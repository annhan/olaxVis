#!/usr/bin/ python3
# coding: utf8
from PySide2.QtUiTools import QUiLoader
from PySide2.QtCore import  QMetaObject

class UiLoader(QUiLoader):

    def __init__(self, baseinstance, customWidgets=None):
        QUiLoader.__init__(self, baseinstance)
        self.baseinstance = baseinstance
        self.customWidgets = customWidgets

    def createWidget(self, class_name, parent=None, name=''):
        if parent is None and self.baseinstance:return self.baseinstance
        else:
            if class_name in self.availableWidgets():widget = QUiLoader.createWidget(self, class_name, parent, name)
            else:
                try:widget = self.customWidgets[class_name](parent)
                except (TypeError, KeyError) as e:raise Exception('No custom widget ' + class_name + ' found in customWidgets param of UiLoader __init__.')
            if self.baseinstance:setattr(self.baseinstance, name, widget)
            return widget


def loadUi(uifile, baseinstance=None, customWidgets=None, workingDirectory=None):
    loader = UiLoader(baseinstance, customWidgets)
    if workingDirectory is not None:loader.setWorkingDirectory(workingDirectory)
    widget = loader.load(uifile)
    QMetaObject.connectSlotsByName(widget)
    return widget
