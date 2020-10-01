Imports System.Data.SqlClient
Public Class FrmSysPeriod
    Dim Action As AppAction

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        lblAction.Text = "Delete Record"
        Action = AppAction.Delete
        Me.Height = 381
        Me.StartPosition = FormStartPosition.CenterParent
        tPName.Enabled = False
        Flush()
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        lblAction.Text = "Edit Record"
        Action = AppAction.Edit
        Me.Height = 381
        Me.StartPosition = FormStartPosition.CenterParent
        tPName.Enabled = True
        Flush()
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        lblAction.Text = "New Record"
        Action = AppAction.Add
        tPName.Enabled = True
        Flush()
    End Sub
    Private Function IsValidForm() As Boolean
        On Error GoTo handler
        IsValidForm = True
        If dtpEnd.Value < dtpStart.Value Then
            MsgBox("Start Date must not be greater than End Date.")
            Return False
        End If
        If tPName.Text = "" Then
            MsgBox("Period Name is required.", vbInformation, strApptitle)
            Return False
        End If

        If Action = AppAction.Add And dtpStart.Value.ToShortDateString >= sysStartDate And dtpStart.Value.ToShortDateString <= sysEndDate Then
            MsgBox("Start Date falls within current/open period", MsgBoxStyle.Information, strApptitle)
            Return False
        ElseIf Action = AppAction.Add And dtpEnd.Value.ToShortDateString >= sysStartDate And dtpEnd.Value.ToShortDateString <= sysEndDate Then
            MsgBox("End Date falls within current/open period", MsgBoxStyle.Information, strApptitle)
            Return False
        End If
        If Action = AppAction.Add And dtpStart.Value.ToShortDateString <= sysStartDate Then
            MsgBox("Start Date must be greater than current period Start date", MsgBoxStyle.Information, strApptitle)
            Return False
        End If
        If Action = AppAction.Add And dtpEnd.Value.ToShortDateString <= sysEndDate Then
            MsgBox("End Date must be greater than current period End date", MsgBoxStyle.Information, strApptitle)
            Return False
        End If

        Exit Function
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        If Action <> AppAction.Delete Then
            If Not IsValidForm() Then
                Exit Sub
            End If
        End If

        'cnSQL.Open()
        Dim myTrans As SqlClient.SqlTransaction

        Select Case Action
            Case AppAction.Add
                If MsgBox("The current period would be closed" & Chr(13) & "You cannot undo this operation do you wish to continue.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, strApptitle) = MsgBoxResult.No Then
                    Exit Sub
                End If

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "CloseAllSystemPeriods"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.ExecuteNonQuery()


                cmSQL.CommandText = "UpdateSysParam4SysPeriod"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Period", tPName.Text)
                cmSQL.Parameters.AddWithValue("@StartDate", formatDate(dtpStart))
                cmSQL.Parameters.AddWithValue("@EndDate", formatDate(dtpEnd))
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertSystemPeriods"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@PeriodName", tPName.Text)
                cmSQL.Parameters.AddWithValue("@StartDate", formatDate(dtpStart))
                cmSQL.Parameters.AddWithValue("@EndDate", formatDate(dtpEnd))
                cmSQL.Parameters.AddWithValue("@Status", "Open")
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
                MsgBox("System Period Successfully Set" + Chr(13) + "Pls. restart the application", MsgBoxStyle.Information, strApptitle)
                End

            Case AppAction.Edit
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "DELETE FROM SystemPeriods WHERE Status='Open'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()


                cmSQL.CommandText = "UpdateSysParam4SysPeriod"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Period", tPName.Text)
                cmSQL.Parameters.AddWithValue("@StartDate", formatDate(dtpStart))
                cmSQL.Parameters.AddWithValue("@EndDate", formatDate(dtpEnd))
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertSystemPeriods"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@PeriodName", tPName.Text)
                cmSQL.Parameters.AddWithValue("@StartDate", formatDate(dtpStart))
                cmSQL.Parameters.AddWithValue("@EndDate", formatDate(dtpEnd))
                cmSQL.Parameters.AddWithValue("@Status", "Open")
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
                MsgBox("System Period Successfully Updated" + Chr(13) + "Pls. restart the application", MsgBoxStyle.Information, strApptitle)
                End
            Case AppAction.Delete
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "DELETE FROM SystemPeriods WHERE PeriodName='" & tPName.Text & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                myTrans.Commit()
                MsgBox("Period Deleted Successfully", MsgBoxStyle.Information, strApptitle)
        End Select
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Flush()
        FilllvList()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()

    End Sub
    Private Sub FilllvList()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvList.Items.Clear()

        cmSQL.CommandText = "FetchAllSystemPeriods"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            Dim LvItems As New ListViewItem(drSQL.Item("PeriodName").ToString)
            If drSQL.Item("Status") = "Open" Then
                LvItems.Group = lvList.Groups.Item(0)
                sysStartDate = drSQL.Item("StartDate")
                sysEndDate = drSQL.Item("EndDate")
            Else
                LvItems.Group = lvList.Groups.Item(1)
            End If
            LvItems.SubItems.Add(drSQL.Item("StartDate"))
            LvItems.SubItems.Add(drSQL.Item("EndDate"))
            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Sub FrmSysPeriod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvList.LabelEdit = False
        Me.BackColor = MainTheme
        Panel2.BackColor = HeaderTheme
        Panel3.BackColor = MainTheme
        mnuNew.Enabled = ModuleAdd
        mnuEdit.Enabled = ModuleAdd
        mnuDelete.Enabled = ModuleAdd

        lvList.AllowColumnReorder = True
        dtpStart.Text = CDate("01-Jan-" + Trim(Str(Year(Now))))
        dtpEnd.Text = CDate("31-Dec-" + Trim(Str(Year(Now))))
        FilllvList()
        Me.Height = 162
        If mnuNew.Enabled Then mnuNew_Click(sender, e)
    End Sub
    Private Sub Flush()
        tPName.Text = ""

    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        Dim SLV As ListView.SelectedListViewItemCollection = lvList.SelectedItems
        Dim item As ListViewItem
        For Each item In SLV
            If Action = AppAction.Add Then Exit Sub
            If item.Group.ToString = "Close Period(s)" And Action = AppAction.Edit Then
                MsgBox("Only Current period can be Edited", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If Not (item.Group.ToString = "Close Period(s)") And Action = AppAction.Delete Then
                MsgBox("Only Closed period can be Deleted", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            tPName.Text = item.Text
            dtpStart.Value = item.SubItems(1).Text
            dtpEnd.Value = item.SubItems(2).Text
        Next
    End Sub

    Private Sub FrmSysPeriod_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub
End Class