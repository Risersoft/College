Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCampus
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_TCName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_SelFaxNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_SelFaxArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_SelFaxCountry As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_SelPhNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_SelPhArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_SelPhCOuntry As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_SelPinCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_SelCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_SelAddress As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chk_sameashead As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents btnCopyAdd As Infragistics.Win.Misc.UltraButton
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl17 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_SelCountry = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmb_SelState = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txt_SelAddress = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_SelPinCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chk_sameashead = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_SelFaxArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_SelFaxCountry = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_SelFaxNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnCopyAdd = New Infragistics.Win.Misc.UltraButton()
        Me.txt_SelPhNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_SelPhArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_SelPhCOuntry = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UltraTabPageControl18 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_TinNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cmb_TaxAreaID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txt_FactoryLicenseNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_PanNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_TCName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_SelCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_campuscode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_DispName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_CampusType = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage3 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl17.SuspendLayout()
        CType(Me.cmb_SelCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_SelState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelPinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_sameashead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelFaxArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelFaxCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelFaxNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelPhNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelPhArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelPhCOuntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl18.SuspendLayout()
        CType(Me.txt_TinNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_TaxAreaID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FactoryLicenseNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PanNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txt_TCName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SelCity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_campuscode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_DispName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_CampusType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl17
        '
        Me.UltraTabPageControl17.Controls.Add(Me.Label10)
        Me.UltraTabPageControl17.Controls.Add(Me.cmb_SelCountry)
        Me.UltraTabPageControl17.Controls.Add(Me.Label11)
        Me.UltraTabPageControl17.Controls.Add(Me.cmb_SelState)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelAddress)
        Me.UltraTabPageControl17.Controls.Add(Me.Label2)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelPinCode)
        Me.UltraTabPageControl17.Controls.Add(Me.Label5)
        Me.UltraTabPageControl17.Controls.Add(Me.chk_sameashead)
        Me.UltraTabPageControl17.Controls.Add(Me.Label7)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelFaxArea)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelFaxCountry)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelFaxNum)
        Me.UltraTabPageControl17.Controls.Add(Me.btnCopyAdd)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelPhNum)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelPhArea)
        Me.UltraTabPageControl17.Controls.Add(Me.txt_SelPhCOuntry)
        Me.UltraTabPageControl17.Controls.Add(Me.Label6)
        Me.UltraTabPageControl17.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl17.Name = "UltraTabPageControl17"
        Me.UltraTabPageControl17.Size = New System.Drawing.Size(682, 316)
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(5, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Country"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_SelCountry
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_SelCountry.Appearance = Appearance1
        Me.cmb_SelCountry.Location = New System.Drawing.Point(109, 84)
        Me.cmb_SelCountry.Name = "cmb_SelCountry"
        Me.cmb_SelCountry.Size = New System.Drawing.Size(256, 22)
        Me.cmb_SelCountry.TabIndex = 13
        Me.cmb_SelCountry.Text = "UltraCombo5"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(5, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "State"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_SelState
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.cmb_SelState.Appearance = Appearance2
        Me.cmb_SelState.Location = New System.Drawing.Point(109, 110)
        Me.cmb_SelState.Name = "cmb_SelState"
        Me.cmb_SelState.Size = New System.Drawing.Size(256, 22)
        Me.cmb_SelState.TabIndex = 15
        Me.cmb_SelState.Text = "UltraCombo5"
        '
        'txt_SelAddress
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.txt_SelAddress.Appearance = Appearance3
        Me.txt_SelAddress.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelAddress.Location = New System.Drawing.Point(109, 14)
        Me.txt_SelAddress.Name = "txt_SelAddress"
        Me.txt_SelAddress.Size = New System.Drawing.Size(456, 17)
        Me.txt_SelAddress.TabIndex = 1
        Me.txt_SelAddress.Text = "UltraTextEditor2"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(37, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SelPinCode
        '
        Appearance4.FontData.BoldAsString = "False"
        Me.txt_SelPinCode.Appearance = Appearance4
        Me.txt_SelPinCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelPinCode.Location = New System.Drawing.Point(109, 38)
        Me.txt_SelPinCode.Name = "txt_SelPinCode"
        Me.txt_SelPinCode.Size = New System.Drawing.Size(120, 17)
        Me.txt_SelPinCode.TabIndex = 3
        Me.txt_SelPinCode.Text = "UltraTextEditor5"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(37, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Pincode"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chk_sameashead
        '
        Me.chk_sameashead.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_sameashead.Location = New System.Drawing.Point(397, 108)
        Me.chk_sameashead.Name = "chk_sameashead"
        Me.chk_sameashead.Size = New System.Drawing.Size(207, 24)
        Me.chk_sameashead.TabIndex = 16
        Me.chk_sameashead.Text = "Address is Same as Head Office"
        Me.chk_sameashead.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(386, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Fax No."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SelFaxArea
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.txt_SelFaxArea.Appearance = Appearance5
        Me.txt_SelFaxArea.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelFaxArea.Location = New System.Drawing.Point(482, 61)
        Me.txt_SelFaxArea.Name = "txt_SelFaxArea"
        Me.txt_SelFaxArea.Size = New System.Drawing.Size(32, 17)
        Me.txt_SelFaxArea.TabIndex = 10
        Me.txt_SelFaxArea.Text = "UltraTextEditor10"
        '
        'txt_SelFaxCountry
        '
        Appearance6.FontData.BoldAsString = "False"
        Me.txt_SelFaxCountry.Appearance = Appearance6
        Me.txt_SelFaxCountry.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelFaxCountry.Location = New System.Drawing.Point(442, 61)
        Me.txt_SelFaxCountry.Name = "txt_SelFaxCountry"
        Me.txt_SelFaxCountry.Size = New System.Drawing.Size(32, 17)
        Me.txt_SelFaxCountry.TabIndex = 9
        Me.txt_SelFaxCountry.Text = "UltraTextEditor11"
        '
        'txt_SelFaxNum
        '
        Appearance7.FontData.BoldAsString = "False"
        Me.txt_SelFaxNum.Appearance = Appearance7
        Me.txt_SelFaxNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelFaxNum.Location = New System.Drawing.Point(522, 61)
        Me.txt_SelFaxNum.Name = "txt_SelFaxNum"
        Me.txt_SelFaxNum.Size = New System.Drawing.Size(144, 17)
        Me.txt_SelFaxNum.TabIndex = 11
        Me.txt_SelFaxNum.Text = "UltraTextEditor9"
        '
        'btnCopyAdd
        '
        Me.btnCopyAdd.Location = New System.Drawing.Point(109, 138)
        Me.btnCopyAdd.Name = "btnCopyAdd"
        Me.btnCopyAdd.Size = New System.Drawing.Size(124, 39)
        Me.btnCopyAdd.TabIndex = 8
        Me.btnCopyAdd.Text = "Copy Address from Main Party"
        '
        'txt_SelPhNum
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.txt_SelPhNum.Appearance = Appearance8
        Me.txt_SelPhNum.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelPhNum.Location = New System.Drawing.Point(189, 61)
        Me.txt_SelPhNum.Name = "txt_SelPhNum"
        Me.txt_SelPhNum.Size = New System.Drawing.Size(176, 17)
        Me.txt_SelPhNum.TabIndex = 7
        Me.txt_SelPhNum.Text = "UltraTextEditor8"
        '
        'txt_SelPhArea
        '
        Appearance9.FontData.BoldAsString = "False"
        Me.txt_SelPhArea.Appearance = Appearance9
        Me.txt_SelPhArea.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelPhArea.Location = New System.Drawing.Point(149, 61)
        Me.txt_SelPhArea.Name = "txt_SelPhArea"
        Me.txt_SelPhArea.Size = New System.Drawing.Size(32, 17)
        Me.txt_SelPhArea.TabIndex = 6
        Me.txt_SelPhArea.Text = "UltraTextEditor7"
        '
        'txt_SelPhCOuntry
        '
        Appearance10.FontData.BoldAsString = "False"
        Me.txt_SelPhCOuntry.Appearance = Appearance10
        Me.txt_SelPhCOuntry.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelPhCOuntry.Location = New System.Drawing.Point(109, 61)
        Me.txt_SelPhCOuntry.Name = "txt_SelPhCOuntry"
        Me.txt_SelPhCOuntry.Size = New System.Drawing.Size(32, 17)
        Me.txt_SelPhCOuntry.TabIndex = 5
        Me.txt_SelPhCOuntry.Text = "UltraTextEditor6"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(37, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ph. No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTabPageControl18
        '
        Me.UltraTabPageControl18.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl18.Controls.Add(Me.UltraLabel20)
        Me.UltraTabPageControl18.Controls.Add(Me.txt_TinNum)
        Me.UltraTabPageControl18.Controls.Add(Me.cmb_TaxAreaID)
        Me.UltraTabPageControl18.Controls.Add(Me.txt_FactoryLicenseNumber)
        Me.UltraTabPageControl18.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl18.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl18.Controls.Add(Me.txt_PanNum)
        Me.UltraTabPageControl18.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl18.Name = "UltraTabPageControl18"
        Me.UltraTabPageControl18.Size = New System.Drawing.Size(682, 316)
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance11
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(42, 83)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(80, 14)
        Me.UltraLabel5.TabIndex = 21
        Me.UltraLabel5.Text = "Tax Area Code"
        '
        'UltraLabel20
        '
        Me.UltraLabel20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.TextHAlignAsString = "Right"
        Me.UltraLabel20.Appearance = Appearance12
        Me.UltraLabel20.AutoSize = True
        Me.UltraLabel20.Location = New System.Drawing.Point(79, 54)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.Size = New System.Drawing.Size(43, 14)
        Me.UltraLabel20.TabIndex = 16
        Me.UltraLabel20.Text = "TIN No."
        '
        'txt_TinNum
        '
        Me.txt_TinNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.TextHAlignAsString = "Right"
        Me.txt_TinNum.Appearance = Appearance13
        Me.txt_TinNum.Location = New System.Drawing.Point(125, 51)
        Me.txt_TinNum.Name = "txt_TinNum"
        Me.txt_TinNum.Size = New System.Drawing.Size(208, 21)
        Me.txt_TinNum.TabIndex = 17
        '
        'cmb_TaxAreaID
        '
        Appearance14.FontData.BoldAsString = "False"
        Me.cmb_TaxAreaID.Appearance = Appearance14
        Me.cmb_TaxAreaID.Location = New System.Drawing.Point(125, 79)
        Me.cmb_TaxAreaID.Name = "cmb_TaxAreaID"
        Me.cmb_TaxAreaID.Size = New System.Drawing.Size(208, 22)
        Me.cmb_TaxAreaID.TabIndex = 5
        Me.cmb_TaxAreaID.Text = "UltraCombo5"
        '
        'txt_FactoryLicenseNumber
        '
        Me.txt_FactoryLicenseNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.TextHAlignAsString = "Right"
        Me.txt_FactoryLicenseNumber.Appearance = Appearance15
        Me.txt_FactoryLicenseNumber.Location = New System.Drawing.Point(125, 110)
        Me.txt_FactoryLicenseNumber.Name = "txt_FactoryLicenseNumber"
        Me.txt_FactoryLicenseNumber.Size = New System.Drawing.Size(208, 21)
        Me.txt_FactoryLicenseNumber.TabIndex = 15
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance16.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance16
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(16, 113)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(106, 14)
        Me.UltraLabel1.TabIndex = 14
        Me.UltraLabel1.Text = "College License No."
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance17
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(74, 27)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(48, 14)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "PAN No."
        '
        'txt_PanNum
        '
        Me.txt_PanNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.TextHAlignAsString = "Right"
        Me.txt_PanNum.Appearance = Appearance18
        Me.txt_PanNum.Location = New System.Drawing.Point(125, 24)
        Me.txt_PanNum.Name = "txt_PanNum"
        Me.txt_PanNum.Size = New System.Drawing.Size(208, 21)
        Me.txt_PanNum.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 463)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(686, 39)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Appearance19.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance19
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(422, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 39)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance20.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance20
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(510, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 39)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance21.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance21
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(598, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 39)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(44, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Print Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_TCName
        '
        Appearance22.FontData.BoldAsString = "False"
        Me.txt_TCName.Appearance = Appearance22
        Me.txt_TCName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_TCName.Location = New System.Drawing.Point(110, 50)
        Me.txt_TCName.Name = "txt_TCName"
        Me.txt_TCName.Size = New System.Drawing.Size(192, 17)
        Me.txt_TCName.TabIndex = 5
        Me.txt_TCName.Text = "UltraTextEditor1"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(44, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "City"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SelCity
        '
        Appearance23.FontData.BoldAsString = "False"
        Me.txt_SelCity.Appearance = Appearance23
        Me.txt_SelCity.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SelCity.Location = New System.Drawing.Point(110, 78)
        Me.txt_SelCity.Name = "txt_SelCity"
        Me.txt_SelCity.Size = New System.Drawing.Size(192, 17)
        Me.txt_SelCity.TabIndex = 7
        Me.txt_SelCity.Text = "UltraTextEditor3"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraLabel4)
        Me.Panel1.Controls.Add(Me.UltraLabel2)
        Me.Panel1.Controls.Add(Me.txt_campuscode)
        Me.Panel1.Controls.Add(Me.txt_DispName)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cmb_CampusType)
        Me.Panel1.Controls.Add(Me.txt_TCName)
        Me.Panel1.Controls.Add(Me.txt_SelCity)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(686, 121)
        Me.Panel1.TabIndex = 0
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance24.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance24
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(328, 24)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(75, 14)
        Me.UltraLabel4.TabIndex = 21
        Me.UltraLabel4.Text = "Campus Type"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance25
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(326, 50)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(77, 14)
        Me.UltraLabel2.TabIndex = 20
        Me.UltraLabel2.Text = "Campus Code"
        '
        'txt_campuscode
        '
        Appearance26.FontData.BoldAsString = "False"
        Me.txt_campuscode.Appearance = Appearance26
        Me.txt_campuscode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_campuscode.Location = New System.Drawing.Point(406, 49)
        Me.txt_campuscode.Name = "txt_campuscode"
        Me.txt_campuscode.ReadOnly = True
        Me.txt_campuscode.Size = New System.Drawing.Size(192, 17)
        Me.txt_campuscode.TabIndex = 10
        Me.txt_campuscode.Text = "UltraTextEditor1"
        '
        'txt_DispName
        '
        Appearance27.FontData.BoldAsString = "False"
        Me.txt_DispName.Appearance = Appearance27
        Me.txt_DispName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_DispName.Location = New System.Drawing.Point(110, 23)
        Me.txt_DispName.Name = "txt_DispName"
        Me.txt_DispName.Size = New System.Drawing.Size(192, 17)
        Me.txt_DispName.TabIndex = 3
        Me.txt_DispName.Text = "UltraTextEditor1"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Display Name"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_CampusType
        '
        Appearance28.FontData.BoldAsString = "False"
        Me.cmb_CampusType.Appearance = Appearance28
        Me.cmb_CampusType.Location = New System.Drawing.Point(406, 21)
        Me.cmb_CampusType.Name = "cmb_CampusType"
        Me.cmb_CampusType.Size = New System.Drawing.Size(192, 22)
        Me.cmb_CampusType.TabIndex = 1
        Me.cmb_CampusType.Text = "UltraCombo5"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl17)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl18)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 121)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage3
        Me.UltraTabControl1.Size = New System.Drawing.Size(686, 342)
        Me.UltraTabControl1.TabIndex = 1
        UltraTab7.TabPage = Me.UltraTabPageControl17
        UltraTab7.Text = "Address"
        UltraTab2.TabPage = Me.UltraTabPageControl18
        UltraTab2.Text = "Statutory"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab7, UltraTab2})
        '
        'UltraTabSharedControlsPage3
        '
        Me.UltraTabSharedControlsPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage3.Name = "UltraTabSharedControlsPage3"
        Me.UltraTabSharedControlsPage3.Size = New System.Drawing.Size(682, 316)
        '
        'frmCampus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.Caption = "Campus"
        Me.ClientSize = New System.Drawing.Size(686, 502)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCampus"
        Me.Text = "Campus"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl17.ResumeLayout(False)
        Me.UltraTabPageControl17.PerformLayout()
        CType(Me.cmb_SelCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_SelState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelPinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_sameashead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelFaxArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelFaxCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelFaxNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelPhNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelPhArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelPhCOuntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl18.ResumeLayout(False)
        Me.UltraTabPageControl18.PerformLayout()
        CType(Me.txt_TinNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_TaxAreaID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FactoryLicenseNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PanNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.txt_TCName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SelCity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_campuscode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_DispName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_CampusType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage3 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl17 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl18 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_PanNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_DispName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_CampusType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txt_FactoryLicenseNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_SelCountry As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmb_SelState As Infragistics.Win.UltraWinGrid.UltraCombo
    'Friend WithEvents Label25 As Label
    Friend WithEvents cmb_TaxAreaID As UltraCombo
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_TinNum As UltraTextEditor
    Friend WithEvents txt_campuscode As UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel

#End Region
End Class

