<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StkFrmSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StkFrmSales))
        Me.lvSalesList = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.tblHeader = New System.Windows.Forms.TableLayoutPanel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdAccept = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tQty = New System.Windows.Forms.NumericUpDown
        Me.tDetails = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cSalesPerson = New System.Windows.Forms.ComboBox
        Me.cCostPrice = New System.Windows.Forms.ComboBox
        Me.tCostPrice = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tSourceDoc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tOrderNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdSalesPerson = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cFixedPrice = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tSellPrice = New System.Windows.Forms.TextBox
        Me.tStockLevel = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tCategoryName = New System.Windows.Forms.TextBox
        Me.tProductName = New System.Windows.Forms.TextBox
        Me.tItemCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.TblProduct = New System.Windows.Forms.TableLayoutPanel
        Me.lvProduct = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmdFind = New System.Windows.Forms.Button
        Me.tFind = New System.Windows.Forms.TextBox
        Me.lvCategory = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cmdClose = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdCustomer = New System.Windows.Forms.Button
        Me.cmdFetchCustomer = New System.Windows.Forms.Button
        Me.tCustomerName = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.tCustomerCode = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.chkReceipt = New System.Windows.Forms.CheckBox
        Me.PanCopies = New System.Windows.Forms.Panel
        Me.tCopies = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.mnuEdit = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cPole = New System.Windows.Forms.ComboBox
        Me.cPOS = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkGiveChange = New System.Windows.Forms.CheckBox
        Me.tChange = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.tReceiptNo = New System.Windows.Forms.TextBox
        Me.PanPayType = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.tPayDetails = New System.Windows.Forms.TextBox
        Me.RadOthers = New System.Windows.Forms.RadioButton
        Me.RadCheque = New System.Windows.Forms.RadioButton
        Me.RadCash = New System.Windows.Forms.RadioButton
        Me.Label21 = New System.Windows.Forms.Label
        Me.tPaid = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.chkDiscount = New System.Windows.Forms.CheckBox
        Me.chkVAT = New System.Windows.Forms.CheckBox
        Me.tPayable = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.tDiscount = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.tVat = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.tTotalValue = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.mnuPntInvoice = New System.Windows.Forms.MenuStrip
        Me.mnuPrintInvoice = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.cmdEnquiry = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.PanCommands = New System.Windows.Forms.Panel
        Me.CmdCut = New System.Windows.Forms.Button
        Me.CmdOpen = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdNew = New System.Windows.Forms.Button
        Me.chkCategory = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pan = New System.Windows.Forms.Panel
        Me.cInvoiceType = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.tblHeader.SuspendLayout()
        Me.tblMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblProduct.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.PanCopies.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.PanPayType.SuspendLayout()
        Me.mnuPntInvoice.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanCommands.SuspendLayout()
        Me.Pan.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvSalesList
        '
        Me.lvSalesList.BackColor = System.Drawing.Color.LightCyan
        Me.lvSalesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader18, Me.ColumnHeader5})
        Me.tblMain.SetColumnSpan(Me.lvSalesList, 2)
        Me.lvSalesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSalesList.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSalesList.FullRowSelect = True
        Me.lvSalesList.GridLines = True
        Me.lvSalesList.Location = New System.Drawing.Point(480, 423)
        Me.lvSalesList.Margin = New System.Windows.Forms.Padding(1, 3, 2, 0)
        Me.lvSalesList.MultiSelect = False
        Me.lvSalesList.Name = "lvSalesList"
        Me.lvSalesList.Size = New System.Drawing.Size(543, 223)
        Me.lvSalesList.TabIndex = 266
        Me.lvSalesList.UseCompatibleStateImageBehavior = False
        Me.lvSalesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Sn"
        Me.ColumnHeader7.Width = 28
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "CategoryCode"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "CategoryName"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ProductCode"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "ProductName"
        Me.ColumnHeader11.Width = 243
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Qty"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader12.Width = 48
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Sell Price"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 81
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Value"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 73
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Fixed Price"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Details"
        Me.ColumnHeader16.Width = 0
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Sales Person"
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CostPrice"
        Me.ColumnHeader5.Width = 0
        '
        'tblHeader
        '
        Me.tblHeader.BackColor = System.Drawing.Color.MintCream
        Me.tblHeader.ColumnCount = 1
        Me.tblMain.SetColumnSpan(Me.tblHeader, 3)
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblHeader.Controls.Add(Me.Label7, 0, 0)
        Me.tblHeader.Controls.Add(Me.Label8, 0, 1)
        Me.tblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHeader.Location = New System.Drawing.Point(0, 0)
        Me.tblHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.tblHeader.Name = "tblHeader"
        Me.tblHeader.RowCount = 2
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.76923!))
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.23077!))
        Me.tblHeader.Size = New System.Drawing.Size(1025, 50)
        Me.tblHeader.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.GhostWhite
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1025, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Sales"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Segoe Print", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 27)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1025, 23)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tblMain
        '
        Me.tblMain.ColumnCount = 3
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 479.0!))
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Controls.Add(Me.tblHeader, 0, 0)
        Me.tblMain.Controls.Add(Me.lvSalesList, 1, 3)
        Me.tblMain.Controls.Add(Me.Panel2, 1, 1)
        Me.tblMain.Controls.Add(Me.TblProduct, 0, 1)
        Me.tblMain.Controls.Add(Me.Panel4, 2, 1)
        Me.tblMain.Controls.Add(Me.Panel3, 1, 2)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Margin = New System.Windows.Forms.Padding(1, 1, 1, 3)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 4
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Size = New System.Drawing.Size(1025, 646)
        Me.tblMain.TabIndex = 267
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Controls.Add(Me.cmdAccept)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.cmdClearAll)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(480, 53)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 295)
        Me.Panel2.TabIndex = 0
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(148, 6)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 556
        '
        'cmdAccept
        '
        Me.cmdAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAccept.Location = New System.Drawing.Point(164, 260)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(85, 28)
        Me.cmdAccept.TabIndex = 553
        Me.cmdAccept.Text = "Accept"
        Me.cmdAccept.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tQty)
        Me.GroupBox1.Controls.Add(Me.tDetails)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cSalesPerson)
        Me.GroupBox1.Controls.Add(Me.cCostPrice)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tSourceDoc)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.tOrderNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmdSalesPerson)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cFixedPrice)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tSellPrice)
        Me.GroupBox1.Controls.Add(Me.tStockLevel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tCategoryName)
        Me.GroupBox1.Controls.Add(Me.tProductName)
        Me.GroupBox1.Controls.Add(Me.tItemCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.tCostPrice)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(249, 232)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "STOCK ITEM"
        '
        'tQty
        '
        Me.tQty.Location = New System.Drawing.Point(57, 110)
        Me.tQty.Name = "tQty"
        Me.tQty.Size = New System.Drawing.Size(57, 20)
        Me.tQty.TabIndex = 561
        '
        'tDetails
        '
        Me.tDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDetails.Location = New System.Drawing.Point(57, 156)
        Me.tDetails.Name = "tDetails"
        Me.tDetails.Size = New System.Drawing.Size(187, 20)
        Me.tDetails.TabIndex = 29
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdClear.Location = New System.Drawing.Point(169, 200)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(72, 28)
        Me.cmdClear.TabIndex = 554
        Me.cmdClear.Text = "Cancel Order"
        Me.cmdClear.UseVisualStyleBackColor = True
        Me.cmdClear.Visible = False
        '
        'cSalesPerson
        '
        Me.cSalesPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSalesPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cSalesPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSalesPerson.FormattingEnabled = True
        Me.cSalesPerson.Location = New System.Drawing.Point(58, 178)
        Me.cSalesPerson.Name = "cSalesPerson"
        Me.cSalesPerson.Size = New System.Drawing.Size(148, 20)
        Me.cSalesPerson.TabIndex = 30
        '
        'cCostPrice
        '
        Me.cCostPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cCostPrice.ForeColor = System.Drawing.Color.Black
        Me.cCostPrice.FormattingEnabled = True
        Me.cCostPrice.Location = New System.Drawing.Point(58, 202)
        Me.cCostPrice.Name = "cCostPrice"
        Me.cCostPrice.Size = New System.Drawing.Size(68, 20)
        Me.cCostPrice.TabIndex = 559
        Me.cCostPrice.TabStop = False
        Me.cCostPrice.Visible = False
        '
        'tCostPrice
        '
        Me.tCostPrice.AutoSize = True
        Me.tCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCostPrice.Location = New System.Drawing.Point(3, 208)
        Me.tCostPrice.Name = "tCostPrice"
        Me.tCostPrice.Size = New System.Drawing.Size(57, 13)
        Me.tCostPrice.TabIndex = 560
        Me.tCostPrice.Text = "Cost Price:"
        Me.tCostPrice.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(5, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(238, 8)
        Me.GroupBox2.TabIndex = 558
        Me.GroupBox2.TabStop = False
        '
        'tSourceDoc
        '
        Me.tSourceDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSourceDoc.Location = New System.Drawing.Point(197, 14)
        Me.tSourceDoc.Name = "tSourceDoc"
        Me.tSourceDoc.Size = New System.Drawing.Size(45, 18)
        Me.tSourceDoc.TabIndex = 557
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(116, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 556
        Me.Label11.Text = "Source Doc No:"
        '
        'tOrderNo
        '
        Me.tOrderNo.BackColor = System.Drawing.Color.Lavender
        Me.tOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOrderNo.ForeColor = System.Drawing.Color.Maroon
        Me.tOrderNo.Location = New System.Drawing.Point(56, 14)
        Me.tOrderNo.Name = "tOrderNo"
        Me.tOrderNo.ReadOnly = True
        Me.tOrderNo.Size = New System.Drawing.Size(58, 18)
        Me.tOrderNo.TabIndex = 555
        Me.tOrderNo.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(4, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 554
        Me.Label10.Text = "Order No:"
        '
        'cmdSalesPerson
        '
        Me.cmdSalesPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalesPerson.Location = New System.Drawing.Point(207, 176)
        Me.cmdSalesPerson.Name = "cmdSalesPerson"
        Me.cmdSalesPerson.Size = New System.Drawing.Size(38, 24)
        Me.cmdSalesPerson.TabIndex = 552
        Me.cmdSalesPerson.Text = "New"
        Me.cmdSalesPerson.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Details:"
        '
        'cFixedPrice
        '
        Me.cFixedPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cFixedPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cFixedPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cFixedPrice.FormattingEnabled = True
        Me.cFixedPrice.Location = New System.Drawing.Point(176, 132)
        Me.cFixedPrice.Name = "cFixedPrice"
        Me.cFixedPrice.Size = New System.Drawing.Size(68, 20)
        Me.cFixedPrice.TabIndex = 26
        Me.cFixedPrice.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Sell Price:"
        '
        'tSellPrice
        '
        Me.tSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSellPrice.Location = New System.Drawing.Point(57, 133)
        Me.tSellPrice.Name = "tSellPrice"
        Me.tSellPrice.Size = New System.Drawing.Size(60, 20)
        Me.tSellPrice.TabIndex = 11
        '
        'tStockLevel
        '
        Me.tStockLevel.BackColor = System.Drawing.Color.Lavender
        Me.tStockLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStockLevel.Location = New System.Drawing.Point(192, 110)
        Me.tStockLevel.Name = "tStockLevel"
        Me.tStockLevel.ReadOnly = True
        Me.tStockLevel.Size = New System.Drawing.Size(51, 20)
        Me.tStockLevel.TabIndex = 9
        Me.tStockLevel.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Qty:"
        '
        'tCategoryName
        '
        Me.tCategoryName.BackColor = System.Drawing.Color.Lavender
        Me.tCategoryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCategoryName.Location = New System.Drawing.Point(4, 42)
        Me.tCategoryName.Name = "tCategoryName"
        Me.tCategoryName.ReadOnly = True
        Me.tCategoryName.Size = New System.Drawing.Size(240, 20)
        Me.tCategoryName.TabIndex = 5
        Me.tCategoryName.TabStop = False
        Me.tCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tCategoryName, "Category")
        '
        'tProductName
        '
        Me.tProductName.BackColor = System.Drawing.Color.Lavender
        Me.tProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tProductName.Location = New System.Drawing.Point(4, 64)
        Me.tProductName.Name = "tProductName"
        Me.tProductName.ReadOnly = True
        Me.tProductName.Size = New System.Drawing.Size(240, 20)
        Me.tProductName.TabIndex = 3
        Me.tProductName.TabStop = False
        Me.tProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tProductName, "Item name")
        '
        'tItemCode
        '
        Me.tItemCode.AllowDrop = True
        Me.tItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tItemCode.Location = New System.Drawing.Point(57, 87)
        Me.tItemCode.Name = "tItemCode"
        Me.tItemCode.Size = New System.Drawing.Size(187, 20)
        Me.tItemCode.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(117, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Stock Level:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(118, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Fixed Price:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Itemcode :"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 28)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Sales Person:"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cmdClearAll.ForeColor = System.Drawing.Color.Maroon
        Me.cmdClearAll.Location = New System.Drawing.Point(6, 260)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(80, 28)
        Me.cmdClearAll.TabIndex = 557
        Me.cmdClearAll.Text = "Cancel Order"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'TblProduct
        '
        Me.TblProduct.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TblProduct.ColumnCount = 2
        Me.TblProduct.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TblProduct.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TblProduct.Controls.Add(Me.lvProduct, 1, 1)
        Me.TblProduct.Controls.Add(Me.Panel1, 1, 0)
        Me.TblProduct.Controls.Add(Me.lvCategory, 0, 0)
        Me.TblProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TblProduct.Location = New System.Drawing.Point(1, 53)
        Me.TblProduct.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.TblProduct.Name = "TblProduct"
        Me.TblProduct.RowCount = 2
        Me.tblMain.SetRowSpan(Me.TblProduct, 3)
        Me.TblProduct.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TblProduct.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TblProduct.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TblProduct.Size = New System.Drawing.Size(477, 590)
        Me.TblProduct.TabIndex = 266
        '
        'lvProduct
        '
        Me.lvProduct.BackColor = System.Drawing.Color.LightCyan
        Me.lvProduct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProduct.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProduct.FullRowSelect = True
        Me.lvProduct.GridLines = True
        Me.lvProduct.HideSelection = False
        Me.lvProduct.Location = New System.Drawing.Point(220, 46)
        Me.lvProduct.Margin = New System.Windows.Forms.Padding(1, 3, 2, 0)
        Me.lvProduct.MultiSelect = False
        Me.lvProduct.Name = "lvProduct"
        Me.lvProduct.Size = New System.Drawing.Size(252, 541)
        Me.lvProduct.TabIndex = 265
        Me.lvProduct.UseCompatibleStateImageBehavior = False
        Me.lvProduct.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Code"
        Me.ColumnHeader1.Width = 48
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 182
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.CmdFind)
        Me.Panel1.Controls.Add(Me.tFind)
        Me.Panel1.Location = New System.Drawing.Point(222, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 31)
        Me.Panel1.TabIndex = 266
        '
        'CmdFind
        '
        Me.CmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFind.Image = Global.Cupid.My.Resources.Resources.FIND
        Me.CmdFind.Location = New System.Drawing.Point(218, 4)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(30, 24)
        Me.CmdFind.TabIndex = 551
        Me.CmdFind.UseVisualStyleBackColor = True
        '
        'tFind
        '
        Me.tFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFind.Location = New System.Drawing.Point(5, 5)
        Me.tFind.Name = "tFind"
        Me.tFind.Size = New System.Drawing.Size(206, 20)
        Me.tFind.TabIndex = 1
        '
        'lvCategory
        '
        Me.lvCategory.BackColor = System.Drawing.Color.LightCyan
        Me.lvCategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCategory.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCategory.FullRowSelect = True
        Me.lvCategory.GridLines = True
        Me.lvCategory.HideSelection = False
        Me.lvCategory.Location = New System.Drawing.Point(6, 6)
        Me.lvCategory.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.lvCategory.MultiSelect = False
        Me.lvCategory.Name = "lvCategory"
        Me.TblProduct.SetRowSpan(Me.lvCategory, 2)
        Me.lvCategory.Size = New System.Drawing.Size(210, 578)
        Me.lvCategory.TabIndex = 265
        Me.lvCategory.UseCompatibleStateImageBehavior = False
        Me.lvCategory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Code"
        Me.ColumnHeader3.Width = 42
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Description"
        Me.ColumnHeader4.Width = 150
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmdClose)
        Me.Panel4.Controls.Add(Me.GroupBox4)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Controls.Add(Me.mnuPntInvoice)
        Me.Panel4.Location = New System.Drawing.Point(742, 53)
        Me.Panel4.Name = "Panel4"
        Me.tblMain.SetRowSpan(Me.Panel4, 2)
        Me.Panel4.Size = New System.Drawing.Size(279, 363)
        Me.Panel4.TabIndex = 2
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(4, 330)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(234, 28)
        Me.cmdClose.TabIndex = 558
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdCustomer)
        Me.GroupBox4.Controls.Add(Me.cmdFetchCustomer)
        Me.GroupBox4.Controls.Add(Me.tCustomerName)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.tCustomerCode)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 270)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(234, 56)
        Me.GroupBox4.TabIndex = 557
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CUSTOMER INFORMATION"
        '
        'cmdCustomer
        '
        Me.cmdCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustomer.Location = New System.Drawing.Point(174, 10)
        Me.cmdCustomer.Name = "cmdCustomer"
        Me.cmdCustomer.Size = New System.Drawing.Size(38, 24)
        Me.cmdCustomer.TabIndex = 554
        Me.cmdCustomer.Text = "New"
        Me.cmdCustomer.UseVisualStyleBackColor = True
        '
        'cmdFetchCustomer
        '
        Me.cmdFetchCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFetchCustomer.Location = New System.Drawing.Point(148, 10)
        Me.cmdFetchCustomer.Name = "cmdFetchCustomer"
        Me.cmdFetchCustomer.Size = New System.Drawing.Size(26, 24)
        Me.cmdFetchCustomer.TabIndex = 553
        Me.cmdFetchCustomer.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdFetchCustomer, "Get Customer")
        Me.cmdFetchCustomer.UseVisualStyleBackColor = True
        '
        'tCustomerName
        '
        Me.tCustomerName.BackColor = System.Drawing.Color.Lavender
        Me.tCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCustomerName.Location = New System.Drawing.Point(50, 34)
        Me.tCustomerName.Name = "tCustomerName"
        Me.tCustomerName.ReadOnly = True
        Me.tCustomerName.Size = New System.Drawing.Size(180, 18)
        Me.tCustomerName.TabIndex = 6
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Name:"
        '
        'tCustomerCode
        '
        Me.tCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCustomerCode.Location = New System.Drawing.Point(50, 14)
        Me.tCustomerCode.Name = "tCustomerCode"
        Me.tCustomerCode.Size = New System.Drawing.Size(98, 18)
        Me.tCustomerCode.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(2, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 13)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Code:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.chkReceipt)
        Me.Panel5.Controls.Add(Me.PanCopies)
        Me.Panel5.Controls.Add(Me.chkPrint)
        Me.Panel5.Controls.Add(Me.mnuEdit)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.cPole)
        Me.Panel5.Controls.Add(Me.cPOS)
        Me.Panel5.Location = New System.Drawing.Point(1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(268, 52)
        Me.Panel5.TabIndex = 3
        '
        'chkReceipt
        '
        Me.chkReceipt.AutoSize = True
        Me.chkReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReceipt.ForeColor = System.Drawing.Color.Maroon
        Me.chkReceipt.Location = New System.Drawing.Point(212, 4)
        Me.chkReceipt.Name = "chkReceipt"
        Me.chkReceipt.Size = New System.Drawing.Size(61, 17)
        Me.chkReceipt.TabIndex = 557
        Me.chkReceipt.Text = "Receipt"
        Me.chkReceipt.UseVisualStyleBackColor = True
        '
        'PanCopies
        '
        Me.PanCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanCopies.Controls.Add(Me.tCopies)
        Me.PanCopies.Controls.Add(Me.Label27)
        Me.PanCopies.Location = New System.Drawing.Point(133, 22)
        Me.PanCopies.Name = "PanCopies"
        Me.PanCopies.Size = New System.Drawing.Size(51, 22)
        Me.PanCopies.TabIndex = 556
        '
        'tCopies
        '
        Me.tCopies.BackColor = System.Drawing.Color.White
        Me.tCopies.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCopies.Location = New System.Drawing.Point(32, 1)
        Me.tCopies.Name = "tCopies"
        Me.tCopies.Size = New System.Drawing.Size(16, 18)
        Me.tCopies.TabIndex = 9
        Me.tCopies.Text = "1"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(0, 4)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 12)
        Me.Label27.TabIndex = 31
        Me.Label27.Text = "Copies"
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrint.ForeColor = System.Drawing.Color.Maroon
        Me.chkPrint.Location = New System.Drawing.Point(132, 4)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(84, 17)
        Me.chkPrint.TabIndex = 555
        Me.chkPrint.Text = "Print Invoice"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'mnuEdit
        '
        Me.mnuEdit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.mnuEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.mnuEdit.Location = New System.Drawing.Point(198, 23)
        Me.mnuEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(52, 27)
        Me.mnuEdit.TabIndex = 2
        Me.mnuEdit.Text = "&Edit"
        Me.mnuEdit.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Pole Port: "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "POS Printer: "
        '
        'cPole
        '
        Me.cPole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cPole.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cPole.FormattingEnabled = True
        Me.cPole.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3", "LPT4"})
        Me.cPole.Location = New System.Drawing.Point(72, 24)
        Me.cPole.Name = "cPole"
        Me.cPole.Size = New System.Drawing.Size(54, 20)
        Me.cPole.TabIndex = 28
        '
        'cPOS
        '
        Me.cPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cPOS.FormattingEnabled = True
        Me.cPOS.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3", "LPT4"})
        Me.cPOS.Location = New System.Drawing.Point(72, 2)
        Me.cPOS.Name = "cPOS"
        Me.cPOS.Size = New System.Drawing.Size(54, 20)
        Me.cPOS.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.tReceiptNo)
        Me.GroupBox3.Controls.Add(Me.PanPayType)
        Me.GroupBox3.Controls.Add(Me.RadOthers)
        Me.GroupBox3.Controls.Add(Me.RadCheque)
        Me.GroupBox3.Controls.Add(Me.RadCash)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.tPaid)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.chkDiscount)
        Me.GroupBox3.Controls.Add(Me.chkVAT)
        Me.GroupBox3.Controls.Add(Me.tPayable)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.tDiscount)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.tVat)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.tTotalValue)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(2, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(268, 210)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "FINANCIALS"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkGiveChange)
        Me.GroupBox5.Controls.Add(Me.tChange)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(170, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(91, 86)
        Me.GroupBox5.TabIndex = 566
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Get Change"
        '
        'chkGiveChange
        '
        Me.chkGiveChange.AutoSize = True
        Me.chkGiveChange.Checked = True
        Me.chkGiveChange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGiveChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGiveChange.ForeColor = System.Drawing.Color.Maroon
        Me.chkGiveChange.Location = New System.Drawing.Point(9, 58)
        Me.chkGiveChange.Name = "chkGiveChange"
        Me.chkGiveChange.Size = New System.Drawing.Size(78, 16)
        Me.chkGiveChange.TabIndex = 564
        Me.chkGiveChange.Text = "Give Change"
        Me.chkGiveChange.UseVisualStyleBackColor = True
        '
        'tChange
        '
        Me.tChange.BackColor = System.Drawing.Color.Lavender
        Me.tChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tChange.ForeColor = System.Drawing.Color.Maroon
        Me.tChange.Location = New System.Drawing.Point(4, 33)
        Me.tChange.Name = "tChange"
        Me.tChange.ReadOnly = True
        Me.tChange.Size = New System.Drawing.Size(79, 21)
        Me.tChange.TabIndex = 563
        Me.tChange.TabStop = False
        Me.tChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(47, 13)
        Me.Label29.TabIndex = 562
        Me.Label29.Text = "Change:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(118, 144)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(114, 13)
        Me.Label26.TabIndex = 565
        Me.Label26.Text = "from Previous payment"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 147)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 564
        Me.Label25.Text = "Receipt No:"
        '
        'tReceiptNo
        '
        Me.tReceiptNo.BackColor = System.Drawing.Color.White
        Me.tReceiptNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tReceiptNo.Location = New System.Drawing.Point(70, 141)
        Me.tReceiptNo.Name = "tReceiptNo"
        Me.tReceiptNo.Size = New System.Drawing.Size(44, 20)
        Me.tReceiptNo.TabIndex = 563
        '
        'PanPayType
        '
        Me.PanPayType.Controls.Add(Me.Label22)
        Me.PanPayType.Controls.Add(Me.tPayDetails)
        Me.PanPayType.Location = New System.Drawing.Point(4, 180)
        Me.PanPayType.Name = "PanPayType"
        Me.PanPayType.Size = New System.Drawing.Size(231, 26)
        Me.PanPayType.TabIndex = 562
        Me.PanPayType.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(2, 7)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 13)
        Me.Label22.TabIndex = 560
        Me.Label22.Text = "Details:"
        '
        'tPayDetails
        '
        Me.tPayDetails.BackColor = System.Drawing.Color.White
        Me.tPayDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPayDetails.Location = New System.Drawing.Point(66, 4)
        Me.tPayDetails.Name = "tPayDetails"
        Me.tPayDetails.Size = New System.Drawing.Size(162, 18)
        Me.tPayDetails.TabIndex = 559
        '
        'RadOthers
        '
        Me.RadOthers.AutoSize = True
        Me.RadOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadOthers.Location = New System.Drawing.Point(179, 162)
        Me.RadOthers.Name = "RadOthers"
        Me.RadOthers.Size = New System.Drawing.Size(56, 17)
        Me.RadOthers.TabIndex = 561
        Me.RadOthers.Text = "Others"
        Me.RadOthers.UseVisualStyleBackColor = True
        '
        'RadCheque
        '
        Me.RadCheque.AutoSize = True
        Me.RadCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCheque.Location = New System.Drawing.Point(117, 162)
        Me.RadCheque.Name = "RadCheque"
        Me.RadCheque.Size = New System.Drawing.Size(62, 17)
        Me.RadCheque.TabIndex = 560
        Me.RadCheque.Text = "Cheque"
        Me.RadCheque.UseVisualStyleBackColor = True
        '
        'RadCash
        '
        Me.RadCash.AutoSize = True
        Me.RadCash.Checked = True
        Me.RadCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCash.Location = New System.Drawing.Point(69, 162)
        Me.RadCash.Name = "RadCash"
        Me.RadCash.Size = New System.Drawing.Size(49, 17)
        Me.RadCash.TabIndex = 559
        Me.RadCash.TabStop = True
        Me.RadCash.Text = "Cash"
        Me.RadCash.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 124)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 558
        Me.Label21.Text = "Paid:"
        '
        'tPaid
        '
        Me.tPaid.BackColor = System.Drawing.Color.White
        Me.tPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPaid.Location = New System.Drawing.Point(70, 118)
        Me.tPaid.Name = "tPaid"
        Me.tPaid.Size = New System.Drawing.Size(86, 20)
        Me.tPaid.TabIndex = 557
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 106)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 556
        Me.Label20.Text = "PAYMENT"
        '
        'chkDiscount
        '
        Me.chkDiscount.AutoSize = True
        Me.chkDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscount.ForeColor = System.Drawing.Color.Maroon
        Me.chkDiscount.Location = New System.Drawing.Point(131, 63)
        Me.chkDiscount.Name = "chkDiscount"
        Me.chkDiscount.Size = New System.Drawing.Size(35, 17)
        Me.chkDiscount.TabIndex = 555
        Me.chkDiscount.Text = "%"
        Me.chkDiscount.UseVisualStyleBackColor = True
        '
        'chkVAT
        '
        Me.chkVAT.AutoSize = True
        Me.chkVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVAT.ForeColor = System.Drawing.Color.Maroon
        Me.chkVAT.Location = New System.Drawing.Point(131, 41)
        Me.chkVAT.Name = "chkVAT"
        Me.chkVAT.Size = New System.Drawing.Size(35, 17)
        Me.chkVAT.TabIndex = 554
        Me.chkVAT.Text = "%"
        Me.chkVAT.UseVisualStyleBackColor = True
        '
        'tPayable
        '
        Me.tPayable.BackColor = System.Drawing.Color.Black
        Me.tPayable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPayable.ForeColor = System.Drawing.Color.White
        Me.tPayable.Location = New System.Drawing.Point(69, 84)
        Me.tPayable.Name = "tPayable"
        Me.tPayable.ReadOnly = True
        Me.tPayable.Size = New System.Drawing.Size(88, 21)
        Me.tPayable.TabIndex = 10
        Me.tPayable.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Payable:"
        '
        'tDiscount
        '
        Me.tDiscount.BackColor = System.Drawing.Color.White
        Me.tDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDiscount.Location = New System.Drawing.Point(70, 62)
        Me.tDiscount.Name = "tDiscount"
        Me.tDiscount.Size = New System.Drawing.Size(58, 18)
        Me.tDiscount.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Discount:"
        '
        'tVat
        '
        Me.tVat.BackColor = System.Drawing.Color.White
        Me.tVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tVat.Location = New System.Drawing.Point(70, 40)
        Me.tVat.Name = "tVat"
        Me.tVat.Size = New System.Drawing.Size(58, 18)
        Me.tVat.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "VAT:"
        '
        'tTotalValue
        '
        Me.tTotalValue.BackColor = System.Drawing.Color.Lavender
        Me.tTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTotalValue.Location = New System.Drawing.Point(69, 19)
        Me.tTotalValue.Name = "tTotalValue"
        Me.tTotalValue.ReadOnly = True
        Me.tTotalValue.Size = New System.Drawing.Size(85, 18)
        Me.tTotalValue.TabIndex = 4
        Me.tTotalValue.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Total Value:"
        '
        'mnuPntInvoice
        '
        Me.mnuPntInvoice.Dock = System.Windows.Forms.DockStyle.None
        Me.mnuPntInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintInvoice})
        Me.mnuPntInvoice.Location = New System.Drawing.Point(48, 335)
        Me.mnuPntInvoice.Name = "mnuPntInvoice"
        Me.mnuPntInvoice.Size = New System.Drawing.Size(93, 24)
        Me.mnuPntInvoice.TabIndex = 557
        Me.mnuPntInvoice.Text = "MenuStrip1"
        '
        'mnuPrintInvoice
        '
        Me.mnuPrintInvoice.Name = "mnuPrintInvoice"
        Me.mnuPrintInvoice.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuPrintInvoice.Size = New System.Drawing.Size(85, 20)
        Me.mnuPrintInvoice.Text = "Print Invoice"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmdEnquiry)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.PanCommands)
        Me.Panel3.Controls.Add(Me.cmdSave)
        Me.Panel3.Controls.Add(Me.cmdNew)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(479, 351)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(260, 69)
        Me.Panel3.TabIndex = 1
        '
        'cmdEnquiry
        '
        Me.cmdEnquiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnquiry.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdEnquiry.Location = New System.Drawing.Point(185, 3)
        Me.cmdEnquiry.Name = "cmdEnquiry"
        Me.cmdEnquiry.Size = New System.Drawing.Size(72, 28)
        Me.cmdEnquiry.TabIndex = 562
        Me.cmdEnquiry.Text = "Enquiry"
        Me.cmdEnquiry.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(6, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 13)
        Me.Label13.TabIndex = 561
        Me.Label13.Text = "Press F3 to print last invoice"
        '
        'PanCommands
        '
        Me.PanCommands.BackColor = System.Drawing.Color.LightBlue
        Me.PanCommands.Controls.Add(Me.CmdCut)
        Me.PanCommands.Controls.Add(Me.CmdOpen)
        Me.PanCommands.Location = New System.Drawing.Point(180, 36)
        Me.PanCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.PanCommands.Name = "PanCommands"
        Me.PanCommands.Size = New System.Drawing.Size(76, 28)
        Me.PanCommands.TabIndex = 556
        '
        'CmdCut
        '
        Me.CmdCut.Image = Global.Cupid.My.Resources.Resources.CUT
        Me.CmdCut.Location = New System.Drawing.Point(38, 1)
        Me.CmdCut.Name = "CmdCut"
        Me.CmdCut.Size = New System.Drawing.Size(36, 25)
        Me.CmdCut.TabIndex = 10
        Me.CmdCut.UseVisualStyleBackColor = True
        '
        'CmdOpen
        '
        Me.CmdOpen.Image = Global.Cupid.My.Resources.Resources.OPEN
        Me.CmdOpen.Location = New System.Drawing.Point(2, 1)
        Me.CmdOpen.Name = "CmdOpen"
        Me.CmdOpen.Size = New System.Drawing.Size(36, 25)
        Me.CmdOpen.TabIndex = 9
        Me.CmdOpen.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(90, 31)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(84, 38)
        Me.cmdSave.TabIndex = 555
        Me.cmdSave.Text = "Save Order"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.Location = New System.Drawing.Point(2, 31)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(84, 38)
        Me.cmdNew.TabIndex = 554
        Me.cmdNew.Text = "New Order"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'chkCategory
        '
        Me.chkCategory.AutoSize = True
        Me.chkCategory.ForeColor = System.Drawing.Color.Red
        Me.chkCategory.Location = New System.Drawing.Point(9, 30)
        Me.chkCategory.Name = "chkCategory"
        Me.chkCategory.Size = New System.Drawing.Size(93, 17)
        Me.chkCategory.TabIndex = 552
        Me.chkCategory.Text = "Hide Category"
        Me.chkCategory.UseVisualStyleBackColor = True
        '
        'Pan
        '
        Me.Pan.Controls.Add(Me.cInvoiceType)
        Me.Pan.Controls.Add(Me.Label28)
        Me.Pan.Location = New System.Drawing.Point(862, 26)
        Me.Pan.Name = "Pan"
        Me.Pan.Size = New System.Drawing.Size(162, 24)
        Me.Pan.TabIndex = 559
        Me.Pan.Visible = False
        '
        'cInvoiceType
        '
        Me.cInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cInvoiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cInvoiceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cInvoiceType.FormattingEnabled = True
        Me.cInvoiceType.Items.AddRange(New Object() {"POS", "Standard"})
        Me.cInvoiceType.Location = New System.Drawing.Point(85, 1)
        Me.cInvoiceType.Name = "cInvoiceType"
        Me.cInvoiceType.Size = New System.Drawing.Size(78, 20)
        Me.cInvoiceType.TabIndex = 247
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(11, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 13)
        Me.Label28.TabIndex = 246
        Me.Label28.Text = "Invoice Type:"
        '
        'FrmSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1025, 646)
        Me.Controls.Add(Me.Pan)
        Me.Controls.Add(Me.chkCategory)
        Me.Controls.Add(Me.tblMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuPntInvoice
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SALES"
        Me.tblHeader.ResumeLayout(False)
        Me.tblHeader.PerformLayout()
        Me.tblMain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblProduct.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.PanCopies.ResumeLayout(False)
        Me.PanCopies.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.PanPayType.ResumeLayout(False)
        Me.PanPayType.PerformLayout()
        Me.mnuPntInvoice.ResumeLayout(False)
        Me.mnuPntInvoice.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanCommands.ResumeLayout(False)
        Me.Pan.ResumeLayout(False)
        Me.Pan.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvCategory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TblProduct As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvProduct As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tFind As System.Windows.Forms.TextBox
    Friend WithEvents CmdFind As System.Windows.Forms.Button
    Friend WithEvents tblMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tItemCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tProductName As System.Windows.Forms.TextBox
    Friend WithEvents tCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents tStockLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents cFixedPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdSalesPerson As System.Windows.Forms.Button
    Friend WithEvents cSalesPerson As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tSourceDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cCostPrice As System.Windows.Forms.ComboBox
    Friend WithEvents tCostPrice As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAccept As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents PanCommands As System.Windows.Forms.Panel
    Friend WithEvents CmdCut As System.Windows.Forms.Button
    Friend WithEvents CmdOpen As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tTotalValue As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tPayable As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tVat As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents chkVAT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cPole As System.Windows.Forms.ComboBox
    Friend WithEvents cPOS As System.Windows.Forms.ComboBox
    Friend WithEvents mnuEdit As System.Windows.Forms.Button
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents PanPayType As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tPayDetails As System.Windows.Forms.TextBox
    Friend WithEvents RadOthers As System.Windows.Forms.RadioButton
    Friend WithEvents RadCheque As System.Windows.Forms.RadioButton
    Friend WithEvents RadCash As System.Windows.Forms.RadioButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdFetchCustomer As System.Windows.Forms.Button
    Friend WithEvents tCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lvSalesList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PanCopies As System.Windows.Forms.Panel
    Friend WithEvents tCopies As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEnquiry As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tChange As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents chkGiveChange As System.Windows.Forms.CheckBox
    Friend WithEvents mnuPntInvoice As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPrintInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents tQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents Pan As System.Windows.Forms.Panel
    Friend WithEvents cInvoiceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
End Class
