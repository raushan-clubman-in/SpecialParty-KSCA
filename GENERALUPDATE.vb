Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Public Class GENERALUPDATE
    'Public Class General
    ' Methods
    Dim VCONN As New GlobalClass
    Dim CARDID1 As String
    Public Function FnReadDataFile() As Boolean
        Dim stream As FileStream
        Me.WizObj = New Wizard
        Dim path As String = "C:\KGACARD\Update.txt"
        Try
            If File.Exists(path) Then
                File.Delete(path)
            End If
            'VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Dim filewrite As System.IO.StreamWriter
            filewrite = File.AppendText(path)
            'If Txt_CardNo.Text = "" Then

            CARDID1 = VCONN.getvalue("SELECT isnull(MAX(CAST(CARDID AS NUMERIC) ),1110000)+1 FROM SMARTCARDDETAILS")

            ''Txt_CardNo.Text = CARDID1
            ''End If
            ''************8CHECK CASH DEPOSITED WITH CURRENT CARDID AND IF YES NOT ALLOW CARDID TO BE CHANGED
            'Dim SQLSTRING As String
            'SQLSTRING = "SELECT * FROM SM_CASHTRANSACTION WHERE CARDCODE='" & Trim(Txt_Cardcode.Text) & "' "
            'GConnection.getDataSet(SQLSTRING, "CardAmtMaster")
            'If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
            '    MsgBox("SMARTCARD TRANSACTIONS ALREADY TAKEN, CANNOT OVERWRITE", MsgBoxStyle.Information + MessageBoxButtons.OK, "CANNOT OVERWRITE")
            '    Exit Function
            'End If
            filewrite.WriteLine("""" & " YES~    " & CARDID1 & "~                    ~                         ~          ~       0~       0~       0~  /  /    ~" & Now() & "~     ~                    ~" & gUsername & "     ~ ~     ~     ~     ~     " & """")

            filewrite.Close()

            stream = File.Open(path, FileMode.Open, FileAccess.Read)
            Dim length As Long = stream.Length
            Dim buffer As Byte() = New Byte(stream.Length - 1) {}
            stream.Read(buffer, 0, CInt(length))
            Dim str2 As String = Encoding.ASCII.GetString(buffer)
            Dim startIndex As Integer = 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                startIndex += 1
            Loop
            startIndex += 1
            Do While (str2.Substring(startIndex, 1) <> "~")
                Me.WizObj.sBal = (Me.WizObj.sBal & str2.Substring(startIndex, 1))
                startIndex += 1
            Loop
            stream.Close()
        Catch exception As Exception
            Dim str3 As String = ""
            str3 = exception.ToString
            Console.WriteLine(str3)
            path = "C:\KGACARD\Error.txt"
            stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite)
            Dim num1 As Long = stream.Length
            Dim writer As New StreamWriter(stream)
            writer.WriteLine(str3)
            writer.Close()
            stream.Close()
            General.Sleep(&H7D0)
            Return False
        End Try
        Return True
    End Function

    Public Function FnReadKeyFile() As Boolean
        Dim stream As FileStream
        Dim path As String = "C:\KEY.txt"
        Try
            stream = File.Open(path, FileMode.Open, FileAccess.Read)
            Dim length As Long = stream.Length
            stream.Read(Me.bKEY, 0, CInt(stream.Length) - 2)
            stream.Close()
            Dim s As String = Encoding.ASCII.GetString(Me.bKEY)
            Me.bKEY = Encoding.ASCII.GetBytes(s)
        Catch exception As Exception
            path = "C:\KEYError.txt"
            Dim str3 As String = ""
            str3 = exception.ToString
            Console.WriteLine(str3)
            stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite)
            Dim num1 As Long = stream.Length
            Dim writer As New StreamWriter(stream)
            writer.WriteLine(str3)
            writer.Close()
            stream.Close()
            General.Sleep(&H7D0)
            Return False
        End Try
        Return True
    End Function

    Public Function FnUpdateCard() As Boolean
        Dim num2 As Integer
        Dim num As Integer = 0
        Dim sReader As Byte() = New Byte(100 - 1) {}
        Dim data As Byte() = New Byte(20 - 1) {}
        Dim buffer1 As Byte() = New Byte(10 - 1) {}
        Dim buffer3 As Byte() = New Byte(&H10 - 1) {}
        Dim password As Byte() = New Byte(3 - 1) {}
        Dim bInput As Byte() = New Byte(&H19 - 1) {}
        Dim bOutput As Byte() = New Byte(&H19 - 1) {}
        Dim ks As Byte() = New Byte(8 - 1) {}
        Dim buffer8 As Byte() = New Byte(3 - 1) {}
        Dim buffer9 As Byte() = New Byte(6 - 1) {}
        Dim buffer10 As Byte() = New Byte(8 - 1) {}
        Dim buffer11 As Byte() = New Byte(1 - 1) {}
        Dim flag As Boolean = False
        Dim index As Integer = 0
        Me.WizObj.sErrorMsg = ""
        num = CryptoDLL.InitReader_CM
        num = CryptoDLL.GetReaderName_CM(sReader, 0)
        num = CryptoDLL.PowerOff_CM
        If (CryptoDLL.PowerOn_CM(sReader) <> 0) Then
            Console.WriteLine("Error Powering on the Reader")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Powering on the Reader")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.CardPresent_CM <> 0) Then
            Console.WriteLine("Please Insert Card")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Please Insert Card")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        Select Case CryptoDLL.GetCardType_CM
            Case 10
                Console.WriteLine("Error Check Whether Card is Present")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Check Whether Card is Present")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            Case 1
                password(0) = &HDD
                password(1) = &H42
                password(2) = &H97
                Exit Select
            Case 2
                password(0) = &HE5
                password(1) = &H47
                password(2) = &H47
                Exit Select
            Case 3
                password(0) = &H60
                password(1) = &H57
                password(2) = &H34
                Exit Select
            Case 4
                password(0) = &H22
                password(1) = &HE8
                password(2) = &H3F
                Exit Select
            Case 5
                password(0) = &H20
                password(1) = 12
                password(2) = &HE0
                Exit Select
            Case 6
                password(0) = &HCB
                password(1) = 40
                password(2) = 80
                Exit Select
            Case 7
                password(0) = &HF7
                password(1) = &H62
                password(2) = 11
                Exit Select
            Case 8
                password(0) = &H22
                password(1) = &HEF
                password(2) = &H67
                Exit Select
            Case 9
                password(0) = &H17
                password(1) = &HC3
                password(2) = &H3A
                Exit Select
        End Select
        If (CryptoDLL.Read_Config_CM(12, 4, buffer9) <> 0) Then
            Console.WriteLine("Error Reading Data in Config Zone")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_Config_CM(&H20, 8, buffer10) <> 0) Then
            Console.WriteLine("Error Reading Data in Config Zone")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If ((buffer10(0) = &H57) AndAlso (buffer10(1) = &H3F)) Then
            If (CryptoDLL.Read_Config_CM(&H19, 1, buffer11) <> 0) Then
                Console.WriteLine("Error Reading Data from Config Zone")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (buffer11(0) = &H45) Then
                If (CryptoDLL.Read_Config_CM(&H40, &H10, buffer3) <> 0) Then
                    Console.WriteLine("Error Reading Data from Config Zone")
                    Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                num2 = 0
                Do While (num2 < 8)
                    bInput(num2) = Me.bKEY(num2)
                    num2 += 1
                Loop
                'index()
                For index = 0 To &H10 - 1
                    bInput(num2) = buffer3(index)
                    num2 += 1
                Next index
                CCS_Algorithms.fnSha1_Encryption(bInput, bOutput, &H18)
                index = 0
                'num2()
                For num2 = 8 To &H10 - 1
                    ks(index) = bOutput(num2)
                    index += 1
                Next num2
                password(0) = bOutput(0)
                password(1) = bOutput(1)
                password(2) = bOutput(2)
                If (CryptoDLL.Verify_Password_CM(0, 7, password, False) <> 0) Then
                    Console.WriteLine("Verify Password Failed")
                    Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Verify Password Failed")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                   
                End If
            Else
                If (CryptoDLL.Read_Config_CM(&H40, &H10, bInput) <> 0) Then
                    Console.WriteLine("Error Reading Data from Config Zone")
                    Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                CCS_Algorithms.fnSha1_Encryption(bInput, bOutput, &H10)
                'num2()
                For num2 = 8 To &H10 - 1
                    ks(index) = bOutput(num2)
                    index += 1
                Next num2
                password(0) = &H4B
                password(1) = &H47
                password(2) = &H41
                If (CryptoDLL.Verify_Password_CM(0, 7, password, False) <> 0) Then
                    Console.WriteLine("Verify Password Failed")
                    Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Verify Password Failed")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
            End If
            Dim buffer As Byte() = New Byte(8 - 1) {}
            ' New Random().NextBytes(buffer)
            Dim buffer13 As Byte() = New Byte(2 - 1) {}
            Dim buffer14 As Byte() = New Byte(8 - 1) {}
            If (CryptoDLL.Read_Config_CM(80, 8, buffer14) <> 0) Then
                Console.WriteLine("Error Reading Data from Config Zone")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in Config Zone")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            CryptoDLL.Init_Auth_CM(buffer14, ks, buffer)
            If (CryptoDLL.Authentication_CM(buffer, 0, 0) <> 0) Then
                Console.WriteLine("Error Authenticating the Card")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Authenticating the Card")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (CryptoDLL.Read_Config_CM(80, 1, buffer13) <> 0) Then
                Console.WriteLine("Error Reading Config Zone")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Config Zone")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (buffer13(0) <> &HFF) Then
                Console.WriteLine("Error Validating Authentication")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Validating Authentication")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (CryptoDLL.Authentication_CM(buffer, 1, 0) <> 0) Then
                Console.WriteLine("Error Authenticating the Card")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Authenticating the Card")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (CryptoDLL.Read_Config_CM(80, 1, buffer13) <> 0) Then
                Console.WriteLine("Error Reading Config Zone")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Config Zone")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (buffer13(0) <> &HFF) Then
                Console.WriteLine("Error Validating Authentication")
                Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Validating Authentication")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            flag = True '
        End If
        If (CryptoDLL.Set_Zone_CM(0, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 0")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 0")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_User_Zone_CM(4, 10, data) <> 0) Then
            Console.WriteLine("Error Writing Data in User Zone 1")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Writing Data in User Zone 1")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (data(0) = &HFF) Then
            Console.WriteLine("This is not a valid KGA Card")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error This is not a valid KGA Card")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        data = Encoding.ASCII.GetBytes(Me.WizObj.sBal)
        If (CryptoDLL.Set_Zone_CM(1, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 1")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 1")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Write_User_Zone_CM(&H37, 8, data) <> 0) Then
            Console.WriteLine("Error Writing Data in User Zone 1")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Writing Data in User Zone 1")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If ((buffer9(0) <> &H42) OrElse (buffer11(0) <> &H45)) Then
            If Not flag Then
                Dim buffer15 As Byte() = New Byte(4 - 1) {}
                'New Random().NextBytes(buffer3)
                num2 = 0
                Do While (num2 < 8)
                    bInput(num2) = Me.bKEY(num2)
                    num2 += 1
                Loop
                'index()
                For index = 0 To &H10 - 1
                    bInput(num2) = buffer3(index)
                    num2 += 1
                Next index
                CCS_Algorithms.fnSha1_Encryption(bInput, bOutput, &H18)
                index = 0
                'num2()
                For num2 = 8 To &H10 - 1
                    ks(index) = bOutput(num2)
                    index += 1
                Next num2
                buffer15(0) = &H42
                buffer15(1) = &H4E
                buffer15(2) = &H4C
                buffer15(3) = &H52
                If (CryptoDLL.Verify_Password_CM(0, 7, password, False) <> 0) Then
                    password(0) = &H4B
                    password(1) = &H47
                    password(2) = &H41
                    If (CryptoDLL.Verify_Password_CM(0, 7, password, False) <> 0) Then
                        Console.WriteLine("Verify Password Failed")
                        Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Verify Password Failed")
                        CryptoDLL.PowerOff_CM()
                        General.Sleep(&H7D0)
                        Return False
                    End If
                End If
                If (CryptoDLL.Write_Config_CM(12, 4, buffer15) <> 0) Then
                    Console.WriteLine("Error Writing Data in Config Zone")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                If (CryptoDLL.Write_Config_CM(&H40, &H10, buffer3) <> 0) Then
                    Console.WriteLine("Error Writing Data in Issuer Code")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                If (CryptoDLL.Write_Config_CM(&H90, 8, ks) <> 0) Then
                    Console.WriteLine("Error Writing Data in Issuer Code")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                buffer11(0) = &H45
                buffer10(0) = &H57
                buffer10(1) = &H3F
                buffer10(2) = &H57
                buffer10(3) = &H3F
                buffer10(4) = &H57
                buffer10(5) = &H3F
                buffer10(6) = &H57
                buffer10(7) = &H3F
                If (CryptoDLL.Write_Config_CM(&H19, 1, buffer11) <> 0) Then
                    Console.WriteLine("Error Writing Data in Access Registers")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                If (CryptoDLL.Write_Config_CM(&H20, 8, buffer10) <> 0) Then
                    Console.WriteLine("Error Writing Data in Access Registers")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                buffer8(0) = bOutput(0)
                buffer8(1) = bOutput(1)
                buffer8(2) = bOutput(2)
                If (CryptoDLL.Write_Config_CM(&HE9, 3, buffer8) <> 0) Then
                    Console.WriteLine("Error Writing Data in Config Zone")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                If (CryptoDLL.Verify_Password_CM(0, 7, buffer8, False) <> 0) Then
                    Console.WriteLine("Verify Password Failed")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
            End If
            Dim fuses As Byte() = New Byte(1 - 1) {}
            Dim fuseID As Integer = 0
            If (CryptoDLL.Read_Fuses_CM(fuses) <> 0) Then
                Console.WriteLine("Error Reading Data From Config Zone")
                CryptoDLL.PowerOff_CM()
                General.Sleep(&H7D0)
                Return False
            End If
            If (fuses(0) = 7) Then
                fuseID = 6
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                fuseID = 4
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                fuseID = 0
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
            End If
            If (fuses(0) = 6) Then
                fuseID = 4
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
                fuseID = 0
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
            End If
            If (fuses(0) = 4) Then
                fuseID = 0
                If (CryptoDLL.Write_Fuses_CM(fuseID) <> 0) Then
                    Console.WriteLine("Error Blowing Fuse")
                    CryptoDLL.PowerOff_CM()
                    General.Sleep(&H7D0)
                    Return False
                End If
            End If
        End If
        CryptoDLL.PowerOff_CM()
        Dim SQLSTRING As String
        SQLSTRING = "INSERT INTO SMARTCARDDETAILS(CARDID)VALUES('" & CARDID1 & "')"
        VCONN.dataOperation(6, SQLSTRING, "num1")
        Return True
    End Function

    <STAThread(), DllImport("kernel32.dll")> _
    Public Shared Sub Sleep(ByVal needed As Int32)
    End Sub


    ' Fields
    Private bKEY As Byte() = New Byte(8 - 1) {}
    Public WizObj As Wizard
    '  End Class


    'Collapse Methods


End Class
