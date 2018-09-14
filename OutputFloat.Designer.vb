<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OutputFloat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutputFloat))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.TextBox5 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.ContextMenuStrip8 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GotoErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerFadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 282)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(7, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Compiler Output"
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.BackgroundImage = CType(resources.GetObject("Button13.BackgroundImage"), System.Drawing.Image)
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Location = New System.Drawing.Point(451, 7)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(17, 17)
        Me.Button13.TabIndex = 83
        Me.Button13.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.TextBox5.AutoScrollMinSize = New System.Drawing.Size(0, 15)
        Me.TextBox5.BackBrush = Nothing
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TextBox5.CaretVisible = False
        Me.TextBox5.CharHeight = 15
        Me.TextBox5.CharWidth = 8
        Me.TextBox5.ContextMenuStrip = Me.ContextMenuStrip8
        Me.TextBox5.CurrentLineColor = System.Drawing.Color.White
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.TextBox5.Font = New System.Drawing.Font("Consolas", 7.8!)
        Me.TextBox5.ForeColor = System.Drawing.Color.White
        Me.TextBox5.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange
        Me.TextBox5.IsReplaceMode = False
        Me.TextBox5.LineNumberColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.TextBox5.Location = New System.Drawing.Point(1, 29)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Paddings = New System.Windows.Forms.Padding(0)
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TextBox5.ServiceColors = CType(resources.GetObject("TextBox5.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.TextBox5.Size = New System.Drawing.Size(475, 252)
        Me.TextBox5.TabIndex = 57
        Me.TextBox5.WordWrap = True
        Me.TextBox5.Zoom = 100
        '
        'ContextMenuStrip8
        '
        Me.ContextMenuStrip8.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GotoErrorToolStripMenuItem})
        Me.ContextMenuStrip8.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip8.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip8.ShowImageMargin = False
        Me.ContextMenuStrip8.Size = New System.Drawing.Size(151, 56)
        '
        'GotoErrorToolStripMenuItem
        '
        Me.GotoErrorToolStripMenuItem.Name = "GotoErrorToolStripMenuItem"
        Me.GotoErrorToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.GotoErrorToolStripMenuItem.Text = "Goto Error"
        '
        'TimerFadeIn
        '
        Me.TimerFadeIn.Enabled = True
        Me.TimerFadeIn.Interval = 1
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 10
        '
        'OutputFloat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 282)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OutputFloat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OutputFloat"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox5 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents TimerFadeIn As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Button13 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ContextMenuStrip8 As ContextMenuStrip
    Friend WithEvents GotoErrorToolStripMenuItem As ToolStripMenuItem
End Class
