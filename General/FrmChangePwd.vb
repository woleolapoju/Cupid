Imports System.Data.SqlClient
Public Class FrmChangePwd
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

        If Not IsValidForm() Then
            Exit Sub
        End If

        'cnSQL.Open()

        cmSQL.CommandText = "UPDATE UserAccess SET UserPassword='" & tPassword.Text & "' WHERE UserID='" & tUserID.Text & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        MsgBox("Password changed Successfully", MsgBoxStyle.Information, strApptitle)

        FrmStart.CloseAllToolStripMenuItem_Click(sender, e)
        LogOffIn = True

        FrmMain.tblLogin.Visible = True
        FrmMain.txtUserId.Text = ""
        FrmMain.txtUserId.Enabled = True
        FrmMain.txtPwd.Text = ""
        sysUser = ""
        FrmMain.txtPwd.Focus()


        Me.Close()


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub FrmChangePwd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Change Password"
        Me.BackColor = MainTheme
        tUserID.BackColor = MainTheme
        tUsername.BackColor = MainTheme

        tUserID.Text = sysUser
        tUsername.Text = sysUserName
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class