<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_TKGA_FinalBilling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_TKGA_FinalBilling))
        Me.cmd_BillNoHelp = New System.Windows.Forms.Button()
        Me.dtp_BillDate = New System.Windows.Forms.DateTimePicker()
        Me.txt_BillNo = New System.Windows.Forms.TextBox()
        Me.Lab_Kotdate = New System.Windows.Forms.Label()
        Me.LBL_KotNo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_card_id = New System.Windows.Forms.TextBox()
        Me.lbl_SwipeCard = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmb_type = New System.Windows.Forms.ComboBox()
        Me.cmd_TablenoHelp = New System.Windows.Forms.Button()
        Me.txt_TableNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMB_BTYPE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmd_ServerCodeHelp = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.cbo_SubPaymentMode = New System.Windows.Forms.ComboBox()
        Me.cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.txt_ServerCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_holder_name = New System.Windows.Forms.TextBox()
        Me.txt_MemberName = New System.Windows.Forms.TextBox()
        Me.txt_ServerName = New System.Windows.Forms.TextBox()
        Me.lbl_SubPaymentMode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_MemberName = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Holder_Code = New System.Windows.Forms.TextBox()
        Me.txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Membercode = New System.Windows.Forms.Label()
        Me.Pic_Member = New System.Windows.Forms.PictureBox()
        Me.txt_KOTTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.KOT_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Delay = New System.Windows.Forms.Timer(Me.components)
        Me.sSGrid = New AxFPSpreadADO.AxfpSpread()
        Me.lblDeleted = New System.Windows.Forms.Label()
        Me.grp_Paymentmodeselection = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_Save = New System.Windows.Forms.Button()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Back = New System.Windows.Forms.Button()
        Me.ssgridPayment1 = New AxFPSpreadADO.AxfpSpread()
        Me.txt_PartialPayment = New System.Windows.Forms.TextBox()
        Me.SETLEMENT_GROUP = New System.Windows.Forms.GroupBox()
        Me.LAB_BALANCEAMT = New System.Windows.Forms.Label()
        Me.CMD_SETTLEMENT = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ssgrid_settlement = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_bal = New System.Windows.Forms.Label()
        Me.Txt_Remarks = New System.Windows.Forms.TextBox()
        Me.txt_BillAmount = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Lbl_OtherBill = New System.Windows.Forms.Label()
        Me.Lbl_Bill = New System.Windows.Forms.Label()
        Me.grp_BANK_DETAILS = New System.Windows.Forms.GroupBox()
        Me.cmb_instype = New System.Windows.Forms.ComboBox()
        Me.txt_insno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CHK_PRINT = New System.Windows.Forms.CheckBox()
        Me.lblCro1 = New System.Windows.Forms.Label()
        Me.lblCro2 = New System.Windows.Forms.Label()
        Me.cmd_BillSettlement = New System.Windows.Forms.Button()
        Me.cmdMcodeUpd = New System.Windows.Forms.Button()
        Me.grpPass = New System.Windows.Forms.GroupBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.GRP_PAY = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBO_NPAYMODE = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Paymentmodeselection.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgridPayment1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SETLEMENT_GROUP.SuspendLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_BANK_DETAILS.SuspendLayout()
        Me.grpPass.SuspendLayout()
        Me.GRP_PAY.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_BillNoHelp
        '
        Me.cmd_BillNoHelp.BackgroundImage = CType(resources.GetObject("cmd_BillNoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_BillNoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_BillNoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_BillNoHelp.Location = New System.Drawing.Point(818, 113)
        Me.cmd_BillNoHelp.Name = "cmd_BillNoHelp"
        Me.cmd_BillNoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_BillNoHelp.TabIndex = 595
        Me.cmd_BillNoHelp.UseVisualStyleBackColor = True
        '
        'dtp_BillDate
        '
        Me.dtp_BillDate.Location = New System.Drawing.Point(692, 140)
        Me.dtp_BillDate.Name = "dtp_BillDate"
        Me.dtp_BillDate.Size = New System.Drawing.Size(85, 20)
        Me.dtp_BillDate.TabIndex = 594
        '
        'txt_BillNo
        '
        Me.txt_BillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_BillNo.Location = New System.Drawing.Point(692, 114)
        Me.txt_BillNo.Name = "txt_BillNo"
        Me.txt_BillNo.Size = New System.Drawing.Size(124, 20)
        Me.txt_BillNo.TabIndex = 593
        '
        'Lab_Kotdate
        '
        Me.Lab_Kotdate.AutoSize = True
        Me.Lab_Kotdate.BackColor = System.Drawing.Color.Transparent
        Me.Lab_Kotdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Kotdate.Location = New System.Drawing.Point(629, 142)
        Me.Lab_Kotdate.Name = "Lab_Kotdate"
        Me.Lab_Kotdate.Size = New System.Drawing.Size(53, 15)
        Me.Lab_Kotdate.TabIndex = 592
        Me.Lab_Kotdate.Text = "Bill Date"
        '
        'LBL_KotNo
        '
        Me.LBL_KotNo.AutoSize = True
        Me.LBL_KotNo.BackColor = System.Drawing.Color.Transparent
        Me.LBL_KotNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_KotNo.Location = New System.Drawing.Point(610, 116)
        Me.LBL_KotNo.Name = "LBL_KotNo"
        Me.LBL_KotNo.Size = New System.Drawing.Size(72, 15)
        Me.LBL_KotNo.TabIndex = 591
        Me.LBL_KotNo.Text = "Bill Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(183, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 596
        Me.Label1.Text = "Final Billing"
        '
        'txt_card_id
        '
        Me.txt_card_id.Location = New System.Drawing.Point(264, 118)
        Me.txt_card_id.Name = "txt_card_id"
        Me.txt_card_id.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txt_card_id.Size = New System.Drawing.Size(125, 20)
        Me.txt_card_id.TabIndex = 598
        '
        'lbl_SwipeCard
        '
        Me.lbl_SwipeCard.Location = New System.Drawing.Point(186, 116)
        Me.lbl_SwipeCard.Name = "lbl_SwipeCard"
        Me.lbl_SwipeCard.Size = New System.Drawing.Size(75, 23)
        Me.lbl_SwipeCard.TabIndex = 597
        Me.lbl_SwipeCard.Text = "Swipe Card"
        Me.lbl_SwipeCard.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmb_type)
        Me.Panel1.Controls.Add(Me.cmd_TablenoHelp)
        Me.Panel1.Controls.Add(Me.txt_TableNo)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.CMB_BTYPE)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(186, 145)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(333, 64)
        Me.Panel1.TabIndex = 599
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 15)
        Me.Label17.TabIndex = 133
        Me.Label17.Text = "Table No"
        '
        'CMB_BTYPE
        '
        Me.CMB_BTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_BTYPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMB_BTYPE.FormattingEnabled = True
        Me.CMB_BTYPE.Location = New System.Drawing.Point(220, 9)
        Me.CMB_BTYPE.Name = "CMB_BTYPE"
        Me.CMB_BTYPE.Size = New System.Drawing.Size(106, 21)
        Me.CMB_BTYPE.TabIndex = 131
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(161, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Location"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmd_ServerCodeHelp)
        Me.Panel2.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Panel2.Controls.Add(Me.cbo_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.cbo_PaymentMode)
        Me.Panel2.Controls.Add(Me.txt_ServerCode)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Txt_holder_name)
        Me.Panel2.Controls.Add(Me.txt_MemberName)
        Me.Panel2.Controls.Add(Me.txt_ServerName)
        Me.Panel2.Controls.Add(Me.lbl_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lbl_MemberName)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txt_Holder_Code)
        Me.Panel2.Controls.Add(Me.txt_MemberCode)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbl_Membercode)
        Me.Panel2.Location = New System.Drawing.Point(186, 215)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 131)
        Me.Panel2.TabIndex = 600
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 15)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Waiter Code"
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(296, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 15)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "Waiter Name"
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
        Me.Pic_Member.Location = New System.Drawing.Point(749, 215)
        Me.Pic_Member.Name = "Pic_Member"
        Me.Pic_Member.Size = New System.Drawing.Size(91, 94)
        Me.Pic_Member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Member.TabIndex = 601
        Me.Pic_Member.TabStop = False
        '
        'txt_KOTTime
        '
        Me.txt_KOTTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KOTTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_KOTTime.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTTime.Location = New System.Drawing.Point(781, 139)
        Me.txt_KOTTime.Name = "txt_KOTTime"
        Me.txt_KOTTime.ReadOnly = True
        Me.txt_KOTTime.Size = New System.Drawing.Size(69, 21)
        Me.txt_KOTTime.TabIndex = 603
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 550)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 604
        Me.Label5.Text = "Remarks"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(862, 550)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Exit.TabIndex = 614
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(862, 494)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Export.TabIndex = 613
        Me.Cmd_Export.Text = "Browse [F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(862, 438)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Print.TabIndex = 612
        Me.Cmd_Print.Text = "Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = True
        '
        'Cmd_View
        '
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(862, 382)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_View.TabIndex = 611
        Me.Cmd_View.Text = "View [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = True
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(862, 326)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Delete.TabIndex = 610
        Me.Cmd_Delete.Text = "Delete [F8]"
        Me.Cmd_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Delete.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(862, 214)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Clear.TabIndex = 609
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(862, 270)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Add.TabIndex = 608
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'KOT_Timer
        '
        '
        'sSGrid
        '
        Me.sSGrid.DataSource = Nothing
        Me.sSGrid.Location = New System.Drawing.Point(185, 352)
        Me.sSGrid.Name = "sSGrid"
        Me.sSGrid.OcxState = CType(resources.GetObject("sSGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid.Size = New System.Drawing.Size(567, 175)
        Me.sSGrid.TabIndex = 615
        '
        'lblDeleted
        '
        Me.lblDeleted.BackColor = System.Drawing.Color.Transparent
        Me.lblDeleted.Font = New System.Drawing.Font("Verdana", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleted.ForeColor = System.Drawing.Color.Red
        Me.lblDeleted.Location = New System.Drawing.Point(506, 45)
        Me.lblDeleted.Name = "lblDeleted"
        Me.lblDeleted.Size = New System.Drawing.Size(176, 23)
        Me.lblDeleted.TabIndex = 616
        Me.lblDeleted.Text = "DELETED BILL"
        Me.lblDeleted.Visible = False
        '
        'grp_Paymentmodeselection
        '
        Me.grp_Paymentmodeselection.Controls.Add(Me.GroupBox1)
        Me.grp_Paymentmodeselection.Controls.Add(Me.ssgridPayment1)
        Me.grp_Paymentmodeselection.Controls.Add(Me.txt_PartialPayment)
        Me.grp_Paymentmodeselection.Location = New System.Drawing.Point(189, 300)
        Me.grp_Paymentmodeselection.Name = "grp_Paymentmodeselection"
        Me.grp_Paymentmodeselection.Size = New System.Drawing.Size(561, 224)
        Me.grp_Paymentmodeselection.TabIndex = 617
        Me.grp_Paymentmodeselection.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_Save)
        Me.GroupBox1.Controls.Add(Me.cmd_Cancel)
        Me.GroupBox1.Controls.Add(Me.cmd_Back)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 164)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 53)
        Me.GroupBox1.TabIndex = 15
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
        'ssgridPayment1
        '
        Me.ssgridPayment1.DataSource = Nothing
        Me.ssgridPayment1.Location = New System.Drawing.Point(6, 17)
        Me.ssgridPayment1.Name = "ssgridPayment1"
        Me.ssgridPayment1.OcxState = CType(resources.GetObject("ssgridPayment1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgridPayment1.Size = New System.Drawing.Size(537, 110)
        Me.ssgridPayment1.TabIndex = 0
        '
        'txt_PartialPayment
        '
        Me.txt_PartialPayment.BackColor = System.Drawing.Color.White
        Me.txt_PartialPayment.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PartialPayment.Location = New System.Drawing.Point(334, 131)
        Me.txt_PartialPayment.MaxLength = 12
        Me.txt_PartialPayment.Name = "txt_PartialPayment"
        Me.txt_PartialPayment.ReadOnly = True
        Me.txt_PartialPayment.Size = New System.Drawing.Size(207, 29)
        Me.txt_PartialPayment.TabIndex = 40
        Me.txt_PartialPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SETLEMENT_GROUP
        '
        Me.SETLEMENT_GROUP.Controls.Add(Me.LAB_BALANCEAMT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.CMD_SETTLEMENT)
        Me.SETLEMENT_GROUP.Controls.Add(Me.Label6)
        Me.SETLEMENT_GROUP.Controls.Add(Me.ssgrid_settlement)
        Me.SETLEMENT_GROUP.Controls.Add(Me.lbl_bal)
        Me.SETLEMENT_GROUP.Location = New System.Drawing.Point(238, 730)
        Me.SETLEMENT_GROUP.Name = "SETLEMENT_GROUP"
        Me.SETLEMENT_GROUP.Size = New System.Drawing.Size(553, 259)
        Me.SETLEMENT_GROUP.TabIndex = 619
        Me.SETLEMENT_GROUP.TabStop = False
        '
        'LAB_BALANCEAMT
        '
        Me.LAB_BALANCEAMT.AutoSize = True
        Me.LAB_BALANCEAMT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAB_BALANCEAMT.ForeColor = System.Drawing.Color.Maroon
        Me.LAB_BALANCEAMT.Location = New System.Drawing.Point(228, 222)
        Me.LAB_BALANCEAMT.Name = "LAB_BALANCEAMT"
        Me.LAB_BALANCEAMT.Size = New System.Drawing.Size(180, 18)
        Me.LAB_BALANCEAMT.TabIndex = 622
        Me.LAB_BALANCEAMT.Text = "BALANCE AMOUNT:"
        '
        'CMD_SETTLEMENT
        '
        Me.CMD_SETTLEMENT.Location = New System.Drawing.Point(49, 217)
        Me.CMD_SETTLEMENT.Name = "CMD_SETTLEMENT"
        Me.CMD_SETTLEMENT.Size = New System.Drawing.Size(99, 25)
        Me.CMD_SETTLEMENT.TabIndex = 621
        Me.CMD_SETTLEMENT.Text = "SETTLEMENT"
        Me.CMD_SETTLEMENT.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(202, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 620
        Me.Label6.Text = "SETTLEMENT"
        '
        'ssgrid_settlement
        '
        Me.ssgrid_settlement.DataSource = Nothing
        Me.ssgrid_settlement.Location = New System.Drawing.Point(50, 50)
        Me.ssgrid_settlement.Name = "ssgrid_settlement"
        Me.ssgrid_settlement.OcxState = CType(resources.GetObject("ssgrid_settlement.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_settlement.Size = New System.Drawing.Size(429, 156)
        Me.ssgrid_settlement.TabIndex = 619
        '
        'lbl_bal
        '
        Me.lbl_bal.AllowDrop = True
        Me.lbl_bal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_bal.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bal.ForeColor = System.Drawing.Color.Magenta
        Me.lbl_bal.Location = New System.Drawing.Point(77, -149)
        Me.lbl_bal.Name = "lbl_bal"
        Me.lbl_bal.Size = New System.Drawing.Size(227, 28)
        Me.lbl_bal.TabIndex = 618
        '
        'Txt_Remarks
        '
        Me.Txt_Remarks.Location = New System.Drawing.Point(251, 533)
        Me.Txt_Remarks.Multiline = True
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(289, 32)
        Me.Txt_Remarks.TabIndex = 620
        '
        'txt_BillAmount
        '
        Me.txt_BillAmount.Location = New System.Drawing.Point(663, 536)
        Me.txt_BillAmount.Name = "txt_BillAmount"
        Me.txt_BillAmount.Size = New System.Drawing.Size(86, 20)
        Me.txt_BillAmount.TabIndex = 622
        Me.txt_BillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(586, 539)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 15)
        Me.Label13.TabIndex = 621
        Me.Label13.Text = "Bill Amount"
        '
        'Lbl_OtherBill
        '
        Me.Lbl_OtherBill.BackColor = System.Drawing.Color.DarkMagenta
        Me.Lbl_OtherBill.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_OtherBill.ForeColor = System.Drawing.Color.White
        Me.Lbl_OtherBill.Location = New System.Drawing.Point(523, 186)
        Me.Lbl_OtherBill.Name = "Lbl_OtherBill"
        Me.Lbl_OtherBill.Size = New System.Drawing.Size(245, 24)
        Me.Lbl_OtherBill.TabIndex = 624
        Me.Lbl_OtherBill.Text = "OTHER BILLNO :"
        Me.Lbl_OtherBill.Visible = False
        '
        'Lbl_Bill
        '
        Me.Lbl_Bill.AutoSize = True
        Me.Lbl_Bill.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Bill.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Bill.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Bill.Location = New System.Drawing.Point(187, 607)
        Me.Lbl_Bill.Name = "Lbl_Bill"
        Me.Lbl_Bill.Size = New System.Drawing.Size(0, 22)
        Me.Lbl_Bill.TabIndex = 625
        Me.Lbl_Bill.Visible = False
        '
        'grp_BANK_DETAILS
        '
        Me.grp_BANK_DETAILS.Controls.Add(Me.cmb_instype)
        Me.grp_BANK_DETAILS.Controls.Add(Me.txt_insno)
        Me.grp_BANK_DETAILS.Controls.Add(Me.Label7)
        Me.grp_BANK_DETAILS.Controls.Add(Me.Label9)
        Me.grp_BANK_DETAILS.Location = New System.Drawing.Point(618, 587)
        Me.grp_BANK_DETAILS.Name = "grp_BANK_DETAILS"
        Me.grp_BANK_DETAILS.Size = New System.Drawing.Size(135, 136)
        Me.grp_BANK_DETAILS.TabIndex = 626
        Me.grp_BANK_DETAILS.TabStop = False
        Me.grp_BANK_DETAILS.Visible = False
        '
        'cmb_instype
        '
        Me.cmb_instype.BackColor = System.Drawing.Color.White
        Me.cmb_instype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_instype.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_instype.Items.AddRange(New Object() {"CARD", "CHEQUE", "DD", "PO"})
        Me.cmb_instype.Location = New System.Drawing.Point(16, 32)
        Me.cmb_instype.Name = "cmb_instype"
        Me.cmb_instype.Size = New System.Drawing.Size(104, 30)
        Me.cmb_instype.TabIndex = 609
        Me.cmb_instype.Visible = False
        '
        'txt_insno
        '
        Me.txt_insno.BackColor = System.Drawing.Color.White
        Me.txt_insno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_insno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_insno.Location = New System.Drawing.Point(8, 96)
        Me.txt_insno.MaxLength = 35
        Me.txt_insno.Name = "txt_insno"
        Me.txt_insno.Size = New System.Drawing.Size(120, 29)
        Me.txt_insno.TabIndex = 608
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 23)
        Me.Label7.TabIndex = 607
        Me.Label7.Text = "INSTRUMENT NO:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(0, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 23)
        Me.Label9.TabIndex = 606
        Me.Label9.Text = "INSTRUMENT TYPE"
        '
        'CHK_PRINT
        '
        Me.CHK_PRINT.BackColor = System.Drawing.Color.Transparent
        Me.CHK_PRINT.Checked = True
        Me.CHK_PRINT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_PRINT.Location = New System.Drawing.Point(786, 699)
        Me.CHK_PRINT.Name = "CHK_PRINT"
        Me.CHK_PRINT.Size = New System.Drawing.Size(64, 24)
        Me.CHK_PRINT.TabIndex = 627
        Me.CHK_PRINT.Text = "Print"
        Me.CHK_PRINT.UseVisualStyleBackColor = False
        Me.CHK_PRINT.Visible = False
        '
        'lblCro1
        '
        Me.lblCro1.BackColor = System.Drawing.Color.Transparent
        Me.lblCro1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCro1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCro1.Location = New System.Drawing.Point(182, 635)
        Me.lblCro1.Name = "lblCro1"
        Me.lblCro1.Size = New System.Drawing.Size(72, 16)
        Me.lblCro1.TabIndex = 628
        Me.lblCro1.Text = "CRO NO. "
        Me.lblCro1.Visible = False
        '
        'lblCro2
        '
        Me.lblCro2.BackColor = System.Drawing.Color.Transparent
        Me.lblCro2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCro2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCro2.Location = New System.Drawing.Point(249, 636)
        Me.lblCro2.Name = "lblCro2"
        Me.lblCro2.Size = New System.Drawing.Size(189, 16)
        Me.lblCro2.TabIndex = 629
        Me.lblCro2.Visible = False
        '
        'cmd_BillSettlement
        '
        Me.cmd_BillSettlement.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_BillSettlement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_BillSettlement.Location = New System.Drawing.Point(861, 605)
        Me.cmd_BillSettlement.Name = "cmd_BillSettlement"
        Me.cmd_BillSettlement.Size = New System.Drawing.Size(145, 53)
        Me.cmd_BillSettlement.TabIndex = 630
        Me.cmd_BillSettlement.Text = "Bill Settle [F5]"
        Me.cmd_BillSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_BillSettlement.UseVisualStyleBackColor = True
        '
        'cmdMcodeUpd
        '
        Me.cmdMcodeUpd.BackColor = System.Drawing.Color.MistyRose
        Me.cmdMcodeUpd.ForeColor = System.Drawing.Color.Black
        Me.cmdMcodeUpd.Location = New System.Drawing.Point(543, 561)
        Me.cmdMcodeUpd.Name = "cmdMcodeUpd"
        Me.cmdMcodeUpd.Size = New System.Drawing.Size(211, 24)
        Me.cmdMcodeUpd.TabIndex = 631
        Me.cmdMcodeUpd.Text = "<< PAYMENT MODE Updation  >>"
        Me.cmdMcodeUpd.UseVisualStyleBackColor = False
        '
        'grpPass
        '
        Me.grpPass.BackColor = System.Drawing.Color.Gray
        Me.grpPass.Controls.Add(Me.cmdOk)
        Me.grpPass.Controls.Add(Me.txtPass)
        Me.grpPass.Location = New System.Drawing.Point(511, 429)
        Me.grpPass.Name = "grpPass"
        Me.grpPass.Size = New System.Drawing.Size(244, 128)
        Me.grpPass.TabIndex = 632
        Me.grpPass.TabStop = False
        Me.grpPass.Text = "               ENTER PASSWORD"
        Me.grpPass.Visible = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdOk.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.Color.Black
        Me.cmdOk.Location = New System.Drawing.Point(63, 80)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(104, 32)
        Me.cmdOk.TabIndex = 10
        Me.cmdOk.Text = "Add"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(24, 40)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtPass.Size = New System.Drawing.Size(187, 22)
        Me.txtPass.TabIndex = 2
        '
        'GRP_PAY
        '
        Me.GRP_PAY.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GRP_PAY.Controls.Add(Me.Button3)
        Me.GRP_PAY.Controls.Add(Me.Label10)
        Me.GRP_PAY.Controls.Add(Me.CBO_NPAYMODE)
        Me.GRP_PAY.Location = New System.Drawing.Point(199, 235)
        Me.GRP_PAY.Name = "GRP_PAY"
        Me.GRP_PAY.Size = New System.Drawing.Size(256, 100)
        Me.GRP_PAY.TabIndex = 674
        Me.GRP_PAY.TabStop = False
        Me.GRP_PAY.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button3.Location = New System.Drawing.Point(135, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 34)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "UPDATE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "NEW MODE:"
        '
        'CBO_NPAYMODE
        '
        Me.CBO_NPAYMODE.BackColor = System.Drawing.Color.White
        Me.CBO_NPAYMODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_NPAYMODE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CBO_NPAYMODE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_NPAYMODE.Location = New System.Drawing.Point(87, 23)
        Me.CBO_NPAYMODE.Name = "CBO_NPAYMODE"
        Me.CBO_NPAYMODE.Size = New System.Drawing.Size(128, 23)
        Me.CBO_NPAYMODE.TabIndex = 27
        '
        'FRM_TKGA_FinalBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 742)
        Me.Controls.Add(Me.GRP_PAY)
        Me.Controls.Add(Me.SETLEMENT_GROUP)
        Me.Controls.Add(Me.grpPass)
        Me.Controls.Add(Me.cmdMcodeUpd)
        Me.Controls.Add(Me.cmd_BillSettlement)
        Me.Controls.Add(Me.lblCro2)
        Me.Controls.Add(Me.lblCro1)
        Me.Controls.Add(Me.CHK_PRINT)
        Me.Controls.Add(Me.grp_BANK_DETAILS)
        Me.Controls.Add(Me.Lbl_Bill)
        Me.Controls.Add(Me.Lbl_OtherBill)
        Me.Controls.Add(Me.txt_BillAmount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Txt_Remarks)
        Me.Controls.Add(Me.sSGrid)
        Me.Controls.Add(Me.lblDeleted)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_KOTTime)
        Me.Controls.Add(Me.Pic_Member)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_card_id)
        Me.Controls.Add(Me.lbl_SwipeCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmd_BillNoHelp)
        Me.Controls.Add(Me.dtp_BillDate)
        Me.Controls.Add(Me.txt_BillNo)
        Me.Controls.Add(Me.Lab_Kotdate)
        Me.Controls.Add(Me.LBL_KotNo)
        Me.Controls.Add(Me.grp_Paymentmodeselection)
        Me.KeyPreview = True
        Me.Name = "FRM_TKGA_FinalBilling"
        Me.Text = "Final Billing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Paymentmodeselection.ResumeLayout(False)
        Me.grp_Paymentmodeselection.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssgridPayment1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SETLEMENT_GROUP.ResumeLayout(False)
        Me.SETLEMENT_GROUP.PerformLayout()
        CType(Me.ssgrid_settlement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_BANK_DETAILS.ResumeLayout(False)
        Me.grp_BANK_DETAILS.PerformLayout()
        Me.grpPass.ResumeLayout(False)
        Me.grpPass.PerformLayout()
        Me.GRP_PAY.ResumeLayout(False)
        Me.GRP_PAY.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_BillNoHelp As System.Windows.Forms.Button
    Friend WithEvents dtp_BillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_BillNo As System.Windows.Forms.TextBox
    Friend WithEvents Lab_Kotdate As System.Windows.Forms.Label
    Friend WithEvents LBL_KotNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_card_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SwipeCard As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmd_TablenoHelp As System.Windows.Forms.Button
    Friend WithEvents txt_TableNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CMB_BTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmd_ServerCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cbo_SubPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents txt_ServerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_holder_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SubPaymentMode As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_MemberName As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Holder_Code As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Membercode As System.Windows.Forms.Label
    Friend WithEvents Pic_Member As System.Windows.Forms.PictureBox
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents txt_KOTTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmb_type As System.Windows.Forms.ComboBox
    Friend WithEvents KOT_Timer As System.Windows.Forms.Timer
    Friend WithEvents Timer_Delay As System.Windows.Forms.Timer
    Friend WithEvents sSGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lblDeleted As System.Windows.Forms.Label
    Friend WithEvents grp_Paymentmodeselection As System.Windows.Forms.GroupBox
    Friend WithEvents ssgridPayment1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_bal As System.Windows.Forms.Label
    Friend WithEvents SETLEMENT_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents txt_BillAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ssgrid_settlement As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMD_SETTLEMENT As System.Windows.Forms.Button
    Friend WithEvents LAB_BALANCEAMT As System.Windows.Forms.Label
    Friend WithEvents Lbl_OtherBill As System.Windows.Forms.Label
    Friend WithEvents Lbl_Bill As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Save As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Back As System.Windows.Forms.Button
    Friend WithEvents grp_BANK_DETAILS As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_instype As System.Windows.Forms.ComboBox
    Friend WithEvents txt_insno As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CHK_PRINT As System.Windows.Forms.CheckBox
    Friend WithEvents lblCro1 As System.Windows.Forms.Label
    Friend WithEvents lblCro2 As System.Windows.Forms.Label
    Friend WithEvents cmd_BillSettlement As System.Windows.Forms.Button
    Friend WithEvents txt_PartialPayment As System.Windows.Forms.TextBox
    Friend WithEvents cmdMcodeUpd As System.Windows.Forms.Button
    Friend WithEvents grpPass As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents GRP_PAY As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CBO_NPAYMODE As System.Windows.Forms.ComboBox
End Class
