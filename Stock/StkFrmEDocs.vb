Imports System.Data.SqlClient
Imports System.IO
Public Class StkFrmEDoc
    Public ReturnCode As String
    Private Sub FrmeDocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DeleteHTMTempFiles()
        Panel1.BackColor = HeaderTheme
        Panel2.BackColor = MainTheme
        Me.BackColor = MainTheme
        LB.BackColor = MainTheme

        cmdStock.Enabled = GetUserAccessDetails("Stock Items", False)

        AppHeader1.lblForm.Text = "eDocuments"
        tDocDir.Text = eDocDir + "\"
        If tRefNo.Text <> "" Then
            CreateHTML(tRefNo.Text)
            loadfiles()
        End If
    End Sub
    Private Sub cmdGetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetFile.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PDF|*.pdf"
        OpenFileDialog.FilterIndex = 1
        tFileName.Text = ""
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            tFileName.Text = FileName
        End If
    End Sub

    Private Sub tRefNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tRefNo.LostFocus
        CreateHTML(tRefNo.Text)
    End Sub

    Private Function CreateHTML(ByVal strRefNo As String) As Boolean
        On Error GoTo errHandler
        'If Trim(strAccountNo) = "" Then Exit Sub
        ' Create an instance of StreamWriter to write text to a file.
        LB.Items.Clear()
        Dim GetHTMFileName As String = My.Computer.FileSystem.GetTempFileName
        GetHTMFileName = Mid(GetHTMFileName, 1, Len(GetHTMFileName) - 3) + "apx"
        CreateHTML = False
        Using sw As StreamWriter = New StreamWriter(GetHTMFileName)

            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>")
            sw.WriteLine("<title>ApexSuite</title>")
            sw.WriteLine("<style>")
            sw.WriteLine("<!--")
            sw.WriteLine("BODY         { background: url('top-vb.gif') repeat-x; font-family: Verdana; font-size: 67% }")
            sw.WriteLine(".maindiv     { background: url('side-vb.gif') repeat-y; padding-left: 30px; padding-top: 5px; position: relative; ")

            sw.WriteLine("height: 50px }")
            sw.WriteLine("P            { margin-top: 0; margin-bottom: 6px; line-height:130% }")
            sw.WriteLine("H1           { margin-top: 20px; margin-bottom: 12px; font-size:190% }")
            sw.WriteLine("H2           { color: #585F56; left: -55px; position: relative; margin-top: 21px; margin-bottom: 9px; font-size:170% ")

            sw.WriteLine("}")
            sw.WriteLine("H3           { margin-top: 21px; margin-bottom: 9px; font-size: 140%;  font-weight: bold}")
            sw.WriteLine("H4           { margin-top: 18px; margin-bottom: 9px; font-size: 140%; font-weight: bold}")
            sw.WriteLine("OL           { margin-top: 0; margin-bottom: 9px; line-height:130%}")
            sw.WriteLine("UL           { margin-top: 0; margin-bottom: 9px; line-height:130%}")
            sw.WriteLine("LI           { margin-top: 0; margin-bottom: 6px }")
            sw.WriteLine("BLOCKQUOTE   { margin-left: 10px }")
            sw.WriteLine("TABLE        { padding: 4px; BACKGROUND: lightsteelblue; BORDER: #DDDCD6 1px solid; BORDER-COLLAPSE: collapse; margin-")

            sw.WriteLine("bottom: 9px; }")
            sw.WriteLine("TR           { vertical-align: top} ")
            sw.WriteLine("TD           { padding: 4px; font-family: Verdana; font-size: 67%; line-height: 130%} ")
            sw.WriteLine(".contents    { line-height: 150% }")
            sw.WriteLine("DIV.CodeBlock   { font-family: 'Courier New'; font-size: 100%; margin-bottom: 6px; BACKGROUND: lightsteelblue; BORDER: ")

            sw.WriteLine("#eeede6 1px solid; padding: 5px; }")
            sw.WriteLine(".CodeInline  { font-family: 'Courier New' }")
            sw.WriteLine(".ProcedureLabel {margin-top: 5px; font-style: italic; font-weight: bold; color: #0D4CC3 } ")
            sw.WriteLine(".FileNameCol { padding: 5px; BACKGROUND:lightblue; width=200px; font-size: 60%; font-weight: bold}")
            sw.WriteLine(".Col {padding: 5px; width=600px}")
            sw.WriteLine("-->")
            sw.WriteLine("</style>")
            sw.WriteLine("</head>")

            sw.WriteLine("<body topmargin='0' leftmargin='0' rightmargin='0'>")
            sw.WriteLine("<div class='maindiv'>")

            sw.WriteLine("<a name='top'>")

            sw.WriteLine("<!-- MAIN CONTENT BEGINS -->")

            'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
            Dim cmSQL As SqlCommand = cnSQL.CreateCommand
            Dim drSQL As SqlDataReader
            cmSQL.CommandText = "FetchProduct4HTMfile"

            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@ProductCode", strRefNo)

            'cnSQL.Open()
            drSQL = cmSQL.ExecuteReader()
            Dim i As Integer
            If drSQL.HasRows = False Then GoTo SkipIt
            CreateHTML = True
            If drSQL.Read Then

                sw.WriteLine("<h1>")
                sw.WriteLine("<span style='font-size: 11pt'>" & sysOwner & "</span><a name='top'>")
                sw.WriteLine("<span style='font-size: 11pt;color: #990000'>Stock Item Details:</span><a name='top'>")
               
                sw.WriteLine("</h1>")

                sw.WriteLine("</a>")

                sw.WriteLine("<table border='1' bordercolor= #DDDCD6 width='100%' style='border-collapse: collapse'>")
                sw.WriteLine("<tr>")

                For i = 0 To drSQL.FieldCount - 1

                    sw.WriteLine("<tr>")

                    sw.WriteLine("<td class='FileNameCol'>" & drSQL.GetName(i) & "</td>")
                    If drSQL.Item(i).GetType.ToString = "System.DateTime" Then
                        sw.WriteLine("<td class='Col'>" & IIf(IsDBNull(drSQL.Item(i)), "", Format(drSQL.Item(i), "dd-MMM-yyyy")) & "</td>")
                    ElseIf drSQL.Item(i).GetType.ToString = "System.Decimal" Then
                        sw.WriteLine("<td class='Col'>" & IIf(IsDBNull(drSQL.Item(i)), 0, Format(drSQL.Item(i), "standard")) & "</td>")
                    Else
                        sw.WriteLine("<td class='Col'>" & ChkNull(drSQL.Item(i)) & "</td>")
                    End If
                    sw.WriteLine("</tr>")
                Next i
            Else
                sw.WriteLine("<h1>")
                sw.WriteLine("<span style='font-size: 11pt;color: #990000'>" & sysOwner & "</span><a name='top'>")
                sw.WriteLine("</h1>")
                sw.WriteLine("<h1>")
                sw.WriteLine("<span style='font-size: 11pt;color: #990000'>Details:</span><a name='top'>")
                sw.WriteLine("</h1>")
                sw.WriteLine("</a>")
                sw.WriteLine("<table border='1' bordercolor= #DDDCD6 width='70%' style='border-collapse: collapse'>")
                sw.WriteLine("<tr>")
            End If

