Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Net

Module globalFunction
    Dim regexp As Regex
    Public boolexp As Boolean = False
    Public boolexp1 As Boolean = False
    Public boolexp2 As Boolean = False
    Public G_dout(15) As Byte
    Public SendBuff(262), RecvBuff(262) As Byte
    Public hContext, hcard As Long
    Public connActive, validATS As Boolean
    Public SendLen, RecvLen, nBytesRet, reqType, Aprotocol As Integer
    Public dwProtocol As Integer
    Public cbPciLength As Integer
    Public dwState, dwActProtocol, Protocol As Long
    Public pioSendRequest, pioRecvRequest As SCARD_IO_REQUEST

    Dim gconnection As New GlobalClass
    'Dim GPort As New GlobalClass
    'Public Function CloseSmartDevicePort()
    '    Dim RETVALUE, HANDLE As Integer
    '    RETVALUE = ACR120U.ACR120_Close(HANDLE)
    'End Function
    Public Function GetPass(ByVal vUser As String) As String
        Dim Vdesc As String
        Dim vAsc As Long
        Dim vPass As String
        Dim Loopindex As Long
        Vdesc = ""
        For Loopindex = 1 To Len(vUser)
            Vdesc = Mid(vUser, Loopindex, 1)
            vAsc = Asc(Vdesc) + 150
            vPass = Trim(vPass) & Chr(vAsc)
        Next Loopindex
        GetPass = vPass
    End Function
    Public Function CloseSmartDevicePort()
        'Dim RETVALUE, HANDLE As Integer
        'RETVALUE = ACR120U.ACR120_Close(HANDLE)
        Dim RETVALUE, HANDLE As Integer
        If UCase(gCompanyname) = "KARNATAKA GOLF ASSOCIATION" Then
        Else
            If greadertype = "ACR120U" Then
                RETVALUE = ACR120U.ACR120_Close(HANDLE)
            Else
                If connActive Then

                    retcode = ModWinsCard.SCardDisconnect(hcard, ModWinsCard.SCARD_UNPOWER_CARD)

                End If

                '' Shared Connection
                'retcode = ModWinsCard.SCardConnect(hContext, greadertype.ToString(), ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)

                'If retcode <> ModWinsCard.SCARD_S_SUCCESS Then
                '    Exit Function


                'Else

                '    ' Call displayOut(0, 0, "Successful connection to " & cbReader.Text)

                'End If

                connActive = False
            End If
        End If
    End Function
    Public Function GetSMARTDEVICEPORT()
         Try
            Dim RETVALUE As Integer
            If UCase(gCompanyname) = "KARNATAKA GOLF ASSOCIATION" Then
            Else
                If greadertype = "ACR120U" Then
                    RETVALUE = ACR120U.ACR120_Open(ACR120U.PORTS.ACR120_USB1)
                    'RETVALUE = ACR120U.ACR120_Open(CInt(GBL_SMARTDEVICEPORT))
                    If RETVALUE < 0 Then
                        If cardprent = False Then
                            cardprent = True
                            MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")

                        End If
                    Else
                        cardprent = False
                        '  MsgBox("SMART CARD DEVICE CONNECTION SUCCESSFUL", MsgBoxStyle.Information, "CONNECTED")
                    End If
                Else
                    retcode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)
                    If connActive Then
                        retcode = ModWinsCard.SCardDisconnect(hcard, ModWinsCard.SCARD_UNPOWER_CARD)
                    End If
                    ' Shared Connection
                    retcode = ModWinsCard.SCardConnect(hContext, greadertype.ToString(), ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hcard, Protocol)

                    If retcode <> ModWinsCard.SCARD_S_SUCCESS Then
                        Exit Function
                    Else
                        ' Call displayOut(0, 0, "Successful connection to " & cbReader.Text)
                    End If
                    connActive = True
                End If
            End If
        Catch ex As Exception
            MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
        End Try

    End Function
    Public Function GetSMART_CARDID1()
        Dim RETVALUE, HANDLE As Integer
        'Variable Declarations
        Dim ResultSN(11) As Byte
        Dim ResultTag As Byte
        Dim ctr As Integer
        Dim TagType(50) As Byte

        RETVALUE = ACR120U.ACR120_Select(HANDLE, TagType(0), ResultTag, ResultSN(0))

        GBL_SMARTCARDSNO = ""
        For ctr = 0 To ResultTag - 1
            GBL_SMARTCARDSNO = GBL_SMARTCARDSNO + Format_Hex2(ResultSN(ctr))
        Next
    End Function
    Public Function GetSMART_CARDID()
        If UCase(gCompanyname) = "KARNATAKA GOLF ASSOCIATION" Then
            GBL_SMARTCARDSNO = ""
            Dim gen As New Class1
            Dim s As String()
            gen.Main(s)
        Else
            If greadertype = "ACR120U" Then
                Call CloseSmartDevicePort()
                Call GetSMARTDEVICEPORT()
                Dim RETVALUE, HANDLE As Integer
                'Variable Declarations
                Dim ResultSN(11) As Byte
                Dim ResultTag As Byte
                Dim ctr As Integer
                Dim TagType(50) As Byte

                RETVALUE = ACR120U.ACR120_Select(HANDLE, TagType(0), ResultTag, ResultSN(0))

                GBL_SMARTCARDSNO = ""
                For ctr = 0 To ResultTag - 1
                    GBL_SMARTCARDSNO = GBL_SMARTCARDSNO + Format_Hex2(ResultSN(ctr))
                Next
            Else
                Dim tmpStr As String
                Dim indx As Integer
                GBL_SMARTCARDSNO = ""
                tmpStr = ""
                validATS = False
                Call ClearBuffers()
                SendBuff(0) = &HFF                              ' CLA
                SendBuff(1) = &HCA                              ' INS

                'If cbIso14443A.Checked Then

                '    SendBuff(2) = &H1                           ' P1 : ISO 14443 A Card

                'Else

                SendBuff(2) = &H0                           ' P1 : Other cards

                'End If

                SendBuff(3) = &H0                               ' P2
                SendBuff(4) = &H0                               ' Le : Full Length

                SendLen = SendBuff(4) + 5
                RecvLen = &HFF

                retcode = SendAPDUandDisplay(3)

                If retcode <> ModWinsCard.SCARD_S_SUCCESS Then

                    Exit Function

                End If


                ' Interpret and display return values
                If validATS Then

                    'If cbIso14443A.Checked Then

                    '    tmpStr = "UID: "

                    'End If


                    For indx = 0 To (RecvLen - 3)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2)

                    Next indx

                    ' displayOut(3, 0, tmpStr.Trim)
                    GBL_SMARTCARDSNO = ""
                    'For ctr = 0 To ResultTag - 1
                    GBL_SMARTCARDSNO = tmpStr
                    'Next
                End If

            End If
        End If
    End Function
    Private Sub ClearBuffers()

        Dim indx As Long

        For indx = 0 To 262

            RecvBuff(indx) = &H0
            SendBuff(indx) = &H0

        Next indx

    End Sub
    Private Function SendAPDUandDisplay(ByVal reqType As Integer) As Integer

        Dim indx As Integer
        Dim tmpStr As String

        pioSendRequest.dwProtocol = 2 '2Aprotocol
        pioSendRequest.cbPciLength = Len(pioSendRequest)

        ' Display Apdu In
        tmpStr = ""
        For indx = 0 To SendLen - 1

            tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(SendBuff(indx)), 2) + " "
            'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(SendBuff(indx)), 2) + ""
        Next indx

        'displayOut(2, 0, tmpStr)
        retCode = ModWinsCard.SCardTransmit(hCard, pioSendRequest, SendBuff(0), SendLen, pioSendRequest, RecvBuff(0), RecvLen)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

            'displayOut(1, retCode, "")
            SendAPDUandDisplay = retCode
            Exit Function

        Else

            tmpStr = ""
            Select Case reqType

                Case 0  '  Display SW1/SW2 value
                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""

                    Next indx

                    If Trim(tmpStr) <> "90 00" Then

                        'displayOut(4, 0, "Return bytes are not acceptable.")

                    End If

                Case 1  ' Display ATR after checking SW1/SW2

                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""

                    Next indx

                    If tmpStr.Trim() <> "90 00" Then

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""

                    Else

                        tmpStr = "ATR : "
                        For indx = 0 To (RecvLen - 3)

                            tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                            'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""
                        Next indx

                    End If

                Case 2  ' Display all data

                    For indx = 0 To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""

                    Next indx

                Case 3  ' Interpret SW1/SW2

                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                        'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + ""

                    Next indx

                    If tmpStr.Trim = "6A 81" Then

                        'displayOut(4, 0, "The function is not supported.")
                        SendAPDUandDisplay = retCode
                        Exit Select

                    End If

                    If tmpStr.Trim = "63 00" Then

                        'displayOut(4, 0, "The operation failed.")
                        SendAPDUandDisplay = retCode
                        Exit Select

                    End If

                    validATS = True

            End Select

            'displayOut(3, 0, tmpStr.Trim())

        End If

        SendAPDUandDisplay = retCode

    End Function
    ' End Function
    'Public Function GetSMARTDEVICEPORT()
    '    Try
    '        Dim RETVALUE As Integer
    '        RETVALUE = ACR120U.ACR120_Open(ACR120U.PORTS.ACR120_USB1)
    '        'RETVALUE = ACR120U.ACR120_Open(CInt(GBL_SMARTDEVICEPORT))
    '        If RETVALUE < 0 Then
    '            If cardprent = False Then
    '                MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
    '                cardprent = True
    '            End If

    '        Else
    '            cardprent = False
    '            '  MsgBox("SMART CARD DEVICE CONNECTION SUCCESSFUL", MsgBoxStyle.Information, "CONNECTED")
    '        End If
    '    Catch ex As Exception
    '        cardprent = True
    '        'MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
    '    End Try
    'End Function
    'Public Function GetSMART_CARDID()
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
    'Public Function GetSMART_CARDIDnoncatholic()
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
    'Public Function GetSMART_CARDID()
    '    'If cardprent = False Then
    '    Call CloseSmartDevicePort()
    '    Call GetSMARTDEVICEPORT()
    '    'If cardprent = False Then
    '    Dim RETVALUE, HANDLE As Integer
    '    'Variable Declarations
    '    GBL_SMARTCARDSNO = ""
    '    Dim ResultSN(11) As Byte
    '    Dim ResultTag As Byte
    '    Dim ctr As Integer
    '    Dim TagType(50) As Byte
    '    'Dim g_retCode As Integer
    '    Dim dataRead(16) As Byte
    '    Dim blck As Byte
    '    Dim dstr As String
    '    Dim TempStr As String
    '    Dim FRMMAIN As New FrmMain
    '    With FRMMAIN


    '        .CONNECT()
    '        .SELECTCARD()
    '        .LOGIN()


    '        If G_retcode < 0 Then
    '            Call GetSMART_CARDIDnoncatholic()
    '        Else
    '            .READBLOCK()
    '            If (G_retcode < 0) Then

    '            Else

    '            End If

    '        End If
    '    End With
    '    ' End If
    '    'End If
    'End Function
    'Public Function GET_SERVERTIME()
    '    Dim sqlstring As String
    '    Try
    '        sqlstring = " Select GETDATE() AS SERVERTIME "
    '        gconnection.getDataSet(sqlstring, "SERVERTIME")
    '        If gdataset.Tables("SERVERTIME").Rows.Count > 0 Then
    '            GBL_SERVERTIME = Format(CDate(gdataset.Tables("SERVERTIME").Rows(0).Item("SERVERTIME")), "dd/MMM/yyyy HH:mm")
    '            GBL_SERVERTIME_SECONDS = Format(CDate(gdataset.Tables("SERVERTIME").Rows(0).Item("SERVERTIME")), "dd/MMM/yyyy HH:mm:ss")
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Function

    'Public Function DLLCLOSE()
    '    Try
    '        ' Dim HANDLE As Integer
    '        ' G_rHandle = ACR120U.ACR120_Close(HANDLE)

    '        G_retcode = ACR120U.ACR120_Close(G_rHandle)

    '        If G_retcode < 0 Then
    '            '  MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CLOSE")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try
    'End Function
    'Public Function DLLCONNECT()
    '    Try
    '        G_rHandle = ACR120U.ACR120_Open(ACR120U.PORTS.ACR120_USB1)
    '        If G_rHandle < 0 Then
    '            MsgBox("PROBLEM IN SMART CARD DEVICE CONNECTION", MsgBoxStyle.Critical, "NOT CONNECTED")
    '            Call DLLCLOSE()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try
    'End Function
    Public Function ConvertHexToString(ByVal HexValue As String) As String
        Dim inputString As String = HexValue
        inputString = inputString.Replace(" ", "")
        Dim StrValue As String = ""
        While inputString.Length > 0
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(inputString.Substring(0, 2), 16)).ToString()
            inputString = inputString.Substring(2, inputString.Length - 2)

        End While
        Return StrValue
    End Function
    'Public Function dlllogin(ByVal sector_l As Integer)
    '    Try
    '        Dim TempStr As String
    '        Dim txt1, txt2, txt3, txt4, txt5, txt6 As String
    '        txt1 = "FF"
    '        txt2 = "FF"
    '        txt3 = "FF"
    '        txt4 = "FF"
    '        txt5 = "FF"
    '        txt6 = "FF"

    '        G_vKeyType = ACR120U.KEYTYPES.ACR120_LOGIN_KEYTYPE_A

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt1, 2)))
    '        G_pKey(0) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt2, 2)))
    '        G_pKey(1) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt3, 2)))
    '        G_pKey(2) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt4, 2)))
    '        G_pKey(3) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt5, 2)))
    '        G_pKey(4) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt6, 2)))
    '        G_pKey(5) = CByte(TempStr)

    '        'set sector
    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & sector_l, 2)))
    '        G_Sec = CInt(TempStr)

    '        If G_Sec > 39 Then

    '            MsgBox("Sector Out of Range. Please Enter value from 0-39 only", MsgBoxStyle.Exclamation, "Log-In Fail")
    '            Exit Function

    '        End If

    '        'Computation for obtaining the actual Physical Sector.
    '        If G_Sec > 31 Then

    '            G_Sec = CInt(TempStr)
    '            G_PhysicalSector = G_Sec + ((G_Sec - 32) * 3)

    '        Else

    '            G_Sec = CInt(TempStr)
    '            G_PhysicalSector = G_Sec

    '        End If

    '        G_retcode = ACR120U.ACR120_Login(G_rHandle, G_PhysicalSector, G_vKeyType, G_StoredNum, G_pKey(0))

    '        'check if retcode is error
    '        If G_retcode < 0 Then
    '            MsgBox("PROBLEM IN SMART CARD login", MsgBoxStyle.Critical, "NOT LOGIN")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try
    'End Function
    Public Function Format_Hex2(ByVal NUM As Integer) As String
        Try
            'Format Byte into two-digit Hex
            Format_Hex2 = Microsoft.VisualBasic.Right("00" & Hex(NUM), 2)
        Catch ex As Exception
            MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    'Public Function DLLSELECT()
    '    Try
    '        Dim RETVALUE, HANDLE As Integer
    '        'Variable Declarations
    '        Dim ResultSN(11) As Byte
    '        Dim ResultTag As Byte
    '        Dim ctr As Integer
    '        Dim TagType(50) As Byte

    '        RETVALUE = ACR120U.ACR120_Select(HANDLE, TagType(0), ResultTag, ResultSN(0))
    '        GBL_SMARTCARDSNO = ""
    '        For ctr = 0 To ResultTag - 1
    '            GBL_SMARTCARDSNO = GBL_SMARTCARDSNO + Format_Hex2(ResultSN(ctr))
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try

    'End Function
    'Public Function DLLREAD()
    '    Try
    '        Dim BLCK As Byte
    '        Dim dataRead(16) As Byte
    '        Dim dStr As String
    '        Dim ctr As Byte


    '        If G_Sec > 31 Then
    '            BLCK = ((G_Sec - 32) * 16) + 128 + BLCK
    '        Else
    '            BLCK = G_Sec * 4 + BLCK
    '        End If
    '        G_BlockNum = BLCK
    '        'read specified block
    '        G_retcode = ACR120U.ACR120_Read(G_rHandle, G_BlockNum, dataRead(0))

    '        'check if retcode is error
    '        If G_retcode < 0 Then
    '            MsgBox("PROBLEM IN SMART CARD login", MsgBoxStyle.Critical, "READ")
    '        End If

    '        dStr = ""
    '        For ctr = 0 To 15
    '            dStr = dStr + Format_Hex2(dataRead(ctr)) + " "
    '        Next

    '        MsgBox("CARD CONTENT...." & dStr, MsgBoxStyle.OKOnly, "CARD READ")

    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try

    'End Function
    'Public Function DLLWRITE(ByVal txt1 As String, ByVal txt2 As String, ByVal txt3 As String, ByVal txt4 As String, ByVal txt5 As String, ByVal txt6 As String, ByVal txt7 As String, ByVal txt8 As String, ByVal txt9 As String, ByVal txt10 As String, ByVal txt11 As String, ByVal txt12 As String, ByVal txt13 As String, ByVal txt14 As String, ByVal txt15 As String, ByVal txt16 As String)
    '    Try
    '        Dim BLCK As Byte
    '        Dim TempStr As String


    '        If G_Sec > 31 Then
    '            BLCK = ((G_Sec - 32) * 16) + 128 + BLCK
    '        Else
    '            BLCK = G_Sec * 4 + BLCK
    '        End If

    '        G_BlockNum = BLCK

    '        'if Hexadecimal was selected convert hex to byte
    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt1, 2)))
    '        G_dout(0) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt2, 2)))
    '        G_dout(1) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt3, 2)))
    '        G_dout(2) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt4, 2)))
    '        G_dout(3) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt5, 2)))
    '        G_dout(4) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt6, 2)))
    '        G_dout(5) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt7, 2)))
    '        G_dout(6) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt8, 2)))
    '        G_dout(7) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt9, 2)))
    '        G_dout(8) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt10, 2)))
    '        G_dout(9) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt11, 2)))
    '        G_dout(10) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt12, 2)))
    '        G_dout(11) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt13, 2)))
    '        G_dout(12) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt14, 2)))
    '        G_dout(13) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt15, 2)))
    '        G_dout(14) = CByte(TempStr)

    '        TempStr = ("&H" & (Microsoft.VisualBasic.Right("00" & txt16, 2)))
    '        G_dout(15) = CByte(TempStr)


    '        'G_dout(0) = Asc(txt1)
    '        'G_dout(1) = Asc(txt2)
    '        'G_dout(2) = Asc(txt3)
    '        'G_dout(3) = Asc(txt4)
    '        'G_dout(4) = Asc(txt5)
    '        'G_dout(5) = Asc(txt6)
    '        'G_dout(6) = Asc(txt7)
    '        'G_dout(7) = Asc(txt8)
    '        'G_dout(8) = Asc(txt9)
    '        'G_dout(9) = Asc(txt10)
    '        'G_dout(10) = Asc(txt11)
    '        'G_dout(11) = Asc(txt12)
    '        'G_dout(12) = Asc(txt13)
    '        'G_dout(13) = Asc(txt14)
    '        'G_dout(14) = Asc(txt15)
    '        'G_dout(15) = Asc(txt16)


    '        'execute ACR120 write, Write to Block
    '        G_retcode = ACR120U.ACR120_Write(G_rHandle, G_BlockNum, G_dout(0))

    '        'check if retcode was error
    '        If G_retcode < 0 Then
    '            MsgBox("PROBLEM IN SMART CARD WRITE", MsgBoxStyle.Critical, "NOT WRITE")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(Err.Description, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try
    'End Function
    Public Function CardIdValidate(ByVal vCardID As String) As Boolean
        Try
            Dim vSQL, vDay, vDate, vMonth As String
            'SHOWN ERROR
            'vTmp = vCardID.Substring(6, 11)
            vTmp = vCardID

            vSQL = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(vTmp) & "' AND ISNULL(CARDCODE,'')<>'' "
            vSQL = vSQL & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(vTmp) & "' AND ISNULL(CARDCODE,'')<>'' "
            gconnection.getDataSet(vSQL, "SM_MEM_LINKAGE1")
            If gdataset.Tables("SM_MEM_LINKAGE1").Rows.Count > 0 Then
                vCardcode = gdataset.Tables("SM_MEM_LINKAGE1").Rows(0).Item("CARDCODE")
            End If

            vDate = Format(DateTime.Today, "dd/MM/yyyy")
            vDay = vDate.Substring(0, 2)
            vMonth = vDate.Substring(3, 2)
            If gdataset.Tables("SM_MEM_LINKAGE1").Rows.Count > 0 Then
                If Len(vTmp) > 13 Then
                    If Trim(vCardID.Substring(0, 2)) = Trim(vDay) And Trim(vCardID.Substring(17, 2)) = Trim(vMonth) Then
                        Cardidcheck = True
                        CardIdValidate = True
                    Else
                        vTmp = " "
                        CardIdValidate = False
                        Cardidcheck = False
                    End If
                Else
                    Cardidcheck = True
                    CardIdValidate = True
                End If

            End If

        Catch ex As Exception
            Cardidcheck = False
            CardIdValidate = False
            Exit Function
        End Try
    End Function

    '*******************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Numeric
    'Function Name:getNumeric
    'Input Type:KeyPressEventArgs
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*******************************************************************
    Public Sub getNumeric(ByVal a As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(a.KeyChar)
            Case 65 To 127
                a.Handled = True
            Case 33 To 38
                a.Handled = True
            Case 40 To 44
                a.Handled = True
            Case 58 To 64
                a.Handled = True
        End Select
    End Sub
    '*************************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Alpha-Numeric
    'Function Name:getAlphanumeric
    'Input Type:KeyPressEventArgs
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*************************************************************************
    Public Sub getAlphanumeric(ByVal b As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(b.KeyChar)
            Case 33 To 47
                b.Handled = True
            Case 58 To 64
                b.Handled = True
            Case 91 To 96
                b.Handled = True
            Case 123 To 135
                b.Handled = True
        End Select
    End Sub
    Public Sub Blank(ByVal b As System.Windows.Forms.KeyPressEventArgs)
        If Asc(b.KeyChar) > 0 And Asc(b.KeyChar) < 225 Then
            b.Handled = True
        End If
    End Sub
    '*************************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Charater
    'Function Name:getCharater
    'Input Type:KeyPressEventArgs
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*************************************************************************
    Public Sub getCharater(ByVal b As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(b.KeyChar)
            Case 33 To 64
                b.Handled = True
            Case 91 To 96
                b.Handled = True
            Case 91 To 96
                b.Handled = True
            Case 123 To 135
                b.Handled = True
        End Select
    End Sub
    '*************************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Alpha-Numeric
    'Function Name:getEmail
    'Input Type:Textbox
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*************************************************************************
    Public Sub getEmail(ByVal txtbox As System.Windows.Forms.TextBox)
        Dim boolexp1 As Boolean = False
        If regexp.IsMatch(txtbox.Text, "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") Then
            boolexp1 = True
            txtbox.ForeColor = Color.Black
        Else
            MsgBox(" E-mail Id field is not in correct format", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Validating Phoneno ")
            txtbox.ForeColor = Color.Red
            txtbox.Select()
            boolexp1 = False
            Exit Sub
        End If
    End Sub
    '*************************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Alpha-Numeric
    'Function Name:getPincode
    'Input Type:Textbox
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*************************************************************************
    'Public Sub getPincode(ByVal txtbox As System.Windows.Forms.TextBox)
    '    Dim boolexp As Boolean = False
    '    If regexp.IsMatch(txtbox.Text, "^\d{5}(-\d{4})?$") Then
    '        boolexp = True
    '        txtbox.ForeColor = Color.Blue
    '    Else
    '        MsgBox(" Pincode field is not in correct format", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Validating Phoneno ")
    '        txtbox.ForeColor = Color.Red
    '        txtbox.Select()
    '        boolexp = False
    '    End If

    'End Sub  P
    '*************************************************************************
    'Purpose:To Validate , Data-entry at End-User.It only allows Alpha-Numeric
    'Function Name:getPhoneno
    'Input Type:Textbox
    'Returm Type:Nothing
    'Auther:Avinash
    'Date:30/08/2006
    '*************************************************************************
    'Public Sub getPhoneno(ByVal txtbox As System.Windows.Forms.TextBox)
    '    If regexp.IsMatch(txtbox.Text, "^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$") Then
    '        boolexp = True
    '        txtbox.ForeColor = Color.Blue
    '    Else
    '        MsgBox(" Phoneno field is not in correct format", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Validating Phoneno ")
    '        txtbox.ForeColor = Color.Red
    '        txtbox.Select()
    '        boolexp = False
    '    End If
    'End Sub
    '************************************************************
    'Purpose: To Clear all the textBox control,within a group Box
    'Function Name: clearPanel
    'Input Type: panel 
    'Return Type:Nothing
    'Author:Avinash
    'Date:30/08/2006
    '************************************************************
    Public Sub clearform(ByVal frm As System.Windows.Forms.Form)
        Dim ctrl As New Control
        For Each ctrl In frm.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = ""
            End If
            If TypeOf ctrl Is ComboBox Then
                ctrl.Text = ""
            End If
            'If ctrl.Visible = False And ctrl.Text <> "" Then
            '    ctrl.Visible = True
            'End If
        Next ctrl
    End Sub

    Public Sub OpenTextFile(ByVal VOutputfile As String)
        If Dir(AppPath & "\Reports\" & Trim(VOutputfile & "") & ".txt") <> "" Then
            If Dir(AppPath & "\Wordpad.exe") <> "" Then
                Shell(AppPath & "\Wordpad.exe " & AppPath & "\Reports\" & VOutputfile & ".txt", vbMaximizedFocus)
            Else
                MessageBox.Show("Wordpad.Exe Not Found in your System", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Else
            MessageBox.Show(VOutputfile & " Not Found in your System", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub
    Public Sub PrintTextFile(ByVal VOutputfile As String)
        Try
            Dim Filewrite As StreamWriter
            If Dir(AppPath & "\Reports\" & Trim(VOutputfile & "") & ".txt") <> "" Then
                Filewrite = File.AppendText(AppPath & "\Reports\" & VOutputfile & ".bat")
                Filewrite.WriteLine("Type " & AppPath & "\Reports\" & VOutputfile & ".txt >prn")
                Filewrite.Close()
                Call Shell(AppPath & "\Reports\" & VOutputfile & ".bat", vbHide)
            Else
                MessageBox.Show(VOutputfile & " Not Found in your System", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Catch
        End Try
    End Sub
    Public Sub PrintTextFile1(ByVal VOutputfile As String)

        Dim Filewrite As StreamWriter
        If Dir(Trim(VOutputfile & "")) <> "" Then
            'If Dir(AppPath & "\Reports\" & Trim(VOutputfile & "") & ".txt") <> "" Then
            VOutputfile = Mid(VOutputfile, 1, VOutputfile.Length - 4)
            Filewrite = File.AppendText(VOutputfile & ".bat")
            If computername = "" Or Printername = "" Then
                Filewrite.WriteLine("Type " & VOutputfile & ".txt > " & gport)
            Else
                Filewrite.WriteLine("Type " & VOutputfile & ".txt > \\" & computername & "\" & Printername)
            End If
            Filewrite.Close()
            'Call Shell(AppPath & "\Reports\GG" & ".bat", vbHide)
            Call Shell(VOutputfile & ".bat", vbHide)
        Else
            MsgBox(VOutputfile & " File not found", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If File.Exists(VOutputfile) Then
            File.Delete(VOutputfile)
        End If
    End Sub
    Public Sub PrintTextFile_Kot(ByVal VOutputfile As String)
        Dim Filewrite As StreamWriter
        If Dir(Trim(VOutputfile & "")) <> "" Then
            VOutputfile = Mid(VOutputfile, 1, VOutputfile.Length - 4)
            Filewrite = File.AppendText(VOutputfile & ".bat")
            If computername = "" Or Printername = "" Then
                Filewrite.WriteLine("Type " & VOutputfile & ".txt >> prn")
                Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
            Else
                Filewrite.WriteLine("Type " & VOutputfile & ".txt > \\" & Kotcomputername & "\" & KotPrintername)
                Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
            End If
            Filewrite.Close()
            Call Shell(VOutputfile & ".bat", vbHide)
        Else
            MessageBox.Show(VOutputfile & " Not Found in your System", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub
    'Public Sub PrintTextFile1(ByVal VOutputfile As String)
    '    Try
    '        Dim Filewrite As StreamWriter
    '        If Dir(Trim(VOutputfile & "")) <> "" Then
    '            VOutputfile = Mid(VOutputfile, 1, VOutputfile.Length - 4)
    '            Filewrite = File.AppendText(VOutputfile & ".bat")
    '            If Kot_PrintOption <> "Y" Then
    '                If computername = "" Or Printername = "" Then
    '                    Filewrite.WriteLine("Type " & VOutputfile & ".txt >> lpt1")
    '                    Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
    '                Else
    '                    Filewrite.WriteLine("Type " & VOutputfile & ".txt > \\" & computername & "\" & Printername)
    '                    Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
    '                End If
    '                Filewrite.Close()
    '                Call Shell(VOutputfile & ".bat", vbHide)
    '                Kot_PrintOption = "N"
    '            Else 'FOR KOT_PRINTER
    '                If Kot_Computername = "" Or Kot_Printername = "" Then
    '                    Filewrite.WriteLine("Type " & VOutputfile & ".txt >> prn")
    '                    Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
    '                Else
    '                    Filewrite.WriteLine("Type " & VOutputfile & ".txt > \\" & Kot_Computername & "\" & Kot_Printername)
    '                    Filewrite.WriteLine("erase " & VOutputfile & ".txt ")
    '                End If
    '                Filewrite.Close()
    '                Call Shell(VOutputfile & ".bat", vbHide)
    '                Kot_PrintOption = "N"
    '            End If
    '        Else
    '            MessageBox.Show(VOutputfile & " Not Found in your System", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Public Function Checkdaterangevalidate(ByVal Startdate As Date, ByVal Enddate As Date) As Boolean
        chkdatevalidate = True
        If DateDiff(DateInterval.Day, Enddate, DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Function
        End If
        If DateDiff(DateInterval.Day, Startdate, Enddate) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Function
        End If
        If CDate(Startdate) >= CDate(Startdate) And CDate(Enddate) <= CDate(Enddate) Then
            chkdatevalidate = True
        Else
            MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
            chkdatevalidate = False
            Exit Function
        End If
        Return chkdatevalidate
    End Function
    Public Function GetPassword(ByVal vUser As String) As String
        Dim Vdesc, vPass As String
        Dim vAsc, Loopindex As Long
        Vdesc = ""
        For Loopindex = 1 To Len(vUser)
            Vdesc = Mid(vUser, Loopindex, 1)
            vAsc = Asc(Vdesc) + 150
            vPass = Trim(vPass) & Chr(vAsc)
        Next Loopindex
        Return vPass
    End Function
    Public Function ExportTo(ByVal ssgrid As AxFPSpreadADO.AxfpSpread)
        Try
            Dim X As Boolean
            Dim vpath As String
            Dim vLog As String
            Dim strpath As String
            vpath = Application.StartupPath & "\Reports\Monprtn"
            vLog = Application.StartupPath & "\Reports\Monprtn.Txt"
            X = ssgrid.ExportRangeToTextFile(0, 0, ssgrid.Col2, ssgrid.Row2, Application.StartupPath & "\Reports\One.txt", "", ",", vbCrLf, FPSpreadADO.ExportRangeToTextFileConstants.ExportRangeToTextFileCreateNewFile, Application.StartupPath & "\Reports\One.log")
            With ssgrid
                If Dir(vpath & ".Xls") <> "" Then
                    Kill(vpath & ".Xls")
                End If
                X = .ExportToExcel(vpath & ".Xls", "", "")
                strpath = strexcelpath & " " & vpath & ".xls"
                Call Shell(strpath, AppWinStyle.NormalFocus)
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
            MessageBox.Show("Before Opening New EXCEL Sheet Close Previous EXCEL sheet", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    'REFERINVENTORY**************************************************************************************************
    Public Function CalAverageQuantity(ByVal ITEMCODE As String) As Double
        Dim Opquantity, Opamount, Grnquantity, Grnamount As Double
        Dim Calquantity, Issuequantity, Issueamount As Double
        Dim Calrate, Clsquantity As Double
        Dim sqlstring As String
        '********************************** CALCULATION OF AVERAGE FOR A PARTICULAR ITEM ***************'''
        '''********************************* FEATCH FROM OPENING STOCK ******************************************'''
        sqlstring = "SELECT ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y'"
        gconnection.getDataSet(sqlstring, "INVENTORYITEM")
        If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
            Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
            Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
        Else
            Opquantity = 0
            Opamount = 0
        End If
        ''''********************************* FEATCH FROM GRN_DETAILS ********************************************'''
        sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'"
        gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
            Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
            Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
        Else
            Grnquantity = 0
            Grnamount = 0
        End If
        ''''********************************* FROM STOCKISSUEDETAILS ***************************************'''
        sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
            Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
        Else
            Issuequantity = 0
            Issueamount = 0
        End If
        '' ********************************* CALCULATE CLOSING BALANCE *********************************'''
        Clsquantity = (Val(Opquantity) + Val(Grnquantity) - Val(Issuequantity))
        If Clsquantity = 0 Then
            Calrate = Val(Grnamount) / Val(Grnquantity)
        Else
            Calrate = (Val(Opamount) + Val(Grnamount) - Val(Issueamount)) / (Val(Clsquantity))
        End If
        ''********************************** COMPLETE CALCULATION OF AVERAGE FOR PARTICULAR ITEM  ********'''
        Return Clsquantity
    End Function
    Public Function ClosingQuantity(ByVal ITEMCODE As String, ByVal STORECODE As String) As Double
        Dim AdjustQty, ClsQty, MainstockQty, TransQty, TransFromQty, TransToQty As Double
        Dim OpQty, GrnQty, IssueQty, ReturnQty, ReturnFromQty, ReturnToQty, IssueToQty, IssueFromQty, ConsumedQty As Double
        Dim sqlstring As String
        Dim i As Integer
        ''*************************************** CALCULATION OF CLOSING QUANTITY FOR A PARTICULAR ITEM ***********************'''
        sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(STORECODE) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STORECODE ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            'If Trim(gdataset.Tables("STOREMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
            If Trim(gdataset.Tables("STOREMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
                ''''********************************* FETCH FROM OPENING STOCK ******************************************'''
                sqlstring = "SELECT ISNULL(OPSTOCK,0) * ISNULL(CONVVALUE,0) AS OPSTOCK1,ISNULL(OPSTOCK,0) AS OPSTOCK FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & Trim(STORECODE) & "'"
                gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                    OpQty = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                Else
                    OpQty = 0
                End If
                ''''********************************* FETCH FROM GRN_DETAILS ********************************************'''
                sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'"
                gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                    GrnQty = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                Else
                    GrnQty = 0
                End If
                ''********************************* FROM STOCK RETURN *****************************************'''
                'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
                'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND TOSTORECODE = '" & Trim(STORECODE) & "' AND ISNULL(DOCTYPE,'')  = 'RET' AND ISNULL(VOID,'')<>'Y'"
                'gconnection.getDataSet(sqlstring, "STOCKRETURNDETAILS")
                'If gdataset.Tables("STOCKRETURNDETAILS").Rows.Count > 0 Then
                '    ReturnQty = Format(Val(gdataset.Tables("STOCKRETURNDETAILS").Rows(0).Item("QTY")), "0.000")
                'Else
                '    ReturnQty = 0
                'End If
                '==========================      
                MainstockQty = GrnQty + OpQty
            Else
                ''''********************************* FETCH FROM OPENING STOCK ******************************************'''
                sqlstring = "SELECT ISNULL(OPSTOCK,0) * ISNULL(CONVVALUE,0) AS OPSTOCK1,ISNULL(OPSTOCK,0) AS OPSTOCK FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & Trim(STORECODE) & "'"
                gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                    OpQty = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                Else
                    OpQty = 0
                End If
                '    ''''********************************* FETCH FROM GRN_DETAILS ********************************************'''
                sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y' AND STORECODE='" & Trim(STORECODE) & "'"
                gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                    GrnQty = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                Else
                    GrnQty = 0
                End If
                'End If
                ''''********************************* FROM STOCK RETURN *****************************************'''
                'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
                'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND TOSTORECODE = '" & Trim(STORECODE) & "' AND ISNULL(DOCTYPE,'')  = 'RET' AND ISNULL(VOID,'')<>'Y'"
                'gconnection.getDataSet(sqlstring, "STOCKRETURNDETAILS")
                'If gdataset.Tables("STOCKRETURNDETAILS").Rows.Count > 0 Then
                '    ReturnQty = Format(Val(gdataset.Tables("STOCKRETURNDETAILS").Rows(0).Item("QTY")), "0.000")
                'Else
                '    ReturnQty = 0
                'End If
                '==========================      
                MainstockQty = GrnQty + OpQty
            End If
        End If

        ''''********************************* FROM STOCKISSUEDETAILS ***************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            IssueFromQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
        Else
            IssueFromQty = 0
        End If
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND OPSTORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            IssueToQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
        Else
            IssueToQty = 0
        End If
        IssueQty = IssueToQty - IssueFromQty
        ''''********************************* FROM STOCKADJUSTMENT ***************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY FROM STOCKADJUSTDETAILS "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
        If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
            AdjustQty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            AdjustQty = 0
        End If
        ''********************************* FROM STOCK TRANSFER *****************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND FROMSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKTRANSDETAILS")
        If gdataset.Tables("STOCKTRANSDETAILS").Rows.Count > 0 Then
            TransFromQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            TransFromQty = 0
        End If
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND TOSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKTRANSDETAILS1")
        If gdataset.Tables("STOCKTRANSDETAILS1").Rows.Count > 0 Then
            TransToQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS1").Rows(0).Item("QTY")), "0.000")
        Else
            TransToQty = 0
        End If
        TransQty = TransToQty - TransFromQty
        ''********************************* FROM STOCK consumption *****************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STORECONSUMPTIONDETAILS")
        If gdataset.Tables("STORECONSUMPTIONDETAILS").Rows.Count > 0 Then
            ConsumedQty = Format(Val(gdataset.Tables("STORECONSUMPTIONDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            ConsumedQty = 0
        End If

        '' ********************************* CALCULATE CLOSING QUANTITY *********************************'''
        sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(STORECODE) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STORECODE ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            If Trim(gdataset.Tables("STOREMASTER").Rows(i).Item("STORESTATUS")) = "M" Then
                ClsQty = (Val(MainstockQty) + Val(AdjustQty)) + Val(IssueQty) + Val(TransQty) - Val(ConsumedQty)
            Else
                ClsQty = (Val(MainstockQty) + Val(AdjustQty)) + Val(IssueQty) + Val(TransQty) - Val(ConsumedQty)
            End If
        End If
        ''********************************** COMPLETE CALCULATION QUANTITY ******************************'''
        Return ClsQty
    End Function
    Public Function CalAverageRate(ByVal ITEMCODE As String) As Double
        Dim Opquantity, Opamount, Grnquantity, Grnamount As Double
        Dim Calquantity, Issuequantity, Issueamount As Double
        Dim Calrate, Clsquantity As Double
        Dim sqlstring As String
        ''********************************** CALCULATION OF AVERAGE FOR A PARTICULAR ITEM ***************'''
        ''********************************* FEATCH FROM OPENING STOCK ******************************************'''
        sqlstring = "SELECT ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y'"
        gconnection.getDataSet(sqlstring, "INVENTORYITEM")
        If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
            Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
            Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
        Else
            Opquantity = 0
            Opamount = 0
        End If
        ''''********************************* FEATCH FROM GRN_DETAILS ********************************************'''
        sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'"
        gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
            Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
            Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
        Else
            Grnquantity = 0
            Grnamount = 0
        End If
        ''''********************************* FROM STOCKISSUEDETAILS ***************************************'''
        sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOID,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
            Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
        Else
            Issuequantity = 0
            Issueamount = 0
        End If
        ''' ********************************* CALCULATE CLOSING BALANCE *********************************'''
        Clsquantity = (Val(Opquantity) + Val(Grnquantity) - Val(Issuequantity))
        If Clsquantity = 0 Then
            If Grnquantity <> 0 Then
                Calrate = Val(Grnamount) / Val(Grnquantity)
            Else
                Calrate = 0
            End If
        Else
            Calrate = (Val(Opamount) + Val(Grnamount) - Val(Issueamount)) / (Val(Clsquantity))
        End If
        '''********************************** COMPLETE CALCULATION OF AVERAGE FOR PARTICULAR ITEM  ********'''
        Return Calrate
    End Function
    Public Function STOCKAVAILABILITY(ByVal GRID_OBJECT As Object, ByVal ROW As Integer) As Integer
        Dim POSITEMCODE, POSITEMUOM, SQLSTRING, VARPOSCODE, ITEMCODE As String
        Dim CHK_CLS_QUANTITY, DBLCALQTY As Double
        Dim CURQTY, PREVQTY, CLSQTY, VDIFF As Double
        Dim K As Integer

        Dim SUBSTORECODE As String
        If FormType = "K" Then
            GRID_OBJECT.col = 1
        Else
            GRID_OBJECT.col = 2
        End If
        ITEMCODE = (GRID_OBJECT.text & "")
        SQLSTRING = "SELECT ISNULL(STORECODE,'') AS STORECODE FROM ITEMMASTER "
        SQLSTRING = SQLSTRING & " WHERE ITEMCODE='" & ITEMCODE & "' AND ISNULL(STORECODE,'') <> ''"
        gconnection.getDataSet(SQLSTRING, "ITEMMASTER")
        If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
            VARPOSCODE = gdataset.Tables("ITEMMASTER").Rows(0).Item("STORECODE")
        Else
            If FormType = "K" Then
                GRID_OBJECT.row = ROW
                GRID_OBJECT.col = 3
                VARPOSCODE = (GRID_OBJECT.text & "")
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 1
                POSITEMCODE = Trim(GRID_OBJECT.Text)
            Else
                GRID_OBJECT.row = ROW
                GRID_OBJECT.col = 4
                VARPOSCODE = (GRID_OBJECT.text & "")
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 2
                POSITEMCODE = Trim(GRID_OBJECT.Text)
            End If
        End If
        If Mid(gCompName, 1, 3) = "BCL" Then
            Return 2
            Exit Function
        End If
        'SQLSTRING = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(VARPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
        'gconnection.getDataSet(SQLSTRING, "SUBSTORE")
        'If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
        '    SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
        'Else
        '    SUBSTORECODE = VARPOSCODE
        'End If
        'SQLSTRING = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & VARPOSCODE & "' AND ISNULL(FREEZE,'') <> 'Y'"
        SQLSTRING = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(VARPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
        gconnection.getDataSet(SQLSTRING, "STOREMASTER1")
        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
            If FormType = "K" Then
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 1
                POSITEMCODE = Trim(GRID_OBJECT.Text)
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 4
                POSITEMUOM = Trim(GRID_OBJECT.Text)
            Else
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 2
                POSITEMCODE = Trim(GRID_OBJECT.Text)
                GRID_OBJECT.Row = ROW
                GRID_OBJECT.Col = 5
                POSITEMUOM = Trim(GRID_OBJECT.Text)
            End If
           
            SQLSTRING = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(VARPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
            gconnection.getDataSet(SQLSTRING, "SUBSTORE")
            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
            Else
                SUBSTORECODE = VARPOSCODE
            End If
            SQLSTRING = "SELECT GITEMCODE,GUOM,GQTY FROM BOM_DET WHERE  "
            SQLSTRING = SQLSTRING & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
            gconnection.getDataSet(SQLSTRING, "BOM")
            If gdataset.Tables("BOM").Rows.Count > 0 Then
                'If gdataset.Tables("BOM").Rows.Count > 0 Then
                For K = 0 To gdataset.Tables("BOM").Rows.Count - 1
                    SQLSTRING = "SELECT * FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "' AND STORECODE='" & SUBSTORECODE & "' AND ISNULL(FREEZE,'') <> 'Y'"
                    gconnection.getDataSet(SQLSTRING, "ITEMSTATUS")
                    If gdataset.Tables("ITEMSTATUS").Rows.Count <= 0 Then
                        MessageBox.Show(POSITEMCODE & " NOT AVAILABLE")
                        Return 0
                        Exit Function
                    End If
                    GRID_OBJECT.Row = ROW
                   
                    ''If GmoduleName = "KOT Entry" Then
                    ''    GRID_OBJECT.Col = 18
                    ''Else
                    ''    GRID_OBJECT.Col = 22
                    ''End If
                    If FormType = "K" Then
                        GRID_OBJECT.Col = 18
                    Else
                        GRID_OBJECT.Col = 22
                    End If
                    PREVQTY = Val(GRID_OBJECT.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY"))
                    If PREVQTY <> 0 Then
                        If FormType = "K" Then
                            GRID_OBJECT.Row = ROW
                            GRID_OBJECT.Col = 5
                        Else
                            GRID_OBJECT.Row = ROW
                            GRID_OBJECT.Col = 6
                        End If
                       
                        CURQTY = Val(GRID_OBJECT.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY"))
                        CLSQTY = ClosingQuantity(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE"), SUBSTORECODE)
                        VDIFF = Val(CLSQTY) + Val(PREVQTY) - Val(CURQTY)
                        If Val(VDIFF) < 0 Then
                            MessageBox.Show("STOCK IS NOT SUFFICIENT TO  MODIFY...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return 1
                            Exit Function
                        End If
                    Else
                        CHK_CLS_QUANTITY = ClosingQuantity(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE"), SUBSTORECODE)
                        If FormType = "K" Then
                            GRID_OBJECT.Col = 5
                            GRID_OBJECT.Row = ROW
                        Else
                            GRID_OBJECT.Col = 6
                            GRID_OBJECT.Row = ROW
                        End If
                      
                        DBLCALQTY = Val(GRID_OBJECT.Text)
                        'pank
                        If CHK_CLS_QUANTITY < (DBLCALQTY * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY"))) Then
                            MessageBox.Show(POSITEMCODE & " NOT AVAILABLE")
                            Return 0
                            Exit Function
                        End If
                        'pank
                    End If
                Next
            Else
                SQLSTRING = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(VARPOSCODE) & "' AND ITEMCODE='" & POSITEMCODE & "'"
                gconnection.getDataSet(SQLSTRING, "SUBSTORE")
                If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                    SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                Else
                    SUBSTORECODE = VARPOSCODE
                End If

                ''SQLSTRING = "SELECT ITEMCODE,STOCKUOM FROM INVENTORYITEMMASTER WHERE  STORECODE='" & SUBSTORECODE & "' AND "
                ''SQLSTRING = SQLSTRING & " ITEMCODE='" & POSITEMCODE & "' AND STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y'"
                ''gconnection.getDataSet(SQLSTRING, "DIRECT_STOCK")
                ''If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                ''    GRID_OBJECT.Row = ROW
                ''    'REFERCSC
                ''    'GRID_OBJECT.Col = 22
                ''    If GmoduleName = "KOT Entry" Then
                ''        GRID_OBJECT.Col = 18
                ''    Else
                ''        GRID_OBJECT.Col = 22
                ''    End If
                ''    PREVQTY = Val(GRID_OBJECT.Text)
                ''    If PREVQTY <> 0 Then
                ''        GRID_OBJECT.Row = ROW
                ''        GRID_OBJECT.Col = 5
                ''        CURQTY = Val(GRID_OBJECT.Text)
                ''        CLSQTY = ClosingQuantity(gdataset.Tables("DIRECT_STOCK").Rows(K).Item("ITEMCODE"), SUBSTORECODE)
                ''        VDIFF = Val(CLSQTY) + Val(PREVQTY) - Val(CURQTY)
                ''        If Val(VDIFF) < 0 Then
                ''            MessageBox.Show("STOCK IS NOT SUFFICIENT TO  MODIFY...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''            Return 1
                ''            Exit Function
                ''        End If
                ''    Else
                ''        CHK_CLS_QUANTITY = ClosingQuantity(gdataset.Tables("DIRECT_STOCK").Rows(K).Item("ITEMCODE"), SUBSTORECODE)
                ''        GRID_OBJECT.Col = 5
                ''        GRID_OBJECT.Row = ROW
                ''        DBLCALQTY = Val(GRID_OBJECT.Text)
                ''        'PANK
                ''        If CHK_CLS_QUANTITY < DBLCALQTY Then
                ''            MessageBox.Show(POSITEMCODE & " NOT AVAILABLE")
                ''            Return 0
                ''            Exit Function
                ''        End If
                ''        'PANK
                ''    End If
                ''End If
            End If
        End If
        Return 2
    End Function

    Public Function STORELOCATION(ByVal STORECODE As String) As String
        Dim sqlstring, STRLOCATION As String
        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & STORECODE & "' AND ISNULL(FREEZE,'') <> 'Y'"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            STRLOCATION = (gdataset.Tables("STOREMASTER").Rows(0).Item("STOREDESC") & "")
        End If
        Return STRLOCATION
    End Function

    Public Function GetMainStore() As String
        Try
            Dim SQLSTRING, MnStore As String
            SQLSTRING = "SELECT STORECODE FROM STOREMASTER WHERE STORESTATUS='M' AND ISNULL(FREEZE,'') <> 'Y'"
            gconnection.getDataSet(SQLSTRING, "MAINSTORE")
            If gdataset.Tables("MAINSTORE").Rows.Count > 0 Then
                MnStore = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORECODE"))
            Else
                MnStore = ""
            End If
            Return MnStore
        Catch EX As Exception
            MsgBox(EX.Message)
            Exit Function
        End Try
    End Function
    Public Function getVoucherno(ByVal vvouchertype As String, ByVal vvouchercategory As String) As Double

        Dim ssql As String
        ssql = "Select docno from poskotdoc where doctype='" & Trim(vvouchertype & "") & "'"
        gconnection.getDataSet(ssql, "docnumbers")
        If gdataset.Tables("docnuMbers").Rows.Count > 0 Then
            getVoucherno = Val(gdataset.Tables("DOCNUMBERS").Rows(0).Item(0) & "")
        Else
            ssql = "insert into poskotdoc(doctype,docno) values ('" & Trim(vvouchertype) & "',1)"
            gconnection.dataOperation(6, ssql)
            getVoucherno = 1
        End If

        'and bc_code='" & Trim(vvouchercategory) & "'
        gconnection.dataOperation(6, "Update poskotdoc set Docno=isnull(Docno,0) +1 where Doctype='" & vvouchertype & "'")

    End Function
    Public Function Search_Item(ByVal listBox As Windows.Forms.CheckedListBox, ByVal searchText As String)
        If searchText <> "" Then
            Dim I, J As Integer
            For I = 0 To listBox.Items.Count - 1
                For J = 1 To Len(listBox.Items(I))
                    If UCase(Mid(listBox.Items(I), J, Len(Trim(searchText)))) = UCase(Trim(searchText)) Then
                        listBox.SetItemChecked(I, True)
                        listBox.SelectedIndex = I
                    End If
                Next
            Next
        End If
    End Function
    '***************************************************************************************************************
    'SARAVANAN
    ' Function for conversion of a Indian Rupees into words
    '   Parameter - accept a Currency
    '   Returns the number in words format
    '   You can use this function in Excel, VBA, VB6,.NET
    '====================================================

    '****************************************************
    ' Code Created by 

    '****************************************************
    Function RupeesToWord(ByVal MyNumber)
        Dim Temp
        Dim Rupees, Paisa As String
        Dim DecimalPlace, iCount
        Dim Hundreds, Words As String
        Dim place(9) As String
        place(0) = " Thousand "
        place(2) = " Lakh "
        place(4) = " Crore "
        place(6) = " Arab "
        place(8) = " Kharab "
        On Error Resume Next
        ' Convert MyNumber to a string, trimming extra spaces.
        MyNumber = Trim(Str(MyNumber))

        ' Find decimal place.
        DecimalPlace = InStr(MyNumber, ".")

        ' If we find decimal place...
        If DecimalPlace > 0 Then
            ' Convert Paisa
            Temp = Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2)
            Paisa = " and " & ConvertTens(Temp) & " Paisa"

            ' Strip off paisa from remainder to convert.
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If

        '===============================================================
        Dim TM As String  ' If MyNumber between Rs.1 To 99 Only.
        TM = Right(MyNumber, 2)

        If Len(MyNumber) > 0 And Len(MyNumber) <= 2 Then
            If Len(TM) = 1 Then
                Words = ConvertDigit(TM)
                RupeesToWord = "Rupees " & Words & Paisa & " Only"

                Exit Function

            Else
                If Len(TM) = 2 Then
                    Words = ConvertTens(TM)
                    RupeesToWord = "Rupees " & Words & Paisa & " Only"
                    Exit Function

                End If
            End If
        End If
        '===============================================================


        ' Convert last 3 digits of MyNumber to ruppees in word.
        Hundreds = ConvertHundreds(Right(MyNumber, 3))
        ' Strip off last three digits
        MyNumber = Left(MyNumber, Len(MyNumber) - 3)

        iCount = 0
        Do While MyNumber <> ""
            'Strip last two digits
            Temp = Right(MyNumber, 2)
            If Len(MyNumber) = 1 Then


                If Trim(Words) = "Thousand" Or _
                Trim(Words) = "Lakh  Thousand" Or _
                Trim(Words) = "Lakh" Or _
                Trim(Words) = "Crore" Or _
                Trim(Words) = "Crore  Lakh  Thousand" Or _
                Trim(Words) = "Arab  Crore  Lakh  Thousand" Or _
                Trim(Words) = "Arab" Or _
                Trim(Words) = "Kharab  Arab  Crore  Lakh  Thousand" Or _
                Trim(Words) = "Kharab" Then

                    Words = ConvertDigit(Temp) & place(iCount)
                    MyNumber = Left(MyNumber, Len(MyNumber) - 1)

                Else

                    Words = ConvertDigit(Temp) & place(iCount) & Words
                    MyNumber = Left(MyNumber, Len(MyNumber) - 1)

                End If
            Else

                If Trim(Words) = "Thousand" Or _
                   Trim(Words) = "Lakh  Thousand" Or _
                   Trim(Words) = "Lakh" Or _
                   Trim(Words) = "Crore" Or _
                   Trim(Words) = "Crore  Lakh  Thousand" Or _
                   Trim(Words) = "Arab  Crore  Lakh  Thousand" Or _
                   Trim(Words) = "Arab" Then


                    Words = ConvertTens(Temp) & place(iCount)


                    MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                Else

                    '=================================================================
                    ' if only Lakh, Crore, Arab, Kharab

                    If Trim(ConvertTens(Temp) & place(iCount)) = "Lakh" Or _
                       Trim(ConvertTens(Temp) & place(iCount)) = "Crore" Or _
                       Trim(ConvertTens(Temp) & place(iCount)) = "Arab" Then

                        Words = Words
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    Else
                        Words = ConvertTens(Temp) & place(iCount) & Words
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If

                End If
            End If

            iCount = iCount + 2
        Loop

        RupeesToWord = "Rs." & Words & Hundreds & Paisa & " Only"
    End Function

    Function RupeesToWordASCA(ByVal MyNumber)
        Dim Temp
        Dim Rupees, Paisa As String
        Dim DecimalPlace, iCount
        Dim Hundreds, Words As String
        Dim place(9) As String
        place(0) = " Thousand "
        place(2) = " Lakh "
        place(4) = " Crore "
        place(6) = " Arab "
        place(8) = " Kharab "
        On Error Resume Next
        ' Convert MyNumber to a string, trimming extra spaces.
        MyNumber = Trim(Str(MyNumber))

        ' Find decimal place.
        DecimalPlace = InStr(MyNumber, ".")

        ' If we find decimal place...
        If DecimalPlace > 0 Then
            ' Convert Paisa
            Temp = Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2)
            Paisa = " and " & ConvertTens(Temp) & " Paise"

            ' Strip off paisa from remainder to convert.
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If

        '===============================================================
        Dim TM As String  ' If MyNumber between Rs.1 To 99 Only.
        TM = Right(MyNumber, 2)

        If Len(MyNumber) > 0 And Len(MyNumber) <= 2 Then
            If Len(TM) = 1 Then
                Words = ConvertDigit(TM)
                RupeesToWordASCA = Words & Paisa & " Only"

                Exit Function

            Else
                If Len(TM) = 2 Then
                    Words = ConvertTens(TM)
                    RupeesToWordASCA = Words & Paisa & " Only"
                    Exit Function

                End If
            End If
        End If
        '===============================================================


        ' Convert last 3 digits of MyNumber to ruppees in word.
        Hundreds = ConvertHundreds(Right(MyNumber, 3))
        ' Strip off last three digits
        MyNumber = Left(MyNumber, Len(MyNumber) - 3)

        iCount = 0
        Do While MyNumber <> ""
            'Strip last two digits
            Temp = Right(MyNumber, 2)
            If Len(MyNumber) = 1 Then


                If Trim(Words) = "Thousand" Or _
                Trim(Words) = "Lakh  Thousand" Or _
                Trim(Words) = "Lakh" Or _
                Trim(Words) = "Crore" Or _
                Trim(Words) = "Crore  Lakh  Thousand" Or _
                Trim(Words) = "Arab  Crore  Lakh  Thousand" Or _
                Trim(Words) = "Arab" Or _
                Trim(Words) = "Kharab  Arab  Crore  Lakh  Thousand" Or _
                Trim(Words) = "Kharab" Then

                    Words = ConvertDigit(Temp) & place(iCount)
                    MyNumber = Left(MyNumber, Len(MyNumber) - 1)

                Else

                    Words = ConvertDigit(Temp) & place(iCount) & Words
                    MyNumber = Left(MyNumber, Len(MyNumber) - 1)

                End If
            Else

                If Trim(Words) = "Thousand" Or _
                   Trim(Words) = "Lakh  Thousand" Or _
                   Trim(Words) = "Lakh" Or _
                   Trim(Words) = "Crore" Or _
                   Trim(Words) = "Crore  Lakh  Thousand" Or _
                   Trim(Words) = "Arab  Crore  Lakh  Thousand" Or _
                   Trim(Words) = "Arab" Then


                    Words = ConvertTens(Temp) & place(iCount)


                    MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                Else

                    '=================================================================
                    ' if only Lakh, Crore, Arab, Kharab

                    If Trim(ConvertTens(Temp) & place(iCount)) = "Lakh" Or _
                       Trim(ConvertTens(Temp) & place(iCount)) = "Crore" Or _
                       Trim(ConvertTens(Temp) & place(iCount)) = "Arab" Then

                        Words = Words
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    Else
                        Words = ConvertTens(Temp) & place(iCount) & Words
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If

                End If
            End If

            iCount = iCount + 2
        Loop

        RupeesToWordASCA = Words & Hundreds & Paisa & " Only"
    End Function

    ' Conversion for hundreds
    '*****************************************
    Private Function ConvertHundreds(ByVal MyNumber)
        Dim Result As String

        ' Exit if there is nothing to convert.
        If Val(MyNumber) = 0 Then Exit Function

        ' Append leading zeros to number.
        MyNumber = Right("000" & MyNumber, 3)

        ' Do we have a hundreds place digit to convert?
        If Left(MyNumber, 1) <> "0" Then
            'Result = ConvertDigit(Left(MyNumber, 1)) & " Hundreds "
            Result = ConvertDigit(Left(MyNumber, 1)) & " Hundred "
        End If

        ' Do we have a tens place digit to convert?
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & ConvertTens(Mid(MyNumber, 2))
        Else
            ' If not, then convert the ones place digit.
            Result = Result & ConvertDigit(Mid(MyNumber, 3))
        End If

        ConvertHundreds = Trim(Result)
    End Function

    ' Conversion for tens
    '*****************************************
    Private Function ConvertTens(ByVal MyTens)
        Dim Result As String

        ' Is value between 10 and 19?
        If Val(Left(MyTens, 1)) = 1 Then
            Select Case Val(MyTens)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else
            ' .. otherwise it's between 20 and 99.
            Select Case Val(Left(MyTens, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Foruty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select

            ' Convert ones place digit.
            Result = Result & ConvertDigit(Right(MyTens, 1))
        End If
        ConvertTens = Result
    End Function
    Private Function ConvertDigit(ByVal MyDigit)
        Select Case Val(MyDigit)
            Case 1 : ConvertDigit = "One"
            Case 2 : ConvertDigit = "Two"
            Case 3 : ConvertDigit = "Three"
            Case 4 : ConvertDigit = "Four"
            Case 5 : ConvertDigit = "Five"
            Case 6 : ConvertDigit = "Six"
            Case 7 : ConvertDigit = "Seven"
            Case 8 : ConvertDigit = "Eight"
            Case 9 : ConvertDigit = "Nine"
            Case Else : ConvertDigit = ""
        End Select
    End Function

    Public Function SPLASH_EXPORT()
        Dim ServerConn1 As New OleDb.OleDbConnection
        Dim servercmd1 As New OleDb.OleDbDataAdapter
        Dim getserver1 As New DataSet
        Dim sql, ssql, insertsql As String
        Dim dr, dr1 As DataRow
        Dim ext, dept, number, tim, dur, gno, trans, trunk, ndur, stdn As String
        Dim dat As Date
        Dim amt, ncost As Double
        Dim Insert(0) As String
        Dim Insert1(0) As String
        Dim sqlstring As String
        Dim StrDat() As String
        Dim dd, mm, yy, dd1, mm1 As String
        Dim insertcount As Integer
        Dim K As Integer

        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & GSplashPath & ".mdb"
        ServerConn1.ConnectionString = sql
        Try
            If ServerConn1.State = ConnectionState.Open Then
                ServerConn1.Close()
            Else
                ServerConn1.Open()
            End If
            sqlstring = "select MEMBERCODE,[16_DIGIT_CODE],FREEZE_FLAG,ACTIVATION_FLAG from  sm_cardfile_hdr WHERE ISNULL(ACTIVATION_FLAG,'')='N'"
            gconnection.getDataSet(sqlstring, "ACTIVATION")
            If gdataset.Tables("ACTIVATION").Rows.Count > 0 Then
                ssql = "DELETE FROM BLOCKLIST"
                servercmd1 = New OleDb.OleDbDataAdapter(ssql, ServerConn1)
                servercmd1.Fill(getserver1)

                ssql = "select [16_DIGIT_CODE] AS DIGITCODE from  sm_cardfile_hdr WHERE ISNULL(ACTIVATION_FLAG,'')='N'"
                gconnection.getDataSet(ssql, "docnumbers")
                If gdataset.Tables("docnuMbers").Rows.Count > 0 Then
                    For K = 0 To gdataset.Tables("docnuMbers").Rows.Count - 1
                        ssql = "INSERT INTO BLOCKLIST (MEMID) VALUES('" & gdataset.Tables("docnuMbers").Rows(K).Item("DIGITCODE") & "')"
                        servercmd1 = New OleDb.OleDbDataAdapter(ssql, ServerConn1)
                        servercmd1.Fill(getserver1)
                    Next
                    MsgBox("Block Imported....")
                End If
            End If


            sqlstring = "select MEMBERCODE,[16_DIGIT_CODE],FREEZE_FLAG,ACTIVATION_FLAG from  sm_cardfile_hdr"
            gconnection.getDataSet(sqlstring, "ACTIVATION")
            If gdataset.Tables("ACTIVATION").Rows.Count > 0 Then
                ssql = "DELETE FROM MEMBERLIST"
                servercmd1 = New OleDb.OleDbDataAdapter(ssql, ServerConn1)
                servercmd1.Fill(getserver1)

                ssql = "select [16_DIGIT_CODE] AS DIGITCODE from  sm_cardfile_hdr"
                gconnection.getDataSet(ssql, "docnumbers")
                If gdataset.Tables("docnuMbers").Rows.Count > 0 Then
                    For K = 0 To gdataset.Tables("docnuMbers").Rows.Count - 1
                        ssql = "INSERT INTO MEMBERLIST (MEMID) VALUES('" & gdataset.Tables("docnuMbers").Rows(K).Item("DIGITCODE") & "')"
                        servercmd1 = New OleDb.OleDbDataAdapter(ssql, ServerConn1)
                        servercmd1.Fill(getserver1)
                    Next
                    MsgBox("MEMBERLIST Imported....")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & " EPBX Import")
        Finally
            ServerConn1.Close()
        End Try
    End Function
    Public Function ERPExpiry()
        Dim sqlstring As String
        Dim vDes As String
        Dim expdate As Date

        sqlstring = "SELECT isnull(expirydate,dateadd(day,1,getdate())) as expirydate,Convert(char,Comp,103) as Comp FROM MASTER..CLUBMASTER WHERE  DATAFILE = '" & gDatabase & "' and (isnull(expirydate,'')<>'' or isnull(comp,'')<>'')"
        gconnection.getCompanyinfo(sqlstring, "ExpiryDate")
        If gdataset.Tables("ExpiryDate").Rows.Count > 0 Then
            'FOR KOT Table

            vDes = abcdMINUS(Trim(gdataset.Tables("ExpiryDate").Rows(0).Item("comp") & ""))
            If IsDate(vDes) = True Then
                expdate = DateValue(vDes)
            Else
                expdate = Format(gdataset.Tables("ExpiryDate").Rows(0).Item("ExpiryDate"), "dd/MMM/yyyy")
            End If

            sqlstring = "select * from " & gDatabase & "..kot_hdr where cast(convert(varchar(11),kotdate,106) as datetime)>dateadd(day,-13,'" & Format(expdate, "dd/MMM/yyyy") & "')"
            gconnection.getCompanyinfo(sqlstring, "ExpiryDate1")
            If gdataset.Tables("ExpiryDate1").Rows.Count > 0 Then
                MsgBox("CLUBMAN ERP License Expiry/Due Date is  :" & Format(expdate, "dd/MM/yyyy") & ", So Kindly Renew the license On or Before Due Date")
                sqlstring = "select * from " & gDatabase & "..kot_hdr where cast(convert(varchar(11),kotdate,106) as datetime)>'" & Format(expdate, "dd/MMM/yyyy") & "'"
                gconnection.getCompanyinfo(sqlstring, "ExpiryDate1")
                If gdataset.Tables("ExpiryDate1").Rows.Count > 0 Then
                    MsgBox("Sorry..CLUBMAN ERP License Expired on  :" & Format(expdate, "dd/MM/yyyy") & ", Please Contact - Email:info@databasesoftware.in; for further Assistance")
                    End
                End If
            End If

            'JOURNAL Table
            sqlstring = "select * from " & gDatabase & "..journalentry where cast(convert(varchar(11),voucherdate,106) as datetime)>dateadd(day,-13,'" & Format(expdate, "dd/MMM/yyyy") & "')"
            gconnection.getCompanyinfo(sqlstring, "ExpiryDate1")
            If gdataset.Tables("ExpiryDate1").Rows.Count > 0 Then
                MsgBox("CLUBMAN ERP License Expiry/Due Date is " & Format(expdate, "dd/MM/yyyy") & ", So Kindly Renew the license On or Before Due Date")
                sqlstring = "select * from " & gDatabase & "..journalentry where cast(convert(varchar(11),voucherdate,106) as datetime)>'" & Format(expdate, "dd/MMM/yyyy") & "'"
                gconnection.getCompanyinfo(sqlstring, "ExpiryDate1")
                If gdataset.Tables("ExpiryDate1").Rows.Count > 0 Then
                    MsgBox("Sorry...CLUBMAN ERP License Expired on  : " & Format(expdate, "dd/MM/yyyy") & ", Please Contact - Email:info@databasesoftware.in; for further Assistance")
                    End
                End If
            End If
        End If
    End Function
    Public Sub SendSMS(ByVal code As String, ByVal Amt As Double, Billno As String, Billdate As DateTime)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        Dim username As String = "punjabclub"
        Dim password As String = "punjabclub123"
        'Dim host As String = "http://dndopen.loyalsmsindia.co.in/web2sms.php?"
        'Dim host As String = "http://fastsms.way2mint.com/SendSMS/sendmsg.php?"
        Dim host As String = "http://opt.iissms.co.in/api/sendhttp.php?"
        Dim originator As String = "THECPC"
        Dim Ph As String
        Dim Message, sqlMsg, MnthName, sqlString, User As String
        Dim Amount As String
        Dim Bdate, BTime As DateTime
        Dim DebAmt As Double

        Try
            sqlMsg = "SELECT MCODE,REPLACE(REPLACE(CONTCELL,'-',''),' ','') AS CONTCELL FROM MEMBERMASTER WHERE MCODE = '" & Trim(code) & "'"
            gconnection.getDataSet(sqlMsg, "MemPh")
            If gdataset.Tables("MemPh").Rows.Count > 0 Then
                Ph = gdataset.Tables("MemPh").Rows(0).Item(1)
            End If
            'SQLSTRING = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS DEBAMT FROM VIEW_OUTSTANDING WHERE ISNULL(SLCODE,'') = '" & Trim(code) & "' AND MONTH(ISNULL(VOUCHERDATE,'')) = " & Month(Billdate) & "  AND ISNULL(VOUCHERTYPE,'') <> 'OPL' AND ISNULL(CREDITDEBIT,'') = 'DEBIT'"
            sqlString = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS DEBAMT FROM VIEW_OUTSTANDING_CHECK WHERE ISNULL(SLCODE,'') = '" & Trim(code) & "' AND MONTH(ISNULL(VOUCHERDATE,'')) = " & Month(Billdate) & "  AND ISNULL(VOUCHERTYPE,'') <> 'OPL' AND ISNULL(CREDITDEBIT,'') = 'DEBIT'"
            gconnection.getDataSet(SQLSTRING, "DebTotal")
            If gdataset.Tables("DebTotal").Rows.Count > 0 Then
                DebAmt = Format(Math.Round(Val(gdataset.Tables("DebTotal").Rows(0).Item(0)), 0), "0.00")
            End If
            MnthName = UCase(Mid(MonthName(Month(Billdate)), 1, 3))
            sqlString = "SELECT * FROM BILL_HDR WHERE BILLDETAILS IN ( " & Trim(Billno) & ")"
            gconnection.getDataSet(sqlString, "Bill")
            If gdataset.Tables("Bill").Rows.Count > 0 Then
                Bdate = Format(gdataset.Tables("Bill").Rows(0).Item("Billdate"), "dd/MM/yyyy")
                BTime = Format(gdataset.Tables("Bill").Rows(0).Item("Billtime"), "T")
                User = gdataset.Tables("Bill").Rows(0).Item("AddUserId")
            End If

            'Ph = "9038850188"
            If Ph <> "" And Len(Ph) = 10 And Amt > 0 Then
                'Message = "Dear Member " & Amount & " Credited in Your Smart Card Thanks For Using Smart Card"
                Message = "Amt of " & Format(Amt, "0.00") & " is billed on A/c no. " & Trim(code) & ". Bill No. " & Trim(Billno) & " Dt. " & Trim(Bdate) & " " & Trim(BTime) & " at KGA TOTAL FOR " & Trim(MnthName) & ": " & Trim(DebAmt) & " by Staff " & Trim(User) & ""
                'url = host + "" & "uname=kgatt&pass=12345678&send=Way2mint&dest=" & Ph & "&msg=" & Message & "&concat=1"
                url = host + "" & "authkey=4449AIkKxBSS53c7cf5f&mobiles=" & Ph & "&message=" & Message & "&sender=KGASMS&route=4"
                '& "uname=" & HttpUtility.UrlEncode(username) _
                '& "&password=" + HttpUtility.UrlEncode(password) _
                '& "&to=" + HttpUtility.UrlEncode(Ph) _
                '& "&sender=" + HttpUtility.UrlEncode(originator) _
                '& "&message=" + HttpUtility.UrlEncode(Message) _
                ''& "&originator=" + HttpUtility.UrlEncode(originator) _
                '& "&serviceprovider=" _
                '& "&responseformat=html"

                request = DirectCast(WebRequest.Create(url), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)

                'MessageBox.Show("Response: " & response.StatusDescription)
            End If
        Catch ex As Exception
            MessageBox.Show("Netwrok Error.." & ex.ToString())
        End Try

    End Sub
    Public Sub KGA_SendSMS_Delete(ByVal code As String, ByVal Amt As Double, Billno As String, Billdate As DateTime)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        Dim username As String = ""
        Dim password As String = ""
        'Dim host As String = "http://dndopen.loyalsmsindia.co.in/web2sms.php?"
        Dim host As String = "http://fastsms.way2mint.com/SendSMS/sendmsg.php?"
        Dim originator As String = ""
        Dim Ph As String
        Dim Message, sqlMsg, MnthName, sqlString, User As String
        Dim Amount As String
        Dim Bdate, BTime As DateTime
        Dim DebAmt As Double

        Try
            sqlMsg = "SELECT MCODE,REPLACE(REPLACE(CONTCELL,'-',''),' ','') AS CONTCELL FROM MEMBERMASTER WHERE MCODE = '" & Trim(code) & "'"
            gconnection.getDataSet(sqlMsg, "MemPh")
            If gdataset.Tables("MemPh").Rows.Count > 0 Then
                Ph = gdataset.Tables("MemPh").Rows(0).Item(1)
            End If
            'SQLSTRING = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS DEBAMT FROM VIEW_OUTSTANDING WHERE ISNULL(SLCODE,'') = '" & Trim(code) & "' AND MONTH(ISNULL(VOUCHERDATE,'')) = " & Month(Billdate) & "  AND ISNULL(VOUCHERTYPE,'') <> 'OPL' AND ISNULL(CREDITDEBIT,'') = 'DEBIT'"
            sqlString = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS DEBAMT FROM VIEW_OUTSTANDING_CHECK WHERE ISNULL(SLCODE,'') = '" & Trim(code) & "' AND MONTH(ISNULL(VOUCHERDATE,'')) = " & Month(Billdate) & "  AND ISNULL(VOUCHERTYPE,'') <> 'OPL' AND ISNULL(CREDITDEBIT,'') = 'DEBIT'"
            gconnection.getDataSet(sqlString, "DebTotal")
            If gdataset.Tables("DebTotal").Rows.Count > 0 Then
                DebAmt = Format(Math.Round(Val(gdataset.Tables("DebTotal").Rows(0).Item(0)), 0), "0.00")
            End If
            MnthName = UCase(Mid(MonthName(Month(Billdate)), 1, 3))
            sqlString = "SELECT * FROM BILL_HDR WHERE BILLDETAILS IN ( " & Trim(Billno) & ")"
            gconnection.getDataSet(sqlString, "Bill")
            If gdataset.Tables("Bill").Rows.Count > 0 Then
                Bdate = Format(gdataset.Tables("Bill").Rows(0).Item("Billdate"), "dd/MM/yyyy")
                BTime = Format(gdataset.Tables("Bill").Rows(0).Item("Billtime"), "T")
                User = gdataset.Tables("Bill").Rows(0).Item("AddUserId")
            End If

            'Ph = "9038850188"
            If Ph <> "" And Len(Ph) = 10 And Amt > 0 Then
                'Message = "Dear Member " & Amount & " Credited in Your Smart Card Thanks For Using Smart Card"
                'Message = "Amt of " & Format(Amt, "0.00") & " is billed on A/c no. " & Trim(code) & ". Bill No. " & Trim(Billno) & " Dt. " & Trim(Bdate) & " " & Trim(BTime) & " at KGA TOTAL FOR " & Trim(MnthName) & ": " & Trim(DebAmt) & " by Staff " & Trim(User) & ""
                Message = "Amt of " & Format(Amt, "0.00") & " is Deleted on A/c no. " & Trim(code) & ". Bill No. " & Trim(Billno) & ""
                url = host + "" & "uname=kgatt&pass=12345678&send=Way2mint&dest=" & Ph & "&msg=" & Message & "&concat=1"
                '& "uname=" & HttpUtility.UrlEncode(username) _
                '& "&password=" + HttpUtility.UrlEncode(password) _
                '& "&to=" + HttpUtility.UrlEncode(Ph) _
                '& "&sender=" + HttpUtility.UrlEncode(originator) _
                '& "&message=" + HttpUtility.UrlEncode(Message) _
                ''& "&originator=" + HttpUtility.UrlEncode(originator) _
                '& "&serviceprovider=" _
                '& "&responseformat=html"

                request = DirectCast(WebRequest.Create(url), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)

                'MessageBox.Show("Response: " & response.StatusDescription)
            End If
        Catch ex As Exception
            MessageBox.Show("Netwrok Error.." & ex.ToString())
        End Try

    End Sub
    Public Sub SendSMSTKC(ByVal code As String, ByVal Amt As Double, Loc As String, Pmode As String, HCODE As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url, MainCode As String
        Dim username As String = ""
        Dim password As String = ""
        'Dim host As String = "http://dndopen.loyalsmsindia.co.in/web2sms.php?"
        Dim host As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?"
        Dim originator As String = "KORCLB"
        Dim Ph As String
        Dim Message, sqlMsg, MNAME As String
        Dim Amount As String
        Dim CrLimit, CrLimitAmt As Double

        Try
            sqlMsg = "SELECT MCODE,REPLACE(REPLACE(CONTCELL,'-',''),' ','') AS CONTCELL,MNAME FROM MEMBERMASTER WHERE MCODE = '" & Trim(code) & "'"
            gconnection.getDataSet(sqlMsg, "MemPh")
            If gdataset.Tables("MemPh").Rows.Count > 0 Then
                Ph = gdataset.Tables("MemPh").Rows(0).Item(1)
                MNAME = gdataset.Tables("MemPh").Rows(0).Item(2) & " [" & Trim(code) & "]"
            End If
            If Pmode = "MEMBER ACCOUNT" Then
                SQLSTRING = "SELECT ISNULL(MEMLIMIT,0) AS MEMLIMIT FROM MEMBERMASTER WHERE MCODE = '" & Trim(code) & "'"
                gconnection.getDataSet(SQLSTRING, "CRLIMIT")
                If gdataset.Tables("CRLIMIT").Rows.Count > 0 Then
                    CrLimit = gdataset.Tables("CRLIMIT").Rows(0).Item(0)
                Else
                    CrLimit = 0
                End If
                If Trim(gCompName) = "TKC" Then
                    SQLSTRING = "SELECT  ISNULL(MCode,'') AS Mcode FROM MEMBERMASTER Where MCODE ='" & Trim(code) & "'"
                    gconnection.getDataSet(SQLSTRING, "MEMBERMASTER")
                    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                        MainCode = gdataset.Tables("MEMBERMASTER").Rows(0).Item("Mcode")
                        SQLSTRING = "SELECT SLCODE,ISNULL(SUM(DEB),0)-ISNULL(SUM(CRE),0) AS CLS FROM Get_CreditBal WHERE SLCODE = '" & Trim(MainCode) & "' GROUP BY SLCODE ORDER BY SLCODE"
                        gconnection.getDataSet(SQLSTRING, "CLSAMT")
                        If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                            CrLimit = CrLimit - gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
                        Else
                            'CrLimitAmt = 0
                        End If
                    End If
                End If
            ElseIf Pmode = "SMART CARD" Then
                SQLSTRING = "SELECT BALANCE FROM SM_CARDFILE_HDR WHERE CARDCODE = '" & Trim(HCODE) & "'"
                gconnection.getDataSet(SQLSTRING, "CLSAMT")
                If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                    If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                        CrLimit = gdataset.Tables("CLSAMT").Rows(0).Item("BALANCE")
                    Else
                        'CrLimitAmt = 0
                    End If
                End If
            End If

            If Ph <> "" And Len(Ph) = 10 And Amt > 0 Then
                'Message = "Dear Member " & Amount & " Credited in Your Smart Card Thanks For Using Smart Card"
                If Pmode = "MEMBER ACCOUNT" Then
                    'Message = "method=SendMessage&send_to=91" & Ph & "&msg=Dear Member, " & MNAME & " your account has been debited for POS on LOcation " & Loc & " and Rs " & Format(Amt, "0.00") & " is reduce and current credit balance is Rs " & Format(CrLimit, "0.00") & ". TKC -->credit sale details."
                    Message = "method=SendMessage&send_to=91" & Ph & "&msg=" & MNAME & " you have signed for Rs." & Format(Amt, "0.00") & " using Credit Facility at " & Loc & ". Your available credit balance is Rs." & Format(CrLimit, "0.00") & " from total limit of Rs.10, 000/-. TKC"
                ElseIf Pmode = "SMART CARD" Then
                    Message = "method=SendMessage&send_to=91" & Ph & "&msg=Dear Member, " & MNAME & " your Smart card has been Use for POS on Location " & Loc & " and Rs " & Format(Amt, "0.00") & " is reduce and current card balance is Rs " & Format(CrLimit, "0.00") & ". TKC -->card sale details."
                Else
                    Exit Sub
                End If
                url = host + "" & Message & "&msg_type=TEXT&userid=2000107894&auth_scheme=plain&password=kora8oct2012&v=1.1&format=text"

                request = DirectCast(WebRequest.Create(url), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)

                'MessageBox.Show("Response: " & response.StatusDescription)
            End If
        Catch ex As Exception
            MessageBox.Show("Netwrok Error.." & ex.ToString())
        End Try

    End Sub
    Public Sub SendSMSDCL(ByVal code As String, ByVal Amt As Double, Billno As String, Billdate As DateTime, PMode As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        Dim username As String = "punjabclub"
        Dim password As String = "punjabclub123"
        'Dim host As String = "http://dndopen.loyalsmsindia.co.in/web2sms.php?"
        Dim host As String = "http://fastsms.way2mint.com/SendSMS/sendmsg.php?"
        Dim originator As String = "THECPC"
        Dim Ph As String
        Dim Message, sqlMsg, MnthName, sqlString, User, CardHolder As String
        Dim Amount As String
        Dim Bdate, BTime As DateTime
        Dim DebAmt, BalSM As Double

        Try
            sqlMsg = "SELECT MCODE,REPLACE(REPLACE(CONTCELL,'-',''),' ','') AS CONTCELL FROM MEMBERMASTER WHERE MCODE = '" & Trim(code) & "'"
            gconnection.getDataSet(sqlMsg, "MemPh")
            If gdataset.Tables("MemPh").Rows.Count > 0 Then
                Ph = gdataset.Tables("MemPh").Rows(0).Item(1)
            End If
            sqlString = "SELECT * FROM BILL_HDR WHERE BILLDETAILS IN ( " & Trim(Billno) & ")"
            gconnection.getDataSet(sqlString, "Bill")
            If gdataset.Tables("Bill").Rows.Count > 0 Then
                Bdate = Format(gdataset.Tables("Bill").Rows(0).Item("Billdate"), "dd/MM/yyyy")
                BTime = Format(gdataset.Tables("Bill").Rows(0).Item("Billtime"), "T")
                User = gdataset.Tables("Bill").Rows(0).Item("AddUserId")
                CardHolder = Trim(gdataset.Tables("Bill").Rows(0).Item("CARDHOLDERCODE"))
            End If
            sqlString = "SELECT ISNULL(BALANCE,0) AS BAL FROM SM_CARDFILE_HDR WHERE CARDCODE = '" & Trim(CardHolder) & "'"
            gconnection.getDataSet(sqlString, "BAL")
            If gdataset.Tables("BAL").Rows.Count > 0 Then
                BalSM = gdataset.Tables("BAL").Rows(0).Item("BAL")
            Else
                BalSM = 0
            End If

            'Ph = "9038850188"
            If Ph <> "" And Len(Ph) = 10 And Amt > 0 And PMode = "SMART CARD" Then
                'Message = "Dear Member " & Amount & " Credited in Your Smart Card Thanks For Using Smart Card"
                Message = "uname=dclubapi&pass=api12345&send=Way2mint&dest=91" & Ph & "&msg=Membership No." & Trim(code) & " has been debited with INR " & Format(Amt, "0.00") & " on " & Bdate & " " & BTime & "  thru Smart Card, Aval Bal Rs  " & Format(BalSM, "0.00") & " CR Dhanbad Club Ltd"
                url = host + "" & Message & "&concat=1"
                '& "uname=" & HttpUtility.UrlEncode(username) _
                '& "&password=" + HttpUtility.UrlEncode(password) _
                '& "&to=" + HttpUtility.UrlEncode(Ph) _
                '& "&sender=" + HttpUtility.UrlEncode(originator) _
                '& "&message=" + HttpUtility.UrlEncode(Message) _
                ''& "&originator=" + HttpUtility.UrlEncode(originator) _
                '& "&serviceprovider=" _
                '& "&responseformat=html"

                request = DirectCast(WebRequest.Create(url), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)

                'MessageBox.Show("Response: " & response.StatusDescription)
            End If
        Catch ex As Exception
            MessageBox.Show("Netwrok Error.." & ex.ToString())
        End Try
    End Sub
    Public Sub SMSCR_TCL(ByVal BILLDETAIL, ByVal SOPBAL, ByVal STRANS, ByVal SMCODE, ByVal MBLNO, ByVal SDATE, ByVal OUTSTAN, ByVal PAYMODE, ByVal pc)
        If pc = "Y" Then
            Dim xmlobj
            Dim strPostData, params As String
            Dim SQLSTRING As String
            Dim USERID, SID, PWD As String
            Dim i As Integer
            Dim gconnection As New GlobalClass
            Dim url As String
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing

            USERID = Trim("1170603b51i3849hws3d1")
            SID = Trim("TWRCLB")
            PWD = Trim("5cbcb9383kdvdijxs")
            Try
                'Dim HttpReq As New WinHttpRequest
                If PAYMODE = "SMART CARD" Then
                    url = "http://dnd.adithya.me/api/web2sms.php?"
                    'params = "workingkey=" & USERID & "&sender=" & SID & "&to=" & MBLNO & "&message=Dear Member,P.O sales of your towers club. code " & SMCODE & " SM op.bal. Rs" & SOPBAL & " current bill rs " & STRANS & "/- SM cl bal rs " & OUTSTAN & " in towers club"
                    params = "workingkey=" & USERID & "&to=" & MBLNO & "&sender=" & SID & "&message=Dear Member,P.O sales of your towers club. code " & SMCODE & " SM op.bal. Rs" & SOPBAL & " current bill rs " & STRANS & "/- SM cl bal rs " & OUTSTAN & " in towers club"
                Else
                    url = "http://dnd.adithya.me/api/web2sms.php?"
                    'params = "workingkey=" & USERID & "&sender=" & SID & "&to=" & MBLNO & "&message=Dear Member,P.O sales of your towers club. code " & SMCODE & " op.bal. Rs" & SOPBAL & " current bill rs " & STRANS & "/- cl bal rs " & OUTSTAN & " in towers club"
                    params = "workingkey=" & USERID & "&to=" & MBLNO & "&sender=" & SID & "&message=Dear Member,P.O sales of your towers club. code " & SMCODE & " op.bal. Rs" & SOPBAL & " current bill rs " & STRANS & "/- cl bal rs " & OUTSTAN & " in towers club"
                End If
                url = url & params
                'HttpReq.Open("POST", url, False)
                'HttpReq.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                'HttpReq.Send(params)
                request = DirectCast(WebRequest.Create(url), HttpWebRequest)
                response = DirectCast(request.GetResponse(), HttpWebResponse)
            Catch
                MsgBox("Please Check Your Internet Connection")
            End Try
        End If
    End Sub
End Module
