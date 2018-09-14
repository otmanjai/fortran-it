Public Class Form2
    Dim pfc As Drawing.Text.PrivateFontCollection = New Drawing.Text.PrivateFontCollection
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Opacity = 0.0

        If Not My.Settings.DefaultBin = "" And Not My.Settings.DefaultLib = "" And Not My.Settings.DefaultCompilerName = "" Then
            With My.Computer.FileSystem
                If .DirectoryExists(My.Settings.DefaultBin) And .DirectoryExists(My.Settings.DefaultLib) Then
                    ComboBox1.Text = My.Settings.DefaultCompilerName
                    TextBox6.Text = My.Settings.DefaultBin
                    TextBox5.Text = My.Settings.DefaultLib
                End If
            End With
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()
        If r = DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As DialogResult = OpenFileDialog1.ShowDialog()
        If r = DialogResult.OK Then
            TextBox3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()
        If r = DialogResult.OK Then
            TextBox6.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()
        If r = DialogResult.OK Then
            TextBox5.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.DirectoryExists(TextBox2.Text) And System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z0-9_]+$") Then
            On Error GoTo 1
            If Not My.Computer.FileSystem.DirectoryExists(TextBox2.Text + "\" + TextBox1.Text) Then My.Computer.FileSystem.CreateDirectory(TextBox2.Text + "\" + TextBox1.Text)
            If Not My.Computer.FileSystem.DirectoryExists(TextBox2.Text + "\" + TextBox1.Text + "\bin") Then My.Computer.FileSystem.CreateDirectory(TextBox2.Text + "\" + TextBox1.Text + "\bin")
            My.Settings.EXE = TextBox2.Text + "\" + TextBox1.Text + "\bin"
            If Not My.Computer.FileSystem.DirectoryExists(TextBox2.Text + "\" + TextBox1.Text + "\source") Then My.Computer.FileSystem.CreateDirectory(TextBox2.Text + "\" + TextBox1.Text + "\source")
            My.Settings.SOURCE = TextBox2.Text + "\" + TextBox1.Text + "\source"
            GoTo 3
1:          NewMsgBox.MBox("An error has occured while creating project directories!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            Exit Sub
        Else
            If System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z0-9_]+$") = False Then
                NewMsgBox.MBox("Invalid project name! Only alphanumeric characters are allowed and no blank spaces are allowed.", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            Else
                NewMsgBox.MBox("Folder does not found! Error creating project directory.", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End If

            Exit Sub
        End If
3:      If CheckBox1.Checked = True Then
            My.Settings.SOURCEEDITOR = ""
        Else
            If My.Computer.FileSystem.FileExists(TextBox3.Text) And My.Computer.FileSystem.GetFileInfo(TextBox3.Text).Extension = ".exe" Then
                My.Settings.SOURCEEDITOR = TextBox3.Text
            Else
                NewMsgBox.MBox("Source editor has been set to default since the specified source editor program is not found.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End If

        If My.Computer.FileSystem.DirectoryExists(TextBox6.Text) AndAlso My.Computer.FileSystem.DirectoryExists(TextBox5.Text) Then
            Dim IsBinNameExists As Boolean = False
            Dim FInfo As New IO.DirectoryInfo(TextBox6.Text)
            For Each item As IO.FileInfo In FInfo.GetFiles()
                If Strings.Replace(item.Name, item.Extension, "") = ComboBox1.Text Then
                    IsBinNameExists = True
                    Exit For
                End If
            Next
            If IsBinNameExists Then

                My.Settings.COMPILER = ComboBox1.Text
                My.Settings.BIN = TextBox6.Text
                My.Settings.LIBRARY = TextBox5.Text
                My.Settings.CurrentProjectName = TextBox1.Text
                My.Settings.CurrentProjectPath = TextBox2.Text + "\" + TextBox1.Text + "\" + TextBox1.Text + ".fip"
                My.Settings.Save()
                On Error GoTo 4
                SaveProject()
                If ComboBox1.Text = My.Settings.DefaultCompilerName And TextBox6.Text = My.Settings.DefaultBin And TextBox5.Text = My.Settings.DefaultLib Then
                    NewMsgBox.MBox("Project has been created!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
                Else
                    Dim res As DialogResult = NewMsgBox.MBox("Project has been created! Do you wish to save the compiler settings for future?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                    If res = DialogResult.Yes Then
                        My.Settings.DefaultCompilerName = ComboBox1.Text
                        My.Settings.DefaultBin = TextBox6.Text
                        My.Settings.DefaultLib = TextBox5.Text
                        My.Settings.Save()
                    End If
                End If
                Me.Close()
                Exit Sub
4:              NewMsgBox.MBox("Error creating the new project. Project FIP file could not be saved!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                Exit Sub
            Else
                NewMsgBox.MBox("Warning: Compiler " + ComboBox1.Text + " does not exist inside the specified binary folder.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            NewMsgBox.MBox("Warning: Compiler is not found! Try a different compiler.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub





    Private Sub SaveProject()
        Dim info As New IO.FileInfo(My.Settings.CurrentProjectPath)
        My.Settings.CurrentProjectName = info.Name
        Me.Text = My.Settings.CurrentProjectName + " - Fortran-It!"
        My.Settings.Save()
        Dim Data As New IO.StreamWriter(My.Settings.CurrentProjectPath)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:PROJECTNAME")
        Data.WriteLine(My.Settings.CurrentProjectName)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:BIN")
        Data.WriteLine(My.Settings.BIN)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:CODE")
        Data.WriteLine(My.Settings.CODE)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:CODETEMPLATE")
        Data.Write(My.Settings.CODETEMPLATE)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:COMPILER")
        Data.WriteLine(My.Settings.COMPILER)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:EXE")
        Data.WriteLine(My.Settings.EXE)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:LIBRARY")
        Data.WriteLine(My.Settings.LIBRARY)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:SCRIPT")
        Data.WriteLine(My.Settings.SCRIPT)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:SOURCE")
        Data.WriteLine(My.Settings.SOURCE)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!STR:SOURCEEDITOR")
        Data.WriteLine(My.Settings.SOURCEEDITOR)
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!ARRAY:PROGRAMMAIN=" + My.Settings.PROGRAMMAIN.Count.ToString)
        For Each item As String In My.Settings.PROGRAMMAIN
            Data.WriteLine(item)
        Next
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!ARRAY:PROGRAMNAME=" + My.Settings.PROGRAMNAME.Count.ToString)
        For Each item As String In My.Settings.PROGRAMNAME
            Data.WriteLine(item)
        Next
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!ARRAY:PROGRAMSETTINGS=" + My.Settings.PROGRAMSETTINGS.Count.ToString)
        For Each item As String In My.Settings.PROGRAMSETTINGS
            Data.WriteLine(item)
        Next
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!ARRAY:PROGRAMLIB=" + My.Settings.PROGRAMLIB.Count.ToString)
        For Each item As String In My.Settings.PROGRAMLIB
            Data.WriteLine(item)
        Next
        Data.WriteLine("<FORTRAN-IT:SECTION>")
        Data.WriteLine("!ARRAY:PROGRAMMOD=" + My.Settings.PROGRAMMOD.Count.ToString)
        For Each item As String In My.Settings.PROGRAMMOD
            Data.WriteLine(item)
        Next
        Data.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox1.Enabled = False
        Else
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim k As New MainForm
        k.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text = "" And
            TextBox2.Text = "" And
            ComboBox1.Text = "" And
            TextBox5.Text = "" And
            TextBox6.Text = "" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False

        Else
            Me.Opacity += 0.04
        End If

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        ComboBox1.Items.Clear()
        If My.Computer.FileSystem.DirectoryExists(TextBox6.Text) Then
            Dim Parent As String = My.Computer.FileSystem.GetParentPath(TextBox6.Text)
            If My.Computer.FileSystem.DirectoryExists(Parent + "\lib") Then
                TextBox5.Text = Parent + "\lib"
            End If
            Dim di As New IO.DirectoryInfo(TextBox6.Text)
            For Each File In di.GetFiles()
                If File.Name.Contains(".exe") Then
                    ComboBox1.Items.Add(Strings.Replace(File.Name, ".exe", ""))
                    ComboBox1.AutoCompleteCustomSource.Add(Strings.Replace(File.Name, ".exe", ""))
                End If
            Next
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Not TextBox2.Text = "" Then
            If My.Computer.FileSystem.DirectoryExists(TextBox2.Text) Then
                My.Settings.DefaultProjectDirectory = TextBox2.Text
                My.Settings.Save()
                NewMsgBox.MBox("The specified folder has been set as default project location!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            Else
                Try
                    Dim res As DialogResult = NewMsgBox.MBox("Folder does not exist. Do you want to create the folder?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                    If res = DialogResult.Yes Then
                        My.Computer.FileSystem.CreateDirectory(TextBox2.Text)
                        My.Settings.DefaultProjectDirectory = TextBox2.Text
                        My.Settings.Save()
                        NewMsgBox.MBox("The specified folder has been set as default project location!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    NewMsgBox.MBox("Fail creating folder. Reason: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                End Try
            End If
        Else
            NewMsgBox.MBox("The 'Project Folder' text field cannot be empty!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.DefaultBin = "" Or My.Settings.DefaultLib = "" Then
            My.Settings.DefaultBin = My.Application.Info.DirectoryPath + "\MinGW\bin"
            My.Settings.DefaultLib = My.Application.Info.DirectoryPath + "\MinGW\lib"
            My.Settings.DefaultCompilerName = "gfortran"
            My.Settings.Save()
        End If

        If My.Settings.DefaultProjectDirectory = "" Or My.Settings.DefaultProjectDirectory = (My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\FortranIt") Then
            If Not My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\FortranIt") Then
                My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\FortranIt")
                My.Settings.DefaultProjectDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\FortranIt"
                My.Settings.Save()
            Else
                My.Settings.DefaultProjectDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\FortranIt"
                My.Settings.Save()
            End If
        End If
        TextBox2.Text = My.Settings.DefaultProjectDirectory
        TextBox6.Text = My.Settings.DefaultBin
        TextBox5.Text = My.Settings.DefaultLib
        ComboBox1.Text = My.Settings.DefaultCompilerName
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim k As New MainForm
        k.Show()
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\MinGW") Then
            TextBox6.Text = My.Application.Info.DirectoryPath + "\MinGW\bin"
            TextBox5.Text = My.Application.Info.DirectoryPath + "\MinGW\lib"
            ComboBox1.Text = "gfortran"
        End If

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\G77") Then
            TextBox6.Text = My.Application.Info.DirectoryPath + "\G77\bin"
            TextBox5.Text = My.Application.Info.DirectoryPath + "\G77\lib"
            ComboBox1.Text = "g77"
        End If
    End Sub
End Class