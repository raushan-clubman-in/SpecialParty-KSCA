Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_TKGA_KOTBOOK
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    'Dim vconn As New GlobalClass
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Lbl_SerCode As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXT_SNOFROM As System.Windows.Forms.TextBox
    Friend WithEvents TXT_SNOTO As System.Windows.Forms.TextBox
    Friend WithEvents cmd_prefixhelp As System.Windows.Forms.Button
    Friend WithEvents cmd_delete As System.Windows.Forms.Button
    Friend WithEvents TXT_KOTBOOK As System.Windows.Forms.TextBox
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MSK_FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Chklist_Servermaster As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Chk_Taxtype As System.Windows.Forms.CheckBox
    Friend WithEvents TXT_PREFIX As System.Windows.Forms.ComboBox
    Friend WithEvents GRP_UPDATE As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMD_UPD As System.Windows.Forms.Button
    Friend WithEvents TXT_SNOTO1 As System.Windows.Forms.TextBox
    Friend WithEvents dtgrd As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_TKGA_KOTBOOK))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmd_prefixhelp = New System.Windows.Forms.Button()
        Me.Lbl_SerCode = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_SNOTO = New System.Windows.Forms.TextBox()
        Me.TXT_SNOFROM = New System.Windows.Forms.TextBox()
        Me.TXT_KOTBOOK = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MSK_FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_Taxtype = New System.Windows.Forms.CheckBox()
        Me.Chklist_Servermaster = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TXT_PREFIX = New System.Windows.Forms.ComboBox()
        Me.GRP_UPDATE = New System.Windows.Forms.GroupBox()
        Me.CMD_UPD = New System.Windows.Forms.Button()
        Me.TXT_SNOTO1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtgrd = New System.Windows.Forms.DataGrid()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GRP_UPDATE.SuspendLayout()
        CType(Me.dtgrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 634)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(280, 15)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(202, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 16)
        Me.Label16.TabIndex = 422
        Me.Label16.Text = "KOT BOOK ISSUES"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_prefixhelp
        '
        Me.cmd_prefixhelp.Image = CType(resources.GetObject("cmd_prefixhelp.Image"), System.Drawing.Image)
        Me.cmd_prefixhelp.Location = New System.Drawing.Point(560, 72)
        Me.cmd_prefixhelp.Name = "cmd_prefixhelp"
        Me.cmd_prefixhelp.Size = New System.Drawing.Size(23, 28)
        Me.cmd_prefixhelp.TabIndex = 3
        Me.cmd_prefixhelp.Visible = False
        '
        'Lbl_SerCode
        '
        Me.Lbl_SerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SerCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SerCode.Location = New System.Drawing.Point(52, 19)
        Me.Lbl_SerCode.Name = "Lbl_SerCode"
        Me.Lbl_SerCode.Size = New System.Drawing.Size(80, 21)
        Me.Lbl_SerCode.TabIndex = 424
        Me.Lbl_SerCode.Text = "BOOK NO"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXT_SNOTO)
        Me.GroupBox1.Controls.Add(Me.TXT_SNOFROM)
        Me.GroupBox1.Controls.Add(Me.TXT_KOTBOOK)
        Me.GroupBox1.Controls.Add(Me.cmd_prefixhelp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Lbl_SerCode)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(199, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(640, 56)
        Me.GroupBox1.TabIndex = 423
        Me.GroupBox1.TabStop = False
        '
        'TXT_SNOTO
        '
        Me.TXT_SNOTO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SNOTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_SNOTO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SNOTO.Location = New System.Drawing.Point(512, 18)
        Me.TXT_SNOTO.MaxLength = 8
        Me.TXT_SNOTO.Name = "TXT_SNOTO"
        Me.TXT_SNOTO.Size = New System.Drawing.Size(104, 21)
        Me.TXT_SNOTO.TabIndex = 5
        Me.TXT_SNOTO.Text = "0"
        Me.TXT_SNOTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_SNOFROM
        '
        Me.TXT_SNOFROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SNOFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_SNOFROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SNOFROM.Location = New System.Drawing.Point(328, 18)
        Me.TXT_SNOFROM.MaxLength = 8
        Me.TXT_SNOFROM.Name = "TXT_SNOFROM"
        Me.TXT_SNOFROM.Size = New System.Drawing.Size(96, 21)
        Me.TXT_SNOFROM.TabIndex = 4
        Me.TXT_SNOFROM.Text = "0"
        Me.TXT_SNOFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_KOTBOOK
        '
        Me.TXT_KOTBOOK.BackColor = System.Drawing.Color.Wheat
        Me.TXT_KOTBOOK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_KOTBOOK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_KOTBOOK.Location = New System.Drawing.Point(127, 18)
        Me.TXT_KOTBOOK.MaxLength = 6
        Me.TXT_KOTBOOK.Name = "TXT_KOTBOOK"
        Me.TXT_KOTBOOK.Size = New System.Drawing.Size(88, 21)
        Me.TXT_KOTBOOK.TabIndex = 431
        Me.TXT_KOTBOOK.Text = "0"
        Me.TXT_KOTBOOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(233, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 21)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "S.NO FROM"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(440, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 21)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "S.NO TO"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CmdView)
        Me.GroupBox2.Controls.Add(Me.CmdClear)
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.CmdAdd)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Location = New System.Drawing.Point(866, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 407)
        Me.GroupBox2.TabIndex = 429
        Me.GroupBox2.TabStop = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(3, 234)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 56)
        Me.CmdView.TabIndex = 3
        Me.CmdView.Text = " View [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(4, 36)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 0
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
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(2, 302)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.BackgroundImage = Global.SpecialParty.My.Resources.Resources.save
        Me.CmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(4, 103)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(131, 56)
        Me.CmdAdd.TabIndex = 1
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Delete
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(4, 166)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(131, 56)
        Me.Cmd_Freeze.TabIndex = 2
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 562)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 15)
        Me.Label6.TabIndex = 431
        Me.Label6.Text = "WITH EFFECT FROM :"
        '
        'MSK_FROMDATE
        '
        Me.MSK_FROMDATE.CustomFormat = "dd/MMM/yyyy"
        Me.MSK_FROMDATE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSK_FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MSK_FROMDATE.Location = New System.Drawing.Point(518, 559)
        Me.MSK_FROMDATE.Name = "MSK_FROMDATE"
        Me.MSK_FROMDATE.Size = New System.Drawing.Size(112, 21)
        Me.MSK_FROMDATE.TabIndex = 430
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Chk_Taxtype)
        Me.GroupBox3.Controls.Add(Me.Chklist_Servermaster)
        Me.GroupBox3.Location = New System.Drawing.Point(200, 187)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 328)
        Me.GroupBox3.TabIndex = 433
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(40, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(368, 24)
        Me.Label4.TabIndex = 435
        Me.Label4.Text = "WAITER LIST"
        '
        'Chk_Taxtype
        '
        Me.Chk_Taxtype.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Taxtype.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Taxtype.Location = New System.Drawing.Point(40, 41)
        Me.Chk_Taxtype.Name = "Chk_Taxtype"
        Me.Chk_Taxtype.Size = New System.Drawing.Size(128, 16)
        Me.Chk_Taxtype.TabIndex = 434
        Me.Chk_Taxtype.Text = "SELECT ALL"
        Me.Chk_Taxtype.UseVisualStyleBackColor = False
        Me.Chk_Taxtype.Visible = False
        '
        'Chklist_Servermaster
        '
        Me.Chklist_Servermaster.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Servermaster.Location = New System.Drawing.Point(40, 42)
        Me.Chklist_Servermaster.Name = "Chklist_Servermaster"
        Me.Chklist_Servermaster.Size = New System.Drawing.Size(368, 256)
        Me.Chklist_Servermaster.TabIndex = 433
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(453, 524)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(121, 15)
        Me.lbl_Freeze.TabIndex = 434
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Location = New System.Drawing.Point(216, 538)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(640, 56)
        Me.GroupBox4.TabIndex = 435
        Me.GroupBox4.TabStop = False
        '
        'TXT_PREFIX
        '
        Me.TXT_PREFIX.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_PREFIX.Location = New System.Drawing.Point(216, 40)
        Me.TXT_PREFIX.Name = "TXT_PREFIX"
        Me.TXT_PREFIX.Size = New System.Drawing.Size(168, 27)
        Me.TXT_PREFIX.TabIndex = 436
        Me.TXT_PREFIX.Visible = False
        '
        'GRP_UPDATE
        '
        Me.GRP_UPDATE.BackColor = System.Drawing.Color.Transparent
        Me.GRP_UPDATE.Controls.Add(Me.CMD_UPD)
        Me.GRP_UPDATE.Controls.Add(Me.TXT_SNOTO1)
        Me.GRP_UPDATE.Controls.Add(Me.Label7)
        Me.GRP_UPDATE.Location = New System.Drawing.Point(649, 180)
        Me.GRP_UPDATE.Name = "GRP_UPDATE"
        Me.GRP_UPDATE.Size = New System.Drawing.Size(200, 184)
        Me.GRP_UPDATE.TabIndex = 437
        Me.GRP_UPDATE.TabStop = False
        Me.GRP_UPDATE.Visible = False
        '
        'CMD_UPD
        '
        Me.CMD_UPD.BackColor = System.Drawing.Color.Transparent
        Me.CMD_UPD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMD_UPD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_UPD.ForeColor = System.Drawing.Color.Black
        Me.CMD_UPD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_UPD.Location = New System.Drawing.Point(40, 93)
        Me.CMD_UPD.Name = "CMD_UPD"
        Me.CMD_UPD.Size = New System.Drawing.Size(131, 56)
        Me.CMD_UPD.TabIndex = 427
        Me.CMD_UPD.Text = "UPDATE"
        Me.CMD_UPD.UseVisualStyleBackColor = False
        '
        'TXT_SNOTO1
        '
        Me.TXT_SNOTO1.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SNOTO1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_SNOTO1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SNOTO1.Location = New System.Drawing.Point(64, 40)
        Me.TXT_SNOTO1.MaxLength = 8
        Me.TXT_SNOTO1.Name = "TXT_SNOTO1"
        Me.TXT_SNOTO1.Size = New System.Drawing.Size(104, 21)
        Me.TXT_SNOTO1.TabIndex = 425
        Me.TXT_SNOTO1.Text = "0"
        Me.TXT_SNOTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 21)
        Me.Label7.TabIndex = 426
        Me.Label7.Text = "S.NO TO"
        '
        'dtgrd
        '
        Me.dtgrd.DataMember = ""
        Me.dtgrd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgrd.Location = New System.Drawing.Point(656, 493)
        Me.dtgrd.Name = "dtgrd"
        Me.dtgrd.Size = New System.Drawing.Size(346, 152)
        Me.dtgrd.TabIndex = 438
        '
        'FRM_TKGA_KOTBOOK
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1014, 692)
        Me.Controls.Add(Me.dtgrd)
        Me.Controls.Add(Me.GRP_UPDATE)
        Me.Controls.Add(Me.TXT_PREFIX)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MSK_FROMDATE)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "FRM_TKGA_KOTBOOK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KOTBOOK"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GRP_UPDATE.ResumeLayout(False)
        Me.GRP_UPDATE.PerformLayout()
        CType(Me.dtgrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Sub checkValidation()
        Try
            boolchk = False
            '''********** Check  Server Code Can't be blank *********************'''
            'If Trim(TXT_PREFIX.Text) = "" Then
            '    MessageBox.Show(" Prefix Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    TXT_PREFIX.Focus()
            '    Exit Sub
            'End If

            'If Trim(TXT_PREFIX.Text) = "" Then
            '    MessageBox.Show(" Prefix Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    TXT_PREFIX.Focus()
            '    Exit Sub
            'End If
            sqlstring = "select ISNULL(bookseries,0)as serial from possetup"
            gconnection.getDataSet(sqlstring, "boo")
            If gdataset.Tables("boo").Rows.Count > 0 Then
                If Len(TXT_SNOFROM.Text) > 3 Then
                    If Val(Mid(TXT_SNOFROM.Text, 4, Len(TXT_SNOFROM.Text) - 2)) - Val(Mid(TXT_SNOTO.Text, 4, Len(TXT_SNOTO.Text) - 2)) > Val(gdataset.Tables("boo").Rows(0).Item("serial")) Then
                        'If Val(Me.TXT_SNOTO.Text) - Val(Me.TXT_SNOFROM.Text) > Val(gdataset.Tables("boo").Rows(0).Item("serial")) Then
                        MessageBox.Show(" Serial No  exeeds limit ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        TXT_SNOFROM.Focus()
                        Exit Sub
                    End If
                Else
                    If Val(Me.TXT_SNOTO.Text) - Val(Me.TXT_SNOFROM.Text) > Val(gdataset.Tables("boo").Rows(0).Item("serial")) Then
                        MessageBox.Show(" Serial No  exeeds limit ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        TXT_SNOFROM.Focus()
                        Exit Sub
                    End If
                End If

                If Val(Me.TXT_SNOTO.Text) - Val(Me.TXT_SNOFROM.Text) < 0 Then
                    MessageBox.Show(" Serial No  not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_SNOFROM.Focus()
                    Exit Sub
                End If
            End If
            If Trim(TXT_SNOFROM.Text) = "" Then
                MessageBox.Show(" Serial No  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_SNOFROM.Focus()
                Exit Sub
            Else
                sqlstring = " SELECT *  FROM KOTBOOK WHERE  "
                sqlstring = sqlstring & TXT_SNOFROM.Text & " BETWEEN SNOFROM AND SNOTO "
                gconnection.getDataSet(sqlstring, "KOTBOOK")
                If gdataset.Tables("KOTBOOK").Rows.Count > 0 Then
                    MessageBox.Show(" This S.No Already Issued,Kidly Check It", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_SNOTO.Focus()
                    dtgrd.DataSource = Nothing
                    dtgrd.DataSource = gdataset.Tables("KOTBOOK")
                    Exit Sub
                End If

                If Val(TXT_SNOFROM.Text) > Val(TXT_SNOTO.Text) Then
                    MessageBox.Show("STARTING SNO SHOULD BE LESS THEN ENDING SNO ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_SNOFROM.Focus()
                    Exit Sub
                End If
            End If
            If Trim(TXT_SNOTO.Text) = "" Then
                MessageBox.Show(" Serial No  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_SNOTO.Focus()
                Exit Sub
            Else
                sqlstring = " SELECT *  FROM KOTBOOK WHERE  "
                sqlstring = sqlstring & TXT_SNOTO.Text & " BETWEEN SNOFROM AND SNOTO "
                gconnection.getDataSet(sqlstring, "KOTBOOK")
                If gdataset.Tables("KOTBOOK").Rows.Count > 0 Then
                    MessageBox.Show(" This S.No Already Issued,Kidly Check It", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_SNOTO.Focus()
                    dtgrd.DataSource = Nothing
                    dtgrd.DataSource = gdataset.Tables("KOTBOOK")
                    Exit Sub
                End If
            End If
            If Format(Now(), "dd/MM/yyyy") < Format(MSK_FROMDATE.Value, "dd/MM/yyyy") Then
                MessageBox.Show("Issue Date  can't be Less then SystemDate ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                MSK_FROMDATE.Focus()
                Exit Sub
            End If
            boolchk = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub TXT_PREFIX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getCharater(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_PREFIX.Text <> "" Then
                TXT_SNOFROM.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_SNOTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SNOTO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_SNOTO.Text <> "" Then
                Chklist_Servermaster.Focus()
                'TXT_KOTBOOK.Focus()

            End If
        End If
    End Sub
    Private Sub TXT_SNOFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SNOFROM.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_SNOFROM.Text <> "" Then
                TXT_SNOTO.Focus()
            End If
        End If
    End Sub
    Private Sub MSK_FROMDATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If MSK_FROMDATE.Text <> "" Then
                CmdAdd.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_SNOFROM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_SNOFROM.LostFocus
        TXT_SNOFROM.Text = Format(Val(TXT_SNOFROM.Text), "0")
        'If Val(TXT_SNOTO.Text) = 0 Then
        sqlstring = "select ISNULL(bookseries,0)as serial from possetup"
        gconnection.getDataSet(sqlstring, "boo")
        If gdataset.Tables("boo").Rows.Count > 0 Then
            If Len(TXT_SNOFROM.Text) > 3 Then
                TXT_SNOTO.Text = Mid(TXT_SNOFROM.Text, 1, 3) & Val(Mid(TXT_SNOFROM.Text, 4, Len(TXT_SNOFROM.Text) - 2)) + Val(gdataset.Tables("boo").Rows(0).Item("serial"))
            Else
                TXT_SNOTO.Text = Val(TXT_SNOFROM.Text) + Val(gdataset.Tables("boo").Rows(0).Item("serial"))
            End If
        Else
            TXT_SNOTO.Text = Val(TXT_SNOFROM.Text) + 49
        End If

        'End If
    End Sub
    Private Sub TXT_SNOTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_SNOTO.LostFocus
        TXT_SNOTO.Text = Format(Val(TXT_SNOTO.Text), "0")
        Call svalied()
    End Sub
    Sub Text_Clear()
        Chk_Taxtype.Checked = False
        TXT_SNOTO.Text = 0
        TXT_SNOFROM.Text = 0
        CmdAdd.Enabled = True
        TXT_KOTBOOK.Text = ""
        MSK_FROMDATE.Value = Now()
        TXT_PREFIX.Text = ""
        Me.TXT_SNOTO1.Text = ""
        'TXT_PREFIX.Focus()
        TXT_KOTBOOK.Focus()
        Fillservermaster()
        Me.GRP_UPDATE.Visible = False
    End Sub
    Private Sub KOTBOOK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Text_Clear()
    End Sub
    Private Sub Fillservermaster()
        Dim i As Integer
        Chklist_Servermaster.Items.Clear()
        sqlstring = "SELECT DISTINCT servercode,SERVERNAME FROM servermaster WHERE ISNULL(Freeze,'')<>'Y'  --ORDER BY CONVERT(INT,SERVERCODE)"
        gconnection.getDataSet(sqlstring, "kot")
        If gdataset.Tables("KOT").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("KOT").Rows.Count - 1
                With gdataset.Tables("KOT").Rows(i)
                    Chklist_Servermaster.Items.Add(Trim(.Item("SERVERCODE")) & Space(3) & "-->" & Trim(.Item("SERVERNAME")))
                End With
            Next i
        End If
        gconnection.closeConnection()
        Chklist_Servermaster.Sorted = True
    End Sub

    Private Sub TXT_PREFIX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmd_prefixhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_prefixhelp.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub TXT_SNOTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_SNOTO.TextChanged

    End Sub
    Private Sub svalied()
        Dim i, J As Integer
        Dim SCODE(0) As String
        'PREFIX='" & TXT_PREFIX.Text & "' AND "
        sqlstring = " SELECT DISTINCT SERVERCODE,SERVERNAME,ISNULL(BOOKNO,0) AS BOOKNO FROM KOTBOOK  WHERE "
        sqlstring = sqlstring & " snoFrom=" & IIf(Len(TXT_SNOFROM.Text) > 0, TXT_SNOFROM.Text, 0) & " AND snoto=" & IIf(Len(TXT_SNOTO.Text) > 0, TXT_SNOTO.Text, 0)
        gconnection.getDataSet(sqlstring, "SMST")
        If gdataset.Tables("SMST").Rows.Count > 0 Then
            CmdAdd.Enabled = True
            For i = 0 To gdataset.Tables("SMST").Rows.Count - 1
                For J = 0 To Chklist_Servermaster.Items.Count - 1
                    SCODE = Split(Chklist_Servermaster.Items(J), "-->")
                    If Trim(gdataset.Tables("SMST").Rows(i).Item("SERVERCODE")) = Trim(SCODE(0)) Then
                        Chklist_Servermaster.SetItemChecked(J, True)
                        Exit For
                    End If
                Next
            Next
            TXT_KOTBOOK.Text = gdataset.Tables("SMST").Rows(0).Item("BOOKNO")
            dtgrd.DataSource = Nothing
            dtgrd.DataSource = gdataset.Tables("SMST")
            MessageBox.Show(" THIS SERIAL ALREADY ENTERED.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.GRP_UPDATE.Visible = True
        End If
        Chklist_Servermaster.Sorted = True
    End Sub
    Private Sub TXT_KOTBOOK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_KOTBOOK.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TXT_SNOTO.Text <> "" Then
                TXT_SNOFROM.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_KOTBOOK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_KOTBOOK.LostFocus
        TXT_KOTBOOK.Text = Format(Val(TXT_KOTBOOK.Text), "0")
    End Sub
    Private Sub KOTBOOK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If cmd_delete.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If

        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            End If

        ElseIf e.KeyCode = Keys.F9 Then
            If Cmd_View.Enabled = True Then
                Call CmdView_Click(CmdView, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        End If
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Try
            If CmdAdd.Text = "Add [F7]" Then
                Dim I As Integer
                Call checkValidation() ''--->Check Validation
                If boolchk = False Then Exit Sub
                Dim INSERT(0) As String
                Dim SCODE(0) As String
                sqlstring = "Delete From kotbook "
                sqlstring = sqlstring & " where prefix='" & TXT_PREFIX.Text & "' "
                sqlstring = sqlstring & " and snoFrom=" & Val(TXT_SNOFROM.Text)
                sqlstring = sqlstring & " and snoTo=" & Val(TXT_SNOTO.Text)
                INSERT(0) = sqlstring
                If Chklist_Servermaster.CheckedItems.Count <> 0 Then
                    For I = 0 To Chklist_Servermaster.CheckedItems.Count - 1
                        SCODE = Split(Chklist_Servermaster.CheckedItems(I), "-->")
                        sqlstring = "INSERT INTO KOTBOOK(SERVERCODE,SERVERNAME,BOOKNO,PREFIX,SNOFROM,SNOTO,EFFECTFROMDT,ADDDATETIME,USERNAME,DELFLAG)"
                        sqlstring = sqlstring & " VALUES ( '" & Trim(SCODE(0)) & "','"
                        sqlstring = sqlstring & Trim(SCODE(1)) & "','"
                        sqlstring = sqlstring & Trim(TXT_KOTBOOK.Text) & "','"
                        sqlstring = sqlstring & TXT_PREFIX.Text & "',"
                        sqlstring = sqlstring & IIf(Val(TXT_SNOFROM.Text) > 0, Val(TXT_SNOFROM.Text), 0) & ","
                        sqlstring = sqlstring & IIf(Val(TXT_SNOTO.Text) > 0, Val(TXT_SNOTO.Text), 0) & ",'"
                        sqlstring = sqlstring & Format(MSK_FROMDATE.Value, " dd/MMM/yyyy") & "','"
                        sqlstring = sqlstring & Format(Now, " dd/MMM/yyyy hh:mm:ss") & "','"
                        sqlstring = sqlstring & gUsername & "','"
                        sqlstring = sqlstring & "N')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    Next
                Else
                    MessageBox.Show("Select the Server(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                gconnection.MoreTransold(INSERT)
                Me.CmdClear_Click(sender, e)
            ElseIf CmdAdd.Text = "Update[F7]" Then
                Call checkValidation() '''--->Check Validation
                If boolchk = False Then Exit Sub
                If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        boolchk = False
                        Exit Sub
                    End If
                End If
                'sqlstring = "UPDATE  KOTBOOK SET "
                'gconnection.dataOperation(2, sqlstring, "ServerMaster")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Dim INSERT(0), SCODE(0) As String
        sqlstring = "Delete From KOTBOOK "
        sqlstring = sqlstring & " where prefix='" & TXT_PREFIX.Text & "' "
        sqlstring = sqlstring & " and snoFrom=" & Val(TXT_SNOFROM.Text)
        sqlstring = sqlstring & " and snoTo=" & Val(TXT_SNOTO.Text)
        INSERT(0) = sqlstring
        gconnection.MoreTransold(INSERT)
        CmdClear_Click(sender, e)
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        'Dim FrReport As New ReportDesigner
        'tables = " FROM KOTBOOK"
        'Gheader = "KOT BOOK ISSUE"
        'FrReport.SsGridReport.SetText(2, 1, "SERVERCODE")
        'FrReport.SsGridReport.SetText(3, 1, 10)
        'FrReport.SsGridReport.SetText(2, 2, "SERVERNAME")
        'FrReport.SsGridReport.SetText(3, 2, 30)
        'FrReport.SsGridReport.SetText(2, 3, "PREFIX")
        'FrReport.SsGridReport.SetText(3, 3, 5)
        'FrReport.SsGridReport.SetText(2, 4, "SNOFROM")
        'FrReport.SsGridReport.SetText(3, 4, 10)
        'FrReport.SsGridReport.SetText(2, 5, "SNOTO")
        'FrReport.SsGridReport.SetText(3, 5, 15)
        'FrReport.SsGridReport.SetText(2, 6, "EFFECTFROMDT")
        'FrReport.SsGridReport.SetText(3, 6, 15)
        'FrReport.SsGridReport.SetText(2, 7, "USERNAME")
        'FrReport.SsGridReport.SetText(3, 7, 10)
        'FrReport.SsGridReport.SetText(2, 8, "BOOKNO")
        'FrReport.SsGridReport.SetText(3, 8, 10)
        'FrReport.Show()
        Dim FRM As New ReportDesigner
        'If txtItemCode.Text.Length > 0 Then
        'les = " FROM ITEMMASTER WHERE ITEMCODE ='" & txtItemCode.Text & "' "
        'Else
        tables = "FROM KOTBOOK "
        'End If
        Gheader = "KOTBOOK DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"SERVERCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SERVERNAME", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PREFIX", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SNOFROM", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SNOTO", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"EFFECTFROMDT", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"USERNAME", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BOOKNO", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call Text_Clear()
        dtgrd.DataSource = Nothing
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Hide()
    End Sub
    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub
    Private Sub TXT_SNOFROM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_SNOFROM.TextChanged

    End Sub

    Private Sub MSK_FROMDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TXT_KOTBOOK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_KOTBOOK.TextChanged

    End Sub

    Private Sub Chklist_Servermaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Chk_Taxtype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Taxtype.CheckedChanged
        Try
            Dim i As Integer
            If Chk_Taxtype.Checked = True Then
                For i = 0 To Chklist_Servermaster.Items.Count - 1
                    Chklist_Servermaster.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To Chklist_Servermaster.Items.Count - 1
                    Chklist_Servermaster.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lbl_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CMD_UPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_UPD.Click
        Dim INSERT(0) As String
        sqlstring = "UPDATE KOTBOOK SET SNOTO=" & IIf(Val(TXT_SNOTO1.Text) > 0, Val(TXT_SNOTO1.Text), 0) & " WHERE BOOKNO='" & Trim(TXT_KOTBOOK.Text) & "' AND   prefix='" & TXT_PREFIX.Text & "'  and snoFrom=" & Val(TXT_SNOFROM.Text) & " And snoTo = " & Val(TXT_SNOTO.Text)
        INSERT(0) = sqlstring
        gconnection.MoreTransold(INSERT)
        CmdClear_Click(sender, e)
    End Sub
End Class

