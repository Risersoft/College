Imports risersoft.app.mxent
Imports System.Collections.Generic
Imports risersoft.app.mxform.edu
Imports risersoft.app.mxform.college

Public Class frmAttendDay
    Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myView.SetGrid(Me.UGridAtt)
        Me.InitForm()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents UGridAtt As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnPR As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPunch As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnPunch = New Infragistics.Win.Misc.UltraButton()
        Me.btnPR = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.UGridAtt = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UGridAtt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnPunch)
        Me.Panel4.Controls.Add(Me.btnPR)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 453)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(696, 32)
        Me.Panel4.TabIndex = 5
        '
        'btnPunch
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnPunch.Appearance = Appearance1
        Me.btnPunch.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPunch.Location = New System.Drawing.Point(79, 0)
        Me.btnPunch.Name = "btnPunch"
        Me.btnPunch.Size = New System.Drawing.Size(79, 32)
        Me.btnPunch.TabIndex = 12
        Me.btnPunch.Text = "Process Punch"
        '
        'btnPR
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.btnPR.Appearance = Appearance2
        Me.btnPR.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPR.Location = New System.Drawing.Point(0, 0)
        Me.btnPR.Name = "btnPR"
        Me.btnPR.Size = New System.Drawing.Size(79, 32)
        Me.btnPR.TabIndex = 11
        Me.btnPR.Text = "All Present"
        '
        'btnSave
        '
        Appearance3.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance3
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(432, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 32)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance4.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance4
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(520, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance5.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance5
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(608, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_Name)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 48)
        Me.Panel1.TabIndex = 6
        '
        'lbl_Name
        '
        Me.lbl_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Name.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Name.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(696, 48)
        Me.lbl_Name.TabIndex = 0
        Me.lbl_Name.Text = "Mr Rajendra Prasad"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UGridAtt
        '
        Me.UGridAtt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UGridAtt.Location = New System.Drawing.Point(0, 48)
        Me.UGridAtt.Name = "UGridAtt"
        Me.UGridAtt.Size = New System.Drawing.Size(696, 405)
        Me.UGridAtt.TabIndex = 9
        Me.UGridAtt.Text = "Attendance"
        '
        'frmAttendDay
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Attendance (Day Wise)"
        Me.ClientSize = New System.Drawing.Size(696, 485)
        Me.Controls.Add(Me.UGridAtt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAttendDay"
        Me.Text = "Attendance (Day Wise)"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UGridAtt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitForm()
        myView.SetGrid(Me.UGridAtt)
        WinFormUtils.SetButtonConf(Me.btnOK, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmAttendDayModel = Me.InitData("frmAttendDayModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.lbl_Name.Text = "Attendance for " & Format(Convert.ToDateTime(myWinSQL2.ParamValue("@Dated", Me.Model.ModelParams)), "dd-MMM-yyyy")
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Att"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        If Me.ValidateData() Then
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnPR_Click(sender As Object, e As EventArgs) Handles btnPR.Click
        Dim objHRPProcBase As New clsHRProcBase(Me.Controller)
        Dim AttendID As Integer = objHRPProcBase.AttendIDPresent
        myUtils.ChangeAll(myView.mainGrid.myDS.Tables(0).Select("isnull(attendIdFH,0)<>0"), "attendIdFH=" & AttendID & "")
        myUtils.ChangeAll(myView.mainGrid.myDS.Tables(0).Select("isnull(attendIdSH,0)<>0"), "attendIdSH=" & AttendID & "")
    End Sub

    Private Sub btnPunch_Click(sender As Object, e As EventArgs) Handles btnPunch.Click
        If Me.VSave() Then
            Dim Params As New List(Of clsSQLParam)
            Params.Add(New clsSQLParam("@dated", Format(Convert.ToDateTime(myWinSQL2.ParamValue("@Dated", Me.Model.ModelParams)), "dd-MMM-yyyy"), GetType(DateTime), False))
            Dim oRet As clsProcOutput = Me.GenerateParamsOutput("punch", Params)
            If oRet.Success Then
                Me.PrepForm(Me.pView, Me.frmMode, Me.frmIDX, Me.Controller.Data.VarBagXML(Me.vBag))
            Else
                MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
            End If
        End If
    End Sub
End Class


