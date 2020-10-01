Imports System
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Public Class stkFrmProformal1
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
        AppHeader1.lblForm.Text = "Proformal Invoice"
        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        lvCategory.BackColor = MainTheme
        lvProduct.BackColor = MainTheme
        lvSalesList.BackColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        tOrderNo.BackColor = MainTheme
        tCategoryName.BackColor = MainTheme
        tItemDesc.BackColor = MainTheme
        tPack.BackColor = MainTheme
        tStockLevel.BackColor = MainTheme
        tTotalValue.BackColor = MainTheme
        PanCommands.BackColor = MainTheme
        Panel4.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        PanList.BackColor = HeaderTheme
        cStore.BackColor = HeaderTheme


        DGrid.DataSource = bindingSource

        FillStore()

        oLoadBank()

        ' FetchBatchNo("087400431030")

        dtpDate.Value = Now
        cmdNew.Enabled = ModuleAdd

        Action = AppAction.Add

        mnuEdit.Enabled = ModuleEdit

        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        PanList.Top = tblMain.Top + PanEntry.Top + tblDetails.Top + tProductName.Bottom + 55
        PanList.Left = tblMain.Left + PanEntry.Left + tblDetails.Left + tProductName.Left + 5

        Minimize_Size = tblDetails.Width

        fillCustomers()

        cmdNewBatch.Enabled = Not ST_IgnoreBatch

        GetUserAccessDetails("Stockitem Register")
        cmdNewItem.Enabled = ModuleAdd

    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()
        lvProduct.Items.Clear()

        cmSQL.CommandText = "SELECT DISTINCT Category FROM STOREITEMS WHERE TransType='Retail' AND Discontinue=0 ORDER BY Category"

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

        cmSQL.CommandText = "FetchAllActiveStoreItemsPerCategoryPerStore4Retail"
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

    Private Sub RadCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCash.CheckedChanged
        PanPayType.Visible = False
        tCheqNo.Text = ""
    End Sub
    Private Sub RadCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCheque.CheckedChanged
        PanPayType.Visible = True
        tCheqNo.Focus()
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
        cBatchNo.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveStoreItemsPerProductCode4RetailOnly"
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
                    tItemCode.Focus()
                    'tProductName.Focus()
                    cmSQL.Dispose()
                    drSQL.Close()
                End If
            Else
                MsgBox("Product not found....", vbInformation, strApptitle)
                GetProductByCode = False
                tItemCode.Focus()
                'tProductName.Focus()
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

                tPack.Text = drSQL.Item("Pack")
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

        FetchBatchNo(tItemCode.Text)

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

        cmSQL.CommandText = "FetchNewReceiptOrderNo"
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

        If RadCash.Checked <> True And Trim(tCheqNo.Text) = "" Then
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

        MainCashPaid = CDbl(tPaid.Text)

        If MainCashPaid < CDbl(tPayable.Text) And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
            MsgBox("Incomplete credit transaction", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If MainCashPaid > CDbl(tPayable.Text) And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
            MsgBox("Over payment!!, pls enter customer details", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If RadCash.Checked <> True And (Trim(tCustomerCode.Text) = "" Or Trim(tCustomerName.Text) = "") Then
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
            cmSQL1.CommandText = "SELECT * FROM RECEIPTDETAILS WHERE OrderNo=" & Val(tOrderNo.Text)
            cmSQL1.CommandType = CommandType.Text
            cnSQL1.Open()
            drSQL1 = cmSQL1.ExecuteReader()
            Do While drSQL1.Read
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "UpdateProduct4Receipt"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
                cmSQL.Parameters.AddWithValue("@ProductCode", drSQL1.Item("ProductCode"))
                cmSQL.Parameters.AddWithValue("@BatchNo", drSQL1.Item("BatchNo"))
                cmSQL.Parameters.AddWithValue("@Store", drSQL1.Item("Store"))
                cmSQL.ExecuteNonQuery()
            Loop
            drSQL1.Close()
            cmSQL1.Dispose()
            cnSQL1.Close()

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteReceipt"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
            cmSQL.ExecuteNonQuery()
        End If
        Dim ReceiptValue As Double = CDbl(tTotalValue.Text) 'Val(tPayable.Text) - Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2) + Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)

        If lvSalesList.Items.Count > 0 Then
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertReceipt"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@ClientCode", tCustomerCode.Text)
            cmSQL.Parameters.AddWithValue("@ClientName", tCustomerName.Text)
            cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
            cmSQL.Parameters.AddWithValue("@AmountPaid", MainCashPaid) 'Val(tPaid.Text))
            cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(ReceiptValue, 2))
            cmSQL.Parameters.AddWithValue("@Discount", Math.Round(IIf(chkDiscount.Checked, (CDbl(tDiscount.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text)), 2)) 'Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2))
            cmSQL.Parameters.AddWithValue("@VAT", Math.Round(IIf(chkVAT.Checked, (CDbl(tVat.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tVat.Text)), 2)) 'Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2))
            cmSQL.Parameters.AddWithValue("@AmtInWord", IIf(MainCashPaid = 0, "", Towords(MainCashPaid, "Naira", "Kobo") + " Only"))
            cmSQL.Parameters.AddWithValue("@PaymentMode", IIf(RadCash.Checked, "Cash", "Cheque"))
            If RadCash.Checked Then
                cmSQL.Parameters.AddWithValue("@BankName", "")
                cmSQL.Parameters.AddWithValue("@BankCode", "")
                cmSQL.Parameters.AddWithValue("@ChequeNo", "")
            Else
                cmSQL.Parameters.AddWithValue("@BankName", Microsoft.VisualBasic.Mid(cBank.Text, Len(GetIt4Me(cBank.Text, " - ") + 4)))
                cmSQL.Parameters.AddWithValue("@BankCode", GetIt4Me(cBank.Text, " - "))
                cmSQL.Parameters.AddWithValue("@ChequeNo", tCheqNo.Text)
            End If
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ReceiptNo", Val(tReceiptNo.Text))

            cmSQL.ExecuteNonQuery()

            'tPayable.Text = Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2)

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertReceiptDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@ReceiptIndex", i + 1)
                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@BatchNo", lvSalesList.Items(i).SubItems(5).Text)
                cmSQL.Parameters.AddWithValue("@CostPrice", CDbl(lvSalesList.Items(i).SubItems(6).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(lvSalesList.Items(i).SubItems(8).Text))
                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(9).Text)
                cmSQL.Parameters.AddWithValue("@Pack", lvSalesList.Items(i).SubItems(10).Text)
                cmSQL.Parameters.AddWithValue("@ProductDesc", lvSalesList.Items(i).SubItems(11).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(12).Text)
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(16).Text)

                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@BatchNo", lvSalesList.Items(i).SubItems(5).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(12).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(lvSalesList.Items(i).SubItems(6).Text))
                cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(lvSalesList.Items(i).SubItems(8).Text))
                cmSQL.Parameters.AddWithValue("@DateMade", CDate(lvSalesList.Items(i).SubItems(13).Text))
                cmSQL.Parameters.AddWithValue("@ExpiryDate", CDate(lvSalesList.Items(i).SubItems(14).Text))
                cmSQL.Parameters.AddWithValue("@Discontinue", IIf(lvSalesList.Items(i).SubItems(15).Text = "True", True, False))
                cmSQL.Parameters.AddWithValue("@TransType", "Retail")
                cmSQL.ExecuteNonQuery()

            Next i
        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        cStore.Enabled = True

        LastOrderNo = Val(tOrderNo.Text)

        flush()
        cmdSave.Enabled = False
        cmdNew.Enabled = True

        Action = AppAction.Add

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
            cBatchNo.Focus()
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
        tTotalValue.Text = 0
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

        tTotalValue.Text = 0
        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        tPayable.Text = 0
        tPaid.Text = 0
        tCustomerCode.Text = ""
        tCustomerName.Text = ""
        tReceiptNo.Text = ""

        lvSalesList.Items.Clear()
        cBatchNo.Items.Clear()
        DoNotExist = False
        RadCash.Checked = True

        tSourceDoc.Text = ""

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
        cBatchNo.Items.Clear()
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
            .tSelection = "Supplier"
            .listQuery = "Supplier"
            .Text = "List of Suppliers"
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

    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal ProductBatch As String, ByVal TheStore As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(2).Text = ProductCode And lvSalesList.Items(i).SubItems(5).Text = ProductBatch And lvSalesList.Items(i).SubItems(12).Text = TheStore Then
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
        If cBatchNo.Text = "" Then
            MsgBox("Batch No is required", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cBatchNo.Text, cStore.Text)
        If PositionInList >= 0 Then
            lvSalesList.Items(PositionInList).SubItems(4).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) + CDbl(tQty.Text)
            lvSalesList.Items(PositionInList).SubItems(6).Text = IIf((Val(lvSalesList.Items(PositionInList).SubItems(6).Text) + CDbl(tCostPrice.Text)) = 0, 0, Math.Round(CDbl(lvSalesList.Items(PositionInList).SubItems(6).Text) + CDbl(tCostPrice.Text)) / 2)
            ' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

            lvSalesList.Items(PositionInList).SubItems(7).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) * CDbl(lvSalesList.Items(PositionInList).SubItems(6).Text) ' seem dump hen!!, don't delete i know what am doing
            lvSalesList.Items(PositionInList).SubItems(9).Text = lvSalesList.Items(PositionInList).SubItems(9).Text + IIf(Trim(tDetails.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(9).Text) = "", "", ",") + tDetails.Text)

        Else

            'including when PositionInList = -1 MsgBox("Item Already in List with different Deposit Status" & Chr(13) & "It cannot be added to the existing Product", vbInformation, strApptitle)
            Dim LvItems As New ListViewItem
            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(tCategoryName.Text)
            LvItems.SubItems.Add(tItemCode.Text)
            LvItems.SubItems.Add(tProductName.Text)
            LvItems.SubItems.Add(Val(tQty.Text))
            LvItems.SubItems.Add(cBatchNo.Text)
            LvItems.SubItems.Add(Format(tCostPrice.Text, "Standard"))
            LvItems.SubItems.Add(Format(tQty.Text * tCostPrice.Text, "Standard"))
            LvItems.SubItems.Add(Format(tSellPrice.Text, "Standard"))
            LvItems.SubItems.Add(tDetails.Text)

            LvItems.SubItems.Add(tPack.Text)
            LvItems.SubItems.Add(tItemDesc.Text)
            LvItems.SubItems.Add(cStore.Text)

            LvItems.SubItems.Add(ReturnMadeDate)
            LvItems.SubItems.Add(ReturnExpiryDate)
            LvItems.SubItems.Add(ReturnDiscontinue)
            LvItems.SubItems.Add(tItemCode.Tag)

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
            ThePayable = ThePayable + CDbl(lvSalesList.Items(i).SubItems(7).Text)
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
        GetProductByCode(lvSalesList.SelectedItems(0).SubItems(2).Text)

        tDetails.Text = lvSalesList.SelectedItems(0).SubItems(9).Text
        tTotalValue.Text = tTotalValue.Text - (CDbl(lvSalesList.SelectedItems(0).SubItems(4).Text) * CDbl(lvSalesList.SelectedItems(0).SubItems(6).Text))

        tQty.Text = lvSalesList.SelectedItems(0).SubItems(4).Text
        tCostPrice.Text = Math.Round(CDbl(lvSalesList.SelectedItems(0).SubItems(6).Text), 2)
        tSellPrice.Text = Math.Round(CDbl(lvSalesList.SelectedItems(0).SubItems(8).Text), 2)

        ReturnMadeDate = lvSalesList.SelectedItems(0).SubItems(13).Text
        ReturnExpiryDate = lvSalesList.SelectedItems(0).SubItems(14).Text
        ReturnDiscontinue = lvSalesList.SelectedItems(0).SubItems(15).Text

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
        cStore.Enabled = True
    End Sub


    Private Sub CmdCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        On Error GoTo errhdl
        If MsgBox("The Selected Transaction would be removed" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbYes Then
            tTotalValue.Text = tTotalValue.Text - (Val(lvSalesList.SelectedItems(0).SubItems(4).Text) * Val(lvSalesList.SelectedItems(0).SubItems(6).Text))
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
        Action = AppAction.Edit
        Dim strOrder As String = InputBox("Enter Order No", "Restock", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            ReturnOrderNo = Val(strOrder)
            LoadEditableOrder(ReturnOrderNo)
            Exit Sub
        End If
        With FrmList
            .Text = "Edit Stock Restock"
            .frmParent = Me
            .tSelection = "Edit Restock"
            .listQuery = "Edit Restock"
            .Text = "List of Restock"
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

        cmSQL.CommandText = "FetchReceipt"
        cmSQL.Parameters.AddWithValue("@OrderNo", TheOrderNo)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                'If drSQL.Item("DepositTag") > 0 Then
                '    MsgBox("This order cannot be edited...Bank Deposit Transaction exist", MsgBoxStyle.Information, strApptitle)
                '    'cmSQL.Connection.Close()
                '    cmSQL.Dispose()
                '    drSQL.Close()
                '    'cnSQL.Close()
                '    'cnSQL.Dispose()

                '    flush()
                '    lvSalesList.Items.Clear()
                '    cmdNew.Enabled = True
                '    cmdSave.Enabled = False
                '    tItemCode.Focus()
                '    ReturnOrderNo = 0
                '    cmdNew.Enabled = ModuleAdd
                '    Action = ModuleAdd

                '    Exit Sub
                'End If

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
                cBank.Text = ChkNull(drSQL.Item("BankCode")) + " - " + ChkNull(drSQL.Item("BankName"))
                tCheqNo.Text = ChkNull(drSQL.Item("ChequeNo"))
                tCustomerCode.Text = ChkNull(drSQL.Item("ClientCode"))
                tCustomerName.Text = ChkNull(drSQL.Item("ClientName"))
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
            LvItems.SubItems.Add(drSQL.Item("BatchNo"))
            LvItems.SubItems.Add(Format(drSQL.Item("CostPrice"), "standard"))
            LvItems.SubItems.Add(Format(drSQL.Item("Qty") * drSQL.Item("CostPrice"), "standard"))
            LvItems.SubItems.Add(Format(drSQL.Item("SellPrice"), "standard"))
            LvItems.SubItems.Add(drSQL.Item("Details"))

            LvItems.SubItems.Add(drSQL.Item("Pack"))
            LvItems.SubItems.Add(drSQL.Item("ProductDesc"))
            LvItems.SubItems.Add(drSQL.Item("Store"))
            LvItems.SubItems.Add("01-Jan-1900")
            LvItems.SubItems.Add("01-Jan-2900")
            LvItems.SubItems.Add("False")
            LvItems.SubItems.Add(drSQL.Item("TransType"))

            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

            tTotalValue.Text = CDbl(tTotalValue.Text) + drSQL.Item("Qty") * drSQL.Item("CostPrice")

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
    Private Sub tSellPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSellPrice.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tDetails.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
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

        cmSQL.CommandText = "SELECT PaymentTag, PayType, ClientCode, ClientName FROM Payments WHERE PayType='Payable' AND PaymentTag=" & TheTag
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
                cBatchNo.Focus()
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
        Dim str1 As String = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.BatchNo, StoreItems.Pack,StoreItems.ProductDesc"
        Dim str2 As String = " FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND StoreItems.TransType='Retail' AND (StoreItems.Discontinue = 0) AND "
        'cnSQL.Open()
        If radContaining.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%'"
        If RadStartWith.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%'"
        If RadEndWith.Checked Then strQuery = "  ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "'"
        If RadEqual.Checked Then strQuery = " ProductName IS NOT NULL AND ProductName  = '" + strQry & "'"
        Dim str As String = "SELECT ProductCode, ProductName, Category,0 AS Qty,'' AS BatchNo,Pack,ProductDesc FROM StoreItems WHERE TransType='Retail' AND Discontinue=0 AND " & strQuery & " AND ProductCode NOT IN (SELECT StockQty.ProductCode " & str2 + strQuery & ") UNION " & str1 + str2 + strQuery + " ORDER BY ProductName"

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
        DGrid.Columns(3).Width = 40
        DGrid.Columns(4).Width = 60
        DGrid.Columns(5).Width = 80

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
        cBatchNo.Items.Clear()

        If Trim(strValue) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveStoreItemsPerProductName4RetailOnly"
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

                tPack.Text = drSQL.Item("Pack")
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

        FetchBatchNo(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Function
    Private Sub GetProductDetails(ByVal ProductCode As String, ByVal TheBatchNo As String)
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



        cmSQL.CommandText = "FetchActiveStoreItemsPerBatchNoPerStore4Retail"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@BatchNo", TheBatchNo)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            If cBatchNo.Text = "@Batch" Then
                ReturnMadeDate = "01-Jan-1900"
                ReturnExpiryDate = "01-Jan-2900"
                ReturnDiscontinue = False

                tQty.Text = 1
                tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)

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

    Private Sub FetchBatchNo(ByVal strProduct As String)
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cBatchNo.Items.Clear()

        cmSQL.CommandText = "FetchActiveBatchPerStockItem"
        cmSQL.Parameters.AddWithValue("@ProductCode", strProduct)
        ' cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        Do While drSQL.Read
            cBatchNo.Items.Add(drSQL.Item("BatchNo").ToString)
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        ' If ST_IgnoreBatch = True Then cBatchNo.Items.Add("@Batch")

        cBatchNo.SelectedIndex = 0

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

            cBatchNo.Focus()
        End If
    End Sub
    Private Sub cBatchNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cBatchNo.SelectedIndexChanged
        GetProductDetails(tItemCode.Text, cBatchNo.Text)
    End Sub

    Sub fillCustomers()
        On Error GoTo handler

        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cCustomerName.Items.Clear()
        cmSQL.CommandText = "SELECT DISTINCT [ID],[Name],ClientType FROM Client WHERE [Name] IS NOT NULL ORDER BY ClientType DESC,[Name]"
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
    Private Sub cCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cCustomerName.SelectedIndexChanged
        tCustomerName.Text = GetIt4Me(cCustomerName.Text, " - ")
        tCustomerCode.Text = Mid(cCustomerName.Text, Len(tCustomerName.Text) + 4)
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
    Private Sub cmdNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewBatch.Click
        If Trim(tItemCode.Text) = "" Then Exit Sub
        Dim ChildForm As New stkFrmBatches
        ChildForm.ProductCode = tItemCode.Text
        ChildForm.ProductDesc = tProductName.Text
        ChildForm.frmParent = Me
        ChildForm.chkDiscontinue.Enabled = False
        ChildForm.ShowDialog()
        On Error Resume Next
        ' justloading = True
        cBatchNo.Items.Add(ReturnBatchNo)
        cBatchNo.Text = ReturnBatchNo
        'justloading = False
    End Sub
    Private Sub oLoadBank()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "SELECT Code, Description FROM ACCOUNTCHART WHERE [Description]<>'CASH' AND Category = N'Bank'"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cBank.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Description"))
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

        cmSQL.Parameters.AddWithValue("@Pack", "Unit")
        cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
        cmSQL.Parameters.AddWithValue("@MaxQty", 0)
        cmSQL.Parameters.AddWithValue("@Rate", 0)
        cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")


        cmSQL.Parameters.AddWithValue("@Discontinue", False)
        cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
        cmSQL.Parameters.AddWithValue("@ProductDesc", "")
        cmSQL.Parameters.AddWithValue("@Remark", "")
        cmSQL.Parameters.AddWithValue("@TransType", "Retail")

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


End Class