Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_RKGA_CancelItemRegister
    Inherits System.Windows.Forms.Form
    Dim pageno As Integer
    Dim gconnection As New GlobalClass
    Dim ssql As String
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Dim dr As DataRow

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
    Friend WithEvents btn_Exporttoexcel As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mskToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllPos As System.Windows.Forms.CheckBox
    Friend WithEvents LstPOS As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmdcry As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chk_it As System.Windows.Forms.CheckBox
    Friend WithEvents chkbill As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_RKGA_CancelItemRegister))
        Me.btn_Exporttoexcel = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdcry = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mskFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mskToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllPos = New System.Windows.Forms.CheckBox()
        Me.LstPOS = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chk_it = New System.Windows.Forms.CheckBox()
        Me.chkbill = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Exporttoexcel
        '
        Me.btn_Exporttoexcel.BackColor = System.Drawing.Color.White
        Me.btn_Exporttoexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Exporttoexcel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exporttoexcel.ForeColor = System.Drawing.Color.White
        Me.btn_Exporttoexcel.Image = CType(resources.GetObject("btn_Exporttoexcel.Image"), System.Drawing.Image)
        Me.btn_Exporttoexcel.Location = New System.Drawing.Point(856, 51)
        Me.btn_Exporttoexcel.Name = "btn_Exporttoexcel"
        Me.btn_Exporttoexcel.Size = New System.Drawing.Size(104, 32)
        Me.btn_Exporttoexcel.TabIndex = 429
        Me.btn_Exporttoexcel.Text = "Grid View"
        Me.btn_Exporttoexcel.UseVisualStyleBackColor = False
        Me.btn_Exporttoexcel.Visible = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.White
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.Location = New System.Drawing.Point(832, 304)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 425
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.White
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(8, 249)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 426
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.White
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(6, 42)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 427
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.White
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(848, 34)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 424
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        Me.CmdView.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdcry)
        Me.GroupBox2.Controls.Add(Me.CmdClear)
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.cmdexport)
        Me.GroupBox2.Location = New System.Drawing.Point(857, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(148, 336)
        Me.GroupBox2.TabIndex = 428
        Me.GroupBox2.TabStop = False
        '
        'cmdcry
        '
        Me.cmdcry.BackColor = System.Drawing.Color.White
        Me.cmdcry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdcry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcry.ForeColor = System.Drawing.Color.Black
        Me.cmdcry.Image = Global.SpecialParty.My.Resources.Resources.view
        Me.cmdcry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdcry.Location = New System.Drawing.Point(6, 113)
        Me.cmdcry.Name = "cmdcry"
        Me.cmdcry.Size = New System.Drawing.Size(131, 56)
        Me.cmdcry.TabIndex = 427
        Me.cmdcry.Text = "Report [F9]"
        Me.cmdcry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdcry.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.White
        Me.cmdexport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexport.Location = New System.Drawing.Point(6, 181)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(131, 56)
        Me.cmdexport.TabIndex = 6
        Me.cmdexport.Text = " Export [F12]"
        Me.cmdexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.mskFromDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.mskToDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(224, 480)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 64)
        Me.GroupBox1.TabIndex = 423
        Me.GroupBox1.TabStop = False
        '
        'mskFromDate
        '
        Me.mskFromDate.CustomFormat = "dd/MM/yyyy"
        Me.mskFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskFromDate.Location = New System.Drawing.Point(155, 23)
        Me.mskFromDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskFromDate.Name = "mskFromDate"
        Me.mskFromDate.Size = New System.Drawing.Size(144, 21)
        Me.mskFromDate.TabIndex = 0
        Me.mskFromDate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(308, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "TO DATE :"
        '
        'mskToDate
        '
        Me.mskToDate.CustomFormat = "dd/MM/yyyy"
        Me.mskToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mskToDate.Location = New System.Drawing.Point(385, 22)
        Me.mskToDate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.mskToDate.Name = "mskToDate"
        Me.mskToDate.Size = New System.Drawing.Size(144, 21)
        Me.mskToDate.TabIndex = 1
        Me.mskToDate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(336, -291)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(272, 26)
        Me.Label4.TabIndex = 435
        Me.Label4.Text = "CATEGORY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FROM DATE :"
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(336, -315)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(136, 24)
        Me.CheckBox2.TabIndex = 433
        Me.CheckBox2.Text = "SELECT ALL "
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(0, -315)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox1.TabIndex = 430
        Me.CheckBox1.Text = "SELECT ALL"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, -291)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 24)
        Me.Label1.TabIndex = 432
        Me.Label1.Text = "POS LOCATION :"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(203, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(288, 24)
        Me.Label6.TabIndex = 432
        Me.Label6.Text = "POS LOCATION :"
        '
        'Chk_SelectAllPos
        '
        Me.Chk_SelectAllPos.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPos.Location = New System.Drawing.Point(203, 157)
        Me.Chk_SelectAllPos.Name = "Chk_SelectAllPos"
        Me.Chk_SelectAllPos.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllPos.TabIndex = 430
        Me.Chk_SelectAllPos.Text = "SELECT ALL"
        Me.Chk_SelectAllPos.UseVisualStyleBackColor = False
        '
        'LstPOS
        '
        Me.LstPOS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPOS.Location = New System.Drawing.Point(203, 205)
        Me.LstPOS.Name = "LstPOS"
        Me.LstPOS.Size = New System.Drawing.Size(288, 212)
        Me.LstPOS.TabIndex = 431
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(494, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 26)
        Me.Label3.TabIndex = 435
        Me.Label3.Text = "CATEGORY"
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(494, 157)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllCategory.TabIndex = 433
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstcategory.Location = New System.Drawing.Point(494, 205)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(272, 212)
        Me.lstcategory.TabIndex = 434
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(182, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(157, 15)
        Me.Label16.TabIndex = 436
        Me.Label16.Text = "CANCELED ITEM REGISTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_it
        '
        Me.chk_it.BackColor = System.Drawing.Color.Transparent
        Me.chk_it.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_it.Location = New System.Drawing.Point(318, 444)
        Me.chk_it.Name = "chk_it"
        Me.chk_it.Size = New System.Drawing.Size(158, 24)
        Me.chk_it.TabIndex = 437
        Me.chk_it.Text = "CANCELED KOT ITEM"
        Me.chk_it.UseVisualStyleBackColor = False
        '
        'chkbill
        '
        Me.chkbill.BackColor = System.Drawing.Color.Transparent
        Me.chkbill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbill.Location = New System.Drawing.Point(556, 444)
        Me.chkbill.Name = "chkbill"
        Me.chkbill.Size = New System.Drawing.Size(144, 24)
        Me.chkbill.TabIndex = 438
        Me.chkbill.Text = "CANCELED BILL"
        Me.chkbill.UseVisualStyleBackColor = False
        '
        'FRM_RKGA_CancelItemRegister
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1018, 696)
        Me.Controls.Add(Me.chkbill)
        Me.Controls.Add(Me.chk_it)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Chk_SelectAllPos)
        Me.Controls.Add(Me.LstPOS)
        Me.Controls.Add(Me.btn_Exporttoexcel)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmdPrint)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FRM_RKGA_CancelItemRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CANCEL ITEM : REGISTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Function printoperation()
        Dim heading As String
        Dim rowcount, TotalDoc As Integer
        Try
            'Dim Filewrite As StreamWriter
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Cro" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".Txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            heading = "CANCEL ITEM REGISTER"

            Filewrite.Write(Chr(15))
            PrintHeader(heading, mskFromDate.Value, mskToDate.Value)

            ''========================================================================

            Dim vString, sqlstring, ssql As String
            Dim vTypeseqno As Double
            Dim vGroupseqno As Double
            Dim totQty As Double
            Dim dt As New DataTable
            Dim i, j As Integer
            Dim CODEPOS() As String
            Dim POSDESC As String
            Dim dblGRQTY, dblGRAMOUNT As Double
            ssql = "SELECT A.SERVICELOCATION,B.* FROM KOT_HDR A,KOT_DET B WHERE A.KOTDETAILS=B.KOTDETAILS AND (ISNULL(B.KOTSTATUS,'')='Y' OR ISNULL(B.DELFLAG,'')='Y') and cast(convert(varchar(11),B.KOTDATE,6) as DATETIME) BETWEEN '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "' "
            'ssql = "SELECT A.SERVICELOCATION,B.* FROM KOT_HDR A,KOT_DET B WHERE A.KOTDETAILS=B.KOTDETAILS AND  cast(convert(varchar(11),B.KOTDATE,6) as DATETIME) BETWEEN '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "' "

            If LstPOS.CheckedItems.Count <> 0 Then
                ssql = ssql & " and A.servicelocation in ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
                    ssql = ssql & " '" & CODEPOS(0) & "', "
                Next
                ssql = Mid(ssql, 1, Len(ssql) - 2)
                ssql = ssql & ")"
            End If

            If lstcategory.CheckedItems.Count <> 0 Then
                ssql = ssql & " and CATEGORY in ("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    ssql = ssql & " '" & lstcategory.CheckedItems(i) & "', "
                Next
                ssql = Mid(ssql, 1, Len(ssql) - 2)
                ssql = ssql & ")"
            End If

            ssql = ssql & " order by A.SERVICELOCATION,b.ADDUSERID,B.kotdetails  "
            gconnection.getDataSet(ssql, "cancel_item")
            If gdataset.Tables("cancel_item").Rows.Count > 0 Then
                Filewrite.Write(Chr(18))
                rowcount = 9
                For Each dr In gdataset.Tables("cancel_item").Rows
                    If rowcount >= 60 Then
                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        PrintHeader(heading, mskFromDate.Value, mskToDate.Value)
                        rowcount = 9
                    End If
                    If POSDESC <> dr("SERVICELOCATION") Then
                        If Val(dblGRQTY) > 0 Then
                            Filewrite.WriteLine()
                            Filewrite.WriteLine(StrDup(73, "."))
                            rowcount = rowcount + 2
                            Filewrite.WriteLine(Mid(UCase(POSDESC), 1, 20) & Space(20 - Len(Mid(UCase(POSDESC), 1, 20))) & "  Total =====>" & Space(3) & Space(10 - Len(Mid(Format(Val(dblGRQTY), "0.00"), 1, 10))) & Mid(Format(Val(dblGRQTY), "0.00"), 1, 10) & Space(11) & Space(12 - Len(Mid(Format(Val(dblGRAMOUNT), "0.00"), 1, 12))) & Mid(Format(Val(dblGRAMOUNT), "0.00"), 1, 12))
                            rowcount = rowcount + 1
                            Filewrite.WriteLine(StrDup(73, "."))
                            Filewrite.WriteLine()
                            rowcount = rowcount + 2
                            dblGRQTY = 0
                            dblGRAMOUNT = 0
                        End If
                        Filewrite.WriteLine(Mid(dr("SERVICELOCATION"), 1, 10) & Space(10 - Len(Mid(dr("SERVICELOCATION"), 1, 10))))
                        rowcount = rowcount + 1
                        POSDESC = dr("SERVICELOCATION")
                    End If

                    sqlstring = Format(dr("KOTDATE"), "dd-MMM-yyyy") & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("KOTDETAILS")), 1, 20) & Space(20 - Len(Mid(Trim(dr("KOTDETAILS")), 1, 20))) & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("MCODE")), 1, 20) & Space(20 - Len(Mid(Trim(dr("MCODE")), 1, 20))) & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("ITEMCODE")), 1, 9) & Space(9 - Len(Trim(dr("ITEMCODE")))) & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("ITEMDESC")), 1, 28) & Space(28 - Len(Trim(Mid(dr("ITEMDESC"), 1, 28)))) & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("SCODE")), 1, 4) & Space(4 - Len(Trim(Mid(dr("SCODE"), 1, 4)))) & Space(1)
                    sqlstring = sqlstring & Mid(Trim(dr("ADDUSERID")), 1, 10) & Space(10 - Len(Trim(Mid(dr("ADDUSERID"), 1, 10))))
                    dblGRQTY = dblGRQTY + dr("qty")
                    dblGRAMOUNT = dblGRAMOUNT + dr("AMOUNT")
                    Filewrite.WriteLine(sqlstring)
                    rowcount = rowcount + 1
                    TotalDoc = TotalDoc + 1
                Next
                Filewrite.WriteLine(StrDup(81, "-"))
                Filewrite.WriteLine("Total Document(S)    : " & TotalDoc)
                Filewrite.WriteLine(StrDup(81, "-"))
                Filewrite.Write(Chr(12))
                Filewrite.Close()
                If gPrint = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile1(VFilePath)
                End If
            Else
                MsgBox("There is No Record to View..", MsgBoxStyle.OKOnly, "View")
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid Billno :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        Finally
        End Try
    End Function
    Private Function PrintHeader(ByVal HEADING As String, ByVal fDATE As Date, ByVal tDate As Date)
        Dim I As Integer
        Dim sstring As String
        Try
            '''*********************************************** PRINT REPORTS HEADING  *********************************'''
            Filewrite.Write(Chr(18) & Chr(27) + "E" & Chr(27) + "F")
            Filewrite.WriteLine("{0,23}{1,20}{2,11}{3,25}", "", gUsername, " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HEADING), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HEADING)), "-"), 1, 30))
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            Filewrite.WriteLine("{0,-30}{1,-30}", "From : " & Format(mskFromDate.Value, "MMM dd,yyyy"), "To :             " & Format(mskToDate.Value, "MMM dd,yyyy"))
            Filewrite.Write(Chr(18))
            Filewrite.WriteLine(StrDup(104, "-"))
            sstring = "KOTDATE     KOTNO                 MS.NO              ITEMCODE    ITEMDESCRIPTION              SCODE  USER   "
            Filewrite.WriteLine(sstring)
            Filewrite.WriteLine(StrDup(104, "-"))

            '''*********************************************** COMPLETE PRINT REPORTS HEADING  *********************************'''
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    'Private Function PrintHeader(ByVal HEADING As String, ByVal fDATE As Date, ByVal tDate As Date)
    '    Dim I As Integer
    '    Dim sstring As String
    '    Try
    '        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
    '        Filewrite.Write(Chr(18) & Chr(27) + "E" & Chr(27) + "F")
    '        Filewrite.WriteLine("{0,23}{1,20}{2,11}{3,25}", "", gUsername, " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
    '        Filewrite.Write(Chr(15))
    '        Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
    '        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HEADING), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
    '        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HEADING)), "-"), 1, 30))
    '        Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
    '        Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
    '        Filewrite.WriteLine("{0,-30}{1,-30}", "From : " & Format(mskFromDate.Value, "MMM dd,yyyy"), "To : " & Format(mskToDate.Value, "MMM dd,yyyy"))
    '        Filewrite.Write(Chr(18))
    '        Filewrite.WriteLine(StrDup(79, "-"))
    '        sstring = "KOTDATE     KOTNO            ITEMCODE ITEMDESCRIPTION            SCODE  USER   "
    '        Filewrite.WriteLine(sstring)
    '        Filewrite.WriteLine(StrDup(79, "-"))

    '        '''*********************************************** COMPLETE PRINT REPORTS HEADING  *********************************'''
    '    Catch ex As Exception
    '        Exit Function
    '    End Try
    'End Function

    Private Sub frmCancelItemRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPOS()
        FillCATEGORY()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CATERING"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))
        mskFromDate.Value = Now.Today
        mskToDate.Value = Now.Today
    End Sub
    Private Sub FillCATEGORY()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        lstcategory.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT CATEGORY FROM ITEMMaster "
        gconnection.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    lstcategory.Items.Add(Trim(.Item("CATEGORY")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub
    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        gPrint = False
        Call printoperation()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        gPrint = True
        Dim CODEPOS() As String
        Dim rowcount, TotalDoc As Integer
        Dim i As Integer
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptcan_item
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * FROM can_item WHERE"
        sqlstring = sqlstring & " cast(convert(varchar(11),KOTDATE,6)as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        For i = 0 To LstPOS.CheckedItems.Count - 1
            CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
            SSQL = SSQL & " '" & CODEPOS(0) & "', "
        Next
        SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        SSQL = SSQL & ")"


        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        sqlstring = sqlstring & "ORDER BY KOTDATE"

        Call Viewer.GetDetails(sqlstring, "can_item", r)
        Viewer.TableName = "can_item"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text7")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

        Viewer.Show()
    End Sub
    Private Sub frmCancelItemRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F8 Then
            If CmdPrint.Enabled = True Then
                Call cmdPrint_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call cmdcry_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call cmdexport_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdExit_Click(sender, e)
        End If
    End Sub
    Private Sub FillPOS()   '''***************************** To fill POS details from POSMaster  *****************'''
        LstPOS.Items.Clear()
        Dim i As Integer
        ssql = "SELECT DISTINCT poscode,posdesc FROM PosMaster "
        gconnection.getDataSet(ssql, "Pos")
        If gdataset.Tables("Pos").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("Pos").Rows.Count - 1
                With gdataset.Tables("Pos").Rows(i)
                    'LstPOS.Items.Add(Trim(.Item("POSdesc")))
                    LstPOS.Items.Add(Trim(.Item("poscode") & "-->" & .Item("posdesc")))
                End With
            Next i
        End If
        LstPOS.Sorted = True
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        LstPOS.Items.Clear()
        lstcategory.Items.Clear()
        lstcategory.Items.Add(Trim("CATERING"))
        lstcategory.Items.Add(Trim("BAR"))
        lstcategory.Items.Add(Trim("FACILITY"))
        Chk_SelectAllPos.Checked = False
        Chk_SelectAllCategory.Checked = False
        Call FillPOS()
        mskFromDate.Value = Now.Today
        mskToDate.Value = Now.Today
    End Sub

    Private Sub Chk_SelectAllPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPos.CheckedChanged, CheckBox1.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPos.Checked = True Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllCategory.CheckedChanged, CheckBox2.CheckedChanged
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
        End If
        If e.KeyCode = Keys.F3 Then
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
        End If
        If e.KeyCode = Keys.F3 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        If Me.chkbill.Checked = True Then
            Call cancelbillEXCEL()
        ElseIf chk_it.Checked = True Then
            Call cancelitemEXCEL()
        End If
    End Sub
    Private Sub cancelbillEXCEL()
        Dim CODEPOS() As String
        Dim rowcount, TotalDoc As Integer
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, SSQL As String
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = " SELECT * FROM can_bill WHERE"
        sqlstring = sqlstring & " cast(convert(varchar(11),kotdate1,6)as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        For i = 0 To LstPOS.CheckedItems.Count - 1
            CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
            SSQL = SSQL & " '" & CODEPOS(0) & "', "
        Next
        SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        SSQL = SSQL & ")"


        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        sqlstring = sqlstring & "ORDER BY KOTDATE1"
        gconnection.getDataSet(sqlstring, "CANBILL")
        If gdataset.Tables("CANBILL").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "CANCEL BILL " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cancelitemEXCEL()
        Dim CODEPOS() As String

        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, SSQL As String
       
        sqlstring = " SELECT * FROM can_item WHERE"
        sqlstring = sqlstring & " cast(convert(varchar(11),KOTDATE1,6)as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        For i = 0 To LstPOS.CheckedItems.Count - 1
            CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
            SSQL = SSQL & " '" & CODEPOS(0) & "', "
        Next
        SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        SSQL = SSQL & ")"


        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        sqlstring = sqlstring & "ORDER BY KOTDATE1"
        gconnection.getDataSet(sqlstring, "CANCELITEM")
        If gdataset.Tables("CANCELITEM").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "CANCEL ITEM  " & Format(mskFromDate.Value, "dd-MMM-yyyy") & "   TO   " & Format(mskToDate.Value, "dd-MMM-yyyy"), "")

        Else
            MessageBox.Show("NO RECORDS FOUND", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_Exporttoexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exporttoexcel.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "posmaster"
        sqlstring = "select * from posmaster order by poscode"
        Call _export.export_excel(sqlstring)
        _export.Show()
    End Sub

    Private Sub cmdcry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcry.Click

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

        If Me.chkbill.Checked = True Then
            Call cancelbill()
        ElseIf chk_it.Checked = True Then
            Call cancelitem()
        End If
    End Sub
    Private Sub cancelitem()
        Dim CODEPOS() As String

        Dim i As Integer
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptcan_item
       
        sqlstring = " SELECT * FROM can_item WHERE"
        sqlstring = sqlstring & " cast(convert(varchar(11),KOTDATE1,6)as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        For i = 0 To LstPOS.CheckedItems.Count - 1
            CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
            SSQL = SSQL & " '" & CODEPOS(0) & "', "
        Next
        SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        SSQL = SSQL & ")"


        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        sqlstring = sqlstring & "ORDER BY MNAME,KOTDATE1"

        Call Viewer.GetDetails(sqlstring, "can_item", r)
        Viewer.TableName = "can_item"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text7")
        TXTOBJ1.Text = gCompanyname

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

        Viewer.Show()
    End Sub
    Private Sub cancelbill()
        Dim CODEPOS() As String

        Dim i As Integer
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New canbill
       
        sqlstring = " SELECT * FROM can_bill WHERE"
        sqlstring = sqlstring & " cast(convert(varchar(11),kotdate1,6)as datetime) BETWEEN '"
        sqlstring = sqlstring & Format(mskFromDate.Value, "yyyy-MM-dd") & "' AND '" & Format(mskToDate.Value, "yyyy-MM-dd") & "'"
        For i = 0 To LstPOS.CheckedItems.Count - 1
            CODEPOS = Split(LstPOS.CheckedItems(i), "-->")
            SSQL = SSQL & " '" & CODEPOS(0) & "', "
        Next
        SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        SSQL = SSQL & ")"


        If lstcategory.CheckedItems.Count <> 0 Then
            SSQL = SSQL & " and CATEGORY in ("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                SSQL = SSQL & " '" & lstcategory.CheckedItems(i) & "', "
            Next
            SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            SSQL = SSQL & ")"
        End If

        sqlstring = sqlstring & "ORDER BY KOTDATE1"

        Call Viewer.GetDetails(sqlstring, "can_bill", r)
        Viewer.TableName = "can_bill"
        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text7")
        'TXTOBJ1.Text = gCompanyname

        'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ16.Text = "Period From  " & Format(mskFromDate.Value, "dd/MM/yyyy") & "  To " & " " & Format(mskToDate.Value, "dd/MM/yyyy") & ""

        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text3")
        'TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

        Viewer.Show()
    End Sub

    Private Sub chk_it_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_it.CheckedChanged
        If chk_it.Checked = True Then
            chkbill().Checked = False
        End If

    End Sub

    Private Sub chkbill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbill.CheckedChanged
        If chkbill.Checked = True Then
            chk_it.Checked = False
        End If
    End Sub
End Class
