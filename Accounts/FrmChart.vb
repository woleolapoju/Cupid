Imports System.Data.SqlClient
Public Class FrmChart
    Public ReturnCode As String
    Public ReturnMainCode As String
    Dim Action As AppAction
    Dim No_Generated As Boolean = False
    Dim IsFormValid As Boolean
    Private Sub ACFrmChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl

        AppHeader1.lblForm.Text = "Journal"
        Me.BackColor = MainTheme
        lvList.BackColor = MainTheme
        TVList.BackColor = MainTheme

        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        cboAccType.SelectedIndex = 0

        LoadAcctCtrl()

        LoadLvList()

        LoadTVList()

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub LoadAcctCtrl()
        On Error GoTo errhdl
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cboCtrlAcct.Items.Clear()
        cmSQL.CommandText = "SELECT DISTINCT AcctCtrl FROM AccountChart"
        cmSQL.CommandType = CommandType.Text

        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
       
        Do While drSQL.Read
            cboCtrlAcct.Items.Add(drSQL.Item("AcctCtrl"))
        Loop
        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub


    Private Sub lnkViewType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkViewType.LinkClicked
        If TLlvList.Visible = True Then
            TLlvList.Visible = False
            TvList.Visible = True
        Else
            TLlvList.Visible = True
            TvList.Visible = False
        End If
    End Sub
    Public Sub LoadLvList()
        On Error GoTo errhdl
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        Dim i
        lvList.Items.Clear()

        cmSQL.CommandText = "SELECT * FROM AccountChart"
        cmSQL.CommandType = CommandType.Text

        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim j As Long = 0
        Dim initialText As String
        Do While drSQL.Read
            j += 1
            If drSQL.Item(0).GetType.ToString = "System.DateTime" Then
                initialText = IIf(IsDBNull(drSQL.Item(0)), "", Format(drSQL.Item(0), "dd-MMM-yyyy"))
            Else
                initialText = drSQL.Item(0).ToString
            End If
            Dim LvItems As New ListViewItem(initialText)
            For i = 1 To lvList.Columns.Count - 1
                If drSQL.Item(i).GetType.ToString = "System.DateTime" Then
                    LvItems.SubItems.Add(IIf(IsDBNull(drSQL.Item(i)), "", Format(drSQL.Item(i), "dd-MMM-yyyy")))
                Else
                    LvItems.SubItems.Add(ChkNull(drSQL.Item(i)))
                End If

            Next
            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()

        lblCount.Text = j
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub lvList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvList.ColumnClick
        SelColumn.Value = e.Column + 1
        lvList.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub LoadTVList()
        On Error GoTo handler
        Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim cmSQL1 As SqlCommand = cnSQL.CreateCommand
        Dim drSQL1 As SqlDataReader

        TVList.Nodes.Clear()
        cmSQL.CommandText = "SELECT DISTINCT AcctCtrl FROM AccountChart"
        cmSQL.CommandType = CommandType.Text
        cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        TVList.BeginUpdate()
        TVList.Nodes.Add("NONE@", "Account Chart").BackColor = Color.LightBlue
        TVList.EndUpdate()
        Do While drSQL.Read
            TVList.BeginUpdate()
            TVList.Nodes.Add(drSQL.Item("AcctCtrl"), drSQL.Item("AcctCtrl").ToString)
            TVList.EndUpdate()
        Loop
        drSQL.Close()

        cmSQL.CommandText = "SELECT * FROM AccountChart"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            TVList.BeginUpdate()
            TVList.Nodes(UCase(drSQL.Item("AcctCtrl").ToString)).Nodes.Add(drSQL.Item("Code").ToString, drSQL.Item("Code").ToString + " - " + drSQL.Item("Description").ToString, 0)
            ' TVList.Nodes(UCase(drSQL.Item("Outline").ToString)).Nodes.Add(drSQL.Item("Key").ToString, drSQL.Item("Account").ToString, 0)
            TVList.EndUpdate()
        Loop

        cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        cnSQL.Close()
        cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        If Err.Number = 91 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If


    End Sub
    Private Function oLoad(ByVal strValue As String) As Boolean
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If strValue = "" Then Exit Function
        oLoad = False
        ReturnMainCode = strValue
        cmSQL.CommandText = "SELECT * FROM AccountChart WHERE Code='" & strValue & "'"
        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then GoTo skipIt
        If drSQL.Read Then
            tCode.Text = drSQL.Item("Code")
            tDesc.Text = drSQL.Item("Description")
            cboAccType.Text = drSQL.Item("Category")
            cboCtrlAcct.Text = drSQL.Item("AcctCtrl")
        End If
        oLoad = True
