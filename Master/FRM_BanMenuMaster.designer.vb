<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_BanMenuMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_BanMenuMaster))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdFreeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Ccode = New System.Windows.Forms.Button()
        Me.cmb_category = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_CCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmd_ChargeCode = New System.Windows.Forms.Button()
        Me.txt_taxcode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_MenuRate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Tariffdesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd_MenuHelp = New System.Windows.Forms.Button()
        Me.Txt_TariffCode = New System.Windows.Forms.TextBox()
        Me.SSGRID_MENU = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SSGRID_MENU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(198, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 667
        Me.Label2.Text = "Menu Master"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CmdExit)
        Me.GroupBox4.Controls.Add(Me.CmdBrowse)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Controls.Add(Me.CmdFreeze)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(857, 108)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 376)
        Me.GroupBox4.TabIndex = 689
        Me.GroupBox4.TabStop = False
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(4, 248)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(144, 55)
        Me.CmdExit.TabIndex = 167
        Me.CmdExit.Text = "Exit [F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBrowse.Location = New System.Drawing.Point(4, 188)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(144, 55)
        Me.CmdBrowse.TabIndex = 165
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'CmdView
        '
        Me.CmdView.Enabled = False
        Me.CmdView.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(4, 188)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(144, 55)
        Me.CmdView.TabIndex = 164
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
        Me.CmdFreeze.Location = New System.Drawing.Point(4, 129)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(144, 55)
        Me.CmdFreeze.TabIndex = 163
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Cmd_Ccode)
        Me.GroupBox1.Controls.Add(Me.cmb_category)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_CCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cmd_ChargeCode)
        Me.GroupBox1.Controls.Add(Me.txt_taxcode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_MenuRate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_Tariffdesc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Cmd_MenuHelp)
        Me.GroupBox1.Controls.Add(Me.Txt_TariffCode)
        Me.GroupBox1.Location = New System.Drawing.Point(192, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 125)
        Me.GroupBox1.TabIndex = 690
        Me.GroupBox1.TabStop = False
        '
        'Cmd_Ccode
        '
        Me.Cmd_Ccode.BackgroundImage = CType(resources.GetObject("Cmd_Ccode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Ccode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Ccode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Ccode.Location = New System.Drawing.Point(252, 83)
        Me.Cmd_Ccode.Name = "Cmd_Ccode"
        Me.Cmd_Ccode.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_Ccode.TabIndex = 696
        Me.Cmd_Ccode.UseVisualStyleBackColor = True
        '
        'cmb_category
        '
        Me.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_category.Items.AddRange(New Object() {"VEG", "NON VEG"})
        Me.cmb_category.Location = New System.Drawing.Point(404, 89)
        Me.cmb_category.Name = "cmb_category"
        Me.cmb_category.Size = New System.Drawing.Size(122, 21)
        Me.cmb_category.TabIndex = 695
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(292, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 694
        Me.Label7.Text = "Tarriff Type"
        '
        'txt_CCode
        '
        Me.txt_CCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CCode.Location = New System.Drawing.Point(104, 85)
        Me.txt_CCode.MaxLength = 10
        Me.txt_CCode.Name = "txt_CCode"
        Me.txt_CCode.Size = New System.Drawing.Size(146, 20)
        Me.txt_CCode.TabIndex = 693
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 692
        Me.Label5.Text = "Category Code"
        '
        'Cmd_ChargeCode
        '
        Me.Cmd_ChargeCode.BackgroundImage = CType(resources.GetObject("Cmd_ChargeCode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_ChargeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_ChargeCode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_ChargeCode.Location = New System.Drawing.Point(552, 51)
        Me.Cmd_ChargeCode.Name = "Cmd_ChargeCode"
        Me.Cmd_ChargeCode.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_ChargeCode.TabIndex = 691
        Me.Cmd_ChargeCode.UseVisualStyleBackColor = True
        '
        'txt_taxcode
        '
        Me.txt_taxcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_taxcode.Location = New System.Drawing.Point(403, 51)
        Me.txt_taxcode.MaxLength = 10
        Me.txt_taxcode.Name = "txt_taxcode"
        Me.txt_taxcode.Size = New System.Drawing.Size(146, 20)
        Me.txt_taxcode.TabIndex = 690
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 689
        Me.Label4.Text = "Charge Code"
        '
        'Txt_MenuRate
        '
        Me.Txt_MenuRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MenuRate.Location = New System.Drawing.Point(103, 49)
        Me.Txt_MenuRate.MaxLength = 10
        Me.Txt_MenuRate.Name = "Txt_MenuRate"
        Me.Txt_MenuRate.Size = New System.Drawing.Size(146, 20)
        Me.Txt_MenuRate.TabIndex = 688
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 687
        Me.Label3.Text = "Menu Rate"
        '
        'Txt_Tariffdesc
        '
        Me.Txt_Tariffdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tariffdesc.Location = New System.Drawing.Point(402, 13)
        Me.Txt_Tariffdesc.MaxLength = 30
        Me.Txt_Tariffdesc.Name = "Txt_Tariffdesc"
        Me.Txt_Tariffdesc.Size = New System.Drawing.Size(146, 20)
        Me.Txt_Tariffdesc.TabIndex = 686
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 685
        Me.Label1.Text = "Menu Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 682
        Me.Label6.Text = "Menu Code"
        '
        'Cmd_MenuHelp
        '
        Me.Cmd_MenuHelp.BackgroundImage = CType(resources.GetObject("Cmd_MenuHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_MenuHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_MenuHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_MenuHelp.Location = New System.Drawing.Point(252, 14)
        Me.Cmd_MenuHelp.Name = "Cmd_MenuHelp"
        Me.Cmd_MenuHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_MenuHelp.TabIndex = 684
        Me.Cmd_MenuHelp.UseVisualStyleBackColor = True
        '
        'Txt_TariffCode
        '
        Me.Txt_TariffCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TariffCode.Location = New System.Drawing.Point(102, 14)
        Me.Txt_TariffCode.MaxLength = 10
        Me.Txt_TariffCode.Name = "Txt_TariffCode"
        Me.Txt_TariffCode.Size = New System.Drawing.Size(146, 20)
        Me.Txt_TariffCode.TabIndex = 683
        '
        'SSGRID_MENU
        '
        Me.SSGRID_MENU.DataSource = Nothing
        Me.SSGRID_MENU.Location = New System.Drawing.Point(206, 244)
        Me.SSGRID_MENU.Name = "SSGRID_MENU"
        Me.SSGRID_MENU.OcxState = CType(resources.GetObject("SSGRID_MENU.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_MENU.Size = New System.Drawing.Size(579, 142)
        Me.SSGRID_MENU.TabIndex = 691
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(419, 427)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 692
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(192, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(630, 167)
        Me.GroupBox2.TabIndex = 693
        Me.GroupBox2.TabStop = False
        '
        'FRM_BanMenuMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1025, 750)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.SSGRID_MENU)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "FRM_BanMenuMaster"
        Me.Text = "FRM_BanMenuMaster"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SSGRID_MENU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_CCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_ChargeCode As System.Windows.Forms.Button
    Friend WithEvents txt_taxcode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_MenuRate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Tariffdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_MenuHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_TariffCode As System.Windows.Forms.TextBox
    Friend WithEvents SSGRID_MENU As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Ccode As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
