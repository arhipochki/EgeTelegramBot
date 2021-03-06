# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'data_builder_main_window.ui'
#
# Created by: PyQt5 UI code generator 5.15.6
#
# WARNING: Any manual changes made to this file will be lost when pyuic5 is
# run again.  Do not edit this file unless you know what you are doing.


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(699, 336)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.jsonList = QtWidgets.QListWidget(self.centralwidget)
        self.jsonList.setGeometry(QtCore.QRect(30, 11, 256, 231))
        self.jsonList.setObjectName("jsonList")
        self.questionLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.questionLineEdit.setGeometry(QtCore.QRect(420, 50, 201, 31))
        self.questionLineEdit.setObjectName("questionLineEdit")
        self.answerLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.answerLineEdit.setGeometry(QtCore.QRect(420, 90, 201, 31))
        self.answerLineEdit.setObjectName("answerLineEdit")
        self.cardsLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.cardsLineEdit.setGeometry(QtCore.QRect(420, 130, 201, 31))
        self.cardsLineEdit.setObjectName("cardsLineEdit")
        self.filePathLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.filePathLineEdit.setGeometry(QtCore.QRect(420, 210, 201, 31))
        self.filePathLineEdit.setObjectName("filePathLineEdit")
        self.addBtn = QtWidgets.QPushButton(self.centralwidget)
        self.addBtn.setGeometry(QtCore.QRect(470, 250, 101, 32))
        self.addBtn.setObjectName("addBtn")
        self.removeBtn = QtWidgets.QPushButton(self.centralwidget)
        self.removeBtn.setGeometry(QtCore.QRect(60, 250, 81, 32))
        self.removeBtn.setObjectName("removeBtn")
        self.openFileBtn = QtWidgets.QPushButton(self.centralwidget)
        self.openFileBtn.setGeometry(QtCore.QRect(630, 210, 61, 32))
        self.openFileBtn.setObjectName("openFileBtn")
        self.questionLabel = QtWidgets.QLabel(self.centralwidget)
        self.questionLabel.setGeometry(QtCore.QRect(340, 60, 60, 16))
        self.questionLabel.setObjectName("questionLabel")
        self.answerLabel = QtWidgets.QLabel(self.centralwidget)
        self.answerLabel.setGeometry(QtCore.QRect(340, 100, 60, 16))
        self.answerLabel.setObjectName("answerLabel")
        self.cardsLabel = QtWidgets.QLabel(self.centralwidget)
        self.cardsLabel.setGeometry(QtCore.QRect(340, 140, 60, 16))
        self.cardsLabel.setObjectName("cardsLabel")
        self.filePathLabel = QtWidgets.QLabel(self.centralwidget)
        self.filePathLabel.setGeometry(QtCore.QRect(340, 220, 60, 16))
        self.filePathLabel.setObjectName("filePathLabel")
        self.themeLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.themeLineEdit.setGeometry(QtCore.QRect(420, 10, 201, 31))
        self.themeLineEdit.setObjectName("themenLineEdit")
        self.themeLabel = QtWidgets.QLabel(self.centralwidget)
        self.themeLabel.setGeometry(QtCore.QRect(340, 20, 60, 16))
        self.themeLabel.setObjectName("themeLabel")
        self.explanationLabel = QtWidgets.QLabel(self.centralwidget)
        self.explanationLabel.setGeometry(QtCore.QRect(340, 180, 81, 16))
        self.explanationLabel.setObjectName("explanationLabel")
        self.explanationLineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.explanationLineEdit.setGeometry(QtCore.QRect(420, 170, 201, 31))
        self.explanationLineEdit.setObjectName("explanationLineEdit")
        self.editBtn = QtWidgets.QPushButton(self.centralwidget)
        self.editBtn.setGeometry(QtCore.QRect(170, 250, 81, 32))
        self.editBtn.setObjectName("editBtn")
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 699, 21))
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 699, 24))
        self.menubar.setObjectName("menubar")
        self.menubar.setNativeMenuBar(True)
        self.fileAction = self.menubar.addMenu('&File')
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)


    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "Data Builder"))
        self.addBtn.setText(_translate("MainWindow", "Add"))
        self.removeBtn.setText(_translate("MainWindow", "Remove"))
        self.openFileBtn.setText(_translate("MainWindow", "Open"))
        self.questionLabel.setText(_translate("MainWindow", "Quesion"))
        self.answerLabel.setText(_translate("MainWindow", "Answer"))
        self.cardsLabel.setText(_translate("MainWindow", "Cards"))
        self.filePathLabel.setText(_translate("MainWindow", "FilePath"))
        self.themeLabel.setText(_translate("MainWindow", "Theme"))
        self.explanationLabel.setText(_translate("MainWindow", "Explanation"))
        self.editBtn.setText(_translate("MainWindow", "Edit"))
