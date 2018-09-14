<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodeEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                Me.CommentStyle.Dispose()
                Me.FunctionNameStyle.Dispose()
                Me.KeywordsStyle.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodeEditor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.TextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.TextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnippetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoEnddoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoWhileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnippetsConditionalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IfElseifelseEndifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IfElseifEndifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IfElseEndifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IfEndifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnippetsMethodsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunctionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubroutineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnippetsIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadvarN1NToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineContinuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerFadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.toolStripSeparator1, Me.ToolStripComboBox1, Me.ToolStripSeparator7, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton8, Me.ToolStripButton2, Me.ToolStripButton7, Me.ToolStripSeparator6, Me.ToolStripDropDownButton2, Me.ToolStripButton3, Me.ToolStripButton9, Me.ToolStripSeparator8, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripSeparator9, Me.ToolStripButton12, Me.TextBox2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(964, 28)
        Me.ToolStrip1.TabIndex = 57
        Me.ToolStrip1.Text = "Editor Toolbox"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripDropDownButton1.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"200%", "150%", "100%", "90%", "80%", "70%", "60%", "50%", "40%", "30%", "20%", "10%"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(80, 28)
        Me.ToolStripComboBox1.ToolTipText = "Zoom"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 28)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(24, 25)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(24, 25)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(24, 25)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton5.Text = "Undo"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton6.Text = "Redo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton8.Text = "Replace"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton2.Text = "Goto"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton7.Text = "Find"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripDropDownButton2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripDropDownButton2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(150, 28)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton3.Text = "Compile and Run"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton9.Text = "Launch"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.CheckOnClick = True
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.DoubleClickEnabled = True
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton10.Text = "Top Most"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton11.Text = "Tile View"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.CheckOnClick = True
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripButton12.Text = "80 Char Control"
        '
        'TextBox2
        '
        Me.TextBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Black
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(300, 28)
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.TextBox1.AutoIndent = False
        Me.TextBox1.AutoIndentChars = False
        Me.TextBox1.AutoIndentCharsPatterns = "^\s*\w+\s+(?<range>[^,]+)\s*,?\s*(?<range>.+)?"
        Me.TextBox1.AutoScrollMinSize = New System.Drawing.Size(27, 17)
        Me.TextBox1.BackBrush = Nothing
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.TextBox1.CaretColor = System.Drawing.Color.LightGray
        Me.TextBox1.CharHeight = 17
        Me.TextBox1.CharWidth = 8
        Me.TextBox1.CommentPrefix = "C"
        Me.TextBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TextBox1.CurrentLineColor = System.Drawing.Color.Black
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.FoldingIndicatorColor = System.Drawing.Color.LightGray
        Me.TextBox1.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange
        Me.TextBox1.Hotkeys = resources.GetString("TextBox1.Hotkeys")
        Me.TextBox1.IsReplaceMode = False
        Me.TextBox1.LineNumberColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(0, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.TextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox1.ServiceColors = Nothing
        Me.TextBox1.ServiceLinesColor = System.Drawing.Color.Black
        Me.TextBox1.Size = New System.Drawing.Size(964, 607)
        Me.TextBox1.TabIndex = 58
        Me.TextBox1.TabLength = 3
        Me.TextBox1.Zoom = 100
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator4, Me.FindToolStripMenuItem, Me.ReplaceToolStripMenuItem, Me.ToolStripSeparator5, Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.SnippetsToolStripMenuItem, Me.SnippetsConditionalToolStripMenuItem, Me.SnippetsMethodsToolStripMenuItem, Me.SnippetsIOToolStripMenuItem, Me.LineContinuationToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(244, 304)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(240, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.FindToolStripMenuItem.Text = "Find..."
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.ReplaceToolStripMenuItem.Text = "Replace..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(240, 6)
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'SnippetsToolStripMenuItem
        '
        Me.SnippetsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DoEnddoToolStripMenuItem, Me.DoWhileToolStripMenuItem})
        Me.SnippetsToolStripMenuItem.Name = "SnippetsToolStripMenuItem"
        Me.SnippetsToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.SnippetsToolStripMenuItem.Text = "Snippets (Loops)"
        '
        'DoEnddoToolStripMenuItem
        '
        Me.DoEnddoToolStripMenuItem.Name = "DoEnddoToolStripMenuItem"
        Me.DoEnddoToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.DoEnddoToolStripMenuItem.Text = "do ... enddo"
        '
        'DoWhileToolStripMenuItem
        '
        Me.DoWhileToolStripMenuItem.Name = "DoWhileToolStripMenuItem"
        Me.DoWhileToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.DoWhileToolStripMenuItem.Text = "do ... while"
        '
        'SnippetsConditionalToolStripMenuItem
        '
        Me.SnippetsConditionalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IfElseifelseEndifToolStripMenuItem, Me.IfElseifEndifToolStripMenuItem, Me.IfElseEndifToolStripMenuItem, Me.IfEndifToolStripMenuItem, Me.SelectCaseToolStripMenuItem})
        Me.SnippetsConditionalToolStripMenuItem.Name = "SnippetsConditionalToolStripMenuItem"
        Me.SnippetsConditionalToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.SnippetsConditionalToolStripMenuItem.Text = "Snippets (Conditional)"
        '
        'IfElseifelseEndifToolStripMenuItem
        '
        Me.IfElseifelseEndifToolStripMenuItem.Name = "IfElseifelseEndifToolStripMenuItem"
        Me.IfElseifelseEndifToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.IfElseifelseEndifToolStripMenuItem.Text = "if ... elseif ...else ... endif"
        '
        'IfElseifEndifToolStripMenuItem
        '
        Me.IfElseifEndifToolStripMenuItem.Name = "IfElseifEndifToolStripMenuItem"
        Me.IfElseifEndifToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.IfElseifEndifToolStripMenuItem.Text = "if ... elseif ... endif"
        '
        'IfElseEndifToolStripMenuItem
        '
        Me.IfElseEndifToolStripMenuItem.Name = "IfElseEndifToolStripMenuItem"
        Me.IfElseEndifToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.IfElseEndifToolStripMenuItem.Text = "if ...  else ... endif"
        '
        'IfEndifToolStripMenuItem
        '
        Me.IfEndifToolStripMenuItem.Name = "IfEndifToolStripMenuItem"
        Me.IfEndifToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.IfEndifToolStripMenuItem.Text = "if ... endif"
        '
        'SelectCaseToolStripMenuItem
        '
        Me.SelectCaseToolStripMenuItem.Name = "SelectCaseToolStripMenuItem"
        Me.SelectCaseToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.SelectCaseToolStripMenuItem.Text = "select case"
        '
        'SnippetsMethodsToolStripMenuItem
        '
        Me.SnippetsMethodsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FunctionToolStripMenuItem, Me.SubroutineToolStripMenuItem})
        Me.SnippetsMethodsToolStripMenuItem.Name = "SnippetsMethodsToolStripMenuItem"
        Me.SnippetsMethodsToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.SnippetsMethodsToolStripMenuItem.Text = "Snippets (Methods)"
        '
        'FunctionToolStripMenuItem
        '
        Me.FunctionToolStripMenuItem.Name = "FunctionToolStripMenuItem"
        Me.FunctionToolStripMenuItem.Size = New System.Drawing.Size(154, 26)
        Me.FunctionToolStripMenuItem.Text = "function"
        '
        'SubroutineToolStripMenuItem
        '
        Me.SubroutineToolStripMenuItem.Name = "SubroutineToolStripMenuItem"
        Me.SubroutineToolStripMenuItem.Size = New System.Drawing.Size(154, 26)
        Me.SubroutineToolStripMenuItem.Text = "subroutine"
        '
        'SnippetsIOToolStripMenuItem
        '
        Me.SnippetsIOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadvarN1NToolStripMenuItem})
        Me.SnippetsIOToolStripMenuItem.Name = "SnippetsIOToolStripMenuItem"
        Me.SnippetsIOToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.SnippetsIOToolStripMenuItem.Text = "Snippets (IO)"
        '
        'ReadvarN1NToolStripMenuItem
        '
        Me.ReadvarN1NToolStripMenuItem.Name = "ReadvarN1NToolStripMenuItem"
        Me.ReadvarN1NToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ReadvarN1NToolStripMenuItem.Text = "read(*,*) (var, n=1, N)"
        '
        'LineContinuationToolStripMenuItem
        '
        Me.LineContinuationToolStripMenuItem.Name = "LineContinuationToolStripMenuItem"
        Me.LineContinuationToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LineContinuationToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.LineContinuationToolStripMenuItem.Text = "Line Continuation"
        '
        'TimerFadeIn
        '
        Me.TimerFadeIn.Interval = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel8, Me.ToolStripStatusLabel2, Me.ToolStripLabel7, Me.ToolStripStatusLabel1, Me.ToolStripLabel6, Me.ToolStripStatusLabel4, Me.ToolStripLabel5, Me.ToolStripStatusLabel5, Me.ToolStripLabel3, Me.ToolStripStatusLabel3, Me.ToolStripLabel2, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 635)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 12, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(964, 27)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 59
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel8.Text = "Status"
        Me.ToolStripLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel7.Text = "Status"
        Me.ToolStripLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel6.Text = "Status"
        Me.ToolStripLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel4.Text = " "
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel5.Text = "Status"
        Me.ToolStripLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.AutoSize = False
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel5.Text = " "
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel3.Text = "Zoom"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel3.Text = " "
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(49, 25)
        Me.ToolStripLabel2.Text = "Status"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.AutoSize = False
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripStatusLabel6.Text = " "
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(0, 22)
        '
        'BackgroundWorker1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 500
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 5000
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Location = New System.Drawing.Point(443, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 120
        Me.PictureBox2.TabStop = False
        '
        'CodeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(964, 662)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CodeEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fortran Editor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CutToolStripButton As ToolStripButton
    Friend WithEvents CopyToolStripButton As ToolStripButton
    Friend WithEvents PasteToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents TextBox2 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripButton8 As ToolStripButton
    Friend WithEvents TextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents TimerFadeIn As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents SnippetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoEnddoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoWhileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SnippetsConditionalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SnippetsMethodsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IfElseifelseEndifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IfElseifEndifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IfElseEndifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IfEndifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectCaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FunctionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubroutineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents Timer3 As Timer
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton9 As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripButton10 As ToolStripButton
    Friend WithEvents ToolStripButton11 As ToolStripButton
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ToolStripButton12 As ToolStripButton
    Friend WithEvents SnippetsIOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadvarN1NToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LineContinuationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As ToolStripComboBox
End Class
