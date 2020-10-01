Public Class FrmSplash

    Private Sub FrmSplash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Close()
    End Sub

    Private Sub FrmSplash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Me.Close()
    End Sub

    Private Sub FrmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tTimer.Enabled = True
        'If LogOnFail Then
        '    FrmSvrInfor.ShowDialog()
        '    InitialiseEntireSystem()
        'End If
        lblOwner.Text = sysOwner
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tTimer.Tick
        Me.Close()
    End Sub
End Class
