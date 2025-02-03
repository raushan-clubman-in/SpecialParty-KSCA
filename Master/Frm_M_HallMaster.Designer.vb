<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_M_HallMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_M_HallMaster))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_HallCodeHelp = New System.Windows.Forms.Button()
        Me.Cbo_OSFoodAllow = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cbo_HRentOveride = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_SecDeposit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_ActCapacity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_MaxCapacity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_MinCapacity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_HallDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_HallCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.sSGrid_TimeSlot = New AxFPSpreadADO.AxfpSpread()
        Me.Txt_HalfDayHourRate = New System.Windows.Forms.TextBox()
        Me.Txt_HalfDayRate = New System.Windows.Forms.TextBox()
        Me.Txt_FullDayRate = New System.Windows.Forms.TextBox()
        Me.Chk_TimeSlot = New System.Windows.Forms.CheckBox()
        Me.Chk_HalfDay = New System.Windows.Forms.CheckBox()
        Me.Chk_FullDay = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmd_MGChargeCodeHelp = New System.Windows.Forms.Button()
        Me.Txt_MGChargeCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_MGAmount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_NonStandRateWEnd = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_NonStandRate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Dtp_BookToTime = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_BookFromTime = New System.Windows.Forms.DateTimePicker()
        Me.Cmd_MKChargeCodeHelp = New System.Windows.Forms.Button()
        Me.Cmd_HChargeCodeHelp = New System.Windows.Forms.Button()
        Me.Txt_MKChargeCode = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cbo_AdvanceApp = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txt_HallChargeCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Grp_Cancel = New System.Windows.Forms.GroupBox()
        Me.Cmd_ok = New System.Windows.Forms.Button()
        Me.sSGrid_Can = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_CanSetting = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.sSGrid_TimeSlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Grp_Cancel.SuspendLayout()
        CType(Me.sSGrid_Can, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(187, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Hall Master"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Cmd_HallCodeHelp)
        Me.GroupBox1.Controls.Add(Me.Cbo_OSFoodAllow)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Cbo_HRentOveride)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_SecDeposit)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Txt_ActCapacity)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_MaxCapacity)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_MinCapacity)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_HallDesc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_HallCode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(200, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(647, 136)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Cmd_HallCodeHelp
        '
        Me.Cmd_HallCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_HallCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_HallCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_HallCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_HallCodeHelp.Location = New System.Drawing.Point(253, 13)
        Me.Cmd_HallCodeHelp.Name = "Cmd_HallCodeHelp"
        Me.Cmd_HallCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_HallCodeHelp.TabIndex = 221
        Me.Cmd_HallCodeHelp.UseVisualStyleBackColor = True
        '
        'Cbo_OSFoodAllow
        '
        Me.Cbo_OSFoodAllow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_OSFoodAllow.FormattingEnabled = True
        Me.Cbo_OSFoodAllow.Items.AddRange(New Object() {"Yes", "No"})
        Me.Cbo_OSFoodAllow.Location = New System.Drawing.Point(476, 95)
        Me.Cbo_OSFoodAllow.Name = "Cbo_OSFoodAllow"
        Me.Cbo_OSFoodAllow.Size = New System.Drawing.Size(116, 21)
        Me.Cbo_OSFoodAllow.TabIndex = 121
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(341, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 15)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Outside Food Allowed"
        '
        'Cbo_HRentOveride
        '
        Me.Cbo_HRentOveride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_HRentOveride.FormattingEnabled = True
        Me.Cbo_HRentOveride.Items.AddRange(New Object() {"Yes", "No"})
        Me.Cbo_HRentOveride.Location = New System.Drawing.Point(138, 94)
        Me.Cbo_HRentOveride.Name = "Cbo_HRentOveride"
        Me.Cbo_HRentOveride.Size = New System.Drawing.Size(116, 21)
        Me.Cbo_HRentOveride.TabIndex = 119
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 15)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Hall Rent Override"
        '
        'Txt_SecDeposit
        '
        Me.Txt_SecDeposit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SecDeposit.Location = New System.Drawing.Point(476, 68)
        Me.Txt_SecDeposit.MaxLength = 10
        Me.Txt_SecDeposit.Name = "Txt_SecDeposit"
        Me.Txt_SecDeposit.Size = New System.Drawing.Size(116, 20)
        Me.Txt_SecDeposit.TabIndex = 112
        Me.Txt_SecDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(341, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Security Deposit"
        '
        'Txt_ActCapacity
        '
        Me.Txt_ActCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ActCapacity.Location = New System.Drawing.Point(138, 66)
        Me.Txt_ActCapacity.MaxLength = 10
        Me.Txt_ActCapacity.Name = "Txt_ActCapacity"
        Me.Txt_ActCapacity.Size = New System.Drawing.Size(116, 20)
        Me.Txt_ActCapacity.TabIndex = 110
        Me.Txt_ActCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Actual Capacity"
        '
        'Txt_MaxCapacity
        '
        Me.Txt_MaxCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MaxCapacity.Location = New System.Drawing.Point(476, 42)
        Me.Txt_MaxCapacity.MaxLength = 10
        Me.Txt_MaxCapacity.Name = "Txt_MaxCapacity"
        Me.Txt_MaxCapacity.Size = New System.Drawing.Size(116, 20)
        Me.Txt_MaxCapacity.TabIndex = 108
        Me.Txt_MaxCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(341, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Maximum Capacity"
        '
        'Txt_MinCapacity
        '
        Me.Txt_MinCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MinCapacity.Location = New System.Drawing.Point(138, 40)
        Me.Txt_MinCapacity.MaxLength = 10
        Me.Txt_MinCapacity.Name = "Txt_MinCapacity"
        Me.Txt_MinCapacity.Size = New System.Drawing.Size(116, 20)
        Me.Txt_MinCapacity.TabIndex = 106
        Me.Txt_MinCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Minimum Capacity"
        '
        'Txt_HallDesc
        '
        Me.Txt_HallDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HallDesc.Location = New System.Drawing.Point(476, 16)
        Me.Txt_HallDesc.MaxLength = 50
        Me.Txt_HallDesc.Name = "Txt_HallDesc"
        Me.Txt_HallDesc.Size = New System.Drawing.Size(116, 20)
        Me.Txt_HallDesc.TabIndex = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(341, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Hall Description"
        '
        'Txt_HallCode
        '
        Me.Txt_HallCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HallCode.Location = New System.Drawing.Point(138, 14)
        Me.Txt_HallCode.MaxLength = 10
        Me.Txt_HallCode.Name = "Txt_HallCode"
        Me.Txt_HallCode.Size = New System.Drawing.Size(116, 20)
        Me.Txt_HallCode.TabIndex = 102
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Hall Code"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.sSGrid_TimeSlot)
        Me.GroupBox2.Controls.Add(Me.Txt_HalfDayHourRate)
        Me.GroupBox2.Controls.Add(Me.Txt_HalfDayRate)
        Me.GroupBox2.Controls.Add(Me.Txt_FullDayRate)
        Me.GroupBox2.Controls.Add(Me.Chk_TimeSlot)
        Me.GroupBox2.Controls.Add(Me.Chk_HalfDay)
        Me.GroupBox2.Controls.Add(Me.Chk_FullDay)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(198, 248)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 216)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RATE CONFIGURATION"
        '
        'sSGrid_TimeSlot
        '
        Me.sSGrid_TimeSlot.DataSource = Nothing
        Me.sSGrid_TimeSlot.Location = New System.Drawing.Point(17, 111)
        Me.sSGrid_TimeSlot.Name = "sSGrid_TimeSlot"
        Me.sSGrid_TimeSlot.OcxState = CType(resources.GetObject("sSGrid_TimeSlot.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_TimeSlot.Size = New System.Drawing.Size(476, 100)
        Me.sSGrid_TimeSlot.TabIndex = 124
        '
        'Txt_HalfDayHourRate
        '
        Me.Txt_HalfDayHourRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HalfDayHourRate.Location = New System.Drawing.Point(263, 70)
        Me.Txt_HalfDayHourRate.MaxLength = 10
        Me.Txt_HalfDayHourRate.Name = "Txt_HalfDayHourRate"
        Me.Txt_HalfDayHourRate.Size = New System.Drawing.Size(131, 20)
        Me.Txt_HalfDayHourRate.TabIndex = 123
        Me.Txt_HalfDayHourRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_HalfDayRate
        '
        Me.Txt_HalfDayRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HalfDayRate.Location = New System.Drawing.Point(138, 70)
        Me.Txt_HalfDayRate.MaxLength = 10
        Me.Txt_HalfDayRate.Name = "Txt_HalfDayRate"
        Me.Txt_HalfDayRate.Size = New System.Drawing.Size(116, 20)
        Me.Txt_HalfDayRate.TabIndex = 122
        Me.Txt_HalfDayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_FullDayRate
        '
        Me.Txt_FullDayRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_FullDayRate.Location = New System.Drawing.Point(138, 44)
        Me.Txt_FullDayRate.MaxLength = 10
        Me.Txt_FullDayRate.Name = "Txt_FullDayRate"
        Me.Txt_FullDayRate.Size = New System.Drawing.Size(116, 20)
        Me.Txt_FullDayRate.TabIndex = 121
        Me.Txt_FullDayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_TimeSlot
        '
        Me.Chk_TimeSlot.AutoSize = True
        Me.Chk_TimeSlot.BackColor = System.Drawing.Color.Transparent
        Me.Chk_TimeSlot.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_TimeSlot.Location = New System.Drawing.Point(17, 92)
        Me.Chk_TimeSlot.Name = "Chk_TimeSlot"
        Me.Chk_TimeSlot.Size = New System.Drawing.Size(78, 18)
        Me.Chk_TimeSlot.TabIndex = 120
        Me.Chk_TimeSlot.Text = "Time Slot"
        Me.Chk_TimeSlot.UseVisualStyleBackColor = False
        '
        'Chk_HalfDay
        '
        Me.Chk_HalfDay.AutoSize = True
        Me.Chk_HalfDay.BackColor = System.Drawing.Color.Transparent
        Me.Chk_HalfDay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_HalfDay.Location = New System.Drawing.Point(17, 68)
        Me.Chk_HalfDay.Name = "Chk_HalfDay"
        Me.Chk_HalfDay.Size = New System.Drawing.Size(68, 18)
        Me.Chk_HalfDay.TabIndex = 119
        Me.Chk_HalfDay.Text = "Half Day"
        Me.Chk_HalfDay.UseVisualStyleBackColor = False
        '
        'Chk_FullDay
        '
        Me.Chk_FullDay.AutoSize = True
        Me.Chk_FullDay.BackColor = System.Drawing.Color.Transparent
        Me.Chk_FullDay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_FullDay.Location = New System.Drawing.Point(17, 44)
        Me.Chk_FullDay.Name = "Chk_FullDay"
        Me.Chk_FullDay.Size = New System.Drawing.Size(67, 18)
        Me.Chk_FullDay.TabIndex = 118
        Me.Chk_FullDay.Text = "Full Day"
        Me.Chk_FullDay.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(260, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 15)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Additional Charge/Hour"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(196, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "Hall Rent"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "Session Type"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmd_MGChargeCodeHelp)
        Me.GroupBox3.Controls.Add(Me.Txt_MGChargeCode)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Txt_MGAmount)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Txt_NonStandRateWEnd)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Txt_NonStandRate)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Dtp_BookToTime)
        Me.GroupBox3.Controls.Add(Me.Dtp_BookFromTime)
        Me.GroupBox3.Controls.Add(Me.Cmd_MKChargeCodeHelp)
        Me.GroupBox3.Controls.Add(Me.Cmd_HChargeCodeHelp)
        Me.GroupBox3.Controls.Add(Me.Txt_MKChargeCode)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Cbo_AdvanceApp)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Txt_HallChargeCode)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(196, 464)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(644, 148)
        Me.GroupBox3.TabIndex = 123
        Me.GroupBox3.TabStop = False
        '
        'Cmd_MGChargeCodeHelp
        '
        Me.Cmd_MGChargeCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_MGChargeCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_MGChargeCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_MGChargeCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_MGChargeCodeHelp.Location = New System.Drawing.Point(604, 121)
        Me.Cmd_MGChargeCodeHelp.Name = "Cmd_MGChargeCodeHelp"
        Me.Cmd_MGChargeCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_MGChargeCodeHelp.TabIndex = 863
        Me.Cmd_MGChargeCodeHelp.UseVisualStyleBackColor = True
        '
        'Txt_MGChargeCode
        '
        Me.Txt_MGChargeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MGChargeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MGChargeCode.Location = New System.Drawing.Point(483, 122)
        Me.Txt_MGChargeCode.MaxLength = 10
        Me.Txt_MGChargeCode.Name = "Txt_MGChargeCode"
        Me.Txt_MGChargeCode.Size = New System.Drawing.Size(120, 21)
        Me.Txt_MGChargeCode.TabIndex = 862
        Me.Txt_MGChargeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(323, 126)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 15)
        Me.Label13.TabIndex = 861
        Me.Label13.Text = "M. G. Charge Code"
        '
        'Txt_MGAmount
        '
        Me.Txt_MGAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MGAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MGAmount.Location = New System.Drawing.Point(179, 122)
        Me.Txt_MGAmount.MaxLength = 10
        Me.Txt_MGAmount.Name = "Txt_MGAmount"
        Me.Txt_MGAmount.Size = New System.Drawing.Size(120, 21)
        Me.Txt_MGAmount.TabIndex = 860
        Me.Txt_MGAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 15)
        Me.Label10.TabIndex = 859
        Me.Label10.Text = "Mininum Guarantee Amount"
        '
        'Txt_NonStandRateWEnd
        '
        Me.Txt_NonStandRateWEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NonStandRateWEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NonStandRateWEnd.Location = New System.Drawing.Point(483, 99)
        Me.Txt_NonStandRateWEnd.MaxLength = 10
        Me.Txt_NonStandRateWEnd.Name = "Txt_NonStandRateWEnd"
        Me.Txt_NonStandRateWEnd.Size = New System.Drawing.Size(120, 21)
        Me.Txt_NonStandRateWEnd.TabIndex = 858
        Me.Txt_NonStandRateWEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(322, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 15)
        Me.Label9.TabIndex = 857
        Me.Label9.Text = "Non Standard % Weekend"
        '
        'Txt_NonStandRate
        '
        Me.Txt_NonStandRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NonStandRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NonStandRate.Location = New System.Drawing.Point(179, 98)
        Me.Txt_NonStandRate.MaxLength = 10
        Me.Txt_NonStandRate.Name = "Txt_NonStandRate"
        Me.Txt_NonStandRate.Size = New System.Drawing.Size(120, 21)
        Me.Txt_NonStandRate.TabIndex = 856
        Me.Txt_NonStandRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(159, 15)
        Me.Label8.TabIndex = 855
        Me.Label8.Text = "Non Standard % Weekdays"
        '
        'Dtp_BookToTime
        '
        Me.Dtp_BookToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtp_BookToTime.Location = New System.Drawing.Point(261, 36)
        Me.Dtp_BookToTime.Name = "Dtp_BookToTime"
        Me.Dtp_BookToTime.ShowUpDown = True
        Me.Dtp_BookToTime.Size = New System.Drawing.Size(103, 20)
        Me.Dtp_BookToTime.TabIndex = 224
        '
        'Dtp_BookFromTime
        '
        Me.Dtp_BookFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtp_BookFromTime.Location = New System.Drawing.Point(140, 38)
        Me.Dtp_BookFromTime.Name = "Dtp_BookFromTime"
        Me.Dtp_BookFromTime.ShowUpDown = True
        Me.Dtp_BookFromTime.Size = New System.Drawing.Size(103, 20)
        Me.Dtp_BookFromTime.TabIndex = 223
        '
        'Cmd_MKChargeCodeHelp
        '
        Me.Cmd_MKChargeCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_MKChargeCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_MKChargeCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_MKChargeCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_MKChargeCodeHelp.Location = New System.Drawing.Point(576, 62)
        Me.Cmd_MKChargeCodeHelp.Name = "Cmd_MKChargeCodeHelp"
        Me.Cmd_MKChargeCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_MKChargeCodeHelp.TabIndex = 222
        Me.Cmd_MKChargeCodeHelp.UseVisualStyleBackColor = True
        '
        'Cmd_HChargeCodeHelp
        '
        Me.Cmd_HChargeCodeHelp.BackgroundImage = CType(resources.GetObject("Cmd_HChargeCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_HChargeCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_HChargeCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_HChargeCodeHelp.Location = New System.Drawing.Point(251, 64)
        Me.Cmd_HChargeCodeHelp.Name = "Cmd_HChargeCodeHelp"
        Me.Cmd_HChargeCodeHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_HChargeCodeHelp.TabIndex = 221
        Me.Cmd_HChargeCodeHelp.UseVisualStyleBackColor = True
        '
        'Txt_MKChargeCode
        '
        Me.Txt_MKChargeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MKChargeCode.Location = New System.Drawing.Point(471, 63)
        Me.Txt_MKChargeCode.MaxLength = 10
        Me.Txt_MKChargeCode.Name = "Txt_MKChargeCode"
        Me.Txt_MKChargeCode.Size = New System.Drawing.Size(106, 20)
        Me.Txt_MKChargeCode.TabIndex = 138
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(287, 68)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(178, 15)
        Me.Label25.TabIndex = 137
        Me.Label25.Text = "Marriage Keeper Charge Code"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(258, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 15)
        Me.Label20.TabIndex = 130
        Me.Label20.Text = "To Time"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(136, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 15)
        Me.Label21.TabIndex = 128
        Me.Label21.Text = "From Time"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 15)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "Booking  Applicable"
        '
        'Cbo_AdvanceApp
        '
        Me.Cbo_AdvanceApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_AdvanceApp.FormattingEnabled = True
        Me.Cbo_AdvanceApp.Items.AddRange(New Object() {"Yes", "No"})
        Me.Cbo_AdvanceApp.Location = New System.Drawing.Point(514, 33)
        Me.Cbo_AdvanceApp.Name = "Cbo_AdvanceApp"
        Me.Cbo_AdvanceApp.Size = New System.Drawing.Size(116, 21)
        Me.Cbo_AdvanceApp.TabIndex = 125
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(374, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 15)
        Me.Label18.TabIndex = 126
        Me.Label18.Text = "Advance Applicable"
        '
        'Txt_HallChargeCode
        '
        Me.Txt_HallChargeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HallChargeCode.Location = New System.Drawing.Point(136, 65)
        Me.Txt_HallChargeCode.MaxLength = 10
        Me.Txt_HallChargeCode.Name = "Txt_HallChargeCode"
        Me.Txt_HallChargeCode.Size = New System.Drawing.Size(116, 20)
        Me.Txt_HallChargeCode.TabIndex = 124
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 15)
        Me.Label17.TabIndex = 123
        Me.Label17.Text = "Charge Code"
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
        Me.GroupBox4.Location = New System.Drawing.Point(857, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 442)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(4, 354)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 65)
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
        Me.Cmdbwse.Location = New System.Drawing.Point(4, 286)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 165
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Enabled = False
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(4, 217)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(4, 149)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
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
        Me.CmdClear.Location = New System.Drawing.Point(4, 80)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 65)
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
        Me.CmdAdd.Size = New System.Drawing.Size(144, 65)
        Me.CmdAdd.TabIndex = 161
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(586, 48)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 16)
        Me.lbl_Freeze.TabIndex = 852
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Grp_Cancel
        '
        Me.Grp_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Cancel.Controls.Add(Me.Cmd_ok)
        Me.Grp_Cancel.Controls.Add(Me.sSGrid_Can)
        Me.Grp_Cancel.Location = New System.Drawing.Point(195, 475)
        Me.Grp_Cancel.Name = "Grp_Cancel"
        Me.Grp_Cancel.Size = New System.Drawing.Size(644, 134)
        Me.Grp_Cancel.TabIndex = 853
        Me.Grp_Cancel.TabStop = False
        Me.Grp_Cancel.Visible = False
        '
        'Cmd_ok
        '
        Me.Cmd_ok.Location = New System.Drawing.Point(515, 48)
        Me.Cmd_ok.Name = "Cmd_ok"
        Me.Cmd_ok.Size = New System.Drawing.Size(112, 40)
        Me.Cmd_ok.TabIndex = 1
        Me.Cmd_ok.Text = "O K"
        Me.Cmd_ok.UseVisualStyleBackColor = True
        '
        'sSGrid_Can
        '
        Me.sSGrid_Can.DataSource = Nothing
        Me.sSGrid_Can.Location = New System.Drawing.Point(7, 14)
        Me.sSGrid_Can.Name = "sSGrid_Can"
        Me.sSGrid_Can.OcxState = CType(resources.GetObject("sSGrid_Can.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid_Can.Size = New System.Drawing.Size(493, 113)
        Me.sSGrid_Can.TabIndex = 0
        '
        'Cmd_CanSetting
        '
        Me.Cmd_CanSetting.Location = New System.Drawing.Point(722, 423)
        Me.Cmd_CanSetting.Name = "Cmd_CanSetting"
        Me.Cmd_CanSetting.Size = New System.Drawing.Size(116, 41)
        Me.Cmd_CanSetting.TabIndex = 168
        Me.Cmd_CanSetting.Text = "Cancellation Setting"
        Me.Cmd_CanSetting.UseVisualStyleBackColor = True
        '
        'Frm_M_HallMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1021, 744)
        Me.Controls.Add(Me.Cmd_CanSetting)
        Me.Controls.Add(Me.Grp_Cancel)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_M_HallMaster"
        Me.Text = "Frm_M_HallMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.sSGrid_TimeSlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Grp_Cancel.ResumeLayout(False)
        CType(Me.sSGrid_Can, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_HallDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_HallCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_SecDeposit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_ActCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_MaxCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_MinCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cbo_OSFoodAllow As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cbo_HRentOveride As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Chk_TimeSlot As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_HalfDay As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_FullDay As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_HalfDayHourRate As System.Windows.Forms.TextBox
    Friend WithEvents Txt_HalfDayRate As System.Windows.Forms.TextBox
    Friend WithEvents Txt_FullDayRate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cbo_AdvanceApp As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_HallChargeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Txt_MKChargeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents sSGrid_TimeSlot As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_HallCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_HChargeCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_MKChargeCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Dtp_BookToTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_BookFromTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Grp_Cancel As System.Windows.Forms.GroupBox
    Friend WithEvents sSGrid_Can As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_ok As System.Windows.Forms.Button
    Friend WithEvents Cmd_CanSetting As System.Windows.Forms.Button
    Friend WithEvents Txt_NonStandRate As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_NonStandRateWEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_MGAmount As System.Windows.Forms.TextBox
    Friend WithEvents Txt_MGChargeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Cmd_MGChargeCodeHelp As System.Windows.Forms.Button
End Class
