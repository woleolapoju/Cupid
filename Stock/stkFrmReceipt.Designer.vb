<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stkFrmReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stkFrmReceipt))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tblHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.PanAction = New System.Windows.Forms.FlowLayoutPanel()
        Me.mnuAction = New System.Windows.Forms.MenuStrip()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.tblDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lvSalesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanEntry = New System.Windows.Forms.Panel()
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
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tItemDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tProductName = New System.Windows.Forms.TextBox()
        Me.tItemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.PanCommands = New System.Windows.Forms.Panel()
        Me.CmdCut = New System.Windows.Forms.Button()
        Me.CmdOpen = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.mnuPntInvoice = New System.Windows.Forms.MenuStrip()
        Me.mnuPrintInvoice = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanPayment = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanPayType = New System.Windows.Forms.Panel()
        Me.cBank = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tCheqNo = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tReceiptNo = New System.Windows.Forms.TextBox()
        Me.RadCheque = New System.Windows.Forms.RadioButton()
        Me.RadCash = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tPaid = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkDiscount = New System.Windows.Forms.CheckBox()
        Me.chkVAT = New System.Windows.Forms.CheckBox()
        Me.tPayable = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tDiscount = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tVat = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tTotalValue = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdCustomer = New System.Windows.Forms.Button()
        Me.cmdFetchCustomer = New System.Windows.Forms.Button()
        Me.tCustomerName = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tCustomerCode = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cCustomerName = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PanList = New System.Windows.Forms.Panel()
        Me.cmdClosePanList = New System.Windows.Forms.Button()
        Me.RadEqual = New System.Windows.Forms.RadioButton()
        Me.RadEndWith = New System.Windows.Forms.RadioButton()
        Me.RadStartWith = New System.Windows.Forms.RadioButton()
        Me.radContaining = New System.Windows.Forms.RadioButton()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.lnkItemList = New System.Windows.Forms.LinkLabel()
        Me.tblMain.SuspendLayout()
        Me.tblHeader.SuspendLayout()
        Me.PanAction.SuspendLayout()
        Me.mnuAction.SuspendLayout()
        Me.tblContent.SuspendLayout()
        Me.tblProductListings.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tblDetails.SuspendLayout()
        Me.PanEntry.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.PanCommands.SuspendLayout()
        Me.mnuPntInvoice.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.PanPayment.SuspendLayout()
        Me.PanPayType.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.tblMain.Size = New System.Drawing.Size(1251, 574)
        Me.tblMain.TabIndex = 0
        '
        'tblHeader
        '
        Me.tblHeader.ColumnCount = 2
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblHeader.Controls.Add(Me.PanAction, 1, 0)
        Me.tblHeader.Controls.Add(Me.AppHeader1, 0, 0)
        Me.tblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblHeader.Location = New System.Drawing.Point(0, 0)
        Me.tblHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.tblHeader.Name = "tblHeader"
        Me.tblHeader.RowCount = 1
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tblHeader.Size = New System.Drawing.Size(1251, 49)
        Me.tblHeader.TabIndex = 100
        '
        'PanAction
        '
        Me.PanAction.BackColor = System.Drawing.Color.GhostWhite
        Me.PanAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanAction.Controls.Add(Me.mnuAction)
        Me.PanAction.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanAction.Location = New System.Drawing.Point(1198, 0)
        Me.PanAction.Margin = New System.Windows.Forms.Padding(0)
        Me.PanAction.Name = "PanAction"
        Me.PanAction.Size = New System.Drawing.Size(53, 49)
        Me.PanAction.TabIndex = 56
        '
        'mnuAction
        '
        Me.mnuAction.AllowMerge = False
        Me.mnuAction.BackColor = System.Drawing.Color.Transparent
        Me.mnuAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.mnuAction.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit})
        Me.mnuAction.Location = New System.Drawing.Point(0, 0)
        Me.mnuAction.Name = "mnuAction"
        Me.mnuAction.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mnuAction.Size = New System.Drawing.Size(39, 47)
        Me.mnuAction.TabIndex = 52
        Me.mnuAction.Text = "mnuAction"
        Me.mnuAction.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        '
        'mnuEdit
        '
        Me.mnuEdit.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.mnuEdit.ForeColor = System.Drawing.Color.Red
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(31, 43)
        Me.mnuEdit.Text = "Edit"
        Me.mnuEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(1198, 48)
        Me.AppHeader1.TabIndex = 7
        '
        'tblContent
        '
        Me.tblContent.ColumnCount = 2
        Me.tblContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblContent.Controls.Add(Me.tblProductListings, 0, 0)
        Me.tblContent.Controls.Add(Me.tblDetails, 1, 0)
        Me.tblContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblContent.Location = New System.Drawing.Point(3, 52)
        Me.tblContent.Name = "tblContent"
        Me.tblContent.RowCount = 1
        Me.tblContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContent.Size = New System.Drawing.Size(1245, 519)
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
        'tblDetails
        '
        Me.tblDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblDetails.ColumnCount = 3
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetails.Controls.Add(Me.lvSalesList, 0, 2)
        Me.tblDetails.Controls.Add(Me.PanEntry, 0, 0)
        Me.tblDetails.Controls.Add(Me.Panel4, 0, 1)
        Me.tblDetails.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.tblDetails.Controls.Add(Me.Panel5, 2, 0)
        Me.tblDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetails.Location = New System.Drawing.Point(562, 0)
        Me.tblDetails.Margin = New System.Windows.Forms.Padding(0)
        Me.tblDetails.Name = "tblDetails"
        Me.tblDetails.RowCount = 3
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetails.Size = New System.Drawing.Size(683, 519)
        Me.tblDetails.TabIndex = 277
        '
        'lvSalesList
        '
        Me.lvSalesList.BackColor = System.Drawing.Color.Khaki
        Me.lvSalesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader16, Me.ColumnHeader2, Me.ColumnHeader14, Me.ColumnHeader13, Me.ColumnHeader19, Me.ColumnHeader21})
        Me.tblDetails.SetColumnSpan(Me.lvSalesList, 3)
        Me.lvSalesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSalesList.FullRowSelect = True
        Me.lvSalesList.GridLines = True
        Me.lvSalesList.Location = New System.Drawing.Point(4, 329)
        Me.lvSalesList.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.lvSalesList.MultiSelect = False
        Me.lvSalesList.Name = "lvSalesList"
        Me.lvSalesList.Size = New System.Drawing.Size(678, 186)
        Me.lvSalesList.TabIndex = 278
        Me.lvSalesList.UseCompatibleStateImageBehavior = False
        Me.lvSalesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Sn"
        Me.ColumnHeader9.Width = 30
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Item Code"
        Me.ColumnHeader4.Width = 73
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item Name"
        Me.ColumnHeader5.Width = 198
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Qty"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 47
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Cost Price"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 67
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Value"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "SellPrice"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 83
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Details"
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Item Description"
        Me.ColumnHeader13.Width = 107
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Store"
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "TransType"
        Me.ColumnHeader21.Width = 0
        '
        'PanEntry
        '
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
        Me.PanEntry.Controls.Add(Me.Label18)
        Me.PanEntry.Controls.Add(Me.tItemDesc)
        Me.PanEntry.Controls.Add(Me.Label5)
        Me.PanEntry.Controls.Add(Me.Label3)
        Me.PanEntry.Controls.Add(Me.Label2)
        Me.PanEntry.Controls.Add(Me.tProductName)
        Me.PanEntry.Controls.Add(Me.tItemCode)
        Me.PanEntry.Controls.Add(Me.Label1)
        Me.PanEntry.Controls.Add(Me.lblCost)
        Me.PanEntry.Controls.Add(Me.Label7)
        Me.PanEntry.Controls.Add(Me.Label20)
        Me.PanEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanEntry.Location = New System.Drawing.Point(1, 1)
        Me.PanEntry.Margin = New System.Windows.Forms.Padding(0)
        Me.PanEntry.Name = "PanEntry"
        Me.PanEntry.Size = New System.Drawing.Size(339, 271)
        Me.PanEntry.TabIndex = 271
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(4, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 587
        Me.Label10.Text = "Cost Price:"
        '
        'tCostPrice
        '
        Me.tCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCostPrice.Location = New System.Drawing.Point(81, 140)
        Me.tCostPrice.Name = "tCostPrice"
        Me.tCostPrice.Size = New System.Drawing.Size(60, 20)
        Me.tCostPrice.TabIndex = 586
        '
        'cCostPrice
        '
        Me.cCostPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cCostPrice.ForeColor = System.Drawing.Color.Black
        Me.cCostPrice.FormattingEnabled = True
        Me.cCostPrice.Location = New System.Drawing.Point(258, 140)
        Me.cCostPrice.Name = "cCostPrice"
        Me.cCostPrice.Size = New System.Drawing.Size(78, 20)
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
        Me.Label9.Location = New System.Drawing.Point(2, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(157, 13)
        Me.Label9.TabIndex = 583
        Me.Label9.Text = "Press F3 to print last Restock list"
        '
        'cmdAccept
        '
        Me.cmdAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAccept.Location = New System.Drawing.Point(247, 211)
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
        Me.tDetails.Location = New System.Drawing.Point(81, 186)
        Me.tDetails.Name = "tDetails"
        Me.tDetails.Size = New System.Drawing.Size(256, 20)
        Me.tDetails.TabIndex = 568
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(4, 191)
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
        Me.cSellPrice.Location = New System.Drawing.Point(258, 163)
        Me.cSellPrice.Name = "cSellPrice"
        Me.cSellPrice.Size = New System.Drawing.Size(79, 20)
        Me.cSellPrice.TabIndex = 565
        Me.cSellPrice.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(4, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 563
        Me.Label4.Text = "Sell Price:"
        '
        'tSellPrice
        '
        Me.tSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSellPrice.Location = New System.Drawing.Point(81, 164)
        Me.tSellPrice.Name = "tSellPrice"
        Me.tSellPrice.Size = New System.Drawing.Size(60, 20)
        Me.tSellPrice.TabIndex = 564
        '
        'tQty
        '
        Me.tQty.Location = New System.Drawing.Point(81, 118)
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
        Me.tStockLevel.Location = New System.Drawing.Point(257, 117)
        Me.tStockLevel.Name = "tStockLevel"
        Me.tStockLevel.ReadOnly = True
        Me.tStockLevel.Size = New System.Drawing.Size(61, 20)
        Me.tStockLevel.TabIndex = 261
        Me.tStockLevel.TabStop = False
        Me.tStockLevel.Tag = "PreparedBy"
        Me.tStockLevel.Text = "0"
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
        Me.Label5.Location = New System.Drawing.Point(4, 123)
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
        Me.lblCost.Location = New System.Drawing.Point(195, 144)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(59, 13)
        Me.lblCost.TabIndex = 573
        Me.lblCost.Text = "Prev. Cost:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(195, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 566
        Me.Label7.Text = "Prev. Sell:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(195, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 264
        Me.Label20.Text = "Stock Level:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel4.Controls.Add(Me.cmdSave)
        Me.Panel4.Controls.Add(Me.PanCommands)
        Me.Panel4.Controls.Add(Me.cmdNew)
        Me.Panel4.Controls.Add(Me.cmdClearAll)
        Me.Panel4.Controls.Add(Me.mnuPntInvoice)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(4, 276)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(333, 46)
        Me.Panel4.TabIndex = 273
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(94, 4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(87, 38)
        Me.cmdSave.TabIndex = 581
        Me.cmdSave.Text = "Save Order"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'PanCommands
        '
        Me.PanCommands.BackColor = System.Drawing.Color.Khaki
        Me.PanCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanCommands.Controls.Add(Me.CmdCut)
        Me.PanCommands.Controls.Add(Me.CmdOpen)
        Me.PanCommands.Location = New System.Drawing.Point(255, 13)
        Me.PanCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.PanCommands.Name = "PanCommands"
        Me.PanCommands.Size = New System.Drawing.Size(74, 28)
        Me.PanCommands.TabIndex = 582
        '
        'CmdCut
        '
        Me.CmdCut.Image = CType(resources.GetObject("CmdCut.Image"), System.Drawing.Image)
        Me.CmdCut.Location = New System.Drawing.Point(37, 2)
        Me.CmdCut.Name = "CmdCut"
        Me.CmdCut.Size = New System.Drawing.Size(34, 23)
        Me.CmdCut.TabIndex = 10
        Me.CmdCut.UseVisualStyleBackColor = True
        '
        'CmdOpen
        '
        Me.CmdOpen.Image = CType(resources.GetObject("CmdOpen.Image"), System.Drawing.Image)
        Me.CmdOpen.Location = New System.Drawing.Point(1, 2)
        Me.CmdOpen.Name = "CmdOpen"
        Me.CmdOpen.Size = New System.Drawing.Size(34, 23)
        Me.CmdOpen.TabIndex = 9
        Me.CmdOpen.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.Location = New System.Drawing.Point(3, 4)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(87, 38)
        Me.cmdNew.TabIndex = 580
        Me.cmdNew.Text = "New Order"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cmdClearAll.ForeColor = System.Drawing.Color.Maroon
        Me.cmdClearAll.Location = New System.Drawing.Point(185, 4)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(56, 38)
        Me.cmdClearAll.TabIndex = 579
        Me.cmdClearAll.Text = "Cancel Order"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'mnuPntInvoice
        '
        Me.mnuPntInvoice.Dock = System.Windows.Forms.DockStyle.None
        Me.mnuPntInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintInvoice})
        Me.mnuPntInvoice.Location = New System.Drawing.Point(94, 12)
        Me.mnuPntInvoice.Name = "mnuPntInvoice"
        Me.mnuPntInvoice.Size = New System.Drawing.Size(70, 24)
        Me.mnuPntInvoice.TabIndex = 592
        Me.mnuPntInvoice.Text = "MenuStrip1"
        '
        'mnuPrintInvoice
        '
        Me.mnuPrintInvoice.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.mnuPrintInvoice.Name = "mnuPrintInvoice"
        Me.mnuPrintInvoice.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuPrintInvoice.Size = New System.Drawing.Size(62, 20)
        Me.mnuPrintInvoice.Text = "Print Invoice"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.PanPayment, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox4, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(341, 1)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.tblDetails.SetRowSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(339, 324)
        Me.TableLayoutPanel3.TabIndex = 274
        '
        'PanPayment
        '
        Me.PanPayment.Controls.Add(Me.Label12)
        Me.PanPayment.Controls.Add(Me.PanPayType)
        Me.PanPayment.Controls.Add(Me.dtpDate)
        Me.PanPayment.Controls.Add(Me.Label30)
        Me.PanPayment.Controls.Add(Me.Panel6)
        Me.PanPayment.Controls.Add(Me.Label26)
        Me.PanPayment.Controls.Add(Me.Label25)
        Me.PanPayment.Controls.Add(Me.tReceiptNo)
        Me.PanPayment.Controls.Add(Me.RadCheque)
        Me.PanPayment.Controls.Add(Me.RadCash)
        Me.PanPayment.Controls.Add(Me.Label14)
        Me.PanPayment.Controls.Add(Me.tPaid)
        Me.PanPayment.Controls.Add(Me.Label15)
        Me.PanPayment.Controls.Add(Me.chkDiscount)
        Me.PanPayment.Controls.Add(Me.chkVAT)
        Me.PanPayment.Controls.Add(Me.tPayable)
        Me.PanPayment.Controls.Add(Me.Label17)
        Me.PanPayment.Controls.Add(Me.tDiscount)
        Me.PanPayment.Controls.Add(Me.Label16)
        Me.PanPayment.Controls.Add(Me.tVat)
        Me.PanPayment.Controls.Add(Me.Label23)
        Me.PanPayment.Controls.Add(Me.tTotalValue)
        Me.PanPayment.Controls.Add(Me.Label24)
        Me.PanPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPayment.Location = New System.Drawing.Point(1, 1)
        Me.PanPayment.Margin = New System.Windows.Forms.Padding(0)
        Me.PanPayment.Name = "PanPayment"
        Me.PanPayment.Size = New System.Drawing.Size(337, 221)
        Me.PanPayment.TabIndex = 275
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(218, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 593
        Me.Label12.Text = "DATE"
        '
        'PanPayType
        '
        Me.PanPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanPayType.Controls.Add(Me.cBank)
        Me.PanPayType.Controls.Add(Me.Label11)
        Me.PanPayType.Controls.Add(Me.Label22)
        Me.PanPayType.Controls.Add(Me.tCheqNo)
        Me.PanPayType.Location = New System.Drawing.Point(105, 171)
        Me.PanPayType.Name = "PanPayType"
        Me.PanPayType.Size = New System.Drawing.Size(231, 45)
        Me.PanPayType.TabIndex = 592
        Me.PanPayType.Visible = False
        '
        'cBank
        '
        Me.cBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBank.DropDownWidth = 261
        Me.cBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBank.FormattingEnabled = True
        Me.cBank.Location = New System.Drawing.Point(65, 2)
        Me.cBank.Name = "cBank"
        Me.cBank.Size = New System.Drawing.Size(161, 20)
        Me.cBank.TabIndex = 561
        Me.cBank.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 562
        Me.Label11.Text = "Bank:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(1, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 13)
        Me.Label22.TabIndex = 560
        Me.Label22.Text = "Cheque No:"
        '
        'tCheqNo
        '
        Me.tCheqNo.BackColor = System.Drawing.Color.White
        Me.tCheqNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCheqNo.Location = New System.Drawing.Point(64, 24)
        Me.tCheqNo.Name = "tCheqNo"
        Me.tCheqNo.Size = New System.Drawing.Size(163, 18)
        Me.tCheqNo.TabIndex = 559
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(220, 25)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(112, 21)
        Me.dtpDate.TabIndex = 561
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(2, 9)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 588
        Me.Label30.Text = "FINANCIALS"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.GroupBox1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 213)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(337, 8)
        Me.Panel6.TabIndex = 561
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 8)
        Me.GroupBox1.TabIndex = 564
        Me.GroupBox1.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(165, 152)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(114, 13)
        Me.Label26.TabIndex = 586
        Me.Label26.Text = "from Previous payment"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(18, 156)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 585
        Me.Label25.Text = "Receipt No:"
        '
        'tReceiptNo
        '
        Me.tReceiptNo.BackColor = System.Drawing.Color.White
        Me.tReceiptNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tReceiptNo.Location = New System.Drawing.Point(103, 149)
        Me.tReceiptNo.Name = "tReceiptNo"
        Me.tReceiptNo.Size = New System.Drawing.Size(56, 20)
        Me.tReceiptNo.TabIndex = 584
        '
        'RadCheque
        '
        Me.RadCheque.AutoSize = True
        Me.RadCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCheque.ForeColor = System.Drawing.Color.Red
        Me.RadCheque.Location = New System.Drawing.Point(23, 197)
        Me.RadCheque.Name = "RadCheque"
        Me.RadCheque.Size = New System.Drawing.Size(62, 17)
        Me.RadCheque.TabIndex = 581
        Me.RadCheque.Text = "Cheque"
        Me.RadCheque.UseVisualStyleBackColor = True
        '
        'RadCash
        '
        Me.RadCash.AutoSize = True
        Me.RadCash.Checked = True
        Me.RadCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCash.ForeColor = System.Drawing.Color.Red
        Me.RadCash.Location = New System.Drawing.Point(24, 178)
        Me.RadCash.Name = "RadCash"
        Me.RadCash.Size = New System.Drawing.Size(49, 17)
        Me.RadCash.TabIndex = 580
        Me.RadCash.TabStop = True
        Me.RadCash.Text = "Cash"
        Me.RadCash.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 579
        Me.Label14.Text = "Paid:"
        '
        'tPaid
        '
        Me.tPaid.BackColor = System.Drawing.Color.White
        Me.tPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPaid.Location = New System.Drawing.Point(103, 123)
        Me.tPaid.Name = "tPaid"
        Me.tPaid.Size = New System.Drawing.Size(86, 23)
        Me.tPaid.TabIndex = 578
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(2, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 577
        Me.Label15.Text = "PAYMENT"
        '
        'chkDiscount
        '
        Me.chkDiscount.AutoSize = True
        Me.chkDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscount.ForeColor = System.Drawing.Color.Maroon
        Me.chkDiscount.Location = New System.Drawing.Point(164, 71)
        Me.chkDiscount.Name = "chkDiscount"
        Me.chkDiscount.Size = New System.Drawing.Size(34, 17)
        Me.chkDiscount.TabIndex = 576
        Me.chkDiscount.Text = "%"
        Me.chkDiscount.UseVisualStyleBackColor = True
        '
        'chkVAT
        '
        Me.chkVAT.AutoSize = True
        Me.chkVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVAT.ForeColor = System.Drawing.Color.Maroon
        Me.chkVAT.Location = New System.Drawing.Point(164, 49)
        Me.chkVAT.Name = "chkVAT"
        Me.chkVAT.Size = New System.Drawing.Size(34, 17)
        Me.chkVAT.TabIndex = 575
        Me.chkVAT.Text = "%"
        Me.chkVAT.UseVisualStyleBackColor = True
        '
        'tPayable
        '
        Me.tPayable.BackColor = System.Drawing.Color.Black
        Me.tPayable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPayable.ForeColor = System.Drawing.Color.White
        Me.tPayable.Location = New System.Drawing.Point(102, 92)
        Me.tPayable.Name = "tPayable"
        Me.tPayable.ReadOnly = True
        Me.tPayable.Size = New System.Drawing.Size(88, 23)
        Me.tPayable.TabIndex = 574
        Me.tPayable.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 573
        Me.Label17.Text = "Payable:"
        '
        'tDiscount
        '
        Me.tDiscount.BackColor = System.Drawing.Color.White
        Me.tDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDiscount.Location = New System.Drawing.Point(103, 70)
        Me.tDiscount.Name = "tDiscount"
        Me.tDiscount.Size = New System.Drawing.Size(58, 20)
        Me.tDiscount.TabIndex = 572
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 571
        Me.Label16.Text = "Discount:"
        '
        'tVat
        '
        Me.tVat.BackColor = System.Drawing.Color.White
        Me.tVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tVat.Location = New System.Drawing.Point(103, 48)
        Me.tVat.Name = "tVat"
        Me.tVat.Size = New System.Drawing.Size(58, 20)
        Me.tVat.TabIndex = 570
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(18, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(31, 13)
        Me.Label23.TabIndex = 569
        Me.Label23.Text = "VAT:"
        '
        'tTotalValue
        '
        Me.tTotalValue.BackColor = System.Drawing.Color.Khaki
        Me.tTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTotalValue.Location = New System.Drawing.Point(102, 24)
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
        Me.Label24.Location = New System.Drawing.Point(18, 30)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 13)
        Me.Label24.TabIndex = 567
        Me.Label24.Text = "Total Value:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cmdCustomer)
        Me.GroupBox4.Controls.Add(Me.cmdFetchCustomer)
        Me.GroupBox4.Controls.Add(Me.tCustomerName)
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.tCustomerCode)
        Me.GroupBox4.Controls.Add(Me.Label32)
        Me.GroupBox4.Controls.Add(Me.cCustomerName)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 226)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(331, 60)
        Me.GroupBox4.TabIndex = 558
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SUPPLIER INFORMATION"
        '
        'cmdCustomer
        '
        Me.cmdCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustomer.Location = New System.Drawing.Point(174, 14)
        Me.cmdCustomer.Name = "cmdCustomer"
        Me.cmdCustomer.Size = New System.Drawing.Size(38, 22)
        Me.cmdCustomer.TabIndex = 1
        Me.cmdCustomer.Text = "New"
        Me.cmdCustomer.UseVisualStyleBackColor = True
        '
        'cmdFetchCustomer
        '
        Me.cmdFetchCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFetchCustomer.Location = New System.Drawing.Point(149, 14)
        Me.cmdFetchCustomer.Name = "cmdFetchCustomer"
        Me.cmdFetchCustomer.Size = New System.Drawing.Size(26, 21)
        Me.cmdFetchCustomer.TabIndex = 1
        Me.cmdFetchCustomer.Text = "..."
        Me.cmdFetchCustomer.UseVisualStyleBackColor = True
        '
        'tCustomerName
        '
        Me.tCustomerName.BackColor = System.Drawing.Color.White
        Me.tCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCustomerName.Location = New System.Drawing.Point(50, 35)
        Me.tCustomerName.Name = "tCustomerName"
        Me.tCustomerName.ReadOnly = True
        Me.tCustomerName.Size = New System.Drawing.Size(226, 20)
        Me.tCustomerName.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(2, 37)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "Name:"
        '
        'tCustomerCode
        '
        Me.tCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCustomerCode.Location = New System.Drawing.Point(50, 14)
        Me.tCustomerCode.Name = "tCustomerCode"
        Me.tCustomerCode.Size = New System.Drawing.Size(98, 20)
        Me.tCustomerCode.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(2, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(35, 13)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "Code:"
        '
        'cCustomerName
        '
        Me.cCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cCustomerName.FormattingEnabled = True
        Me.cCustomerName.Location = New System.Drawing.Point(51, 35)
        Me.cCustomerName.Name = "cCustomerName"
        Me.cCustomerName.Size = New System.Drawing.Size(244, 21)
        Me.cCustomerName.TabIndex = 2
        Me.cCustomerName.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tID)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 290)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 30)
        Me.Panel2.TabIndex = 559
        '
        'tID
        '
        Me.tID.BackColor = System.Drawing.Color.Khaki
        Me.tID.Enabled = False
        Me.tID.Location = New System.Drawing.Point(3, 5)
        Me.tID.Name = "tID"
        Me.tID.Size = New System.Drawing.Size(36, 20)
        Me.tID.TabIndex = 260
        Me.tID.Tag = "ProductCode"
        Me.tID.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(214, 0)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(117, 30)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(681, 1)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.tblDetails.SetRowSpan(Me.Panel5, 2)
        Me.Panel5.Size = New System.Drawing.Size(1, 324)
        Me.Panel5.TabIndex = 279
        '
        'PanList
        '
        Me.PanList.AllowDrop = True
        Me.PanList.BackColor = System.Drawing.Color.Goldenrod
        Me.PanList.Controls.Add(Me.cmdClosePanList)
        Me.PanList.Controls.Add(Me.RadEqual)
        Me.PanList.Controls.Add(Me.RadEndWith)
        Me.PanList.Controls.Add(Me.RadStartWith)
        Me.PanList.Controls.Add(Me.radContaining)
        Me.PanList.Controls.Add(Me.DGrid)
        Me.PanList.Location = New System.Drawing.Point(-1, 313)
        Me.PanList.Name = "PanList"
        Me.PanList.Size = New System.Drawing.Size(564, 255)
        Me.PanList.TabIndex = 272
        Me.PanList.Visible = False
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
        Me.RadEqual.Location = New System.Drawing.Point(236, 6)
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
        Me.RadEndWith.Location = New System.Drawing.Point(162, 7)
        Me.RadEndWith.Name = "RadEndWith"
        Me.RadEndWith.Size = New System.Drawing.Size(69, 17)
        Me.RadEndWith.TabIndex = 272
        Me.RadEndWith.Text = "End With"
        Me.RadEndWith.UseVisualStyleBackColor = True
        '
        'RadStartWith
        '
        Me.RadStartWith.AutoSize = True
        Me.RadStartWith.ForeColor = System.Drawing.Color.White
        Me.RadStartWith.Location = New System.Drawing.Point(85, 7)
        Me.RadStartWith.Name = "RadStartWith"
        Me.RadStartWith.Size = New System.Drawing.Size(72, 17)
        Me.RadStartWith.TabIndex = 271
        Me.RadStartWith.Text = "Start With"
        Me.RadStartWith.UseVisualStyleBackColor = True
        '
        'radContaining
        '
        Me.radContaining.AutoSize = True
        Me.radContaining.Checked = True
        Me.radContaining.ForeColor = System.Drawing.Color.White
        Me.radContaining.Location = New System.Drawing.Point(6, 7)
        Me.radContaining.Name = "radContaining"
        Me.radContaining.Size = New System.Drawing.Size(75, 17)
        Me.radContaining.TabIndex = 270
        Me.radContaining.TabStop = True
        Me.radContaining.Text = "Containing"
        Me.radContaining.UseVisualStyleBackColor = True
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
        Me.DGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaShell
        Me.DGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.BackgroundColor = System.Drawing.Color.Khaki
        Me.DGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.Location = New System.Drawing.Point(5, 27)
        Me.DGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.DGrid.MultiSelect = False
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGrid.RowHeadersWidth = 20
        Me.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGrid.Size = New System.Drawing.Size(556, 222)
        Me.DGrid.StandardTab = True
        Me.DGrid.TabIndex = 269
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
        '
        'stkFrmReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(1251, 574)
        Me.Controls.Add(Me.lnkItemList)
        Me.Controls.Add(Me.PanList)
        Me.Controls.Add(Me.tblMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stkFrmReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tblMain.ResumeLayout(False)
        Me.tblHeader.ResumeLayout(False)
        Me.PanAction.ResumeLayout(False)
        Me.PanAction.PerformLayout()
        Me.mnuAction.ResumeLayout(False)
        Me.mnuAction.PerformLayout()
        Me.tblContent.ResumeLayout(False)
        Me.tblProductListings.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tblDetails.ResumeLayout(False)
        Me.PanEntry.ResumeLayout(False)
        Me.PanEntry.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PanCommands.ResumeLayout(False)
        Me.mnuPntInvoice.ResumeLayout(False)
        Me.mnuPntInvoice.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.PanPayment.ResumeLayout(False)
        Me.PanPayment.PerformLayout()
        Me.PanPayType.ResumeLayout(False)
        Me.PanPayType.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanList.ResumeLayout(False)
        Me.PanList.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanAction As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents mnuAction As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents tblDetails As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanEntry As System.Windows.Forms.Panel
    Friend WithEvents tCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tStockLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tProductName As System.Windows.Forms.TextBox
    Friend WithEvents tItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cSellPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tDetails As System.Windows.Forms.TextBox
    Friend WithEvents cCostPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents PanList As System.Windows.Forms.Panel
    Friend WithEvents cmdClosePanList As System.Windows.Forms.Button
    Friend WithEvents RadEqual As System.Windows.Forms.RadioButton
    Friend WithEvents RadEndWith As System.Windows.Forms.RadioButton
    Friend WithEvents RadStartWith As System.Windows.Forms.RadioButton
    Friend WithEvents radContaining As System.Windows.Forms.RadioButton
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAccept As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents PanCommands As System.Windows.Forms.Panel
    Friend WithEvents CmdCut As System.Windows.Forms.Button
    Friend WithEvents CmdOpen As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents lvSalesList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tSourceDoc As System.Windows.Forms.TextBox
    Friend WithEvents tOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents PanPayment As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents RadCheque As System.Windows.Forms.RadioButton
    Friend WithEvents RadCash As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents chkVAT As System.Windows.Forms.CheckBox
    Friend WithEvents tPayable As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tVat As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tTotalValue As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdFetchCustomer As System.Windows.Forms.Button
    Friend WithEvents tCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mnuPntInvoice As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPrintInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lnkItemList As System.Windows.Forms.LinkLabel
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdNewItem As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tCostPrice As System.Windows.Forms.TextBox
    Friend WithEvents PanPayType As System.Windows.Forms.Panel
    Friend WithEvents cBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tCheqNo As System.Windows.Forms.TextBox
    Friend WithEvents tQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
End Class
