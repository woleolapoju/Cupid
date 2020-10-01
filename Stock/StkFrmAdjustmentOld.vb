Imports System
Imports System.Data.SqlClient
Public Class StkFrmAdjustmentOld
    Public ReturnRefNo As Integer
    Dim justloading As Boolean = False
    Dim SkipBatchLoading As Boolean = False
    Public ReturnBatchNo As String
    Public ReturnMadeDate As Date
    Public ReturnExpiryDate As Date
    Public ReturnDiscontinue As Boolean

    Private Sub FrmAdjustment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Stock Adjustments"
        oLoadCategory()
        BackColor = MainTheme
        tRefNo.BackColor = MainTheme
        tCategoryName.BackColor = MainTheme
        tProductName.BackColor = MainTheme
        tStockLevel.BackColor = MainTheme
        lvProduct.BackColor = MainTheme
        lvCategory.BackColor = MainTheme
        cboTransType.BackColor = MainTheme
        Panel1.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme


        dtpDate.Value = Now

        cmdOk.Enabled = ModuleAdd

        FillStore()

        GetUserAccessDetails("Stockitem Register", False)
        cmdNewItem.Enabled = ModuleAdd
        cmdNewBatch.Enabled = Not ST_IgnoreBatch

        'If ST_IgnoreBatch Then
        ReturnMadeDate = CDate("01-Jan-1900")
        ReturnExpiryDate = CDate("01-Jan-2900") '+ Trim(Year(Now) + 100))
        ReturnDiscontinue = False
        'End If
        lblPack.Text = ""

    End Sub
    Private Sub oLoadCategory()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvCategory.Items.Clear()

        cmSQL.CommandText = "SELECT Description FROM Category ORDER BY [Description]"

        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        LvItems = New ListViewItem("<ALL>")
        LvItems.SubItems.Add("")
        lvCategory.Items.AddRange(New ListViewItem() {LvItems})
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("Description").ToString)
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

        cmSQL.CommandText = "FetchAllStoreItemsByCategory"
        cmSQL.Parameters.AddWithValue("@Category", IIf(TheCat = "<ALL>", "*", TheCat))
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
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
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0
        tStockLevel.Text = 0
        'tReason.Text = ""

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        oLoadProduct(lvCategory.SelectedItems(0).Text)
        tCategoryName.Text = lvCategory.SelectedItems(0).Text
    End Sub

    Private Sub lvProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProduct.Click
        'On Error Resume Next
        'LoadProductDetails(lvProduct.SelectedItems(0).Text)

        lvProduct_SelectedIndexChanged(sender, e)
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
    Private Function LoadProductDetails(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl

        If SkipBatchLoading = False Then LoadBatches(ProductCode)

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        LoadProductDetails = True

        tProductName.Text = ""
        'tCategoryName.Text = ""
        'tCategoryName.Tag = ""
        tQty.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = ""
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0

        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchStoreItemsPerProductCodePerStorePerBatch"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.Parameters.AddWithValue("@BatchNo", cboBatch.Text)

        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            '  MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            LoadProductDetails = False
            ' tProductCode.Focus()
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("Category")

                'tStockLevel.Text = drSQL.Item("UnitInStock")
                tQty.Tag = drSQL.Item("Qty")
                tQty.Text = 0
                tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)
                tStockLevel.Tag = drSQL.Item("MaxQty")

                tCostPrice.Text = (Math.Round(drSQL.Item("CostPriceNew"), 2))
                tCostPrice.Tag = (Math.Round(drSQL.Item("CostPriceNew"), 2))


                tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                If Val(tQty.Text) = 0 Then tQty.Text = ""
                If Val(tCostPrice.Text) = 0 Then tCostPrice.Text = ""
                If Val(tSellPrice.Text) = 0 Then tSellPrice.Text = ""

                cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                cSellPrice.SelectedIndex = 0

                cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                cCostPrice.SelectedIndex = 0
                cboTransType.Text = drSQL.Item("TransType")
                lblPack.Text = ChkNull(drSQL.Item("Pack"))

            End If
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()

        If LoadProductDetails = False Then
            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "FetchStoreItemsWithStockBalance"
            cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
            cmSQL.CommandType = CommandType.StoredProcedure
            'cnSQL.Open()
            drSQL = cmSQL.ExecuteReader()

            If drSQL.HasRows = False Then
                '  MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
                LoadProductDetails = False
                ' tProductCode.Focus()
            Else
                If drSQL.Read Then
                    tItemCode.Text = drSQL.Item("ProductCode")
                    tProductName.Text = drSQL.Item("ProductName")
                    tCategoryName.Text = drSQL.Item("Category")

                    'tStockLevel.Text = drSQL.Item("UnitInStock")
                    tQty.Tag = drSQL.Item("TotalQty")
                    tQty.Text = 0
                    tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)
                    tStockLevel.Tag = drSQL.Item("MaxQty")

                    tCostPrice.Text = (Math.Round(drSQL.Item("CostPriceNew"), 2))
                    tCostPrice.Tag = (Math.Round(drSQL.Item("CostPriceNew"), 2))


                    tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                    tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                    If Val(tQty.Text) = 0 Then tQty.Text = ""
                    If Val(tCostPrice.Text) = 0 Then tCostPrice.Text = ""
                    If Val(tSellPrice.Text) = 0 Then tSellPrice.Text = ""

                    cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cSellPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                    cSellPrice.SelectedIndex = 0

                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                    cCostPrice.SelectedIndex = 0
                    cboTransType.Text = drSQL.Item("TransType")
                    lblPack.Text = ChkNull(drSQL.Item("Pack"))

                End If

                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                drSQL.Close()




            End If


        End If
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function
    Private Sub lvProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProduct.SelectedIndexChanged
        On Error Resume Next
        If lvProduct.SelectedItems(0).Text = "" Then Exit Sub
        justloading = True
        tItemCode.Tag = lvProduct.SelectedItems(0).Text
        LoadProductDetails(lvProduct.SelectedItems(0).Text)
        justloading = False
    End Sub
    Private Sub tItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tItemCode.LostFocus

        On Error GoTo handler
        Dim jk As Integer = 1
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        If LoadProductDetails(tItemCode.Text) = False Then
            If MsgBox("Product Code not Found" & Chr(13) & "Create (y/n)", vbYesNo + vbCritical, strApptitle) = MsgBoxResult.Yes Then
                If tCategoryName.Text = "" Then
                    MsgBox("Please enter a Category for the New Stock Item", vbInformation, strApptitle)
                    tItemCode.Text = ""
                    tItemCode.Focus()
                Else
                    Dim resp As String = InputBox("Enter Item Name", "New Item")
                    If resp = "" Then
                        tItemCode.Focus()
                    Else
                        Dim ProductCode As String = tItemCode.Text
