Imports System.Data.SqlClient
Public Class SalesBillChecklist1
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
    Friend WithEvents Chk_SelectAllPos As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_SelectAllServer As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents Chklist_POSLocation As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chklist_Servercode As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RAD_BOTH As System.Windows.Forms.RadioButton
    Friend WithEvents RAD_POOLCAFE As System.Windows.Forms.RadioButton
    Friend WithEvents RAD_MCLUB As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents LBL_POSWISE As System.Windows.Forms.Label
    Friend WithEvents Chk_SUMM As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_DET As System.Windows.Forms.CheckBox
    Friend WithEvents SSGRIDT As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllUSERS As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_USERNAME As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllBEARERS As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_BEARERNAME As System.Windows.Forms.CheckedListBox
    Friend WithEvents BEARERWISE As System.Windows.Forms.CheckBox
    Friend WithEvents USERWISE As System.Windows.Forms.CheckBox
    Friend WithEvents DATEWISE As System.Windows.Forms.CheckBox
    Friend WithEvents cmdexp As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesBillChecklist1))
        Me.Chklist_POSLocation = New System.Windows.Forms.CheckedListBox()
        Me.Chklist_Servercode = New System.Windows.Forms.CheckedListBox()
        Me.Chk_SelectAllPos = New System.Windows.Forms.CheckBox()
        Me.Chk_SelectAllServer = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
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
        Me.CmdView = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexp = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.LBL_POSWISE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DATEWISE = New System.Windows.Forms.CheckBox()
        Me.BEARERWISE = New System.Windows.Forms.CheckBox()
        Me.USERWISE = New System.Windows.Forms.CheckBox()
        Me.CHK_DET = New System.Windows.Forms.CheckBox()
        Me.Chk_SUMM = New System.Windows.Forms.CheckBox()
        Me.RAD_BOTH = New System.Windows.Forms.RadioButton()
        Me.RAD_POOLCAFE = New System.Windows.Forms.RadioButton()
        Me.RAD_MCLUB = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.SSGRIDT = New AxFPSpreadADO.AxfpSpread()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllUSERS = New System.Windows.Forms.CheckBox()
        Me.Chklist_USERNAME = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllBEARERS = New System.Windows.Forms.CheckBox()
        Me.Chklist_BEARERNAME = New System.Windows.Forms.CheckedListBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SSGRIDT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chklist_POSLocation
        '
        Me.Chklist_POSLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_POSLocation.Location = New System.Drawing.Point(208, 175)
        Me.Chklist_POSLocation.Name = "Chklist_POSLocation"
        Me.Chklist_POSLocation.Size = New System.Drawing.Size(198, 356)
        Me.Chklist_POSLocation.TabIndex = 1
        '
        'Chklist_Servercode
        '
        Me.Chklist_Servercode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chklist_Servercode.Location = New System.Drawing.Point(936, 433)
        Me.Chklist_Servercode.Name = "Chklist_Servercode"
        Me.Chklist_Servercode.Size = New System.Drawing.Size(48, 46)
        Me.Chklist_Servercode.TabIndex = 3
        Me.Chklist_Servercode.Visible = False
        '
        'Chk_SelectAllPos
        '
        Me.Chk_SelectAllPos.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPos.Location = New System.Drawing.Point(208, 128)
        Me.Chk_SelectAllPos.Name = "Chk_SelectAllPos"
        Me.Chk_SelectAllPos.Size = New System.Drawing.Size(104, 24)
        Me.Chk_SelectAllPos.TabIndex = 0
        Me.Chk_SelectAllPos.Text = "SELECT ALL "
        Me.Chk_SelectAllPos.UseVisualStyleBackColor = False
        '
        'Chk_SelectAllServer
        '
        Me.Chk_SelectAllServer.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllServer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllServer.Location = New System.Drawing.Point(953, 362)
        Me.Chk_SelectAllServer.Name = "Chk_SelectAllServer"
        Me.Chk_SelectAllServer.Size = New System.Drawing.Size(48, 24)
        Me.Chk_SelectAllServer.TabIndex = 2
        Me.Chk_SelectAllServer.Text = "SELECT ALL"
        Me.Chk_SelectAllServer.UseVisualStyleBackColor = False
        Me.Chk_SelectAllServer.Visible = False
        '
        'Timer1
        '
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(6, 63)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 5
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.Location = New System.Drawing.Point(-40, 304)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(6, 319)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(201, 580)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(614, 64)
        Me.grp_SalebillChecklist.TabIndex = 12
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
        Me.ProgressBar1.Size = New System.Drawing.Size(589, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.mskFromDate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.mskToDate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(220, 584)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(590, 56)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(139, 16)
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
        Me.Label6.Location = New System.Drawing.Point(320, 18)
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
        Me.mskToDate.Location = New System.Drawing.Point(398, 16)
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
        Me.Label7.Location = New System.Drawing.Point(48, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(56, 632)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(40, 32)
        Me.CmdView.TabIndex = 6
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        Me.CmdView.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexp)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.cmdreport)
        Me.GroupBox4.Location = New System.Drawing.Point(866, 144)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(141, 417)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'cmdexp
        '
        Me.cmdexp.BackColor = System.Drawing.Color.Transparent
        Me.cmdexp.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.cmdexp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexp.ForeColor = System.Drawing.Color.Black
        Me.cmdexp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexp.Location = New System.Drawing.Point(7, 232)
        Me.cmdexp.Name = "cmdexp"
        Me.cmdexp.Size = New System.Drawing.Size(131, 56)
        Me.cmdexp.TabIndex = 10
        Me.cmdexp.Text = "Export [F12]"
        Me.cmdexp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexp.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdreport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.cmdreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.Black
        Me.cmdreport.Location = New System.Drawing.Point(7, 150)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(131, 56)
        Me.cmdreport.TabIndex = 9
        Me.cmdreport.Text = "Report [F8]"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Image = CType(resources.GetObject("cmdexport.Image"), System.Drawing.Image)
        Me.cmdexport.Location = New System.Drawing.Point(16, 632)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(32, 32)
        Me.cmdexport.TabIndex = 9
        Me.cmdexport.Text = " Export[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'LBL_POSWISE
        '
        Me.LBL_POSWISE.AutoSize = True
        Me.LBL_POSWISE.BackColor = System.Drawing.Color.Transparent
        Me.LBL_POSWISE.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_POSWISE.Location = New System.Drawing.Point(192, 79)
        Me.LBL_POSWISE.Name = "LBL_POSWISE"
        Me.LBL_POSWISE.Size = New System.Drawing.Size(145, 18)
        Me.LBL_POSWISE.TabIndex = 9
        Me.LBL_POSWISE.Text = " POSWISE  SALES  "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 656)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(424, 16)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(208, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 24)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "POS LOCATION :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(913, 564)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 24)
        Me.Label4.TabIndex = 422
        Me.Label4.Text = "SERVER NAME :"
        Me.Label4.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DATEWISE)
        Me.GroupBox1.Controls.Add(Me.BEARERWISE)
        Me.GroupBox1.Controls.Add(Me.USERWISE)
        Me.GroupBox1.Controls.Add(Me.CHK_DET)
        Me.GroupBox1.Controls.Add(Me.Chk_SUMM)
        Me.GroupBox1.Location = New System.Drawing.Point(210, 539)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 40)
        Me.GroupBox1.TabIndex = 423
        Me.GroupBox1.TabStop = False
        '
        'DATEWISE
        '
        Me.DATEWISE.BackColor = System.Drawing.Color.Transparent
        Me.DATEWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DATEWISE.Location = New System.Drawing.Point(499, 16)
        Me.DATEWISE.Name = "DATEWISE"
        Me.DATEWISE.Size = New System.Drawing.Size(88, 16)
        Me.DATEWISE.TabIndex = 433
        Me.DATEWISE.Text = "DATEWISE"
        Me.DATEWISE.UseVisualStyleBackColor = False
        '
        'BEARERWISE
        '
        Me.BEARERWISE.BackColor = System.Drawing.Color.Transparent
        Me.BEARERWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BEARERWISE.Location = New System.Drawing.Point(365, 16)
        Me.BEARERWISE.Name = "BEARERWISE"
        Me.BEARERWISE.Size = New System.Drawing.Size(115, 16)
        Me.BEARERWISE.TabIndex = 432
        Me.BEARERWISE.Text = "BEARER WISE"
        Me.BEARERWISE.UseVisualStyleBackColor = False
        '
        'USERWISE
        '
        Me.USERWISE.BackColor = System.Drawing.Color.Transparent
        Me.USERWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.USERWISE.Location = New System.Drawing.Point(252, 16)
        Me.USERWISE.Name = "USERWISE"
        Me.USERWISE.Size = New System.Drawing.Size(93, 16)
        Me.USERWISE.TabIndex = 431
        Me.USERWISE.Text = "USERWISE"
        Me.USERWISE.UseVisualStyleBackColor = False
        '
        'CHK_DET
        '
        Me.CHK_DET.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DET.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DET.Location = New System.Drawing.Point(152, 16)
        Me.CHK_DET.Name = "CHK_DET"
        Me.CHK_DET.Size = New System.Drawing.Size(80, 16)
        Me.CHK_DET.TabIndex = 430
        Me.CHK_DET.Text = "DETAILS"
        Me.CHK_DET.UseVisualStyleBackColor = False
        '
        'Chk_SUMM
        '
        Me.Chk_SUMM.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SUMM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SUMM.Location = New System.Drawing.Point(31, 16)
        Me.Chk_SUMM.Name = "Chk_SUMM"
        Me.Chk_SUMM.Size = New System.Drawing.Size(93, 16)
        Me.Chk_SUMM.TabIndex = 429
        Me.Chk_SUMM.Text = "SUMMARY"
        Me.Chk_SUMM.UseVisualStyleBackColor = False
        '
        'RAD_BOTH
        '
        Me.RAD_BOTH.Checked = True
        Me.RAD_BOTH.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RAD_BOTH.Location = New System.Drawing.Point(24, 504)
        Me.RAD_BOTH.Name = "RAD_BOTH"
        Me.RAD_BOTH.Size = New System.Drawing.Size(64, 15)
        Me.RAD_BOTH.TabIndex = 0
        Me.RAD_BOTH.TabStop = True
        Me.RAD_BOTH.Text = "BOTH"
        Me.RAD_BOTH.Visible = False
        '
        'RAD_POOLCAFE
        '
        Me.RAD_POOLCAFE.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RAD_POOLCAFE.Location = New System.Drawing.Point(8, 608)
        Me.RAD_POOLCAFE.Name = "RAD_POOLCAFE"
        Me.RAD_POOLCAFE.Size = New System.Drawing.Size(96, 15)
        Me.RAD_POOLCAFE.TabIndex = 0
        Me.RAD_POOLCAFE.Text = "POOL CAFE"
        Me.RAD_POOLCAFE.Visible = False
        '
        'RAD_MCLUB
        '
        Me.RAD_MCLUB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RAD_MCLUB.Location = New System.Drawing.Point(8, 560)
        Me.RAD_MCLUB.Name = "RAD_MCLUB"
        Me.RAD_MCLUB.Size = New System.Drawing.Size(96, 15)
        Me.RAD_MCLUB.TabIndex = 0
        Me.RAD_MCLUB.Text = " M.CLUB"
        Me.RAD_MCLUB.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(933, 564)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 24)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "CATEGORY"
        Me.Label8.Visible = False
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(883, 564)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(24, 16)
        Me.Chk_SelectAllCategory.TabIndex = 431
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        Me.Chk_SelectAllCategory.Visible = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lstcategory.Location = New System.Drawing.Point(963, 552)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(24, 25)
        Me.lstcategory.TabIndex = 432
        Me.lstcategory.Visible = False
        '
        'SSGRIDT
        '
        Me.SSGRIDT.DataSource = Nothing
        Me.SSGRIDT.Location = New System.Drawing.Point(8, 8)
        Me.SSGRIDT.Name = "SSGRIDT"
        Me.SSGRIDT.OcxState = CType(resources.GetObject("SSGRIDT.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRIDT.Size = New System.Drawing.Size(144, 48)
        Me.SSGRIDT.TabIndex = 442
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(422, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 24)
        Me.Label3.TabIndex = 445
        Me.Label3.Text = "USER NAMELIST:"
        '
        'Chk_SelectAllUSERS
        '
        Me.Chk_SelectAllUSERS.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllUSERS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllUSERS.Location = New System.Drawing.Point(422, 128)
        Me.Chk_SelectAllUSERS.Name = "Chk_SelectAllUSERS"
        Me.Chk_SelectAllUSERS.Size = New System.Drawing.Size(104, 24)
        Me.Chk_SelectAllUSERS.TabIndex = 443
        Me.Chk_SelectAllUSERS.Text = "SELECT ALL "
        Me.Chk_SelectAllUSERS.UseVisualStyleBackColor = False
        '
        'Chklist_USERNAME
        '
        Me.Chklist_USERNAME.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_USERNAME.Location = New System.Drawing.Point(422, 175)
        Me.Chklist_USERNAME.Name = "Chklist_USERNAME"
        Me.Chklist_USERNAME.Size = New System.Drawing.Size(191, 356)
        Me.Chklist_USERNAME.TabIndex = 444
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(626, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(189, 24)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "BEARER NAMELIST :"
        '
        'Chk_SelectAllBEARERS
        '
        Me.Chk_SelectAllBEARERS.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllBEARERS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllBEARERS.Location = New System.Drawing.Point(626, 127)
        Me.Chk_SelectAllBEARERS.Name = "Chk_SelectAllBEARERS"
        Me.Chk_SelectAllBEARERS.Size = New System.Drawing.Size(104, 34)
        Me.Chk_SelectAllBEARERS.TabIndex = 446
        Me.Chk_SelectAllBEARERS.Text = "SELECT ALL "
        Me.Chk_SelectAllBEARERS.UseVisualStyleBackColor = False
        '
        'Chklist_BEARERNAME
        '
        Me.Chklist_BEARERNAME.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_BEARERNAME.Location = New System.Drawing.Point(626, 178)
        Me.Chklist_BEARERNAME.Name = "Chklist_BEARERNAME"
        Me.Chklist_BEARERNAME.Size = New System.Drawing.Size(189, 356)
        Me.Chklist_BEARERNAME.TabIndex = 447
        '
        'SalesBillChecklist1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1021, 696)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Chk_SelectAllBEARERS)
        Me.Controls.Add(Me.Chklist_BEARERNAME)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_SelectAllUSERS)
        Me.Controls.Add(Me.Chklist_USERNAME)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBL_POSWISE)
        Me.Controls.Add(Me.RAD_BOTH)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_SelectAllServer)
        Me.Controls.Add(Me.Chk_SelectAllPos)
        Me.Controls.Add(Me.Chklist_POSLocation)
        Me.Controls.Add(Me.Chklist_Servercode)
        Me.Controls.Add(Me.RAD_POOLCAFE)
        Me.Controls.Add(Me.RAD_MCLUB)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CmdPrint)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "SalesBillChecklist1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SALE BILL CHECKLIST-POSWISE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.SSGRIDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass

    '''******************************  To fill POS details from POSMASTER  *******************************'''
    Private Sub FillPOSLocation()
        Dim i As Integer
        Chklist_POSLocation.Items.Clear()
        sqlstring = "SELECT DISTINCT poscode,posdesc FROM posmaster WHERE ISNULL(Freeze,'')<>'Y' "
        vconn.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    Chklist_POSLocation.Items.Add(Trim(.Item("POSdesc")))
                End With
            Next i
        End If
        Chklist_POSLocation.Sorted = True
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
    '''*****************************  To fill Server details from SERVERMASTER  **************************'''
    Private Sub FillServerName()
        Dim i As Integer
        Chklist_Servercode.Items.Clear()
        sqlstring = " SELECT DISTINCT ISNULL(SCODE,'') AS SERVERCODE ,ISNULL(S.SERVERNAME,'') AS SERVERNAME  FROM SERVERMASTER S RIGHT OUTER JOIN KOT_DET K ON S.SERVERCODE=K.SCODE"
        ' sqlstring = "SELECT DISTINCT ISNULL(SERVERCODE,'') AS SERVERCODE,ISNULL(SERVERNAME,'') AS SERVERNAME FROM SERVERMASTER ORDER BY SERVERCODE"
        vconn.getDataSet(sqlstring, "SERVERMASTER")
        If gdataset.Tables("SERVERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SERVERMASTER").Rows.Count - 1
                With gdataset.Tables("SERVERMASTER").Rows(i)
                    Chklist_BEARERNAME.Items.Add(Trim(.Item("servercode")) & "==>" & .Item("servername"))
                End With
            Next i
        End If
        Chklist_Servercode.Sorted = True
    End Sub
    Private Sub USERName()
        Dim i As Integer
        Chklist_Servercode.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(adduserid,'')AS adduserid  FROM kot_det  ORDER BY adduserid"
        vconn.getDataSet(sqlstring, "POS_USERCONTROL")
        If gdataset.Tables("POS_USERCONTROL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS_USERCONTROL").Rows.Count - 1
                With gdataset.Tables("POS_USERCONTROL").Rows(i)
                    Chklist_USERNAME.Items.Add(Trim(.Item("adduserid")))
                End With
            Next i
        End If
        Chklist_Servercode.Sorted = True
    End Sub

    Private Sub SalesBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillPOSLocation()
        Call FillServerName()
        Call USERName()
        FillCATEGORY()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CATERING"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))
        Me.SSGRIDT.Visible = False
        mskFromDate.Value = Now.Today
        mskToDate.Value = Now.Today
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
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Chklist_POSLocation.Items.Clear()
        Chklist_Servercode.Items.Clear()
        Chklist_BEARERNAME.Items.Clear()
        Chklist_USERNAME.Items.Clear()
        grp_SalebillChecklist.Top = 1000
        Chk_SelectAllPos.Checked = False
        Chk_SelectAllServer.Checked = False
        Chk_SelectAllBEARERS.Checked = False
        Chk_SelectAllUSERS.Checked = False
        Call FillPOSLocation()
        Call FillServerName()
        Call USERName()
        Me.SSGRIDT.Visible = False
        Chk_SUMM.Checked = False
        BEARERWISE.Checked = False
        USERWISE.Checked = False
        DATEWISE.Checked = False
        CHK_DET.Checked = False
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        'If Chklist_POSLocation.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If Chklist_Servercode.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Server(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        'If chkdatevalidate = False Then Exit Sub
        'gPrint = False
        'grp_SalebillChecklist.Top = 520
        'grp_SalebillChecklist.Left = 176
        'Me.ProgressBar1.Value = 2
        'Me.Timer1.Interval = 30
        'Me.Timer1.Enabled = True
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        gPrint = True
        If Chk_SUMM.Checked = True Then
            Call POSWISESUMMARY()
        Else
            CHK_DET.Checked = True
            Call POSDETAILS()
        End If
    End Sub
    Private Sub Chk_SelectAllPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPos.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPos.Checked = True Then
            For i = 0 To Chklist_POSLocation.Items.Count - 1
                Chklist_POSLocation.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_POSLocation.Items.Count - 1
                Chklist_POSLocation.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllServer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllServer.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllServer.Checked = True Then
            For i = 0 To Chklist_Servercode.Items.Count - 1
                Chklist_Servercode.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To Chklist_Servercode.Items.Count - 1
                Chklist_Servercode.SetItemChecked(i, False)
            Next i
        End If

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            Call Viewsalebillchecklist()
        End If
        'Me.grp_SalebillChecklist.Top = 1000
        'Call Viewsalebillchecklist()
    End Sub

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
    Public Sub Viewsalebillchecklist()
        Dim RSNO
        Try
            Dim servercode() As String
            Dim i As Integer

            sqlstring = "SELECT * FROM VIEWSALEBILLCHECKLIST_KOT WHERE "
            sqlstring = sqlstring & " BILLDATE BETWEEN '"
            sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
            If Chklist_POSLocation.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND POSDESC IN ("
                For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            End If
            If Chklist_Servercode.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND SERVERCODE IN ("
                For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                    servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                    'sqlstring = sqlstring & servercode(0) & ", "
                    sqlstring = sqlstring & " '" & servercode(0) & "', "
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

            sqlstring = sqlstring & " ORDER BY MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLDATE,BILLDETAILS"
            Dim heading() As String = {"SALES BILL CHECKLIST "}
            Dim ObjSalesBillChecklist1Report As New SalesBillChecklist1Report
            ObjSalesBillChecklist1Report.ReportDetails(sqlstring, heading, mskFromDate.Value, mskToDate.Value, RSNO, Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub SalesBillChecklist1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            For i = 0 To Chklist_POSLocation.Items.Count - 1
                Chklist_POSLocation.SetItemChecked(i, True)
            Next i
            Chk_SelectAllPos.Checked = True
            For i = 0 To Chklist_Servercode.Items.Count - 1
                Chklist_Servercode.SetItemChecked(i, True)
            Next i
            Chk_SelectAllServer.Checked = True
            Me.mskFromDate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            If cmdreport.Enabled = True Then
                Call cmdreport_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
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
        End If
    End Sub

    Private Sub Chklist_POSLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chklist_POSLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            Chk_SelectAllServer.Focus()
        End If
    End Sub

    Private Sub Chklist_Servercode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chklist_Servercode.KeyDown
        If e.KeyCode = Keys.Enter Then
            mskFromDate.Focus()
        End If
    End Sub

    Private Sub Chk_SelectAllPos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllPos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Chklist_POSLocation.Focus()
        End If
    End Sub

    Private Sub Chk_SelectAllServer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllServer.KeyDown
        If e.KeyCode = Keys.Enter Then
            Chklist_Servercode.Focus()
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

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEWSALEBILLCHECKLIST_KOT"
        sqlstring = "select * from VIEWSALEBILLCHECKLIST_KOT order by CATEGORY"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim SSQL As String

        If Chklist_POSLocation.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Chklist_USERNAME.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Username(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Chklist_BEARERNAME.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Bearer(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub

        If Chk_SUMM.Checked = True Then
            If Chk_SUMM.Checked = True And USERWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSWISESUMMARYUSERWISE()
                Exit Sub
            ElseIf BEARERWISE.Checked = True And Chk_SUMM.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)
                Call POSWISESUMMARYBEARERWISE()
                Exit Sub
            ElseIf Chk_SUMM.Checked = True And DATEWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)
                Call POSWISESUMMARYDATEWISE()
                Exit Sub
            Else
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)
                Call POSWISESUMMARY()
                Exit Sub
            End If
        Else
            If CHK_DET.Checked = True Then



                If CHK_DET.Checked = True And USERWISE.Checked = True Then
                    SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                    gconnection.ExcuteStoreProcedure(SSQL)
                    Call POSDETAILSUSERWISE()
                    Exit Sub
                ElseIf CHK_DET.Checked = True And BEARERWISE.Checked = True Then
                    SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                    gconnection.ExcuteStoreProcedure(SSQL)
                    Call POSDETAILSBEARERWISE()

                    Exit Sub
                ElseIf CHK_DET.Checked = True And DATEWISE.Checked = True Then
                    SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                    gconnection.ExcuteStoreProcedure(SSQL)
                    Call POSDETAILSDATEWISE()
                    Exit Sub
                Else
                    SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                    gconnection.ExcuteStoreProcedure(SSQL)
                    Call POSDETAILS()
                    Exit Sub
                End If
            End If
        End If
        'ElseIf DATEWISE.Checked = True And USERWISE.Checked = True Then
        '    Call USERDATEWISE()

        'ElseIf DATEWISE.Checked = True And BEARERWISE.Checked = True Then
        '    Call BEARERDATEWISE()
        If Chk_SUMM.Checked = True And CHK_DET.Checked = True Then
            MessageBox.Show("PLEASE SELECT THE CORRECT COMBINATION FOR CHECKBOX  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Chk_SUMM.Checked = False And CHK_DET.Checked = False Then
            MessageBox.Show("PLEASE SELECT THE CORRECT COMBINATION FOR CHECKBOX  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub POSDETAILS()
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESUMMARY_DETAILS

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and CATEGORY in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"

        gconnection.getDataSet(sqlstring, "DET")
        If (gdataset.Tables("DET").Rows.Count > 0) Then
            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY_DETAILS", r)
            Viewer.TableName = "POSWISESALESUMMARY_DETAILS"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text8")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub POSDETAILSDATEWISE()
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSDETAILSDATEWISE

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and CATEGORY in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"

        gconnection.getDataSet(sqlstring, "DETDATE")
        If (gdataset.Tables("DETDATE").Rows.Count > 0) Then
            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY_DETAILS", r)
            Viewer.TableName = "POSWISESALESUMMARY_DETAILS"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text10")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub


    Private Sub POSDETAILSUSERWISE()
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESUSERWISEDETAILS

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and CATEGORY in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        sqlstring = sqlstring & "ORDER BY POSDESC,ADDUSERID,BILLDATE"

        gconnection.getDataSet(sqlstring, "USERWISED")
        If (gdataset.Tables("USERWISED").Rows.Count > 0) Then

            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY_DETAILS", r)
            Viewer.TableName = "POSWISESALESUMMARY_DETAILS"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text26")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub POSDETAILSBEARERWISE()
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESBEARERWISEDETAIL

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and CATEGORY in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        sqlstring = sqlstring & "ORDER BY POSDESC,SERVERNAME,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "BEAR")
        If (gdataset.Tables("BEAR").Rows.Count > 0) Then
            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY_DETAILS", r)
            Viewer.TableName = "POSWISESALESUMMARY_DETAILS"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text10")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub POSWISESUMMARYDATEWISE()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESUMMARYDATEWISE

        sqlstring = "SELECT * FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and SERVERCODE in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "DATEWISE")

        If (gdataset.Tables("DATEWISE").Rows.Count > 0) Then
            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY", r)
            Viewer.TableName = "POSWISESALESUMMARY"
            ' r.RecordSelectionFormula(

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO" & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
    Private Sub POSWISESUMMARY()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESUMMARY

        sqlstring = "SELECT * FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and SERVERCODE in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"

        gconnection.getDataSet(sqlstring, "SUMMARY")
        If (gdataset.Tables("SUMMARY").Rows.Count > 0) Then

            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY", r)
            Viewer.TableName = "POSWISESALESUMMARY"
            'r.RecordSelectionFormula(

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO" & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub POSWISESUMMARYUSERWISE()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESUMMARYUSERWISE

        sqlstring = "SELECT * FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and SERVERCODE in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        sqlstring = sqlstring & "ORDER BY POSDESC,ADDUSERID,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "USERWISE")
        If (gdataset.Tables("USERWISE").Rows.Count > 0) Then
            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY", r)
            Viewer.TableName = "POSWISESALESUMMARY"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO" & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub POSWISESUMMARYBEARERWISE()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim txtobj1 As TextObject


        Dim r As New POSWISESALESUMMARYBEARERWISE

        sqlstring = "SELECT * FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'If lstcategory.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and SERVERCODE in ("
        '    For i = 0 To lstcategory.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        sqlstring = sqlstring & "ORDER BY POSDESC,SERVERNAME,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "BEARER")
        If (gdataset.Tables("BEARER").Rows.Count > 0) Then

            Call Viewer.GetDetails(sqlstring, "POSWISESALESUMMARY", r)
            Viewer.TableName = "POSWISESALESUMMARY"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = gCompanyname

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO" & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Chk_SUMM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SUMM.CheckedChanged
        If Chk_SUMM.Checked = True Then
            CHK_DET.Checked = False
            'USERWISE.Checked = True
            'BEARERWISE.Checked = False
        ElseIf Chk_SUMM.Checked = True Then
            CHK_DET.Checked = False
            'USERWISE.Checked = False
            'BEARERWISE.Checked = True
        Else
            CHK_DET.Checked = True

        End If
    End Sub

    Private Sub CHK_DET_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_DET.CheckedChanged
        If CHK_DET.Checked = True Then
            Chk_SUMM.Checked = False
            'USERWISE.Checked = True
            'BEARERWISE.Checked = False
        ElseIf CHK_DET.Checked = True Then
            Chk_SUMM.Checked = False
            ''USERWISE.Checked = False
            ''BEARERWISE.Checked = True
        Else
            Chk_SUMM.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexp.Click
        'If Chk_SUMM.Checked = True Then
        '    Call POSWISESUMMARYEXCEL()
        'Else
        '    CHK_DET.Checked = True
        '    Call POSWISESUMMARYEXCELDETAILS()
        'End If

        Dim SSQL As String
        If Chk_SUMM.Checked = True Then
            If Chk_SUMM.Checked = True And USERWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSWISESUMMARYUSERWISEexcel()
                Exit Sub
            ElseIf BEARERWISE.Checked = True And Chk_SUMM.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSWISESUMMARYBEARERWISEexcel()
                Exit Sub
            ElseIf Chk_SUMM.Checked = True And DATEWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSWISESUMMARYDATEWISEexcel()
                Exit Sub
            Else
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSWISESUMMARYEXCEL()
                Exit Sub
            End If
        End If
        If CHK_DET.Checked = True Then
            If CHK_DET.Checked = True And USERWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSDETAILSUSERWISEexcel()
                Exit Sub
            ElseIf CHK_DET.Checked = True And BEARERWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSDETAILSBEARERWISEexcel()
                Exit Sub
            ElseIf CHK_DET.Checked = True And DATEWISE.Checked = True Then
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)

                Call POSDETAILSDATEWISEexcel()
                Exit Sub
            Else
                SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SSQL)
                Call POSDETAILSexcel()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub POSDETAILSDATEWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel

        Dim sqlstring, SSQL As String

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSDETAILSDATEWISEexcel")
        If gdataset.Tables("POSDETAILSDATEWISEexcel").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES DETAILS -DATEWISE" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub POSWISESUMMARYDATEWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, SSQL As String

        sqlstring = " SELECT ISNULL(POSDESC,'') AS POSDESC ,ISNULL(MCODE,'') AS MEMBERCODE,ISNULL(MNAME,'')AS MEMBERNAME,ISNULL(BILLNO,'')AS BILLNO,"
        sqlstring = sqlstring & "ISNULL(BILLDATE,'')AS BILLDATE,ISNULL(BILLDETAILS,'')AS BILLDETAILS,ISNULL(BILLAMOUNT,0)AS AMOUNT,ISNULL(TAXAMOUNT,0)AS TAXAMOUNT,"
        sqlstring = sqlstring & "ISNULL(packamount,0)AS SERTAX,ISNULL(TOTALAMOUNT,0)AS TOTALAMOUNT,"
        sqlstring = sqlstring & "ISNULL(PAYMENTMODE,'')AS PAYMENTMODE,ISNULL(SERVERCODE,'')AS SERVERCODE,ISNULL(KOTDATE,'')AS KOTDATE,ISNULL(AddUserid,'')AS AddUserid,"
        sqlstring = sqlstring & "ISNULL(ServerName,'')AS SERVERNAME FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSWISESUMMARYDATEWISEexcel")
        If gdataset.Tables("POSWISESUMMARYDATEWISEexcel").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES SUMMARY - DATEWISE" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub POSDETAILSBEARERWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, SSQL As String

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,SERVERNAME,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSDETAILSBEARERWISEexcel")
        If gdataset.Tables("POSDETAILSBEARERWISEexcel").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES DETAILS -BEARERWISE" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub POSDETAILSUSERWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel

        Dim sqlstring, SSQL As String

        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,ADDUSERID,BILLDATE"
        gconnection.getDataSet(sqlstring, "POSDETAILSUSERWISEexcel")
        If gdataset.Tables("POSDETAILSUSERWISEexcel").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES DETAILS -USERWISE" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub POSWISESUMMARYBEARERWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel

        Dim sqlstring, SSQL As String

        sqlstring = " SELECT ISNULL(POSDESC,'') AS POSDESC ,ISNULL(MCODE,'') AS MEMBERCODE,ISNULL(MNAME,'')AS MEMBERNAME,ISNULL(BILLNO,'')AS BILLNO,"
        sqlstring = sqlstring & "ISNULL(BILLDATE,'')AS BILLDATE,ISNULL(BILLDETAILS,'')AS BILLDETAILS,ISNULL(BILLAMOUNT,0)AS AMOUNT,ISNULL(TAXAMOUNT,0)AS TAXAMOUNT,"
        sqlstring = sqlstring & "ISNULL(packamount,0)AS SERTAX,ISNULL(TOTALAMOUNT,0)AS TOTALAMOUNT,"
        sqlstring = sqlstring & "ISNULL(PAYMENTMODE,'')AS PAYMENTMODE,ISNULL(SERVERCODE,'')AS SERVERCODE,ISNULL(KOTDATE,'')AS KOTDATE,ISNULL(AddUserid,'')AS AddUserid,"
        sqlstring = sqlstring & "ISNULL(ServerName,'')AS SERVERNAME FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,SERVERNAME,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSWISESALESUMMARYBEARER")
        If gdataset.Tables("POSWISESALESUMMARYBEARER").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES SUMMARY -BEARERWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub POSWISESUMMARYUSERWISEexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel

        Dim sqlstring, SSQL As String
        sqlstring = " SELECT ISNULL(POSDESC,'') AS POSDESC ,ISNULL(MCODE,'') AS MEMBERCODE,ISNULL(MNAME,'')AS MEMBERNAME,ISNULL(BILLNO,'')AS BILLNO,"
        sqlstring = sqlstring & "ISNULL(BILLDATE,'')AS BILLDATE,ISNULL(BILLDETAILS,'')AS BILLDETAILS,ISNULL(BILLAMOUNT,0)AS AMOUNT,ISNULL(TAXAMOUNT,0)AS TAXAMOUNT,"
        sqlstring = sqlstring & "ISNULL(packamount,0)AS SERTAX,ISNULL(TOTALAMOUNT,0)AS TOTALAMOUNT,"
        sqlstring = sqlstring & "ISNULL(PAYMENTMODE,'')AS PAYMENTMODE,ISNULL(SERVERCODE,'')AS SERVERCODE,ISNULL(KOTDATE,'')AS KOTDATE,ISNULL(AddUserid,'')AS AddUserid,"
        sqlstring = sqlstring & "ISNULL(ServerName,'')AS SERVERNAME FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & "ORDER BY POSDESC,ADDUSERID,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSWISESALESUMMARYUSER")
        If gdataset.Tables("POSWISESALESUMMARYUSER").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES SUMMARY -USERWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub POSDETAILSexcel()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel

        Dim sqlstring, SSQL As String
        sqlstring = "SELECT * FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        '''''''''''BEARER NAME SELECTION REPORT 
        If Chklist_BEARERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SCODE IN ("
            For i = 0 To Chklist_BEARERNAME.CheckedItems.Count - 1
                servercode = Split(Chklist_BEARERNAME.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        ''''''''''''''''''USER NAME SELECTION FOR REPORT 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ADDUSERID IN ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSWISESALESUMMARY_DETAILS")
        If gdataset.Tables("POSWISESALESUMMARY_DETAILS").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES DETAILS " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub POSWISESUMMARYEXCEL()
        Dim i As Integer
        Dim exp As New exportexcel
        Dim servercode() As String
        Dim sqlstring, SSQL As String
        sqlstring = "SELECT  ISNULL(POSDESC,'') AS POSDESC ,ISNULL(MCODE,'') AS MEMBERCODE,ISNULL(MNAME,'')AS MEMBERNAME,ISNULL(BILLNO,'')AS BILLNO,"
        sqlstring = sqlstring & "ISNULL(BILLDATE,'')AS BILLDATE,ISNULL(BILLDETAILS,'')AS BILLDETAILS,ISNULL(BILLAMOUNT,0)AS AMOUNT,ISNULL(TAXAMOUNT,0)AS TAXAMOUNT,"
        sqlstring = sqlstring & "ISNULL(packamount,0)AS SERTAX,ISNULL(TOTALAMOUNT,0)AS TOTALAMOUNT,"
        sqlstring = sqlstring & "ISNULL(PAYMENTMODE,'')AS PAYMENTMODE,ISNULL(SERVERCODE,'')AS SERVERCODE,ISNULL(KOTDATE,'')AS KOTDATE,ISNULL(AddUserid,'')AS AddUserid,"
        sqlstring = sqlstring & "ISNULL(ServerName,'')AS SERVERNAME FROM POSWISESALESUMMARY WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For i = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''SERVER CODE SELECTION
        If Chklist_Servercode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND SERVERCODE IN ("
            For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
                servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
                'sqlstring = sqlstring & servercode(0) & ", "
                sqlstring = sqlstring & " '" & servercode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        '''''''''''''USER NAME SELECTION 
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY POSDESC,BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "POSWISESALESUMMARY")
        If gdataset.Tables("POSWISESALESUMMARY").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "POSWISE SALES SUMMARY " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    'Private Sub POSWISESUMMARYEXCE()
    '    Dim I, J, K As Integer
    '    sqlstring = "SELECT POSDESC,KOTDATE AS BILLDATE,MCODE,MNAME,BILLNO,BILLDETAILS,BILLAMOUNT,TAXAMOUNT,packamount AS STAX,TOTALAMOUNT,PAYMENTMODE  FROM POSWISESALESUMMARY WHERE "
    '    sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
    '    sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
    '    If Chklist_POSLocation.CheckedItems.Count <> 0 Then
    '        sqlstring = sqlstring & " AND POSDESC IN ("
    '        For I = 0 To Chklist_POSLocation.CheckedItems.Count - 1
    '            sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(I) & "', "
    '        Next
    '        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '        sqlstring = sqlstring & ")"
    '    End If
    '    'If Chklist_Servercode.CheckedItems.Count <> 0 Then
    '    '    sqlstring = sqlstring & " AND SERVERCODE IN ("
    '    '    For i = 0 To Chklist_Servercode.CheckedItems.Count - 1
    '    '        servercode = Split(Chklist_Servercode.CheckedItems(i), "==>")
    '    '        'sqlstring = sqlstring & servercode(0) & ", "
    '    '        sqlstring = sqlstring & " '" & servercode(0) & "', "
    '    '    Next
    '    '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '    '    sqlstring = sqlstring & ")"
    '    'End If
    '    If lstcategory.CheckedItems.Count <> 0 Then
    '        sqlstring = sqlstring & " and CATEGORY in ("
    '        For I = 0 To lstcategory.CheckedItems.Count - 1
    '            sqlstring = sqlstring & " '" & lstcategory.CheckedItems(I) & "', "
    '        Next
    '        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
    '        sqlstring = sqlstring & ")"
    '    End If
    '    sqlstring = sqlstring & "ORDER BY BILLDETAILS"
    '    vconn.getDataSet(sqlstring, "GROUP")
    '    SSGRIDT.ClearRange(1, 1, -1, -1, False)
    '    If gdataset.Tables("GROUP").Rows.Count > 0 Then
    '        With SSGRIDT
    '            .Row = 1
    '            .Col = 1
    '            .Text = "POS WISE SALE SUMMARY FOR " & Format(mskFromDate.Value, "yyyy-MM-dd") & " AND " & Format(mskToDate.Value, "yyyy-MM-dd") & ""
    '            For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
    '                .Row = 2
    '                .Col = K + 1
    '                .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
    '            Next
    '            '.Row = 1
    '            '.Col = 1
    '            '.Text = "ITEMCODE"
    '            '.Col = 2
    '            '.Text = "ITEMDESC"
    '            '.Col = 3
    '            '.Text = "ITEMTYPE"
    '            '.Col = 4
    '            '.Text = "GROUPCODE"
    '            '.Col = 5
    '            '.Text = "GROUPDESC"
    '            '.Col = 6
    '            '.Text = "QTY"
    '            '.Col = 7
    '            '.Text = "RATE"
    '            '.Col = 8
    '            '.Text = "UOM"
    '            '.Col = 9
    '            '.Text = "TAXAMOUNT"
    '            '.Col = 10
    '            '.Text = "SCHARGE"
    '            '.Col = 11
    '            '.Text = "PACKAMOUNT"
    '            '.Col = 12
    '            '.Text = "AMOUNT"
    '            '.Col = 13
    '            '.Text = "AMT"
    '            For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
    '                .Row = I + 3
    '                For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
    '                    .Col = J + 1
    '                    .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
    '                    'If J <= 9 Then
    '                    '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
    '                    'Else
    '                    '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
    '                    'End If
    '                Next
    '            Next
    '        End With
    '        Me.SSGRIDT.Visible = True
    '    End If
    '    Call ExportTo(SSGRIDT)
    'End Sub
    Private Sub POSWISESUMMARYEXCELDETAILS()
        Dim I, J, K As Integer
        sqlstring = "SELECT POSDESC,KOTNO,ITEMCODE,ITEMDESC,QTY,RATE,UOM,AMOUNT,SCODE,MCODE,MNAME,BILLNO,BILLDETAILS,BILLAMOUNT,TAXAMOUNT,TOTALAMOUNT,PAYMENTMODE ,SCHARGE ,stax,CATEGORY FROM POSWISESALESUMMARY_DETAILS WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,BILLDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        If Chklist_POSLocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND POSDESC IN ("
            For I = 0 To Chklist_POSLocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_POSLocation.CheckedItems(I) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & "ORDER BY BILLDETAILS"

        vconn.getDataSet(sqlstring, "GROUP")
        SSGRIDT.ClearRange(1, 1, -1, -1, False)
        If gdataset.Tables("GROUP").Rows.Count > 0 Then
            With SSGRIDT
                '.Row = 1
                '.Col = 1
                '.Text = "POS WISE SALE DETAILS FOR " & Format(mskFromDate.Value, "yyyy-MM-dd") & " AND " & Format(mskToDate.Value, "yyyy-MM-dd") & ""
                For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                    .Row = 2

                    .Col = K + 1
                    .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
                Next
                '.Row = 1
                '.Col = 1
                '.Text = "ITEMCODE"
                '.Col = 2
                '.Text = "ITEMDESC"
                '.Col = 3
                '.Text = "ITEMTYPE"
                '.Col = 4
                '.Text = "GROUPCODE"
                '.Col = 5
                '.Text = "GROUPDESC"
                '.Col = 6
                '.Text = "QTY"
                '.Col = 7
                '.Text = "RATE"
                '.Col = 8
                '.Text = "UOM"
                '.Col = 9
                '.Text = "TAXAMOUNT"
                '.Col = 10
                '.Text = "SCHARGE"
                '.Col = 11
                '.Text = "PACKAMOUNT"
                '.Col = 12
                '.Text = "AMOUNT"
                '.Col = 13
                '.Text = "AMT"
                For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
                    .Row = I + 3
                    For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                        .Col = J + 1
                        .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                        'If J <= 9 Then
                        '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                        'Else
                        '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        'End If
                    Next
                    SSGRIDT.MaxRows = SSGRIDT.MaxRows + 1
                Next
            End With
            Me.SSGRIDT.Visible = True
        End If
        Call ExportTo(SSGRIDT)
    End Sub

    Private Sub Chk_SelectAllUSERS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllUSERS.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllUSERS.Checked = True Then
            For i = 0 To Chklist_USERNAME.Items.Count - 1
                Chklist_USERNAME.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_USERNAME.Items.Count - 1
                Chklist_USERNAME.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllBEARERS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllBEARERS.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllBEARERS.Checked = True Then
            For i = 0 To Chklist_BEARERNAME.Items.Count - 1
                Chklist_BEARERNAME.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_BEARERNAME.Items.Count - 1
                Chklist_BEARERNAME.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub USERWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERWISE.CheckedChanged
        If USERWISE.Checked = True Then
            BEARERWISE.Checked = False
            DATEWISE.Checked = False
        Else
            'BEARERWISE.Checked = True
        End If
    End Sub

    Private Sub BEARERWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEARERWISE.CheckedChanged
        If BEARERWISE.Checked = True Then
            'USERWISE.Checked = False
            USERWISE.Checked = False
            DATEWISE.Checked = False
        Else
            ' USERWISE.Checked = True
        End If
    End Sub

    Private Sub Chklist_BEARERNAME_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chklist_BEARERNAME.SelectedIndexChanged

    End Sub

    Private Sub DATEWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATEWISE.CheckedChanged
        If DATEWISE.Checked = True Then
            'USERWISE.Checked = False
            BEARERWISE.Checked = False
            USERWISE.Checked = False
        Else
            ' USERWISE.Checked = True
        End If
    End Sub
End Class