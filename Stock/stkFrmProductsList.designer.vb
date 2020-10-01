<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stkFrmProductsList
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("<All>")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Retail")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Service")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stkFrmProductsList))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvListCat = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cntxCategory = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lvListStore = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvTransType = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tblDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.cntxStockItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuStockItemHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuStockPicture = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadWithout = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboCriteria = New System.Windows.Forms.ComboBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.SelNumber2 = New System.Windows.Forms.NumericUpDown()
        Me.tFilterText2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.RadAll = New System.Windows.Forms.RadioButton()
        Me.RadWith = New System.Windows.Forms.RadioButton()
        Me.PanInput = New System.Windows.Forms.Panel()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.tDesc = New System.Windows.Forms.TextBox()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.PanStockImage = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.cntxCategory.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tblDetails.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntxStockItem.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.SelNumber2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AppHeader1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1354, 512)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tblDetails, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PanInput, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 51)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1354, 461)
        Me.TableLayoutPanel2.TabIndex = 252
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(243, 343)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvListCat)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(1)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(235, 315)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Category"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvListCat
        '
        Me.lvListCat.BackColor = System.Drawing.Color.Khaki
        Me.lvListCat.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvListCat.ContextMenuStrip = Me.cntxCategory
        Me.lvListCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvListCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvListCat.GridLines = True
        Me.lvListCat.HideSelection = False
        Me.lvListCat.Location = New System.Drawing.Point(3, 3)
        Me.lvListCat.Margin = New System.Windows.Forms.Padding(1)
        Me.lvListCat.Name = "lvListCat"
        Me.lvListCat.Size = New System.Drawing.Size(229, 309)
        Me.lvListCat.TabIndex = 0
        Me.lvListCat.UseCompatibleStateImageBehavior = False
        Me.lvListCat.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 201
        '
        'cntxCategory
        '
        Me.cntxCategory.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CategoryToolStripMenuItem, Me.mnuAdd, Me.mnuEdit, Me.mnuDelete})
        Me.cntxCategory.Name = "cntxCategory"
        Me.cntxCategory.ShowImageMargin = False
        Me.cntxCategory.Size = New System.Drawing.Size(110, 92)
        '
        'CategoryToolStripMenuItem
        '
        Me.CategoryToolStripMenuItem.Enabled = False
        Me.CategoryToolStripMenuItem.Name = "CategoryToolStripMenuItem"
        Me.CategoryToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.CategoryToolStripMenuItem.Text = "CATEGORY"
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Size = New System.Drawing.Size(109, 22)
        Me.mnuAdd.Text = "Add"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(109, 22)
        Me.mnuEdit.Text = "Edit"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(109, 22)
        Me.mnuDelete.Text = "Delete"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lvListStore)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(235, 315)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Store"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lvListStore
        '
        Me.lvListStore.BackColor = System.Drawing.Color.Khaki
        Me.lvListStore.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lvListStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvListStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvListStore.GridLines = True
        Me.lvListStore.HideSelection = False
        Me.lvListStore.Location = New System.Drawing.Point(3, 3)
        Me.lvListStore.Margin = New System.Windows.Forms.Padding(1)
        Me.lvListStore.Name = "lvListStore"
        Me.lvListStore.Size = New System.Drawing.Size(229, 309)
        Me.lvListStore.TabIndex = 1
        Me.lvListStore.UseCompatibleStateImageBehavior = False
        Me.lvListStore.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Store"
        Me.ColumnHeader3.Width = 201
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvTransType)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(235, 315)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "Trans. Type"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvTransType
        '
        Me.lvTransType.BackColor = System.Drawing.Color.Khaki
        Me.lvTransType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvTransType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTransType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTransType.GridLines = True
        Me.lvTransType.HideSelection = False
        Me.lvTransType.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lvTransType.Location = New System.Drawing.Point(3, 3)
        Me.lvTransType.Margin = New System.Windows.Forms.Padding(1)
        Me.lvTransType.Name = "lvTransType"
        Me.lvTransType.Size = New System.Drawing.Size(229, 309)
        Me.lvTransType.TabIndex = 2
        Me.lvTransType.UseCompatibleStateImageBehavior = False
        Me.lvTransType.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Transaction Type"
        Me.ColumnHeader2.Width = 201
        '
        'tblDetails
        '
        Me.tblDetails.ColumnCount = 1
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetails.Controls.Add(Me.DGrid, 0, 1)
        Me.tblDetails.Controls.Add(Me.Panel1, 0, 0)
        Me.tblDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetails.Location = New System.Drawing.Point(249, 0)
        Me.tblDetails.Margin = New System.Windows.Forms.Padding(0)
        Me.tblDetails.Name = "tblDetails"
        Me.tblDetails.RowCount = 2
        Me.TableLayoutPanel2.SetRowSpan(Me.tblDetails, 2)
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetails.Size = New System.Drawing.Size(1105, 461)
        Me.tblDetails.TabIndex = 1
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
        Me.DGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.DGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.BackgroundColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.ContextMenuStrip = Me.cntxStockItem
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 34)
        Me.DGrid.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
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
        Me.DGrid.RowHeadersWidth = 23
        Me.DGrid.Size = New System.Drawing.Size(1105, 427)
        Me.DGrid.TabIndex = 279
        '
        'cntxStockItem
        '
        Me.cntxStockItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.mnuAddItem, Me.mnuEditItem, Me.mnuDeleteItem, Me.ToolStripMenuItem6, Me.mnuStockItemHistory, Me.ToolStripMenuItem5, Me.mnuStockPicture})
        Me.cntxStockItem.Name = "cntxCategory"
        Me.cntxStockItem.ShowImageMargin = False
        Me.cntxStockItem.Size = New System.Drawing.Size(147, 148)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItem2.Text = "STOCK ITEMS"
        '
        'mnuAddItem
        '
        Me.mnuAddItem.Name = "mnuAddItem"
        Me.mnuAddItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuAddItem.Size = New System.Drawing.Size(146, 22)
        Me.mnuAddItem.Text = "Add"
        '
        'mnuEditItem
        '
        Me.mnuEditItem.Name = "mnuEditItem"
        Me.mnuEditItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuEditItem.Size = New System.Drawing.Size(146, 22)
        Me.mnuEditItem.Text = "Edit"
        '
        'mnuDeleteItem
        '
        Me.mnuDeleteItem.Name = "mnuDeleteItem"
        Me.mnuDeleteItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.mnuDeleteItem.Size = New System.Drawing.Size(146, 22)
        Me.mnuDeleteItem.Text = "Delete"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(143, 6)
        '
        'mnuStockItemHistory
        '
        Me.mnuStockItemHistory.Name = "mnuStockItemHistory"
        Me.mnuStockItemHistory.Size = New System.Drawing.Size(146, 22)
        Me.mnuStockItemHistory.Text = "Stock Item History"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(143, 6)
        '
        'mnuStockPicture
        '
        Me.mnuStockPicture.Name = "mnuStockPicture"
        Me.mnuStockPicture.Size = New System.Drawing.Size(146, 22)
        Me.mnuStockPicture.Text = "Pictures"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadWithout)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.RadAll)
        Me.Panel1.Controls.Add(Me.RadWith)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1102, 31)
        Me.Panel1.TabIndex = 280
        '
        'RadWithout
        '
        Me.RadWithout.AutoSize = True
        Me.RadWithout.Location = New System.Drawing.Point(128, 8)
        Me.RadWithout.Name = "RadWithout"
        Me.RadWithout.Size = New System.Drawing.Size(93, 17)
        Me.RadWithout.TabIndex = 244
        Me.RadWithout.Text = "Without Stock"
        Me.RadWithout.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cboCriteria)
        Me.GroupBox4.Controls.Add(Me.cmdRefresh)
        Me.GroupBox4.Controls.Add(Me.cmdFilter)
        Me.GroupBox4.Controls.Add(Me.SelNumber2)
        Me.GroupBox4.Controls.Add(Me.tFilterText2)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Location = New System.Drawing.Point(330, -4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(649, 33)
        Me.GroupBox4.TabIndex = 241
        Me.GroupBox4.TabStop = False
        '
        'cboCriteria
        '
        Me.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCriteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCriteria.FormattingEnabled = True
        Me.cboCriteria.Items.AddRange(New Object() {"=", "Containing", "Start With", "End With"})
        Me.cboCriteria.Location = New System.Drawing.Point(186, 9)
        Me.cboCriteria.Name = "cboCriteria"
        Me.cboCriteria.Size = New System.Drawing.Size(91, 20)
        Me.cboCriteria.TabIndex = 18
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(571, 8)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(71, 22)
        Me.cmdRefresh.TabIndex = 17
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(499, 8)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(71, 22)
        Me.cmdFilter.TabIndex = 16
        Me.cmdFilter.Text = "F&ilter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'SelNumber2
        '
        Me.SelNumber2.Location = New System.Drawing.Point(90, 9)
        Me.SelNumber2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SelNumber2.Name = "SelNumber2"
        Me.SelNumber2.Size = New System.Drawing.Size(39, 20)
        Me.SelNumber2.TabIndex = 15
        Me.SelNumber2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tFilterText2
        '
        Me.tFilterText2.Location = New System.Drawing.Point(280, 9)
        Me.tFilterText2.Name = "tFilterText2"
        Me.tFilterText2.Size = New System.Drawing.Size(215, 20)
        Me.tFilterText2.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.Location = New System.Drawing.Point(131, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 23)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "&Filter Text:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(3, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 23)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "&Selected Column:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadAll
        '
        Me.RadAll.AutoSize = True
        Me.RadAll.Checked = True
        Me.RadAll.Location = New System.Drawing.Point(5, 7)
        Me.RadAll.Name = "RadAll"
        Me.RadAll.Size = New System.Drawing.Size(36, 17)
        Me.RadAll.TabIndex = 4
        Me.RadAll.TabStop = True
        Me.RadAll.Text = "All"
        Me.RadAll.UseVisualStyleBackColor = True
        '
        'RadWith
        '
        Me.RadWith.AutoSize = True
        Me.RadWith.Location = New System.Drawing.Point(46, 7)
        Me.RadWith.Name = "RadWith"
        Me.RadWith.Size = New System.Drawing.Size(78, 17)
        Me.RadWith.TabIndex = 2
        Me.RadWith.Text = "With Stock"
        Me.RadWith.UseVisualStyleBackColor = True
        '
        'PanInput
        '
        Me.PanInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanInput.Controls.Add(Me.cmdOk)
        Me.PanInput.Controls.Add(Me.lblCaption)
        Me.PanInput.Controls.Add(Me.tDesc)
        Me.PanInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanInput.Location = New System.Drawing.Point(3, 352)
        Me.PanInput.Name = "PanInput"
        Me.PanInput.Size = New System.Drawing.Size(243, 106)
        Me.PanInput.TabIndex = 2
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(170, 28)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(69, 24)
        Me.cmdOk.TabIndex = 57
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(1, 7)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(52, 13)
        Me.lblCaption.TabIndex = 56
        Me.lblCaption.Text = "Category:"
        '
        'tDesc
        '
        Me.tDesc.Location = New System.Drawing.Point(52, 4)
        Me.tDesc.Name = "tDesc"
        Me.tDesc.Size = New System.Drawing.Size(187, 20)
        Me.tDesc.TabIndex = 55
        Me.tDesc.Tag = "Description"
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(1354, 51)
        Me.AppHeader1.TabIndex = 253
        '
        'PanStockImage
        '
        Me.PanStockImage.AllowDrop = True
        Me.PanStockImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanStockImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanStockImage.Location = New System.Drawing.Point(266, 262)
        Me.PanStockImage.Name = "PanStockImage"
        Me.PanStockImage.Size = New System.Drawing.Size(241, 234)
        Me.PanStockImage.TabIndex = 245
        Me.PanStockImage.Visible = False
        '
        'stkFrmProductsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(1354, 512)
        Me.Controls.Add(Me.PanStockImage)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stkFrmProductsList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stockitem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.cntxCategory.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.tblDetails.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntxStockItem.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.SelNumber2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanInput.ResumeLayout(False)
        Me.PanInput.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lvListCat As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tblDetails As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanInput As System.Windows.Forms.Panel
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents tDesc As System.Windows.Forms.TextBox
    Friend WithEvents cntxCategory As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadAll As System.Windows.Forms.RadioButton
    Friend WithEvents RadWith As System.Windows.Forms.RadioButton
    Friend WithEvents cntxStockItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lvListStore As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents SelNumber2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents tFilterText2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents mnuStockPicture As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanStockImage As System.Windows.Forms.Panel
    Friend WithEvents mnuStockItemHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvTransType As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RadWithout As System.Windows.Forms.RadioButton
End Class