FetchNoAgain:
                        FetchNextNo(jk)

                        Dim ProductName As String = Trim(resp)
                        If ProductCode <> "" And ProductName <> "" And Val(cmdNewItem.Tag) > 0 Then

                            cmSQL.Parameters.Clear()
                            cmSQL.CommandText = "InsertStoreItems"
                            cmSQL.CommandType = CommandType.StoredProcedure
                            cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
                            cmSQL.Parameters.AddWithValue("@ProductName", ProductName)
                            cmSQL.Parameters.AddWithValue("@Category", tCategoryName.Text)
                            cmSQL.Parameters.AddWithValue("@Pack", " ")
                            cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
                            cmSQL.Parameters.AddWithValue("@MaxQty", 0)
                            cmSQL.Parameters.AddWithValue("@Rate", 0)
                            cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")
                            cmSQL.Parameters.AddWithValue("@Discontinue", 0)
                            cmSQL.Parameters.AddWithValue("@AutoID", Val(cmdNewItem.Tag))
                            cmSQL.Parameters.AddWithValue("@ProductDesc", " ")
                            cmSQL.Parameters.AddWithValue("@Remark", " ")
                            cmSQL.Parameters.AddWithValue("@TransType", IIf(ST_TransType = "Both", "Retail", ST_TransType))

                            cmSQL.ExecuteNonQuery()

                            cmSQL.Dispose()
                            'cnSQL.Close()

                            oLoadProduct(tCategoryName.Text)
                            LoadProductDetails(ProductCode)
                            'tQty.Text = 1
                            'tQty.Focus()
                        Else
                            tItemCode.Focus()
                        End If
                    End If

                End If
            Else
                tItemCode.Focus()
            End If
        End If
        Exit Sub
        Resume
