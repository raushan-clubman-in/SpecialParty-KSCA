<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VIEWHDR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VIEWHDR))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveExcelFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.DTGRDHDR = New System.Windows.Forms.DataGridView()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(806, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 10)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "EXPORT"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'DTGRDHDR
        '
        Me.DTGRDHDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGRDHDR.Location = New System.Drawing.Point(3, 0)
        Me.DTGRDHDR.Name = "DTGRDHDR"
        Me.DTGRDHDR.Size = New System.Drawing.Size(842, 489)
        Me.DTGRDHDR.TabIndex = 2
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackgroundImage = CType(resources.GetObject("Cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(181, 495)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(136, 53)
        Me.Cmd_Exit.TabIndex = 209
        Me.Cmd_Exit.Text = "EXIT[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.BackgroundImage = CType(resources.GetObject("Cmd_Export.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(39, 495)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(136, 53)
        Me.Cmd_Export.TabIndex = 210
        Me.Cmd_Export.Text = "EXPORT[F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'VIEWHDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 558)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.DTGRDHDR)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.Name = "VIEWHDR"
        Me.Text = "VIEW"
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveExcelFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DTGRDHDR As System.Windows.Forms.DataGridView
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
End Class
