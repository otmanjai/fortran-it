<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                Me.HiLiteBrush.Dispose()
                Me.pfc.Dispose()
                Me.pfc2.Dispose()
                Me.pfc3.Dispose()
                Me.KeywordsStyle.Dispose()
                Me.OutputErrorStyle.Dispose()
                Me.PathStyle.Dispose()

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelinkSourceFromProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSourceCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerFadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox5 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.ContextMenuStrip8 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GotoErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFortranSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenOutputFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSourceFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutThisVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FortranEditorColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCompilationScriptMakefileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button17 = New System.Windows.Forms.PictureBox()
        Me.Button16 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip5 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAsAModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAsALinkedSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip6 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllPermanentlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInExplorerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.PictureBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.PictureBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button12 = New System.Windows.Forms.PictureBox()
        Me.Button9 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip7 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddANewSourceToBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddANewLinkedSourceToBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAnExistingSourceToBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer6 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip8.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Button17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip5.SuspendLayout()
        Me.ContextMenuStrip6.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.LinkLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinkLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip4.SuspendLayout()
        CType(Me.Button12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip7.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Fortran Source|*.for|Fortran 90|*.f90|Fortran|*.f|Object File|*.o|Dynamic Linked " &
    "Library|*.dll|Archived Library|*.a"
        Me.OpenFileDialog1.Multiselect = True
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.RunToolStripMenuItem1})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip3.ShowImageMargin = False
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(110, 52)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(109, 24)
        Me.ToolStripMenuItem1.Text = "Compile"
        '
        'RunToolStripMenuItem1
        '
        Me.RunToolStripMenuItem1.Image = CType(resources.GetObject("RunToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.RunToolStripMenuItem1.Name = "RunToolStripMenuItem1"
        Me.RunToolStripMenuItem1.Size = New System.Drawing.Size(109, 24)
        Me.RunToolStripMenuItem1.Text = "Run"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelinkSourceFromProgramToolStripMenuItem, Me.EditSourceCodeToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.ShowImageMargin = False
        Me.ContextMenuStrip2.ShowItemToolTips = False
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(255, 52)
        '
        'DelinkSourceFromProgramToolStripMenuItem
        '
        Me.DelinkSourceFromProgramToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DelinkSourceFromProgramToolStripMenuItem.Name = "DelinkSourceFromProgramToolStripMenuItem"
        Me.DelinkSourceFromProgramToolStripMenuItem.Size = New System.Drawing.Size(254, 24)
        Me.DelinkSourceFromProgramToolStripMenuItem.Text = "Un-link source from program..."
        '
        'EditSourceCodeToolStripMenuItem
        '
        Me.EditSourceCodeToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EditSourceCodeToolStripMenuItem.Name = "EditSourceCodeToolStripMenuItem"
        Me.EditSourceCodeToolStripMenuItem.Size = New System.Drawing.Size(254, 24)
        Me.EditSourceCodeToolStripMenuItem.Text = "Edit Source Code"
        '
        'TimerFadeIn
        '
        Me.TimerFadeIn.Interval = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 628)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(1173, 25)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 76
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 20)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(100, 20)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 20)
        '
        'TextBox5
        '
        Me.TextBox5.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.TextBox5.AutoScrollMinSize = New System.Drawing.Size(0, 17)
        Me.TextBox5.BackBrush = Nothing
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TextBox5.CharHeight = 17
        Me.TextBox5.CharWidth = 8
        Me.TextBox5.ContextMenuStrip = Me.ContextMenuStrip8
        Me.TextBox5.CurrentLineColor = System.Drawing.Color.White
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.DisabledColor = System.Drawing.Color.Black
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.TextBox5.ForeColor = System.Drawing.Color.White
        Me.TextBox5.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange
        Me.TextBox5.IsReplaceMode = False
        Me.TextBox5.LineNumberColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.TextBox5.Location = New System.Drawing.Point(0, 0)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Paddings = New System.Windows.Forms.Padding(0)
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TextBox5.ServiceColors = CType(resources.GetObject("TextBox5.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.TextBox5.ShowLineNumbers = False
        Me.TextBox5.Size = New System.Drawing.Size(598, 238)
        Me.TextBox5.TabIndex = 56
        Me.TextBox5.WordWrap = True
        Me.TextBox5.Zoom = 100
        '
        'ContextMenuStrip8
        '
        Me.ContextMenuStrip8.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GotoErrorToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.ContextMenuStrip8.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip8.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip8.ShowImageMargin = False
        Me.ContextMenuStrip8.Size = New System.Drawing.Size(123, 52)
        '
        'GotoErrorToolStripMenuItem
        '
        Me.GotoErrorToolStripMenuItem.Name = "GotoErrorToolStripMenuItem"
        Me.GotoErrorToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.GotoErrorToolStripMenuItem.Text = "Goto Error"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.NewFortranSourceToolStripMenuItem, Me.SaveProjectToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem1.Image = CType(resources.GetObject("FileToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(64, 24)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.NewProjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(307, 26)
        Me.NewProjectToolStripMenuItem.Text = "Open Project"
        '
        'NewFortranSourceToolStripMenuItem
        '
        Me.NewFortranSourceToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.NewFortranSourceToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.NewFortranSourceToolStripMenuItem.Name = "NewFortranSourceToolStripMenuItem"
        Me.NewFortranSourceToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewFortranSourceToolStripMenuItem.Size = New System.Drawing.Size(307, 26)
        Me.NewFortranSourceToolStripMenuItem.Text = "New Fortran Source"
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.SaveProjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(307, 26)
        Me.SaveProjectToolStripMenuItem.Text = "Save Project"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(307, 26)
        Me.ToolStripMenuItem2.Text = "Close Project"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ExitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(307, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'BuildToolStripMenuItem1
        '
        Me.BuildToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenOutputFolderToolStripMenuItem, Me.OpenSourceFolderToolStripMenuItem, Me.BuildProgramToolStripMenuItem, Me.RunProgramToolStripMenuItem})
        Me.BuildToolStripMenuItem1.Image = CType(resources.GetObject("BuildToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.BuildToolStripMenuItem1.Name = "BuildToolStripMenuItem1"
        Me.BuildToolStripMenuItem1.Size = New System.Drawing.Size(75, 24)
        Me.BuildToolStripMenuItem1.Text = "Build"
        '
        'OpenOutputFolderToolStripMenuItem
        '
        Me.OpenOutputFolderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.OpenOutputFolderToolStripMenuItem.Name = "OpenOutputFolderToolStripMenuItem"
        Me.OpenOutputFolderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F7), System.Windows.Forms.Keys)
        Me.OpenOutputFolderToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.OpenOutputFolderToolStripMenuItem.Text = "Open Output Folder"
        '
        'OpenSourceFolderToolStripMenuItem
        '
        Me.OpenSourceFolderToolStripMenuItem.Name = "OpenSourceFolderToolStripMenuItem"
        Me.OpenSourceFolderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F8), System.Windows.Forms.Keys)
        Me.OpenSourceFolderToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.OpenSourceFolderToolStripMenuItem.Text = "Open Source Folder"
        '
        'BuildProgramToolStripMenuItem
        '
        Me.BuildProgramToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.BuildProgramToolStripMenuItem.Name = "BuildProgramToolStripMenuItem"
        Me.BuildProgramToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.BuildProgramToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.BuildProgramToolStripMenuItem.Text = "Build Program"
        '
        'RunProgramToolStripMenuItem
        '
        Me.RunProgramToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.RunProgramToolStripMenuItem.Name = "RunProgramToolStripMenuItem"
        Me.RunProgramToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
        Me.RunProgramToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.RunProgramToolStripMenuItem.Text = "Run Program"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutThisVersionToolStripMenuItem, Me.ManualToolStripMenuItem})
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(82, 24)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutThisVersionToolStripMenuItem
        '
        Me.AboutThisVersionToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.AboutThisVersionToolStripMenuItem.Name = "AboutThisVersionToolStripMenuItem"
        Me.AboutThisVersionToolStripMenuItem.Size = New System.Drawing.Size(207, 26)
        Me.AboutThisVersionToolStripMenuItem.Text = "About This Version"
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        Me.ManualToolStripMenuItem.Size = New System.Drawing.Size(207, 26)
        Me.ManualToolStripMenuItem.Text = "Program Manual"
        '
        'MainPageToolStripMenuItem
        '
        Me.MainPageToolStripMenuItem.Image = CType(resources.GetObject("MainPageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MainPageToolStripMenuItem.Name = "MainPageToolStripMenuItem"
        Me.MainPageToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.MainPageToolStripMenuItem.Text = "Main Page"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.BuildToolStripMenuItem1, Me.AboutToolStripMenuItem, Me.MainPageToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ExecuteToolStripMenuItem, Me.RunToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(5, 7)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip2.Size = New System.Drawing.Size(617, 28)
        Me.MenuStrip2.TabIndex = 70
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FortranEditorColorToolStripMenuItem, Me.EditCompilationScriptMakefileToolStripMenuItem, Me.ProjectParametersToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(94, 24)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'FortranEditorColorToolStripMenuItem
        '
        Me.FortranEditorColorToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.FortranEditorColorToolStripMenuItem.Name = "FortranEditorColorToolStripMenuItem"
        Me.FortranEditorColorToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.FortranEditorColorToolStripMenuItem.Text = "Code Editor Settings"
        '
        'EditCompilationScriptMakefileToolStripMenuItem
        '
        Me.EditCompilationScriptMakefileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EditCompilationScriptMakefileToolStripMenuItem.Name = "EditCompilationScriptMakefileToolStripMenuItem"
        Me.EditCompilationScriptMakefileToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.EditCompilationScriptMakefileToolStripMenuItem.Text = "Build Script Editor"
        '
        'ProjectParametersToolStripMenuItem
        '
        Me.ProjectParametersToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ProjectParametersToolStripMenuItem.Name = "ProjectParametersToolStripMenuItem"
        Me.ProjectParametersToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.ProjectParametersToolStripMenuItem.Text = "Project Configuration"
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.Image = CType(resources.GetObject("ExecuteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        Me.ExecuteToolStripMenuItem.Size = New System.Drawing.Size(97, 24)
        Me.ExecuteToolStripMenuItem.Text = "Compile"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Image = CType(resources.GetObject("RunToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(87, 24)
        Me.RunToolStripMenuItem.Text = "Launch"
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(555, 25)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Fortran-It, a simple Fortran IDE."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.SplitContainer2)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.TextBox6)
        Me.Panel1.Controls.Add(Me.Button14)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1173, 653)
        Me.Panel1.TabIndex = 80
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(625, 250)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(171, 4)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 139
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoEllipsis = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(621, 227)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(181, 25)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "CPU Utilization: 100%"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 36)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox5)
        Me.SplitContainer2.Size = New System.Drawing.Size(598, 592)
        Me.SplitContainer2.SplitterDistance = 350
        Me.SplitContainer2.TabIndex = 137
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Panel1MinSize = 200
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView2)
        Me.SplitContainer1.Size = New System.Drawing.Size(598, 350)
        Me.SplitContainer1.SplitterDistance = 295
        Me.SplitContainer1.TabIndex = 134
        '
        'Button17
        '
        Me.Button17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button17.BackColor = System.Drawing.Color.LightGray
        Me.Button17.BackgroundImage = CType(resources.GetObject("Button17.BackgroundImage"), System.Drawing.Image)
        Me.Button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button17.Location = New System.Drawing.Point(231, 5)
        Me.Button17.Name = "Button17"
        Me.Button17.Padding = New System.Windows.Forms.Padding(2)
        Me.Button17.Size = New System.Drawing.Size(25, 25)
        Me.Button17.TabIndex = 136
        Me.Button17.TabStop = False
        Me.Button17.Tag = "Edit"
        '
        'Button16
        '
        Me.Button16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button16.BackColor = System.Drawing.Color.LightGray
        Me.Button16.BackgroundImage = CType(resources.GetObject("Button16.BackgroundImage"), System.Drawing.Image)
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button16.Location = New System.Drawing.Point(260, 8)
        Me.Button16.Name = "Button16"
        Me.Button16.Padding = New System.Windows.Forms.Padding(2)
        Me.Button16.Size = New System.Drawing.Size(25, 19)
        Me.Button16.TabIndex = 136
        Me.Button16.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoEllipsis = True
        Me.Label13.BackColor = System.Drawing.Color.LightGray
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(-4, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(297, 31)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Code Bank"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListView1
        '
        Me.ListView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.ListView1.AllowDrop = True
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip5
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.GridLines = True
        Me.ListView1.LargeImageList = Me.ImageList2
        Me.ListView1.Location = New System.Drawing.Point(0, 34)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(293, 316)
        Me.ListView1.SmallImageList = Me.ImageList2
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip5
        '
        Me.ContextMenuStrip5.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ShowInExplorerToolStripMenuItem, Me.RenameToolStripMenuItem, Me.AddAsAModuleToolStripMenuItem, Me.AddAsALinkedSourceToolStripMenuItem})
        Me.ContextMenuStrip5.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip5.ShowImageMargin = False
        Me.ContextMenuStrip5.Size = New System.Drawing.Size(203, 148)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(202, 24)
        Me.ToolStripMenuItem5.Text = "Open"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(202, 24)
        Me.ToolStripMenuItem6.Text = "Delete Permanently"
        '
        'ShowInExplorerToolStripMenuItem
        '
        Me.ShowInExplorerToolStripMenuItem.Name = "ShowInExplorerToolStripMenuItem"
        Me.ShowInExplorerToolStripMenuItem.Size = New System.Drawing.Size(202, 24)
        Me.ShowInExplorerToolStripMenuItem.Text = "Show in explorer"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(202, 24)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'AddAsAModuleToolStripMenuItem
        '
        Me.AddAsAModuleToolStripMenuItem.Name = "AddAsAModuleToolStripMenuItem"
        Me.AddAsAModuleToolStripMenuItem.Size = New System.Drawing.Size(202, 24)
        Me.AddAsAModuleToolStripMenuItem.Text = "Add as a module"
        '
        'AddAsALinkedSourceToolStripMenuItem
        '
        Me.AddAsALinkedSourceToolStripMenuItem.Name = "AddAsALinkedSourceToolStripMenuItem"
        Me.AddAsALinkedSourceToolStripMenuItem.Size = New System.Drawing.Size(202, 24)
        Me.AddAsALinkedSourceToolStripMenuItem.Text = "Add as a linked source"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "001-browser.png")
        Me.ImageList2.Images.SetKeyName(1, "004-browser-1.png")
        Me.ImageList2.Images.SetKeyName(2, "003-box.png")
        Me.ImageList2.Images.SetKeyName(3, "006-paper.png")
        Me.ImageList2.Images.SetKeyName(4, "paper-plane.png")
        Me.ImageList2.Images.SetKeyName(5, "molecular.png")
        Me.ImageList2.Images.SetKeyName(6, "005-dll.png")
        Me.ImageList2.Images.SetKeyName(7, "001-folder.png")
        Me.ImageList2.Images.SetKeyName(8, "002-file.png")
        Me.ImageList2.Images.SetKeyName(9, "pack (1).png")
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoEllipsis = True
        Me.Label14.BackColor = System.Drawing.Color.LightGray
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(0, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(298, 32)
        Me.Label14.TabIndex = 136
        Me.Label14.Text = "Program Binaries"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.ContextMenuStrip = Me.ContextMenuStrip6
        Me.ListView2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.ForeColor = System.Drawing.Color.White
        Me.ListView2.Location = New System.Drawing.Point(0, 34)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(298, 316)
        Me.ListView2.TabIndex = 0
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip6
        '
        Me.ContextMenuStrip6.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.DeleteAllPermanentlyToolStripMenuItem, Me.ShowInExplorerToolStripMenuItem1})
        Me.ContextMenuStrip6.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip6.ShowImageMargin = False
        Me.ContextMenuStrip6.Size = New System.Drawing.Size(205, 100)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(204, 24)
        Me.ToolStripMenuItem7.Text = "Open"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.ShowShortcutKeys = False
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(204, 24)
        Me.ToolStripMenuItem8.Text = "Delete Permanently"
        '
        'DeleteAllPermanentlyToolStripMenuItem
        '
        Me.DeleteAllPermanentlyToolStripMenuItem.Name = "DeleteAllPermanentlyToolStripMenuItem"
        Me.DeleteAllPermanentlyToolStripMenuItem.Size = New System.Drawing.Size(204, 24)
        Me.DeleteAllPermanentlyToolStripMenuItem.Text = "Delete All Permanently"
        '
        'ShowInExplorerToolStripMenuItem1
        '
        Me.ShowInExplorerToolStripMenuItem1.Name = "ShowInExplorerToolStripMenuItem1"
        Me.ShowInExplorerToolStripMenuItem1.Size = New System.Drawing.Size(204, 24)
        Me.ShowInExplorerToolStripMenuItem1.Text = "Show in explorer"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoEllipsis = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(878, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(227, 40)
        Me.Label15.TabIndex = 135
        Me.Label15.Text = "You currently have no program. Click '+' to add a new program."
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(1136, 8)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 131
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1105, 8)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 130
        Me.PictureBox4.TabStop = False
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TextBox6.Location = New System.Drawing.Point(680, 7)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(0, 27)
        Me.TextBox6.TabIndex = 129
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.Black
        Me.Button14.Location = New System.Drawing.Point(622, 108)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(99, 30)
        Me.Button14.TabIndex = 128
        Me.Button14.Text = "RUN"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Black
        Me.Button13.Location = New System.Drawing.Point(622, 72)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(99, 30)
        Me.Button13.TabIndex = 127
        Me.Button13.Text = "COMPILE"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Quicksand", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(786, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(228, 23)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "SOLUTION EXPLORER"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(622, 36)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(99, 30)
        Me.Button6.TabIndex = 124
        Me.Button6.Text = "SAVE"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoEllipsis = True
        Me.Label1.ContextMenuStrip = Me.ContextMenuStrip8
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(619, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 68)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Project Explorer"
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Control
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip3
        Me.TreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.ItemHeight = 24
        Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.TreeView1.Location = New System.Drawing.Point(862, 44)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(281, 231)
        Me.TreeView1.TabIndex = 122
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "browser.png")
        Me.ImageList1.Images.SetKeyName(1, "high-voltage (1).png")
        Me.ImageList1.Images.SetKeyName(2, "link.png")
        Me.ImageList1.Images.SetKeyName(3, "open-cardboard-box (1).png")
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.LinkLabel4)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Button11)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.ListBox2)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.ListBox1)
        Me.Panel2.Controls.Add(Me.Button12)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(604, 355)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 273)
        Me.Panel2.TabIndex = 83
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.BackgroundImage = CType(resources.GetObject("LinkLabel2.BackgroundImage"), System.Drawing.Image)
        Me.LinkLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel2.Location = New System.Drawing.Point(365, 613)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(25, 25)
        Me.LinkLabel2.TabIndex = 124
        Me.LinkLabel2.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.BackgroundImage = CType(resources.GetObject("LinkLabel1.BackgroundImage"), System.Drawing.Image)
        Me.LinkLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Location = New System.Drawing.Point(365, 350)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(25, 25)
        Me.LinkLabel1.TabIndex = 123
        Me.LinkLabel1.TabStop = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(430, 349)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(77, 29)
        Me.Button5.TabIndex = 122
        Me.Button5.Text = "Un-link"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(122, 6)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(114, 20)
        Me.LinkLabel4.TabIndex = 121
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Delete Program"
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(15, 651)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 40)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Compiler Settings"
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(15, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 139)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "Assigned Module(s)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Double click to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "open code)"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.White
        Me.Button11.Location = New System.Drawing.Point(429, 611)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(77, 29)
        Me.Button11.TabIndex = 115
        Me.Button11.Text = "Remove"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoEllipsis = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(17, 32317)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 45)
        Me.Label7.TabIndex = 112
        Me.Label7.Text = "Assign New Module"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(396, 613)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(25, 25)
        Me.Button10.TabIndex = 108
        Me.Button10.TabStop = False
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.ContextMenuStrip = Me.ContextMenuStrip4
        Me.ListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.White
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 17
        Me.ListBox2.Location = New System.Drawing.Point(125, 386)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.ScrollAlwaysVisible = True
        Me.ListBox2.Size = New System.Drawing.Size(402, 221)
        Me.ListBox2.TabIndex = 107
        '
        'ContextMenuStrip4
        '
        Me.ContextMenuStrip4.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.ContextMenuStrip4.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip4.ShowImageMargin = False
        Me.ContextMenuStrip4.Size = New System.Drawing.Size(270, 52)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(269, 24)
        Me.ToolStripMenuItem3.Text = "Remove module from program..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(269, 24)
        Me.ToolStripMenuItem4.Text = "Edit Source Code"
        '
        'TextBox2
        '
        Me.TextBox2.AllowDrop = True
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(125, 650)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(402, 145)
        Me.TextBox2.TabIndex = 90
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.White
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(126, 107)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(402, 238)
        Me.ListBox1.TabIndex = 96
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Transparent
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(514, 62)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(25, 25)
        Me.Button12.TabIndex = 103
        Me.Button12.TabStop = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(514, 31)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(25, 25)
        Me.Button9.TabIndex = 99
        Me.Button9.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoEllipsis = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 25)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Main Source"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(126, 33)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(381, 67)
        Me.TextBox1.TabIndex = 97
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(396, 350)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(25, 25)
        Me.Button4.TabIndex = 92
        Me.Button4.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoEllipsis = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(17, 32317)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 66)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Additional Compiler Options"
        '
        'Label4
        '
        Me.Label4.AutoEllipsis = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 81)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Linked Source Code(s)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Double click to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "open code)"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Quicksand", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(791, 285)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(201, 23)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "PROGRAM BUILDER"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(730, 321)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(339, 28)
        Me.ComboBox1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(621, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 25)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Program Name"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(1073, 323)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(2)
        Me.Button1.Size = New System.Drawing.Size(25, 25)
        Me.Button1.TabIndex = 86
        Me.Button1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(1102, 323)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(2)
        Me.Button2.Size = New System.Drawing.Size(25, 25)
        Me.Button2.TabIndex = 87
        Me.Button2.TabStop = False
        Me.Button2.Tag = "Edit"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(1132, 323)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(2)
        Me.Button3.Size = New System.Drawing.Size(25, 25)
        Me.Button3.TabIndex = 88
        Me.Button3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(745, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 119
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(747, 65)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 136
        Me.PictureBox6.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(743, 59)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(67, 64)
        Me.PictureBox3.TabIndex = 123
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(805, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(56, 211)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 120
        Me.PictureBox1.TabStop = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 5000
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        Me.Timer4.Interval = 1
        '
        'ContextMenuStrip7
        '
        Me.ContextMenuStrip7.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddANewSourceToBankToolStripMenuItem, Me.AddANewLinkedSourceToBankToolStripMenuItem, Me.AddAnExistingSourceToBankToolStripMenuItem})
        Me.ContextMenuStrip7.Name = "ContextMenuStrip7"
        Me.ContextMenuStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip7.ShowImageMargin = False
        Me.ContextMenuStrip7.Size = New System.Drawing.Size(279, 76)
        '
        'AddANewSourceToBankToolStripMenuItem
        '
        Me.AddANewSourceToBankToolStripMenuItem.Name = "AddANewSourceToBankToolStripMenuItem"
        Me.AddANewSourceToBankToolStripMenuItem.Size = New System.Drawing.Size(278, 24)
        Me.AddANewSourceToBankToolStripMenuItem.Text = "Add a new module to bank..."
        '
        'AddANewLinkedSourceToBankToolStripMenuItem
        '
        Me.AddANewLinkedSourceToBankToolStripMenuItem.Name = "AddANewLinkedSourceToBankToolStripMenuItem"
        Me.AddANewLinkedSourceToBankToolStripMenuItem.Size = New System.Drawing.Size(278, 24)
        Me.AddANewLinkedSourceToBankToolStripMenuItem.Text = "Add a new linked source to bank..."
        '
        'AddAnExistingSourceToBankToolStripMenuItem
        '
        Me.AddAnExistingSourceToBankToolStripMenuItem.Name = "AddAnExistingSourceToBankToolStripMenuItem"
        Me.AddAnExistingSourceToBankToolStripMenuItem.Size = New System.Drawing.Size(278, 24)
        Me.AddAnExistingSourceToBankToolStripMenuItem.Text = "Add an existing source to bank..."
        '
        'Timer5
        '
        Me.Timer5.Enabled = True
        Me.Timer5.Interval = 500
        '
        'Timer6
        '
        Me.Timer6.Enabled = True
        Me.Timer6.Interval = 5000
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1173, 653)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fortran-It"
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip8.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Button17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip5.ResumeLayout(False)
        Me.ContextMenuStrip6.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.LinkLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinkLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip4.ResumeLayout(False)
        CType(Me.Button12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TimerFadeIn As Timer
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents DelinkSourceFromProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents EditSourceCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox5 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents FileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewFortranSourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuildToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenOutputFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuildProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutThisVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FortranEditorColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents EditCompilationScriptMakefileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExecuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProjectParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button12 As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Button9 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As PictureBox
    Friend WithEvents Button2 As PictureBox
    Friend WithEvents Button1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button10 As PictureBox
    Friend WithEvents Button11 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button6 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Label10 As Label
    Friend WithEvents ContextMenuStrip4 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents OpenSourceFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents ContextMenuStrip5 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ContextMenuStrip6 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents Label15 As Label
    Friend WithEvents ShowInExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowInExplorerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAsAModuleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAsALinkedSourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button16 As PictureBox
    Friend WithEvents ContextMenuStrip7 As ContextMenuStrip
    Friend WithEvents AddANewSourceToBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddANewLinkedSourceToBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAnExistingSourceToBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button17 As PictureBox
    Friend WithEvents DeleteAllPermanentlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip8 As ContextMenuStrip
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Button5 As Button
    Friend WithEvents LinkLabel1 As PictureBox
    Friend WithEvents LinkLabel2 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents GotoErrorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label11 As Label
    Friend WithEvents Timer5 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer6 As Timer
End Class
