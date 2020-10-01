Public Class stkFrmText
    Public frmParent As Object
    Private Sub FrmText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblHeader.BackColor = HeaderTheme
        Me.BackColor = MainTheme
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        frmParent.text = txt.Text
        Me.Close()
    End Sub
End Class