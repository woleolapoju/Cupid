Imports System
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Public Class stkFrmAdjustment
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
    Public ReturnBatchNo As String
    Public ReturnMadeDate As String
    Public ReturnExpiryDate As String
    Public ReturnDiscontinue As Boolean
    Dim SelectedStore As String

    Private Sub stkFrmProformal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Stock Adjustment"
        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        lvCategory.BackColor = MainTheme
        lvProduct.BackColor = MainTheme
        lvSalesList.BackColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        tOrderNo.BackColor = MainTheme
        tCategoryName.BackColor = MainTheme
        tItemDesc.BackColor = MainTheme

        tStockLevel.BackColor = MainTheme
        PanCommands.BackColor = MainTheme
        Panel4.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        PanList.BackColor = HeaderTheme
        cStore.BackColor = HeaderTheme


        DGrid.DataSource = bindingSource

        FillStore()


        ' FetchBatchNo("087400431030")

        dtpDate.Value = Now
        'cmdNew.Enabled = ModuleAdd

        'Action = AppAction.Add



        'chkDiscount.Checked = True
        PanList.Top = tblMain.Top + PanEntry.Top + tblDetails.Top + tProductName.Bottom + 55
        PanList.Left = tblMain.Left + PanEntry.Right + tblDetails.Left + tProductName.Left - 700

        Minimize_Size = tblDetails.Width


        cmdNewItem.Enabled = GetUserAccessDetails("Stockitem Register")
        mnuDELETEPRODUCT.Enabled = ModuleDelete

     
    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()
        lvProduct.Items.Clear()

        cmSQL.CommandText = "SELECT Description AS Category FROM CATEGORY UNION SELECT DISTINCT Category FROM STOREITEMS WHERE Category NOT IN (SELECT Description FROM CATEGORY) AND Discontinue=0"

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
        If chkOnlyWithQuantity.Checked = False Then
            cmSQL.CommandText = "FetchAllActiveStoreItemsPerCategoryPerStore"
        Else
            cmSQL.CommandText = "FetchAllActiveAvailableStoreItemsPerCategoryPerStore"
        End If

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
            LvItems.SubItems.Add(Mid(drSQL.Item("TransType"), 1, 1))
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

        tQty.Enabled = True

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveStoreItemsPerProductCode"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            If cmdNewItem.Enabled = True Then
                If MsgBox("Product not found....Create y/n", vbYesNo + vbInformation, strApptitle) = vbYes Then
                    cmSQL.Dispose()
                    drSQL.Close()
                    chkProduct = False
                    PanList.Visible = False
                    If tCategoryName.Tag = "" Then
                        MsgBox("Select a category for the New Stock Item", vbInformation, strApptitle)
                    Else
                        If Trim(tItemCode.Text) <> "" Then
                            SaveNewProduct("code", tItemCode.Text)
                            GetProductByCode(tItemCode.Text)
                        End If
                    End If

                Else
                    MsgBox("Product not found....", vbInformation, strApptitle)
                    GetProductByCode = False
                    'tProductName.Focus()
                    tItemCode.Focus()
                    cmSQL.Dispose()
                    drSQL.Close()
                End If
            Else
                MsgBox("Product not found....", vbInformation, strApptitle)
                GetProductByCode = False
                'tProductName.Focus()
                tItemCode.Focus()
                cmSQL.Dispose()
                drSQL.Close()
            End If

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
                tReason.Tag = drSQL.Item("TransType")
                If drSQL.Item("TransType") = "Service" Then tQty.Enabled = False

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

        cmSQL.CommandText = "FetchNewAdjustmentRefNo"
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        ' Dim drSQL As SqlDataReader

        'Dim cmSQL2 As SqlCommand = cnSQL1.CreateCommand
        'Dim drSQL2 As SqlDataReader

        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub

        Dim i As Integer

        ''cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        FetchNextNo()
        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        If lvSalesList.Items.Count > 0 Then

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertAdjustment"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@RefNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
                cmSQL.Parameters.AddWithValue("@Sn", i + 1)
                cmSQL.Parameters.AddWithValue("@Category", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))

                cmSQL.Parameters.AddWithValue("@Cost", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@PrevCost", CDbl(lvSalesList.Items(i).SubItems(6).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(lvSalesList.Items(i).SubItems(7).Text))
                cmSQL.Parameters.AddWithValue("@Reason", lvSalesList.Items(i).SubItems(8).Text)
                cmSQL.Parameters.AddWithValue("@ProductDesc", lvSalesList.Items(i).SubItems(9).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(10).Text)
                cmSQL.Parameters.AddWithValue("@PrevSellPrice", CDbl(lvSalesList.Items(i).SubItems(11).Text))
                cmSQL.Parameters.AddWithValue("@PrevQty", Val(lvSalesList.Items(i).SubItems(12).Text))
                cmSQL.Parameters.AddWithValue("@Username", sysUserName)

                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(10).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(lvSalesList.Items(i).SubItems(7).Text))
                cmSQL.Parameters.AddWithValue("@Discontinue", False)
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(13).Text)
                cmSQL.ExecuteNonQuery()

            Next i
        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()


        LastOrderNo = Val(tOrderNo.Text)

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

    Private Sub PrintTheInvoice() 'Optional LPT As String = "LPT1")
        On Error GoTo errhdl
        Dim report As New ReportDocument()
        report.Load(AppPath + "ConfigDir\Invoice.rpt")


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
        Dim SelFormular As String = "{RptSales.OrderNo}=" & LastOrderNo  'Val(tOrderNo.Text)

        report.RecordSelectionFormula = SelFormular

        '            report.SetDatabaseLogon(UserID, Password)
        report.PrintToPrinter(jk, True, 0, 0)

        report.Close()


        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub lvProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProduct.SelectedIndexChanged
        On Error Resume Next
        lvProduct.Tag = ""
        mnuDELETEPRODUCT.Tag = ""
        ctxtDeleteProduct.Tag = ""
        lvProduct.Tag = lvProduct.SelectedItems(0).Text
        mnuDELETEPRODUCT.Tag = lvProduct.SelectedItems(0).SubItems(2).Text
        ctxtDeleteProduct.Tag = lvProduct.SelectedItems(0).SubItems(3).Text

        chkProduct = False
        GetProductByCode(lvProduct.SelectedItems(0).Text)
        chkProduct = True
    End Sub

    Private Sub mnuDELETEPRODUCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDELETEPRODUCT.Click
        'lvProduct.Tag = lvProduct.SelectedItems(0).Text
        'mnuDELETEPRODUCT.Tag = lvProduct.SelectedItems(0).SubItems(1).Text
        'ctxtDeleteProduct.Tag = lvProduct.SelectedItems(0).SubItems(2).Text

        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim myTrans As SqlClient.SqlTransaction

        If lvProduct.Tag = "" Then
            MsgBox("Pls. select a Stock Item to delete", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        'If Val(mnuDELETEPRODUCT.Tag) > 0 And ctxtDeleteProduct.Tag = "R" Then
        '    MsgBox("The product still remaining in stock", MsgBoxStyle.Information, strApptitle)
        '    Exit Sub
        'End If
        If MsgBox("Do You Want To Delete This Product?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

        myTrans = cnSQL.BeginTransaction()

        cmSQL.Transaction = myTrans

        cmSQL.CommandText = "DeleteStockItem4StockQty"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", lvProduct.Tag)
        cmSQL.ExecuteNonQuery()

        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "DeleteStoreItems"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", lvProduct.Tag)
        cmSQL.ExecuteNonQuery()


        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        On Error Resume Next
        oLoadProduct(tCategoryName.Tag)
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()

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
        chkProduct = False
        If tItemCode.Text = "" Then Exit Sub
        If GetProductByCode(tItemCode.Text) = False Then
            tItemCode.Focus()
        Else
            tQty.Focus()
        End If

        chkProduct = True
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

        ' tReason.Text = ""
        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()
        cCostPrice.Tag = 0
        tItemCode.Focus()


        lvSalesList.Items.Clear()

        DoNotExist = False

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        '  tCategoryName.Tag = ""

        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tCostPrice.Text = 0
        tCostPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0
        tStockLevel.Text = 0
        ' tReason.Text = ""
        'tReason.Tag = ""

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        tItemCode.Focus()

    End Sub

    'Private Sub tQty_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tQty.Enter, tQty.Enter
    '    tQty.Select(0, tQty.Text.Length)
    'End Sub

    Private Sub tQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tQty.GotFocus
        tQty.Select(0, tQty.Text.Length)
    End Sub

    Private Sub tQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tQty.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)
        If Val(tStockLevel.Text) < 0 Then
            MsgBox("Stock Level cannot be less than 0", MsgBoxStyle.Information, strApptitle)
            tQty.Text = 0
        End If
    End Sub
    Private Sub tStockLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tStockLevel.TextChanged
        'If Val(tStockLevel.Text) < 0 Then
        '    MsgBox("Purchase Quantity greater than Stock Level", MsgBoxStyle.Information, strApptitle)
        '    tQty.Text = 1
        'End If
        If Val(tStockLevel.Text) > Val(tStockLevel.Tag) And Val(tStockLevel.Tag) > 0 Then MsgBox("Stock Level exceeds Max. Level allowed", MsgBoxStyle.Information, strApptitle)

    End Sub
    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal TheStore As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(2).Text = ProductCode And lvSalesList.Items(i).SubItems(10).Text = TheStore Then
                ProductAreadyInList = i 'Exist but should be added to existing
                Exit Function
            Else
                ProductAreadyInList = -2
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

        If Trim(tCostPrice.Text) = "" Then tCostPrice.Text = 0
        If Trim(tSellPrice.Text) = "" Then tSellPrice.Text = 0
        If Trim(tQty.Text) = "" Then tQty.Text = 0


        If IsNumeric(tSellPrice.Text) = False Or IsNumeric(tCostPrice.Text) = False Or IsNumeric(tQty.Text) = False Then
            MsgBox("Quantity,Selling Price and Cost Price must be numeric", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tCostPrice.Text) > Val(tCostPrice.Tag) And Val(tCostPrice.Tag) <> 0 Then
            If MsgBox("New Costprice is above prevailing costprice" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If
        If Trim(tReason.Text) = "" Then
            MsgBox("Reason for the adjustment is required", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If Val(tCostPrice.Text) = Val(tCostPrice.Tag) And Val(tSellPrice.Text) = Val(tSellPrice.Tag) And Val(tQty.Text) = 0 Then
            MsgBox("No change made", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tQty.Value) < 1 And Me.Tag = False Then
            MsgBox("You dont have the privildge to do a negative adjustment", vbCritical, strApptitle)
            tQty.Value = 0
            tQty.Focus()
            Exit Sub
        End If

        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cStore.Text)
        If PositionInList >= 0 Then
            lvSalesList.Items(PositionInList).SubItems(4).Text = Val(lvSalesList.Items(PositionInList).SubItems(4).Text) + Val(tQty.Text)
            'lvSalesList.Items(PositionInList).SubItems(6).Text = IIf((Val(lvSalesList.Items(PositionInList).SubItems(6).Text) + Val(tCostPrice.Text)) = 0, 0, Math.Round(Val(lvSalesList.Items(PositionInList).SubItems(6).Text) + Val(tCostPrice.Text)) / 2)
            '' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

            ' lvSalesList.Items(PositionInList).SubItems(7).Text = Val(lvSalesList.Items(PositionInList).SubItems(4).Text) * Val(lvSalesList.Items(PositionInList).SubItems(6).Text) ' seem dump hen!!, don't delete i know what am doing
            ' lvSalesList.Items(PositionInList).SubItems(8).Text = lvSalesList.Items(PositionInList).SubItems(9).Text + IIf(Trim(tReason.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(9).Text) = "", "", ",") + tReason.Text)

        Else

            'including when PositionInList = -1 MsgBox("Item Already in List with different Deposit Status" & Chr(13) & "It cannot be added to the existing Product", vbInformation, strApptitle)
            Dim LvItems As New ListViewItem
            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(tCategoryName.Text)
            LvItems.SubItems.Add(tItemCode.Text)
            LvItems.SubItems.Add(tProductName.Text)
            LvItems.SubItems.Add(Val(tQty.Text))
            LvItems.SubItems.Add(CDbl(tCostPrice.Text))
            LvItems.SubItems.Add(CDbl(tCostPrice.Tag))
            LvItems.SubItems.Add(CDbl(tSellPrice.Text))
            LvItems.SubItems.Add(tReason.Text)

            LvItems.SubItems.Add(tItemDesc.Text)
            LvItems.SubItems.Add(cStore.Text)

            LvItems.SubItems.Add(CDbl(tSellPrice.Tag))
            LvItems.SubItems.Add(Val(tQty.Tag))
            LvItems.SubItems.Add(tReason.Tag) 'TransType

            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

        End If

        cmdClear_Click(sender, e)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub CmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOpen.Click
        On Error GoTo handler

        If lvSalesList.SelectedItems(0).SubItems(10).Text <> cStore.Text Then cStore.Text = lvSalesList.SelectedItems(0).SubItems(10).Text
        chkProduct = False
        GetProductByCode(lvSalesList.SelectedItems(0).SubItems(2).Text)

        tReason.Text = lvSalesList.SelectedItems(0).SubItems(8).Text

        tQty.Text = lvSalesList.SelectedItems(0).SubItems(4).Text
        tCostPrice.Text = Math.Round(Val(lvSalesList.SelectedItems(0).SubItems(5).Text), 2)
        tSellPrice.Text = Math.Round(Val(lvSalesList.SelectedItems(0).SubItems(7).Text), 2)


        lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)

        Dim i As Integer = 0
        For i = 0 To lvSalesList.Items.Count - 1
            lvSalesList.Items(i).Text = i + 1
        Next
        tQty.Focus()

        chkProduct = True

        Exit Sub
handler:
        If Err.Description Like "*InvalidArgument=Value of*" Then
            MsgBox("Please select from the list", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        flush()
        lvSalesList.Items.Clear()
        cmdNew.Enabled = True
        cmdSave.Enabled = False
        tItemCode.Focus()
        ReturnOrderNo = 0
        cmdNew.Enabled = ModuleAdd
        Action = ModuleAdd
        cStore.Enabled = True
    End Sub
    Private Sub CmdCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        On Error GoTo errhdl
        If MsgBox("The Selected Transaction would be removed" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbYes Then
            lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)
            Dim i As Integer = 0
            For i = 0 To lvSalesList.Items.Count - 1
                lvSalesList.Items(i).Text = i + 1
            Next
        End If
        Exit Sub
errhdl:
        If Err.Description Like "*InvalidArgument=Value of*" Then
            MsgBox("Please select from the list", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub


    Private Sub tSellPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSellPrice.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tReason.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub mnuPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintInvoice.Click
        If LastOrderNo <> 0 Then Call PrintTheInvoice()
    End Sub
    Private Sub lnkItemList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkItemList.LinkClicked
        If lnkItemList.Text Like "Show*" Then
            tblProductListings.Visible = True
            lnkItemList.Text = "Hide Item Listings"
            tblContent.ColumnStyles(0).Width = 50
            tblContent.ColumnStyles(1).Width = 50
            Me.WindowState = FormWindowState.Maximized
            PanList.Top = tProductName.Top + 80 'tDesc.Height
            PanList.Left = tblDetails.Left + tProductName.Left + 5
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
        If chkProduct = False Then Exit Sub
        skipLostFocus = True
        If tProductName.Text <> "" Then
            getProductList(tProductName.Text)
            PanList.Visible = True
        Else
            PanList.Visible = False
        End If
        skipLostFocus = False
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
        Dim strQuery As String = ""
        Dim str1 As String = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc"
        Dim str2 As String = " FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND StoreItems.TransType='Retail' AND (StoreItems.Discontinue = 0) AND "
        'cnSQL.Open()
        If radContaining.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%'"
        If RadStartWith.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%'"
        If RadEndWith.Checked Then strQuery = "  ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "'"
        If RadEqual.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName  = '" + strQry & "'"
        Dim str As String = "SELECT ProductCode, ProductName, Category,0 AS Qty,0 AS SellPriceNew, 0 AS CostPriceNew,ProductDesc FROM StoreItems WHERE TransType='Retail' AND Discontinue=0 AND " & strQuery & " AND ProductCode NOT IN (SELECT StockQty.ProductCode " & str2 + strQuery & ") UNION " & str1 + str2 + strQuery + " ORDER BY ProductName"

        cmSQL.CommandText = str
        cmSQL.CommandType = CommandType.Text

        dataAdapter = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        cmSQL.Dispose()

        DGrid.Columns(1).Width = 200
        DGrid.Columns(3).Width = 60
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
        tQty.Enabled = True
        If Trim(strValue) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveStoreItemsPerProductName"
        cmSQL.Parameters.AddWithValue("@ProductName", strValue)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            If cmdNewItem.Enabled = True Then
                If MsgBox("Product not found....Create y/n", vbYesNo + vbInformation, strApptitle) = vbYes Then
                    cmSQL.Dispose()
                    drSQL.Close()
                    chkProduct = False
                    PanList.Visible = False
                    If tCategoryName.Tag = "" Then
                        MsgBox("Select a category for the New Stock Item", vbInformation, strApptitle)
                    Else
                        If Trim(tProductName.Text) <> "" Then
                            SaveNewProduct("name", tProductName.Text)
                            GetProductByName(tProductName.Text)
                        End If
                    End If

                Else
                    MsgBox("Product not found....", vbInformation, strApptitle)
                    GetProductByName = False
                    tProductName.Focus()
                    cmSQL.Dispose()
                    drSQL.Close()
                End If
            Else
                MsgBox("Product not found....", vbInformation, strApptitle)
                GetProductByName = False
                tProductName.Focus()
                cmSQL.Dispose()
                drSQL.Close()
            End If

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
                tReason.Tag = drSQL.Item("TransType")
                If drSQL.Item("TransType") = "Service" Then tQty.Enabled = False

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

        ' tReason.Tag = ""
        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        tQty.Minimum = -1000000000
        tQty.Maximum = 1000000000

        '  tQty.Enabled = True

        If Trim(ProductCode) = "" Then Exit Sub

        'cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerStore"
        'cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        'cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        'cmSQL.CommandType = CommandType.StoredProcedure
        Dim jk As Integer = 0
        cmSQL.CommandText = "SELECT StockItemBalances.* FROM StockItemBalances INNER JOIN STOREITEMS ON StockItemBalances.ProductCode = STOREITEMS.ProductCode WHERE Store='" & cStore.Text & "' AND StockItemBalances.ProductCode='" & ProductCode & "' AND  StoreItems.Discontinue=0"
        'cmSQL.CommandText = "SELECT * FROM StockQty WHERE Store='" & cStore.Text & "' AND ProductCode='" & ProductCode & "' AND  Discontinue=0"
        GoTo skipAgain
checkAgain:
        cmSQL.CommandText = "SELECT * FROM StockQty WHERE ProductCode='" & ProductCode & "'" ' AND  Discontinue=0"
skipAgain:
        cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            jk = jk + 1
            If jk = 1 Then
                drSQL.Close()
                GoTo checkAgain
            End If

        Else
            If drSQL.Read Then
                'tItemCode.Text = drSQL.Item("ProductCode")
                'tProductName.Text = drSQL.Item("ProductName")
                'tCategoryName.Text = drSQL.Item("Category")
                'tPack.Text = drSQL.Item("Pack")
                'tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
                ' tStockLevel.Text = drSQL.Item("Qty")

                tQty.Tag = drSQL.Item("Qty")
                tQty.Text = 0

                If jk = 1 Then
                    tQty.Tag = 0
                    tQty.Text = 0
                End If

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

                tReason.Tag = drSQL.Item("TransType")
                '  If drSQL.Item("TransType") = "Service" Then tQty.Enabled = False
            End If
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()


        Exit Sub
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
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
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM Store ORDER BY [Default] DESC"
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
    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        If ST_IgnoreStoreAssignment = False Then
            If lvSalesList.Items.Count > 0 And cStore.Text <> SelectedStore Then
                If MsgBox("Content of the list would be deleted" + Chr(13) + "Continue...(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, strApptitle) = MsgBoxResult.No Then
                    cStore.Text = SelectedStore
                    Exit Sub
                Else
                    oLoadCategory()
                    cmdClearAll_Click(sender, e)
                End If
            Else
                oLoadCategory()
            End If
        Else
            oLoadCategory()
        End If

        SelectedStore = cStore.Text
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
    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        'If chkProduct = False Then
        '    tProductName.Text = DGrid.Item(1, e.RowIndex).Value
        '    tProductName.Tag = DGrid.Item(0, e.RowIndex).Value
        'End If

        On Error Resume Next
        If chkProduct = False Then
            GetProductByCode(tProductName.Tag)
            PanList.Visible = False
        End If

    End Sub
    Private Sub DGrid_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.RowEnter
        On Error Resume Next
        If chkProduct = False Then
            '    tProductName.Text = DGrid.Item(1, e.RowIndex).Value
            GetProductByCode(DGrid.Item(0, e.RowIndex).Value)
            tProductName.Tag = DGrid.Item(0, e.RowIndex).Value
        End If


    End Sub
    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        If e.KeyCode = 13 And DGrid.RowCount > 0 Then
            skipLostFocus = True
            ' On Error Resume Next
            '  GetProductByCode(tProductName.Tag)
            chkProduct = True
            PanList.Visible = False

            tQty.Focus()
        End If
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
    Private Sub SaveNewProduct(ByVal ByWhot As String, ByVal Thestr As String)
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim jk As Integer = 1
        Dim resp As String = ""
        tID.Tag = ""
        If Trim(Thestr) = "" Then Exit Sub
        If ByWhot = "code" Then
            tID.Tag = Thestr
            resp = InputBox("Enter Product Name", "New Product", "")
            If Trim(resp) = "" Then Exit Sub
        End If
        If tCategoryName.Tag = "" Then
            MsgBox("Pls. select Category", vbInformation, strApptitle)
            Exit Sub
        End If
FetchNoAgain:
        FetchNextProductNo(jk)

        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction
        myTrans = cnSQL.BeginTransaction()
        cmSQL.Transaction = myTrans

        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "InsertStoreItems"
        cmSQL.CommandType = CommandType.StoredProcedure
        If ByWhot = "name" Then
            cmSQL.Parameters.AddWithValue("@ProductCode", tID.Tag)
            cmSQL.Parameters.AddWithValue("@ProductName", Thestr)
        Else
            cmSQL.Parameters.AddWithValue("@ProductCode", Thestr)
            cmSQL.Parameters.AddWithValue("@ProductName", resp)
        End If

        cmSQL.Parameters.AddWithValue("@Category", tCategoryName.Tag)

        'cmSQL.Parameters.AddWithValue("@Pack", "Unit")
        cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
        cmSQL.Parameters.AddWithValue("@MaxQty", 0)
        cmSQL.Parameters.AddWithValue("@Rate", 0)
        cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")


        cmSQL.Parameters.AddWithValue("@Discontinue", False)
        cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
        cmSQL.Parameters.AddWithValue("@ProductDesc", "")
        cmSQL.Parameters.AddWithValue("@Remark", "")

        If ST_TransType = "Both" Then
            cmSQL.Parameters.AddWithValue("@TransType", IIf(Trim(tReason.Tag) = "", "Retail", tReason.Tag))
        Else
            cmSQL.Parameters.AddWithValue("@TransType", ST_TransType)

        End If


        '      @ProductCode,@ProductName
        ' @Category,@ReorderLevel,@MaxQty,@Rate,@Discontinue,@AutoID,@ProductDesc,@Remark,
        '@ShelfLocation,
        '@TransType)


        cmSQL.ExecuteNonQuery()

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        If Err.Description Like "Violation of PRIMARY KEY constraint*" Then
            jk = jk + 1
            myTrans.Rollback()
            ' cnSQL.Close()
            GoTo FetchNoAgain
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
            myTrans.Rollback()
        End If
    End Sub
    Private Function FetchNextProductNo(ByVal j As Integer) As Boolean
        On Error GoTo errhdl
        FetchNextProductNo = True
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewStockItemID"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If Trim(tID.Tag) = "" Then

            If drSQL.HasRows Then
                If drSQL.Read Then tID.Tag = CStr(CLng(drSQL.Item("NewID") + j))
            Else
                tID.Tag = "1"
            End If
            tID.Text = Val(tID.Tag)
        Else
            If drSQL.HasRows Then
                If drSQL.Read Then tID.Text = CLng(drSQL.Item("NewID") + j)
            Else
                tID.Text = 1
            End If
            ' tCode.Tag = Val(tCode.Text)
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    Private Sub tCostPrice_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tCostPrice.Enter
        If (Not String.IsNullOrEmpty(tCostPrice.Text)) Then
            tCostPrice.SelectionStart = 0
            tCostPrice.SelectionLength = tCostPrice.Text.Length
        End If
    End Sub

    Private Sub tSellPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tSellPrice.GotFocus
        If (Not String.IsNullOrEmpty(tSellPrice.Text)) Then
            tSellPrice.SelectionStart = 0
            tSellPrice.SelectionLength = tSellPrice.Text.Length
        End If
    End Sub

    Private Sub tQty_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.ValueChanged
        
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        PrintTheInvoice()
    End Sub
End Class