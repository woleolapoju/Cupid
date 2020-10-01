Imports System.Data.SqlClient
Imports System.Drawing
Public Class FrmCoyInfo
    'Private Sub cmdGetLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim OpenFileDialog As New OpenFileDialog
    '    OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
    '    OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
    '    OpenFileDialog.FilterIndex = 2

    '    If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = OpenFileDialog.FileName
    '        OwnerLogo.Image = Image.FromFile(FileName)
    '    End If
    'End Sub

    Private Sub FrmCoyInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo handler
        AppHeader1.lblForm.Text = "Edit Company Information"
        Me.BackColor = MainTheme

        tName.Text = sysOwner

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        'cnSQL.Open()

        cmSQL.CommandText = "FetchAllSystemParameters"
        cmSQL.CommandType = CommandType.StoredProcedure
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            MsgBox("Invalid System parameter", MsgBoxStyle.Information, strApptitle)
            End
        Else
            If drSQL.Read Then
                tAddress.Text = drSQL.Item("Address")
                tPhone.Text = drSQL.Item("Phone")
                temail.Text = drSQL.Item("e_mail")
                tWebsite.Text = drSQL.Item("wwweb")
                tDocFile.Text = ChkNull(drSQL.Item("eDocPath"))
                tBackupPath.Text = ChkNull(drSQL.Item("BackupPath"))
                '  chkIntegration.Checked = drSQL.Item("AC_AllowIntegration")
         
                If IsDBNull(drSQL.Item("Logo")) = False Then
                    arrayLogo = CType(drSQL.Item("Logo"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        OwnerLogo.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'OwnerLogo.Image.Save(logoPictFileName)
                        ms.Close()
                        'OwnerLogo.Image = Image.FromFile(logoPictFileName)
                    End If
                End If

                If IsDBNull(drSQL.Item("Pict1")) = False Then
                    arrayLogo = CType(drSQL.Item("Pict1"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        PB1.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'PB1.Image.Save(logoPictFileName)
                        ms.Close()
                        'PB1.Image = Image.FromFile(logoPictFileName)
                    End If
                End If

                If IsDBNull(drSQL.Item("Pict2")) = False Then
                    arrayLogo = CType(drSQL.Item("Pict2"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        PB2.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'PB2.Image.Save(logoPictFileName)
                        ms.Close()
                        'PB2.Image = Image.FromFile(logoPictFileName)
                    End If
                End If


                If IsDBNull(drSQL.Item("Pict3")) = False Then
                    arrayLogo = CType(drSQL.Item("Pict3"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        PB3.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'PB3.Image.Save(logoPictFileName)
                        ms.Close()
                        'PB3.Image = Image.FromFile(logoPictFileName)
                    End If
                End If

                If IsDBNull(drSQL.Item("Pict4")) = False Then
                    arrayLogo = CType(drSQL.Item("Pict4"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        PB4.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'PB4.Image.Save(logoPictFileName)
                        ms.Close()
                        'PB4.Image = Image.FromFile(logoPictFileName)
                    End If
                End If

                If IsDBNull(drSQL.Item("Pict5")) = False Then
                    arrayLogo = CType(drSQL.Item("Pict5"), Byte())
                    If arrayLogo.Length > 1 Then
                        Dim ms As New IO.MemoryStream(arrayLogo)
                        PB5.Image = New Bitmap(Image.FromStream(ms))
                        'Dim logoPictFileName = My.Computer.FileSystem.GetTempFileName
                        'logoPictFileName = Mid(logoPictFileName, 1, Len(logoPictFileName) - 3) + "nap"
                        'PB5.Image.Save(logoPictFileName)
                        ms.Close()
                        'PB5.Image = Image.FromFile(logoPictFileName)
                    End If
                End If

                'tTitle.Text = ChkNull(drSQL.Item("NoticeTitle"))
                'tBody.Text = ChkNull(drSQL.Item("NoticeBody"))

            End If
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        FrmMain.Text = FrmMain.Text + "     (System User: " + sysUserName + ")"


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        'cnSQL.Open()


        Dim arrayLogo() As Byte = {0}

        If IsNothing(OwnerLogo.Image) = False Then
            Dim ms As New IO.MemoryStream()
            OwnerLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) 'OwnerLogo.Image.RawFormat
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If

        cmSQL.CommandText = "UpdateSysParam4CoySetup"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@NName", tName.Text)
        cmSQL.Parameters.AddWithValue("@Address", tAddress.Text)
        cmSQL.Parameters.AddWithValue("@Phone", tPhone.Text)
        cmSQL.Parameters.AddWithValue("@E_mail", temail.Text)
        cmSQL.Parameters.AddWithValue("@wwweb", tWebsite.Text)
        'cmSQL.Parameters.AddWithValue("@NoticeTitle", tTitle.Text)
        'cmSQL.Parameters.AddWithValue("@NoticeBody", tBody.Text)
        cmSQL.Parameters.AddWithValue("@logo", arrayLogo)
        cmSQL.Parameters.AddWithValue("@eDocPath", tDocFile.Text)
        cmSQL.Parameters.AddWithValue("@BackupPath", tBackupPath.Text)


        ReDim arrayLogo(0)
        If IsNothing(PB1.Image) = False Then
            Dim ms As New IO.MemoryStream()
            PB1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If
        cmSQL.Parameters.AddWithValue("@Pict1", arrayLogo)

        ReDim arrayLogo(0)
        If IsNothing(PB2.Image) = False Then
            Dim ms As New IO.MemoryStream()
            PB2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If
        cmSQL.Parameters.AddWithValue("@Pict2", arrayLogo)

        ReDim arrayLogo(0)
        If IsNothing(PB3.Image) = False Then
            Dim ms As New IO.MemoryStream()
            PB3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If
        cmSQL.Parameters.AddWithValue("@Pict3", arrayLogo)

        ReDim arrayLogo(0)
        If IsNothing(PB4.Image) = False Then
            Dim ms As New IO.MemoryStream()
            PB4.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If
        cmSQL.Parameters.AddWithValue("@Pict4", arrayLogo)

        ReDim arrayLogo(0)
        If IsNothing(PB5.Image) = False Then
            Dim ms As New IO.MemoryStream()
            PB5.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrayLogo = ms.GetBuffer
            ms.Close()
        End If
        cmSQL.Parameters.AddWithValue("@Pict5", arrayLogo)

        cmSQL.ExecuteNonQuery()
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        InitialiseEntireSystem()

        MsgBox("Pls. restart...", vbInformation, strApptitle)

        End

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    'Private Sub InsertLogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    cmdGetLogo_Click(sender, e)
    'End Sub

    'Private Sub ClearLogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    OwnerLogo.Image = Nothing
    'End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
    Private Sub PB1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB1.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            If Len(FileName) = 0 Then
                PB1.Image = Nothing
            Else
                PB1.Image = Image.FromFile(FileName)
            End If
        End If
    End Sub
    Private Sub PB2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB2.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            If Len(FileName) = 0 Then
                PB2.Image = Nothing
            Else
                PB2.Image = Image.FromFile(FileName)
            End If
        End If
    End Sub
    Private Sub PB3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB3.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            If Len(FileName) = 0 Then
                PB3.Image = Nothing
            Else
                PB3.Image = Image.FromFile(FileName)
            End If
        End If
    End Sub
    Private Sub PB4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB4.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            If Len(FileName) = 0 Then
                PB4.Image = Nothing
            Else
                PB4.Image = Image.FromFile(FileName)
            End If
        End If
    End Sub
    Private Sub PB5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB5.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            If Len(FileName) = 0 Then
                PB5.Image = Nothing
            Else
                PB5.Image = Image.FromFile(FileName)
            End If
        End If
    End Sub

    Private Sub OwnerLogo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OwnerLogo.DoubleClick
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        OpenFileDialog.FilterIndex = 2
        OwnerLogo.Image = Nothing
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            OwnerLogo.Image = Image.FromFile(FileName)
        End If
    End Sub
    Private Sub cmdGetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetFile.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tDocFile.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub cmdGetBakPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBakPath.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tBackupPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class