Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Public Class stkFrmTransfer1
    Public ReturnCode As String = ""
    Dim Action As AppAction
    Private printFont As Font
    Private streamToPrint As StreamReader
    Public Shared FullfilePath As String
    ' Dim WithEvents serialPort As New IO.Ports.SerialPort
    Dim chkProduct As Boolean = True
    Public ReturnOrderNo As Integer
    Public LastOrderNo As Integer = 0
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Dim StoredX As Long
    Dim StoredY As Long
    Dim Stored1X As Long
    Dim Stored1Y As Long
    Dim Minimize_Size As Long
    Dim skipLostFocus As Boolean

    Public ReturnBatchNo As String
    Public ReturnMadeDate As String
    Public ReturnExpiryDate As String
    Public ReturnDiscontinue As Boolean
    Private Sub stkFrmSales1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Stock Transfer"
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
        tTotalValue.BackColor = MainTheme
        PanDestinationStore.BackColor = MainTheme
        PanCommands.BackColor = MainTheme
        Panel4.BackColor = HeaderTheme
        PanDestinationStore.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        PanList.BackColor = HeaderTheme
        cStore.BackColor = HeaderTheme


        DGrid.DataSource = bindingSource

        FillStore()
        FillDestinationStore()

        dtpDate.Value = Now
        '   cmdNew.Enabled = ModuleAdd

        Action = AppAction.Add

        'mnuEdit.Enabled = ModuleEdit
        'PanCostPrice.Visible = ModuleEdit

        PanList.Top = tblMain.Top + PanEntry.Top + tblDetails.Top + tProductName.Bottom + 55
        PanList.Left = tblMain.Left + PanEntry.Left + tblDetails.Left + tProductName.Left + 5


        Minimize_Size = tblDetails.Width

        GetUserAccessDetails("Sales")
        PanCostPrice.Visible = ModuleEdit

    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()
        lvProduct.Items.Clear()

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

        'Dim i As Integer
        'For i = 0 To lvCategory.Items.Count - 1
        '    If i Mod 2 <> 0 Then
        '        lvCategory.Items(i).BackColor = MainTheme
        '    Else
        '        lvCategory.Items(i).BackColor = Color.SeaShell
        '    End If
        'Next

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
        tCategoryName.Tag = lvCategory.SelectedItems(0).Text
        tCategoryName.Text = lvCategory.SelectedItems(0).Text
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

        tProductName.Text = ""
        tCategoryName.Text = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0
        tItemCode.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductCodePerStore"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            GetProductByCode = False
            tItemCode.Focus()
            cmSQL.Dispose()
            drSQL.Close()
            Exit Function
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("Category")
                tItemCode.Tag = drSQL.Item("TransType")

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
        If lvSalesList.Items.Count > 0 Then
            TransferValue = Val(tTotalValue.Text)

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockTRANSFER"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@RefNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@Sn", i + 1)
                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@FixedPrice", CDbl(lvSalesList.Items(i).SubItems(7).Text))
                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(8).Text)
                '   cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(9).Text)------- Leave subitem 9 vacant
                cmSQL.Parameters.AddWithValue("@CostPrice", CDbl(lvSalesList.Items(i).SubItems(10).Text))
                cmSQL.Parameters.AddWithValue("@ProductDesc", lvSalesList.Items(i).SubItems(11).Text)
                cmSQL.Parameters.AddWithValue("@SourceStore", cStore.Text)
                cmSQL.Parameters.AddWithValue("@DestinationStore", cDestinationStore.Text)
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(13).Text)
                cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
                cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
                cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(TransferValue, 2))
                cmSQL.Parameters.AddWithValue("@Username", sysUserName)

                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@Store", cDestinationStore.Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(lvSalesList.Items(i).SubItems(10).Text))
                cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(13).Text)
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
        'Dim LPT As String = cPOS.Text
        'Dim ThePort As Integer = Val(Mid(cPOS.Text, 4))

        'If GetUserReportAccess("Sales Invoice") = False Then Exit Sub

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
        jk = 1
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
        chkProduct = False
        GetProductByCode(lvProduct.SelectedItems(0).Text)
        chkProduct = True
    End Sub
    Private Sub lvProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProduct.Click
        On Error Resume Next
        chkProduct = False
        GetProductByCode(lvProduct.SelectedItems(0).Text)
        chkProduct = True
    End Sub
    Private Sub tItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tItemCode.KeyPress
        If e.KeyChar = Chr(13) Then
            chkProduct = False
            If GetProductByCode(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
            chkProduct = True
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
        tQty.Text = ""
        tQty.Tag = 0

        tDetails.Text = ""
        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()
        cCostPrice.Tag = 0
        tItemCode.Focus()

        tTotalValue.Text = 0

        lvSalesList.Items.Clear()

        DoNotExist = False

        tSourceDoc.Text = ""


    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0
        tStockLevel.Text = 0
        tDetails.Text = ""

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()
        tItemCode.Focus()

    End Sub
    Private Sub tQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tQty.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
    End Sub
    Private Sub tStockLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tStockLevel.TextChanged
        If Val(tStockLevel.Text) < 0 Then
            MsgBox("Purchase Quantity greater than Stock Level", MsgBoxStyle.Information, strApptitle)
            tQty.Text = 1
        End If
    End Sub

    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal TheStore As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(2).Text = ProductCode And lvSalesList.Items(i).SubItems(12).Text = TheStore Then
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

        If IsNumeric(tSellPrice.Text) = False Or IsNumeric(tQty.Text) = False Then
            MsgBox("Quantity and Selling Price must be numeric", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tSellPrice.Text) < Val(tSellPrice.Tag) Then
            If MsgBox("Selling Below Selling Price" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If Val(tQty.Text) < 0 Then
            MsgBox("Quantity must be positive", vbInformation, strApptitle)
            Exit Sub
        End If
        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Or Val(tQty.Text) = 0 Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If

        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cStore.Text)
        If PositionInList >= 0 Then
            lvSalesList.Items(PositionInList).SubItems(4).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) + CDbl(tQty.Text)
            lvSalesList.Items(PositionInList).SubItems(5).Text = IIf((CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) = 0, 0, Math.Round(CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) / 2)
            ' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

            lvSalesList.Items(PositionInList).SubItems(6).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) * CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) ' seem dump hen!!, don't delete i know what am doing
            lvSalesList.Items(PositionInList).SubItems(8).Text = lvSalesList.Items(PositionInList).SubItems(8).Text + IIf(Trim(tDetails.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(8).Text) = "", "", ",") + tDetails.Text)

        Else

            'including when PositionInList = -1 MsgBox("Item Already in List with different Deposit Status" & Chr(13) & "It cannot be added to the existing Product", vbInformation, strApptitle)
            Dim LvItems As New ListViewItem
            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(tCategoryName.Text)
            LvItems.SubItems.Add(tItemCode.Text)
            LvItems.SubItems.Add(tProductName.Text)
            LvItems.SubItems.Add(Val(tQty.Text))

            LvItems.SubItems.Add(Format(CDbl(tSellPrice.Text), "Standard"))
            LvItems.SubItems.Add(Format(CDbl(tQty.Text) * CDbl(tSellPrice.Text), "Standard"))
            LvItems.SubItems.Add(tSellPrice.Tag)
            LvItems.SubItems.Add(tDetails.Text)
            LvItems.SubItems.Add("")
            LvItems.SubItems.Add(CDbl(cCostPrice.Tag))

            LvItems.SubItems.Add(tItemDesc.Text)
            LvItems.SubItems.Add(cStore.Text)
            LvItems.SubItems.Add(tItemCode.Tag) 'TransType

            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

        End If
        calculatePayable()


        cmdClear_Click(sender, e)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub calculatePayable()
        On Error GoTo handler
        Dim i As Integer
        Dim ThePayable As Double = 0
        For i = 0 To lvSalesList.Items.Count - 1
            ThePayable = ThePayable + CDbl(lvSalesList.Items(i).SubItems(6).Text)
        Next
        tTotalValue.Text = Format(Math.Round(ThePayable, 2), "standard")

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub tTotalValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tTotalValue.TextChanged
        calculatePayable()
    End Sub

    Private Sub CmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOpen.Click
        On Error GoTo handler

        If lvSalesList.SelectedItems(0).SubItems(12).Text <> cStore.Text Then cStore.Text = lvSalesList.SelectedItems(0).SubItems(12).Text
        chkProduct = False
        GetProductByCode(lvSalesList.SelectedItems(0).SubItems(2).Text)

        tDetails.Text = lvSalesList.SelectedItems(0).SubItems(8).Text
        tTotalValue.Text = tTotalValue.Text - (CDbl(lvSalesList.SelectedItems(0).SubItems(4).Text) * CDbl(lvSalesList.SelectedItems(0).SubItems(5).Text))

        tQty.Text = lvSalesList.SelectedItems(0).SubItems(4).Text
        tSellPrice.Text = Math.Round(Val(lvSalesList.SelectedItems(0).SubItems(5).Text), 2)


        lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)

        Dim i As Integer = 0
        For i = 0 To lvSalesList.Items.Count - 1
            lvSalesList.Items(i).Text = i + 1
        Next
        tQty.Focus()

        chkProduct = True

        calculatePayable()

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
        Action = AppAction.Add
        cStore.Enabled = True
    End Sub
    Private Sub CmdCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        On Error GoTo errhdl
        If MsgBox("The Selected Transaction would be removed" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbYes Then
            tTotalValue.Text = tTotalValue.Text - (Val(lvSalesList.SelectedItems(0).SubItems(4).Text) * Val(lvSalesList.SelectedItems(0).SubItems(5).Text))
            lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)
            Dim i As Integer = 0
            For i = 0 To lvSalesList.Items.Count - 1
                lvSalesList.Items(i).Text = i + 1
            Next
            calculatePayable()
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
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tDetails.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub mnuPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintInvoice.Click
        If LastOrderNo <> 0 Then Call PrintTheInvoice()
    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        MsgBox(Me.Width)
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
        If tProductName.Text <> "" Then
            getProductList(tProductName.Text)
            PanList.Visible = True
        Else
            PanList.Visible = False
        End If
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

        'cnSQL.Open()
        If radContaining.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%' ORDER BY ProductName"
        If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%' ORDER BY ProductName"
        If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "' ORDER BY ProductName"
        If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName  = '" + strQry & "' ORDER BY ProductName"

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

        On Error Resume Next
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

        tProductName.Text = ""
        tCategoryName.Text = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0
        tItemCode.Tag = ""
        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(strValue) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductNamePerStore"
        cmSQL.Parameters.AddWithValue("@ProductName", strValue)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            ' MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
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
        tStockLevel.Tag = 0

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

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

                If tItemCode.Tag = "Service" Then
                    tQty.Tag = 1000000
                    tQty.Text = 1
                    tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                    tQty.Minimum = 1
                    tQty.Maximum = Val(tQty.Tag)
                Else
                    tQty.Tag = drSQL.Item("Qty")
                    tQty.Text = 1
                    tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                    tQty.Minimum = 1
                    tQty.Maximum = Val(tQty.Tag)
                End If

                tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                    cFixedPrice.SelectedIndex = 0
                Else
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cFixedPrice.SelectedIndex = 0
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

                ReturnMadeDate = Format(drSQL.Item("DateMade"), "dd-MMM-yyyy")
                ReturnExpiryDate = Format(drSQL.Item("ExpiryDate"), "dd-MMM-yyyy")
                ReturnDiscontinue = drSQL.Item("Discontinue")

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
            cmSQL.CommandText = "SELECT Store FROM AssignedStore WHERE UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
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
    Private Sub FillDestinationStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim StaffName As String
        cDestinationStore.Items.Clear()
        cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cDestinationStore.Items.Add(drSQL.Item("Store").ToString)
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        cDestinationStore.SelectedIndex = 0

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
        oLoadCategory()
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
        'If chkProduct = False Then
        '    tProductName.Text = DGrid.Item(1, e.RowIndex).Value
        '    tProductName.Tag = DGrid.Item(0, e.RowIndex).Value
        'End If
        On Error Resume Next
        If chkProduct = False Then GetProductByCode(DGrid.Item(0, e.RowIndex).Value)
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
    Private Sub stkFrmTransfer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Height = 1189
        Me.Width = 612

        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub
End Class