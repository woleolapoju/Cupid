Public Class AppHeader
    Private Sub AppHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        lblForm.Text = "Accounting"
        lblForm.BackColor = HeaderTheme

    End Sub
End Class
