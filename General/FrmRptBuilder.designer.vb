<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptBuilder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptBuilder))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkBrowser = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCondition = New System.Windows.Forms.TextBox()
        Me.lbField = New System.Windows.Forms.ListBox()
        Me.lbTable = New System.Windows.Forms.ListBox()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdDisplay = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdInsert = New System.Windows.Forms.Button()
        Me.cmdOR = New System.Windows.Forms.Button()
        Me.cmdAND = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSortBy = New System.Windows.Forms.ComboBox()
        Me.chkSortOrder = New System.Windows.Forms.CheckBox()
        Me.chkLoadPeriod = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboValue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDataField = New System.Windows.Forms.ComboBox()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkBrowser)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCondition)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbField)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbTable)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblWait)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdClose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdClear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdDisplay)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSQL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvList)
        Me.SplitContainer1.Size = New System.Drawing.Size(924, 534)
        Me.SplitContainer1.SplitterDistance = 600
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 124
        '
        'chkBrowser
        '
        Me.chkBrowser.AutoSize = True
        Me.chkBrowser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBrowser.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkBrowser.Location = New System.Drawing.Point(189, 419)
        Me.chkBrowser.Name = "chkBrowser"
        Me.chkBrowser.Size = New System.Drawing.Size(116, 17)
        Me.chkBrowser.TabIndex = 147
        Me.chkBrowser.Text = "Preview in Browser"
        Me.chkBrowser.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(300, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 13)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Select Report Fields"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Select Database Tables"
        '
        'txtCondition
        '
        Me.txtCondition.Location = New System.Drawing.Point(387, 370)
        Me.txtCondition.Name = "txtCondition"
        Me.txtCondition.Size = New System.Drawing.Size(126, 20)
        Me.txtCondition.TabIndex = 143
        '
        'lbField
        '
        Me.lbField.FormattingEnabled = True
        Me.lbField.Location = New System.Drawing.Point(303, 30)
        Me.lbField.Name = "lbField"
        Me.lbField.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbField.Size = New System.Drawing.Size(279, 199)
        Me.lbField.TabIndex = 142
        '
        'lbTable
        '
        Me.lbTable.FormattingEnabled = True
        Me.lbTable.Location = New System.Drawing.Point(20, 30)
        Me.lbTable.Name = "lbTable"
        Me.lbTable.Size = New System.Drawing.Size(279, 199)
        Me.lbTable.TabIndex = 141
        '
        'lblWait
        '
        Me.lblWait.AutoSize = True
        Me.lblWait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWait.ForeColor = System.Drawing.Color.Blue
        Me.lblWait.Location = New System.Drawing.Point(383, 423)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(80, 13)
        Me.lblWait.TabIndex = 140
        Me.lblWait.Text = "Pls. WAIT !!!"
        Me.lblWait.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(502, 411)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 33)
        Me.cmdClose.TabIndex = 139
        Me.cmdClose.Text = "Cl&ose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(104, 410)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(80, 33)
        Me.cmdClear.TabIndex = 138
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdDisplay
        '
        Me.cmdDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisplay.Location = New System.Drawing.Point(23, 410)
        Me.cmdDisplay.Name = "cmdDisplay"
        Me.cmdDisplay.Size = New System.Drawing.Size(80, 33)
        Me.cmdDisplay.TabIndex = 137
        Me.cmdDisplay.Text = "&Preview"
        Me.cmdDisplay.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(24, 322)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 136
        Me.Label6.Text = "Report Query:"
        '
        'txtSQL
        '
        Me.txtSQL.BackColor = System.Drawing.Color.Khaki
        Me.txtSQL.Location = New System.Drawing.Point(23, 338)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ReadOnly = True
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQL.Size = New System.Drawing.Size(557, 68)
        Me.txtSQL.TabIndex = 135
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdLoad)
        Me.GroupBox1.Controls.Add(Me.cmdInsert)
        Me.GroupBox1.Controls.Add(Me.cmdOR)
        Me.GroupBox1.Controls.Add(Me.cmdAND)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboSortBy)
        Me.GroupBox1.Controls.Add(Me.chkSortOrder)
        Me.GroupBox1.Controls.Add(Me.chkLoadPeriod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboValue)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboCondition)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDataField)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 89)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Condition"
        '
        'cmdLoad
        '
        Me.cmdLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoad.Location = New System.Drawing.Point(512, 33)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(43, 24)
        Me.cmdLoad.TabIndex = 13
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdInsert
        '
        Me.cmdInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsert.ForeColor = System.Drawing.Color.Red
        Me.cmdInsert.Location = New System.Drawing.Point(93, 57)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(97, 27)
        Me.cmdInsert.TabIndex = 12
        Me.cmdInsert.Text = "Insert Criteria"
        Me.cmdInsert.UseVisualStyleBackColor = True
        '
        'cmdOR
        '
        Me.cmdOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOR.Location = New System.Drawing.Point(50, 56)
        Me.cmdOR.Name = "cmdOR"
        Me.cmdOR.Size = New System.Drawing.Size(41, 27)
        Me.cmdOR.TabIndex = 11
        Me.cmdOR.Text = "OR"
        Me.cmdOR.UseVisualStyleBackColor = True
        '
        'cmdAND
        '
        Me.cmdAND.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAND.Location = New System.Drawing.Point(8, 56)
        Me.cmdAND.Name = "cmdAND"
        Me.cmdAND.Size = New System.Drawing.Size(41, 27)
        Me.cmdAND.TabIndex = 10
        Me.cmdAND.Text = "AND"
        Me.cmdAND.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(202, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Sort By:"
        '
        'cboSortBy
        '
        Me.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSortBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Location = New System.Drawing.Point(246, 58)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(168, 21)
        Me.cboSortBy.TabIndex = 8
        '
        'chkSortOrder
        '
        Me.chkSortOrder.AutoSize = True
        Me.chkSortOrder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSortOrder.Checked = True
        Me.chkSortOrder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSortOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSortOrder.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkSortOrder.Location = New System.Drawing.Point(416, 61)
        Me.chkSortOrder.Name = "chkSortOrder"
        Me.chkSortOrder.Size = New System.Drawing.Size(138, 17)
        Me.chkSortOrder.TabIndex = 7
        Me.chkSortOrder.Text = "Sort in Ascending Order"
        Me.chkSortOrder.UseVisualStyleBackColor = True
        '
        'chkLoadPeriod
        '
        Me.chkLoadPeriod.AutoSize = True
        Me.chkLoadPeriod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadPeriod.Checked = True
        Me.chkLoadPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoadPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLoadPeriod.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkLoadPeriod.Location = New System.Drawing.Point(363, 16)
        Me.chkLoadPeriod.Name = "chkLoadPeriod"
        Me.chkLoadPeriod.Size = New System.Drawing.Size(190, 17)
        Me.chkLoadPeriod.TabIndex = 6
        Me.chkLoadPeriod.Text = "Load Values in Current Period Only"
        Me.chkLoadPeriod.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(244, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Value:"
        '
        'cboValue
        '
        Me.cboValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboValue.FormattingEnabled = True
        Me.cboValue.Location = New System.Drawing.Point(246, 35)
        Me.cboValue.Name = "cboValue"
        Me.cboValue.Size = New System.Drawing.Size(265, 21)
        Me.cboValue.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(153, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Condition:"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(155, 35)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(89, 21)
        Me.cboCondition.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select Data Field:"
        '
        'cboDataField
        '
        Me.cboDataField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDataField.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDataField.FormattingEnabled = True
        Me.cboDataField.Location = New System.Drawing.Point(9, 35)
        Me.cboDataField.Name = "cboDataField"
        Me.cboDataField.Size = New System.Drawing.Size(145, 21)
        Me.cboDataField.TabIndex = 0
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.Color.Khaki
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.Location = New System.Drawing.Point(0, 0)
        Me.lvList.MultiSelect = False
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(317, 530)
        Me.lvList.TabIndex = 134
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Result Listings"
        Me.ColumnHeader1.Width = 412
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(924, 41)
        Me.AppHeader1.TabIndex = 122
        '
        'FrmRptBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(924, 575)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.AppHeader1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptBuilder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Builder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdDisplay As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents cmdOR As System.Windows.Forms.Button
    Friend WithEvents cmdAND As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents chkSortOrder As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboValue As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDataField As System.Windows.Forms.ComboBox
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents lblWait As System.Windows.Forms.Label
    Friend WithEvents lbTable As System.Windows.Forms.ListBox
    Friend WithEvents lbField As System.Windows.Forms.ListBox
    Friend WithEvents txtCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkBrowser As System.Windows.Forms.CheckBox
End Class
