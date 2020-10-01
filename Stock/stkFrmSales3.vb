Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Management
Public Class stkFrmSales3
    Public ReturnCode As String = ""
    Dim Action As AppAction
    Private printFont As Font
    Private streamToPrint As StreamReader
    Public Shared FullfilePath As String
    ' Dim WithEvents serialPort As New IO.Ports.SerialPort
    Dim chkProduct As Boolean = True
    Public ReturnOrderNo As Integer
    Public LastOrderNo As Integer = 0
    Private bindingSource As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Dim StoredX As Long
    Dim StoredY As Long
    Dim Stored1X As Long
    Dim Stored1Y As Long
    Dim Minimize_Size As Long
    Dim skipLostFocus As Boolean
    Dim DoNotMoveNext As Boolean = False
    Dim SkipRowEnter As Boolean = False
    Dim SelectedStore As String
    Private defaultNetwork As Boolean
    Private Sub stkFrmSales1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppHeader1.lblForm.Text = "Sales"
        lnkPortPrinter.BackColor = HeaderTheme
        Me.BackColor = MainTheme
        lvSalesList.BackColor = MainTheme
        tOrderNo.BackColor = MainTheme
        tCategoryName.BackColor = MainTheme
        tItemDesc.BackColor = MainTheme
        tStockLevel.BackColor = MainTheme
        tChange.BackColor = MainTheme
        tProductName.BackColor = MainTheme
        tTotalValue.BackColor = MainTheme
        Panel5.BackColor = MainTheme
        PanPrinter.BackColor = HeaderTheme
        Panel3.BackColor = HeaderTheme
        '  cStore.BackColor = HeaderTheme
        PanEntry.BackColor = MainTheme
        DGrid.AlternatingRowsDefaultCellStyle = myStyleGridAlternate
        PanList.BackColor = HeaderTheme
        FillStore()

        LoadPrinters()
        If defaultNetwork Then
            radioNetworkPrinters.Checked = True
        Else
            radioLocalPrinters.Checked = True
        End If
        ' FetchBatchNo("087400431030")
        cPOS.Items.Add("WinPrn")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cPOS.Items.Add(sp)
            cPole.Items.Add(sp)
        Next


        cPOS.Text = POSPrinter
        cPole.Text = POSPole
        chkPrint.Checked = PrintInvoice
        cInvoiceType.Text = InvoiceType

        dtpDate.Value = Now
        cmdNew.Enabled = ModuleAdd

        Action = AppAction.Add

        mnuEdit.Enabled = ModuleEdit And ModuleDelete
        PanCostPrice.Visible = ModuleEdit

        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        PanPrinter.Location = New Point(4, 49)

        AddHandler cmd1.Click, AddressOf btnClick
        AddHandler cmd2.Click, AddressOf btnClick
        AddHandler cmd3.Click, AddressOf btnClick
        AddHandler cmd4.Click, AddressOf btnClick
        AddHandler cmd5.Click, AddressOf btnClick
        AddHandler cmd6.Click, AddressOf btnClick
        AddHandler cmd7.Click, AddressOf btnClick
        AddHandler cmd8.Click, AddressOf btnClick
        AddHandler cmd9.Click, AddressOf btnClick
        AddHandler cmd0.Click, AddressOf btnClick

    End Sub
    Private Function GetProductByCode(ByVal ProductCode As String) As Boolean
        On Error GoTo errhdl


        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        GetProductByCode = False

        tProductName.Text = ""
        tCategoryName.Text = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0
        tItemCode.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If Trim(ProductCode) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductCodePerStore"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            GetProductByCode = False
            tItemCode.Focus()
            cmSQL.Dispose()
            drSQL.Close()
            Exit Function
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("Category")
                tItemCode.Tag = drSQL.Item("TransType")

                'tStockLevel.Text = drSQL.Item("UnitInStock")
                'tQty.Tag = drSQL.Item("Qty")
                'tQty.Text = 1
                'tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                'tQty.Minimum = 1
                'tQty.Maximum = Val(tQty.Tag)

                tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))

                'tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                'tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                'If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                '    cFixedPrice.SelectedIndex = 0
                'Else
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                '    cFixedPrice.SelectedIndex = 0
                'End If


                'If drSQL.Item("CostPriceNew") <> drSQL.Item("CostPriceOld") Then
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                '    cCostPrice.SelectedIndex = 0
                'Else
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                '    cCostPrice.SelectedIndex = 0
                'End If

                'cCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)
            End If
            GetProductByCode = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        GetProductDetails(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If

    End Function
    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        cmdSave.Enabled = True
        cmdNew.Enabled = False
        FetchNextNo()
        'tItemCode.Focus()
        tItemCode.Focus()
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = False
    End Sub

    Private Function FetchNextNo() As Integer
        On Error GoTo errhdl
        FetchNextNo = 0
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        cmSQL.CommandText = "FetchNewSalesOrderNo"
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader
        If drSQL.HasRows Then If drSQL.Read Then tOrderNo.Text = drSQL.Item("NewNo")
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Exit Function
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        ' Dim drSQL As SqlDataReader

        Dim cnSQL1 As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL1 As SqlCommand = cnSQL1.CreateCommand
        Dim drSQL1 As SqlDataReader

        'Dim cmSQL2 As SqlCommand = cnSQL1.CreateCommand
        'Dim drSQL2 As SqlDataReader

        If ValidateDate(dtpDate.Text, "Transaction Date") = False Then Exit Sub

        Dim MainCashPaid As Double = 0

        If Val(tPaid.Text) < 0 Then
            MsgBox("Amount paid cannot be less than zero (0)", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If
        If Val(tPayable.Text) < 0 Then
            MsgBox("Payable amount cannot be less than Zero (0)", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        If chkGiveChange.Checked = True Then
            If CDbl(tChange.Text) <> 0 Then
                If CDbl(tChange.Text) < 0 Then
                    MainCashPaid = CDbl(tPaid.Text)
                Else
                    MainCashPaid = CDbl(tPaid.Text) - CDbl(tChange.Text)
                End If
            Else
                MainCashPaid = CDbl(tPaid.Text)
            End If
        Else
            MainCashPaid = CDbl(tPaid.Text)
        End If

        If MainCashPaid > CDbl(tPayable.Text) Then
            If MsgBox("Over payment!!...continue (y/n)", MsgBoxStyle.Information + vbYesNo, strApptitle) = vbNo Then Exit Sub
        End If

        If MainCashPaid < CDbl(tPayable.Text) Then
            MsgBox("Credit Transaction not allowed", MsgBoxStyle.Information, strApptitle)
            Exit Sub
        End If

        Dim i As Integer

        ''cnSQL.Open()

        Dim myTrans As SqlClient.SqlTransaction

        If Action = AppAction.Add Then FetchNextNo()
        myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable)
        cmSQL.Transaction = myTrans

        If Action = AppAction.Edit Then
            cmSQL1.CommandText = "SELECT * FROM SalesDetails WHERE OrderNo=" & Val(tOrderNo.Text)
            cmSQL1.CommandType = CommandType.Text
            cnSQL1.Open()
            drSQL1 = cmSQL1.ExecuteReader()
            Do While drSQL1.Read
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "UpdateProduct4Sales"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
                cmSQL.Parameters.AddWithValue("@ProductCode", drSQL1.Item("ProductCode"))
                cmSQL.Parameters.AddWithValue("@Store", drSQL1.Item("Store"))
                cmSQL.ExecuteNonQuery()
            Loop
            drSQL1.Close()
            cmSQL1.Dispose()
            cnSQL1.Close()

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "DeleteSales"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", Val(tOrderNo.Text))
            cmSQL.ExecuteNonQuery()
        End If
        Dim salesValue As Double = CDbl(tTotalValue.Text)   'Val(tPayable.Text) - Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2) + Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2)
        If lvSalesList.Items.Count > 0 Then
            Dim TheStore As String = ""
            For i = 0 To lvSalesList.Items.Count - 1
                If TheStore Like "*" & lvSalesList.Items(i).SubItems(12).Text & "*" Then GoTo skipit
                TheStore = TheStore + IIf(TheStore = "", "", ",") + lvSalesList.Items(i).SubItems(12).Text
SkipIt:
            Next i

            cmSQL.Parameters.Clear()
            cmSQL.CommandText = "InsertSales"
            cmSQL.CommandType = CommandType.StoredProcedure
            cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
            cmSQL.Parameters.AddWithValue("@Date", formatDate(dtpDate))
            cmSQL.Parameters.AddWithValue("@CustomerCode", "")
            cmSQL.Parameters.AddWithValue("@CustomerName", "")
            cmSQL.Parameters.AddWithValue("@SourceDoc", tSourceDoc.Text)
            cmSQL.Parameters.AddWithValue("@AmountPaid", MainCashPaid) 'Val(tPaid.Text))
            cmSQL.Parameters.AddWithValue("@OrderValue", Math.Round(salesValue, 2))
            cmSQL.Parameters.AddWithValue("@Discount", Math.Round(IIf(chkDiscount.Checked, (CDbl(tDiscount.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text)), 2)) 'Math.Round(IIf(chkDiscount.Checked, Val(tDiscount.Text) * Val(tTotalValue.Text), Val(tDiscount.Text)), 2))
            cmSQL.Parameters.AddWithValue("@VAT", Math.Round(IIf(chkVAT.Checked, (CDbl(tVat.Text) / 100) * CDbl(tTotalValue.Text), CDbl(tVat.Text)), 2)) 'Math.Round(IIf(chkVAT.Checked, Val(tVat.Text) * Val(tTotalValue.Text), Val(tVat.Text)), 2))
            cmSQL.Parameters.AddWithValue("@AmtInWord", IIf(MainCashPaid = 0, "", Towords(MainCashPaid, "Naira", "Kobo") + " Only"))
            cmSQL.Parameters.AddWithValue("@PaymentMode", "Cash")
            cmSQL.Parameters.AddWithValue("@PaymentDetails", "")
            cmSQL.Parameters.AddWithValue("@Username", sysUserName)
            cmSQL.Parameters.AddWithValue("@ReceiptNo", 0)
            cmSQL.Parameters.AddWithValue("@DepositTag", 0)
            cmSQL.Parameters.AddWithValue("@SalesStore", TheStore)

            cmSQL.ExecuteNonQuery()

            'tPayable.Text = Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2)

            For i = 0 To lvSalesList.Items.Count - 1
                cmSQL.Parameters.Clear()
                cmSQL.CommandText = "InsertSalesDetails"
                cmSQL.CommandType = CommandType.StoredProcedure
                cmSQL.Parameters.AddWithValue("@OrderNo", tOrderNo.Text)
                cmSQL.Parameters.AddWithValue("@SalesIndex", i + 1)
                cmSQL.Parameters.AddWithValue("@CategoryName", lvSalesList.Items(i).SubItems(1).Text)
                cmSQL.Parameters.AddWithValue("@ProductCode", lvSalesList.Items(i).SubItems(2).Text)
                cmSQL.Parameters.AddWithValue("@ProductName", lvSalesList.Items(i).SubItems(3).Text)
                cmSQL.Parameters.AddWithValue("@Qty", Val(lvSalesList.Items(i).SubItems(4).Text))
                cmSQL.Parameters.AddWithValue("@SellPrice", CDbl(lvSalesList.Items(i).SubItems(5).Text))
                cmSQL.Parameters.AddWithValue("@FixedPrice", CDbl(lvSalesList.Items(i).SubItems(7).Text))
                cmSQL.Parameters.AddWithValue("@Details", lvSalesList.Items(i).SubItems(8).Text)
                cmSQL.Parameters.AddWithValue("@SalesPerson", lvSalesList.Items(i).SubItems(9).Text)
                cmSQL.Parameters.AddWithValue("@CostPrice", CDbl(lvSalesList.Items(i).SubItems(10).Text))
                cmSQL.Parameters.AddWithValue("@ProductDesc", lvSalesList.Items(i).SubItems(11).Text)
                cmSQL.Parameters.AddWithValue("@Store", lvSalesList.Items(i).SubItems(12).Text)
                cmSQL.Parameters.AddWithValue("@TransType", lvSalesList.Items(i).SubItems(13).Text)

                cmSQL.ExecuteNonQuery()
            Next i
        End If

        myTrans.Commit()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        Dim Thefile As System.IO.StreamWriter = Nothing
        If chkPrint.Checked = True And InvoiceType = "POS" And lvSalesList.Items.Count > 0 Then

            'writing invoice to file

            If File.Exists(AppPath + "\InvoiceFile.txt") Then
                File.Delete(AppPath + "\InvoiceFile.txt")
            End If

            Thefile = My.Computer.FileSystem.OpenTextFileWriter(AppPath + "\InvoiceFile.txt", True)

            ' file.Close()

            'FileOpen(1, AppPath + "\InvoiceFile.txt", OpenMode.Output)
            Thefile.WriteLine(UCase(sysOwner))
            Thefile.WriteLine(Address)
            Thefile.WriteLine(Phone)

            Thefile.WriteLine("Date: " + Format(dtpDate.Value, "dd-MMM-yyyy"))
            Thefile.WriteLine("Invoice No: " + Trim(Int(tOrderNo.Text)))
            Thefile.WriteLine("Teller: " + Trim(sysUserName))

            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
            Thefile.WriteLine("Item" + Microsoft.VisualBasic.StrDup(14, Chr(32)) + "Qty" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + "Price" + Microsoft.VisualBasic.StrDup(4, Chr(32)) + "Value")
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(42, "-"))
            'Thefile.WriteLine("")

            For i = 0 To lvSalesList.Items.Count - 1
                'If chkPrint.Checked = True And InvoiceType = "POS" Then
                Dim TheItem As String = lvSalesList.Items(i).SubItems(3).Text
                If Len(TheItem) <= 15 Then
                    Thefile.WriteLine(TheItem + Microsoft.VisualBasic.StrDup(15 - Len(TheItem) + 3, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(4).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(4).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(4).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(6).Text)
                Else
                    Thefile.WriteLine(Microsoft.VisualBasic.Left(TheItem, 15) + "-" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + Trim(lvSalesList.Items(i).SubItems(4).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(4).Text)) > 5, 0, 5 - Len(Trim(lvSalesList.Items(i).SubItems(4).Text))), Chr(32)) + Trim(lvSalesList.Items(i).SubItems(5).Text) + Microsoft.VisualBasic.StrDup(IIf(Len(Trim(lvSalesList.Items(i).SubItems(5).Text)) > 9, 0, 9 - Len(Trim(lvSalesList.Items(i).SubItems(5).Text))), Chr(32)) + lvSalesList.Items(i).SubItems(6).Text)
                    TheItem = Mid(TheItem, 16)
                    If Len(TheItem) <= 15 Then
                        Thefile.WriteLine(TheItem)
                    Else
                        Do While Len(TheItem) > 15
                            Thefile.WriteLine((Microsoft.VisualBasic.Left(TheItem, 15) + IIf(Len(Mid(TheItem, 16)) > 15, "-", "")))
                            TheItem = Mid(TheItem, 15)
                        Loop
                    End If
                End If
                'End If
            Next i
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
            Thefile.WriteLine("Sales Value:" + Microsoft.VisualBasic.StrDup(6, Chr(32)) + Trim(CDbl(tTotalValue.Text)))
            Thefile.WriteLine("Add VAT:" + Microsoft.VisualBasic.StrDup(10, Chr(32)) + Str(Math.Round(IIf(chkVAT.Checked, CDbl(tVat.Text) * CDbl(tTotalValue.Text), CDbl(tVat.Text)), 2)))
            Thefile.WriteLine("Less Discount:" + Microsoft.VisualBasic.StrDup(5, Chr(32)) + Str(Math.Round(IIf(chkDiscount.Checked, CDbl(tDiscount.Text) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text)), 2)))
            Thefile.WriteLine("Payment:" + Microsoft.VisualBasic.StrDup(19, Chr(32)) + Trim(MainCashPaid)) 'Val(tPaid.Text)
            Thefile.WriteLine(Microsoft.VisualBasic.StrDup(17, Chr(32)) + "------------------------")
            Dim TValue As Double = CDbl(tTotalValue.Text) + IIf(chkVAT.Checked, CDbl(tVat.Text) * CDbl(tTotalValue.Text), CDbl(tVat.Text)) - IIf(chkDiscount.Checked, CDbl(tDiscount.Text) * CDbl(tTotalValue.Text), CDbl(tDiscount.Text))
            'Trim(CDbl(tVat.Text) + CDbl(tTotalValue.Text) - CDbl(tDiscount.Text))
            Thefile.WriteLine("Net Total:" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Str(TValue) + Microsoft.VisualBasic.StrDup(IIf(Len(TValue) > 14, 0, 14 - Len(TValue)), Chr(32)) + Trim(MainCashPaid))
            Thefile.WriteLine("Bal:     :" + Microsoft.VisualBasic.StrDup(8, Chr(32)) + Trim(Str(Math.Round(CDbl(TValue) - MainCashPaid))))
            Thefile.WriteLine("Payment Mode:" + Microsoft.VisualBasic.StrDup(2, Chr(32)) + "Cash")
            'Thefile.WriteLine("")
            Thefile.WriteLine("Thanks for your patronage")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.WriteLine("")
            Thefile.Close()
        End If

        LastOrderNo = Val(tOrderNo.Text)
        If chkPrint.Checked = True And lvSalesList.Items.Count > 0 Then Call PrintTheInvoice()

        flush()
        cmdSave.Enabled = False
        cmdNew.Enabled = True


        Action = AppAction.Add
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = True

        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        If Err.Number = 57 Then Thefile.Close()
        myTrans.Rollback()

    End Sub

    Private Sub PrintTheInvoice() 'Optional LPT As String = "LPT1")
        On Error GoTo errhdl
        'Dim LPT As String = cPOS.Text
        'Dim ThePort As Integer = Val(Mid(cPOS.Text, 4))

        'If GetUserReportAccess("Sales Invoice") = False Then Exit Sub

        If InvoiceType = "POS" Then 'POS Invoice
            If Trim(cPOS.Text) = "WinPrn" Then
                If radioLocalPrinters.Checked Then
                    printerName = cboLocalPrinters.SelectedItem.ToString()
                Else
                    'If the network printer radio button is checked, we try to associate the selected network printer.
                    printerName = cboNetworkPrinters.SelectedItem.ToString()
                End If

                Dim printerSettings As New PrinterSettings()
                printerSettings.PrinterName = printerName

                'Here, we try to see if the printer really exists. Otherwise, it's no use to print there.
                If printerSettings.IsValid Then printDoc.PrinterSettings = printerSettings

                printDoc.Print()

            Else                '----open serial port
                'If serialPort.IsOpen Then
                '    serialPort.Close()
                'End If
                'With serialPort
                '    .PortName = cPOS.Text
                '    .BaudRate = 9600
                '    .Parity = IO.Ports.Parity.None
                '    .DataBits = 8
                '    .StopBits = IO.Ports.StopBits.One
                'End With
                'serialPort.Open()
                'serialPort.Close()
                '-------------
                'serialPort
                Dim objStreamReader As StreamReader
                Dim strLine As String = ""

                ' objStreamReader = New StreamReader(AppPath + "\InvoiceFile.txt")
                objStreamReader = New StreamReader(AppPath(+IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt")))

                'strLine = objStreamReader.ReadLine 'Read the first line of text.

                'Continue to read until you reach the end of the file.
                Do While Not strLine Is Nothing
                    ' AccessPort(LPT, strLine)
                    On Error GoTo skipIt
                    strLine = objStreamReader.ReadLine
                    'Read the next line.
                    ' WriteToComPort(ThePort, strLine)
                    ' MsgBox(strLine)
                    AccessPort(cPOS.Text, strLine + vbCrLf)
                    'serialPort.Write(strLine & vbCrLf)

                Loop
SkipIt:

                FileClose(1)
                objStreamReader.Close()


                '            PrintFile(AppPath + "\InvoiceFile.txt")

                'Dim objStreamReader As StreamReader
                'Dim strLine As String
                'FileOpen(1, LPT, OpenMode.Output)

                'objStreamReader = New StreamReader(AppPath + "\InvoiceFile.txt")

                'strLine = objStreamReader.ReadLine 'Read the first line of text.

                ''Continue to read until you reach the end of the file.
                'Do While Not strLine Is Nothing
                '    Print(2, strLine)
                '    strLine = objStreamReader.ReadLine                 'Read the next line.
                'Loop
                'FileClose(1)
                'objStreamReader.Close()
            End If
        Else 'Standard Invoice



            Dim report As New ReportDocument()
            report.Load(AppPath + "ConfigDir\Invoice.rpt")


            Dim intCounter As Integer
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
            ConInfo.ConnectionInfo.DatabaseName = AttachName
            ConInfo.ConnectionInfo.ServerName = ServerName
            If IntegratedSecurity Then
                ConInfo.ConnectionInfo.IntegratedSecurity = True
            Else
                ConInfo.ConnectionInfo.Password = Password
                ConInfo.ConnectionInfo.UserID = UserID
            End If

            For intCounter = 0 To report.Database.Tables.Count - 1
                report.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next


            ' You can change more print options via PrintOptions property of ReportDocument
            Dim jk As Integer = 1
            jk = IIf(Val(tCopies.Text) = 0, 1, Val(tCopies.Text))
            Dim SelFormular As String = "{RptSales.OrderNo}=" & LastOrderNo  'Val(tOrderNo.Text)

            report.RecordSelectionFormula = SelFormular
            If radioLocalPrinters.Checked Then
                report.PrintOptions.PrinterName = cboLocalPrinters.SelectedItem.ToString()
            Else
                'If the network printer radio button is checked, we try to associate the selected network printer.
                report.PrintOptions.PrinterName = cboNetworkPrinters.SelectedItem.ToString()
            End If
            '            report.SetDatabaseLogon(UserID, Password)
            report.PrintToPrinter(jk, True, 0, 0)

            report.Close()


            If chkReceipt.Checked = True Then


                report.Load(AppPath + "ConfigDir\InvoiceReceipt.rpt")


                For intCounter = 0 To report.Database.Tables.Count - 1
                    report.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
                Next


                jk = IIf(Val(tCopies.Text) = 0, 1, Val(tCopies.Text))
                SelFormular = "{RptSales.OrderNo}=" & LastOrderNo  'Val(tOrderNo.Text)

                report.RecordSelectionFormula = SelFormular
                If radioLocalPrinters.Checked Then
                    report.PrintOptions.PrinterName = cboLocalPrinters.SelectedItem.ToString()
                Else
                    'If the network printer radio button is checked, we try to associate the selected network printer.
                    report.PrintOptions.PrinterName = cboNetworkPrinters.SelectedItem.ToString()
                End If
                report.PrintToPrinter(jk, True, 0, 0)

                report.Close()

            End If


        End If

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub tItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tItemCode.KeyPress
        If e.KeyChar = Chr(13) Then
            If GetProductByCode(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
        End If
    End Sub

    Private Sub tItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tItemCode.LostFocus
        On Error GoTo handler
        If tItemCode.Text = "" Then Exit Sub
        If GetProductByCode(tItemCode.Text) = False Then
            tItemCode.Focus()
        Else
            tQty.Focus()
        End If
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub flush()
        dtpDate.Value = Now
        ReturnOrderNo = 0
        tOrderNo.Text = ""
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0

        tDetails.Text = ""
        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()
        cCostPrice.Tag = 0
        tItemCode.Focus()

        tTotalValue.Text = 0
        tVat.Text = Vat
        chkVAT.Checked = True
        tDiscount.Text = Discount
        'chkDiscount.Checked = True
        tPayable.Text = 0
        tPaid.Text = 0
        lvSalesList.Items.Clear()
        DoNotExist = False
       
        tSourceDoc.Text = ""


    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        tItemCode.Text = ""
        tProductName.Text = ""
        tCategoryName.Text = ""
        tCategoryName.Tag = ""

        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tQty.Text = ""
        tQty.Tag = 0
        tStockLevel.Text = 0
        tDetails.Text = ""

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()
        tItemCode.Focus()

    End Sub

    Private Sub tQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tQty.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tQty.TextChanged
        tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
    End Sub
    Private Sub tStockLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tStockLevel.TextChanged
        If Val(tStockLevel.Text) < 0 Then
            MsgBox("Purchase Quantity greater than Stock Level", MsgBoxStyle.Information, strApptitle)
            tQty.Text = 1
        End If
    End Sub

    Private Function ProductAreadyInList(ByVal ProductCode As String, ByVal SalesPerson As String, ByVal TheStore As String) As Integer
        On Error GoTo errhdl
        ProductAreadyInList = -2
        Dim i As Integer
        For i = 0 To lvSalesList.Items.Count - 1
            If lvSalesList.Items(i).SubItems(2).Text = ProductCode And lvSalesList.Items(i).SubItems(9).Text = SalesPerson And lvSalesList.Items(i).SubItems(12).Text = TheStore Then
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
    Private Sub cmdAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccept.Click
        On Error GoTo handler
        If cmdSave.Enabled = False Then Exit Sub

        If IsNumeric(tSellPrice.Text) = False Or IsNumeric(tQty.Text) = False Then
            MsgBox("Quantity and Selling Price must be numeric", vbInformation, strApptitle)
            Exit Sub
        End If

        If Val(tSellPrice.Text) < Val(tSellPrice.Tag) Then
            If MsgBox("Selling Below Selling Price" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbNo Then Exit Sub
        End If

        If Val(tQty.Text) < 0 Then
            MsgBox("Quantity must be positive", vbInformation, strApptitle)
            Exit Sub
        End If
        If tItemCode.Text = "" Or tProductName.Text = "" Or tCategoryName.Text = "" Or Val(tQty.Text) = 0 Then
            MsgBox("Incomplete record", vbInformation, strApptitle)
            Exit Sub
        End If

        ' IMPORTANT
        Dim PositionInList As Integer = ProductAreadyInList(tItemCode.Text, cSalesPerson.Text, cStore.Text)
        If PositionInList >= 0 Then
                  lvSalesList.Items(PositionInList).SubItems(4).Text = CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) + CDbl(tQty.Text)
            lvSalesList.Items(PositionInList).SubItems(5).Text = Format(IIf((CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) = 0, 0, Math.Round(CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text) + CDbl(tSellPrice.Text)) / 2), "standard")
            ' lvSalesList.Items(PositionInList).SubItems(6).Text = Val(lvSalesList.Items(PositionInList).SubItems(6)) + (Val(tQty.Text) * Val(tSellPrice.Text))

            lvSalesList.Items(PositionInList).SubItems(6).Text = Format(CDbl(lvSalesList.Items(PositionInList).SubItems(4).Text) * CDbl(lvSalesList.Items(PositionInList).SubItems(5).Text), "standard") ' seem dump hen!!, don't delete i know what am doing
            lvSalesList.Items(PositionInList).SubItems(8).Text = lvSalesList.Items(PositionInList).SubItems(8).Text + IIf(Trim(tDetails.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(8).Text) = "", "", ",") + tDetails.Text)
            lvSalesList.Items(PositionInList).SubItems(9).Text = lvSalesList.Items(PositionInList).SubItems(9).Text + IIf(Trim(cSalesPerson.Text) = "", "", IIf(Trim(lvSalesList.Items(PositionInList).SubItems(9).Text) = "", "", ",") + cSalesPerson.Text)

        Else

            'including when PositionInList = -1 MsgBox("Item Already in List with different Deposit Status" & Chr(13) & "It cannot be added to the existing Product", vbInformation, strApptitle)
            Dim LvItems As New ListViewItem
            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(tCategoryName.Text)
            LvItems.SubItems.Add(tItemCode.Text)
            LvItems.SubItems.Add(tProductName.Text)
            LvItems.SubItems.Add(Val(tQty.Text))
            LvItems.SubItems.Add(Format(CDbl(tSellPrice.Text), "Standard"))
            LvItems.SubItems.Add(Format(CDbl(tQty.Text) * CDbl(tSellPrice.Text), "Standard"))
            LvItems.SubItems.Add(tSellPrice.Tag)
            LvItems.SubItems.Add(tDetails.Text)
            LvItems.SubItems.Add(cSalesPerson.Text)
            LvItems.SubItems.Add(CDbl(cCostPrice.Tag))
            LvItems.SubItems.Add(tItemDesc.Text)
            LvItems.SubItems.Add(cStore.Text)
            LvItems.SubItems.Add(tItemCode.Tag) 'TransType

            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

        End If
        calculatePayable()

        If Trim(cPole.Text) <> "" Then
            '' AccessPort(cPole.Text, "")
            '' AccessPort(cPole.Text, "Your Charge is " + Chr(10) + Chr(13) + Chr(10) + Chr(13) + tPayable.Text + " Naira")
            'AccessPort(cPole.Text, "Your Charge is " + tPayable.Text + " Naira")
            '' AccessPort(cPole.Text, tPayable.Text + " Naira")
            Print2ComPort(cPole.Text, "                                                                            " + Chr(13))
            'Print2ComPort(cPole.Text, "Your Charge is " + Chr(13))
            Print2ComPort(cPole.Text, tPayable.Text + " Naira")
        End If


        cmdClear_Click(sender, e)
        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub
    Sub calculatePayable()
        On Error GoTo handler
        Dim i As Integer
        Dim ThePayable As Double = 0
        For i = 0 To lvSalesList.Items.Count - 1
            ThePayable = ThePayable + CDbl(lvSalesList.Items(i).SubItems(7).Text)
        Next
        tTotalValue.Text = Format(Math.Round(ThePayable, 2), "standard")
        tPayable.Text = Format(Math.Round(ThePayable + IIf(chkVAT.Checked, (Val(tVat.Text) / 100) * ThePayable, Val(tVat.Text)) - IIf(chkDiscount.Checked, (Val(tDiscount.Text) / 100) * ThePayable, Val(tDiscount.Text)), 2), "standard")
        'If Trim(cPole.Text) <> "" Then
        '    AccessPort(cPole.Text, "")
        '    AccessPort(cPole.Text, "Your Charge is" + Chr(10) + Chr(13))
        '    AccessPort(cPole.Text, tPayable.Text + " Naira")
        'End If

        Exit Sub
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub tTotalValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tTotalValue.TextChanged
        calculatePayable()
    End Sub

    Private Sub tVat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tVat.TextChanged
        calculatePayable()
    End Sub

    Private Sub tDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tDiscount.TextChanged
        calculatePayable()
    End Sub

    Private Sub tPayable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tPayable.TextChanged
        tPaid.Text = tPayable.Text
    End Sub

    Private Sub chkVAT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVAT.CheckedChanged
        calculatePayable()
    End Sub

    Private Sub chkDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiscount.CheckedChanged
        calculatePayable()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        flush()
        lvSalesList.Items.Clear()
        cmdNew.Enabled = True
        cmdSave.Enabled = False
        tItemCode.Focus()
        ReturnOrderNo = 0
        cmdNew.Enabled = ModuleAdd
        Action = ModuleAdd
        If ST_IgnoreStoreAssignment = False Then cStore.Enabled = True
    End Sub


    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        On Error GoTo errhdl
        'Dim strValue As String
        'Dim strPrompt As String
        'Dim strCaption(6) As String
        'Dim intWidth(6) As Integer
        'strCaption(0) = "Order No"
        'strCaption(1) = "Date"
        'strCaption(2) = "No of Items"
        'strCaption(3) = "Order Value"
        'strCaption(4) = "Amt Paid"
        'strCaption(5) = "Sales Person"

        'intWidth(0) = 70
        'intWidth(1) = 80
        'intWidth(2) = 100
        'intWidth(3) = 80
        'intWidth(4) = 80
        'intWidth(5) = 80
        Action = AppAction.Edit
        Dim strOrder As String = InputBox("Enter Order No", "Sales", "*")
        If strOrder = "" Then
            Exit Sub
        ElseIf Not Trim(strOrder) = "*" Then
            ReturnOrderNo = Val(strOrder)
            LoadEditableOrder(ReturnOrderNo)
            Exit Sub
        End If
        With FrmList
            .Text = "Edit Stock Sales"
            .frmParent = Me
            .tSelection = "Edit Sales"
            .listQuery = "Edit Sales"
            .Text = "List of Sales"
            .qryPrm = If(ST_IgnoreStoreAssignment = False, cStore.Text, "@?ALL?@")
            .ShowDialog()
        End With
        If ReturnOrderNo <> 0 Then LoadEditableOrder(ReturnOrderNo)
        Exit Sub
errhdl:
        MsgBox(Err.Description, vbCritical, strApptitle)
    End Sub
    Private Sub LoadEditableOrder(ByVal TheOrderNo As Long)
        On Error GoTo errhdl
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        flush()

        cmSQL.CommandText = "FetchSales"
        cmSQL.Parameters.AddWithValue("@OrderNo", TheOrderNo)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = True Then
            If drSQL.Read Then
                If drSQL.Item("DepositTag") > 0 Then
                    MsgBox("This order cannot be edited...Bank Deposit Transaction exist", MsgBoxStyle.Information, strApptitle)
                    'cmSQL.Connection.Close()
                    cmSQL.Dispose()
                    drSQL.Close()
                    'cnSQL.Close()
                    'cnSQL.Dispose()

                    flush()
                    lvSalesList.Items.Clear()
                    cmdNew.Enabled = True
                    cmdSave.Enabled = False
                    tItemCode.Focus()
                    ReturnOrderNo = 0
                    cmdNew.Enabled = ModuleAdd
                    Action = ModuleAdd

                    Exit Sub
                End If

                If drSQL.Item("RefundQty") > 0 Then
                    MsgBox("This order cannot be edited...Refund Transaction exist", MsgBoxStyle.Information, strApptitle)
                    'cmSQL.Connection.Close()
                    cmSQL.Dispose()
                    drSQL.Close()
                    'cnSQL.Close()
                    'cnSQL.Dispose()

                    flush()
                    lvSalesList.Items.Clear()
                    cmdNew.Enabled = True
                    cmdSave.Enabled = False
                    tItemCode.Focus()
                    ReturnOrderNo = 0
                    cmdNew.Enabled = ModuleAdd
                    Action = ModuleAdd
                    Exit Sub
                End If

                dtpDate.Text = drSQL.Item("Date")
                tDiscount.Text = drSQL.Item("Discount")
                chkDiscount.Checked = False
                tVat.Text = drSQL.Item("Vat")
                chkVAT.Checked = False
                tDetails.Text = drSQL.Item("Details")
                tOrderNo.Text = drSQL.Item("OrderNo")
                tSourceDoc.Text = drSQL.Item("Sourcedoc")
                 tPaid.Tag = drSQL.Item("AmountPaid")
                LastOrderNo = drSQL.Item("OrderNo")
            End If
        Else
            MsgBox("Order No do not exist", MsgBoxStyle.Information, strApptitle)
        End If

        drSQL.Close()
        drSQL = cmSQL.ExecuteReader()

        Dim LvItems As New ListViewItem
        Do While drSQL.Read

            If drSQL.Item("RefundQty") > 0 Then
                MsgBox("This order cannot be edited...Refund Transaction exist", MsgBoxStyle.Information, strApptitle)
                'cmSQL.Connection.Close()
                cmSQL.Dispose()
                drSQL.Close()
                'cnSQL.Close()
                'cnSQL.Dispose()

                flush()
                lvSalesList.Items.Clear()
                cmdNew.Enabled = True
                cmdSave.Enabled = False
                tItemCode.Focus()
                ReturnOrderNo = 0
                cmdNew.Enabled = ModuleAdd
                Action = ModuleAdd
                Exit Sub
            End If

            Dim j As Integer = lvSalesList.Items.Count + 1
            LvItems = New ListViewItem(j)
            LvItems.SubItems.Add(drSQL.Item("CategoryName"))
            LvItems.SubItems.Add(drSQL.Item("ProductCode"))
            LvItems.SubItems.Add(drSQL.Item("ProductName"))
            LvItems.SubItems.Add(drSQL.Item("Qty"))
            LvItems.SubItems.Add(Format(Math.Round(drSQL.Item("SellPrice"), 2), "Standard"))
            LvItems.SubItems.Add(Format(drSQL.Item("Qty") * drSQL.Item("SellPrice"), "Standard"))
            LvItems.SubItems.Add(drSQL.Item("FixedPrice"))
            LvItems.SubItems.Add(drSQL.Item("Details"))
            LvItems.SubItems.Add(drSQL.Item("SalesPerson"))
            LvItems.SubItems.Add(drSQL.Item("CostPrice"))
            LvItems.SubItems.Add(drSQL.Item("ProductDesc"))
            LvItems.SubItems.Add(drSQL.Item("Store"))
            LvItems.SubItems.Add(drSQL.Item("TransType"))
            lvSalesList.Items.AddRange(New ListViewItem() {LvItems})

            tTotalValue.Text = Format(CDbl(tTotalValue.Text) + drSQL.Item("Qty") * drSQL.Item("SellPrice"), "standard")

        Loop
        tPaid.Text = Format(Math.Round(tPaid.Tag, 2), "standard")
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()


        cmdSave.Enabled = True
        cmdNew.Enabled = False

        Exit Sub
        Resume
errhdl:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub
    Private Sub tSellPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSellPrice.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub
    Private Sub tDetails_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tDetails.KeyPress
        If e.KeyChar = Chr(13) Then cmdAccept_Click(sender, e)
    End Sub

    Private Sub chkPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrint.CheckedChanged
        PanCopies.Visible = chkPrint.Checked
        Pan.Visible = chkPrint.Checked
    End Sub

    Private Sub tPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tPaid.TextChanged
        On Error Resume Next
        If tPaid.Text = "" Then tPaid.Tag = ""
        tChange.Text = 0
        tChange.Text = Format(Math.Round(CDbl(tPaid.Text) - CDbl(tPayable.Text), 2), "standard")
        If CDbl(tChange.Text) < 0 Then tChange.Text = 0
    End Sub

    Private Sub mnuPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintInvoice.Click
        If LastOrderNo <> 0 Then Call PrintTheInvoice()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        MsgBox(Me.Width)
    End Sub
    Private Sub cInvoiceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cInvoiceType.SelectedIndexChanged
        InvoiceType = cInvoiceType.Text
    End Sub
    Private Sub cmdClosePanelPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanelPrinter.Click
        PanPrinter.Visible = False
    End Sub

    Private Sub lnkPortPrinter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPortPrinter.LinkClicked
        PanPrinter.Visible = True
    End Sub
    Private Function GetProductByName(ByVal strValue As String) As Boolean
        On Error GoTo errhdl

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        GetProductByName = False

        tProductName.Text = ""
        tCategoryName.Text = ""
        tQty.Tag = 0
        tQty.Minimum = 0
        tQty.Maximum = 0
        tQty.Value = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0
        tItemCode.Tag = ""
        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()
      
        If Trim(strValue) = "" Then Exit Function

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerProductNamePerStore"
        cmSQL.Parameters.AddWithValue("@ProductName", strValue)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
            ' MsgBox("Product not found or is out of stock", MsgBoxStyle.Information, strApptitle)
            GetProductByName = False
            tProductName.Focus()
            cmSQL.Dispose()
            drSQL.Close()

            Exit Function
        Else
            If drSQL.Read Then
                tItemCode.Text = drSQL.Item("ProductCode")
                tProductName.Text = drSQL.Item("ProductName")
                tCategoryName.Text = drSQL.Item("Category")
                tItemCode.Tag = drSQL.Item("TransType")

                'tStockLevel.Text = drSQL.Item("UnitInStock")
                'tQty.Tag = drSQL.Item("Qty")
                'tQty.Text = 1
                'tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                'tQty.Minimum = 1
                'tQty.Maximum = Val(tQty.Tag)

                tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))

                'tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                'tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                'If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                '    cFixedPrice.SelectedIndex = 0
                'Else
                '    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                '    cFixedPrice.SelectedIndex = 0
                'End If


                'If drSQL.Item("CostPriceNew") <> drSQL.Item("CostPriceOld") Then
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                '    cCostPrice.SelectedIndex = 0
                'Else
                '    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                '    cCostPrice.SelectedIndex = 0
                'End If

                'cCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)
            End If
            GetProductByName = True
        End If

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()

        GetProductDetails(tItemCode.Text)

        Exit Function
        Resume
