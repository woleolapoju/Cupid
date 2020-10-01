Imports System.Data.SqlClient
Imports System.IO
Public Class FrmRptBuilder
    Dim LogicalCondition As String
    Private TheFrom As String = ""
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearScr()
    End Sub
    Private Sub ClearScr()
        txtSQL.Text = ""
        cboValue.Text = ""
        txtCondition.Text = ""
        Dim i As Integer
        For i = 0 To lbField.Items.Count - 1
            lbField.SetSelected(i, False)
        Next i
        lvList.Columns.Clear()
        lvList.Columns.Add("Result Listings", 300)
        lvList.Items.Clear()
    End Sub
    Private Sub FrmRptBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errorhandle
        cmdDisplay.Enabled = ModuleAdd
        If ModuleAdd = False Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        AppHeader1.lblForm.Text = "Report Builder"
        Me.BackColor = MainTheme
        lvList.BackColor = MainTheme
        txtSQL.BackColor = MainTheme


        cmSQL.CommandText = "SELECT * FROM ReportWriter ORDER BY tName"
        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo SkipIt
        Dim initialText As String
        Do While drSQL.Read
            lbTable.Items.Add(drSQL.Item("tName"))
        Loop
SkipIt:
        'lbTable.SelectedIndex = 0
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        'lvTable.ListIndex = 0

        cboCondition.Items.Add("=")
        cboCondition.Items.Add(">")
        cboCondition.Items.Add("<")
        cboCondition.Items.Add(">=")
        cboCondition.Items.Add("<=")
        cboCondition.Items.Add("<>")
        cboCondition.Items.Add("Like")
        cboCondition.SelectedIndex = 0

        Exit Sub
        Resume
errorhandle:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Sub FillFields()
        On Error GoTo errorhandle
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        Dim i As Integer
        TheFrom = ""

        cmSQL.CommandText = "SELECT tFrom FROM ReportWriter WHERE tName='" & lbTable.Text & "'"
        cmSQL.CommandType = CommandType.Text

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo SkipIt
        If drSQL.Read Then TheFrom = "[" & drSQL.Item("tFrom") & "]"
SkipIt:
        drSQL.Close()
        cmSQL.CommandText = "SELECT * FROM " & TheFrom
        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            drSQL.Close()
            Exit Sub
        End If

        If drSQL.Read Then

        End If

        lbField.Items.Clear()
        cboDataField.Items.Clear()
        cboSortBy.Items.Clear()

        cboSortBy.Items.Add("")
        cboDataField.Items.Add("")
        For i = 0 To drSQL.FieldCount - 1
            lbField.Items.Add(drSQL.GetName(i))
            cboDataField.Items.Add(drSQL.GetName(i))
            cboSortBy.Items.Add(drSQL.GetName(i))
        Next i
        cmSQL.Dispose()
        drSQL.Close()
        'lbField.SelectedIndex = 0
        cboDataField.SelectedIndex = 1
        cboSortBy.SelectedIndex = 0

        ClearScr()

        'cmSQL.Connection.Close()

        ' cnSQL.Close()
        'cnSQL.Dispose()


        Exit Sub
        Resume
