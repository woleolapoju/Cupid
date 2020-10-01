<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StkFrmItemRegister4Service
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StkFrmItemRegister4Service))
        Me.lblAction = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.chkDiscontinue = New System.Windows.Forms.CheckBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.tDesc = New System.Windows.Forms.TextBox()
        Me.tRemark = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanPrevID = New System.Windows.Forms.Panel()
        Me.tPrevID = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PanBatch = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.SelectIt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Store = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.PictStockItem = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.PanPrevID.SuspendLayout()
        Me.PanBatch.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblMain.SuspendLayout()
        CType(Me.PictStockItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAction
        '
        Me.lblAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAction.ForeColor = System.Drawing.Color.Red
        Me.lblAction.Location = New System.Drawing.Point(224, 27)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(138, 19)
        Me.lblAction.TabIndex = 11
        Me.lblAction.Text = "?"
        Me.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Code:"
        '
        'tCode
        '
        Me.tCode.Location = New System.Drawing.Point(101, 28)
        Me.tCode.Name = "tCode"
        Me.tCode.Size = New System.Drawing.Size(114, 20)
        Me.tCode.TabIndex = 0
        Me.tCode.Tag = "ProductCode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Item Name;"
        '
        'tName
        '
        Me.tName.Location = New System.Drawing.Point(101, 49)
        Me.tName.Name = "tName"
        Me.tName.Size = New System.Drawing.Size(261, 20)
        Me.tName.TabIndex = 1
        Me.tName.Tag = "ProductName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(102, 70)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(259, 21)
        Me.cboCategory.TabIndex = 2
        Me.cboCategory.Tag = "CategoryCode"
        '
        'chkDiscontinue
        '
        Me.chkDiscontinue.AutoSize = True
        Me.chkDiscontinue.Location = New System.Drawing.Point(282, 157)
        Me.chkDiscontinue.Name = "chkDiscontinue"
        Me.chkDiscontinue.Size = New System.Drawing.Size(82, 17)
        Me.chkDiscontinue.TabIndex = 223
        Me.chkDiscontinue.Text = "Discontinue"
        Me.chkDiscontinue.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdOk.Location = New System.Drawing.Point(215, 351)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(72, 44)
        Me.cmdOk.TabIndex = 10
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(289, 351)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(72, 44)
        Me.CmdCancel.TabIndex = 11
        Me.CmdCancel.Text = "&Close"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'tDesc
        '
        Me.tDesc.Location = New System.Drawing.Point(101, 93)
        Me.tDesc.Name = "tDesc"
        Me.tDesc.Size = New System.Drawing.Size(262, 20)
        Me.tDesc.TabIndex = 7
        Me.tDesc.Tag = "ProductDesc"
        '
        'tRemark
        '
        Me.tRemark.Location = New System.Drawing.Point(101, 114)
        Me.tRemark.Multiline = True
        Me.tRemark.Name = "tRemark"
        Me.tRemark.Size = New System.Drawing.Size(262, 40)
        Me.tRemark.TabIndex = 9
        Me.tRemark.Tag = "Remark"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictStockItem)
        Me.Panel1.Controls.Add(Me.PanPrevID)
        Me.Panel1.Controls.Add(Me.tID)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.PanBatch)
        Me.Panel1.Controls.Add(Me.lblAction)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.tCode)
        Me.Panel1.Controls.Add(Me.tRemark)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.tName)
        Me.Panel1.Controls.Add(Me.tDesc)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboCategory)
        Me.Panel1.Controls.Add(Me.chkDiscontinue)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.cmdOk)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 401)
        Me.Panel1.TabIndex = 255
        '
        'PanPrevID
        '
        Me.PanPrevID.Controls.Add(Me.tPrevID)
        Me.PanPrevID.Controls.Add(Me.Label37)
        Me.PanPrevID.Location = New System.Drawing.Point(250, 5)
        Me.PanPrevID.Name = "PanPrevID"
        Me.PanPrevID.Size = New System.Drawing.Size(111, 22)
        Me.PanPrevID.TabIndex = 264
        Me.PanPrevID.Visible = False
        '
        'tPrevID
        '
        Me.tPrevID.BackColor = System.Drawing.Color.Khaki
        Me.tPrevID.Enabled = False
        Me.tPrevID.Location = New System.Drawing.Point(55, 1)
        Me.tPrevID.Name = "tPrevID"
        Me.tPrevID.Size = New System.Drawing.Size(53, 20)
        Me.tPrevID.TabIndex = 262
        Me.tPrevID.Tag = "ProductCode"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(1, 5)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(49, 13)
        Me.Label37.TabIndex = 263
        Me.Label37.Text = "Prev. ID:"
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
        Me.Label11.Location = New System.Drawing.Point(14, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 260
        Me.Label11.Text = "ID:"
        '
        'PanBatch
        '
        Me.PanBatch.Controls.Add(Me.DGrid)
        Me.PanBatch.Location = New System.Drawing.Point(3, 174)
        Me.PanBatch.Name = "PanBatch"
        Me.PanBatch.Size = New System.Drawing.Size(358, 162)
        Me.PanBatch.TabIndex = 257
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
        Me.DGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaShell
        Me.DGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.BackgroundColor = System.Drawing.Color.Khaki
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectIt, Me.Store, Me.CostPrice, Me.SellPrice})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.Location = New System.Drawing.Point(3, 6)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.RowHeadersWidth = 23
        Me.DGrid.Size = New System.Drawing.Size(353, 154)
        Me.DGrid.TabIndex = 281
        '
        'SelectIt
        '
        Me.SelectIt.HeaderText = ""
        Me.SelectIt.Name = "SelectIt"
        Me.SelectIt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SelectIt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SelectIt.Width = 30
        '
        'Store
        '
        Me.Store.HeaderText = "Store"
        Me.Store.Name = "Store"
        Me.Store.ReadOnly = True
        Me.Store.Width = 120
        '
        'CostPrice
        '
        Me.CostPrice.HeaderText = "Cost Price"
        Me.CostPrice.Name = "CostPrice"
        Me.CostPrice.Width = 80
        '
        'SellPrice
        '
        Me.SellPrice.HeaderText = "Sell Price"
        Me.SellPrice.Name = "SellPrice"
        Me.SellPrice.Width = 80
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Item Name;"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 119)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 254
        Me.Label20.Text = "Remark:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Product Code:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 252
        Me.Label18.Text = "Description:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Category:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(82, 343)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 3)
        Me.GroupBox2.TabIndex = 224
        Me.GroupBox2.TabStop = False
        '
        'tblMain
        '
        Me.tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblMain.ColumnCount = 1
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.Controls.Add(Me.Panel1, 0, 1)
        Me.tblMain.Controls.Add(Me.AppHeader1, 0, 0)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 2
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.Size = New System.Drawing.Size(375, 461)
        Me.tblMain.TabIndex = 256
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppHeader1.Location = New System.Drawing.Point(1, 1)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(374, 51)
        Me.AppHeader1.TabIndex = 257
        '
        'PictStockItem
        '
        Me.PictStockItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.PictStockItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictStockItem.Location = New System.Drawing.Point(6, 337)
        Me.PictStockItem.Name = "PictStockItem"
        Me.PictStockItem.Size = New System.Drawing.Size(70, 62)
        Me.PictStockItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictStockItem.TabIndex = 265
        Me.PictStockItem.TabStop = False
        '
        'StkFrmItemRegister4Service
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(375, 461)
        Me.Controls.Add(Me.tblMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StkFrmItemRegister4Service"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Items"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanPrevID.ResumeLayout(False)
        Me.PanPrevID.PerformLayout()
        Me.PanBatch.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblMain.ResumeLayout(False)
        CType(Me.PictStockItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chkDiscontinue As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblAction As System.Windows.Forms.Label
    Friend WithEvents tDesc As System.Windows.Forms.TextBox
    Friend WithEvents tRemark As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PanBatch As System.Windows.Forms.Panel
    Friend WithEvents tblMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tPrevID As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents PanPrevID As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents SelectIt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Store As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictStockItem As System.Windows.Forms.PictureBox
End Class