handler:
        If Err.Description Like "Violation of PRIMARY KEY constraint*" Then
            jk = jk + 1
            GoTo FetchNoAgain
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Function FetchNextNo(ByVal j As Integer) As Boolean
        On Error GoTo errhdl
        FetchNextNo = True
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewStockItemID"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then
            If drSQL.Read Then cmdNewItem.Tag = CLng(drSQL.Item("NewID") + j)
        Else
            cmdNewItem.Tag = 1
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
    Private Function FetchNextItemCode(ByVal j As Integer) As Boolean
        On Error GoTo errhdl
        FetchNextItemCode = True
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewStockItemID"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then
            If drSQL.Read Then cmdNewItem.Tag = CStr(CLng(drSQL.Item("NewID") + j))
        Else
            cmdNewItem.Tag = "1"
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

    Sub flush()
        dtpDate.Value = Now
        ReturnRefNo = 0
        tRefNo.Text = ""
        tItemCode.Text = ""
        tProductName.Text = ""
        'tCategoryName.Text = ""
        'tCategoryName.Tag = ""

        tSellPrice.Text = ""
        tSellPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = ""
        tCostPrice.Text = ""
        tCostPrice.Tag = 0

        ' tReason.Text = ""
        cSellPrice.Items.Clear()
        cCostPrice.Items.Clear()
        cCostPrice.Tag = 0

        tStockLevel.Text = 0
        tStockLevel.Tag = ""
        cboBatch.Items.Clear()
        tItemCode.Focus()
        lblPack.Text = ""
    End Sub

    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tStockLevel.Text = Val(tQty.Tag) + Val(tQty.Text)
        If Val(tStockLevel.Tag) <= 0 Or Val(tQty.Text) = 0 Then Exit Sub
        If Val(tStockLevel.Text) > Val(tStockLevel.Tag) Then MsgBox("New Stock Level exceeds Max. Level", MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub
        If Trim(tCostPrice.Text) = "" Then tCostPrice.Text = 0
        If Trim(tSellPrice.Text) = "" Then tSellPrice.Text = 0
        If Trim(tQty.Text) = "" Then tQty.Text = 0
        If Val(tCostPrice.Text) = Val(tCostPrice.Tag) And Val(tSellPrice.Text) = Val(tSellPrice.Tag) And Val(tQty.Text) = 0 Then
            MsgBox("No change made", vbInformation, strApptitle)
            Exit Sub
        End If
        'If IsNumeric(tSellPrice.Text) = False Or IsNumeric(tCostPrice.Text) = False Or IsNumeric(tQty.Text) = False Then
        '    MsgBox("Quantity,Selling Price and Cost Price must be numeric", vbInformation, strApptitle)
        '    Exit Sub
        'End If

        If Val(tCostPrice.Text) > Val(tCostPrice.Tag) Then
            If MsgBox("New Costprice is above prevailing costprice" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If Val(tSellPrice.Text) < Val(tSellPrice.Tag) Then
            If MsgBox("New Sellprice is below prevailing sellprice" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If Val(tSellPrice.Text) < 0 Then
            MsgBox("Sell Price must be positive", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tCostPrice.Text) < 0 Then
            MsgBox("Cost Price must be positive", vbInformation, strApptitle)
            Exit Sub
        End If

        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If
        If Trim(tReason.Text) = "" Then
            MsgBox("Reason for adjustment is required", vbInformation, strApptitle)
            Exit Sub
        End If

        If IsNumeric(tCostPrice.Text) = False Then
            MsgBox("A number is expected as Cost price", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If IsNumeric(tSellPrice.Text) = False Then
            MsgBox("A number is expected as Sell price", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If CDbl(tCostPrice.Text) > CDbl(tSellPrice.Text) Then
            If MsgBox("Cost price is greater than Sell price ..... continue(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, strApptitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If CDbl(tCostPrice.Text) = CDbl(tSellPrice.Text) Then
            If MsgBox("Cost price is equal than Sell price ..... continue(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, strApptitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If Val(tStockLevel.Tag) > 0 Then
            If Val(tStockLevel.Tag) > Val(tStockLevel.Text) Then
                If MsgBox("The Maximum stock level is passed" + Chr(13) + "Continue (y/n)", vbYesNo + vbCritical, strApptitle) = vbNo Then Exit Sub
            End If
        End If
        Dim myTrans As SqlClient.SqlTransaction

        If MsgBox("The Adjustment would be saved" + Chr(13) + "Continue (y/n)", vbYesNo + vbCritical, strApptitle) = vbNo Then Exit Sub
        'cnSQL.Open()
        myTrans = cnSQL.BeginTransaction()
        cmSQL.Transaction = myTrans

        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "InsertAdjustment"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.Parameters.AddWithValue("@ProductCode", tItemCode.Text)
        cmSQL.Parameters.AddWithValue("@ProductName", tProductName.Text)
        cmSQL.Parameters.AddWithValue("@Category", tCategoryName.Text)
        cmSQL.Parameters.AddWithValue("@BatchNo", cboBatch.Text)
        cmSQL.Parameters.AddWithValue("@Qty", IIf(cboTransType.Text = "Service", 0, Val(tQty.Text)))
        cmSQL.Parameters.AddWithValue("@PrevQty", Val(tQty.Tag))
        cmSQL.Parameters.AddWithValue("@Cost", CDbl(tCostPrice.Text))
        cmSQL.Parameters.AddWithValue("@PrevCost", CDbl(tCostPrice.Tag))
        cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(tSellPrice.Text))
        cmSQL.Parameters.AddWithValue("@PrevSellPrice", CDbl(tSellPrice.Tag))
        cmSQL.Parameters.AddWithValue("@Reason", tReason.Text)
        cmSQL.Parameters.AddWithValue("@Username", sysUserName)
        cmSQL.ExecuteNonQuery()

        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "InsertStockQty"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", tItemCode.Text)
        cmSQL.Parameters.AddWithValue("@BatchNo", cboBatch.Text)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.Parameters.AddWithValue("@Qty", IIf(cboTransType.Text = "Service", 0, Val(tQty.Text)))
        cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(tCostPrice.Text))
        cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(tSellPrice.Text))
        cmSQL.Parameters.AddWithValue("@DateMade", ReturnMadeDate)
        cmSQL.Parameters.AddWithValue("@ExpiryDate", ReturnExpiryDate)
        cmSQL.Parameters.AddWithValue("@Discontinue", ReturnDiscontinue)
        cmSQL.Parameters.AddWithValue("@TransType", cboTransType.Text)
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()
        myTrans.Commit()

        flush()

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewItem.Click
        If tCategoryName.Text = "" Then
            MsgBox("Please select a Category for the New Stock Item", vbInformation, strApptitle)
            tItemCode.Text = ""
            tItemCode.Focus()
            Exit Sub
        End If
        'If GetUserAccessDetails("Stockitem Register") = False Then Exit Sub
        'Dim ChildForm As New FrmProducts
        'ChildForm.Category = tCategoryName.Tag + " - " + tCategoryName.Text
        'ChildForm.ShowDialog()
        'If Val(tCategoryName.Tag) <> 0 Then oLoadProduct(tCategoryName.Tag)

        If ST_TransType = "Service" Then
            Dim Childform As New StkFrmItemRegister4Service
            Childform.ReturnCode = ""
            Childform.Action1 = "Add"
            On Error Resume Next
            Childform.cboCategory.Tag = tCategoryName.Text
            Childform.ShowDialog()
        Else
            Dim Childform As New StkFrmItemRegister
            Childform.ReturnCode = ""
            Childform.Action1 = "Add"
            On Error Resume Next
            Childform.cboCategory.Tag = tCategoryName.Text
            Childform.ShowDialog()
        End If

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        flush()
    End Sub
    Private Sub FillStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT  ASSIGNEDSTORE.Store, STORE.[Default] FROM ASSIGNEDSTORE INNER JOIN STORE ON ASSIGNEDSTORE.Store = STORE.Store WHERE UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT * FROM STORE ORDER BY [Default] DESC"
        End If
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        Dim InitialText As String = ""
        drSQL = cmSQL.ExecuteReader()
        Dim j As Integer = 1
        Do While drSQL.Read
            cStore.Items.Add(drSQL.Item("Store"))
            If drSQL.Item("Default") = True Then cStore.Tag = drSQL.Item("Store")
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

    Private Sub LoadBatches(ByVal strQuery As String)
        On Error GoTo errhdl
        If Trim(strQuery) = "" Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim MySQL As String = ""
        cboBatch.Items.Clear()

        cmSQL.CommandText = "FetchAllBatchPerStockItem"
        cmSQL.Parameters.AddWithValue("@ProductCode", strQuery)
        cmSQL.CommandType = CommandType.StoredProcedure

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim j As Long = 0
        Dim i
        Dim initialText As String
        Do While drSQL.Read
            cboBatch.Items.Add(drSQL.Item("BatchNo"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        On Error Resume Next
        cboBatch.SelectedIndex = 0

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        If justloading = True Then Exit Sub
        justloading = True
        LoadProductDetails(tItemCode.Tag)
        justloading = False
    End Sub

    Private Sub cboBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatch.SelectedIndexChanged
        If justloading = True Then Exit Sub
        SkipBatchLoading = True
        LoadProductDetails(tItemCode.Tag)
        SkipBatchLoading = False
    End Sub

    Private Sub tItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tItemCode.TextChanged

    End Sub

    Private Sub cmdNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewBatch.Click
        Dim ChildForm As New stkFrmBatches
        ChildForm.ProductCode = tItemCode.Text
        ChildForm.frmParent = Me
        ChildForm.chkDiscontinue.Enabled = False
        ChildForm.ShowDialog()
        On Error Resume Next
        justloading = True
        cboBatch.Items.Add(ReturnBatchNo)
        cboBatch.Text = ReturnBatchNo
        justloading = False
    End Sub

    Private Sub StkFrmAdjustment_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class