errorhandle:

        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub lbTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTable.SelectedIndexChanged
        ClearScr()
        cboSortBy.Items.Clear()
        cboDataField.Items.Clear()
        cboValue.Items.Clear()
        FillFields()
        CompileSQLStmt()
    End Sub
    Private Sub CompileSQLStmt()
        On Error GoTo errhdl
        If TheFrom = "" Then Exit Sub
        txtSQL.Text = ""
        cboValue.Text = ""
        Dim choice As Integer = 0
        Dim SQLstmnt As String = "Select Distinct "
        Dim i As Integer
        For i = 0 To lbField.Items.Count - 1
            If lbField.GetSelected(i) = True Then
                choice = 1
                SQLstmnt = SQLstmnt & " [" & Mid(lbField.Items.Item(i).ToString, InStr(lbField.Items.Item(i).ToString, ".") + 1) & "],"
            End If
        Next i
        If choice = 1 Then
            SQLstmnt = Microsoft.VisualBasic.Left(SQLstmnt, Len(SQLstmnt) - 1)
        Else
            SQLstmnt = SQLstmnt & " *"
        End If
        SQLstmnt = SQLstmnt & " FROM"

        SQLstmnt = SQLstmnt & " " & TheFrom & ","
        SQLstmnt = Microsoft.VisualBasic.Left(SQLstmnt, Len(SQLstmnt) - 1)

        If txtCondition.Text <> "" Then
            SQLstmnt = SQLstmnt & " WHERE " & txtCondition.Text
        End If
        If cboSortBy.Text <> "" Then SQLstmnt = SQLstmnt & " ORDER BY " & " [" & Mid(cboSortBy.Text, InStr(cboSortBy.Text, ".") + 1) & "]" & IIf(chkSortOrder.Checked, " ASC", " DESC")
        txtSQL.Text = SQLstmnt

        DisplayRpt()

        Exit Sub
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub lbField_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbField.Click
        CompileSQLStmt()
    End Sub

    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
        On Error GoTo errhdl
        If cboCondition.Text = "" Or cboDataField.Text = "" Or cboValue.Text = "" Then
            MsgBox("Choose A Field, the Condition,and the Value")
            Exit Sub
        End If
        Dim FieldType As System.Type = Nothing
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()

        cmSQL.CommandText = "SELECT * FROM " & TheFrom
        cmSQL.CommandType = CommandType.Text


        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo skipit
        Dim i As Integer
        For i = 0 To drSQL.FieldCount - 1
            If drSQL.GetName(i) = cboDataField.Text Then
                FieldType = drSQL.GetFieldType(i)
                Exit For
            End If
        Next i
skipit:
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Select Case FieldType.ToString
            Case Is = "System.String", "System.Byte", "System.DateTime" '6, 131
                If txtCondition.Text = "" Then
                    txtCondition.Text = txtCondition.Text & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & "'" & IIf(cboCondition.Text = "Like", "%", "") & IIf(cboCondition.Text = "End with", "%", "") & cboValue.Text & IIf(cboCondition.Text = "Like", "%", "") & IIf(cboCondition.Text = "Start with", "%", "") & "'"
                Else
                    If LogicalCondition = "" Then
                        MsgBox("Please select the logical operator 'AND/OR'", vbInformation, strApptitle)
                        Exit Sub
                    End If
                    txtCondition.Text = txtCondition.Text & LogicalCondition & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & "'" & IIf(cboCondition.Text = "Like", "%", "") & IIf(cboCondition.Text = "End with", "%", "") & cboValue.Text & IIf(cboCondition.Text = "Like", "%", "") & IIf(cboCondition.Text = "Start with", "%", "") & "'"
                End If
            Case Is = "System.Boolean" ' Boolean fields
                If txtCondition.Text = "" Then
                    txtCondition.Text = txtCondition.Text & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & IIf(cboValue.Text = "True", 1, 0)
                Else
                    If LogicalCondition = "" Then
                        MsgBox("Please select the logical operator 'AND/OR'", vbInformation, strApptitle)
                        Exit Sub
                    End If
                    txtCondition.Text = txtCondition.Text & LogicalCondition & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & IIf(cboValue.Text = "True", 1, 0)
                End If
            Case Else 'Numbers
                If txtCondition.Text = "" Then
                    txtCondition.Text = txtCondition.Text & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & cboValue.Text
                Else
                    If LogicalCondition = "" Then
                        MsgBox("Please select the logical operator 'AND/OR'", vbInformation, strApptitle)
                        Exit Sub
                    End If
                    txtCondition.Text = txtCondition.Text & LogicalCondition & " [" & Mid(cboDataField.Text, InStr(cboDataField.Text, ".") + 1) & "] " & IIf(cboCondition.Text = "Start with" Or cboCondition.Text = "End with", "Like", cboCondition.Text) & cboValue.Text
                End If
        End Select
        cboValue.Text = ""
        LogicalCondition = ""
        CompileSQLStmt()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        On Error GoTo errorhandle
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()

        cboValue.Items.Clear()

        Dim TheWhere = IIf(chkLoadPeriod.Checked, " WHERE [Date]>='" & sysStartDate & "' AND [Date]<='" & sysEndDate & "'", "")
1:
        cmSQL.CommandText = "SELECT DISTINCT [" & cboDataField.Text & "] FROM " & TheFrom & TheWhere
        cmSQL.CommandType = CommandType.Text


        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo skipit

        Do While drSQL.Read
            cboValue.Items.Add(ChkNull(drSQL.GetValue(0)))
        Loop
        cboValue.SelectedIndex = 0
        'cmSQL.Connection.Close()
