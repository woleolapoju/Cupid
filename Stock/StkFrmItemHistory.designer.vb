<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StkFrmItemHistory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StkFrmItemHistory))
        Me.tCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.tReorder = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tMaxQty = New System.Windows.Forms.TextBox()
        Me.tUnitInStore = New System.Windows.Forms.TextBox()
        Me.chkDiscontinue = New System.Windows.Forms.CheckBox()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tRate = New System.Windows.Forms.TextBox()
        Me.tDesc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tRemark = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lnkImage = New System.Windows.Forms.LinkLabel()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lnkEDoc = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cShelfLocation = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUnitInStock = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PanStore = New System.Windows.Forms.Panel()
        Me.cStore = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tblBatchImage = New System.Windows.Forms.TableLayoutPanel()
        Me.PictStockItem = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.Panel1.SuspendLayout()
        Me.PanStore.SuspendLayout()
        Me.tblMain.SuspendLayout()
        Me.tblBatchImage.SuspendLayout()
        CType(Me.PictStockItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tCode
        '
        Me.tCode.Location = New System.Drawing.Point(101, 27)
        Me.tCode.Name = "tCode"
        Me.tCode.Size = New System.Drawing.Size(114, 20)
        Me.tCode.TabIndex = 47
        Me.tCode.Tag = "ProductCode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Item Name;"
        '
        'tName
        '
        Me.tName.Location = New System.Drawing.Point(101, 48)
        Me.tName.Name = "tName"
        Me.tName.Size = New System.Drawing.Size(261, 20)
        Me.tName.TabIndex = 49
        Me.tName.Tag = "ProductName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(102, 70)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(261, 21)
        Me.cboCategory.TabIndex = 53
        Me.cboCategory.Tag = "CategoryCode"
        '
        'tReorder
        '
        Me.tReorder.Location = New System.Drawing.Point(101, 93)
        Me.tReorder.Name = "tReorder"
        Me.tReorder.Size = New System.Drawing.Size(114, 20)
        Me.tReorder.TabIndex = 198
        Me.tReorder.Tag = "ReorderLevel"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 201
        Me.Label6.Text = "Max. Qty:"
        '
        'tMaxQty
        '
        Me.tMaxQty.Location = New System.Drawing.Point(101, 114)
        Me.tMaxQty.Name = "tMaxQty"
        Me.tMaxQty.Size = New System.Drawing.Size(114, 20)
        Me.tMaxQty.TabIndex = 200
        Me.tMaxQty.Tag = "MaxQty"
        '
        'tUnitInStore
        '
        Me.tUnitInStore.BackColor = System.Drawing.Color.Khaki
        Me.tUnitInStore.Location = New System.Drawing.Point(101, 268)
        Me.tUnitInStore.Name = "tUnitInStore"
        Me.tUnitInStore.ReadOnly = True
        Me.tUnitInStore.Size = New System.Drawing.Size(65, 20)
        Me.tUnitInStore.TabIndex = 210
        Me.tUnitInStore.Tag = "UnitInStore"
        '
        'chkDiscontinue
        '
        Me.chkDiscontinue.AutoSize = True
        Me.chkDiscontinue.Location = New System.Drawing.Point(279, 267)
        Me.chkDiscontinue.Name = "chkDiscontinue"
        Me.chkDiscontinue.Size = New System.Drawing.Size(82, 17)
        Me.chkDiscontinue.TabIndex = 223
        Me.chkDiscontinue.Text = "Discontinue"
        Me.chkDiscontinue.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(267, 102)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(72, 72)
        Me.CmdCancel.TabIndex = 226
        Me.CmdCancel.Text = "&Close"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Approved Rate:"
        '
        'tRate
        '
        Me.tRate.Location = New System.Drawing.Point(101, 135)
        Me.tRate.Name = "tRate"
        Me.tRate.Size = New System.Drawing.Size(114, 20)
        Me.tRate.TabIndex = 248
        Me.tRate.Tag = "MaxQty"
        '
        'tDesc
        '
        Me.tDesc.Location = New System.Drawing.Point(101, 156)
        Me.tDesc.Multiline = True
        Me.tDesc.Name = "tDesc"
        Me.tDesc.Size = New System.Drawing.Size(155, 44)
        Me.tDesc.TabIndex = 251
        Me.tDesc.Tag = "ProductDesc"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 254
        Me.Label10.Text = "Remark:"
        '
        'tRemark
        '
        Me.tRemark.Location = New System.Drawing.Point(101, 225)
        Me.tRemark.Multiline = True
        Me.tRemark.Name = "tRemark"
        Me.tRemark.Size = New System.Drawing.Size(260, 40)
        Me.tRemark.TabIndex = 253
        Me.tRemark.Tag = "Remark"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lnkImage)
        Me.Panel1.Controls.Add(Me.tID)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lnkEDoc)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cShelfLocation)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.tCode)
        Me.Panel1.Controls.Add(Me.tRemark)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.tName)
        Me.Panel1.Controls.Add(Me.tDesc)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboCategory)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tReorder)
        Me.Panel1.Controls.Add(Me.tRate)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.tMaxQty)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.tUnitInStore)
        Me.Panel1.Controls.Add(Me.lblUnitInStock)
        Me.Panel1.Controls.Add(Me.chkDiscontinue)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 305)
        Me.Panel1.TabIndex = 255
        '
        'lnkImage
        '
        Me.lnkImage.AutoSize = True
        Me.lnkImage.Location = New System.Drawing.Point(293, 285)
        Me.lnkImage.Name = "lnkImage"
        Me.lnkImage.Size = New System.Drawing.Size(67, 13)
        Me.lnkImage.TabIndex = 261
        Me.lnkImage.TabStop = True
        Me.lnkImage.Text = "Stock Image"
        '
        'tID
        '
        Me.tID.BackColor = System.Drawing.Color.Khaki
        Me.tID.Enabled = False
        Me.tID.Location = New System.Drawing.Point(101, 6)
        Me.tID.Name = "tID"
        Me.tID.Size = New System.Drawing.Size(114, 20)
        Me.tID.TabIndex = 259
        Me.tID.Tag = "ProductCode"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 260
        Me.Label11.Text = "ID:"
        '
        'lnkEDoc
        '
        Me.lnkEDoc.AutoSize = True
        Me.lnkEDoc.Location = New System.Drawing.Point(225, 286)
        Me.lnkEDoc.Name = "lnkEDoc"
        Me.lnkEDoc.Size = New System.Drawing.Size(66, 13)
        Me.lnkEDoc.TabIndex = 1
        Me.lnkEDoc.TabStop = True
        Me.lnkEDoc.Text = "E-Document"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 255
        Me.Label9.Text = "Shelf Location:"
        '
        'cShelfLocation
        '
        Me.cShelfLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cShelfLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cShelfLocation.FormattingEnabled = True
        Me.cShelfLocation.Location = New System.Drawing.Point(102, 202)
        Me.cShelfLocation.Name = "cShelfLocation"
        Me.cShelfLocation.Size = New System.Drawing.Size(257, 21)
        Me.cShelfLocation.TabIndex = 256
        Me.cShelfLocation.Tag = "ShelfLocation"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Product Code:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 252
        Me.Label18.Text = "Description:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 249
        Me.Label16.Text = "Approved Rate:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Reorder Level:"
        '
        'lblUnitInStock
        '
        Me.lblUnitInStock.AutoSize = True
        Me.lblUnitInStock.Location = New System.Drawing.Point(9, 272)
        Me.lblUnitInStock.Name = "lblUnitInStock"
        Me.lblUnitInStock.Size = New System.Drawing.Size(68, 13)
        Me.lblUnitInStock.TabIndex = 211
        Me.lblUnitInStock.Text = "Unit in Store:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(260, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(2, 75)
        Me.GroupBox2.TabIndex = 224
        Me.GroupBox2.TabStop = False
        '
        'PanStore
        '
        Me.PanStore.Controls.Add(Me.cStore)
        Me.PanStore.Controls.Add(Me.Label35)
        Me.PanStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanStore.Location = New System.Drawing.Point(3, 3)
        Me.PanStore.Name = "PanStore"
        Me.PanStore.Size = New System.Drawing.Size(569, 25)
        Me.PanStore.TabIndex = 258
        '
        'cStore
        '
        Me.cStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cStore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cStore.FormattingEnabled = True
        Me.cStore.Location = New System.Drawing.Point(45, 1)
        Me.cStore.Name = "cStore"
        Me.cStore.Size = New System.Drawing.Size(145, 21)
        Me.cStore.TabIndex = 272
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(10, 6)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(35, 13)
        Me.Label35.TabIndex = 271
        Me.Label35.Text = "Store:"
        '
        'tblMain
        '
        Me.tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblMain.ColumnCount = 2
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.Controls.Add(Me.tblBatchImage, 1, 1)
        Me.tblMain.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.tblMain.Controls.Add(Me.AppHeader1, 0, 0)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 2
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Size = New System.Drawing.Size(962, 560)
        Me.tblMain.TabIndex = 256
        '
        'tblBatchImage
        '
        Me.tblBatchImage.ColumnCount = 1
        Me.tblBatchImage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblBatchImage.Controls.Add(Me.PictStockItem, 0, 1)
        Me.tblBatchImage.Controls.Add(Me.Panel1, 0, 0)
        Me.tblBatchImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblBatchImage.Location = New System.Drawing.Point(586, 52)
        Me.tblBatchImage.Name = "tblBatchImage"
        Me.tblBatchImage.RowCount = 2
        Me.tblBatchImage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblBatchImage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblBatchImage.Size = New System.Drawing.Size(372, 504)
        Me.tblBatchImage.TabIndex = 256
        '
        'PictStockItem
        '
        Me.PictStockItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.PictStockItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictStockItem.Location = New System.Drawing.Point(93, 314)
        Me.PictStockItem.Name = "PictStockItem"
        Me.PictStockItem.Size = New System.Drawing.Size(186, 187)
        Me.PictStockItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictStockItem.TabIndex = 234
        Me.PictStockItem.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DGrid, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PanStore, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 52)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(575, 504)
        Me.TableLayoutPanel1.TabIndex = 257
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
        Me.DGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite
        Me.DGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.BackgroundColor = System.Drawing.Color.Khaki
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(3, 34)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.RowHeadersWidth = 23
        Me.DGrid.Size = New System.Drawing.Size(569, 467)
        Me.DGrid.TabIndex = 280
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.tblMain.SetColumnSpan(Me.AppHeader1, 2)
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppHeader1.Location = New System.Drawing.Point(1, 1)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(960, 47)
        Me.AppHeader1.TabIndex = 258
        '
        'StkFrmItemHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(962, 560)
        Me.Controls.Add(Me.tblMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StkFrmItemHistory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Items History"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanStore.ResumeLayout(False)
        Me.PanStore.PerformLayout()
        Me.tblMain.ResumeLayout(False)
        Me.tblBatchImage.ResumeLayout(False)
        CType(Me.PictStockItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents tReorder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tMaxQty As System.Windows.Forms.TextBox
    Friend WithEvents tUnitInStore As System.Windows.Forms.TextBox
    Friend WithEvents chkDiscontinue As System.Windows.Forms.CheckBox
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tRate As System.Windows.Forms.TextBox
    Friend WithEvents tDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tRemark As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cShelfLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblUnitInStock As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PanStore As System.Windows.Forms.Panel
    Friend WithEvents cStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tblMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lnkEDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lnkImage As System.Windows.Forms.LinkLabel
    Friend WithEvents tblBatchImage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictStockItem As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
