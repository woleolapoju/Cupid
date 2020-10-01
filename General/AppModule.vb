Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Module AppModule
    Public LogOffIn As Boolean = False
    Public strApptitle As String = "Cupid"
    Public sysOwner As String = "Megahit Systems"
    Public strOwnerFromServer As String = "Megahit Systems"
    Public sysUser As String = ""
    Public sysPwd As String = ""
    Public sysPeriod As String = "01-Jan-1880 To 01-Jan-1880"
    Public strPeriod As String = ""
    Public strConnect As String = ""
    Public sysUserName As String = ""
    Public ServerName As String
    Public Password As String
    Public UserID As String
    Public IntegratedSecurity As Boolean
    Public AttachName As String
    Public AppPath As String
    Public arrayLogo() As Byte
    Public PictBody As Integer
    Public arrayBody() As Byte
    Public arrayHeader() As Byte
    Public sysStartDate, sysEndDate As Date
    Public ModuleOpen, ModuleAdd, ModuleEdit, ModuleBrowse, ModuleDelete, ModuleAuthorise, ReportOpen As Boolean
    Public IsFormValid As Boolean = True
    Public MSAccessCn As String
    Public Address, Phone As String
    Public SalesInputLayout As String
    Public DateDurationValidation As Integer = 15

    'Public UnreadMail As Integer = 0

    Public eDocDir As String

    Public ST_IgnoreStoreAssignment As Boolean
    Public ST_TransType As String

    Public RefNo As String = ""
    Public LogOnFail As Boolean = False
    Public ProgramAccess As String = ""

    'Public fmt As String = "###,##0.00" 'used to format number
    Public Gen As String = "General Number"

    Public BackupPath As String

    Public MainTheme As Color = Color.Khaki
    Public HeaderTheme As Color = Color.Goldenrod
    Public MainThemeCode As String = ""
    Public HeaderThemeCode As String = ""

    Public myStyleGridAlternate As New DataGridViewCellStyle

    Public cnSQL As SqlConnection

    Public Vat As Double = 0
    Public Discount As Double = 0
    Public POSPrinter As String = ""
    Public POSPole As String = ""
    Public PrintInvoice As Boolean = False
    Public InvoiceType As String = ""
    Private mySerialPort As New SerialPort
    '__________________________________________________
    'USERS
    'KAMDI COMPUTERS
    'JUSTLABEL
    '__________________________________________________
    Public Enum AppAction
        Add = 1
        Edit = 2
        Delete = 3
        Browse = 4
        Authorise = 5
        Open = 6
    End Enum
    Sub New()
        On Error GoTo handler
        sysOwner = "Megahit Systems, Abuja"
        AppPath = IIf(Len(My.Application.Info.DirectoryPath) <= 3, My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath + "\")
        '  AppPath = "C:\Applications\Cupid\"
        MSAccessCn = "Provider=Microsoft.jet.oledb.4.0;Data Source=" + AppPath + "ConfigDir\Config.gif;Jet OLEDB:Database Password=secret" ' & 

        DeleteHTMTempFiles()

        InitialiseEntireSystem()
        'If Not (Format(Now, "dd-MMM-yyyy") >= CDate("01-jul-2008") And Format(Now, "dd-MMM-yyyy") <= CDate("31-Aug-2008")) Then
        '    End
        'End If

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    'Sub Main()
    '    FrmSplash.ShowDialog()
    '    FrmStart.ShowDialog()
    'End Sub
    Public Function GetUserAccessDetails(ByVal dModule As String, Optional ByVal DisplayMsg As Boolean = True) As Boolean
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        GetUserAccessDetails = False
        ModuleOpen = False : ModuleAdd = False : ModuleEdit = False : ModuleBrowse = False : ModuleDelete = False : ModuleAuthorise = False

        ' Try
        On Error Resume Next
        'cnSQL.Open()

        cmSQL.CommandText = "FetchUserDetails"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@UserID", sysUser)
        cmSQL.Parameters.AddWithValue("@ModuleID", dModule)

        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
        Else
            If drSQL.Read Then
                ModuleOpen = drSQL.Item("AllowOpen")
                ModuleAdd = drSQL.Item("AllowAdd")
                ModuleEdit = drSQL.Item("AllowEdit")
                ModuleBrowse = drSQL.Item("AllowBrowse")
                ModuleDelete = drSQL.Item("AllowDelete")
                ModuleAuthorise = drSQL.Item("AllowAuthorise")
                GetUserAccessDetails = drSQL.Item("AllowOpen")
            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        If ModuleOpen = False And DisplayMsg = True Then MsgBox("Access is denied to the " + Chr(13) + UCase(dModule) + " module", MsgBoxStyle.Information, strApptitle)
        'Catch e As Exception
        '    MsgBox(e.Message, MsgBoxStyle.Critical, strApptitle)
        'End Try
    End Function
    Public Function GetUserReportAccess(ByVal dReport As String, Optional ByVal DisplayMsg As Boolean = True) As Boolean
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        GetUserReportAccess = False

        Try

            'cnSQL.Open()

            cmSQL.CommandText = "FetchUserReport"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@UserID", sysUser)
            cmSQL.Parameters.AddWithValue("@ReportID", dReport)

            drSQL = cmSQL.ExecuteReader()
            If drSQL.HasRows = False Then
            Else
                If drSQL.Read Then
                    GetUserReportAccess = drSQL.Item("AllowOpen")
                End If
            End If
            'cmSQL.Connection.Close()
            cmSQL.Dispose()
            drSQL.Close()
            ' cnSQL.Close()
            'cnSQL.Dispose()
            If GetUserReportAccess = False And DisplayMsg = True Then MsgBox("Access is denied to the " + Chr(13) + UCase(dReport) + " report", MsgBoxStyle.Information, strApptitle)
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, strApptitle)
        End Try
    End Function
    Public Sub InitialiseEntireSystem()
        sysOwner = "Megahit Systems, Abuja"
        Dim cnOle As OleDbConnection
        Dim cmOle As OleDbCommand
        Dim drOle As OleDbDataReader
        ReDim arrayLogo(0)
        On Error GoTo handler
        cnOle = New OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=" & AppPath & "ConfigDir\Config.gif;Jet OLEDB:Database Password=secret")
        cnOle.Open()

        cmOle = New OleDbCommand("SELECT * FROM SvrParam", cnOle)
        drOle = cmOle.ExecuteReader()

        If drOle.HasRows = False Then
            MsgBox("Invalid Configuration Parameter" & Chr(13) & "System Halted", MsgBoxStyle.Information)
            End
        End If
        If drOle.Read Then
            ServerName = IIf(IsDBNull(drOle.Item("ServerName").ToString()), "", drOle.Item("ServerName").ToString())
            UserID = IIf(IsDBNull(drOle.Item("UserID").ToString()), "", drOle.Item("UserID").ToString())
            Password = IIf(IsDBNull(drOle.Item("Password").ToString()), "", drOle.Item("Password").ToString())
            IntegratedSecurity = drOle.Item("IntegratedSecurity")
            sysOwner = IIf(IsDBNull(drOle.Item("Owner").ToString()), "Invalid User", drOle.Item("Owner").ToString())
            AttachName = IIf(IsDBNull(drOle.Item("AttachName").ToString()), "", drOle.Item("AttachName").ToString())
        End If
        If drOle.Item("IntegratedSecurity") = False Then
            'strConnect = "Data Source=tcp:" & ServerName & ";Initial Catalog=" & AttachName & ";Persist Security Info=True;User ID=" & UserID & ";Password=" & Password
            strConnect = "SERVER=" & ServerName & ";Initial Catalog=" & AttachName & ";Persist Security Info=True;Connection Timeout=90;User ID=" & UserID & ";Password=" & Password
            'Connection Timeout=0 ' indefinite
        Else
            strConnect = "SERVER=" & ServerName & ";Initial Catalog=" & AttachName & ";Integrated Security=True;Connection Timeout=90"
        End If

        '"Provider=SQLOLEDB;Data Source=(local);User ID=sa;Initial Catalog=Cupid

        drOle.Close()
        cnOle.Close()
        cmOle.Dispose()
        cnOle.Dispose()

