Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class stkFrmIssue
    Dim ReturnCategory As String = ""
    'Public ReturnGINo As String
    Dim ReturnGroup As String = ""
    Dim chkProduct As Boolean = True
    Dim skipLostFocus As Boolean = False
    Dim DetailAction As String = ""
    Public ReturnGINo, ReturnRequisition As String
    Dim Action As AppAction
    Dim DoNotExist As Boolean = False
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Dim StoredX As Long
    Dim StoredY As Long
    Dim Stored1X As Long
    Dim Stored1Y As Long

    Private Sub stkFrmIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        AppHeader1.lblForm.Text = "Stock Issue" '/Requisition"

        If RefNo <> "" Then
            tblProductListings.Visible = False
            lnkItemList.Text = "Show Item Listings"
            tblMain.ColumnStyles(0).Width = 50
            tblMain.ColumnStyles(2).Width = 50
            Me.Width = tblDetails.Width + 20
            Me.WindowState = FormWindowState.Normal
            PanList.Top = tName.Top + 80
            PanList.Left = tName.Left + 5
        Else
            tblProductListings.Visible = True
            lnkItemList.Text = "Hide Item Listings"
            tblMain.ColumnStyles(0).Width = 100
            tblMain.ColumnStyles(2).Width = 0
            Me.WindowState = FormWindowState.Maximized
            PanList.Top = tName.Top + 80 'tDesc.Height
            PanList.Left = tblDetails.Left + tName.Left + 5
        End If

        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2


        DGrid.DataSource = bindingSource

        DGrid.Tag = 0

        dtpDate.Value = Now

        FillStore()
        'FillGroup()
        'FillCategory()
        FillStaff()
        FillLocation()

        mnuNew.Enabled = ModuleAdd
        mnuEdit.Enabled = ModuleEdit
        mnuBrowse.Enabled = ModuleBrowse
        mnuDelete.Enabled = ModuleDelete
        mnuAuthorise.Enabled = ModuleAuthorise
        chkAuthorise.Visible = ModuleAuthorise

        tPreparedBy.Text = sysUser
        tAuthorisedBy.Text = sysUserName
        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        If RefNo <> "" Then
            Action = AppAction.Authorise
            InitialiseAction()
            mnuAction.Enabled = False

            cmdCancel_Click(sender, e)
            oLoad(RefNo)
            ReturnGINo = RefNo

            'tAuthorisedBy.ReadOnly = Not AC_EditDocOfficer
            'tAuthorisedBy.TabStop = AC_EditDocOfficer
            'tAuthorisedBy.BackColor = IIf(AC_EditDocOfficer, Color.White, Color.LightSteelBlue)

            tAuthorisedBy.Tag = sysUser
            tAuthorisedBy.Text = sysUserName
            chkAuthorise.Enabled = False
            chkAuthorise.Checked = True
            PanEntry.Enabled = False
            'tAuthorisedBy.Focus()

        End If
        RefNo = ""

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        On Error GoTo errhdl
        Action = AppAction.Add
        InitialiseAction()
        cmdInsert_Click(sender, e)
        tName.Focus()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub InitialiseAction()
        PanListCmd.Enabled = False
        tGINNo.Enabled = False
        tAuthorisedBy.ReadOnly = True
        tPreparedBy.ReadOnly = True
        Select Case Action
            Case AppAction.Add
                lblAction.Text = "New Record"
                cmdOk.Visible = True
                PanListCmd.Enabled = True
                tGINNo.Enabled = True
            Case AppAction.Browse
                lblAction.Text = "Browse Record"
                cmdOk.Visible = False
            Case AppAction.Edit
                lblAction.Text = "Edit Record"
                cmdOk.Visible = True
                PanListCmd.Enabled = True
                tGINNo.Enabled = True
            Case AppAction.Delete
                lblAction.Text = "Delete Record"
                cmdOk.Visible = True
            Case AppAction.Authorise
                lblAction.Text = "Authorise Record"
                cmdOk.Visible = True
        End Select
        Flush(Me)
    End Sub
    Private Sub FillLocation()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cLocation.Items.Clear()

        'cmSQL.CommandText = "SELECT Project FROM AC_Projects"
        cmSQL.CommandText = "SELECT Code,Description AS Project FROM Ac_Account WHERE isHeader=1 AND OutlineIndex=1 AND Category='Project' ORDER BY Project"

        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        cLocation.Items.Add("@ - General Use")
        drSQL = cmSQL.ExecuteReader()
        Do While drSQL.Read
            cLocation.Items.Add(drSQL.Item("Code") + " - " + drSQL.Item("Project"))
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        cLocation.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub Flush(ByVal tContainer As Control)
        On Error Resume Next
        Dim ctl As Control
        Dim txt As TextBox
        For Each ctl In tContainer.Controls
            If TypeOf ctl Is TextBox Then
                txt = ctl
                If Not (txt.Name = "tPreparedBy" Or txt.Name = "tAuthorisedBy") Then txt.Text = ""
            End If
            If ctl.HasChildren Then
                Flush(ctl)
            End If
        Next
        tGINNo.Text = "(Auto)"

        tQty.Text = 0
        tGINNo.Tag = 0
        tPreparedBy.Text = sysUser
        cBatchNo.Items.Clear()
        lvList.Items.Clear()
        DoNotExist = False

    End Sub
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
        Dim i As Integer
        Dim j As Integer
