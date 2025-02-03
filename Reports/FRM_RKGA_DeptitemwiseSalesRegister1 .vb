Imports System.Data.SqlClient
Public Class DeptitemwiseSalesRegister123
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
    Friend WithEvents LstPOS As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SelectAllPos As System.Windows.Forms.CheckBox
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chk_DEPARTMENT As System.Windows.Forms.CheckBox
    Friend WithEvents chkbox_group As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GP_DEPT_WISE As System.Windows.Forms.CheckBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents LstGroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_PAYMENT As System.Windows.Forms.CheckBox
    Friend WithEvents lstsubgroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SelectAllsubgroup As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_PEND As System.Windows.Forms.CheckBox
    Friend WithEvents CMD_EXPORT As System.Windows.Forms.Button
    Friend WithEvents CHK_DTSUM As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeptitemwiseSalesRegister123))
        Me.LstPOS = New System.Windows.Forms.CheckedListBox()
        Me.Chk_SelectAllPos = New System.Windows.Forms.CheckBox()
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
        Me.CMD_EXPORT = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chk_DEPARTMENT = New System.Windows.Forms.CheckBox()
        Me.chkbox_group = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllsubgroup = New System.Windows.Forms.CheckBox()
        Me.lstsubgroup = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GP_DEPT_WISE = New System.Windows.Forms.CheckBox()
        Me.LstGroup = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.CHK_PAYMENT = New System.Windows.Forms.CheckBox()
        Me.CHK_PEND = New System.Windows.Forms.CheckBox()
        Me.CHK_DTSUM = New System.Windows.Forms.CheckBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstPOS
        '
        Me.LstPOS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPOS.Location = New System.Drawing.Point(193, 168)
        Me.LstPOS.Name = "LstPOS"
        Me.LstPOS.Size = New System.Drawing.Size(212, 356)
        Me.LstPOS.TabIndex = 382
        '
        'Chk_SelectAllPos
        '
        Me.Chk_SelectAllPos.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPos.Location = New System.Drawing.Point(193, 120)
        Me.Chk_SelectAllPos.Name = "Chk_SelectAllPos"
        Me.Chk_SelectAllPos.Size = New System.Drawing.Size(160, 24)
        Me.Chk_SelectAllPos.TabIndex = 389
        Me.Chk_SelectAllPos.Text = "SELECT ALL"
        Me.Chk_SelectAllPos.UseVisualStyleBackColor = False
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(152, 1000)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(712, 64)
        Me.grp_SalebillChecklist.TabIndex = 393
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
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.mskFromDate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.mskToDate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(265, 585)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(514, 55)
        Me.GroupBox3.TabIndex = 390
        Me.GroupBox3.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(119, 18)
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
        Me.Label6.Location = New System.Drawing.Point(283, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "To Date :"
        '
        'mskToDate
        '
        Me.mskToDate.CustomFormat = "dd/MM/yyyy"
        Me.mskToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskToDate.Location = New System.Drawing.Point(348, 16)
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
        Me.Label7.Location = New System.Drawing.Point(30, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "From Date :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CMD_EXPORT)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Location = New System.Drawing.Point(859, 139)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(151, 379)
        Me.GroupBox4.TabIndex = 396
        Me.GroupBox4.TabStop = False
        '
        'CMD_EXPORT
        '
        Me.CMD_EXPORT.BackColor = System.Drawing.Color.White
        Me.CMD_EXPORT.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.CMD_EXPORT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMD_EXPORT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_EXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMD_EXPORT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_EXPORT.Location = New System.Drawing.Point(12, 180)
        Me.CMD_EXPORT.Name = "CMD_EXPORT"
        Me.CMD_EXPORT.Size = New System.Drawing.Size(131, 56)
        Me.CMD_EXPORT.TabIndex = 438
        Me.CMD_EXPORT.Text = "Export [F12]"
        Me.CMD_EXPORT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_EXPORT.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.White
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(12, 278)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 437
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.White
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(12, 19)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 396
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.White
        Me.CmdView.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(12, 101)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 56)
        Me.CmdView.TabIndex = 436
        Me.CmdView.Text = "Crystal [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.White
        Me.CmdPrint.BackgroundImage = CType(resources.GetObject("CmdPrint.BackgroundImage"), System.Drawing.Image)
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Location = New System.Drawing.Point(868, 111)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 436
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.White
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(880, 520)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 395
        Me.cmdexport.Text = " Export[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.Location = New System.Drawing.Point(185, 80)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(204, 16)
        Me.lbl_Heading.TabIndex = 398
        Me.lbl_Heading.Text = "GROUP WISE  SALE REGISTER"
        '
        'Timer1
        '
        '
        'chk_DEPARTMENT
        '
        Me.chk_DEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.chk_DEPARTMENT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_DEPARTMENT.Location = New System.Drawing.Point(205, 547)
        Me.chk_DEPARTMENT.Name = "chk_DEPARTMENT"
        Me.chk_DEPARTMENT.Size = New System.Drawing.Size(127, 24)
        Me.chk_DEPARTMENT.TabIndex = 424
        Me.chk_DEPARTMENT.Text = "LOCATION WISE"
        Me.chk_DEPARTMENT.UseVisualStyleBackColor = False
        Me.chk_DEPARTMENT.Visible = False
        '
        'chkbox_group
        '
        Me.chkbox_group.BackColor = System.Drawing.Color.Transparent
        Me.chkbox_group.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbox_group.Location = New System.Drawing.Point(904, 496)
        Me.chkbox_group.Name = "chkbox_group"
        Me.chkbox_group.Size = New System.Drawing.Size(80, 16)
        Me.chkbox_group.TabIndex = 425
        Me.chkbox_group.Text = "GROUP/LOCATION WISE"
        Me.chkbox_group.UseVisualStyleBackColor = False
        Me.chkbox_group.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(628, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 24)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "SUBGROUP DESC :"
        '
        'Chk_SelectAllsubgroup
        '
        Me.Chk_SelectAllsubgroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllsubgroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllsubgroup.Location = New System.Drawing.Point(632, 120)
        Me.Chk_SelectAllsubgroup.Name = "Chk_SelectAllsubgroup"
        Me.Chk_SelectAllsubgroup.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllsubgroup.TabIndex = 431
        Me.Chk_SelectAllsubgroup.Text = "SELECT ALL "
        Me.Chk_SelectAllsubgroup.UseVisualStyleBackColor = False
        '
        'lstsubgroup
        '
        Me.lstsubgroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstsubgroup.Location = New System.Drawing.Point(629, 169)
        Me.lstsubgroup.Name = "lstsubgroup"
        Me.lstsubgroup.Size = New System.Drawing.Size(215, 356)
        Me.lstsubgroup.TabIndex = 432
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(193, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 24)
        Me.Label2.TabIndex = 434
        Me.Label2.Text = "POS  LOCATIONS"
        '
        'GP_DEPT_WISE
        '
        Me.GP_DEPT_WISE.BackColor = System.Drawing.Color.Transparent
        Me.GP_DEPT_WISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GP_DEPT_WISE.Location = New System.Drawing.Point(523, 546)
        Me.GP_DEPT_WISE.Name = "GP_DEPT_WISE"
        Me.GP_DEPT_WISE.Size = New System.Drawing.Size(119, 24)
        Me.GP_DEPT_WISE.TabIndex = 435
        Me.GP_DEPT_WISE.Text = "GROUP WISE "
        Me.GP_DEPT_WISE.UseVisualStyleBackColor = False
        '
        'LstGroup
        '
        Me.LstGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstGroup.Location = New System.Drawing.Point(408, 168)
        Me.LstGroup.Name = "LstGroup"
        Me.LstGroup.Size = New System.Drawing.Size(213, 356)
        Me.LstGroup.TabIndex = 436
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(407, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(213, 24)
        Me.Label4.TabIndex = 437
        Me.Label4.Text = "GROUP DESCRIPTION :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(410, 126)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(144, 16)
        Me.Chk_SelectAllGroup.TabIndex = 438
        Me.Chk_SelectAllGroup.Text = "SELECT ALL "
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'CHK_PAYMENT
        '
        Me.CHK_PAYMENT.BackColor = System.Drawing.Color.Transparent
        Me.CHK_PAYMENT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_PAYMENT.Location = New System.Drawing.Point(872, 576)
        Me.CHK_PAYMENT.Name = "CHK_PAYMENT"
        Me.CHK_PAYMENT.Size = New System.Drawing.Size(160, 24)
        Me.CHK_PAYMENT.TabIndex = 439
        Me.CHK_PAYMENT.Text = "PAYMENT WISE"
        Me.CHK_PAYMENT.UseVisualStyleBackColor = False
        Me.CHK_PAYMENT.Visible = False
        '
        'CHK_PEND
        '
        Me.CHK_PEND.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_PEND.Location = New System.Drawing.Point(329, 547)
        Me.CHK_PEND.Name = "CHK_PEND"
        Me.CHK_PEND.Size = New System.Drawing.Size(190, 24)
        Me.CHK_PEND.TabIndex = 440
        Me.CHK_PEND.Text = "GROUP WISE WITH PENDING"
        Me.CHK_PEND.Visible = False
        '
        'CHK_DTSUM
        '
        Me.CHK_DTSUM.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DTSUM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DTSUM.Location = New System.Drawing.Point(681, 546)
        Me.CHK_DTSUM.Name = "CHK_DTSUM"
        Me.CHK_DTSUM.Size = New System.Drawing.Size(160, 24)
        Me.CHK_DTSUM.TabIndex = 442
        Me.CHK_DTSUM.Text = "DATE WISE SUMMARY"
        Me.CHK_DTSUM.UseVisualStyleBackColor = False
        Me.CHK_DTSUM.Visible = False
        '
        'DeptitemwiseSalesRegister123
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.Controls.Add(Me.CHK_DTSUM)
        Me.Controls.Add(Me.CHK_PEND)
        Me.Controls.Add(Me.CHK_PAYMENT)
        Me.Controls.Add(Me.Chk_SelectAllGroup)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LstGroup)
        Me.Controls.Add(Me.GP_DEPT_WISE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_SelectAllsubgroup)
        Me.Controls.Add(Me.lstsubgroup)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkbox_group)
        Me.Controls.Add(Me.chk_DEPARTMENT)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LstPOS)
        Me.Controls.Add(Me.Chk_SelectAllPos)
        Me.Controls.Add(Me.cmdexport)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DeptitemwiseSalesRegister123"
        Me.Text = "DaywiseSalesRegister"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Myconn As New SqlConnection
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub Reportsform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mskFromDate.Value = Format(CDate(Now), "dd-MM-yyyy")
        mskToDate.Value = Format(CDate(Now), "dd-MM-yyyy")
        grp_SalebillChecklist.Top = 1000
        Call FillPOS()
        FillGroup()
        lstsubgroup.Items.Clear()
        FillSUBGROUPCODE()
        'FillCATEGORY()
        'SSGRID.Visible = False
        'lstsubgroup.Items.Add(Trim("CATERING"))
        'lstsubgroup.Items.Add(Trim("BAR"))
        'lstsubgroup.Items.Add(Trim("FACILITY"))

    End Sub
    Private Sub FillGroup()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        LstGroup.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT Groupcode,Groupdesc FROM GroupMaster "
        vconn.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    LstGroup.Items.Add(Trim(.Item("GroupDESC")) & Space(100) & "-->" & Trim(.Item("GroupCode")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub
    'Private Sub FillCATEGORY()   '''***************************** To fill Group details from GroupMaster  *****************'''
    '    Dim sqlstring As String
    '    Dim gconnection As String
    '    lstcategory.Items.Clear()
    '    Dim i As Integer
    '    sqlstring = "SELECT DISTINCT CATEGORY FROM ITEMMaster "
    '    vconn.getDataSet(sqlstring, "GroupMaster")
    '    If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
    '        For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
    '            With gdataset.Tables("GroupMaster").Rows(i)
    '                lstcategory.Items.Add(Trim(.Item("CATEGORY")))
    '                'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
    '            End With
    '        Next
    '    End If
    'End Sub
    Private Sub FillSUBGROUPCODE()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        Dim gconnection As String
        lstsubgroup.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT subGROUPDESC  FROM SUBGROUPMASTER "
        vconn.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    lstsubgroup.Items.Add(Trim(.Item("subGROUPDESC")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub


    '''******************************  To fill POS details from POSMaster  *******************************'''
    Private Sub FillPOS()
        Dim i As Integer
        Dim sqlstring As String
        LstPOS.Items.Clear()
        sqlstring = "SELECT DISTINCT poscode,posdesc FROM posmaster WHERE ISNULL(Freeze,'')<>'Y'"
        vconn.getDataSet(sqlstring, "posmaster")
        If gdataset.Tables("posmaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("posmaster").Rows.Count - 1
                With gdataset.Tables("posmaster").Rows(i)
                    LstPOS.Items.Add(Trim(.Item("POSdesc")))
                End With
            Next i
            LstPOS.Sorted = True
        End If
    End Sub
    '''*****************************  To fill Server details from ServerMaster  **************************'''
    'Private Sub FillServer()
    '    'Dim i As Integer
    '    'Dim sqlstring As String
    '    'LstServer.Items.Clear()
    '    'sqlstring = "SELECT DISTINCT servercode, servername FROM servermaster WHERE ISNULL(Freeze,'')<>'Y'"
    '    'vconn.getDataSet(sqlstring, "servermaster")
    '    'If gdataset.Tables("servermaster").Rows.Count - 1 >= 0 Then
    '    '    For i = 0 To gdataset.Tables("servermaster").Rows.Count - 1
    '    '        With gdataset.Tables("servermaster").Rows(i)
    '    '            LstServer.Items.Add(Trim(.Item("ServerCode") & "->" & .Item("servername")))
    '    '        End With
    '    '    Next i
    '    '    LstServer.Sorted = True
    '    'End If
    'End Sub

    Private Sub CmdClear_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grp_SalebillChecklist.Top = 1000
        lstsubgroup.Items.Clear()
        'lstsubgroup.Items.Add(Trim("CANTEEN"))
        'lstsubgroup.Items.Add(Trim("BAR"))
        'lstsubgroup.Items.Add(Trim("FACILITY"))

        gPrint = False
        LstPOS.Items.Clear()
        Call FillPOS()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'grp_SalebillChecklist.Top = 560
        'grp_SalebillChecklist.Left = 152
        'Me.ProgressBar1.Value = 2
        'Me.Timer1.Interval = 100
        'Me.Timer1.Enabled = True

        If chk_DEPARTMENT.Checked = True Then
            Call Viewdaywisesaleregister_dept()
        ElseIf GP_DEPT_WISE.Checked = True Then
            Call Viewdaywisesaleregister_DEPT_GROUPWISE()
        ElseIf chkbox_group.Checked = True Then
            'Call Viewdaywisesaleregister()
            Call Viewdaywisesaleregister_GROUPWISE()
        End If
        'Call Viewdaywisesaleregister()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Function validatedate()
        ''''chkbool = False
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(Now.Today, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should less than Today Date", MsgBoxStyle.Information)
        ''''    mskFromDate.Text = ""
        ''''    mskFromDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") < Format(CDate("01-Apr-" & gFinancalyearStart), "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should  be in the Finacial Year", MsgBoxStyle.Information)
        ''''    mskFromDate.Text = ""
        ''''    mskFromDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(mskToDate.Value, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should be Less than To date", MsgBoxStyle.Information)
        ''''    Exit Function
        ''''End If
        ''''If Format(mskToDate.Value, "MM-dd-yyyy") > Format(Now.Today, "MM-dd-yyyy") Then
        ''''    MsgBox("To Date should less be than Today Date", MsgBoxStyle.Information)
        ''''    mskToDate.Text = ""
        ''''    mskToDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskToDate.Value, "MM-dd-yyyy") > Format("31-Mar-07", "MM-dd-yyyy") Then
        ''''    MsgBox("To Date should not be less than Finacial Year", MsgBoxStyle.Information)
        ''''    mskToDate.Text = ""
        ''''    mskToDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(mskToDate.Value, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should be Less than To date", MsgBoxStyle.Information)
        ''''    Exit Function
        ''''End If
        CmdView.Focus()
        chkbool = True
    End Function


    Private Sub Chk_SelectAllPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPos.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPos.Checked = True Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next i
        End If
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chk_DEPARTMENT.Checked = True Then
            Call Viewdaywisesaleregister_dept()
        Else
            Call Viewdaywisesaleregister_GROUPWISE()
        End If
      
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            If chk_DEPARTMENT.Checked = True Then
                Call Viewdaywisesaleregister_dept()
            ElseIf chkbox_group.Checked = True Then
                Call Viewdaywisesaleregister_GROUPWISE()
            Else
                Call Viewdaywisesaleregister_DEPT_GROUPWISE()
            End If
        End If
    End Sub
    Private Sub Viewdaywisesaleregister_dept()
        Try

            Dim i As Integer
            Call validatedate() ''--> Check Validation
            If chkbool = False Then Exit Sub
            SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,UOM,RATE,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT ,SUM(AMOUNT) AS AMOUNT,isnull(SCHARGE,0) AS SCHARGE,isnull(ACHARGE,0) AS ACHARGE ,isnull(PCHARGE,0) AS PCHARGE,isnull(RCHARGE,0)AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC "
            SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
            SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
            If LstPOS.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If lstsubgroup.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
                For i = 0 To lstsubgroup.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
            End If
            SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,TAXAMOUNT,CATEGORY,SCHARGE,ACHARGE,PCHARGE,RCHARGE ORDER BY POSDESC"

            Dim r1 As New deptItemWise
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
            TXTOBJ1.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


            Viewer.ssql = SQLSTRING
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
            Viewer.Show()
            'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
            'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
            'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
            'Dim total() As Integer = {2, 3, 4, 5, 6}
            'Dim DaySalesRegisterReport As New DaySalesRegisterReport
            'DaySalesRegisterReport.begin()
            '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Viewdaywisesaleregister_DEPT_GROUPWISE()

        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim Viewer As New ReportViwer
        Dim r1 As New GroupWiseDeptItem
        Dim i As Integer
        Call validatedate() ''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT ITEMCODE,ITEMDESC,ITEMTYPE,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,rate,UOM,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as PACKAMOUNT,SUM(AMOUNT) AS AMOUNT,SUM(AMT) AS AMT,SUM(isnull(ACHARGE,0)) AS ACHARGE ,SUM(isnull(PCHARGE,0)) AS PCHARGE,SUM(isnull(RCHARGE,0)) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC "
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY ITEMTYPE,itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,category ORDER BY GROUPDESC,itemdesc"
        Viewer.Report = r1

        SSQL2 = "SELECT GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY GROUPCODE,GROUPDESC ,ITEMTYPE"

        Call Viewer.GetDetails1(SQLSTRING, "VIEWITEMWISESALESUMMARY_JIC", r1)
        Call Viewer.GetDetails1(SSQL2, "VIEWDATEGROUPPAYMENT", r1)
        'Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"


        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text4")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text18")
        TXTOBJ4.Text = HNAME


        'Viewer.ssql = SQLSTRING

        Viewer.Show()
        'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
        'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
        'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
        'Dim total() As Integer = {2, 3, 4, 5, 6}
        'Dim DaySalesRegisterReport As New DaySalesRegisterReport
        'DaySalesRegisterReport.begin()
        '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub Viewdaywisesaleregister_GROUPWISE()
        Try
            Dim posdesc(), servercode() As String
            Dim i As Integer
            Call validatedate() '''--> Check Validation
            If chkbool = False Then Exit Sub
            SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,UOM,RATE,TAXAMOUNT,SUM(AMOUNT) AS AMOUNT FROM VIEWITEMWISESALESUMMARY_JIC "
            SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
            SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
            If LstPOS.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If lstsubgroup.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
                For i = 0 To lstsubgroup.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
            End If
            SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,TAXAMOUNT,GROUPCODE,GROUPDESC,category ORDER BY POSDESC"

            Dim r1 As New GroupWiseItem
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = " PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = "UserName : " & gUsername
            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


            Viewer.ssql = SQLSTRING
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
            Viewer.Show()
            'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
            'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
            'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
            'Dim total() As Integer = {2, 3, 4, 5, 6}
            'Dim DaySalesRegisterReport As New DaySalesRegisterReport
            'DaySalesRegisterReport.begin()
            '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Viewdaywisesaleregister()

        Dim posdesc(), servercode() As String
        Dim i As Integer
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        Dim sqlstring = "SELECT BH.BILLDATE,P.POSDESC,SUM(ISNULL(R.PURCAHSERATE,0)) AS PURCHASERATE,"
        sqlstring = sqlstring & " SUM(ISNULL(BH.BILLAMOUNT,0)) AS BILLAMOUNT,SUM(ISNULL(BH.TAXAMOUNT,0)) AS TAXAMOUNT, "
        sqlstring = sqlstring & " SUM(ISNULL(BH.TOTALAMOUNT,0)) AS TOTALAMOUNT,SUM(ISNULL(BH.TAXAMOUNT,0) + ISNULL(BH.TOTALAMOUNT,0)) AS TOTAL"
        sqlstring = sqlstring & " FROM BILL_HDR AS BH INNER JOIN KOT_DET AS KD ON BH.BILLDETAILS = KD.BILLDETAILS "
        sqlstring = sqlstring & " INNER JOIN POSMASTER AS P ON P.POSCODE = KD.POSCODE INNER JOIN RATEMASTER AS R ON R.ITEMCODE = KD.ITEMCODE "
        If LstPOS.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE P.POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        sqlstring = sqlstring & "AND BH.BILLDATE BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        sqlstring = sqlstring & " GROUP BY P.POSDESC,BH.BILLDATE ORDER BY P.POSDESC"
        Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
        Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
        Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
        Dim total() As Integer = {2, 3, 4, 5, 6}
        Dim DaySalesRegisterReport As New DaySalesRegisterReport
        'DaySalesRegisterReport.begin()
        '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub

    End Sub

    Private Sub Chk_SelectAllsubgroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllsubgroup.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllsubgroup.Checked = True Then
            For i = 0 To lstsubgroup.Items.Count - 1
                lstsubgroup.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To lstsubgroup.Items.Count - 1
                lstsubgroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub
    Private Sub LstPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPOS.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub lstsubgroup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstsubgroup.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To lstsubgroup.Items.Count - 1
                lstsubgroup.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To lstsubgroup.Items.Count - 1
                lstsubgroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub DeptitemwiseSalesRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            If CmdClear.Enabled = True Then
                Call CmdClear_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If CmdPrint.Enabled = True Then
                Call CMD_EXPORT_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
        End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEWITEMWISESALESUMMARY_JIC"
        sqlstring = "select * from VIEWITEMWISESALESUMMARY_JIC"
        Call _export.export_excel(sqlstring)
        _export.Show()
    End Sub

    Private Sub chk_DEPARTMENT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_DEPARTMENT.CheckedChanged
        If chk_DEPARTMENT.Checked = True Then
            GP_DEPT_WISE.Checked = False
            CHK_DTSUM.Checked = False
        Else
            GP_DEPT_WISE.Checked = True
        End If
    End Sub

    Private Sub GP_DEPT_WISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GP_DEPT_WISE.CheckedChanged
        If GP_DEPT_WISE.Checked = True Then
            CHK_PEND.Checked = False
            CHK_DTSUM.Checked = False
            'Else
            '    CHK_PEND.Checked = True
        End If
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        grp_SalebillChecklist.Top = 1000
        gPrint = False
        LstPOS.Items.Clear()
        LstGroup.Items.Clear()
        lstsubgroup.Items.Clear()
        Call FillPOS()
        FillGroup()
        'FillCATEGORY()
        FillSUBGROUPCODE()
        'Me.SSGRID.Visible = True
    End Sub

    Private Sub CmdView_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If LstPOS.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Group(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If lstsubgroup.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the SubGroup(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If GP_DEPT_WISE.Checked = False Then
            MessageBox.Show("Please the check the GroupWise", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub

        Dim SSQL As String
        If chk_DEPARTMENT.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call Viewdaywisesaleregister_dept()
        ElseIf GP_DEPT_WISE.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call Viewdaywisesaleregister_DEPT_GROUPWISE()
        ElseIf CHK_PAYMENT.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call PAYMENTDETAILS()
        ElseIf chkbox_group.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            'Call Viewdaywisesaleregister()
            Call Viewdaywisesaleregister_GROUPWISE()
        ElseIf CHK_PEND.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','Y'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call VIEWPENDINGALLSATE()
        ElseIf Me.CHK_DTSUM.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call SUMMARY()
        End If
        'Call Viewdaywisesaleregister()

    End Sub
    Private Sub SUMMARY()
        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim Viewer As New ReportViwer
        'Dim r1 As New GroupWiseDatewise
        Dim r1 As New GroupWiseDeptItemdatewise
        Dim i As Integer
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT  ITEMCODE,ITEMDESC,ITEMTYPE,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,rate,UOM,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as PACKAMOUNT,SUM(AMOUNT) AS AMOUNT,SUM(AMT) AS AMT FROM VIEWITEMWISESALESUMMARY_JIC "
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,ITEMTYPE,category ORDER BY GROUPDESC,itemdesc"
        Viewer.Report = r1

        SSQL2 = "SELECT kotdate,GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY kotdate,GROUPCODE,GROUPDESC,ITEMTYPE"

        Call Viewer.GetDetails1(SQLSTRING, "VIEWITEMWISESALESUMMARY_JIC", r1)
        Call Viewer.GetDetails1(SSQL2, "VIEWDATEGROUPPAYMENT", r1)
        'Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"


        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text4")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text18")
        TXTOBJ4.Text = HNAME

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
        TXTOBJ1.Text = "UserName : " & gUsername


        'Viewer.ssql = SQLSTRING

        Viewer.Show()
    End Sub
    Private Sub VIEWPENDINGALLSATE()
        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim Viewer As New ReportViwer
        Dim r1 As New ALLGROUPWISEPENDING
        Dim i As Integer
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT POSDESC,ISNULL(CATEGORY,'')AS CATEGORY,subGroupdesc,Paymentmode,ITEMCODE,ITEMDESC,ITEMTYPE,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,rate,UOM,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as PACKAMOUNT,SUM(AMOUNT) AS AMOUNT,SUM(AMT) AS AMT,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC"
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSDESC,ISNULL(CATEGORY,''),subGroupdesc,paymentmode,ITEMTYPE,itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,category ORDER BY GROUPDESC,itemdesc"
        Viewer.Report = r1

        SSQL2 = "SELECT GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY GROUPCODE,GROUPDESC  ,ITEMTYPE"

        Call Viewer.GetDetails1(SQLSTRING, "VIEWITEMWISESALESUMMARY_JIC", r1)
        Call Viewer.GetDetails1(SSQL2, "VIEWDATEGROUPPAYMENT", r1)
        'Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"


        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
        TXTOBJ1.Text = "UserName : " & gUsername

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text4")
        TXTOBJ5.Text = gCompanyname

        'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text18")
        'TXTOBJ4.Text = HNAME


        'Viewer.ssql = SQLSTRING

        Viewer.Show()
    End Sub
    Private Sub PAYMENTDETAILS()
        Dim i As Integer

        Dim sqlstring, SSQL, payment() As String
        Dim Viewer As New ReportViwer
        Dim r As New datewisecollectionreport
        Dim POSdesc(), MemberCode(), code() As String
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * FROM datewiseLIQUIRcollectionreport WHERE CATEGORY='BAR'"
        ''sqlstring = sqlstring & " WHERE KOTDATE BETWEEN "
        sqlstring = sqlstring & " AND  convert(varchar(11),KOTDATE,103) BETWEEN "
        sqlstring = sqlstring & " '" & Format(mskFromDate.Value, "dd/MM/yyyy") & "' AND '" & Format(mskToDate.Value, "dd/MM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and poscode in ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                code = Split(LstPOS.CheckedItems(i), "-->")
                'sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
                sqlstring = sqlstring & " '" & code(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"



        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lstsubgroup.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and subGROUPDESC in ("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstsubgroup.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        'If LstGroup.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and groupcode in ("
        '    For i = 0 To LstGroup.CheckedItems.Count - 1
        '        code = Split(LstGroup.CheckedItems(i), "-->")
        '        'sqlstring = sqlstring & " '" & LstGroup.CheckedItems(i) & "', "
        '        sqlstring = sqlstring & " '" & code(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        'If CHKLIST_PAYMENTMODE.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and paymentmode in ("
        '    For i = 0 To CHKLIST_PAYMENTMODE.CheckedItems.Count - 1
        '        payment = Split(CHKLIST_PAYMENTMODE.CheckedItems(i), "-->")
        '        'sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
        '        sqlstring = sqlstring & " '" & payment(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"

        'Else
        '    MsgBox("Select the PAYMENT MODE", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
        '    Exit Sub
        'End If
        'sqlstring = sqlstring & "order by kotdate,itemcode"

        Call Viewer.GetDetails(sqlstring, "datewiseLIQUIRcollectionreport", r)
        Viewer.TableName = "datewiseLIQUIRcollectionreport"

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ1.Text = MyCompanyName
        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ2.Text = " From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text20")
        TXTOBJ3.Text = "UserName : " & gUsername
        Viewer.Show()
    End Sub
    Private Sub CmdPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        'gPrint = True
        'If chk_DEPARTMENT.Checked = True Then
        '    Call Viewdaywisesaleregister_dept()
        'ElseIf GP_DEPT_WISE.Checked = True Then

        '    Call Viewdaywisesaleregister_DEPT_GROUPWISE()
        'ElseIf CHK_PAYMENT.Checked = True Then
        '    Call PAYMENTDETAILS()
        'ElseIf chkbox_group.Checked = True Then
        '    'Call Viewdaywisesaleregister()
        '    Call Viewdaywisesaleregister_GROUPWISE()
        'End If
        'Call Viewdaywisesaleregister()

    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub LstGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstGroup.SelectedIndexChanged

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

    Private Sub Chk_SelectAllGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllGroup.KeyDown
    End Sub

    Private Sub lstsubgroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstsubgroup.SelectedIndexChanged

    End Sub

    Private Sub CHK_PEND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_PEND.CheckedChanged
        If CHK_PEND.Checked = True Then
            GP_DEPT_WISE.Checked = False
            CHK_DTSUM.Checked = False
            'Else
            '    GP_DEPT_WISE.Checked = True
        End If
    End Sub

    Private Sub CMD_EXPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_EXPORT.Click
        Dim SSQL As String
        If CHK_PEND.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','Y'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call PENDINGGROUPWISEEXCEL()
        ElseIf GP_DEPT_WISE.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call GROUPWISEEXCEL()
        ElseIf CHK_DTSUM.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call DATEWISEEXCEL()
        Else
            MessageBox.Show("PLEASE SELECT THE OPTION", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
    Private Sub PENDINGGROUPWISEEXCEL()
        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim i As Integer
        Dim exp As New exportexcel
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT POSDESC,GROUPCODE,GROUPDESC,subGroupdesc,ITEMTYPE,ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,rate,SUM(AMT) AS AMOUNT,sum(TAXAMOUNT)as TAXAMOUNT,sum(SCHARGE)as SERVICECHARGE,sum(PACKAMOUNT)as SERTAX,SUM(AMOUNT) AS TOTAL,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC"
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSDESC,subGroupdesc,ITEMTYPE,itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,category ORDER BY itemdesc,GROUPDESC,category "

        SSQL2 = "SELECT GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE ,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY GROUPCODE,GROUPDESC ,ITEMTYPE"
        gconnection.getDataSet(SSQL2, "pending")
        If gdataset.Tables("pending").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SQLSTRING, "GROUPWISE SALES REGISTER(PENDING) " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub GROUPWISEEXCEL()
        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim i As Integer
        Dim exp As New exportexcel
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT POSDESC,GROUPCODE,GROUPDESC,subGroupdesc,ITEMTYPE,ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,rate,SUM(AMT) AS AMOUNT,sum(TAXAMOUNT)as TAXAMOUNT,sum(SCHARGE)as SERVICECHARGE,sum(PACKAMOUNT)as SERTAX,SUM(AMOUNT) AS TOTAL,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC"
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSDESC,subGroupdesc,ITEMTYPE,itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,category ORDER BY itemdesc,GROUPDESC,category "

        SSQL2 = "SELECT GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE,sum((ISNULL(ACHARGE  ,0))) AS ACHARGE,sum((ISNULL(PCHARGE  ,0))) AS PCHARGE,sum((ISNULL(RCHARGE  ,0))) AS RCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY GROUPCODE,GROUPDESC  ,ITEMTYPE"
        gconnection.getDataSet(SSQL2, "NOpending")
        If gdataset.Tables("NOpending").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SQLSTRING, "GROUPWISE SALES REGISTER " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub DATEWISEEXCEL()
        Dim posdesc(), servercode(), TYPE(), HNAME, SSQL2 As String
        Dim i As Integer
        Dim exp As New exportexcel
        Call validatedate() '''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT POSDESC,GROUPCODE,GROUPDESC,subGroupdesc,ITEMTYPE,ITEMCODE,ITEMDESC,UOM,SUM(QTY) AS QTY,RATE,SUM(AMT) AS AMOUNT ,sum(TAXAMOUNT)as TAXAMOUNT,sum(SCHARGE)as SERVICECHARGE,sum(PACKAMOUNT)as SERTAX,SUM(AMOUNT) AS TOTAL FROM VIEWITEMWISESALESUMMARY_JIC_pending"
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lstsubgroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and subGROUPDESC in ("
            HNAME = "("
            For i = 0 To lstsubgroup.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstsubgroup.CheckedItems(i) & "', "
                HNAME = HNAME & lstsubgroup.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SQLSTRING = SQLSTRING & " '" & TYPE(1) & "', "

            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSDESC,subGroupdesc,ITEMTYPE,itemcode,itemdesc,UOM,rate,GROUPCODE,GROUPDESC,category ORDER BY itemdesc,GROUPDESC,category "

        SSQL2 = "SELECT GROUPCODE,GROUPDESC,ITEMTYPE,sum(TOTamt) TOTAMT,sum((ISNULL(TAXAMOUNT ,0))) AS TAXAMOUNT,SUM((ISNULL(AMT ,0))) AS AMT,"
        SSQL2 = SSQL2 & "sum((ISNULL(PACKAMOUNT ,0))) AS PACKAMOUNT,sum((ISNULL(SCHARGE  ,0))) AS SCHARGE FROM VIEWDATEGROUPPAYMENT where kotdate between'"
        SSQL2 = SSQL2 & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SSQL2 = SSQL2 & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            SSQL2 = SSQL2 & " AND GROUPCODE IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                TYPE = Split(LstGroup.CheckedItems(i), "-->")
                SSQL2 = SSQL2 & " '" & TYPE(1) & "', "

            Next
            SSQL2 = Mid(SSQL2, 1, Len(SSQL2) - 2)
            SSQL2 = SSQL2 & ")"
        End If
        SSQL2 = SSQL2 & "GROUP BY GROUPCODE,GROUPDESC,ITEMTYPE"

        gconnection.getDataSet(SSQL2, "NOpending")
        If gdataset.Tables("NOpending").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SQLSTRING, "GROUPWISE SALES-DATEWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub CHK_DTSUM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_DTSUM.CheckedChanged
        If CHK_DTSUM.Checked = True Then
            GP_DEPT_WISE.Checked = False
            CHK_PEND.Checked = False
            'Else
            '    GP_DEPT_WISE.Checked = True
        End If
    End Sub
End Class
