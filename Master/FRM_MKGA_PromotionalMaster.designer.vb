<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_PromotionalMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_PromotionalMaster))
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmb_exit = New System.Windows.Forms.Button()
        Me.cmd_excel = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.cmd_view = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grp_Qty = New System.Windows.Forms.GroupBox()
        Me.mskdate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_prodesc = New System.Windows.Forms.TextBox()
        Me.cmdPROMOHelp = New System.Windows.Forms.Button()
        Me.txtPROMOcode = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PROMOGRID = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DAYSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.CHK_LOCATION = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_ToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_QBaseUom = New System.Windows.Forms.ComboBox()
        Me.cmdBaseItemHelp = New System.Windows.Forms.Button()
        Me.txtBaseItem = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBaseName = New System.Windows.Forms.TextBox()
        Me.TXT_SALEQTY = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cbo_TYPE = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk_days = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.grp_Qty.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PROMOGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DAYSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(863, 119)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(140, 58)
        Me.Cmd_Add.TabIndex = 117
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'cmb_exit
        '
        Me.cmb_exit.BackColor = System.Drawing.Color.Transparent
        Me.cmb_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmb_exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_exit.Image = CType(resources.GetObject("cmb_exit.Image"), System.Drawing.Image)
        Me.cmb_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb_exit.Location = New System.Drawing.Point(863, 559)
        Me.cmb_exit.Name = "cmb_exit"
        Me.cmb_exit.Size = New System.Drawing.Size(140, 58)
        Me.cmb_exit.TabIndex = 123
        Me.cmb_exit.Text = "Exit [F11]"
        Me.cmb_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmb_exit.UseVisualStyleBackColor = False
        '
        'cmd_excel
        '
        Me.cmd_excel.BackColor = System.Drawing.Color.Transparent
        Me.cmd_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_excel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_excel.Location = New System.Drawing.Point(863, 437)
        Me.cmd_excel.Name = "cmd_excel"
        Me.cmd_excel.Size = New System.Drawing.Size(140, 58)
        Me.cmd_excel.TabIndex = 122
        Me.cmd_excel.Text = "Browse"
        Me.cmd_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_excel.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(863, 374)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(140, 58)
        Me.Button8.TabIndex = 121
        Me.Button8.Text = "Report "
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = False
        '
        'cmd_view
        '
        Me.cmd_view.BackColor = System.Drawing.Color.Transparent
        Me.cmd_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_view.Image = CType(resources.GetObject("cmd_view.Image"), System.Drawing.Image)
        Me.cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_view.Location = New System.Drawing.Point(863, 311)
        Me.cmd_view.Name = "cmd_view"
        Me.cmd_view.Size = New System.Drawing.Size(140, 58)
        Me.cmd_view.TabIndex = 120
        Me.cmd_view.Text = "View [F9]"
        Me.cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_view.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(863, 245)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(140, 58)
        Me.Cmd_Freeze.TabIndex = 119
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(863, 182)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(140, 58)
        Me.Cmd_Clear.TabIndex = 118
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 19)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Promotional Master"
        '
        'grp_Qty
        '
        Me.grp_Qty.BackColor = System.Drawing.Color.Transparent
        Me.grp_Qty.Controls.Add(Me.mskdate)
        Me.grp_Qty.Controls.Add(Me.Label4)
        Me.grp_Qty.Controls.Add(Me.Label2)
        Me.grp_Qty.Controls.Add(Me.txt_prodesc)
        Me.grp_Qty.Controls.Add(Me.cmdPROMOHelp)
        Me.grp_Qty.Controls.Add(Me.txtPROMOcode)
        Me.grp_Qty.Controls.Add(Me.Panel1)
        Me.grp_Qty.Controls.Add(Me.Label12)
        Me.grp_Qty.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_Qty.Location = New System.Drawing.Point(192, 98)
        Me.grp_Qty.Name = "grp_Qty"
        Me.grp_Qty.Size = New System.Drawing.Size(653, 112)
        Me.grp_Qty.TabIndex = 431
        Me.grp_Qty.TabStop = False
        '
        'mskdate
        '
        Me.mskdate.CustomFormat = "dd/MM/yyyy"
        Me.mskdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskdate.Location = New System.Drawing.Point(488, 21)
        Me.mskdate.Name = "mskdate"
        Me.mskdate.Size = New System.Drawing.Size(136, 20)
        Me.mskdate.TabIndex = 456
        Me.mskdate.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(358, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 14)
        Me.Label4.TabIndex = 455
        Me.Label4.Text = "DATE OF CREATION :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 454
        Me.Label2.Text = "DESCRIPTION :"
        '
        'txt_prodesc
        '
        Me.txt_prodesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_prodesc.Location = New System.Drawing.Point(155, 54)
        Me.txt_prodesc.MaxLength = 30
        Me.txt_prodesc.Name = "txt_prodesc"
        Me.txt_prodesc.Size = New System.Drawing.Size(336, 22)
        Me.txt_prodesc.TabIndex = 453
        '
        'cmdPROMOHelp
        '
        Me.cmdPROMOHelp.Location = New System.Drawing.Point(276, 20)
        Me.cmdPROMOHelp.Name = "cmdPROMOHelp"
        Me.cmdPROMOHelp.Size = New System.Drawing.Size(29, 22)
        Me.cmdPROMOHelp.TabIndex = 452
        Me.cmdPROMOHelp.Text = "F4"
        Me.cmdPROMOHelp.UseVisualStyleBackColor = True
        '
        'txtPROMOcode
        '
        Me.txtPROMOcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPROMOcode.Location = New System.Drawing.Point(155, 21)
        Me.txtPROMOcode.MaxLength = 10
        Me.txtPROMOcode.Name = "txtPROMOcode"
        Me.txtPROMOcode.Size = New System.Drawing.Size(115, 22)
        Me.txtPROMOcode.TabIndex = 451
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(8, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(680, 264)
        Me.Panel1.TabIndex = 450
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Promotional Details"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 14)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "PROMOTIONAL CODE :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.PROMOGRID)
        Me.GroupBox2.Location = New System.Drawing.Point(191, 306)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 154)
        Me.GroupBox2.TabIndex = 433
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PROMOTIONAL ON :"
        '
        'PROMOGRID
        '
        Me.PROMOGRID.DataSource = Nothing
        Me.PROMOGRID.Location = New System.Drawing.Point(6, 20)
        Me.PROMOGRID.Name = "PROMOGRID"
        Me.PROMOGRID.OcxState = CType(resources.GetObject("PROMOGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PROMOGRID.Size = New System.Drawing.Size(554, 127)
        Me.PROMOGRID.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.DAYSGRID)
        Me.GroupBox3.Location = New System.Drawing.Point(567, 458)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(278, 215)
        Me.GroupBox3.TabIndex = 434
        Me.GroupBox3.TabStop = False
        '
        'DAYSGRID
        '
        Me.DAYSGRID.DataSource = Nothing
        Me.DAYSGRID.Location = New System.Drawing.Point(3, 16)
        Me.DAYSGRID.Name = "DAYSGRID"
        Me.DAYSGRID.OcxState = CType(resources.GetObject("DAYSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAYSGRID.Size = New System.Drawing.Size(275, 193)
        Me.DAYSGRID.TabIndex = 0
        '
        'CHK_LOCATION
        '
        Me.CHK_LOCATION.FormattingEnabled = True
        Me.CHK_LOCATION.Location = New System.Drawing.Point(366, 495)
        Me.CHK_LOCATION.Name = "CHK_LOCATION"
        Me.CHK_LOCATION.Size = New System.Drawing.Size(166, 154)
        Me.CHK_LOCATION.TabIndex = 436
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(363, 467)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 435
        Me.Label5.Text = "POS Code"
        '
        'Cmb_FromDate
        '
        Me.Cmb_FromDate.CustomFormat = "dd/MM/yyyy"
        Me.Cmb_FromDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Cmb_FromDate.Location = New System.Drawing.Point(85, 19)
        Me.Cmb_FromDate.Name = "Cmb_FromDate"
        Me.Cmb_FromDate.Size = New System.Drawing.Size(82, 20)
        Me.Cmb_FromDate.TabIndex = 458
        Me.Cmb_FromDate.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 457
        Me.Label6.Text = "FROM DATE :"
        '
        'Cmb_ToDate
        '
        Me.Cmb_ToDate.CustomFormat = "dd/MM/yyyy"
        Me.Cmb_ToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Cmb_ToDate.Location = New System.Drawing.Point(85, 64)
        Me.Cmb_ToDate.Name = "Cmb_ToDate"
        Me.Cmb_ToDate.Size = New System.Drawing.Size(82, 20)
        Me.Cmb_ToDate.TabIndex = 460
        Me.Cmb_ToDate.Value = New Date(2012, 12, 10, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 459
        Me.Label7.Text = "TO DATE :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbo_QBaseUom)
        Me.GroupBox1.Controls.Add(Me.cmdBaseItemHelp)
        Me.GroupBox1.Controls.Add(Me.txtBaseItem)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtBaseName)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(191, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 88)
        Me.GroupBox1.TabIndex = 461
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SALE ON"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(8, 144)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(680, 264)
        Me.Panel2.TabIndex = 450
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(248, 24)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Promotional Details"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(29, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 14)
        Me.Label9.TabIndex = 447
        Me.Label9.Text = "BASE UOM :"
        '
        'cbo_QBaseUom
        '
        Me.cbo_QBaseUom.BackColor = System.Drawing.Color.Wheat
        Me.cbo_QBaseUom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_QBaseUom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_QBaseUom.Location = New System.Drawing.Point(140, 50)
        Me.cbo_QBaseUom.Name = "cbo_QBaseUom"
        Me.cbo_QBaseUom.Size = New System.Drawing.Size(104, 22)
        Me.cbo_QBaseUom.Sorted = True
        Me.cbo_QBaseUom.TabIndex = 446
        '
        'cmdBaseItemHelp
        '
        Me.cmdBaseItemHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBaseItemHelp.Location = New System.Drawing.Point(246, 14)
        Me.cmdBaseItemHelp.Name = "cmdBaseItemHelp"
        Me.cmdBaseItemHelp.Size = New System.Drawing.Size(23, 26)
        Me.cmdBaseItemHelp.TabIndex = 440
        Me.cmdBaseItemHelp.Text = "?"
        '
        'txtBaseItem
        '
        Me.txtBaseItem.BackColor = System.Drawing.Color.Wheat
        Me.txtBaseItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBaseItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseItem.Location = New System.Drawing.Point(139, 17)
        Me.txtBaseItem.MaxLength = 10
        Me.txtBaseItem.Name = "txtBaseItem"
        Me.txtBaseItem.Size = New System.Drawing.Size(104, 20)
        Me.txtBaseItem.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(28, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 14)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "ITEM CODE :"
        '
        'txtBaseName
        '
        Me.txtBaseName.BackColor = System.Drawing.Color.Wheat
        Me.txtBaseName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseName.Location = New System.Drawing.Point(271, 16)
        Me.txtBaseName.MaxLength = 15
        Me.txtBaseName.Name = "txtBaseName"
        Me.txtBaseName.ReadOnly = True
        Me.txtBaseName.Size = New System.Drawing.Size(176, 20)
        Me.txtBaseName.TabIndex = 1
        '
        'TXT_SALEQTY
        '
        Me.TXT_SALEQTY.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SALEQTY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_SALEQTY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SALEQTY.Location = New System.Drawing.Point(706, 250)
        Me.TXT_SALEQTY.MaxLength = 2
        Me.TXT_SALEQTY.Name = "TXT_SALEQTY"
        Me.TXT_SALEQTY.Size = New System.Drawing.Size(104, 20)
        Me.TXT_SALEQTY.TabIndex = 451
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(724, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 14)
        Me.Label10.TabIndex = 452
        Me.Label10.Text = "SALE QTY :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(202, 188)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 14)
        Me.Label13.TabIndex = 463
        Me.Label13.Text = "PROMOTIONAL TYPE :"
        '
        'Cbo_TYPE
        '
        Me.Cbo_TYPE.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_TYPE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_TYPE.Items.AddRange(New Object() {"QTY", "FIXED RATE", "DISCOUNT ON RATE", "DISCOUNT "})
        Me.Cbo_TYPE.Location = New System.Drawing.Point(347, 183)
        Me.Cbo_TYPE.Name = "Cbo_TYPE"
        Me.Cbo_TYPE.Size = New System.Drawing.Size(150, 22)
        Me.Cbo_TYPE.TabIndex = 462
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Cmb_FromDate)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Cmb_ToDate)
        Me.GroupBox4.Location = New System.Drawing.Point(179, 512)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(182, 100)
        Me.GroupBox4.TabIndex = 464
        Me.GroupBox4.TabStop = False
        '
        'chk_days
        '
        Me.chk_days.FormattingEnabled = True
        Me.chk_days.Location = New System.Drawing.Point(9, 216)
        Me.chk_days.Name = "chk_days"
        Me.chk_days.Size = New System.Drawing.Size(140, 424)
        Me.chk_days.TabIndex = 465
        Me.chk_days.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(485, 45)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 16)
        Me.lbl_Freeze.TabIndex = 466
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(863, 498)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(140, 58)
        Me.cmd_auth.TabIndex = 467
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        '
        'FRM_MKGA_PromotionalMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.chk_days)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Cbo_TYPE)
        Me.Controls.Add(Me.TXT_SALEQTY)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CHK_LOCATION)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grp_Qty)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.cmb_exit)
        Me.Controls.Add(Me.cmd_excel)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.cmd_view)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_PromotionalMaster"
        Me.Text = "PromotionalMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_Qty.ResumeLayout(False)
        Me.grp_Qty.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PROMOGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DAYSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmb_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_excel As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents cmd_view As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_Qty As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_prodesc As System.Windows.Forms.TextBox
    Friend WithEvents cmdPROMOHelp As System.Windows.Forms.Button
    Friend WithEvents txtPROMOcode As System.Windows.Forms.TextBox
    Friend WithEvents mskdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PROMOGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DAYSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents CHK_LOCATION As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmb_FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_QBaseUom As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBaseItemHelp As System.Windows.Forms.Button
    Friend WithEvents txtBaseItem As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBaseName As System.Windows.Forms.TextBox
    Friend WithEvents TXT_SALEQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Cbo_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_days As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
End Class
