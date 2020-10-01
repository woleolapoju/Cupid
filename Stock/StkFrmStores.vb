Imports System.Data.SqlClient
Public Class StkFrmStores
    Public ReturnStore As String
    Public ReturnDefault As Boolean = False
    Public ReturnNonSelling As Boolean = False
    Dim Action As AppAction
    Private Sub StkFrmStores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo errhdl
        Panel2.BackColor = HeaderTheme
        Me.BackColor = MainTheme

        mnuNew.Enabled = ModuleAdd
        mnuEdit.Enabled = ModuleEdit
        mnuBrowse.Enabled = ModuleBrowse
        mnuDelete.Enabled = ModuleDelete

        If mnuNew.Enabled Then mnuNew_Click(sender, e)

        Exit Sub
errhdl:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    
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
        tStore.Text = ""
        chkDefault.Checked = False
    End Sub
    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        Action = AppAction.Edit
        InitialiseAction()
        On Error GoTo errhdl
        Dim strCaption(2) As String
        Dim intWidth(2) As Integer
        strCaption(0) = "Store"
        intWidth(0) = 300
        strCaption(1) = "Default"
        intWidth(1) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Store"
            .listQuery = "Store"
            .Text = "List of Stores"
            .ShowDialog()
        End With
        tStore.Text = ReturnStore
        chkDefault.Checked = ReturnDefault
        chkNonSelling.Checked = ReturnNonSelling
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
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
FetchNoAgain:
        If Trim(tStore.Text) = "" Then
            MsgBox("Store is required", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        'cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction
        Select Case Action
            Case AppAction.Add
                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                ' they can only be one default
                'set all other stores to non-default
                If chkDefault.Checked = True Then
                    cmSQL.CommandText = "UPDATE Store SET [Default]=0"
                    cmSQL.CommandType = CommandType.Text
                    cmSQL.ExecuteNonQuery()
                End If

                cmSQL.CommandText = "InsertStore"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Store", tStore.Text)
                cmSQL.Parameters.AddWithValue("@Default", chkDefault.Checked)
                cmSQL.Parameters.AddWithValue("@NonSelling", chkNonSelling.Checked)
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()

            Case AppAction.Edit
                If ReturnStore = "" Then
                    MsgBox("Pls. select a Store to edit", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If

                myTrans = cnSQL.BeginTransaction()
                cmSQL.Transaction = myTrans

                ' they can only be one default
                'set all other stores to non-default
                If chkDefault.Checked = True Then
                    cmSQL.CommandText = "UPDATE Store SET [Default]=0"
                    cmSQL.CommandType = CommandType.Text
                    cmSQL.ExecuteNonQuery()
                End If

                cmSQL.CommandText = "DeleteStore"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Store", ReturnStore)
                cmSQL.ExecuteNonQuery()

                cmSQL.Parameters.Clear()

                cmSQL.CommandText = "InsertStore"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Store", tStore.Text)
                cmSQL.Parameters.AddWithValue("@Default", chkDefault.Checked)
                cmSQL.Parameters.AddWithValue("@NonSelling", chkNonSelling.Checked)
                cmSQL.ExecuteNonQuery()

                'Update the store in ST_AssignedStore
                cmSQL.CommandText = "UPDATE AssignedStore SET Store='" & tStore.Text & "' WHERE Store='" & ReturnStore & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()

            Case AppAction.Delete
                If ReturnStore = "" Then
                    MsgBox("Pls. select a Store Code to delete", MsgBoxStyle.Information, strApptitle)
                    Exit Sub
                End If
                If MsgBox("Do You Want To Delete This Record?", vbQuestion + vbYesNo, strApptitle) = vbNo Then Exit Sub

                myTrans = cnSQL.BeginTransaction()

                cmSQL.Transaction = myTrans
                cmSQL.CommandText = "DeleteStore"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@Store", ReturnStore)
                cmSQL.ExecuteNonQuery()

                cmSQL.CommandText = "DELETE FROM AssignedStore WHERE Store='" & ReturnStore & "'"
                cmSQL.CommandType = CommandType.Text
                cmSQL.ExecuteNonQuery()

                myTrans.Commit()

        End Select
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Flush(Me)

        ReturnStore = ""
        ReturnDefault = False
        If mnuNew.Enabled Then mnuNew_Click(sender, e)
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        myTrans.Rollback()
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub mnuBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBrowse.Click
        Action = AppAction.Browse
        InitialiseAction()
        On Error GoTo errhdl
        Dim strCaption(2) As String
        Dim intWidth(2) As Integer
        strCaption(0) = "Store"
        intWidth(0) = 300
        strCaption(1) = "Default"
        intWidth(1) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Store"
            .listQuery = "Store"
            .Text = "List of Stores"
            .ShowDialog()
        End With
        tStore.Text = ReturnStore
        chkDefault.Checked = ReturnDefault
        chkNonSelling.Checked = ReturnNonSelling
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        On Error GoTo errhdl
        Action = AppAction.Add
        InitialiseAction()
        tStore.Focus()
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Action = AppAction.Delete
        InitialiseAction()
        On Error GoTo errhdl
        Dim strCaption(2) As String
        Dim intWidth(2) As Integer
        strCaption(0) = "Store"
        intWidth(0) = 300
        strCaption(1) = "Default"
        intWidth(1) = 100
        With FrmList
            .frmParent = Me
            .tSelection = "Store"
            .listQuery = "Store"
            .Text = "List of Stores"
            .ShowDialog()
        End With
        tStore.Text = ReturnStore
        chkDefault.Checked = ReturnDefault
        chkNonSelling.Checked = ReturnNonSelling
        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
End Class