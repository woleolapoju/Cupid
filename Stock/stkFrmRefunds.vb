Imports System
Imports System.Data.SqlClient
Public Class stkFrmRefunds
    Public RefundType As String = ""
    Dim justLoaded As Boolean = False

    Private Sub FrmRefunds_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Refunds " + RefundType
        AppHeaderLeft1.lblForm.Text = "Refunds " + RefundType

        Me.BackColor = MainTheme
        lvList.BackColor = MainTheme
        lvFullOrder.BackColor = MainTheme

        tCategoryName.BackColor = MainTheme
        tItemCode.BackColor = MainTheme
        tProductName.BackColor = MainTheme
        tClient.BackColor = MainTheme
        tQtyIssued.BackColor = MainTheme
        tSellPrice.BackColor = MainTheme
        tSourceDoc.BackColor = MainTheme

        Panel3.BackColor = Color.White
        justLoaded = True

        If ST_IgnoreStoreAssignment = True Then
            Panel4.Visible = False
        Else
            FillStore()
        End If


        dtpDate.Value = Now
        justLoaded = True
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now



        RadInwards.Enabled = GetUserAccessDetails("Refunds Inwards")
        RadOutwards.Enabled = GetUserAccessDetails("Refunds Outwards")

        If RadInwards.Enabled = True Then
            RadInwards.Checked = True
            RadInwards_Click(sender, e)
        Else
            If RadOutwards.Enabled = True Then RadOutwards_Click(sender, e)
        End If

        If RefundType = "Outwards" Then
            lvFullOrder.Columns(5).Text = "Cost Price"
            lblPrice.Text = "Cost Price"
        End If

        oLoadOrders()
        justLoaded = False
    End Sub
    Private Sub oLoadOrders()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        lvList.Items.Clear()
        lvFullOrder.Items.Clear()
        flush()

        cmSQL.CommandText = "FetchAllOrdersByDate"
        cmSQL.Parameters.AddWithValue("@StartDate", formatDate(dtpStartDate))
        cmSQL.Parameters.AddWithValue("@EndDate", formatDate(dtpEndDate))
        cmSQL.Parameters.AddWithValue("@Store", If(ST_IgnoreStoreAssignment = False, cStore.Text, "@?ALL?@"))
        If RefundType = "Inwards" Then cmSQL.Parameters.AddWithValue("@TheType", "Sales")
        If RefundType = "Outwards" Then cmSQL.Parameters.AddWithValue("@TheType", "Receipt")
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        Dim j As Integer = 0
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        Do While drSQL.Read
            LvItems = New ListViewItem(drSQL.Item("OrderNo").ToString)
            LvItems.SubItems.Add(Format(drSQL.Item("Date"), "dd-MMM-yyy"))
            LvItems.SubItems.Add(drSQL.Item("NoOfItems").ToString)
            LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("Value"), 2), "standard"))
            LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("AmountPaid"), 2), "standard"))
            lvList.Items.AddRange(New ListViewItem() {LvItems})
            j = j + 1

        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        lblCount.Text = "Count: " + j.ToString

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Sub flush()
        tCategoryName.Tag = ""
        tCategoryName.Text = ""
        tItemCode.Text = ""
        tProductName.Text = ""
        tSellPrice.Text = ""
        tRefundAmt.Text = ""
        tRefundQty.Text = ""
        tQtyIssued.Text = ""
        tStore.Text = ""
        tTransType.Text = ""
    End Sub
    Private Sub LoadRefundableOrder(ByVal TheOrderNo As Long)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        lvFullOrder.Items.Clear()
        tClient.Text = ""
        tOrderNo.Text = ""
        tSourceDoc.Text = ""
        flush()

        If RefundType = "Inwards" Then cmSQL.CommandText = "FetchSales"
        If RefundType = "Outwards" Then cmSQL.CommandText = "FetchReceipt"
        cmSQL.Parameters.AddWithValue("@OrderNo", TheOrderNo)
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                tOrderNo.Text = drSQL.Item("OrderNo")
                tSourceDoc.Text = drSQL.Item("SourceDoc")
                If RefundType = "Inwards" Then
                    If drSQL.Item("CustomerCode") <> "" Then
                        tClient.Text = ChkNull(drSQL.Item("CustomerCode")) + " - " + ChkNull(drSQL.Item("CustomerName"))
                    Else
                        tClient.Text = ""
                    End If
                Else
                    If drSQL.Item("ClientCode") <> "" Then
                        tClient.Text = ChkNull(drSQL.Item("ClientCode")) + " - " + ChkNull(drSQL.Item("ClientName"))
                    Else
                        tClient.Text = ""
                    End If
                End If
            End If
        Else
            MsgBox("Order No do not exist", MsgBoxStyle.Information, strApptitle)
        End If
        drSQL.Close()
        drSQL = cmSQL.ExecuteReader()
        Dim initialText As String = ""
        Dim LvItems As New ListViewItem
        Do While drSQL.Read
            If RefundType = "Inwards" Then initialText = drSQL.Item("SalesIndex")
            If RefundType = "Outwards" Then initialText = drSQL.Item("ReceiptIndex")
            LvItems = New ListViewItem(initialText)
            LvItems.SubItems.Add(drSQL.Item("OrderNo"))
            LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            If RefundType = "Inwards" Then LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("SellPrice"), 2), "standard"))
            If RefundType = "Outwards" Then LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("CostPrice"), 2), "standard"))
            LvItems.SubItems.Add(drSQL.Item("RefundQty"))
            lvFullOrder.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        getClientBalance(GetIt4Me(tClient.Text, " - "))

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub oLoad(ByVal TheIndexNo As Long, ByVal TheOrderNo As Long)

        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        flush()

        If RefundType = "Inwards" Then cmSQL.CommandText = "FetchSalesDetails"
        If RefundType = "Outwards" Then cmSQL.CommandText = "FetchReceiptDetails"
        cmSQL.Parameters.AddWithValue("@Index", TheIndexNo)
        cmSQL.Parameters.AddWithValue("@OrderNo", TheOrderNo)
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                If drSQL.Item("Qty") - drSQL.Item("RefundQty") < 1 Then
                    MsgBox("This item has being fully refunded", MsgBoxStyle.Information, strApptitle)
                    'cmSQL.Connection.Close()
                    cmSQL.Dispose()
                    drSQL.Close()
                    'cnSQL.Close()
                    'cnSQL.Dispose()
                    Exit Sub
                End If
                tOrderNo.Text = drSQL.Item("OrderNo")
                '  tCategoryName.Tag = drSQL.Item("CategoryCode")
                tCategoryName.Text = drSQL.Item("CategoryName")
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tSellPrice.Text = Math.Round(drSQL.Item("SellPrice"), 2)
                tRefundAmt.Text = Math.Round(drSQL.Item("SellPrice"), 2)
                tRefundQty.Text = 1
                tQtyIssued.Text = drSQL.Item("Qty") - drSQL.Item("RefundQty")

                tStore.Text = drSQL.Item("Store")
                tTransType.Text = drSQL.Item("TransType")
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
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub dtpStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        If justLoaded = True Then Exit Sub
        oLoadOrders()
    End Sub
    Sub getClientBalance(ByVal ClientCode As String)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        lblBalance.Text = "0.0"
        cmSQL.CommandText = "SELECT * FROM ClientBalances WHERE CustomerCode='" & ClientCode & "'"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim LvItems As New ListViewItem
        If drSQL.HasRows Then
            If drSQL.Read Then lblBalance.Text = Str(Math.Abs(drSQL.Item("Balance"))) + " " + IIf(drSQL.Item("Balance") > 0, "DR", "CR")
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
    Private Sub dtpEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        If justLoaded = True Then Exit Sub
        oLoadOrders()
    End Sub
    Private Sub lvList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.Click
        On Error Resume Next
        LoadRefundableOrder(lvList.SelectedItems(0).Text)
    End Sub
    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged
        On Error Resume Next
        LoadRefundableOrder(lvList.SelectedItems(0).Text)
    End Sub

    Private Sub tOrderNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tOrderNo.LostFocus
        LoadRefundableOrder(tOrderNo.Text)
    End Sub

    Private Sub tRefundQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tRefundQty.LostFocus
        If Val(tRefundQty.Text) > Val(tQtyIssued.Text) Then
            MsgBox("Quantity Refunded cannot be greater than Issued quantity", MsgBoxStyle.Information, strApptitle)
            tRefundQty.Focus()
        End If
    End Sub

    Private Sub lvFullOrder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFullOrder.DoubleClick
        On Error Resume Next
        tOrderNo.Tag = Val(lvFullOrder.SelectedItems(0).Text)
        oLoad(Val(lvFullOrder.SelectedItems(0).Text), lvFullOrder.SelectedItems(0).SubItems(1).Text)
    End Sub
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub tRefundAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tRefundAmt.LostFocus
        If CDbl(tRefundAmt.Text) > Val(tRefundQty.Text) * CDbl(tSellPrice.Text) Then
            MsgBox("Amount refunded is more than the calculated refund value", MsgBoxStyle.Information, strApptitle)
            tRefundAmt.Focus()
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader


        If ValidateDate(dtpDate.Text, "Refund Date") = False Then Exit Sub

        If Val(tOrderNo.Tag) = 0 Or Val(tOrderNo.Text) = 0 Or tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Then
            MsgBox("Incomplete information", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If Val(tRefundAmt.Text) <= 0 Then
            ' MsgBox("Refund amount must be greater than zero (0)", MsgBoxStyle.Information, strApptitle)
            If MsgBox("Refund amount is zero (0)....continue (y/n)", vbYesNo + MsgBoxStyle.Information, strApptitle) = vbNo Then
                Exit Sub
            End If
        End If
        If Val(tRefundQty.Text) <= 0 Then
            MsgBox("Refund quantity must be greater than zero (0)", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If MsgBox("The selected transaction would be refunded" + Chr(13) + "It cannot be revised" + Chr(13) + "Continue (y/n)", vbYesNo + vbCritical, strApptitle) = vbNo Then Exit Sub

        'cnSQL.Open()

        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "InsertRefund"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@RefundType", RefundType)
        cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
        cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
        cmSQL.Parameters.AddWithValue("@IndexNo", tOrderNo.Tag)
        cmSQL.Parameters.AddWithValue("@ProductCode", tItemCode.Text)
        cmSQL.Parameters.AddWithValue("@ProductName", tProductName.Text)
        cmSQL.Parameters.AddWithValue("@CategoryName", tCategoryName.Text)
        cmSQL.Parameters.AddWithValue("@RefundQty", Val(tRefundQty.Text))
        cmSQL.Parameters.AddWithValue("@RefundAmt", CDbl(tRefundAmt.Text))
        cmSQL.Parameters.AddWithValue("@Price", CDbl(tSellPrice.Text))
        If tClient.Text = " - " Or Trim(tClient.Text) = "" Then
            cmSQL.Parameters.AddWithValue("@ClientCode", "")
            cmSQL.Parameters.AddWithValue("@ClientName", "")
        Else
            cmSQL.Parameters.AddWithValue("@ClientCode", GetIt4Me(tClient.Text, " - "))
            cmSQL.Parameters.AddWithValue("@ClientName", Microsoft.VisualBasic.Mid(tClient.Text, Len(GetIt4Me(tClient.Text, " - ")) + 4))
        End If
        cmSQL.Parameters.AddWithValue("@UserName", sysUserName)
        cmSQL.Parameters.AddWithValue("@Store", tStore.Text)
        cmSQL.Parameters.AddWithValue("@TransType", tTransType.Text)
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        tClient.Text = ""
        tOrderNo.Text = ""
        tOrderNo.Tag = ""
        tSourceDoc.Text = ""
        lvFullOrder.Items.Clear()

        flush()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub RadInwards_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadInwards.CheckedChanged

    End Sub

    Private Sub RadInwards_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadInwards.Click
        RefundType = "Inwards"
        Me.Text = "Refunds " + RefundType

        AppHeaderLeft1.lblForm.Text = IIf(RefundType = "Inwards", "Goods Returned BY Clients", "Goods Returned TO Suppliers")


        lvFullOrder.Columns(5).Text = "Sell Price"
        lblPrice.Text = "Sell Price"

        oLoadOrders()
    End Sub

    Private Sub RadOutwards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadOutwards.Click
        RefundType = "Outwards"
        Me.Text = "Refunds " + RefundType
        AppHeaderLeft1.lblForm.Text = IIf(RefundType = "Inwards", "Goods Returned BY Clients", "Goods Returned TO Suppliers")

        lvFullOrder.Columns(5).Text = "Cost Price"
        lblPrice.Text = "Cost Price"

        oLoadOrders()
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

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        If justLoaded = True Then Exit Sub
        oLoadOrders()
    End Sub
End Class