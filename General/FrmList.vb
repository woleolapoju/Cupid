Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmList

    Public frmParent As Object
    Public tSelection As String
    Public qryPrm As String = ""
    Public colIndex As Integer = 0
    Dim pstrCaption() As String
    Dim pintWidth() As Integer
    Dim plistQuery As String
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Public listQuery As String
    Private Sub FrmList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate

        DGrid.DataSource = bindingSource
        LoadLvList()
        'DGrid.AutoGenerateColumns = True
        cboCriteria.SelectedIndex = 1
        If colIndex > 0 And qryPrm <> "" Then
            tFilter.Text = qryPrm
            SelColumn.Value = colIndex
            PassFilter(DGrid, tFilter.Text)
            colIndex = 0
            qryPrm = ""
            tFilter.Text = ""
            SelColumn.Value = 1
        End If
    End Sub
    Public Sub LoadLvList()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmdOk.Visible = True
        cmSQL.CommandType = CommandType.StoredProcedure
        Dim startdate As String = "01-" & Format(Now, "MMM-yyyy")
        Dim EndDate As String = ""
        For i = 31 To 28 Step -1
            If IsDate(i.ToString & "-" & Format(Now, "MMM-yyyy")) = True Then
                EndDate = i.ToString & "-" & Format(Now, "MMM-yyyy")
                Exit For
            End If
        Next

        Select Case listQuery
            '----------------General
            Case "Store"
                cmSQL.CommandText = "SELECT Store, [Default],NonSelling FROM STORE"
                cmSQL.CommandType = CommandType.Text
            Case "SystemUser"
                cmSQL.CommandText = "FetchAllUserAccess"
            Case "Customer"
                cmSQL.CommandText = "SELECT  ID,Name,Address,ContactPerson,ClientType FROM  Client ORDER BY ClientType,  ID"
                cmSQL.CommandType = CommandType.Text
                'Case "Debit Client"
                '    cmSQL.CommandText = "SELECT  CustomerCode,CustomerName,Balance FROM  ClientBalances WHERE Balance>0 ORDER BY CustomerCode"
                '    cmSQL.CommandType = CommandType.Text
                'Case "Credit Client"
                '    cmSQL.CommandText = "SELECT  CustomerCode,CustomerName,0-isnull(Balance,0) AS Balance FROM  ClientBalances WHERE Balance<0 ORDER BY CustomerCode"
                '    cmSQL.CommandType = CommandType.Text
            Case "Supplier"
                cmSQL.CommandText = "SELECT  ID,Name,Address,ContactPerson,ClientType FROM  Client ORDER BY ClientType DESC,  ID"
                cmSQL.CommandType = CommandType.Text
            Case "Edit Sales"
                cmSQL.CommandText = "FetchAllSales"
                cmSQL.Parameters.AddWithValue("@Store", qryPrm)
                cmSQL.CommandType = CommandType.StoredProcedure
            Case "Edit Restock"
                cmSQL.CommandText = "FetchAllReceipt"
                cmSQL.Parameters.AddWithValue("@Store", qryPrm)
                cmSQL.CommandType = CommandType.StoredProcedure

            Case "Browse Payment Inwards"
                cmSQL.CommandText = "FetchAllPaymentsInwards"
                cmSQL.CommandType = CommandType.StoredProcedure
            Case "Browse Payment Outwards"
                cmSQL.CommandText = "FetchAllPaymentsOutwards"
                cmSQL.CommandType = CommandType.StoredProcedure

            Case "Delete Payment Inwards", "Edit Payment Inwards"
                'cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Receiveable' AND [Date]>='" & CDate(startdate) & "' AND [Date]<='" & CDate(EndDate) & "' ORDER BY [Date] DESC"
                If DateDurationValidation >= 0 Then
                    cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Receiveable' AND  DATEDIFF(day, [Date], GETDATE())<=" & DateDurationValidation & " ORDER BY [Date] DESC"
                Else
                    cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Receiveable' ORDER BY [Date] DESC"
                End If
                cmSQL.CommandType = CommandType.Text
            Case "Delete Payment Outwards", "Edit Payment Outwards"
                'cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Payable' AND [Date]>='" & CDate(startdate) & "' AND [Date]<='" & CDate(EndDate) & "' ORDER BY [Date] DESC"
                If DateDurationValidation >= 0 Then
                    cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Payable' AND  DATEDIFF(day, [Date], GETDATE())<=" & DateDurationValidation & " ORDER BY [Date] DESC"
                Else
                    cmSQL.CommandText = "SELECT PaymentTag, [Date], AmtPaid, PayMode, ClientName,Purpose AS Particulars FROM  Payments WHERE PayType='Payable' ORDER BY [Date] DESC"
                End If
                cmSQL.CommandType = CommandType.Text

            Case "FetchAllJournal"
                cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Particulars, DrDesc, CrDesc, Title FROM JOURNAL ORDER BY RefNo"
                cmSQL.CommandType = CommandType.Text
            Case "FetchAllIncome"
                cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, IncomeDesc, BankDesc, ReceiptNo,ReceivedFrom FROM INCOME ORDER BY RefNo"
                cmSQL.CommandType = CommandType.Text
            Case "FetchAllExpenditure"
                cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, ExpenseDesc, BankDesc, VoucherNo,ExpendedBy FROM EXPENDITURE ORDER BY RefNo"
                cmSQL.CommandType = CommandType.Text
            Case "FetchEditeableJournal"
                'cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Particulars, DrDesc, CrDesc, Title FROM JOURNAL WHERE [Date]>='" & CDate(startdate) & "' AND [Date]<='" & CDate(EndDate) & "' ORDER BY RefNo"
                If DateDurationValidation >= 0 Then
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Particulars, DrDesc, CrDesc, Title FROM JOURNAL WHERE DATEDIFF(day, [Date], GETDATE())<=" & DateDurationValidation & " ORDER BY RefNo"
                Else
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Particulars, DrDesc, CrDesc, Title FROM JOURNAL ORDER BY RefNo"
                End If
                cmSQL.CommandType = CommandType.Text
            Case "FetchEditeableIncome"
                'cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, IncomeDesc, BankDesc, ReceiptNo,ReceivedFrom FROM INCOME WHERE [Date]>='" & CDate(startdate) & "' AND [Date]<='" & CDate(EndDate) & "' ORDER BY RefNo"
                If DateDurationValidation >= 0 Then
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, IncomeDesc, BankDesc, ReceiptNo,ReceivedFrom FROM INCOME WHERE DATEDIFF(day, [Date], GETDATE())<=" & DateDurationValidation & " ORDER BY RefNo"
                Else
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, IncomeDesc, BankDesc, ReceiptNo,ReceivedFrom FROM INCOME ORDER BY RefNo"
                End If
                cmSQL.CommandType = CommandType.Text
            Case "FetchEditeableExpenditure"
                'cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, ExpenseDesc, BankDesc, VoucherNo,ExpendedBy FROM EXPENDITURE WHERE [Date]>='" & CDate(startdate) & "' AND [Date]<='" & CDate(EndDate) & "' ORDER BY RefNo"
                If DateDurationValidation >= 0 Then
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, ExpenseDesc, BankDesc, VoucherNo,ExpendedBy FROM EXPENDITURE WHERE DATEDIFF(day, [Date], GETDATE())<=" & DateDurationValidation & " ORDER BY RefNo"
                Else
                    cmSQL.CommandText = "SELECT RefNo, [Date], Amount, Purpose, ExpenseDesc, BankDesc, VoucherNo,ExpendedBy FROM EXPENDITURE ORDER BY RefNo"
                End If
                cmSQL.CommandType = CommandType.Text

        End Select

        'cnSQL.Open()
        dataAdapter = New SqlDataAdapter(cmSQL) '"AC_FetchAllPaymentVouchers", strConnect)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        cmSQL.Dispose()
        lblCount.Text = DGrid.Rows.Count
        SelColumn.Minimum = 1
        SelColumn.Maximum = DGrid.Columns.Count

        If listQuery = "SystemUser" Then DGrid.Columns(2).Visible = False

        Dim myStyle1 As New DataGridViewCellStyle
        myStyle1.Format = "N2"
        myStyle1.Alignment = DataGridViewContentAlignment.BottomRight

        If listQuery = "UnPostedPaymentVoucher" Or listQuery = "AllPaymentVoucher" Then
            'DGrid.Columns(3).Visible = False
            DGrid.Columns(7).DefaultCellStyle = myStyle1
            ' DGrid.Columns(9).Visible = False
            DGrid.Columns(10).DefaultCellStyle = myStyle1
            DGrid.Columns(11).DefaultCellStyle = myStyle1
            'DGrid.Columns(12).DefaultCellStyle = myStyle1
            'DGrid.Columns(13).Visible = False
            'DGrid.Columns(14).Visible = False
        End If

        formatGrid()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Sub formatGrid()

        Dim myStyle1 As New DataGridViewCellStyle
        myStyle1.Format = "N2"
        myStyle1.Alignment = DataGridViewContentAlignment.BottomRight

        For i = 0 To DGrid.ColumnCount - 1
            If DGrid.Columns(i).ValueType.FullName = "System.Decimal" Then
                ' MsgBox(DGrid.Columns(i).ValueType.FullName)
                DGrid.Columns(i).DefaultCellStyle = myStyle1
            End If
        Next
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        Select Case tSelection
            '_____________________General
            Case "Store"
                On Error Resume Next
                frmParent.ReturnStore = DGrid.Tag
                frmParent.ReturnDefault = Me.Tag
                frmParent.ReturnNonSelling = GrpQuery.Tag
            Case "SystemUser"
                frmParent.ReturnUserID = DGrid.Tag '.SelectedItems.Item.ToString
            Case "Customer", "Suppliers"
                frmParent.ReturnCode = DGrid.Tag
            Case "Supplier"
                frmParent.ReturnCode = DGrid.Tag
            Case "Edit Sales"
                frmParent.ReturnOrderNo = DGrid.Tag
            Case "Edit Restock"
                frmParent.ReturnOrderNo = DGrid.Tag
            Case "Delete Payment Inwards", "Delete Payment Outwards", "Edit Payment Inwards", "Edit Payment Outwards", "Browse Payment Inwards", "Browse Payment Outwards"
                frmParent.ReturnRefNo = Val(DGrid.Tag)
            Case "FetchAllJournal", "FetchAllIncome", "FetchAllExpenditure", "FetchEditeableJournal", "FetchEditeableIncome", "FetchEditeableExpenditure"
                frmParent.ReturnRefNo = Val(DGrid.Tag)
        End Select
        DGrid.Tag = ""
        Me.Close()
        Exit Sub
