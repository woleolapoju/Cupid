Imports System.Data.SqlClient
Public Class FrmSysUser
    Public ReturnUserID As String
    Dim Action As AppAction

    Private Sub FrmSysUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo handler
        AppHeader1.lblForm.Text = "System Users"

        Me.BackColor = MainTheme
        ModuleDGV.BackgroundColor = MainTheme
        ReportDGV.BackgroundColor = MainTheme
        lnkReset.BackColor = MainTheme
        lnkSuspend.BackColor = MainTheme
        lnkReset.BackColor = MainTheme
        ModuleDGV.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        ReportDGV.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        Panel2.BackColor = HeaderTheme


        LoadModules()
        LoadReports()

        mnuNew.Enabled = ModuleAdd
        mnuEdit.Enabled = ModuleEdit
        mnuBrowse.Enabled = ModuleBrowse
        mnuDelete.Enabled = ModuleDelete
        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        Exit Sub
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Action = AppAction.Delete
        InitialiseAction()
        On Error GoTo errhdl
        Dim strValue As String
        Dim strPrompt As String
        Dim strCaption(4) As String
        Dim intWidth(4) As Integer
        strCaption(0) = "User ID"
        strCaption(1) = "Username"
        strCaption(2) = "Password"
        strCaption(3) = "Suspend"
        intWidth(0) = 120
        intWidth(1) = 450
        intWidth(2) = 0
        intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "SystemUser"
            .listQuery = "SystemUser"
            .Text = "List of System Users"
            .ShowDialog()
            oLoad(ReturnUserID)
        End With
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        Action = AppAction.Edit
        InitialiseAction()
        On Error GoTo errhdl
        Dim strValue As String
        Dim strPrompt As String
        Dim strCaption(4) As String
        Dim intWidth(4) As Integer
        strCaption(0) = "User ID"
        strCaption(1) = "Username"
        strCaption(2) = "Password"
        strCaption(3) = "Suspend"
        intWidth(0) = 120
        intWidth(1) = 450
        intWidth(2) = 0
        intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "SystemUser"
            .listQuery = "SystemUser"
            .Text = "List of System Users"
            .ShowDialog()
            oLoad(ReturnUserID)
        End With
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Action = AppAction.Add
        InitialiseAction()
        LoadModules()
        LoadReports()
        tUserID.Focus()
    End Sub
    Private Sub Flush()
        tUserID.Text = ""
        tUsername.Text = ""
        tPassword.Text = ""
        tConfirm.Text = ""
        ModuleDGV.Rows.Clear()
        ReportDGV.Rows.Clear()
        chkAdmin.Checked = False
        lnkSuspend.Text = "Suspend User"
    End Sub
    Private Sub oLoad(ByVal tUserIDStr As String)
        On Error GoTo handler
        If tUserIDStr = "" Then Exit Sub
        lnkSuspend.Text = "Suspend User"
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        Flush()
        'cnSQL.Open()
        cmSQL.CommandText = "FetchUserAccessByUserID"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@UserID", tUserIDStr)

        drSQL = cmSQL.ExecuteReader()
        If drSQL.Read Then
            tUserID.Text = tUserIDStr
            tUsername.Text = drSQL.Item("Username")
            tPassword.Text = drSQL.Item("UserPassword")
            tConfirm.Text = drSQL.Item("UserPassword")
            On Error Resume Next
            If drSQL.Item("Suspend") = True Then lnkSuspend.Text = "Release User"
        End If

        On Error GoTo handler
        drSQL.Close()
        ' cnSQL.Close()


        LoadModules()
        LoadReports()


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub CmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub LoadModules()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        ModuleDGV.Rows.Clear()
        Select Case Action
            Case AppAction.Add
                cmSQL.CommandText = "FetchAllSystemModules"
                cmSQL.CommandType = CommandType.StoredProcedure
            Case AppAction.Edit, AppAction.Delete, AppAction.Browse, 0
                cmSQL.CommandText = "FetchAllUserDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
        End Select
        Dim j As Long = 0
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read

            ModuleDGV.Rows.Add()
            ModuleDGV.Rows(j).Cells(0).Value = drSQL.Item("ModuleID").ToString
            If Action = AppAction.Edit Or Action = AppAction.Delete Or Action = AppAction.Browse Or Action = AppAction.Authorise Then
                ModuleDGV.Rows(j).Cells(1).Value = drSQL.Item("AllowOpen")
                ModuleDGV.Rows(j).Cells(2).Value = drSQL.Item("AllowAdd")
                ModuleDGV.Rows(j).Cells(3).Value = drSQL.Item("AllowEdit")
                ModuleDGV.Rows(j).Cells(4).Value = drSQL.Item("AllowBrowse")
                ModuleDGV.Rows(j).Cells(5).Value = drSQL.Item("AllowDelete")
            End If
            
            ' ModuleDGV.Rows(j).Cells(1).Style.BackColor = MainTheme
            'ModuleDGV.Rows(j).Cells(2).Value = False
            'ModuleDGV.Rows(j).Cells(3).Value = False
            'ModuleDGV.Rows(j).Cells(4).Value = False
            'ModuleDGV.Rows(j).Cells(5).Value = False
            

            Select Case drSQL.Item("ModuleID").ToString
                'Open
                Case Is = "Setup - Store Assignment", "Setup - Sales Person", "Stock Item Pack", "Stockitem List", "Stock Adjustment", "Refunds Inwards", "Refunds Outwards", "Client Transactions Summary"
                    ModuleDGV.Rows(j).Cells(2).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(3).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(4).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(5).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(2).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(3).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(4).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(5).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(2).Value = False
                    ModuleDGV.Rows(j).Cells(3).Value = False
                    ModuleDGV.Rows(j).Cells(4).Value = False
                    ModuleDGV.Rows(j).Cells(5).Value = False

                    'open,new,edit,delete
                Case Is = "System Period", "Stockitem Register", "Sales"
                    ModuleDGV.Rows(j).Cells(4).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(4).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(4).Value = False
                    'Open, new,Edit
                Case Is = "Restock"
                    ModuleDGV.Rows(j).Cells(4).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(5).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(4).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(5).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(4).Value = False
                    ModuleDGV.Rows(j).Cells(5).Value = False
                    'Open, new
                Case Is = "Stock Transfer"
                    ModuleDGV.Rows(j).Cells(3).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(4).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(5).ReadOnly = True
                    ModuleDGV.Rows(j).Cells(3).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(4).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(5).Style.BackColor = HeaderTheme
                    ModuleDGV.Rows(j).Cells(3).Value = False
                    ModuleDGV.Rows(j).Cells(4).Value = False
                    ModuleDGV.Rows(j).Cells(5).Value = False


            End Select

            j = j + 1

