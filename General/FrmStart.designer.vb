<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStart))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerMail = New System.Windows.Forms.Timer(Me.components)
        Me.timerBlink = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSystemPeriod = New System.Windows.Forms.ToolStripTextBox()
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeNotices = New System.Windows.Forms.Timer(Me.components)
        Me.PanBottomBox = New System.Windows.Forms.Panel()
        Me.tblBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.lblOwner = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnShortCut4 = New System.Windows.Forms.Button()
        Me.btnShortCut3 = New System.Windows.Forms.Button()
        Me.btnShortCut1 = New System.Windows.Forms.Button()
        Me.btnShortCut2 = New System.Windows.Forms.Button()
        Me.btnShortCut6 = New System.Windows.Forms.Button()
        Me.btnShortCut5 = New System.Windows.Forms.Button()
        Me.btnShortCut7 = New System.Windows.Forms.Button()
        Me.btnShortCut8 = New System.Windows.Forms.Button()
        Me.btnShortCut9 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lnkReconnect = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PanLogo = New System.Windows.Forms.Panel()
        Me.OwnerLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        Me.PanBottomBox.SuspendLayout()
        Me.tblBottom.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanLogo.SuspendLayout()
        CType(Me.OwnerLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerMail
        '
        Me.TimerMail.Interval = 14400
        '
        'timerBlink
        '
        Me.timerBlink.Interval = 360
        '
        'MenuStrip
        '
        Me.MenuStrip.AllowItemReorder = True
        Me.MenuStrip.AllowMerge = False
        Me.MenuStrip.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowsMenu, Me.HelpMenu, Me.mnuSystemPeriod, Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(1, 1)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(317, 26)
        Me.MenuStrip.TabIndex = 173
        Me.MenuStrip.Text = "MenuStrip"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Font = New System.Drawing.Font("Tempus Sans ITC", 9.0!)
        Me.WindowsMenu.ForeColor = System.Drawing.Color.OrangeRed
        Me.WindowsMenu.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.WindowsMenu.MergeIndex = 9
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(67, 22)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 22)
        Me.HelpMenu.Text = "&Help"
        Me.HelpMenu.Visible = False
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(165, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'mnuSystemPeriod
        '
        Me.mnuSystemPeriod.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuSystemPeriod.BackColor = System.Drawing.Color.LightSteelBlue
        Me.mnuSystemPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mnuSystemPeriod.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.mnuSystemPeriod.ForeColor = System.Drawing.Color.Maroon
        Me.mnuSystemPeriod.Name = "mnuSystemPeriod"
        Me.mnuSystemPeriod.ReadOnly = True
        Me.mnuSystemPeriod.Size = New System.Drawing.Size(240, 22)
        Me.mnuSystemPeriod.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem
        '
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.ForeColor = System.Drawing.Color.Firebrick
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.Name = "Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem"
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.Size = New System.Drawing.Size(282, 22)
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.Text = "www.megahitsystems.eu5.org (234-803-311-6212)"
        Me.Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem.Visible = False
        '
        'TimeNotices
        '
        Me.TimeNotices.Interval = 2160000
        '
        'PanBottomBox
        '
        Me.PanBottomBox.BackColor = System.Drawing.Color.IndianRed
        Me.PanBottomBox.Controls.Add(Me.tblBottom)
        Me.PanBottomBox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanBottomBox.Location = New System.Drawing.Point(0, 628)
        Me.PanBottomBox.Name = "PanBottomBox"
        Me.PanBottomBox.Size = New System.Drawing.Size(1022, 40)
        Me.PanBottomBox.TabIndex = 177
        '
        'tblBottom
        '
        Me.tblBottom.ColumnCount = 5
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137.0!))
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblBottom.Controls.Add(Me.lblOwner, 1, 0)
        Me.tblBottom.Controls.Add(Me.TableLayoutPanel1, 4, 0)
        Me.tblBottom.Controls.Add(Me.Panel1, 3, 0)
        Me.tblBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tblBottom.Location = New System.Drawing.Point(0, 5)
        Me.tblBottom.Name = "tblBottom"
        Me.tblBottom.RowCount = 1
        Me.tblBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblBottom.Size = New System.Drawing.Size(1022, 35)
        Me.tblBottom.TabIndex = 70
        '
        'lblOwner
        '
        Me.lblOwner.BackColor = System.Drawing.Color.Transparent
        Me.lblOwner.Font = New System.Drawing.Font("Segoe UI Symbol", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwner.ForeColor = System.Drawing.Color.White
        Me.lblOwner.Location = New System.Drawing.Point(141, 4)
        Me.lblOwner.Margin = New System.Windows.Forms.Padding(4, 4, 4, 2)
        Me.lblOwner.Name = "lblOwner"
        Me.lblOwner.Size = New System.Drawing.Size(389, 29)
        Me.lblOwner.TabIndex = 69
        Me.lblOwner.Text = "MegaHit Systems"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut6, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut7, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut8, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShortCut9, 8, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(840, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(179, 22)
        Me.TableLayoutPanel1.TabIndex = 68
        '
        'btnShortCut4
        '
        Me.btnShortCut4.AllowDrop = True
        Me.btnShortCut4.BackColor = System.Drawing.Color.Tomato
        Me.btnShortCut4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut4.FlatAppearance.BorderSize = 0
        Me.btnShortCut4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut4.Location = New System.Drawing.Point(63, 3)
        Me.btnShortCut4.Name = "btnShortCut4"
        Me.btnShortCut4.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut4.TabIndex = 8
        Me.btnShortCut4.UseVisualStyleBackColor = False
        '
        'btnShortCut3
        '
        Me.btnShortCut3.AllowDrop = True
        Me.btnShortCut3.BackColor = System.Drawing.Color.CadetBlue
        Me.btnShortCut3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut3.FlatAppearance.BorderSize = 0
        Me.btnShortCut3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut3.Location = New System.Drawing.Point(43, 3)
        Me.btnShortCut3.Name = "btnShortCut3"
        Me.btnShortCut3.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut3.TabIndex = 7
        Me.btnShortCut3.UseVisualStyleBackColor = False
        '
        'btnShortCut1
        '
        Me.btnShortCut1.AllowDrop = True
        Me.btnShortCut1.BackColor = System.Drawing.Color.SandyBrown
        Me.btnShortCut1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut1.FlatAppearance.BorderSize = 0
        Me.btnShortCut1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut1.Location = New System.Drawing.Point(3, 3)
        Me.btnShortCut1.Name = "btnShortCut1"
        Me.btnShortCut1.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut1.TabIndex = 6
        Me.btnShortCut1.UseVisualStyleBackColor = False
        '
        'btnShortCut2
        '
        Me.btnShortCut2.AllowDrop = True
        Me.btnShortCut2.BackColor = System.Drawing.Color.SteelBlue
        Me.btnShortCut2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut2.FlatAppearance.BorderSize = 0
        Me.btnShortCut2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut2.Location = New System.Drawing.Point(23, 3)
        Me.btnShortCut2.Name = "btnShortCut2"
        Me.btnShortCut2.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut2.TabIndex = 4
        Me.btnShortCut2.UseVisualStyleBackColor = False
        '
        'btnShortCut6
        '
        Me.btnShortCut6.AllowDrop = True
        Me.btnShortCut6.BackColor = System.Drawing.Color.SpringGreen
        Me.btnShortCut6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut6.FlatAppearance.BorderSize = 0
        Me.btnShortCut6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut6.Location = New System.Drawing.Point(103, 3)
        Me.btnShortCut6.Name = "btnShortCut6"
        Me.btnShortCut6.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut6.TabIndex = 9
        Me.btnShortCut6.UseVisualStyleBackColor = False
        '
        'btnShortCut5
        '
        Me.btnShortCut5.AllowDrop = True
        Me.btnShortCut5.BackColor = System.Drawing.Color.DarkOrange
        Me.btnShortCut5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut5.FlatAppearance.BorderSize = 0
        Me.btnShortCut5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut5.Location = New System.Drawing.Point(83, 3)
        Me.btnShortCut5.Name = "btnShortCut5"
        Me.btnShortCut5.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut5.TabIndex = 10
        Me.btnShortCut5.UseVisualStyleBackColor = False
        '
        'btnShortCut7
        '
        Me.btnShortCut7.AllowDrop = True
        Me.btnShortCut7.BackColor = System.Drawing.Color.Indigo
        Me.btnShortCut7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut7.FlatAppearance.BorderSize = 0
        Me.btnShortCut7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut7.Location = New System.Drawing.Point(123, 3)
        Me.btnShortCut7.Name = "btnShortCut7"
        Me.btnShortCut7.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut7.TabIndex = 11
        Me.btnShortCut7.UseVisualStyleBackColor = False
        '
        'btnShortCut8
        '
        Me.btnShortCut8.AllowDrop = True
        Me.btnShortCut8.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnShortCut8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut8.FlatAppearance.BorderSize = 0
        Me.btnShortCut8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut8.Location = New System.Drawing.Point(143, 3)
        Me.btnShortCut8.Name = "btnShortCut8"
        Me.btnShortCut8.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut8.TabIndex = 12
        Me.btnShortCut8.UseVisualStyleBackColor = False
        '
        'btnShortCut9
        '
        Me.btnShortCut9.AllowDrop = True
        Me.btnShortCut9.BackColor = System.Drawing.Color.Magenta
        Me.btnShortCut9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShortCut9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortCut9.FlatAppearance.BorderSize = 0
        Me.btnShortCut9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnShortCut9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet
        Me.btnShortCut9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortCut9.Location = New System.Drawing.Point(163, 3)
        Me.btnShortCut9.Name = "btnShortCut9"
        Me.btnShortCut9.Size = New System.Drawing.Size(14, 16)
        Me.btnShortCut9.TabIndex = 13
        Me.btnShortCut9.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lnkReconnect)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(549, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(285, 29)
        Me.Panel1.TabIndex = 70
        '
        'lnkReconnect
        '
        Me.lnkReconnect.BackColor = System.Drawing.Color.Transparent
        Me.lnkReconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkReconnect.ForeColor = System.Drawing.Color.White
        Me.lnkReconnect.LinkColor = System.Drawing.Color.Yellow
        Me.lnkReconnect.Location = New System.Drawing.Point(108, -6)
        Me.lnkReconnect.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.lnkReconnect.Name = "lnkReconnect"
        Me.lnkReconnect.Size = New System.Drawing.Size(69, 20)
        Me.lnkReconnect.TabIndex = 32
        Me.lnkReconnect.TabStop = True
        Me.lnkReconnect.Text = "Reconnect"
        Me.lnkReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkReconnect.VisitedLinkColor = System.Drawing.Color.Yellow
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 12)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(233, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "www.megahitsystems.com (+234-803-311-6212)"
        '
        'PanLogo
        '
        Me.PanLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanLogo.BackColor = System.Drawing.Color.White
        Me.PanLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanLogo.Controls.Add(Me.OwnerLogo)
        Me.PanLogo.Location = New System.Drawing.Point(7, 556)
        Me.PanLogo.Name = "PanLogo"
        Me.PanLogo.Size = New System.Drawing.Size(119, 105)
        Me.PanLogo.TabIndex = 178
        '
        'OwnerLogo
        '
        Me.OwnerLogo.AccessibleDescription = ""
        Me.OwnerLogo.BackColor = System.Drawing.Color.Transparent
        Me.OwnerLogo.Location = New System.Drawing.Point(1, 1)
        Me.OwnerLogo.Margin = New System.Windows.Forms.Padding(6)
        Me.OwnerLogo.Name = "OwnerLogo"
        Me.OwnerLogo.Size = New System.Drawing.Size(115, 101)
        Me.OwnerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OwnerLogo.TabIndex = 10
        Me.OwnerLogo.TabStop = False
        '
        'FrmStart
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1022, 668)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.PanLogo)
        Me.Controls.Add(Me.PanBottomBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "FrmStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cupid -   a complete stock management solution"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.PanBottomBox.ResumeLayout(False)
        Me.tblBottom.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanLogo.ResumeLayout(False)
        CType(Me.OwnerLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TimerMail As System.Windows.Forms.Timer
    Friend WithEvents timerBlink As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSystemPeriod As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TimeNotices As System.Windows.Forms.Timer
    Friend WithEvents PanBottomBox As System.Windows.Forms.Panel
    Friend WithEvents PanLogo As System.Windows.Forms.Panel
    Friend WithEvents OwnerLogo As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnShortCut4 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut3 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut1 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut2 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut6 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut5 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut7 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut8 As System.Windows.Forms.Button
    Friend WithEvents btnShortCut9 As System.Windows.Forms.Button
    Friend WithEvents lblOwner As System.Windows.Forms.Label
    Friend WithEvents tblBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Wwwmegahitsystemseu5org2348033116212ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkReconnect As System.Windows.Forms.LinkLabel

End Class
