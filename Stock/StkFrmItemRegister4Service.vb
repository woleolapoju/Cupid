Imports System.Data.SqlClient
Imports System.IO
Public Class StkFrmItemRegister4Service
    Public ReturnCode As String
    Public Action1 As String
    Public ReturnBatchNo As String
    Public ReturnMadeDate As Date
    Public ReturnExpiryDate As Date
    Public ReturnDiscontinue As Boolean

    Dim Action As AppAction
    Public StockCode As String
    Private Sub StkFrmItemRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        AppHeader1.lblForm.Text = "Stock Items"
        BackColor = MainTheme
        tID.BackColor = MainTheme
        
        LoadCategory()

        loadStore()

        If cboCategory.Tag <> "" Then cboCategory.Text = cboCategory.Tag
        ReturnMadeDate = CDate("01-Jan-1900")
        ReturnExpiryDate = CDate("01-Jan-2900") ' + Trim(Year(Now) + 100))
        ReturnDiscontinue = False


        If Action1 = "Add" Then
            PanPrevID.Visible = True
            Action = AppAction.Add
            FillGrid("@##EJMDKK$@@$$$&*$(($&&$(($(")
        End If

        If Action1 = "Edit" Then Action = AppAction.Edit
        If Action1 = "Delete" Then Action = AppAction.Delete
        InitialiseAction()

        If ReturnCode <> "" Then
            oLoad(ReturnCode)
            FillGrid(ReturnCode)
            StockCode = ReturnCode
        End If

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
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
                '  If drSQL.Item("TransType") = "Service" Then
                tCode.Text = drSQL.Item("ProductCode")
                tID.Text = drSQL.Item("AutoID")
                tName.Text = drSQL.Item("productName")
                cboCategory.Text = drSQL.Item("Category")
                chkDiscontinue.Checked = drSQL.Item("discontinue")
                tDesc.Text = ChkNull(drSQL.Item("productDesc"))
                tRemark.Text = ChkNull(drSQL.Item("Remark"))

                oLoad = True
                'End If
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
                    If Trim(txt.Text) = "" Then
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
                cmSQL.Parameters.AddWithValue("@Pack", " ")
                cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
                cmSQL.Parameters.AddWithValue("@MaxQty", 0)
                cmSQL.Parameters.AddWithValue("@Rate", 0)
                cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
                cmSQL.Parameters.AddWithValue("@ProductDesc", tDesc.Text)
                cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text)
                cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")
                cmSQL.Parameters.AddWithValue("@TransType", "Service")
                cmSQL.ExecuteNonQuery()

                Got1 = 0
                For i = 0 To DGrid.RowCount - 1
                    If Val(DGrid.Item(2, i).Value) < 0 And Val(DGrid.Item(3, i).Value) < 0 Then GoTo skipIt
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
                        cmSQL.Parameters.AddWithValue("@ExpiryDate", CDate("01-Jan-2900")) 'ReturnExpiryDate
                        cmSQL.Parameters.AddWithValue("@Discontinue", ReturnDiscontinue)
                        cmSQL.Parameters.AddWithValue("@TransType", "Service")
                        cmSQL.ExecuteNonQuery()

                        Got1 = 1
                    End If
skipIt:
                Next
                'If Got1 = 0 Then
                '    MsgBox("Please select at least one (1) Store in the list", MsgBoxStyle.Information, strApptitle)
                '    myTrans.Rollback()
                '    tPrevID.Text = ""
                '    StockCode = ""
                '    Exit Sub
                'Else
                myTrans.Commit()
                tPrevID.Text = tCode.Text
                StockCode = tCode.Text
                'End If

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
                cmSQL.Parameters.AddWithValue("@Pack", " ")
                cmSQL.Parameters.AddWithValue("@ReorderLevel", 0)
                cmSQL.Parameters.AddWithValue("@MaxQty", 0)
                cmSQL.Parameters.AddWithValue("@Rate", 0)
                cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                cmSQL.Parameters.AddWithValue("@AutoID", Val(tID.Text))
                cmSQL.Parameters.AddWithValue("@ProductDesc", tDesc.Text)
                cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text)
                cmSQL.Parameters.AddWithValue("@ShelfLocation", " ")
                cmSQL.Parameters.AddWithValue("@TransType", "Service")
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "DeleteStockItem4StockQty"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@ProductCode", ReturnCode)
                cmSQL.ExecuteNonQuery()

                Got1 = 0
                For i = 0 To DGrid.Rows.Count - 1
                    If Val(DGrid.Item(1, i).Value) < 0 And Val(DGrid.Item(2, i).Value) < 0 Then GoTo skipIt1
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
SkipIt1:
                Next

                'If Got1 = 0 Then
                '    MsgBox("Please select at least one (1) Store in the list", MsgBoxStyle.Information, strApptitle)
                '    myTrans.Rollback()
                '    StockCode = ""
                '    Exit Sub
                'Else
                myTrans.Commit()
                StockCode = tCode.Text
                'End If


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

End Class