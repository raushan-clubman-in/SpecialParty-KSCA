<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_ItemMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_ItemMaster))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CHKLOCNO = New System.Windows.Forms.CheckBox()
        Me.CHKLOCYES = New System.Windows.Forms.CheckBox()
        Me.CHKFBNO = New System.Windows.Forms.CheckBox()
        Me.CHKFBYES = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdKitchenHelp = New System.Windows.Forms.Button()
        Me.cmdType = New System.Windows.Forms.Button()
        Me.CBO_CATEGORY = New System.Windows.Forms.ComboBox()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.TxtKitchenCode = New System.Windows.Forms.TextBox()
        Me.CMDSUBCODE = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTypedes = New System.Windows.Forms.TextBox()
        Me.cmdGroup = New System.Windows.Forms.Button()
        Me.TXT_SUBDESC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGroupDes = New System.Windows.Forms.TextBox()
        Me.cmdItemHelp = New System.Windows.Forms.Button()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtShort = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtItemType = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_subcode = New System.Windows.Forms.TextBox()
        Me.txtGroupcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LstPOScode = New System.Windows.Forms.CheckedListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.FraRate = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CHK_MRPTAG = New System.Windows.Forms.CheckBox()
        Me.CmbUOm = New System.Windows.Forms.ComboBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txt_mrprate = New System.Windows.Forms.TextBox()
        Me.txtPurchaseRate = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.FraGrid = New System.Windows.Forms.GroupBox()
        Me.cbo_BaseUOM = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_BaseRate = New System.Windows.Forms.TextBox()
        Me.B = New System.Windows.Forms.Label()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.ChkOPENITEMFACILITY = New System.Windows.Forms.CheckBox()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FraRate.SuspendLayout()
        Me.FraGrid.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CHKLOCNO)
        Me.GroupBox1.Controls.Add(Me.CHKLOCYES)
        Me.GroupBox1.Controls.Add(Me.CHKFBNO)
        Me.GroupBox1.Controls.Add(Me.CHKFBYES)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmdKitchenHelp)
        Me.GroupBox1.Controls.Add(Me.cmdType)
        Me.GroupBox1.Controls.Add(Me.CBO_CATEGORY)
        Me.GroupBox1.Controls.Add(Me.txtItemCode)
        Me.GroupBox1.Controls.Add(Me.TxtKitchenCode)
        Me.GroupBox1.Controls.Add(Me.CMDSUBCODE)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTypedes)
        Me.GroupBox1.Controls.Add(Me.cmdGroup)
        Me.GroupBox1.Controls.Add(Me.TXT_SUBDESC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtGroupDes)
        Me.GroupBox1.Controls.Add(Me.cmdItemHelp)
        Me.GroupBox1.Controls.Add(Me.txtItemDesc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtShort)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtItemType)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Txt_subcode)
        Me.GroupBox1.Controls.Add(Me.txtGroupcode)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(195, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(646, 209)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CHKLOCNO
        '
        Me.CHKLOCNO.AutoSize = True
        Me.CHKLOCNO.Location = New System.Drawing.Point(186, 181)
        Me.CHKLOCNO.Name = "CHKLOCNO"
        Me.CHKLOCNO.Size = New System.Drawing.Size(41, 18)
        Me.CHKLOCNO.TabIndex = 116
        Me.CHKLOCNO.Text = "NO"
        Me.CHKLOCNO.UseVisualStyleBackColor = True
        '
        'CHKLOCYES
        '
        Me.CHKLOCYES.AutoSize = True
        Me.CHKLOCYES.Location = New System.Drawing.Point(133, 180)
        Me.CHKLOCYES.Name = "CHKLOCYES"
        Me.CHKLOCYES.Size = New System.Drawing.Size(46, 18)
        Me.CHKLOCYES.TabIndex = 115
        Me.CHKLOCYES.Text = "YES"
        Me.CHKLOCYES.UseVisualStyleBackColor = True
        '
        'CHKFBNO
        '
        Me.CHKFBNO.AutoSize = True
        Me.CHKFBNO.Location = New System.Drawing.Point(186, 157)
        Me.CHKFBNO.Name = "CHKFBNO"
        Me.CHKFBNO.Size = New System.Drawing.Size(41, 18)
        Me.CHKFBNO.TabIndex = 114
        Me.CHKFBNO.Text = "NO"
        Me.CHKFBNO.UseVisualStyleBackColor = True
        '
        'CHKFBYES
        '
        Me.CHKFBYES.AutoSize = True
        Me.CHKFBYES.Location = New System.Drawing.Point(134, 157)
        Me.CHKFBYES.Name = "CHKFBYES"
        Me.CHKFBYES.Size = New System.Drawing.Size(46, 18)
        Me.CHKFBYES.TabIndex = 113
        Me.CHKFBYES.Text = "YES"
        Me.CHKFBYES.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 15)
        Me.Label18.TabIndex = 112
        Me.Label18.Text = "Location Wise Tax"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 155)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 15)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "Food and Beverage "
        '
        'cmdKitchenHelp
        '
        Me.cmdKitchenHelp.Location = New System.Drawing.Point(573, 171)
        Me.cmdKitchenHelp.Name = "cmdKitchenHelp"
        Me.cmdKitchenHelp.Size = New System.Drawing.Size(40, 23)
        Me.cmdKitchenHelp.TabIndex = 108
        Me.cmdKitchenHelp.Text = "?"
        Me.cmdKitchenHelp.UseVisualStyleBackColor = True
        '
        'cmdType
        '
        Me.cmdType.Location = New System.Drawing.Point(244, 69)
        Me.cmdType.Name = "cmdType"
        Me.cmdType.Size = New System.Drawing.Size(40, 23)
        Me.cmdType.TabIndex = 108
        Me.cmdType.Text = "?"
        Me.cmdType.UseVisualStyleBackColor = True
        '
        'CBO_CATEGORY
        '
        Me.CBO_CATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_CATEGORY.FormattingEnabled = True
        Me.CBO_CATEGORY.Location = New System.Drawing.Point(433, 44)
        Me.CBO_CATEGORY.Name = "CBO_CATEGORY"
        Me.CBO_CATEGORY.Size = New System.Drawing.Size(178, 22)
        Me.CBO_CATEGORY.TabIndex = 96
        '
        'txtItemCode
        '
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Location = New System.Drawing.Point(121, 19)
        Me.txtItemCode.MaxLength = 10
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(116, 20)
        Me.txtItemCode.TabIndex = 100
        '
        'TxtKitchenCode
        '
        Me.TxtKitchenCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKitchenCode.Location = New System.Drawing.Point(433, 173)
        Me.TxtKitchenCode.MaxLength = 10
        Me.TxtKitchenCode.Name = "TxtKitchenCode"
        Me.TxtKitchenCode.Size = New System.Drawing.Size(137, 20)
        Me.TxtKitchenCode.TabIndex = 107
        '
        'CMDSUBCODE
        '
        Me.CMDSUBCODE.Location = New System.Drawing.Point(244, 97)
        Me.CMDSUBCODE.Name = "CMDSUBCODE"
        Me.CMDSUBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMDSUBCODE.TabIndex = 107
        Me.CMDSUBCODE.Text = "?"
        Me.CMDSUBCODE.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(322, 175)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 15)
        Me.Label17.TabIndex = 106
        Me.Label17.Text = "Kitchen Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Group Code"
        '
        'txtTypedes
        '
        Me.txtTypedes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTypedes.Location = New System.Drawing.Point(433, 76)
        Me.txtTypedes.MaxLength = 40
        Me.txtTypedes.Name = "txtTypedes"
        Me.txtTypedes.Size = New System.Drawing.Size(178, 20)
        Me.txtTypedes.TabIndex = 105
        '
        'cmdGroup
        '
        Me.cmdGroup.Location = New System.Drawing.Point(244, 126)
        Me.cmdGroup.Name = "cmdGroup"
        Me.cmdGroup.Size = New System.Drawing.Size(40, 23)
        Me.cmdGroup.TabIndex = 106
        Me.cmdGroup.Text = "?"
        Me.cmdGroup.UseVisualStyleBackColor = True
        Me.cmdGroup.Visible = False
        '
        'TXT_SUBDESC
        '
        Me.TXT_SUBDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_SUBDESC.Location = New System.Drawing.Point(433, 107)
        Me.TXT_SUBDESC.MaxLength = 35
        Me.TXT_SUBDESC.Name = "TXT_SUBDESC"
        Me.TXT_SUBDESC.Size = New System.Drawing.Size(178, 20)
        Me.TXT_SUBDESC.TabIndex = 104
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Sub Group Code"
        '
        'txtGroupDes
        '
        Me.txtGroupDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupDes.Location = New System.Drawing.Point(433, 140)
        Me.txtGroupDes.MaxLength = 35
        Me.txtGroupDes.Name = "txtGroupDes"
        Me.txtGroupDes.Size = New System.Drawing.Size(178, 20)
        Me.txtGroupDes.TabIndex = 103
        '
        'cmdItemHelp
        '
        Me.cmdItemHelp.Location = New System.Drawing.Point(244, 21)
        Me.cmdItemHelp.Name = "cmdItemHelp"
        Me.cmdItemHelp.Size = New System.Drawing.Size(40, 23)
        Me.cmdItemHelp.TabIndex = 105
        Me.cmdItemHelp.Text = "F4"
        Me.cmdItemHelp.UseVisualStyleBackColor = True
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Location = New System.Drawing.Point(433, 18)
        Me.txtItemDesc.MaxLength = 35
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(178, 20)
        Me.txtItemDesc.TabIndex = 102
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(322, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Tax Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(322, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Category"
        '
        'txtShort
        '
        Me.txtShort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShort.Location = New System.Drawing.Point(121, 44)
        Me.txtShort.MaxLength = 10
        Me.txtShort.Name = "txtShort"
        Me.txtShort.Size = New System.Drawing.Size(116, 20)
        Me.txtShort.TabIndex = 104
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(322, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Short Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(322, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 15)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Description"
        '
        'txtItemType
        '
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Location = New System.Drawing.Point(121, 71)
        Me.txtItemType.MaxLength = 10
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(116, 20)
        Me.txtItemType.TabIndex = 103
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(322, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 15)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Item Code"
        '
        'Txt_subcode
        '
        Me.Txt_subcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_subcode.Location = New System.Drawing.Point(121, 99)
        Me.Txt_subcode.MaxLength = 10
        Me.Txt_subcode.Name = "Txt_subcode"
        Me.Txt_subcode.Size = New System.Drawing.Size(116, 20)
        Me.Txt_subcode.TabIndex = 102
        '
        'txtGroupcode
        '
        Me.txtGroupcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupcode.Location = New System.Drawing.Point(121, 127)
        Me.txtGroupcode.MaxLength = 10
        Me.txtGroupcode.Name = "txtGroupcode"
        Me.txtGroupcode.Size = New System.Drawing.Size(116, 20)
        Me.txtGroupcode.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(192, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Master"
        '
        'LstPOScode
        '
        Me.LstPOScode.FormattingEnabled = True
        Me.LstPOScode.Location = New System.Drawing.Point(267, 336)
        Me.LstPOScode.Name = "LstPOScode"
        Me.LstPOScode.Size = New System.Drawing.Size(248, 94)
        Me.LstPOScode.TabIndex = 90
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(204, 335)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 15)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "POS Code"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.optNo)
        Me.GroupBox2.Controls.Add(Me.optYes)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(574, 329)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Multi Rate Status"
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.BackColor = System.Drawing.Color.Transparent
        Me.optNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optNo.Location = New System.Drawing.Point(113, 34)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(42, 19)
        Me.optNo.TabIndex = 26
        Me.optNo.TabStop = True
        Me.optNo.Text = "NO"
        Me.optNo.UseVisualStyleBackColor = False
        '
        'optYes
        '
        Me.optYes.AutoSize = True
        Me.optYes.BackColor = System.Drawing.Color.Transparent
        Me.optYes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYes.Location = New System.Drawing.Point(44, 34)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(47, 19)
        Me.optYes.TabIndex = 25
        Me.optYes.TabStop = True
        Me.optYes.Text = "YES"
        Me.optYes.UseVisualStyleBackColor = False
        '
        'FraRate
        '
        Me.FraRate.BackColor = System.Drawing.Color.Transparent
        Me.FraRate.Controls.Add(Me.CheckBox1)
        Me.FraRate.Controls.Add(Me.Label14)
        Me.FraRate.Controls.Add(Me.CHK_MRPTAG)
        Me.FraRate.Controls.Add(Me.CmbUOm)
        Me.FraRate.Controls.Add(Me.txtRate)
        Me.FraRate.Controls.Add(Me.txt_mrprate)
        Me.FraRate.Controls.Add(Me.txtPurchaseRate)
        Me.FraRate.Controls.Add(Me.Label22)
        Me.FraRate.Controls.Add(Me.Label23)
        Me.FraRate.Controls.Add(Me.Label21)
        Me.FraRate.Controls.Add(Me.Label20)
        Me.FraRate.Location = New System.Drawing.Point(197, 471)
        Me.FraRate.Name = "FraRate"
        Me.FraRate.Size = New System.Drawing.Size(646, 126)
        Me.FraRate.TabIndex = 94
        Me.FraRate.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(761, -213)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(47, 17)
        Me.CheckBox1.TabIndex = 117
        Me.CheckBox1.Text = "YES"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(292, 187)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 15)
        Me.Label14.TabIndex = 427
        Me.Label14.Text = "MRP Rate"
        '
        'CHK_MRPTAG
        '
        Me.CHK_MRPTAG.BackColor = System.Drawing.Color.Transparent
        Me.CHK_MRPTAG.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CHK_MRPTAG.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_MRPTAG.ForeColor = System.Drawing.Color.Black
        Me.CHK_MRPTAG.Location = New System.Drawing.Point(16, 61)
        Me.CHK_MRPTAG.Name = "CHK_MRPTAG"
        Me.CHK_MRPTAG.Size = New System.Drawing.Size(123, 24)
        Me.CHK_MRPTAG.TabIndex = 426
        Me.CHK_MRPTAG.Text = "MRP TAG"
        Me.CHK_MRPTAG.UseVisualStyleBackColor = False
        '
        'CmbUOm
        '
        Me.CmbUOm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUOm.FormattingEnabled = True
        Me.CmbUOm.Location = New System.Drawing.Point(470, 65)
        Me.CmbUOm.Name = "CmbUOm"
        Me.CmbUOm.Size = New System.Drawing.Size(100, 21)
        Me.CmbUOm.TabIndex = 7
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(470, 11)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(100, 20)
        Me.txtRate.TabIndex = 6
        '
        'txt_mrprate
        '
        Me.txt_mrprate.Location = New System.Drawing.Point(229, 62)
        Me.txt_mrprate.Name = "txt_mrprate"
        Me.txt_mrprate.Size = New System.Drawing.Size(100, 20)
        Me.txt_mrprate.TabIndex = 5
        '
        'txtPurchaseRate
        '
        Me.txtPurchaseRate.Location = New System.Drawing.Point(144, 15)
        Me.txtPurchaseRate.Name = "txtPurchaseRate"
        Me.txtPurchaseRate.Size = New System.Drawing.Size(100, 20)
        Me.txtPurchaseRate.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(386, 68)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 15)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "UOM"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(386, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 15)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Sales Rate"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(161, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 15)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "MRP Rate"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(51, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 15)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Purchase Rate"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(860, 578)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 65)
        Me.cmdexit.TabIndex = 131
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(860, 512)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 130
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(860, 444)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 129
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(860, 308)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 128
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(860, 240)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 127
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
        Me.CmdClear.Location = New System.Drawing.Point(860, 171)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 65)
        Me.CmdClear.TabIndex = 126
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
        Me.CmdAdd.Location = New System.Drawing.Point(860, 103)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 65)
        Me.CmdAdd.TabIndex = 125
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'FraGrid
        '
        Me.FraGrid.BackColor = System.Drawing.Color.Transparent
        Me.FraGrid.Controls.Add(Me.cbo_BaseUOM)
        Me.FraGrid.Controls.Add(Me.Label13)
        Me.FraGrid.Controls.Add(Me.txt_BaseRate)
        Me.FraGrid.Controls.Add(Me.B)
        Me.FraGrid.Controls.Add(Me.ssgrid)
        Me.FraGrid.Location = New System.Drawing.Point(195, 436)
        Me.FraGrid.Name = "FraGrid"
        Me.FraGrid.Size = New System.Drawing.Size(646, 207)
        Me.FraGrid.TabIndex = 132
        Me.FraGrid.TabStop = False
        '
        'cbo_BaseUOM
        '
        Me.cbo_BaseUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_BaseUOM.FormattingEnabled = True
        Me.cbo_BaseUOM.Location = New System.Drawing.Point(111, 21)
        Me.cbo_BaseUOM.Name = "cbo_BaseUOM"
        Me.cbo_BaseUOM.Size = New System.Drawing.Size(100, 21)
        Me.cbo_BaseUOM.TabIndex = 119
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(317, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 15)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Base Rate "
        '
        'txt_BaseRate
        '
        Me.txt_BaseRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_BaseRate.Location = New System.Drawing.Point(428, 19)
        Me.txt_BaseRate.MaxLength = 10
        Me.txt_BaseRate.Name = "txt_BaseRate"
        Me.txt_BaseRate.Size = New System.Drawing.Size(116, 20)
        Me.txt_BaseRate.TabIndex = 118
        '
        'B
        '
        Me.B.AutoSize = True
        Me.B.BackColor = System.Drawing.Color.Transparent
        Me.B.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B.Location = New System.Drawing.Point(20, 21)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(68, 15)
        Me.B.TabIndex = 115
        Me.B.Text = "Base Uom "
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(8, 52)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(632, 147)
        Me.ssgrid.TabIndex = 0
        '
        'ChkOPENITEMFACILITY
        '
        Me.ChkOPENITEMFACILITY.AutoSize = True
        Me.ChkOPENITEMFACILITY.BackColor = System.Drawing.Color.Transparent
        Me.ChkOPENITEMFACILITY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkOPENITEMFACILITY.Location = New System.Drawing.Point(606, 411)
        Me.ChkOPENITEMFACILITY.Name = "ChkOPENITEMFACILITY"
        Me.ChkOPENITEMFACILITY.Size = New System.Drawing.Size(134, 18)
        Me.ChkOPENITEMFACILITY.TabIndex = 117
        Me.ChkOPENITEMFACILITY.Text = "OPEN ITEM FACILITY"
        Me.ChkOPENITEMFACILITY.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(860, 377)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 160
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(512, 46)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 15)
        Me.lbl_Freeze.TabIndex = 161
        '
        'FRM_MKGA_ItemMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.ChkOPENITEMFACILITY)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LstPOScode)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FraRate)
        Me.Controls.Add(Me.FraGrid)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_ItemMaster"
        Me.Text = "ItemMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.FraRate.ResumeLayout(False)
        Me.FraRate.PerformLayout()
        Me.FraGrid.ResumeLayout(False)
        Me.FraGrid.PerformLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdKitchenHelp As System.Windows.Forms.Button
    Friend WithEvents cmdType As System.Windows.Forms.Button
    Friend WithEvents CBO_CATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtKitchenCode As System.Windows.Forms.TextBox
    Friend WithEvents CMDSUBCODE As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTypedes As System.Windows.Forms.TextBox
    Friend WithEvents cmdGroup As System.Windows.Forms.Button
    Friend WithEvents TXT_SUBDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGroupDes As System.Windows.Forms.TextBox
    Friend WithEvents cmdItemHelp As System.Windows.Forms.Button
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtShort As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_subcode As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LstPOScode As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents FraRate As System.Windows.Forms.GroupBox
    Friend WithEvents CmbUOm As System.Windows.Forms.ComboBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txt_mrprate As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseRate As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CHK_MRPTAG As System.Windows.Forms.CheckBox
    Friend WithEvents FraGrid As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_BaseRate As System.Windows.Forms.TextBox
    Friend WithEvents B As System.Windows.Forms.Label
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cbo_BaseUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CHKLOCNO As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLOCYES As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFBNO As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFBYES As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOPENITEMFACILITY As System.Windows.Forms.CheckBox
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
End Class
