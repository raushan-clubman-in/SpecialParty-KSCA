Imports System.Runtime.InteropServices
Public Class CryptoDLL
    ' Methods
     <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Authentication_CM(ByVal Q0 As Byte(), ByVal AuthEnc As Integer, ByVal iSet As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function CardPresent_CM() As Integer
    End Function

     <DllImport("CCS_Crypto.dll")> _
    Public Shared Function ComputeGc_CM(ByVal Ks As Byte(), ByVal Nc As Byte(), ByVal Gc As Byte()) As Integer
    End Function

     <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnCardPresent_CM(ByVal cCardType As Byte(), ByVal cNoOfZones As Byte(), ByVal cZoneSize As Byte()) As Integer
    End Function

     <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnChangePassword_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal ChangePassword As Byte()) As Integer
    End Function

  <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnChangeSecureCode_CM(ByVal OldSecureCode As Byte(), ByVal NewSecureCode As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnInitializeAuthentication_CM(ByVal SetNuber As Integer, ByVal Ks As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
   Public Shared Function fnPersonalize_CM(ByVal iPersonalize As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadAAC_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadCMC_CM(ByVal bCMCData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadData_CM(ByVal Zone As Integer, ByVal ByteAddr As Integer, ByVal Noofbytes As Integer, ByVal bData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadIssuerCode_CM(ByVal bIssuerCode As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadMemoryTestZone_CM(ByVal bMTZ As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadNc_CM(ByVal bNc As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadPAC_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnReadPassword_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal Password As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnResetSecurity_CM() As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnSetSecurity_CM(ByVal iZone As Integer, ByVal Pwd As Integer, ByVal PwdSet As Integer, ByVal Auth As Integer, ByVal AuthSet As Integer, ByVal Enc As Integer, ByVal PokSet As Integer, ByVal WLM As Integer, ByVal ModifyForbidden As Integer, ByVal ProgramOnly As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnVerifyAuthentication_CM(ByVal SetNuber As Integer, ByVal Ks As Byte(), ByVal Enc As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnVerifySecureCode_CM(ByVal SecureCode As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteCMC_CM(ByVal bCMCData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteData_CM(ByVal Zone As Integer, ByVal ByteAddr As Integer, ByVal Noofbytes As Integer, ByVal bData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteDCR_CM(ByVal iOption As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteIssuerCode_CM(ByVal bIssuerCode As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteMemoryTestZone_CM(ByVal bMTZ As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function fnWriteNc_CM(ByVal bNc As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function GetCardName_CM(ByVal CardType As Integer, ByVal CardName As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function GetCardType_CM() As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function GetReaderName_CM(ByVal sReader As Byte(), ByVal index As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function Init_Auth_CM(ByVal Ci As Byte(), ByVal Ks As Byte(), ByVal Q0 As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function InitReader_CM() As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function PowerOff_CM() As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function PowerOn_CM(ByVal Reader As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function Read_Checksum_CM(ByVal Ch As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_Config_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_Fuses_CM(ByVal Fuses As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_Password_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte(), ByVal Encrypt As Boolean) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_PasswordEnc_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte(), ByVal Encrypt As Boolean, ByVal EncData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_User_Zone_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Read_User_ZoneEnc_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte(), ByVal EncData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Reset_Auth_CM(ByVal iSet As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Reset_Password_CM(ByVal Zone As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Set_Zone_CM(ByVal Zone As Integer, ByVal AntiTear As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Verify_Password_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal Password As Byte(), ByVal Encrypt As Boolean) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Verify_PasswordEnc_CM(ByVal ReadWrite As Integer, ByVal SetNumber As Integer, ByVal Password As Byte(), ByVal Encrypt As Boolean, ByVal EncData As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
      Public Shared Function Write_Config_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Write_Fuses_CM(ByVal FuseID As Integer) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Write_User_Zone_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte()) As Integer
    End Function

    <DllImport("CCS_Crypto.dll")> _
    Public Shared Function Write_User_ZoneEnc_CM(ByVal ByteAddr As Integer, ByVal NOB As Integer, ByVal Data As Byte(), ByVal EncData As Byte()) As Integer
    End Function

End Class


'Collapse Methods

