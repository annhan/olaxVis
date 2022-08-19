#!/usr/bin/ python3
# coding: utf8

import requests, time , datetime , sys ,re
from PySide2 import QtWidgets,QtCore
from PySide2.QtCore import Qt 
from pysideLoadUi import loadUi
from PySide2.QtWidgets import QApplication
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from threading import Thread
from threading import Lock
import requests
from get_config import config 
import pyotp
import base64

def print_debug(*msg):
    print(datetime.datetime.now().strftime("%H:%M:%S"), "|" , *msg, flush=True)
    sys.stdout.flush()
class reset_ip_Olax():
    def __init__(self,user = None , password = None, page = None):
        self.username = user
        self.password = password
        self.page = page
    def run(self):
        print_debug("reset olax")
        return ("{}: Airtel chưa xây dựng ".format(datetime.datetime.now().strftime("%H:%M:%S")))

class reset_ip_Viettel():
    def __init__(self,user = None , password = None, page = None):
        self.username = user
        self.password = password
        self.page = page
    def run(self):
        print_debug("reset olax")
        return ("{}: Viettel chưa xây dựng ".format(datetime.datetime.now().strftime("%H:%M:%S")))

class reset_ip_VNPT():
    def __init__(self,user = None , password = None, page = None):
        self.username = user
        self.password = password
        self.page = page
    def run(self):
        print_debug("reset olax")
        return ("{}: VNPT chưa xây dựng ".format(datetime.datetime.now().strftime("%H:%M:%S")))

class reset_ip_FPT():
    def __init__(self,user = None , password = None, page = None):
        self.username = user
        self.password = password
        self.page = page

    def run(self):
        def close_chrome(dri):
            try: 
                dri.close() 
            except Exception as e : 
                print_debug("can't closechrome {}".format(e)) 
            time.sleep(1)
            try: 
                dri.quit() 
            except Exception as e : 
                print_debug("can't quit chrome {}".format(e)) 
            #dri.dispose()
        try:
            msg1 = ""
            msg2 = ""
            options = webdriver.ChromeOptions()
            #options.binary_location  = r'E:\\Arduino\\Github\\01Finance\\olaxVis\\Python\\GoogleChromePortable\\GoogleChromePortable.exe'  
            #options.binary_location  = 'E:/Arduino/Github/01Finance/olaxVis/Python/GoogleChromePortable/GoogleChromePortable.exe'  
            options.binary_location  = './GoogleChromePortable/App/Chrome-bin/chrome.exe'
            options.add_argument("headless")
            chromedriverpath='chromedriver.exe' #chromedriverpath
            options.add_argument("--disable-extensions")
            options.add_argument("--disable-gpu")
            options.add_argument("--disable-dev-shm-usage")
            options.add_argument("--no-sandbox")
            options.add_experimental_option('excludeSwitches', ['enable-logging'])

            try:
                driver = webdriver.Chrome(options=options)
                #webdriver.Chrome(executable_path=chromedriverpath, options=chromeoptions)
                username = self.username
                password = self.password
                try:
                    driver.get(self.page)
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
                close_chrome(driver)
            except Exception as e: 
                print_debug("error Exception {}".format(e)) 
                m = re.search("version is (.+?) with binary path", str(e))
                if m:
                    found = m.group(1)
                    msg2 = ("{}: NEED to download chromedriver ver: {}".format(datetime.datetime.now().strftime("%H:%M:%S"),found))
                close_chrome(driver)

        except : 
            try:
                close_chrome(driver)
            except Exception as e : 
                print_debug("can't  chrome {}".format(e)) 
        finally: 
            return msg2