errhdl:
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Function
    Private Sub GetProductDetails(ByVal ProductCode As String)
        On Error GoTo errhdl

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        tQty.Tag = 0

        tStockLevel.Text = 0
        tSellPrice.Text = 0
        tSellPrice.Tag = 0
        tStockLevel.Tag = 0

        cFixedPrice.Items.Clear()
        cCostPrice.Items.Clear()

        If IsNumeric(ProductCode) Then
        End If
        Dim g As Integer = InStr(ProductCode, ".00")
        If g > 0 Then
            ProductCode = Mid(ProductCode, 1, g - 1)
        End If

        If Trim(ProductCode) = "" Then Exit Sub

        cmSQL.CommandText = "FetchActiveAvailableStoreItemsPerStore"
        cmSQL.Parameters.AddWithValue("@ProductCode", ProductCode)
        cmSQL.Parameters.AddWithValue("@Store", cStore.Text)
        cmSQL.CommandType = CommandType.StoredProcedure
        ''cnSQL.Open()
        drSQL = cmSQL.ExecuteReader()

        If drSQL.HasRows = False Then
        Else
            If drSQL.Read Then
                'tItemCode.Text = drSQL.Item("ProductCode")
                'tProductName.Text = drSQL.Item("ProductName")
                'tCategoryName.Text = drSQL.Item("Category")
                'tPack.Text = drSQL.Item("Pack")
                'tItemDesc.Text = ChkNull(drSQL.Item("ProductDesc"))
                ' tStockLevel.Text = drSQL.Item("Qty")

                If tItemCode.Tag = "Service" Then
                    tQty.Tag = 1000000
                    tQty.Text = 1
                    tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                    tQty.Minimum = 1
                    tQty.Maximum = Val(tQty.Tag)
                Else
                    tQty.Tag = drSQL.Item("Qty")
                    tQty.Text = 1
                    tStockLevel.Text = Val(tQty.Tag) - Val(tQty.Text)
                    tQty.Minimum = 1
                    tQty.Maximum = Val(tQty.Tag)
                End If

                tSellPrice.Text = Math.Round(drSQL.Item("SellPriceNew"), 2)
                tSellPrice.Tag = Math.Round(drSQL.Item("SellPriceNew"), 2)

                If drSQL.Item("SellPriceNew") <> drSQL.Item("SellPriceOld") Then
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceOld"), 2))
                    cFixedPrice.SelectedIndex = 0
                Else
                    cFixedPrice.Items.Add(Math.Round(drSQL.Item("SellPriceNew"), 2))
                    cFixedPrice.SelectedIndex = 0
                End If


                If drSQL.Item("CostPriceNew") <> drSQL.Item("CostPriceOld") Then
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceOld"), 2))
                    cCostPrice.SelectedIndex = 0
                Else
                    cCostPrice.Items.Add(Math.Round(drSQL.Item("CostPriceNew"), 2))
                    cCostPrice.SelectedIndex = 0
                End If

                cCostPrice.Tag = Math.Round(drSQL.Item("CostPriceNew"), 2)
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
        If Err.Number = 5 Then

        Else
            MsgBox(Err.Description, vbInformation, strApptitle)
        End If
    End Sub

    Private Sub FillStore()
        On Error GoTo handler
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader
        cStore.Items.Clear()

        If ST_IgnoreStoreAssignment = False Then
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE INNER JOIN ASSIGNEDSTORE ON STORE.Store = ASSIGNEDSTORE.Store WHERE  NonSelling<>1  AND ASSIGNEDSTORE.UserID='" & sysUser & "'"
        Else
            cmSQL.CommandText = "SELECT STORE.Store, STORE.[Default] AS TheDefault FROM  STORE WHERE  NonSelling<>1  ORDER BY [Default] DESC"
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
    Private Sub PanPrinter_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanPrinter.MouseDown
        StoredX = e.X
        StoredY = e.Y
        PanPrinter.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanPrinter_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanPrinter.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanPrinter.Top = PanPrinter.Top - (StoredY - e.Y)
            PanPrinter.Left = PanPrinter.Left - (StoredX - e.X)
        End If
        PanPrinter.Cursor = Cursors.Default
    End Sub
    Private Sub stkFrmSales3_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Height = 550
        Me.Width = 909
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tSearchName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tSearchName.TextChanged
        ' If chkProduct = False Then Exit Sub
        If tSearchName.Text <> "" Then
            getProductList(tSearchName.Text)
            PanList.Visible = True
        Else
            'PanList.Visible = False
        End If
    End Sub

    Private Sub tSearchName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tSearchName.KeyPress
        If e.KeyChar = Chr(13) Then
            chkProduct = False
            If GetProductByName(tSearchName.Text) = False Then Exit Sub
            PanList.Visible = False
            cmdAccept_Click(sender, e)
            tItemCode.Focus()
        End If
    End Sub

    Private Sub tSearchName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tSearchName.KeyDown
        If (e.KeyCode = 38 Or e.KeyCode = 40) And DGrid.RowCount > 0 Then
            skipLostFocus = True
            DGrid.Focus()
            On Error Resume Next
            DGrid.Rows(0).Selected = True
            '  skipLostFocus = False
            'Else
            ' skipLostFocus = False
        Else
            skipLostFocus = False
        End If
        'If e.KeyCode = 13 Then
        '    tCategory.Focus()
        '    PanList.Visible = False
        'End If
    End Sub
    Private Sub tSearchName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tSearchName.LostFocus
        If skipLostFocus = False Then PanList.Visible = False
    End Sub
    Sub getProductList(ByVal strQry As String)
        On Error GoTo handler
        If strQry = "" Then Exit Sub
        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        DGrid.DataSource = Nothing
        DGrid.Rows.Clear()
        DGrid.DataSource = bindingSource

        'cnSQL.Open()
        'If radContaining.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "%' ORDER BY ProductName"
        'If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '" + strQry & "%' ORDER BY ProductName"
        'If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName LIKE '%" + strQry & "' ORDER BY ProductName"
        'If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockQty.ProductCode, StoreItems.ProductName, StoreItems.Category,StockQty.Qty,StockQty.SellPriceNew,StockQty.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockQty ON StoreItems.ProductCode = StockQty.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockQty.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND ProductName IS NOT NULL AND ProductName  = '" + strQry & "' ORDER BY ProductName"

        If radContaining.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadStartWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '" + strQry & "%' ORDER BY StoreItems.ProductName"
        If RadEndWith.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName LIKE '%" + strQry & "' ORDER BY StoreItems.ProductName"
        If RadEqual.Checked Then cmSQL.CommandText = "SELECT StockItemBalances.ProductCode, StoreItems.ProductName, StoreItems.Category,StockItemBalances.Qty,StockItemBalances.SellPriceNew,StockItemBalances.CostPriceNew,StoreItems.ProductDesc FROM StoreItems RIGHT OUTER JOIN StockItemBalances ON StoreItems.ProductCode = StockItemBalances.ProductCode WHERE Store='" & cStore.Text & "' AND ((StockItemBalances.Qty > 0 AND StoreItems.TransType='Retail') OR StoreItems.TransType='Service') AND (StoreItems.Discontinue = 0) AND StoreItems.ProductName IS NOT NULL AND StoreItems.ProductName  = '" + strQry & "' ORDER BY StoreItems.ProductName"

        cmSQL.CommandType = CommandType.Text

        dataAdapter = New SqlDataAdapter(cmSQL)
        Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource.DataSource = table

        cmSQL.Dispose()

        DGrid.Columns(1).Width = 200
        DGrid.Columns(3).Width = 40
        DGrid.Columns(4).Width = 80
        DGrid.Columns(5).Width = 80


        Dim myStyle As New DataGridViewCellStyle
        myStyle.Format = "N2"
        myStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        On Error Resume Next

        DGrid.Columns(4).DefaultCellStyle = myStyle
        DGrid.Columns(5).DefaultCellStyle = myStyle

        SkipRowEnter = True
        DGrid.Rows(0).Selected = True
        ' cnSQL.Close()
        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, vbInformation, strApptitle)
    End Sub

    Private Sub radContaining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radContaining.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadStartWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadStartWith.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadEndWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEndWith.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub RadEqual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEqual.CheckedChanged
        On Error Resume Next
        getProductList(tProductName.Text)
    End Sub
    Private Sub DGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellClick
        'If DoNotMoveNext = False Then tItemCode.Text = DGrid.Item(0, e.RowIndex).Value
        'DoNotMoveNext = False
        '   MsgBox(DGrid.Item(0, e.RowIndex).Value)
        If e.RowIndex < 0 Then
            SkipRowEnter = True

            Exit Sub
        End If

        DoNotMoveNext = True
        If Trim(tItemCode.Text) = "" Then Exit Sub
        If GetProductByCode(tItemCode.Text) = False Then Exit Sub
        cmdAccept_Click(sender, e)
        PanList.Visible = False
    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        'DoNotMoveNext = True
        'If Trim(tItemCode.Text) = "" Then Exit Sub
        'If GetProductByCode(tItemCode.Text) = False Then Exit Sub
        'cmdAccept_Click(sender, e)
        ' PanList.Visible = False
    End Sub
    Private Sub DGrid_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.RowEnter
        On Error Resume Next
        If SkipRowEnter = True Then
            SkipRowEnter = False
            Exit Sub
        End If
        tItemCode.Text = ""
        If e.RowIndex < 0 Then Exit Sub
        If DoNotMoveNext = False Then tItemCode.Text = DGrid.Item(0, e.RowIndex).Value
        DoNotMoveNext = False
    End Sub
    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        If e.KeyCode = 13 And DGrid.RowCount > 0 Then
            DoNotMoveNext = True
            ' On Error Resume Next
            '  GetProductByCode(tProductName.Tag)
            If tItemCode.Text = "" Then Exit Sub
            If GetProductByCode(tItemCode.Text) = False Then Exit Sub
            cmdAccept_Click(sender, e)
            PanList.Visible = False
            tItemCode.Focus()
        End If
    End Sub
    Private Sub cmdClosePanList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanList.Click
        PanList.Visible = False
    End Sub
    Private Sub lnkSearchProduct_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSearchProduct.LinkClicked
        skipLostFocus = True
        DoNotMoveNext = False
        tSearchName.Text = ""
        PanList.Visible = True
        tSearchName.Focus()
    End Sub

    Private Sub lvSalesList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSalesList.DoubleClick
        On Error GoTo errhdl
        If MsgBox("The Selected Transaction would be removed" + Chr(13) + "Continue (y/n)?", vbYesNo + vbCritical) = vbYes Then
            tTotalValue.Text = tTotalValue.Text - (Val(lvSalesList.SelectedItems(0).SubItems(4).Text) * Val(lvSalesList.SelectedItems(0).SubItems(6).Text))
            lvSalesList.Items.RemoveAt(lvSalesList.SelectedItems(0).Text - 1)
            Dim i As Integer = 0
            For i = 0 To lvSalesList.Items.Count - 1
                lvSalesList.Items(i).Text = i + 1
            Next
            calculatePayable()
        End If
        Exit Sub
