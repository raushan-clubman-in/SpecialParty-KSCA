Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Public Class General
    ' Methods
    Public Function FnKGAReadCard() As Boolean
        Dim num2 As Integer
        Dim num As Integer = 0
        Dim sReader As Byte() = New Byte(100 - 1) {}
        Dim data As Byte() = New Byte(100 - 1) {}
        Dim str As String = ""
        Dim password As Byte() = New Byte(3 - 1) {}
        Dim buffer4 As Byte() = New Byte(&H10 - 1) {}
        Dim bInput As Byte() = New Byte(&H19 - 1) {}
        Dim bOutput As Byte() = New Byte(&H19 - 1) {}
        Dim ks As Byte() = New Byte(8 - 1) {}
        Dim buffer8 As Byte() = New Byte(3 - 1) {}
        Dim buffer9 As Byte() = New Byte(6 - 1) {}
        Dim buffer10 As Byte() = New Byte(8 - 1) {}
        Dim buffer11 As Byte() = New Byte(1 - 1) {}
        Dim flag As Boolean = False
        oldccrd = ""

        Dim index As Integer = 0
        Me.WizObj = New Wizard
        num = CryptoDLL.InitReader_CM
        Me.WizObj.sErrorMsg = ""
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
                If (CryptoDLL.Read_Config_CM(&H40, &H10, buffer4) <> 0) Then
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
                    bInput(num2) = buffer4(index)
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
                ' num2()
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
            flag = True
        End If
        If (CryptoDLL.Set_Zone_CM(0, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 0")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 0")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_User_Zone_CM(0, &H2D, data) <> 0) Then
            Console.WriteLine("Error Reading Data in User Zone 0")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in User Zone 0")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If ((data(0) = &HFF) OrElse (data(4) = &HFF)) Then
            Console.WriteLine("This is not a valid KGA Card")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error This is not a valid KGA Card")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        str = Encoding.ASCII.GetString(data)
        Me.WizObj.sLock = str.Substring(0, 4)
        oldccrd = str.Substring(0, 4)
        If Trim(oldccrd) <> "YES" Then
            MsgBox("THIS CARD IA NOT INIALIZED WITH CLUBMAN ! please initialize issue and then use")
            Return False
        End If
        Me.WizObj.sCrdNo = str.Substring(4, 12)
        GBL_SMARTCARDSNO = str.Substring(4, 12)
        Me.WizObj.sName = str.Substring(15, 30)
        If (CryptoDLL.Set_Zone_CM(1, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 1")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 1")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_User_Zone_CM(0, &H3F, data) <> 0) Then
            Console.WriteLine("Error Reading Data in User Zone 1")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Reading Data in User Zone 1")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        str = ""
        str = Encoding.ASCII.GetString(data)
        Me.WizObj.sClub = str.Substring(0, &H19)
        Me.WizObj.sACNo = str.Substring(&H1A, 10)
        Me.WizObj.sAmt = str.Substring(&H25, 8)
        Me.WizObj.sSecDep = str.Substring(&H2E, 8)
        Me.WizObj.sBal = str.Substring(&H37, 8)
        If (CryptoDLL.Set_Zone_CM(2, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 2")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 2")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_User_Zone_CM(0, &H39, data) <> 0) Then
            Console.WriteLine("Error Writing Data in User Zone 2")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Writing Data in User Zone 2")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        str = ""
        str = Encoding.ASCII.GetString(data)
        Me.WizObj.sCardValidity = str.Substring(0, 10)
        Me.WizObj.sDOI = str.Substring(11, 10)
        Me.WizObj.sTOI = str.Substring(&H16, 8)
        Me.WizObj.sMode = str.Substring(&H1F, 5)
        Me.WizObj.sCCREFNO = str.Substring(&H25, 20)
        If (CryptoDLL.Set_Zone_CM(3, 0) <> 0) Then
            Console.WriteLine("Error Setting User Zone 2")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Setting User Zone 3")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        If (CryptoDLL.Read_User_Zone_CM(0, &H2A, data) <> 0) Then
            Console.WriteLine("Error Writing Data in User Zone 3")
            Me.WizObj.sErrorMsg = (Me.WizObj.sErrorMsg & "Error Writing Data in User Zone 3")
            CryptoDLL.PowerOff_CM()
            General.Sleep(&H7D0)
            Return False
        End If
        str = ""
        str = Encoding.ASCII.GetString(data)
        Me.WizObj.sUSER = str.Substring(0, 10)
        Me.WizObj.sMEMCODE = str.Substring(11, 7)
        Me.WizObj.sSPCODE = str.Substring(&H13, 5)
        Me.WizObj.sDPCODE = str.Substring(&H19, 5)
        Me.WizObj.sEXTRA = str.Substring(&H1F, 5)
        Me.WizObj.sEXTRA1 = str.Substring(&H25, 5)
        If ((buffer9(0) <> &H42) OrElse (buffer11(0) <> &H45)) Then
            If Not flag Then
                Dim buffer15 As Byte() = New Byte(4 - 1) {}
                '  New Random().NextBytes(buffer4)
                num2 = 0
                Do While (num2 < 8)
                    bInput(num2) = Me.bKEY(num2)
                    num2 += 1
                Loop
                'index()
                For index = 0 To &H10 - 1
                    bInput(num2) = buffer4(index)
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
                If (CryptoDLL.Write_Config_CM(&H40, &H10, buffer4) <> 0) Then
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
        Return True
    End Function

    Public Function FnReadKeyFile() As Boolean
        Dim stream As FileStream
        Dim path As String = "D:\KEY.txt"
        Try
            'stream = Nothing
            stream = File.Open(path, FileMode.Open, FileAccess.Read)
            Dim length As Long = stream.Length
            stream.Read(Me.bKEY, 0, CInt(stream.Length) - 2)
            stream.Close()
            ' bKEY = Nothing
            ' bKEY = New Byte(8 - 1) {}

            'Me.bKEY(0) = Asc("S")
            'Me.bKEY(1) = Asc("K")
            'Me.bKEY(2) = Asc("R")
            'Me.bKEY(3) = Asc("I")
            'Me.bKEY(4) = Asc("S")
            'Me.bKEY(5) = Asc("H")
            'Me.bKEY(6) = Asc("N")
            'Me.bKEY(7) = Asc("A")
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

    Public Function FnWriteDataFile() As Boolean
        Dim stream As FileStream
        Dim str4 As String = String.Concat(New String() {"""", Me.WizObj.sLock, "~", Me.WizObj.sCrdNo, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sName, "~", Me.WizObj.sClub, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sACNo, "~", Me.WizObj.sAmt, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sSecDep, "~", Me.WizObj.sBal, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sCardValidity, "~", Me.WizObj.sDOI, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sTOI, "~", Me.WizObj.sMode, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sCCREFNO, "~", Me.WizObj.sUSER, "~"})
        str4 = String.Concat(New String() {str4, Me.WizObj.sMEMCODE, "~", Me.WizObj.sSPCODE, "~"})
        Dim str2 As String = (String.Concat(New String() {str4, Me.WizObj.sDPCODE, "~", Me.WizObj.sEXTRA, "~"}) & Me.WizObj.sEXTRA1 & """")
        Dim path As String = "C:\KGACARD\Read.txt"
        Try
            stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim length As Long = stream.Length
            Dim writer As New StreamWriter(stream)
            writer.WriteLine(str2)
            writer.Close()
            stream.Close()
        Catch exception As Exception
            Console.WriteLine(exception.ToString)
            path = "C:\KGACARD\Error.txt"
            Dim str3 As String = ""
            str3 = exception.ToString
            Console.WriteLine(str3)
            stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite)
            Dim num2 As Long = stream.Length
            Dim writer2 As New StreamWriter(stream)
            writer2.WriteLine(str3)
            writer2.Close()
            stream.Close()
            General.Sleep(&H7D0)
            Return False
        End Try
        Return True
    End Function

    '<DllImport("kernel32.dll")> _
    ' Public Shared Sub Sleep(ByVal needed As Long)
    ' End Sub


    ' Fields
    Private bKEY As Byte() = New Byte(8 - 1) {}
    Public WizObj As Wizard
    ' Friend Class Class1
    ' Methods
    Private Shared Sub Mainupd(ByVal args As String())
        Console.WriteLine("Reading File.......")
        Dim general As New General
        If Not Directory.Exists("C:\KGACARD") Then
            Directory.CreateDirectory("C:\KGACARD")
        End If
        If Not general.FnReadDataFile Then
            Console.WriteLine("Error reading specified file")
            Class1.Sleep(&H7D0)
        ElseIf Not general.FnReadKeyFile Then
            Console.WriteLine("Error reading specified file")
        ElseIf Not general.FnUpdateCard Then
            If Not Directory.Exists("C:\KGACARD") Then
                Directory.CreateDirectory("C:\KGACARD")
            End If
            Dim path As String = "C:\KGACARD\Error.txt"
            Dim stream As FileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite)
            Dim length As Long = stream.Length
            Dim writer As New StreamWriter(stream)
            writer.WriteLine(general.WizObj.sErrorMsg)
            writer.Close()
            stream.Close()
        Else
            Console.WriteLine("Card Updated Successfully")
            Dim str2 As String = "C:\KGACARD\Success.txt"
            Dim stream2 As FileStream = File.Open(str2, FileMode.Create, FileAccess.Write)
            Dim num2 As Long = stream2.Length
            'New StreamWriter(stream2).Close
            stream2.Close()
            Class1.Sleep(&H7D0)
        End If
    End Sub
    Public Function FnReadDataFileupd() As Boolean
        Dim stream As FileStream
        Me.WizObj = New Wizard
        Dim path As String = "C:\KGACARD\Update.txt"
        Try
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




    Public Function FnReadDataFile() As Boolean
        Dim stream As FileStream
        Me.WizObj = New Wizard
        Dim path As String = "C:\KGACARD\Update.txt"
        Try
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
    Public Function FnUpdateCardupd() As Boolean
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
                ' index()
                For index = 0 To &H10 - 1
                    bInput(num2) = buffer3(index)
                    num2 += 1
                Next index
                CCS_Algorithms.fnSha1_Encryption(bInput, bOutput, &H18)
                index = 0
                ' num2()
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
            'New Random().NextBytes(buffer)
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
            flag = True
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
                ' index()
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
                ' index()
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
            'New Random().NextBytes(buffer)
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
            flag = True
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
                ' num2()
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
        Return True
    End Function
    <STAThread(), DllImport("kernel32.dll")> _
    Public Shared Sub Sleep(ByVal needed As Int32)
    End Sub

End Class

