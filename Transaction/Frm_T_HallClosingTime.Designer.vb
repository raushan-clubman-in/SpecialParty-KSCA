<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_T_HallClosingTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_T_HallClosingTime))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_PartyDay = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBBOOKINGTYPE = New System.Windows.Forms.ComboBox()
        Me.Cmd_MCodeHelp = New System.Windows.Forms.Button()
        Me.Cmd_BookingNoHelp = New System.Windows.Forms.Button()
        Me.Dtp_PartyDate = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_BookingDate = New System.Windows.Forms.DateTimePicker()
        Me.Txt_CellNo = New System.Windows.Forms.TextBox()
        Me.Txt_GuestName = New System.Windows.Forms.TextBox()
        Me.Txt_TotPax = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Email = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.Hall_Reservation = New System.Windows.Forms.TabPage()
        Me.sSGrid_HallReserv = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Cmb_Location = New System.Windows.Forms.ComboBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Hall_Reservation.SuspendLayout()
        CType(Me.sSGrid_HallReserv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Banquet Closing Time Updation"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Lbl_PartyDay)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CMBBOOKINGTYPE)
        Me.GroupBox1.Controls.Add(Me.Cmd_MCodeHelp)
        Me.GroupBox1.Controls.Add(Me.Cmd_BookingNoHelp)
        Me.GroupBox1.Controls.Add(Me.Dtp_PartyDate)
        Me.GroupBox1.Controls.Add(Me.Dtp_BookingDate)
        Me.GroupBox1.Controls.Add(Me.Txt_CellNo)
        Me.GroupBox1.Controls.Add(Me.Txt_GuestName)
        Me.GroupBox1.Controls.Add(Me.Txt_TotPax)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_Email)
        Me.GroupBox1.Controls.Add(Me.Label10)
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
        Me.GroupBox1.Location = New System.Drawing.Point(189, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 161)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Lbl_PartyDay
        '
        Me.Lbl_PartyDay.AutoSize = True
        Me.Lbl_PartyDay.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PartyDay.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PartyDay.Location = New System.Drawing.Point(274, 40)
        Me.Lbl_PartyDay.Name = "Lbl_PartyDay"
        Me.Lbl_PartyDay.Size = New System.Drawing.Size(62, 15)
        Me.Lbl_PartyDay.TabIndex = 846
        Me.Lbl_PartyDay.Text = "Day Name"
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
        Me.CMBBOOKINGTYPE.Items.AddRange(New Object() {"BOOKING"})
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
        'Txt_CellNo
        '
        Me.Txt_CellNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CellNo.Location = New System.Drawing.Point(128, 109)
        Me.Txt_CellNo.MaxLength = 10
        Me.Txt_CellNo.Name = "Txt_CellNo"
        Me.Txt_CellNo.Size = New System.Drawing.Size(146, 20)
        Me.Txt_CellNo.TabIndex = 127
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 15)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "Cell No"
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
        'Txt_Email
        '
        Me.Txt_Email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Email.Location = New System.Drawing.Point(468, 110)
        Me.Txt_Email.MaxLength = 50
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Size = New System.Drawing.Size(146, 20)
        Me.Txt_Email.TabIndex = 118
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(354, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 15)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "E-mail"
        '
        'Txt_VPax
        '
        Me.Txt_VPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VPax.Location = New System.Drawing.Point(468, 133)
        Me.Txt_VPax.MaxLength = 10
        Me.Txt_VPax.Name = "Txt_VPax"
        Me.Txt_VPax.Size = New System.Drawing.Size(146, 20)
        Me.Txt_VPax.TabIndex = 116
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(354, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Veg Paxs"
        '
        'Txt_NVPax
        '
        Me.Txt_NVPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NVPax.Location = New System.Drawing.Point(128, 132)
        Me.Txt_NVPax.MaxLength = 10
        Me.Txt_NVPax.Name = "Txt_NVPax"
        Me.Txt_NVPax.Size = New System.Drawing.Size(146, 20)
        Me.Txt_NVPax.TabIndex = 114
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 133)
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
        Me.TabControl1.Controls.Add(Me.Hall_Reservation)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(194, 279)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 224)
        Me.TabControl1.TabIndex = 5
        '
        'Hall_Reservation
        '
        Me.Hall_Reservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Hall_Reservation.Controls.Add(Me.sSGrid_HallReserv)
        Me.Hall_Reservation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hall_Reservation.Location = New System.Drawing.Point(4, 25)
        Me.Hall_Reservation.Name = "Hall_Reservation"
        Me.Hall_Reservation.Padding = New System.Windows.Forms.Padding(3)
        Me.Hall_Reservation.Size = New System.Drawing.Size(649, 195)
        Me.Hall_Reservation.TabIndex = 0
        Me.Hall_Reservation.Text = "Hall Reservation"
        Me.Hall_Reservation.UseVisualStyleBackColor = True
        '
        'sSGrid_HallReserv
        '
        Me.sSGrid_HallReserv.DataSource = Nothing
        Me.sSGrid_HallReserv.Location = New System.Drawing.Point(6, 5)
        Me.sSGrid_HallReserv.Name = "sSGrid_HallReserv"
        Me.sSGrid_HallReserv.OcxState = CType(resources.GetObject("sSGrid_HallReserv.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_HallReserv.Size = New System.Drawing.Size(634, 182)
        Me.sSGrid_HallReserv.TabIndex = 0
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
        Me.GroupBox4.Location = New System.Drawing.Point(857, 109)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 257)
        Me.GroupBox4.TabIndex = 125
        Me.GroupBox4.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(4, 129)
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
        Me.Cmdbwse.Location = New System.Drawing.Point(4, 188)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 55)
        Me.Cmdbwse.TabIndex = 165
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        Me.Cmdbwse.Visible = False
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(4, 129)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 55)
        Me.Cmdview.TabIndex = 164
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
        Me.Cmdview.Visible = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Enabled = False
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
        Me.Cmb_Location.Location = New System.Drawing.Point(764, 80)
        Me.Cmb_Location.Name = "Cmb_Location"
        Me.Cmb_Location.Size = New System.Drawing.Size(82, 23)
        Me.Cmb_Location.TabIndex = 850
        Me.Cmb_Location.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(616, 43)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 16)
        Me.lbl_Freeze.TabIndex = 851
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Frm_T_HallClosingTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1015, 743)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmb_Location)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_T_HallClosingTime"
        Me.Text = "Frm_T_HallClosingTime"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Hall_Reservation.ResumeLayout(False)
        CType(Me.sSGrid_HallReserv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_CellNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GuestName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TotPax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Email As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dtp_PartyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_BookingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Hall_Reservation As System.Windows.Forms.TabPage
    Friend WithEvents sSGrid_HallReserv As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Cmd_MCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_BookingNoHelp As System.Windows.Forms.Button
    Friend WithEvents CMBBOOKINGTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_Location As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_PartyDay As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
End Class
