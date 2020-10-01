Imports System.Data.SqlClient
Public Class FrmJournal
    Dim Action As AppAction
    Public ReturnRefNo As Integer
    Private Sub FrmJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Journal"
        Me.BackColor = MainTheme
        tRefNo.BackColor = MainTheme

        dtpDate.Value = Now
        mnuNew_Click(sender, e)
        chkBankTransfer.Checked = True
        oLoadDr()
        oLoadCr()
    End Sub

    Sub flush()
        dtpDate.Value = Now
        tRefNo.Text = ""
        tAmount.Text = ""
        tPurposeNo.Text = ""
        tTitle.Text = ""
        chkBankTransfer.Checked = False
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If Action <> AppAction.Delete Then
            If Trim(tPurposeNo.Text) = "" Then
                MsgBox("Income details required", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(tTitle.Text) = "" Then
                MsgBox("Pls entered, Received by", MsgBoxStyle.Information, strApptitle)
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
            If Trim(cboDr.Text) = "" Then
                MsgBox("Pls entered, Account to Debit", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Trim(cboCr.Text) = "" Then
                MsgBox("Pls entered, Account to Credit", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Val(tAmount.Text) <= 0 Then
                MsgBox("Amount paid must be greater than zero (0)", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If

        End If
        cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        If Action = AppAction.Delete Then
            If MsgBox("The Selected Journal transaction would be deleted" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = MsgBoxResult.No Then Exit Sub
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteJournal"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.ExecuteNonQuery()
        ElseIf Action = AppAction.Add Then
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "Insertjournal"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", 0)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@Amount", CDbl(tAmount.Text))
            cmSQL.Parameters.AddWithValue("@Particulars", tPurposeNo.Text)
            cmSQL.Parameters.AddWithValue("@Title", tTitle.Text)
            cmSQL.Parameters.AddWithValue("@DrCode", GetIt4Me(cboDr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@DrDesc", GetItLast4Me(cboDr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@CrCode", GetIt4Me(cboCr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@CrDesc", GetItLast4Me(cboCr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@BankTransfer", chkBankTransfer.Checked)
            cmSQL.ExecuteNonQuery()
        Else
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteJournal"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.ExecuteNonQuery()

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "Insertjournal"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@RefNo", tRefNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@Amount", CDbl(tAmount.Text))
            cmSQL.Parameters.AddWithValue("@Particulars", tPurposeNo.Text)
            cmSQL.Parameters.AddWithValue("@Title", tTitle.Text)
            cmSQL.Parameters.AddWithValue("@DrCode", GetIt4Me(cboDr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@DrDesc", GetItLast4Me(cboDr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@CrCode", GetIt4Me(cboCr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@CrDesc", GetItLast4Me(cboCr.Text, " - "))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@BankTransfer", chkBankTransfer.Checked)
            cmSQL.ExecuteNonQuery()

        End If

        myTrans.Commit()

        cmSQL.Connection.Close()
        cmSQL.Dispose()
        cnSQL.Close()
        cnSQL.Dispose()

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
        Dim strValue As String = InputBox("Enter RefNo", "Journal", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            Loadjournal(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "Date"
        strCaption(2) = "Amount"
        strCaption(3) = "Title"
        strCaption(4) = "Debit Account"
        strCaption(5) = "Credit Account"
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
            .tSelection = "FetchEditeableJournal"
            .listQuery = "FetchEditeableJournal"
            .Text = "List of Journal Transaction"
            .ShowDialog()
        End With
        Loadjournal(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub Loadjournal(ByVal TheRefNo As Long)

        On Error GoTo errhdl
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If ReturnRefNo = 0 Then
            flush()
            Action = AppAction.Add
            Exit Sub
        End If

        flush()

        cmSQL.CommandText = "SELECT * FROM journal WHERE RefNo=" & TheRefNo
        cmSQL.CommandType = CommandType.Text
        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                tRefNo.Text = drSQL.Item("RefNo")
                dtpDate.Text = drSQL.Item("Date")
                tAmount.Text = Format(Math.Round(drSQL.Item("Amount"), 2), "standard")
                tPurposeNo.Text = drSQL.Item("Particulars")
                tTitle.Text = drSQL.Item("Title")
              
                chkBankTransfer.Checked = drSQL.Item("BankTransfer")

                cboCr.Text = drSQL.Item("CrCode") + " - " + drSQL.Item("CrDesc")
                cboDr.Text = drSQL.Item("DrCode") + " - " + drSQL.Item("DrDesc")
            End If
        Else
            MsgBox("Journal Ref.No do not exist", MsgBoxStyle.Information, strApptitle)
            flush()
            Action = AppAction.Add
        End If
        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        ReturnRefNo = 0
        cmdOk.Enabled = True
        Action = AppAction.Edit
        lblAction.Text = "Edit Record"
        Dim strValue As String = InputBox("Enter RefNo", "Journal", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            Loadjournal(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "Date"
        strCaption(2) = "Amount"
        strCaption(3) = "Title"
        strCaption(4) = "Debit Account"
        strCaption(5) = "Credit Account"
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
            .tSelection = "FetchEditeableJournal"
            .listQuery = "FetchEditeableJournal"
            .Text = "List of Journal Transaction"
            .ShowDialog()
        End With
        Loadjournal(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        On Error GoTo errhdl
        Action = AppAction.Add
        lblAction.Text = "New Record"
        flush()
        cmdOk.Enabled = True
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub oLoadCr()
        On Error GoTo handler
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cboCr.Items.Clear()
        If chkBankTransfer.Checked = True Then
            cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart WHERE Category='BANK' ORDER BY Description"
        Else
            cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart ORDER BY Description"
        End If
        cmSQL.CommandType = CommandType.Text

        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then Exit Sub
        Do While drSQL.Read
            cboCr.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
        Loop
        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()
        On Error Resume Next
        cboCr.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub oLoadDr()
        On Error GoTo handler
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cboDr.Items.Clear()
        If chkBankTransfer.Checked = True Then
            cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart WHERE Category='BANK' ORDER BY Description"
        Else
            cmSQL.CommandText = "SELECT Code , [Description] FROM AccountChart ORDER BY Description"
        End If

        cmSQL.CommandType = CommandType.Text

        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then Exit Sub
        Do While drSQL.Read
            cboDr.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
        Loop
        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()
        On Error Resume Next
        cboDr.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub chkBankTransfer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBankTransfer.CheckedChanged
        oLoadDr()
        oLoadCr()
        If chkBankTransfer.Checked Then
            tTitle.Text = "Bank Transfer"
        Else
            tTitle.Text = ""
        End If
    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        On Error GoTo errhdl
        cmdOk.Enabled = False
        ReturnRefNo = 0
        Action = AppAction.Browse
        lblAction.Text = "Browse Record"
        Dim strValue As String = InputBox("Enter RefNo", "Journal", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            ReturnRefNo = Val(strValue)
            Loadjournal(ReturnRefNo)
            Exit Sub
        End If
        Dim strCaption(7) As String
        Dim intWidth(7) As Integer
        strCaption(0) = "RefNo"
        strCaption(1) = "Date"
        strCaption(2) = "Amount"
        strCaption(3) = "Title"
        strCaption(4) = "Debit Account"
        strCaption(5) = "Credit Account"
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
            .tSelection = "FetchAllJournal"
            .listQuery = "FetchAllJournal"
            .Text = "List of Journal Transaction"
            .ShowDialog()
        End With
        Loadjournal(ReturnRefNo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub FrmJournal_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub cmdDRAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDRAccount.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        If chkBankTransfer.Checked = True Then
            Dim ChildForm As New FrmChartAdhoc
            ChildForm.TheSource = "BANK"
            ChildForm.Text = "LIST OF BANKS"
            ChildForm.ShowDialog()
        Else
            Dim ChildForm As New FrmChartAdhoc
            ChildForm.TheSource = "ALL"
            ChildForm.Text = "CHART OF ACCOUNTS"
            ChildForm.ShowDialog()
        End If

        oLoadDr()
    End Sub

    Private Sub cmdCRAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCRAccount.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        If chkBankTransfer.Checked = True Then
            Dim ChildForm As New FrmChartAdhoc
            ChildForm.TheSource = "BANK"
            ChildForm.Text = "LIST OF BANKS"
            ChildForm.ShowDialog()
        Else
            Dim ChildForm As New FrmChartAdhoc
            ChildForm.TheSource = "ALL"
            ChildForm.Text = "CHART OF ACCOUNTS"
            ChildForm.ShowDialog()
        End If

        oLoadCr()
    End Sub
End Class