skipIt:
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        cnSQL = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cnSQL.Open()

        'Dim cnSQL4Notices As SqlConnection = New SqlConnection(strConnect)
        cnSQL4Notices = New SqlConnection(strConnect)
        cnSQL4Notices.Open()

        'MsgBox(cnSQL.State)
        'MsgBox(cnSQL.ConnectionTimeout)

        cmSQL.CommandText = "FetchAllSystemParameters"
        cmSQL.CommandType = CommandType.StoredProcedure
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            MsgBox("Invalid System Parameters")
            End
        Else
            If drSQL.Read Then
                sysPeriod = Format(drSQL.Item("StartDate"), "dd-MMM-yyyy") + " To " + Format(drSQL.Item("EndDate"), "dd-MMM-yyyy")
                strOwnerFromServer = drSQL.Item("NName")
                strPeriod = drSQL.Item("Period")
                sysStartDate = drSQL.Item("StartDate")
                sysEndDate = drSQL.Item("EndDate")
                arrayLogo = CType(drSQL.Item("Logo"), Byte())
                eDocDir = ChkNull(drSQL.Item("eDocPath"))

                BackupPath = ChkNull(drSQL.Item("BackupPath"))


                FrmStart.mnuSystemPeriod.Text = "System Period : " + sysPeriod

                strOwnerFromServer = drSQL.Item("NName")
                Vat = drSQL.Item("Vat")
                Discount = drSQL.Item("Discount")
                POSPrinter = drSQL.Item("POSPrinter")
                POSPole = drSQL.Item("POSPole")
                PrintInvoice = drSQL.Item("PrintInvoice")
                InvoiceType = drSQL.Item("InvoiceType")
                Address = drSQL.Item("Address")
                Phone = drSQL.Item("Phone")

                ST_IgnoreStoreAssignment = drSQL.Item("IgnoreStoreAssignment")

                ST_TransType = drSQL.Item("TransType")
                SalesInputLayout = drSQL.Item("SalesInputLayout")

                On Error Resume Next
                DateDurationValidation = Val(ChkNull(drSQL.Item("DateDurationValidation")))
                On Error GoTo handler


            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        ''cnSQL.Dispose()



        Exit Sub
