Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Data.SqlClient

Public Class FrmBarcode
    Dim SelectedStore1 As String
    Private Sub FrmBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now
        '  oLoadCategory()
        AppHeaderLeft1.lblForm.Text = "Barcode Labels"
        DGrid.BackgroundColor = MainTheme
        lvCategory.BackColor = MainTheme
        lvProduct.BackColor = MainTheme

        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate

        Panel1.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        Panel4.BackColor = HeaderTheme
        cStore.BackColor = HeaderTheme

        FillStore()

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
        oLoadProduct(lvCategory.SelectedItems(0).Text)
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

    Private Sub lvProduct_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvProduct.ItemCheck
        On Error GoTo handler
        varifyChk(e.Index, e.NewValue)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Sub varifyChk(ByVal TheIndex As Integer, ByVal chked As Boolean)
        On Error GoTo handler

        Dim PositionInList As Integer = ProductAreadyInList(lvProduct.Items(TheIndex).Text)
        If PositionInList >= 0 And chked = True Then
            MsgBox("Already in list", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If chked = True Then

            DGrid.Rows.Add()
            Dim w As Integer = DGrid.Rows.Count - 1
            DGrid.Item(0, w).Value = lvProduct.Items(TheIndex).Text
            DGrid.Item(1, w).Value = lvProduct.Items(TheIndex).SubItems(1).Text
            DGrid.Item(2, w).Value = lvProduct.Items(TheIndex).SubItems(2).Text
        Else
            If PositionInList >= 0 Then DGrid.Rows.RemoveAt(PositionInList)
        End If

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Function ProductAreadyInList(ByVal ProductCode As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To DGrid.Rows.Count - 1
            If DGrid.Item(0, i).Value = ProductCode Then
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
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        DGrid.Rows.Clear()
    End Sub

    Private Sub cmdGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerate.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim j As Integer
        Dim k As Integer
        Dim RptFilename As ReportDocument = New ReportDocument

        If DGrid.Rows.Count < 1 Then Exit Sub
        Dim myTrans As SqlClient.SqlTransaction
        'cnSQL.Open()

        cmSQL.CommandText = "DELETE FROM BarcodeTrash"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        For j = 0 To DGrid.Rows.Count - 1
            If Val(DGrid.Item(2, j).Value) > 0 Then
                For k = 1 To DGrid.Item(2, j).Value
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "InsertBarcodeTrash"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@ProductCode", DGrid.Item(0, j).Value)
                    cmSQL.ExecuteNonQuery()
                Next
            End If
        Next j

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()

        'cnSQL.Close()
        'cnSQL.Dispose()

        RptFilename = New Barcodes

        FrmRptDisplay.myReportDocument = RptFilename
        FrmRptDisplay.SelFormula = "{RptStoreItemsWithQty.Store}='" & cStore.Text & "'"
        FrmRptDisplay.RptDestination = "Screen"
        FrmRptDisplay.ShowDialog()


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub cmdLoadReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadReceipt.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()

        cmSQL.CommandText = "SELECT ProductCode,ProductName, Qty, [Date] FROM RptReceipt WHERE [Date]>='" & Format(dtpStartDate.Value, "dd-MMM-yyyy") & "' AND [Date]<='" & Format(dtpEndDate.Value, "dd-MMM-yyyy") & "' AND ReceiptStore='" & cStore.Text & "'"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        Dim i As Integer
        Do While drSQL.Read
            DGrid.Rows.Add()
            i = DGrid.Rows.Count - 1
            DGrid.Item(0, i).Value = drSQL.Item("ProductCode")
            DGrid.Item(1, i).Value = drSQL.Item("ProductName")
            DGrid.Item(2, i).Value = drSQL.Item("Qty")
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        If DGrid.RowCount > 0 Then
            If cStore.Text <> SelectedStore1 Then
                MsgBox("Sorry you cannot change STORE at this time...." + Chr(13) + Chr(10) + "Selection already made from current store")
                cStore.Text = SelectedStore1
            End If
            Exit Sub
        End If
        oLoadCategory()
        SelectedStore1 = cStore.Text
    End Sub

    Private Sub lvProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProduct.SelectedIndexChanged

    End Sub

    Private Sub cmdLoadAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadAdjustment.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()

        cmSQL.CommandText = "SELECT ProductCode,ProductName, Qty, [Date] FROM RptAdjustment WHERE [Date]>='" & Format(dtpStartDateAdj.Value, "dd-MMM-yyyy") & "' AND [Date]<='" & Format(dtpEndDateAdj.Value, "dd-MMM-yyyy") & "' AND Store='" & cStore.Text & "'"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        Dim i As Integer
        Do While drSQL.Read
            DGrid.Rows.Add()
            i = DGrid.Rows.Count - 1
            DGrid.Item(0, i).Value = drSQL.Item("ProductCode")
            DGrid.Item(1, i).Value = drSQL.Item("ProductName")
            DGrid.Item(2, i).Value = drSQL.Item("Qty")
        Loop

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub


End Class