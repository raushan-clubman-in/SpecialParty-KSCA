<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_TKGA_SmartKotEntry
    Inherits System.Windows.Forms.Form
    Public Sub New(ByVal STRPOS As String, ByVal DOCTYP As String)
        MyBase.New()
        '        billno = billdetails
        STRPOSCODE = STRPOS
        DOCTYPE = DOCTYP
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_TKGA_SmartKotEntry))
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.txt_ServerCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Txt_holder_name = New System.Windows.Forms.TextBox()
        Me.txt_MemberName = New System.Windows.Forms.TextBox()
        Me.txt_ServerName = New System.Windows.Forms.TextBox()
        Me.lbl_SubPaymentMode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_MemberName = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Holder_Code = New System.Windows.Forms.TextBox()
        Me.txt_MemberCode = New System.Windows.Forms.TextBox()
        Me.Txt_Remarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Membercode = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_KOTno = New System.Windows.Forms.TextBox()
        Me.Lab_Kotdate = New System.Windows.Forms.Label()
        Me.LBL_KotNo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_card_id = New System.Windows.Forms.TextBox()
        Me.lbl_SwipeCard = New System.Windows.Forms.Button()
        Me.dtp_KOTdate = New System.Windows.Forms.DateTimePicker()
        Me.CMB_BTYPE = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_TableNo = New System.Windows.Forms.TextBox()
        Me.txt_Cover = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txt_PartyBookingNo = New System.Windows.Forms.TextBox()
        Me.Lbl_PartyBookingNo = New System.Windows.Forms.Label()
        Me.cmd_TablenoHelp = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CMD_LOCHELP = New System.Windows.Forms.Button()
        Me.txt_LOCATIONCODE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXT_LOCATIONNAME = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmd_ServerCodeHelp = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.cbo_SubPaymentMode = New System.Windows.Forms.ComboBox()
        Me.cbo_PaymentMode = New System.Windows.Forms.ComboBox()
        Me.txt_KOTTime = New System.Windows.Forms.TextBox()
        Me.Pic_Member = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Delay = New System.Windows.Forms.Timer(Me.components)
        Me.KOT_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_POSCode = New System.Windows.Forms.Panel()
        Me.lvw_POSCode = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnl_UOMCode = New System.Windows.Forms.Panel()
        Me.lvw_Uom = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.cmd_KOTnoHelp = New System.Windows.Forms.Button()
        Me.sSGrid = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_bal = New System.Windows.Forms.Label()
        Me.Lbl_Bill = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblBillno2 = New System.Windows.Forms.Label()
        Me.lblBillno1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cmd_GolfRegNoHelp = New System.Windows.Forms.Button()
        Me.Txt_GolfRegNo = New System.Windows.Forms.TextBox()
        Me.Lbl_GolfRegNo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_POSCode.SuspendLayout()
        Me.pnl_UOMCode.SuspendLayout()
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(861, 488)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Exit.TabIndex = 130
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(861, 432)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Export.TabIndex = 129
        Me.Cmd_Export.Text = "Browse [F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(861, 376)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Print.TabIndex = 128
        Me.Cmd_Print.Text = "Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = True
        '
        'Cmd_View
        '
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(861, 320)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_View.TabIndex = 127
        Me.Cmd_View.Text = "View [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = True
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(861, 264)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Delete.TabIndex = 126
        Me.Cmd_Delete.Text = "Delete [F8]"
        Me.Cmd_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Delete.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(861, 152)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Clear.TabIndex = 125
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'txt_ServerCode
        '
        Me.txt_ServerCode.Location = New System.Drawing.Point(108, 100)
        Me.txt_ServerCode.Name = "txt_ServerCode"
        Me.txt_ServerCode.Size = New System.Drawing.Size(125, 20)
        Me.txt_ServerCode.TabIndex = 123
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 15)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Waiter Code"
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(791, 603)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(10, 20)
        Me.TextBox17.TabIndex = 121
        Me.TextBox17.Visible = False
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(822, 602)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(16, 20)
        Me.TextBox16.TabIndex = 120
        Me.TextBox16.Visible = False
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(815, 571)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(23, 20)
        Me.TextBox15.TabIndex = 119
        Me.TextBox15.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(772, 573)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 15)
        Me.Label15.TabIndex = 118
        Me.Label15.Text = "Total Amount"
        Me.Label15.Visible = False
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(807, 603)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(13, 20)
        Me.TextBox14.TabIndex = 117
        Me.TextBox14.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(772, 604)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 15)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Tax Amount"
        Me.Label14.Visible = False
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(822, 628)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(16, 20)
        Me.TextBox13.TabIndex = 115
        Me.TextBox13.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(772, 630)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 15)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Bill Amount"
        Me.Label13.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 18)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Smart KOT Entry"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(861, 208)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(145, 53)
        Me.Cmd_Add.TabIndex = 124
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'Txt_holder_name
        '
        Me.Txt_holder_name.Location = New System.Drawing.Point(380, 39)
        Me.Txt_holder_name.Name = "Txt_holder_name"
        Me.Txt_holder_name.Size = New System.Drawing.Size(150, 20)
        Me.Txt_holder_name.TabIndex = 111
        '
        'txt_MemberName
        '
        Me.txt_MemberName.Location = New System.Drawing.Point(380, 68)
        Me.txt_MemberName.Name = "txt_MemberName"
        Me.txt_MemberName.Size = New System.Drawing.Size(150, 20)
        Me.txt_MemberName.TabIndex = 110
        '
        'txt_ServerName
        '
        Me.txt_ServerName.Location = New System.Drawing.Point(380, 99)
        Me.txt_ServerName.Name = "txt_ServerName"
        Me.txt_ServerName.Size = New System.Drawing.Size(150, 20)
        Me.txt_ServerName.TabIndex = 109
        '
        'lbl_SubPaymentMode
        '
        Me.lbl_SubPaymentMode.AutoSize = True
        Me.lbl_SubPaymentMode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SubPaymentMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubPaymentMode.Location = New System.Drawing.Point(292, 11)
        Me.lbl_SubPaymentMode.Name = "lbl_SubPaymentMode"
        Me.lbl_SubPaymentMode.Size = New System.Drawing.Size(87, 15)
        Me.lbl_SubPaymentMode.TabIndex = 108
        Me.lbl_SubPaymentMode.Text = "Sub Pay Mode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Card Holder"
        '
        'lbl_MemberName
        '
        Me.lbl_MemberName.AutoSize = True
        Me.lbl_MemberName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MemberName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MemberName.Location = New System.Drawing.Point(287, 71)
        Me.lbl_MemberName.Name = "lbl_MemberName"
        Me.lbl_MemberName.Size = New System.Drawing.Size(90, 15)
        Me.lbl_MemberName.TabIndex = 106
        Me.lbl_MemberName.Text = "Member Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(296, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 15)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "Waiter Name"
        '
        'txt_Holder_Code
        '
        Me.txt_Holder_Code.Location = New System.Drawing.Point(108, 42)
        Me.txt_Holder_Code.Name = "txt_Holder_Code"
        Me.txt_Holder_Code.Size = New System.Drawing.Size(125, 20)
        Me.txt_Holder_Code.TabIndex = 103
        '
        'txt_MemberCode
        '
        Me.txt_MemberCode.Location = New System.Drawing.Point(108, 70)
        Me.txt_MemberCode.Name = "txt_MemberCode"
        Me.txt_MemberCode.Size = New System.Drawing.Size(125, 20)
        Me.txt_MemberCode.TabIndex = 102
        '
        'Txt_Remarks
        '
        Me.Txt_Remarks.Location = New System.Drawing.Point(250, 516)
        Me.Txt_Remarks.Multiline = True
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(289, 32)
        Me.Txt_Remarks.TabIndex = 101
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Operation Mode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Card Holder"
        '
        'lbl_Membercode
        '
        Me.lbl_Membercode.AutoSize = True
        Me.lbl_Membercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Membercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Membercode.Location = New System.Drawing.Point(9, 73)
        Me.lbl_Membercode.Name = "lbl_Membercode"
        Me.lbl_Membercode.Size = New System.Drawing.Size(86, 15)
        Me.lbl_Membercode.TabIndex = 98
        Me.lbl_Membercode.Text = "Member Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 522)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Remarks"
        '
        'txt_KOTno
        '
        Me.txt_KOTno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTno.Location = New System.Drawing.Point(696, 108)
        Me.txt_KOTno.Name = "txt_KOTno"
        Me.txt_KOTno.Size = New System.Drawing.Size(124, 20)
        Me.txt_KOTno.TabIndex = 94
        '
        'Lab_Kotdate
        '
        Me.Lab_Kotdate.AutoSize = True
        Me.Lab_Kotdate.BackColor = System.Drawing.Color.Transparent
        Me.Lab_Kotdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Kotdate.Location = New System.Drawing.Point(633, 136)
        Me.Lab_Kotdate.Name = "Lab_Kotdate"
        Me.Lab_Kotdate.Size = New System.Drawing.Size(60, 15)
        Me.Lab_Kotdate.TabIndex = 93
        Me.Lab_Kotdate.Text = "KOT Date"
        '
        'LBL_KotNo
        '
        Me.LBL_KotNo.AutoSize = True
        Me.LBL_KotNo.BackColor = System.Drawing.Color.Transparent
        Me.LBL_KotNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_KotNo.Location = New System.Drawing.Point(614, 110)
        Me.LBL_KotNo.Name = "LBL_KotNo"
        Me.LBL_KotNo.Size = New System.Drawing.Size(79, 15)
        Me.LBL_KotNo.TabIndex = 92
        Me.LBL_KotNo.Text = "KOT Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(151, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Location"
        '
        'txt_card_id
        '
        Me.txt_card_id.Location = New System.Drawing.Point(259, 107)
        Me.txt_card_id.Name = "txt_card_id"
        Me.txt_card_id.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txt_card_id.Size = New System.Drawing.Size(125, 20)
        Me.txt_card_id.TabIndex = 89
        '
        'lbl_SwipeCard
        '
        Me.lbl_SwipeCard.Location = New System.Drawing.Point(181, 105)
        Me.lbl_SwipeCard.Name = "lbl_SwipeCard"
        Me.lbl_SwipeCard.Size = New System.Drawing.Size(75, 23)
        Me.lbl_SwipeCard.TabIndex = 88
        Me.lbl_SwipeCard.Text = "Swipe Card"
        Me.lbl_SwipeCard.UseVisualStyleBackColor = True
        '
        'dtp_KOTdate
        '
        Me.dtp_KOTdate.Location = New System.Drawing.Point(696, 134)
        Me.dtp_KOTdate.Name = "dtp_KOTdate"
        Me.dtp_KOTdate.Size = New System.Drawing.Size(85, 20)
        Me.dtp_KOTdate.TabIndex = 132
        '
        'CMB_BTYPE
        '
        Me.CMB_BTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_BTYPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMB_BTYPE.FormattingEnabled = True
        Me.CMB_BTYPE.Location = New System.Drawing.Point(210, 35)
        Me.CMB_BTYPE.Name = "CMB_BTYPE"
        Me.CMB_BTYPE.Size = New System.Drawing.Size(106, 21)
        Me.CMB_BTYPE.TabIndex = 131
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(5, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 15)
        Me.Label17.TabIndex = 133
        Me.Label17.Text = "Table No"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 15)
        Me.Label18.TabIndex = 134
        Me.Label18.Text = "Covers"
        '
        'txt_TableNo
        '
        Me.txt_TableNo.Location = New System.Drawing.Point(63, 9)
        Me.txt_TableNo.Name = "txt_TableNo"
        Me.txt_TableNo.Size = New System.Drawing.Size(83, 20)
        Me.txt_TableNo.TabIndex = 135
        '
        'txt_Cover
        '
        Me.txt_Cover.Location = New System.Drawing.Point(63, 35)
        Me.txt_Cover.Name = "txt_Cover"
        Me.txt_Cover.Size = New System.Drawing.Size(83, 20)
        Me.txt_Cover.TabIndex = 136
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txt_PartyBookingNo)
        Me.Panel1.Controls.Add(Me.Lbl_PartyBookingNo)
        Me.Panel1.Controls.Add(Me.cmd_TablenoHelp)
        Me.Panel1.Controls.Add(Me.txt_Cover)
        Me.Panel1.Controls.Add(Me.txt_TableNo)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.CMB_BTYPE)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(183, 134)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(333, 64)
        Me.Panel1.TabIndex = 137
        '
        'Txt_PartyBookingNo
        '
        Me.Txt_PartyBookingNo.Location = New System.Drawing.Point(256, 9)
        Me.Txt_PartyBookingNo.Name = "Txt_PartyBookingNo"
        Me.Txt_PartyBookingNo.Size = New System.Drawing.Size(61, 20)
        Me.Txt_PartyBookingNo.TabIndex = 627
        '
        'Lbl_PartyBookingNo
        '
        Me.Lbl_PartyBookingNo.AutoSize = True
        Me.Lbl_PartyBookingNo.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PartyBookingNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PartyBookingNo.Location = New System.Drawing.Point(184, 11)
        Me.Lbl_PartyBookingNo.Name = "Lbl_PartyBookingNo"
        Me.Lbl_PartyBookingNo.Size = New System.Drawing.Size(71, 15)
        Me.Lbl_PartyBookingNo.TabIndex = 626
        Me.Lbl_PartyBookingNo.Text = "Booking No"
        '
        'cmd_TablenoHelp
        '
        Me.cmd_TablenoHelp.BackgroundImage = CType(resources.GetObject("cmd_TablenoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_TablenoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_TablenoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_TablenoHelp.Location = New System.Drawing.Point(148, 9)
        Me.cmd_TablenoHelp.Name = "cmd_TablenoHelp"
        Me.cmd_TablenoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_TablenoHelp.TabIndex = 220
        Me.cmd_TablenoHelp.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CMD_LOCHELP)
        Me.Panel2.Controls.Add(Me.txt_LOCATIONCODE)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.TXT_LOCATIONNAME)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cmd_ServerCodeHelp)
        Me.Panel2.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Panel2.Controls.Add(Me.cbo_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.cbo_PaymentMode)
        Me.Panel2.Controls.Add(Me.txt_ServerCode)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Txt_holder_name)
        Me.Panel2.Controls.Add(Me.txt_MemberName)
        Me.Panel2.Controls.Add(Me.txt_ServerName)
        Me.Panel2.Controls.Add(Me.lbl_SubPaymentMode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lbl_MemberName)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txt_Holder_Code)
        Me.Panel2.Controls.Add(Me.txt_MemberCode)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbl_Membercode)
        Me.Panel2.Location = New System.Drawing.Point(183, 205)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 158)
        Me.Panel2.TabIndex = 138
        '
        'CMD_LOCHELP
        '
        Me.CMD_LOCHELP.BackgroundImage = CType(resources.GetObject("CMD_LOCHELP.BackgroundImage"), System.Drawing.Image)
        Me.CMD_LOCHELP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMD_LOCHELP.DialogResult = System.Windows.Forms.DialogResult.No
        Me.CMD_LOCHELP.Location = New System.Drawing.Point(235, 127)
        Me.CMD_LOCHELP.Name = "CMD_LOCHELP"
        Me.CMD_LOCHELP.Size = New System.Drawing.Size(32, 23)
        Me.CMD_LOCHELP.TabIndex = 225
        Me.CMD_LOCHELP.UseVisualStyleBackColor = True
        '
        'txt_LOCATIONCODE
        '
        Me.txt_LOCATIONCODE.Location = New System.Drawing.Point(110, 129)
        Me.txt_LOCATIONCODE.Name = "txt_LOCATIONCODE"
        Me.txt_LOCATIONCODE.Size = New System.Drawing.Size(125, 20)
        Me.txt_LOCATIONCODE.TabIndex = 224
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "Location Code"
        '
        'TXT_LOCATIONNAME
        '
        Me.TXT_LOCATIONNAME.Location = New System.Drawing.Point(382, 128)
        Me.TXT_LOCATIONNAME.Name = "TXT_LOCATIONNAME"
        Me.TXT_LOCATIONNAME.Size = New System.Drawing.Size(150, 20)
        Me.TXT_LOCATIONNAME.TabIndex = 222
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(285, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 221
        Me.Label9.Text = "Location Name"
        '
        'cmd_ServerCodeHelp
        '
        Me.cmd_ServerCodeHelp.BackgroundImage = CType(resources.GetObject("cmd_ServerCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_ServerCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_ServerCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_ServerCodeHelp.Location = New System.Drawing.Point(235, 98)
        Me.cmd_ServerCodeHelp.Name = "cmd_ServerCodeHelp"
        Me.cmd_ServerCodeHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_ServerCodeHelp.TabIndex = 220
        Me.cmd_ServerCodeHelp.UseVisualStyleBackColor = True
        '
        'cmd_MemberCodeHelp
        '
        Me.cmd_MemberCodeHelp.BackgroundImage = CType(resources.GetObject("cmd_MemberCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_MemberCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_MemberCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_MemberCodeHelp.Location = New System.Drawing.Point(235, 69)
        Me.cmd_MemberCodeHelp.Name = "cmd_MemberCodeHelp"
        Me.cmd_MemberCodeHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_MemberCodeHelp.TabIndex = 219
        Me.cmd_MemberCodeHelp.UseVisualStyleBackColor = True
        '
        'cbo_SubPaymentMode
        '
        Me.cbo_SubPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_SubPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_SubPaymentMode.FormattingEnabled = True
        Me.cbo_SubPaymentMode.Location = New System.Drawing.Point(383, 8)
        Me.cbo_SubPaymentMode.Name = "cbo_SubPaymentMode"
        Me.cbo_SubPaymentMode.Size = New System.Drawing.Size(147, 21)
        Me.cbo_SubPaymentMode.TabIndex = 133
        '
        'cbo_PaymentMode
        '
        Me.cbo_PaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_PaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_PaymentMode.FormattingEnabled = True
        Me.cbo_PaymentMode.Location = New System.Drawing.Point(108, 10)
        Me.cbo_PaymentMode.Name = "cbo_PaymentMode"
        Me.cbo_PaymentMode.Size = New System.Drawing.Size(106, 21)
        Me.cbo_PaymentMode.TabIndex = 132
        '
        'txt_KOTTime
        '
        Me.txt_KOTTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KOTTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_KOTTime.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_KOTTime.Location = New System.Drawing.Point(784, 133)
        Me.txt_KOTTime.Name = "txt_KOTTime"
        Me.txt_KOTTime.ReadOnly = True
        Me.txt_KOTTime.Size = New System.Drawing.Size(69, 21)
        Me.txt_KOTTime.TabIndex = 139
        '
        'Pic_Member
        '
        Me.Pic_Member.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Member.Location = New System.Drawing.Point(746, 205)
        Me.Pic_Member.Name = "Pic_Member"
        Me.Pic_Member.Size = New System.Drawing.Size(91, 94)
        Me.Pic_Member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Member.TabIndex = 581
        Me.Pic_Member.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer_Delay
        '
        '
        'KOT_Timer
        '
        '
        'pnl_POSCode
        '
        Me.pnl_POSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_POSCode.Controls.Add(Me.lvw_POSCode)
        Me.pnl_POSCode.Location = New System.Drawing.Point(46, 53)
        Me.pnl_POSCode.Name = "pnl_POSCode"
        Me.pnl_POSCode.Size = New System.Drawing.Size(269, 119)
        Me.pnl_POSCode.TabIndex = 585
        '
        'lvw_POSCode
        '
        Me.lvw_POSCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.lvw_POSCode.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_POSCode.FullRowSelect = True
        Me.lvw_POSCode.GridLines = True
        Me.lvw_POSCode.HideSelection = False
        Me.lvw_POSCode.HoverSelection = True
        Me.lvw_POSCode.Location = New System.Drawing.Point(0, 0)
        Me.lvw_POSCode.Name = "lvw_POSCode"
        Me.lvw_POSCode.Scrollable = False
        Me.lvw_POSCode.Size = New System.Drawing.Size(263, 135)
        Me.lvw_POSCode.TabIndex = 0
        Me.lvw_POSCode.UseCompatibleStateImageBehavior = False
        Me.lvw_POSCode.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "POS Code"
        Me.ColumnHeader1.Width = 121
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "POS Desc"
        Me.ColumnHeader3.Width = 133
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Account In"
        Me.ColumnHeader5.Width = 110
        '
        'pnl_UOMCode
        '
        Me.pnl_UOMCode.BackgroundImage = CType(resources.GetObject("pnl_UOMCode.BackgroundImage"), System.Drawing.Image)
        Me.pnl_UOMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_UOMCode.Controls.Add(Me.lvw_Uom)
        Me.pnl_UOMCode.Location = New System.Drawing.Point(322, 52)
        Me.pnl_UOMCode.Name = "pnl_UOMCode"
        Me.pnl_UOMCode.Size = New System.Drawing.Size(261, 120)
        Me.pnl_UOMCode.TabIndex = 586
        '
        'lvw_Uom
        '
        Me.lvw_Uom.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvw_Uom.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_Uom.FullRowSelect = True
        Me.lvw_Uom.GridLines = True
        Me.lvw_Uom.HoverSelection = True
        Me.lvw_Uom.Location = New System.Drawing.Point(3, 0)
        Me.lvw_Uom.Name = "lvw_Uom"
        Me.lvw_Uom.Size = New System.Drawing.Size(257, 119)
        Me.lvw_Uom.TabIndex = 0
        Me.lvw_Uom.UseCompatibleStateImageBehavior = False
        Me.lvw_Uom.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "UOM Code"
        Me.ColumnHeader2.Width = 114
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "UOM Rate"
        Me.ColumnHeader4.Width = 131
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Status.Location = New System.Drawing.Point(188, 580)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(0, 22)
        Me.lbl_Status.TabIndex = 588
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_KOTnoHelp
        '
        Me.cmd_KOTnoHelp.BackgroundImage = CType(resources.GetObject("cmd_KOTnoHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_KOTnoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_KOTnoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_KOTnoHelp.Location = New System.Drawing.Point(822, 107)
        Me.cmd_KOTnoHelp.Name = "cmd_KOTnoHelp"
        Me.cmd_KOTnoHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_KOTnoHelp.TabIndex = 590
        Me.cmd_KOTnoHelp.UseVisualStyleBackColor = True
        '
        'sSGrid
        '
        Me.sSGrid.DataSource = Nothing
        Me.sSGrid.Location = New System.Drawing.Point(183, 372)
        Me.sSGrid.Name = "sSGrid"
        Me.sSGrid.OcxState = CType(resources.GetObject("sSGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sSGrid.Size = New System.Drawing.Size(659, 140)
        Me.sSGrid.TabIndex = 593
        '
        'lbl_bal
        '
        Me.lbl_bal.AllowDrop = True
        Me.lbl_bal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_bal.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bal.ForeColor = System.Drawing.Color.Magenta
        Me.lbl_bal.Location = New System.Drawing.Point(251, 559)
        Me.lbl_bal.Name = "lbl_bal"
        Me.lbl_bal.Size = New System.Drawing.Size(208, 24)
        Me.lbl_bal.TabIndex = 614
        '
        'Lbl_Bill
        '
        Me.Lbl_Bill.AutoSize = True
        Me.Lbl_Bill.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Bill.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Bill.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Bill.Location = New System.Drawing.Point(184, 607)
        Me.Lbl_Bill.Name = "Lbl_Bill"
        Me.Lbl_Bill.Size = New System.Drawing.Size(0, 18)
        Me.Lbl_Bill.TabIndex = 615
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(523, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 18)
        Me.Label6.TabIndex = 618
        Me.Label6.Text = "BILL NO(S) :"
        Me.Label6.Visible = False
        '
        'lblBillno2
        '
        Me.lblBillno2.BackColor = System.Drawing.Color.Azure
        Me.lblBillno2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillno2.Location = New System.Drawing.Point(832, 40)
        Me.lblBillno2.Name = "lblBillno2"
        Me.lblBillno2.Size = New System.Drawing.Size(178, 21)
        Me.lblBillno2.TabIndex = 617
        Me.lblBillno2.Visible = False
        '
        'lblBillno1
        '
        Me.lblBillno1.BackColor = System.Drawing.Color.Azure
        Me.lblBillno1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillno1.Location = New System.Drawing.Point(648, 40)
        Me.lblBillno1.Name = "lblBillno1"
        Me.lblBillno1.Size = New System.Drawing.Size(178, 21)
        Me.lblBillno1.TabIndex = 616
        Me.lblBillno1.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(188, 568)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(655, 15)
        Me.Label10.TabIndex = 619
        Me.Label10.Text = "Press Alt+K For Remarks/Press Alt+S For Servercode/Press Alt+B For MemberCode/Pre" & _
    "ss Alt+P For PaymentMode"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(188, 587)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(539, 15)
        Me.Label11.TabIndex = 620
        Me.Label11.Text = "Press Alt+G For SsGrid/Press Alt+T For Table No/Press Alt+C For Cover/Press Alt+L" & _
    " For Loction"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(189, 607)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(286, 15)
        Me.Label19.TabIndex = 621
        Me.Label19.Text = "Press Alt+D For KotDate/Press Ctrl+F For Final Bill"
        '
        'Cmd_GolfRegNoHelp
        '
        Me.Cmd_GolfRegNoHelp.BackgroundImage = CType(resources.GetObject("Cmd_GolfRegNoHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_GolfRegNoHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_GolfRegNoHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_GolfRegNoHelp.Location = New System.Drawing.Point(822, 74)
        Me.Cmd_GolfRegNoHelp.Name = "Cmd_GolfRegNoHelp"
        Me.Cmd_GolfRegNoHelp.Size = New System.Drawing.Size(32, 23)
        Me.Cmd_GolfRegNoHelp.TabIndex = 624
        Me.Cmd_GolfRegNoHelp.UseVisualStyleBackColor = True
        Me.Cmd_GolfRegNoHelp.Visible = False
        '
        'Txt_GolfRegNo
        '
        Me.Txt_GolfRegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GolfRegNo.Location = New System.Drawing.Point(696, 75)
        Me.Txt_GolfRegNo.Name = "Txt_GolfRegNo"
        Me.Txt_GolfRegNo.Size = New System.Drawing.Size(124, 20)
        Me.Txt_GolfRegNo.TabIndex = 623
        Me.Txt_GolfRegNo.Visible = False
        '
        'Lbl_GolfRegNo
        '
        Me.Lbl_GolfRegNo.AutoSize = True
        Me.Lbl_GolfRegNo.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_GolfRegNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_GolfRegNo.Location = New System.Drawing.Point(614, 77)
        Me.Lbl_GolfRegNo.Name = "Lbl_GolfRegNo"
        Me.Lbl_GolfRegNo.Size = New System.Drawing.Size(75, 15)
        Me.Lbl_GolfRegNo.TabIndex = 622
        Me.Lbl_GolfRegNo.Text = "Golf Reg No."
        Me.Lbl_GolfRegNo.Visible = False
        '
        'FRM_TKGA_SmartKotEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.pnl_UOMCode)
        Me.Controls.Add(Me.Cmd_GolfRegNoHelp)
        Me.Controls.Add(Me.Txt_GolfRegNo)
        Me.Controls.Add(Me.Lbl_GolfRegNo)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblBillno2)
        Me.Controls.Add(Me.lblBillno1)
        Me.Controls.Add(Me.Lbl_Bill)
        Me.Controls.Add(Me.lbl_bal)
        Me.Controls.Add(Me.sSGrid)
        Me.Controls.Add(Me.cmd_KOTnoHelp)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.pnl_POSCode)
        Me.Controls.Add(Me.Pic_Member)
        Me.Controls.Add(Me.txt_KOTTime)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtp_KOTdate)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.TextBox17)
        Me.Controls.Add(Me.TextBox16)
        Me.Controls.Add(Me.TextBox15)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox14)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Txt_Remarks)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_KOTno)
        Me.Controls.Add(Me.Lab_Kotdate)
        Me.Controls.Add(Me.LBL_KotNo)
        Me.Controls.Add(Me.txt_card_id)
        Me.Controls.Add(Me.lbl_SwipeCard)
        Me.KeyPreview = True
        Me.Name = "FRM_TKGA_SmartKotEntry"
        Me.Text = "FRM_TKGA_SmartKotEntry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_POSCode.ResumeLayout(False)
        Me.pnl_UOMCode.ResumeLayout(False)
        CType(Me.sSGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents txt_ServerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Txt_holder_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SubPaymentMode As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_MemberName As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Holder_Code As System.Windows.Forms.TextBox
    Friend WithEvents txt_MemberCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Membercode As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_KOTno As System.Windows.Forms.TextBox
    Friend WithEvents Lab_Kotdate As System.Windows.Forms.Label
    Friend WithEvents LBL_KotNo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_card_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SwipeCard As System.Windows.Forms.Button
    Friend WithEvents dtp_KOTdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMB_BTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_TableNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cover As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbo_SubPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_PaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents txt_KOTTime As System.Windows.Forms.TextBox
    Friend WithEvents Pic_Member As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_ServerCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer_Delay As System.Windows.Forms.Timer
    Friend WithEvents KOT_Timer As System.Windows.Forms.Timer
    Friend WithEvents pnl_POSCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_POSCode As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnl_UOMCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_Uom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents cmd_KOTnoHelp As System.Windows.Forms.Button
    Friend WithEvents cmd_TablenoHelp As System.Windows.Forms.Button
    Friend WithEvents sSGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_bal As System.Windows.Forms.Label
    Friend WithEvents Lbl_Bill As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblBillno2 As System.Windows.Forms.Label
    Friend WithEvents lblBillno1 As System.Windows.Forms.Label
    Friend WithEvents CMD_LOCHELP As System.Windows.Forms.Button
    Friend WithEvents txt_LOCATIONCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXT_LOCATIONNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cmd_GolfRegNoHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_GolfRegNo As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_GolfRegNo As System.Windows.Forms.Label
    Friend WithEvents Lbl_PartyBookingNo As System.Windows.Forms.Label
    Friend WithEvents Txt_PartyBookingNo As System.Windows.Forms.TextBox
End Class
