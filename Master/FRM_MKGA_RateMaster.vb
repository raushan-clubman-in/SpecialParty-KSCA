Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_RateMaster
    Inherits System.Windows.Forms.Form
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim ssql, vPOint, vGroup, vcategory, vsubgroup, vitem As String
    Dim i As Integer
    Friend WithEvents Rdorate As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Dim boolmask As Boolean = False
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDateHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNearest As System.Windows.Forms.RadioButton
    Friend WithEvents OptNone As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptPercentage As System.Windows.Forms.RadioButton
    Friend WithEvents OptValue As System.Windows.Forms.RadioButton
    Friend WithEvents txtChangeValue As System.Windows.Forms.TextBox
    Friend WithEvents LstGroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents LstPOS As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdRoundoff As System.Windows.Forms.Button
    Friend WithEvents cmdValueby As System.Windows.Forms.Button
    Friend WithEvents mskdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkFreeze As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRNDVAL As System.Windows.Forms.ComboBox
    Friend WithEvents LstCATEGORY As System.Windows.Forms.CheckedListBox
    Friend WithEvents LstSUBGROUP As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Chkitems As System.Windows.Forms.CheckBox
    Friend WithEvents Lstitems As System.Windows.Forms.CheckedListBox
    Friend WithEvents SELECTGROUP As System.Windows.Forms.CheckBox
    Friend WithEvents selectsubgroup As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdoprevious As System.Windows.Forms.RadioButton
    Friend WithEvents Rdoexisting As System.Windows.Forms.RadioButton
    Friend WithEvents Rdonew As System.Windows.Forms.RadioButton
    Friend WithEvents Rdomodified As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_RateMaster))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdDateHelp = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdValueby = New System.Windows.Forms.Button()
        Me.OptPercentage = New System.Windows.Forms.RadioButton()
        Me.OptValue = New System.Windows.Forms.RadioButton()
        Me.txtChangeValue = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CHKRNDVAL = New System.Windows.Forms.ComboBox()
        Me.cmdRoundoff = New System.Windows.Forms.Button()
        Me.OptNearest = New System.Windows.Forms.RadioButton()
        Me.OptNone = New System.Windows.Forms.RadioButton()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkFreeze = New System.Windows.Forms.CheckBox()
        Me.LstGroup = New System.Windows.Forms.CheckedListBox()
        Me.LstPOS = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.LstCATEGORY = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SELECTGROUP = New System.Windows.Forms.CheckBox()
        Me.LstSUBGROUP = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.selectsubgroup = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chkitems = New System.Windows.Forms.CheckBox()
        Me.Lstitems = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Rdorate = New System.Windows.Forms.RadioButton()
        Me.Rdomodified = New System.Windows.Forms.RadioButton()
        Me.Rdonew = New System.Windows.Forms.RadioButton()
        Me.Rdoexisting = New System.Windows.Forms.RadioButton()
        Me.Rdoprevious = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.ssGrid)
        Me.GroupBox4.Location = New System.Drawing.Point(180, 344)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(672, 224)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'ssGrid
        '
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(8, 16)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(657, 200)
        Me.ssGrid.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(193, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 324
        Me.Label16.Text = "RATE MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(311, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 14)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "WITH EFFECT FROM :"
        '
        'cmdDateHelp
        '
        Me.cmdDateHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDateHelp.Location = New System.Drawing.Point(631, 161)
        Me.cmdDateHelp.Name = "cmdDateHelp"
        Me.cmdDateHelp.Size = New System.Drawing.Size(34, 22)
        Me.cmdDateHelp.TabIndex = 2
        Me.cmdDateHelp.Text = "F4"
        Me.cmdDateHelp.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtRate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkFreeze)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 567)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 143)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdValueby)
        Me.GroupBox3.Controls.Add(Me.OptPercentage)
        Me.GroupBox3.Controls.Add(Me.OptValue)
        Me.GroupBox3.Controls.Add(Me.txtChangeValue)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(13, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 80)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CHANGE EFFECT IN"
        Me.GroupBox3.Visible = False
        '
        'cmdValueby
        '
        Me.cmdValueby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdValueby.ForeColor = System.Drawing.Color.Blue
        Me.cmdValueby.Location = New System.Drawing.Point(208, 16)
        Me.cmdValueby.Name = "cmdValueby"
        Me.cmdValueby.Size = New System.Drawing.Size(48, 40)
        Me.cmdValueby.TabIndex = 3
        Me.cmdValueby.Text = "Value Chg"
        '
        'OptPercentage
        '
        Me.OptPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptPercentage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptPercentage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptPercentage.Location = New System.Drawing.Point(10, 56)
        Me.OptPercentage.Name = "OptPercentage"
        Me.OptPercentage.Size = New System.Drawing.Size(102, 16)
        Me.OptPercentage.TabIndex = 2
        Me.OptPercentage.Text = "PERCENTAGE"
        '
        'OptValue
        '
        Me.OptValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptValue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptValue.Location = New System.Drawing.Point(10, 24)
        Me.OptValue.Name = "OptValue"
        Me.OptValue.Size = New System.Drawing.Size(80, 16)
        Me.OptValue.TabIndex = 1
        Me.OptValue.Text = "VALUE"
        '
        'txtChangeValue
        '
        Me.txtChangeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeValue.Location = New System.Drawing.Point(112, 48)
        Me.txtChangeValue.MaxLength = 10
        Me.txtChangeValue.Name = "txtChangeValue"
        Me.txtChangeValue.Size = New System.Drawing.Size(84, 20)
        Me.txtChangeValue.TabIndex = 3
        Me.txtChangeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CHKRNDVAL)
        Me.GroupBox2.Controls.Add(Me.cmdRoundoff)
        Me.GroupBox2.Controls.Add(Me.OptNearest)
        Me.GroupBox2.Controls.Add(Me.OptNone)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(351, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 63)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ROUNDED OFF"
        Me.GroupBox2.Visible = False
        '
        'CHKRNDVAL
        '
        Me.CHKRNDVAL.Items.AddRange(New Object() {"0", "10"})
        Me.CHKRNDVAL.Location = New System.Drawing.Point(128, 48)
        Me.CHKRNDVAL.Name = "CHKRNDVAL"
        Me.CHKRNDVAL.Size = New System.Drawing.Size(77, 22)
        Me.CHKRNDVAL.TabIndex = 3
        '
        'cmdRoundoff
        '
        Me.cmdRoundoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRoundoff.ForeColor = System.Drawing.Color.Blue
        Me.cmdRoundoff.Location = New System.Drawing.Point(224, 16)
        Me.cmdRoundoff.Name = "cmdRoundoff"
        Me.cmdRoundoff.Size = New System.Drawing.Size(56, 39)
        Me.cmdRoundoff.TabIndex = 2
        Me.cmdRoundoff.Text = "Round Off"
        '
        'OptNearest
        '
        Me.OptNearest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNearest.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptNearest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNearest.Location = New System.Drawing.Point(24, 48)
        Me.OptNearest.Name = "OptNearest"
        Me.OptNearest.Size = New System.Drawing.Size(104, 16)
        Me.OptNearest.TabIndex = 2
        Me.OptNearest.Text = "NEAREST RS."
        '
        'OptNone
        '
        Me.OptNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNone.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptNone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNone.Location = New System.Drawing.Point(24, 18)
        Me.OptNone.Name = "OptNone"
        Me.OptNone.Size = New System.Drawing.Size(56, 16)
        Me.OptNone.TabIndex = 1
        Me.OptNone.Text = "NONE"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.White
        Me.txtRate.Location = New System.Drawing.Point(40, 40)
        Me.txtRate.MaxLength = 20
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(8, 21)
        Me.txtRate.TabIndex = 1
        Me.txtRate.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 14)
        Me.Label7.TabIndex = 344
        Me.Label7.Text = "RATE CHARGE BY :"
        Me.Label7.Visible = False
        '
        'chkFreeze
        '
        Me.chkFreeze.ForeColor = System.Drawing.Color.Maroon
        Me.chkFreeze.Location = New System.Drawing.Point(415, 21)
        Me.chkFreeze.Name = "chkFreeze"
        Me.chkFreeze.Size = New System.Drawing.Size(112, 24)
        Me.chkFreeze.TabIndex = 427
        Me.chkFreeze.Text = "FREEZE"
        Me.chkFreeze.Visible = False
        '
        'LstGroup
        '
        Me.LstGroup.BackColor = System.Drawing.Color.White
        Me.LstGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstGroup.Location = New System.Drawing.Point(477, 233)
        Me.LstGroup.Name = "LstGroup"
        Me.LstGroup.Size = New System.Drawing.Size(121, 109)
        Me.LstGroup.TabIndex = 3
        '
        'LstPOS
        '
        Me.LstPOS.BackColor = System.Drawing.Color.White
        Me.LstPOS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPOS.Location = New System.Drawing.Point(181, 235)
        Me.LstPOS.Name = "LstPOS"
        Me.LstPOS.Size = New System.Drawing.Size(170, 109)
        Me.LstPOS.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(190, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 345
        Me.Label3.Text = "SELECT POS "
        '
        'mskdate
        '
        Me.mskdate.CustomFormat = "dd/MM/yyyy"
        Me.mskdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskdate.Location = New System.Drawing.Point(487, 161)
        Me.mskdate.Name = "mskdate"
        Me.mskdate.Size = New System.Drawing.Size(136, 20)
        Me.mskdate.TabIndex = 16
        Me.mskdate.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(715, 716)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 22)
        Me.lbl_Freeze.TabIndex = 335
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(869, 218)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 53)
        Me.CmdClear.TabIndex = 330
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(868, 360)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 53)
        Me.CmdView.TabIndex = 333
        Me.CmdView.Text = " View[F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.SpecialParty.My.Resources.Resources.Delete
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(869, 289)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(131, 53)
        Me.Cmd_Freeze.TabIndex = 332
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.SpecialParty.My.Resources.Resources.save
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(868, 144)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(131, 53)
        Me.CmdAdd.TabIndex = 331
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(867, 575)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 53)
        Me.cmdexit.TabIndex = 334
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Maroon
        Me.CheckBox1.Location = New System.Drawing.Point(223, 192)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox1.TabIndex = 418
        Me.CheckBox1.Text = "SELECT ALL"
        Me.CheckBox1.UseVisualStyleBackColor = False
        Me.CheckBox1.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Maroon
        Me.CheckBox2.Location = New System.Drawing.Point(362, 191)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox2.TabIndex = 421
        Me.CheckBox2.Text = "SELECT ALL"
        Me.CheckBox2.UseVisualStyleBackColor = False
        Me.CheckBox2.Visible = False
        '
        'LstCATEGORY
        '
        Me.LstCATEGORY.BackColor = System.Drawing.Color.White
        Me.LstCATEGORY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstCATEGORY.Location = New System.Drawing.Point(357, 234)
        Me.LstCATEGORY.Name = "LstCATEGORY"
        Me.LstCATEGORY.Size = New System.Drawing.Size(112, 109)
        Me.LstCATEGORY.TabIndex = 419
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(359, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 14)
        Me.Label4.TabIndex = 420
        Me.Label4.Text = "SELECT CATEGORY"
        '
        'SELECTGROUP
        '
        Me.SELECTGROUP.BackColor = System.Drawing.Color.Transparent
        Me.SELECTGROUP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SELECTGROUP.ForeColor = System.Drawing.Color.Maroon
        Me.SELECTGROUP.Location = New System.Drawing.Point(482, 191)
        Me.SELECTGROUP.Name = "SELECTGROUP"
        Me.SELECTGROUP.Size = New System.Drawing.Size(112, 24)
        Me.SELECTGROUP.TabIndex = 424
        Me.SELECTGROUP.Text = "SELECT ALL"
        Me.SELECTGROUP.UseVisualStyleBackColor = False
        Me.SELECTGROUP.Visible = False
        '
        'LstSUBGROUP
        '
        Me.LstSUBGROUP.BackColor = System.Drawing.Color.White
        Me.LstSUBGROUP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstSUBGROUP.Location = New System.Drawing.Point(603, 234)
        Me.LstSUBGROUP.Name = "LstSUBGROUP"
        Me.LstSUBGROUP.Size = New System.Drawing.Size(106, 109)
        Me.LstSUBGROUP.TabIndex = 422
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(494, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 14)
        Me.Label6.TabIndex = 423
        Me.Label6.Text = "SELECT GROUP"
        '
        'selectsubgroup
        '
        Me.selectsubgroup.BackColor = System.Drawing.Color.Transparent
        Me.selectsubgroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectsubgroup.ForeColor = System.Drawing.Color.Maroon
        Me.selectsubgroup.Location = New System.Drawing.Point(600, 192)
        Me.selectsubgroup.Name = "selectsubgroup"
        Me.selectsubgroup.Size = New System.Drawing.Size(112, 24)
        Me.selectsubgroup.TabIndex = 425
        Me.selectsubgroup.Text = "SELECT ALL"
        Me.selectsubgroup.UseVisualStyleBackColor = False
        Me.selectsubgroup.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(600, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 14)
        Me.Label8.TabIndex = 426
        Me.Label8.Text = "SELECT SUBGROUP"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(729, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 14)
        Me.Label9.TabIndex = 429
        Me.Label9.Text = "SELECT ITEM"
        '
        'Chkitems
        '
        Me.Chkitems.BackColor = System.Drawing.Color.Transparent
        Me.Chkitems.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkitems.ForeColor = System.Drawing.Color.Maroon
        Me.Chkitems.Location = New System.Drawing.Point(697, 192)
        Me.Chkitems.Name = "Chkitems"
        Me.Chkitems.Size = New System.Drawing.Size(176, 24)
        Me.Chkitems.TabIndex = 430
        Me.Chkitems.Text = "ALT + I   TO SEARCH"
        Me.Chkitems.UseVisualStyleBackColor = False
        '
        'Lstitems
        '
        Me.Lstitems.BackColor = System.Drawing.Color.White
        Me.Lstitems.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lstitems.Location = New System.Drawing.Point(712, 233)
        Me.Lstitems.Name = "Lstitems"
        Me.Lstitems.Size = New System.Drawing.Size(138, 109)
        Me.Lstitems.TabIndex = 428
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Rdorate)
        Me.GroupBox6.Controls.Add(Me.Rdomodified)
        Me.GroupBox6.Controls.Add(Me.Rdonew)
        Me.GroupBox6.Controls.Add(Me.Rdoexisting)
        Me.GroupBox6.Controls.Add(Me.Rdoprevious)
        Me.GroupBox6.Location = New System.Drawing.Point(180, 115)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(665, 40)
        Me.GroupBox6.TabIndex = 431
        Me.GroupBox6.TabStop = False
        '
        'Rdorate
        '
        Me.Rdorate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdorate.Location = New System.Drawing.Point(504, 11)
        Me.Rdorate.Name = "Rdorate"
        Me.Rdorate.Size = New System.Drawing.Size(136, 24)
        Me.Rdorate.TabIndex = 436
        Me.Rdorate.Text = " RATE HISTORY"
        Me.Rdorate.Visible = False
        '
        'Rdomodified
        '
        Me.Rdomodified.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdomodified.Location = New System.Drawing.Point(704, -12)
        Me.Rdomodified.Name = "Rdomodified"
        Me.Rdomodified.Size = New System.Drawing.Size(136, 24)
        Me.Rdomodified.TabIndex = 435
        Me.Rdomodified.Text = "MODIFIED RATE"
        Me.Rdomodified.Visible = False
        '
        'Rdonew
        '
        Me.Rdonew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdonew.Location = New System.Drawing.Point(349, 10)
        Me.Rdonew.Name = "Rdonew"
        Me.Rdonew.Size = New System.Drawing.Size(136, 24)
        Me.Rdonew.TabIndex = 434
        Me.Rdonew.Text = "NEW RATE"
        '
        'Rdoexisting
        '
        Me.Rdoexisting.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdoexisting.Location = New System.Drawing.Point(182, 10)
        Me.Rdoexisting.Name = "Rdoexisting"
        Me.Rdoexisting.Size = New System.Drawing.Size(136, 24)
        Me.Rdoexisting.TabIndex = 433
        Me.Rdoexisting.Text = "EXISTING RATE"
        '
        'Rdoprevious
        '
        Me.Rdoprevious.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdoprevious.Location = New System.Drawing.Point(19, 10)
        Me.Rdoprevious.Name = "Rdoprevious"
        Me.Rdoprevious.Size = New System.Drawing.Size(136, 24)
        Me.Rdoprevious.TabIndex = 432
        Me.Rdoprevious.Text = "PREVIOUS RATE"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(868, 507)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 53)
        Me.Button1.TabIndex = 432
        Me.Button1.Text = "Authorize"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(869, 432)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 53)
        Me.Button2.TabIndex = 433
        Me.Button2.Text = " Browse"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FRM_MKGA_RateMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chkitems)
        Me.Controls.Add(Me.Lstitems)
        Me.Controls.Add(Me.selectsubgroup)
        Me.Controls.Add(Me.SELECTGROUP)
        Me.Controls.Add(Me.LstSUBGROUP)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.LstCATEGORY)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.mskdate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdDateHelp)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LstPOS)
        Me.Controls.Add(Me.LstGroup)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_RateMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RATE MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub FRM_MKGA_RateMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillPOS()
        Call FillCATEGORY()
        Call FillGroup()
        Call FILLSUBGROUP()
        Call FillItems()
        Call filllstitems()
        OptNone.Checked = True
        OptValue.Checked = True
        RateMastbool = True
        mskdate.Value = Now
        mskdate.Focus()
        CmdAdd.Text = "Update[F7]"
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
        Me.CmdAdd.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.CmdView.Enabled = True
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
                    Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub ClearOperation()
        ssGrid.ClearRange(1, 1, -1, -1, True)
        OptNone.Checked = True
        OptValue.Checked = True
        LstPOS.Items.Clear()
        Rdonew.Checked = False
        Rdoprevious.Checked = False
        Rdoexisting.Checked = False
        Rdorate.Checked = False
        LstGroup.Items.Clear()
        CheckBox1.Checked = False
        txtRate.Text = ""
        txtChangeValue.Text = ""
        txtChangeValue.MaxLength = 10
        txtRate.MaxLength = 50
        CmdAdd.Text = "Update[F7]"
        Call FillPOS()
        Call FillCATEGORY()
        Call FillGroup()
        Call FillItems()
        Call FILLSUBGROUP()
        Call filllstitems()
        mskdate.Focus()
    End Sub
    Private Sub FillItems()
        ssql = " SELECT R.RPOSCODE AS POS,I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.STARTINGDATE AS STARTINGDATE"
        ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN RateMaster AS R ON I.ITEMCODE = R.ITEMCODE"
        ssql = ssql & " INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE ISNULL(R.ENDINGDATE,'') = ''" 'R.STARTINGDATE IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND 
        ssql = ssql & " GROUP BY I.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate"
        ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
        vconn.getDataSet(ssql, "ITEMMASTER")
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
            For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                    ssGrid.MaxRows = ssGrid.Row + 500
                End If
                With ssGrid
                    .Row = i
                    .Col = 1
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                    .Col = 2
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                    .Col = 3
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                    .Col = 4
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                    '.Col = 5
                    '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                    .Col = 6
                    .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                    .Col = 7
                    .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                    '.Col = 8
                    '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                    '.Col = 9
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                    '.Col = 12
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                    '.Col = 13
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                    .Col = 11
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                End With
                'mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
            Next
        End If
    End Sub
    Private Sub FRM_MKGA_RateMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call ClearOperation()
        End If
        'If e.KeyCode = Keys.F7 Then
        '    Call CmdAdd_Click(CmdAdd, e)
        'End If
        'If e.KeyCode = Keys.F9 Then

        'End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                'Call Cmd_Freeze(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(CmdView, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(cmdexit, e)
        End If
        If e.KeyCode = Keys.F4 And boolmask = True Then
            Call cmdDateHelp_Click(sender, e)
        End If
        'If e.Alt = True And e.KeyCode = Keys.I Then
        '    Dim lstAdvSearch As New frmListSearch
        '    lstAdvSearch.listbox = Lstitems
        '    lstAdvSearch.Text = "Item Search"
        '    lstAdvSearch.ShowDialog(Me)
        'End If
    End Sub
    Private Sub FillPOS()
        LstCATEGORY.Items.Clear()
        ssql = "SELECT POSCODE,POSDESC,POSSEQNO FROM POSMaster  WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY POSCODE"
        vconn.getDataSet(ssql, "POSMASTER")
        If gdataset.Tables("POSMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POSMASTER").Rows.Count - 1
                With gdataset.Tables("POSMASTER").Rows(i)
                    LstPOS.Items.Add(Trim(.Item("POSCODE")) & "-->" & .Item("POSDESC"))
                End With
            Next i
        End If
    End Sub
    Private Sub FillCATEGORY()
        LstGroup.Items.Clear()
        ssql = "SELECT CATEGORYCODE,CATEGORYSEQNO,CATEGORYNAME FROM POSCATEGORYMaster  WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY CATEGORYCODE"
        vconn.getDataSet(ssql, "POSCATEGORYMASTER")
        If gdataset.Tables("POSCATEGORYMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POSCATEGORYMASTER").Rows.Count - 1
                With gdataset.Tables("POSCATEGORYMASTER").Rows(i)
                    LstCATEGORY.Items.Add(Trim(.Item("CATEGORYCODE")) & "-->" & .Item("CATEGORYNAME"))
                End With
            Next i
        End If

    End Sub

    Private Sub FillGroup()
        LstSUBGROUP.Items.Clear()
        ssql = "SELECT GROUPCODE,GROUPSEQNO,GROUPDESC FROM GroupMaster  WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY GROUPCODE"
        vconn.getDataSet(ssql, "GROUPMASTER")
        If gdataset.Tables("GROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GROUPMASTER").Rows.Count - 1
                With gdataset.Tables("GROUPMASTER").Rows(i)
                    LstGroup.Items.Add(Trim(.Item("GROUPCODE")) & "-->" & .Item("GROUPDESC"))
                End With
            Next i
        End If
    End Sub
    Private Sub filllstitems()
        Lstitems.Items.Clear()
        ssql = "SELECT itemcode,itemdesc FROM itemmaster  WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY itemcode"
        vconn.getDataSet(ssql, "itemmaster")
        If gdataset.Tables("itemmaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("itemmaster").Rows.Count - 1
                With gdataset.Tables("itemmaster").Rows(i)
                    Lstitems.Items.Add(Trim(.Item("itemcode")) & "-->" & .Item("itemdesc"))
                End With
            Next i
        End If
    End Sub
    Private Sub FILLSUBGROUP()
        LstSUBGROUP.Items.Clear()
        ssql = "SELECT SUBGROUPCODE,SUBGROUPDESC FROM SUBGroupMaster  WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY SUBGROUPCODE"
        vconn.getDataSet(ssql, "SUBGROUPMASTER")
        If gdataset.Tables("SUBGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("SUBGROUPMASTER").Rows(i)
                    LstSUBGROUP.Items.Add(Trim(.Item("SUBGROUPCODE")) & "-->" & .Item("SUBGROUPDESC"))
                End With
            Next i
        End If
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub cmdRoundoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRoundoff.Click
        Dim vRoundoff As Double
        Dim varience
        Dim prate
        If OptNearest.Checked = True Then
            If ssGrid.DataRowCnt = 0 Then Exit Sub
            For i = 1 To ssGrid.DataRowCnt
                ssGrid.Row = i
                ssGrid.Col = 7
                prate = Val(ssGrid.Text)
                ssGrid.Row = i
                ssGrid.Col = 8
                If CHKRNDVAL.Text = 10 Then
                    Dim RND As Decimal
                    RND = CStr(ssGrid.Text)
                    vRoundoff = Math.Round(RND, 1)
                    ssGrid.SetText(8, i, Format(Val(vRoundoff), "0.00"))
                    varience = Format(Val(ssGrid.Text) - prate, "0.00")
                    ssGrid.SetText(9, i, varience)
                Else
                    vRoundoff = Math.Ceiling(Val(ssGrid.Text))
                    ssGrid.SetText(8, i, Format(Val(vRoundoff), "0.00"))
                    varience = Format(Val(ssGrid.Text) - prate, "0.00")
                    ssGrid.SetText(9, i, varience)
                End If
            Next i
        End If
    End Sub
    Private Sub txtChangeValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChangeValue.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            cmdValueby.Focus()
        End If
    End Sub
    Private Sub OptValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptValue.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtChangeValue.Text = ""
            txtChangeValue.MaxLength = 10
            txtChangeValue.Focus()
        End If
    End Sub
    Private Sub OptPercentage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptPercentage.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtChangeValue.Text = ""
            txtChangeValue.Focus()
            txtChangeValue.MaxLength = 2
        End If
    End Sub
    Private Sub OptNone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptNone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdRoundoff.Focus()
        End If
    End Sub
    Private Sub OptNearest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptNearest.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdRoundoff.Focus()
        End If
    End Sub
    Private Sub cmdValueby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueby.Click
        Dim vRate
        Dim varience
        If OptValue.Checked = True Then
            If Val(txtChangeValue.Text) > 0 Then
                For i = 1 To ssGrid.DataRowCnt
                    ssGrid.Row = i
                    ssGrid.Col = 7
                    vRate = Val(ssGrid.Text)
                    vRate = Val(vRate) + Val(txtChangeValue.Text)
                    varience = Format(Val(vRate - Val(ssGrid.Text)), "0.00")
                    ssGrid.SetText(8, i, vRate)
                    ssGrid.SetText(9, i, varience)
                Next
            End If
        End If
        If OptPercentage.Checked = True Then
            If Val(txtChangeValue.Text) > 0 Then
                For i = 1 To ssGrid.DataRowCnt
                    ssGrid.Row = i
                    ssGrid.Col = 7
                    vRate = Val(ssGrid.Text)
                    vRate = Val(vRate) + Val(vRate * (Val(txtChangeValue.Text) / 100))
                    varience = Format(Val(vRate - Val(ssGrid.Text)), "0.00")
                    ssGrid.SetText(8, i, vRate)
                    ssGrid.SetText(9, i, varience)
                Next
            End If
        End If
    End Sub
    'Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        LstPOS.Focus()
    '    End If
    'End Sub
    Private Sub LstPOS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstPOS.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LstPOS_DoubleClick(LstPOS, e)
            LstGroup.Focus()
        End If
    End Sub
    Private Sub LstGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstGroup.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LstGroup_DoubleClick(LstGroup, e)
            OptValue.Focus()
        End If
    End Sub
    Private Sub LstPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPOS.KeyDown
        Dim Loopindex As Integer
        If e.KeyCode = Keys.F2 Then
            For Loopindex = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(Loopindex, True)
            Next
        End If
        If e.KeyCode = Keys.F3 Then
            For Loopindex = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(Loopindex, False)
            Next
        End If
        If e.KeyCode = Keys.Enter Then
            ' For Loopindex = 0 To LstPOS.Items.Count - 1
            'LstPOS.SetItemChecked(Loopindex, False)
            ' Next
            LstCATEGORY.Focus()
        End If
    End Sub
    Private Sub LstGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstGroup.KeyDown
        Dim Loopindex As Integer
        If e.KeyCode = Keys.F2 Then
            For Loopindex = 0 To LstPOS.Items.Count - 1
                LstGroup.SetItemChecked(Loopindex, True)
            Next
        End If
        If e.KeyCode = Keys.F3 Then
            For Loopindex = 0 To LstPOS.Items.Count - 1
                LstGroup.SetItemChecked(Loopindex, False)
            Next
        End If
        If e.KeyCode = Keys.Enter Then
            ' For Loopindex = 0 To LstPOS.Items.Count - 1
            'LstPOS.SetItemChecked(Loopindex, False)
            ' Next
            LstSUBGROUP.Focus()
        End If
    End Sub

    Private Sub cmdDateHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDateHelp.Click
        '    gSQLString = "SELECT DISTINCT CONVERT(DATETIME,Startingdate,103) AS STARTINGDATE FROM FRM_MKGA_RateMaster "
        '    M_WhereCondition = " WHERE  ISNULL(Endingdate,'') = ''"
        '    Dim vform As New ListOperattion1
        '    vform.Field = "STARTINGDATE"
        '    vform.vFormatstring = "                       WITH EFFECT FROM                     "
        '    vform.vCaption = "RATE MASTER HELP"
        '    vform.KeyPos = 0
        '    vform.ShowDialog(Me)
        '    If Trim(vform.keyfield & "") <> "" Then
        '        mskdate.Value = Format(CDate(vform.keyfield), "dd/MMM/yyyy")
        '        Call mskdate_Validated(mskdate, e)
        '    End If
        '    vform.Close()
        '    vform = Nothing
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call ClearOperation()
        Label1.Visible = True
        ' Label2.Visible = True
        mskdate.Visible = True
        cmdDateHelp.Visible = True
        GroupBox2.Visible = False
        vPOint = ""
        vGroup = ""
        vcategory = ""
        vsubgroup = ""
        vitem = ""
        GroupBox3.Visible = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim insert(0) As String
        Dim vDate, vRate, vItem, vSeqno, VERATE, vpRate As Double
        Dim GRate As Double
        Dim vCheck, vUOM, vCode, vlocation As String
        'If chkFreeze.Checked = True Then
        '    vCheck = "Y"
        'Else
        '    vCheck = "N"
        'End If
        If mskdate.Value < Now.Date Then
            MsgBox("EFFECTIVE DATE SHOULD BE GREATER THAN OR EQUAL TO TODAY DATE", MsgBoxStyle.Information, gCompanyname)
            ' Return False
            Exit Sub
        End If
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            For i = 1 To ssGrid.DataRowCnt
                ssGrid.Row = i
                ssGrid.Col = 1
                vlocation = Trim(CStr(ssGrid.Text))
                ssGrid.Col = 2
                vCode = Trim(CStr(ssGrid.Text))
                ssGrid.Col = 4
                vUOM = Trim(CStr(ssGrid.Text))
                ssGrid.Col = 7
                VERATE = Format(Val(ssGrid.Text), "0.00")
                ssGrid.Col = 8
                vRate = Format(Val(ssGrid.Text), "0.00")
                ssGrid.Col = 7
                vpRate = Format(Val(ssGrid.Text), "0.00")

                ssql = "UPDATE RateMaster SET ITEMRATE = " & Val(vRate) & " ,witheffectfrom='" & Format(mskdate.Value, "dd-MMM-yyyy") & "',pritemrate=" & Val(vpRate) & ",EXENDINGdATE='" & Format(mskdate.Value, "dd-MMM-yyyy") & "',STARTINGDATE = '" & Format(mskdate.Value, "dd-MMM-yyyy") & "' "
                'ssql = ssql & " from FRM_MKGA_RateMaster "
                ssql = ssql & " WHERE ItemCode='" & CStr(vCode) & "' and ISNULL(Endingdate,'') = ''"
                ssql = ssql & " and  rposcode='" & CStr(vlocation) & "'"

                If i = 1 Then
                    insert(insert.Length - 1) = ssql
                Else
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssql
                End If
            Next
            'For i = 1 To ssGrid.DataRowCnt
            '    ssql = "INSERT INTO FRM_MKGA_RateMaster(WitheffectFrom,ItemCode,ItemCodeseqno,UOM,Freeze,ItemRate,Startingdate) "
            '    ssql = ssql & " VALUES ("
            '    ssql = ssql & "'" & Format(mskdate.Value, "dd-MMM-yyyy") & "',"
            '    ssGrid.Col = 1
            '    ssGrid.Row = i
            '    ssql = ssql & "'" & Trim(ssGrid.Text) & "',"
            '    ssGrid.Col = 1
            '    ssGrid.Row = i
            '    vSeqno = GetSeqno(ssGrid.Text)
            '    ssql = ssql & "'" & vSeqno & "',"
            '    ssGrid.Col = 3
            '    ssGrid.Row = i
            '    ssql = ssql & "'" & Trim(ssGrid.Text) & "',"
            '    ssGrid.Col = 5
            '    ssGrid.Row = i
            '    ssql = ssql & "'N',"
            '    ssql = ssql & "" & Format(Val(ssGrid.Text), "0.00") & ","
            '    ssql = ssql & "'" & Format(mskdate.Value, "dd-MMM-yyyy") & "')"
            '    If i = 1 Then
            '        insert(insert.Length - 1) = ssql
            '    Else
            '        ReDim Preserve insert(insert.Length)
            '        insert(insert.Length - 1) = ssql
            '    End If
            'Next
        End If
        vconn.MoreTransold(insert)
        Call ClearOperation()
    End Sub
    Private Sub LstPOS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPOS.LostFocus
        Call LstPOS_SelectedValueChanged(LstPOS, e)
    End Sub
    Private Sub LstGroup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstGroup.LostFocus
        Call LstGroup_SelectedValueChanged(LstGroup, e)
    End Sub
    Private Sub LstPOS_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPOS.SelectedValueChanged

    End Sub
    Private Sub OptPercentage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptPercentage.Click
        txtChangeValue.Text = ""
        txtChangeValue.MaxLength = 2
    End Sub
    Private Sub OptValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptValue.CheckedChanged
        txtChangeValue.Text = ""
        txtChangeValue.MaxLength = 10
    End Sub
    Private Sub LstGroup_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstGroup.SelectedValueChanged

    End Sub
    'Private Sub mskDate_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyDownEvent)
    '    boolmask = True
    'End Sub

    Private Sub FRM_MKGA_RateMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        RateMastbool = False
    End Sub

    Private Sub mskdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtRate.Focus()
        End If
    End Sub

    Private Sub LstGroup_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstGroup.DoubleClick
        'Dim j As Integer
        'vGroup = ""
        'For j = 0 To LstGroup.Items.Count - 1
        '    If LstGroup.GetItemChecked(j) = True Then
        '        If Trim(vGroup) = "" Then
        '            vGroup = " '" & LstGroup.Items.Item(j) & "'"
        '        Else
        '            vGroup = vGroup & ",'" & LstGroup.Items.Item(j) & "'"
        '        End If
        '    End If
        'Next j
        'ssGrid.ClearRange(1, 1, -1, -1, True)
        'ssql = "SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
        'ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
        'ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN FRM_MKGA_RateMaster AS R ON I.ITEMCODE = R.ITEMCODE INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
        'If Trim(vPOint & "") <> "" Then
        '    ssql = ssql & " AND P.POS IN (" & vPOint & ")"
        'End If
        'If Trim(vGroup & "") <> "" Then
        '    ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
        'End If
        'ssql = ssql & " ORDER BY ITEMCODE"
        'vconn.getDataSet(ssql, "ITEMMASTER")
        'If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
        '    For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
        '        With ssGrid
        '            .Row = i
        '            .Col = 1
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '            .Col = 2
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
        '            .Col = 3
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
        '            .Col = 5
        '            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '            .Col = 6
        '            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '            '.Col = 7
        '            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMTYPECODE"))
        '            '.Col = 8
        '            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '            '.Col = 9
        '            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '            .Col = 12
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
        '            .Col = 13
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '            .Col = 14
        '            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))
        '        End With
        '    Next i
        'Else
        '    MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    For i = 0 To LstPOS.Items.Count - 1
        '        LstPOS.SetItemChecked(i, False)
        '    Next
        '    Call FillItems()
        '    Exit Sub
        'End If
    End Sub

    Private Sub LstPOS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPOS.DoubleClick
        '    If LstPOS.CheckedItems.Count <> 0 Then
        '        Dim j, i As Integer
        '        Dim LstPOS1 As String()
        '        vPOint = ""
        '        'If LstPOS.CheckedItems.Count = True Then
        '        'For i = 0 To Me.CHK_LOCATION.CheckedItems.Count() - 1
        '        'Loc = Split(CHK_LOCATION.CheckedItems(i), "-->")
        '        'loccode = Loc(0)
        '        'For k = 0 To Me.LstPOS.Items.Count() > 0
        '        For j = 0 To Me.LstPOS.SelectedItems.Count - 1
        '            'For i = 0 To Me.LstPOS.GetItemChecked(j) = True
        '            If Me.LstPOS.GetItemChecked(j) = True Then
        '                'If LstPOS.GetSelected(j) = True Then
        '                If Trim(vPOint) = "" Then
        '                    'LstPOS1 = LstPOS.SelectedItems(j).split("-->")
        '                    LstPOS1 = Split(Me.LstPOS.SelectedItems(j), "-->")
        '                    'LstPOS1 = Me.LstPOS.SelectedItems(j)
        '                    vPOint = " '" & LstPOS1(0) & "' "
        '                    'MessageBox.Show(LstPOS1(0))
        '                Else
        '                    LstPOS1 = Split(Me.LstPOS.SelectedItems(j), "-->")
        '                    vPOint = "" & vPOint & ", '" & LstPOS1(0) & "' "
        '                    'MessageBox.Show(LstPOS1(0))

        '                End If
        '            End If
        '            'Next i

        '        Next j
        '        'Next
        '        'If LstPOS.CheckedItems.Count <> 0 Then
        '        'Dim j As Integer
        '        'vPOint = ""
        '        'For j = 0 To LstPOS.Items.Count - 1
        '        '    If LstPOS.GetItemChecked(j) = True Then
        '        '        If Trim(vPOint) = "" Then
        '        '            vPOint = " '" & LstPOS.Items.Item(j) & "'"
        '        '        Else
        '        '            vPOint = "" & vPOint & " ,'" & LstPOS.Items.Item(j) & "'"
        '        '        End If
        '        '    End If
        '        'Next j
        '        ssGrid.ClearRange(1, 1, -1, -1, True)
        '        If Rdoprevious.Checked = True Then
        '            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        '            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.STARTINGDATE AS STARTINGDATE"
        '            ssql = ssql & " FROM FRM_MKGA_RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
        '            ssql = ssql & " INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE AND P.POS=R.RPOSCODE" ' WHERE R.STARTINGDATE <'" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')<>''"
        '            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

        '            If Trim(vPOint & "") <> "" Then
        '                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
        '            End If

        '            'If Trim(vGroup & "") <> "" Then
        '            'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
        '            'End If
        '            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.PRITEMRATE "
        '            ssql = ssql & " ORDER BY POS,ITEMCODE"
        '            vconn.getDataSet(ssql, "ITEMMASTER")

        '            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

        '                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
        '                    ' 
        '                    With ssGrid
        '                        .Row = i
        '                        .Col = 1
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        .Col = 2
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
        '                        .Col = 3
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
        '                        .Col = 4
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
        '                        .Col = 6
        '                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
        '                        '.Col = 7
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 6
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 7
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 8
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 9
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        '.Col = 12
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
        '                        '.Col = 13
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '                        .Col = 11
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
        '                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        '.Col = 12
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
        '                        '.Col = 13
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '                        '.Col = 14
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

        '                    End With
        '                Next i
        '            Else
        '                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '                For i = 0 To LstPOS.Items.Count - 1
        '                    LstPOS.SetItemChecked(i, False)
        '                Next
        '                Call FillItems()
        '                Exit Sub
        '            End If
        '        ElseIf Rdoexisting.Checked = True Then
        '            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        '            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.STARTINGDATE AS STARTINGDATE"
        '            ssql = ssql & " FROM FRM_MKGA_RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
        '            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'')=''"
        '            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

        '            If Trim(vPOint & "") <> "" Then
        '                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
        '            End If

        '            'If Trim(vGroup & "") <> "" Then
        '            'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
        '            'End If
        '            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.EXITEMRATE "
        '            ssql = ssql & " ORDER BY ITEMCODE"
        '            vconn.getDataSet(ssql, "ITEMMASTER")

        '            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

        '                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
        '                    With ssGrid
        '                        .Row = i
        '                        .Col = 1
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        .Col = 2
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
        '                        .Col = 3
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
        '                        .Col = 4
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
        '                        '.Col = 6
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 7
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 6
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        .Col = 7
        '                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 8
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 9
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        '.Col = 12
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
        '                        '.Col = 13
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '                        .Col = 11
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
        '                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        '.Col = 12
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
        '                        '.Col = 13
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
        '                        '.Col = 14
        '                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

        '                    End With
        '                Next i
        '            Else
        '                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '                For i = 0 To LstPOS.Items.Count - 1
        '                    LstPOS.SetItemChecked(i, False)
        '                Next
        '                Call FillItems()
        '                Exit Sub
        '            End If
        '        ElseIf Rdonew.Checked = True Then
        '            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        '            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.STARTINGDATE AS STARTINGDATE"
        '            ssql = ssql & " FROM FRM_MKGA_RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
        '            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')=''"
        '            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

        '            If Trim(vPOint & "") <> "" Then
        '                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
        '            End If

        '            'If Trim(vGroup & "") <> "" Then
        '            'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
        '            'End If
        '            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate "
        '            ssql = ssql & " ORDER BY POS,ITEMCODE"
        '            vconn.getDataSet(ssql, "ITEMMASTER")

        '            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

        '                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
        '                    With ssGrid
        '                        .Row = i
        '                        .Col = 1
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        .Col = 2
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
        '                        .Col = 3
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
        '                        .Col = 4
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

        '                        .Col = 6
        '                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
        '                        .Col = 7
        '                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 8
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
        '                        .Col = 11
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

        '                    End With
        '                Next i
        '            Else
        '                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '                For i = 0 To LstPOS.Items.Count - 1
        '                    LstPOS.SetItemChecked(i, False)
        '                Next
        '                Call FillItems()
        '                Exit Sub
        '            End If
        '        ElseIf Rdomodified.Checked = True Then
        '            ssql = " SELECT P.RPOSCODE AS POS,I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        '            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.STARTINGDATE AS STARTINGDATE"
        '            ssql = ssql & " FROM FRM_MKGA_RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
        '            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE  WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')=''"
        '            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

        '            If Trim(vPOint & "") <> "" Then
        '                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
        '            End If

        '            'If Trim(vGroup & "") <> "" Then
        '            'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
        '            'End If
        '            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid "
        '            ssql = ssql & " ORDER BY POS,ITEMCODE"
        '            vconn.getDataSet(ssql, "ITEMMASTER")

        '            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

        '                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
        '                    With ssGrid
        '                        .Row = i
        '                        .Col = 1
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
        '                        .Col = 2
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
        '                        .Col = 3
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
        '                        .Col = 4
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
        '                        '.Col = 6
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 7
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 6
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        '.Col = 7
        '                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        .Col = 8
        '                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
        '                        .Col = 11
        '                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))


        '                    End With
        '                    ' End If
        '                Next i
        '            Else
        '                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '                For i = 0 To LstPOS.Items.Count - 1
        '                    LstPOS.SetItemChecked(i, False)
        '                Next
        '                Call FillItems()
        '                Exit Sub
        '            End If

        '        End If
        '    End If
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        Dim FRM As New ReportDesigner
        If mskdate.Text.Length > 0 Then
            tables = " FROM RATEMASTER WHERE WITHEFFECTFROM = '" & Format(mskdate.Value, "yyyy/MM/dd") & "'"
        Else
            tables = "FROM RATEMASTER "
        End If
        Gheader = "RATEMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"WITHEFFECTFROM", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMCODE", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UOM", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMRATE", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PRITEMRATE", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"RPOSCODE", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERid", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub mskdate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskdate.Validated
        Dim vDate As Date
        Dim vpurchaserate, vRate As Double
        If IsDate(mskdate.Value) = False Then
            Call FillItems()
            mskdate.Focus()
            Exit Sub
        End If
        ssql = " SELECT R.RPOSCODE AS POS,I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
        ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.STARTINGDATE AS STARTINGDATE"
        ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN RateMaster AS R ON I.ITEMCODE = R.ITEMCODE"
        ssql = ssql & " INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE ISNULL(R.ENDINGDATE,'') = ''" 'R.STARTINGDATE IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND 
        ssql = ssql & " GROUP BY I.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate "
        ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
        vconn.getDataSet(ssql, "ITEMMASTER")
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
            For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                    ssGrid.MaxRows = ssGrid.Row + 500
                End If
                With ssGrid
                    .Row = i
                    .Col = 1
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                    .Col = 2
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                    .Col = 3
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                    .Col = 4
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                    '.Col = 5
                    '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                    '.Col = 6
                    '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                    .Col = 7
                    .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                    '.Col = 8
                    '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                    '.Col = 9
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                    '.Col = 12
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                    '.Col = 13
                    '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                    .Col = 11
                    .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                End With
                mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
            Next
        Else
            CmdAdd.Text = "Add [F7]"
            ssGrid.ClearRange(1, 1, -1, -1, True)
        End If
    End Sub

    Private Sub mskdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskdate.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmdDateHelp_Click(cmdDateHelp, e)
        End If
    End Sub

    Private Sub LstGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstGroup.SelectedIndexChanged
        Dim j As Integer
        vGroup = ""
        Dim lstgrp() As String
        For j = 0 To LstGroup.Items.Count - 1
            If LstGroup.GetItemChecked(j) = True Then
                If Trim(vGroup) = "" Then
                    lstgrp = Split(LstGroup.Items.Item(j), "-->")
                    vGroup = " '" & lstgrp(0) & "'"
                Else
                    'vGroup = vGroup & ",'" & LstGroup.Items.Item(j) & "'"
                    lstgrp = Split(LstGroup.Items.Item(j), "-->")
                    vGroup = " '" & lstgrp(0) & "'"
                End If
            End If
        Next j

        'Dim j As Integer
        'vGroup = ""
        'For j = 0 To LstGroup.Items.Count - 1
        '    If LstGroup.GetItemChecked(j) = True Then
        '        If Trim(vGroup) = "" Then
        '            vGroup = " '" & LstGroup.Items.Item(j) & "'"
        '        Else
        '            vGroup = "" & vGroup & ",'" & LstGroup.Items.Item(j) & "'"
        '        End If
        '    End If
        'Next j
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If Rdoprevious.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,R.PRITEMRATE AS PRITEMRATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE " 'WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    'If Rdoprevious.Checked = True Then
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstGroup.Items.Count - 1
                    LstGroup.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdoexisting.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i.adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstGroup.Items.Count - 1
                    LstGroup.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdonew.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i .adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstGroup.Items.Count - 1
                    LstGroup.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdomodified.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 8
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With

                Next i

            Else
                MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstGroup.Items.Count - 1
                    LstGroup.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        End If
        ' End IF
    End Sub

    Private Sub OptNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptNone.CheckedChanged

    End Sub

    Private Sub OptNearest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptNearest.CheckedChanged

    End Sub

    Private Sub LstPOS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstPOS.SelectedIndexChanged
        If LstPOS.CheckedItems.Count <> 0 Then
            Dim j, i As Integer
            Dim items As Integer
            Dim LstPOS1 As String()
            vPOint = ""
            'For i = 0 To Me.LstPOS.Items.Count - 1
            For j = 0 To Me.LstPOS.Items.Count - 1
                If Me.LstPOS.GetItemChecked(j) = True Then
                    If Trim(vPOint) = "" Then
                        LstPOS1 = Split(Me.LstPOS.Items.Item(j), "-->")
                        vPOint = " '" & LstPOS1(0) & "' "
                    Else
                        LstPOS1 = Split(Me.LstPOS.Items.Item(j), "-->")
                        vPOint = "" & vPOint & ", '" & LstPOS1(items) & "' "
                    End If
                End If
            Next j
            'Next i
            'If LstPOS.CheckedItems.Count <> 0 Then
            'Dim j As Integer
            'vPOint = ""
            'For j = 0 To LstPOS.Items.Count - 1
            '    If LstPOS.GetItemChecked(j) = True Then
            '        If Trim(vPOint) = "" Then
            '            vPOint = " '" & LstPOS.Items.Item(j) & "'"
            '        Else
            '            vPOint = "" & vPOint & " ,'" & LstPOS.Items.Item(j) & "'"
            '        End If
            '    End If
            'Next j
            ssGrid.ClearRange(1, 1, -1, -1, True)
            If Rdoprevious.Checked = True Then
                ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
                ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.STARTINGDATE AS STARTINGDATE"
                ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
                ssql = ssql & " INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE AND P.POS=R.RPOSCODE" ' WHERE R.STARTINGDATE <'" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')<>''"
                'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

                If Trim(vPOint & "") <> "" Then
                    ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
                End If

                'If Trim(vGroup & "") <> "" Then
                'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
                'End If
                ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.PRITEMRATE "
                ssql = ssql & " ORDER BY POS,ITEMCODE"
                vconn.getDataSet(ssql, "ITEMMASTER")

                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

                    For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                        ' 
                        With ssGrid
                            .Row = i
                            .Col = 1
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            .Col = 2
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                            .Col = 3
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                            .Col = 4
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                            .Col = 6
                            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                            '.Col = 7
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 6
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 7
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 8
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 9
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            '.Col = 12
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                            '.Col = 13
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                            .Col = 11
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                            'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            '.Col = 12
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                            '.Col = 13
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                            '.Col = 14
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                        End With
                    Next i
                Else
                    MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    For i = 0 To LstPOS.Items.Count - 1
                        LstPOS.SetItemChecked(i, False)
                    Next
                    Call FillItems()
                    Exit Sub
                End If
            ElseIf Rdoexisting.Checked = True Then
                ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
                ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.STARTINGDATE AS STARTINGDATE"
                ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
                ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'')=''"
                'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

                If Trim(vPOint & "") <> "" Then
                    ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
                End If

                'If Trim(vGroup & "") <> "" Then
                'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
                'End If
                ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.EXITEMRATE "
                ssql = ssql & " ORDER BY ITEMCODE"
                vconn.getDataSet(ssql, "ITEMMASTER")

                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

                    For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                        With ssGrid
                            .Row = i
                            .Col = 1
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            .Col = 2
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                            .Col = 3
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                            .Col = 4
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                            '.Col = 6
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 7
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 6
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            .Col = 7
                            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 8
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 9
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            '.Col = 12
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                            '.Col = 13
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                            .Col = 11
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                            'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            '.Col = 12
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                            '.Col = 13
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                            '.Col = 14
                            '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                        End With
                    Next i
                Else
                    MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    For i = 0 To LstPOS.Items.Count - 1
                        LstPOS.SetItemChecked(i, False)
                    Next
                    Call FillItems()
                    Exit Sub
                End If
            ElseIf Rdonew.Checked = True Then
                ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
                ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.STARTINGDATE AS STARTINGDATE"
                ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
                ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')=''"
                'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

                If Trim(vPOint & "") <> "" Then
                    ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
                End If

                'If Trim(vGroup & "") <> "" Then
                'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
                'End If
                ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate "
                ssql = ssql & " ORDER BY POS,ITEMCODE"
                vconn.getDataSet(ssql, "ITEMMASTER")

                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

                    For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                        With ssGrid
                            .Row = i
                            .Col = 1
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            .Col = 2
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                            .Col = 3
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                            .Col = 4
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

                            .Col = 6
                            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                            .Col = 7
                            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 8
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
                            .Col = 11
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                        End With
                    Next i
                Else
                    MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    For i = 0 To LstPOS.Items.Count - 1
                        LstPOS.SetItemChecked(i, False)
                    Next
                    Call FillItems()
                    Exit Sub
                End If
            ElseIf Rdomodified.Checked = True Then
                ssql = " SELECT P.RPOSCODE AS POS,I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
                ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.STARTINGDATE AS STARTINGDATE"
                ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
                ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE  WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')=''"
                'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"

                If Trim(vPOint & "") <> "" Then
                    ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
                End If

                'If Trim(vGroup & "") <> "" Then
                'ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
                'End If
                ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid "
                ssql = ssql & " ORDER BY POS,ITEMCODE"
                vconn.getDataSet(ssql, "ITEMMASTER")

                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then

                    For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                        With ssGrid
                            .Row = i
                            .Col = 1
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                            .Col = 2
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                            .Col = 3
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                            .Col = 4
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                            '.Col = 6
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 7
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 6
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            '.Col = 7
                            '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            .Col = 8
                            .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                            .Col = 11
                            .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))


                        End With
                        ' End If
                    Next i
                Else
                    MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    For i = 0 To LstPOS.Items.Count - 1
                        LstPOS.SetItemChecked(i, False)
                    Next
                    Call FillItems()
                    Exit Sub
                End If

            End If
        End If
    End Sub

    Private Sub selectsubgroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectsubgroup.CheckedChanged
        Dim i As Integer
        If selectsubgroup.Checked = True Then
            For i = 0 To LstSUBGROUP.Items.Count - 1
                LstSUBGROUP.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstSUBGROUP.Items.Count - 1
                LstSUBGROUP.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chkFreeze_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFreeze.CheckedChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If CheckBox1.Checked = True Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next
        End If
    End Sub

    'Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
    '    Dim j As Integer
    '    Dim LstPOS1() As String
    '    vPOint = ""
    '    For j = 0 To LstPOS.Items.Count - 1
    '        If LstPOS.GetItemChecked(j) = True Then
    '            If Trim(vPOint) = "" Then
    '                'vPOint = "'" & LstPOS.Items.Item(j) & "'"
    '                LstPOS1 = Split(LstPOS.CheckedItems(j), "-->")
    '                vPOint = " '" & LstPOS1(0) & "' "
    '                'vPOint = "'" & LstPOS1.Split("-->") & "'"
    '            Else
    '                'vPOint = vPOint & ",'" & LstPOS.Items.Item(j) & "'"
    '                LstPOS1 = Split(LstPOS.CheckedItems(j), "-->")
    '                vPOint = vPOint & ",'" & LstPOS1(0) & "'"
    '                'vPOint.Split("-->")
    '            End If
    '        End If
    '    Next j
    '    ssGrid.ClearRange(1, 1, -1, -1, True)
    '    ssql = "SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
    '    ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
    '    ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN FRM_MKGA_RateMaster AS R ON I.ITEMCODE = R.ITEMCODE INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
    '    If Trim(vPOint & "") <> "" Then
    '        ssql = ssql & " AND P.POS IN (" & vPOint & ")"
    '    End If
    '    'If Trim(vcategory & "") <> "" Then
    '    '    ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
    '    'End If

    '    'If Trim(vGroup & "") <> "" Then
    '    '    ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
    '    'End If

    '    'If Trim(vsubgroup & "") <> "" Then
    '    '    ssql = ssql & " AND I.SUBGROUPCODE IN (" & vsubgroup & ")"
    '    'End If

    '    'If Trim(vitem & "") <> "" Then
    '    '    ssql = ssql & " AND I.ITEMCODE IN (" & vitem & ")"
    '    'End If
    '    ssql = ssql & " ORDER BY ITEMCODE"
    '    vconn.getDataSet(ssql, "ITEMMASTER")
    '    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
    '        For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
    '            With ssGrid
    '                .Row = i
    '                .Col = 1
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 2
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
    '                .Col = 3
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
    '                .Col = 5
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                .Col = 6
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                '.Col = 7
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMTYPECODE"))
    '                '.Col = 8
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                '.Col = 9
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 12
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
    '                .Col = 13
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                .Col = 14
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

    '            End With
    '        Next i
    '    Else
    '        MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        For i = 0 To LstPOS.Items.Count - 1
    '            LstPOS.SetItemChecked(i, False)
    '        Next
    '        Call FillItems()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub LstPOS_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPOS.TabIndexChanged

    End Sub

    Private Sub LstCATEGORY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstCATEGORY.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstGroup.Focus()
        End If
    End Sub

    Private Sub LstCATEGORY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstCATEGORY.SelectedIndexChanged

        Dim j, ITEMS As Integer
        Dim Lstcat() As String
        vcategory = ""
        For j = 0 To LstCATEGORY.Items.Count - 1
            If LstCATEGORY.GetItemChecked(j) = True Then
                If Trim(vcategory) = "" Then
                    Lstcat = Split(LstCATEGORY.Items.Item(j), "-->")
                    vcategory = " '" & Lstcat(0) & "' "
                    'MessageBox.Show(LstPOS1(0))
                Else
                    Lstcat = Split(LstCATEGORY.Items.Item(j), "-->")
                    vcategory = vcategory & " '" & Lstcat(ITEMS) & "' "
                    'MessageBox.Show(LstPOS1(0))

                End If
            End If

        Next j
        'If LstCATEGORY.CheckedItems.Count <> 0 Then
        '    For j = 0 To LstCATEGORY.Items.Count - 1
        '        If LstCATEGORY.GetItemChecked(j) = True Then
        '            If Trim(vcategory) = "" Then
        '                vcategory = " '" & LstCATEGORY.Items.Item(j) & "'"
        '            Else
        '                vcategory = "" & vcategory & ",'" & LstCATEGORY.Items.Item(j) & "'"
        '            End If
        '        End If
        '    Next j
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If Rdoprevious.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i.adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE" ' WHERE R.STARTINGDATE <'" & Format(mskdate.Value, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') =''  "

            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstCATEGORY.Items.Count - 1
                    LstCATEGORY.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdoexisting.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i.adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') =''  "

            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                    ' End If
                Next i
            Else
                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstCATEGORY.Items.Count - 1
                    LstCATEGORY.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdonew.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i.adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') =''  "

            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                    ' End If
                Next i
            Else
                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstCATEGORY.Items.Count - 1
                    LstCATEGORY.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdomodified.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,i.adduserid as adduserid,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE  WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') =''  "

            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 8
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))


                    End With
                    ' End If
                Next i
            Else
                MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstCATEGORY.Items.Count - 1
                    LstCATEGORY.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        End If
        ' End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        If CheckBox2.Checked = True Then
            For i = 0 To LstCATEGORY.Items.Count - 1
                LstCATEGORY.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstCATEGORY.Items.Count - 1
                LstCATEGORY.SetItemChecked(i, False)
            Next
        End If
    End Sub

    'Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
    '    Dim j As Integer
    '    Dim LstCAT() As String
    '    vPOint = ""
    '    For j = 0 To LstCATEGORY.Items.Count - 1
    '        If LstCATEGORY.GetItemChecked(j) = True Then
    '            If Trim(vcategory) = "" Then
    '                'vPOint = "'" & LstPOS.Items.Item(j) & "'"
    '                LstCAT = Split(LstCATEGORY.CheckedItems(j), "-->")
    '                vcategory = " '" & LstCAT(0) & "' "
    '                'vPOint = "'" & LstPOS1.Split("-->") & "'"
    '            Else
    '                'vPOint = vPOint & ",'" & LstPOS.Items.Item(j) & "'"
    '                LstCAT = Split(LstCATEGORY.CheckedItems(j), "-->")
    '                vcategory = vcategory & ",'" & LstCAT(0) & "'"
    '                'vPOint.Split("-->")
    '            End If
    '        End If
    '    Next j
    '    ssGrid.ClearRange(1, 1, -1, -1, True)
    '    ssql = "SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
    '    ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
    '    ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN FRM_MKGA_RateMaster AS R ON I.ITEMCODE = R.ITEMCODE INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
    '    If Trim(vPOint & "") <> "" Then
    '        ssql = ssql & " AND P.POS IN (" & vPOint & ")"
    '    End If
    '    If Trim(vcategory & "") <> "" Then
    '        ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
    '    End If

    '    'If Trim(vGroup & "") <> "" Then
    '    '    ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
    '    'End If

    '    'If Trim(vsubgroup & "") <> "" Then
    '    '    ssql = ssql & " AND I.SUBGROUPCODE IN (" & vsubgroup & ")"
    '    'End If

    '    'If Trim(vitem & "") <> "" Then
    '    '    ssql = ssql & " AND I.ITEMCODE IN (" & vitem & ")"
    '    'End If
    '    ssql = ssql & " ORDER BY ITEMCODE"
    '    vconn.getDataSet(ssql, "ITEMMASTER")
    '    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
    '        For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
    '            With ssGrid
    '                .Row = i
    '                .Col = 1
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 2
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
    '                .Col = 3
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
    '                .Col = 5
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                .Col = 6
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                '.Col = 7
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMTYPECODE"))
    '                '.Col = 8
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                '.Col = 9
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 12
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
    '                .Col = 13
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                .Col = 14
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

    '            End With
    '        Next i
    '    Else
    '        MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        For i = 0 To LstCATEGORY.Items.Count - 1
    '            LstCATEGORY.SetItemChecked(i, False)
    '        Next
    '        Call FillItems()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub SELECTGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SELECTGROUP.CheckedChanged
        Dim i As Integer
        If SELECTGROUP.Checked = True Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub LstSUBGROUP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstSUBGROUP.KeyDown
        If e.KeyCode = Keys.Enter Then
            Lstitems.Focus()
        End If
    End Sub

    ''Private Sub SELECTGROUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SELECTGROUP.Click
    ''    Dim j As Integer
    ''    vGroup = ""
    ''    Dim lstgrp() As String
    ''    For j = 0 To LstGroup.Items.Count - 1
    ''        If LstGroup.GetItemChecked(j) = True Then
    ''            If Trim(vGroup) = "" Then
    ''                lstgrp = Split(LstGroup.Items.Item(j), "-->")
    ''                vGroup = " '" & lstgrp(0) & "'"
    ''            Else
    ''                'vGroup = vGroup & ",'" & LstGroup.Items.Item(j) & "'"
    ''                lstgrp = Split(LstGroup.Items.Item(j), "-->")
    ''                vGroup = " '" & lstgrp(0) & "'"
    ''            End If
    ''        End If
    ''    Next j
    ''    ssGrid.ClearRange(1, 1, -1, -1, True)
    ''    ssql = "SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
    ''    ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
    ''    ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN FRM_MKGA_RateMaster AS R ON I.ITEMCODE = R.ITEMCODE INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
    ''    If Trim(vPOint & "") <> "" Then
    ''        ssql = ssql & " AND P.POS IN (" & vPOint & ")"
    ''    End If

    ''    If Trim(vcategory & "") <> "" Then
    ''        ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
    ''    End If

    ''    If Trim(vGroup & "") <> "" Then
    ''        ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
    ''    End If
    ''    ssql = ssql & " ORDER BY ITEMCODE"
    ''    vconn.getDataSet(ssql, "ITEMMASTER")
    ''    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
    ''        For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
    ''            With ssGrid
    ''                .Row = i
    ''                .Col = 1
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    ''                .Col = 2
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
    ''                .Col = 3
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
    ''                .Col = 5
    ''                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    ''                .Col = 6
    ''                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    ''                '.Col = 7
    ''                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMTYPECODE"))
    ''                '.Col = 8
    ''                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    ''                '.Col = 9
    ''                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    ''                .Col = 12
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
    ''                .Col = 13
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    ''                .Col = 14
    ''                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))
    ''            End With
    ''        Next i
    ''    Else
    ''        MessageBox.Show(" Specified Group Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    ''        For i = 0 To LstGroup.Items.Count - 1
    ''            LstGroup.SetItemChecked(i, False)
    ''        Next
    ''        Call FillItems()
    ''        Exit Sub
    ''    End If
    ''End Sub

    'Private Sub selectsubgroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectsubgroup.Click
    '    Dim j, i As Integer
    '    Dim Lstsubgroup1() As String
    '    vsubgroup = ""
    '    For j = 0 To LstSUBGROUP.Items.Count - 1
    '        If LstSUBGROUP.GetItemChecked(j) = True Then
    '            If Trim(vsubgroup) = "" Then
    '                Lstsubgroup1 = Split(LstSUBGROUP.SelectedItems(j), "-->")
    '                vsubgroup = " '" & Lstsubgroup1(0) & "' "
    '                'MessageBox.Show(LstPOS1(0))
    '            Else
    '                Lstsubgroup1 = Split(LstSUBGROUP.SelectedItems(j), "-->")
    '                vsubgroup = vsubgroup & " '" & Lstsubgroup1(0) & "' "
    '                'MessageBox.Show(LstPOS1(0))

    '            End If
    '        End If

    '    Next j

    '    ssGrid.ClearRange(1, 1, -1, -1, True)
    '    ssql = "SELECT I.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,"
    '    ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,P.POS AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
    '    ssql = ssql & " FROM ITEMMASTER AS I INNER JOIN FRM_MKGA_RateMaster AS R ON I.ITEMCODE = R.ITEMCODE INNER JOIN POSMENULINK AS P ON I.ITEMCODE = P.ITEMCODE WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "

    '    If Trim(vPOint & "") <> "" Then
    '        ssql = ssql & " AND P.POS IN (" & vPOint & ")"
    '    End If

    '    If Trim(vcategory & "") <> "" Then
    '        ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
    '    End If

    '    If Trim(vGroup & "") <> "" Then
    '        ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
    '    End If

    '    If Trim(vsubgroup & "") <> "" Then
    '        ssql = ssql & " AND I.SUBGROUPCODE IN (" & vsubgroup & ")"
    '    End If

    '    'If Trim(vitem & "") <> "" Then
    '    '    ssql = ssql & " AND I.ITEMCODE IN (" & vitem & ")"
    '    'End If

    '    ssql = ssql & " ORDER BY ITEMCODE"
    '    vconn.getDataSet(ssql, "ITEMMASTER")
    '    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
    '        For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
    '            With ssGrid
    '                .Row = i
    '                .Col = 1
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 2
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
    '                .Col = 3
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
    '                .Col = 5
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                .Col = 6
    '                .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
    '                '.Col = 7
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMTYPECODE"))
    '                '.Col = 8
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                '.Col = 9
    '                '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
    '                .Col = 12
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
    '                .Col = 13
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
    '                .Col = 14
    '                .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

    '            End With
    '        Next i
    '    Else
    '        MessageBox.Show(" Specified POS Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        For i = 0 To LstSUBGROUP.Items.Count - 1
    '            LstSUBGROUP.SetItemChecked(i, False)
    '        Next
    '        Call FillItems()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub LstSUBGROUP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstSUBGROUP.SelectedIndexChanged
        Dim j, i As Integer
        Dim Lstsubgroup1() As String
        vsubgroup = ""
        For j = 0 To LstSUBGROUP.Items.Count - 1
            If LstSUBGROUP.GetItemChecked(j) = True Then
                If Trim(vsubgroup) = "" Then
                    Lstsubgroup1 = Split(LstSUBGROUP.Items.Item(j), "-->")
                    vsubgroup = " '" & Lstsubgroup1(0) & "' "
                    'MessageBox.Show(LstPOS1(0))
                Else
                    Lstsubgroup1 = Split(LstSUBGROUP.Items.Item(j), "-->")
                    vsubgroup = vsubgroup & " '" & Lstsubgroup1(0) & "' "
                    'MessageBox.Show(LstPOS1(0))

                End If
            End If

        Next j
        'Dim j As Integer
        'vsubgroup = ""
        'For j = 0 To LstSUBGROUP.Items.Count - 1
        '    If LstSUBGROUP.GetItemChecked(j) = True Then
        '        If Trim(vsubgroup) = "" Then
        '            vsubgroup = " '" & LstSUBGROUP.Items.Item(j) & "'"
        '        Else
        '            vsubgroup = "" & vsubgroup & ",'" & LstSUBGROUP.Items.Item(j) & "'"
        '        End If
        '    End If
        'Next j
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If Rdoprevious.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE  AND P.POS=R.RPOSCODE" ' WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified subGroup Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstSUBGROUP.Items.Count - 1
                    LstSUBGROUP.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdoexisting.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' " 'AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified subGroup Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstSUBGROUP.Items.Count - 1
                    LstSUBGROUP.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdonew.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified subGroup Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstSUBGROUP.Items.Count - 1
                    LstSUBGROUP.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdomodified.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE  P.POS=R.RPOSCODE WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 8
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                    'End If
                Next i
            Else
                MessageBox.Show(" Specified subGroup Code is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To LstSUBGROUP.Items.Count - 1
                    LstSUBGROUP.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub Rdoprevious_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdoprevious.CheckedChanged
        Dim vDate As Date
        Dim vpurchaserate, vRate As Double
        'If IsDate(mskdate.Value) = False Then
        '    Call FillItems()
        '    mskdate.Focus()
        '    Exit Sub
        'End If
        Label1.Visible = True
        ' Label2.Visible = True
        mskdate.Visible = True
        cmdDateHelp.Visible = True
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        LstPOS.Items.Clear()
        LstCATEGORY.Items.Clear()
        LstGroup.Items.Clear()
        LstSUBGROUP.Items.Clear()
        Lstitems.Items.Clear()
        Call FillPOS()
        Call FillCATEGORY()
        Call FillGroup()
        Call FillItems()
        Call FILLSUBGROUP()
        Call filllstitems()

        If Rdoprevious.Checked = True Then
            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.STARTINGDATE AS STARTINGDATE"
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE " 'WHERE R.STARTINGDATE <='" & Format(mskdate.Value, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''"
            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"
            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.PRITEMRATE"
            ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
            vconn.getDataSet(ssql, "ITEMMASTER")
            ssGrid.ClearRange(1, 1, -1, -1, True)
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                        ssGrid.MaxRows = ssGrid.Row + 500
                    End If
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 5
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                    End With
                    'mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
                Next
                'Else
                '    CmdAdd.Text = "Add [F7]"
                '    ssGrid.ClearRange(1, 1, -1, -1, True)
            End If

        End If
        CmdAdd.Enabled = False
    End Sub

    Private Sub Rdoexisting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdoexisting.CheckedChanged
        Dim vDate As Date
        Dim vpurchaserate, vRate As Double
        Label1.Visible = False
        ' Label2.Visible = False
        mskdate.Visible = False
        cmdDateHelp.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        'If IsDate(mskdate.Value) = False Then
        '    Call FillItems()
        '    mskdate.Focus()
        '    Exit Sub
        'End If
        LstPOS.Items.Clear()
        LstCATEGORY.Items.Clear()
        LstGroup.Items.Clear()
        LstSUBGROUP.Items.Clear()
        Lstitems.Items.Clear()
        Call FillPOS()
        Call FillCATEGORY()
        Call FillGroup()
        Call FillItems()
        Call FILLSUBGROUP()
        Call filllstitems()

        If Rdoexisting.Checked = True Then
            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.STARTINGDATE AS STARTINGDATE"
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE" ' WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' " 'AND ISNULL(R.ENDINGDATE,'')= ''"
            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"
            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,R.EXITEMRATE"
            ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
            vconn.getDataSet(ssql, "ITEMMASTER")
            ssGrid.ClearRange(1, 1, -1, -1, True)
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                        ssGrid.MaxRows = ssGrid.Row + 500
                    End If
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 5
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                    End With
                    'mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
                Next
                'Else
                'CmdAdd.Text = "Add [F7]"
                'ssGrid.ClearRange(1, 1, -1, -1, True)
            End If

        End If
        CmdAdd.Enabled = False
    End Sub

    Private Sub Rdonew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdonew.CheckedChanged
        Dim vDate As Date
        Dim vpurchaserate, vRate As Double
        'If IsDate(mskdate.Value) = False Then
        '    Call FillItems()
        '    mskdate.Focus()
        '    Exit Sub
        'End If
        LstPOS.Items.Clear()
        LstCATEGORY.Items.Clear()
        LstGroup.Items.Clear()
        LstSUBGROUP.Items.Clear()
        Lstitems.Items.Clear()
        Call FillPOS()
        Call FillCATEGORY()
        Call FillGroup()
        Call FillItems()
        Call FILLSUBGROUP()
        Call filllstitems()

        GroupBox2.Visible = True
        GroupBox3.Visible = True
        Label7.Visible = True
        Label1.Visible = True
        ' Label2.Visible = True
        mskdate.Visible = True
        cmdDateHelp.Visible = True
        CmdAdd.Text = "Update[F7]"
        If CmdAdd.Enabled = False Then
            CmdAdd.Enabled = True
        End If
        If Rdonew.Checked = True Then
            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.STARTINGDATE AS STARTINGDATE"
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "' " 'AND ISNULL(R.ENDINGDATE,'')= ''"
            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"
            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate "
            ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
            vconn.getDataSet(ssql, "ITEMMASTER")
            ssGrid.ClearRange(1, 1, -1, -1, True)
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                        ssGrid.MaxRows = ssGrid.Row + 500
                    End If
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 5
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                    End With
                    'mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
                Next
                'Else
                'CmdAdd.Text = "Add [F7]"
                'ssGrid.ClearRange(1, 1, -1, -1, True)
            End If

        End If
    End Sub

    Private Sub Lstitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Lstitems.KeyDown
        If e.KeyCode = Keys.Enter Then
            OptValue.Focus()
        End If
    End Sub

    Private Sub Lstitems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lstitems.SelectedIndexChanged

        Dim j, i As Integer
        Dim LstSITEM1() As String
        vitem = ""
        For j = 0 To Lstitems.Items.Count - 1
            If Lstitems.GetItemChecked(j) = True Then
                If Trim(vitem) = "" Then
                    LstSITEM1 = Split(Lstitems.Items.Item(j), "-->")
                    vitem = " '" & LstSITEM1(0) & "' "
                    'MessageBox.Show(LstPOS1(0))
                Else
                    LstSITEM1 = Split(Lstitems.Items.Item(j), "-->")
                    vitem = vitem & " '" & LstSITEM1(0) & "' "
                    'MessageBox.Show(LstPOS1(0))

                End If
            End If

        Next j

        'Dim j As Integer
        'vitem = ""
        'For j = 0 To Lstitems.Items.Count - 1
        '    If Lstitems.GetItemChecked(j) = True Then
        '        If Trim(vitem) = "" Then
        '            vitem = " '" & Lstitems.Items.Item(j) & "'"
        '        Else
        '            vitem = "" & vitem & ",'" & Lstitems.Items.Item(j) & "'"
        '        End If
        '    End If
        'Next j
        ssGrid.ClearRange(1, 1, -1, -1, True)
        If Rdoprevious.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.PRITEMRATE AS PRITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE " 'WHERE R.STARTINGDATE ='" & Format(mskdate.Value, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            If Trim(vitem & "") <> "" Then
                ssql = ssql & " AND I.itemCODE IN (" & vitem & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count

                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        '.Col = 7
                        ' .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified ITEMCode is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To Lstitems.Items.Count - 1
                    Lstitems.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdoexisting.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.EXITEMRATE AS EXITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            If Trim(vitem & "") <> "" Then
                ssql = ssql & " AND I.itemCODE IN (" & vitem & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                        'aset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        '.Col = 14
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("SUBGROUPCODE"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified ITEMCode is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To Lstitems.Items.Count - 1
                    Lstitems.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdonew.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,r.pritemrate as pritemrate,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE and  P.POS=R.RPOSCODE WHERE R.STARTINGDATE <='" & Format(Now, "dd-MMM-yyyy") & "'" ' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            If Trim(vitem & "") <> "" Then
                ssql = ssql & " AND I.itemCODE IN (" & vitem & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))

                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("prITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 8
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")                      
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                Next i
            Else
                MessageBox.Show(" Specified ITEMCode is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To Lstitems.Items.Count - 1
                    Lstitems.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        ElseIf Rdomodified.Checked = True Then
            ssql = "SELECT R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,I.GROUPCODE AS GROUPCODE,I.ADDUSERID AS ADDUSERID,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.RPOSCODE AS POS,R.STARTINGDATE AS STARTINGDATE,I.CATEGORY AS CATEGORY,I.SUBGROUPCODE AS SUBGROUPCODE "
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE  AND P.POS=R.RPOSCODE WHERE R.STARTINGDATE >'" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'') = ''  "
            If Trim(vPOint & "") <> "" Then
                ssql = ssql & " AND R.RPOSCODE IN (" & vPOint & ")"
            End If

            If Trim(vcategory & "") <> "" Then
                ssql = ssql & " AND I.CATEGORY IN (" & vcategory & ")"
            End If

            If Trim(vGroup & "") <> "" Then
                ssql = ssql & " AND I.GROUPCODE IN (" & vGroup & ")"
            End If
            If Trim(vsubgroup & "") <> "" Then
                ssql = ssql & " AND I.subgroupCODE IN (" & vsubgroup & ")"
            End If
            If Trim(vitem & "") <> "" Then
                ssql = ssql & " AND I.itemCODE IN (" & vitem & ")"
            End If
            ssql = ssql & " ORDER BY ITEMCODE"
            vconn.getDataSet(ssql, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 7
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 8
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))

                    End With
                    'End If
                Next i
            Else
                MessageBox.Show(" Specified ITEMCode is not avaliable", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                For i = 0 To Lstitems.Items.Count - 1
                    Lstitems.SetItemChecked(i, False)
                Next
                Call FillItems()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub Chkitems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkitems.CheckedChanged

        Dim i As Integer
        If Chkitems.Checked = True Then
            For i = 0 To Lstitems.Items.Count - 1
                Lstitems.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Lstitems.Items.Count - 1
                Lstitems.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Rdomodified_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdomodified.CheckedChanged
        Dim vDate As Date
        Dim vpurchaserate, vRate As Double
        'If IsDate(mskdate.Value) = False Then
        '    Call FillItems()
        '    mskdate.Focus()
        '    Exit Sub
        'End If
        GroupBox2.Visible = True
        GroupBox3.Visible = True
        Label7.Visible = True
        Label1.Visible = True
        'Label2.Visible = True
        mskdate.Visible = True
        cmdDateHelp.Visible = True
        If CmdAdd.Enabled = False Then
            CmdAdd.Enabled = True
        End If
        If Rdomodified.Checked = True Then
            ssql = " SELECT R.RPOSCODE AS POS,R.ITEMCODE AS ITEMCODE ,I.ITEMDESC AS ITEMDESC,I.ITEMTYPECODE AS ITEMTYPECODE ,i.adduserid as adduserid ,"
            ssql = ssql & " R.UOM AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCAHSERATE ,R.ITEMRATE AS ITEMRATE,R.pritemrate as pritemrate,R.STARTINGDATE AS STARTINGDATE"
            ssql = ssql & " FROM RateMaster AS R INNER JOIN ITEMMASTER AS I ON R.ITEMCODE = I.ITEMCODE"
            ssql = ssql & " INNER JOIN POSMENULINK AS P ON P.ITEMCODE = R.ITEMCODE AND P.POS=R.RPOSCODE  WHERE R.STARTINGDATE > '" & Format(Now, "dd-MMM-yyyy") & "' AND ISNULL(R.ENDINGDATE,'')= ''"
            'IN (SELECT MAX(STARTINGDATE) FROM FRM_MKGA_RateMaster) AND ISNULL(R.ENDINGDATE,'') = ''"
            ssql = ssql & " GROUP BY R.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,R.UOM,R.PURCAHSERATE,R.ITEMRATE,R.RPOSCODE,R.STARTINGDATE,i.adduserid,r.pritemrate "
            ssql = ssql & " ORDER BY ITEMCODE,ITEMDESC"
            vconn.getDataSet(ssql, "ITEMMASTER")
            ssGrid.ClearRange(1, 1, -1, -1, True)
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("ITEMMASTER").Rows.Count
                    If gdataset.Tables("ITEMMASTER").Rows.Count >= 500 Then
                        ssGrid.MaxRows = ssGrid.Row + 500
                    End If
                    With ssGrid
                        .Row = i
                        .Col = 1
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        .Col = 2
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMCODE"))
                        .Col = 3
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMDESC"))
                        .Col = 4
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("UOM"))
                        '.Col = 5
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PURCAHSERATE")), "0.00")
                        '.Col = 6
                        '.Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        .Col = 7
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("PRITEMRATE")), "0.00")
                        .Col = 8
                        .Text = Format(Val(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("ITEMRATE")), "0.00")
                        '.Col = 9
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("POS"))
                        '.Col = 12
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("CATEGORY"))
                        '.Col = 13
                        '.Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("GROUPCODE"))
                        .Col = 11
                        .Text = CStr(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("AddUserID"))
                    End With
                    'mskdate.Value = Format(gdataset.Tables("ITEMMASTER").Rows(i - 1).Item("STARTINGDATE"), "dd/MMM/yyyy")
                Next
                'Else
                'CmdAdd.Text = "Add [F7]"
                'ssGrid.ClearRange(1, 1, -1, -1, True)
            End If

        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub mskdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskdate.ValueChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM ratemaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM ratemaster", "SERIALNO", 0)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ratemaster set  ", "WITHEFFECTFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ratemaster set  ", "WITHEFFECTFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM ratemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ratemaster set  ", "WITHEFFECTFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub Rdorate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdorate.CheckedChanged
        LstPOS.Items.Clear()
        LstCATEGORY.Items.Clear()
        LstGroup.Items.Clear()
        LstSUBGROUP.Items.Clear()
        Lstitems.Items.Clear()
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click

    End Sub
End Class