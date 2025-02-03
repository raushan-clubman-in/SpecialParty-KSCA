Imports System.Data.SqlClient
Public Class FRM_MKGA_BOM
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents grp_Cocktail As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Menuitemcode As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemuom As System.Windows.Forms.Label
    Friend WithEvents lbl_Salerate As System.Windows.Forms.Label
    Friend WithEvents txt_Menucode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Menucodehelp As System.Windows.Forms.Button
    Friend WithEvents lbl_menuname As System.Windows.Forms.Label
    Friend WithEvents txt_Salerate As System.Windows.Forms.TextBox
    Friend WithEvents txt_Menuname As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Itemuom As System.Windows.Forms.ComboBox
    Friend WithEvents ssgrid2 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Cmd_brse As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_BOM))
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Cmd_brse = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.grp_Cocktail = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear1 = New System.Windows.Forms.Button()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_Menuitemcode = New System.Windows.Forms.Label()
        Me.lbl_Itemuom = New System.Windows.Forms.Label()
        Me.lbl_Salerate = New System.Windows.Forms.Label()
        Me.txt_Menucode = New System.Windows.Forms.TextBox()
        Me.Cmd_Menucodehelp = New System.Windows.Forms.Button()
        Me.lbl_menuname = New System.Windows.Forms.Label()
        Me.txt_Salerate = New System.Windows.Forms.TextBox()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.ssgrid2 = New AxFPSpreadADO.AxfpSpread()
        Me.txt_Menuname = New System.Windows.Forms.TextBox()
        Me.Cbo_Itemuom = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.frmbut.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ssgrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Button2)
        Me.frmbut.Controls.Add(Me.Cmd_brse)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.Cmd_Freeze)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Location = New System.Drawing.Point(862, 91)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(152, 572)
        Me.frmbut.TabIndex = 36
        Me.frmbut.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(3, 404)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 65)
        Me.Button2.TabIndex = 326
        Me.Button2.Text = "Authorize"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Cmd_brse
        '
        Me.Cmd_brse.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_brse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_brse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_brse.ForeColor = System.Drawing.Color.Black
        Me.Cmd_brse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_brse.Location = New System.Drawing.Point(2, 332)
        Me.Cmd_brse.Name = "Cmd_brse"
        Me.Cmd_brse.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_brse.TabIndex = 325
        Me.Cmd_brse.Text = "Browse"
        Me.Cmd_brse.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.SpecialParty.My.Resources.Resources.Clear
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(2, 119)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 324
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.SpecialParty.My.Resources.Resources._Exit
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(3, 477)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Exit.TabIndex = 12
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.SpecialParty.My.Resources.Resources.Delete
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(3, 189)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 10
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.SpecialParty.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(3, 260)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_View.TabIndex = 11
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = Global.SpecialParty.My.Resources.Resources.save
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(3, 49)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 9
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Navy
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(792, 504)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 323
        Me.cmdexport.Text = " Export[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(190, 81)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(132, 16)
        Me.lbl_Heading.TabIndex = 19
        Me.lbl_Heading.Text = "BILL OF MATERIAL "
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(214, 502)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(328, 25)
        Me.lbl_Freeze.TabIndex = 35
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'grp_Cocktail
        '
        Me.grp_Cocktail.BackColor = System.Drawing.Color.Transparent
        Me.grp_Cocktail.Location = New System.Drawing.Point(180, 128)
        Me.grp_Cocktail.Name = "grp_Cocktail"
        Me.grp_Cocktail.Size = New System.Drawing.Size(676, 88)
        Me.grp_Cocktail.TabIndex = 20
        Me.grp_Cocktail.TabStop = False
        '
        'Cmd_Clear1
        '
        Me.Cmd_Clear1.BackColor = System.Drawing.Color.Navy
        Me.Cmd_Clear1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear1.Location = New System.Drawing.Point(86, 504)
        Me.Cmd_Clear1.Name = "Cmd_Clear1"
        Me.Cmd_Clear1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear1.TabIndex = 13
        Me.Cmd_Clear1.Text = "Clear[F6]"
        Me.Cmd_Clear1.UseVisualStyleBackColor = False
        Me.Cmd_Clear1.Visible = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(136, 268)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(792, 272)
        Me.ssgrid.TabIndex = 369
        '
        'lbl_Menuitemcode
        '
        Me.lbl_Menuitemcode.AutoSize = True
        Me.lbl_Menuitemcode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Menuitemcode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Menuitemcode.Location = New System.Drawing.Point(194, 148)
        Me.lbl_Menuitemcode.Name = "lbl_Menuitemcode"
        Me.lbl_Menuitemcode.Size = New System.Drawing.Size(104, 14)
        Me.lbl_Menuitemcode.TabIndex = 21
        Me.lbl_Menuitemcode.Text = "MENU ITEM CODE :"
        '
        'lbl_Itemuom
        '
        Me.lbl_Itemuom.AutoSize = True
        Me.lbl_Itemuom.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Itemuom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemuom.Location = New System.Drawing.Point(197, 185)
        Me.lbl_Itemuom.Name = "lbl_Itemuom"
        Me.lbl_Itemuom.Size = New System.Drawing.Size(100, 14)
        Me.lbl_Itemuom.TabIndex = 24
        Me.lbl_Itemuom.Text = "MENU ITEM UOM :"
        '
        'lbl_Salerate
        '
        Me.lbl_Salerate.AutoSize = True
        Me.lbl_Salerate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Salerate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Salerate.Location = New System.Drawing.Point(524, 187)
        Me.lbl_Salerate.Name = "lbl_Salerate"
        Me.lbl_Salerate.Size = New System.Drawing.Size(71, 14)
        Me.lbl_Salerate.TabIndex = 25
        Me.lbl_Salerate.Text = "SALE RATE :"
        Me.lbl_Salerate.Visible = False
        '
        'txt_Menucode
        '
        Me.txt_Menucode.BackColor = System.Drawing.Color.White
        Me.txt_Menucode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menucode.Location = New System.Drawing.Point(308, 143)
        Me.txt_Menucode.MaxLength = 10
        Me.txt_Menucode.Name = "txt_Menucode"
        Me.txt_Menucode.Size = New System.Drawing.Size(144, 20)
        Me.txt_Menucode.TabIndex = 0
        '
        'Cmd_Menucodehelp
        '
        Me.Cmd_Menucodehelp.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Menucodehelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Menucodehelp.Location = New System.Drawing.Point(452, 140)
        Me.Cmd_Menucodehelp.Name = "Cmd_Menucodehelp"
        Me.Cmd_Menucodehelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Menucodehelp.TabIndex = 22
        Me.Cmd_Menucodehelp.Text = "?"
        Me.Cmd_Menucodehelp.UseVisualStyleBackColor = False
        '
        'lbl_menuname
        '
        Me.lbl_menuname.AutoSize = True
        Me.lbl_menuname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_menuname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_menuname.Location = New System.Drawing.Point(483, 146)
        Me.lbl_menuname.Name = "lbl_menuname"
        Me.lbl_menuname.Size = New System.Drawing.Size(106, 14)
        Me.lbl_menuname.TabIndex = 23
        Me.lbl_menuname.Text = "MENU ITEM NAME :"
        '
        'txt_Salerate
        '
        Me.txt_Salerate.BackColor = System.Drawing.Color.White
        Me.txt_Salerate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Salerate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Salerate.Location = New System.Drawing.Point(599, 183)
        Me.txt_Salerate.MaxLength = 15
        Me.txt_Salerate.Name = "txt_Salerate"
        Me.txt_Salerate.ReadOnly = True
        Me.txt_Salerate.Size = New System.Drawing.Size(144, 20)
        Me.txt_Salerate.TabIndex = 2
        Me.txt_Salerate.Visible = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(544, 448)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(386, 163)
        Me.AxfpSpread1.TabIndex = 380
        '
        'ssgrid2
        '
        Me.ssgrid2.DataSource = Nothing
        Me.ssgrid2.Location = New System.Drawing.Point(192, 264)
        Me.ssgrid2.Name = "ssgrid2"
        Me.ssgrid2.OcxState = CType(resources.GetObject("ssgrid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid2.Size = New System.Drawing.Size(608, 208)
        Me.ssgrid2.TabIndex = 3
        '
        'txt_Menuname
        '
        Me.txt_Menuname.BackColor = System.Drawing.Color.White
        Me.txt_Menuname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Menuname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menuname.Location = New System.Drawing.Point(594, 143)
        Me.txt_Menuname.MaxLength = 15
        Me.txt_Menuname.Name = "txt_Menuname"
        Me.txt_Menuname.Size = New System.Drawing.Size(256, 20)
        Me.txt_Menuname.TabIndex = 18
        '
        'Cbo_Itemuom
        '
        Me.Cbo_Itemuom.BackColor = System.Drawing.Color.White
        Me.Cbo_Itemuom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Itemuom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Itemuom.Location = New System.Drawing.Point(308, 180)
        Me.Cbo_Itemuom.Name = "Cbo_Itemuom"
        Me.Cbo_Itemuom.Size = New System.Drawing.Size(168, 22)
        Me.Cbo_Itemuom.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(200, 613)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(458, 15)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Press F4 for HELP/Press F3 for DELETE item in grid/Press ENTER key to navigate"
        Me.Label6.Visible = False
        '
        'FRM_MKGA_BOM
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1026, 744)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Menuname)
        Me.Controls.Add(Me.txt_Salerate)
        Me.Controls.Add(Me.lbl_menuname)
        Me.Controls.Add(Me.txt_Menucode)
        Me.Controls.Add(Me.lbl_Salerate)
        Me.Controls.Add(Me.lbl_Itemuom)
        Me.Controls.Add(Me.lbl_Menuitemcode)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Cbo_Itemuom)
        Me.Controls.Add(Me.ssgrid2)
        Me.Controls.Add(Me.Cmd_Menucodehelp)
        Me.Controls.Add(Me.Cmd_Clear1)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.grp_Cocktail)
        Me.Controls.Add(Me.cmdexport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_BOM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BILL OF MATERIAL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.frmbut.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ssgrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim i As Integer
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode As String
    Private Sub Cock_Tail_Ratio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CockTailRatioTransbool = True
        txt_Menucode.Enabled = True
        txt_Menucode.ReadOnly = False
        txt_Menuname.ReadOnly = False
        CockTailRatioTransbool = True
        ssgrid2.SetActiveCell(1, 1)
        Call FILLUOM()
    End Sub
    Private Sub FILLUOM()
        Dim i As Integer
        sqlstring = "SELECT UOMCODE FROM UOMMASTER WHERE freeze='N'"
        gconnection.getDataSet(sqlstring, "UOMMaster1")
        Cbo_Itemuom.Items.Clear()
        Cbo_Itemuom.Sorted = True
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                Cbo_Itemuom.Items.Add(gdataset.Tables("UOMMaster1").Rows(i).Item("UOMCODE"))
            Next i
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear1.Click
        Call clearform(Me)
        'Call FILLUOM()
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Void  On "
        ssgrid2.ClearRange(1, 1, -1, -1, True)
        Me.Cmd_Freeze.Text = "Void [F8]"
        Cmd_Add.Text = "Add [F7]"
        ssgrid2.SetActiveCell(1, 1)
        txt_Menucode.Enabled = True
        txt_Menucode.ReadOnly = False
        txt_Menuname.ReadOnly = False
        txt_Menucode.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        ' Dim totalamt, totalqty As Double
        Dim sqlstring As String
        Dim Insert(0) As String
        Dim i As Integer
        Call checkValidation() ''--->Check Validation
        If boolchk = False Then Exit Sub

        ''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
        'With ssgrid2
        '    Me.txt_Totalamount.Text = 0
        '    Me.txt_Totalqty.Text = 0
        '    For i = 1 To .DataRowCnt
        '        .Row = i
        '        .Col = 4
        '        totalqty = Val(.Text)
        '        Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(totalqty), "0.000")
        '        .Col = 6
        '        totalamt = Val(.Text)
        '        Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(totalamt), "0.00")
        '    Next i
        'End With
        ''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
        ''*********************************************************** Case-1 : Add [F7] *******************************************'''

        If Cmd_Add.Text = "Add [F7]" Then
            sqlstring = "INSERT INTO BOM_hdr(Itemcode,Itemname,ItemUOM,Void,Adduser,Adddate)"
            sqlstring = sqlstring & " VALUES ('" & Trim(txt_Menucode.Text) & "',"
            sqlstring = sqlstring & "'" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
            sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            Insert(0) = sqlstring
            ''******************************************************** Insert into Grn_details **********************************'''
            For i = 1 To ssgrid2.DataRowCnt
                With ssgrid2
                    sqlstring = "INSERT INTO BOM_det(Itemcode,Itemname,ItemUOM,gitemcode,"
                    ' sqlstring = sqlstring & " gitemname,gUOM,gqty,grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
                    sqlstring = sqlstring & " gitemname,gUOM,gqty,gdblamt,Void,Adduser,Adddate)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Menucode.Text) & "','" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                    sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
                    .Row = i
                    .Col = 1
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 2
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 3
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 4
                    sqlstring = sqlstring & "" & Format(Val(.Text), "0.000000") & ","
                    '.Col = 5
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                    '.Col = 6
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                    .Col = 4
                    sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                    '.Col = 9
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                    '.Col = 10
                    'sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    '.Col = 11
                    'sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End With
            Next i
            ''****************************************** UPDATE Opening Stock ***************************************
            'For i = 1 To ssgrid2.DataRowCnt
            '    With ssgrid2
            '        .Row = i
            '        sqlstring = "UPDATE OpeningStock SET "
            '        .Col = 4
            '        sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
            '        .Col = 8
            '        sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
            '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        .Col = 1
            '        sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
            '        ReDim Preserve Insert(Insert.Length)
            '        Insert(Insert.Length - 1) = sqlstring
            '    End With
            'Next i
            ''****************************************** UPDATE Completed ********************************************
            gconnection.MoreTransold(Insert)
            'If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            '    Call Cmd_View_Click(Cmd_View, e)
            '    Call Cmd_Clear_Click(sender, e)
            'Else
            Call Cmd_Clear_Click(sender, e)
            'End If
            ''*********************************************************** Case-2 : Update [F7] *******************************************'''
        Else
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            ''********************************************************** UPDATE GRN_HEADER *********************************************************'''
            'sqlstring = " UPDATE cocktailratio_hdr SET Itemname='" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
            'sqlstring = sqlstring & " ItemUOM='" & Trim(Cbo_Itemuom.Text) & "',ItemEOQ='" & Format(Val(txt_Eoq.Text), "0.000") & "',"
            'sqlstring = sqlstring & " Itemtype='" & Trim(cbo_Type.Text) & "',totalqty='" & Format(Val(txt_Totalqty.Text), "0.000") & "',"
            'sqlstring = sqlstring & " totalamt='" & Format(Val(txt_Totalamount.Text), "0.00") & "',Void='N',"
            'sqlstring = sqlstring & " Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
            'sqlstring = sqlstring & " WHERE itemcode='" & Trim(txt_ItemCode.Text) & "' "
            sqlstring = " UPDATE bom_hdr SET Itemname='" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
            sqlstring = sqlstring & " ItemUOM='" & Trim(Cbo_Itemuom.Text) & "',"
            sqlstring = sqlstring & " Void='N',"
            sqlstring = sqlstring & " Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
            sqlstring = sqlstring & " WHERE itemcode='" & Trim(txt_Menucode.Text) & "' and itemuom='" & Trim(Cbo_Itemuom.Text) & "'"
            Insert(0) = sqlstring
            ''********************************************************* DELETE FROM GRN_DETAILS *****************************************************'''
            sqlstring = "DELETE FROM BOM_det WHERE itemcode='" & Trim(txt_Menucode.Text) & "' and itemuom='" & Trim(Cbo_Itemuom.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            ''******************************************************** INSERT INTO GRN_DETAILS ******************************************************'''
            For i = 1 To ssgrid2.DataRowCnt
                With ssgrid2
                    sqlstring = "INSERT INTO BOM_det(Itemcode,Itemname,ItemUOM,gitemcode,"
                    sqlstring = sqlstring & " gitemname,gUOM,gqty,gdblamt,Void,Adduser,Adddate)" ',grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Menucode.Text) & "','" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                    sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
                    .Row = i
                    .Col = 1
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 2
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 3
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 4
                    sqlstring = sqlstring & "" & Format(Val(.Text), "0.000000") & ","
                    .Col = 4
                    sqlstring = sqlstring & "" & Format(Val(.Text), "0.000000") & ","
                    '.Col = 6
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                    '.Col = 7
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                    '.Col = 9
                    'sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                    '.Col = 10
                    'sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    '.Col = 11
                    'sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End With
            Next i
            ''****************************************** UPDATE Opening Stock ***************************************
            'For i = 1 To ssgrid2.DataRowCnt
            '    With ssgrid2
            '        .Row = i
            '        sqlstring = "UPDATE OpeningStock SET "
            '        .Col = 4
            '        sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
            '        .Col = 8
            '        sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
            '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        .Col = 1
            '        sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
            '        ReDim Preserve Insert(Insert.Length)
            '        Insert(Insert.Length - 1) = sqlstring
            '    End With
            'Next i
            ''****************************************** UPDATE Completed ********************************************
            gconnection.MoreTransold(Insert)
            'If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            'Call Cmd_View_Click(Cmd_View, e)
            'Call Cmd_Clear_Click(sender, e)
            'Else
            Call Cmd_Clear_Click(sender, e)
            'End If
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        Dim i As Integer
        Dim insert(0) As String
        Dim status As Integer
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            ''***************************************** Void the DOCNO in BOMheader **************************'''
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  BOM_hdr "
                sqlstring = sqlstring & " SET Void= 'Y',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "BOM_hdr")
                insert(0) = sqlstring


                ''***************************************** Void the DOCNO in Complete **********************************'''
                ''***************************************** Void the DOCNO in BOMdetails **************************'''
                For i = 1 To ssgrid2.DataRowCnt
                    With ssgrid2
                        sqlstring = "UPDATE  BOM_det "
                        sqlstring = sqlstring & " SET Void= 'Y',"
                        sqlstring = sqlstring & " UPDATEUSER='" & gUsername & " ',"
                        sqlstring = sqlstring & " UPDATETIME ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                        sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                    End With
                Next i
                ''***************************************** Void the DOCNO is Complete **********************************'''
                ''****************************************** UPDATE Opening Stock ***************************************
                'For i = 1 To ssgrid2.DataRowCnt
                '    With ssgrid2
                '        .Row = i
                '        sqlstring = "UPDATE OpeningStock SET "
                '        .Col = 4
                '        sqlstring = sqlstring & " mainclstock = mainclstock - " & Format(Val(.Text), "0") & ","
                '        .Col = 8
                '        sqlstring = sqlstring & " doublevalue= doublevalue - " & Format(Val(.Text), "0.00") & ","
                '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                '        .Col = 1
                '        sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
                '        ReDim Preserve insert(insert.Length)
                '        insert(insert.Length - 1) = sqlstring
                '    End With
                'Next i
                ''****************************************** UPDATE Completed ********************************************
                gconnection.MoreTransold(insert)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If
            'Else
            '    status = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If status = 1 Then
            '        sqlstring = "UPDATE  BOM_hdr "
            '        sqlstring = sqlstring & " SET Void= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "BOM_hdr")
            '        insert(0) = sqlstring
            '        ''***************************************** Void the DOCNO in Complete **********************************'''
            '        ''***************************************** Void the DOCNO in BOMdetails **************************'''
            '        For i = 1 To ssgrid2.DataRowCnt
            '            With ssgrid2
            '                sqlstring = "UPDATE  BOM_det "
            '                sqlstring = sqlstring & " SET Void= 'N',"
            '                sqlstring = sqlstring & " Adduser='" & gUsername & " ',"
            '                sqlstring = sqlstring & " Adddate ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
            '                ReDim Preserve insert(insert.Length)
            '                insert(insert.Length - 1) = sqlstring
            '            End With
            '            gconnection.MoreTransold(insert)
            '            Me.Cmd_Clear_Click(sender, e)
            '            Cmd_Add.Text = "Add [F7]"
            '        Next i
            '    Else
            '        Exit Sub
            '    End If

        End If

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        'Dim objCocktailratio As New frmCocktailratiochart
        'objCocktailratio.Show()
        'GroupBox3.Visible = True
       
        'Dim sqlstring, SSQL As String
        'Dim Viewer As New ReportViwer
        'Dim r As New CrptBOM
        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String
        'sqlstring = "select * from BOM_REPORT order by itemcode "

        'Call Viewer.GetDetails(sqlstring, "BOM_REPORT", r)
        'Viewer.TableName = "BOM_REPORT"
        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
        'TXTOBJ5.Text = gCompanyname

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        'TXTOBJ1.Text = "UserName : " & gUsername
        'Viewer.Show()
        Dim FRM As New ReportDesigner
        If txt_Menucode.Text.Length > 0 Then
            tables = " FROM bom_det WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
        Else
            tables = "FROM bom_det "
        End If
        Gheader = "BOM DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"ITEMCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMNAME", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMUOM", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GITEMCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GITEMNAME", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GUOM", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GQTY", "4"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GRATE", "6"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GAMOUNT", "6"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cock_Tail_Ratio_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        CockTailRatioTransbool = False
    End Sub

    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Item Code Can't be blank *********************'''
        If Trim(txt_Menucode.Text) = "" Then
            MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Menucode.Focus()
            Exit Sub
        End If
        ''********** Check  Item desc Can't be blank *********************'''
        'If Trim(txt_ItemDesc.Text) = "" Then
        '    MessageBox.Show(" Item Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_ItemDesc.Focus()
        '    Exit Sub
        'End If
        ''********** Check  EOQ Can't be blank *********************'''
        'If Val(txt_Eoq.Text) = 0 Then
        '    MessageBox.Show(" EOQ can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_Eoq.Focus()
        '    Exit Sub
        'End If
        ''********** Check  UOM Can't be blank *********************'''
        If Trim(Cbo_Itemuom.Text) = "" Then
            MessageBox.Show(" UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cbo_Itemuom.Focus()
            Exit Sub
        End If
        '' ********** Check ItemCode,ItemDesc,UOM,Rate can't be blank ***********'''
        For i = 1 To ssgrid2.DataRowCnt
            ssgrid2.Row = i
            ssgrid2.Col = 1
            If Trim(ssgrid2.Text) = "" Then
                MessageBox.Show("ItemCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                ssgrid2.Focus()
                Exit Sub
            End If
            ssgrid2.Col = 2
            If Trim(ssgrid2.Text) = "" Then
                MessageBox.Show("Itemdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid2.SetActiveCell(2, ssgrid2.ActiveRow)
                ssgrid2.Focus()
                Exit Sub
            End If
            ssgrid2.Col = 3
            If Trim(ssgrid2.Text) = "" Then
                MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                ssgrid2.Focus()
                Exit Sub
            End If
            ssgrid2.Col = 4
            If Val(ssgrid2.Text) = 0 Then
                MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid2.SetActiveCell(4, ssgrid2.ActiveRow)
                ssgrid2.Focus()
                Exit Sub
            End If
            'ssgrid2.Col = 5
            'If Val(ssgrid2.Text) = 0 Then
            '    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(5, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
            'ssgrid2.Col = 6
            'If Val(ssgrid2.Text) = 0 Then
            '    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(6, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
            'ssgrid2.Col = 7
            'If Val(ssgrid2.Text) = 0 Then
            '    MessageBox.Show("dblamount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(7, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
            'ssgrid2.Col = 9
            'If Val(ssgrid2.Text) = 0 Then
            '    MessageBox.Show("High Ratio can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(8, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
            'ssgrid2.Col = 10
            'If Trim(ssgrid2.Text) = "" Then
            '    MessageBox.Show("Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(9, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
            'ssgrid2.Col = 11
            'If Trim(ssgrid2.Text) = "" Then
            '    MessageBox.Show("Sub Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    ssgrid2.SetActiveCell(10, ssgrid2.ActiveRow)
            '    ssgrid2.Focus()
            '    Exit Sub
            'End If
        Next i
        boolchk = True
    End Sub



    Private Sub Cock_Tail_Ratio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear1, e)
            Exit Sub
            'ElseIf e.KeyCode = Keys.F8 Then
            '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
            '    Exit Sub
            'ElseIf e.KeyCode = Keys.F7 Then
            '    Call Cmd_Add_Click(Cmd_Add, e)
            '    Exit Sub
        End If

        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If Cmd_View.Enabled = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            'txt_ItemCode.Text = ""
            'txt_ItemCode.Focus()
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.R Then
            'Me.txt_Remarks.Focus()
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.G Then
            Me.ssgrid2.Focus()
            Me.ssgrid2.SetActiveCell(1, 1)
            Exit Sub
        End If

        If e.Alt = True And e.KeyCode = Keys.U Then
            'Me.cbo_Uom.Focus()
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.T Then
            'Me.cbo_Type.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_ItemDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cbo_Itemuom.Focus()
        End If
    End Sub

    Private Sub cbo_Uom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid2.Focus()
        End If
    End Sub

    Private Sub cbo_ITEMUom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid2.Focus()
        End If
    End Sub

    Private Sub txt_Eoq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid2.Focus()
        End If
    End Sub

    Private Sub FillMenu()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        'Dim vform As New ListOperattion1
        ' '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO ssgrid2 ********** 
        'gSQLString = " SELECT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0) AS AVGRATE, "
        'gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
        'gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
        'If Trim(vsearch) = " " Then
        '    M_WhereCondition = " "
        'Else
        '    M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
        'End If
        'vform.Field = "I.ITEMCODE,I.ITEMNAME"
        'vform.vFormatstring = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
        'vform.vCaption = "INVENTORY ITEM CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    Call GridUOM(ssgrid2.ActiveRow) '''---> Fill the UOM feild
        '    ssgrid2.Col = 1
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield)
        '    'For K = 1 To ssgrid2.DataRowCnt
        '    '    ssgrid2.Row = K
        '    '    ssgrid2.Col = 1
        '    '    If Itemvalidate(ssgrid2, Trim(vform.keyfield), 1) = True Then
        '    '        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
        '    '        ssgrid2.Focus()
        '    '        Exit Sub
        '    '    End If
        '    'Next
        '    ssgrid2.Col = 2
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield1)
        '    ssgrid2.Col = 3
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
        '    ssgrid2.TypeComboBoxString = vform.keyfield2
        '    ssgrid2.Text = Trim(vform.keyfield2)
        '    ssgrid2.Col = 5
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    Avgrate = CalAverageRate(Trim(vform.keyfield))
        '    'ssgrid2.Text = Format(Val(Avgrate), "0.00")
        '    ssgrid2.Text = Format(Val(vform.keyfield3), "0.00")
        '    ssgrid2.Col = 8
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield4)
        '    ssgrid2.Col = 9
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Format(Val(vform.keyfield5), "0.00")
        '    ssgrid2.Col = 10
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield6)
        '    ssgrid2.Col = 11
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield7)
        '    'clsquantity = ClosingQuantity(Trim(vform.keyfield), "MNS")
        '    clsquantity = ClosingQuantity(Trim(vform.keyfield), GetMainStore())
        '    ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
        '    ssgrid2.Focus()
        'Else
        '    ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
        '    Exit Sub
        'End If
        'vform.Close()
        'vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = " SELECT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0) AS AVGRATE, "
            gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.CATEGORY,'') AS CATEGORY FROM INVENTORYITEMMASTER AS I  "
            gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
            M_WhereCondition = "WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
            vform.Field = "I.ITEMNAME,I.ITEMCODE"
            ' vform.Frmcalled = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
            vform.vCaption = " InventoryItem Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ssgrid2.Col = 1
                ssgrid2.Row = ssgrid2.ActiveRow
                ssgrid2.Text = Trim(vform.keyfield)
                'For K = 1 To ssgrid2.DataRowCnt
                '    ssgrid2.Row = K
                '    ssgrid2.Col = 1
                '    If Itemvalidate(ssgrid2, Trim(vform.keyfield1), 1) = True Then
                '        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                '        ssgrid2.Focus()
                '        Exit Sub
                '    End If
                'Next
                'ssgrid2.Col = 2
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Trim(vform.keyfield1)
                'ssgrid2.Col = 3
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                'ssgrid2.TypeComboBoxString = vform.keyfield2
                'ssgrid2.Text = Trim(vform.keyfield2)
                ''ssgrid2.Col = 5
                ''ssgrid2.Row = ssgrid2.ActiveRow
                ''Avgrate = CalAverageRate(Trim(vform.keyfield1))
                ''ssgrid2.Text = Format(Val(Avgrate), "0.00")
                ''ssgrid2.Col = 8
                ''ssgrid2.Row = ssgrid2.ActiveRow
                ''ssgrid2.Text = Trim(vform.keyfield4)
                ''ssgrid2.Col = 9
                ''ssgrid2.Row = ssgrid2.ActiveRow
                ''ssgrid2.Text = Format(Val(vform.keyfield5), "0.00")
                ''ssgrid2.Col = 10
                ''ssgrid2.Row = ssgrid2.ActiveRow
                ''ssgrid2.Text = Trim(vform.keyfield6)
                ''ssgrid2.Col = 11
                ''ssgrid2.Row = ssgrid2.ActiveRow
                ''ssgrid2.Text = Trim(vform.keyfield7)
                ''clsquantity = ClosingQuantity(Trim(vform.keyfield1), "MNS")
                'clsquantity = ClosingQuantity(Trim(vform.keyfield1), GetMainStore())
                'ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                'ssgrid2.Focus()
                Dim itemcode As String
                'ssgrid2.Row = i
                i = ssgrid2.ActiveRow
                itemcode = Trim(vform.keyfield)
                ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
                ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                    Call GridUOM(i) ''---> Fill the UOM feild
                    ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMCODE")))
                    'For K = 1 To ssgrid2.DataRowCnt
                    '    ssgrid2.Row = K
                    '    ssgrid2.Col = 1
                    '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                    '        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
                    '        ssgrid2.Focus()
                    '        Exit Sub
                    '    End If
                    'Next
                    ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMNAME")))
                    ssgrid2.Col = 3
                    ssgrid2.Row = i
                    ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("STOCKUOM"))
                    ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("STOCKUOM"))
                    'Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                    ' ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                    ' ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                    ' ssgrid2.SetText(4, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("HIGHRATIO")))
                    'ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                    ' ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                    '                            clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
                    clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMCODE")), GetMainStore())
                    'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                    ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                    ssgrid2.Focus()
                End If
            Else
                ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
    Private Sub FillMenuItem()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        'Dim vform As New ListOperattion1
        'Dim ssql As String
        ' '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO ssgrid2 ********** 
        ''gSQLString = " SELECT   ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(i.purchaserate,0) AS AVGRATE, "
        ''gSQLString = gSQLString & " ISNULL(I.STOCKUOM,'') AS CONVUOM,ISNULL(1,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
        ' ''gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
        'gSQLString = " SELECT   ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
        'gSQLString = gSQLString & "ISNULL(1,0) AS HIGHRATIO  FROM INVENTORYITEMMASTER AS I  "

        'If Trim(vsearch) = " " Then
        '    M_WhereCondition = " "
        'Else
        '    M_WhereCondition = " WHERE I.ITEMNAME like '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
        'End If
        'vform.Field = "I.ITEMNAME,I.ITEMCODE"
        'vform.vFormatstring = "             ITEMNAME               |  ITEMCODE    | STOCKUOM | HIGHRATIO |"
        'vform.vCaption = "INVENTORY ITEM CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        '' vform.Keypos5 = 5
        ''vform.Keypos6 = 6
        '' vform.Keypos7 = 7
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    ssgrid2.Col = 1
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield1)
        '    'For K = 1 To ssgrid2.DataRowCnt
        '    '    ssgrid2.Row = K
        '    '    ssgrid2.Col = 1
        '    '    If Itemvalidate(ssgrid2, Trim(vform.keyfield1), 1) = True Then
        '    '        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
        '    '        ssgrid2.Focus()
        '    '        Exit Sub
        '    '    End If
        '    'Next
        '    ssgrid2.Col = 2
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.Text = Trim(vform.keyfield)
        '    ssgrid2.Col = 3
        '    ssgrid2.Row = ssgrid2.ActiveRow
        '    ssgrid2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
        '    ssgrid2.TypeComboBoxString = vform.keyfield2
        '    ssgrid2.Text = Trim(vform.keyfield2)
        '    'ssgrid2.Col = 5
        '    'ssgrid2.Row = ssgrid2.ActiveRow
        '    'Avgrate = CalAverageRate(Trim(vform.keyfield1))
        '    'ssgrid2.Text = Format(Val(Avgrate), "0.00")
        '    'ssgrid2.Col = 8
        '    'ssgrid2.Row = ssgrid2.ActiveRow
        '    'ssgrid2.Text = Trim(vform.keyfield4)
        '    'ssgrid2.Col = 9
        '    'ssgrid2.Row = ssgrid2.ActiveRow
        '    'ssgrid2.Text = Format(Val(vform.keyfield5), "0.00")
        '    'ssgrid2.Col = 10
        '    'ssgrid2.Row = ssgrid2.ActiveRow
        '    'ssgrid2.Text = Trim(vform.keyfield6)
        '    'ssgrid2.Col = 11
        '    'ssgrid2.Row = ssgrid2.ActiveRow
        '    'ssgrid2.Text = Trim(vform.keyfield7)
        '    'clsquantity = ClosingQuantity(Trim(vform.keyfield1), "MNS")
        '    clsquantity = ClosingQuantity(Trim(vform.keyfield1), GetMainStore())
        '    ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
        '    ssgrid2.Focus()
        'Else
        '    ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
        '    Exit Sub
        'End If
        'vform.Close()
        'vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = " SELECT   ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
            gSQLString = gSQLString & "ISNULL(1,0) AS HIGHRATIO  FROM INVENTORYITEMMASTER AS I  "
            M_WhereCondition = "WHERE I.ITEMNAME like '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
            vform.Field = "I.ITEMCODE,I.ITEMNAME"
            ' vform.Frmcalled = "              ITEMCODE               |  ITEMNAME    | STOCKUOM | HIGHRATIO |"
            vform.vCaption = " InventoryItem Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ssgrid2.Col = 1
                ssgrid2.Row = ssgrid2.ActiveRow
                ssgrid2.Text = Trim(vform.keyfield)
                'For K = 1 To ssgrid2.DataRowCnt
                '    ssgrid2.Row = K
                '    ssgrid2.Col = 1
                '    If Itemvalidate(ssgrid2, Trim(vform.keyfield1), 1) = True Then
                '        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                '        ssgrid2.Focus()
                '        Exit Sub
                '    End If
                'Next
                'ssgrid2.Col = 2
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Trim(vform.keyfield1)
                'ssgrid2.Col = 3
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                'ssgrid2.TypeComboBoxString = vform.keyfield2
                'ssgrid2.Text = Trim(vform.keyfield2)
                'ssgrid2.Col = 5
                'ssgrid2.Row = ssgrid2.ActiveRow
                'Avgrate = CalAverageRate(Trim(vform.keyfield1))
                'ssgrid2.Text = Format(Val(Avgrate), "0.00")
                'ssgrid2.Col = 8
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Trim(vform.keyfield4)
                'ssgrid2.Col = 9
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Format(Val(vform.keyfield5), "0.00")
                'ssgrid2.Col = 10
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Trim(vform.keyfield6)
                'ssgrid2.Col = 11
                'ssgrid2.Row = ssgrid2.ActiveRow
                'ssgrid2.Text = Trim(vform.keyfield7)
                'clsquantity = ClosingQuantity(Trim(vform.keyfield1), "MNS")
                'clsquantity = ClosingQuantity(Trim(vform.keyfield1), GetMainStore())
                'ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                'ssgrid2.Focus()
                'ssgrid2.Row = i
                i = ssgrid2.ActiveRow
                Dim itemcode As String
                Itemcode = Trim(vform.keyfield)
                ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
                ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                    Call GridUOM(i) ''---> Fill the UOM feild
                    ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMCODE")))
                    'For K = 1 To ssgrid2.DataRowCnt
                    '    ssgrid2.Row = K
                    '    ssgrid2.Col = 1
                    '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                    '        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
                    '        ssgrid2.Focus()
                    '        Exit Sub
                    '    End If
                    'Next
                    ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMNAME")))
                    ssgrid2.Col = 3
                    ssgrid2.Row = i
                    ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("STOCKUOM"))
                    ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("STOCKUOM"))
                    'Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                    ' ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                    ' ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                    ' ssgrid2.SetText(4, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("HIGHRATIO")))
                    'ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                    ' ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                    '                            clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
                    clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(0).Item("ITEMCODE")), GetMainStore())
                    'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                    ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                    ssgrid2.Focus()
                End If
            Else
                ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
    'Private Sub Calculate()
    '    Dim ValQty, ValRate, ValDiscount, VarTotal, clsquantiy As Double
    '    Dim ValHighratio, ValItemamount, ValDblamount, Calqty As Double
    '    Dim Itemcode As String
    '    Dim i, j As Integer
    '    If ssgrid2.ActiveCol = 1 Or ssgrid2.ActiveCol = 2 Or ssgrid2.ActiveCol = 3 Or ssgrid2.ActiveCol = 4 Or ssgrid2.ActiveCol = 5 Or ssgrid2.ActiveCol = 6 Then
    '        i = ssgrid2.ActiveRow
    '        ssgrid2.Col = 4
    '        ssgrid2.Row = i
    '        'ValQty = Val(ssgrid2.Text)
    '        'ssgrid2.Col = 5
    '        'ssgrid2.Row = i
    '        'ValRate = Val(ssgrid2.Text)
    '        'ssgrid2.Col = 9
    '        'ssgrid2.Row = i
    '        'ValHighratio = Val(ssgrid2.Text())
    '        'ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
    '        'ValDblamount = Format(Val(ValQty) * Val(ValHighratio), "0.000")
    '        'If Val(ValItemamount) = 0 Then
    '        '    ssgrid2.SetText(6, i, "")
    '        '    ssgrid2.SetText(7, i, "")
    '        'Else
    '        '    ssgrid2.SetText(6, i, Val(ValItemamount))
    '        '    ssgrid2.SetText(7, i, Val(ValDblamount))
    '        'End If
    '        ssgrid2.Col = 1
    '        ssgrid2.Row = ssgrid2.ActiveRow
    '        Itemcode = Trim(ssgrid2.Text)
    '        For j = 1 To ssgrid2.DataRowCnt
    '            ssgrid2.Col = 1
    '            ssgrid2.Row = j
    '            If Trim(Itemcode) = Trim(ssgrid2.Text) Then
    '                ssgrid2.Col = 4
    '                ssgrid2.Row = j
    '                Calqty = Calqty + Val(ssgrid2.Text)
    '            End If
    '        Next
    '        i = i - 1
    '    End If
    'End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Dim j As Integer
        sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
        gconnection.getDataSet(sqlstring, "UOMMaster1")
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                ssgrid2.Col = 3
                ssgrid2.Row = i
                ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                ssgrid2.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
            Next j
        End If
    End Sub

    Private Sub cbo_Type_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'txt_Eoq.Focus()
        End If
    End Sub

    Private Sub ssgrid2_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid2.KeyDownEvent
        Dim Issuerate, clsquantity As Double
        '  Dim ItemQty, ItemAmount, ItemRate As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        ' Dim focusbool As Boolean
        Dim i, j, K As Integer
        Search = Nothing
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgrid2.ActiveRow
                If ssgrid2.ActiveCol = 1 Then
                    ssgrid2.Col = 1
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            Call FillMenu() '' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemcode = Trim(ssgrid2.Text)
                            ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
                            ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) ''---> Fill the UOM feild
                                ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To ssgrid2.DataRowCnt
                                '    ssgrid2.Row = K
                                '    ssgrid2.Col = 1
                                '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
                                '        ssgrid2.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid2.Col = 3
                                ssgrid2.Row = i
                                ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ' ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                ' ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                ssgrid2.SetText(4, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                'ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                ' ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                '                            clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
                                clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                                ssgrid2.Focus()
                            Else
                                MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
                                ssgrid2.Text = ""
                                ssgrid2.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                    End If
                ElseIf ssgrid2.ActiveCol = 2 Then
                    ssgrid2.Col = 2
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            Call FillMenuItem() '' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid2.Text)
                            ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
                            ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) ''---> Fill the UOM feild
                                ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To ssgrid2.DataRowCnt
                                '    ssgrid2.Row = K
                                '    ssgrid2.Col = 1
                                '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                                '        ssgrid2.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid2.Col = 3
                                ssgrid2.Row = i
                                ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                '  ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                ' ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                ssgrid2.SetText(4, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                ' ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                'ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                '                           clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
                                clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
                                ssgrid2.Text = ""
                                ssgrid2.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 3 Then
                    ssgrid2.Col = 3
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            ssgrid2.SetActiveCell(2, ssgrid2.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 4 Then
                    ssgrid2.Col = 4
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Val(ssgrid2.Text) = 0 Then
                            ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
                        Else
                            'Call Calculate() '''--> Calculate total amount
                            ssgrid2.Row = ssgrid2.ActiveRow + 1
                            ssgrid2.Col = 1
                            ssgrid2.Lock = False
                            ssgrid2.Col = 2
                            ssgrid2.Lock = False
                            ssgrid2.Col = 3
                            ssgrid2.Lock = False
                            ssgrid2.Col = 4
                            ssgrid2.Lock = False
                            ssgrid2.Col = 5
                            ssgrid2.Lock = False
                            ssgrid2.Col = 6
                            ssgrid2.Lock = False
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 5 Then
                    ssgrid2.Col = 5
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Val(ssgrid2.Text) = 0 Then
                            ssgrid2.SetActiveCell(4, ssgrid2.ActiveRow)
                        Else
                            'Call Calculate() '''--> Calculate total amount
                            ssgrid2.Row = ssgrid2.ActiveRow + 1
                            ssgrid2.Col = 1
                            ssgrid2.Lock = False
                            ssgrid2.Col = 2
                            ssgrid2.Lock = False
                            ssgrid2.Col = 3
                            ssgrid2.Lock = False
                            ssgrid2.Col = 4
                            ssgrid2.Lock = False
                            ssgrid2.Col = 5
                            ssgrid2.Lock = False
                            ssgrid2.Col = 6
                            ssgrid2.Lock = False
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 6 Then
                    ssgrid2.Col = 6
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Val(ssgrid2.Text) = 0 Then
                            ssgrid2.SetActiveCell(5, ssgrid2.ActiveRow)
                        Else
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    Else
                        ssgrid2.SetActiveCell(6, ssgrid2.ActiveRow)
                    End If
                ElseIf ssgrid2.ActiveCol = 7 Then
                    ssgrid2.Col = 7
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            ssgrid2.SetActiveCell(6, ssgrid2.ActiveRow)
                        Else
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 8 Then
                    ssgrid2.Col = 8
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            ssgrid2.SetActiveCell(7, ssgrid2.ActiveRow)
                        Else
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid2.ActiveCol = 9 Then
                    ssgrid2.Col = 9
                    i = ssgrid2.ActiveRow
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        If Trim(ssgrid2.Text) = "" Then
                            ssgrid2.SetActiveCell(8, ssgrid2.ActiveRow)
                        Else
                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F4 Then
                If ssgrid2.ActiveCol = 1 Then
                    ssgrid2.Col = 1
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        ssgrid2.Col = 1
                        ssgrid2.Row = ssgrid2.ActiveRow
                        Search = Trim(ssgrid2.Text)
                        Call FillMenu()
                    End If
                ElseIf ssgrid2.ActiveCol = 2 Then
                    ssgrid2.Col = 2
                    ssgrid2.Row = i
                    If ssgrid2.Lock = False Then
                        ssgrid2.Col = 2
                        ssgrid2.Row = ssgrid2.ActiveRow
                        Search = Trim(ssgrid2.Text)
                        Call FillMenuItem()
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid2.Col = ssgrid2.ActiveCol
                i = ssgrid2.ActiveRow
                ssgrid2.Row = i
                If ssgrid2.Lock = False Then
                    With ssgrid2
                        .Row = .ActiveRow
                        .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                        .DeleteRows(.ActiveRow, 1)
                        'Call Calculate()
                        .SetActiveCell(1, ssgrid2.ActiveRow)
                        .Focus()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub




    Private Sub Cmd_Menucodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Menucodehelp.Click
        'gSQLString = "SELECT  distinct ISNULL(ITEMDESC,'') as ITEMDESC,ISNULL(ITEMCODE,'') AS ITEMCODE FROM ITEMMASTER "
        'If Trim(Search) = " " Then
        '    'M_WhereCondition = " WHERE POS IN (SELECT STORECODE FROM STOREMASTER) "
        '    'HARD CODED FOR CSC 
        '    'M_WhereCondition = " WHERE itemtypecode='' "
        'Else
        '    'M_WhereCondition = " WHERE POS IN (SELECT STORECODE FROM STOREMASTER) "
        '    'M_WhereCondition = " WHERE itemtypecode='' "
        'End If
        'Dim vform As New ListOperattion1
        'vform.Field = "ITEMDESC,ITEMCODE"
        'vform.vFormatstring = "  ITEM DESC                                      |  ITEM CODE                       "
        'vform.vCaption = " ITEM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield1 & "") <> "" Then
        '    txt_Menucode.Text = Trim(vform.keyfield1 & "")
        '    Call txt_Menucode_Validated(txt_Menucode, e)
        'End If
        'vform.Close()
        'vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT  distinct ISNULL(ITEMCODE,'') as ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC FROM ITEMMASTER "
            M_WhereCondition = " "
            vform.Field = "ITEMCODE,ITEMDESC"
            'vform.Frmcalled = "   ITEM CODE       | ITEM NAME         |                                  "
            vform.vCaption = " Item Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Menucode.Text = Trim(vform.keyfield & "")
                txt_Menucode_Validated(sender, e)
                ssgrid2.Focus()
                ssgrid2.SetActiveCell(1, 1)
                'Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Cbo_Itemuom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.Validated
        Dim J, K As Integer
        If Trim(txt_Menucode.Text) <> "" And Trim(Cbo_Itemuom.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.ITEMCODE,'') AS ITEMCODE,ISNULL(H.ITEMNAME,'') AS ITEMDESC,ISNULL(H.ITEMUOM,'') AS ITEMUOM,"
                sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID,ADDDATE FROM BOM_HDR AS H WHERE ISNULL(H.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "' AND ISNULL(H.ITEMUOM,'') = '" & Trim(Cbo_Itemuom.Text) & "'"
                gconnection.getDataSet(sqlstring, "BOM_HDR")
                If gdataset.Tables("BOM_HDR").Rows.Count > 0 Then
                    txt_Menucode.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMCODE"))
                    txt_Menuname.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMDESC"))
                    Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDown
                    Cbo_Itemuom.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMUOM"))
                    Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                    '------------------------------------- SELECT RECORDS FROM BOM_DET -------------
                    sqlstring = "SELECT ISNULL(D.GITEMCODE,'') AS GITEMCODE,ISNULL(D.GITEMNAME,'') AS GITEMNAME,ISNULL(D.GUOM,'') AS UOM,"
                    sqlstring = sqlstring & " ISNULL(D.GQTY,0) AS QTY,ISNULL(D.GRATE,0) AS RATE,ISNULL(D.GAMOUNT,0) AS AMOUNT,ISNULL(D.GDBLAMT,0) AS DBLAMT,"
                    sqlstring = sqlstring & " ISNULL(D.GHIGHRATIO,0) AS HIGHRATIO,ISNULL(D.GGROUPCODE,'') AS GROUPCODE,ISNULL(D.GSUBGROUPCODE,'') AS SUBGROUPCODE,"
                    sqlstring = sqlstring & " ISNULL(D.VOID,'') AS VOID FROM BOM_DET AS D WHERE ISNULL(D.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "' AND ISNULL(D.ITEMUOM,'') = '" & Trim(Cbo_Itemuom.Text) & "'"
                    gconnection.getDataSet(sqlstring, "BOM_DET")
                    If gdataset.Tables("BOM_DET").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("BOM_DET").Rows.Count
                            ssgrid2.SetText(1, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GITEMCODE")))
                            ssgrid2.SetText(2, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GITEMNAME")))
                            ssgrid2.Col = 3
                            ssgrid2.Row = i
                            ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("BOM_DET").Rows(J).Item("UOM"))
                            ssgrid2.Text = Trim(gdataset.Tables("BOM_DET").Rows(J).Item("UOM"))
                            ssgrid2.SetText(4, i, Val(gdataset.Tables("BOM_DET").Rows(J).Item("QTY")))
                            'ssgrid2.SetText(5, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("RATE")), "0.00"))
                            'ssgrid2.SetText(6, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("AMOUNT")), "0.00"))
                            'ssgrid2.SetText(7, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("DBLAMT")), "0.000"))
                            'ssgrid2.SetText(9, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("HIGHRATIO")), "0.00"))
                            'ssgrid2.SetText(10, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GROUPCODE")))
                            'ssgrid2.SetText(11, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("SUBGROUPCODE")))
                            J = J + 1
                        Next
                        'Cbo_Itemuom.SelectedIndex = 0
                        'Cbo_Itemuom.Focus()
                    End If
                    If gdataset.Tables("BOM_HDR").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = Me.lbl_Freeze.Text & Format(CDate(gdataset.Tables("BOM_HDR").Rows(0).Item("AddDate")), "dd-MMM-yyyy")
                        'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Me.Cmd_Add.Text = "Update[F7]"

                    txt_Menucode.ReadOnly = True
                    txt_Menuname.ReadOnly = True
                    Me.Cmd_Add.Text = "Update[F7]"
                Else
                    ssgrid2.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show("Enter a valid ITEM CODE ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    'Private Sub Cbo_Itemuom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.SelectedIndexChanged
    '    Dim sqlstring As String
    '    If Trim(Cbo_Itemuom.Text) <> "" Then
    '        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM,ISNULL(R.ITEMRATE,0) AS ITEMRATE"
    '        sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
    '        sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(R.UOM,'') = '" & Trim(Cbo_Itemuom.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y' AND I.POS IN (SELECT STORECODE FROM STOREMASTER)"
    '        gconnection.getDataSet(sqlstring, "ITEMMASTERSELECTION")
    '        If gdataset.Tables("ITEMMASTERSELECTION").Rows.Count > 0 Then
    '            txt_Salerate.Text = Format(Val(gdataset.Tables("ITEMMASTERSELECTION").Rows(0).Item("ITEMRATE")), "0.00")
    '            ssgrid2.Focus()
    '        Else
    '            txt_Salerate.Text = ""
    '        End If
    '    Else
    '        Cbo_Itemuom.Focus()
    '    End If
    'End Sub

    Private Sub txt_Menucode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Menucode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_Menucodehelp.Enabled = True Then
                Search = Trim(txt_Menucode.Text)
                Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
            End If
        End If
    End Sub

    Private Sub txt_Menucode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Menucode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_Menucode.Text) = "" Then
                Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
            Else
                txt_Menucode_Validated(txt_Menucode, e)
                'Cbo_Itemuom.Focus()
            End If
        End If
    End Sub

    Private Sub ssgrid2_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid2.LeaveCell
        Dim Issuerate, Highratio, Dblamount, ItemQty, ItemAmount, ItemRate, clsquantity As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim i, j, K As Integer
        Search = Nothing
        'If ssgrid2.ActiveCol = 1 Or ssgrid2.ActiveCol = 2 Then
        '    Call Calculate()
        'End If
        Try
            i = ssgrid2.ActiveRow
            If ssgrid2.ActiveCol = 4 Then
                ssgrid2.Col = 4
                i = ssgrid2.ActiveRow
                ssgrid2.Row = i
                If ssgrid2.Lock = False Then
                    If Val(ssgrid2.Text) = 0 Then
                        ssgrid2.SetActiveCell(4, ssgrid2.ActiveRow)
                    Else
                        'Call Calculate() '''--> Calculate total amount
                        ssgrid2.Row = ssgrid2.ActiveRow + 1
                        ssgrid2.Col = 1
                        ssgrid2.Lock = False
                        ssgrid2.Col = 2
                        ssgrid2.Lock = False
                        ssgrid2.Col = 3
                        ssgrid2.Lock = False
                        ssgrid2.Col = 4
                        ssgrid2.Lock = False
                        'ssgrid2.Col = 5
                        'ssgrid2.Lock = False
                        'ssgrid2.Col = 6
                        'ssgrid2.Lock = False
                        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow + 1)
                    End If
                End If
                'ElseIf ssgrid2.ActiveCol = 5 Then
                '    ssgrid2.Col = 5
                '    i = ssgrid2.ActiveRow
                '    ssgrid2.Row = i
                '    If ssgrid2.Lock = False Then
                '        If Val(ssgrid2.Text) = 0 Then
                '            ssgrid2.SetActiveCell(5, ssgrid2.ActiveRow)
                '        Else
                '            'Call Calculate() '''--> Calculate total amount
                '            ssgrid2.Row = ssgrid2.ActiveRow + 1
                '            ssgrid2.Col = 1
                '            ssgrid2.Lock = False
                '            ssgrid2.Col = 2
                '            ssgrid2.Lock = False
                '            ssgrid2.Col = 3
                '            ssgrid2.Lock = False
                '            ssgrid2.Col = 4
                '            'ssgrid2.Lock = False
                '            'ssgrid2.Col = 5
                '            'ssgrid2.Lock = False
                '            'ssgrid2.Col = 6
                '            'ssgrid2.Lock = False
                '            ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow + 1)
                '        End If
                '    End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cbo_Itemuom_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Itemuom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ssgrid2.Focus()
            ssgrid2.SetActiveCell(1, 1)
        End If
    End Sub

    'Private Sub ssgrid2_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid2.KeyDownEvent
    '    Dim Issuerate, Highratio, Dblamount, clsquantity As Double
    '    Dim ItemQty, ItemAmount, ItemRate As Double
    '    Dim sqlstring, Itemcode, Itemdesc As String
    '    Dim focusbool As Boolean
    '    Dim i, j, K As Integer
    '    Search = Nothing
    '    Try
    '        If e.keyCode = Keys.Enter Then
    '            i = ssgrid2.ActiveRow
    '            If ssgrid2.ActiveCol = 1 Then
    '                ssgrid2.Col = 1
    '                ssgrid2.Row = i
    '                If ssgrid2.Lock = False Then
    '                    If Trim(ssgrid2.Text) = "" Then
    '                        'Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
    '                        FillMenuItem()
    '                    Else
    '                        Itemcode = Trim(ssgrid2.Text)
    '                        ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
    '                        ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
    '                        sqlstring = " SELECT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
    '                        sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,ISNULL(1,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
    '                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I " 'INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
    '                        sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
    '                        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
    '                        If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
    '                            Call GridUOM(i) ''---> Fill the UOM feild
    '                            ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'For K = 1 To ssgrid2.DataRowCnt
    '                            '    ssgrid2.Row = K
    '                            '    ssgrid2.Col = 1
    '                            '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
    '                            '        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
    '                            '        ssgrid2.Focus()
    '                            '        Exit Sub
    '                            '    End If
    '                            'Next
    '                            ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
    '                            ssgrid2.Col = 3
    '                            ssgrid2.Row = i
    '                            ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            'Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
    '                            'ssgrid2.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
    '                            'ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
    '                            'ssgrid2.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
    '                            'ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
    '                            'ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
    '                            'clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
    '                            'clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GetMainStore())
    '                            'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
    '                            ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
    '                            ssgrid2.Focus()
    '                        Else
    '                            MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow)
    '                            ssgrid2.Text = ""
    '                            ssgrid2.Focus()
    '                            Exit Sub
    '                        End If
    '                    End If
    '                Else
    '                    ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
    '                End If
    '            ElseIf ssgrid2.ActiveCol = 2 Then
    '                ssgrid2.Col = 2
    '                i = ssgrid2.ActiveRow
    '                ssgrid2.Row = i
    '                If ssgrid2.Lock = False Then
    '                    If Trim(ssgrid2.Text) = "" Then
    '                        Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
    '                    Else
    '                        Itemdesc = Trim(ssgrid2.Text)
    '                        ssgrid2.ClearRange(1, ssgrid2.ActiveRow, 10, ssgrid2.ActiveRow, True)
    '                        '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
    '                        'sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
    '                        'sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
    '                        'sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
    '                        'sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
    '                        sqlstring = " SELECT   ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
    '                        sqlstring = sqlstring & " ISNULL(I.CONVUOM,'') AS CONVUOM,ISNULL(I.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
    '                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
    '                        sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"

    '                        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
    '                        If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
    '                            Call GridUOM(i) '''---> Fill the UOM feild
    '                            ssgrid2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'For K = 1 To ssgrid2.DataRowCnt
    '                            '    ssgrid2.Row = K
    '                            '    ssgrid2.Col = 1
    '                            '    If Itemvalidate(ssgrid2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
    '                            '        ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
    '                            '        ssgrid2.Focus()
    '                            '        Exit Sub
    '                            '    End If
    '                            'Next
    '                            ssgrid2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
    '                            ssgrid2.Col = 3
    '                            ssgrid2.Row = i
    '                            ssgrid2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            ssgrid2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'ssgrid2.SetText(5, i, Format(Val(Issuerate), "0.00"))
    '                            'ssgrid2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
    '                            ssgrid2.SetText(4, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
    '                            'ssgrid2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
    '                            'ssgrid2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
    '                            'clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
    '                            'clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), GetMainStore())
    '                            'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
    '                            ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
    '                        Else
    '                            MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            ssgrid2.SetActiveCell(1, ssgrid2.ActiveRow)
    '                            ssgrid2.Text = ""
    '                            ssgrid2.Focus()
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            ElseIf ssgrid2.ActiveCol = 3 Then
    '                ssgrid2.Col = 3
    '                i = ssgrid2.ActiveRow
    '                ssgrid2.Row = i
    '                If ssgrid2.Lock = False Then
    '                    If Trim(ssgrid2.Text) = "" Then
    '                        ssgrid2.SetActiveCell(2, ssgrid2.ActiveRow)
    '                    End If
    '                End If
    '            ElseIf ssgrid2.ActiveCol = 4 Then
    '                ssgrid2.Col = 4
    '                i = ssgrid2.ActiveRow
    '                ssgrid2.Row = i
    '                If ssgrid2.Lock = False Then
    '                    If Val(ssgrid2.Text) = 0 Then
    '                        ssgrid2.SetActiveCell(3, ssgrid2.ActiveRow)
    '                    Else
    '                        'Call Calculate() '''--> Calculate total amount
    '                        ssgrid2.Row = ssgrid2.ActiveRow + 1
    '                        ssgrid2.Col = 1
    '                        ssgrid2.Lock = False
    '                        ssgrid2.Col = 2
    '                        ssgrid2.Lock = False
    '                        ssgrid2.Col = 3
    '                        ssgrid2.Lock = False
    '                        ssgrid2.Col = 4
    '                        ssgrid2.Lock = False
    '                        ssgrid2.Col = 5
    '                        ssgrid2.Lock = False
    '                        ssgrid2.Col = 6
    '                        ssgrid2.Lock = False
    '                        ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                    End If
    '                End If
    '                '    ElseIf ssgrid2.ActiveCol = 5 Then
    '                '        ssgrid2.Col = 5
    '                '        i = ssgrid2.ActiveRow
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            If Val(ssgrid2.Text) = 0 Then
    '                '                ssgrid2.SetActiveCell(4, ssgrid2.ActiveRow)
    '                '            Else
    '                '                'Call Calculate() '''--> Calculate total amount
    '                '                ssgrid2.Row = ssgrid2.ActiveRow + 1
    '                '                ssgrid2.Col = 1
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.Col = 2
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.Col = 3
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.Col = 4
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.Col = 5
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.Col = 6
    '                '                ssgrid2.Lock = False
    '                '                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                '            End If
    '                '        End If
    '                '    ElseIf ssgrid2.ActiveCol = 6 Then
    '                '        ssgrid2.Col = 6
    '                '        i = ssgrid2.ActiveRow
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            If Val(ssgrid2.Text) = 0 Then
    '                '                ssgrid2.SetActiveCell(5, ssgrid2.ActiveRow)
    '                '            Else
    '                '                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                '            End If
    '                '        Else
    '                '            ssgrid2.SetActiveCell(6, ssgrid2.ActiveRow)
    '                '        End If
    '                '    ElseIf ssgrid2.ActiveCol = 7 Then
    '                '        ssgrid2.Col = 7
    '                '        i = ssgrid2.ActiveRow
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            If Trim(ssgrid2.Text) = "" Then
    '                '                ssgrid2.SetActiveCell(6, ssgrid2.ActiveRow)
    '                '            Else
    '                '                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                '            End If
    '                '        End If
    '                '    ElseIf ssgrid2.ActiveCol = 8 Then
    '                '        ssgrid2.Col = 8
    '                '        i = ssgrid2.ActiveRow
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            If Trim(ssgrid2.Text) = "" Then
    '                '                ssgrid2.SetActiveCell(7, ssgrid2.ActiveRow)
    '                '            Else
    '                '                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                '            End If
    '                '        End If
    '                '    ElseIf ssgrid2.ActiveCol = 9 Then
    '                '        ssgrid2.Col = 9
    '                '        i = ssgrid2.ActiveRow
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            If Trim(ssgrid2.Text) = "" Then
    '                '                ssgrid2.SetActiveCell(8, ssgrid2.ActiveRow)
    '                '            Else
    '                '                ssgrid2.SetActiveCell(0, ssgrid2.ActiveRow + 1)
    '                '            End If
    '                '        End If
    '                '    End If
    '                'ElseIf e.keyCode = Keys.F4 Then
    '                '    If ssgrid2.ActiveCol = 1 Then
    '                '        ssgrid2.Col = 1
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            ssgrid2.Col = 1
    '                '            ssgrid2.Row = ssgrid2.ActiveRow
    '                '            Search = Trim(ssgrid2.Text)
    '                '            'Call FillMenu()
    '                '            FillMenuItem()
    '                '        End If
    '                '    ElseIf ssgrid2.ActiveCol = 2 Then
    '                '        ssgrid2.Col = 2
    '                '        ssgrid2.Row = i
    '                '        If ssgrid2.Lock = False Then
    '                '            ssgrid2.Col = 2
    '                '            ssgrid2.Row = ssgrid2.ActiveRow
    '                '            Search = Trim(ssgrid2.Text)
    '                '            Call FillMenuItem()
    '                '        End If
    '                '    End If
    '                'ElseIf e.keyCode = Keys.F3 Then
    '                '    ssgrid2.Col = ssgrid2.ActiveCol
    '                '    i = ssgrid2.ActiveRow
    '                '    ssgrid2.Row = i
    '                '    If ssgrid2.Lock = False Then
    '                '        With ssgrid2
    '                '            .Row = .ActiveRow
    '                '            .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
    '                '            .DeleteRows(.ActiveRow, 1)
    '                '            'Call Calculate()
    '                '            .SetActiveCell(1, ssgrid2.ActiveRow)
    '                '            .Focus()
    '                '        End With
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub txt_Menucode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Menucode.Validated
        If Trim(txt_Menucode.Text & "") <> "" Then
            sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM"
            sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
            sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y' " '  AND I.POS IN (SELECT POSCODE FROM POSMASTER WHERE POSDESC LIKE '%BAR%') "
            'Hard coded for csc
            'sqlstring = sqlstring & " and itemtypecode='bar' "
            gconnection.getDataSet(sqlstring, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                txt_Menucode.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMCODE"))
                txt_Menuname.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMDESC"))
                Me.Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                Cbo_Itemuom.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("UOM"))
                ' Cbo_Itemuom.Enabled = False
                Cbo_Itemuom.SelectedIndex = 0
                Call Cbo_Itemuom_Validated(sender, e)
                'For K = 0 To gdataset.Tables("ITEMMASTER").Rows.Count - 1 Step 1
                'Cbo_Itemuom.Items.Add(Trim(gdataset.Tables("ITEMMASTER").Rows(K).Item("UOM")))
                'Next K
                'Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                'Cbo_Itemuom.SelectedIndex = 0
                txt_Menucode.ReadOnly = True
                txt_Menuname.ReadOnly = True
                ' Cbo_Itemuom.Focus()
                ssgrid2.Focus()
            Else
                Me.Cmd_Add.Text = "Add [F7]"
                txt_Menucode.ReadOnly = False
                txt_Menucode.Text = ""
                txt_Menucode.Focus()
            End If
        End If
    End Sub

    'Private Sub ssgrid2_MouseDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_MouseDownEvent) Handles ssgrid2.MouseDownEvent

    'End Sub

    Private Sub txt_Menucode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Menucode.TextChanged

    End Sub

    Private Sub ssgrid2_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid2.Advance

    End Sub

    Private Sub Cbo_Itemuom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.SelectedIndexChanged

    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        'Dim sqlstring As String
        'Dim _export As New EXPORT
        '_export.TABLENAME = "BOM_det"

        'sqlstring = "SELECT * FROM BOM_det order by ITEMCODE"
        'Call _export.export_excel(sqlstring)
        '_export.Show()
        'Exit Sub
    End Sub

    'Private Sub Cmd_Clear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click

    'End Sub

    Private Sub Cmd_Clear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        'Call FILLUOM()
        Me.lbl_Freeze.Visible = False
        Cbo_Itemuom.Enabled = True
        'Cbo_Itemuom.clear()
        Me.Cmd_Freeze.Enabled = True
        Me.lbl_Freeze.Text = "Record Void  On "
        ssgrid2.ClearRange(1, 1, -1, -1, True)
        Me.Cmd_Freeze.Text = "Void [F8]"
        Cmd_Add.Text = "Add [F7]"
        ssgrid2.SetActiveCell(1, 1)
        txt_Menucode.Enabled = True
        txt_Menucode.ReadOnly = False
        txt_Menuname.ReadOnly = False
        txt_Menucode.Focus()
    End Sub

    Private Sub Cmd_brse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_brse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM BOM"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM BOM", "SERIALNO", 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE BOM set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE BOM set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM BOM WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE BOM set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub ssgrid2_KeyPressEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles ssgrid2.KeyPressEvent

    End Sub
End Class
