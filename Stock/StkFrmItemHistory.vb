Imports System.Data.SqlClient
Imports System.IO
Public Class StkFrmItemHistory
    Public ReturnCode As String
    Public Action1 As String
    Dim Action As AppAction
    Public StockCode As String
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()


    Private Sub StkFrmItemHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        AppHeader1.lblForm.Text = "Stock Items History"
        BackColor = MainTheme
        tID.BackColor = MainTheme
        DGrid.BackgroundColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate

        FillStore()
        If ReturnCode <> "" Then
            oLoad(ReturnCode)
            FillList()
            StockCode = ReturnCode
        End If

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Public Sub FillList()
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim strQry As String = ""
        strQry = "SELECT [Date], Source AS TransType , RefNo, Movement, Qty, 0 AS Balance FROM ItemMovementDetails WHERE ProductCode='" & tCode.Text & "' AND Store='" & cStore.Text & "' ORDER BY [Date], Sn"
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
        DGrid.Columns(0).Width = 60
        DGrid.Columns(3).Width = 160
        DGrid.Columns(4).Width = 60
        DGrid.Columns(5).Width = 60
        'DGrid.Columns(0).DefaultCellStyle = myStyle
        'DGrid.Columns(11).DefaultCellStyle = myStyle
        'DGrid.Columns(12).DefaultCellStyle = myStyle
        Dim i As Integer = 0
        Dim sum As Double = 0
        For i = 0 To DGrid.Rows.Count - 1
            sum = sum + DGrid.Item(4, i).Value
            DGrid.Item(5, i).Value = sum
        Next
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
            cmSQL.CommandText = "SELECT Store FROM AssignedStore WHERE UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT Store FROM Store ORDER BY [Default] DESC"
        End If
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        Dim InitialText As String = ""
        drSQL = cmSQL.ExecuteReader()
        Dim j As Integer = 1
        Do While drSQL.Read
            cStore.Items.Add(drSQL.Item("Store"))
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

                oLoad = True
            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()

        On Error Resume Next
        PictStockItem.Image = Image.FromFile(FindStockItemImageFilename(strValue))

        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
    Private Sub lnkEDoc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEDoc.LinkClicked
        Dim ChildForm As New StkFrmEDoc
        ' ChildForm.RadBill.Checked = True
        ChildForm.tRefNo.Text = StockCode + "D"
        ChildForm.ShowDialog()

    End Sub
    Private Sub lnkImage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImage.LinkClicked
        Dim ChildForm As New StkFrmEDoc
        ' ChildForm.RadBill.Checked = True
        ChildForm.tRefNo.Text = StockCode + "P"
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

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        FillList()
    End Sub
End Class