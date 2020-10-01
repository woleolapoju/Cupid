<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Stocks", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Stock Transactions", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Documents", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Setups", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Financials", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReport))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvList1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRetTitle = New System.Windows.Forms.Label()
        Me.PanMainCmd = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.ChkDisplay = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FrpSelection = New System.Windows.Forms.GroupBox()
        Me.cStore = New System.Windows.Forms.ComboBox()
        Me.lblStore = New System.Windows.Forms.Label()
        Me.cmdAccount = New System.Windows.Forms.Button()
        Me.tAcct = New System.Windows.Forms.TextBox()
        Me.lblAcct = New System.Windows.Forms.Label()
        Me.cClient = New System.Windows.Forms.ComboBox()
        Me.cProduct = New System.Windows.Forms.ComboBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.cCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.tRefNo = New System.Windows.Forms.TextBox()
        Me.lblRefNo = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.lblStockItem = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdPrinter = New System.Windows.Forms.Button()
        Me.cOrientation = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cSize = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.cboLocalPrinters = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanMainCmd.SuspendLayout()
        Me.FrpSelection.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AppHeader1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lvList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lvList1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(650, 591)
        Me.TableLayoutPanel1.TabIndex = 125
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.AppHeader1, 3)
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(650, 40)
        Me.AppHeader1.TabIndex = 0
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.Color.Khaki
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        ListViewGroup1.Header = "Stocks"
        ListViewGroup1.Name = "GrpStocks"
        ListViewGroup2.Header = "Stock Transactions"
        ListViewGroup2.Name = "GrpStockTrans"
        ListViewGroup3.Header = "Documents"
        ListViewGroup3.Name = "GrpDoc"
        ListViewGroup4.Header = "Setups"
        ListViewGroup4.Name = "Grpsetup"
        Me.lvList.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.lvList.HideSelection = False
        Me.lvList.HoverSelection = True
        Me.lvList.Location = New System.Drawing.Point(3, 40)
        Me.lvList.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lvList.MultiSelect = False
        Me.lvList.Name = "lvList"
        Me.TableLayoutPanel1.SetRowSpan(Me.lvList, 3)
        Me.lvList.Size = New System.Drawing.Size(225, 551)
        Me.lvList.TabIndex = 2
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Report"
        Me.ColumnHeader1.Width = 214
        '
        'lvList1
        '
        Me.lvList1.BackColor = System.Drawing.Color.Khaki
        Me.lvList1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvList1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList1.FullRowSelect = True
        Me.lvList1.GridLines = True
        ListViewGroup5.Header = "Financials"
        ListViewGroup5.Name = "GrpFinance"
        Me.lvList1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup5})
        Me.lvList1.HideSelection = False
        Me.lvList1.HoverSelection = True
        Me.lvList1.Location = New System.Drawing.Point(234, 40)
        Me.lvList1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lvList1.MultiSelect = False
        Me.lvList1.Name = "lvList1"
        Me.lvList1.Size = New System.Drawing.Size(225, 284)
        Me.lvList1.TabIndex = 8
        Me.lvList1.UseCompatibleStateImageBehavior = False
        Me.lvList1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Report"
        Me.ColumnHeader2.Width = 200
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.lblRetTitle)
        Me.Panel1.Controls.Add(Me.PanMainCmd)
        Me.Panel1.Controls.Add(Me.ChkDisplay)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.FrpSelection)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(234, 327)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(413, 261)
        Me.Panel1.TabIndex = 7
        '
        'lblRetTitle
        '
        Me.lblRetTitle.AutoSize = True
        Me.lblRetTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.lblRetTitle.Location = New System.Drawing.Point(7, 3)
        Me.lblRetTitle.Name = "lblRetTitle"
        Me.lblRetTitle.Size = New System.Drawing.Size(114, 16)
        Me.lblRetTitle.TabIndex = 259
        Me.lblRetTitle.Text = "Stock Inventory"
        '
        'PanMainCmd
        '
        Me.PanMainCmd.Controls.Add(Me.cmdClose)
        Me.PanMainCmd.Controls.Add(Me.cmdOk)
        Me.PanMainCmd.Location = New System.Drawing.Point(22, 194)
        Me.PanMainCmd.Name = "PanMainCmd"
        Me.PanMainCmd.Size = New System.Drawing.Size(185, 64)
        Me.PanMainCmd.TabIndex = 261
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(93, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(89, 56)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.Color.Lavender
        Me.cmdOk.Location = New System.Drawing.Point(2, 3)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(90, 56)
        Me.cmdOk.TabIndex = 14
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'ChkDisplay
        '
        Me.ChkDisplay.AutoSize = True
        Me.ChkDisplay.Checked = True
        Me.ChkDisplay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDisplay.ForeColor = System.Drawing.Color.DarkRed
        Me.ChkDisplay.Location = New System.Drawing.Point(304, 4)
        Me.ChkDisplay.Name = "ChkDisplay"
        Me.ChkDisplay.Size = New System.Drawing.Size(77, 17)
        Me.ChkDisplay.TabIndex = 266
        Me.ChkDisplay.Text = "On Screen"
        Me.ChkDisplay.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(297, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "NOTE:"
        '
        'FrpSelection
        '
        Me.FrpSelection.Controls.Add(Me.cStore)
        Me.FrpSelection.Controls.Add(Me.lblStore)
        Me.FrpSelection.Controls.Add(Me.cmdAccount)
        Me.FrpSelection.Controls.Add(Me.tAcct)
        Me.FrpSelection.Controls.Add(Me.lblAcct)
        Me.FrpSelection.Controls.Add(Me.cClient)
        Me.FrpSelection.Controls.Add(Me.cProduct)
        Me.FrpSelection.Controls.Add(Me.dtpEndDate)
        Me.FrpSelection.Controls.Add(Me.lblEnd)
        Me.FrpSelection.Controls.Add(Me.cCategory)
        Me.FrpSelection.Controls.Add(Me.lblCategory)
        Me.FrpSelection.Controls.Add(Me.tRefNo)
        Me.FrpSelection.Controls.Add(Me.lblRefNo)
        Me.FrpSelection.Controls.Add(Me.dtpStartDate)
        Me.FrpSelection.Controls.Add(Me.lblStart)
        Me.FrpSelection.Controls.Add(Me.lblClient)
        Me.FrpSelection.Controls.Add(Me.lblStockItem)
        Me.FrpSelection.Location = New System.Drawing.Point(5, 20)
        Me.FrpSelection.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FrpSelection.Name = "FrpSelection"
        Me.FrpSelection.Size = New System.Drawing.Size(374, 166)
        Me.FrpSelection.TabIndex = 260
        Me.FrpSelection.TabStop = False
        Me.FrpSelection.Text = "Report Conditions/Parameters"
        '
        'cStore
        '
        Me.cStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cStore.FormattingEnabled = True
        Me.cStore.Location = New System.Drawing.Point(71, 88)
        Me.cStore.Name = "cStore"
        Me.cStore.Size = New System.Drawing.Size(294, 23)
        Me.cStore.TabIndex = 278
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStore.Location = New System.Drawing.Point(6, 92)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(35, 13)
        Me.lblStore.TabIndex = 277
        Me.lblStore.Text = "Store:"
        '
        'cmdAccount
        '
        Me.cmdAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAccount.Location = New System.Drawing.Point(338, 139)
        Me.cmdAccount.Name = "cmdAccount"
        Me.cmdAccount.Size = New System.Drawing.Size(27, 21)
        Me.cmdAccount.TabIndex = 276
        Me.cmdAccount.Text = "..."
        Me.cmdAccount.UseVisualStyleBackColor = True
        '
        'tAcct
        '
        Me.tAcct.Location = New System.Drawing.Point(246, 139)
        Me.tAcct.Name = "tAcct"
        Me.tAcct.Size = New System.Drawing.Size(90, 21)
        Me.tAcct.TabIndex = 274
        Me.tAcct.Tag = ""
        '
        'lblAcct
        '
        Me.lblAcct.AutoSize = True
        Me.lblAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcct.Location = New System.Drawing.Point(182, 142)
        Me.lblAcct.Name = "lblAcct"
        Me.lblAcct.Size = New System.Drawing.Size(68, 13)
        Me.lblAcct.TabIndex = 275
        Me.lblAcct.Text = "Control Acct:"
        '
        'cClient
        '
        Me.cClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cClient.FormattingEnabled = True
        Me.cClient.Location = New System.Drawing.Point(71, 113)
        Me.cClient.Name = "cClient"
        Me.cClient.Size = New System.Drawing.Size(294, 23)
        Me.cClient.TabIndex = 273
        '
        'cProduct
        '
        Me.cProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cProduct.FormattingEnabled = True
        Me.cProduct.Location = New System.Drawing.Point(71, 63)
        Me.cProduct.Name = "cProduct"
        Me.cProduct.Size = New System.Drawing.Size(294, 23)
        Me.cProduct.TabIndex = 272
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(250, 16)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(116, 20)
        Me.dtpEndDate.TabIndex = 270
        Me.dtpEndDate.Tag = "Date"
        '
        'lblEnd
        '
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(188, 20)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(68, 15)
        Me.lblEnd.TabIndex = 271
        Me.lblEnd.Text = "End Date:"
        '
        'cCategory
        '
        Me.cCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCategory.FormattingEnabled = True
        Me.cCategory.Location = New System.Drawing.Point(71, 38)
        Me.cCategory.Name = "cCategory"
        Me.cCategory.Size = New System.Drawing.Size(294, 23)
        Me.cCategory.TabIndex = 268
        '
        'lblCategory
        '
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(6, 44)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(56, 20)
        Me.lblCategory.TabIndex = 269
        Me.lblCategory.Text = "Category:"
        '
        'tRefNo
        '
        Me.tRefNo.Location = New System.Drawing.Point(70, 139)
        Me.tRefNo.Name = "tRefNo"
        Me.tRefNo.Size = New System.Drawing.Size(104, 21)
        Me.tRefNo.TabIndex = 265
        Me.tRefNo.Tag = ""
        '
        'lblRefNo
        '
        Me.lblRefNo.AutoSize = True
        Me.lblRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefNo.Location = New System.Drawing.Point(6, 142)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(47, 13)
        Me.lblRefNo.TabIndex = 266
        Me.lblRefNo.Text = "Ref. No:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(70, 16)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(116, 20)
        Me.dtpStartDate.TabIndex = 257
        Me.dtpStartDate.Tag = "Date"
        '
        'lblStart
        '
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.Location = New System.Drawing.Point(6, 20)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(68, 15)
        Me.lblStart.TabIndex = 258
        Me.lblStart.Text = "Start Date:"
        '
        'lblClient
        '
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(6, 115)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(55, 14)
        Me.lblClient.TabIndex = 242
        Me.lblClient.Text = "Client:"
        '
        'lblStockItem
        '
        Me.lblStockItem.AutoSize = True
        Me.lblStockItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockItem.Location = New System.Drawing.Point(6, 67)
        Me.lblStockItem.Name = "lblStockItem"
        Me.lblStockItem.Size = New System.Drawing.Size(61, 13)
        Me.lblStockItem.TabIndex = 239
        Me.lblStockItem.Text = "Stock Item:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(305, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = "RED"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(239, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 42)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "NOTE: Only the report parameters in RED are required for selected report type"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(465, 43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(182, 278)
        Me.Panel2.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 124)
        Me.GroupBox1.TabIndex = 261
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PRINT OPTIONS"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cboLocalPrinters)
        Me.Panel3.Controls.Add(Me.cmdPrinter)
        Me.Panel3.Controls.Add(Me.cOrientation)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cSize)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(4, 17)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(168, 104)
        Me.Panel3.TabIndex = 0
        '
        'cmdPrinter
        '
        Me.cmdPrinter.Location = New System.Drawing.Point(66, 1)
        Me.cmdPrinter.Name = "cmdPrinter"
        Me.cmdPrinter.Size = New System.Drawing.Size(86, 27)
        Me.cmdPrinter.TabIndex = 261
        Me.cmdPrinter.Text = "Select Printer"
        Me.cmdPrinter.UseVisualStyleBackColor = True
        Me.cmdPrinter.Visible = False
        '
        'cOrientation
        '
        Me.cOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cOrientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cOrientation.FormattingEnabled = True
        Me.cOrientation.Items.AddRange(New Object() {"(Default)", "Portrait", "Landscape"})
        Me.cOrientation.Location = New System.Drawing.Point(67, 73)
        Me.cOrientation.Name = "cOrientation"
        Me.cOrientation.Size = New System.Drawing.Size(92, 21)
        Me.cOrientation.TabIndex = 261
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Orientation:"
        '
        'cSize
        '
        Me.cSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSize.FormattingEnabled = True
        Me.cSize.Items.AddRange(New Object() {"(Default)", "A4", "A3", "A5", "B4", "B5", "Executive", "FanfoldLegal", "FanfoldStandard", "FanfoldUS", "Legal", "Letter"})
        Me.cSize.Location = New System.Drawing.Point(67, 48)
        Me.cSize.Name = "cSize"
        Me.cSize.Size = New System.Drawing.Size(93, 21)
        Me.cSize.TabIndex = 259
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Paper Size:"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowSelection = True
        Me.PrintDialog1.AllowSomePages = True
        Me.PrintDialog1.UseEXDialog = True
        '
        'cboLocalPrinters
        '
        Me.cboLocalPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalPrinters.FormattingEnabled = True
        Me.cboLocalPrinters.Location = New System.Drawing.Point(5, 22)
        Me.cboLocalPrinters.Name = "cboLocalPrinters"
        Me.cboLocalPrinters.Size = New System.Drawing.Size(156, 21)
        Me.cboLocalPrinters.TabIndex = 569
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 570
        Me.Label1.Text = "Printer:"
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(650, 591)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanMainCmd.ResumeLayout(False)
        Me.FrpSelection.ResumeLayout(False)
        Me.FrpSelection.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRetTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanMainCmd As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FrpSelection As System.Windows.Forms.GroupBox
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents lblStockItem As System.Windows.Forms.Label
    Friend WithEvents ChkDisplay As System.Windows.Forms.CheckBox
    Friend WithEvents tRefNo As System.Windows.Forms.TextBox
    Friend WithEvents lblRefNo As System.Windows.Forms.Label
    Friend WithEvents cCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents lvList1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cClient As System.Windows.Forms.ComboBox
    Friend WithEvents cProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdPrinter As System.Windows.Forms.Button
    Friend WithEvents cOrientation As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents tAcct As System.Windows.Forms.TextBox
    Friend WithEvents lblAcct As System.Windows.Forms.Label
    Friend WithEvents cmdAccount As System.Windows.Forms.Button
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents cStore As System.Windows.Forms.ComboBox
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cboLocalPrinters As System.Windows.Forms.ComboBox
End Class