skipit:
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
errorhandle:
        If Err.Number = 5 Then
            TheWhere = ""
            GoTo 1
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
    End Sub

    Private Sub cmdOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOR.Click
        LogicalCondition = " OR "
    End Sub

    Private Sub cmdAND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAND.Click
        LogicalCondition = " AND "
    End Sub

    Private Sub chkSortOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSortOrder.CheckedChanged
        CompileSQLStmt()
    End Sub

    Private Sub cboSortBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSortBy.SelectedIndexChanged
        CompileSQLStmt()
    End Sub
    Sub PreviewRpt4NewSheet()
        'Create a new workbook in Excel
        On Error Resume Next
        lblWait.Visible = True
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.add
        oSheet = oBook.Worksheets(1)

        Dim filename As String = Path.GetTempFileName()
        Kill(filename)

        oExcel.Workbooks.Open(filename)


        oSheet.Range("A1").font.size = 12
        oSheet.Range("A1").font.bold = True
        oSheet.Range("A1").font.underline = True
        oSheet.Range("A1").value = UCase(sysOwner)

        oSheet.Range("A3").font.size = 12
        oSheet.Range("A3").font.underline = True
        oSheet.Range("A3").value = UCase(lbTable.SelectedItem)


        Dim oQryTable As Object

        Dim cnn As String = "OLEDB;Provider=SQLOLEDB.1;Password=" & Password & ";Persist Security Info=True;User ID=" & UserID & ";Initial Catalog=" & AttachName & ";Data Source=" & ServerName

        oQryTable = oSheet.QueryTables.Add(cnn & ";", oSheet.Range("A5"), txtSQL.Text)
        oQryTable.Refresh(False)

        oExcel.Workbooks(1).Save() 'As(filename)
        oExcel.Visible = True
        oExcel.Workbooks(1).PrintPreview()
        oExcel.Workbooks(1).SaveAs(filename)
        oExcel.Workbooks(1).Close()
        oExcel.Quit()
        Kill(filename)
        lblWait.Visible = False
    End Sub
    Sub PreviewRpt()
        'Create a new workbook in Excel
        On Error Resume Next
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        lblWait.Visible = True
        'My.Application.DoEvents()

        Dim oExcel As Object
        oExcel = CreateObject("Excel.Application")

        Dim filename As String = Path.GetTempFileName()
        Kill(filename)
        FileCopy(AppPath & "ConfigDir\" + "rptWriter.xls", filename)

        oExcel.Workbooks.Open(filename)


        Dim i As Integer

        'cnSQL.Open()

        cmSQL.CommandText = txtSQL.Text
        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo skipit
        oExcel.Sheets(1).Select()
        oExcel.Cells(1, 1) = UCase(sysOwner)

        oExcel.Cells(3, 1) = UCase(lbTable.SelectedItem)

        oExcel.Cells(5, 1) = "S/n"
        If drSQL.Read Then
            For i = 0 To drSQL.FieldCount - 1
                oExcel.Cells(5, i + 2) = drSQL.GetName(i)
            Next i
        End If

        Dim k As Integer = 1
        Dim j As Integer = 6

skipit:
        drSQL.Close()
        cmSQL.CommandText = txtSQL.Text
        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()

        Do While drSQL.Read
            oExcel.Cells(j, 1) = k
            For i = 0 To drSQL.FieldCount - 1
                If drSQL.Item(i).GetType.ToString = "System.DateTime" Then
                    oExcel.Cells(j, i + 2) = IIf(IsDBNull(drSQL.Item(i)), "", Format(drSQL.Item(i), "dd-MMM-yyyy"))
                Else
                    oExcel.Cells(j, i + 2) = ChkNull(drSQL.Item(i))
                End If
            Next
            j = j + 1
            k = k + 1
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        oExcel.Workbooks(1).Save()   'As(filename)
        oExcel.Visible = True
        oExcel.Workbooks(1).PrintPreview()
        oExcel.Workbooks(1).Close()
        oExcel.Quit()
        Kill(filename)
        lblWait.Visible = False
    End Sub
    Sub DisplayRpt()
        On Error GoTo hell
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        lblWait.Visible = True
        '' My.Application.DoEvents()
        lvList.Columns.Clear()
        lvList.Items.Clear()

        'cnSQL.Open()

        'cboValue.Items.Clear()
        'Report Title

        Dim i As Integer

        cmSQL.CommandText = txtSQL.Text
        cmSQL.CommandType = CommandType.Text


        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo skipit
        If drSQL.Read Then
            lvList.Columns.Add("S/n")
            For i = 0 To drSQL.FieldCount - 1
                lvList.Columns.Add(drSQL.GetName(i))
            Next i
        End If
skipit:
        drSQL.Close()
        cmSQL.CommandText = txtSQL.Text
        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("No Record(s) for the selected criteria", vbInformation, strApptitle)
            drSQL.Close()
            Exit Sub
        End If

        Dim k As Integer = 1
        Dim initialText As String
        Do While drSQL.Read

            Dim LvItems As New ListViewItem(k)
            For i = 0 To drSQL.FieldCount - 1
                If drSQL.Item(i).GetType.ToString = "System.DateTime" Then
                    LvItems.SubItems.Add(IIf(IsDBNull(drSQL.Item(i)), "", Format(drSQL.Item(i), "dd-MMM-yyyy")))
                Else
                    LvItems.SubItems.Add(ChkNull(drSQL.Item(i)))
                End If
            Next
            lvList.Items.AddRange(New ListViewItem() {LvItems})
            k = k + 1
        Loop


        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()


        lblWait.Visible = False
        Exit Sub
        Resume
hell:
        lblWait.Visible = False
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub cmdDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
        If chkBrowser.Checked = True Then
            'BrowseRpt()
            CreateHTML(txtSQL.Text, lbTable.Text)
        Else
            PreviewRpt()
        End If
    End Sub

    Private Sub cboDataField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDataField.SelectedIndexChanged
        cboValue.Items.Clear()
        cboValue.Text = ""
    End Sub
    Private Sub BrowseRpt()
        On Error GoTo errhdl
        If txtSQL.Text = "" Then Exit Sub
        lblWait.Visible = True
        'My.Application.DoEvents()
        Dim FieldType As System.Type = Nothing
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        'cnSQL.Open()

        Dim filename As String = Path.GetTempFileName()
        Kill(filename)
        filename = Mid(filename, 1, Len(filename) - 3) + "htm"
        Dim strSQL As String = "EXECUTE sp_makewebtask @outputfile = N'" & filename & "', @query=N'" & txtSQL.Text & "', @fixedfont=1, @HTMLheader=3, @webpagetitle=N'Megahit Systems', @resultstitle=N'" & sysOwner & "', @dbname=N'" & AttachName & "', @whentype=1,@procname=N'Cupid Web Page',@codepage=65001,@charset=N'utf-8'" '"SELECT * FROM " & TheFrom
        cmSQL.CommandText = strSQL
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        System.Diagnostics.Process.Start(filename)

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        lblWait.Visible = False
        Exit Sub
        Resume
errhdl:
        lblWait.Visible = False
        MsgBox(Err.Description, vbInformation, strApptitle)

    End Sub

    Public Sub CreateHTML(ByVal strQuery As String, ByVal Title As String, Optional ByVal WebBrowser As Object = Nothing)
        On Error GoTo errHandler
        If Trim(strQuery) = "" Then Exit Sub
        lblWait.Visible = True
        '' My.Application.DoEvents()
        ' Create an instance of StreamWriter to write text to a file.
        Dim GetHTMFileName As String = My.Computer.FileSystem.GetTempFileName
        GetHTMFileName = Mid(GetHTMFileName, 1, Len(GetHTMFileName) - 3) + "htm"

        Using sw As StreamWriter = New StreamWriter(GetHTMFileName)

            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>")
            sw.WriteLine("<title>" + Title + "</title>")
            sw.WriteLine("<style>")
            sw.WriteLine("<!--")
            sw.WriteLine("BODY         { background: url('top-vb.gif') repeat-x; font-family: Verdana; font-size: 67% }")
            sw.WriteLine(".maindiv     { background: url('side-vb.gif') repeat-y; padding-left: 55px; padding-top: 5px; position: relative; ")

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
            sw.WriteLine("BLOCKQUOTE   { margin-left: 20px }")
            sw.WriteLine("TABLE        { padding: 4px; BACKGROUND: #f8f7ef; BORDER: #DDDCD6 1px solid; BORDER-COLLAPSE: collapse; margin-")

            sw.WriteLine("bottom: 9px; }")
            sw.WriteLine("TR           { vertical-align: top} ")
            sw.WriteLine("TD           { padding: 4px; font-family: Verdana; font-size: 67%; line-height: 130%} ")
            sw.WriteLine(".contents    { line-height: 150% }")
            sw.WriteLine("DIV.CodeBlock   { font-family: 'Courier New'; font-size: 100%; margin-bottom: 6px; BACKGROUND: #f8f7ef; BORDER: ")

            sw.WriteLine("#eeede6 1px solid; padding: 10px; }")
            sw.WriteLine(".CodeInline  { font-family: 'Courier New' }")
            sw.WriteLine(".ProcedureLabel {margin-top: 12px; font-style: italic; font-weight: bold; color: #0D4CC3 } ")
            sw.WriteLine(".FileNameCol { padding: 6px; BACKGROUND: #eeede6; width=220px; font-weight: bold}")
            sw.WriteLine("-->")
            sw.WriteLine("</style>")
            sw.WriteLine("</head>")

            sw.WriteLine("<body topmargin='0' leftmargin='0' rightmargin='20'>")
            sw.WriteLine("<div class='maindiv'>")

            sw.WriteLine("<a name='top'>")

            sw.WriteLine("<!-- MAIN CONTENT BEGINS -->")

            sw.WriteLine("<h2>")
            sw.WriteLine("<span style='font-size: 13pt;color: #990000'>" + sysOwner + "</span><a name='top'>")
            sw.WriteLine("</h2>")

            sw.WriteLine("<h1>")
            sw.WriteLine("<span style='font-size: 11pt;color: #990000'>" + Title + "</span><a name='top'>")

            sw.WriteLine("</h1>")

            sw.WriteLine("</a>")

            sw.WriteLine("<table border='1' bordercolor= #DDDCD6 width='100%' style='border-collapse: collapse'>")
            sw.WriteLine("<tr>")


            'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
            Dim cmSQL As SqlCommand = cnSQL.CreateCommand
            Dim drSQL As SqlDataReader

            cmSQL.CommandText = strQuery
            cmSQL.CommandType = CommandType.Text
            'cnSQL.Open()
            drSQL = cmSQL.ExecuteReader()
            Dim i As Integer
            If drSQL.HasRows = False Then
                sw.WriteLine("<h3>")
                sw.WriteLine("<span style='font-size: 120%'>")
                sw.WriteLine("No Record</h3>")
                sw.WriteLine("<span>")
            Else


                sw.WriteLine("<tr>")
                For i = 0 To drSQL.FieldCount - 1
                    sw.WriteLine("<td class='FileNameCol'>" & drSQL.GetName(i) & "</td>")
                Next i
                sw.WriteLine("</tr>")

                Do While drSQL.Read = True
                    sw.WriteLine("<tr>")
                    For i = 0 To drSQL.FieldCount - 1
                        sw.WriteLine("<td>" & ChkNull(drSQL.Item(i)) & "</td>")
                    Next i
                    sw.WriteLine("</tr>")
                Loop
                sw.WriteLine("</table>")
                sw.WriteLine("</p>")

            End If
            'cmSQL.Connection.Close()
            cmSQL.Dispose()
            drSQL.Close()
            ' cnSQL.Close()
            'cnSQL.Dispose()


            sw.WriteLine("<h3>")
            sw.WriteLine("<span style='font-size: 50%'>")
            sw.WriteLine("Web site:</span> <a href='http://www.megahitsystems.com'><span style='font-size: 70%'>")
            sw.WriteLine("www.megahitsystem.com</span></a>")
            sw.WriteLine("</h3>")

            sw.WriteLine("<h3>")
            sw.WriteLine("<span style='font-size: 60%'>")
            sw.WriteLine("<span>")

            sw.WriteLine("Cupid. All rights reserved. Conditions and Terms applied")
            sw.WriteLine("</span>")

            sw.WriteLine("<p>&nbsp;</p>")

            sw.WriteLine("</div>")
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")


            sw.Close()


            If WebBrowser Is Nothing Then
                System.Diagnostics.Process.Start(GetHTMFileName)
            Else
                WebBrowser.Navigate(New Uri(GetHTMFileName))
            End If

            lblWait.Visible = False

        End Using
        Exit Sub
        Resume
errHandler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub

    Private Sub lbField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbField.SelectedIndexChanged

    End Sub
End Class