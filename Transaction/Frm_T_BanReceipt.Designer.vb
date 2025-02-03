<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_T_BanReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_T_BanReceipt))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_AdvAmt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cmd_RecNoHelp = New System.Windows.Forms.Button()
        Me.Txt_GuestName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_MemberName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cbo_RecType = New System.Windows.Forms.ComboBox()
        Me.Dtp_RecDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_RecNo = New System.Windows.Forms.TextBox()
        Me.Dtp_PartyDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd_BookingNoHelp = New System.Windows.Forms.Button()
        Me.Txt_BookingNo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dgvBox = New System.Windows.Forms.DataGridView()
        Me.Txt_Amount = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.sSGrid = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.BankDet = New System.Windows.Forms.Panel()
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
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Chk_Prev = New System.Windows.Forms.CheckBox()
        Me.Lbl_Outstanding = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.BankDet.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Banquet Receipt Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_AdvAmt)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Cmd_RecNoHelp)
        Me.GroupBox1.Controls.Add(Me.Txt_GuestName)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Txt_MemberName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txt_MemberCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Cbo_RecType)
        Me.GroupBox1.Controls.Add(Me.Dtp_RecDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cbo_PaymentMode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_RecNo)
        Me.GroupBox1.Controls.Add(Me.Dtp_PartyDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Cmd_BookingNoHelp)
        Me.GroupBox1.Controls.Add(Me.Txt_BookingNo)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(641, 154)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Txt_AdvAmt
        '
        Me.Txt_AdvAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AdvAmt.Location = New System.Drawing.Point(145, 126)
        Me.Txt_AdvAmt.MaxLength = 10
        Me.Txt_AdvAmt.Name = "Txt_AdvAmt"
        Me.Txt_AdvAmt.Size = New System.Drawing.Size(85, 20)
        Me.Txt_AdvAmt.TabIndex = 242
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 15)
        Me.Label10.TabIndex = 241
        Me.Label10.Text = "Amount For Advance"
        '
        'Cmd_RecNoHelp
        '
        Me.Cmd_RecNoHelp.BackgroundImage = CType(resources.GetObject("Cmd_RecNoHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_RecNoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_RecNoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_RecNoHelp.Location = New System.Drawing.Point(281, 40)
        Me.Cmd_RecNoHelp.Name = "Cmd_RecNoHelp"
        Me.Cmd_RecNoHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_RecNoHelp.TabIndex = 240
        Me.Cmd_RecNoHelp.UseVisualStyleBackColor = True
        '
        'Txt_GuestName
        '
        Me.Txt_GuestName.Location = New System.Drawing.Point(472, 122)
        Me.Txt_GuestName.MaxLength = 50
        Me.Txt_GuestName.Name = "Txt_GuestName"
        Me.Txt_GuestName.ReadOnly = True
        Me.Txt_GuestName.Size = New System.Drawing.Size(146, 20)
        Me.Txt_GuestName.TabIndex = 239
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(358, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 15)
        Me.Label12.TabIndex = 238
        Me.Label12.Text = "Guest Name"
        '
        'Txt_MemberName
        '
        Me.Txt_MemberName.Location = New System.Drawing.Point(472, 96)
        Me.Txt_MemberName.MaxLength = 50
        Me.Txt_MemberName.Name = "Txt_MemberName"
        Me.Txt_MemberName.ReadOnly = True
        Me.Txt_MemberName.Size = New System.Drawing.Size(146, 20)
        Me.Txt_MemberName.TabIndex = 237
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(358, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 15)
        Me.Label8.TabIndex = 236
        Me.Label8.Text = "Member Name"
        '
        'Txt_MemberCode
        '
        Me.Txt_MemberCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MemberCode.Location = New System.Drawing.Point(132, 93)
        Me.Txt_MemberCode.MaxLength = 15
        Me.Txt_MemberCode.Name = "Txt_MemberCode"
        Me.Txt_MemberCode.ReadOnly = True
        Me.Txt_MemberCode.Size = New System.Drawing.Size(146, 20)
        Me.Txt_MemberCode.TabIndex = 235
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 15)
        Me.Label9.TabIndex = 234
        Me.Label9.Text = "Member Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(356, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "Receipt Type"
        '
        'Cbo_RecType
        '
        Me.Cbo_RecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_RecType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_RecType.Items.AddRange(New Object() {"ADVANCE", "DEPOSIT", "REFUND", "SETTLEMENT"})
        Me.Cbo_RecType.Location = New System.Drawing.Point(474, 68)
        Me.Cbo_RecType.MaxDropDownItems = 1
        Me.Cbo_RecType.Name = "Cbo_RecType"
        Me.Cbo_RecType.Size = New System.Drawing.Size(145, 21)
        Me.Cbo_RecType.TabIndex = 232
        '
        'Dtp_RecDate
        '
        Me.Dtp_RecDate.Location = New System.Drawing.Point(134, 67)
        Me.Dtp_RecDate.Name = "Dtp_RecDate"
        Me.Dtp_RecDate.Size = New System.Drawing.Size(145, 20)
        Me.Dtp_RecDate.TabIndex = 231
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "Receipt Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(356, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 229
        Me.Label4.Text = "Payment Mode"
        '
        'Cbo_PaymentMode
        '
        Me.Cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_PaymentMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_PaymentMode.Items.AddRange(New Object() {"BOOKING"})
        Me.Cbo_PaymentMode.Location = New System.Drawing.Point(474, 38)
        Me.Cbo_PaymentMode.MaxDropDownItems = 1
        Me.Cbo_PaymentMode.Name = "Cbo_PaymentMode"
        Me.Cbo_PaymentMode.Size = New System.Drawing.Size(145, 21)
        Me.Cbo_PaymentMode.TabIndex = 228
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Receipt Number"
        '
        'Txt_RecNo
        '
        Me.Txt_RecNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_RecNo.Location = New System.Drawing.Point(133, 40)
        Me.Txt_RecNo.MaxLength = 20
        Me.Txt_RecNo.Name = "Txt_RecNo"
        Me.Txt_RecNo.Size = New System.Drawing.Size(146, 20)
        Me.Txt_RecNo.TabIndex = 227
        '
        'Dtp_PartyDate
        '
        Me.Dtp_PartyDate.Enabled = False
        Me.Dtp_PartyDate.Location = New System.Drawing.Point(474, 12)
        Me.Dtp_PartyDate.Name = "Dtp_PartyDate"
        Me.Dtp_PartyDate.Size = New System.Drawing.Size(145, 20)
        Me.Dtp_PartyDate.TabIndex = 225
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(355, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Party Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 221
        Me.Label6.Text = "Booking No"
        '
        'Cmd_BookingNoHelp
        '
        Me.Cmd_BookingNoHelp.BackgroundImage = CType(resources.GetObject("Cmd_BookingNoHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_BookingNoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_BookingNoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_BookingNoHelp.Location = New System.Drawing.Point(281, 14)
        Me.Cmd_BookingNoHelp.Name = "Cmd_BookingNoHelp"
        Me.Cmd_BookingNoHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_BookingNoHelp.TabIndex = 223
        Me.Cmd_BookingNoHelp.UseVisualStyleBackColor = True
        '
        'Txt_BookingNo
        '
        Me.Txt_BookingNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_BookingNo.Location = New System.Drawing.Point(133, 14)
        Me.Txt_BookingNo.MaxLength = 10
        Me.Txt_BookingNo.Name = "Txt_BookingNo"
        Me.Txt_BookingNo.Size = New System.Drawing.Size(146, 20)
        Me.Txt_BookingNo.TabIndex = 222
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.dgvBox)
        Me.GroupBox2.Controls.Add(Me.Txt_Amount)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.sSGrid)
        Me.GroupBox2.Location = New System.Drawing.Point(189, 270)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(640, 311)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(166, 15)
        Me.Label20.TabIndex = 857
        Me.Label20.Text = "Press Alt+B For Menu Billing"
        '
        'dgvBox
        '
        Me.dgvBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBox.Location = New System.Drawing.Point(14, 213)
        Me.dgvBox.Name = "dgvBox"
        Me.dgvBox.Size = New System.Drawing.Size(604, 93)
        Me.dgvBox.TabIndex = 849
        '
        'Txt_Amount
        '
        Me.Txt_Amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Amount.Location = New System.Drawing.Point(500, 187)
        Me.Txt_Amount.MaxLength = 10
        Me.Txt_Amount.Name = "Txt_Amount"
        Me.Txt_Amount.Size = New System.Drawing.Size(103, 21)
        Me.Txt_Amount.TabIndex = 131
        Me.Txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(445, 191)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = "Amount"
        '
        'sSGrid
        '
        Me.sSGrid.DataSource = Nothing
        Me.sSGrid.Location = New System.Drawing.Point(14, 15)
        Me.sSGrid.Name = "sSGrid"
        Me.sSGrid.OcxState = CType(resources.GetObject("sSGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid.Size = New System.Drawing.Size(605, 166)
        Me.sSGrid.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.Cmdbwse)
        Me.GroupBox4.Controls.Add(Me.Cmdview)
        Me.GroupBox4.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(857, 111)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 384)
        Me.GroupBox4.TabIndex = 126
        Me.GroupBox4.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(4, 310)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 55)
        Me.cmdexit.TabIndex = 167
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(4, 250)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 55)
        Me.Cmdbwse.TabIndex = 165
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(4, 188)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 55)
        Me.Cmdview.TabIndex = 164
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
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
        'BankDet
        '
        Me.BankDet.BackColor = System.Drawing.Color.Transparent
        Me.BankDet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BankDet.Controls.Add(Me.Txt_city)
        Me.BankDet.Controls.Add(Me.Label24)
        Me.BankDet.Controls.Add(Me.TXT_CARDNO)
        Me.BankDet.Controls.Add(Me.INS_DATE)
        Me.BankDet.Controls.Add(Me.TXT_DRAWEEBANK)
        Me.BankDet.Controls.Add(Me.Label17)
        Me.BankDet.Controls.Add(Me.Label18)
        Me.BankDet.Controls.Add(Me.TXT_INSNO)
        Me.BankDet.Controls.Add(Me.Label19)
        Me.BankDet.Controls.Add(Me.INS_TYPE)
        Me.BankDet.Controls.Add(Me.Label21)
        Me.BankDet.Controls.Add(Me.LBL_CARD)
        Me.BankDet.Location = New System.Drawing.Point(187, 608)
        Me.BankDet.Name = "BankDet"
        Me.BankDet.Size = New System.Drawing.Size(643, 97)
        Me.BankDet.TabIndex = 846
        '
        'Txt_city
        '
        Me.Txt_city.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_city.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_city.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_city.Location = New System.Drawing.Point(131, 59)
        Me.Txt_city.MaxLength = 50
        Me.Txt_city.Name = "Txt_city"
        Me.Txt_city.Size = New System.Drawing.Size(146, 20)
        Me.Txt_city.TabIndex = 617
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(13, 56)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 20)
        Me.Label24.TabIndex = 616
        Me.Label24.Text = "PLACE"
        '
        'TXT_CARDNO
        '
        Me.TXT_CARDNO.BackColor = System.Drawing.SystemColors.Window
        Me.TXT_CARDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CARDNO.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CARDNO.Location = New System.Drawing.Point(133, 8)
        Me.TXT_CARDNO.MaxLength = 25
        Me.TXT_CARDNO.Name = "TXT_CARDNO"
        Me.TXT_CARDNO.Size = New System.Drawing.Size(146, 20)
        Me.TXT_CARDNO.TabIndex = 849
        Me.TXT_CARDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_CARDNO.Visible = False
        '
        'INS_DATE
        '
        Me.INS_DATE.CalendarFont = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.CustomFormat = "dd/MM/yyyy "
        Me.INS_DATE.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.INS_DATE.Location = New System.Drawing.Point(484, 32)
        Me.INS_DATE.Name = "INS_DATE"
        Me.INS_DATE.Size = New System.Drawing.Size(146, 20)
        Me.INS_DATE.TabIndex = 615
        '
        'TXT_DRAWEEBANK
        '
        Me.TXT_DRAWEEBANK.BackColor = System.Drawing.SystemColors.Window
        Me.TXT_DRAWEEBANK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DRAWEEBANK.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DRAWEEBANK.Location = New System.Drawing.Point(484, 58)
        Me.TXT_DRAWEEBANK.MaxLength = 50
        Me.TXT_DRAWEEBANK.Name = "TXT_DRAWEEBANK"
        Me.TXT_DRAWEEBANK.Size = New System.Drawing.Size(146, 20)
        Me.TXT_DRAWEEBANK.TabIndex = 614
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(352, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 20)
        Me.Label17.TabIndex = 613
        Me.Label17.Text = "DRAWEE BANK"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(352, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 20)
        Me.Label18.TabIndex = 612
        Me.Label18.Text = "INSTR. DATE"
        '
        'TXT_INSNO
        '
        Me.TXT_INSNO.BackColor = System.Drawing.SystemColors.Window
        Me.TXT_INSNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_INSNO.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_INSNO.Location = New System.Drawing.Point(132, 34)
        Me.TXT_INSNO.MaxLength = 10
        Me.TXT_INSNO.Name = "TXT_INSNO"
        Me.TXT_INSNO.Size = New System.Drawing.Size(146, 20)
        Me.TXT_INSNO.TabIndex = 610
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 20)
        Me.Label19.TabIndex = 609
        Me.Label19.Text = "INST. NO"
        '
        'INS_TYPE
        '
        Me.INS_TYPE.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_TYPE.Items.AddRange(New Object() {"CARD", "CHEQUE", "DD", "PO"})
        Me.INS_TYPE.Location = New System.Drawing.Point(484, 6)
        Me.INS_TYPE.Name = "INS_TYPE"
        Me.INS_TYPE.Size = New System.Drawing.Size(146, 22)
        Me.INS_TYPE.TabIndex = 607
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(352, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(129, 20)
        Me.Label21.TabIndex = 608
        Me.Label21.Text = "INSTR. TYPE"
        '
        'LBL_CARD
        '
        Me.LBL_CARD.BackColor = System.Drawing.Color.Transparent
        Me.LBL_CARD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CARD.Location = New System.Drawing.Point(11, 9)
        Me.LBL_CARD.Name = "LBL_CARD"
        Me.LBL_CARD.Size = New System.Drawing.Size(80, 20)
        Me.LBL_CARD.TabIndex = 848
        Me.LBL_CARD.Text = "CARD. NO "
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(533, 46)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(187, 18)
        Me.lbl_Freeze.TabIndex = 420
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Chk_Prev
        '
        Me.Chk_Prev.AutoSize = True
        Me.Chk_Prev.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Prev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Prev.Location = New System.Drawing.Point(627, 69)
        Me.Chk_Prev.Name = "Chk_Prev"
        Me.Chk_Prev.Size = New System.Drawing.Size(229, 19)
        Me.Chk_Prev.TabIndex = 847
        Me.Chk_Prev.Text = "Booking No From Previous Year"
        Me.Chk_Prev.UseVisualStyleBackColor = False
        '
        'Lbl_Outstanding
        '
        Me.Lbl_Outstanding.AutoSize = True
        Me.Lbl_Outstanding.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Outstanding.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Outstanding.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Outstanding.Location = New System.Drawing.Point(187, 585)
        Me.Lbl_Outstanding.Name = "Lbl_Outstanding"
        Me.Lbl_Outstanding.Size = New System.Drawing.Size(36, 19)
        Me.Lbl_Outstanding.TabIndex = 858
        Me.Lbl_Outstanding.Text = "Out"
        '
        'Frm_T_BanReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1020, 741)
        Me.Controls.Add(Me.Lbl_Outstanding)
        Me.Controls.Add(Me.Chk_Prev)
        Me.Controls.Add(Me.BankDet)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_T_BanReceipt"
        Me.Text = "Frm_T_BanReceipt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.BankDet.ResumeLayout(False)
        Me.BankDet.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_BookingNoHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_BookingNo As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_PartyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_RecNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents Dtp_RecDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cbo_RecType As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_GuestName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents sSGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents BankDet As System.Windows.Forms.Panel
    Friend WithEvents Txt_city As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TXT_CARDNO As System.Windows.Forms.TextBox
    Friend WithEvents INS_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXT_DRAWEEBANK As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXT_INSNO As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents INS_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LBL_CARD As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Txt_Amount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmd_RecNoHelp As System.Windows.Forms.Button
    Friend WithEvents Chk_Prev As System.Windows.Forms.CheckBox
    Friend WithEvents dgvBox As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_AdvAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Outstanding As System.Windows.Forms.Label
End Class
