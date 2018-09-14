Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class CodeEditor
    Shared IsTopMost As Boolean = False
    Shared IsTileMode As Boolean = False
    Private IsMeWhoTriggerTopMost As Boolean = False
    Private _codeChanged As Boolean = False
    Private _CodePath As String = ""
    Private _LoadedSourceName As String = ""
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private popMenu As AutocompleteMenu
    Sub New(ByVal CodePath As String, Optional ByVal inName As String = Nothing, Optional ByVal ingotoLine As Integer = -1, Optional ByVal ingotoCol As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()

        ToolStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode
        ToolStrip1.Renderer = New NewToolStripRenderer()
        'Setting user defined editor styles!
        TextBox1.Font = New Font(My.Settings.DefaultFont.FontFamily, TextBox1.Font.SizeInPoints, FontStyle.Regular)
        TextBox1.SyntaxHighlighter.BlueStyle = New TextStyle(New SolidBrush(My.Settings.KeywordColor), Nothing, FontStyle.Regular)
        TextBox1.SyntaxHighlighter.MagentaStyle = New TextStyle(New SolidBrush(My.Settings.NumericColor), Nothing, FontStyle.Regular)
        TextBox1.SyntaxHighlighter.BrownStyle = New TextStyle(New SolidBrush(My.Settings.StringsColor), Nothing, FontStyle.Regular)
        If My.Settings.IsItalicComment Then
            TextBox1.SyntaxHighlighter.GreenStyle = New TextStyle(New SolidBrush(My.Settings.CommentsColor), Nothing, FontStyle.Italic)
        Else
            TextBox1.SyntaxHighlighter.GreenStyle = New TextStyle(New SolidBrush(My.Settings.CommentsColor), Nothing, FontStyle.Regular)
        End If
        TextBox1.SyntaxHighlighter.SubroutineStyle = New TextStyle(New SolidBrush(My.Settings.SubroutinesColor), Nothing, FontStyle.Regular)
        TextBox1.SyntaxHighlighter.AquamarineStyle = New TextStyle(New SolidBrush(My.Settings.TypeColor), Nothing, FontStyle.Regular)
        TextBox1.BackColor = My.Settings.BackgroundColor
        TextBox1.ForeColor = My.Settings.ForeGroundColor
        TextBox1.LineNumberColor = My.Settings.LineNumberColor
        TextBox1.SelectionColor = My.Settings.SelectionColor
        TextBox1.CurrentLineColor = My.Settings.CurrentLine
        TextBox1.SyntaxHighlighter.InitStyleSchema(Language.Fortran)
        'Handle Intellisense!
        popMenu = New FastColoredTextBoxNS.AutocompleteMenu(TextBox1)
        popMenu.MinFragmentLength = 1
        popMenu.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        popMenu.LayoutStyle = ToolStripLayoutStyle.StackWithOverflow
        popMenu.BackColor = Color.Black
        popMenu.ForeColor = Color.White
        popMenu.SelectedColor = Color.FromArgb(48, 113, 173)
        popMenu.Items.MaximumSize = New System.Drawing.Size(400, 1000)
        popMenu.Items.Width = 400
        popMenu.AutoSize = True
        popMenu.AllowTabKey = True
        Dim IL As New ImageList
        IL.Images.Add(My.Resources.favicon__4_)
        IL.Images.Add(My.Resources.favicon__5_)
        IL.Images.Add(My.Resources.x2_symbol_of_a_letter_and_a_number_subscript_z5b_icon)
        popMenu.ImageList = IL
        BeginGetMyMethodName()
        BeginGetMethodName()
        Dim ACI As New List(Of AutocompleteItem)
        For Each item In SharedMethodName
            ACI.Add(New AutocompleteItem(item, 0))
        Next


        popMenu.Items.SetAutocompleteItems(ACI)

        'Load existing methods...


        Dim k As New IO.FileInfo(CodePath)
        _LoadedSourceName = k.Name
        ' Add any initialization after the InitializeComponent() call.
        TextBox1.Language = FastColoredTextBoxNS.Language.Fortran
        _CodePath = CodePath
        Try
            Dim r As New IO.StreamReader(CodePath)
            TextBox1.Text = r.ReadToEnd()
            _codeChanged = False
            r.Dispose()
            Me.Text = "Fortran Editor - " + My.Computer.FileSystem.GetFileInfo(_CodePath).Name

        Catch ex As Exception
            NewMsgBox.MBox("Error opening source code! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            Me.Dispose()
            Return
        End Try
        Timer3.Enabled = True


        If ingotoLine > -1 And ingotoCol > -1 And Not inName = Nothing Then
            frmErrText = inName
            gotoCol = ingotoCol
            gotoLine = ingotoLine
        End If
    End Sub

    Public Shared frmErrText As String = ""
    Public Shared gotoLine As Integer = -1
    Public Shared gotoCol As Integer = -1

    Private Sub doFindErrorLocation()
        If Not frmErrText = Nothing AndAlso Not gotoLine = -1 AndAlso Not gotoCol = -1 Then
            If Me.Text = frmErrText Then
                Me.Activate()
                Me.BringToFront()
                Me.TextBox1.Focus()
                TextBox1.Selection.Start = New Place(gotoCol - 1, gotoLine - 1)
                TextBox1.CurrentLineColor = Color.Yellow
                TextBox1.DoSelectionVisible()
                TextBox1.Selection.Start = New Place(gotoCol - 1, gotoLine - 1)

                gotoCol = -1
                gotoLine = -1
                frmErrText = ""
            End If
        End If

    End Sub

    Public Shared CodeEditorProgramSelect As String = ""
    Sub UpdateProg()
        ToolStripDropDownButton2.Items.Clear()
        For Each item As String In My.Settings.PROGRAMNAME
            ToolStripDropDownButton2.Items.Add(item)
        Next
    End Sub
    Private Sub FortranEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text
        IAmNew = True
        ToolStrip1.RenderMode = ToolStripRenderMode.System
        ToolStrip1.Renderer = New NewMenuStripRenderer
        PictureBox2.Visible = False
        TextBox2.Text = "  Search code"
        TextBox2.Font = New Font("Segoe UI", TextBox2.Font.SizeInPoints, FontStyle.Italic)
        TextBox1.AutoIndent = True

        TextBox1.AutoCompleteBrackets = False
        TextBox1.AutoIndentExistingLines = False
        ToolStrip1.MinimumSize = New Size(ToolStrip1.Width, ToolStrip1.Height + 10)
        Me.Opacity = 0.0
        StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        StatusStrip1.ForeColor = Color.White
        TextBox1.Focus()
        TextBox1.SelectionStart = TextBox1.Text.Length
        BeginGetMyMethodName()
        'AddHandler Me.TextBox1.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.Textbox1_TextChangedDelayed)
        TimerFadeIn.Enabled = True
        ToolStripComboBox1.Text = TextBox1.Zoom.ToString + "%"
        TextBox1.TabLength = My.Settings.Indent

        Dim FInfo As New IO.FileInfo(_CodePath)
        If FInfo.Extension.ToLower = ".bat" Or FInfo.Extension.ToLower = ".cmd" Then
            TextBox1.Language = Language.VB
            TextBox1.SyntaxHighlighter.InitStyleSchema(Language.VB)
        End If
        Timer1.Enabled = True
        UpdateProg()
    End Sub

    Private KeywordsStyle As Style = New TextStyle(Brushes.PaleTurquoise, Nothing, FontStyle.Regular)
    Private FunctionNameStyle As Style = New TextStyle(Brushes.PaleTurquoise, Nothing, FontStyle.Regular)
    Private CommentStyle As Style = New TextStyle(Brushes.Silver, Nothing, FontStyle.Italic)
    Public Shared SharedMethodName As New List(Of String)()
    Private MySharedMethodName As New List(Of String)()

    Sub BeginGetMethodName()
        Dim ACI As New List(Of AutocompleteItem)
        For Each item In SharedMethodName
            ACI.Add(New AutocompleteItem(item, 0))
        Next

        popMenu.Items.SetAutocompleteItems(ACI)




    End Sub

    Sub BeginGetMyMethodName()
        Dim Temp As New List(Of String)

        'Remove duplicates in Shared
        For Each item In SharedMethodName
            If Not Temp.Contains(item) Then
                Temp.Add(item)
            End If
        Next
        SharedMethodName.Clear()
        SharedMethodName.AddRange(Temp)
        Temp.Clear()

        'Remove duplicates in MyShared
        For Each item In MySharedMethodName
            If Not Temp.Contains(item) Then
                Temp.Add(item)
            End If
        Next
        MySharedMethodName.Clear()
        MySharedMethodName.AddRange(Temp)
        Temp.Clear()

        'Remove old MyShared from Shared
        For Each item In MySharedMethodName
            Dim RemoveSuccess As Boolean = True
            While RemoveSuccess
                RemoveSuccess = SharedMethodName.Remove(item)
            End While
        Next
        'Clear MyShare for new item update...
        MySharedMethodName.Clear()
        'Update new MyShared
        Dim regexPattern As String = "\b(function|subroutine)\b\s+([a-z][a-z0-9_]*)\(([^0-9.'""\n][^0-9.'""\n]*)\)|([a-z][a-z0-9_]*)\(\)"
        Dim regexPattern2 As String = "\b(function|subroutine)\s+(?<range>\w+)"
        For Each found In Me.TextBox1.GetRanges(regexPattern, RegexOptions.IgnoreCase)
            Dim jojo As String = found.Text
            jojo = Strings.Replace(jojo, "function", "")
            jojo = Strings.Replace(jojo, "subroutine", "")
            jojo = Strings.Replace(jojo, "FUNCTION", "")
            jojo = Strings.Replace(jojo, "SUBROUTINE", "")
            jojo = Strings.Trim(jojo)
            Dim RGX As New Regex("^\b(if|elseif|intent|dimension|select|case)\b\s*\(.*$")
            If Not jojo.ToLower = "function" And
                    Not jojo.ToLower = "subroutine" And
                    Not jojo.ToLower.Contains("intent") And
                    Not jojo.ToLower.Contains("dimension") And
                   Not RGX.IsMatch(jojo.ToLower) Then
                MySharedMethodName.Add(jojo)
            End If
        Next
        'Add New MyShared to Shared
        SharedMethodName.AddRange(MySharedMethodName)

        'Mark all methods name in textbox...
        Me.TextBox1.Range.ClearStyle(New Style() {Me.KeywordsStyle, Me.FunctionNameStyle})
        ''For Each Item As String In SharedMethodName
        'Me.TextBox1.Range.SetStyle(Me.FunctionNameStyle, "\b" + Item + "\b")
        'Next

        'Update intellisense items...
        Dim ACI As New List(Of AutocompleteItem)

        ACI.Add(New AutocompleteItem("if", 1))
        ACI.Add(New AutocompleteItem("elseif", 1))
        ACI.Add(New AutocompleteItem("program", 1))
        ACI.Add(New AutocompleteItem("else", 1))
        ACI.Add(New AutocompleteItem("do", 1))
        ACI.Add(New AutocompleteItem("while", 1))
        ACI.Add(New AutocompleteItem("select", 1))
        ACI.Add(New AutocompleteItem("case", 1))
        ACI.Add(New AutocompleteItem("endif", 1))
        ACI.Add(New AutocompleteItem("function", 1))
        ACI.Add(New AutocompleteItem("end", 1))
        ACI.Add(New AutocompleteItem("subroutine", 1))
        ACI.Add(New AutocompleteItem("use", 1))
        ACI.Add(New AutocompleteItem("not", 1))
        ACI.Add(New AutocompleteItem("for", 1))
        ACI.Add(New AutocompleteItem("forall", 1))
        ACI.Add(New AutocompleteItem("return", 1))
        ACI.Add(New AutocompleteItem("result", 1))
        ACI.Add(New AutocompleteItem("call", 1))
        ACI.Add(New AutocompleteItem("select", 1))
        ACI.Add(New AutocompleteItem("print", 0))
        ACI.Add(New AutocompleteItem("write", 0))
        ACI.Add(New AutocompleteItem("read", 0))
        ACI.Add(New AutocompleteItem("exit", 1))

        ACI.Add(New AutocompleteItem("cos(x)", 2))
        ACI.Add(New AutocompleteItem("sin(x)", 2))
        ACI.Add(New AutocompleteItem("tan(x)", 2))
        ACI.Add(New AutocompleteItem("acos(x)", 2))
        ACI.Add(New AutocompleteItem("asin(x)", 2))
        ACI.Add(New AutocompleteItem("atan(x)", 2))
        ACI.Add(New AutocompleteItem("abs(x)", 2))
        ACI.Add(New AutocompleteItem("sqrt(x)", 2))
        ACI.Add(New AutocompleteItem("exp(x)", 2))
        ACI.Add(New AutocompleteItem("log(x)", 2))
        ACI.Add(New AutocompleteItem("int(x)", 2))
        ACI.Add(New AutocompleteItem("nint(x)", 2))
        ACI.Add(New AutocompleteItem("floor(x)", 2))
        ACI.Add(New AutocompleteItem("fraction(x)", 2))
        ACI.Add(New AutocompleteItem("real(x)", 2))
        ACI.Add(New AutocompleteItem("max(x1,x2,...,xN)", 2))
        ACI.Add(New AutocompleteItem("min(x1,x2,...xN)", 2))
        ACI.Add(New AutocompleteItem("mod(x,y)", 2))
        'Remove duplicates in Shared
        For Each item In SharedMethodName
            If Not Temp.Contains(item) Then
                Temp.Add(item)
            End If
        Next
        SharedMethodName.Clear()
        SharedMethodName.AddRange(Temp)
        Temp.Clear()

        'Remove duplicates in MyShared
        For Each item In MySharedMethodName
            If Not Temp.Contains(item) Then
                Temp.Add(item)
            End If
        Next
        MySharedMethodName.Clear()
        MySharedMethodName.AddRange(Temp)
        Temp.Clear()

        For Each item In SharedMethodName
            ACI.Add(New AutocompleteItem(item, 0))
        Next

        popMenu.Items.SetAutocompleteItems(ACI)


    End Sub

    Private Sub Textbox1_TextChangedDelayed(sender As Object, e As TextChangedEventArgs) Handles TextBox1.TextChangedDelayed
        Me.TextBox1.Range.ClearStyle(New Style() {Me.KeywordsStyle, Me.FunctionNameStyle, Me.CommentStyle})
        'For Each Item As String In SharedMethodName
        'Me.TextBox1.Range.SetStyle(Me.FunctionNameStyle, "\b" + Item + "\b", RegexOptions.Compiled)
        'Next'
        Me.TextBox1.Range.ClearStyle(New Style() {Me.KeywordsStyle, Me.FunctionNameStyle, Me.CommentStyle})
        Dim CommentReg As New Regex("(^(c|C)\b.*$)|(!)[^'""\n]*$|^[^ '""\n]!.*$")
        Me.TextBox1.Range.SetStyle(CommentStyle, CommentReg)
        Dim SnippetReg As New Regex("_[A-Za-z]+_")
        Me.TextBox1.Range.SetStyle(CommentStyle, SnippetReg)

    End Sub
    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity > My.Settings.EditorOpacity Then
            TimerFadeIn.Enabled = False

        Else
            Me.Opacity += 0.04
        End If

    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBox1.TextChanged
        'On Error GoTo 1

        Try
            _codeChanged = True
            Me.Text = "Fortran Editor - (Unsaved) " + My.Computer.FileSystem.GetFileInfo(_CodePath).Name
            ToolStripLabel2.Text = ""
        Catch ex As Exception

        End Try

        If ToolStripStatusLabel7.Text = "80-CHAR" Then
            If (TextBox1.Selection.Start.iChar + 1) > 80 Then
                TextBox1.CurrentLineColor = Color.IndianRed
            Else
                TextBox1.CurrentLineColor = My.Settings.CurrentLine
            End If
        Else
            TextBox1.CurrentLineColor = My.Settings.CurrentLine
        End If

    End Sub

    Private Sub FortranEditor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _codeChanged Then
            e.Cancel = True
            Dim res As DialogResult = NewMsgBox.MBox("Save code before Exit?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Information)
            If res = DialogResult.Yes Then
                Try
                    Dim r As New IO.StreamWriter(_CodePath, False)
                    r.Write(TextBox1.Text)
                    r.Dispose()
                    _codeChanged = False
                    NewMsgBox.MBox("Code has been saved!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
                    Me.Text = "Fortran Editor - " + My.Computer.FileSystem.GetFileInfo(_CodePath).Name
                    Form1.OpenedSourceCodes.Remove(_CodePath)
                    Me.Dispose()
                Catch ex As Exception
                    NewMsgBox.MBox("Error saving the code! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                End Try
            ElseIf res = DialogResult.No
                Me.Text = My.Computer.FileSystem.GetFileInfo(_CodePath).Name
                _codeChanged = False
                Form1.OpenedSourceCodes.Remove(_CodePath)
                Me.Dispose()
            Else
                Exit Sub
            End If
        Else
            Form1.OpenedSourceCodes.Remove(_CodePath)
        End If

        Dim k As Integer = 0
        For Each item As Form In My.Application.OpenForms
            If Not item.IsDisposed Then
                k += 1
            End If
        Next
        If k = 1 Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)

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
        TextBox1.ShowFindDialog()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        TextBox1.ShowReplaceDialog()
    End Sub
    Dim tbFindChanged = False

    'This method handles keyword search.
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = vbCr Then
            Dim r As Range = If(Me.tbFindChanged, Me.TextBox1.Range.Clone(), Me.TextBox1.Selection.Clone())
            Me.tbFindChanged = False
            r.[End] = New Place(Me.TextBox1(Me.TextBox1.LinesCount - 1).Count, Me.TextBox1.LinesCount - 1)
            Dim pattern As String = Regex.Escape(Me.TextBox2.Text)
            Using enumerator As IEnumerator(Of Range) = r.GetRanges(pattern, RegexOptions.IgnoreCase).GetEnumerator()
                If enumerator.MoveNext() Then
                    Dim found As Range = enumerator.Current
                    found.Inverse()
                    Me.TextBox1.Selection = found
                    Me.TextBox1.DoSelectionVisible()
                    Return
                End If
            End Using
            NewMsgBox.MBox("Search cannot find anymore matches!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            Me.tbFindChanged = True
        Else
            Me.tbFindChanged = True
        End If
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
        TextBox1.ShowFindDialog()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceToolStripMenuItem.Click
        TextBox1.ShowReplaceDialog()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        TextBox1.Redo()
    End Sub

    Private canChangebuttonImage As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        doFindErrorLocation()
        If Form1.CanCompile And canChangebuttonImage Then
            ToolStripButton3.Image = My.Resources.play_rounded_button
            canChangebuttonImage = False
        End If

        If Form1.isCompileButtonDisabled And canChangebuttonImage Then
            ToolStrip1.Enabled = False
        Else
            ToolStrip1.Enabled = True
        End If
        If Form1.IsBuildingSignal Then

            Try
                Dim r As New IO.StreamWriter(_CodePath, False)
                r.Write(TextBox1.Text)
                r.Dispose()
                Me.Text = "Fortran Editor - " + My.Computer.FileSystem.GetFileInfo(_CodePath).Name
                ToolStripLabel2.Text = "Source code has been saved On " + My.Computer.Clock.LocalTime.ToString + "."
                _codeChanged = False

            Catch ex As Exception

            End Try
        End If

        If Me.TopMost Then
            ToolStripButton10.Checked = True
        Else
            ToolStripButton10.Checked = False
        End If
        If IsMeWhoTriggerTopMost Then
            Me.BringToFront()
        End If

        If Form1.CanCompile Then
            ToolStripButton3.Enabled = True
        Else
            ToolStripButton3.Enabled = False
        End If
        ToolStripLabel8.Text = TextBox1.TextLength.ToString + " Char(s)"
        ToolStripLabel7.Text = TextBox1.Lines.Count.ToString + " line(s)"
        ToolStripLabel6.Text = "Ln " + (TextBox1.Selection.Start.iLine + 1).ToString
        ToolStripLabel5.Text = "Col " + (TextBox1.Selection.Start.iChar + 1).ToString
        ToolStripLabel3.Text = TextBox1.Zoom.ToString + "%"

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Dim k As New ThemeForm
        k.ShowDialog()
    End Sub


    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Or e.KeyCode = Keys.Up Or
            e.KeyCode = Keys.Left Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Right Then
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
        If ToolStripStatusLabel7.Text = "80-CHAR" Then
            If (TextBox1.Selection.Start.iChar + 1) > 80 Then
                TextBox1.CurrentLineColor = Color.IndianRed
            Else
                TextBox1.CurrentLineColor = My.Settings.CurrentLine
            End If
        Else
            TextBox1.CurrentLineColor = My.Settings.CurrentLine
        End If
    End Sub

    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            BeginGetMyMethodName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        On Error Resume Next
        TextBox1.Zoom = CType(Strings.Replace(ToolStripComboBox1.Text, "%", ""), Integer)
        ToolStripComboBox1.SelectAll()
    End Sub

    Private Sub ToolStripComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            On Error Resume Next
            TextBox1.Zoom = CType(Strings.Replace(ToolStripComboBox1.Text, "%", ""), Integer)
            ToolStripComboBox1.SelectAll()
        End If
    End Sub

    Private Sub TextBox1_ZoomChanged(sender As Object, e As EventArgs) Handles TextBox1.ZoomChanged
        ToolStripComboBox1.Text = TextBox1.Zoom.ToString + "%"
        ToolStripComboBox1.SelectAll()


    End Sub

    Private Sub StatusStrip1_Paint(sender As Object, e As PaintEventArgs) Handles StatusStrip1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.StatusStrip1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub ToolStripLabel6_DoubleClick(sender As Object, e As EventArgs) Handles ToolStripLabel6.DoubleClick
        TextBox1.ShowGoToDialog()

    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        TextBox1.ShowGoToDialog()
    End Sub
    Sub AddSnippet(ByVal Code As String, ByVal Ln As Integer, ByVal Col As Integer)
        Dim tbTab As Integer = TextBox1.TabLength
        Dim cLine As Integer = TextBox1.Selection.Start.iLine
        Dim cCol As Integer = TextBox1.Selection.Start.iChar
        Dim i As Integer = 0
        Dim fnd As Integer = Col
        Dim fndl As Integer = Ln
        For Each Part In Strings.Split(Code, vbNewLine)
            If Not Trim(Part) = Nothing Then
                If i = 0 Then
                    TextBox1.InsertText(Strings.Replace(Part, "\t", Strings.LSet(" ", tbTab)) + vbNewLine)
                ElseIf i = Strings.Split(Code, vbNewLine).GetUpperBound(0)
                    TextBox1.InsertText(Strings.LSet(" ", cCol) + Strings.Replace(Part, "\t", Strings.LSet(" ", tbTab)))
                Else
                    TextBox1.InsertText(Strings.LSet(" ", cCol) + Strings.Replace(Part, "\t", Strings.LSet(" ", tbTab)) + vbNewLine)
                End If
                i += 1
            End If

        Next
        If Not fnd = -1 Then
            TextBox1.Selection.Start = New Place(cCol + fnd, cLine + fndl)
        End If
    End Sub
    Private Sub DoEnddoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoEnddoToolStripMenuItem.Click
        AddSnippet("do i=_iStart_, _iEnd_, _iStep_" + vbNewLine + "\t" + vbNewLine + "enddo", 1, TextBox1.TabLength)
    End Sub

    Private Sub DoWhileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoWhileToolStripMenuItem.Click
        AddSnippet("do while(_Condition_)" + vbNewLine + "\t" + vbNewLine + "enddo", 1, TextBox1.TabLength)
    End Sub

    Private Sub IfElseifelseEndifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IfElseifelseEndifToolStripMenuItem.Click
        AddSnippet("if () then" + vbNewLine + "\t" + vbNewLine + "elseif (_Condition_) then" + vbNewLine + "\t" + vbNewLine + "then" + vbNewLine + "\t" + vbNewLine + "endif", 0, 4)
    End Sub

    Private Sub IfElseifEndifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IfElseifEndifToolStripMenuItem.Click
        AddSnippet("if () then" + vbNewLine + "\t" + vbNewLine + "elseif (_Condition_) then" + vbNewLine + "\t" + vbNewLine + "endif", 0, 4)

    End Sub

    Private Sub IfElseEndifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IfElseEndifToolStripMenuItem.Click
        AddSnippet("if () then" + vbNewLine + "\t" + vbNewLine + "else" + vbNewLine + "\t" + vbNewLine + "endif", 0, 4)
    End Sub

    Private Sub IfEndifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IfEndifToolStripMenuItem.Click
        AddSnippet("if () then" + vbNewLine + "\t" + vbNewLine + "endif", 0, 4)
    End Sub

    Private Sub SelectCaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCaseToolStripMenuItem.Click
        AddSnippet("select case (_selection_)" + vbNewLine + "\tcase (_label_)" + vbNewLine + "\t\t" + vbNewLine + "\tcase (_label_)" + vbNewLine + "\t\t" + vbNewLine + "\tcase default" + vbNewLine + "\t\t" + vbNewLine + "end select", 0, 13)
    End Sub

    Private Sub FunctionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FunctionToolStripMenuItem.Click
        AddSnippet("_type_ function MyFunction(_parameters_)" + vbNewLine + "\t! Define parameter(s) here..." + vbNewLine + "\t" + vbNewLine + "\treturn" + vbNewLine + "end function" + vbNewLine, 0, 13)
    End Sub

    Private Sub SubroutineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubroutineToolStripMenuItem.Click
        AddSnippet("subroutine MySub(_parameters_)" + vbNewLine + "\t! Define parameter(s) here..." + vbNewLine + "\t" + vbNewLine + "\treturn" + vbNewLine + "end subroutine" + vbNewLine, 0, 13)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal

        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub



    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = False
    End Sub

    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = False
    End Sub

    Private Sub ToolStripStatusLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel7.Click
        If ToolStripStatusLabel7.Text = "" Then
            ToolStripStatusLabel7.Text = "80-CHAR"
        ElseIf ToolStripStatusLabel7.Text = "80-CHAR" Then
            ToolStripStatusLabel7.Text = ""
        End If
    End Sub

    Private Sub TextBox1_Load(sender As Object, e As EventArgs) Handles TextBox1.Load

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'This is for intellisense purpose!
        BeginGetMyMethodName()
        BeginGetMethodName()

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Form1.isCompileButtonDisabled = True
        ToolStripButton3.Image = PictureBox2.Image
        ToolStrip1.Enabled = False
        Dim k As New OutputFloat
        k.Show()
        canChangebuttonImage = True
        Form1.BeginCompile = True
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Form1.BeginRun = True
    End Sub

    Private isDropClosed As Boolean = True
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Form1.HaveToFocusNow = _CodePath Then
            Me.WindowState = FormWindowState.Minimized
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Form1.HaveToFocusNow = ""
        End If
        If Form1.CompileDone Then
            ToolStripButton3.Enabled = True
        End If
        If Not (My.Settings.PROGRAMNAME.Count = ToolStripDropDownButton2.Items.Count) Then
            UpdateProg()
        End If
        If Not CodeEditorProgramSelect = ToolStripDropDownButton2.SelectedItem And isDropClosed Then
            ToolStripDropDownButton2.SelectedItem = CodeEditorProgramSelect
        End If

    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        IsMeWhoTriggerTopMost = True
        If ToolStripButton10.Checked = True Then
            IsTopMost = True
            For Each fm As Form In My.Application.OpenForms
                If fm.Text.Contains("Fortran Editor") Then
                    fm.TopMost = True
                End If
            Next
            Me.TopMost = True
            Me.BringToFront()
        Else
            For Each fm As Form In My.Application.OpenForms
                If fm.Text.Contains("Fortran Editor") Then
                    fm.TopMost = False
                End If
            Next
            Me.TopMost = False
            Me.BringToFront()
            IsTopMost = False
        End If
    End Sub

    Private Sub FortranEditor_LostFocus(sender As Object, e As EventArgs) Handles Me.Deactivate
        IsMeWhoTriggerTopMost = False

    End Sub

    Shared isLostFocus As Boolean = False
    Private Sub FortranEditor_GotFocus(sender As Object, e As EventArgs) Handles Me.Activated
        IsMeWhoTriggerTopMost = True
        If isLostFocus Then
            For Each frm As Form In My.Application.OpenForms
                frm.BringToFront()

            Next
        End If
        isLostFocus = False
    End Sub


    Private Shared OldLocations As New List(Of Point)
    Private Shared OldSizes As New List(Of Size)
    Private Shared OldId As New List(Of String)
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        If Not OldLocations.Count = 0 Then
            For i = 0 To OldId.Count - 1
                For Each frm As Form In My.Application.OpenForms
                    If frm.Text = OldId(i) Then
                        frm.Size = New Size(OldSizes(i).Width, OldSizes(i).Height)
                        frm.Location = New Size(OldLocations(i).X, OldLocations(i).Y)
                    End If
                Next
            Next
            OldId.Clear()
            OldLocations.Clear()
            OldSizes.Clear()
        Else
            For Each frm As Form In My.Application.OpenForms
                If frm.Text.Contains("Fortran Editor") Then
                    OldLocations.Add(frm.Location)
                    OldSizes.Add(frm.Size)
                    OldId.Add(frm.Text)
                End If
            Next
            IsTileMode = True
            Dim EditorFormCount As Integer = 0
            For Each fm As Form In My.Application.OpenForms
                If fm.Text.Contains("Fortran Editor") Then
                    EditorFormCount += 1
                    fm.BringToFront()
                End If
            Next

            If EditorFormCount <= 3 Then
                Dim X As Integer = My.Computer.Screen.WorkingArea.Width
                Dim Y As Integer = My.Computer.Screen.WorkingArea.Height
                Dim WinWidth As Integer = X / EditorFormCount + 10
                Dim WinHeight As Integer = Y
                Dim i As Integer = 0
                For Each fm As Form In My.Application.OpenForms
                    If fm.Text.Contains("Fortran Editor") Then
                        fm.Size = New Size(WinWidth, WinHeight)
                        fm.BringToFront()
                        fm.Location = New Point(My.Computer.Screen.WorkingArea.Left + i * WinWidth, My.Computer.Screen.WorkingArea.Top)
                        i += 1
                    End If
                Next

            ElseIf EditorFormCount > 3
                Dim X As Integer = My.Computer.Screen.WorkingArea.Width
                Dim Y As Integer = My.Computer.Screen.WorkingArea.Height
                Dim WinWidth As Integer = X / (EditorFormCount / 2)
                Dim WinHeight As Integer = Y / 2
                Dim i As Integer = 0
                Dim j As Integer = 0

                For Each fm As Form In My.Application.OpenForms
                    If fm.Text.Contains("Fortran Editor") Then
                        If i = EditorFormCount / 2 Then
                            i = 0
                            j += 1
                        End If
                        fm.Size = New Size(WinWidth, WinHeight)
                        fm.Location = New Point(My.Computer.Screen.WorkingArea.Left + i * WinWidth, My.Computer.Screen.WorkingArea.Top + j * WinHeight)
                        i += 1
                    End If
                Next

            End If
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs)
        IsTileMode = False
    End Sub

    Private Sub ToolStripButton12_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If ToolStripButton12.Checked Then
            ToolStripStatusLabel7.Text = "80-CHAR"
        Else
            ToolStripStatusLabel7.Text = ""
        End If
    End Sub

    Private Sub ReadvarN1NToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadvarN1NToolStripMenuItem.Click
        AddSnippet("read(*,*) (, n=1, _Nmax_)", 0, 11)
    End Sub

    Private Sub SnippetsIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnippetsIOToolStripMenuItem.Click

    End Sub

    Private Sub FortranEditor_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.isFinishEditCode = True
    End Sub

    Private Sub FortranEditorEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click

    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If TextBox2.Text = "  Search code" And TextBox2.Font.Style = FontStyle.Italic Then
            TextBox2.Text = ""
        End If
        TextBox2.SelectAll()
        TextBox2.Font = New Font("Segoe UI", TextBox2.Font.SizeInPoints, FontStyle.Regular)
        TextBox2.ForeColor = Color.Black
    End Sub

    Private IAmNew As Boolean = True
    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.Text = "  Search code"
            TextBox2.Font = New Font("Segoe UI", TextBox2.Font.SizeInPoints, FontStyle.Italic)
            TextBox2.ForeColor = Color.FromArgb(65, 65, 65)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Dim r As New IO.StreamWriter(_CodePath, False)
            r.Write(TextBox1.Text)
            r.Dispose()
            Me.Text = "Fortran Editor - " + My.Computer.FileSystem.GetFileInfo(_CodePath).Name
            _codeChanged = False
            ToolStripLabel2.Text = "Source code has been saved on " + My.Computer.Clock.LocalTime.ToString + "."
        Catch ex As Exception
            NewMsgBox.MBox("Error saving the code! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            Dim sfd As New SaveFileDialog
            sfd.Filter = "Fortran Code|*" + My.Computer.FileSystem.GetFileInfo(_CodePath).Extension
            sfd.InitialDirectory = My.Settings.SOURCE
            Dim res As DialogResult = sfd.ShowDialog()
            If res = DialogResult.OK Then
                Dim k As New IO.StreamWriter(sfd.FileName)
                k.WriteLine(TextBox1.Text)
                k.Dispose()
                NewMsgBox.MBox("Fortran code has been saved!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            NewMsgBox.MBox("Error exporting the Fortran code! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LineContinuationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineContinuationToolStripMenuItem.Click
        TextBox1.InsertText(vbNewLine + "     &", True)
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub

    Private Sub ToolStripDropDownButton2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.SelectedIndexChanged
        CodeEditorProgramSelect = ToolStripDropDownButton2.SelectedItem
    End Sub

    Private Sub ToolStripDropDownButton2_DropDown(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.DropDown
        isDropClosed = False
    End Sub

    Private Sub ToolStripDropDownButton2_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.DropDownClosed
        isDropClosed = True
    End Sub

    Private Sub ToolStripDropDownButton2_MouseEnter(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.MouseEnter
        isDropClosed = False
    End Sub

    Private Sub ToolStripDropDownButton2_MouseHover(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.MouseHover
        isDropClosed = False
    End Sub

    Private Sub CodeEditor_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        isLostFocus = True
    End Sub
End Class