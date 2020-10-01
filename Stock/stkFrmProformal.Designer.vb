<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stkFrmProformal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stkFrmProformal))
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tblHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.tblContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tblProductListings = New System.Windows.Forms.TableLayoutPanel()
        Me.lvCategory = New System.Windows.Forms.ListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cStore = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lvProduct = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DGridItems = New System.Windows.Forms.DataGridView()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lnkSearchProduct = New System.Windows.Forms.LinkLabel()
        Me.tTotalValue = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.PanEntry = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tCostPrice = New System.Windows.Forms.TextBox()
        Me.cCostPrice = New System.Windows.Forms.ComboBox()
        Me.cmdNewItem = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tSourceDoc = New System.Windows.Forms.TextBox()
        Me.tOrderNo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdAccept = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.tDetails = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cSellPrice = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tSellPrice = New System.Windows.Forms.TextBox()
        Me.tQty = New System.Windows.Forms.NumericUpDown()
        Me.tCategoryName = New System.Windows.Forms.TextBox()
        Me.tStockLevel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tItemDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tProductName = New System.Windows.Forms.TextBox()
        Me.tItemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lnkItemList = New System.Windows.Forms.LinkLabel()
        Me.PanList = New System.Windows.Forms.Panel()
        Me.tSearchName = New System.Windows.Forms.TextBox()
        Me.cmdClosePanList = New System.Windows.Forms.Button()
        Me.RadEqual = New System.Windows.Forms.RadioButton()
        Me.RadEndWith = New System.Windows.Forms.RadioButton()
        Me.RadStartWith = New System.Windows.Forms.RadioButton()
        Me.radContaining = New System.Windows.Forms.RadioButton()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.tblMain.SuspendLayout()
        Me.tblHeader.SuspendLayout()
        Me.tblContent.SuspendLayout()
        Me.tblProductListings.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DGridItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanEntry.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanList.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblMain
        '
        Me.tblMain.ColumnCount = 1
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Controls.Add(Me.tblHeader, 0, 0)
        Me.tblMain.Controls.Add(Me.tblContent, 0, 1)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 2
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Size = New System.Drawing.Size(1107, 574)
        Me.tblMain.TabIndex = 0
        '
        'tblHeader
        '
        Me.tblHeader.ColumnCount = 2
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblHeader.Controls.Add(Me.AppHeader1, 0, 0)
        Me.tblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblHeader.Location = New System.Drawing.Point(0, 0)
        Me.tblHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.tblHeader.Name = "tblHeader"
        Me.tblHeader.RowCount = 1
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tblHeader.Size = New System.Drawing.Size(1107, 49)
        Me.tblHeader.TabIndex = 100
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(1107, 48)
        Me.AppHeader1.TabIndex = 7
        '
        'tblContent
        '
        Me.tblContent.ColumnCount = 2
        Me.tblContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContent.Controls.Add(Me.tblProductListings, 0, 0)
        Me.tblContent.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.tblContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblContent.Location = New System.Drawing.Point(3, 52)
        Me.tblContent.Name = "tblContent"
        Me.tblContent.RowCount = 1
        Me.tblContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContent.Size = New System.Drawing.Size(1101, 519)
        Me.tblContent.TabIndex = 101
        '
        'tblProductListings
        '
        Me.tblProductListings.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblProductListings.ColumnCount = 2
        Me.tblProductListings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblProductListings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblProductListings.Controls.Add(Me.lvCategory, 0, 1)
        Me.tblProductListings.Controls.Add(Me.Panel3, 0, 0)
        Me.tblProductListings.Controls.Add(Me.lvProduct, 1, 0)
        Me.tblProductListings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProductListings.Location = New System.Drawing.Point(0, 0)
        Me.tblProductListings.Margin = New System.Windows.Forms.Padding(0)
        Me.tblProductListings.Name = "tblProductListings"
        Me.tblProductListings.RowCount = 2
        Me.tblProductListings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblProductListings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblProductListings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblProductListings.Size = New System.Drawing.Size(562, 519)
        Me.tblProductListings.TabIndex = 276
        '
        'lvCategory
        '
        Me.lvCategory.BackColor = System.Drawing.Color.Khaki
        Me.lvCategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15})
        Me.lvCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCategory.FullRowSelect = True
        Me.lvCategory.GridLines = True
        Me.lvCategory.HideSelection = False
        Me.lvCategory.Location = New System.Drawing.Point(4, 42)
        Me.lvCategory.MultiSelect = False
        Me.lvCategory.Name = "lvCategory"
        Me.lvCategory.Size = New System.Drawing.Size(201, 473)
        Me.lvCategory.TabIndex = 4
        Me.lvCategory.UseCompatibleStateImageBehavior = False
        Me.lvCategory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Category"
        Me.ColumnHeader15.Width = 179
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cStore)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(201, 31)
        Me.Panel3.TabIndex = 0
        '
        'cStore
        '
        Me.cStore.BackColor = System.Drawing.Color.Red
        Me.cStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cStore.ForeColor = System.Drawing.Color.White
        Me.cStore.FormattingEnabled = True
        Me.cStore.Location = New System.Drawing.Point(48, 2)
        Me.cStore.Name = "cStore"
        Me.cStore.Size = New System.Drawing.Size(147, 24)
        Me.cStore.TabIndex = 54
        Me.cStore.Tag = "Location"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(2, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 17)
        Me.Label21.TabIndex = 51
        Me.Label21.Text = "Store:"
        '
        'lvProduct
        '
        Me.lvProduct.BackColor = System.Drawing.Color.Khaki
        Me.lvProduct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProduct.FullRowSelect = True
        Me.lvProduct.GridLines = True
        Me.lvProduct.HideSelection = False
        Me.lvProduct.Location = New System.Drawing.Point(212, 4)
        Me.lvProduct.MultiSelect = False
        Me.lvProduct.Name = "lvProduct"
        Me.tblProductListings.SetRowSpan(Me.lvProduct, 2)
        Me.lvProduct.Size = New System.Drawing.Size(346, 511)
        Me.lvProduct.TabIndex = 2
        Me.lvProduct.UseCompatibleStateImageBehavior = False
        Me.lvProduct.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Code"
        Me.ColumnHeader3.Width = 89
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Description"
        Me.ColumnHeader10.Width = 198
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Qty"
        Me.ColumnHeader11.Width = 38
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DGridItems, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(562, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(539, 519)
        Me.TableLayoutPanel1.TabIndex = 277
        '
        'DGridItems
        '
        Me.DGridItems.AllowUserToAddRows = False
        Me.DGridItems.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.DGridItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGridItems.BackgroundColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode, Me.oProductName, Me.Qty, Me.Amount, Me.oDiscount})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridItems.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGridItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGridItems.Location = New System.Drawing.Point(1, 4)
        Me.DGridItems.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.DGridItems.Name = "DGridItems"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGridItems.RowHeadersWidth = 23
        Me.DGridItems.Size = New System.Drawing.Size(537, 434)
        Me.DGridItems.TabIndex = 280
        '
        'ProductCode
        '
        Me.ProductCode.HeaderText = "Code"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.ReadOnly = True
        Me.ProductCode.Width = 70
        '
        'oProductName
        '
        Me.oProductName.HeaderText = "Product Name"
        Me.oProductName.Name = "oProductName"
        Me.oProductName.ReadOnly = True
        Me.oProductName.Width = 245
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 50
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 60
        '
        'oDiscount
        '
        Me.oDiscount.HeaderText = "Discount"
        Me.oDiscount.Name = "oDiscount"
        Me.oDiscount.Width = 70
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel7.Controls.Add(Me.tID)
        Me.Panel7.Controls.Add(Me.Panel2)
        Me.Panel7.Controls.Add(Me.Panel4)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(2, 440)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(535, 77)
        Me.Panel7.TabIndex = 281
        '
        'tID
        '
        Me.tID.BackColor = System.Drawing.Color.Khaki
        Me.tID.Enabled = False
        Me.tID.Location = New System.Drawing.Point(257, 44)
        Me.tID.Name = "tID"
        Me.tID.Size = New System.Drawing.Size(36, 20)
        Me.tID.TabIndex = 594
        Me.tID.Tag = "ProductCode"
        Me.tID.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lnkSearchProduct)
        Me.Panel2.Controls.Add(Me.tTotalValue)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(369, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 77)
        Me.Panel2.TabIndex = 593
        '
        'lnkSearchProduct
        '
        Me.lnkSearchProduct.AutoSize = True
        Me.lnkSearchProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkSearchProduct.LinkColor = System.Drawing.Color.White
        Me.lnkSearchProduct.Location = New System.Drawing.Point(27, 54)
        Me.lnkSearchProduct.Name = "lnkSearchProduct"
        Me.lnkSearchProduct.Size = New System.Drawing.Size(133, 20)
        Me.lnkSearchProduct.TabIndex = 592
        Me.lnkSearchProduct.TabStop = True
        Me.lnkSearchProduct.Text = "Search Product"
        '
        'tTotalValue
        '
        Me.tTotalValue.BackColor = System.Drawing.Color.Khaki
        Me.tTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTotalValue.Location = New System.Drawing.Point(70, 25)
        Me.tTotalValue.Name = "tTotalValue"
        Me.tTotalValue.ReadOnly = True
        Me.tTotalValue.Size = New System.Drawing.Size(85, 23)
        Me.tTotalValue.TabIndex = 568
        Me.tTotalValue.TabStop = False
        Me.tTotalValue.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(66, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 13)
        Me.Label24.TabIndex = 567
        Me.Label24.Text = "Total Value:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel4.Controls.Add(Me.cmdSave)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.cmdNew)
        Me.Panel4.Controls.Add(Me.cmdClearAll)
        Me.Panel4.Controls.Add(Me.dtpDate)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(244, 77)
        Me.Panel4.TabIndex = 273
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(94, 35)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(87, 38)
        Me.cmdSave.TabIndex = 581
        Me.cmdSave.Text = "Print"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 593
        Me.Label12.Text = "DATE"
        '
        'cmdNew
        '
        Me.cmdNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.Location = New System.Drawing.Point(3, 35)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(87, 38)
        Me.cmdNew.TabIndex = 580
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cmdClearAll.ForeColor = System.Drawing.Color.Maroon
        Me.cmdClearAll.Location = New System.Drawing.Point(186, 35)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(56, 38)
        Me.cmdClearAll.TabIndex = 579
        Me.cmdClearAll.Text = "Cancel"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(46, 4)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(112, 21)
        Me.dtpDate.TabIndex = 561
        '
        'PanEntry
        '
        Me.PanEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanEntry.Controls.Add(Me.cmdClose)
        Me.PanEntry.Controls.Add(Me.Label10)
        Me.PanEntry.Controls.Add(Me.tCostPrice)
        Me.PanEntry.Controls.Add(Me.cCostPrice)
        Me.PanEntry.Controls.Add(Me.cmdNewItem)
        Me.PanEntry.Controls.Add(Me.Panel1)
        Me.PanEntry.Controls.Add(Me.Label9)
        Me.PanEntry.Controls.Add(Me.cmdAccept)
        Me.PanEntry.Controls.Add(Me.cmdClear)
        Me.PanEntry.Controls.Add(Me.tDetails)
        Me.PanEntry.Controls.Add(Me.Label8)
        Me.PanEntry.Controls.Add(Me.cSellPrice)
        Me.PanEntry.Controls.Add(Me.Label4)
        Me.PanEntry.Controls.Add(Me.tSellPrice)
        Me.PanEntry.Controls.Add(Me.tQty)
        Me.PanEntry.Controls.Add(Me.tCategoryName)
        Me.PanEntry.Controls.Add(Me.tStockLevel)
        Me.PanEntry.Controls.Add(Me.Label6)
        Me.PanEntry.Controls.Add(Me.Label18)
        Me.PanEntry.Controls.Add(Me.tItemDesc)
        Me.PanEntry.Controls.Add(Me.Label5)
        Me.PanEntry.Controls.Add(Me.Label3)
        Me.PanEntry.Controls.Add(Me.Label2)
        Me.PanEntry.Controls.Add(Me.tProductName)
        Me.PanEntry.Controls.Add(Me.tItemCode)
        Me.PanEntry.Controls.Add(Me.Label1)
        Me.PanEntry.Controls.Add(Me.lblCost)
        Me.PanEntry.Controls.Add(Me.Label13)
        Me.PanEntry.Controls.Add(Me.Label7)
        Me.PanEntry.Controls.Add(Me.Label20)
        Me.PanEntry.Location = New System.Drawing.Point(255, 130)
        Me.PanEntry.Margin = New System.Windows.Forms.Padding(0)
        Me.PanEntry.Name = "PanEntry"
        Me.PanEntry.Size = New System.Drawing.Size(197, 102)
        Me.PanEntry.TabIndex = 271
        Me.PanEntry.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(104, 174)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(117, 40)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(6, 218)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 587
        Me.Label10.Text = "Cost Price:"
        Me.Label10.Visible = False
        '
        'tCostPrice
        '
        Me.tCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCostPrice.Location = New System.Drawing.Point(58, 214)
        Me.tCostPrice.Name = "tCostPrice"
        Me.tCostPrice.Size = New System.Drawing.Size(10, 20)
        Me.tCostPrice.TabIndex = 586
        Me.tCostPrice.Visible = False
        '
        'cCostPrice
        '
        Me.cCostPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cCostPrice.ForeColor = System.Drawing.Color.Black
        Me.cCostPrice.FormattingEnabled = True
        Me.cCostPrice.Location = New System.Drawing.Point(256, 186)
        Me.cCostPrice.Name = "cCostPrice"
        Me.cCostPrice.Size = New System.Drawing.Size(80, 20)
        Me.cCostPrice.TabIndex = 572
        Me.cCostPrice.TabStop = False
        '
        'cmdNewItem
        '
        Me.cmdNewItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewItem.Location = New System.Drawing.Point(172, 29)
        Me.cmdNewItem.Name = "cmdNewItem"
        Me.cmdNewItem.Size = New System.Drawing.Size(36, 22)
        Me.cmdNewItem.TabIndex = 585
        Me.cmdNewItem.Text = "New"
        Me.cmdNewItem.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tSourceDoc)
        Me.Panel1.Controls.Add(Me.tOrderNo)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Location = New System.Drawing.Point(4, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 30)
        Me.Panel1.TabIndex = 584
        '
        'tSourceDoc
        '
        Me.tSourceDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSourceDoc.Location = New System.Drawing.Point(263, 1)
        Me.tSourceDoc.Name = "tSourceDoc"
        Me.tSourceDoc.Size = New System.Drawing.Size(67, 20)
        Me.tSourceDoc.TabIndex = 562
        Me.tSourceDoc.Visible = False
        '
        'tOrderNo
        '
        Me.tOrderNo.BackColor = System.Drawing.Color.Khaki
        Me.tOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOrderNo.ForeColor = System.Drawing.Color.Maroon
        Me.tOrderNo.Location = New System.Drawing.Point(77, 1)
        Me.tOrderNo.Name = "tOrderNo"
        Me.tOrderNo.ReadOnly = True
        Me.tOrderNo.Size = New System.Drawing.Size(89, 20)
        Me.tOrderNo.TabIndex = 560
        Me.tOrderNo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(4, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 8)
        Me.GroupBox2.TabIndex = 563
        Me.GroupBox2.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(180, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 13)
        Me.Label33.TabIndex = 561
        Me.Label33.Text = "Source Doc No:"
        Me.Label33.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Maroon
        Me.Label34.Location = New System.Drawing.Point(0, 5)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 13)
        Me.Label34.TabIndex = 559
        Me.Label34.Text = "Order No:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(2, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(157, 13)
        Me.Label9.TabIndex = 583
        Me.Label9.Text = "Press F3 to print last Restock list"
        '
        'cmdAccept
        '
        Me.cmdAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAccept.Location = New System.Drawing.Point(160, 240)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(85, 28)
        Me.cmdAccept.TabIndex = 577
        Me.cmdAccept.Text = "Accept"
        Me.cmdAccept.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdClear.Location = New System.Drawing.Point(264, 23)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(72, 28)
        Me.cmdClear.TabIndex = 578
        Me.cmdClear.Text = "Cancel Order"
        Me.cmdClear.UseVisualStyleBackColor = True
        Me.cmdClear.Visible = False
        '
        'tDetails
        '
        Me.tDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDetails.Location = New System.Drawing.Point(81, 164)
        Me.tDetails.Name = "tDetails"
        Me.tDetails.Size = New System.Drawing.Size(256, 20)
        Me.tDetails.TabIndex = 568
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(4, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 567
        Me.Label8.Text = "Details:"
        '
        'cSellPrice
        '
        Me.cSellPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSellPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSellPrice.FormattingEnabled = True
        Me.cSellPrice.Location = New System.Drawing.Point(256, 140)
        Me.cSellPrice.Name = "cSellPrice"
        Me.cSellPrice.Size = New System.Drawing.Size(79, 20)
        Me.cSellPrice.TabIndex = 565
        Me.cSellPrice.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(4, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 563
        Me.Label4.Text = "Sell Price:"
        '
        'tSellPrice
        '
        Me.tSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSellPrice.Location = New System.Drawing.Point(81, 142)
        Me.tSellPrice.Name = "tSellPrice"
        Me.tSellPrice.Size = New System.Drawing.Size(60, 20)
        Me.tSellPrice.TabIndex = 564
        '
        'tQty
        '
        Me.tQty.Location = New System.Drawing.Point(81, 119)
        Me.tQty.Name = "tQty"
        Me.tQty.Size = New System.Drawing.Size(57, 20)
        Me.tQty.TabIndex = 562
        '
        'tCategoryName
        '
        Me.tCategoryName.BackColor = System.Drawing.Color.Khaki
        Me.tCategoryName.Location = New System.Drawing.Point(81, 74)
        Me.tCategoryName.Name = "tCategoryName"
        Me.tCategoryName.ReadOnly = True
        Me.tCategoryName.Size = New System.Drawing.Size(254, 20)
        Me.tCategoryName.TabIndex = 268
        Me.tCategoryName.TabStop = False
        Me.tCategoryName.Tag = "PreparedBy"
        '
        'tStockLevel
        '
        Me.tStockLevel.BackColor = System.Drawing.Color.Khaki
        Me.tStockLevel.Location = New System.Drawing.Point(257, 118)
        Me.tStockLevel.Name = "tStockLevel"
        Me.tStockLevel.ReadOnly = True
        Me.tStockLevel.Size = New System.Drawing.Size(61, 20)
        Me.tStockLevel.TabIndex = 261
        Me.tStockLevel.TabStop = False
        Me.tStockLevel.Tag = "PreparedBy"
        Me.tStockLevel.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 259
        Me.Label6.Text = "BatchNo:"
        Me.Label6.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 254
        Me.Label18.Text = "Description:"
        '
        'tItemDesc
        '
        Me.tItemDesc.BackColor = System.Drawing.Color.Khaki
        Me.tItemDesc.Location = New System.Drawing.Point(81, 96)
        Me.tItemDesc.Name = "tItemDesc"
        Me.tItemDesc.ReadOnly = True
        Me.tItemDesc.Size = New System.Drawing.Size(254, 20)
        Me.tItemDesc.TabIndex = 253
        Me.tItemDesc.TabStop = False
        Me.tItemDesc.Tag = "ProductDesc"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Qty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Category:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Item Name:"
        '
        'tProductName
        '
        Me.tProductName.Location = New System.Drawing.Point(81, 51)
        Me.tProductName.Name = "tProductName"
        Me.tProductName.Size = New System.Drawing.Size(254, 20)
        Me.tProductName.TabIndex = 0
        '
        'tItemCode
        '
        Me.tItemCode.Location = New System.Drawing.Point(81, 30)
        Me.tItemCode.Name = "tItemCode"
        Me.tItemCode.Size = New System.Drawing.Size(91, 20)
        Me.tItemCode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code:"
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCost.Location = New System.Drawing.Point(192, 191)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(59, 13)
        Me.lblCost.TabIndex = 573
        Me.lblCost.Text = "Prev. Cost:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 574
        Me.Label13.Text = "Pack:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(192, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 566
        Me.Label7.Text = "Prev. Sell:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(192, 121)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 264
        Me.Label20.Text = "Stock Level:"
        '
        'lnkItemList
        '
        Me.lnkItemList.AutoSize = True
        Me.lnkItemList.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkItemList.Location = New System.Drawing.Point(9, 31)
        Me.lnkItemList.Name = "lnkItemList"
        Me.lnkItemList.Size = New System.Drawing.Size(90, 13)
        Me.lnkItemList.TabIndex = 275
        Me.lnkItemList.TabStop = True
        Me.lnkItemList.Text = "Hide Item Listings"
        Me.lnkItemList.Visible = False
        '
        'PanList
        '
        Me.PanList.AllowDrop = True
        Me.PanList.BackColor = System.Drawing.Color.Goldenrod
        Me.PanList.Controls.Add(Me.tSearchName)
        Me.PanList.Controls.Add(Me.PanEntry)
        Me.PanList.Controls.Add(Me.cmdClosePanList)
        Me.PanList.Controls.Add(Me.RadEqual)
        Me.PanList.Controls.Add(Me.RadEndWith)
        Me.PanList.Controls.Add(Me.RadStartWith)
        Me.PanList.Controls.Add(Me.radContaining)
        Me.PanList.Controls.Add(Me.DGrid)
        Me.PanList.Location = New System.Drawing.Point(523, 202)
        Me.PanList.Name = "PanList"
        Me.PanList.Size = New System.Drawing.Size(564, 255)
        Me.PanList.TabIndex = 276
        Me.PanList.Visible = False
        '
        'tSearchName
        '
        Me.tSearchName.BackColor = System.Drawing.Color.White
        Me.tSearchName.Location = New System.Drawing.Point(5, 6)
        Me.tSearchName.Name = "tSearchName"
        Me.tSearchName.Size = New System.Drawing.Size(212, 20)
        Me.tSearchName.TabIndex = 275
        '
        'cmdClosePanList
        '
        Me.cmdClosePanList.BackColor = System.Drawing.Color.Firebrick
        Me.cmdClosePanList.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClosePanList.ForeColor = System.Drawing.Color.White
        Me.cmdClosePanList.Location = New System.Drawing.Point(539, 4)
        Me.cmdClosePanList.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
        Me.cmdClosePanList.Name = "cmdClosePanList"
        Me.cmdClosePanList.Size = New System.Drawing.Size(21, 21)
        Me.cmdClosePanList.TabIndex = 274
        Me.cmdClosePanList.Text = "X"
        Me.cmdClosePanList.UseVisualStyleBackColor = False
        '
        'RadEqual
        '
        Me.RadEqual.AutoSize = True
        Me.RadEqual.ForeColor = System.Drawing.Color.White
        Me.RadEqual.Location = New System.Drawing.Point(450, 5)
        Me.RadEqual.Name = "RadEqual"
        Me.RadEqual.Size = New System.Drawing.Size(52, 17)
        Me.RadEqual.TabIndex = 273
        Me.RadEqual.Text = "Equal"
        Me.RadEqual.UseVisualStyleBackColor = True
        '
        'RadEndWith
        '
        Me.RadEndWith.AutoSize = True
        Me.RadEndWith.ForeColor = System.Drawing.Color.White
        Me.RadEndWith.Location = New System.Drawing.Point(376, 6)
        Me.RadEndWith.Name = "RadEndWith"
        Me.RadEndWith.Size = New System.Drawing.Size(69, 17)
        Me.RadEndWith.TabIndex = 272
        Me.RadEndWith.Text = "End With"
        Me.RadEndWith.UseVisualStyleBackColor = True
        '
        'RadStartWith
        '
        Me.RadStartWith.AutoSize = True
        Me.RadStartWith.Checked = True
        Me.RadStartWith.ForeColor = System.Drawing.Color.White
        Me.RadStartWith.Location = New System.Drawing.Point(299, 6)
        Me.RadStartWith.Name = "RadStartWith"
        Me.RadStartWith.Size = New System.Drawing.Size(72, 17)
        Me.RadStartWith.TabIndex = 271
        Me.RadStartWith.TabStop = True
        Me.RadStartWith.Text = "Start With"
        Me.RadStartWith.UseVisualStyleBackColor = True
        '
        'radContaining
        '
        Me.radContaining.AutoSize = True
        Me.radContaining.ForeColor = System.Drawing.Color.White
        Me.radContaining.Location = New System.Drawing.Point(220, 6)
        Me.radContaining.Name = "radContaining"
        Me.radContaining.Size = New System.Drawing.Size(75, 17)
        Me.radContaining.TabIndex = 270
        Me.radContaining.Text = "Containing"
        Me.radContaining.UseVisualStyleBackColor = True
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
        Me.DGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SeaShell
        Me.DGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGrid.BackgroundColor = System.Drawing.Color.Khaki
        Me.DGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGrid.Location = New System.Drawing.Point(5, 30)
        Me.DGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.DGrid.MultiSelect = False
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGrid.RowHeadersWidth = 20
        Me.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGrid.Size = New System.Drawing.Size(556, 219)
        Me.DGrid.StandardTab = True
        Me.DGrid.TabIndex = 269
        '
        'stkFrmProformal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(1107, 574)
        Me.Controls.Add(Me.PanList)
        Me.Controls.Add(Me.lnkItemList)
        Me.Controls.Add(Me.tblMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stkFrmProformal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proformal Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tblMain.ResumeLayout(False)
        Me.tblHeader.ResumeLayout(False)
        Me.tblContent.ResumeLayout(False)
        Me.tblProductListings.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DGridItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PanEntry.ResumeLayout(False)
        Me.PanEntry.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanList.ResumeLayout(False)
        Me.PanList.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents tblContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblProductListings As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvProduct As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lvCategory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanEntry As System.Windows.Forms.Panel
    Friend WithEvents tCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tStockLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tProductName As System.Windows.Forms.TextBox
    Friend WithEvents cSellPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tDetails As System.Windows.Forms.TextBox
    Friend WithEvents cCostPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdAccept As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tSourceDoc As System.Windows.Forms.TextBox
    Friend WithEvents tOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tTotalValue As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lnkItemList As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdNewItem As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tCostPrice As System.Windows.Forms.TextBox
    Friend WithEvents tQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DGridItems As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents tItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanList As System.Windows.Forms.Panel
    Friend WithEvents tSearchName As System.Windows.Forms.TextBox
    Friend WithEvents cmdClosePanList As System.Windows.Forms.Button
    Friend WithEvents RadEqual As System.Windows.Forms.RadioButton
    Friend WithEvents RadEndWith As System.Windows.Forms.RadioButton
    Friend WithEvents RadStartWith As System.Windows.Forms.RadioButton
    Friend WithEvents radContaining As System.Windows.Forms.RadioButton
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents lnkSearchProduct As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
