Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Management
Public Class FrmReport
    Dim ReportTitle As String
    Private myReportDocument As ReportDocument
    Dim RptCondition, RptTitle As String
    Public ReturnCode As String
    Dim RptFilename As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim justLoading As Boolean = False
    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo handler
        CloseFrm("FrmReport")

        AppHeader1.lblForm.Text = "Standard Reports"
        Me.BackColor = MainTheme
        LoadReports()

        lvList1.BackColor = MainTheme
        lvList.BackColor = MainTheme

        dtpStartDate.Text = Now
        cSize.SelectedIndex = 0
        cOrientation.SelectedIndex = 0

        lvList.Items(0).Selected = True
        lvList_Click(sender, e)

        ReportTitle = "Stock Inventory"
        justLoading = True
        FillClient()
        FillStockItem()
        FillStockCategory()
        FillStore()
        justLoading = False

        LoadPrinters()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub LoadReports()
        lvList.Items.Clear()

        Dim LvItems As New ListViewItem

        'Stocks
        LvItems = New ListViewItem("Stock Inventory")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Inventory Valuation")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Item List")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Reorder List")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Price List")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Category List")
        LvItems.Group = lvList.Groups.Item(0)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        'Stock Transactions
        LvItems = New ListViewItem("Sales Transactions")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales Transactions (with Profit)")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales Transactions (by Category)")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales Transactions (by Sales Rep.)")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales Transactions (by Customer)")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Restock Transactions")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Refunds Inwards")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Refunds Outwards")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Adjustments")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Transfers - IN")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Stock Transfers - OUT")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("StockItem Transaction History")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("StockItem Transaction History (Summary)")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales by Staff/Agent")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales Chart")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Sales with disparity Price")
        LvItems.Group = lvList.Groups.Item(1)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        'Documents
        LvItems = New ListViewItem("Client Balances")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Debtors Notification")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})
    
        LvItems = New ListViewItem("Client Transaction History (Details)")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Client Transaction History (Summary)")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})



        LvItems = New ListViewItem("Sales Invoice")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Payment Receipt")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Expenditure Voucher")
        LvItems.Group = lvList.Groups.Item(2)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        'Setup

        LvItems = New ListViewItem("Chart of Account")
        LvItems.Group = lvList.Groups.Item(3)
        lvList.Items.AddRange(New ListViewItem() {LvItems})


        LvItems = New ListViewItem("Client Register")
        LvItems.Group = lvList.Groups.Item(3)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Staff List")
        LvItems.Group = lvList.Groups.Item(3)
        lvList.Items.AddRange(New ListViewItem() {LvItems})

        'Financials

        LvItems = New ListViewItem("Payments Inwards")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Payments Outwards")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Office Expenditures")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Office Expenditures (Summary)")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})


        LvItems = New ListViewItem("Office Income")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Journal List")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Transaction Summary")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Uncleared Cheques")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Undeposited/hanging Cheques")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Tax")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Discounts")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Cash Book")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Cash Book (Summary)")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})


        LvItems = New ListViewItem("Trial Balance")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})


        LvItems = New ListViewItem("Trial Balance (Control Account)")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

        LvItems = New ListViewItem("Profit and Lost")
        LvItems.Group = lvList1.Groups.Item(0)
        lvList1.Items.AddRange(New ListViewItem() {LvItems})

    End Sub

    Private Sub lvList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.Click
        On Error Resume Next
        ReportTitle = lvList.SelectedItems(0).Text
        lblRetTitle.Text = lvList.SelectedItems(0).Text
        SetCriteriaSource()
    End Sub

    Private Sub lvList1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList1.Click
        On Error Resume Next
        ReportTitle = lvList1.SelectedItems(0).Text
        lblRetTitle.Text = lvList1.SelectedItems(0).Text
        SetCriteriaSource()
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        On Error Resume Next
        ReportTitle = lvList.SelectedItems(0).Text
        lblRetTitle.Text = lvList.SelectedItems(0).Text
        SetCriteriaSource()
        cmdOk_Click(sender, e)
    End Sub
    Private Sub lvList1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList1.DoubleClick
        On Error Resume Next
        ReportTitle = lvList1.SelectedItems(0).Text
        lblRetTitle.Text = lvList1.SelectedItems(0).Text
        SetCriteriaSource()
        cmdOk_Click(sender, e)
    End Sub
    Private Sub lvList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvList.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then
            ReportTitle = lvList.SelectedItems(0).Text
            lblRetTitle.Text = lvList.SelectedItems(0).Text
            SetCriteriaSource()
        End If
    End Sub

    Private Sub lvList1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvList1.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then
            ReportTitle = lvList1.SelectedItems(0).Text
            lblRetTitle.Text = lvList1.SelectedItems(0).Text
            SetCriteriaSource()
        End If
    End Sub
    Private Sub SetCriteriaSource()

        lblStart.ForeColor = Color.Black
        lblEnd.ForeColor = Color.Black
        lblStockItem.ForeColor = Color.Black
        lblClient.ForeColor = Color.Black
        lblRefNo.ForeColor = Color.Black
        lblCategory.ForeColor = Color.Black
        lblStore.ForeColor = Color.Black
        tRefNo.Text = ""
        lblAcct.ForeColor = Color.Black
        Select Case ReportTitle

            Case Is = "Stock Inventory"
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Stock Inventory Valuation"
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Stock Item List"
                lblCategory.ForeColor = Color.Red
            Case Is = "Stock Reorder List"
            Case Is = "Stock Price List"
            Case Is = "Stock Category List"
                lblCategory.ForeColor = Color.Red
                'Stock Transactions
            Case Is = "Sales Transactions", "Sales Transactions (with Profit)", "Sales Transactions (by Category)", "Sales Transactions (by Sales Rep.)", "Sales Transactions (by Customer)"
                lblStore.ForeColor = Color.Red
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Restock Transactions"
                lblStart.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Refunds Inwards"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Refunds Outwards"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Adjustments"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Stock Transfers - IN", "Stock Transfers - OUT"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red

            Case Is = "StockItem Transaction History"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStockItem.ForeColor = Color.Red
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "StockItem Transaction History (Summary)"
                lblStart.ForeColor = Color.Red
                'lblEnd.ForeColor = Color.Red
                lblStockItem.ForeColor = Color.Red
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red
            Case Is = "Sales with disparity Price"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red

            Case Is = "Sales by Staff/Agent"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red

            Case Is = "Sales Chart"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblCategory.ForeColor = Color.Red
                lblStore.ForeColor = Color.Red


                'Documents
            Case Is = "Client Balances"
                lblClient.ForeColor = Color.Red
            Case Is = "Debtors Notification"
                lblClient.ForeColor = Color.Red
            Case Is = "Client Transaction History (Details)"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblClient.ForeColor = Color.Red
            Case Is = "Client Transaction History (Summary)"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblClient.ForeColor = Color.Red
            Case Is = "Sales Invoice"
                lblRefNo.ForeColor = Color.Red
            Case Is = "Payment Receipt"
                lblRefNo.ForeColor = Color.Red
            Case Is = "Expenditure Voucher"
                lblRefNo.ForeColor = Color.Red

                'Setup
            Case Is = "Chart of Account"
            Case Is = "Client Register"
            Case Is = "Staff List"

                'Financials
            Case Is = "Payments Inwards"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblClient.ForeColor = Color.Red
            Case Is = "Payments Outwards"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblClient.ForeColor = Color.Red
            Case Is = "Office Expenditures"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblAcct.ForeColor = Color.Red
            Case Is = "Office Expenditures (Summary)"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
                lblAcct.ForeColor = Color.Red
            Case Is = "Office Income"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Journal List"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Transaction Summary"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Bank Deposits"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Bank Withdrawals"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Uncleared Cheques"
            Case Is = "Undeposited/hanging Cheques"
            Case Is = "Tax"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Discounts"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Cash Book", "Cash Book (Summary)"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Profit and Lost"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Trial Balance"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Trial Balance (Control Account)"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
            Case Is = "Balance Sheet"
                lblStart.ForeColor = Color.Red
                lblEnd.ForeColor = Color.Red
        End Select
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        Dim SelFormular As String = ""
        Dim tStartDate As String = IIf(dtpStartDate.Checked = False, "", "Date(" & Year(dtpStartDate.Value) & "," & Month(dtpStartDate.Value) & "," & Microsoft.VisualBasic.DateAndTime.Day(dtpStartDate.Value) & ")")
        Dim tEndDate As String = IIf(dtpEndDate.Checked = False, "", "Date(" & Year(dtpEndDate.Value) & "," & Month(dtpEndDate.Value) & "," & Microsoft.VisualBasic.DateAndTime.Day(dtpEndDate.Value) & ")")
        RptFilename = Nothing
        RptCondition = ""
        If ReportTitle = "" Then
            MsgBox("Pls. Select a Report")
            Exit Sub
        End If

        If ReportTitle = "Sales Transactions (with Profit)" Then
            If GetUserReportAccess("Sales Transactions") = False Then Exit Sub
        ElseIf ReportTitle = "Office Expenditures (Summary)" Then
            If GetUserReportAccess("Office Expenditures") = False Then Exit Sub
        ElseIf ReportTitle = "StockItem Transaction History (Summary)" Then
            If GetUserReportAccess("StockItem Transaction History") = False Then Exit Sub
        ElseIf ReportTitle = "Sales Transactions (by Sales Rep.)" Then
            If GetUserReportAccess("Sales Transactions") = False Then Exit Sub
        ElseIf ReportTitle = "Sales Transactions (by Customer)" Then
            If GetUserReportAccess("Sales Transactions") = False Then Exit Sub
        ElseIf ReportTitle = "Sales Transactions (by Category)" Then
            If GetUserReportAccess("Sales Transactions") = False Then Exit Sub
        ElseIf ReportTitle = "Cash Book (Summary)" Then
            If GetUserReportAccess("Cash Book") = False Then Exit Sub
        ElseIf ReportTitle = "Stock Transfers - IN" Then
            If GetUserReportAccess("Adjustments") = False Then Exit Sub
        ElseIf ReportTitle = "Stock Transfers - OUT" Then
            If GetUserReportAccess("Adjustments") = False Then Exit Sub
        Else
            If GetUserReportAccess(ReportTitle) = False Then Exit Sub
        End If

        Select Case ReportTitle
            Case Is = "Stock Inventory"
                RptFilename = New StockInv
                SelFormular = "{RptStoreItemsWithQty.Qty}<>0 AND {RptStoreItemsWithQty.TransType}='Retail'"
                If UCase(Trim(cCategory.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Category}='" & cCategory.Text & "'"
                End If
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Store}='" & cStore.Text & "'"
                End If

            Case Is = "Stock Inventory Valuation"
                RptFilename = New StockVal
                SelFormular = "{RptStoreItemsWithQty.Qty}<>0 AND {RptStoreItemsWithQty.TransType}='Retail'"
                If UCase(Trim(cCategory.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Category}='" & cCategory.Text & "'"
                End If
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Store}='" & cStore.Text & "'"
                End If

            Case Is = "Stock Item List"
                RptFilename = New StockList
            Case Is = "Stock Reorder List"
                RptFilename = New StockReorder
            Case Is = "Stock Price List"
                RptFilename = New PriceList
                If UCase(Trim(cCategory.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Category}='" & cCategory.Text & "'"
                End If
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItemsWithQty.Store}='" & cStore.Text & "'"
                End If
            Case Is = "Stock Category List"
                RptFilename = New Category

                'Stock Transactions
            Case Is = "Sales Transactions"
                RptFilename = New SalesList
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}<=" & tEndDate

                If cStore.Text <> "" Then
                    ' RptFilename.Subreports(0).RecordSelectionFormula = "{RptSales.OrderNo} = {?Pm-RptSalesParticulars.OrderNo} AND {RptSales.Store}='" & cStore.Text & "'"
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.SalesStore} LIKE '*" & cStore.Text & "*'"
                End If

            Case Is = "Sales Transactions (with Profit)"
                RptFilename = New SalesListWithProfit
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    ' RptFilename.Subreports(0).RecordSelectionFormula = "{RptSales.OrderNo} = {?Pm-RptSalesParticulars.OrderNo} AND {RptSales.Store}='" & cStore.Text & "'"
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.SalesStore} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Sales Transactions (by Category)"
                RptFilename = New SalesByCategory
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Store} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Sales Transactions (by Sales Rep.)"
                RptFilename = New SalesListBySalesRep
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    ' RptFilename.Subreports(0).RecordSelectionFormula = "{RptSales.OrderNo} = {?Pm-RptSalesParticulars.OrderNo} AND {RptSales.Store}='" & cStore.Text & "'"
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.SalesStore} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Sales Transactions (by Customer)"
                RptFilename = New SalesListByCustomer
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    ' RptFilename.Subreports(0).RecordSelectionFormula = "{RptSales.OrderNo} = {?Pm-RptSalesParticulars.OrderNo} AND {RptSales.Store}='" & cStore.Text & "'"
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesParticulars.SalesStore} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Restock Transactions"
                RptFilename = New ReceiptList
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptReceiptParticulars.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptReceiptParticulars.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    ' RptFilename.Subreports(0).RecordSelectionFormula = "{RptSales.OrderNo} = {?Pm-RptReceiptParticulars.OrderNo} AND {RptReceipt.Store}='" & cStore.Text & "'"
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptReceiptParticulars.ReceiptStore} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Refunds Inwards"
                RptFilename = New Refund
                SelFormular = "{RptRefunds.RefundType}='Inwards'"
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Store} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Refunds Outwards"
                RptFilename = New Refund
                SelFormular = "{RptRefunds.RefundType}='Outwards'"
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptRefunds.Store} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Adjustments"
                RptFilename = New Adjustments
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptAdjustment.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptAdjustment.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptAdjustment.Store} LIKE '*" & cStore.Text & "*'"
                End If

            Case Is = "Stock Transfers - OUT"
                RptFilename = New StockTransfersOUT
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.SourceStore} LIKE '*" & cStore.Text & "*'"
                End If

            Case Is = "Stock Transfers - IN"
                RptFilename = New StockTransfersIN
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.DestinationStore} LIKE '*" & cStore.Text & "*'"
                End If

            Case Is = "StockItem Transaction History"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New StockTransHistory
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.Date}<=" & tEndDate

                If UCase(Trim(cProduct.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.ProductCode}='" & GetIt4Me(cProduct.Text, " - ") & "'"
                Else
                    If UCase(Trim(cCategory.Text)) <> "ALL" Then
                        SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItems.Category}='" & cCategory.Text & "'"
                    End If
                End If
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.Store} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "StockItem Transaction History (Summary)"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New StockTransHistorySum
                'If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransSummary.Date}>=" & tStartDate
                'If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransSummary.Date}<=" & tEndDate

                If UCase(Trim(cProduct.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.ProductCode}='" & GetIt4Me(cProduct.Text, " - ") & "'"
                Else
                    If UCase(Trim(cCategory.Text)) <> "ALL" Then
                        SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStoreItems.Category}='" & cCategory.Text & "'"
                    End If
                End If
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockItemTransactionHistory.Store} LIKE '*" & cStore.Text & "*'"
                End If
            Case Is = "Sales with disparity Price"
                RptFilename = New SalesDiff
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}<=" & tEndDate
                If cStore.Text <> "" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Store} LIKE '*" & cStore.Text & "*'"
                End If

            Case Is = "Sales by Staff/Agent"
                RptFilename = New SalesByAgent
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Date}<=" & tEndDate
                If UCase(Trim(cCategory.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSales.Category}='" & cCategory.Text & "'"
                End If

            Case Is = "Sales Chart"
                RptFilename = New SalesChart
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesGraph.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesGraph.Date}<=" & tEndDate
                If UCase(Trim(cCategory.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptSalesGraph.CategoryCode}='" & GetIt4Me(cCategory.Text, " - ") & "'"
                End If

                'Documents
            Case Is = "Client Balances"
                RptFilename = New ClientBalances
                If UCase(Trim(cClient.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientBalances.CustomerCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                End If
            Case Is = "Debtors Notification"
                'RptFilename = New ClientBalances
                'SelFormular = "{RptClientBalances.Balance}<0"
                'If UCase(Trim(cCategory.Text)) <> "ALL" Then
                '    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientBalances.CustomerCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                'End If
                MsgBox("Ok..design to user organisation spec.", MsgBoxStyle.Information, strApptitle)

            Case Is = "Client Transaction History (Details)"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New ClientXtransD
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientTransactionDetails.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientTransactionDetails.Date}<=" & tEndDate

                If UCase(Trim(cClient.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientTransactionDetails.ClientCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                End If
            Case Is = "Client Transaction History (Summary)"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New ClientXtransS
                SelFormular = "{RptClientStatementOfAccount.CustomerCode}<>''"
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientStatementOfAccount.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientStatementOfAccount.Date}<=" & tEndDate

                If UCase(Trim(cClient.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptClientStatementOfAccount.CustomerCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                End If

            Case Is = "Sales Invoice"
                If Len(Trim(tRefNo.Text)) = 0 Then
                    MsgBox("Enter OrderNo", vbInformation, strApptitle)
                    tRefNo.Focus()
                    Exit Sub
                End If
                RptFilename = New ReportDocument
                RptFilename.Load(AppPath + "ConfigDir\Invoice.rpt")

                SelFormular = "{RptSales.OrderNo}=" & Val(tRefNo.Text)

            Case Is = "Payment Receipt"
                If Len(Trim(tRefNo.Text)) = 0 Then
                    MsgBox("Enter OrderNo", vbInformation, strApptitle)
                    tRefNo.Focus()
                    Exit Sub
                End If
                RptFilename = New ReportDocument
                RptFilename.Load(AppPath + "ConfigDir\Receipt.rpt")
                SelFormular = "{RptPayments.PaymentTag}='" & tRefNo.Text & "' AND {RptPayments.PayType}='Receiveable'"
            Case Is = "Expenditure Voucher"
                On Error Resume Next
                If GetUserReportAccess("Expenditure Voucher") = False Then Exit Sub
                If Len(Trim(tRefNo.Text)) = 0 Then
                    MsgBox("Enter Expenditure VoucherNo/RefNo", vbInformation, strApptitle)
                    tRefNo.Focus()
                    Exit Sub
                End If
                RptFilename = New ExpensesVoucher
                SelFormular = "{AC_RptExpenseVoucher.PVNo}='" & Trim(tRefNo.Text) & "'"

                'Setup
            Case Is = "Chart of Account"
                RptFilename = New AccountChart
            Case Is = "Client Register"
                RptFilename = New ClientList

                'Financials
            Case Is = "Payments Inwards"
                RptFilename = New Payments
                SelFormular = "{RptPayments.PayType}='Receiveable'"
                If UCase(Trim(cClient.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.ClientCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                End If
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.Date}<=" & tEndDate
            Case Is = "Payments Outwards"
                RptFilename = New Payments
                SelFormular = "{RptPayments.PayType}='Payable'"
                If UCase(Trim(cClient.Text)) <> "ALL" Then
                    SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.ClientCode}='" & Trim(GetIt4Me(cClient.Text, " - ")) & "'"
                End If
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptPayments.Date}<=" & tEndDate
                If tAcct.Text <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptAccountChartHeader.Code}<='" & tAcct.Text & "'"
            Case Is = "Office Expenditures"
                RptFilename = New Expenditure
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptExpenseVoucher.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptExpenseVoucher.Date}<=" & tEndDate
                If tAcct.Text <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptExpenseVoucher.Code}<='" & tAcct.Text & "'"
            Case Is = "Office Expenditures (Summary)"
                RptFilename = New ExpenditureSum
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptExpenseVoucher.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptExpenseVoucher.Date}<=" & tEndDate

            Case Is = "Office Income"
                RptFilename = New Income
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptIncome.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptIncome.Date}<=" & tEndDate
            Case Is = "Journal List"
                RptFilename = New Journal
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptJournal.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{AC_RptJournal.Date}<=" & tEndDate

            Case Is = "Transaction Summary"
                RptFilename = New TransactionSum
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttransaction.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttransaction.Date}<=" & tEndDate
                RptFilename.DataDefinition.FormulaFields("ReportCondition").Text = "'TRANSACTION SUMMARY BTW " + dtpStartDate.Text & " AND " + dtpEndDate.Text + "'"

            Case Is = "Uncleared Cheques"
                RptFilename = New UnclearedCheque
                SelFormular = "{RptUnclearedCheques.Deposit}=0"
            Case Is = "Undeposited/hanging Cheques"
                RptFilename = New UnclearedCheque
                SelFormular = "{RptUnclearedCheques.Deposit}=1"
            Case Is = "Tax"
                RptFilename = New Tax
                SelFormular = "{RptVatDiscount.VAT}<>0"
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptVatDiscount.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptVatDiscount.Date}<=" & tEndDate
            Case Is = "Discounts"
                RptFilename = New Discounts
                SelFormular = "{RptVatDiscount.Discount}<>0"
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptVatDiscount.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptVatDiscount.Date}<=" & tEndDate
            Case Is = "Cash Book", "Cash Book (Summary)"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()
                If ReportTitle = "Cash Book" Then
                    RptFilename = New CashBook
                Else
                    RptFilename = New CashBookSummary
                End If

                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptCashBook.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptCashBook.Date}<=" & tEndDate
            Case Is = "Profit and Lost"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New IncomeStmt
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rptincomestmt.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rptincomestmt.Date}<=" & tEndDate
            Case Is = "Trial Balance"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New TrialBalance
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttrialbalance.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttrialbalance.Date}<=" & tEndDate
            Case Is = "Trial Balance (Control Account)"
                'cnSQL.Open()
                cmSQL.CommandText = "Update SystemParameters Set TempDate='" & formatDate(dtpStartDate) & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                'cnSQL.Close()
                'cnSQL.Dispose()

                RptFilename = New TrialBalanceHeader
                If tStartDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttrialbalance.Date}>=" & tStartDate
                If tEndDate <> "" Then SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{ac_rpttrialbalance.Date}<=" & tEndDate
        End Select

        If RptFilename Is Nothing Then
            MsgBox("Please select a report", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        Dim ChildForm As New FrmRptDisplay
        ChildForm.PaperSize = cSize.Text
        ChildForm.POrientation = cOrientation.Text
        'ChildForm.PrinterName = cboLocalPrinters.Text
        ChildForm.RptTitle = ReportTitle



        If SelFormular <> "" Then ChildForm.SelFormula = SelFormular
        If RptTitle <> "" Then RptFilename.DataDefinition.FormulaFields("Title").Text = "'" + RptTitle + "'"
        'ChildForm.MdiParent = FrmStart
        If ChkDisplay.Checked Then
            ChildForm.RptDestination = "Screen"
        Else
            ChildForm.RptDestination = "Printer"
        End If

        ChildForm.myReportDocument = RptFilename

        'RptFilename.DataDefinition.FormulaFields("ReportCondition").Text = "'" + RptCondition + "'"
        ChildForm.ShowDialog()
        'ChildForm.myReportDocument = RptFilename

        'RptFilename.SetParameterValue(0, 1) ' to pass parameter

        SelFormular = ""
        RptCondition = ""
        RptTitle = ""
        RptFilename.Close()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub ConfigureCrystalReports(ByVal myReportDocument As ReportDocument)
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

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)


    End Sub
    Private Sub FillClient()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandText = "FetchAllClient"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        cClient.Items.Add("ALL")
        Do While drSQL.Read
            cClient.Items.Add(drSQL.Item("ID") + " - " + drSQL.Item("Name"))
        Loop
        drSQL.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        cClient.SelectedIndex = 0
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub FillStockItem(Optional ByVal byCategory As String = "")
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If byCategory <> "" And UCase(Trim(byCategory)) <> "ALL" Then
            cmSQL.CommandText = "SELECT * FROM STOREITEMS WHERE Category='" & byCategory & "' ORDER BY ProductName"
        Else
            cmSQL.CommandText = "SELECT * FROM STOREITEMS ORDER BY ProductName"
        End If

        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        cProduct.Items.Clear()
        drSQL = cmSQL.ExecuteReader()
        cProduct.Items.Add("ALL")
        Do While drSQL.Read
            cProduct.Items.Add(drSQL.Item("ProductCode") + " - " + drSQL.Item("ProductName"))
        Loop
        cProduct.SelectedIndex = 0
        drSQL.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub FillStockCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim tPrevCode As String = ""
        cmSQL.CommandText = "SELECT DISTINCT Category FROM STOREITEMS ORDER BY Category"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        cCategory.Items.Add("ALL")
        Do While drSQL.Read
            If tPrevCode = drSQL.Item("Category") Then
            Else
                cCategory.Items.Add(drSQL.Item("Category"))
                tPrevCode = drSQL.Item("Category")
            End If
        Loop
        cCategory.SelectedIndex = 0
        drSQL.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged
        lvList_Click(sender, e)
    End Sub

    Private Sub lvList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList1.SelectedIndexChanged
        lvList1_Click(sender, e)
    End Sub

    Private Sub cmdPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrinter.Click
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub cmdAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccount.Click
        On Error GoTo errhdl
        If Not (ReportTitle = "Office Expenditures (Summary)" Or ReportTitle = "Office Expenditures") Then Exit Sub
        Dim strCaption(4) As String
        Dim intWidth(4) As Integer
        strCaption(0) = "Account Code"
        intWidth(0) = 100
        strCaption(1) = "Account Name"
        intWidth(1) = 200
        strCaption(2) = "Acct. Type"
        intWidth(2) = 100
        strCaption(3) = "Outline"
        intWidth(3) = 0

        With FrmList
            .frmParent = Me
            If ReportTitle = "Office Expenditures (Summary)" Or ReportTitle = "Office Expenditures" Then
                .tSelection = "ControlAccount"
                '    .LoadLvList(strCaption, intWidth, "ControlAccount")
            Else
                .tSelection = "Account4Journal"
                '   .LoadLvList(strCaption, intWidth, "Account4Journal")
            End If
            .Text = "List of Control Account"
            .ShowDialog()
        End With
        tAcct.Text = ReturnCode
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub cCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cCategory.SelectedIndexChanged
        If justLoading = False Then FillStockItem(GetIt4Me(cCategory.Text, " - "))
    End Sub

    Private Sub FillStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cStore.Items.Clear()

        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT Store FROM AssignedStore WHERE UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
            cStore.Items.Add("")
        End If

        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cStore.Items.Add(drSQL.Item("Store").ToString)
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        On Error Resume Next
        cStore.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub

    Private Sub FrmReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub LoadPrinters()
        On Error GoTo handler
        'Let's clear our comboboxes to start fresh.

        cboLocalPrinters.Items.Clear()
        cboLocalPrinters.Items.Add("")

        'We use the ObjectQuery to get the list of configured printers
        Dim oquery As New System.Management.ObjectQuery("SELECT * FROM Win32_Printer")
        Dim mosearcher As New System.Management.ManagementObjectSearcher(oquery)
        Dim moc As System.Management.ManagementObjectCollection = mosearcher.[Get]()

        'If at least one printer is found, we add it to a specific list and enable the Print button.
        If moc IsNot Nothing AndAlso moc.Count > 0 Then
            'For each printer found, we put it either in the local or network combobox, accordingly.
            For Each mo As ManagementObject In moc
                Dim network As Boolean = False
                Dim ipAddress As String() = mo("PortName").ToString().Split("."c)

                'It's a network printer.
                If mo("PortName") IsNot Nothing AndAlso ipAddress.Length = 4 Then
                    cboLocalPrinters.Items.Add(mo("Name").ToString())
                    network = True
                Else
                    'It's a local printer.
                    cboLocalPrinters.Items.Add(mo("Name").ToString())
                End If

                'If the printer is found to be the default one, we select it.
                If CBool(mo("Default")) Then
                    If network Then
                        cboLocalPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = True
                    Else
                        cboLocalPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = False
                    End If

                 
                End If
            Next



        End If
        Exit Sub
handler:
        MsgBox("Problem Loading Default Printer", vbInformation, strApptitle)
    End Sub
End Class