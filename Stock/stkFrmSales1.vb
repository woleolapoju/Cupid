Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Management

Public Class stkFrmSales1
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
    Dim SelectedStore As String
    Dim dontRefillCustomer As Boolean = False
    Private defaultNetwork As Boolean
    Private Sub stkFrmSales1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        AppHeader1.lblForm.Text = "Sales"
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
        tChange.BackColor = MainTheme
        tTotalValue.BackColor = MainTheme
        Panel5.BackColor = MainTheme
        PanCommands.BackColor = MainTheme
        Panel4.BackColor = HeaderTheme
        PanPrinter.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        PanList.BackColor = HeaderTheme
        '  cStore.BackColor = HeaderTheme


        DGrid.DataSource = bindingSource

        FillStore()
        oLoadSalesPerson()
        LoadPrinters()
        If defaultNetwork Then
            radioNetworkPrinters.Checked = True
        Else
            radioLocalPrinters.Checked = True
        End If

        ' FetchBatchNo("087400431030")
        cPOS.Items.Add("WinPrn")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cPOS.Items.Add(sp)
            cPole.Items.Add(sp)
        Next

        cPOS.Text = POSPrinter
        cPole.Text = POSPole
        chkPrint.Checked = PrintInvoice
        cInvoiceType.Text = InvoiceType

        dtpDate.Value = Now
        cmdNew.Enabled = ModuleAdd

        Action = AppAction.Add

        mnuEdit.Enabled = ModuleEdit And ModuleDelete
        PanCostPrice.Visible = ModuleEdit

        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        PanList.Top = tblMain.Top + PanEntry.Top + tblDetails.Top + tProductName.Bottom + 55
        PanList.Left = tblMain.Left + PanEntry.Left + tblDetails.Left + tProductName.Left + 5

        PanPrinter.Top = tblMain.Top + tblDetails.Top + lnkPortPrinter.Bottom + 55
        PanPrinter.Left = tblMain.Left + tblDetails.Left + PanPayment.Left + lnkPortPrinter.Left + 205

        Minimize_Size = tblDetails.Width

        ' fillCustomers()

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

    Private Sub oLoadSalesPerson()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cSalesPerson.Items.Clear()

        cmSQL.CommandText = "SELECT * FROM SalesPerson ORDER BY TheName"

        cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        cSalesPerson.Items.Add("")

        Do While drSQL.Read
            cSalesPerson.Items.Add(drSQL.Item("TheName"))
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

    Private Sub RadCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCash.CheckedChanged
        PanPayType.Visible = False
        tPayDetails.Text = ""
    End Sub
    Private Sub RadPOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPOS.CheckedChanged
        PanPayType.Visible = True
        tPayDetails.Focus()
    End Sub

    Private Sub RadCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCheque.CheckedChanged
        PanPayType.Visible = True
        tPayDetails.Focus()
    End Sub

    Private Sub RadOthers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadOthers.CheckedChanged
        PanPayType.Visible = True
        tPayDetails.Focus()
    End Sub
    Private Function GetProductByCode(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl

        If IsNumeric(ProductCode) Then ProductCode = Math.Round(Val(ProductCode), 0)

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
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = False
    End Sub

    Private Function FetchNextNo() As Integer
        On Error GoTo errhdl
        FetchNextNo = 0
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewSalesOrderNo"
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

        Dim cnSQL1 As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL1 As SqlCommand = cnSQL1.CreateCommand
        Dim drSQL1 As SqlDataReader

        'Dim cmSQL2 As SqlCommand = cnSQL1.CreateCommand
        'Dim drSQL2 As SqlDataReader

        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub

        Dim MainCashPaid As Double = 0

        If RadCash.Checked <> True And Trim(tPayDetails.Text) = "" Then
            MsgBox("Please enter payment details for the mode chosen", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If Val(tPaid.Text) < 0 Then
            MsgBox("Amount paid cannot be less than zero (0)", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If Val(tPayable.Text) < 0 Then
            MsgBox("Payable amount cannot be less than Zero (0)", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If Val(tPaid.Text) = 0 And RadCash.Checked = False Then
            MsgBox("Amount paid cannot be zero (0) for non-cash payment", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If chkGiveChange.Checked = True Then
            If CDbl(tChange.Text) <> 0 Then
                If CDbl(tChange.Text) < 0 Then
                    MainCashPaid = CDbl(tPaid.Text)
                Else
                    MainCashPaid = CDbl(tPaid.Text) - CDbl(tChange.Text)
                End If
            Else
                MainCashPaid = CDbl(tPaid.Text)
            End If
        Else
            MainCashPaid = CDbl(tPaid.Text)
        End If

        If MainCashPaid < CDbl(tPayable.Text) And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
            MsgBox("Incomplete credit transaction", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If MainCashPaid > CDbl(tPayable.Text) And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
            MsgBox("Over payment!!, pls enter customer details", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If RadCash.Checked <> True And RadPOS.Checked <> True And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
            MsgBox("Customer information required", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        Dim i As Integer

        ''cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        If Action = AppAction.Add Then FetchNextNo()
        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        If Action = AppAction.Edit Then
            cmSQL1.CommandText = "SELECT * FROM SalesDetails WHERE OrderNo=" & Val(tOrderNo.Text)
            cmSQL1.CommandType = CommandType.Text
            cnSQL1.Open()
            drSQL1 = cmSQL1.ExecuteReader()
            Do While drSQL1.Read
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "UpdateProduct4Sales"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
                cmSQL.Parameters.AddWithValue("@ProductCode", drSQL1.Item("ProductCode"))
                cmSQL.Parameters.AddWithValue("@Store", drSQL1.Item("Store"))
                cmSQL.ExecuteNonQuery()
            Loop
            drSQL1.Close()
            cmSQL1.Dispose()
            cnSQL1.Close()

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteSales"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
            cmSQL.ExecuteNonQuery()
        End If

        Dim salesValue As Double = CDbl(tTotalValue.Text)   'Val(tPayable.Text) - Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2) + Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)
        If lvSalesList.Items.Count > 0 Then
            Dim TheStore As String = ""
            For i = 0 To lvSalesList.Items.Count - 1
                If TheStore Like "*" & lvSalesList.Items(i).SubItems(12).Text & "*" Then GoTo skipit
                TheStore = TheStore + IIf(TheStore = "", "", ",") + lvSalesList.Items(i).SubItems(12).Text
SkipIt:
            Next i

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertSales"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@CustomerCode", tCustomerCode.Text)
            cmSQL.Parameters.AddWithValue("@CustomerName", tCustomerName.Text)
            cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
            cmSQL.Parameters.AddWithValue("@AmountPaid", MainCashPaid) 'Val(tPaid.Text))
            cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(salesValue, 2))
            cmSQL.Parameters.AddWithValue("@Discount", Math.Round(IIf(chkDiscount.Checked, (CDbl(tDiscount.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text)), 2)) 'Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2))
            cmSQL.Parameters.AddWithValue("@VAT", Math.Round(IIf(chkVAT.Checked, (CDbl(tVat.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tVat.Text)), 2)) 'Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2))
            cmSQL.Parameters.AddWithValue("@AmtInWord", IIf(MainCashPaid = 0, "", Towords(MainCashPaid, "Naira", "Kobo") + " Only"))
            cmSQL.Parameters.AddWithValue("@PaymentMode", IIf(RadCash.Checked, "Cash", IIf(RadPOS.Checked, "POS", IIf(RadCheque.Checked, "Cheque", "Others"))))
            cmSQL.Parameters.AddWithValue("@PaymentDetails", IIf(RadCash.Checked, "", tPayDetails.Text))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ReceiptNo", Val(tReceiptNo.Text))
            cmSQL.Parameters.AddWithValue("@DepositTag", 0)
            cmSQL.Parameters.AddWithValue("@SalesStore", TheStore)

            cmSQL.ExecuteNonQuery()

            'tPayable.Text = Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2)

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertSalesDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@SalesIndex", i + 1)
                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@FixedPrice", CDbl(lvSalesList.Items(i).SubItems(7).Text))
                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(8).Text)
                cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(9).Text)
                cmSQL.Parameters.AddWithValue("@CostPrice", CDbl(lvSalesList.Items(i).SubItems(10).Text))

                cmSQL.Parameters.AddWithValue("@ProductDesc", lvSalesList.Items(i).SubItems(11).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(12).Text)
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(13).Text)

                cmSQL.ExecuteNonQuery()
            Next i
        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Dim Thefile As System.IO.StreamWriter = Nothing
        If chkPrint.Checked = True And InvoiceType = "POS" And lvSalesList.Items.Count > 0 Then

            'writing invoice to file

            If File.Exists(AppPath + "\InvoiceFile.txt") Then
                File.Delete(AppPath + "\InvoiceFile.txt")
            End If

            Thefile = My.Computer.FileSystem.OpenTextFileWriter(AppPath + "\InvoiceFile.txt", True)

            ' file.Close()

            'FileOpen(1, AppPath + "\InvoiceFile.txt", OpenMode.Output)
            Thefile.WriteLine(UCase(sysOwner))
            Thefile.WriteLine(Address)
            Thefile.WriteLine(Phone)

            Thefile.WriteLine("Date: " + Format(dtpDate.Value, "dd-MMM-yyyy"))
            Thefile.WriteLine("Invoice No: " + Trim(Int(tOrderNo.Text)))
            Thefile.WriteLine("Teller: " + Trim(sysUserName))

            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
            Thefile.WriteLine("Item" + Microsoft.VisualBasic.StrDup(14, Chr(32)) + "Qty" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + "Price" + Microsoft.VisualBasic.StrDup(4, Chr(32)) + "Value")
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
            'Thefile.WriteLine("")

            For i = 0 To lvSalesList.Items.Count - 1
                'If chkPrint.Checked = True And InvoiceType = "POS" Then
                Dim TheItem As String = lvSalesList.Items(i).SubItems(3).Text
                If Len(TheItem) <= 15 Then
                    Thefile.WriteLine(TheItem + Microsoft.VisualBasic.StrDup(15 - Len(TheItem) + 3, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(4).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(4).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(4).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(6).Text)
                Else
                    Thefile.WriteLine(Microsoft.VisualBasic.Left(TheItem, 15) + "-" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(4).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(4).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(4).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(6).Text)
                    TheItem = Mid(TheItem, 16)
                    If Len(TheItem) <= 15 Then
                        Thefile.WriteLine(TheItem)
                    Else
                        Do While Len(TheItem) > 15
                            Thefile.WriteLine((Microsoft.VisualBasic.Left(TheItem, 15) + IIf(Len(Mid(TheItem, 16)) > 15, "-", "")))
                            TheItem = Mid(TheItem, 15)
                        Loop
                    End If
                End If
                'End If
            Next i
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
            Thefile.WriteLine("Sales Value:" + Microsoft.VisualBasic.StrDup(6, Chr(32)) + Trim(CDbl(tTotalValue.Text)))
            Thefile.WriteLine("Add VAT:" + Microsoft.VisualBasic.StrDup(10, Chr(32)) + Str(Math.Round(IIf(chkVAT.Checked, CDbl(tVat.Text) * CDbl(tTotalValue.Text), CDbl(tVat.Text)), 2)))
            Thefile.WriteLine("Less Discount:" + Microsoft.VisualBasic.StrDup(5, Chr(32)) + Str(Math.Round(IIf(chkDiscount.Checked, CDbl(tDiscount.Text) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text)), 2)))
            Thefile.WriteLine("Payment:" + Microsoft.VisualBasic.StrDup(19, Chr(32)) + Trim(MainCashPaid)) 'Val(tPaid.Text)
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
            Dim TValue As Double = CDbl(tTotalValue.Text) + IIf(chkVAT.Checked, CDbl(tVat.Text) * CDbl(tTotalValue.Text), CDbl(tVat.Text)) - IIf(chkDiscount.Checked, CDbl(tDiscount.Text) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text))
            'Trim(CDbl(tVat.Text) + CDbl(tTotalValue.Text) - CDbl(tDiscount.Text))
            Thefile.WriteLine("Net Total:" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Str(TValue) + Microsoft.VisualBasic.StrDup(IIf(Len(TValue) > 14, 0, 14 - Len(TValue)), Chr(32)) + Trim(MainCashPaid))
            Thefile.WriteLine("Bal:     :" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Trim(Str(Math.Round(CDbl(TValue) - MainCashPaid))))
            Thefile.WriteLine("Payment Mode:" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + "Cash")
            'Thefile.WriteLine("")
            Thefile.WriteLine("Thanks for your patronage")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.Close()
        End If

        LastOrderNo = Val(tOrderNo.Text)
        If chkPrint.Checked = True And lvSalesList.Items.Count > 0 Then Call PrintTheInvoice()

        flush()
        cmdSave.Enabled = False
        cmdNew.Enabled = True

        Action = AppAction.Add
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = True
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        If Err.Number = 57 Then Thefile.Close()
        myTrans.Rollback()

    End Sub

    Private Sub PrintTheInvoice() 'Optional LPT As String = "LPT1")
        On Error GoTo errhdl
        'Dim LPT As String = cPOS.Text
        'Dim ThePort As Integer = Val(Mid(cPOS.Text, 4))

        'If GetUserReportAccess("Sales Invoice") = False Then Exit Sub

        If InvoiceType = "POS" Then 'POS Invoice
            If Trim(cPOS.Text) = "WinPrn" Then
                If radioLocalPrinters.Checked Then
                    printerName = cboLocalPrinters.SelectedItem.ToString()
                Else
                    'If the network printer radio button is checked, we try to associate the selected network printer.
                    printerName = cboNetworkPrinters.SelectedItem.ToString()
                End If

                Dim printerSettings As New PrinterSettings()
                printerSettings.PrinterName = printerName

                'Here, we try to see if the printer really exists. Otherwise, it's no use to print there.
                If printerSettings.IsValid Then printDoc.PrinterSettings = printerSettings

                printDoc.Print()

            Else                '----open serial port
                'If serialPort.IsOpen Then
                '    serialPort.Close()
                'End If
                'With serialPort
                '    .PortName = cPOS.Text
                '    .BaudRate = 9600
                '    .Parity = IO.Ports.Parity.None
                '    .DataBits = 8
                '    .StopBits = IO.Ports.StopBits.One
                'End With
                'serialPort.Open()
                'serialPort.Close()
                '-------------
                'serialPort
                Dim objStreamReader As StreamReader
                Dim strLine As String = ""

                ' objStreamReader = New StreamReader(AppPath + "\InvoiceFile.txt")
                objStreamReader = New StreamReader(AppPath(+IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt")))

                'strLine = objStreamReader.ReadLine 'Read the first line of text.

                'Continue to read until you reach the end of the file.
                Do While Not strLine Is Nothing
                    ' AccessPort(LPT, strLine)
                    On Error GoTo skipIt
                    strLine = objStreamReader.ReadLine
                    'Read the next line.
                    ' WriteToComPort(ThePort, strLine)
                    ' MsgBox(strLine)
                    AccessPort(cPOS.Text, strLine + vbCrLf)
                    'serialPort.Write(strLine & vbCrLf)

                Loop
SkipIt:

                FileClose(1)
                objStreamReader.Close()


                '            PrintFile(AppPath + "\InvoiceFile.txt")

                'Dim objStreamReader As StreamReader
                'Dim strLine As String
                'FileOpen(1, LPT, OpenMode.Output)

                'objStreamReader = New StreamReader(AppPath + "\InvoiceFile.txt")

                'strLine = objStreamReader.ReadLine 'Read the first line of text.

                ''Continue to read until you reach the end of the file.
                'Do While Not strLine Is Nothing
                '    Print(2, strLine)
                '    strLine = objStreamReader.ReadLine                 'Read the next line.
                'Loop
                'FileClose(1)
                'objStreamReader.Close()
            End If
        Else 'Standard Invoice



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
            jk = IIf(Val(tCopies.Text) = 0, 1, Val(tCopies.Text))
            Dim SelFormular As String = "{RptSales.OrderNo}=" & LastOrderNo  'Val(tOrderNo.Text)

            report.RecordSelectionFormula = SelFormular

            '            report.SetDatabaseLogon(UserID, Password)
            If radioLocalPrinters.Checked Then
                report.PrintOptions.PrinterName = cboLocalPrinters.SelectedItem.ToString()
            Else
                'If the network printer radio button is checked, we try to associate the selected network printer.
                report.PrintOptions.PrinterName = cboNetworkPrinters.SelectedItem.ToString()
            End If

            report.PrintToPrinter(jk, True, 0, 0)

            report.Close()


            If chkReceipt.Checked = True Then


                report.Load(AppPath + "ConfigDir\InvoiceReceipt.rpt")


                For intCounter = 0 To report.Database.Tables.Count - 1
                    report.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
                Next


                jk = IIf(Val(tCopies.Text) = 0, 1, Val(tCopies.Text))
                SelFormular = "{RptSales.OrderNo}=" & LastOrderNo  'Val(tOrderNo.Text)

                report.RecordSelectionFormula = SelFormular

                If radioLocalPrinters.Checked Then
                    report.PrintOptions.PrinterName = cboLocalPrinters.SelectedItem.ToString()
                Else
                    'If the network printer radio button is checked, we try to associate the selected network printer.
                    report.PrintOptions.PrinterName = cboNetworkPrinters.SelectedItem.ToString()
                End If

                report.PrintToPrinter(jk, True, 0, 0)

                report.Close()

            End If


        End If

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
        chkProduct = False
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
        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        tPayable.Text = 0
        tPaid.Text = 0
        tPayDetails.Text = ""
        tCustomerCode.Text = ""
        tCustomerName.Text = ""
        tReceiptNo.Text = ""

        lvSalesList.Items.Clear()

        DoNotExist = False
        RadCash.Checked = True

        tSourceDoc.Text = ""
        tTotalValue.Text = ""

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

    Private Sub tQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tQty.GotFocus
        tQty.Select(0, tQty.Text.Length)
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

    Private Sub cmdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomer.Click
        If GetUserAccessDetails("Setup - Client Register") = False Then Exit Sub
        Dim ChildForm As New FrmClient
        ChildForm.txt = tCustomerCode
        ChildForm.ShowDialog()
        If tCustomerCode.Text <> "" Then tCustomerCode_LostFocus(sender, e)
    End Sub

    Private Sub cmdFetchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFetchCustomer.Click
        On Error GoTo errhdl
        Dim strCaption(5) As String
        Dim intWidth(5) As Integer
        strCaption(0) = "ID"
        intWidth(0) = 40
        strCaption(1) = "Name"
        intWidth(1) = 120
        strCaption(2) = "Address"
        intWidth(2) = 120
        strCaption(3) = "Contact Person"
        intWidth(3) = 100
        strCaption(4) = "Client Type"
        intWidth(4) = 80

        With FrmList
            .frmParent = Me
            .tSelection = "Customer"
            .listQuery = "Customer"
            .Text = "List of Customers"
            .ShowDialog()
        End With
        tCustomerCode.Text = ReturnCode
        tCustomerCode_LostFocus(sender, e)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Function oLoadCustomer(ByVal strValue As String) As Boolean
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        oLoadCustomer = False
        If strValue = "" Then Exit Function

        cmSQL.CommandText = "FetchClient"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ID", strValue)

        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then GoTo SkipIt
        dontRefillCustomer = True
        If drSQL.Read Then
            tCustomerCode.Text = drSQL.Item("ID")
            tCustomerName.Text = drSQL.Item("Name")
            oLoadCustomer = True
        End If
        dontRefillCustomer = False
SkipIt:
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function

    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal SalesPerson As String, ByVal TheStore As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(2).Text = ProductCode And lvSalesList.Items(i).SubItems(9).Text = SalesPerson And lvSalesList.Items(i).SubItems(12).Text = TheStore Then
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
        'Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cSalesPerson.Text, cStore.Text)
        'If PositionInList >= 0 Then
        '    lvSalesList.Items(PositionInList).SubItems(4).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) + CDbl(tQty.Text)
        '    lvSalesList.Items(PositionInList).SubItems(5).Text = Format(IIf((CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) = 0, 0, Math.Round(CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) / 2), "standard")
        '    ' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

        '    lvSalesList.Items(PositionInList).SubItems(6).Text = Format(CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) * CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text), "standard") ' seem dump hen!!, don't delete i know what am doing
        '    lvSalesList.Items(PositionInList).SubItems(8).Text = lvSalesList.Items(PositionInList).SubItems(8).Text + IIf(Trim(tDetails.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(8).Text) = "", "", ",") + tDetails.Text)
        '    lvSalesList.Items(PositionInList).SubItems(9).Text = lvSalesList.Items(PositionInList).SubItems(9).Text + IIf(Trim(cSalesPerson.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(9).Text) = "", "", ",") + cSalesPerson.Text)

        'Else

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
        LvItems.SubItems.Add(cSalesPerson.Text)
        LvItems.SubItems.Add(CDbl(cCostPrice.Tag))
        LvItems.SubItems.Add(tItemDesc.Text)
        LvItems.SubItems.Add(cStore.Text)
        LvItems.SubItems.Add(tItemCode.Tag) 'TransType

        lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

        'End If


        calculatePayable()

        If Trim(cPole.Text) <> "" Then
            '' AccessPort(cPole.Text, "")
            '' AccessPort(cPole.Text, "Your Charge is " + Chr(10) + Chr(13) + Chr(10) + Chr(13) + tPayable.Text + " Naira")
            'AccessPort(cPole.Text, "Your Charge is " + tPayable.Text + " Naira")
            '' AccessPort(cPole.Text, tPayable.Text + " Naira")
            Print2ComPort(cPole.Text, "                                                                            " + Chr(13))
            'Print2ComPort(cPole.Text, "Your Charge is " + Chr(13))
            Print2ComPort(cPole.Text, tPayable.Text + " Naira")
        End If


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
        tPayable.Text = Format(Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2), "standard")
        'If Trim(cPole.Text) <> "" Then
        '    AccessPort(cPole.Text, "")
        '    AccessPort(cPole.Text, "Your Charge is" + Chr(10) + Chr(13))
        '    AccessPort(cPole.Text, tPayable.Text + " Naira")
        'End If

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub tTotalValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tTotalValue.TextChanged
        calculatePayable()
    End Sub

    Private Sub tVat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tVat.TextChanged
        calculatePayable()
    End Sub

    Private Sub tDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tDiscount.TextChanged
        calculatePayable()
    End Sub

    Private Sub tPayable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tPayable.TextChanged
        tPaid.Text = tPayable.Text
    End Sub

    Private Sub chkVAT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVAT.CheckedChanged
        calculatePayable()
    End Sub

    Private Sub chkDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiscount.CheckedChanged
        calculatePayable()
    End Sub

    Private Sub CmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOpen.Click
        On Error GoTo handler

        If lvSalesList.SelectedItems(0).SubItems(12).Text <> cStore.Text Then cStore.Text = lvSalesList.SelectedItems(0).SubItems(12).Text
        chkProduct = False

        GetProductByCode4Receipt(lvSalesList.SelectedItems(0).SubItems(2).Text)

        tQty.Tag = tQty.Tag + lvSalesList.SelectedItems(0).SubItems(4).Text
        tQty.Text = 1
        tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
        tQty.Minimum = 1
        tQty.Maximum = Val(tQty.Tag + lvSalesList.SelectedItems(0).SubItems(4).Text)

        tDetails.Text = lvSalesList.SelectedItems(0).SubItems(8).Text
        cSalesPerson.Text = lvSalesList.SelectedItems(0).SubItems(9).Text
        tTotalValue.Text = tTotalValue.Text - (CDbl(lvSalesList.SelectedItems(0).SubItems(4).Text) * CDbl(lvSalesList.SelectedItems(0).SubItems(5).Text))

        tQty.Text = lvSalesList.SelectedItems(0).SubItems(4).Text
        tSellPrice.Text = Math.Round(CDbl(lvSalesList.SelectedItems(0).SubItems(5).Text), 2)


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
        cmdNew.Enabled = ModuleAdd
        Action = ModuleAdd
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = True
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

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        'Dim strValue As String
        'Dim strPrompt As String
        'Dim strCaption(6) As String
        'Dim intWidth(6) As Integer
        'strCaption(0) = "Order No"
        'strCaption(1) = "Date"
        'strCaption(2) = "No of Items"
        'strCaption(3) = "Order Value"
        'strCaption(4) = "Amt Paid"
        'strCaption(5) = "Sales Person"

        'intWidth(0) = 70
        'intWidth(1) = 80
        'intWidth(2) = 100
        'intWidth(3) = 80
        'intWidth(4) = 80
        'intWidth(5) = 80
        Action = AppAction.Edit
        Dim strOrder As String = InputBox("Enter Order No", "Sales", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            ReturnOrderNo = Val(strOrder)
            LoadEditableOrder(ReturnOrderNo)
            Exit Sub
        End If
        With FrmList
            .Text = "Edit Stock Sales"
            .frmParent = Me
            .tSelection = "Edit Sales"
            .listQuery = "Edit Sales"
            .Text = "List of Sales"
            .qryPrm = If(ST_IgnoreStoreAssignment = False, cStore.Text, "@?ALL?@")
            .ShowDialog()
        End With
        If ReturnOrderNo <> 0 Then LoadEditableOrder(ReturnOrderNo)
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub LoadEditableOrder(ByVal TheOrderNo As Long)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        flush()

        cmSQL.CommandText = "FetchSales"
        cmSQL.Parameters.AddWithValue("@OrderNo", TheOrderNo)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                If drSQL.Item("DepositTag") > 0 Then
                    MsgBox("This order cannot be edited...Bank Deposit Transaction exist", MsgBoxStyle.Information, strApptitle)
                    'cmSQL.Connection.Close()
                    cmSQL.Dispose()
                    drSQL.Close()
                    'cnSQL.Close()
                    'cnSQL.Dispose()

                    flush()
                    lvSalesList.Items.Clear()
                    cmdNew.Enabled = True
                    cmdSave.Enabled = False
                    tItemCode.Focus()
                    ReturnOrderNo = 0
                    cmdNew.Enabled = ModuleAdd
                    Action = ModuleAdd

                    Exit Sub
                End If

                If drSQL.Item("RefundQty") > 0 Then
                    MsgBox("This order cannot be edited...Refund Transaction exist", MsgBoxStyle.Information, strApptitle)
                    'cmSQL.Connection.Close()
                    cmSQL.Dispose()
                    drSQL.Close()
                    'cnSQL.Close()
                    'cnSQL.Dispose()

                    flush()
                    lvSalesList.Items.Clear()
                    cmdNew.Enabled = True
                    cmdSave.Enabled = False
                    tItemCode.Focus()
                    ReturnOrderNo = 0
                    cmdNew.Enabled = ModuleAdd
                    Action = ModuleAdd
                    Exit Sub
                End If

                dtpDate.Text = drSQL.Item("Date")
                tDiscount.Text = drSQL.Item("Discount")
                chkDiscount.Checked = False
                tVat.Text = drSQL.Item("Vat")
                chkVAT.Checked = False
                tDetails.Text = drSQL.Item("Details")
                tOrderNo.Text = drSQL.Item("OrderNo")
                tSourceDoc.Text = drSQL.Item("Sourcedoc")
                If drSQL.Item("PaymentMode") = "Cash" Then RadCash.Checked = True
                If drSQL.Item("PaymentMode") = "Cheque" Then RadCheque.Checked = True
                If drSQL.Item("PaymentMode") = "POS" Then RadPOS.Checked = True
                If drSQL.Item("PaymentMode") = "Others" Then RadOthers.Checked = True
                tPayDetails.Text = drSQL.Item("PaymentDetails")
                dontRefillCustomer = True
                tCustomerCode.Text = ChkNull(drSQL.Item("CustomerCode"))
                tCustomerName.Text = ChkNull(drSQL.Item("CustomerName"))
                dontRefillCustomer = False
                tPaid.Tag = drSQL.Item("AmountPaid")
                tReceiptNo.Text = drSQL.Item("ReceiptNo")
                LastOrderNo = drSQL.Item("OrderNo")
            End If
        Else
            MsgBox("Order No do not exist", MsgBoxStyle.Information, strApptitle)
        End If

        drSQL.Close()
        drSQL = cmSQL.ExecuteReader()

        Dim LvItems As New ListViewItem
        Do While drSQL.Read

            If drSQL.Item("RefundQty") > 0 Then
                MsgBox("This order cannot be edited...Refund Transaction exist", MsgBoxStyle.Information, strApptitle)
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                drSQL.Close()
                'cnSQL.Close()
                'cnSQL.Dispose()

                flush()
                lvSalesList.Items.Clear()
                cmdNew.Enabled = True
                cmdSave.Enabled = False
                tItemCode.Focus()
                ReturnOrderNo = 0
                cmdNew.Enabled = ModuleAdd
                Action = ModuleAdd
                Exit Sub
            End If

            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(drSQL.Item("CategoryName"))
            LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("SellPrice"), 2), "Standard"))
            LvItems.SubItems.Add(Format(drSQL.Item("Qty") * drSQL.Item("SellPrice"), "Standard"))
            LvItems.SubItems.Add(drSQL.Item("FixedPrice"))
            LvItems.SubItems.Add(drSQL.Item("Details"))
            LvItems.SubItems.Add(drSQL.Item("SalesPerson"))
            LvItems.SubItems.Add(drSQL.Item("CostPrice"))
            LvItems.SubItems.Add(drSQL.Item("ProductDesc"))
            LvItems.SubItems.Add(drSQL.Item("Store"))
            LvItems.SubItems.Add(drSQL.Item("TransType"))
            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

            tTotalValue.Text = Format(CDbl(tTotalValue.Text) + drSQL.Item("Qty") * drSQL.Item("SellPrice"), "standard")


        Loop
        tPaid.Text = Format(Math.Round(tPaid.Tag, 2), "standard")
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()


        cmdSave.Enabled = True
        cmdNew.Enabled = False

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub tSellPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tSellPrice.GotFocus
        If (Not String.IsNullOrEmpty(tSellPrice.Text)) Then
            tSellPrice.SelectionStart = 0
            tSellPrice.SelectionLength = tSellPrice.Text.Length
        End If
    End Sub
    Private Sub tSellPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSellPrice.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tDetails.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub

    Private Sub chkPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrint.CheckedChanged
        PanCopies.Visible = chkPrint.Checked
        Pan.Visible = chkPrint.Checked
    End Sub

    Private Sub tReceiptNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tReceiptNo.LostFocus
        If Val(tReceiptNo.Text) <> 0 Then GetDepositPaymentDetails(Val(tReceiptNo.Text))
    End Sub

    Private Sub GetDepositPaymentDetails(ByVal TheTag As Integer)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        'lvProduct.Items.Clear()

        cmSQL.CommandText = "SELECT PaymentTag, PayType, ClientCode, ClientName FROM Payments WHERE PayType='Receiveable' AND PaymentTag=" & TheTag
        cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows Then
            If drSQL.Read Then
                dontRefillCustomer = True
                tCustomerCode.Text = drSQL.Item("ClientCode")
                tCustomerName.Text = drSQL.Item("ClientName")
                dontRefillCustomer = False
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
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub tPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tPaid.TextChanged
        tChange.Text = Format(Math.Round(CDbl(tPaid.Text) - CDbl(tPayable.Text), 2), "standard")
        If CDbl(tChange.Text) < 0 Then tChange.Text = 0
    End Sub

    Private Sub mnuPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintInvoice.Click
        If LastOrderNo <> 0 Then Call PrintTheInvoice()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        MsgBox(Me.Width)
    End Sub
    Private Sub cInvoiceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cInvoiceType.SelectedIndexChanged
        InvoiceType = cInvoiceType.Text
    End Sub
    Private Sub cmdClosePanelPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanelPrinter.Click
        PanPrinter.Visible = False
    End Sub

    Private Sub lnkPortPrinter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPortPrinter.LinkClicked
        PanPrinter.Visible = True

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
            PanPrinter.Top = tblMain.Top + tblDetails.Top + lnkPortPrinter.Bottom + 55
            PanPrinter.Left = tblMain.Left + tblDetails.Left + PanPayment.Left + lnkPortPrinter.Left + 205

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
            PanPrinter.Top = tblDetails.Top + lnkPortPrinter.Bottom + 55
            PanPrinter.Left = tblDetails.Left + PanPayment.Left + lnkPortPrinter.Left + 205

            Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

        End If
    End Sub
    Private Sub lnkSalesPerson_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSalesPerson.LinkClicked
        If GetUserAccessDetails("Setup - Sales Person") = False Then Exit Sub
        Dim ChildForm As New StkFrmSalesPerson
        ChildForm.ShowDialog()
        oLoadSalesPerson()
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

        'If radContaining.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%' ORDER BY ProductName"
        'If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%' ORDER BY ProductName"
        'If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "' ORDER BY ProductName"
        'If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName  = '" + strQry & "' ORDER BY ProductName"

        If radContaining.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "' ORDER BY StoreItems.ProductName"
        If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName  = '" + strQry & "' ORDER BY StoreItems.ProductName"

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

        If IsNumeric(ProductCode) Then
        End If
        Dim g As Integer = InStr(ProductCode, ".00")
        If g > 0 Then
            ProductCode = Mid(ProductCode, 1, g - 1)
        End If


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
                If chkWithCostPrice.Checked = True Then
                    tSellPrice.Text = Math.Round(drSQL.Item("CostPriceNew"), 2)
                Else
                    tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                End If
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
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE INNER JOIN ASSIGNEDSTORE ON STORE.Store = ASSIGNEDSTORE.Store WHERE NonSelling<>1 AND ASSIGNEDSTORE.UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE WHERE NonSelling<>1 ORDER BY [Default] DESC"
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
    Private Sub PanPrinter_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanPrinter.MouseDown
        StoredX = e.X
        StoredY = e.Y
        PanPrinter.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanPrinter_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanPrinter.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanPrinter.Top = PanPrinter.Top - (StoredY - e.Y)
            PanPrinter.Left = PanPrinter.Left - (StoredX - e.X)
        End If
        PanPrinter.Cursor = Cursors.Default
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
        If e.RowIndex < 0 Then Exit Sub
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

    Private Sub cCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cCustomerName.SelectedIndexChanged
        dontRefillCustomer = True
        tCustomerName.Text = GetIt4Me(cCustomerName.Text, " - ")
        tCustomerCode.Text = Mid(cCustomerName.Text, Len(tCustomerName.Text) + 4)
        dontRefillCustomer = False
    End Sub
    Private Sub tCustomerCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tCustomerCode.LostFocus
        tCustomerName.Text = ""
        If oLoadCustomer(tCustomerCode.Text) = False And Trim(tCustomerCode.Text) <> "" Then
            MsgBox("Customer do not exist", MsgBoxStyle.Information, strApptitle)
            tCustomerCode.Text = ""
            ' tCustomerCode.Focus()
        Else
            'cmdFetchCustomer.Focus()
        End If
        chkPayee = True
    End Sub

    Private Sub tQty_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.ValueChanged

    End Sub

    Private Sub stkFrmSales1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '   If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tCustomerName.TextChanged
        fillCustomers(tCustomerName.Text)
    End Sub

    Sub fillCustomers(ByVal filterstring As String)
        On Error GoTo handler

        If filterstring = "" Then Exit Sub
        If dontRefillCustomer = True Then Exit Sub
        cCustomerName.Items.Clear()
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader


        cCustomerName.Items.Clear()
        cmSQL.CommandText = "SELECT DISTINCT [ID],[Name],ClientType FROM Client WHERE [Name] Like '%" & filterstring & "%' ORDER BY [Name]"
        '   cmSQL.CommandText = "SELECT DISTINCT [ID],[Name],ClientType FROM Client WHERE [Name] Like '%" & filterstring & "%' IS NOT NULL and  ORDER BY ClientType,[Name]"

        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()
        ' If drSQL.HasRows = False Then GoTo skipIt
        Do While drSQL.Read
            cCustomerName.Items.Add(drSQL.Item("Name") + " - " + drSQL.Item("ID"))
        Loop
        'skipIt:

        cmSQL.Dispose()
        drSQL.Close()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Function GetProductByCode4Receipt(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl


        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        GetProductByCode4Receipt = False

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

        cmSQL.CommandText = "FetchActiveStoreItemsPerProductCode"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        ' cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            GetProductByCode4Receipt = False
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
            GetProductByCode4Receipt = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        GetProductDetails4Receipt(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Function

    Private Sub GetProductDetails4Receipt(ByVal ProductCode As String)
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

        'cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerStore"
        'cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        'cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandText = "SELECT * FROM StockQty WHERE Store='" & cStore.Text & "' AND ProductCode='" & ProductCode & "' AND  Discontinue=0"

        cmSQL.CommandType = CommandType.Text
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
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        PrintTheInvoice()
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

    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Static MyNewAcctFile As String = IO.File.ReadAllText(AppPath + IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt"))
        Dim printFont As New Font("Arial", 9, FontStyle.Regular)
        Dim charsFitted As Integer
        Dim linesFilled As Integer
        e.Graphics.MeasureString(MyNewAcctFile, printFont, New SizeF(e.MarginBounds.Width, e.MarginBounds.Height), Drawing.StringFormat.GenericTypographic, charsFitted, linesFilled)
        e.Graphics.DrawString(MyNewAcctFile, printFont, Brushes.Black, e.MarginBounds, Drawing.StringFormat.GenericTypographic)

        MyNewAcctFile = MyNewAcctFile.Substring(charsFitted)

        If MyNewAcctFile <> "" Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            MyNewAcctFile = IO.File.ReadAllText(AppPath + IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt"))
        End If

    End Sub
End Class