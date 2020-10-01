<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stkFrmBatches
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stkFrmBatches))
        Me.lblAction = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tBatchNo = New System.Windows.Forms.TextBox()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpMadeDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.chkDiscontinue = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GrpBatches = New System.Windows.Forms.GroupBox()
        Me.PanListCmd = New System.Windows.Forms.Panel()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.cmdInsert = New System.Windows.Forms.Button()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tName = New System.Windows.Forms.TextBox()
        Me.tCode = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GrpBatches.SuspendLayout()
        Me.PanListCmd.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAction
        '
        Me.lblAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAction.BackColor = System.Drawing.Color.Transparent
        Me.lblAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAction.ForeColor = System.Drawing.Color.Red
        Me.lblAction.Location = New System.Drawing.Point(210, 10)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(147, 18)
        Me.lblAction.TabIndex = 9
        Me.lblAction.Text = "?"
        Me.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Batch No:"
        '
        'tBatchNo
        '
        Me.tBatchNo.Location = New System.Drawing.Point(77, 26)
        Me.tBatchNo.Name = "tBatchNo"
        Me.tBatchNo.Size = New System.Drawing.Size(100, 20)
        Me.tBatchNo.TabIndex = 214
        Me.tBatchNo.Tag = "BatchNo"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiryDate.Location = New System.Drawing.Point(78, 70)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpExpiryDate.TabIndex = 226
        Me.dtpExpiryDate.Tag = "ExpiryDate"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(4, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "Expiry Date:"
        '
        'dtpMadeDate
        '
        Me.dtpMadeDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpMadeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpMadeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMadeDate.Location = New System.Drawing.Point(78, 48)
        Me.dtpMadeDate.Name = "dtpMadeDate"
        Me.dtpMadeDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpMadeDate.TabIndex = 224
        Me.dtpMadeDate.Tag = "DateMade"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(4, 54)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(63, 13)
        Me.lblDate.TabIndex = 225
        Me.lblDate.Text = "Date Made:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(5, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 5)
        Me.GroupBox1.TabIndex = 230
        Me.GroupBox1.TabStop = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.Transparent
        Me.cmdOk.Location = New System.Drawing.Point(287, 26)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(72, 47)
        Me.cmdOk.TabIndex = 228
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(287, 74)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(72, 33)
        Me.CmdCancel.TabIndex = 229
        Me.CmdCancel.Text = "&Close"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'chkDiscontinue
        '
        Me.chkDiscontinue.AutoSize = True
        Me.chkDiscontinue.Location = New System.Drawing.Point(78, 91)
        Me.chkDiscontinue.Name = "chkDiscontinue"
        Me.chkDiscontinue.Size = New System.Drawing.Size(82, 17)
        Me.chkDiscontinue.TabIndex = 238
        Me.chkDiscontinue.Text = "Discontinue"
        Me.chkDiscontinue.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GrpBatches, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 41)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(371, 385)
        Me.TableLayoutPanel1.TabIndex = 249
        '
        'GrpBatches
        '
        Me.GrpBatches.Controls.Add(Me.PanListCmd)
        Me.GrpBatches.Controls.Add(Me.lvList)
        Me.GrpBatches.Controls.Add(Me.lblAction)
        Me.GrpBatches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBatches.Location = New System.Drawing.Point(3, 122)
        Me.GrpBatches.Name = "GrpBatches"
        Me.GrpBatches.Size = New System.Drawing.Size(365, 260)
        Me.GrpBatches.TabIndex = 234
        Me.GrpBatches.TabStop = False
        '
        'PanListCmd
        '
        Me.PanListCmd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanListCmd.Controls.Add(Me.cmdDelete)
        Me.PanListCmd.Controls.Add(Me.cmdOpen)
        Me.PanListCmd.Controls.Add(Me.cmdInsert)
        Me.PanListCmd.Location = New System.Drawing.Point(3, 5)
        Me.PanListCmd.Name = "PanListCmd"
        Me.PanListCmd.Size = New System.Drawing.Size(99, 26)
        Me.PanListCmd.TabIndex = 229
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdDelete.Image = Global.Cupid.My.Resources.Resources.CUT
        Me.cmdDelete.Location = New System.Drawing.Point(56, 3)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(27, 23)
        Me.cmdDelete.TabIndex = 199
        '
        'cmdOpen
        '
        Me.cmdOpen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOpen.Image = Global.Cupid.My.Resources.Resources.OPEN
        Me.cmdOpen.Location = New System.Drawing.Point(28, 3)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(27, 23)
        Me.cmdOpen.TabIndex = 198
        '
        'cmdInsert
        '
        Me.cmdInsert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdInsert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdInsert.Image = Global.Cupid.My.Resources.Resources.NEW1
        Me.cmdInsert.Location = New System.Drawing.Point(0, 3)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(27, 23)
        Me.cmdInsert.TabIndex = 197
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.Color.Khaki
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.Location = New System.Drawing.Point(3, 33)
        Me.lvList.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
        Me.lvList.MultiSelect = False
        Me.lvList.Name = "lvList"
        Me.lvList.ShowItemToolTips = True
        Me.lvList.Size = New System.Drawing.Size(359, 224)
        Me.lvList.TabIndex = 230
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sn"
        Me.ColumnHeader8.Width = 28
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Batch No"
        Me.ColumnHeader2.Width = 84
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Date Made"
        Me.ColumnHeader5.Width = 72
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Expiry Date"
        Me.ColumnHeader6.Width = 72
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Discontinued"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 75
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tName)
        Me.Panel1.Controls.Add(Me.tCode)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.tBatchNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkDiscontinue)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Controls.Add(Me.cmdOk)
        Me.Panel1.Controls.Add(Me.dtpMadeDate)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtpExpiryDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(365, 113)
        Me.Panel1.TabIndex = 0
        '
        'tName
        '
        Me.tName.BackColor = System.Drawing.Color.Khaki
        Me.tName.Location = New System.Drawing.Point(176, 4)
        Me.tName.Name = "tName"
        Me.tName.ReadOnly = True
        Me.tName.Size = New System.Drawing.Size(186, 20)
        Me.tName.TabIndex = 241
        Me.tName.Tag = "ProductName"
        '
        'tCode
        '
        Me.tCode.BackColor = System.Drawing.Color.Khaki
        Me.tCode.Location = New System.Drawing.Point(77, 4)
        Me.tCode.Name = "tCode"
        Me.tCode.ReadOnly = True
        Me.tCode.Size = New System.Drawing.Size(98, 20)
        Me.tCode.TabIndex = 239
        Me.tCode.Tag = "ProductCode"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 240
        Me.Label19.Text = "Product Code:"
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(371, 41)
        Me.AppHeader1.TabIndex = 248
        '
        'stkFrmBatches
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(371, 426)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.AppHeader1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stkFrmBatches"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Batches"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GrpBatches.ResumeLayout(False)
        Me.PanListCmd.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAction As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpMadeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkDiscontinue As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpBatches As System.Windows.Forms.GroupBox
    Friend WithEvents PanListCmd As System.Windows.Forms.Panel
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Public WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents tCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tName As System.Windows.Forms.TextBox
End Class
