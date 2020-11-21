Imports risersoft.app.mxform.college
Imports System.Configuration

Public Class frmNAAC
    Inherits frmMax
    Dim ServerPath As String = "", LocalPath As String = ""

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
        Me.GetExtensionName()
    End Sub

    Public Function GetExtensionName()
        Dim FileExtCode = System.IO.Path.GetExtension(myUtils.cStrTN(Me.SaveFileDialog1.FileName))
        Dim FileExt = myWinFtp.FileExtText(FileExtCode)

        'myRow("FileType") = Me.Controller.FTP.FileExtText(FileExt)

        Dim strFilter As String = FileExt & " (*" & FileExtCode & ")|*" & FileExtCode
        Me.SaveFileDialog1.Filter = strFilter

    End Function

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmNAACModel = Me.InitData("frmNAACModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            InitUpLoad1()
            InitUpLoad2()
            InitUpLoad3()

            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "Session", "", Me.cmb_FinyearID)
            myWinSQL.AssignCmb(Me.dsCombo, "company", "", Me.cmb_CompanyID)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Function InitUpLoad1()
        Dim str1 As String = ""
        str1 = "XLS File|*.xls|XLSX File|*.xlsx|Word Document(.doc)|*.doc|Word XML Document (.docx)|*.docx|Rich Text File (*.rtf)|*.rtf|Portable Document File(.pdf)|*.pdf"

        Me.CtlUpLoad2.InitFilter(EnumfrmMode.acEditM, "", Me.Controller.App.objAppExtender.FileServerPath, "", str1, ConfigurationManager.AppSettings("StorageContainerName"))
        AddHandler Me.CtlUpLoad2.FileSelected, Sub(SelectedFile As String)
                                                   LocalPath = SelectedFile
                                                   Dim UniqueFileId = System.Guid.NewGuid.ToString
                                                   Me.CtlUpLoad2.FileName = System.IO.Path.GetFileNameWithoutExtension(SelectedFile) & "-" & UniqueFileId & System.IO.Path.GetExtension(SelectedFile)
                                               End Sub
        AddHandler Me.CtlUpLoad2.FileUploaded, Sub(ByVal localFile As String, ServerPath As String)
                                                   Me.ServerPath = ServerPath
                                                   'myRow("FileURL") = ServerPath
                                                   myRow("IQAC") = Me.CtlUpLoad2.FileName
                                               End Sub
        Return True
    End Function

    Private Function InitUpLoad2()
        Dim str1 As String = ""
        str1 = "XLS File|*.xls|XLSX File|*.xlsx|Word Document(.doc)|*.doc|Word XML Document (.docx)|*.docx|Rich Text File (*.rtf)|*.rtf|Portable Document File(.pdf)|*.pdf"

        Me.CtlUpLoad2.InitFilter(EnumfrmMode.acEditM, "", Me.Controller.App.objAppExtender.FileServerPath, "", str1, ConfigurationManager.AppSettings("StorageContainerName"))
        AddHandler Me.CtlUpLoad2.FileSelected, Sub(SelectedFile As String)
                                                   LocalPath = SelectedFile
                                                   Dim UniqueFileId = System.Guid.NewGuid.ToString
                                                   Me.CtlUpLoad2.FileName = System.IO.Path.GetFileNameWithoutExtension(SelectedFile) & "-" & UniqueFileId & System.IO.Path.GetExtension(SelectedFile)
                                               End Sub
        AddHandler Me.CtlUpLoad2.FileUploaded, Sub(ByVal localFile As String, ServerPath As String)
                                                   Me.ServerPath = ServerPath
                                                   'myRow("FileURL") = ServerPath
                                                   myRow("AQAR") = Me.CtlUpLoad2.FileName
                                               End Sub
        Return True
    End Function

    Private Function InitUpLoad3()
        Dim str1 As String = ""
        str1 = "XLS File|*.xls|XLSX File|*.xlsx|Word Document(.doc)|*.doc|Word XML Document (.docx)|*.docx|Rich Text File (*.rtf)|*.rtf|Portable Document File(.pdf)|*.pdf"

        Me.CtlUpLoad2.InitFilter(EnumfrmMode.acEditM, "", Me.Controller.App.objAppExtender.FileServerPath, "", str1, ConfigurationManager.AppSettings("StorageContainerName"))
        AddHandler Me.CtlUpLoad2.FileSelected, Sub(SelectedFile As String)
                                                   LocalPath = SelectedFile
                                                   Dim UniqueFileId = System.Guid.NewGuid.ToString
                                                   Me.CtlUpLoad2.FileName = System.IO.Path.GetFileNameWithoutExtension(SelectedFile) & "-" & UniqueFileId & System.IO.Path.GetExtension(SelectedFile)
                                               End Sub
        AddHandler Me.CtlUpLoad2.FileUploaded, Sub(ByVal localFile As String, ServerPath As String)
                                                   Me.ServerPath = ServerPath
                                                   'myRow("FileURL") = ServerPath
                                                   myRow("SSR") = Me.CtlUpLoad2.FileName
                                               End Sub
        Return True
    End Function

End Class