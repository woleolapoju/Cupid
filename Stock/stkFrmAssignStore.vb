Imports System.Data.SqlClient
Public Class stkFrmAssignStore
    Public ReturnUserID As String
    Private Sub stkFrmAssignStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        lvList.BackColor = MainTheme

        Panel1.BackColor = HeaderTheme

        AppHeader1.lblForm.Text = "Store User Assignment"

        LoadlvList()
        LoadUsers()
    End Sub
    Private Sub LoadlvList()
        On Error GoTo errHdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandType = CommandType.Text
        cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            lvList.Items.Add(drSQL.Item("store"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
errHdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub LoadlvListSelected(ByVal TheUserID As String)
        On Error GoTo errHdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandType = CommandType.Text
        cmSQL.CommandText = "SELECT * FROM AssignedStore WHERE UserID='" & TheUserID & "'"
        'cnSQL.Open()
        Dim j As Integer = 0
        DGrid.Rows.Clear()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
               DGrid.Rows.Add()
            j = DGrid.RowCount - 1
            DGrid.Rows(j).Cells(0).Value = drSQL.Item("Store")
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
errHdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub LoadUsers()
        On Error GoTo errHdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandType = CommandType.Text
        cmSQL.CommandText = "SELECT DISTINCT UserID, UserName  FROM UserAccess ORDER BY UserName"
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cboUser.Items.Add(drSQL.Item("UserID") + " - " + drSQL.Item("UserName"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
errHdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub cmdMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMove.Click
        On Error Resume Next
        Dim i As Integer
        If Trim(cboUser.Text) = "" Then
            MsgBox("Pls. select a User", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        Dim j As Integer = 0
        If ChkExisting(lvList.SelectedItems(0).Text) > 0 Then
            MsgBox("Store already in list", MsgBoxStyle.Information, strApptitle)
        Else
            DGrid.Rows.Add()
            j = DGrid.RowCount - 1
            DGrid.Rows(j).Cells(0).Value = lvList.SelectedItems(0).Text
        End If

    End Sub
    Private Function ChkExisting(ByVal Store As String) As Integer
        On Error GoTo errhdl
        ChkExisting = -1
        For i = 0 To DGrid.RowCount - 1
            If DGrid.Item(0, i).Value = Store Then
                ChkExisting = i
                Exit Function
            End If
        Next
        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        On Error Resume Next
        DGrid.Rows.RemoveAt(Val(DGrid.Tag))
    End Sub
    Private Sub cboUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUser.SelectedIndexChanged
        LoadlvListSelected(GetIt4Me(cboUser.SelectedItem, " - "))
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
       
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim jk As Integer = 1
FetchNoAgain:
        If Trim(cboUser.Text) = "" Then
            MsgBox("User ID is required", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        myTrans = cnSQL.BeginTransaction()
        cmSQL.Transaction = myTrans

        cmSQL.CommandText = "DeleteAssignedStore"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@UserID", GetIt4Me(cboUser.Text, " - "))
        cmSQL.ExecuteNonQuery()

        Dim i As Integer
        'For i = 0 To lvListSelected.Items.Count - 1
        '    cmSQL.Parameters.Clear()
        '    cmSQL.CommandText = "ST_InsertAssignedStore"
        '    cmSQL.CommandType = CommandType.StoredProcedure
        '    cmSQL.Parameters.AddWithValue("@UserID", GetIt4Me(cboUser.Text, " - "))
        '    cmSQL.Parameters.AddWithValue("@Store", lvListSelected.Items(i).Text)
        '    cmSQL.ExecuteNonQuery()
        'Next i

        For i = 0 To DGrid.RowCount - 1
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertAssignedStore"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@UserID", GetIt4Me(cboUser.Text, " - "))
            cmSQL.Parameters.AddWithValue("@Store", DGrid.Item(0, i).Value)
            cmSQL.ExecuteNonQuery()
        Next i


        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        ' DGrid.Rows.Clear()

        MsgBox("Successfull", vbInformation, strApptitle)
        'lvListSelected.Items.Clear()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        cmdMove_Click(sender, e)
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
   Private Sub DGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGrid.CellBeginEdit
        If e.ColumnIndex = 0 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        DGrid.Tag = e.RowIndex
    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        DGrid.Rows.RemoveAt(Val(DGrid.Tag))
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class