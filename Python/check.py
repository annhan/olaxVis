#!/usr/bin/ python3
# coding: utf8

import requests, json ,time , datetime , sys ,re
from PySide2 import QtWidgets,QtCore
from PySide2.QtCore import Qt 
from pysideLoadUi import loadUi
from PySide2.QtWidgets import QApplication
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

from threading import *
from importlib.machinery import SourceFileLoader
config = SourceFileLoader( 'config', './config.py' ).load_module()
import requests

def print_debug(*msg):
    print(datetime.datetime.now().strftime("%H:%M:%S"), "|" , *msg, flush=True)
    sys.stdout.flush()

class CustomMessageBox(QtWidgets.QMainWindow):
    reset_ip_finish = QtCore.Signal(str)
    read_ip_finish = QtCore.Signal(str)
    def __init__(self,style=None,ui = 'ui.ui'):
        super().__init__()
        self.status_reset = False
        self.status_get_ip = False
        self.idDevice = 0
        loadUi(ui, self )
        self.set_default()
        self.timeout = 0
        self.autoclose = True
        self.currentTime = 0 
        self.set_style()
        self.setWindowFlag(Qt.WindowStaysOnTopHint)
        self.setAttribute(Qt.WA_DeleteOnClose, True)
        self.btn_1.clicked.connect(self.btn_1_click)  
        self.btn_2.clicked.connect(self.btn_2_click)
        self.btn_3.clicked.connect(self.btn_3_click)
        self.reset_ip_finish.connect(self.reset_ip_finish_event)
        self.read_ip_finish.connect(self.thread_read_ip_finish)
        self.lbl_status.setText("Fail")
        self.mylist_ip = [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]
        self.i = 0

    def set_default(self):
        self.setWindowTitle("CHANGE IP OF ROUTER")
        self.btn_1.setText("Get IP")
        self.btn_2.setText("Change IP")
        self.btn_3.setText("Change and Check IP")
        self.lbl_2.setText("@annhandt09")
        self.btn_4.hide()
    ####################
    ## Event GUI
    ###############
    def btn_2_click(self,value):
        if self.status_reset == True:return
        function = self.reset_FPT_97RG6W
        if config.TYPE_ROUTER['name'] == "FPT-G-97RG6W":
            function = self.reset_FPT_97RG6W

        t1=Thread(target=function)
        t1.start()

    def btn_1_click(self,value):
        if self.status_reset == True:return
        if self.status_get_ip == True:return
        self.status_get_ip = True
        self.lbl_status.setText("Waiting Get IP")
        t1=Thread(target=self.read_ip_thread)
        t1.start() 

    def btn_3_click(self,value):
        t1=Thread(target=self.auto)
        t1.start()
    #################################
    ## Event thrad finish ###########
    #################################
    def thread_read_ip_finish(self,value):
        self.lbl_status.setText("Get Ip Done")
        self.status_get_ip = False
        print_debug('My public IP address is main: {}'.format(value))
        if value == '0':
            self.lbl_status.setText("IP - Error")
        else:
            self.lbl_status.setText("IP - OK")
        self.check_ip_dupl(value)
        self.lbl_log.append("{}:GET IP {}".format(datetime.datetime.now().strftime("%H:%M:%S"),value))
        self.lbl_ip.setText(value)
        print_debug("finish")

    def reset_ip_finish_event(self,value):
        self.lbl_status.setText("Reset Done")
        print_debug("reset finish")
        self.lbl_log.append("{}: SESET OK ".format(datetime.datetime.now().strftime("%H:%M:%S")))
        self.status_reset = False
    ############
    ## thread
    ####################
    def auto(self):
        self.btn_2_click(1)
        time.sleep(1)
        while (self.status_reset == True):
            time.sleep(1)
        time.sleep(1)
        self.btn_1_click(1)

    def reset_FPT_97RG6W(self):      
        self.status_reset = True
        self.lbl_status.setText("Waiting Reset")
        options = webdriver.ChromeOptions()
        options.add_argument("headless")
        try:
            driver = webdriver.Chrome(config.PATH_CHROME, options=options)
        except Exception as e: 
            print_debug("error Exception ddd {}".format(e)) 
            m = re.search("version is (.+?) with binary path", str(e))
            if m:
                found = m.group(1)
                self.lbl_log.append("{}: NEED to download chromedriver ver: {}".format(datetime.datetime.now().strftime("%H:%M:%S"),found))
            return
        username = config.TYPE_ROUTER['user']
        password = config.TYPE_ROUTER['pass']
        try:
            driver.get(config.TYPE_ROUTER['login_page'])
            driver.implicitly_wait(20)
        
            try:    
                button = driver.find_element(By.ID,"username").send_keys(username)
                button = driver.find_element(By.ID,"password").send_keys(password)
                button = driver.find_element(By.ID,'btn_login').click()
            except Exception as e:  
                print_debug("fdfffffffffffffffffffffffff",e)
            driver.implicitly_wait(5)
            driver.switch_to.frame("contentfrm")
            button = driver.find_element(By.ID ,"waninfo").click()
            driver.implicitly_wait(5)
            button = driver.find_element(By.ID,'btn_reconnect').click()
        except Exception as e: 
            print_debug("error Exception{}".format(e)) 
            try: driver.close() 
            except : pass
            time.sleep(0.1)
            try: driver.quit() 
            except : pass
        self.reset_ip_finish.emit("ip")

    def read_ip_thread(self): #(w, verify=False, timeout=10)
        try: 
            ip = requests.get('https://api.ipify.org', timeout= config.TYPE_ROUTER['timeout_get_ip']).content.decode('utf8')
        except requests.exceptions.Timeout as e: 
            print_debug("error {}".format(e))
            ip = '0'
        self.read_ip_finish.emit(ip)
    ##################
    ## funtions  #####
    ##################
    def check_ip_dupl(self,value):
        if value == '0': 
            return
        self.i = self.i + 1
        if self.i>19:
            self.i = 0
        for i in range(0,19):
            if value == self.mylist_ip[i]:
                self.lbl_status.setText("IP - Trùng")
                return
        self.mylist_ip[self.i] = value
        print_debug("ok")

    def set_style(self,type = 0):
        self.setStyleSheet("""
                            QDialog { 
                                border-radius: 30px; 
                                border: 3.5px solid; 
                                border-color: qlineargradient(x1: 1, y1: 1, x2: 0, y2: 0, stop: 0 #ffeb7f, stop: 1 #d09d1e); 
                                background: qlineargradient(x1: 0, y1: 0, x2: 1, y2: 1, stop: 0 #ffeb7f, stop: 1 #d09d1e); 
                                color: #003200;
                            }
                            .QFrame {
                                border: 5px solid green;
                                border-radius:30px;
                                background-color: #d4fab6;
                            }
                            QLabel{min-width: 100px;font-size:20px;}
                            QLineEdit{min-width: 100px;font-size:18px;border: 20px solid black;border-radius: 4px;}
                            QPushButton{border: 3px solid black;border-radius: 20px;font: 15pt;min-width: 150px;}
                            QPushButton:pressed {border-color: blue;background-color: #d0d67c;color: #0000FF;}
                            QPushButton:hover{border: 2px solid blue;}""")

    def exit_dialog(self,type = 0):
        self.done(0)

if __name__ == "__main__":
    app = QApplication(sys.argv)
    msg = CustomMessageBox(ui ='ui.ui')
    msg.show()
    sys.exit(app.exec_())

        


    
