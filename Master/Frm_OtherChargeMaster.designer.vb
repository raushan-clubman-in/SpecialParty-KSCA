<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OtherChargeMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OtherChargeMaster))
        Me.Lbl_Arrenment = New System.Windows.Forms.Label()
        Me.Cmd_ChargeCode = New System.Windows.Forms.Button()
        Me.Cmd_Uom = New System.Windows.Forms.Button()
        Me.Txt_CCode = New System.Windows.Forms.TextBox()
        Me.Cmb_AmtOverRide = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Rate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Uom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_OthItemdesc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd_OthItemHelp = New System.Windows.Forms.Button()
        Me.Txt_OthItemCode = New System.Windows.Forms.TextBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdFreeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'Lbl_Arrenment
        '
        Me.Lbl_Arrenment.AutoSize = True
        Me.Lbl_Arrenment.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Arrenment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Arrenment.Location = New System.Drawing.Point(190, 75)
        Me.Lbl_Arrenment.Name = "Lbl_Arrenment"
        Me.Lbl_Arrenment.Size = New System.Drawing.Size(126, 15)
        Me.Lbl_Arrenment.TabIndex = 689
        Me.Lbl_Arrenment.Text = "Other Charge Master"
        '
        'Cmd_ChargeCode
        '
        Me.Cmd_ChargeCode.BackgroundImage = CType(resources.GetObject("Cmd_ChargeCode.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_ChargeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_ChargeCode.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_ChargeCode.Location = New System.Drawing.Point(790, 173)
        Me.Cmd_ChargeCode.Name = "Cmd_ChargeCode"
        Me.Cmd_ChargeCode.Size = New System.Drawing.Size(30, 24)
        Me.Cmd_ChargeCode.TabIndex = 716
        Me.Cmd_ChargeCode.UseVisualStyleBackColor = True
        '
        'Cmd_Uom
        '
        Me.Cmd_Uom.BackgroundImage = CType(resources.GetObject("Cmd_Uom.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Uom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Uom.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_Uom.Location = New System.Drawing.Point(335, 281)
        Me.Cmd_Uom.Name = "Cmd_Uom"
        Me.Cmd_Uom.Size = New System.Drawing.Size(30, 24)
        Me.Cmd_Uom.TabIndex = 715
        Me.Cmd_Uom.UseVisualStyleBackColor = True
        Me.Cmd_Uom.Visible = False
        '
        'Txt_CCode
        '
        Me.Txt_CCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CCode.Location = New System.Drawing.Point(634, 175)
        Me.Txt_CCode.MaxLength = 10
        Me.Txt_CCode.Name = "Txt_CCode"
        Me.Txt_CCode.Size = New System.Drawing.Size(153, 20)
        Me.Txt_CCode.TabIndex = 714
        '
        'Cmb_AmtOverRide
        '
        Me.Cmb_AmtOverRide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AmtOverRide.FormattingEnabled = True
        Me.Cmb_AmtOverRide.Items.AddRange(New Object() {"Y", "N"})
        Me.Cmb_AmtOverRide.Location = New System.Drawing.Point(330, 212)
        Me.Cmb_AmtOverRide.Name = "Cmb_AmtOverRide"
        Me.Cmb_AmtOverRide.Size = New System.Drawing.Size(175, 21)
        Me.Cmb_AmtOverRide.TabIndex = 713
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(530, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 712
        Me.Label5.Text = "Charge Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 711
        Me.Label4.Text = "Amount Override"
        '
        'Txt_Rate
        '
        Me.Txt_Rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Rate.Location = New System.Drawing.Point(330, 174)
        Me.Txt_Rate.MaxLength = 10
        Me.Txt_Rate.Name = "Txt_Rate"
        Me.Txt_Rate.Size = New System.Drawing.Size(176, 20)
        Me.Txt_Rate.TabIndex = 710
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 709
        Me.Label3.Text = "Rate"
        '
        'Txt_Uom
        '
        Me.Txt_Uom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Uom.Location = New System.Drawing.Point(260, 283)
        Me.Txt_Uom.MaxLength = 10
        Me.Txt_Uom.Name = "Txt_Uom"
        Me.Txt_Uom.Size = New System.Drawing.Size(71, 20)
        Me.Txt_Uom.TabIndex = 708
        Me.Txt_Uom.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(224, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 707
        Me.Label2.Text = "Uom"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(528, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 705
        Me.Label1.Text = "Item Description"
        '
        'Txt_OthItemdesc
        '
        Me.Txt_OthItemdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_OthItemdesc.Location = New System.Drawing.Point(634, 137)
        Me.Txt_OthItemdesc.MaxLength = 30
        Me.Txt_OthItemdesc.Name = "Txt_OthItemdesc"
        Me.Txt_OthItemdesc.Size = New System.Drawing.Size(186, 20)
        Me.Txt_OthItemdesc.TabIndex = 706
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(221, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 702
        Me.Label6.Text = "Item Code"
        '
        'Cmd_OthItemHelp
        '
        Me.Cmd_OthItemHelp.BackgroundImage = CType(resources.GetObject("Cmd_OthItemHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_OthItemHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_OthItemHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_OthItemHelp.Location = New System.Drawing.Point(480, 135)
        Me.Cmd_OthItemHelp.Name = "Cmd_OthItemHelp"
        Me.Cmd_OthItemHelp.Size = New System.Drawing.Size(30, 24)
        Me.Cmd_OthItemHelp.TabIndex = 704
        Me.Cmd_OthItemHelp.UseVisualStyleBackColor = True
        '
        'Txt_OthItemCode
        '
        Me.Txt_OthItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_OthItemCode.Location = New System.Drawing.Point(332, 137)
        Me.Txt_OthItemCode.MaxLength = 10
        Me.Txt_OthItemCode.Name = "Txt_OthItemCode"
        Me.Txt_OthItemCode.Size = New System.Drawing.Size(143, 20)
        Me.Txt_OthItemCode.TabIndex = 703
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(860, 421)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(144, 55)
        Me.CmdExit.TabIndex = 722
        Me.CmdExit.Text = "Exit [F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBrowse.Location = New System.Drawing.Point(860, 360)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(144, 55)
        Me.CmdBrowse.TabIndex = 721
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'CmdView
        '
        Me.CmdView.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(860, 300)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(144, 55)
        Me.CmdView.TabIndex = 720
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
        Me.CmdFreeze.Location = New System.Drawing.Point(860, 241)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(144, 55)
        Me.CmdFreeze.TabIndex = 719
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
        Me.CmdClear.Location = New System.Drawing.Point(860, 182)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 55)
        Me.CmdClear.TabIndex = 718
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
        Me.CmdAdd.Location = New System.Drawing.Point(860, 124)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 55)
        Me.CmdAdd.TabIndex = 717
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(420, 339)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 724
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(203, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 200)
        Me.GroupBox1.TabIndex = 725
        Me.GroupBox1.TabStop = False
        '
        'Frm_OtherChargeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1025, 750)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.CmdFreeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Cmd_ChargeCode)
        Me.Controls.Add(Me.Cmd_Uom)
        Me.Controls.Add(Me.Txt_CCode)
        Me.Controls.Add(Me.Cmb_AmtOverRide)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_Rate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Uom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_OthItemdesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmd_OthItemHelp)
        Me.Controls.Add(Me.Txt_OthItemCode)
        Me.Controls.Add(Me.Lbl_Arrenment)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_OtherChargeMaster"
        Me.Text = "Frm_OtherChargeMaster"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Arrenment As System.Windows.Forms.Label
    Friend WithEvents Cmd_ChargeCode As System.Windows.Forms.Button
    Friend WithEvents Cmd_Uom As System.Windows.Forms.Button
    Friend WithEvents Txt_CCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmb_AmtOverRide As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Rate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Uom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_OthItemdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_OthItemHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_OthItemCode As System.Windows.Forms.TextBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
