Imports System.Runtime.InteropServices

Public Class CCS_Algorithms
    ' Methods
    Private Sub New()
    End Sub

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes_Decryption(ByVal bKey As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes_Encryption(ByVal bKey As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes3_Decryption2Keys(ByVal bKey1 As Byte(), ByVal bKey2 As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes3_Decryption3Keys(ByVal bKey1 As Byte(), ByVal bKey2 As Byte(), ByVal bKey3 As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes3_Encryption2Keys(ByVal bKey1 As Byte(), ByVal bKey2 As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnDes3_Encryption3Keys(ByVal bKey1 As Byte(), ByVal bKey2 As Byte(), ByVal bKey3 As Byte(), ByVal bInput As Byte(), ByVal bOutput As Byte()) As Integer
    End Function

    <DllImport("CCS_Algorithms.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function fnSha1_Encryption(ByVal bInput As Byte(), ByVal bOutput As Byte(), ByVal iLen As Integer) As Integer
    End Function

End Class





