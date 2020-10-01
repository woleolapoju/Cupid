<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stkFrmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stkFrmSettings))
        Me.tblHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tVat = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDebitNote = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tDiscount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cPole = New System.Windows.Forms.ComboBox()
        Me.cPOS = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Pan = New System.Windows.Forms.Panel()
        Me.cInvoiceType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkStoreAssignment = New System.Windows.Forms.CheckBox()
        Me.cboTransType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cSalesInputLayout = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tDateDurationValidation = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tblHeader.SuspendLayout()
        Me.Pan.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblHeader
        '
        Me.tblHeader.BackColor = System.Drawing.Color.MintCream
        Me.tblHeader.ColumnCount = 1
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblHeader.Controls.Add(Me.Label7, 0, 0)
        Me.tblHeader.Controls.Add(Me.lblHeader, 0, 1)
        Me.tblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblHeader.Location = New System.Drawing.Point(0, 0)
        Me.tblHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.tblHeader.Name = "tblHeader"
        Me.tblHeader.RowCount = 2
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.76923!))
        Me.tblHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.23077!))
        Me.tblHeader.Size = New System.Drawing.Size(328, 44)
        Me.tblHeader.TabIndex = 51
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.GhostWhite
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(328, 24)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "SETTINGS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.AutoSize = True
        Me.lblHeader.BackColor = System.Drawing.Color.Goldenrod
        Me.lblHeader.Font = New System.Drawing.Font("Segoe Print", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 24)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(328, 20)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "Setup Program Parameters"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(171, 298)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(114, 34)
        Me.cmdClose.TabIndex = 66
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.Color.Lavender
        Me.cmdOk.Location = New System.Drawing.Point(39, 299)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(113, 34)
        Me.cmdOk.TabIndex = 67
        Me.cmdOk.Text = "&Save"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 284)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 10)
        Me.GroupBox1.TabIndex = 226
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "VAT:"
        '
        'tVat
        '
        Me.tVat.Location = New System.Drawing.Point(105, 47)
        Me.tVat.Name = "tVat"
        Me.tVat.Size = New System.Drawing.Size(38, 20)
        Me.tVat.TabIndex = 234
        Me.tVat.Text = "0"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(2, 251)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(274, 10)
        Me.GroupBox3.TabIndex = 227
        Me.GroupBox3.TabStop = False
        '
        'txtDebitNote
        '
        Me.txtDebitNote.Location = New System.Drawing.Point(97, 266)
        Me.txtDebitNote.Multiline = True
        Me.txtDebitNote.Name = "txtDebitNote"
        Me.txtDebitNote.Size = New System.Drawing.Size(174, 20)
        Me.txtDebitNote.TabIndex = 238
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Debit Notice Note"
        '
        'tDiscount
        '
        Me.tDiscount.Location = New System.Drawing.Point(105, 71)
        Me.tDiscount.Name = "tDiscount"
        Me.tDiscount.Size = New System.Drawing.Size(38, 20)
        Me.tDiscount.TabIndex = 240
        Me.tDiscount.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Discount:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "POS Printer:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(144, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(144, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 244
        Me.Label9.Text = "%"
        '
        'cPole
        '
        Me.cPole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cPole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cPole.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cPole.FormattingEnabled = True
        Me.cPole.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3"})
        Me.cPole.Location = New System.Drawing.Point(105, 115)
        Me.cPole.Name = "cPole"
        Me.cPole.Size = New System.Drawing.Size(54, 20)
        Me.cPole.TabIndex = 246
        '
        'cPOS
        '
        Me.cPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cPOS.FormattingEnabled = True
        Me.cPOS.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3"})
        Me.cPOS.Location = New System.Drawing.Point(105, 93)
        Me.cPOS.Name = "cPOS"
        Me.cPOS.Size = New System.Drawing.Size(54, 20)
        Me.cPOS.TabIndex = 245
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 247
        Me.Label10.Text = "Pole Display:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(157, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 248
        Me.Label11.Text = "evaluated"
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrint.ForeColor = System.Drawing.Color.Maroon
        Me.chkPrint.Location = New System.Drawing.Point(103, 141)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(15, 14)
        Me.chkPrint.TabIndex = 556
        Me.chkPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 557
        Me.Label12.Text = "Print Invoice:"
        '
        'Pan
        '
        Me.Pan.Controls.Add(Me.cInvoiceType)
        Me.Pan.Controls.Add(Me.Label13)
        Me.Pan.Location = New System.Drawing.Point(123, 141)
        Me.Pan.Name = "Pan"
        Me.Pan.Size = New System.Drawing.Size(114, 24)
        Me.Pan.TabIndex = 558
        Me.Pan.Visible = False
        '
        'cInvoiceType
        '
        Me.cInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cInvoiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cInvoiceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cInvoiceType.FormattingEnabled = True
        Me.cInvoiceType.Items.AddRange(New Object() {"POS", "Standard"})
        Me.cInvoiceType.Location = New System.Drawing.Point(34, 1)
        Me.cInvoiceType.Name = "cInvoiceType"
        Me.cInvoiceType.Size = New System.Drawing.Size(78, 20)
        Me.cInvoiceType.TabIndex = 247
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 246
        Me.Label13.Text = "Type:"
        '
        'chkStoreAssignment
        '
        Me.chkStoreAssignment.AutoSize = True
        Me.chkStoreAssignment.Location = New System.Drawing.Point(174, 115)
        Me.chkStoreAssignment.Name = "chkStoreAssignment"
        Me.chkStoreAssignment.Size = New System.Drawing.Size(141, 17)
        Me.chkStoreAssignment.TabIndex = 560
        Me.chkStoreAssignment.Text = "&Ignore Store Assignment"
        Me.chkStoreAssignment.UseVisualStyleBackColor = True
        '
        'cboTransType
        '
        Me.cboTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTransType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTransType.FormattingEnabled = True
        Me.cboTransType.Items.AddRange(New Object() {"Retail", "Service", "Both"})
        Me.cboTransType.Location = New System.Drawing.Point(103, 170)
        Me.cboTransType.Name = "cboTransType"
        Me.cboTransType.Size = New System.Drawing.Size(135, 21)
        Me.cboTransType.TabIndex = 561
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 562
        Me.Label2.Text = "Transaction Type:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 564
        Me.Label8.Text = "Sales Input Layout:"
        '
        'cSalesInputLayout
        '
        Me.cSalesInputLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSalesInputLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cSalesInputLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSalesInputLayout.FormattingEnabled = True
        Me.cSalesInputLayout.Items.AddRange(New Object() {"Standard", "Button", "Mini"})
        Me.cSalesInputLayout.Location = New System.Drawing.Point(103, 198)
        Me.cSalesInputLayout.Name = "cSalesInputLayout"
        Me.cSalesInputLayout.Size = New System.Drawing.Size(135, 21)
        Me.cSalesInputLayout.TabIndex = 563
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 30)
        Me.Label14.TabIndex = 565
        Me.Label14.Text = "Date Duration Validation:"
        '
        'tDateDurationValidation
        '
        Me.tDateDurationValidation.Location = New System.Drawing.Point(102, 224)
        Me.tDateDurationValidation.Name = "tDateDurationValidation"
        Me.tDateDurationValidation.Size = New System.Drawing.Size(44, 20)
        Me.tDateDurationValidation.TabIndex = 566
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(148, 228)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 567
        Me.Label15.Text = "-1 For Indefinate"
        '
        'stkFrmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(328, 334)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tDateDurationValidation)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cSalesInputLayout)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTransType)
        Me.Controls.Add(Me.chkStoreAssignment)
        Me.Controls.Add(Me.Pan)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chkPrint)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cPole)
        Me.Controls.Add(Me.cPOS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tDiscount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDebitNote)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tVat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tblHeader)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "stkFrmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.tblHeader.ResumeLayout(False)
        Me.tblHeader.PerformLayout()
        Me.Pan.ResumeLayout(False)
        Me.Pan.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tVat As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDebitNote As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cPole As System.Windows.Forms.ComboBox
    Friend WithEvents cPOS As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Pan As System.Windows.Forms.Panel
    Friend WithEvents cInvoiceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkStoreAssignment As System.Windows.Forms.CheckBox
    Friend WithEvents cboTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cSalesInputLayout As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tDateDurationValidation As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
