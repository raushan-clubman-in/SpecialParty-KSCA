Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Receiptentry_HSR
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim gconn As New GlobalClass
    Dim i, j, k As Integer
    Dim ssql As String
    Dim DT As New DataTable
    Dim dgv As New DataTable
    Dim AMOUNT As Integer
    Public cardcode As String
    Public Cardidcheck As Boolean
    Public vCardcode, vTmp As String
    Dim BALANCE_HDR As Double


    'Public greadertype, lastpaymode, ordertype As String
    'Public connActive, validATS As Boolean
    'Public retcode As Integer
    'Public hContext, hcard As Long
    Public MNAME_GBL, PAYMENTMODE_GBL, MCODE_GBL As String
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents CMD_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents BK_HELP As System.Windows.Forms.Button
    Friend WithEvents cmd_mcodehelp As System.Windows.Forms.Button
    Friend WithEvents CMD_VOUCHERNOHELP As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_holder_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Holder_Code As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_cname As System.Windows.Forms.Label
    Friend WithEvents Lbl_ccode As System.Windows.Forms.Label
    Friend WithEvents txt_card_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SwipeCard As System.Windows.Forms.Button
    Friend WithEvents Txt_Remarks As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbl_bal As System.Windows.Forms.Label
    Dim receiptamount
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBRECEIPTTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit1 As System.Windows.Forms.Button
    Friend WithEvents cmd_mcodehelp1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DTPVOUCHERDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTVOUCHERNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTMENUAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTARRAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents LABLASTVOUCHERNO As System.Windows.Forms.Label
    Friend WithEvents CMD_VOUCHERNOHELP1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Dtppartydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GRPRECEIPT As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ssgrid_Receipt As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents INS_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXT_DRAWEEBANK As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXT_INSNO As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents INS_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents bankdet As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXT_AMT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_CARDNO As System.Windows.Forms.TextBox
    Friend WithEvents LBL_CARD As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXT_VOTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Txt_city As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TXTGUESTNAME As System.Windows.Forms.TextBox
    Friend WithEvents DTGRD As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Receiptentry_HSR))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_card_id = New System.Windows.Forms.TextBox()
        Me.lbl_SwipeCard = New System.Windows.Forms.Button()
        Me.Txt_holder_name = New System.Windows.Forms.TextBox()
        Me.txt_Holder_Code = New System.Windows.Forms.TextBox()
        Me.Lbl_cname = New System.Windows.Forms.Label()
        Me.Lbl_ccode = New System.Windows.Forms.Label()
        Me.BK_HELP = New System.Windows.Forms.Button()
        Me.cmd_mcodehelp = New System.Windows.Forms.Button()
        Me.CMD_VOUCHERNOHELP = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXTGUESTNAME = New System.Windows.Forms.TextBox()
        Me.TXT_VOTYPE = New System.Windows.Forms.ComboBox()
        Me.cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Dtppartydate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CMD_VOUCHERNOHELP1 = New System.Windows.Forms.Button()
        Me.cmd_mcodehelp1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTPVOUCHERDATE = New System.Windows.Forms.DateTimePicker()
        Me.txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTVOUCHERNO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_MemberName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.LABLASTVOUCHERNO = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBRECEIPTTYPE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTHALLAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTMENUAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTARRAMOUNT = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear1 = New System.Windows.Forms.Button()
        Me.Cmd_View1 = New System.Windows.Forms.Button()
        Me.Cmd_Freeze1 = New System.Windows.Forms.Button()
        Me.Cmd_Add1 = New System.Windows.Forms.Button()
        Me.Cmd_Exit1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GRPRECEIPT = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ssgrid_Receipt = New AxFPSpreadADO.AxfpSpread()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.bankdet = New System.Windows.Forms.Panel()
        Me.Txt_Remarks = New System.Windows.Forms.Label()
        Me.Txt_city = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXT_CARDNO = New System.Windows.Forms.TextBox()
        Me.INS_DATE = New System.Windows.Forms.DateTimePicker()
        Me.TXT_DRAWEEBANK = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXT_INSNO = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.INS_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LBL_CARD = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_AMT = New System.Windows.Forms.TextBox()
        Me.DTGRD = New System.Windows.Forms.DataGrid()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.CMD_FREEZE = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_bal = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GRPRECEIPT.SuspendLayout()
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bankdet.SuspendLayout()
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_card_id)
        Me.GroupBox1.Controls.Add(Me.lbl_SwipeCard)
        Me.GroupBox1.Controls.Add(Me.Txt_holder_name)
        Me.GroupBox1.Controls.Add(Me.txt_Holder_Code)
        Me.GroupBox1.Controls.Add(Me.Lbl_cname)
        Me.GroupBox1.Controls.Add(Me.Lbl_ccode)
        Me.GroupBox1.Controls.Add(Me.BK_HELP)
        Me.GroupBox1.Controls.Add(Me.cmd_mcodehelp)
        Me.GroupBox1.Controls.Add(Me.CMD_VOUCHERNOHELP)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TXTGUESTNAME)
        Me.GroupBox1.Controls.Add(Me.TXT_VOTYPE)
        Me.GroupBox1.Controls.Add(Me.cbo_PaymentMode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Dtppartydate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TXTBOOKINGNO)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.CMD_VOUCHERNOHELP1)
        Me.GroupBox1.Controls.Add(Me.cmd_mcodehelp1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.DTPVOUCHERDATE)
        Me.GroupBox1.Controls.Add(Me.txt_MemberCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXTVOUCHERNO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_MemberName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(200, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(647, 223)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txt_card_id
        '
        Me.txt_card_id.Location = New System.Drawing.Point(372, 199)
        Me.txt_card_id.Name = "txt_card_id"
        Me.txt_card_id.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txt_card_id.Size = New System.Drawing.Size(125, 20)
        Me.txt_card_id.TabIndex = 865
        '
        'lbl_SwipeCard
        '
        Me.lbl_SwipeCard.Location = New System.Drawing.Point(286, 197)
        Me.lbl_SwipeCard.Name = "lbl_SwipeCard"
        Me.lbl_SwipeCard.Size = New System.Drawing.Size(75, 23)
        Me.lbl_SwipeCard.TabIndex = 864
        Me.lbl_SwipeCard.Text = "Swipe Card"
        Me.lbl_SwipeCard.UseVisualStyleBackColor = True
        '
        'Txt_holder_name
        '
        Me.Txt_holder_name.BackColor = System.Drawing.Color.Wheat
        Me.Txt_holder_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_holder_name.Location = New System.Drawing.Point(110, 196)
        Me.Txt_holder_name.MaxLength = 15
        Me.Txt_holder_name.Name = "Txt_holder_name"
        Me.Txt_holder_name.ReadOnly = True
        Me.Txt_holder_name.Size = New System.Drawing.Size(169, 26)
        Me.Txt_holder_name.TabIndex = 863
        '
        'txt_Holder_Code
        '
        Me.txt_Holder_Code.BackColor = System.Drawing.Color.Wheat
        Me.txt_Holder_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Holder_Code.Location = New System.Drawing.Point(111, 159)
        Me.txt_Holder_Code.MaxLength = 15
        Me.txt_Holder_Code.Name = "txt_Holder_Code"
        Me.txt_Holder_Code.ReadOnly = True
        Me.txt_Holder_Code.Size = New System.Drawing.Size(114, 26)
        Me.txt_Holder_Code.TabIndex = 862
        '
        'Lbl_cname
        '
        Me.Lbl_cname.AutoSize = True
        Me.Lbl_cname.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_cname.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_cname.Location = New System.Drawing.Point(10, 200)
        Me.Lbl_cname.Name = "Lbl_cname"
        Me.Lbl_cname.Size = New System.Drawing.Size(40, 15)
        Me.Lbl_cname.TabIndex = 861
        Me.Lbl_cname.Text = "NAME"
        '
        'Lbl_ccode
        '
        Me.Lbl_ccode.AutoSize = True
        Me.Lbl_ccode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_ccode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ccode.Location = New System.Drawing.Point(9, 166)
        Me.Lbl_ccode.Name = "Lbl_ccode"
        Me.Lbl_ccode.Size = New System.Drawing.Size(79, 15)
        Me.Lbl_ccode.TabIndex = 860
        Me.Lbl_ccode.Text = "CARD CODE"
        '
        'BK_HELP
        '
        Me.BK_HELP.Location = New System.Drawing.Point(224, 16)
        Me.BK_HELP.Name = "BK_HELP"
        Me.BK_HELP.Size = New System.Drawing.Size(40, 27)
        Me.BK_HELP.TabIndex = 859
        Me.BK_HELP.Text = "?"
        Me.BK_HELP.UseVisualStyleBackColor = True
        '
        'cmd_mcodehelp
        '
        Me.cmd_mcodehelp.Location = New System.Drawing.Point(224, 120)
        Me.cmd_mcodehelp.Name = "cmd_mcodehelp"
        Me.cmd_mcodehelp.Size = New System.Drawing.Size(40, 26)
        Me.cmd_mcodehelp.TabIndex = 858
        Me.cmd_mcodehelp.Text = "?"
        Me.cmd_mcodehelp.UseVisualStyleBackColor = True
        '
        'CMD_VOUCHERNOHELP
        '
        Me.CMD_VOUCHERNOHELP.Location = New System.Drawing.Point(224, 56)
        Me.CMD_VOUCHERNOHELP.Name = "CMD_VOUCHERNOHELP"
        Me.CMD_VOUCHERNOHELP.Size = New System.Drawing.Size(40, 27)
        Me.CMD_VOUCHERNOHELP.TabIndex = 857
        Me.CMD_VOUCHERNOHELP.Text = "F4"
        Me.CMD_VOUCHERNOHELP.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(267, 156)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 15)
        Me.Label25.TabIndex = 382
        Me.Label25.Text = "GUEST NAME"
        '
        'TXTGUESTNAME
        '
        Me.TXTGUESTNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTGUESTNAME.Enabled = False
        Me.TXTGUESTNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUESTNAME.Location = New System.Drawing.Point(371, 152)
        Me.TXTGUESTNAME.MaxLength = 50
        Me.TXTGUESTNAME.Name = "TXTGUESTNAME"
        Me.TXTGUESTNAME.ReadOnly = True
        Me.TXTGUESTNAME.Size = New System.Drawing.Size(262, 26)
        Me.TXTGUESTNAME.TabIndex = 381
        '
        'TXT_VOTYPE
        '
        Me.TXT_VOTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TXT_VOTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_VOTYPE.Items.AddRange(New Object() {"ADVANCE", "REFUND"})
        Me.TXT_VOTYPE.Location = New System.Drawing.Point(371, 84)
        Me.TXT_VOTYPE.Name = "TXT_VOTYPE"
        Me.TXT_VOTYPE.Size = New System.Drawing.Size(187, 28)
        Me.TXT_VOTYPE.TabIndex = 6
        '
        'cbo_PaymentMode
        '
        Me.cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_PaymentMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_PaymentMode.Items.AddRange(New Object() {"CARD", "CREDIT", "CHEQUE", "CASH", "SMART CARD"})
        Me.cbo_PaymentMode.Location = New System.Drawing.Point(371, 48)
        Me.cbo_PaymentMode.Name = "cbo_PaymentMode"
        Me.cbo_PaymentMode.Size = New System.Drawing.Size(187, 28)
        Me.cbo_PaymentMode.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(267, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 15)
        Me.Label16.TabIndex = 378
        Me.Label16.Text = "PAYMENT MODE"
        '
        'Dtppartydate
        '
        Me.Dtppartydate.CustomFormat = ""
        Me.Dtppartydate.Enabled = False
        Me.Dtppartydate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtppartydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtppartydate.Location = New System.Drawing.Point(371, 16)
        Me.Dtppartydate.Name = "Dtppartydate"
        Me.Dtppartydate.Size = New System.Drawing.Size(131, 26)
        Me.Dtppartydate.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(269, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 376
        Me.Label15.Text = "PARTY DATE"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(78, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 375
        Me.Button1.Visible = False
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(110, 16)
        Me.TXTBOOKINGNO.MaxLength = 10
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(114, 26)
        Me.TXTBOOKINGNO.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 373
        Me.Label14.Text = "BOOKING NO"
        '
        'CMD_VOUCHERNOHELP1
        '
        Me.CMD_VOUCHERNOHELP1.Image = CType(resources.GetObject("CMD_VOUCHERNOHELP1.Image"), System.Drawing.Image)
        Me.CMD_VOUCHERNOHELP1.Location = New System.Drawing.Point(78, 56)
        Me.CMD_VOUCHERNOHELP1.Name = "CMD_VOUCHERNOHELP1"
        Me.CMD_VOUCHERNOHELP1.Size = New System.Drawing.Size(35, 23)
        Me.CMD_VOUCHERNOHELP1.TabIndex = 372
        Me.CMD_VOUCHERNOHELP1.Visible = False
        '
        'cmd_mcodehelp1
        '
        Me.cmd_mcodehelp1.Image = CType(resources.GetObject("cmd_mcodehelp1.Image"), System.Drawing.Image)
        Me.cmd_mcodehelp1.Location = New System.Drawing.Point(78, 116)
        Me.cmd_mcodehelp1.Name = "cmd_mcodehelp1"
        Me.cmd_mcodehelp1.Size = New System.Drawing.Size(35, 23)
        Me.cmd_mcodehelp1.TabIndex = 5
        Me.cmd_mcodehelp1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(267, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 369
        Me.Label7.Text = "RECEIPT TYPE"
        '
        'DTPVOUCHERDATE
        '
        Me.DTPVOUCHERDATE.CustomFormat = "dd/MM/yyyy"
        Me.DTPVOUCHERDATE.Enabled = False
        Me.DTPVOUCHERDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPVOUCHERDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPVOUCHERDATE.Location = New System.Drawing.Point(110, 88)
        Me.DTPVOUCHERDATE.Name = "DTPVOUCHERDATE"
        Me.DTPVOUCHERDATE.Size = New System.Drawing.Size(114, 26)
        Me.DTPVOUCHERDATE.TabIndex = 5
        '
        'txt_MemberCode
        '
        Me.txt_MemberCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_MemberCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MemberCode.Location = New System.Drawing.Point(110, 120)
        Me.txt_MemberCode.MaxLength = 15
        Me.txt_MemberCode.Name = "txt_MemberCode"
        Me.txt_MemberCode.ReadOnly = True
        Me.txt_MemberCode.Size = New System.Drawing.Size(114, 26)
        Me.txt_MemberCode.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "MEMBER CODE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 362
        Me.Label1.Text = "RECEIPT DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "RECEIPT NO"
        '
        'TXTVOUCHERNO
        '
        Me.TXTVOUCHERNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTVOUCHERNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVOUCHERNO.Location = New System.Drawing.Point(110, 56)
        Me.TXTVOUCHERNO.MaxLength = 25
        Me.TXTVOUCHERNO.Name = "TXTVOUCHERNO"
        Me.TXTVOUCHERNO.Size = New System.Drawing.Size(114, 26)
        Me.TXTVOUCHERNO.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 22)
        Me.Label5.TabIndex = 362
        '
        'txt_MemberName
        '
        Me.txt_MemberName.BackColor = System.Drawing.Color.Wheat
        Me.txt_MemberName.Enabled = False
        Me.txt_MemberName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MemberName.Location = New System.Drawing.Point(371, 120)
        Me.txt_MemberName.MaxLength = 50
        Me.txt_MemberName.Name = "txt_MemberName"
        Me.txt_MemberName.ReadOnly = True
        Me.txt_MemberName.Size = New System.Drawing.Size(262, 26)
        Me.txt_MemberName.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(267, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 362
        Me.Label6.Text = "MEMBER NAME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(24, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 22)
        Me.Label3.TabIndex = 362
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(-6, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 22)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "HALL AMOUNT"
        Me.Label4.Visible = False
        '
        'TxtDescription
        '
        Me.TxtDescription.BackColor = System.Drawing.Color.Wheat
        Me.TxtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(889, 474)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(115, 26)
        Me.TxtDescription.TabIndex = 3
        Me.TxtDescription.Visible = False
        '
        'LABLASTVOUCHERNO
        '
        Me.LABLASTVOUCHERNO.AutoSize = True
        Me.LABLASTVOUCHERNO.BackColor = System.Drawing.Color.Transparent
        Me.LABLASTVOUCHERNO.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.LABLASTVOUCHERNO.ForeColor = System.Drawing.Color.Blue
        Me.LABLASTVOUCHERNO.Location = New System.Drawing.Point(544, 76)
        Me.LABLASTVOUCHERNO.Name = "LABLASTVOUCHERNO"
        Me.LABLASTVOUCHERNO.Size = New System.Drawing.Size(175, 22)
        Me.LABLASTVOUCHERNO.TabIndex = 371
        Me.LABLASTVOUCHERNO.Text = "LAST VOUCHERNO:"
        Me.LABLASTVOUCHERNO.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(-40, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 22)
        Me.Label10.TabIndex = 370
        Me.Label10.Text = "MENU AMOUNT"
        Me.Label10.Visible = False
        '
        'CMBRECEIPTTYPE
        '
        Me.CMBRECEIPTTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRECEIPTTYPE.Items.AddRange(New Object() {"CATERING ADVANCE", "BAR ADVANCE", "HALL ADVANCE", "ARRANGEMENT ADVANCE", "OTHER ADVANCE", "BILL"})
        Me.CMBRECEIPTTYPE.Location = New System.Drawing.Point(32, 128)
        Me.CMBRECEIPTTYPE.Name = "CMBRECEIPTTYPE"
        Me.CMBRECEIPTTYPE.Size = New System.Drawing.Size(35, 28)
        Me.CMBRECEIPTTYPE.TabIndex = 0
        Me.CMBRECEIPTTYPE.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(-40, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 22)
        Me.Label8.TabIndex = 362
        Me.Label8.Text = "RECEIPT TYPE"
        Me.Label8.Visible = False
        '
        'TXTHALLAMOUNT
        '
        Me.TXTHALLAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHALLAMOUNT.Location = New System.Drawing.Point(40, 200)
        Me.TXTHALLAMOUNT.MaxLength = 12
        Me.TXTHALLAMOUNT.Name = "TXTHALLAMOUNT"
        Me.TXTHALLAMOUNT.Size = New System.Drawing.Size(27, 26)
        Me.TXTHALLAMOUNT.TabIndex = 7
        Me.TXTHALLAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTHALLAMOUNT.Visible = False
        '
        'TXTMENUAMOUNT
        '
        Me.TXTMENUAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTMENUAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMENUAMOUNT.Location = New System.Drawing.Point(48, 280)
        Me.TXTMENUAMOUNT.MaxLength = 12
        Me.TXTMENUAMOUNT.Name = "TXTMENUAMOUNT"
        Me.TXTMENUAMOUNT.Size = New System.Drawing.Size(22, 26)
        Me.TXTMENUAMOUNT.TabIndex = 8
        Me.TXTMENUAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTMENUAMOUNT.Visible = False
        '
        'TXTARRAMOUNT
        '
        Me.TXTARRAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRAMOUNT.Location = New System.Drawing.Point(72, 336)
        Me.TXTARRAMOUNT.MaxLength = 12
        Me.TXTARRAMOUNT.Name = "TXTARRAMOUNT"
        Me.TXTARRAMOUNT.Size = New System.Drawing.Size(27, 26)
        Me.TXTARRAMOUNT.TabIndex = 9
        Me.TXTARRAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTARRAMOUNT.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(-16, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 22)
        Me.Label11.TabIndex = 370
        Me.Label11.Text = "ARR.AMOUNT"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(312, 653)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(384, 16)
        Me.Label12.TabIndex = 421
        Me.Label12.Text = "Press F4 for HELP / Press ENTER key to navigate"
        Me.Label12.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(266, 4)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(187, 18)
        Me.lbl_Freeze.TabIndex = 420
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear1)
        Me.GroupBox2.Controls.Add(Me.Cmd_View1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit1)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 665)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(603, 53)
        Me.GroupBox2.TabIndex = 419
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'Cmd_Clear1
        '
        Me.Cmd_Clear1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear1.Image = CType(resources.GetObject("Cmd_Clear1.Image"), System.Drawing.Image)
        Me.Cmd_Clear1.Location = New System.Drawing.Point(16, 16)
        Me.Cmd_Clear1.Name = "Cmd_Clear1"
        Me.Cmd_Clear1.Size = New System.Drawing.Size(115, 29)
        Me.Cmd_Clear1.TabIndex = 11
        Me.Cmd_Clear1.Text = "Clear[F6]"
        Me.Cmd_Clear1.UseVisualStyleBackColor = False
        '
        'Cmd_View1
        '
        Me.Cmd_View1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View1.ForeColor = System.Drawing.Color.White
        Me.Cmd_View1.Image = CType(resources.GetObject("Cmd_View1.Image"), System.Drawing.Image)
        Me.Cmd_View1.Location = New System.Drawing.Point(355, 16)
        Me.Cmd_View1.Name = "Cmd_View1"
        Me.Cmd_View1.Size = New System.Drawing.Size(115, 29)
        Me.Cmd_View1.TabIndex = 13
        Me.Cmd_View1.Text = " View[F9]"
        Me.Cmd_View1.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze1
        '
        Me.Cmd_Freeze1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze1.Image = CType(resources.GetObject("Cmd_Freeze1.Image"), System.Drawing.Image)
        Me.Cmd_Freeze1.Location = New System.Drawing.Point(240, 16)
        Me.Cmd_Freeze1.Name = "Cmd_Freeze1"
        Me.Cmd_Freeze1.Size = New System.Drawing.Size(115, 29)
        Me.Cmd_Freeze1.TabIndex = 12
        Me.Cmd_Freeze1.Text = "Freeze[F8]"
        Me.Cmd_Freeze1.UseVisualStyleBackColor = False
        '
        'Cmd_Add1
        '
        Me.Cmd_Add1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add1.Image = CType(resources.GetObject("Cmd_Add1.Image"), System.Drawing.Image)
        Me.Cmd_Add1.Location = New System.Drawing.Point(128, 16)
        Me.Cmd_Add1.Name = "Cmd_Add1"
        Me.Cmd_Add1.Size = New System.Drawing.Size(115, 29)
        Me.Cmd_Add1.TabIndex = 10
        Me.Cmd_Add1.Text = "Add [F7]"
        Me.Cmd_Add1.UseVisualStyleBackColor = False
        '
        'Cmd_Exit1
        '
        Me.Cmd_Exit1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit1.Image = CType(resources.GetObject("Cmd_Exit1.Image"), System.Drawing.Image)
        Me.Cmd_Exit1.Location = New System.Drawing.Point(469, 16)
        Me.Cmd_Exit1.Name = "Cmd_Exit1"
        Me.Cmd_Exit1.Size = New System.Drawing.Size(115, 29)
        Me.Cmd_Exit1.TabIndex = 14
        Me.Cmd_Exit1.Text = "Exit[F11]"
        Me.Cmd_Exit1.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(190, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(327, 29)
        Me.Label13.TabIndex = 422
        Me.Label13.Text = "BANQUET RECEIPT ENTRY"
        '
        'GRPRECEIPT
        '
        Me.GRPRECEIPT.BackColor = System.Drawing.Color.Transparent
        Me.GRPRECEIPT.Controls.Add(Me.Label28)
        Me.GRPRECEIPT.Controls.Add(Me.ssgrid_Receipt)
        Me.GRPRECEIPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPRECEIPT.ForeColor = System.Drawing.Color.Blue
        Me.GRPRECEIPT.Location = New System.Drawing.Point(200, 340)
        Me.GRPRECEIPT.Name = "GRPRECEIPT"
        Me.GRPRECEIPT.Size = New System.Drawing.Size(647, 208)
        Me.GRPRECEIPT.TabIndex = 844
        Me.GRPRECEIPT.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label28.Location = New System.Drawing.Point(0, -24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(109, 18)
        Me.Label28.TabIndex = 392
        Me.Label28.Text = "HALL FACILITY"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ssgrid_Receipt
        '
        Me.ssgrid_Receipt.DataSource = Nothing
        Me.ssgrid_Receipt.Location = New System.Drawing.Point(6, 17)
        Me.ssgrid_Receipt.Name = "ssgrid_Receipt"
        Me.ssgrid_Receipt.OcxState = CType(resources.GetObject("ssgrid_Receipt.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_Receipt.Size = New System.Drawing.Size(627, 181)
        Me.ssgrid_Receipt.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(481, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(289, 25)
        Me.Label22.TabIndex = 850
        Me.Label22.Text = "RECEIPT  IS CANCELLED"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label22.Visible = False
        '
        'bankdet
        '
        Me.bankdet.BackColor = System.Drawing.Color.Transparent
        Me.bankdet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bankdet.Controls.Add(Me.Txt_Remarks)
        Me.bankdet.Controls.Add(Me.Txt_city)
        Me.bankdet.Controls.Add(Me.Label24)
        Me.bankdet.Controls.Add(Me.TXT_CARDNO)
        Me.bankdet.Controls.Add(Me.INS_DATE)
        Me.bankdet.Controls.Add(Me.lbl_Freeze)
        Me.bankdet.Controls.Add(Me.TXT_DRAWEEBANK)
        Me.bankdet.Controls.Add(Me.Label17)
        Me.bankdet.Controls.Add(Me.Label18)
        Me.bankdet.Controls.Add(Me.TXT_INSNO)
        Me.bankdet.Controls.Add(Me.Label19)
        Me.bankdet.Controls.Add(Me.INS_TYPE)
        Me.bankdet.Controls.Add(Me.Label21)
        Me.bankdet.Controls.Add(Me.LBL_CARD)
        Me.bankdet.Location = New System.Drawing.Point(200, 549)
        Me.bankdet.Name = "bankdet"
        Me.bankdet.Size = New System.Drawing.Size(654, 101)
        Me.bankdet.TabIndex = 845
        '
        'Txt_Remarks
        '
        Me.Txt_Remarks.AutoSize = True
        Me.Txt_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.Txt_Remarks.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Remarks.Location = New System.Drawing.Point(-5, 11)
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(131, 22)
        Me.Txt_Remarks.TabIndex = 859
        Me.Txt_Remarks.Text = "HALL AMOUNT"
        Me.Txt_Remarks.Visible = False
        '
        'Txt_city
        '
        Me.Txt_city.BackColor = System.Drawing.Color.Wheat
        Me.Txt_city.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_city.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_city.Location = New System.Drawing.Point(65, 66)
        Me.Txt_city.MaxLength = 50
        Me.Txt_city.Name = "Txt_city"
        Me.Txt_city.Size = New System.Drawing.Size(148, 29)
        Me.Txt_city.TabIndex = 617
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 69)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 20)
        Me.Label24.TabIndex = 616
        Me.Label24.Text = "PLACE"
        '
        'TXT_CARDNO
        '
        Me.TXT_CARDNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_CARDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CARDNO.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CARDNO.Location = New System.Drawing.Point(67, 4)
        Me.TXT_CARDNO.MaxLength = 25
        Me.TXT_CARDNO.Name = "TXT_CARDNO"
        Me.TXT_CARDNO.Size = New System.Drawing.Size(146, 29)
        Me.TXT_CARDNO.TabIndex = 849
        Me.TXT_CARDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_CARDNO.Visible = False
        '
        'INS_DATE
        '
        Me.INS_DATE.CalendarFont = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.INS_DATE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.INS_DATE.Location = New System.Drawing.Point(540, 25)
        Me.INS_DATE.Name = "INS_DATE"
        Me.INS_DATE.Size = New System.Drawing.Size(110, 22)
        Me.INS_DATE.TabIndex = 615
        '
        'TXT_DRAWEEBANK
        '
        Me.TXT_DRAWEEBANK.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DRAWEEBANK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DRAWEEBANK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DRAWEEBANK.Location = New System.Drawing.Point(310, 60)
        Me.TXT_DRAWEEBANK.MaxLength = 50
        Me.TXT_DRAWEEBANK.Name = "TXT_DRAWEEBANK"
        Me.TXT_DRAWEEBANK.Size = New System.Drawing.Size(143, 29)
        Me.TXT_DRAWEEBANK.TabIndex = 614
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(216, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 20)
        Me.Label17.TabIndex = 613
        Me.Label17.Text = "DRAWEE BANK"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(459, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 20)
        Me.Label18.TabIndex = 612
        Me.Label18.Text = "INSTR. DATE"
        '
        'TXT_INSNO
        '
        Me.TXT_INSNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_INSNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_INSNO.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_INSNO.Location = New System.Drawing.Point(66, 34)
        Me.TXT_INSNO.MaxLength = 10
        Me.TXT_INSNO.Name = "TXT_INSNO"
        Me.TXT_INSNO.Size = New System.Drawing.Size(147, 29)
        Me.TXT_INSNO.TabIndex = 610
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(0, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 20)
        Me.Label19.TabIndex = 609
        Me.Label19.Text = "INST. NO"
        '
        'INS_TYPE
        '
        Me.INS_TYPE.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_TYPE.Items.AddRange(New Object() {"CARD", "CHEQUE", "DD", "PO"})
        Me.INS_TYPE.Location = New System.Drawing.Point(310, 27)
        Me.INS_TYPE.Name = "INS_TYPE"
        Me.INS_TYPE.Size = New System.Drawing.Size(143, 30)
        Me.INS_TYPE.TabIndex = 607
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(219, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(147, 20)
        Me.Label21.TabIndex = 608
        Me.Label21.Text = "INSTR. TYPE"
        '
        'LBL_CARD
        '
        Me.LBL_CARD.BackColor = System.Drawing.Color.Transparent
        Me.LBL_CARD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CARD.Location = New System.Drawing.Point(0, 9)
        Me.LBL_CARD.Name = "LBL_CARD"
        Me.LBL_CARD.Size = New System.Drawing.Size(80, 20)
        Me.LBL_CARD.TabIndex = 848
        Me.LBL_CARD.Text = "CARD. NO "
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(40, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(355, 20)
        Me.Label20.TabIndex = 595
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(550, 522)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 20)
        Me.Label23.TabIndex = 846
        Me.Label23.Text = "TOTAL AMOUNT "
        Me.Label23.Visible = False
        '
        'TXT_AMT
        '
        Me.TXT_AMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_AMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_AMT.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_AMT.Location = New System.Drawing.Point(663, 514)
        Me.TXT_AMT.MaxLength = 10
        Me.TXT_AMT.Name = "TXT_AMT"
        Me.TXT_AMT.Size = New System.Drawing.Size(128, 29)
        Me.TXT_AMT.TabIndex = 847
        Me.TXT_AMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_AMT.Visible = False
        '
        'DTGRD
        '
        Me.DTGRD.DataMember = ""
        Me.DTGRD.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DTGRD.Location = New System.Drawing.Point(62, 368)
        Me.DTGRD.Name = "DTGRD"
        Me.DTGRD.Size = New System.Drawing.Size(10, 189)
        Me.DTGRD.TabIndex = 851
        Me.DTGRD.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(6, 180)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(135, 55)
        Me.cmdreport.TabIndex = 8
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_exit.Image = CType(resources.GetObject("cmd_exit.Image"), System.Drawing.Image)
        Me.cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_exit.Location = New System.Drawing.Point(6, 235)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(135, 55)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "Exit [F11]"
        Me.cmd_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(-2, 653)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 857
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        Me.Cmdauth.Visible = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(-2, 587)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 856
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        Me.Cmdbwse.Visible = False
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(865, 681)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 855
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        Me.Cmd_view.Visible = False
        '
        'CMD_FREEZE
        '
        Me.CMD_FREEZE.BackColor = System.Drawing.Color.Gainsboro
        Me.CMD_FREEZE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_FREEZE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_FREEZE.Image = CType(resources.GetObject("CMD_FREEZE.Image"), System.Drawing.Image)
        Me.CMD_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_FREEZE.Location = New System.Drawing.Point(6, 125)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(135, 55)
        Me.CMD_FREEZE.TabIndex = 7
        Me.CMD_FREEZE.Text = "Freeze [F8]"
        Me.CMD_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_FREEZE.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 15)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(135, 55)
        Me.Cmd_Clear.TabIndex = 6
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 70)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(135, 55)
        Me.Cmd_Add.TabIndex = 5
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdreport)
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.cmd_exit)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.CMD_FREEZE)
        Me.GroupBox3.Location = New System.Drawing.Point(853, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(147, 299)
        Me.GroupBox3.TabIndex = 858
        Me.GroupBox3.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'lbl_bal
        '
        Me.lbl_bal.AutoSize = True
        Me.lbl_bal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_bal.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_bal.ForeColor = System.Drawing.Color.Red
        Me.lbl_bal.Location = New System.Drawing.Point(849, 561)
        Me.lbl_bal.Name = "lbl_bal"
        Me.lbl_bal.Size = New System.Drawing.Size(131, 22)
        Me.lbl_bal.TabIndex = 860
        Me.lbl_bal.Text = "HALL AMOUNT"
        '
        'Receiptentry_HSR
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.lbl_bal)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.DTGRD)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTHALLAMOUNT)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTMENUAMOUNT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTARRAMOUNT)
        Me.Controls.Add(Me.LABLASTVOUCHERNO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXT_AMT)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.bankdet)
        Me.Controls.Add(Me.GRPRECEIPT)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CMBRECEIPTTYPE)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label4)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.KeyPreview = True
        Me.Name = "Receiptentry_HSR"
        Me.Text = "Banquet Receipt Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GRPRECEIPT.ResumeLayout(False)
        Me.GRPRECEIPT.PerformLayout()
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bankdet.ResumeLayout(False)
        Me.bankdet.PerformLayout()
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub autogeneratePARTY()
        Dim DOCTYPE As String
        DOCTYPE = "PAR"
        Dim sqlstring, financalyear As String
        sqlstring = "SELECT ISNULL(COMPNAME,'')AS COMPNAME FROM POSSETUP "
        gconnection.getDataSet(sqlstring, "POSSETUP")
        If gdataset.Tables("POSSETUP").Rows.Count - 1 >= 0 Then
            gCompName = gdataset.Tables("POSSETUP").Rows(0).Item("COMPNAME")
        End If


        If gCompName <> "KGA" Then
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
            Try
                sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
                gconnection.openConnection()
                gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then

                    If gdreader(0) Is System.DBNull.Value Then
                        TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        TXTVOUCHERNO.Text = DOCTYPE & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Catch ex As Exception
                Exit Sub
            Finally
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End Try
        Else ''''FOR KGA
            Try
                sqlstring = "SELECT MAX(CAST(VOUCHERNO AS INT))AS VOUCHERNO  FROM JOURNAL_REC"
                gconnection.openConnection()
                gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        TXTVOUCHERNO.Text = "000001"
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        TXTVOUCHERNO.Text = Format(gdreader(0) + 1, "000000")
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    TXTVOUCHERNO.Text = "000001"
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Catch ex As Exception
                Exit Sub
            Finally
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End Try
        End If

    End Sub

    Private Sub autogeneratePARTY1()
        Dim DOCTYPE As String
        DOCTYPE = "PAR"
        Dim sqlstring, financalyear As String

        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then

                If gdreader(0) Is System.DBNull.Value Then
                    TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    TXTVOUCHERNO.Text = DOCTYPE & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub

    Public Sub checkValidation()
        boolchk = False
        If Trim(TXTBOOKINGNO.Text) = "" Then '
            MessageBox.Show("Booing No  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTBOOKINGNO.Focus()
            Exit Sub
        End If
        ssql = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " AND  Isnull(cancelflag,'')='Y'"
        DT = gconnection.GetValues(ssql)
        If DT.Rows.Count > 0 Then
            MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If Trim(TxtDescription.Text) = "" Then
        '    MessageBox.Show("Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TxtDescription.Focus()
        '    Exit Sub
        'End If
        If Trim(TXT_VOTYPE.Text) = "" Then
            MessageBox.Show("VOUCHER can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtDescription.Focus()
            Exit Sub
        End If
        If Trim(DTPVOUCHERDATE.Text) = "" Then
            MessageBox.Show("VoucherDate Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DTPVOUCHERDATE.Focus()
            Exit Sub
        End If
        If Trim(txt_MemberCode.Text) = "" Then
            MessageBox.Show("Mcode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_MemberCode.Focus()
            Exit Sub
        End If
        If Trim(txt_MemberName.Text) = "" Then
            MessageBox.Show("Member Name Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_MemberCode.Focus()
            Exit Sub
        End If

        If Trim(cbo_PaymentMode.Text) = "" Then
            MessageBox.Show("Payment Mode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_PaymentMode.Focus()
            Exit Sub
        End If
        With ssgrid_Receipt
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 3
                receiptamount = Val(.Text)
            Next
        End With
        If Val(receiptamount) <= "0" Or Val(receiptamount) < "0.00" Then
            MessageBox.Show("PLEASE ENTER THE VALID RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'If Val(TXT_AMT.Text) <= "0" Or Val(TXT_AMT.Text) < "0.00" Then
        '    MessageBox.Show("PLEASE ENTER THE VALID RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'If Val(AMOUNT) <= "0" Or Val(AMOUNT) < "0.00" Then
        '    MessageBox.Show("PLEASE ENTER THE RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If Trim(cbo_PaymentMode.Text) = "CHEQUE" Then
            If Trim(cbo_PaymentMode.Text) = "" Then
                MessageBox.Show("Payment Mode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_PaymentMode.Focus()
                Exit Sub
            End If
            If Trim(TXT_INSNO.Text) = "" Then
                MessageBox.Show("insrtument no can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_INSNO.Focus()
                Exit Sub
            End If
            If Trim(Txt_city.Text) = "" Then
                MessageBox.Show("PLACE  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_city.Focus()
                Exit Sub
            End If
            If Trim(TXT_DRAWEEBANK.Text) = "" Then '
                MessageBox.Show("Drawee Bank  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DRAWEEBANK.Focus()
                Exit Sub
            End If

        
            'If Val(TXT_AMT.Text) <= "0" Or Val(TXT_AMT.Text) < "0.00" Then
            '    MessageBox.Show("PLEASE ENTER THE VALID  RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            'If Val(AMOUNT) <= "0" Or Val(AMOUNT) < "0.00" Then
            '    MessageBox.Show("PLEASE ENTER THE RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
        End If
        If cbo_PaymentMode.Text = "SMART CARD" Then
            Dim CARDBAL As Double
            Call DISPLAYINF()

            sqlstring = "select balance,muc_amt from sm_vw_balance  where  CARDCODE='" & Trim(Me.txt_Holder_Code.Text) & "'"
            gconnection.getDataSet(sqlstring, "sm_bal")
            If gdataset.Tables("sm_bal").Rows.Count > 0 Then
                CARDBAL = gdataset.Tables("sm_bal").Rows(0).Item("balance")
                '& "  MUC :" & gdataset.Tables("sm_bal").Rows(0).Item("muc_amt")
            End If

            '' CARDBAL = lbl_bal.Text
            If Val(receiptamount) > CARDBAL Then
                MessageBox.Show("Insufficient Card Balance ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If




            If Me.cbo_PaymentMode.Text = "SMART CARD" Then
                ''  sqlstring = "SELECT [16_DIGIT_CODE]AS CODE FROM  SM_POSTRANSACTION WHERE BILL_NO='" & Trim(TXTVOUCHERNO.Text) & "' "
                sqlstring = "select [16_DIGIT_CODE] AS CODE from SM_CARDFILE_HDR   where MEMBERCODE ='" & Trim(txt_MemberCode.Text) & "' "
                DT = gconnection.GetValues(sqlstring)
                If DT.Rows.Count > 0 Then
                    If Trim(DT.Rows(0).Item("CODE")) <> Trim(Me.txt_card_id.Text) Then
                        MsgBox("SORRY PUT THE CORRECT CARD WITH WHICH BILLING DONE")
                        '' Call Cmd_Clear_Click(Cmd_Clear, e)
                        Exit Sub
                    End If
                End If
            End If



        End If
        If Trim(TXTBOOKINGNO.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & TXTBOOKINGNO.Text & " AND ISNULL(POSTFLAG,'')='Y' "
            gconnection.getDataSet(sqlstring, "accpost")
            If gdataset.Tables("accpost").Rows.Count > 0 Then
                MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT ADD/UPDATE THE RECEIPTS .. ", MyCompanyName, MessageBoxButtons.OK)
                Exit Sub
            End If
        End If
        boolchk = True
    End Sub
    Private Sub RECEIT()
        Dim Viewer As New ReportViwer
        Dim r1 As New partreceiptVoucher
        Dim i As Integer
        Dim sqlstring, sqlstring1 As String
        sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        If (gdataset.Tables("PARTYRECEIPTNO").Rows.Count > 0) Then

            Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text11")
            TXTOBJ5.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & "," & vbNewLine & " " & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            ''Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text14")
            ''TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = "UserName : " & gUsername
            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If

    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
        Me.ResizeRedraw = True
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
        If U = 1366 Then
            T = T - 55
        End If

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T
        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Panel" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox3" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub Receiptentry_HSR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Resize_Form()

        TXTBOOKINGNO.Focus()
        Call Cmd_Clear_Click(sender, e)
        TXTVOUCHERNO.ReadOnly = False
        TXTBOOKINGNO.Focus()
        Label22.Visible = False
        bankdet.Visible = False
        LBL_CARD.Visible = False
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        TXT_VOTYPE.DropDownStyle = ComboBoxStyle.DropDownList
        Call BILLGENERATE()
        Call autogeneratePARTY()
        TXTBOOKINGNO.Focus()
        TXTBOOKINGNO.Select()

        lbl_bal.Text = ""
        lbl_SwipeCard.Visible = False
        txt_card_id.Visible = False
        Lbl_ccode.Visible = False
        Lbl_cname.Visible = False
        txt_Holder_Code.Visible = False
        Txt_holder_name.Visible = False
    End Sub
    Private Sub Calculate()

        Dim dblTotalamount, amount, sum As Double
        Me.TXT_AMT.Text = "0.00"
        'Me.txt_total.Text = "0.00"
        With ssgrid_Receipt
            TXT_AMT.Text = ""
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                amount = .Text
                Me.TXT_AMT.Text = Format(Val(Me.TXT_AMT.Text) + Val(amount), "0.00")
                'txt_total.Text = Val(txt_total.Text) + TOTAL
            Next
        End With
    End Sub
    Private Function TOT_AMT1(ByVal ssgrid_Receipt As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Totamount, _taxamount As Double
        _Totamount = 0
        With ssgrid_Receipt
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                _Totamount = _Totamount + Math.Round(Val(.Text), 2)
            Next i
            Return Math.Round((_Totamount + _taxamount), 2)
        End With
    End Function

    Private Function Itemamt(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _amount As Double
        _amount = 0
        With _ssgrid
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                _amount = _amount + Val(.Text)
            Next i
            Return Math.Round(_amount, 2)
        End With
    End Function
    Private Sub BILLGENERATE()
        Dim sqlstring, financalyear As String
        Dim billint As Integer
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
            sqlstring = "SELECT Isnull(DocNo,0) FROM PoSKotDoc Where DocType = 'PAR'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    TXTVOUCHERNO.Text = "000001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    TXTVOUCHERNO.Text = "PAR" & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    billint = gdreader(0)
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()

                End If
            Else
                TXTVOUCHERNO.Text = "000001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.CMD_FREEZE.Enabled = False
        Me.Cmd_view.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.CMD_FREEZE.Enabled = True
                    Me.Cmd_view.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add1.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze1.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View1.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub txtmcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemberCode.Validated
        If txt_MemberCode.Text <> "" Then
            sqlstring = "Select mname From MemberMaster Where Mcode='" & Trim(txt_MemberCode.Text) & "' "
            gconnection.getDataSet(sqlstring, "MemberMaster")
            If gdataset.Tables("MemberMaster").Rows.Count > 0 Then
                txt_MemberName.Text = ""
                txt_MemberName.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                txt_MemberName.ReadOnly = True
                'TXTHALLAMOUNT.Focus()
            Else
                txt_MemberCode.Clear()
                txt_MemberName.Clear()
                'TXTHALLAMOUNT.Focus()
            End If
        Else
            txt_MemberName.Clear()
        End If
    End Sub
    Private Sub CMBRECEIPTTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBRECEIPTTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPVOUCHERDATE.Focus()
        End If
    End Sub
    Private Sub TXTVOUCHERNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTVOUCHERNO.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPVOUCHERDATE.Focus()
        End If
    End Sub
    Private Sub DTPVOUCHERDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPVOUCHERDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbo_PaymentMode.Focus()
        End If
    End Sub
    Private Sub TxtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_MemberCode.Focus()
        End If
    End Sub
    Private Sub txtmcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_MemberCode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Asc(e.KeyChar) = 13 Then
                    If Trim(txt_MemberCode.Text) <> "" Then
                        Call txtmcode_Validated(txt_MemberCode, e)
                    Else
                        Call cmd_mcodehelp_Click(sender, e)
                    End If
                End If
                ssgrid_Receipt.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txtmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MemberName.TextChanged
    End Sub
    Private Sub TXTHALLAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTMENUAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTMENUAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMENUAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTARRAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTARRAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTARRAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub TXTVOUCHERNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTVOUCHERNO.Validated
        sqlstring = "SELECT BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,ISNULL(GUESTNAME,'')AS GUESTNAME,RECEIPTTYPE FROM party_receipt_DET WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        gconnection.getDataSet(sqlstring, "party_receipt_DET")
        If gdataset.Tables("party_receipt_DET").Rows.Count > 0 Then
            TXTBOOKINGNO.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("bookingno")
            Dtppartydate.Value = Format(gdataset.Tables("party_receipt_DET").Rows(0).Item("partydate"), "dd/MM/yyyy")
            cbo_PaymentMode.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("PAYMENTMODE")
            DTPVOUCHERDATE.Value = Format(gdataset.Tables("party_receipt_DET").Rows(0).Item("PARTYRECEIPTDATE"), "dd/MM/yyyy")
            TxtDescription.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("DESCRIPTION")
            txt_MemberCode.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("mcode")
            txt_MemberName.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("mname")
            TXTGUESTNAME.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("GUESTNAME")
            TXT_VOTYPE.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("RECEIPTTYPE")
        Else

        End If
        sqlstring = "SELECT * FROM party_receipt_HDR where PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' AND FREEZE='Y'"
        gconnection.getDataSet(sqlstring, "party_receipt_HDR")
        If gdataset.Tables("party_receipt_hdr").Rows.Count > 0 Then
            Label22.Visible = True
        End If
        sqlstring = "SELECT ISNULL(INSTTYPE,'')AS INSTTYPE ,ISNULL(INSTNO,'')AS INSTNO,ISNULL(INSTDATE,'')AS INSTDATE ,ISNULL(DRAWBANK,'')AS DRAWBANK,ISNULL(CARDNUMBER,'')AS CARDNUMBER,ISNULL(PLACE,'')AS PLACE  from party_receipt_hdr where PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        gconnection.getDataSet(sqlstring, "party_receipt_hdr")
        If gdataset.Tables("party_receipt_hdr").Rows.Count > 0 Then
            TXT_CARDNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("cardnumber")
            Txt_city.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("PLACE")
            INS_TYPE.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTTYPE")
            'INSTNO,INSDATE,DRAWBANK
            TXT_INSNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTNO")
            INS_DATE.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTDATE")
            TXT_DRAWEEBANK.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("DRAWBANK")
        End If
        sqlstring = "SELECT Receiptheadcode,Receiptheaddesc,amount,RECEIPTTYPE from party_receipt_DET WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        DT = gconnection.GetValues(sqlstring)
        If DT.Rows.Count > 0 Then
            ssgrid_Receipt.ClearRange(-1, -1, 1, 1, True)
            With ssgrid_Receipt
                For i = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheadcode")
                    .Col = 2
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheaddesc")
                    .Col = 3
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("amount")
                Next
            End With

            '''''''''''''''POS''''''''''''''''
            If cbo_PaymentMode.Text = "SMART CARD" Then
                sqlstring = "SELECT * FROM SM_POSTRANSACTION WHERE BILL_NO='" & Me.TXTVOUCHERNO.Text & "'"
                gconnection.getDataSet(sqlstring, "SM_POSTRANSACTION")
                If gdataset.Tables("party_receipt_hdr").Rows.Count > 0 Then
                    ''Label22.Visible = True

                    txt_Holder_Code.Text = Trim(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("CARDCODE") & "")
                    ' Txt_holder_name.Text = Trim(gdataset.Tables("party_receipt_hdr").Rows(0).Item("CARDHOLDERNAME") & "")
                    '  cardcode = Trim(gdataset.Tables("party_receipt_hdr").Rows(0).Item("CARDHOLDERCODE") & "")
                    txt_card_id.Text = Trim(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("16_DIGIT_CODE") & "")

                    sqlstring = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & Me.txt_Holder_Code.Text & "'"
                    gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                    If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                        Txt_holder_name.Text = Trim(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("NAME") & "")
                    End If
                    '' txt_card_id .Text =
                End If
            End If

            '''''''''''END''''''''''''''

            Me.Cmd_Add.Text = "Update[F7]"

        End If

        'Me.Cmd_Add.Text = "Update[F7]"
    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 5
                ssgrid_Receipt.Col = j
                ssgrid_Receipt.Row = i
                ssgrid_Receipt.Lock = False
            Next j
        Next i
    End Sub
    Private Sub txtmname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_MemberName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTGUESTNAME.Focus()
        End If
    End Sub
    Private Sub Receiptentry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call CMD_FREEZE_Click(CMD_FREEZE, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call CMD_VOUCHERNOHELP_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_view_Click(Cmd_view, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_exit_Click(cmd_exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub txtmcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_MemberCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_mcodehelp_Click(sender, e)
        End If
    End Sub

    Private Sub txtmname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_MemberName.KeyUp

    End Sub

    Private Sub TxtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescription.TextChanged

    End Sub

    Private Sub txtmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MemberCode.TextChanged

    End Sub
    Private Sub CMBRECEIPTTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRECEIPTTYPE.SelectedIndexChanged
        Call Lastvoucherno()
    End Sub
    Private Sub TXTVOUCHERNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTVOUCHERNO.TextChanged
    End Sub
    Private Sub Lastvoucherno()
        Dim STRSQL As String
        Dim VOUNO As Integer
        Dim DT As New DataTable
        LABLASTVOUCHERNO.Visible = True
        LABLASTVOUCHERNO.Text = ""
        STRSQL = "SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(VOUCHERNO,5,5))),0) AS MAXNO FROM PARTY_RECEIPT "
        STRSQL = STRSQL & " WHERE SUBSTRING(LTRIM(VOUCHERNO),1,3)='" & Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "'"
        DT = gconnection.GetValues(STRSQL)
        If DT.Rows.Count > 0 Then
            VOUNO = DT.Rows(0).Item(0)
        Else
            VOUNO = 1
        End If
        If VOUNO >= 1 And VOUNO <= 9 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0000" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 10 And VOUNO <= 99 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/000" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 100 And VOUNO <= 999 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/00" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 1000 And VOUNO <= 9999 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        Else
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        End If
    End Sub

    Private Sub TXTVOUCHERNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTVOUCHERNO.KeyDown
        If e.KeyCode = Keys.F4 Then
            CMD_VOUCHERNOHELP_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            TXTVOUCHERNO_Validated(sender, e)
        End If
    End Sub

    Private Sub ssgrid_Receipt_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid_Receipt.Advance

    End Sub
    Private Sub ssgrid_Receipt_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_Receipt.KeyDownEvent
        Dim partyheadcode As String
        Dim AMOUNT As Integer


        '' '' ''With ssgrid_Receipt
        '' '' ''    If e.keyCode = Keys.Enter Then
        '' '' ''        i = .ActiveRow
        '' '' ''        If .ActiveCol = 1 Then
        '' '' ''            .Row = i
        '' '' ''            .Col = 1
        '' '' ''            .Focus()
        '' '' ''            If Trim(.Text) = "" Then
        '' '' ''                .SetActiveCell(1, .ActiveRow)
        '' '' ''                .Focus()
        '' '' ''            Else
        '' '' ''                .SetActiveCell(2, .ActiveRow)
        '' '' ''            End If
        '' '' ''        ElseIf .ActiveCol = 2 Then
        '' '' ''            .Col = 2
        '' '' ''            .Row = i
        '' '' ''            If Trim(.Text) = "" Then
        '' '' ''                .SetActiveCell(2, .ActiveRow)
        '' '' ''                .Focus()
        '' '' ''            Else
        '' '' ''                .SetActiveCell(3, .ActiveRow)
        '' '' ''            End If
        '' '' ''        ElseIf .ActiveCol = 3 Then
        '' '' ''            .Col = 3
        '' '' ''            .Row = i
        '' '' ''            AMOUNT = .Text
        '' '' ''            If Val(AMOUNT) <> 0 Then
        '' '' ''                .SetActiveCell(1, .ActiveRow + 1)
        '' '' ''                .Focus()
        '' '' ''                AMOUNT = .Text
        '' '' ''                '  TXT_AMT.Text = Format((ssgrid_Receipt), "0.00")
        '' '' ''                TXT_AMT.Text = AMOUNT
        '' '' ''            ElseIf Val(.Text) = 0 Then
        '' '' ''                .SetActiveCell(3, .ActiveRow)
        '' '' ''                .Focus()
        '' '' ''            End If
        '' '' ''            Call Calculate()
        '' '' ''        End If


        '' '' ''    ElseIf e.keyCode = Keys.F3 Then
        '' '' ''        .Row = .ActiveRow
        '' '' ''        .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)
        '' '' ''        .DeleteRows(.ActiveRow, 1)
        '' '' ''        .SetActiveCell(1, .ActiveRow)
        '' '' ''    End If
        '' '' ''End With

        With ssgrid_Receipt
            If e.keyCode = Keys.Enter Then
                i = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = i
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call FillMenu()
                    ElseIf Trim(.Text) <> "" Then
                        partyheadcode = Trim(.Text)
                        .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)

                        sqlstring = "SELECT  DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master"
                        sqlstring = sqlstring & " WHERE RECEIPTHEADCODE='" & partyheadcode & "'"
                        gconnection.getDataSet(sqlstring, "partyheadcode")
                        If gdataset.Tables("partyheadcode").Rows.Count > 0 Then
                            .Col = 1
                            .Row = i
                            .Text = gdataset.Tables("partyheadcode").Rows(0).Item("RECEIPTHEADCODE")
                            .Col = 2
                            .Row = i
                            .Text = gdataset.Tables("partyheadcode").Rows(0).Item("Receiptheaddesc")
                            .SetActiveCell(3, .ActiveRow)
                            .Focus()

                        Else
                            .ClearRange(1, .ActiveRow, 1, .ActiveRow, True)
                            .SetActiveCell(1, .ActiveRow)
                            .Focus()
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    If Val(.Text) = 0 Then
                        .SetActiveCell(3, .ActiveRow)
                        .Focus()
                    Else
                        .SetActiveCell(2, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = i
                    AMOUNT = Val(.Text)
                    If Val(AMOUNT) <> 0 Then
                        .SetActiveCell(1, .ActiveRow + 1)
                        .Focus()
                        AMOUNT = .Text
                        'TXT_AMT.Text = Format((ssgrid_Receipt), "0.00")
                        TXT_AMT.Text = AMOUNT
                    ElseIf Val(.Text) = 0 Then
                        .SetActiveCell(1, .ActiveRow)
                        .Focus()
                    End If
                End If

                'Call Calculate()
            ElseIf e.keyCode = Keys.F3 Then
                .Row = .ActiveRow
                .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, .ActiveRow)
            End If
        End With

    End Sub
    Private Sub FillMenu()
        Try
            Dim vform As New LIST_OPERATION1

            Dim ssql As String

            gSQLString = "SELECT DISTINCT RECEIPTHEADCODE,RECEIPTHEADDESC FROM party_Head_master"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "RECEIPTHEADCODE,RECEIPTHEADDESC"
            'vform.vFormatstring = "RECEIPTHEADCODE    |RECEIPT HEADDESC  "
            vform.vCaption = "RECEIPT HEAD CODE HELP"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            'vform.keypos4 = 4
            vform.ShowDialog(Me)

            If Trim(vform.keyfield & "") <> "" Then
                With ssgrid_Receipt
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = vform.keyfield
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = vform.keyfield1
                    '.Col = 3
                    '.Row = .ActiveRow
                    '.Text = vform.keyfield2
                    '.Col = 4
                    '.Row = .ActiveRow
                    '.Text = Format(CDate(vform.keyfield3), "dd/MM/yyyy")

                    '.Col = 5
                    '.Row = .ActiveRow
                    '.Text = vform.keyfield4

                    '.Col = 7
                    '.Row = .ActiveRow
                    '.Text = Format(Now, "dd/MM/yyyy")

                    '.SetText(8, i, "N")

                    .SetActiveCell(3, .ActiveRow)

                End With
            Else
                ssgrid_Receipt.SetActiveCell(0, ssgrid_Receipt.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub HALLHEAD()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        gSQLString = "SELECT DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master "
        If Trim(Search) = " " Then
            M_WhereCondition = " "
        Else
            M_WhereCondition = " where ISNULL(FREEZE,'') <>'Y' "
        End If
        vform.Field = "RECEIPTHEADCODE,Receiptheaddesc"
        'vform.vFormatstring = "RECEIPTHEADCODE     |RECEIPT HEAD DESCRIPTION     "
        vform.vCaption = "RECEIPT HEAD CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid_Receipt
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield1

            End With
            ssgrid_Receipt.SetActiveCell(3, ssgrid_Receipt.ActiveRow)
        Else

            Exit Sub

        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXTBOOKINGNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTBOOKINGNO.KeyDown

    End Sub

    Private Sub TXTBOOKINGNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.TextChanged
    End Sub

    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Dtppartydate.Focus()
            cbo_PaymentMode.Focus()
        End If
    End Sub

    Private Sub TXTBOOKINGNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.Validated

        If Trim(TXTBOOKINGNO.Text) <> "" Then
            sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            gconnection.getDataSet(sqlstring, "HallStatus")
            If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                Dtppartydate.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("partydate"), "dd/MM/yyyy")
                txt_MemberCode.Text = gdataset.Tables("HallStatus").Rows(0).Item("mcode")
                txt_MemberName.Text = gdataset.Tables("HallStatus").Rows(0).Item("mname")
                TXTGUESTNAME.Text = gdataset.Tables("HallStatus").Rows(0).Item("GUESTNAME")
                TxtDescription.Text = gdataset.Tables("HallStatus").Rows(0).Item("Description")
                sqlstring = "SELECT PARTYRECEIPTNO,Receiptheaddesc,AMOUNT FROM party_receipt_DET  WHERE ISNULL(FREEZE,'')<>'Y' AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                gconnection.getDataSet(sqlstring, "PAY")
                If gdataset.Tables("PAY").Rows.Count > 0 Then
                    DTGRD.DataSource = gdataset.Tables("PAY")
                End If
            Else
                If MsgBox("PARTICULAR BOOKING IS NOT FOUND...", MsgBoxStyle.OkCancel, "BANQUET") = MsgBoxResult.Ok Then
                    TXTBOOKINGNO.Clear()
                    TXTBOOKINGNO.Focus()
                End If
            End If
        End If
        Dtppartydate.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT DISTINCT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,MCODE "
            gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,MCODE"
            'vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE     |        MCODE    "
            vform.vCaption = "HALL RESERVATION HELP"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
                Dtppartydate.Text = Trim(vform.keyfield1 & "")
                Call TXTBOOKINGNO_Validated(sender, e)
                Dtppartydate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Dtppartydate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtppartydate.ValueChanged

    End Sub

    Private Sub Dtppartydate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtppartydate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTVOUCHERNO.Focus()
        End If
    End Sub

    Private Sub DTPVOUCHERDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPVOUCHERDATE.ValueChanged

    End Sub
    Public Function CloseSmartDevicePort()
        'Dim RETVALUE, HANDLE As Integer
        'RETVALUE = ACR120U.ACR120_Close(HANDLE)
        Dim RETVALUE, HANDLE As Integer
        If UCase(gCompanyname) = "KARNATAKA GOLF ASSOCIATION-INN" Then
        Else
            If greadertype = "ACR120U" Then
                RETVALUE = ACR120U.ACR120_Close(HANDLE)
                'ElseIf greadertype = "SM_D3" Then
                '    ''   SM_D3.dc_exit(icdev)
                '    Exit Function
            Else
                If connActive Then

                    retcode = ModWinsCard.SCardDisconnect(hcard, ModWinsCard.SCARD_UNPOWER_CARD)

                End If

                '' Shared Connection
                'retcode = ModWinsCard.SCardConnect(hContext, greadertype.ToString(), ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)

                'If retcode <> ModWinsCard.SCARD_S_SUCCESS Then
                '    Exit Function


                'Else

                '    ' Call displayOut(0, 0, "Successful connection to " & cbReader.Text)

                'End If

                connActive = False
            End If
        End If
    End Function

    Private Sub com_payment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_PaymentMode.SelectedIndexChanged
        If Trim(cbo_PaymentMode.Text) = "CHEQUE" Then
            TXT_CARDNO.Visible = False
            LBL_CARD.Visible = False
            bankdet.Visible = True


            lbl_SwipeCard.Visible = False
            txt_card_id.Visible = False
            Lbl_ccode.Visible = False
            Lbl_cname.Visible = False
            txt_Holder_Code.Visible = False
            Txt_holder_name.Visible = False
        ElseIf Trim(cbo_PaymentMode.Text) = "DD" Then
            LBL_CARD.Visible = False
            TXT_CARDNO.Visible = False
            bankdet.Visible = True
            lbl_SwipeCard.Visible = False
            txt_card_id.Visible = False
            Lbl_ccode.Visible = False
            Lbl_cname.Visible = False
            txt_Holder_Code.Visible = False
            Txt_holder_name.Visible = False
        ElseIf Trim(cbo_PaymentMode.Text) = "CARD" Then
            LBL_CARD.Visible = True
            TXT_CARDNO.Visible = True
            bankdet.Visible = False

            lbl_SwipeCard.Visible = False
            txt_card_id.Visible = False
            Lbl_ccode.Visible = False
            Lbl_cname.Visible = False
            txt_Holder_Code.Visible = False
            Txt_holder_name.Visible = False
        ElseIf Trim(cbo_PaymentMode.Text) = "CREDIT" Then
            LBL_CARD.Visible = False
            TXT_CARDNO.Visible = False
            bankdet.Visible = False

            lbl_SwipeCard.Visible = False
            txt_card_id.Visible = False
            Lbl_ccode.Visible = False
            Lbl_cname.Visible = False
            txt_Holder_Code.Visible = False
            Txt_holder_name.Visible = False
            'Else
            '    bankdet.Visible = False
        ElseIf Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
            LBL_CARD.Visible = False
            TXT_CARDNO.Visible = False
            bankdet.Visible = False
            Lbl_ccode.Visible = True
            Lbl_cname.Visible = True
            txt_Holder_Code.Visible = True
            Txt_holder_name.Visible = True

            Dim sqlstring As String
            'CSC SMARTCARD
            Try
                Call CloseSmartDevicePort()
                PAYMENTMODE_GBL = cbo_PaymentMode.Text
                lastpaymode = cbo_PaymentMode.Text
                ordertype = " "


                lbl_SwipeCard.Visible = True
                txt_card_id.Visible = True
                txt_card_id.Text = ""
                'Timer1.Enabled = True
                Label3.Visible = True
                '  Label4.Visible = True
             

                txt_MemberCode.Enabled = False
                txt_MemberName.Enabled = False
                Txt_holder_name.Visible = True
                txt_Holder_Code.Enabled = True

                Txt_holder_name.Enabled = False

                'lbl_SubPaymentMode.Visible = False
                'cbo_SubPaymentMode.Visible = False
                'cmd_MemberCodeHelp.Visible = False

                '***************** CSC SMARTCARD

                txt_MemberCode.ReadOnly = True
                txt_MemberName.ReadOnly = True
                'cmd_MemberCodeHelp.Visible = False



                '' ''txt_MemberName.Text = ""
                '' ''txt_MemberCode.Text = ""


                txt_Holder_Code.Text = ""
                Txt_holder_name.Text = ""

                txt_MemberCode.Text = MCODE_GBL
                txt_MemberName.Text = MNAME_GBL


                If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                    '*****************'CSC SMARTCARD
                    txt_MemberCode.Text = MCODE_GBL
                    txt_MemberName.Text = MNAME_GBL
                End If

                '' cmd_MemberCodeHelp.Visible = False
                ''   lbl_Membercode.Text = "MEMBER CODE :"
                sqlstring = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                sqlstring = sqlstring & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                gconnection.getDataSet(sqlstring, "SM_MEM_LINKAGE")
                'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                Call CardIdValidate(Trim(txt_card_id.Text))
                If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                    cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                ElseIf Cardidcheck = True Then
                    cardcode = Trim(vCardcode)
                    vCardcode = ""
                Else
                    If Me.txt_card_id.Text <> "" Then
                        MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    cbo_PaymentMode.Focus()
                    Exit Sub
                End If

                sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                    If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                        gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                        If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                            MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                            Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                            txt_MemberName.Text = MNAME_GBL
                            ordertype = "CLUBMEMBER"
                        End If
                    ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                        'lbl_Membercode.Text = "CLUB CODE   :"
                        gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                        If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                            MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                            txt_MemberName.Text = MNAME_GBL
                            ordertype = "AFFMEMBER"
                        End If
                    ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                        '  lbl_Membercode.Text = "EMP CODE   :"
                        gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                        If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                            MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                            txt_MemberName.Text = MNAME_GBL
                            ordertype = "EMPMEMBER"
                        End If
                    End If
                End If




                If TXTBOOKINGNO.Text <> "" Then
                    sqlstring = " select * from party_receipt_hdr where BOOKINGNO  ='" & Trim(TXTBOOKINGNO.Text) & "'"
                    gconnection.getDataSet(sqlstring, "party_receipt_hdr1")
                    If gdataset.Tables("party_receipt_hdr1").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("party_receipt_hdr1").Rows(0).Item("MCODE")
                        txt_MemberName.Text = gdataset.Tables("party_receipt_hdr1").Rows(0).Item("MNAME")
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
            '' Call FillSubPaymentMode(Trim(Me.cbo_PaymentMode.Text))

        End If




    End Sub

    Private Sub com_payment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_PaymentMode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXT_VOTYPE.Focus()
        End If
    End Sub

    Private Sub txtmcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemberCode.LostFocus
        Try
            Dim dt As New DataTable
            If txt_MemberCode.Text <> "" Then
                sqlstring = "Select ISNULL(MNAME,'') AS MNAME from membermaster where mcode='" & txt_MemberCode.Text & "'"
                dt = gconnection.GetValues(sqlstring)
                If dt.Rows.Count > 0 Then
                    txt_MemberName.Text = dt.Rows(0).Item("mname")
                Else
                    MessageBox.Show("Member Code Not Found,Please Check ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_MemberCode.Text = ""
                    txt_MemberCode.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub com_payment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_PaymentMode.Validated

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub


    Private Sub ssgrid_Receipt_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_Receipt.LeaveCell
        'Dim amount As Double
        'Dim Receiptheaddesc, Receiptheadcode As String
        'With ssgrid_Receipt

        'End With

    End Sub

    Private Sub TXT_VOTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_VOTYPE.SelectedIndexChanged

        If Trim(TXT_VOTYPE.Text) = "DEPOSIT" Then
        ElseIf Trim(TXT_VOTYPE.Text) = "REFUND" Then
        ElseIf Trim(TXT_VOTYPE.Text) = "ADVANCE" Then
        End If

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub TXTGUESTNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGUESTNAME.TextChanged

    End Sub

    Private Sub TXTGUESTNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGUESTNAME.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLAMOUNT.Focus()
        End If
    End Sub

    Private Sub TXT_VOTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_VOTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ssgrid_Receipt.SetActiveCell(1, 1)
            ssgrid_Receipt.Focus()
        End If
    End Sub

    Private Sub ssgrid_Receipt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ssgrid_Receipt.Leave

    End Sub

    Private Sub TXT_AMT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_AMT.TextChanged

    End Sub


    Private Sub BK_HELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BK_HELP.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT DISTINCT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,MCODE "
            gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,MCODE"
            ' vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE     |        MCODE    "
            vform.vCaption = "HALL RESERVATION HELP"
            '  vform.KeyPos = 0
            '  vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
                TXTBOOKINGNO.Select()
                ' Dtppartydate.Text = Trim(vform.keyfield1 & "")
                Call TXTBOOKINGNO_Validated(sender, e)
                Dtppartydate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CMD_VOUCHERNOHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_VOUCHERNOHELP.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select DISTINCT PARTYRECEIPTNO,PARTYRECEIPTDATE,BOOKINGNO,PARTYDATE,MCODE,MNAME,DESCRIPTION FROM party_receipt_DET "
            M_WhereCondition = ""
            vform.Field = "PARTYRECEIPTNO,PARTYRECEIPTDATE"
            'vform.vFormatstring = " PARTYRECEIPTNO        | PARTYRECEIPTDATE       |   BOOKINGNO       |    PARTYDATE       |  MCODE    |   MNAME           |   DESCRIPTION     |"
            vform.vCaption = "Member Master Help"
            '   vform.KeyPos = 0
            '  vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTVOUCHERNO.Text = Trim(vform.keyfield & "")
                TXTVOUCHERNO.Select()
                ' DTPVOUCHERDATE.Text = Trim(vform.keyfield1 & "")
                Call TXTVOUCHERNO_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TXTVOUCHERNO.ReadOnly = True
    End Sub

    Private Sub cmd_mcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_mcodehelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select Mcode,Mname From MemberMaster "
            M_WhereCondition = "  WHERE CURENTSTATUS IN ('ACTIVE','LIVE')"
            vform.Field = "Mcode,Mname"
            'vform.vFormatstring = " Member Code  | Member Name                           "
            vform.vCaption = "Member Master Help"
            ' vform.KeyPos = 0
            '  vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberCode.Select()
                ' txtmname.Text = Trim(vform.keyfield1 & "")
                ' txtmcode.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call autogeneratePARTY()
        DTGRD.DataSource = Nothing
        DTPVOUCHERDATE.Value = Format("dd/MM/yyyy", Now())
        Dtppartydate.Value = Format("dd/MM/yyyy", Now())
        txt_MemberCode.Text = ""
        TxtDescription.Text = ""
        TXTBOOKINGNO.Text = ""
        Label22.Visible = False
        cbo_PaymentMode.Text = ""
        txt_MemberCode.Text = ""
        txt_MemberName.Text = ""
        TXTGUESTNAME.Text = ""
        TXT_CARDNO.Visible = False
        LBL_CARD.Visible = False
        TXT_CARDNO.Text = ""
        bankdet.Visible = False
        Txt_city.Text = ""
        ssgrid_Receipt.ClearRange(1, 1, -1, -1, True)
        Call BILLGENERATE()
        Call autogeneratePARTY()
        If Trim(cbo_PaymentMode.Text) = "CHEQUE" Then
            bankdet.Visible = True
        ElseIf Trim(cbo_PaymentMode.Text) = "DD" Then
            bankdet.Visible = True
        Else
            bankdet.Visible = False
        End If
        txt_MemberName.Text = ""
        TXTGUESTNAME.Text = ""
        cbo_PaymentMode.Text = ""
        TXT_VOTYPE.Text = ""
        LABLASTVOUCHERNO.Visible = True
        LABLASTVOUCHERNO.Text = ""
        TXTVOUCHERNO.ReadOnly = False
        lbl_Freeze.Visible = False
        Cmd_Add.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        TXTBOOKINGNO.Focus()
        Call autogeneratePARTY()
        cbo_PaymentMode.Text = "CASH"
        TXT_AMT.Text = "0.00"

        lbl_SwipeCard.Visible = False
        txt_card_id.Visible = False
        Lbl_ccode.Visible = False
        Lbl_cname.Visible = False
        txt_Holder_Code.Visible = False
        Txt_holder_name.Visible = False

        lbl_bal.Text = ""
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim DT As New DataTable
        Dim HALCODE, ACCTCODE, ACCTDESC, RECPTCODE, RECPTDESC As String
        Dim VOUNO As Integer
        Dim INSERT(0) As String
        LABLASTVOUCHERNO.Visible = True
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            Call autogeneratePARTY()


            strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
            strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
            strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
            strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
            strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(cbo_PaymentMode.Text) & "','" & TxtDescription.Text & "'"
            strSQL = strSQL & ",'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
            strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
            strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "','" & Trim(TXT_CARDNO.Text) & "','" & Trim(Txt_city.Text) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With ssgrid_Receipt
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
                    strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(cbo_PaymentMode.Text) & "','" & TxtDescription.Text & "'"
                    strSQL = strSQL & ",'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
                    ssgrid_Receipt.Row = i
                    ssgrid_Receipt.Col = 1
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 2
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 3
                    strSQL = strSQL & "," & Val(ssgrid_Receipt.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With
            sqlstring = "UPDATE POSKOTDOC SET DOCNO = ISNULL(DOCNO,0) + 1 WHERE DOCTYPE = 'PARTY'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "  SELECT *  FROM PARTY_HALLBOOKING_DET WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "' "
            gconnection.getDataSet(sqlstring, "PARTY_HALLBOOKING_DET")
            If gdataset.Tables("PARTY_HALLBOOKING_DET").Rows.Count > 0 Then
                HALCODE = gdataset.Tables("PARTY_HALLBOOKING_DET").Rows(0)("HALLCODE")
            End If

            sqlstring = "   SELECT * FROM PARTY_HALLMASTER_HDR WHERE halltypecode ='" & HALCODE & "' "
            gconnection.getDataSet(sqlstring, "PARTY_HALLMASTER_HDR")
            If gdataset.Tables("PARTY_HALLMASTER_HDR").Rows.Count > 0 Then
                ACCTCODE = gdataset.Tables("PARTY_HALLMASTER_HDR").Rows(0)("glaccode")
                ACCTDESC = gdataset.Tables("PARTY_HALLMASTER_HDR").Rows(0)("GLDESC")
            End If

            sqlstring = "   SELECT * FROM party_Head_master WHERE Receiptheadcode ='ADV' "
            gconnection.getDataSet(sqlstring, "party_Head_master")
            If gdataset.Tables("party_Head_master").Rows.Count > 0 Then
                RECPTCODE = gdataset.Tables("party_Head_master").Rows(0)("ACCOUNTIN")
                RECPTDESC = gdataset.Tables("party_Head_master").Rows(0)("ACCTINDESC")
            End If


            'TWO TABLE  RECORD INSERTING HERE
            '''''''JOURNALS'''''''''''''''''''''''''''
            sqlstring = "insert into journalentry(voucherno,voucherdate,VOUCHERCATEGORY,vouchertype,accountcode,"
            sqlstring = sqlstring & " accountcodedesc, SLCODE, sldesc, REF_NO,  "
            sqlstring = sqlstring & " amount,creditdebit,cashbank,void,description,oppaccountcode,InstrumentDate,InstrumentType,"
            sqlstring = sqlstring & " Instrumentno,adduserid, adddatetime, RoomRefFlag)"
            sqlstring = sqlstring & " VALUES('" & Trim(TXTVOUCHERNO.Text) & "',"
            sqlstring = sqlstring & " '" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy") & "','PARTY-ADVANCE','PARTY','" & ACCTCODE & "',"
            sqlstring = sqlstring & "'" & ACCTDESC & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "', " & Val(TXTBOOKINGNO.Text) & ","
            sqlstring = sqlstring & Val(TXT_AMT.Text) & ",'DEBIT','" & Trim(cbo_PaymentMode.Text) & "','N',"
            sqlstring = sqlstring & " 'ADV. RECVD. FROM ROOM PARTY  BOOKING ID-" & TXTBOOKINGNO.Text & " ','',"
            If cbo_PaymentMode.Text = "CHEQUE" Then
                sqlstring = sqlstring & " '" & Format(INS_DATE.Value, "dd/MMM/yyyy") & "','" & INS_TYPE.Text & "','" & TXT_INSNO.Text & "','" & gUsername & "',"
            Else
                sqlstring = sqlstring & " '','','','" & gUsername & "',"
            End If
            ''  sqlstring = sqlstring & " '" & Format(CMDRECEIPTDATE.Value, "dd/MMM/yyyy") & "','" & CBOPAYMENT.Text & "','" & TXTCHEQUENO.Text & "','" & gUsername & "',"
            sqlstring = sqlstring & " '" & Format(Date.Now, "dd/MMM/yyyy HH:mm") & "',"
            sqlstring = sqlstring & " 'P')"

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring


            sqlstring = "insert into journalentry(voucherno,voucherdate,VOUCHERCATEGORY,vouchertype,accountcode,"
            sqlstring = sqlstring & " accountcodedesc, SLCODE, sldesc, REF_NO,  "
            sqlstring = sqlstring & " amount,creditdebit,cashbank,void,description,oppaccountcode,InstrumentDate,InstrumentType,"
            sqlstring = sqlstring & " Instrumentno,adduserid, adddatetime, RoomRefFlag)"
            sqlstring = sqlstring & " VALUES('" & Trim(TXTVOUCHERNO.Text) & "',"
            sqlstring = sqlstring & " '" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy") & "','PARTY-ADVANCE','PARTY','" & RECPTCODE & "',"
            sqlstring = sqlstring & "'" & RECPTDESC & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "', " & Val(TXTBOOKINGNO.Text) & ","
            sqlstring = sqlstring & Val(TXT_AMT.Text) & ",'CREDIT','" & Trim(cbo_PaymentMode.Text) & "','N',"
            sqlstring = sqlstring & " 'ADV. RECVD. FROM ROOM PARTY  BOOKING ID-" & TXTBOOKINGNO.Text & " ','',"
            If cbo_PaymentMode.Text = "CHEQUE" Then
                sqlstring = sqlstring & " '" & Format(INS_DATE.Value, "dd/MMM/yyyy") & "','" & INS_TYPE.Text & "','" & TXT_INSNO.Text & "','" & gUsername & "',"
            Else
                sqlstring = sqlstring & " '','','','" & gUsername & "',"
            End If
            ''  sqlstring = sqlstring & " '" & Format(CMDRECEIPTDATE.Value, "dd/MMM/yyyy") & "','" & CBOPAYMENT.Text & "','" & TXTCHEQUENO.Text & "','" & gUsername & "',"
            sqlstring = sqlstring & " '" & Format(Date.Now, "dd/MMM/yyyy HH:mm") & "',"
            sqlstring = sqlstring & " 'P')"

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            ''''''''''''''''''''''''''''''''''''''




            ''''''''''''''P O S  T R A C T I O N''''''''''''''
            Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double


            '  DEDUCT_FROM_CARD = " & Format(Val(TXT_AMT.Text), 0.0) & "

            DEDUCT_FROM_CARD = Val(TXT_AMT.Text)

            strSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL

            'FOR EBALANCE

            Dim BALstr, EBAL As String
            Dim BALnum As Double
            sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
            gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
            If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                    BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) - Val(DEDUCT_FROM_CARD)
                Else '--for zero
                    BALnum = 0 - Val(DEDUCT_FROM_CARD)
                End If
            End If
            EBAL = abcdADD(BALnum)

            strSQL = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            'END

            strSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,DEDUCT_TYPE,DEDUCT_FROM_card) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','PTY','" & Format(DTPVOUCHERDATE.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(TXTVOUCHERNO.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','FC'," & DEDUCT_FROM_CARD & ")"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL


            '''''''''''''''''''''PO S TRACTION END.................................
            gconn.MoreTrans(INSERT)

            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call RECEIT()
            End If

        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  party_receipt_HDR"
            strSQL = strSQL & " SET PARTYRECEIPTDATE='" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & " BOOKINGNO ='" & Trim(TXTBOOKINGNO.Text) & "',"
            strSQL = strSQL & " PARTYDATE ='" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & " description ='" & Trim(TxtDescription.Text) & "',"
            strSQL = strSQL & " Mcode ='" & Trim(txt_MemberCode.Text) & "',"
            strSQL = strSQL & " MNAME ='" & Trim(txt_MemberName.Text) & "',"
            strSQL = strSQL & " GUESTNAME ='" & Trim(TXTGUESTNAME.Text) & "',"
            strSQL = strSQL & " PAYMENTMODE ='" & Trim(cbo_PaymentMode.Text) & "',"
            strSQL = strSQL & " INSTTYPE ='" & Trim(INS_TYPE.Text) & "',"
            strSQL = strSQL & " INSTNO ='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " RECEIPTTYPE='" & Trim(TXT_VOTYPE.Text) & "',"
            strSQL = strSQL & " DRAWBANK ='" & Trim(TXT_DRAWEEBANK.Text) & "',"
            strSQL = strSQL & " INSTDATE ='" & Format(INS_DATE.Value, "dd/MMM/yyyy") & "',"
            strSQL = strSQL & " UPDATEuserid='" & Trim(gUsername) & "',"
            strSQL = strSQL & " TOTALAMOUNT='" & Format(Val(TXT_AMT.Text), 0.0) & "',"
            strSQL = strSQL & " CARDNUMBER='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " UPDATEadddatetime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With ssgrid_Receipt
                strSQL = " DELETE FROM party_receipt_DET "
                strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
                    strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(cbo_PaymentMode.Text) & "','" & TxtDescription.Text & "'"
                    strSQL = strSQL & ",'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
                    ssgrid_Receipt.Row = i
                    ssgrid_Receipt.Col = 1
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 2
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 3
                    strSQL = strSQL & "," & Val(ssgrid_Receipt.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With

            ''''''''''''''POS'''''''''''''''''''''''''''''
            If Me.cbo_PaymentMode.Text = "SMART CARD" Then
                ''sqlstring = "SELECT [16_DIGIT_CODE]AS CODE FROM  SM_POSTRANSACTION WHERE BILL_NO='" & Trim(TXTVOUCHERNO.Text) & "' "
                ''DT = gconnection.GetValues(sqlstring)
                ''If DT.Rows.Count > 0 Then
                ''    If Trim(DT.Rows(0).Item("CODE")) <> Trim(Me.txt_card_id.Text) Then
                ''        MsgBox("SORRY PUT THE CORRECT CARD WITH WHICH BILLING DONE")
                ''        Call Cmd_Clear_Click(Cmd_Clear, e)
                ''        Exit Sub
                ''    End If
                ''End If

                strSQL = " DELETE FROM SM_POSTRANSACTION "
                strSQL = strSQL & " Where BILL_NO='" & Trim(TXTVOUCHERNO.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL


                Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double


                '  DEDUCT_FROM_CARD = " & Format(Val(TXT_AMT.Text), 0.0) & "

                DEDUCT_FROM_CARD = Val(TXT_AMT.Text)

                strSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL

                'FOR EBALANCE

                Dim BALstr, EBAL As String
                Dim BALnum As Double
                sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
                If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                    If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                        BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) - Val(DEDUCT_FROM_CARD)
                    Else '--for zero
                        BALnum = 0 - Val(DEDUCT_FROM_CARD)
                    End If
                End If
                EBAL = abcdADD(BALnum)

                strSQL = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                'END

                strSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,DEDUCT_TYPE,DEDUCT_FROM_card) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','PTY','" & Format(DTPVOUCHERDATE.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(TXTVOUCHERNO.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','FC'," & DEDUCT_FROM_CARD & ")"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL




            End If


            ''''''''''''''''''''''''''''''''''''''''''



            gconn.MoreTrans(INSERT)
            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call RECEIT()
            End If
        End If
        Call Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim Fre, strsql As String
        Try
            'If Val(TXTVOUCHERNO.Text) >= 1 And Val(TXTVOUCHERNO.Text) <= 9 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0000" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 10 And Val(TXTVOUCHERNO.Text) <= 99 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/000" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 100 And Val(TXTVOUCHERNO.Text) <= 999 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/00" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 1000 And Val(TXTVOUCHERNO.Text) <= 9999 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'Else
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'End If
            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            gconnection.getDataSet(sqlstring, "party_receipt_DET")
            If Mid(Me.CMD_FREEZE.Text, 1, 1) = "F" Then

                sqlstring = "UPDATE party_receipt_hdr "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ',"
                sqlstring = sqlstring & " AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "RECEIPT")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If TXTBOOKINGNO.Text.Length > 0 Then
            tables = " FROM ITEMMASTER WHERE ITEMCODE ='" & TXTBOOKINGNO.Text & "' "
        Else
            tables = "FROM ITEMMASTER "
        End If
        Gheader = "ITEMMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"ITEMCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMTYPECODE", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPCODE", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPCODEDEC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BASEUOMSTD", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BASERATESTD", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"OPENFACILITY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"STORECODE", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"MRPRATE", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"roundval", "7"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub




    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Me.Hide()
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Call RECEIT()
    End Sub

    Private Sub Cmd_View1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View1.Click

    End Sub

    Private Sub BK_HELP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BK_HELP.KeyDown

    End Sub

    Private Sub txt_card_id_TextChanged(sender As Object, e As EventArgs) Handles txt_card_id.TextChanged

    End Sub

    Private Sub txt_card_id_Validated(sender As Object, e As EventArgs) Handles txt_card_id.Validated

        If cbo_PaymentMode.Text = "SMART CARD" Then
            Dim ssql, pay, valid, MCODE As String

            ssql = "select MEMBERSTATUS ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(ssql, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                pay = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
                valid = gdataset.Tables("PAY").Rows(0).Item("SMARTVALIDATE")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If
            Dim SQLSTRING As String
            If Trim(txt_card_id.Text) = "" And pay = "SMART CARD" Then
                ''''MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''''lbl_SwipeCard.Visible = True
                ''''txt_card_id.Focus()
                ''''Exit Sub
            Else
                SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                SQLSTRING = SQLSTRING & " UNION ALL SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
                'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                Call CardIdValidate(Trim(txt_card_id.Text))
                If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                    cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                ElseIf Cardidcheck = True Then
                    cardcode = Trim(vCardcode)
                    vCardcode = ""
                Else
                    If pay = "SMART CARD" Then
                        MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Focus()
                        Exit Sub
                    End If
                End If

                SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "' "
                gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
                If txt_card_id.Text <> "" Then
                    '' gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                End If
                If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                    'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                    Dim temp_flag As Char
                    temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                    If temp_flag <> "Y" Then
                        MessageBox.Show("Sorry!  Your Card Not Activated. " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Sub
                    End If
                    'DISPLAY BALNACE AMOUNT
                    BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE")), "0.00")
                    'MIN_USAGE_BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MIN_USG_BALANCE")), "0.00")


                Else
                    'MessageBox.Show("Sorry! CARD EXPIRED " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK)
                End If



                If Trim(Me.txt_card_id.Text) <> "" Then
                    Call DISPLAYINF()



                    If TXTBOOKINGNO.Text <> "" Then
                        SQLSTRING = " select * from party_receipt_hdr where BOOKINGNO  ='" & Trim(TXTBOOKINGNO.Text) & "'"
                        gconnection.getDataSet(SQLSTRING, "party_receipt_hdr1")
                        If gdataset.Tables("party_receipt_hdr1").Rows.Count > 0 Then
                            txt_MemberCode.Text = gdataset.Tables("party_receipt_hdr1").Rows(0).Item("MCODE")
                            txt_MemberName.Text = gdataset.Tables("party_receipt_hdr1").Rows(0).Item("MNAME")
                        End If
                    End If
                    If Mid(gCompName, 1, 5) = "MCEME" Then
                        'StrSql = " SELECT * FROM memphoto WHERE MCODE ='" & Trim(txt_MemberCode.Text) & "' AND MNAME='" & Trim(Txt_holder_name.Text) & "'"
                        'gconnection.getDataSet(StrSql, "AGE")
                        'If gdataset.Tables("AGE").Rows.Count > 0 Then
                        '    Age = gdataset.Tables("AGE").Rows(0).Item("Age")
                        'End If
                    End If

                End If

                ' ''If Mid(gCompName, 1, 3) = "BRC" Then
                ' ''    If Mid(MSUBCODE, 1, 1) = "D" And txt_card_id.Text <> "" Then
                ' ''        SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'D' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 30 AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE','DIVORCED' ) AND CARDCODE = '" & Trim(cardcode) & "'"
                ' ''        gconnection.getDataSet(SQLSTRING, "ChkDep")
                ' ''        If gdataset.Tables("ChkDep").Rows.Count = 0 Then
                ' ''            MessageBox.Show("This Card Expire Due to Validation of Age or Married", MyCompanyName)
                ' ''            Cmd_Clear_Click(sender, e)
                ' ''            Exit Sub
                ' ''        End If
                ' ''    ElseIf Mid(MSUBCODE, 1, 1) = "S" And txt_card_id.Text <> "" Then
                ' ''        SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'S' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 21 AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE') AND CARDCODE = '" & Trim(cardcode) & "'"
                ' ''        SQLSTRING = SQLSTRING & " UNION ALL SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'S' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 26 AND ISNULL(DEPMEMBERSHIP,'') = 'YES' AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE') AND CARDCODE = '" & Trim(cardcode) & "'"
                ' ''        gconnection.getDataSet(SQLSTRING, "ChkDep")
                ' ''        If gdataset.Tables("ChkDep").Rows.Count = 0 Then
                ' ''            MessageBox.Show("This Card Expire Due to Validation of Age or Married", MyCompanyName)
                ' ''            Cmd_Clear_Click(sender, e)
                ' ''            Exit Sub
                ' ''        End If
                ' ''    End If
                ' ''End If

                ' ''If gFoto = "Y" Then
                ' ''    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                ' ''    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                ' ''    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Txt_holder_name, Pic_Member)
                ' ''Else
                ' ''    If gShortName = "MCC" Then
                ' ''        gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
                ' ''    ElseIf gShortName = "NIZAM" Then
                ' ''        gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
                ' ''    Else
                ' ''        gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
                ' ''    End If
                ' ''End If
                'End If
            End If

        End If
    End Sub
    Public Function CardIdValidate(ByVal vCardID As String) As Boolean
        Try
            Dim vSQL, vDay, vDate, vMonth As String
            'SHOWN ERROR
            'vTmp = vCardID.Substring(6, 11)
            vTmp = vCardID

            vSQL = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(vTmp) & "' AND ISNULL(CARDCODE,'')<>'' "
            vSQL = vSQL & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(vTmp) & "' AND ISNULL(CARDCODE,'')<>'' "
            gconnection.getDataSet(vSQL, "SM_MEM_LINKAGE1")
            If gdataset.Tables("SM_MEM_LINKAGE1").Rows.Count > 0 Then
                vCardcode = gdataset.Tables("SM_MEM_LINKAGE1").Rows(0).Item("CARDCODE")
            End If

            vDate = Format(DateTime.Today, "dd/MM/yyyy")
            vDay = vDate.Substring(0, 2)
            vMonth = vDate.Substring(3, 2)
            If gdataset.Tables("SM_MEM_LINKAGE1").Rows.Count > 0 Then
                If Len(vTmp) > 13 Then
                    If Trim(vCardID.Substring(0, 2)) = Trim(vDay) And Trim(vCardID.Substring(17, 2)) = Trim(vMonth) Then
                        Cardidcheck = True
                        CardIdValidate = True
                    Else
                        vTmp = " "
                        CardIdValidate = False
                        Cardidcheck = False
                    End If
                Else
                    Cardidcheck = True
                    CardIdValidate = True
                End If

            End If

        Catch ex As Exception
            Cardidcheck = False
            CardIdValidate = False
            Exit Function
        End Try
    End Function
   

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ttime = 0 Or ttime <> 2 Then
            '    Lbl_SwipeCard.Visible = False
            ttime = 2
        ElseIf ttime = 2 And Trim(txt_card_id.Text) = "" Then
            txt_card_id.Focus()
            CloseSmartDevicePort()
            If RealD < 0 Then
                Timer1.Stop()
                If MessageBox.Show("PROBLEM IN SMART CARD DEVICE CONNECTION ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Timer1.Start()
                    Call GetSMARTDEVICEPORT()
                Else
                    Timer1.Start()
                End If
            Else
                GetSMARTDEVICEPORT()
            End If
            GetSMART_CARDID()
            txt_card_id.Text = Trim(GBL_SMARTCARDSNO)
            If txt_card_id.Text <> "" Then
                Call txt_card_id_Validated(sender, e)
                ttime = 0
            End If
        ElseIf Mid(gCompName, 1, 6) = "RSIHYD" And ttime = 2 And Trim(txt_card_id.Text) <> "" Then
            CloseSmartDevicePort()
            Timer1.Start()
            Call GetSMARTDEVICEPORT()
            GetSMART_CARDID()
            If txt_card_id.Text <> Trim(GBL_SMARTCARDSNO) And Trim(GBL_SMARTCARDSNO) <> "" Then
                ''txt_card_id.Text = Trim(GBL_SMARTCARDSNO)
                ''If txt_card_id.Text <> "" Then
                ''    Call txt_card_id_Validated(sender, e)
                ''    ttime = 0
                ''End If
                Call Cmd_Clear_Click(sender, e)
            End If
          
        End If
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
    End Sub
   
    Private Sub txt_Holder_Code_TextChanged(sender As Object, e As EventArgs) Handles txt_Holder_Code.TextChanged

    End Sub

    Private Sub txt_Holder_Code_Validated(sender As Object, e As EventArgs) Handles txt_Holder_Code.Validated
        Dim ssql, pay, valid As String
        ssql = "select MEMBERSTATUS ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(ssql, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            pay = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            valid = gdataset.Tables("PAY").Rows(0).Item("SMARTVALIDATE")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        Dim SQLSTRING As String
        If Trim(txt_card_id.Text) = "" And pay = "SMART CARD" Then
            ''''MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ''''lbl_SwipeCard.Visible = True
            ''''txt_card_id.Focus()
            ''''Exit Sub
        Else
            SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            SQLSTRING = SQLSTRING & " UNION ALL SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
            'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
            Call CardIdValidate(Trim(txt_card_id.Text))
            If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
            ElseIf Cardidcheck = True Then
                cardcode = Trim(vCardcode)
                vCardcode = ""
            Else
                If pay = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Focus()
                    Exit Sub
                End If
            End If

            SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "' "
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If txt_card_id.Text <> "" Then
                '   gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            End If
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    MessageBox.Show("Sorry!  Your Card Not Activated. " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                    lbl_SwipeCard.Focus()
                    Exit Sub
                End If
                'DISPLAY BALNACE AMOUNT
                BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE")), "0.00")
                'MIN_USAGE_BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MIN_USG_BALANCE")), "0.00")


            Else
                'MessageBox.Show("Sorry! CARD EXPIRED " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK)
            End If

            'Show PHOTOS
            'If gFoto = "Y" Then
            '    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            '    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            '    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Txt_holder_name, Pic_Member)
            'Else
            '    If gShortName = "MCC" Then
            '        gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
            '    ElseIf gShortName = "NIZAM" Then
            '        gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
            '    Else
            '        gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
            '    End If
            'End If
            If Trim(Me.txt_card_id.Text) <> "" Then
                '' Call DISPLAYINF()
                If Mid(gCompName, 1, 5) = "MCEME" Then
                    'StrSql = " SELECT * FROM memphoto WHERE MCODE ='" & Trim(txt_MemberCode.Text) & "' AND MNAME='" & Trim(Txt_holder_name.Text) & "'"
                    'gconnection.getDataSet(StrSql, "AGE")
                    'If gdataset.Tables("AGE").Rows.Count > 0 Then
                    '    Age = gdataset.Tables("AGE").Rows(0).Item("Age")
                    'End If
                End If

            End If

            'If Mid(gCompName, 1, 3) = "BRC" Then
            '    If Mid(MSUBCODE, 1, 1) = "D" And txt_card_id.Text <> "" Then
            '        SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'D' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 30 AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE','DIVORCED' ) AND CARDCODE = '" & Trim(cardcode) & "'"
            '        gconnection.getDataSet(SQLSTRING, "ChkDep")
            '        If gdataset.Tables("ChkDep").Rows.Count = 0 Then
            '            MessageBox.Show("This Card Expire Due to Validation of Age or Married", MyCompanyName)
            '            Cmd_Clear_Click(sender, e)
            '            Exit Sub
            '        End If
            '    ElseIf Mid(MSUBCODE, 1, 1) = "S" And txt_card_id.Text <> "" Then
            '        SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'S' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 21 AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE') AND CARDCODE = '" & Trim(cardcode) & "'"
            '        SQLSTRING = SQLSTRING & " UNION ALL SELECT * FROM SM_CARDFILE_HDR H,MEMDET D WHERE H.CARDHOLDERNAME  = child_nm AND SUBSTRING(MEMBERSUBCODE,1,1) = 'S' AND DATEDIFF(DAY,D.child_dob,GETDATE())/365.6 <= 26 AND ISNULL(DEPMEMBERSHIP,'') = 'YES' AND  ISNULL(D.maritalstatus,'SINGLE') IN ('SINGLE') AND CARDCODE = '" & Trim(cardcode) & "'"
            '        gconnection.getDataSet(SQLSTRING, "ChkDep")
            '        If gdataset.Tables("ChkDep").Rows.Count = 0 Then
            '            MessageBox.Show("This Card Expire Due to Validation of Age or Married", MyCompanyName)
            '            Cmd_Clear_Click(sender, e)
            '            Exit Sub
            '        End If
            '    End If
            'End If

            'If gFoto = "Y" Then
            '    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            '    'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            '    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Txt_holder_name, Pic_Member)
            'Else
            '    If gShortName = "MCC" Then
            '        gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
            '    ElseIf gShortName = "NIZAM" Then
            '        gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
            '    Else
            '        gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
            '    End If
            'End If
            'End If
        End If
    End Sub
    Public Function DISPLAYINF()
        Try
            Dim sender As Object, e As System.EventArgs
            Dim SMARTDATE, DD, MM, YY As String
            Dim CARDDATE As Date
            Dim i As Integer
            Dim TT() As String
            bselect = True


            Dim sqlstring1, sqlstring2, SQLSTRING, subcode, mcode As String

            If Me.cbo_PaymentMode.Text = "SMART CARD" Then
                SQLSTRING = "SELECT [16_DIGIT_CODE]AS CODE FROM  SM_POSTRANSACTION WHERE BILL_NO='" & Trim(TXTVOUCHERNO.Text) & "' "
                DT = gconnection.GetValues(SQLSTRING)
                If DT.Rows.Count > 0 Then
                    If Trim(DT.Rows(0).Item("CODE")) <> Trim(Me.txt_card_id.Text) Then
                        MsgBox("SORRY PUT THE CORRECT CARD WITH WHICH BILLING DONE")
                        Call Cmd_Clear_Click(Cmd_Clear, e)
                        Exit Function
                    End If
                End If
            End If



            'CHECKING AND DISPLAYING RECORDS FROM SM_CARDFILE_HDR
            SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
            SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME,  ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
            SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = ""
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    If cbo_PaymentMode.Text = "SMART CARD" Then
                        MessageBox.Show("SORRY! CARD IS DEACTIVATED", "CARD DEACTIVATED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Function
                    End If
                End If
                Dim todate As DateTime
                todate = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("VALID_TO")
                If Date.Today > todate Then
                    MessageBox.Show("SORRY! CARD IS OUT OF VALIDITY DATE", "CARD EXPIRED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Function
                End If
                Dim ACCESS_CTL As String
                Dim strsql, STRSQL2 As String
                
                '' ''txt_MemberCode.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MEMBERCODE")
                ' '' ''txt_MemberCode_Validated(sender, e)
                '' ''MCODE_GBL = Trim(txt_MemberCode.Text)
                '' ''NAME_GBL = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("NAME")

                ''If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                ''    txt_MemberCode.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MEMBERCODE")
                ''    MCODE_GBL = Trim(txt_MemberCode.Text)
                ''End If

                MSUBCODE = UCase(Trim(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MEMBERSUBCODE")))
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    gconnection.getDataSet("SELECT MNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                    If Mid(gCompName, 1, 6) = "RSIHYD" Then
                        cbo_PaymentMode.SelectedItem = "SMART CARD"
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM  EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "MEMBERMASTER")
                    If Mid(gCompName, 1, 3) = "BCL" Then
                        cbo_PaymentMode.SelectedItem = "ROOM"
                    End If
                    ''cbo_PaymentMode.SelectedItem = "ROOM"
                End If


                If Mid(gCompName, 1, 6) = "RSIHYD" And gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") <> "MEM" Then
                    cbo_PaymentMode.SelectedItem = "SMART CARD"
                End If

                If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                    MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                    txt_MemberName.Text = MNAME_GBL
                Else

                End If

                'KARTHI JUNE 13
                'KARTHI JUNE 13
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    ' lbl_Membercode.Text = "CLUB CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE CLUBCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    ' lbl_Membercode.Text = "EMP  CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as EMPNAME FROM EMPLOYEEMASTER WHERE mcode='" & Trim(MCODE_GBL) & "'", "empdet")
                    If gdataset.Tables("empdet").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("empdet").Rows(0).Item("EMPNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    '  lbl_Membercode.Text = "ROOM NO     :"
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM")
                    If gdataset.Tables("ROOM").Rows.Count > 0 Then

                        MNAME_GBL = gdataset.Tables("ROOM").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                    'cbo_PaymentMode.SelectedItem = "ROOM"
                    TT = Split(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDCODE"), "-")
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE DOCNO='" & TT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM1")
                    If gdataset.Tables("ROOM1").Rows.Count > 0 Then
                    Else
                        MsgBox("SORRY USER GUEST CHECKED OUT U CAN NOT GENERATE KOT")
                        MNAME_GBL = ""
                        Me.txt_MemberCode.Text = ""
                        Me.txt_MemberName.Text = ""
                    End If

                End If
                txt_Holder_Code.Enabled = True
                ' cmd_MemberCodeHelp.Enabled = True
                txt_Holder_Code.ReadOnly = False

                txt_Holder_Code.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("cardcode")
                ''If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                ''    Dim CSPLIT() As String
                ''    CSPLIT = Split(Me.txt_Holder_Code.Text, "-")
                ''    SQLSTRING = "SELECT * FROM ROOMCHECKIN WHERE ISNULL(DOCNO,0)='" & CSPLIT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'"
                ''    gconnection.getDataSet(SQLSTRING, "RMC")
                ''    If gdataset.Tables("RMC").Rows.Count > 0 Then
                ''    Else
                ''        MsgBox("ROOM IS CHECKEDOUT U CANNOT USE THE CARD")
                ''        Me.txt_Holder_Code.Text = ""
                ''        Me.txt_MemberCode.Text = ""
                ''        Me.Cmd_Add.Enabled = False
                ''    End If
                ''End If
                Txt_holder_name.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDHOLDERNAME")
                lbl_SwipeCard.Visible = False
                '***********************************New addition for reading datefromcard block
                ''If ACCESS_CHECK_GBL = True Then
                ''    SQLSTRING = "SELECT CARDCODE FROM SM_MEMBERENTRY_LOG WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "' AND CAST(CONVERT(VARCHAR(11),DATETIME,6) AS DATETIME ) = '" & Format(Date.Now, "dd/MMM/yyyy") & "'"
                ''    If Mid(gCompName, 1, 3) = "ALU" Then
                ''        SQLSTRING = "SELECT CARDCODE FROM SM_MEMBERENTRY_LOG WHERE (CARDCODE='" & Trim(txt_Holder_Code.Text) & "' OR MCODE='" & Trim(txt_MemberCode.Text) & "') AND CAST(CONVERT(VARCHAR(11),DATETIME,6) AS DATETIME ) = '" & Format(Date.Now, "dd/MMM/yyyy") & "'"
                ''    End If
                ''    gconnection.getDataSet(SQLSTRING, "SM_MEMBERENTRY_LOG")
                ''    If gdataset.Tables("SM_MEMBERENTRY_LOG").Rows.Count = 0 Then
                ''        MessageBox.Show("SORRY! GET ACCESS AT RECEPTION", "GET ACCESS AT RECEPTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''        txt_card_id.Clear()
                ''        txt_card_id.Focus()
                ''        txt_MemberCode.Clear()
                ''        txt_MemberName.Clear()
                ''        Txt_holder_name.Clear()
                ''        txt_Holder_Code.Clear()
                ''        Exit Function
                ''    End If
                ''End If
                ''CHECKING AND DISPLAYING RECORDS FROM MEMBERMASTER
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    SQLSTRING = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' and curentstatus not in('live','active') "
                    gconnection.getDataSet(SQLSTRING, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")

                        If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OkCancel, "chs") = MsgBoxResult.Ok Then
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        Else
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        End If
                    End If
                End If

                If Trim(Mid(gCompName, 1, 3)) = "TKC" And gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                ElseIf Mid(gCompName, 1, 4) = "BNGV" And gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                ElseIf Mid(gCompName, 1, 3) = "HSR" And gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                ElseIf Mid(gCompName, 1, 4) = "JHIC" And gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                Else
                    txtmcode_Validated(sender, e)
                End If
                'txt_MemberCode_Validated(sender, e)

                SQLSTRING = "select balance,muc_amt from sm_vw_balance  where  CARDCODE='" & Trim(Me.txt_Holder_Code.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "sm_bal")
                If gdataset.Tables("sm_bal").Rows.Count > 0 Then
                    lbl_bal.Text = "CARD BAL.:" & gdataset.Tables("sm_bal").Rows(0).Item("balance")
                    '& "  MUC :" & gdataset.Tables("sm_bal").Rows(0).Item("muc_amt")

                End If

                'ssql = "SELECT * FROM SM_CARDFILE_HDR "
                'gconnection.getDataSet(ssql, "PAY")
                'If gdataset.Tables("PAY").Rows.Count > 0 Then
                '    mcode = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
                '    '' valid = gdataset.Tables("PAY").Rows(0).Item("SMARTVALIDATE")
                'End If


                txt_card_id.ReadOnly = True
            Else
                If cbo_PaymentMode.Text = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    cbo_PaymentMode.Focus()
                End If
            End If
        Catch EX As Exception
            MsgBox("PLEASE GET ACCESS AT RECEPTION USING SPLASH DEVICE..." & EX.Message)
            '   Cmd_Clear_Click(sender, e)
        End Try
    End Function
End Class
