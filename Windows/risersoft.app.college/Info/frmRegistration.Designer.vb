<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistration
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        Me.InitForm()
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_EventName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_SubjectGroup = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Course = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FatherName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dt_Dated = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FullName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.txt_Name = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txt_EventName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SubjectGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Course, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FatherName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txt_Name, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraLabel6)
        Me.Panel2.Controls.Add(Me.UltraLabel5)
        Me.Panel2.Controls.Add(Me.txt_SubjectGroup)
        Me.Panel2.Controls.Add(Me.UltraLabel4)
        Me.Panel2.Controls.Add(Me.txt_Course)
        Me.Panel2.Controls.Add(Me.UltraLabel1)
        Me.Panel2.Controls.Add(Me.txt_FatherName)
        Me.Panel2.Controls.Add(Me.dt_Dated)
        Me.Panel2.Controls.Add(Me.UltraLabel2)
        Me.Panel2.Controls.Add(Me.txt_FullName)
        Me.Panel2.Controls.Add(Me.UltraLabel11)
        Me.Panel2.Controls.Add(Me.txt_EventName)
        Me.Panel2.Controls.Add(Me.txt_Name)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(540, 242)
        Me.Panel2.TabIndex = 13
        '
        'UltraLabel6
        '
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(8, 190)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(106, 14)
        Me.UltraLabel6.TabIndex = 82
        Me.UltraLabel6.Text = "Event/Activity Name"
        '
        'txt_EventName
        '
        Appearance6.TextHAlignAsString = "Left"
        Me.txt_EventName.Appearance = Appearance6
        Me.txt_EventName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EventName.Location = New System.Drawing.Point(121, 189)
        Me.txt_EventName.Name = "txt_EventName"
        Me.txt_EventName.ReadOnly = True
        Me.txt_EventName.Size = New System.Drawing.Size(387, 21)
        Me.txt_EventName.TabIndex = 83
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(72, 156)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(42, 14)
        Me.UltraLabel5.TabIndex = 80
        Me.UltraLabel5.Text = "Subject"
        '
        'txt_SubjectGroup
        '
        Appearance1.TextHAlignAsString = "Left"
        Me.txt_SubjectGroup.Appearance = Appearance1
        Me.txt_SubjectGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubjectGroup.Location = New System.Drawing.Point(121, 155)
        Me.txt_SubjectGroup.Name = "txt_SubjectGroup"
        Me.txt_SubjectGroup.ReadOnly = True
        Me.txt_SubjectGroup.Size = New System.Drawing.Size(186, 21)
        Me.txt_SubjectGroup.TabIndex = 81
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(73, 122)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(41, 14)
        Me.UltraLabel4.TabIndex = 78
        Me.UltraLabel4.Text = "Course"
        '
        'txt_Course
        '
        Appearance2.TextHAlignAsString = "Left"
        Me.txt_Course.Appearance = Appearance2
        Me.txt_Course.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Course.Location = New System.Drawing.Point(121, 122)
        Me.txt_Course.Name = "txt_Course"
        Me.txt_Course.ReadOnly = True
        Me.txt_Course.Size = New System.Drawing.Size(186, 21)
        Me.txt_Course.TabIndex = 79
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(36, 88)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel1.TabIndex = 74
        Me.UltraLabel1.Text = "Father's Name"
        '
        'txt_FatherName
        '
        Appearance3.TextHAlignAsString = "Left"
        Me.txt_FatherName.Appearance = Appearance3
        Me.txt_FatherName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FatherName.Location = New System.Drawing.Point(121, 88)
        Me.txt_FatherName.Name = "txt_FatherName"
        Me.txt_FatherName.ReadOnly = True
        Me.txt_FatherName.Size = New System.Drawing.Size(257, 21)
        Me.txt_FatherName.TabIndex = 75
        '
        'dt_Dated
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.FontData.ItalicAsString = "False"
        Appearance4.FontData.Name = "Arial"
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.FontData.StrikeoutAsString = "False"
        Appearance4.FontData.UnderlineAsString = "False"
        Me.dt_Dated.Appearance = Appearance4
        Me.dt_Dated.DateTime = New Date(2020, 5, 8, 0, 0, 0, 0)
        Me.dt_Dated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Dated.FormatString = "dddd dd MMM yyyy"
        Me.dt_Dated.Location = New System.Drawing.Point(121, 17)
        Me.dt_Dated.Name = "dt_Dated"
        Me.dt_Dated.NullText = "Not Defined"
        Me.dt_Dated.ReadOnly = True
        Me.dt_Dated.Size = New System.Drawing.Size(186, 21)
        Me.dt_Dated.TabIndex = 73
        Me.dt_Dated.Value = New Date(2020, 5, 8, 0, 0, 0, 0)
        '
        'UltraLabel2
        '
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(25, 54)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(89, 14)
        Me.UltraLabel2.TabIndex = 63
        Me.UltraLabel2.Text = "Name of Student"
        '
        'txt_FullName
        '
        Appearance5.TextHAlignAsString = "Left"
        Me.txt_FullName.Appearance = Appearance5
        Me.txt_FullName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FullName.Location = New System.Drawing.Point(121, 55)
        Me.txt_FullName.Name = "txt_FullName"
        Me.txt_FullName.ReadOnly = True
        Me.txt_FullName.Size = New System.Drawing.Size(257, 21)
        Me.txt_FullName.TabIndex = 64
        '
        'UltraLabel11
        '
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel11.Location = New System.Drawing.Point(81, 17)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel11.TabIndex = 4
        Me.UltraLabel11.Text = "Dated"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 242)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(540, 52)
        Me.Panel4.TabIndex = 14
        '
        'btnSave
        '
        Appearance8.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance8
        Me.btnSave.Location = New System.Drawing.Point(185, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 52)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Register"
        '
        'txt_Name
        '
        Appearance7.TextHAlignAsString = "Left"
        Me.txt_Name.Appearance = Appearance7
        Me.txt_Name.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Name.Location = New System.Drawing.Point(121, 189)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.ReadOnly = True
        Me.txt_Name.Size = New System.Drawing.Size(387, 21)
        Me.txt_Name.TabIndex = 84
        '
        'frmRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Registration"
        Me.ClientSize = New System.Drawing.Size(540, 294)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmRegistration"
        Me.Text = "Registration"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txt_EventName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SubjectGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Course, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FatherName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Dated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.txt_Name, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FullName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dt_Dated As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Course As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FatherName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_SubjectGroup As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_EventName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_Name As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
