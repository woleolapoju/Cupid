<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSvrInfor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSvrInfor))
        Me.GrpServ = New System.Windows.Forms.GroupBox()
        Me.txtAttachName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboServerName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpAuthenticate = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.chkWinAuthen = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrpAttach = New System.Windows.Forms.GroupBox()
        Me.cmdAttach = New System.Windows.Forms.Button()
        Me.cmdDBMain = New System.Windows.Forms.Button()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GrpAdvance = New System.Windows.Forms.GroupBox()
        Me.txtOwner = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.GrpServ.SuspendLayout()
        Me.GrpAuthenticate.SuspendLayout()
        Me.GrpAttach.SuspendLayout()
        Me.GrpAdvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpServ
        '
        Me.GrpServ.Controls.Add(Me.txtAttachName)
        Me.GrpServ.Controls.Add(Me.Label2)
        Me.GrpServ.Controls.Add(Me.cboServerName)
        Me.GrpServ.Controls.Add(Me.Label1)
        Me.GrpServ.Location = New System.Drawing.Point(5, 42)
        Me.GrpServ.Name = "GrpServ"
        Me.GrpServ.Size = New System.Drawing.Size(228, 78)
        Me.GrpServ.TabIndex = 0
        Me.GrpServ.TabStop = False
        Me.GrpServ.Text = "Server Infor"
        '
        'txtAttachName
        '
        Me.txtAttachName.Location = New System.Drawing.Point(84, 47)
        Me.txtAttachName.Name = "txtAttachName"
        Me.txtAttachName.Size = New System.Drawing.Size(138, 20)
        Me.txtAttachName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attached Name:"
        '
        'cboServerName
        '
        Me.cboServerName.FormattingEnabled = True
        Me.cboServerName.Location = New System.Drawing.Point(84, 18)
        Me.cboServerName.Name = "cboServerName"
        Me.cboServerName.Size = New System.Drawing.Size(138, 21)
        Me.cboServerName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Name:"
        '
        'GrpAuthenticate
        '
        Me.GrpAuthenticate.Controls.Add(Me.txtPassword)
        Me.GrpAuthenticate.Controls.Add(Me.txtUserID)
        Me.GrpAuthenticate.Controls.Add(Me.chkWinAuthen)
        Me.GrpAuthenticate.Controls.Add(Me.Label3)
        Me.GrpAuthenticate.Controls.Add(Me.Label4)
        Me.GrpAuthenticate.Location = New System.Drawing.Point(5, 124)
        Me.GrpAuthenticate.Name = "GrpAuthenticate"
        Me.GrpAuthenticate.Size = New System.Drawing.Size(228, 93)
        Me.GrpAuthenticate.TabIndex = 1
        Me.GrpAuthenticate.TabStop = False
        Me.GrpAuthenticate.Text = "Authentication"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(84, 64)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(138, 20)
        Me.txtPassword.TabIndex = 5
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(84, 36)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(138, 20)
        Me.txtUserID.TabIndex = 4
        '
        'chkWinAuthen
        '
        Me.chkWinAuthen.AutoSize = True
        Me.chkWinAuthen.Location = New System.Drawing.Point(9, 19)
        Me.chkWinAuthen.Name = "chkWinAuthen"
        Me.chkWinAuthen.Size = New System.Drawing.Size(141, 17)
        Me.chkWinAuthen.TabIndex = 3
        Me.chkWinAuthen.Text = "Windows Authentication"
        Me.chkWinAuthen.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkWinAuthen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "User ID:"
        '
        'GrpAttach
        '
        Me.GrpAttach.Controls.Add(Me.cmdAttach)
        Me.GrpAttach.Controls.Add(Me.cmdDBMain)
        Me.GrpAttach.Controls.Add(Me.txtDBName)
        Me.GrpAttach.Controls.Add(Me.Label6)
        Me.GrpAttach.Location = New System.Drawing.Point(5, 221)
        Me.GrpAttach.Name = "GrpAttach"
        Me.GrpAttach.Size = New System.Drawing.Size(228, 78)
        Me.GrpAttach.TabIndex = 2
        Me.GrpAttach.TabStop = False
        Me.GrpAttach.Text = "DB Attachment"
        '
        'cmdAttach
        '
        Me.cmdAttach.Location = New System.Drawing.Point(137, 43)
        Me.cmdAttach.Name = "cmdAttach"
        Me.cmdAttach.Size = New System.Drawing.Size(84, 26)
        Me.cmdAttach.TabIndex = 15
        Me.cmdAttach.Text = "&Attach"
        Me.cmdAttach.UseVisualStyleBackColor = True
        '
        'cmdDBMain
        '
        Me.cmdDBMain.Location = New System.Drawing.Point(200, 18)
        Me.cmdDBMain.Name = "cmdDBMain"
        Me.cmdDBMain.Size = New System.Drawing.Size(25, 22)
        Me.cmdDBMain.TabIndex = 14
        Me.cmdDBMain.Text = "..."
        Me.cmdDBMain.UseVisualStyleBackColor = True
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(82, 19)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(118, 20)
        Me.txtDBName.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "DB Filename:"
        '
        'GrpAdvance
        '
        Me.GrpAdvance.Controls.Add(Me.txtOwner)
        Me.GrpAdvance.Controls.Add(Me.Label7)
        Me.GrpAdvance.Location = New System.Drawing.Point(239, 42)
        Me.GrpAdvance.Name = "GrpAdvance"
        Me.GrpAdvance.Size = New System.Drawing.Size(212, 257)
        Me.GrpAdvance.TabIndex = 3
        Me.GrpAdvance.TabStop = False
        Me.GrpAdvance.Text = "Advance Setting"
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(50, 19)
        Me.txtOwner.Multiline = True
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOwner.Size = New System.Drawing.Size(154, 110)
        Me.txtOwner.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Owner:"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(42, 304)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(73, 37)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(115, 304)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(68, 37)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(238, 38)
        Me.AppHeader1.TabIndex = 126
        '
        'FrmSvrInfor
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(238, 342)
        Me.Controls.Add(Me.AppHeader1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.GrpAdvance)
        Me.Controls.Add(Me.GrpAttach)
        Me.Controls.Add(Me.GrpAuthenticate)
        Me.Controls.Add(Me.GrpServ)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSvrInfor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server Information"
        Me.GrpServ.ResumeLayout(False)
        Me.GrpServ.PerformLayout()
        Me.GrpAuthenticate.ResumeLayout(False)
        Me.GrpAuthenticate.PerformLayout()
        Me.GrpAttach.ResumeLayout(False)
        Me.GrpAttach.PerformLayout()
        Me.GrpAdvance.ResumeLayout(False)
        Me.GrpAdvance.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpServ As System.Windows.Forms.GroupBox
    Friend WithEvents txtAttachName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboServerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpAuthenticate As System.Windows.Forms.GroupBox
    Friend WithEvents chkWinAuthen As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents GrpAttach As System.Windows.Forms.GroupBox
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDBMain As System.Windows.Forms.Button
    Friend WithEvents GrpAdvance As System.Windows.Forms.GroupBox
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdAttach As System.Windows.Forms.Button
    Friend WithEvents AppHeader1 As Cupid.AppHeader
End Class
