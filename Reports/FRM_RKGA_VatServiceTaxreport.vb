Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_RKGA_VatServiceTaxreport
    Inherits System.Windows.Forms.Form
    Dim pageno As Integer
    Dim gconnection As New GlobalClass
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Dim vconn As New GlobalClass
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mskTodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbStax As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVat As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chklist_Type As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_Taxtype As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents LstGroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_itemwise As System.Windows.Forms.CheckBox
    Friend WithEvents CHKBILLDETAILS As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_POSlocation As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chk_POSlocation As System.Windows.Forms.CheckBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents GROUPWISE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLIST_PAYMENTMODE As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_PAYMENTMODE As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Chk_Membername As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_Membername As System.Windows.Forms.CheckedListBox
    Friend WithEvents txt_Tomcode As System.Windows.Forms.TextBox
    Friend WithEvents txt_mcode As System.Windows.Forms.TextBox
    Friend WithEvents cmd_MemberCodeHelp1 As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents membertype As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHK_DATEWISE As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_RKGA_VatServiceTaxreport))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mskFromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskTodate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdbStax = New System.Windows.Forms.RadioButton()
        Me.rdbVat = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_Taxtype = New System.Windows.Forms.CheckBox()
        Me.chklist_Type = New System.Windows.Forms.CheckedListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.LstGroup = New System.Windows.Forms.CheckedListBox()
        Me.Chk_itemwise = New System.Windows.Forms.CheckBox()
        Me.CHKBILLDETAILS = New System.Windows.Forms.CheckBox()
        Me.chklist_POSlocation = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chk_POSlocation = New System.Windows.Forms.CheckBox()
        Me.GROUPWISE = New System.Windows.Forms.CheckBox()
        Me.CHKLIST_PAYMENTMODE = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_PAYMENTMODE = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Chk_Membername = New System.Windows.Forms.CheckBox()
        Me.chklist_Membername = New System.Windows.Forms.CheckedListBox()
        Me.txt_Tomcode = New System.Windows.Forms.TextBox()
        Me.txt_mcode = New System.Windows.Forms.TextBox()
        Me.cmd_MemberCodeHelp1 = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.membertype = New System.Windows.Forms.CheckedListBox()
        Me.CHK_DATEWISE = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CmdClear)
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.CmdView)
        Me.GroupBox2.Controls.Add(Me.cmdexport)
        Me.GroupBox2.Location = New System.Drawing.Point(861, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 388)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(6, 32)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 15
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(8, 271)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(7, 109)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 56)
        Me.CmdView.TabIndex = 12
        Me.CmdView.Text = "Report  [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Transparent
        Me.cmdexport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.cmdexport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.Location = New System.Drawing.Point(8, 191)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(131, 56)
        Me.cmdexport.TabIndex = 16
        Me.cmdexport.Text = "Export [F12]"
        Me.cmdexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.Transparent
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.Location = New System.Drawing.Point(8, 624)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 13
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.mskFromdate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.mskTodate)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(269, 533)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 48)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'mskFromdate
        '
        Me.mskFromdate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromdate.Location = New System.Drawing.Point(168, 14)
        Me.mskFromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskFromdate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskFromdate.Name = "mskFromdate"
        Me.mskFromdate.Size = New System.Drawing.Size(109, 21)
        Me.mskFromdate.TabIndex = 18
        Me.mskFromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(292, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "TO DATE       :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(64, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "FROM DATE :"
        '
        'mskTodate
        '
        Me.mskTodate.CustomFormat = "dd/MM/yyyy"
        Me.mskTodate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskTodate.Location = New System.Drawing.Point(391, 14)
        Me.mskTodate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskTodate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskTodate.Name = "mskTodate"
        Me.mskTodate.Size = New System.Drawing.Size(112, 21)
        Me.mskTodate.TabIndex = 19
        Me.mskTodate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rdbStax)
        Me.GroupBox3.Controls.Add(Me.rdbVat)
        Me.GroupBox3.Location = New System.Drawing.Point(824, 616)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 32)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'rdbStax
        '
        Me.rdbStax.BackColor = System.Drawing.Color.Transparent
        Me.rdbStax.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbStax.Location = New System.Drawing.Point(168, 8)
        Me.rdbStax.Name = "rdbStax"
        Me.rdbStax.Size = New System.Drawing.Size(136, 24)
        Me.rdbStax.TabIndex = 22
        Me.rdbStax.Text = "SERVICE TAX"
        Me.rdbStax.UseVisualStyleBackColor = False
        '
        'rdbVat
        '
        Me.rdbVat.BackColor = System.Drawing.Color.Transparent
        Me.rdbVat.Checked = True
        Me.rdbVat.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbVat.Location = New System.Drawing.Point(48, 8)
        Me.rdbVat.Name = "rdbVat"
        Me.rdbVat.Size = New System.Drawing.Size(56, 24)
        Me.rdbVat.TabIndex = 21
        Me.rdbVat.TabStop = True
        Me.rdbVat.Text = "VAT"
        Me.rdbVat.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(494, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 24)
        Me.Label4.TabIndex = 424
        Me.Label4.Text = "ITEM CODE   :"
        '
        'Chk_Taxtype
        '
        Me.Chk_Taxtype.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Taxtype.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Taxtype.Location = New System.Drawing.Point(493, 131)
        Me.Chk_Taxtype.Name = "Chk_Taxtype"
        Me.Chk_Taxtype.Size = New System.Drawing.Size(138, 16)
        Me.Chk_Taxtype.TabIndex = 423
        Me.Chk_Taxtype.Text = "SELECT ALL"
        Me.Chk_Taxtype.UseVisualStyleBackColor = False
        '
        'chklist_Type
        '
        Me.chklist_Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Type.Location = New System.Drawing.Point(493, 171)
        Me.chklist_Type.Name = "chklist_Type"
        Me.chklist_Type.Size = New System.Drawing.Size(150, 319)
        Me.chklist_Type.TabIndex = 422
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 480)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 24)
        Me.Label7.TabIndex = 427
        Me.Label7.Text = "GROUP DESCRIPTION :"
        Me.Label7.Visible = False
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(8, 528)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(32, 16)
        Me.Chk_SelectAllGroup.TabIndex = 425
        Me.Chk_SelectAllGroup.Text = "SELECT ALL "
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        Me.Chk_SelectAllGroup.Visible = False
        '
        'LstGroup
        '
        Me.LstGroup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LstGroup.Location = New System.Drawing.Point(16, 448)
        Me.LstGroup.Name = "LstGroup"
        Me.LstGroup.Size = New System.Drawing.Size(40, 25)
        Me.LstGroup.TabIndex = 426
        Me.LstGroup.Visible = False
        '
        'Chk_itemwise
        '
        Me.Chk_itemwise.BackColor = System.Drawing.Color.Transparent
        Me.Chk_itemwise.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_itemwise.Location = New System.Drawing.Point(320, 501)
        Me.Chk_itemwise.Name = "Chk_itemwise"
        Me.Chk_itemwise.Size = New System.Drawing.Size(131, 16)
        Me.Chk_itemwise.TabIndex = 428
        Me.Chk_itemwise.Text = "ITEMWISE [Y/N]"
        Me.Chk_itemwise.UseVisualStyleBackColor = False
        '
        'CHKBILLDETAILS
        '
        Me.CHKBILLDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CHKBILLDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKBILLDETAILS.Location = New System.Drawing.Point(483, 501)
        Me.CHKBILLDETAILS.Name = "CHKBILLDETAILS"
        Me.CHKBILLDETAILS.Size = New System.Drawing.Size(125, 16)
        Me.CHKBILLDETAILS.TabIndex = 429
        Me.CHKBILLDETAILS.Text = "BILL WISE  [Y/N]"
        Me.CHKBILLDETAILS.UseVisualStyleBackColor = False
        '
        'chklist_POSlocation
        '
        Me.chklist_POSlocation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_POSlocation.Location = New System.Drawing.Point(332, 171)
        Me.chklist_POSlocation.Name = "chklist_POSlocation"
        Me.chklist_POSlocation.Size = New System.Drawing.Size(157, 319)
        Me.chklist_POSlocation.TabIndex = 430
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(332, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 23)
        Me.Label1.TabIndex = 432
        Me.Label1.Text = "POS DESCRIPTION :"
        '
        'Chk_POSlocation
        '
        Me.Chk_POSlocation.BackColor = System.Drawing.Color.Transparent
        Me.Chk_POSlocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_POSlocation.Location = New System.Drawing.Point(332, 123)
        Me.Chk_POSlocation.Name = "Chk_POSlocation"
        Me.Chk_POSlocation.Size = New System.Drawing.Size(157, 24)
        Me.Chk_POSlocation.TabIndex = 433
        Me.Chk_POSlocation.Text = "SELECT ALL"
        Me.Chk_POSlocation.UseVisualStyleBackColor = False
        '
        'GROUPWISE
        '
        Me.GROUPWISE.BackColor = System.Drawing.Color.Transparent
        Me.GROUPWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GROUPWISE.Location = New System.Drawing.Point(784, 424)
        Me.GROUPWISE.Name = "GROUPWISE"
        Me.GROUPWISE.Size = New System.Drawing.Size(184, 16)
        Me.GROUPWISE.TabIndex = 429
        Me.GROUPWISE.Text = "GROUP WISE [Y/N]"
        Me.GROUPWISE.UseVisualStyleBackColor = False
        Me.GROUPWISE.Visible = False
        '
        'CHKLIST_PAYMENTMODE
        '
        Me.CHKLIST_PAYMENTMODE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLIST_PAYMENTMODE.Location = New System.Drawing.Point(187, 439)
        Me.CHKLIST_PAYMENTMODE.Name = "CHKLIST_PAYMENTMODE"
        Me.CHKLIST_PAYMENTMODE.Size = New System.Drawing.Size(136, 49)
        Me.CHKLIST_PAYMENTMODE.TabIndex = 434
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(187, 415)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 24)
        Me.Label3.TabIndex = 435
        Me.Label3.Text = "PAYMENTMODE:"
        '
        'Chk_PAYMENTMODE
        '
        Me.Chk_PAYMENTMODE.BackColor = System.Drawing.Color.Transparent
        Me.Chk_PAYMENTMODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_PAYMENTMODE.Location = New System.Drawing.Point(187, 391)
        Me.Chk_PAYMENTMODE.Name = "Chk_PAYMENTMODE"
        Me.Chk_PAYMENTMODE.Size = New System.Drawing.Size(136, 24)
        Me.Chk_PAYMENTMODE.TabIndex = 436
        Me.Chk_PAYMENTMODE.Text = "SELECT ALL"
        Me.Chk_PAYMENTMODE.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(824, 440)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 439
        Me.Label6.Text = "SERVER DESCRIPTION :"
        Me.Label6.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(800, 408)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox1.TabIndex = 437
        Me.CheckBox1.Text = "SELECT ALL "
        Me.CheckBox1.UseVisualStyleBackColor = False
        Me.CheckBox1.Visible = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CheckedListBox1.Location = New System.Drawing.Point(832, 472)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(112, 46)
        Me.CheckedListBox1.TabIndex = 438
        Me.CheckedListBox1.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(649, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 24)
        Me.Label8.TabIndex = 442
        Me.Label8.Text = "MEMBER NAME  :"
        '
        'Chk_Membername
        '
        Me.Chk_Membername.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Membername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Membername.Location = New System.Drawing.Point(651, 123)
        Me.Chk_Membername.Name = "Chk_Membername"
        Me.Chk_Membername.Size = New System.Drawing.Size(164, 24)
        Me.Chk_Membername.TabIndex = 441
        Me.Chk_Membername.Text = "SELECT ALL"
        Me.Chk_Membername.UseVisualStyleBackColor = False
        '
        'chklist_Membername
        '
        Me.chklist_Membername.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Membername.Location = New System.Drawing.Point(647, 171)
        Me.chklist_Membername.Name = "chklist_Membername"
        Me.chklist_Membername.Size = New System.Drawing.Size(205, 319)
        Me.chklist_Membername.TabIndex = 440
        '
        'txt_Tomcode
        '
        Me.txt_Tomcode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tomcode.Location = New System.Drawing.Point(651, 606)
        Me.txt_Tomcode.Name = "txt_Tomcode"
        Me.txt_Tomcode.Size = New System.Drawing.Size(120, 21)
        Me.txt_Tomcode.TabIndex = 587
        '
        'txt_mcode
        '
        Me.txt_mcode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mcode.Location = New System.Drawing.Point(403, 605)
        Me.txt_mcode.Name = "txt_mcode"
        Me.txt_mcode.Size = New System.Drawing.Size(120, 21)
        Me.txt_mcode.TabIndex = 585
        '
        'cmd_MemberCodeHelp1
        '
        Me.cmd_MemberCodeHelp1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd_MemberCodeHelp1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_MemberCodeHelp1.Image = CType(resources.GetObject("cmd_MemberCodeHelp1.Image"), System.Drawing.Image)
        Me.cmd_MemberCodeHelp1.Location = New System.Drawing.Point(778, 604)
        Me.cmd_MemberCodeHelp1.Name = "cmd_MemberCodeHelp1"
        Me.cmd_MemberCodeHelp1.Size = New System.Drawing.Size(24, 24)
        Me.cmd_MemberCodeHelp1.TabIndex = 590
        Me.cmd_MemberCodeHelp1.UseVisualStyleBackColor = False
        '
        'cmd_MemberCodeHelp
        '
        Me.cmd_MemberCodeHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd_MemberCodeHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_MemberCodeHelp.Image = CType(resources.GetObject("cmd_MemberCodeHelp.Image"), System.Drawing.Image)
        Me.cmd_MemberCodeHelp.Location = New System.Drawing.Point(529, 604)
        Me.cmd_MemberCodeHelp.Name = "cmd_MemberCodeHelp"
        Me.cmd_MemberCodeHelp.Size = New System.Drawing.Size(24, 24)
        Me.cmd_MemberCodeHelp.TabIndex = 586
        Me.cmd_MemberCodeHelp.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(301, 606)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 24)
        Me.Label11.TabIndex = 584
        Me.Label11.Text = "MCODE FROM :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(565, 606)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 24)
        Me.Label9.TabIndex = 591
        Me.Label9.Text = "MCODE TO   :"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(187, 255)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 24)
        Me.Label12.TabIndex = 594
        Me.Label12.Text = "CATEGORY"
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(187, 231)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllCategory.TabIndex = 592
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstcategory.Location = New System.Drawing.Point(187, 279)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(136, 94)
        Me.lstcategory.TabIndex = 593
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.Location = New System.Drawing.Point(206, 85)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(174, 15)
        Me.lbl_Heading.TabIndex = 595
        Me.lbl_Heading.Text = "ITEMWISE/BILLWISE  REPORT"
        '
        'membertype
        '
        Me.membertype.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membertype.Items.AddRange(New Object() {"CLUBMEMBER", "AFFMEMBER", "EMPMEMBER", "ROOMGUEST"})
        Me.membertype.Location = New System.Drawing.Point(187, 171)
        Me.membertype.Name = "membertype"
        Me.membertype.Size = New System.Drawing.Size(136, 49)
        Me.membertype.TabIndex = 596
        '
        'CHK_DATEWISE
        '
        Me.CHK_DATEWISE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DATEWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DATEWISE.Location = New System.Drawing.Point(662, 501)
        Me.CHK_DATEWISE.Name = "CHK_DATEWISE"
        Me.CHK_DATEWISE.Size = New System.Drawing.Size(120, 16)
        Me.CHK_DATEWISE.TabIndex = 597
        Me.CHK_DATEWISE.Text = "DATEWISE [Y/N]"
        Me.CHK_DATEWISE.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(187, 144)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(136, 24)
        Me.CheckBox2.TabIndex = 598
        Me.CheckBox2.Text = "SELECT ALL "
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'FRM_RKGA_VatServiceTaxreport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CHK_DATEWISE)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.membertype)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.txt_Tomcode)
        Me.Controls.Add(Me.txt_mcode)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmd_MemberCodeHelp1)
        Me.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Chk_Membername)
        Me.Controls.Add(Me.chklist_Membername)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Chk_PAYMENTMODE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CHKLIST_PAYMENTMODE)
        Me.Controls.Add(Me.Chk_POSlocation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chklist_POSlocation)
        Me.Controls.Add(Me.CHKBILLDETAILS)
        Me.Controls.Add(Me.Chk_itemwise)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Chk_SelectAllGroup)
        Me.Controls.Add(Me.LstGroup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_Taxtype)
        Me.Controls.Add(Me.chklist_Type)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GROUPWISE)
        Me.KeyPreview = True
        Me.Name = "FRM_RKGA_VatServiceTaxreport"
        Me.Text = "Vat and ServiceTaxreport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click


        If chklist_POSlocation.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the PaymentMode(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If chklist_Type.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Item(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If membertype.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Membertype(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If lstcategory.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Membertype(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        
        Checkdaterangevalidate(mskFromdate.Value, mskTodate.Value)
        If chkdatevalidate = False Then Exit Sub

        Dim SSQL As String
        gPrint = False
        If Chk_itemwise.Checked = True Then
            'itemwisesaleregister()
            SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            itemwisesaleregister_cry()
        ElseIf CHKBILLDETAILS.Checked = True Then
            'itemwisesaleregister_BILL()
            SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)
            itemwisesaleregister_BILL_crystal()

        ElseIf GROUPWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            itemwisesaleregister_Group_crystal()
            'itemwisesaleregister_Group()
        ElseIf CHK_DATEWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call DATEWISESALES()
        Else
            SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            Printoperation_Vat_CRYSTAL()
            'Printoperation_Vat()
        End If
    End Sub
    Private Sub DATEWISESALES()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String
        SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,SUM(PACKAMOUNT)AS PACKAMOUNT,KOTDATE,ISNULL(CATEGORY,'') AS CATEGORY,SUM(SER_CHG) AS SER_CHG,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE,"
        SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        'SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,"
        'SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,106) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  itemcode IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(0) & "', "
                HNAME = HNAME & " " & Trim(TYPE(1))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        '========

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"

            End If
        End If

        SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,RATE,UOM,CATEGORY,KOTDATE ORDER BY KOTDATE,ITEMDESC "


        'SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,UOM,CATEGORY "

        Dim r1 As New DATEWISESALES
        Dim Viewer As New ReportViwer
        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = " PERIOD FROM " & Format(mskFromdate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskTodate.Value, "dd/MM/yyyy") & ""


        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text17")
        TXTOBJ1.Text = "UserName : " & gUsername



        Viewer.ssql = SSQL
        Viewer.Report = r1
        Viewer.TableName = "VIEWITEMWISESALESUMMARY_TAXWISE"
        Viewer.Show()
    End Sub
    Private Sub itemwisesaleregister()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String
        SSQL = "SELECT ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,"
        SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  TAXCODE IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "
                HNAME = HNAME & " " & Trim(TYPE(0))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MessageBox.Show("Select the TaxType Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the GROUP", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        '====

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND SCODE IN ("
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the SERVER", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If

        '========

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        Else
            MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If



        End If




        SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,UOM "
        Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        Dim objSaleregistersummary As New rptSaleregistersummary_TAXTYPE
        objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub
    Private Sub itemwisesaleregister_BILL()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String

        SSQL = "SELECT ITEMCODE,ITEMDESC,QTY AS QTY,AMOUNT AS AMOUNT,TAXAMOUNT,POSCODE,GROUPCODE,KOTDATE,TAXCODE,KOTDETAILS,RATE,mcode,"
        SSQL = SSQL & "BILLAMOUNT AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  TAXCODE IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "
                HNAME = HNAME & " " & Trim(TYPE(0))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MessageBox.Show("Select the TaxType Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If

        '====

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND SCODE IN ("
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the SERVER", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If

        '========




        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        Else
            MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If


        '''  If chklist_Membername.CheckedItems.Count <> 0 Then
        '''SSQL = SSQL & " AND mcode IN ("
        ''' For i = 0 To chklist_Membername.CheckedItems.Count - 1
        '''   SSQL = SSQL & " '" & chklist_Membername.CheckedItems(i) & "', "
        'SSQL = SSQL & " '" & TYPE(1) & "', "

        '''  Next
        '''   SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '''   SSQL = SSQL & ") order by mcode"
        '''   Else
        '''   MsgBox("Select the MCODE", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
        '''   Exit Sub
        '''   End If



        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ") order by mcode"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If




        End If




        'SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC "
        Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        Dim objSaleregistersummary As New BILLWISE_TAX
        objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub


    Private Sub itemwisesaleregister_BILL_crystal()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String

        SSQL = "SELECT isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC,QTY AS QTY,AMOUNT AS AMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,TAXAMOUNT,SER_CHG,PACKAMOUNT,POSCODE,POSDesc,GROUPCODE,KOTDATE,TAXCODE,KOTDETAILS,RATE,mcode,PAYMENTMODE,"
        SSQL = SSQL & "MNAME,BILLAMOUNT AS BILLAMOUNT,ISNULL(SER_CHG,0) AS SER_CHG,ISNULL(ACHARGE,0) AS ACHARGE,ISNULL(PCHARGE,0) AS PCHARGE,ISNULL(RCHARGE,0) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        'SSQL = "SELECT ITEMCODE,ITEMDESC,QTY AS QTY,AMOUNT AS AMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,TAXAMOUNT,POSCODE,GROUPCODE,KOTDATE,TAXCODE,KOTDETAILS,RATE,mcode,"
        'SSQL = SSQL & "BILLAMOUNT AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"

        'If chklist_Type.CheckedItems.Count <> 0 Then
        '    SSQL = SSQL & " and  itemcode IN("
        '    For i = 0 To chklist_Type.CheckedItems.Count - 1
        '        TYPE = Split(chklist_Type.CheckedItems(i), "-->")
        '        SSQL = SSQL & " '" & TYPE(1) & "', "
        '        HNAME = HNAME & " " & Trim(TYPE(0))
        '        'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
        '    Next
        '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '    SSQL = SSQL & ")"

        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND itemcode IN ("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                itemcode = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & "'" & itemcode(0) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ") "


        End If

        'If chklist_Type.CheckedItems.Count <> 0 Then
        '    SSQL = SSQL & " and  TAXCODE IN("
        '    For i = 0 To chklist_Type.CheckedItems.Count - 1
        '        TYPE = Split(chklist_Type.CheckedItems(i), "-->")
        '        SSQL = SSQL & " '" & TYPE(1) & "', "
        '        HNAME = HNAME & " " & Trim(TYPE(0))
        '        'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
        '    Next
        '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '    SSQL = SSQL & ")"




        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        '====

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND SCODE IN ("
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If

        '========




        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"

        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ") "
            End If

            SSQL = SSQL & "order by kotdetails,MTORDERNO,PREFIXMCODE,MSORDERNO,kotdate"
            'SSQL = SSQL & "order by kotdetails,MTORDERNO,PREFIXMCODE,MSORDERNO,kotdate"
        End If
        Dim r1 As New VatItemWiseBillwise

        Dim Viewer As New ReportViwer

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = " PERIOD FROM  " & Format(mskFromdate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskTodate.Value, "dd/MM/yyyy") & ""


        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text11")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text2")
        TXTOBJ1.Text = "UserName : " & gUsername



        Viewer.ssql = SSQL
        Viewer.Report = r1
        Viewer.TableName = "VIEWITEMWISESALESUMMARY_TAXWISE"
        Viewer.Show()




        'SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC "
        'Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        'Dim objSaleregistersummary As New BILLWISE_TAX
        'objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub

    Private Sub itemwisesaleregister_Group()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String

        SSQL = "SELECT GROUPNAME,(ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(AMOUNT),0)) AS TOTALAMOUNT, ISNULL(SUM(TAXAMOUNT),0) AS TAXAMOUNT,ISNULL(SUM(AMOUNT),0) AS AMOUNT,ISNULL(SUM(QTY),0)  AS QTY,SUM(SER_CHG) AS SER_CHG,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE,SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  TAXCODE IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "
                HNAME = HNAME & " " & Trim(TYPE(0))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MessageBox.Show("Select the TaxType Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If


        '====

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND SCODE IN ("
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        Else
            MsgBox("Select the SERVER", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        '========
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("
            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        Else
            MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ") "
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If





        SSQL = SSQL & " GROUP BY GROUPNAME "

        Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        Dim objSaleregistersummary As New ITEMGROUPWISE
        objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub
    Private Sub itemwisesaleregister_Group_crystal()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String

        SSQL = "SELECT GROUPNAME,(ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(AMOUNT),0)) AS TOTALAMOUNT, ISNULL(SUM(TAXAMOUNT),0) AS TAXAMOUNT,ISNULL(SUM(AMOUNT),0) AS AMOUNT,ISNULL(SUM(QTY),0)  AS QTY,SUM(SER_CHG)AS SER_CHG,SUM(ACHARGE)AS ACHARGE,SUM(PCHARGE)AS PCHARGE,SUM(RCHARGE)AS RCHARGE,SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"

        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  ITEMDESC IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "
                HNAME = HNAME & " " & Trim(TYPE(0))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            'SSQL = SSQL & " and  TAXCODE IN("
            'For i = 0 To chklist_Type.CheckedItems.Count - 1
            '    TYPE = Split(chklist_Type.CheckedItems(i), "-->")
            '    SSQL = SSQL & " '" & TYPE(1) & "', "
            '    HNAME = HNAME & " " & Trim(TYPE(0))
            '    'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            'Next
            'SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            'SSQL = SSQL & ")"

        End If

        'If LstGroup.CheckedItems.Count <> 0 Then
        '    SSQL = SSQL & " AND GROUPCODE IN ("
        '    For i = 0 To LstGroup.CheckedItems.Count - 1
        '        TYPE = Split(LstGroup.CheckedItems(i), "-->")
        '        SSQL = SSQL & " '" & TYPE(1) & "', "

        '    Next
        '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '    SSQL = SSQL & ")"
        'End If
        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If


        '====

        'If CheckedListBox1.CheckedItems.Count <> 0 Then
        '    SSQL = SSQL & " AND SCODE IN ("
        '    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
        '        TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
        '        SSQL = SSQL & " '" & TYPE(1) & "', "

        '    Next
        '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '    SSQL = SSQL & ")"

        'End If
        '========
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("
            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"

        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ") "

            End If
        End If





        SSQL = SSQL & " GROUP BY GROUPNAME "

        Dim r1 As New VatItemWiseGroupwise
        Dim Viewer As New ReportViwer
        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = " From  " & Format(mskFromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskTodate.Value, "dd/MM/yyyy") & ""


        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = "UserName : " & gUsername




        Viewer.ssql = SSQL
        Viewer.Report = r1
        Viewer.TableName = "VIEWITEMWISESALESUMMARY_TAXWISE"
        Viewer.Show()


        'Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        'Dim objSaleregistersummary As New ITEMGROUPWISE
        'objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub

    Private Sub Printoperation_Vat()
        Dim sqlstring, SSQL As String
        Dim TYPE(), HNAME As String
        Dim heading, MEMBERCODE() As String
        Dim rowcount, TotalDoc, pageno As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Cro" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".Txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            'PrintHeader(HNAME, mskFromdate.Value, mskTodate.Value, pageno)

            ''========================================================================
            Dim vTypeseqno As Double
            Dim vGroupseqno As Double
            Dim totQty, totAmount, totTax, gtotal As Double
            Dim dt As New DataTable
            Dim i, j As Integer
            SSQL = "select d.poscode,p.posdesc as POS,isnull(sum(amount),0) as amount,isnull(sum(taxamount),0) as taxamount,"
            SSQL = SSQL & " isnull(ROUND(SUM(amount+taxamount),0),2) as totalamount "
            SSQL = SSQL & " from kot_det d ,posmaster p"
            SSQL = SSQL & " where(p.poscode = d.poscode)"
            SSQL = SSQL & " and isnull(delflag,'')<>'Y' and isnull(kotstatus,'')<>'Y'"
            SSQL = SSQL & " and cast(convert(varchar(11),d.kotdate,6) as datetime) between "
            SSQL = SSQL & "'" & Format(mskFromdate.Value, "dd-MMM-yyyy") & "' and '" & Format(mskTodate.Value, "dd-MMM-yyyy") & "'"

            If chklist_Type.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " and  TAXCODE IN("
                For i = 0 To chklist_Type.CheckedItems.Count - 1
                    TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "
                    'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MessageBox.Show("Select the TaxType Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If LstGroup.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND GROUPCODE IN ("
                For i = 0 To LstGroup.CheckedItems.Count - 1
                    TYPE = Split(LstGroup.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If
            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND d.POSCODE IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "

                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If

            If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND PAYMENTMODE IN ("
                HNAME = "("
                For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                    SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                    HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"
            Else
                MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If


            'If chklist_Membername.CheckedItems.Count <> 0 Then
            '    SSQL = SSQL & " AND MCODE IN ("
            '    For i = 0 To chklist_Membername.CheckedItems.Count - 1
            '        MEMBERCODE = Split(chklist_Membername.CheckedItems(i), "->")
            '        SSQL = SSQL & "'" & MEMBERCODE(0) & "' ,"
            '    Next
            '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            '    SSQL = SSQL & "'"
            'Else
            '    MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If


            If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
                SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
            Else
                If chklist_Membername.CheckedItems.Count <> 0 Then
                    SSQL = SSQL & " AND MCODE IN ("
                    For i = 0 To chklist_Membername.CheckedItems.Count - 1
                        TYPE = Split(chklist_Membername.CheckedItems(i), "-->")
                        SSQL = SSQL & " '" & TYPE(0) & "', "
                    Next
                    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                    SSQL = SSQL & ")"
                Else
                    MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                    Exit Sub
                End If
            End If





            PrintHeader(HNAME, mskFromdate.Value, mskTodate.Value, pageno)

            SSQL = SSQL & " group by d.poscode,p.posdesc order by posdesc "
            gconnection.getDataSet(SSQL, "VAT")
            If gdataset.Tables("VAT").Rows.Count > 0 Then
                Filewrite.Write(Chr(18))
                rowcount = 9
                For i = 0 To gdataset.Tables("VAT").Rows.Count - 1
                    sqlstring = Trim(gdataset.Tables("VAT").Rows(i).Item("POS")) & Space(29 - Len(Mid(Trim(gdataset.Tables("VAT").Rows(i).Item("POS")), 1, 29)))
                    sqlstring = sqlstring & Space(12 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))
                    sqlstring = sqlstring & Space(18 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))
                    sqlstring = sqlstring & Space(17 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))
                    Filewrite.WriteLine(sqlstring)
                    rowcount = rowcount + 1
                    TotalDoc = TotalDoc + 1
                    totAmount = totAmount + Val(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))
                    totTax = totTax + Val(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))
                    gtotal = gtotal + Val(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))
                    If rowcount >= 60 Then
                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        PrintHeader(heading, mskFromdate.Value, mskTodate.Value, pageno)
                        rowcount = 9
                    End If
                Next
                Filewrite.WriteLine(StrDup(79, "="))
                sqlstring = "Total :" & Space(22) & Space(12 - Len(Trim(Mid(Format(totAmount, "0.00"), 1, 12)))) & Format(totAmount, "0.00")
                sqlstring = sqlstring & Space(18 - Len(Trim(CStr(Format(totTax, "0.00"))))) & Format(totTax, "0.00")
                sqlstring = sqlstring & Space(17 - Len(Trim(CStr(Format(gtotal, "0.00"))))) & Format(gtotal, "0.00")
                Filewrite.WriteLine(sqlstring)
                Filewrite.WriteLine(StrDup(79, "="))
                Filewrite.WriteLine("Total Document(S)    : " & TotalDoc)
                Filewrite.WriteLine(StrDup(79, "="))
                Filewrite.Write(Chr(12))
                Filewrite.Close()
                If gPrint = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile1(VFilePath)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid Billno :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
        End Try
    End Sub

    Private Sub Printoperation_Vat_CRYSTAL()
        Dim sqlstring, SSQL As String
        Dim TYPE(), HNAME As String
        Dim heading, MEMBERCODE() As String
        Dim rowcount, TotalDoc, pageno As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Cro" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".Txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            'PrintHeader(HNAME, mskFromdate.Value, mskTodate.Value, pageno)

            ''========================================================================
            Dim vTypeseqno As Double
            Dim vGroupseqno As Double
            Dim totQty, totAmount, totTax, gtotal As Double
            Dim dt As New DataTable
            Dim i, j As Integer
            SSQL = "select poscode, POS, sum(amount) as amount,sum(taxamount) as taxamount,"
            SSQL = SSQL & "  sum(totalamount)as totalamount "
            SSQL = SSQL & " from VIEWITEMWISESALESUMMARY_POSWISE"
            SSQL = SSQL & " where"
            'SSQL = SSQL & " and isnull(delflag,'')<>'Y' and isnull(kotstatus,'')<>'Y'"
            SSQL = SSQL & " cast(convert(varchar(11),kotdate,6) as datetime) between "
            SSQL = SSQL & "'" & Format(mskFromdate.Value, "dd-MMM-yyyy") & "' and '" & Format(mskTodate.Value, "dd-MMM-yyyy") & "'"

            If chklist_Type.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " and  TAXCODE IN("
                For i = 0 To chklist_Type.CheckedItems.Count - 1
                    TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "
                    'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MessageBox.Show("Select the TaxType Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If LstGroup.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND GROUPCODE IN ("
                For i = 0 To LstGroup.CheckedItems.Count - 1
                    TYPE = Split(LstGroup.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If
            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND POSCODE IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                    SSQL = SSQL & " '" & TYPE(1) & "', "

                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            Else
                MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If


            If lstcategory.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
            End If

            If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND PAYMENTMODE IN ("
                HNAME = "("
                For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                    SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                    HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"
            Else
                MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If


            'If chklist_Membername.CheckedItems.Count <> 0 Then
            '    SSQL = SSQL & " AND MCODE IN ("
            '    For i = 0 To chklist_Membername.CheckedItems.Count - 1
            '        MEMBERCODE = Split(chklist_Membername.CheckedItems(i), "->")
            '        SSQL = SSQL & "'" & MEMBERCODE(0) & "' ,"
            '    Next
            '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            '    SSQL = SSQL & "'"
            'Else
            '    MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If


            If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
                SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
            Else
                If chklist_Membername.CheckedItems.Count <> 0 Then
                    SSQL = SSQL & " AND MCODE IN ("
                    For i = 0 To chklist_Membername.CheckedItems.Count - 1
                        TYPE = Split(chklist_Membername.CheckedItems(i), "-->")
                        SSQL = SSQL & " '" & TYPE(0) & "', "
                    Next
                    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                    SSQL = SSQL & ")"
                Else
                    MsgBox("Select the POS(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                    Exit Sub
                End If
            End If
            SSQL = SSQL & "group by poscode, POS"


            Dim r1 As New VatItemWiselocationwise
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = " From  " & Format(mskFromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskTodate.Value, "dd/MM/yyyy") & ""


            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
            TXTOBJ4.Text = HNAME

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname


            Viewer.ssql = SSQL
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_POSWISE"
            Viewer.Show()


            'PrintHeader(HNAME, mskFromdate.Value, mskTodate.Value, pageno)

            'SSQL = SSQL & " group by d.poscode,p.posdesc order by posdesc "
            'gconnection.getDataSet(SSQL, "VAT")
            'If gdataset.Tables("VAT").Rows.Count > 0 Then
            '    Filewrite.Write(Chr(18))
            '    rowcount = 9
            '    For i = 0 To gdataset.Tables("VAT").Rows.Count - 1
            '        sqlstring = Trim(gdataset.Tables("VAT").Rows(i).Item("POS")) & Space(29 - Len(Mid(Trim(gdataset.Tables("VAT").Rows(i).Item("POS")), 1, 29)))
            '        sqlstring = sqlstring & Space(12 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))
            '        sqlstring = sqlstring & Space(18 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))
            '        sqlstring = sqlstring & Space(17 - Len(Trim(CStr(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))))) & Trim(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))
            '        Filewrite.WriteLine(sqlstring)
            '        rowcount = rowcount + 1
            '        TotalDoc = TotalDoc + 1
            '        totAmount = totAmount + Val(gdataset.Tables("VAT").Rows(i).Item("AMOUNT"))
            '        totTax = totTax + Val(gdataset.Tables("VAT").Rows(i).Item("TAXAMOUNT"))
            '        gtotal = gtotal + Val(gdataset.Tables("VAT").Rows(i).Item("TOTALAMOUNT"))
            '        If rowcount >= 60 Then
            '            Filewrite.WriteLine(StrDup(79, "-"))
            '            Filewrite.Write(Chr(12))
            '            pageno = pageno + 1
            '            PrintHeader(heading, mskFromdate.Value, mskTodate.Value, pageno)
            '            rowcount = 9
            '        End If
            '    Next
            '    Filewrite.WriteLine(StrDup(79, "="))
            '    sqlstring = "Total :" & Space(22) & Space(12 - Len(Trim(Mid(Format(totAmount, "0.00"), 1, 12)))) & Format(totAmount, "0.00")
            '    sqlstring = sqlstring & Space(18 - Len(Trim(CStr(Format(totTax, "0.00"))))) & Format(totTax, "0.00")
            '    sqlstring = sqlstring & Space(17 - Len(Trim(CStr(Format(gtotal, "0.00"))))) & Format(gtotal, "0.00")
            '    Filewrite.WriteLine(sqlstring)
            '    Filewrite.WriteLine(StrDup(79, "="))
            '    Filewrite.WriteLine("Total Document(S)    : " & TotalDoc)
            '    Filewrite.WriteLine(StrDup(79, "="))
            '    Filewrite.Write(Chr(12))
            '    Filewrite.Close()
            '    If gPrint = False Then
            '        OpenTextFile(vOutfile)
            '    Else
            '        PrintTextFile1(VFilePath)
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid Billno :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
        End Try
    End Sub

    Private Function PrintOperation_Stax()
        Dim sqlstring, SSQL As String
        Dim heading As String
        Dim rowcount, TotalDoc, pageno As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Cro" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".Txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            heading = "SERVICE TAX REPORT REGISTER"
            Filewrite.Write(Chr(15))
            PrintHeader_Stax(heading, mskFromdate.Value, mskTodate.Value, pageno)

            ''========================================================================
            Dim vTypeseqno As Double
            Dim vGroupseqno As Double
            Dim totQty, totAmount, totTax, gtotal As Double
            Dim dt As New DataTable
            Dim i, j As Integer
            SSQL = "SELECT H.BILLDETAILS,H.BILLDATE AS BILLDATE,H.TAXAMOUNT AS TAXAMOUNT,"
            SSQL = SSQL & "H.BILLAMOUNT AS BILLAMOUNT,ROUND(H.TOTALAMOUNT,0) AS TOTALAMOUNT"
            SSQL = SSQL & " FROM BILL_HDR H INNER JOIN BILL_DET D ON D.BILLNO=H.BILLNO "
            SSQL = SSQL & "WHERE H.BILLDATE  BETWEEN "
            SSQL = SSQL & "'" & Format(mskFromdate.Value, "dd-MMM-yyyy") & "' and '" & Format(mskTodate.Value, "dd-MMM-yyyy") & "'"
            SSQL = SSQL & " and  Taxcode IN(SELECT TAXCODE FROM ACCOUNTSTAXMASTER WHERE TYPEOFTAX='SERVICE TAX')  AND ISNULL(H.DELFLAG,'')<>'Y' ORDER BY H.BILLDETAILS"

            gconnection.getDataSet(SSQL, "STAX")
            If gdataset.Tables("STAX").Rows.Count > 0 Then
                Filewrite.Write(Chr(18))
                rowcount = 9
                For i = 0 To gdataset.Tables("STAX").Rows.Count - 1
                    sqlstring = Mid(Trim(gdataset.Tables("STAX").Rows(i).Item("BILLDETAILS")), 1, 16) & Space(18 - Len(Mid(Trim(gdataset.Tables("STAX").Rows(i).Item("BILLDETAILS")), 1, 16))) & Mid(Trim(gdataset.Tables("STAX").Rows(i).Item("BILLDATE")), 1, 10) & Space(10 - Len(Mid(Trim(gdataset.Tables("STAX").Rows(i).Item("BILLDATE")), 1, 10)))
                    sqlstring = sqlstring & Space(13 - Len(Trim(CStr(gdataset.Tables("STAX").Rows(i).Item("BILLAMOUNT"))))) & Trim(gdataset.Tables("STAX").Rows(i).Item("BILLAMOUNT"))
                    sqlstring = sqlstring & Space(12 - Len(Trim(CStr(gdataset.Tables("STAX").Rows(i).Item("TAXAMOUNT"))))) & Trim(Mid(gdataset.Tables("STAX").Rows(i).Item("TAXAMOUNT"), 1, 12))
                    sqlstring = sqlstring & Space(14 - Len(Trim(CStr(gdataset.Tables("STAX").Rows(i).Item("TOTALAMOUNT"))))) & Trim(gdataset.Tables("STAX").Rows(i).Item("TOTALAMOUNT"))
                    Filewrite.WriteLine(sqlstring)
                    rowcount = rowcount + 1
                    TotalDoc = TotalDoc + 1
                    totAmount = totAmount + Val(gdataset.Tables("STAX").Rows(i).Item("BILLAMOUNT"))
                    totTax = totTax + Val(gdataset.Tables("STAX").Rows(i).Item("TAXAMOUNT"))
                    gtotal = gtotal + Val(gdataset.Tables("STAX").Rows(i).Item("TOTALAMOUNT"))
                    If rowcount >= 60 Then
                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        PrintHeader_Stax(heading, mskFromdate.Value, mskTodate.Value, pageno)
                        rowcount = 9
                    End If
                Next
                Filewrite.WriteLine(StrDup(79, "="))
                sqlstring = "Total :" & Space(19) & Space(12 - Len(Trim(Mid(Format(totAmount, "0.00"), 1, 12)))) & Format(totAmount, "0.00")
                sqlstring = sqlstring & Space(12 - Len(Trim(CStr(Format(totTax, "0.00"))))) & Format(totTax, "0.00")
                sqlstring = sqlstring & Space(14 - Len(Trim(CStr(Format(gtotal, "0.00"))))) & Format(gtotal, "0.00")
                Filewrite.WriteLine(sqlstring)
                Filewrite.WriteLine(StrDup(79, "="))
                Filewrite.WriteLine("Total Document(S)    : " & TotalDoc)
                Filewrite.WriteLine(StrDup(79, "="))
                Filewrite.Write(Chr(12))
                Filewrite.Close()
                If gPrint = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile1(VFilePath)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid Billno :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        Finally
        End Try
    End Function
    Private Function PrintHeader(ByVal HEADING As String, ByVal fDATE As Date, ByVal tDate As Date, ByVal pageno As Integer)
        Dim I As Integer
        Dim sstring As String
        Try
            '''*********************************************** PRINT REPORTS HEADING  *********************************'''
            Filewrite.Write(Chr(18) & Chr(27) + "E" & Chr(27) + "F")
            Filewrite.WriteLine("{0,23}{1,20}{2,11}{3,25}", "", gUsername, " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            ''Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HEADING), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)

            ''Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HEADING)), "-"), 1, 30))
            Filewrite.Write("{0,-30}{1,-26}", Mid(Address2, 1, 30), " ")
            Filewrite.Write("{0," & Len(Trim(HEADING)) & "}", Mid(Trim(HEADING), 1, Len(Trim(HEADING))))
            Filewrite.WriteLine("{0,-25}{1,-24}", "", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)



            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            Filewrite.WriteLine("{0,-30}{1,-30}", "From : " & Format(mskFromdate.Value, "MMM dd,yyyy"), "To : " & Format(mskTodate.Value, "MMM dd,yyyy"))
            Filewrite.Write(Chr(18))
            Filewrite.WriteLine(StrDup(79, "="))
            sstring = "POSLOCATION                    BILLAMOUNT         TAXAMOUNT      TOTALAMOUNT"
            Filewrite.WriteLine(sstring)
            Filewrite.WriteLine(StrDup(79, "="))

            '''*********************************************** COMPLETE PRINT REPORTS HEADING  *********************************'''
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Function PrintHeader_Stax(ByVal HEADING As String, ByVal fDATE As Date, ByVal tDate As Date, ByVal pageno As Integer)
        Dim I As Integer
        Dim sstring As String
        Try
            '''*********************************************** PRINT REPORTS HEADING  *********************************'''
            Filewrite.Write(Chr(18) & Chr(27) + "E" & Chr(27) + "F")
            Filewrite.WriteLine("{0,23}{1,20}{2,11}{3,25}", "", gUsername, " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HEADING), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HEADING)), "-"), 1, 30))
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            Filewrite.WriteLine("{0,-30}{1,-30}", "From : " & Format(mskFromdate.Value, "MMM dd,yyyy"), "To : " & Format(mskTodate.Value, "MMM dd,yyyy"))
            Filewrite.Write(Chr(18))
            Filewrite.WriteLine(StrDup(79, "="))
            sstring = "BILLNO            BILLDATE     BILLAMOUNT   TAXAMOUNT   TOTALAMOUNT"
            Filewrite.WriteLine(sstring)
            Filewrite.WriteLine(StrDup(79, "="))

            '''*********************************************** COMPLETE PRINT REPORTS HEADING  *********************************'''
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Sub frmVatServiceTaxreport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mskFromdate.Value = Format(Now, "dd-MMM-yyyy")
        mskTodate.Value = Format(Now, "dd-MMM-yyyy")

        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CANTEEN"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))

        FILLTAXTYPE()
        'FillItems()

        FillGroup()
        FillCATEGORY()
        FILLSERVER()
        FillPOSLocation()
        FillPaymentmode()
        FillMembername()

    End Sub
    Private Sub FillItems()
        Dim ssql As String
        Dim I As Integer
        ssql = " SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
        ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE"
        ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
        ssql = ssql & " INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE IN (SELECT MAX(STARTINGDATE) FROM RATEMASTER) AND ISNULL(R.ENDINGDATE,'') = ''"
        ssql = ssql & " GROUP BY I.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,I.GROUPCODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,P.POS,R.STARTINGDATE  "
        ssql = ssql & " ORDER BY ITEMDESC"
        gconnection.getDataSet(ssql, "ITEMMASTER")
        If gdataset.Tables("ITEMMASTER").Rows.Count - 1 >= 0 Then
            For I = 0 To gdataset.Tables("ITEMMASTER").Rows.Count - 1
                With gdataset.Tables("ITEMMASTER").Rows(I)
                    chklist_Membername.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                End With
            Next I
        End If

    End Sub
    Private Sub FillMembername()
        Dim i As Integer
        Dim str, type As String
        chklist_Membername.Items.Clear()
        If membertype.CheckedItems.Count <> 0 Then
            str = "( "
            For i = 0 To membertype.CheckedItems.Count - 1
                type = membertype.CheckedItems(i)
                str = str & " '" & type & "', "
                'HNAME = HNAME & " " & Trim(Type(0))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
        Else
            str = "('')"
        End If
        SQLSTRING = "SELECT DISTINCT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME FROM  viewmember_room  "
        SQLSTRING = SQLSTRING & "  WHERE type in " & str & "  and mcode in(select mcode from bill_hdr union all select cast(isnull(roomno,0) as varchar(20)) from bill_hdr where isnull(roomno,0)<>0 )--and ISNULL(MEMBERTYPECODE,'') <> 'EM' AND ISNULL(Freeze,'') <> 'Y'  "
        SQLSTRING = SQLSTRING & "order by mcode"
        gconnection.getDataSet(SQLSTRING, "MemberMaster")
        If gdataset.Tables("MemberMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("MemberMaster").Rows.Count - 1
                With gdataset.Tables("MemberMaster").Rows(i)
                    chklist_Membername.Items.Add(Trim(.Item("Mcode") & "-->" & .Item("Mname")))
                End With
            Next i
        End If
        'SQLSTRING = "SELECT ROOMNO,ROOMTYPECODE FROM ROOMMASTER"
        'gconnection.getDataSet(SQLSTRING, "ROOMNO")
        'If gdataset.Tables("ROOMNO").Rows.Count - 1 >= 0 Then
        '    For i = 0 To gdataset.Tables("ROOMNO").Rows.Count - 1
        '        With gdataset.Tables("ROOMNO").Rows(i)
        '            chklist_Membername.Items.Add(Trim(.Item("ROOMNO") & "-->" & .Item("ROOMTYPECODE")))
        '        End With
        '    Next i
        'End If
        chklist_Membername.Sorted = True
    End Sub
    Private Sub FillPOSLocation()
        Dim sqlstring As String
        Dim i As Integer
        chklist_POSlocation.Items.Clear()
        sqlstring = "SELECT DISTINCT poscode,posdesc FROM posmaster WHERE ISNULL(Freeze,'')<>'Y' "
        gconnection.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    'chklist_POSlocation.Items.Add(Trim(.Item("POSdesc")))
                    chklist_POSlocation.Items.Add(Trim(.Item("POSdesc")) & Space(100) & "-->" & Trim(.Item("POSCode")))
                End With
            Next i
        End If
    End Sub
    Private Sub FILLSERVER()
        Dim sqlstring As String
        Dim i As Integer
        CheckedListBox1.Items.Clear()
        sqlstring = "SELECT DISTINCT SERVERCODE,SERVERNAME FROM SERVERMASTER WHERE ISNULL(Freeze,'')<>'Y' "
        gconnection.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    'chklist_POSlocation.Items.Add(Trim(.Item("POSdesc")))
                    CheckedListBox1.Items.Add(Trim(.Item("SERVERNAME")) & Space(100) & "-->" & Trim(.Item("SERVERCODE")))
                End With
            Next i
        End If
    End Sub
    Private Sub FillPaymentmode()
        Dim sqlstring As String
        Dim i As Integer
        CHKLIST_PAYMENTMODE.Items.Clear()
        sqlstring = "select paymentcode from PaymentModeMaster where isnull(freeze,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    CHKLIST_PAYMENTMODE.Items.Add(Trim(.Item("paymentcode")))
                End With
            Next i
        End If
    End Sub
    Private Sub FillGroup()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        LstGroup.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT Groupcode,Groupdesc FROM GroupMaster "
        gconnection.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    LstGroup.Items.Add(Trim(.Item("GroupDESC")) & Space(100) & "-->" & Trim(.Item("GroupCode")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub
    Private Sub FillCATEGORY()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        Dim gconnection As String
        lstcategory.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT CATEGORY FROM ITEMMaster "
        vconn.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    lstcategory.Items.Add(Trim(.Item("CATEGORY")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub


    Private Sub FILLTAXTYPE()
        Dim sqlstring As String
        lstcategory.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT itemcode,itemdesc FROM ITEMMaster ORDER BY ITEMDESC"
        gconnection.getDataSet(sqlstring, "ITEMMaster")
        If gdataset.Tables("ITEMMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("ITEMMaster").Rows.Count - 1
                With gdataset.Tables("ITEMMaster").Rows(i)
                    lstcategory.Items.Add(Trim(.Item("itemcode")))
                    chklist_Type.Items.Add(Trim(.Item("itemcode")) & "-->" & Trim(.Item("itemdesc")))
                End With
            Next
        End If
        chklist_Type.Sorted = True

    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        gPrint = True
        If Chk_itemwise.Checked = True Then
            'itemwisesaleregister()
            itemwisesaleregister_cry()
        ElseIf CHKBILLDETAILS.Checked = True Then
            'itemwisesaleregister_BILL()
            itemwisesaleregister_BILL_crystal()
        ElseIf GROUPWISE.Checked = True Then
            itemwisesaleregister_Group_crystal()
            'itemwisesaleregister_Group()
        Else
            Printoperation_Vat_CRYSTAL()
            'Printoperation_Vat()
        End If

    End Sub
    Private Sub frmVatServiceTaxreport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F8 Then
            If CmdPrint.Enabled = True Then
                Call CmdPrint_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If CmdClear.Enabled = True Then
                Call CmdClear_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            If cmdexit.Enabled = True Then
                Call cmdexit_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If cmdexit.Enabled = True Then
                Call cmdexport_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            If cmdexport.Enabled = True Then
                Call cmdexport_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Chk_Taxtype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Taxtype.CheckedChanged
        Dim i As Integer
        If Chk_Taxtype.Checked = True Then
            For i = 0 To chklist_Type.Items.Count - 1
                chklist_Type.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Type.Items.Count - 1
                chklist_Type.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllGroup.Checked = True Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Dim I As Long
        For I = 0 To chklist_Type.Items.Count - 1
            chklist_Type.SetItemChecked(I, False)
        Next
        For I = 0 To LstGroup.Items.Count - 1
            LstGroup.SetItemChecked(I, False)
        Next I

        For I = 0 To chklist_POSlocation.Items.Count - 1
            chklist_POSlocation.SetItemChecked(I, False)
        Next
        For I = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
            CHKLIST_PAYMENTMODE.SetItemChecked(I, False)
        Next
        For I = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(I, False)
        Next
        For I = 0 To chklist_Membername.Items.Count - 1
            chklist_Membername.SetItemChecked(I, False)
        Next
        For I = 0 To lstcategory.Items.Count - 1
            lstcategory.SetItemChecked(I, False)
        Next
        For I = 0 To membertype.Items.Count - 1
            membertype.SetItemChecked(I, False)
        Next
        'For I = 0 To membertype.Items.Count - 1
        '    membertype.SetItemChecked(I, False)
        'Next
        Chk_itemwise.Checked = False
        CheckBox2.Checked = False
        Chk_SelectAllCategory.Checked = False
        Chk_Taxtype.Checked = False
        CHKBILLDETAILS.Checked = False
        Chk_SelectAllGroup.Checked = False
        Chk_PAYMENTMODE.Checked = False
        CheckBox1.Checked = False
        Chk_Membername.Checked = False
        CHK_DATEWISE.Checked = False
        GROUPWISE.Checked = False
        CHKBILLDETAILS.Checked = False
        Chk_POSlocation.Checked = False

        'lstcategory.Items.Clear()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CANTEEN"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))

        txt_mcode.Text = ""
        txt_Tomcode.Text = ""
        mskFromdate.Value = Format(Now, "dd-MMM-yyyy")
        mskTodate.Value = Format(Now, "dd-MMM-yyyy")
    End Sub
    Private Sub Chk_POSlocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_POSlocation.CheckedChanged
        Dim i As Integer

        If Chk_POSlocation.Checked = True Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim SSQL As String
        SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromdate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskTodate.Value, "dd-MMM-yyyy") & "'"
        gconnection.ExcuteStoreProcedure(SSQL)

        If CHKBILLDETAILS.Checked = True Then
            Call BILLDETAILSEXCEL()
        ElseIf Chk_itemwise.Checked = True Then
            Call ITEMWISEEXCEL()
        ElseIf CHK_DATEWISE.Checked = True Then
            Call DATEWISE()
        Else
            MessageBox.Show("PLEASE CHOOSE THE CHECK BOX", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
    Private Sub BILLDETAILSEXCEL()
        Dim i As Integer
        Dim exp As New exportexcel
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String

        SSQL = "SELECT isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC,QTY AS QTY,AMOUNT AS AMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,TAXAMOUNT,SER_CHG,PACKAMOUNT as servicetax,POSCODE,POSDesc,GROUPCODE,KOTDATE,TAXCODE,KOTDETAILS,RATE,mcode,PAYMENTMODE,"
        SSQL = SSQL & "MNAME,BILLAMOUNT AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"

        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND itemcode IN ("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                itemcode = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & "'" & itemcode(0) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ") "


        End If

        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        '====

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND SCODE IN ("
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                TYPE = Split(CheckedListBox1.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If

        '========

        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"

        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ") "
            End If
        End If
        SSQL = SSQL & "order by kotdetails,MTORDERNO,PREFIXMCODE,MSORDERNO,kotdate"

        gconnection.getDataSet(SSQL, "POSITS")
        If gdataset.Tables("POSITS").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SSQL, "ITEMWISESALES-DETAILS " & Format(mskFromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskTodate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub ITEMWISEEXCEL()
        Dim i As Integer
        Dim exp As New exportexcel
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String
        SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,SUM(PACKAMOUNT)AS PACKAMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,"
        SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,106) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  itemcode IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(0) & "', "
                HNAME = HNAME & " " & Trim(TYPE(1))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"

            End If
        End If

        SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,RATE,UOM,CATEGORY ORDER BY ITEMDESC "

        gconnection.getDataSet(SSQL, "POSITEMWIS")
        If gdataset.Tables("POSITEMWIS").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SSQL, "ITEMWISESALES " & Format(mskFromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskTodate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
    Private Sub DATEWISE()
        Dim i As Integer
        Dim exp As New exportexcel
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String
        SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,SUM(PACKAMOUNT)AS PACKAMOUNT,KOTDATE,ISNULL(CATEGORY,'') AS CATEGORY,"
        SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,106) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  itemcode IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(0) & "', "
                HNAME = HNAME & " " & Trim(TYPE(1))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        '========

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"

            End If
        End If

        SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,RATE,UOM,CATEGORY,KOTDATE ORDER BY KOTDATE,ITEMDESC "
        gconnection.getDataSet(SSQL, "POSI")
        If gdataset.Tables("POSI").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SSQL, "ITEMSALES-DATEWISE " & Format(mskFromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskTodate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub mskFromdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskFromdate.ValueChanged

    End Sub
    Private Sub mskFromdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskFromdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mskTodate.Focus()
        End If
    End Sub
    Private Sub mskTodate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskTodate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CmdView.Focus()
        End If
    End Sub


    Private Sub Chk_PAYMENTMODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_PAYMENTMODE.CheckedChanged
        Dim i As Integer
        If Chk_PAYMENTMODE.Checked = True Then
            For i = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
                CHKLIST_PAYMENTMODE.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
                CHKLIST_PAYMENTMODE.SetItemChecked(i, False)
            Next
        End If

    End Sub

    Private Sub LstGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstGroup.SelectedIndexChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If CheckBox1.Checked = True Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub Chk_Membername_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Membername.CheckedChanged
        Dim i As Integer

        If Chk_Membername.Checked = True Then
            For i = 0 To chklist_Membername.Items.Count - 1
                chklist_Membername.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Membername.Items.Count - 1
                chklist_Membername.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chklist_Membername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_Membername.SelectedIndexChanged

    End Sub

    Private Sub cmd_MemberCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_MemberCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME FROM MEMBERMASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "MCODE,MNAME"
        'vform.vFormatstring = "     MEMBER CODE    |         MEMBER NAME                         "
        vform.vCaption = "MEMBER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_mcode.Text = Trim(vform.keyfield & "")
            Call txt_mcode_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub cmd_MemberCodeHelp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_MemberCodeHelp1.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME FROM MEMBERMASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "MCODE,MNAME"
        'vform.vFormatstring = "     MEMBER CODE    |         MEMBER NAME                         "
        vform.vCaption = "MEMBER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Tomcode.Text = Trim(vform.keyfield & "")
            Call txt_mcode_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_mcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mcode.Validated
        Try
            If Trim(txt_mcode.Text) <> "" Then
                SQLSTRING = "SELECT MCODE,MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(txt_mcode.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "MEMBER")
                If gdataset.Tables("MEMBER").Rows.Count > 0 Then
                    txt_mcode.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("MCODE"))
                    'txt_mname.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("MNAME"))
                    txt_Tomcode.Focus()
                    'cmd_view.Focus()
                Else
                    txt_mcode.Text = ""
                    txt_mcode.Focus()
                End If
            Else
                txt_mcode.Text = ""
                txt_mcode.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub CHKLIST_PAYMENTMODE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKLIST_PAYMENTMODE.SelectedIndexChanged

    End Sub

    Private Sub itemwisesaleregister_cry()
        Dim i As Integer
        Dim SSQL, TYPE(), HNAME As String
        Dim posdesc(), groupcode(), itemcode(), sqlstring, membercode() As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim sqlstringCancel As String
        SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,SUM(PACKAMOUNT)AS PACKAMOUNT,SUM(SER_CHG)AS SER_CHG,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE,ISNULL(CATEGORY,'') AS CATEGORY,"
        SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        'SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT)AS TAXAMOUNT,ISNULL(CATEGORY,'') AS CATEGORY,"
        'SSQL = SSQL & "SUM(BILLAMOUNT) AS BILLAMOUNT FROM VIEWITEMWISESALESUMMARY_TAXWISE "
        SSQL = SSQL & " WHERE CAST(Convert(varchar(11),KOTDATE,106) AS DATETIME) BETWEEN "
        SSQL = SSQL & " '" & Format(mskFromdate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskTodate.Value, "yyyy-MM-dd") & "'"
        If chklist_Type.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and  itemcode IN("
            For i = 0 To chklist_Type.CheckedItems.Count - 1
                TYPE = Split(chklist_Type.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(0) & "', "
                HNAME = HNAME & " " & Trim(TYPE(1))
                'SSQL = SSQL & " '" & chklist_Type.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If


        '========



        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND POSCODE IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                TYPE = Split(chklist_POSlocation.CheckedItems(i), "-->")
                SSQL = SSQL & " '" & TYPE(1) & "', "

            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"

        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                SSQL = SSQL & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            SSQL = SSQL & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else
            If chklist_Membername.CheckedItems.Count <> 0 Then
                SSQL = SSQL & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    membercode = Split(chklist_Membername.CheckedItems(i), "-->")
                    SSQL = SSQL & "'" & membercode(0) & "', "
                Next
                SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
                SSQL = SSQL & ")"

            End If
        End If

        SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,RATE,UOM,CATEGORY ORDER BY ITEMDESC "


        'SSQL = SSQL & "GROUP BY ITEMCODE,ITEMDESC,UOM,CATEGORY "

        Dim r1 As New VatItemWise
        Dim Viewer As New ReportViwer
        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = " PERIOD FROM " & Format(mskFromdate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskTodate.Value, "dd/MM/yyyy") & ""


        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text17")
        TXTOBJ1.Text = "UserName : " & gUsername



        Viewer.ssql = SSQL
        Viewer.Report = r1
        Viewer.TableName = "VIEWITEMWISESALESUMMARY_TAXWISE"
        Viewer.Show()
        'Dim heading() As String = {"SALES REGISTER [ITEM WISE]", "ALL"}
        'Dim objSaleregistersummary As New rptSaleregistersummary_TAXTYPE
        'objSaleregistersummary.Detailsection(SSQL, heading, HNAME, mskFromdate.Value, mskTodate.Value)
    End Sub


    Private Sub Chk_SelectAllCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllCategory.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllCategory.Checked = True Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub chklist_Type_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_Type.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Type.Items.Count - 1
                chklist_Type.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To chklist_Type.Items.Count - 1
                chklist_Type.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub LstGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstGroup.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub chklist_POSlocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_POSlocation.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub CHKLIST_PAYMENTMODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHKLIST_PAYMENTMODE.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
                CHKLIST_PAYMENTMODE.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
                CHKLIST_PAYMENTMODE.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub CheckedListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckedListBox1.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub lstcategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstcategory.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub chklist_Membername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_Membername.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Membername.Items.Count - 1
                chklist_Membername.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To chklist_Membername.Items.Count - 1
                chklist_Membername.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub lstcategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstcategory.SelectedIndexChanged

    End Sub

    Private Sub Chk_itemwise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_itemwise.CheckedChanged
        If Chk_itemwise.Checked = True Then
            CHKBILLDETAILS.Checked = False
            CHK_DATEWISE.Checked = False
            'Else
            '    CHKBILLDETAILS.Checked = True
        End If
    End Sub

    Private Sub CHKBILLDETAILS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKBILLDETAILS.CheckedChanged
        If CHKBILLDETAILS.Checked = True Then
            Chk_itemwise.Checked = False
            CHK_DATEWISE.Checked = False
            'Else
            '    Chk_itemwise.Checked = True
        End If
    End Sub

    Private Sub txt_mcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mcode.TextChanged

    End Sub

    Private Sub membertype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles membertype.SelectedIndexChanged
        Call Me.FillMembername()
    End Sub

    Private Sub CHK_DATEWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_DATEWISE.CheckedChanged
        If CHK_DATEWISE.Checked = True Then
            Chk_itemwise.Checked = False
            CHKBILLDETAILS.Checked = False
            'Else
            '    Chk_itemwise.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        If CheckBox2.Checked = True Then
            For i = 0 To membertype.Items.Count - 1
                membertype.SetItemChecked(i, True)
                Call Me.FillMembername()
            Next i
        Else
            For i = 0 To membertype.Items.Count - 1
                membertype.SetItemChecked(i, False)
            Next i
        End If
    End Sub
End Class
