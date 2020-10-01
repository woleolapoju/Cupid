<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StkFrmEDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StkFrmEDoc))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdStock = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tRefNo = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tNewFilename = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tDocDir = New System.Windows.Forms.TextBox()
        Me.chkMove = New System.Windows.Forms.CheckBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmdGetFile = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tFileName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LB = New System.Windows.Forms.ListBox()
        Me.cMenuDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPreviewFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanBody = New System.Windows.Forms.Panel()
        Me.RadeDoc = New System.Windows.Forms.RadioButton()
        Me.RadPicture = New System.Windows.Forms.RadioButton()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.cMenuDeleteR = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPreviewFileR = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteFileR = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowRecordR = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.cMenuDelete.SuspendLayout()
        Me.PanBody.SuspendLayout()
        Me.cMenuDeleteR.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(349, 33)
        Me.Panel1.TabIndex = 127
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Khaki
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdStock)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.tRefNo)
        Me.Panel2.Location = New System.Drawing.Point(4, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(183, 27)
        Me.Panel2.TabIndex = 232
        '
        'cmdStock
        '
        Me.cmdStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStock.Location = New System.Drawing.Point(150, 2)
        Me.cmdStock.Name = "cmdStock"
        Me.cmdStock.Size = New System.Drawing.Size(27, 21)
        Me.cmdStock.TabIndex = 200
        Me.cmdStock.Text = "..."
        Me.cmdStock.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(0, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Ref. No:"
        '
        'tRefNo
        '
        Me.tRefNo.Location = New System.Drawing.Point(49, 2)
        Me.tRefNo.Name = "tRefNo"
        Me.tRefNo.Size = New System.Drawing.Size(100, 20)
        Me.tRefNo.TabIndex = 181
        Me.tRefNo.Tag = "RctNo"
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(187, 90)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(148, 42)
        Me.cmdClose.TabIndex = 231
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdOk.Location = New System.Drawing.Point(5, 90)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(141, 42)
        Me.cmdOk.TabIndex = 230
        Me.cmdOk.Text = "&Upload"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.WebBrowser, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AppHeader1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(647, 367)
        Me.TableLayoutPanel1.TabIndex = 128
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 83)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(349, 280)
        Me.TableLayoutPanel2.TabIndex = 234
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.cmdClose)
        Me.Panel4.Controls.Add(Me.chkMove)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.cmdOk)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(342, 139)
        Me.Panel4.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.tNewFilename)
        Me.Panel7.Location = New System.Drawing.Point(5, 58)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(333, 27)
        Me.Panel7.TabIndex = 235
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "FileName:"
        '
        'tNewFilename
        '
        Me.tNewFilename.Location = New System.Drawing.Point(64, 2)
        Me.tNewFilename.Name = "tNewFilename"
        Me.tNewFilename.Size = New System.Drawing.Size(264, 20)
        Me.tNewFilename.TabIndex = 181
        Me.tNewFilename.Tag = "RctNo"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.tDocDir)
        Me.Panel5.Location = New System.Drawing.Point(245, 33)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(81, 23)
        Me.Panel5.TabIndex = 233
        Me.Panel5.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "Document Dir:"
        '
        'tDocDir
        '
        Me.tDocDir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tDocDir.Location = New System.Drawing.Point(78, 2)
        Me.tDocDir.Name = "tDocDir"
        Me.tDocDir.ReadOnly = True
        Me.tDocDir.Size = New System.Drawing.Size(245, 20)
        Me.tDocDir.TabIndex = 181
        Me.tDocDir.Tag = "RctNo"
        '
        'chkMove
        '
        Me.chkMove.AutoSize = True
        Me.chkMove.ForeColor = System.Drawing.Color.Maroon
        Me.chkMove.Location = New System.Drawing.Point(70, 37)
        Me.chkMove.Name = "chkMove"
        Me.chkMove.Size = New System.Drawing.Size(151, 17)
        Me.chkMove.TabIndex = 234
        Me.chkMove.Text = "Delete source after upload"
        Me.chkMove.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.cmdGetFile)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.tFileName)
        Me.Panel6.Location = New System.Drawing.Point(6, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(332, 27)
        Me.Panel6.TabIndex = 233
        '
        'cmdGetFile
        '
        Me.cmdGetFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGetFile.Location = New System.Drawing.Point(294, 2)
        Me.cmdGetFile.Name = "cmdGetFile"
        Me.cmdGetFile.Size = New System.Drawing.Size(33, 21)
        Me.cmdGetFile.TabIndex = 200
        Me.cmdGetFile.Text = "..."
        Me.cmdGetFile.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Source File:"
        '
        'tFileName
        '
        Me.tFileName.Location = New System.Drawing.Point(63, 3)
        Me.tFileName.Name = "tFileName"
        Me.tFileName.Size = New System.Drawing.Size(229, 20)
        Me.tFileName.TabIndex = 181
        Me.tFileName.Tag = "RctNo"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LB, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.PanBody, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 148)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(343, 129)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'LB
        '
        Me.LB.BackColor = System.Drawing.Color.Khaki
        Me.LB.ContextMenuStrip = Me.cMenuDelete
        Me.LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB.ForeColor = System.Drawing.Color.Black
        Me.LB.FormattingEnabled = True
        Me.LB.HorizontalScrollbar = True
        Me.LB.Location = New System.Drawing.Point(3, 31)
        Me.LB.Name = "LB"
        Me.LB.Size = New System.Drawing.Size(337, 95)
        Me.LB.TabIndex = 0
        '
        'cMenuDelete
        '
        Me.cMenuDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewFile, Me.ToolStripMenuItem1, Me.mnuDeleteFile, Me.ToolStripMenuItem2, Me.mnuShowRecord})
        Me.cMenuDelete.Name = "cMenuDelete"
        Me.cMenuDelete.ShowImageMargin = False
        Me.cMenuDelete.Size = New System.Drawing.Size(132, 82)
        Me.cMenuDelete.Text = "Delete File"
        '
        'mnuPreviewFile
        '
        Me.mnuPreviewFile.Name = "mnuPreviewFile"
        Me.mnuPreviewFile.Size = New System.Drawing.Size(131, 22)
        Me.mnuPreviewFile.Text = "Open Externally"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 6)
        '
        'mnuDeleteFile
        '
        Me.mnuDeleteFile.Name = "mnuDeleteFile"
        Me.mnuDeleteFile.Size = New System.Drawing.Size(131, 22)
        Me.mnuDeleteFile.Text = "Delete File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(128, 6)
        '
        'mnuShowRecord
        '
        Me.mnuShowRecord.Name = "mnuShowRecord"
        Me.mnuShowRecord.Size = New System.Drawing.Size(131, 22)
        Me.mnuShowRecord.Text = "Show Record"
        '
        'PanBody
        '
        Me.PanBody.Controls.Add(Me.RadeDoc)
        Me.PanBody.Controls.Add(Me.RadPicture)
        Me.PanBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanBody.Location = New System.Drawing.Point(0, 1)
        Me.PanBody.Margin = New System.Windows.Forms.Padding(0, 1, 3, 1)
        Me.PanBody.Name = "PanBody"
        Me.PanBody.Size = New System.Drawing.Size(340, 26)
        Me.PanBody.TabIndex = 0
        Me.PanBody.Visible = False
        '
        'RadeDoc
        '
        Me.RadeDoc.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadeDoc.AutoSize = True
        Me.RadeDoc.Location = New System.Drawing.Point(64, 1)
        Me.RadeDoc.Name = "RadeDoc"
        Me.RadeDoc.Size = New System.Drawing.Size(93, 23)
        Me.RadeDoc.TabIndex = 1
        Me.RadeDoc.Text = "EDOCUMENTS"
        Me.RadeDoc.UseVisualStyleBackColor = True
        '
        'RadPicture
        '
        Me.RadPicture.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadPicture.AutoSize = True
        Me.RadPicture.Checked = True
        Me.RadPicture.FlatAppearance.BorderSize = 2
        Me.RadPicture.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lavender
        Me.RadPicture.Location = New System.Drawing.Point(0, 1)
        Me.RadPicture.Name = "RadPicture"
        Me.RadPicture.Size = New System.Drawing.Size(64, 23)
        Me.RadPicture.TabIndex = 0
        Me.RadPicture.TabStop = True
        Me.RadPicture.Text = "PICTURE"
        Me.RadPicture.UseVisualStyleBackColor = True
        '
        'WebBrowser
        '
        Me.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser.Location = New System.Drawing.Point(360, 4)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.TableLayoutPanel1.SetRowSpan(Me.WebBrowser, 3)
        Me.WebBrowser.Size = New System.Drawing.Size(283, 359)
        Me.WebBrowser.TabIndex = 267
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppHeader1.Location = New System.Drawing.Point(2, 2)
        Me.AppHeader1.Margin = New System.Windows.Forms.Padding(1)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(353, 36)
        Me.AppHeader1.TabIndex = 126
        '
        'cMenuDeleteR
        '
        Me.cMenuDeleteR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewFileR, Me.ToolStripSeparator1, Me.mnuDeleteFileR, Me.ToolStripMenuItem3, Me.mnuShowRecordR})
        Me.cMenuDeleteR.Name = "cMenuDelete"
        Me.cMenuDeleteR.ShowImageMargin = False
        Me.cMenuDeleteR.Size = New System.Drawing.Size(132, 82)
        Me.cMenuDeleteR.Text = "Delete File"
        '
        'mnuPreviewFileR
        '
        Me.mnuPreviewFileR.Name = "mnuPreviewFileR"
        Me.mnuPreviewFileR.Size = New System.Drawing.Size(131, 22)
        Me.mnuPreviewFileR.Text = "Open Externally"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(128, 6)
        '
        'mnuDeleteFileR
        '
        Me.mnuDeleteFileR.Name = "mnuDeleteFileR"
        Me.mnuDeleteFileR.Size = New System.Drawing.Size(131, 22)
        Me.mnuDeleteFileR.Text = "Delete File"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(128, 6)
        '
        'mnuShowRecordR
        '
        Me.mnuShowRecordR.Name = "mnuShowRecordR"
        Me.mnuShowRecordR.Size = New System.Drawing.Size(131, 22)
        Me.mnuShowRecordR.Text = "Show Record"
        '
        'StkFrmEDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(647, 367)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StkFrmEDoc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Document Processing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.cMenuDelete.ResumeLayout(False)
        Me.PanBody.ResumeLayout(False)
        Me.PanBody.PerformLayout()
        Me.cMenuDeleteR.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdStock As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tDocDir As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents chkMove As System.Windows.Forms.CheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cmdGetFile As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tFileName As System.Windows.Forms.TextBox
    Friend WithEvents LB As System.Windows.Forms.ListBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tNewFilename As System.Windows.Forms.TextBox
    Friend WithEvents cMenuDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDeleteFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuShowRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cMenuDeleteR As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPreviewFileR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteFileR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuShowRecordR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanBody As System.Windows.Forms.Panel
    Friend WithEvents RadeDoc As System.Windows.Forms.RadioButton
    Friend WithEvents RadPicture As System.Windows.Forms.RadioButton
End Class
