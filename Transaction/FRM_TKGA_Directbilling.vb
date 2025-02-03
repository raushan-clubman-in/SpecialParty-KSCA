Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_TKGA_Directbilling
    Dim strPhotoFilePath As String
    Public foto As New GlobalClass
    Dim doctype, POScode As String
    Dim boolchk As Boolean
    Dim Sql, STran(0), PrintFlag, strBatchNo, strAccountDesc, strAccountIn, strSlDesc, strBillno, strSaleCostAccountIn, strPackCostAccountIn, strSaleCostAccountInDesc, strPackCostAccountInDesc As String
    Dim Amt, AMT1 As Double
    Public dblBillTotalAmount, dblBillNonTotalAmount, dblBillTaxTotal, dblBillNonTaxtotal, gridRow As Double
    Public BillTaxBillno, BillTaxBilldetails, BillNonTaxBilldetails, BillNonTaxBillno, BillMcode, BillMname, loccode As String
    Dim BillNontaxamount, BillNontotalamount, Billtaxamount, Billtotalamount As Double
    Dim dbldicountAmount, dblGrossAmount, dbldicountPack, dblGrossPack As Double
    Dim dbldicountTax, dblGrossTax, dblDicountBillAmount, Gridbillamount, PACKINGPERCENT As Double
    Dim txt_creditfacility As String
    Dim I, J As Long
    Dim itembool, chkbool, smartcardbool, boolPromotional As Boolean
    Dim vsearch, vitem, accountcode, Billno(), HNAME() As String
    Public KOTno(), billstatus, BillDetails As String
    Dim gconnection As New GlobalClass
    Dim TotalItemCount As Integer
    Dim crstopmsg As String
    Dim STMcode As String
    Public vseqno, Jnltaxamount, Jnlamount, _Billamount As Double
    Dim dr As DataRow
    Dim ITEMCODE, servicelocation As String
    '----SMART CARD
    Public BALANCE_HDR As Double
    Public MIN_USAGE_BALANCE_HDR As Double
    Dim count As Integer = 1
    Dim GADDDATETIME As Date
    Public STRPOSCODE, MainCode, StrSql As String
    Dim POSBILLDET As String
    Dim gDocType As String
    Dim CrLimit, CrLimitAmt As Double
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double

    Private Sub FRM_TKGA_Directbilling_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            txt_KOTno.Text = ""
            txt_KOTno.Focus()
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
            If pnl_POSCode.Top = 50 Then
                pnl_POSCode.Top = 1000
                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                Exit Sub
            ElseIf pnl_UOMCode.Top = 50 Then
                pnl_UOMCode.Top = 1000
                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                Exit Sub
            Else
                Call Cmd_Exit_Click(sender, e)
                Exit Sub
            End If
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
        ElseIf e.Alt = True And e.KeyCode = Keys.C Then
            Me.txt_Cover.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.L Then
            Me.CMB_BTYPE.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.D Then
            Me.dtp_KOTdate.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub FRM_TKGA_Directbilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim LastDoctype As String
        gDocType = DOCTYPE
        LastDoctype = DOCTYPE
        Timer1.Enabled = False
        bselect = False

        StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(DIRECTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(directprefix,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
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
        End If

        'Dim pending As String
        Timer1.Enabled = True
        'Call FacilityValidation()
        'Call FillDefaultPayment()
        Call fillPayment_Mode()
        'Call fillNPayment_Mode()
        Call fillposdocument()
        CMB_BTYPE.Enabled = True

        'SQLSTRING = " SELECT KOTTYPE FROM POSSETUP"
        'gconnection.getDataSet(SQLSTRING, "KOT")
        'If gdataset.Tables("KOT").Rows.Count > 0 Then
        '    If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
        '        'pardha 03 oct 2012 given error meesage if kottype is null in possetup table
        '    ElseIf gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "" Then
        '        MessageBox.Show(" KOTTYPE SHOULD BE DEFINED in POSSETUP")

        '    Else
        '        Call autogenerate()
        '    End If
        'End If

        Call ShowBillno()
        'Call Autogenerate()
        If gCenterlized = "Y" And Mid(gKotType, 1, 1) = "A" Then
            Call Autogenerate()
        ElseIf gCenterlized = "N" And Mid(pKotType, 1, 1) = "A" Then
            Call Autogenerate()
            CMB_BTYPE.SelectedItem = doctype
        ElseIf gCenterlized = "Y" And Mid(gKotType, 1, 1) = "M" Then
            txt_KOTno.Text = ""
        End If
        Call GRIDLOCK()

        itembool = False
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        KOT_Timer.Enabled = True
        KOT_Timer.Interval = 100
        kotentrybool = True
        ordertype = ""
        KOT_Timer.Enabled = True
        KOT_Timer.Interval = 100
        txt_TotalValue.ReadOnly = True
        txt_TaxValue.ReadOnly = True
        Txt_Charges.ReadOnly = True
        txt_BillAmount.ReadOnly = True
        Me.cmd_BillSettlement.Enabled = False
        cmd_BillSettlement.Enabled = False
        cmb_type.SelectedIndex = 0
        'cbo_Typeofcheque.SelectedIndex = 0
        grp_Paymentmodeselection.Top = 1000
        sSGrid.ClearRange(1, 1, -1, -1, True)
        Me.cmd_KOTnoHelp.Enabled = True
        Me.Cmd_Delete.Enabled = True
        'grp_paydet.Visible = False

        Lbl_PartyBookingNo.Visible = False
        Txt_PartyBookingNo.Visible = False
        Txt_PartyBookingNo.Text = ""

        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call SetDateTime()
        SYS_DATE_TIME()
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
        Else
            ACCESS_CHECK_GBL = False
        End If
        'txt_KOTno.Focus()
        'txt_TableNo.Focus()
        Show()
        SETLEMENT_GROUP.Visible = False
        CMB_BTYPE.Focus()

        If Mid(pTableReq, 1, 1) = "Y" Then
            txt_TableNo.ReadOnly = False
            cmd_TablenoHelp.Enabled = True
            txt_TableNo.Focus()
        Else
            txt_TableNo.ReadOnly = True
            cmd_TablenoHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
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
        CMB_BTYPE.SelectedItem = LastDoctype
        If Mid(pKotType, 1, 1) = "A" Then
            Me.CMB_BTYPE.Focus()
        Else
            txt_KOTno.Focus()
        End If
    End Sub
    Private Sub Autogenerate()
        Dim sqlstring, financalyear, strstring As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            If Mid(pKotType, 1, 1) = "A" Then
                sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(KOTno,1,6) As Numeric)),0)  FROM KOT_HDR  WHERE DocType ='" & Trim(doctype) & "' AND SALETYPE <> 'SALE' "
                gconnection.openConnection()
                gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_KOTno.Text = doctype & "/000001" & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_KOTno.Text = doctype & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_KOTno.Text = doctype & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                If Mid(pKotType, 1, 1) = "A" Then
                Else
                    strstring = "SELECT * FROM KOT_HDR WHERE KOTDETAILS='" & txt_KOTno.Text & "'"
                    gconnection.getDataSet(strstring, "KOTNO")
                    If gdataset.Tables("KOTNO").Rows.Count = 0 Then
                        strstring = " Select isnull(Prefix,'') as Prefix,isnull(Servercode,'') as Servercode From Kotbook "
                        strstring = strstring & "  Where  " & IIf(Val(txt_KOTno.Text) > 0, Val(txt_KOTno.Text), 0) & " between snofrom and  snoto "
                        gconnection.getDataSet(strstring, "servermaster")
                        If gdataset.Tables("servermaster").Rows.Count > 0 Then
                            txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("Servercode")
                            strstring = " Select isnull(servername,'') as servername,isnull(Servercode,'') as Servercode From servermaster where servercode='" & Trim(txt_ServerCode.Text) & "' "
                            gconnection.getDataSet(strstring, "servername")
                            txt_ServerName.Text = gdataset.Tables("servername").Rows(0).Item("servername")
                            'txt_ServerCode_Validated(sender, e)
                            cbo_PaymentMode.Focus()
                            'txt_MemberCode.Focus()
                        Else
                            'MessageBox.Show("Kindly Register This Kotbook in System,Thanking You", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            txt_KOTno.Text = ""
                            txt_KOTno.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            'gdreader.Close()
            'gcommand.Dispose()
            'gconnection.closeConnection()
        End Try
    End Sub
    Private Sub SYS_DATE_TIME()
        Dim sqlstring, financalyear, Insert(0) As String
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                dtp_KOTdate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
            End If
            'dtp_BillDate.Enabled = False
            'CMD_LOCK()
        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GRIDLOCK()
        Dim Row, Col As Integer
        ssGrid.Col = 15
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 5
                ssGrid.Row = Row
                ssGrid.Col = Col
                ssGrid.Lock = True
            Next
        Next
        ssGrid.Row = 1
        For Col = 1 To 5
            ssGrid.Col = Col
            ssGrid.Lock = False
        Next
    End Sub
    Private Sub GridLockRate()
        Dim Row, Col As Integer
        sSGrid.Col = 7
        sSGrid.Row = sSGrid.ActiveRow
        For Row = 1 To 100
            sSGrid.Col = 19
            sSGrid.Row = Row
            If Trim(sSGrid.Text) = "Y" Then
                For Col = 7 To 7
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = False
                Next
            Else
                For Col = 7 To 9
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = True
                Next
            End If
        Next
    End Sub
    Private Sub fillposdocument()
        Dim sqlstring As String
        Dim i As Integer
        Try
            If gUserCategory = "S" Then
                sqlstring = " SELECT ISNULL(directprefix,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(directprefix,'') <> '' AND Isnull(Freeze,'N')='N' "
            Else
                sqlstring = "  SELECT ISNULL(directprefix,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(directprefix,'') <> '' AND Isnull(Freeze,'N')='N' and poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
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
                index = cbo_PaymentMode.FindString(DefaultPayment)
                cbo_PaymentMode.SelectedIndex = index
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
            dtp_KOTdate.Value = DateAdd(DateInterval.Day, -1, Now)
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
    Private Sub KOT_Timer_Tick(sender As Object, e As EventArgs) Handles KOT_Timer.Tick
        txt_KOTTime.Text = Now.ToLongTimeString
    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 6
                sSGrid.Col = j
                sSGrid.Row = i
                sSGrid.Lock = False
            Next j
        Next i
    End Sub
    Private Sub GridColUnLock(ByVal ColNo As Integer)
        Dim i, j As Integer
        For i = 1 To 100
            'For j = 1 To 5
            sSGrid.Col = ColNo
            sSGrid.Row = i
            sSGrid.Lock = False
            'Next j
        Next i
    End Sub
    Private Sub disablecontrols()
        txt_TableNo.ReadOnly = True
        txt_MemberCode.ReadOnly = True
        txt_MemberName.ReadOnly = True
        txt_ServerCode.ReadOnly = True
        txt_ServerName.ReadOnly = True
        dtp_KOTdate.Enabled = False
        cbo_PaymentMode.Enabled = False
        cbo_SubPaymentMode.Enabled = False
        cmd_MemberCodeHelp.Enabled = False
        cmd_ServerCodeHelp.Enabled = False
        cmd_TablenoHelp.Enabled = False
        Cmd_Add.Enabled = False
    End Sub
    Private Sub Enabledcontrol()
        txt_TableNo.ReadOnly = False
        txt_MemberCode.ReadOnly = False
        txt_MemberName.ReadOnly = False
        txt_ServerCode.ReadOnly = False
        txt_ServerName.ReadOnly = False
        dtp_KOTdate.Enabled = True
        cbo_PaymentMode.Enabled = True
        cbo_SubPaymentMode.Enabled = True
        cmd_MemberCodeHelp.Enabled = True
        cmd_ServerCodeHelp.Enabled = True
        cmd_TablenoHelp.Enabled = True
        Cmd_Add.Enabled = True
    End Sub
    Private Sub ShowBillno()
        Dim sqlstring, financalyear As String
        Try
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)

            sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(KOTno,1,6) As Numeric)),0)  FROM KOT_HDR  WHERE DocType ='" & Trim(doctype) & "' AND SALETYPE <> 'SALE' "
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is DBNull.Value Then
                    lbl_Status.Visible = True
                    lbl_Status.Text = "FIRST KOTNO :"
                Else
                    lbl_Status.Visible = False
                    lbl_Status.Text = "LAST KOTNO :" & Trim(DOCTYPE) & "/" & Format(Val(gdreader(0)), "000000") & "/" & financalyear
                    'lbl_Status.Text = "LAST KOTNO :" & gPoSUsername & "/" & Format(Val(gdreader(0)), "000000") & "/" & financalyear
                    'End
                End If
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            Else
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub sSGrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid.KeyDownEvent
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, itc As String
        Dim varitemcode, varitemdesc, varposcode, varuom, varkotdesc As String
        Dim i, j, t, cct As Integer
        Dim PROQTY_GRID As Double

        Dim varitemrate As Double
        Try
            If e.keyCode = Keys.Enter Or e.keyCode = Keys.Tab Then
                i = sSGrid.ActiveRow
                If sSGrid.ActiveCol = 1 Then
                    sSGrid.Row = i
                    sSGrid.Col = 1
                    If Trim(sSGrid.Text) = "" Then
                        If sSGrid.ActiveRow = 1 Then
                            sSGrid.SetText(1, i, Trim(txt_KOTno.Text) & "")
                            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                        Else
                            sSGrid.Col = 1
                            sSGrid.Row = i - 1
                            varkotdesc = Trim(sSGrid.Text)
                            sSGrid.SetText(1, i, Trim(varkotdesc) & "")
                            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                        End If
                    Else
                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                    End If
                ElseIf sSGrid.ActiveCol = 2 Then
                    sSGrid.Row = i
                    sSGrid.Col = 3
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 4
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 2
                    If sSGrid.Lock = False Then
                        If Trim(sSGrid.Text) = "" Then
                            Call FillMenu() ' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        ElseIf Trim(sSGrid.Text) <> "" Then
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                Itemcode = Trim(sSGrid.Text)
                                Dim K As Integer
                                For j = 1 To sSGrid.DataRowCnt + 1
                                    'Dim ITC
                                    sSGrid.Col = 2
                                    sSGrid.Row = j
                                    itc = sSGrid.Text
                                    For K = 1 To sSGrid.DataRowCnt + 1
                                        sSGrid.Col = 2
                                        sSGrid.Row = K
                                        If Trim(sSGrid.Text) = itc Then
                                            cct = cct + 1
                                        End If
                                    Next
                                    If cct > 1 Then
                                        MsgBox("duplicate item entry")
                                        Exit Sub
                                    End If
                                    cct = 0
                                Next
                                j = 0
                                sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE,I.OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                'AND txt_POSCode='" & Trim(POScode) & "'
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    sSGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(12, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SALESACCTIN")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    sSGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    End If
                                    ''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN "

                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, 0.0)
                                                    sSGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    sSGrid.SetText(12, i + 1, 0.0)
                                                    sSGrid.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                    sSGrid.SetText(19, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    'Sqlstring = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 4
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 5
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 7
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Val(PACKINGPERCENT) <> 0 Then
                                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            Else
                                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 7
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 5
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            Else
                                If pnl_POSCode.Top = 50 Then
                                    Me.lvw_POSCode.FullRowSelect = True
                                    lvw_POSCode.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 3 Then
                    sSGrid.Row = i
                    sSGrid.Col = 4
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 1
                    sSGrid.Col = 3
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.Lock = False Then
                        If Trim(sSGrid.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM DESC
                        Else
                            If Trim(varposcode) = "" Then
                                Itemdesc = Trim(sSGrid.Text)
                                sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    Itemcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & ""
                                    sSGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(12, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("subgroupcode")))
                                    sSGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    End If
                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then

                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "

                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, 0.0)
                                                    sSGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    sSGrid.SetText(12, i + 1, 0.0)
                                                    sSGrid.SetText(19, i + 1, "Y")
                                                    boolPromotional = True

                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 4
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 5
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 7
                                            ''sSGrid.Row = sSGrid.ActiveRow
                                            ''If Val(PACKINGPERCENT) <> 0 Then
                                            ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            ''Else
                                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 5
                                            sSGrid.Col = 6
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''

                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM DESC not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            Else
                                sSGrid.Col = 19
                                sSGrid.Row = sSGrid.ActiveRow
                                If Trim(sSGrid.Text) = "Y" Then
                                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    sSGrid.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 4 Then
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 2
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 4
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" Then
                        sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 2
                            varitemcode = Trim(sSGrid.Text)
                            sSGrid.Col = 4
                            varposcode = Trim(sSGrid.Text)
                            If Trim(varposcode) = "" Then
                                sSGrid.Text = ""
                                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                sSGrid.Focus()
                                Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                    '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    lvw_POSCode.Focus()
                                End If
                                '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                Exit Sub
                            ElseIf Trim(varposcode) <> "" Then
                                Sqlstring = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND POSCODE = '" & Trim(CStr(varposcode)) & "' ORDER BY POSCODE"
                                gconnection.getDataSet(Sqlstring, "POSMASTER")
                                If gdataset.Tables("POSMASTER").Rows.Count = 1 Then
                                    sSGrid.Col = 4
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("POSMASTER").Rows(0).Item("POSCODE")
                                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    'If IsDBNull(gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")) = False Then
                                    '    If Trim((gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                    '        sSGrid.Col = 14
                                    '        sSGrid.Row = sSGrid.ActiveRow
                                    '        'sSGrid.Text = gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")
                                    '    Else
                                    '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '        Exit Sub
                                    '    End If
                                    'Else
                                    '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '    Exit Sub
                                    'End If
                                Else
                                    MessageBox.Show("!! Oop's specified POSCODE is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    sSGrid.Text = ""
                                    sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                    sSGrid.Focus()
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 5 Then
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 2
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 4
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 5
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 2
                            varitemcode = Trim(sSGrid.Text)
                            sSGrid.Col = 4
                            varposcode = Trim(sSGrid.Text)
                            sSGrid.Col = 7
                            varitemrate = Val(sSGrid.Text)
                            sSGrid.Col = 5
                            If Trim(sSGrid.Text) = "" Then
                                '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                    sSGrid.Col = 5
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                    ''sSGrid.Col = 6
                                    ''sSGrid.Row = sSGrid.ActiveRow
                                    ''sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    sSGrid.Col = 19
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) = "Y" Then
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.Col = 7
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    End If
                                ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    sSGrid.Col = 5
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()
                                Else
                                    sSGrid.Col = 2
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) <> "" Then
                                        sSGrid.Col = 5
                                        sSGrid.Text = ""
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    End If
                                End If
                                '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                            ElseIf Trim(sSGrid.Text) <> "" Then
                                Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) AND R.ITEMRATE = " & Val(varitemrate) & " "
                                gconnection.getDataSet(Sqlstring, "RATEMASTER")
                                If gdataset.Tables("RATEMASTER").Rows.Count > 0 Then
                                    If gdataset.Tables("RATEMASTER").Rows.Count = 1 Then
                                        sSGrid.Col = 5
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = CStr(gdataset.Tables("RATEMASTER").Rows(0).Item("UOM")) & ""
                                        sSGrid.Col = 7
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                        sSGrid.Col = 19
                                        sSGrid.Row = sSGrid.ActiveRow
                                        If Trim(sSGrid.Text) = "Y" Then
                                            sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                        Else
                                            sSGrid.Col = 7
                                            sSGrid.Row = sSGrid.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE"))
                                            '    ''+ (Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                        End If
                                    ElseIf gdataset.Tables("RATEMASTER").Rows.Count > 1 Then
                                        sSGrid.Col = 5
                                        Call FillUomList(gdataset.Tables("ITEMRATE"))
                                        Me.lvw_Uom.FullRowSelect = True
                                        pnl_UOMCode.Top = 50
                                        Me.lvw_Uom.Focus()
                                        Exit Sub
                                    Else
                                        sSGrid.Col = 5
                                        sSGrid.Col = 7
                                        sSGrid.Text = "0.00"
                                    End If
                                Else
                                    MessageBox.Show("!! Oop's specified ITEM UOM is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    sSGrid.Col = 5
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = ""
                                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                End If
                            End If
                        Else
                            If pnl_UOMCode.Top = 50 Then
                                Me.lvw_Uom.FullRowSelect = True
                                pnl_UOMCode.Top = 50
                                Me.lvw_Uom.Focus()
                                Exit Sub
                            Else
                                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 6 Then
                    Dim ITEMQTY, Freeqty, FreeDis, FreeRate, ActRate, PKotQty, rkotqty, baseqty As Double
                    Dim PROMAMT As Double
                    Dim Basedon, BItemcode, Pitemcode, Puom, WeekDay, Type, Pssql, buom, ssql As String
                    Dim CHECK_AVAILABILITY, k As Integer
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 4
                    sSGrid.Lock = True
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 5
                    sSGrid.Lock = True
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 2
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 4
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 5
                    buom = Trim(sSGrid.Text)
                    sSGrid.Col = 7
                    ActRate = Val(sSGrid.Text)
                    sSGrid.Col = 6
                    ITEMQTY = Val(sSGrid.Text)
                    WeekDay = UCase(Now.DayOfWeek.ToString)
                    PKotQty = 0
                    'boolProm = False
                    Pssql = "DELETE FROM PROM_STATUS"
                    gconnection.dataOperation(9, Pssql, "DELETE")

                    Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                    Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & varitemcode & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "'"
                    Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                    gconnection.getDataSet(Pssql, "PROM")
                    If gdataset.Tables("PROM").Rows.Count > 0 Then
                        For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                            PKotQty = PKotQty + gdataset.Tables("PROM").Rows(k).Item("QTY")
                            Pssql = "INSERT INTO PROM_STATUS VALUES ('" & gdataset.Tables("PROM").Rows(k).Item("KOTDETAILS") & "','" & Trim(txt_KOTno.Text) & "','" & gdataset.Tables("PROM").Rows(k).Item("ITEMCODE") & "','" & gdataset.Tables("PROM").Rows(k).Item("QTY") & "')"
                            gconnection.dataOperation(9, Pssql, "DELETE")
                        Next
                    End If
                    ssql = "select pitemcode as itemcode FROM PROMMASTER WHERE  BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                    gconnection.getDataSet(ssql, "rau")
                    If gdataset.Tables("RAU").Rows.Count > 0 Then
                        Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                        Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & gdataset.Tables("RAU").Rows(0).Item("itemcode") & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "'"
                        Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') = 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                        gconnection.getDataSet(Pssql, "PROM")
                        If gdataset.Tables("PROM").Rows.Count > 0 Then
                            For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                                rkotqty = rkotqty + gdataset.Tables("PROM").Rows(k).Item("QTY")
                            Next

                        End If
                    End If
                    Pssql = "INSERT INTO PROM_STATUS_TEMP SELECT * FROM PROM_STATUS"
                    gconnection.dataOperation(9, Pssql, "DELETE")
                    ITEMQTY = ITEMQTY + PKotQty
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 2
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) <> "" Then
                                sSGrid.Col = 6
                                sSGrid.Row = sSGrid.ActiveRow
                                If Val(sSGrid.Text) = 0 Then
                                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    Exit Sub
                                Else
                                    sSGrid.Col = 19
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) = "Y" Then
                                        sSGrid.Col = 7
                                        sSGrid.Lock = False
                                        sSGrid.SetActiveCell(7, sSGrid.ActiveRow)
                                        Exit Sub
                                    Else
                                        'GPS  PROMOTIONAL
                                        '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                        sSGrid.Col = 2
                                        sSGrid.Row = sSGrid.ActiveRow
                                        Itemcode = Trim(sSGrid.Text)
                                        Sqlstring = " SELECT ISNULL(Promotional,'') AS Promotional,ISNULL(PromItemcode,'') AS PromItemcode FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                                        Sqlstring = "SELECT 'Y' AS Promotional,BASEDON AS PromItemcode FROM PROMMASTER WHERE BASEDITEMCODE = '" & varitemcode & "' "
                                        gconnection.getDataSet(Sqlstring, "ITEMCODE1")
                                        If gdataset.Tables("ITEMCODE1").Rows.Count > 0 Then
                                            If Trim(gdataset.Tables("ITEMCODE1").Rows(j).Item("Promotional")) = "Y" Then
                                                sSGrid.Col = 2
                                                sSGrid.Row = i
                                                Itemcode = Trim(sSGrid.Text)
                                                Basedon = (gdataset.Tables("ITEMCODE1").Rows(j).Item("PromItemcode"))

                                                '----- Pankaj Start
                                                If Basedon = "Q" Then
                                                    'Sqlstring = "SELECT PITEMCODE,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,'QTY' AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT ,cast(((" & ITEMQTY & " /FROMQTY )- " & rkotqty & " )*ISNULL(FREEQTY,0) as integer) as prom  FROM PROMMASTER WHERE BASEDON = 'Q' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "'AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE"
                                                    ' AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY "
                                                    Sqlstring = "SELECT PITEMCODE,isnull(saleqty,0)as fromqty,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,ISNULL(TYPE,'') AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT,cast(((" & ITEMQTY & " /saleqty )- " & rkotqty & " )*ISNULL(saleqty,0) as integer) as prom FROM PROMMASTER WHERE BASEDON = 'Q' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                                                ElseIf Basedon = "P" Then
                                                    Sqlstring = "SELECT PITEMCODE,isnull(FROMQTY,0)as fromqty,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,ISNULL(TYPE,'') AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT,cast(((" & ITEMQTY & " /FROMQTY )- " & rkotqty & " )*ISNULL(FREEQTY,0) as integer) as prom FROM PROMMASTER WHERE BASEDON = 'P' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                                                    'AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY 
                                                End If
                                                gconnection.getDataSet(Sqlstring, "FITEMCODE")
                                                If gdataset.Tables("FITEMCODE").Rows.Count > 0 Then
                                                    If gdataset.Tables("FITEMCODE").Rows(0).Item("prom") > 0 Then
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")
                                                    Else
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")

                                                    End If
                                                End If
                                                '-----Pankaj End

                                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                                Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,I.PROMOTIONAL,I.PROMITEMCODE FROM ITEMMASTER AS I"
                                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
                                                Sqlstring = Sqlstring & " WHERE I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,getdate())  AND ISNULL(I.FREEZE,'') <>'Y'"
                                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                                    Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(0).Item("PromItemcode"))
                                                End If
                                                sSGrid.Row = sSGrid.ActiveRow
                                                sSGrid.Col = 2
                                                Itemcode = Trim(sSGrid.Text)

                                                Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,ISNULL(I.PROMTYPE,'') AS PROMTYPE,"
                                                Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY,I.BASEQTY , I.PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                Sqlstring = Sqlstring & " INNER JOIN ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                                Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN I.StartingDate AND I.EndingDate AND PL.POS='" & Trim(STRPOSCODE) & "'"

                                                'PANKAJ
                                                If Basedon = "Q" Then
                                                    Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, 'QTY' AS PROMTYPE,"
                                                    Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                    Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE"
                                                    'Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                    Sqlstring = Sqlstring & " WHERE (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                    Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"

                                                ElseIf Basedon = "P" Then
                                                    If Type = "QTY" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                    ElseIf Type = "DISCOUNT ON RATE" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeDis & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                    ElseIf Type = "FIXED RATE" Then
                                                        If UCase(Mid(gCompanyname, 1, 4)) = "CATH" Then
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & baseqty & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                        Else
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"

                                                        End If
                                                    End If
                                                End If

                                                'PANKAJ
                                                'CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(serverdate.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(serverdate.Today)
                                                'End
                                                gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                                sSGrid.Row = sSGrid.ActiveRow
                                                sSGrid.Col = 6
                                                Trim(sSGrid.Text)
                                                'If Trim(sSGrid.Text) = Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY")) Then
                                                'PROQTY_GRID = Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")))
                                                If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                                    If Val(Trim(sSGrid.Text)) + PKotQty >= Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) Then
                                                        PROQTY_GRID = (Val(Math.Floor(Trim(sSGrid.Text) + PKotQty) / Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) * Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY"))))
                                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 And PROQTY_GRID <> 0 And Basedon = "Q" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                            If CHECK_AVAILABILITY > 0 Then
                                                                If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                    'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(dtp_KOTdate.Value), "dd/MM/yyyy") Then
                                                                    If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                                        If CHECK_AVAILABILITY = 0 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                sSGrid.ClearRange(2, i, sSGrid.MaxCols, i, True)
                                                                                sSGrid.Focus()
                                                                                sSGrid.SetActiveCell(1, i)
                                                                                Exit Sub
                                                                            End If

                                                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                sSGrid.Col = 5
                                                                                sSGrid.Text = ""
                                                                                sSGrid.SetActiveCell(5, i)
                                                                                sSGrid.Focus()
                                                                                Exit Sub
                                                                            End If
                                                                        End If
                                                                        If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                            sSGrid.SetText(7, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 6
                                                                            If Val(sSGrid.Text) > 0 Then
                                                                                ITEMQTY = Val(sSGrid.Text)
                                                                                PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                sSGrid.SetText(9, i, PROMAMT)
                                                                                sSGrid.SetText(19, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                            ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                            sSGrid.SetText(7, i, Val(ActRate))
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 6
                                                                            If Val(sSGrid.Text) > 0 Then
                                                                                ITEMQTY = Val(sSGrid.Text)
                                                                                PROMAMT = Val(ActRate)
                                                                                sSGrid.SetText(9, i, PROMAMT)
                                                                                sSGrid.SetText(19, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        Else
                                                                            Dim Kno As String
                                                                            sSGrid.GetText(1, i, Kno)
                                                                            sSGrid.SetText(1, i + 1, Kno & "")
                                                                            sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                            sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                            sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 4
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 5
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 4
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i + 1
                                                                            sSGrid.Col = 5
                                                                            sSGrid.Lock = True
                                                                            'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                            sSGrid.SetText(6, i + 1, Val(PROQTY_GRID))
                                                                            sSGrid.Row = i + 1
                                                                            sSGrid.Col = 6
                                                                            sSGrid.Lock = True
                                                                            sSGrid.SetText(7, i + 1, 0.0)
                                                                            sSGrid.SetText(8, i + 1, 0.0)
                                                                            sSGrid.SetText(9, i + 1, 0.0)
                                                                            sSGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                            sSGrid.SetText(12, i + 1, 0.0)
                                                                            sSGrid.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                            sSGrid.SetText(19, i + 1, "Y")
                                                                            sSGrid.SetText(20, i, Type)
                                                                            sSGrid.SetText(21, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            boolPromotional = True
                                                                            boolProm = True
                                                                        End If
                                                                    End If

                                                                End If
                                                            End If
                                                        ElseIf Type <> "QTY" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                            sSGrid.Row = sSGrid.ActiveRow
                                                            sSGrid.Col = 5
                                                            Trim(sSGrid.Text)
                                                            If Val(Trim(sSGrid.Text)) Mod Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) = 0 Then
                                                                If CHECK_AVAILABILITY > 0 Then
                                                                    If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                        'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(dtp_KOTdate.Value), "dd/MM/yyyy") Then
                                                                        If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                                            If CHECK_AVAILABILITY = 0 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    sSGrid.ClearRange(1, i, sSGrid.MaxCols, i, True)
                                                                                    sSGrid.Focus()
                                                                                    sSGrid.SetActiveCell(1, i)
                                                                                    Exit Sub
                                                                                End If
                                                                            ElseIf CHECK_AVAILABILITY = 1 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    sSGrid.Col = 5
                                                                                    sSGrid.Text = ""
                                                                                    sSGrid.SetActiveCell(5, i)
                                                                                    sSGrid.Focus()
                                                                                    Exit Sub
                                                                                End If
                                                                            End If
                                                                            'If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "RATE" Then
                                                                            If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                                sSGrid.SetText(7, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 6
                                                                                If Val(sSGrid.Text) > 0 Then
                                                                                    ITEMQTY = Val(sSGrid.Text)
                                                                                    PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                    sSGrid.SetText(9, i, PROMAMT)
                                                                                    sSGrid.SetText(19, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                                ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                                sSGrid.SetText(7, i, Val(ActRate))
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 6
                                                                                If Val(sSGrid.Text) > 0 Then
                                                                                    ITEMQTY = Val(sSGrid.Text)
                                                                                    PROMAMT = Val(ActRate)
                                                                                    sSGrid.SetText(9, i, PROMAMT)
                                                                                    sSGrid.SetText(19, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            Else
                                                                                sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                                sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                                sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 4
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 5
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 3
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i + 1
                                                                                sSGrid.Col = 5
                                                                                sSGrid.Lock = True
                                                                                'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                                sSGrid.SetText(6, i + 1, Val(PROQTY_GRID))
                                                                                sSGrid.Row = i + 1
                                                                                sSGrid.Col = 6
                                                                                sSGrid.Lock = True
                                                                                sSGrid.SetText(7, i + 1, 0.0)
                                                                                sSGrid.SetText(8, i + 1, 0.0)
                                                                                sSGrid.SetText(9, i + 1, 0.0)
                                                                                sSGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                                sSGrid.SetText(12, i + 1, 0.0)
                                                                                sSGrid.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                                sSGrid.SetText(19, i + 1, "Y")
                                                                                sSGrid.SetText(20, i, Type)
                                                                                sSGrid.SetText(21, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                boolPromotional = True
                                                                                boolProm = True
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            Else
                                                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                                                gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                                                    sSGrid.Col = 5
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                                                    sSGrid.Col = 7
                                                                    ''sSGrid.Row = sSGrid.ActiveRow
                                                                    ''If Val(PACKINGPERCENT) <> 0 Then
                                                                    ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                                                    ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                                                    ''Else
                                                                    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                                                    'End If
                                                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                                                    sSGrid.Col = 19
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    If Trim(sSGrid.Text) = "Y" Then
                                                                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                                                    Else
                                                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                                                    End If
                                                                Else
                                                                    sSGrid.Col = 5
                                                                    sSGrid.Col = 7
                                                                    sSGrid.Text = "0.00"
                                                                    sSGrid.Col = 19
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    If Trim(sSGrid.Text) = "Y" Then
                                                                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                                                    Else
                                                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                                                    End If

                                                                End If

                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If

                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                        If CHECK_AVAILABILITY = 0 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                sSGrid.ClearRange(2, i, sSGrid.MaxCols, i, True)
                                                sSGrid.Focus()
                                                sSGrid.SetActiveCell(1, i)
                                                Exit Sub
                                            End If
                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                sSGrid.Col = 5
                                                sSGrid.Text = ""
                                                sSGrid.SetActiveCell(5, i)
                                                sSGrid.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                        '''************************************************************************************************
                                        Call Calculate()
                                        If boolPromotional = True Then
                                            sSGrid.Row = sSGrid.ActiveRow + 1
                                        Else
                                            sSGrid.Row = sSGrid.ActiveRow + 1
                                        End If
                                        sSGrid.Col = 1
                                        sSGrid.Lock = False
                                        sSGrid.Col = 2
                                        sSGrid.Lock = False
                                        sSGrid.Col = 3
                                        sSGrid.Lock = False
                                        sSGrid.Col = 4
                                        sSGrid.Lock = False
                                        sSGrid.Col = 5
                                        sSGrid.Lock = False
                                        sSGrid.Col = 6
                                        sSGrid.Lock = False
                                        If boolPromotional = True Then
                                            If PROMAMT > 0 Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                            End If
                                        Else
                                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                        End If
                                        sSGrid.Col = 1
                                        sSGrid.Lock = False
                                        sSGrid.Col = 2
                                        sSGrid.Lock = False
                                        sSGrid.Col = 3
                                        sSGrid.Lock = False
                                        sSGrid.Col = 4
                                        sSGrid.Lock = False
                                        sSGrid.Col = 5
                                        sSGrid.Lock = False
                                        sSGrid.Col = 6
                                        sSGrid.Lock = False
                                        If boolPromotional = True Then
                                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            sSGrid.Focus()
                                        End If
                                        'boolPromotional = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 7 Then
                    sSGrid.Col = 7
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.Lock = False Then
                        sSGrid.Col = 2
                        sSGrid.Row = sSGrid.ActiveRow
                        If Trim(sSGrid.Text) <> "" Then
                            sSGrid.Col = 7
                            sSGrid.Row = sSGrid.ActiveRow
                            If Val(sSGrid.Text) = 0 Then
                                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                Exit Sub
                            Else
                                Call Calculate()
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 6
                                sSGrid.Lock = False
                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                sSGrid.Col = 1
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 4
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.ActiveCol = 4 Then
                        If sSGrid.Lock = False Then
                            Itemcode = Nothing
                            i = sSGrid.ActiveRow
                            sSGrid.Col = 2
                            sSGrid.Row = i
                            Itemcode = Trim(sSGrid.Text)

                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE P.ITEMCODE='" & Trim(Itemcode) & "' ORDER BY POSCODE"
                            gconnection.getDataSet(Sqlstring, "POSMENULINK")
                            If gdataset.Tables("POSMENULINK").Rows.Count > 0 Then
                                If gdataset.Tables("POSMENULINK").Rows.Count > 1 Then
                                    sSGrid.Col = 4
                                    sSGrid.Row = i
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    pnl_POSCode.Focus()
                                    lvw_POSCode.Focus()
                                Else
                                    sSGrid.Col = 4
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                                    sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                End If
                            Else
                                sSGrid.Col = 2
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Focus()
                            End If
                        End If
                    ElseIf sSGrid.ActiveCol = 5 Then
                        sSGrid.Col = 5
                        sSGrid.Row = sSGrid.ActiveRow
                        If sSGrid.Lock = False Then
                            Itemcode = Nothing
                            i = sSGrid.ActiveRow
                            sSGrid.Col = 2
                            sSGrid.Row = i
                            Itemcode = Trim(sSGrid.Text)
                            Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                            Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                            gconnection.getDataSet(Sqlstring, "ITEMRATE")
                            If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                                If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    sSGrid.Col = 5
                                    sSGrid.Row = i
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()

                                Else
                                    sSGrid.Col = 5
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                                    sSGrid.Col = 7
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                End If
                            Else
                                sSGrid.Col = 2
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Focus()
                            End If
                        End If
                    ElseIf sSGrid.ActiveCol = 2 Or sSGrid.ActiveCol = 6 Or sSGrid.ActiveCol = 1 Then

                        If Mid(Me.Cmd_Add.Text, 1, 1) <> "U" Then
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                            sSGrid.DeleteRows(sSGrid.ActiveRow, 1)
                            'Call Calculate()
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.Col = 1
                            sSGrid.Lock = False
                            sSGrid.Col = 2
                            sSGrid.Lock = False
                            sSGrid.Col = 3
                            sSGrid.Lock = False
                            sSGrid.Col = 4
                            sSGrid.Lock = False
                            sSGrid.Col = 5
                            sSGrid.Lock = False
                            sSGrid.Col = 6
                            sSGrid.Lock = False
                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                        End If

                    End If
                End If
            End If
            Call GridLockRate()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql, COMPNAME As String
        Dim k, cct As Integer
        cct = 0
        Dim itc As String
        ssql = "SELECT ISNULL(COMPNAME,'')AS COMPNAME FROM POSSETUP "
        gconnection.getDataSet(ssql, "COMP")
        If gdataset.Tables("COMP").Rows.Count > 0 Then
            COMPNAME = gdataset.Tables("COMP").Rows(0).Item("COMPNAME")
        End If
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.subGroupCode,'') AS subGroupCode,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink)"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink) AND (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "ITEMCODE     |ITEM DESCRIPTION                       |  BASERATESTD  |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  |SALESACCTIN|OPENFACILITY|"
        vform.vCaption = "ITEM CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        'vform.Keypos10 = 10
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield1
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 12
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 14
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 16
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 17
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 18
                .Row = .ActiveRow
                .Text = vform.keyfield9
                .Col = 19
                .Row = .ActiveRow
                .Text = vform.keyfield10
            End With
        Else
            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(sSGrid.Text) <> "" Then
            sSGrid.GetText(2, sSGrid.ActiveRow, itc)
            For k = 1 To sSGrid.DataRowCnt
                sSGrid.Col = 2
                sSGrid.Row = k
                If Trim(sSGrid.Text) = itc Then
                    cct = cct + 1
                    'MsgBox("duplicate item entry")
                    'Exit For
                End If

            Next
        End If
        If cct > 1 Then
            MsgBox("duplicate item entry")
        End If
        ' End If
        If Trim(vform.keyfield) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ *********************************************'''
            '''
            If gCenterlized = "Y" Then
                SQLSTRING = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' "
            Else
                SQLSTRING = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
            End If
            gconnection.getDataSet(SQLSTRING, "PosMenuLink")

            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                Call FillPosList(gdataset.Tables("PosMenuLink"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                Exit Sub
                'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        If sSGrid.Text = "" Then
                '            sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(2)
                '        End If
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield) & "' ) "
            gconnection.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If sSGrid.ActiveCol = 6 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                sSGrid.Col = 7
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''

            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & "posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield & "' "
            gconnection.getDataSet(gSQLString, "Promotional")

            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then
                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(10, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")

                            sSGrid.SetText(12, sSGrid.ActiveRow + 1, 0.0)
                            boolPromotional = True
                            sSGrid.SetText(19, sSGrid.ActiveRow + 1, "Y")
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenuItem()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink )"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "              ITEMDESC            |     ITEMCODE     | RATE    |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | TAX.ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  | OPENFACILITY | SALESACCTIN|"
        vform.vCaption = "ITEM DESC HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 2
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield1)
                .Col = 3
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield)
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 12
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 14
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 16
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 19
                .Row = .ActiveRow
                .Text = vform.keyfield10

                If Trim(CStr(vform.keyfield7)) = "Y" Then
                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                Else
                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                End If
                'End
            End With
        Else
            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield1) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ ********************************************************'''
            If gCenterlized = "Y" Then
                ssql = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' ORDER BY POSCODE"
            Else
                ssql = "SELECT DISTINCT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
            End If
            gconnection.getDataSet(ssql, "POSMENULINK")
            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS POS LOC $ ******************************************************''
                Call FillPosList(gdataset.Tables("POSMENULINK"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                Exit Sub
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("POSMENULINK").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("POSMENULINK").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        ''sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(2)
                '        ''sSGrid.Text = vform.keyfield8
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT R.UOM, R.ItemRate "
            gSQLString = gSQLString & "FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & "RateMaster AS R ON I.ItemCode = R.ItemCode "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ItemCode = '" & Trim(vform.keyfield1) & "' ) AND ISNULL(I.freeze,'')<>'Y' "
            gconnection.getDataSet(gSQLString, "ItemRate")
            If gdataset.Tables("ItemRate").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ItemRate"))
                If sSGrid.ActiveCol = 6 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                End If
            Else
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("UOM")
                sSGrid.Col = 7
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("ItemRate")
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,ISNULL(promotional,'') AS promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & " posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield1 & "' AND ISNULL(VIEW_ITEMMASTER.freeze,'')<>'Y'"
            gconnection.getDataSet(gSQLString, "Promotional")
            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then

                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "

                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(10, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")
                            sSGrid.SetText(12, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(19, sSGrid.ActiveRow + 1, "Y")
                            boolPromotional = True
                            'End
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillPosList(ByVal PosTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_POSCode.Items.Clear()
        For i = 0 To PosTable.Rows.Count - 1
            lvw = lvw_POSCode.Items.Add(PosTable.Rows(i).Item(0))
            lvw.SubItems.Add(PosTable.Rows(i).Item(1))
            lvw.SubItems.Add(PosTable.Rows(i).Item(2))
        Next i
    End Sub
    Private Sub FillUomList(ByVal UomTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_Uom.Items.Clear()
        For i = 0 To UomTable.Rows.Count - 1
            lvw = lvw_Uom.Items.Add(UomTable.Rows(i).Item("UOM"))
            lvw.SubItems.Add(UomTable.Rows(i).Item("ITEMRATE"))
        Next i
    End Sub

    Private Sub lvw_POSCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_POSCode.KeyPress
        Dim strSQL As String
        Dim posloc As String
        Dim acctin As String
        If Asc(e.KeyChar) = 13 Then
            Try
                posloc = Trim(lvw_POSCode.SelectedItems(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.SelectedItems(0).SubItems(2).Text)
            Catch ex As Exception
                posloc = Trim(lvw_POSCode.Items(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.Items(0).SubItems(2).Text)
            Finally
                If Trim(acctin) <> "" Or Trim(acctin) = "" Then
                    sSGrid.SetText(4, sSGrid.ActiveRow, posloc)
                    ''sSGrid.SetText(14, sSGrid.ActiveRow, acctin)
                    pnl_POSCode.Top = 1000
                    sSGrid.Focus()
                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                Else
                    MsgBox("Sales Account In Not Defined", MsgBoxStyle.Critical)
                End If
            End Try
        End If
    End Sub
    Private Sub lvw_Uom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_Uom.KeyPress
        Try
            Dim strSQL As String
            Dim uomcode, uomrate As String
            If Asc(e.KeyChar) = 13 Then
                Try
                    uomcode = Trim(lvw_Uom.SelectedItems(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.SelectedItems(0).SubItems(1).Text)
                Catch ex As Exception
                    uomcode = Trim(lvw_Uom.Items(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
                Finally
                    sSGrid.SetText(5, sSGrid.ActiveRow, uomcode)
                    sSGrid.SetText(7, sSGrid.ActiveRow, uomrate)
                    pnl_UOMCode.Top = 1000
                    sSGrid.Focus()
                    sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                End Try
            End If
        Catch
        End Try
    End Sub
    Private Sub Calculate()
        Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT As Double
        Dim i As Integer
        With sSGrid
            '   If .ActiveCol = 5 Or .ActiveCol = 4 Or .ActiveCol = 1 Then
            'Me.txt_TaxValue.Text = "0.00"
            'Me.txt_TotalValue.Text = "0.00"
            'Me.Txt_PackingValue.Text = "0.00"
            'Me.txt_BillAmount.Text = "0.00"
            For i = 1 To .DataRowCnt
                sSGrid.Row = i
                sSGrid.Col = 4
                .Col = 13
                .Row = i
                kotstatus = .Text
                If Trim(kotstatus) = "NO" Or Trim(kotstatus) = "" Then
                    .Col = 6
                    .Row = i
                    qty = .Text
                    .Col = 7
                    .Row = i
                    rate = .Text
                    .Col = 12
                    .Row = i
                    taxperc = Val(.Text)
                    If Val(rate) > 0 Then
                        total = (Val(qty) * Val(rate))
                    Else
                        total = 0
                    End If
                    Taxamount = (total) * (taxperc / 100)
                    .SetText(9, i, total)
                    .SetText(8, i, Taxamount)
                    'Billamount = Format(Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.TXT_TIPS.Text), "0.00")
                    'If BILLROUNDYESNO = "YES" Then
                    '    Me.txt_BillAmount.Text = Format(Math.Round(Billamount), "0.00")
                    'Else
                    '    Me.txt_BillAmount.Text = Format(Billamount, "0.00")
                    'End If
                End If
            Next i
            '+ Val(Me.Txt_PackingValue.Text)
            '+ Val(txt_sertax_value.Text)
            'txt_sertax_value.Text = Format(((Val(Me.txt_TotalValue.Text) * PACKINGPERCENT) / 100), "0.00")
            'Me.TXT_TIPS.Text = Format(((Val(Me.txt_TotalValue.Text) * TIPSPERCENT) / 100), "0.00")
            'Billroundoff = Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(txt_sertax_value.Text) + Val(Me.TXT_TIPS.Text)
            'If BILLROUNDYESNO = "YES" Then
            '    Me.txt_BillAmount.Text = Format(Math.Round(Billroundoff), "0.00")
            'Else
            '    Me.txt_BillAmount.Text = Format(Billroundoff, "0.00")
            'End If

            'End If
        End With
        i = i - 1
        Call CheckBillAmt()
    End Sub
    Private Sub sSGrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles sSGrid.LeaveCell
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, UOMCODE, itc As String
        Dim varitemcode, varitemdesc, varposcode As String
        Dim RATE As Double
        Dim i, j, k, cct As Integer
        cct = 0
        Dim qty As String
        Call Calculate()
        Try
            i = sSGrid.ActiveRow
            If sSGrid.ActiveCol = 2 Then
                sSGrid.Col = 2
                sSGrid.Row = i
                'If sSGrid.Lock = False Then
                If Trim(sSGrid.Text) <> "" Then
                    sSGrid.GetText(2, i, itc)
                    For k = 1 To sSGrid.DataRowCnt
                        sSGrid.Col = 1
                        sSGrid.Row = k
                        If Trim(sSGrid.Text) = itc Then
                            cct = cct + 1
                            'MsgBox("duplicate item entry")
                            'Exit For
                        End If

                    Next
                End If
                'End If
                If cct > 1 Then
                    MsgBox("duplicate item entry")
                End If
            ElseIf sSGrid.ActiveCol = 3 Then
                sSGrid.Col = 2
                sSGrid.Row = i
                If sSGrid.Lock = False Then
                    If Trim(sSGrid.Text) <> "" Then
                        Itemcode = Trim(sSGrid.Text)
                        Sqlstring = "SELECT ITEMDESC FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                        gconnection.getDataSet(Sqlstring, "RR")
                        If gdataset.Tables("RR").Rows.Count > 0 Then
                            sSGrid.Col = 3
                            sSGrid.Row = i
                            sSGrid.Text = Trim(gdataset.Tables("RR").Rows(0).Item("Itemdesc"))
                        Else
                            MsgBox("ITEMNAME NOT FOUND")
                            sSGrid.Col = 3
                            sSGrid.Row = i
                            sSGrid.Text = ""
                        End If
                        sSGrid.Col = 4
                        sSGrid.Row = i
                        If Trim(sSGrid.Text) = "" Then
                            sSGrid.Row = i
                            sSGrid.Col = 3
                            varitemdesc = Trim(sSGrid.Text)
                            sSGrid.Col = 4
                            varposcode = Trim(sSGrid.Text)
                            sSGrid.Col = 2
                            Itemcode = Trim(sSGrid.Text)
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    sSGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(12, i, Val(gdataset.Tables("ITE2MCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("salesacctin")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    sSGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                    End If


                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        'Modified on 14 Mar'08
                                        'Mk Kannan
                                        'Begin
                                        'Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, I.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        'Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        'Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        'End

                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, 0.0)
                                                    sSGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    sSGrid.SetText(12, i + 1, 0.0)
                                                    sSGrid.SetText(19, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 4
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                            If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                                sSGrid.Col = 15
                                                sSGrid.Row = sSGrid.ActiveRow
                                                ' sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                            Else
                                                MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                                sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                                Exit Sub
                                            End If
                                        Else
                                            MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                            sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                            Exit Sub
                                        End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 5
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 7
                                            sSGrid.Row = sSGrid.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            '    '' + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 7
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 5
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If
                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                        Exit Sub
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(2, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 3 Then
                sSGrid.Col = 2
                sSGrid.Row = sSGrid.ActiveRow
                Itemcode = sSGrid.Text
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                POScode = sSGrid.Text

                If sSGrid.Lock = False Then
                    '    If Trim(sSGrid.Text) = "" Then
                    '        'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                    '        Exit Sub
                    '    End If
                    'Sqlstring = "SELECT POS FROM POSMENULINK WHERE POS='" & POScode & "'AND ITEMCODE='" & Itemcode & "'"
                    'gconnection.getDataSet(Sqlstring, "TR")
                    'If gdataset.Tables("TR").Rows.Count > 0 Then
                    'Else
                    '    MsgBox("POSCODE ALTERED PLEASE CHECK")
                    '    sSGrid.Text = ""
                    'End If
                End If

            ElseIf sSGrid.ActiveCol = 5 Then
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    If Trim(sSGrid.Text) = "" Then
                        sSGrid.Col = 2
                        sSGrid.Row = sSGrid.ActiveRow
                        Itemcode = Trim(sSGrid.Text)
                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' )"
                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                            sSGrid.Col = 5
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                            sSGrid.Col = 7
                            sSGrid.Row = sSGrid.ActiveRow
                            'If Val(PACKINGPERCENT) <> 0 Then
                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                            '    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                            'Else
                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                            'End If
                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)

                            sSGrid.Col = 19
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                            Else
                                sSGrid.Col = 7
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                            End If

                        ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                            sSGrid.Col = 5
                            Call FillUomList(gdataset.Tables("ITEMRATE"))
                            Me.lvw_Uom.FullRowSelect = True
                            pnl_UOMCode.Top = 50
                            Me.lvw_Uom.Focus()
                            Exit Sub
                        Else
                            sSGrid.Col = 2
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) <> "" Then
                                sSGrid.Col = 5
                                sSGrid.Text = ""
                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                            End If
                        End If
                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                    Else
                        sSGrid.Col = 2
                        sSGrid.Row = sSGrid.ActiveRow
                        Itemcode = Trim(sSGrid.Text)
                        sSGrid.Col = 5
                        sSGrid.Row = sSGrid.ActiveRow
                        UOMCODE = Trim(sSGrid.Text)
                        sSGrid.Col = 7
                        sSGrid.Row = sSGrid.ActiveRow
                        RATE = Trim(sSGrid.Text)
                        'Sqlstring = "SELECT UOM FROM RATEMASTER WHERE ITEMCODE='" & Itemcode & "' AND UOM='" & UOMCODE & "'AND ITEMRATE='" & Val(RATE) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE AND ISNULL(ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  "
                        'gconnection.getDataSet(Sqlstring, "RAT")
                        'If gdataset.Tables("RAT").Rows.Count > 0 Then
                        'Else
                        '    MsgBox("UOM ALTERED PLEASE CHECK")
                        '    sSGrid.Col = 4
                        '    sSGrid.Row = sSGrid.ActiveRow
                        '    sSGrid.Text = ""
                        'End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 6 Then
                Dim CHECK_AVAILABILITY As Integer
                sSGrid.Col = 6
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 2
                    sSGrid.Row = sSGrid.ActiveRow
                    If Trim(sSGrid.Text) <> "" Then
                        sSGrid.Col = 6
                        sSGrid.Row = sSGrid.ActiveRow
                        If Val(sSGrid.Text) = 0 Then
                            sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                            Exit Sub
                        Else
                            '' Call Calculate()
                            sSGrid.Col = 19
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.Col = 7
                                sSGrid.Lock = False
                                sSGrid.SetActiveCell(7, sSGrid.ActiveRow)
                                Exit Sub
                            Else
                                CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                If CHECK_AVAILABILITY = 0 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        sSGrid.ClearRange(2, i, sSGrid.MaxCols, i, True)
                                        sSGrid.Focus()
                                        sSGrid.SetActiveCell(2, i)
                                        Exit Sub
                                    End If
                                ElseIf CHECK_AVAILABILITY = 1 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        sSGrid.Col = 5
                                        sSGrid.Text = ""
                                        sSGrid.SetActiveCell(5, i)
                                        sSGrid.Focus()
                                        Exit Sub
                                    End If
                                End If
                                Call Calculate()
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 6
                                sSGrid.Lock = False
                                'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If

                            'Added on 14 Mar'08
                            'Mk Kannan
                            'Begin
                            'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            If boolPromotional = True Then

                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 6
                                sSGrid.Lock = False
                            Else
                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If
                            boolPromotional = False
                            'End                            
                        End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 7 Then
                sSGrid.Col = 7
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 2
                    sSGrid.Row = sSGrid.ActiveRow
                    If Trim(sSGrid.Text) <> "" Then
                        sSGrid.Col = 7
                        sSGrid.Row = sSGrid.ActiveRow
                        If Val(sSGrid.Text) = 0 Then
                            sSGrid.SetActiveCell(7, sSGrid.ActiveRow)
                            Exit Sub
                        Else
                            Call Calculate()
                            sSGrid.Row = sSGrid.ActiveRow + 1
                            sSGrid.Col = 1
                            sSGrid.Lock = False
                            sSGrid.Col = 2
                            sSGrid.Lock = False
                            sSGrid.Col = 3
                            sSGrid.Lock = False
                            sSGrid.Col = 4
                            sSGrid.Lock = False
                            sSGrid.Col = 5
                            sSGrid.Lock = False
                            sSGrid.Col = 6
                            sSGrid.Lock = False
                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf sSGrid.ActiveCol = 13 Then
                sSGrid.Col = 13
                sSGrid.Row = sSGrid.ActiveRow
                If Trim(sSGrid.Text) = "No" Or Trim(sSGrid.Text) = "" Then
                    Call Calculate()
                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                    Exit Sub
                Else
                    Call Calculate()
                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                    Exit Sub
                End If
            End If
            Call GridLockRate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
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
                If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                    Lbl_PartyBookingNo.Visible = True
                    Txt_PartyBookingNo.Visible = True
                    Txt_PartyBookingNo.Focus()
                Else
                    Lbl_PartyBookingNo.Visible = False
                    Txt_PartyBookingNo.Visible = False
                    Txt_PartyBookingNo.Focus()
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
            Call clear()
        End Try
    End Function
    Public Sub clear()
        Dim sender As Object, e As System.EventArgs
        cmd_Clear_Click(sender, e)
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Pic_Member.Image = Nothing
        sSGrid.ClearRange(1, 1, -1, -1, True)
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        sSGrid.SetActiveCell(1, 1)
        Call clearform(Me)
        Me.txt_ServerName.Enabled = True
        Me.txt_ServerCode.Enabled = True
        SQLSTRING = " SELECT KOTTYPE FROM POSSETUP"
        gconnection.getDataSet(SQLSTRING, "KOT")
        If gdataset.Tables("KOT").Rows.Count > 0 Then
            If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
            Else
                Call Autogenerate()
            End If
        End If
        Call ShowBillno()
        Call GRIDLOCK()
        Call Enabledcontrol()
        Call fillPayment_Mode()
        'Call FacilityValidation()
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        txt_MemberCode.Tag = ""
        'txtCreditLimit.Text = ""
        'txtusage1.Text = ""
        Cmd_Add.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        cbo_PaymentMode.Focus()
        KOT_Timer.Enabled = True
        Me.Lbl_Bill.Visible = False
        TotalItemCount = 0
        txt_KOTno.ReadOnly = False
        Me.Cmd_Delete.Enabled = True
        txt_MemberName.ReadOnly = False
        txt_ServerName.ReadOnly = False
        Me.Cmd_Add.Enabled = True
        Me.lbl_SubPaymentMode.Visible = False
        Me.cbo_SubPaymentMode.Visible = False
        Me.cmd_BillSettlement.Enabled = True
        Me.cmd_KOTnoHelp.Enabled = True
        'grp_paydet.Visible = False
        'Me.grpPass.Visible = False
        'GRP_PAY.Visible = False
        'lblCro1.Visible = False
        'lblCro2.Visible = False
        txt_MemberCode.Text = ""
        txt_MemberName.Text = ""
        MCODE_GBL = ""
        MNAME_GBL = ""
        txt_TableNo.Text = ""
        txt_ServerCode.Text = ""
        txt_ServerName.Text = ""
        Me.Txt_Remarks.Text = ""
        txt_Cover.Text = ""
        txt_TotalValue.Text = ""
        txt_TaxValue.Text = ""
        Txt_Charges.Text = ""
        txt_Discount.Text = ""
        txt_BillAmount.Text = ""

        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
            Lbl_PartyBookingNo.Visible = True
            Txt_PartyBookingNo.Visible = True
            Txt_PartyBookingNo.Text = ""
        Else
            Lbl_PartyBookingNo.Visible = False
            Txt_PartyBookingNo.Visible = False
            Txt_PartyBookingNo.Text = ""
        End If

        SETLEMENT_GROUP.Visible = True
        ssgrid_settlement.ClearRange(1, 1, -1, -1, True)
        ssgridPayment1.ClearRange(1, 1, -1, -1, True)
        ssgrid_settlement.SetActiveCell(1, 1)
        SETLEMENT_GROUP.Visible = False
        Me.dtp_KOTdate.Value = Format(Now, "dd/MM/yyyy")
        GmoduleName = "Direct Billing"

        If Mid(pTableReq, 1, 1) = "Y" Then
            txt_TableNo.ReadOnly = False
            cmd_TablenoHelp.Enabled = True
            txt_TableNo.Focus()
        Else
            txt_TableNo.ReadOnly = True
            cmd_TablenoHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
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

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txt_card_id.Text = ""
        BillNontaxamount = 0 : BillNontotalamount = 0 : Billtaxamount = 0 : Billtotalamount = 0
        CMB_BTYPE.Focus()
        If Mid(pKotType, 1, 1) = "A" Then
            Me.CMB_BTYPE.Focus()
        Else
            txt_KOTno.Focus()
        End If
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
    Private Sub CMB_BTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_BTYPE.SelectedIndexChanged
        doctype = CMB_BTYPE.Text
        SQLSTRING = "select poscode,posdesc from POSMASTER where ISNULL(directprefix,'') ='" & doctype & "'"
        gconnection.getDataSet(SQLSTRING, "doc")
        If gdataset.Tables("doc").Rows.Count > 0 Then
            STRPOSCODE = gdataset.Tables("doc").Rows(0).Item("poscode")
            Lbl_PosDesc.Text = gdataset.Tables("doc").Rows(0).Item("posdesc")
        End If
        If gCenterlized = "N" Then
            StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(DIRECTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(directprefix,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
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
            End If
        End If
        Call fillPayment_Mode()
        'Call FillDefaultPayment()
        Call Enabledcontrol()
        Call Autogenerate()
        Call ShowBillno()
        Call GRIDLOCK()
        'Call fillposdocument()
        Call Autogenerate()
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
                'Me.txt_TableNo.Focus()
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
                If txt_ServerCode.ReadOnly = True Then
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
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
                If txt_ServerCode.ReadOnly = True Then
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
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
                If txt_ServerCode.ReadOnly = True Then
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
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
                If txt_ServerCode.ReadOnly = True Then
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
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
                If txt_ServerCode.ReadOnly = True Then
                    sSGrid.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
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
        If cbo_PaymentMode.SelectedItem = "ROOM" Then
            getNumeric(e)
        End If
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
            Dim strstring As String
            Dim SSQL As String
            Dim CLIMIT, pLIMIT As Double
            'Dim SSQL As String
            Dim PAY As String
            PAY = ""
            'SMART CARD
            'ROOM CHECKIN
            'MEMBER ACCOUNT
            'BANK INSTRUMENT
            'CASH
            'CLUB ACCOUNT
            'EMPLOYEE
            SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(SSQL, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If
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
                    'If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
                    '    MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '    'Exit Sub
                    'End If
                End If
            End If
            If Me.txt_card_id.Text = "" Then
                If UCase(Mid(gCompanyname, 1, 4)) = "" Then
                    If Trim(txt_MemberCode.Text) <> "" Then
                        SQLSTRING = "SELECT * FROM memberblocking WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' AND CAST(CONVERT(VARCHAR(20),adddatetime,106)AS DATETIME)='" & Format(Now, "dd-MMM-yyyy") & "'"
                        gconnection.getDataSet(SQLSTRING, "MEM")
                        If gdataset.Tables("MEM").Rows.Count > 0 Then
                            If PAY = "ROOM CHECKIN" Then
                                Label8.Visible = True
                                Me.txt_MemberName.Text = ""
                                Me.txt_MemberCode.Text = ""
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
                                    If Me.txt_card_id.Text <> "" Then
                                        MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    End If
                                    lbl_SwipeCard.Visible = True
                                    txt_card_id.Clear()
                                    cbo_PaymentMode.Focus()
                                    Exit Sub
                                End If

                                SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                                SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                                SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                                gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
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
                            Label8.Visible = True
                            Me.txt_MemberName.Text = ""
                            Me.txt_MemberCode.Text = ""
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
                                If Me.txt_card_id.Text <> "" Then
                                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                lbl_SwipeCard.Visible = True
                                txt_card_id.Clear()
                                cbo_PaymentMode.Focus()
                                Exit Sub
                            End If

                            SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                            SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                            SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
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

                                    gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                        txt_MemberName.Text = MNAME_GBL
                                        ordertype = "EMPMEMBER"
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            End If
            If Trim(txt_MemberCode.Text) <> "" Then
                'Call tableno()
                If cbo_PaymentMode.Text <> "ROOM" Or cbo_PaymentMode.Text <> "SMART CARD" Then
                    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                End If

                If PAY = "ROOM CHECKIN" Then
                    strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(txt_MemberCode.Text) & "'"
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("docno")
                        ordertype = "ROOMGUEST"
                        If txt_ServerCode.ReadOnly = True Then
                            sSGrid.Focus()
                        Else
                            txt_ServerCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberCode.Focus()
                    End If
                    'club
                    '03/05/2008
                ElseIf PAY = "CLUB ACCOUNT" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM membermaster WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE')and membertypecode in(select subtypecode from subcategorymaster where isnull(clubaccount,'')='Y') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        ordertype = "CLUBMEMBER"
                        If txt_ServerCode.ReadOnly = True Then
                            sSGrid.Focus()
                        Else
                            txt_ServerCode.Focus()
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
                        ordertype = "EMPMEMBER"
                        If txt_ServerCode.ReadOnly = True Then
                            sSGrid.Focus()
                        Else
                            txt_ServerCode.Focus()
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
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            strstring = "SELECT * FROM party_hallbooking_hdr WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                            gconnection.getDataSet(strstring, "membermasterparty")
                            If gdataset.Tables("membermasterparty").Rows.Count > 0 Then
                            Else
                                txt_MemberCode.Text = ""
                                txt_MemberName.Text = ""
                                MessageBox.Show("Check Booking No")
                                txt_MemberCode.Focus()
                            End If
                        End If
                        If gclosingvalue = True Then
                            'If Trim(Txt_Remarks.Text) = "" Then
                            Dim sqlstring As String
                            Dim prvbal, curbal, present, rcd, clsbal, asonbal As Double
                            sqlstring = "exec cp_creditlimit '" & Format(dtp_KOTdate.Value, "dd MMM yyyy") & "','" & Trim(gDebtors) & "','" & Trim(txt_MemberCode.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CP_CREDIT")

                            sqlstring = "select ISNULL(PLIMIT,0) AS PLIMIT,ISNULL(CLIMIT,0) AS CLIMIT,ISNULL(SUM(ISNULL(CDR,0)),0)-ISNULL(SUM(ISNULL(CCR,0)),0) AS CAMOUNT,ISNULL(SUM(ISNULL(PDR,0)),0)-ISNULL(SUM(ISNULL(PCR,0)),0) AS PAMOUNT from CREDITSTOP_MCODE WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' GROUP BY PLIMIT,CLIMIT"
                            gconnection.getDataSet(sqlstring, "CP_CRLIMIT")
                            If gdataset.Tables("CP_CRLIMIT").Rows.Count > 0 Then
                                curbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CAMOUNT")
                                prvbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PAMOUNT")
                                CLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CLIMIT")
                                pLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PLIMIT")
                            Else
                                curbal = 0
                                prvbal = 0
                                CLIMIT = 0
                                pLIMIT = 0
                            End If

                            'If Val(prvbal) < 0 Then
                            '    LABDUE.Text = "PREV MONTH : " & " CR " & Space(8 - Len(Mid(Format(Val(prvbal) * -1, "0.00"), 1, 8))) & Mid(Format(Val(prvbal) * -1, "0.00"), 1, 8)
                            'Else
                            '    LABDUE.Text = "PREV MONTH : " & " DR " & Space(8 - Len(Mid(Format(Val(prvbal), "0.00"), 1, 8))) & Mid(Format(Val(prvbal), "0.00"), 1, 8)
                            'End If
                            'If Val(curbal) < 0 Then
                            '    LABDUE.Text = LABDUE.Text & "   ASON : " & " CR " & Space(8 - Len(Mid(Format(Val(curbal) * -1, "0.00"), 1, 8))) & Mid(Format(Val(curbal) * -1, "0.00"), 1, 8)
                            'Else
                            '    LABDUE.Text = LABDUE.Text & "   ASON : " & " DR " & Space(8 - Len(Mid(Format(Val(curbal), "0.00"), 1, 8))) & Mid(Format(Val(curbal), "0.00"), 1, 8)
                            'End If


                            'If Trim(cbo_PaymentMode.Text) = "CREDIT" Then
                            '    If pLIMIT - CLIMIT > 0 Then
                            '        LABDUE.Text = "CREDIT LIMIT EXCEED Rs....  " & Trim(Format(pLIMIT - CLIMIT, "0.00"))
                            '        MsgBox("CREDIT LIMIT EXCEED...  " & LABDUE.Text, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Credit Limit Exceed")
                            '        txt_MemberCode.Focus()
                            '        Exit Sub
                            '    Else
                            '        LABDUE.Text = "CURRENT BAR LIMIT AMOUNT Rs....  " & Trim(Format(pLIMIT - CLIMIT, "0.00"))
                            '    End If
                            'End If


                            If Trim(PAY) = "MEMBER ACCOUNT" Then

                                'Txt_Remarks.Text = LABDUE.Text
                                txt_ServerCode.Focus()
                                SSQL = "DELETE FROM CREDITSTOP_MCODE WHERE MCODE='" & Trim(txt_MemberCode.Text) & "'"
                                gcommand = New SqlClient.SqlCommand(SSQL, gconnection.Myconn)
                                gconnection.openConnection()
                                gcommand.ExecuteNonQuery()
                                gconnection.closeConnection()
                            Else
                                crstopmsg = ""
                                If txt_ServerCode.ReadOnly = True Then
                                    sSGrid.Focus()
                                Else
                                    txt_ServerCode.Focus()
                                End If
                            End If
                            ' Txt_Remarks.Text = LABDUE.Text    '"L-Credit: " & Format(pcredit, "0.00") & "  L-Debit: " & Format(pdebit, "0.00") & "  L-Closing: " & Format(pclbal, "0.00") & "  C-Credit: " & Format(ccredit, "0.00") & "  C-Debit: " & Format(cdebit, "0.00") & "  C-Closing: " & Format(cclbal, "0.00")
                            txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                            txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                                strstring = "SELECT * FROM party_hallbooking_hdr WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                                gconnection.getDataSet(strstring, "membermasterparty")
                                If gdataset.Tables("membermasterparty").Rows.Count > 0 Then
                                Else
                                    txt_MemberCode.Text = ""
                                    txt_MemberName.Text = ""
                                    MessageBox.Show("Check Booking No")
                                    txt_MemberCode.Focus()
                                End If
                            End If
                            'Else
                            '    txt_MemberCode.Text = ""
                            '    txt_MemberCode.Focus()
                            ' End If
                        Else
                            If txt_ServerCode.ReadOnly = True Then
                                sSGrid.Focus()
                            Else
                                txt_ServerCode.Focus()
                            End If
                        End If
                    Else
                        strstring = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' "
                        gconnection.getDataSet(strstring, "membermaster")
                        If gdataset.Tables("membermaster").Rows.Count > 0 Then
                            Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")

                            If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OkCancel, "chs") = MsgBoxResult.Ok Then
                                txt_MemberCode.Text = ""
                                txt_MemberCode.Focus()
                            Else
                                txt_MemberCode.Text = ""
                                txt_MemberCode.Focus()

                            End If
                        End If
                    End If
                End If
            End If
        Catch
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
                sSGrid.SetActiveCell(1, 1)
                'txt_LOCATIONCODE.Focus()
                'sSGrid.Focus()
            Else
                txt_ServerCode.Text = ""
                txt_ServerCode.Focus()
            End If
        Else
        End If
    End Sub
    Public Sub CreditCheck()
        SQLSTRING = "SELECT ISNULL(MEMLIMIT,0) AS MEMLIMIT FROM MEMBERMASTER WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "CRLIMIT")
        If gdataset.Tables("CRLIMIT").Rows.Count > 0 Then
            CrLimit = gdataset.Tables("CRLIMIT").Rows(0).Item(0)
        Else
            CrLimit = 0
        End If
        SQLSTRING = "SELECT  ISNULL(MCode,'') AS Mcode FROM MEMBERMASTER Where MCODE ='" & Trim(txt_MemberCode.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "MEMBERMASTER")
        If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
            MainCode = gdataset.Tables("MEMBERMASTER").Rows(0).Item("Mcode")
            SQLSTRING = "SELECT SLCODE,ISNULL(SUM(DEB),0)-ISNULL(SUM(CRE),0) AS CLS FROM Get_CreditBal WHERE SLCODE = '" & Trim(MainCode) & "' GROUP BY SLCODE ORDER BY SLCODE"
            gconnection.getDataSet(SQLSTRING, "CLSAMT")
            If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                CrLimitAmt = CrLimit - gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
            Else
                CrLimitAmt = 0
            End If
        End If
    End Sub
    Private Sub CheckBillAmt()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
        GrdAmount = 0
        For i = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Col = 9
                .Row = i
                GrdAmount = GrdAmount + Val(.Text)
            End With
        Next
        For i = 1 To sSGrid.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid
                .Col = 2
                .Row = i
                ITEMCODE = Trim(.Text)
                .Col = 7
                .Row = i
                GrdRate = Val(.Text)
                .Col = 6
                .Row = i
                Qty = Val(.Text)
                .Col = 10
                .Row = i
                ChargeCode = Trim(.Text)
                SQLSTRING = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                gconnection.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                gconnection.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
            End With
        Next
        GrdAmount = GrdAmount + TotTaxAmt
        txt_TotalValue.Text = Format(TotAmt, "0.00")
        txt_TaxValue.Text = Format(TotTaxAmt, "0.00")
        TotCharges = 0
        For i = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Col = 2
                .Row = i
                ITEMCODE = Trim(.Text)
                .Col = 6
                .Row = i
                Qty = Val(.Text)
                .Col = 9
                .Row = i
                GAmt = Val(.Text)
                If gCenterlized = "Y" Then
                    TPackAmt = Val((GAmt * gPackPer) / 100)
                    TTipsAmt = Val((GAmt * gTipsPer) / 100)
                    TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                    'TPartyAmt = Val((GAmt * gPartyPer) / 100)
                    'TRoomAmt = Val((GAmt * gRoomPer) / 100)
                    If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                        TPartyAmt = Val((GAmt * gPartyPer) / 100)
                        'PartyPer = gPartyPer
                    Else
                        TPartyAmt = 0
                        'PartyPer = 0
                    End If
                    If Trim(cbo_PaymentMode.Text) = "ROOM" Then
                        TRoomAmt = Val((GAmt * gRoomPer) / 100)
                        'RoomPer = gRoomPer
                    Else
                        'RoomPer = 0
                        TRoomAmt = 0
                    End If
                Else
                    TPackAmt = Val((GAmt * pPackPer) / 100)
                    TTipsAmt = Val((GAmt * pTipsPer) / 100)
                    TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                    'TPartyAmt = Val((GAmt * pPartyPer) / 100)
                    'TRoomAmt = Val((GAmt * pRoomPer) / 100)
                    If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                        TPartyAmt = Val((GAmt * pPartyPer) / 100)
                        'PartyPer = gPartyPer
                    Else
                        TPartyAmt = 0
                        'PartyPer = 0
                    End If
                    If Trim(cbo_PaymentMode.Text) = "ROOM" Then
                        TRoomAmt = Val((GAmt * pRoomPer) / 100)
                        'RoomPer = gRoomPer
                    Else
                        'RoomPer = 0
                        TRoomAmt = 0
                    End If
                End If
                GrdAmount = GrdAmount + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
                TotCharges = TotCharges + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
            End With
        Next
        Txt_Charges.Text = Format(TotCharges, "0.00")
        txt_BillAmount.Text = Format(GrdAmount, "0.00")
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim Totalamount, Taxamount, Calamount, Caltax, CalBilamount, calhighratio, CardAmount, Billroundoff, dblCard, dblMinimum, Roundoff1, TIPSPERCENT, acperc, acamt As Double
        Dim cancelamt, canceltax, cancel, SubpaymentMode(), paymentaccountcode, Roundaccountcode, Subpaymentaccountcode, Round, jrnsql, jrnsql1 As String
        Dim Taxamt, Totalamt, Packamt, DiscAmt, costinguom, Billdetails, Roundedvalue() As String
        Dim Oldtaxbilldetails, Oldtaxbillno, Oldnontaxbilldetails, Oldnontaxbillno, OldOtherbillno As String
        Dim TaxTotal, total, size, i, j, Z As Double
        Dim TaxApp, NoTax, Otherbool As Boolean
        Dim Taxdr(), NoTaxDr() As DataRow
        Dim Kot_Bill As New DataTable
        Dim Qty As Integer
        Dim taxbilldetails, taxbillno, nontaxbilldetails, nontaxbillno, Otherbillno As String
        Dim sqlstring, varchk, VarSql As String
        Dim Insert(0), Update2(0), caldoublevalue, Insert1(0), StrUpdate(0) As String
        Dim Gridbool As Boolean
        Dim Round1 As Decimal
        'REFERINVENTORY**********************************************************************************************
        Dim POSLOCATION, POSITEMCODE, POSITEMUOM, SALETYPE As String
        Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        Dim K As Integer
        Dim SSQL123 As String
        Dim PAY As String
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, PKOTAMT As Double
        PAY = ""
        SSQL123 = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL123, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If gCenterlized = "Y" Then
            SALETYPE = "SALE"
        Else
            SALETYPE = doctype
        End If
        '************************************************************************************************************
        loccode = ""
        Call Randomize()
        vOutfile = Mid("jrnl" & (Rnd() * 800000), 1, 8)
        Update2(0) = " Exec Jrn_Kot_Det '" & vOutfile & "'"
        Call CheckBillAmt()
        Call CreditCheck()

        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
            Txt_PartyBookingNo.Text = Val(Txt_PartyBookingNo.Text)
        Else
            Txt_PartyBookingNo.Text = ""
        End If
        sqlstring = "SELECT MCODE,SUM(ISNULL(AMOUNT,0))+SUM(ISNULL(TAXAMOUNT,0))+SUM(ISNULL(PACKAMOUNT,0))+SUM(ISNULL(TIPSAMT,0))+SUM(ISNULL(ADCGSAMT,0))+SUM(ISNULL(PARTYAMT,0))+SUM(ISNULL(ROOMAMT,0)) AS PKOT FROM KOT_DET "
        sqlstring = sqlstring & " WHERE ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(BILLDETAILS,'') = '' AND PAYMENTMODE = '" & Trim(cbo_PaymentMode.Text) & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "' GROUP BY MCODE"
        gconnection.getDataSet(sqlstring, "PKOT")
        If gdataset.Tables("PKOT").Rows.Count > 0 Then
            PKOTAMT = gdataset.Tables("PKOT").Rows(0).Item(1)
        Else
            PKOTAMT = 0
        End If

        If Trim(cbo_PaymentMode.Text) = "CREDIT" Then
            If CrLimitAmt < (Val(GrdAmount) + Val(PKOTAMT)) Then
                MsgBox("CREDIT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
            If (MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL < (Val(GrdAmount) + Val(PKOTAMT)) Then
                MsgBox("CARD BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Call checkvalidate() '''---> Check Validation
        If chkbool = False Then Exit Sub

        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            ReDim Preserve Update2(Update2.Length)
            Update2(Update2.Length - 1) = " SELECT * INTO " & vOutfile & " FROM KOT_DET WHERE 1<0 "
            sqlstring = " SELECT KOTTYPE FROM POSSETUP"
            sqlstring = "SELECT ISNULL(DIRECTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(directprefix,'') AS KOTPREFIX FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
            gconnection.getDataSet(sqlstring, "KOT")
            If gdataset.Tables("KOT").Rows.Count > 0 Then
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                Else
                    Call Autogenerate()
                End If
            End If
            BILLAMT_GBL = Val(txt_BillAmount.Text)

            If PAY = "SMART CARD" Then
                If (MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL < Val(txt_BillAmount.Text) Then
                    MsgBox("SUFFICIENT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    ' Txt_Remarks.Text = "OpBal : " & Format((MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL, "0.00") & " Trans Amt : " & Format(Val(txt_BillAmount.Text), "0.00") & "   ClsBal : " & Format(((MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL) - Val(txt_BillAmount.Text), "0.00")
                End If
            End If

            KOTno = Split(Trim(txt_KOTno.Text), "/")
            Me.txt_TotalValue.Text = 0
            Me.txt_TaxValue.Text = 0
            Me.Txt_Charges.Text = 0
            For i = 1 To sSGrid.DataRowCnt
                cancel = Nothing
                Taxamt = Nothing
                Totalamt = Nothing
                Packamt = Nothing
                acamt = Nothing
                sSGrid.GetText(13, i, cancel)
                If Trim(cancel) <> "Yes" Then
                    sSGrid.GetText(8, i, Taxamt)
                    sSGrid.GetText(9, i, Totalamt)
                    Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(Totalamt), "0.00")
                    Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(Taxamt), "0.00")
                    Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(Packamt), "0.00")
                End If
            Next i

            'If Val(txt_Discount.Text) = 0 Then
            '    Billroundoff = Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.Txt_Charges.Text)
            '    Round1 = CStr(Billroundoff)
            '    Round = CStr(Billroundoff)
            '    'PARDHU
            '    If BILLROUNDYESNO = "YES" Then
            '        If ROUNDVAL = 10 Then
            '            Billroundoff = Math.Round(Round1, 1)
            '            Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
            '        Else
            '            'Billroundoff = Math.Round(Round1, 2)
            '            'End If
            '            If Round.IndexOf(".") <= 0 Then
            '                Round = Round.Insert(Round.Length - 1, ".00")
            '            End If
            '            Roundedvalue = Split(Round, ".")
            '            If Format(Val(Roundedvalue(1)), "00") = 50 Then
            '                Billroundoff = Math.Ceiling(Billroundoff)
            '            ElseIf Format(Val(Roundedvalue(1)), "00") > 50 Then
            '                Billroundoff = Math.Ceiling(Billroundoff)
            '            Else
            '                Billroundoff = Math.Floor(Billroundoff)
            '            End If
            '            Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
            '            If Format(Val(Roundoff1), "00") = 50 Then
            '                Billroundoff = Math.Ceiling(Billroundoff)
            '            ElseIf Format(Val(Roundoff1), "00") > 50 Then
            '                Billroundoff = Math.Ceiling(Billroundoff)
            '            Else
            '                Billroundoff = Math.Floor(Billroundoff)
            '            End If
            '            Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
            '        End If
            '    Else
            '        Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
            '        Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
            '    End If
            '    'PARDHU
            'Else
            '    dbldicountAmount = (Val(txt_TotalValue.Text) * Val(txt_Discount.Text)) / 100
            '    dblGrossAmount = Val(txt_TotalValue.Text) - Val(dbldicountAmount)
            '    dbldicountTax = (Val(txt_TaxValue.Text) * Val(txt_Discount.Text)) / 100
            '    dblGrossTax = Val(txt_TaxValue.Text) - Val(dbldicountTax)
            '    dbldicountPack = (Val(Txt_Charges.Text) * Val(txt_Discount.Text)) / 100
            '    dblGrossPack = Val(Txt_Charges.Text) - Val(dbldicountPack)
            '    dblDicountBillAmount = dblGrossAmount + dblGrossTax + dblGrossPack

            '    'VIJAY()
            '    Me.txt_TotalValue.Text = Format(Val(dblGrossAmount), "0.00")
            '    'Me.txt_TotalValue.Text = Format(Val(txt_TotalValue.Text), "0.00")
            '    Me.txt_TaxValue.Text = Format(Val(dblGrossTax), "0.00")
            '    Me.Txt_Charges.Text = Format(Val(dblGrossPack), "0.00")

            '    Round = CStr(dblDicountBillAmount)
            '    If BILLROUNDYESNO = "YES" Then
            '        If ROUNDVAL = 10 Then
            '            Billroundoff = Math.Round(Round1, 1)
            '            Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
            '        Else

            '            If Round.IndexOf(".") <= 0 Then
            '                Round = Round.Insert(Round.Length - 1, ".00")
            '            End If
            '            Roundedvalue = Split(Round, ".")
            '            If Format(Val(Roundedvalue(1)), "00") = ROUNDVAL Then
            '                Billroundoff = Math.Ceiling(dblDicountBillAmount)
            '            ElseIf Format(Val(Roundedvalue(1)), "00") > ROUNDVAL Then
            '                Billroundoff = Math.Ceiling(dblDicountBillAmount)
            '            Else
            '                Billroundoff = Math.Floor(dblDicountBillAmount)
            '            End If
            '            Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
            '            If Format(Val(Roundoff1), "00") = ROUNDVAL Then
            '                dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
            '            ElseIf Format(Val(Roundoff1), "00") > ROUNDVAL Then
            '                dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
            '            Else
            '                dblDicountBillAmount = Math.Floor(dblDicountBillAmount)
            '            End If
            '            Me.txt_BillAmount.Text = Format(Math.Round(Val(dblDicountBillAmount)), "0.00")
            '        End If

            '    Else
            '        Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
            '        Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
            '    End If
            'End If
            If Val(txt_Discount.Text) = 0 Then
                If BILLROUNDYESNO = "YES" Then
                    txt_BillAmount.Text = Format(Math.Round(GrdAmount - Val(txt_Discount.Text), 0), "0.00")
                Else
                    txt_BillAmount.Text = Format((GrdAmount - Val(txt_Discount.Text)), "0.00")
                End If
            Else
                If BILLROUNDYESNO = "YES" Then
                    txt_BillAmount.Text = Format(Math.Round(GrdAmount, 0), "0.00")
                Else
                    txt_BillAmount.Text = Format((GrdAmount), "0.00")
                End If
            End If

            '''******************************************* Find Out Paymentmode Accountcode and Subpaymentmode Accountcode *********************'''
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
            '''************************************************************* PAYMENT MODE ACCT IN *******************'''
            sqlstring = "SELECT Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "Paymentmodemaster")
            If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
                paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
            Else
                MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                paymentaccountcode = ""
                Exit Sub
            End If
            '''************************************************************* ROUND OFF ACCT IN *******************'''
            sqlstring = "SELECT ISNULL(ROUNDACCTIN,'') AS ROUNDACCTIN FROM POSSETUP WHERE ISNULL(ROUNDACCTIN,'') <> ''"
            gconnection.getDataSet(sqlstring, "POSSETUP")
            If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                Roundaccountcode = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("ROUNDACCTIN") & "")
            Else
                'MessageBox.Show("Assign a AccountCode For Specified ROUNDOFF VALUE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Roundaccountcode = ""
                'Exit Sub
            End If
            '''***************************************************************** INSERT INTO KOT_HDR ********************************************************************************************************'''
            If PAY = "ROOM CHECKIN" Then
                sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','','','','" & Trim(txt_MemberCode.Text) & "', "
                Else
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','','','','" & Trim(txt_MemberCode.Text) & "', "
                End If
                sqlstring = sqlstring & " '" & Trim(txt_MemberName.Text) & "','" & Trim(txt_MemberCode.Tag) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                If BILLROUNDYESNO = "YES" Then
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                Else
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                End If
                sqlstring = sqlstring & " 'N',0,'','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','N')"

            ElseIf PAY = "PENDING" Then
                sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,SMARTBILL"
                sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername) "
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                Else
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                End If

                sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"

                If BILLROUNDYESNO = "YES" Then
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                Else
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                End If
                sqlstring = sqlstring & " 'N','" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(gDebitors) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','N')"

            ElseIf PAY = "MEMBER ACCOUNT" Then
                sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "

                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                Else
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                End If

                sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                'sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(txt_PackingCharge.Text) & "," & Val(txt_TotalValue.Text) & "," & Val(txt_TaxValue.Text) & "," & Math.Round(Val(txt_BillAmount.Text)) & "," & Format((Val(txt_BillAmount.Text)) - (Val(txt_TotalValue.Text) + Val(txt_PackingCharge.Text) + Val(txt_TaxValue.Text)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                If BILLROUNDYESNO = "YES" Then
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                Else
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                End If
                sqlstring = sqlstring & " 'N','" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(gDebitors) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','N')"

            ElseIf PAY = "SMART CARD" Then
                sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                Else
                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                End If
                sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                If BILLROUNDYESNO = "YES" Then
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                Else
                    sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                End If
                sqlstring = sqlstring & " 'N','" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(gDebitors) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','Y')"
            Else
                Try
                    sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                    sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                    If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                        If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                            sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                            sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "
                            If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','','','','', "
                            Else
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','','','','', "
                            End If

                            sqlstring = sqlstring & " '','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"

                            If BILLROUNDYESNO = "YES" Then
                                sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                            Else
                                sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                            End If
                            sqlstring = sqlstring & " 'N','" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','Y')"
                        Else
                            sqlstring = "INSERT INTO KOT_HDR(KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,SLCode,MCode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,PackAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                            sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "
                            If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                            Else
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','" & Trim(SALETYPE) & "','" & Trim(accountcode) & "','" & Trim(txt_MemberCode.Text) & "', "
                            End If
                            sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                            If BILLROUNDYESNO = "YES" Then
                                sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Math.Round(Val(0)) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                            Else
                                sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                            End If
                            sqlstring = sqlstring & " 'N','" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','Y')"
                        End If
                    Else
                        MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Catch ex As Exception
                    MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
            Insert(0) = sqlstring
            '''******************************************************** Insert into KOT_DET **********************************'''
            For i = 1 To sSGrid.DataRowCnt
                sqlstring = "INSERT INTO KOT_DET(KotNo,KOTdetails,KotDate,Billdetails,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,PackAmt,DiscAmt,BillAmt,ChkId,MKOTNO,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGROUPCODE,"
                sqlstring = sqlstring & "Openfacilityst,Promotionalst,Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,KOTStatus,Delflag,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA) "
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    sqlstring = sqlstring & " VALUES('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & doctype & "','" & Trim(cbo_PaymentMode.Text) & "',"
                Else
                    sqlstring = sqlstring & " VALUES('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & doctype & "','" & Trim(cbo_PaymentMode.Text) & "',"
                End If

                If BILLROUNDYESNO = "YES" Then
                    sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & "," & Val(Me.txt_TableNo.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_Discount.Text) & "," & Math.Round(Val(0)) & "," & Val(Me.txt_MemberCode.Tag) & ""
                Else
                    sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & "," & Val(Me.txt_TableNo.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_Discount.Text) & "," & Val(0) & "," & Val(Me.txt_MemberCode.Tag) & ""
                End If
                sSGrid.Row = i
                sSGrid.Col = 1
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 2
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 3
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 4
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 5
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 6
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 7
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                POS_RATE_GBL = Val(sSGrid.Text)
                sSGrid.Col = 8
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 9
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 10
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 11
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 12
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & " "
                sSGrid.Col = 14
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 15
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 16
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 17
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 19
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 20
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 10
                If Trim(sSGrid.Text) = "BAR" Then
                    sqlstring = sqlstring & ",'','Y'"
                ElseIf Trim(sSGrid.Text) = "SD" Then
                    sqlstring = sqlstring & ",'SALES','S'"
                Else
                    sqlstring = sqlstring & ",'SALES','N'"
                End If
                sqlstring = sqlstring & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sSGrid.Col = 13
                If Trim(sSGrid.Text) = "Yes" Then
                    sqlstring = sqlstring & ",'Y','N','','','')"
                Else
                    sqlstring = sqlstring & ",'N','N','','','')"
                End If
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                ReDim Preserve Update2(Update2.Length)
                Update2(Update2.Length - 1) = Replace(sqlstring, "KOT_DET", " " & vOutfile & " ")


                ''REFERINVENTORY*************************UPDATING STOCK***********************************************
                sSGrid.Row = i
                sSGrid.Col = 4
                POSLOCATION = Trim(sSGrid.Text)


                Dim SUBSTORECODE As String

                sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POScode) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                'sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='NAB' AND ISNULL(FREEZE,'') <> 'Y'"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    sSGrid.Row = i
                    sSGrid.Col = 2
                    POSITEMCODE = Trim(sSGrid.Text)

                    sSGrid.Row = i
                    sSGrid.Col = 5
                    POSITEMUOM = Trim(sSGrid.Text)

                    sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(STRPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
                    gconnection.getDataSet(sqlstring, "SUBSTORE")
                    If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                        SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                    Else
                        SUBSTORECODE = STRPOSCODE
                    End If

                    sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                    sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "BOM")
                    If gdataset.Tables("BOM").Rows.Count > 0 Then
                        For K = 0 To gdataset.Tables("BOM").Rows.Count - 1
                            sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            Else
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            End If
                            sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                            sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                            sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "',"
                            sSGrid.Col = 5
                            sSGrid.Row = i
                            dblCalqty = Val(sSGrid.Text)
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            sqlstring = sqlstring & AVGRATE & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT")) & ","
                            sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ","
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next K
                    Else
                        sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                        sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                        sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' and I.STORECODE='" & Trim(SUBSTORECODE) & "'"
                        gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                        If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                            sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            Else
                                sqlstring = sqlstring & " VALUES ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            End If

                            sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                            sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                            sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "',"
                            sSGrid.Col = 5
                            sSGrid.Row = i
                            dblCalqty = Val(sSGrid.Text)
                            sqlstring = sqlstring & dblCalqty & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            sqlstring = sqlstring & AVGRATE & ","
                            sqlstring = sqlstring & dblCalqty * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            sqlstring = sqlstring & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"

                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring

                            'ReDim Preserve Update2(Update2.Length)
                            'Update2(Update2.Length - 1) = Replace(sqlstring, "kot_det", " " & vOutfile & " ")
                        End If
                    End If
                End If
                '******************************************************************************************************
            Next i

            '''********************************************************* INSERT INTO BILL_HDR TABLE ********************************************************************************************************************************************************************************************************************************************'''
            If PAY = "ROOM CHECKIN" Then
                sqlstring = "INSERT INTO BILL_HDR(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(Me.txt_ServerCode.Text) & "','" & Trim(Me.txt_ServerName.Text) & "','N'," & Val(Me.txt_MemberCode.Text) & ","
                sqlstring = sqlstring & " " & Val(Me.txt_MemberCode.Tag) & ",'" & Trim(Me.txt_MemberName.Text) & "','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            ElseIf PAY = "MEMBER ACCOUNT" Then
                sqlstring = "INSERT INTO BILL_HDR(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(gDebitors) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Me.txt_MemberCode.Text) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','" & Trim(Me.txt_ServerName.Text) & "','N',0,"
                sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
                'SMART
            ElseIf PAY = "SMART CARD" Then
                sqlstring = "INSERT INTO BILL_HDR(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','" & Trim(Me.txt_ServerName.Text) & "','N',0,"
                sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'," & Format(Val(dblMinimum), "0.00") & "," & Format(Val(dblCard), "0.00") & ",'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            ElseIf PAY = "CARD" Then
                sqlstring = "INSERT INTO BILL_HDR(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(Trim(CStr(KOTno(1)))) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "','" & Trim(Me.txt_ServerName.Text) & "','N',0,"
                sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'," & Format(Val(dblMinimum), "0.00") & "," & Format(Val(dblCard), "0.00") & ",'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
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
                                        sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Math.Round(Val(Totalamount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                        dblCard = Math.Round(Val(Totalamount))
                                        dblMinimum = 0
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    Else
                                        MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        cbo_PaymentMode.Focus()
                                        Exit Sub
                                    End If
                                End If
                            ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) >= Val(Totalamount) Then
                                sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = Minimumusage - " & Math.Round(Val(Totalamount)) & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                                dblCard = 0
                                dblMinimum = Math.Round(Val(Totalamount))
                            ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) <= Val(Totalamount) And Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) > 0 Then
                                sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = 0 WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                                dblMinimum = Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                CardAmount = Math.Round(Val(Totalamount)) - Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                                gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                    If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(Totalamount) Then
                                        sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Format(Val(CardAmount), "0.00") & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
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
                '''***************************************************** $ COMPLETE CALCULATION FOR CARD PAYMENTMODE ********************************************************************************'''
            Else
                Try
                    sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                    sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                    If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                        If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                            sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                            sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                            sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(Me.txt_ServerCode.Text) & "','" & Trim(Me.txt_ServerName.Text) & "','N',0,"
                            sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
                        Else
                            sqlstring = "INSERT INTO Bill_Hdr(Billno,BillDetails,BillDate,BillTime,DiscountAmount,PackAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,servicelocation,[16_digit_code],cardholdercode,cardholdername) VALUES"
                            sqlstring = sqlstring & " ('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "T") & "'," & Val(txt_Discount.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",0,'" & Trim(Roundaccountcode) & " ',"
                            sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Me.txt_MemberCode.Text) & "','" & Trim(Me.txt_MemberName.Text) & "','" & Trim(Me.txt_ServerCode.Text) & "',"
                            sqlstring = sqlstring & " '" & Trim(Me.txt_ServerName.Text) & "','N',0,0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
                        End If
                    Else
                        MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Catch ex As Exception
                    MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            '''*********************************************************** COMPLETE INSERTING BILL_HDR ***********************************************************************************************'''
            '''*********************************************************** INSERT INTO BILL_DET ******************************************************************************************************'''
            sqlstring = "SELECT ISNULL(TAXCODE,'') AS TAXCODE  FROM TAXITEMLINK WHERE ITEMTYPECODE IN (SELECT TAXTYPECODE FROM CHARGEMASTER WHERE CHARGECODE IN (SELECT ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE FROM ITEMMASTER INNER JOIN POSMENULINK ON "
            sqlstring = sqlstring & " ITEMMASTER.ITEMCODE = POSMENULINK.ITEMCODE))" ' WHERE POS= '" & Trim(poscode) & "') "
            gconnection.getDataSet(sqlstring, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                sqlstring = " INSERT INTO Bill_Det(Billno,BillDetails,BillDate,KotDetails,TaxAmount,Packamount,Discountamount,KotAmount,Roundoff,OthBillDetails,KotDate,TaxCode) VALUES ("
                sqlstring = sqlstring & " '" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                sqlstring = sqlstring & " " & Val(0) & "," & Val(0) & "," & Val(txt_Discount.Text) & "," & Val(0) & ",0,'',"
                sqlstring = sqlstring & " '" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("TAXCODE")) & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                sqlstring = "UPDATE KOT_HDR SET "
                sqlstring = sqlstring & " Crostatus='N',PaymentType ='" & Trim(Me.cbo_PaymentMode.Text) & "',Paymodeaccountcode ='" & Trim(paymentaccountcode) & " ',"
                sqlstring = sqlstring & " SubPaymentMode ='" & Trim(SubpaymentMode(0)) & "',subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ' WHERE Kotdetails= '" & Trim(CStr(txt_KOTno.Text)) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                sqlstring = "UPDATE KOT_DET SET BillDetails='" & Trim(CStr(txt_KOTno.Text)) & "'"
                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            End If
            '''*********************************************************** COMPLETE INSERTING BILL_DET ***********************************************************************************************'''
            ''''************************************************** $ BILL SETTLEMENT IF ANY   $ ********************************************'''
            If ssgridPayment1.DataRowCnt = 0 Then
                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                sqlstring = sqlstring & " '" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Trim(cbo_PaymentMode.Text) & "','" & Trim(POScode) & "','" & Trim(paymentaccountcode) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "', "
                sqlstring = sqlstring & " '','','" & Format(Now, "dd-MMM-yyyy") & "','',''," & Format(Val(txt_BillAmount.Text), "0.00") & ", " & Format(Val(txt_BillAmount.Text), "0.00") & ",0,'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N') "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            Else
                For Z = 1 To ssgridPayment1.DataRowCnt
                    ssgridPayment1.Col = 1
                    ssgridPayment1.Row = Z
                    If Trim(ssgridPayment1.Text) <> "" Then
                        ssgridPayment1.Col = 3
                        ssgridPayment1.Row = Z
                        sqlstring = " SELECT ISNULL(Accountin,'') AS ACCOUNTIN,ISNULL(Paymentcode,'') AS Paymentcode,ISNULL(paymentType,'') AS paymentType  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment1.Text) & "' AND ISNULL(Freeze,'')='N'"
                        gconnection.getDataSet(sqlstring, "paymentmodemaster")
                        If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                            If Trim(ssgridPayment1.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'" & Trim("") & "','" & Trim("") & "','" & Format(Now, "dd-MMM-yyyy") & "','','" & Trim("") & "',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            ElseIf Trim(ssgridPayment1.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'" & Trim(cmb_instype.Text) & "','" & Trim(txt_insno.Text) & "','" & Format(Now, "dd-MMM-yyyy") & "','" & Trim("") & "','',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Else
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'','','" & Format(Now, "dd-MMM-yyyy") & "','','',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            End If
                        End If
                    End If
                Next Z
            End If
            '''''************************************************** $ BILL SETTLEMENT COMPLETE   $ ********************************************'''
            ''**************************Inserting Data into ROOM LEDGER table **************************************
            If PAY = "ROOM CHECKIN" Then
                Dim saltype As String

                saltype = "SALE"

                sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO,salestype)"
                sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','SALES',1," & Val(txt_TotalValue.Text) & ","
                sqlstring = sqlstring & "'" & POScode & "'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','DEBIT','ROOM','RM','RM',1,'" & saltype & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                If Val(txt_TaxValue.Text) > 0 Then
                    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','VAT',1," & Val(txt_TaxValue.Text) & ","
                    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','VAT',1," & Val(txt_TaxValue.Text) & ","
                    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If

                'If Val(txt_PackingCharge.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_PackingCharge.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_PackingCharge.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
                'If Val(Me.txt_tips.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','TIPS',1," & Val(txt_tips.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','TIPS',1," & Val(txt_tips.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
                'If Val(Me.TXT_ACCHG.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "',substring('" & Trim(CStr(txt_KOTno.Text)) & "',5,6),'" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','ACCHG',1," & Val(TXT_ACCHG.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','ACCHG',1," & Val(TXT_ACCHG.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
            End If
            '--------------------

            With ssgrid_settlement
                If .DataRowCnt = 1 Or .DataRowCnt = 0 Then
                    sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,deleteflag,SBILLFLAG) "
                    sqlstring = sqlstring & "VALUES('" & txt_KOTno.Text & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "'," & txt_BillAmount.Text & ",'','N','N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='N' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Else
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,DELETEFLAG,SBILLFLAG) "
                        sqlstring = sqlstring & "VALUES('" & txt_KOTno.Text & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                        .Col = 1
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        .Row = i
                        sqlstring = sqlstring & Math.Round(Val(Trim(.Text)), 2) & ","
                        .Col = 3
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "','N','Y')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Next
                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='Y' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With

            '-----------------------------------------JOURNAL BEGIN

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

            STMcode = Trim(txt_MemberCode.Text)

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
            sqlstring = " Delete From  BILL_JOURNALENTRY Where voucherno='" & txt_KOTno.Text & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "Select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.PACKAMOUNT),0) as Amount,Isnull(B.Acdesc,'') as Acdesc,"
            sqlstring = sqlstring & "Isnull(A.PACKACCOUNTCODE,'') as Acctcode From " & vOutfile & "  A,Accountsglaccountmaster B "
            sqlstring = sqlstring & "Where Isnull(delFlag,'')<>'Y'  And A.PACKACCOUNTCODE=b.Accode "
            sqlstring = sqlstring & "And Isnull(Billdetails,'')='" & txt_KOTno.Text & "' "
            sqlstring = sqlstring & "Group by A.PACKACCOUNTCODE,A.billdetails,B.Acdesc "
            gconnection.getDataSet(sqlstring, "JrnTax1")
            Jnltaxamount = 0
            If (gdataset.Tables("JrnTax1").Rows.Count > 0) Then
                For K = 0 To gdataset.Tables("JrnTax1").Rows.Count - 1
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax1").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax1").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax1").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                    Jnltaxamount = Jnltaxamount + Val(gdataset.Tables("Jrntax1").Rows(K).Item("Amount"))
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End If
            sqlstring = "Select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.TaxAMOUNT),0) as Amount,Isnull(B.Acdesc,'') as Acdesc,"
            sqlstring = sqlstring & "Isnull(A.Taxaccountcode,'') as Acctcode From " & vOutfile & "  A,Accountsglaccountmaster B "
            sqlstring = sqlstring & "Where Isnull(delFlag,'')<>'Y'  And A.TAXAccountcode=b.Accode "
            sqlstring = sqlstring & "And Isnull(Billdetails,'')='" & txt_KOTno.Text & "' "
            sqlstring = sqlstring & "Group by A.Taxaccountcode,A.billdetails,B.Acdesc "
            gconnection.getDataSet(sqlstring, "JrnTax")
            'Jnltaxamount = 0
            If (gdataset.Tables("JrnTax").Rows.Count > 0) Then
                For K = 0 To gdataset.Tables("JrnTax").Rows.Count - 1
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                    Jnltaxamount = Jnltaxamount + Val(gdataset.Tables("Jrntax").Rows(K).Item("Amount"))
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End If
            'ACCOUNTS CODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART
            sqlstring = "select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.AMOUNT),0) as Amount,"
            sqlstring = sqlstring & "Isnull(A.SalesAccountcode,'') as AcctCode,Isnull(B.Acdesc,'') as Acdesc From  " & vOutfile & " A, "
            sqlstring = sqlstring & "Accountsglaccountmaster B Where Isnull(A.delFlag,'')<>'Y' "
            sqlstring = sqlstring & "And Isnull(A.billdetails,'')='" & txt_KOTno.Text & "'  And A.SalesAccountcode=B.Accode "
            sqlstring = sqlstring & "Group by A.SalesAccountcode,A.billdetails,B.Acdesc "
            gconnection.getDataSet(sqlstring, "JrnAcct")
            If (gdataset.Tables("JrnAcct").Rows.Count > 0) Then
                Jnlamount = 0
                For K = 0 To gdataset.Tables("JrnAcct").Rows.Count - 1
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                    Jnlamount = Jnlamount + Val(gdataset.Tables("JrnAcct").Rows(K).Item("Amount"))
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                        sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                        sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                        sqlstring = sqlstring & Trim(STMcode) & "','',"

                        sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                        sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Next
                Else
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                    sqlstring = sqlstring & Trim(txt_MemberCode.Text) & "','" & txt_MemberName.Text & "',"
                    sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
            sqlstring = " Drop Table  " & vOutfile
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            Dim STRSQL2, SSTR As String
            Dim STRSQL As String

            If PAY = "SMART CARD" Then
                If MIN_USAGE_BALANCE_HDR >= Val(BILLAMT_GBL) Then

                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ('" & txt_card_id.Text & "', '" & Trim(txt_Holder_Code.Text) & "','" & STRPOSCODE & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & Val(BILLAMT_GBL) & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & Val(BILLAMT_GBL) & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL


                ElseIf MIN_USAGE_BALANCE_HDR <= 0 Then
                    'DEDUCT AMOUNT ONLY FROM CARD

                    Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                    DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR
                    DEDUCT_FROM_CARD = Val(BILLAMT_GBL) - MIN_USAGE_BALANCE_HDR

                    'FOR BALANCE
                    STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                    'END

                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE,DEDUCT_FROM_card) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & STRPOSCODE & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FC'," & DEDUCT_FROM_CARD & ")"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                ElseIf MIN_USAGE_BALANCE_HDR > 0 And MIN_USAGE_BALANCE_HDR < Val(txt_BillAmount.Text) Then

                    Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                    DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR
                    DEDUCT_FROM_CARD = Val(BILLAMT_GBL) - MIN_USAGE_BALANCE_HDR

                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & Trim(txt_Holder_Code.Text) & "','" & STRPOSCODE & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & DEDUCT_FROM_MINUSAGE & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL


                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE,DEDUCT_FROM_card) VALUES ( '" & txt_card_id.Text & "','" & Trim(txt_Holder_Code.Text) & "','" & STRPOSCODE & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HC'," & DEDUCT_FROM_CARD & ")"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL


                    STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & DEDUCT_FROM_MINUSAGE & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    'FOR EBALANCE

                    Dim BALstr, EBAL As String
                    Dim BALnum As Double
                    sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                    gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
                    If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                        If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                            BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) - Val(DEDUCT_FROM_CARD)
                        Else
                            : BALnum = 0 - Val(DEDUCT_FROM_CARD)
                        End If
                    End If
                    EBAL = abcdADD(BALnum)

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                End If
            End If
            For i = 1 To sSGrid.DataRowCnt
                Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                With sSGrid
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 7
                    .Row = i
                    GrdRate = .Text
                    .Col = 6
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 4
                    .Row = i
                    Pos = Trim(.Text)
                    .Col = 13
                    .Row = i
                    KStatus = Mid(Trim(.Text), 1, 1)
                    .Col = 10
                    .Row = i
                    ChargeCode = Trim(.Text)
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    gconnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    gconnection.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                            STRSQL = "INSERT INTO KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                            STRSQL = STRSQL & "'" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(CMB_BTYPE.Text) & "','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(Pos) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ","

                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                STRSQL = STRSQL & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                STRSQL = STRSQL & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                STRSQL = STRSQL & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                STRSQL = STRSQL & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                STRSQL = STRSQL & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                STRSQL = STRSQL & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                STRSQL = STRSQL & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                STRSQL = STRSQL & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                STRSQL = STRSQL & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                STRSQL = STRSQL & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                STRSQL = STRSQL & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                STRSQL = STRSQL & "" & Val(ThreeB) * Qty & ","
                            End If
                            STRSQL = STRSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = STRSQL
                        Next
                    End If
                End With
            Next
            For i = 1 To sSGrid.DataRowCnt
                With sSGrid
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 6
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 9
                    .Row = i
                    GAmt = Val(.Text)
                    If gCenterlized = "Y" Then
                        TPackAmt = Val((GAmt * gPackPer) / 100)
                        TTipsAmt = Val((GAmt * gTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * gRoomPer) / 100)
                            RoomPer = gRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    Else
                        TPackAmt = Val((GAmt * pPackPer) / 100)
                        TTipsAmt = Val((GAmt * pTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * pRoomPer) / 100)
                            RoomPer = pRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    End If
                    If gCenterlized = "Y" Then
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Else
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTransold(Insert)

            'sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'StrUpdate(0) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE BILL_DET SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE BILL_DET SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE BILL_HDR SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE BILL_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE GROUP BY KOTDETAILS,ITEMCODE)"
            'sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL1")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL2")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            ''sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_HDR SET TotalTax = TAXAMT,Total = TOTAMT,BillAmount = BILLAMT FROM KOT_DET K ,KOT_HDR H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE BILL_DET SET TAXAMOUNT = TAXAMT,KOTAMOUNT = TOTAMT FROM KOT_DET K ,BILL_DET H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE BILL_HDR SET TAXAMOUNT = TAXAMT,BILLAMOUNT = TOTAMT FROM KOT_DET K ,BILL_HDR H WHERE K.BILLDETAILS = H.BILLDETAILS AND K.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = 0 WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            StrUpdate(0) = sqlstring

            sqlstring = "UPDATE KOT_DET SET PACKAMOUNT = (AMOUNT * PACKPERCENT)/100,TipsAmt = (AMOUNT * TipsPer)/100,AdCgsAmt = (AMOUNT * AdCgsPer) /100,PartyAmt = (AMOUNT *PartyPer) / 100, RoomAmt = (AMOUNT * RoomPer)/100  WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE  GROUP BY KOTDETAILS,ITEMCODE)"
            sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'  AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL1")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL2")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0)+ISNULL(SUM(KOT_DET.PACKAMOUNT),0)+ISNULL(SUM(KOT_DET.TipsAmt),0)+ISNULL(SUM(KOT_DET.AdCgsAmt),0)+ISNULL(SUM(KOT_DET.PartyAmt),0)+ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_DET SET PACKAMOUNT = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE BILL_DET SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE BILL_HDR SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE BILL_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET KOTAMOUNT = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_HDR SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET BILLAMOUNT = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring


            gconnection.MoreTrans1(StrUpdate)

            sqlstring = "UPDATE KOT_DET SET CATEGORY =isnull(A.CATEGORY,'') FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'and isnull(KOT_DET.CATEGORY,'') =''"
            gconnection.dataOperation(9, sqlstring, "CAT")

            sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT")

            sqlstring = "UPDATE KOT_DET SET POSCODE='" & Trim(POScode) & "' where category='BAR'and KOTDETAILS='" & Trim(txt_KOTno.Text) & "' and poscode='" & Trim(POScode) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT1")

            sqlstring = "UPDATE substoreconsumptiondetail SET storelocationcode='" & Trim(POScode) & "' where docDETAILS='" & Trim(txt_KOTno.Text) & "' and storelocationcode='" & Trim(POScode) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT1")


            If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                'Call Cmd_Print_Click(Cmd_Print, e)
                Call Cmd_Clear_Click(sender, e)
                If kotupdate = True Then
                    Me.Close()
                End If
            Else
                Call Cmd_Clear_Click(sender, e)
                If kotupdate = True Then
                    Me.Close()
                End If
            End If

        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            If Trim(txt_card_id.Text) = "" And cbo_PaymentMode.Text = "SMART CARD" Then
                MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lbl_SwipeCard.Visible = True
                txt_card_id.Focus()
                Exit Sub
            Else
                If PAY = "SMART CARD" Then
                    Call cardcheck()
                End If
            End If

            ReDim Preserve Update2(Update2.Length)
            Update2(Update2.Length - 1) = " SELECT * INTO " & vOutfile & " FROM KOT_DET WHERE KOTDETAILS='" & txt_KOTno.Text & "'"

            KOTno = Split(Trim(txt_KOTno.Text), "/")
            Me.txt_TotalValue.Text = 0
            Me.txt_TaxValue.Text = 0
            Me.Txt_Charges.Text = 0
            For i = 1 To sSGrid.DataRowCnt
                cancel = Nothing
                Taxamt = Nothing
                Totalamt = Nothing
                Packamt = Nothing
                sSGrid.GetText(12, i, cancel)
                If Trim(cancel) <> "Yes" Then
                    sSGrid.GetText(7, i, Taxamt)
                    sSGrid.GetText(8, i, Totalamt)
                    'sSGrid.GetText(18, i, Packamt)
                    Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(Totalamt), "0.00")
                    Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(Taxamt), "0.00")
                    Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(Packamt), "0.00")
                End If
            Next i
            If Val(txt_Discount.Text) = 0 Then
                Billroundoff = Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.Txt_Charges.Text)
                Round = CStr(Billroundoff)
                Round1 = CStr(Billroundoff)
                If BILLROUNDYESNO = "YES" Then
                    If ROUNDVAL = 10 Then
                        Billroundoff = Math.Round(Round1, 1)
                        Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
                    Else
                        If Round.IndexOf(".") <= 0 Then
                            Round = Round.Insert(Round.Length - 1, ".00")
                        End If
                        Roundedvalue = Split(Round, ".")
                        If Format(Val(Roundedvalue(1)), "00") = 50 Then
                            Billroundoff = Math.Ceiling(Billroundoff)
                        ElseIf Format(Val(Roundedvalue(1)), "00") > 50 Then
                            Billroundoff = Math.Ceiling(Billroundoff)
                        Else
                            Billroundoff = Math.Floor(Billroundoff)
                        End If
                        Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
                        If Format(Val(Roundoff1), "00") = 50 Then
                            Billroundoff = Math.Ceiling(Billroundoff)
                        ElseIf Format(Val(Roundoff1), "00") > 50 Then
                            Billroundoff = Math.Ceiling(Billroundoff)
                        Else
                            Billroundoff = Math.Floor(Billroundoff)
                        End If
                        Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
                    End If
                Else
                    Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
                    Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
                End If
            Else
                dbldicountAmount = (Val(txt_TotalValue.Text) * Val(txt_Discount.Text)) / 100
                dblGrossAmount = Val(txt_TotalValue.Text) - Val(dbldicountAmount)
                dbldicountTax = (Val(txt_TaxValue.Text) * Val(txt_Discount.Text)) / 100
                dblGrossTax = Val(txt_TaxValue.Text) - Val(dbldicountTax)
                dbldicountPack = (Val(Txt_Charges.Text) * Val(txt_Discount.Text)) / 100
                dblGrossPack = Val(Txt_Charges.Text) - Val(dbldicountPack)
                dblDicountBillAmount = dblGrossAmount + dblGrossTax + dblGrossPack
                Me.txt_TotalValue.Text = Format(Val(dblGrossAmount), "0.00")
                'Me.txt_TotalValue.Text = Format(Val(dblGrossAmount), "0.00")
                Me.txt_TaxValue.Text = Format(Val(dblGrossTax), "0.00")
                Me.Txt_Charges.Text = Format(Val(dblGrossPack), "0.00")
                Round = CStr(dblDicountBillAmount)
                Round1 = CStr(dblDicountBillAmount)
                If BILLROUNDYESNO = "YES" Then
                    If ROUNDVAL = 10 Then
                        Billroundoff = Math.Round(Round1, 1)
                        Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
                    Else
                        If Round.IndexOf(".") <= 0 Then
                            Round = Round.Insert(Round.Length - 1, ".00")
                        End If
                        Roundedvalue = Split(Round, ".")
                        If Format(Val(Roundedvalue(1)), "00") = 50 Then
                            Billroundoff = Math.Ceiling(dblDicountBillAmount)
                        ElseIf Format(Val(Roundedvalue(1)), "00") > 50 Then
                            Billroundoff = Math.Ceiling(dblDicountBillAmount)
                        Else
                            Billroundoff = Math.Floor(dblDicountBillAmount)
                        End If
                        Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
                        If Format(Val(Roundoff1), "00") = 50 Then
                            dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
                        ElseIf Format(Val(Roundoff1), "00") > 50 Then
                            dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
                        Else
                            dblDicountBillAmount = Math.Floor(dblDicountBillAmount)
                        End If
                        Me.txt_BillAmount.Text = Format(Math.Round(Val(dblDicountBillAmount)), "0.00")
                        Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
                    End If
                Else
                    Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
                    Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
                End If
            End If

            Dim ssql As String
            ssql = " select isnull(tips,0)as tips from posmaster where poscode='" & STRPOSCODE & "'"
            gconnection.getDataSet(ssql, "ser")
            If gdataset.Tables("ser").Rows.Count > 0 Then
                If Val(gdataset.Tables("ser").Rows(0).Item("tips")) > 0 Then
                    BILLAMT_GBL = Math.Round(Val(txt_BillAmount.Text)) '+ ((Val(Me.txt_TotalValue.Text) * Val(gdataset.Tables("ser").Rows(0).Item("tips"))) / 100), 0)
                Else
                    BILLAMT_GBL = Val(txt_BillAmount.Text)
                End If
            Else
                BILLAMT_GBL = Val(txt_BillAmount.Text)
            End If
            If cbo_PaymentMode.Text = "SMART CARD" Then
                Dim prev As Double
                SSTR = "SELECT * FROM SM_POSTRANSACTION WHERE BILL_NO='" & Trim(txt_KOTno.Text) & "' and isnull(void,'')<>'y'"
                gconnection.getDataSet(SSTR, "SM_POSTRANSACTION")
                If gdataset.Tables("SM_POSTRANSACTION").Rows.Count > 0 Then
                    prev = Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("DEDUCT_FROM_card"))
                End If
                If (MIN_USAGE_BALANCE_HDR + BALANCE_HDR + prev) - MIN_BALANCE_GBL < Val(BILLAMT_GBL) Then
                    MsgBox("SUFFICIENT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            '''******************************************* Find Out Subpaymentmode Accountcode *****************************'''
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
            '''******************************************* Find Out Paymentmode Accountcode  *****************************'''
            sqlstring = "SELECT Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "Paymentmodemaster")
            If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
                paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
            Else
                MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                paymentaccountcode = ""
                Exit Sub
            End If
            '''************************************************************* ROUND OFF ACCT IN *******************'''
            sqlstring = "SELECT ISNULL(ROUNDACCTIN,'') AS ROUNDACCTIN FROM POSSETUP WHERE ISNULL(ROUNDACCTIN,'') <> ''"
            gconnection.getDataSet(sqlstring, "POSSETUP")
            If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                Roundaccountcode = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("ROUNDACCTIN") & "")
            Else
                'MessageBox.Show("Assign a AccountCode For Specified ROUNDOFF VALUE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Roundaccountcode = ""
                'Exit Sub
            End If
            If Me.Lbl_Bill.Visible = True And Me.Lbl_Bill.Text = "CRO GENERATED" Then
                MessageBox.Show("As CRO is generated so Bill Can't be modified", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Cmd_Add.Enabled = True
                Exit Sub
            ElseIf Me.Lbl_Bill.Visible = True And Trim(Me.Lbl_Bill.Text) = "BILL GENERATED" Then
                '''********************************************************** UPDATE KOT_HDR *********************************************************'''
                If PAY = "ROOM CHECKIN" Then
                    sqlstring = "SELECT ISNULL(CHECKOUT,'N') AS CHECKOUT,ISNULL(ROOMNO,0)AS ROOMNO FROM ROOMCHECKIN WHERE DOCNO = " & Val(txt_MemberCode.Tag) & ""
                    gconnection.getDataSet(sqlstring, "Roomcheckin")
                    If gdataset.Tables("Roomcheckin").Rows.Count > 0 Then
                        If Trim(CStr(gdataset.Tables("Roomcheckin").Rows(0).Item("CHECKOUT"))) = "Y" Then
                            MessageBox.Show("Bill Can't be updated " & " as GUEST  had been checkout from RoomNo" & ": " & gdataset.Tables("Roomcheckin").Rows(0).Item("ROOMNO"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Call Cmd_Clear_Click(Cmd_Clear, e)
                            Cmd_Add.Enabled = True
                            Exit Sub
                        End If
                    End If

                    sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & Trim(accountcode) & "',"
                    sqlstring = sqlstring & " Slcode = '',Mcode= '',Mname= '',RoomNo='" & Trim(txt_MemberCode.Text) & "',Guest='" & Trim(txt_MemberName.Text) & "',checkin='" & Trim(txt_MemberCode.Tag) & "',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                    If BILLROUNDYESNO = "YES" Then
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ", PackAmt =" & Val(0) & ", Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    Else
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ", PackAmt =" & Val(0) & ", Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    End If
                    sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & " ',SMARTBILL='Y' "
                    sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                ElseIf PAY = "PENDING" Then
                    sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & Trim(accountcode) & "',"
                    sqlstring = sqlstring & " Slcode = '" & Trim(txt_MemberCode.Text) & "',Mcode= '" & Trim(txt_MemberCode.Text) & "',Mname= '" & Trim(txt_MemberName.Text) & "',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                    If BILLROUNDYESNO = "YES" Then
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(Txt_Charges) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    Else
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(Txt_Charges) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    End If
                    sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(gDebitors) & " ',subpaymentaccountcode = '" & Trim(txt_MemberCode.Text) & "' ,SMARTBILL='Y'"
                    sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                ElseIf PAY = "MEMBER ACCOUNT" Then
                    sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & Trim(accountcode) & "',"
                    sqlstring = sqlstring & " Slcode = '" & Trim(txt_MemberCode.Text) & "',Mcode= '" & Trim(txt_MemberCode.Text) & "',Mname= '" & Trim(txt_MemberName.Text) & "',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                    If BILLROUNDYESNO = "YES" Then
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    Else
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    End If
                    sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(gDebitors) & " ',subpaymentaccountcode = '" & Trim(txt_MemberCode.Text) & "',SMARTBILL='Y' "
                    sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                ElseIf PAY = "SMART CARD" Then
                    sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & Trim(accountcode) & "',"
                    sqlstring = sqlstring & " Slcode = '" & Trim(txt_MemberCode.Text) & "',Mcode= '" & Trim(txt_MemberCode.Text) & "',Mname= '" & Trim(txt_MemberName.Text) & "',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                    If BILLROUNDYESNO = "YES" Then
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    Else
                        sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                    End If
                    sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(gDebitors) & " ',subpaymentaccountcode = '" & Trim(txt_MemberCode.Text) & "',SMARTBILL='Y' "
                    sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                Else
                    Try
                        sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                        sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                        If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                            If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & accountcode & "',"
                                sqlstring = sqlstring & " Slcode = '',Mcode= '',Mname= '',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                                If BILLROUNDYESNO = "YES" Then
                                    sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                                Else
                                    sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                                End If
                                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & " ' ,SMARTBILL='Y'"
                                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                            Else
                                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & Trim(doctype) & "',SaleType='" & Trim(SALETYPE) & "',AccountCode='" & accountcode & "',"
                                sqlstring = sqlstring & " SLCode='" & Trim(txt_MemberCode.Text) & "',MCode='" & Trim(txt_MemberCode.Text) & "',Mname='" & Trim(txt_MemberName.Text) & "',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                                If BILLROUNDYESNO = "YES" Then
                                    sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Math.Round(Val(0)) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                                Else
                                    sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',DiscountAmt =" & Val(txt_Discount.Text) & ",PackAmt =" & Val(0) & ",Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",Roundoff = 0,Remarks = '" & Trim(Txt_Remarks.Text) & "',"
                                End If
                                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoffaccountcode='" & Trim(Roundaccountcode) & "',upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & " ',SMARTBILL='Y' "
                                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
                            End If
                        Else
                            MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                End If
                Insert(0) = sqlstring
                '''********************************************************** UPDATE BILL_HDR *********************************************************'''
                If PAY = "ROOM CHECKIN" Then
                    sqlstring = "UPDATE BILL_HDR SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',BillTime = '" & Format(Now, "hh:mm:ss") & "',DiscountAmount =" & Val(txt_Discount.Text) & ",PackAmount = " & Format(Val(0), "0.00") & ",TaxAmount = " & Format(Val(0), "0.00") & ",BillAmount = " & Format(Val(0), "0.00") & ",PayMentmode= '" & Trim(Me.cbo_PaymentMode.Text) & "' ,Paymentaccountcode= '" & Trim(paymentaccountcode) & " ' ,SubPaymentMode='" & Trim(SubpaymentMode(0)) & "',Subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ',"
                    sqlstring = sqlstring & "Mcode='',Mname='',Scode='" & Trim(Me.txt_ServerCode.Text) & "',sname='" & Trim(Me.txt_ServerName.Text) & "',Roomno=" & Val(Me.txt_MemberCode.Text) & ",ChkId=" & Val(Me.txt_MemberCode.Tag) & ",Guest='" & Trim(Me.txt_MemberName.Text) & "',Roundoff = 0,Roundoffaccountcode='" & Trim(Roundaccountcode) & "',"
                    sqlstring = sqlstring & "Upduserid='" & gUsername & "',Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Remarks = '" & Trim(CStr(Txt_Remarks.Text)) & "' WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
                ElseIf PAY = "MEMBER ACCOUNT" Then
                    sqlstring = "UPDATE BILL_HDR SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',BillTime = '" & Format(Now, "hh:mm:ss") & "',DiscountAmount =" & Val(txt_Discount.Text) & ",PackAmount = " & Format(Val(0), "0.00") & ",TaxAmount = " & Format(Val(0), "0.00") & ",BillAmount = " & Format(Val(0), "0.00") & ",PayMentmode= '" & Trim(Me.cbo_PaymentMode.Text) & "' ,Paymentaccountcode= '" & Trim(gDebitors) & "' ,SubPaymentMode='" & Trim(SubpaymentMode(0)) & "',Subpaymentaccountcode='" & Trim(txt_MemberCode.Text) & "',"
                    sqlstring = sqlstring & "Mcode='" & Trim(Me.txt_MemberCode.Text) & "',Mname='" & Trim(Me.txt_MemberName.Text) & "',Scode='" & Trim(Me.txt_ServerCode.Text) & "',sname='" & Trim(Me.txt_ServerName.Text) & "',Roomno=0,ChkId=0,Guest='',Roundoff = 0,Roundoffaccountcode='" & Trim(Roundaccountcode) & "',"
                    sqlstring = sqlstring & "Upduserid='" & gUsername & "',Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Remarks = '" & Trim(CStr(Txt_Remarks.Text)) & "' WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
                ElseIf PAY = "SMART CARD" Then
                    sqlstring = "UPDATE BILL_HDR SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',BillTime = '" & Format(Now, "hh:mm:ss") & "',DiscountAmount =" & Val(txt_Discount.Text) & ",PackAmount = " & Format(Val(0), "0.00") & ",TaxAmount = " & Format(Val(0), "0.00") & ",BillAmount = " & Format(Val(0), "0.00") & ",PayMentmode= '" & Trim(Me.cbo_PaymentMode.Text) & "' ,Paymentaccountcode= '" & Trim(gDebitors) & "' ,SubPaymentMode='" & Trim(SubpaymentMode(0)) & "',Subpaymentaccountcode='" & Trim(txt_MemberCode.Text) & "',"
                    sqlstring = sqlstring & "Mcode='" & Trim(Me.txt_MemberCode.Text) & "',Mname='" & Trim(Me.txt_MemberName.Text) & "',Scode='" & Trim(Me.txt_ServerCode.Text) & "',sname='" & Trim(Me.txt_ServerName.Text) & "',Roomno=0,ChkId=0,Guest='',Roundoff = 0,Roundoffaccountcode='" & Trim(Roundaccountcode) & "',"
                    sqlstring = sqlstring & "Upduserid='" & gUsername & "',Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Remarks = '" & Trim(CStr(Txt_Remarks.Text)) & "',[16_digit_code]='" & txt_card_id.Text & "',cardholdercode='" & txt_Holder_Code.Text & "',cardholdername='" & Txt_holder_name.Text & "'  WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
                Else
                    Try
                        sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                        sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                        If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                            If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                                sqlstring = "UPDATE BILL_HDR SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',BillTime = '" & Format(Now, "hh:mm:ss") & "',DiscountAmount =" & Val(txt_Discount.Text) & ",PackAmount = " & Format(Val(0), "0.00") & ",TaxAmount = " & Format(Val(0), "0.00") & ",BillAmount = " & Format(Val(0), "0.00") & ",PayMentmode= '" & Trim(Me.cbo_PaymentMode.Text) & "' ,Paymentaccountcode= '" & Trim(paymentaccountcode) & " ' ,SubPaymentMode='" & Trim(SubpaymentMode(0)) & "',Subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ',"
                                sqlstring = sqlstring & "Mcode='',Mname='',Scode='" & Trim(Me.txt_ServerCode.Text) & "',sname='" & Trim(Me.txt_ServerName.Text) & "',Roomno=0,ChkId=0,Guest='',Roundoff = 0,Roundoffaccountcode='" & Trim(Roundaccountcode) & "',"
                                sqlstring = sqlstring & "Upduserid='" & gUsername & "',Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Remarks = '" & Trim(CStr(Txt_Remarks.Text)) & "' WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
                            Else
                                sqlstring = "UPDATE BILL_HDR SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',BillTime = '" & Format(Now, "hh:mm:ss") & "',DiscountAmount =" & Val(txt_Discount.Text) & ",PackAmount = " & Format(Val(0), "0.00") & ",TaxAmount = " & Format(Val(0), "0.00") & ",BillAmount = " & Format(Val(0), "0.00") & ",PayMentmode= '" & Trim(Me.cbo_PaymentMode.Text) & "' ,Paymentaccountcode= '" & Trim(paymentaccountcode) & " ' ,SubPaymentMode='" & Trim(SubpaymentMode(0)) & "',Subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ',"
                                sqlstring = sqlstring & "Mcode='" & Trim(Me.txt_MemberCode.Text) & "',Mname='" & Trim(Me.txt_MemberName.Text) & "',Scode='" & Trim(Me.txt_ServerCode.Text) & "',sname='" & Trim(Me.txt_ServerName.Text) & "',Roomno=0,ChkId=0,Guest='',Roundoff = 0,Roundoffaccountcode='" & Trim(Roundaccountcode) & "',"
                                sqlstring = sqlstring & "Upduserid='" & gUsername & "',Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Remarks = '" & Trim(CStr(Txt_Remarks.Text)) & "'  WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
                            End If
                        Else
                            MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                End If
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''*********************************************************** COMPLETE ************************************************************'''
                'REFERINVENTORY
                'VarSql = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode FROM KOT_DET WHERE KOTDETAILS  = '" & Trim(txt_KOTno.Text) & "'"
                VarSql = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode,ISNULL(QTY,0) QTY FROM KOT_DET WHERE KOTDETAILS  = '" & Trim(txt_KOTno.Text) & "'"
                gconnection.getDataSet(VarSql, "TEMPKOTDET")
                If gdataset.Tables("TEMPKOTDET").Rows.Count > 0 Then
                    For Z = 0 To gdataset.Tables("TEMPKOTDET").Rows.Count - 1
                        For i = 1 To sSGrid.DataRowCnt
                            sSGrid.Row = i
                            sSGrid.Col = 18
                            If Val(sSGrid.Text) = Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) Then
                                '''******************************************************** UPDATE INTO KOT_DET ******************************************************'''
                                sqlstring = "UPDATE KOT_DET SET KotType = '" & Trim(doctype) & "',kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',PaymentMode= '" & Trim(cbo_PaymentMode.Text) & "' ,"
                                sqlstring = sqlstring & " Mcode = '" & Trim(txt_MemberCode.Text) & "',Scode = '" & Trim(txt_ServerCode.Text) & "',Covers = " & Val(Me.txt_Cover.Text) & ",TableNo = " & Val(Me.txt_TableNo.Text) & ","
                                If BILLROUNDYESNO = "YES" Then
                                    sqlstring = sqlstring & " TotAmt= " & Val(0) & ",PackAmt = " & Val(0) & " ,TaxAmt= " & Val(0) & ",DiscAmt =" & Val(Me.txt_Discount.Text) & ", BillAmt= " & Math.Round(Val(0)) & ",ChkId= " & Val(Me.txt_MemberCode.Tag) & " "
                                Else
                                    sqlstring = sqlstring & " TotAmt= " & Val(0) & ",PackAmt = " & Val(0) & " ,TaxAmt= " & Val(0) & ",DiscAmt =" & Val(Me.txt_Discount.Text) & ", BillAmt= " & Val(0) & ",ChkId= " & Val(Me.txt_MemberCode.Tag) & " "
                                End If
                                sSGrid.Row = i
                                sSGrid.Col = 1
                                sqlstring = sqlstring & ",MKOTNO='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 2
                                sqlstring = sqlstring & ",ItemCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 3
                                sqlstring = sqlstring & ",Itemdesc='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 4
                                sqlstring = sqlstring & ",Poscode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 5
                                sqlstring = sqlstring & ",Uom= '" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 6
                                sqlstring = sqlstring & ",Qty= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 7
                                sqlstring = sqlstring & ",Rate= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 8
                                sqlstring = sqlstring & ",Taxamount= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 9
                                sqlstring = sqlstring & ",Amount = " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 10
                                sqlstring = sqlstring & ",ItemType ='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 11
                                sqlstring = sqlstring & ",TaxCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 12
                                sqlstring = sqlstring & ",TaxPerc =" & Val(sSGrid.Text) & " "
                                sSGrid.Col = 14
                                sqlstring = sqlstring & ",TaxAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 15
                                sqlstring = sqlstring & ",SalesAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 16
                                sqlstring = sqlstring & ",GroupCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 17
                                sqlstring = sqlstring & ",SUBGroupCode ='" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 19
                                sqlstring = sqlstring & ",Openfacilityst ='" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 20
                                sqlstring = sqlstring & ",Promotionalst ='" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 10
                                If Trim(sSGrid.Text) = "BAR" Then
                                    sqlstring = sqlstring & ",Taxtype = '',Alcholst = 'Y'"
                                ElseIf Trim(sSGrid.Text) = "SD" Then
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='S'"
                                Else
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='N'"
                                End If
                                sqlstring = sqlstring & ",Upduserid = '" & Trim(gUsername) & "',Upddatetime = '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                sSGrid.Col = 13
                                If Trim(sSGrid.Text) = "Yes" Then
                                    sqlstring = sqlstring & "KOTStatus='Y',DELFLAG = 'N'"
                                Else
                                    sqlstring = sqlstring & "KOTStatus='N',DELFLAG = 'N'"
                                End If
                                sqlstring = sqlstring & " WHERE  AUTOID = " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & ""
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring

                                ReDim Preserve Update2(Update2.Length)
                                Update2(Update2.Length - 1) = Replace(sqlstring, "KOT_DET", " " & vOutfile & " ")

                                'REFERINVENTORY******************************* CHANGING THE QUANTITY OF ITEM *****************
                                sSGrid.Row = i
                                sSGrid.Col = 3
                                POSLOCATION = Trim(sSGrid.Text)

                                sSGrid.Row = i
                                sSGrid.Col = 1
                                POSITEMCODE = Trim(sSGrid.Text)

                                Dim SUBSTORECODE As String

                                sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(STRPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
                                gconnection.getDataSet(sqlstring, "SUBSTORE")
                                If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                    SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                Else
                                    SUBSTORECODE = STRPOSCODE
                                End If

                                'sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POScode) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                                'PENDING


                                sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POScode) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                                    sSGrid.Row = i
                                    sSGrid.Col = 1
                                    POSITEMCODE = Trim(sSGrid.Text)

                                    sSGrid.Row = i
                                    sSGrid.Col = 4
                                    POSITEMUOM = Trim(sSGrid.Text)

                                    sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                                    sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                                    gconnection.getDataSet(sqlstring, "BOM")
                                    If gdataset.Tables("BOM").Rows.Count > 0 Then
                                        For K = 0 To gdataset.Tables("BOM").Rows.Count - 1
                                            sqlstring = "UPDATE SUBSTORECONSUMPTIONDETAIL SET DOCDate = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 3
                                            sqlstring = sqlstring & ",STORELOCATIONcode='" & Trim(SUBSTORECODE) & "'"
                                            sqlstring = sqlstring & ",STORELOCATIONNAME='" & STORELOCATION(Trim(SUBSTORECODE)) & "'"
                                            sqlstring = sqlstring & ",ItemCode='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & ",ItemNAME='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "'"
                                            sqlstring = sqlstring & ",Uom= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                            sSGrid.Col = 5
                                            sqlstring = sqlstring & ",Qty= " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY"))) & ""
                                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                            sqlstring = sqlstring & ",RATE= " & AVGRATE & ""
                                            sSGrid.Col = 5
                                            sSGrid.Row = i
                                            dblCalqty = Val(sSGrid.Text)
                                            sqlstring = sqlstring & ",AMOUNT= " & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ""
                                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                            sqlstring = sqlstring & ",DBLAmt = " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT"))) & ""
                                            sqlstring = sqlstring & ",HIGHRATIO = " & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ""
                                            sqlstring = sqlstring & ",GROUPCODE= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "'"
                                            sqlstring = sqlstring & ",SUBGROUPCODE= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "'"
                                            sSGrid.Col = 12
                                            If Trim(sSGrid.Text) = "1" Then
                                                sqlstring = sqlstring & ",VOID='Y'"
                                            Else
                                                sqlstring = sqlstring & ",VOID='N'"
                                            End If
                                            sqlstring = sqlstring & ",UpdATEuser = '" & Trim(gUsername) & "',Updatetime = '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
                                            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_KOTno.Text) & "' AND STORELOCATIONCODE='" & Trim(SUBSTORECODE) & "' "
                                            sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 22
                                            '  sqlstring = sqlstring & " AND QTY='" & Val(ssGrid.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & "'"

                                            ReDim Preserve Insert(Insert.Length)
                                            Insert(Insert.Length - 1) = sqlstring
                                        Next K
                                    Else

                                        sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                        sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                                        sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' and i.storecode='" & Trim(SUBSTORECODE) & "'"
                                        gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                        If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                                            sqlstring = "UPDATE SUBSTORECONSUMPTIONDETAIL SET DOCDate = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 3
                                            sqlstring = sqlstring & ",STORELOCATIONcode='" & Trim(SUBSTORECODE) & "'"
                                            sqlstring = sqlstring & ",STORELOCATIONNAME='" & STORELOCATION(Trim(SUBSTORECODE)) & "'"
                                            sqlstring = sqlstring & ",ItemCode='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & ",ItemNAME='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "'"
                                            sqlstring = sqlstring & ",Uom= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                            sSGrid.Col = 5
                                            sqlstring = sqlstring & ",Qty= " & Val(sSGrid.Text) & ""
                                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                            sqlstring = sqlstring & ",RATE= " & AVGRATE & ""
                                            sSGrid.Col = 5
                                            sSGrid.Row = i
                                            dblCalqty = Val(sSGrid.Text)
                                            sqlstring = sqlstring & ",AMOUNT= " & dblCalqty * AVGRATE & ""
                                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                            sqlstring = sqlstring & ",DBLAmt = " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO"))) & ""
                                            sqlstring = sqlstring & ",HIGHRATIO = " & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ""
                                            sqlstring = sqlstring & ",GROUPCODE= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "'"
                                            sqlstring = sqlstring & ",SUBGROUPCODE= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "'"
                                            sSGrid.Col = 12
                                            If Trim(sSGrid.Text) = "1" Then
                                                sqlstring = sqlstring & ",VOID='Y'"
                                            Else
                                                sqlstring = sqlstring & ",VOID='N'"
                                            End If

                                            sqlstring = sqlstring & ",UpdATEuser = '" & Trim(gUsername) & "',Updatetime = '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
                                            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_KOTno.Text) & "' AND STORELOCATIONCODE='" & Trim(SUBSTORECODE) & "' "
                                            sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 22
                                            'sqlstring = sqlstring & " AND QTY=" & Val(ssGrid.Text)

                                            ReDim Preserve Insert(Insert.Length)
                                            Insert(Insert.Length - 1) = sqlstring
                                        End If
                                    End If
                                End If
                                '********************************************************************************************
                                Gridbool = True
                                Exit For
                            Else
                                Gridbool = False
                            End If
                        Next i


                        If Gridbool = False Then
                            'REFERINVENTORY******************UPDATING STOCK FOR DELETION*****************************
                            Dim KOTDETAILS_DEL, ITEMCODE_DEL, UOM_DEL, POSCODE_DEL As String
                            sqlstring = "SELECT KOTDETAILS,ITEMCODE,UOM,POSCODE FROM KOT_DET WHERE AUTOID=" & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & " "
                            gconnection.getDataSet(sqlstring, "KOTDETAILS")
                            If gdataset.Tables("KOTDETAILS").Rows.Count > 0 Then
                                KOTDETAILS_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("kotdetails")
                                ITEMCODE_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("ITEMCODE")
                                UOM_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("UOM")
                                POSCODE_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("POSCODE")
                            End If

                            Dim SUBSTORECODE As String

                            sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & POSCODE_DEL & "' AND ISNULL(FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "STOREMASTER1")
                            If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                                sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                                sqlstring = sqlstring & " ITEMCODE='" & ITEMCODE_DEL & "' AND ITEMUOM='" & UOM_DEL & "' AND ISNULL(VOID,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "BOM")
                                If gdataset.Tables("BOM").Rows.Count > 0 Then
                                    For K = 0 To gdataset.Tables("BOM").Rows.Count - 1


                                        sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(STRPOSCODE) & "' AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE")) & "'"
                                        gconnection.getDataSet(sqlstring, "SUBSTORE")
                                        If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                            SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                        Else
                                            SUBSTORECODE = STRPOSCODE
                                        End If

                                        sqlstring = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE "
                                        sqlstring = sqlstring & " DOCDETAILS='" & KOTDETAILS_DEL & "'"
                                        sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                        sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                        sqlstring = sqlstring & " AND STORELOCATIONCODE='" & SUBSTORECODE & "'"
                                        'sqlstring = sqlstring & " AND QTY=" & (CDbl(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("QTY")) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")))
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    Next K
                                Else

                                    sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(STRPOSCODE) & "' AND ITEMCODE='" & ITEMCODE_DEL & "'"
                                    gconnection.getDataSet(sqlstring, "SUBSTORE")
                                    If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                        SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                    Else
                                        SUBSTORECODE = STRPOSCODE
                                    End If

                                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                    sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                    sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                                    sqlstring = sqlstring & " WHERE I.ITEMCODE='" & ITEMCODE_DEL & "' AND I.STOCKUOM='" & UOM_DEL & "' AND ISNULL(FREEZE,'') <> 'Y'"
                                    gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                    If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                                        sqlstring = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE "
                                        sqlstring = sqlstring & " DOCDETAILS='" & KOTDETAILS_DEL & "'"
                                        sqlstring = sqlstring & " AND ITEMCODE='" & ITEMCODE_DEL & "'"
                                        sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                        sqlstring = sqlstring & " AND STORELOCATIONCODE='" & SUBSTORECODE & "'"
                                        '  sqlstring = sqlstring & " AND QTY=" & CDbl(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("QTY"))
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    End If
                                End If
                            End If
                            '****************************************************************************************
                            sqlstring = "DELETE FROM KOT_DET WHERE autoid= " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) & " "
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring

                            ReDim Preserve Update2(Update2.Length)
                            Update2(Update2.Length - 1) = Replace(sqlstring, "KOT_DET", " " & vOutfile & " ")


                        End If
                        '''******************************************************** COMPLETE KOT_DET *********************************************************'''
                    Next Z

                End If
                For i = 1 To sSGrid.DataRowCnt
                    sSGrid.Row = i
                    sSGrid.Col = 18
                    If Val(sSGrid.Text) = 0 Then
                        sqlstring = "INSERT INTO KOT_DET(KotNo,KOTdetails,KotDate,Billdetails,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,PackAmt,DiscAmt,BillAmt,ChkId,MKOTNO,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGROUPCODE,"
                        sqlstring = sqlstring & "Openfacilityst,Promotionalst,Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,KOTStatus,Delflag,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA) "
                        If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                            sqlstring = sqlstring & " VALUES('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & doctype & "','" & Trim(cbo_PaymentMode.Text) & "',"
                        Else
                            sqlstring = sqlstring & " VALUES('" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & doctype & "','" & Trim(cbo_PaymentMode.Text) & "',"
                        End If

                        If BILLROUNDYESNO = "YES" Then
                            sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & "," & Val(Me.txt_TableNo.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_Discount.Text) & "," & Math.Round(Val(0)) & "," & Val(Me.txt_MemberCode.Tag) & ""
                        Else
                            sqlstring = sqlstring & " '" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & "," & Val(Me.txt_TableNo.Text) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_Discount.Text) & "," & Val(0) & "," & Val(Me.txt_MemberCode.Tag) & ""
                        End If
                        sSGrid.Row = i
                        sSGrid.Col = 1
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 2
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 3
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 4
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 5
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 6
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 7
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        POS_RATE_GBL = Val(sSGrid.Text)
                        sSGrid.Col = 8
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 9
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 10
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 11
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 12
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & " "
                        sSGrid.Col = 14
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 15
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 16
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 17
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 19
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 20
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 10
                        If Trim(sSGrid.Text) = "BAR" Then
                            sqlstring = sqlstring & ",'','Y'"
                        ElseIf Trim(sSGrid.Text) = "SD" Then
                            sqlstring = sqlstring & ",'SALES','S'"
                        Else
                            sqlstring = sqlstring & ",'SALES','N'"
                        End If
                        sqlstring = sqlstring & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                        sSGrid.Col = 13
                        If Trim(sSGrid.Text) = "Yes" Then
                            sqlstring = sqlstring & ",'Y','N','','','')"
                        Else
                            sqlstring = sqlstring & ",'N','N','','','')"
                        End If
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring

                        ReDim Preserve Update2(Update2.Length)
                        Update2(Update2.Length - 1) = Replace(sqlstring, "KOT_DET", " " & vOutfile & " ")


                        ''REFERINVENTORY*************************UPDATING STOCK***********************************************

                        sSGrid.Row = i
                        sSGrid.Col = 3
                        POSLOCATION = Trim(sSGrid.Text)

                        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POScode) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                        gconnection.getDataSet(sqlstring, "STOREMASTER1")
                        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                            sSGrid.Row = i
                            sSGrid.Col = 1
                            POSITEMCODE = Trim(sSGrid.Text)

                            sSGrid.Row = i
                            sSGrid.Col = 4
                            POSITEMUOM = Trim(sSGrid.Text)

                            Dim SUBSTORECODE As String

                            sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(STRPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
                            gconnection.getDataSet(sqlstring, "SUBSTORE")
                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                            Else
                                SUBSTORECODE = STRPOSCODE
                            End If


                            'AVGRATE = CalAverageRate(Trim(ssGrid.Text))
                            'AVGQUANTITY = CalAverageQuantity(Trim(ssGrid.Text))
                            sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                            sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "BOM")
                            If gdataset.Tables("BOM").Rows.Count > 0 Then
                                For K = 0 To gdataset.Tables("BOM").Rows.Count - 1

                                    sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                                    sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                                    sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                                    sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                                    sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "',"
                                    sSGrid.Col = 5
                                    sSGrid.Row = i
                                    dblCalqty = Val(sSGrid.Text)
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & ","
                                    AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                                    'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                    sqlstring = sqlstring & AVGRATE & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ","
                                    'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT")) & ","
                                    sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ","
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                    sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                    ReDim Preserve Insert(Insert.Length)
                                    Insert(Insert.Length - 1) = sqlstring
                                Next K
                            Else
                                sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                                sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then


                                    sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                                    sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                                    sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                                    sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                                    sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "',"
                                    sSGrid.Col = 5
                                    sSGrid.Row = i
                                    dblCalqty = Val(sSGrid.Text)
                                    sqlstring = sqlstring & dblCalqty & ","
                                    AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                                    'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                    sqlstring = sqlstring & AVGRATE & ","
                                    sqlstring = sqlstring & dblCalqty * AVGRATE & ","
                                    'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                                    sqlstring = sqlstring & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                    sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                    ReDim Preserve Insert(Insert.Length)
                                    Insert(Insert.Length - 1) = sqlstring
                                End If
                            End If
                        End If
                        '******************************************************************************************************
                    End If
                Next i

                'sqlstring = "SELECT ISNULL(TAXCODE,'') AS TAXCODE FROM KOT_DET WHERE KOTDETAILS = '" & Trim(CStr(txt_KOTno.Text)) & "' "
                'gconnection.getDataSet(sqlstring, "KOT_DET")
                'If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                '    sqlstring = "UPDATE BILL_DET SET Billdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',Kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy ") & "',TaxCode = '" & gdataset.Tables("KOT_DET").Rows(0).Item("TAXCODE") & "',TaxAmount= " & Val(txt_TaxValue.Text) & ",Packamount = " & Val(txt_PackingCharge.Text) & ",Discountamount = " & Val(txt_Discount.Text) & ",KotAmount= " & Val(txt_TotalValue.Text) & ",Roundoff = " & Format((Val(txt_BillAmount.Text)) - (Val(txt_TotalValue.Text) + Val(txt_PackingCharge.Text) + Val(txt_TaxValue.Text)), "0.00") & " WHERE KotDetails='" & Trim(Me.txt_KOTno.Text) & "' "
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
            End If
            ''''************************************************** $ BILL SETTLEMENT IF ANY   $ ********************************************'''
            If ssgridPayment1.DataRowCnt = 0 Then
                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                sqlstring = sqlstring & " '" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Trim(cbo_PaymentMode.Text) & "','" & Trim(POScode) & "','" & Trim(paymentaccountcode) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "', "
                sqlstring = sqlstring & " '','','" & Format(Now, "dd-MMM-yyyy") & "','',''," & Format(Val(txt_BillAmount.Text), "0.00") & ", " & Format(Val(txt_BillAmount.Text), "0.00") & ",0,'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N') "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            ElseIf ssgridPayment1.DataRowCnt = 1 Then
                sqlstring = "UPDATE BILLSETTLEMENT SET Billdate ='" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',PaymentMode = '" & Trim(cbo_PaymentMode.Text) & "',poscode = '" & Trim(POScode) & "',PaymentAccountCode = '" & Trim(paymentaccountcode) & "',Mcode = '" & Trim(txt_MemberCode.Text) & "',Mname = '" & Trim(txt_MemberName.Text) & "',"
                sqlstring = sqlstring & " CardType = '', Instrumentno = '',Instrumentdate = '" & Format(Now, "dd-MMM-yyyy") & "',Bankname = '',ReceivedName = '',Payamount= " & Format(Val(txt_BillAmount.Text), "0.00") & ",Billamount = " & Format(Val(txt_BillAmount.Text), "0.00") & ",Balanceamount = 0,UpdateUserid='" & Trim(gUsername) & "',Updatedatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
                sqlstring = sqlstring & " WHERE BillNo = '" & Trim(txt_KOTno.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            Else
                '''**********************************************  $ DELETE FROM BILLSETTLEMENT $ *****************************************'''
                sqlstring = "DELETE FROM  BILLSETTLEMENT WHERE BILLNO =  '" & Trim(CStr(txt_KOTno.Text)) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''**********************************************  $ COMPLETE DELETE BILLSETTLEMENT $ *****************************************'''
                For Z = 1 To ssgridPayment1.DataRowCnt
                    ssgridPayment1.Col = 1
                    ssgridPayment1.Row = Z
                    If Trim(ssgridPayment1.Text) <> "" Then
                        ssgridPayment1.Col = 3
                        ssgridPayment1.Row = Z
                        sqlstring = " SELECT ISNULL(Accountin,'') AS ACCOUNTIN,ISNULL(Paymentcode,'') AS Paymentcode,ISNULL(paymentType,'') AS paymentType  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment1.Text) & "' AND ISNULL(Freeze,'')='N'"
                        gconnection.getDataSet(sqlstring, "paymentmodemaster")
                        If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                            If Trim(ssgridPayment1.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'" & Trim("") & "','" & Trim("") & "','" & Format(Now, "dd-MMM-yyyy") & "','','" & Trim("") & "',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            ElseIf Trim(ssgridPayment1.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'" & Trim("") & "','" & Trim("") & "','" & Format(Now, "dd-MMM-yyyy") & "','" & Trim("") & "','',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Else
                                sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                ssgridPayment1.Row = Z
                                ssgridPayment1.Col = 1
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 2
                                sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                ssgridPayment1.Col = 3
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "','" & Trim(POScode) & "',"
                                sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                ssgridPayment1.Col = 5
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                ssgridPayment1.Col = 6
                                sqlstring = sqlstring & "'" & Trim(ssgridPayment1.Text) & "',"
                                sqlstring = sqlstring & "'','','" & Format(Now, "dd-MMM-yyyy") & "','','',"
                                ssgridPayment1.Col = 4
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 7
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                ssgridPayment1.Col = 8
                                sqlstring = sqlstring & "" & Format(Val(ssgridPayment1.Text), "0.00") & ","
                                sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            End If
                        End If
                    End If
                Next Z
            End If
            '''''************************************************** $ BILL SETTLEMENT COMPLETE   $ ********************************************'''
            sqlstring = "SELECT ISNULL(KOTDETAILS,'') AS KOTDETAILS,KOTDATE,ISNULL(VOUCHERNO,'') AS VOUCHERNO,ISNULL(POSTINGSTATUS,'') As POSTINGSTATUS FROM KOT_HDR  WHERE KOTDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "' AND PAYMENTTYPE <> 'CREDIT'"
            gconnection.getDataSet(sqlstring, "KOTHDR")
            If gdataset.Tables("KOTHDR").Rows.Count > 0 Then
                sqlstring = " UPDATE KOT_HDR SET VOUCHERNO = '',POSTINGSTATUS = 'N' WHERE KOTDETAILS='" & Trim(CStr(gdataset.Tables("KOTHDR").Rows(0).Item("KOTDETAILS"))) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                sqlstring = " UPDATE BILL_JOURNALENTRY SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(gdataset.Tables("KOTHDR").Rows(0).Item("VOUCHERNO"))) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                sqlstring = " UPDATE OUTSTANDING SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(gdataset.Tables("KOTHDR").Rows(0).Item("VOUCHERNO"))) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            End If
            sqlstring = "delete from settlement where billdetails='" & txt_KOTno.Text & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            
            If PAY = "ROOM CHECKIN" Then
                Dim saltype As String
                saltype = doctype

                sqlstring = "delete from roomledger where docno='" & txt_KOTno.Text & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO,salestype)"
                sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','SALES',1," & Val(txt_TotalValue.Text) & ","
                sqlstring = sqlstring & "'" & POScode & "'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','DEBIT','ROOM','RM','RM',1,'" & saltype & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                sqlstring = "delete from roomledgerdtl where docno='" & txt_KOTno.Text & "' and doctype='TAX' AND KOTNO='" & Trim(CStr(txt_KOTno.Text)) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                If Trim(txt_TaxValue.Text) > 0 Then
                    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_TaxValue.Text) & ","
                    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_TaxValue.Text) & ","
                    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
                'If Val(txt_PackingCharge.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_PackingCharge.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','SERTL',1," & Val(txt_PackingCharge.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
                'If Val(Me.txt_tips.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','TIPS',1," & Val(txt_tips.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','TIPS',1," & Val(txt_tips.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
                'If Val(Me.TXT_ACCHG.Text) > 0 Then
                '    sqlstring = "INSERT INTO ROOMLEDGERDTL (Chkno,Docno,DocDate,Doctype,TAXCODE, Foliono,Amount,Poscode,Roomno, SLCODE, ACCOUNTCODE , VOUCHERCATEGORY, CreditDebit,KOTNO)"
                '    'sqlstring = sqlstring & "AddUserid,AddDatetime,VoidStatus,Cancel)"
                '    sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','ACCHG',1," & Val(TXT_ACCHG.Text) & ","
                '    'sqlstring = sqlstring & " Values('" & txt_MemberCode.Tag & "','" & Trim(CStr(KOTno(1))) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','TAX','ACCHG',1," & Val(TXT_ACCHG.Text) & ","
                '    sqlstring = sqlstring & "'RMCH'," & Val(Me.txt_MemberCode.Text) & ",'" & txt_MemberCode.Tag & "','41206','RM','DEBIT','" & Trim(CStr(txt_KOTno.Text)) & "')"
                '    ReDim Preserve Insert(Insert.Length)
                '    Insert(Insert.Length - 1) = sqlstring
                'End If
            End If
            '--------------------ABILASH
            '---------------------
            'Settlement 
            'begin
            'If cbo_PaymentMode.SelectedItem <> "ROOM" Then
            With ssgrid_settlement
                sqlstring = "delete from settlement where billdetails='" & txt_KOTno.Text & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                If .DataRowCnt = 1 Or .DataRowCnt = 0 Then
                    sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,deleteflag,SBILLFLAG) "
                    sqlstring = sqlstring & "VALUES('" & txt_KOTno.Text & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "'," & txt_BillAmount.Text & ",'','N','N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='N' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Else
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,DELETEFLAG,SBILLFLAG) "
                        sqlstring = sqlstring & "VALUES('" & txt_KOTno.Text & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                        .Col = 1
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        .Row = i
                        sqlstring = sqlstring & Math.Round(Val(Trim(.Text)), 2) & ","
                        .Col = 3
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "','N','Y')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Next
                    sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='Y' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
            'End If
            '---------------------
            'Settlement 
            'end

            '-----------------------------------------JOURNAL BEGIN
            'BILL_JOURNALENTRY 
            'begin
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

            sqlstring = " Delete From  BILL_JOURNALENTRY Where voucherno='" & txt_KOTno.Text & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            'TAXCODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART
            sqlstring = "Select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.TaxAMOUNT),0) as Amount,Isnull(B.Acdesc,'') as Acdesc,"
            sqlstring = sqlstring & "Isnull(A.Taxaccountcode,'') as Acctcode From " & vOutfile & "  A,Accountsglaccountmaster B "
            sqlstring = sqlstring & "Where Isnull(delFlag,'')<>'Y'  And A.TAXAccountcode=b.Accode "
            sqlstring = sqlstring & "And Isnull(Billdetails,'')='" & txt_KOTno.Text & "' "
            sqlstring = sqlstring & "Group by A.Taxaccountcode,A.billdetails,B.Acdesc "
            gconnection.getDataSet(sqlstring, "JrnTax")
            Jnltaxamount = 0
            If (gdataset.Tables("JrnTax").Rows.Count > 0) Then
                For K = 0 To gdataset.Tables("JrnTax").Rows.Count - 1
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                    Jnltaxamount = Jnltaxamount + Val(gdataset.Tables("Jrntax").Rows(K).Item("Amount"))
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End If
            'ACCOUNTS CODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART
            sqlstring = "select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.AMOUNT),0) as Amount,"
            sqlstring = sqlstring & "Isnull(A.SalesAccountcode,'') as AcctCode,Isnull(B.Acdesc,'') as Acdesc From  " & vOutfile & " A, "
            sqlstring = sqlstring & "Accountsglaccountmaster B Where Isnull(A.delFlag,'')<>'Y' "
            sqlstring = sqlstring & "And Isnull(A.billdetails,'')='" & txt_KOTno.Text & "'  And A.SalesAccountcode=B.Accode "
            sqlstring = sqlstring & "Group by A.SalesAccountcode,A.billdetails,B.Acdesc "
            gconnection.getDataSet(sqlstring, "JrnAcct")
            If (gdataset.Tables("JrnAcct").Rows.Count > 0) Then
                Jnlamount = 0
                For K = 0 To gdataset.Tables("JrnAcct").Rows.Count - 1
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                    Jnlamount = Jnlamount + Val(gdataset.Tables("JrnAcct").Rows(K).Item("Amount"))
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                        sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                        sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                        sqlstring = sqlstring & Trim(STMcode) & "','',"

                        sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                        sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Next
                Else
                    strBatchNo = strBatchNo + 1
                    sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                    sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Mid(Trim(txt_KOTno.Text), 1, 3) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                    sqlstring = sqlstring & Trim(txt_MemberCode.Text) & "','" & txt_MemberName.Text & "',"
                    sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                    sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, 3) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
            sqlstring = " Drop Table  " & vOutfile
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
          
            If Trim(txt_card_id.Text) = "" And PAY = "SMART CARD" Then
                MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lbl_SwipeCard.Visible = True
                txt_card_id.Focus()
                '                lbl_SwipeCard.Focus()
                Exit Sub
            Else
                If cbo_PaymentMode.Text = "SMART CARD" Then
                    Call cardcheck()
                End If
            End If
            Dim LastBal As Double
            If PAY = "SMART CARD" Then
                Dim STRSQL As String
                SSTR = "SELECT * FROM SM_POSTRANSACTION WHERE BILL_NO='" & Trim(txt_KOTno.Text) & "' and isnull(void,'')<>'y'"
                gconnection.getDataSet(SSTR, "SM_POSTRANSACTION")
                If gdataset.Tables("SM_POSTRANSACTION").Rows.Count > 0 Then
                    LastBal = gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("DEDUCT_FROM_card")
                End If

                If MIN_USAGE_BALANCE_HDR >= Val(BILLAMT_GBL) Then

                    STRSQL = " update SM_POSTRANSACTION set void='Y' where BILL_NO='" & Trim(txt_KOTno.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & "01" & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & Val(txt_BillAmount.Text) & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & Val(BILLAMT_GBL) & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                ElseIf MIN_USAGE_BALANCE_HDR <= 0 Then
                    'DEDUCT AMOUNT ONLY FROM CARD

                    Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                    DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR
                    'to be test
                    '29/06/2010

                    DEDUCT_FROM_CARD = Val(BILLAMT_GBL) - (MIN_USAGE_BALANCE_HDR + Val(LastBal))

                    STRSQL = " update SM_POSTRANSACTION set void='Y' where BILL_NO='" & Trim(txt_KOTno.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                    If Val(DEDUCT_FROM_CARD) < 0 Then
                        STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE+" & Math.Abs(DEDUCT_FROM_CARD) & " WHERE CARDCODE='" & cardcode & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = STRSQL
                    Else
                        STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = STRSQL
                    End If

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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                    'END


                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE,DEDUCT_FROM_card) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & "01" & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & Val(BILLAMT_GBL) & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','FC'," & Val(BILLAMT_GBL) & ")"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                ElseIf MIN_USAGE_BALANCE_HDR > 0 And MIN_USAGE_BALANCE_HDR < Val(txt_BillAmount.Text) Then

                    Dim DEDUCT_FROM_MINUSAGE, DEDUCT_FROM_CARD As Double
                    DEDUCT_FROM_MINUSAGE = MIN_USAGE_BALANCE_HDR

                    'to be test
                    '29/06/2010
                    DEDUCT_FROM_CARD = Val(txt_BillAmount.Text) - (MIN_USAGE_BALANCE_HDR + Val(LastBal))

                    'DEDUCT_FROM_CARD = Val(txt_BillAmount.Text) - MIN_USAGE_BALANCE_HDR

                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & "01" & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & DEDUCT_FROM_MINUSAGE & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL


                    STRSQL = " INSERT INTO SM_POSTRANSACTION ([16_DIGIT_CODE],CARDCODE,POSCODE,POSDATE,FROM_DATE,TO_DATE,FROM_TIME,TO_TIME,DURATION,BILL_NO,BILL_AMOUNT,ADDDATETIME,ADDUSERID,VOID,REMARKS,DEDUCT_TYPE) VALUES ( '" & txt_card_id.Text & "','" & cardcode & "','" & "01" & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','','','','','','" & Trim(txt_KOTno.Text) & "'," & DEDUCT_FROM_CARD & ",'" & Format(Now, "dd/MMM/yyy HH:mm") & "','" & Trim(gUsername) & "','N','" & Trim(Txt_Remarks.Text) & "','HC')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET MIN_USG_BALANCE = MIN_USG_BALANCE -" & DEDUCT_FROM_MINUSAGE & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL

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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                    'END

                    STRSQL = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE-" & DEDUCT_FROM_CARD & " WHERE CARDCODE='" & cardcode & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = STRSQL
                End If
            End If

            StrSql = "DELETE FROM KOT_DET_TAX WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' "
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = StrSql

            For i = 1 To sSGrid.DataRowCnt
                Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                With sSGrid
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 7
                    .Row = i
                    GrdRate = .Text
                    .Col = 6
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 4
                    .Row = i
                    Pos = Trim(.Text)
                    .Col = 13
                    .Row = i
                    KStatus = Mid(Trim(.Text), 1, 1)
                    .Col = 10
                    .Row = i
                    ChargeCode = Trim(.Text)
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    gconnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    gconnection.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                            StrSql = "INSERT INTO KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                            StrSql = StrSql & "'" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(CMB_BTYPE.Text) & "','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(Pos) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ","

                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                StrSql = StrSql & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                StrSql = StrSql & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                StrSql = StrSql & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                StrSql = StrSql & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                StrSql = StrSql & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                StrSql = StrSql & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                StrSql = StrSql & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                StrSql = StrSql & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                StrSql = StrSql & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                StrSql = StrSql & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                StrSql = StrSql & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                StrSql = StrSql & "" & Val(ThreeB) * Qty & ","
                            End If
                            StrSql = StrSql & "'" & Trim(gUsername) & "',getdate(),'N','')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = StrSql
                        Next
                    End If
                End With
            Next
            For i = 1 To sSGrid.DataRowCnt
                With sSGrid
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 6
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 9
                    .Row = i
                    GAmt = Val(.Text)
                    If gCenterlized = "Y" Then
                        TPackAmt = Val((GAmt * gPackPer) / 100)
                        TTipsAmt = Val((GAmt * gTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * gRoomPer) / 100)
                            RoomPer = gRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    Else
                        TPackAmt = Val((GAmt * pPackPer) / 100)
                        TTipsAmt = Val((GAmt * pTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * pRoomPer) / 100)
                            RoomPer = pRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    End If
                    If gCenterlized = "Y" Then
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Else
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTransold(Insert)

            'sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'StrUpdate(0) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE BILL_DET SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE BILL_DET SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_DET SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE BILL_HDR SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE BILL_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE BILL_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE GROUP BY KOTDETAILS,ITEMCODE)"
            'sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL1")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL2")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            ''sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_HDR SET TotalTax = TAXAMT,Total = TOTAMT,BillAmount = BILLAMT FROM KOT_DET K ,KOT_HDR H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE BILL_DET SET TAXAMOUNT = TAXAMT,KOTAMOUNT = TOTAMT FROM KOT_DET K ,BILL_DET H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE BILL_HDR SET TAXAMOUNT = TAXAMT,BILLAMOUNT = TOTAMT FROM KOT_DET K ,BILL_HDR H WHERE K.BILLDETAILS = H.BILLDETAILS AND K.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = 0 WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            StrUpdate(0) = sqlstring

            sqlstring = "UPDATE KOT_DET SET PACKAMOUNT = (AMOUNT * PACKPERCENT)/100,TipsAmt = (AMOUNT * TipsPer)/100,AdCgsAmt = (AMOUNT * AdCgsPer) /100,PartyAmt = (AMOUNT *PartyPer) / 100, RoomAmt = (AMOUNT * RoomPer)/100  WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE  GROUP BY KOTDETAILS,ITEMCODE)"
            sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'  AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL1")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL2")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0)+ISNULL(SUM(KOT_DET.PACKAMOUNT),0)+ISNULL(SUM(KOT_DET.TipsAmt),0)+ISNULL(SUM(KOT_DET.AdCgsAmt),0)+ISNULL(SUM(KOT_DET.PartyAmt),0)+ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_DET SET PACKAMOUNT = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_DET SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE BILL_DET SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE BILL_HDR SET Packamount = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE BILL_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY BILLDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_DET SET KOTAMOUNT = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = BILL_DET.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE BILL_HDR SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE BILL_HDR SET BILLAMOUNT = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.BILLDETAILS = BILL_HDR.BILLDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE BILL_HDR.BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring


            gconnection.MoreTrans1(StrUpdate)

            sqlstring = "UPDATE KOT_DET SET CATEGORY =isnull(A.CATEGORY,'') FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'and isnull(KOT_DET.CATEGORY,'') =''"
            gconnection.dataOperation(9, sqlstring, "CAT")

            sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT")

            sqlstring = "UPDATE KOT_DET SET POSCODE='" & Trim(POScode) & "' where category='BAR'and KOTDETAILS='" & Trim(txt_KOTno.Text) & "' and poscode='" & Trim(POScode) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT1")

            sqlstring = "UPDATE substoreconsumptiondetail SET storelocationcode='" & Trim(POScode) & "' where docDETAILS='" & Trim(txt_KOTno.Text) & "' and storelocationcode='" & Trim(POScode) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT1")

            If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                'Call Cmd_Print_Click(Cmd_Print, e)
                Call Cmd_Clear_Click(sender, e)
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
    End Sub
    Function cardcheck()
        Dim SQLSTRING As String
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
            If cbo_PaymentMode.Text = "SMART CARD" Then
                MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lbl_SwipeCard.Visible = True
                txt_card_id.Focus()
                '                lbl_SwipeCard.Focus()
                Exit Function
            End If
        End If

        SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "' "
        gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
        If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
            'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
            Dim temp_flag As Char
            temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
            If temp_flag <> "Y" Then
                MessageBox.Show("Sorry!  Your Card Not Activated. " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txt_card_id.Clear()
                txt_card_id.Focus()
                '                lbl_SwipeCard.Focus()
                Exit Function
            End If
            'DISPLAY BALNACE AMOUNT
            BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE")), "0.00")
            ' MIN_USAGE_BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MIN_USG_BALANCE")), "0.00")

        Else
            MessageBox.Show("Sorry! CARD EXPIRED " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK)
        End If
    End Function

    Private Sub cmd_KOTnoHelp_Click(sender As Object, e As EventArgs) Handles cmd_KOTnoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(KOTDETAILS,'') AS KOTDETAILS,ISNULL(MCODE,'') AS MCODE,ISNULL(SERVERCODE,'') AS SERVERCODE,ISNULL(MNAME,'') AS MNAME,Convert(varchar, KOTDATE,100) AS KOTDATE  FROM KOT_HDR "
        If Trim(txt_MemberCode.Text) <> "" Then
            M_WhereCondition = " WHERE ISNULL(MANUALBILLSTATUS,'')='Y' AND ISNULL(DELFLAG,'') <> 'Y' AND CAST(CONVERT(CHAR(39),KOTDATE,106) AS DATETIME)='" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND MCODE='" & Trim(txt_MemberCode.Text) & "' AND DOCTYPE = '" & Trim(doctype) & "'"
        Else
            M_WhereCondition = " WHERE ISNULL(MANUALBILLSTATUS,'')='Y' AND ISNULL(DELFLAG,'') <> 'Y' AND DOCTYPE = '" & Trim(doctype) & "'"
        End If

        vform.Field = " KOTDETAILS,MCODE,SERVERCODE,KOTDATE "
        'vform.vFormatstring = "            BILL NO            |  MCODE   | SERVER CODE |    SERVER NAME      |    MNAME           |      KOT DATE     |   REMARKS    | "
        vform.vCaption = "KOT DETAILS HELP"
        'vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_KOTno.Text = Trim(vform.keyfield & "")
            Call txt_KOTno_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_KOTno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_KOTno.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmd_KOTnoHelp.Enabled = True Then
                Search = Trim(txt_KOTno.Text)
                Call cmd_KOTnoHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_KOTno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_KOTno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_KOTno.Text) = "" Then
                Call cmd_KOTnoHelp_Click(cmd_KOTnoHelp, e)
            Else
                Call txt_KOTno_Validated(sender, e)
                If Me.txt_TableNo.Text = "" And txt_TableNo.ReadOnly = False Then
                    txt_TableNo.Focus()
                Else
                    Me.cbo_PaymentMode.Focus()
                End If

                Show()
            End If
        End If
    End Sub

    Private Sub txt_KOTno_Validated(sender As Object, e As EventArgs) Handles txt_KOTno.Validated
        Dim j, i As Integer
        Dim vString, sqlstring, strstring As String
        Dim vTypeseqno As Double
        Dim vGroupseqno As Double
        Dim sum As Double
        Dim dt As New DataTable
        If Trim(txt_KOTno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(SMARTBILL,'') AS SMARTBILL,ISNULL(PACKAMT,0) as PACKAMT,ISNULL(DISCOUNTAMT,0) as DISCOUNTAMT,ISNULL(MR_FLAG,'') AS MR_FLAG,* "
                sqlstring = sqlstring & " FROM KOT_HDR H"
                sqlstring = sqlstring & " LEFT OUTER JOIN  RECEIPT_DETAILS R"
                sqlstring = sqlstring & " ON H.KOTDETAILS=R.BILLNO  WHERE H.KOTNO='" & Format(Val(txt_KOTno.Text), "000000") & "'  AND H.DOCTYPE ='" & Trim(doctype) & "' OR H.KOTDETAILS='" & Trim(txt_KOTno.Text) & "' AND H.DOCTYPE ='" & Trim(doctype) & "'"
                gconnection.getDataSet(sqlstring, "KOT_HDR")
                If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
                Else
                    sqlstring = " SELECT KOTTYPE FROM POSSETUP"
                    gconnection.getDataSet(sqlstring, "KOT")
                    If gdataset.Tables("KOT").Rows.Count > 0 Then
                        If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                            sqlstring = "SELECT ISNULL(SMARTBILL,'') AS SMARTBILL,ISNULL(PACKAMT,0) as PACKAMT,ISNULL(DISCOUNTAMT,0) as DISCOUNTAMT,ISNULL(MR_FLAG,'') AS MR_FLAG,* "
                            sqlstring = sqlstring & " FROM KOT_HDR H"
                            sqlstring = sqlstring & " LEFT OUTER JOIN  RECEIPT_DETAILS R"
                            sqlstring = sqlstring & " ON H.KOTDETAILS=R.BILLNO  WHERE H.KOTNO='" & Val(txt_KOTno.Text) & "'   OR H.KOTDETAILS='" & Trim(txt_KOTno.Text) & "' "
                            gconnection.getDataSet(sqlstring, "KOT_HDR")
                            If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
                                CMB_BTYPE.Text = gdataset.Tables("KOT_HDR").Rows(0).Item("DOCTYPE")
                                Call Me.CMB_BTYPE_KeyPress(sender, e)
                            End If
                            sqlstring = "SELECT ISNULL(SMARTBILL,'') AS SMARTBILL,ISNULL(PACKAMT,0) as PACKAMT,ISNULL(DISCOUNTAMT,0) as DISCOUNTAMT,ISNULL(MR_FLAG,'') AS MR_FLAG,* "
                            sqlstring = sqlstring & " FROM KOT_HDR H"
                            sqlstring = sqlstring & " LEFT OUTER JOIN  RECEIPT_DETAILS R"
                            sqlstring = sqlstring & " ON H.KOTDETAILS=R.BILLNO  WHERE H.KOTNO='" & Val(txt_KOTno.Text) & "'  AND H.DOCTYPE ='" & Trim(doctype) & "' OR H.KOTDETAILS='" & Trim(txt_KOTno.Text) & "' AND H.DOCTYPE ='" & Trim(doctype) & "'"
                            gconnection.getDataSet(sqlstring, "KOT_HDR")
                        End If
                    End If
                End If
                '''************************************************* SELECT record from KOT_HDR *********************************************''''                
                If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
                    '-------------only Aministrator can edit the bill with out card.-------------------------
                    If gUserCategory <> "S" Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("PAYMENTTYPE")) = "SMART CARD" And Trim(txt_card_id.Text) = "" Then
                            MessageBox.Show("THIS IS SMART CARD BILL KINDLY! SWIPE THE CARD TO EDIT KOT..... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Cmd_Add.Enabled = False
                        End If
                    End If
                    '-------------only Aministrator can edit the bill with out card.-------------------------
                    Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_KOTno.ReadOnly = True
                    If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("CroStatus") = False Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroStatus")) = "Y" Then
                            Me.Cmd_Add.Enabled = False
                        End If
                    End If
                    If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("BillStatus") = False Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("BillStatus")) = "ST" Then
                            Me.Lbl_Bill.Visible = True
                            If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("CroStatus") = True Then
                                Me.Lbl_Bill.Text = "BILL GENERATED"
                            Else
                                If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroStatus")) = "N" Then
                                    Me.Lbl_Bill.Text = "BILL GENERATED"
                                Else
                                    Me.Lbl_Bill.Text = "MRP/CRO GENERATED"
                                    'lblCro.Visible = True
                                    'lblCro1.Visible = True
                                    'Me.lblCro.Text = Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroNO"))
                                    ' Call disablecontrols()
                                    Call CROGRIDLOCK()
                                End If
                            End If
                        Else
                            Me.Lbl_Bill.Visible = True
                            Me.Lbl_Bill.Text = "BILL GENERATED"
                        End If
                    Else
                        Me.Lbl_Bill.Visible = True
                        Me.Lbl_Bill.Text = "BILL GENERATED"
                    End If

                    If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("DELFLAG")) = "Y" Then
                        'grp_paydet.Visible = False
                        Me.Lbl_Bill.Text = "BILL DELETED"
                        ' Call disablecontrols()
                        Call CROGRIDLOCK()
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Delete.Enabled = False
                        Me.cmd_BillSettlement.Enabled = False
                    End If
                    KOT_Timer.Enabled = False

                    dtp_KOTdate.Value = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("KOTDATE")), "dd-MMM-yyyy")
                    txt_KOTTime.Text = Format(gdataset.Tables("KOT_HDR").Rows(0).Item("adddatetime"), "HH:mm:ss")
                    'txt_KOTTime.Text = Format(gdataset.Tables("KOT_HDR").Rows(0).Item("KOTDATE"), "hh:mm:ss")
                    txt_KOTno.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("KOTDETAILS") & "")
                    txt_TableNo.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("tableno") & "")
                    txt_Cover.Text = Val(gdataset.Tables("KOT_HDR").Rows(0).Item("Covers"))
                    txt_ServerCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerCode") & "")
                    txt_ServerName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerName") & "")
                    txt_Holder_Code.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERCODE") & "")
                    Txt_holder_name.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERNAME") & "")
                    cardcode = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERCODE") & "")
                    txt_card_id.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("16_digit_code") & "")
                    txt_TotalValue.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("Total")), "0.00")
                    txt_TaxValue.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("TotalTax")), "0.00")
                    Txt_Charges.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("PackAmt")) + Val(gdataset.Tables("KOT_HDR").Rows(0).Item("TipsAmt")) + Val(gdataset.Tables("KOT_HDR").Rows(0).Item("AdCgsAmt")) + Val(gdataset.Tables("KOT_HDR").Rows(0).Item("PartyAmt")) + Val(gdataset.Tables("KOT_HDR").Rows(0).Item("RoomAmt")), "0.00")
                    txt_Discount.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("DiscountAmt")), "0.00")
                    txt_BillAmount.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("BillAmount")) - Val(gdataset.Tables("KOT_HDR").Rows(0).Item("DiscountAmt")), "0.00")
                    cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                    cbo_PaymentMode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType") & "")
                    Txt_Remarks.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Remarks") & "")
                    If gdataset.Tables("KOT_HDR").Rows(0).IsNull("Subpaymentmode") = False Then
                        If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Subpaymentmode") & "") <> "" Then
                            Call FillSubPaymentMode(Trim(gdataset.Tables("KOt_HDR").Rows(0).Item("PaymentType") & ""))
                            sqlstring = "SELECT SUBPAYMENTNAME,SUBPAYMENTCODE FROM SUBPAYMENTMODE WHERE SUBPAYMENTCODE = '" & Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Subpaymentmode")) & "' "
                            gconnection.getDataSet(sqlstring, "SUBPAYMENTMODE")
                            If gdataset.Tables("SUBPAYMENTMODE").Rows.Count = 1 Then
                                cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                                Me.cbo_SubPaymentMode.Text = Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTCODE") & "-" & Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTNAME")))
                                cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
                            End If
                        End If
                    End If
                    If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType")) = "ROOM" Then
                        txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ROOMNO")) & ""
                        txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("GUEST")) & ""
                        txt_MemberCode.Tag = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CHECKIN")) & ""
                    Else
                        Try
                            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "ROOM CHECKIN" Then
                                    txt_MemberCode.Visible = True
                                    txt_MemberName.Visible = True
                                    lbl_Membercode.Visible = True
                                    lbl_MemberName.Visible = True
                                    cmd_MemberCodeHelp.Visible = True
                                    lbl_Membercode.Text = "MEMBER CODE :"
                                    lbl_MemberName.Text = "MEMBER NAME :"
                                    txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("roomno")) & ""
                                    txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("guest")) & ""
                                    txt_MemberCode.Tag = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CHECKIN")) & ""

                                    'If cbo_PaymentMode.Text <> "STAFF" Then
                                    '    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                                    'End If

                                ElseIf Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) <> "SMART CARD" Then
                                    '''txt_MemberCode.Visible = False
                                    '''txt_MemberName.Visible = False
                                    '''lbl_Membercode.Visible = False
                                    '''lbl_MemberName.Visible = False
                                    '''cmd_MemberCodeHelp.Visible = False
                                    '''txt_MemberCode.Text = ""
                                    '''txt_MemberName.Text = ""
                                    txt_MemberCode.Visible = True
                                    txt_MemberName.Visible = True
                                    lbl_Membercode.Visible = True
                                    lbl_MemberName.Visible = True
                                    cmd_MemberCodeHelp.Visible = True
                                    lbl_Membercode.Text = "MEMBER CODE :"
                                    lbl_MemberName.Text = "MEMBER NAME :"
                                    txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("MCode")) & ""
                                    txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Mname")) & ""
                                    If cbo_PaymentMode.Text <> "STAFF" Then
                                        gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                                    End If

                                Else
                                    txt_MemberCode.Visible = True
                                    txt_MemberName.Visible = True
                                    lbl_Membercode.Visible = True
                                    lbl_MemberName.Visible = True
                                    cmd_MemberCodeHelp.Visible = True
                                    lbl_Membercode.Text = "MEMBER CODE :"
                                    lbl_MemberName.Text = "MEMBER NAME :"
                                    txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("MCode")) & ""
                                    txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Mname")) & ""
                                    If cbo_PaymentMode.Text <> "STAFF" Then
                                        gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                                    End If
                                End If
                            Else
                                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            End If
                        Catch ex As Exception
                            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If

                    '''************************************************* SELECT record from KOT_DET *********************************************''''                

                    sqlstring = "SELECT ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(PACKPERCENT,0) AS PACKPERCENT,"
                    sqlstring = sqlstring & " ISNULL(PACKAMOUNT,0) AS PACKAMOUNT,ISNULL(OPENFACILITYST,0) AS OPENFACILITYST,ISNULL(PROMOTIONALST,0) AS PROMOTIONALST,ISNULL(PACKACCOUNTCODE,'') AS PACKACCOUNTCODE,* FROM KOT_DET WHERE  KOTDETAILS='" & Trim(txt_KOTno.Text) & "' ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "KOT_DET")
                    If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("KOT_DET").Rows.Count
                            sSGrid.SetText(1, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("MKOTNO")) & "")
                            sSGrid.SetText(2, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemCode")) & "")
                            sSGrid.SetText(3, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("itemdesc")) & "")
                            sSGrid.SetText(4, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("poscode")))
                            sSGrid.SetText(5, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("UOM")))
                            sSGrid.SetText(6, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            sSGrid.SetText(7, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Rate")), "0.00"))
                            sSGrid.SetText(8, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Taxamount")), "0.00"))
                            sSGrid.SetText(9, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Amount")), "0.00"))
                            sSGrid.SetText(10, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemType")) & "")
                            sSGrid.SetText(11, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxCode")) & "")
                            sSGrid.SetText(12, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("TaxPerc")))
                            sSGrid.SetText(14, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxAccountCode")))
                            sSGrid.SetText(15, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("SalesAccountCode")))
                            sSGrid.SetText(16, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("GroupCode")))
                            sSGrid.SetText(17, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("SUBGroupCode")))
                            sSGrid.SetText(18, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("autoid")), "0.00"))
                            sSGrid.SetText(19, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("Openfacilityst")))
                            sSGrid.SetText(20, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("Promotionalst")))
                            'REFERINVENTORY***********************************************************************
                            sSGrid.SetText(21, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            '*************************************************************************************
                            If CStr(gdataset.Tables("KOT_DET").Rows(j).Item("KOTStatus") & "") = "Y" Then
                                sSGrid.SetText(13, i, "Yes")
                            Else
                                sSGrid.SetText(13, i, "No")
                            End If
                            j = j + 1
                        Next
                    End If
                    'Call Calculate()
                    '''************************************************* SELECT record from BILLSETTLEMENT  *********************************************''''                
                    sqlstring = "SELECT ISNULL(BILLNO,'') AS BILLNO,BILLDATE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(PAYMENTACCOUNTCODE,'') AS PAYMENTACCOUNTCODE,"
                    sqlstring = sqlstring & " ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(CARDTYPE,'') AS CARDTYPE,ISNULL(INSTRUMENTNO,'') AS INSTRUMENTNO,INSTRUMENTDATE,"
                    sqlstring = sqlstring & " ISNULL(BANKNAME,'') AS BANKNAME,ISNULL(RECEIVEDNAME,'') AS RECEIVEDANAME,ISNULL(PAYAMOUNT,0) AS PAYAMOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(BALANCEAMOUNT,0) AS BALANCEAMOUNT  FROM BILLSETTLEMENT WHERE BILLNO = '" & Trim(txt_KOTno.Text) & "' ORDER BY PAYMENTMODE"
                    gconnection.getDataSet(sqlstring, "BILLSETTLEMENT")
                    If gdataset.Tables("BILLSETTLEMENT").Rows.Count > 0 Then
                        j = 0
                        For i = 1 To gdataset.Tables("BILLSETTLEMENT").Rows.Count
                            ssgridPayment1.SetText(1, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLNO")) & "")
                            ssgridPayment1.SetText(2, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLDATE")) & "")
                            Call FillPaymentmodeSettlement(i)
                            ssgridPayment1.SetText(3, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYMENTMODE")))
                            ssgridPayment1.SetText(5, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("MCODE")))
                            ssgridPayment1.SetText(6, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("MNAME")))
                            ssgridPayment1.SetText(4, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYAMOUNT")), "0.00"))
                            ssgridPayment1.SetText(7, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLAMOUNT")), "0.00"))
                            ssgridPayment1.SetText(8, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BALANCEAMOUNT")), "0.00"))
                            ssgridPayment1.Col = 3
                            ssgridPayment1.Row = i
                            sqlstring = " SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE,ISNULL(PAYMENTTYPE,'') AS PAYMENTTYPE  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment1.Text) & "' AND ISNULL(Freeze,'')='N'"
                            gconnection.getDataSet(sqlstring, "paymentmodemaster")
                            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                    'txt_Typeofcard.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("CARDTYPE"))
                                    'txt_Cardno.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTNO"))
                                    'dtp_Expirydate.Value = Format(CDate(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTDATE")), "dd-MMM-yyyy")
                                    'txt_Cardholdername.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYMENTMODE"))
                                ElseIf Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                    'cbo_Typeofcheque.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("CARDTYPE"))
                                    'txt_Chequeno.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTNO"))
                                    'dtp_Chequedate.Value = Format(CDate(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTDATE")), "dd-MMM-yyyy")
                                    'txt_Draweebank.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BANKNAME"))
                                End If
                            End If
                            j = j + 1
                        Next
                    Else
                        ssgridPayment1.ClearRange(1, 1, -1, -1, True)
                    End If
                    TotalItemCount = gdataset.Tables("KOT_DET").Rows.Count
                    Call Fillsettlement()
                    sSGrid.SetActiveCell(1, 1)
                    cbo_PaymentMode.Focus()
                    'txt_TableNo.Focus()
                    Show()
                    cmd_KOTnoHelp.Enabled = False
                    If GSALESACCOUNTCODEIN = "Y" Then
                        strstring = "SELECT * FROM membermaster WHERE MCODE='" & Trim(txt_MemberCode.Text) & "'"
                        gconnection.getDataSet(strstring, "membermaster")
                        If gdataset.Tables("membermaster").Rows.Count > 0 Then
                            txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                            txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            'If File.Exists(AppPath & "\MemberPhotos\" & Trim(txt_MemberCode.Text) & ".Jpg") Then
                            '    PicBoxMemberPhoto.Image = New Bitmap(AppPath & "\MemberPhotos\" & Trim(txt_MemberCode.Text) & ".Jpg")
                            'Else
                            '    PicBoxMemberPhoto.Image = New Bitmap(AppPath & "\MemberPhotos\Image.Jpg")
                            'End If
                        End If
                        'strstring = "EXEC Sp_CreditLimit '" & Trim(txt_MemberCode.Text) & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "'"
                        'gconnection.dataOperation(6, strstring, "CreditLimit")
                        'strstring = "Select Isnull(ClosingBalance,0) as ClosingBalance, Isnull(CreditBalance,0) as CreditBalance from CBalLmt1"
                        'gconnection.getDataSet(strstring, "CreditLimit")
                        'If (gdataset.Tables("CreditLimit").Rows.Count > 0) Then
                        '    txtCreditLimit.Text = Trim(CStr(Format(Val(gdataset.Tables("CreditLimit").Rows(0).Item("CreditBalance")), "0.00")))
                        'End If

                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                Else
                    If Mid(pKotType, 1, 1) = "A" Then
                    Else
                        strstring = "SELECT * FROM KOT_HDR WHERE KOTDETAILS='" & txt_KOTno.Text & "'"
                        gconnection.getDataSet(strstring, "KOTNO")
                        If gdataset.Tables("KOTNO").Rows.Count = 0 Then
                            strstring = " Select isnull(Prefix,'') as Prefix,isnull(Servercode,'') as Servercode From Kotbook "
                            strstring = strstring & "  Where  " & IIf(Val(txt_KOTno.Text) > 0, Val(txt_KOTno.Text), 0) & " between snofrom and  snoto "
                            gconnection.getDataSet(strstring, "servermaster")
                            If gdataset.Tables("servermaster").Rows.Count > 0 Then
                                txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("Servercode")
                                txt_ServerCode_Validated(sender, e)
                                cbo_PaymentMode.Focus()
                                'txt_MemberCode.Focus()
                            Else
                                MessageBox.Show("Kindly Register This Kotbook in System,Thanking You", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                txt_KOTno.Text = ""
                                txt_KOTno.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                    
                End If

                If Me.cbo_PaymentMode.Text = "SMART CARD" Then
                    Me.cbo_PaymentMode.Enabled = False
                End If
                If gUserCategory <> "S" Then
                    bill_closing()
                End If
                If Me.cbo_PaymentMode.Text = "SMART CARD" Then
                    sqlstring = "SELECT [16_DIGIT_CODE]AS CODE FROM  SM_POSTRANSACTION WHERE BILL_NO='" & Trim(txt_KOTno.Text) & "' AND ISNULL(VOID,'')<>'Y'"
                    dt = gconnection.GetValues(sqlstring)
                    If dt.Rows.Count > 0 Then
                        If Trim(dt.Rows(0).Item("CODE")) <> Trim(Me.txt_card_id.Text) Then
                            MsgBox("SORRY PUT THE CORRECT CARD WITH WHICH BILLING DONE")
                            Call Cmd_Clear_Click(Cmd_Clear, e)
                            Exit Sub
                        End If
                    End If
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub CROGRIDLOCK()
        Dim Row, Col As Integer
        ssGrid.Col = 15
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 15
                ssGrid.Row = Row
                ssGrid.Col = Col
                ssGrid.Lock = True
            Next
        Next Row
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
    Private Function Fillsettlement()
        Dim sqlstring, Subpaymentmode() As String
        Dim Billtotal As Double
        kotdetails = ""
        Dim i, j As Integer
        Try
            sqlstring = " SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(BILLDETAILS,'') AS BILLDETAILS,ISNULL(DESCRIPTION,'') AS DESCRIPTION "
            sqlstring = sqlstring & " FROM SETTLEMENT WHERE BILLDETAILS='" & Trim(txt_KOTno.Text) & "' --AND ISNULL(DELETEFLAG,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "SETTLE")
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
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub bill_closing()
        Dim ssql As String
        ssql = "select isnull(accountflag,'')  as Aflag from bill_hdr where billdetails='" & txt_KOTno.Text & "'"
        gconnection.getDataSet(ssql, "Bill")
        If gdataset.Tables("Bill").Rows.Count > 0 Then
            If Trim(gdataset.Tables("Bill").Rows(0).Item("Aflag")) = "Y" Then
                MessageBox.Show("YOU HAVE NO RIGHTS TO EDIT THIS KOT.....", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Cmd_Add.Enabled = False
                cmd_Delete.Enabled = False
                cmd_Delete.Enabled = False
                cmd_BillSettlement.Enabled = False
            End If
        End If
    End Sub
    Private Sub checkvalidate()
        Dim icode, icode1, uom, uom1, Fstart, Fend As String
        Dim taxcode, sqlstring, itemdesc As String
        Dim i, j As Integer
        chkbool = False
        ''**************************************** Assign Account Code Value **********************************************'''

        Dim SSQL As String
        Dim PAY As String
        PAY = ""
        'SMART CARD
        'ROOM CHECKIN
        'MEMBER ACCOUNT
        'BANK INSTRUMENT
        'CASH
        'CLUB ACCOUNT
        'EMPLOYEE

        Dim journdate As Date
        'sqlstring = " SELECT  isnull(max(VOUCHERDATE),'') as VOUCHERDATE FROM Journalentry WHERE VoucherType='MBILL'AND ACCOUNTCODE='SDRS' and '" & Format(Me.dtp_KOTdate.Value, "dd-MMM-yyyy") & "' >= cast(convert(isnull(max(varchar(11),voucherdate,106)))) ORDER BY VoucherDate DESC "
        sqlstring = " select isnull(max(VOUCHERDATE),'') as VOUCHERDATE from journalentry where VoucherType ='MBILL' AND ACCOUNTCODE='" & Trim(gDebitors) & "' "
        gconnection.getDataSet(sqlstring, "journtab")
        If gdataset.Tables("journtab").Rows.Count > 0 Then
            journdate = gdataset.Tables("journtab").Rows(0).Item("VOUCHERDATE")
            If Year(dtp_KOTdate.Value) <= Year(journdate) And Month(dtp_KOTdate.Value) <= Month(journdate) Then
                If DateDiff(DateInterval.Day, Me.dtp_KOTdate.Value, journdate) >= 0 Then
                    Me.dtp_KOTdate.Focus()
                    MessageBox.Show("Sorry Already Month Bill Was Processed...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
        End If


        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"  'CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME)
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        'sqlstring = "select isnull(memcreditlimit,0)as creditlimit from  possetup"
        'gconnection.getDataSet(sqlstring, "climit")
        'If gdataset.Tables("climit").Rows.Count > 0 Then
        '    If gdataset.Tables("climit").Rows(0).Item("creditlimit") > 0 Then
        '        sqlstring = " SELECT TOP 1 isnull(VOUCHERDATE,'') FROM Journalentry WHERE VoucherType='MBILL'AND ACCOUNTCODE='SDRS' AND SLCode='" & Me.txt_MemberCode.Text & "' ORDER BY VoucherDate DESC "
        '        gconnection.getDataSet(sqlstring, "journalentry")
        '        If gdataset.Tables("journalentry").Rows.Count > 0 Then
        '            sqlstring = "exec get_creditlimit'" & Me.txt_MemberCode.Text & "'"
        '            gconnection.ExcuteStoreProcedure(sqlstring)
        '        Else
        '            sqlstring = "exec get_creditlimit_withoutmbill'" & Me.txt_MemberCode.Text & "'"
        '            gconnection.ExcuteStoreProcedure(sqlstring)
        '        End If
        '        sqlstring = "SELECT * FROM balance WHERE MCODE='" & Me.txt_MemberCode.Text & "'"
        '        gconnection.getDataSet(sqlstring, "CRD")
        '        If gdataset.Tables("CRD").Rows.Count > 0 Then
        '            MemberOutstand = gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
        '        Else
        '            MemberOutstand = 0
        '        End If

        '        If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
        '            MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '            If PAY = "MEMBER ACCOUNT" Then
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        'End If

        If SMENTTYPE = "YES" Then
            If SETLEMENT_GROUP.Visible = True Then
                MessageBox.Show("Please Close the Settlement Screen.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid_settlement.Focus()
                Exit Sub
            End If
        End If
        If cbo_PaymentMode.SelectedItem = "ROOM" Then
            accountcode = "RMLDGR"
        ElseIf cbo_PaymentMode.SelectedItem = "CREDIT" Then
            accountcode = Trim(gDebitors)
        ElseIf cbo_PaymentMode.SelectedItem = "SMART CARD" Then
            accountcode = Trim(gDebitors)
        Else
            accountcode = ""
        End If
        '''**************************************** Check Payment Mode can't be blank *******************************************''
        Fstart = "01-APR-" & Trim(gFinancalyearStart)
        Fend = "31-MAR-" & Trim(gFinancialYearEnd)
        If DateDiff(DateInterval.Day, Me.dtp_KOTdate.Value, Now) < 0 Then
            Me.dtp_KOTdate.Focus()
            MessageBox.Show("Billdate can't be greater then today's date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If (Format(Me.dtp_KOTdate.Value, "dd-MMM-yyyy") > Format(Fstart, "dd-MMM-yyyy")) And (Format(Me.dtp_KOTdate.Value, "dd-MMM-yyyy") < Format(Fend, "dd-MMM-yyyy")) Then
            Me.dtp_KOTdate.Focus()
            MessageBox.Show("Voucher Date Should Be Within The Financial Year", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Trim(cbo_PaymentMode.Text) = "" Then
            MessageBox.Show("Payment Mode Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cbo_PaymentMode.Focus()
            Exit Sub
        End If

        Dim K, CCT As Integer
        For j = 1 To ssGrid.DataRowCnt
            Dim ITC
            sSGrid.Col = 2
            ssGrid.Row = j
            ITC = ssGrid.Text
          
            For K = 1 To ssGrid.DataRowCnt
                sSGrid.Col = 2
                ssGrid.Row = K
                If Trim(ssGrid.Text) = ITC Then
                    CCT = CCT + 1
                End If
            Next
            If CCT > 1 Then
                MsgBox("duplicate item entry")
                Exit Sub
            End If
            'End If
            CCT = 0
        Next

        If txt_KOTno.Text = "" Then
            MessageBox.Show("Billno Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_MemberCode.Focus()
            Exit Sub
        End If
        '''**************************************** Check Room No and Member Code can't be blank *******************************************''
        If Trim(txt_MemberCode.Text) = "" Then
            If cbo_PaymentMode.Text = "ROOM" Then
                MessageBox.Show("Room No Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberCode.Focus()
                Exit Sub
            Else
                Try
                    sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                    sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                    If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                        If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) <> "NO" Then
                            MessageBox.Show("Member Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            txt_MemberCode.Focus()
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Catch ex As Exception
                    MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        End If
        '''**************************************** Check Guest Name and Member Name can't be blank *******************************************''
        If Trim(txt_MemberName.Text) = "" Then
            If cbo_PaymentMode.Text = "ROOM" Then
                MessageBox.Show("Guest Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberName.Focus()
                Exit Sub
            Else
                Try
                    sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                    sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                    If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                        If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) <> "NO" Then
                            MessageBox.Show("Member Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            txt_MemberName.Focus()
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Catch ex As Exception
                    MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        End If
        '''**************************************** Check Server Code can't be blank *******************************************''


        'If cbo_PaymentMode.Text = "CREDIT" And Len(Trim(txt_creditfacility)) = 0 Then
        '    MessageBox.Show("This member is not not entitled for Credit facility", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    txt_MemberCode.Focus()
        '    Exit Sub
        'ElseIf cbo_PaymentMode.Text = "N.CREDIT" And Len(Trim(txt_creditfacility)) > 0 Then
        '    MessageBox.Show("This member has the credit Facility. Kindly change the mode of payment", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    txt_MemberCode.Focus()
        '    Exit Sub
        'End If

        If Trim(txt_ServerCode.Text) = "" And txt_ServerCode.ReadOnly = False Then
            MessageBox.Show("Server Code. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_ServerCode.Focus()
            Exit Sub
        End If
        '''**************************************** Check Server Name can't be blank *******************************************''
        If Trim(txt_ServerName.Text) = "" And txt_ServerName.ReadOnly = False Then
            MessageBox.Show("Server Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_ServerName.Focus()
            Exit Sub
        End If
        If Trim(txt_MemberCode.Text) = "" Then
            If cbo_PaymentMode.Text = "ROOM" Then
                MessageBox.Show("Room No Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberCode.Focus()
                Exit Sub
            ElseIf cbo_PaymentMode.Text = "R.MEMBER" Then
                cbo_PaymentMode.Text = "R.MEMBER"
            ElseIf cbo_PaymentMode.Text = "COUPON" Then
                cbo_PaymentMode.Text = "COUPON"
            ElseIf cbo_PaymentMode.Text = "CLUB" Then
                cbo_PaymentMode.Text = "CLUB"
            Else
                MessageBox.Show("Member Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberCode.Focus()
                Exit Sub
            End If
        End If

        '''********************************************* Check ssgrid value can't be blank ********************************************'''
        If ssGrid.DataRowCnt = 0 Then
            MessageBox.Show("!! Sorry !!There is no KOT DETAILS part to be saved", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ssGrid.Focus()
            ssGrid.SetActiveCell(1, 1)
            Exit Sub
        End If
        With ssGrid
            For i = 1 To .DataRowCnt
                If i = 1 Then
                    .Col = 4
                    .Row = i
                    loccode = Trim(.Text)
                End If
                .Col = 19
                .Row = i
                If Trim(.Text) <> "Y" Then
                    .Row = i
                    .Col = 2
                    ITEMCODE = Trim(CStr(ssGrid.Text))
                    .Row = i
                    .Col = 3
                    itemdesc = Trim(CStr(ssGrid.Text))
                    sqlstring = "SELECT ITEMCODE,ITEMDESC FROM ITEMMASTER WHERE Itemcode = '" & Trim(ITEMCODE) & "' AND Itemdesc = '" & Trim(itemdesc) & "'"
                    gconnection.getDataSet(sqlstring, "ITEMMASTER")
                    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                        .Row = i
                        .Col = 2
                        ssGrid.Text = Trim(CStr(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMCODE")))
                        .Row = i
                        .Col = 3
                        ssGrid.Text = Trim(CStr(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMDESC")))
                    Else
                        MessageBox.Show("!!Warning!! Itemcode : " & Trim(ITEMCODE) & " And Itemdesc : " & Trim(itemdesc) & " is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssGrid.Focus()
                        ssGrid.SetActiveCell(1, i)
                        Exit Sub
                    End If
                End If
            Next
        End With
        For i = 1 To ssGrid.DataRowCnt
            ssGrid.Row = i
            sSGrid.Col = 2
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(1, i)
                ssGrid.Focus()
                Exit Sub
            End If
            sSGrid.Col = 3
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Item Description can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(2, i)
                ssGrid.Focus()
                Exit Sub
            End If
            sSGrid.Col = 4
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("POS Location can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(3, i)
                ssGrid.Focus()
                Exit Sub
            End If
            sSGrid.Col = 5
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(4, i)
                ssGrid.Focus()
                Exit Sub
            End If
            sSGrid.Col = 6
            If Val(ssGrid.Text) = 0 Then
                MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(5, i)
                ssGrid.Focus()
                Exit Sub
            End If
            sSGrid.Col = 7
            If Val(ssGrid.Text) = 0 Then
                sSGrid.Row = i - 1
                sSGrid.Col = 19
                Dim var As Object
                sSGrid.GetText(19, i - 1, var)
                If UCase(var) <> "Y" Then
                    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sSGrid.SetActiveCell(6, i)
                    sSGrid.Focus()
                    Exit Sub
                End If
            End If
            sSGrid.Row = i
            sSGrid.Col = 9
            If Val(sSGrid.Text) = 0 Then
                sSGrid.Col = 19
                sSGrid.Row = i - 1
                Dim var As Object
                sSGrid.GetText(19, i - 1, var)
                If UCase(var) <> "Y" Then
                    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sSGrid.SetActiveCell(8, i)
                    sSGrid.Focus()
                    Exit Sub
                End If
            End If
            sSGrid.Row = i
            sSGrid.Col = 9
            If Trim(sSGrid.Text) = "" Then
                MessageBox.Show("Item Type can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                sSGrid.SetActiveCell(9, i)
                sSGrid.Focus()
                Exit Sub
            End If
        Next i
        
        If Cmd_Add.Text = "Update[F7]" And Me.Lbl_Bill.Text = "CRO GENERATED" Then
            If Me.ssGrid.DataRowCnt > TotalItemCount Then
                MessageBox.Show("Specified Billno has been deposited in CRO Counter", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        chkbool = True
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Call checkvalidate() '''---> Check Validation
        If chkbool = False Then Exit Sub
        Dim sqlstring, Delete(0) As String
        Dim dt As New DataTable
        Dim DT1 As New DataTable
        Dim DT2 As New DataTable

        sqlstring = "SELECT ISNULL(CHKID,0)AS CHKID FROM KOT_DET WHERE BILLDETAILS='" & Trim(txt_KOTno.Text) & "'"
        DT1 = gconnection.GetValues(sqlstring)
        If (DT1.Rows.Count > 0) Then
            If DT1.Rows(0).Item("CHKID") <> "0" Then
                sqlstring = "SELECT * FROM ROOMCHECKIN WHERE DOCNO='" & DT1.Rows(0).Item("CHKID") & "' AND ISNULL(CHECKOUT,'')<>'y'"
                DT2 = gconnection.GetValues(sqlstring)
                If (DT2.Rows.Count > 0) Then
                Else
                    MsgBox("Sorry, GUEST ALREADY CHECKED OUT , You Can't Delete....")
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            End If
        End If

        sqlstring = "SELECT * FROM MATCHING WHERE VOUCHERNO = '" & Trim(txt_KOTno.Text) & "' AND VOUCHERDATE = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
        dt = gconnection.GetValues(sqlstring)
        If (dt.Rows.Count > 0) Then
            MsgBox("Sorry, Bill Matching Was Already Made, You Can't Delete....")
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        'End
        If Me.cbo_PaymentMode.Text = "SMART CARD" Then
            sqlstring = "SELECT [16_DIGIT_CODE]AS CODE FROM  SM_POSTRANSACTION WHERE BILL_NO='" & Trim(txt_KOTno.Text) & "' AND ISNULL(VOID,'')<>'Y'"
            dt = gconnection.GetValues(sqlstring)
            If dt.Rows.Count > 0 Then
                If Trim(dt.Rows(0).Item("CODE")) <> Trim(Me.txt_card_id.Text) Then
                    MsgBox("SORRY PUT THE CORRECT CARD WITH WHICH BILLING DONE")
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            End If
        End If
        sqlstring = "SELECT ISNULL(BillStatus,'PO') As BillStatus,ISNULL(Crostatus,'N') As Crostatus,ISNULL(PostingStatus,'N') as PostingStatus FROM Kot_Hdr WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
        dt = gconnection.GetValues(sqlstring)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("PostingStatus") = "Y" Then
                If MsgBox("The KotAmount Is Already Posted To Accounts,Deleting This Kot Also Reflects In Accounts,Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call DeleteOperation()
                    Exit Sub
                Else
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            ElseIf dt.Rows(0).Item("CRostatus") = "Y" Then
                If MsgBox("The KotAmount Is Already Posted To Cro,Deleting This Kot Also Reflects In Cro,Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call DeleteOperation()
                    Exit Sub
                Else
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            Else
                '''************************************** Deleting KOTDETAILS Permently from KOT_HDR ************************************'''
                sqlstring = " UPDATE KOT_HDR SET DELFLAG = 'Y',DELUSER = '" & gUsername & "',DELDATETIME = GETDATE() WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                Delete(0) = sqlstring
                '''************************************************* COMPLETE KOT_HDR ***************************************************'''
                '''************************************** Deleting KOTDETAILS Permently from KOT_DET ************************************'''
                sqlstring = " UPDATE KOT_DET SET DELFLAG = 'Y' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                '''************************************** Deleting item  reason from KOT_DET ************************************'''
                'sqlstring = " UPDATE KOT_DET SET reason = '" & Trim(cmb_CANNAME.Text) & "' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                'ReDim Preserve Delete(Delete.Length)
                'Delete(Delete.Length - 1) = sqlstring
                ' '''************************************** Deleting item  reason from KOT_hdr ************************************'''
                'sqlstring = " UPDATE KOT_hdr SET reason = '" & Trim(cmb_CANNAME.Text) & "' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                'ReDim Preserve Delete(Delete.Length)
                'Delete(Delete.Length - 1) = sqlstring

                'REFERINVENTORY************************************* UPDATING STOCK FOR KOT DELETION **************************************
                sqlstring = " UPDATE SUBSTORECONSUMPTIONDETAIL SET VOID = 'Y' WHERE DOCDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                '***************************************************************************************************************************
                '''************************************************* COMPLETE KOT_HDR ***************************************************'''

                sqlstring = " UPDATE BILL_HDR SET DELFLAG = 'Y' WHERE BILLDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                '''************************************************* COMPLETE KOT_HDR ***************************************************'''
                sqlstring = " UPDATE BILL_DET SET DELFLAG = 'Y' WHERE BILLDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                '''************************************************* COMPLETE BILLSETTLEMENT ***************************************************'''
                sqlstring = " UPDATE BILLSETTLEMENT SET DELFLAG = 'Y' WHERE BILLNO='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                sqlstring = " UPDATE KOT_HDR SET VOUCHERNO = '',POSTINGSTATUS = 'N' WHERE KOTDETAILS='" & txt_KOTno.Text & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                '''************************************************* COMPLETE KOT_HDR ***************************************************'''
                sqlstring = "SELECT ISNULL(KOTDETAILS,'') AS KOTDETAILS,KOTDATE,ISNULL(VOUCHERNO,'') AS VOUCHERNO,ISNULL(POSTINGSTATUS,'') As POSTINGSTATUS FROM KOT_HDR  WHERE KOTDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                gconnection.getDataSet(sqlstring, "KOTHDR")
                If gdataset.Tables("KOTHDR").Rows.Count > 0 Then

                    sqlstring = " UPDATE KOT_HDR SET VOUCHERNO = '',POSTINGSTATUS = 'N' WHERE KOTDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring
                    sqlstring = " UPDATE BILL_JOURNALENTRY SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring
                    sqlstring = " UPDATE OUTSTANDING SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring
                End If

                If cbo_PaymentMode.Text = "SMART CARD" Then
                    sqlstring = "SELECT * FROM  SM_POSTRANSACTION WHERE BILL_NO ='" & Trim(txt_KOTno.Text) & "' and isnull(void,'')<>'y'"
                    gconnection.getDataSet(sqlstring, "SM_POSTRANSACTION")

                    sqlstring = " UPDATE SM_POSTRANSACTION SET VOID ='Y', VOIDUSER='" & gUsername & "' WHERE BILL_NO='" & Trim(txt_KOTno.Text) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring


                    If gdataset.Tables("SM_POSTRANSACTION").Rows.Count > 0 Then
                        sqlstring = " UPDATE SM_CARDFILE_HDR SET BALANCE = BALANCE +" & Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("DEDUCT_FROM_card")) & " WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "'"
                        ReDim Preserve Delete(Delete.Length)
                        Delete(Delete.Length - 1) = sqlstring

                        Dim BALstr, EBAL As String
                        Dim BALnum As Double
                        sqlstring = " SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(txt_card_id.Text) & "' "
                        gconnection.getDataSet(sqlstring, "CARDFILE_HDR_BAL")
                        If gdataset.Tables("CARDFILE_HDR_BAL").Rows.Count > 0 Then
                            If IsDBNull(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) = False Then
                                BALnum = abcdMINUS(gdataset.Tables("CARDFILE_HDR_BAL").Rows(0)("EBALANCE")) + Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("DEDUCT_FROM_card"))
                            Else '--for zero
                                BALnum = 0 - Val(gdataset.Tables("SM_POSTRANSACTION").Rows(0).Item("DEDUCT_FROM_card"))
                            End If
                        End If
                        EBAL = abcdADD(BALnum)

                        sqlstring = " UPDATE SM_CARDFILE_HDR SET EBALANCE = '" & Trim(EBAL) & "' WHERE CARDCODE='" & cardcode & "'"
                        ReDim Preserve Delete(Delete.Length)
                        Delete(Delete.Length - 1) = sqlstring
                        'END
                    End If
                End If
              
                Dim STRSQL2 As String
                STRSQL2 = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
                'STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & StrPOSCODE & "' AND STORESTATUS = 'FF' "
                gconnection.getDataSet(STRSQL2, "SM_CARDFILE_DET")
                If gdataset.Tables("SM_CARDFILE_DET").Rows.Count > 0 Then
                    POS_AMT_GBL = Val(txt_TotalValue.Text)
                    STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & STRPOSCODE & "' AND STORESTATUS = 'FF' "
                    gconnection.getDataSet(STRSQL2, "FACILITY")
                    If gdataset.Tables("FACILITY").Rows.Count > 0 Then
                        'ONCE FACILITY 
                        sqlstring = " UPDATE SM_CARDFILE_HDR SET UPDATEUSER='" & Trim(gUsername) & "',UPDATEDATETIME='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "' WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "'"
                        ReDim Preserve Delete(Delete.Length)
                        Delete(Delete.Length - 1) = sqlstring
                        'sqlstring = " UPDATE SM_CARDFILE_DET SET POS_VALID_FROM='" & Format(Cmb_Validfrom.Value, "dd/MMM/yyyy") & "',POS_VALID_TO='" & Format(Cmb_Validto.Value, "dd/MMM/yyyy") & "',TIME_FROM='" & Format(Cmb_TimeFrom.Value, "HH:MM") & "', TIME_TO='" & Format(Cmb_TimeTo.Value, "HH:MM") & "',DURATION='" & Format(Cmb_Duration.Value, "hh:mm") & "', HOURLY_BILL=" & POS_RATE_GBL & ", PERIOD_TO_DATE_USAGE=" & POS_AMT_GBL & " WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & StrPOSCODE & "'"

                        sqlstring = " SELECT POS_ACCESS, isNULL(POS_VALID_FROM,'01/01/1900') AS POS_VALID_FROM, ISNULL(POS_VALID_TO,'01/01/1900')AS POS_VALID_TO, ISNULL(TIME_FROM,'01/01/1900 00:00') AS TIME_FROM, ISNULL(TIME_TO,'01/01/1900 00:00') AS TIME_TO, ISNULL(DURATION,'01/01/1900 00:00')AS DURATION  FROM SM_CARDFILE_DET_IMG WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
                        gconnection.getDataSet(sqlstring, "SM_CARDFILE_DET_IMG")
                        If gdataset.Tables("SM_CARDFILE_DET_IMG").Rows.Count > 0 Then
                            Dim POS_ACCESS As String
                            Dim POS_VALID_FROM, POS_VALID_TO, TIME_FROM, TIME_TO, DURATION As DateTime
                            POS_ACCESS = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_ACCESS")
                            POS_VALID_FROM = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_VALID_FROM")
                            POS_VALID_TO = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("POS_VALID_TO")
                            TIME_FROM = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("TIME_FROM")
                            TIME_TO = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("TIME_TO")
                            DURATION = gdataset.Tables("SM_CARDFILE_DET_IMG").Rows(0).Item("DURATION")
                            sqlstring = " UPDATE SM_CARDFILE_DET SET POS_ACCESS='" & POS_ACCESS & "',POS_VALID_FROM ='" & Format(POS_VALID_FROM, "dd/MMM/yyyy") & "',POS_VALID_TO='" & Format(POS_VALID_TO, "dd/MMM/yyyy") & "',TIME_FROM='" & Format(TIME_FROM, "HH:MM") & "',TIME_TO='" & Format(TIME_TO, "HH:MM") & "',DURATION='" & Format(DURATION, "HH:MM") & "' WHERE CARDCODE = '" & Trim(txt_Holder_Code.Text) & "' AND POSCODE='" & STRPOSCODE & "'"
                            ReDim Preserve Delete(Delete.Length)
                            Delete(Delete.Length - 1) = sqlstring
                        End If
                    End If
                End If


                sqlstring = " UPDATE SETTLEMENT SET DELETEFLAG = 'Y' WHERE BILLDETAILS='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                sqlstring = " UPDATE ROOMLEDGER SET CANCEL='Y' WHERE ROOMNO =" & Val(txt_MemberCode.Text) & " "
                sqlstring = sqlstring & " AND DOCTYPE='SALES' AND DOCNO in ('" & Trim(txt_KOTno.Text) & "')"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                sqlstring = " UPDATE ROOMLEDGERDTL SET VOIDSTATUS='Y' where docno=substring('" & txt_KOTno.Text & "',5,6) and doctype='TAX' AND KOTNO='" & Trim(CStr(txt_KOTno.Text)) & "'"
                'sqlstring = sqlstring & " AND DOCTYPE='SALES' AND DOCNO in ('" & Trim(txt_KOTno.Text) & "')"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                If gMEMBERCLIMITVALIDATE = "Y" Then
                    sqlstring = " UPDATE JOURNALENTRY SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring
                    sqlstring = " UPDATE OUTSTANDING SET VOID = 'Y' WHERE VOUCHERNO='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                    ReDim Preserve Delete(Delete.Length)
                    Delete(Delete.Length - 1) = sqlstring
                End If

                gconnection.MoreTransold(Delete)
                Call Cmd_Clear_Click(Cmd_Clear, e)
            End If
        Else
            MessageBox.Show("Plz Enter a Valid KOTno", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
    End Sub
    Private Sub DeleteOperation()
        MessageBox.Show("Particular KOT's Can't be deleted", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        If Mid(Trim(UCase(gCompanyname)), 1, 10) = "THE BENGAL" Then
            Call Bengal_Print()
        Else
            gPrint = False
            Call BillPrintOperation1()
        End If
    End Sub
    Private Sub Bengal_Print()
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New DirectBill
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "SELECT * FROM BILL_HDR WHERE BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
        Call Viewer.GetDetails1(sqlstring, "BILL_HDR", r)
        Viewer.TableName = "BILL_HDR"

        sqlstring = "select K.ITEMCODE,K.ITEMDESC,K.RATE,K.QTY,AMOUNT,VAT AS TAXAMOUNT,SER AS TAXAMT,ISNULL(PACKAMOUNT,0)+isnull(TipsAmt,0)+isnull(AdCgsAmt,0)+isnull(PartyAmt,0)+isnull(RoomAmt,0) AS Packamount "
        sqlstring = sqlstring & " from kot_det K,ITEM_TAX_DET_SUM T  WHERE K.KOTDETAILS = T.KOTDETAILS AND K.ITEMCODE = T.ITEMCODE AND BILLDETAILS = '" & Trim(txt_KOTno.Text) & "'"
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
    Public Sub BillPrintOperation()
        Randomize()
        Dim vOutfile, vheader, vFilepath, vline, Kot, Bill, amtword, paymentmode, rupeesword As String
        Dim ssql, vCaption, vPath, str, Sqlstring, billdetails, Fsize(), Forder(), Round, Roundedvalue() As String
        Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, Taxpercentage, RoundOff1 As Double
        Dim Loopindex, i, Fo, in1, CountItem, rowj As Integer
        Dim Vrowcount, vpagenumber As Long
        Dim Filewrite As StreamWriter
        gCompanyname = MyCompanyName
        gCompanyAddress(0) = Address1
        gCompanyAddress(1) = Address2
        Gheader = " V O U C H E R "
        vpagenumber = 1
        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
        vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
        billdetails = "'" & Trim(txt_KOTno.Text) & "'"
        paymentmode = Trim(cbo_PaymentMode.Text)

        Sqlstring = " SELECT ISNULL(D.KOTNO,'') AS KOTNO,ISNULL(D.BILLDETAILS,'') AS BILLDETAILS,ISNULL(D.KOTDETAILS,'') AS KOTDETAILS, "
        Sqlstring = Sqlstring & " D.KOTDATE AS KOTDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMDESC,'') AS ITEMDESC,ISNULL(D.POSCODE,'') AS POSCODE,"
        Sqlstring = Sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(D.TAXTYPE,'') AS TAXTYPE, ISNULL(D.TAXPERC,0) AS TAXPERC,"
        Sqlstring = Sqlstring & " ISNULL(D.TAXCODE,'') AS TAXCODE,ISNULL(D.TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(D.ITEMTYPE,'') AS ITEMTYPE,ISNULL(H.MCODE,'') AS MCODE,"
        Sqlstring = Sqlstring & " ISNULL(H.MNAME,'') AS MNAME,ISNULL(H.STCODE,'') AS STCODE,ISNULL(H.SERVERNAME,'') AS SERVERNAME,ISNULL(H.PAYMENTTYPE,'') AS PAYMENTTYPE,ISNULL(H.GUEST,'') AS GUEST,"
        Sqlstring = Sqlstring & " ISNULL(H.ROOMNO,'') AS ROOMNO,ISNULL(H.DISCOUNTAMT,0) AS DISCOUNTAMT,ISNULL(H.PACKAMT,0) AS PACKAMT,ISNULL(H.TOTAL,0) AS TOTAL,ISNULL(H.TOTALTAX,0) AS TOTALTAX,"
        Sqlstring = Sqlstring & " ISNULL(H.BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(H.ROUNDOFF,0) AS ROUNDOFF,ISNULL(H.ADDUSERID,'') AS ADDUSERID,ISNULL(H.REMARKS,'') AS REMARKS,H.ADDDATETIME AS ADDDATETIME,"
        Sqlstring = Sqlstring & " ISNULL(H.DELFLAG,'') AS DELFLAG FROM KOT_HDR AS H INNER JOIN KOT_DET AS D ON H.KOTDETAILS = D.KOTDETAILS "
        Sqlstring = Sqlstring & " WHERE BILLDETAILS = '" & Trim(txt_KOTno.Text) & "' ORDER BY BILLDETAILS,ITEMCODE"

        gconnection.getDataSet(Sqlstring, "Manualbilldetails")
        If gdataset.Tables("Manualbilldetails").Rows.Count > 0 Then
            Filewrite = File.AppendText(vFilepath)
            vline = "" : Kot = "" : Bill = "" : Taxpercentage = 0
            Bill = Trim(gdataset.Tables("Manualbilldetails").Rows(0).Item("BILLDETAILS"))
            Taxpercentage = Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TAXPERC"))

            Sql = "SELECT ISNULL(PRINTFLAG,'') AS PRINTFLAG FROM BILL_HDR Where Billdetails = '" & Trim(Bill) & "'"
            gconnection.getDataSet(Sql, "PRINTFLAG")
            PrintFlag = Trim(gdataset.Tables("PRINTFLAG").Rows(0).Item("PRINTFLAG"))

            For rowj = 0 To gdataset.Tables("Manualbilldetails").Rows.Count - 1
                CountItem = CountItem + 1
                If Trim(Bill) <> Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("BillDetails")) Then
                    If Vrowcount <= 16 Then
                        For i = 1 To 16 - Vrowcount
                            Filewrite.WriteLine("")
                        Next
                    End If
                    If gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE") = "ROOM" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("GUEST")) & "[" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("ROOMNO")) & "]", 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE") = "CREDIT" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MNAME")) & "[" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MCODE")) & "]", 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE") = "COUPON" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-45}", ":")
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE") = "R.MEMBER" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & "RECIPROCAL MEMBER", 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE") = "PENDING" Then
                        Filewrite.Write("{0,-10}", "MEMEBER NAME :")
                        Filewrite.WriteLine("{0,-55}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MNAME") & "[" & gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MCODE") & "]", 1, 55))
                    Else
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MNAME")) & "[" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("MCODE")) & "]", 1, 55))
                    End If
                    Filewrite.WriteLine("{0,-69}{1,10}", "", StrDup(10, "-"))
                    Filewrite.WriteLine("{0,-69}{1,10}", "", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")), "0.00"))
                    Sqlstring = "SELECT ISNULL(TAXCODE,'') AS TAXCODE,ISNULL(TAXDESC,'') AS TAXDESC,ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM ACCOUNTSTAXMASTER WHERE TAXCODE ='" & Trim(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("TAXCODE")) & "' "
                    gconnection.getDataSet(Sqlstring, "ACCOUNTSTAXMASTER")
                    If gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count > 0 Then
                        Sqlstring = "SELECT ISNULL(DATAFILE,'') FROM MASTER..CLUBMASTER WHERE DATAFILE = 'CLUB2007'"
                        gconnection.getDataSet(Sqlstring, "CLUBMASTER")
                        If gdataset.Tables("CLUBMASTER").Rows.Count > 0 Then
                            Filewrite.Write("{0,-31}{1,38}", "BILL PAYBLE ON PRESENTATION", Mid(Trim(CStr(gdataset.Tables("ACCOUNTSTAXMASTER").Rows(0).Item("TAXDESC"))) & ":", 1, 35))
                            Filewrite.WriteLine("{0,10}", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")), "0.00"))
                        Else
                            Filewrite.Write("{0,-31}{1,38}", "", Mid(Trim(CStr(gdataset.Tables("ACCOUNTSTAXMASTER").Rows(0).Item("TAXDESC"))) & ":", 1, 35))
                            Filewrite.WriteLine("{0,10}", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")), "0.00"))
                        End If
                    End If
                    If Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")) > 0 Then
                        Filewrite.Write("{0,69}", "                                      PACKING CHARGES @ 5% :")
                        Filewrite.WriteLine("{0,10}", Format((Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
                    End If
                    If Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("DISCOUNTAMT")) > 0 Then
                        Filewrite.Write("{0,69}", "                                       DISCOUNT PERCENTAGE :")
                        Filewrite.WriteLine("{0,10}", Mid(Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("DISCOUNTAMT")), "0") & "%", 1, 10))
                    End If
                    Filewrite.WriteLine("{0,-79}", "")
                    Filewrite.WriteLine("{0,-69}{1,10}", "", StrDup(10, "-"))
                    Filewrite.Write("{0,-50}{1,19}", "", "TOTAL :")
                    Filewrite.WriteLine("{0,10}", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
                    RoundOff = Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")))
                    Round = CStr(RoundOff)

                    RoundOff1 = Mid(Format(Val(RoundOff), "0.00"), Len(Format(Val(RoundOff), "0.00")) - 1, Len(Format(Val(RoundOff), "0.00")))
                    If Format(Val(RoundOff1), "00") = 50 Then
                        RoundOff = Math.Ceiling(RoundOff)
                    ElseIf Format(Val(RoundOff1), "00") > 50 Then
                        RoundOff = Math.Ceiling(RoundOff)
                    Else
                        RoundOff = Math.Floor(RoundOff)
                    End If
                    If Val(RoundOff) > Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))) Then
                        RoundDiff = RoundOff - (Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")))
                        Filewrite.Write("{0,-50}{1,19}", "", "ROUNDED OFF(+):")
                    Else
                        RoundDiff = (Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))) - RoundOff
                        Filewrite.Write("{0,-50}{1,19}", "", "ROUNDED OFF(-):")
                    End If
                    Filewrite.WriteLine("{0,10}", Format(Val(RoundDiff), "0.00"))
                    Filewrite.WriteLine(StrDup(79, "-"))
                    rupeesword = RupeesToWordASCA(Format(Math.Round(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
                    Filewrite.Write("{0,-69}", Mid(Trim("RUPEES " & rupeesword & " ONLY."), 1, 69))
                    Filewrite.WriteLine("{0,10}", Format(Math.Round(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("BILLAMOUNT"))), "0.00"))
                    Filewrite.WriteLine(StrDup(79, "-"))
                    Filewrite.Write("{0,-14}{1,-46}", "PREPARED BY:", Mid(UCase(gUsername), 1, 40))
                    Filewrite.WriteLine("{0,-20}", Mid(MyCompanyName, 1, 20))
                    Filewrite.WriteLine("{0,-14}{1,-20}", "REMARKS :   ", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("REMARKS"), 1, 20))
                    Kot = ""
                    Bill = gdataset.Tables("ReportTable").Rows(rowj).Item("BILLDETAILS")
                    Taxpercentage = Val(gdataset.Tables("Manualbilldetails").Rows(rowj).Item("TAXPERC"))
                    TotalAmount = 0 : TaxAmount = 0 : Vrowcount = 0 : CountItem = 1
                    Filewrite.WriteLine(Chr(12))
                End If
                If Kot <> gdataset.Tables("Manualbilldetails").Rows(0).Item("KOTNO") Then
                    If Trim(Kot) <> "" Then
                        Kot = Kot & "," & gdataset.Tables("Manualbilldetails").Rows(0).Item("KOTNO")
                    Else
                        Kot = gdataset.Tables("Manualbilldetails").Rows(0).Item("KOTNO")
                    End If
                End If
                If Vrowcount = 0 Then
                    Sqlstring = "SELECT ISNULL(BillPrintHeader,'') AS BillPrintHeader FROM POSSETUP"
                    gconnection.getDataSet(Sqlstring, "POSSETUP")
                    If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                        If Trim(gdataset.Tables("POSSETUP").Rows(0).Item("BillPrintHeader")) = "YES" Then
                            vheader = Space((65 - Len(gCompanyname)) / 2) & Chr(14) & Chr(15) & gCompanyname & Chr(18)
                            Filewrite.WriteLine(vheader)
                            vheader = Space((65 - Len(Trim(gCompanyAddress(0)))) / 2) & Chr(14) & Chr(15) & gCompanyAddress(0) & Chr(18)
                            Filewrite.WriteLine(vheader)
                            vheader = Space((65 - Len(Trim(gCompanyAddress(1)))) / 2) & Chr(14) & Chr(15) & gCompanyAddress(1) & Chr(18)
                            Filewrite.WriteLine(vheader)
                            '    Filewrite.WriteLine(Space(17) & Chr(14) & Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10) & Chr(18))
                        End If
                    End If
                    Filewrite.WriteLine("")
                    If gdataset.Tables("Manualbilldetails").Rows(0).Item("DELFLAG") <> "Y" Then
                        'vheader = Chr(14) & Chr(15) & Space((40 / 2) - (Len(Gheader) / 2)) & Gheader
                    Else
                        vheader = Chr(14) & Chr(15) & Space((40 / 2) - (Len(Gheader) / 2)) & " V O U C H E R [D E L E T E D]"
                        'siva
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine(vheader)
                    End If
                    'siva
                    'Filewrite.WriteLine("")
                    'Filewrite.WriteLine(vheader)
                    Filewrite.Write("{0,-12}{1,-24}{2,-12}", Chr(15) & Mid("BILL   NO:", 1, 10), Chr(14) & Chr(15) & Mid(Bill, 1, 18) & Chr(20), "")
                    Filewrite.WriteLine("{0,-8}{1,-10}", Chr(15) & "TIME   :", Format(gdataset.Tables("Manualbilldetails").Rows(0).Item("ADDDATETIME"), "hh:mm:ss"))
                    Filewrite.Write("{0,-12}{1,-24}{2,-24}", Mid("SERVER   :", 1, 10), Mid(CStr(gdataset.Tables("Manualbilldetails").Rows(0).Item("SERVERNAME")) & "[" & CStr(gdataset.Tables("Manualbilldetails").Rows(0).Item("STCODE")) & "]", 1, 24), "")
                    Filewrite.WriteLine("{0,8}{1,-10}", "DATE   :", Format(CDate(gdataset.Tables("Manualbilldetails").Rows(0).Item("KOTDATE")), "MM/dd/yyyy"))
                    'siva
                    If gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "ROOM" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & gdataset.Tables("Manualbilldetails").Rows(0).Item("GUEST") & "[" & gdataset.Tables("Manualbilldetails").Rows(0).Item("ROOMNO") & "]", 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "CREDIT" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(": " & Chr(14) & Chr(15) & gdataset.Tables("Manualbilldetails").Rows(0).Item("MNAME") & "[" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MCODE") & "]" & Chr(20), 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "COUPON" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", ":")
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "R.MEMBER" Then
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & "RECIPROCAL MEMBER", 1, 55))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "PENDING" Then
                        Filewrite.Write("{0,-20}", "MEMEBER NAME :")
                        Filewrite.WriteLine("{0,-45}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("MNAME") & "[" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MCODE") & "]", 1, 45))
                    ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "CASH" Then
                        '                        Filewrite.WriteLine("{0,-20}", Chr(14) & Chr(15) & Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") & Chr(20), 1, 20))
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MNAME") & "[" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MCODE") & "]", 1, 55))
                    Else
                        Filewrite.Write("{0,-10}", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                        Filewrite.WriteLine("{0,-55}", Mid(":" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MNAME") & "[" & gdataset.Tables("Manualbilldetails").Rows(0).Item("MCODE") & "]", 1, 55))
                    End If
                    Vrowcount = Vrowcount + 1
                    'Filewrite.WriteLine("{0,-69}{1,10}", "", StrDup(10, "-"))
                    'Filewrite.WriteLine("{0,-69}{1,10}", "", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")), "0.00"))

                    'Filewrite.WriteLine("")
                    'Filewrite.WriteLine("")

                    Filewrite.WriteLine(StrDup(86, "-"))
                    Filewrite.WriteLine("{0,-6}{1,-6}{2,2}{3,-26}{4,8}{5,1}{6,4}{7,5}{8,6}", "SLNO", "CODE", "", "ITEM DESCRIPTION " & Chr(18) & Chr(14) & Chr(15) & Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 6), Chr(15) & "QTY", "", "UOM", "RATE", "AMOUNT")
                    Filewrite.WriteLine(StrDup(86, "-"))
                    Vrowcount = 8
                End If
                With gdataset.Tables("Manualbilldetails").Rows(rowj)
                    Filewrite.Write("{0,-6}{1,-6}{2,2}", Mid(CountItem & ".", 1, 5), Mid(Trim(.Item("ITEMCODE")), 1, 6), "")
                    Filewrite.Write("{0,-36}{1,8}{2,2}{3,-8}", Mid(Trim(.Item("ITEMDESC")) & Trim(".............................."), 1, 36), Mid(Format(Val(.Item("QTY")), "0.00"), 1, 8), "", Mid(Trim(.Item("UOM")), 1, 8))
                    Filewrite.WriteLine("{0,8}{1,10}", Mid(Format(Val(.Item("RATE")), "0.00"), 1, 8), Mid(Format(Val(.Item("AMOUNT")), "0.00"), 1, 10))
                    TotalAmount = TotalAmount + Val(.Item("Amount"))
                    TaxAmount = TaxAmount + Val(.Item("TaxAmount"))
                    Vrowcount = Vrowcount + 1
                End With
                'If Vrowcount > 32 Then
                '    Vrowcount = 0
                '    vpagenumber = Val(vpagenumber) + 1
                'End If
            Next rowj
            'siva
            Filewrite.WriteLine("{0,-76}{1,10}", "", StrDup(10, "-"))
            Filewrite.WriteLine("{0,-76}{1,10}", "", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")), "0.00"))
            Sqlstring = "SELECT ISNULL(TAXCODE,'') AS TAXCODE,ISNULL(TAXDESC,'') AS TAXDESC,ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM ACCOUNTSTAXMASTER WHERE TAXCODE ='" & Trim(gdataset.Tables("Manualbilldetails").Rows(0).Item("TAXCODE")) & "' "
            gconnection.getDataSet(Sqlstring, "ACCOUNTSTAXMASTER")
            If gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count > 0 Then
                Filewrite.Write("{0,-31}{1,45}", "BILL PAYBLE ON PRESENTATION", Mid(Trim(CStr(gdataset.Tables("ACCOUNTSTAXMASTER").Rows(0).Item("TAXDESC"))) & ":", 1, 35))
                Filewrite.WriteLine("{0,10}", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")), "0.00"))
            End If
            If Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")) > 0 Then
                Filewrite.Write("{0,76}", "                                      PACKING CHARGES @ 5% :")
                Filewrite.WriteLine("{0,10}", Format((Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
                Vrowcount = Vrowcount + 1
            End If
            Vrowcount = Vrowcount + 3
            If Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("DISCOUNTAMT")) > 0 Then
                Filewrite.Write("{0,76}", "                                       DISCOUNT PERCENTAGE :")
                Filewrite.WriteLine("{0,10}", Mid(Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("DISCOUNTAMT")), "0") & "%", 1, 10))
                Vrowcount = Vrowcount + 1
            End If
            'Filewrite.WriteLine("{0,-79}", "")
            Filewrite.WriteLine("{0,-76}{1,10}", "", StrDup(10, "-"))
            Vrowcount = Vrowcount + 2
            Filewrite.Write("{0,-57}{1,19}", "", "TOTAL :")
            Filewrite.WriteLine("{0,10}", Format(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
            Vrowcount = Vrowcount + 1
            RoundOff = Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")))
            Round = CStr(RoundOff)
            RoundOff1 = Mid(Format(Val(RoundOff), "0.00"), Len(Format(Val(RoundOff), "0.00")) - 1, Len(Format(Val(RoundOff), "0.00")))
            If Format(Val(RoundOff1), "00") = 50 Then
                RoundOff = Math.Ceiling(RoundOff)
            ElseIf Format(Val(RoundOff1), "00") > 50 Then
                RoundOff = Math.Ceiling(RoundOff)
            Else
                RoundOff = Math.Floor(RoundOff)
            End If
            If Val(RoundOff) > Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX") + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))) Then
                RoundDiff = RoundOff - (Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT")))
                Filewrite.Write("{0,-57}{1,19}", "", "ROUNDED OFF(+):")
            Else
                RoundDiff = (Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))) - RoundOff
                Filewrite.Write("{0,-57}{1,19}", "", "ROUNDED OFF(-):")
            End If
            Filewrite.WriteLine("{0,10}", Format(Val(RoundDiff), "0.00"))
           
            Filewrite.WriteLine(StrDup(86, "-"))
            rupeesword = RupeesToWordASCA(Format(Math.Round(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTAL")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("TOTALTAX")) + Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("PACKAMT"))), "0.00"))
            Filewrite.Write("{0,-53}", Mid(Trim("RUPEES " & rupeesword & " ONLY.") & "      " & Chr(18) & Chr(14) & Chr(15) & Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10), 1, 52) & Chr(15))
            Filewrite.WriteLine("{0,10}", Chr(14) & Chr(15) & Format(Math.Round(Val(gdataset.Tables("Manualbilldetails").Rows(0).Item("BILLAMOUNT"))), "0.00") & Chr(20))
            Filewrite.WriteLine(StrDup(86, "-"))
            '            Filewrite.WriteLine("")
            '            Filewrite.WriteLine(Space(37) & Chr(14) & Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10) & Chr(18))

            Dim strstring As String

            'strstring = "EXEC Sp_CreditLimit '" & Trim(txt_MemberCode.Text) & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "'"
            'gconnection.dataOperation(6, strstring, "CreditLimit")
            'strstring = "Select Isnull(ClosingBalance,0) as ClosingBalance, Isnull(CreditBalance,0) as CreditBalance from CBalLmt1"
            'gconnection.getDataSet(strstring, "CreditLimit")
            'If (gdataset.Tables("CreditLimit").Rows.Count > 0) Then
            '    Filewrite.WriteLine("Ledger Balance : Rs. " & Trim(CStr(Format(Val(gdataset.Tables("CreditLimit").Rows(0).Item("ClosingBalance")), "0.00"))) & Space(10) & "Credit Limit   : Rs. " & Trim(CStr(Format(Val(gdataset.Tables("CreditLimit").Rows(0).Item("CreditBalance")), "0.00"))))
            'Else
            '    Filewrite.WriteLine()
            'End If

            Filewrite.WriteLine("{0,-14}{1,-46}", "PREPARED BY:", Mid(UCase(gUsername), 1, 40))
            'Filewrite.WriteLine("{0,-20}", Mid(MyCompanyName, 1, 20))
            Filewrite.WriteLine("{0,-14}{1,-36}", "REMARKS :   ", Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("REMARKS"), 1, 20))
            '            Filewrite.Write("{0,-12}{1,-24}{2,-24}", Mid("SERVER   :", 1, 10), Mid(CStr(gdataset.Tables("Manualbilldetails").Rows(0).Item("SERVERNAME")) & "   [" & CStr(gdataset.Tables("Manualbilldetails").Rows(0).Item("STCODE")) & "]", 1, 24), "")
            If gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "CREDIT" Then
                Filewrite.WriteLine(Space(50) & Mid("Signature of Member", 1, 20))
                'Filewrite.Write("(0,10){1,-10}", Space(10), Mid(gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE"), 1, 10))
                Filewrite.WriteLine(Space(58) & Trim(gdataset.Tables("Manualbilldetails").Rows(0).Item("MCODE")))
            ElseIf gdataset.Tables("Manualbilldetails").Rows(0).Item("PAYMENTTYPE") = "CASH" Then
                Filewrite.WriteLine("{0,-20}", Mid("Signature of Waiter", 1, 20))
            End If

            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Filewrite.WriteLine("")
            Vrowcount = Vrowcount + 6
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(vFilepath)
                Sql = "Update BILL_HDR Set PrintFlag = 'Y' Where Billdetails = '" & Trim(Bill) & "'"
                STran(0) = Sql
                gconnection.dataOperation(6, STran(0), "BillHeader")
            End If
        End If
    End Sub
    Public Sub BillPrintOperation1()
        Randomize()
        Dim rowj, Loopindex, i, Pagesize, CountItem, in1, Fo, jo, cpt, Vrowcount1 As Integer
        Dim Rowprint, vCaption, vPath, Fsize(), Forder(), billdetails, rupeesword, splmember, servicelocation As String
        Dim BillNo, sql, sqlstring, Kot, vOutfile, vheader, vline, round, vFilepath, str, ssql, Otherbillno, BILLPLACE As String
        Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, taxpercentage, toalamt As Double
        Dim CardOpBalance, CardClBalance, trnBalance, OCardOpBalance, OCardClBalance, OtrnBalance As Double
        Dim oth1 As Boolean
        Dim SSQL1, TypeFlag, PackDesc, TipsDesc, AddChgDesc As String
        Dim climit, ulimit, vPackAmt, vTipsAmt, vAdAmt, vPartyAmt, vRoomAmt As Double

        Dim Otrnbalance2 As Long
        Dim OCardOpBalance2 As Long
        sqlstring = "SELECT ISNULL(BALANCE,0) BALANCE FROM SM_CARDFILE_HDR WHERE CARDCODE='" & txt_Holder_Code.Text & "'  "
        gconnection.getDataSet(sqlstring, "balanceAmount")

        If gdataset.Tables("balanceAmount").Rows.Count > 0 Then
            CardOpBalance = Val(gdataset.Tables("balanceAmount").Rows(0).Item(0))
        End If
        sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
        gconnection.getDataSet(sql, "Bill_det")
        If gdataset.Tables("Bill_det").Rows.Count > 0 Then
            Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
            oth1 = True
            If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
                oth1 = False
                sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
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
            billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_KOTno.Text) & "'"
        Else
            billdetails = "'" & Trim(Me.txt_KOTno.Text) & "'"
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

        sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
        gconnection.getDataSet(sql, "Bill_det")
        If gdataset.Tables("Bill_det").Rows.Count > 0 Then
            Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
            Otherbool = True
            If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
                Otherbool = False
                sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
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
            billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_KOTno.Text) & "'"
        Else
            billdetails = "'" & Trim(Me.txt_KOTno.Text) & "'"
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
                        If Trim(txt_ServerCode.Text) <> "" Then
                            sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
                            sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
                            sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,BILL_HDR.Discountamount,"
                            sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
                            sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
                            sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
                            sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

                            sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
                            sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME,BILL_HDR.DELFLAG,"
                            sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
                            sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,"
                            sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS,BILL_HDR.Discountamount"
                            sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "
                        Else
                            sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,'' AS SNAME,"
                            sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
                            sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,BILL_HDR.Discountamount,"
                            sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
                            sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
                            sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
                            'sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

                            sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
                            sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,SNAME,BILL_HDR.DELFLAG,"
                            sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
                            sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,"
                            sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS,BILL_HDR.Discountamount"
                            sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "
                        End If
                    Else
                        sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
                        sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,D.KOTDATE,ITEMCODE,D.KOTNO,ITEMDESC,D.POSCODE,D.UOM,D.QTY,"
                        sql = sql & "ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,ISNULL(D.TAXAMOUNT,0) as TAXAMOUNT,,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,SUM(BILL_HDR.Discountamount) AS Discountamount,"
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
                                    If gCompanyname <> "" Then
                                        'Rowprint = Space(3) & Chr(18) & Chr(27) & Chr(106) & Chr(200) & Chr(27) + "E" & Space(10) & gCompanyname & Space(2) & Chr(27) + "F"
                                        Rowprint = Space(3) & Chr(18) & Chr(27) & Chr(106) & Chr(200) & Chr(27) + "E" & gCompanyname & Chr(27) + "F"
                                        Filewrite.WriteLine(Rowprint & Chr(18))
                                        Vrowcount = Vrowcount + 1
                                    End If

                                    If UCase(Trim(gdataset.Tables("ReportTable").Rows(0).Item("PRN"))) = "Y" Then
                                        Filewrite.WriteLine(Space(8) & "DUPLICATE")
                                        Vrowcount = Vrowcount + 1
                                    Else
                                        Filewrite.WriteLine("")
                                        Vrowcount = Vrowcount + 1
                                    End If
                                    If gTINNO <> "" Then
                                        Filewrite.WriteLine("{0,-11}{1,-20}", Space(3) & "TINNO" & Space(2) & ":", gTINNO)
                                        Vrowcount = Vrowcount + 1
                                    End If
                                    Rowprint = Space(3) & "BILL NO   :"
                                    Rowprint = Rowprint & Trim(HBILLDETAILS)
                                    Filewrite.WriteLine(Rowprint)
                                    Vrowcount = Vrowcount + 1
                                    Rowprint = Space(3) & "BILL DATE :"
                                    Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillDate"), "dd/MM/yyyy")
                                    Rowprint = Rowprint & " "
                                    Rowprint = Rowprint & Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillTime"), "T")
                                    Filewrite.WriteLine(Rowprint)
                                    Vrowcount = Vrowcount + 1

                                    Filewrite.WriteLine(Space(3) & "{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))
                                    Vrowcount = Vrowcount + 1

                                    Rowprint = Space(3) & "WAITER    :"
                                    Rowprint = Rowprint
                                    Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("SCODE"))
                                    Rowprint = Chr(17) & Rowprint & "("
                                    Rowprint = Rowprint & Trim(gdataset.Tables("ReportTable").Rows(rowj).Item("sname"))
                                    Rowprint = Trim(Rowprint) & ")"
                                    Filewrite.WriteLine(Chr(17) & Rowprint)
                                    Vrowcount = Vrowcount + 1
                                    If MCODE = "" Then
                                        Rowprint = Space(3) & "ROOM NO   :"
                                        Rowprint = Rowprint & Space(1) & Chr(18) & Trim(ROOMNO)
                                        Filewrite.WriteLine(Rowprint & Chr(18))
                                        Vrowcount = Vrowcount + 1
                                        Rowprint = Space(3) & "GUEST NAME:" & Space(1) & Chr(18) & Trim(GUEST)
                                        Filewrite.WriteLine(Rowprint & Chr(17))
                                        Vrowcount = Vrowcount + 1
                                    Else
                                        Rowprint = Space(3) & "MEM CODE  :"
                                        Rowprint = Rowprint & Space(1) & Chr(18) & Trim(MCODE)
                                        Filewrite.WriteLine(Rowprint & Chr(18))
                                        Vrowcount = Vrowcount + 1
                                        Rowprint = Space(3) & "MEM NAME  :" & Space(1) & Chr(18) & Trim(MNAME)
                                        Filewrite.WriteLine(Rowprint & Chr(17))
                                        Vrowcount = Vrowcount + 1
                                    End If

                                    If gCompanyname <> "" Then
                                        Filewrite.Write(Space(3) & StrDup(37, "-"))
                                        Vrowcount = Vrowcount + 1
                                        Filewrite.WriteLine()
                                        Vrowcount = Vrowcount + 1
                                        Rowprint = Space(3) & "ITEM DESC            UOM  QTY  AMOUNT"
                                        Filewrite.WriteLine(Rowprint)
                                        Vrowcount = Vrowcount + 1
                                    End If
                                    '13
                                    Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
                                    Vrowcount = Vrowcount + 1
                                    '14
                                    Filewrite.WriteLine("")
                                    '15
                                    Vrowcount = Vrowcount + 1
                                    '16
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
                                    Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7)
                                    If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                        For i = 1 To 6
                                            Filewrite.WriteLine()
                                            Vrowcount = Vrowcount + 1
                                        Next
                                    End If
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
                                    If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
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
                            Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If

                        taxcount = taxcount + 1

                        Rowprint = Space(3) & "Total:" & Space(23) & Space(8 - Len(Mid(Trim(Format(TotalAmount, "0.00")), 1, 8))) & Mid(Trim(Format(TotalAmount, "0.00")), 1, 8)
                        Filewrite.WriteLine(Rowprint)
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        If gCompanyname <> "" Then
                            '2
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
                                If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                    For J = 1 To 6
                                        Filewrite.WriteLine()
                                        Vrowcount = Vrowcount + 1
                                    Next
                                End If
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
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        If vTipsAmt > 0 Then
                            Rowprint = Space(3) & Mid(TipsDesc, 1, 29) & Space(29 - Len(Mid(TipsDesc, 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vTipsAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        If vAdAmt > 0 Then
                            Rowprint = Space(3) & Mid(AddChgDesc, 1, 29) & Space(29 - Len(Mid(AddChgDesc, 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vAdAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        If vPartyAmt > 0 Then
                            Rowprint = Space(3) & Mid("Add Party Charges", 1, 29) & Space(29 - Len(Mid("Add Party Charges", 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vPartyAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        If vRoomAmt > 0 Then
                            Rowprint = Space(3) & Mid("Add Room Charges", 1, 29) & Space(29 - Len(Mid("Add Room Charges", 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8))) & Mid(Format(Val(vRoomAmt & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        If Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount")) > 0 Then
                            Rowprint = Space(3) & Mid("Less Discount", 1, 29) & Space(29 - Len(Mid("Less Discount", 1, 29)))
                            Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount") & ""), "0.00"), 1, 8)
                            Filewrite.WriteLine(Rowprint & Chr(17))
                            taxcount = taxcount + 1
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
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

                        Amt = Math.Round(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"), 0) - (TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))

                        Rowprint = Space(3) & "Round Off" & Space(20) & Space(8 - Len(Mid(Trim(Format(Amt, "0.00")), 1, 8))) & Mid(Trim(Format(Amt, "0.00")), 1, 8)
                        If Amt <> 0 Then
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        '------------------------------------------
                        Amt = 0
                        Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
                        taxcount = taxcount + 1
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("BILL AMOUNT:", 1, 15) & Space(15 - Len(Mid("BILL AMOUNT:", 1, 15)))

                        If Amt < 0 Then
                            Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) - Val(Amt * -1), "0.00")
                            toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) - Val(Amt * -1), "0.00")

                        Else
                            Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) + Val(Amt), "0.00")
                            toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) + Val(Amt), "0.00")
                        End If

                        Filewrite.WriteLine(Rowprint)
                        '10
                        taxcount = taxcount + 1
                        Vrowcount = Vrowcount + 1
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
                        Vrowcount = Vrowcount + 1
                        '11
                        taxcount = taxcount + 1
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
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
                            Rowprint = Space(3) & "KOT's:" & Kot & "."
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                            taxcount = taxcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
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
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
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
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        If PAY = "SMART CARD" Then
                            Filewrite.WriteLine(Space(3) & Chr(14) & Chr(15) & "CARD OP BAL. TRN AMOUNT  CLBAL.")
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                            Filewrite.WriteLine(Space(3) & "--------------------------------------------------")
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                            Rowprint = Space(3) & Chr(14) & Chr(15) & Space(9 - Len(CStr(Format(CardOpBalance, "0.00")))) & Mid(Format(CardOpBalance, "0.00"), 1, 9)
                            Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(trnBalance, "0.00")), 1, 9))) & Mid(Format(trnBalance, "0.00"), 1, 9)
                            Rowprint = Rowprint & Space(1) & Space(9 - Len(Mid(CStr(Format(CardClBalance, "0.00")), 1, 9))) & Mid(Format(CardClBalance, "0.00"), 1, 9)
                            Filewrite.WriteLine(Rowprint)
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                            Filewrite.WriteLine(Space(3) & "---------------------------------------------------")
                            Vrowcount = Vrowcount + 1
                            If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                                For i = 1 To 6
                                    Filewrite.WriteLine()
                                    Vrowcount = Vrowcount + 1
                                Next
                            End If
                        End If
                        CardOpBalance = CardClBalance
                        For i = 1 To 1
                            Filewrite.WriteLine("")
                            Vrowcount = Vrowcount + 1
                        Next
                        Vrowcount1 = Vrowcount
                        If Vrowcount = 19 Or Vrowcount = 44 Or Vrowcount = 63 Then
                            For i = 1 To 6
                                Filewrite.WriteLine()
                                Vrowcount = Vrowcount + 1
                            Next
                        End If
                        SSQL1 = "UPDATE BILL_HDR SET PRINTFLAG='Y' WHERE BILLDETAILS='" & Trim(Me.txt_KOTno.Text) & "'"
                        gconnection.ExcuteStoreProcedure(SSQL1)
                    End If
                Next
                cpt = cpt + 1
            Next
        End If

        If cpt > 1 Then
            Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
            Vrowcount1 = Vrowcount1 + 1
            If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
                For i = 1 To 6
                    Filewrite.WriteLine()
                    Vrowcount1 = Vrowcount1 + 1
                Next
            End If
            Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("TOTAL AMOUNT:", 1, 15) & Space(15 - Len(Mid("TOTAL AMOUNT:", 1, 15)))
            Rowprint = Rowprint & Format(Val((toalamt)), "0.00")
            Filewrite.WriteLine(Rowprint)
            Vrowcount1 = Vrowcount1 + 1
            If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
                For i = 1 To 6
                    Filewrite.WriteLine()
                    Vrowcount1 = Vrowcount1 + 1
                Next
            End If
            Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
            Vrowcount1 = Vrowcount1 + 1
            If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
                For i = 1 To 6
                    Filewrite.WriteLine()
                    Vrowcount1 = Vrowcount1 + 1
                Next
            End If
        End If
        Rowprint = Chr(15) & Chr(27) + "In Words:" & RupeesToWord(Val(Format(toalamt, "0.00"))) & Chr(27) + "F" & Chr(15)
        Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        Vrowcount1 = Vrowcount1 + 1
        If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                Vrowcount1 = Vrowcount1 + 1
            Next
        End If
        'If climit > 0 Then
        '    Rowprint = "CREDIT LIMIT Rs." & Format(Val(climit), "0.00")
        '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        '    Rowprint = "CRD.USED Rs." & Format(Val(MemberOutstand), "0.00") & Space(3) & "CRD.AVAILABLE Rs." & Format(Val(climit) - Val(MemberOutstand), "0.00")
        '    Filewrite.WriteLine(Space(3) & UCase(Rowprint))
        'End If

        Rowprint = Space(3) & Chr(14) & Chr(15) & "Payment Type:" & Trim(cbo_PaymentMode.Text) & ""
        Filewrite.WriteLine(Rowprint)
        Vrowcount1 = Vrowcount1 + 1
        If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                Vrowcount1 = Vrowcount1 + 1
            Next
        End If
        Filewrite.WriteLine("")
        Vrowcount1 = Vrowcount1 + 1
        If Vrowcount1 = 19 Or Vrowcount1 = 44 Or Vrowcount1 = 63 Then
            For i = 1 To 6
                Filewrite.WriteLine()
                Vrowcount1 = Vrowcount1 + 1
            Next
        End If
        Rowprint = Space(3) & "Prepared By:" & Trim(addUser)
        Filewrite.WriteLine(Chr(16) & Rowprint)
        Vrowcount1 = Vrowcount1 + 1
        If Vrowcount1 > 19 And Vrowcount1 < 44 Then
            J = 44 - Vrowcount1
            J = J + 11
        ElseIf Vrowcount1 > 50 And Vrowcount1 < 69 Then
            J = 69 - Vrowcount1
            J = J + 11
        ElseIf Vrowcount1 > 75 And Vrowcount1 < 94 Then
            J = 94 - Vrowcount1
            J = J + 11
        ElseIf Vrowcount1 > 100 And Vrowcount1 < 119 Then
            J = 119 - Vrowcount1
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

    'Public Sub BillPrintOperation1()
    '    Randomize()
    '    Dim rowj, Loopindex, i, Pagesize, CountItem, in1, Fo, jo, cpt As Integer
    '    Dim Rowprint, vCaption, vPath, Fsize(), Forder(), billdetails, rupeesword, splmember, servicelocation As String
    '    Dim BillNo, sql, sqlstring, Kot, vOutfile, vheader, vline, round, vFilepath, str, ssql, Otherbillno, BILLPLACE As String
    '    Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, taxpercentage, toalamt As Double
    '    Dim CardOpBalance, CardClBalance, trnBalance, OCardOpBalance, OCardClBalance, OtrnBalance As Double
    '    Dim oth1 As Boolean
    '    Dim SSQL1, TypeFlag, PackDesc, TipsDesc, AddChgDesc As String
    '    Dim climit, ulimit, vPackAmt, vTipsAmt, vAdAmt, vPartyAmt, vRoomAmt As Double

    '    Dim Otrnbalance2 As Long
    '    Dim OCardOpBalance2 As Long
    '    sqlstring = "SELECT ISNULL(BALANCE,0) BALANCE FROM SM_CARDFILE_HDR WHERE CARDCODE='" & txt_Holder_Code.Text & "'  "
    '    gconnection.getDataSet(sqlstring, "balanceAmount")

    '    If gdataset.Tables("balanceAmount").Rows.Count > 0 Then
    '        CardOpBalance = Val(gdataset.Tables("balanceAmount").Rows(0).Item(0))
    '    End If
    '    sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
    '    gconnection.getDataSet(sql, "Bill_det")
    '    If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '        Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
    '        oth1 = True
    '        If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
    '            oth1 = False
    '            sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
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
    '        billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_KOTno.Text) & "'"
    '    Else
    '        billdetails = "'" & Trim(Me.txt_KOTno.Text) & "'"
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

    '    sql = "SELECT OthbillDetails FROM Bill_det WHERE Billdetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
    '    gconnection.getDataSet(sql, "Bill_det")
    '    If gdataset.Tables("Bill_det").Rows.Count > 0 Then
    '        Otherbillno = Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "")
    '        Otherbool = True
    '        If Trim(gdataset.Tables("Bill_det").Rows(0).Item("OthbillDetails") & "") = "" Then
    '            Otherbool = False
    '            sql = "SELECT billdetails FROM Bill_det WHERE OthbillDetails = '" & Trim(CStr(txt_KOTno.Text)) & "'"
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
    '        billdetails = "'" & Trim(Otherbillno) & "','" & Trim(Me.txt_KOTno.Text) & "'"
    '    Else
    '        billdetails = "'" & Trim(Me.txt_KOTno.Text) & "'"
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
    '                    If Trim(txt_ServerCode.Text) <> "" Then
    '                        sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
    '                        sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
    '                        sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,BILL_HDR.Discountamount,"
    '                        sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
    '                        sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
    '                        sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
    '                        sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

    '                        sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
    '                        sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME,BILL_HDR.DELFLAG,"
    '                        sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
    '                        sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,"
    '                        sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS,BILL_HDR.Discountamount"
    '                        sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "
    '                    Else
    '                        sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,'' AS SNAME,"
    '                        sql = sql & "D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,SUM(D.QTY) AS QTY,ISNULL(D.TABLENO,'') AS TABLENO,"
    '                        sql = sql & "ISNULL(D.RATE,0) AS RATE,SUM(ISNULL(D.AMOUNT,0)) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,SUM(ISNULL(D.TAXAMOUNT,0)) as TAXAMOUNT,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,BILL_HDR.Discountamount,"
    '                        sql = sql & "ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid as adduserid,ISNULL(BILL_HDR.servicelocation,'') AS servicelocation,ISNULL(BILL_HDR.PRINTFLAG,'')AS PRN,"
    '                        sql = sql & "ISNULL(GUEST,'') AS GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),'') AS ROOMNO,ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),'') AS CHKID"
    '                        sql = sql & " FROM KOT_DET D INNER JOIN BILL_HDR ON BILL_HDR.BILLDETAILS = D.BILLDETAILS "
    '                        'sql = sql & "  INNER JOIN SERVERMASTER E  ON E.SERVERCODE=D.SCODE  "

    '                        sql = sql & " WHERE D.Billdetails IN (" & Trim(billdetails) & ") AND ISNULL(KotStatus,'N')='N' "
    '                        sql = sql & " group by D.POSCODE,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,SNAME,BILL_HDR.DELFLAG,"
    '                        sql = sql & " D.BILLDETAILS,ITEMCODE,ITEMDESC,D.POSCODE,D.UOM,D.RATE,D.TABLENO,BILL_HDR.PRINTFLAG,"
    '                        sql = sql & " TAXTYPE,TAXPERC,TAXCODE,ITEMTYPE,BILLDATE,BILLTIME,BILL_HDR.adduserid,BILL_HDR.servicelocation,"
    '                        sql = sql & "GUEST,ISNULL(CAST(ROOMNO AS VARCHAR),''),ISNULL(CAST(BILL_HDR.CHKID AS VARCHAR),''),BILL_HDR.BILLDETAILS,BILL_HDR.Discountamount"
    '                        sql = sql & " --ORDER BY D.KOTDETAILS --D.BillDetails "
    '                    End If
    '                Else
    '                    sql = "SELECT BILL_HDR.BILLDETAILS AS HBILLDETAILS,BILL_HDR.PAYMENTMODE,BILL_HDR.MCODE,BILL_HDR.MNAME,D.SCODE,E.SERVERNAME AS SNAME,"
    '                    sql = sql & "D.BILLDETAILS,D.KOTNO,D.KOTDETAILS,D.KOTDATE,ITEMCODE,D.KOTNO,ITEMDESC,D.POSCODE,D.UOM,D.QTY,"
    '                    sql = sql & "ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,TAXTYPE,TAXPERC,ISNULL(TAXCODE,'') as TAXCODE,ISNULL(D.TAXAMOUNT,0) as TAXAMOUNT,,SUM(ISNULL(D.PACKAMOUNT,0)) as PACKAMOUNT,SUM(ISNULL(D.TipsAmt,0)) as TipsAmt,SUM(ISNULL(D.AdCgsAmt,0)) as AdCgsAmt,SUM(ISNULL(D.PartyAmt,0)) as PartyAmt,SUM(ISNULL(D.RoomAmt,0)) as RoomAmt,SUM(BILL_HDR.Discountamount) AS Discountamount,"
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

    '                                If gCompanyname <> "" Then
    '                                    Filewrite.Write(Space(3) & StrDup(37, "-"))
    '                                    Filewrite.WriteLine()
    '                                    Vrowcount = Vrowcount + 1
    '                                    Rowprint = Space(3) & "ITEM DESC            UOM  QTY  AMOUNT"
    '                                    Filewrite.WriteLine(Rowprint)
    '                                End If
    '                                '13
    '                                Vrowcount = Vrowcount + 1
    '                                Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
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
    '                                Rowprint = Rowprint & Space(7 - Len(Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7))) & Mid(Format(Val(.Item("AMOUNT") & ""), "0.00"), 1, 7)

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
    '                        Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
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
    '                    If Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount")) > 0 Then
    '                        Rowprint = Space(3) & Mid("Less Discount", 1, 29) & Space(29 - Len(Mid("Less Discount", 1, 29)))
    '                        Rowprint = Rowprint & Space(8 - Len(Mid(Format(Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount") & ""), "0.00"), 1, 8))) & Mid(Format(Val(gdataset.Tables("ReportTable").Rows(0).Item("Discountamount") & ""), "0.00"), 1, 8)
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

    '                    Amt = Math.Round(TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"), 0) - (TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))

    '                    Rowprint = Space(3) & "Round Off" & Space(20) & Space(8 - Len(Mid(Trim(Format(Amt, "0.00")), 1, 8))) & Mid(Trim(Format(Amt, "0.00")), 1, 8)
    '                    If Amt <> 0 Then
    '                        Filewrite.WriteLine(Rowprint)
    '                        Vrowcount = Vrowcount + 1
    '                    End If
    '                    '------------------------------------------
    '                    Amt = 0
    '                    Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
    '                    taxcount = taxcount + 1
    '                    Vrowcount = Vrowcount + 1
    '                    Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("BILL AMOUNT:", 1, 15) & Space(15 - Len(Mid("BILL AMOUNT:", 1, 15)))

    '                    If Amt < 0 Then
    '                        Rowprint = Rowprint & Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) - Val(Amt * -1), "0.00")
    '                        toalamt = toalamt + Format(Val((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) - Val(Amt * -1), "0.00")

    '                    Else
    '                        Rowprint = Rowprint & Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) + Val(Amt), "0.00")
    '                        toalamt = toalamt + Format(Math.Round((TaxAmount + TotalAmount + vPackAmt + vTipsAmt + vAdAmt + vPartyAmt + vRoomAmt - gdataset.Tables("ReportTable").Rows(0).Item("Discountamount"))) + Val(Amt), "0.00")
    '                    End If

    '                    Filewrite.WriteLine(Rowprint)
    '                    '10
    '                    taxcount = taxcount + 1
    '                    Vrowcount = Vrowcount + 1
    '                    Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
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
    '                    SSQL1 = "UPDATE BILL_HDR SET PRINTFLAG='Y' WHERE BILLDETAILS='" & Trim(Me.txt_KOTno.Text) & "'"
    '                    gconnection.ExcuteStoreProcedure(SSQL1)

    '                End If
    '            Next
    '            cpt = cpt + 1
    '        Next
    '    End If

    '    If cpt > 1 Then
    '        Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
    '        Rowprint = Space(3) & Chr(14) & Chr(15) & Mid("TOTAL AMOUNT:", 1, 15) & Space(15 - Len(Mid("TOTAL AMOUNT:", 1, 15)))
    '        Rowprint = Rowprint & Format(Val((toalamt)), "0.00")
    '        Filewrite.WriteLine(Rowprint)
    '        Filewrite.WriteLine(Space(3) & StrDup(37, "-"))
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

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Mid(Trim(UCase(gCompanyname)), 1, 10) = "THE BENGAL" Then
            Call Bengal_Print()
        Else
            gPrint = True
            Call BillPrintOperation1()
        End If
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

    Private Sub Txt_PartyBookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PartyBookingNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_PartyBookingNo.Text) <> "" Then
                Call Txt_PartyBookingNo_Validated(Txt_PartyBookingNo, e)
                Exit Sub
            Else
                'Call Cmd_GolfRegNoHelp_Click(sender, e)
                'Exit Sub
                'MessageBox.Show("Party Not Available in this Date")
                'Txt_PartyBookingNo.Text = ""
            End If
        End If
    End Sub

    Private Sub Txt_PartyBookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_PartyBookingNo.Validated
        If Trim(Txt_PartyBookingNo.Text) <> "" Then
            If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                SQLSTRING = "SELECT * FROM party_hallbooking_hdr WHERE  CAST(CONVERT(VARCHAR,PARTYDATE,106) AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                gconnection.getDataSet(SQLSTRING, "BOOKVALUE")
                If gdataset.Tables("BOOKVALUE").Rows.Count > 0 Then
                    txt_MemberCode.Text = Trim(CStr(gdataset.Tables("BOOKVALUE").Rows(0).Item("MCODE")))
                    txt_MemberName.Text = Trim(CStr(gdataset.Tables("BOOKVALUE").Rows(0).Item("ASSOCIATENAME")))
                    txt_MemberCode.ReadOnly = True
                    txt_MemberName.ReadOnly = True
                    cmd_MemberCodeHelp.Enabled = False
                    txt_MemberCode.Focus()
                Else
                    MessageBox.Show("Party Not Available in this Date")
                    Txt_PartyBookingNo.Text = ""
                End If
            Else
                Txt_PartyBookingNo.Text = ""
                txt_MemberCode.Focus()
            End If
        End If
    End Sub
End Class