SkipIt:
            'cmSQL.Connection.Close()
            cmSQL.Dispose()
            drSQL.Close()
            ' cnSQL.Close()
            'cnSQL.Dispose()

            sw.WriteLine("</table>")
            sw.WriteLine("</p>")
            'sw.WriteLine("<h3>")
            'sw.WriteLine("<span style='font-size: 60%'>")
            'sw.WriteLine("Web site:</span> <a href='http://www.megahitsystems.com'><span style='font-size: 70%'>")
            'sw.WriteLine("www.megahitsystem.com</span></a>")
            'sw.WriteLine("</h3>")

            sw.WriteLine("<h3>")
            sw.WriteLine("<span style='font-size: 60%'>")
            sw.WriteLine("<span>")

            sw.WriteLine("<span> © ApexSuite. ")
            sw.WriteLine("</span>")

            sw.WriteLine("<p>&nbsp;</p>")

            sw.WriteLine("</div>")
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")

            sw.Close()

            WebBrowser.Navigate(New Uri(GetHTMFileName))

        End Using
        Exit Function
        Resume
errHandler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Function
    Private Sub Navigate(ByVal address As String)

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        If Not address.StartsWith("http://") Then
            address = address ''"http://" &
        End If

        Try
            WebBrowser.Navigate(New Uri(address))
        Catch ex As System.UriFormatException
            WebBrowser.Visible = False
            MsgBox("Cannot open Readme file", MsgBoxStyle.Information, strApptitle)
            Return
        End Try
    End Sub
    Private Sub DeleteHTMTempFiles()
        On Error Resume Next
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Temp, FileIO.SearchOption.SearchTopLevelOnly, "*.apx")
            Kill(foundFile)
        Next
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        Dim theExt As String = ""
        Dim i As Integer = InStr(tFileName.Text, ".")
        If i > 0 Then theExt = Mid(tFileName.Text, i)

        If chkMove.Checked = False Then
            System.IO.File.Copy(tFileName.Text, tDocDir.Text + "\" + tRefNo.Text + tRefNo.Tag + "(" + tNewFilename.Text + ")" + theExt)
        Else
            System.IO.File.Move(tFileName.Text, tDocDir.Text + "\" + tRefNo.Text + tRefNo.Tag + "(" + tNewFilename.Text + ")" + theExt)
        End If

        MsgBox("Successfull !", MsgBoxStyle.Information)

        loadfiles()
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Critical, strApptitle)
    End Sub

    Sub loadfiles()
        On Error GoTo handler
        Dim Directory As New IO.DirectoryInfo(tDocDir.Text)
        Dim allFiles As IO.FileInfo() = Directory.GetFiles(tRefNo.Text + Trim(tRefNo.Tag) + "*.*", SearchOption.TopDirectoryOnly)
        'Dim allFiles As IO.FileInfo() = Directory.GetFiles("*.*")
        Dim singleFile As IO.FileInfo
        Dim j As Integer
        LB.Items.Clear()
        For Each singleFile In allFiles
            LB.Items.Add(singleFile.Name)
            j = j + 1
        Next

        tNewFilename.Text = j + 1

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub LB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LB.Click
        On Error GoTo handler
        If LB.Text = "" Then Exit Sub
        WebBrowser.Navigate(tDocDir.Text + LB.Text)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub mnuDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteFile.Click
        On Error GoTo handler
        '        On Error Resume Next
        If MsgBox("This action would delete the file (" + UCase(LB.Text) & ") stored in the location" & Chr(13) & "Continue (y/n)", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub
        Kill(tDocDir.Text + LB.Text)
        loadfiles()
        Exit Sub
handler:
        If Err.Description Like "*Could not find a part of the path*" Then 'Err.Number = 76
            MsgBox("Error Deleting... Pls. contact administrator")
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub

    Private Sub mnuPreviewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPreviewFile.Click
        If LB.Text = "" Then Exit Sub
        On Error GoTo handler
        System.Diagnostics.Process.Start(tDocDir.Text + LB.Text)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Sub mnuShowRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowRecord.Click
        tRefNo_LostFocus(sender, e)
    End Sub
    Private Sub mnuShowRecordR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowRecordR.Click
        tRefNo_LostFocus(sender, e)
    End Sub

    Private Sub RadPicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPicture.Click
        ' tRefNo.Text =
        tRefNo.Tag = "P"
        loadfiles()
    End Sub

  Private Sub RadeDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadeDoc.Click
        tRefNo.Tag = "D"
        loadfiles()
    End Sub

    Private Sub tRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tRefNo.TextChanged

    End Sub

    Private Sub tFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tFileName.TextChanged

    End Sub

    Private Sub LB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB.SelectedIndexChanged

    End Sub
End Class