handler:
        If Err.Number = 5 Then
            MsgBox("Please select an entry", vbInformation, strApptitle)
        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        On Error GoTo handler
        Select Case tSelection
            '_____________________General
        
            Case "SystemUser"
                frmParent.ReturnUserID = ""
            Case "Customer", "Suppliers"
                frmParent.ReturnCode = ""
               
            Case "Supplier"
                frmParent.ReturnCode = ""
            Case "Edit Sales"
                frmParent.ReturnOrderNo = 0
            Case "Edit Restock"
                frmParent.ReturnOrderNo = 0
            Case "Delete Payment Inwards", "Delete Payment Outwards", "Edit Payment Inwards", "Edit Payment Outwards", "Browse Payment Inwards", "Browse Payment Outwards"
                frmParent.ReturnRefNo = -1
        End Select
        DGrid.Tag = ""
        Me.Close()
        Exit Sub
handler:
        If Err.Number = 5 Then
            MsgBox("Please select an entry", vbInformation, strApptitle)
        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        On Error GoTo errhdl
        'Dim myStyle As New DataGridViewCellStyle
        'myStyle.ForeColor = Color.Black

        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        'DGrid.DataSource = bindingSource

        'DGrid.Refresh()
        tFilter.Text = ""
        'Dim x As Integer = 0
        'Dim y As Integer = 0
        'While x < DGrid.Rows.Count

        '    While y < DGrid.Rows(x).Cells.Count
        '        DGrid.Item(y, x).Style = myStyle
        '        y = y + 1
        '    End While

        '    'DGrid.Rows(x).DefaultCellStyle = myStyle
        '    x = x + 1
        'End While
        SelColumn.Maximum = DGrid.Columns.Count

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        PassFilter(DGrid, tFilter.Text)
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub

    Private Sub tFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdFilter_Click(sender, e)
        End If
    End Sub
    Private Sub PassFilter(ByRef datagridview As DataGridView, ByVal strFilter As String)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim jk As Integer = 0
        Dim kj As Integer
        Dim wr As Integer = 0
        Dim containStr As Boolean = False
        ' Row indexes we'll remove later on.
        Dim deleteIndexList As List(Of Integer) = New List(Of Integer)

        Dim strNewFilter As String = ""
        Select Case cboCriteria.Text
            Case Is = "="
                strNewFilter = strFilter
            Case Is = "Containing"
                strNewFilter = "*" + strFilter + "*"
            Case Is = "Start With"
                strNewFilter = strFilter + "*"
            Case Is = "End With"
                strNewFilter = "*" + strFilter
        End Select
        While i < datagridview.Rows.Count
            j = 0
            containStr = False

            If chkIgnore.Checked = True Then
                jk = datagridview.Rows(i).Cells.Count - 1
                kj = 0
            Else
                kj = SelColumn.Value - 1
                jk = SelColumn.Value - 1
            End If
            For j = kj To jk
                If Not datagridview.Item(j, i).Value Is DBNull.Value Or Nothing Then
                    If LCase(datagridview.Item(j, i).Value) Like LCase(strNewFilter) Then
                        containStr = True
                        wr = wr + 1
                        Exit For
                    End If

                End If
            Next j
            If Not containStr Then
                ' Don't remove rows here or your row indexes will get out of whack!
                ' datagridview.Rows.RemoveAt(i)
                deleteIndexList.Add(i)
            End If
            i = i + 1
        End While
        ' Remove rows by reversed row index order (highest removed first) to keep the indexes in whack.
        deleteIndexList.Reverse()
        For Each idx As Integer In deleteIndexList
            datagridview.Rows.RemoveAt(idx)
        Next
        lblCount.Text = wr
    End Sub
    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        On Error GoTo handler
        Dim x As Integer = 0

        Dim myStyle As New DataGridViewCellStyle
        Dim myStyle1 As New DataGridViewCellStyle
        myStyle.ForeColor = Color.Red
        myStyle1.ForeColor = Color.Black
        Dim ij As Integer = 0
        Dim jk As Integer = 0
        Dim kj As Integer
        Dim strNewFilter As String = ""
        Select Case cboCriteria.Text
            Case Is = "="
                strNewFilter = tFilter.Text
            Case Is = "Containing"
                strNewFilter = "*" + tFilter.Text + "*"
            Case Is = "Start With"
                strNewFilter = tFilter.Text + "*"
            Case Is = "End with"
                strNewFilter = "*" + tFilter.Text
        End Select

        While x < DGrid.Rows.Count
            Dim y As Integer = 0
            If chkIgnore.Checked = True Then
                jk = DGrid.Rows(x).Cells.Count - 1
                kj = 0
            Else
                kj = SelColumn.Value - 1
                jk = SelColumn.Value - 1
            End If
            For y = kj To jk
                If Not DGrid.Item(y, x).Value Is DBNull.Value Or Nothing Then
                    If LCase(DGrid.Item(y, x).Value) Like LCase(strNewFilter) Then
                        DGrid.Item(y, x).Style = myStyle
                        ij = ij + 1
                    End If
                End If
            Next y
            x = x + 1
        End While
        If ij = 0 Then
            MessageBox.Show("Match Not Found!")
        Else
            MessageBox.Show("(" + ij.ToString + ") Match Found")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportToExcel.Click
        On Error GoTo handler
        Dim oXL As Object
        oXL = CreateObject("Excel.Application")
        oXL.Visible = True
        oXL.Workbooks.Add()

        oXL.Sheets(1).Select()

        oXL.Visible = True

        ' Format A1:D1 as bold, vertical alignment = center.
        With oXL.Sheets(1).Range("A1", "AZ1")
            .Font.Bold = True
            ' .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With

        Dim jk As Integer = 0
        For j = 0 To DGrid.ColumnCount - 1
            oXL.Cells(1, j + 1) = DGrid.Columns(j).Name.ToString()
        Next

        For i = 0 To DGrid.RowCount - 1
            If DGrid.Rows(i).Selected = True Then
                For j = 0 To DGrid.ColumnCount - 1
                    oXL.Cells(jk + 2, j + 1) = DGrid(j, i).Value.ToString()
                Next
                jk = jk + 1
            End If
        Next

        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.

        oXL.UserControl = True

        ' Make sure that you release object references.
        oXL.Quit()
        oXL = Nothing

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub mnuCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyToClipboard.Click

        DGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        If DGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(DGrid.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                'Me.TextBox1.Text = Clipboard.GetText()
                MsgBox("Successfull!!")
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("The Clipboard could not be accessed. Please try again.")
            End Try

        End If
    End Sub
    Sub ExportData()

        'Dim oExcel As Object
        'oExcel = CreateObject("Excel.Application")

        'Dim filename As String = AppPath & "CupidExcel.xls"
        'On Error Resume Next
        'Kill(filename)
        'On Error GoTo handler
        'FileCopy(AppPath & "ConfigDir\" + "rptWriter.xls", filename)
        'oExcel.Workbooks.Open(filename)
        'oExcel.Sheets(1).Select()

        'Dim i As Integer
        'Dim j As Integer


        'oExcel.Sheets(1).Select()
        'oExcel.rows(1).delete()
        'oExcel.rows(2).delete()
        'oExcel.rows(3).delete()
        'oExcel.rows(4).delete()
        'oExcel.rows(5).delete()
        'oExcel.rows(6).delete()
        'Dim jk As Integer = 0
        'For j = 0 To DGrid.ColumnCount - 1
        '    oExcel.Cells(2, j + 1) = DGrid.Columns(j).Name.ToString()
        'Next

        'For i = 0 To DGrid.RowCount - 1
        '    If DGrid.Rows(i).Selected = True Then
        '        For j = 0 To DGrid.ColumnCount - 1
        '            oExcel.Cells(jk + 3, j + 1) = DGrid(j, i).Value.ToString()
        '        Next
        '        jk = jk + 1
        '    End If
        'Next
        'oExcel.rows(1).delete()

        'oExcel.Workbooks(1).Save() 'As(filename)
        ''oExcel.Visible = True
        ''oExcel.Workbooks(1).PrintPreview()
        'oExcel.Workbooks(1).Close()
        'oExcel.Quit()

        'releaseObject(oExcel)

        'MsgBox("Successfull!!! You can find the file in " + filename)

    End Sub
    'Sub releaseObject(ByVal obj As Object)
    '    Try
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '        obj = Nothing
    '    Catch ex As Exception
    '        obj = Nothing
    '    Finally
    '        GC.Collect()
    '    End Try
    'End Sub
    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        On Error Resume Next
        DGrid.Tag = DGrid.Item(0, e.RowIndex).Value
        Me.Tag = DGrid.Item(1, e.RowIndex).Value
        GrpQuery.Tag = DGrid.Item(2, e.RowIndex).Value
        cboCriteria.Tag = DGrid.Item(3, e.RowIndex).Value
        SelColumn.Value = e.ColumnIndex + 1
        tFilter.Text = DGrid.Item(e.ColumnIndex, e.RowIndex).Value

    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        On Error Resume Next
        If Len(DGrid.Tag) = 0 Then Exit Sub
        cmdOk_Click(sender, e)
        DGrid.Tag = ""
    End Sub
    Private Sub mnuGetTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGetTotal.Click
        Dim i As Integer = Val(SelColumn.Value) - 1
        Dim sum As Double
        If DGrid.Columns(i).ValueType.FullName = "System.Decimal" Then
            For j = 0 To DGrid.RowCount - 1
                sum = sum + DGrid.Item(i, j).Value
            Next
        End If
        If sum > 0 Then
            MsgBox("TOTAL: " + Trim(Str(Format(sum, "standard"))))
            tFilter.Text = Format(sum, "standard")
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class

