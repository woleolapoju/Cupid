Imports System.Data.SqlClient
Public Class stkFrmBatches
    Public Action As String
    Public frmParent As Object
    Public ProductCode As String = ""
    Public ProductDesc As String = ""
    Public ReturnCode As String
    Public ReturnBatchNo As String = ""
    Dim OnlyOneEntry As Boolean = False
    Public NoListInvolved As Boolean = False

    Private Sub stkFrmBatches_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Stock Batches"
        BackColor = MainTheme
        lvList.BackColor = MainTheme
        tCode.BackColor = MainTheme
        tName.BackColor = MainTheme

        GetUserAccessDetails("Stock Item Batches", False)
        cmdOpen.Enabled = ModuleEdit
        cmdDelete.Enabled = ModuleDelete

        'Flush(Me)

        cmdInsert_Click(sender, e)

        If ProductCode <> "" Then
            tCode.Text = ProductCode
            tName.Text = ProductDesc
            oLoad(ProductCode)

        End If



    End Sub
    Private Sub Flush(ByVal tContainer As Control)
        On Error Resume Next
        tBatchNo.Text = ""
        dtpMadeDate.Text = sysStartDate
        dtpExpiryDate.Text = sysEndDate
        chkDiscontinue.Checked = False
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If tBatchNo.Text = "@Batch" Then
            MsgBox("This batch name is reserved and not allowed", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If Action <> "Delete" Then
            If Not IsValidForm(Me) Or IsFormValid = False Then
                IsFormValid = True
                Exit Sub
            End If
        End If
        IsFormValid = True

        'cnSQL.Open()


        Dim myTrans As SqlClient.SqlTransaction
        Dim j As Integer = 1
        Dim NewSn As Integer = 0
        Select Case Action
            Case Is = "Add"
                

                frmParent.ReturnBatchNo = tBatchNo.Text
                frmParent.ReturnMadeDate = CDate(Format(dtpMadeDate.Value, "dd-MM-yyyy")) 'formatDate(dtpMadeDate)
                frmParent.ReturnExpiryDate = CDate(Format(dtpExpiryDate.Value, "dd-MM-yyyy"))
                frmParent.ReturnDiscontinue = chkDiscontinue.Checked

            

            Case "Edit"
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Parameters.Clear()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "ST_DeleteBatches"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@BatchNo", ReturnBatchNo)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "ST_InsertBatches"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@BatchNo", tBatchNo.Text)
                cmSQL.Parameters.AddWithValue("@DateMade", formatDate(dtpMadeDate))
                cmSQL.Parameters.AddWithValue("@ExpiryDate", formatDate(dtpExpiryDate))
                cmSQL.Parameters.AddWithValue("@Discontinue", chkDiscontinue.Checked)
                cmSQL.ExecuteNonQuery()

                If ReturnBatchNo <> tBatchNo.Text Then
                    cmSQL.CommandText = "UPDATE ST_StockQty SET BatchNo='" & tBatchNo.Text & "' WHERE BatchNo='" & ReturnBatchNo & "'"
                    cmSQL.CommandType = CommandType.Text

                End If

                myTrans.Commit()
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                ' cnSQL.Close()
                'cnSQL.Dispose()

            Case "Delete"
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Parameters.Clear()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "ST_DeleteBatches"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@BatchNo", ReturnBatchNo)
                cmSQL.ExecuteNonQuery()
                myTrans.Commit()

                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                ' cnSQL.Close()
                'cnSQL.Dispose()


        End Select
        'cmSQL.Connection.Close()
        cmSQL.Dispose()

        If Action = "Add" Then
            Me.Close()
            Exit Sub
        End If
        oLoad(ProductCode)

        cmdInsert_Click(sender, e)
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
        Resume
handler:
      
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
      
    End Sub
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
                Case Is = "tBatchNo", "tCode", "tDesc"
                    If txt.Text = "" Then
                        MsgBox(Mid(txt.Name, 2) + " is required", MsgBoxStyle.Information, strApptitle)
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
    Private Sub oLoad(ByVal strProductCode As String)
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchAllBatchPerStockItem"
        cmSQL.Parameters.AddWithValue("@ProductCode", strProductCode)
        cmSQL.CommandType = CommandType.StoredProcedure
        lvList.Items.Clear()
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim j As Long = 0
        Dim i
        Dim initialText As String
        Do While drSQL.Read
            j += 1
            initialText = j
            Dim LvItems As New ListViewItem(initialText)
            'LvItems.SubItems.Add(j)
            For i = 1 To lvList.Columns.Count - 2
                LvItems.SubItems.Add(drSQL.Item("BatchNo"))
                LvItems.SubItems.Add(Format(drSQL.Item("DateMade"), "dd-MMM-yyyy"))
                LvItems.SubItems.Add(Format(drSQL.Item("ExpiryDate"), "dd-MMM-yyyy"))
                LvItems.SubItems.Add(drSQL.Item("Discontinue"))
            Next

            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
        Flush(Me)
        tBatchNo.Focus()
        lblAction.Text = "New Record"
        Action = "Add"
    End Sub
    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        tBatchNo.Text = lvList.SelectedItems(0).SubItems(1).Text
        ReturnBatchNo = tBatchNo.Text
        dtpMadeDate.Text = lvList.SelectedItems(0).SubItems(2).Text
        dtpExpiryDate.Text = lvList.SelectedItems(0).SubItems(3).Text
        chkDiscontinue.Checked = lvList.SelectedItems(0).SubItems(4).Text
        lblAction.Text = "Edit Record"
        Action = "Edit"
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        On Error GoTo handler

        ReturnBatchNo = lvList.SelectedItems(0).SubItems(1).Text

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "SELECT * FROM ST_StockQty WHERE BatchNo='" & ReturnBatchNo & "'"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            MsgBox("Cannot delete Batch...already in use", MsgBoxStyle.Information, strApptitle)
            cmSQL.Dispose()
            drSQL.Close()
            ReturnBatchNo = ""
            Exit Sub
        End If
        cmSQL.Dispose()
        drSQL.Close()
        
        lblAction.Text = "Delete Record"
        Action = "Delete"

        cmdOk_Click(sender, e)

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)

        
    End Sub
End Class