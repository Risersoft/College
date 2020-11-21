Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class frmStudent
    Inherits frmMax

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        Me.InitForm()
    End Sub

    ' Form overrides dispose to clean up the component list.
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_ClassID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_campusid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_shiftid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dt_LeaveDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dt_AdmissionDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txt_SerialNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btn_Person As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_CardNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmb_SubjectGroup = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txt_RegistrationNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_AdmissionType = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_AdmittedAs = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_ListNumber = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txt_SerialNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmb_ClassID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmb_PunchEnabled = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmb_campusid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_RollNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmb_shiftid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_CardNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dt_AdmissionDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dt_LeaveDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridStuSubject = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnDelSub = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddSub = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridStuPaper = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddNew = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_Person = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cmb_SubjectGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RegistrationNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_AdmissionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_AdmittedAs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ListNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ClassID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_PunchEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RollNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CardNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_AdmissionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_LeaveDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGridStuSubject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.UltraGridStuPaper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(895, 306)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.cmb_SubjectGroup)
        Me.UltraGroupBox2.Controls.Add(Me.Label46)
        Me.UltraGroupBox2.Controls.Add(Me.txt_RegistrationNum)
        Me.UltraGroupBox2.Controls.Add(Me.Label8)
        Me.UltraGroupBox2.Controls.Add(Me.cmb_AdmissionType)
        Me.UltraGroupBox2.Controls.Add(Me.Label12)
        Me.UltraGroupBox2.Controls.Add(Me.cmb_AdmittedAs)
        Me.UltraGroupBox2.Controls.Add(Me.cmb_ListNumber)
        Me.UltraGroupBox2.Controls.Add(Me.Label14)
        Me.UltraGroupBox2.Controls.Add(Me.Label13)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox2.Location = New System.Drawing.Point(312, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(309, 306)
        Me.UltraGroupBox2.TabIndex = 104
        Me.UltraGroupBox2.Text = "   "
        '
        'cmb_SubjectGroup
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_SubjectGroup.Appearance = Appearance1
        Me.cmb_SubjectGroup.Location = New System.Drawing.Point(107, 133)
        Me.cmb_SubjectGroup.Name = "cmb_SubjectGroup"
        Me.cmb_SubjectGroup.Size = New System.Drawing.Size(175, 22)
        Me.cmb_SubjectGroup.TabIndex = 97
        Me.cmb_SubjectGroup.Text = "UltraCombo5"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(20, 137)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(76, 14)
        Me.Label46.TabIndex = 91
        Me.Label46.Text = "Subject Group"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_RegistrationNum
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.txt_RegistrationNum.Appearance = Appearance2
        Me.txt_RegistrationNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_RegistrationNum.Location = New System.Drawing.Point(107, 18)
        Me.txt_RegistrationNum.Name = "txt_RegistrationNum"
        Me.txt_RegistrationNum.Size = New System.Drawing.Size(175, 17)
        Me.txt_RegistrationNum.TabIndex = 87
        Me.txt_RegistrationNum.Text = "UltraTextEditor2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 14)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Admitted As"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_AdmissionType
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.cmb_AdmissionType.Appearance = Appearance3
        Me.cmb_AdmissionType.Location = New System.Drawing.Point(107, 72)
        Me.cmb_AdmissionType.Name = "cmb_AdmissionType"
        Me.cmb_AdmissionType.Size = New System.Drawing.Size(175, 22)
        Me.cmb_AdmissionType.TabIndex = 90
        Me.cmb_AdmissionType.Text = "UltraCombo5"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 14)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Admission Type"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_AdmittedAs
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.cmb_AdmittedAs.Appearance = Appearance4
        Me.cmb_AdmittedAs.Location = New System.Drawing.Point(107, 42)
        Me.cmb_AdmittedAs.Name = "cmb_AdmittedAs"
        Me.cmb_AdmittedAs.Size = New System.Drawing.Size(175, 22)
        Me.cmb_AdmittedAs.TabIndex = 89
        Me.cmb_AdmittedAs.Text = "UltraCombo5"
        '
        'cmb_ListNumber
        '
        Me.cmb_ListNumber.Location = New System.Drawing.Point(107, 103)
        Me.cmb_ListNumber.Name = "cmb_ListNumber"
        Me.cmb_ListNumber.Size = New System.Drawing.Size(175, 21)
        Me.cmb_ListNumber.TabIndex = 76
        Me.cmb_ListNumber.Text = "UltraComboEditor9"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 14)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Registration No"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 106)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 14)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "List Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txt_SerialNo)
        Me.UltraGroupBox3.Controls.Add(Me.cmb_ClassID)
        Me.UltraGroupBox3.Controls.Add(Me.cmb_PunchEnabled)
        Me.UltraGroupBox3.Controls.Add(Me.Label5)
        Me.UltraGroupBox3.Controls.Add(Me.Label32)
        Me.UltraGroupBox3.Controls.Add(Me.cmb_campusid)
        Me.UltraGroupBox3.Controls.Add(Me.Label4)
        Me.UltraGroupBox3.Controls.Add(Me.Label2)
        Me.UltraGroupBox3.Controls.Add(Me.txt_RollNum)
        Me.UltraGroupBox3.Controls.Add(Me.cmb_shiftid)
        Me.UltraGroupBox3.Controls.Add(Me.Label1)
        Me.UltraGroupBox3.Controls.Add(Me.Label3)
        Me.UltraGroupBox3.Controls.Add(Me.txt_CardNum)
        Me.UltraGroupBox3.Controls.Add(Me.lblDate)
        Me.UltraGroupBox3.Controls.Add(Me.Label10)
        Me.UltraGroupBox3.Controls.Add(Me.dt_AdmissionDate)
        Me.UltraGroupBox3.Controls.Add(Me.Label9)
        Me.UltraGroupBox3.Controls.Add(Me.dt_LeaveDate)
        Me.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(312, 306)
        Me.UltraGroupBox3.TabIndex = 1
        Me.UltraGroupBox3.Text = "    "
        '
        'txt_SerialNo
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.txt_SerialNo.Appearance = Appearance5
        Me.txt_SerialNo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SerialNo.Location = New System.Drawing.Point(107, 18)
        Me.txt_SerialNo.Name = "txt_SerialNo"
        Me.txt_SerialNo.Size = New System.Drawing.Size(183, 17)
        Me.txt_SerialNo.TabIndex = 1
        Me.txt_SerialNo.Text = "UltraTextEditor2"
        '
        'cmb_ClassID
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.cmb_ClassID.Appearance = Appearance6
        Me.cmb_ClassID.Location = New System.Drawing.Point(107, 127)
        Me.cmb_ClassID.Name = "cmb_ClassID"
        Me.cmb_ClassID.Size = New System.Drawing.Size(183, 22)
        Me.cmb_ClassID.TabIndex = 9
        Me.cmb_ClassID.Text = "UltraCombo5"
        '
        'cmb_PunchEnabled
        '
        Me.cmb_PunchEnabled.Location = New System.Drawing.Point(107, 250)
        Me.cmb_PunchEnabled.Name = "cmb_PunchEnabled"
        Me.cmb_PunchEnabled.Size = New System.Drawing.Size(183, 21)
        Me.cmb_PunchEnabled.TabIndex = 39
        Me.cmb_PunchEnabled.Text = "UltraComboEditor9"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Class"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(22, 253)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 14)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "Punch"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_campusid
        '
        Appearance7.FontData.BoldAsString = "False"
        Me.cmb_campusid.Appearance = Appearance7
        Me.cmb_campusid.Location = New System.Drawing.Point(107, 158)
        Me.cmb_campusid.Name = "cmb_campusid"
        Me.cmb_campusid.Size = New System.Drawing.Size(183, 22)
        Me.cmb_campusid.TabIndex = 17
        Me.cmb_campusid.Text = "UltraCombo5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Roll No."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Campus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_RollNum
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.txt_RollNum.Appearance = Appearance8
        Me.txt_RollNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_RollNum.Location = New System.Drawing.Point(107, 45)
        Me.txt_RollNum.Name = "txt_RollNum"
        Me.txt_RollNum.Size = New System.Drawing.Size(183, 17)
        Me.txt_RollNum.TabIndex = 40
        Me.txt_RollNum.Text = "UltraTextEditor2"
        '
        'cmb_shiftid
        '
        Appearance9.FontData.BoldAsString = "False"
        Me.cmb_shiftid.Appearance = Appearance9
        Me.cmb_shiftid.Location = New System.Drawing.Point(107, 189)
        Me.cmb_shiftid.Name = "cmb_shiftid"
        Me.cmb_shiftid.Size = New System.Drawing.Size(183, 22)
        Me.cmb_shiftid.TabIndex = 21
        Me.cmb_shiftid.Text = "UltraCombo5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Card Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Shift *"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CardNum
        '
        Appearance10.FontData.BoldAsString = "False"
        Me.txt_CardNum.Appearance = Appearance10
        Me.txt_CardNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CardNum.Location = New System.Drawing.Point(107, 101)
        Me.txt_CardNum.Name = "txt_CardNum"
        Me.txt_CardNum.Size = New System.Drawing.Size(183, 17)
        Me.txt_CardNum.TabIndex = 15
        Me.txt_CardNum.Text = "UltraTextEditor2"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(22, 75)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(82, 14)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Admission Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Serial No."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_AdmissionDate
        '
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.ItalicAsString = "False"
        Appearance11.FontData.Name = "Arial"
        Appearance11.FontData.SizeInPoints = 8.25!
        Appearance11.FontData.StrikeoutAsString = "False"
        Appearance11.FontData.UnderlineAsString = "False"
        Me.dt_AdmissionDate.Appearance = Appearance11
        Me.dt_AdmissionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_AdmissionDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_AdmissionDate.Location = New System.Drawing.Point(107, 72)
        Me.dt_AdmissionDate.Name = "dt_AdmissionDate"
        Me.dt_AdmissionDate.NullText = "Not Defined"
        Me.dt_AdmissionDate.Size = New System.Drawing.Size(183, 21)
        Me.dt_AdmissionDate.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(22, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 14)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Leave Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_LeaveDate
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.ItalicAsString = "False"
        Appearance12.FontData.Name = "Arial"
        Appearance12.FontData.SizeInPoints = 8.25!
        Appearance12.FontData.StrikeoutAsString = "False"
        Appearance12.FontData.UnderlineAsString = "False"
        Me.dt_LeaveDate.Appearance = Appearance12
        Me.dt_LeaveDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_LeaveDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_LeaveDate.Location = New System.Drawing.Point(107, 220)
        Me.dt_LeaveDate.Name = "dt_LeaveDate"
        Me.dt_LeaveDate.NullText = "Not Defined"
        Me.dt_LeaveDate.ReadOnly = True
        Me.dt_LeaveDate.Size = New System.Drawing.Size(183, 21)
        Me.dt_LeaveDate.TabIndex = 37
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraGroupBox1.Location = New System.Drawing.Point(621, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(274, 306)
        Me.UltraGroupBox1.TabIndex = 103
        Me.UltraGroupBox1.Text = "    "
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGridStuSubject)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraPanel2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(895, 306)
        '
        'UltraGridStuSubject
        '
        Me.UltraGridStuSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridStuSubject.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridStuSubject.Name = "UltraGridStuSubject"
        Me.UltraGridStuSubject.Size = New System.Drawing.Size(895, 274)
        Me.UltraGridStuSubject.TabIndex = 58
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnDelSub)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnAddSub)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 274)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(895, 32)
        Me.UltraPanel2.TabIndex = 57
        '
        'btnDelSub
        '
        Me.btnDelSub.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelSub.Location = New System.Drawing.Point(755, 0)
        Me.btnDelSub.Name = "btnDelSub"
        Me.btnDelSub.Size = New System.Drawing.Size(70, 32)
        Me.btnDelSub.TabIndex = 1
        Me.btnDelSub.Text = "Delete"
        '
        'btnAddSub
        '
        Me.btnAddSub.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddSub.Location = New System.Drawing.Point(825, 0)
        Me.btnAddSub.Name = "btnAddSub"
        Me.btnAddSub.Size = New System.Drawing.Size(70, 32)
        Me.btnAddSub.TabIndex = 0
        Me.btnAddSub.Text = "Add New"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGridStuPaper)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraPanel1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(895, 306)
        '
        'UltraGridStuPaper
        '
        Me.UltraGridStuPaper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridStuPaper.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridStuPaper.Name = "UltraGridStuPaper"
        Me.UltraGridStuPaper.Size = New System.Drawing.Size(895, 274)
        Me.UltraGridStuPaper.TabIndex = 1
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnDel)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnAddNew)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 274)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(895, 32)
        Me.UltraPanel1.TabIndex = 56
        '
        'btnDel
        '
        Me.btnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDel.Location = New System.Drawing.Point(755, 0)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(70, 32)
        Me.btnDel.TabIndex = 1
        Me.btnDel.Text = "Delete"
        '
        'btnAddNew
        '
        Me.btnAddNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddNew.Location = New System.Drawing.Point(825, 0)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(70, 32)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(899, 48)
        Me.Panel1.TabIndex = 4
        '
        'lblName
        '
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(0, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(899, 48)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Mr xxx yyy"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_Person)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 380)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(899, 39)
        Me.Panel4.TabIndex = 5
        '
        'btn_Person
        '
        Appearance13.FontData.BoldAsString = "True"
        Me.btn_Person.Appearance = Appearance13
        Me.btn_Person.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Person.Location = New System.Drawing.Point(0, 0)
        Me.btn_Person.Name = "btn_Person"
        Me.btn_Person.Size = New System.Drawing.Size(160, 39)
        Me.btn_Person.TabIndex = 0
        Me.btn_Person.Text = "Open Personal Details"
        '
        'btnSave
        '
        Appearance14.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance14
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(635, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 39)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance15.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance15
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(723, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 39)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance16.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance16
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(811, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 39)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 48)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Appearance17.FontData.BoldAsString = "True"
        Me.UltraTabControl1.SelectedTabAppearance = Appearance17
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(899, 332)
        Me.UltraTabControl1.TabIndex = 0
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
        UltraTab1.Key = "Detail"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Detail"
        UltraTab2.Key = "Sub"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Subject"
        UltraTab3.Key = "Paper"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Paper"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        Me.UltraTabControl1.TabsPerRow = 5
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(895, 306)
        '
        'frmStudent
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Student Details"
        Me.ClientSize = New System.Drawing.Size(899, 419)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmStudent"
        Me.Text = "Student Details"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cmb_SubjectGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RegistrationNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_AdmissionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_AdmittedAs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ListNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ClassID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_PunchEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RollNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CardNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_AdmissionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_LeaveDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGridStuSubject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.UltraGridStuPaper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_PunchEnabled As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label32 As Windows.Forms.Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_RollNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As Label
    Friend WithEvents cmb_ListNumber As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_RegistrationNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridStuPaper As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddNew As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_AdmissionType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_AdmittedAs As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_SubjectGroup As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label46 As Label
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridStuSubject As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnDelSub As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddSub As Infragistics.Win.Misc.UltraButton

#End Region
End Class

