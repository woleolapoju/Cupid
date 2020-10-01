<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCoyInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCoyInfo))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.temail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tWebsite = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OwnerLogo = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PB1 = New System.Windows.Forms.PictureBox()
        Me.PB5 = New System.Windows.Forms.PictureBox()
        Me.PB4 = New System.Windows.Forms.PictureBox()
        Me.PB3 = New System.Windows.Forms.PictureBox()
        Me.PB2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.cmdGetBakPath = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tBackupPath = New System.Windows.Forms.TextBox()
        Me.tDocFile = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdGetFile = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.OwnerLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Name:"
        '
        'tName
        '
        Me.tName.AcceptsReturn = True
        Me.tName.Enabled = False
        Me.tName.Location = New System.Drawing.Point(104, 59)
        Me.tName.Multiline = True
        Me.tName.Name = "tName"
        Me.tName.Size = New System.Drawing.Size(226, 40)
        Me.tName.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Address:"
        '
        'tAddress
        '
        Me.tAddress.Location = New System.Drawing.Point(104, 101)
        Me.tAddress.Multiline = True
        Me.tAddress.Name = "tAddress"
        Me.tAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tAddress.Size = New System.Drawing.Size(226, 47)
        Me.tAddress.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Phone:"
        '
        'tPhone
        '
        Me.tPhone.Location = New System.Drawing.Point(104, 150)
        Me.tPhone.Name = "tPhone"
        Me.tPhone.Size = New System.Drawing.Size(226, 20)
        Me.tPhone.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "E-mail:"
        '
        'temail
        '
        Me.temail.Location = New System.Drawing.Point(104, 173)
        Me.temail.Name = "temail"
        Me.temail.Size = New System.Drawing.Size(226, 20)
        Me.temail.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Web Site:"
        '
        'tWebsite
        '
        Me.tWebsite.Location = New System.Drawing.Point(104, 196)
        Me.tWebsite.Name = "tWebsite"
        Me.tWebsite.Size = New System.Drawing.Size(226, 20)
        Me.tWebsite.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Logo"
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdOk.Location = New System.Drawing.Point(217, 439)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 31)
        Me.cmdOk.TabIndex = 20
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(296, 439)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(80, 31)
        Me.CmdCancel.TabIndex = 19
        Me.CmdCancel.Text = "&Close"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OwnerLogo)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(105, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(147, 147)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'OwnerLogo
        '
        Me.OwnerLogo.AccessibleDescription = ""
        Me.OwnerLogo.Location = New System.Drawing.Point(2, 9)
        Me.OwnerLogo.Name = "OwnerLogo"
        Me.OwnerLogo.Size = New System.Drawing.Size(143, 134)
        Me.OwnerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OwnerLogo.TabIndex = 17
        Me.OwnerLogo.TabStop = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(-86, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 30)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "Header Pictures"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(-85, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 39)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "Selectable Body Pictures"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PB1)
        Me.Panel1.Controls.Add(Me.PB5)
        Me.Panel1.Controls.Add(Me.PB4)
        Me.Panel1.Controls.Add(Me.PB3)
        Me.Panel1.Controls.Add(Me.PB2)
        Me.Panel1.Location = New System.Drawing.Point(338, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(214, 146)
        Me.Panel1.TabIndex = 126
        '
        'PB1
        '
        Me.PB1.AccessibleDescription = ""
        Me.PB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB1.Location = New System.Drawing.Point(4, 4)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(66, 65)
        Me.PB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB1.TabIndex = 131
        Me.PB1.TabStop = False
        '
        'PB5
        '
        Me.PB5.AccessibleDescription = ""
        Me.PB5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB5.Location = New System.Drawing.Point(75, 74)
        Me.PB5.Name = "PB5"
        Me.PB5.Size = New System.Drawing.Size(66, 65)
        Me.PB5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB5.TabIndex = 130
        Me.PB5.TabStop = False
        '
        'PB4
        '
        Me.PB4.AccessibleDescription = ""
        Me.PB4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB4.Location = New System.Drawing.Point(143, 4)
        Me.PB4.Name = "PB4"
        Me.PB4.Size = New System.Drawing.Size(66, 65)
        Me.PB4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB4.TabIndex = 129
        Me.PB4.TabStop = False
        '
        'PB3
        '
        Me.PB3.AccessibleDescription = ""
        Me.PB3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB3.Location = New System.Drawing.Point(5, 74)
        Me.PB3.Name = "PB3"
        Me.PB3.Size = New System.Drawing.Size(66, 65)
        Me.PB3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB3.TabIndex = 128
        Me.PB3.TabStop = False
        '
        'PB2
        '
        Me.PB2.AccessibleDescription = ""
        Me.PB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB2.Location = New System.Drawing.Point(74, 4)
        Me.PB2.Name = "PB2"
        Me.PB2.Size = New System.Drawing.Size(66, 65)
        Me.PB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB2.TabIndex = 127
        Me.PB2.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(335, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 30)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Selectable Body Pictures"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(1, 433)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(559, 3)
        Me.GroupBox5.TabIndex = 131
        Me.GroupBox5.TabStop = False
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.Transparent
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(557, 48)
        Me.AppHeader1.TabIndex = 202
        '
        'cmdGetBakPath
        '
        Me.cmdGetBakPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGetBakPath.Location = New System.Drawing.Point(304, 240)
        Me.cmdGetBakPath.Name = "cmdGetBakPath"
        Me.cmdGetBakPath.Size = New System.Drawing.Size(27, 22)
        Me.cmdGetBakPath.TabIndex = 205
        Me.cmdGetBakPath.Text = "..."
        Me.cmdGetBakPath.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 203
        Me.Label8.Text = "Backup Path:"
        '
        'tBackupPath
        '
        Me.tBackupPath.Location = New System.Drawing.Point(105, 241)
        Me.tBackupPath.Name = "tBackupPath"
        Me.tBackupPath.Size = New System.Drawing.Size(196, 20)
        Me.tBackupPath.TabIndex = 204
        '
        'tDocFile
        '
        Me.tDocFile.Location = New System.Drawing.Point(105, 218)
        Me.tDocFile.Name = "tDocFile"
        Me.tDocFile.Size = New System.Drawing.Size(196, 20)
        Me.tDocFile.TabIndex = 133
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "eDoc Path:"
        '
        'cmdGetFile
        '
        Me.cmdGetFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGetFile.Location = New System.Drawing.Point(304, 218)
        Me.cmdGetFile.Name = "cmdGetFile"
        Me.cmdGetFile.Size = New System.Drawing.Size(27, 21)
        Me.cmdGetFile.TabIndex = 201
        Me.cmdGetFile.Text = "..."
        Me.cmdGetFile.UseVisualStyleBackColor = True
        '
        'FrmCoyInfo
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(557, 472)
        Me.Controls.Add(Me.cmdGetBakPath)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tBackupPath)
        Me.Controls.Add(Me.AppHeader1)
        Me.Controls.Add(Me.cmdGetFile)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tDocFile)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.tWebsite)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.temail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tPhone)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCoyInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Information"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.OwnerLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents temail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OwnerLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PB1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB5 As System.Windows.Forms.PictureBox
    Friend WithEvents PB4 As System.Windows.Forms.PictureBox
    Friend WithEvents PB3 As System.Windows.Forms.PictureBox
    Friend WithEvents PB2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents AppHeader1 As Cupid.AppHeader
    Friend WithEvents cmdGetBakPath As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tBackupPath As System.Windows.Forms.TextBox
    Friend WithEvents tDocFile As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdGetFile As System.Windows.Forms.Button
End Class