skipIt:
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
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        On Error GoTo errhdl
        Action = AppAction.Add
        InitialiseAction()
        tCode.Focus()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub InitialiseAction()
        Select Case Action
            Case AppAction.Add
                lblAction.Text = "New Record"
                cmdOk.Visible = True
            Case AppAction.Browse
                lblAction.Text = "Browse Record"
                cmdOk.Visible = False
            Case AppAction.Edit
                lblAction.Text = "Edit Record"
                cmdOk.Visible = True
            Case AppAction.Delete
                lblAction.Text = "Delete Record"
                cmdOk.Visible = True
        End Select
        Flush(Me)
    End Sub
    Private Sub Flush(ByVal tContainer As Control)
        On Error Resume Next
        Dim ctl As Control
        Dim txt As TextBox
        For Each ctl In tContainer.Controls
            If TypeOf ctl Is TextBox Then
                txt = ctl
                txt.Text = ""
            End If
            If ctl.HasChildren Then
                Flush(ctl)
            End If
        Next
        No_Generated = False

    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        Action = AppAction.Edit
        InitialiseAction()
        If lvList.Visible = True Then
            ReturnCode = lvList.SelectedItems(0).Text
        Else
            ReturnCode = Mid(TVList.SelectedNode.Text, 1, InStr(TVList.SelectedNode.Text, " - ") - 1)
        End If
        If ReturnCode = "0001" Or ReturnCode Like "R*" Then
            MsgBox("Sorry! This record cannot be Edited or Deleted", vbCritical, strApptitle)
            Exit Sub
        End If

        oLoad(ReturnCode)
        Exit Sub
        Resume
errhdl:
        If Err.Number = 5 Then
            MsgBox("Please select record to edit", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, vbCritical, strApptitle)
        End If
    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        On Error GoTo errhdl
        Action = AppAction.Browse
        InitialiseAction()

        If lvList.Visible = True Then
            ReturnCode = lvList.SelectedItems(0).Text
        Else
            ReturnCode = Mid(TVList.SelectedNode.Text, 1, InStr(TVList.SelectedNode.Text, " - ") - 1)
        End If
        oLoad(ReturnCode)

        Exit Sub
        Resume
errhdl:
        If Err.Number = 5 Then
            MsgBox("Please select record to Browse", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, vbCritical, strApptitle)
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        On Error GoTo errhdl
        Action = AppAction.Delete
        InitialiseAction()

        If lvList.Visible = True Then
            ReturnCode = lvList.SelectedItems(0).Text
        Else
            ReturnCode = Mid(TVList.SelectedNode.Text, 1, InStr(TVList.SelectedNode.Text, " - ") - 1)
        End If
        If ReturnCode = "0001" Or ReturnCode Like "R*" Then
            MsgBox("Sorry! This record cannot be Edited or Deleted", vbCritical, strApptitle)
            Exit Sub
        End If
        oLoad(ReturnCode)

        Exit Sub
        Resume
errhdl:
        If Err.Number = 5 Then
            MsgBox("Please select record to Delete", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, vbCritical, strApptitle)
        End If
    End Sub
    Public Function IsValidForm(ByVal tContainer As Control) As Boolean
        On Error GoTo handler
        On Error Resume Next
        IsValidForm = True
        If IsFormValid = False Then Exit Function
        Dim ctl As Control
        Dim txt As TextBox
        For Each ctl In tContainer.Controls
            'If TypeOf ctl Is TextBox Then
            txt = ctl
            Select Case txt.Name
                Case Is = "tCode", "tDesc", "cboAccType"
                    If txt.Text = "" Then
                        MsgBox(Mid(txt.Name, 2) + " is required", MsgBoxStyle.Information, strApptitle)
                        IsValidForm = False
                        IsFormValid = False
                        Exit For
                        Exit Function
                    End If
            End Select
            'End If

            ' Recursively call this function for any container controls.
            If ctl.HasChildren And IsFormValid = True Then
                IsValidForm(ctl)
            End If
        Next

        Exit Function
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        If Action = 0 Then
            MsgBox("Please selected a NEW,EDIT,BROWSE or DELETE Action")
            Exit Sub
        End If
        ' Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim jk As Integer = 1
