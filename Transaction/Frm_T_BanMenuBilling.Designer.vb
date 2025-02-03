<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_T_BanMenuBilling
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_T_BanMenuBilling))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_Discount = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_PaidAmt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBBOOKINGTYPE = New System.Windows.Forms.ComboBox()
        Me.Cmd_MCodeHelp = New System.Windows.Forms.Button()
        Me.Cmd_BookingNoHelp = New System.Windows.Forms.Button()
        Me.Dtp_PartyDate = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_BookingDate = New System.Windows.Forms.DateTimePicker()
        Me.Txt_GuestName = New System.Windows.Forms.TextBox()
        Me.Txt_TotPax = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_VPax = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_NVPax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_MemberName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Purpose = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_BookingNo = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Hall_Display = New System.Windows.Forms.TabPage()
        Me.sSGrid_HallResv = New AxFPSpreadADO.AxfpSpread()
        Me.Veg_Pax = New System.Windows.Forms.TabPage()
        Me.sSGrid_VPax = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_VMenuCodeHelp = New System.Windows.Forms.Button()
        Me.Txt_VMaxItem = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_VMenuDesc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_VMenuCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NV_Pax = New System.Windows.Forms.TabPage()
        Me.sSGrid_NVPax = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_NVMenuCodeHelp = New System.Windows.Forms.Button()
        Me.Txt_NVMaxItem = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_NVMenuDesc = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_NVMenuCode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.KotDet = New System.Windows.Forms.TabPage()
        Me.sSGrid_Kot = New AxFPSpreadADO.AxfpSpread()
        Me.Arr_Item = New System.Windows.Forms.TabPage()
        Me.sSGrid_Arr = New AxFPSpreadADO.AxfpSpread()
        Me.Oth_Chgs = New System.Windows.Forms.TabPage()
        Me.sSGrid_Oth = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Settlement = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Cmb_Location = New System.Windows.Forms.ComboBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.TXTBILLINGNO = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CMD_BILLINGNO = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Lbl_Outstanding = New System.Windows.Forms.Label()
        Me.Grp_Settlement = New System.Windows.Forms.GroupBox()
        Me.Cmd_Settle = New System.Windows.Forms.Button()
        Me.Txt_SettleAmt = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.Rdb_Settle = New System.Windows.Forms.RadioButton()
        Me.Rdb_Refund = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Hall_Display.SuspendLayout()
        CType(Me.sSGrid_HallResv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Veg_Pax.SuspendLayout()
        CType(Me.sSGrid_VPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NV_Pax.SuspendLayout()
        CType(Me.sSGrid_NVPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KotDet.SuspendLayout()
        CType(Me.sSGrid_Kot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Arr_Item.SuspendLayout()
        CType(Me.sSGrid_Arr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Oth_Chgs.SuspendLayout()
        CType(Me.sSGrid_Oth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Grp_Settlement.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Banquet Menu Billing"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_Discount)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Txt_PaidAmt)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CMBBOOKINGTYPE)
        Me.GroupBox1.Controls.Add(Me.Cmd_MCodeHelp)
        Me.GroupBox1.Controls.Add(Me.Cmd_BookingNoHelp)
        Me.GroupBox1.Controls.Add(Me.Dtp_PartyDate)
        Me.GroupBox1.Controls.Add(Me.Dtp_BookingDate)
        Me.GroupBox1.Controls.Add(Me.Txt_GuestName)
        Me.GroupBox1.Controls.Add(Me.Txt_TotPax)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_VPax)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Txt_NVPax)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txt_MemberName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Txt_MemberCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_Purpose)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_BookingNo)
        Me.GroupBox1.Location = New System.Drawing.Point(191, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 174)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Txt_Discount
        '
        Me.Txt_Discount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Discount.Location = New System.Drawing.Point(468, 137)
        Me.Txt_Discount.MaxLength = 10
        Me.Txt_Discount.Name = "Txt_Discount"
        Me.Txt_Discount.Size = New System.Drawing.Size(148, 21)
        Me.Txt_Discount.TabIndex = 226
        Me.Txt_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(354, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 15)
        Me.Label21.TabIndex = 225
        Me.Label21.Text = "Overall Discount"
        '
        'Txt_PaidAmt
        '
        Me.Txt_PaidAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PaidAmt.Location = New System.Drawing.Point(128, 138)
        Me.Txt_PaidAmt.MaxLength = 10
        Me.Txt_PaidAmt.Name = "Txt_PaidAmt"
        Me.Txt_PaidAmt.ReadOnly = True
        Me.Txt_PaidAmt.Size = New System.Drawing.Size(146, 20)
        Me.Txt_PaidAmt.TabIndex = 224
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 223
        Me.Label10.Text = "Paid Amount"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Booking No"
        '
        'CMBBOOKINGTYPE
        '
        Me.CMBBOOKINGTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBBOOKINGTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBOOKINGTYPE.Items.AddRange(New Object() {"BILLING"})
        Me.CMBBOOKINGTYPE.Location = New System.Drawing.Point(276, 85)
        Me.CMBBOOKINGTYPE.MaxDropDownItems = 1
        Me.CMBBOOKINGTYPE.Name = "CMBBOOKINGTYPE"
        Me.CMBBOOKINGTYPE.Size = New System.Drawing.Size(74, 21)
        Me.CMBBOOKINGTYPE.TabIndex = 222
        Me.CMBBOOKINGTYPE.Visible = False
        '
        'Cmd_MCodeHelp
        '
        Me.Cmd_MCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_MCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_MCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_MCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_MCodeHelp.Location = New System.Drawing.Point(276, 60)
        Me.Cmd_MCodeHelp.Name = "Cmd_MCodeHelp"
        Me.Cmd_MCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_MCodeHelp.TabIndex = 221
        Me.Cmd_MCodeHelp.UseVisualStyleBackColor = True
        '
        'Cmd_BookingNoHelp
        '
        Me.Cmd_BookingNoHelp.BackgroundImage = CType(resources.GetObject("Cmd_BookingNoHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_BookingNoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_BookingNoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_BookingNoHelp.Location = New System.Drawing.Point(276, 13)
        Me.Cmd_BookingNoHelp.Name = "Cmd_BookingNoHelp"
        Me.Cmd_BookingNoHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_BookingNoHelp.TabIndex = 220
        Me.Cmd_BookingNoHelp.UseVisualStyleBackColor = True
        '
        'Dtp_PartyDate
        '
        Me.Dtp_PartyDate.Location = New System.Drawing.Point(129, 37)
        Me.Dtp_PartyDate.Name = "Dtp_PartyDate"
        Me.Dtp_PartyDate.Size = New System.Drawing.Size(145, 20)
        Me.Dtp_PartyDate.TabIndex = 137
        '
        'Dtp_BookingDate
        '
        Me.Dtp_BookingDate.Enabled = False
        Me.Dtp_BookingDate.Location = New System.Drawing.Point(468, 16)
        Me.Dtp_BookingDate.Name = "Dtp_BookingDate"
        Me.Dtp_BookingDate.Size = New System.Drawing.Size(145, 20)
        Me.Dtp_BookingDate.TabIndex = 136
        '
        'Txt_GuestName
        '
        Me.Txt_GuestName.Location = New System.Drawing.Point(468, 87)
        Me.Txt_GuestName.MaxLength = 50
        Me.Txt_GuestName.Name = "Txt_GuestName"
        Me.Txt_GuestName.Size = New System.Drawing.Size(146, 20)
        Me.Txt_GuestName.TabIndex = 126
        '
        'Txt_TotPax
        '
        Me.Txt_TotPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TotPax.Location = New System.Drawing.Point(128, 85)
        Me.Txt_TotPax.MaxLength = 10
        Me.Txt_TotPax.Name = "Txt_TotPax"
        Me.Txt_TotPax.ReadOnly = True
        Me.Txt_TotPax.Size = New System.Drawing.Size(146, 20)
        Me.Txt_TotPax.TabIndex = 125
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(354, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 15)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Guest Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 15)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Paxs"
        '
        'Txt_VPax
        '
        Me.Txt_VPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VPax.Location = New System.Drawing.Point(468, 112)
        Me.Txt_VPax.MaxLength = 10
        Me.Txt_VPax.Name = "Txt_VPax"
        Me.Txt_VPax.ReadOnly = True
        Me.Txt_VPax.Size = New System.Drawing.Size(146, 20)
        Me.Txt_VPax.TabIndex = 116
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(354, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Veg Paxs"
        '
        'Txt_NVPax
        '
        Me.Txt_NVPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NVPax.Location = New System.Drawing.Point(128, 111)
        Me.Txt_NVPax.MaxLength = 10
        Me.Txt_NVPax.Name = "Txt_NVPax"
        Me.Txt_NVPax.ReadOnly = True
        Me.Txt_NVPax.Size = New System.Drawing.Size(146, 20)
        Me.Txt_NVPax.TabIndex = 114
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 15)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Non-Veg Paxs"
        '
        'Txt_MemberName
        '
        Me.Txt_MemberName.Location = New System.Drawing.Point(468, 64)
        Me.Txt_MemberName.MaxLength = 50
        Me.Txt_MemberName.Name = "Txt_MemberName"
        Me.Txt_MemberName.Size = New System.Drawing.Size(146, 20)
        Me.Txt_MemberName.TabIndex = 112
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(354, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 15)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Member Name"
        '
        'Txt_MemberCode
        '
        Me.Txt_MemberCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MemberCode.Location = New System.Drawing.Point(128, 61)
        Me.Txt_MemberCode.MaxLength = 15
        Me.Txt_MemberCode.Name = "Txt_MemberCode"
        Me.Txt_MemberCode.Size = New System.Drawing.Size(146, 20)
        Me.Txt_MemberCode.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 15)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Member Code"
        '
        'Txt_Purpose
        '
        Me.Txt_Purpose.Location = New System.Drawing.Point(468, 40)
        Me.Txt_Purpose.MaxLength = 250
        Me.Txt_Purpose.Name = "Txt_Purpose"
        Me.Txt_Purpose.Size = New System.Drawing.Size(146, 20)
        Me.Txt_Purpose.TabIndex = 108
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(354, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Purpose"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Party Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(354, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Booking Date"
        '
        'Txt_BookingNo
        '
        Me.Txt_BookingNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_BookingNo.Location = New System.Drawing.Point(128, 14)
        Me.Txt_BookingNo.MaxLength = 10
        Me.Txt_BookingNo.Name = "Txt_BookingNo"
        Me.Txt_BookingNo.Size = New System.Drawing.Size(146, 20)
        Me.Txt_BookingNo.TabIndex = 102
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Hall_Display)
        Me.TabControl1.Controls.Add(Me.Veg_Pax)
        Me.TabControl1.Controls.Add(Me.NV_Pax)
        Me.TabControl1.Controls.Add(Me.KotDet)
        Me.TabControl1.Controls.Add(Me.Arr_Item)
        Me.TabControl1.Controls.Add(Me.Oth_Chgs)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(191, 293)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 217)
        Me.TabControl1.TabIndex = 6
        '
        'Hall_Display
        '
        Me.Hall_Display.Controls.Add(Me.sSGrid_HallResv)
        Me.Hall_Display.Location = New System.Drawing.Point(4, 24)
        Me.Hall_Display.Name = "Hall_Display"
        Me.Hall_Display.Padding = New System.Windows.Forms.Padding(3)
        Me.Hall_Display.Size = New System.Drawing.Size(649, 189)
        Me.Hall_Display.TabIndex = 0
        Me.Hall_Display.Text = "Hall Display"
        Me.Hall_Display.UseVisualStyleBackColor = True
        '
        'sSGrid_HallResv
        '
        Me.sSGrid_HallResv.DataSource = Nothing
        Me.sSGrid_HallResv.Location = New System.Drawing.Point(8, 7)
        Me.sSGrid_HallResv.Name = "sSGrid_HallResv"
        Me.sSGrid_HallResv.OcxState = CType(resources.GetObject("sSGrid_HallResv.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_HallResv.Size = New System.Drawing.Size(630, 175)
        Me.sSGrid_HallResv.TabIndex = 0
        '
        'Veg_Pax
        '
        Me.Veg_Pax.Controls.Add(Me.sSGrid_VPax)
        Me.Veg_Pax.Controls.Add(Me.Cmd_VMenuCodeHelp)
        Me.Veg_Pax.Controls.Add(Me.Txt_VMaxItem)
        Me.Veg_Pax.Controls.Add(Me.Label15)
        Me.Veg_Pax.Controls.Add(Me.Txt_VMenuDesc)
        Me.Veg_Pax.Controls.Add(Me.Label14)
        Me.Veg_Pax.Controls.Add(Me.Txt_VMenuCode)
        Me.Veg_Pax.Controls.Add(Me.Label13)
        Me.Veg_Pax.Location = New System.Drawing.Point(4, 24)
        Me.Veg_Pax.Name = "Veg_Pax"
        Me.Veg_Pax.Padding = New System.Windows.Forms.Padding(3)
        Me.Veg_Pax.Size = New System.Drawing.Size(649, 189)
        Me.Veg_Pax.TabIndex = 1
        Me.Veg_Pax.Text = "Veg Pax"
        Me.Veg_Pax.UseVisualStyleBackColor = True
        '
        'sSGrid_VPax
        '
        Me.sSGrid_VPax.DataSource = Nothing
        Me.sSGrid_VPax.Location = New System.Drawing.Point(8, 36)
        Me.sSGrid_VPax.Name = "sSGrid_VPax"
        Me.sSGrid_VPax.OcxState = CType(resources.GetObject("sSGrid_VPax.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_VPax.Size = New System.Drawing.Size(629, 145)
        Me.sSGrid_VPax.TabIndex = 222
        '
        'Cmd_VMenuCodeHelp
        '
        Me.Cmd_VMenuCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_VMenuCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_VMenuCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_VMenuCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_VMenuCodeHelp.Enabled = False
        Me.Cmd_VMenuCodeHelp.Location = New System.Drawing.Point(186, 9)
        Me.Cmd_VMenuCodeHelp.Name = "Cmd_VMenuCodeHelp"
        Me.Cmd_VMenuCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_VMenuCodeHelp.TabIndex = 221
        Me.Cmd_VMenuCodeHelp.UseVisualStyleBackColor = True
        '
        'Txt_VMaxItem
        '
        Me.Txt_VMaxItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VMaxItem.Location = New System.Drawing.Point(503, 9)
        Me.Txt_VMaxItem.MaxLength = 10
        Me.Txt_VMaxItem.Name = "Txt_VMaxItem"
        Me.Txt_VMaxItem.Size = New System.Drawing.Size(110, 21)
        Me.Txt_VMaxItem.TabIndex = 121
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(437, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 15)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "Max Item"
        '
        'Txt_VMenuDesc
        '
        Me.Txt_VMenuDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VMenuDesc.Location = New System.Drawing.Point(304, 9)
        Me.Txt_VMenuDesc.MaxLength = 10
        Me.Txt_VMenuDesc.Name = "Txt_VMenuDesc"
        Me.Txt_VMenuDesc.Size = New System.Drawing.Size(126, 21)
        Me.Txt_VMenuDesc.TabIndex = 119
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(228, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 15)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Description"
        '
        'Txt_VMenuCode
        '
        Me.Txt_VMenuCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VMenuCode.Location = New System.Drawing.Point(86, 10)
        Me.Txt_VMenuCode.MaxLength = 10
        Me.Txt_VMenuCode.Name = "Txt_VMenuCode"
        Me.Txt_VMenuCode.Size = New System.Drawing.Size(97, 21)
        Me.Txt_VMenuCode.TabIndex = 117
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 15)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Menu Code"
        '
        'NV_Pax
        '
        Me.NV_Pax.Controls.Add(Me.sSGrid_NVPax)
        Me.NV_Pax.Controls.Add(Me.Cmd_NVMenuCodeHelp)
        Me.NV_Pax.Controls.Add(Me.Txt_NVMaxItem)
        Me.NV_Pax.Controls.Add(Me.Label16)
        Me.NV_Pax.Controls.Add(Me.Txt_NVMenuDesc)
        Me.NV_Pax.Controls.Add(Me.Label17)
        Me.NV_Pax.Controls.Add(Me.Txt_NVMenuCode)
        Me.NV_Pax.Controls.Add(Me.Label18)
        Me.NV_Pax.Location = New System.Drawing.Point(4, 24)
        Me.NV_Pax.Name = "NV_Pax"
        Me.NV_Pax.Size = New System.Drawing.Size(649, 189)
        Me.NV_Pax.TabIndex = 2
        Me.NV_Pax.Text = "Non-Veg Pax"
        Me.NV_Pax.UseVisualStyleBackColor = True
        '
        'sSGrid_NVPax
        '
        Me.sSGrid_NVPax.DataSource = Nothing
        Me.sSGrid_NVPax.Location = New System.Drawing.Point(6, 36)
        Me.sSGrid_NVPax.Name = "sSGrid_NVPax"
        Me.sSGrid_NVPax.OcxState = CType(resources.GetObject("sSGrid_NVPax.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_NVPax.Size = New System.Drawing.Size(633, 145)
        Me.sSGrid_NVPax.TabIndex = 229
        '
        'Cmd_NVMenuCodeHelp
        '
        Me.Cmd_NVMenuCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_NVMenuCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_NVMenuCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_NVMenuCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_NVMenuCodeHelp.Enabled = False
        Me.Cmd_NVMenuCodeHelp.Location = New System.Drawing.Point(189, 8)
        Me.Cmd_NVMenuCodeHelp.Name = "Cmd_NVMenuCodeHelp"
        Me.Cmd_NVMenuCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_NVMenuCodeHelp.TabIndex = 228
        Me.Cmd_NVMenuCodeHelp.UseVisualStyleBackColor = True
        '
        'Txt_NVMaxItem
        '
        Me.Txt_NVMaxItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NVMaxItem.Location = New System.Drawing.Point(506, 8)
        Me.Txt_NVMaxItem.MaxLength = 10
        Me.Txt_NVMaxItem.Name = "Txt_NVMaxItem"
        Me.Txt_NVMaxItem.Size = New System.Drawing.Size(110, 21)
        Me.Txt_NVMaxItem.TabIndex = 227
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(443, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 226
        Me.Label16.Text = "Max Item"
        '
        'Txt_NVMenuDesc
        '
        Me.Txt_NVMenuDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NVMenuDesc.Location = New System.Drawing.Point(307, 8)
        Me.Txt_NVMenuDesc.MaxLength = 10
        Me.Txt_NVMenuDesc.Name = "Txt_NVMenuDesc"
        Me.Txt_NVMenuDesc.Size = New System.Drawing.Size(126, 21)
        Me.Txt_NVMenuDesc.TabIndex = 225
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(232, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 15)
        Me.Label17.TabIndex = 224
        Me.Label17.Text = "Description"
        '
        'Txt_NVMenuCode
        '
        Me.Txt_NVMenuCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NVMenuCode.Location = New System.Drawing.Point(89, 9)
        Me.Txt_NVMenuCode.MaxLength = 10
        Me.Txt_NVMenuCode.Name = "Txt_NVMenuCode"
        Me.Txt_NVMenuCode.Size = New System.Drawing.Size(97, 21)
        Me.Txt_NVMenuCode.TabIndex = 223
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 15)
        Me.Label18.TabIndex = 222
        Me.Label18.Text = "Menu Code"
        '
        'KotDet
        '
        Me.KotDet.Controls.Add(Me.sSGrid_Kot)
        Me.KotDet.Location = New System.Drawing.Point(4, 24)
        Me.KotDet.Name = "KotDet"
        Me.KotDet.Size = New System.Drawing.Size(649, 189)
        Me.KotDet.TabIndex = 3
        Me.KotDet.Text = "Kot Details"
        Me.KotDet.UseVisualStyleBackColor = True
        '
        'sSGrid_Kot
        '
        Me.sSGrid_Kot.DataSource = Nothing
        Me.sSGrid_Kot.Location = New System.Drawing.Point(9, 7)
        Me.sSGrid_Kot.Name = "sSGrid_Kot"
        Me.sSGrid_Kot.OcxState = CType(resources.GetObject("sSGrid_Kot.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_Kot.Size = New System.Drawing.Size(629, 174)
        Me.sSGrid_Kot.TabIndex = 0
        '
        'Arr_Item
        '
        Me.Arr_Item.Controls.Add(Me.sSGrid_Arr)
        Me.Arr_Item.Location = New System.Drawing.Point(4, 24)
        Me.Arr_Item.Name = "Arr_Item"
        Me.Arr_Item.Size = New System.Drawing.Size(649, 189)
        Me.Arr_Item.TabIndex = 4
        Me.Arr_Item.Text = "Arrangement Item"
        Me.Arr_Item.UseVisualStyleBackColor = True
        '
        'sSGrid_Arr
        '
        Me.sSGrid_Arr.DataSource = Nothing
        Me.sSGrid_Arr.Location = New System.Drawing.Point(9, 9)
        Me.sSGrid_Arr.Name = "sSGrid_Arr"
        Me.sSGrid_Arr.OcxState = CType(resources.GetObject("sSGrid_Arr.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_Arr.Size = New System.Drawing.Size(628, 169)
        Me.sSGrid_Arr.TabIndex = 0
        '
        'Oth_Chgs
        '
        Me.Oth_Chgs.Controls.Add(Me.sSGrid_Oth)
        Me.Oth_Chgs.Location = New System.Drawing.Point(4, 24)
        Me.Oth_Chgs.Name = "Oth_Chgs"
        Me.Oth_Chgs.Size = New System.Drawing.Size(649, 189)
        Me.Oth_Chgs.TabIndex = 5
        Me.Oth_Chgs.Text = "Other Charges"
        Me.Oth_Chgs.UseVisualStyleBackColor = True
        '
        'sSGrid_Oth
        '
        Me.sSGrid_Oth.DataSource = Nothing
        Me.sSGrid_Oth.Location = New System.Drawing.Point(7, 7)
        Me.sSGrid_Oth.Name = "sSGrid_Oth"
        Me.sSGrid_Oth.OcxState = CType(resources.GetObject("sSGrid_Oth.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_Oth.Size = New System.Drawing.Size(631, 175)
        Me.sSGrid_Oth.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Cmd_Settlement)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Cmdbwse)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.Cmdview)
        Me.GroupBox4.Controls.Add(Me.cmdreport)
        Me.GroupBox4.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(857, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 472)
        Me.GroupBox4.TabIndex = 126
        Me.GroupBox4.TabStop = False
        '
        'Cmd_Settlement
        '
        Me.Cmd_Settlement.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Settlement.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Settlement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Settlement.Location = New System.Drawing.Point(5, 417)
        Me.Cmd_Settlement.Name = "Cmd_Settlement"
        Me.Cmd_Settlement.Size = New System.Drawing.Size(143, 47)
        Me.Cmd_Settlement.TabIndex = 885
        Me.Cmd_Settlement.Text = "SETTLEMENT"
        Me.Cmd_Settlement.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Gainsboro
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button5.Location = New System.Drawing.Point(5, 364)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(143, 47)
        Me.Button5.TabIndex = 884
        Me.Button5.Text = "POST"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(4, 246)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 55)
        Me.Cmdbwse.TabIndex = 165
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(4, 305)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 55)
        Me.cmdexit.TabIndex = 167
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(4, 187)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 55)
        Me.Cmdview.TabIndex = 164
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(4, 247)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 55)
        Me.cmdreport.TabIndex = 168
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        Me.cmdreport.Visible = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(4, 129)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 55)
        Me.Cmd_Freeze.TabIndex = 163
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
        Me.CmdClear.Location = New System.Drawing.Point(4, 70)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 55)
        Me.CmdClear.TabIndex = 162
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
        Me.CmdAdd.Location = New System.Drawing.Point(4, 12)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 55)
        Me.CmdAdd.TabIndex = 161
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'Cmb_Location
        '
        Me.Cmb_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Location.Location = New System.Drawing.Point(923, 76)
        Me.Cmb_Location.Name = "Cmb_Location"
        Me.Cmb_Location.Size = New System.Drawing.Size(82, 23)
        Me.Cmb_Location.TabIndex = 851
        Me.Cmb_Location.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(563, 44)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(210, 19)
        Me.lbl_Freeze.TabIndex = 852
        Me.lbl_Freeze.Text = "BOOKING  IS CANCELLED"
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'TXTBILLINGNO
        '
        Me.TXTBILLINGNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBILLINGNO.Location = New System.Drawing.Point(659, 70)
        Me.TXTBILLINGNO.MaxLength = 10
        Me.TXTBILLINGNO.Name = "TXTBILLINGNO"
        Me.TXTBILLINGNO.Size = New System.Drawing.Size(146, 20)
        Me.TXTBILLINGNO.TabIndex = 853
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(615, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 15)
        Me.Label19.TabIndex = 854
        Me.Label19.Text = "Bill No"
        '
        'CMD_BILLINGNO
        '
        Me.CMD_BILLINGNO.Image = CType(resources.GetObject("CMD_BILLINGNO.Image"), System.Drawing.Image)
        Me.CMD_BILLINGNO.Location = New System.Drawing.Point(807, 68)
        Me.CMD_BILLINGNO.Name = "CMD_BILLINGNO"
        Me.CMD_BILLINGNO.Size = New System.Drawing.Size(23, 22)
        Me.CMD_BILLINGNO.TabIndex = 855
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(703, 518)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(141, 15)
        Me.Label20.TabIndex = 856
        Me.Label20.Text = "Press Alt+R For Receipt"
        '
        'Lbl_Outstanding
        '
        Me.Lbl_Outstanding.AutoSize = True
        Me.Lbl_Outstanding.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Outstanding.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Outstanding.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Outstanding.Location = New System.Drawing.Point(188, 581)
        Me.Lbl_Outstanding.Name = "Lbl_Outstanding"
        Me.Lbl_Outstanding.Size = New System.Drawing.Size(36, 19)
        Me.Lbl_Outstanding.TabIndex = 857
        Me.Lbl_Outstanding.Text = "Out"
        '
        'Grp_Settlement
        '
        Me.Grp_Settlement.Controls.Add(Me.Cmd_Settle)
        Me.Grp_Settlement.Controls.Add(Me.Txt_SettleAmt)
        Me.Grp_Settlement.Controls.Add(Me.Label23)
        Me.Grp_Settlement.Controls.Add(Me.Label22)
        Me.Grp_Settlement.Controls.Add(Me.Cbo_PaymentMode)
        Me.Grp_Settlement.Controls.Add(Me.Rdb_Settle)
        Me.Grp_Settlement.Controls.Add(Me.Rdb_Refund)
        Me.Grp_Settlement.Location = New System.Drawing.Point(285, 294)
        Me.Grp_Settlement.Name = "Grp_Settlement"
        Me.Grp_Settlement.Size = New System.Drawing.Size(502, 118)
        Me.Grp_Settlement.TabIndex = 858
        Me.Grp_Settlement.TabStop = False
        Me.Grp_Settlement.Text = "Settlement"
        '
        'Cmd_Settle
        '
        Me.Cmd_Settle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Settle.Location = New System.Drawing.Point(271, 74)
        Me.Cmd_Settle.Name = "Cmd_Settle"
        Me.Cmd_Settle.Size = New System.Drawing.Size(125, 32)
        Me.Cmd_Settle.TabIndex = 245
        Me.Cmd_Settle.Text = "Make Settlement"
        Me.Cmd_Settle.UseVisualStyleBackColor = True
        '
        'Txt_SettleAmt
        '
        Me.Txt_SettleAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SettleAmt.Location = New System.Drawing.Point(120, 73)
        Me.Txt_SettleAmt.MaxLength = 10
        Me.Txt_SettleAmt.Name = "Txt_SettleAmt"
        Me.Txt_SettleAmt.Size = New System.Drawing.Size(142, 20)
        Me.Txt_SettleAmt.TabIndex = 244
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(22, 74)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 15)
        Me.Label23.TabIndex = 243
        Me.Label23.Text = "Amount"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(22, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 15)
        Me.Label22.TabIndex = 231
        Me.Label22.Text = "Payment Mode"
        '
        'Cbo_PaymentMode
        '
        Me.Cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_PaymentMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_PaymentMode.Items.AddRange(New Object() {"BOOKING"})
        Me.Cbo_PaymentMode.Location = New System.Drawing.Point(119, 41)
        Me.Cbo_PaymentMode.MaxDropDownItems = 1
        Me.Cbo_PaymentMode.Name = "Cbo_PaymentMode"
        Me.Cbo_PaymentMode.Size = New System.Drawing.Size(145, 21)
        Me.Cbo_PaymentMode.TabIndex = 230
        '
        'Rdb_Settle
        '
        Me.Rdb_Settle.AutoSize = True
        Me.Rdb_Settle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_Settle.Location = New System.Drawing.Point(411, 16)
        Me.Rdb_Settle.Name = "Rdb_Settle"
        Me.Rdb_Settle.Size = New System.Drawing.Size(85, 17)
        Me.Rdb_Settle.TabIndex = 1
        Me.Rdb_Settle.TabStop = True
        Me.Rdb_Settle.Text = "Settlement"
        Me.Rdb_Settle.UseVisualStyleBackColor = True
        '
        'Rdb_Refund
        '
        Me.Rdb_Refund.AutoSize = True
        Me.Rdb_Refund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_Refund.Location = New System.Drawing.Point(330, 16)
        Me.Rdb_Refund.Name = "Rdb_Refund"
        Me.Rdb_Refund.Size = New System.Drawing.Size(66, 17)
        Me.Rdb_Refund.TabIndex = 0
        Me.Rdb_Refund.TabStop = True
        Me.Rdb_Refund.Text = "Refund"
        Me.Rdb_Refund.UseVisualStyleBackColor = True
        '
        'Frm_T_BanMenuBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1023, 741)
        Me.Controls.Add(Me.Grp_Settlement)
        Me.Controls.Add(Me.Lbl_Outstanding)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.CMD_BILLINGNO)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TXTBILLINGNO)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmb_Location)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_T_BanMenuBilling"
        Me.Text = "Frm_T_BanMenuBooking"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Hall_Display.ResumeLayout(False)
        CType(Me.sSGrid_HallResv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Veg_Pax.ResumeLayout(False)
        Me.Veg_Pax.PerformLayout()
        CType(Me.sSGrid_VPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NV_Pax.ResumeLayout(False)
        Me.NV_Pax.PerformLayout()
        CType(Me.sSGrid_NVPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KotDet.ResumeLayout(False)
        CType(Me.sSGrid_Kot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Arr_Item.ResumeLayout(False)
        CType(Me.sSGrid_Arr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Oth_Chgs.ResumeLayout(False)
        CType(Me.sSGrid_Oth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Grp_Settlement.ResumeLayout(False)
        Me.Grp_Settlement.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKINGTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_MCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_BookingNoHelp As System.Windows.Forms.Button
    Friend WithEvents Dtp_PartyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_BookingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_GuestName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TotPax As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_VPax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_NVPax As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Purpose As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_BookingNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PaidAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Hall_Display As System.Windows.Forms.TabPage
    Friend WithEvents Veg_Pax As System.Windows.Forms.TabPage
    Friend WithEvents NV_Pax As System.Windows.Forms.TabPage
    Friend WithEvents KotDet As System.Windows.Forms.TabPage
    Friend WithEvents Arr_Item As System.Windows.Forms.TabPage
    Friend WithEvents Oth_Chgs As System.Windows.Forms.TabPage
    Friend WithEvents sSGrid_HallResv As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Txt_VMaxItem As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txt_VMenuDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Txt_VMenuCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Cmd_VMenuCodeHelp As System.Windows.Forms.Button
    Friend WithEvents sSGrid_VPax As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_NVMenuCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_NVMaxItem As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_NVMenuDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_NVMenuCode As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents sSGrid_NVPax As AxFPSpreadADO.AxfpSpread
    Friend WithEvents sSGrid_Arr As AxFPSpreadADO.AxfpSpread
    Friend WithEvents sSGrid_Oth As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Cmb_Location As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents sSGrid_Kot As AxFPSpreadADO.AxfpSpread
    Friend WithEvents TXTBILLINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CMD_BILLINGNO As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Txt_Discount As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Outstanding As System.Windows.Forms.Label
    Friend WithEvents Cmd_Settlement As System.Windows.Forms.Button
    Friend WithEvents Grp_Settlement As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_Settle As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Refund As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_SettleAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Settle As System.Windows.Forms.Button
End Class