handler:
        If Err.Description Like "Cannot open database requested in login 'Cupid'. Login fails*" Then
            If My.Computer.Name = ServerName Or UCase(ServerName) = "(LOCAL)" Then
                attachDB(AttachName)
            Else
                MsgBox("Database not attached...Pls. refer to the system administrator", MsgBoxStyle.Information, strApptitle)
            End If
        ElseIf Err.Number = 5 Then
            ServerName = "(local)"
            UserID = "sa"
            Password = "penny"
            IntegratedSecurity = "false"
            sysOwner = "MEGAHIT SYSTEMS"
            AttachName = "Cupid"
            strConnect = "Data Source=" & ServerName & ";Initial Catalog=" & AttachName & ";Persist Security Info=True;Connection Timeout=30;User ID=" & UserID & ";Password=" & Password

            GoTo SkipIt
            'Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Critical, strApptitle)
            If Err.Description Like "*Login fails*" Then LogOnFail = True
        End If
    End Sub
    Sub attachDB(ByVal attachName As String)
        On Error GoTo handler
        Dim connectStr As String = ""

        If IntegratedSecurity Then
            connectStr = "workstation id=" & ServerName & ";packet size=4096;data source=" & ServerName & ";Integrated Security=True;initial catalog=master"
        Else
            connectStr = "workstation id=" & ServerName & ";packet size=4096;user id=" & UserID & ";pwd=" & Password & ";data source=" & ServerName & ";persist security info=False;initial catalog=master"
        End If

        Dim SqlCn As SqlConnection = New SqlConnection(connectStr)
        Dim strConnectMaster As String
        SqlCn.Open()
        On Error Resume Next

        Dim myCommand As SqlCommand = SqlCn.CreateCommand

        On Error GoTo handler
        Dim DBName As String = AppPath + "ConfigDir\Cupid.mdf"
        myCommand.CommandText = "EXEC sp_attach_db @dbname = N'" & attachName & "',@filename1 = N'" & DBName & "',@filename2 = N'" & Mid(Trim(DBName), 1, InStr(Trim(DBName), ".") - 1) + ".ldf" & "'"
        myCommand.ExecuteNonQuery()

        myCommand.Connection.Close()
        myCommand.Dispose()
        SqlCn.Close()
        SqlCn.Dispose()
        MsgBox("Pls. restart the application", MsgBoxStyle.Information, strApptitle)
        End
        Exit Sub
        Resume
