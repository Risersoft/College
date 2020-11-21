Imports risersoft.app.shared
Imports risersoft.app.mxent
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Partial Class frmAttendStu
	Inherits frmMax

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnProcess = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.UltraGridAttend = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.txt_SerialNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_ClassName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_FullName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.UltraGridAttend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ClassName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnProcess)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 407)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(794, 41)
        Me.Panel4.TabIndex = 2
        '
        'btnProcess
        '
        Appearance1.FontData.BoldAsString = "True"
        Me.btnProcess.Appearance = Appearance1
        Me.btnProcess.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcess.Location = New System.Drawing.Point(0, 0)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(88, 41)
        Me.btnProcess.TabIndex = 4
        Me.btnProcess.Text = "Process Punch"
        '
        'btnSave
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance2
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(530, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 41)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance3.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance3
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(618, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 41)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance4.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance4
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(706, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 41)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_FullName)
        Me.Panel1.Controls.Add(Me.txt_ClassName)
        Me.Panel1.Controls.Add(Me.txt_SerialNo)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.UltraLabel4)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 86)
        Me.Panel1.TabIndex = 0
        '
        'UltraLabel6
        '
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(51, 34)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel6.TabIndex = 2
        Me.UltraLabel6.Text = "Serial No."
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(39, 58)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(66, 14)
        Me.UltraLabel4.TabIndex = 4
        Me.UltraLabel4.Text = "Class Name"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(71, 10)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Name"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.UltraGridAttend)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 86)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(794, 321)
        Me.Panel3.TabIndex = 88
        '
        'UltraGridAttend
        '
        Me.UltraGridAttend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridAttend.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridAttend.Name = "UltraGridAttend"
        Me.UltraGridAttend.Size = New System.Drawing.Size(794, 321)
        Me.UltraGridAttend.TabIndex = 2
        Me.UltraGridAttend.Text = "Attendance"
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(260, 295)
        '
        'txt_SerialNo
        '
        Appearance7.FontData.BoldAsString = "False"
        Me.txt_SerialNo.Appearance = Appearance7
        Me.txt_SerialNo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SerialNo.Location = New System.Drawing.Point(108, 33)
        Me.txt_SerialNo.Name = "txt_SerialNo"
        Me.txt_SerialNo.ReadOnly = True
        Me.txt_SerialNo.Size = New System.Drawing.Size(104, 17)
        Me.txt_SerialNo.TabIndex = 5
        Me.txt_SerialNo.Text = "UltraTextEditor2"
        '
        'txt_ClassName
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.txt_ClassName.Appearance = Appearance6
        Me.txt_ClassName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_ClassName.Location = New System.Drawing.Point(108, 57)
        Me.txt_ClassName.Name = "txt_ClassName"
        Me.txt_ClassName.ReadOnly = True
        Me.txt_ClassName.Size = New System.Drawing.Size(104, 17)
        Me.txt_ClassName.TabIndex = 6
        Me.txt_ClassName.Text = "UltraTextEditor2"
        '
        'txt_FullName
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.txt_FullName.Appearance = Appearance5
        Me.txt_FullName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_FullName.Location = New System.Drawing.Point(108, 9)
        Me.txt_FullName.Name = "txt_FullName"
        Me.txt_FullName.ReadOnly = True
        Me.txt_FullName.Size = New System.Drawing.Size(302, 17)
        Me.txt_FullName.TabIndex = 7
        Me.txt_FullName.Text = "UltraTextEditor2"
        '
        'frmAttendStu
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.Caption = "Attendance (Student Wise)"
        Me.ClientSize = New System.Drawing.Size(794, 448)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAttendStu"
        Me.Text = "Attendance (Student Wise)"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.UltraGridAttend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ClassName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnProcess As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents UltraGridAttend As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents txt_FullName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_ClassName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_SerialNo As Infragistics.Win.UltraWinEditors.UltraTextEditor

#End Region
End Class

