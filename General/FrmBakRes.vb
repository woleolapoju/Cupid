Imports System.Data
Imports System.Data.OleDb
Imports system.data.SqlClient
Public Class FrmBakRes
    Public Action As String = ""
    Private Sub FrmBakRes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        Dim cnOle As OleDbConnection
        Dim cmOle As OleDbCommand
        Dim drOle As OleDbDataReader
        cmdOk.Text = Action
        'AppHeader1.lblAppName.Visible = False
        AppHeader1.lblForm.Text = "Database " + Action

        Me.BackColor = MainTheme
        cboServerName.BackColor = MainTheme
        txtAttachName.BackColor = MainTheme
        txtUserID.BackColor = MainTheme
        txtPassword.BackColor = MainTheme

        GrpAction.Text = Action + " Path"
        Label6.Text = Action + " Filename"
        Me.Text = Action

        'cmdOk.Enabled = ModuleAdd

        cnOle = New OleDbConnection(MSAccessCn)
        cnOle.Open()

        cmOle = New OleDbCommand("SELECT * FROM SvrParam", cnOle)
        drOle = cmOle.ExecuteReader()

        If drOle.HasRows = False Then
            MsgBox("Invalid Configuration Parameter" & Chr(13) & "System Halted", MsgBoxStyle.Information)
            End
        End If
        If drOle.Read Then
            cboServerName.Text = ChkNull(drOle.Item("ServerName"))
            txtUserID.Text = ChkNull(drOle.Item("UserID"))
            txtPassword.Text = ChkNull(drOle.Item("Password"))
            txtAttachName.Text = ChkNull(drOle.Item("AttachName"))
            chkWinAuthen.Checked = drOle.Item("IntegratedSecurity")
        End If
        If Action = "Backup" Then
            If BackupPath = "" Then
                txtDBName.Text = IIf(Len(My.Application.Info.DirectoryPath) <= 3, My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath) + "\" + txtAttachName.Text + Format(Now, "ddMMyy") + ".Bak" ' + "\010203.bak")
            Else
                txtDBName.Text = BackupPath + "\" + txtAttachName.Text + Format(Now, "ddMMyy") + ".Bak" ' + "\010203.bak")
            End If
        End If


            drOle.Close()
            cnOle.Close()
            drOle.Dispose()
            'cnSQL.Dispose()
            Exit Sub
            Resume
errhdl:
            MsgBox(Err.Description, MsgBoxStyle.Critical, strApptitle)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        If Action = "Backup" Then
            'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
            Dim cmSQL As SqlCommand = cnSQL.CreateCommand
            If Trim(txtDBName.Text) = "" Then
                MsgBox("Please Enter a Backup Filename", vbInformation)
                Exit Sub
            End If
            If Len(Dir(Trim(txtDBName.Text))) > 0 Then
                Kill(Trim(txtDBName.Text))
            End If
            'cnSQL.Open()
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "BACKUP DATABASE [" & txtAttachName.Text & "] TO DISK=N'" & Trim(txtDBName.Text) & "' WITH NOINIT, NOUNLOAD, NAME=N'Cupid Backup', NOSKIP, STATS=10, NOFORMAT"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            MsgBox("Backup Successfull!!", MsgBoxStyle.Information, strApptitle)
            ' cnSQL.Close()

        Else
            Dim strConnect1 As String
            If chkWinAuthen.Checked = False Then
                strConnect1 = "Data Source=" & cboServerName.Text & ";Initial Catalog=tempdb;Persist Security Info=True;User ID=" & UserID & ";Password=" & Password
            Else
                strConnect1 = "Data Source=" & cboServerName.Text & ";Initial Catalog=tempdb;Integrated Security=True"
            End If
            Dim cnSQL As SqlConnection = New SqlConnection(strConnect1)
            Dim cmSQL As SqlCommand = cnSQL.CreateCommand

            If Trim(txtDBName.Text) = "" Then
                MsgBox("Please Select the Filename to Restore", vbInformation)
                Exit Sub
            End If
            If MsgBox("This Operation would overwrite existing Database" + Chr(13) + "Continue.....", vbCritical + vbYesNo) = vbNo Then
                Exit Sub
            End If

            'cnSQL.Open()
            If Len(Dir("c:\BankPlus" + Format(Now, "ddMMyy") + ".Bak")) > 0 Then
                If MsgBox("Pls.copy the file (c:\BankPlus" + Format(Now, "ddMMyy") + ".Bak) to a safe location before proceeding" + Chr(13) + "Proceed (y/n)", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, strApptitle) = MsgBoxResult.No Then Exit Sub
            End If
            cmSQL.CommandText = "BACKUP DATABASE [" & txtAttachName.Text & "] TO DISK=N'c:\BankPlus" + Format(Now, "ddMMyy") + ".Bak' WITH NOINIT, NOUNLOAD, NAME=N'Cupid Backup', NOSKIP, STATS=10, NOFORMAT"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            cmSQL.CommandText = "RESTORE DATABASE [" & txtAttachName.Text & "] FROM DISK =N'" & Trim(txtDBName.Text) & "' WITH REPLACE"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()

            MsgBox("Restore Successfull!!", MsgBoxStyle.Information, strApptitle)
            ' cnSQL.Close()
        End If
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub cmdDBMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDBMain.Click
        On Error GoTo handler
        If Action = "Backup" Then
            SFDialog.FileName = IIf(Len(My.Application.Info.DirectoryPath) <= 3, My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath) + txtAttachName.Text + Format(Now, "ddMMyy") + ".Bak" ' + "\010203.bak")
            If SFDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtDBName.Text = SFDialog.FileName
            End If
        Else
            If OFDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtDBName.Text = OFDialog.FileName
            End If
        End If
        
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Critical, strApptitle)
    End Sub
End Class