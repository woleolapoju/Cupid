Imports System
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Management
Public Class stkFrmTransfer
    Public ReturnCode As String = ""
    Dim Action As AppAction
    Dim chkProduct As Boolean = True
    Public ReturnOrderNo As Integer
    Public ReturnItemCode As String
    Public LastOrderNo As Integer = 0
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Dim StoredX As Long
    Dim StoredY As Long
    Dim Minimize_Size As Long
    Dim skipLostFocus As Boolean
    Dim SelectedStore As String
    Dim DoNotMoveNext As Boolean = False
    Dim SkipRowEnter As Boolean = False
    Private defaultNetwork As Boolean
    Private Sub stkFrmProformal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On Error Resume Next
        AppHeader1.lblForm.Text = "Stock Transfer"
        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        lvCategory.BackColor = MainTheme
        lvProduct.BackColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        tOrderNo.BackColor = MainTheme
        tCategoryName.BackColor = MainTheme
        tItemDesc.BackColor = MainTheme
        tStockLevel.BackColor = MainTheme
        tTotalValue.BackColor = MainTheme
        Panel7.BackColor = HeaderTheme
        Panel4.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        PanList.BackColor = HeaderTheme
        cStore.BackColor = HeaderTheme
        DGridItems.BackgroundColor = MainTheme
        DGridItems.AlternatingRowsDefaultCellStyle = myStyleGridAlternate


        DGrid.DataSource = bindingSource


        FillDestinationStore()
        FillStore()

        LoadPrinters()
        If defaultNetwork Then
            radioNetworkPrinters.Checked = True
        Else
            radioLocalPrinters.Checked = True
        End If

        dtpDate.Value = Now
        cmdNew.Enabled = ModuleAdd

        Action = AppAction.Add

        'GetUserAccessDetails("Stockitem Register")
        'cmdNewItem.Enabled = ModuleAdd

        'oLoadCategory()

        PanPrinter.Location = New Point(784, 49)

    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()
        lvProduct.Items.Clear()

        'cmSQL.CommandText = "SELECT DISTINCT Category FROM STOREITEMS WHERE Discontinue=0 ORDER BY Category"

        cmSQL.CommandText = "SELECT DISTINCT Category FROM STOCKQTY INNER JOIN STOREITEMS ON STOCKQTY.ProductCode = STOREITEMS.ProductCode WHERE ((Qty>0 AND   STOREITEMS.TransType='Retail') OR   STOREITEMS.TransType='Service') AND STOCKQTY.Discontinue=0 AND STOCKQTY.Store='" & cStore.Text & "' ORDER BY Category"

        cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        LvItems = New ListViewItem("<ALL>")
        LvItems.SubItems.Add("")
        lvCategory.Items.AddRange(New ListViewItem() {LvItems})
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("Category").ToString)
            lvCategory.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub oLoadProduct(ByVal TheCat As String)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvProduct.Items.Clear()

        cmSQL.CommandText = "FetchAllActiveAvailableStoreItemsPerCategoryPerStore"
        cmSQL.Parameters.AddWithValue("@Category", IIf(TheCat = "<ALL>", "*", TheCat))
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("ProductCode").ToString)
            LvItems.SubItems.Add(drSQL.Item("ProductName").ToString)
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            lvProduct.Items.AddRange(New ListViewItem() {LvItems})
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub lvCategory_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCategory.ColumnClick
        On Error GoTo handler
        lvCategory.ListViewItemSorter = New ListViewItemComparer(e.Column)

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub lvCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCategory.SelectedIndexChanged
        On Error Resume Next
        tCategoryName.Text = lvCategory.SelectedItems(0).Text
        tCategoryName.Tag = lvCategory.SelectedItems(0).Text
        oLoadProduct(lvCategory.SelectedItems(0).Text)
    End Sub
    Private Sub lvProduct_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvProduct.ColumnClick
        On Error GoTo handler
        lvProduct.ListViewItemSorter = New ListViewItemComparer(e.Column)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Function GetProductByCode(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        GetProductByCode = False

        ' tProductName.Text = ""
        '  tCategoryName.Text = ""
        ' tCategoryName.Tag = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0
        tItemCode.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tStockLevel.Tag = 0

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductCodePerStore"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found....", vbInformation, strApptitle)
            GetProductByCode = False
            tItemCode.Focus()
            'tProductName.Focus()
            cmSQL.Dispose()
            drSQL.Close()
            Exit Function
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("Category")
                tItemCode.Tag = drSQL.Item("TransType")
                tCategoryName.Tag = drSQL.Item("Category")
                tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))

                tStockLevel.Tag = drSQL.Item("MaxQty")

            End If
            GetProductByCode = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        GetProductDetails(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If

    End Function
    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        cmdSave.Enabled = True
        cmdNew.Enabled = False
        FetchNextNo()
        'tItemCode.Focus()
        tProductName.Focus()
        cStore.Enabled = False
    End Sub

    Private Function FetchNextNo() As Integer
        On Error GoTo errhdl
        FetchNextNo = 0
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewStockTransferRefNo"
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then If drSQL.Read Then tOrderNo.Text = drSQL.Item("NewNo")
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub lvProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProduct.SelectedIndexChanged
        'On Error Resume Next
        'chkProduct = False
        'GetProductByCode(lvProduct.SelectedItems(0).Text)
        'chkProduct = True
    End Sub
    Private Sub lvProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProduct.Click
        On Error Resume Next
        chkProduct = False
        GetProductByCode(lvProduct.SelectedItems(0).Text)
        chkProduct = True
    End Sub
    Private Sub tItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tItemCode.KeyPress
        If e.KeyChar = Chr(13) Then
            If GetProductByCode(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
        End If
    End Sub

    Private Sub tItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tItemCode.LostFocus
        On Error GoTo handler
        If tItemCode.Text = "" Then Exit Sub
        If GetProductByCode(tItemCode.Text) = False Then
            tItemCode.Focus()
        Else
            tQty.Focus()
        End If
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub flush()
        dtpDate.Value = Now
        ReturnOrderNo = 0
        tOrderNo.Text = ""
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0

        tDetails.Text = ""
        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()
        cCostPrice.Tag = 0
        tItemCode.Focus()



        DGridItems.Rows.Clear()
        DoNotExist = False

        tSourceDoc.Text = ""

        tTotalValue.Text = 0

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0
        tStockLevel.Text = 0
        tDetails.Text = ""

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()
        tItemCode.Focus()

    End Sub

    Private Sub tQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tQty.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)
        If Val(tStockLevel.Tag) <= 0 Or Val(tQty.Text) = 0 Then Exit Sub
    End Sub
    Private Sub tStockLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tStockLevel.TextChanged
        'If Val(tStockLevel.Text) < 0 Then
        '    MsgBox("Purchase Quantity greater than Stock Level", MsgBoxStyle.Information, strApptitle)
        '    tQty.Text = 1
        'End If
        If Val(tStockLevel.Text) > Val(tStockLevel.Tag) And Val(tStockLevel.Tag) > 0 Then MsgBox("Stock Level exceeds Max. Level allowed", MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Function ProductAreadyInList(ByVal ProductCode As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To DGridItems.RowCount - 1
            If DGridItems.Rows(i).Cells(0).Value = ProductCode Then
                ProductAreadyInList = i 'Exist but should be added to existing
                Exit Function
                'Else
                '    ProductAreadyInList = -2
            End If
        Next i
        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function
    Private Sub cmdAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccept.Click
        On Error GoTo handler
        If cmdSave.Enabled = False Then Exit Sub
        If tQty.Text = "" Then Exit Sub
        If IsNumeric(tSellPrice.Text) = False Or IsNumeric(tCostPrice.Text) = False Or IsNumeric(tQty.Text) = False Then
            MsgBox("Quantity,Selling Price and Cost Price must be numeric", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tCostPrice.Text) > Val(tCostPrice.Tag) And Val(tCostPrice.Tag) <> 0 Then
            If MsgBox("New Costprice is above prevailing costprice" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If Val(tQty.Text) < 0 Then
            MsgBox("Quantity must be positive", vbInformation, strApptitle)
            Exit Sub
        End If
        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Or Val(tQty.Text) = 0 Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If
        'If cBatchNo.Text = "" Then
        '    MsgBox("Batch No is required", MsgBoxStyle.Information, strApptitle)
        '    Exit Sub
        'End If
        Dim j As Integer = 0
        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text)
        If PositionInList >= 0 Then
            DGridItems.Rows(PositionInList).Cells(2).Value = CDbl(DGridItems.Rows(PositionInList).Cells(2).Value) + 1
        Else
            j = DGridItems.RowCount
            ' If j < 0 Then j = 0
            DGridItems.Rows.Add()
            DGridItems.Rows(j).Cells(0).Value = tItemCode.Text
            DGridItems.Rows(j).Cells(1).Value = tProductName.Text
            DGridItems.Rows(j).Cells(2).Value = 1
            DGridItems.Rows(j).Cells(3).Value = Format(tSellPrice.Text, "Standard")
            DGridItems.Rows(j).Cells(4).Value = Format(tCostPrice.Text, "Standard")
            DGridItems.Rows(j).Cells(5).Value = tCategoryName.Text
            DGridItems.Rows(j).Cells(6).Value = Format(tSellPrice.Text, "Standard")
            DGridItems.Rows(j).Cells(7).Value = IIf(tItemDesc.Text = "", " ", tItemDesc.Text)
            DGridItems.Rows(j).Cells(8).Value = tItemCode.Tag 'TransType

        End If

        cmdClear_Click(sender, e)

        calculatePayable()


        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub calculatePayable()
        On Error GoTo handler
        Dim i As Integer
        Dim ThePayable As Double = 0
        For i = 0 To DGridItems.RowCount - 1
            ThePayable = ThePayable + (CDbl(DGridItems.Item(2, i).Value) * CDbl(DGridItems.Item(3, i).Value))
        Next
        tTotalValue.Text = Format(Math.Round(ThePayable, 2), "standard")
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        flush()
        DGridItems.Rows.Clear()
        cmdNew.Enabled = True
        cmdSave.Enabled = False
        tItemCode.Focus()
        ReturnOrderNo = 0
        cmdNew.Enabled = ModuleAdd
        Action = ModuleAdd
        cStore.Enabled = True
    End Sub

    Private Sub tSellPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSellPrice.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tDetails.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub lnkItemList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkItemList.LinkClicked
        If lnkItemList.Text Like "Show*" Then
            tblProductListings.Visible = True
            lnkItemList.Text = "Hide Item Listings"
            tblContent.ColumnStyles(0).Width = 50
            tblContent.ColumnStyles(1).Width = 50
            Me.WindowState = FormWindowState.Maximized
            PanList.Top = tProductName.Top + 80 'tDesc.Height
        Else
            tblProductListings.Visible = False
            lnkItemList.Text = "Show Item Listings"
            tblContent.ColumnStyles(0).Width = 0
            tblContent.ColumnStyles(1).Width = 100
            ' Me.Width = Minimize_Size + 20
            Me.WindowState = FormWindowState.Normal
            Me.Width = Minimize_Size + 20
            PanList.Top = tProductName.Top + 80
            PanList.Left = tProductName.Left + 5

            Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

        End If
    End Sub
    Private Sub tProductName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tProductName.KeyDown
        If (e.KeyCode = 38 Or e.KeyCode = 40) And DGrid.RowCount > 0 Then
            skipLostFocus = True
            DGrid.Focus()
            chkProduct = False
            On Error Resume Next
            DGrid.Rows(0).Selected = True
            '  skipLostFocus = False
            'Else
            ' skipLostFocus = False
        Else
            chkProduct = True
            skipLostFocus = False
        End If
        'If e.KeyCode = 13 Then
        '    tCategory.Focus()
        '    PanList.Visible = False
        'End If
    End Sub
    Private Sub tProductName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tProductName.LostFocus
        chkProduct = False

        If tProductName.Text = "" Then Exit Sub
        If skipLostFocus = False Then
            If GetProductByName(tProductName.Text) = False Then
                tProductName.Focus()
            Else
                tQty.Focus()
            End If


            PanList.Visible = False
        End If
    End Sub
    Private Sub tProductName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tProductName.TextChanged
        'If chkProduct = False Then Exit Sub
        'skipLostFocus = True
        'If tProductName.Text <> "" Then
        '    getProductList(tProductName.Text)
        '    PanList.Visible = True
        'Else
        '    PanList.Visible = False
        'End If
        'skipLostFocus = False
    End Sub
    Private Sub tProductName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tProductName.KeyPress
        If e.KeyChar = Chr(13) Then
            chkProduct = False
            If GetProductByName(tProductName.Text) = False Then Exit Sub
            PanList.Visible = False
            cmdAccept_Click(sender, e)
            tProductName.Focus()
        End If
    End Sub
    Sub getProductList(ByVal strQry As String)
        On Error GoTo handler
        If strQry = "" Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        DGrid.DataSource = Nothing
        DGrid.Rows.Clear()
        DGrid.DataSource = bindingSource

        'Dim strQuery As String = ""
        'Dim str1 As String = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc"
        'Dim str2 As String = " FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND StoreItems.TransType='Retail' AND (StoreItems.Discontinue = 0) AND "
        ''cnSQL.Open()
        'If radContaining.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%'"
        'If RadStartWith.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%'"
        'If RadEndWith.Checked Then strQuery = "  ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "'"
        'If RadEqual.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName  = '" + strQry & "'"
        'Dim str As String = "SELECT ProductCode, ProductName, Category,0 AS Qty,0 AS SellPriceNew, 0 AS CostPriceNew,ProductDesc FROM StoreItems WHERE TransType='Retail' AND Discontinue=0 AND " & strQuery & " AND ProductCode NOT IN (SELECT StockQty.ProductCode " & str2 + strQuery & ") UNION " & str1 + str2 + strQuery + " ORDER BY ProductName"

        If radContaining.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "' ORDER BY StoreItems.ProductName"
        If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName  = '" + strQry & "' ORDER BY StoreItems.ProductName"

        'cmSQL.CommandText = str
        cmSQL.CommandType = CommandType.Text

        dataAdapter = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        cmSQL.Dispose()

        DGrid.Columns(1).Width = 200
        DGrid.Columns(3).Width = 40
        DGrid.Columns(4).Width = 80
        DGrid.Columns(5).Width = 80


        Dim myStyle As New DataGridViewCellStyle
        myStyle.Format = "N2"
        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        On Error Resume Next

        DGrid.Columns(4).DefaultCellStyle = myStyle
        DGrid.Columns(5).DefaultCellStyle = myStyle
        DGrid.Rows(0).Selected = True
        ' cnSQL.Close()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Function GetProductByName(ByVal strValue As String) As Boolean
        On Error GoTo errhdl


        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        GetProductByName = False

        ' tProductName.Text = ""
        '  tCategoryName.Text = ""
        '  tCategoryName.Tag = ""
        tItemCode.Text = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tStockLevel.Tag = 0
        tItemCode.Tag = ""
        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(strValue) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductNamePerStore"
        cmSQL.Parameters.AddWithValue("@ProductName", strValue)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found....", vbInformation, strApptitle)
            GetProductByName = False
            tProductName.Focus()
            cmSQL.Dispose()
            drSQL.Close()
            Exit Function
        Else
        If drSQL.Read Then
            tItemCode.Text = drSQL.Item("ProductCode")
            tProductName.Text = drSQL.Item("ProductName")
            tCategoryName.Text = drSQL.Item("Category")
            tItemCode.Tag = drSQL.Item("TransType")
            tCategoryName.Tag = drSQL.Item("Category")

            'tStockLevel.Text = drSQL.Item("UnitInStock")
            'tQty.Tag = drSQL.Item("Qty")
            'tQty.Text = 1
            'tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
            'tQty.Minimum = 1
            'tQty.Maximum = Val(tQty.Tag)

            tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))

            'tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
            'tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

            'If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
            '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
            '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
            '    cFixedPrice.SelectedIndex = 0
            'Else
            '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
            '    cFixedPrice.SelectedIndex = 0
            'End If


            'If drSQL.Item("CostPriceNew") <> drSQL.Item("CostPriceOld") Then
            '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
            '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
            '    cCostPrice.SelectedIndex = 0
            'Else
            '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
            '    cCostPrice.SelectedIndex = 0
            'End If

            'cCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)
        End If
        GetProductByName = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        GetProductDetails(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Function
    Private Sub GetProductDetails(ByVal ProductCode As String)
        On Error GoTo errhdl

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader


        tQty.Tag = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tStockLevel.Tag = 0

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        tQty.Minimum = 1
        tQty.Maximum = 1000000000


        If Trim(ProductCode) = "" Then Exit Sub

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerStore"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
        Else
            If drSQL.Read Then
                'tItemCode.Text = drSQL.Item("ProductCode")
                'tProductName.Text = drSQL.Item("ProductName")
                'tCategoryName.Text = drSQL.Item("Category")
                'tPack.Text = drSQL.Item("Pack")
                'tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
                ' tStockLevel.Text = drSQL.Item("Qty")

                tQty.Tag = drSQL.Item("Qty")
                tQty.Text = 1
                tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)


                tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                tCostPrice.Text = Math.Round(drSQL.Item("CostPriceNew"), 2)
                tCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)

                If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
                    cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                    cSellPrice.SelectedIndex = 0
                Else
                    cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cSellPrice.SelectedIndex = 0
                End If


                If drSQL.Item("CostPriceNew") <> drSQL.Item("CostPriceOld") Then
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                    cCostPrice.SelectedIndex = 0
                Else
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                    cCostPrice.SelectedIndex = 0
                End If

                cCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)

            End If
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        Dim sender As System.Object = Nothing
        Dim e As System.EventArgs = Nothing


        cmdAccept_Click(sender, e)


        Exit Sub
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Sub
    Private Sub FillDestinationStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim StaffName As String
        cDestinationStore.Items.Clear()
        'cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"


        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE INNER JOIN ASSIGNEDSTORE ON STORE.Store = ASSIGNEDSTORE.Store WHERE ASSIGNEDSTORE.UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE ORDER BY [Default] DESC"
        End If
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cDestinationStore.Items.Add(drSQL.Item("Store").ToString)
            If drSQL.Item("TheDefault") = True Then
                cDestinationStore.Tag = drSQL.Item("Store")
            End If
        Loop

        'cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        'drSQL = cmSQL.ExecuteReader()
        'Do While drSQL.Read
        '    cDestinationStore.Items.Add(drSQL.Item("Store").ToString)
        'Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        On Error Resume Next
        cDestinationStore.SelectedIndex = 1

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub FillStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cStore.Items.Clear()

        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE INNER JOIN ASSIGNEDSTORE ON STORE.Store = ASSIGNEDSTORE.Store WHERE ASSIGNEDSTORE.UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE ORDER BY [Default] DESC"
        End If
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cStore.Items.Add(drSQL.Item("Store").ToString)
            If drSQL.Item("TheDefault") = True Then
                cStore.Tag = drSQL.Item("Store")
            End If
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        cStore.SelectedIndex = 0
        cStore.Text = cStore.Tag
        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub cmdClosePanList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanList.Click
        PanList.Visible = False
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
    Private Sub radContaining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radContaining.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadStartWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadStartWith.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadEndWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEndWith.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadEqual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEqual.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub cmdNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewItem.Click

        ' If GetUserAccessDetails("Stockitem Register") = False Then Exit Sub
        Dim ChildForm As New StkFrmItemRegister
        ChildForm.cboCategory.Tag = tCategoryName.Tag
        ChildForm.frmParent = Me
        ChildForm.oneTime = True
        ChildForm.Action1 = "Add"
        ChildForm.ShowDialog()
        GetProductByCode(ReturnItemCode)

    End Sub
    Private Sub lnkSearchProduct_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSearchProduct.LinkClicked
        skipLostFocus = True
        DoNotMoveNext = False
        tSearchName.Text = ""
        PanList.Visible = True
        tSearchName.Focus()
    End Sub
    Private Sub PrintTheInvoice() 'Optional LPT As String = "LPT1")
        On Error GoTo errhdl
        Dim report As New ReportDocument()
        'report.Load(AppPath + "ConfigDir\Invoice.rpt")
        report = New StockTransfersOUT

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

            For intCounter = 0 To report.Database.Tables.Count - 1
                report.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next


            ' You can change more print options via PrintOptions property of ReportDocument
        Dim jk As Integer = 1

        Dim SelFormular As String = "{RptStockTransfer.RefNo}=" & LastOrderNo  'Val(tOrderNo.Text)
        SelFormular = SelFormular + IIf(SelFormular = "", "", " AND ") + "{RptStockTransfer.SourceStore} LIKE '*" & cStore.Text & "*'"

        report.RecordSelectionFormula = SelFormular

        If radioLocalPrinters.Checked Then
            report.PrintOptions.PrinterName = cboLocalPrinters.SelectedItem.ToString()
        Else
            'If the network printer radio button is checked, we try to associate the selected network printer.
            report.PrintOptions.PrinterName = cboNetworkPrinters.SelectedItem.ToString()
        End If
        '            report.SetDatabaseLogon(UserID, Password)
        report.PrintToPrinter(jk, True, 0, 0)

        report.Close()


        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        ' Dim drSQL As SqlDataReader


        'Dim cmSQL2 As SqlCommand = cnSQL1.CreateCommand
        'Dim drSQL2 As SqlDataReader

        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub
        If cStore.Text = cDestinationStore.Text Then
            MsgBox("Source Store cannot be the same as the Destination Store", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        Dim MainCashPaid As Double = 0

        Dim i As Integer

        ''cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        If Action = AppAction.Add Then FetchNextNo()
        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        Dim TransferValue As Double = 0
        If DGridItems.Rows.Count > 0 Then
            TransferValue = CDbl(tTotalValue.Text)

            Dim j As Integer = 10

            For i = 0 To DGridItems.RowCount - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockTRANSFER"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@RefNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@Sn", i + 1)
                cmSQL.Parameters.AddWithValue("@CategoryName", DGridItems.Item(5, i).Value)
                cmSQL.Parameters.AddWithValue("@ProductCode", DGridItems.Item(0, i).Value)
                cmSQL.Parameters.AddWithValue("@ProductName", DGridItems.Item(1, i).Value)
                cmSQL.Parameters.AddWithValue("@Qty", Val(DGridItems.Item(2, i).Value))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(DGridItems.Item(3, i).Value))
                cmSQL.Parameters.AddWithValue("@FixedPrice", CDbl(DGridItems.Item(6, i).Value))
                cmSQL.Parameters.AddWithValue("@Details", "Transfer from " + cStore.Text & " to " & cDestinationStore.Text)
                '   cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(9).Text)------- Leave subitem 9 vacant
                cmSQL.Parameters.AddWithValue("@CostPrice", CDbl(DGridItems.Item(4, i).Value))
                cmSQL.Parameters.AddWithValue("@ProductDesc", DGridItems.Item(7, i).Value)
                cmSQL.Parameters.AddWithValue("@SourceStore", cStore.Text)
                cmSQL.Parameters.AddWithValue("@DestinationStore", cDestinationStore.Text)
                cmSQL.Parameters.AddWithValue("@TransType", DGridItems.Item(8, i).Value)
                cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
                cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
                cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(TransferValue, 2))
                cmSQL.Parameters.AddWithValue("@Username", sysUserName)

                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", DGridItems.Item(0, i).Value)
                cmSQL.Parameters.AddWithValue("@Store", cDestinationStore.Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(DGridItems.Item(2, i).Value))
                cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(DGridItems.Item(4, i).Value))
                cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(DGridItems.Item(3, i).Value))
                cmSQL.Parameters.AddWithValue("@TransType", DGridItems.Item(8, i).Value)
                cmSQL.Parameters.AddWithValue("@Discontinue", False)

                cmSQL.ExecuteNonQuery()

            Next i
        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        LastOrderNo = Val(tOrderNo.Text)

        If chkPrint.Checked = True Then PrintTheInvoice()

        flush()
        cmdSave.Enabled = False
        cmdNew.Enabled = True

        Action = AppAction.Add
        cStore.Enabled = True

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()


    End Sub

    Private Sub DGridItems_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridItems.CellLeave
        If e.ColumnIndex = 2 Then
            calculatePayable()
        End If
        If e.ColumnIndex = 3 Then
            DGridItems.Item(3, e.RowIndex).Value = Format(DGridItems.Item(3, e.RowIndex).Value, "standard")
            calculatePayable()
        End If
    End Sub
    Private Sub tSearchName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tSearchName.TextChanged
        ' If chkProduct = False Then Exit Sub
        If tSearchName.Text <> "" Then
            getProductList(tSearchName.Text)
            PanList.Visible = True
        Else
            'PanList.Visible = False
        End If
    End Sub
    Private Sub tSearchName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSearchName.KeyPress
        If e.KeyChar = Chr(13) Then
            chkProduct = False
            If GetProductByName(tSearchName.Text) = False Then Exit Sub
            PanList.Visible = False
            cmdAccept_Click(sender, e)
            tItemCode.Focus()
        End If
    End Sub
    Private Sub tSearchName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tSearchName.KeyDown
        If (e.KeyCode = 38 Or e.KeyCode = 40) And DGrid.RowCount > 0 Then
            skipLostFocus = True
            DGrid.Focus()
            On Error Resume Next
            DGrid.Rows(0).Selected = True
            '  skipLostFocus = False
            'Else
            ' skipLostFocus = False
        Else
            skipLostFocus = False
        End If
        'If e.KeyCode = 13 Then
        '    tCategory.Focus()
        '    PanList.Visible = False
        'End If
    End Sub
    Private Sub tSearchName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tSearchName.LostFocus
        '  If skipLostFocus = False Then PanList.Visible = False
    End Sub
    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        'If DoNotMoveNext = False Then tItemCode.Text = DGrid.Item(0, e.RowIndex).Value
        'DoNotMoveNext = False
        '   MsgBox(DGrid.Item(0, e.RowIndex).Value)
        If e.RowIndex < 0 Then
            SkipRowEnter = True

            Exit Sub
        End If

        DoNotMoveNext = True
        tItemCode.Text = DGrid.Item(0, e.RowIndex).Value
        If Trim(tItemCode.Text) = "" Then Exit Sub
        If GetProductByCode(tItemCode.Text) = False Then Exit Sub
        cmdAccept_Click(sender, e)
        ' PanList.Visible = False
    End Sub
    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        'DoNotMoveNext = True

        'If Trim(tItemCode.Text) = "" Then Exit Sub
        'If GetProductByCode(tItemCode.Text) = False Then Exit Sub
        'cmdAccept_Click(sender, e)
        '' PanList.Visible = False
    End Sub
    Private Sub DGrid_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.RowEnter
        On Error Resume Next
        If SkipRowEnter = True Then
            SkipRowEnter = False
            Exit Sub
        End If
        tItemCode.Text = ""
        If e.RowIndex < 0 Then Exit Sub
        If DoNotMoveNext = False Then tItemCode.Text = DGrid.Item(0, e.RowIndex).Value
        DoNotMoveNext = False
    End Sub
    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        If e.KeyCode = 13 And DGrid.RowCount > 0 Then
            DoNotMoveNext = True
            ' On Error Resume Next
            '  GetProductByCode(tProductName.Tag)
            If tItemCode.Text = "" Then Exit Sub
            If GetProductByCode(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
            PanList.Visible = False
            tItemCode.Focus()
        End If
    End Sub
    Private Sub lnkPrint_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPrint.LinkClicked
        PrintTheInvoice()
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

    End Sub

    Private Sub lnkPortPrinter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPortPrinter.LinkClicked
        PanPrinter.Visible = True
    End Sub

    Private Sub cmdClosePanelPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanelPrinter.Click
        PanPrinter.Visible = False
    End Sub
    Private Sub LoadPrinters()
        On Error GoTo handler
        'Let's clear our comboboxes to start fresh.
        cboNetworkPrinters.Items.Clear()
        cboLocalPrinters.Items.Clear()

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
                    cboNetworkPrinters.Items.Add(mo("Name").ToString())
                    network = True
                Else
                    'It's a local printer.
                    cboLocalPrinters.Items.Add(mo("Name").ToString())
                End If

                'If the printer is found to be the default one, we select it.
                If CBool(mo("Default")) Then
                    If network Then
                        cboNetworkPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = True
                    Else
                        cboLocalPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = False
                    End If

                    'lblNameValue.Text = mo("Name").ToString()
                    'lblPortValue.Text = mo("PortName").ToString()
                    'lblDriverValue.Text = mo("DriverName").ToString()
                    'lblDeviceIDValue.Text = mo("DeviceID").ToString()
                    'lblSharedValue.Text = mo("Shared").ToString()
                End If
            Next



        End If
        Exit Sub
handler:
        MsgBox("Problem Loading Default Printer", vbInformation, strApptitle)
    End Sub

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        oLoadCategory()
    End Sub
End Class