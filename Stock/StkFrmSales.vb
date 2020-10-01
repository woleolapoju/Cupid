Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Public Class StkFrmSales
    Public ReturnCode As String = ""
    Dim Action As AppAction
    Private printFont As Font
    Private streamToPrint As StreamReader
    Public Shared FullfilePath As String
    ' Dim WithEvents serialPort As New IO.Ports.SerialPort

    Public ReturnOrderNo As Integer
    Public LastOrderNo As Integer = 0
    Private Sub FrmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oLoadCategory()
        oLoadSalesPerson()

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

        mnuEdit.Enabled = ModuleEdit
        If ModuleEdit Then
            cCostPrice.Visible = True
            tCostPrice.Visible = True
        End If
        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True


    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()

        cmSQL.CommandText = "SELECT DISTINCT Categorycode, CategoryName FROM Product WHERE UnitInStock>0 ORDER BY CategoryCode"

        cmSQL.CommandType = CommandType.Text
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        LvItems = New ListViewItem("ALL")
        LvItems.SubItems.Add("")
        lvCategory.Items.AddRange(New ListViewItem() {LvItems})
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("CategoryCode").ToString)
            LvItems.SubItems.Add(drSQL.Item("CategoryName").ToString)
            lvCategory.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Dim i As Integer
        For i = 0 To lvCategory.Items.Count - 1
            If i Mod 2 <> 0 Then
                lvCategory.Items(i).BackColor = Color.LightCyan
            Else
                lvCategory.Items(i).BackColor = Color.Azure
            End If
        Next

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

        cmSQL.CommandText = "FetchAvailableProductByCategory"
        cmSQL.Parameters.AddWithValue("@CategoryCode", TheCat)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("ProductCode").ToString)
            LvItems.SubItems.Add(drSQL.Item("ProductName").ToString)
            lvProduct.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Dim i As Integer
        For i = 0 To lvProduct.Items.Count - 1
            If i Mod 2 <> 0 Then
                lvProduct.Items(i).BackColor = Color.LightCyan
            Else
                lvProduct.Items(i).BackColor = Color.Azure
            End If
        Next


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
        oLoadProduct(lvCategory.SelectedItems(0).Text)
    End Sub

    Private Sub lvProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProduct.Click
        On Error Resume Next
        LoadProductDetails(lvProduct.SelectedItems(0).Text)
    End Sub

    Private Sub lvProduct_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvProduct.ColumnClick
        On Error GoTo handler
        lvProduct.ListViewItemSorter = New ListViewItemComparer(e.Column)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub CmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFind.Click
        On Error GoTo handler
        If Trim(tFind.Text) = "" Then Exit Sub
        Dim startIndex As Integer = lvProduct.SelectedIndices.Item(0) + 1
resumeIt:
        Dim item1 As ListViewItem = lvProduct.FindItemWithText(tFind.Text, True, startIndex) ', True, 0, False)
        If Not (item1 Is Nothing) Then
            item1.EnsureVisible()
            item1.Selected = True
            lvProduct.Focus()
        Else
            MsgBox("No match found")
            Exit Sub
        End If
        Exit Sub