handler:
        MsgBox("Pls. refer to the system administrator", MsgBoxStyle.Information, strApptitle)

        'MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Public Function ValidateDate(ByVal TheDate As Date, Optional ByVal DateName As String = "") As Boolean
        ValidateDate = True
        On Error GoTo handler
        TheDate = Format(TheDate, "dd-MMM-yyyy")
        If Not (TheDate >= sysStartDate And TheDate <= sysEndDate) Then
            MsgBox(DateName + " Date does not fall within System Period", vbCritical, strApptitle)
            ValidateDate = False

        End If
        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function
    Public Function GetIt4Me(ByVal TheStr As String, ByVal LocStr As String) As String
        On Error GoTo handler
        GetIt4Me = ""
        If TheStr = "" Or LocStr = "" Then Exit Function
        GetIt4Me = TheStr
        Dim TheLen As Integer = InStr(Trim(TheStr), LocStr)
        If TheLen <> 0 Then GetIt4Me = Trim(Mid$(Trim(TheStr), 1, TheLen - 1))
        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function
    Public Function ChkNull(ByVal TheStr, Optional ByVal tType = "") As String
        On Error GoTo handler
        ''Resume Next
        'If tType <> "" Then
        '    If tType = "Decimal" Then
        '        ChkNull = IIf(IsDBNull(TheStr), 0, TheStr.ToString)
        '    End If
        'End If
        ChkNull = IIf(IsDBNull(TheStr).ToString, "", TheStr.ToString)
        'ChkNull = IIf(IsDBNull(TheStr), "", TheStr.ToString)
        Exit Function
handler:
        ChkNull = ""
    End Function
    Public Function formatDate(ByVal dtp As DateTimePicker) As Date
        If dtp.ShowCheckBox = True Then
            If dtp.Checked = False Then
                formatDate = "31-Dec-9998"
            Else
                formatDate = Format(dtp.Value, "dd-MMM-yyyy")
            End If
        Else
            formatDate = Format(dtp.Value, "dd-MMM-yyyy")
        End If
    End Function
    Private Sub DeleteHTMTempFiles()
        On Error Resume Next
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Temp, FileIO.SearchOption.SearchTopLevelOnly, "*.cup")
            Kill(foundFile)
        Next
    End Sub
    Public Sub Print2ComPort(ByVal tComPort As String, ByVal tText As String)
        On Error GoTo handler
        If Trim(tText) = "" Then Exit Sub
        With mySerialPort
            .PortName = tComPort
            .BaudRate = 9600
            .DataBits = 8
            .Parity = Parity.None
            .StopBits = StopBits.One
            ' .Handshake = Handshake.None
        End With
        'mySerialPort.PortName = tComPort
        'mySerialPort.StopBits = StopBits.One
        'mySerialPort.DataBits = 0
        'mySerialPort.BaudRate = 9600

        mySerialPort.Open()
        'mySerialPort.DiscardInBuffer()
        'mySerialPort.DiscardOutBuffer()
        ' mySerialPort.NewLine
        'Dim instance As SerialPort
        'Dim text As String
        mySerialPort.WriteLine(tText.ToString)
        mySerialPort.Close()
        Exit Sub
handler:
        If Err.Number = 5 Then
            Err.Clear()
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Public Sub CloseFrm(ByVal FrmName As String, Optional ByVal All As Boolean = False)
        On Error Resume Next
        If FrmName = "" Then Exit Sub
        ' Close all child forms of the parent.
        For Each ChildForm As Form In FrmStart.MdiChildren
            If All Then
                If Not (ChildForm.Name = "FrmMain" Or ChildForm.Name = FrmName) Then ChildForm.Close()
            Else
                If Not (ChildForm.Name = "FrmMain" Or ChildForm.Name = FrmName Or ChildForm.Name Like "*Start") Then ChildForm.Close()
            End If
        Next
    End Sub
    Public Function GetItLast4Me(ByVal TheStr As String, ByVal LocStr As String) As String
        On Error GoTo handler
        GetItLast4Me = ""
        If TheStr = "" Or LocStr = "" Then Exit Function
        GetItLast4Me = TheStr
        Dim TheLen As Integer = InStr(Trim(TheStr), LocStr)
        If TheLen <> 0 Then
            GetItLast4Me = Trim(Mid$(Trim(TheStr), 1, TheLen - 1))
            GetItLast4Me = Mid(TheStr, Len(GetItLast4Me) + 4)
        End If

        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function

End Module
