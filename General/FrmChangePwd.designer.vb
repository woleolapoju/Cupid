<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangePwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChangePwd))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tConfirm = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tUsername = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tUserID = New System.Windows.Forms.TextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.AppHeader1 = New Cupid.AppHeader()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Confirm Pwd:"
        '
        'tConfirm
        '
        Me.tConfirm.AcceptsReturn = True
        Me.tConfirm.Location = New System.Drawing.Point(88, 104)
        Me.tConfirm.Name = "tConfirm"
        Me.tConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tConfirm.Size = New System.Drawing.Size(94, 20)
        Me.tConfirm.TabIndex = 1
        Me.tConfirm.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Password:"
        '
        'tPassword
        '
        Me.tPassword.AcceptsReturn = True
        Me.tPassword.Location = New System.Drawing.Point(88, 82)
        Me.tPassword.Name = "tPassword"
        Me.tPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tPassword.Size = New System.Drawing.Size(94, 20)
        Me.tPassword.TabIndex = 0
        Me.tPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Username:"
        '
        'tUsername
        '
        Me.tUsername.AcceptsReturn = True
        Me.tUsername.BackColor = System.Drawing.Color.Khaki
        Me.tUsername.Enabled = False
        Me.tUsername.Location = New System.Drawing.Point(88, 59)
        Me.tUsername.Name = "tUsername"
        Me.tUsername.ReadOnly = True
        Me.tUsername.Size = New System.Drawing.Size(192, 20)
        Me.tUsername.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "User ID:"
        '
        'tUserID
        '
        Me.tUserID.AcceptsReturn = True
        Me.tUserID.BackColor = System.Drawing.Color.Khaki
        Me.tUserID.Enabled = False
        Me.tUserID.Location = New System.Drawing.Point(88, 36)
        Me.tUserID.Name = "tUserID"
        Me.tUserID.ReadOnly = True
        Me.tUserID.Size = New System.Drawing.Size(94, 20)
        Me.tUserID.TabIndex = 38
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdOk.Location = New System.Drawing.Point(157, 130)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(64, 39)
        Me.cmdOk.TabIndex = 47
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(223, 130)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(64, 39)
        Me.cmdClose.TabIndex = 46
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'AppHeader1
        '
        Me.AppHeader1.BackColor = System.Drawing.Color.White
        Me.AppHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppHeader1.Location = New System.Drawing.Point(0, 0)
        Me.AppHeader1.Name = "AppHeader1"
        Me.AppHeader1.Size = New System.Drawing.Size(292, 32)
        Me.AppHeader1.TabIndex = 124
        '
        'FrmChangePwd
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(292, 172)
        Me.Controls.Add(Me.AppHeader1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tConfirm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tUserID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmChangePwd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tConfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tUserID As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents AppHeader1 As Cupid.AppHeader
End Class