FetchNoAgain:
        If Action = AppAction.Add Then FetchNextNo(jk)
        If Action <> AppAction.Delete Then
            If ValidateDate(dtpDate.Text, "Issue") = False Then Exit Sub
            If Not IsValidForm(PanMain) Or IsFormValid = False Then
                IsFormValid = True
                Exit Sub
            End If
            For i = 0 To lvList.Items.Count - 1
                For j = 1 To lvList.Columns.Count - 1
                    If Trim(lvList.Items(i).SubItems(j).Text) = "" And j < 6 Then
                        MsgBox(lvList.Columns(j).Text + " is required", MsgBoxStyle.Information, strApptitle)
                        Exit Sub
                    End If
                Next
            Next i
            If Trim(UCase(tGINNo.Text)) = "(AUTO)" Then
                MsgBox("Invalid Issue No", MsgBoxStyle.Information, strApptitle)
                Exit Sub
            End If

            Dim k As Integer = 0
            For i = 0 To lvList.Items.Count - 1
                If Trim(UCase(lvList.Items(i).SubItems(1).Text)) = "{UNREGISTERED}" Then
                    k = k + 1
                End If
            Next

            If k > 0 Then
                MsgBox("Select a valid stock item to replaced the unregistered requested item(s)", vbInformation, strApptitle)
                Exit Sub
            End If
        End If
        IsFormValid = True
        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction
        Select Case Action
            Case AppAction.Add
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "ST_InsertIssue"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", tGINNo.Text)
                cmSQL.Parameters.AddWithValue("@Date", dtpDate.Text)
                cmSQL.Parameters.AddWithValue("@RequisitionNo", tRequisitionNo.Text)
                cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                cmSQL.Parameters.AddWithValue("@ReceivingStaff", cStaff.Text)
                cmSQL.Parameters.AddWithValue("@IssueLocation", cLocation.Text)
                cmSQL.Parameters.AddWithValue("@IssueDepartment", "")
                cmSQL.Parameters.AddWithValue("@PreparedBy", sysUser)
                cmSQL.Parameters.AddWithValue("@AutoID", Val(tGINNo.Tag))
                cmSQL.ExecuteNonQuery()

                For i = 0 To lvList.Items.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "ST_InsertIssueDetails"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@GINo", tGINNo.Text)
                    cmSQL.Parameters.AddWithValue("@ProductCode", lvList.Items(i).SubItems(1).Text)
                    cmSQL.Parameters.AddWithValue("@ProductName", lvList.Items(i).SubItems(2).Text)
                    cmSQL.Parameters.AddWithValue("@Category", lvList.Items(i).SubItems(5).Text)
                    cmSQL.Parameters.AddWithValue("@Qty", CDbl(lvList.Items(i).SubItems(3).Text))
                    cmSQL.Parameters.AddWithValue("@BatchNo", Trim(ChkNull(lvList.Items(i).SubItems(4).Text)))
                    cmSQL.Parameters.AddWithValue("@RequisitionNo", lvList.Items(i).SubItems(6).Text)
                    cmSQL.Parameters.AddWithValue("@Cost", CDbl(Val(lvList.Items(i).SubItems(7).Text)))
                    cmSQL.Parameters.AddWithValue("@Pack", lvList.Items(i).SubItems(8).Text)
                    cmSQL.Parameters.AddWithValue("@ReqSn", Val(lvList.Items(i).SubItems(10).Text))
                    cmSQL.ExecuteNonQuery()
                Next i

                If chkAuthorise.Checked = True Then
                    tAuthorisedBy.Text = sysUserName
                    If Trim(tAuthorisedBy.Text) = "" Then
                        MsgBox("Pls. Authorising Officer by must be entered", MsgBoxStyle.Information, strApptitle)
                        myTrans.Rollback()
                        Exit Sub
                    End If
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "UPDATE ST_Issue SET Authorised=1,AuthorisedBy='" & tAuthorisedBy.Text & "' WHERE GINo='" & tGINNo.Text & "'"
                    cmSQL.CommandType = CommandType.Text
                    cmSQL.ExecuteNonQuery()

                    For i = 0 To lvList.Items.Count - 1
                        cmSQL.Parameters.Clear()
                        cmSQL.CommandText = "ST_UpdateStockQty4Issue"
                        cmSQL.CommandType = CommandType.StoredProcedure
                        cmSQL.Parameters.AddWithValue("@ProductCode", lvList.Items(i).SubItems(1).Text)
                        cmSQL.Parameters.AddWithValue("@BatchNo", lvList.Items(i).SubItems(4).Text)
                        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                        cmSQL.Parameters.AddWithValue("@Qty", CDbl(lvList.Items(i).SubItems(3).Text))
                        cmSQL.ExecuteNonQuery()

                        If Trim(lvList.Items(i).SubItems(6).Text) <> "" Then
                            cmSQL.CommandText = "UPDATE ST_RequisitionDetails SET QtyIssued=QtyIssued+" & CDbl(lvList.Items(i).SubItems(3).Text) & " WHERE ReqNo='" & lvList.Items(i).SubItems(6).Text & "' AND Sn=" & Val(lvList.Items(i).SubItems(10).Text)
                            cmSQL.CommandType = CommandType.Text
                            cmSQL.ExecuteNonQuery()
                        End If


                    Next i
                End If

                myTrans.Commit()
                ReturnGINo = tGINNo.Text

            Case AppAction.Edit
                If ReturnGINo = "" Then
                    MsgBox("Pls. select a Issue Note to edit", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If

                myTrans = cnSQL.BeginTransaction()

                cmSQL.Parameters.Clear()
                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "ST_DeleteIssue"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", ReturnGINo)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "ST_DeleteIssueDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", ReturnGINo)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "ST_InsertIssue"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", tGINNo.Text)
                cmSQL.Parameters.AddWithValue("@Date", dtpDate.Text)
                cmSQL.Parameters.AddWithValue("@RequisitionNo", tRequisitionNo.Text)
                cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                cmSQL.Parameters.AddWithValue("@ReceivingStaff", cStaff.Text)
                cmSQL.Parameters.AddWithValue("@IssueLocation", cLocation.Text)
                cmSQL.Parameters.AddWithValue("@IssueDepartment", "")
                cmSQL.Parameters.AddWithValue("@PreparedBy", sysUser)
                cmSQL.Parameters.AddWithValue("@AutoID", Val(tGINNo.Tag))
                cmSQL.ExecuteNonQuery()

                For i = 0 To lvList.Items.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "ST_InsertIssueDetails"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@GINo", tGINNo.Text)
                    cmSQL.Parameters.AddWithValue("@ProductCode", lvList.Items(i).SubItems(1).Text)
                    cmSQL.Parameters.AddWithValue("@ProductName", lvList.Items(i).SubItems(2).Text)
                    cmSQL.Parameters.AddWithValue("@Category", lvList.Items(i).SubItems(5).Text)
                    cmSQL.Parameters.AddWithValue("@Qty", CDbl(lvList.Items(i).SubItems(3).Text))
                    cmSQL.Parameters.AddWithValue("@BatchNo", lvList.Items(i).SubItems(4).Text)
                    cmSQL.Parameters.AddWithValue("@RequisitionNo", lvList.Items(i).SubItems(6).Text)
                    cmSQL.Parameters.AddWithValue("@Cost", CDbl(Val(lvList.Items(i).SubItems(7).Text)))
                    cmSQL.Parameters.AddWithValue("@Pack", lvList.Items(i).SubItems(8).Text)
                    cmSQL.Parameters.AddWithValue("@ReqSn", Val(lvList.Items(i).SubItems(10).Text))
                    cmSQL.ExecuteNonQuery()
                Next i

                If chkAuthorise.Checked = True Then
                    tAuthorisedBy.Text = sysUserName
                    If Trim(tAuthorisedBy.Text) = "" Then
                        MsgBox("Pls. Authorising Officer by must be entered", MsgBoxStyle.Information, strApptitle)
                        myTrans.Rollback()
                        Exit Sub
                    End If
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "UPDATE ST_Issue SET Authorised=1,AuthorisedBy='" & tAuthorisedBy.Text & "' WHERE GINo='" & tGINNo.Text & "'"
                    cmSQL.CommandType = CommandType.Text
                    cmSQL.ExecuteNonQuery()

                    For i = 0 To lvList.Items.Count - 1
                        cmSQL.Parameters.Clear()
                        cmSQL.CommandText = "ST_UpdateStockQty4Issue"
                        cmSQL.CommandType = CommandType.StoredProcedure
                        cmSQL.Parameters.AddWithValue("@ProductCode", lvList.Items(i).SubItems(1).Text)
                        cmSQL.Parameters.AddWithValue("@BatchNo", lvList.Items(i).SubItems(4).Text)
                        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                        cmSQL.Parameters.AddWithValue("@Qty", CDbl(lvList.Items(i).SubItems(3).Text))
                        cmSQL.ExecuteNonQuery()

                        If Trim(lvList.Items(i).SubItems(6).Text) <> "" Then
                            ' cmSQL.CommandText = "UPDATE ST_RequisitionDetails SET QtyIssued=QtyIssued+" & CDbl(lvList.Items(i).SubItems(3).Text) & " WHERE ReqNo='" & lvList.Items(i).SubItems(6).Text & "' AND ProductCode='" & lvList.Items(i).SubItems(1).Text & "'"
                            cmSQL.CommandText = "UPDATE ST_RequisitionDetails SET QtyIssued=QtyIssued+" & CDbl(lvList.Items(i).SubItems(3).Text) & " WHERE ReqNo='" & lvList.Items(i).SubItems(6).Text & "' AND Sn=" & Val(lvList.Items(i).SubItems(10).Text)
                            cmSQL.CommandType = CommandType.Text
                            cmSQL.ExecuteNonQuery()
                        End If

                    Next i
                End If

                myTrans.Commit()
                ReturnGINo = tGINNo.Text
            Case AppAction.Delete
                If ReturnGINo = "" Then
                    MsgBox("Pls. select a Issue Note to delete", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

                myTrans = cnSQL.BeginTransaction()

                cmSQL.Transaction = myTrans

                cmSQL.CommandText = "ST_DeleteIssue"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", ReturnGINo)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "ST_DeleteIssueDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@GINo", ReturnGINo)
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()
                ReturnGINo = ""
            Case AppAction.Authorise
                tAuthorisedBy.Text = sysUserName
                If Trim(tAuthorisedBy.Text) = "" Then
                    MsgBox("Pls. Authorising Officer by must be entered", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If ReturnGINo = "" Then
                    MsgBox("Pls. select a Issue Note to authorise", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If MsgBox("The Selected Issue Note Would be Posted Permanently" & Chr(13) & " Continue (y/n)", vbYesNo + vbCritical, "Issue Authorisation") = vbNo Then Exit Sub

                myTrans = cnSQL.BeginTransaction()

                cmSQL.Transaction = myTrans

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "UPDATE ST_Issue SET Authorised=1,AuthorisedBy='" & tAuthorisedBy.Text & "' WHERE GINo='" & ReturnGINo & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                For i = 0 To lvList.Items.Count - 1
                    cmSQL.Parameters.Clear()
                    cmSQL.CommandText = "ST_UpdateStockQty4Issue"
                    cmSQL.CommandType = CommandType.StoredProcedure
                    cmSQL.Parameters.AddWithValue("@ProductCode", lvList.Items(i).SubItems(1).Text)
                    cmSQL.Parameters.AddWithValue("@BatchNo", lvList.Items(i).SubItems(4).Text)
                    cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
                    cmSQL.Parameters.AddWithValue("@Qty", CDbl(lvList.Items(i).SubItems(3).Text))
                    cmSQL.ExecuteNonQuery()

                    If Trim(lvList.Items(i).SubItems(6).Text) <> "" Then
                        'cmSQL.CommandText = "UPDATE ST_RequisitionDetails SET QtyIssued=QtyIssued+" & CDbl(lvList.Items(i).SubItems(3).Text) & " WHERE ReqNo='" & lvList.Items(i).SubItems(6).Text & "' AND ProductCode='" & lvList.Items(i).SubItems(1).Text & "'"
                        cmSQL.CommandText = "UPDATE ST_RequisitionDetails SET QtyIssued=QtyIssued+" & CDbl(lvList.Items(i).SubItems(3).Text) & " WHERE ReqNo='" & lvList.Items(i).SubItems(6).Text & "' AND Sn=" & Val(lvList.Items(i).SubItems(10).Text)
                        cmSQL.CommandType = CommandType.Text
                        cmSQL.ExecuteNonQuery()
                    End If
                Next i

                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertMailServer"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Attachment1", "")
                cmSQL.Parameters.AddWithValue("@Attachment2", "")
                cmSQL.Parameters.AddWithValue("@Attachment3", "")
                cmSQL.Parameters.AddWithValue("@Attachment4", "")
                cmSQL.Parameters.AddWithValue("@Attachment5", "")
                cmSQL.Parameters.AddWithValue("@To", Trim(tPreparedBy.Text))
                cmSQL.Parameters.AddWithValue("@From", sysUserName)
                cmSQL.Parameters.AddWithValue("@Title", "APPROVAL " + ReturnGINo)
                cmSQL.Parameters.AddWithValue("@Body", "ATTN: Stock Issue No " + ReturnGINo + Chr(13) + Chr(10) + Chr(13) + Chr(10) + " has been approved")
                cmSQL.Parameters.AddWithValue("@Date", Format(Now, "dd-MMM-yyyy"))
                cmSQL.Parameters.AddWithValue("@Departmental", 0)
                cmSQL.Parameters.AddWithValue("@Saved", False)
                cmSQL.ExecuteNonQuery()
                myTrans.Commit()
                Me.Close()

        End Select
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Flush(Me)
        ' ReturnGINo = ""
        If mnuNew.Enabled Then mnuNew_Click(sender, e)

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
            On Error Resume Next
            myTrans.Rollback()
        End If
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
                Case Is = "tOrderNo", "tPreparedBy", "cLocation", "cDepartment"
                    If txt.Text = "" Then
                        MsgBox(Mid(txt.Name, 2) + " is required", MsgBoxStyle.Information, strApptitle)
                        IsValidForm = False
                        IsFormValid = False
                        Exit For
                        Exit Function
                    End If
            End Select
        Next
        If lvList.Items.Count < 1 Then
            MsgBox("Incomplete data, stock item list empty", MsgBoxStyle.Information, strApptitle)
            IsValidForm = False
            IsFormValid = False
        End If
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Function
    Private Sub lvList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvList.ColumnClick
        lvList.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
        ' PanListCmd.Visible = False
        DetailAction = "Add"
        tItemCode.Text = ""
        tCategory.Text = ""
        tName.Text = ""
        tQty.Text = 0
        tPack.Text = ""
        'If cmdOk.Visible = True Then cmdOk.Enabled = False
        tItemCode.Focus()
    End Sub

    Private Function FetchNextNo(ByVal j As Integer) As Boolean
        On Error GoTo errhdl
        FetchNextNo = True
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        If UCase(Trim(tGINNo.Text)) <> "(AUTO)" Then Exit Function
        cmSQL.CommandText = "ST_FetchNewIssueID"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then
            If drSQL.Read Then
                tGINNo.Text = "GIN_" & IIf(Len(strPeriod) > 2, Microsoft.VisualBasic.Right(strPeriod, 2), strPeriod) & "_" & StrDup(4 - Len(CStr(CLng(drSQL.Item("NewID") + j))), "0") & CStr(CLng(drSQL.Item("NewID") + j))
                tGINNo.Tag = drSQL.Item("NewID") + j
            End If

        Else
            tGINNo.Text = "GIN_" & IIf(Len(strPeriod) > 2, Microsoft.VisualBasic.Right(strPeriod, 2), strPeriod) & "_" & "0001"
            tGINNo.Tag = 1
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
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub FillStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim StaffName As String
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
    Private Sub tDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tName.TextChanged
        If chkProduct = False Then Exit Sub
        If tName.Text <> "" Then
            getProductList(tName.Text)
            PanList.Visible = True
        Else
            PanList.Visible = False
        End If
    End Sub
    Private Sub FetchBatchNo(ByVal strProduct As String)
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim StaffName As String
        cBatchNo.Items.Clear()

        cmSQL.CommandText = "FetchActiveBatchPerStockItemWithStock"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", strProduct)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        'cnSQL.Open()
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
    Private Sub FillStaff()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        Dim StaffName As String
        cStaff.Items.Clear()

        cmSQL.CommandText = "FetchAllActiveStaff"
        cmSQL.CommandType = CommandType.StoredProcedure
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        cStaff.Items.Add("")
        Do While drSQL.Read
            StaffName = drSQL.Item("StaffNo").ToString + " - " + drSQL.Item("Surname").ToString + " " + drSQL.Item("Othername").ToString
            cStaff.Items.Add(StaffName)
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        cStaff.SelectedIndex = 0

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub tName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tName.KeyDown
        If (e.KeyCode = 38 Or e.KeyCode = 40) And DGrid.RowCount > 0 Then
            skipLostFocus = True
            DGrid.Focus()
            DGrid.Item(0, 0).Selected = True
            skipLostFocus = False
        Else
            skipLostFocus = False
        End If
        If e.KeyCode = 13 Then
            tCategory.Focus()
            PanList.Visible = False
        End If
    End Sub
    Private Sub tName_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tName.MouseEnter
        skipLostFocus = False
    End Sub
    Private Sub tName_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tName.MouseLeave
        skipLostFocus = True
    End Sub
    Private Sub tName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tName.LostFocus
        If skipLostFocus = True Then Exit Sub

        If GetProductByName(tName.Text) = False Then
            ' tCategory.Focus()
            tItemCode.Text = ""

            PanList.Visible = False
        Else
            PanList.Visible = False
        End If
    End Sub
    Private Sub cmdClosePanList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanList.Click
        PanList.Visible = False
    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        ' GetProductByCode(DGrid.Item(0, DGrid.Tag).Value)
        On Error Resume Next
        tItemCode.Text = DGrid.Item(0, DGrid.Tag).Value
        tName.Text = DGrid.Item(1, DGrid.Tag).Value
        tCategory.Text = DGrid.Item(2, DGrid.Tag).Value
        tPack.Text = DGrid.Item(3, DGrid.Tag).Value
        tItemDesc.Text = DGrid.Item(4, DGrid.Tag).Value
        PanList.Visible = False
        DoNotExist = False
        FetchBatchNo(tItemCode.Text)
    End Sub
    Private Sub DGrid_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.RowEnter
        DGrid.Tag = e.RowIndex
    End Sub
    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then
            GetProductByCode(DGrid.Item(0, DGrid.Tag).Value)
            PanList.Visible = False
        End If
    End Sub
    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        On Error Resume Next
        If e.KeyCode = 13 Then
            tItemCode.Text = DGrid.Item(0, DGrid.Tag).Value
            tName.Text = DGrid.Item(1, DGrid.Tag).Value
            tCategory.Text = DGrid.Item(2, DGrid.Tag).Value
            tPack.Text = DGrid.Item(3, DGrid.Tag).Value
            tQty.Select()
            PanList.Visible = False
        ElseIf e.KeyCode = 8 Then
            tName.Focus()
        End If
    End Sub
    Sub getProductList(ByVal strQry As String)
        On Error GoTo handler
        If strQry = "" Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        'cnSQL.Open()
        If radContaining.Checked Then cmSQL.CommandText = "SELECT ST_StockQty.ProductCode, ST_StoreItems.ProductName, ST_StoreItems.Category,ST_StoreItems.Pack, ST_StoreItems.ProductDesc, ST_StockQty.BatchNo, ST_StockQty.Qty FROM ST_StoreItems RIGHT OUTER JOIN ST_StockQty ON ST_StoreItems.ProductCode = ST_StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND (ST_StockQty.Qty > 0) AND (ST_StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%' ORDER BY ProductName"
        If RadStartWith.Checked Then cmSQL.CommandText = "SELECT ST_StockQty.ProductCode, ST_StoreItems.ProductName, ST_StoreItems.Category,ST_StoreItems.Pack, ST_StoreItems.ProductDesc, ST_StockQty.BatchNo, ST_StockQty.Qty FROM ST_StoreItems RIGHT OUTER JOIN ST_StockQty ON ST_StoreItems.ProductCode = ST_StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND (ST_StockQty.Qty > 0) AND (ST_StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%' ORDER BY ProductName"
        If RadEndWith.Checked Then cmSQL.CommandText = "SELECT ST_StockQty.ProductCode, ST_StoreItems.ProductName, ST_StoreItems.Category,ST_StoreItems.Pack, ST_StoreItems.ProductDesc, ST_StockQty.BatchNo, ST_StockQty.Qty FROM ST_StoreItems RIGHT OUTER JOIN ST_StockQty ON ST_StoreItems.ProductCode = ST_StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND (ST_StockQty.Qty > 0) AND (ST_StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "' ORDER BY ProductName"
        If RadEqual.Checked Then cmSQL.CommandText = "SELECT ST_StockQty.ProductCode, ST_StoreItems.ProductName, ST_StoreItems.Category,ST_StoreItems.Pack, ST_StoreItems.ProductDesc, ST_StockQty.BatchNo, ST_StockQty.Qty FROM ST_StoreItems RIGHT OUTER JOIN ST_StockQty ON ST_StoreItems.ProductCode = ST_StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND (ST_StockQty.Qty > 0) AND (ST_StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName  = '" + strQry & "' ORDER BY ProductName"


        cmSQL.CommandType = CommandType.Text

        dataAdapter = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        cmSQL.Dispose()

        ' cnSQL.Close()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Function GetProductByName(ByVal strValue As String) As Boolean
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        GetProductByName = True
        If strValue = "" Then Exit Function
        'cnSQL.Open()
        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "ST_FetchStoreItemsByName"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductName", strValue)

        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            ' MsgBox("Client do not exist", MsgBoxStyle.Information, strApptitle)
            'tDesc.Text = ""
            'cboDesc.Text = ""
            'tCategory.Text = ""
            'tPack.Text = ""
            tItemDesc.Text = ""
            tDesc.Text = ""
            tRemark.Text = ""
            DoNotExist = True
            GetProductByName = False
            GoTo skipit
        End If
        If drSQL.Read Then
            tItemCode.Text = drSQL.Item("ProductCode")
            tName.Text = drSQL.Item("ProductName")
            tCategory.Text = drSQL.Item("Category")
            tPack.Text = drSQL.Item("Pack")
            tDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
            tRemark.Text = ChkNull(drSQL.Item("Remark"))
            tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
            DoNotExist = False
        End If
SkipIt:
        cmSQL.Dispose()
        drSQL.Close()
        drSQL.Close()

        If DoNotExist = False Then FetchBatchNo(tItemCode.Text)
        chkProduct = True

        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function


    Private Sub tItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tItemCode.LostFocus
        chkProduct = False
        If GetProductByCode(tItemCode.Text) = False Then tQty.Focus()
        chkProduct = True
    End Sub
    Private Function GetProductByCode(ByVal strValue As String) As Boolean
        On Error GoTo handler
        chkProduct = False
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        GetProductByCode = True
        If strValue = "" Then Exit Function
        'cnSQL.Open()
        cmSQL.Parameters.Clear()
        cmSQL.CommandText = "ST_FetchStoreItems"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", strValue)

        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            ' MsgBox("Client do not exist", MsgBoxStyle.Information, strApptitle)
            tName.Text = ""
            tItemDesc.Text = ""
            tCategory.Text = ""
            tPack.Text = ""
            tDesc.Text = ""
            tItemDesc.Text = ""
            tRemark.Text = ""
            DoNotExist = True
            GetProductByCode = False
            GoTo skipit
        End If
        If drSQL.Read Then
            tItemCode.Text = drSQL.Item("ProductCode")
            tName.Text = drSQL.Item("ProductName")
            tCategory.Text = drSQL.Item("Category")
            tPack.Text = drSQL.Item("Pack")
            tDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
            tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
            tRemark.Text = ChkNull(drSQL.Item("Remark"))
            DoNotExist = False
        End If

        On Error GoTo SkipIt
        PanStockImage.Visible = False
        PanStockImage.BackgroundImage = Nothing
        PanStockImage.BackgroundImage = Image.FromFile(StkFrmItemRegister.FindStockItemImageFilename(tItemCode.Text.ToString))
        If PanStockImage.BackgroundImage Is Nothing Then Exit Function
        PanStockImage.Visible = True

SkipIt:
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        If DoNotExist = False Then FetchBatchNo(tItemCode.Text)
        chkProduct = True
        Exit Function
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Function

    Private Sub cmdInsertDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertDetails.Click
        On Error GoTo errhdl
        chkProduct = False
        If DoNotExist = True Then tItemCode.Text = "" ' "(AUTO)"

        If tItemCode.Text = "" Or tName.Text = "" Or tCategory.Text = "" Or CDbl(IIf(tQty.Text = "", 0, tQty.Text)) = 0 Then
            MsgBox("Incomplete Data", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        Dim k As Integer
        Select Case DetailAction

            Case Is = "Add"
                k = ChkExisting(tItemCode.Text, cBatchNo.Text)
                If k <> -1 Then
                    lvList.Items(k).SubItems(3).Text = CDbl(lvList.Items(k).SubItems(3).Text) + CDbl(tQty.Text)
                Else
                    Dim listItem As New ListViewItem(lvList.Items.Count + 1)
                    listItem.SubItems.Add(tItemCode.Text)
                    listItem.SubItems.Add(tName.Text)
                    listItem.SubItems.Add(CDbl(tQty.Text))
                    listItem.SubItems.Add(cBatchNo.Text)
                    listItem.SubItems.Add(tCategory.Text)
                    listItem.SubItems.Add("")
                    listItem.SubItems.Add(tQty.Tag)
                    listItem.SubItems.Add(tPack.Text)
                    listItem.SubItems.Add(tItemDesc.Text)
                    listItem.SubItems.Add(0)
                    ' listItem.SubItems.Add(tItemCode.Text)
                    lvList.Items.Add(listItem)

                    Dim i As Integer
                    For i = 0 To lvList.Items.Count - 1
                        lvList.Items(i).Text = i + 1
                        If i Mod 2 <> 0 Then lvList.Items(i).BackColor = Color.LavenderBlush
                    Next
                End If
                
            Case Is = "Edit"
                k = Val(tItemCode.Tag) - 1
                lvList.Items(k).SubItems(1).Text = tItemCode.Text
                lvList.Items(k).SubItems(2).Text = tName.Text
                lvList.Items(k).SubItems(3).Text = CDbl(tQty.Text)
                lvList.Items(k).SubItems(4).Text = cBatchNo.Text
                lvList.Items(k).SubItems(5).Text = tCategory.Text
                '        lvList.Items(k).SubItems(6).Text = tCategory.Tag 'ReqNo
                lvList.Items(k).SubItems(7).Text = tQty.Tag 'Val(tQty.Tag) 'Cost
                lvList.Items(k).SubItems(8).Text = tPack.Text
                lvList.Items(k).SubItems(9).Text = tItemDesc.Text
                'lvList.Items(k).SubItems(10).Text = tItemCode.Text

        End Select

        'If DetailAction <> "Add" Then
        cmdCancel_Click(sender, e)



        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        tItemCode.Text = ""
        tCategory.Text = ""
        tPack.Text = ""
        tName.Text = ""
        tQty.Text = 0
        tItemDesc.Text = ""
        tName.Focus()
        cmdOk.Enabled = True
        chkProduct = True
        cBatchNo.Items.Clear()
        DetailAction = "Add"
        'PanListCmd.Visible = True
        ''  PanDetails.Visible = False
        'If cmdOk.Visible = True Then cmdOk.Enabled = True
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        On Error Resume Next
        DetailAction = "Edit"
        chkProduct = False
        'PanListCmd.Visible = False
        tItemCode.Tag = lvList.SelectedItems(0).Text
        tItemCode.Text = lvList.SelectedItems(0).SubItems(1).Text
        tName.Text = lvList.SelectedItems(0).SubItems(2).Text
        tQty.Text = 0
        tCategory.Text = lvList.SelectedItems(0).SubItems(5).Text
        tCategory.Tag = lvList.SelectedItems(0).SubItems(6).Text

        tPack.Text = lvList.SelectedItems(0).SubItems(8).Text
        tItemDesc.Text = lvList.SelectedItems(0).SubItems(9).Text

        FetchBatchNo(lvList.SelectedItems(0).SubItems(1).Text)

        tQty.Text = lvList.SelectedItems(0).SubItems(3).Text

        'If cmdOk.Visible = True Then cmdOk.Enabled = False
        tQty.Focus()
        chkProduct = True
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        On Error Resume Next
        If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

        Dim k As Integer
        lvList.Items(lvList.SelectedItems(0).Index).Remove()
        For k = 0 To lvList.Items.Count - 1
            lvList.Items(k).Text = k + 1
        Next

    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        Action = AppAction.Edit
        InitialiseAction()
        cmdCancel_Click(sender, e)
        On Error GoTo errhdl
        Dim strValue As String = InputBox("Enter Issue No", "Stock Issue", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            If oLoad(strValue) = False Then
                MsgBox("IssueNo do not exist", MsgBoxStyle.Information, strApptitle)
            Else
                ReturnGINo = strValue
            End If
            Exit Sub
        End If
        'Dim strCaption(4) As String
        'Dim intWidth(4) As Integer
        'strCaption(0) = "Issue No"
        'intWidth(0) = 100
        'strCaption(1) = "Date"
        'intWidth(1) = 100
        'strCaption(2) = "Store"
        'intWidth(2) = 150
        'strCaption(3) = "Req. No"
        'intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Unauthorised Issue"
            .listQuery = "Unauthorised Issue"
            .Text = "List of Unauthorised Issue"
            .ShowDialog()
        End With
        oLoad(ReturnGINo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        Action = AppAction.Browse
        InitialiseAction()
        cmdCancel_Click(sender, e)
        On Error GoTo errhdl
        Dim strValue As String = InputBox("Enter Issue No", "Stock Issue", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            If oLoad(strValue) = False Then
                MsgBox("IssueNo do not exist", MsgBoxStyle.Information, strApptitle)
            Else
                ReturnGINo = strValue
            End If
            Exit Sub
        End If
        'Dim strCaption(4) As String
        'Dim intWidth(4) As Integer
        'strCaption(0) = "Issue No"
        'intWidth(0) = 100
        'strCaption(1) = "Date"
        'intWidth(1) = 100
        'strCaption(2) = "Store"
        'intWidth(2) = 150
        'strCaption(3) = "Req. No"
        'intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "All Issue"
            .listQuery = "All Issue"
            .Text = "List of All Issue"
            .ShowDialog()
        End With
        oLoad(ReturnGINo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Action = AppAction.Delete
        InitialiseAction()
        cmdCancel_Click(sender, e)
        On Error GoTo errhdl
        Dim strValue As String = InputBox("Enter Issue No", "Stock Issue", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            If oLoad(strValue) = False Then
                MsgBox("IssueNo do not exist", MsgBoxStyle.Information, strApptitle)
            Else
                ReturnGINo = strValue
            End If
            Exit Sub
        End If
        'Dim strCaption(4) As String
        'Dim intWidth(4) As Integer
        'strCaption(0) = "Issue No"
        'intWidth(0) = 100
        'strCaption(1) = "Date"
        'intWidth(1) = 100
        'strCaption(2) = "Store"
        'intWidth(2) = 150
        'strCaption(3) = "Req. No"
        'intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Unauthorised Issue"
            .listQuery = "Unauthorised Issue"
            .Text = "List of Unauthorised Issue"
            .ShowDialog()
        End With
        oLoad(ReturnGINo)
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub mnuAuthorise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAuthorise.Click
        Action = AppAction.Authorise
        InitialiseAction()
        cmdCancel_Click(sender, e)
        On Error GoTo errhdl
        Dim strValue As String = InputBox("Enter Issue No", "Stock Issue", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            If oLoad(strValue) = False Then
                MsgBox("IssueNo do not exist", MsgBoxStyle.Information, strApptitle)
            Else
                ReturnGINo = strValue
            End If
            Exit Sub
        End If
        'Dim strCaption(4) As String
        'Dim intWidth(4) As Integer
        'strCaption(0) = "Issue No"
        'intWidth(0) = 100
        'strCaption(1) = "Date"
        'intWidth(1) = 100
        'strCaption(2) = "Store"
        'intWidth(2) = 150
        'strCaption(3) = "Req. No"
        'intWidth(3) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Unauthorised Issue"
            .listQuery = "Unauthorised Issue"
            .Text = "List of Unauthorised Issue"
            .ShowDialog()
        End With
        oLoad(ReturnGINo)
        If Trim(tAuthorisedBy.Text) = "" Then tAuthorisedBy.Text = sysUserName
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Function oLoad(ByVal strValue As String) As Boolean
        On Error GoTo handler
        oLoad = False
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        If strValue = "" Then Exit Function

        Flush(Me)


        If Action = AppAction.Browse Then
            cmSQL.CommandText = "ST_FetchIssue"
        Else
            cmSQL.CommandText = "ST_FetchUnAuthorisedIssue"
        End If

        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@GINo", strValue)

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then GoTo skipIt
        oLoad = True
        If drSQL.Read = False Then GoTo skipIt
        tGINNo.Text = drSQL.Item("GINo")
        dtpDate.Text = drSQL.Item("Date")
        tRequisitionNo.Text = drSQL.Item("RequisitionNo")
        cStore.Text = drSQL.Item("Store")
        cStaff.Text = drSQL.Item("Receivingstaff")
        cLocation.Text = ChkNull(drSQL.Item("IssueLocation"))
        ' cDepartment.Text = ChkNull(drSQL.Item("IssueDepartment"))
        tPreparedBy.Text = drSQL.Item("Preparedby")
        tAuthorisedBy.Text = ChkNull(drSQL.Item("Authorisedby"))
        tGINNo.Tag = drSQL.Item("AutoID")

        drSQL.Close()
        drSQL = cmSQL.ExecuteReader()

        Do While drSQL.Read = True
            Dim LvItems As New ListViewItem(lvList.Items.Count + 1)
            LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            LvItems.SubItems.Add(drSQL.Item("BatchNo"))
            LvItems.SubItems.Add(drSQL.Item("Category"))
            LvItems.SubItems.Add(drSQL.Item("RequisitionNoFromDetails"))
            LvItems.SubItems.Add(Format(drSQL.Item("Cost"), Gen))
            LvItems.SubItems.Add(drSQL.Item("Pack"))
            LvItems.SubItems.Add("")
            LvItems.SubItems.Add(drSQL.Item("ReqSn"))
            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop

        'cmSQL.Connection.Close()
skipIt:
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Dim i As Integer
        For i = 0 To lvList.Items.Count - 1
            lvList.Items(i).Text = i + 1
            If i Mod 2 <> 0 Then lvList.Items(i).BackColor = Color.LavenderBlush
        Next
        Exit Function
        Resume
handler:
        MsgBox(Err.Description + Chr(13) + Err.Source, vbInformation, strApptitle)
    End Function
    Private Sub radContaining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radContaining.CheckedChanged
        On Error Resume Next
        getProductList(tName.Text)
    End Sub
    Private Sub RadStartWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadStartWith.CheckedChanged
        On Error Resume Next
        getProductList(tName.Text)
    End Sub
    Private Sub RadEndWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEndWith.CheckedChanged
        On Error Resume Next
        getProductList(tName.Text)
    End Sub
    Private Sub RadEqual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEqual.CheckedChanged
        On Error Resume Next
        getProductList(tName.Text)
    End Sub

    Private Sub FillCategory()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        lvListCat.Items.Clear()
        'cmSQL.CommandText = "ST_FetchAllCategory"
        cmSQL.CommandText = "SELECT DISTINCT ST_StoreItems.Category AS [Description] FROM ST_StockQty LEFT OUTER JOIN ST_StoreItems ON ST_StockQty.ProductCode = ST_StoreItems.ProductCode WHERE ST_StockQty.Qty > 0 AND ST_StockQty.Store = '" & cStore.Text & "'"
        cmSQL.CommandType = CommandType.Text
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        lvListCat.Items.Add("<All>")
        Do While drSQL.Read
            lvListCat.Items.Add(drSQL.Item("Description").ToString)
        Loop
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        'lvListCat.SelectedItems(0).EnsureVisible()

        Exit Sub
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub FillStockItem(ByVal sendCategory As String, ByVal sendStore As String, Optional ByVal tFrom As Integer = 0)
        If sendCategory = "" Or sendStore = "" Then Exit Sub
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        tDesc.Text = ""
        tRemark.Text = ""
        lvListProduct.Items.Clear()
        If tFrom = 1 Then ' from group
            cmSQL.CommandText = "ST_FetchAllActiveAvailableStoreItemsPerGroupPerStore"
            cmSQL.Parameters.AddWithValue("@Group", IIf(sendCategory = "<All>", "*", sendCategory))
        Else
            cmSQL.CommandText = "ST_FetchAllActiveAvailableStoreItemsPerCategoryPerStore"
            cmSQL.Parameters.AddWithValue("@Category", IIf(sendCategory = "<All>", "*", sendCategory))
        End If

        cmSQL.CommandType = CommandType.StoredProcedure

        cmSQL.Parameters.AddWithValue("@Store", sendStore)
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        Dim initialText As String = ""
        Do While drSQL.Read
            initialText = drSQL.Item("ProductCode").ToString
            Dim LvItems As New ListViewItem(initialText)
            LvItems.SubItems.Add(drSQL.Item("ProductName").ToString)
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            lvListProduct.Items.AddRange(New ListViewItem() {LvItems})
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

    Private Sub lvListCat_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvListCat.ColumnClick
        lvListCat.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub
    Private Sub lvListCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListCat.SelectedIndexChanged
        On Error Resume Next
        ReturnCategory = lvListCat.SelectedItems(0).Text
        FillStockItem(lvListCat.SelectedItems(0).Text, cStore.Text)
    End Sub

    Private Sub lvListGrp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvListGrp.DoubleClick
        On Error Resume Next
        For i = 0 To lvListProduct.Items.Count - 1
            tItemCode.Text = lvListProduct.Items(i).Text
            tItemCode_LostFocus(sender, e)
            tQty.Text = 1
            cmdInsertDetails_Click(sender, e)
        Next
    End Sub
    Private Sub lvListGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListGrp.SelectedIndexChanged
        On Error Resume Next
        ReturnGroup = lvListGrp.SelectedItems(0).Text
        FillStockItem(lvListGrp.SelectedItems(0).Text, cStore.Text, 1)
    End Sub
    Private Sub lvListProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvListProduct.Click
        lvListProduct_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub lvListProduct_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvListProduct.ColumnClick
        lvListProduct.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub lvListProduct_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvListProduct.DoubleClick
        On Error Resume Next
        tItemCode.Text = lvListProduct.SelectedItems(0).Text
        tItemCode_LostFocus(sender, e)
        tQty.Text = 1
        cmdInsertDetails_Click(sender, e)
    End Sub
    Private Sub lvListProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListProduct.SelectedIndexChanged
        On Error Resume Next
        ' If Not PanDetails.Visible Then Exit Sub
        tItemCode.Text = lvListProduct.SelectedItems(0).Text
        tItemCode_LostFocus(sender, e)

    End Sub
    Private Sub lnkItemList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkItemList.LinkClicked
        If lnkItemList.Text Like "Show*" Then
            tblProductListings.Visible = True
            lnkItemList.Text = "Hide Item Listings"
            tblMain.ColumnStyles(0).Width = 100
            tblMain.ColumnStyles(2).Width = 0
            Me.WindowState = FormWindowState.Maximized
            PanList.Top = tName.Top + 80 'tDesc.Height
            PanList.Left = tblDetails.Left + tName.Left + 5
        Else
            tblProductListings.Visible = False
            lnkItemList.Text = "Show Item Listings"
            tblMain.ColumnStyles(0).Width = 50
            tblMain.ColumnStyles(2).Width = 50
            Me.Width = tblDetails.Width + 20
            Me.WindowState = FormWindowState.Normal
            PanList.Top = tName.Top + 80
            PanList.Left = tName.Left + 5

            Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

        End If
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

    Private Sub cmdRequisition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRequisition.Click
        On Error GoTo errhdl
        If lvList.Items.Count <> 0 Then
            If MsgBox("Content of the list would be deleted" + Chr(13) + "Continue...(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, strApptitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        cmdCancel_Click(sender, e)
        Dim strValue As String = InputBox("Enter Requisition No", "Outstanding Requisiition", "*")
        If strValue = "" Then Exit Sub
        If strValue <> "*" Then
            If LoadLvListThroughRequisition(strValue) = False Then
                MsgBox("RequisitionNo do not exist", MsgBoxStyle.Information, strApptitle)
            Else
                ReturnRequisition = strValue
                tRequisitionNo.Text = ReturnRequisition
            End If
            Exit Sub
        End If
        'Dim strCaption(4) As String
        'Dim intWidth(4) As Integer
        'strCaption(0) = "Req. No"
        'intWidth(0) = 100
        'strCaption(1) = "Date"
        'intWidth(1) = 100
        'strCaption(2) = "Request Location"
        'intWidth(2) = 150
        'strCaption(3) = "Request Dept."
        'intWidth(3) = 150
        With FrmList
            .frmParent = Me
            .tSelection = "All Outstanding Requisition"
            .listQuery = "All Outstanding Requisition"
            .Text = "List of Outstanding Requisition"
            .ShowDialog()
        End With
        tRequisitionNo.Text = ReturnRequisition
        If LoadLvListThroughRequisition(ReturnRequisition) = False Then MsgBox("RequisitionNo do not exist", MsgBoxStyle.Information, strApptitle)

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Function LoadLvListThroughRequisition(ByVal strLPO As String) As Boolean
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        LoadLvListThroughRequisition = False
        If strLPO = "" Then Exit Function

        Dim i As Integer

        lvList.Items.Clear()

        cmSQL.CommandText = "ST_FetchOutStandingRequisition"

        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ReqNo", strLPO)

        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        Do While drSQL.Read = True
            Dim LvItems As New ListViewItem(lvList.Items.Count + 1)
            If Trim(UCase(drSQL.Item("ProductCode"))) = "(AUTO)" Then
                LvItems.SubItems.Add("{Unregistered}")
            Else
                LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            End If
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Balance"))
            'If ST_IgnoreBatch Then
            '    LvItems.SubItems.Add("@Batch")
            'Else
            LvItems.SubItems.Add(" ")  '(drSQL.Item("BatchNo")) 
            'End If
            LvItems.SubItems.Add(drSQL.Item("Category"))
            LvItems.SubItems.Add(drSQL.Item("ReqNo"))
            LvItems.SubItems.Add(Format(drSQL.Item("Cost"), Gen))
            LvItems.SubItems.Add(drSQL.Item("Pack"))
            LvItems.SubItems.Add(" ")  'ItemDescription
            LvItems.SubItems.Add(drSQL.Item("Sn"))
            lvList.Items.AddRange(New ListViewItem() {LvItems})
        Loop
        LoadLvListThroughRequisition = True
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()

        ' cnSQL.Close()
        'cnSQL.Dispose()

        For i = 0 To lvList.Items.Count - 1
            lvList.Items(i).Text = i + 1
            If i Mod 2 <> 0 Then lvList.Items(i).BackColor = Color.LavenderBlush
        Next
        Exit Function
        Resume
handler:
        MsgBox(Err.Description + Chr(13) + Err.Source, vbInformation, strApptitle)
    End Function
    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tUnitInStore.Text = Val(tUnitInStore.Tag) - Val(tQty.Text)
        If Val(tUnitInStore.Text) - Val(tReservedQty.Text) < 0 Then
            MsgBox("Requested Quantity more than stock level", MsgBoxStyle.Information, strApptitle)
            tQty.Text = 0
        End If
    End Sub
    Private Sub cBatchNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cBatchNo.SelectedIndexChanged
        tUnitInStore.Text = GetProductUnitInStore()
    End Sub

    Private Function ChkExisting(ByVal ProductCode As String, ByVal ProductBatch As String) As Integer
        On Error GoTo errhdl
        ChkExisting = -1
        For i = 0 To lvList.Items.Count - 1
            If lvList.Items(i).SubItems(1).Text = ProductCode And lvList.Items(i).SubItems(4).Text = ProductBatch Then
                ChkExisting = i
                Exit Function
            End If
        Next
        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    Private Function GetProductUnitInStore() As Double
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        GetProductUnitInStore = 0
        tUnitInStore.Tag = 0
        tUnitInStore.Text = 0
        tQty.Tag = 0
        tQty.Text = 0


        If Trim(tItemCode.Text) = "" Or Trim(cStore.Text) = "" Or Trim(cBatchNo.Text) = "" Then Exit Function

        cmSQL.CommandText = "ST_FetchQty4ActiveAvailableStoreItemsPerProductCodePerStorePerBatch"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@ProductCode", tItemCode.Text)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.Parameters.AddWithValue("@BatchNo", cBatchNo.Text)
        'cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            GetProductUnitInStore = 0
        Else
            If drSQL.Read = True Then
                GetProductUnitInStore = drSQL.Item("Qty")
                tUnitInStore.Tag = drSQL.Item("Qty")
                tUnitInStore.Text = drSQL.Item("Qty")
                tQty.Tag = Format(drSQL.Item("CostPriceNew"), Gen)
                tReservedQty.Text = drSQL.Item("ReservedQty")
            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        '        cStore.SelectedIndex = 0

        Exit Function
        Resume
handler:
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Function

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        FillGroup()
        FillCategory()

        'If ST_IgnoreStoreAssignment = False Then
        '    chkAuthorise.Enabled = StockChk4AuthorisationPriviledge("Issue", cStore.Text)
        '    mnuAuthorise.Enabled = chkAuthorise.Enabled
        'End If

        lvListProduct.Items.Clear()
        cmdCancel_Click(sender, e)

        'If lvList.Items.Count <> 0 Then
        '    If MsgBox("Content of the list would be deleted" + Chr(13) + "Continue...(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, strApptitle) = MsgBoxResult.No Then

        '    End If
        'End If

        lvList.Items.Clear()
    End Sub

    Private Sub FillGroup()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        'cnSQL.Open()
        'cmSQL.CommandText = "SELECT DISTINCT [Group] FROM ST_Grouping"
        cmSQL.CommandText = "SELECT DISTINCT ST_Grouping.[Group] FROM ST_StockQty RIGHT OUTER JOIN ST_Grouping ON ST_StockQty.ProductCode = ST_Grouping.ProductCode WHERE ST_StockQty.Qty > 0 AND ST_StockQty.Store = '" & cStore.Text & "'"
        cmSQL.CommandType = CommandType.Text
        drSQL = cmSQL.ExecuteReader()
        lvListGrp.Items.Clear()
        ' lvListGrp.Items.Add("<All>")
        Do While drSQL.Read
            lvListGrp.Items.Add(drSQL.Item("Group").ToString)
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

    Private Sub PanStockImage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanStockImage.MouseDown
        Stored1X = e.X
        Stored1Y = e.Y
        PanStockImage.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanStockImage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanStockImage.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanStockImage.Top = PanStockImage.Top - (Stored1Y - e.Y)
            PanStockImage.Left = PanStockImage.Left - (Stored1X - e.X)
        End If
        PanStockImage.Cursor = Cursors.Default
    End Sub

    Private Sub tItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tItemCode.TextChanged

    End Sub

    Private Sub lnkeDoc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkeDoc.LinkClicked
        If tGINNo.Text = "" Then Exit Sub
        Dim ChildForm As New StkFrmEDoc
        ChildForm.tRefNo.Text = IIf(tGINNo.Text = "(Auto)", ReturnGINo, tGINNo.Text)
        ChildForm.tRefNo.Tag = IIf(tGINNo.Text = "(Auto)", ReturnGINo, tGINNo.Text)
        ChildForm.PanBody.Visible = False
        ChildForm.ShowDialog()
    End Sub
    Private Sub lvList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        cmdOpen_Click(sender, e)
    End Sub

    Private Sub lnkPrintGRN_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPrintGRN.LinkClicked
        On Error Resume Next
        If Len(Trim(ReturnGINo)) = 0 Then
            MsgBox("Select Issue", vbInformation, strApptitle)
            Exit Sub
        End If
        Dim RptFilename As ReportDocument = New ReportDocument
        RptFilename = New ReportDocument()
        '     RptFilename = New Issue
        Dim ChildForm As New FrmRptDisplay
        ChildForm.RptDestination = "Screen"
        ChildForm.myReportDocument = RptFilename
        ChildForm.SelFormula = "{ST_RptIssue.GINo}='" & ReturnGINo & "'"

        ChildForm.Show()
    End Sub

    Private Sub PanList_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanList.Paint

    End Sub
End Class