SkipIt:
        Loop
        'cmSQL.Connection.Close()
        'cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub LoadReports()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        ReportDGV.Rows.Clear()
        'cnSQL.Open()
        Select Case Action
            Case AppAction.Add
                cmSQL.CommandText = "FetchAllSystemReports"
                cmSQL.CommandType = CommandType.StoredProcedure
            Case AppAction.Edit, AppAction.Delete, AppAction.Browse, 0
                cmSQL.CommandText = "FetchAllUserReports"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
        End Select

        Dim j As Long = 0
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            ReportDGV.Rows.Add()
            ReportDGV.Rows(j).Cells(0).Value = UCase(drSQL.Item("ReportID").ToString)
            If Action = AppAction.Edit Or Action = AppAction.Delete Or Action = AppAction.Browse Then
                ReportDGV.Rows(j).Cells(1).Value = drSQL.Item("AllowOpen")
            End If
            'ReportDGV.Rows(j).Cells(0).Style.BackColor = MainTheme
            'ReportDGV.Rows(j).Cells(1).Style.BackColor = MainTheme
            j = j + 1
SkipIt:
        Loop

        drSQL.Close()
        ' cnSQL.Close()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)

    End Sub
    Private Sub chkAdmin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdmin.CheckedChanged
        Dim i As Integer
        If ModuleDGV.Visible Then
            For i = 0 To ModuleDGV.RowCount - 1
                If chkAdmin.Checked Then
                    ModuleDGV.Rows(i).Cells(1).Value = True
                    If ModuleDGV.Rows(i).Cells(2).ReadOnly = False Then ModuleDGV.Rows(i).Cells(2).Value = True
                    If ModuleDGV.Rows(i).Cells(3).ReadOnly = False Then ModuleDGV.Rows(i).Cells(3).Value = True
                    If ModuleDGV.Rows(i).Cells(4).ReadOnly = False Then ModuleDGV.Rows(i).Cells(4).Value = True
                    If ModuleDGV.Rows(i).Cells(5).ReadOnly = False Then ModuleDGV.Rows(i).Cells(5).Value = True

                Else
                    ModuleDGV.Rows(i).Cells(1).Value = False
                    ModuleDGV.Rows(i).Cells(2).Value = False
                    ModuleDGV.Rows(i).Cells(3).Value = False
                    ModuleDGV.Rows(i).Cells(4).Value = False
                    ModuleDGV.Rows(i).Cells(5).Value = False
                End If
            Next
        Else
            For i = 0 To ReportDGV.RowCount - 1
                If chkAdmin.Checked Then
                    ReportDGV.Rows(i).Cells(1).Value = True
                Else
                    ReportDGV.Rows(i).Cells(1).Value = False
                End If
            Next
        End If
    End Sub
    Private Function IsValidForm() As Boolean
        On Error GoTo handler
        IsValidForm = True
        If tUserID.Text = "" Or tUsername.Text = "" Or tPassword.Text = "" Or tConfirm.Text = "" Then
            MsgBox("Incomplete data for update", MsgBoxStyle.Information, strApptitle)
            Return False
        End If
        If tPassword.Text <> tConfirm.Text Then
            MsgBox("Inconsistant Password", MsgBoxStyle.Information, strApptitle)
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
        Dim drSQL As SqlDataReader
        Dim ProgramAccess As String = ""
        If Action <> AppAction.Delete Then
            If Not IsValidForm() Then
                Exit Sub
            End If
        End If

        'cnSQL.Open()
        Dim myTrans As SqlClient.SqlTransaction
        Dim i As Integer
        Select Case Action
            Case AppAction.Add

                cmSQL.Parameters.Clear()

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "InsertUserAccess"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                cmSQL.Parameters.AddWithValue("@UserName", tUsername.Text)
                cmSQL.Parameters.AddWithValue("@UserPassword", tPassword.Text)
                cmSQL.ExecuteNonQuery()


                'cmSQL.CommandText = "UPDATE "
                'cmSQL.CommandType = CommandType.StoredProcedure


                For i = 0 To ModuleDGV.Rows.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "InsertUserDetails"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                    cmSQL.Parameters.AddWithValue("@ModuleID", IIf(ModuleDGV.Item(0, i).Value = Nothing, 0, ModuleDGV.Item(0, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowOpen", IIf(ModuleDGV.Item(1, i).Value = Nothing, 0, ModuleDGV.Item(1, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowAdd", IIf(ModuleDGV.Item(2, i).Value = Nothing, 0, ModuleDGV.Item(2, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowEdit", IIf(ModuleDGV.Item(3, i).Value = Nothing, 0, ModuleDGV.Item(3, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowBrowse", IIf(ModuleDGV.Item(4, i).Value = Nothing, 0, ModuleDGV.Item(4, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowDelete", IIf(ModuleDGV.Item(5, i).Value = Nothing, 0, ModuleDGV.Item(5, i).Value))
                  
                    cmSQL.ExecuteNonQuery()

                Next

                For i = 0 To ReportDGV.Rows.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "InsertUserReports"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                    cmSQL.Parameters.AddWithValue("@ReportID", IIf(ReportDGV.Item(0, i).Value = Nothing, 0, ReportDGV.Item(0, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowOpen", IIf(ReportDGV.Item(1, i).Value = Nothing, 0, ReportDGV.Item(1, i).Value))
                    cmSQL.ExecuteNonQuery()

                Next



                myTrans.Commit()

            Case AppAction.Edit
                cmSQL.Parameters.Clear()

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                'cmSQL.CommandText = "DELETE FROM UserAccess WHERE UserID='" & ReturnUserID & "'"
                'cmSQL.CommandType = CommandType.Text
                'cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "DELETE FROM UserDetails WHERE UserId='" & ReturnUserID & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "DELETE FROM UserReports WHERE UserId='" & ReturnUserID & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UpdateUserAccess"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                cmSQL.Parameters.AddWithValue("@UserName", tUsername.Text)
                cmSQL.Parameters.AddWithValue("@UserPassword", tPassword.Text)
                cmSQL.Parameters.AddWithValue("@UserID1", ReturnUserID)
                cmSQL.ExecuteNonQuery()

                For i = 0 To ModuleDGV.Rows.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "InsertUserDetails"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                    cmSQL.Parameters.AddWithValue("@ModuleID", IIf(ModuleDGV.Item(0, i).Value = Nothing, 0, ModuleDGV.Item(0, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowOpen", IIf(ModuleDGV.Item(1, i).Value = Nothing, 0, ModuleDGV.Item(1, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowAdd", IIf(ModuleDGV.Item(2, i).Value = Nothing, 0, ModuleDGV.Item(2, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowEdit", IIf(ModuleDGV.Item(3, i).Value = Nothing, 0, ModuleDGV.Item(3, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowBrowse", IIf(ModuleDGV.Item(4, i).Value = Nothing, 0, ModuleDGV.Item(4, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowDelete", IIf(ModuleDGV.Item(5, i).Value = Nothing, 0, ModuleDGV.Item(5, i).Value))
                    cmSQL.ExecuteNonQuery()

                Next


                For i = 0 To ReportDGV.Rows.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "InsertUserReports"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text)
                    cmSQL.Parameters.AddWithValue("@ReportID", IIf(ReportDGV.Item(0, i).Value = Nothing, 0, ReportDGV.Item(0, i).Value))
                    cmSQL.Parameters.AddWithValue("@AllowOpen", IIf(ReportDGV.Item(1, i).Value = Nothing, 0, ReportDGV.Item(1, i).Value))
                    cmSQL.ExecuteNonQuery()
                Next

                myTrans.Commit()

            Case AppAction.Delete
                If LCase(tUserID.Text) = "admin" Then
                    MsgBox("Can't delete this user", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "DELETE FROM UserAccess WHERE UserID='" & ReturnUserID & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                cmSQL.CommandText = "DELETE FROM UserDetails WHERE UserID='" & ReturnUserID & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                cmSQL.CommandText = "DELETE FROM UserReports WHERE UserID='" & ReturnUserID & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                '-----Delete all related records

                myTrans.Commit()
        End Select
        cmSQL.Dispose()
        ' cnSQL.Close()
       
        Flush()

        If mnuNew.Enabled Then mnuNew_Click(sender, e)



        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()

    End Sub

    Private Sub ModuleDGV_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ModuleDGV.ColumnHeaderMouseClick
        Dim i As Integer
        Dim AllChecked As Boolean = True
        Dim AllUnChecked As Boolean = True
        For i = 0 To ModuleDGV.RowCount - 1
            If e.ColumnIndex = 1 Then
                If ModuleDGV.Rows(i).Cells(e.ColumnIndex).Value = False Then
                    AllChecked = False
                End If
                If ModuleDGV.Rows(i).Cells(e.ColumnIndex).Value = True Then
                    AllUnChecked = False
                End If
            End If
        Next i
        For i = 0 To ModuleDGV.RowCount - 1
            If e.ColumnIndex = 1 Then
                If AllChecked Then ModuleDGV.Rows(i).Cells(e.ColumnIndex).Value = False
                If AllUnChecked Then ModuleDGV.Rows(i).Cells(e.ColumnIndex).Value = True
            End If
        Next i
    End Sub
    Private Sub InitialiseAction()
        tUserID.Enabled = True
        tUsername.Enabled = True
        tPassword.Enabled = True
        tConfirm.Enabled = True
        Select Case Action
            Case AppAction.Add
                lblAction.Text = "New Record"
                cmdOk.Visible = True
            Case AppAction.Browse
                lblAction.Text = "Browse Record"
                cmdOk.Visible = False
                tUserID.Enabled = False
                tUsername.Enabled = False
                tPassword.Enabled = False
                tConfirm.Enabled = False
            Case AppAction.Edit
                lblAction.Text = "Edit Record"
                cmdOk.Visible = True
            Case AppAction.Delete
                lblAction.Text = "Delete Record"
                tUserID.Enabled = True
                cmdOk.Visible = True
                tUserID.Enabled = False
                tUsername.Enabled = False
                tPassword.Enabled = False
                tConfirm.Enabled = False
        End Select
        Flush()
    End Sub
    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        On Error GoTo errhdl
        Action = AppAction.Browse
        InitialiseAction()

        Dim strValue As String
        Dim strPrompt As String
        Dim strCaption(4) As String
        Dim intWidth(4) As Integer
        strCaption(0) = "User ID"
        strCaption(1) = "Username"
        strCaption(2) = "Password"
        strCaption(3) = "Suspend"
        intWidth(0) = 120
        intWidth(1) = 450
        intWidth(2) = 0
        intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "SystemUser"
            .listQuery = "SystemUser"
            .Text = "List of System Users"
            .ShowDialog()
            oLoad(ReturnUserID)
        End With
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub lnkReset_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        'Dim drSQL As SqlDataReader
        Dim resp As String = ""
        If MsgBox("Password would be reset....continue (y/n)?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
        resp = InputBox("Enter Password", "Reset Password", 1)
        If resp = "" Then Exit Sub
        'cnSQL.Open()
        cmSQL.CommandText = "UPDATE UserAccess SET UserPassword='" & resp & "' WHERE UserID='" & tUserID.Text & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Flush()

        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub lnkSuspend_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSuspend.LinkClicked
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        'Dim drSQL As SqlDataReader

        '  If MsgBox("User would be suspended....continue (y/n)?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
        'cnSQL.Open()
        If lnkSuspend.Text = "Suspend User" Then
            cmSQL.CommandText = "UPDATE UserAccess SET Suspend=1 WHERE UserID='" & tUserID.Text & "'"
        Else
            cmSQL.CommandText = "UPDATE UserAccess SET Suspend=0 WHERE UserID='" & tUserID.Text & "'"
        End If

        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        MsgBox("Successfull", vbInformation, strApptitle)

        Flush()

        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
End Class