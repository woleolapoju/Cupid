Imports System.Data.SqlClient
Public Class FrmColorTheme

    Private Sub FrmColorTheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = ""
        cmdThemeB.BackColor = MainTheme
        cmdThemeH.BackColor = HeaderTheme
        cmdThemeB.Tag = MainThemeCode
        cmdThemeH.Tag = HeaderThemeCode
    End Sub

    Private Sub cmdThemeH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThemeH.Click
        Dim MyDialog As New ColorDialog()
        ' Keeps the user from selecting a custom color.
        MyDialog.AllowFullOpen = True
        ' Allows the user to get help. (The default is false.)
        MyDialog.ShowHelp = True
        ' Sets the initial color select to the current text color,
        MyDialog.Color = cmdThemeH.BackColor
        ' Update the text box color if the user clicks OK 
        If (MyDialog.ShowDialog() = DialogResult.OK) Then
            cmdThemeH.BackColor = MyDialog.Color
            cmdThemeH.Tag = MyDialog.Color.ToArgb
        End If
    End Sub

    Private Sub cmdThemeB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThemeB.Click
        Dim MyDialog1 As New ColorDialog()
        ' Keeps the user from selecting a custom color.
        MyDialog1.AllowFullOpen = True
        ' Allows the user to get help. (The default is false.)
        MyDialog1.ShowHelp = True
        ' Sets the initial color select to the current text color,
        MyDialog1.Color = cmdThemeB.BackColor
        ' Update the text box color if the user clicks OK 
        If (MyDialog1.ShowDialog() = DialogResult.OK) Then
            cmdThemeB.BackColor = MyDialog1.Color
            cmdThemeB.Tag = MyDialog1.Color.ToArgb
        End If
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        cmdThemeB.BackColor = Color.Khaki
        cmdThemeB.Tag = Color.Khaki.ToArgb
        cmdThemeH.BackColor = Color.Goldenrod
        cmdThemeH.Tag = Color.Goldenrod.ToArgb
        cmdUpdate_Click(sender, e)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '   Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET MainTheme ='" & cmdThemeB.Tag & "', HeaderTheme='" & cmdThemeH.Tag & "' WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        MainTheme = Color.FromArgb(cmdThemeB.Tag)
        HeaderTheme = Color.FromArgb(cmdThemeH.Tag)
        myStyleGridAlternate.BackColor = MainTheme

        MsgBox("Successful!!!!", MsgBoxStyle.Information, strApptitle)
        Me.Close()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class