handler:
        If Err.Number = 5 Then
            startIndex = 0
            GoTo resumeIt
        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If

    End Sub

    Private Sub tFind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tFind.KeyPress
        If e.KeyChar = Chr(13) Then
            CmdFind_Click(sender, e)
        End If
    End Sub
    Private Sub RadCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCash.CheckedChanged
        PanPayType.Visible = False
        tPayDetails.Text = ""
    End Sub

    Private Sub RadCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCheque.CheckedChanged
        PanPayType.Visible = True
        tPayDetails.Focus()
    End Sub

    Private Sub RadOthers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadOthers.CheckedChanged
        PanPayType.Visible = True
        tPayDetails.Focus()
    End Sub
    Private Function LoadProductDetails(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        LoadProductDetails = False

        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""
        tQty.Tag = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchAvailableProductByProduct"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            LoadProductDetails = False
            tItemCode.Focus()
            cmSQL.Dispose()
            drSQL.Close()
            Exit Function
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("CategoryName")
                tCategoryName.Tag = drSQL.Item("CategoryCode")

                'tStockLevel.Text = drSQL.Item("UnitInStock")
                tQty.Tag = drSQL.Item("UnitInStock")
                tQty.Text = 1
                tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                tQty.Minimum = 1
                tQty.Maximum = Val(tQty.Tag)

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
            LoadProductDetails = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

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
        tItemCode.Focus()
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
        Dim drSQL As SqlDataReader

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
            If Val(tChange.Text) <> 0 Then
                If Val(tChange.Text) < 0 Then
                    MainCashPaid = Val(tPaid.Text)
                Else
                    MainCashPaid = Val(tPaid.Text) - Val(tChange.Text)
                End If
            Else
                MainCashPaid = Val(tPaid.Text)
            End If
        Else
            MainCashPaid = Val(tPaid.Text)
        End If

        If MainCashPaid < Val(tPayable.Text) And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
            MsgBox("Incomplete credit transaction", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If MainCashPaid > Val(tPayable.Text) And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
            MsgBox("Over payment!, pls enter customer details", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If RadCash.Checked <> True And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
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
        Dim salesValue As Double = 0
        If lvSalesList.Items.Count > 0 Then
            salesValue = Val(tTotalValue.Text) 'Val(tPayable.Text) - Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2) + Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)
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
            cmSQL.Parameters.AddWithValue("@Discount", Math.Round(IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2)) 'Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2))
            cmSQL.Parameters.AddWithValue("@VAT", Math.Round(IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * Val(tTotalValue.Text), Val(tVat.Text)), 2)) 'Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2))
            cmSQL.Parameters.AddWithValue("@AmtInWord", IIf(MainCashPaid = 0, "", Towords(MainCashPaid, "Naira", "Kobo") + " Only"))
            cmSQL.Parameters.AddWithValue("@PaymentMode", IIf(RadCash.Checked, "Cash", IIf(RadCheque.Checked, "Cheque", "Others")))
            cmSQL.Parameters.AddWithValue("@PaymentDetails", IIf(RadCash.Checked, "", tPayDetails.Text))
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ReceiptNo", Val(tReceiptNo.Text))
            cmSQL.Parameters.AddWithValue("@DepositTag", 0)

            cmSQL.ExecuteNonQuery()

            'tPayable.Text = Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2)

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertSalesDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@SalesIndex", i + 1)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(4).Text)
                cmSQL.Parameters.AddWithValue("@CategoryCode", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", Val(lvSalesList.Items(i).SubItems(6).Text))
                cmSQL.Parameters.AddWithValue("@FixedPrice", Val(lvSalesList.Items(i).SubItems(8).Text))
                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(9).Text)
                cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(10).Text)
                cmSQL.Parameters.AddWithValue("@CostPrice", Val(lvSalesList.Items(i).SubItems(11).Text))
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
                Dim TheItem As String = lvSalesList.Items(i).SubItems(4).Text
                If Len(TheItem) <= 15 Then
                    Thefile.WriteLine(TheItem + Microsoft.VisualBasic.StrDup(15 - Len(TheItem) + 3, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(6).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(6).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(6).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(7).Text)
                Else
                    Thefile.WriteLine(Microsoft.VisualBasic.Left(TheItem, 15) + "-" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(6).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(6).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(6).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(7).Text)
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
            Thefile.WriteLine("Sales Value:" + Microsoft.VisualBasic.StrDup(6, Chr(32)) + Trim(Val(tTotalValue.Text)))
            Thefile.WriteLine("Add VAT:" + Microsoft.VisualBasic.StrDup(10, Chr(32)) + Str(Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)))
            Thefile.WriteLine("Less Discount:" + Microsoft.VisualBasic.StrDup(5, Chr(32)) + Str(Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2)))
            Thefile.WriteLine("Payment:" + Microsoft.VisualBasic.StrDup(19, Chr(32)) + Trim(MainCashPaid)) 'Val(tPaid.Text)
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
            Dim TValue As Double = Val(tTotalValue.Text) + IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)) - IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text))
            'Trim(Val(tVat.Text) + Val(tTotalValue.Text) - Val(tDiscount.Text))
            Thefile.WriteLine("Net Total:" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Str(TValue) + Microsoft.VisualBasic.StrDup(IIf(Len(TValue) > 14, 0, 14 - Len(TValue)), Chr(32)) + Trim(MainCashPaid))
            Thefile.WriteLine("Bal:     :" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Trim(Str(Math.Round(Val(TValue) - MainCashPaid))))
            Thefile.WriteLine("Payment Mode:" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + IIf(RadCash.Checked, "Cash", IIf(RadCheque.Checked, "Cheque", "Others")))
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

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        If Err.Number = 57 Then Thefile.Close()
        myTrans.Rollback()

    End Sub

    '    Private Sub OldSave()
    '        On Error GoTo handler

    '        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
    '        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
    '        Dim drSQL As SqlDataReader

    '        Dim cnSQL1 As SqlConnection = New SqlConnection(strConnect)
    '        Dim cmSQL1 As SqlCommand = cnSQL1.CreateCommand
    '        Dim drSQL1 As SqlDataReader

    '        Dim cmSQL2 As SqlCommand = cnSQL1.CreateCommand
    '        Dim drSQL2 As SqlDataReader

    '        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub

    '        Dim MainCashPaid As Double = 0

    '        If RadCash.Checked <> True And Trim(tPayDetails.Text) = "" Then
    '            MsgBox("Please enter payment details for the mode chosen", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If
    '        If Val(tPaid.Text) < 0 Then
    '            MsgBox("Amount paid cannot be less than zero (0)", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If
    '        If Val(tPaid.Text) = 0 And RadCash.Checked = False Then
    '            MsgBox("Amount paid cannot be zero (0) for non-cash payment", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If
    '        If chkGiveChange.Checked = True Then
    '            If Val(tChange.Text) <> 0 Then
    '                If Val(tChange.Text) < 0 Then
    '                    MainCashPaid = Val(tPaid.Text)
    '                Else
    '                    MainCashPaid = Val(tPaid.Text) - Val(tChange.Text)
    '                End If
    '            Else
    '                MainCashPaid = Val(tPaid.Text)
    '            End If
    '        Else
    '            MainCashPaid = Val(tPaid.Text)
    '        End If

    '        If MainCashPaid < Val(tPayable.Text) And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
    '            MsgBox("Incomplete credit transaction", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If

    '        If MainCashPaid > Val(tPayable.Text) And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
    '            MsgBox("Over payment!, pls enter customer details", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If

    '        If RadCash.Checked <> True And Trim(tCustomerCode.Text) = "" And Trim(tCustomerName.Text) = "" Then
    '            MsgBox("Customer information required", MsgBoxStyle.Information, strApptitle)
    '            Exit Sub
    '        End If


    '        Dim i As Integer

    '        ''cnSQL.Open()

    '        Dim myTrans As SqlClient.SqlTransaction

    '        If Action = AppAction.Add Then FetchNextNo()
    '        Dim Thefile As System.IO.StreamWriter = Nothing
    '        If chkPrint.Checked = True And InvoiceType = "POS" Then

    '            'writing invoice to file

    '            If File.Exists(AppPath + "\InvoiceFile.txt") Then
    '                File.Delete(AppPath + "\InvoiceFile.txt")
    '            End If

    '            Thefile = My.Computer.FileSystem.OpenTextFileWriter(AppPath + "\InvoiceFile.txt", True)

    '            ' file.Close()

    '            'FileOpen(1, AppPath + "\InvoiceFile.txt", OpenMode.Output)
    '            Thefile.WriteLine(UCase(sysOwner))
    '            Thefile.WriteLine(Address)
    '            Thefile.WriteLine(Phone)

    '            Thefile.WriteLine("Date: " + Format(dtpDate.Value, "dd-MMM-yyyy"))
    '            Thefile.WriteLine("Invoice No: " + Trim(Int(tOrderNo.Text)))
    '            Thefile.WriteLine("Teller: " + Trim(sysUserName))

    '            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
    '            Thefile.WriteLine("Item" + Microsoft.VisualBasic.StrDup(14, Chr(32)) + "Qty" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + "Price" + Microsoft.VisualBasic.StrDup(4, Chr(32)) + "Value")
    '            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
    '            'Thefile.WriteLine("")
    '        End If

    '        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
    '        cmSQL.Transaction = myTrans


    '        If Action = AppAction.Edit Then
    '            cmSQL1.CommandText = "SELECT * FROM SalesDetails WHERE OrderNo=" & Val(tOrderNo.Text)
    '            cmSQL1.CommandType = CommandType.Text
    '            cnSQL1.Open()
    '            drSQL1 = cmSQL1.ExecuteReader()
    '            Do While drSQL1.Read
    '                cmSQL.Parameters.Clear()
    '                cmSQL.CommandText = "UpdateProduct4Sales"
    '                cmSQL.CommandType = CommandType.StoredProcedure
    '                cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
    '                cmSQL.Parameters.AddWithValue("@ProductCode", drSQL1.Item("ProductCode"))
    '                cmSQL.ExecuteNonQuery()
    '            Loop
    '            drSQL1.Close()
    '            cmSQL1.Dispose()
    '            cnSQL1.Close()

    '            cmSQL.Parameters.Clear()
    '            cmSQL.CommandText = "DeleteSales"
    '            cmSQL.CommandType = CommandType.StoredProcedure
    '            cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
    '            cmSQL.ExecuteNonQuery()
    '        End If

    '        If lvSalesList.Items.Count > 0 Then

    '            cmSQL.Parameters.Clear()
    '            cmSQL.CommandText = "InsertSales"
    '            cmSQL.CommandType = CommandType.StoredProcedure
    '            cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
    '            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
    '            cmSQL.Parameters.AddWithValue("@CustomerCode", tCustomerCode.Text)
    '            cmSQL.Parameters.AddWithValue("@CustomerName", tCustomerName.Text)
    '            cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
    '            cmSQL.Parameters.AddWithValue("@AmountPaid", MainCashPaid) 'Val(tPaid.Text))
    '            cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(Val(tTotalValue.Text), 2))
    '            cmSQL.Parameters.AddWithValue("@Discount", Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2))
    '            cmSQL.Parameters.AddWithValue("@VAT", Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2))
    '            cmSQL.Parameters.AddWithValue("@AmtInWord", Towords(MainCashPaid, "Naira", "Kobo"))
    '            cmSQL.Parameters.AddWithValue("@PaymentMode", IIf(RadCash.Checked, "Cash", IIf(RadCheque.Checked, "Cheque", "Others")))
    '            cmSQL.Parameters.AddWithValue("@PaymentDetails", IIf(RadCash.Checked, "", tPayDetails.Text))
    '            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
    '            cmSQL.Parameters.AddWithValue("@ReceiptNo", Val(tReceiptNo.Text))
    '            cmSQL.Parameters.AddWithValue("@DepositTag", 0)

    '            cmSQL.ExecuteNonQuery()

    '            For i = 0 To lvSalesList.Items.Count - 1
    '                cmSQL.Parameters.Clear()
    '                cmSQL.CommandText = "InsertSalesDetails"
    '                cmSQL.CommandType = CommandType.StoredProcedure
    '                cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
    '                cmSQL.Parameters.AddWithValue("@SalesIndex", i + 1)
    '                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(3).Text)
    '                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(4).Text)
    '                cmSQL.Parameters.AddWithValue("@CategoryCode", lvSalesList.Items(i).SubItems(1).Text)
    '                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(2).Text)
    '                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(5).Text))
    '                cmSQL.Parameters.AddWithValue("@SellPrice", Val(lvSalesList.Items(i).SubItems(6).Text))
    '                cmSQL.Parameters.AddWithValue("@FixedPrice", Val(lvSalesList.Items(i).SubItems(8).Text))
    '                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(9).Text)
    '                cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(10).Text)
    '                cmSQL.Parameters.AddWithValue("@CostPrice", Val(lvSalesList.Items(i).SubItems(11).Text))
    '                cmSQL.ExecuteNonQuery()

    '                If chkPrint.Checked = True And InvoiceType = "POS" Then


    '                    Dim TheItem As String = lvSalesList.Items(i).SubItems(4).Text
    '                    If Len(TheItem) <= 15 Then

    '                        Thefile.WriteLine(TheItem + Microsoft.VisualBasic.StrDup(15 - Len(TheItem) + 3, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(6).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(6).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(6).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(7).Text)

    '                    Else
    '                        Thefile.WriteLine(Microsoft.VisualBasic.Left(TheItem, 15) + "-" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(6).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(6).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(6).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(7).Text)
    '                        TheItem = Mid(TheItem, 16)
    '                        If Len(TheItem) <= 15 Then
    '                            Thefile.WriteLine(TheItem)
    '                        Else
    '                            Do While Len(TheItem) > 15
    '                                Thefile.WriteLine((Microsoft.VisualBasic.Left(TheItem, 15) + IIf(Len(Mid(TheItem, 16)) > 15, "-", "")))
    '                                TheItem = Mid(TheItem, 15)
    '                            Loop
    '                        End If
    '                    End If
    '                End If


    '            Next i
    '        End If


    '        myTrans.Commit()

    '        'cmSQL.Connection.Close()
    '        cmSQL.Dispose()
    '        'cnSQL.Close()
    '        'cnSQL.Dispose()


    '        If chkPrint.Checked = True And InvoiceType = "POS" Then
    '            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
    '            Thefile.WriteLine("Sales Value:" + Microsoft.VisualBasic.StrDup(6, Chr(32)) + Trim(Val(tTotalValue.Text)))
    '            Thefile.WriteLine("Add VAT:" + Microsoft.VisualBasic.StrDup(10, Chr(32)) + Str(Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)))
    '            Thefile.WriteLine("Less Discount:" + Microsoft.VisualBasic.StrDup(5, Chr(32)) + Str(Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2)))
    '            Thefile.WriteLine("Payment:" + Microsoft.VisualBasic.StrDup(19, Chr(32)) + Trim(MainCashPaid)) 'Val(tPaid.Text)
    '            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
    '            Dim TValue As Double = Val(tTotalValue.Text) + IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)) - IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text))
    '            'Trim(Val(tVat.Text) + Val(tTotalValue.Text) - Val(tDiscount.Text))
    '            Thefile.WriteLine("Net Total:" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Str(TValue) + Microsoft.VisualBasic.StrDup(IIf(Len(TValue) > 14, 0, 14 - Len(TValue)), Chr(32)) + Trim(MainCashPaid))
    '            Thefile.WriteLine("Bal:     :" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Trim(Str(Math.Round(Val(TValue) - MainCashPaid))))
    '            Thefile.WriteLine("Payment Mode:" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + IIf(RadCash.Checked, "Cash", IIf(RadCheque.Checked, "Cheque", "Others")))
    '            'Thefile.WriteLine("")
    '            Thefile.WriteLine("Thanks for your patronage")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.WriteLine("")
    '            Thefile.Close()
    '        End If



    '        If chkPrint.Checked = True And lvSalesList.Items.Count > 0 Then Call PrintTheInvoice()

    '        flush()
    '        cmdSave.Enabled = False
    '        cmdNew.Enabled = True

    '        Action = AppAction.Add

    '        Exit Sub
    '        Resume
    'handler:

    '        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    '        If Err.Number = 57 Then Thefile.Close()
    '        myTrans.Rollback()
    'End Sub
    Private Sub PrintTheInvoice() 'Optional LPT As String = "LPT1")
        On Error GoTo errhdl
        'Dim LPT As String = cPOS.Text
        'Dim ThePort As Integer = Val(Mid(cPOS.Text, 4))

        'If GetUserReportAccess("Sales Invoice") = False Then Exit Sub

        If InvoiceType = "POS" And Trim(cPOS.Text) <> "" Then 'POS Invoice

            '----open serial port
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

            objStreamReader = New StreamReader(AppPath + "\InvoiceFile.txt")

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
        LoadProductDetails(lvProduct.SelectedItems(0).Text)
    End Sub

    Private Sub tProductCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tItemCode.KeyPress
        If e.KeyChar = Chr(13) Then
            If LoadProductDetails(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
        End If
    End Sub

    Private Sub tItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tItemCode.LostFocus
        On Error GoTo handler
        LoadProductDetails(tItemCode.Text)
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
    Private Sub cmdSalesPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalesPerson.Click
        If GetUserAccessDetails("Setup - Sales Person") = False Then Exit Sub
        ' Dim ChildForm As New FrmSetups
        'ChildForm.SetupTable = "Sales Person"
        'ChildForm.ShowDialog()
    End Sub
    Private Sub cmdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomer.Click
        'If GetUserAccessDetails("Setup - Client Register") = False Then Exit Sub
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
        If drSQL.Read Then
            tCustomerCode.Text = drSQL.Item("ID")
            tCustomerName.Text = drSQL.Item("Name")
            oLoadCustomer = True
        End If
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

    Private Sub tCustomerCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tCustomerCode.LostFocus
        tCustomerName.Text = ""
        If oLoadCustomer(tCustomerCode.Text) = False And Trim(tCustomerCode.Text) <> "" Then
            MsgBox("Customer do not exist", MsgBoxStyle.Information, strApptitle)
            tCustomerCode.Focus()
        End If
    End Sub
    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal SalesPerson As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(3).Text = ProductCode And lvSalesList.Items(i).SubItems(10).Text = SalesPerson Then
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
        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Tag = "" Or tCategoryName.Text = "" Or Val(tQty.Text) = 0 Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If

        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cSalesPerson.Text)
        If PositionInList >= 0 Then
            lvSalesList.Items(PositionInList).SubItems(5).Text = Val(lvSalesList.Items(PositionInList).SubItems(5).Text) + Val(tQty.Text)
            lvSalesList.Items(PositionInList).SubItems(6).Text = IIf((Val(lvSalesList.Items(PositionInList).SubItems(6).Text) + Val(tSellPrice.Text)) = 0, 0, Math.Round(Val(lvSalesList.Items(PositionInList).SubItems(6).Text) + Val(tSellPrice.Text)) / 2)
            ' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

            lvSalesList.Items(PositionInList).SubItems(7).Text = Val(lvSalesList.Items(PositionInList).SubItems(5).Text) * Val(lvSalesList.Items(PositionInList).SubItems(6).Text) ' seem dump hen!!, don't delete i know what am doing
            lvSalesList.Items(PositionInList).SubItems(9).Text = lvSalesList.Items(PositionInList).SubItems(9).Text + IIf(Trim(tDetails.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(9).Text) = "", "", ",") + tDetails.Text)
            lvSalesList.Items(PositionInList).SubItems(10).Text = lvSalesList.Items(PositionInList).SubItems(10).Text + IIf(Trim(cSalesPerson.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(10).Text) = "", "", ",") + cSalesPerson.Text)

        Else

            'including when PositionInList = -1 MsgBox("Item Already in List with different Deposit Status" & Chr(13) & "It cannot be added to the existing Product", vbInformation, strApptitle)
            Dim LvItems As New ListViewItem
            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(tCategoryName.Tag)
            LvItems.SubItems.Add(tCategoryName.Text)
            LvItems.SubItems.Add(tItemCode.Text)
            LvItems.SubItems.Add(tProductName.Text)
            LvItems.SubItems.Add(Val(tQty.Text))
            LvItems.SubItems.Add(Val(tSellPrice.Text))
            LvItems.SubItems.Add(Val(tQty.Text) * Val(tSellPrice.Text))
            LvItems.SubItems.Add(tSellPrice.Tag)
            LvItems.SubItems.Add(tDetails.Text)
            LvItems.SubItems.Add(cSalesPerson.Text)
            LvItems.SubItems.Add(Val(cCostPrice.Tag))
            'LvItems.SubItems.Add(Val(cCostPrice.Tag))
            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

        End If
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
            ThePayable = ThePayable + Val(lvSalesList.Items(i).SubItems(7).Text)
        Next
        tTotalValue.Text = Math.Round(ThePayable, 2)
        tPayable.Text = Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2)
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
        LoadProductDetails(lvSalesList.SelectedItems(0).SubItems(3).Text)

        tDetails.Text = lvSalesList.SelectedItems(0).SubItems(9).Text
        cSalesPerson.Text = lvSalesList.SelectedItems(0).SubItems(10).Text
        tTotalValue.Text = tTotalValue.Text - (Val(lvSalesList.SelectedItems(0).SubItems(5).Text) * Val(lvSalesList.SelectedItems(0).SubItems(6).Text))

        tQty.Text = lvSalesList.SelectedItems(0).SubItems(5).Text
        tSellPrice.Text = Math.Round(Val(lvSalesList.SelectedItems(0).SubItems(6).Text), 2)

        lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)
        Dim i As Integer = 0
        For i = 0 To lvSalesList.Items.Count - 1
            lvSalesList.Items(i).Text = i + 1
        Next
        tQty.Focus()
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
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
    End Sub

    Private Sub lvSalesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSalesList.SelectedIndexChanged

    End Sub

    Private Sub CmdCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        If MsgBox("The Selected Transaction would be removed" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbYes Then
            tTotalValue.Text = tTotalValue.Text - (Val(lvSalesList.SelectedItems(0).SubItems(5).Text) * Val(lvSalesList.SelectedItems(0).SubItems(6).Text))
            lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)
            Dim i As Integer = 0
            For i = 0 To lvSalesList.Items.Count - 1
                lvSalesList.Items(i).Text = i + 1
            Next
            calculatePayable()
        End If
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        Dim strValue As String
        Dim strPrompt As String
        Dim strCaption(6) As String
        Dim intWidth(6) As Integer
        strCaption(0) = "Order No"
        strCaption(1) = "Date"
        strCaption(2) = "No of Items"
        strCaption(3) = "Order Value"
        strCaption(4) = "Amt Paid"
        strCaption(5) = "Sales Person"

        intWidth(0) = 70
        intWidth(1) = 80
        intWidth(2) = 100
        intWidth(3) = 80
        intWidth(4) = 80
        intWidth(5) = 80
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
                If drSQL.Item("PaymentMode") = "Others" Then RadOthers.Checked = True
                tPayDetails.Text = drSQL.Item("PaymentDetails")
                tCustomerCode.Text = ChkNull(drSQL.Item("CustomerCode"))
                tCustomerName.Text = ChkNull(drSQL.Item("CustomerName"))
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
            LvItems.SubItems.Add(drSQL.Item("CategoryCode"))
            LvItems.SubItems.Add(drSQL.Item("CategoryName"))
            LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            LvItems.SubItems.Add(Math.Round(drSQL.Item("SellPrice"), 2))
            LvItems.SubItems.Add(drSQL.Item("Qty") * drSQL.Item("SellPrice"))
            LvItems.SubItems.Add(drSQL.Item("FixedPrice"))
            LvItems.SubItems.Add(drSQL.Item("Details"))
            LvItems.SubItems.Add(drSQL.Item("SalesPerson"))
            LvItems.SubItems.Add(drSQL.Item("CostPrice"))
            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})
            tTotalValue.Text = Val(tTotalValue.Text) + drSQL.Item("Qty") * drSQL.Item("SellPrice")

        Loop
        tPaid.Text = Math.Round(tPaid.Tag, 2)
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
                tCustomerCode.Text = drSQL.Item("ClientCode")
                tCustomerName.Text = drSQL.Item("ClientName")
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
    Private Sub chkCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCategory.CheckedChanged
        If chkCategory.Checked = True Then
            lvCategory.Visible = False
            tblMain.ColumnStyles(0).SizeType = SizeType.Absolute
            tblMain.ColumnStyles(0).Width = 0
            tblMain.ColumnStyles(2).SizeType = SizeType.Percent
            tblMain.ColumnStyles(2).Width = 100
            Me.Width = 560
            Me.Left = (My.Computer.Screen.WorkingArea.Width) / 4 ' + Me.Width) / 2

        Else
            lvCategory.Visible = True
            tblMain.ColumnStyles(0).SizeType = SizeType.AutoSize
            'tblMain.ColumnStyles(1).Width = 0
            tblMain.ColumnStyles(2).SizeType = SizeType.Percent
            tblMain.ColumnStyles(2).Width = 100
            Me.Width = 1041
            Me.Left = (My.Computer.Screen.WorkingArea.Width) / 8 ' + Me.Width) / 2

        End If

    End Sub
    Private Sub tPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tPaid.TextChanged
        tChange.Text = Math.Round(Val(tPaid.Text) - Val(tPayable.Text), 2)
        If Val(tChange.Text) < 0 Then tChange.Text = 0
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
End Class
