<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LIST_OPERATION1
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMB_ORDERBY = New System.Windows.Forms.ComboBox()
        Me.CMB_SRC_FIELDS = New System.Windows.Forms.ComboBox()
        Me.TXT_SEARCH_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.LBL_HEADING = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CMB_ORDERBY)
        Me.GroupBox1.Controls.Add(Me.CMB_SRC_FIELDS)
        Me.GroupBox1.Controls.Add(Me.TXT_SEARCH_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 67)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Options"
        '
        'CMB_ORDERBY
        '
        Me.CMB_ORDERBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ORDERBY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMB_ORDERBY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_ORDERBY.FormattingEnabled = True
        Me.CMB_ORDERBY.Location = New System.Drawing.Point(502, 13)
        Me.CMB_ORDERBY.Name = "CMB_ORDERBY"
        Me.CMB_ORDERBY.Size = New System.Drawing.Size(189, 23)
        Me.CMB_ORDERBY.TabIndex = 8
        Me.CMB_ORDERBY.Visible = False
        '
        'CMB_SRC_FIELDS
        '
        Me.CMB_SRC_FIELDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SRC_FIELDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMB_SRC_FIELDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_SRC_FIELDS.FormattingEnabled = True
        Me.CMB_SRC_FIELDS.Location = New System.Drawing.Point(186, 13)
        Me.CMB_SRC_FIELDS.Name = "CMB_SRC_FIELDS"
        Me.CMB_SRC_FIELDS.Size = New System.Drawing.Size(189, 23)
        Me.CMB_SRC_FIELDS.TabIndex = 0
        Me.CMB_SRC_FIELDS.Visible = False
        '
        'TXT_SEARCH_TXT
        '
        Me.TXT_SEARCH_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SEARCH_TXT.Location = New System.Drawing.Point(119, 36)
        Me.TXT_SEARCH_TXT.Name = "TXT_SEARCH_TXT"
        Me.TXT_SEARCH_TXT.Size = New System.Drawing.Size(314, 21)
        Me.TXT_SEARCH_TXT.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Search Text :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(426, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Order By :"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Search Fields :"
        Me.Label1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.Location = New System.Drawing.Point(13, 113)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 44
        Me.DataGridView1.Size = New System.Drawing.Size(690, 268)
        Me.DataGridView1.TabIndex = 9
        '
        'LBL_HEADING
        '
        Me.LBL_HEADING.AutoSize = True
        Me.LBL_HEADING.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_HEADING.Location = New System.Drawing.Point(225, 11)
        Me.LBL_HEADING.Name = "LBL_HEADING"
        Me.LBL_HEADING.Size = New System.Drawing.Size(162, 26)
        Me.LBL_HEADING.TabIndex = 10
        Me.LBL_HEADING.Text = "LBLHEADING"
        Me.LBL_HEADING.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LIST_OPERATION1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(718, 395)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LBL_HEADING)
        Me.KeyPreview = True
        Me.Name = "LIST_OPERATION1"
        Me.Text = "Help Window"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMB_SRC_FIELDS As System.Windows.Forms.ComboBox
    Friend WithEvents TXT_SEARCH_TXT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LBL_HEADING As System.Windows.Forms.Label
    Friend WithEvents CMB_ORDERBY As System.Windows.Forms.ComboBox
End Class
