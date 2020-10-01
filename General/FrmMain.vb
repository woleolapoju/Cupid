Imports System.IO
Imports System.Data.SqlClient
Public Class FrmMain
    Dim oShortCut As String = ""

    Dim noOfLogons As Integer = 0
    Public ReturnCode As String

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo handler

        FrmStart.lblOwner.Text = sysOwner
        tblMenu.Top = PanOwnerInfor.Top
       
        lblUserName1.Text = ""
        lblUserName2.Text = ""
        ' NoticeMenu.Visible = False
        If ST_TransType = "Service" Then PictRestock.Enabled = False

        On Error Resume Next
        If Not arrayLogo Is Nothing Then
            Dim ms As New MemoryStream(arrayLogo)
            FrmStart.OwnerLogo.Image = Image.FromStream(ms)
        End If
        If UBound(arrayLogo) <= 10 Then
            FrmStart.PanLogo.Visible = False
            FrmStart.tblBottom.ColumnStyles(0).Width = 1
        End If


        If sysUser = "" Then
            ' FrmLogin.Show()
            tblLogin.Visible = True
            txtUserId.Focus()
            Exit Sub
        End If


        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub FrmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        tblMenu.Top = PanOwnerInfor.Top + 20
    End Sub

    Private Sub mnuPict1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPict1.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '        Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET PicBody = 1 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        PictBody = 1
        GetBodyPict()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
        Else
            tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub mnuPict2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPict2.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '      Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET PicBody = 2 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        PictBody = 2
        GetBodyPict()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
        Else
            tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub mnuPict3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPict3.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '     Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET PicBody = 3 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        PictBody = 3
        GetBodyPict()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
        Else
            tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub mnuPict4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPict4.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '    Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = "Update UserAccess SET PicBody = 4 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        PictBody = 4
        GetBodyPict()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
        Else
            tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub mnuPict5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPict5.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '   Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET PicBody = 5 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        PictBody = 5
        GetBodyPict()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
        Else
            tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Public Sub GetBodyPict()
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        On Error GoTo handler

        ReDim arrayBody(0)
        'cnSQL.Open()

        cmSQL.CommandText = "FetchAllSystemParameters"
        cmSQL.CommandType = CommandType.StoredProcedure

        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
        Else
            If drSQL.Read Then
                If PictBody = 1 Then
                    arrayBody = CType(drSQL.Item("Pict1"), Byte())
                End If

                If PictBody = 2 Then
                    arrayBody = CType(drSQL.Item("Pict2"), Byte())
                End If

                If PictBody = 3 Then
                    arrayBody = CType(drSQL.Item("Pict3"), Byte())
                End If

                If PictBody = 4 Then
                    arrayBody = CType(drSQL.Item("Pict4"), Byte())
                End If

                If PictBody = 5 Then
                    arrayBody = CType(drSQL.Item("Pict5"), Byte())
                End If

            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        If Not arrayBody Is Nothing And arrayBody.Length > 1 Then
            Dim ms As New MemoryStream(arrayBody)
            tblBody.BackgroundImage = Image.FromStream(ms)
            'Else
            'tblBody.BackgroundImage = Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")
        End If


        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Critical, strApptitle)
    End Sub

    Private Sub mnuSystemPeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSystemPeriods.Click
        If GetUserAccessDetails("System Period") = False Then Exit Sub
        Dim ChildForm As New FrmSysPeriod
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub mnuClearPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearPicture.Click
        On Error Resume Next

        tblBody.BackgroundImage = Nothing ' Image.FromFile(AppPath + "\ConfigDir\BodyPic.jpg")

        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        '       Dim drSQL As SqlDataReader

        'cnSQL.Open()
        cmSQL.CommandText = " Update UserAccess SET PicBody = 0 WHERE UserID = '" & sysUser & "'"
        cmSQL.CommandType = CommandType.Text
        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        ' cnSQL.Close()
        'cnSQL.Dispose()

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub

    Private Sub RefreshNotice()
        'Dim j As Integer = 0
        'GetUserAccessDetails("Bills", False) : If ModuleAuthorise Then mnuBills4Approval.Visible = GetAccountsBills4Approval()
        'If ModuleAuthorise Then mnuBillReview4Approval.Visible = GetAccountsBillReviews4Approval()
        'If ModuleAdd Or ModuleEdit Then mnuRetainershipDueForPayment.Visible = GetRetainership4Payment()

        'If ModuleAuthorise Then j = j + 1
        'GetUserAccessDetails("Payment Request", False) : If ModuleAuthorise Then mnuPaymentRequestsAvailableForApproval.Visible = GetAccountsPayRequest4Approval()
        'If ModuleAuthorise Then j = j + 1
        'GetUserAccessDetails("Payments", False)
        'If ModuleAdd Or ModuleEdit Then
        '    mnuPayment4Disbursement.Visible = GetAccountsPayment4Disbursement()
        '    mnuCashAdvanceDue4Retirement.Visible = GetAccountsCashAdvanceDue4Retirement()
        'End If

        'If ModuleAuthorise Then
        '    mnuPayments4Approval.Visible = GetAccountsPayment4Approval()
        '    mnuRetainershipDueForPayment.Visible = GetRetainership4Payment()
        'End If

        'GetUserAccessDetails("Sales", False) : If ModuleAuthorise Then mnuSales4Approval.Visible = GetAccountsSales4Approval()
        'If ModuleAuthorise Then j = j + 1

        ''mnuVerifyTransactions

        'GetUserAccessDetails("Verify Bill", False)
        'If ModuleOpen Then mnuVerifyTransactions.Visible = GetBills4Verification()
        'If mnuVerifyTransactions.Visible = False Then
        '    GetUserAccessDetails("Verify Payment Request", False)
        '    If ModuleOpen Then mnuVerifyTransactions.Visible = GetPaymentRequest4Verification()
        'End If
        'If mnuVerifyTransactions.Visible = False Then
        '    GetUserAccessDetails("Verify Cash Advance", False)
        '    If ModuleOpen Then mnuVerifyTransactions.Visible = GetCashAdvance4Verification()
        'End If
        'If mnuVerifyTransactions.Visible = False Then
        '    GetUserAccessDetails("Verify Cash Advance Retirement", False)
        '    If ModuleOpen Then mnuVerifyTransactions.Visible = GetCashAdvanceRetire4Verification()
        'End If
        'If mnuVerifyTransactions.Visible = False Then
        '    GetUserAccessDetails("Verify Requisition", False)
        '    If ModuleOpen Then mnuVerifyTransactions.Visible = GetRequisition4Verification()
        'End If

        'If ModuleAuthorise Then j = j + 1
        'GetUserAccessDetails("Requisition", False) : If ModuleAuthorise Then mnuRequisitions4Approval.Visible = GetAccountsRequisition4Approval()
        'If ModuleAuthorise Then j = j + 1
        'GetUserAccessDetails("Cash Advance", False)
        'If ModuleAuthorise Then
        '    mnuCashAdvance4Approval.Visible = GetAccountsCashAdvance4Approval()
        '    mnuCashRetireApproval.Visible = GetAccountsCashAdvanceRetire4Approval()
        '    mnuCashAdvanceDue4Retirement.Visible = GetAccountsCashAdvanceDue4Retirement
        'End If
        'If ModuleAuthorise Then j = j + 1

    End Sub
    Private Sub tblBody_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblBody.Click
        tblMenu.Visible = False
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        'cnSQL.Open()

        cmSQL.CommandText = "FetchUserAccessByPwd"
        cmSQL.CommandType = CommandType.StoredProcedure
        cmSQL.Parameters.AddWithValue("@UserID", txtUserId.Text)
        cmSQL.Parameters.AddWithValue("@UserPwd", txtPwd.Text)
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Invalid User Login Information" & Chr(13) & "Access Denied", MsgBoxStyle.Information)
            If noOfLogons = 3 Then
                End
            Else
                noOfLogons += 1
                lblAttemps.Visible = True
                lblAttemps.Text = lblAttemps.Text + " *"
                drSQL.Close()
                Exit Sub
            End If
        End If
        On Error Resume Next
        If drSQL.Read Then
            sysUserName = drSQL.Item("UserName")
            PictBody = IIf(IsDBNull(drSQL.Item("PicBody")), 0, drSQL.Item("PicBody"))
            sysUser = drSQL.Item("UserID")
            MainTheme = IIf(IsDBNull(drSQL.Item("MainTheme")), Color.Khaki, Color.FromArgb(drSQL.Item("MainTheme")))
            HeaderTheme = IIf(IsDBNull(drSQL.Item("HeaderTheme")), Color.Goldenrod, Color.FromArgb(drSQL.Item("HeaderTheme")))
            MainThemeCode = IIf(IsDBNull(drSQL.Item("MainTheme")), Color.Khaki.ToArgb, drSQL.Item("MainTheme"))
            HeaderThemeCode = IIf(IsDBNull(drSQL.Item("HeaderTheme")) Or drSQL.Item("HeaderTheme") = "", Color.Goldenrod.ToArgb, drSQL.Item("HeaderTheme"))
        End If
        On Error GoTo handler
        drSQL.Close()

        'sysUser = txtUserId.Text
        sysPwd = txtPwd.Text

        GetBodyPict()
        tblLogin.Visible = False
        lblSignIn.Visible = True
        My.Application.DoEvents()



        myStyleGridAlternate.BackColor = MainTheme

        My.Application.DoEvents()


        'FrmMain.lblUserName.Text = sysUserName

        If UCase(sysOwner) <> UCase(strOwnerFromServer) Then
            cmSQL.CommandText = "UPDATE SystemParameters SET NName='" & sysOwner & "'"
            cmSQL.CommandType = CommandType.Text
            cmSQL.ExecuteNonQuery()
        End If
        drSQL.Close()
        'cmSQL.Connection.Close()
        cmSQL.Dispose()

        'cnSQL.Close()
        'cnSQL.Dispose()

        FrmStart.mnuSystemPeriod.Text = "System Period : " + sysPeriod  '+ "     (System User: " + UCase(sysUserName) + ")"


        InitialUserDetails()
        'PB1.Visible = True
        'PB1.Minimum = 0
        'PB1.Maximum = 27
        'PB1.Value = 0
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor

        '  FrmStart.TimeNotices_Tick(sender, e) '.GetItems4Approval()


        txtPwd.Text = ""
        txtUserId.Text = ""

        FrmStart.TimeNotices.Enabled = True
        FrmStart.TimerMail.Enabled = True

        FrmStart.timerBlink.Enabled = True

        Me.Cursor = Cursors.Default

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub
    Sub InitialUserDetails()
        If sysUser <> "" Then

            Dim i As Integer
            i = InStr(sysUserName, " ")
            If i > 0 Then
                lblUserName1.Text = Mid(sysUserName, 1, i - 1)
                lblUserName2.Text = Mid(sysUserName, i + 1)
            Else
                lblUserName1.Text = sysUserName
                lblUserName2.Text = ""
            End If

            ' lblSignIn.Text = "Lock"
        End If

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Private Sub lblSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSignIn.Click
        If sysUser = "" Then Exit Sub

        FrmStart.CloseAllToolStripMenuItem_Click(sender, e)

        tblMenu.Visible = False
        FrmStart.TimeNotices.Enabled = False
        FrmStart.TimerMail.Enabled = False

        lblAttemps.Text = "Attempts:"
        noOfLogons = 0
        ' If lblSignIn.Text = "Lock" Then
        ' lblSignIn.Text = "Sign In"
        tblLogin.Visible = True
        txtUserId.Text = sysUser
        ' txtUserId.Enabled = False
        txtPwd.Text = ""
        sysUser = ""
        lblSignIn.Visible = False
        txtPwd.Focus()
        'Else
        'lblSignIn.Text = "Lock"
        'tblLogin.Visible = True
        'txtUserId.Text = ""
        'txtUserId.Enabled = True
        'txtPwd.Text = ""
        'sysUser = ""
        'txtPwd.Focus()
        'End If
    End Sub
    Private Sub SvrInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SvrInfo.Click

        Dim ChildForm As New FrmSvrInfor
        ChildForm.TopMost = True
        ChildForm.ShowDialog()
    End Sub
    Private Sub PictSales_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictSales.MouseEnter
        If sysUser = "" Then Exit Sub
        PictSales.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictSales_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictSales.MouseLeave
        PictSales.BackColor = Color.DarkRed
    End Sub
    Private Sub PictRestock_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictRestock.MouseEnter
        If sysUser = "" Then Exit Sub
        PictRestock.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictRestock_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictRestock.MouseLeave
        PictRestock.BackColor = Color.DarkOrange
    End Sub

    Private Sub PictAdjust_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictAdjust.MouseEnter
        If sysUser = "" Then Exit Sub
        PictAdjust.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictAdjust_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictAdjust.MouseLeave
        PictAdjust.BackColor = Color.SeaGreen
    End Sub

    Private Sub PictStockList_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictStockList.MouseEnter
        If sysUser = "" Then Exit Sub
        PictStockList.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictStockList_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictStockList.MouseLeave
        PictStockList.BackColor = Color.Black
    End Sub
    Private Sub PictPayment_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictPayment.MouseEnter
        If sysUser = "" Then Exit Sub
        PictPayment.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictPayment_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictPayment.MouseLeave
        PictPayment.BackColor = Color.DarkSlateBlue
    End Sub

    Private Sub PictRefund_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictRefund.MouseEnter
        If sysUser = "" Then Exit Sub
        PictRefund.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictRefund_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictRefund.MouseLeave
        PictRefund.BackColor = Color.Tan
    End Sub
    Private Sub PictStockTransfer_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictStockTransfer.MouseEnter
        If sysUser = "" Then Exit Sub
        PictStockTransfer.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictStockTransfer_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictStockTransfer.MouseLeave
        PictStockTransfer.BackColor = Color.DarkOrchid
    End Sub
    Private Sub PictProformal_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictProformal.MouseEnter
        If sysUser = "" Then Exit Sub
        PictProformal.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictProformal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictProformal.MouseLeave
        PictProformal.BackColor = Color.MediumVioletRed
    End Sub
    Private Sub PictReport_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictReport.MouseEnter
        If sysUser = "" Then Exit Sub
        PictReport.BackColor = Color.DarkKhaki
        tblMenu.Left = tblControls.Left + tblReports.Left + PictReport.Left + 10
        tblMenu.Visible = True
        mnuStores.Visible = False
        mnuReportBuilder.Visible = True
        mnuStandardReports.Visible = True
        mnuClientProfile.Visible = False
        mnuProgramParameters.Visible = False
        mnuCoyInformation.Visible = False
        mnuBarcode.Visible = False
        mnuServerInfor.Visible = False
        mnuSystemPeriods.Visible = False
        mnuSystemUsers.Visible = False
        mnuAssignStores.Visible = False
        mnuChangePwd.Visible = False
        mnuAccountChart.Visible = False
        mnuBar1.Visible = False
        mnuBar2.Visible = False
        mnuAbout.Visible = False
        mnuBackup.Visible = False

        tblMenu.Height = 50
    End Sub
    Private Sub PictReport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictReport.MouseLeave
        PictReport.BackColor = Color.DarkSlateGray
    End Sub
    Private Sub Picttools_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictTools.MouseEnter
        If sysUser = "" Then Exit Sub
        PictTools.BackColor = Color.DarkKhaki
        tblMenu.Left = tblControls.Left + tbltools.Left + PictTools.Left + 10
        tblMenu.Visible = True
        mnuReportBuilder.Visible = False
        mnuStandardReports.Visible = False
        mnuClientProfile.Visible = True
        mnuProgramParameters.Visible = True
        mnuCoyInformation.Visible = True
        mnuServerInfor.Visible = True
        mnuSystemPeriods.Visible = True
        mnuSystemUsers.Visible = True
        mnuAssignStores.Visible = True
        mnuBackup.Visible = True
        mnuBarcode.Visible = True
        mnuChangePwd.Visible = True
        mnuAccountChart.Visible = True
        mnuStores.Visible = True
        mnuBar1.Visible = True
        mnuBar2.Visible = True
        mnuAbout.Visible = True
        tblMenu.Height = 250
    End Sub
    Private Sub Picttools_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictTools.MouseLeave
        PictTools.BackColor = Color.DarkGreen
    End Sub
    Private Sub mnuCoyInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCoyInformation.Click
        If GetUserAccessDetails("Company Information") = False Then Exit Sub
        Dim ChildForm As New FrmCoyInfo
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictExpense_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictExpense.MouseEnter
        If sysUser = "" Then Exit Sub
        PictExpense.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictExpense_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictExpense.MouseLeave
        PictExpense.BackColor = Color.Olive
    End Sub
    Private Sub PictIncome_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIncome.MouseEnter
        If sysUser = "" Then Exit Sub
        PictIncome.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictIncome_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIncome.MouseLeave
        PictIncome.BackColor = Color.CadetBlue
    End Sub
    Private Sub PictJournal_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictJournal.MouseEnter
        If sysUser = "" Then Exit Sub
        PictJournal.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub PictJournal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictJournal.MouseLeave
        PictJournal.BackColor = Color.DarkSalmon
    End Sub

    Private Sub PictStockList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictStockList.Click
        If GetUserAccessDetails("Stockitem List") = False Then Exit Sub
        Dim ChildForm As New stkFrmProductsList
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub mnuSetColorTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetColorTheme.Click
        Dim ChildForm As New FrmColorTheme
        ChildForm.ShowDialog()
    End Sub
    Private Sub mnuProgramParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgramParameters.Click
        If GetUserAccessDetails("Program Parameter") = False Then Exit Sub
        Dim ChildForm As New stkFrmSettings
        ChildForm.ShowDialog()
    End Sub

    Private Sub PictTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictTools.Click

    End Sub

    Private Sub PictAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictAdjust.Click
        If GetUserAccessDetails("Adjustment") = False Then Exit Sub
        Dim ChildForm As New stkFrmAdjustment
        ChildForm.Tag = ModuleEdit
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub

    Private Sub PictSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictSales.Click
        If GetUserAccessDetails("Sales") = False Then Exit Sub
        Dim ChildForm As New Form
        If SalesInputLayout = "Button" Then
            ChildForm = New stkFrmSales2
        ElseIf SalesInputLayout = "Mini" Then
            ChildForm = New stkFrmSales3
        Else
            ChildForm = New stkFrmSales1
        End If
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub

    Private Sub mnuAssignStores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAssignStores.Click
        If ST_IgnoreStoreAssignment = True Then
            MsgBox("Store Assignment is Ignored...Module not neccessary", vbInformation)
            Exit Sub
        End If
        If GetUserAccessDetails("Setup - Store Assignment") = False Then Exit Sub
        Dim ChildForm As New stkFrmAssignStore
        ChildForm.ShowDialog()

    End Sub

    Private Sub mnuSystemUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSystemUsers.Click
        If GetUserAccessDetails("System User") = False Then Exit Sub
        Dim ChildForm As New FrmSysUser
        ChildForm.ShowDialog()
    End Sub
    Private Sub mnuBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBackup.Click
        FrmBakRes.Action = "Backup"
        FrmBakRes.ShowDialog()
    End Sub
    Private Sub mnuChangePwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangePwd.Click
        FrmChangePwd.ShowDialog()
    End Sub
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        FrmAbout.ShowDialog()
    End Sub
    Private Sub mnuServerInfor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServerInfor.Click
        ' If GetUserAccessDetails("Server Information") = False Then Exit Sub
        Dim ChildForm As New FrmSvrInfor
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub

    Private Sub PictRestock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictRestock.Click
        If GetUserAccessDetails("Restock") = False Then Exit Sub
        Dim ChildForm As New stkFrmReceipt
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictRefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictRefund.Click
        Dim ChildForm As New stkFrmRefunds
        ChildForm.RefundType = ""
        'ChildForm.MdiParent = FrmStart
        ChildForm.ShowDialog()
    End Sub
    Private Sub mnuClientProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClientProfile.Click
        If GetUserAccessDetails("Setup - Client Register") = False Then Exit Sub
        Dim ChildForm As New FrmClient
        ChildForm.ShowDialog()
    End Sub

    Private Sub mnuReportBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportBuilder.Click
        If GetUserAccessDetails("Report Builder") = False Then Exit Sub
        Dim ChildForm As New FrmRptBuilder
        ChildForm.ShowDialog()
    End Sub
    Private Sub mnuStandardReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStandardReports.Click
        If GetUserAccessDetails("Reports") = False Then Exit Sub
        Dim ChildForm As New FrmReport
        ChildForm.ShowDialog()
    End Sub

    Private Sub PictStockTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictStockTransfer.Click
        If GetUserAccessDetails("Transfer") = False Then Exit Sub
        Dim ChildForm As New stkFrmTransfer
        ChildForm.ShowDialog()
    End Sub

    Private Sub PictPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictPayment.Click
        Dim ChildForm As New FrmPayment
        'ChildForm.MdiParent = FrmStart
        ChildForm.ShowDialog()
    End Sub

    Private Sub PictExpense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictExpense.Click
        If GetUserAccessDetails("Office Expenditure") = False Then Exit Sub
        Dim ChildForm As New FrmExpenses
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictIncome.Click
        If GetUserAccessDetails("Office Income") = False Then Exit Sub
        Dim ChildForm As New FrmIncome
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictJournal.Click
        If GetUserAccessDetails("Journal") = False Then Exit Sub
        Dim ChildForm As New FrmJournal
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub mnuAccountChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccountChart.Click
        If GetUserAccessDetails("Chart of Account") = False Then Exit Sub
        Dim ChildForm As New FrmChart
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictProformal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictProformal.Click
        If GetUserAccessDetails("Proformal Invoice") = False Then Exit Sub
        Dim ChildForm As New stkFrmProformal
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub lblClientLedger_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClientLedger.MouseEnter
        If sysUser = "" Then Exit Sub
        lblClientLedger.BackColor = Color.DarkKhaki
        tblMenu.Visible = False
    End Sub
    Private Sub lblClientLedger_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClientLedger.MouseLeave
        lblClientLedger.BackColor = Color.Transparent
    End Sub
    Private Sub PanNotice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanNotice.Click
        tblMenu.Visible = False
    End Sub
    Private Sub lblOwner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOwner.Click
        tblMenu.Visible = False
    End Sub
    Private Sub tblLogin_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tblLogin.Paint
        tblMenu.Visible = False
    End Sub
    Private Sub lblClientLedger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClientLedger.Click
        If GetUserAccessDetails("Client Transactions Summary") = False Then Exit Sub
        Dim ChildForm As New FrmClientLedger
        ChildForm.MdiParent = FrmStart
        ChildForm.Show()
    End Sub
    Private Sub PictReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictReport.Click
        mnuStandardReports_Click(sender, e)
    End Sub

    Private Sub mnuStores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStores.Click
        If GetUserAccessDetails("Store Setup") = False Then Exit Sub
        Dim ChildForm As New StkFrmStores
        ChildForm.ShowDialog()
    End Sub

    Private Sub mnuBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBarcode.Click
        If GetUserAccessDetails("Generate Barcode Label") = False Then Exit Sub
        Dim ChildForm As New FrmBarcode
        ChildForm.ShowDialog()
    End Sub
End Class