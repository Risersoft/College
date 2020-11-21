<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsset
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.dt_SinceWhen = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Quantity = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmb_DeptID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmb_Status = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Item = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.cmb_Type = New Infragistics.Win.UltraWinGrid.UltraCombo()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        CType(Me.dt_SinceWhen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_DeptID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.cmb_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.cmb_Type)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.dt_SinceWhen)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.txt_Quantity)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.cmb_DeptID)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.cmb_Status)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel11)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.txt_Item)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel4)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(372, 214)
        Me.UltraPanel2.TabIndex = 9
        '
        'dt_SinceWhen
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.ItalicAsString = "False"
        Appearance2.FontData.Name = "Arial"
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.FontData.StrikeoutAsString = "False"
        Appearance2.FontData.UnderlineAsString = "False"
        Me.dt_SinceWhen.Appearance = Appearance2
        Me.dt_SinceWhen.DateTime = New Date(2020, 5, 8, 0, 0, 0, 0)
        Me.dt_SinceWhen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_SinceWhen.FormatString = "dddd dd MMM yyyy"
        Me.dt_SinceWhen.Location = New System.Drawing.Point(88, 106)
        Me.dt_SinceWhen.Name = "dt_SinceWhen"
        Me.dt_SinceWhen.NullText = "Not Defined"
        Me.dt_SinceWhen.Size = New System.Drawing.Size(120, 21)
        Me.dt_SinceWhen.TabIndex = 73
        Me.dt_SinceWhen.Value = New Date(2020, 5, 8, 0, 0, 0, 0)
        '
        'UltraLabel3
        '
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UltraLabel3.Location = New System.Drawing.Point(16, 107)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(65, 14)
        Me.UltraLabel3.TabIndex = 62
        Me.UltraLabel3.Text = "Since When"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(35, 137)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(46, 14)
        Me.UltraLabel2.TabIndex = 60
        Me.UltraLabel2.Text = "Quantity"
        '
        'txt_Quantity
        '
        Appearance3.TextHAlignAsString = "Left"
        Me.txt_Quantity.Appearance = Appearance3
        Me.txt_Quantity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Quantity.Location = New System.Drawing.Point(88, 138)
        Me.txt_Quantity.Name = "txt_Quantity"
        Me.txt_Quantity.Size = New System.Drawing.Size(221, 21)
        Me.txt_Quantity.TabIndex = 61
        '
        'cmb_DeptID
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.cmb_DeptID.Appearance = Appearance4
        Me.cmb_DeptID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_DeptID.Location = New System.Drawing.Point(88, 46)
        Me.cmb_DeptID.Name = "cmb_DeptID"
        Me.cmb_DeptID.Size = New System.Drawing.Size(221, 22)
        Me.cmb_DeptID.TabIndex = 59
        Me.cmb_DeptID.Text = "UltraCombo5"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UltraLabel5.Location = New System.Drawing.Point(18, 47)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(63, 14)
        Me.UltraLabel5.TabIndex = 58
        Me.UltraLabel5.Text = "Department"
        '
        'cmb_Status
        '
        Me.cmb_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem1.DataValue = False
        ValueListItem1.DisplayText = "Normal"
        ValueListItem2.DataValue = True
        ValueListItem2.DisplayText = "Casual"
        Me.cmb_Status.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.cmb_Status.Location = New System.Drawing.Point(89, 165)
        Me.cmb_Status.Name = "cmb_Status"
        Me.cmb_Status.Size = New System.Drawing.Size(142, 21)
        Me.cmb_Status.TabIndex = 53
        Me.cmb_Status.Text = "UltraComboEditor9"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UltraLabel1.Location = New System.Drawing.Point(46, 167)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel1.TabIndex = 14
        Me.UltraLabel1.Text = "Status"
        '
        'UltraLabel11
        '
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UltraLabel11.Location = New System.Drawing.Point(55, 18)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(26, 14)
        Me.UltraLabel11.TabIndex = 2
        Me.UltraLabel11.Text = "Item"
        '
        'txt_Item
        '
        Appearance5.TextHAlignAsString = "Left"
        Me.txt_Item.Appearance = Appearance5
        Me.txt_Item.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Item.Location = New System.Drawing.Point(88, 16)
        Me.txt_Item.Name = "txt_Item"
        Me.txt_Item.Size = New System.Drawing.Size(221, 21)
        Me.txt_Item.TabIndex = 3
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UltraLabel4.Location = New System.Drawing.Point(51, 77)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(29, 14)
        Me.UltraLabel4.TabIndex = 10
        Me.UltraLabel4.Text = "Type"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 214)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(372, 42)
        Me.Panel4.TabIndex = 10
        '
        'btnSave
        '
        Appearance6.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance6
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(108, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 42)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance7.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance7
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(196, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 42)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance8.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance8
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(284, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 42)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'cmb_Type
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_Type.Appearance = Appearance1
        Me.cmb_Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Type.Location = New System.Drawing.Point(89, 77)
        Me.cmb_Type.Name = "cmb_Type"
        Me.cmb_Type.Size = New System.Drawing.Size(221, 22)
        Me.cmb_Type.TabIndex = 74
        Me.cmb_Type.Text = "UltraCombo5"
        '
        'frmAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Asset"
        Me.ClientSize = New System.Drawing.Size(372, 256)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmAsset"
        Me.Text = "Asset"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ClientArea.PerformLayout()
        Me.UltraPanel2.ResumeLayout(False)
        CType(Me.dt_SinceWhen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Quantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_DeptID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.cmb_Type, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents cmb_Status As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Item As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_DeptID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Quantity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dt_SinceWhen As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmb_Type As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
