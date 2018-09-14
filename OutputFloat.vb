Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class OutputFloat
    Private Sub OutputFloat_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        Me.TopMost = True
    End Sub

    Private Sub OutputFloat_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub

    Dim OutputErrorStyle As Style = New TextStyle(New SolidBrush(Color.IndianRed), Nothing, FontStyle.Italic)
    Dim PathStyle As Style = New TextStyle(New SolidBrush(Color.LightGreen), Nothing, FontStyle.Regular)
    Dim OutputErrorRegex As Regex = New Regex("(Error:|Fatal Error:)", RegexOptions.IgnoreCase)
    Private Sub OutputFloat_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 1.0
        Me.TopMost = True
        TextBox5.Text = Form1.OutputText

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub


    Private Sub TextBox5_Load(sender As Object, e As EventArgs) Handles TextBox5.Load

    End Sub

    Private Sub TextBox5_TextChangedDelayed(sender As Object, e As TextChangedEventArgs) Handles TextBox5.TextChangedDelayed
        TextBox5.Range.SetStyle(OutputErrorStyle, OutputErrorRegex)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        TextBox5.Text = Form1.OutputText


    End Sub


    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Close()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub GotoErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoErrorToolStripMenuItem.Click
        On Error Resume Next
1:      Dim rgex As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:[0-9]+:\s*$", RegexOptions.IgnoreCase)
        Dim rgex2 As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:\s*$", RegexOptions.IgnoreCase)
        If rgex.IsMatch(TextBox5.Lines(TextBox5.Selection.Start.iLine)) Then

            If Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":").GetLength(0) > 3 Then

                Dim location As String = Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(0) + ":" + Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(1)
                If My.Computer.FileSystem.FileExists(location) Then
                    If Form1.OpenedSourceCodes.Contains(location) Then
                        Dim FInfo As New IO.FileInfo(location)
                        If IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2)) And
                            IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3)) Then

                            CodeEditor.frmErrText = "Fortran Editor - " + FInfo.Name
                            CodeEditor.gotoLine = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer)
                            CodeEditor.gotoCol = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3), Integer)
                        End If
                        Exit Sub
                    Else

                        Dim FInfo As New IO.FileInfo(location)
                        If IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2)) And
                            IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3)) Then

                            Form1.OpenedSourceCodes.Add(location)
                            Dim k As New CodeEditor(location, "Fortran Editor - " + FInfo.Name, CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer), CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3), Integer))
                            k.Show()
                            '  CodeEditor.frmErrText = "Fortran Editor - " + FInfo.Name
                            ' CodeEditor.gotoLine = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer)
                            'CodeEditor.gotoCol = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3), Integer)
                        End If
                        Exit Sub
                    End If
                End If

            End If

        ElseIf rgex2.IsMatch(TextBox5.Lines(TextBox5.Selection.Start.iLine)) Then

            If Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":").GetLength(0) > 2 Then
                Dim location As String = Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(0) + ":" + Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(1)
                If My.Computer.FileSystem.FileExists(location) Then
                    If Form1.OpenedSourceCodes.Contains(location) Then
                        Dim FInfo As New IO.FileInfo(location)
                        If IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2)) Then

                            CodeEditor.frmErrText = "Fortran Editor - " + FInfo.Name
                            CodeEditor.gotoLine = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer)
                            CodeEditor.gotoCol = 1
                        End If
                        Exit Sub
                    Else

                        Dim FInfo As New IO.FileInfo(location)
                        If IsNumeric(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2)) Then

                            Form1.OpenedSourceCodes.Add(location)
                            Dim k As New CodeEditor(location, "Fortran Editor - " + FInfo.Name, CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer), 1)
                            k.Show()
                            '  CodeEditor.frmErrText = "Fortran Editor - " + FInfo.Name
                            ' CodeEditor.gotoLine = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(2), Integer)
                            'CodeEditor.gotoCol = CType(Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(3), Integer)
                        End If
                        Exit Sub
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub ContextMenuStrip8_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip8.Opening
        Dim rgex As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:[0-9]+:\s*$", RegexOptions.IgnoreCase)
        Dim rgex2 As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:\s*$", RegexOptions.IgnoreCase)
        For Each item As ToolStripMenuItem In ContextMenuStrip8.Items
            item.Enabled = False
        Next
        For Each item As ToolStripMenuItem In ContextMenuStrip8.Items
            If rgex.IsMatch(TextBox5.Lines(TextBox5.Selection.Start.iLine)) Or rgex2.IsMatch(TextBox5.Lines(TextBox5.Selection.Start.iLine)) Then
                item.Enabled = True
            End If
            If item.Text = "Clear" Then
                item.Enabled = True
            End If
        Next
    End Sub
End Class