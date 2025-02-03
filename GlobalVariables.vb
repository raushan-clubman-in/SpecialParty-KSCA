Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Module GlobalVariables
    Public doclength, doctypelength As Integer

    ''MC SMARTCARD 
    ' Dim ListOperattion1 As New ListOperattion1
    Public dirbill As Boolean
    Public oldccrd As String
    Public strGlobeUserName, strGlobePassword As String
    Public cardprent As Boolean
    Public StrPOSCODE, strDocType As String
    Public greadertype As String
    Public SMSYN As String
    Public FKot As String
    Public FkotMcode As String
    Public Fkotscode As String
    Public Fkotpaymode As String
    Public DigitNumber As String
    Public gclosingvalue As Boolean = False
    Public GBL_SERVERTIME, GBL_SERVERTIME_SECONDS As DateTime
    Public KOTLEVELDEDUCT As String = "N"
    Public gPosPosting As String
    Public bselect As Boolean
    Public TABNO As Boolean
    Public gSmartCard As String
    Public RealD As Integer
    Public serverdate As DateTime
    Public servertime As DateTime
    Public billclosedate As DateTime
    Public BOOLCHECKKOT As Boolean
    Public smartdeviceportcount As Integer
    'FOR SMART CARD
    Public gPosUserControl As String
    Public ordertype As String
    Public kotbool123 As Boolean
    Public clearcheck As Boolean
    Public GSplashPath As String
    Public Cardidcheck As Boolean
    Public vCardcode, vTmp As String
    Public gdataset, dset As New DataSet
    'Public rptClass As New Report.Report
    Public GSALESACCOUNTCODEIN As String
    Public gSERVERCLIMITVALIDATE As String
    Public MemberOutstand As Double
    Public gBILLPRINT As String = "Y"
    Public gPrintOperation As String
    Public gPrintOperationabc As String
    Public gSUP_NAME As String
    Public gSUP_TINNO As String
    Public gMEMBERCLIMITVALIDATE As String
    Public GBL_SmartCardID As String
    Public GBL_ReadDelay As Integer
    Public COMPORT_SC As Integer
    Public GBL_SMARTCARDSNO As String
    Public rHandle As Integer
    Public retcode As Integer
    Public SID As Byte
    Public Sec As Integer
    Public pKey(5) As Byte
    Public gReaderType_code As String = "2"
    Public gReaderDesc As String
    Public gShortName As String = "1"
    Public gFoto As String = "Y"
    'Public gtinno As String
    Public BOOKINGNO As String
    Public listop As String
    Public CARDID_GBL As String
    Public ttime As Double
    Public MIN_BALANCE_GBL, MAX_BALANCE_GBL, BALANCE_HDR, MIN_USAGE_BALANCE_HDR As Double
    Public STRPHOTOPATH As String
    Public ACCESS_CHECK_GBL As Boolean
    Public CARD_Mcode_GBL, CARD_Subcode_GBL, CARD_CardHolderName_GBL As String
    Public CARD_Balance_GBL, PRINTREP As Double
    Public TOCARD_Balance_GBL As Double
    Public CARD_CardCode_GBL, TOCARD_CardCode_GBL As String
    Public BILL_FROM_ACCESS As Boolean
    Public gdataset1 As New DataSet
    Public vrowcnt As Int16
    Public ACC_ENTRY, POS_ENTREE As Boolean
    Public MCODE_GBL As String
    Public POSCODE_GBL, POSTYPE_GBL, DOCTYPE_GBL, BILLNO_GBL As String
    Public POSNAME_GBL As String
    Public POS_CHECK, D_CARDUPDATE As Boolean
    Public cardcode As String
    Public POS_AMT_GBL As Double 'AMT WITHOUT TAX
    Public POS_RATE_GBL, BILLAMT_GBL As Double 'BILL_AMT WITH TAX
    Public dc_trans_closed As Boolean
    Public NAME_GBL, KOT_NO_GBL As String
    Public MNAME_GBL, PAYMENTMODE_GBL As String
    Public SQLSTRING, SSTR As String
    'FOR SMART CARD

    'MC SMARTCARD ENDS 
    'KARTHI

    Public gDebtors, strCompany_ID, strDataSqlPwd, strDataSqlUsr As String
    Public gFinancialyearEnding, gFinancialyearStart As Date

    Public BarLimit As Double
    Public BILLROUNDYESNO As String
    Public ROUNDVAL As Integer
    Public chkdatevalidate As Boolean
    Public dblMsg As Double
    Public kotdetails As String
    Public strexcelpath As String
    Public kotupdate As Boolean
    Public MDIParentobj As Object
    Public gSQLString As String
    Public M_Groupby As String
    Public M_ORDERBY As String
    Public gridviewstatus As String
    Public SMENTTYPE As String
    Public gridviewHeading(5) As String
    Public gridviewPos As String
    Public M_WhereCondition As String
    Public gUsername As String
    Public gPoSUsername As String
    Public gPrint As Boolean
    Public AppPath As String
    Public gCompanyname As String
    Public gCompanyAddress(10) As String
    Public gTINNO As String
    Public gDatabase As String
    Public gDivCode As String
    Public gDivName As String
    Public gSeasion As String
    Public gUserCategory As String
    Public rac As Integer
    Public wemp1, wemp2, wemp3 As String
    Public Reportsql As String
    Public tables As String
    Public Gheader As String
    Public gserver As String
    Public gCompName As String

    Public gport As String
    Public gdreader As SqlDataReader
    Public gadapter As SqlDataAdapter
    Public gcommand As SqlCommand
    Public gfstream As FileStream
    Public gtrans As SqlTransaction
    Public Billstatusbool As Boolean
    Public Accountpostingbool As Boolean
    Public AutoServicebillbool As Boolean
    Public itemtypebool As Boolean
    Public itemmasterbool As Boolean
    Public GroupMasterbool As Boolean
    Public Paymentmodebool As Boolean
    Public POSMastbool As Boolean
    Public RateMastbool As Boolean
    Public UOMRelabool As Boolean
    Public ServerMastbool As Boolean
    Public categoryMastbool As Boolean
    Public kitchenMastbool As Boolean
    Public StewardMastbool As Boolean
    Public locationMastbool As Boolean
    Public TableMastbool As Boolean
    Public Possetupbool As Boolean
    Public UOMMastbool As Boolean
    Public UserAdminbool As Boolean
    Public gFinancalyearStart As String
    Public gFinancialYearEnd As String
    Public subpaymentmodebool As Boolean
    Public posdocumentbool As Boolean
    Public vOutfile, vheader, vLine As String
    Public Filewrite As StreamWriter
    Public VFilePath As String
    Public printfile As String
    Public kotentrybool As Boolean
    Public finalbillbool As Boolean
    Public manualbillbool As Boolean
    Public cashreceiptbool As Boolean
    Public Printername As String
    Public computername As String
    Public KotPrintername As String
    Public Kotcomputername As String
    Public Kot_Printername, Kot_Computername, Kot_PrintOption As String
    Public Search As String
    Public MyCompanyName As String
    Public Address1 As String
    'Public gtinno As Integer
    Public tinno As Integer
    Public Address2 As String
    Public gCity As String
    Public gState As String
    Public gPincode As String
    Public BillPrefix As String
    Public DefaultPayment As String

    Public GBillBasis As String

    Public PrintTaxheading1 As String
    Public PrintTaxheading2 As String
    Public gCreditors As String
    Public gDebitors As String
    Public GmoduleName As String

    Public gCompanyAddresses(10), gMAINCompanyname As String
    Public strFinancialYearStart, strFinancialYearEnd As Date

    'REFERINVENTORY
    Public CockTailRatioTransbool As Boolean

    Public fdataset As New DataSet

    'for version information

    'begin

    Public Filepath As String
    Public FileSize As Long
    Public dtCreationDate As DateTime
    Public dtLastAccessTime As DateTime
    Public dtLastWriteTime As DateTime
    Public GModule As String = "SMARTPOS"
    Public GVerValidate As Boolean = True

    Public gSYSTEMDATE As DateTime
    Public gserverMONTH As DateTime

    Public GAmountValidate As Boolean = False
    'end
    Public FormType As String
    Public boolProm As Boolean
    Public gCenterlized, gKotType, gKotPrefix, gPayMode, gTableReq, gWaiterReq As String
    Public pCenterlized, pKotType, pKotPrefix, pPayMode, pTableReq, pWaiterReq, RoundYN As String
    Public gPackPer, gTipsPer, gAdCgsPer, gPartyPer, gRoomPer As Double
    Public pPackPer, pTipsPer, pAdCgsPer, pPartyPer, pRoomPer As Double
    Public RndVal As Double
    Public GolfRegApp As String
    Public gPrevDatabase As String

    Public lastpaymode, MSUBCODE As String

    Public PartyAcccode As String

End Module
