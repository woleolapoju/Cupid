Imports System.Data.SqlClient
Imports System.IO
Public Class FrmClientLedger
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private bindingSourceA As New BindingSource()
    Private dataAdapterA As New SqlDataAdapter()
    Private bindingSourceB As New BindingSource()
    Private dataAdapterB As New SqlDataAdapter()
    Dim ReturnCode As String = ""
    Dim StoredX As Long
    Dim StoredY As Long
    Private Sub FrmClientLedger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        DGrid.DataSource = bindingSource
        DGridSummary.DataSource = bindingSourceA
        DGridFullDetails.DataSource = bindingSourceB

        AppHeader2.lblForm.Text = "Client Ledger"
        Dim e1 As System.Windows.Forms.LinkLabelLinkClickedEventArgs
        'lnkViewType_LinkClicked(sender, e1)

        DGrid.BackgroundColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        Me.BackColor = MainTheme
        DGridSummary.BackgroundColor = MainTheme
        DGridSummary.AlternatingRowsDefaultCellStyle = myStyleGridAlternate

        PanList.BackColor = HeaderTheme

        DGridFullDetails.BackgroundColor = MainTheme
        DGridFullDetails.AlternatingRowsDefaultCellStyle = myStyleGridAlternate

        LoadClientBalances()
       
        'tblMain.RowStyles(1).SizeType = SizeType.Percent
        'tblMain.RowStyles(2).SizeType = SizeType.Absolute
        'tblMain.RowStyles(2).Height = 0
        'tblMain.RowStyles(1).Height = 100

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Sub LoadClientBalances()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        'cnSQL.Open()
        cmSQL.Parameters.Clear()
        ' cmSQL.CommandText = "AC_FetchClientBalancesSummary"

        cmSQL.CommandText = "SELECT CustomerCode, MAX(CustomerName) AS CustomerName, SUM(Dr) AS Dr, SUM(Cr) AS Cr, SUM(Dr - CR) AS Balance FROM CliientAccountStatement  GROUP BY CustomerCode"
        cmSQL.CommandType = CommandType.Text
        dataAdapterA = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(dataAdapterA)
        Dim tableA As New DataTable()
        tableA.Locale = System.Globalization.CultureInfo.InvariantCulture
        dataAdapterA.Fill(tableA)
        bindingSourceA.DataSource = tableA

        Dim myStyle As New DataGridViewCellStyle
        Dim myStyle1 As New DataGridViewCellStyle
        myStyle.ForeColor = Color.Red
        myStyle.Format = "N2"
        myStyle1.Format = "N2"
        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        myStyle1.ForeColor = Color.Black
        myStyle1.Alignment = DataGridViewContentAlignment.MiddleRight
        ' cnSQL.Close()

        'For i = 0 To DGridSummary.Rows.Count - 1
        '    If DGridSummary.Item(4, i).Value < 0 Then
        '        DGridSummary.Item(4, i).Style = myStyle
        '    Else
        '        DGridSummary.Item(4, i).Style = myStyle1
        '    End If
        'Next

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub LoadDetails(ByVal ClientCode As String, ByVal theCurrency As String)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        'cnSQL.Open()
        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "SELECT [Date], RefNo, Particulars, CR, Dr, Source FROM CliientAccountStatement WHERE CustomerCode='" & ClientCode & "' ORDER BY [Date]"
        cmSQL.CommandType = CommandType.Text
        dataAdapter = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        dataAdapter.Fill(table)
        bindingSource.DataSource = table

        DGrid.Columns(2).Width = 200
        DGrid.Columns(1).Width = 60
        DGrid.Columns(0).Width = 80

        Dim myStyle As New DataGridViewCellStyle
        Dim myStyle1 As New DataGridViewCellStyle
        myStyle.ForeColor = Color.Red
        myStyle.Format = "N2"
        myStyle1.Format = "N2"
        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        myStyle1.ForeColor = Color.Black
        myStyle1.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim i As Integer
        Dim j As Integer

        'For i = 0 To DGrid.Rows.Count - 1
        '    If DGrid.Item(2, i).Value < 0 Then
        '        DGrid.Item(2, i).Style = myStyle
        '    Else
        '        DGrid.Item(2, i).Style = myStyle1
        '    End If
        'Next

        DGrid.Columns(3).DefaultCellStyle = myStyle1
        DGrid.Columns(4).DefaultCellStyle = myStyle1

        cmSQL.Dispose()
        ' cnSQL.Close()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        On Error Resume Next

        If DGrid.Item(1, e.RowIndex).Value Is Nothing Then Exit Sub
        ReturnCode = DGrid.Item(1, e.RowIndex).Value
        DGridFullDetails.Tag = DGrid.Item(5, e.RowIndex).Value

        DGrid.Tag = e.RowIndex

    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        LoadFullDetails(ReturnCode, DGridFullDetails.Tag)

    End Sub
    Private Sub DGridSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridSummary.CellClick
        On Error Resume Next
        Me.Tag = ""
        Me.Tag = DGridSummary.Item(0, e.RowIndex).Value
        DGridSummary.Tag = DGridSummary.Item(5, e.RowIndex).Value


    End Sub
    Private Sub DGridSummary_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridSummary.DoubleClick
        On Error GoTo skipIt
        If Me.Tag <> "" Then LoadDetails(Me.Tag, DGridSummary.Tag)

        Exit Sub
skipIt:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub

    Private Sub LoadFullDetails(ByVal RefNo As Integer, ByVal theSource As String)
        On Error GoTo errhdl
        If theSource = "" Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        'cnSQL.Open()
        cmSQL.Parameters.Clear()
        Dim str As String = ""
        If theSource = "Sales" Then
            str = "SELECT SalesIndex AS Sn, ProductCode, ProductName, Qty, SellPrice, Details, RefundQty FROM SALESDETAILS WHERE OrderNo=" & RefNo & " ORDER BY SalesIndex"
        ElseIf theSource = "Receipt" Then
            str = "SELECT ReceiptIndex AS Sn, ProductCode, ProductName, Qty, CostPrice, Details, RefundQty FROM RECEIPTDETAILS WHERE OrderNo=" & RefNo & " ORDER BY ReceiptIndex"
        ElseIf theSource = "Refund Inwards" Then
            str = "SELECT 1 AS Sn, ProductCode, ProductName, RefundQty AS Qty, RefundAmt, Details, RefundQty FROM REFUND WHERE RefNo=" & RefNo & " WHERE RefundType='Inwards'"
        ElseIf theSource = "Refund Outwards" Then
            str = "SELECT 1 AS Sn, ProductCode, ProductName, RefundQty AS Qty, RefundAmt, Details, RefundQty FROM REFUND WHERE RefNo=" & RefNo & " WHERE RefundType='Outwards'"
        Else
            Exit Sub
        End If


        cmSQL.CommandText = str
        cmSQL.CommandType = CommandType.Text
        dataAdapterB = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(dataAdapterB)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        dataAdapterB.Fill(table)
        bindingSourceB.DataSource = table

        DGridFullDetails.Columns(2).Width = 120
        DGridFullDetails.Columns(1).Width = 80
        DGridFullDetails.Columns(0).Width = 30
        DGridFullDetails.Columns(3).Width = 40


        Dim myStyle As New DataGridViewCellStyle
        myStyle.Format = "N2"

        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGridFullDetails.Columns(4).DefaultCellStyle = myStyle

        cmSQL.Dispose()
        ' cnSQL.Close()

        PanList.Visible = True

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
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
    Private Sub cmdClosePanList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanList.Click
        PanList.Visible = False
    End Sub

 
End Class