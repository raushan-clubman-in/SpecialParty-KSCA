Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_TKGA_FinalBilling
    Public STRPOSCODE, DOCTYPE, MainCode, lastpaymode As String
    Dim Amt, AMT1 As Double
    Dim POScode As String
    Dim i, J, K As Integer
    Public Billno() As String
    Dim LoadCount As Integer
    Dim strAccountIn, strSaleCostAccountIn, strSaleCostAccountInDesc, strBatchNo, strAccountDesc, STMcode As String
    Dim txt_creditfacility, SEC, strstring As String
    Dim BillDetails, CHKINNO As String
    Dim gconnection As New GlobalClass
    Dim DT As New DataSet
    Dim Sql, STran(0), PrintFlag, strSlDesc, strBillno, strPackCostAccountIn, strPackCostAccountInDesc As String
    Dim itembool, chkbool, smartcardbool As Boolean
    Dim KotDetails, BillMcode, BillMname, loccode, ssql, seccode, HNAME() As String
    Public dblBillTotalAmount, dblBillNonTotalAmount, dblBillTaxTotal, dblBillNonTaxtotal, gridRow, Jnltaxamount, Jnlamount, _Billamount As Double
    Public billstatus, BillTaxBillno, BillTaxBilldetails, BillNonTaxBilldetails, BillNonTaxBillno As String
    Dim duplicateflag As Boolean = False
    Dim servicelocation As String
    Public ACCPOST As Boolean
    Dim strPhotoFilePath, StrSql As String
    Public foto As New GlobalClass
    Public BALANCE_HDR As Double
    Public MIN_USAGE_BALANCE_HDR As Double
    Dim count As Integer = 1
    Dim GADDDATETIME As Date
    Dim boolchk As Boolean
    Dim POSBILLDET As String
    Dim gDocType As String

    Private Sub FRM_TKGA_FinalBilling_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            If Cmd_Delete.Enabled = True Then
                Call Cmd_Delete_Click(Cmd_Delete, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If Cmd_View.Enabled = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            If Cmd_Print.Enabled = True Then
                Call Cmd_Print_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F12 Then
            Call Cmd_Export_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.K Then
            Me.Txt_Remarks.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.S Then
            Me.txt_ServerCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.B Then
            Me.txt_MemberCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Me.cbo_PaymentMode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.G Then
            Me.sSGrid.Focus()
            Me.sSGrid.SetActiveCell(1, 1)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.txt_TableNo.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.L Then
            Me.CMB_BTYPE.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub FRM_TKGA_FinalBilling_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim LastDoctype As String
        gDocType = DOCTYPE
        LastDoctype = DOCTYPE
        Timer1.Enabled = False
        bselect = False
        LoadCount = 0
        If gCenterlized = "N" Then
            StrSql = "SELECT ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ,roundoffyesno,roundval FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
            gconnection.getDataSet(StrSql, "PSETUP")
            If gdataset.Tables("PSETUP").Rows.Count > 0 Then
                pTableReq = gdataset.Tables("PSETUP").Rows(0).Item("TABLEREQ")
                pKotType = gdataset.Tables("PSETUP").Rows(0).Item("KOTTYPE")
                pKotPrefix = gdataset.Tables("PSETUP").Rows(0).Item("FINALPREFIX")
                DefaultPayment = gdataset.Tables("PSETUP").Rows(0).Item("PAYMENTMODE")
                RoundYN = gdataset.Tables("PSETUP").Rows(0).Item("roundoffyesno")
                RndVal = gdataset.Tables("PSETUP").Rows(0).Item("roundval")
            End If
        End If
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_type.DropDownStyle = ComboBoxStyle.DropDownList
        'Call FillDefaultPayment()
        Call PaymentGridLocking()
        'Call FillBillPrefix()
        Call fillPayment_Mode()
        Call fillNPayment_Mode()
        Call fillposdocument()
        Call GridUnLocking()
        Call autogenerate()
        'Call ShowBillno()
        '        CMB_BTYPE.SelectedIndex = 0
        finalbillbool = True
        kotupdate = False
        itembool = False
        Me.Button3.Enabled = True
        KotDetails = ""
        cmb_type.Text = "CLUBMEMBER"
        '*******************SMART CARD START
        Dim ssqqll As String
        ssqqll = "SELECT  ISNULL(ACCESS_CHECK,'N') AS ACCESS_CHECK FROM SM_ACCESSCONTROL_MASTER"
        gconnection.getDataSet(ssqqll, "SM_ACCESSCONTROL_MASTER")
        If gdataset.Tables("SM_ACCESSCONTROL_MASTER").Rows.Count > 0 Then
            If Trim(gdataset.Tables("SM_ACCESSCONTROL_MASTER").Rows(0).Item("ACCESS_CHECK")) = "Y" Then
                ACCESS_CHECK_GBL = True
            Else
                ACCESS_CHECK_GBL = False
            End If
        End If
        If gCenterlized = "Y" Then
            Call Autogenerate()
        ElseIf gCenterlized = "N" Then
            Call Autogenerate()
            CMB_BTYPE.SelectedItem = DOCTYPE
        End If
        'Call fillNPayment_Mode()
        'cmd_BillSettlement.Enabled = False
        'cbo_Typeofcheque.SelectedIndex = 0
        cmd_BillSettlement.Enabled = False
        KOT_Timer.Enabled = True
        KOT_Timer.Interval = 100
        txt_BillAmount.ReadOnly = True
        cmd_BillNoHelp.Enabled = True
        grp_Paymentmodeselection.Top = 1000
        ssGrid.ClearRange(1, 1, -1, -1, True)
        lblCro1.Visible = False
        lblCro2.Visible = False
        'cbo_PaymentMode.Focus()
        Me.cmb_type.Focus()
        lblDeleted.Visible = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call SetDateTime()
        SYS_DATE_TIME()
        If gCenterlized = "Y" Then
            If Mid(gTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        Else
            If Mid(pTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        End If
        If Mid(gWaiterReq, 1, 1) = "Y" Then
            txt_ServerCode.ReadOnly = False
            txt_ServerName.ReadOnly = False
            cmd_ServerCodeHelp.Enabled = True
        Else
            txt_ServerCode.ReadOnly = True
            txt_ServerName.ReadOnly = True
            cmd_ServerCodeHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
        End If
        If gCenterlized = "Y" And Mid(gKotType, 1, 1) = "A" Then
        ElseIf gCenterlized = "N" And Mid(pKotType, 1, 1) = "A" Then
            CMB_BTYPE.SelectedItem = LastDoctype
        End If
        If FKot = "Y" Then
            cbo_PaymentMode.Text = Fkotpaymode
            txt_MemberCode.Text = FkotMcode
            txt_ServerCode.Text = Fkotscode
            txt_MemberCode_Validated(txt_MemberCode, e)
            If Fkotscode <> "" Then
                'txt_ServerCode_Validated(txt_ServerCode, e)
            End If
        End If
        FKot = "N"
        Fkotpaymode = DefaultPayment
        FkotMcode = ""
        Fkotscode = ""
        Me.Show()
        txt_MemberCode.Focus()
        '_Billamount = GetRoundVal(11.51)
    End Sub
    Private Sub SYS_DATE_TIME()
        Dim sqlstring, financalyear, Insert(0) As String
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                dtp_BillDate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
            End If
            'dtp_BillDate.Enabled = False
            'CMD_LOCK()
        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub fillposdocument()
        Dim sqlstring As String
        Dim i As Integer
        Try
            If gUserCategory = "S" Then
                sqlstring = " SELECT ISNULL(finalprefix,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(finalprefix,'') <> '' AND Isnull(Freeze,'N')='N' "
            Else
                sqlstring = "  SELECT ISNULL(finalprefix,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(finalprefix,'') <> '' AND Isnull(Freeze,'N')='N' and poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            End If
            CMB_BTYPE.Items.Clear()
            gconnection.getDataSet(sqlstring, "posdocument")
            If gdataset.Tables("posdocument").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("posdocument").Rows.Count - 1
                    CMB_BTYPE.Items.Add(gdataset.Tables("posdocument").Rows(i).Item("DOCTYPE"))
                Next i
                CMB_BTYPE.SelectedIndex = 0
            Else
                MessageBox.Show("Plz Enter various POS DOCUMENT into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Autogenerate()
        Dim sqlstring, financalyear As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            If gCenterlized = "Y" Then
                sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(BILLno,1,6) As Numeric)),0)  FROM BILL_HDR  WHERE BILLDETAILS LIKE '" & Trim(gDocType) & "%'"
            ElseIf gCenterlized = "N" Then
                sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(BILLno,1,6) As Numeric)),0)  FROM BILL_HDR  WHERE BILLDETAILS LIKE '" & Trim(DOCTYPE) & "%' "
            End If
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    If gCenterlized = "Y" Then
                        txt_BillNo.Text = gDocType & "/000001" & "/" & financalyear
                    Else
                        txt_BillNo.Text = DOCTYPE & "/000001" & "/" & financalyear
                    End If
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    If gCenterlized = "Y" Then
                        txt_BillNo.Text = gDocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    Else
                        txt_BillNo.Text = DOCTYPE & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    End If
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                If gCenterlized = "Y" Then
                    txt_BillNo.Text = gDocType & "/000001" & "/" & financalyear
                Else
                    txt_BillNo.Text = DOCTYPE & "/000001" & "/" & financalyear
                End If
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Function Autogenerate_Poswise(ByVal BILLPREF As String)
        Dim sqlstring, financalyear As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            If gCenterlized = "Y" Then
                sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(BILLno,1,6) As Numeric)),0)  FROM BILL_HDR  WHERE BILLDETAILS ='" & Trim(gDocType) & "%'"
            ElseIf gCenterlized = "N" Then
                sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(BILLno,1,6) As Numeric)),0)  FROM BILL_HDR  WHERE BILLDETAILS LIKE '" & Trim(BILLPREF) & "%' "
            End If
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    If gCenterlized = "Y" Then
                        txt_BillNo.Text = gDocType & "/000001" & "/" & financalyear
                    Else
                        POSBILLDET = BILLPREF & "/000001" & "/" & financalyear
                    End If
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    If gCenterlized = "Y" Then
                        txt_BillNo.Text = gDocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    Else
                        POSBILLDET = BILLPREF & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    End If
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                If gCenterlized = "Y" Then
                    txt_BillNo.Text = gDocType & "/000001" & "/" & financalyear
                Else
                    POSBILLDET = BILLPREF & "/000001" & "/" & financalyear
                End If
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Function
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
        Return POSBILLDET
    End Function
    Private Sub GridLocking()
        Dim Row, Col As Integer
        ssGrid.Col = 15
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 5
                ssGrid.Row = Row
                ssGrid.Col = 4
                ssGrid.Lock = True
            Next
        Next Row
    End Sub
    Private Sub PaymentGridLocking()
        Dim Row, Col As Integer
        ssgridPayment1.Col = 6
        ssgridPayment1.Row = ssgridPayment1.ActiveRow
        For Row = 1 To 20
            For Col = 3 To 4
                ssgridPayment1.Row = Row
                ssgridPayment1.Col = Col
                ssgridPayment1.Lock = True
            Next
        Next Row
        ssgridPayment1.Row = 1
        For Col = 3 To 4
            ssgridPayment1.Col = Col
            ssgridPayment1.Lock = False
        Next
    End Sub
    Private Sub GridUnLocking()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 5
                ssGrid.Col = 4
                ssGrid.Row = i
                ssGrid.Lock = False
            Next j
        Next i
    End Sub
    Private Sub fillPayment_Mode()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' and isnull(kot,'')='YES'"
            cbo_PaymentMode.Items.Clear()
            gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    cbo_PaymentMode.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("Paymentcode"))
                Next i
                'index = cbo_PaymentMode.FindString(DefaultPayment)
                'cbo_PaymentMode.SelectedIndex = index
                If LoadCount = 0 Then
                    index = cbo_PaymentMode.FindString(DefaultPayment)
                    cbo_PaymentMode.SelectedIndex = index
                Else
                    index = cbo_PaymentMode.FindString(lastpaymode)
                    cbo_PaymentMode.SelectedIndex = index
                End If
                Call FillSubPaymentMode(DefaultPayment)
            Else
                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillSubPaymentMode(ByVal Paymode As String)
        Dim sql As String
        Dim i As Integer
        Dim dt As New DataTable
        sql = "SELECT ISNULL(SUBPAYSTATUS,'') AS SUBPAYSTATUS FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(Paymode) & "'and isnull(kot,'')='YES'"
        gconnection.getDataSet(sql, "PAYMENTMODEMASTER")
        If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
            If gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("SUBPAYSTATUS") = "YES" Then
                sql = "SELECT subpaymentcode + '-' + SubPaymentname FROM SubpaymentMode WHERE Paymentcode='" & Trim(Paymode) & "' AND ISNULL(Freeze,'')<>'Y'"
                Me.cbo_SubPaymentMode.Items.Clear()
                dt = gconnection.GetValues(sql)
                If dt.Rows.Count > 0 Then
                    Me.cbo_SubPaymentMode.Visible = True
                    lbl_SubPaymentMode.Visible = True
                    For i = 0 To dt.Rows.Count - 1
                        Me.cbo_SubPaymentMode.Items.Add(dt.Rows(i).Item(0))
                    Next i
                    Me.cbo_PaymentMode.Focus()
                    Me.cbo_SubPaymentMode.SelectedIndex = 0
                Else
                    cbo_SubPaymentMode.Visible = False
                    lbl_SubPaymentMode.Visible = False
                End If
            Else
                cbo_SubPaymentMode.Visible = False
                lbl_SubPaymentMode.Visible = False
            End If
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.cmd_Delete.Enabled = False
        Me.cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.cmd_Delete.Enabled = True
                    Me.cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Function SetDateTime()
        If Val(Now.Hour) >= 0 And Val(Now.Hour) <= 5 Then
            dtp_BillDate.Value = DateAdd(DateInterval.Day, -1, Now)
            KOT_Timer.Enabled = False
            Select Case Val(Now.Hour)
                Case 1
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-65 - Now.Minute), Now).ToLongTimeString
                Case 2
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-125 - Now.Minute), Now).ToLongTimeString
                Case 3
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-185 - Now.Minute), Now).ToLongTimeString
                Case 4
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-245 - Now.Minute), Now).ToLongTimeString
                Case 5
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-305 - Now.Minute), Now).ToLongTimeString
                Case 0
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-5 - Now.Minute), Now).ToLongTimeString
            End Select
        Else
            KOT_Timer.Enabled = True
            txt_KOTTime.Text = Now.ToLongTimeString
            'dtp_KOTdate.Value = Now.Date
            'dtp_KOTdate.Value = Now.ToLongDateString
            'Now.ToLongDateString()

        End If
        'txt_TableNo.Focus()
        cbo_PaymentMode.Focus()
    End Function
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub cbo_PaymentMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_PaymentMode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cbo_SubPaymentMode.Visible = True Then
                cbo_SubPaymentMode.Focus()
            ElseIf txt_MemberCode.Visible = True Then

                If txt_TableNo.Text = "" And txt_TableNo.ReadOnly = False Then
                    txt_TableNo.Focus()
                Else
                    txt_MemberCode.Focus()
                End If
            Else
                If txt_TableNo.Text = "" Then
                    txt_TableNo.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cbo_PaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_PaymentMode.SelectedIndexChanged
        Dim sqlstring As String
        'CSC SMARTCARD
        Try
            Call CloseSmartDevicePort()
            PAYMENTMODE_GBL = cbo_PaymentMode.Text
            lastpaymode = cbo_PaymentMode.Text
            ordertype = " "
            lbl_Membercode.Text = "Member Code"
            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE FROM PAYMENTMODEMASTER "
            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) <> "SMART CARD" Then
                    If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("SMARTVALIDATE")).ToUpper() <> "YES" Then
                        lbl_SwipeCard.Visible = False
                        txt_card_id.Visible = False
                        Label3.Visible = False
                        Label4.Visible = False
                        txt_Holder_Code.Visible = False
                        Txt_holder_name.Visible = False
                        txt_card_id.Text = ""
                        txt_Holder_Code.Text = ""
                        Txt_holder_name.Text = ""

                        txt_MemberName.Enabled = True
                        txt_MemberCode.Enabled = True
                        cmd_MemberCodeHelp.Enabled = True
                        lbl_Membercode.Visible = True
                        txt_MemberName.Text = ""
                        txt_MemberCode.Text = ""
                        txt_MemberName.ReadOnly = False
                        txt_MemberCode.ReadOnly = False

                        txt_MemberName.Visible = True
                        txt_MemberCode.Visible = True
                        cmd_MemberCodeHelp.Visible = True
                        lbl_Membercode.Visible = True
                        Timer1.Enabled = False
                        Pic_Member.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                    Else
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Visible = True
                        txt_card_id.Text = ""
                        Timer1.Enabled = True
                        Label3.Visible = True
                        Label4.Visible = True
                        txt_Holder_Code.Visible = True
                        Txt_holder_name.Visible = True
                        txt_Holder_Code.Enabled = True
                        Txt_holder_name.Enabled = True
                        txt_MemberCode.Enabled = False
                        txt_MemberName.Enabled = False

                        'txt_Holder_Code.Enabled = False
                        cmd_MemberCodeHelp.Enabled = False
                        Txt_holder_name.Enabled = False

                        lbl_SubPaymentMode.Visible = False
                        cbo_SubPaymentMode.Visible = False
                        cmd_MemberCodeHelp.Visible = False

                        '***************** CSC SMARTCARD

                        txt_MemberCode.ReadOnly = True
                        txt_MemberName.ReadOnly = True
                        cmd_MemberCodeHelp.Visible = False


                        txt_MemberName.Text = ""
                        txt_MemberCode.Text = ""
                        txt_Holder_Code.Text = ""
                        Txt_holder_name.Text = ""

                        txt_MemberCode.Text = MCODE_GBL
                        txt_MemberName.Text = MNAME_GBL


                        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                            '*****************'CSC SMARTCARD
                            txt_MemberCode.Text = MCODE_GBL
                            txt_MemberName.Text = MNAME_GBL
                        End If

                        cmd_MemberCodeHelp.Visible = False
                        lbl_Membercode.Text = "MEMBER CODE :"
                        sqlstring = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                        sqlstring = sqlstring & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                        gconnection.getDataSet(sqlstring, "SM_MEM_LINKAGE")
                        'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                        Call CardIdValidate(Trim(txt_card_id.Text))
                        If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                            cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                        ElseIf Cardidcheck = True Then
                            cardcode = Trim(vCardcode)
                            vCardcode = ""
                        Else
                            If Me.txt_card_id.Text <> "" Then
                                MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            lbl_SwipeCard.Visible = True
                            txt_card_id.Clear()
                            cbo_PaymentMode.Focus()
                            Exit Sub
                        End If

                        sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                        sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                        sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                        gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                        If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                            If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                                gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                                If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                    Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "CLUBMEMBER"
                                End If
                            ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                                lbl_Membercode.Text = "AFF CLUB CODE   :"
                                'ordertype = "AFFMEMBER"
                                gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                                If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "AFFMEMBER"
                                End If
                            ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                                lbl_Membercode.Text = "EMP CODE   :"

                                gconnection.getDataSet("SELECT MNAME AS CLUBNAME  FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                                If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "EMPMEMBER"
                                End If
                            End If
                        End If
                    End If


                Else
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Visible = True
                    txt_card_id.Text = ""
                    Timer1.Enabled = True
                    Label3.Visible = True
                    Label4.Visible = True
                    txt_Holder_Code.Visible = True
                    Txt_holder_name.Visible = True

                    txt_MemberCode.Enabled = False
                    txt_MemberName.Enabled = False
                    Txt_holder_name.Visible = True
                    txt_Holder_Code.Enabled = True

                    Txt_holder_name.Enabled = False

                    lbl_SubPaymentMode.Visible = False
                    cbo_SubPaymentMode.Visible = False
                    cmd_MemberCodeHelp.Visible = False

                    '***************** CSC SMARTCARD

                    txt_MemberCode.ReadOnly = True
                    txt_MemberName.ReadOnly = True
                    cmd_MemberCodeHelp.Visible = False


                    txt_MemberName.Text = ""
                    txt_MemberCode.Text = ""
                    txt_Holder_Code.Text = ""
                    Txt_holder_name.Text = ""

                    txt_MemberCode.Text = MCODE_GBL
                    txt_MemberName.Text = MNAME_GBL


                    If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                        '*****************'CSC SMARTCARD
                        txt_MemberCode.Text = MCODE_GBL
                        txt_MemberName.Text = MNAME_GBL
                    End If

                    cmd_MemberCodeHelp.Visible = False
                    lbl_Membercode.Text = "MEMBER CODE :"
                    sqlstring = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                    sqlstring = sqlstring & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                    gconnection.getDataSet(sqlstring, "SM_MEM_LINKAGE")
                    'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                    Call CardIdValidate(Trim(txt_card_id.Text))
                    If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                        cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                    ElseIf Cardidcheck = True Then
                        cardcode = Trim(vCardcode)
                        vCardcode = ""
                    Else
                        If Me.txt_card_id.Text <> "" Then
                            MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Clear()
                        cbo_PaymentMode.Focus()
                        Exit Sub
                    End If

                    sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                    sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                    sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                    gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                    If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                        If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                            gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                            If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "CLUBMEMBER"
                            End If
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                            lbl_Membercode.Text = "CLUB CODE   :"
                            gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                            If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "AFFMEMBER"
                            End If
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                            lbl_Membercode.Text = "EMP CODE   :"
                            gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                            If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "EMPMEMBER"
                            End If
                        End If
                    End If
                End If
            Else
                MsgBox("Please select a valid payment mode.........")
                cbo_PaymentMode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Call FillSubPaymentMode(Trim(Me.cbo_PaymentMode.Text))
    End Sub
    Private Sub txt_MemberCode_GotFocus(sender As Object, e As EventArgs) Handles txt_MemberCode.GotFocus
        If txt_card_id.Text = "" And cbo_PaymentMode.Text = "SMART CARD" Then
            txt_card_id.Focus()
        Else
        End If
    End Sub
    Private Sub txt_card_id_GotFocus(sender As Object, e As EventArgs) Handles txt_card_id.GotFocus
        If gReaderType_code = 2 Then
            'If cardprent = False Then
            Call GetSMARTDEVICEPORT()
            Timer1.Enabled = True
            'Else
            '    txt_MemberCode.Focus()
            'End If

        ElseIf gReaderType_code = 3 Then
            If Trim(txt_card_id.Text) = "" Then
                Call GetSMART_CARDID()
            End If
        End If
    End Sub
    Private Sub txt_card_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_card_id.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                Call txt_card_id_Validated(txt_card_id, e)
            Else
                MsgBox("SELECT CORRECT PAYMENTMODE", MsgBoxStyle.Information)
                txt_card_id.Text = ""
                cbo_PaymentMode.Focus()
            End If
        End If
    End Sub
    Private Sub txt_card_id_LostFocus(sender As Object, e As EventArgs) Handles txt_card_id.LostFocus
        If gReaderType_code = 2 Then
            Call CloseSmartDevicePort()
            If cardprent = True Then
                Me.txt_MemberCode.Focus()
            End If
        End If
    End Sub
    Private Sub txt_card_id_Validated(sender As Object, e As EventArgs) Handles txt_card_id.Validated
        Dim ssql, pay, valid As String
        ssql = "select MEMBERSTATUS ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(ssql, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            pay = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            valid = gdataset.Tables("PAY").Rows(0).Item("SMARTVALIDATE")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        Dim SQLSTRING As String
        If Trim(txt_card_id.Text) = "" And pay = "SMART CARD" Then
            ''''MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ''''lbl_SwipeCard.Visible = True
            ''''txt_card_id.Focus()
            ''''Exit Sub
        Else
            SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            SQLSTRING = SQLSTRING & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
            'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
            Call CardIdValidate(Trim(txt_card_id.Text))
            If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
            ElseIf Cardidcheck = True Then
                cardcode = Trim(vCardcode)
                vCardcode = ""
            Else
                If pay = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Focus()
                    Exit Sub
                End If
            End If

            SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "' "
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If txt_card_id.Text <> "" Then
                gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            End If
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    MessageBox.Show("Sorry!  Your Card Not Activated. " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                    lbl_SwipeCard.Focus()
                    Exit Sub
                End If
                'DISPLAY BALNACE AMOUNT
                BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE")), "0.00")
                'MIN_USAGE_BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MIN_USG_BALANCE")), "0.00")


            Else
                'MessageBox.Show("Sorry! CARD EXPIRED " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK)
            End If

            'Show PHOTOS
            If gFoto = "Y" Then
                gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            Else
                If gShortName = "MCC" Then
                    gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
                ElseIf gShortName = "NIZAM" Then
                    gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
                Else
                    gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
                End If
            End If
            If Trim(Me.txt_card_id.Text) <> "" Then
                Call DISPLAYINF()
            End If

            'End If
        End If
    End Sub
    Public Function DISPLAYINF()
        Try
            Dim sender As Object, e As System.EventArgs
            Dim SMARTDATE, DD, MM, YY As String
            Dim CARDDATE As Date
            Dim i As Integer
            Dim TT() As String
            bselect = True
            Dim sqlstring1, sqlstring2, SQLSTRING, subcode, mcode As String
            'CHECKING AND DISPLAYING RECORDS FROM SM_CARDFILE_HDR
            SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
            SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME,  ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
            SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = ""
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    If cbo_PaymentMode.Text = "SMART CARD" Then
                        MessageBox.Show("SORRY! CARD IS DEACTIVATED", "CARD DEACTIVATED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Function
                    End If
                End If
                Dim todate As DateTime
                todate = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("VALID_TO")
                If Date.Today > todate Then
                    MessageBox.Show("SORRY! CARD IS OUT OF VALIDITY DATE", "CARD EXPIRED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Function
                End If
                Dim ACCESS_CTL As String
                Dim strsql, STRSQL2 As String
                strsql = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & cardcode & "' AND POSCODE='" & STRPOSCODE & "'"
                gconnection.getDataSet(strsql, "SM_CARDFILE_DET")
                If gdataset.Tables("SM_CARDFILE_DET").Rows.Count > 0 Then
                    STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & STRPOSCODE & "'"
                    gconnection.getDataSet(STRSQL2, "POSMASTER")
                    If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
                        POSNAME_GBL = gdataset.Tables("POSMASTER").Rows(0).Item("POSDESC")
                    End If
                    ACCESS_CTL = gdataset.Tables("SM_CARDFILE_DET").Rows(0).Item("POS_ACCESS")
                    If ACCESS_CTL = "N" Then
                        MessageBox.Show("SORRY! YOU HAVE NO RIGHTS TO USE THE POS FACILITY", "ACCESS BLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Function
                    End If
                Else
                    MessageBox.Show(" PLEASE GET POS VALIDITY", "NO RIGHTS FOR POS USAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Function
                End If
                txt_MemberCode.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MEMBERCODE")
                MCODE_GBL = Trim(txt_MemberCode.Text)
                NAME_GBL = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("NAME")
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    gconnection.getDataSet("SELECT MNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM  EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "MEMBERMASTER")
                End If

                If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                    MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                    txt_MemberName.Text = MNAME_GBL
                Else

                End If
                'KARTHI JUNE 13
                'KARTHI JUNE 13
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    lbl_Membercode.Text = "CLUB CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE CLUBCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    lbl_Membercode.Text = "EMP  CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as EMPNAME FROM EMPLOYEEMASTER WHERE mcode='" & Trim(MCODE_GBL) & "'", "empdet")
                    If gdataset.Tables("empdet").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("empdet").Rows(0).Item("EMPNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    lbl_Membercode.Text = "ROOM NO     :"
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM")
                    If gdataset.Tables("ROOM").Rows.Count > 0 Then

                        MNAME_GBL = gdataset.Tables("ROOM").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                    TT = Split(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDCODE"), "-")
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE DOCNO='" & TT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM1")
                    If gdataset.Tables("ROOM1").Rows.Count > 0 Then
                    Else
                        MsgBox("SORRY USER GUEST CHECKED OUT U CAN NOT GENERATE KOT")
                        MNAME_GBL = ""
                        Me.txt_MemberCode.Text = ""
                        Me.txt_MemberName.Text = ""
                    End If

                End If
                txt_Holder_Code.Enabled = True
                cmd_MemberCodeHelp.Enabled = True
                txt_Holder_Code.ReadOnly = False
                'karthi jun2
                txt_Holder_Code.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("cardcode")
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    Dim CSPLIT() As String
                    CSPLIT = Split(Me.txt_Holder_Code.Text, "-")
                    SQLSTRING = "SELECT * FROM ROOMCHECKIN WHERE ISNULL(DOCNO,0)='" & CSPLIT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'"
                    gconnection.getDataSet(SQLSTRING, "RMC")
                    If gdataset.Tables("RMC").Rows.Count > 0 Then
                    Else
                        MsgBox("ROOM IS CHECKEDOUT U CANNOT USE THE CARD")
                        Me.txt_Holder_Code.Text = ""
                        Me.txt_MemberCode.Text = ""
                        Me.Cmd_Add.Enabled = False
                    End If
                End If
                Txt_holder_name.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDHOLDERNAME")
                lbl_SwipeCard.Visible = False
                '***********************************New addition for reading datefromcard block
                If ACCESS_CHECK_GBL = True Then
                    SQLSTRING = "SELECT CARDCODE FROM SM_MEMBERENTRY_LOG WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "' AND CAST(CONVERT(VARCHAR(11),DATETIME,6) AS DATETIME ) = '" & Format(Date.Now, "dd/MMM/yyyy") & "'"
                    gconnection.getDataSet(SQLSTRING, "SM_MEMBERENTRY_LOG")
                    If gdataset.Tables("SM_MEMBERENTRY_LOG").Rows.Count = 0 Then
                        MessageBox.Show("SORRY! GET ACCESS AT RECEPTION", "GET ACCESS AT RECEPTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        txt_MemberCode.Clear()
                        txt_MemberName.Clear()
                        Txt_holder_name.Clear()
                        txt_Holder_Code.Clear()
                        Exit Function
                    End If
                End If
                ''CHECKING AND DISPLAYING RECORDS FROM MEMBERMASTER
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    SQLSTRING = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' and curentstatus not in('live','active') "
                    gconnection.getDataSet(SQLSTRING, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")

                        If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OKCancel, "chs") = MsgBoxResult.OK Then
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        Else
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        End If
                    End If
                End If
                SQLSTRING = "select balance,muc_amt from sm_vw_balance  where  CARDCODE='" & Trim(Me.txt_Holder_Code.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "sm_bal")
                If gdataset.Tables("sm_bal").Rows.Count > 0 Then
                    lbl_bal.Text = "CARD BAL.:" & gdataset.Tables("sm_bal").Rows(0).Item("balance")
                    '& "  MUC :" & gdataset.Tables("sm_bal").Rows(0).Item("muc_amt")

                End If

                Dim PHOTOFILENAME As String
                If txt_TableNo.ReadOnly = True Then
                    txt_ServerCode.Focus()
                Else
                    txt_TableNo.Focus()
                End If
            Else
                If cbo_PaymentMode.Text = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    cbo_PaymentMode.Focus()
                End If
            End If
        Catch EX As Exception
            MsgBox("PLEASE GET ACCESS AT RECEPTION USING SPLASH DEVICE..." & EX.Message)
        End Try
    End Function

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        LoadCount = 1
        Call clearform(Me)
        Call Autogenerate()
        Amt = 0
        'Call ShowBillno()
        Me.grpPass.Visible = False
        GRP_PAY.Visible = False
        Call fillPayment_Mode()
        Call GridUnLocking()
        txt_MemberCode.Tag = ""
        Cmd_Add.Text = "Add [F7]"
        cbo_PaymentMode.Focus()
        For i = 0 To sSGrid.MaxRows
            sSGrid.Row = i
            sSGrid.Col = 1
            sSGrid.BackColor = Color.White
            sSGrid.ForeColor = Color.Black
        Next
        sSGrid.ClearRange(1, 1, -1, -1, True)
        sSGrid.SetActiveCell(1, 1)
        KotDetails = ""
        grp_Paymentmodeselection.Top = 1000
        Me.KOT_Timer.Enabled = True
        Me.cmd_BillNoHelp.Enabled = True
        Me.Lbl_OtherBill.Visible = False
        Me.Cmd_Add.Enabled = True
        Me.txt_BillNo.ReadOnly = False
        cbo_SubPaymentMode.Visible = False
        lbl_SubPaymentMode.Visible = False
        Me.Button3.Enabled = True
        'lblCro1.Visible = False
        'lblCro2.Visible = False
        Lbl_Bill.Text = ""
        txt_Holder_Code.Text = ""
        Txt_holder_name.Text = ""
        MCODE_GBL = ""
        MNAME_GBL = ""
        txt_MemberCode.Text = ""
        txt_MemberName.Text = ""
        txt_ServerCode.Text = ""
        txt_ServerName.Text = ""
        lblCro1.Visible = False
        lblCro2.Visible = False
        'grp_paydet.Visible = False
        Timer1.Enabled = False
        Call cmd_Cancel_Click(sender, e)
        'Modified on 18 Mar'08
        'Mk Kannan
        'Begin
        lblDeleted.Visible = False
        'End
        'LAB_SPILTMEMBER.Visible = False
        'CMB_SPILTMEMBER.Visible = False
        'grpPass.Visible = False
        'grpNewMcode.Visible = False
        SETLEMENT_GROUP.Visible = True
        ssgrid_settlement.ClearRange(1, 1, -1, -1, True)
        ssgrid_settlement.SetActiveCell(1, 1)
        SETLEMENT_GROUP.Visible = False
        'CHKALL.Checked = False
        'CHKALL.Visible = False
        grp_BANK_DETAILS.Visible = False
        Me.txt_insno.Text = ""
        Me.cmb_instype.Text = ""
        'If File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
        '    Pic_Member.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpg")
        'End If
        txt_ServerCode.ReadOnly = False
        If Mid(gWaiterReq, 1, 1) = "Y" Then
            txt_ServerCode.ReadOnly = False
            txt_ServerName.ReadOnly = False
            cmd_ServerCodeHelp.Enabled = True
        Else
            txt_ServerCode.ReadOnly = True
            txt_ServerName.ReadOnly = True
            cmd_ServerCodeHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call SetDateTime()
        SYS_DATE_TIME()
        Me.cmb_type.Focus()
    End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        ssgridPayment1.ClearRange(1, 1, -1, -1, True)
        ssgridPayment1.SetActiveCell(1, 1)
        'txt_Cardholdername.Text = ""
        'txt_PartialPayment.Text = ""
        'txt_Chequeno.Text = ""
        'txt_Draweebank.Text = ""
        'txt_Typeofcard.Text = ""
        'txt_Cardno.Text = ""
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ttime = 0 Or ttime <> 2 Then
            '    Lbl_SwipeCard.Visible = False
            ttime = 2
        ElseIf ttime = 2 And Trim(txt_card_id.Text) = "" Then
            txt_card_id.Focus()
            CloseSmartDevicePort()
            If RealD < 0 Then
                Timer1.Stop()
                If MessageBox.Show("PROBLEM IN SMART CARD DEVICE CONNECTION ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Timer1.Start()
                    Call GetSMARTDEVICEPORT()
                Else
                    Timer1.Start()
                End If
            Else
                GetSMARTDEVICEPORT()
            End If
            GetSMART_CARDID()
            txt_card_id.Text = Trim(GBL_SMARTCARDSNO)
            If txt_card_id.Text <> "" Then
                Call txt_card_id_Validated(sender, e)
                ttime = 0
            End If
        End If
    End Sub
    Private Sub CMB_BTYPE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CMB_BTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'bselect = True
            Me.cbo_PaymentMode.Focus()
        End If
    End Sub
    Private Sub cmd_TablenoHelp_Click(sender As Object, e As EventArgs) Handles cmd_TablenoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT ISNULL(TABLENO,'') AS TABLENO,ISNULL(TABLENAME,'') AS TABLENAME FROM TABLEMASTER"
        M_WhereCondition = " WHERE     isnull(FREEZE,'') <> 'Y'"
        vform.Field = " TABLENO,TABLENAME"
        'vform.vFormatstring = "         TABLE NO         |          TABLE DESC"
        vform.vCaption = "TABLE MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_TableNo.Text = Trim(vform.keyfield & "")
            txt_TableNo_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_TableNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_TableNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_TablenoHelp_Click(sender, e)
        End If
    End Sub
    Private Sub txt_TableNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_TableNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If txt_TableNo.ReadOnly = False Then
                If Trim(txt_TableNo.Text) <> "" Then
                    txt_TableNo_Validated(sender, e)
                Else
                    Call cmd_TablenoHelp_Click(cmd_TablenoHelp, e)
                End If
            End If
            'txt_Cover.Focus()
        End If
    End Sub
    Private Sub txt_TableNo_Validated(sender As Object, e As EventArgs) Handles txt_TableNo.Validated
        Try
            Dim strstring As String
            Dim I As Integer
            If Trim(txt_TableNo.Text) <> "" Then
                If Trim(txt_TableNo.Text) <> "" Then
                    'strstring = "SELECT TABLENO,MCODE,MNAME FROM Kot_Hdr WHERE tableno='" & Trim(txt_TableNo.Text) & "' AND   "
                    'strstring = strstring & "Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_KOTdate.Value), "yyyy-MM-dd") & "' "
                    '                    strstring = "SELECT isnull(poscode,'') as poscode,isnull(posdesc,'') as posname FROM POSMASTER WHERE POSCODE='" & Trim(txt_ServerCode.Text) & "'AND ISNULL(Freeze,'')<>'Y'"
                    strstring = "SELECT TABLENO FROM TABLEMASTER WHERE tableno='" & Trim(txt_TableNo.Text) & "' AND ISNULL(FREEZE,'')<>'y'"
                    gconnection.getDataSet(strstring, "LOCmaster")
                    If gdataset.Tables("LOCmaster").Rows.Count > 0 Then
                        txt_TableNo.Text = gdataset.Tables("Locmaster").Rows(0).Item("TABLENO")
                        'txt_ServerName.Text = gdataset.Tables("Locmaster").Rows(0).Item("PosName")
                        'txt_MemberCode.Text = gdataset.Tables("Locmaster").Rows(0).Item("MCODE")
                        'txt_MemberName.Text = gdataset.Tables("Locmaster").Rows(0).Item("MNAME")
                        'txt_MemberCode_Validated(sender, e)
                        Me.cbo_PaymentMode.Focus()
                        'txt_ServerCode.Focus()
                    Else
                        Me.txt_TableNo.Focus()
                    End If
                Else
                    Me.txt_TableNo.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_MemberCodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_MemberCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Dim SSQL As String
        Dim PAY As String
        PAY = ""
        'SMART(CARD)
        'ROOM(CHECKIN)
        'MEMBER(ACCOUNT)
        'BANK(INSTRUMENT)
        'CASH()
        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If PAY = "ROOM CHECKIN" Then
            gSQLString = "SELECT roomno,guest,docno FROM roomcheckin "
            M_WhereCondition = "WHERE ISNULL(checkout,'') <> 'Y' AND roomstatus='occupied'"
            vform.Field = " ROOMNO,GUEST,DOCNO "
            'vform.vFormatstring = "     ROOM NO                  |                     GUEST NAME                    |              DOC NO               "
            vform.vCaption = "ROOM MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode.Tag = Trim(vform.keyfield2 & "")
                txt_ServerCode.Focus()
            End If
            vform.Close()
            vform = Nothing
            'club
            '03/05/2008
            'SMART(CARD)
            'ROOM(CHECKIN)
            'MEMBER(ACCOUNT)
            'BANK(INSTRUMENT)
            'CASH()
            'CLUB(ACCOUNT)
            'EMPLOYEE()
        ElseIf PAY = "CLUB ACCOUNT" Then
            gSQLString = "SELECT MCODE,MNAME FROM MEMBERMASTER "
            M_WhereCondition = "WHERE membertypecode in(select subtypecode from subcategorymaster where isnull(clubaccount,'')='Y') "
            vform.Field = " SLCODE,SLNAME "
            'vform.vFormatstring = "     SLCODE                  |                     SL NAME                    "
            vform.vCaption = "ACCOUNT MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode.Tag = Trim(vform.keyfield & "")
                txt_ServerCode.Focus()
            End If
            vform.Close()
            vform = Nothing
        ElseIf PAY = "MEMBER ACCOUNT" Then
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='CLUBMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"

            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                txt_ServerCode.Focus()
            End If
            vform.Close()
            vform = Nothing
        ElseIf PAY = "EMPLOYEE" Then
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='EMPMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                txt_ServerCode.Focus()
            End If
            vform.Close()
            vform = Nothing
        Else
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='CLUBMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                txt_ServerCode.Focus()
            End If
            vform.Close()
            vform = Nothing
        End If
    End Sub
    Private Sub txt_MemberCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MemberCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Me.cmd_MemberCodeHelp.Enabled = True Then
                Call cmd_MemberCodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_MemberCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_MemberCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_MemberCode.Text) <> "" Then
                txt_MemberCode_Validated(sender, e)
            Else
                Call cmd_MemberCodeHelp_Click(cmd_MemberCodeHelp, e)
            End If
        End If
    End Sub

    Private Sub txt_MemberCode_Validated(sender As Object, e As EventArgs) Handles txt_MemberCode.Validated
        Try
            Dim PAY As String
            PAY = ""
            'SMART CARD
            'ROOM CHECKIN
            'MEMBER ACCOUNT
            'BANK INSTRUMENT
            'CASH
            'CLUB ACCOUNT
            'EMPLOYEE
            SQLSTRING = "select isnull(memcreditlimit,0)as creditlimit from  possetup"
            gconnection.getDataSet(SQLSTRING, "climit")
            If gdataset.Tables("climit").Rows.Count > 0 Then
                If gdataset.Tables("climit").Rows(0).Item("creditlimit") > 0 Then
                    SQLSTRING = "exec get_creditlimit'" & Me.txt_MemberCode.Text & "'"
                    gconnection.ExcuteStoreProcedure(SQLSTRING)
                    SQLSTRING = "SELECT * FROM balance WHERE MCODE='" & Me.txt_MemberCode.Text & "'"
                    gconnection.getDataSet(SQLSTRING, "CRD")
                    If gdataset.Tables("CRD").Rows.Count > 0 Then
                        MemberOutstand = gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
                        'Me.LAB_OUTSTAND.Text = "MEMBER OUTSTANDING :" & gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
                    Else
                        MemberOutstand = 0
                    End If

                    If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
                        MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        'Exit Sub
                    End If

                End If
            End If
            ssql = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(ssql, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If

            If Trim(txt_MemberCode.Text) <> "" Then

                'Call tableno()
                If cbo_PaymentMode.Text <> "STAFF" Or cbo_PaymentMode.Text <> "SMART CARD" Then
                    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                End If

                If PAY = "ROOM CHECKIN" Then
                    strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(txt_MemberCode.Text) & "'"
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("docno")
                        If Mid(gWaiterReq, 1, 1) = "Y" Then
                            txt_ServerCode.Focus()
                        Else
                            txt_MemberCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberCode.Focus()
                    End If
                ElseIf Me.cmb_type.Text = "ROOMGUEST" Then
                    strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(txt_MemberCode.Text) & "'"
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("docno")
                        If Mid(gWaiterReq, 1, 1) = "Y" Then
                            txt_ServerCode.Focus()
                        Else
                            txt_MemberCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberCode.Focus()
                    End If
                    'club
                    '03/05/2008
                ElseIf PAY = "CLUB ACCOUNT" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM membermaster WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE')and membertypecode in(select subtypecode from subcategorymaster where isnull(clubaccount,'')='YES') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        If Mid(gWaiterReq, 1, 1) = "Y" Then
                            txt_ServerCode.Focus()
                        Else
                            txt_MemberCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                        txt_MemberCode.Focus()
                    End If
                ElseIf PAY = "EMPLOYEE" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM EMPLOYEEMASTER WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        If Mid(gWaiterReq, 1, 1) = "Y" Then
                            txt_ServerCode.Focus()
                        Else
                            txt_MemberCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                        txt_MemberCode.Focus()
                    End If
                ElseIf Me.cmb_type.Text = "EMPLOYEE" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM EMPLOYEEMASTER WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        If Mid(gWaiterReq, 1, 1) = "Y" Then
                            txt_ServerCode.Focus()
                        Else
                            txt_MemberCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                        txt_MemberCode.Focus()
                    End If
                Else
                    strstring = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' and CurentStatus in ('ACTIVE','live')"
                    gconnection.getDataSet(strstring, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        Dim name
                        name = gdataset.Tables("membermaster").Rows(0).Item("termination")

                        Select Case Trim(name)
                            Case "LIVE"
                                Txt_Remarks.Text = ""
                                txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            Case "ACTIVE"
                                Txt_Remarks.Text = ""
                                txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            Case Else
                                Txt_Remarks.Text = "MEMBERSHIP " & name & "."
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                txt_MemberCode.Focus()
                        End Select
                        'if txt_MemberCode.Text =
                        If gclosingvalue = True Then
                            txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                            txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                        Else
                            If Mid(gWaiterReq, 1, 1) = "Y" Then
                                txt_ServerCode.Focus()
                            Else
                                txt_MemberCode.Focus()
                            End If
                        End If
                    Else
                        If Me.cmb_type.Text = "ROOMGUEST" Then
                            strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(txt_MemberCode.Text) & "'"
                            gconnection.getDataSet(strstring, "RoomCheckin")
                            If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                                txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                                txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                                txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("docno")
                                If Mid(gWaiterReq, 1, 1) = "Y" Then
                                    txt_ServerCode.Focus()
                                Else
                                    txt_MemberCode.Focus()
                                End If
                            Else
                                txt_MemberCode.Text = ""
                                txt_MemberCode.Focus()
                            End If
                        Else
                            strstring = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' AND TTYPE='" & Me.cmb_type.Text & "' "
                            gconnection.getDataSet(strstring, "membermaster")
                            If gdataset.Tables("membermaster").Rows.Count > 0 Then
                                Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")
                                If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OkCancel, "chs") = MsgBoxResult.Ok Then
                                    txt_MemberCode.Text = ""
                                    txt_MemberCode.Focus()
                                End If
                            End If
                        End If
                    End If
                End If
                If txt_ServerCode.ReadOnly = True Then
                    Call FillKOTdetails()
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Invalid Entry Plz try once again", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_MemberCode.Focus()
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_ServerCodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_ServerCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT Servercode, Servername FROM servermaster"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <>'Y'"
        vform.Field = " SERVERCODE,SERVERNAME "
        'vform.vFormatstring = "         SERVER CODE            |                       SERVERNAME                               "
        vform.vCaption = "SERVER MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_ServerCode.Text = Trim(vform.keyfield & "")
            txt_ServerName.Text = Trim(vform.keyfield1 & "")
            sSGrid.Focus()
            sSGrid.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_ServerCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ServerCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Me.cmd_ServerCodeHelp.Enabled = True Then
                Call cmd_ServerCodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_ServerCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ServerCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_ServerCode.Text) <> "" Then
                txt_ServerCode_Validated(sender, e)
            Else
                Call cmd_ServerCodeHelp_Click(cmd_ServerCodeHelp, e)
            End If
        End If
    End Sub
    Private Sub txt_ServerCode_Validated(sender As Object, e As EventArgs) Handles txt_ServerCode.Validated
        Dim strstring As String
        Dim I As Integer
        If Trim(txt_ServerCode.Text) <> "" Then
            strstring = "SELECT * FROM servermaster WHERE ServerCode='" & Trim(txt_ServerCode.Text) & "'AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(strstring, "servermaster")
            If gdataset.Tables("servermaster").Rows.Count > 0 Then
                txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("ServerCode")
                txt_ServerName.Text = gdataset.Tables("servermaster").Rows(0).Item("ServerName")
                'If txt_ServerCode.ReadOnly = False Then
                Call FillKOTdetails()
                sSGrid.Focus()
                'End If
                sSGrid.SetActiveCell(1, 1)
            Else
                txt_ServerCode.Text = ""
                txt_ServerCode.Focus()
            End If
        Else
        End If
    End Sub
    Private Sub FillKOTdetails()
        Dim sqlstring, sqlstring123, Subpaymentmode(), sts, tsqlstring As String
        Dim Billtotal As Double
        KotDetails = ""
        Dim i, j As Integer
        Try
            Dim PAY As String
            PAY = ""
            'SMART CARD
            'ROOM CHECKIN
            'MEMBER ACCOUNT
            'BANK INSTRUMENT
            'CASH
            'CLUB ACCOUNT
            'EMPLOYEE
            'CLUBMEMBER()
            'EMPLOYEE()
            'ROOMGUEST()
            'SMART(CARD)
            ssql = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(ssql, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If
            If Me.txt_MemberCode.Text <> "" Then
                If Me.cmb_type.Text = "ROOMGUEST" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE RoomNo='" & Trim(txt_MemberCode.Text) & "' AND  ttype='" & Me.cmb_type.Text & "'  AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' AND ISNULL(Manualbillstatus,'')<>'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "'"
                ElseIf Me.cmb_type.Text = "EMPLOYEE" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' AND  ttype='EMPMEMBER'  AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' AND ISNULL(Manualbillstatus,'')<>'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "'"
                ElseIf cbo_PaymentMode.Text = "R.MEMBER" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE  Mcode='" & Trim(txt_MemberCode.Text) & "' AND  PAYMENTTYPE='" & cbo_PaymentMode.Text & "'  AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' AND ISNULL(Manualbillstatus,'')<> 'Y'AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "
                ElseIf cbo_PaymentMode.Text = "COUPON" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE  Mcode='" & Trim(txt_MemberCode.Text) & "' AND  PAYMENTTYPE='" & cbo_PaymentMode.Text & "'  AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "
                ElseIf cbo_PaymentMode.Text = "CASH" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE  Mcode='" & Trim(txt_MemberCode.Text) & "'   AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "
                ElseIf PAY = "CLUB ACCOUNT" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE  Mcode='" & Trim(txt_MemberCode.Text) & "'  AND "
                    sqlstring = sqlstring & " Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y'AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "

                ElseIf cbo_PaymentMode.Text = "PARTY" Then
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE Mcode='" & Trim(txt_MemberCode.Text) & "' AND  PAYMENTTYPE='" & cbo_PaymentMode.Text & "' AND  "
                    sqlstring = sqlstring & "Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "
                Else
                    sqlstring = "SELECT Kotdetails,Kotdate,TOTAL AS BillAmount,TOTALTAX, ISNULL(PACKAMT,0)+ISNULL(TIPSAMT,0)+ISNULL(ADCGSAMT,0)+ISNULL(PARTYAMT,0)+ISNULL(ROOMAMT,0) AS CHARGESAMT, BillStatus, Isnull(Remarks,'') as Remarks,servicelocation FROM Kot_Hdr WHERE Mcode='" & Trim(txt_MemberCode.Text) & "'    AND  "
                    sqlstring = sqlstring & "Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y'  AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_BillDate.Value), "yyyy-MM-dd") & "' "
                End If
                If gCenterlized = "Y" Then
                    sqlstring = sqlstring & " AND ISNULL(SALETYPE,'') = 'SALE' "
                Else
                    sqlstring = sqlstring & " AND ISNULL(SALETYPE,'') <> 'SALE'"
                End If
                Dim VSQL As String
                If Me.cmb_type.Text <> "SMART CARD" Then
                    If Me.cmb_type.Text = "EMPLOYEE" Then
                        sqlstring = sqlstring & " AND TTYPE='EMPMEMBER'"
                    Else
                        sqlstring = sqlstring & " AND TTYPE='" & Me.cmb_type.Text & "'"
                    End If
                Else
                    ordertype = ""
                    VSQL = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                    VSQL = VSQL & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                    VSQL = VSQL & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                    gconnection.getDataSet(VSQL, "SM_CARDFILE_HDR")
                    If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                        If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Then
                            ordertype = "CLUBMEMBER"

                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                            ordertype = "AFFMEMBER"
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                            ordertype = "EMPMEMBER"
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                            ordertype = "ROOMGUEST"
                        End If
                    End If
                    If ordertype = "" Then
                        MsgBox("PLEASE SWIPE CARD")
                        Exit Sub
                    Else
                        sqlstring = sqlstring & " AND TTYPE='" & ordertype & "'"
                    End If

                End If
                sts = "select * from POSGROUPMASTER where isnull(void,'')<>'y' and poscode in(select poscode from POSMASTER WHERE finalprefix ='" & DOCTYPE & "' )"
                gconnection.getDataSet(sts, "group")
                If gdataset.Tables("group").Rows.Count > 0 Then
                    If gCenterlized = "Y" Then
                        sqlstring = sqlstring & " AND ISNULL(SALETYPE,'') ='SALE'"
                    Else
                        sqlstring = sqlstring & " AND ISNULL(DOCTYPE,'')  IN (SELECT KOTPREFIX FROM POSMASTER WHERE POSCODE IN  (SELECT POSCODE FROM POSGROUPMASTER WHERE GROUPCODE IN(SELECT GROUPCODE FROM POSGROUPMASTER  WHERE POSCODE IN(SELECT POSCODE FROM POSMASTER WHERE  finalprefix='" & DOCTYPE & "') AND ISNULL(VOID,'')<>'Y')))"
                    End If
                Else
                    If gCenterlized = "Y" Then
                        sqlstring = sqlstring & " AND ISNULL(SALETYPE,'') ='SALE'"
                    Else
                        sqlstring = sqlstring & " AND ISNULL(DOCTYPE,'') ='" & DOCTYPE & "'"
                    End If

                End If
                If Me.cbo_SubPaymentMode.Visible = True Then
                    Subpaymentmode = Split(Trim(Me.cbo_SubPaymentMode.Text), "-")
                    sqlstring = sqlstring & " and SubPaymentMode='" & Trim(Subpaymentmode(0)) & "' "
                End If
                tsqlstring = " ORDER BY Kotdetails,Kotdate"
                tsqlstring = sqlstring & tsqlstring
                'End 
                gconnection.getDataSet(sqlstring, "KOT_HDR")
                If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
                    'For i = 0 To gdataset.Tables("KOT_HDR").Rows.Count - 1
                    '    sqlstring123 = "EXEC UPD_PACK '" & Trim(gdataset.Tables("Kot_Hdr").Rows(i).Item("Kotdetails")) & "'"
                    '    gconnection.dataOperation(6, sqlstring123, "UPD_PACK")
                    'Next
                End If
                sqlstring = sqlstring & "  AND ISNULL(BillAmount,0)<>0  ORDER BY Kotdetails,Kotdate"
                With ssGrid
                    gconnection.getDataSet(sqlstring, "KOT_HDR1")
                    If gdataset.Tables("KOT_HDR1").Rows.Count > 0 Then
                        Txt_Remarks.Text = Nothing
                        For i = 1 To gdataset.Tables("Kot_Hdr1").Rows.Count
                            .SetText(1, i, Trim(gdataset.Tables("Kot_Hdr1").Rows(j).Item("Kotdetails")) & "")
                            If Trim(KotDetails) = "" Then
                                KotDetails = "'" & Trim(gdataset.Tables("Kot_Hdr1").Rows(j).Item("Kotdetails")) & "'"
                            Else
                                KotDetails = KotDetails & ",'" & Trim(gdataset.Tables("Kot_Hdr1").Rows(j).Item("Kotdetails")) & "'"
                            End If
                            .SetText(2, i, gdataset.Tables("KOT_HDR1").Rows(j).Item("Kotdate"))
                            .SetText(3, i, Format(Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("BillAmount")), "0.00"))
                            .SetText(4, i, Format(Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("TOTALTAX")), "0.00"))
                            .SetText(5, i, Format(Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("CHARGESAMT")), "0.00"))
                            Billtotal = Billtotal + Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("BillAmount")) + Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("TOTALTAX")) + Val(gdataset.Tables("KOT_HDR1").Rows(j).Item("CHARGESAMT"))
                            .SetText(6, i, Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("BillStatus")))
                            'If Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("BillStatus")) = "ST" Then
                            '    .SetText(4, i, 1)
                            'Else
                            '    .SetText(4, i, 1)
                            'End If
                            '.Row = i
                            '.Col = 4
                            '.Lock = True
                            If Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("Remarks")) <> "" Then
                                If j = 0 Then
                                    Txt_Remarks.Text = Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("Remarks"))
                                Else
                                    If Len(Txt_Remarks.Text) > 0 Then
                                        Txt_Remarks.Text = Txt_Remarks.Text & "," & Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("Remarks"))
                                    Else
                                        Txt_Remarks.Text = Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("Remarks"))
                                    End If
                                End If
                            End If
                            If j = 0 Then
                                loccode = Trim(gdataset.Tables("KOT_HDR1").Rows(j).Item("servicelocation"))
                            End If
                            j = j + 1
                        Next
                        If BILLROUNDYESNO = "YES" Then
                            Me.txt_BillAmount.Text = Format(Math.Round(Val(Billtotal)), "0.00")
                        Else
                            Me.txt_BillAmount.Text = Format((Val(Billtotal)), "0.00")
                        End If
                        .Focus()
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        'MessageBox.Show("Plz enter a Valid Combination", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssGrid.ClearRange(-1, -1, 1, 1, True)
                        txt_ServerCode.Focus()
                    End If
                End With
                '----------------------------------------
                'SETTLEMENT
                'BEGIN
                With ssgrid_settlement
                    If ssgrid_settlement.DataRowCnt = 0 Then
                        .SetActiveCell(1, 1)
                        .Row = 1
                        .Col = 1
                        .Text = Trim(txt_MemberCode.Text)
                        .Col = 2
                        .Text = Trim(txt_BillAmount.Text)
                    End If
                End With
                '----------------------------------------
                'SETTLEMENT
                'END
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim taxbilldetails, taxbillno, nontaxbilldetails, nontaxbillno, Otherbillno, poscode, jrnsql, jrnsql1 As String
        Dim Oldtaxbilldetails, Oldtaxbillno, Oldnontaxbilldetails, Oldnontaxbillno, OldOtherbillno As String
        Dim sqlstring, Varchk, SubpaymentMode(), paymentaccountcode, Subpaymentaccountcode As String
        Dim TotalAmount, TaxTotal, TotPackAmt, TotTipsAmt, TotAdAmt, TotPartyAmt, TotRoomAmt, total, size, CardAmount, i, j, Z, dblCard, dblMinimum, TOTALBILL, acperc, acamt As Double
        Dim TaxApp, NoTax, Otherbool As Boolean
        Dim ttotal, tntotal, ttaxtotal, tntaxtotal As Double
        Dim Kot_Bill As New DataTable
        Dim Taxdr(), NoTaxDr() As DataRow
        Dim Update1(0) As String
        Dim Update2(0) As String
        Dim financalyear As String
        Dim KOTDETA As String
        Dim M, Rau As Integer
        Dim NEWBILLDETAILS, OLDBILLDETAILS, COMPNAME As String
        Dim DELSQL, sqlstringRoom, ssql As String
        ssql = "SELECT ISNULL(COMPNAME,'')AS COMPNAME FROM POSSETUP "
        gconnection.getDataSet(ssql, "COMP")
        If gdataset.Tables("COMP").Rows.Count > 0 Then
            COMPNAME = gdataset.Tables("COMP").Rows(0).Item("COMPNAME")
        End If
        TaxApp = False
        NoTax = False
        Try
            NEWBILLDETAILS = ""
            OLDBILLDETAILS = ""
            Dim PAY As String
            PAY = ""
            KOTDETA = ""
            For M = 1 To sSGrid.DataRowCnt
                With sSGrid
                    sSGrid.Row = M
                    sSGrid.Col = 1
                    Varchk = ""
                    Varchk = sSGrid.Text
                    If Trim(Varchk & "") <> "" Then
                        .Row = M
                        .Col = 1
                        KOTDETA = KOTDETA & "'" & .Text & "',"
                    End If
                End With
            Next
            KOTDETA = Mid(KOTDETA, 1, Len(KOTDETA) - 1)
            If Me.cmb_type.Text = "ROOMGUEST" Then
                ssql = "select * from kot_hdr where KOTDETAILS IN(" & KOTDETA & ") and roomno<>'" & Me.txt_MemberCode.Text & "'"
            Else
                ssql = "select * from kot_hdr where KOTDETAILS IN(" & KOTDETA & ") and mcode<>'" & Me.txt_MemberCode.Text & "'"
            End If
            gconnection.getDataSet(ssql, "room")
            If gdataset.Tables("room").Rows.Count > 0 Then
                MsgBox("please check kot mismatch with mcode")
                Exit Sub
            End If
            ssql = " SELECT SUM(ISNULL(AMOUNT,0)+ISNULL(TAXAMOUNT,0)+ISNULL(PACKAMOUNT,0)+ISNULL(TipsAmt,0)+ISNULL(AdCgsAmt,0)+ISNULL(PartyAmt,0)+ISNULL(RoomAmt,0)) AS BILLTOTAL FROM KOT_DET WHERE KOTDETAILS IN(" & KOTDETA & ") AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'')<>'Y' AND ISNULL(BILLDETAILS,'')=''"
            gconnection.getDataSet(ssql, "BAL")
            If gdataset.Tables("BAL").Rows.Count > 0 Then
                TOTALBILL = gdataset.Tables("BAL").Rows(0).Item("BILLTOTAL")
                If BILLROUNDYESNO = "YES" Then
                    TOTALBILL = Math.Round(TOTALBILL, 0)
                Else
                    TOTALBILL = TOTALBILL
                End If
            End If
            ssql = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(ssql, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If
            If PAY = "BANK INSTRUMENT" Then
                If Me.cmb_instype.Text = "" Then
                    MsgBox("No input for instrumenttype")
                    Me.cmb_instype.Focus()
                    Exit Sub
                End If
                If Me.txt_insno.Text = "" Then
                    MsgBox("No input for instrumentno")
                    Me.txt_insno.Focus()
                    Exit Sub
                End If
            End If
            Call Randomize()
            vOutfile = Mid("jrnl" & (Rnd() * 800000), 1, 8)
            Update2(0) = " Exec Jrn_Kot_Det '" & vOutfile & "'"
            'Call checkvalidate() '''---> Check Validation
            'If chkbool = False Then Exit Sub


            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                dblMsg = 0
                'sqlstring = "DELETE FROM KOTBLOCK WHERE MCODE='" & Trim(Me.txt_MemberCode.Text) & "'"
                'gconnection.dataOperation(6, sqlstring, "RAU")
                ''''''*********************SMART CARD CARD
                ''''''WITH MIN USAGE
                txt_BillAmount.Text = Format(Val(TOTALBILL), "0.00")
                BILLAMT_GBL = Val(txt_BillAmount.Text)
                If PAY = "SMART CARD" Then
                    If (MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL < Val(txt_BillAmount.Text) Then
                        MsgBox("SUFFICIENT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                        Exit Sub
                    Else
                        Txt_Remarks.Text = "OpBal : " & Format((MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL, "0.00") & " Trans Amt : " & Format(Val(txt_BillAmount.Text), "0.00") & "   ClsBal : " & Format(((MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL) - Val(txt_BillAmount.Text), "0.00")
                    End If
                End If
                Call Autogenerate()
                KotDetails = ""
                For i = 1 To sSGrid.DataRowCnt
                    sSGrid.Row = i
                    sSGrid.Col = 1
                    Varchk = ""
                    Varchk = sSGrid.Text
                    If Trim(Varchk & "") <> "" Then
                        sSGrid.Col = 1
                        If KotDetails = "" Then
                            KotDetails = "'" & Trim(sSGrid.Text) & "'"
                        Else
                            KotDetails = KotDetails & ",'" & Trim(sSGrid.Text) & "'"
                        End If
                    End If
                Next i
                If Trim(KotDetails) = "" Then
                    MessageBox.Show("Plz Select The Kots To Generate The Bill", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '''******************************************* $ Find Out Paymentmode Accountcode and Subpaymentmode Accountcode $ *********************'''
                '''******************************************* $ CHECK IF THAT MEMBER HAV THE FACILITY OF USING CARD OR NOT      $ *********************'''
                If Trim(PAY) = "CARD" Then
                    sqlstring = "SELECT * FROM SMARTCARDDETAILS WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                    gconnection.getDataSet(sqlstring, "SMARTCARDDETAILS")
                    If gdataset.Tables("SMARTCARDDETAILS").Rows.Count > 0 Then
                        smartcardbool = True
                    Else
                        MessageBox.Show("Sorry this member don't hav card facility", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txt_MemberCode.Focus()
                        smartcardbool = False
                        Exit Sub
                    End If
                End If
                '''************************************************** $ CHECK COMPLETED  $ ********************************************************************'''
                If Me.cbo_SubPaymentMode.Visible = True Then
                    SubpaymentMode = Split(Trim(Me.cbo_SubPaymentMode.Text), "-")
                    sqlstring = "SELECT Accountin FROM subpaymentmode WHERE Subpaymentcode ='" & Trim(SubpaymentMode(0)) & "' AND ISNULL(Freeze,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "subpaymentmode")
                    If gdataset.Tables("subpaymentmode").Rows.Count > 0 Then
                        Subpaymentaccountcode = Trim(gdataset.Tables("subpaymentmode").Rows(0).Item("Accountin") & "")
                    End If
                Else
                    ReDim Preserve SubpaymentMode(1)
                    SubpaymentMode(0) = ""
                    Subpaymentaccountcode = ""
                End If
                sqlstring = "SELECT Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "Paymentmodemaster")
                If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
                    paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
                Else
                    MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    paymentaccountcode = ""
                    Exit Sub
                End If
                '''****************************************** $ In KotBill Table I am Storing The Kotdetails according to taxcode $ ******************'''
                'sqlstring = "SELECT KOTDATE,KOTDetails,Isnull(TAxcode,'') AS Taxcode ,ISNULL(SUM(ISNULL(Amount,0)),0) AS Amount,ISNULL(SUM(ISNULL(TaxAmount,0)),0) AS TaxAmount FROM Kot_det WHERE Isnull(KotStatus,'') <> 'Y' AND Kotdetails IN( " & KotDetails & " ) GROUP BY KOTDATE,Taxcode,KotDetails ORDER BY Taxcode,KotDetails"
                If gCenterlized = "Y" Then
                    sqlstring = "SELECT DISTINCT MCODE FROM KOT_DET WHERE Isnull(KotStatus,'') <> 'Y' AND Kotdetails IN( " & KotDetails & " )"
                Else
                    sqlstring = "SELECT DISTINCT POSCODE FROM KOT_DET WHERE Isnull(KotStatus,'') <> 'Y' AND Kotdetails IN( " & KotDetails & " )"
                End If
                gconnection.getDataSet(sqlstring, "KTD")
                If gdataset.Tables("KTD").Rows.Count > 0 Then
                    For Rau = 0 To gdataset.Tables("KTD").Rows.Count - 1
                        Call Randomize()
                        vOutfile = Mid("jrnl" & (Rnd() * 800000), 1, 8)
                        Update2(0) = " Exec Jrn_Kot_Det '" & vOutfile & "'"
                        If gCenterlized = "Y" Then
                            sqlstring = "SELECT FINALPREFIX FROM POSSETUP "
                        Else
                            sqlstring = "SELECT FINALPREFIX as doctype FROM POSMASTER where poscode='" & Trim(gdataset.Tables("KTD").Rows(Rau).Item("poscode")) & "'"
                        End If
                        gconnection.getDataSet(sqlstring, "ktd1")
                        If gdataset.Tables("ktd1").Rows.Count > 0 Then
                            If gCenterlized <> "Y" Then
                                Me.txt_BillNo.Text = Autogenerate_Poswise(gdataset.Tables("ktd1").Rows(0).Item("doctype"))
                            End If
                            If NEWBILLDETAILS <> "" Then
                                OLDBILLDETAILS = NEWBILLDETAILS
                            End If
                            NEWBILLDETAILS = Me.txt_BillNo.Text

                            If gCenterlized = "Y" Then
                                ssql = " SELECT SUM(ISNULL(AMOUNT,0)+ISNULL(TAXAMOUNT,0)+ISNULL(PACKAMOUNT,0)+ISNULL(TipsAmt,0)+ISNULL(AdCgsAmt,0)+ISNULL(PartyAmt,0)+ISNULL(RoomAmt,0)) AS BILLTOTAL FROM KOT_DET WHERE KOTDETAILS IN(" & KOTDETA & ") AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'')<>'Y' AND ISNULL(BILLDETAILS,'')='' and MCODE ='" & Trim(gdataset.Tables("KTD").Rows(Rau).Item("MCODE")) & "'"
                            Else
                                ssql = " SELECT SUM(ISNULL(AMOUNT,0)+ISNULL(TAXAMOUNT,0)+ISNULL(PACKAMOUNT,0)+ISNULL(TipsAmt,0)+ISNULL(AdCgsAmt,0)+ISNULL(PartyAmt,0)+ISNULL(RoomAmt,0)) AS BILLTOTAL FROM KOT_DET WHERE KOTDETAILS IN(" & KOTDETA & ") AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'')<>'Y' AND ISNULL(BILLDETAILS,'')='' and poscode ='" & Trim(gdataset.Tables("KTD").Rows(Rau).Item("poscode")) & "'"
                            End If
                            gconnection.getDataSet(ssql, "BAL")
                            If gdataset.Tables("BAL").Rows.Count > 0 Then
                                TOTALBILL = gdataset.Tables("BAL").Rows(0).Item("BILLTOTAL")
                                If BILLROUNDYESNO = "YES" Then
                                    TOTALBILL = Math.Round(TOTALBILL, 0)
                                Else
                                    TOTALBILL = TOTALBILL
                                End If

                            End If

                            If gCenterlized = "Y" Then
                                sqlstring = "SELECT KOTDATE,KOTDetails,ISNULL(MCODE,'') AS POSCODE,Isnull(taxcode,'') AS Taxcode ,Isnull(category,'') AS category,ISNULL(SUM(ISNULL(Amount,0)),0) AS Amount,ISNULL(SUM(ISNULL(TaxAmount,0)),0) AS TaxAmount,ISNULL(SUM(ISNULL(PACKAMOUNT,0)),0) AS PACKAMOUNT,ISNULL(SUM(ISNULL(TipsAmt,0)),0) AS TipsAmt,ISNULL(SUM(ISNULL(AdCgsAmt,0)),0) AS AdCgsAmt,ISNULL(SUM(ISNULL(PartyAmt,0)),0) AS PartyAmt,ISNULL(SUM(ISNULL(RoomAmt,0)),0) AS RoomAmt FROM Kot_det WHERE Isnull(KotStatus,'') <> 'Y' AND Kotdetails IN( " & KotDetails & " ) and MCODE ='" & Trim(gdataset.Tables("KTD").Rows(Rau).Item("MCODE")) & "' GROUP BY KOTDATE,category,taxcode,MCODE,KotDetails ORDER BY category,taxcode,MCODE,KotDetails"
                            Else
                                sqlstring = "SELECT KOTDATE,KOTDetails,ISNULL(POSCODE,'') AS POSCODE,Isnull(taxcode,'') AS Taxcode ,Isnull(category,'') AS category,ISNULL(SUM(ISNULL(Amount,0)),0) AS Amount,ISNULL(SUM(ISNULL(TaxAmount,0)),0) AS TaxAmount,ISNULL(SUM(ISNULL(PACKAMOUNT,0)),0) AS PACKAMOUNT,ISNULL(SUM(ISNULL(TipsAmt,0)),0) AS TipsAmt,ISNULL(SUM(ISNULL(AdCgsAmt,0)),0) AS AdCgsAmt,ISNULL(SUM(ISNULL(PartyAmt,0)),0) AS PartyAmt,ISNULL(SUM(ISNULL(RoomAmt,0)),0) AS RoomAmt FROM Kot_det WHERE Isnull(KotStatus,'') <> 'Y' AND Kotdetails IN( " & KotDetails & " ) and poscode ='" & Trim(gdataset.Tables("KTD").Rows(Rau).Item("poscode")) & "' GROUP BY KOTDATE,category,taxcode,POSCODE,KotDetails ORDER BY category,taxcode,POSCODE,KotDetails"
                            End If

                            Kot_Bill = gconnection.GetValues(sqlstring)

                            If UCase(GBillBasis) = "P" Then
                                Taxdr = Kot_Bill.Select("POSCODE <> ''")
                                NoTaxDr = Kot_Bill.Select("POSCODE = ''")
                            ElseIf UCase(GBillBasis) = "C" Then
                                Taxdr = Kot_Bill.Select("category = 'BAR'")
                                NoTaxDr = Kot_Bill.Select("category = 'CATERING'")
                            ElseIf UCase(GBillBasis) = "T" Then
                                Taxdr = Kot_Bill.Select("TAXCODE <> 'VAT0'")
                                NoTaxDr = Kot_Bill.Select("TAXCODE = 'VAT0'")
                            Else
                                If Mid(Trim(UCase(gCompanyname)), 1, 8) = "KARNATKA" Then
                                    Taxdr = Kot_Bill.Select("category = 'CATERING'")
                                    NoTaxDr = Kot_Bill.Select("category <> 'CATERING'")
                                Else
                                    Taxdr = Kot_Bill.Select("POSCODE <> ''")
                                    NoTaxDr = Kot_Bill.Select("POSCODE = ''")
                                End If
                            End If
                            If Taxdr.Length > 0 Then
                                size = (Taxdr.Length * 3)
                                TaxApp = True
                            End If
                            If NoTaxDr.Length > 0 Then
                                If Val(size) > 0 Then
                                    size = size + (NoTaxDr.Length * 3)
                                Else
                                    size = (NoTaxDr.Length * 3)
                                End If
                                NoTax = True
                            End If

                            Dim Update(size + 2) As String
                            Billno = Split(Trim(txt_BillNo.Text), "/")
                            BillDetails = Trim(Me.txt_BillNo.Text)
                            If sSGrid.ActiveCol = 5 Or sSGrid.ActiveCol = 4 Then
                                Me.txt_BillAmount.Text = 0.0
                                For i = 1 To sSGrid.DataRowCnt
                                    sSGrid.Row = i
                                    sSGrid.Col = 4
                                    Varchk = ""
                                    Varchk = sSGrid.Text
                                    If Trim(Varchk & "") = "1" Then
                                        sSGrid.Col = 3
                                        total = Val(sSGrid.Text)
                                        Me.txt_BillAmount.Text = Format(Val(Me.txt_BillAmount.Text) + Val(total), "0.00")
                                    End If
                                Next i
                            End If
                            Me.txt_BillAmount.Text = Format(Val(Me.txt_BillAmount.Text) + Val(acamt), "0.00")
                            If TaxApp = True Then
                                Dim x, y As String
                                taxbillno = Billno(1)
                                taxbilldetails = Trim(Me.txt_BillNo.Text)
                                If NoTax = True Then
                                    Billno(1) = Convert.ToString(Val(Billno(1)) + 1)
                                    Billno(1) = Format(Val(Billno(1)), "000000")
                                    If gCenterlized = "Y" Then
                                        x = Trim(gDocType) & "/" & Billno(1) & "/" & Microsoft.VisualBasic.Right(Trim(txt_BillNo.Text), 5)
                                    Else
                                        x = Trim(DOCTYPE) & "/" & Billno(1) & "/" & Microsoft.VisualBasic.Right(Trim(txt_BillNo.Text), 5)
                                    End If

                                    nontaxbilldetails = x
                                    nontaxbillno = Billno(1)
                                Else
                                    nontaxbilldetails = ""
                                    nontaxbillno = ""
                                End If
                            Else
                                taxbillno = ""
                                taxbilldetails = ""
                                nontaxbillno = Billno(1)
                                nontaxbilldetails = Trim(Me.txt_BillNo.Text)
                            End If

                            Oldtaxbillno = taxbillno
                            Oldnontaxbillno = nontaxbillno
                            Oldtaxbilldetails = taxbilldetails
                            Oldnontaxbilldetails = nontaxbilldetails

                            If Taxdr.Length > 0 Then
                                TaxTotal = 0
                                TotalAmount = 0
                                TotPackAmt = 0
                                TotTipsAmt = 0
                                TotAdAmt = 0
                                TotPartyAmt = 0
                                TotRoomAmt = 0
                                j = 0
                                jrnsql1 = ""
                                If OLDBILLDETAILS = "" Then
                                    OLDBILLDETAILS = Oldnontaxbilldetails
                                End If
                                For i = 0 To Taxdr.Length - 1
                                    sqlstring = " INSERT INTO Bill_Det(Billno,BillDetails,BillDate,KotDetails,TaxAmount,KotAmount,OthBillDetails,KotDate,TaxCode,CATEGORY,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES ("
                                    sqlstring = sqlstring & "'" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "',"
                                    sqlstring = sqlstring & "" & Val(Taxdr(i).Item("TaxAmount")) & "," & Val(Taxdr(i).Item("Amount")) & ",'" & Trim(CStr(OLDBILLDETAILS)) & "',"
                                    sqlstring = sqlstring & "'" & Format(CDate(Taxdr(i).Item("KotDate")), "dd-MMM-yyyy") & "','" & Trim(Taxdr(i).Item("TaxCode")) & "','" & Trim(Taxdr(i).Item("CATEGORY")) & "'," & Val(Taxdr(i).Item("PACKAMOUNT")) & "," & Val(Taxdr(i).Item("TipsAmt")) & "," & Val(Taxdr(i).Item("AdCgsAmt")) & "," & Val(Taxdr(i).Item("PartyAmt")) & "," & Val(Taxdr(i).Item("RoomAmt")) & ")"
                                    Update(j) = sqlstring
                                    billstatus = "ST"
                                    sqlstring = "UPDATE KOT_HDR SET "
                                    sqlstring = sqlstring & "BillStatus='" & billstatus & "',Crostatus='N',PaymentType ='" & Trim(Me.cbo_PaymentMode.Text) & "',Paymodeaccountcode ='" & Trim(paymentaccountcode) & " ',"
                                    sqlstring = sqlstring & " SubPaymentMode ='" & Trim(SubpaymentMode(0)) & "',subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ' WHERE Kotdetails='" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "'"
                                    j = j + 1
                                    Update(j) = sqlstring

                                    'sqlstring = " UPDATE KOT_DET SET BillDetails='" & Trim(taxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    'sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "' and Isnull(CATEGORY,'')= 'BAR'"
                                    sqlstring = " UPDATE KOT_DET SET BillDetails='" & Trim(taxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "' "

                                    j = j + 1
                                    Update(j) = sqlstring
                                    j = j + 1
                                    TaxTotal = TaxTotal + Val(Taxdr(i).Item("TaxAmount"))
                                    TotalAmount = TotalAmount + Val(Taxdr(i).Item("Amount"))
                                    TotPackAmt = TotPackAmt + Val(Taxdr(i).Item("PACKAMOUNT"))
                                    TotTipsAmt = TotTipsAmt + Val(Taxdr(i).Item("TipsAmt"))
                                    TotAdAmt = TotAdAmt + Val(Taxdr(i).Item("AdCgsAmt"))
                                    TotPartyAmt = TotPartyAmt + Val(Taxdr(i).Item("PartyAmt"))
                                    TotRoomAmt = TotRoomAmt + Val(Taxdr(i).Item("RoomAmt"))
                                Next i

                                jrnsql1 = ""
                                For i = 0 To Taxdr.Length - 1
                                    If i = 0 Then
                                        jrnsql = ""
                                        jrnsql = " Select *  into " & vOutfile & "  From kot_det where kotdetails in('" & Trim(CStr(Taxdr(i).Item("KotDetails")))
                                    Else
                                        jrnsql = jrnsql & "','" & Trim(CStr(Taxdr(i).Item("KotDetails")))
                                    End If
                                    'jrnsql1 = jrnsql1 & " UPDATE " & vOutfile & " SET BillDetails='" & Trim(taxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    'jrnsql1 = jrnsql1 & " WHERE Kotdetails='" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "' and Isnull(CATEGORY,'')= 'BAR' "
                                    jrnsql1 = jrnsql1 & " UPDATE " & vOutfile & " SET BillDetails='" & Trim(taxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    jrnsql1 = jrnsql1 & " WHERE Kotdetails='" & Trim(CStr(Taxdr(i).Item("KotDetails"))) & "' "
                                Next


                                If PAY = "ROOM CHECKIN" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,SECCODE,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & TaxTotal & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(Me.txt_ServerCode.Text) & "','','N'," & Val(Me.txt_MemberCode.Text) & ","
                                    sqlstring = sqlstring & "" & Val(Me.txt_MemberCode.Tag) & ",'" & Trim(Me.txt_MemberName.Text) & "','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf cbo_PaymentMode.SelectedItem = "R.MEMBER" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,SECCODE,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If

                                    'sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & txt_MemberCode.Text & "','" & txt_MemberName.Text & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "COUPON" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,SECCODE,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    'sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & txt_MemberCode.Text & "','" & txt_MemberName.Text & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "CLUB ACCOUNT" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,SECCODE,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "MEMBER ACCOUNT" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,SECCODE,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","

                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','BAR','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf cbo_PaymentMode.SelectedItem = "SCARD" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "',"
                                    sqlstring = sqlstring & "'','N',0,0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','BAR','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"

                                ElseIf cbo_PaymentMode.SelectedItem = "CARD" Then
                                    '''************************************************** $ IF PAYMENTMODE IS "CARD"  $ ********************************************'''
                                    If CStr(cbo_PaymentMode.Text) = "CARD" Then
                                        If smartcardbool = True Then
                                            sqlstring = "SELECT Minimumusage FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                            gconnection.getDataSet(sqlstring, "MinimumusageMaster")
                                            If gdataset.Tables("MinimumusageMaster").Rows.Count > 0 Then
                                                If Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) = 0 Then
                                                    sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                                    gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                                    If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                                        If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(txt_BillAmount.Text) Then
                                                            sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Math.Round(Val(TotalAmount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                            dblCard = Math.Round(Val(TotalAmount))
                                                            dblMinimum = 0
                                                            ReDim Preserve Update(Update.Length)
                                                            Update(Update.Length - 1) = sqlstring
                                                        Else
                                                            MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                            cbo_PaymentMode.Focus()
                                                            Exit Sub
                                                        End If
                                                    End If
                                                ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) >= Val(TotalAmount) Then
                                                    sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = Minimumusage - " & Math.Round(Val(TotalAmount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                    ReDim Preserve Update(Update.Length)
                                                    Update(Update.Length - 1) = sqlstring
                                                    dblCard = 0
                                                    dblMinimum = Math.Round(Val(TotalAmount))
                                                ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) <= Val(TotalAmount) And Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) > 0 Then
                                                    sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = 0 WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                    ReDim Preserve Update(Update.Length)
                                                    Update(Update.Length - 1) = sqlstring
                                                    dblMinimum = Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                                    CardAmount = Math.Round(Val(TotalAmount)) - Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                                    sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                                    gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                                    If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                                        If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(TotalAmount) Then
                                                            sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Format(Val(CardAmount), "0.00") & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                            ReDim Preserve Update(Update.Length)
                                                            Update(Update.Length - 1) = sqlstring
                                                            dblCard = Format(Val(CardAmount), "0.00")
                                                        Else
                                                            MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                            cbo_PaymentMode.Focus()
                                                            Exit Sub
                                                        End If
                                                    End If
                                                Else
                                                    MessageBox.Show("!!! Warning !!! Recharge your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    cbo_PaymentMode.Focus()
                                                    Exit Sub
                                                End If
                                            Else
                                                MessageBox.Show("!!! Sorry !!! Transaction can't be proceed ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                Exit Sub
                                            End If
                                        End If
                                    End If

                                    '''***************************************************** $ COMPLETE CALCULATION FOR CARD PAYMENTMODE **********************************************************************'''
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,SECCODE,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'," & Format(Val(dblMinimum), "0.00") & "," & Format(Val(dblCard), "0.00") & ",'" & Trim(CStr(Txt_Remarks.Text)) & "','" & seccode & "','BAR','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                Else
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(taxbillno)) & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "',"
                                    sqlstring = sqlstring & "'','N',0,0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','BAR','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                End If
                                Update(j) = sqlstring
                                TaxApp = True
                                ttaxtotal = TaxTotal + TotPackAmt + TotTipsAmt + TotAdAmt + TotPartyAmt + TotRoomAmt
                                ttotal = TotalAmount
                            End If
                            If NoTaxDr.Length > 0 Then
                                TaxTotal = 0
                                TotalAmount = 0
                                TotPackAmt = 0
                                TotTipsAmt = 0
                                TotAdAmt = 0
                                TotPartyAmt = 0
                                TotRoomAmt = 0
                                '''************************************************** $ IF TAX ITEM IS INSERTED  $ ********************************************'''
                                If Val(j) > 0 Then
                                    j = j + 1
                                End If
                                If OLDBILLDETAILS = "" Then
                                    OLDBILLDETAILS = Oldtaxbilldetails
                                End If
                                For i = 0 To NoTaxDr.Length - 1

                                    sqlstring = " INSERT INTO Bill_Det(Billno,BillDetails,BillDate,KotDetails,TaxAmount,KotAmount,OthBilldetails,KotDate,TaxCode,CATEGORY,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES("
                                    sqlstring = sqlstring & "'" & Trim(CStr(nontaxbillno)) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Trim(CStr(NoTaxDr(i).Item("KotDetails"))) & "',"
                                    sqlstring = sqlstring & "" & Val(NoTaxDr(i).Item("TaxAmount")) & "," & Val(NoTaxDr(i).Item("Amount")) & ",'" & Trim(OLDBILLDETAILS) & "','" & Format(CDate(NoTaxDr(i).Item("KotDate")), "dd-MMM-yyyy") & "','" & Trim(NoTaxDr(i).Item("Taxcode")) & "','CANTEEN'," & Val(NoTaxDr(i).Item("PACKAMOUNT")) & "," & Val(NoTaxDr(i).Item("TipsAmt")) & "," & Val(NoTaxDr(i).Item("AdCgsAmt")) & "," & Val(NoTaxDr(i).Item("PartyAmt")) & "," & Val(NoTaxDr(i).Item("RoomAmt")) & ")"
                                    Update(j) = sqlstring

                                    billstatus = "ST"
                                    sqlstring = "UPDATE KOT_HDR SET "
                                    sqlstring = sqlstring & "BillStatus='" & billstatus & "',Crostatus='N',PaymentType ='" & Trim(Me.cbo_PaymentMode.Text) & "',Paymodeaccountcode ='" & Trim(paymentaccountcode) & " ',"
                                    sqlstring = sqlstring & "SubPaymentMode ='" & Trim(SubpaymentMode(0)) & "',subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ' WHERE Kotdetails='" & Trim(CStr(NoTaxDr(i).Item("KotDetails"))) & "'"
                                    j = j + 1
                                    Update(j) = sqlstring


                                    sqlstring = "UPDATE KOT_DET SET BillDetails='" & Trim(nontaxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    sqlstring = sqlstring & "WHERE Kotdetails='" & Trim(CStr(NoTaxDr(i).Item("KotDetails"))) & "' "

                                    j = j + 1
                                    Update(j) = sqlstring
                                    j = j + 1
                                    TaxTotal = TaxTotal + Val(NoTaxDr(i).Item("TaxAmount"))
                                    TotalAmount = TotalAmount + Val(NoTaxDr(i).Item("Amount"))
                                    TotPackAmt = TotPackAmt + Val(NoTaxDr(i).Item("PACKAMOUNT"))
                                    TotTipsAmt = TotTipsAmt + Val(NoTaxDr(i).Item("TipsAmt"))
                                    TotAdAmt = TotAdAmt + Val(NoTaxDr(i).Item("AdCgsAmt"))
                                    TotPartyAmt = TotPartyAmt + Val(NoTaxDr(i).Item("PartyAmt"))
                                    TotRoomAmt = TotRoomAmt + Val(NoTaxDr(i).Item("RoomAmt"))
                                Next

                                For i = 0 To NoTaxDr.Length - 1
                                    If jrnsql = "" Then
                                        jrnsql = " Select *  into " & vOutfile & "  From kot_det where kotdetails in('" & Trim(CStr(NoTaxDr(i).Item("KotDetails")))
                                    Else
                                        jrnsql = jrnsql & "','" & Trim(CStr(NoTaxDr(i).Item("KotDetails")))
                                    End If
                                    jrnsql1 = jrnsql1 & " UPDATE " & vOutfile & " SET BillDetails='" & Trim(nontaxbilldetails) & "',PAYMENTMODE='" & Trim(Me.cbo_PaymentMode.Text) & "' "
                                    jrnsql1 = jrnsql1 & " WHERE Kotdetails='" & Trim(CStr(NoTaxDr(i).Item("KotDetails"))) & "'  "
                                Next



                                If PAY = "ROOM CHECKIN" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(Me.txt_ServerCode.Text) & "','','N'," & Val(Me.txt_MemberCode.Text) & ","
                                    sqlstring = sqlstring & "" & Val(Me.txt_MemberCode.Tag) & ",'" & Trim(Me.txt_MemberName.Text) & "','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "R.MEMBER" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & txt_MemberCode.Text & "','" & txt_MemberName.Text & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "COUPON" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & txt_MemberCode.Text & "','" & txt_MemberName.Text & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "CLUB ACCOUNT" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & txt_MemberCode.Text & "','" & txt_MemberName.Text & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "MEMBER ACCOUNT" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    'sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Math.Round(Val(Me.txt_BillAmount.Text)) & ","
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','CANTEEN','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                ElseIf PAY = "CARD" Then
                                    '''************************************************** $ IF PAYMENTMODE IS "CARD"  $ ********************************************'''
                                    If CStr(PAY) = "CARD" Then
                                        If smartcardbool = True Then
                                            sqlstring = "SELECT Minimumusage FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                            gconnection.getDataSet(sqlstring, "MinimumusageMaster")
                                            If gdataset.Tables("MinimumusageMaster").Rows.Count > 0 Then
                                                If Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) = 0 Then
                                                    sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                                    gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                                    If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                                        If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(txt_BillAmount.Text) Then
                                                            sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Math.Round(Val(TotalAmount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                            dblCard = Math.Round(Val(TotalAmount))
                                                            dblMinimum = 0
                                                            ReDim Preserve Update(Update.Length)
                                                            Update(Update.Length - 1) = sqlstring
                                                        Else
                                                            MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                            cbo_PaymentMode.Focus()
                                                            Exit Sub
                                                        End If
                                                    End If
                                                ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) >= Val(TotalAmount) Then
                                                    sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = Minimumusage - " & Math.Round(Val(TotalAmount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                    ReDim Preserve Update(Update.Length)
                                                    Update(Update.Length - 1) = sqlstring
                                                    dblCard = 0
                                                    dblMinimum = Math.Round(Val(TotalAmount))
                                                ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) <= Val(TotalAmount) And Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) > 0 Then
                                                    sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = 0 WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                    ReDim Preserve Update(Update.Length)
                                                    Update(Update.Length - 1) = sqlstring
                                                    dblMinimum = Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                                    CardAmount = Math.Round(Val(TotalAmount)) - Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                                    sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                                    gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                                    If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                                        If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(TotalAmount) Then
                                                            sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Format(Val(CardAmount), "0.00") & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                                            ReDim Preserve Update(Update.Length)
                                                            Update(Update.Length - 1) = sqlstring
                                                            dblCard = Format(Val(CardAmount), "0.00")
                                                        Else
                                                            MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                            cbo_PaymentMode.Focus()
                                                            Exit Sub
                                                        End If
                                                    End If
                                                Else
                                                    MessageBox.Show("!!! Warning !!! Recharge your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    cbo_PaymentMode.Focus()
                                                    Exit Sub
                                                End If
                                            Else
                                                MessageBox.Show("!!! Sorry !!! Transaction can't be proceed ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                Exit Sub
                                            End If
                                        End If
                                    End If
                                    '''***************************************************** $ COMPLETE CALCULATION FOR CARD PAYMENTMODE **********************************************************************'''
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & Trim(CStr(nontaxbillno)) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & Trim(CStr(nontaxbillno)) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'," & Format(Val(dblMinimum), "0.00") & "," & Format(Val(dblCard), "0.00") & ",'" & Trim(CStr(Txt_Remarks.Text)) & "','CANTEEN','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                Else
                                    sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,TaxAmount,BillAmount,Roundoff,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,servicelocation,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,CATEGORY,[16_digit_code],cardholdercode,cardholdername,PACKAMOUNT,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Math.Round(Val(TotalAmount)) & "," & Amt & ","
                                    Else
                                        sqlstring = sqlstring & "('" & CStr(nontaxbillno) & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(TaxTotal) & "," & Val(TotalAmount) & "," & Amt & ","
                                    End If
                                    sqlstring = sqlstring & "'" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "',"
                                    sqlstring = sqlstring & "'','N',0,0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','CANTEEN','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "'," & Val(TotPackAmt) & "," & Val(TotTipsAmt) & "," & Val(TotAdAmt) & "," & Val(TotPartyAmt) & "," & Val(TotRoomAmt) & ")"
                                End If
                                j = j + 1
                                Update(j) = sqlstring
                                tntaxtotal = TaxTotal + TotPackAmt + TotTipsAmt + TotAdAmt + TotPartyAmt + TotRoomAmt
                                tntotal = TotalAmount
                            End If

                            'If NoTaxDr.Length > 0 And Taxdr.Length > 0 Then
                            '    sqlstring = "Update PoSKotDoc Set DocNo = " & Val(nontaxbillno) & ",DOCFLAG='N' Where DocType = '" & Trim(BillPrefix) & "'"
                            'ElseIf Taxdr.Length > 0 Then
                            '    sqlstring = "Update PoSKotDoc Set DocNo = " & Val(taxbillno) & " ,DOCFLAG='N' Where DocType = '" & Trim(BillPrefix) & "'"
                            'ElseIf NoTaxDr.Length > 0 Then
                            '    sqlstring = "Update PoSKotDoc Set DocNo = " & Val(nontaxbillno) & " ,DOCFLAG='N' Where DocType = '" & Trim(BillPrefix) & "'"
                            'End If
                            ''gconnection.dataOperation(7, sqlstring, "PosKotDoc")
                            'ReDim Preserve Update(Update.Length)
                            'Update(Update.Length - 1) = sqlstring
                            ''============================================================================
                            'If Len(Oldtaxbillno) > 0 Then
                            ''**************************Inserting Data into ROOM LEDGER table **************************************
                            If PAY = "ROOM CHECKIN" Then
                                If Len(Oldtaxbillno) > 0 Then
                                    sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                                    sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO)"
                                    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(taxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','SALES',1," & Val(txt_BillAmount.Text) & ","
                                    sqlstring = sqlstring & "'" & loccode & "'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','DEBIT','ROOM','RM','RM',1)"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                    'gconnection.dataOperation(6, sqlstring, "ROOMLEDGER")
                                    'End If
                                ElseIf Len(Oldnontaxbillno) > 0 Then
                                    sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                                    sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO)"
                                    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(nontaxbilldetails)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','SALES',1," & Math.Round(Val(tntaxtotal) + Val(tntotal)) & ","
                                    sqlstring = sqlstring & "'" & loccode & "'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','DEBIT','ROOM','RM','RM',1)"
                                    'gconnection.dataOperation(1, sqlstring, "ROOMLEDGER")
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                Else
                                    sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                                    sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO,salestype)"
                                    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_BillNo.Text)) & "','" & Format(CDate(Me.dtp_BillDate.Value), "dd-MMM-yyyy") & "','SALES',1," & Val(txt_BillAmount.Text) & ","
                                    sqlstring = sqlstring & "'" & poscode & "'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','DEBIT','ROOM','RM','RM',1,'POSSALE')"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                    'If Val(txt_TaxValue.Text) > 0 Then
                                    '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                                    '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                                    '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','VAT',1," & Val(txt_TaxValue.Text) & ","
                                    '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                                    '    ReDim Preserve Update(Update.Length)
                                    '    Update(Update.Length - 1) = sqlstring
                                    'End If

                                    'If Val(txt_PackingCharge.Text) > 0 Then
                                    '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                                    '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                                    '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_PackingCharge.Text) & ","
                                    '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                                    '    ReDim Preserve Update(Update.Length)
                                    '    Update(Update.Length - 1) = sqlstring
                                    'End If
                                    'If Val(Me.txt_tips.Text) > 0 Then
                                    '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                                    '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                                    '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','TIPS',1," & Val(txt_tips.Text) & ","
                                    '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                                    '    ReDim Preserve Update(Update.Length)
                                    '    Update(Update.Length - 1) = sqlstring
                                    'End If
                                    'If Val(Me.txt_acchg.Text) > 0 Then
                                    '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                                    '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                                    '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','ACCHG',1," & Val(txt_acchg.Text) & ","
                                    '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                                    '    ReDim Preserve Update(Update.Length)
                                    '    Update(Update.Length - 1) = sqlstring
                                    'End If
                                End If
                            End If

                            '---------------------
                            'Settlement 
                            'begin
                            With ssgrid_settlement
                                'If cbo_PaymentMode.SelectedItem <> "ROOM" Then
                                If .DataRowCnt = 1 Or .DataRowCnt = 0 Then
                                    sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,deleteflag,SBILLFLAG) "
                                    sqlstring = sqlstring & "VALUES('" & txt_BillNo.Text & "','" & Format(dtp_BillDate.Value, "dd/MMM/yyyy") & "',"
                                    sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "'," & txt_BillAmount.Text & ",'','N','N')"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring

                                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='N' WHERE BILLDETAILS='" & txt_BillNo.Text & "'"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                Else
                                    For i = 1 To .DataRowCnt
                                        sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,DELETEFLAG,SBILLFLAG) "
                                        sqlstring = sqlstring & "VALUES('" & txt_BillNo.Text & "','" & Format(dtp_BillDate.Value, "dd/MMM/yyyy") & "',"
                                        .Col = 1
                                        .Row = i
                                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                                        .Col = 2
                                        .Row = i
                                        sqlstring = sqlstring & Math.Round(Val(Trim(.Text)), 2) & ","
                                        .Col = 3
                                        .Row = i
                                        sqlstring = sqlstring & "'" & Trim(.Text) & "','N','Y')"
                                        ReDim Preserve Update(Update.Length)
                                        Update(Update.Length - 1) = sqlstring
                                    Next
                                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='Y' WHERE BILLDETAILS='" & txt_BillNo.Text & "'"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                End If
                                'End If
                            End With
                            '---------------------
                            'Settlement 
                            'end
                            'BILL_JOURNALENTRY 
                            'begin


                            If Len(jrnsql) > 0 Then
                                jrnsql = jrnsql & "')"
                            End If

                            ReDim Preserve Update2(Update2.Length)
                            Update2(Update2.Length - 1) = jrnsql
                            ReDim Preserve Update2(Update2.Length)
                            Update2(Update2.Length - 1) = jrnsql1

                            gconnection.MoreTransold1(Update2)

                            sqlstring = "SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN, ISNULL(SALECOSTCENTERCODE,'') AS         SALECOSTCENTERCODE, ISNULL(SALECOSTCENTERDESC,'') AS SALECOSTCENTERDESC FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' And ISNULL(SUBPAYSTATUS,'')<>'Y'"
                            gconnection.getDataSet(sqlstring, "AccountIn")
                            If (gdataset.Tables("AccountIn").Rows.Count > 0) Then
                                strAccountIn = Trim(gdataset.Tables("AccountIn").Rows(0).Item("AccountIn"))
                                strSaleCostAccountIn = Trim(gdataset.Tables("AccountIn").Rows(0).Item("SALECOSTCENTERCODE"))
                                strSaleCostAccountInDesc = Trim(gdataset.Tables("AccountIn").Rows(0).Item("SALECOSTCENTERDESC"))
                            Else
                                sqlstring = "SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN, ISNULL(SALECOSTCENTERCODE,'') AS         SALECOSTCENTERCODE, ISNULL(SALECOSTCENTERDESC,'') AS SALECOSTCENTERDESC FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "'ISNULL(SUBPAYSTATUS,'')='N'"
                                strAccountIn = ""
                                strSaleCostAccountIn = ""
                                strSaleCostAccountInDesc = ""
                            End If
                            If Me.cbo_SubPaymentMode.Visible = True Then
                                strAccountIn = Subpaymentaccountcode
                            End If

                            sqlstring = "SELECT ISNULL(MAX(ISNULL(BATCHNO,0)),0) AS BATCHNO FROM BILL_JOURNALENTRY"
                            gconnection.getDataSet(sqlstring, "BatchNo")
                            If (gdataset.Tables("BatchNo").Rows.Count > 0) Then
                                strBatchNo = Trim(gdataset.Tables("BatchNo").Rows(0).Item("BATCHNO"))
                            Else
                                strBatchNo = ""
                            End If
                            If (strAccountIn <> "") Then
                                sqlstring = "SELECT ISNULL(ACDESC,'') AS ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACCODE = '" & strAccountIn & "'"
                                gconnection.getDataSet(sqlstring, "AccountDesc")
                                If (gdataset.Tables("AccountDesc").Rows.Count > 0) Then
                                    strAccountDesc = Trim(gdataset.Tables("AccountDesc").Rows(0).Item("ACDESC"))
                                Else
                                    strAccountDesc = ""
                                End If
                            End If


                            If Trim(taxbilldetails) <> "" And Trim(nontaxbilldetails) <> "" Then
                                BillDetails = "'" & Trim(taxbilldetails) & "'" & ",'" & Trim(nontaxbilldetails) & "'"
                            ElseIf Trim(taxbilldetails) <> "" Then
                                BillDetails = "'" & Trim(taxbilldetails) & "'"
                            Else
                                BillDetails = "'" & Trim(nontaxbilldetails) & "'"

                            End If
                            'If Trim(nontaxbilldetails) <> "" Then
                            '    BillDetails = BillDetails & ",'" & Trim(nontaxbilldetails) & "'"
                            'End If
                            'Call CHECKACCPOST()
                            'If ACCPOST = True Then

                            sqlstring = " Delete From  BILL_JOURNALENTRY Where voucherno  IN ( " & Trim(BillDetails) & ")"
                            ReDim Preserve Update(Update.Length)
                            Update(Update.Length - 1) = sqlstring
                            STMcode = Trim(txt_MemberCode.Text)

                            'TAXCODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART

                            sqlstring = "Select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.TaxAMOUNT),0) as Amount,Isnull(B.Acdesc,'') as Acdesc,"
                            sqlstring = sqlstring & "Isnull(A.Taxaccountcode,'') as Acctcode From " & vOutfile & "  A,Accountsglaccountmaster B "
                            sqlstring = sqlstring & "Where Isnull(delFlag,'')<>'Y'  And A.TAXAccountcode=b.Accode "
                            sqlstring = sqlstring & "And Isnull(Billdetails,'') IN ( " & Trim(BillDetails) & ")"
                            sqlstring = sqlstring & "Group by A.Taxaccountcode,A.billdetails,B.Acdesc "
                            gconnection.getDataSet(sqlstring, "JrnTax")
                            Jnltaxamount = 0
                            If (gdataset.Tables("JrnTax").Rows.Count > 0) Then
                                For K = 0 To gdataset.Tables("JrnTax").Rows.Count - 1
                                    strBatchNo = strBatchNo + 1
                                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"

                                    Jnltaxamount = Jnltaxamount + Val(gdataset.Tables("Jrntax").Rows(K).Item("Amount"))
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                Next
                            End If
                            'ACCOUNTS CODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART

                            sqlstring = "select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.AMOUNT),0) as Amount,"
                            sqlstring = sqlstring & "Isnull(A.SalesAccountcode,'') as AcctCode,Isnull(B.Acdesc,'') as Acdesc From  " & vOutfile & " A, "
                            sqlstring = sqlstring & "Accountsglaccountmaster B Where Isnull(A.delFlag,'')<>'Y' "
                            sqlstring = sqlstring & "And Isnull(A.billdetails,'') IN ( " & Trim(BillDetails) & ")  And A.SalesAccountcode=B.Accode "
                            sqlstring = sqlstring & "Group by A.SalesAccountcode,A.billdetails,B.Acdesc "
                            gconnection.getDataSet(sqlstring, "JrnAcct")
                            If (gdataset.Tables("JrnAcct").Rows.Count > 0) Then
                                Jnlamount = 0
                                For K = 0 To gdataset.Tables("JrnAcct").Rows.Count - 1
                                    strBatchNo = strBatchNo + 1
                                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                                    Jnlamount = Jnlamount + Val(gdataset.Tables("JrnAcct").Rows(K).Item("Amount"))
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                Next
                            End If
                            'MEMBER CODE WISE INSERT IN BILL_JOURNALENTRY - DEBIT PART
                            With ssgrid_settlement
                                If .DataRowCnt > 1 Then
                                    .SetActiveCell(1, 1)
                                    For K = 1 To .DataRowCnt
                                        STMcode = ""
                                        _Billamount = 0.0
                                        .Row = K
                                        .Col = 1
                                        STMcode = .Text
                                        .Row = K
                                        .Col = 2
                                        _Billamount = .Text
                                        strBatchNo = strBatchNo + 1

                                        If PAY = "CARD" Or PAY = "CASH" Then
                                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SLCODE,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                            sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','','',"
                                            'sqlstring = sqlstring & Trim(STMcode) & "','',"
                                            sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                        ElseIf PAY = "ROOM" Then
                                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,ROOMNO,SlDesc,REF_NO,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                            sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                            sqlstring = sqlstring & Trim(STMcode) & "','','" & txt_MemberCode.Tag & "',"
                                            sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                        Else
                                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                            sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                            sqlstring = sqlstring & Trim(STMcode) & "','',"
                                            sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                        End If

                                        ReDim Preserve Update(Update.Length)
                                        Update(Update.Length - 1) = sqlstring
                                    Next
                                Else
                                    strBatchNo = strBatchNo + 1

                                    If PAY = "CARD" Or PAY = "CASH" Then
                                        sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SLCODE,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                        sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','','',"
                                        'sqlstring = sqlstring & Trim(STMcode) & "','',"
                                        sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                        sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                    ElseIf PAY = "ROOM CHECKIN" Then
                                        sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,ROOMNO,SlDesc,REF_NO,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                        sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                        sqlstring = sqlstring & Trim(txt_MemberCode.Text) & "','','" & txt_MemberCode.Tag & "',"
                                        sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                        sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                    Else
                                        sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                        sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                        sqlstring = sqlstring & Trim(txt_MemberCode.Text) & "','',"
                                        sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                        sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                    End If

                                    'sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                    'sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Mid(Trim(txt_BillNo.Text), 1, 3) & "','" & Trim(txt_BillNo.Text) & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                    'sqlstring = sqlstring & Trim(txt_MemberCode.Text) & "','" & txt_MemberName.Text & "',"
                                    'sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                    'sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_BillNo.Text), 1, 3) & "')"
                                    ReDim Preserve Update(Update.Length)
                                    Update(Update.Length - 1) = sqlstring
                                End If
                            End With
                            'End If
                            sqlstring = " Drop Table  " & vOutfile
                            ReDim Preserve Update(Update.Length)
                            Update(Update.Length - 1) = sqlstring

                            'vijay26122011 triggerupdate
                            'sqlstring = "update kot_det set  billdetails=b.billdetails from bill_det b inner join bill_hdr c on b.billdetails=c.BillDetails where b.kotdetails=kot_det.kotdetails and isnull(kot_det.billdetails,'')='" & Trim(txt_BillNo.Text) & "' and ISNULL(c.delflag,'')<>'y'"
                            sqlstring = "update kot_det set  billdetails=b.billdetails from bill_det b inner join bill_hdr c on b.billdetails=c.BillDetails where b.kotdetails=kot_det.kotdetails and isnull(kot_det.billdetails,'')='" & Trim(txt_BillNo.Text) & "' and ISNULL(c.delflag,'')<>'y'"

                            gconnection.dataOperation(9, sqlstring, "CAT")
                            'sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM VIEW_ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"

                            'CHECK BILLNO--------BEGIN
                            sqlstring = "select * from BILL_HDR where BILLdetails='" & txt_BillNo.Text & "'"
                            gconnection.getDataSet(sqlstring, "BILLNO")
                            If gdataset.Tables("BILLNO").Rows.Count > 0 Then
                                If gCenterlized = "Y" Then
                                    sqlstring = "SELECT MAX(BILLNO)  AS BNO FROM BILL_HDR WHERE SUBSTRING(BILLDETAILS,1,3)='" & Mid(gDocType, 1, 3) & "'"
                                Else
                                    sqlstring = "SELECT MAX(BILLNO)  AS BNO FROM BILL_HDR WHERE SUBSTRING(BILLDETAILS,1,3)='" & Mid(DOCTYPE, 1, 3) & "'"
                                End If
                                gconnection.getDataSet(sqlstring, "BNO")
                                If gdataset.Tables("BNO").Rows.Count > 0 Then
                                    'sqlstring = "Update PoSKotDoc Set DocNo = " & gdataset.Tables("BNO").Rows(0).Item("BNO") & " WHERE DOCFLAG='N' And DocType = '" & BillPrefix & "'"
                                    'gconnection.dataOperation(9, sqlstring, "upd")
                                    Call Cmd_Add_Click(sender, e)
                                End If
                            Else
                                '                    gconnection.MoreTransold(Update)
                                'CSC SMARTCARD
                                '****************SHOW SMART CARD CARD TRANSACTION*****************

                                Dim STRSQL2, SSTR As String
                                'STRSQL2 = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & cardcode & "' AND POSCODE='" & StrPOSCODE & "'"
                                STRSQL2 = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & cardcode & "' "
                                gconnection.getDataSet(STRSQL2, "SM_CARDFILE_DET")
                                If gdataset.Tables("SM_CARDFILE_DET").Rows.Count > 0 Then
                                    POS_AMT_GBL = Val(txt_BillAmount.Text)
                                    STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & STRPOSCODE & "' AND STORETYPE = 'FF' "
                                    gconnection.getDataSet(STRSQL2, "FACILITY")
                                    If gdataset.Tables("FACILITY").Rows.Count > 0 Then
                                        'ONCE FACILITY 
                                        KOT_NO_GBL = Trim(txt_BillNo.Text)
                                        gconnection.MoreTransold(Update)
                                        sqlstring = "update bill_hdr set instype='" & Me.cmb_instype.Text & "' ,insno='" & Me.txt_insno.Text & "' where billdetails ='" & Me.txt_BillNo.Text & "'"
                                        gconnection.dataOperation(9, sqlstring, "ins")


                                        'If CHK_PRINT.Checked = True Then
                                        '    Call Cmd_Print_Click(Cmd_Print, e)
                                        '    Call Cmd_Clear_Click(sender, e)
                                        '    If kotupdate = True Then
                                        '        Me.Close()
                                        '    End If
                                        'Else
                                        '    Call Cmd_Clear_Click(sender, e)
                                        '    If kotupdate = True Then
                                        '        Me.Close()
                                        '    Else
                                        '        Me.Close()
                                        '    End If
                                        'End If

                                        'SSTR = "SELECT * FROM SM_POSTRANSACTION WHERE BILL_NO='" & Trim(KOT_NO_GBL) & "'"
                                        'gconnection.getDataSet(SSTR, "SM_POSTRANSACTION")
                                        'If gdataset.Tables("SM_POSTRANSACTION").Rows.Count > 0 Then
                                        '    Dim DE_TRA_AMEND As New DEBIT_CARD_TRANSACTION
                                        '    D_CARDUPDATE = True
                                        '    DE_TRA_AMEND.Show()
                                        'Else
                                        '    Dim DE_TRA As New DEBIT_CARD_TRANSACTION
                                        '    D_CARDUPDATE = False
                                        '    DE_TRA.Show()
                                        'End If
                                        'Call Autogenerate()

                                        'Dim dc_tra As New DEBIT_CARD_TRANSACTION
                                        'dc_tra.FormBorderStyle = FormBorderStyle.FixedToolWindow
                                        'dc_tra.MdiParent = MDIParentobj
                                        'dc_tra.Show()

                                        Exit Sub
                                    Else
                                        'CSC SMART CARD CARD
                                        '****************SHOW SMART CARD CARD TRANSACTION*****************
                                        Dim STRSQL As String
                                        If PAY = "SMART CARD" Then
                                            'SALE SMARTCARD 
                                            'POSCODE GBL  HARDCODE TO KITCHEN 
                                            'KARTHI CHECK MIN BALANCE AND PROCEED FOR CARD BALANCE
                                            'NOV 14
                                            If MIN_USAGE_BALANCE_HDR >= Val(TOTALBILL) Then

                                                STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ('" & txt_card_id.Text & "', '" & cardcode & "','" & STRPOSCODE & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_BillNo.Text) & "'," & Val(txt_BillAmount.Text) & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FM')"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL

                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & Val(txt_BillAmount.Text) & " WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL


                                            ElseIf MIN_USAGE_BALANCE_HDR <= 0 Then
                                                'DEDUCT AMOUNT ONLY FROM CARD

                                                Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                                                DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR
                                                DEDUCT_FROM_CARD = Val(TOTALBILL) - MIN_USAGE_BALANCE_HDR

                                                'FOR BALANCE
                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL

                                                'FOR EBALANCE

                                                Dim BALstr, EBAL As String
                                                Dim BALnum As Double
                                                sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                                                gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
                                                If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                                                    If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                                                        BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) - Val(DEDUCT_FROM_CARD)
                                                    Else '--for zero
                                                        BALnum = 0 - Val(DEDUCT_FROM_CARD)
                                                    End If
                                                End If
                                                EBAL = abcdADD(BALnum)

                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL
                                                'END

                                                STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & STRPOSCODE & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_BillNo.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FC')"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL

                                            ElseIf MIN_USAGE_BALANCE_HDR > 0 And MIN_USAGE_BALANCE_HDR < Val(txt_BillAmount.Text) Then

                                                Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                                                DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR
                                                DEDUCT_FROM_CARD = Val(TOTALBILL) - MIN_USAGE_BALANCE_HDR

                                                STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & STRPOSCODE & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_BillNo.Text) & "'," & DEDUCT_FROM_MINUSAGE & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HM')"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL


                                                STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & STRPOSCODE & "','" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_BillNo.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HC')"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL


                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & DEDUCT_FROM_MINUSAGE & " WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL

                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL

                                                'FOR EBALANCE

                                                Dim BALstr, EBAL As String
                                                Dim BALnum As Double
                                                sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                                                gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
                                                If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                                                    If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                                                        BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) - Val(DEDUCT_FROM_CARD)
                                                    Else '--for zero
                                                        BALnum = 0 - Val(DEDUCT_FROM_CARD)
                                                    End If
                                                End If
                                                EBAL = abcdADD(BALnum)

                                                STRSQL = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                                                ReDim Preserve Update(Update.Length)
                                                Update(Update.Length - 1) = STRSQL
                                                'END

                                            End If
                                            'Else
                                            '   STRSQL = " INSERT INTO SM_POSTRANSACTION (CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & cardcode & "','" & StrPOSCODE & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & Val(txt_BillAmount.Text) & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','O')"
                                            '  ReDim Preserve Insert(Insert.Length)
                                            ' Insert(Insert.Length - 1) = STRSQL
                                        End If

                                        gconnection.MoreTransold(Update)
                                        sqlstring = "update bill_hdr set instype='" & Me.cmb_instype.Text & "' ,insno='" & Me.txt_insno.Text & "' where billdetails ='" & Me.txt_BillNo.Text & "'"
                                        gconnection.dataOperation(9, sqlstring, "ins")

                                    End If
                                Else
                                    gconnection.MoreTransold(Update)

                                    sqlstring = "update bill_hdr set instype='" & Me.cmb_instype.Text & "' ,insno='" & Me.txt_insno.Text & "' where billdetails ='" & Me.txt_BillNo.Text & "'"
                                    gconnection.dataOperation(9, sqlstring, "ins")

                                End If
                            End If

                            sqlstring = "UPDATE BILL_HDR SET ROUNDOFF=ROUND(TOTALAMOUNT,0)-TOTALAMOUNT WHERE BILLDETAILS  IN ( " & Trim(BillDetails) & ")"
                            gconnection.getDataSet(sqlstring, "ROFF")
                            sqlstring = "UPDATE BILL_HDR SET Discountamount=0 WHERE BILLDETAILS  IN ( " & Trim(BillDetails) & ")"
                            gconnection.getDataSet(sqlstring, "ROFF")

                        End If
                    Next
                End If

                If CHK_PRINT.Checked = True Then
                    If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                        Call Cmd_Print_Click(Cmd_View, e)
                        Call Cmd_Clear_Click(sender, e)
                        '***********CHANGE
                        MNAME_GBL = ""
                        MCODE_GBL = ""
                        cardcode = ""
                        NAME_GBL = ""
                        '***********CHANGE
                        If kotupdate = True Then
                            Me.Close()
                        End If
                    Else
                        Call Cmd_Clear_Click(sender, e)
                        If kotupdate = True Then
                            Me.Close()
                        End If
                    End If
                End If
                Exit Sub
                If Trim(txt_card_id.Text) = "" And PAY = "SCARD" Then
                    MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Sub
                Else
                    If PAY = "SCARD" Then
                        'Call cardcheck()
                    End If
                End If
                Call txt_MemberCode_Validated(sender, e)
                If gFoto = "Y" Then
                    Call foto.SaveFoto(strPhotoFilePath, Trim(txt_card_id.Text))
                End If
            ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub CMB_BTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_BTYPE.SelectedIndexChanged
        DOCTYPE = CMB_BTYPE.Text
        SQLSTRING = "select poscode from POSMASTER where ISNULL(finalprefix,'') ='" & DOCTYPE & "'"
        gconnection.getDataSet(SQLSTRING, "doc")
        If gdataset.Tables("doc").Rows.Count > 0 Then
            STRPOSCODE = gdataset.Tables("doc").Rows(0).Item("poscode")
        End If
        If gCenterlized = "N" Then
            StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(finalprefix,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ,roundoffyesno,roundval FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
            gconnection.getDataSet(StrSql, "PSETUP")
            If gdataset.Tables("PSETUP").Rows.Count > 0 Then
                pPackPer = gdataset.Tables("PSETUP").Rows(0).Item("PACKPER")
                pTipsPer = gdataset.Tables("PSETUP").Rows(0).Item("TIPS_SER")
                pAdCgsPer = gdataset.Tables("PSETUP").Rows(0).Item("ADCHARGE")
                pPartyPer = gdataset.Tables("PSETUP").Rows(0).Item("PRCHARGE")
                pRoomPer = gdataset.Tables("PSETUP").Rows(0).Item("GRCHARGE")
                pTableReq = gdataset.Tables("PSETUP").Rows(0).Item("TABLEREQ")
                pKotType = gdataset.Tables("PSETUP").Rows(0).Item("KOTTYPE")
                pKotPrefix = gdataset.Tables("PSETUP").Rows(0).Item("KOTPREFIX")
                DefaultPayment = gdataset.Tables("PSETUP").Rows(0).Item("PAYMENTMODE")
                RoundYN = gdataset.Tables("PSETUP").Rows(0).Item("roundoffyesno")
                RndVal = gdataset.Tables("PSETUP").Rows(0).Item("roundval")
            End If
        End If
        Call fillPayment_Mode()
        'Call FillDefaultPayment()
        'Call Enabledcontrol()
        Call Autogenerate()
        'Call ShowBillno()
        'Call GRIDLOCK()
        'Call fillposdocument()
        If gCenterlized = "Y" Then
            Call Autogenerate()
        ElseIf gCenterlized = "N" Then
            Call Autogenerate()
        End If
        sSGrid.ClearRange(1, 1, -1, -1, True)
        If gCenterlized = "Y" Then
            If Mid(gTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        Else
            If Mid(pTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        End If
    End Sub

    Private Sub dtp_BillDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_BillDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbo_PaymentMode.Focus()
        End If
    End Sub
    Private Sub cmb_type_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_type.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Me.cbo_PaymentMode.Focus()
        End If
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim SQLSTRING, DELETE(0), STRKOTDETAILS As String
        Dim VCTR As Integer
        Dim dt As New DataTable
        Dim sql, Otherbillno, SSQL As String
        Dim otherbool As Boolean
        Dim vDocno
        Dim i As Integer
        Dim PAY As String
        PAY = ""
        Dim DT1, DT2 As DataTable
       
        SQLSTRING = "SELECT ISNULL(CHKID,0)AS CHKID FROM KOT_DET WHERE BILLDETAILS='" & Trim(Me.txt_BillNo.Text) & "'"
        DT1 = gconnection.GetValues(SQLSTRING)
        If (DT1.Rows.Count > 0) Then
            If DT1.Rows(0).Item("CHKID") <> "0" Then
                SQLSTRING = "SELECT * FROM ROOMCHECKIN WHERE DOCNO='" & DT1.Rows(0).Item("CHKID") & "' AND ISNULL(CHECKOUT,'')<>'y'"
                DT2 = gconnection.GetValues(SQLSTRING)
                If (DT2.Rows.Count > 0) Then
                Else
                    MsgBox("Sorry, GUEST ALREADY CHECKED OUT , You Can't Delete....")
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            End If
        End If
        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If PAY = "SMART CARD" Then
            SSQL = "select [16_digit_code] as id  from sm_postransaction where bill_no='" & Me.txt_BillNo.Text & "' and ISNULL(void,'')<>'y'"
            gconnection.getDataSet(SSQL, "raj")
            If gdataset.Tables("raj").Rows.Count > 0 Then
                If gdataset.Tables("raj").Rows(0).Item("id") <> Trim(txt_card_id.Text) Then
                    MsgBox("provide correct card")
                    Exit Sub
                End If
            End If
        End If
        'Call FILLCANCELREASON()

        SQLSTRING = "SELECT * FROM MATCHING WHERE VOUCHERNO = '" & Trim(txt_BillNo.Text) & "' AND VOUCHERDATE = '" & Format(dtp_BillDate.Value, "dd-MMM-yyyy") & "'"
        dt = gconnection.GetValues(SQLSTRING)
        If (dt.Rows.Count > 0) Then
            MsgBox("Sorry, Bill Matching Was Already Made, You Can't Delete....")
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        dt = New DataTable

        sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
        gconnection.getDataSet(sql, "Bill_det")
        If gdataset.Tables("Bill_det").Rows.Count > 0 Then
            If gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") <> "" Then

                Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
                otherbool = True
            End If
        Else
            otherbool = False
        End If
        If otherbool = True Then
            BillDetails = Trim(Otherbillno) & "'" & "," & "'" & Trim(Me.txt_BillNo.Text)
        Else
            BillDetails = Trim(Me.txt_BillNo.Text)
        End If

        BillDetails = Trim(Me.txt_BillNo.Text)
        SQLSTRING = "SELECT KOTDETAILS FROM KOT_DET WHERE BILLDETAILS in ('" & Trim(BillDetails) & "'" & ")"
        gconnection.getDataSet(SQLSTRING, "KOT_DET")
        If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
            For VCTR = 0 To gdataset.Tables("KOT_DET").Rows.Count - 1
                If Trim(STRKOTDETAILS) = "" Then
                    STRKOTDETAILS = "'" & Trim(gdataset.Tables("KOT_DET").Rows(VCTR).Item("KOTDETAILS")) & "',"
                Else
                    STRKOTDETAILS = STRKOTDETAILS & "'" & Trim(gdataset.Tables("KOT_DET").Rows(VCTR).Item("KOTDETAILS")) & "',"
                End If
            Next
            SQLSTRING = "UPDATE KOT_HDR SET "
            SQLSTRING = SQLSTRING & " BILLSTATUS ='PO' "
            SQLSTRING = SQLSTRING & " WHERE KOTDETAILS IN(" & Mid(Trim(STRKOTDETAILS), 1, Len(Trim(STRKOTDETAILS)) - 1) & ")"
            DELETE(0) = SQLSTRING

            SQLSTRING = "UPDATE KOT_DET SET "
            SQLSTRING = SQLSTRING & " BILLDETAILS =''"
            SQLSTRING = SQLSTRING & " WHERE KOTDETAILS IN(" & Mid(Trim(STRKOTDETAILS), 1, Len(Trim(STRKOTDETAILS)) - 1) & ")"
            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING

            '''************************************** Deleting item  reason from KOT_hdr ************************************'''
            'SQLSTRING = " UPDATE BILL_HDR SET reason = '" & Trim(cmb_CANNAME.Text) & "',Upduserid='" & gUsername & "' WHERE BILLDETAILS='" & Trim(CStr(Me.txt_BillNo.Text)) & "'"
            'ReDim Preserve DELETE(DELETE.Length)
            'DELETE(DELETE.Length - 1) = SQLSTRING
            '''************************************************* COMPLETE KOT_HDR ***************************************************'''
            '''************************************** Deleting KOTDETAILS Permently from KOT_DET ************************************'''
            SQLSTRING = " UPDATE BILL_DET SET DELFLAG = 'Y' WHERE BILLDETAILS in ('" & Trim(BillDetails) & "'" & ")"

            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING
            '''************************************************* COMPLETE KOT_HDR ***************************************************'''
            'SQLSTRING = " UPDATE BILL_HDR SET DELFLAG = 'Y' WHERE BILLDETAILS='" & Trim(CStr(Me.txt_BillNo.Text)) & "'"
            SQLSTRING = " UPDATE BILL_HDR SET DELFLAG = 'Y' WHERE BILLDETAILS in ('" & Trim(BillDetails) & "'" & ")"

            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING

            SQLSTRING = " UPDATE BILL_JOURNALENTRY SET VOID = 'Y' WHERE VOUCHERNO  in ('" & Trim(BillDetails) & "'" & ")"

            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING
         
            SQLSTRING = " UPDATE OUTSTANDING SET VOID = 'Y' WHERE VOUCHERNO in ('" & Trim(BillDetails) & "'" & ")"
            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING


            'smart card

            If PAY = "SMART CARD" Then
                SQLSTRING = " UPDATE SM_POSTRANSACTION SET VOID ='Y', VOIDUSER='" & gUsername & "' WHERE BILL_NO='" & Trim(txt_BillNo.Text) & "'"
                ReDim Preserve DELETE(DELETE.Length)
                DELETE(DELETE.Length - 1) = SQLSTRING

                SQLSTRING = "SELECT * FROM  SM_POSTRANSACTION WHERE BILL_NO in ('" & Trim(BillDetails) & "'" & ") and isnull(void,'')<>'y'"
                gconnection.getDataSet(SQLSTRING, "SM_POSTRANSACTION")
                If gdataset.Tables("SM_POSTRANSACTION").Rows.Count > 0 Then
                    SQLSTRING = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE +" & Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("bill_amount")) & " WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "'"
                    ReDim Preserve DELETE(DELETE.Length)
                    DELETE(DELETE.Length - 1) = SQLSTRING

                    'FOR EBALANCE

                    Dim BALstr, EBAL As String
                    Dim BALnum As Double
                    SQLSTRING = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                    gconnection.getDataSet(SQLSTRING, "CARDFILE_HDR_BAL")
                    If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                        If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                            BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) + Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("bill_amount"))
                        Else '--for zero
                            BALnum = 0 - Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("bill_amount"))
                        End If
                    End If
                    EBAL = abcdADD(BALnum)

                    SQLSTRING = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve DELETE(DELETE.Length)
                    DELETE(DELETE.Length - 1) = SQLSTRING
                    'END
                End If
            End If
            'karthi 

            'UPDATE POSVALID DATE TO NULL
            'CANT TRACK BEFORE
            'WANT TO BE DONE BY ADMIN
            Dim STRSQL2 As String
            STRSQL2 = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
            'STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & StrPOSCODE & "' AND STORESTATUS = 'FF' "
            gconnection.getDataSet(STRSQL2, "SM_CARDFILE_DET")
            If gdataset.Tables("SM_CARDFILE_DET").Rows.Count > 0 Then
                POS_AMT_GBL = Val(txt_BillAmount.Text)
                STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & STRPOSCODE & "' AND STORESTATUS = 'FF' "
                gconnection.getDataSet(STRSQL2, "FACILITY")
                If gdataset.Tables("FACILITY").Rows.Count > 0 Then
                    'ONCE FACILITY 
                    SQLSTRING = " UPDATE SM_CARDFILE_HDR SET UPDATEUSER='" & Trim(gUsername) & "',UPDATEDATETIME='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "' WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "'"
                    ReDim Preserve DELETE(DELETE.Length)
                    DELETE(DELETE.Length - 1) = SQLSTRING
                    'sqlstring = " UPDATE SM_CARDFILE_DET SET POS_VALID_FROM='" & Format(Cmb_Validfrom.Value, "dd/MMM/yyyy") & "',POS_VALID_TO='" & Format(Cmb_Validto.Value, "dd/MMM/yyyy") & "',TIME_FROM='" & Format(Cmb_TimeFrom.Value, "HH:MM") & "', TIME_TO='" & Format(Cmb_TimeTo.Value, "HH:MM") & "',DURATION='" & Format(Cmb_Duration.Value, "hh:mm") & "', HOURLY_BILL=" & POS_RATE_GBL & ", PERIOD_TO_DATE_USAGE=" & POS_AMT_GBL & " WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & StrPOSCODE & "'"

                    SQLSTRING = " SELECT POS_ACCESS, isNULL(POS_VALID_FROM,'01/01/1900') AS POS_VALID_FROM, ISNULL(POS_VALID_TO,'01/01/1900')AS POS_VALID_TO, ISNULL(TIME_FROM,'01/01/1900 00:00') AS TIME_FROM, ISNULL(TIME_TO,'01/01/1900 00:00') AS TIME_TO, ISNULL(DURATION,'01/01/1900 00:00')AS DURATION  FROM SM_CARDFILE_DET_IMG WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
                    gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_DET_IMG")
                    If gdataset.Tables("SM_CARDFILE_DET_IMG").Rows.Count > 0 Then
                        Dim POS_ACCESS As String
                        Dim POS_VALID_FROM, POS_VALID_TO, TIME_FROM, TIME_TO, DURATION As DateTime
                        POS_ACCESS = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_ACCESS")
                        POS_VALID_FROM = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_VALID_FROM")
                        POS_VALID_TO = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_VALID_TO")
                        TIME_FROM = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("TIME_FROM")
                        TIME_TO = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("TIME_TO")
                        DURATION = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("DURATION")
                        SQLSTRING = " UPDATE SM_CARDFILE_DET SET POS_ACCESS='" & POS_ACCESS & "',POS_VALID_FROM ='" & Format(POS_VALID_FROM, "dd/MMM/yyyy") & "',POS_VALID_TO='" & Format(POS_VALID_TO, "dd/MMM/yyyy") & "',TIME_FROM='" & Format(TIME_FROM, "HH:MM") & "',TIME_TO='" & Format(TIME_TO, "HH:MM") & "',DURATION='" & Format(DURATION, "HH:MM") & "' WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
                        ReDim Preserve DELETE(DELETE.Length)
                        DELETE(DELETE.Length - 1) = SQLSTRING
                    End If
                End If
            End If


            ''================================Cancel at Roomledger==============================================
            SQLSTRING = "SELECT ISNULL(CHECKOUT,'N') AS CHECKOUT,ISNULL(ROOMNO,0)AS ROOMNO FROM Roomcheckin WHERE docno = " & Val(txt_MemberCode.Tag) & ""
            gconnection.getDataSet(SQLSTRING, "Roomcheckin")
            If gdataset.Tables("Roomcheckin").Rows.Count > 0 Then
                If Trim(CStr(gdataset.Tables("Roomcheckin").Rows(0).Item("CHECKOUT"))) = "Y" Then
                    MessageBox.Show("Bill Can't be updated " & vbCrLf & " as GUEST  has been checkout from RoomNo" & ": " & gdataset.Tables("ROOMcheckin").Rows(0).Item("ROOMNO"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Cmd_Add.Enabled = True
                    Exit Sub
                End If
            End If

            vDocno = getVoucherno("CANCEL", "GUEST ROOM")

            SSQL = "Select * From Roomledger where  Doctype = 'SALES' And Docno IN ('" & Trim(BillDetails) & "') and isnull(Cancel,'')<>'Y' "
            gconnection.getDataSet(SSQL, "ROOMLEDGER")
            If gdataset.Tables("RoomLedger").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("roomledger").Rows.Count - 1
                    SSQL = "Insert into RoomLedger(Chkno,Docno,DocDate,Doctype,poscode,Amount,Roomno,Refno,AddUserid,AddDatetime,Description,Creditdebit,foliono,Accountcode,slcode,Paymentmode,Angcode,Billhold,Checkout,Partyname,Vouchertype,Vouchercategory,Cancel,OldDocType,VOIDSTATUS)"
                    SSQL = SSQL & " values(" & Val(gdataset.Tables("RoomLedger").Rows(i).Item("chkno")) & ", " & vDocno & ",'" & Format(gdataset.Tables("RoomLedger").Rows(i).Item("DocDate"), "dd-MMM-yyyy") & "',"
                    SSQL = SSQL & "'CANCEL','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("PosCode")) & "'," & Val(gdataset.Tables("RoomLedger").Rows(i).Item("Amount") & "") & ","
                    SSQL = SSQL & " " & Val(gdataset.Tables("RoomLedger").Rows(i).Item("RoomNo") & "") & ",'" & Val(gdataset.Tables("RoomLedger").Rows(i).Item("Refno") & "") & "',"
                    SSQL = SSQL & " '" & Trim(gUsername & "") & "','" & Format(Now, "dd-MMM-yyyy") & "',"
                    SSQL = SSQL & " '" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("DocType") & "") & "CANCELLED - " & gdataset.Tables("RoomLedger").Rows(i).Item("docNo") & " dt." & Format(gdataset.Tables("RoomLedger").Rows(i).Item("Docdate"), "dd-MMM-yyyy") & "','Credit',1,'" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("Accountcode") & "") & "','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("slcode") & "") & "'"
                    SSQL = SSQL & ",'" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("Paymentmode") & "") & "','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("AngCode") & "") & "','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("BillHold") & "") & "','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("checkout") & "") & "','" & Trim(gdataset.Tables("RoomLedger").Rows(i).Item("Partyname") & "") & "','CANCEL','GUEST ROOM','Y','" & gdataset.Tables("RoomLedger").Rows(i).Item("DocType") & "','Y')"

                    ReDim Preserve DELETE(DELETE.Length)
                    DELETE(DELETE.Length - 1) = SSQL

                    SSQL = " UPDATE ROOMLEDGER SET CANCEL='Y',VOIDSTATUS='Y' WHERE CHKNO =" & Val(gdataset.Tables("RoomLedger").Rows(0).Item("chkno")) & " "
                    SSQL = SSQL & " AND DOCTYPE='SALES' AND DOCNO in ('" & Trim(BillDetails) & "')"

                    ReDim Preserve DELETE(DELETE.Length)
                    DELETE(DELETE.Length - 1) = SSQL
                Next
            End If
            ''=============================Updation of roomledger complete=========================================
            SQLSTRING = " UPDATE SETTLEMENT SET DELETEFLAG = 'Y' WHERE BILLDETAILS='" & txt_BillNo.Text & "'"
            ReDim Preserve DELETE(DELETE.Length)
            DELETE(DELETE.Length - 1) = SQLSTRING

            gconnection.MoreTransold(DELETE)

            MsgBox("Bill is Deleted Successfully!", MsgBoxStyle.OkOnly, "Info!")
            Call Cmd_Clear_Click(Cmd_Clear, e)
        Else
            MessageBox.Show("!! OOPS !! Bill Can't be deleted ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub
    Private Sub cmd_BillNoHelp_Click(sender As Object, e As EventArgs) Handles cmd_BillNoHelp.Click
        Dim vform As New LIST_OPERATION1
        BillDetails = ""
        If gCenterlized = "Y" Then
            gSQLString = "SELECT ISNULL(Billdetails,'') AS Billdetails ,Convert(varchar, BillDate,100)AS BILLDATE,MCODE,MNAME FROM BILL_HDR"
            'M_WhereCondition = " WHERE BILLDETAILS LIKE ('" & Trim(gDocType) & "%') OR (BILLDETAILS = '" & Trim(BillDetails) & "' AND  BILLDETAILS LIKE '" & Trim(gDocType) & "%')"
            M_WhereCondition = " WHERE BILLDETAILS LIKE ('" & Trim(gDocType) & "%') "
        Else
            gSQLString = "SELECT ISNULL(Billdetails,'') AS Billdetails ,Convert(varchar, BillDate,100)AS BILLDATE,MCODE,MNAME FROM BILL_HDR"
            'M_WhereCondition = " WHERE BILLDETAILS LIKE ('" & Trim(DOCTYPE) & "%') OR (BILLDETAILS = '" & Trim(BillDetails) & "' AND  BILLDETAILS LIKE '" & Trim(DOCTYPE) & "%')"
            M_WhereCondition = " WHERE BILLDETAILS LIKE ('" & Trim(DOCTYPE) & "%') "
        End If
        'M_WhereCondition = " WHERE SUBSTRING(BILLDETAILS,1,3) = '" & Trim(CMB_BTYPE.Text) & "'"
        vform.Field = "BILLDETAILS,BILLDATE,MCODE,MNAME "
        'vform.vFormatstring = "                    BILL NO                         |                    BILL DATE               |"
        vform.vCaption = "Bill Details Help"
        'vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_BillNo.Text = Trim(vform.keyfield & "")
            Call txt_BillNo_Validated(sender, e)
            cbo_PaymentMode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_BillNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_BillNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_BillNoHelp_Click(cmd_BillNoHelp, e)
        End If
    End Sub
    Private Sub txt_BillNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_BillNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_BillNo.Text) = "" Then
                Call Cmd_Clear_Click(sender, e)
            Else
                Call txt_BillNo_Validated(txt_BillNo, e)
                cbo_PaymentMode.Focus()
            End If
        End If
    End Sub
    Private Sub txt_BillNo_Validated(sender As Object, e As EventArgs) Handles txt_BillNo.Validated
        Try
            If Trim(txt_BillNo.Text) <> "" Then
                Call BillValidate(Trim(txt_BillNo.Text))
                'Call txt_ServerCode_Validated(txt_ServerCode, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid Billno :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub BillValidate(ByVal billdetails As String)
        Dim j, i As Integer
        Dim vString, sqlstring As String
        Dim vTypeseqno As Double
        Dim vGroupseqno As Double
        Dim other As Boolean
        Dim dt As New DataTable
        other = False
        If Trim(billdetails) <> "" Then
            sqlstring = "SELECT ISNULL(B.BILLNO,'') AS BILLNO,ISNULL(B.BILLDETAILS,'') AS BILLDETAILS,ISNULL(OTHBILLDETAILS,'') AS OTHBILLDETAILS,ISNULL(servicelocation,'') AS servicelocation,"
            sqlstring = sqlstring & " B.BILLDATE AS BILLDATE,ISNULL(B.TOTALAMT,0) AS TOTALAMT,ISNULL(B.KOTDETAILS,'') AS KOTDETAILS,ISNULL(H.MCODE,'') AS MCODE,ISNULL(H.SCODE,'') AS SCODE, "
            sqlstring = sqlstring & " ISNULL(H.MNAME,'') AS MNAME,ISNULL(H.SNAME,'') AS SNAME,H.BILLTIME AS BILLTIME,ISNULL(H.TOTALAMOUNT,0) AS TOTALAMOUNT,B.KotAmount,B.Taxamount,B.Packamount,B.TipsAmt,B.AdCgsAmt,B.PartyAmt,B.RoomAmt,"
            sqlstring = sqlstring & " ISNULL(H.PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(H.CROSTATUS,'') AS CROSTATUS,B.KOTDATE AS KOTDATE,ISNULL(H.GUEST,'') AS GUEST,"
            sqlstring = sqlstring & " ISNULL(H.ROOMNO,0) AS ROOMNO,ISNULL(H.CHKID,0) AS CHKID,ISNULL(H.SUBPAYMENTMODE,'') AS SUBPAYMENTMODE, ISNULL(H.DELFLAG,'') AS DELFLAG, ISNULL(H.REMARKS,'') AS REMARKS,isnull(h.reason,'') as reason,ISNULL(SBILLFLAG,'') AS SBILLFLAG,ISNULL(INSTYPE,'')AS INSTYPE,ISNULL(INSNO,'')AS INSNO "
            sqlstring = sqlstring & " FROM BILL_HDR AS H INNER JOIN BILL_DET AS B ON H.BILLDETAILS = B.BILLDETAILS"
            sqlstring = sqlstring & " WHERE  (B.BILLNO ='" & Format(Val(billdetails), "000000") & "' AND  B.BILLDETAILS LIKE '" & Trim(BillPrefix) & "%') OR (B.BILLDETAILS = '" & Trim(billdetails) & "' AND  B.BILLDETAILS LIKE '" & Trim(BillPrefix) & "%') ORDER BY B.KOTDETAILS"
            ssGrid.ClearRange(1, 1, -1, -1, True)
            gconnection.getDataSet(sqlstring, "BILL_HDR")
            '''************************************************* SELECT record from KOT_HDR *********************************************''''                
            If gdataset.Tables("BILL_HDR").Rows.Count > 0 Then
                loccode = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("servicelocation") & "")
                If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("DelFlag") & "") = "Y" Then
                    'If gCompanyname = "THE TNCA CLUB" Then
                    '    grp_paydet.Visible = True
                    '    cmb_CANNAME.Text = Trim(gdataset.Tables("bill_hdr").Rows(0).Item("reason") & "")
                    'Else
                    '    grp_paydet.Visible = False
                    'End If
                    lblDeleted.Visible = True
                    Cmd_Add.Enabled = False
                    Cmd_Delete.Enabled = False
                Else
                    lblDeleted.Visible = False
                    Cmd_Add.Enabled = True
                    Cmd_Delete.Enabled = True
                End If
                'End
                ''*************************TO SHOW THE CRO NO IN THE BILL*******************************************
                sqlstring = "SELECT CRONO,USERID FROM RECEIPT_DETAILS WHERE BILLNO='" & billdetails & "'"
                gconnection.getDataSet(sqlstring, "CRO")
                If gdataset.Tables("CRO").Rows.Count > 0 Then
                    lblCro1.Visible = True
                    lblCro2.Visible = True
                    lblCro2.Text = Trim(gdataset.Tables("CRO").Rows(0).Item(0)) & " -> " & Trim(gdataset.Tables("CRO").Rows(0).Item(1))
                End If
                ''***************************************************************************************************
                Cmd_Add.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.txt_BillNo.ReadOnly = True
                Me.cmd_BillNoHelp.Enabled = False
                KOT_Timer.Enabled = False
                Call fillPayment_Mode()
                txt_BillNo.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Billdetails") & "")
                dtp_BillDate.Value = Format(CDate(gdataset.Tables("BILL_HDR").Rows(0).Item("BillDate")), "dd-MMM-yy")
                txt_KOTTime.Text = Format(CDate(gdataset.Tables("BILL_HDR").Rows(0).Item("BillTime")), "hh:mm:ss")
                txt_ServerCode.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("servicelocation") & "")
                'txt_ServerName.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Sname") & "")
                txt_BillAmount.Text = Format(Val(gdataset.Tables("BILL_HDR").Rows(0).Item("TotalAmount") & ""), "0.00")
                cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                cbo_PaymentMode.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("PaymentMode") & "")
                Me.cmb_instype.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("INSTYPE") & "")
                Me.txt_insno.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("INSNO") & "")
                Txt_Remarks.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Remarks") & "")
              
                cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
                If gdataset.Tables("BILL_HDR").Rows(0).IsNull("CroStatus") = True Then
                    Me.Lbl_Bill.Visible = False
                    Cmd_Add.Enabled = True
                Else
                    If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("CroStatus")) <> "N" Then
                        Me.Lbl_Bill.Text = "C R O G E N E R A T E D"
                        Me.Lbl_Bill.Visible = True
                        Cmd_Add.Enabled = False
                        Cmd_Delete.Enabled = False
                    End If
                End If
                Call GridLocking()
                If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Subpaymentmode") & "") <> "" Then
                    Call FillSubPaymentMode(Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("PaymentMode") & ""))
                    sqlstring = "SELECT SUBPAYMENTNAME,SUBPAYMENTCODE FROM SUBPAYMENTMODE WHERE SUBPAYMENTCODE = '" & Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Subpaymentmode")) & "' "
                    gconnection.getDataSet(sqlstring, "SUBPAYMENTMODE")
                    If gdataset.Tables("SUBPAYMENTMODE").Rows.Count = 1 Then
                        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                        Me.cbo_SubPaymentMode.Text = Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTCODE") & "-" & Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTNAME")))
                        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
                    End If
                End If
                If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Paymentmode")) = "ROOM" Then
                    txt_MemberCode.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("ROOMNO")) & ""
                    txt_MemberName.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("GUEST")) & ""
                    sqlstring = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(CRIDITNUMBER,'') AS CRIDITNUMBER FROM membermaster WHERE MCODE='" & Trim(txt_MemberCode.Text) & "'"
                    gconnection.getDataSet(sqlstring, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        txt_creditfacility = gdataset.Tables("membermaster").Rows(0).Item("CRIDITNUMBER")
                    End If
                    txt_MemberCode.Tag = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("CHKID")) & ""
                Else
                    If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("MCode")) & "" <> "" And Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Mname")) & "" <> "" Then
                        txt_MemberCode.Visible = True
                        txt_MemberName.Visible = True
                        lbl_Membercode.Visible = True
                        cmd_MemberCodeHelp.Visible = True
                        txt_MemberCode.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("MCode")) & ""
                        txt_MemberName.Text = Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("Mname")) & ""
                        sqlstring = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(CRIDITNUMBER,'') AS CRIDITNUMBER FROM membermaster WHERE MCODE='" & Trim(txt_MemberCode.Text) & "'"
                        gconnection.getDataSet(sqlstring, "membermaster")
                        If gdataset.Tables("membermaster").Rows.Count > 0 Then
                            txt_creditfacility = gdataset.Tables("membermaster").Rows(0).Item("CRIDITNUMBER")
                        End If

                    Else
                        txt_MemberCode.Visible = False
                        txt_MemberName.Visible = False
                        lbl_Membercode.Visible = False
                        cmd_MemberCodeHelp.Visible = False
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                    End If

                    If txt_Holder_Code.Text = "" Then
                        txt_Holder_Code.Text = txt_MemberCode.Text
                    End If

                End If

                If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("OthBilldetails")) = "" Then
                    other = False
                    sqlstring = "select Bill_det.BillDetails,Isnull(Bill_det.BillDetails,'') As OthBilldetails,Bill_det.BillDate,TotalAmt,Bill_det.KotAmount,Bill_det.Taxamount,Bill_det.Packamount,Bill_det.TipsAmt,Bill_det.AdCgsAmt,Bill_det.PartyAmt,Bill_det.RoomAmt,Kotdetails,mcode,scode,mname,sname,KotDetails,BillTime,totalamount,PayMentMode,KotDate,Guest,RoomNo,chkid"
                    sqlstring = sqlstring & " from Bill_Hdr Inner Join Bill_Det On Bill_Hdr.BillDetails=Bill_det.BillDetails  "
                    sqlstring = sqlstring & " WHERE  Bill_det.OthBilldetails='" & Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("billdetails")) & "' ORDER BY Bill_det.BillDetails"
                    gconnection.getDataSet(sqlstring, "OTHERBILLDETAILS")
                    If gdataset.Tables("OTHERBILLDETAILS").Rows.Count > 0 Then
                        other = True
                    Else
                        other = False
                    End If
                Else
                    sqlstring = "select Bill_det.BillDetails,Isnull(OthBilldetails,'') As OthBilldetails,Bill_det.BillDate,TotalAmt,Bill_det.KotAmount,Bill_det.Taxamount,Bill_det.Packamount,Bill_det.TipsAmt,Bill_det.AdCgsAmt,Bill_det.PartyAmt,Bill_det.RoomAmt,Kotdetails,mcode,scode,mname,sname,KotDetails,BillTime,totalamount,PayMentMode,KotDate,Guest,RoomNo,chkid"
                    sqlstring = sqlstring & " from Bill_Hdr Inner Join Bill_Det On Bill_Hdr.BillDetails=Bill_det.BillDetails  "
                    sqlstring = sqlstring & " WHERE  Bill_det.Billdetails='" & Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("OthBilldetails")) & "' ORDER BY Bill_det.BillDetails"
                    gconnection.getDataSet(sqlstring, "OTHERBILLDETAILS")
                    other = True
                End If
                With ssGrid
                    For i = 1 To gdataset.Tables("BILL_HDR").Rows.Count
                        .SetText(1, i, Trim(gdataset.Tables("BILL_HDR").Rows(j).Item("Kotdetails")) & "")
                        .SetText(2, i, gdataset.Tables("BILL_HDR").Rows(j).Item("Kotdate"))
                        .SetText(3, i, Format(Val(gdataset.Tables("BILL_HDR").Rows(j).Item("KotAmount")), "0.00"))
                        .SetText(4, i, Format(Val(gdataset.Tables("BILL_HDR").Rows(j).Item("Taxamount")), "0.00"))
                        .SetText(5, i, Format(Val(gdataset.Tables("BILL_HDR").Rows(j).Item("Packamount")) + Val(gdataset.Tables("BILL_HDR").Rows(j).Item("TipsAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(j).Item("AdCgsAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(j).Item("PartyAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(j).Item("RoomAmt")), "0.00"))
                        .SetText(6, i, Trim("ST"))
                        j = j + 1
                    Next i
                    If other = True Then
                        If gdataset.Tables("OTHERBILLDETAILS").Rows.Count > 0 Then
                            j = i
                            Me.Lbl_OtherBill.Visible = True
                            If Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("OthBilldetails")) <> "" Then
                                Me.Lbl_OtherBill.Text = "Other Bill No :" & Trim(gdataset.Tables("BILL_HDR").Rows(0).Item("OthBilldetails"))
                            Else
                                Me.Lbl_OtherBill.Text = "Other Bill No :" & Trim(gdataset.Tables("OTHERBILLDETAILS").Rows(0).Item("OthBilldetails"))
                            End If
                            For i = 0 To gdataset.Tables("OTHERBILLDETAILS").Rows.Count - 1
                                .Row = j
                                .Col = 1
                                .BackColor = Color.DarkMagenta
                                .ForeColor = Color.White
                                .SetText(1, j, Trim(gdataset.Tables("OTHERBILLDETAILS").Rows(i).Item("Kotdetails")) & "")
                                .SetText(2, j, gdataset.Tables("OTHERBILLDETAILS").Rows(i).Item("Kotdate"))
                                .SetText(3, j, Format(Val(gdataset.Tables("OTHERBILLDETAILS").Rows(i).Item("KotAmount")), "0.00"))
                                .SetText(4, j, Format(Val(gdataset.Tables("OTHERBILLDETAILS").Rows(i).Item("Taxamount")), "0.00"))
                                .SetText(5, j, Format(Val(gdataset.Tables("OTHERBILLDETAILS").Rows(i).Item("Packamount")) + Val(gdataset.Tables("BILL_HDR").Rows(i).Item("TipsAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(i).Item("AdCgsAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(i).Item("PartyAmt")) + Val(gdataset.Tables("BILL_HDR").Rows(i).Item("RoomAmt")), "0.00"))
                                .SetText(6, j, Trim("ST"))
                                j = j + 1
                            Next
                        End If
                    End If
                End With
                Call Fillsettlement()
                If gUserCategory <> "S" Then
                    bill_closing()
                End If
                'bill_closing()
            Else
                'txt_BillNo.Text = ""
                Call Autogenerate()
                CMB_BTYPE.Focus()
            End If
        End If
    End Sub
    Private Function Fillsettlement()
        Dim sqlstring, Subpaymentmode() As String
        Dim Billtotal As Double
        KotDetails = ""
        'CMB_SPILTMEMBER.Items.Clear()
        Dim i, j As Integer
        Try
            sqlstring = " SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(BILLDETAILS,'') AS BILLDETAILS,ISNULL(DESCRIPTION,'') AS DESCRIPTION "
            sqlstring = sqlstring & " FROM SETTLEMENT WHERE BILLDETAILS='" & Trim(txt_BillNo.Text) & "' --AND ISNULL(DELETEFLAG,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "SETTLE")
            'If cbo_PaymentMode.SelectedItem <> "ROOM" Then
            If gdataset.Tables("SETTLE").Rows.Count > 0 Then
                With ssgrid_settlement
                    ssgrid_settlement.ClearRange(1, 1, -1, -1, True)
                    ssgrid_settlement.SetActiveCell(1, 1)
                    For i = 0 To gdataset.Tables("SETTLE").Rows.Count - 1
                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("SETTLE").Rows(i).Item("MCODE")
                        .Col = 2
                        .Text = Format(Val(gdataset.Tables("SETTLE").Rows(i).Item("AMOUNT")), "0.00")
                        .Col = 3
                        .Text = gdataset.Tables("SETTLE").Rows(i).Item("DESCRIPTION")
                        'CMB_SPILTMEMBER.Items.Add(gdataset.Tables("SETTLE").Rows(i).Item("MCODE"))
                    Next
                End With
                'End If
            End If
            If gdataset.Tables("SETTLE").Rows.Count > 1 Then
                'LAB_SPILTMEMBER.Visible = True
                'CMB_SPILTMEMBER.Visible = True
                'CHKALL.Visible = True
                'CMB_SPILTMEMBER.SelectedIndex = 0
            Else
                'LAB_SPILTMEMBER.Visible = False
                'CMB_SPILTMEMBER.Visible = False
                'CHKALL.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub bill_closing()
        ssql = "select isnull(accountflag,'')  as Aflag from bill_hdr where billdetails='" & txt_BillNo.Text & "'"
        gconnection.getDataSet(ssql, "Bill")
        'If cbo_PaymentMode.SelectedItem <> "ROOM" Then
        If gdataset.Tables("Bill").Rows.Count > 0 Then
            If Trim(gdataset.Tables("Bill").Rows(0).Item("Aflag")) = "Y" Then
                MessageBox.Show("YOU HAVE NO RIGHTS TO EDIT THIS KOT.....", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Cmd_Add.Enabled = False
                Cmd_Delete.Enabled = False
                Cmd_Delete.Enabled = False
                cmd_BillSettlement.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmd_BillSettlement_Click(sender As Object, e As EventArgs) Handles cmd_BillSettlement.Click
        Dim sqlstring, Varchk, SubpaymentMode(), paymentaccountcode, Subpaymentaccountcode As String
        Dim TotalAmount, TaxTotal, total, size, i, j As Double
        Dim TaxApp, NoTax, Otherbool As Boolean
        Dim Kot_Bill As New DataTable
        Dim Taxdr(), NoTaxDr() As DataRow
        Try
            'Call checkvalidate() '''---> Check Validation
            'If chkbool = False Then Exit Sub
            ''''************************************************* Case-1:ADD [F7] ***********************************'''
            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                KotDetails = ""
                For i = 1 To sSGrid.DataRowCnt
                    sSGrid.Row = i
                    sSGrid.Col = 1
                    Varchk = ""
                    Varchk = sSGrid.Text
                    If Trim(Varchk & "") <> "" Then
                        sSGrid.Col = 1
                        If KotDetails = "" Then
                            KotDetails = "'" & Trim(sSGrid.Text) & "'"
                        Else
                            KotDetails = KotDetails & ",'" & Trim(sSGrid.Text) & "'"
                        End If
                    End If
                Next i
                If Trim(KotDetails) = "" Then
                    MessageBox.Show("Plz Select The Kots To Generate The Bill", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '''****************************************** $ In KotBill Table I am Storing The Kotdetails according to taxcode $ ******************'''
                sqlstring = "SELECT KOTDATE,KOTDETAILS,ISNULL(TAXCODE,'') AS TAXCODE ,ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS AMOUNT,ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) AS TAXAMOUNT FROM KOT_DET WHERE ISNULL(KOTSTATUS,'') <> 'Y' AND KOTDETAILS IN( " & KotDetails & " )GROUP BY TAXCODE,KOTDETAILS,KOTDATE ORDER BY TAXCODE,KOTDETAILS"
                Kot_Bill = gconnection.GetValues(sqlstring)
                '''****************************************** $ TaxDr Contains The Taxable Items $ ***********************************************'''
                Taxdr = Kot_Bill.Select("TAXCODE <> ''")
                '''****************************************** $ NoTaxdr Contains The NonTaxable Items $ *****************************************'''
                NoTaxDr = Kot_Bill.Select("TAXCODE = ''")
                If Taxdr.Length > 0 Then
                    size = (Taxdr.Length * 3)
                    TaxApp = True
                End If
                If NoTaxDr.Length > 0 Then
                    If Val(size) > 0 Then
                        size = size + (NoTaxDr.Length * 3)
                    Else
                        size = (NoTaxDr.Length * 3)
                    End If
                    NoTax = True
                End If
                Billno = Split(Trim(txt_BillNo.Text), "/")
                BillDetails = Trim(Me.txt_BillNo.Text)
                ''' ************************************************ $ TAX BILLDETAILS GENERATION $ ***************************'''
                If TaxApp = True Then
                    Dim varStr1, varStr2 As String
                    BillTaxBillno = Billno(1)
                    BillTaxBilldetails = Trim(Me.txt_BillNo.Text)
                    ''' ************************************************ $ NONTAX BILLDETAILS GENERATION $ ***************************'''
                    If NoTax = True Then
                        Billno(1) = Convert.ToString(Val(Billno(1)) + 1)
                        Billno(1) = Format(Val(Billno(1)), "000000")
                        varStr1 = Trim(Me.txt_BillNo.Text).Substring(4, 6)
                        varStr2 = CStr(Val(varStr1) + 1)
                        BillNonTaxBilldetails = Trim(Me.txt_BillNo.Text).Replace(varStr1, Format(Val(varStr2), "000000"))
                        BillNonTaxBillno = Billno(1)
                    Else
                        BillNonTaxBilldetails = ""
                        BillNonTaxBillno = ""
                    End If
                Else
                    BillTaxBillno = ""
                    BillTaxBilldetails = ""
                    BillNonTaxBillno = Billno(1)
                    BillNonTaxBilldetails = Trim(Me.txt_BillNo.Text)
                End If
                ''' ************************************************ $  TAXTOTAL AND TOTALAMOUNT GENERATION $ ***************************'''
                If Taxdr.Length > 0 Then
                    dblBillTaxTotal = 0
                    dblBillTotalAmount = 0
                    For i = 0 To Taxdr.Length - 1
                        dblBillTaxTotal = dblBillTaxTotal + Val(Taxdr(i).Item("TaxAmount"))
                        dblBillTotalAmount = dblBillTaxTotal + dblBillTotalAmount + Val(Taxdr(i).Item("Amount"))
                    Next i
                    TaxApp = True
                End If
                ''' ************************************************ $  NONTAXTOTAL AND NONTOTALAMOUNT GENERATION $ ***************************'''
                If NoTaxDr.Length > 0 Then
                    dblBillNonTaxtotal = 0
                    dblBillNonTotalAmount = 0
                    For i = 0 To NoTaxDr.Length - 1
                        dblBillNonTaxtotal = dblBillNonTaxtotal + Val(NoTaxDr(i).Item("TaxAmount"))
                        dblBillNonTotalAmount = dblBillNonTaxtotal + dblBillNonTotalAmount + Val(NoTaxDr(i).Item("Amount"))
                    Next i
                End If
                BillMcode = Trim(txt_MemberCode.Text)
                BillMname = Trim(txt_MemberName.Text)
                ssgridPayment1.Col = 1
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = Trim(BillTaxBilldetails)
                ssgridPayment1.Col = 2
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = CDate(dtp_BillDate.Value)
                ssgridPayment1.Col = 5
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = Trim(BillMcode)
                ssgridPayment1.Col = 6
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = Trim(BillMname)
                ssgridPayment1.Col = 7
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = Format(Val(dblBillTotalAmount), "0.00")
                ssgridPayment1.Col = 8
                ssgridPayment1.Row = 1
                ssgridPayment1.Text = Format(Val(dblBillTotalAmount), "0.00")
                Me.txt_PartialPayment.Text = Format(Val(dblBillTotalAmount), "0.00")
                Call FillPaymentmodeSettlement(1)
                grp_Paymentmodeselection.Top = 296
                grp_Paymentmodeselection.Left = 80
                grp_Paymentmodeselection.BringToFront()
                ssgridPayment1.SetActiveCell(3, 1)
                ssgridPayment1.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub FillPaymentmodeSettlement(ByVal i As Integer)
        Dim sqlstring As String
        Dim j As Integer
        Try
            ssgridPayment1.TypeComboBoxClear(3, i)
            sqlstring = "SELECT Paymentcode FROM paymentmodemaster WHERE  Paymentcode <> 'ROOM' AND Isnull(Freeze,'')='N'"
            gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    ssgridPayment1.Col = 3
                    ssgridPayment1.Row = i
                    ssgridPayment1.TypeComboBoxString = Trim(gdataset.Tables("paymentmodemaster").Rows(j).Item("Paymentcode"))
                    ssgridPayment1.Text = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode"))
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_Back_Click(sender As Object, e As EventArgs) Handles cmd_Back.Click
        grp_Paymentmodeselection.SendToBack()
        grp_Paymentmodeselection.Top = 1000
    End Sub
    Private Sub cmdMcodeUpd_Click(sender As Object, e As EventArgs) Handles cmdMcodeUpd.Click
        If Mid(Trim(Me.Cmd_Add.Text), 1, 1) = "A" Then
        Else
            grpPass.Visible = True
            txtPass.Focus()
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        gconnection.getDataSet("SELECT ISNULL(PASSWORD,'') AS PASSWORD FROM PASSWORD", "PASSWORD")
        If gdataset.Tables("PASSWORD").Rows(0).Item(0) = GetPassword(UCase(Trim(txtPass.Text))) Then
            grpPass.Visible = False
            txtPass.Text = ""
            'grpNewMcode.Visible = True
            'txtNmcode.Focus()
            GRP_PAY.Visible = True
            CBO_NPAYMODE.Focus()
            Me.Button3.Enabled = False
        Else
            MsgBox("UNAUTHERISED ACCESS...", MsgBoxStyle.Critical)
            txtPass.Text = ""
            grpPass.Visible = False
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Update1(0), SQLSTRING As String
        SQLSTRING = " UPDATE BILL_HDR SET PAYMENTMODE='" & Me.CBO_NPAYMODE.Text & "' WHERE BILLDETAILS='" & Me.txt_BillNo.Text & "'AND ISNULL(DELFLAG,'')<>'Y'"
        Update1(0) = SQLSTRING
        SQLSTRING = " UPDATE KOT_DET SET PAYMENTMODE='" & Me.CBO_NPAYMODE.Text & "' WHERE BILLDETAILS='" & Me.txt_BillNo.Text & "'AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'')<>'Y'"
        ReDim Preserve Update1(Update1.Length)
        Update1(Update1.Length - 1) = SQLSTRING

        SQLSTRING = " UPDATE KOT_HDR SET PaymentType='" & Me.CBO_NPAYMODE.Text & "' WHERE KOTDETAILS IN(SELECT KOTDETAILS FROM KOT_DET WHERE BILLDETAILS='" & Me.txt_BillNo.Text & "'AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'')<>'Y')AND ISNULL(DELFLAG,'')<>'Y' "
        ReDim Preserve Update1(Update1.Length)
        Update1(Update1.Length - 1) = SQLSTRING
        gconnection.MoreTransold(Update1)
        Call Me.Cmd_Clear_Click(sender, e)
    End Sub
    Private Sub fillNPayment_Mode()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            If Mid(Trim(Me.Cmd_Add.Text), 1, 1) = "A" Then
                'Call FillDefaultPayment()
                'Modified on 18 Mar'08
                'Mk Kannan
                'Begin
                'sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Paymentcode NOT IN ('CLUB')AND Isnull(Freeze,'N')='N'"
                sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'N')='N'"
                'End
                CBO_NPAYMODE.Items.Clear()
                gconnection.getDataSet(sqlstring, "paymentmodemaster")
                If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                        CBO_NPAYMODE.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("Paymentcode"))
                    Next i
                    index = CBO_NPAYMODE.FindString(DefaultPayment)
                    CBO_NPAYMODE.SelectedIndex = index
                Else
                    MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'N')='N'"
                cbo_PaymentMode.Items.Clear()
                gconnection.getDataSet(sqlstring, "paymentmodemaster")
                If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                        CBO_NPAYMODE.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("Paymentcode"))
                    Next i
                    index = CBO_NPAYMODE.FindString(DefaultPayment)
                    cbo_PaymentMode.SelectedIndex = index
                Else
                    MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdOk.Focus()
        End If
    End Sub
    Private Sub CBO_NPAYMODE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBO_NPAYMODE.SelectedIndexChanged
        If CBO_NPAYMODE.Text <> "SMART CARD" Then
            Me.Button3.Enabled = True
        Else
            Me.Button3.Enabled = False
        End If
    End Sub
    Public Sub MCLUB_PRINT()
        Randomize()
        Dim rowj, Loopindex, i, Pagesize, CountItem, in1, Fo, jo, cpt As Integer
        Dim Rowprint, rowno, vCaption, vPath, Fsize(), Forder(), billdetails, rupeesword, splmember, servicelocation, SCODE, SNAME As String
        Dim BillNo, sql, sqlstring, Kot, vOutfile, vheader, vline, round, vFilepath, str, Otherbillno, BILLPLACE, Table, Loc As String
        Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, taxpercentage, toalamt As Double
        Dim CardOpBalance, CardClBalance, trnBalance, OCardOpBalance, OCardClBalance, OtrnBalance As Double
        Dim oth1 As Boolean
        Dim SSQL1, TypeFlag, PackDesc, TipsDesc, AddChgDesc As String
        Dim climit, ulimit, vPackAmt, vTipsAmt, vAdAmt, vPartyAmt, vRoomAmt As Double
        'ssql = "select isnull(memcreditlimit,0)as creditlimit from  possetup"
        'gconnection.getDataSet(ssql, "climit")
        'If gdataset.Tables("climit").Rows.Count > 0 Then
        '    If gdataset.Tables("climit").Rows(0).Item("creditlimit") > 0 Then
        '        climit = gdataset.Tables("climit").Rows(0).Item("creditlimit")
        '        ssql = "exec get_creditlimit'" & Me.txt_MemberCode.Text & "'"
        '        gconnection.ExcuteStoreProcedure(ssql)
        '        ssql = "SELECT * FROM balance WHERE MCODE='" & Me.txt_MemberCode.Text & "'"
        '        gconnection.getDataSet(ssql, "CRD")
        '        If gdataset.Tables("CRD").Rows.Count > 0 Then
        '            MemberOutstand = gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
        '            'Me.LAB_OUTSTAND.Text = "MEMBER OUTSTANDING :" & gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
        '        Else
        '            MemberOutstand = 0
        '        End If

        '        If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
        '            MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '            'Exit Sub
        '        End If
        '    End If
        'End If

        Dim Otrnbalance2 As Long
        Dim OCardOpBalance2 As Long
        sqlstring = "SELECT ISNULL(BALANCE,0) BALANCE FROM SM_CARDFILE_HDR WHERE CARDCODE='" & txt_Holder_Code.Text & "'  "
        gconnection.getDataSet(sqlstring, "balanceAmount")

        If gdataset.Tables("balanceAmount").Rows.Count > 0 Then
            CardOpBalance = Val(gdataset.Tables("balanceAmount").Rows(0).Item(0))
        End If
        sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
        gconnection.getDataSet(sql, "Bill_det")
        If gdataset.Tables("Bill_det").Rows.Count > 0 Then
            Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
            oth1 = True
            If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
                oth1 = False
                sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
                gconnection.getDataSet(sql, "Bill_det")
                If gdataset.Tables("Bill_det").Rows.Count > 0 Then
                    Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("billdetails") & "")
                    oth1 = True
                End If
            End If
        Else
            oth1 = False
        End If
        If oth1 = True Then
            billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_BillNo.Text) & "'"
        Else
            billdetails = "'" & Trim(Me.txt_BillNo.Text) & "'"
        End If
        sqlstring = "SELECT  isnull(SUM(isnull(BILL_AMOUNT,0)),0) DFM, isnull(SUM(isnull(DEDUCT_FROM_CARD,0)),0) DFC FROM SM_POSTRANSACTION WHERE isnull(VOID,'')<>'Y' and BILL_NO in (" & Trim(billdetails) & ") "
        gconnection.getDataSet(sqlstring, "BillTotal")
        If gdataset.Tables("billTotal").Rows.Count > 0 Then
            If gdataset.Tables("billTotal").Rows.Count = 1 Then
                trnBalance = Val(gdataset.Tables("BillTotal").Rows(0).Item(0))
            End If
        End If
        cpt = 0
        CardOpBalance = CardOpBalance + Math.Round(trnBalance) '+ Math.Round(OtrnBalance)

        Dim ds As New DataSet
        Dim Otherbool, boolOtherBill As Boolean
        Dim addUser As String
        Dim Filewrite As StreamWriter
        gCompanyname = MyCompanyName
        gCompanyAddress(0) = Address1
        gCompanyAddress(1) = Address2
        'gtinno(0) = gtinno
        Dim HBILLDETAILS As String
        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
        vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"

        sql = "SELECT ISNULL(TINNO,'') AS TINNO FROM master..CLUBMASTER WHERE DATAFILE = '" & Trim(gDatabase) & "'"
        gconnection.getDataSet(sql, "CLUBMASTER")
        If gdataset.Tables("CLUBMASTER").Rows.Count > 0 Then
            gTINNO = gdataset.Tables("CLUBMASTER").Rows(0).Item("TinNo")
        End If

        sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
        gconnection.getDataSet(sql, "Bill_det")
        If gdataset.Tables("Bill_det").Rows.Count > 0 Then
            Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
            Otherbool = True
            If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
                Otherbool = False
                sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
                gconnection.getDataSet(sql, "Bill_det")
                If gdataset.Tables("Bill_det").Rows.Count > 0 Then
                    Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("billdetails") & "")
                    Otherbool = True
                End If
            End If
        Else
            Otherbool = False
        End If
        If Otherbool = True Then
            billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_BillNo.Text) & "'"
        Else
            billdetails = "'" & Trim(Me.txt_BillNo.Text) & "'"
        End If
        Filewrite = File.AppendText(vFilepath)
        sql = "select billdetails from bill_hdr where billdetails in (" & Trim(billdetails) & ") and isnull(delflag,'')<>'Y' "
        gconnection.getDataSet(sql, "billing")
        If gdataset.Tables("billing").Rows.Count > 0 Then
            For jo = 0 To gdataset.Tables("billing").Rows.Count - 1
                billdetails = "'" & gdataset.Tables("billing").Rows(jo).Item("billdetails") & "'"
                sqlstring = "SELECT isnull(SUM(isnull(BILL_AMOUNT,0)),0) DFM, isnull(SUM(isnull(DEDUCT_FROM_CARD,0)),0) DFC FROM SM_POSTRANSACTION WHERE isnull(VOID,'')<>'Y' and BILL_NO =" & billdetails & "  "
                gconnection.getDataSet(sqlstring, "BillTotal")
                If gdataset.Tables("billTotal").Rows.Count > 0 Then
                    If gdataset.Tables("billTotal").Rows.Count = 1 Then
                        trnBalance = Val(gdataset.Tables("BillTotal").Rows(0).Item(0))
                    End If
                End If
                Dim V As Integer
                For V = 1 To 1
                    If V = 1 Then
                        sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
                        'sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
                        sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
                        sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,"
                        sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
                        sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
                        sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
                        sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

                        sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
                        sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME,BILL_HDR.DELFLAG,"
                        sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
                        sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,D.KOTNO,D.KOTDETAILS,"
                        sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS"
                        sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "

                    Else
                        sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
                        sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,D.KOTDATE,ITEMCODE,D.KOTNO,ITEMDESC,D.POSCODE,D.UOM,D.QTY,"
                        sql = sql & "ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,ISNULL(D.TAXAMOUNT,0) as TAXAMOUNT,"
                        sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(D.TABLENO,'') AS TABLENO,"
                        sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN  "
                        sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
                        sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "
                        sql = sql & " WHERE ISNULL(D.CATEGORY,'')<>'BAR' AND D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
                        sql = sql & " ORDER BY D.KOTDETAILS,D.BillDetails"
                    End If
                    gconnection.getDataSet(sql, "ReportTable")
                    Dim adduserid As String
                    adduserid = ""
                    If gdataset.Tables("ReportTable").Rows.Count > 0 Then
                        vline = ""
                        BillNo = Trim(gdataset.Tables("ReportTable").Rows(0).Item("BillDetails"))
                        taxpercentage = Val(gdataset.Tables("ReportTable").Rows(0).Item("TaxPerc"))
                        Kot = ""
                        ssgrid_settlement.SetActiveCell(1, 1)
                        splmember = ""
                        ssgrid_settlement.SetActiveCell(1, 1)
                        TaxAmount = 0
                        TotalAmount = 0
                        vPackAmt = 0 : vTipsAmt = 0 : vAdAmt = 0 : vPartyAmt = 0 : vRoomAmt = 0
                        Dim SETMCODE As String
                        Dim SETAMOUNT As Double
                        Dim vpagenumber, Vrowcount, innercount, taxcount As Long
                        Dim headercount As Double
                        Dim ROOMNO As Integer
                        Dim SSQLROOM, poscode, PAYMENTMODE, MCODE, MNAME, GUEST As String
                        innercount = 0
                        Vrowcount = 0
                        vpagenumber = 1
                        SETMCODE = ""
                        SETAMOUNT = 0
                        ssgrid_settlement.Col = 1
                        ssgrid_settlement.Row = J
                        SETMCODE = (ssgrid_settlement.Text)
                        ssgrid_settlement.Col = 2
                        ssgrid_settlement.Row = J
                        SETAMOUNT = Format(Val(ssgrid_settlement.Text), "0.00")
                        poscode = Trim(gdataset.Tables("ReportTable").Rows(0).Item("poscode"))
                        servicelocation = Trim(gdataset.Tables("ReportTable").Rows(0).Item("servicelocation"))
                        adduserid = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ADDUSERID"))
                        addUser = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ADDUSERID"))

                        PAYMENTMODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("PAYMENTMODE"))
                        MCODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("MCODE"))
                        MNAME = Trim(gdataset.Tables("ReportTable").Rows(0).Item("MNAME"))
                        GUEST = Trim(gdataset.Tables("ReportTable").Rows(0).Item("GUEST"))
                        ROOMNO = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ROOMNO"))
                        HBILLDETAILS = Trim(gdataset.Tables("ReportTable").Rows(0).Item("HBILLDETAILS"))
                        BILLPLACE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("HBILLDETAILS"))
                        Table = gdataset.Tables("ReportTable").Rows(0).Item("TABLENO")
                        SCODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("SCODE"))
                        SNAME = Trim(gdataset.Tables("ReportTable").Rows(0).Item("SNAME"))
                        CountItem = 0
                        ''FOR LOOP START
                        ''==============
                        For rowj = 0 To gdataset.Tables("ReportTable").Rows.Count - 1
                            CountItem = CountItem + 1
                            boolOtherBill = False
                            headercount = 1
                            If Vrowcount = 0 Then
                                If headercount = 1 Then
                                    '========================
                                    headercount = 2
                                    For i = 1 To 2
                                        Filewrite.WriteLine("")
                                    Next
                                    Vrowcount = 2
                                    Vrowcount = Vrowcount + 1

                                    If gCompanyname <> "" Then
                                        ' Rowprint = Space(3) & Chr(18) & Chr(27) + "E" & Space(10) & gCompanyname & Space(2) & Chr(27) + "F"
                                        Rowprint = Space(5) & Chr(27) & Chr(106) & Chr(200) & Chr(27) + "E" & gCompanyname & Chr(27) + "F"
                                        Filewrite.WriteLine(Rowprint & Chr(15))
                                        Vrowcount = Vrowcount + 1
                                    End If

                                    If UCase(Trim(gdataset.Tables("ReportTable").Rows(0).Item("PRN"))) = "Y" Then
                                        Filewrite.WriteLine(Space(8) & "DUPLICATE")
                                    Else
                                        Filewrite.WriteLine("")
                                    End If
                                    If gTINNO <> "" Then
                                        Filewrite.WriteLine("{0,-11}{1,-20}", Space(3) & "TINNO" & Space(2) & ":", gTINNO)
                                    End If
                                    Rowprint = Space(3) & "BILL NO   :"
                                    Rowprint = Rowprint & Trim(HBILLDETAILS)
                                    Filewrite.WriteLine(Rowprint)
                                    Rowprint = Space(3) & "BILL DATE :"
                                    Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillDate"), "dd/MM/yyyy")
                                    Rowprint = Rowprint & " "
                                    Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillTime"), "T")
                                    Filewrite.WriteLine(Rowprint)

                                    Filewrite.WriteLine(Space(3) & "{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))

                                    Rowprint = Space(3) & Chr(15) & "WAITER    :" & Chr(15)
                                    Rowprint = Rowprint
                                    Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("SCODE"))
                                    Rowprint = Chr(17) & Rowprint & "("
                                    Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("sname"))
                                    Rowprint = Trim(Rowprint) & ")"
                                    Filewrite.WriteLine(Chr(17) & Rowprint)
                                    If MCODE = "" Then
                                        Rowprint = Space(3) & "ROOM NO   :"
                                        Rowprint = Rowprint & Space(1) & Chr(15) & Trim(ROOMNO)
                                        Filewrite.WriteLine(Rowprint & Chr(15))
                                        Rowprint = Space(3) & "GUEST NAME:" & Space(1) & Chr(15) & Trim(GUEST)
                                        Filewrite.WriteLine(Rowprint & Chr(17))
                                    Else
                                        Rowprint = Space(3) & "MEM CODE  :"
                                        Rowprint = Rowprint & Space(1) & Chr(15) & Trim(MCODE)
                                        Filewrite.WriteLine(Rowprint & Chr(15))
                                        Rowprint = Space(3) & "MEM NAME  :" & Space(1) & Chr(15) & Trim(MNAME)
                                        Filewrite.WriteLine(Rowprint & Chr(17))
                                    End If
                                    If Trim(Table) <> "" Then
                                        Rowprint = Space(3) & "TABLE     :"
                                        Rowprint = Rowprint & Space(1) & Chr(15) & Trim(Table)
                                        Filewrite.WriteLine(Rowprint & Chr(15))
                                    End If
                                    If gCompanyname <> "" Then
                                        Filewrite.Write(Space(3) & StrDup(45, "-"))
                                        Filewrite.WriteLine()
                                        Vrowcount = Vrowcount + 1
                                        Rowprint = Space(3) & "ITEM DESC            UOM  QTY  AMOUNT KOTNO"
                                        Filewrite.WriteLine(Rowprint)
                                    End If
                                    '13
                                    Vrowcount = Vrowcount + 1
                                    Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
                                    '14
                                    Vrowcount = Vrowcount + 1
                                    Filewrite.WriteLine("")
                                    '15
                                    Vrowcount = Vrowcount + 2
                                    '16
                                    Vrowcount = Vrowcount + 1
                                End If
                            End If
                            With gdataset.Tables("ReportTable").Rows(rowj)
                                If gCompanyname <> "" Then
                                    'Rowprint = ""
                                    'Rowprint = Rowprint & Mid(Trim(.Item("ITEMDESC") & ""), 1, 19) & Space(19 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 19))) & Space(1)
                                    'Rowprint = Rowprint & Mid(Val(.Item("QTY") & ""), 1, 3) & Space(3 - Len(Mid(Trim(.Item("QTY") & ""), 1, 3))) & Space(1)
                                    'Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("RATE") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("RATE") & ""), "0.00"), 1, 7) & Space(1)
                                    'Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7)
                                    Rowprint = Space(3) & ""
                                    Rowprint = Rowprint & Mid(Trim(.Item("ITEMDESC") & ""), 1, 19) & Space(19 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 19))) & Space(1)
                                    Rowprint = Rowprint & Mid(Trim(.Item("UOM") & ""), 1, 6) & Space(7 - Len(Mid(Trim(.Item("UOM") & ""), 1, 6))) & Space(1)
                                    Rowprint = Rowprint & Mid(Val(.Item("QTY") & ""), 1, 3) & Space(3 - Len(Mid(Trim(.Item("QTY") & ""), 1, 3))) & Space(1)
                                    Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7) & Space(1)
                                    Rowprint = Rowprint & Mid(Trim(.Item("KOTNO") & ""), 1, 6) & Space(7 - Len(Mid(Trim(.Item("KOTNO") & ""), 1, 6))) & Space(1)
                                    'If Vrowcount = 13 Or Vrowcount = 42 Or Vrowcount = 67 Then
                                    '    For i = 0 To 6
                                    '        Filewrite.WriteLine()
                                    '    Next
                                    'End If
                                    TotalAmount = TotalAmount + Val(.Item("Amount"))
                                    TaxAmount = TaxAmount + Val(.Item("TaxAmount"))
                                    vPackAmt = vPackAmt + Val(.Item("PACKAMOUNT"))
                                    vTipsAmt = vTipsAmt + Val(.Item("TipsAmt"))
                                    vAdAmt = vAdAmt + Val(.Item("AdCgsAmt"))
                                    vPartyAmt = vPartyAmt + Val(.Item("PartyAmt"))
                                    vRoomAmt = vRoomAmt + Val(.Item("RoomAmt"))
                                    Filewrite.WriteLine(Rowprint & Chr(17))
                                    Vrowcount = Vrowcount + 1
                                    innercount = innercount + 1
                                    If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                                        For i = 1 To 6
                                            Filewrite.WriteLine()
                                            Vrowcount = Vrowcount + 1
                                        Next
                                    End If
                                End If
                            End With
                        Next rowj
                        taxcount = 0

                        If gCompanyname <> "" Then
                            Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
                        End If
                        'If Vrowcount = 21 Or Vrowcount = 51 Then
                        '    For i = 0 To 10
                        '        Filewrite.WriteLine()
                        '    Next
                        'End If
                        taxcount = taxcount + 1
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        Rowprint = Space(3) & "Total:" & Space(23) & Space(8 - Len(Mid(Trim(Format(TotalAmount, "0.00")), 1, 8))) & Mid(Trim(Format(TotalAmount, "0.00")), 1, 8)
                        Filewrite.WriteLine(Rowprint)
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        If gCompanyname <> "" Then
                            Vrowcount = Vrowcount + 1
                            taxcount = taxcount + 1
                            sqlstring = "SELECT isnull(sum(a.TAXAMT),0) as Taxamount,A.TAXCODE,B.TAXDESC,'' AS SYMB FROM KOT_DET_TAX A,accountstaxmaster B"
                            sqlstring = sqlstring & " WHERE A.TAXCODE = B.taxcode AND ISNULL(VOID,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND TAXAMT > 0"
                            sqlstring = sqlstring & "AND KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_det WHERE billdetails ='" & Trim(HBILLDETAILS) & "')"
                            sqlstring = sqlstring & " GROUP BY A.TAXCODE,B.taxdesc"
                            gconnection.getDataSet(sqlstring, "TaxDet")
                            For i = 0 To gdataset.Tables("TaxDet").Rows.Count - 1
                                Rowprint = Space(3) & Mid(gdataset.Tables("TaxDet").Rows(i).Item("TAXDESC"), 1, 29) & Space(29 - Len(Mid(gdataset.Tables("TaxDet").Rows(i).Item("TAXDESC"), 1, 29)))
                                Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(gdataset.Tables("TaxDet").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("TaxDet").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8)
                                Filewrite.WriteLine(Rowprint & Chr(17))
                                taxcount = taxcount + 1
                                Vrowcount = Vrowcount + 1
                                If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                                    For J = 1 To 6
                                        Filewrite.WriteLine()
                                    Next
                                End If
                            Next
                        End If
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                            Next
                        End If
                        sqlstring = "SELECT SaleType FROM KOT_HDR WHERE Kotdetails IN (SELECT Kotdetails FROM KOT_DET WHERE billdetails ='" & Trim(HBILLDETAILS) & "')"
                        gconnection.getDataSet(sqlstring, "ChargesTag")
                        If gdataset.Tables("ChargesTag").Rows.Count > 0 Then
                            If Trim(gdataset.Tables("ChargesTag").Rows(0).Item(0)) = "SALE" Then
                                sqlstring = "SELECT PCKDESC,SCDESC,ADDESC FROM POSSETUP"
                                gconnection.getDataSet(sqlstring, "DESC")
                                If gdataset.Tables("DESC").Rows.Count > 0 Then
                                    PackDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(0))
                                    TipsDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(1))
                                    AddChgDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(2))
                                End If
                            Else
                                sqlstring = "SELECT PCKDESC,SCDESC,ADDESC FROM POSMASTER WHERE POSCODE = '" & poscode & "'"
                                gconnection.getDataSet(sqlstring, "DESC")
                                If gdataset.Tables("DESC").Rows.Count > 0 Then
                                    PackDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(0))
                                    TipsDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(1))
                                    AddChgDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(2))
                                End If
                            End If
                        End If
                        If vPackAmt > 0 Then
                            Rowprint = Space(3) & Mid(PackDesc, 1, 29) & Space(29 - Len(Mid(PackDesc, 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vPackAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vPackAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                        End If
                        If vTipsAmt > 0 Then
                            Rowprint = Space(3) & Mid(TipsDesc, 1, 29) & Space(29 - Len(Mid(TipsDesc, 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                        End If
                        If vAdAmt > 0 Then
                            Rowprint = Space(3) & Mid(AddChgDesc, 1, 29) & Space(29 - Len(Mid(AddChgDesc, 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                        End If
                        If vPartyAmt > 0 Then
                            Rowprint = Space(3) & Mid("Add Party Charges", 1, 29) & Space(29 - Len(Mid("Add Party Charges", 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                        End If
                        If vRoomAmt > 0 Then
                            Rowprint = Space(3) & Mid("Add Room Charges", 1, 29) & Space(29 - Len(Mid("Add Room Charges", 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                        End If

                        'sqlstring = "select isnull(sum(a.packamount),0) as Taxamount,'S.Tax' as itemtypedesc,isnull(b.symb,'')as symb from KOT_det a,"
                        'sqlstring = sqlstring & "itemtypemaster b where a.taxcode=b.taxcode and isnull(a.delflag,'')<>'Y' AND "
                        'sqlstring = sqlstring & " a.packamount>0 AND a.billdetails ='" & Trim(HBILLDETAILS) & "'"
                        'sqlstring = sqlstring & "  group by isnull(b.symb,'')"
                        'gconnection.getDataSet(sqlstring, "TaxDetn")
                        'If gdataset.Tables("taxdetn").Rows.Count > 0 Then
                        '    For i = 0 To gdataset.Tables("TaxDetn").Rows.Count - 1
                        '        'Rowprint = Mid(gdataset.Tables("TaxDet").Rows(i).Item("ItemtypeDesc"), 1, 14) & Space(14 - Len(Mid(gdataset.Tables("TaxDet").Rows(i).Item("ItemtypeDesc"), 1, 14)) & Space(1) & gdataset.Tables("TaxDet").Rows(i).Item("symb"))

                        '        Rowprint = Space(3) & Mid(gdataset.Tables("TaxDetn").Rows(i).Item("ItemtypeDesc"), 1, 13) & Space(2) & gdataset.Tables("TaxDetn").Rows(i).Item("symb")
                        '        Rowprint = Rowprint & Space(30 - Len(Mid(Format(Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8)
                        '        Filewrite.WriteLine(Rowprint & Chr(17))
                        '        TaxAmount = TaxAmount + Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount"))
                        '        taxcount = taxcount + 1
                        '        Vrowcount = Vrowcount + 1
                        '    Next
                        'End If

                        Amt = Math.Round(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt, 0) - (TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)
                        'Amt = GetRoundVal(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)
                        Rowprint = Space(3) & "Round Off" & Space(20) & Space(8 - Len(Mid(Trim(Format(Amt, "0.00")), 1, 8))) & Mid(Trim(Format(Amt, "0.00")), 1, 8)
                        If Amt <> 0 Then
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                        End If
                        '------------------------------------------
                        Amt = 0

                        Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
                        taxcount = taxcount + 1
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                            Next
                        End If
                        Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("BILL AMOUNT:", 1, 15) & Space(15 - Len(Mid("BILL AMOUNT:", 1, 15)))
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        If Amt < 0 Then
                            Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt * -1), "0.00")
                            toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt * -1), "0.00")

                        Else
                            Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
                            toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
                        End If
                        'If Amt < 0 Then
                        '    Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt), "0.00")
                        '    toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt), "0.00")

                        'Else
                        '    'Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
                        '    'toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
                        '    Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
                        '    toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")

                        'End If
                        Filewrite.WriteLine(Rowprint & Chr(15))
                        '10
                        taxcount = taxcount + 1
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                            Next
                        End If
                        Filewrite.WriteLine(Space(3) & Chr(15) & Chr(27) & StrDup(45, "-"))
                        Vrowcount = Vrowcount + 1
                        '11
                        taxcount = taxcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                            Next
                        End If

                        Dim sstring As String
                        sstring = "SELECT distinct D.KOTNO,d.billdetails,D.KOTDETAILS,D.KOTDATE "
                        sstring = sstring & "  FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
                        sstring = sstring & " WHERE D.Billdetails = '" & BillNo & "' "
                        sstring = sstring & " AND ISNULL(KotStatus,'N')='N'"
                        sstring = sstring & " order by d.billdetails"
                        gconnection.getDataSet(sstring, "rTable")
                        For i = 0 To gdataset.Tables("rTable").Rows.Count - 1
                            Kot = Kot & "," & gdataset.Tables("rTable").Rows(i).Item("Kotno")
                        Next
                        If Len(Kot) < 31 Then
                            Rowprint = Space(3) & Chr(15) & "KOT's:" & Kot & "."
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                            taxcount = taxcount + 1
                            If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                            '13
                        Else
                            Rowprint = Space(3) & "KOT's :" & Mid(Kot, 1, 28) & ","
                            Filewrite.WriteLine(Rowprint)
                            Rowprint = "             " & Mid(Kot, 29, 30) & "."
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 2
                            taxcount = taxcount + 2
                            '14
                        End If
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        Dim PAY As String
                        PAY = ""
                        'SMART CARD
                        'ROOM CHECKIN
                        'MEMBER ACCOUNT
                        'BANK INSTRUMENT
                        'CASH
                        'CLUB ACCOUNT
                        'EMPLOYEE

                        ssql = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
                        gconnection.getDataSet(ssql, "PAY")
                        If gdataset.Tables("PAY").Rows.Count > 0 Then
                            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
                        Else
                            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                            Exit Sub
                        End If
                        CardClBalance = CardOpBalance - trnBalance
                        Filewrite.WriteLine("")
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                            For J = 1 To 6
                                Filewrite.WriteLine()
                            Next
                        End If
                        If PAY = "SMART CARD" Then
                            Filewrite.WriteLine(Space(3) & Chr(14) & Chr(15) & "CARD OP BAL. TRN AMOUNT  CLBAL.")
                            Vrowcount = Vrowcount + 1
                            Filewrite.WriteLine(Space(3) & "--------------------------------------------------")
                            Vrowcount = Vrowcount + 1
                            Rowprint = Space(3) & Chr(14) & Chr(15) & Space(9 - Len(CStr(Format(CardOpBalance, "0.00")))) & Mid(Format(CardOpBalance, "0.00"), 1, 9)
                            Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(trnBalance, "0.00")), 1, 9))) & Mid(Format(trnBalance, "0.00"), 1, 9)
                            Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(CardClBalance, "0.00")), 1, 9))) & Mid(Format(CardClBalance, "0.00"), 1, 9)
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                            Filewrite.WriteLine(Space(3) & "---------------------------------------------------")
                            Vrowcount = Vrowcount + 1
                            rowno = Vrowcount
                        End If
                        CardOpBalance = CardClBalance
                        For i = 1 To 1
                            Filewrite.WriteLine("")
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 13 Or Vrowcount = 38 Or Vrowcount = 63 Then
                                For J = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        Next
                        rowno = Vrowcount
                        SSQL1 = "UPDATE BILL_HDR SET PRINTFLAG='Y' WHERE BILLDETAILS='" & Trim(Me.txt_BillNo.Text) & "'"
                        gconnection.ExcuteStoreProcedure(SSQL1)
                    End If
                Next
                cpt = cpt + 1
            Next
        End If

        If cpt > 1 Then
            Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
            Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("TOTAL AMOUNT:", 1, 15) & Space(15 - Len(Mid("TOTAL AMOUNT:", 1, 15)))
            Rowprint = Rowprint & Format(Val((toalamt)), "0.00")
            Filewrite.WriteLine(Rowprint)
            Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
        End If
        Rowprint = Chr(15) + "In Words:" & RupeesToWord(Val(Format(toalamt, "0.00"))) + "F" & Chr(15)
        Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        rowno = rowno + 1
        If rowno = 13 Or rowno = 38 Or rowno = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                rowno = rowno + 1
            Next
        End If
        'If climit > 0 Then
        '    Rowprint = "CREDIT LIMIT Rs." & Format(Val(climit), "0.00")
        '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        '    Rowprint = "CRD.USED Rs." & Format(Val(MemberOutstand), "0.00") & Space(3) & "CRD.AVAILABLE Rs." & Format(Val(climit) - Val(MemberOutstand), "0.00")
        '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        'End If
        Rowprint = Space(3) & Chr(14) & Chr(15) & "Payment Type:" & Trim(cbo_PaymentMode.Text) & "" & Chr(15)
        Filewrite.WriteLine(Rowprint)
        rowno = rowno + 1
        If rowno = 13 Or rowno = 38 Or rowno = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                rowno = rowno + 1
            Next
        End If
        Filewrite.WriteLine("")
        rowno = rowno + 1
        If rowno = 13 Or rowno = 38 Or rowno = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                rowno = rowno + 1
            Next
        End If
        Rowprint = Space(3) & "Prepared By:" & Trim(addUser)
        Filewrite.WriteLine(Chr(16) & Rowprint)
        rowno = rowno + 1
        If rowno = 13 Or rowno = 38 Or rowno = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                rowno = rowno + 1
            Next
        End If
        If Trim(Txt_Remarks.Text) <> "" Then
            If Len(Trim(Txt_Remarks.Text)) < 65 Then
                Filewrite.WriteLine("Remarks: " & Trim(Txt_Remarks.Text))
                rowno = rowno + 1
                If rowno = 13 Or rowno = 38 Or rowno = 63 Then
                    For i = 1 To 6
                        Filewrite.WriteLine()
                        rowno = rowno + 1
                    Next
                End If
                Filewrite.WriteLine()
                rowno = rowno + 1
                If rowno = 13 Or rowno = 38 Or rowno = 63 Then
                    For i = 1 To 6
                        Filewrite.WriteLine()
                    Next
                End If
            Else
                Filewrite.WriteLine("Remarks: " & Mid(Trim(Txt_Remarks.Text), 1, 65))
                rowno = rowno + 1
                If rowno = 13 Or rowno = 38 Or rowno = 63 Then
                    For i = 1 To 6
                        Filewrite.WriteLine()
                    Next
                End If
                Filewrite.WriteLine("         " & Mid(Trim(Txt_Remarks.Text), 66, 65))
                rowno = rowno + 1
                'If rowno = 13 Or rowno = 38 Or rowno = 63 Then
                '    For i = 0 To 6
                '        Filewrite.WriteLine()
                '    Next
                'End If

            End If
        End If
        If rowno > 19 And rowno < 38 Then
            J = 38 - rowno
            J = J + 11
        ElseIf rowno > 44 And rowno < 63 Then
            J = 63 - rowno
            J = J + 11
        ElseIf rowno > 69 And rowno < 88 Then
            J = 88 - rowno
            J = J + 11
        ElseIf rowno > 94 And rowno < 113 Then
            J = 113 - rowno
            J = J + 11
        End If
        For i = 1 To J
            Filewrite.WriteLine("")
        Next
        Filewrite.Close()
        If gPrint = False Then
            OpenTextFile(vOutfile)
        Else
            PrintTextFile1(vFilepath)
        End If
    End Sub

    'Public Sub MCLUB_PRINT()
    '    Randomize()
    '    Dim rowj, Loopindex, i, Pagesize, CountItem, in1, Fo, jo, cpt As Integer
    '    Dim Rowprint, vCaption, vPath, Fsize(), Forder(), billdetails, rupeesword, splmember, servicelocation, SCODE, SNAME As String
    '    Dim BillNo, sql, sqlstring, Kot, vOutfile, vheader, vline, round, vFilepath, str, Otherbillno, BILLPLACE, Table, Loc As String
    '    Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, taxpercentage, toalamt As Double
    '    Dim CardOpBalance, CardClBalance, trnBalance, OCardOpBalance, OCardClBalance, OtrnBalance As Double
    '    Dim oth1 As Boolean
    '    Dim SSQL1, TypeFlag, PackDesc, TipsDesc, AddChgDesc As String
    '    Dim climit, ulimit, vPackAmt, vTipsAmt, vAdAmt, vPartyAmt, vRoomAmt As Double
    '    'ssql = "select isnull(memcreditlimit,0)as creditlimit from  possetup"
    '    'gconnection.getDataSet(ssql, "climit")
    '    'If gdataset.Tables("climit").Rows.Count > 0 Then
    '    '    If gdataset.Tables("climit").Rows(0).Item("creditlimit") > 0 Then
    '    '        climit = gdataset.Tables("climit").Rows(0).Item("creditlimit")
    '    '        ssql = "exec get_creditlimit'" & Me.txt_MemberCode.Text & "'"
    '    '        gconnection.ExcuteStoreProcedure(ssql)
    '    '        ssql = "SELECT * FROM balance WHERE MCODE='" & Me.txt_MemberCode.Text & "'"
    '    '        gconnection.getDataSet(ssql, "CRD")
    '    '        If gdataset.Tables("CRD").Rows.Count > 0 Then
    '    '            MemberOutstand = gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
    '    '            'Me.LAB_OUTSTAND.Text = "MEMBER OUTSTANDING :" & gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
    '    '        Else
    '    '            MemberOutstand = 0
    '    '        End If

    '    '        If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
    '    '            MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '    '            'Exit Sub
    '    '        End If
    '    '    End If
    '    'End If

    '    Dim Otrnbalance2 As Long
    '    Dim OCardOpBalance2 As Long
    '    sqlstring = "SELECT ISNULL(BALANCE,0) BALANCE FROM SM_CARDFILE_HDR WHERE CARDCODE='" & txt_Holder_Code.Text & "'  "
    '    gconnection.getDataSet(sqlstring, "balanceAmount")

    '    If gdataset.Tables("balanceAmount").Rows.Count > 0 Then
    '        CardOpBalance = Val(gdataset.Tables("balanceAmount").Rows(0).Item(0))
    '    End If
    '    sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
    '    gconnection.getDataSet(sql, "Bill_det")
    '    If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '        Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
    '        oth1 = True
    '        If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
    '            oth1 = False
    '            sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
    '            gconnection.getDataSet(sql, "Bill_det")
    '            If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '                Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("billdetails") & "")
    '                oth1 = True
    '            End If
    '        End If
    '    Else
    '        oth1 = False
    '    End If
    '    If oth1 = True Then
    '        billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_BillNo.Text) & "'"
    '    Else
    '        billdetails = "'" & Trim(Me.txt_BillNo.Text) & "'"
    '    End If
    '    sqlstring = "SELECT  isnull(SUM(isnull(BILL_AMOUNT,0)),0) DFM, isnull(SUM(isnull(DEDUCT_FROM_CARD,0)),0) DFC FROM SM_POSTRANSACTION WHERE isnull(VOID,'')<>'Y' and BILL_NO in (" & Trim(billdetails) & ") "
    '    gconnection.getDataSet(sqlstring, "BillTotal")
    '    If gdataset.Tables("billTotal").Rows.Count > 0 Then
    '        If gdataset.Tables("billTotal").Rows.Count = 1 Then
    '            trnBalance = Val(gdataset.Tables("BillTotal").Rows(0).Item(0))
    '        End If
    '    End If
    '    cpt = 0
    '    CardOpBalance = CardOpBalance + Math.Round(trnBalance) '+ Math.Round(OtrnBalance)

    '    Dim ds As New DataSet
    '    Dim Otherbool, boolOtherBill As Boolean
    '    Dim addUser As String
    '    Dim Filewrite As StreamWriter
    '    gCompanyname = MyCompanyName
    '    gCompanyAddress(0) = Address1
    '    gCompanyAddress(1) = Address2
    '    'gtinno(0) = gtinno
    '    Dim HBILLDETAILS As String
    '    vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
    '    vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"

    '    sql = "SELECT ISNULL(TINNO,'') AS TINNO FROM master..CLUBMASTER WHERE DATAFILE = '" & Trim(gDatabase) & "'"
    '    gconnection.getDataSet(sql, "CLUBMASTER")
    '    If gdataset.Tables("CLUBMASTER").Rows.Count > 0 Then
    '        gTINNO = gdataset.Tables("CLUBMASTER").Rows(0).Item("TinNo")
    '    End If

    '    sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
    '    gconnection.getDataSet(sql, "Bill_det")
    '    If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '        Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
    '        Otherbool = True
    '        If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
    '            Otherbool = False
    '            sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_BillNo.Text)) & "'"
    '            gconnection.getDataSet(sql, "Bill_det")
    '            If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '                Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("billdetails") & "")
    '                Otherbool = True
    '            End If
    '        End If
    '    Else
    '        Otherbool = False
    '    End If
    '    If Otherbool = True Then
    '        billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_BillNo.Text) & "'"
    '    Else
    '        billdetails = "'" & Trim(Me.txt_BillNo.Text) & "'"
    '    End If
    '    Filewrite = File.AppendText(vFilepath)
    '    sql = "select billdetails from bill_hdr where billdetails in (" & Trim(billdetails) & ") and isnull(delflag,'')<>'Y' "
    '    gconnection.getDataSet(sql, "billing")
    '    If gdataset.Tables("billing").Rows.Count > 0 Then
    '        For jo = 0 To gdataset.Tables("billing").Rows.Count - 1
    '            billdetails = "'" & gdataset.Tables("billing").Rows(jo).Item("billdetails") & "'"

    '            sqlstring = "SELECT isnull(SUM(isnull(BILL_AMOUNT,0)),0) DFM, isnull(SUM(isnull(DEDUCT_FROM_CARD,0)),0) DFC FROM SM_POSTRANSACTION WHERE isnull(VOID,'')<>'Y' and BILL_NO =" & billdetails & "  "
    '            gconnection.getDataSet(sqlstring, "BillTotal")
    '            If gdataset.Tables("billTotal").Rows.Count > 0 Then
    '                If gdataset.Tables("billTotal").Rows.Count = 1 Then
    '                    trnBalance = Val(gdataset.Tables("BillTotal").Rows(0).Item(0))
    '                End If
    '            End If
    '            Dim V As Integer
    '            For V = 1 To 1
    '                If V = 1 Then
    '                    sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
    '                    'sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
    '                    sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
    '                    sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,"
    '                    sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
    '                    sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
    '                    sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
    '                    sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

    '                    sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
    '                    sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME,BILL_HDR.DELFLAG,"
    '                    sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
    '                    sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,D.KOTNO,D.KOTDETAILS,"
    '                    sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS"
    '                    sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "

    '                Else
    '                    sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
    '                    sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,D.KOTDATE,ITEMCODE,D.KOTNO,ITEMDESC,D.POSCODE,D.UOM,D.QTY,"
    '                    sql = sql & "ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,ISNULL(D.TAXAMOUNT,0) as TAXAMOUNT,"
    '                    sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(D.TABLENO,'') AS TABLENO,"
    '                    sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN  "
    '                    sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
    '                    sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "
    '                    sql = sql & " WHERE ISNULL(D.CATEGORY,'')<>'BAR' AND D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
    '                    sql = sql & " ORDER BY D.KOTDETAILS,D.BillDetails"
    '                End If
    '                gconnection.getDataSet(sql, "ReportTable")
    '                Dim adduserid As String
    '                adduserid = ""
    '                If gdataset.Tables("ReportTable").Rows.Count > 0 Then
    '                    vline = ""
    '                    BillNo = Trim(gdataset.Tables("ReportTable").Rows(0).Item("BillDetails"))
    '                    taxpercentage = Val(gdataset.Tables("ReportTable").Rows(0).Item("TaxPerc"))
    '                    Kot = ""
    '                    ssgrid_settlement.SetActiveCell(1, 1)
    '                    splmember = ""
    '                    ssgrid_settlement.SetActiveCell(1, 1)
    '                    TaxAmount = 0
    '                    TotalAmount = 0
    '                    vPackAmt = 0 : vTipsAmt = 0 : vAdAmt = 0 : vPartyAmt = 0 : vRoomAmt = 0
    '                    Dim SETMCODE As String
    '                    Dim SETAMOUNT As Double
    '                    Dim vpagenumber, Vrowcount, innercount, taxcount As Long
    '                    Dim headercount As Double
    '                    Dim ROOMNO As Integer
    '                    Dim SSQLROOM, poscode, PAYMENTMODE, MCODE, MNAME, GUEST As String
    '                    innercount = 0
    '                    Vrowcount = 0
    '                    vpagenumber = 1
    '                    SETMCODE = ""
    '                    SETAMOUNT = 0
    '                    ssgrid_settlement.Col = 1
    '                    ssgrid_settlement.Row = J
    '                    SETMCODE = (ssgrid_settlement.Text)
    '                    ssgrid_settlement.Col = 2
    '                    ssgrid_settlement.Row = J
    '                    SETAMOUNT = Format(Val(ssgrid_settlement.Text), "0.00")
    '                    poscode = Trim(gdataset.Tables("ReportTable").Rows(0).Item("poscode"))
    '                    servicelocation = Trim(gdataset.Tables("ReportTable").Rows(0).Item("servicelocation"))
    '                    adduserid = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ADDUSERID"))
    '                    addUser = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ADDUSERID"))

    '                    PAYMENTMODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("PAYMENTMODE"))
    '                    MCODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("MCODE"))
    '                    MNAME = Trim(gdataset.Tables("ReportTable").Rows(0).Item("MNAME"))
    '                    GUEST = Trim(gdataset.Tables("ReportTable").Rows(0).Item("GUEST"))
    '                    ROOMNO = Trim(gdataset.Tables("ReportTable").Rows(0).Item("ROOMNO"))
    '                    HBILLDETAILS = Trim(gdataset.Tables("ReportTable").Rows(0).Item("HBILLDETAILS"))
    '                    BILLPLACE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("HBILLDETAILS"))
    '                    Table = gdataset.Tables("ReportTable").Rows(0).Item("TABLENO")
    '                    SCODE = Trim(gdataset.Tables("ReportTable").Rows(0).Item("SCODE"))
    '                    SNAME = Trim(gdataset.Tables("ReportTable").Rows(0).Item("SNAME"))
    '                    CountItem = 0
    '                    ''FOR LOOP START
    '                    ''==============
    '                    For rowj = 0 To gdataset.Tables("ReportTable").Rows.Count - 1
    '                        CountItem = CountItem + 1
    '                        boolOtherBill = False
    '                        headercount = 1
    '                        If Vrowcount = 0 Then
    '                            If headercount = 1 Then
    '                                '========================
    '                                headercount = 2
    '                                For i = 1 To 2
    '                                    Filewrite.WriteLine("")
    '                                Next
    '                                Vrowcount = 2
    '                                Vrowcount = Vrowcount + 1

    '                                If gCompanyname <> "" Then
    '                                    Rowprint = Space(3) & Chr(18) & Chr(27) + "E" & Space(10) & gCompanyname & Space(2) & Chr(27) + "F"
    '                                    Filewrite.WriteLine(Rowprint & Chr(18))
    '                                    Vrowcount = Vrowcount + 1
    '                                End If

    '                                If UCase(Trim(gdataset.Tables("ReportTable").Rows(0).Item("PRN"))) = "Y" Then
    '                                    Filewrite.WriteLine(Space(8) & "DUPLICATE")
    '                                Else
    '                                    Filewrite.WriteLine("")
    '                                End If
    '                                If gTINNO <> "" Then
    '                                    Filewrite.WriteLine("{0,-11}{1,-20}", Space(3) & "TINNO" & Space(2) & ":", gTINNO)
    '                                End If
    '                                Rowprint = Space(3) & "BILL NO   :"
    '                                Rowprint = Rowprint & Trim(HBILLDETAILS)
    '                                Filewrite.WriteLine(Rowprint)
    '                                Rowprint = Space(3) & "BILL DATE :"
    '                                Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillDate"), "dd/MM/yyyy")
    '                                Rowprint = Rowprint & " "
    '                                Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillTime"), "T")
    '                                Filewrite.WriteLine(Rowprint)

    '                                Filewrite.WriteLine(Space(3) & "{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))

    '                                Rowprint = Space(3) & "WAITER    :"
    '                                Rowprint = Rowprint
    '                                Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("SCODE"))
    '                                Rowprint = Chr(17) & Rowprint & "("
    '                                Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("sname"))
    '                                Rowprint = Trim(Rowprint) & ")"
    '                                Filewrite.WriteLine(Chr(17) & Rowprint)
    '                                If MCODE = "" Then
    '                                    Rowprint = Space(3) & "ROOM NO   :"
    '                                    Rowprint = Rowprint & Space(1) & Chr(18) & Trim(ROOMNO)
    '                                    Filewrite.WriteLine(Rowprint & Chr(18))
    '                                    Rowprint = Space(3) & "GUEST NAME:" & Space(1) & Chr(18) & Trim(GUEST)
    '                                    Filewrite.WriteLine(Rowprint & Chr(17))
    '                                Else
    '                                    Rowprint = Space(3) & "MEM CODE  :"
    '                                    Rowprint = Rowprint & Space(1) & Chr(18) & Trim(MCODE)
    '                                    Filewrite.WriteLine(Rowprint & Chr(18))
    '                                    Rowprint = Space(3) & "MEM NAME  :" & Space(1) & Chr(18) & Trim(MNAME)
    '                                    Filewrite.WriteLine(Rowprint & Chr(17))
    '                                End If
    '                                If Trim(Table) <> "" Then
    '                                    Rowprint = Space(3) & "TABLE     :"
    '                                    Rowprint = Rowprint & Space(1) & Chr(18) & Trim(Table)
    '                                    Filewrite.WriteLine(Rowprint & Chr(18))
    '                                End If
    '                                If gCompanyname <> "" Then
    '                                    Filewrite.Write(Space(3) & StrDup(45, "-"))
    '                                    Filewrite.WriteLine()
    '                                    Vrowcount = Vrowcount + 1
    '                                    Rowprint = Space(3) & "ITEM DESC            UOM  QTY  AMOUNT KOTNO"
    '                                    Filewrite.WriteLine(Rowprint)
    '                                End If
    '                                '13
    '                                Vrowcount = Vrowcount + 1
    '                                Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
    '                                '14
    '                                Vrowcount = Vrowcount + 1
    '                                Filewrite.WriteLine("")
    '                                '15
    '                                Vrowcount = Vrowcount + 2
    '                                '16
    '                                Vrowcount = Vrowcount + 1
    '                            End If
    '                        End If
    '                        With gdataset.Tables("ReportTable").Rows(rowj)
    '                            If gCompanyname <> "" Then

    '                                'Rowprint = ""
    '                                'Rowprint = Rowprint & Mid(Trim(.Item("ITEMDESC") & ""), 1, 19) & Space(19 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 19))) & Space(1)

    '                                'Rowprint = Rowprint & Mid(Val(.Item("QTY") & ""), 1, 3) & Space(3 - Len(Mid(Trim(.Item("QTY") & ""), 1, 3))) & Space(1)

    '                                'Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("RATE") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("RATE") & ""), "0.00"), 1, 7) & Space(1)

    '                                'Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7)

    '                                Rowprint = Space(3) & ""
    '                                Rowprint = Rowprint & Mid(Trim(.Item("ITEMDESC") & ""), 1, 19) & Space(19 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 19))) & Space(1)
    '                                Rowprint = Rowprint & Mid(Trim(.Item("UOM") & ""), 1, 6) & Space(7 - Len(Mid(Trim(.Item("UOM") & ""), 1, 6))) & Space(1)
    '                                Rowprint = Rowprint & Mid(Val(.Item("QTY") & ""), 1, 3) & Space(3 - Len(Mid(Trim(.Item("QTY") & ""), 1, 3))) & Space(1)
    '                                Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7) & Space(1)

    '                                Rowprint = Rowprint & Mid(Trim(.Item("KOTNO") & ""), 1, 6) & Space(7 - Len(Mid(Trim(.Item("KOTNO") & ""), 1, 6))) & Space(1)

    '                                TotalAmount = TotalAmount + Val(.Item("Amount"))
    '                                TaxAmount = TaxAmount + Val(.Item("TaxAmount"))
    '                                vPackAmt = vPackAmt + Val(.Item("PACKAMOUNT"))
    '                                vTipsAmt = vTipsAmt + Val(.Item("TipsAmt"))
    '                                vAdAmt = vAdAmt + Val(.Item("AdCgsAmt"))
    '                                vPartyAmt = vPartyAmt + Val(.Item("PartyAmt"))
    '                                vRoomAmt = vRoomAmt + Val(.Item("RoomAmt"))
    '                                Filewrite.WriteLine(Rowprint & Chr(17))
    '                                Vrowcount = Vrowcount + 1
    '                                innercount = innercount + 1
    '                            End If
    '                        End With
    '                    Next rowj
    '                    taxcount = 0

    '                    If gCompanyname <> "" Then
    '                        Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
    '                    End If

    '                    taxcount = taxcount + 1
    '                    Vrowcount = Vrowcount + 1

    '                    Rowprint = Space(3) & "Total:" & Space(23) & Space(8 - Len(Mid(Trim(Format(TotalAmount, "0.00")), 1, 8))) & Mid(Trim(Format(TotalAmount, "0.00")), 1, 8)
    '                    Filewrite.WriteLine(Rowprint)

    '                    If gCompanyname <> "" Then
    '                        Vrowcount = Vrowcount + 1
    '                        '2
    '                        taxcount = taxcount + 1
    '                        sqlstring = "SELECT isnull(sum(a.TAXAMT),0) as Taxamount,A.TAXCODE,B.TAXDESC,'' AS SYMB FROM KOT_DET_TAX A,accountstaxmaster B"
    '                        sqlstring = sqlstring & " WHERE A.TAXCODE = B.taxcode AND ISNULL(VOID,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND TAXAMT > 0"
    '                        sqlstring = sqlstring & "AND KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_det WHERE billdetails ='" & Trim(HBILLDETAILS) & "')"
    '                        sqlstring = sqlstring & " GROUP BY A.TAXCODE,B.taxdesc"
    '                        gconnection.getDataSet(sqlstring, "TaxDet")
    '                        For i = 0 To gdataset.Tables("TaxDet").Rows.Count - 1
    '                            Rowprint = Space(3) & Mid(gdataset.Tables("TaxDet").Rows(i).Item("TAXDESC"), 1, 29) & Space(29 - Len(Mid(gdataset.Tables("TaxDet").Rows(i).Item("TAXDESC"), 1, 29)))
    '                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(gdataset.Tables("TaxDet").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("TaxDet").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8)
    '                            Filewrite.WriteLine(Rowprint & Chr(17))
    '                            taxcount = taxcount + 1
    '                            Vrowcount = Vrowcount + 1
    '                        Next
    '                    End If
    '                    sqlstring = "SELECT SaleType FROM KOT_HDR WHERE Kotdetails IN (SELECT Kotdetails FROM KOT_DET WHERE billdetails ='" & Trim(HBILLDETAILS) & "')"
    '                    gconnection.getDataSet(sqlstring, "ChargesTag")
    '                    If gdataset.Tables("ChargesTag").Rows.Count > 0 Then
    '                        If Trim(gdataset.Tables("ChargesTag").Rows(0).Item(0)) = "SALE" Then
    '                            sqlstring = "SELECT PCKDESC,SCDESC,ADDESC FROM POSSETUP"
    '                            gconnection.getDataSet(sqlstring, "DESC")
    '                            If gdataset.Tables("DESC").Rows.Count > 0 Then
    '                                PackDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(0))
    '                                TipsDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(1))
    '                                AddChgDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(2))
    '                            End If
    '                        Else
    '                            sqlstring = "SELECT PCKDESC,SCDESC,ADDESC FROM POSMASTER WHERE POSCODE = '" & poscode & "'"
    '                            gconnection.getDataSet(sqlstring, "DESC")
    '                            If gdataset.Tables("DESC").Rows.Count > 0 Then
    '                                PackDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(0))
    '                                TipsDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(1))
    '                                AddChgDesc = Trim(gdataset.Tables("DESC").Rows(0).Item(2))
    '                            End If
    '                        End If
    '                    End If
    '                    If vPackAmt > 0 Then
    '                        Rowprint = Space(3) & Mid(PackDesc, 1, 29) & Space(29 - Len(Mid(PackDesc, 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vPackAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vPackAmt & ""), "0.00"), 1, 8)
    '                        Filewrite.WriteLine(Rowprint & Chr(17))
    '                        taxcount = taxcount + 1
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    If vTipsAmt > 0 Then
    '                        Rowprint = Space(3) & Mid(TipsDesc, 1, 29) & Space(29 - Len(Mid(TipsDesc, 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8)
    '                        Filewrite.WriteLine(Rowprint & Chr(17))
    '                        taxcount = taxcount + 1
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    If vAdAmt > 0 Then
    '                        Rowprint = Space(3) & Mid(AddChgDesc, 1, 29) & Space(29 - Len(Mid(AddChgDesc, 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8)
    '                        Filewrite.WriteLine(Rowprint & Chr(17))
    '                        taxcount = taxcount + 1
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    If vPartyAmt > 0 Then
    '                        Rowprint = Space(3) & Mid("Add Party Charges", 1, 29) & Space(29 - Len(Mid("Add Party Charges", 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8)
    '                        Filewrite.WriteLine(Rowprint & Chr(17))
    '                        taxcount = taxcount + 1
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    If vRoomAmt > 0 Then
    '                        Rowprint = Space(3) & Mid("Add Room Charges", 1, 29) & Space(29 - Len(Mid("Add Room Charges", 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8)
    '                        Filewrite.WriteLine(Rowprint & Chr(17))
    '                        taxcount = taxcount + 1
    '                        Vrowcount = Vrowcount + 1
    '                    End If

    '                    'sqlstring = "select isnull(sum(a.packamount),0) as Taxamount,'S.Tax' as itemtypedesc,isnull(b.symb,'')as symb from KOT_det a,"
    '                    'sqlstring = sqlstring & "itemtypemaster b where a.taxcode=b.taxcode and isnull(a.delflag,'')<>'Y' AND "
    '                    'sqlstring = sqlstring & " a.packamount>0 AND a.billdetails ='" & Trim(HBILLDETAILS) & "'"
    '                    'sqlstring = sqlstring & "  group by isnull(b.symb,'')"
    '                    'gconnection.getDataSet(sqlstring, "TaxDetn")
    '                    'If gdataset.Tables("taxdetn").Rows.Count > 0 Then
    '                    '    For i = 0 To gdataset.Tables("TaxDetn").Rows.Count - 1
    '                    '        'Rowprint = Mid(gdataset.Tables("TaxDet").Rows(i).Item("ItemtypeDesc"), 1, 14) & Space(14 - Len(Mid(gdataset.Tables("TaxDet").Rows(i).Item("ItemtypeDesc"), 1, 14)) & Space(1) & gdataset.Tables("TaxDet").Rows(i).Item("symb"))

    '                    '        Rowprint = Space(3) & Mid(gdataset.Tables("TaxDetn").Rows(i).Item("ItemtypeDesc"), 1, 13) & Space(2) & gdataset.Tables("TaxDetn").Rows(i).Item("symb")
    '                    '        Rowprint = Rowprint & Space(30 - Len(Mid(Format(Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount") & ""), "0.00"), 1, 8)
    '                    '        Filewrite.WriteLine(Rowprint & Chr(17))
    '                    '        TaxAmount = TaxAmount + Val(gdataset.Tables("TaxDetn").Rows(i).Item("taxamount"))
    '                    '        taxcount = taxcount + 1
    '                    '        Vrowcount = Vrowcount + 1
    '                    '    Next
    '                    'End If

    '                    Amt = Math.Round(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt, 0) - (TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)
    '                    'Amt = GetRoundVal(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)
    '                    Rowprint = Space(3) & "Round Off" & Space(20) & Space(8 - Len(Mid(Trim(Format(Amt, "0.00")), 1, 8))) & Mid(Trim(Format(Amt, "0.00")), 1, 8)
    '                    If Amt <> 0 Then
    '                        Filewrite.WriteLine(Rowprint)
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    '------------------------------------------
    '                    Amt = 0
    '                    Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
    '                    taxcount = taxcount + 1
    '                    Vrowcount = Vrowcount + 1
    '                    Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("BILL AMOUNT:", 1, 15) & Space(15 - Len(Mid("BILL AMOUNT:", 1, 15)))

    '                    If Amt < 0 Then
    '                        Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt * -1), "0.00")
    '                        toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt * -1), "0.00")

    '                    Else
    '                        Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
    '                        toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
    '                    End If
    '                    'If Amt < 0 Then
    '                    '    Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt), "0.00")
    '                    '    toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) - Val(Amt), "0.00")

    '                    'Else
    '                    '    'Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
    '                    '    'toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
    '                    '    Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")
    '                    '    toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt)) + Val(Amt), "0.00")

    '                    'End If
    '                    Filewrite.WriteLine(Rowprint)
    '                    '10
    '                    taxcount = taxcount + 1
    '                    Vrowcount = Vrowcount + 1
    '                    Filewrite.WriteLine(Space(3) & Chr(18) & Chr(27) & StrDup(45, "-"))
    '                    Vrowcount = Vrowcount + 1
    '                    '11
    '                    taxcount = taxcount + 1

    '                    Dim sstring As String
    '                    sstring = "SELECT distinct D.KOTNO,d.billdetails,D.KOTDETAILS,D.KOTDATE "
    '                    sstring = sstring & "  FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
    '                    sstring = sstring & " WHERE D.Billdetails = '" & BillNo & "' "
    '                    sstring = sstring & " AND ISNULL(KotStatus,'N')='N'"
    '                    sstring = sstring & " order by d.billdetails"
    '                    gconnection.getDataSet(sstring, "rTable")
    '                    For i = 0 To gdataset.Tables("rTable").Rows.Count - 1
    '                        Kot = Kot & "," & gdataset.Tables("rTable").Rows(i).Item("Kotno")
    '                    Next
    '                    If Len(Kot) < 31 Then
    '                        Rowprint = Space(3) & "KOT's:" & Kot & "."
    '                        Filewrite.WriteLine(Rowprint)
    '                        Vrowcount = Vrowcount + 1
    '                        taxcount = taxcount + 1
    '                        '13
    '                    Else
    '                        Rowprint = Space(3) & "KOT's :" & Mid(Kot, 1, 28) & ","
    '                        Filewrite.WriteLine(Rowprint)
    '                        Rowprint = "             " & Mid(Kot, 29, 30) & "."
    '                        Filewrite.WriteLine(Rowprint)
    '                        Vrowcount = Vrowcount + 2
    '                        taxcount = taxcount + 2
    '                        '14
    '                    End If

    '                    Dim PAY As String
    '                    PAY = ""
    '                    'SMART CARD
    '                    'ROOM CHECKIN
    '                    'MEMBER ACCOUNT
    '                    'BANK INSTRUMENT
    '                    'CASH
    '                    'CLUB ACCOUNT
    '                    'EMPLOYEE

    '                    ssql = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
    '                    gconnection.getDataSet(ssql, "PAY")
    '                    If gdataset.Tables("PAY").Rows.Count > 0 Then
    '                        PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
    '                    Else
    '                        MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
    '                        Exit Sub
    '                    End If
    '                    CardClBalance = CardOpBalance - trnBalance
    '                    Filewrite.WriteLine("")
    '                    If PAY = "SMART CARD" Then
    '                        Filewrite.WriteLine(Space(3) & Chr(14) & Chr(15) & "CARD OP BAL. TRN AMOUNT  CLBAL.")
    '                        Vrowcount = Vrowcount + 1
    '                        Filewrite.WriteLine(Space(3) & "--------------------------------------------------")
    '                        Vrowcount = Vrowcount + 1
    '                        Rowprint = Space(3) & Chr(14) & Chr(15) & Space(9 - Len(CStr(Format(CardOpBalance, "0.00")))) & Mid(Format(CardOpBalance, "0.00"), 1, 9)
    '                        Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(trnBalance, "0.00")), 1, 9))) & Mid(Format(trnBalance, "0.00"), 1, 9)
    '                        Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(CardClBalance, "0.00")), 1, 9))) & Mid(Format(CardClBalance, "0.00"), 1, 9)
    '                        Filewrite.WriteLine(Rowprint)
    '                        Vrowcount = Vrowcount + 1
    '                        Filewrite.WriteLine(Space(3) & "---------------------------------------------------")
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    CardOpBalance = CardClBalance
    '                    For i = 1 To 1
    '                        Filewrite.WriteLine("")
    '                    Next
    '                    SSQL1 = "UPDATE BILL_HDR SET PRINTFLAG='Y' WHERE BILLDETAILS='" & Trim(Me.txt_BillNo.Text) & "'"
    '                    gconnection.ExcuteStoreProcedure(SSQL1)

    '                End If
    '            Next
    '            cpt = cpt + 1
    '        Next
    '    End If

    '    If cpt > 1 Then
    '        Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
    '        Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("TOTAL AMOUNT:", 1, 15) & Space(15 - Len(Mid("TOTAL AMOUNT:", 1, 15)))
    '        Rowprint = Rowprint & Format(Val((toalamt)), "0.00")
    '        Filewrite.WriteLine(Rowprint)
    '        Filewrite.WriteLine(Space(3) & StrDup(45, "-"))
    '    End If
    '    Rowprint = Chr(15) & Chr(27) + "In Words:" & RupeesToWord(Val(Format(toalamt, "0.00"))) & Chr(27) + "F" & Chr(15)
    '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))

    '    'If climit > 0 Then
    '    '    Rowprint = "CREDIT LIMIT Rs." & Format(Val(climit), "0.00")
    '    '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
    '    '    Rowprint = "CRD.USED Rs." & Format(Val(MemberOutstand), "0.00") & Space(3) & "CRD.AVAILABLE Rs." & Format(Val(climit) - Val(MemberOutstand), "0.00")
    '    '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
    '    'End If

    '    Rowprint = Space(3) & Chr(14) & Chr(15) & "Payment Type:" & Trim(cbo_PaymentMode.Text) & ""
    '    Filewrite.WriteLine(Rowprint)

    '    Filewrite.WriteLine("")
    '    Rowprint = Space(3) & "Prepared By:" & Trim(addUser)
    '    Filewrite.WriteLine(Chr(16) & Rowprint)

    '    If Trim(Txt_Remarks.Text) <> "" Then
    '        If Len(Trim(Txt_Remarks.Text)) < 65 Then
    '            Filewrite.WriteLine("Remarks: " & Trim(Txt_Remarks.Text))
    '            Filewrite.WriteLine()
    '        Else
    '            Filewrite.WriteLine("Remarks: " & Mid(Trim(Txt_Remarks.Text), 1, 65))
    '            Filewrite.WriteLine("         " & Mid(Trim(Txt_Remarks.Text), 66, 65))
    '        End If
    '    End If
    '    For i = 1 To 5
    '        Filewrite.WriteLine("")
    '    Next
    '    Filewrite.Close()
    '    If gPrint = False Then
    '        OpenTextFile(vOutfile)
    '    Else
    '        PrintTextFile1(vFilepath)
    '    End If
    'End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        If Mid(Trim(UCase(gCompanyname)), 1, 10) = "THE BENGAL" Then
            Call Bengal_Print()
        Else
            gPrint = False
            Call MCLUB_PRINT()
        End If
        'gPrint = False
        'Call MCLUB_PRINT()
    End Sub
    Private Sub Bengal_Print()
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New DirectBill
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "SELECT * FROM BILL_HDR WHERE BILLDETAILS = '" & Trim(txt_BillNo.Text) & "'"
        Call Viewer.GetDetails1(sqlstring, "BILL_HDR", r)
        Viewer.TableName = "BILL_HDR"

        sqlstring = "select K.ITEMCODE,K.ITEMDESC,K.RATE,K.QTY,AMOUNT,VAT AS TAXAMOUNT,SER AS TAXAMT,ISNULL(PACKAMOUNT,0)+isnull(TipsAmt,0)+isnull(AdCgsAmt,0)+isnull(PartyAmt,0)+isnull(RoomAmt,0) AS Packamount "
        sqlstring = sqlstring & " from kot_det K,ITEM_TAX_DET_SUM T  WHERE K.KOTDETAILS = T.KOTDETAILS AND K.ITEMCODE = T.ITEMCODE AND BILLDETAILS = '" & Trim(txt_BillNo.Text) & "'"
        Call Viewer.GetDetails1(sqlstring, "KOT_DET", r)
        Viewer.TableName = "KOT_DET"

        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text8")
        'TXTOBJ5.Text = gCompanyname

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text6")
        'TXTOBJ1.Text = "UserName : " & gUsername
        Viewer.Show()
    End Sub
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Mid(Trim(UCase(gCompanyname)), 1, 10) = "THE BENGAL" Then
            Call Bengal_Print()
        Else
            gPrint = True
            Call MCLUB_PRINT()
        End If
        'gPrint = True
        'Call MCLUB_PRINT()
    End Sub
    Private Sub KOT_Timer_Tick(sender As Object, e As EventArgs) Handles KOT_Timer.Tick
        txt_KOTTime.Text = Now.ToLongTimeString
    End Sub
    Private Sub Cmd_Export_Click(sender As Object, e As EventArgs) Handles Cmd_Export.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        SQLSTRING = "SELECT BillDetails,BillDate,PAYMENTMODE,Mcode,Mname,CARDHOLDERCODE,CARDHOLDERNAME,Roomno,ChkId, BillAmount,TaxAmount,Packamount AS SERCHARGE,TipsAmt,AdCgsAmt AS ADDITIONCGS,PartyAmt,RoomAmt,Discountamount,TotalAmount,ISNULL(DELFLAG,'N') AS DELFLAG FROM BILL_HDR ORDER BY BillDate "
        ChildSql = "SELECT BillDetails,KOTDETAILS,CATEGORY,GROUPCODE,ITEMTYPE,POSCODE,ITEMCODE,ITEMDESC,UOM,QTY,RATE,AMOUNT,TAXAMOUNT,PAYMENTMODE,ISNULL(PACKAMOUNT,0) AS SERCHARGE,ISNULL(TipsAmt,0) AS TipsAmt,ISNULL(ADCGSAMT,0) AS ADDITIONCGS,ISNULL(PARTYAMT,0) AS PARTAMT,ISNULL(ROOMAMT,0) AS ROOMAMT FROM KOT_DET"
        gconnection.getDataSet(SQLSTRING, "BILL_HDR")
        OBJ1.LOADGRID(gdataset.Tables("BILL_HDR"), True, "FRM_TKGA_Directbilling", ChildSql, "BillDetails", 1)
        OBJ1.Show()
    End Sub
    Public Function GetRoundVal(Amount As Double)
        Dim Tot As Double
        If RndVal = "0.10" Then
            Tot = Math.Round(Amount, 1) - Amount
        ElseIf RndVal = "0.50" Then
            Tot = Math.Round(Amount, 0) - Amount
        Else
            Tot = 0
        End If
        Return Tot
    End Function
End Class