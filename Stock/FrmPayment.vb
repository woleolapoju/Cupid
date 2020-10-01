Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmPayment
    Public PayType As String
    Dim Action As AppAction
    Public PaymentTag As Integer
    Public ReturnRefNo As Integer
    Public ReturnCode As String
    Public ReturnAmt As String
    Dim AddIn, EditIn, BrowseIn, DeleteIn As Boolean
    Dim AddOut, EditOut, BrowseOut, DeleteOut As Boolean
    Private Sub FrmPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Payment " + PayType + " - " + IIf(PayType = "Inwards", "Receiveables", "Payables")
        AppHeader1.lblForm.Text = "Payment " + PayType + " - " + IIf(PayType = "Inwards", "Receiveables", "Payables")
        Label6.Text = ""
        Me.BackColor = MainTheme
        tCustomerName.BackColor = MainTheme
        tRefNo.BackColor = MainTheme
        lvList.BackColor = MainTheme

        RadInwards.Enabled = GetUserAccessDetails("Payment Inwards")

        AddIn = ModuleAdd
        EditIn = ModuleEdit
        BrowseIn = ModuleBrowse
        DeleteIn = ModuleDelete


        RadOutwards.Enabled = GetUserAccessDetails("Payment Outwards")
        AddOut = ModuleAdd
        EditOut = ModuleEdit
        BrowseOut = ModuleBrowse
        DeleteOut = ModuleDelete

        If RadInwards.Enabled = True Then
            RadInwards.Checked = True
            RadInwards_Click(sender, e)
        Else
            If RadOutwards.Enabled = True Then RadOutwards_Click(sender, e)
        End If


        cPayMode.SelectedIndex = 0
        oLoadBank()

        Action = AppAction.Add

        dtpDate.Value = Now
        dtpDateTrans.Value = DateAdd(DateInterval.Day, -14, Now)

        mnuDelete.Enabled = ModuleDelete
        If ModuleAdd Then FetchNextNo()

    End Sub

    Private Sub cPayMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cPayMode.SelectedIndexChanged
        If cPayMode.Text = "Cash" Then
            PanPayType.Visible = False
        Else
            PanPayType.Visible = True
        End If
    End Sub
    Private Function oLoadCustomer(ByVal strValue As String) As Boolean
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        oLoadCustomer = False
        If strValue = "" Then Exit Function

        cmSQL.CommandText = "FetchClient"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ID", strValue)

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then GoTo SkipIt
        If drSQL.Read Then
            tCustomerCode.Text = drSQL.Item("ID")
            tCustomerName.Text = drSQL.Item("Name")
        End If
        oLoadCustomer = True
