Public Class MEMBERSALESPOINTWISEREGISTER
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_Membername As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_POSlocation As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_POSlocation As System.Windows.Forms.CheckedListBox
    Friend WithEvents chklist_Membername As System.Windows.Forms.CheckedListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChKSELECTGROUP As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Groupcode As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CHKLIST_PAYMENTMODE As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_PAYMENTMODE As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Tomcode As System.Windows.Forms.TextBox
    Friend WithEvents cmd_MemberCodeHelp1 As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_mcode As System.Windows.Forms.TextBox
    Friend WithEvents CHK_SUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_DETAILS As System.Windows.Forms.CheckBox
    Friend WithEvents MEM_CHK_REG As System.Windows.Forms.CheckBox
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Ch_CONSUMPTION As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MEMBERSALESPOINTWISEREGISTER))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_Membername = New System.Windows.Forms.CheckBox()
        Me.Chk_POSlocation = New System.Windows.Forms.CheckBox()
        Me.chklist_POSlocation = New System.Windows.Forms.CheckedListBox()
        Me.chklist_Membername = New System.Windows.Forms.CheckedListBox()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.mskFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChKSELECTGROUP = New System.Windows.Forms.CheckBox()
        Me.Chk_Groupcode = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.Chk_PAYMENTMODE = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CHKLIST_PAYMENTMODE = New System.Windows.Forms.CheckedListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Tomcode = New System.Windows.Forms.TextBox()
        Me.cmd_MemberCodeHelp1 = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.txt_mcode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CHK_SUMMARY = New System.Windows.Forms.CheckBox()
        Me.CHK_DETAILS = New System.Windows.Forms.CheckBox()
        Me.MEM_CHK_REG = New System.Windows.Forms.CheckBox()
        Me.Ch_CONSUMPTION = New System.Windows.Forms.CheckBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(179, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(284, 16)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "MEMBER SALE-POINTWISE SALES REPORT"
        '
        'Chk_Membername
        '
        Me.Chk_Membername.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Membername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Membername.Location = New System.Drawing.Point(585, 139)
        Me.Chk_Membername.Name = "Chk_Membername"
        Me.Chk_Membername.Size = New System.Drawing.Size(141, 24)
        Me.Chk_Membername.TabIndex = 391
        Me.Chk_Membername.Text = "SELECT ALL"
        Me.Chk_Membername.UseVisualStyleBackColor = False
        '
        'Chk_POSlocation
        '
        Me.Chk_POSlocation.BackColor = System.Drawing.Color.Transparent
        Me.Chk_POSlocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_POSlocation.Location = New System.Drawing.Point(381, 138)
        Me.Chk_POSlocation.Name = "Chk_POSlocation"
        Me.Chk_POSlocation.Size = New System.Drawing.Size(132, 24)
        Me.Chk_POSlocation.TabIndex = 390
        Me.Chk_POSlocation.Text = "SELECT ALL"
        Me.Chk_POSlocation.UseVisualStyleBackColor = False
        '
        'chklist_POSlocation
        '
        Me.chklist_POSlocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_POSlocation.Location = New System.Drawing.Point(376, 187)
        Me.chklist_POSlocation.Name = "chklist_POSlocation"
        Me.chklist_POSlocation.Size = New System.Drawing.Size(208, 356)
        Me.chklist_POSlocation.TabIndex = 387
        '
        'chklist_Membername
        '
        Me.chklist_Membername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Membername.Location = New System.Drawing.Point(586, 186)
        Me.chklist_Membername.Name = "chklist_Membername"
        Me.chklist_Membername.Size = New System.Drawing.Size(269, 356)
        Me.chklist_Membername.TabIndex = 388
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Location = New System.Drawing.Point(9, 74)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 399
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
        Me.cmdexit.Location = New System.Drawing.Point(8, 292)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 398
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(40, 314)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(103, 64)
        Me.grp_SalebillChecklist.TabIndex = 397
        Me.grp_SalebillChecklist.TabStop = False
        '
        'lbl_Wait
        '
        Me.lbl_Wait.AutoSize = True
        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wait.Location = New System.Drawing.Point(360, 24)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 15)
        Me.lbl_Wait.TabIndex = 387
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 40)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(617, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Location = New System.Drawing.Point(203, 625)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(579, 49)
        Me.GroupBox3.TabIndex = 394
        Me.GroupBox3.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(403, 612)
        Me.mskFromDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(144, 21)
        Me.mskFromDate.TabIndex = 0
        Me.mskFromDate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(555, 617)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'mskToDate
        '
        Me.mskToDate.CustomFormat = "dd/MM/yyyy"
        Me.mskToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskToDate.Location = New System.Drawing.Point(632, 612)
        Me.mskToDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.Name = "mskToDate"
        Me.mskToDate.Size = New System.Drawing.Size(144, 21)
        Me.mskToDate.TabIndex = 1
        Me.mskToDate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(317, 614)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdPrint)
        Me.GroupBox4.Controls.Add(Me.cmdexport)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Location = New System.Drawing.Point(861, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(146, 428)
        Me.GroupBox4.TabIndex = 400
        Me.GroupBox4.TabStop = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdPrint.BackgroundImage = CType(resources.GetObject("CmdPrint.BackgroundImage"), System.Drawing.Image)
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Location = New System.Drawing.Point(47, 16)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 396
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Transparent
        Me.cmdexport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.cmdexport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.Location = New System.Drawing.Point(8, 217)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(131, 56)
        Me.cmdexport.TabIndex = 396
        Me.cmdexport.Text = " Export [F12]"
        Me.cmdexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Location = New System.Drawing.Point(9, 144)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 56)
        Me.CmdView.TabIndex = 395
        Me.CmdView.Text = "Report  [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(377, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 24)
        Me.Label2.TabIndex = 420
        Me.Label2.Text = "POS LOCATION :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(585, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 24)
        Me.Label4.TabIndex = 421
        Me.Label4.Text = "MEMBER NAME  :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(88, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(8, 24)
        Me.Label8.TabIndex = 427
        Me.Label8.Text = "GROUP NAME  :"
        Me.Label8.Visible = False
        '
        'ChKSELECTGROUP
        '
        Me.ChKSELECTGROUP.BackColor = System.Drawing.Color.Transparent
        Me.ChKSELECTGROUP.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChKSELECTGROUP.Location = New System.Drawing.Point(72, 24)
        Me.ChKSELECTGROUP.Name = "ChKSELECTGROUP"
        Me.ChKSELECTGROUP.Size = New System.Drawing.Size(8, 24)
        Me.ChKSELECTGROUP.TabIndex = 426
        Me.ChKSELECTGROUP.Text = "SELECT ALL"
        Me.ChKSELECTGROUP.UseVisualStyleBackColor = False
        Me.ChKSELECTGROUP.Visible = False
        '
        'Chk_Groupcode
        '
        Me.Chk_Groupcode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chk_Groupcode.Location = New System.Drawing.Point(40, 24)
        Me.Chk_Groupcode.Name = "Chk_Groupcode"
        Me.Chk_Groupcode.Size = New System.Drawing.Size(16, 25)
        Me.Chk_Groupcode.TabIndex = 425
        Me.Chk_Groupcode.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(144, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 433
        Me.Label9.Text = "CATEGORY"
        Me.Label9.Visible = False
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(136, 37)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllCategory.TabIndex = 431
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        Me.Chk_SelectAllCategory.Visible = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lstcategory.Location = New System.Drawing.Point(32, 64)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(16, 46)
        Me.lstcategory.TabIndex = 432
        Me.lstcategory.Visible = False
        '
        'Chk_PAYMENTMODE
        '
        Me.Chk_PAYMENTMODE.BackColor = System.Drawing.Color.Transparent
        Me.Chk_PAYMENTMODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_PAYMENTMODE.Location = New System.Drawing.Point(182, 138)
        Me.Chk_PAYMENTMODE.Name = "Chk_PAYMENTMODE"
        Me.Chk_PAYMENTMODE.Size = New System.Drawing.Size(184, 24)
        Me.Chk_PAYMENTMODE.TabIndex = 439
        Me.Chk_PAYMENTMODE.Text = "SELECT ALL"
        Me.Chk_PAYMENTMODE.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(181, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 24)
        Me.Label10.TabIndex = 438
        Me.Label10.Text = "PAYMENTMODE:"
        '
        'CHKLIST_PAYMENTMODE
        '
        Me.CHKLIST_PAYMENTMODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLIST_PAYMENTMODE.Location = New System.Drawing.Point(180, 185)
        Me.CHKLIST_PAYMENTMODE.Name = "CHKLIST_PAYMENTMODE"
        Me.CHKLIST_PAYMENTMODE.Size = New System.Drawing.Size(192, 356)
        Me.CHKLIST_PAYMENTMODE.TabIndex = 437
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(593, 566)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 24)
        Me.Label11.TabIndex = 597
        Me.Label11.Text = "MCODE TO   :"
        '
        'txt_Tomcode
        '
        Me.txt_Tomcode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tomcode.Location = New System.Drawing.Point(690, 566)
        Me.txt_Tomcode.Name = "txt_Tomcode"
        Me.txt_Tomcode.Size = New System.Drawing.Size(120, 21)
        Me.txt_Tomcode.TabIndex = 595
        '
        'cmd_MemberCodeHelp1
        '
        Me.cmd_MemberCodeHelp1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmd_MemberCodeHelp1.Location = New System.Drawing.Point(813, 565)
        Me.cmd_MemberCodeHelp1.Name = "cmd_MemberCodeHelp1"
        Me.cmd_MemberCodeHelp1.Size = New System.Drawing.Size(24, 24)
        Me.cmd_MemberCodeHelp1.TabIndex = 596
        Me.cmd_MemberCodeHelp1.UseVisualStyleBackColor = False
        '
        'cmd_MemberCodeHelp
        '
        Me.cmd_MemberCodeHelp.BackColor = System.Drawing.Color.DimGray
        Me.cmd_MemberCodeHelp.Location = New System.Drawing.Point(556, 565)
        Me.cmd_MemberCodeHelp.Name = "cmd_MemberCodeHelp"
        Me.cmd_MemberCodeHelp.Size = New System.Drawing.Size(24, 24)
        Me.cmd_MemberCodeHelp.TabIndex = 594
        Me.cmd_MemberCodeHelp.UseVisualStyleBackColor = False
        '
        'txt_mcode
        '
        Me.txt_mcode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mcode.Location = New System.Drawing.Point(440, 566)
        Me.txt_mcode.Name = "txt_mcode"
        Me.txt_mcode.Size = New System.Drawing.Size(112, 21)
        Me.txt_mcode.TabIndex = 593
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(328, 566)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 24)
        Me.Label12.TabIndex = 592
        Me.Label12.Text = "MCODE FROM :"
        '
        'CHK_SUMMARY
        '
        Me.CHK_SUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHK_SUMMARY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_SUMMARY.Location = New System.Drawing.Point(189, 552)
        Me.CHK_SUMMARY.Name = "CHK_SUMMARY"
        Me.CHK_SUMMARY.Size = New System.Drawing.Size(108, 24)
        Me.CHK_SUMMARY.TabIndex = 598
        Me.CHK_SUMMARY.Text = "SUMMARY"
        Me.CHK_SUMMARY.UseVisualStyleBackColor = False
        '
        'CHK_DETAILS
        '
        Me.CHK_DETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DETAILS.Font = New System.Drawing.Font("Verdana", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DETAILS.Location = New System.Drawing.Point(176, 568)
        Me.CHK_DETAILS.Name = "CHK_DETAILS"
        Me.CHK_DETAILS.Size = New System.Drawing.Size(8, 8)
        Me.CHK_DETAILS.TabIndex = 599
        Me.CHK_DETAILS.Text = "DETAILS"
        Me.CHK_DETAILS.UseVisualStyleBackColor = False
        Me.CHK_DETAILS.Visible = False
        '
        'MEM_CHK_REG
        '
        Me.MEM_CHK_REG.BackColor = System.Drawing.Color.Transparent
        Me.MEM_CHK_REG.Font = New System.Drawing.Font("Verdana", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEM_CHK_REG.Location = New System.Drawing.Point(850, 626)
        Me.MEM_CHK_REG.Name = "MEM_CHK_REG"
        Me.MEM_CHK_REG.Size = New System.Drawing.Size(168, 32)
        Me.MEM_CHK_REG.TabIndex = 600
        Me.MEM_CHK_REG.Text = "DETAILS"
        Me.MEM_CHK_REG.UseVisualStyleBackColor = False
        Me.MEM_CHK_REG.Visible = False
        '
        'Ch_CONSUMPTION
        '
        Me.Ch_CONSUMPTION.BackColor = System.Drawing.Color.Transparent
        Me.Ch_CONSUMPTION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ch_CONSUMPTION.Location = New System.Drawing.Point(189, 592)
        Me.Ch_CONSUMPTION.Name = "Ch_CONSUMPTION"
        Me.Ch_CONSUMPTION.Size = New System.Drawing.Size(122, 24)
        Me.Ch_CONSUMPTION.TabIndex = 601
        Me.Ch_CONSUMPTION.Text = "CONSUMPTION"
        Me.Ch_CONSUMPTION.UseVisualStyleBackColor = False
        '
        'MEMBERSALESPOINTWISEREGISTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1014, 692)
        Me.Controls.Add(Me.mskToDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mskFromDate)
        Me.Controls.Add(Me.Ch_CONSUMPTION)
        Me.Controls.Add(Me.MEM_CHK_REG)
        Me.Controls.Add(Me.CHK_DETAILS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CHK_SUMMARY)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_Tomcode)
        Me.Controls.Add(Me.txt_mcode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmd_MemberCodeHelp1)
        Me.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Chk_PAYMENTMODE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CHKLIST_PAYMENTMODE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ChKSELECTGROUP)
        Me.Controls.Add(Me.Chk_Groupcode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_Membername)
        Me.Controls.Add(Me.Chk_POSlocation)
        Me.Controls.Add(Me.chklist_POSlocation)
        Me.Controls.Add(Me.chklist_Membername)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "MEMBERSALESPOINTWISEREGISTER"
        Me.Text = "CREDIT SALE REGISTER-GROUPWISE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        chklist_POSlocation.Items.Clear()
        chklist_Membername.Items.Clear()
        Chk_Groupcode.Items.Clear()
        grp_SalebillChecklist.Top = 1000
        Chk_POSlocation.Checked = False
        Chk_Membername.Checked = False
        Chk_PAYMENTMODE.Checked = False
        CHKLIST_PAYMENTMODE.Items.Clear()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CATERING"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))

        Call FillPOSLocation()
        Call FillMembername()
        Call FillGroupname()
        Call FillPaymentmode()
        FillCATEGORY()

        txt_mcode.Text = ""
        txt_Tomcode.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    '''******************************  To fill POS details from POSMaster  *******************************'''
    Private Sub FillPOSLocation()
        Dim i As Integer
        chklist_POSlocation.Items.Clear()
        sqlstring = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER ORDER BY POSDESC "
        vconn.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    chklist_POSlocation.Items.Add(Trim(.Item("POSdesc")))
                End With
            Next i
        End If
        chklist_POSlocation.Sorted = True
    End Sub
    '''*****************************  To fill Server details from ServerMaster  **************************'''
    Private Sub FillMembername()
        Dim i As Integer
        chklist_Membername.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(K.MCODE,'') AS MCODE,ISNULL(m.MNAME,'') AS MNAME FROM KOT_DET AS K left outer JOIN viewmember AS M ON "
        sqlstring = sqlstring & " M.MCODE = K.MCODE   "
        'sqlstring = sqlstring & "select distinct cast(isnull(roomno,0) as varchar(20))as mcode ,isnull(guest,'') as mname from bill_hdr where isnull(roomno,0)<>0"
        'sqlstring = sqlstring & " union all SELECT DISTINCT ISNULL(K.MCODE,'') AS MCODE,ISNULL(M.MNAME,'') AS MNAME FROM KOT_DET AS K INNER JOIN membermaster AS M ON "
        'sqlstring = sqlstring & " M.MCODE = K.MCODE  and k.mcode not in(select mcode from viewmember ) "
        'sqlstring = " select ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME from viewmember_room"
        'sqlstring = sqlstring & " union all select "
        vconn.getDataSet(sqlstring, "MemberMaster")
        If gdataset.Tables("MemberMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("MemberMaster").Rows.Count - 1
                With gdataset.Tables("MemberMaster").Rows(i)
                    chklist_Membername.Items.Add(Trim(.Item("MCODE") & "->" & .Item("MNAME")))
                End With
            Next i
        End If
        'sqlstring = "SELECT ROOMNO,ROOMTYPECODE FROM ROOMMASTER"
        'vconn.getDataSet(sqlstring, "ROOMNO")
        'If gdataset.Tables("ROOMNO").Rows.Count - 1 >= 0 Then
        '    For i = 0 To gdataset.Tables("ROOMNO").Rows.Count - 1
        '        With gdataset.Tables("ROOMNO").Rows(i)
        '            chklist_Membername.Items.Add(Trim(.Item("ROOMNO") & "->" & .Item("ROOMTYPECODE")))
        '        End With
        '    Next i
        'End If
        chklist_Membername.Sorted = True
    End Sub
    Private Sub FillGroupname()
        Dim i As Integer
        Chk_Groupcode.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(M.GROUPCODE,'') AS SCODE,ISNULL(M.GROUPDESC,'') AS SNAME FROM GROUPMASTER M WHERE ISNULL(FREEZE,'')<>'Y'"
        vconn.getDataSet(sqlstring, "MemberMaster")
        If gdataset.Tables("MemberMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("MemberMaster").Rows.Count - 1
                With gdataset.Tables("MemberMaster").Rows(i)
                    Chk_Groupcode.Items.Add(Trim(.Item("Scode") & "->" & .Item("Sname")))
                End With
            Next i
        End If
        Chk_Groupcode.Sorted = True
    End Sub
    Private Sub txt_mcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mcode.Validated
        Try
            If Trim(txt_mcode.Text) <> "" Then
                sqlstring = "SELECT MCODE,MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(txt_mcode.Text) & "'"
                vconn.getDataSet(sqlstring, "MEMBER")
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
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click

        If chklist_POSlocation.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the PaymentMode(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If chklist_Membername.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the MemberName(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub

        Dim SSQL As String
        SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
        gconnection.ExcuteStoreProcedure(SSQL)

        'If chklist_POSlocation.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        ''If chklist_Membername.CheckedItems.Count = 0 Then
        ''    MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''    Exit Sub
        'End If
        'If Chk_Groupcode.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the GROUP NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        'If chkdatevalidate = False Then Exit Sub
        'gPrint = False
        'grp_SalebillChecklist.Top = 552
        'grp_SalebillChecklist.Left = 200
        'Me.ProgressBar1.Value = 2
        'Me.Timer1.Interval = 30
        'Me.Timer1.Enabled = True
        If MEM_CHK_REG.Checked = True Then
            Call viewCreditSaleregister_SUM_CRYSTAL()
        ElseIf CHK_DETAILS.Checked = True Then
            'Call viewCreditSaleregister_REG_CRYSTAL()
            '''''''''''''FINAL POS EXE 
        ElseIf CHK_SUMMARY.Checked = True Then
            'SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            'gconnection.ExcuteStoreProcedure(SSQL)
            Call viewCreditSaleregister_REG_CRYSTAL1()
            'Call viewCreditSaleregister_CRYSTAL()
        ElseIf Ch_CONSUMPTION.Checked = True Then
            'SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            'gconnection.ExcuteStoreProcedure(SSQL)
            Call view_memberwiseconsumption()
            'ElseIf CHK_SUMMARY.Checked = False Then


        End If
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        gPrint = True
        Dim SSQL As String
        SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
        gconnection.ExcuteStoreProcedure(SSQL)

        If MEM_CHK_REG.Checked = True Then
            Call viewCreditSaleregister_SUM_CRYSTAL()
        ElseIf CHK_DETAILS.Checked = True Then
            'Call viewCreditSaleregister_REG_CRYSTAL()

        ElseIf CHK_SUMMARY.Checked = True Then
            Call viewCreditSaleregister_REG_CRYSTAL1()
            'Call viewCreditSaleregister_CRYSTAL()
        ElseIf Ch_CONSUMPTION.Checked = True Then
            Call view_memberwiseconsumption()
            'ElseIf CHK_SUMMARY.Checked = False Then
        End If
    End Sub
    Private Sub FillPaymentmode()
        Dim sqlstring As String
        Dim i As Integer
        CHKLIST_PAYMENTMODE.Items.Clear()
        sqlstring = "select paymentcode from PaymentModeMaster where isnull(freeze,'')<>'Y'"
        vconn.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    CHKLIST_PAYMENTMODE.Items.Add(Trim(.Item("paymentcode")))
                End With
            Next i
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub frmCreditSalesregister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillPOSLocation()
        Call FillMembername()
        Call FillGroupname()
        FillPaymentmode()
        lstcategory.Items.Clear()
        FillCATEGORY()
        mskFromDate.Value = Now
        mskToDate.Value = Now
        grp_SalebillChecklist.Top = 1000
        If gUserCategory <> "S" Then
            Call GetRights()
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
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
        '    Me.ProgressBar1.Value += 1
        '    Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        'Else
        '    Me.Timer1.Enabled = False
        '    Me.ProgressBar1.Value = 0
        '    Me.grp_SalebillChecklist.Top = 1000
        'Call viewCreditSaleregister()

        'If MEM_CHK_REG.Checked = True Then
        '    Call viewCreditSaleregister_SUM_CRYSTAL()
        'ElseIf CHK_DETAILS.Checked = True Then
        '    Call viewCreditSaleregister_REG_CRYSTAL()
        'ElseIf CHK_SUMMARY.Checked = True Then
        '    Call viewCreditSaleregister_CRYSTAL()
        'ElseIf Ch_CONSUMPTION.Checked = True Then
        '    Call view_memberwiseconsumption()
        '    'ElseIf CHK_SUMMARY.Checked = False Then


        'End If


    End Sub
    Private Sub view_memberwiseconsumption()


        Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
        Dim i As Integer
        Dim SQLSTRING2 As String
        'sqlstring = " SELECT MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,MNAME,BILLDETAILS,kotDATE,KOTDETAILS,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SERVICELOCATIONDESC,TABLENO,CATEGORY,SUBSTRING(SNAME,1,10) AS SNAME,ISNULL(ADDUSERID,'') AS ADDUSERID FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        sqlstring = " SELECT * from memberconsumption where"

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            sqlstring = sqlstring & "  MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else


            If chklist_Membername.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                    sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND POSDESC IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR,KOTDATE,106 ) AS DATETIME)BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"

        'sqlstring = sqlstring & " GROUP BY MTORDERNO,PREFIXMCODE,MSORDERNO,KOTDETAILS,KOTDATE,BILLDETAILS,SERVICELOCATIONDESC,ITEMCODE,ITEMDESC,RATE,TABLENO,CATEGORY,SNAME,ADDUSERID"

        Dim r1 As New memberconsumption
        Dim Viewer As New ReportViwer


        Viewer.ssql = sqlstring
        Viewer.Report = r1
        Viewer.TableName = "memberconsumption"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text3")
        TXTOBJ16.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text8")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text5")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        Viewer.Show()
    End Sub
    'Public Sub viewCreditSaleregister_CRYSTAL()
    '    Try
    '        Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
    '        Dim i As Integer
    '        Dim SQLSTRING2 As String
    '        'sqlstring = " SELECT MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,SUBSTRING(MNAME,1,12) AS MNAME,ISNULL(BILLDETAILS,'') AS BILLDETAILS,ISNULL(KOTDETAILS,'') AS kotdetails,KOTDATE,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SUBSTRING(SNAME,1,10)AS SNAME,TABLENO,ADDUSERID,POSCODE,POSDESC FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE"
    '        sqlstring = " SELECT * FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE WHERE"

    '        If chklist_POSlocation.CheckedItems.Count <> 0 Then
    '            sqlstring = sqlstring & " SERVICELOCATIONDESC IN ("
    '            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
    '                sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
    '            Next
    '            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '            sqlstring = sqlstring & ")"
    '        Else
    '            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        End If
    '        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
    '            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
    '            HNAME = "("

    '            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
    '                sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
    '                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
    '            Next
    '            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '            sqlstring = sqlstring & ")"
    '            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
    '            HNAME = HNAME & ")"

    '        End If
    '        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
    '            sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
    '        Else

    '            If chklist_Membername.CheckedItems.Count <> 0 Then
    '                sqlstring = sqlstring & " AND MCODE IN ("
    '                For i = 0 To chklist_Membername.CheckedItems.Count - 1
    '                    MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
    '                    sqlstring = sqlstring & "'" & MemberCode(0) & "', "
    '                Next
    '                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '                sqlstring = sqlstring & ")"
    '            Else
    '                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            End If
    '        End If
    '        If Chk_Groupcode.CheckedItems.Count <> 0 Then
    '            sqlstring = sqlstring & " AND GROUPCODE IN ("
    '            For i = 0 To Chk_Groupcode.CheckedItems.Count - 1
    '                GRPCODE = Split(Chk_Groupcode.CheckedItems(i), "->")
    '                sqlstring = sqlstring & "'" & GRPCODE(0) & "', "
    '            Next
    '            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '            sqlstring = sqlstring & ")"
    '        End If

    '        If lstcategory.CheckedItems.Count <> 0 Then
    '            sqlstring = sqlstring & " and CATEGORY in ("
    '            For i = 0 To lstcategory.CheckedItems.Count - 1
    '                sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
    '            Next
    '            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '            sqlstring = sqlstring & ")"
    '        End If

    '        sqlstring = sqlstring & " AND kotDATE BETWEEN '"
    '        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
    '        'BILLDATE,ITEMCODE,ITEMNAME,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SUBSTRING(SERVERNAME,1,10)AS SERVERNAME,TABLENO,ADDUSERID
    '        'sqlstring = sqlstring & " GROUP BY MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,MNAME,BILLDETAILS,kotdetails,kotDATE,ITEMCODE,ITEMDESC,RATE,SNAME,TABLENO,ADDUSERID,servicelocationdesc,POSCODE,POSDESC"
    '        'sqlstring = sqlstring & " ORDER BY MTORDERNO,PREFIXMCODE,MSORDERNO,kotdetails,kotDATE,POSCODE,POSDESC"

    '        Dim r1 As New MemberSalesPointwisesalereg
    '        Dim Viewer As New ReportViwer
    '        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
    '        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
    '        TXTOBJ3.Text = " From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


    '        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
    '        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text17")
    '        TXTOBJ4.Text = HNAME

    '        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
    '        TXTOBJ5.Text = gCompanyname



    '        Viewer.ssql = sqlstring
    '        Viewer.Report = r1
    '        'Viewer.TableName = "MEMBESALESPOINTWISEREGISTER"
    '        Viewer.TableName = "VIEWITMWISESALE_ITEM_SALEPOINTWISE"
    '        Viewer.Show()

    'End Sub
    Private Sub mskFromDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskFromDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mskToDate.Focus()
        End If
    End Sub

    Private Sub mskToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskToDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CmdView.Focus()
        End If
    End Sub
    Public Sub viewCreditSaleregister()
        Try
            Dim POSdesc(), MemberCode(), GRPCODE() As String
            Dim i As Integer
            Dim SQLSTRING2 As String
            sqlstring = " SELECT * FROM VIEWSALEREGISTERUSERWISE_MEM"

            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE POSDESC IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND PAYMENTMODE IN ("


                For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "

                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"

            End If
            If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
                sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
            Else

                If chklist_Membername.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND MCODE IN ("
                    For i = 0 To chklist_Membername.CheckedItems.Count - 1
                        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                End If
            End If
            If Chk_Groupcode.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND GROUPCODE IN ("
                For i = 0 To Chk_Groupcode.CheckedItems.Count - 1
                    GRPCODE = Split(Chk_Groupcode.CheckedItems(i), "->")
                    sqlstring = sqlstring & "'" & GRPCODE(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            End If

            sqlstring = sqlstring & " AND BILLDATE BETWEEN '"
            sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
            sqlstring = sqlstring & " ORDER BY MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLNO, BILLDATE"
            Dim heading() As String = {" CREDIT SALE REGISTER "}
            Dim Objcreditsaleregister As New CreditSaleRegister
            Objcreditsaleregister.Reportdetails(sqlstring, SQLSTRING2, heading, mskFromDate.Value, mskToDate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Sub viewCreditSaleregister_CRYSTAL()
        'Try
        Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
        Dim i As Integer
        Dim SQLSTRING2 As String
        'sqlstring = " SELECT MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,SUBSTRING(MNAME,1,12) AS MNAME,ISNULL(BILLDETAILS,'') AS BILLDETAILS,ISNULL(KOTDETAILS,'') AS kotdetails,KOTDATE,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SUBSTRING(SNAME,1,10)AS SNAME,TABLENO,ADDUSERID,POSCODE,POSDESC FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        sqlstring = " SELECT * FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE WHERE"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " SERVICELOCATIONDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"

        End If
        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else

            If chklist_Membername.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                    sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If Chk_Groupcode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND GROUPCODE IN ("
            For i = 0 To Chk_Groupcode.CheckedItems.Count - 1
                GRPCODE = Split(Chk_Groupcode.CheckedItems(i), "->")
                sqlstring = sqlstring & "'" & GRPCODE(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & " AND kotDATE BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        'BILLDATE,ITEMCODE,ITEMNAME,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SUBSTRING(SERVERNAME,1,10)AS SERVERNAME,TABLENO,ADDUSERID
        'sqlstring = sqlstring & " GROUP BY MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,MNAME,BILLDETAILS,kotdetails,kotDATE,ITEMCODE,ITEMDESC,RATE,SNAME,TABLENO,ADDUSERID,servicelocationdesc,POSCODE,POSDESC"
        'sqlstring = sqlstring & " ORDER BY MTORDERNO,PREFIXMCODE,MSORDERNO,kotdetails,kotDATE,POSCODE,POSDESC"
        Dim r1 As New MemberSalesPointwisesalereg
        Dim Viewer As New ReportViwer


        Viewer.ssql = sqlstring
        Viewer.Report = r1
        Viewer.TableName = "VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        '    Dim r1 As New MemberSalesPointwisesalereg
        '    Dim Viewer As New ReportViwer



        '    Viewer.ssql = sqlstring
        '    Viewer.Report = r1
        '    'Viewer.TableName = "MEMBESALESPOINTWISEREGISTER"
        'Viewer.TableName = "VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text11")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text20")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text19")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        Viewer.Show()
        'Dim heading() As String = {" CREDIT SALE REGISTER "}
        'Dim Objcreditsaleregister As New CreditSaleRegister
        'Objcreditsaleregister.Reportdetails(sqlstring, SQLSTRING2, heading, mskFromDate.Value, mskToDate.Value)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
        Exit Sub
    End Sub
    Public Sub viewCreditSaleregister_REG_CRYSTAL1()
        Try
            Dim MemberCode(), HNAME As String
            Dim i As Integer

           
            'sqlstring = " SELECT MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,MNAME,BILLDETAILS,kotDATE,KOTDETAILS,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SERVICELOCATIONDESC,TABLENO,CATEGORY,SUBSTRING(SNAME,1,10) AS SNAME,ISNULL(ADDUSERID,'') AS ADDUSERID FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE"
            sqlstring = " SELECT * from POSWISESALESUMMARY where"
            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  POSDESC IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND PAYMENTMODE IN ("
                HNAME = "("

                For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                    HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"

            Else
                MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
                Exit Sub
            End If
            If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
                sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
            Else

                If chklist_Membername.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND MCODE IN ("
                    For i = 0 To chklist_Membername.CheckedItems.Count - 1
                        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            'If Chk_Groupcode.CheckedItems.Count <> 0 Then
            '    sqlstring = sqlstring & " AND GROUPCODE IN ("
            '    For i = 0 To Chk_Groupcode.CheckedItems.Count - 1
            '        GRPCODE = Split(Chk_Groupcode.CheckedItems(i), "->")
            '        sqlstring = sqlstring & "'" & GRPCODE(0) & "', "
            '    Next
            '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            '    sqlstring = sqlstring & ")"
            'Else
            '    MessageBox.Show("Select the GROUP NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            If lstcategory.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            End If

            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),BILLDATE,106)AS DATETIME) BETWEEN '"
            sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
            sqlstring = sqlstring & " order BY BILLDATE,MCODE"
            'sqlstring = sqlstring & " GROUP BY MTORDERNO,PREFIXMCODE,MSORDERNO,KOTDETAILS,KOTDATE,BILLDETAILS,SERVICELOCATIONDESC,ITEMCODE,ITEMDESC,RATE,TABLENO,CATEGORY,SNAME,ADDUSERID"

            Dim r1 As New POSWISESALESUMMARY1
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ3.Text = " PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text17")
            TXTOBJ4.Text = HNAME

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text11")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject

            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ6.Text = "UserName : " & gUsername


            Viewer.ssql = sqlstring
            Viewer.Report = r1
            Viewer.TableName = "POSWISESALESUMMARY"
            Viewer.Show()
            'Dim heading() As String = {" CREDIT SALE REGISTER "}
            'Dim Objcreditsaleregister As New CreditSaleRegister
            'Objcreditsaleregister.Reportdetails(sqlstring, SQLSTRING2, heading, mskFromDate.Value, mskToDate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Public Sub viewCreditSaleregister_SUM_CRYSTAL()
        Try
            Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
            Dim i As Integer
            Dim SQLSTRING2 As String
            'sqlstring = " SELECT MTORDERNO,PREFIXMCODE,MSORDERNO,MCODE,MNAME,billDETAILS,kotDATE,kotdetails,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,SUBSTRING(SNAME,1,10) AS SNAME,ADDUSERID  FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE"
            sqlstring = " SELECT * FROM VIEWITMWISESALE_ITEM_SALEPOINTWISE WHERE"
            'sqlstring = " SELECT * FROM MEMBERWISESALESSUMVV WHERE"


            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " POSDESC IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND PAYMENTMODE IN ("
                HNAME = "("

                For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                    HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"

            End If
            If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
                sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
            Else

                If chklist_Membername.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND MCODE IN ("
                    For i = 0 To chklist_Membername.CheckedItems.Count - 1
                        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            'If Chk_Groupcode.CheckedItems.Count <> 0 Then
            '    sqlstring = sqlstring & " AND GROUPCODE IN ("
            '    For i = 0 To Chk_Groupcode.CheckedItems.Count - 1
            '        GRPCODE = Split(Chk_Groupcode.CheckedItems(i), "->")
            '        sqlstring = sqlstring & "'" & GRPCODE(0) & "', "
            '    Next
            '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            '    sqlstring = sqlstring & ")"
            'End If

            If lstcategory.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            End If

            sqlstring = sqlstring & " AND cast(convert(varchar(11),KOTDATE,106) as datetime) BETWEEN '"
            sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
            'sqlstring = sqlstring & " GROUP BY MTORDERNO,PREFIXMCODE,MSORDERNO,BILLDETAILS,KOTDATE,KOTDETAILS,ADDUSERID,SNAME ORDER BY MTORDERNO,PREFIXMCODE,MSORDERNO,KOTDATE, KOTDETAILS"

            Dim r1 As New Memberwisesalepointreg_summary
            Dim Viewer As New ReportViwer

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text17")
            TXTOBJ4.Text = HNAME

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text6")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")



            Viewer.ssql = sqlstring
            Viewer.Report = r1
            Viewer.TableName = "VIEWITMWISESALE_ITEM_SALEPOINTWISE"
            Viewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub


    Private Sub Chk_Membername_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Membername.CheckedChanged
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
    Private Sub Chk_POSlocation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_POSlocation.CheckedChanged
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

    Private Sub frmCreditSalesregister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            'For i = 0 To chklist_POSlocation.Items.Count - 1
            '    chklist_POSlocation.SetItemChecked(i, True)
            'Next i
            'Chk_POSlocation.Checked = True
            'For i = 0 To chklist_Membername.Items.Count - 1
            '    chklist_Membername.SetItemChecked(i, True)
            'Next i
            'Chk_Membername.Checked = True

            'For i = 0 To Chk_Groupcode.Items.Count - 1
            '    Chk_Groupcode.SetItemChecked(i, True)
            'Next i
            'ChKSELECTGROUP.Checked = True

            'For i = 0 To lstcategory.Items.Count - 1
            '    lstcategory.SetItemChecked(i, True)
            'Next i
            'Chk_SelectAllCategory.Checked = True

            'For i = 0 To CHKLIST_PAYMENTMODE.Items.Count - 1
            '    CHKLIST_PAYMENTMODE.SetItemChecked(i, True)
            'Next i
            'Chk_PAYMENTMODE.Checked = True



            'Me.mskFromDate.Focus()
            'Exit Sub
            'ElseIf e.KeyCode = Keys.F8 Then
            '    Call CmdPrint_Click(sender, e)
            '    Exit Sub
            'ElseIf e.KeyCode = Keys.F9 Then
            '    Call CmdView_Click(sender, e)
            '    Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            If CmdPrint.Enabled = True Then
                Call CmdPrint_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If CmdView.Enabled = True Then
                Call cmdexport_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.mskFromDate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.mskToDate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F7 Then
            Search = InputBox("ENTER TEXT", "SEARCH")
            If chklist_Membername.SelectedIndex = 0 Then
                Call Search_Item(chklist_Membername, Search)
            ElseIf chklist_POSlocation.SelectedIndex = 0 Then
                Call Search_Item(chklist_POSlocation, Search)
            End If
        End If
    End Sub
    Private Sub ChKSELECTGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKSELECTGROUP.CheckedChanged
        Dim i As Integer
        If ChKSELECTGROUP.Checked = True Then
            For i = 0 To Chk_Groupcode.Items.Count - 1
                Chk_Groupcode.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chk_Groupcode.Items.Count - 1
                Chk_Groupcode.SetItemChecked(i, False)
            Next
        End If
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

    Private Sub Chk_Groupcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_Groupcode.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To Chk_Groupcode.Items.Count - 1
                Chk_Groupcode.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To Chk_Groupcode.Items.Count - 1
                Chk_Groupcode.SetItemChecked(i, False)
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

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click

        Dim SSQL As String
        SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
        gconnection.ExcuteStoreProcedure(SSQL)

        'Dim _export As New EXPORT
        '_export.TABLENAME = "VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        'sqlstring = "select * from VIEWITMWISESALE_ITEM_SALEPOINTWISE"
        'Call _export.export_excel(sqlstring)
        '_export.Show()

        'SSQL = "EXEC POS_POSWISETAX '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
        'gconnection.ExcuteStoreProcedure(SSQL)

        If CHK_SUMMARY.Checked = True Then
            Call MEMBERWISESALESDETAILS()
        ElseIf Ch_CONSUMPTION.Checked = True Then
            Call MEMBERWISESALESCONSUMPTION()
        End If

    End Sub
    Private Sub MEMBERWISESALESDETAILS()
        Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
        Dim i As Integer
        Dim exp As New exportexcel
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * from POSWISESALESUMMARY where"
        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"

        Else
            MsgBox("Select the Paymentmode", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            sqlstring = sqlstring & " AND MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else

            If chklist_Membername.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                    sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        sqlstring = sqlstring & " order BY POSDESC,BILLDATE,MCODE"
        gconnection.getDataSet(sqlstring, "MEMBERWISESALESDETAILS")
        If gdataset.Tables("MEMBERWISESALESDETAILS").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "MEMBERWISESALES-DETAILS " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub MEMBERWISESALESCONSUMPTION()
        Dim POSdesc(), MemberCode(), GRPCODE(), HNAME As String
        Dim i As Integer
        Dim exp As New exportexcel
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * from kitchenwiseconsumption where"

        If Trim(txt_mcode.Text) <> "" And Trim(txt_Tomcode.Text) <> "" Then
            sqlstring = sqlstring & "  MCODE between '" & Trim(txt_mcode.Text) & "' and '" & Trim(txt_Tomcode.Text) & "'"
        Else


            If chklist_Membername.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  MCODE IN ("
                For i = 0 To chklist_Membername.CheckedItems.Count - 1
                    MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
                    sqlstring = sqlstring & "'" & MemberCode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the MEMBER NAME(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If chklist_POSlocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND POSDESC IN ("
                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            HNAME = "("

            For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & CHKLIST_PAYMENTMODE.CheckedItems(i) & "', "
                HNAME = HNAME & CHKLIST_PAYMENTMODE.CheckedItems(i) & ", "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR,KOTDATE,106 ) AS DATETIME)BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        sqlstring = sqlstring & " order BY KOTDATE,POSDESC,MCODE"
        gconnection.getDataSet(sqlstring, "MEMBERWISESALESCONSUMPTION")
        If gdataset.Tables("MEMBERWISESALESCONSUMPTION").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "MEMBERWISESALES-CONSUMPTION " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       

        Dim Viewer As New ReportViwer
        Dim r As New Crptviewcashsalesregisteruserwise
      
    End Sub

    Private Sub CHKLIST_PAYMENTMODE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKLIST_PAYMENTMODE.SelectedIndexChanged

    End Sub


    Private Sub CHK_SUMMARY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_SUMMARY.CheckedChanged
        If CHK_SUMMARY.Checked = True Then
            MEM_CHK_REG.Checked = False
            Ch_CONSUMPTION.Checked = False
        End If
    End Sub

    Private Sub Ch_CONSUMPTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch_CONSUMPTION.CheckedChanged
        If Ch_CONSUMPTION.Checked = True Then
            CHK_SUMMARY.Checked = False
            MEM_CHK_REG.Checked = False
        End If
    End Sub

    Private Sub MEM_CHK_REG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEM_CHK_REG.CheckedChanged
        If MEM_CHK_REG.Checked = True Then
            CHK_SUMMARY.Checked = False
            Ch_CONSUMPTION.Checked = False
        End If
    End Sub

    Private Sub chklist_POSlocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_POSlocation.SelectedIndexChanged

    End Sub
End Class
