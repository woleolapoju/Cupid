Imports System.Data.SqlClient
Imports System.IO
Public Class StkFrmItemRegister
    Public ReturnCode As String
    Public Action1 As String
    Public ReturnBatchNo As String
    Public ReturnMadeDate As Date
    Public ReturnExpiryDate As Date
    Public ReturnDiscontinue As Boolean
    Public oneTime As Boolean
    Dim Action As AppAction
    Public StockCode As String
    Public frmParent As Object
    Private Sub StkFrmItemRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        AppHeader1.lblForm.Text = "Stock Items"
        BackColor = MainTheme
        tID.BackColor = MainTheme
        tUnitInStore.BackColor = MainTheme
    
        PanService.Top = PanTransType.Bottom + 5
        

        LoadCategory()
      


        LoadShelfLocation()
        PanTransType.Enabled = False
        cboTransType.Text = ST_TransType

        If ST_TransType = "Both" Then
            PanTransType.Enabled = True
            loadStore()
        End If


        If cboCategory.Tag <> "" Then cboCategory.Text = cboCategory.Tag

        If Action1 = "Add" Then
            ' Me.Width = 400
            ' GrpBatches.Visible = False
            lblUnitInStock.Text = "Opening Stock:"
            tUnitInStore.ReadOnly = False
            tUnitInStore.BackColor = Color.White
            PanBatch.Visible = True
            PanStore.Visible = True
            cboTransType.SelectedIndex = 0

            FillStore()


            If cStore.Tag <> "" Then cStore.Text = cStore.Tag
            PanPrevID.Visible = True

            If ST_TransType = "Both" Then FillGrid("@##EJMDKK$@@$$$&*$(($&&$(($(")

            Action = AppAction.Add
        End If

        If Action1 = "Edit" Then Action = AppAction.Edit
        If Action1 = "Delete" Then Action = AppAction.Delete
        InitialiseAction()
       
        If ReturnCode <> "" Then
            oLoad(ReturnCode)
            StockCode = ReturnCode
        End If

        cboCategory.Text = cboCategory.Tag
        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    '    Private Sub FillBatches(ByVal strQuery As String)
    '        On Error GoTo errhdl
    '        If Trim(strQuery) = "" Then Exit Sub
    '        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
    '        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
    '        Dim drSQL As SqlDataReader
    '        Dim MySQL As String = ""
    '        cboBatch.Items.Clear()

    '        cmSQL.CommandText = "FetchActiveBatchPerStockItem"
    '        cmSQL.Parameters.AddWithValue("@ProductCode", strQuery)
    '        cmSQL.CommandType = CommandType.StoredProcedure

    '        'cnSQL.Open()
    '        drSQL = cmSQL.ExecuteReader()

    '        Do While drSQL.Read
    '            cboBatch.Items.Add(drSQL.Item("BatchNo"))
    '        Loop
    '        'cmSQL.Connection.Close()
    '        cmSQL.Dispose()
    '        drSQL.Close()
    '        ' cnSQL.Close()
    '        'cnSQL.Dispose()

    '        Exit Sub
    '        Resume
    'errhdl:
    '        MsgBox(Err.Description, vbCritical, strApptitle)
    '    End Sub

    Private Sub LoadShelfLocation()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()
        cShelfLocation.Items.Clear()
        cmSQL.CommandText = "SELECT DISTINCT ISNULL(ShelfLocation,'') AS ShelfLocation FROM StoreItems ORDER BY ShelfLocation"
        cmSQL.CommandType = CommandType.Text

        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cShelfLocation.Items.Add(drSQL.Item("ShelfLocation"))
        Loop
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
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

        cStore.SelectedIndex = 0

        On Error Resume Next
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
    Private Function oLoad(ByVal strValue As String) As Boolean
        On Error GoTo handler
        oLoad = False
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If strValue = "" Then Exit Function
        oLoad = False

        cmSQL.CommandText = "FetchStoreItemsWithStockBalance"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", strValue)

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                tCode.Text = drSQL.Item("ProductCode")
                tID.Text = drSQL.Item("AutoID")
                tName.Text = drSQL.Item("productName")
                cboCategory.Text = drSQL.Item("Category")
                tReorder.Text = Val(drSQL.Item("ReorderLevel"))
                tMaxQty.Text = Val(drSQL.Item("MaxQty"))
                tUnitInStore.Text = Val(drSQL.Item("TotalQty"))
                chkDiscontinue.Checked = drSQL.Item("discontinue")
                tRate.Text = Val(drSQL.Item("Rate"))
                tDesc.Text = ChkNull(drSQL.Item("productDesc"))
                tRemark.Text = ChkNull(drSQL.Item("Remark"))
                cShelfLocation.Text = ChkNull(drSQL.Item("ShelfLocation"))
                cboTransType.Text = ChkNull(drSQL.Item("TransType"))

                oLoad = True
            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()

        On Error Resume Next
        PictStockItem.Image = Image.FromFile(FindStockItemImageFilename(strValue))

        'If cboTransType.Text = "Service" Then
        FillGrid(ReturnCode)


        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function
    Private Sub InitialiseAction()
        Select Case Action
            Case AppAction.Add
                lblAction.Text = "New Record"
                cmdOk.Visible = True
            Case AppAction.Browse
                lblAction.Text = "Browse Record"
                cmdOk.Visible = False
            Case AppAction.Edit
                lblAction.Text = "Edit Record"
                cmdOk.Visible = True
            Case AppAction.Delete
                lblAction.Text = "Delete Record"
                cmdOk.Visible = True
        End Select
        Flush(Me)
    End Sub
    Private Sub Flush(ByVal tContainer As Control)
        On Error Resume Next
        Dim ctl As Control
        Dim txt As TextBox
        For Each ctl In tContainer.Controls
            If TypeOf ctl Is TextBox Then
                txt = ctl
                txt.Text = ""
            End If
            If ctl.HasChildren Then
                Flush(ctl)
            End If
        Next
        tCode.Text = ""
        chkDiscontinue.Checked = False
        tReorder.Text = 0
        tMaxQty.Text = 0
        tRate.Text = 0
        tUnitInStore.Text = 0
        'ReturnCode = ""
        cboTransType.Text = ST_TransType

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
        If Trim(tCode.Text) = "" Then

            If drSQL.HasRows Then
                If drSQL.Read Then tCode.Text = CStr(CLng(drSQL.Item("NewID") + j))
            Else
                tCode.Text = "1"
            End If
            tID.Text = Val(tCode.Text)
        Else
            If drSQL.HasRows Then
                If drSQL.Read Then tID.Text = CLng(drSQL.Item("NewID") + j)
            Else
                tID.Text = 1
            End If
            tCode.Tag = Val(tCode.Text)
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
    Public Function IsValidForm(ByVal tContainer As Control) As Boolean
        On Error GoTo handler
        On Error Resume Next
        IsValidForm = True
        If IsFormValid = False Then Exit Function
        Dim ctl As Control
        Dim txt As TextBox
        For Each ctl In tContainer.Controls
            'If TypeOf ctl Is TextBox Then
            txt = ctl
            Select Case txt.Name
                Case Is = "tCode", "tDesc"
                    If txt.Text = "" Then
                        MsgBox(Mid(txt.Name, 2) + " is required", MsgBoxStyle.Information, strApptitle)
                        IsValidForm = False
                        IsFormValid = False
                        Exit For
                        Exit Function
                    End If
                Case Is = "cboCategory"
                    If txt.Text = "" Then
                        MsgBox("Category is required", MsgBoxStyle.Information, strApptitle)
                        IsValidForm = False
                        IsFormValid = False
                        Exit For
                        Exit Function
                    End If

            End Select
        Next

        Exit Function
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        If Action = 0 Then
            MsgBox("Please selected ADD,EDIT,DELETE or BROWSE")
            Exit Sub
        End If
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim jk As Integer = 1
FetchNoAgain:
        If Action = AppAction.Add Then FetchNextNo(jk)
        If Action <> AppAction.Delete Then
            If Not IsValidForm(Me) Or IsFormValid = False Then
                IsFormValid = True
                Exit Sub
            End If
            If Action = AppAction.Add Then
                If cboTransType.Text <> "Service" And Val(tUnitInStore.Text) > 0 Then
                    If Trim(tCost.Text) = "" Then tCost.Text = 0
                    If Trim(tSellPrice.Text) = "" Then tSellPrice.Text = 0
                    If IsNumeric(tCost.Text) = False Then
                        MsgBox("A number is expected as Cost price", MsgBoxStyle.Information, strApptitle)
                        Exit Sub
                    End If
                    If IsNumeric(tSellPrice.Text) = False Then
                        MsgBox("A number is expected as Sell price", MsgBoxStyle.Information, strApptitle)
                        Exit Sub
                    End If
                    If CDbl(tCost.Text) > CDbl(tSellPrice.Text) Then
                        If MsgBox("Cost price is greater than Sell price ..... continue(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, strApptitle) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                    If CDbl(tCost.Text) = CDbl(tSellPrice.Text) Then
                        If MsgBox("Cost price is equal than Sell price ..... continue(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, strApptitle) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
            IsFormValid = True
            'cnSQL.Open()
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Select Case Action
            Case AppAction.Add
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertStoreItems"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                cmSQL.Parameters.AddWithValue("@ProductName", tName.Text)
                cmSQL.Parameters.AddWithValue("@Category", cboCategory.Text)
                If cboTransType.Text = "Service" Then
                    cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
                    cmSQL.Parameters.AddWithValue("@MaxQty", 0)
                    cmSQL.Parameters.AddWithValue("@Rate", 0)
                    cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")
                Else
                    cmSQL.Parameters.AddWithValue("@ReorderLevel", Val(tReorder.Text))
                    cmSQL.Parameters.AddWithValue("@MaxQty", Val(tMaxQty.Text))
                    cmSQL.Parameters.AddWithValue("@Rate", Val(tRate.Text))
                    cmSQL.Parameters.AddWithValue("@ShelfLocation", cShelfLocation.Text)
                End If

                cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
                cmSQL.Parameters.AddWithValue("@ProductDesc", tDesc.Text)
                cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text)
                cmSQL.Parameters.AddWithValue("@TransType", cboTransType.Text)

                cmSQL.ExecuteNonQuery()


                If cboTransType.Text = "Service" Then
                    Got1 = 0
                    For i = 0 To DGrid.Rows.Count - 1
                        If Val(DGrid.Item(2, i).Value) < 0 And Val(DGrid.Item(3, i).Value) < 0 Then GoTo skipIt
                        If DGrid.Item(0, i).Value = True Or DGrid.Item(0, i).Value = 1 Then
                            cmSQL.Parameters.Clear()
                            cmSQL.CommandText = "InsertStockQty"
                            cmSQL.CommandType = CommandType.StoredProcedure
                            cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                            cmSQL.Parameters.AddWithValue("@Store", DGrid.Item(1, i).Value)
                            cmSQL.Parameters.AddWithValue("@Qty", 0)
                            cmSQL.Parameters.AddWithValue("@CostPriceNew", IIf(DGrid.Item(2, i).Value = Nothing, 0, CDbl(DGrid.Item(2, i).Value)))
                            cmSQL.Parameters.AddWithValue("@SellPriceNew", IIf(DGrid.Item(3, i).Value = Nothing, 0, CDbl(DGrid.Item(3, i).Value)))
                             cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)

                            cmSQL.Parameters.AddWithValue("@TransType", "Service")
                            cmSQL.ExecuteNonQuery()
                            Got1 = 1
                        End If


