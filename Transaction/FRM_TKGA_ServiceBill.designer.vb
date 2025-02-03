<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_TKGA_ServiceBill
    Inherits System.Windows.Forms.Form
    Public Sub New(ByVal STRPOS As String, ByVal DOCTYP As String)
        '    Public Sub New(ByVal doctypebill As String, ByVal POScodeloc As String, ByVal POSSALESACCTIN As String, ByVal UNDER As String)
        MyBase.New()
        'doctype = doctypebill
        'POScode = POScodeloc
        'SALESACCTIN = POSSALESACCTIN
        'POSUNDER = UNDER
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        StrPOSCODE = STRPOS
        doctype = DOCTYP
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_TKGA_ServiceBill))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grp_Tabledetails = New System.Windows.Forms.GroupBox()
        Me.Cmd_Pos = New System.Windows.Forms.Button()
        Me.Txt_Pos = New System.Windows.Forms.TextBox()
        Me.cmd_TablenoHelp = New System.Windows.Forms.Button()
        Me.TXT_ITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_ServerName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_SubPaymentMode = New System.Windows.Forms.Label()
        Me.cbo_SubPaymentMode = New System.Windows.Forms.ComboBox()
        Me.txt_Cover = New System.Windows.Forms.TextBox()
        Me.txt_TableNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LBL_TRANSNO = New System.Windows.Forms.Label()
        Me.LBL_DOCNO = New System.Windows.Forms.Label()
        Me.CMD_ITEMCODE = New System.Windows.Forms.Button()
        Me.Cmd_Servercode = New System.Windows.Forms.Button()
        Me.cmd_KOTnoHelp = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_ITEMCODE = New System.Windows.Forms.TextBox()
        Me.Txt_ServerCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_PaymentMode = New System.Windows.Forms.Label()
        Me.cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.lbl_KOTno = New System.Windows.Forms.Label()
        Me.txt_KOTno = New System.Windows.Forms.TextBox()
        Me.lbl_KOTdate = New System.Windows.Forms.Label()
        Me.dtp_KOTdate = New System.Windows.Forms.DateTimePicker()
        Me.txt_KOTTime = New System.Windows.Forms.TextBox()
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_BillAmount = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_TaxValue = New System.Windows.Forms.TextBox()
        Me.Txt_Charges = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_Discount = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_TotalValue = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.Lbl_Bill = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmd_BillSettlement = New System.Windows.Forms.Button()
        Me.KOT_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_POSCode = New System.Windows.Forms.Panel()
        Me.lvw_POSCode = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnl_UOMCode = New System.Windows.Forms.Panel()
        Me.lvw_Uom = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SSGRID_MEM = New AxFPSpreadADO.AxfpSpread()
        Me.grp_Paymentmodeselection = New System.Windows.Forms.GroupBox()
        Me.txt_PartialPayment = New System.Windows.Forms.TextBox()
        Me.lbl_PartialPayment = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_Save = New System.Windows.Forms.Button()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Back = New System.Windows.Forms.Button()
        Me.ssgridPayment = New AxFPSpreadADO.AxfpSpread()
        Me.Txt_Remarks = New System.Windows.Forms.TextBox()
        Me.SETLEMENT_GROUP = New System.Windows.Forms.GroupBox()
        Me.LAB_BALANCEAMT = New System.Windows.Forms.Label()
        Me.CMD_SETTLEMENT = New System.Windows.Forms.Button()
        Me.ssgrid_settlement = New AxFPSpreadADO.AxfpSpread()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.grp_Carddetails = New System.Windows.Forms.GroupBox()
        Me.txt_Cardholdername = New System.Windows.Forms.TextBox()
        Me.dtp_Expirydate = New System.Windows.Forms.DateTimePicker()
        Me.txt_Cardno = New System.Windows.Forms.TextBox()
        Me.txt_Typeofcard = New System.Windows.Forms.TextBox()
        Me.lbl_cardholdername = New System.Windows.Forms.Label()
        Me.lbl_Expirydate = New System.Windows.Forms.Label()
        Me.lbl_Cardno = New System.Windows.Forms.Label()
        Me.lbl_Typeofcard = New System.Windows.Forms.Label()
        Me.lbl_Carddetails = New System.Windows.Forms.Label()
        Me.grp_Chequedetails = New System.Windows.Forms.GroupBox()
        Me.cbo_Typeofcheque = New System.Windows.Forms.ComboBox()
        Me.txt_Draweebank = New System.Windows.Forms.TextBox()
        Me.dtp_Chequedate = New System.Windows.Forms.DateTimePicker()
        Me.txt_Chequeno = New System.Windows.Forms.TextBox()
        Me.lbl_Draweebank = New System.Windows.Forms.Label()
        Me.lbl_Chequedate = New System.Windows.Forms.Label()
        Me.lbl_Chequeno = New System.Windows.Forms.Label()
        Me.lbl_Typeofcheque = New System.Windows.Forms.Label()
        Me.lbl_Chequedetails = New System.Windows.Forms.Label()
        Me.lbl_POS = New System.Windows.Forms.Label()
        Me.CHK_PRINT = New System.Windows.Forms.CheckBox()
        Me.grp_Tabledetails.SuspendLayout()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnl_POSCode.SuspendLayout()
        Me.pnl_UOMCode.SuspendLayout()
        CType(Me.SSGRID_MEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Paymentmodeselection.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgridPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SETLEMENT_GROUP.SuspendLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Carddetails.SuspendLayout()
        Me.grp_Chequedetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Service Billing"
        '
        'grp_Tabledetails
        '
        Me.grp_Tabledetails.BackColor = System.Drawing.Color.Transparent
        Me.grp_Tabledetails.Controls.Add(Me.Cmd_Pos)
        Me.grp_Tabledetails.Controls.Add(Me.Txt_Pos)
        Me.grp_Tabledetails.Controls.Add(Me.cmd_TablenoHelp)
        Me.grp_Tabledetails.Controls.Add(Me.TXT_ITEMNAME)
        Me.grp_Tabledetails.Controls.Add(Me.Label10)
        Me.grp_Tabledetails.Controls.Add(Me.Txt_ServerName)
        Me.grp_Tabledetails.Controls.Add(Me.Label6)
        Me.grp_Tabledetails.Controls.Add(Me.lbl_SubPaymentMode)
        Me.grp_Tabledetails.Controls.Add(Me.cbo_SubPaymentMode)
        Me.grp_Tabledetails.Controls.Add(Me.txt_Cover)
        Me.grp_Tabledetails.Controls.Add(Me.txt_TableNo)
        Me.grp_Tabledetails.Controls.Add(Me.Label7)
        Me.grp_Tabledetails.Controls.Add(Me.LBL_TRANSNO)
        Me.grp_Tabledetails.Controls.Add(Me.LBL_DOCNO)
        Me.grp_Tabledetails.Controls.Add(Me.CMD_ITEMCODE)
        Me.grp_Tabledetails.Controls.Add(Me.Cmd_Servercode)
        Me.grp_Tabledetails.Controls.Add(Me.cmd_KOTnoHelp)
        Me.grp_Tabledetails.Controls.Add(Me.Label9)
        Me.grp_Tabledetails.Controls.Add(Me.TXT_ITEMCODE)
        Me.grp_Tabledetails.Controls.Add(Me.Txt_ServerCode)
        Me.grp_Tabledetails.Controls.Add(Me.Label5)
        Me.grp_Tabledetails.Controls.Add(Me.lbl_PaymentMode)
        Me.grp_Tabledetails.Controls.Add(Me.cbo_PaymentMode)
        Me.grp_Tabledetails.Controls.Add(Me.lbl_KOTno)
        Me.grp_Tabledetails.Controls.Add(Me.txt_KOTno)
        Me.grp_Tabledetails.Controls.Add(Me.lbl_KOTdate)
        Me.grp_Tabledetails.Controls.Add(Me.dtp_KOTdate)
        Me.grp_Tabledetails.Controls.Add(Me.txt_KOTTime)
        Me.grp_Tabledetails.Location = New System.Drawing.Point(191, 135)
        Me.grp_Tabledetails.Name = "grp_Tabledetails"
        Me.grp_Tabledetails.Size = New System.Drawing.Size(640, 158)
        Me.grp_Tabledetails.TabIndex = 89
        Me.grp_Tabledetails.TabStop = False
        '
        'Cmd_Pos
        '
        Me.Cmd_Pos.BackgroundImage = CType(resources.GetObject("Cmd_Pos.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Pos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Pos.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Pos.Location = New System.Drawing.Point(275, 89)
        Me.Cmd_Pos.Name = "Cmd_Pos"
        Me.Cmd_Pos.Size = New System.Drawing.Size(32, 23)
        Me.Cmd_Pos.TabIndex = 624
        Me.Cmd_Pos.UseVisualStyleBackColor = True
        '
        'Txt_Pos
        '
        Me.Txt_Pos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Pos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Pos.Location = New System.Drawing.Point(105, 91)
        Me.Txt_Pos.MaxLength = 9
        Me.Txt_Pos.Name = "Txt_Pos"
        Me.Txt_Pos.Size = New System.Drawing.Size(168, 21)
        Me.Txt_Pos.TabIndex = 623
        '
        'cmd_TablenoHelp
        '
        Me.cmd_TablenoHelp.BackgroundImage = CType(resources.GetObject("cmd_TablenoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_TablenoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_TablenoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_TablenoHelp.Location = New System.Drawing.Point(602, 68)
        Me.cmd_TablenoHelp.Name = "cmd_TablenoHelp"
        Me.cmd_TablenoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_TablenoHelp.TabIndex = 622
        Me.cmd_TablenoHelp.UseVisualStyleBackColor = True
        Me.cmd_TablenoHelp.Visible = False
        '
        'TXT_ITEMNAME
        '
        Me.TXT_ITEMNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_ITEMNAME.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ITEMNAME.Location = New System.Drawing.Point(429, 119)
        Me.TXT_ITEMNAME.MaxLength = 9
        Me.TXT_ITEMNAME.Name = "TXT_ITEMNAME"
        Me.TXT_ITEMNAME.Size = New System.Drawing.Size(169, 21)
        Me.TXT_ITEMNAME.TabIndex = 620
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(330, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 15)
        Me.Label10.TabIndex = 621
        Me.Label10.Text = "Item Name"
        '
        'Txt_ServerName
        '
        Me.Txt_ServerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ServerName.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ServerName.Location = New System.Drawing.Point(429, 92)
        Me.Txt_ServerName.MaxLength = 9
        Me.Txt_ServerName.Name = "Txt_ServerName"
        Me.Txt_ServerName.Size = New System.Drawing.Size(169, 21)
        Me.Txt_ServerName.TabIndex = 618
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(327, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 619
        Me.Label6.Text = "Waiter Name"
        '
        'lbl_SubPaymentMode
        '
        Me.lbl_SubPaymentMode.AutoSize = True
        Me.lbl_SubPaymentMode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SubPaymentMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubPaymentMode.ForeColor = System.Drawing.Color.Black
        Me.lbl_SubPaymentMode.Location = New System.Drawing.Point(327, 68)
        Me.lbl_SubPaymentMode.Name = "lbl_SubPaymentMode"
        Me.lbl_SubPaymentMode.Size = New System.Drawing.Size(83, 15)
        Me.lbl_SubPaymentMode.TabIndex = 616
        Me.lbl_SubPaymentMode.Text = "Member Type"
        Me.lbl_SubPaymentMode.Visible = False
        '
        'cbo_SubPaymentMode
        '
        Me.cbo_SubPaymentMode.BackColor = System.Drawing.Color.White
        Me.cbo_SubPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_SubPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_SubPaymentMode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_SubPaymentMode.Location = New System.Drawing.Point(428, 66)
        Me.cbo_SubPaymentMode.Name = "cbo_SubPaymentMode"
        Me.cbo_SubPaymentMode.Size = New System.Drawing.Size(169, 23)
        Me.cbo_SubPaymentMode.TabIndex = 617
        Me.cbo_SubPaymentMode.Visible = False
        '
        'txt_Cover
        '
        Me.txt_Cover.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Cover.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cover.Location = New System.Drawing.Point(428, 39)
        Me.txt_Cover.MaxLength = 9
        Me.txt_Cover.Name = "txt_Cover"
        Me.txt_Cover.Size = New System.Drawing.Size(169, 21)
        Me.txt_Cover.TabIndex = 614
        Me.txt_Cover.Visible = False
        '
        'txt_TableNo
        '
        Me.txt_TableNo.BackColor = System.Drawing.Color.White
        Me.txt_TableNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TableNo.Location = New System.Drawing.Point(428, 39)
        Me.txt_TableNo.MaxLength = 10
        Me.txt_TableNo.Name = "txt_TableNo"
        Me.txt_TableNo.Size = New System.Drawing.Size(168, 21)
        Me.txt_TableNo.TabIndex = 615
        Me.txt_TableNo.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(327, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 613
        Me.Label7.Text = "Transaction No"
        '
        'LBL_TRANSNO
        '
        Me.LBL_TRANSNO.AutoSize = True
        Me.LBL_TRANSNO.BackColor = System.Drawing.Color.Transparent
        Me.LBL_TRANSNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TRANSNO.ForeColor = System.Drawing.Color.Black
        Me.LBL_TRANSNO.Location = New System.Drawing.Point(439, 17)
        Me.LBL_TRANSNO.Name = "LBL_TRANSNO"
        Me.LBL_TRANSNO.Size = New System.Drawing.Size(39, 15)
        Me.LBL_TRANSNO.TabIndex = 611
        Me.LBL_TRANSNO.Text = "Trans"
        '
        'LBL_DOCNO
        '
        Me.LBL_DOCNO.AutoSize = True
        Me.LBL_DOCNO.BackColor = System.Drawing.Color.Transparent
        Me.LBL_DOCNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_DOCNO.ForeColor = System.Drawing.Color.Black
        Me.LBL_DOCNO.Location = New System.Drawing.Point(511, 16)
        Me.LBL_DOCNO.Name = "LBL_DOCNO"
        Me.LBL_DOCNO.Size = New System.Drawing.Size(44, 15)
        Me.LBL_DOCNO.TabIndex = 612
        Me.LBL_DOCNO.Text = "DocNo"
        '
        'CMD_ITEMCODE
        '
        Me.CMD_ITEMCODE.BackgroundImage = CType(resources.GetObject("CMD_ITEMCODE.BackgroundImage"), System.Drawing.Image)
        Me.CMD_ITEMCODE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMD_ITEMCODE.DialogResult = System.Windows.Forms.DialogResult.No
        Me.CMD_ITEMCODE.Location = New System.Drawing.Point(276, 113)
        Me.CMD_ITEMCODE.Name = "CMD_ITEMCODE"
        Me.CMD_ITEMCODE.Size = New System.Drawing.Size(32, 23)
        Me.CMD_ITEMCODE.TabIndex = 610
        Me.CMD_ITEMCODE.UseVisualStyleBackColor = True
        '
        'Cmd_Servercode
        '
        Me.Cmd_Servercode.BackgroundImage = CType(resources.GetObject("Cmd_Servercode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Servercode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Servercode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Servercode.Location = New System.Drawing.Point(276, 88)
        Me.Cmd_Servercode.Name = "Cmd_Servercode"
        Me.Cmd_Servercode.Size = New System.Drawing.Size(32, 23)
        Me.Cmd_Servercode.TabIndex = 609
        Me.Cmd_Servercode.UseVisualStyleBackColor = True
        Me.Cmd_Servercode.Visible = False
        '
        'cmd_KOTnoHelp
        '
        Me.cmd_KOTnoHelp.BackgroundImage = CType(resources.GetObject("cmd_KOTnoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_KOTnoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_KOTnoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_KOTnoHelp.Location = New System.Drawing.Point(275, 16)
        Me.cmd_KOTnoHelp.Name = "cmd_KOTnoHelp"
        Me.cmd_KOTnoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_KOTnoHelp.TabIndex = 608
        Me.cmd_KOTnoHelp.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(10, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 607
        Me.Label9.Text = "ItemCode"
        '
        'TXT_ITEMCODE
        '
        Me.TXT_ITEMCODE.BackColor = System.Drawing.Color.White
        Me.TXT_ITEMCODE.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ITEMCODE.Location = New System.Drawing.Point(106, 114)
        Me.TXT_ITEMCODE.MaxLength = 10
        Me.TXT_ITEMCODE.Name = "TXT_ITEMCODE"
        Me.TXT_ITEMCODE.Size = New System.Drawing.Size(168, 21)
        Me.TXT_ITEMCODE.TabIndex = 605
        '
        'Txt_ServerCode
        '
        Me.Txt_ServerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ServerCode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ServerCode.Location = New System.Drawing.Point(106, 90)
        Me.Txt_ServerCode.MaxLength = 9
        Me.Txt_ServerCode.Name = "Txt_ServerCode"
        Me.Txt_ServerCode.Size = New System.Drawing.Size(168, 21)
        Me.Txt_ServerCode.TabIndex = 2
        Me.Txt_ServerCode.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 601
        Me.Label5.Text = "POS Location"
        '
        'lbl_PaymentMode
        '
        Me.lbl_PaymentMode.AutoSize = True
        Me.lbl_PaymentMode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_PaymentMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PaymentMode.ForeColor = System.Drawing.Color.Black
        Me.lbl_PaymentMode.Location = New System.Drawing.Point(8, 68)
        Me.lbl_PaymentMode.Name = "lbl_PaymentMode"
        Me.lbl_PaymentMode.Size = New System.Drawing.Size(91, 15)
        Me.lbl_PaymentMode.TabIndex = 599
        Me.lbl_PaymentMode.Text = "Payment Mode"
        '
        'cbo_PaymentMode
        '
        Me.cbo_PaymentMode.BackColor = System.Drawing.Color.White
        Me.cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_PaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_PaymentMode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_PaymentMode.Location = New System.Drawing.Point(106, 64)
        Me.cbo_PaymentMode.Name = "cbo_PaymentMode"
        Me.cbo_PaymentMode.Size = New System.Drawing.Size(160, 23)
        Me.cbo_PaymentMode.TabIndex = 1
        '
        'lbl_KOTno
        '
        Me.lbl_KOTno.AutoSize = True
        Me.lbl_KOTno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KOTno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KOTno.ForeColor = System.Drawing.Color.Black
        Me.lbl_KOTno.Location = New System.Drawing.Point(8, 16)
        Me.lbl_KOTno.Name = "lbl_KOTno"
        Me.lbl_KOTno.Size = New System.Drawing.Size(70, 15)
        Me.lbl_KOTno.TabIndex = 27
        Me.lbl_KOTno.Text = "Service Bill"
        '
        'txt_KOTno
        '
        Me.txt_KOTno.BackColor = System.Drawing.Color.Wheat
        Me.txt_KOTno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_KOTno.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTno.Location = New System.Drawing.Point(106, 16)
        Me.txt_KOTno.Name = "txt_KOTno"
        Me.txt_KOTno.Size = New System.Drawing.Size(164, 21)
        Me.txt_KOTno.TabIndex = 602
        '
        'lbl_KOTdate
        '
        Me.lbl_KOTdate.AutoSize = True
        Me.lbl_KOTdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KOTdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KOTdate.ForeColor = System.Drawing.Color.Black
        Me.lbl_KOTdate.Location = New System.Drawing.Point(8, 42)
        Me.lbl_KOTdate.Name = "lbl_KOTdate"
        Me.lbl_KOTdate.Size = New System.Drawing.Size(79, 15)
        Me.lbl_KOTdate.TabIndex = 28
        Me.lbl_KOTdate.Text = "Service Date"
        '
        'dtp_KOTdate
        '
        Me.dtp_KOTdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_KOTdate.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_KOTdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_KOTdate.Location = New System.Drawing.Point(106, 40)
        Me.dtp_KOTdate.Name = "dtp_KOTdate"
        Me.dtp_KOTdate.Size = New System.Drawing.Size(104, 21)
        Me.dtp_KOTdate.TabIndex = 0
        '
        'txt_KOTTime
        '
        Me.txt_KOTTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KOTTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_KOTTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTTime.Location = New System.Drawing.Point(216, 40)
        Me.txt_KOTTime.Name = "txt_KOTTime"
        Me.txt_KOTTime.ReadOnly = True
        Me.txt_KOTTime.Size = New System.Drawing.Size(69, 21)
        Me.txt_KOTTime.TabIndex = 30
        '
        'ssGrid
        '
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(221, 298)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(582, 166)
        Me.ssGrid.TabIndex = 90
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txt_BillAmount)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txt_TaxValue)
        Me.Panel3.Controls.Add(Me.Txt_Charges)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txt_Discount)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txt_TotalValue)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(563, 476)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 130)
        Me.Panel3.TabIndex = 630
        '
        'txt_BillAmount
        '
        Me.txt_BillAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_BillAmount.Location = New System.Drawing.Point(117, 103)
        Me.txt_BillAmount.Name = "txt_BillAmount"
        Me.txt_BillAmount.Size = New System.Drawing.Size(111, 20)
        Me.txt_BillAmount.TabIndex = 121
        Me.txt_BillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 15)
        Me.Label17.TabIndex = 120
        Me.Label17.Text = "Bill Amount"
        '
        'txt_TaxValue
        '
        Me.txt_TaxValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TaxValue.Location = New System.Drawing.Point(118, 78)
        Me.txt_TaxValue.Name = "txt_TaxValue"
        Me.txt_TaxValue.Size = New System.Drawing.Size(111, 20)
        Me.txt_TaxValue.TabIndex = 119
        Me.txt_TaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Charges
        '
        Me.Txt_Charges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Charges.Location = New System.Drawing.Point(118, 53)
        Me.Txt_Charges.Name = "Txt_Charges"
        Me.Txt_Charges.Size = New System.Drawing.Size(111, 20)
        Me.Txt_Charges.TabIndex = 117
        Me.Txt_Charges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 15)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Tax Amount"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 15)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Charges Amount"
        '
        'txt_Discount
        '
        Me.txt_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Discount.Location = New System.Drawing.Point(118, 29)
        Me.txt_Discount.Name = "txt_Discount"
        Me.txt_Discount.Size = New System.Drawing.Size(111, 20)
        Me.txt_Discount.TabIndex = 115
        Me.txt_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Discount.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 15)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Discount Amount"
        Me.Label14.Visible = False
        '
        'txt_TotalValue
        '
        Me.txt_TotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalValue.Location = New System.Drawing.Point(118, 5)
        Me.txt_TotalValue.Name = "txt_TotalValue"
        Me.txt_TotalValue.Size = New System.Drawing.Size(111, 20)
        Me.txt_TotalValue.TabIndex = 113
        Me.txt_TotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 15)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Total Amount"
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.ForeColor = System.Drawing.Color.Black
        Me.lbl_Remarks.Location = New System.Drawing.Point(217, 476)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(88, 18)
        Me.lbl_Remarks.TabIndex = 632
        Me.lbl_Remarks.Text = "REMARKS:"
        Me.lbl_Remarks.Visible = False
        '
        'Lbl_Bill
        '
        Me.Lbl_Bill.AutoSize = True
        Me.Lbl_Bill.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Bill.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Bill.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Bill.Location = New System.Drawing.Point(215, 504)
        Me.Lbl_Bill.Name = "Lbl_Bill"
        Me.Lbl_Bill.Size = New System.Drawing.Size(36, 15)
        Me.Lbl_Bill.TabIndex = 633
        Me.Lbl_Bill.Text = "BILL"
        Me.Lbl_Bill.Visible = False
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Status.Location = New System.Drawing.Point(213, 530)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(85, 15)
        Me.lbl_Status.TabIndex = 634
        Me.lbl_Status.Text = "BILL STATUS"
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Status.Visible = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(860, 497)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Exit.TabIndex = 648
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(860, 441)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Export.TabIndex = 647
        Me.Cmd_Export.Text = "Browse [F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(860, 385)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Print.TabIndex = 646
        Me.Cmd_Print.Text = "Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = True
        '
        'Cmd_View
        '
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(860, 329)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_View.TabIndex = 645
        Me.Cmd_View.Text = "View [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = True
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(860, 273)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Delete.TabIndex = 644
        Me.Cmd_Delete.Text = "Delete [F8]"
        Me.Cmd_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Delete.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(860, 161)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Clear.TabIndex = 643
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(860, 217)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Add.TabIndex = 642
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'cmd_BillSettlement
        '
        Me.cmd_BillSettlement.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_BillSettlement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_BillSettlement.Location = New System.Drawing.Point(860, 553)
        Me.cmd_BillSettlement.Name = "cmd_BillSettlement"
        Me.cmd_BillSettlement.Size = New System.Drawing.Size(145, 53)
        Me.cmd_BillSettlement.TabIndex = 649
        Me.cmd_BillSettlement.Text = "Bill Settle [F5]"
        Me.cmd_BillSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_BillSettlement.UseVisualStyleBackColor = True
        '
        'KOT_Timer
        '
        '
        'pnl_POSCode
        '
        Me.pnl_POSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_POSCode.Controls.Add(Me.lvw_POSCode)
        Me.pnl_POSCode.Location = New System.Drawing.Point(80, 1000)
        Me.pnl_POSCode.Name = "pnl_POSCode"
        Me.pnl_POSCode.Size = New System.Drawing.Size(269, 119)
        Me.pnl_POSCode.TabIndex = 650
        '
        'lvw_POSCode
        '
        Me.lvw_POSCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.lvw_POSCode.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_POSCode.FullRowSelect = True
        Me.lvw_POSCode.GridLines = True
        Me.lvw_POSCode.HideSelection = False
        Me.lvw_POSCode.HoverSelection = True
        Me.lvw_POSCode.Location = New System.Drawing.Point(0, 0)
        Me.lvw_POSCode.Name = "lvw_POSCode"
        Me.lvw_POSCode.Scrollable = False
        Me.lvw_POSCode.Size = New System.Drawing.Size(263, 135)
        Me.lvw_POSCode.TabIndex = 0
        Me.lvw_POSCode.UseCompatibleStateImageBehavior = False
        Me.lvw_POSCode.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "POS Code"
        Me.ColumnHeader1.Width = 121
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "POS Desc"
        Me.ColumnHeader3.Width = 133
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Account In"
        Me.ColumnHeader5.Width = 110
        '
        'pnl_UOMCode
        '
        Me.pnl_UOMCode.BackgroundImage = CType(resources.GetObject("pnl_UOMCode.BackgroundImage"), System.Drawing.Image)
        Me.pnl_UOMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_UOMCode.Controls.Add(Me.lvw_Uom)
        Me.pnl_UOMCode.Location = New System.Drawing.Point(496, 1000)
        Me.pnl_UOMCode.Name = "pnl_UOMCode"
        Me.pnl_UOMCode.Size = New System.Drawing.Size(261, 120)
        Me.pnl_UOMCode.TabIndex = 651
        '
        'lvw_Uom
        '
        Me.lvw_Uom.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvw_Uom.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_Uom.FullRowSelect = True
        Me.lvw_Uom.GridLines = True
        Me.lvw_Uom.HoverSelection = True
        Me.lvw_Uom.Location = New System.Drawing.Point(3, 0)
        Me.lvw_Uom.Name = "lvw_Uom"
        Me.lvw_Uom.Size = New System.Drawing.Size(257, 119)
        Me.lvw_Uom.TabIndex = 0
        Me.lvw_Uom.UseCompatibleStateImageBehavior = False
        Me.lvw_Uom.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "UOM Code"
        Me.ColumnHeader2.Width = 114
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "UOM Rate"
        Me.ColumnHeader4.Width = 131
        '
        'SSGRID_MEM
        '
        Me.SSGRID_MEM.DataSource = Nothing
        Me.SSGRID_MEM.Location = New System.Drawing.Point(226, 420)
        Me.SSGRID_MEM.Name = "SSGRID_MEM"
        Me.SSGRID_MEM.OcxState = CType(resources.GetObject("SSGRID_MEM.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_MEM.Size = New System.Drawing.Size(312, 40)
        Me.SSGRID_MEM.TabIndex = 652
        Me.SSGRID_MEM.Visible = False
        '
        'grp_Paymentmodeselection
        '
        Me.grp_Paymentmodeselection.Controls.Add(Me.txt_PartialPayment)
        Me.grp_Paymentmodeselection.Controls.Add(Me.lbl_PartialPayment)
        Me.grp_Paymentmodeselection.Controls.Add(Me.GroupBox1)
        Me.grp_Paymentmodeselection.Controls.Add(Me.ssgridPayment)
        Me.grp_Paymentmodeselection.Location = New System.Drawing.Point(81, 1000)
        Me.grp_Paymentmodeselection.Name = "grp_Paymentmodeselection"
        Me.grp_Paymentmodeselection.Size = New System.Drawing.Size(652, 239)
        Me.grp_Paymentmodeselection.TabIndex = 653
        Me.grp_Paymentmodeselection.TabStop = False
        '
        'txt_PartialPayment
        '
        Me.txt_PartialPayment.BackColor = System.Drawing.Color.Wheat
        Me.txt_PartialPayment.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PartialPayment.Location = New System.Drawing.Point(225, 136)
        Me.txt_PartialPayment.MaxLength = 12
        Me.txt_PartialPayment.Name = "txt_PartialPayment"
        Me.txt_PartialPayment.ReadOnly = True
        Me.txt_PartialPayment.Size = New System.Drawing.Size(192, 29)
        Me.txt_PartialPayment.TabIndex = 42
        Me.txt_PartialPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_PartialPayment
        '
        Me.lbl_PartialPayment.AutoSize = True
        Me.lbl_PartialPayment.BackColor = System.Drawing.Color.Transparent
        Me.lbl_PartialPayment.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PartialPayment.Location = New System.Drawing.Point(58, 136)
        Me.lbl_PartialPayment.Name = "lbl_PartialPayment"
        Me.lbl_PartialPayment.Size = New System.Drawing.Size(153, 22)
        Me.lbl_PartialPayment.TabIndex = 41
        Me.lbl_PartialPayment.Text = "BILL AMOUNT :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_Save)
        Me.GroupBox1.Controls.Add(Me.cmd_Cancel)
        Me.GroupBox1.Controls.Add(Me.cmd_Back)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 172)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 53)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'cmd_Save
        '
        Me.cmd_Save.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Save.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Save.ForeColor = System.Drawing.Color.White
        Me.cmd_Save.Image = CType(resources.GetObject("cmd_Save.Image"), System.Drawing.Image)
        Me.cmd_Save.Location = New System.Drawing.Point(144, 16)
        Me.cmd_Save.Name = "cmd_Save"
        Me.cmd_Save.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Save.TabIndex = 1
        Me.cmd_Save.Text = "SAVE"
        Me.cmd_Save.UseVisualStyleBackColor = False
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Cancel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancel.ForeColor = System.Drawing.Color.White
        Me.cmd_Cancel.Image = CType(resources.GetObject("cmd_Cancel.Image"), System.Drawing.Image)
        Me.cmd_Cancel.Location = New System.Drawing.Point(264, 16)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Cancel.TabIndex = 2
        Me.cmd_Cancel.Text = "CLEAR"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'cmd_Back
        '
        Me.cmd_Back.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Back.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Back.ForeColor = System.Drawing.Color.White
        Me.cmd_Back.Image = CType(resources.GetObject("cmd_Back.Image"), System.Drawing.Image)
        Me.cmd_Back.Location = New System.Drawing.Point(24, 14)
        Me.cmd_Back.Name = "cmd_Back"
        Me.cmd_Back.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Back.TabIndex = 0
        Me.cmd_Back.Text = "BACK"
        Me.cmd_Back.UseVisualStyleBackColor = False
        '
        'ssgridPayment
        '
        Me.ssgridPayment.DataSource = Nothing
        Me.ssgridPayment.Location = New System.Drawing.Point(33, 31)
        Me.ssgridPayment.Name = "ssgridPayment"
        Me.ssgridPayment.OcxState = CType(resources.GetObject("ssgridPayment.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgridPayment.Size = New System.Drawing.Size(576, 84)
        Me.ssgridPayment.TabIndex = 0
        '
        'Txt_Remarks
        '
        Me.Txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Remarks.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Remarks.ForeColor = System.Drawing.Color.Red
        Me.Txt_Remarks.Location = New System.Drawing.Point(306, 476)
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(248, 22)
        Me.Txt_Remarks.TabIndex = 654
        '
        'SETLEMENT_GROUP
        '
        Me.SETLEMENT_GROUP.Controls.Add(Me.LAB_BALANCEAMT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.CMD_SETTLEMENT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.ssgrid_settlement)
        Me.SETLEMENT_GROUP.Controls.Add(Me.Label2)
        Me.SETLEMENT_GROUP.Location = New System.Drawing.Point(112, 728)
        Me.SETLEMENT_GROUP.Name = "SETLEMENT_GROUP"
        Me.SETLEMENT_GROUP.Size = New System.Drawing.Size(388, 216)
        Me.SETLEMENT_GROUP.TabIndex = 655
        Me.SETLEMENT_GROUP.TabStop = False
        '
        'LAB_BALANCEAMT
        '
        Me.LAB_BALANCEAMT.AutoSize = True
        Me.LAB_BALANCEAMT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAB_BALANCEAMT.ForeColor = System.Drawing.Color.Maroon
        Me.LAB_BALANCEAMT.Location = New System.Drawing.Point(194, 167)
        Me.LAB_BALANCEAMT.Name = "LAB_BALANCEAMT"
        Me.LAB_BALANCEAMT.Size = New System.Drawing.Size(180, 18)
        Me.LAB_BALANCEAMT.TabIndex = 624
        Me.LAB_BALANCEAMT.Text = "BALANCE AMOUNT:"
        '
        'CMD_SETTLEMENT
        '
        Me.CMD_SETTLEMENT.Location = New System.Drawing.Point(15, 162)
        Me.CMD_SETTLEMENT.Name = "CMD_SETTLEMENT"
        Me.CMD_SETTLEMENT.Size = New System.Drawing.Size(99, 25)
        Me.CMD_SETTLEMENT.TabIndex = 623
        Me.CMD_SETTLEMENT.Text = "SETTLEMENT"
        Me.CMD_SETTLEMENT.UseVisualStyleBackColor = True
        '
        'ssgrid_settlement
        '
        Me.ssgrid_settlement.DataSource = Nothing
        Me.ssgrid_settlement.Location = New System.Drawing.Point(16, 48)
        Me.ssgrid_settlement.Name = "ssgrid_settlement"
        Me.ssgrid_settlement.OcxState = CType(resources.GetObject("ssgrid_settlement.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_settlement.Size = New System.Drawing.Size(337, 99)
        Me.ssgrid_settlement.TabIndex = 622
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(132, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 19)
        Me.Label2.TabIndex = 621
        Me.Label2.Text = "SETTLEMENT"
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.Gainsboro
        Me.lblUser.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(196, 113)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(115, 21)
        Me.lblUser.TabIndex = 656
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Carddetails
        '
        Me.grp_Carddetails.Controls.Add(Me.txt_Cardholdername)
        Me.grp_Carddetails.Controls.Add(Me.dtp_Expirydate)
        Me.grp_Carddetails.Controls.Add(Me.txt_Cardno)
        Me.grp_Carddetails.Controls.Add(Me.txt_Typeofcard)
        Me.grp_Carddetails.Controls.Add(Me.lbl_cardholdername)
        Me.grp_Carddetails.Controls.Add(Me.lbl_Expirydate)
        Me.grp_Carddetails.Controls.Add(Me.lbl_Cardno)
        Me.grp_Carddetails.Controls.Add(Me.lbl_Typeofcard)
        Me.grp_Carddetails.Controls.Add(Me.lbl_Carddetails)
        Me.grp_Carddetails.Location = New System.Drawing.Point(147, 1000)
        Me.grp_Carddetails.Name = "grp_Carddetails"
        Me.grp_Carddetails.Size = New System.Drawing.Size(368, 160)
        Me.grp_Carddetails.TabIndex = 657
        Me.grp_Carddetails.TabStop = False
        '
        'txt_Cardholdername
        '
        Me.txt_Cardholdername.BackColor = System.Drawing.Color.Wheat
        Me.txt_Cardholdername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Cardholdername.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cardholdername.Location = New System.Drawing.Point(184, 126)
        Me.txt_Cardholdername.MaxLength = 35
        Me.txt_Cardholdername.Name = "txt_Cardholdername"
        Me.txt_Cardholdername.Size = New System.Drawing.Size(168, 25)
        Me.txt_Cardholdername.TabIndex = 3
        '
        'dtp_Expirydate
        '
        Me.dtp_Expirydate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Expirydate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Expirydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Expirydate.Location = New System.Drawing.Point(184, 96)
        Me.dtp_Expirydate.Name = "dtp_Expirydate"
        Me.dtp_Expirydate.Size = New System.Drawing.Size(168, 25)
        Me.dtp_Expirydate.TabIndex = 2
        '
        'txt_Cardno
        '
        Me.txt_Cardno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Cardno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Cardno.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cardno.Location = New System.Drawing.Point(184, 66)
        Me.txt_Cardno.MaxLength = 20
        Me.txt_Cardno.Name = "txt_Cardno"
        Me.txt_Cardno.Size = New System.Drawing.Size(168, 25)
        Me.txt_Cardno.TabIndex = 1
        '
        'txt_Typeofcard
        '
        Me.txt_Typeofcard.BackColor = System.Drawing.Color.Wheat
        Me.txt_Typeofcard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Typeofcard.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Typeofcard.Location = New System.Drawing.Point(184, 37)
        Me.txt_Typeofcard.MaxLength = 20
        Me.txt_Typeofcard.Name = "txt_Typeofcard"
        Me.txt_Typeofcard.Size = New System.Drawing.Size(168, 25)
        Me.txt_Typeofcard.TabIndex = 0
        '
        'lbl_cardholdername
        '
        Me.lbl_cardholdername.AutoSize = True
        Me.lbl_cardholdername.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cardholdername.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cardholdername.Location = New System.Drawing.Point(8, 128)
        Me.lbl_cardholdername.Name = "lbl_cardholdername"
        Me.lbl_cardholdername.Size = New System.Drawing.Size(170, 17)
        Me.lbl_cardholdername.TabIndex = 8
        Me.lbl_cardholdername.Text = "CARD HOLDER NAME :"
        '
        'lbl_Expirydate
        '
        Me.lbl_Expirydate.AutoSize = True
        Me.lbl_Expirydate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Expirydate.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Expirydate.Location = New System.Drawing.Point(54, 102)
        Me.lbl_Expirydate.Name = "lbl_Expirydate"
        Me.lbl_Expirydate.Size = New System.Drawing.Size(125, 17)
        Me.lbl_Expirydate.TabIndex = 7
        Me.lbl_Expirydate.Text = "EXPIRY DATE :"
        '
        'lbl_Cardno
        '
        Me.lbl_Cardno.AutoSize = True
        Me.lbl_Cardno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Cardno.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cardno.Location = New System.Drawing.Point(91, 71)
        Me.lbl_Cardno.Name = "lbl_Cardno"
        Me.lbl_Cardno.Size = New System.Drawing.Size(89, 17)
        Me.lbl_Cardno.TabIndex = 6
        Me.lbl_Cardno.Text = "CARD NO :"
        '
        'lbl_Typeofcard
        '
        Me.lbl_Typeofcard.AutoSize = True
        Me.lbl_Typeofcard.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Typeofcard.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Typeofcard.Location = New System.Drawing.Point(45, 40)
        Me.lbl_Typeofcard.Name = "lbl_Typeofcard"
        Me.lbl_Typeofcard.Size = New System.Drawing.Size(134, 17)
        Me.lbl_Typeofcard.TabIndex = 5
        Me.lbl_Typeofcard.Text = "TYPE OF CARD :"
        '
        'lbl_Carddetails
        '
        Me.lbl_Carddetails.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Carddetails.ForeColor = System.Drawing.Color.White
        Me.lbl_Carddetails.Location = New System.Drawing.Point(0, 8)
        Me.lbl_Carddetails.Name = "lbl_Carddetails"
        Me.lbl_Carddetails.Size = New System.Drawing.Size(368, 24)
        Me.lbl_Carddetails.TabIndex = 4
        Me.lbl_Carddetails.Text = "CARD DETAILS :"
        '
        'grp_Chequedetails
        '
        Me.grp_Chequedetails.Controls.Add(Me.cbo_Typeofcheque)
        Me.grp_Chequedetails.Controls.Add(Me.txt_Draweebank)
        Me.grp_Chequedetails.Controls.Add(Me.dtp_Chequedate)
        Me.grp_Chequedetails.Controls.Add(Me.txt_Chequeno)
        Me.grp_Chequedetails.Controls.Add(Me.lbl_Draweebank)
        Me.grp_Chequedetails.Controls.Add(Me.lbl_Chequedate)
        Me.grp_Chequedetails.Controls.Add(Me.lbl_Chequeno)
        Me.grp_Chequedetails.Controls.Add(Me.lbl_Typeofcheque)
        Me.grp_Chequedetails.Controls.Add(Me.lbl_Chequedetails)
        Me.grp_Chequedetails.Location = New System.Drawing.Point(178, 1000)
        Me.grp_Chequedetails.Name = "grp_Chequedetails"
        Me.grp_Chequedetails.Size = New System.Drawing.Size(370, 164)
        Me.grp_Chequedetails.TabIndex = 658
        Me.grp_Chequedetails.TabStop = False
        '
        'cbo_Typeofcheque
        '
        Me.cbo_Typeofcheque.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Typeofcheque.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Typeofcheque.Items.AddRange(New Object() {"PO", "DD", "CHEQUE"})
        Me.cbo_Typeofcheque.Location = New System.Drawing.Point(184, 38)
        Me.cbo_Typeofcheque.Name = "cbo_Typeofcheque"
        Me.cbo_Typeofcheque.Size = New System.Drawing.Size(168, 25)
        Me.cbo_Typeofcheque.TabIndex = 0
        '
        'txt_Draweebank
        '
        Me.txt_Draweebank.BackColor = System.Drawing.Color.Wheat
        Me.txt_Draweebank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Draweebank.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Draweebank.Location = New System.Drawing.Point(184, 126)
        Me.txt_Draweebank.MaxLength = 20
        Me.txt_Draweebank.Name = "txt_Draweebank"
        Me.txt_Draweebank.Size = New System.Drawing.Size(168, 25)
        Me.txt_Draweebank.TabIndex = 3
        '
        'dtp_Chequedate
        '
        Me.dtp_Chequedate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Chequedate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Chequedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Chequedate.Location = New System.Drawing.Point(184, 96)
        Me.dtp_Chequedate.Name = "dtp_Chequedate"
        Me.dtp_Chequedate.Size = New System.Drawing.Size(168, 25)
        Me.dtp_Chequedate.TabIndex = 2
        '
        'txt_Chequeno
        '
        Me.txt_Chequeno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Chequeno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Chequeno.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Chequeno.Location = New System.Drawing.Point(184, 66)
        Me.txt_Chequeno.MaxLength = 20
        Me.txt_Chequeno.Name = "txt_Chequeno"
        Me.txt_Chequeno.Size = New System.Drawing.Size(168, 25)
        Me.txt_Chequeno.TabIndex = 1
        '
        'lbl_Draweebank
        '
        Me.lbl_Draweebank.AutoSize = True
        Me.lbl_Draweebank.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Draweebank.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Draweebank.Location = New System.Drawing.Point(40, 127)
        Me.lbl_Draweebank.Name = "lbl_Draweebank"
        Me.lbl_Draweebank.Size = New System.Drawing.Size(125, 17)
        Me.lbl_Draweebank.TabIndex = 8
        Me.lbl_Draweebank.Text = "DRAWEE BANK :"
        '
        'lbl_Chequedate
        '
        Me.lbl_Chequedate.AutoSize = True
        Me.lbl_Chequedate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Chequedate.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Chequedate.Location = New System.Drawing.Point(40, 98)
        Me.lbl_Chequedate.Name = "lbl_Chequedate"
        Me.lbl_Chequedate.Size = New System.Drawing.Size(125, 17)
        Me.lbl_Chequedate.TabIndex = 7
        Me.lbl_Chequedate.Text = "CHEQUE DATE :"
        '
        'lbl_Chequeno
        '
        Me.lbl_Chequeno.AutoSize = True
        Me.lbl_Chequeno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Chequeno.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Chequeno.Location = New System.Drawing.Point(59, 69)
        Me.lbl_Chequeno.Name = "lbl_Chequeno"
        Me.lbl_Chequeno.Size = New System.Drawing.Size(107, 17)
        Me.lbl_Chequeno.TabIndex = 6
        Me.lbl_Chequeno.Text = "CHEQUE NO :"
        '
        'lbl_Typeofcheque
        '
        Me.lbl_Typeofcheque.AutoSize = True
        Me.lbl_Typeofcheque.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Typeofcheque.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Typeofcheque.Location = New System.Drawing.Point(12, 40)
        Me.lbl_Typeofcheque.Name = "lbl_Typeofcheque"
        Me.lbl_Typeofcheque.Size = New System.Drawing.Size(152, 17)
        Me.lbl_Typeofcheque.TabIndex = 5
        Me.lbl_Typeofcheque.Text = "TYPE OF CHEQUE :"
        '
        'lbl_Chequedetails
        '
        Me.lbl_Chequedetails.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Chequedetails.ForeColor = System.Drawing.Color.White
        Me.lbl_Chequedetails.Location = New System.Drawing.Point(0, 8)
        Me.lbl_Chequedetails.Name = "lbl_Chequedetails"
        Me.lbl_Chequedetails.Size = New System.Drawing.Size(368, 24)
        Me.lbl_Chequedetails.TabIndex = 4
        Me.lbl_Chequedetails.Text = "CHEQUE DETAILS :"
        '
        'lbl_POS
        '
        Me.lbl_POS.AutoSize = True
        Me.lbl_POS.BackColor = System.Drawing.Color.Transparent
        Me.lbl_POS.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_POS.ForeColor = System.Drawing.Color.Black
        Me.lbl_POS.Location = New System.Drawing.Point(314, 113)
        Me.lbl_POS.Name = "lbl_POS"
        Me.lbl_POS.Size = New System.Drawing.Size(87, 22)
        Me.lbl_POS.TabIndex = 659
        Me.lbl_POS.Text = "COVERS "
        Me.lbl_POS.Visible = False
        '
        'CHK_PRINT
        '
        Me.CHK_PRINT.BackColor = System.Drawing.Color.Transparent
        Me.CHK_PRINT.Checked = True
        Me.CHK_PRINT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_PRINT.Location = New System.Drawing.Point(774, 111)
        Me.CHK_PRINT.Name = "CHK_PRINT"
        Me.CHK_PRINT.Size = New System.Drawing.Size(57, 24)
        Me.CHK_PRINT.TabIndex = 660
        Me.CHK_PRINT.Text = "Print"
        Me.CHK_PRINT.UseVisualStyleBackColor = False
        '
        'FRM_TKGA_ServiceBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1020, 742)
        Me.Controls.Add(Me.CHK_PRINT)
        Me.Controls.Add(Me.lbl_POS)
        Me.Controls.Add(Me.grp_Chequedetails)
        Me.Controls.Add(Me.grp_Carddetails)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.SETLEMENT_GROUP)
        Me.Controls.Add(Me.Txt_Remarks)
        Me.Controls.Add(Me.grp_Paymentmodeselection)
        Me.Controls.Add(Me.pnl_UOMCode)
        Me.Controls.Add(Me.pnl_POSCode)
        Me.Controls.Add(Me.cmd_BillSettlement)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.lbl_Remarks)
        Me.Controls.Add(Me.Lbl_Bill)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ssGrid)
        Me.Controls.Add(Me.grp_Tabledetails)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SSGRID_MEM)
        Me.KeyPreview = True
        Me.Name = "FRM_TKGA_ServiceBill"
        Me.Text = "FRM_TKGA_ServiceBill"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_Tabledetails.ResumeLayout(False)
        Me.grp_Tabledetails.PerformLayout()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnl_POSCode.ResumeLayout(False)
        Me.pnl_UOMCode.ResumeLayout(False)
        CType(Me.SSGRID_MEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Paymentmodeselection.ResumeLayout(False)
        Me.grp_Paymentmodeselection.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssgridPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SETLEMENT_GROUP.ResumeLayout(False)
        Me.SETLEMENT_GROUP.PerformLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Carddetails.ResumeLayout(False)
        Me.grp_Carddetails.PerformLayout()
        Me.grp_Chequedetails.ResumeLayout(False)
        Me.grp_Chequedetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_Tabledetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXT_ITEMCODE As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ServerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_PaymentMode As System.Windows.Forms.Label
    Friend WithEvents cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_KOTno As System.Windows.Forms.Label
    Friend WithEvents txt_KOTno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_KOTdate As System.Windows.Forms.Label
    Friend WithEvents dtp_KOTdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_KOTTime As System.Windows.Forms.TextBox
    Friend WithEvents CMD_ITEMCODE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Servercode As System.Windows.Forms.Button
    Friend WithEvents cmd_KOTnoHelp As System.Windows.Forms.Button
    Friend WithEvents cmd_TablenoHelp As System.Windows.Forms.Button
    Friend WithEvents TXT_ITEMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_SubPaymentMode As System.Windows.Forms.Label
    Friend WithEvents cbo_SubPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Cover As System.Windows.Forms.TextBox
    Friend WithEvents txt_TableNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBL_TRANSNO As System.Windows.Forms.Label
    Friend WithEvents LBL_DOCNO As System.Windows.Forms.Label
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_BillAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_TaxValue As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Charges As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_Discount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalValue As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents Lbl_Bill As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_BillSettlement As System.Windows.Forms.Button
    Friend WithEvents KOT_Timer As System.Windows.Forms.Timer
    Friend WithEvents pnl_POSCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_POSCode As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnl_UOMCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_Uom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SSGRID_MEM As AxFPSpreadADO.AxfpSpread
    Friend WithEvents grp_Paymentmodeselection As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents txt_PartialPayment As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PartialPayment As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Save As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Back As System.Windows.Forms.Button
    Friend WithEvents ssgridPayment As AxFPSpreadADO.AxfpSpread
    Friend WithEvents SETLEMENT_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents ssgrid_settlement As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LAB_BALANCEAMT As System.Windows.Forms.Label
    Friend WithEvents CMD_SETTLEMENT As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Cmd_Pos As System.Windows.Forms.Button
    Friend WithEvents Txt_Pos As System.Windows.Forms.TextBox
    Friend WithEvents grp_Carddetails As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Cardholdername As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Expirydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Cardno As System.Windows.Forms.TextBox
    Friend WithEvents txt_Typeofcard As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cardholdername As System.Windows.Forms.Label
    Friend WithEvents lbl_Expirydate As System.Windows.Forms.Label
    Friend WithEvents lbl_Cardno As System.Windows.Forms.Label
    Friend WithEvents lbl_Typeofcard As System.Windows.Forms.Label
    Friend WithEvents lbl_Carddetails As System.Windows.Forms.Label
    Friend WithEvents grp_Chequedetails As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_Typeofcheque As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Draweebank As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Chequedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Chequeno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Draweebank As System.Windows.Forms.Label
    Friend WithEvents lbl_Chequedate As System.Windows.Forms.Label
    Friend WithEvents lbl_Chequeno As System.Windows.Forms.Label
    Friend WithEvents lbl_Typeofcheque As System.Windows.Forms.Label
    Friend WithEvents lbl_Chequedetails As System.Windows.Forms.Label
    Friend WithEvents lbl_POS As System.Windows.Forms.Label
    Friend WithEvents CHK_PRINT As System.Windows.Forms.CheckBox
End Class
