Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class ThemeForm

    Private ColorList As String()
    Private FontList As New List(Of String)

    Dim SComment As Style
    Dim SStrings As Style
    Dim SKeyword As Style
    Dim SFunction As Style
    Dim SNumeric As Style
    Dim SType As Style

#Region "MouseDrag"

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub
#End Region
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.Opacity = 0
        If Form1.IsForm1Topmost Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        PictureBox1.BackColor = Color.FromName(ComboBox1.Text)
        Label11.ForeColor = PictureBox1.BackColor
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        PictureBox2.BackColor = Color.FromName(ComboBox2.Text)
        Label16.ForeColor = PictureBox2.BackColor
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        PictureBox3.BackColor = Color.FromName(ComboBox5.Text)
        Label17.ForeColor = PictureBox3.BackColor
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        If My.Settings.BackgroundColor.IsNamedColor Then
            PictureBox4.BackColor = Color.FromName(ComboBox8.Text)
        End If
        Label11.BackColor = PictureBox4.BackColor
        Label16.BackColor = PictureBox4.BackColor
        Label17.BackColor = PictureBox4.BackColor
        Label19.BackColor = PictureBox4.BackColor
        Label20.BackColor = PictureBox4.BackColor
        Label21.BackColor = PictureBox4.BackColor
        Label7.BackColor = PictureBox4.BackColor
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        PictureBox8.BackColor = Color.FromName(ComboBox3.Text)
        Label20.ForeColor = PictureBox8.BackColor
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        PictureBox7.BackColor = Color.FromName(ComboBox4.Text)
        Label21.ForeColor = PictureBox7.BackColor
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        PictureBox6.BackColor = Color.FromName(ComboBox7.Text)
        Label7.ForeColor = PictureBox6.BackColor
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox13.SelectedIndexChanged
        PictureBox9.BackColor = Color.FromName(ComboBox13.Text)
        Label18.BackColor = PictureBox9.BackColor
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox14.SelectedIndexChanged
        PictureBox10.BackColor = Color.FromName(ComboBox14.Text)
        Label22.BackColor = PictureBox10.BackColor
    End Sub

    Private Sub ComboBox15_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox15.SelectedIndexChanged
        PictureBox11.BackColor = Color.FromName(ComboBox15.Text)
        Label19.ForeColor = PictureBox11.BackColor
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim res As DialogResult = NewMsgBox.MBox("Apply all editor color settings?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Information)
        If res = DialogResult.Yes Then
            My.Settings.EditorOpacity = NumericUpDown1.Value / 100.0
            My.Settings.Indent = CType(NumericUpDown2.Value, Integer)
            My.Settings.KeywordColor = PictureBox1.BackColor
            My.Settings.NumericColor = PictureBox11.BackColor
            My.Settings.StringsColor = PictureBox2.BackColor
            My.Settings.CommentsColor = PictureBox8.BackColor
            My.Settings.SubroutinesColor = PictureBox7.BackColor
            My.Settings.TypeColor = PictureBox3.BackColor
            My.Settings.BackgroundColor = PictureBox4.BackColor
            My.Settings.ForeGroundColor = PictureBox6.BackColor
            My.Settings.LineNumberColor = PictureBox5.BackColor
            My.Settings.SelectionColor = PictureBox9.BackColor
            My.Settings.CurrentLine = PictureBox10.BackColor
            If CheckBox2.Checked = True Then
                My.Settings.IsItalicComment = True
            Else
                My.Settings.IsItalicComment = False
            End If
            My.Settings.DefaultFont = New Font(New FontFamily(ComboBox10.Text), 9, FontStyle.Regular)
            My.Settings.Save()
            NewMsgBox.MBox("All editor color settings has been saved. Please re-open all editors for changes to take effect.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        PictureBox5.BackColor = Color.FromName(ComboBox9.Text)
        Label12.ForeColor = PictureBox5.BackColor
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ColorDialog1.Color = PictureBox1.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox1.Text = Nothing
            PictureBox1.BackColor = ColorDialog1.Color()
            Label11.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ColorDialog1.Color = PictureBox2.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox2.Text = Nothing
            PictureBox2.BackColor = ColorDialog1.Color()
            Label16.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ColorDialog1.Color = PictureBox3.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox5.Text = Nothing
            PictureBox3.BackColor = ColorDialog1.Color()
            Label17.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ColorDialog1.Color = PictureBox4.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox8.Text = Nothing
            PictureBox4.BackColor = ColorDialog1.Color()
            Label11.BackColor = ColorDialog1.Color()
            Label16.BackColor = ColorDialog1.Color()
            Label17.BackColor = ColorDialog1.Color()
            Label19.BackColor = ColorDialog1.Color()
            Label20.BackColor = ColorDialog1.Color()
            Label21.BackColor = ColorDialog1.Color()
            Label7.BackColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        ColorDialog1.Color = PictureBox9.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox13.Text = Nothing
            PictureBox9.BackColor = ColorDialog1.Color()
            Label18.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        ColorDialog1.Color = PictureBox11.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox15.Text = Nothing
            PictureBox11.BackColor = ColorDialog1.Color()
            Label19.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        ColorDialog1.Color = PictureBox8.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox3.Text = Nothing
            PictureBox8.BackColor = ColorDialog1.Color()
            Label20.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ColorDialog1.Color = PictureBox7.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox4.Text = Nothing
            PictureBox7.BackColor = ColorDialog1.Color()
            Label21.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ColorDialog1.Color = PictureBox6.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox7.Text = Nothing
            PictureBox6.BackColor = ColorDialog1.Color()
            Label7.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        ColorDialog1.Color = PictureBox10.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox14.Text = Nothing
            PictureBox10.BackColor = ColorDialog1.Color()
            Label22.BackColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        ColorDialog1.Color = PictureBox5.BackColor
        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            ComboBox9.Text = Nothing
            PictureBox5.BackColor = ColorDialog1.Color()
            Label12.ForeColor = ColorDialog1.Color()

        End If
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        Button1.Text = "Save"
        If ComboBox6.Text = "Dark" Then
            CKeyword = Color.SteelBlue
            CTypeName = Color.Aquamarine
            CSubroutine = Color.PaleTurquoise
            CString = Color.Salmon
            CComments = Color.Silver
            CNumeric = Color.Plum
            CBackColor = Color.FromArgb(34, 34, 34)
            CForeColor = Color.White
            CLineNumber = Color.SteelBlue
            CCurrentLine = Color.Black
            CSelection = Color.PowderBlue
            SetSettings()
        ElseIf ComboBox6.Text = "Visual Studio"
            CKeyword = Color.SteelBlue
            CTypeName = Color.SteelBlue
            CSubroutine = Color.FromArgb(34, 34, 34)
            CString = Color.IndianRed
            CComments = Color.ForestGreen
            CNumeric = Color.Black
            CBackColor = Color.White
            CForeColor = Color.Black
            CLineNumber = Color.FromArgb(34, 34, 34)
            CCurrentLine = Color.LightGray
            CSelection = Color.DodgerBlue
            SetSettings()
        ElseIf ComboBox6.Text = "Forest"
            CKeyword = Color.YellowGreen
            CTypeName = Color.Beige
            CSubroutine = Color.LimeGreen
            CString = Color.SpringGreen
            CComments = Color.Silver
            CNumeric = Color.MintCream
            CBackColor = Color.FromArgb(0, 43, 0)
            CForeColor = Color.GreenYellow
            CLineNumber = Color.ForestGreen
            CCurrentLine = Color.Black
            CSelection = Color.YellowGreen
            SetSettings()
        End If
    End Sub

    Private CKeyword As Color
    Private CTypeName As Color
    Private CSubroutine As Color
    Private CString As Color
    Private CComments As Color
    Private CNumeric As Color
    Private CBackColor As Color
    Private CForeColor As Color
    Private CLineNumber As Color
    Private CCurrentLine As Color
    Private CSelection As Color

    Private Sub SetSettings()
        Label11.ForeColor = CKeyword
        If CKeyword.IsNamedColor Then ComboBox1.Text = CKeyword.Name Else ComboBox1.Text = Nothing
        PictureBox1.BackColor = CKeyword

        Label16.ForeColor = CString
        If CString.IsNamedColor Then ComboBox2.Text = CString.Name Else ComboBox2.Text = Nothing
        PictureBox2.BackColor = CString

        Label17.ForeColor = CTypeName
        If CTypeName.IsNamedColor Then ComboBox5.Text = CTypeName.Name Else ComboBox5.Text = Nothing
        PictureBox3.BackColor = CTypeName

        If CBackColor.IsNamedColor Then ComboBox8.Text = CBackColor.Name Else ComboBox8.Text = Nothing
        PictureBox4.BackColor = CBackColor

        Label18.BackColor = CSelection
        If CSelection.IsNamedColor Then ComboBox13.Text = CSelection.Name Else ComboBox13.Text = Nothing
        PictureBox9.BackColor = CSelection

        Label19.ForeColor = CNumeric
        If CNumeric.IsNamedColor Then ComboBox15.Text = CNumeric.Name Else ComboBox15.Text = Nothing
        PictureBox11.BackColor = CNumeric

        Label20.ForeColor = CComments
        If CComments.IsNamedColor Then ComboBox3.Text = CComments.Name Else ComboBox3.Text = Nothing
        PictureBox8.BackColor = CComments

        Label21.BackColor = CSubroutine
        If CSubroutine.IsNamedColor Then ComboBox4.Text = CSubroutine.Name Else ComboBox4.Text = Nothing
        PictureBox7.BackColor = CSubroutine

        Label7.ForeColor = CForeColor
        If CForeColor.IsNamedColor Then ComboBox7.Text = CForeColor.Name Else ComboBox7.Text = Nothing
        PictureBox6.BackColor = CForeColor

        Label12.ForeColor = CLineNumber
        If CLineNumber.IsNamedColor Then ComboBox9.Text = CLineNumber.Name Else ComboBox9.Text = Nothing
        PictureBox5.BackColor = CLineNumber

        Label22.BackColor = CCurrentLine
        If CCurrentLine.IsNamedColor Then ComboBox14.Text = CCurrentLine.Name Else ComboBox14.Text = Nothing
        PictureBox10.BackColor = CCurrentLine

        Label11.BackColor = CBackColor
        Label16.BackColor = CBackColor
        Label17.BackColor = CBackColor
        Label19.BackColor = CBackColor
        Label20.BackColor = CBackColor
        Label21.BackColor = CBackColor
        Label7.BackColor = CBackColor
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Label20.Font = New Font(Label20.Font.FontFamily.Name, 9, FontStyle.Italic)
        Else
            Label20.Font = New Font(Label20.Font.FontFamily.Name, 9, FontStyle.Regular)
        End If
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        Label11.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label16.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label17.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label19.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        If CheckBox2.Checked Then
            Label20.Font = New Font(ComboBox10.Text, 9, FontStyle.Italic)
        Else
            Label20.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        End If
        Label21.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label7.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label22.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label12.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
        Label18.Font = New Font(ComboBox10.Text, 9, FontStyle.Regular)
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False

        Else
            Me.Opacity += 0.04
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ThemeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        NumericUpDown1.Value = My.Settings.EditorOpacity * 100.0
        NumericUpDown2.Value = CType(My.Settings.Indent, Decimal)
        ColorList = [Enum].GetNames(GetType(KnownColor))
        Dim k As New Color
        ComboBox1.Items.AddRange(ColorList)
        ComboBox2.Items.AddRange(ColorList)
        ComboBox3.Items.AddRange(ColorList)
        ComboBox4.Items.AddRange(ColorList)
        ComboBox5.Items.AddRange(ColorList)
        ComboBox7.Items.AddRange(ColorList)
        ComboBox8.Items.AddRange(ColorList)
        ComboBox13.Items.AddRange(ColorList)
        ComboBox14.Items.AddRange(ColorList)
        ComboBox15.Items.AddRange(ColorList)
        ComboBox9.Items.AddRange(ColorList)

        If My.Settings.IsItalicComment Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        Dim fnt As New InstalledFontCollection()
        For Each item In fnt.Families
            Dim WWidth As Single = TextRenderer.MeasureText("W", New Font(New FontFamily(item.Name), 9, FontStyle.Regular)).Width
            Dim IWidth As Single = TextRenderer.MeasureText("I", New Font(New FontFamily(item.Name), 9, FontStyle.Regular)).Width
            If WWidth = IWidth Then
                ComboBox10.Items.Add(item.Name)
            End If
        Next
        ComboBox10.Text = My.Settings.DefaultFont.FontFamily.Name
        Label11.ForeColor = My.Settings.KeywordColor
        If My.Settings.KeywordColor.IsNamedColor Then ComboBox1.Text = My.Settings.KeywordColor.Name
        PictureBox1.BackColor = My.Settings.KeywordColor

        Label16.ForeColor = My.Settings.StringsColor
        If My.Settings.StringsColor.IsNamedColor Then ComboBox2.Text = My.Settings.StringsColor.Name
        PictureBox2.BackColor = My.Settings.StringsColor

        Label17.ForeColor = My.Settings.TypeColor
        If My.Settings.TypeColor.IsNamedColor Then ComboBox5.Text = My.Settings.TypeColor.Name
        PictureBox3.BackColor = My.Settings.TypeColor

        If My.Settings.BackgroundColor.IsNamedColor Then ComboBox8.Text = My.Settings.BackgroundColor.Name
        PictureBox4.BackColor = My.Settings.BackgroundColor

        Label18.BackColor = My.Settings.SelectionColor
        If My.Settings.SelectionColor.IsNamedColor Then ComboBox13.Text = My.Settings.SelectionColor.Name
        PictureBox9.BackColor = My.Settings.SelectionColor

        Label19.ForeColor = My.Settings.NumericColor
        If My.Settings.NumericColor.IsNamedColor Then ComboBox15.Text = My.Settings.NumericColor.Name
        PictureBox11.BackColor = My.Settings.NumericColor

        Label20.ForeColor = My.Settings.CommentsColor
        If My.Settings.CommentsColor.IsNamedColor Then ComboBox3.Text = My.Settings.CommentsColor.Name
        PictureBox8.BackColor = My.Settings.CommentsColor

        Label21.BackColor = My.Settings.SubroutinesColor
        If My.Settings.SubroutinesColor.IsNamedColor Then ComboBox4.Text = My.Settings.SubroutinesColor.Name
        PictureBox7.BackColor = My.Settings.SubroutinesColor

        Label7.ForeColor = My.Settings.ForeGroundColor
        If My.Settings.ForeGroundColor.IsNamedColor Then ComboBox7.Text = My.Settings.ForeGroundColor.Name
        PictureBox6.BackColor = My.Settings.ForeGroundColor

        If My.Settings.LineNumberColor.IsNamedColor Then ComboBox9.Text = My.Settings.LineNumberColor.Name
        PictureBox5.BackColor = My.Settings.LineNumberColor

        Label22.BackColor = My.Settings.CurrentLine
        If My.Settings.CurrentLine.IsNamedColor Then ComboBox14.Text = My.Settings.CurrentLine.Name
        PictureBox10.BackColor = My.Settings.CurrentLine

        Label11.BackColor = PictureBox4.BackColor
        Label16.BackColor = PictureBox4.BackColor
        Label17.BackColor = PictureBox4.BackColor
        Label19.BackColor = PictureBox4.BackColor
        Label20.BackColor = PictureBox4.BackColor
        Label21.BackColor = PictureBox4.BackColor
        Label7.BackColor = PictureBox4.BackColor

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub ThemeForm_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub
End Class