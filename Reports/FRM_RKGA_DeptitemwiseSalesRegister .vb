Imports System.Data.SqlClient
Public Class DeptitemwiseSalesRegister
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
    Friend WithEvents LstPOS As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SelectAllPos As System.Windows.Forms.CheckBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chk_DEPARTMENT As System.Windows.Forms.CheckBox
    Friend WithEvents chkbox_group As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GP_DEPT_WISE As System.Windows.Forms.CheckBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents CHK_DATEWISE As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeptitemwiseSalesRegister))
        Me.LstPOS = New System.Windows.Forms.CheckedListBox()
        Me.Chk_SelectAllPos = New System.Windows.Forms.CheckBox()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.mskFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chk_DEPARTMENT = New System.Windows.Forms.CheckBox()
        Me.chkbox_group = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GP_DEPT_WISE = New System.Windows.Forms.CheckBox()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.CHK_DATEWISE = New System.Windows.Forms.CheckBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstPOS
        '
        Me.LstPOS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPOS.Location = New System.Drawing.Point(291, 161)
        Me.LstPOS.Name = "LstPOS"
        Me.LstPOS.Size = New System.Drawing.Size(234, 356)
        Me.LstPOS.TabIndex = 382
        '
        'Chk_SelectAllPos
        '
        Me.Chk_SelectAllPos.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPos.Location = New System.Drawing.Point(294, 114)
        Me.Chk_SelectAllPos.Name = "Chk_SelectAllPos"
        Me.Chk_SelectAllPos.Size = New System.Drawing.Size(160, 24)
        Me.Chk_SelectAllPos.TabIndex = 389
        Me.Chk_SelectAllPos.Text = "SELECT ALL"
        Me.Chk_SelectAllPos.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(0, 16)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 395
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.White
        Me.CmdPrint.BackgroundImage = CType(resources.GetObject("CmdPrint.BackgroundImage"), System.Drawing.Image)
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Location = New System.Drawing.Point(30, 436)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 392
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(1, 282)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 394
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(152, 1000)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(712, 64)
        Me.grp_SalebillChecklist.TabIndex = 393
        Me.grp_SalebillChecklist.TabStop = False
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
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.mskFromDate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.mskToDate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(266, 563)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(522, 64)
        Me.GroupBox3.TabIndex = 390
        Me.GroupBox3.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(110, 24)
        Me.mskFromDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(144, 21)
        Me.mskFromDate.TabIndex = 0
        Me.mskFromDate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(282, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "To Date :"
        '
        'mskToDate
        '
        Me.mskToDate.CustomFormat = "dd/MM/yyyy"
        Me.mskToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskToDate.Location = New System.Drawing.Point(350, 24)
        Me.mskToDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.Name = "mskToDate"
        Me.mskToDate.Size = New System.Drawing.Size(144, 21)
        Me.mskToDate.TabIndex = 1
        Me.mskToDate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "From Date :"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(-1, 104)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(131, 56)
        Me.CmdView.TabIndex = 391
        Me.CmdView.Text = "Report  [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CmdPrint)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.cmdexport)
        Me.GroupBox4.Location = New System.Drawing.Point(873, 125)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(133, 380)
        Me.GroupBox4.TabIndex = 396
        Me.GroupBox4.TabStop = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Transparent
        Me.cmdexport.BackgroundImage = Global.SpecialParty.My.Resources.Resources.excel
        Me.cmdexport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexport.Location = New System.Drawing.Point(1, 190)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(131, 56)
        Me.cmdexport.TabIndex = 395
        Me.cmdexport.Text = " Export [F12]"
        Me.cmdexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'chk_DEPARTMENT
        '
        Me.chk_DEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.chk_DEPARTMENT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_DEPARTMENT.Location = New System.Drawing.Point(369, 537)
        Me.chk_DEPARTMENT.Name = "chk_DEPARTMENT"
        Me.chk_DEPARTMENT.Size = New System.Drawing.Size(151, 24)
        Me.chk_DEPARTMENT.TabIndex = 424
        Me.chk_DEPARTMENT.Text = "LOCATION WISE"
        Me.chk_DEPARTMENT.UseVisualStyleBackColor = False
        '
        'chkbox_group
        '
        Me.chkbox_group.BackColor = System.Drawing.Color.Transparent
        Me.chkbox_group.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbox_group.Location = New System.Drawing.Point(904, 488)
        Me.chkbox_group.Name = "chkbox_group"
        Me.chkbox_group.Size = New System.Drawing.Size(80, 24)
        Me.chkbox_group.TabIndex = 425
        Me.chkbox_group.Text = "GROUP/LOCATION WISE"
        Me.chkbox_group.UseVisualStyleBackColor = False
        Me.chkbox_group.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(542, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(230, 24)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "CATEGORY"
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(542, 116)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllCategory.TabIndex = 431
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstcategory.Location = New System.Drawing.Point(539, 163)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(230, 356)
        Me.lstcategory.TabIndex = 432
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(294, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 24)
        Me.Label2.TabIndex = 434
        Me.Label2.Text = "POS LOCATION"
        '
        'GP_DEPT_WISE
        '
        Me.GP_DEPT_WISE.BackColor = System.Drawing.Color.Transparent
        Me.GP_DEPT_WISE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GP_DEPT_WISE.Location = New System.Drawing.Point(896, 549)
        Me.GP_DEPT_WISE.Name = "GP_DEPT_WISE"
        Me.GP_DEPT_WISE.Size = New System.Drawing.Size(192, 24)
        Me.GP_DEPT_WISE.TabIndex = 435
        Me.GP_DEPT_WISE.Text = "GROUPWISE "
        Me.GP_DEPT_WISE.UseVisualStyleBackColor = False
        Me.GP_DEPT_WISE.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.Location = New System.Drawing.Point(176, 82)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(224, 16)
        Me.lbl_Heading.TabIndex = 436
        Me.lbl_Heading.Text = "POS WISE  ITEM  SALE REGISTER"
        '
        'CHK_DATEWISE
        '
        Me.CHK_DATEWISE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DATEWISE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DATEWISE.Location = New System.Drawing.Point(561, 537)
        Me.CHK_DATEWISE.Name = "CHK_DATEWISE"
        Me.CHK_DATEWISE.Size = New System.Drawing.Size(99, 24)
        Me.CHK_DATEWISE.TabIndex = 437
        Me.CHK_DATEWISE.Text = "DATEWISE"
        Me.CHK_DATEWISE.UseVisualStyleBackColor = False
        '
        'DeptitemwiseSalesRegister
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.Controls.Add(Me.CHK_DATEWISE)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GP_DEPT_WISE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkbox_group)
        Me.Controls.Add(Me.chk_DEPARTMENT)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LstPOS)
        Me.Controls.Add(Me.Chk_SelectAllPos)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DeptitemwiseSalesRegister"
        Me.Text = "DaywiseSalesRegister"
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
    Public Myconn As New SqlConnection
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub Reportsform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mskFromDate.Value = Format(CDate(Now), "dd-MM-yyyy")
        mskToDate.Value = Format(CDate(Now), "dd-MM-yyyy")
        grp_SalebillChecklist.Top = 1000
        Call FillPOS()
        FillCATEGORY()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CATERING"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))

    End Sub
    Private Sub FillCATEGORY()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        Dim gconnection As String
        lstcategory.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT CATEGORY FROM ITEMMaster "
        vconn.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    lstcategory.Items.Add(Trim(.Item("CATEGORY")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub
    '''******************************  To fill POS details from POSMaster  *******************************'''
    Private Sub FillPOS()
        Dim i As Integer
        Dim sqlstring As String
        LstPOS.Items.Clear()
        sqlstring = "SELECT DISTINCT poscode,posdesc FROM posmaster WHERE ISNULL(Freeze,'')<>'Y'"
        vconn.getDataSet(sqlstring, "posmaster")
        If gdataset.Tables("posmaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("posmaster").Rows.Count - 1
                With gdataset.Tables("posmaster").Rows(i)
                    LstPOS.Items.Add(Trim(.Item("POSdesc")))
                End With
            Next i
            LstPOS.Sorted = True
        End If
    End Sub
    '''*****************************  To fill Server details from ServerMaster  **************************'''
    'Private Sub FillServer()
    '    'Dim i As Integer
    '    'Dim sqlstring As String
    '    'LstServer.Items.Clear()
    '    'sqlstring = "SELECT DISTINCT servercode, servername FROM servermaster WHERE ISNULL(Freeze,'')<>'Y'"
    '    'vconn.getDataSet(sqlstring, "servermaster")
    '    'If gdataset.Tables("servermaster").Rows.Count - 1 >= 0 Then
    '    '    For i = 0 To gdataset.Tables("servermaster").Rows.Count - 1
    '    '        With gdataset.Tables("servermaster").Rows(i)
    '    '            LstServer.Items.Add(Trim(.Item("ServerCode") & "->" & .Item("servername")))
    '    '        End With
    '    '    Next i
    '    '    LstServer.Sorted = True
    '    'End If
    'End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        grp_SalebillChecklist.Top = 1000
        lstcategory.Items.Clear()
        lstcategory.Items.Add(Trim("CANTEEN"))
        lstcategory.Items.Add(Trim("BAR"))
        lstcategory.Items.Add(Trim("FACILITY"))

        gPrint = False
        LstPOS.Items.Clear()
        Call FillPOS()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If LstPOS.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If lstcategory.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Category(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
       
        Checkdaterangevalidate(mskFromDate.Value, mskToDate.Value)
        If chkdatevalidate = False Then Exit Sub
        Dim SSQL As String
       

        If chk_DEPARTMENT.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call Viewdaywisesaleregister_dept()
        ElseIf CHK_DATEWISE.Checked = True Then
            SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
            gconnection.ExcuteStoreProcedure(SSQL)
            Call DATEWISE()
        End If

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub DATEWISE()
        Try
            Dim HNAME As String
            Dim i As Integer
            Call validatedate() ''--> Check Validation
            If chkbool = False Then Exit Sub
            SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,UOM,RATE,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as PACKAMOUNT,KOTDATE,SUM(AMOUNT) AS AMOUNT,SUM(AMT) AS AMT,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE   FROM VIEWITEMWISESALESUMMARY_JIC "
            SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
            SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
            If LstPOS.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and CATEGORY in ("
                HNAME = "("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                    HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"
            End If

            SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,CATEGORY,KOTDATE ORDER BY KOTDATE,POSDESC,itemdesc"

            Dim r1 As New deptDateWise
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text18")
            TXTOBJ4.Text = HNAME

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
            TXTOBJ1.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


            Viewer.ssql = SQLSTRING
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
            Viewer.Show()
            'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
            'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
            'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
            'Dim total() As Integer = {2, 3, 4, 5, 6}
            'Dim DaySalesRegisterReport As New DaySalesRegisterReport
            'DaySalesRegisterReport.begin()
            '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Function validatedate()
        ''''chkbool = False
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(Now.Today, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should less than Today Date", MsgBoxStyle.Information)
        ''''    mskFromDate.Text = ""
        ''''    mskFromDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") < Format(CDate("01-Apr-" & gFinancalyearStart), "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should  be in the Finacial Year", MsgBoxStyle.Information)
        ''''    mskFromDate.Text = ""
        ''''    mskFromDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(mskToDate.Value, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should be Less than To date", MsgBoxStyle.Information)
        ''''    Exit Function
        ''''End If
        ''''If Format(mskToDate.Value, "MM-dd-yyyy") > Format(Now.Today, "MM-dd-yyyy") Then
        ''''    MsgBox("To Date should less be than Today Date", MsgBoxStyle.Information)
        ''''    mskToDate.Text = ""
        ''''    mskToDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskToDate.Value, "MM-dd-yyyy") > Format("31-Mar-07", "MM-dd-yyyy") Then
        ''''    MsgBox("To Date should not be less than Finacial Year", MsgBoxStyle.Information)
        ''''    mskToDate.Text = ""
        ''''    mskToDate.Focus()
        ''''    Exit Function
        ''''End If
        ''''If Format(mskFromDate.Value, "MM-dd-yyyy") > Format(mskToDate.Value, "MM-dd-yyyy") Then
        ''''    MsgBox("From Date should be Less than To date", MsgBoxStyle.Information)
        ''''    Exit Function
        ''''End If
        CmdView.Focus()
        chkbool = True
    End Function


    Private Sub Chk_SelectAllPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPos.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPos.Checked = True Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next i
        End If
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        gPrint = True
        If chk_DEPARTMENT.Checked = True Then
            Call Viewdaywisesaleregister_dept()
        ElseIf GP_DEPT_WISE.Checked = True Then
            Call Viewdaywisesaleregister_DEPT_GROUPWISE()
        ElseIf chkbox_group.Checked = True Then
            'Call Viewdaywisesaleregister()
            Call Viewdaywisesaleregister_GROUPWISE()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            If chk_DEPARTMENT.Checked = True Then
                Call Viewdaywisesaleregister_dept()
            ElseIf chkbox_group.Checked = True Then
                'Call Viewdaywisesaleregister()
                Call Viewdaywisesaleregister_GROUPWISE()
            Else
                Call Viewdaywisesaleregister_DEPT_GROUPWISE()

            End If
            'Call Viewdaywisesaleregister()
        End If
    End Sub
    Private Sub Viewdaywisesaleregister_dept()
        Try
            Dim HNAME As String
            Dim i As Integer
            Call validatedate() ''--> Check Validation
            If chkbool = False Then Exit Sub
            SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,UOM,RATE,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as PACKAMOUNT,SUM(AMOUNT) AS AMOUNT,SUM(AMT) AS AMT,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE FROM VIEWITEMWISESALESUMMARY_JIC "
            SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
            SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
            If LstPOS.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and CATEGORY in ("
                HNAME = "("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                    HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"
            End If

            SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,CATEGORY ORDER BY POSDESC,itemdesc"

            Dim r1 As New deptItemWise
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = "PERIOD FROM  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  TO " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text18")
            TXTOBJ4.Text = HNAME

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
            TXTOBJ1.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


            Viewer.ssql = SQLSTRING
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
            Viewer.Show()
            'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
            'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
            'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
            'Dim total() As Integer = {2, 3, 4, 5, 6}
            'Dim DaySalesRegisterReport As New DaySalesRegisterReport
            'DaySalesRegisterReport.begin()
            '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Viewdaywisesaleregister_DEPT_GROUPWISE()


        Dim i As Integer
        Call validatedate() ''--> Check Validation
        If chkbool = False Then Exit Sub
        SQLSTRING = " SELECT ITEMCODE,ITEMDESC,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,UOM,TAXAMOUNT,SUM(AMOUNT) AS AMOUNT FROM VIEWITEMWISESALESUMMARY_JIC "
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If
        SQLSTRING = SQLSTRING & " GROUP BY itemcode,itemdesc,UOM,TAXAMOUNT,GROUPCODE,GROUPDESC,category ORDER BY GROUPDESC"

        Dim r1 As New GroupWiseDeptItem
        Dim Viewer As New ReportViwer
        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ3.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


        'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text4")
        TXTOBJ5.Text = gCompanyname


        Viewer.ssql = SQLSTRING
        Viewer.Report = r1
        Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
        Viewer.Show()
        'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
        'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
        'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
        'Dim total() As Integer = {2, 3, 4, 5, 6}
        'Dim DaySalesRegisterReport As New DaySalesRegisterReport
        'DaySalesRegisterReport.begin()
        '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub Viewdaywisesaleregister_GROUPWISE()
        Try

            Dim i As Integer
            Call validatedate() ''--> Check Validation
            If chkbool = False Then Exit Sub
            SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,GROUPCODE,GROUPDESC,SUM(QTY) AS QTY,UOM,RATE,TAXAMOUNT,SUM(AMOUNT) AS AMOUNT FROM VIEWITEMWISESALESUMMARY_JIC "
            SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
            SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
            If LstPOS.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If lstcategory.CheckedItems.Count <> 0 Then
                SQLSTRING = SQLSTRING & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
                SQLSTRING = SQLSTRING & ")"
            End If
            SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,TAXAMOUNT,GROUPCODE,GROUPDESC,category ORDER BY POSDESC"

            Dim r1 As New GroupWiseItem
            Dim Viewer As New ReportViwer
            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ3.Text = " From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""


            'Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text15")

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ5.Text = gCompanyname

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = "UserName : " & gUsername
            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")


            Viewer.ssql = SQLSTRING
            Viewer.Report = r1
            Viewer.TableName = "VIEWITEMWISESALESUMMARY_JIC"
            Viewer.Show()
            'Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
            'Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
            'Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
            'Dim total() As Integer = {2, 3, 4, 5, 6}
            'Dim DaySalesRegisterReport As New DaySalesRegisterReport
            'DaySalesRegisterReport.begin()
            '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub



    Private Sub Viewdaywisesaleregister()


        Dim i As Integer
        Call validatedate() ''--> Check Validation
        If chkbool = False Then Exit Sub
        Dim sqlstring = "SELECT BH.BILLDATE,P.POSDESC,SUM(ISNULL(R.PURCAHSERATE,0)) AS PURCHASERATE,"
        sqlstring = sqlstring & " SUM(ISNULL(BH.BILLAMOUNT,0)) AS BILLAMOUNT,SUM(ISNULL(BH.TAXAMOUNT,0)) AS TAXAMOUNT, "
        sqlstring = sqlstring & " SUM(ISNULL(BH.TOTALAMOUNT,0)) AS TOTALAMOUNT,SUM(ISNULL(BH.TAXAMOUNT,0) + ISNULL(BH.TOTALAMOUNT,0)) AS TOTAL"
        sqlstring = sqlstring & " FROM BILL_HDR AS BH INNER JOIN KOT_DET AS KD ON BH.BILLDETAILS = KD.BILLDETAILS "
        sqlstring = sqlstring & " INNER JOIN POSMASTER AS P ON P.POSCODE = KD.POSCODE INNER JOIN RATEMASTER AS R ON R.ITEMCODE = KD.ITEMCODE "
        If LstPOS.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE P.POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        sqlstring = sqlstring & "AND BH.BILLDATE BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND ' " & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        sqlstring = sqlstring & " GROUP BY P.POSDESC,BH.BILLDATE ORDER BY P.POSDESC"
        Dim columnheading() As String = {"BILL DATE", "COST CENTRE", "PURCHASE Rs.", "TOTAL Rs.", "VAT AMT Rs.", "BASIC SALES Rs.", "TOTAL SALES Rs."}
        Dim pageheading() As String = {"DAYWISE SALES REGISTER"}
        Dim colsize() As Integer = {15, 30, 15, 15, 18, 18, 15}
        Dim total() As Integer = {2, 3, 4, 5, 6}
        Dim DaySalesRegisterReport As New DaySalesRegisterReport
        'DaySalesRegisterReport.begin()
        '`DaySalesRegisterReport.buttonclick(vconn.sqlconnection, sqlstring, pageheading, columnheading, colsize, LstPOS, mskFromDate.Value, mskToDate.Value, total)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub

    End Sub

    Private Sub Chk_SelectAllCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllCategory.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllCategory.Checked = True Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub
    Private Sub LstPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPOS.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub lstcategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstcategory.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub DeptitemwiseSalesRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            If CmdClear.Enabled = True Then
                Call CmdClear_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CmdView_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If CmdPrint.Enabled = True Then
                Call cmdexport_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
        End If
    End Sub
    Private Sub POSLOCATIONWISE()
        Dim HNAME As String
        Dim i As Integer
        Dim exp As New exportexcel
        SQLSTRING = " SELECT POSCODE,POSDESC,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,UOM,RATE,SUM(AMT) AS AMOUNT,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as servicetax  ,SUM(AMOUNT) AS TOTAL,,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE  FROM VIEWITEMWISESALESUMMARY_JIC "
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            HNAME = "("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,itemcode,itemdesc,UOM,rate,CATEGORY ORDER BY POSDESC,itemdesc"
        gconnection.getDataSet(SQLSTRING, "POSITEMWISESALES")
        If gdataset.Tables("POSITEMWISESALES").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SQLSTRING, "POSWISE-ITEMSALES " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub POSDATEWISE()
        Dim HNAME As String
        Dim i As Integer
        Dim exp As New exportexcel
        SQLSTRING = " SELECT KOTDATE,POSCODE,POSDESC,ITEMCODE,ITEMDESC,SUM(QTY) AS QTY,UOM,RATE,SUM(AMT) AS AMOUNT,sum(TAXAMOUNT)as taxamount,sum(SCHARGE)as SCHARGE,sum(PACKAMOUNT)as servicetax,SUM(AMOUNT) AS TOTAL,SUM(ACHARGE) AS ACHARGE,SUM(PCHARGE) AS PCHARGE,SUM(RCHARGE) AS RCHARGE  FROM VIEWITEMWISESALESUMMARY_JIC "
        SQLSTRING = SQLSTRING & " WHERE CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) BETWEEN "
        SQLSTRING = SQLSTRING & " '" & Format(mskFromDate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(mskToDate.Value, "dd/MMM/yyyy") & "'"
        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If

        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            HNAME = "("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(i) & "', "
                HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If

        SQLSTRING = SQLSTRING & " GROUP BY POSCODE,POSDESC,KOTDATE,itemcode,itemdesc,UOM,rate,CATEGORY ORDER BY POSDESC,KOTDATE,itemdesc"
        gconnection.getDataSet(SQLSTRING, "POSITEMWISESALES")
        If gdataset.Tables("POSITEMWISESALES").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(SQLSTRING, "POSWISE SALES-DATEWISE " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim SSQL As String
        SSQL = "EXEC GROUPWISESALE '" & Format(Me.mskFromDate.Value, "dd-MMM-yyyy") & "','" & Format(Me.mskToDate.Value, "dd-MMM-yyyy") & "','N'"
        gconnection.ExcuteStoreProcedure(SSQL)

        If chk_DEPARTMENT.Checked = True Then
            Call POSLOCATIONWISE()
        ElseIf CHK_DATEWISE.Checked = True Then
            Call POSDATEWISE()
        End If
    End Sub

    Private Sub chk_DEPARTMENT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_DEPARTMENT.CheckedChanged
        If chk_DEPARTMENT.Checked = True Then
            CHK_DATEWISE.Checked = False
        End If
    End Sub

    Private Sub CHK_DATEWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_DATEWISE.CheckedChanged
        If CHK_DATEWISE.Checked = True Then
            chk_DEPARTMENT.Checked = False
        End If
    End Sub
End Class