class CustomMessageBox(QtWidgets.QMainWindow):
    reset_ip_finish = QtCore.Signal(str)
    read_ip_finish = QtCore.Signal(str)
    def __init__(self,style=None,ui = 'ui.ui'):
        super().__init__()
        self.config = config()
        self.user,self.password,self.name,self.page = self.config.get_router()
        self.gchrome_path = self.config.get_chrome_path()
        self.license,self.license_code = self.config.get_license()
        self.server,self.timeout = self.config.get_ip()
        
        self.status_reset = Lock()
        self.status_get_ip = Lock()
        self.status_lock_auto = Lock()
        self.idDevice = 0
        loadUi(ui, self )
        self.set_default()
        self.status_license = False
        self.autoclose = True
        self.currentTime = 0 
        self.set_style()
        if "show code" in self.input_license.toPlainText():
            self.btn_update_license_2.show()  
        else:
            self.btn_update_license_2.hide()  
        #self.setWindowFlag(Qt.WindowStaysOnTopHint)
        self.setAttribute(Qt.WA_DeleteOnClose, True)
        self.btn_1.clicked.connect(self.btn_1_click)  
        self.btn_2.clicked.connect(self.btn_2_click)
        self.btn_3.clicked.connect(self.btn_3_click)
        self.reset_ip_finish.connect(self.reset_ip_finish_event)
        self.read_ip_finish.connect(self.thread_read_ip_finish)
        self.lbl_status.setText("Fail")
        self.mylist_ip = [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]
        self.i = 0
        self.btn_update_user.clicked.connect(self.btn_update_user_click)  
        self.btn_update_license.clicked.connect(self.update_license_click) #update license
        self.btn_update_license_2.clicked.connect(self.genera_license_click) #update license
        self.btn_update_user_2.clicked.connect(self.update_router_click) # updaye type router
        self.btn_group_main.buttonClicked.connect(self.change_main_windown_click) # updaye type router
        self.check_code()
        self.add_combobox()
        self.btn_1_click(1)# load ip when begin

    def add_combobox(self):
        self.comboBox.addItems(['FPT G97RG6W','USB 4G Airtel', 'Viettel' , 'VNPT'])
        self.comboBox.setCurrentIndex(int(self.name))
        #self.comboxBox.currentData()
        #self.combo_box.currentText()

    def update_router_click(self):
        data = self.comboBox.currentIndex()
        
        self.name = data
        print_debug("Router change to {}".format(self.name )) 
        self.config.save_type_router(str(self.name))


    def set_default(self):
        self.tab_main.setCurrentIndex(0)
        self.setWindowTitle("CHANGE IP OF ROUTER")
        self.btn_1.setText("Get IP")
        self.btn_2.setText("Change IP")
        self.btn_3.setText("Change and Check IP")
        self.input_user.setText(self.user)
        self.input_pass.setText(self.password)
        self.input_license.setText(self.license)
        self.input_license_CODE.setText(self.license_code)
        
        self.lbl_about.setText("@annhandt09")
        self.lbl_status_license.setText("Checking ...")

    def create_license_key(self,secret_code):
        code = 000000
        try:
            secret = base64.b32encode(bytes(secret_code, encoding='ascii'))
            hotp = pyotp.HOTP(secret)
            code = hotp.at(1401) # => '316439'
            code = int(code)
        except Exception as e: 
            print_debug("error Exception check code {}".format(e))  
        return code

    def check_code(self):
        try:
            code = self.create_license_key(self.password)
            if (int(self.license_code) == code):
                self.status_license = True
                self.lbl_status_license.setText("License OK.")
            else:
                self.disable_license()
                self.lbl_status_license.setText("License Error.")
        except Exception as e: 
            self.disable_license()
            print_debug("error Exception check code {}".format(e)) 

    def genera_license_click(self):
        try:
            code = self.create_license_key(self.password)
            print_debug("get {}".format(code))
        except Exception as e: 
            print_debug("error Exception check code {}".format(e))  
 
    def disable_license(self):
        self.status_license = False   

    ####################
    ## Event GUI
    ###############)
    def btn_update_user_click(self):
        self.user =  self.input_user.toPlainText()   
        self.password =self.input_pass.toPlainText()
        print_debug("new user {} - password:{}".format(self.user,self.password))
        self.config.save_user_web(self.user,self.password)

    def update_license_click(self):
        self.license =  self.input_license.toPlainText()   
        self.license_code =self.input_license_CODE.toPlainText()
        print_debug("new license {} - code:{}".format(self.license,self.license_code))
        self.config.set_license(self.license,self.license_code)
        self.check_code()

    def check_license(func):
        def check(self,*args, **kwarg):
            if self.status_license == False: 
                self.lbl_status.setText("License Error")
                return     
            func(self,*args, **kwarg)
        return check        

    def change_main_windown_click(self,btn):
        index = btn.property("index")
        if index is None: return 
        self.tab_main.setCurrentIndex(index)

    @check_license
    def btn_2_click(self,value=1):    

        function = self.thread_reset_ip
        t1=Thread(target=function)
        t1.start()

    @check_license
    def btn_1_click(self,value=1):
        self.lbl_status.setText("Waiting Get IP")
        t1=Thread(target=self.read_ip_thread)
        t1.start() 

    @check_license
    def btn_3_click(self,value=1):
        t1=Thread(target=self.auto)
        t1.start()
        
    #################################
    ## Event thrad finish ###########
    #################################
    def thread_read_ip_finish(self,value):
        self.lbl_status.setText("Get Ip Done")
        print_debug('My public IP address is main: {}'.format(value))
        if value == '0':
            self.lbl_status.setText("IP - Error")
        else:
            self.lbl_status.setText("IP - OK")
        self.check_ip_dupl(value)
        self.lbl_log.append("{}: GET IP {}".format(datetime.datetime.now().strftime("%H:%M:%S"),value))
        self.lbl_ip.setText(value)
        print_debug("finish")

    def reset_ip_finish_event(self,value):
        if value == "er":
            self.lbl_status.setText("Reset Error")
        else:
            self.lbl_status.setText("Reset Done")
        print_debug("reset finish")
        self.lbl_log.append("{}: RESET OK ".format(datetime.datetime.now().strftime("%H:%M:%S")))


    ############
    ## thread
    ####################
    def auto(self):
        if self.status_lock_auto.acquire(timeout = 1) == False: return   
        try:
            self.btn_2_click(1)
            self.status_reset.acquire()   
            time.sleep(1)
            self.btn_1_click(1)
        finally:
            self.status_reset.release()
            self.status_lock_auto.release()

    def get_type_router(self):
        if int(self.name) == 0: #"FPT-G-97RG6W"
            fund = reset_ip_FPT(self.user,self.password,self.page)
        elif int(self.name) == 1: # USB 4G 
            fund = reset_ip_Olax(self.user,self.password,self.page)
        elif int(self.name) == 2: # USB 4G 
            fund = reset_ip_Viettel(self.user,self.password,self.page)
        elif int(self.name) == 3: # USB 4G 
            fund = reset_ip_VNPT(self.user,self.password,self.page)
        return fund

    def thread_reset_ip(self):
        fund = self.get_type_router()
        if self.status_reset.acquire(timeout = 1) == False: return  
        try:
            self.lbl_status.setText("Waiting Reset")
            self.lbl_log.append(fund.run())
            self.reset_ip_finish.emit("ok")
        except Exception as e :
            self.reset_ip_finish.emit("er")
        finally: 
            self.status_reset.release()
            

    def read_ip_thread(self): #(w, verify=False, timeout=10)
        if self.status_get_ip.acquire(timeout = 1) == False: return             
        try: 
            print_debug("get {}  {}".format(self.server,self.timeout))
            ip = requests.get(self.server, timeout= float(self.timeout)).content.decode('utf8')
        except requests.exceptions.Timeout as e: 
            print_debug("error {}".format(e))
            ip = '0'
        finally:
            self.status_get_ip.release()
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

        


    
