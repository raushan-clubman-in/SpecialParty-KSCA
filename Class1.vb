Imports System.Runtime.InteropServices
Imports System.io
Friend Class Class1
    ' Methods
    Public Shared Sub Main(ByVal args As String())
        Dim general As New General
        Console.WriteLine("Reading Card.......")
        If Not general.FnReadKeyFile Then
            Console.WriteLine("Error reading specified file")
        ElseIf Not general.FnKGAReadCard Then
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
            Class1.Sleep(&H7D0)
        Else
            Console.WriteLine("Card Read Successfull")
            Console.WriteLine("Writing File.......")
            If Not general.FnWriteDataFile Then
                Class1.Sleep(&H7D0)
            Else
                Console.WriteLine("File Write Successfull")
                Dim str2 As String = "C:\KGACARD\Success.txt"
                Dim stream2 As FileStream = File.Open(str2, FileMode.Create, FileAccess.ReadWrite)
                Dim num2 As Long = stream2.Length
                'New StreamWriter(stream2).Close
                stream2.Close()
                Class1.Sleep(&H7D0)
            End If
        End If
    End Sub

    <STAThread(), DllImport("kernel32.dll")> _
    Public Shared Sub Sleep(ByVal needed As Long)
    End Sub

End Class


'Collapse Methods

