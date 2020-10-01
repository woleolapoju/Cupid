Imports System.Data.SqlClient
Public Class FrmExpenses
    Dim Action As AppAction
    Public ReturnRefNo As Integer
    Private Sub FrmExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Expenses"
        Me.BackColor = MainTheme
        tRefNo.BackColor = MainTheme

        dtpDate.Value = Now
        mnuNew_Click(sender, e)
        oLoadExpenseType()
        oLoadBank()

       
    End Sub

    Sub flush()
        dtpDate.Value = Now
        tRefNo.Text = ""
        tAmount.Text = ""
        tPurposeNo.Text = ""
        tExpendedBy.Text = ""
        tVoucherNo.Text = ""
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If Action <> AppAction.Delete Then
            If Trim(tPurposeNo.Text) = "" Then
                MsgBox("Expenditure Purpose required", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(tExpendedBy.Text) = "" Then
                MsgBox("Pls entered, Expenditure by", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            'If IsNumeric(tVoucherNo.Text) = False And Trim(tVoucherNo.Text) <> "" Then
            '    MsgBox("VoucherNo must be numeric", MsgBoxStyle.Information, strApptitle)
            '    Exit Sub
            'End If
            'If Trim(tVoucherNo.Text) = "" Then
            '    MsgBox("Pls enter VoucherNo", MsgBoxStyle.Information, strApptitle)
            '    Exit Sub
            'End If
            If Trim(cboBank.Text) = "" Then
                MsgBox("Pls entered, Bank", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(cExpenseType.Text) = "" Then
                MsgBox("Pls entered, Expense Type", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Val(tAmount.Text) <= 0 Then
                MsgBox("Amount paid must be greater than zero (0)", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If

        End If
        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        If Action = AppAction.Delete Then
            If MsgBox("The Selected Expense transaction would be deleted" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = MsgBoxResult.No Then Exit Sub
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteExpenditure"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.ExecuteNonQuery()
        ElseIf Action = AppAction.Add Then
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertExpenditure"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", 0)
            cmSQL.Parameters.AddWithValue("@VoucherNo", tVoucherNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@Amount", CDbl(tAmount.Text))
            cmSQL.Parameters.AddWithValue("@Purpose", tPurposeNo.Text)
            cmSQL.Parameters.AddWithValue("@ExpendedBy", tExpendedBy.Text)
            cmSQL.Parameters.AddWithValue("@BankCode", GetIt4Me(cboBank.Text, " - "))
            cmSQL.Parameters.AddWithValue("@BankDesc", GetItLast4Me(cboBank.Text, " - "))
            cmSQL.Parameters.AddWithValue("@ExpenseCode", GetIt4Me(cExpenseType.Text, " - "))
            cmSQL.Parameters.AddWithValue("@ExpenseDesc", GetItLast4Me(cExpenseType.Text, " - "))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ChequeNo", tPurposeNo.Text)
            cmSQL.ExecuteNonQuery()
        Else
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteExpenditure"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.ExecuteNonQuery()

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertExpenditure"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.Parameters.AddWithValue("@VoucherNo", tVoucherNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@Amount", CDbl(tAmount.Text))
            cmSQL.Parameters.AddWithValue("@Purpose", tPurposeNo.Text)
            cmSQL.Parameters.AddWithValue("@ExpendedBy", tExpendedBy.Text)
            cmSQL.Parameters.AddWithValue("@BankCode", GetIt4Me(cboBank.Text, " - "))
            cmSQL.Parameters.AddWithValue("@BankDesc", GetItLast4Me(cboBank.Text, " - "))
            cmSQL.Parameters.AddWithValue("@ExpenseCode", GetIt4Me(cExpenseType.Text, " - "))
            cmSQL.Parameters.AddWithValue("@ExpenseDesc", GetItLast4Me(cExpenseType.Text, " - "))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ChequeNo", tChequeNo.Text)

            cmSQL.ExecuteNonQuery()

        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        mnuNew_Click(sender, e)
        'flush()

        'Action = AppAction.Add

        Exit Sub
        Resume
handler:

        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        flush()

        Action = AppAction.Add
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        On Error GoTo errhdl
        cmdOk.Enabled = True
        Action = AppAction.Delete
        ReturnRefNo = 0
        lblAction.Text = "Delete Record"
        Dim strValue As String = InputBox("Enter RefNo", "Expenditure", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            LoadExpenditure(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "VoucherNo"
        strCaption(2) = "Date"
        strCaption(3) = "Amount"
        strCaption(4) = "ExpenseType"
        strCaption(5) = "Bank"
        strCaption(6) = "Details"
        intWidth(0) = 60
        intWidth(1) = 70
        intWidth(2) = 80
        intWidth(3) = 100
        intWidth(4) = 80
        intWidth(5) = 80
        intWidth(6) = 120
        With FrmList
            .frmParent = Me
            .tSelection = "FetchEditeableExpenditure"
            .listQuery = "FetchEditeableExpenditure"
            .Text = "List of Expenditure Transaction"
            .ShowDialog()
        End With
        LoadExpenditure(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub LoadExpenditure(ByVal TheRefNo As Long)

        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If ReturnRefNo = 0 Then
            flush()
            Action = AppAction.Add
            Exit Sub
        End If

        flush()

        cmSQL.CommandText = "SELECT * FROM Expenditure WHERE RefNo=" & TheRefNo
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                tRefNo.Text = drSQL.Item("RefNo")
                dtpDate.Text = drSQL.Item("Date")

                tAmount.Text = Format(Math.Round(drSQL.Item("Amount"), 2), "standard")
                tPurposeNo.Text = drSQL.Item("Purpose")
                tExpendedBy.Text = drSQL.Item("ExpendedBy")
                cExpenseType.Text = drSQL.Item("ExpenseCode") + " - " + drSQL.Item("ExpenseDesc")
                cboBank.Text = drSQL.Item("BankCode") + " - " + drSQL.Item("BankDesc")
                tVoucherNo.Text = drSQL.Item("VoucherNo")
                tChequeNo.Text = ChkNull(drSQL.Item("ChequeNo"))

            End If
        Else
            MsgBox("Expenditure Ref.No do not exist", MsgBoxStyle.Information, strApptitle)
            flush()
            Action = AppAction.Add
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

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        cmdOk.Enabled = True
        ReturnRefNo = 0
        Action = AppAction.Edit
        lblAction.Text = "Edit Record"
        Dim strValue As String = InputBox("Enter RefNo", "Expenditure", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            LoadExpenditure(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "VoucherNo"
        strCaption(2) = "Date"
        strCaption(3) = "Amount"
        strCaption(4) = "ExpenseType"
        strCaption(5) = "Bank"
        strCaption(6) = "Details"
        intWidth(0) = 60
        intWidth(1) = 70
        intWidth(2) = 80
        intWidth(3) = 100
        intWidth(4) = 80
        intWidth(5) = 80
        intWidth(6) = 120
        With FrmList
            .frmParent = Me
            .tSelection = "FetchEditeableExpenditure"
            .listQuery = "FetchEditeableExpenditure"
            .Text = "List of Expenditure Transaction"
            .ShowDialog()
        End With
        LoadExpenditure(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)


    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        On Error GoTo errhdl
        cmdOk.Enabled = True
        Action = AppAction.Add
        lblAction.Text = "New Record"
        flush()

        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub oLoadExpenseType()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cExpenseType.Items.Clear()
        cmSQL.CommandText = "SELECT Code , [Description]   FROM AccountChart WHERE Category='EXPENSE' ORDER BY Description"
        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            drSQL.Close()
            Exit Sub
        End If

        Do While drSQL.Read
            cExpenseType.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        On Error Resume Next
        cExpenseType.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub oLoadBank()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cboBank.Items.Clear()
        cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart WHERE Category='BANK' ORDER BY Description"
        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            drSQL.Close()
            Exit Sub
        End If

        Do While drSQL.Read
            cboBank.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        On Error Resume Next
        cboBank.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        On Error GoTo errhdl
        cmdOk.Enabled = False
        ReturnRefNo = 0
        Action = AppAction.Browse
        lblAction.Text = "Browse Record"
        Dim strValue As String = InputBox("Enter RefNo", "Expenditure", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            LoadExpenditure(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "VoucherNo"
        strCaption(2) = "Date"
        strCaption(3) = "Amount"
        strCaption(4) = "ExpenseType"
        strCaption(5) = "Bank"
        strCaption(6) = "Details"
        intWidth(0) = 60
        intWidth(1) = 70
        intWidth(2) = 80
        intWidth(3) = 100
        intWidth(4) = 80
        intWidth(5) = 80
        intWidth(6) = 120
        With FrmList
            .frmParent = Me
            .tSelection = "FetchAllExpenditure"
            .listQuery = "FetchAllExpenditure"
            .Text = "List of Expenditure Transaction"
            .ShowDialog()
        End With
        LoadExpenditure(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub FrmExpenses_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub cmdNewBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewBank.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        Dim ChildForm As New FrmChartAdhoc
        ChildForm.TheSource = "BANK"
        ChildForm.Text = "LIST OF BANKS"
        ChildForm.ShowDialog()
        oLoadBank()
    End Sub

    Private Sub cmdNewExpenseType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewExpenseType.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        Dim ChildForm As New FrmChartAdhoc
        ChildForm.TheSource = "EXPENSE"
        ChildForm.Text = "LIST OF EXPENSES ACCOUNTS"
        ChildForm.ShowDialog()
        oLoadExpenseType()
    End Sub
End Class