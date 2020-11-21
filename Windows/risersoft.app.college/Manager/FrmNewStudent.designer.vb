<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNewStudent


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_SerialNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_shiftid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_campusid = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_ClassID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dt_AdmissionDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_RollNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
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
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ClassID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_AdmissionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RollNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cmb_SubjectGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RegistrationNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_AdmissionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_AdmittedAs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_ListNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Serial No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SerialNo
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.txt_SerialNo.Appearance = Appearance1
        Me.txt_SerialNo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SerialNo.Location = New System.Drawing.Point(97, 34)
        Me.txt_SerialNo.Name = "txt_SerialNo"
        Me.txt_SerialNo.Size = New System.Drawing.Size(183, 17)
        Me.txt_SerialNo.TabIndex = 1
        Me.txt_SerialNo.Text = "UltraTextEditor2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Shift"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_shiftid
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.cmb_shiftid.Appearance = Appearance2
        Me.cmb_shiftid.Location = New System.Drawing.Point(97, 208)
        Me.cmb_shiftid.Name = "cmb_shiftid"
        Me.cmb_shiftid.Size = New System.Drawing.Size(183, 22)
        Me.cmb_shiftid.TabIndex = 7
        Me.cmb_shiftid.Text = "UltraCombo5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Campus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_campusid
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.cmb_campusid.Appearance = Appearance3
        Me.cmb_campusid.Location = New System.Drawing.Point(97, 171)
        Me.cmb_campusid.Name = "cmb_campusid"
        Me.cmb_campusid.Size = New System.Drawing.Size(183, 22)
        Me.cmb_campusid.TabIndex = 5
        Me.cmb_campusid.Text = "UltraCombo5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Class"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_ClassID
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.cmb_ClassID.Appearance = Appearance4
        Me.cmb_ClassID.Location = New System.Drawing.Point(97, 134)
        Me.cmb_ClassID.Name = "cmb_ClassID"
        Me.cmb_ClassID.Size = New System.Drawing.Size(183, 22)
        Me.cmb_ClassID.TabIndex = 3
        Me.cmb_ClassID.Text = "UltraCombo5"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblDate.Location = New System.Drawing.Point(12, 101)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(82, 14)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "Admission Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dt_AdmissionDate
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.ItalicAsString = "False"
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.FontData.StrikeoutAsString = "False"
        Appearance7.FontData.UnderlineAsString = "False"
        Me.dt_AdmissionDate.Appearance = Appearance7
        Me.dt_AdmissionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_AdmissionDate.FormatString = "dddd dd MMM yyyy"
        Me.dt_AdmissionDate.Location = New System.Drawing.Point(97, 98)
        Me.dt_AdmissionDate.Name = "dt_AdmissionDate"
        Me.dt_AdmissionDate.NullText = "Not Defined"
        Me.dt_AdmissionDate.Size = New System.Drawing.Size(183, 21)
        Me.dt_AdmissionDate.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Roll No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_RollNum
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.txt_RollNum.Appearance = Appearance6
        Me.txt_RollNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_RollNum.Location = New System.Drawing.Point(97, 66)
        Me.txt_RollNum.Name = "txt_RollNum"
        Me.txt_RollNum.Size = New System.Drawing.Size(183, 17)
        Me.txt_RollNum.TabIndex = 11
        Me.txt_RollNum.Text = "UltraTextEditor2"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txt_SerialNo)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.cmb_ClassID)
        Me.UltraGroupBox1.Controls.Add(Me.txt_RollNum)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.Label10)
        Me.UltraGroupBox1.Controls.Add(Me.cmb_campusid)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.dt_AdmissionDate)
        Me.UltraGroupBox1.Controls.Add(Me.cmb_shiftid)
        Me.UltraGroupBox1.Controls.Add(Me.lblDate)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(292, 252)
        Me.UltraGroupBox1.TabIndex = 104
        Me.UltraGroupBox1.Text = "    "
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
        Me.UltraGroupBox2.Location = New System.Drawing.Point(292, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(291, 252)
        Me.UltraGroupBox2.TabIndex = 105
        Me.UltraGroupBox2.Text = "   "
        '
        'cmb_SubjectGroup
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.cmb_SubjectGroup.Appearance = Appearance8
        Me.cmb_SubjectGroup.Location = New System.Drawing.Point(104, 171)
        Me.cmb_SubjectGroup.Name = "cmb_SubjectGroup"
        Me.cmb_SubjectGroup.Size = New System.Drawing.Size(175, 22)
        Me.cmb_SubjectGroup.TabIndex = 97
        Me.cmb_SubjectGroup.Text = "UltraCombo5"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(17, 175)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(76, 14)
        Me.Label46.TabIndex = 91
        Me.Label46.Text = "Subject Group"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_RegistrationNum
        '
        Appearance9.FontData.BoldAsString = "False"
        Me.txt_RegistrationNum.Appearance = Appearance9
        Me.txt_RegistrationNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_RegistrationNum.Location = New System.Drawing.Point(104, 34)
        Me.txt_RegistrationNum.Name = "txt_RegistrationNum"
        Me.txt_RegistrationNum.Size = New System.Drawing.Size(175, 17)
        Me.txt_RegistrationNum.TabIndex = 87
        Me.txt_RegistrationNum.Text = "UltraTextEditor2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 14)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Admitted As"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_AdmissionType
        '
        Appearance10.FontData.BoldAsString = "False"
        Me.cmb_AdmissionType.Appearance = Appearance10
        Me.cmb_AdmissionType.Location = New System.Drawing.Point(104, 98)
        Me.cmb_AdmissionType.Name = "cmb_AdmissionType"
        Me.cmb_AdmissionType.Size = New System.Drawing.Size(175, 22)
        Me.cmb_AdmissionType.TabIndex = 90
        Me.cmb_AdmissionType.Text = "UltraCombo5"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 14)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Admission Type"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_AdmittedAs
        '
        Appearance11.FontData.BoldAsString = "False"
        Me.cmb_AdmittedAs.Appearance = Appearance11
        Me.cmb_AdmittedAs.Location = New System.Drawing.Point(104, 66)
        Me.cmb_AdmittedAs.Name = "cmb_AdmittedAs"
        Me.cmb_AdmittedAs.Size = New System.Drawing.Size(175, 22)
        Me.cmb_AdmittedAs.TabIndex = 89
        Me.cmb_AdmittedAs.Text = "UltraCombo5"
        '
        'cmb_ListNumber
        '
        Me.cmb_ListNumber.Location = New System.Drawing.Point(104, 134)
        Me.cmb_ListNumber.Name = "cmb_ListNumber"
        Me.cmb_ListNumber.Size = New System.Drawing.Size(175, 21)
        Me.cmb_ListNumber.TabIndex = 76
        Me.cmb_ListNumber.Text = "UltraComboEditor9"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 14)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Registration No"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 14)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "List Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmNewStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "New Student"
        Me.ClientSize = New System.Drawing.Size(583, 252)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmNewStudent"
        Me.Text = "New Student"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SerialNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_shiftid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_campusid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ClassID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_AdmissionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RollNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cmb_SubjectGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RegistrationNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_AdmissionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_AdmittedAs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_ListNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txt_SerialNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cmb_shiftid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cmb_campusid As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cmb_ClassID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents dt_AdmissionDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_RollNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmb_SubjectGroup As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label46 As Label
    Friend WithEvents txt_RegistrationNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label8 As Label
    Friend WithEvents cmb_AdmissionType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label12 As Label
    Friend WithEvents cmb_AdmittedAs As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmb_ListNumber As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
End Class