errhdl:
        If Err.Description Like "*InvalidArgument=Value of*" Then
            MsgBox("Please select from the list", MsgBoxStyle.Information, strApptitle)
        Else
            MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
        End If
    End Sub
    Private Sub PanList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanList.MouseDown
        Stored1X = e.X
        Stored1Y = e.Y
        PanList.Cursor = Cursors.NoMove2D
    End Sub
    Private Sub PanList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanList.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PanList.Top = PanList.Top - (Stored1Y - e.Y)
            PanList.Left = PanList.Left - (Stored1X - e.X)
        End If
        PanList.Cursor = Cursors.Default
    End Sub
    Private Sub cmdClearPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPayment.Click
        tPaid.Text = 0
        tPaid.Tag = ""
    End Sub
    Private Sub btnClick(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cmd1.Click
        On Error Resume Next
        Dim ClickedButton As Button = DirectCast(sender, Button)
        Dim a As Integer = InStr(1, tPaid.Text, ".")
        Dim Naira, Kobo As Long
        If a = 0 Then
            Naira = Int(tPaid.Text)
        ElseIf a = 1 Then
            Naira = 0
            Kobo = Int(Mid(tPaid.Text, a + 1))
        Else
            Naira = Int(Mid(tPaid.Text, 1, a - 1))
            Kobo = Int(Mid(tPaid.Text, a + 1))
        End If

        If tPaid.Tag <> "Dot" Then
            tPaid.Text = IIf(Naira <= 0, "", Naira.ToString) + ClickedButton.Text + "." + Kobo.ToString
        Else
            ' "1"
            If Kobo = 0 Then
                tPaid.Text = Naira.ToString + "." + ClickedButton.Text
            ElseIf Len(Trim(Kobo)) = 1 And Kobo > 0 Then
                tPaid.Text = Naira.ToString + "." + Kobo.ToString + ClickedButton.Text
            ElseIf Len(Trim(Kobo)) = 2 And Kobo > 0 Then
                If Val(Mid(Kobo.ToString, 2, 1)) = 0 Then
                    tPaid.Text = Naira.ToString + "." + Mid(Kobo.ToString, 1, 1) + ClickedButton.Text
                Else
                    tPaid.Text = Naira.ToString + "." + Mid(Kobo.ToString, 2, 1) + ClickedButton.Text
                End If

            End If

        End If

        If IsNumeric(tPaid.Text) Then tPaid.Text = Format(tPaid.Text, "standard")

    End Sub
    Private Sub cmdDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDot.Click
        tPaid.Tag = "Dot"
        If InStr(1, tPaid.Text, ".") = 0 Then tPaid.Text = IIf(Val(tPaid.Text) = 0, "", tPaid.Text) + ".00"
    End Sub

    Private Sub cStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cStore.SelectedIndexChanged
        If ST_IgnoreStoreAssignment = False Then
            If lvSalesList.Items.Count > 0 And cStore.Text <> SelectedStore Then
                If MsgBox("Content of the list would be deleted" + Chr(13) + "Continue...(y/n)", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, strApptitle) = MsgBoxResult.No Then
                    cStore.Text = SelectedStore
                    Exit Sub
                Else
                    cmdClearAll_Click(sender, e)
                End If
            End If
        End If

        SelectedStore = cStore.Text
    End Sub
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If Len(tPaid.Text) <= 1 Then
            tPaid.Text = ""
            tPaid.Tag = ""
        Else
            tPaid.Text = Mid(tPaid.Text, 1, Len(tPaid.Text) - 1)
            If InStr(tPaid.Text, ".") = 0 Then tPaid.Tag = ""
        End If
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        PrintTheInvoice()
    End Sub

    Private Sub LoadPrinters()
        On Error GoTo handler
        'Let's clear our comboboxes to start fresh.
        cboNetworkPrinters.Items.Clear()
        cboLocalPrinters.Items.Clear()

        'We use the ObjectQuery to get the list of configured printers
        Dim oquery As New System.Management.ObjectQuery("SELECT * FROM Win32_Printer")
        Dim mosearcher As New System.Management.ManagementObjectSearcher(oquery)
        Dim moc As System.Management.ManagementObjectCollection = mosearcher.[Get]()

        'If at least one printer is found, we add it to a specific list and enable the Print button.
        If moc IsNot Nothing AndAlso moc.Count > 0 Then
            'For each printer found, we put it either in the local or network combobox, accordingly.
            For Each mo As ManagementObject In moc
                Dim network As Boolean = False
                Dim ipAddress As String() = mo("PortName").ToString().Split("."c)

                'It's a network printer.
                If mo("PortName") IsNot Nothing AndAlso ipAddress.Length = 4 Then
                    cboNetworkPrinters.Items.Add(mo("Name").ToString())
                    network = True
                Else
                    'It's a local printer.
                    cboLocalPrinters.Items.Add(mo("Name").ToString())
                End If

                'If the printer is found to be the default one, we select it.
                If CBool(mo("Default")) Then
                    If network Then
                        cboNetworkPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = True
                    Else
                        cboLocalPrinters.SelectedItem = mo("Name").ToString()
                        defaultNetwork = False
                    End If

                    'lblNameValue.Text = mo("Name").ToString()
                    'lblPortValue.Text = mo("PortName").ToString()
                    'lblDriverValue.Text = mo("DriverName").ToString()
                    'lblDeviceIDValue.Text = mo("DeviceID").ToString()
                    'lblSharedValue.Text = mo("Shared").ToString()
                End If
            Next



        End If

        Exit Sub
handler:
        MsgBox("Problem Loading Default Printer", vbInformation, strApptitle)
    End Sub
    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Static MyNewAcctFile As String = IO.File.ReadAllText(AppPath + IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt"))
        Dim printFont As New Font("Arial", 9, FontStyle.Regular)
        Dim charsFitted As Integer
        Dim linesFilled As Integer
        e.Graphics.MeasureString(MyNewAcctFile, printFont, New SizeF(e.MarginBounds.Width, e.MarginBounds.Height), Drawing.StringFormat.GenericTypographic, charsFitted, linesFilled)
        e.Graphics.DrawString(MyNewAcctFile, printFont, Brushes.Black, e.MarginBounds, Drawing.StringFormat.GenericTypographic)

        MyNewAcctFile = MyNewAcctFile.Substring(charsFitted)

        If MyNewAcctFile <> "" Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            MyNewAcctFile = IO.File.ReadAllText(AppPath + IIf(Microsoft.VisualBasic.Right(AppPath, 1) = "\", "InvoiceFile.txt", "\InvoiceFile.txt"))
        End If

    End Sub

End Class

