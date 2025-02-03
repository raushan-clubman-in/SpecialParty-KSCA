<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Party_Recon_BRC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Party_Recon_BRC))
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Dtp_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Dtp_ToDate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackgroundImage = CType(resources.GetObject("Cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(865, 134)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(138, 53)
        Me.Cmd_Clear.TabIndex = 684
        Me.Cmd_Clear.Text = "CLEAR [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackgroundImage = CType(resources.GetObject("Cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(865, 249)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(138, 53)
        Me.Cmd_Exit.TabIndex = 685
        Me.Cmd_Exit.Text = "EXIT [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Dtp_FromDate)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Dtp_ToDate)
        Me.GroupBox3.Location = New System.Drawing.Point(218, 147)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(571, 61)
        Me.GroupBox3.TabIndex = 683
        Me.GroupBox3.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(318, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 15)
        Me.Label17.TabIndex = 221
        Me.Label17.Text = "TODATE"
        '
        'Dtp_FromDate
        '
        Me.Dtp_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_FromDate.Location = New System.Drawing.Point(145, 26)
        Me.Dtp_FromDate.Name = "Dtp_FromDate"
        Me.Dtp_FromDate.Size = New System.Drawing.Size(136, 20)
        Me.Dtp_FromDate.TabIndex = 218
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(66, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 15)
        Me.Label16.TabIndex = 220
        Me.Label16.Text = "FROM DATE"
        '
        'Dtp_ToDate
        '
        Me.Dtp_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_ToDate.Location = New System.Drawing.Point(390, 28)
        Me.Dtp_ToDate.Name = "Dtp_ToDate"
        Me.Dtp_ToDate.Size = New System.Drawing.Size(115, 20)
        Me.Dtp_ToDate.TabIndex = 219
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.Location = New System.Drawing.Point(187, 75)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(193, 16)
        Me.lbl_Heading.TabIndex = 687
        Me.lbl_Heading.Text = "Banquet Get-Together Report"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(865, 193)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(137, 50)
        Me.CmdView.TabIndex = 688
        Me.CmdView.Text = "Report [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'Frm_Party_Recon_BRC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1024, 750)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.GroupBox3)
        Me.DoubleBuffered = True
        Me.Name = "Frm_Party_Recon_BRC"
        Me.Text = "Party_Reconcilation"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Dtp_ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents CmdView As System.Windows.Forms.Button
End Class