FetchNoAgain:
        If Action <> AppAction.Delete Then
            If Not IsValidForm(Me) Or IsFormValid = False Then
                IsFormValid = True
                Exit Sub
            End If
        End If
        IsFormValid = True

        ' cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction
        Select Case Action
            Case AppAction.Add

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.Parameters.Clear()

                cmSQL.CommandText = "InsertAccountsChart"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Code", ChkNull(tCode.Text))
                cmSQL.Parameters.AddWithValue("@Description", ChkNull(tDesc.Text))
                cmSQL.Parameters.AddWithValue("@Category", ChkNull(cboAccType.Text))
                cmSQL.Parameters.AddWithValue("@AcctCtrl", cboCtrlAcct.Text)

                cmSQL.ExecuteNonQuery()

                myTrans.Commit()

            Case AppAction.Edit
                If ReturnMainCode = "" Then
                    MsgBox("Pls. select an Account Code to edit", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "DELETE AccountChart WHERE CODE='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()

                cmSQL.CommandText = "InsertAccountsChart"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Code", ChkNull(tCode.Text))
                cmSQL.Parameters.AddWithValue("@Description", ChkNull(tDesc.Text))
                cmSQL.Parameters.AddWithValue("@Category", ChkNull(cboAccType.Text))
                cmSQL.Parameters.AddWithValue("@AcctCtrl", cboCtrlAcct.Text)
                cmSQL.ExecuteNonQuery()


                cmSQL.CommandText = "UPDATE EXPENDITURE SET ExpenseCode='" & tCode.Text & "',ExpenseDesc='" & tDesc.Text & "' WHERE ExpenseCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE EXPENDITURE SET BankCode='" & tCode.Text & "',BankDesc='" & tDesc.Text & "' WHERE BankCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE INCOME SET IncomeCode='" & tCode.Text & "',IncomeDesc='" & tDesc.Text & "' WHERE IncomeCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE INCOME SET BankCode='" & tCode.Text & "',BankDesc='" & tDesc.Text & "' WHERE BankCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE JOURNAL SET DrCode='" & tCode.Text & "',DrDesc='" & tDesc.Text & "' WHERE DrCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE JOURNAL SET CrCode='" & tCode.Text & "',CrDesc='" & tDesc.Text & "' WHERE CrCode ='" & ReturnMainCode & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()

            Case AppAction.Delete
                If ReturnMainCode = "" Then
                    MsgBox("Pls. select an Account Code to Delete", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "DeleteAccountsChart"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Code", ReturnMainCode)
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
        End Select
        No_Generated = False

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Flush(Me)
        ReturnCode = ""
        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        Exit Sub
        Resume
handler:

        If Err.Description Like "Violation of PRIMARY KEY constraint*" And No_Generated = True Then
            jk = jk + 1
            myTrans.Rollback()
            'cnSQL.Close()
            GoTo FetchNoAgain
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
            myTrans.Rollback()
        End If

    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        LoadTVList()
        LoadLvList()
    End Sub

    Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click
        lvList.Sorting = IIf(RadAscend.Checked = True, SortOrder.Ascending, SortOrder.Descending)
    End Sub
    Private Sub filterList()
        On Error GoTo errhdl
        Dim i As Integer
        Dim j As Integer = SelColumn.Value
        Dim price As Double = 0.0
        i = lvList.Items.Count - 1
        Do While i >= 0
            If j = 1 Then
                If Not LCase(lvList.Items(i).Text) Like LCase(tFilter.Text) Then
                    lvList.Items(i).Remove()
                End If
            Else
                If Not LCase(lvList.Items(i).SubItems(j - 1).Text) Like LCase(tFilter.Text) Then
                    lvList.Items(i).Remove()
                End If
            End If
            i = i - 1
        Loop
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        filterList()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        On Error GoTo errhdl
        LoadLvList()
        tFilter.Text = ""
        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub FrmChart_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub
End Class