skipIt:
                    Next

                    'If Got1 = 0 Then
                    '    MsgBox("Please select at least one (1) Store in the list", MsgBoxStyle.Information, strApptitle)
                    '    myTrans.Rollback()
                    '    StockCode = ""
                    'Else
                    myTrans.Commit()
                    StockCode = tCode.Text
                    'End If


                Else
                    If Val(tUnitInStore.Text) > 0 Then
                        cmSQL.Parameters.Clear()
                        cmSQL.CommandText = "InsertAdjustment"
                        cmSQL.CommandType = CommandType.StoredProcedure
                        cmSQL.Parameters.AddWithValue("@Date", Format(Now, "dd-MMM-yyyy"))
                        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                        cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                        cmSQL.Parameters.AddWithValue("@ProductName", tName.Text)
                        cmSQL.Parameters.AddWithValue("@Category", cboCategory.Text)
                        'End If
                        cmSQL.Parameters.AddWithValue("@Qty", Val(tUnitInStore.Text))
                        cmSQL.Parameters.AddWithValue("@PrevQty", 0)
                        cmSQL.Parameters.AddWithValue("@Cost", CDbl(tCost.Text))
                        cmSQL.Parameters.AddWithValue("@PrevCost", 0)
                        cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(tSellPrice.Text))
                        cmSQL.Parameters.AddWithValue("@PrevSellPrice", 0)
                        cmSQL.Parameters.AddWithValue("@Reason", "Opening Stock")
                        cmSQL.Parameters.AddWithValue("@Username", sysUserName)

                        cmSQL.ExecuteNonQuery()

                        cmSQL.Parameters.Clear()
                        cmSQL.CommandText = "InsertStockQty"
                        cmSQL.CommandType = CommandType.StoredProcedure
                        cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                        'If ST_IgnoreBatch Then
                        '    cmSQL.Parameters.AddWithValue("@BatchNo", "@Batch")
                        'Else
                        'End If
                        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                        cmSQL.Parameters.AddWithValue("@Qty", Val(tUnitInStore.Text))
                        cmSQL.Parameters.AddWithValue("@CostPriceNew", CDbl(tCost.Text))
                        cmSQL.Parameters.AddWithValue("@SellPriceNew", CDbl(tSellPrice.Text))
                        cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                        cmSQL.Parameters.AddWithValue("@TransType", cboTransType.Text)
                        cmSQL.ExecuteNonQuery()
                    End If

                    myTrans.Commit()

                    tPrevID.Text = tCode.Text
                    StockCode = tCode.Text

                    End If

            Case AppAction.Edit
                    If ReturnCode = "" Then
                        MsgBox("Pls. select a Stock Item Code to edit", MsgBoxStyle.Information, strApptitle)
                        Exit Sub
                    End If

                    myTrans = cnSQL.BeginTransaction()

                    cmSQL.Parameters.Clear()
                    cmSQL.Transaction = myTrans
                    cmSQL.Parameters.Clear()

                    cmSQL.CommandText = "UpdateStoreItems"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@ProductCode1", ReturnCode)
                    cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                    cmSQL.Parameters.AddWithValue("@ProductName", tName.Text)
                    cmSQL.Parameters.AddWithValue("@Category", cboCategory.Text)
                    cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                    cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
                    cmSQL.Parameters.AddWithValue("@ProductDesc", tDesc.Text)
                    cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text)
                    cmSQL.Parameters.AddWithValue("@TransType", cboTransType.Text)

                    If cboTransType.Text = "Service" Then
                    cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
                        cmSQL.Parameters.AddWithValue("@MaxQty", 0)
                        cmSQL.Parameters.AddWithValue("@Rate", 0)
                        cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")
                    Else
                    cmSQL.Parameters.AddWithValue("@ReorderLevel", Val(tReorder.Text))
                        cmSQL.Parameters.AddWithValue("@MaxQty", Val(tMaxQty.Text))
                        cmSQL.Parameters.AddWithValue("@Rate", Val(tRate.Text))
                        cmSQL.Parameters.AddWithValue("@ShelfLocation", cShelfLocation.Text)
                    End If
                    cmSQL.ExecuteNonQuery()

                    If cboTransType.Text = "Service" And ST_TransType = "Both" Then
                        cmSQL.Parameters.Clear()
                        cmSQL.CommandText = "DeleteStockItem4StockQty"
                        cmSQL.CommandType = CommandType.StoredProcedure
                        cmSQL.Parameters.AddWithValue("@ProductCode", ReturnCode)
                        cmSQL.ExecuteNonQuery()

                        Got1 = 0
                        For i = 0 To DGrid.Rows.Count - 1
                            If Val(DGrid.Item(2, i).Value) < 0 And Val(DGrid.Item(3, i).Value) < 0 Then GoTo skipIt1
                            If DGrid.Item(0, i).Value = True Or DGrid.Item(0, i).Value = 1 Then
                                cmSQL.Parameters.Clear()
                                cmSQL.CommandText = "InsertStockQty"
                                cmSQL.CommandType = CommandType.StoredProcedure
                                cmSQL.Parameters.AddWithValue("@ProductCode", tCode.Text)
                                cmSQL.Parameters.AddWithValue("@BatchNo", "@Batch")
                                cmSQL.Parameters.AddWithValue("@Store", DGrid.Item(1, i).Value)
                                cmSQL.Parameters.AddWithValue("@Qty", 0)
                                cmSQL.Parameters.AddWithValue("@CostPriceNew", IIf(DGrid.Item(2, i).Value = Nothing, 0, CDbl(DGrid.Item(2, i).Value)))
                                cmSQL.Parameters.AddWithValue("@SellPriceNew", IIf(DGrid.Item(3, i).Value = Nothing, 0, CDbl(DGrid.Item(3, i).Value)))
                                cmSQL.Parameters.AddWithValue("@DateMade", CDate("01-Jan-1900")) ' ReturnMadeDate)
                                cmSQL.Parameters.AddWithValue("@ExpiryDate", CDate("01-Jan-2900")) ' + Trim(Year(Now) + 100))) ' ReturnExpiryDate)
                                cmSQL.Parameters.AddWithValue("@Discontinue", ReturnDiscontinue)
                                cmSQL.Parameters.AddWithValue("@TransType", "Service")
                                cmSQL.ExecuteNonQuery()
                                Got1 = 1
                            End If
