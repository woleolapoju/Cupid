Imports System.Data.SqlClient
Public Class stkFrmProductsList
    Public ReturnCode As String
    Dim Action As AppAction
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Dim tQry As String = ""
    Dim tQry1 As String = ""
    Dim tQry4All As String = ""
    Dim JustStarted As Boolean = True
    Dim StoredX As Long = 0
    Dim StoredY As Long = 0
    Dim GrpDgrid As DataGridView
    Dim justLoading As Boolean = False
    Dim FromCellEnter As Boolean = False
    Dim MyStore As String
    Private Sub stkFrmProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Stock Item Listings"
        JustStarted = False
        FillCategory()
        FillStore()
        If ST_TransType = "Service" Then
            RadWith.Enabled = False
            RadWithout.Enabled = False
        End If

        Me.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        lvListCat.BackColor = MainTheme
        lvListStore.BackColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate


        If GetUserAccessDetails("Stockitem Register") = False Then
            mnuAddItem.Enabled = False
            mnuEditItem.Enabled = False
            mnuDeleteItem.Enabled = False
        Else
            mnuAddItem.Enabled = ModuleAdd
            mnuEditItem.Enabled = ModuleEdit
            mnuDeleteItem.Enabled = ModuleDelete
        End If
        
        cboCriteria.SelectedIndex = 1
        'mnuShowDetails.Enabled = Not ST_IgnoreBatch
        If ST_TransType <> "Both" Then TabControl1.TabPages.RemoveAt(2)
      
        'JustStarted = False
        'DGrid.DataSource = bindingSource
    End Sub
    Private Sub FillCategory()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()
        cmSQL.CommandText = "SELECT * FROM CATEGORY"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        lvListCat.Items.Clear()
        lvListCat.Items.Add("<All>")
        Do While drSQL.Read
            lvListCat.Items.Add(drSQL.Item("Description").ToString)
        Loop
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
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

        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT Store FROM AssignedStore WHERE UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
        End If
        cmSQL.CommandType = CommandType.Text
        lvListStore.Items.Clear()
        'lvListStore.Items.Add("<All>")
        drSQL = cmSQL.ExecuteReader()
        Dim j As Integer = 1
        Do While drSQL.Read
            lvListStore.Items.Add(drSQL.Item("Store"))
            MyStore = MyStore + If(MyStore = "", "", ",") + "'" + drSQL.Item("Store") + "'"
        Loop
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdd.Click
        lblCaption.Text = "Category"
        tDesc.Text = ""
        lblCaption.Tag = "Add"
        tDesc.Focus()
    End Sub
    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo skipIt
        If lvListCat.SelectedItems(0).Text = "<All>" Then Exit Sub
        lblCaption.Text = "Category"
        tDesc.Text = lvListCat.SelectedItems(0).Text
        tDesc.Tag = lvListCat.SelectedItems(0).Text
        lblCaption.Tag = "Edit"
        tDesc.Focus()
skipIt:
    End Sub
    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        On Error GoTo skipIt
        If lvListCat.SelectedItems(0).Text = "<All>" Then Exit Sub
        lblCaption.Text = "Category"
        tDesc.Text = lvListCat.SelectedItems(0).Text
        tDesc.Tag = lvListCat.SelectedItems(0).Text
        lblCaption.Tag = "Delete"
        tDesc.Focus()
