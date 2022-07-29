#!/usr/bin/ python3
# coding: utf8
import  os,sys
from PySide2 import QtWidgets, QtCore
from PySide2.QtCore import Qt 
from PySide2.QtGui import QPixmap
USE_DEBUG = False
if __name__ == "__main__":
    USE_DEBUG = True
    from pysideLoadUi import loadUi
    from PySide2.QtWidgets import QApplication
else:
    from view.pysideLoadUi import loadUi
class popup(QtWidgets.QDialog):
    def __init__(self,style = None,ui = 'ui/popup.ui'):
        super().__init__()
        self.idDevice = 0
        loadUi(ui, self )
        self.data_select = [0,4] # 4 laf 100%, 0 is glass type 0
        self.setWindowFlag(QtCore.Qt.WindowStaysOnTopHint)
        self.setAttribute(QtCore.Qt.WA_DeleteOnClose)
        self.initEvent()
        self.initvalue()
        self.setAttribute(Qt.WA_TranslucentBackground)   
        self.setWindowFlags(Qt.FramelessWindowHint)# hide title
        self.setWindowFlag(Qt.WindowStaysOnTopHint)
        self.set_style()

    def initEvent(self):
        self.btn_return.clicked.connect(lambda :self.hide())
        self.btn_group_type.buttonClicked.connect(self.on_typeGlass_changed)
        self.btn_group_percent.buttonClicked.connect(self.btn_group_percent_changed)
        #self.typeGlass.currentTextChanged.connect(self.on_typeGlass_changed)

    def initvalue(self):
        type_glass = 1
        percent = 100
        getattr(self, 'btn_type_' + str(type_glass)).setChecked(True)
        getattr(self, 'btn_percent_' + str(percent)).setChecked(True)
        self.updateImage(type_glass)
        self.data_select = [type_glass,percent // 25]

    def updateID(self, orderID):
        self.idDevice = orderID
        self.initvalue()

    def updateImage(self,image):
        image = "Glass{}.jpg".format(image)
        mainpath = os.path.dirname(os.path.abspath(__file__))
        if USE_DEBUG:
            goal_dir = os.path.join(mainpath, '../../data/res/Food', image)
        else:
            goal_dir = os.path.join(mainpath, '../../data/res/Food', image)
        goal_dir = os.path.abspath(goal_dir)
        pixmap = QPixmap(goal_dir)
        self.lblImageGlass.setPixmap(pixmap.scaled(
                            self.lblImageGlass.size(),
                            QtCore.Qt.KeepAspectRatio,
                            QtCore.Qt.SmoothTransformation))

    def btn_group_percent_changed(self,btn):
        index = btn.property("index")
        btn.setChecked(True)
        self.data_select[1] = index
        print("percent",index, flush=True)

    def on_typeGlass_changed(self,btn):
        index = btn.property("index")
        self.data_select[0] = index
        btn.setChecked(True)
        print("type glass",index, flush=True)
        self.updateImage(index)

    def set_style(self):
        mainpath = os.path.dirname(os.path.abspath(__file__))
        goal_dir = os.path.join(mainpath, 'res','popup.qss')
        goal_dir = os.path.abspath(goal_dir)
        qss_file = open(goal_dir).read()
        self.setStyleSheet(qss_file)
        
if __name__ == "__main__":
    app = QApplication(sys.argv)
    msg = None
    def create():
        msg = popup(ui ='../ui/popup.ui')
        msg.set_style()
        msg.exec()
    create()
    #exit()
        

"""
 QComboBox {
                                    background: qlineargradient(
                                    x1:0, y1:0, x2:0, y2:1,
                                    stop:0 #f9f9f9,
                                    stop: 0.5 #c6c6c6,
                                    stop: 0.6 #dfdfdf,
                                    stop:1 #f9f9f9 );
                                    border-style: solid;
                                    border-width: 1px;
                                    border-color: rgb(0, 93, 168);
                                    border-radius: 30px;
                                    color: rgb(0, 93, 168);
                                    min-width: 170px;
                                    min-height: 60px;
                                    padding-left: 15px;
                                 }
                                QComboBox:on {border-radius: 30px;background:transparent;}
                                QComboBox::drop-down {
                                    
                                    subcontrol-position: center right;
                                    margin-right: 10px;
                                }

                                QComboBox QAbstractItemView::item { min-height: 1000px; min-width: 5000px; }
                                QListView::item:selected { color: black; background-color: lightgray}   
                                QComboBox QAbstractItemView {
                                    color: rgb(0, 93, 168);
                                    background: transparent;
                                    border: 2px solid darkgray;
                                    selection-background-color: lightgray;
                                    min-height: 400px;
                                }

"""