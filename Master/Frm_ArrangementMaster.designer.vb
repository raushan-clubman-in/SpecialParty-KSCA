<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ArrangementMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ArrangementMaster))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd_ArrItemHelp = New System.Windows.Forms.Button()
        Me.Txt_ArrItemCode = New System.Windows.Forms.TextBox()
        Me.Lbl_Arrenment = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_ArrItemdesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Uom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Rate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_OpenFacility = New System.Windows.Forms.ComboBox()
        Me.Txt_CCode = New System.Windows.Forms.TextBox()
        Me.Cmd_Uom = New System.Windows.Forms.Button()
        Me.Cmd_ChargeCode = New System.Windows.Forms.Button()
        Me.Rdb_Self = New System.Windows.Forms.RadioButton()
        Me.Rdb_Vendor = New System.Windows.Forms.RadioButton()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdFreeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Grp_Vendor = New System.Windows.Forms.GroupBox()
        Me.Txt_Vendorcode = New System.Windows.Forms.TextBox()
        Me.Cmd_Vendor = New System.Windows.Forms.Button()
        Me.Txt_Pincode = New System.Windows.Forms.TextBox()
        Me.Txt_City = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Add3 = New System.Windows.Forms.TextBox()
        Me.Txt_Add2 = New System.Windows.Forms.TextBox()
        Me.Txt_Add1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_ContPersone = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_VendorName = New System.Windows.Forms.TextBox()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.Cmd_Ccode = New System.Windows.Forms.Button()
        Me.Text_CCODE = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Grp_Vendor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(205, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 685
        Me.Label6.Text = "Item Code"
        '
        'Cmd_ArrItemHelp
        '
        Me.Cmd_ArrItemHelp.BackgroundImage = CType(resources.GetObject("Cmd_ArrItemHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_ArrItemHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_ArrItemHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_ArrItemHelp.Location = New System.Drawing.Point(427, 129)
        Me.Cmd_ArrItemHelp.Name = "Cmd_ArrItemHelp"
        Me.Cmd_ArrItemHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_ArrItemHelp.TabIndex = 687
        Me.Cmd_ArrItemHelp.UseVisualStyleBackColor = True
        '
        'Txt_ArrItemCode
        '
        Me.Txt_ArrItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ArrItemCode.Location = New System.Drawing.Point(279, 131)
        Me.Txt_ArrItemCode.MaxLength = 10
        Me.Txt_ArrItemCode.Name = "Txt_ArrItemCode"
        Me.Txt_ArrItemCode.Size = New System.Drawing.Size(143, 20)
        Me.Txt_ArrItemCode.TabIndex = 686
        '
        'Lbl_Arrenment
        '
        Me.Lbl_Arrenment.AutoSize = True
        Me.Lbl_Arrenment.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Arrenment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Arrenment.Location = New System.Drawing.Point(194, 75)
        Me.Lbl_Arrenment.Name = "Lbl_Arrenment"
        Me.Lbl_Arrenment.Size = New System.Drawing.Size(153, 15)
        Me.Lbl_Arrenment.TabIndex = 688
        Me.Lbl_Arrenment.Text = "Arrangement Item Master"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(495, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 689
        Me.Label1.Text = "Item Description"
        '
        'Txt_ArrItemdesc
        '
        Me.Txt_ArrItemdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ArrItemdesc.Location = New System.Drawing.Point(601, 131)
        Me.Txt_ArrItemdesc.MaxLength = 30
        Me.Txt_ArrItemdesc.Name = "Txt_ArrItemdesc"
        Me.Txt_ArrItemdesc.Size = New System.Drawing.Size(170, 20)
        Me.Txt_ArrItemdesc.TabIndex = 690
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 691
        Me.Label2.Text = "Uom"
        '
        'Txt_Uom
        '
        Me.Txt_Uom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Uom.Location = New System.Drawing.Point(279, 162)
        Me.Txt_Uom.MaxLength = 10
        Me.Txt_Uom.Name = "Txt_Uom"
        Me.Txt_Uom.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Uom.TabIndex = 692
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 693
        Me.Label3.Text = "Rate"
        '
        'Txt_Rate
        '
        Me.Txt_Rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Rate.Location = New System.Drawing.Point(279, 194)
        Me.Txt_Rate.MaxLength = 10
        Me.Txt_Rate.Name = "Txt_Rate"
        Me.Txt_Rate.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Rate.TabIndex = 694
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(201, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 695
        Me.Label4.Text = "Open Facility"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(495, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 697
        Me.Label5.Text = "Charge Code"
        '
        'Cmb_OpenFacility
        '
        Me.Cmb_OpenFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_OpenFacility.FormattingEnabled = True
        Me.Cmb_OpenFacility.Items.AddRange(New Object() {"Y", "N"})
        Me.Cmb_OpenFacility.Location = New System.Drawing.Point(279, 228)
        Me.Cmb_OpenFacility.Name = "Cmb_OpenFacility"
        Me.Cmb_OpenFacility.Size = New System.Drawing.Size(143, 21)
        Me.Cmb_OpenFacility.TabIndex = 698
        '
        'Txt_CCode
        '
        Me.Txt_CCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CCode.Location = New System.Drawing.Point(601, 200)
        Me.Txt_CCode.MaxLength = 10
        Me.Txt_CCode.Name = "Txt_CCode"
        Me.Txt_CCode.Size = New System.Drawing.Size(138, 20)
        Me.Txt_CCode.TabIndex = 699
        '
        'Cmd_Uom
        '
        Me.Cmd_Uom.BackgroundImage = CType(resources.GetObject("Cmd_Uom.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Uom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Uom.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Uom.Location = New System.Drawing.Point(427, 160)
        Me.Cmd_Uom.Name = "Cmd_Uom"
        Me.Cmd_Uom.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_Uom.TabIndex = 700
        Me.Cmd_Uom.UseVisualStyleBackColor = True
        '
        'Cmd_ChargeCode
        '
        Me.Cmd_ChargeCode.BackgroundImage = CType(resources.GetObject("Cmd_ChargeCode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_ChargeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_ChargeCode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_ChargeCode.Location = New System.Drawing.Point(741, 198)
        Me.Cmd_ChargeCode.Name = "Cmd_ChargeCode"
        Me.Cmd_ChargeCode.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_ChargeCode.TabIndex = 701
        Me.Cmd_ChargeCode.UseVisualStyleBackColor = True
        '
        'Rdb_Self
        '
        Me.Rdb_Self.AutoSize = True
        Me.Rdb_Self.Location = New System.Drawing.Point(459, 280)
        Me.Rdb_Self.Name = "Rdb_Self"
        Me.Rdb_Self.Size = New System.Drawing.Size(43, 17)
        Me.Rdb_Self.TabIndex = 702
        Me.Rdb_Self.TabStop = True
        Me.Rdb_Self.Text = "Self"
        Me.Rdb_Self.UseVisualStyleBackColor = True
        '
        'Rdb_Vendor
        '
        Me.Rdb_Vendor.AutoSize = True
        Me.Rdb_Vendor.Location = New System.Drawing.Point(562, 280)
        Me.Rdb_Vendor.Name = "Rdb_Vendor"
        Me.Rdb_Vendor.Size = New System.Drawing.Size(59, 17)
        Me.Rdb_Vendor.TabIndex = 703
        Me.Rdb_Vendor.TabStop = True
        Me.Rdb_Vendor.Text = "Vendor"
        Me.Rdb_Vendor.UseVisualStyleBackColor = True
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(860, 414)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(144, 55)
        Me.CmdExit.TabIndex = 709
        Me.CmdExit.Text = "Exit [F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBrowse.Location = New System.Drawing.Point(860, 354)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(144, 55)
        Me.CmdBrowse.TabIndex = 708
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'CmdView
        '
        Me.CmdView.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(860, 295)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(144, 55)
        Me.CmdView.TabIndex = 707
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = True
        '
        'CmdFreeze
        '
        Me.CmdFreeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFreeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdFreeze.Image = CType(resources.GetObject("CmdFreeze.Image"), System.Drawing.Image)
        Me.CmdFreeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFreeze.Location = New System.Drawing.Point(860, 236)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(144, 55)
        Me.CmdFreeze.TabIndex = 706
        Me.CmdFreeze.Text = "Freeze [F8]"
        Me.CmdFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdFreeze.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(860, 177)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 55)
        Me.CmdClear.TabIndex = 705
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
        Me.CmdAdd.Location = New System.Drawing.Point(860, 119)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 55)
        Me.CmdAdd.TabIndex = 704
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'Grp_Vendor
        '
        Me.Grp_Vendor.Controls.Add(Me.Txt_Vendorcode)
        Me.Grp_Vendor.Controls.Add(Me.Cmd_Vendor)
        Me.Grp_Vendor.Controls.Add(Me.Txt_Pincode)
        Me.Grp_Vendor.Controls.Add(Me.Txt_City)
        Me.Grp_Vendor.Controls.Add(Me.Label11)
        Me.Grp_Vendor.Controls.Add(Me.Label10)
        Me.Grp_Vendor.Controls.Add(Me.Txt_Add3)
        Me.Grp_Vendor.Controls.Add(Me.Txt_Add2)
        Me.Grp_Vendor.Controls.Add(Me.Txt_Add1)
        Me.Grp_Vendor.Controls.Add(Me.Label9)
        Me.Grp_Vendor.Controls.Add(Me.Txt_ContPersone)
        Me.Grp_Vendor.Controls.Add(Me.Label8)
        Me.Grp_Vendor.Controls.Add(Me.Label7)
        Me.Grp_Vendor.Controls.Add(Me.Txt_VendorName)
        Me.Grp_Vendor.Location = New System.Drawing.Point(194, 303)
        Me.Grp_Vendor.Name = "Grp_Vendor"
        Me.Grp_Vendor.Size = New System.Drawing.Size(655, 100)
        Me.Grp_Vendor.TabIndex = 711
        Me.Grp_Vendor.TabStop = False
        Me.Grp_Vendor.Text = "Vendor"
        '
        'Txt_Vendorcode
        '
        Me.Txt_Vendorcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vendorcode.Location = New System.Drawing.Point(11, 57)
        Me.Txt_Vendorcode.MaxLength = 10
        Me.Txt_Vendorcode.Name = "Txt_Vendorcode"
        Me.Txt_Vendorcode.Size = New System.Drawing.Size(109, 20)
        Me.Txt_Vendorcode.TabIndex = 702
        '
        'Cmd_Vendor
        '
        Me.Cmd_Vendor.BackgroundImage = CType(resources.GetObject("Cmd_Vendor.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Vendor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Vendor.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Vendor.Location = New System.Drawing.Point(121, 33)
        Me.Cmd_Vendor.Name = "Cmd_Vendor"
        Me.Cmd_Vendor.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_Vendor.TabIndex = 701
        Me.Cmd_Vendor.UseVisualStyleBackColor = True
        '
        'Txt_Pincode
        '
        Me.Txt_Pincode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Pincode.Location = New System.Drawing.Point(560, 34)
        Me.Txt_Pincode.MaxLength = 10
        Me.Txt_Pincode.Name = "Txt_Pincode"
        Me.Txt_Pincode.Size = New System.Drawing.Size(92, 20)
        Me.Txt_Pincode.TabIndex = 700
        '
        'Txt_City
        '
        Me.Txt_City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_City.Location = New System.Drawing.Point(453, 34)
        Me.Txt_City.MaxLength = 20
        Me.Txt_City.Name = "Txt_City"
        Me.Txt_City.Size = New System.Drawing.Size(100, 20)
        Me.Txt_City.TabIndex = 699
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(562, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 15)
        Me.Label11.TabIndex = 698
        Me.Label11.Text = "Pincode"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(459, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 15)
        Me.Label10.TabIndex = 697
        Me.Label10.Text = "City"
        '
        'Txt_Add3
        '
        Me.Txt_Add3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Add3.Location = New System.Drawing.Point(304, 74)
        Me.Txt_Add3.MaxLength = 20
        Me.Txt_Add3.Name = "Txt_Add3"
        Me.Txt_Add3.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Add3.TabIndex = 696
        Me.Txt_Add3.Text = "ADD3"
        '
        'Txt_Add2
        '
        Me.Txt_Add2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Add2.Location = New System.Drawing.Point(304, 54)
        Me.Txt_Add2.MaxLength = 20
        Me.Txt_Add2.Name = "Txt_Add2"
        Me.Txt_Add2.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Add2.TabIndex = 695
        Me.Txt_Add2.Text = "ADD2"
        '
        'Txt_Add1
        '
        Me.Txt_Add1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Add1.Location = New System.Drawing.Point(305, 33)
        Me.Txt_Add1.MaxLength = 20
        Me.Txt_Add1.Name = "Txt_Add1"
        Me.Txt_Add1.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Add1.TabIndex = 694
        Me.Txt_Add1.Text = "ADD1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(307, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 693
        Me.Label9.Text = "Address"
        '
        'Txt_ContPersone
        '
        Me.Txt_ContPersone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ContPersone.Location = New System.Drawing.Point(154, 35)
        Me.Txt_ContPersone.MaxLength = 10
        Me.Txt_ContPersone.Name = "Txt_ContPersone"
        Me.Txt_ContPersone.Size = New System.Drawing.Size(143, 20)
        Me.Txt_ContPersone.TabIndex = 692
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(160, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 15)
        Me.Label8.TabIndex = 691
        Me.Label8.Text = "Contact Person"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 690
        Me.Label7.Text = "Vendor Name"
        '
        'Txt_VendorName
        '
        Me.Txt_VendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_VendorName.Location = New System.Drawing.Point(12, 33)
        Me.Txt_VendorName.MaxLength = 10
        Me.Txt_VendorName.Name = "Txt_VendorName"
        Me.Txt_VendorName.Size = New System.Drawing.Size(120, 20)
        Me.Txt_VendorName.TabIndex = 688
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(431, 478)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 712
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'Cmd_Ccode
        '
        Me.Cmd_Ccode.BackgroundImage = CType(resources.GetObject("Cmd_Ccode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Ccode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Ccode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Ccode.Location = New System.Drawing.Point(741, 162)
        Me.Cmd_Ccode.Name = "Cmd_Ccode"
        Me.Cmd_Ccode.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_Ccode.TabIndex = 715
        Me.Cmd_Ccode.UseVisualStyleBackColor = True
        '
        'Text_CCODE
        '
        Me.Text_CCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Text_CCODE.Location = New System.Drawing.Point(601, 164)
        Me.Text_CCODE.MaxLength = 10
        Me.Text_CCODE.Name = "Text_CCODE"
        Me.Text_CCODE.Size = New System.Drawing.Size(138, 20)
        Me.Text_CCODE.TabIndex = 714
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(495, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 713
        Me.Label12.Text = "Category"
        '
        'Frm_ArrangementMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1025, 741)
        Me.Controls.Add(Me.Cmd_Ccode)
        Me.Controls.Add(Me.Text_CCODE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.Grp_Vendor)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.CmdFreeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Rdb_Vendor)
        Me.Controls.Add(Me.Rdb_Self)
        Me.Controls.Add(Me.Cmd_ChargeCode)
        Me.Controls.Add(Me.Cmd_Uom)
        Me.Controls.Add(Me.Txt_CCode)
        Me.Controls.Add(Me.Cmb_OpenFacility)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_Rate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Uom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_ArrItemdesc)
        Me.Controls.Add(Me.Lbl_Arrenment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmd_ArrItemHelp)
        Me.Controls.Add(Me.Txt_ArrItemCode)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_ArrangementMaster"
        Me.Text = "Frm_ArrangementMaster"
        Me.Grp_Vendor.ResumeLayout(False)
        Me.Grp_Vendor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_ArrItemHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_ArrItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Arrenment As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_ArrItemdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Uom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Rate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmb_OpenFacility As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_CCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Uom As System.Windows.Forms.Button
    Friend WithEvents Cmd_ChargeCode As System.Windows.Forms.Button
    Friend WithEvents Rdb_Self As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Vendor As System.Windows.Forms.RadioButton
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Grp_Vendor As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Pincode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_City As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_Add3 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Add2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Add1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_ContPersone As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_VendorName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Vendor As System.Windows.Forms.Button
    Friend WithEvents Txt_Vendorcode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Ccode As System.Windows.Forms.Button
    Friend WithEvents Text_CCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