skipIt:
    End Sub
    Public Sub FillList()
        On Error GoTo errhdl
        DGrid.DataSource = Nothing
        DGrid.Rows.Clear()
        Dim Qry As String = ""
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        If tQry <> "" Then Qry = " WHERE " + tQry
        If tQry1 <> "" Then Qry = IIf(Qry = "", " WHERE " + tQry1, Qry + " AND " + tQry1)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim strQry As String = ""
        ' If TabControl1.SelectedTab.Text = "Category" Then
        If ST_TransType = "Service" Then
            strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category,StoreItems.AutoID AS ProductID, StoreItems.ProductDesc AS [Description],StockQty.Store, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld,StoreItems.Remark " & _
                            " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
            strQry = strQry + " UNION SELECT ProductCode, ProductName, Category, AutoID AS ProductID, ProductDesc AS [Description],'' AS Store,0 AS SellPriceNew, 0 AS CostPriceNew,0 AS SellPriceOld, 0 AS CostPriceOld,Remark " & _
                            " FROM StoreItems " + IIf(tQry4All = "", "", " WHERE ") + tQry4All + IIf(tQry4All = "", " WHERE ", " AND ") + " ProductCode NOT IN  (SELECT StoreItems.ProductCode FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry + ") ORDER BY StoreItems.AutoID"
        Else
            If RadAll.Checked = True Then
                If ST_TransType = "Both" Then
                    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category," & _
                             " StoreItems.AutoID AS ProductID, StoreItems.ProductDesc AS [Description],StockQty.Store, isnull(StockQty.Qty,0) AS Qty,StoreItems.TransType, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld, StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, StoreItems.Remark  " & _
                             " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
                    strQry = strQry + " UNION SELECT ProductCode, ProductName, Category, AutoID AS ProductID, ProductDesc AS [Description],'' AS Store,0 AS Qty, StoreItems.TransType, 0 AS SellPriceNew, 0 AS CostPriceNew,0 AS SellPriceOld, 0 AS CostPriceOld,StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, Remark " & _
                          " FROM StoreItems " + IIf(tQry4All = "", "", " WHERE ") + tQry4All + IIf(tQry4All = "", " WHERE ", " AND ") + " ProductCode NOT IN  (SELECT StoreItems.ProductCode FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry + ") ORDER BY StoreItems.AutoID"

                End If
                If ST_TransType = "Retail" Then
                    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category," & _
                             " StoreItems.AutoID AS ProductID, StoreItems.ProductDesc AS [Description],StockQty.Store, isnull(StockQty.Qty,0) AS Qty,StoreItems.TransType, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld, StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, StoreItems.Remark  " & _
                             " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
                    strQry = strQry + " UNION SELECT ProductCode, ProductName, Category, AutoID AS ProductID, ProductDesc AS [Description],'' AS Store,0 AS Qty, StoreItems.TransType, 0 AS SellPriceNew, 0 AS CostPriceNew,0 AS SellPriceOld, 0 AS CostPriceOld,StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, Remark " & _
                        " FROM StoreItems " + IIf(tQry4All = "", "", " WHERE ") + tQry4All + IIf(tQry4All = "", " WHERE ", " AND ") + " ProductCode NOT IN  (SELECT StoreItems.ProductCode FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry + ") ORDER BY StoreItems.AutoID"

                End If
            Else
                If ST_TransType = "Both" Then
                    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category," & _
                             " StoreItems.AutoID AS ProductID, StoreItems.ProductDesc AS [Description],StockQty.Store, isnull(StockQty.Qty,0) AS Qty,StoreItems.TransType, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld, StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, StoreItems.Remark  " & _
                             " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
                    '  strQry = strQry + " UNION SELECT ProductCode, ProductName, Category, AutoID AS ProductID, ProductDesc AS [Description],'' AS Store,0 AS Qty, StoreItems.TransType, 0 AS SellPriceNew, 0 AS CostPriceNew,0 AS SellPriceOld, 0 AS CostPriceOld,StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, Remark " & _
                    '      " FROM StoreItems " + IIf(tQry4All = "", "", " WHERE ") + tQry4All + IIf(tQry4All = "", " WHERE ", " AND ") + " ProductCode NOT IN  (SELECT StoreItems.ProductCode FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry + ") ORDER BY StoreItems.AutoID"

                End If
                If ST_TransType = "Retail" Then
                    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category," & _
                             " StoreItems.AutoID AS ProductID, StoreItems.ProductDesc AS [Description],StockQty.Store, isnull(StockQty.Qty,0) AS Qty, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld, StoreItems.ReorderLevel, StoreItems.MaxQty, StoreItems.ShelfLocation, StoreItems.Remark  " & _
                             " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
                    ' strQry = strQry + " UNION SELECT ProductCode, ProductName, Category, AutoID AS ProductID, ProductDesc AS [Description],'' AS Store,0 AS Qty, StoreItems.TransType, 0 AS SellPriceNew, 0 AS CostPriceNew,0 AS SellPriceOld, 0 AS CostPriceOld,StoreItems.ReorderLevel, StoreItems.MaxQtyk, StoreItems.ShelfLocation, Remark " & _
                    '    " FROM StoreItems " + IIf(tQry4All = "", "", " WHERE ") + tQry4All + IIf(tQry4All = "", " WHERE ", " AND ") + " ProductCode NOT IN  (SELECT StoreItems.ProductCode FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry + ") ORDER BY StoreItems.AutoID"

                End If
            End If
        End If

      
        ' End If

        'If TabControl1.SelectedTab.Text = "Store" Then
        '    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category, StoreItems.ReorderLevel," & _
        '           " StoreItems.ProductDesc AS [Description], StoreItems.Pack, StoreItems.Remark,StoreItems.ShelfLocation, StockQty.BatchNo, StockQty.Store, isnull(StockQty.Qty,0) AS Qty, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld " & _
        '           " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
        'End If
        'If TabControl1.SelectedTab.Text = "Batches" Then
        '    strQry = "SELECT StoreItems.ProductCode, StoreItems.ProductName, StoreItems.Category, StoreItems.ReorderLevel," & _
        '           " StoreItems.ProductDesc AS [Description], StoreItems.Pack, StoreItems.Remark,StoreItems.ShelfLocation, StockQty.BatchNo, StockQty.Store, isnull(StockQty.Qty,0) AS Qty, StockQty.SellPriceNew, StockQty.CostPriceNew,StockQty.SellPriceOld, StockQty.CostPriceOld " & _
        '           " FROM StoreItems LEFT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode " + Qry
        'End If

        cmSQL.CommandText = strQry
        cmSQL.CommandType = CommandType.Text
        DGrid.DataSource = bindingSource

        dataAdapter = New SqlDataAdapter(cmSQL) '"AC_FetchAllPaymentVouchers", strConnect)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table
        Dim myStyle As New DataGridViewCellStyle
        myStyle.Format = "N2"
        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        On Error Resume Next
        DGrid.Columns(1).Width = 200
        DGrid.Columns(6).DefaultCellStyle = myStyle
        DGrid.Columns(7).DefaultCellStyle = myStyle
        DGrid.Columns(8).DefaultCellStyle = myStyle
        DGrid.Columns(9).DefaultCellStyle = myStyle
        DGrid.Columns(10).DefaultCellStyle = myStyle
        DGrid.Columns(11).DefaultCellStyle = myStyle
        'Dim i As Integer = 0
        'Dim sum As Double = 0
        'For i = 0 To DGrid.Rows.Count - 1
        '    sum = sum + DGrid.Item(4, i).Value
        'Next
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        If Trim(tDesc.Text) = "" Then
            MsgBox("Incomplete information", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim myTrans As SqlClient.SqlTransaction
        'cnSQL.Open()
        If lblCaption.Text = "Category" Then
            If lblCaption.Tag = "" Then
                MsgBox("Please select an action to perform", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If
            If lblCaption.Tag = "Add" Then
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "InsertCategory"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Description", tDesc.Text)

                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
            End If
            If lblCaption.Tag = "Edit" Then
                If tDesc.Tag = "" Then
                    MsgBox("Pls. select a Category to edit", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If

                myTrans = cnSQL.BeginTransaction()

                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "DeleteCategory"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Description", tDesc.Tag)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()

                cmSQL.CommandText = "InsertCategory"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Description", tDesc.Text)
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "UPDATE StoreItems SET Category='" & tDesc.Text & "' WHERE Category='" & tDesc.Tag & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
            End If
            If lblCaption.Tag = "Delete" Then

                If MsgBox("Do You Want To Delete This Record?" + Chr(13) + "This would delete all associated stock items" + Chr(13) + "Continue (y/n)", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Parameters.Clear()
                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "DeleteCategory"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Description", tDesc.Text)
                cmSQL.ExecuteNonQuery()


                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "DeleteCategory4StockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Category", tDesc.Text)
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "DELETE FROM StoreItems WHERE Category='" & tDesc.Text & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()
                myTrans.Commit()
            End If
            cmSQL.Dispose()
            FillCategory()
        End If


        tDesc.Text = ""
        tDesc.Tag = ""
        If lblCaption.Tag <> "Add" Then lblCaption.Tag = ""
        ' GetData(Me.dataAdapter.SelectCommand.CommandText)
        ' cnSQL.Close()

        Exit Sub
        Resume
handler:
        If Err.Description = "Some product of this category is still in store." Then
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
            tDesc.Text = ""
            tDesc.Tag = ""
            lblCaption.Tag = ""
            myTrans.Rollback()
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
            myTrans.Rollback()
        End If
    End Sub
    Private Sub lvListCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListCat.SelectedIndexChanged
        On Error GoTo SkipIt
        If lvListCat.SelectedItems(0).Text = "<All>" Then
            tQry = " Store IN (" + MyStore & ")"
            tQry4All = ""
        Else
            tQry = " Category='" & lvListCat.SelectedItems(0).Text & "'  AND StockQty.Store IN (" + MyStore & ")"
            tQry4All = " Category='" & lvListCat.SelectedItems(0).Text & "'"
        End If

        justLoading = True
        FillList()
        justLoading = False
        Exit Sub
SkipIt:
    End Sub
    Private Sub RadAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.Click
        If JustStarted = True Then
            JustStarted = False
            Exit Sub
        End If
        tQry1 = " Store IN (" + MyStore & ")"
        FillList()
    End Sub
    Private Sub RadWith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadWith.Click
        tQry1 = " ((StockQty.Qty>0 AND StockQty.TransType='Retail') OR StockQty.TransType='Service' ) AND StockQty.Store IN (" + MyStore & ")"
        FillList()
    End Sub
    Private Sub RadWithOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadWithout.Click
        tQry1 = " ((StockQty.Qty<=0 AND StockQty.TransType='Retail') OR StockQty.TransType='Service') AND StockQty.Store IN (" + MyStore & ")"
        FillList()
    End Sub
   Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        On Error GoTo errhdl
        DGrid.Tag = ""
        If e.RowIndex = -1 Then Exit Sub
        If justLoading = True Then Exit Sub
        'On Error Resume Next

        On Error Resume Next
        If DGrid.Item(0, e.RowIndex).Value Is Nothing Then Exit Sub
        DGrid.Tag = DGrid.Item(0, e.RowIndex).Value
        Me.Tag = DGrid.Item(1, e.RowIndex).Value
        SelNumber2.Value = e.ColumnIndex + 1
        tFilterText2.Text = DGrid.Item(e.ColumnIndex, e.RowIndex).Value


        PanStockImage.Visible = False
        PanStockImage.BackgroundImage = Nothing
        PanStockImage.BackgroundImage = Image.FromFile(StkFrmItemRegister.FindStockItemImageFilename(DGrid.Tag))
        If PanStockImage.BackgroundImage Is Nothing Then Exit Sub
        PanStockImage.Visible = True

        ' If StoredX = 0 And StoredY = 0 Then PanStockImage.Top = tblDetails.Top + DGrid.Top + (10 * e.RowIndex)


        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub DGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEnter
        On Error Resume Next
        FromCellEnter = True
        DGrid_CellClick(sender, e)
        FromCellEnter = False

    End Sub
    Private Sub PanStockImage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanStockImage.MouseDown
        StoredX = e.X
        StoredY = e.Y
        PanStockImage.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanStockImage.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanStockImage.Top = PanStockImage.Top - (StoredY - e.Y)
            PanStockImage.Left = PanStockImage.Left - (StoredX - e.X)
        End If
        PanStockImage.Cursor = Cursors.Default
    End Sub
    Private Sub mnuAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddItem.Click
        If GetUserAccessDetails("Stockitem Register") = False Then Exit Sub
        If ModuleAdd = False Then Exit Sub
        If ST_TransType = "Service" Then
            Dim Childform As New StkFrmItemRegister4Service
            Childform.ReturnCode = ""
            Childform.Action1 = "Add"
            On Error Resume Next
            If TabControl1.SelectedTab.Text = "Category" Then Childform.cboCategory.Tag = lvListCat.SelectedItems(0).Text
            Childform.ShowDialog()
            'On Error Resume Next
            refreshGrid()
        Else
            Dim Childform As New StkFrmItemRegister
            Childform.ReturnCode = ""
            Childform.Action1 = "Add"
            On Error Resume Next
            If TabControl1.SelectedTab.Text = "Category" Then Childform.cboCategory.Tag = lvListCat.SelectedItems(0).Text
            If TabControl1.SelectedTab.Text = "Store" Then Childform.cStore.Tag = lvListStore.SelectedItems(0).Text
            Childform.ShowDialog()
            'On Error Resume Next
            refreshGrid()
        End If
       
    End Sub
    Private Sub mnuEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditItem.Click
        If DGrid.Tag Is Nothing Then Exit Sub
        If GetUserAccessDetails("Stockitem Register") = False Then Exit Sub
        If ModuleEdit = False Then Exit Sub

        If ST_TransType = "Service" Then
            Dim Childform As New StkFrmItemRegister4Service
            Childform.ReturnCode = DGrid.Tag
            Childform.Action1 = "Edit"
            Childform.ShowDialog()
            refreshGrid()
        Else
            Dim Childform As New StkFrmItemRegister
            Childform.ReturnCode = DGrid.Tag
            Childform.Action1 = "Edit"
            Childform.ShowDialog()
            refreshGrid()
        End If
       
    End Sub
    Private Sub mnuDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteItem.Click
        If DGrid.Tag Is Nothing Then Exit Sub
        If GetUserAccessDetails("Stockitem Register") = False Then Exit Sub
        If ModuleDelete = False Then Exit Sub
        If ST_TransType = "Service" Then
            Dim Childform As New StkFrmItemRegister4Service
            Childform.ReturnCode = DGrid.Tag
            Childform.Action1 = "Delete"
            Childform.ShowDialog()
            refreshGrid()
        Else
            Dim Childform As New StkFrmItemRegister
            Childform.ReturnCode = DGrid.Tag
            Childform.Action1 = "Delete"
            Childform.ShowDialog()
            refreshGrid()
        End If
        
    End Sub
    Sub refreshGrid()
        On Error GoTo errhdl
        'On Error Resume Next

        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table
        Exit Sub
errhdl:
        If Err.Number = 5 Then
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub

    Private Sub lvListStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListStore.SelectedIndexChanged
        On Error GoTo SkipIt
        If lvListStore.SelectedItems(0).Text = "<All>" Then
            tQry = ""
            tQry4All = ""
        Else
            tQry = " StockQty.Store='" & lvListStore.SelectedItems(0).Text & "'"
            tQry4All = " StoreItems.Category='@#####JDJDKK#**#!!#!$'"
        End If

        justLoading = True
        FillList()
        justLoading = False
        Exit Sub
SkipIt:
    End Sub
    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Click
        PanInput.Visible = True
        lblCaption.Text = "Category"
    End Sub
    Private Sub TabPage3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Click
        PanInput.Visible = False
    End Sub
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        refreshGrid()
    End Sub
    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
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
                strNewFilter = tFilterText2.Text
            Case Is = "Containing"
                strNewFilter = "*" + tFilterText2.Text + "*"
            Case Is = "Start With"
                strNewFilter = tFilterText2.Text + "*"
            Case Is = "End With"
                strNewFilter = "*" + tFilterText2.Text
        End Select
        While i < DGrid.Rows.Count
            j = 0
            containStr = False
            kj = SelNumber2.Value - 1
            jk = SelNumber2.Value - 1
            For j = kj To jk
                If Not DGrid.Item(j, i).Value Is DBNull.Value Or Nothing Then
                    If LCase(DGrid.Item(j, i).Value) Like LCase(strNewFilter) Then
                        containStr = True
                        wr = wr + 1
                        Exit For
                    End If

                End If
            Next j
            If Not containStr Then
                ' Don't remove rows here or your row indexes will get out of whack!
                ' DGrid.Rows.RemoveAt(i)
                deleteIndexList.Add(i)
            End If
            i = i + 1
        End While
        ' Remove rows by reversed row index order (highest removed first) to keep the indexes in whack.
        deleteIndexList.Reverse()
        For Each idx As Integer In deleteIndexList
            DGrid.Rows.RemoveAt(idx)
        Next
    End Sub
    Private Sub mnuStockPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStockPicture.Click
        If DGrid.Tag Is Nothing Then Exit Sub
        Dim ChildForm As New StkFrmEDoc
        ChildForm.tRefNo.Text = DGrid.Tag + "P"
        ChildForm.tRefNo.Tag = DGrid.Tag
        ChildForm.RadPicture.Checked = True
        ChildForm.PanBody.Visible = True
        ChildForm.ShowDialog()
    End Sub
    Private Function ChkExisting(ByVal ProductCode As String, ByVal lvlist As ListView) As Integer
        On Error GoTo errhdl
        ChkExisting = -1
        For i = 0 To lvlist.Items.Count - 1
            If lvlist.Items(i).SubItems(1).Text = ProductCode Then
                ChkExisting = i
                Exit Function
            End If
        Next
        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Dim Childform As New StkFrmItemHistory
        Childform.ReturnCode = DGrid.Tag
        Childform.ShowDialog()
    End Sub
    Private Sub mnuStockItemHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStockItemHistory.Click
        If DGrid.Tag Is Nothing Then Exit Sub
        If GetUserAccessDetails("StockItem History") = False Then Exit Sub
        Dim Childform As New StkFrmItemHistory
        Childform.ReturnCode = DGrid.Tag
        Childform.ShowDialog()
    End Sub
    Private Sub DGrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGrid.DataError
        Err.Clear()
    End Sub

    Private Sub lvTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTransType.SelectedIndexChanged
        On Error GoTo SkipIt
        If lvTransType.SelectedItems(0).Text = "<All>" Then
            tQry = " Store IN (" + MyStore & ")"
            tQry4All = ""
        Else
            tQry = " StoreItems.TransType='" & lvTransType.SelectedItems(0).Text & "' AND StockQty.Store IN (" + MyStore & ")"
            tQry4All = " StoreItems.TransType='" & lvTransType.SelectedItems(0).Text & "'"
        End If

        justLoading = True
        FillList()
        justLoading = False
        Exit Sub
SkipIt:
    End Sub

    Private Sub RadWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadWith.CheckedChanged

    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class