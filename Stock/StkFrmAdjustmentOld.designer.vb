<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StkFrmAdjustmentOld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StkFrmAdjustmentOld))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tProductName = New System.Windows.Forms.TextBox()
        Me.tCategoryName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvCategory = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvProduct = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.tFind = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cStore = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanTransType = New System.Windows.Forms.Panel()
        Me.cboTransType = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmdNewBatch = New System.Windows.Forms.Button()
        Me.cboBatch = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCostPrice = New System.Windows.Forms.TextBox()
        Me.cmdNewItem = New System.Windows.Forms.Button()
        Me.cCostPrice = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tRefNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tReason = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cSellPrice = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tSellPrice = New System.Windows.Forms.TextBox()
        Me.tStockLevel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tQty = New System.Windows.Forms.TextBox()
        Me.tItemCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPack = New System.Windows.Forms.Label()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanTransType.SuspendLayout()
        Me.SuspendLayout()
        '
        'tProductName
        '
        Me.tProductName.BackColor = System.Drawing.Color.Khaki
        Me.tProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tProductName.Location = New System.Drawing.Point(4, 64)
        Me.tProductName.Name = "tProductName"
        Me.tProductName.ReadOnly = True
        Me.tProductName.Size = New System.Drawing.Size(363, 20)
        Me.tProductName.TabIndex = 3
        Me.tProductName.TabStop = False
        Me.tProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tProductName, "Item name")
        '
        'tCategoryName
        '
        Me.tCategoryName.BackColor = System.Drawing.Color.Khaki
        Me.tCategoryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCategoryName.Location = New System.Drawing.Point(4, 42)
        Me.tCategoryName.Name = "tCategoryName"
        Me.tCategoryName.ReadOnly = True
        Me.tCategoryName.Size = New System.Drawing.Size(363, 20)
        Me.tCategoryName.TabIndex = 5
        Me.tCategoryName.TabStop = False
        Me.tCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tCategoryName, "Category")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lvCategory, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AppHeader1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1015, 531)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lvCategory
        '
        Me.lvCategory.BackColor = System.Drawing.Color.Khaki
        Me.lvCategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lvCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lvCategory.FullRowSelect = True
        Me.lvCategory.GridLines = True
        Me.lvCategory.HideSelection = False
        Me.lvCategory.Location = New System.Drawing.Point(3, 52)
        Me.lvCategory.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.lvCategory.MultiSelect = False
        Me.lvCategory.Name = "lvCategory"
        Me.lvCategory.Size = New System.Drawing.Size(213, 476)
        Me.lvCategory.TabIndex = 265
        Me.lvCategory.UseCompatibleStateImageBehavior = False
        Me.lvCategory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Category"
        Me.ColumnHeader4.Width = 190
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lvProduct, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(217, 52)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(402, 476)
        Me.TableLayoutPanel2.TabIndex = 266
        '
        'lvProduct
        '
        Me.lvProduct.BackColor = System.Drawing.Color.Khaki
        Me.lvProduct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lvProduct.FullRowSelect = True
        Me.lvProduct.GridLines = True
        Me.lvProduct.HideSelection = False
        Me.lvProduct.Location = New System.Drawing.Point(4, 46)
        Me.lvProduct.Margin = New System.Windows.Forms.Padding(1, 3, 2, 0)
        Me.lvProduct.MultiSelect = False
        Me.lvProduct.Name = "lvProduct"
        Me.lvProduct.Size = New System.Drawing.Size(393, 427)
        Me.lvProduct.TabIndex = 265
        Me.lvProduct.UseCompatibleStateImageBehavior = False
        Me.lvProduct.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Code"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 248
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel1.Controls.Add(Me.CmdFind)
        Me.Panel1.Controls.Add(Me.tFind)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 31)
        Me.Panel1.TabIndex = 266
        '
        'CmdFind
        '
        Me.CmdFind.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFind.Image = Global.Cupid.My.Resources.Resources.FIND
        Me.CmdFind.Location = New System.Drawing.Point(355, 3)
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
        Me.tFind.Size = New System.Drawing.Size(350, 20)
        Me.tFind.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(621, 50)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(1, 1, 1, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(393, 478)
        Me.TableLayoutPanel3.TabIndex = 267
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(388, 370)
        Me.TableLayoutPanel4.TabIndex = 558
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.cStore)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(380, 362)
        Me.Panel2.TabIndex = 0
        '
        'cStore
        '
        Me.cStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cStore.FormattingEnabled = True
        Me.cStore.Location = New System.Drawing.Point(65, 7)
        Me.cStore.Name = "cStore"
        Me.cStore.Size = New System.Drawing.Size(159, 21)
        Me.cStore.TabIndex = 565
        Me.cStore.Tag = "Location"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(9, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 564
        Me.Label21.Text = "STORE:"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(277, 5)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 556
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel3.Controls.Add(Me.cmdClear)
        Me.Panel3.Controls.Add(Me.cmdOk)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Location = New System.Drawing.Point(67, 300)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 54)
        Me.Panel3.TabIndex = 557
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(89, 6)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(74, 42)
        Me.cmdClear.TabIndex = 555
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(6, 6)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(83, 42)
        Me.cmdOk.TabIndex = 553
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(162, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(74, 42)
        Me.cmdClose.TabIndex = 554
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PanTransType)
        Me.GroupBox1.Controls.Add(Me.cmdNewBatch)
        Me.GroupBox1.Controls.Add(Me.cboBatch)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tCostPrice)
        Me.GroupBox1.Controls.Add(Me.cmdNewItem)
        Me.GroupBox1.Controls.Add(Me.cCostPrice)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.tRefNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tReason)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cSellPrice)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tSellPrice)
        Me.GroupBox1.Controls.Add(Me.tStockLevel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tQty)
        Me.GroupBox1.Controls.Add(Me.tCategoryName)
        Me.GroupBox1.Controls.Add(Me.tProductName)
        Me.GroupBox1.Controls.Add(Me.tItemCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblPack)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 253)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "STOCK ITEM"
        '
        'PanTransType
        '
        Me.PanTransType.Controls.Add(Me.cboTransType)
        Me.PanTransType.Controls.Add(Me.Label38)
        Me.PanTransType.Location = New System.Drawing.Point(115, 84)
        Me.PanTransType.Name = "PanTransType"
        Me.PanTransType.Size = New System.Drawing.Size(252, 25)
        Me.PanTransType.TabIndex = 567
        '
        'cboTransType
        '
        Me.cboTransType.BackColor = System.Drawing.Color.Khaki
        Me.cboTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransType.Enabled = False
        Me.cboTransType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTransType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboTransType.FormattingEnabled = True
        Me.cboTransType.Items.AddRange(New Object() {"Retail", "Service"})
        Me.cboTransType.Location = New System.Drawing.Point(141, 1)
        Me.cboTransType.Name = "cboTransType"
        Me.cboTransType.Size = New System.Drawing.Size(111, 21)
        Me.cboTransType.TabIndex = 563
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(42, 4)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(93, 13)
        Me.Label38.TabIndex = 564
        Me.Label38.Text = "Transaction Type:"
        '
        'cmdNewBatch
        '
        Me.cmdNewBatch.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdNewBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cmdNewBatch.Location = New System.Drawing.Point(209, 134)
        Me.cmdNewBatch.Name = "cmdNewBatch"
        Me.cmdNewBatch.Size = New System.Drawing.Size(36, 22)
        Me.cmdNewBatch.TabIndex = 566
        Me.cmdNewBatch.Text = "New"
        Me.cmdNewBatch.UseVisualStyleBackColor = True
        '
        'cboBatch
        '
        Me.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBatch.FormattingEnabled = True
        Me.cboBatch.Location = New System.Drawing.Point(58, 135)
        Me.cboBatch.Name = "cboBatch"
        Me.cboBatch.Size = New System.Drawing.Size(149, 21)
        Me.cboBatch.TabIndex = 564
        Me.cboBatch.Tag = "BatchNo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 565
        Me.Label7.Text = "Batch:"
        '
        'tCostPrice
        '
        Me.tCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCostPrice.Location = New System.Drawing.Point(57, 182)
        Me.tCostPrice.Name = "tCostPrice"
        Me.tCostPrice.Size = New System.Drawing.Size(60, 20)
        Me.tCostPrice.TabIndex = 563
        '
        'cmdNewItem
        '
        Me.cmdNewItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewItem.Location = New System.Drawing.Point(209, 112)
        Me.cmdNewItem.Name = "cmdNewItem"
        Me.cmdNewItem.Size = New System.Drawing.Size(36, 22)
        Me.cmdNewItem.TabIndex = 561
        Me.cmdNewItem.Text = "New"
        Me.cmdNewItem.UseVisualStyleBackColor = True
        '
        'cCostPrice
        '
        Me.cCostPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cCostPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cCostPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cCostPrice.FormattingEnabled = True
        Me.cCostPrice.Location = New System.Drawing.Point(298, 180)
        Me.cCostPrice.Name = "cCostPrice"
        Me.cCostPrice.Size = New System.Drawing.Size(68, 21)
        Me.cCostPrice.TabIndex = 559
        Me.cCostPrice.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(243, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 560
        Me.Label12.Text = "Cost Price:"
        '
        'tRefNo
        '
        Me.tRefNo.BackColor = System.Drawing.Color.Khaki
        Me.tRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRefNo.ForeColor = System.Drawing.Color.Maroon
        Me.tRefNo.Location = New System.Drawing.Point(306, 14)
        Me.tRefNo.Name = "tRefNo"
        Me.tRefNo.ReadOnly = True
        Me.tRefNo.Size = New System.Drawing.Size(60, 20)
        Me.tRefNo.TabIndex = 555
        Me.tRefNo.TabStop = False
        Me.tRefNo.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(254, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 554
        Me.Label10.Text = "Ref No:"
        Me.Label10.Visible = False
        '
        'tReason
        '
        Me.tReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tReason.Location = New System.Drawing.Point(57, 228)
        Me.tReason.Name = "tReason"
        Me.tReason.Size = New System.Drawing.Size(311, 20)
        Me.tReason.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(3, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Reason:"
        '
        'cSellPrice
        '
        Me.cSellPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSellPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cSellPrice.FormattingEnabled = True
        Me.cSellPrice.Location = New System.Drawing.Point(298, 204)
        Me.cSellPrice.Name = "cSellPrice"
        Me.cSellPrice.Size = New System.Drawing.Size(68, 21)
        Me.cSellPrice.TabIndex = 26
        Me.cSellPrice.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(3, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Sell Price:"
        '
        'tSellPrice
        '
        Me.tSellPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSellPrice.Location = New System.Drawing.Point(57, 205)
        Me.tSellPrice.Name = "tSellPrice"
        Me.tSellPrice.Size = New System.Drawing.Size(60, 20)
        Me.tSellPrice.TabIndex = 11
        '
        'tStockLevel
        '
        Me.tStockLevel.BackColor = System.Drawing.Color.Khaki
        Me.tStockLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStockLevel.Location = New System.Drawing.Point(315, 156)
        Me.tStockLevel.Name = "tStockLevel"
        Me.tStockLevel.ReadOnly = True
        Me.tStockLevel.Size = New System.Drawing.Size(51, 20)
        Me.tStockLevel.TabIndex = 9
        Me.tStockLevel.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(3, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Qty:"
        '
        'tQty
        '
        Me.tQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tQty.Location = New System.Drawing.Point(57, 159)
        Me.tQty.Name = "tQty"
        Me.tQty.Size = New System.Drawing.Size(60, 20)
        Me.tQty.TabIndex = 7
        '
        'tItemCode
        '
        Me.tItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tItemCode.Location = New System.Drawing.Point(57, 113)
        Me.tItemCode.Name = "tItemCode"
        Me.tItemCode.Size = New System.Drawing.Size(150, 20)
        Me.tItemCode.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(239, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Stock Level:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(247, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Sell Price:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(3, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Itemcode :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(3, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 562
        Me.Label9.Text = "Cost Price:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(5, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(358, 8)
        Me.GroupBox2.TabIndex = 558
        Me.GroupBox2.TabStop = False
        '
        'lblPack
        '
        Me.lblPack.AutoSize = True
        Me.lblPack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblPack.ForeColor = System.Drawing.Color.Maroon
        Me.lblPack.Location = New System.Drawing.Point(115, 164)
        Me.lblPack.Name = "lblPack"
        Me.lblPack.Size = New System.Drawing.Size(32, 13)
        Me.lblPack.TabIndex = 568
        Me.lblPack.Text = "Pack"
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.AppHeader1, 3)
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(1015, 49)
        Me.AppHeader1.TabIndex = 268
        '
        'StkFrmAdjustmentOld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(1015, 531)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StkFrmAdjustmentOld"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Adjustment"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanTransType.ResumeLayout(False)
        Me.PanTransType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvCategory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvProduct As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdFind As System.Windows.Forms.Button
    Friend WithEvents tFind As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tCostPrice As System.Windows.Forms.TextBox
    Friend WithEvents cmdNewItem As System.Windows.Forms.Button
    Friend WithEvents cCostPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tReason As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cSellPrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents tStockLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tQty As System.Windows.Forms.TextBox
    Friend WithEvents tCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents tProductName As System.Windows.Forms.TextBox
    Friend WithEvents tItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdNewBatch As System.Windows.Forms.Button
    Friend WithEvents cboBatch As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanTransType As System.Windows.Forms.Panel
    Friend WithEvents cboTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblPack As System.Windows.Forms.Label
End Class
