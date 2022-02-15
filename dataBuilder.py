import json
import sys

from PyQt5 import QtWidgets
from PyQt5.QtGui import QIcon
from mainWindowUi import Ui_MainWindow
from dialogWindow import Ui_editDialog


class DialogWindow(QtWidgets.QDialog):
    def __init__(self, parent=None):
        QtWidgets.QDialog.__init__(self, parent)
        self.ui = Ui_editDialog()
        self.ui.setupUi(self)
        self.ui.okBtn.clicked.connect(self.okBtnClicked)
        self.ui.cancelBtn.clicked.connect(self.cancelBtnClicked)


    def setData(self, theme="", question="", answer="", cards="", filePath="", explanation=""):
        self.ui.themeLineEdit.setText(theme)
        self.ui.questionLineEdit.setText(question)
        self.ui.answerLineEdit.setText(answer)
        self.ui.cardsLineEdit.setText(cards)
        self.ui.filePathLineEdit.setText(filePath)
        self.ui.explanationLineEdit.setText(explanation)


    def getData(self):
        return f"{self.ui.themeLineEdit.text()};{self.ui.questionLineEdit.text()};{self.ui.answerLineEdit.text()};" + f"{self.ui.cardsLineEdit.text()};{self.ui.filePathLineEdit.text()};{self.ui.explanationLineEdit.text()}"


    def okBtnClicked(self):
        self.close()


    def cancelBtnClicked(self):
        self.ui.themeLineEdit.clear()
        self.ui.questionLineEdit.clear()
        self.ui.answerLineEdit.clear()
        self.ui.cardsLineEdit.clear()
        self.ui.filePathLineEdit.clear()
        self.ui.explanationLineEdit.clear()
        
        self.close()


class MainWindow(QtWidgets.QMainWindow):
    def __init__(self):
        super(MainWindow, self).__init__()

        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        self.ui.addBtn.clicked.connect(self.addBtnClicked)
        self.ui.removeBtn.clicked.connect(self.removeBtnClicked)
        self.ui.editBtn.clicked.connect(self.editBtnClicked)
        self.ui.openFileBtn.clicked.connect(self.openBtnClicked)

        saveAction = QtWidgets.QAction(QIcon(), "Save", self)
        saveAction.setShortcut("Ctrl+S")
        saveAction.triggered.connect(self.saveBtnClicked)

        loadAction = QtWidgets.QAction(QIcon(), "Load", self)
        loadAction.setShortcut("Ctrl+O")
        loadAction.triggered.connect(self.loadBtnClicked)

        self.ui.fileAction.addActions([saveAction, loadAction])


    def addBtnClicked(self):
        self.ui.jsonList.addItem(
            f"{self.ui.themeLineEdit.text()};{self.ui.questionLineEdit.text()};{self.ui.answerLineEdit.text()};" +
            f"{self.ui.cardsLineEdit.text()};{self.ui.filePathLineEdit.text()};{self.ui.explanationLineEdit.text()}"
        )

        self.clearAllLines()

    
    def clearAllLines(self):
        self.ui.themeLineEdit.clear()
        self.ui.questionLineEdit.clear()
        self.ui.answerLineEdit.clear()
        self.ui.cardsLineEdit.clear()
        self.ui.filePathLineEdit.clear()
        self.ui.explanationLineEdit.clear()


    def removeBtnClicked(self):
        self.ui.jsonList.takeItem(self.ui.jsonList.row(self.ui.jsonList.selectedItems()[0]))


    def editBtnClicked(self):
        dialog = DialogWindow()
        data = self.ui.jsonList.item(self.ui.jsonList.currentRow()).text().split(";")
        dialog.setData(theme=data[0], question=data[1], answer=data[2], cards=data[3], filePath=data[4], explanation=data[5])
        dialog.exec()

        if dialog.getData() != (";" * 5):
            self.ui.jsonList.item(self.ui.jsonList.currentRow()).setText(dialog.getData())


    def openBtnClicked(self):
        file, _ = QtWidgets.QFileDialog.getOpenFileName(self, 'Open file', None, "Image (*.png *.jpg *jpeg)")

        self.ui.filePathLineEdit.setText(file)


    def saveBtnClicked(self):
        outDict = {}

        outDict["0"] = {
            "Theme": "",
            "Question": "",
            "Answer": "",
            "Cards": tuple([""]),
            "FilePath": "",
            "Explanation": ""
        }

        count = 1
        for i in range(self.ui.jsonList.count()):
            data = self.ui.jsonList.item(i).text().split(";")

            outDict[str(count)] = {
                "Theme": data[0],
                "Question": data[1],
                "Answer": data[2],
                "Cards": tuple(data[3].split(" ")),
                "FilePath": data[4],
                "Explanation": data[5]
            }

            count += 1

        name = QtWidgets.QFileDialog().getSaveFileName(self, "Save file")
        with open(name[0] + ".json", "w", encoding="utf-8") as file:
            json.dump(outDict, file, indent=4, ensure_ascii=False)


    def loadBtnClicked(self):
        self.clearAllLines()
        self.ui.jsonList.clear()

        outDict = {}

        name = QtWidgets.QFileDialog.getOpenFileName(self, "Open file")
        with open(name[0], "r", encoding='utf-8') as file:
            outDict = json.load(file)

        for i in range(1, len(outDict)):
            self.ui.jsonList.addItem(
                f"{outDict[str(i)]['Theme']};{outDict[str(i)]['Question']};{outDict[str(i)]['Answer']};" +
                " ".join(outDict[str(i)]['Cards']) + f";{outDict[str(i)]['FilePath']};{outDict[str(i)]['Explanation']}"
            )


def main():
    app = QtWidgets.QApplication([])
    win = MainWindow()
    win.show()

    sys.exit(app.exec())


if __name__ == "__main__":
    main()
