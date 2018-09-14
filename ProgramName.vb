Public Class ProgramName
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not TextBox1.Text = Nothing And Not TextBox2.Text = Nothing Then

            For Each ProgramName In My.Settings.PROGRAMNAME
                If TextBox1.Text.ToLower = ProgramName.ToLower Then
                    NewMsgBox.MBox("The specified program name already exists. Please try a new program name.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    TextBox1.Focus()
                    TextBox1.SelectAll()
                    Exit Sub
                End If
            Next

            If Not My.Computer.FileSystem.FileExists(TextBox2.Text) Then
                NewMsgBox.MBox("The specified source code does not exists!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                Dim FInfo As New IO.FileInfo(TextBox2.Text)
                If My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + FInfo.Name) Then
                    Dim res As DialogResult = NewMsgBox.MBox("The specified source code is already exists in the code bank and it will be used instead. Are you sure?", MsgBoxStyle.YesNo, MsgBoxStyle.Exclamation)
                    If res = DialogResult.Yes Then
                        Try
                            If Not FInfo.FullName = My.Settings.SOURCE + "\" + FInfo.Name Then
                                My.Computer.FileSystem.CopyFile(FInfo.FullName, My.Settings.SOURCE + "\" + FInfo.Name, True)
                            End If
                        Catch ex As Exception
                            NewMsgBox.MBox("Error: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    Else
                        Exit Sub
                    End If
                Else
                    Try
                        My.Computer.FileSystem.CopyFile(FInfo.FullName, My.Settings.SOURCE + "\" + FInfo.Name, True)
                    Catch ex As Exception
                        NewMsgBox.MBox("Error: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End Try

                End If
                Dim FName As String = My.Settings.SOURCE + "\" + FInfo.Name
                My.Settings.PROGRAMNAME.Add(Strings.Replace(TextBox1.Text, " ", ""))
                My.Settings.PROGRAMMAIN.Add(Strings.Replace(TextBox1.Text, " ", "") + "=" + FName)
                My.Settings.PROGRAMLIB.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                My.Settings.PROGRAMMOD.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                My.Settings.PROGRAMSETTINGS.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                My.Settings.NewName = Strings.Replace(TextBox1.Text, " ", "")
                My.Settings.Save()
                Form1.ChangedData = True
                Me.Close()
            End If

        Else
            NewMsgBox.MBox("Invalid program name input! Fields cannot be empty.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.InitialDirectory = My.Settings.SOURCE
        Dim r As DialogResult = OpenFileDialog1.ShowDialog()
        If r = DialogResult.OK Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Dim pfc3 As Drawing.Text.PrivateFontCollection = New Drawing.Text.PrivateFontCollection
    Private Sub ProgramName_Load(sender As Object, e As EventArgs) Handles Me.Load

        If CheckBox1.Checked = False Then
            Button4.Enabled = False
            Button1.Enabled = False
            TextBox2.Enabled = False
            Button2.Enabled = True
        Else
            Button4.Enabled = True
            Button1.Enabled = True
            TextBox2.Enabled = True
            Button2.Enabled = False
        End If
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Fortran (Old)|*.for|Fortran 90|*.f90|Fortran (Modern)|*.f"
        sfd.InitialDirectory = My.Settings.SOURCE
        Dim r As DialogResult = sfd.ShowDialog
        If r = DialogResult.OK Then
            TextBox2.Text = sfd.FileName

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
            Label2.Enabled = True
            TextBox2.Enabled = True
            Button4.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = False
        Else
            CheckBox2.Checked = True
            Label2.Enabled = False
            TextBox2.Enabled = False
            Button4.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Button2.Enabled = True
            CheckBox1.Checked = False
        Else
            Button2.Enabled = False
            CheckBox1.Checked = True
        End If
    End Sub


    Private Function AddBlank(ByVal vTab As Integer, Optional ByVal offSet As Integer = 0) As String
        AddBlank = ""
        For i = 1 To vTab * My.Settings.Indent + offSet
            AddBlank += " "
        Next
    End Function
    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click

        If Not TextBox1.Text = Nothing And System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z][a-zA-Z_\d]*$") Then
            For Each ProgramName In My.Settings.PROGRAMNAME
                If TextBox1.Text.ToLower = ProgramName.ToLower Then
                    NewMsgBox.MBox("The specified program name already exists. Please try a new program name.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    TextBox1.Focus()
                    TextBox1.SelectAll()
                    Exit Sub
                End If
            Next
            Dim ofd As New SaveFileDialog
            ofd.Filter = "FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
            ofd.InitialDirectory = My.Settings.SOURCE
            ofd.FileName = TextBox1.Text
            Dim r As DialogResult = ofd.ShowDialog()
            If r = DialogResult.OK Then
                Dim k As New IO.StreamWriter(ofd.FileName)
                k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
                k.WriteLine("!" + AddBlank(0, 5) + "THIS FORTRAN SOURCE FILE WAS GENERATED USING FORTRAN-IT.")
                k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
                k.WriteLine("!" + AddBlank(0, 5) + "Generation time: " + My.Computer.Clock.LocalTime.ToString.ToUpper)
                k.WriteLine("!" + AddBlank(0, 5) + "Author         : " + My.User.Name.ToUpper)
                k.WriteLine("!" + AddBlank(0, 5) + "Device Name    : " + My.Computer.Name.ToUpper)
                k.WriteLine("!" + AddBlank(0, 5) + "Project Name   : " + My.Settings.CurrentProjectName)
                k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
                k.WriteLine(AddBlank(0, 6))
                k.WriteLine(AddBlank(0, 6))
                k.WriteLine(AddBlank(0, 6) + "program " + Strings.Replace(TextBox1.Text, " ", ""))
                k.WriteLine(AddBlank(0, 6) + AddBlank(1))
                k.WriteLine("!" + AddBlank(0, 5) + AddBlank(1) + "Begin your code here...")
                k.WriteLine(AddBlank(0, 6) + AddBlank(1))
                k.WriteLine(AddBlank(0, 6) + AddBlank(1) + "print*, 'Program terminated successfully!'")
                k.WriteLine(AddBlank(0, 6) + "end program")
                k.WriteLine()
                k.Close()
                Try
                    Form1.NewProgramMainSourceLocation = ofd.FileName
                    My.Settings.PROGRAMNAME.Add(Strings.Replace(TextBox1.Text, " ", ""))
                    My.Settings.PROGRAMMAIN.Add(Strings.Replace(TextBox1.Text, " ", "") + "=""" + ofd.FileName + """")
                    My.Settings.PROGRAMLIB.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                    My.Settings.PROGRAMMOD.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                    My.Settings.PROGRAMSETTINGS.Add(Strings.Replace(TextBox1.Text, " ", "") + "=")
                    My.Settings.NewName = Strings.Replace(TextBox1.Text, " ", "")
                    My.Settings.Save()
                    Form1.ChangedData = True
                    Me.Close()
                Catch ex As Exception
                    NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                End Try
            End If
        Else
            If TextBox1.Text = "" Then
                NewMsgBox.MBox("Invalid program name input! 'Program Name' field cannot be empty!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z]+$") = False
                NewMsgBox.MBox("Invalid program name input! 'Program Name' field should contains only alphabets [A-Z]!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If

            TextBox1.Focus()
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Close()
    End Sub
End Class