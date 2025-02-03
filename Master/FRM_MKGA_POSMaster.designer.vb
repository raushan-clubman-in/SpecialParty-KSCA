<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_POSMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_POSMaster))
        Me.CMD_LOCATION = New System.Windows.Forms.Button()
        Me.cmdPOSHelp = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMD_USER = New System.Windows.Forms.Button()
        Me.AUTHORISE = New System.Windows.Forms.Button()
        Me.CMD_BRSE = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.txt_SCLIMIT = New System.Windows.Forms.TextBox()
        Me.txt_SCKDESC = New System.Windows.Forms.TextBox()
        Me.txt_ADLIMIT = New System.Windows.Forms.TextBox()
        Me.txt_ADDESC = New System.Windows.Forms.TextBox()
        Me.txt_PCKLIMIT = New System.Windows.Forms.TextBox()
        Me.txt_PCKDESC = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXT_DRPREFIX = New System.Windows.Forms.TextBox()
        Me.Txt_fprefix = New System.Windows.Forms.TextBox()
        Me.Txt_prefix = New System.Windows.Forms.TextBox()
        Me.LBLDRPREFIX = New System.Windows.Forms.Label()
        Me.CMB_DRTYPE = New System.Windows.Forms.ComboBox()
        Me.LBLDRTYP = New System.Windows.Forms.Label()
        Me.LBLFPREFIX = New System.Windows.Forms.Label()
        Me.LBLPREFIX = New System.Windows.Forms.Label()
        Me.CMB_TYPE = New System.Windows.Forms.ComboBox()
        Me.LBLTYPE = New System.Windows.Forms.Label()
        Me.CMB_RNDVAL = New System.Windows.Forms.ComboBox()
        Me.Cmb_postype = New System.Windows.Forms.ComboBox()
        Me.Lblroundval = New System.Windows.Forms.Label()
        Me.CMB_KOTENTRY = New System.Windows.Forms.ComboBox()
        Me.TXT_CENTRALIZED = New System.Windows.Forms.ComboBox()
        Me.CMB_PAYMENT = New System.Windows.Forms.ComboBox()
        Me.CMB_SMRT = New System.Windows.Forms.ComboBox()
        Me.CMB_TABLENO = New System.Windows.Forms.ComboBox()
        Me.CMB_ROUND = New System.Windows.Forms.ComboBox()
        Me.CMB_DIRECT = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPOSCode = New System.Windows.Forms.TextBox()
        Me.txtPOSDesc = New System.Windows.Forms.TextBox()
        Me.txt_PackingPercent = New System.Windows.Forms.TextBox()
        Me.txt_tips = New System.Windows.Forms.TextBox()
        Me.txt_acchg = New System.Windows.Forms.TextBox()
        Me.Txt_party = New System.Windows.Forms.TextBox()
        Me.txt_groom = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ussgrid = New AxFPSpreadADO.AxfpSpread()
        Me.GRP_USER = New System.Windows.Forms.GroupBox()
        Me.USERGRID = New AxFPSpreadADO.AxfpSpread()
        Me.GRP_LOC = New System.Windows.Forms.GroupBox()
        Me.Lssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Ussgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRP_USER.SuspendLayout()
        CType(Me.USERGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRP_LOC.SuspendLayout()
        CType(Me.Lssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMD_LOCATION
        '
        Me.CMD_LOCATION.Location = New System.Drawing.Point(132, 19)
        Me.CMD_LOCATION.Name = "CMD_LOCATION"
        Me.CMD_LOCATION.Size = New System.Drawing.Size(92, 35)
        Me.CMD_LOCATION.TabIndex = 1
        Me.CMD_LOCATION.Text = "Locations Allocation"
        Me.CMD_LOCATION.UseVisualStyleBackColor = True
        '
        'cmdPOSHelp
        '
        Me.cmdPOSHelp.Location = New System.Drawing.Point(466, 146)
        Me.cmdPOSHelp.Name = "cmdPOSHelp"
        Me.cmdPOSHelp.Size = New System.Drawing.Size(38, 23)
        Me.cmdPOSHelp.TabIndex = 163
        Me.cmdPOSHelp.Text = "F4"
        Me.cmdPOSHelp.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(862, 613)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 65)
        Me.cmdexit.TabIndex = 162
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'CMD_USER
        '
        Me.CMD_USER.Location = New System.Drawing.Point(32, 20)
        Me.CMD_USER.Name = "CMD_USER"
        Me.CMD_USER.Size = New System.Drawing.Size(92, 35)
        Me.CMD_USER.TabIndex = 0
        Me.CMD_USER.Text = "User Allocation"
        Me.CMD_USER.UseVisualStyleBackColor = True
        '
        'AUTHORISE
        '
        Me.AUTHORISE.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AUTHORISE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AUTHORISE.Location = New System.Drawing.Point(861, 538)
        Me.AUTHORISE.Name = "AUTHORISE"
        Me.AUTHORISE.Size = New System.Drawing.Size(144, 65)
        Me.AUTHORISE.TabIndex = 161
        Me.AUTHORISE.Text = "AUTHORISE"
        Me.AUTHORISE.UseVisualStyleBackColor = True
        '
        'CMD_BRSE
        '
        Me.CMD_BRSE.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_BRSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_BRSE.Location = New System.Drawing.Point(861, 463)
        Me.CMD_BRSE.Name = "CMD_BRSE"
        Me.CMD_BRSE.Size = New System.Drawing.Size(144, 65)
        Me.CMD_BRSE.TabIndex = 160
        Me.CMD_BRSE.Text = "BROWSE"
        Me.CMD_BRSE.UseVisualStyleBackColor = True
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(862, 324)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 159
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(862, 251)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 158
        Me.Cmd_Freeze.Text = "Freeze  [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(862, 171)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 65)
        Me.CmdClear.TabIndex = 157
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(862, 92)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 65)
        Me.CmdAdd.TabIndex = 156
        Me.CmdAdd.Text = "Add  [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'txt_SCLIMIT
        '
        Me.txt_SCLIMIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SCLIMIT.Location = New System.Drawing.Point(586, 247)
        Me.txt_SCLIMIT.MaxLength = 10
        Me.txt_SCLIMIT.Name = "txt_SCLIMIT"
        Me.txt_SCLIMIT.Size = New System.Drawing.Size(100, 20)
        Me.txt_SCLIMIT.TabIndex = 155
        '
        'txt_SCKDESC
        '
        Me.txt_SCKDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SCKDESC.Location = New System.Drawing.Point(470, 246)
        Me.txt_SCKDESC.MaxLength = 15
        Me.txt_SCKDESC.Name = "txt_SCKDESC"
        Me.txt_SCKDESC.Size = New System.Drawing.Size(100, 20)
        Me.txt_SCKDESC.TabIndex = 154
        '
        'txt_ADLIMIT
        '
        Me.txt_ADLIMIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ADLIMIT.Location = New System.Drawing.Point(586, 275)
        Me.txt_ADLIMIT.MaxLength = 10
        Me.txt_ADLIMIT.Name = "txt_ADLIMIT"
        Me.txt_ADLIMIT.Size = New System.Drawing.Size(100, 20)
        Me.txt_ADLIMIT.TabIndex = 153
        '
        'txt_ADDESC
        '
        Me.txt_ADDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ADDESC.Location = New System.Drawing.Point(470, 276)
        Me.txt_ADDESC.MaxLength = 15
        Me.txt_ADDESC.Name = "txt_ADDESC"
        Me.txt_ADDESC.Size = New System.Drawing.Size(100, 20)
        Me.txt_ADDESC.TabIndex = 152
        '
        'txt_PCKLIMIT
        '
        Me.txt_PCKLIMIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PCKLIMIT.Location = New System.Drawing.Point(586, 217)
        Me.txt_PCKLIMIT.MaxLength = 10
        Me.txt_PCKLIMIT.Name = "txt_PCKLIMIT"
        Me.txt_PCKLIMIT.Size = New System.Drawing.Size(100, 20)
        Me.txt_PCKLIMIT.TabIndex = 151
        '
        'txt_PCKDESC
        '
        Me.txt_PCKDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PCKDESC.Location = New System.Drawing.Point(469, 217)
        Me.txt_PCKDESC.MaxLength = 15
        Me.txt_PCKDESC.Name = "txt_PCKDESC"
        Me.txt_PCKDESC.Size = New System.Drawing.Size(100, 20)
        Me.txt_PCKDESC.TabIndex = 150
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(600, 202)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 15)
        Me.Label24.TabIndex = 149
        Me.Label24.Text = "Upper Limit"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(481, 202)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 15)
        Me.Label23.TabIndex = 148
        Me.Label23.Text = "Description"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_LOCATION)
        Me.GroupBox1.Controls.Add(Me.CMD_USER)
        Me.GroupBox1.Location = New System.Drawing.Point(334, 604)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 60)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        '
        'TXT_DRPREFIX
        '
        Me.TXT_DRPREFIX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DRPREFIX.Location = New System.Drawing.Point(636, 566)
        Me.TXT_DRPREFIX.MaxLength = 5
        Me.TXT_DRPREFIX.Name = "TXT_DRPREFIX"
        Me.TXT_DRPREFIX.Size = New System.Drawing.Size(100, 20)
        Me.TXT_DRPREFIX.TabIndex = 144
        Me.TXT_DRPREFIX.Visible = False
        '
        'Txt_fprefix
        '
        Me.Txt_fprefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_fprefix.Location = New System.Drawing.Point(636, 462)
        Me.Txt_fprefix.MaxLength = 5
        Me.Txt_fprefix.Name = "Txt_fprefix"
        Me.Txt_fprefix.Size = New System.Drawing.Size(100, 20)
        Me.Txt_fprefix.TabIndex = 143
        Me.Txt_fprefix.Visible = False
        '
        'Txt_prefix
        '
        Me.Txt_prefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_prefix.Location = New System.Drawing.Point(636, 433)
        Me.Txt_prefix.MaxLength = 5
        Me.Txt_prefix.Name = "Txt_prefix"
        Me.Txt_prefix.Size = New System.Drawing.Size(100, 20)
        Me.Txt_prefix.TabIndex = 142
        Me.Txt_prefix.Visible = False
        '
        'LBLDRPREFIX
        '
        Me.LBLDRPREFIX.AutoSize = True
        Me.LBLDRPREFIX.BackColor = System.Drawing.Color.Transparent
        Me.LBLDRPREFIX.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDRPREFIX.Location = New System.Drawing.Point(476, 566)
        Me.LBLDRPREFIX.Name = "LBLDRPREFIX"
        Me.LBLDRPREFIX.Size = New System.Drawing.Size(78, 15)
        Me.LBLDRPREFIX.TabIndex = 141
        Me.LBLDRPREFIX.Text = "Direct Prefix"
        Me.LBLDRPREFIX.Visible = False
        '
        'CMB_DRTYPE
        '
        Me.CMB_DRTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DRTYPE.FormattingEnabled = True
        Me.CMB_DRTYPE.Items.AddRange(New Object() {"MANUAL", "AUTO"})
        Me.CMB_DRTYPE.Location = New System.Drawing.Point(636, 496)
        Me.CMB_DRTYPE.Name = "CMB_DRTYPE"
        Me.CMB_DRTYPE.Size = New System.Drawing.Size(100, 21)
        Me.CMB_DRTYPE.TabIndex = 140
        Me.CMB_DRTYPE.Visible = False
        '
        'LBLDRTYP
        '
        Me.LBLDRTYP.AutoSize = True
        Me.LBLDRTYP.BackColor = System.Drawing.Color.Transparent
        Me.LBLDRTYP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDRTYP.Location = New System.Drawing.Point(476, 499)
        Me.LBLDRTYP.Name = "LBLDRTYP"
        Me.LBLDRTYP.Size = New System.Drawing.Size(156, 15)
        Me.LBLDRTYP.TabIndex = 139
        Me.LBLDRTYP.Text = "Manual Entry for Direct Bill"
        Me.LBLDRTYP.Visible = False
        '
        'LBLFPREFIX
        '
        Me.LBLFPREFIX.AutoSize = True
        Me.LBLFPREFIX.BackColor = System.Drawing.Color.Transparent
        Me.LBLFPREFIX.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFPREFIX.Location = New System.Drawing.Point(476, 469)
        Me.LBLFPREFIX.Name = "LBLFPREFIX"
        Me.LBLFPREFIX.Size = New System.Drawing.Size(90, 15)
        Me.LBLFPREFIX.TabIndex = 138
        Me.LBLFPREFIX.Text = "Final Bill Prefix"
        Me.LBLFPREFIX.Visible = False
        '
        'LBLPREFIX
        '
        Me.LBLPREFIX.AutoSize = True
        Me.LBLPREFIX.BackColor = System.Drawing.Color.Transparent
        Me.LBLPREFIX.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPREFIX.Location = New System.Drawing.Point(476, 440)
        Me.LBLPREFIX.Name = "LBLPREFIX"
        Me.LBLPREFIX.Size = New System.Drawing.Size(68, 15)
        Me.LBLPREFIX.TabIndex = 137
        Me.LBLPREFIX.Text = "KOT Prefix"
        Me.LBLPREFIX.Visible = False
        '
        'CMB_TYPE
        '
        Me.CMB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TYPE.FormattingEnabled = True
        Me.CMB_TYPE.Items.AddRange(New Object() {"MANUAL", "AUTO"})
        Me.CMB_TYPE.Location = New System.Drawing.Point(636, 404)
        Me.CMB_TYPE.Name = "CMB_TYPE"
        Me.CMB_TYPE.Size = New System.Drawing.Size(100, 21)
        Me.CMB_TYPE.TabIndex = 136
        Me.CMB_TYPE.Visible = False
        '
        'LBLTYPE
        '
        Me.LBLTYPE.AutoSize = True
        Me.LBLTYPE.BackColor = System.Drawing.Color.Transparent
        Me.LBLTYPE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTYPE.Location = New System.Drawing.Point(476, 407)
        Me.LBLTYPE.Name = "LBLTYPE"
        Me.LBLTYPE.Size = New System.Drawing.Size(60, 15)
        Me.LBLTYPE.TabIndex = 135
        Me.LBLTYPE.Text = "KOT Type"
        Me.LBLTYPE.Visible = False
        '
        'CMB_RNDVAL
        '
        Me.CMB_RNDVAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_RNDVAL.FormattingEnabled = True
        Me.CMB_RNDVAL.Items.AddRange(New Object() {"0.05", "0.10", "0.50"})
        Me.CMB_RNDVAL.Location = New System.Drawing.Point(636, 531)
        Me.CMB_RNDVAL.Name = "CMB_RNDVAL"
        Me.CMB_RNDVAL.Size = New System.Drawing.Size(100, 21)
        Me.CMB_RNDVAL.TabIndex = 134
        Me.CMB_RNDVAL.Visible = False
        '
        'Cmb_postype
        '
        Me.Cmb_postype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_postype.FormattingEnabled = True
        Me.Cmb_postype.Items.AddRange(New Object() {"POS", "FACILITY"})
        Me.Cmb_postype.Location = New System.Drawing.Point(360, 117)
        Me.Cmb_postype.Name = "Cmb_postype"
        Me.Cmb_postype.Size = New System.Drawing.Size(100, 21)
        Me.Cmb_postype.TabIndex = 133
        '
        'Lblroundval
        '
        Me.Lblroundval.AutoSize = True
        Me.Lblroundval.BackColor = System.Drawing.Color.Transparent
        Me.Lblroundval.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblroundval.Location = New System.Drawing.Point(476, 533)
        Me.Lblroundval.Name = "Lblroundval"
        Me.Lblroundval.Size = New System.Drawing.Size(73, 15)
        Me.Lblroundval.TabIndex = 132
        Me.Lblroundval.Text = "Rounded To"
        Me.Lblroundval.Visible = False
        '
        'CMB_KOTENTRY
        '
        Me.CMB_KOTENTRY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KOTENTRY.FormattingEnabled = True
        Me.CMB_KOTENTRY.Items.AddRange(New Object() {"NO", "YES"})
        Me.CMB_KOTENTRY.Location = New System.Drawing.Point(359, 401)
        Me.CMB_KOTENTRY.Name = "CMB_KOTENTRY"
        Me.CMB_KOTENTRY.Size = New System.Drawing.Size(100, 21)
        Me.CMB_KOTENTRY.TabIndex = 131
        '
        'TXT_CENTRALIZED
        '
        Me.TXT_CENTRALIZED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TXT_CENTRALIZED.FormattingEnabled = True
        Me.TXT_CENTRALIZED.Items.AddRange(New Object() {"NO", "YES"})
        Me.TXT_CENTRALIZED.Location = New System.Drawing.Point(360, 369)
        Me.TXT_CENTRALIZED.Name = "TXT_CENTRALIZED"
        Me.TXT_CENTRALIZED.Size = New System.Drawing.Size(100, 21)
        Me.TXT_CENTRALIZED.TabIndex = 130
        '
        'CMB_PAYMENT
        '
        Me.CMB_PAYMENT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_PAYMENT.FormattingEnabled = True
        Me.CMB_PAYMENT.Location = New System.Drawing.Point(360, 469)
        Me.CMB_PAYMENT.Name = "CMB_PAYMENT"
        Me.CMB_PAYMENT.Size = New System.Drawing.Size(100, 21)
        Me.CMB_PAYMENT.TabIndex = 129
        '
        'CMB_SMRT
        '
        Me.CMB_SMRT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_SMRT.FormattingEnabled = True
        Me.CMB_SMRT.Items.AddRange(New Object() {"NO", "YES"})
        Me.CMB_SMRT.Location = New System.Drawing.Point(360, 568)
        Me.CMB_SMRT.Name = "CMB_SMRT"
        Me.CMB_SMRT.Size = New System.Drawing.Size(100, 21)
        Me.CMB_SMRT.TabIndex = 128
        '
        'CMB_TABLENO
        '
        Me.CMB_TABLENO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TABLENO.FormattingEnabled = True
        Me.CMB_TABLENO.Items.AddRange(New Object() {"NO", "YES"})
        Me.CMB_TABLENO.Location = New System.Drawing.Point(360, 537)
        Me.CMB_TABLENO.Name = "CMB_TABLENO"
        Me.CMB_TABLENO.Size = New System.Drawing.Size(100, 21)
        Me.CMB_TABLENO.TabIndex = 127
        '
        'CMB_ROUND
        '
        Me.CMB_ROUND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ROUND.FormattingEnabled = True
        Me.CMB_ROUND.Items.AddRange(New Object() {"NO", "YES"})
        Me.CMB_ROUND.Location = New System.Drawing.Point(360, 503)
        Me.CMB_ROUND.Name = "CMB_ROUND"
        Me.CMB_ROUND.Size = New System.Drawing.Size(100, 21)
        Me.CMB_ROUND.TabIndex = 126
        '
        'CMB_DIRECT
        '
        Me.CMB_DIRECT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DIRECT.FormattingEnabled = True
        Me.CMB_DIRECT.Items.AddRange(New Object() {"NO", "YES"})
        Me.CMB_DIRECT.Location = New System.Drawing.Point(360, 434)
        Me.CMB_DIRECT.Name = "CMB_DIRECT"
        Me.CMB_DIRECT.Size = New System.Drawing.Size(100, 21)
        Me.CMB_DIRECT.TabIndex = 125
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(186, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 19)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "POS/Facility Master"
        '
        'txtPOSCode
        '
        Me.txtPOSCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOSCode.Location = New System.Drawing.Point(360, 149)
        Me.txtPOSCode.MaxLength = 10
        Me.txtPOSCode.Name = "txtPOSCode"
        Me.txtPOSCode.Size = New System.Drawing.Size(100, 20)
        Me.txtPOSCode.TabIndex = 123
        '
        'txtPOSDesc
        '
        Me.txtPOSDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOSDesc.Location = New System.Drawing.Point(360, 180)
        Me.txtPOSDesc.MaxLength = 25
        Me.txtPOSDesc.Name = "txtPOSDesc"
        Me.txtPOSDesc.Size = New System.Drawing.Size(206, 20)
        Me.txtPOSDesc.TabIndex = 122
        '
        'txt_PackingPercent
        '
        Me.txt_PackingPercent.Location = New System.Drawing.Point(360, 216)
        Me.txt_PackingPercent.MaxLength = 7
        Me.txt_PackingPercent.Name = "txt_PackingPercent"
        Me.txt_PackingPercent.Size = New System.Drawing.Size(100, 20)
        Me.txt_PackingPercent.TabIndex = 121
        '
        'txt_tips
        '
        Me.txt_tips.Location = New System.Drawing.Point(360, 246)
        Me.txt_tips.MaxLength = 7
        Me.txt_tips.Name = "txt_tips"
        Me.txt_tips.Size = New System.Drawing.Size(100, 20)
        Me.txt_tips.TabIndex = 120
        '
        'txt_acchg
        '
        Me.txt_acchg.Location = New System.Drawing.Point(360, 276)
        Me.txt_acchg.MaxLength = 7
        Me.txt_acchg.Name = "txt_acchg"
        Me.txt_acchg.Size = New System.Drawing.Size(100, 20)
        Me.txt_acchg.TabIndex = 119
        '
        'Txt_party
        '
        Me.Txt_party.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_party.Location = New System.Drawing.Point(360, 307)
        Me.Txt_party.MaxLength = 7
        Me.Txt_party.Name = "Txt_party"
        Me.Txt_party.Size = New System.Drawing.Size(100, 20)
        Me.Txt_party.TabIndex = 118
        '
        'txt_groom
        '
        Me.txt_groom.Location = New System.Drawing.Point(360, 339)
        Me.txt_groom.MaxLength = 7
        Me.txt_groom.Name = "txt_groom"
        Me.txt_groom.Size = New System.Drawing.Size(100, 20)
        Me.txt_groom.TabIndex = 117
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(191, 574)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 15)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Smart Required"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(191, 539)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 15)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Table no Required"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(193, 438)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Direct Billing"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(194, 406)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "KOT Entry"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(192, 370)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 15)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Centralized KOT"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(191, 472)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 15)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Default Payment Mode"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(191, 506)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Round Off"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(191, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 15)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Add.Rate For G.Room Sales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(191, 311)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 15)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Add.Rate For Party Sales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(191, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 15)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Additional Charges"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(191, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 15)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Service Charge/Tips"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(191, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 15)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Packing/Serv./Surchr"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(191, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(191, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "POS Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Type"
        '
        'Ussgrid
        '
        Me.Ussgrid.DataSource = Nothing
        Me.Ussgrid.Location = New System.Drawing.Point(6, 19)
        Me.Ussgrid.Name = "Ussgrid"
        Me.Ussgrid.OcxState = CType(resources.GetObject("Ussgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ussgrid.Size = New System.Drawing.Size(241, 263)
        Me.Ussgrid.TabIndex = 0
        '
        'GRP_USER
        '
        Me.GRP_USER.Controls.Add(Me.USERGRID)
        Me.GRP_USER.Location = New System.Drawing.Point(603, 68)
        Me.GRP_USER.Name = "GRP_USER"
        Me.GRP_USER.Size = New System.Drawing.Size(253, 287)
        Me.GRP_USER.TabIndex = 164
        Me.GRP_USER.TabStop = False
        Me.GRP_USER.Visible = False
        '
        'USERGRID
        '
        Me.USERGRID.DataSource = Nothing
        Me.USERGRID.Location = New System.Drawing.Point(7, 19)
        Me.USERGRID.Name = "USERGRID"
        Me.USERGRID.OcxState = CType(resources.GetObject("USERGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.USERGRID.Size = New System.Drawing.Size(240, 262)
        Me.USERGRID.TabIndex = 0
        '
        'GRP_LOC
        '
        Me.GRP_LOC.Controls.Add(Me.Lssgrid)
        Me.GRP_LOC.Location = New System.Drawing.Point(607, 367)
        Me.GRP_LOC.Name = "GRP_LOC"
        Me.GRP_LOC.Size = New System.Drawing.Size(247, 291)
        Me.GRP_LOC.TabIndex = 165
        Me.GRP_LOC.TabStop = False
        Me.GRP_LOC.Visible = False
        '
        'Lssgrid
        '
        Me.Lssgrid.DataSource = Nothing
        Me.Lssgrid.Location = New System.Drawing.Point(6, 20)
        Me.Lssgrid.Name = "Lssgrid"
        Me.Lssgrid.OcxState = CType(resources.GetObject("Lssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Lssgrid.Size = New System.Drawing.Size(235, 265)
        Me.Lssgrid.TabIndex = 0
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(504, 103)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 19)
        Me.lbl_Freeze.TabIndex = 166
        '
        'CMDVIEW
        '
        Me.CMDVIEW.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.Image = CType(resources.GetObject("CMDVIEW.Image"), System.Drawing.Image)
        Me.CMDVIEW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDVIEW.Location = New System.Drawing.Point(862, 393)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(144, 65)
        Me.CMDVIEW.TabIndex = 167
        Me.CMDVIEW.Text = "View [F9]"
        Me.CMDVIEW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDVIEW.UseVisualStyleBackColor = True
        '
        'FRM_MKGA_POSMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1028, 742)
        Me.Controls.Add(Me.CMDVIEW)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmdPOSHelp)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.AUTHORISE)
        Me.Controls.Add(Me.CMD_BRSE)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.txt_SCLIMIT)
        Me.Controls.Add(Me.txt_SCKDESC)
        Me.Controls.Add(Me.txt_ADLIMIT)
        Me.Controls.Add(Me.txt_ADDESC)
        Me.Controls.Add(Me.txt_PCKLIMIT)
        Me.Controls.Add(Me.txt_PCKDESC)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXT_DRPREFIX)
        Me.Controls.Add(Me.Txt_fprefix)
        Me.Controls.Add(Me.Txt_prefix)
        Me.Controls.Add(Me.LBLDRPREFIX)
        Me.Controls.Add(Me.CMB_DRTYPE)
        Me.Controls.Add(Me.LBLDRTYP)
        Me.Controls.Add(Me.LBLFPREFIX)
        Me.Controls.Add(Me.LBLPREFIX)
        Me.Controls.Add(Me.CMB_TYPE)
        Me.Controls.Add(Me.LBLTYPE)
        Me.Controls.Add(Me.CMB_RNDVAL)
        Me.Controls.Add(Me.Cmb_postype)
        Me.Controls.Add(Me.Lblroundval)
        Me.Controls.Add(Me.CMB_KOTENTRY)
        Me.Controls.Add(Me.TXT_CENTRALIZED)
        Me.Controls.Add(Me.CMB_PAYMENT)
        Me.Controls.Add(Me.CMB_SMRT)
        Me.Controls.Add(Me.CMB_TABLENO)
        Me.Controls.Add(Me.CMB_ROUND)
        Me.Controls.Add(Me.CMB_DIRECT)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPOSCode)
        Me.Controls.Add(Me.txtPOSDesc)
        Me.Controls.Add(Me.txt_PackingPercent)
        Me.Controls.Add(Me.txt_tips)
        Me.Controls.Add(Me.txt_acchg)
        Me.Controls.Add(Me.Txt_party)
        Me.Controls.Add(Me.txt_groom)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GRP_LOC)
        Me.Controls.Add(Me.GRP_USER)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_POSMaster"
        Me.Text = "POSMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Ussgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRP_USER.ResumeLayout(False)
        CType(Me.USERGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRP_LOC.ResumeLayout(False)
        CType(Me.Lssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMD_LOCATION As System.Windows.Forms.Button
    Friend WithEvents cmdPOSHelp As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMD_USER As System.Windows.Forms.Button
    Friend WithEvents AUTHORISE As System.Windows.Forms.Button
    Friend WithEvents CMD_BRSE As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents txt_SCLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txt_SCKDESC As System.Windows.Forms.TextBox
    Friend WithEvents txt_ADLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txt_ADDESC As System.Windows.Forms.TextBox
    Friend WithEvents txt_PCKLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txt_PCKDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_DRPREFIX As System.Windows.Forms.TextBox
    Friend WithEvents Txt_fprefix As System.Windows.Forms.TextBox
    Friend WithEvents Txt_prefix As System.Windows.Forms.TextBox
    Friend WithEvents LBLDRPREFIX As System.Windows.Forms.Label
    Friend WithEvents CMB_DRTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents LBLDRTYP As System.Windows.Forms.Label
    Friend WithEvents LBLFPREFIX As System.Windows.Forms.Label
    Friend WithEvents LBLPREFIX As System.Windows.Forms.Label
    Friend WithEvents CMB_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents LBLTYPE As System.Windows.Forms.Label
    Friend WithEvents CMB_RNDVAL As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_postype As System.Windows.Forms.ComboBox
    Friend WithEvents Lblroundval As System.Windows.Forms.Label
    Friend WithEvents CMB_KOTENTRY As System.Windows.Forms.ComboBox
    Friend WithEvents TXT_CENTRALIZED As System.Windows.Forms.ComboBox
    Friend WithEvents CMB_PAYMENT As System.Windows.Forms.ComboBox
    Friend WithEvents CMB_SMRT As System.Windows.Forms.ComboBox
    Friend WithEvents CMB_TABLENO As System.Windows.Forms.ComboBox
    Friend WithEvents CMB_ROUND As System.Windows.Forms.ComboBox
    Friend WithEvents CMB_DIRECT As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPOSCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSDesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_PackingPercent As System.Windows.Forms.TextBox
    Friend WithEvents txt_tips As System.Windows.Forms.TextBox
    Friend WithEvents txt_acchg As System.Windows.Forms.TextBox
    Friend WithEvents Txt_party As System.Windows.Forms.TextBox
    Friend WithEvents txt_groom As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Ussgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GRP_USER As System.Windows.Forms.GroupBox
    Friend WithEvents USERGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GRP_LOC As System.Windows.Forms.GroupBox
    Friend WithEvents Lssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
End Class
