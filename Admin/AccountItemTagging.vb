
Public Class AccountItemTagging
    Dim Vconn As New GlobalClass

    Private Sub AccountItemTagging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i, j As Integer
        SQLSTRING = "SELECT 'TARIFF' AS SOURCE,A.TARIFFCODE AS ITEMCODE,A.TARIFFDESC AS ITEMDESC,ISNULL(A.salesacctin,'') AS ACCODE,isnull(b.acdesc,'') as acdesc,ISNULL(A.SUBGLACCODE,'') AS SUBACCODE,ISNULL(A.COSTCODE,'') AS COSTCODE FROM party_tariffhdr A left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "SELECT 'HALL' AS SOURCE,A.HALLTYPECODE AS ITEMCODE,A.HALLTYPEDESC AS ITEMDESC,ISNULL(A.GLACCODE,'') AS ACCODE,isnull(b.acdesc,'') as acdesc,ISNULL(A.SUBGLACCODE,'') AS SUBACCODE,ISNULL(A.COSTCODE,'') AS COSTCODE  FROM PARTY_HALLMASTER_HDR A left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "  select 'OTHERS'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.GLACCODE,'') as accode,isnull(b.acdesc,'') as acdesc,ISNULL(A.SUBGLACCODE,'') AS SUBACCODE,ISNULL(A.COSTCODE,'') AS COSTCODE  from Party_OtherChgsMaster a left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y'   "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "select 'ARRANGEMENT'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.GLACCODE,'') as accode,isnull(b.acdesc,'') as acdesc,ISNULL(A.SUBGLACCODE,'') AS SUBACCODE,ISNULL(A.COSTCODE,'') AS COSTCODE  from PARTY_ITEMMASTER a left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' order by SOURCE "

        Vconn.getDataSet(SQLSTRING, "acctag")
        If gdataset.Tables("acctag").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("acctag").Rows.Count - 1
                j = i + 1
                With ssgrid1
                    .Row = j
                    .Col = 1
                    .Text = gdataset.Tables("acctag").Rows(i).Item("SOURCE")
                    .Col = 2
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemcode")
                    .Col = 3
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemdesc")
                    .Col = 4
                    .Text = gdataset.Tables("acctag").Rows(i).Item("accode")
                    .Col = 5
                    .Text = gdataset.Tables("acctag").Rows(i).Item("acdesc")
                    .Col = 6
                    .Text = gdataset.Tables("acctag").Rows(i).Item("SUBACCODE")
                    .Col = 7
                    .Text = Vconn.getvalue("SELECT ISNULL(slname,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(gdataset.Tables("acctag").Rows(i).Item("accode")) & "' AND slcode = '" & Trim(gdataset.Tables("acctag").Rows(i).Item("SUBACCODE")) & "' AND ISNULL(FREEZEFLAG,'') <> 'Y'")
                    .Col = 8
                    .Text = gdataset.Tables("acctag").Rows(i).Item("COSTCODE")
                End With
                ssgrid1.MaxRows = ssgrid1.MaxRows + 1
            Next
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        Vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        '.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
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
                    'Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    'Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub ssgrid1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid1.KeyDownEvent
        '' ''With ssgrid1
        '' ''    If .ActiveCol = 3 Then
        '' ''        .Row = .ActiveRow
        '' ''        If .Text = "" Then
        '' ''            Call FillMenu()
        '' ''        End If
        '' ''    End If
        '' ''    If .Col = 4 Then
        '' ''        .Row = .ActiveRow
        '' ''        If .Text = "" Then
        '' ''            Call FillMenu()
        '' ''        End If
        '' ''    End If
        '' ''End With
        Dim accode, Subaccode As String
        Dim ssql As String
        Dim ITEMCODE As String
        With ssgrid1
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 4 Then
                    .Col = 4
                    .Row = .ActiveRow
                    If .Text = "" Then
                        Call FillMenu()
                    Else
                        .Col = 1
                        .Row = .ActiveRow
                        ITEMCODE = Trim(.Text)
                        If Trim(ITEMCODE) = "" Then
                            MessageBox.Show("ITEMCODE CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .ClearRange(1, .ActiveRow, 6, .ActiveRow, True)
                        End If
                        .Col = 4
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        ssql = " select ISNULL(accode,'')AS ACCODE,ISNULL(acdesc,'')ACDESC from accountsglaccountmaster WHERE category in ('I','E','L') and ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(accode) & " '"
                        Vconn.getDataSet(ssql, "acctag")
                        If gdataset.Tables("acctag").Rows.Count > 0 Then
                            .Col = 4
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag").Rows(0).Item("ACCODE"))
                            .Col = 5
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag").Rows(0).Item("ACDESC"))
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                            .Focus()
                        Else
                            MessageBox.Show("ACCOUNT CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .Text = ""
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow)
                        End If
                    End If
                End If
                If .ActiveCol = 5 Then
                    .Row = .ActiveRow
                    If .Text = "" Then
                        Call FillMenu()
                    Else
                        ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                    End If
                End If
                If .ActiveCol = 6 Then
                    .Col = 6
                    .Row = .ActiveRow
                    If .Text = "" Then
                        .Col = 4
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        Call FillMenuSub(accode)
                    Else
                        .Col = 1
                        .Row = .ActiveRow
                        ITEMCODE = Trim(.Text)
                        If Trim(ITEMCODE) = "" Then
                            MessageBox.Show("ITEMCODE CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .ClearRange(1, .ActiveRow, 6, .ActiveRow, True)
                        End If
                        .Col = 4
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        .Col = 6
                        .Row = .ActiveRow
                        Subaccode = Trim(.Text)
                        ssql = " select ISNULL(SLCODE,'')AS SLCODE,ISNULL(slname,'') slname from ACCOUNTSSUBLEDGERMASTER WHERE ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(accode) & " ' and  slcode='" & Trim(Subaccode) & " ' "
                        Vconn.getDataSet(ssql, "acctag1")
                        If gdataset.Tables("acctag1").Rows.Count > 0 Then
                            .Col = 6
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag1").Rows(0).Item("SLCODE"))
                            .Col = 7
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag1").Rows(0).Item("slname"))
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                            .Focus()
                        Else
                            MessageBox.Show("ACCOUNT CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .Text = ""
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow)
                        End If
                    End If
                End If
                If .ActiveCol = 8 Then
                    .Col = 8
                    .Row = .ActiveRow
                    If .Text = "" Then
                        .Col = 4
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        Call FillCostCode()
                    Else
                        .Col = 8
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        ssql = " SELECT costcentercode FROM ACCOUNTSCOSTCENTERMASTER WHERE ISNULL(freezeflag,'') <> 'Y' and costcentercode='" & Trim(accode) & " '"
                        Vconn.getDataSet(ssql, "acctag")
                        If gdataset.Tables("acctag").Rows.Count > 0 Then
                            .Col = 8
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag").Rows(0).Item("costcentercode"))
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                            .Focus()
                        Else
                            MessageBox.Show("COST CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .Text = ""
                            ssgrid1.SetActiveCell(7, ssgrid1.ActiveRow)
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub FillCostCode()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT costcentercode,costcenterdesc FROM ACCOUNTSCOSTCENTERMASTER  "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE ISNULL(freezeflag,'') <> 'Y'"
        Else
            M_WhereCondition = " WHERE ISNULL(freezeflag,'') <> 'Y' "
        End If
        vform.Field = "Costcentercode,Costcenterdesc"
        ' vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "COST CODE HELP"
        ' vform.KeyPos = 0
        'vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid1
                .Col = 8
                .Row = .ActiveRow
                .Text = vform.keyfield
            End With
        Else
            ssgrid1.SetActiveCell(0, ssgrid1.ActiveRow)
            Exit Sub
        End If
    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select accode,acdesc from accountsglaccountmaster "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE   category in ('I','E','L') and ISNULL(FREEZEFLAG,'') <>'Y'"
        Else
            M_WhereCondition = " WHERE category in ('I','E','L') and  ISNULL(FREEZEFLAG,'') <>'Y' "
        End If
        vform.Field = "accode,acdesc"
        ' vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ACCOUNT CODE HELP"
        ' vform.KeyPos = 0
        'vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid1
                .Col = 4
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 5
                .Row = .ActiveRow
                .Text = vform.keyfield1
            End With
        Else
            ssgrid1.SetActiveCell(0, ssgrid1.ActiveRow)
            Exit Sub
        End If
    End Sub
    Private Sub FillMenuSub(ByVal Scode As String)
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select ISNULL(SLCODE,'')AS SLCODE,ISNULL(slname,'') slname from ACCOUNTSSUBLEDGERMASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = "WHERE  ISNULL(FREEZEFLAG,'') <>'Y'  and accode='" & Trim(Scode) & "' "
        Else
            M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(Scode) & "' "
        End If
        vform.Field = "SLCODE,slname"
        ' vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ACCOUNT CODE HELP"
        ' vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid1
                .Col = 6
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 7
                .Row = .ActiveRow
                .Text = vform.keyfield1
            End With
        Else
            ssgrid1.SetActiveCell(0, ssgrid1.ActiveRow)
            Exit Sub
        End If
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        ' ''Dim i As Integer
        ' ''Dim itemcd, acccd, ssql As String
        ' ''If ssgrid1.DataRowCnt <= 1 Then
        ' ''    MsgBox("NO RECORD TO SAVE")
        ' ''    Exit Sub
        ' ''End If
        ' ''With ssgrid1
        ' ''    For i = 0 To ssgrid1.DataRowCnt - 1
        ' ''        .Row = i + 1
        ' ''        .Col = 1
        ' ''        itemcd = .Text
        ' ''        .Col = 3
        ' ''        acccd = .Text
        ' ''        ssql = "update itemmaster set salesacctin='" & acccd & "' where itemcode='" & itemcd & "'"
        ' ''        Vconn.dataOperation(6, ssql, "item")

        ' ''    Next
        ' ''End With
        ' ''MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim i As Integer
        Dim code As String
        Dim source1, itemcode, desc As String

        With ssgrid1
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 4
                code = .Text

                If Trim(code) = "" Then
                    MessageBox.Show("SALES ACCOUNT CODE CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                .Row = i
                .Col = 1
                source1 = .Text
                If Trim(source1) <> "" Then
                    .Row = i
                    .Col = 2
                    itemcode = .Text
                    If Trim(itemcode) = "" Then
                        MessageBox.Show("ITEM CODE CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    .Row = i
                    .Col = 3
                    desc = .Text
                    If Trim(desc) = "" Then
                        MessageBox.Show("ITEM DESCRIPTION CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If


            Next i
        End With

        Dim itemcd, acccd, subacccd, SOURCE, ssql, sflag, costcode As String
        If ssgrid1.DataRowCnt <= 1 Then
            MsgBox("NO RECORD TO SAVE")
            Exit Sub
        End If

        With ssgrid1
            For i = 0 To ssgrid1.DataRowCnt - 1
                .Row = i + 1
                .Col = 1
                SOURCE = .Text
                .Col = 2
                itemcd = .Text
                .Col = 4
                acccd = .Text
                ssql = " select ISNULL(accode,'')AS ACCODE,ISNULL(acdesc,'') ACDESC,isnull(subledgerflag,'N') as subledgerflag from accountsglaccountmaster WHERE ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(acccd) & " '"
                Vconn.getDataSet(ssql, "acctag")
                If gdataset.Tables("acctag").Rows.Count = 0 Then
                    MessageBox.Show("ACCOUNT CODE NOT MATCHING ", MyCompanyName, MessageBoxButtons.OK)
                    .SetActiveCell(4, i + 1)
                    Exit Sub
                Else
                    sflag = UCase(gdataset.Tables("acctag").Rows(0).Item(2))
                End If
                .Col = 6
                subacccd = .Text
                If sflag = "Y" Then
                    ssql = " select SLCODE,ISNULL(slname,'') AS SLNAME from ACCOUNTSSUBLEDGERMASTER WHERE ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(acccd) & "' AND slcode = '" & Trim(subacccd) & "'"
                    Vconn.getDataSet(ssql, "acctag1")
                    If gdataset.Tables("acctag1").Rows.Count = 0 Then
                        MessageBox.Show("ACCOUNT CODE NOT MATCHING ", MyCompanyName, MessageBoxButtons.OK)
                        .SetActiveCell(6, i + 1)
                        Exit Sub
                    End If
                Else
                    subacccd = ""
                End If

                .Col = 8
                costcode = .Text

                If SOURCE = "POS" Then
                    'ssql = "update itemmaster set salesacctin='" & acccd & "',SUBGLACCODE='" & subacccd & "' where itemcode='" & itemcd & "'"
                    'Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "TARIFF" Then
                    ssql = "update party_tariffhdr set salesacctin='" & acccd & "',SUBGLACCODE='" & subacccd & "',COSTCODE='" & costcode & "' where TARIFFCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                ''If SOURCE = "ARRANGEMENT" Then
                ''    ssql = "update PARTY_ARRANGEMASTER_HDR set GLACCODE='" & acccd & "' where ARRCODE='" & itemcd & "'"
                ''    Vconn.dataOperation(6, ssql, "item")
                ''End If
                If SOURCE = "HALL" Then
                    ssql = "update PARTY_HALLMASTER_HDR set GLACCODE='" & acccd & "',SUBGLACCODE='" & subacccd & "',COSTCODE='" & costcode & "' where HALLTYPECODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "ARRANGEMENT" Then
                    ssql = "update PARTY_ITEMMASTER set GLACCODE='" & acccd & "',SUBGLACCODE='" & subacccd & "',COSTCODE='" & costcode & "' where ITEMCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "OTHERS" Then
                    ssql = "update Party_OtherChgsMaster set GLACCODE='" & acccd & "',SUBGLACCODE='" & subacccd & "',COSTCODE='" & costcode & "' where ITEMCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If

                SQLSTRING = "select 'PARTYMENU'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.GLACCODE,'') as accode,isnull(b.acdesc,'') as acdesc  from PARTY_ITEMMASTER a left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y'  "

            Next
        End With
        MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        ssgrid1.ClearRange(1, 1, ssgrid1.DataColCnt, ssgrid1.DataRowCnt, False)
        Call AccountItemTagging_Load(sender, e)
    End Sub
End Class