Imports System.Data.SqlClient
Public Class SETTLEMENT
    Inherits System.Windows.Forms.Form
    Dim GCONN As New GlobalClass
    Dim I, J, K As Integer
    Dim TOTALAMOUNT As Double
    Dim lBOOKINGNO As String
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Dim lpartydate As Date

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal BOOKINGNO, ByVal partydate)
        MyBase.New()

        lBOOKINGNO = BOOKINGNO
        lpartydate = partydate
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
    Friend WithEvents TXT_AUDIT As System.Windows.Forms.Button
    Friend WithEvents SSGRID1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_POST As System.Windows.Forms.Button
    Friend WithEvents SSGRID_ACC As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TXT_Debit As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Credit As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SETTLEMENT))
        Me.SSGRID1 = New AxFPSpreadADO.AxfpSpread()
        Me.TXT_Debit = New System.Windows.Forms.TextBox()
        Me.TXT_Credit = New System.Windows.Forms.TextBox()
        Me.TXT_AUDIT = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CMD_POST = New System.Windows.Forms.Button()
        Me.SSGRID_ACC = New AxFPSpreadADO.AxfpSpread()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SSGRID_ACC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SSGRID1
        '
        Me.SSGRID1.DataSource = Nothing
        Me.SSGRID1.Location = New System.Drawing.Point(222, 121)
        Me.SSGRID1.Name = "SSGRID1"
        Me.SSGRID1.OcxState = CType(resources.GetObject("SSGRID1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID1.Size = New System.Drawing.Size(599, 240)
        Me.SSGRID1.TabIndex = 0
        '
        'TXT_Debit
        '
        Me.TXT_Debit.Location = New System.Drawing.Point(461, 366)
        Me.TXT_Debit.Name = "TXT_Debit"
        Me.TXT_Debit.Size = New System.Drawing.Size(112, 20)
        Me.TXT_Debit.TabIndex = 1
        Me.TXT_Debit.Text = "0.00"
        '
        'TXT_Credit
        '
        Me.TXT_Credit.Location = New System.Drawing.Point(581, 366)
        Me.TXT_Credit.Name = "TXT_Credit"
        Me.TXT_Credit.Size = New System.Drawing.Size(112, 20)
        Me.TXT_Credit.TabIndex = 2
        Me.TXT_Credit.Text = "0.00"
        '
        'TXT_AUDIT
        '
        Me.TXT_AUDIT.BackColor = System.Drawing.Color.Transparent
        Me.TXT_AUDIT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TXT_AUDIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_AUDIT.ForeColor = System.Drawing.Color.White
        Me.TXT_AUDIT.Image = CType(resources.GetObject("TXT_AUDIT.Image"), System.Drawing.Image)
        Me.TXT_AUDIT.Location = New System.Drawing.Point(372, 398)
        Me.TXT_AUDIT.Name = "TXT_AUDIT"
        Me.TXT_AUDIT.Size = New System.Drawing.Size(112, 32)
        Me.TXT_AUDIT.TabIndex = 856
        Me.TXT_AUDIT.Text = "AUDIT_TRIAL"
        Me.TXT_AUDIT.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.CMD_POST)
        Me.GroupBox1.Controls.Add(Me.SSGRID_ACC)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(211, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 396)
        Me.GroupBox1.TabIndex = 857
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(406, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 32)
        Me.Button2.TabIndex = 859
        Me.Button2.Text = "EXIT"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CMD_POST
        '
        Me.CMD_POST.BackColor = System.Drawing.Color.Transparent
        Me.CMD_POST.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_POST.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_POST.ForeColor = System.Drawing.Color.White
        Me.CMD_POST.Image = CType(resources.GetObject("CMD_POST.Image"), System.Drawing.Image)
        Me.CMD_POST.Location = New System.Drawing.Point(134, 336)
        Me.CMD_POST.Name = "CMD_POST"
        Me.CMD_POST.Size = New System.Drawing.Size(112, 39)
        Me.CMD_POST.TabIndex = 857
        Me.CMD_POST.Text = "POST TO ACCOUNTS"
        Me.CMD_POST.UseVisualStyleBackColor = False
        '
        'SSGRID_ACC
        '
        Me.SSGRID_ACC.DataSource = Nothing
        Me.SSGRID_ACC.Location = New System.Drawing.Point(11, 17)
        Me.SSGRID_ACC.Name = "SSGRID_ACC"
        Me.SSGRID_ACC.OcxState = CType(resources.GetObject("SSGRID_ACC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_ACC.Size = New System.Drawing.Size(633, 304)
        Me.SSGRID_ACC.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(270, 338)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 32)
        Me.Button3.TabIndex = 859
        Me.Button3.Text = "VIEW"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(516, 401)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 32)
        Me.Button1.TabIndex = 858
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(212, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(485, 283)
        Me.GroupBox2.TabIndex = 859
        Me.GroupBox2.TabStop = False
        '
        'SETTLEMENT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SSGRID1)
        Me.Controls.Add(Me.TXT_AUDIT)
        Me.Controls.Add(Me.TXT_Credit)
        Me.Controls.Add(Me.TXT_Debit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "SETTLEMENT"
        Me.Text = "SETTLEMENT"
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.SSGRID_ACC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub SETTLEMENT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        GroupBox2.Controls.Add(SSGRID1)
        SSGRID1.Location = New Point(5, 13)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
    End Sub
    Public Sub GETDATA(ByVal SSQL As String, ByVal NUMBER As String)
        TOTALAMOUNT = 0
        BOOKINGNO = NUMBER
        GCONN.getDataSet(SSQL, "ACCAUDIT")
        If gdataset.Tables("ACCAUDIT").Rows.Count > 0 Then

            With SSGRID1
                For I = 0 To gdataset.Tables("ACCAUDIT").Rows.Count - 1
                    .Row = I + 1
                    .Col = 1
                    .Text = gdataset.Tables("ACCAUDIT").Rows(I).Item("ACCODE")
                    .Col = 2
                    .Text = gdataset.Tables("ACCAUDIT").Rows(I).Item("slcode")
                    .Col = 3
                    .Text = gdataset.Tables("ACCAUDIT").Rows(I).Item("COSTCODE")
                    .Col = 4
                    .Text = gdataset.Tables("ACCAUDIT").Rows(I).Item("DEBIT")
                    .Col = 5
                    .Text = gdataset.Tables("ACCAUDIT").Rows(I).Item("CREDIT")
                Next
            End With

            If gdataset.Tables("ACCAUDIT").Rows(0).Item("POSTFLAG") = "Y" Then
                TXT_AUDIT.Visible = False
                CMD_POST.Visible = False
            Else
                TXT_AUDIT.Visible = True
                CMD_POST.Visible = True
            End If
            Call CALCULATE()

            TOTALAMOUNT = Format(Val(TXT_Debit.Text) - Val(TXT_Credit.Text), "0.00")
            SSGRID1.SetActiveCell(4, 1)

        End If
    End Sub
    Private Sub CALCULATE()
        Dim debit, credit As Double
        debit = 0
        credit = 0

        With SSGRID1
            For I = 0 To SSGRID1.DataRowCnt - 1
                .Row = I + 1
                .Col = 4
                debit = debit + Val(.Text)
                .Col = 5
                credit = credit + Val(.Text)
            Next
        End With
        Me.TXT_Debit.Text = Format(Val(debit), "0.00")
        Me.TXT_Credit.Text = Format(Val(credit), "0.00")
    End Sub

    'Private Sub SSGRID1_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID1.KeyDownEvent

    '    With SSGRID1
    '        J = .ActiveRow
    '        K = .ActiveCol
    '        If e.keyCode = Keys.Enter Then
    '            If .ActiveCol = 1 Then
    '                .Row = J
    '                .Col = 1
    '                If .Text = "" Then
    '                    Call FillBOOKING()
    '                Else
    '                    .SetActiveCell(J, 2)
    '                End If
    '            End If
    '            'If .ActiveCol = 2 Then
    '            '    .Row = .ActiveRow
    '            '    .Col = 2
    '            '    If .Text = "" Then
    '            '        Call FillBOOKING()
    '            '    Else
    '            '        .SetActiveCell(.ActiveRow, 3)
    '            '    End If
    '            'End If
    '            If .ActiveCol = 3 Then
    '                .Row = J
    '                .Col = 3
    '                If .Text = "" Then
    '                    Call FillMenu()
    '                Else
    '                    .SetActiveCell(J, 4)
    '                End If
    '            End If
    '            If .ActiveCol = 4 Then
    '                .Row = J
    '                .Col = 4
    '                If .Text = "" Then
    '                    .Text = "0.00"
    '                Else
    '                    .SetActiveCell(J, 5)
    '                End If
    '            End If
    '            If .ActiveCol = 5 Then
    '                .Row = J
    '                .Col = 5
    '                If .Text = "" Then
    '                    .Text = "0.00"
    '                Else
    '                    .SetActiveCell(J, 6)
    '                End If
    '            End If
    '            If .ActiveCol = 6 Then
    '                .Row = J
    '                .Col = 6
    '                If .Text = "" Then
    '                    .Text = "0.00"
    '                Else
    '                    .SetActiveCell(J, 7)
    '                End If
    '            End If
    '            If .ActiveCol = 7 Then
    '                .Row = J
    '                .Col = 7
    '                If .Text = "" Then
    '                    .Text = "0.00"
    '                Else
    '                    .SetActiveCell(J + 1, 1)
    '                End If
    '            End If
    '            Call CALCULATE()
    '            SSGRID1.SetActiveCell(K, J)

    '        ElseIf e.keyCode = Keys.F3 Then
    '            .DeleteRows(J, 1)
    '            .SetActiveCell(1, J)
    '            .Focus()
    '        End If

    '    End With



    'End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select accode,acdesc from accountsglaccountmaster "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(Search) = " " Then
            M_WhereCondition = "WHERE   category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y'"
        Else
            M_WhereCondition = " WHERE (accode LIKE '%" & Search & "%' OR acdesc LIKE '%" & Search & "%')  and  ISNULL(FREEZEFLAG,'') <>'Y' "
        End If
        vform.Field = "ACDESC,ACCODE"
        ''vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ITEM CODE HELP"
        ''vform.KeyPos = 0
        ''vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID1
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield & ">" & vform.keyfield1
                '.Col = 5
                '.Row = .ActiveRow
                '.Text = vform.keyfield1

            End With
        Else
            SSGRID1.SetActiveCell(0, SSGRID1.ActiveRow)
            Exit Sub
        End If
    End Sub
    Private Sub FillBOOKING()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select BOOKINGNO,PARTYDATE from PARTY_HDR "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(Search) = " " Then
            M_WhereCondition = "WHERE  BOOKINGTYPE='BILLING' "
        Else
            M_WhereCondition = " WHERE (BOOKINGNO LIKE '%" & Search & "%' OR PARTYDATE LIKE '%" & Search & "%') AND BOOKINGTYPE='BILLING'  "
        End If
        vform.Field = "BOOKINGNO,PARTYDATE"
        ''vform.vFormatstring = "BOOKINGNO     |PARTYDATE                        "
        vform.vCaption = "BOOKING NO HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID1
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield
                '& ">" & vform.keyfield1
                .Col = 2
                .Row = .ActiveRow
                .Text = Format(vform.keyfield1, "dd/MM/yy")

            End With
        Else
            SSGRID1.SetActiveCell(0, SSGRID1.ActiveRow)
            Exit Sub
        End If
    End Sub

    Private Sub TXT_AUDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_AUDIT.Click
        Dim SSQL As String
        Dim TSPLIT() As String
        GroupBox1.Visible = True
        Call CALCULATE()
        If (Val(TXT_Debit.Text)) <> Val(TXT_Credit.Text) Then
            MsgBox("CREDIT DEBIT AMOUNT NOT MATCHING  ")
            Exit Sub
        End If
        'If TOTALAMOUNT <> (Val(TXT_Debit.Text)) Then
        '    MsgBox("SUM OF SETTLEMENT AMOUNT NOT MATCHING AS BILLING AMOUNT")
        '    Exit Sub
        'End If

        With SSGRID1
            For I = 0 To SSGRID1.DataRowCnt - 1
                .Row = I + 1
                .Col = 1
                If .Text = "" Then
                    MsgBox("BOOKINGNO CANNOT BE BLANK")
                    Exit Sub
                End If
                '.Col = 2
                'If .Text = "" Then
                '    MsgBox("PARTYDATE CANNOT BE BLANK")
                '    Exit Sub
                'End If
                .Col = 4
                If .Text = "" Then
                    MsgBox("ACCOUNTHEAD CANNOT BE BLANK")
                    Exit Sub
                End If
            Next
        End With
        SSQL = "DELETE FROM PARTY_ACC_POST WHERE BOOKINGNO='" & BOOKINGNO & "' AND ISNULL(POSTFLAG,'')<>'Y'"
        GCONN.dataOperation(6, SSQL, "RAU")
        With SSGRID1
            For I = 0 To SSGRID1.DataRowCnt - 1
                .Row = I + 1

                SSQL = "INSERT INTO PARTY_ACC_POST(BOOKINGNO ,PARTYDATE ,ACCOUNTCODE ,ACDESC ,slcode,sldesc,COSTCODE,TOTALAMOUNT ,CASHAMT,POSTFLAG) VALUES("

                SSQL = SSQL & "'" & lBOOKINGNO & "',"

                SSQL = SSQL & "'" & Format(lpartydate, "dd/MMM/yyyy") & "'"

                .Col = 1
                TSPLIT = Split(.Text, ">")

                SSQL = SSQL & ",'" & TSPLIT(0) & "'"
                SSQL = SSQL & ",'" & TSPLIT(1) & "'"

                .Col = 2
                If Trim(.Text) = "" Then
                    SSQL = SSQL & " ,''"
                Else
                    SSQL = SSQL & " ,'" & Trim(.Text) & "'"
                End If

                If Trim(.Text) = "" Then
                    SSQL = SSQL & " ,''"
                Else
                    SSQL = SSQL & " ,'" & Trim(.Text) & "'"
                End If

                .Col = 3
                If Trim(.Text) = "" Then
                    SSQL = SSQL & " ,''"
                Else
                    SSQL = SSQL & " ,'" & Trim(.Text) & "'"
                End If

                .Col = 4
                SSQL = SSQL & "," & Val(.Text) & ""
                .Col = 5
                SSQL = SSQL & " ," & Val(.Text) & ""

                SSQL = SSQL & ",'N')"

                GCONN.dataOperation(6, SSQL, "RAU")
            Next
        End With

        SSQL = "SELECT VOUCHERNO,VOUCHERTYPE,VOUCHERDATE,ACCODE,ACDESC,ISNULL(SLCODE,'') AS SLCODE ,COSTCODE,CREDITDEBIT, AMOUNT FROM PARTY_POSTINGVIEW WHERE BOOKINGNO='" & BOOKINGNO & "'"
        'SSQL = "SELECT VOUCHERNO,VOUCHERTYPE,VOUCHERDATE,ACCODE,ACDESC,ISNULL(SLCODE,'') AS SLCODE ,CREDITDEBIT, AMOUNT FROM PARTY_POSTINGVIEW WHERE BOOKINGNO='" & BOOKINGNO & "' and ACCODE<>''""
        GCONN.getDataSet(SSQL, "ACCAUDITF")
        If gdataset.Tables("ACCAUDITF").Rows.Count > 0 Then
            With SSGRID_ACC
                For I = 0 To gdataset.Tables("ACCAUDITF").Rows.Count - 1
                    .Row = I + 1
                    .Col = 1
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("VOUCHERNO")
                    .Col = 2
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("VOUCHERTYPE")

                    .Col = 3
                    .Text = Format(gdataset.Tables("ACCAUDITF").Rows(I).Item("VOUCHERDATE"), "dd/MM/yy")
                    .Col = 4
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("ACCODE")
                    .Col = 5
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("ACDESC")
                    .Col = 6
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("SLCODE")
                    .Col = 7
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("COSTCODE")

                    .Col = 8
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("CREDITDEBIT")

                    .Col = 9
                    .Text = gdataset.Tables("ACCAUDITF").Rows(I).Item("AMOUNT")

                Next
            End With
            'Call CALCULATE()
            'TOTALAMOUNT = Format(Val(TXT_TOTAL.Text), "0.00")
            'SSGRID1.SetActiveCell(4, 1)

        End If
    End Sub
    Private Sub CHECKVALIDATION()
        If (Val(TXT_Debit.Text)) <> Val(TXT_Credit.Text) Then
            MsgBox("CREDIT DEBIT AMOUNT NOT MATCHING AS BILLING DONE")
            Exit Sub
        End If
        'If TOTALAMOUNT <> (Val(TXT_Debit.Text)) Then
        '    MsgBox("SUM OF SETTLEMENT AMOUNT NOT MATCHING AS BILLING AMOUNT")
        '    Exit Sub
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CMD_POST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_POST.Click
        Dim SSQL, SSQL1 As String
        SSQL = " EXEC PARTY_POST '" & BOOKINGNO & "'"
        GCONN.dataOperation(6, SSQL, "RSPOST")
        SSQL = " UPDATE PARTY_ACC_POST SET POSTFLAG='Y' WHERE BOOKINGNO='" & BOOKINGNO & "'"
        GCONN.dataOperation(6, SSQL, "RSPOST")
        MsgBox("POSTED TO ACCOUNTS SUCCESSFULLY")
        CMD_POST.Visible = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
        If U = 1366 Then
            T = T - 55
        End If
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Panel" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then

                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox4" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 45
                            End If
                            If U = 1280 Then
                                L = L + 45
                            End If
                            If U = 1360 Then
                                L = L + 70
                            End If
                            If U = 1366 Then
                                L = L + 70
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TextBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is ComboBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is DateTimePicker Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is PictureBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is CheckBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TabControl Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Button Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Cmd_Clear" Or Controls(i_i).Name = "Cmd_Add" Or Controls(i_i).Name = "Cmd_Delete" Or Controls(i_i).Name = "Cmd_View" Or Controls(i_i).Name = "Cmd_Print" Or Controls(i_i).Name = "Cmd_Export" Or Controls(i_i).Name = "Cmd_Exit" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                        'L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub
End Class
