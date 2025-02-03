Public Class FRM_RKGA_Selectivedatewise
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
    Friend WithEvents Chk_POSlocation As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_POSlocation As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_SelectAllPaymentmode As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Chk_details As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chklist_Paymentmode As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DATEWISE As System.Windows.Forms.CheckBox
    Friend WithEvents PAYMENTMODE As System.Windows.Forms.CheckBox
    Friend WithEvents USERWISE As System.Windows.Forms.CheckBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdexp As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllUSERS As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_USERNAME As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Chk_POSlocation = New System.Windows.Forms.CheckBox()
        Me.chklist_POSlocation = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.mskFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdexp = New System.Windows.Forms.Button()
        Me.Chk_SelectAllPaymentmode = New System.Windows.Forms.CheckBox()
        Me.chklist_Paymentmode = New System.Windows.Forms.CheckedListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Chk_details = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DATEWISE = New System.Windows.Forms.CheckBox()
        Me.PAYMENTMODE = New System.Windows.Forms.CheckBox()
        Me.USERWISE = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllUSERS = New System.Windows.Forms.CheckBox()
        Me.Chklist_USERNAME = New System.Windows.Forms.CheckedListBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chk_POSlocation
        '
        Me.Chk_POSlocation.BackColor = System.Drawing.Color.Transparent
        Me.Chk_POSlocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_POSlocation.Location = New System.Drawing.Point(185, 135)
        Me.Chk_POSlocation.Name = "Chk_POSlocation"
        Me.Chk_POSlocation.Size = New System.Drawing.Size(132, 24)
        Me.Chk_POSlocation.TabIndex = 396
        Me.Chk_POSlocation.Text = "SELECT ALL"
        Me.Chk_POSlocation.UseVisualStyleBackColor = False
        '
        'chklist_POSlocation
        '
        Me.chklist_POSlocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_POSlocation.Location = New System.Drawing.Point(184, 183)
        Me.chklist_POSlocation.Name = "chklist_POSlocation"
        Me.chklist_POSlocation.Size = New System.Drawing.Size(226, 340)
        Me.chklist_POSlocation.TabIndex = 393
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(176, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 16)
        Me.Label3.TabIndex = 399
        Me.Label3.Text = " SETTLEMENT REGISTER"
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(224, 562)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(561, 64)
        Me.grp_SalebillChecklist.TabIndex = 404
        Me.grp_SalebillChecklist.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(549, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'lbl_Wait
        '
        Me.lbl_Wait.AutoSize = True
        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wait.Location = New System.Drawing.Point(360, 24)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 15)
        Me.lbl_Wait.TabIndex = 387
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.mskFromDate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.mskToDate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(228, 563)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 52)
        Me.GroupBox3.TabIndex = 401
        Me.GroupBox3.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(158, 21)
        Me.mskFromDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(118, 21)
        Me.mskFromDate.TabIndex = 0
        Me.mskFromDate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(298, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'mskToDate
        '
        Me.mskToDate.CustomFormat = "dd/MM/yyyy"
        Me.mskToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskToDate.Location = New System.Drawing.Point(365, 20)
        Me.mskToDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.Name = "mskToDate"
        Me.mskToDate.Size = New System.Drawing.Size(129, 21)
        Me.mskToDate.TabIndex = 1
        Me.mskToDate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(68, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Location = New System.Drawing.Point(40, 536)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 402
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        Me.CmdView.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.cmdreport)
        Me.GroupBox4.Controls.Add(Me.CmdExport)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Location = New System.Drawing.Point(858, 167)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(153, 400)
        Me.GroupBox4.TabIndex = 407
        Me.GroupBox4.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(13, 296)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 441
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdreport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.cmdreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.Black
        Me.cmdreport.Location = New System.Drawing.Point(13, 143)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(131, 56)
        Me.cmdreport.TabIndex = 440
        Me.cmdreport.Text = "Report [F9]"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'CmdExport
        '
        Me.CmdExport.BackColor = System.Drawing.Color.Transparent
        Me.CmdExport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExport.ForeColor = System.Drawing.Color.Black
        Me.CmdExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExport.Location = New System.Drawing.Point(13, 218)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(131, 56)
        Me.CmdExport.TabIndex = 439
        Me.CmdExport.Text = "Export [F12]"
        Me.CmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExport.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Location = New System.Drawing.Point(13, 62)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 438
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'cmdexp
        '
        Me.cmdexp.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexp.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexp.ForeColor = System.Drawing.Color.White
        Me.cmdexp.Location = New System.Drawing.Point(16, 576)
        Me.cmdexp.Name = "cmdexp"
        Me.cmdexp.Size = New System.Drawing.Size(104, 32)
        Me.cmdexp.TabIndex = 6
        Me.cmdexp.Text = " Export[F10]"
        Me.cmdexp.UseVisualStyleBackColor = False
        Me.cmdexp.Visible = False
        '
        'Chk_SelectAllPaymentmode
        '
        Me.Chk_SelectAllPaymentmode.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPaymentmode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPaymentmode.Location = New System.Drawing.Point(417, 135)
        Me.Chk_SelectAllPaymentmode.Name = "Chk_SelectAllPaymentmode"
        Me.Chk_SelectAllPaymentmode.Size = New System.Drawing.Size(160, 24)
        Me.Chk_SelectAllPaymentmode.TabIndex = 17
        Me.Chk_SelectAllPaymentmode.Text = "SELECT ALL "
        Me.Chk_SelectAllPaymentmode.UseVisualStyleBackColor = False
        '
        'chklist_Paymentmode
        '
        Me.chklist_Paymentmode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Paymentmode.Location = New System.Drawing.Point(417, 183)
        Me.chklist_Paymentmode.Name = "chklist_Paymentmode"
        Me.chklist_Paymentmode.Size = New System.Drawing.Size(210, 340)
        Me.chklist_Paymentmode.TabIndex = 16
        '
        'Timer1
        '
        '
        'Chk_details
        '
        Me.Chk_details.BackColor = System.Drawing.Color.Transparent
        Me.Chk_details.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_details.Location = New System.Drawing.Point(16, 632)
        Me.Chk_details.Name = "Chk_details"
        Me.Chk_details.Size = New System.Drawing.Size(160, 24)
        Me.Chk_details.TabIndex = 410
        Me.Chk_details.Text = "DETAILS [ Y/N ]"
        Me.Chk_details.UseVisualStyleBackColor = False
        Me.Chk_details.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(344, 680)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(424, 16)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(185, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 24)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "POS LOCATION :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(417, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 24)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "PAYMENT MODE :"
        '
        'DATEWISE
        '
        Me.DATEWISE.BackColor = System.Drawing.Color.Transparent
        Me.DATEWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DATEWISE.Location = New System.Drawing.Point(306, 537)
        Me.DATEWISE.Name = "DATEWISE"
        Me.DATEWISE.Size = New System.Drawing.Size(120, 24)
        Me.DATEWISE.TabIndex = 424
        Me.DATEWISE.Text = "DATEWISE"
        Me.DATEWISE.UseVisualStyleBackColor = False
        '
        'PAYMENTMODE
        '
        Me.PAYMENTMODE.BackColor = System.Drawing.Color.Transparent
        Me.PAYMENTMODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAYMENTMODE.Location = New System.Drawing.Point(442, 537)
        Me.PAYMENTMODE.Name = "PAYMENTMODE"
        Me.PAYMENTMODE.Size = New System.Drawing.Size(176, 24)
        Me.PAYMENTMODE.TabIndex = 425
        Me.PAYMENTMODE.Text = "PAYMENTMODE"
        Me.PAYMENTMODE.UseVisualStyleBackColor = False
        '
        'USERWISE
        '
        Me.USERWISE.BackColor = System.Drawing.Color.Transparent
        Me.USERWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.USERWISE.Location = New System.Drawing.Point(634, 537)
        Me.USERWISE.Name = "USERWISE"
        Me.USERWISE.Size = New System.Drawing.Size(120, 24)
        Me.USERWISE.TabIndex = 426
        Me.USERWISE.Text = "USERWISE"
        Me.USERWISE.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(634, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(218, 24)
        Me.Label8.TabIndex = 448
        Me.Label8.Text = "USER NAMELIST:"
        '
        'Chk_SelectAllUSERS
        '
        Me.Chk_SelectAllUSERS.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllUSERS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllUSERS.Location = New System.Drawing.Point(636, 135)
        Me.Chk_SelectAllUSERS.Name = "Chk_SelectAllUSERS"
        Me.Chk_SelectAllUSERS.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllUSERS.TabIndex = 446
        Me.Chk_SelectAllUSERS.Text = "SELECT ALL "
        Me.Chk_SelectAllUSERS.UseVisualStyleBackColor = False
        '
        'Chklist_USERNAME
        '
        Me.Chklist_USERNAME.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_USERNAME.Location = New System.Drawing.Point(633, 183)
        Me.Chklist_USERNAME.Name = "Chklist_USERNAME"
        Me.Chklist_USERNAME.Size = New System.Drawing.Size(218, 340)
        Me.Chklist_USERNAME.TabIndex = 447
        '
        'FRM_RKGA_Selectivedatewise
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 702)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Chk_SelectAllUSERS)
        Me.Controls.Add(Me.Chklist_USERNAME)
        Me.Controls.Add(Me.USERWISE)
        Me.Controls.Add(Me.PAYMENTMODE)
        Me.Controls.Add(Me.DATEWISE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_details)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_POSlocation)
        Me.Controls.Add(Me.chklist_POSlocation)
        Me.Controls.Add(Me.chklist_Paymentmode)
        Me.Controls.Add(Me.Chk_SelectAllPaymentmode)
        Me.Controls.Add(Me.cmdexp)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FRM_RKGA_Selectivedatewise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECTIVE PAYMENTMODE PRINT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        chklist_POSlocation.Items.Clear()
        chklist_Paymentmode.Items.Clear()
        grp_SalebillChecklist.Top = 1000
        Chk_POSlocation.Checked = False
        Chk_SelectAllPaymentmode.Checked = False
        Call FillPOSLocation()
        Call FillPaymentMode()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        ' Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    'Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                    ' Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    '''******************************  To fill PAYMENT MODE from PAYMENTMODEMASTER  *******************************'''
    Private Sub FillPaymentMode()
        Dim i As Integer
        chklist_Paymentmode.Items.Clear()
        sqlstring = "SELECT DISTINCT PAYMENTCODE,PAYMENTNAME FROM PAYMENTMODEMASTER WHERE ISNULL(FREEZE,'')<>'Y' "
        vconn.getDataSet(sqlstring, "PAYMENTMODEMASTER")
        If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("PAYMENTMODEMASTER").Rows.Count - 1
                With gdataset.Tables("PAYMENTMODEMASTER").Rows(i)
                    chklist_Paymentmode.Items.Add(Trim(.Item("PAYMENTCODE")))
                End With
            Next i
        End If
        chklist_POSlocation.Sorted = True
    End Sub
    '''******************************  To fill POS details from POSMaster  *******************************'''
    Private Sub FillPOSLocation()
        Dim i As Integer
        chklist_POSlocation.Items.Clear()
        sqlstring = "SELECT DISTINCT poscode,posdesc FROM posmaster WHERE ISNULL(Freeze,'')<>'Y' AND POSDESC NOT LIKE '%KITCHEN%' AND POSDESC NOT LIKE '%SNAC%'"
        vconn.getDataSet(sqlstring, "POS")
        If gdataset.Tables("POS").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS").Rows.Count - 1
                With gdataset.Tables("POS").Rows(i)
                    chklist_POSlocation.Items.Add(Trim(.Item("POSdesc")))
                End With
            Next i
        End If
        chklist_POSlocation.Sorted = True
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If chklist_POSlocation.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the POS LOCATION(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If chklist_Paymentmode.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the PAYMENT MODE(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 552
        grp_SalebillChecklist.Left = 216
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 30
        Me.Timer1.Enabled = True
    End Sub


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub USERName()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(adduserid,'')AS adduserid  FROM kot_det  ORDER BY adduserid"
        vconn.getDataSet(sqlstring, "POS_USERCONTROL")
        If gdataset.Tables("POS_USERCONTROL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POS_USERCONTROL").Rows.Count - 1
                With gdataset.Tables("POS_USERCONTROL").Rows(i)
                    Chklist_USERNAME.Items.Add(Trim(.Item("adduserid")))
                End With
            Next i
        End If
    End Sub
    Private Sub frmCreditSalesregister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call USERName()
        Call FillPOSLocation()
        Call FillPaymentMode()
        mskFromDate.Value = Now.Today
        mskToDate.Value = Now.Today
        grp_SalebillChecklist.Top = 1000
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            Call viewCreditSaleregister()
        End If
    End Sub
    Private Sub mskFromDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskFromDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mskToDate.Focus()
        End If
    End Sub
    Private Sub mskToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskToDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CmdView.Focus()
        End If
    End Sub
    Public Sub viewCreditSaleregister()
        '    Try
        '        Dim POSdesc(), MemberCode() As String
        '        Dim i As Integer
        '        If Chk_details.Checked = True Then
        '            sqlstring = " SELECT * FROM VIEWMEMBERWISESALESUMMARY"
        '            If chklist_POSlocation.CheckedItems.Count <> 0 Then
        '                sqlstring = sqlstring & " WHERE POSDESC IN ("
        '                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
        '                    sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
        '                Next
        '                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '                sqlstring = sqlstring & ")"
        '            Else
        '                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '            If chklist_Paymentmode.CheckedItems.Count <> 0 Then
        '                sqlstring = sqlstring & " AND PAYMENTMODE IN ("
        '                For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
        '                    sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
        '                Next
        '                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '                sqlstring = sqlstring & ")"
        '            End If
        '            sqlstring = sqlstring & " AND BILLDATE BETWEEN "
        '            sqlstring = sqlstring & "'" & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        '            sqlstring = sqlstring & " ORDER BY BILLDATE,BILLNO,MTORDERNO,PREFIXMCODE,MSORDERNO,SCODE"
        '            Dim heading() As String = {" SETTLEMENT REGISTER "}
        '            Dim ObjMemberWisesalereport As New rptMemberWisesalereport
        '            ObjMemberWisesalereport.Reportdetails(sqlstring, heading, mskFromDate.Value, mskToDate.Value)
        '        Else
        '            sqlstring = " SELECT * FROM VIEWPAYMENTMODEWISEREPORT"
        '            If chklist_POSlocation.CheckedItems.Count <> 0 Then
        '                sqlstring = sqlstring & " WHERE POSDESC IN ("
        '                For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
        '                    sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
        '                Next
        '                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '                sqlstring = sqlstring & ")"
        '            Else
        '                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '            If chklist_Paymentmode.CheckedItems.Count <> 0 Then
        '                sqlstring = sqlstring & " AND PAYMENTMODE IN ("
        '                For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
        '                    sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
        '                Next
        '                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '                sqlstring = sqlstring & ")"
        '            End If
        '            sqlstring = sqlstring & " AND BILLDATE BETWEEN "
        '            sqlstring = sqlstring & "'" & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        '            sqlstring = sqlstring & " ORDER BY PAYMENTMODE,MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLNO, BILLDATE,ITEMCODE,ITEMDESC"
        '            Dim heading() As String = {" SETTLEMENT REGISTER "}
        '            Dim ObjPaymentmodewise As New rptPaymentmodewise
        '            ObjPaymentmodewise.Reportdetails(sqlstring, heading, mskFromDate.Value, mskToDate.Value)
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End Try
        'End Sub

        'Private Sub Chk_Membername_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim i As Integer
        '    If Chk_SelectAllPaymentmode.Checked = True Then
        '        For i = 0 To chklist_Paymentmode.Items.Count - 1
        '            chklist_Paymentmode.SetItemChecked(i, True)
        '        Next
        '    Else
        '        For i = 0 To chklist_Paymentmode.Items.Count - 1
        '            chklist_Paymentmode.SetItemChecked(i, False)
        '        Next
        '    End If
        'End Sub

        'Private Sub Chk_POSlocation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_POSlocation.CheckedChanged
        '    Dim i As Integer
        '    If Chk_POSlocation.Checked = True Then
        '        For i = 0 To chklist_POSlocation.Items.Count - 1
        '            chklist_POSlocation.SetItemChecked(i, True)
        '        Next
        '    Else
        '        For i = 0 To chklist_POSlocation.Items.Count - 1
        '            chklist_POSlocation.SetItemChecked(i, False)
        '        Next
        '    End If
    End Sub

    Private Sub frmCreditSalesregister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            'For i = 0 To chklist_POSlocation.Items.Count - 1
            '    chklist_POSlocation.SetItemChecked(i, True)
            'Next i
            'Chk_POSlocation.Checked = True
            'For i = 0 To chklist_Paymentmode.Items.Count - 1
            '    chklist_Paymentmode.SetItemChecked(i, True)
            'Next i
            'Chk_SelectAllPaymentmode.Checked = True
            'Me.mskFromDate.Focus()
            'Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            'Call CmdPrint_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F9 Then
            Call cmdreport_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F12 Then
            Call cmdexport_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.mskFromDate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.mskToDate.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Chk_SelectAllPaymentmode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPaymentmode.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPaymentmode.Checked = True Then
            For i = 0 To chklist_Paymentmode.Items.Count - 1
                chklist_Paymentmode.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Paymentmode.Items.Count - 1
                chklist_Paymentmode.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chklist_Paymentmode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_Paymentmode.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Paymentmode.Items.Count - 1
                chklist_Paymentmode.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To chklist_Paymentmode.Items.Count - 1
                chklist_Paymentmode.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub chklist_POSlocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_POSlocation.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click
        Dim SSQL As String
        ' Dim _export As EXPORT
        If DATEWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            Call SETTLEMENTDATEWISEEXCEL()
        ElseIf USERWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            Call SETTLEMENTUSERWISEDETAILSEXCEL()
        ElseIf PAYMENTMODE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)

            Call SETTLEMENTPAYMENTMODEEXCEL()
        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub SETTLEMENTDATEWISEEXCEL()

        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring As String
    
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "SETTLEMENTREPORT")
        If gdataset.Tables("SETTLEMENTREPORT").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "SETTLEMENT-DATEWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub SETTLEMENTUSERWISEDETAILSEXCEL()

        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring As String
       
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"

        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,ADDUSERID,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "SETTLEMENTREPORT")
        If gdataset.Tables("SETTLEMENTREPORT").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "SETTLEMENT USERWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub SETTLEMENTPAYMENTMODEEXCEL()
        Dim servercode() As String
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, SSQL As String
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"

        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,PAYMENTMODE,BILLDETAILS"
        gconnection.getDataSet(sqlstring, "SETTLEMENTREPORT")
        If gdataset.Tables("SETTLEMENTREPORT").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "SETTLEMENT PAYMENTMODEWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim servercode() As String
        'Dim i As Integer
        'Dim sqlstring, SSQL As String
        'Dim Viewer As New ReportViwer
        'Dim r As New CrptVIEWMEMBERWISESALESUMMARY1
        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String
        'sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        'sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        'sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        'If chklist_POSlocation.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " and POSDESC IN ("
        '    For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        '    'sqlstring = " SELECT * FROM VIEWMEMBERWISESALESUMMARY WHERE"
        '    'sqlstring = sqlstring & " BILLDATE BETWEEN '"
        '    'sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        '    'If chklist_POSlocation.CheckedItems.Count <> 0 Then
        '    '    sqlstring = sqlstring & " WHERE POSDESC IN ("
        '    '    For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
        '    '        sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
        '    '    Next
        '    '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    '    sqlstring = sqlstring & ")"
        '    'End If
        'End If
        'If chklist_Paymentmode.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " AND PAYMENTMODE IN ("
        '    For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
        '        sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        'sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"
        ''If chklist_Membername.CheckedItems.Count <> 0 Then
        ''    sqlstring = sqlstring & " AND SCODE IN ("
        ''    For i = 0 To chklist_Membername.CheckedItems.Count - 1
        ''        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
        ''        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
        ''    Next
        ''    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        ''    sqlstring = sqlstring & ")"
        ''End If
        ''sqlstring = sqlstring & "ORDER BY PAYMENTMODE,MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLNO "
        'Call Viewer.GetDetails(sqlstring, "SETTLEMENTREPORT", r)

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        'TXTOBJ1.Text = gCompanyname

        'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text5")
        'TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        'TXTOBJ5.Text = "UserName : " & gUsername

        ''Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ9 = r.ReportDefinition.ReportObjects("Text12")
        ''TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        'Viewer.TableName = "SETTLEMENTREPORT"

        'Viewer.Show()

    End Sub

    Private Sub chklist_POSlocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_POSlocation.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CMDCLEAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Chklist_USERNAME.Items.Clear()
        chklist_POSlocation.Items.Clear()
        chklist_Paymentmode.Items.Clear()
        grp_SalebillChecklist.Top = 1000
        Chk_POSlocation.Checked = False
        Chk_SelectAllPaymentmode.Checked = False
        Call FillPOSLocation()
        Call FillPaymentMode()
        Call USERName()
    End Sub
    Private Sub SETTLEMENTDATEWISE()

        Dim i As Integer
        Dim sqlstring As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptVIEWMEMBERWISESALESUMMARY1
     
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"

        Call Viewer.GetDetails(sqlstring, "SETTLEMENTREPORT", r)

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ16.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername

        Viewer.TableName = "SETTLEMENTREPORT"
        Viewer.Show()

    End Sub
    Private Sub SETTLEMENTUSERWISE()
        Dim servercode() As String
        Dim i As Integer
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptUSERWISESETTLEMENT
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"

        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"
        Call Viewer.GetDetails(sqlstring, "SETTLEMENTREPORT", r)

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername

        Viewer.TableName = "SETTLEMENTREPORT"

        Viewer.Show()

    End Sub
    Private Sub cmdreport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click

        If chklist_POSlocation.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Chklist_USERNAME.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Username(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If chklist_Paymentmode.CheckedItems.Count = 0 Then
            MessageBox.Show("Select Paymentmode(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub
        Dim SSQL As String

        If DATEWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call SETTLEMENTDATEWISE()
        ElseIf USERWISE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call SETTLEMENTUSERWISEDETAILS()
        ElseIf PAYMENTMODE.Checked = True Then
            SSQL = "EXEC POS_POSWISE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call SETTLEMENTPAYMENTMODE()
        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub SETTLEMENTPAYMENTMODE()
        
        Dim sqlstring As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptPAYMENTMODEWISESETTLEMENT
       
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"

        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"
        'If chklist_Membername.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " AND SCODE IN ("
        '    For i = 0 To chklist_Membername.CheckedItems.Count - 1
        '        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
        '        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        'sqlstring = sqlstring & "ORDER BY PAYMENTMODE,MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLNO "
        Call Viewer.GetDetails(sqlstring, "SETTLEMENTREPORT", r)

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text12")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        Viewer.TableName = "SETTLEMENTREPORT"

        Viewer.Show()

    End Sub
    Private Sub SETTLEMENTUSERWISEDETAILS()

        Dim i As Integer
        Dim sqlstring As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptUSERWISESETTLEMENT
       
        sqlstring = " SELECT * FROM SETTLEMENTREPORT where"
        sqlstring = sqlstring & " cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"

        If chklist_POSlocation.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and POSDESC IN ("
            For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Replace(chklist_POSlocation.CheckedItems(i), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            'sqlstring = " SELECT * FROM VIEWMEMBERWISESALESUMMARY WHERE"
            'sqlstring = sqlstring & " BILLDATE BETWEEN '"
            'sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
            'If chklist_POSlocation.CheckedItems.Count <> 0 Then
            '    sqlstring = sqlstring & " WHERE POSDESC IN ("
            '    For i = 0 To chklist_POSlocation.CheckedItems.Count - 1
            '        sqlstring = sqlstring & " '" & chklist_POSlocation.CheckedItems(i) & "', "
            '    Next
            '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            '    sqlstring = sqlstring & ")"
            'End If
        End If
        If chklist_Paymentmode.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND PAYMENTMODE IN ("
            For i = 0 To chklist_Paymentmode.CheckedItems.Count - 1
                sqlstring = sqlstring & "'" & Replace(Trim(chklist_Paymentmode.CheckedItems(i)), "'", "") & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If Chklist_USERNAME.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ADDUSERID in ("
            For i = 0 To Chklist_USERNAME.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_USERNAME.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        sqlstring = sqlstring & "ORDER BY BILLDATE,BILLDETAILS"
        'If chklist_Membername.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " AND SCODE IN ("
        '    For i = 0 To chklist_Membername.CheckedItems.Count - 1
        '        MemberCode = Split(chklist_Membername.CheckedItems(i), "->")
        '        sqlstring = sqlstring & "'" & MemberCode(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If
        'sqlstring = sqlstring & "ORDER BY PAYMENTMODE,MTORDERNO,PREFIXMCODE,MSORDERNO,POSDESC,BILLNO "
        Call Viewer.GetDetails(sqlstring, "SETTLEMENTREPORT", r)

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ16.Text = "PERIOD FROM " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text12")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        Viewer.TableName = "SETTLEMENTREPORT"

        Viewer.Show()

    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Chk_SelectAllUSERS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllUSERS.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllUSERS.Checked = True Then
            For i = 0 To Chklist_USERNAME.Items.Count - 1
                Chklist_USERNAME.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_USERNAME.Items.Count - 1
                Chklist_USERNAME.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub DATEWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATEWISE.CheckedChanged
        If DATEWISE.Checked = True Then
            PAYMENTMODE.Checked = False
            USERWISE.Checked = False

        End If
    End Sub

    Private Sub PAYMENTMODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENTMODE.CheckedChanged
        If PAYMENTMODE.Checked = True Then
            DATEWISE.Checked = False
            USERWISE.Checked = False

        End If
    End Sub

    Private Sub USERWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERWISE.CheckedChanged
        If USERWISE.Checked = True Then
            DATEWISE.Checked = False
            PAYMENTMODE.Checked = False

        End If
    End Sub

    Private Sub cmdexp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexp.Click

    End Sub

    Private Sub Chk_POSlocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_POSlocation.CheckedChanged
        Dim i As Integer
        If Chk_POSlocation.Checked = True Then
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_POSlocation.Items.Count - 1
                chklist_POSlocation.SetItemChecked(i, False)
            Next
        End If
    End Sub
End Class