SkipIt:
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function

    Private Sub tCustomerCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tCustomerCode.LostFocus
        tCustomerName.Text = ""
        If oLoadCustomer(tCustomerCode.Text) = False And Trim(tCustomerCode.Text) <> "" Then
            MsgBox("Customer do not exist", MsgBoxStyle.Information, strApptitle)
            tCustomerCode.Focus()
        End If
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If ValidateDate(dtpDate.Text, "Payment Date") = False Then Exit Sub

        If Action <> AppAction.Delete Then
            If cPayMode.Text <> "Cash" And Trim(cBank.Text) = "" Then
                MsgBox("Please enter payment details for the mode chosen", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "" Then
                MsgBox("Client information required", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If

            If Val(tPaid.Text) <= 0 Then
                MsgBox("Amount paid must be greater than zero (0)", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(tPurpose.Text) = "" Then
                MsgBox("Payment Purpose is required", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
        End If
        'cnSQL.Open()
        If Action = AppAction.Add Then FetchNextNo()

        Dim myTrans As SqlClient.SqlTransaction

        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans
        Dim BankCode As String = GetIt4Me(cBank.Text, " - ")
        If Action = AppAction.Delete Then
            If MsgBox("The Selected Payment would be deleted" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = MsgBoxResult.No Then Exit Sub
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeletePayments"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@PaymentTag", Val(tRefNo.Text))
            cmSQL.ExecuteNonQuery()
            GoTo SkipIt
        End If
        If Action = AppAction.Edit Then
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeletePayments"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@PaymentTag", Val(tRefNo.Text))
            cmSQL.ExecuteNonQuery()
        End If
        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "InsertPayments"
        cmSQL.CommandType = CommandType.StoredProcedure

        cmSQL.Parameters.AddWithValue("@AmtPaid", CDbl(tPaid.Text))
        If cPayMode.Text = "Cash" Then
            cmSQL.Parameters.AddWithValue("@Bank", "CASH")
            cmSQL.Parameters.AddWithValue("@ChequeNo", "")
            cmSQL.Parameters.AddWithValue("@BankCode", "0001")
        Else
            If PayType = "Inwards" Then
                cmSQL.Parameters.AddWithValue("@Bank", cBank.Text)
                cmSQL.Parameters.AddWithValue("@BankCode", "")
            Else
                cmSQL.Parameters.AddWithValue("@Bank", Microsoft.VisualBasic.Mid(cBank.Text, Len(BankCode) + 4))
                cmSQL.Parameters.AddWithValue("@BankCode", BankCode)
            End If
            cmSQL.Parameters.AddWithValue("@ChequeNo", tCheqNo.Text)
        End If
        cmSQL.Parameters.AddWithValue("@ClientCode", tCustomerCode.Text)
        cmSQL.Parameters.AddWithValue("@ClientName", tCustomerName.Text)
        cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
        cmSQL.Parameters.AddWithValue("@Purpose", tPurpose.Text)
        cmSQL.Parameters.AddWithValue("@AmtWord", Towords(Val(tPaid.Text), "Naira", "Kobo"))
        cmSQL.Parameters.AddWithValue("@PayMode", cPayMode.Text)
        cmSQL.Parameters.AddWithValue("@PayType", IIf(PayType = "Inwards", "Receiveable", "Payable"))
        cmSQL.Parameters.AddWithValue("@UserName", sysUserName)
        cmSQL.Parameters.AddWithValue("@DepositTag", 0)
        cmSQL.ExecuteNonQuery()

skipIt:
        myTrans.Commit()


        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        LoadLvList()

        If chkPrint.Checked = True And Action <> AppAction.Delete Then

            If GetUserReportAccess("Payment Receipt") = False Then Exit Sub

            Dim report As New ReportDocument()
            report.Load(AppPath + "ConfigDir\Receipt.rpt")


            Dim intCounter As Integer
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
            ConInfo.ConnectionInfo.DatabaseName = AttachName
            ConInfo.ConnectionInfo.ServerName = ServerName
            If IntegratedSecurity Then
                ConInfo.ConnectionInfo.IntegratedSecurity = True
            Else
                ConInfo.ConnectionInfo.Password = Password
                ConInfo.ConnectionInfo.UserID = UserID
            End If

            For intCounter = 0 To report.Database.Tables.Count - 1
                report.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next


            ' You can change more print options via PrintOptions property of ReportDocument
            Dim SelFormular As String = "{RptPayments.PaymentTag}='" & Val(tRefNo.Text) & "' AND {RptPayments.PayType}='Receiveable'"

            report.RecordSelectionFormula = SelFormular

            report.SetDatabaseLogon(UserID, Password)
            report.PrintToPrinter(1, True, 0, 0)
            report.Close()

        End If

        flush()

        If ModuleAdd Then
            Action = AppAction.Add
            FetchNextNo()
        End If

        Exit Sub
        Resume
handler:

        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        '        myTrans.Rollback()

    End Sub
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub
    Sub flush()
        dtpDate.Value = Now
        tRefNo.Text = ""

        tPaid.Text = 0
        tCustomerCode.Text = ""
        tCustomerName.Text = ""

        tCheqNo.Text = ""
        tPurpose.Text = ""
    End Sub
    Private Function FetchNextNo() As Integer
        On Error GoTo errhdl
        FetchNextNo = 0
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewPaymentTag"
        cmSQL.Parameters.AddWithValue("@PayType", IIf(PayType = "Inwards", "Receiveable", "Payable"))
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then If drSQL.Read Then tRefNo.Text = drSQL.Item("NewNo")
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    
    Private Sub oLoadBank()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cBank.Items.Clear()
        cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart WHERE Category='BANK' ORDER BY Description"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cBank.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        cBank.SelectedIndex = 0

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub cmdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomer.Click
        If GetUserAccessDetails("Setup - Client Register") = False Then Exit Sub
        Dim ChildForm As New FrmClient
        ChildForm.txt = tCustomerCode
        ChildForm.ShowDialog()
        If tCustomerCode.Text <> "" Then tCustomerCode_LostFocus(sender, e)

    End Sub

    Private Sub cmdFetchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFetchCustomer.Click
        On Error GoTo errhdl
        'Dim strCaption(5) As String
        'Dim intWidth(5) As Integer
        'strCaption(0) = "ID"
        'intWidth(0) = 40
        'strCaption(1) = "Name"
        'intWidth(1) = 120
        'strCaption(2) = "Address"
        'intWidth(2) = 120
        'strCaption(3) = "Contact Person"
        'intWidth(3) = 100
        'strCaption(4) = "Client Type"
        'intWidth(4) = 80

        With FrmList
            .frmParent = Me
            .tSelection = IIf(PayType = "Inwards", "Customer", "Supplier")
            .listQuery = IIf(PayType = "Inwards", "Customer", "Supplier")
            .Text = "List of Clients"
            .ShowDialog()
        End With
        tCustomerCode.Text = ReturnCode
        tCustomerCode_LostFocus(sender, e)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub LoadLvList()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim strQry As String = ""
        lvList.Items.Clear()
        'flush()

        If PayType = "Inwards" Then strQry = "SELECT  CustomerCode,CustomerName,Balance FROM  ClientBalances WHERE Balance>0 AND (CustomerCode<>'' AND NOT CustomerCode IS NULL) ORDER BY CustomerCode"
        If PayType = "Outwards" Then strQry = "SELECT  CustomerCode,CustomerName,0-isnull(Balance,0) AS Balance FROM  ClientBalances WHERE Balance<0 AND (CustomerCode<>'' AND NOT CustomerCode IS NULL) ORDER BY CustomerCode"

        cmSQL.CommandText = strQry
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        Dim j As Integer = 0
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("CustomerCode").ToString)
            LvItems.SubItems.Add(drSQL.Item("CustomerName"))
            LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("Balance"), 2), "standard"))
            lvList.Items.AddRange(New ListViewItem() {LvItems})
            j = j + 1
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)

        

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        flush()
        Action = AppAction.Add
        If ModuleAdd Then FetchNextNo()

    End Sub
    Private Sub RadInwards_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadInwards.Click
        cBank.DropDownStyle = ComboBoxStyle.Simple
        chkPrint.Visible = True
        cBank.Text = ""

        mnuNew.Enabled = AddIn
        mnuEdit.Enabled = EditIn
        mnuBrowse.Enabled = BrowseIn
        mnuDelete.Enabled = DeleteIn

        Action = Nothing
        If mnuNew.Enabled = True Then mnuNew_Click(sender, e)

        PayType = "Inwards"
        Me.Text = "Payment " + PayType + " - " + IIf(PayType = "Inwards", "Receiveables", "Payables")
        AppHeader1.lblForm.Text = "Payments " + IIf(PayType = "Inwards", "Received FROM Clients", "Given TO Clients")



        LoadLvList()

        Label6.Text = "DEBIT CLIENT"

    End Sub

    Private Sub RadOutwards_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadOutwards.Click
        cBank.DropDownStyle = ComboBoxStyle.DropDownList
        chkPrint.Visible = False

        mnuNew.Enabled = AddOut
        mnuEdit.Enabled = EditOut
        mnuBrowse.Enabled = BrowseOut
        mnuDelete.Enabled = DeleteOut
        Action = Nothing
        If mnuNew.Enabled = True Then mnuNew_Click(sender, e)

        PayType = "Outwards"
        Me.Text = "Payment " + PayType + " - " + IIf(PayType = "Inwards", "Receiveables", "Payables")
        AppHeader1.lblForm.Text = "Payments " + IIf(PayType = "Inwards", "Received FROM Clients", "Given TO Clients")

        LoadLvList()

        Label6.Text = "CREDIT CLIENT"

        On Error Resume Next
        cBank.SelectedIndex = 0
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Action = AppAction.Add
        lblAction.Text = "New Record"
        flush()
        FetchNextNo()
        cmdOk.Visible = True
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        cmdOk.Visible = True
        Action = AppAction.Edit
        lblAction.Text = "Edit Record"
        Dim strOrder As String = InputBox("Enter Ref No", "Payment", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            PaymentTag = Val(strOrder)
            LoadEditablePayment(PaymentTag)
            Exit Sub
        End If
        With FrmList
            .Text = "Edit Payment " + PayType
            .frmParent = Me
            .tSelection = "Edit Payment " + PayType
            .listQuery = "Edit Payment " + PayType
            '  .Text = "List of Payments"
            .ShowDialog()
        End With
        LoadEditablePayment(ReturnRefNo)
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)

    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        On Error GoTo errhdl
        cmdOk.Visible = False
        Action = AppAction.Browse
        lblAction.Text = "Browse Record"
        Dim strOrder As String = InputBox("Enter Ref No", "Payment", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            PaymentTag = Val(strOrder)
            LoadEditablePayment(PaymentTag)
            Exit Sub
        End If
        With FrmList
            .Text = "Browse Payment " + PayType
            .frmParent = Me
            .tSelection = "Browse Payment " + PayType
            .listQuery = "Browse Payment " + PayType
            ' .Text = "List of Payments"
            .ShowDialog()
        End With
        LoadEditablePayment(ReturnRefNo)
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)

    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        On Error GoTo errhdl
        cmdOk.Visible = True

        Action = AppAction.Delete
        lblAction.Text = "Delete Record"
        Dim strOrder As String = InputBox("Enter Ref No", "Payment", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            PaymentTag = Val(strOrder)
            LoadEditablePayment(PaymentTag)
            Exit Sub
        End If
        With FrmList
            .Text = "Delete Payment " + PayType
            .frmParent = Me
            .tSelection = "Delete Payment " + PayType
            .listQuery = "Delete Payment " + PayType
            '  .Text = "List of Payments"
            .ShowDialog()
        End With
        LoadEditablePayment(ReturnRefNo)
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub LoadEditablePayment(ByVal TheRefNo As Long)

        If TheRefNo = 0 Or TheRefNo = -1 Then Exit Sub
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        flush()

        cmSQL.CommandText = "FetchPayments"
        cmSQL.Parameters.AddWithValue("@PaymentTag", TheRefNo)
        cmSQL.Parameters.AddWithValue("@PayType", IIf(PayType = "Inwards", "Receiveable", "Payable"))

        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                dtpDate.Text = drSQL.Item("Date")
                tPaid.Text = Math.Round(drSQL.Item("AmtPaid"), 2)
                tPurpose.Text = drSQL.Item("Purpose")
                tRefNo.Text = drSQL.Item("PaymentTag")
                cPayMode.Text = drSQL.Item("PayMode")
                cBank.Text = drSQL.Item("BankCode") + " - " + drSQL.Item("Bank")
                tCheqNo.Text = drSQL.Item("ChequeNo")
                tCustomerCode.Text = drSQL.Item("ClientCode")
                tCustomerName.Text = drSQL.Item("ClientName")
            End If
        Else
            MsgBox("Payment Ref. No do not exist", MsgBoxStyle.Information, strApptitle)
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()


        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged
        If Action = Nothing Then Exit Sub
        On Error Resume Next
        tCustomerCode.Text = lvList.SelectedItems(0).Text
        tCustomerName.Text = lvList.SelectedItems(0).SubItems(1).Text
        tPaid.Text = lvList.SelectedItems(0).SubItems(2).Text
    End Sub
    Private Sub cmdNewBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewBank.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        Dim ChildForm As New FrmChartAdhoc
        ChildForm.TheSource = "BANK"
        ChildForm.Text = "LIST OF BANKS"
        ChildForm.ShowDialog()
        oLoadBank()
    End Sub
End Class
