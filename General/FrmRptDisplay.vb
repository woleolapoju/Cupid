Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmRptDisplay
    Public RptFilename, SelFormula, RptDestination, RptTitle As String
    Public myReportDocument As ReportDocument
    Public PaperSize, POrientation, PrinterName As String
    Public SpecialZoom As Integer
    Dim StoredX As Long
    Dim StoredY As Long

    Dim originalMargin As PageMargins
    Dim originalPaperSize As PaperSize
    Dim originalOrientation As PaperOrientation

    Private Sub FrmRptDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        originalMargin = myReportDocument.PrintOptions.PageMargins
        originalPaperSize = CrystalDecisions.Shared.PaperSize.PaperA4 '"A4" ' RptFilename.PrintOptions.PaperSize
        originalOrientation = myReportDocument.PrintOptions.PaperOrientation

        Dim pkInstalledPrinters As String
        cboPrinters.Items.Clear()
        cboPrinters.Items.Add("(Default)")
        On Error Resume Next
        ' Find all printers installed
        For Each pkInstalledPrinters In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboPrinters.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters
        ' Set the combo to the first printer in the list
        cSize.SelectedIndex = 0
        cboPrinters.SelectedIndex = 0
        cOrientation.SelectedIndex = 0

        ConfigureCrystalReports()

        Me.Text = "Report: " + UCase(RptTitle)

        myReportDocument.PrintOptions.PaperSize = originalPaperSize 'CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        myReportDocument.PrintOptions.PaperOrientation = originalOrientation 'PaperOrientation.DefaultPaperOrientation

        'If Not (originalMargin.leftMargin = 0 Or originalMargin.rightMargin = 0) Then myReportDocument.PrintOptions.ApplyPageMargins(originalMargin)

        myReportDocument.Refresh()

        myCrystalReportViewer.ReportSource = myReportDocument
        If SelFormula <> "" Then myCrystalReportViewer.SelectionFormula = SelFormula
        myCrystalReportViewer.Zoom(75)
        If SpecialZoom <> 0 Then myCrystalReportViewer.Zoom(SpecialZoom)
        SpecialZoom = 0


        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub ConfigureCrystalReports()
        On Error GoTo handler
        Dim intCounter As Integer
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        ConInfo.ConnectionInfo.DatabaseName = AttachName
        ConInfo.ConnectionInfo.ServerName = ServerName
        If IntegratedSecurity Then
            ConInfo.ConnectionInfo.IntegratedSecurity = True
        Else
            ConInfo.ConnectionInfo.Password = Password
            ConInfo.ConnectionInfo.UserID = UserID
        End If

        For intCounter = 0 To myReportDocument.Database.Tables.Count - 1
            myReportDocument.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        Next

        If RptDestination = "Printer" Then
            ' You can change more print options via PrintOptions property of ReportDocument
            ' myCrystalReportViewer.PrintReport()
            myReportDocument.PrintToPrinter(1, True, 0, 0)
            myReportDocument.Close()
        End If
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub ConfigureCrystalReports_Old()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = AttachName
        myConnectionInfo.ServerName = ServerName
        If IntegratedSecurity Then
            myConnectionInfo.IntegratedSecurity = True
        Else
            myConnectionInfo.Password = Password
            myConnectionInfo.UserID = UserID
        End If

        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
            myTable.Location = myConnectionInfo.DatabaseName + ".dbo." + myTable.Location.Substring(myTable.Location.LastIndexOf(".") + 1)
        Next

        If RptDestination = "Printer" Then
            ' You can change more print options via PrintOptions property of ReportDocument
            ' myCrystalReportViewer.PrintReport()
            myReportDocument.PrintToPrinter(1, True, 0, 0)
            myReportDocument.Close()
        End If
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cboPrinters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrinters.SelectedIndexChanged

        'Me.Cursor = Cursors.WaitCursor
        ''cSize.Items.Clear()
        'If Not sender.text = "" Then
        '    ' cSize.Visible = True
        '    '  cSize.Items.Clear()

        '    Dim objPrint As New System.Drawing.Printing.PrinterSettings
        '    ' Dim strPrinters As String
        '    Dim printerformat As System.Drawing.Printing.PaperSize
        '    cSize.Items.Add("(Default)")
        '    For Each printer As String In Printing.PrinterSettings.InstalledPrinters

        '        If printer = sender.text Then

        '            Dim PrinterObj As New System.Drawing.Printing.PrinterSettings()
        '            PrinterObj.PrinterName = printer
        '            For Each printerformat In PrinterObj.PaperSizes()

        '                Try
        '                    cSize.Items.Add(printerformat.PaperName)

        '                Catch ex As Exception

        '                End Try

        '            Next
        '        End If
        '    Next

        'End If
        'cSize.SelectedIndex = 0
        'Me.Cursor = Cursors.Default

    End Sub
    Private Sub mnuSHOWPRINTERSETTINGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSHOWPRINTERSETTINGSToolStripMenuItem.Click
        PanList.Visible = True
    End Sub

    Private Sub PanList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanList.MouseDown
        StoredX = e.X
        StoredY = e.Y
        PanList.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanList.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanList.Top = PanList.Top - (StoredY - e.Y)
            PanList.Left = PanList.Left - (StoredX - e.X)
        End If
        PanList.Cursor = Cursors.Default
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

        'Dim i As Integer = 0
        'Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        'doctoprint.PrinterSettings.PrinterName = cboPrinters.Text
        'For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
        '    Dim rawKind As Integer
        '    If doctoprint.PrinterSettings.PaperSizes(i).PaperName = cSize.Text Then
        '        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
        '        myReportDocument.PrintOptions.PaperSize = rawKind
        '        Exit For
        '    End If
        'Next

        Select Case cSize.Text
            Case Is = "(Default)"
                myReportDocument.PrintOptions.PaperSize = originalPaperSize 'CrystalDecisions.Shared.PaperSize.DefaultPaperSize
            Case Is = "A4"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
            Case Is = "A3"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3
            Case Is = "A5"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5
            Case Is = "B4"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperB4
            Case Is = "B5"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperB5
            Case Is = "Executive"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperExecutive
            Case Is = "FanfoldLegal"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldLegalGerman
            Case Is = "FanfoldStandard"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldStdGerman
            Case Is = "FanfoldUS"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldUS
            Case Is = "Legal"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
            Case Is = "Letter"
                myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        End Select

        Select Case cOrientation.Text
            Case Is = "(Default)"
                myReportDocument.PrintOptions.PaperOrientation = originalOrientation
            Case Is = "Portrait"
                myReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            Case Is = "Landscape"
                myReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape
        End Select


        If cboPrinters.Text <> "(Default)" Then
            myReportDocument.PrintOptions.PrinterName = cboPrinters.Text
        Else
            myReportDocument.PrintOptions.PrinterName = ""
        End If

        myReportDocument.Refresh()

        ''myReportDocument.PrintOptions.PageMargins = New CrystalDecisions.Shared.PageMargins(1, 1, 1, 1)

        'If Not (originalMargin.leftMargin = 0 Or originalMargin.rightMargin = 0) Then myReportDocument.PrintOptions.ApplyPageMargins(originalMargin)

        myCrystalReportViewer.RefreshReport()

    End Sub

    Private Sub cmdClosePanList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanList.Click
        PanList.Visible = False
    End Sub
End Class