skipIt1:
                        Next

                        'If Got1 = 0 Then
                        '    MsgBox("Please select at least one (1) Store in the list", MsgBoxStyle.Information, strApptitle)
                        '    myTrans.Rollback()
                        '    StockCode = ""
                        'Else
                        myTrans.Commit()
                        StockCode = tCode.Text
                        'End If

                    Else
                        If PanTransType.Enabled = True Then
                            cmSQL.CommandText = "UPDATE StockQty SET TransType='" & cboTransType.Text & "', ProductCode='" & tCode.Text & "' WHERE ProductCode='" & ReturnCode & "'"
                            cmSQL.CommandType = CommandType.Text
                            cmSQL.ExecuteNonQuery()
                        End If

                        If tCode.Text <> ReturnCode Then
                            cmSQL.CommandText = "UPDATE StockQty SET ProductCode='" & tCode.Text & "' WHERE ProductCode='" & ReturnCode & "'"
                            cmSQL.CommandType = CommandType.Text
                            cmSQL.ExecuteNonQuery()
                        End If

                        myTrans.Commit()

                        StockCode = tCode.Text

                    End If


            Case AppAction.Delete
                    If ReturnCode = "" Then
                        MsgBox("Pls. select a Stock Item to delete", MsgBoxStyle.Information, strApptitle)
                        Exit Sub
                    End If
                    If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

                    myTrans = cnSQL.BeginTransaction()

                    cmSQL.Transaction = myTrans

                    cmSQL.CommandText = "DeleteStockItem4StockQty"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@ProductCode", ReturnCode)
                    cmSQL.ExecuteNonQuery()

                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "DeleteStoreItems"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@ProductCode", ReturnCode)
                    cmSQL.ExecuteNonQuery()


                    myTrans.Commit()

                    StockCode = ""

        End Select
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        If oneTime = True Then
            frmParent.ReturnItemCode = tCode.Text
            Me.Close()
        End If
        ' cnSQL.Close()
        'cnSQL.Dispose()
        If Action <> AppAction.Add Then Me.Close()
        Flush(Me)
        ReturnCode = ""
        tPrevID.Text = StockCode
        For i = 0 To DGrid.Rows.Count - 1
            DGrid.Item(0, i).Value = 1
            DGrid.Item(2, i).Value = 0
            DGrid.Item(3, i).Value = 0
        Next

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
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
    Private Sub LoadCategory()
        On Error GoTo errHdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandText = "SELECT * FROM CATEGORY"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        cboCategory.Items.Clear()
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cboCategory.Items.Add(drSQL.Item("Description"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
errHdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub lnkEDoc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEDoc.LinkClicked
        Dim ChildForm As New StkFrmEDoc
        ' ChildForm.RadBill.Checked = True
        ChildForm.tRefNo.Text = StockCode
        ChildForm.tRefNo.Tag = "D"
        ChildForm.ShowDialog()
    End Sub
    Private Sub lnkImage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImage.LinkClicked
        Dim ChildForm As New StkFrmEDoc
        ' ChildForm.RadBill.Checked = True
        ChildForm.tRefNo.Text = StockCode
        ChildForm.tRefNo.Tag = "P"
        ChildForm.ShowDialog()
    End Sub

    Public Function FindStockItemImageFilename(ByVal ProductCode As String) As String
        On Error GoTo handler
        On Error Resume Next
        FindStockItemImageFilename = ""
        Dim Directory As New IO.DirectoryInfo(eDocDir + "\")
        Dim allFiles As IO.FileInfo() = Directory.GetFiles(ProductCode + "P*.*", SearchOption.TopDirectoryOnly)
        'Dim allFiles As IO.FileInfo() = Directory.GetFiles("*.*")
        Dim singleFile As IO.FileInfo
        For Each singleFile In allFiles
            FindStockItemImageFilename = eDocDir + "\" + singleFile.Name
            Exit Function

        Next

        Exit Function
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Function
    Private Sub cboTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTransType.SelectedIndexChanged
        If cboTransType.Text = "Service" And ST_TransType = "Both" Then
            PanService.Visible = True
            PanRetail.Visible = False
            PictStockItem.Visible = False
        Else
            PanService.Visible = False
            PanRetail.Visible = True
            PictStockItem.Visible = True
        End If
    End Sub

    Private Sub loadStore()
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
        drSQL = cmSQL.ExecuteReader()
        Dim j As Integer = 0
        Do While drSQL.Read
            DGrid.Rows.Add()
            DGrid.Rows(j).Cells(0).Value = 1
            DGrid.Rows(j).Cells(1).Value = drSQL.Item("Store")
            DGrid.Rows(j).Cells(2).Value = 0
            DGrid.Rows(j).Cells(3).Value = 0
            j = j + 1
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub FillGrid(ByVal strCode As String)
        On Error GoTo handler
        Dim i As Integer = 0
        For i = 0 To DGrid.Rows.Count - 1
            DGrid.Rows(i).Cells(0).Value = 0
        Next
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cmSQL.CommandText = "SELECT STORE.Store, isnull(STOCKQTY.CostPriceNew,0) AS CostPriceNew, isnull(STOCKQTY.SellPriceNew,0) AS SellPriceNew FROM STORE LEFT OUTER JOIN STOCKQTY ON STORE.Store = STOCKQTY.Store WHERE TransType='Service' AND ProductCode='" & strCode & "'"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        Do While drSQL.Read
            For i = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells(1).Value = drSQL.Item("Store") Then
                    DGrid.Rows(i).Cells(0).Value = 1
                    DGrid.Rows(i).Cells(2).Value = Format(drSQL.Item("CostPriceNew"), "standard")
                    DGrid.Rows(i).Cells(3).Value = Format(drSQL.Item("SellPriceNew"), "standard")
                End If
            Next
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
End Class