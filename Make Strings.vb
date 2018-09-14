Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS


Public Class Make_Strings

    Dim popupMenu As AutocompleteMenu
    Dim Founds As List(Of String)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        popupMenu = New FastColoredTextBoxNS.AutocompleteMenu(TextBox1)
        popupMenu.MinFragmentLength = 1
        popupMenu.AllowTabKey = True
        popupMenu.Font = New Font("Consolas", 9, FontStyle.Bold)
        popupMenu.ForeColor = Color.Black
        Founds = New List(Of String)
        Founds.Add("@MainSource")
        Founds.Add("@SourceLinks")
        Founds.Add("@BinPath")
        Founds.Add("@OutputPath")
        Founds.Add("@ProgramName")
        Founds.Add("@CompilerName")
        Founds.Add("@Settings")
        Founds.Add("@Path")
        Founds.Add("@SourcePath")
        Founds.Add("@LibraryPath")
        Founds.Add("@Modules")
        popupMenu.Items.SetAutocompleteItems(Founds)
    End Sub
    Private Sub Make_Strings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        StatusStrip1.ForeColor = Color.White
        TextBox1.Language = FastColoredTextBoxNS.Language.VB
        TextBox1.AutoIndentChars = False
        TextBox1.AutoIndent = True
        TextBox1.AutoCompleteBrackets = False
        TextBox1.AutoCompleteBrackets = True
        TextBox1.AutoIndentExistingLines = True
        If Form1.IsForm1Topmost Then
            Me.TopMost = True
        End If
        Me.Opacity = 0
        ToolStrip1.BackColor = Color.White
        TextBox1.Text = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(My.Settings.CODE, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")
        TextBox1.Text = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(My.Settings.CODE, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")
        Form1.ChangedData = False
        TextBox1.Focus()
        TextBox1.SelectionStart = TextBox1.Text.Length
        Timer1.Interval = 1
        Timer1.Start()

    End Sub

    Dim cp As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False

        Else
            Me.Opacity += 0.04
        End If

    End Sub

    Dim CARACTER As Integer




    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Dim ScriptChanged As Boolean = False
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim r As DialogResult = NewMsgBox.MBox("Apply the new script?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
            If r = DialogResult.Yes Then
                'Remove trailing newlines.
                ScriptChanged = False
                My.Settings.CODE = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")
                My.Settings.Save()
                Form1.ChangedData = True
            ElseIf r = DialogResult.No
                ScriptChanged = False
            End If
        Catch ex As Exception
            MsgBox("Error while saving the script file!", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        Form1.ChangedData = True
        ScriptChanged = True
        'Remove trailing newlines.
        TextBox1.Text = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(My.Settings.SCRIPTTEMPLATE, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Dim Res As DialogResult = OpenFileDialog1.ShowDialog()
            If Res = DialogResult.OK Then
                Dim k As New IO.StreamReader(OpenFileDialog1.FileName)
                TextBox1.Text = k.ReadToEnd()
                k.Close()
            End If

        Catch ex As Exception
            NewMsgBox.MBox("Error opening script file!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try

            Dim Res As DialogResult = SaveFileDialog1.ShowDialog()
            If Res = DialogResult.OK Then
                Dim k As New IO.StreamWriter(SaveFileDialog1.FileName)
                k.WriteLine("REM ----------------------------------------------------------")
                k.WriteLine("REM MAKEFILE SCRIPT CREATED BY FORTRANER (c) M. R. OMAR, 2017.")
                k.WriteLine("REM GENERATED ON " + My.Computer.Clock.LocalTime.ToString.ToUpper)
                k.WriteLine("REM ----------------------------------------------------------")
                k.WriteLine(TextBox1.Text)
                k.Close()
                NewMsgBox.MBox("Make scipt has been exported!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            NewMsgBox.MBox("Error opening script file!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        TextBox1.Cut()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        TextBox1.Paste()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        TextBox1.Undo()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        TextBox1.Redo()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim k As New FindForm(TextBox1)
        k.ShowDialog()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim k As New ReplaceForm(TextBox1)
        k.ShowDialog()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        Dim k As New FindForm(TextBox1)
        k.ShowDialog()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceToolStripMenuItem.Click
        Dim k As New ReplaceForm(TextBox1)
        k.ShowDialog()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        TextBox1.Redo()
    End Sub

    Private Sub Make_Strings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Form1.ChangedData And ScriptChanged Then
            Dim r As DialogResult = NewMsgBox.MBox("Apply script changes?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Information)
            If r = DialogResult.OK Then
                Try
                    'Remove trailing newlines.
                    My.Settings.CODETEMPLATE = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")
                    My.Settings.Save()
                    Form1.ChangedData = True
                    ScriptChanged = False
                Catch ex As Exception
                    MsgBox("Error while saving the script file!", MsgBoxStyle.Exclamation)
                End Try
            ElseIf r = DialogResult.No
                Form1.ChangedData = False
                ScriptChanged = False
            ElseIf r = DialogResult.Cancel
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TextBox1_Load(sender As Object, e As EventArgs) Handles TextBox1.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBox1.TextChanged
        Form1.ChangedData = True
        ScriptChanged = True
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub StatusStrip1_Paint(sender As Object, e As PaintEventArgs) Handles StatusStrip1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.StatusStrip1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripLabel2.Text = TextBox1.TextLength.ToString + " Char(s)"
        ToolStripLabel3.Text = TextBox1.Lines.Count.ToString + " line(s)"
        ToolStripLabel4.Text = "Ln " + (TextBox1.Selection.Start.iLine + 1).ToString
        ToolStripLabel5.Text = "Col " + (TextBox1.Selection.Start.iChar + 1).ToString
        ToolStripLabel6.Text = TextBox1.Zoom.ToString + "%"
    End Sub
End Class