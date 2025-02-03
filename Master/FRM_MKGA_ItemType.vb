Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_ItemType
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vseqno, vTaxseqno As Double
    Friend WithEvents lvm_taxon As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Pnl_tax As System.Windows.Forms.Panel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbrse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Dim gconnection As New GlobalClass
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmdItemHelp As System.Windows.Forms.Button
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemTypeDesc As System.Windows.Forms.Label
    Friend WithEvents lbl_ItemType As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CMDREPORT As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ef_FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents ef_todate As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_ItemType))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvm_taxon = New AxFPSpreadADO.AxfpSpread()
        Me.Pnl_tax = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_ItemType = New System.Windows.Forms.Label()
        Me.lbl_ItemTypeDesc = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtItemType = New System.Windows.Forms.TextBox()
        Me.ef_todate = New System.Windows.Forms.DateTimePicker()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.ef_FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.cmdItemHelp = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CMDREPORT = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbrse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.lvm_taxon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(184, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 16)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "TAX  TYPE  MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lvm_taxon)
        Me.GroupBox1.Controls.Add(Me.Pnl_tax)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemType)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemTypeDesc)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtItemType)
        Me.GroupBox1.Controls.Add(Me.ef_todate)
        Me.GroupBox1.Controls.Add(Me.txtItemDesc)
        Me.GroupBox1.Controls.Add(Me.ef_FROMDATE)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ssgrid)
        Me.GroupBox1.Controls.Add(Me.cmdItemHelp)
        Me.GroupBox1.Location = New System.Drawing.Point(191, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(659, 422)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'lvm_taxon
        '
        Me.lvm_taxon.DataSource = Nothing
        Me.lvm_taxon.Location = New System.Drawing.Point(509, 152)
        Me.lvm_taxon.Name = "lvm_taxon"
        Me.lvm_taxon.OcxState = CType(resources.GetObject("lvm_taxon.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lvm_taxon.Size = New System.Drawing.Size(128, 240)
        Me.lvm_taxon.TabIndex = 18
        Me.lvm_taxon.Visible = False
        '
        'Pnl_tax
        '
        Me.Pnl_tax.Location = New System.Drawing.Point(510, 160)
        Me.Pnl_tax.Name = "Pnl_tax"
        Me.Pnl_tax.Size = New System.Drawing.Size(125, 230)
        Me.Pnl_tax.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(378, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Effctive To"
        '
        'lbl_ItemType
        '
        Me.lbl_ItemType.AutoSize = True
        Me.lbl_ItemType.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemType.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemType.Location = New System.Drawing.Point(120, 23)
        Me.lbl_ItemType.Name = "lbl_ItemType"
        Me.lbl_ItemType.Size = New System.Drawing.Size(59, 14)
        Me.lbl_ItemType.TabIndex = 11
        Me.lbl_ItemType.Text = "Tax Type "
        '
        'lbl_ItemTypeDesc
        '
        Me.lbl_ItemTypeDesc.AutoSize = True
        Me.lbl_ItemTypeDesc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemTypeDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemTypeDesc.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemTypeDesc.Location = New System.Drawing.Point(74, 68)
        Me.lbl_ItemTypeDesc.Name = "lbl_ItemTypeDesc"
        Me.lbl_ItemTypeDesc.Size = New System.Drawing.Size(86, 14)
        Me.lbl_ItemTypeDesc.TabIndex = 14
        Me.lbl_ItemTypeDesc.Text = "Tax Type Desc"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(647, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 26)
        Me.Button1.TabIndex = 12
        Me.Button1.Visible = False
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.White
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.ForeColor = System.Drawing.Color.Black
        Me.txtItemType.Location = New System.Drawing.Point(224, 20)
        Me.txtItemType.MaxLength = 8
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(104, 20)
        Me.txtItemType.TabIndex = 0
        '
        'ef_todate
        '
        Me.ef_todate.CustomFormat = "dd/MM/yyyy"
        Me.ef_todate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ef_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ef_todate.Location = New System.Drawing.Point(458, 105)
        Me.ef_todate.Name = "ef_todate"
        Me.ef_todate.Size = New System.Drawing.Size(152, 20)
        Me.ef_todate.TabIndex = 16
        Me.ef_todate.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'txtItemDesc
        '
        Me.txtItemDesc.BackColor = System.Drawing.Color.White
        Me.txtItemDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDesc.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.ForeColor = System.Drawing.Color.Black
        Me.txtItemDesc.Location = New System.Drawing.Point(224, 64)
        Me.txtItemDesc.MaxLength = 15
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(224, 20)
        Me.txtItemDesc.TabIndex = 1
        '
        'ef_FROMDATE
        '
        Me.ef_FROMDATE.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ef_FROMDATE.CustomFormat = "dd/MM/yyyy"
        Me.ef_FROMDATE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ef_FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ef_FROMDATE.Location = New System.Drawing.Point(224, 104)
        Me.ef_FROMDATE.Name = "ef_FROMDATE"
        Me.ef_FROMDATE.Size = New System.Drawing.Size(144, 20)
        Me.ef_FROMDATE.TabIndex = 15
        Me.ef_FROMDATE.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(72, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Effctive From"
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(52, 153)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(444, 240)
        Me.ssgrid.TabIndex = 2
        '
        'cmdItemHelp
        '
        Me.cmdItemHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdItemHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemHelp.Location = New System.Drawing.Point(333, 18)
        Me.cmdItemHelp.Name = "cmdItemHelp"
        Me.cmdItemHelp.Size = New System.Drawing.Size(35, 26)
        Me.cmdItemHelp.TabIndex = 12
        Me.cmdItemHelp.Text = "F4"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(368, 634)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 23)
        Me.lbl_Freeze.TabIndex = 17
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Navy
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(648, 384)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(24, 32)
        Me.CmdView.TabIndex = 7
        Me.CmdView.Text = " View[F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        Me.CmdView.Visible = False
        '
        'CMDREPORT
        '
        Me.CMDREPORT.BackColor = System.Drawing.Color.Navy
        Me.CMDREPORT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDREPORT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREPORT.ForeColor = System.Drawing.Color.White
        Me.CMDREPORT.Image = CType(resources.GetObject("CMDREPORT.Image"), System.Drawing.Image)
        Me.CMDREPORT.Location = New System.Drawing.Point(887, 662)
        Me.CMDREPORT.Name = "CMDREPORT"
        Me.CMDREPORT.Size = New System.Drawing.Size(104, 32)
        Me.CMDREPORT.TabIndex = 8
        Me.CMDREPORT.Text = "Crystal[F12]"
        Me.CMDREPORT.UseVisualStyleBackColor = False
        Me.CMDREPORT.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Navy
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Image = CType(resources.GetObject("cmdexport.Image"), System.Drawing.Image)
        Me.cmdexport.Location = New System.Drawing.Point(768, 384)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(24, 32)
        Me.cmdexport.TabIndex = 9
        Me.cmdexport.Text = " Export[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(240, 662)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(384, 16)
        Me.Label5.TabIndex = 417
        Me.Label5.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(863, 574)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 65)
        Me.cmdexit.TabIndex = 424
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(863, 507)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 423
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbrse
        '
        Me.Cmdbrse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbrse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbrse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbrse.Location = New System.Drawing.Point(863, 441)
        Me.Cmdbrse.Name = "Cmdbrse"
        Me.Cmdbrse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbrse.TabIndex = 422
        Me.Cmdbrse.Text = "Browse"
        Me.Cmdbrse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(863, 309)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 421
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(863, 241)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 420
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(863, 171)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 65)
        Me.CmdClear.TabIndex = 419
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(863, 103)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 65)
        Me.CmdAdd.TabIndex = 418
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'cmd_rpt
        '
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(862, 375)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(144, 65)
        Me.cmd_rpt.TabIndex = 435
        Me.cmd_rpt.Text = "REPORT"
        Me.cmd_rpt.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(862, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 65)
        Me.Button2.TabIndex = 435
        Me.Button2.Text = "REPORT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FRM_MKGA_ItemType
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1026, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmd_rpt)
        Me.Controls.Add(Me.CMDREPORT)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbrse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CmdView)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_ItemType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITEM TYPE MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.lvm_taxon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ItemType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillGrid()
        itemtypebool = True
        ef_FROMDATE.Value = Now
        ef_todate.Value = Now
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Select()
        ssgrid.Lock = True
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
    Private Sub txtItemtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtItemType.Text) <> "" Then
                Call txtItemtype_Validated(txtItemType, e)
                Exit Sub
            Else
                Call cmdItemHelp_Click(sender, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtItemtype_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdItemHelp.Enabled = True Then
                Search = Trim(txtItemType.Text)
                Call cmdItemHelp_Click(cmdItemHelp, e)
            End If
        End If
    End Sub
    Private Sub txtItemDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.ef_FROMDATE.Focus()
        End If
    End Sub

    Private Sub FillGrid()
        Dim j, i As Integer
        i = 1
        sqlstring = " SELECT DISTINCT ISNULL(T.TaxCode,'') AS TaxCode,ISNULL(T.Taxdesc,'')AS Taxdesc,"
        sqlstring = sqlstring & " ISNULL(T.Taxpercentage,0) AS Taxpercentage" 'ISNULL(Glaccountin,'') AS Glaccountin  "
        '    sqlstring = sqlstring & " FROM ACCOUNTSTAXMASTER AS T  WHERE  T.Taxpercentage <> 0 AND ISNULL(Freezeflag,'') <> 'Y'"
        sqlstring = sqlstring & " FROM ACCOUNTSTAXMASTER AS T  WHERE  ISNULL(Freezeflag,'') <> 'Y'"
        gconnection.getDataSet(sqlstring, "ACCOUNTSTAXMASTER")
        If gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count > 0 Then
            ssgrid.ClearRange(1, 1, -1, -1, True)
            For j = 0 To gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count - 1
                With ssgrid
                    .Row = i
                    .Col = 1
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("TaxCode")
                    .Row = i
                    .Col = 2
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Taxdesc")
                    .Row = i
                    .Col = 3
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Taxpercentage")
                    'pardha
                    '.Row = i
                    '.Col = 6
                    '.Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Glaccountin")
                    i = i + 1
                End With
            Next
            ssgrid.SetActiveCell(4, 1)
        End If
    End Sub

    Private Sub txtItemtype_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        Try
            If Trim(txtItemType.Text) <> "" Then
                sqlstring = "SELECT * FROM ItemTypeMaster WHERE ItemtypeCode= '" & Trim(txtItemType.Text) & "'"
                gconnection.getDataSet(sqlstring, "ItemTypeMaster")
                If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                    txtItemType.Clear()
                    txtItemType.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemtypeCode")))
                    txtItemDesc.Clear()
                    txtItemDesc.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemTypedesc")))
                    ef_FROMDATE.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("startingdate")))
                    ef_todate.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("endingdate")))
                    If gdataset.Tables("ItemTypeMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("ItemTypeMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                        'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Call FillTaxMaster()
                    Me.txtItemType.ReadOnly = True
                    Me.cmdItemHelp.Enabled = False
                    Me.CmdAdd.Text = "Update[F7]"
                    Call GridLocking()
                    txtItemDesc.Focus()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CmdAdd.Text = "Add [F7]"
                    txtItemType.ReadOnly = False
                    txtItemDesc.Focus()
                End If
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            Else
                txtItemType.Text = ""
                txtItemDesc.Text = ""
                txtItemDesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillTaxMaster()
        ''*********************************** TO FILL TAX FROM ACCOUNTSTAXMASTER IF ITEMTYPE IS NOT THERE ******************'''
        Try
            Dim j, i, COUNTER As Integer
            sqlstring = " SELECT ItemTypeCode,TaxCode,TaxPercentage,AccountCode,ISNULL(Startingdate,GETDATE()) AS Startingdate,ISNULL(EndingDate,GETDATE()) AS EndingDate,taxon FROM TAXITEMLINK WHERE itemtypecode = '" & Trim(txtItemType.Text) & "'"
            gconnection.getDataSet(sqlstring, "TAXITEMLINK")
            If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("TAXITEMLINK").Rows.Count - 1
                    For i = 1 To ssgrid.DataRowCnt
                        ssgrid.Row = i
                        ssgrid.Col = 1
                        COUNTER = String.Compare(Trim(ssgrid.Text), Trim(gdataset.Tables("TAXITEMLINK").Rows(j).Item("TaxCode")))
                        If COUNTER = 0 Then
                            'ssgrid.Col = 4
                            'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                            'ssgrid.SetText(4, i, 1)

                            ''ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                            'ssgrid.SetText(4, i, DateValue(gdataset.Tables("TAXITEMLINK").Rows(j).Item("Startingdate")))
                            ssgrid.Col = 4
                            ssgrid.Row = i
                            'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                            ssgrid.TypeComboBoxString = (Trim(gdataset.Tables("TAXITEMLINK").Rows(j).Item("taxon")))
                            ssgrid.Text = Trim(gdataset.Tables("TAXITEMLINK").Rows(j).Item("taxon"))
                            'ssgrid.SetText(5, i, Trim(gdataset.Tables("TAXITEMLINK").Rows(j).Item("taxon")))
                            'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                            'ssgrid.SetText(7, i, "True")
                            'ssgrid.SetActiveCell(5, i)
                        End If
                    Next
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click_1(CmdClear, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F8 Then
        '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '    Exit Sub
        'End If
        'If e.KeyCode = Keys.F7 Then
        '    Call CmdAdd_Click(CmdAdd, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F4 Then
            Call cmdItemHelp_Click(cmdItemHelp, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click_1(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click_1(CmdAdd, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call Cmd_view_Click(CmdView, e)
                Exit Sub
            End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If cmdexport.Enabled = True Then
        '        Call CmdView_Click(cmdexport, e)
        '        Exit Sub
        '    End If
        'End If
        'If e.KeyCode = Keys.F12 Then
        '    If CMDREPORT.Enabled = True Then
        '        Call CMDREPORT_Click(CMDREPORT, e)
        '        Exit Sub
        '    End If
        'End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(cmdexit, e)
            Exit Sub
        End If
    End Sub

    Public Sub FillTaxCode()
        'Dim vform As New ListOperattion1
        ' ''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO ssgrid ********** 
        'gSQLString = "SELECT DISTINCT TaxCode,TaxDesc,TaxPercentage,TypeofTax,Glaccountin,Glaccountdesc FROM ACCOUNTSTAXMASTER"
        'If Trim(Search) = " " Then
        '    M_WhereCondition = ""
        'Else
        '    M_WhereCondition = " WHERE TaxCode LIKE '" & Search & "%' AND ISNULL(Freezeflag,'')  <> 'Y'"
        'End If
        'vform.Field = "TAXCODE,TAXDESC"
        'vform.vFormatstring = "  TAXCODE           |                 TAXDESC                         |  TAX PERCENTAGE  |  TAXTYPE  | "
        'vform.vCaption = "TAX MASTER HELP"
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TaxCode,TaxDesc,TaxPercentage,TypeofTax,Glaccountin,Glaccountdesc FROM ACCOUNTSTAXMASTER WHERE"
        M_WhereCondition = "   TaxCode LIKE '" & Search & "%' AND ISNULL(Freezeflag,'')  <> 'Y'"
        vform.Field = "TAXCODE,TAXDESC"
        ' vform.Frmcalled = "  TAXCODE           |                 TAXDESC                |  TAX PERCENTAGE  |  TAXTYPE  | "
        vform.vCaption = "TAX MASTER HELP  "

        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = vform.keyfield
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = vform.keyfield1
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = vform.keyfield2
            'ssgrid.Col = 6
            'ssgrid.Row = ssgrid.ActiveRow
            'ssgrid.Text = vform.keyfield4
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
        Else
            ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing

    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.ssgrid.ClearRange(1, 1, -1, -1, True)
        Me.CmdAdd.Text = "Add [F7]"
        Call FillGrid()
        txtItemType.ReadOnly = False
        cmdItemHelp.Enabled = True
        lvm_taxon.Visible = False
        ef_FROMDATE.Value = Now
        ef_todate.Value = Now
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Select()
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strSQL, Insert(0), Update(0), Taxpercent() As String
        'Dim vDate As Date
        Dim i, j As Integer
        If Mid(Trim(CmdAdd.Text), 1, 1) = "A" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            'For i = 1 To ssgrid.DataRowCnt Step 1
            '    ssgrid.Col = 4
            '    ssgrid.Row = i
            '    If Val(ssgrid.Text) = 0 Then
            '        COUNTER = COUNTER + 1
            '    End If
            'Next i
            'If COUNTER = 0 Then
            'vseqno = GetSeqno(txtItemType.Text)
            'strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,taxcode,taxseqno,TaxPercentage ,Freeze ,StartingDate,EndingDate,AddUserin,AddDateTime)"
            'strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
            'strSQL = strSQL & "'',0,0,'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
            'strSQL = strSQL & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
            'Insert(0) = strSQL
            'strSQL = " INSERT INTO TAXITEMLINK(WithEffect,ItemSeqno,ItemTypeCode,TaxCode,TaxSeqno,TaxPercentage,Startingdate,EndingDate)"
            'strSQL = strSQL & " VALUES ( '" & Format(Now, "dd-MMM-yyyy ") & "'," & Val(vseqno) & ",'" & Trim(txtItemType.Text) & "',"
            'strSQL = strSQL & " '',0,0,'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "')"
            'ReDim Preserve Insert(Insert.Length)
            'Insert(Insert.Length - 1) = strSQL
            'End If
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,freeze,StartingDate,EndingDate,taxcode,taxseqno,TaxPercentage ,Taxon,AddUserin,AddDateTime)"
                    strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                    strSQL = strSQL & "'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'vseqno = GetSeqno(ssgrid.Text)
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "'," & Val(vseqno) & ","
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 1
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "','N',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    '"
                    '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                    'Insert(0) = strSQL
                End If
            Next i
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = "INSERT INTO TAXITEMLINK(ItemSeqno,ItemTypeCode,Startingdate,EndingDate,TaxCode,TaxSeqno,TaxPercentage ,taxon,adduser,adddatetime) "
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'strSQL = strSQL & " VALUES('" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    strSQL = strSQL & " VALUES( " & Val(vseqno) & ",'" & Trim(CStr(txtItemType.Text)) & "',"
                    strSQL = strSQL & "'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    'ssgrid.Col = 5
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "')"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                End If
            Next i
            gconnection.MoreTransold(Insert)
            Me.CmdClear_Click(sender, e)
        ElseIf Mid(Trim(CmdAdd.Text), 1, 1) = "U" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            'For i = 1 To ssgrid.DataRowCnt Step 1
            '    ssgrid.Col = 4
            '    ssgrid.Row = i
            '    If Val(ssgrid.Text) = 0 Then
            '        COUNTER = COUNTER + 1
            '    End If
            'Next i
            'If COUNTER = 0 Then
            'vseqno = GetSeqno(txtItemType.Text)
            'strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypeDesc = '" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
            ''AccountCode= '' ,Acctsegno =0 ,"
            'strSQL = strSQL & " TaxCode = '',TaxSeqno =0,TaxPercentage =0 ,StartingDate= '" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',endingDate= '" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
            'strSQL = strSQL & " AddUserin='" & Trim(gUsername) & "',AddDateTime= '" & Format(Now, "dd-MMM-yyyy ") & "'"
            'strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            'Update(0) = strSQL
            'strSQL = " UPDATE TAXITEMLINK SET WithEffect ='" & Format(Now, "dd-MMM-yyyy ") & "',TaxCode = '',TaxSeqno =0,TaxPercentage=0, "
            'strSQL = strSQL & " Startingdate = '" & Format(Now, "dd-MMM-yyyy ") & "',endingDate= '" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "'"
            'strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            'ReDim Preserve Update(Update.Length)
            'Update(Update.Length - 1) = strSQL
            'End If
            ' ''For i = 1 To ssgrid.DataRowCnt Step 1
            ' ''    ssgrid.Col = 4
            ' ''    ssgrid.Row = i
            ' ''    If Val(ssgrid.Text) = 1 Then
            ' ''        vseqno = GetSeqno(txtItemType.Text)
            ' ''        strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypedesc='" & Replace(Trim(CStr(txtItemDesc.Text)), "'", "") & "',"
            ' ''        strSQL = strSQL & " freeze='N',StartingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',EndingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',"
            ' ''        'ssgrid.Col = 6
            ' ''        'ssgrid.Row = i
            ' ''        'vseqno = GetSeqno(ssgrid.Text)
            ' ''        'strSQL = strSQL & " Accountcode = '" & Replace(Trim(ssgrid.Text), "'", "") & "',Acctsegno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 1
            ' ''        ssgrid.Row = i
            ' ''        vseqno = GetSeqno(ssgrid.Text)
            ' ''        strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',TaxSeqno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 3
            ' ''        ssgrid.Row = i
            ' ''        Taxpercent = Split(ssgrid.Text, "%")
            ' ''        strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
            ' ''        'ssgrid.Col = 1
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',Freeze = 'N',"
            ' ''        ssgrid.Col = 4
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
            ' ''        'strSQL = strSQL & " StartingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        If Val(ssgrid.Text) = 1 Then
            ' ''            strSQL = strSQL & " apply= 'Y',"
            ' ''        Else
            ' ''            strSQL = strSQL & " apply = 'N',"
            ' ''        End If
            ' ''        ssgrid.Col = 5
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ' ''        strSQL = strSQL & " taxon = '" & Trim(CStr(ssgrid.Text)) & "',"
            ' ''        'strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        strSQL = strSQL & " AddUserin = '" & Trim(gUsername) & "',AddDateTime = '" & Format(Now, "dd-MMM-yyyy ") & "'"
            ' ''        strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            ' ''        ReDim Preserve Update(Update.Length)
            ' ''        Update(Update.Length - 1) = strSQL
            ' ''        'Update(0) = strSQL
            ' ''    End If
            ' ''Next i
            ' ''For i = 1 To ssgrid.DataRowCnt Step 1
            ' ''    ssgrid.Col = 4
            ' ''    ssgrid.Row = i
            ' ''    If Val(ssgrid.Text) = 1 Then
            ' ''        strSQL = "UPDATE TAXITEMLINK SET "
            ' ''        'ssgrid.Col = 4
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " WithEffect = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        strSQL = strSQL & "StartingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',EndingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',"
            ' ''        ssgrid.Col = 1
            ' ''        ssgrid.Row = i
            ' ''        vseqno = GetSeqno(ssgrid.Text)
            ' ''        strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',TaxSeqno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 3
            ' ''        ssgrid.Row = i
            ' ''        Taxpercent = Split(ssgrid.Text, "%")
            ' ''        strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
            ' ''        'ssgrid.Col = 6
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " AccountCode = '" & Replace(Trim(ssgrid.Text), "'", "") & "',"
            ' ''        ssgrid.Col = 4
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
            ' ''        If Val(ssgrid.Text) = 1 Then
            ' ''            strSQL = strSQL & " apply = 'Y',"
            ' ''        Else
            ' ''            strSQL = strSQL & " apply = 'N',"
            ' ''        End If
            ' ''        'strSQL = strSQL & " Startingdate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        ssgrid.Col = 5
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ' ''        strSQL = strSQL & " taxon = '" & Trim(CStr(ssgrid.Text)) & "'"
            ' ''        'strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "'"
            ' ''        strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            ' ''        ReDim Preserve Update(Update.Length)
            ' ''        Update(Update.Length - 1) = strSQL
            ' ''    End If
            ' ''Next i
            ' ''gconnection.MoreTransold(Update)
            strSQL = " delete from ITEMTYPEMASTER where ItemTypeCode='" & Trim(txtItemType.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL
            strSQL = " delete from taxitemlink where ItemTypeCode='" & Trim(txtItemType.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL

            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,freeze,StartingDate,EndingDate,taxcode,taxseqno,TaxPercentage ,Taxon,AddUserin,AddDateTime)"
                    strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                    strSQL = strSQL & "'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'vseqno = GetSeqno(ssgrid.Text)
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "'," & Val(vseqno) & ","
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 1
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "','N',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    '"
                    '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                    'Insert(0) = strSQL
                End If
            Next i
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = "INSERT INTO TAXITEMLINK(ItemSeqno,ItemTypeCode,Startingdate,EndingDate,TaxCode,TaxSeqno,TaxPercentage ,taxon,adduser,adddatetime) "
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'strSQL = strSQL & " VALUES('" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    strSQL = strSQL & " VALUES( " & Val(vseqno) & ",'" & Trim(CStr(txtItemType.Text)) & "',"
                    strSQL = strSQL & "'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    'ssgrid.Col = 5
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "')"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                End If
            Next i
            gconnection.MoreTransold(Insert)
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim status As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  ITEMTYPEMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "ITEMTYPEMASTER")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If
        Else
            status = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "UPDATE  ITEMTYPEMASTER "
                sqlstring = sqlstring & " SET Freeze= 'N',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "ITEMTYPEMASTER")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If
        End If
    End Sub
    'Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
    '    '''*****************************************  View  And Print Operation *************************************'''
    '    Dim FrReport As New ReportDesigner
    '    tables = " FROM ITEMTYPEMASTER"
    '    Gheader = "ITEMTYPE MASTER"
    '    FrReport.ssgridReport.SetText(2, 1, "ITEMTYPECODE")
    '    FrReport.ssgridReport.SetText(3, 1, 10)
    '    FrReport.ssgridReport.SetText(2, 2, "ITEMTYPEDESC")
    '    FrReport.ssgridReport.SetText(3, 2, 35)
    '    FrReport.ssgridReport.SetText(2, 3, "ACCOUNTCODE")
    '    FrReport.ssgridReport.SetText(3, 3, 15)
    '    FrReport.ssgridReport.SetText(2, 4, "TAXCODE")
    '    FrReport.ssgridReport.SetText(3, 4, 15)
    '    FrReport.ssgridReport.SetText(2, 5, "TAXPERCENTAGE")
    '    FrReport.ssgridReport.SetText(3, 5, 10)
    '    FrReport.ssgridReport.SetText(2, 6, "STARTINGDATE")
    '    FrReport.ssgridReport.SetText(3, 6, 15)
    '    FrReport.ssgridReport.SetText(2, 7, "ENDINGDATE")
    '    FrReport.ssgridReport.SetText(3, 7, 15)
    '    FrReport.ssgridReport.SetText(2, 8, "FREEZE")
    '    FrReport.ssgridReport.SetText(3, 8, 5)
    '    FrReport.Show()
    'End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub checkValidation()
        Dim I, COUNTER As Integer
        boolchk = False
        ''******************************************* CHECK  ITEM TYPE CODE Can't be blank ***************************************'''
        If Trim(txtItemType.Text) = "" Then
            MessageBox.Show(" ITEM TYPE CODE Cannot be Blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemType.Focus()
            Exit Sub
        End If
        ''******************************************* CHECK  ITEM DESC Can't be blank ***************************************'''
        If Trim(txtItemDesc.Text) = "" Then
            MessageBox.Show(" ITEM TYPE DESCRIPTION Cannot be Blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemDesc.Focus()
            Exit Sub
        End If
        ' For I = 0 To ssgrid.DataRowCnt
        'ssgrid.Col = 4
        '    ssgrid.Row = I
        '    If ssgrid.Text = "True" Then
        '        COUNTER = COUNTER + 1
        '        If COUNTER >= 2 Then
        '            MessageBox.Show(" Multiple TAX CODE can't be selected ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ' ssgrid.SetActiveCell(7, I)
        '            Exit Sub
        '        End If
        '    End If
        ' Next
        Checkdaterangevalidate(ef_FROMDATE.Value, ef_todate.Value)
        If chkdatevalidate = False Then Exit Sub
        Dim CCT, TC As Integer
        Dim K As Integer
        'ssgrid.GetText(4, I, TC)
        'If TC = "" Then
        For K = 1 To ssgrid.DataRowCnt
            ssgrid.Col = 4
            ssgrid.Row = K
            If Trim(ssgrid.Text) = "" Then
                CCT = CCT + 1
            End If
        Next
        If CCT = ssgrid.DataRowCnt Then
            ' ssgrid.Col = 4
            'ssgrid.Row = I
            'ssgrid.Text = ""
            MsgBox("TAXON SHOULD NOT BE EMPTY ")
            'ssgrid.SetActiveCell(4, I)
            Exit Sub
        End If
        ' End If

        boolchk = True
    End Sub
    Public Function Checkdaterangevalidate(ByVal Startdate As Date, ByVal Enddate As Date) As Boolean
        chkdatevalidate = True
        'If DateDiff(DateInterval.Day, Enddate, DateValue(Now)) < 0 Then
        '    MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    chkdatevalidate = False
        '    Exit Function
        'End If
        If DateDiff(DateInterval.Day, Startdate, Enddate) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Function
        End If
        'If CDate(Startdate) >= CDate(Startdate) And CDate(Enddate) <= CDate(Enddate) Then
        '    chkdatevalidate = True
        'Else
        '    MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
        '    chkdatevalidate = False
        '    Exit Function
        'End If
        Return chkdatevalidate
    End Function
    Private Sub cmdItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemHelp.Click
        'Dim vform As New ListOperattion1
        'gSQLString = "SELECT distinct ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypemaster"
        'If Trim(Search) = " " Then
        '    M_WhereCondition = ""
        'Else
        '    M_WhereCondition = ""
        'End If
        'vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
        'vform.vFormatstring = "                ITEMTYPECODE             |                ITEMTYPECODE ITEMTYPECODE                             "
        'vform.vCaption = "ITEM TYPE MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    txtItemType.Text = Trim(vform.keyfield & "")
        '    Call txtItemtype_Validated(txtItemType, e)
        'End If
        'vform.Close()
        'vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT distinct ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypemaster"
            M_WhereCondition = " "
            vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
            ' vform.Frmcalled = "   ITEMTYPECODE     | ITEMTYPEDESC                                 "
            vform.vCaption = " ITEM TYPE  Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtItemType.Text = Trim(vform.keyfield & "")
                txtItemType.Select()
                txtItemtype_Validated(sender, e)
                CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub ItemType_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        itemtypebool = False
    End Sub
    Private Sub GridLocking()
        Dim Row, Col As Integer
        ssgrid.Col = 4
        ssgrid.Row = ssgrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 4
                ssgrid.Row = Row
                ssgrid.Col = Col
                ssgrid.Lock = True
            Next
        Next
        'ssgrid.Row = 1
        'For Col = 4 To 5
        '    ssgrid.Col = Col
        '    ssgrid.Lock = False
        'Next
    End Sub



    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim Sqlstring As String
        Dim i, j As Integer
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(0, i)
                        Exit Sub
                    ElseIf Trim(ssgrid.Text) <> "" Then
                        ssgrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    ssgrid.Row = i
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(1, i)
                        Exit Sub
                    Else
                        ssgrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(2, i)
                        Exit Sub
                    ElseIf Trim(ssgrid.Text) <> "" Then
                        ssgrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                    'ElseIf ssgrid.ActiveCol = 4 Then
                    '    ssgrid.Col = 4
                    '    ssgrid.Row = i
                    '    If Val(ssgrid.Text) = 0 Then
                    '        ssgrid.SetActiveCell(4, i)
                    '        'Exit Sub
                    '        'ElseIf Trim(ssgrid.Text) <> "" Then
                    '    Else
                    '        ssgrid.SetActiveCell(5, i)
                    '        Exit Sub
                    '    End If
                ElseIf ssgrid.ActiveCol = 4 Then
                    ssgrid.Col = 4
                    ssgrid.Row = i

                    'If ssgrid.Text = "" Then
                    'ssgrid.SetActiveCell(4, i)
                    'ssgrid.SetText(4, i, "")
                    'ssgrid.SetActiveCell(4, i)



                    'If Trim(ssgrid.Text) = "" Then
                    'ssgrid.SetActiveCell(5, i)
                    'Me.lvm_taxon.FullRowSelect = True
                    'pnl_UOMCode.Top = 50
                    lvm_taxon.Visible = True
                    Pnl_tax.Top = 50
                    Me.lvm_taxon.Focus()
                    lvm_taxon.Lock = True
                    lvm_taxon.SetActiveCell(1, 1)
                    'If lvm_taxon.Visible = True Then
                    '    ssgrid.SetActiveCell(4, i)
                    '    end if
                    ssgrid.Lock = True
                    'ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                    'End If
                    Exit Sub
                    'ElseIf Trim(ssgrid.Text) <> "" Then
                    '    ssgrid.SetActiveCell(5, i + 1)
                    '    ssgrid.Col = 4
                    '    ssgrid.Text = True
                    'End If

                    'ElseIf ssgrid.ActiveCol = 7 Then
                    '    ssgrid.Col = 7
                    '    ssgrid.Row = i
                    '    If Trim(ssgrid.Text) = True Then
                    '        ssgrid.SetActiveCell(3, i + 1)
                    '        Exit Sub
                    '    ElseIf Trim(ssgrid.Text) <> "" Then
                    '        ssgrid.SetActiveCell(3, i + 1)
                    '        ssgrid.Col = 4
                    '        ssgrid.Text = ""
                    '        ssgrid.Col = 5
                    '        ssgrid.Text = ""
                    '    End If
                    'End If
                ElseIf e.keyCode = Keys.F3 Then
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.ClearRange(1, ssgrid.ActiveRow, 15, ssgrid.ActiveRow, True)
                    ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim Sqlstring, TC, t As String
        Dim i, j, k, CCT, cc As Integer
        'CCT = 0
        i = ssgrid.ActiveRow
        If ssgrid.ActiveCol = 1 Then
            ssgrid.Col = 1
            ssgrid.Row = i
            If Trim(ssgrid.Text) = "" Then
                ssgrid.SetActiveCell(1, i)
                Exit Sub
            ElseIf Trim(ssgrid.Text) <> "" Then
                ssgrid.SetActiveCell(4, i)
                Exit Sub
            End If
        ElseIf ssgrid.ActiveCol = 2 Then
            ssgrid.Col = 2
            ssgrid.Row = i
            If Trim(ssgrid.Text) = "" Then
                ssgrid.SetActiveCell(2, i)
                Exit Sub
            Else
                ssgrid.SetActiveCell(5, i)
                Exit Sub
            End If
        ElseIf ssgrid.ActiveCol = 3 Then
            ssgrid.Col = 3
            ssgrid.Row = i
            If Trim(ssgrid.Text) = "" Then
                ssgrid.SetActiveCell(3, i)
                Exit Sub
            ElseIf Trim(ssgrid.Text) <> "" Then
                ssgrid.SetActiveCell(4, i)
                Exit Sub
            End If
        ElseIf ssgrid.ActiveCol = 4 Then
            ssgrid.Col = 4
            ssgrid.Row = i
            'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            'strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
            If Trim(CStr(ssgrid.Text)) = "" Then
                'ssgrid.Col = 4
                'ssgrid.Row = i
                'If Val(ssgrid.Text) = 0 Then
                '    ssgrid.Text = ""
                'End If
                Me.lvm_taxon.Focus()
                ssgrid.Lock = True

                'If lvm_taxon.Visible = True Then
                '    ssgrid.SetActiveCell(4, i)
                'End If
            ElseIf Trim(ssgrid.Text) <> "" Then
                ssgrid.GetText(4, i, TC)
                If TC = "1" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 0 ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "0A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 0 ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "0B" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0A" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 0A ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "1A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 1 ")
                        ssgrid.SetActiveCell(5, i)
                        Exit Sub
                    End If
                ElseIf TC = "1B" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1A" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 1A ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "2" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 1 ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "2A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 2 ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "2B" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2A" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 2A ")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf TC = "3" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 2")
                        ssgrid.SetActiveCell(5, i)
                        Exit Sub
                    End If
                ElseIf TC = "3A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 3 ")
                        ssgrid.SetActiveCell(5, i)
                        Exit Sub
                    End If
                ElseIf TC = "3B" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3A" Then
                            CCT = CCT + 1
                        End If
                    Next
                    If CCT = 0 Then
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        MsgBox("Grid must contain the value 3A")
                        ssgrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                End If
                'ssgrid.SetActiveCell(4, i)
                'ssgrid.Text = True
                'ssgrid.SetActiveCell(5, i + 1)

                Exit Sub
                'End If
                '    ElseIf ssgrid.ActiveCol = 4 Then
                '        ssgrid.Col = 4
                '        ssgrid.Row = i
                '        If Val(ssgrid.Text) = 0 Then
                '        'ssgrid.Text = Nothing
                '        'ssgrid.Col = 5
                '        'ssgrid.Row = i
                '        'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                '        ''strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                '        'If Trim(CStr(ssgrid.Text)) <> "" Then
                '        '    ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                '        '    Val(ssgrid.Text) = True
                '        'End If

                '        'ssgrid.SetActiveCell(4, i)
                ''Else
                'ssgrid.SetActiveCell(5, i)
                'ssgrid.Col = 5
                'ssgrid.Row = i
                'If ssgrid.Text <> "" Then
                '    ssgrid.GetText(5, i, TC)
                '    If TC = "0" Then
                '        For k = 1 To ssgrid.DataRowCnt
                '            ssgrid.Col = 5
                '            ssgrid.Row = k
                '            If Trim(ssgrid.Text) = "0" Then
                '                CCT = CCT + 1
                '            End If
                '        Next
                '        If CCT <= 1 Then
                '            ssgrid.GetText(5, i, t)
                '            If t = "0" Then
                '                For k = 1 To ssgrid.DataRowCnt
                '                    ssgrid.Col = 5
                '                    ssgrid.Row = k
                '                    If Trim(ssgrid.Text) = "1" Or Trim(ssgrid.Text) = "1A" Or Trim(ssgrid.Text) = "0A" Then
                '                        cc = cc + 1
                '                    End If
                '                Next
                '                If cc > 0 Then
                '                    'ssgrid.Col = 5
                '                    'ssgrid.Row = i
                '                    'ssgrid.Text = ""
                '                    MsgBox("U CANNOT REMOVE 0 IF 1 or 1A or 0A ARE PRESENT IN THE GRID")
                '                    'ssgrid.Col = 4
                '                    'ssgrid.Row = i
                '                    'ssgrid.SetText(4, i, 1)
                '                    'ssgrid.SetActiveCell(6, i)

                '                End If
                '            End If

                '            'Exit Sub
                '            'ElseIf Trim(ssgrid.Text) <> "" Then
                '        Else
                '            'ssgrid.SetActiveCell(5, i)

                '            'ssgrid.Col = 4
                '            'ssgrid.Text = ""
                '            ssgrid.Col = 5
                '            ssgrid.Row = i
                '            ssgrid.Text = ""
                '            ssgrid.SetActiveCell(6, i)
                '            'Exit Sub
                '        End If

                '        'pardha
                '    ElseIf TC = "1" Then
                '        For k = 1 To ssgrid.DataRowCnt
                '            ssgrid.Col = 5
                '            ssgrid.Row = k
                '            If Trim(ssgrid.Text) = "1" Then
                '                CCT = CCT + 1
                '            End If
                '        Next
                '        If CCT <= 1 Then
                '            ssgrid.GetText(5, i, t)
                '            If t = "1" Then
                '                For k = 1 To ssgrid.DataRowCnt
                '                    ssgrid.Col = 5
                '                    ssgrid.Row = k
                '                    If Trim(ssgrid.Text) = "2" Or Trim(ssgrid.Text) = "2A" Then
                '                        cc = cc + 1
                '                    End If
                '                Next
                '                If cc > 0 Then
                '                    'ssgrid.Col = 5
                '                    'ssgrid.Row = i
                '                    'ssgrid.Text = ""
                '                    MsgBox("U CANNOT REMOVE 1 IF 2 or 2A IS PRESENT IN THE GRID")
                '                    'ssgrid.Col = 4
                '                    'ssgrid.Row = i
                '                    ssgrid.SetText(4, i, 1)
                '                    'ssgrid.SetActiveCell(6, i)
                '                Else
                '                    'ssgrid.SetActiveCell(5, i)

                '                    'ssgrid.Col = 4
                '                    'ssgrid.Text = ""
                '                    ssgrid.Col = 5
                '                    ssgrid.Row = i
                '                    ssgrid.Text = ""
                '                    ssgrid.SetActiveCell(6, i)
                '                End If
                '            End If

                '            'Exit Sub
                '            'ElseIf Trim(ssgrid.Text) <> "" Then
                '        Else
                '            'ssgrid.SetActiveCell(5, i)

                '            'ssgrid.Col = 4
                '            'ssgrid.Text = ""
                '            ssgrid.Col = 5
                '            ssgrid.Row = i
                '            ssgrid.Text = ""
                '            ssgrid.SetActiveCell(6, i)
                '            'Exit Sub
                '        End If
                '        'pardha

                '    ElseIf TC = "2" Then
                '        For k = 1 To ssgrid.DataRowCnt
                '            ssgrid.Col = 5
                '            ssgrid.Row = k
                '            If Trim(ssgrid.Text) = "2" Then
                '                CCT = CCT + 1
                '            End If
                '        Next
                '        If CCT <= 1 Then
                '            ssgrid.GetText(5, i, t)
                '            If t = "2" Then
                '                For k = 1 To ssgrid.DataRowCnt
                '                    ssgrid.Col = 5
                '                    ssgrid.Row = k
                '                    If Trim(ssgrid.Text) = "3" Or Trim(ssgrid.Text) = "3A" Then
                '                        cc = cc + 1
                '                    End If
                '                Next
                '                If cc > 0 Then
                '                    'ssgrid.Col = 5
                '                    'ssgrid.Row = i
                '                    'ssgrid.Text = ""
                '                    MsgBox("U CANNOT REMOVE 2 IF 3 or 3A IS PRESENT IN THE GRID")
                '                    'ssgrid.Col = 4
                '                    'ssgrid.Row = i
                '                    ssgrid.SetText(4, i, 1)
                '                    ssgrid.SetActiveCell(6, i)
                '                Else
                '                    'ssgrid.SetActiveCell(5, i)

                '                    'ssgrid.Col = 4
                '                    'ssgrid.Text = ""
                '                    ssgrid.Col = 5
                '                    ssgrid.Row = i
                '                    ssgrid.Text = ""
                '                    ssgrid.SetActiveCell(6, i)

                '                End If

                '            End If

                '            'Exit Sub
                '            'ElseIf Trim(ssgrid.Text) <> "" Then
                '        Else
                '            'ssgrid.SetActiveCell(5, i)

                '            'ssgrid.Col = 4
                '            'ssgrid.Text = ""
                '            ssgrid.Col = 5
                '            ssgrid.Row = i
                '            ssgrid.Text = ""
                '            ssgrid.SetActiveCell(6, i)
                '            'Exit Sub
                '        End If
                '    Else
                '        ssgrid.Col = 5
                '        ssgrid.Row = i
                '        ssgrid.Text = ""
                '        ssgrid.SetActiveCell(6, i)
                '    End If
                '    'Else
                '    '    ssgrid.Col = 4
                '    '    ssgrid.Row = i
                '    '    If Val(ssgrid.Text) = 1 Then
                '    '        ssgrid.SetActiveCell(4, i)
                '    '    End If
                'End If
                ''Else
                '    ssgrid.SetActiveCell(5, i)
            End If
            'Else
            'ssgrid.SetActiveCell(6, i)
        End If

    End Sub

    Private Sub txtItemType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub

    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "ITEMTYPEMASTER"
    '    sqlstring = "SELECT * FROM ITEMTYPEMASTER order by ITEMTYPEcode"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub

    'Private Sub CMDREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREPORT.Click
    '    'GroupBox3.Visible = True

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    'Dim r As New CrptITEMTYPEMASTER
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    sqlstring = "select * from ITEMTYPEMASTER "

    '    Call Viewer.GetDetails(sqlstring, "ITEMTYPEMASTER", r)
    '    Viewer.TableName = "ITEMTYPEMASTER"

    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text2")
    '    TXTOBJ5.Text = gCompanyname

    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
    '    TXTOBJ1.Text = "UserName : " & gUsername

    '    Viewer.Show()
    'End Sub


    'Private Sub ssgrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ssgrid.MouseClick
    '    If ssgrid.ActiveCol = 4 Then
    '        ssgrid.Col = 4
    '        ssgrid.Row = ssgrid.ActiveRow
    '        If Val(ssgrid.Text) = 0 Then
    '            'ssgrid.SetActiveCell(4, i)
    '            ssgrid.Col = 5
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = ""
    '            'Exit Sub
    '            'ElseIf Trim(ssgrid.Text) <> "" Then
    '        Else
    '            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
    '            'ssgrid.Col = 4
    '            'ssgrid.Text = ""
    '            'ssgrid.Col = 5
    '            'ssgrid.Text = ""
    '            'Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub ef_FROMDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ef_FROMDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.ef_todate.Focus()
        End If
    End Sub

    Private Sub ef_todate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ef_todate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.ssgrid.Focus()
            ssgrid.SetActiveCell(4, 1)
        End If
    End Sub

    'Private Sub ssgrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ssgrid.MouseClick
    '    Dim i As Integer
    '    i = ssgrid.ActiveRow
    'End Sub



    Private Sub lvm_taxon_KeyPressEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles lvm_taxon.KeyPressEvent
        Dim strSQL As String
        Dim taxon As String
        Dim i, k, t, p, q As Integer
        Dim cct, tc, cc, taxon1 As String
        Dim taxcode As String
        'Call getAlphanumeric(e)
        'If Asc(e.KeyChar) = 13 Then
        '    'If e.KeyCode = Keys.13 Then
        'i = lvm_taxon.ActiveRow


        p = ssgrid.ActiveCol
        q = ssgrid.ActiveRow
        ssgrid.GetText(p, q, taxon1)


        Try
            'taxon = Trim(lvm_taxon.SelectedItems(0).SubItems(0).Text)
            lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)

        Catch ex As Exception
            lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)
            'uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
        Finally
            'lvm_taxon.SelBlockCol.ToString()
            ssgrid.Col = 4
            i = ssgrid.ActiveRow
            taxcode = Trim(ssgrid.Text)

            If taxon1 = "" Then
                ssgrid.SetText(4, ssgrid.ActiveRow, taxon)
                'ssgrid.SetText(6, ssgrid.ActiveRow, uomrate)
                Pnl_tax.Top = 1000
                ssgrid.Focus()
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ElseIf taxon1 <> "" Then
                i = ssgrid.ActiveRow
                ssgrid.GetText(4, i, tc)
                If tc = "0" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(5, i, t)
                        If tc = "0" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "1" Or Trim(ssgrid.Text) = "1A" Or Trim(ssgrid.Text) = "0A" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 0 IF 1 or 1A or 0A ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                'ssgrid.SetActiveCell(6, i)

                            End If
                            'ssgrid.SetActiveCell(1, i + 1)
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        'ssgrid.SetActiveCell(6, i)
                        'Exit Sub
                    End If
                ElseIf tc = "0A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "0A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "0B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 0A IF 0B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha
                ElseIf tc = "1A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "1A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "1B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 1A IF 1B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "2A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "2A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "2B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 2A IF 2B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "3A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "3A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 3A IF 3B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "1" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "1" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "2" Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 1 IF 2 or 2A or 2B ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha
                ElseIf tc = "3" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "3" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3A" Or Trim(ssgrid.Text) = "3B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 3 IF 3B or 3A  ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                'ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                                'ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha


                ElseIf tc = "2" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "2" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3" Or Trim(ssgrid.Text) = "3A" Or Trim(ssgrid.Text) = "3B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 2 IF 3 or 3A OR 3B ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                'ssgrid.SetActiveCell(5, i)

                            End If

                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                Else
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(4, i)
                End If
                'Else
                '    ssgrid.Col = 4
                '    ssgrid.Row = i
                '    If Val(ssgrid.Text) = 1 Then
                '        ssgrid.SetActiveCell(4, i)
                '    End If
            End If
            'End If


        End Try
        'End If
    End Sub

    'Private Sub lvm_taxon_MouseDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_MouseDownEvent) Handles lvm_taxon.MouseDownEvent
    '    Dim strSQL As String
    '    Dim taxon As String
    '    Dim i, k, t, p, q As Integer
    '    Dim cct, tc, cc, taxon1 As String
    '    Dim taxcode As String
    '    'Call getAlphanumeric(e)
    '    'If Asc(e.KeyChar) = 13 Then
    '    '    'If e.KeyCode = Keys.13 Then
    '    'i = lvm_taxon.ActiveRow


    '    p = ssgrid.ActiveCol
    '    q = ssgrid.ActiveRow
    '    ssgrid.GetText(p, q, taxon1)


    '    Try
    '        'taxon = Trim(lvm_taxon.SelectedItems(0).SubItems(0).Text)
    '        lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)

    '    Catch ex As Exception
    '        lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)
    '        'uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
    '    Finally
    '        'lvm_taxon.SelBlockCol.ToString()
    '        ssgrid.Col = 4
    '        i = ssgrid.ActiveRow
    '        taxcode = Trim(ssgrid.Text)

    '        If taxon1 = "" Then
    '            ssgrid.SetText(4, ssgrid.ActiveRow, taxon)
    '            'ssgrid.SetText(6, ssgrid.ActiveRow, uomrate)
    '            Pnl_tax.Top = 1000
    '            ssgrid.Focus()
    '            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
    '        ElseIf taxon1 <> "" Then
    '            i = ssgrid.ActiveRow
    '            ssgrid.GetText(4, i, tc)
    '            If tc = "0" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "0" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(5, i, t)
    '                    If tc = "0" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "1" Or Trim(ssgrid.Text) = "1A" Or Trim(ssgrid.Text) = "0A" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 0 IF 1 or 1A or 0A ARE PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            'ssgrid.SetActiveCell(6, i)

    '                        End If
    '                        'ssgrid.SetActiveCell(1, i + 1)
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = i
    '                    ssgrid.Text = ""
    '                    'ssgrid.SetActiveCell(6, i)
    '                    'Exit Sub
    '                End If
    '            ElseIf tc = "0A" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "0A" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "0A" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "0B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 0A IF 0B IS PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            ssgrid.SetActiveCell(4, i)
    '                        End If
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    'ssgrid.Col = 5
    '                    'ssgrid.Row = i
    '                    'ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '                'pardha
    '            ElseIf tc = "1A" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "1A" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "1A" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "1B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 1A IF 1B IS PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            ssgrid.SetActiveCell(4, i)
    '                        End If
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    'ssgrid.Col = 5
    '                    'ssgrid.Row = i
    '                    'ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '            ElseIf tc = "2A" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "2A" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "2A" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "2B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 2A IF 2B IS PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            ssgrid.SetActiveCell(4, i)
    '                        End If
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    'ssgrid.Col = 5
    '                    'ssgrid.Row = i
    '                    'ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '            ElseIf tc = "3A" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "3A" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "3A" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "3B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 3A IF 3B IS PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            ssgrid.SetActiveCell(4, i)
    '                        End If
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    'ssgrid.Col = 5
    '                    'ssgrid.Row = i
    '                    'ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '            ElseIf tc = "1" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "1" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "1" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "2" Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 1 IF 2 or 2A or 2B ARE PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            ssgrid.SetActiveCell(4, i)
    '                        End If
    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    'ssgrid.Col = 5
    '                    'ssgrid.Row = i
    '                    'ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '                'pardha

    '            ElseIf tc = "2" Then
    '                For k = 1 To ssgrid.DataRowCnt
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = k
    '                    If Trim(ssgrid.Text) = "2" Then
    '                        cct = cct + 1
    '                    End If
    '                Next
    '                If cct <= 1 Then
    '                    'ssgrid.GetText(4, i, t)
    '                    If tc = "2" Then
    '                        For k = 1 To ssgrid.DataRowCnt
    '                            ssgrid.Col = 4
    '                            ssgrid.Row = k
    '                            If Trim(ssgrid.Text) = "3" Or Trim(ssgrid.Text) = "3A" Or Trim(ssgrid.Text) = "3B" Then
    '                                cc = cc + 1
    '                            End If
    '                        Next
    '                        If cc > 0 Then
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            MsgBox("U CANNOT REMOVE 2 IF 3 or 3A OR 3B ARE PRESENT IN THE GRID")
    '                            'ssgrid.Col = 4
    '                            'ssgrid.Row = i
    '                            'ssgrid.SetText(4, i, 1)
    '                            ssgrid.SetActiveCell(4, i)
    '                        Else
    '                            'ssgrid.SetActiveCell(5, i)

    '                            'ssgrid.Col = 4
    '                            'ssgrid.Text = ""
    '                            'ssgrid.Col = 5
    '                            'ssgrid.Row = i
    '                            'ssgrid.Text = ""
    '                            'ssgrid.SetActiveCell(5, i)

    '                        End If

    '                    End If

    '                    'Exit Sub
    '                    'ElseIf Trim(ssgrid.Text) <> "" Then
    '                Else
    '                    'ssgrid.SetActiveCell(5, i)

    '                    'ssgrid.Col = 4
    '                    'ssgrid.Text = ""
    '                    ssgrid.Col = 4
    '                    ssgrid.Row = i
    '                    ssgrid.Text = ""
    '                    ssgrid.SetActiveCell(4, i)
    '                    'Exit Sub
    '                End If
    '            Else
    '                ssgrid.Col = 4
    '                ssgrid.Row = i
    '                ssgrid.Text = ""
    '                ssgrid.SetActiveCell(4, i)
    '            End If
    '            'Else
    '            '    ssgrid.Col = 4
    '            '    ssgrid.Row = i
    '            '    If Val(ssgrid.Text) = 1 Then
    '            '        ssgrid.SetActiveCell(4, i)
    '            '    End If
    '        End If
    '        'End If


    '    End Try
    '    'End If
    '    'End Sub
    'End Sub

    Private Sub lvm_taxon_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles lvm_taxon.DblClick
        Dim strSQL As String
        Dim taxon As String
        Dim i, k, t, p, q As Integer
        Dim cct, tc, cc, taxon1 As String
        Dim taxcode As String
        'Call getAlphanumeric(e)
        'If Asc(e.KeyChar) = 13 Then
        '    'If e.KeyCode = Keys.13 Then
        'i = lvm_taxon.ActiveRow


        p = ssgrid.ActiveCol
        q = ssgrid.ActiveRow
        ssgrid.GetText(p, q, taxon1)


        Try
            'taxon = Trim(lvm_taxon.SelectedItems(0).SubItems(0).Text)
            lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)

        Catch ex As Exception
            lvm_taxon.GetText(1, lvm_taxon.ActiveRow, taxon)
            'uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
        Finally
            'lvm_taxon.SelBlockCol.ToString()
            ssgrid.Col = 4
            i = ssgrid.ActiveRow
            taxcode = Trim(ssgrid.Text)

            If taxon1 = "" Then
                ssgrid.SetText(4, ssgrid.ActiveRow, taxon)
                'ssgrid.SetText(6, ssgrid.ActiveRow, uomrate)
                Pnl_tax.Top = 1000
                ssgrid.Focus()
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ElseIf taxon1 <> "" Then
                i = ssgrid.ActiveRow
                ssgrid.GetText(4, i, tc)
                If tc = "0" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(5, i, t)
                        If tc = "0" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "1" Or Trim(ssgrid.Text) = "1A" Or Trim(ssgrid.Text) = "0A" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 0 IF 1 or 1A or 0A ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                'ssgrid.SetActiveCell(6, i)

                            End If
                            'ssgrid.SetActiveCell(1, i + 1)
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        'ssgrid.SetActiveCell(6, i)
                        'Exit Sub
                    End If
                ElseIf tc = "0A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "0A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "0A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "0B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 0A IF 0B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha
                ElseIf tc = "1A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "1A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "1B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 1A IF 1B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "2A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "2A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "2B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 2A IF 2B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                'ssgrid.Col = 5

                                'ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "3A" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3A" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "3A" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3B" Then ' Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 3A IF 3B IS PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                ElseIf tc = "1" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "1" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "1" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "2" Or Trim(ssgrid.Text) = "2A" Or Trim(ssgrid.Text) = "2B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 1 IF 2 or 2A or 2B ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                'ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                                'ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha
                ElseIf tc = "3" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "3" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "3" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3A" Or Trim(ssgrid.Text) = "3B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 3 IF 3B or 3A  ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)

                                'ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                                'ssgrid.SetActiveCell(4, i)
                            End If
                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        'ssgrid.Col = 5
                        'ssgrid.Row = i
                        'ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                    'pardha

                ElseIf tc = "2" Then
                    For k = 1 To ssgrid.DataRowCnt
                        ssgrid.Col = 4
                        ssgrid.Row = k
                        If Trim(ssgrid.Text) = "2" Then
                            cct = cct + 1
                        End If
                    Next
                    If cct <= 1 Then
                        'ssgrid.GetText(4, i, t)
                        If tc = "2" Then
                            For k = 1 To ssgrid.DataRowCnt
                                ssgrid.Col = 4
                                ssgrid.Row = k
                                If Trim(ssgrid.Text) = "3" Or Trim(ssgrid.Text) = "3A" Or Trim(ssgrid.Text) = "3B" Then
                                    cc = cc + 1
                                End If
                            Next
                            If cc > 0 Then
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                MsgBox("U CANNOT REMOVE 2 IF 3 or 3A OR 3B ARE PRESENT IN THE GRID")
                                'ssgrid.Col = 4
                                'ssgrid.Row = i
                                'ssgrid.SetText(4, i, 1)
                                ssgrid.SetActiveCell(4, i)
                            Else
                                'ssgrid.SetActiveCell(5, i)
                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)

                                'ssgrid.Col = 4
                                'ssgrid.Text = ""
                                'ssgrid.Col = 5
                                'ssgrid.Row = i
                                'ssgrid.Text = ""
                                'ssgrid.SetActiveCell(5, i)

                            End If

                        End If

                        'Exit Sub
                        'ElseIf Trim(ssgrid.Text) <> "" Then
                    Else
                        'ssgrid.SetActiveCell(5, i)

                        'ssgrid.Col = 4
                        'ssgrid.Text = ""
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        'Exit Sub
                    End If
                Else
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(4, i)
                End If
                'Else
                '    ssgrid.Col = 4
                '    ssgrid.Row = i
                '    If Val(ssgrid.Text) = 1 Then
                '        ssgrid.SetActiveCell(4, i)
                '    End If
            End If
            'End If


        End Try

    End Sub

    Private Sub ssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "\STUDY\TAXTYPEMASTER.xls")
    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CmdClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        txtItemType.Text = ""
        txtItemDesc.Text = ""
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        Me.ssgrid.ClearRange(1, 1, -1, -1, True)
        Me.CmdAdd.Text = "Add [F7]"
        Call FillGrid()
        txtItemType.ReadOnly = False
        cmdItemHelp.Enabled = True
        lvm_taxon.Visible = False
        ef_FROMDATE.Value = Now
        ef_todate.Value = Now
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Select()
    End Sub

    Private Sub CmdAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim strSQL, Insert(0), Update(0), Taxpercent() As String
        'Dim vDate As Date
        Dim i, j As Integer
        If Mid(Trim(CmdAdd.Text), 1, 1) = "A" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            'For i = 1 To ssgrid.DataRowCnt Step 1
            '    ssgrid.Col = 4
            '    ssgrid.Row = i
            '    If Val(ssgrid.Text) = 0 Then
            '        COUNTER = COUNTER + 1
            '    End If
            'Next i
            'If COUNTER = 0 Then
            'vseqno = GetSeqno(txtItemType.Text)
            'strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,taxcode,taxseqno,TaxPercentage ,Freeze ,StartingDate,EndingDate,AddUserin,AddDateTime)"
            'strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
            'strSQL = strSQL & "'',0,0,'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
            'strSQL = strSQL & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
            'Insert(0) = strSQL
            'strSQL = " INSERT INTO TAXITEMLINK(WithEffect,ItemSeqno,ItemTypeCode,TaxCode,TaxSeqno,TaxPercentage,Startingdate,EndingDate)"
            'strSQL = strSQL & " VALUES ( '" & Format(Now, "dd-MMM-yyyy ") & "'," & Val(vseqno) & ",'" & Trim(txtItemType.Text) & "',"
            'strSQL = strSQL & " '',0,0,'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "')"
            'ReDim Preserve Insert(Insert.Length)
            'Insert(Insert.Length - 1) = strSQL
            'End If
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,freeze,StartingDate,EndingDate,taxcode,taxseqno,TaxPercentage ,Taxon,AddUserin,AddDateTime)"
                    strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                    strSQL = strSQL & "'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'vseqno = GetSeqno(ssgrid.Text)
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "'," & Val(vseqno) & ","
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 1
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "','N',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    '"
                    '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                    'Insert(0) = strSQL
                End If
            Next i
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = "INSERT INTO TAXITEMLINK(ItemSeqno,ItemTypeCode,Startingdate,EndingDate,TaxCode,TaxSeqno,TaxPercentage ,taxon,adduser,adddatetime) "
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'strSQL = strSQL & " VALUES('" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    strSQL = strSQL & " VALUES( " & Val(vseqno) & ",'" & Trim(CStr(txtItemType.Text)) & "',"
                    strSQL = strSQL & "'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    'ssgrid.Col = 5
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "')"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                End If
            Next i
            gconnection.MoreTransold(Insert)
            Me.CmdClear_Click_1(sender, e)
        ElseIf Mid(Trim(CmdAdd.Text), 1, 1) = "U" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            'For i = 1 To ssgrid.DataRowCnt Step 1
            '    ssgrid.Col = 4
            '    ssgrid.Row = i
            '    If Val(ssgrid.Text) = 0 Then
            '        COUNTER = COUNTER + 1
            '    End If
            'Next i
            'If COUNTER = 0 Then
            'vseqno = GetSeqno(txtItemType.Text)
            'strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypeDesc = '" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
            ''AccountCode= '' ,Acctsegno =0 ,"
            'strSQL = strSQL & " TaxCode = '',TaxSeqno =0,TaxPercentage =0 ,StartingDate= '" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',endingDate= '" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
            'strSQL = strSQL & " AddUserin='" & Trim(gUsername) & "',AddDateTime= '" & Format(Now, "dd-MMM-yyyy ") & "'"
            'strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            'Update(0) = strSQL
            'strSQL = " UPDATE TAXITEMLINK SET WithEffect ='" & Format(Now, "dd-MMM-yyyy ") & "',TaxCode = '',TaxSeqno =0,TaxPercentage=0, "
            'strSQL = strSQL & " Startingdate = '" & Format(Now, "dd-MMM-yyyy ") & "',endingDate= '" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "'"
            'strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            'ReDim Preserve Update(Update.Length)
            'Update(Update.Length - 1) = strSQL
            'End If
            ' ''For i = 1 To ssgrid.DataRowCnt Step 1
            ' ''    ssgrid.Col = 4
            ' ''    ssgrid.Row = i
            ' ''    If Val(ssgrid.Text) = 1 Then
            ' ''        vseqno = GetSeqno(txtItemType.Text)
            ' ''        strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypedesc='" & Replace(Trim(CStr(txtItemDesc.Text)), "'", "") & "',"
            ' ''        strSQL = strSQL & " freeze='N',StartingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',EndingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',"
            ' ''        'ssgrid.Col = 6
            ' ''        'ssgrid.Row = i
            ' ''        'vseqno = GetSeqno(ssgrid.Text)
            ' ''        'strSQL = strSQL & " Accountcode = '" & Replace(Trim(ssgrid.Text), "'", "") & "',Acctsegno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 1
            ' ''        ssgrid.Row = i
            ' ''        vseqno = GetSeqno(ssgrid.Text)
            ' ''        strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',TaxSeqno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 3
            ' ''        ssgrid.Row = i
            ' ''        Taxpercent = Split(ssgrid.Text, "%")
            ' ''        strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
            ' ''        'ssgrid.Col = 1
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',Freeze = 'N',"
            ' ''        ssgrid.Col = 4
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
            ' ''        'strSQL = strSQL & " StartingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        If Val(ssgrid.Text) = 1 Then
            ' ''            strSQL = strSQL & " apply= 'Y',"
            ' ''        Else
            ' ''            strSQL = strSQL & " apply = 'N',"
            ' ''        End If
            ' ''        ssgrid.Col = 5
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ' ''        strSQL = strSQL & " taxon = '" & Trim(CStr(ssgrid.Text)) & "',"
            ' ''        'strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        strSQL = strSQL & " AddUserin = '" & Trim(gUsername) & "',AddDateTime = '" & Format(Now, "dd-MMM-yyyy ") & "'"
            ' ''        strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            ' ''        ReDim Preserve Update(Update.Length)
            ' ''        Update(Update.Length - 1) = strSQL
            ' ''        'Update(0) = strSQL
            ' ''    End If
            ' ''Next i
            ' ''For i = 1 To ssgrid.DataRowCnt Step 1
            ' ''    ssgrid.Col = 4
            ' ''    ssgrid.Row = i
            ' ''    If Val(ssgrid.Text) = 1 Then
            ' ''        strSQL = "UPDATE TAXITEMLINK SET "
            ' ''        'ssgrid.Col = 4
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " WithEffect = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        strSQL = strSQL & "StartingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',EndingDate='" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "',"
            ' ''        ssgrid.Col = 1
            ' ''        ssgrid.Row = i
            ' ''        vseqno = GetSeqno(ssgrid.Text)
            ' ''        strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssgrid.Text)) & "',TaxSeqno = " & Val(vseqno) & ","
            ' ''        ssgrid.Col = 3
            ' ''        ssgrid.Row = i
            ' ''        Taxpercent = Split(ssgrid.Text, "%")
            ' ''        strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
            ' ''        'ssgrid.Col = 6
            ' ''        'ssgrid.Row = i
            ' ''        'strSQL = strSQL & " AccountCode = '" & Replace(Trim(ssgrid.Text), "'", "") & "',"
            ' ''        ssgrid.Col = 4
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
            ' ''        If Val(ssgrid.Text) = 1 Then
            ' ''            strSQL = strSQL & " apply = 'Y',"
            ' ''        Else
            ' ''            strSQL = strSQL & " apply = 'N',"
            ' ''        End If
            ' ''        'strSQL = strSQL & " Startingdate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
            ' ''        ssgrid.Col = 5
            ' ''        ssgrid.Row = i
            ' ''        ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ' ''        strSQL = strSQL & " taxon = '" & Trim(CStr(ssgrid.Text)) & "'"
            ' ''        'strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "'"
            ' ''        strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
            ' ''        ReDim Preserve Update(Update.Length)
            ' ''        Update(Update.Length - 1) = strSQL
            ' ''    End If
            ' ''Next i
            ' ''gconnection.MoreTransold(Update)
            strSQL = " delete from ITEMTYPEMASTER where ItemTypeCode='" & Trim(txtItemType.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL
            strSQL = " delete from taxitemlink where ItemTypeCode='" & Trim(txtItemType.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL

            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,freeze,StartingDate,EndingDate,taxcode,taxseqno,TaxPercentage ,Taxon,AddUserin,AddDateTime)"
                    strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                    strSQL = strSQL & "'N','" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'vseqno = GetSeqno(ssgrid.Text)
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "'," & Val(vseqno) & ","
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 1
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "','N',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    '"
                    '" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                    'Insert(0) = strSQL
                End If
            Next i
            For i = 1 To ssgrid.DataRowCnt Step 1
                ssgrid.Col = 4
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = "INSERT INTO TAXITEMLINK(ItemSeqno,ItemTypeCode,Startingdate,EndingDate,TaxCode,TaxSeqno,TaxPercentage ,taxon,adduser,adddatetime) "
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'strSQL = strSQL & " VALUES('" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    strSQL = strSQL & " VALUES( " & Val(vseqno) & ",'" & Trim(CStr(txtItemType.Text)) & "',"
                    strSQL = strSQL & "'" & Format(ef_FROMDATE.Value, "dd-MMM-yyyy ") & "','" & Format(ef_todate.Value, "dd-MMM-yyyy ") & "',"
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    vseqno = GetSeqno(ssgrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "'," & Val(vseqno) & ","
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    Taxpercent = Split(ssgrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    'ssgrid.Col = 6
                    'ssgrid.Row = i
                    'strSQL = strSQL & "'" & Replace(Trim(ssgrid.Text), "'", "") & "',"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "',"
                    'ssgrid.Col = 5
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    'strSQL = strSQL & "'" & Format(DateValue(ssgrid.Text), "dd-MMM-yyyy") & "')"
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeCheckBox
                    'If Val(ssgrid.Text) = 1 Then
                    '    strSQL = strSQL & "'Y',"
                    'Else
                    '    strSQL = strSQL & "'N',"
                    'End If
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    'ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                    strSQL = strSQL & "'" & Trim(CStr(ssgrid.Text)) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                End If
            Next i
            gconnection.MoreTransold(Insert)
            Me.CmdClear_Click_1(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Freeze_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim status As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            status = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "UPDATE  ITEMTYPEMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "ITEMTYPEMASTER")
                Me.CmdClear_Click_1(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If
            'Else
            '    status = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If status = 1 Then
            '        sqlstring = "UPDATE  ITEMTYPEMASTER "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "ITEMTYPEMASTER")
            '        Me.CmdClear_Click_1(sender, e)
            '        CmdAdd.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txtItemType.Text.Length > 0 Then
            tables = " FROM ITEMTYPEMASTER WHERE itemtypecode = '" & Trim(txtItemType.Text) & "'"
        Else
            tables = "FROM ITEMTYPEMASTER "
        End If
        Gheader = "ITEMTYPEMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"ITEMTYPECODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMTYPEDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ACCOUNTCODE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TAXCODE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TAXPERCENTAGE", "13"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TAXON", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"STARTINGDATE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ENDINGDATE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "6"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERIn", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
        ' Dim FrReport As New ReportDesigner
        '    tables = " FROM ITEMTYPEMASTER"
        '    Gheader = "ITEMTYPE MASTER"
        '    FrReport.ssgridReport.SetText(2, 1, "ITEMTYPECODE")
        '    FrReport.ssgridReport.SetText(3, 1, 10)
        '    FrReport.ssgridReport.SetText(2, 2, "ITEMTYPEDESC")
        '    FrReport.ssgridReport.SetText(3, 2, 35)
        '    FrReport.ssgridReport.SetText(2, 3, "ACCOUNTCODE")
        '    FrReport.ssgridReport.SetText(3, 3, 15)
        '    FrReport.ssgridReport.SetText(2, 4, "TAXCODE")
        '    FrReport.ssgridReport.SetText(3, 4, 15)
        '    FrReport.ssgridReport.SetText(2, 5, "TAXPERCENTAGE")
        '    FrReport.ssgridReport.SetText(3, 5, 10)
        '    FrReport.ssgridReport.SetText(2, 6, "STARTINGDATE")
        '    FrReport.ssgridReport.SetText(3, 6, 15)
        '    FrReport.ssgridReport.SetText(2, 7, "ENDINGDATE")
        '    FrReport.ssgridReport.SetText(3, 7, 15)
        '    FrReport.ssgridReport.SetText(2, 8, "FREEZE")
        '    FrReport.ssgridReport.SetText(3, 8, 5)
        '    FrReport.Show()
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM ITEMTYPEMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM ITEMTYPEMASTER", "SERIALNO", 0)
    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMTYPEMASTER set  ", "ITEMTYPECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMTYPEMASTER set  ", "ITEMTYPECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM ITEMTYPEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMTYPEMASTER set  ", "ITEMTYPECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    'End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click, Button2.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Taxtypemaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from ITEMTYPEMASTER "

        Call Viewer.GetDetails(sqlstring, "ITEMTYPEMASTER", r)
        Viewer.TableName = "ITEMTYPEMASTER"

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text13")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub
End Class