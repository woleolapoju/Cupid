Imports System.Data.SqlClient
Public Class FrmChartAdhoc
    Public TheSource As String
    Private Sub FrmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackColor = MainTheme
        PanCommands.BackColor = HeaderTheme
        lvList.BackColor = MainTheme
      

        CmdInsert.Enabled = ModuleAdd
        CmdOpen.Enabled = ModuleEdit
        CmdCut.Enabled = ModuleDelete
        oLoad()
        If TheSource = "ALL" Then
            Panel3.Visible = True
            Panel1.Height = 76
            Me.Width = 415
            Me.Height = Me.Height + 50
            cboAccType.SelectedIndex = 0
        Else
            Panel1.Height = 50
            Panel3.Visible = False
            lvList.Columns(3).Width = 0
            Me.Width = 334
        End If

    End Sub
    Private Sub oLoad()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        Dim i


        'cnSQL.Open()
        lvList.Items.Clear()
        If TheSource = "ALL" Then
            cmSQL.CommandText = "SELECT * FROM AccountChart WHERE Category<>'RESERVED' ORDER BY Category"
            'lvList.Columns(3).Width = 60
        Else
            cmSQL.CommandText = "SELECT * FROM AccountChart WHERE Category='" & TheSource & "'"

        End If

        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim j As Long = 0
        Dim initialText As String
        Do While drSQL.Read
            j += 1
            initialText = j

            Dim LvItems As New ListViewItem(initialText)

            LvItems.SubItems.Add(ChkNull(drSQL.Item("Code")))
            LvItems.SubItems.Add(ChkNull(drSQL.Item("Description")))
            LvItems.SubItems.Add(ChkNull(drSQL.Item("Category")))

            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        lblCount.Text = j

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        On Error GoTo handler
        ' Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        tCode.Text = lvList.SelectedItems(0).SubItems(1).Text
        If MsgBox("The selected record would be deleted completely" + Chr(13) + "Continue (y/n)", MsgBoxStyle.YesNo, "DELETE RECORD") = MsgBoxResult.Yes Then
            cnSQL.Open()
            cmSQL.CommandText = "DeleteAccountsChart"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@Code", tCode.Text)
            cmSQL.ExecuteNonQuery()
            cmSQL.Dispose()
            ' cnSQL.Close()
            oLoad()
        End If
        flush()
        Exit Sub
handler:
        If Err.Number = 5 Then
            MsgBox("Pls. selected an entry to Delete", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If

    End Sub
    Sub flush()
        tCode.Tag = ""
        tCode.Text = ""
        tDesc.Text = ""
    End Sub
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOpen.Click
        On Error GoTo handler
        tCode.Tag = lvList.SelectedItems(0).SubItems(1).Text
        tCode.Text = lvList.SelectedItems(0).SubItems(1).Text
        tDesc.Text = lvList.SelectedItems(0).SubItems(2).Text
        cboAccType.Text = lvList.SelectedItems(0).SubItems(3).Text

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub CmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdInsert.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        If Trim(tCode.Text) = "" Then
            MsgBox("Incomplete data", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction
        If Trim(tCode.Tag) = "" Then

            cmSQL.CommandText = "InsertAccountsChart"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@Code", ChkNull(tCode.Text))
            cmSQL.Parameters.AddWithValue("@Description", ChkNull(tDesc.Text))
            If TheSource = "ALL" Then
                cmSQL.Parameters.AddWithValue("@Category", cboAccType.Text)
                cmSQL.Parameters.AddWithValue("@AcctCtrl", cboAccType.Text)
            Else
                cmSQL.Parameters.AddWithValue("@Category", TheSource)
                cmSQL.Parameters.AddWithValue("@AcctCtrl", TheSource)
            End If
           

            cmSQL.ExecuteNonQuery()

        Else

            myTrans = cnSQL.BeginTransaction()
            cmSQL.Transaction = myTrans
            cmSQL.CommandText = "DELETE AccountChart WHERE CODE='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.Parameters.Clear()

            cmSQL.CommandText = "InsertAccountsChart"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@Code", ChkNull(tCode.Text))
            cmSQL.Parameters.AddWithValue("@Description", ChkNull(tDesc.Text))
            If TheSource = "ALL" Then
                cmSQL.Parameters.AddWithValue("@Category", cboAccType.Text)
                cmSQL.Parameters.AddWithValue("@AcctCtrl", cboAccType.Text)
            Else
                cmSQL.Parameters.AddWithValue("@Category", TheSource)
                cmSQL.Parameters.AddWithValue("@AcctCtrl", TheSource)
            End If

            cmSQL.ExecuteNonQuery()


            cmSQL.CommandText = "UPDATE EXPENDITURE SET ExpenseCode='" & tCode.Text & "',ExpenseDesc='" & tDesc.Text & "' WHERE ExpenseCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "UPDATE EXPENDITURE SET BankCode='" & tCode.Text & "',BankDesc='" & tDesc.Text & "' WHERE BankCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "UPDATE INCOME SET IncomeCode='" & tCode.Text & "',IncomeDesc='" & tDesc.Text & "' WHERE IncomeCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "UPDATE INCOME SET BankCode='" & tCode.Text & "',BankDesc='" & tDesc.Text & "' WHERE BankCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "UPDATE JOURNAL SET DrCode='" & tCode.Text & "',DrDesc='" & tDesc.Text & "' WHERE DrCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "UPDATE JOURNAL SET CrCode='" & tCode.Text & "',CrDesc='" & tDesc.Text & "' WHERE CrCode ='" & tCode.Tag & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()


            myTrans.Commit()

        End If
        cmSQL.Dispose()
        'cnSQL.Close()

        oLoad()
        flush()

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            MsgBox("Pls. selected an entry to Edit", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If

    End Sub
    Private Sub lvList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvList.ColumnClick
        On Error GoTo handler
        lvList.ListViewItemSorter = New ListViewItemComparer(e.Column)

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
End Class