Imports System.Data
Imports System.data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic

Public Class GlobalClass
    Public sqlconnection1 As String
    Public Myconn As New sqlconnection
    Dim MyTrans As SqlTransaction
    Dim Cmd As New SqlCommand
    Dim DataString As String
    Dim strcn As String = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & ";pwd=" & strDataSqlPwd & ";Initial Catalog=  " & gDatabase & ";"
    Public sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & ";pwd=" & strDataSqlPwd & ";Initial Catalog=  " & gDatabase & ";"
    Dim ssql As String
    Public Enum genum
        Add = 1
        Update = 2
        Freeze = 3
        unFreeze = 4
        View = 5
        Delete = 6
    End Enum
    Function getvalue(ByVal QryString As String)
        Dim objVariable As Object
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Cmd.Connection = Myconn
            Cmd.CommandText = QryString
            Cmd.CommandTimeout = 999999
            Cmd.CommandType = CommandType.Text
            objVariable = Cmd.ExecuteScalar()
            Myconn.Close()
            Return objVariable
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            Myconn.Close()
        End Try
    End Function
    Public Function getDataSet(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            openConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 999999
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Sub dataOperation1(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''

            Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    'Public Function CloseSmartDevicePort()
    '    Dim RETVALUE, HANDLE As Integer
    '    RETVALUE = ACR120U.ACR120_Close(HANDLE)
    'End Function
    'Public Function GetSMARTDEVICEPORT()
    '    Try
    '        Dim RETVALUE As Integer
    '        RETVALUE = ACR120U.ACR120_Open(ACR120U.PORTS.ACR120_USB1)
    '        'RETVALUE = ACR120U.ACR120_Open(CInt(GBL_SMARTDEVICEPORT))
    '        If RETVALUE < 0 Then
    '            MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
    '        Else
    '            '  MsgBox("SMART CARD DEVICE CONNECTION SUCCESSFUL", MsgBoxStyle.Information, "CONNECTED")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
    '    End Try
    'End Function
    'Public Function GetSMART_CARDID()
    '    Call CloseSmartDevicePort()
    '    Call GetSMARTDEVICEPORT()
    '    Dim RETVALUE, HANDLE As Integer
    '    'Variable Declarations
    '    Dim ResultSN(11) As Byte
    '    Dim ResultTag As Byte
    '    Dim ctr As Integer
    '    Dim TagType(50) As Byte

    '    RETVALUE = ACR120U.ACR120_Select(HANDLE, TagType(0), ResultTag, ResultSN(0))

    '    GBL_SMARTCARDSNO = ""
    '    For ctr = 0 To ResultTag - 1
    '        GBL_SMARTCARDSNO = GBL_SMARTCARDSNO + Format_Hex2(ResultSN(ctr))
    '    Next
    'End Function
    Public Function Format_Hex2(ByVal NUM As Integer) As String

        'Format Byte into two-digit Hex
        Format_Hex2 = Microsoft.VisualBasic.Right("00" & Hex(NUM), 2)

    End Function

    Public Function getCompanyinfo(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            Call GetfrontConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 999999
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function MORETRANS(ByVal str() As String)
        Dim i, ra As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.CommandTimeout = 999999
            Cmd.Connection = Myconn
            rac = 0
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    ra = Cmd.ExecuteNonQuery()
                    If ra < 1 Then
                        If str.Length - 1 <> i Then
                            rac = rac + 1
                        End If
                    End If
                End If
            Next i
            If rac = 0 Then
                MyTrans.Commit()
                MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            rac = 1
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTransold(ByVal str() As String)
        Dim i As Integer
        Try

            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            ' MyCompanyName = "KGA"
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandTimeout = 999999
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i

            MyTrans.Commit()
            Myconn.Close()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            rac = 1
            dblMsg = 1
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("PLEASE PRESS ENTER AGAIN" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTransold1(ByVal str() As String)
        Dim i As Integer
        Try
            'Myconn.Close()
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandTimeout = 999999
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            'MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            rac = 1
            dblMsg = 1
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("PLEASE PRESS ENTER AGAIN", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Sub dataOperation(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            openConnection()
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
            Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    gadapter.SelectCommand.CommandTimeout = 999999
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 999999
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                Case 7
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                Case 8
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gcommand.CommandTimeout = 999999
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                Case 9
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub

    Public Sub dataOperation_auto(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Dim dt As New DataTable
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
            Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    gadapter.SelectCommand.CommandTimeout = 999999
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 999999
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                Case 7
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 999999
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                Case 8
                    ''=====================
                    '''gadapter = New SqlDataAdapter(ssql, Myconn)
                    '''gadapter.Fill(dt)
                    '''dt.TableName = Tabname
                    '''If gdataset.Tables.Contains(Tabname) = True Then
                    '''    gdataset.Tables.Remove(Tabname)
                    '''End If
                    '''gdataset.Tables.Add(dt)
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 999999
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteScalar()


                    ''=====================
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub openConnection()
        Try
            If Trim(gserver & "") <> "" Then
                'sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=sa;Initial Catalog= " & gDatabase & ";"
                'sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
                Myconn.ConnectionString = "Data Source= " & Trim(gserver) & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog=" & Trim(gDatabase)
            Else
                'sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=sa;Initial Catalog= " & gDatabase & ";"
                sqlconnection = "Data Source=(local):Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            End If
            'Myconn.ConnectionString = sqlconnection

            If Myconn.State = ConnectionState.Open Then
                Myconn.Close()
            End If
            Myconn.Open()
            'Myconn.ConnectionString = "Data Source= " & Trim(gserver) & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog=" & Trim(gDatabase)
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER, Bcoz " & ex.Message.ToString, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub GetfrontConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= MASTER;"
            Else
                sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=" & strDataSqlUsr & ";  pwd=" & strDataSqlPwd & "; Initial Catalog= MASTER;"
            End If
            Myconn.ConnectionString = sqlconnection1
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with Master SERVER, Bcoz " & ex.Message.ToString, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub closeConnection()
        Myconn.Close()
    End Sub
    Public Function GetValues(ByVal ssql As String) As DataTable
        Dim Dt As New DataTable
        Dim Sqladapter As New SqlDataAdapter(ssql, Myconn)
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Sqladapter.SelectCommand.CommandTimeout = 999999
            Sqladapter.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function ExcuteStoreProcedure(ByVal qry As String)
        Dim i As Integer
        Myconn.ConnectionString = sqlconnection
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.CommandTimeout = 999999
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function Getconnection() As String
        Try
            '            sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=sa;Initial Catalog= " & gDatabase & ";"

            If Trim(gserver & "") <> "" Then
                'sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=sa;Initial Catalog= " & gDatabase & ";"
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            Else
                'sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=sa;Initial Catalog= " & gDatabase & ";"
                sqlconnection = "Data Source=(local):Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            End If
            Return sqlconnection
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER, Bcoz " & ex.Message.ToString, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Public Function MoreTrans1(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandTimeout = 999999
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function


    Public Sub subPrintHeader(ByVal strCaption As String, ByVal strColumnHead As String, ByVal intLength As Int16, ByVal boolCondensed As Boolean)
        Dim strHead As String
        Filewrite.WriteLine(Chr(27) + "E" & Trim(Mid(Trim(gMAINCompanyname), 1, 50)) & Chr(27) + "F" & Chr(18))
        If Trim(gCompanyAddress(0)) <> "" Then
            Filewrite.WriteLine(Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F" & Chr(18))
        End If
        If Trim(gCompanyAddress(1)) <> "" Then
            strHead = gCompanyAddress(1)
        End If
        If Trim(gCompanyAddress(2)) <> "" Then
            If Trim(strHead) <> "" Then
                Filewrite.WriteLine(Chr(27) + "E" & strHead & "," & Trim(gCompanyAddress(2)) & Chr(27) + "F" & Chr(18))
            Else
                Filewrite.WriteLine(Chr(27) + "E" & Trim(gCompanyAddress(2)) & Chr(27) + "F" & Chr(18))
            End If
        Else
            If Trim(strHead) <> "" Then
                Filewrite.WriteLine(Chr(27) + "E" & gCompanyAddress(1) & Chr(27) + "F" & Chr(18))
            End If
        End If
        If Trim(gCompanyAddress(3)) <> "" Then
            Filewrite.WriteLine(Chr(27) + "E" & gCompanyAddress(3) & Chr(27) + "F" & Chr(18))
        End If

        If Len(Trim(strCaption)) > 80 Then
            Filewrite.WriteLine(Chr(15) & strCaption & Chr(18))
        Else
            Filewrite.WriteLine(Chr(27) + "E" & strCaption & Chr(27) + "F" & Chr(18))
        End If

        Filewrite.WriteLine(Chr(27) + "E" & "ACCOUNTING PERIOD : " & CStr(Format(DateValue(strFinancialYearStart), "dd/MMM/yyyy")) & " - " & CStr(Format(DateValue(strFinancialYearEnd), "dd/MMM/yyyy")) & Chr(27) + "F" & Chr(18))

        subWriteLine(intLength, boolCondensed)
        If boolCondensed = True Then
            Filewrite.WriteLine(Chr(15) & strColumnHead & Chr(18))
        Else
            Filewrite.WriteLine(strColumnHead)
        End If
        subWriteLine(intLength, boolCondensed)
    End Sub
    Public Sub subPrintFooter(ByVal intLength As Int16, ByVal intPageNumber As Int16, ByVal boolCondensed As Boolean)
        Dim strFoot As String
        strFoot = "User :- " & gUsername & Space(((intLength / 2) - 5) - Len("USER :- " & gUsername)) & "Page - " & CStr(intPageNumber)
        strFoot = strFoot & Space(intLength - (Len(strFoot) + 22)) & CStr(Format(DateValue(Now()), "dd/MMM/yyyy")) & " " & Trim(Now.ToShortTimeString()) & Chr(12)
        If boolCondensed = True Then
            Filewrite.WriteLine(Chr(15) & strFoot & Chr(18))
        Else
            Filewrite.WriteLine(strFoot)
        End If

    End Sub
    Public Sub subWriteLine(ByVal intLine As Int16, ByVal boolCondensed As Boolean)
        Dim I As Int16
        Dim strLine
        For I = 1 To intLine
            strLine = strLine & "="
        Next
        If boolCondensed = True Then
            Filewrite.WriteLine(Chr(15) & strLine & Chr(18))
        Else
            Filewrite.WriteLine(strLine)
        End If
    End Sub
    Public Function getDataSetTest(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            openConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 100000
            gadapter.Fill(dt)
            gtrans = Myconn.BeginTransaction
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
            gtrans.Commit()
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function FillDataSet(ByVal strSQL As String, ByVal Tabname As String)
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Dim dt As New DataTable
            dt.Rows.Clear()
            If fdataset.Tables.Contains(Tabname) = True Then
                fdataset.Tables.Remove(Tabname)
            End If
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 100000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            fdataset.Tables.Add(dt)
        Catch ex As Exception
            MsgBox("Error in Retrieving Data " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        Finally
            closeConnection()
        End Try
    End Function
    'CSC SMARTCARD
    Public Function SaveFoto(ByVal FilePath As String, ByVal Cardid As String)
        Try


            '##### IN CASE NO PHOTO SELECTED ##### 
            If Trim(FilePath) = "" Then
                Exit Function
            End If
            '##### ##### ##### ##### ##### ##### #

            Dim cn As New SqlConnection(strcn)
            Dim cmd As New SqlCommand("update sm_cardfile_hdr set memimage " & _
                " = @memimage where [16_digit_code] = '" & Cardid & "' ", cn)

            Dim fsPhotoFile As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim bytMEMimage(fsPhotoFile.Length() - 1) As Byte
            fsPhotoFile.Read(bytMEMimage, 0, bytMEMimage.Length)
            fsPhotoFile.Close()
            Dim prm As New SqlParameter("@memimage", SqlDbType.VarBinary, _
                bytMEMimage.Length, ParameterDirection.Input, False, _
                0, 0, Nothing, DataRowVersion.Current, bytMEMimage)
            cmd.Parameters.Add(prm)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Foto_LOAD(ByVal CARDCODE As TextBox, ByVal PIC As PictureBox)
        Dim PHOTOFILENAME As String
        If Mid(Trim(CARDCODE.Text), Len(Trim(CARDCODE.Text)) - 1, 2) = "00" Then
            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(CARDCODE.Text), 1, Len(Trim(CARDCODE.Text)) - 3) & ".jpg"
            PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")

            If File.Exists(PHOTOFILENAME) Then
                PIC.Image = New Bitmap(PHOTOFILENAME)
            Else
                If File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                End If
            End If
        Else
            If Mid(Trim(CARDCODE.Text), Len(Trim(CARDCODE.Text)) - 1, 2) = "01" Then
                PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(CARDCODE.Text) & ".jpg"
            Else
                PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(CARDCODE.Text) & ".jpg"
            End If
            PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")
            If File.Exists(PHOTOFILENAME) Then
                PIC.Image = New Bitmap(PHOTOFILENAME)
            Else
                If File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                End If
            End If
        End If
    End Function
    Public Sub LoadFoto_DB_MemberMaster_SPOUSE(ByVal CARDID As TextBox, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMDET WHERE MEm_CODE ='" & Trim(CARDID.Text) & "'AND RELATION='SPOUSE' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                If PIC.Visible = True Then
                    PIC.Visible = False
                End If

            End If
        Catch ex As Exception
            If PIC.Visible = True Then
                PIC.Visible = False
            End If
            '            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadFoto_DB_MemberMaster_CHILD2(ByVal CARDID As TextBox, ByVal CHNAME As String, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMDET WHERE MEm_CODE ='" & Trim(CARDID.Text) & "'AND RELATION IN('SON','DAUGHTER') AND TYPE0='CHLD' AND CHILD_NM='" & CHNAME & "' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                If PIC.Visible = True Then
                    PIC.Visible = False
                End If

            End If
        Catch ex As Exception
            'If PIC.Visible = True Then
            '    PIC.Visible = False
            'End If
            '            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadFoto_DB_MemberMaster_CHILD1(ByVal CARDID As TextBox, ByVal CHNAME As String, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMDET WHERE MEm_CODE ='" & Trim(CARDID.Text) & "'AND RELATION IN('SON','DAUGHTER') AND TYPE0='CHLD' AND CHILD_NM='" & CHNAME & "' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                If PIC.Visible = True Then
                    PIC.Visible = False
                End If

            End If
        Catch ex As Exception
            If PIC.Visible = True Then
                PIC.Visible = False
            End If
            '            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadFoto_DB_MemberMaster(ByVal CARDID As TextBox, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMBERMASTER WHERE MCODE ='" & Trim(CARDID.Text) & "' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                If PIC.Visible = True Then
                    PIC.Visible = False
                End If

            End If
        Catch ex As Exception
            If PIC.Visible = True Then
                PIC.Visible = False
            End If
            '            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadFoto_DB_MemberMaster(ByVal CARDID As TextBox, ByVal CARDNAME As TextBox, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMPHOTO WHERE MCODE ='" & Trim(CARDID.Text) & "' AND MNAME='" & Trim(CARDNAME.Text) & "' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                'If PIC.Visible = True Then
                '    PIC.Visible = False
                'End If

            End If
        Catch ex As Exception
            If PIC.Visible = True Then
                PIC.Visible = False
            End If
            '            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadFoto_DB_MemberMasterSEARCH(ByVal CARDID As String, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            If PIC.Visible = False Then
                PIC.Visible = True
            End If

            sqlstr = "SELECT * FROM MEMBERMASTER WHERE MCODE ='" & Trim(CARDID) & "' AND MEMIMAGE IS NOT NULL"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                ' PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                If PIC.Visible = True Then
                    PIC.Visible = False
                End If

            End If
        Catch ex As Exception
            If PIC.Visible = True Then
                PIC.Visible = False
            End If
            '            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadFoto_DB(ByVal CARDID As TextBox, ByVal PIC As PictureBox)
        Try
            Dim cn As New SqlConnection(strcn)
            Dim sqlstr As String
            sqlstr = "SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] ='" & Trim(CARDID.Text) & "' AND [16_DIGIT_CODE] NOT IN ( SELECT [16_DIGIT_CODE] FROM SM_CARDFILE_HDR WHERE [16_digit_code] = '" & Trim(CARDID.Text) & "' AND MEMIMAGE IS NULL)"
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "sm_image")
            Dim c As Integer = ds.Tables("SM_IMAGE").Rows.Count
            If c > 0 Then
                Dim bytMEMimage() As Byte = ds.Tables("SM_IMAGE").Rows(c - 1)("memimage")
                Dim stmMEMimage As New MemoryStream(bytMEMimage)
                PIC.Image = Image.FromStream(stmMEMimage)
            Else
                PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                'PIC.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub FOTO_LOAD_MCC(ByVal TXT_CARDCODE As TextBox, ByVal PIC_MEMBER As PictureBox)
        'Show PHOTOS
        Dim PHOTOFILENAME As String
        'If Mid(Trim(Txt_CardCode.Text), Len(Trim(Txt_CardCode.Text)) - 2, 3) = "TMP" Then

        If Mid(Trim(TXT_CARDCODE.Text), Len(Trim(TXT_CARDCODE.Text)) - 2, 3) = "TMP" Then
            If Mid(Trim(TXT_CARDCODE.Text), Len(Trim(TXT_CARDCODE.Text)) - 5, 2) = "00" Then
                If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                    If Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 9) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 10) & ".jpg"
                    End If
                Else
                    If Len(Trim(TXT_CARDCODE.Text)) - 4 = 7 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text)) - 8) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 8 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text)) - 9) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 10) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text)) - 11) & ".jpg"
                    End If
                End If
                'PHOTOFILENAME = STRPHOTOPATH & "\" & "P" & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3) & ".jpg"
                PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")

                If File.Exists(PHOTOFILENAME) Then
                    PIC_MEMBER.Image = New Bitmap(PHOTOFILENAME)
                Else
                    PIC_MEMBER.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                End If
            Else
                If Mid(Trim(TXT_CARDCODE.Text), Len(Trim(TXT_CARDCODE.Text)) - 1, 2) = "01" Then
                    ' PHOTOFILENAME = STRPHOTOPATH & "\" & Trim("SS" & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3)) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(txt_Holder_Code.Text) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(txt_Holder_Code.Text), 1, Len(Trim(txt_Holder_Code.Text)) - 3) & ".jpg"
                    If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                        If Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 5) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                        End If
                    Else
                        If Len(Trim(TXT_CARDCODE.Text)) - 4 = 7 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text)) - 5) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 8 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 7) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text)) - 8) & ".jpg"
                        End If
                    End If
                Else
                    ' PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(Txt_Cardcode.Text), Len(Trim(Txt_Cardcode.Text)) - 1, 2) & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(txt_Holder_Code.Text) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(txt_Holder_Code.Text), 1, Len(Trim(txt_Holder_Code.Text)) - 3) & ".jpg"
                    If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                        If Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 7) & ".jpg"
                        End If
                    Else
                        'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(Txt_Cardcode.Text), Len(Trim(Txt_Cardcode.Text)) - 1, 2) & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3) & ".jpg"
                        If Len(Trim(TXT_CARDCODE.Text)) - 4 = 7 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text)) - 5) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 8 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 7) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) - 4 = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text)) - 8) & ".jpg"
                        End If
                    End If

                End If
                PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")
                If File.Exists(PHOTOFILENAME) Then
                    PIC_MEMBER.Image = New Bitmap(PHOTOFILENAME)
                Else
                    PIC_MEMBER.Image = New Bitmap(STRPHOTOPATH & "\NOPHOTO.Jpg")
                End If
            End If


        Else

            If Mid(Trim(TXT_CARDCODE.Text), Len(Trim(TXT_CARDCODE.Text)) - 1, 2) = "00" Then
                'PHOTOFILENAME = STRPHOTOPATH & "\" & "P" & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3) & ".jpg"

                If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                    If Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                    End If
                Else

                    If Len(Trim(TXT_CARDCODE.Text)) = 7 Then

                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text)) - 4) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) = 8 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text)) - 5) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text)) - 6) & ".jpg"
                    ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                        PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text)) - 7) & ".jpg"
                    End If
                End If

                'ORIGINAL

                'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(Txt_Cardcode.Text), 1, 1) & "-" & Mid(Trim(Txt_Cardcode.Text), 2, Len(Trim(Txt_Cardcode.Text))) & ".jpg"
                PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")

                If File.Exists(PHOTOFILENAME) Then
                    PIC_MEMBER.Image = New Bitmap(PHOTOFILENAME)
                Else
                    'Pic_Member.Image = New Bitmap(STRPHOTOPATH & "\NOPHOTO.Jpg")
                    PIC_MEMBER.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                End If
            Else
                If Mid(Trim(TXT_CARDCODE.Text), Len(Trim(TXT_CARDCODE.Text)) - 1, 2) = "01" Then
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Trim("SS" & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3)) & ".jpg"

                    If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                        If Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        End If
                    Else
                        If Len(Trim(TXT_CARDCODE.Text)) = 7 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 8 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        End If
                    End If
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(txt_Holder_Code.Text) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(txt_Holder_Code.Text), 1, Len(Trim(txt_Holder_Code.Text)) - 3) & ".jpg"
                Else
                    If Mid(Trim(TXT_CARDCODE.Text), 1, 3) = "INV" Then
                        If Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        End If
                    Else
                        'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(Txt_Cardcode.Text), Len(Trim(Txt_Cardcode.Text)) - 1, 2) & Mid(Trim(Txt_Cardcode.Text), 1, Len(Trim(Txt_Cardcode.Text)) - 3) & ".jpg"
                        If Len(Trim(TXT_CARDCODE.Text)) = 7 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 1) & "-" & Mid(Trim(TXT_CARDCODE.Text), 2, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 8 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 2) & "-" & Mid(Trim(TXT_CARDCODE.Text), 3, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 9 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 3) & "-" & Mid(Trim(TXT_CARDCODE.Text), 4, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        ElseIf Len(Trim(TXT_CARDCODE.Text)) = 10 Then
                            PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(TXT_CARDCODE.Text), 1, 4) & "-" & Mid(Trim(TXT_CARDCODE.Text), 5, Len(Trim(TXT_CARDCODE.Text))) & ".jpg"
                        End If
                    End If
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Trim(Txt_CardHolderName.Text) & ".jpg"
                    'PHOTOFILENAME = STRPHOTOPATH & "\" & Mid(Trim(Txt_CardHolderName.Text), 1, Len(Trim(Txt_CardHolderName.Text)) - 3) & ".jpg"

                End If
                PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")
                If File.Exists(PHOTOFILENAME) Then
                    PIC_MEMBER.Image = New Bitmap(PHOTOFILENAME)
                Else
                    'Pic_Member.Image = New Bitmap(STRPHOTOPATH & "\NOPHOTO.Jpg")
                    PIC_MEMBER.Image = New Bitmap(AppPath & "\NOPHOTO.Jpg")
                End If
            End If
        End If
        'KARTHI ENDS
    End Sub
    Public Function Foto_LOAD_NIZAM(ByVal CARDCODE As TextBox, ByVal PIC As PictureBox)
        Dim PHOTOFILENAME As String
        If Mid(Trim(CARDCODE.Text), Len(Trim(CARDCODE.Text)) - 1, 2) = "00" Then
            PHOTOFILENAME = STRPHOTOPATH & "\P" & Mid(Trim(CARDCODE.Text), 1, Len(Trim(CARDCODE.Text)) - 3) & ".jpg"
            PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")

            If File.Exists(PHOTOFILENAME) Then
                PIC.Image = New Bitmap(PHOTOFILENAME)
            Else
                If File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                End If
            End If
        Else
            If Mid(Trim(CARDCODE.Text), Len(Trim(CARDCODE.Text)) - 1, 2) = "01" Then
                PHOTOFILENAME = STRPHOTOPATH & "\SS" & Mid(Trim(CARDCODE.Text), 1, Len(Trim(CARDCODE.Text)) - 3) & ".jpg"
            Else
                PHOTOFILENAME = STRPHOTOPATH & "\SS" & Mid(Trim(CARDCODE.Text), 1, Len(Trim(CARDCODE.Text)) - 3) & ".jpg"
            End If
            PHOTOFILENAME = Replace(PHOTOFILENAME, " ", "")
            If File.Exists(PHOTOFILENAME) Then
                PIC.Image = New Bitmap(PHOTOFILENAME)
            Else
                If File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    PIC.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                End If
            End If
        End If
    End Function
    Public Function FileInfo(ByVal MyFilePath As String)
        If File.Exists(MyFilePath) Then
            Dim MyFile As New FileInfo(MyFilePath)
            Filepath = MyFilePath
            FileSize = MyFile.Length
            dtCreationDate = MyFile.CreationTime
            dtLastAccessTime = MyFile.LastAccessTime
            dtLastWriteTime = MyFile.LastWriteTime
        End If
    End Function
End Class
