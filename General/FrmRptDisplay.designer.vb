<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptDisplay))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.myCrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanList = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPrinters = New System.Windows.Forms.ComboBox()
        Me.cOrientation = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cSize = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdClosePanList = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.PanList.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(366, 28)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(59, 31)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "C&lose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'myCrystalReportViewer
        '
        Me.myCrystalReportViewer.ActiveViewIndex = -1
        Me.myCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.myCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.myCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.myCrystalReportViewer.Location = New System.Drawing.Point(0, 24)
        Me.myCrystalReportViewer.Name = "myCrystalReportViewer"
        Me.myCrystalReportViewer.SelectionFormula = ""
        Me.myCrystalReportViewer.Size = New System.Drawing.Size(606, 358)
        Me.myCrystalReportViewer.TabIndex = 0
        Me.myCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.myCrystalReportViewer.ViewTimeSelectionFormula = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(606, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSHOWPRINTERSETTINGSToolStripMenuItem
        '
        Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem.Name = "mnuSHOWPRINTERSETTINGSToolStripMenuItem"
        Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem.Size = New System.Drawing.Size(158, 20)
        Me.mnuSHOWPRINTERSETTINGSToolStripMenuItem.Text = "SHOW PRINTER SETTINGS"
        '
        'PanList
        '
        Me.PanList.AllowDrop = True
        Me.PanList.BackColor = System.Drawing.Color.Goldenrod
        Me.PanList.Controls.Add(Me.Panel1)
        Me.PanList.Controls.Add(Me.cmdClosePanList)
        Me.PanList.Location = New System.Drawing.Point(2, 54)
        Me.PanList.Name = "PanList"
        Me.PanList.Size = New System.Drawing.Size(258, 120)
        Me.PanList.TabIndex = 274
        Me.PanList.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdApply)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboPrinters)
        Me.Panel1.Controls.Add(Me.cOrientation)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cSize)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(4, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 91)
        Me.Panel1.TabIndex = 275
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(167, 60)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 275
        Me.cmdApply.Text = "APPLY"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 264
        Me.Label4.Text = "Printers:"
        '
        'cboPrinters
        '
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrinters.FormattingEnabled = True
        Me.cboPrinters.Items.AddRange(New Object() {"(Default)", "A4", "A3", "A5", "B4", "B5", "Executive", "FanfoldLegal", "FanfoldStandard", "FanfoldUS", "Legal", "Letter"})
        Me.cboPrinters.Location = New System.Drawing.Point(68, 10)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.Size = New System.Drawing.Size(174, 21)
        Me.cboPrinters.TabIndex = 263
        '
        'cOrientation
        '
        Me.cOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cOrientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cOrientation.FormattingEnabled = True
        Me.cOrientation.Items.AddRange(New Object() {"(Default)", "Portrait", "Landscape"})
        Me.cOrientation.Location = New System.Drawing.Point(68, 59)
        Me.cOrientation.Name = "cOrientation"
        Me.cOrientation.Size = New System.Drawing.Size(92, 21)
        Me.cOrientation.TabIndex = 261
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 60)
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
        Me.cSize.Location = New System.Drawing.Point(68, 34)
        Me.cSize.Name = "cSize"
        Me.cSize.Size = New System.Drawing.Size(174, 21)
        Me.cSize.TabIndex = 259
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Paper Size:"
        '
        'cmdClosePanList
        '
        Me.cmdClosePanList.BackColor = System.Drawing.Color.Firebrick
        Me.cmdClosePanList.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClosePanList.ForeColor = System.Drawing.Color.White
        Me.cmdClosePanList.Location = New System.Drawing.Point(232, 1)
        Me.cmdClosePanList.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
        Me.cmdClosePanList.Name = "cmdClosePanList"
        Me.cmdClosePanList.Size = New System.Drawing.Size(21, 21)
        Me.cmdClosePanList.TabIndex = 274
        Me.cmdClosePanList.Text = "X"
        Me.cmdClosePanList.UseVisualStyleBackColor = False
        '
        'FrmRptDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(606, 382)
        Me.Controls.Add(Me.PanList)
        Me.Controls.Add(Me.myCrystalReportViewer)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmRptDisplay"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanList.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents myCrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuSHOWPRINTERSETTINGSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanList As System.Windows.Forms.Panel
    Friend WithEvents cmdClosePanList As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents cOrientation As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
End Class
