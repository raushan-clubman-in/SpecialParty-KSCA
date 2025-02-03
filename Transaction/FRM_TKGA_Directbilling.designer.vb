<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_TKGA_Directbilling
    Inherits System.Windows.Forms.Form
    Public Sub New(ByVal STRPOS As String, ByVal DOCTYP As String)
        MyBase.New()
        '        billno = billdetails
        STRPOSCODE = STRPOS
        DOCTYPE = DOCTYP
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_TKGA_Directbilling))
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
        Me.Txt_Remarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_card_id = New System.Windows.Forms.TextBox()
        Me.lbl_SwipeCard = New System.Windows.Forms.Button()
        Me.txt_KOTTime = New System.Windows.Forms.TextBox()
        Me.cmd_KOTnoHelp = New System.Windows.Forms.Button()
        Me.dtp_KOTdate = New System.Windows.Forms.DateTimePicker()
        Me.txt_KOTno = New System.Windows.Forms.TextBox()
        Me.Lab_Kotdate = New System.Windows.Forms.Label()
        Me.LBL_KotNo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_Cover = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmb_type = New System.Windows.Forms.ComboBox()
        Me.cmd_TablenoHelp = New System.Windows.Forms.Button()
        Me.txt_TableNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMB_BTYPE = New System.Windows.Forms.ComboBox()
        Me.Lbl_Loc = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmd_ServerCodeHelp = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.cbo_SubPaymentMode = New System.Windows.Forms.ComboBox()
        Me.cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.txt_ServerCode = New System.Windows.Forms.TextBox()
        Me.Lab_Waiter = New System.Windows.Forms.Label()
        Me.Txt_holder_name = New System.Windows.Forms.TextBox()
        Me.txt_MemberName = New System.Windows.Forms.TextBox()
        Me.txt_ServerName = New System.Windows.Forms.TextBox()
        Me.lbl_SubPaymentMode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_MemberName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Holder_Code = New System.Windows.Forms.TextBox()
        Me.txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Membercode = New System.Windows.Forms.Label()
        Me.Pic_Member = New System.Windows.Forms.PictureBox()
        Me.grp_BANK_DETAILS = New System.Windows.Forms.GroupBox()
        Me.cmb_instype = New System.Windows.Forms.ComboBox()
        Me.txt_insno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.sSGrid = New AxFPSpreadADO.AxfpSpread()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnl_POSCode = New System.Windows.Forms.Panel()
        Me.lvw_POSCode = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnl_UOMCode = New System.Windows.Forms.Panel()
        Me.lvw_Uom = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grp_Paymentmodeselection = New System.Windows.Forms.GroupBox()
        Me.ssgridPayment1 = New AxFPSpreadADO.AxfpSpread()
        Me.txt_PartialPayment = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_Save = New System.Windows.Forms.Button()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Back = New System.Windows.Forms.Button()
        Me.SETLEMENT_GROUP = New System.Windows.Forms.GroupBox()
        Me.LAB_BALANCEAMT = New System.Windows.Forms.Label()
        Me.CMD_SETTLEMENT = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ssgrid_settlement = New AxFPSpreadADO.AxfpSpread()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.KOT_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Delay = New System.Windows.Forms.Timer(Me.components)
        Me.cmd_BillSettlement = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.lbl_bal = New System.Windows.Forms.Label()
        Me.Lbl_Bill = New System.Windows.Forms.Label()
        Me.Lbl_PosDesc = New System.Windows.Forms.Label()
        Me.Txt_PartyBookingNo = New System.Windows.Forms.TextBox()
        Me.Lbl_PartyBookingNo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_BANK_DETAILS.SuspendLayout()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnl_POSCode.SuspendLayout()
        Me.pnl_UOMCode.SuspendLayout()
        Me.grp_Paymentmodeselection.SuspendLayout()
        CType(Me.ssgridPayment1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SETLEMENT_GROUP.SuspendLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Txt_Remarks
        '
        Me.Txt_Remarks.Location = New System.Drawing.Point(252, 527)
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(272, 20)
        Me.Txt_Remarks.TabIndex = 111
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(191, 530)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 15)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "Remarks"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Smart Direct Billing"
        '
        'txt_card_id
        '
        Me.txt_card_id.Location = New System.Drawing.Point(268, 110)
        Me.txt_card_id.Name = "txt_card_id"
        Me.txt_card_id.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txt_card_id.Size = New System.Drawing.Size(125, 20)
        Me.txt_card_id.TabIndex = 600
        '
        'lbl_SwipeCard
        '
        Me.lbl_SwipeCard.Location = New System.Drawing.Point(190, 108)
        Me.lbl_SwipeCard.Name = "lbl_SwipeCard"
        Me.lbl_SwipeCard.Size = New System.Drawing.Size(75, 23)
        Me.lbl_SwipeCard.TabIndex = 599
        Me.lbl_SwipeCard.Text = "Swipe Card"
        Me.lbl_SwipeCard.UseVisualStyleBackColor = True
        '
        'txt_KOTTime
        '
        Me.txt_KOTTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KOTTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_KOTTime.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTTime.Location = New System.Drawing.Point(783, 133)
        Me.txt_KOTTime.Name = "txt_KOTTime"
        Me.txt_KOTTime.ReadOnly = True
        Me.txt_KOTTime.Size = New System.Drawing.Size(69, 21)
        Me.txt_KOTTime.TabIndex = 609
        '
        'cmd_KOTnoHelp
        '
        Me.cmd_KOTnoHelp.BackgroundImage = CType(resources.GetObject("cmd_KOTnoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_KOTnoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_KOTnoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_KOTnoHelp.Location = New System.Drawing.Point(820, 107)
        Me.cmd_KOTnoHelp.Name = "cmd_KOTnoHelp"
        Me.cmd_KOTnoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_KOTnoHelp.TabIndex = 608
        Me.cmd_KOTnoHelp.UseVisualStyleBackColor = True
        '
        'dtp_KOTdate
        '
        Me.dtp_KOTdate.Location = New System.Drawing.Point(694, 134)
        Me.dtp_KOTdate.Name = "dtp_KOTdate"
        Me.dtp_KOTdate.Size = New System.Drawing.Size(85, 20)
        Me.dtp_KOTdate.TabIndex = 607
        '
        'txt_KOTno
        '
        Me.txt_KOTno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTno.Location = New System.Drawing.Point(694, 108)
        Me.txt_KOTno.Name = "txt_KOTno"
        Me.txt_KOTno.Size = New System.Drawing.Size(124, 20)
        Me.txt_KOTno.TabIndex = 606
        '
        'Lab_Kotdate
        '
        Me.Lab_Kotdate.AutoSize = True
        Me.Lab_Kotdate.BackColor = System.Drawing.Color.Transparent
        Me.Lab_Kotdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Kotdate.Location = New System.Drawing.Point(631, 136)
        Me.Lab_Kotdate.Name = "Lab_Kotdate"
        Me.Lab_Kotdate.Size = New System.Drawing.Size(60, 15)
        Me.Lab_Kotdate.TabIndex = 605
        Me.Lab_Kotdate.Text = "KOT Date"
        '
        'LBL_KotNo
        '
        Me.LBL_KotNo.AutoSize = True
        Me.LBL_KotNo.BackColor = System.Drawing.Color.Transparent
        Me.LBL_KotNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_KotNo.Location = New System.Drawing.Point(612, 110)
        Me.LBL_KotNo.Name = "LBL_KotNo"
        Me.LBL_KotNo.Size = New System.Drawing.Size(79, 15)
        Me.LBL_KotNo.TabIndex = 604
        Me.LBL_KotNo.Text = "KOT Number"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txt_Cover)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.cmb_type)
        Me.Panel1.Controls.Add(Me.cmd_TablenoHelp)
        Me.Panel1.Controls.Add(Me.txt_TableNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CMB_BTYPE)
        Me.Panel1.Controls.Add(Me.Lbl_Loc)
        Me.Panel1.Location = New System.Drawing.Point(190, 137)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(333, 64)
        Me.Panel1.TabIndex = 610
        '
        'txt_Cover
        '
        Me.txt_Cover.Location = New System.Drawing.Point(221, 9)
        Me.txt_Cover.Name = "txt_Cover"
        Me.txt_Cover.Size = New System.Drawing.Size(83, 20)
        Me.txt_Cover.TabIndex = 223
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(163, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 15)
        Me.Label18.TabIndex = 222
        Me.Label18.Text = "Covers"
        '
        'cmb_type
        '
        Me.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_type.FormattingEnabled = True
        Me.cmb_type.Items.AddRange(New Object() {"CLUBMEMBER", "EMPLOYEE", "ROOMGUEST", "SMART CARD"})
        Me.cmb_type.Location = New System.Drawing.Point(7, 36)
        Me.cmb_type.Name = "cmb_type"
        Me.cmb_type.Size = New System.Drawing.Size(150, 21)
        Me.cmb_type.TabIndex = 221
        '
        'cmd_TablenoHelp
        '
        Me.cmd_TablenoHelp.BackgroundImage = CType(resources.GetObject("cmd_TablenoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_TablenoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_TablenoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_TablenoHelp.Location = New System.Drawing.Point(125, 8)
        Me.cmd_TablenoHelp.Name = "cmd_TablenoHelp"
        Me.cmd_TablenoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_TablenoHelp.TabIndex = 220
        Me.cmd_TablenoHelp.UseVisualStyleBackColor = True
        '
        'txt_TableNo
        '
        Me.txt_TableNo.Location = New System.Drawing.Point(60, 9)
        Me.txt_TableNo.Name = "txt_TableNo"
        Me.txt_TableNo.Size = New System.Drawing.Size(63, 20)
        Me.txt_TableNo.TabIndex = 135
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Table No"
        '
        'CMB_BTYPE
        '
        Me.CMB_BTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_BTYPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMB_BTYPE.FormattingEnabled = True
        Me.CMB_BTYPE.Location = New System.Drawing.Point(220, 36)
        Me.CMB_BTYPE.Name = "CMB_BTYPE"
        Me.CMB_BTYPE.Size = New System.Drawing.Size(106, 21)
        Me.CMB_BTYPE.TabIndex = 131
        '
        'Lbl_Loc
        '
        Me.Lbl_Loc.AutoSize = True
        Me.Lbl_Loc.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Loc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Loc.Location = New System.Drawing.Point(161, 39)
        Me.Lbl_Loc.Name = "Lbl_Loc"
        Me.Lbl_Loc.Size = New System.Drawing.Size(56, 15)
        Me.Lbl_Loc.TabIndex = 90
        Me.Lbl_Loc.Text = "Location"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmd_ServerCodeHelp)
        Me.Panel2.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Panel2.Controls.Add(Me.cbo_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.cbo_PaymentMode)
        Me.Panel2.Controls.Add(Me.txt_ServerCode)
        Me.Panel2.Controls.Add(Me.Lab_Waiter)
        Me.Panel2.Controls.Add(Me.Txt_holder_name)
        Me.Panel2.Controls.Add(Me.txt_MemberName)
        Me.Panel2.Controls.Add(Me.txt_ServerName)
        Me.Panel2.Controls.Add(Me.lbl_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lbl_MemberName)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_Holder_Code)
        Me.Panel2.Controls.Add(Me.txt_MemberCode)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbl_Membercode)
        Me.Panel2.Location = New System.Drawing.Point(190, 204)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 131)
        Me.Panel2.TabIndex = 611
        '
        'cmd_ServerCodeHelp
        '
        Me.cmd_ServerCodeHelp.BackgroundImage = CType(resources.GetObject("cmd_ServerCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_ServerCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_ServerCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_ServerCodeHelp.Location = New System.Drawing.Point(235, 98)
        Me.cmd_ServerCodeHelp.Name = "cmd_ServerCodeHelp"
        Me.cmd_ServerCodeHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_ServerCodeHelp.TabIndex = 220
        Me.cmd_ServerCodeHelp.UseVisualStyleBackColor = True
        '
        'cmd_MemberCodeHelp
        '
        Me.cmd_MemberCodeHelp.BackgroundImage = CType(resources.GetObject("cmd_MemberCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_MemberCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_MemberCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_MemberCodeHelp.Location = New System.Drawing.Point(235, 69)
        Me.cmd_MemberCodeHelp.Name = "cmd_MemberCodeHelp"
        Me.cmd_MemberCodeHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_MemberCodeHelp.TabIndex = 219
        Me.cmd_MemberCodeHelp.UseVisualStyleBackColor = True
        '
        'cbo_SubPaymentMode
        '
        Me.cbo_SubPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_SubPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_SubPaymentMode.FormattingEnabled = True
        Me.cbo_SubPaymentMode.Location = New System.Drawing.Point(383, 8)
        Me.cbo_SubPaymentMode.Name = "cbo_SubPaymentMode"
        Me.cbo_SubPaymentMode.Size = New System.Drawing.Size(147, 21)
        Me.cbo_SubPaymentMode.TabIndex = 133
        '
        'cbo_PaymentMode
        '
        Me.cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_PaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_PaymentMode.FormattingEnabled = True
        Me.cbo_PaymentMode.Location = New System.Drawing.Point(108, 10)
        Me.cbo_PaymentMode.Name = "cbo_PaymentMode"
        Me.cbo_PaymentMode.Size = New System.Drawing.Size(106, 21)
        Me.cbo_PaymentMode.TabIndex = 132
        '
        'txt_ServerCode
        '
        Me.txt_ServerCode.Location = New System.Drawing.Point(108, 100)
        Me.txt_ServerCode.Name = "txt_ServerCode"
        Me.txt_ServerCode.Size = New System.Drawing.Size(125, 20)
        Me.txt_ServerCode.TabIndex = 123
        '
        'Lab_Waiter
        '
        Me.Lab_Waiter.AutoSize = True
        Me.Lab_Waiter.BackColor = System.Drawing.Color.Transparent
        Me.Lab_Waiter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Waiter.Location = New System.Drawing.Point(9, 101)
        Me.Lab_Waiter.Name = "Lab_Waiter"
        Me.Lab_Waiter.Size = New System.Drawing.Size(77, 15)
        Me.Lab_Waiter.TabIndex = 122
        Me.Lab_Waiter.Text = "Waiter Code"
        '
        'Txt_holder_name
        '
        Me.Txt_holder_name.Location = New System.Drawing.Point(380, 39)
        Me.Txt_holder_name.Name = "Txt_holder_name"
        Me.Txt_holder_name.Size = New System.Drawing.Size(150, 20)
        Me.Txt_holder_name.TabIndex = 111
        '
        'txt_MemberName
        '
        Me.txt_MemberName.Location = New System.Drawing.Point(380, 68)
        Me.txt_MemberName.Name = "txt_MemberName"
        Me.txt_MemberName.Size = New System.Drawing.Size(150, 20)
        Me.txt_MemberName.TabIndex = 110
        '
        'txt_ServerName
        '
        Me.txt_ServerName.Location = New System.Drawing.Point(380, 99)
        Me.txt_ServerName.Name = "txt_ServerName"
        Me.txt_ServerName.Size = New System.Drawing.Size(150, 20)
        Me.txt_ServerName.TabIndex = 109
        '
        'lbl_SubPaymentMode
        '
        Me.lbl_SubPaymentMode.AutoSize = True
        Me.lbl_SubPaymentMode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SubPaymentMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubPaymentMode.Location = New System.Drawing.Point(292, 11)
        Me.lbl_SubPaymentMode.Name = "lbl_SubPaymentMode"
        Me.lbl_SubPaymentMode.Size = New System.Drawing.Size(87, 15)
        Me.lbl_SubPaymentMode.TabIndex = 108
        Me.lbl_SubPaymentMode.Text = "Sub Pay Mode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Card Holder"
        '
        'lbl_MemberName
        '
        Me.lbl_MemberName.AutoSize = True
        Me.lbl_MemberName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MemberName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MemberName.Location = New System.Drawing.Point(287, 71)
        Me.lbl_MemberName.Name = "lbl_MemberName"
        Me.lbl_MemberName.Size = New System.Drawing.Size(90, 15)
        Me.lbl_MemberName.TabIndex = 106
        Me.lbl_MemberName.Text = "Member Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(296, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Waiter Name"
        '
        'txt_Holder_Code
        '
        Me.txt_Holder_Code.Location = New System.Drawing.Point(108, 42)
        Me.txt_Holder_Code.Name = "txt_Holder_Code"
        Me.txt_Holder_Code.Size = New System.Drawing.Size(125, 20)
        Me.txt_Holder_Code.TabIndex = 103
        '
        'txt_MemberCode
        '
        Me.txt_MemberCode.Location = New System.Drawing.Point(108, 70)
        Me.txt_MemberCode.Name = "txt_MemberCode"
        Me.txt_MemberCode.Size = New System.Drawing.Size(125, 20)
        Me.txt_MemberCode.TabIndex = 102
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Operation Mode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Card Holder"
        '
        'lbl_Membercode
        '
        Me.lbl_Membercode.AutoSize = True
        Me.lbl_Membercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Membercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Membercode.Location = New System.Drawing.Point(9, 73)
        Me.lbl_Membercode.Name = "lbl_Membercode"
        Me.lbl_Membercode.Size = New System.Drawing.Size(86, 15)
        Me.lbl_Membercode.TabIndex = 98
        Me.lbl_Membercode.Text = "Member Code"
        '
        'Pic_Member
        '
        Me.Pic_Member.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Member.Location = New System.Drawing.Point(741, 206)
        Me.Pic_Member.Name = "Pic_Member"
        Me.Pic_Member.Size = New System.Drawing.Size(91, 94)
        Me.Pic_Member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Member.TabIndex = 612
        Me.Pic_Member.TabStop = False
        '
        'grp_BANK_DETAILS
        '
        Me.grp_BANK_DETAILS.Controls.Add(Me.cmb_instype)
        Me.grp_BANK_DETAILS.Controls.Add(Me.txt_insno)
        Me.grp_BANK_DETAILS.Controls.Add(Me.Label9)
        Me.grp_BANK_DETAILS.Controls.Add(Me.Label10)
        Me.grp_BANK_DETAILS.Location = New System.Drawing.Point(69, 222)
        Me.grp_BANK_DETAILS.Name = "grp_BANK_DETAILS"
        Me.grp_BANK_DETAILS.Size = New System.Drawing.Size(115, 113)
        Me.grp_BANK_DETAILS.TabIndex = 627
        Me.grp_BANK_DETAILS.TabStop = False
        Me.grp_BANK_DETAILS.Visible = False
        '
        'cmb_instype
        '
        Me.cmb_instype.BackColor = System.Drawing.Color.White
        Me.cmb_instype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_instype.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_instype.Items.AddRange(New Object() {"CARD", "CHEQUE", "DD", "PO"})
        Me.cmb_instype.Location = New System.Drawing.Point(4, 26)
        Me.cmb_instype.Name = "cmb_instype"
        Me.cmb_instype.Size = New System.Drawing.Size(104, 23)
        Me.cmb_instype.TabIndex = 609
        Me.cmb_instype.Visible = False
        '
        'txt_insno
        '
        Me.txt_insno.BackColor = System.Drawing.Color.White
        Me.txt_insno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_insno.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_insno.Location = New System.Drawing.Point(8, 78)
        Me.txt_insno.MaxLength = 35
        Me.txt_insno.Name = "txt_insno"
        Me.txt_insno.Size = New System.Drawing.Size(98, 22)
        Me.txt_insno.TabIndex = 608
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 23)
        Me.Label9.TabIndex = 607
        Me.Label9.Text = "INSTRUMENT NO:"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(0, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 23)
        Me.Label10.TabIndex = 606
        Me.Label10.Text = "INSTRUMENT TYPE"
        '
        'sSGrid
        '
        Me.sSGrid.DataSource = Nothing
        Me.sSGrid.Location = New System.Drawing.Point(183, 336)
        Me.sSGrid.Name = "sSGrid"
        Me.sSGrid.OcxState = CType(resources.GetObject("sSGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid.Size = New System.Drawing.Size(666, 176)
        Me.sSGrid.TabIndex = 628
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
        Me.Panel3.Location = New System.Drawing.Point(591, 515)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 130)
        Me.Panel3.TabIndex = 629
        '
        'pnl_POSCode
        '
        Me.pnl_POSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_POSCode.Controls.Add(Me.lvw_POSCode)
        Me.pnl_POSCode.Location = New System.Drawing.Point(69, 101)
        Me.pnl_POSCode.Name = "pnl_POSCode"
        Me.pnl_POSCode.Size = New System.Drawing.Size(269, 119)
        Me.pnl_POSCode.TabIndex = 631
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
        Me.pnl_UOMCode.Location = New System.Drawing.Point(344, 100)
        Me.pnl_UOMCode.Name = "pnl_UOMCode"
        Me.pnl_UOMCode.Size = New System.Drawing.Size(261, 120)
        Me.pnl_UOMCode.TabIndex = 632
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
        'grp_Paymentmodeselection
        '
        Me.grp_Paymentmodeselection.Controls.Add(Me.ssgridPayment1)
        Me.grp_Paymentmodeselection.Controls.Add(Me.txt_PartialPayment)
        Me.grp_Paymentmodeselection.Controls.Add(Me.GroupBox1)
        Me.grp_Paymentmodeselection.Location = New System.Drawing.Point(190, 301)
        Me.grp_Paymentmodeselection.Name = "grp_Paymentmodeselection"
        Me.grp_Paymentmodeselection.Size = New System.Drawing.Size(567, 212)
        Me.grp_Paymentmodeselection.TabIndex = 633
        Me.grp_Paymentmodeselection.TabStop = False
        '
        'ssgridPayment1
        '
        Me.ssgridPayment1.DataSource = Nothing
        Me.ssgridPayment1.Location = New System.Drawing.Point(13, 21)
        Me.ssgridPayment1.Name = "ssgridPayment1"
        Me.ssgridPayment1.OcxState = CType(resources.GetObject("ssgridPayment1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgridPayment1.Size = New System.Drawing.Size(531, 119)
        Me.ssgridPayment1.TabIndex = 0
        '
        'txt_PartialPayment
        '
        Me.txt_PartialPayment.BackColor = System.Drawing.Color.White
        Me.txt_PartialPayment.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PartialPayment.Location = New System.Drawing.Point(335, 108)
        Me.txt_PartialPayment.MaxLength = 12
        Me.txt_PartialPayment.Name = "txt_PartialPayment"
        Me.txt_PartialPayment.ReadOnly = True
        Me.txt_PartialPayment.Size = New System.Drawing.Size(207, 29)
        Me.txt_PartialPayment.TabIndex = 41
        Me.txt_PartialPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_Save)
        Me.GroupBox1.Controls.Add(Me.cmd_Cancel)
        Me.GroupBox1.Controls.Add(Me.cmd_Back)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 53)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'cmd_Save
        '
        Me.cmd_Save.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Save.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Save.ForeColor = System.Drawing.Color.Black
        Me.cmd_Save.Image = CType(resources.GetObject("cmd_Save.Image"), System.Drawing.Image)
        Me.cmd_Save.Location = New System.Drawing.Point(144, 15)
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
        Me.cmd_Cancel.ForeColor = System.Drawing.Color.Black
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
        Me.cmd_Back.ForeColor = System.Drawing.Color.Black
        Me.cmd_Back.Image = CType(resources.GetObject("cmd_Back.Image"), System.Drawing.Image)
        Me.cmd_Back.Location = New System.Drawing.Point(24, 14)
        Me.cmd_Back.Name = "cmd_Back"
        Me.cmd_Back.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Back.TabIndex = 0
        Me.cmd_Back.Text = "BACK"
        Me.cmd_Back.UseVisualStyleBackColor = False
        '
        'SETLEMENT_GROUP
        '
        Me.SETLEMENT_GROUP.Controls.Add(Me.LAB_BALANCEAMT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.CMD_SETTLEMENT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.Label11)
        Me.SETLEMENT_GROUP.Controls.Add(Me.ssgrid_settlement)
        Me.SETLEMENT_GROUP.Location = New System.Drawing.Point(241, 732)
        Me.SETLEMENT_GROUP.Name = "SETLEMENT_GROUP"
        Me.SETLEMENT_GROUP.Size = New System.Drawing.Size(409, 266)
        Me.SETLEMENT_GROUP.TabIndex = 634
        Me.SETLEMENT_GROUP.TabStop = False
        '
        'LAB_BALANCEAMT
        '
        Me.LAB_BALANCEAMT.AutoSize = True
        Me.LAB_BALANCEAMT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAB_BALANCEAMT.ForeColor = System.Drawing.Color.Maroon
        Me.LAB_BALANCEAMT.Location = New System.Drawing.Point(178, 229)
        Me.LAB_BALANCEAMT.Name = "LAB_BALANCEAMT"
        Me.LAB_BALANCEAMT.Size = New System.Drawing.Size(180, 18)
        Me.LAB_BALANCEAMT.TabIndex = 624
        Me.LAB_BALANCEAMT.Text = "BALANCE AMOUNT:"
        '
        'CMD_SETTLEMENT
        '
        Me.CMD_SETTLEMENT.Location = New System.Drawing.Point(32, 225)
        Me.CMD_SETTLEMENT.Name = "CMD_SETTLEMENT"
        Me.CMD_SETTLEMENT.Size = New System.Drawing.Size(99, 25)
        Me.CMD_SETTLEMENT.TabIndex = 623
        Me.CMD_SETTLEMENT.Text = "SETTLEMENT"
        Me.CMD_SETTLEMENT.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(132, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 19)
        Me.Label11.TabIndex = 621
        Me.Label11.Text = "SETTLEMENT"
        '
        'ssgrid_settlement
        '
        Me.ssgrid_settlement.DataSource = Nothing
        Me.ssgrid_settlement.Location = New System.Drawing.Point(29, 51)
        Me.ssgrid_settlement.Name = "ssgrid_settlement"
        Me.ssgrid_settlement.OcxState = CType(resources.GetObject("ssgrid_settlement.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_settlement.Size = New System.Drawing.Size(347, 161)
        Me.ssgrid_settlement.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'KOT_Timer
        '
        '
        'cmd_BillSettlement
        '
        Me.cmd_BillSettlement.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_BillSettlement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_BillSettlement.Location = New System.Drawing.Point(860, 598)
        Me.cmd_BillSettlement.Name = "cmd_BillSettlement"
        Me.cmd_BillSettlement.Size = New System.Drawing.Size(145, 53)
        Me.cmd_BillSettlement.TabIndex = 642
        Me.cmd_BillSettlement.Text = "Bill Settle [F5]"
        Me.cmd_BillSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_BillSettlement.UseVisualStyleBackColor = True
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(861, 543)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Exit.TabIndex = 641
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(861, 487)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Export.TabIndex = 640
        Me.Cmd_Export.Text = "Browse [F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(861, 431)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Print.TabIndex = 639
        Me.Cmd_Print.Text = "Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = True
        '
        'Cmd_View
        '
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(861, 375)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_View.TabIndex = 638
        Me.Cmd_View.Text = "View [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = True
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(861, 319)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Delete.TabIndex = 637
        Me.Cmd_Delete.Text = "Delete [F8]"
        Me.Cmd_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Delete.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(861, 207)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Clear.TabIndex = 636
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(861, 263)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Add.TabIndex = 635
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Status.Location = New System.Drawing.Point(186, 596)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(0, 22)
        Me.lbl_Status.TabIndex = 643
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_bal
        '
        Me.lbl_bal.AllowDrop = True
        Me.lbl_bal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_bal.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bal.ForeColor = System.Drawing.Color.Magenta
        Me.lbl_bal.Location = New System.Drawing.Point(250, 550)
        Me.lbl_bal.Name = "lbl_bal"
        Me.lbl_bal.Size = New System.Drawing.Size(208, 24)
        Me.lbl_bal.TabIndex = 644
        '
        'Lbl_Bill
        '
        Me.Lbl_Bill.AutoSize = True
        Me.Lbl_Bill.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Bill.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Bill.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Bill.Location = New System.Drawing.Point(186, 572)
        Me.Lbl_Bill.Name = "Lbl_Bill"
        Me.Lbl_Bill.Size = New System.Drawing.Size(0, 18)
        Me.Lbl_Bill.TabIndex = 645
        '
        'Lbl_PosDesc
        '
        Me.Lbl_PosDesc.AutoSize = True
        Me.Lbl_PosDesc.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PosDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PosDesc.ForeColor = System.Drawing.Color.Red
        Me.Lbl_PosDesc.Location = New System.Drawing.Point(529, 180)
        Me.Lbl_PosDesc.Name = "Lbl_PosDesc"
        Me.Lbl_PosDesc.Size = New System.Drawing.Size(32, 15)
        Me.Lbl_PosDesc.TabIndex = 646
        Me.Lbl_PosDesc.Text = "POS"
        '
        'Txt_PartyBookingNo
        '
        Me.Txt_PartyBookingNo.Location = New System.Drawing.Point(471, 114)
        Me.Txt_PartyBookingNo.Name = "Txt_PartyBookingNo"
        Me.Txt_PartyBookingNo.Size = New System.Drawing.Size(61, 20)
        Me.Txt_PartyBookingNo.TabIndex = 648
        '
        'Lbl_PartyBookingNo
        '
        Me.Lbl_PartyBookingNo.AutoSize = True
        Me.Lbl_PartyBookingNo.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PartyBookingNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PartyBookingNo.Location = New System.Drawing.Point(399, 116)
        Me.Lbl_PartyBookingNo.Name = "Lbl_PartyBookingNo"
        Me.Lbl_PartyBookingNo.Size = New System.Drawing.Size(71, 15)
        Me.Lbl_PartyBookingNo.TabIndex = 647
        Me.Lbl_PartyBookingNo.Text = "Booking No"
        '
        'FRM_TKGA_Directbilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 742)
        Me.Controls.Add(Me.pnl_UOMCode)
        Me.Controls.Add(Me.Txt_PartyBookingNo)
        Me.Controls.Add(Me.Lbl_PartyBookingNo)
        Me.Controls.Add(Me.Lbl_PosDesc)
        Me.Controls.Add(Me.Lbl_Bill)
        Me.Controls.Add(Me.lbl_bal)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.cmd_BillSettlement)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.SETLEMENT_GROUP)
        Me.Controls.Add(Me.pnl_POSCode)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.sSGrid)
        Me.Controls.Add(Me.grp_BANK_DETAILS)
        Me.Controls.Add(Me.Pic_Member)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_KOTTime)
        Me.Controls.Add(Me.cmd_KOTnoHelp)
        Me.Controls.Add(Me.dtp_KOTdate)
        Me.Controls.Add(Me.txt_KOTno)
        Me.Controls.Add(Me.Lab_Kotdate)
        Me.Controls.Add(Me.LBL_KotNo)
        Me.Controls.Add(Me.txt_card_id)
        Me.Controls.Add(Me.lbl_SwipeCard)
        Me.Controls.Add(Me.Txt_Remarks)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_Paymentmodeselection)
        Me.KeyPreview = True
        Me.Name = "FRM_TKGA_Directbilling"
        Me.Text = "FRM_TKGA_Directbilling"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_BANK_DETAILS.ResumeLayout(False)
        Me.grp_BANK_DETAILS.PerformLayout()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnl_POSCode.ResumeLayout(False)
        Me.pnl_UOMCode.ResumeLayout(False)
        Me.grp_Paymentmodeselection.ResumeLayout(False)
        Me.grp_Paymentmodeselection.PerformLayout()
        CType(Me.ssgridPayment1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SETLEMENT_GROUP.ResumeLayout(False)
        Me.SETLEMENT_GROUP.PerformLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_card_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SwipeCard As System.Windows.Forms.Button
    Friend WithEvents txt_KOTTime As System.Windows.Forms.TextBox
    Friend WithEvents cmd_KOTnoHelp As System.Windows.Forms.Button
    Friend WithEvents dtp_KOTdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_KOTno As System.Windows.Forms.TextBox
    Friend WithEvents Lab_Kotdate As System.Windows.Forms.Label
    Friend WithEvents LBL_KotNo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmb_type As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_TablenoHelp As System.Windows.Forms.Button
    Friend WithEvents txt_TableNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMB_BTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Loc As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmd_ServerCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cbo_SubPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents txt_ServerCode As System.Windows.Forms.TextBox
    Friend WithEvents Lab_Waiter As System.Windows.Forms.Label
    Friend WithEvents Txt_holder_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SubPaymentMode As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_MemberName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Holder_Code As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Membercode As System.Windows.Forms.Label
    Friend WithEvents Pic_Member As System.Windows.Forms.PictureBox
    Friend WithEvents grp_BANK_DETAILS As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_instype As System.Windows.Forms.ComboBox
    Friend WithEvents txt_insno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents sSGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnl_POSCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_POSCode As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnl_UOMCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_Uom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grp_Paymentmodeselection As System.Windows.Forms.GroupBox
    Friend WithEvents ssgridPayment1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Save As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Back As System.Windows.Forms.Button
    Friend WithEvents SETLEMENT_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents ssgrid_settlement As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LAB_BALANCEAMT As System.Windows.Forms.Label
    Friend WithEvents CMD_SETTLEMENT As System.Windows.Forms.Button
    Friend WithEvents txt_PartialPayment As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents KOT_Timer As System.Windows.Forms.Timer
    Friend WithEvents Timer_Delay As System.Windows.Forms.Timer
    Friend WithEvents cmd_BillSettlement As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents lbl_bal As System.Windows.Forms.Label
    Friend WithEvents Lbl_Bill As System.Windows.Forms.Label
    Friend WithEvents txt_Cover As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Lbl_PosDesc As System.Windows.Forms.Label
    Friend WithEvents Txt_PartyBookingNo As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_PartyBookingNo As System.Windows.Forms.Label
End Class
