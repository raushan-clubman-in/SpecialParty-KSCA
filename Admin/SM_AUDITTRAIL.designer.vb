<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SM_AUDITTRAIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SM_AUDITTRAIL))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BT_EXIT = New System.Windows.Forms.Button()
        Me.BT_GET = New System.Windows.Forms.Button()
        Me.rd_details = New System.Windows.Forms.RadioButton()
        Me.rd_summary = New System.Windows.Forms.RadioButton()
        Me.DTP_TO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FROM = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GP_SUMMARY = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SSGRID1 = New AxFPSpreadADO.AxfpSpread()
        Me.GP_DETAILS = New System.Windows.Forms.GroupBox()
        Me.BT_CLOSE = New System.Windows.Forms.Button()
        Me.BT_REPORT = New System.Windows.Forms.Button()
        Me.SSGRID2 = New AxFPSpreadADO.AxfpSpread()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GP_SUMMARY.SuspendLayout()
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GP_DETAILS.SuspendLayout()
        CType(Me.SSGRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(385, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PARTY AUDIT TRAIL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BT_EXIT)
        Me.GroupBox1.Controls.Add(Me.BT_GET)
        Me.GroupBox1.Controls.Add(Me.rd_details)
        Me.GroupBox1.Controls.Add(Me.rd_summary)
        Me.GroupBox1.Controls.Add(Me.DTP_TO)
        Me.GroupBox1.Controls.Add(Me.DTP_FROM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(278, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(488, 216)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'BT_EXIT
        '
        Me.BT_EXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_EXIT.Location = New System.Drawing.Point(271, 174)
        Me.BT_EXIT.Name = "BT_EXIT"
        Me.BT_EXIT.Size = New System.Drawing.Size(149, 30)
        Me.BT_EXIT.TabIndex = 7
        Me.BT_EXIT.Text = "EXIT"
        Me.BT_EXIT.UseVisualStyleBackColor = True
        '
        'BT_GET
        '
        Me.BT_GET.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GET.Location = New System.Drawing.Point(96, 174)
        Me.BT_GET.Name = "BT_GET"
        Me.BT_GET.Size = New System.Drawing.Size(149, 30)
        Me.BT_GET.TabIndex = 6
        Me.BT_GET.Text = "GET DATE "
        Me.BT_GET.UseVisualStyleBackColor = True
        '
        'rd_details
        '
        Me.rd_details.AutoSize = True
        Me.rd_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd_details.Location = New System.Drawing.Point(249, 122)
        Me.rd_details.Name = "rd_details"
        Me.rd_details.Size = New System.Drawing.Size(89, 20)
        Me.rd_details.TabIndex = 5
        Me.rd_details.TabStop = True
        Me.rd_details.Text = "DETAILS"
        Me.rd_details.UseVisualStyleBackColor = True
        '
        'rd_summary
        '
        Me.rd_summary.AutoSize = True
        Me.rd_summary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd_summary.Location = New System.Drawing.Point(109, 122)
        Me.rd_summary.Name = "rd_summary"
        Me.rd_summary.Size = New System.Drawing.Size(102, 20)
        Me.rd_summary.TabIndex = 4
        Me.rd_summary.TabStop = True
        Me.rd_summary.Text = "SUMMARY"
        Me.rd_summary.UseVisualStyleBackColor = True
        '
        'DTP_TO
        '
        Me.DTP_TO.CustomFormat = "dd/MMM/yyyy"
        Me.DTP_TO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_TO.Location = New System.Drawing.Point(331, 59)
        Me.DTP_TO.Name = "DTP_TO"
        Me.DTP_TO.Size = New System.Drawing.Size(109, 22)
        Me.DTP_TO.TabIndex = 3
        '
        'DTP_FROM
        '
        Me.DTP_FROM.CustomFormat = "dd/MMM/yyyy"
        Me.DTP_FROM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_FROM.Location = New System.Drawing.Point(137, 59)
        Me.DTP_FROM.Name = "DTP_FROM"
        Me.DTP_FROM.Size = New System.Drawing.Size(108, 22)
        Me.DTP_FROM.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(255, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "TODATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "FROM DATE"
        '
        'GP_SUMMARY
        '
        Me.GP_SUMMARY.Controls.Add(Me.Button2)
        Me.GP_SUMMARY.Controls.Add(Me.Button1)
        Me.GP_SUMMARY.Controls.Add(Me.Label4)
        Me.GP_SUMMARY.Controls.Add(Me.SSGRID1)
        Me.GP_SUMMARY.Location = New System.Drawing.Point(82, 115)
        Me.GP_SUMMARY.Name = "GP_SUMMARY"
        Me.GP_SUMMARY.Size = New System.Drawing.Size(857, 538)
        Me.GP_SUMMARY.TabIndex = 2
        Me.GP_SUMMARY.TabStop = False
        Me.GP_SUMMARY.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(462, 483)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 36)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(268, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "REPORT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(229, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(327, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "PARTY AUDIT TRAIL - SUMMARY"
        '
        'SSGRID1
        '
        Me.SSGRID1.DataSource = Nothing
        Me.SSGRID1.Location = New System.Drawing.Point(62, 59)
        Me.SSGRID1.Name = "SSGRID1"
        Me.SSGRID1.OcxState = CType(resources.GetObject("SSGRID1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID1.Size = New System.Drawing.Size(730, 393)
        Me.SSGRID1.TabIndex = 0
        '
        'GP_DETAILS
        '
        Me.GP_DETAILS.Controls.Add(Me.BT_CLOSE)
        Me.GP_DETAILS.Controls.Add(Me.BT_REPORT)
        Me.GP_DETAILS.Controls.Add(Me.SSGRID2)
        Me.GP_DETAILS.Controls.Add(Me.Label5)
        Me.GP_DETAILS.Location = New System.Drawing.Point(43, 113)
        Me.GP_DETAILS.Name = "GP_DETAILS"
        Me.GP_DETAILS.Size = New System.Drawing.Size(941, 568)
        Me.GP_DETAILS.TabIndex = 3
        Me.GP_DETAILS.TabStop = False
        Me.GP_DETAILS.Visible = False
        '
        'BT_CLOSE
        '
        Me.BT_CLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_CLOSE.Location = New System.Drawing.Point(501, 508)
        Me.BT_CLOSE.Name = "BT_CLOSE"
        Me.BT_CLOSE.Size = New System.Drawing.Size(103, 42)
        Me.BT_CLOSE.TabIndex = 8
        Me.BT_CLOSE.Text = "CLOSE"
        Me.BT_CLOSE.UseVisualStyleBackColor = True
        '
        'BT_REPORT
        '
        Me.BT_REPORT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_REPORT.Location = New System.Drawing.Point(307, 508)
        Me.BT_REPORT.Name = "BT_REPORT"
        Me.BT_REPORT.Size = New System.Drawing.Size(103, 42)
        Me.BT_REPORT.TabIndex = 7
        Me.BT_REPORT.Text = "REPORT"
        Me.BT_REPORT.UseVisualStyleBackColor = True
        '
        'SSGRID2
        '
        Me.SSGRID2.DataSource = Nothing
        Me.SSGRID2.Location = New System.Drawing.Point(24, 80)
        Me.SSGRID2.Name = "SSGRID2"
        Me.SSGRID2.OcxState = CType(resources.GetObject("SSGRID2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID2.Size = New System.Drawing.Size(890, 397)
        Me.SSGRID2.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(301, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(309, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "PARTY AUDIT TRAIL - DETAILS"
        '
        'SM_AUDITTRAIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1008, 694)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GP_SUMMARY)
        Me.Controls.Add(Me.GP_DETAILS)
        Me.Name = "SM_AUDITTRAIL"
        Me.Text = "SM_AUDITTRAIL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GP_SUMMARY.ResumeLayout(False)
        Me.GP_SUMMARY.PerformLayout()
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GP_DETAILS.ResumeLayout(False)
        Me.GP_DETAILS.PerformLayout()
        CType(Me.SSGRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rd_details As System.Windows.Forms.RadioButton
    Friend WithEvents rd_summary As System.Windows.Forms.RadioButton
    Friend WithEvents DTP_TO As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_EXIT As System.Windows.Forms.Button
    Friend WithEvents BT_GET As System.Windows.Forms.Button
    Friend WithEvents GP_SUMMARY As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SSGRID1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GP_DETAILS As System.Windows.Forms.GroupBox
    Friend WithEvents SSGRID2 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BT_CLOSE As System.Windows.Forms.Button
    Friend WithEvents BT_REPORT As System.Windows.Forms.Button
End Class
