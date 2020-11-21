<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGridUserAccount = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAddAcc = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelAcc = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAddGroup = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelGroup = New Infragistics.Win.Misc.UltraButton()
        Me.Panel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.txt_CountryCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_CompanyName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.chk_IsAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txt_ProviderKey = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.chk_IsTwoFactorAuthentication = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cmb_AuthenticationProviderId = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.chk_PhoneNumberConfirmed = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chk_EmailConfirmed = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txt_PhoneNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_PasswordHash = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Email = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_SecurityStamp = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FullName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGridUserAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.ClientArea.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txt_CountryCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_IsAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ProviderKey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_IsTwoFactorAuthentication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_AuthenticationProviderId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_PhoneNumberConfirmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_EmailConfirmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PhoneNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PasswordHash, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Email, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SecurityStamp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(697, 247)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGridUserAccount)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 247)
        Me.Panel1.TabIndex = 8
        '
        'UltraGridUserAccount
        '
        Me.UltraGridUserAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridUserAccount.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridUserAccount.Name = "UltraGridUserAccount"
        Me.UltraGridUserAccount.Size = New System.Drawing.Size(697, 215)
        Me.UltraGridUserAccount.TabIndex = 0
        Me.UltraGridUserAccount.Text = "Delivery Schedule"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAddAcc)
        Me.Panel3.Controls.Add(Me.btnDelAcc)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 215)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 32)
        Me.Panel3.TabIndex = 1
        '
        'btnAddAcc
        '
        Me.btnAddAcc.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddAcc.Location = New System.Drawing.Point(554, 0)
        Me.btnAddAcc.Name = "btnAddAcc"
        Me.btnAddAcc.Size = New System.Drawing.Size(70, 32)
        Me.btnAddAcc.TabIndex = 2
        Me.btnAddAcc.Text = "Add New"
        '
        'btnDelAcc
        '
        Me.btnDelAcc.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelAcc.Location = New System.Drawing.Point(624, 0)
        Me.btnDelAcc.Name = "btnDelAcc"
        Me.btnDelAcc.Size = New System.Drawing.Size(73, 32)
        Me.btnDelAcc.TabIndex = 3
        Me.btnDelAcc.Text = "Delete"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridGroup)
        Me.UltraTabPageControl1.Controls.Add(Me.Panel5)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(697, 247)
        '
        'UltraGridGroup
        '
        Me.UltraGridGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridGroup.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridGroup.Name = "UltraGridGroup"
        Me.UltraGridGroup.Size = New System.Drawing.Size(697, 215)
        Me.UltraGridGroup.TabIndex = 5
        Me.UltraGridGroup.Text = "Delivery Schedule"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAddGroup)
        Me.Panel5.Controls.Add(Me.btnDelGroup)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 215)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(697, 32)
        Me.Panel5.TabIndex = 4
        '
        'btnAddGroup
        '
        Me.btnAddGroup.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddGroup.Location = New System.Drawing.Point(554, 0)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(70, 32)
        Me.btnAddGroup.TabIndex = 2
        Me.btnAddGroup.Text = "Add New"
        '
        'btnDelGroup
        '
        Me.btnDelGroup.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelGroup.Location = New System.Drawing.Point(624, 0)
        Me.btnDelGroup.Name = "btnDelGroup"
        Me.btnDelGroup.Size = New System.Drawing.Size(73, 32)
        Me.btnDelGroup.TabIndex = 3
        Me.btnDelGroup.Text = "Delete"
        '
        'Panel2
        '
        '
        'Panel2.ClientArea
        '
        Me.Panel2.ClientArea.Controls.Add(Me.txt_CountryCode)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_CompanyName)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel9)
        Me.Panel2.ClientArea.Controls.Add(Me.chk_IsAdmin)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_ProviderKey)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel7)
        Me.Panel2.ClientArea.Controls.Add(Me.chk_IsTwoFactorAuthentication)
        Me.Panel2.ClientArea.Controls.Add(Me.cmb_AuthenticationProviderId)
        Me.Panel2.ClientArea.Controls.Add(Me.chk_PhoneNumberConfirmed)
        Me.Panel2.ClientArea.Controls.Add(Me.chk_EmailConfirmed)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_PhoneNumber)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel6)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_PasswordHash)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel5)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_Email)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel4)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_SecurityStamp)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.Panel2.ClientArea.Controls.Add(Me.txt_FullName)
        Me.Panel2.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(701, 170)
        Me.Panel2.TabIndex = 3
        '
        'txt_CountryCode
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.txt_CountryCode.Appearance = Appearance1
        Me.txt_CountryCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CountryCode.Location = New System.Drawing.Point(451, 38)
        Me.txt_CountryCode.Name = "txt_CountryCode"
        Me.txt_CountryCode.Size = New System.Drawing.Size(30, 17)
        Me.txt_CountryCode.TabIndex = 146
        Me.txt_CountryCode.Text = "UltraTextEditor6"
        '
        'txt_CompanyName
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.txt_CompanyName.Appearance = Appearance2
        Me.txt_CompanyName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_CompanyName.Location = New System.Drawing.Point(100, 141)
        Me.txt_CompanyName.Name = "txt_CompanyName"
        Me.txt_CompanyName.Size = New System.Drawing.Size(240, 17)
        Me.txt_CompanyName.TabIndex = 145
        Me.txt_CompanyName.Text = "UltraTextEditor2"
        '
        'UltraLabel9
        '
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(10, 142)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(86, 14)
        Me.UltraLabel9.TabIndex = 144
        Me.UltraLabel9.Text = "Company Name"
        '
        'chk_IsAdmin
        '
        Appearance4.TextHAlignAsString = "Right"
        Me.chk_IsAdmin.Appearance = Appearance4
        Me.chk_IsAdmin.Location = New System.Drawing.Point(559, 131)
        Me.chk_IsAdmin.Name = "chk_IsAdmin"
        Me.chk_IsAdmin.Size = New System.Drawing.Size(54, 22)
        Me.chk_IsAdmin.TabIndex = 143
        Me.chk_IsAdmin.Text = "Admin"
        '
        'txt_ProviderKey
        '
        Appearance5.FontData.BoldAsString = "False"
        Me.txt_ProviderKey.Appearance = Appearance5
        Me.txt_ProviderKey.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_ProviderKey.Location = New System.Drawing.Point(100, 115)
        Me.txt_ProviderKey.Name = "txt_ProviderKey"
        Me.txt_ProviderKey.Size = New System.Drawing.Size(240, 17)
        Me.txt_ProviderKey.TabIndex = 140
        Me.txt_ProviderKey.Text = "UltraTextEditor2"
        '
        'UltraLabel7
        '
        Appearance6.FontData.SizeInPoints = 8.25!
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance6
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(27, 116)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(69, 14)
        Me.UltraLabel7.TabIndex = 139
        Me.UltraLabel7.Text = "Provider Key"
        '
        'chk_IsTwoFactorAuthentication
        '
        Appearance7.TextHAlignAsString = "Right"
        Me.chk_IsTwoFactorAuthentication.Appearance = Appearance7
        Me.chk_IsTwoFactorAuthentication.Location = New System.Drawing.Point(379, 130)
        Me.chk_IsTwoFactorAuthentication.Name = "chk_IsTwoFactorAuthentication"
        Me.chk_IsTwoFactorAuthentication.Size = New System.Drawing.Size(154, 27)
        Me.chk_IsTwoFactorAuthentication.TabIndex = 138
        Me.chk_IsTwoFactorAuthentication.Text = "Two Factor Authentication"
        '
        'cmb_AuthenticationProviderId
        '
        Appearance8.FontData.BoldAsString = "False"
        Me.cmb_AuthenticationProviderId.Appearance = Appearance8
        Me.cmb_AuthenticationProviderId.Location = New System.Drawing.Point(133, 36)
        Me.cmb_AuthenticationProviderId.Name = "cmb_AuthenticationProviderId"
        Me.cmb_AuthenticationProviderId.Size = New System.Drawing.Size(207, 22)
        Me.cmb_AuthenticationProviderId.TabIndex = 137
        Me.cmb_AuthenticationProviderId.Text = "UltraCombo5"
        '
        'chk_PhoneNumberConfirmed
        '
        Appearance9.TextHAlignAsString = "Right"
        Me.chk_PhoneNumberConfirmed.Appearance = Appearance9
        Me.chk_PhoneNumberConfirmed.Location = New System.Drawing.Point(525, 101)
        Me.chk_PhoneNumberConfirmed.Name = "chk_PhoneNumberConfirmed"
        Me.chk_PhoneNumberConfirmed.Size = New System.Drawing.Size(154, 22)
        Me.chk_PhoneNumberConfirmed.TabIndex = 136
        Me.chk_PhoneNumberConfirmed.Text = "Phone Number Confirmed"
        '
        'chk_EmailConfirmed
        '
        Appearance10.TextHAlignAsString = "Right"
        Me.chk_EmailConfirmed.Appearance = Appearance10
        Me.chk_EmailConfirmed.Location = New System.Drawing.Point(379, 101)
        Me.chk_EmailConfirmed.Name = "chk_EmailConfirmed"
        Me.chk_EmailConfirmed.Size = New System.Drawing.Size(106, 22)
        Me.chk_EmailConfirmed.TabIndex = 134
        Me.chk_EmailConfirmed.Text = "Email Confirmed"
        '
        'txt_PhoneNumber
        '
        Appearance11.FontData.BoldAsString = "False"
        Me.txt_PhoneNumber.Appearance = Appearance11
        Me.txt_PhoneNumber.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PhoneNumber.Location = New System.Drawing.Point(485, 38)
        Me.txt_PhoneNumber.Name = "txt_PhoneNumber"
        Me.txt_PhoneNumber.Size = New System.Drawing.Size(205, 17)
        Me.txt_PhoneNumber.TabIndex = 55
        Me.txt_PhoneNumber.Text = "UltraTextEditor2"
        '
        'UltraLabel6
        '
        Appearance12.FontData.SizeInPoints = 8.25!
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance12
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(368, 39)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(80, 14)
        Me.UltraLabel6.TabIndex = 54
        Me.UltraLabel6.Text = "Phone Number"
        '
        'txt_PasswordHash
        '
        Appearance13.FontData.BoldAsString = "False"
        Me.txt_PasswordHash.Appearance = Appearance13
        Me.txt_PasswordHash.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_PasswordHash.Location = New System.Drawing.Point(100, 88)
        Me.txt_PasswordHash.Name = "txt_PasswordHash"
        Me.txt_PasswordHash.Size = New System.Drawing.Size(240, 17)
        Me.txt_PasswordHash.TabIndex = 53
        Me.txt_PasswordHash.Text = "UltraTextEditor2"
        '
        'UltraLabel5
        '
        Appearance14.FontData.SizeInPoints = 8.25!
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance14
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(13, 89)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(84, 14)
        Me.UltraLabel5.TabIndex = 52
        Me.UltraLabel5.Text = "Password Hash"
        '
        'txt_Email
        '
        Appearance15.FontData.BoldAsString = "False"
        Me.txt_Email.Appearance = Appearance15
        Me.txt_Email.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_Email.Location = New System.Drawing.Point(100, 64)
        Me.txt_Email.Name = "txt_Email"
        Me.txt_Email.Size = New System.Drawing.Size(240, 17)
        Me.txt_Email.TabIndex = 51
        Me.txt_Email.Text = "UltraTextEditor2"
        '
        'UltraLabel4
        '
        Appearance16.FontData.SizeInPoints = 8.25!
        Appearance16.TextHAlignAsString = "Right"
        Appearance16.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance16
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(64, 65)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(32, 14)
        Me.UltraLabel4.TabIndex = 50
        Me.UltraLabel4.Text = "Email"
        '
        'UltraLabel3
        '
        Appearance17.FontData.SizeInPoints = 8.25!
        Appearance17.TextHAlignAsString = "Right"
        Appearance17.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance17
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(9, 39)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(121, 14)
        Me.UltraLabel3.TabIndex = 48
        Me.UltraLabel3.Text = "Authentication Provider"
        '
        'txt_SecurityStamp
        '
        Appearance18.FontData.BoldAsString = "False"
        Me.txt_SecurityStamp.Appearance = Appearance18
        Me.txt_SecurityStamp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_SecurityStamp.Location = New System.Drawing.Point(450, 12)
        Me.txt_SecurityStamp.Name = "txt_SecurityStamp"
        Me.txt_SecurityStamp.Size = New System.Drawing.Size(240, 17)
        Me.txt_SecurityStamp.TabIndex = 47
        Me.txt_SecurityStamp.Text = "UltraTextEditor2"
        '
        'UltraLabel2
        '
        Appearance19.FontData.SizeInPoints = 8.25!
        Appearance19.TextHAlignAsString = "Right"
        Appearance19.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance19
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(366, 13)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel2.TabIndex = 46
        Me.UltraLabel2.Text = "Security Stamp"
        '
        'txt_FullName
        '
        Appearance20.FontData.BoldAsString = "False"
        Me.txt_FullName.Appearance = Appearance20
        Me.txt_FullName.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.txt_FullName.Location = New System.Drawing.Point(100, 10)
        Me.txt_FullName.Name = "txt_FullName"
        Me.txt_FullName.Size = New System.Drawing.Size(240, 17)
        Me.txt_FullName.TabIndex = 45
        Me.txt_FullName.Text = "UltraTextEditor2"
        '
        'UltraLabel1
        '
        Appearance21.FontData.SizeInPoints = 8.25!
        Appearance21.TextHAlignAsString = "Right"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance21
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(41, 11)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(56, 14)
        Me.UltraLabel1.TabIndex = 42
        Me.UltraLabel1.Text = "Full Name"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnOK)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 443)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(701, 42)
        Me.Panel4.TabIndex = 8
        '
        'btnSave
        '
        Appearance22.FontData.BoldAsString = "True"
        Me.btnSave.Appearance = Appearance22
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(437, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 42)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Appearance23.FontData.BoldAsString = "True"
        Me.btnCancel.Appearance = Appearance23
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(525, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 42)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Appearance24.FontData.BoldAsString = "True"
        Me.btnOK.Appearance = Appearance24
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(613, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 42)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 170)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Appearance25.FontData.BoldAsString = "True"
        Me.UltraTabControl1.SelectedTabAppearance = Appearance25
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(701, 273)
        Me.UltraTabControl1.TabIndex = 9
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
        UltraTab3.TabPage = Me.UltraTabPageControl2
        UltraTab3.Text = "User Account"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Group Membership"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab1})
        Me.UltraTabControl1.TabsPerRow = 5
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(697, 247)
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "User"
        Me.ClientSize = New System.Drawing.Size(701, 485)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmUser"
        Me.Text = "User"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGridUserAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ClientArea.ResumeLayout(False)
        Me.Panel2.ClientArea.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.txt_CountryCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_IsAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ProviderKey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_IsTwoFactorAuthentication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_AuthenticationProviderId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_PhoneNumberConfirmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_EmailConfirmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PhoneNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PasswordHash, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Email, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SecurityStamp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FullName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents chk_PhoneNumberConfirmed As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chk_EmailConfirmed As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txt_PhoneNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_PasswordHash As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Email As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_SecurityStamp As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FullName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UltraGridUserAccount As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAddAcc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelAcc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_AuthenticationProviderId As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents chk_IsAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txt_ProviderKey As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chk_IsTwoFactorAuthentication As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txt_CompanyName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txt_CountryCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGridGroup As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnAddGroup As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDelGroup As Infragistics.Win.Misc.UltraButton
End Class
