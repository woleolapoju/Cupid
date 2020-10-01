Imports System.Windows.Forms

Public Class FrmStart

    Private Sub FrmStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TO DISABLE Timer for faster process
        'TimerMail.Enabled = AC_AllowMailing

        Dim height As Integer = My.Computer.Screen.Bounds.Height
        Dim width As Integer = My.Computer.Screen.Bounds.Width
        If height < 768 And width < 1024 Then
            MsgBox("A minimum resolution of 764x1024 is recommended" + Chr(13) + "Current system resolution is less", MsgBoxStyle.Information, strApptitle)
        End If

       
        On Error GoTo handler
        If LogOnFail Then
            FrmSvrInfor.ShowDialog()
            InitialiseEntireSystem()
        End If

        FrmSplash.ShowDialog()
        'FrmStart.ShowDialog()

        FrmMain.MdiParent = Me
        FrmMain.Dock = DockStyle.Fill
        FrmMain.Show()

        
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)


    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Public Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        On Error Resume Next
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            If Not (ChildForm.Name = "FrmMain") Then ChildForm.Close()
        Next
    End Sub
    Private m_ChildFormNumber As Integer
    Private Sub lnkReconnect_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReconnect.LinkClicked
        On Error Resume Next
        Cursor = Cursors.WaitCursor
        cnSQL.Close()
        cnSQL.Open()
        Cursor = Cursors.Default
    End Sub
    Private Sub OwnerLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OwnerLogo.Click
        PanLogo.Visible = False
    End Sub

    Private Sub tblBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblBottom.Click
        PanLogo.Visible = True
    End Sub

End Class
