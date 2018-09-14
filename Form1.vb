Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS
Imports System
Imports System.Linq
Imports System.Threading
Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.Diagnostics

Public Class Form1


    Public Shared ChangedData As Boolean = False
    Public Shared NewProgramMainSourceLocation As String = ""
    Public Shared IsBuildingSignal As Boolean = False
    Public Shared ProgramSourceList As New List(Of String)()
    Public Shared OpenedSourceCodes As New List(Of String)()
    Public Shared IsTopMostMode As Boolean = False
    Public Shared IsAppsFocus As Boolean = True
    Public Shared OutputText As String = ""
    Private CurrentLine As Integer
    Private isComboDrop As Boolean = False
    Private cpu As New PerformanceCounter()
    Dim pfc As PrivateFontCollection = New PrivateFontCollection
    Dim pfc2 As PrivateFontCollection = New PrivateFontCollection
    Dim pfc3 As PrivateFontCollection = New PrivateFontCollection
    Dim CurrentNodeText As String = ""
    Dim CurrentNodeParentText As String = ""
    Private KeywordsStyle As Style = New TextStyle(Brushes.IndianRed, Nothing, FontStyle.Regular)
    Private Sub UpdateTree()
        If Not My.Computer.FileSystem.DirectoryExists(My.Settings.SOURCE) Then
            Exit Sub
        End If
        ListView1.Items.Clear()
        ListView1.LargeImageList = ImageList2
        For Each File In My.Computer.FileSystem.GetFiles(My.Settings.SOURCE)
            Try
                Dim FInfo As New IO.FileInfo(File)
                If FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".f95" Then
                    Dim SR As New IO.StreamReader(File)
                    Dim Code As String
                    Do While SR.Peek() > -1
                        Code = SR.ReadLine()
                        If Strings.Left(Strings.Trim(Code), 7).ToLower() = "program" Then
                            Dim k1 As New ListViewItem
                            k1.Tag = File
                            k1.Text = FInfo.Name
                            k1.ImageIndex = 1
                            ListView1.Items.Add(k1)
                            GoTo 1
                        ElseIf Strings.Left(Strings.Trim(Code), 6).ToLower() = "module" Then
                            Dim k1 As New ListViewItem
                            k1.Tag = File
                            k1.Text = FInfo.Name
                            k1.ImageIndex = 2
                            ListView1.Items.Add(k1)
                            GoTo 1
                        End If
                    Loop
                    Dim k As New ListViewItem
                    k.Tag = File
                    k.Text = FInfo.Name
                    k.ImageIndex = 1
                    ListView1.Items.Add(k)

1:                  SR.Dispose()
                ElseIf FInfo.Extension.ToLower = ".bat"
                    Dim k As New ListViewItem
                    k.Tag = File
                    k.Text = FInfo.Name
                    k.ImageIndex = 3
                    ListView1.Items.Add(k)
                ElseIf FInfo.Extension.ToLower = ".dll"
                    Dim k As New ListViewItem
                    k.Tag = File
                    k.Text = FInfo.Name
                    k.ImageIndex = 6
                    ListView1.Items.Add(k)
                ElseIf FInfo.Extension.ToLower = ".a"
                    Dim k As New ListViewItem
                    k.Tag = File
                    k.Text = FInfo.Name
                    k.ImageIndex = 9
                    ListView1.Items.Add(k)
                End If
            Catch ex As Exception

            End Try
        Next

        For Each i In My.Settings.PROGRAMLIB

            Try
                If Strings.Split(i, "=").Count = 2 Then
                    i = Strings.Split(i, "=")(1)
                    For Each u In Strings.Split(i, ";")
                        u = Strings.Replace(u, """", "")
                        If My.Computer.FileSystem.FileExists(u) Then
                            If Not u.Contains(My.Settings.SOURCE) Then
                                Dim FInfo As New IO.FileInfo(u)
                                If FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".a Then" Then
                                    Dim SR2 As New IO.StreamReader(u)
                                    Dim Code As String = ""
                                    Do While SR2.Peek() > -1
                                        Code = SR2.ReadLine()
                                        If Strings.Left(Strings.Trim(Code), 7).ToLower() = "program" Then
                                            Dim k1 As New ListViewItem
                                            k1.Tag = u
                                            k1.Text = FInfo.Name
                                            k1.ImageIndex = 1
                                            ListView1.Items.Add(k1)
                                            GoTo 2
                                        End If
                                    Loop

                                    'Add item...
                                    Dim k2 As New ListViewItem
                                    k2.Tag = u
                                    k2.Text = FInfo.Name
                                    k2.ImageIndex = 2
                                    ListView1.Items.Add(k2)
2:                                  SR2.Dispose()
                                ElseIf FInfo.Extension.ToLower = ".dll"
                                    Dim k2 As New ListViewItem
                                    k2.Tag = u
                                    k2.Text = FInfo.Name
                                    k2.ImageIndex = 6
                                    ListView1.Items.Add(k2)
                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try
        Next


        For Each i In My.Settings.PROGRAMMOD
            Try
                If Strings.Split(i, "=").Count = 2 Then
                    i = Strings.Split(i, "=")(1)
                    For Each u In Strings.Split(i, ";")
                        u = Strings.Replace(u, """", "")
                        If My.Computer.FileSystem.FileExists(u) Then
                            If Not u.Contains(My.Settings.SOURCE) Then
                                Dim FInfo As New IO.FileInfo(u)
                                If FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".f90" Then
                                    Dim SR2 As New IO.StreamReader(u)
                                    Dim Code As String = ""
                                    Do While SR2.Peek() > -1
                                        Code = SR2.ReadLine()
                                        If Strings.Left(Strings.Trim(Code), 7).ToLower() = "program" Then
                                            Dim k1 As New ListViewItem
                                            k1.Tag = u
                                            k1.Text = FInfo.Name
                                            k1.ImageIndex = 1
                                            ListView1.Items.Add(k1)
                                            GoTo 3
                                        End If
                                    Loop

                                    'Add item...
                                    Dim k2 As New ListViewItem
                                    k2.Tag = u
                                    k2.Text = FInfo.Name
                                    k2.ImageIndex = 2
                                    ListView1.Items.Add(k2)
3:                                  SR2.Dispose()
                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try
        Next



        ListView2.Items.Clear()
        ListView2.LargeImageList = ImageList2
        For Each File In My.Computer.FileSystem.GetFiles(My.Settings.EXE)
            Dim FInfo As New IO.FileInfo(File)
            If FInfo.Extension.ToLower = ".exe" Then
                Dim k2 As New ListViewItem
                k2.Tag = File
                k2.Text = FInfo.Name
                k2.ImageIndex = 0
                ListView2.Items.Add(k2)
            ElseIf FInfo.Extension.ToLower = ".dll"
                Dim k2 As New ListViewItem
                k2.Tag = File
                k2.Text = FInfo.Name
                k2.ImageIndex = 6
                ListView2.Items.Add(k2)
            Else
                Dim k2 As New ListViewItem
                k2.Tag = File
                k2.Text = FInfo.Name
                k2.ImageIndex = 8
                ListView2.Items.Add(k2)
            End If
        Next


        TreeView1.BeginUpdate()
        Try
            CurrentNodeText = TreeView1.SelectedNode.Text
            CurrentNodeParentText = TreeView1.SelectedNode.Parent.Text
        Catch ex As Exception

        End Try
        Label1.Text = Strings.Replace(My.Settings.CurrentProjectName, ".fip", "") + vbNewLine + ComboBox1.Items.Count.ToString + " program(s)"
        If My.Computer.FileSystem.FileExists(My.Settings.BIN + "\" + My.Settings.COMPILER + ".exe") Then
            ToolStripStatusLabel3.Text = "Using compiler " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        Else
            ToolStripStatusLabel3.Text = "Warning! Compiler Not found. " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.IndianRed
        End If

        ' Label1.Text = Label1.Text.ToUpper()
        'Update program name...
        'ListBox1.Items.Clear()

        TreeView1.Nodes.Clear()
        For Each item In ComboBox1.Items
            TreeView1.Nodes.Add(item, item, 0)
        Next

        Try
            For Each ProgramMain In My.Settings.PROGRAMMAIN

                'TreeView1 Job
                Dim s = Strings.Split(ProgramMain, "=")
                If s.GetUpperBound(0) > 0 Then
                    If Not s(1) = Nothing Then
                        If TreeView1.Nodes.IndexOfKey(s(0)) > -1 Then
                            TreeView1.Nodes(TreeView1.Nodes.IndexOfKey(s(0))).Nodes.Add(s(1), "(Main) " + My.Computer.FileSystem.GetFileInfo(Strings.Replace(Strings.Replace(s(1), ";", ""), """", "")).Name, 1, 1)
                        End If
                    End If
                End If

                ''''''''''''''''''''''
            Next
        Catch ex As Exception
            If My.Computer.Name = "RABIEMSI" Then
                NewMsgBox.MBox("RABIE " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End Try

        For Each ProgramLib In My.Settings.PROGRAMLIB
            'TreeView1 Job
            Dim s = Strings.Split(ProgramLib, "=")
            If s.GetUpperBound(0) > 0 Then
                For Each item As String In Strings.Split(s(1), ";")
                    If Not item = Nothing Then
                        TreeView1.Nodes(TreeView1.Nodes.IndexOfKey(s(0))).Nodes.Add(item, "(Link) " + My.Computer.FileSystem.GetFileInfo(Strings.Replace(Strings.Replace(item, ";", ""), """", "")).Name, 2, 2)
                    End If
                Next

            End If
            '''''''''''''''''''''''''''
        Next

        For Each ProgramMod In My.Settings.PROGRAMMOD
            'TreeView1 Job
            Dim s = Strings.Split(ProgramMod, "=")
            If s.GetUpperBound(0) > 0 Then
                For Each item As String In Strings.Split(s(1), ";")
                    If Not item = Nothing Then
                        TreeView1.Nodes(TreeView1.Nodes.IndexOfKey(s(0))).Nodes.Add(item, "(Mod) " + My.Computer.FileSystem.GetFileInfo(Strings.Replace(Strings.Replace(item, ";", ""), """", "")).Name, 3, 3)
                    End If
                Next

            End If
            '''''''''''''''''''''''''''
        Next

        TreeView1.EndUpdate()
        TreeView1.ExpandAll()

        For Each Node1 As TreeNode In TreeView1.Nodes
            If CurrentNodeText = Node1.Text Then
                TreeView1.SelectedNode = Node1
                Exit For
            End If
            For Each Node2 As TreeNode In Node1.Nodes
                If CurrentNodeText = Node2.Text And CurrentNodeParentText = Node2.Parent.Text Then
                    TreeView1.SelectedNode = Node2
                    Exit For
                End If
            Next
        Next
    End Sub


    Sub New(Optional ByVal ProjectPath As String = "")

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
        ' This call is required by the designer.
        InitializeComponent()

        MenuStrip2.Renderer = New NewMenuStripRenderer()
        MenuStrip2.Height = 40
        ' Add any initialization after the InitializeComponent() call.
        If Not ProjectPath = "" Then
            My.Settings.CurrentProjectPath = ProjectPath
            My.Settings.Save()
        Else
            My.Settings.CurrentProjectPath = ProjectPath
            My.Settings.Save()
        End If
    End Sub
    Private Sub InitProgram()

        pfc.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksand.ttf")
        pfc2.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksandb.ttf")
        TextBox5.Font = New Font("Consolas", 9, FontStyle.Regular)

        Button3.Visible = False
        Button4.Enabled = False

        Button11.Enabled = False
        Button5.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button4.Enabled = False
        Button9.Enabled = False
        Label16.Font = New Font(pfc2.Families(0), 12, FontStyle.Bold)
        Label10.Font = New Font(pfc2.Families(0), 12, FontStyle.Bold)
        Button6.Font = New Font(pfc2.Families(0), 9, FontStyle.Bold)
        '   Button7.Font = New Font(pfc2.Families(0), 9, FontStyle.Bold)
        Button13.Font = New Font(pfc2.Families(0), 9, FontStyle.Bold)
        Button14.Font = New Font(pfc2.Families(0), 9, FontStyle.Bold)
        TreeView1.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        Me.MinimumSize = New Size(1000, 400)
        LinkLabel1.Enabled = False
        LinkLabel2.Enabled = False
        'LinkLabel3.Enabled = False
        LinkLabel4.Enabled = False
        ComboBox1.Items.Clear()
        TextBox1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        TextBox2.Clear()
        TextBox2_Clean()
        If Not My.Settings.PROGRAMNAME.Count = 0 Then
            For Each ProgramName In My.Settings.PROGRAMNAME
                ComboBox1.Items.Add(ProgramName)
            Next
        End If

        If ComboBox1.Text = Nothing Then
            Button2.Enabled = False
            Button17.Enabled = False
        End If
        DelinkSourceFromProgramToolStripMenuItem.Enabled = False
        ToolStripMenuItem3.Enabled = False
        isCompileButtonDisabled = True
        ExecuteToolStripMenuItem.Enabled = False
        RunToolStripMenuItem.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        ContextMenuStrip2.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip3.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip4.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip5.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip6.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip7.Renderer = New NewMenuStripRenderer()
        ContextMenuStrip8.Renderer = New NewMenuStripRenderer()
        '        Me.Opacity = 0
        If TextBox6.Text = "" Then
            TextBox6.Text = "  Search script output, code bank"
            TextBox6.Font = New Font("Segoe UI", TextBox6.Font.SizeInPoints, FontStyle.Italic)
            TextBox6.ForeColor = Color.FromArgb(65, 65, 65)
        End If

        Try
            If My.Settings.CurrentProjectPath = "" Then
                ResetCmdLine = False
                If My.Application.CommandLineArgs.Count = 1 Then

                    If My.Computer.FileSystem.FileExists(My.Application.CommandLineArgs(1)) Then
                        LoadDataNoDialog(My.Application.CommandLineArgs(1))
                        UpdateTree()
                        Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + My.Settings.BIN)
                        Environment.SetEnvironmentVariable("LIBRARY_PATH", My.Settings.LIBRARY)
                    End If
                Else
                    My.Settings.BIN = ""
                    My.Settings.CODE = ""
                    My.Settings.CODETEMPLATE = ""
                    My.Settings.COMPILER = ""
                    My.Settings.CurrentProjectName = ""
                    My.Settings.CurrentProjectPath = ""
                    My.Settings.EXE = ""
                    My.Settings.LIBRARY = ""
                    My.Settings.PROGRAMLIB.Clear()
                    My.Settings.PROGRAMMOD.Clear()
                    My.Settings.PROGRAMMAIN.Clear()
                    My.Settings.PROGRAMNAME.Clear()
                    My.Settings.PROGRAMSETTINGS.Clear()
                    My.Settings.SOURCE = ""
                    My.Settings.SOURCEEDITOR = "explorer.exe"
                    My.Settings.Save()
                End If
                InitProgram()
            Else

                If ResetCmdLine = False Then
                    LoadDataNoDialog(My.Settings.CurrentProjectPath)
                    UpdateTree()
                    ToolStripStatusLabel1.Text = "Loaded project " + My.Settings.CurrentProjectName
                    Me.Text = My.Settings.CurrentProjectName + " - Fortran-It!"
                    ChangedData = False
                End If

            End If
            'Update TreeView1
            UpdateTree()
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Error loading application!"
            NewMsgBox.MBox("Error loading application!" + vbNewLine + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
        LinkLabel2.Enabled = False
        ChangedData = False
        If My.Computer.FileSystem.FileExists(My.Settings.BIN + "\" + My.Settings.COMPILER + ".exe") Then
            ToolStripStatusLabel3.Text = "Using compiler " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.Transparent 'Color.FromArgb(48, 113, 173)
        Else
            ToolStripStatusLabel3.Text = "Warning! Compiler Not found. " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.IndianRed
        End If

        PictureBox2.Visible = False
        ' MenuStrip2.BackColor = Color.White
        StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        StatusStrip1.ForeColor = Color.White
        TextBox5.Language = FastColoredTextBoxNS.Language.Custom
        ListBox1.DrawMode = DrawMode.OwnerDrawVariable
        ListBox2.DrawMode = DrawMode.OwnerDrawVariable
        Button5.BackColor = Color.Silver

        Button11.BackColor = Color.Silver
        Button5.ForeColor = Color.White

        Button11.ForeColor = Color.White
        Button3.Visible = False

        Dim DInfo As New IO.DirectoryInfo(My.Computer.FileSystem.GetParentPath(My.Settings.CurrentProjectPath))
        If Not DInfo.Name = Strings.Replace(My.Settings.CurrentProjectName, ".fip", "") Then
            NewMsgBox.MBox("The loaded .FIP file Is Not in the correct location!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            MainPageToolStripMenuItem_Click(Me, Nothing)
            Exit Sub
        End If
        If Not My.Computer.FileSystem.DirectoryExists(DInfo.Parent.FullName + "\" + Strings.Replace(My.Settings.CurrentProjectName, ".fip", "") + "\bin") Or
                 Not My.Computer.FileSystem.DirectoryExists(DInfo.Parent.FullName + "\" + Strings.Replace(My.Settings.CurrentProjectName, ".fip", "") + "\source") Then
            NewMsgBox.MBox("The loaded .FIP file Is Not in the correct location!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            MainPageToolStripMenuItem_Click(Me, Nothing)
            Exit Sub
        End If
        Me.Opacity = 1.0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim NewProgramDialog As New ProgramName
        NewProgramDialog.ShowDialog()
        InitProgram()
        ComboBox1.SelectedItem = My.Settings.NewName
        If NewProgramMainSourceLocation <> "" Then
            If Trim(My.Settings.SOURCEEDITOR) = "" Then
                Dim j As New CodeEditor(NewProgramMainSourceLocation)
                j.Show()
            Else
                Try
                    Shell(My.Settings.SOURCEEDITOR + " " + NewProgramMainSourceLocation, AppWinStyle.NormalFocus)
                Catch ex As Exception
                    Shell("explorer.exe" + " " + NewProgramMainSourceLocation, AppWinStyle.NormalFocus)
                End Try
            End If
        End If
        NewProgramMainSourceLocation = ""
        UpdateTree()
        ComboBox1.SelectedItem = My.Settings.NewName
        For Each Node As TreeNode In TreeView1.Nodes
            If ComboBox1.Text = Node.Text Then
                TreeView1.SelectedNode = Node
            End If
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Update program name...
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        For Each ProgramMain In My.Settings.PROGRAMMAIN
            'TreeView1 Job

            ''''''''''''''''''''''
            If ProgramMain.Contains(ComboBox1.Text + "=") Then
                TextBox1.Text = Strings.Replace(Strings.Replace(ProgramMain, """", ""), ComboBox1.Text + "=", "")
            End If
        Next

        For Each ProgramLib In My.Settings.PROGRAMLIB
            'TreeView1 Job

            '''''''''''''''''''''''''''
            If ProgramLib.Contains(ComboBox1.Text + "=") Then
                For Each item As String In Strings.Split(Strings.Replace(ProgramLib, ComboBox1.Text + "=", ""), ";")
                    If Not item = Nothing Then
                        ListBox1.Items.Add(Trim(Strings.Replace(item, """", "")))
                    End If
                Next
            End If
        Next

        For Each ProgramMod In My.Settings.PROGRAMMOD
            'TreeView1 Job

            '''''''''''''''''''''''''''
            If ProgramMod.Contains(ComboBox1.Text + "=") Then
                For Each item As String In Strings.Split(Strings.Replace(ProgramMod, ComboBox1.Text + "=", ""), ";")
                    If Not item = Nothing Then
                        ListBox2.Items.Add(Trim(Strings.Replace(item, """", "")))
                    End If
                Next
            End If
        Next

        For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
            If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                TextBox2.Text = Strings.Replace(Strings.Replace(ProgramSettings, ComboBox1.Text + "=", ""), ";", vbNewLine)
                Exit For
            End If
        Next
        If ComboBox1.Text = Nothing Then
            'ExecuteToolStripMenuItem.Enabled = False
            Button12.Enabled = False
        Else
            ' ExecuteToolStripMenuItem.Enabled = True
            Button12.Enabled = True
        End If


        'This is for intellisense purpose!
        Try
            'Search method names in source files.
            ProgramSourceList.Clear()
            ProgramSourceList.Add(TextBox1.Text)
            For Each item In ListBox1.Items
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim k As New IO.FileInfo(item)
                    If Strings.Replace(k.Extension.ToLower, ".", "") = "f" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "for" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f77" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f90" Then
                        ProgramSourceList.Add(item)
                    End If
                End If
            Next

            For Each item In ListBox2.Items
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim k As New IO.FileInfo(item)
                    If Strings.Replace(k.Extension.ToLower, ".", "") = "f" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "for" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f77" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f90" Then
                        ProgramSourceList.Add(item)
                    End If
                End If
            Next
            CodeEditor.SharedMethodName.Clear()
            Dim kBox As New FastColoredTextBox()
            For Each item In Form1.ProgramSourceList
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim sr As New IO.StreamReader(item)
                    kBox.Text = sr.ReadToEnd()
                    sr.Dispose()

                    Dim Ranges As New List(Of Range)(kBox.GetRanges("\b(function|subroutine)\b\s+([a-z][a-z0-9_]*)\(([^0-9.'""\n][^0-9.'""\n]*)\)|([a-z][a-z0-9_]*)\(\)", RegexOptions.IgnoreCase))
                    For Each found As Range In Ranges
                        Dim jojo As String = found.Text
                        jojo = Strings.Replace(jojo, "function", "")
                        jojo = Strings.Replace(jojo, "subroutine", "")
                        jojo = Strings.Replace(jojo, "FUNCTION", "")
                        jojo = Strings.Replace(jojo, "SUBROUTINE", "")
                        jojo = Strings.Trim(jojo)
                        If Not CodeEditor.SharedMethodName.Contains(jojo) And Not jojo.ToLower = "function" And
                             Not jojo.ToLower = "subroutine" Then
                            Dim RGX As New Regex("^\b(if|elseif|intent|dimension|select|case)\b\s*\(.*$")
                            If Not jojo.ToLower = "function" And
                    Not jojo.ToLower = "subroutine" And
                    Not jojo.ToLower.Contains("intent") And
                    Not jojo.ToLower.Contains("dimension") And
                   Not RGX.IsMatch(jojo.ToLower) Then
                                CodeEditor.SharedMethodName.Add(jojo)
                            End If
                        End If
                    Next
                End If
            Next
            kBox.Dispose()
            CodeEditor.CodeEditorProgramSelect = ComboBox1.SelectedItem
        Catch ex As Exception

        End Try


    End Sub


    Sub TextBox2_Clean()
        Dim G As String = ""
        Dim i As Integer = 0
        For Each line In TextBox2.Lines
            If Not Trim(line) = "" Or Not Trim(line) = Nothing Then
                If i = 0 Then
                    G = line
                ElseIf i = TextBox2.Lines.GetUpperBound(0)
                    G += vbNewLine + line
                Else
                    G += vbNewLine + line
                End If
            End If
            i += 1
        Next
        TextBox2.Text = G
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            NewMsgBox.MBox("Please select a program name from the dropdown list.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
        Dim T As String = ""
        If Button2.Tag = "Edit" Then
            isCompileButtonDisabled = True
            ' ContextMenuStrip5.Enabled = False
            TextBox2_Clean()
            TextBox2.ReadOnly = False
            DelinkSourceFromProgramToolStripMenuItem.Enabled = True
            Button2.BackgroundImage = My.Resources.save
            Button17.BackgroundImage = My.Resources.save
            Button2.Tag = "Save"
            LinkLabel1.Enabled = True
            LinkLabel2.Enabled = True
            'LinkLabel3.Enabled = True
            LinkLabel4.Enabled = True
            Button3.Visible = True
            Button4.Enabled = True
            Button1.Enabled = False
            Button11.Enabled = True
            Button5.Enabled = True
            Button9.Enabled = True
            Button10.Enabled = True
            Button4.Enabled = True
            Button9.Enabled = True
            Button5.BackColor = Color.FromArgb(45, 45, 45)
            Button11.BackColor = Color.FromArgb(45, 45, 45)
            Button5.ForeColor = Color.White
            Button11.ForeColor = Color.White
            ExecuteToolStripMenuItem.Enabled = False
            ToolStripMenuItem3.Enabled = True
            Timer2.Enabled = False
            Button13.Enabled = False
        ElseIf Button2.Tag = "Save" Then

            'ToolStripMenuItem3.Enabled = False
            ContextMenuStrip5.Enabled = True
            isCompileButtonDisabled = False

            DelinkSourceFromProgramToolStripMenuItem.Enabled = False
            Dim Temp As String = ""
            For Each ProgramLib In My.Settings.PROGRAMLIB
                If ProgramLib.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMLIB.Remove(ProgramLib)
                    For Each item As String In ListBox1.Items
                        Temp += """" + item + """;"
                    Next
                    My.Settings.PROGRAMLIB.Add(ComboBox1.Text + "=" + Temp)
                    Exit For
                End If
            Next

            Dim Temp2 As String = ""
            For Each ProgramMod In My.Settings.PROGRAMMOD
                If ProgramMod.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMOD.Remove(ProgramMod)
                    For Each item As String In ListBox2.Items
                        Temp2 += """" + item + """;"
                    Next
                    My.Settings.PROGRAMMOD.Add(ComboBox1.Text + "=" + Temp2)
                    Exit For
                End If
            Next

            For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
                If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMSETTINGS.Remove(ProgramSettings)
                    My.Settings.PROGRAMSETTINGS.Add(ComboBox1.Text + "=" + Strings.Replace(TextBox2.Text, vbNewLine, ";"))
                    Exit For
                End If
            Next

            For Each ProgramMain In My.Settings.PROGRAMMAIN
                If ProgramMain.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMAIN.Remove(ProgramMain)
                    My.Settings.PROGRAMMAIN.Add(ComboBox1.Text + "=""" + TextBox1.Text + """")

                    Exit For
                End If
            Next
            T = ComboBox1.Text
            My.Settings.Save()
            Button2.Tag = "Edit"
            Button2.BackgroundImage = My.Resources.edit
            Button17.BackgroundImage = My.Resources.edit
            InitProgram()
            TextBox2_Clean()
            TextBox2.ReadOnly = True
            LinkLabel1.Enabled = False
            Button1.Enabled = True
            LinkLabel2.Enabled = False
            'LinkLabel3.Enabled = False
            LinkLabel4.Enabled = False
            ComboBox1.SelectedItem = T
            Button3.Visible = False
            Button4.Enabled = False
            Button11.Enabled = False
            Button5.Enabled = False
            Button9.Enabled = False
            Button10.Enabled = False
            Button4.Enabled = False
            Button9.Enabled = False
            Button5.BackColor = Color.Silver
            Button11.BackColor = Color.Silver
            Button5.ForeColor = Color.White
            Button11.ForeColor = Color.White
            ChangedData = True
            UpdateTree()
            Button13.Enabled = True
            Timer2.Enabled = True
        End If
        TextBox2_Clean()
        Panel2.ScrollControlIntoView(ComboBox1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ToolStripMenuItem3.Enabled = False
        Dim T As String = ""
        ContextMenuStrip5.Enabled = True
        isCompileButtonDisabled = False
        DelinkSourceFromProgramToolStripMenuItem.Enabled = False
        T = ComboBox1.Text
        Button2.Tag = "Edit"
        Button2.BackgroundImage = My.Resources.edit
        Button17.BackgroundImage = My.Resources.edit
        InitProgram()
        TextBox2_Clean()
        LinkLabel2.Enabled = False
        LinkLabel2.Enabled = False
        ComboBox1.SelectedItem = T
        Button3.Visible = False
        Button4.Enabled = False
        Button11.Enabled = False
        Button5.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button4.Enabled = False
        Button9.Enabled = False
        Button5.BackColor = Color.Silver
        Button11.BackColor = Color.Silver
        Button5.ForeColor = Color.White
        Button11.ForeColor = Color.White
        ChangedData = True
        UpdateTree()

        Timer2.Enabled = True
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If ComboBox1.SelectedItem = Nothing Then
            Button2.Enabled = False
            Button17.Enabled = False
        Else
            Button2.Enabled = True
            Button17.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        If ComboBox1.SelectedItem = Nothing Then
            Button2.Enabled = False
            Button17.Enabled = False
        Else
            Button2.Enabled = True
            Button17.Enabled = True
        End If

    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.SelectedItem = Nothing Then
            Button2.Enabled = False
            Button17.Enabled = False
        Else
            Button2.Enabled = True
            Button17.Enabled = True
        End If

    End Sub



    Public Shared CompileDone As Boolean = False
    Private Sub Async_Exited(ByVal sender As Object, ByVal e As EventArgs)
        CompileDone = True
        IsBuildingSignal = False

    End Sub
    Private Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Try
            Me.Invoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
        Catch
            Exit Sub
        End Try
    End Sub
    Private Sub Sync_Output(ByVal text As String)
        If Not Trim(text) = Nothing Then
            TextBox5.AppendText(text & Environment.NewLine)
        End If
    End Sub

    Private psi As ProcessStartInfo
    Private cmd As Process
    Private Delegate Sub InvokeWithString(ByVal text As String)


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox5.Clear()
        OpenFileDialog1.InitialDirectory = My.Settings.SOURCE
        Dim DR As DialogResult = OpenFileDialog1.ShowDialog()
        If DR = DialogResult.OK Then
            For Each item In OpenFileDialog1.FileNames
                If Not item = TextBox1.Text Then
                    If Not ListBox1.Items.Contains(item) Then
                        If My.Computer.FileSystem.FileExists(item) Then
                            Dim FInfo As New IO.FileInfo(item)
                            If FInfo.Extension.ToLower = ".dll" Then

                                ListBox1.Items.Add(My.Settings.SOURCE + "\" + FInfo.Name)

                                If Not TextBox2.Text.Contains("-L@SourcePath") Then
                                    Dim G As String = ""
                                    For Each line In TextBox2.Lines
                                        If Not Trim(line) = "" Then
                                            G += line + vbNewLine
                                        End If
                                    Next
                                    TextBox2.Text = G
                                    If TextBox2.Lines.Count = 0 Then
                                        TextBox2.AppendText("-L@SourcePath" + vbNewLine)
                                    Else
                                        TextBox2.AppendText(vbNewLine + "-L@SourcePath" + vbNewLine)
                                    End If
                                    TextBox2_Clean()
                                End If
                            Else
                                ListBox1.Items.Add(My.Settings.SOURCE + "\" + FInfo.Name)
                            End If
                            Dim FInfos As New IO.FileInfo(item)
                            Try
                                If FInfos.Extension = ".dll" Then
                                    My.Computer.FileSystem.CopyFile(item, My.Settings.EXE + "\" + FInfos.Name, True)
                                End If
                                My.Computer.FileSystem.CopyFile(item, My.Settings.SOURCE + "\" + FInfos.Name, True)
                                TextBox5.AppendText(vbNewLine + "OK: " + item + " linked!" + vbNewLine)
                            Catch ex As Exception
                                Try

                                    My.Computer.FileSystem.DeleteFile(item, My.Settings.SOURCE + "\" + FInfos.Name, True)
                                    My.Computer.FileSystem.DeleteFile(item, My.Settings.EXE + "\" + FInfos.Name, True)
                                Catch
                                    ListBox1.Items.Remove(My.Settings.EXE + "\" + FInfos.Name)
                                End Try
                            End Try

                        End If
                    Else
                        TextBox5.AppendText(vbNewLine + "Warning: " + item + " is already linked!" + vbNewLine)
                    End If
                Else
                    TextBox5.AppendText(vbNewLine + "Warning: " + "Linked source(s) cannot be the same with the main source!" + vbNewLine)
                End If
            Next
        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.InitialDirectory = My.Settings.SOURCE
        Dim DR As DialogResult = OpenFileDialog1.ShowDialog()
        If DR = DialogResult.OK Then
            Dim FInfo As New IO.FileInfo(OpenFileDialog1.FileName)
            If My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + FInfo.Name) Then
                Dim res As DialogResult = NewMsgBox.MBox("The specified source code is already exists in the code bank and it will be used instead. Are you sure?", MsgBoxStyle.YesNo, MsgBoxStyle.Exclamation)
                If res = DialogResult.Yes Then
                    Try
                        If Not My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + FInfo.Name) Then
                            My.Computer.FileSystem.CopyFile(FInfo.FullName, My.Settings.SOURCE + "\" + FInfo.Name, True)
                        Else
                            TextBox1.Text = My.Settings.SOURCE + "\" + FInfo.Name
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
            TextBox1.Text = My.Settings.SOURCE + "\" + FInfo.Name
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)

    End Sub
    Public Shared IsForm1Topmost As Boolean = False



    Private Sub Button11_Click(sender As Object, e As EventArgs)
        Shell("explorer.exe " + My.Settings.EXE, AppWinStyle.NormalFocus, False)
    End Sub


    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If e.Button = MouseButtons.Left And ListBox1.SelectedItems.Count > 0 And ListBox1.SelectedItem <> Nothing Then
            If Not OpenedSourceCodes.Contains(ListBox1.SelectedItem) Then

                If My.Settings.SOURCEEDITOR = "" Then
                    OpenedSourceCodes.Add(ListBox1.SelectedItem.ToString)
                    Dim j As New CodeEditor(ListBox1.SelectedItem.ToString)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    Try
                        Shell(My.Settings.SOURCEEDITOR + " """ + ListBox1.SelectedItem + """", AppWinStyle.NormalFocus)
                    Catch ex As Exception
                        Shell("explorer.exe" + " """ + ListBox1.SelectedItem + """", AppWinStyle.NormalFocus)
                    End Try
                End If
            Else
                Form1.HaveToFocusNow = ListBox1.SelectedItem.ToString
                'NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub ListBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDoubleClick
        If e.Button = MouseButtons.Left And ListBox2.SelectedItems.Count > 0 And ListBox2.SelectedItem <> Nothing Then
            If Not OpenedSourceCodes.Contains(ListBox2.SelectedItem) Then

                If My.Settings.SOURCEEDITOR = "" Then
                    OpenedSourceCodes.Add(ListBox2.SelectedItem.ToString)
                    Dim j As New CodeEditor(ListBox2.SelectedItem.ToString)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    Try
                        Shell(My.Settings.SOURCEEDITOR + " """ + ListBox2.SelectedItem + """", AppWinStyle.NormalFocus)
                    Catch ex As Exception
                        Shell("explorer.exe" + " """ + ListBox2.SelectedItem + """", AppWinStyle.NormalFocus)
                    End Try
                End If
            Else
                Form1.HaveToFocusNow = ListBox2.SelectedItem.ToString
                'NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub



    Dim HiLiteBrush As New SolidBrush(Color.Silver)

    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        Try
            Dim Bnd As New Rectangle(New Point(e.Bounds.Location.X + 15, e.Bounds.Location.Y + 3), New Size(e.Bounds.Size.Width - 3, e.Bounds.Size.Height - 3))
            Dim BndS As New Rectangle(New Point(e.Bounds.Location.X, e.Bounds.Location.Y), New Size(e.Bounds.Size.Width - 3, e.Bounds.Size.Height - 3))
            e.DrawBackground()
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(HiLiteBrush, e.Bounds)
                Using b As New SolidBrush(Color.Black)
                    e.Graphics.DrawString((e.Index + 1).ToString, New Font("Segoe UI", 6, FontStyle.Regular), b, BndS)
                    e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, b, Bnd)
                End Using
            Else
                Using b As New SolidBrush(Color.White)
                    e.Graphics.DrawString((e.Index + 1).ToString, New Font("Segoe UI", 6, FontStyle.Regular), b, BndS)
                    e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, b, Bnd)
                End Using
            End If

            e.DrawFocusRectangle()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox2.DrawItem
        Try
            Dim Bnd As New Rectangle(New Point(e.Bounds.Location.X + 15, e.Bounds.Location.Y + 3), New Size(e.Bounds.Size.Width - 3, e.Bounds.Size.Height - 3))
            Dim BndS As New Rectangle(New Point(e.Bounds.Location.X, e.Bounds.Location.Y), New Size(e.Bounds.Size.Width - 3, e.Bounds.Size.Height - 3))
            e.DrawBackground()
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(HiLiteBrush, e.Bounds)
                Using b As New SolidBrush(Color.Black)
                    e.Graphics.DrawString((e.Index + 1).ToString, New Font("Segoe UI", 6, FontStyle.Regular), b, BndS)
                    e.Graphics.DrawString(ListBox2.GetItemText(ListBox2.Items(e.Index)), e.Font, b, Bnd)
                End Using
            Else
                Using b As New SolidBrush(Color.White)
                    e.Graphics.DrawString((e.Index + 1).ToString, New Font("Segoe UI", 6, FontStyle.Regular), b, BndS)
                    e.Graphics.DrawString(ListBox2.GetItemText(ListBox2.Items(e.Index)), e.Font, b, Bnd)
                End Using
            End If

            e.DrawFocusRectangle()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TextBox1.Text <> Nothing Then
            If My.Settings.SOURCEEDITOR = "" Then
                Dim j As New CodeEditor(TextBox1.Text)
                j.Show()
                ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
            Else
                Try
                    Shell(My.Settings.SOURCEEDITOR + " """ + TextBox1.Text + """", AppWinStyle.NormalFocus)
                Catch ex As Exception
                    Shell("explorer.exe" + " """ + TextBox1.Text + """", AppWinStyle.NormalFocus)
                End Try
            End If

        End If
    End Sub

    Public Shared Sub ClearSettings()

        My.Settings.BIN = ""
        My.Settings.CODE = ""
        My.Settings.COMPILER = ""
        My.Settings.CurrentProjectName = ""
        My.Settings.CurrentProjectPath = ""
        My.Settings.EXE = ""
        My.Settings.LIBRARY = ""
        My.Settings.NewName = ""
        My.Settings.PROGRAMLIB.Clear()
        My.Settings.PROGRAMMOD.Clear()
        My.Settings.PROGRAMMAIN.Clear()
        My.Settings.PROGRAMNAME.Clear()
        My.Settings.PROGRAMSETTINGS.Clear()
        My.Settings.SOURCE = ""
        My.Settings.SOURCEEDITOR = ""
        My.Settings.Save()
    End Sub

    Private Sub SaveProject(Optional ByVal NewFile As Boolean = True, Optional ByVal isExport As Boolean = False)
        If NewFile Then
            Dim OFD As New SaveFileDialog
            OFD.Filter = "FORTRAN-IT PROJECT|*.fip"
            Dim Res As DialogResult = OFD.ShowDialog()
            If Res = DialogResult.OK Then
                Dim info As New IO.FileInfo(OFD.FileName)
                My.Settings.CurrentProjectName = info.Name
                My.Settings.CurrentProjectPath = OFD.FileName
                Me.Text = My.Settings.CurrentProjectName + " - Fortran-It!"
                My.Settings.Save()
                Dim Data As New IO.StreamWriter(OFD.FileName)
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
                My.Settings.EXE = Strings.Replace(My.Settings.EXE, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                Data.WriteLine(My.Settings.EXE)
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!STR:LIBRARY")
                Data.WriteLine(My.Settings.LIBRARY)
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!STR:SCRIPT")
                Data.WriteLine(My.Settings.SCRIPT)
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!STR:SOURCE")
                My.Settings.SOURCE = Strings.Replace(My.Settings.SOURCE, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                Data.WriteLine(My.Settings.SOURCE)
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!STR:SOURCEEDITOR")
                Data.WriteLine(My.Settings.SOURCEEDITOR)
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!ARRAY:PROGRAMMAIN=" + My.Settings.PROGRAMMAIN.Count.ToString)
                For Each item As String In My.Settings.PROGRAMMAIN
                    item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
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
                    item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                    Data.WriteLine(item)
                Next
                Data.WriteLine("<FORTRAN-IT:SECTION>")
                Data.WriteLine("!ARRAY:PROGRAMMOD=" + My.Settings.PROGRAMMOD.Count.ToString)
                For Each item As String In My.Settings.PROGRAMMOD
                    item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                    Data.WriteLine(item)
                Next
                Data.Dispose()

            End If
            ChangedData = False
            ToolStripStatusLabel1.Text = "Project file has been saved! Project: " + My.Settings.CurrentProjectName
        Else

            Dim info As New IO.FileInfo(My.Settings.CurrentProjectPath)
            My.Settings.CurrentProjectName = info.Name
            Me.Text = My.Settings.CurrentProjectName + " - Fortran-It!"
            My.Settings.Save()
            Dim Data As New IO.StreamWriter(My.Settings.CurrentProjectPath)
            Data.WriteLine(" <FORTRAN-IT:SECTION>")
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
            My.Settings.EXE = Strings.Replace(My.Settings.EXE, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
            Data.WriteLine(My.Settings.EXE)
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!STR:LIBRARY")
            Data.WriteLine(My.Settings.LIBRARY)
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!STR:SCRIPT")
            Data.WriteLine(My.Settings.SCRIPT)
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!STR:SOURCE")
            My.Settings.SOURCE = Strings.Replace(My.Settings.SOURCE, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
            Data.WriteLine(My.Settings.SOURCE)
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!STR:SOURCEEDITOR")
            Data.WriteLine(My.Settings.SOURCEEDITOR)
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!ARRAY:PROGRAMMAIN=" + My.Settings.PROGRAMMAIN.Count.ToString)
            For Each item As String In My.Settings.PROGRAMMAIN
                item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
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
                item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                Data.WriteLine(item)
            Next
            Data.WriteLine("<FORTRAN-IT:SECTION>")
            Data.WriteLine("!ARRAY:PROGRAMMOD=" + My.Settings.PROGRAMMOD.Count.ToString)
            For Each item As String In My.Settings.PROGRAMMOD
                item = Strings.Replace(item, My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName, "%DIR%")
                Data.WriteLine(item)
            Next
            Data.Dispose()
            ChangedData = False
            ToolStripStatusLabel1.Text = "Project file has been saved!" + " " + "Project: " + My.Settings.CurrentProjectName
        End If
        LoadDataNoDialog(My.Settings.CurrentProjectPath, False)
    End Sub
    Private Function ReadProjString(ByVal Data As String, ByVal Param As String) As String
        Dim Sections = Strings.Split(Data, "<FORTRAN-IT:SECTION>")
        For Each Section As String In Sections
            If Strings.Split(Section, "!STR:" + Param.ToUpper).GetUpperBound(0) > 0 Then
                Dim retVal As String = ""
                For i = 1 To Strings.Split(Section, "!STR:" + Param.ToUpper).GetUpperBound(0)
                    retVal += Strings.Split(Section, "!STR:" + Param.ToUpper)(i)
                Next
                retVal = Strings.Replace(retVal, "%DIR%", My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName)
                Return retVal
            End If
        Next
        Return Nothing
    End Function

    Private Function ReadProjStrCol(ByVal Data As String, ByVal Param As String) As Specialized.StringCollection

        Dim Sections = Strings.Split(Data, "<FORTRAN-IT:SECTION>")
        ReadProjStrCol = New Specialized.StringCollection()
        For Each Section As String In Sections
            If Strings.Split(Section, "!ARRAY:" + Param.ToUpper).GetUpperBound(0) > 0 Then
                Dim retVal As String = ""
                For i = 1 To Strings.Split(Section, "!ARRAY:" + Param.ToUpper).GetUpperBound(0)
                    retVal += Strings.Split(Section, "!ARRAY:" + Param.ToUpper)(i)
                Next
                If IsNumeric(Strings.Replace(Strings.Split(retVal, vbNewLine)(0), "=", "")) Then
                    Dim count As Integer = CInt(Strings.Replace(Strings.Split(retVal, vbNewLine)(0), "=", ""))
                    If Strings.Split(retVal, vbNewLine).GetUpperBound(0) > 0 Then
                        For i = 1 To count
                            ReadProjStrCol.Add(Strings.Split(Strings.Replace(retVal, "%DIR%", My.Computer.FileSystem.GetFileInfo(My.Settings.CurrentProjectPath).Directory.FullName), vbNewLine)(i))
                        Next
                        Return ReadProjStrCol
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub LoadDataNoDialog(ByVal Target As String, Optional ByVal initData As Boolean = True)
        If Not My.Computer.FileSystem.FileExists(Target) Then
            ToolStripStatusLabel1.Text = "Cannot open FIP at " + Target + " Reason: File not exists!"
            Exit Sub
        End If
        If Not My.Computer.FileSystem.GetFileInfo(Target).Extension.ToUpper = ".FIP" Then
            ToolStripStatusLabel1.Text = "Cannot open FIP at " + Target + " Reason: Invalid extension!"
            Exit Sub
        End If

        Dim Inp
        Dim dATA As String = ""
        Try
            Inp = New IO.StreamReader(Target)
            dATA = Inp.ReadToEnd()
            Inp.Dispose()
        Catch ex As Exception
            NewMsgBox.MBox("Error loading FIP file! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
        Dim Corrupted As Boolean = False
        If Strings.Split(dATA, "<FORTRAN-IT:SECTION>").GetUpperBound(0) > 0 Then
            If Not dATA.Contains("!STR:BIN") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:PROJECTNAME") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:BIN") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:CODE") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:CODETEMPLATE") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:COMPILER") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:EXE") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:LIBRARY") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:SCRIPT") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!STR:SOURCE") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!ARRAY:PROGRAMMAIN") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!ARRAY:PROGRAMNAME") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!ARRAY:PROGRAMSETTINGS") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!ARRAY:PROGRAMLIB") Then
                Corrupted = True
            End If
            If Not dATA.Contains("!ARRAY:PROGRAMMOD") Then
                Corrupted = True
            End If
            If Corrupted Then
                ToolStripStatusLabel1.Text = "Unable to open project, project FIP file is corrupted."
                NewMsgBox.MBox("Unable to open project, project FIP file is corrupted.", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                Dim k As New MainForm
                k.Show()
                Me.Dispose()
            Else
                Try

                    My.Settings.CurrentProjectPath = Target
                    My.Settings.BIN = TrimNewLine(ReadProjString(dATA, "BIN"))
                    My.Settings.CODE = TrimNewLine(ReadProjString(dATA, "CODE"))
                    My.Settings.CODETEMPLATE = TrimNewLine(ReadProjString(dATA, "CODETEMPLATE"))
                    My.Settings.SOURCEEDITOR = TrimNewLine(ReadProjString(dATA, "SOURCEEDITOR"))
                    My.Settings.COMPILER = TrimNewLine(ReadProjString(dATA, "COMPILER"))
                    My.Settings.CurrentProjectName = TrimNewLine(ReadProjString(dATA, "PROJECTNAME"))
                    My.Settings.EXE = TrimNewLine(ReadProjString(dATA, "EXE"))
                    My.Settings.LIBRARY = TrimNewLine(ReadProjString(dATA, "LIBRARY"))
                    My.Settings.PROGRAMLIB = ReadProjStrCol(dATA, "PROGRAMLIB")
                    My.Settings.PROGRAMMOD = ReadProjStrCol(dATA, "PROGRAMMOD")
                    My.Settings.PROGRAMMAIN = ReadProjStrCol(dATA, "PROGRAMMAIN")
                    My.Settings.PROGRAMNAME = ReadProjStrCol(dATA, "PROGRAMNAME")
                    My.Settings.PROGRAMSETTINGS = ReadProjStrCol(dATA, "PROGRAMSETTINGS")
                    My.Settings.SOURCE = TrimNewLine(ReadProjString(dATA, "SOURCE"))
                    My.Settings.Save()
                    If initData Then
                        InitProgram()
                    End If
                    ToolStripStatusLabel1.Text = "Loaded project: " + My.Settings.CurrentProjectName
                    ChangedData = False
                    GoTo 400
                Catch ex As Exception
                    ToolStripStatusLabel1.Text = "Error loading project. Error reading data from FIP file. Name: " + My.Settings.CurrentProjectName
                    NewMsgBox.MBox("Error loading project. Error encountered when reading FIP file. File may be corrupted!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                    Dim k As New MainForm
                    k.Show()
                    Me.Dispose()
                End Try
            End If
        Else
            ToolStripStatusLabel1.Text = "Unable to open project, project FIP file is corrupted."
            NewMsgBox.MBox("Error loading project. Error encountered when reading FIP file. File may be corrupted!!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            Exit Sub
        End If
        Exit Sub
400:    If initData Then
            InitProgram()
        End If
    End Sub
    Private Sub LoadData()
        On Error GoTo 100
        Dim OFD As New OpenFileDialog
        OFD.Filter = "FORTRAN-IT PROJECT|*.fip"
        Dim res As DialogResult = OFD.ShowDialog()
        If res = DialogResult.OK Then
            Dim Inp As New IO.StreamReader(OFD.FileName)
            Dim Data As String = Inp.ReadToEnd()
            Inp.Dispose()
            Dim Corrupted As Boolean = False
            If Strings.Split(Data, "<FORTRAN-IT:SECTION>").GetUpperBound(0) > 0 Then
                If Not Data.Contains("!STR:BIN") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:PROJECTNAME") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:BIN") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:CODE") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:CODETEMPLATE") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:COMPILER") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:EXE") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:LIBRARY") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:SCRIPT") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!STR:SOURCE") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!ARRAY:PROGRAMMAIN") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!ARRAY:PROGRAMNAME") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!ARRAY:PROGRAMSETTINGS") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!ARRAY:PROGRAMLIB") Then
                    Corrupted = True
                End If
                If Not Data.Contains("!ARRAY:PROGRAMMOD") Then
                    Corrupted = True
                End If
                If Corrupted Then
                    ToolStripStatusLabel1.Text = "Unable to open project, project FIP file is corrupted."
                    Exit Sub
                Else
                    My.Settings.CurrentProjectPath = OFD.FileName
                    My.Settings.BIN = TrimNewLine(ReadProjString(Data, "BIN"))
                    My.Settings.CODE = TrimNewLine(ReadProjString(Data, "CODE"))
                    My.Settings.CODETEMPLATE = TrimNewLine(ReadProjString(Data, "CODETEMPLATE"))
                    My.Settings.COMPILER = TrimNewLine(ReadProjString(Data, "COMPILER"))
                    My.Settings.SOURCEEDITOR = TrimNewLine(ReadProjString(Data, "SOURCEEDITOR"))
                    My.Settings.CurrentProjectName = TrimNewLine(ReadProjString(Data, "PROJECTNAME"))
                    My.Settings.EXE = TrimNewLine(ReadProjString(Data, "EXE"))
                    My.Settings.LIBRARY = TrimNewLine(ReadProjString(Data, "LIBRARY"))
                    My.Settings.PROGRAMLIB = ReadProjStrCol(Data, "PROGRAMLIB")
                    My.Settings.PROGRAMMOD = ReadProjStrCol(Data, "PROGRAMMOD")
                    My.Settings.PROGRAMMAIN = ReadProjStrCol(Data, "PROGRAMMAIN")
                    My.Settings.PROGRAMNAME = ReadProjStrCol(Data, "PROGRAMNAME")
                    My.Settings.PROGRAMSETTINGS = ReadProjStrCol(Data, "PROGRAMSETTINGS")
                    My.Settings.SOURCE = TrimNewLine(ReadProjString(Data, "SOURCE"))
                    My.Settings.Save()
                    Me.Text = My.Settings.CurrentProjectName + " - Fortran-It!"
                    ToolStripStatusLabel1.Text = "Loaded project: " + My.Settings.CurrentProjectName
                    ChangedData = False
                    GoTo 200
                End If
            Else
                ToolStripStatusLabel1.Text = "Unable to open project, project FIP file is corrupted."
                NewMsgBox.MBox("Error loading project. Error encountered when opening FIP file.", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                Exit Sub
            End If

        End If
        Exit Sub
100:    NewMsgBox.MBox("Error loading project. Error encountered when opening FIP file.", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        Exit Sub
200:    InitProgram()
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectToolStripMenuItem.Click
        LoadData()
        InitProgram()
        UpdateTree()
        ChangedData = False
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
            SaveProject(False)
            UpdateTree()
            ChangedData = False
        Else
            SaveProject(True)
            UpdateTree()
            ChangedData = False
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If ChangedData Then
            e.Cancel = True
            Dim r As DialogResult = NewMsgBox.MBox("Save before exit?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Information)
            If r = DialogResult.Yes Then
                If My.Settings.CurrentProjectPath = Nothing Then
                    SaveProject(True)
                    UpdateTree()
                    ChangedData = False
                    Me.Close()
                Else
                    If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
                        SaveProject(False)
                        UpdateTree()
                        ChangedData = False
                        Me.Close()
                    Else
                        SaveProject(True)
                        UpdateTree()
                        ChangedData = False

                        Me.Close()

                    End If
                End If
            ElseIf r = DialogResult.No
                ChangedData = False
                Me.Close()
            ElseIf r = DialogResult.Cancel
                Exit Sub
            End If
        Else

            e.Cancel = False
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

    Private Function TrimNewLine(ByVal Txt As String) As String
        On Error Resume Next
        Return System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(Txt, "(" & Environment.NewLine & ")*$", ""), "^(" & Environment.NewLine & ")*", "")
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub



    Private Sub SaveProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProjectToolStripMenuItem.Click
        If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
            SaveProject(False)
            UpdateTree()
            ChangedData = False
        Else
            SaveProject(True)
            UpdateTree()
            ChangedData = False
        End If
    End Sub

    Public Shared ResetCmdLine As Boolean = False


    Private Sub NewFortranSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFortranSourceToolStripMenuItem.Click
        Dim ofd As New SaveFileDialog
        ofd.Filter = "|FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
        ofd.InitialDirectory = My.Settings.SOURCE
        Dim r As DialogResult = ofd.ShowDialog()
        If r = DialogResult.OK Then
            Dim k As New IO.StreamWriter(ofd.FileName)
            k.WriteLine("C     ------------------------------------------------------")
            k.WriteLine("C     THIS FORTRAN SOURCE FILE WAS GENERATED BY FORTRAN-IT.")
            k.WriteLine("C     DATE &TIME: " + My.Computer.Clock.LocalTime.ToString.ToUpper)
            k.WriteLine("C     SOURCE: " + ofd.FileName)
            k.WriteLine("C     ------------------------------------------------------")
            k.WriteLine()
            k.WriteLine()
            k.WriteLine("C     BEGIN YOUR CODE HERE")
            k.WriteLine()
            k.Dispose()
            Try
                If My.Settings.SOURCEEDITOR = "" Then
                    Dim ll As New CodeEditor(ofd.FileName)
                    ll.Show()
                Else
                    Shell(My.Settings.SOURCEEDITOR + " " + ofd.FileName, AppWinStyle.NormalFocus)
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub RoseRedToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        CompileTime += 1.0
        If CompileDone Then
            CompileDone = False
            Timer1.Enabled = False
            ToolStripStatusLabel1.Text = "Build job has finished!"
            TextBox5.AppendText("Build job has finished! Build time: " + CompileTime.ToString + " ms.")
            PictureBox2.Visible = False
            CompileTime = 0.0
            ChangedData = False
            InitProgram()
            UpdateTree()
            'Mark all necessary symbols in the compilation output RichTextBox
        End If
    End Sub



    Private Sub OpenOutputFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenOutputFolderToolStripMenuItem.Click
        Shell("explorer.exe " + My.Settings.EXE, AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub EditScriptToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim k As New Make_Strings
        k.ShowDialog()
    End Sub

    Private Sub BuildProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildProgramToolStripMenuItem.Click
        ExecuteToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub RunProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunProgramToolStripMenuItem.Click
        Try
            Shell("cmd.exe /K " + My.Settings.EXE + "\" + ComboBox1.Text + ".exe", AppWinStyle.NormalFocus, False)
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Run Error: The program is either not compiled or the target executable folder does not exists. Please retry building the program."
            NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.YesNo, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub AboutThisVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutThisVersionToolStripMenuItem.Click
        Dim k As New About
        If IsTopMostMode Then
            k.TopMost = True
        Else
            k.TopMost = False
        End If
        k.ShowDialog()
    End Sub

    Private Sub ManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem.Click
        Try
            Shell("" + My.Application.Info.DirectoryPath + "\man\manual.pdf")
        Catch ex As Exception
            NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DelinkSourceFromProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DelinkSourceFromProgramToolStripMenuItem.Click
        If ListBox1.SelectedItems.Count > 0 Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        Else
            NewMsgBox.MBox("Please specify the code/object to be removed from the list!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub






    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Private Sub MainPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainPageToolStripMenuItem.Click
        ResetCmdLine = True
        If ChangedData Then
            Dim r As DialogResult = NewMsgBox.MBox("Save current existing project?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Information)
            If r = DialogResult.Yes Then
                If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
                    SaveProject(False)
                    UpdateTree()
                Else
                    SaveProject(True)
                    UpdateTree()
                End If
                Dim k As New MainForm
                k.Show()
                Me.Dispose()
            ElseIf r = DialogResult.Cancel
                Exit Sub
            ElseIf r = DialogResult.No
                ChangedData = False
                Dim k As New MainForm
                k.Show()
                Me.Dispose()
            End If
        Else

            Dim k As New MainForm
            k.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub ListBox1_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles ListBox1.MeasureItem
        Dim g As Graphics = e.Graphics
        'We will get the size of the string which we are about to draw, 
        'so that we could set the ItemHeight and ItemWidth property 
        Dim size As SizeF = g.MeasureString(ListBox1.Items.Item(e.Index).ToString, ListBox1.Font,
        ListBox1.Width - 5 - SystemInformation.VerticalScrollBarWidth)
        e.ItemHeight = CInt(size.Height) + 5
        e.ItemWidth = CInt(size.Width) + 5
    End Sub

    Private Sub ListBox2_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles ListBox2.MeasureItem
        Dim g As Graphics = e.Graphics
        'We will get the size of the string which we are about to draw, 
        'so that we could set the ItemHeight and ItemWidth property 
        Dim size As SizeF = g.MeasureString(ListBox2.Items.Item(e.Index).ToString, ListBox2.Font,
        ListBox2.Width - 5 - SystemInformation.VerticalScrollBarWidth)
        e.ItemHeight = CInt(size.Height) + 5
        e.ItemWidth = CInt(size.Width) + 5
    End Sub

    Private Sub EditSourceCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSourceCodeToolStripMenuItem.Click
        If Not OpenedSourceCodes.Contains(ListBox1.SelectedItem) Then
            If My.Settings.SOURCEEDITOR = "" Then
                Dim j As New CodeEditor(ListBox1.SelectedItem.ToString)
                OpenedSourceCodes.Add(ListBox1.SelectedItem.ToString)
                j.Show()
                ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
            Else
                Shell(My.Settings.SOURCEEDITOR + " """ + ListBox1.SelectedItem + """", AppWinStyle.NormalFocus)
            End If
        Else
            Form1.HaveToFocusNow = ListBox1.SelectedItem
            ' NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox1.Text <> Nothing And My.Computer.FileSystem.FileExists(TextBox1.Text) Then
            If Not OpenedSourceCodes.Contains(TextBox1.Text) Then
                If My.Settings.SOURCEEDITOR = "" Then
                    Dim j As New CodeEditor(TextBox1.Text)
                    OpenedSourceCodes.Add(TextBox1.Text)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    Try
                        Shell(My.Settings.SOURCEEDITOR + " " + TextBox1.Text, AppWinStyle.NormalFocus)
                    Catch ex As Exception
                        Shell("explorer.exe" + " """ + TextBox1.Text + """", AppWinStyle.NormalFocus)
                    End Try
                End If
            Else
                HaveToFocusNow = Strings.Replace(Strings.Replace(TextBox1.Text, """", ""), ";", "")
                'NewMsgBox.MBox("Source code has been opened.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        Else
            NewMsgBox.MBox("The specified source code is not found or deleted. Please specify a new main source code.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        End If
    End Sub

    Public Shared BeginCompile As Boolean = False
    Public Shared BeginRun As Boolean = False
    Public Shared CanCompile As Boolean = True
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        '       If isFinishEditCode Then
        '      InitProgram()
        '     UpdateTree()
        '    isFinishEditCode = False
        '  End If

        If Button2.Tag = "Edit" Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
        If TreeView1.Nodes.Count = 0 Then
            Label15.Visible = True
        Else
            Label15.Visible = False
        End If
        If PictureBox2.Visible = True Then
            ExecuteToolStripMenuItem.Enabled = False
            RunToolStripMenuItem.Enabled = False
            Button13.Enabled = False
            Button14.Enabled = False
        Else
            ExecuteToolStripMenuItem.Enabled = True
            RunToolStripMenuItem.Enabled = True
            Button13.Enabled = True
            Button14.Enabled = True
        End If

        If Form1.CompileDone Then
            PictureBox2.Visible = False
        End If
        If ChangedData Then
            Me.Text = "Fortran-It! - " + My.Settings.CurrentProjectName + " (Not Saved)"
        Else
            Me.Text = "Fortran-It! - " + My.Settings.CurrentProjectName
        End If
        If ProgramSourceList.Count = 0 Then
            IsTopMostMode = False
        End If
        If TextBox6.Width < 150 Then
            FileToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Image
            BuildToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Image
            AboutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
            MainPageToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
            SettingsToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
            ExecuteToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
            RunToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
            TextBox6.Location = New Point(MenuStrip2.Location.X + MenuStrip2.Width + 20, TextBox6.Location.Y)
            TextBox6.Size = New Size(TextBox5.Location.X + TextBox5.Width - TextBox6.Location.X, TextBox6.Height)
        ElseIf TextBox6.Width > 600
            FileToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            BuildToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            AboutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            MainPageToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            SettingsToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            ExecuteToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            RunToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            TextBox6.Location = New Point(MenuStrip2.Location.X + MenuStrip2.Width + 20, TextBox6.Location.Y)
            TextBox6.Size = New Size(TextBox5.Location.X + TextBox5.Width - TextBox6.Location.X, TextBox6.Height)
        End If
        If My.Computer.FileSystem.FileExists(My.Settings.BIN + "\" + My.Settings.COMPILER + ".exe") Then
            ToolStripStatusLabel3.Text = "Using compiler " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        Else
            ToolStripStatusLabel3.Text = "Warning! Compiler not found. " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.IndianRed
            BeginCompile = False
            Exit Sub
        End If
        If BeginCompile Then
            BeginCompile = False
            Compile()
        End If

        If BeginRun Then
            BeginRun = False
            Try

                If My.Computer.FileSystem.FileExists(My.Settings.EXE + "\" + ComboBox1.Text + ".exe") Then
                    Dim pr As New ProcessStartInfo("cmd.exe")
                    pr.WorkingDirectory = My.Settings.EXE
                    pr.UseShellExecute = True

                    pr.WindowStyle = ProcessWindowStyle.Normal
                    pr.Arguments = "/K """ + My.Settings.EXE + "\" + ComboBox1.Text + ".exe"""
                    Process.Start(pr)
                    ' Shell("cmd.exe /K """ + My.Settings.EXE + "\" + ComboBox1.Text + ".exe""", AppWinStyle.NormalFocus, False)
                Else
                    ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                    NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                End If
            Catch ex As Exception
                ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub CodeEditorColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FortranEditorColorToolStripMenuItem.Click
        Dim j As New ThemeForm
        If IsTopMostMode Then
            j.TopMost = True
        Else
            j.TopMost = False
        End If
        j.ShowDialog()
    End Sub

    Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        Label2.Text = Me.Text
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        'ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub



    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
        isMouseDown = True
    End Sub

    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
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
    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
        isMouseDown = False
    End Sub
    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        drag = False
    End Sub
    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        TextBox1.Text = Strings.Replace(TextBox1.Text, """", "")
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub StatusStrip1_Paint(sender As Object, e As PaintEventArgs) Handles StatusStrip1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.StatusStrip1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub EditCompilationScriptMakefileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditCompilationScriptMakefileToolStripMenuItem.Click
        Dim k As New Make_Strings
        If IsTopMostMode Then
            k.TopMost = True
        Else
            k.TopMost = False
        End If
        k.ShowDialog()
    End Sub

    Private CompileTime As Double = 0.0
    Private Sub Compile()
        isCompileButtonDisabled = True
        ExecuteToolStripMenuItem.Enabled = False
        PictureBox2.Visible = True         'Showing the colorful loading picture.
        Timer1.Enabled = True              '
        IsBuildingSignal = True
        TextBox5.Clear()
        ToolStripStatusLabel1.Text = "Compiling " + ComboBox1.Text + "..."
        TextBox5.AppendText("Building " + ComboBox1.Text + ". Build job started!" + vbNewLine)
        'Checking if the compiler exists...
        If My.Computer.FileSystem.FileExists(My.Settings.BIN + "\" + My.Settings.COMPILER + ".exe") Then
            ToolStripStatusLabel3.Text = "Using compiler " + My.Settings.COMPILER
            TextBox5.AppendText("Using compiler " + My.Settings.COMPILER + "..." + vbNewLine)
            StatusStrip1.BackColor = Color.FromArgb(48, 113, 173)
        Else
            TextBox5.AppendText("Fatal Error! Compiler not found. Terminating compilation job. Not found - " + My.Settings.COMPILER + vbNewLine)
            ToolStripStatusLabel3.Text = "Warning! Compiler not found. " + My.Settings.COMPILER
            StatusStrip1.BackColor = Color.IndianRed
            isCompileButtonDisabled = False
            PictureBox2.Visible = False         'Showing the colorful loading picture.
            Timer1.Enabled = False              '
            IsBuildingSignal = False
            Exit Sub
        End If

        'Checking if the project parameters are not empty...
        Try
            With My.Settings
                If .SOURCE = "" Or .EXE = "" Or .BIN = "" Or .LIBRARY = "" Then
                    NewMsgBox.MBox("Compile Error: Please set the project parameters before compiling the codes!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                    isCompileButtonDisabled = False
                    PictureBox2.Visible = False         'Showing the colorful loading picture...
                    Timer1.Enabled = False              'Stop the timer that detects compilation complete...
                    IsBuildingSignal = False
                    TextBox5.Clear()
                    ToolStripStatusLabel1.Text = "Compile Error. Please set the project parameters before compiling the codes!"

                    Exit Sub
                Else
                    SaveProject(False)                  'Save the project if all of the project parameters are not empty...
                    UpdateTree()
                End If
            End With

            If Not Environment.GetEnvironmentVariable("PATH").Contains(My.Settings.BIN) Then
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + My.Settings.BIN)
            End If

            If Environment.GetEnvironmentVariables().Contains("LIBRARY_PATH") AndAlso Not Environment.GetEnvironmentVariable("LIBRARY_PATH").Contains(My.Settings.LIBRARY) Then
                Environment.SetEnvironmentVariable("LIBRARY_PATH", My.Settings.LIBRARY)
            End If

            'Try
            Dim MakeFileCode As String = My.Settings.CODE
            MakeFileCode = Strings.Replace(MakeFileCode, """", "")
            MakeFileCode = Strings.Replace(MakeFileCode, """""", """")
            MakeFileCode = Strings.Replace(MakeFileCode, "'", "")
            MakeFileCode = Strings.Replace(MakeFileCode, "''", "'")


            For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
                If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                    MakeFileCode = Strings.Replace(MakeFileCode, "@Settings", Strings.Replace(Strings.Replace(ProgramSettings, ComboBox1.Text + "=", ""), ";", " "))
                    Exit For
                End If
            Next

            MakeFileCode = Strings.Replace(MakeFileCode, "@ProgramName", ComboBox1.Text)
            MakeFileCode = Strings.Replace(MakeFileCode, "@CompilerName", My.Settings.COMPILER)
            MakeFileCode = Strings.Replace(MakeFileCode, "@OutputPath", """" + My.Settings.EXE + """")
            MakeFileCode = Strings.Replace(MakeFileCode, "@LibraryPath", """" + My.Settings.LIBRARY + """")
            MakeFileCode = Strings.Replace(MakeFileCode, "@BinPath", """" + My.Settings.BIN + """")
            MakeFileCode = Strings.Replace(MakeFileCode, "@SourcePath", """" + My.Settings.SOURCE + """")
            MakeFileCode = Strings.Replace(MakeFileCode, "@Path", "%PATH%")



            For Each ProgramLink In My.Settings.PROGRAMLIB
                If ProgramLink.Contains(ComboBox1.Text + "=") Then
                    MakeFileCode = Strings.Replace(MakeFileCode, "@SourceLinks", Strings.Replace(Strings.Replace(ProgramLink, ComboBox1.Text + "=", ""), ";", " "))
                    Exit For
                End If
            Next

            For Each ProgramMod In My.Settings.PROGRAMMOD
                If ProgramMod.Contains(ComboBox1.Text + "=") Then
                    MakeFileCode = Strings.Replace(MakeFileCode, "@Modules", Strings.Replace(Strings.Replace(ProgramMod, ComboBox1.Text + "=", ""), ";", " "))
                    Exit For
                End If
            Next

            For Each ProgramMain In My.Settings.PROGRAMMAIN
                If ProgramMain.Contains(ComboBox1.Text + "=") Then
                    MakeFileCode = Strings.Replace(MakeFileCode, "@MainSource", Strings.Replace(ProgramMain, ComboBox1.Text + "=", ""))
                    Exit For
                End If
            Next

            Try
                If My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + ComboBox1.Text + ".bat") Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.SOURCE + "\" + ComboBox1.Text + ".bat")
                End If
            Catch
            End Try

            Dim BatchPath As String = My.Settings.SOURCE + "\" + ComboBox1.Text + ".bat"
            Dim lo As New IO.StreamWriter(BatchPath, False)
            lo.WriteLine(MakeFileCode)
            lo.Dispose()

            Try
                If My.Computer.FileSystem.FileExists(My.Settings.EXE + "\" + ComboBox1.Text + ".exe") Then
                    My.Computer.FileSystem.DeleteFile(My.Settings.EXE + "\" + ComboBox1.Text + ".exe")
                End If
            Catch
            End Try

            '------------------------------------------------------------------------------------------------------------------
            psi = New ProcessStartInfo(BatchPath)
            Dim systemencoding As System.Text.Encoding = Encoding.ASCII
            System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
            With psi
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
            AddHandler cmd.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler cmd.OutputDataReceived, AddressOf Async_Data_Received
            AddHandler cmd.Exited, AddressOf Async_Exited

            cmd.Start()
            cmd.BeginOutputReadLine()
            cmd.BeginErrorReadLine()

        Catch ex As Exception
            NewMsgBox.MBox("Compile Error! " + ex.Message + vbNewLine + ex.StackTrace, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            isCompileButtonDisabled = False
            PictureBox2.Visible = False         'Showing the colorful loading picture...
            Timer1.Enabled = False              'Stop the timer that detects compilation complete...
            IsBuildingSignal = False
            TextBox5.Clear()
            Exit Sub
        End Try

        Dim FoundExe As Boolean = False
        For Each item As ListViewItem In ListView2.Items
            If item.Text = ComboBox1.Text + ".exe" Then
                FoundExe = True
                Exit For
            End If
        Next

        If Not FoundExe Then
            InitProgram()
            UpdateTree()
        End If


        ChangedData = False 'Saying that all of the data has been saved after compile.
    End Sub
    Private Sub ExecuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.Click
        If Not ComboBox1.Text = "" Then
            Compile()
        Else
            NewMsgBox.MBox("Please select a program from the solution explorer.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click
        Try

            If My.Computer.FileSystem.FileExists(My.Settings.EXE + "\" + ComboBox1.Text + ".exe") Then
                Dim pr As New ProcessStartInfo("cmd.exe")
                pr.WorkingDirectory = My.Settings.EXE
                pr.UseShellExecute = True

                pr.WindowStyle = ProcessWindowStyle.Normal
                pr.Arguments = "/K """ + My.Settings.EXE + "\" + ComboBox1.Text + ".exe"""
                Process.Start(pr)
                ' Shell("cmd.exe /K """ + My.Settings.EXE + "\" + ComboBox1.Text + ".exe""", AppWinStyle.NormalFocus, False)
            Else
                ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
            NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
        Dim Found As Boolean = False
        For Each item As ListViewItem In ListView1.Items
            If item.Text = ComboBox1.Text + ".exe" Then
                Found = True
                Exit For
            End If
        Next

        If Not Found Then
            InitProgram()
            UpdateTree()
        End If
    End Sub

    Private Sub TextBox1_Paint(sender As Object, e As PaintEventArgs)
        ControlPaint.DrawBorder(e.Graphics, Me.TextBox1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub ListBox1_Paint(sender As Object, e As PaintEventArgs) Handles ListBox1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ListBox1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub ListBox2_Paint(sender As Object, e As PaintEventArgs) Handles ListBox2.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ListBox2.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub ProjectParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectParametersToolStripMenuItem.Click
        Dim k As New ProjectParameters
        If IsTopMostMode Then
            k.TopMost = True
        Else
            k.TopMost = False
        End If
        k.ShowDialog()
    End Sub



    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Try

            If (TreeView1.SelectedNode.Text.Contains("(Main)") Or TreeView1.SelectedNode.Text.Contains("(Link)") Or TreeView1.SelectedNode.Text.Contains("(Mod)")) Then
                Dim ResolvePath As String = ""
                If TreeView1.SelectedNode.Text.Contains("(Main)") Then

                    ResolvePath = Strings.Replace(TreeView1.SelectedNode.Text, "(Main)", "")

                    If My.Computer.FileSystem.GetFileInfo(Trim(TextBox1.Text)).Name.Equals(Trim(ResolvePath)) Then
                        ResolvePath = Trim(TextBox1.Text)
                    End If
                ElseIf TreeView1.SelectedNode.Text.Contains("(Link)")
                    ResolvePath = Strings.Replace(TreeView1.SelectedNode.Text, "(Link)", "")
                    For Each item In ListBox1.Items
                        If My.Computer.FileSystem.GetFileInfo(Trim(item)).Name.Equals(Trim(ResolvePath)) Then
                            ResolvePath = Trim(item)
                        End If
                    Next
                ElseIf TreeView1.SelectedNode.Text.Contains("(Mod)") Then
                    ResolvePath = Strings.Replace(TreeView1.SelectedNode.Text, "(Mod)", "")
                    For Each item In ListBox2.Items
                        If My.Computer.FileSystem.GetFileInfo(Trim(item)).Name.Equals(Trim(ResolvePath)) Then
                            ResolvePath = Trim(item)
                        End If
                    Next
                End If



                If Not OpenedSourceCodes.Contains(Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", "")) And Not ResolvePath = "" Then
                    If My.Settings.SOURCEEDITOR = "" Then
                        Dim FInfo As New IO.FileInfo(Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", ""))
                        If FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".f95" Then
                            Dim j As New CodeEditor(Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", ""))
                            OpenedSourceCodes.Add(Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", ""))
                            j.Show()
                        Else

                        End If

                    Else
                        Try
                            Shell(My.Settings.SOURCEEDITOR + " " + Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", ""), AppWinStyle.NormalFocus)
                        Catch ex As Exception
                            Shell("explorer.exe" + " """ + Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", "") + """", AppWinStyle.NormalFocus)
                        End Try
                    End If
                Else

                    HaveToFocusNow = Strings.Replace(Strings.Replace(ResolvePath, """", ""), ";", "")
                    'NewMsgBox.MBox("Source code has been opened.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                End If
            ElseIf ComboBox1.Items.Contains(TreeView1.SelectedNode.Text) Then
                ComboBox1.SelectedItem = TreeView1.SelectedNode.Text
            End If


        Catch ex As Exception
            ' NewMsgBox.MBox(ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Shared HaveToFocusNow As String = ""
    Private Sub RunToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.MouseEnter
        RunToolStripMenuItem.Image = My.Resources.small_rocket_ship_silhouette__1_
    End Sub

    Private Sub RunToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.MouseLeave
        RunToolStripMenuItem.Image = My.Resources.small_rocket_ship_silhouette
    End Sub

    Private Sub ExecuteToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.MouseEnter
        If ExecuteToolStripMenuItem.Enabled = True Then
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button__1_
        Else
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
        End If
    End Sub

    Private Sub ExecuteToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.MouseLeave
        ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not TreeView1.Nodes.Count = 0 Then
            If ComboBox1.Items.Contains(TreeView1.SelectedNode.Text) Then
                ComboBox1.SelectedItem = TreeView1.SelectedNode.Text
                CurrentNodeText = TreeView1.SelectedNode.Text
                CurrentNodeParentText = TreeView1.SelectedNode.Text
                isCompileButtonDisabled = False
            ElseIf ComboBox1.Items.Contains(TreeView1.SelectedNode.Parent.Text)
                ComboBox1.SelectedItem = TreeView1.SelectedNode.Parent.Text
                CurrentNodeText = TreeView1.SelectedNode.Parent.Text
                CurrentNodeParentText = TreeView1.SelectedNode.Parent.Text
                isCompileButtonDisabled = False
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip2.Opening
        If ListBox1.SelectedItems.Count = 0 Then
            EditSourceCodeToolStripMenuItem.Enabled = False
        Else
            EditSourceCodeToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ContextMenuStrip4_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip4.Opening
        If ListBox2.SelectedItems.Count = 0 Then
            ToolStripMenuItem4.Enabled = False
        Else
            ToolStripMenuItem4.Enabled = True
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ExecuteToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click

    End Sub

    Private Sub SettingsToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.MouseEnter
        SettingsToolStripMenuItem.Image = My.Resources.settings_work_tool__1_
    End Sub

    Private Sub SettingsToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.MouseLeave
        SettingsToolStripMenuItem.Image = My.Resources.settings_work_tool
    End Sub

    Private Sub MainPageToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles MainPageToolStripMenuItem.MouseEnter
        MainPageToolStripMenuItem.Image = My.Resources.home__1_
    End Sub

    Private Sub MainPageToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles MainPageToolStripMenuItem.MouseLeave
        MainPageToolStripMenuItem.Image = My.Resources.home
    End Sub

    Private Sub RunToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem1.Click
        Try
            If My.Computer.FileSystem.FileExists(My.Settings.EXE + "\" + ComboBox1.Text + ".exe") Then
                Shell("cmd.exe /K """ + My.Settings.EXE + "\" + ComboBox1.Text + ".exe""", AppWinStyle.NormalFocus, False)
            Else
                ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
            NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ContextMenuStrip3_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip3.Opening

    End Sub



    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub AboutToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.MouseEnter
        AboutToolStripMenuItem.Image = My.Resources.icon__1_
    End Sub

    Private Sub AboutToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.MouseLeave
        AboutToolStripMenuItem.Image = My.Resources.icon
    End Sub

    Private Sub BuildToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuildToolStripMenuItem1.Click

    End Sub

    Private Sub BuildToolStripMenuItem1_MouseEnter(sender As Object, e As EventArgs) Handles BuildToolStripMenuItem1.MouseEnter
        BuildToolStripMenuItem1.Image = My.Resources.hammer__3_
    End Sub

    Private Sub BuildToolStripMenuItem1_MouseLeave(sender As Object, e As EventArgs) Handles BuildToolStripMenuItem1.MouseLeave
        BuildToolStripMenuItem1.Image = My.Resources.hammer__2_
    End Sub

    Private Sub FileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.Click

    End Sub

    Private Sub FileToolStripMenuItem1_MouseEnter(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.MouseEnter
        FileToolStripMenuItem1.Image = My.Resources.folder__6_
    End Sub

    Private Sub FileToolStripMenuItem1_MouseLeave(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.MouseLeave
        FileToolStripMenuItem1.Image = My.Resources.folder__5_
    End Sub



    Private Sub TreeView1_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
        Dim state As TreeNodeStates = e.State
        Dim font As Font = If(e.Node.NodeFont, e.Node.TreeView.Font)
        Dim fore As Color = e.Node.ForeColor
        If fore = Color.Empty Then
            fore = e.Node.TreeView.ForeColor
        End If
        Dim Bnd As New Rectangle(New Point(e.Bounds.Location.X, e.Bounds.Location.Y + 2), New Size(e.Bounds.Size.Width, e.Bounds.Size.Height - 2))
        If e.Node.Equals(e.Node.TreeView.SelectedNode) Then
            fore = Color.White

            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 45, 45)), e.Bounds)
            'ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, Color.FromArgb(48, 113, 173))
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, Bnd, fore, Color.FromArgb(45, 45, 45),
                TextFormatFlags.GlyphOverhangPadding)
        Else
            e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, Bnd, Color.Black, TextFormatFlags.GlyphOverhangPadding)
        End If
    End Sub




    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Dim OutputErrorStyle As Style = New TextStyle(New SolidBrush(Color.IndianRed), Nothing, FontStyle.Italic)
    Dim PathStyle As Style = New TextStyle(New SolidBrush(Color.LightSkyBlue), Nothing, FontStyle.Regular)
    Dim OutputErrorRegex As Regex = New Regex("(Error:|Fatal Error:)", RegexOptions.IgnoreCase)
    Private Sub TextBox5_TextChangedDelayed(sender As Object, e As TextChangedEventArgs) Handles TextBox5.TextChangedDelayed
        Dim FilePattern As String = "("
        Dim i As Integer = 0
        If ListBox1.Items.Count = 0 Then
            FilePattern += TextBox1.Text
        Else
            FilePattern += TextBox1.Text + "|"
        End If
        For Each item In ListBox1.Items
            If Not i = ListBox1.Items.Count - 1 Then
                FilePattern += item.ToString() + "|"
            Else
                FilePattern += item.ToString() + ")"
            End If
            i += 1
        Next
        If ListBox1.Items.Count = 0 Then
            FilePattern += ")"
        End If
        If Not ListBox1.Items.Count = 0 Or Not TextBox1.Text = "" Then
            Dim FileRegex As New Regex(Strings.Replace(FilePattern, "\", "\\"), RegexOptions.IgnoreCase)
            TextBox5.Range.SetStyle(PathStyle, FileRegex)
        End If
        TextBox5.Range.SetStyle(OutputErrorStyle, OutputErrorRegex)

    End Sub


    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        CodeEditor.CodeEditorProgramSelect = ComboBox1.SelectedItem
        For Each Node As TreeNode In TreeView1.Nodes
            If ComboBox1.Text = Node.Text Then
                TreeView1.SelectedNode = Node
            End If
        Next


    End Sub


    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        OpenFileDialog1.InitialDirectory = My.Settings.SOURCE
        Dim DR As DialogResult = OpenFileDialog1.ShowDialog()
        If DR = DialogResult.OK Then
            Dim FName As String = OpenFileDialog1.FileName
            If Not FName = Nothing Then
                If Not FName = TextBox1.Text Then
                    If Not ListBox2.Items.Contains(FName) Then
                        If My.Computer.FileSystem.FileExists(FName) Then
                            ListBox2.Items.Add(FName)
                            If Not TextBox2.Text.Contains("-J@SourcePath") Then
                                Dim G As String = ""
                                For Each line In TextBox2.Lines
                                    If Not Trim(line) = "" Then
                                        G += line + vbNewLine
                                    End If
                                Next
                                TextBox2.Text = G
                                If TextBox2.Lines.Count = 0 Then
                                    TextBox2.AppendText("-J@SourcePath" + vbNewLine)
                                Else
                                    TextBox2.AppendText(vbNewLine + "-J@SourcePath" + vbNewLine)
                                End If
                                TextBox2_Clean()
                            End If
                        End If
                    Else
                        NewMsgBox.MBox("Module is already linked!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    End If
                Else
                    NewMsgBox.MBox("Module source(s) cannot be the same with the main source!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                End If
            Else
                NewMsgBox.MBox("Please specify the code/object to be linked!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End If


    End Sub


    Private Sub Button6_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub


    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        Dim res As DialogResult = NewMsgBox.MBox("Are you sure you want to remove the module from the selected program?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
        If res = DialogResult.Yes Then
            If ListBox2.SelectedItems.Count > 0 Then
                ListBox2.Items.Remove(ListBox2.SelectedItem)
            Else
                NewMsgBox.MBox("Please specify the module to be removed from the list!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Public Shared isFinishEditCode As Boolean = False

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        'This is for intellisense purpose!
        Try
            'Search method names in source files.
            ProgramSourceList.Clear()
            ProgramSourceList.Add(TextBox1.Text)
            For Each item In ListBox1.Items
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim k As New IO.FileInfo(item)
                    If Strings.Replace(k.Extension.ToLower, ".", "") = "f" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "for" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f90" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f95" Then
                        ProgramSourceList.Add(item)
                    End If
                End If
            Next

            For Each item In ListBox2.Items
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim k As New IO.FileInfo(item)
                    If Strings.Replace(k.Extension.ToLower, ".", "") = "f" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "for" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f77" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f90" Or
                                Strings.Replace(k.Extension.ToLower, ".", "") = "f95" Then
                        ProgramSourceList.Add(item)
                    End If
                End If
            Next
            CodeEditor.SharedMethodName.Clear()
            Dim kBox As New FastColoredTextBox()
            For Each item In Form1.ProgramSourceList
                If My.Computer.FileSystem.FileExists(item) Then
                    Dim sr As New IO.StreamReader(item)
                    kBox.Text = sr.ReadToEnd()
                    sr.Dispose()

                    Dim Ranges As New List(Of Range)(kBox.GetRanges("\b(function|subroutine)\b\s+([a-z][a-z0-9_]*)\(([^0-9.'""\n][^0-9.'""\n]*)\)|([a-z][a-z0-9_]*)\(\)", RegexOptions.IgnoreCase))
                    For Each found As Range In Ranges
                        Dim jojo As String = found.Text
                        jojo = Strings.Replace(jojo, "function", "")
                        jojo = Strings.Replace(jojo, "subroutine", "")
                        jojo = Strings.Replace(jojo, "FUNCTION", "")
                        jojo = Strings.Replace(jojo, "SUBROUTINE", "")
                        jojo = Strings.Trim(jojo)
                        Dim RGX As New Regex("^\b(if|elseif|intent|dimension|select|case)\b\s*\(.*$")
                        If Not CodeEditor.SharedMethodName.Contains(jojo) And Not jojo.ToLower = "function" And
                             Not found.Text.ToLower = "subroutine" Then
                            If Not jojo.ToLower = "subroutine" And
                    Not jojo.ToLower.Contains("intent") And
                    Not jojo.ToLower.Contains("dimension") And
                   Not RGX.IsMatch(jojo.ToLower) Then
                                CodeEditor.SharedMethodName.Add(jojo)
                            End If
                        End If
                    Next
                End If
            Next
            kBox.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
            SaveProject(False)
            UpdateTree()
            ChangedData = False
        Else
            SaveProject(True)
            UpdateTree()
            ChangedData = False
        End If
        Dim k As New MainForm
        k.Show()
        Me.Dispose()
    End Sub

    Private Sub Button6_Click_3(sender As Object, e As EventArgs) Handles Button6.Click
        PictureBox2.Visible = True
        If My.Computer.FileSystem.FileExists(My.Settings.CurrentProjectPath) Then
            SaveProject(False)
            UpdateTree()
            ChangedData = False
        Else
            SaveProject(True)
            UpdateTree()
            ChangedData = False
        End If
        My.Computer.Audio.Play(My.Resources.alert, AudioPlayMode.Background)
        PictureBox2.Visible = False
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs)
        Dim k As New ProjectParameters
        If IsTopMostMode Then
            k.TopMost = True
        Else
            k.TopMost = False
        End If
        k.ShowDialog()
    End Sub

    Public Shared isCompileButtonDisabled As Boolean = False
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If ExecuteToolStripMenuItem.Enabled = True Then
            CanCompile = True
        Else
            CanCompile = False
        End If
        If Not CodeEditor.CodeEditorProgramSelect = "" And Not ComboBox1.SelectedItem = CodeEditor.CodeEditorProgramSelect And Not isComboDrop Then
            ComboBox1.SelectedItem = CodeEditor.CodeEditorProgramSelect
            ComboBox1_SelectionChangeCommitted(Me, Nothing)
        End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If ListBox2.SelectedItems.Count > 0 Then

            ListBox2.Items.Remove(ListBox2.SelectedItem)
        Else
            NewMsgBox.MBox("Please specify the module to be removed from the list!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If Not OpenedSourceCodes.Contains(ListBox2.SelectedItem) Then

            If My.Settings.SOURCEEDITOR = "" Then
                OpenedSourceCodes.Add(ListBox2.SelectedItem.ToString)
                Dim j As New CodeEditor(ListBox2.SelectedItem.ToString)
                j.Show()
                ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
            Else
                Try
                    Shell(My.Settings.SOURCEEDITOR + " """ + ListBox2.SelectedItem + """", AppWinStyle.NormalFocus)
                Catch ex As Exception
                    Shell("explorer.exe" + " """ + ListBox2.SelectedItem + """", AppWinStyle.NormalFocus)
                End Try
            End If
        Else
            Form1.HaveToFocusNow = ListBox2.SelectedItem.ToString
            'NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        If Not ComboBox1.Text = "" Then
            Form1.BeginCompile = True
        End If
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        If Not ComboBox1.Text = "" Then
            Form1.BeginRun = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            UpdateTree()
        End If
    End Sub

    Dim tbFindChanged As Boolean = False
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = vbCr Then
            If TextBox6.Text = "" Then
                UpdateTree()
            Else
                ListView1.Items.Clear()
                For Each item In My.Computer.FileSystem.GetFiles(My.Settings.SOURCE)
                    Dim ko As New IO.FileInfo(item)
                    If ko.Name.ToLower.Contains(TextBox6.Text.ToLower) Then
                        Dim SR As New IO.StreamReader(item)
                        Dim Code As String
                        Do While SR.Peek() > -1
                            Code = SR.ReadLine()
                            If Strings.Left(Strings.Trim(Code), 7).ToLower() = "program" Then
                                Dim k1 As New ListViewItem
                                k1.Tag = item
                                k1.Text = ko.Name
                                k1.ImageIndex = 1
                                ListView1.Items.Add(k1)
                                GoTo 2
                            ElseIf Strings.Left(Strings.Trim(Code), 6).ToLower() = "module" Then
                                Dim k1 As New ListViewItem
                                k1.Tag = item
                                k1.Text = ko.Name
                                k1.ImageIndex = 2
                                ListView1.Items.Add(k1)
                                GoTo 2
                            End If
                        Loop
                        If ko.Extension.ToLower = ".dll" Then
                            Dim k As New ListViewItem
                            k.Tag = item
                            k.Text = ko.Name
                            k.ImageIndex = 6
                            ListView1.Items.Add(k)
                        ElseIf ko.Extension.ToLower = ".bat"
                            Dim k As New ListViewItem
                            k.Tag = item
                            k.Text = ko.Name
                            k.ImageIndex = 3
                            ListView1.Items.Add(k)
                        ElseIf ko.Extension.ToLower = ".o"
                            Dim k As New ListViewItem
                            k.Tag = item
                            k.Text = ko.Name
                            k.ImageIndex = 2
                            ListView1.Items.Add(k)
                        ElseIf ko.Extension.ToLower = ".a"
                            Dim k As New ListViewItem
                            k.Tag = item
                            k.Text = ko.Name
                            k.ImageIndex = 9
                            ListView1.Items.Add(k)
                        Else
                            Dim k As New ListViewItem
                            k.Tag = item
                            k.Text = ko.Name
                            k.ImageIndex = 8
                            ListView1.Items.Add(k)
                        End If
2:                      SR.Dispose()
                    End If
                Next
            End If




            Dim r As Range = If(Me.tbFindChanged, Me.TextBox5.Range.Clone(), Me.TextBox5.Selection.Clone())
            Me.tbFindChanged = False
            r.[End] = New Place(Me.TextBox5(Me.TextBox5.LinesCount - 1).Count, Me.TextBox5.LinesCount - 1)
            Dim pattern As String = Regex.Escape(Me.TextBox6.Text)
            Using enumerator As IEnumerator(Of Range) = r.GetRanges(pattern, RegexOptions.IgnoreCase).GetEnumerator()
                If enumerator.MoveNext() Then
                    Dim found As Range = enumerator.Current
                    found.Inverse()
                    Me.TextBox5.Selection = found
                    Me.TextBox5.DoSelectionVisible()
                    Return
                End If
            End Using
            Me.tbFindChanged = True
        Else
            Me.tbFindChanged = True
        End If
    End Sub

    Private Sub TextBox6_LostFocus(sender As Object, e As EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = "  Search script output, code bank"
            TextBox6.Font = New Font("Segoe UI", TextBox6.Font.SizeInPoints, FontStyle.Italic)
            TextBox6.ForeColor = Color.FromArgb(65, 65, 65)
        End If
    End Sub

    Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs) Handles TextBox6.GotFocus

        If TextBox6.Text = "  Search script output, code bank" And TextBox6.Font.Style = FontStyle.Italic Then
            TextBox6.Text = ""
        End If
        TextBox6.SelectAll()
        TextBox6.Font = New Font("Segoe UI", TextBox6.Font.SizeInPoints, FontStyle.Regular)
        TextBox6.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim k As New Feedback(True)
        k.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim k As New Feedback(False)
        k.ShowDialog()


    End Sub

    Private Sub OpenSourceFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSourceFolderToolStripMenuItem.Click
        Shell("explorer.exe " + My.Settings.SOURCE, AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBox5.TextChanged
        OutputText = TextBox5.Text
    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        If ListView2.SelectedItems.Count = 1 Then
            If ListView2.SelectedItems(0).Text.Contains(".exe") Then
                Try

                    If My.Computer.FileSystem.FileExists(My.Settings.EXE + "\" + ListView2.SelectedItems(0).Text) Then
                        Dim pr As New ProcessStartInfo("cmd.exe")
                        pr.WorkingDirectory = My.Settings.EXE
                        pr.UseShellExecute = True

                        pr.WindowStyle = ProcessWindowStyle.Normal
                        pr.Arguments = "/K """ + My.Settings.EXE + "\" + ListView2.SelectedItems(0).Text
                        Process.Start(pr)
                    Else
                        ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                        NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                    End If
                Catch ex As Exception
                    ToolStripStatusLabel1.Text = "Run Error: The program is either not built or there were build errors! Please retry building the program."
                    NewMsgBox.MBox(ToolStripStatusLabel1.Text, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                End Try
            Else
                Shell("explorer.exe" + " """ + My.Settings.EXE + "\" + ListView2.SelectedItems(0).Text + """", AppWinStyle.NormalFocus)
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If Not OpenedSourceCodes.Contains(ListView1.SelectedItems(0).Tag) Then

            If My.Settings.SOURCEEDITOR = "" Then
                Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(0).Tag)
                If FInfo.Extension.ToLower = ".a" Or FInfo.Extension.ToLower = ".dll" Or FInfo.Extension.ToLower = ".o" Then
                    Exit Sub
                End If
                Dim j As New CodeEditor(ListView1.SelectedItems(0).Tag)
                j.Show()
                OpenedSourceCodes.Add(ListView1.SelectedItems(0).Tag)
                ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
            Else
                Try
                    Shell(My.Settings.SOURCEEDITOR + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                Catch ex As Exception
                    Shell("explorer.exe" + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                End Try
            End If
        Else
            Form1.HaveToFocusNow = ListView1.SelectedItems(0).Tag
            'NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ContextMenuStrip5_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip5.Opening
        For Each item As ToolStripItem In ContextMenuStrip5.Items
            item.Enabled = False
        Next

        For Each item As ToolStripItem In ContextMenuStrip5.Items
            If item.Text = "Add as a module" And Button2.Tag = "Save" And ListView1.SelectedItems.Count = 1 AndAlso ListView1.SelectedItems(0).ImageIndex = 2 Then
                item.Enabled = True
            End If
            If item.Text = "Open" And ListView1.SelectedItems.Count = 1 Then
                item.Enabled = True
            End If
            If item.Text = "Properties" And ListView1.SelectedItems.Count = 1 Then
                item.Enabled = True
            End If
            If item.Text = "Delete Permanently" And ListView1.SelectedItems.Count >= 1 Then
                item.Enabled = True
            End If
            If item.Text = "Rename" And ListView1.SelectedItems.Count = 1 Then
                item.Enabled = True
            End If
            If item.Text = "Add as a linked source" And Button2.Tag = "Save" And ListView1.SelectedItems.Count = 1 AndAlso (ListView1.SelectedItems(0).ImageIndex = 9 Or ListView1.SelectedItems(0).ImageIndex = 6 Or ListView1.SelectedItems(0).ImageIndex = 1 Or ListView1.SelectedItems(0).ImageIndex = 8) Then
                item.Enabled = True
            End If
            If item.Text = "Show in explorer" And ListView1.SelectedItems.Count = 1 Then
                item.Enabled = True
            End If
        Next



    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If ListView1.SelectedItems.Count >= 1 Then
            Dim DName As String = ""
            Dim res As DialogResult = NewMsgBox.MBox("Are you sure you want to permanently delete this file from the disk?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
            If res = DialogResult.Yes Then
                For j = 0 To ListView1.SelectedItems.Count - 1
                    Try

                        My.Computer.FileSystem.DeleteFile(ListView1.SelectedItems(j).Tag)
                        For i = 0 To My.Settings.PROGRAMMAIN.Count - 1
                            Dim item As String = My.Settings.PROGRAMMAIN.Item(i)
                            item = Strings.Replace(item, ListView1.SelectedItems(j).Tag, "")
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMMAIN.Item(i) = item
                            My.Settings.Save()
                        Next

                        For i = 0 To My.Settings.PROGRAMLIB.Count - 1
                            Dim item As String = My.Settings.PROGRAMLIB.Item(i)
                            item = Strings.Replace(item, ListView1.SelectedItems(j).Tag, "")
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMLIB.Item(i) = item
                            My.Settings.Save()
                        Next

                        For i = 0 To My.Settings.PROGRAMMOD.Count - 1
                            Dim item As String = My.Settings.PROGRAMMOD.Item(i)
                            item = Strings.Replace(item, ListView1.SelectedItems(j).Tag, "")
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMMOD.Item(i) = item
                            My.Settings.Save()
                        Next

                    Catch ex As Exception
                        NewMsgBox.MBox("Error: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    End Try
                Next
                InitProgram()
                UpdateTree()
                SaveProject(False)
            End If

        End If

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        ListView2_DoubleClick(Me, Nothing)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If ListView2.SelectedItems.Count >= 1 Then
            Dim res As DialogResult = NewMsgBox.MBox("Are you sure you want to delete the program binary?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
            If res = DialogResult.Yes Then
                For i = 0 To ListView2.SelectedItems.Count - 1
                    Try
                        My.Computer.FileSystem.DeleteFile(ListView2.SelectedItems(i).Tag)
                    Catch ex As Exception
                        NewMsgBox.MBox("Error: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
                    End Try
                Next
            End If
        End If
        SaveProject(False)
        InitProgram()
        UpdateTree()

    End Sub

    Private Sub ShowInExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowInExplorerToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            Try
                Shell("explorer.exe /select, """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus, False)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ShowInExplorerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowInExplorerToolStripMenuItem1.Click
        If ListView2.SelectedItems.Count = 1 Then
            Try
                Shell("explorer.exe /select, """ + ListView2.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus, False)
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private OldName As String = ""
    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            If Not OpenedSourceCodes.Contains(ListView1.SelectedItems(0).Tag) Then
                OldName = ListView1.SelectedItems(0).Text
                Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(0).Tag)
                ListView1.SelectedItems(0).Text = FInfo.Name
                ListView1.LabelEdit = True
                ListView1.SelectedItems(0).BeginEdit()

            Else
                NewMsgBox.MBox("Cannot rename the file while it is opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        ElseIf ListView1.SelectedItems.Count > 1
            NewMsgBox.MBox("Could not rename multiple files!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles ListView1.SizeChanged

    End Sub
    Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        ' Determines if the name is Nothing.


        If name = "" Then
            Return False
        End If


        ' Determines if there are bad characters in the name.
        For Each badChar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
            If InStr(name, ";") > 0 Then
                Return False
            End If
            If InStr(name, ":") > 0 Then
                Return False
            End If
            If InStr(name, "'") > 0 Then
                Return False
            End If
            If InStr(name, """") > 0 Then
                Return False
            End If
            If InStr(name, ",") > 0 Then
                Return False
            End If
            If InStr(name, "?") > 0 Then
                Return False
            End If
            If InStr(name, ">") > 0 Then
                Return False
            End If
            If InStr(name, "<") > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function
    Private Sub ListView1_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        Dim textt As String = ComboBox1.SelectedItem
        If IsValidFileNameOrPath(e.Label) = False Then
            e.CancelEdit = True
            UpdateTree()
            ComboBox1.SelectedItem = Nothing
            ComboBox1.SelectedItem = textt
            Exit Sub
        End If

        If My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + e.Label) Then
            NewMsgBox.MBox("File is already exists!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            e.CancelEdit = True
            UpdateTree()
            ComboBox1.SelectedItem = Nothing
            ComboBox1.SelectedItem = textt
            Exit Sub
        End If
        If ListView1.SelectedItems.Count = 1 Then
            If Not e.Label = OldName Then
                Dim OldFInfo As New IO.FileInfo(ListView1.SelectedItems(0).Tag)
                Dim i As Integer = Strings.Split(e.Label, ".").GetUpperBound(0)
                Dim ext As String = "." + Strings.Split(e.Label.ToLower, ".")(i)
                If OldFInfo.Extension.ToLower = ext And e.Label.Contains(".") Then
                    ListView1.SelectedItems(0).Tag = Strings.Replace(ListView1.SelectedItems(0).Tag, OldName, e.Label)
                    Try
                        My.Computer.FileSystem.RenameFile(OldFInfo.FullName, e.Label)

                        For i = 0 To My.Settings.PROGRAMMAIN.Count - 1
                            Dim item As String = My.Settings.PROGRAMMAIN.Item(i)
                            item = Strings.Replace(item, OldFInfo.FullName, ListView1.SelectedItems(0).Tag)
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMMAIN.Item(i) = item

                        Next

                        For i = 0 To My.Settings.PROGRAMLIB.Count - 1
                            Dim item As String = My.Settings.PROGRAMLIB.Item(i)
                            item = Strings.Replace(item, OldFInfo.FullName, ListView1.SelectedItems(0).Tag)
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMLIB.Item(i) = item

                        Next

                        For i = 0 To My.Settings.PROGRAMMOD.Count - 1
                            Dim item As String = My.Settings.PROGRAMMOD.Item(i)

                            item = Strings.Replace(item, OldFInfo.FullName, ListView1.SelectedItems(0).Tag)
                            item = Strings.Replace(item, """", "")
                            item = Strings.Replace(item, ";;", ";")
                            My.Settings.PROGRAMMOD.Item(i) = item

                        Next
                        My.Settings.Save()

                    Catch ex As Exception

                    End Try
                ElseIf Not e.Label.Contains(".")
                    ListView1.SelectedItems(0).Tag = Strings.Replace(ListView1.SelectedItems(0).Tag, OldName, e.Label + OldFInfo.Extension)
                    Try
                        My.Computer.FileSystem.RenameFile(OldFInfo.FullName, e.Label + OldFInfo.Extension)

                    Catch ex As Exception

                    End Try

                Else
                    NewMsgBox.MBox("File extension mismatch!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    e.CancelEdit = True
                End If
            End If
        End If
        SaveProject(False)
        ListView1.LabelEdit = False
        UpdateTree()
        ComboBox1.SelectedItem = Nothing
        ComboBox1.SelectedItem = textt

    End Sub

    Private Sub ListView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles ListView1.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(sender.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In sender.SelectedItems
            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i = i + 1
        Next
        ' Create a DataObject containg the array of ListViewItems.
        sender.DoDragDrop(New _
        DataObject("System.Windows.Forms.ListViewItem()", myItems),
        DragDropEffects.Move)

        ListView1.DoDragDrop(ListView1.SelectedItems, DragDropEffects.Move)
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) And Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            Dim MyFiles() As String
            Dim i As Integer

            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                Dim FInfo As New IO.FileInfo(MyFiles(i))
                If FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".o" Then
                    If Not ListBox1.Items.Contains(MyFiles(i)) Then
                        ListBox1.Items.Add(MyFiles(i))
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ListBox2_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListBox2_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) And Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            Dim MyFiles() As String
            Dim i As Integer

            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                Dim FInfo As New IO.FileInfo(MyFiles(i))
                If FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".o" Then
                    If Not ListBox2.Items.Contains(MyFiles(i)) Then
                        ListBox2.Items.Add(MyFiles(i))
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer

            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                Dim FInfo As New IO.FileInfo(MyFiles(i))
                If FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".o" Or FInfo.Extension.ToLower = ".f95" Or FInfo.Extension.ToLower = ".dll" Or FInfo.Extension.ToLower = ".a" Then
                    Try
                        If Not My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + FInfo.Name) Then
                            My.Computer.FileSystem.CopyFile(MyFiles(i), My.Settings.SOURCE + "\" + FInfo.Name)
                            ' InitProgram()
                            UpdateTree()

                        Else
                            Dim T As String = ""
                            Dim res As DialogResult = NewMsgBox.MBox(FInfo.Name + " is already exists in the source bank. Overwrite the file?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                            If res = DialogResult.Yes Then
                                My.Computer.FileSystem.CopyFile(MyFiles(i), My.Settings.SOURCE + "\" + FInfo.Name, True)
                                UpdateTree()

                            End If
                        End If
                    Catch ex As Exception
                        'NewMsgBox.MBox(ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                    End Try
                End If
            Next
        End If


    End Sub

    Private Sub ListView1_DragLeave(sender As Object, e As EventArgs) Handles ListView1.DragLeave

    End Sub

    Dim isMouseDown As Boolean = False

    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles Panel1.MouseEnter
        If isMouseDown Then
            Me.BringToFront()
        End If
    End Sub

    Private Sub AddAsALinkedSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAsALinkedSourceToolStripMenuItem.Click
        If Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            Dim i As Integer
            ' Loop through the array and add the files to the list.
            For i = 0 To ListView1.SelectedItems.Count - 1
                Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(i).Tag)
                If FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".o" Or FInfo.Extension.ToLower = ".f95" Or FInfo.Extension.ToLower = ".dll" Or FInfo.Extension.ToLower = ".a" Then
                    If Not ListBox1.Items.Contains(ListView1.SelectedItems(i).Tag) And Not ListView1.SelectedItems(i).Tag = TextBox1.Text Then
                        If ListView1.SelectedItems(i).ImageIndex = 2 Then
                            NewMsgBox.MBox(FInfo.Name + " is a module file! It cannot be made as a linked source.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                        Else
                            If FInfo.Extension.ToLower = ".dll" Then
                                ListBox1.Items.Add(ListView1.SelectedItems(i).Tag)
                                If Not TextBox2.Text.Contains("-L@SourcePath") Then
                                    Dim G As String = ""
                                    For Each line In TextBox2.Lines
                                        If Not Trim(line) = "" Then
                                            G += line + vbNewLine
                                        End If
                                    Next
                                    TextBox2.Text = G
                                    If TextBox2.Lines.Count = 0 Then
                                        TextBox2.AppendText("-L@SourcePath" + vbNewLine)
                                    Else
                                        TextBox2.AppendText(vbNewLine + "-L@SourcePath" + vbNewLine)
                                    End If
                                    TextBox2_Clean()
                                End If
                            Else
                                ListBox1.Items.Add(ListView1.SelectedItems(i).Tag)
                            End If
                        End If
                    End If
                Else
                    NewMsgBox.MBox(FInfo.Name + " is not a Fortran source file!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                End If
            Next
        End If
    End Sub

    Private Sub AddAsAModuleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAsAModuleToolStripMenuItem.Click
        If Not ComboBox1.Text = "" And Button2.Tag = "Save" Then
            Dim i As Integer
            ' Loop through the array and add the files to the list.
            For i = 0 To ListView1.SelectedItems.Count - 1
                Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(i).Tag)
                If FInfo.Extension.ToLower = ".f" Or FInfo.Extension.ToLower = ".for" Or FInfo.Extension.ToLower = ".f90" Or FInfo.Extension.ToLower = ".o" Then
                    If Not ListBox1.Items.Contains(ListView1.SelectedItems(i).Tag) And Not ListView1.SelectedItems(i).Tag = TextBox1.Text Then
                        If ListView1.SelectedItems(i).ImageIndex = 2 Then
                            If My.Computer.FileSystem.FileExists(ListView1.SelectedItems(i).Tag) Then
                                ListBox2.Items.Add(ListView1.SelectedItems(i).Tag)
                                If Not TextBox2.Text.Contains("-J@SourcePath") Then
                                    Dim G As String = ""
                                    For Each line In TextBox2.Lines
                                        If Not Trim(line) = "" Then
                                            G += line + vbNewLine
                                        End If
                                    Next
                                    TextBox2.Text = G
                                    If TextBox2.Lines.Count = 0 Then
                                        TextBox2.AppendText("-J@SourcePath" + vbNewLine)
                                    Else
                                        TextBox2.AppendText(vbNewLine + "-J@SourcePath" + vbNewLine)
                                    End If
                                    TextBox2_Clean()
                                End If
                            End If
                        End If
                    Else
                        NewMsgBox.MBox(FInfo.Name + " is not a module file!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                    End If
                Else
                    NewMsgBox.MBox(FInfo.Name + " is not a Fortran source file!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
                End If
            Next
        End If
    End Sub

    Private Sub AddANewSourceToBankToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ContextMenuStrip7.Show(Button16, New Point(0, Button16.Height + 1))
    End Sub

    Private Sub AddANewLinkedSourceToBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddANewLinkedSourceToBankToolStripMenuItem.Click
        Dim ofd As New SaveFileDialog
        ofd.Filter = "FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
        ofd.InitialDirectory = My.Settings.SOURCE
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
            k.WriteLine("!" + AddBlank(0, 5) + "Begin your code here:")
            k.WriteLine(AddBlank(0, 6))
            k.Write(AddBlank(0, 6))
            k.Dispose()

            Dim FInfo As New IO.FileInfo(ofd.FileName)
            If Not FInfo.DirectoryName = My.Settings.SOURCE Then
                Dim res As DialogResult = NewMsgBox.MBox("The new source was not saved in the project's source folder. Do you want to copy it into the project's source folder?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                If res = DialogResult.Yes Then
                    My.Computer.FileSystem.CopyFile(FInfo.FullName, My.Settings.SOURCE + FInfo.Name)
                End If
            End If
            SaveProject(False)
            UpdateTree()
            Try
                If Trim(My.Settings.SOURCEEDITOR) = "" Then
                    Dim j As New CodeEditor(ofd.FileName)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    ' Shell(My.Settings.SOURCEEDITOR + " " + ofd.FileName, AppWinStyle.NormalFocus)
                End If
            Catch ex As Exception
                NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Function AddBlank(ByVal vTab As Integer, Optional ByVal offSet As Integer = 0) As String
        AddBlank = ""
        For i = 1 To vTab * My.Settings.Indent + offSet
            AddBlank += " "
        Next
    End Function
    Private Sub AddANewSourceToBankToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddANewSourceToBankToolStripMenuItem.Click
        Dim ofd As New SaveFileDialog
        ofd.Filter = "FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
        ofd.InitialDirectory = My.Settings.SOURCE
        Dim r As DialogResult = ofd.ShowDialog()
        If r = DialogResult.OK Then
            Dim k As New IO.StreamWriter(ofd.FileName)
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine("!" + AddBlank(0, 5) + "THIS FORTRAN MODULE FILE WAS GENERATED USING FORTRAN-IT.")
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine("!" + AddBlank(0, 5) + "Generation time: " + My.Computer.Clock.LocalTime.ToString.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Author         : " + My.User.Name.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Device Name    : " + My.Computer.Name.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Project Name   : " + My.Settings.CurrentProjectName)
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine("!" + AddBlank(0, 5) + "Begin your code here:")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "module " + Strings.Replace(My.Computer.FileSystem.GetFileInfo(ofd.FileName).Name, My.Computer.FileSystem.GetFileInfo(ofd.FileName).Extension, ""))
            k.WriteLine("!" + AddBlank(0, 5) + "Declare your module variables here.")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "contains")
            k.WriteLine("!" + AddBlank(0, 5) + "Declare your methods here.")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "end module")
            k.Dispose()

            Dim FInfo As New IO.FileInfo(ofd.FileName)
            If Not FInfo.DirectoryName = My.Settings.SOURCE Then
                Dim res As DialogResult = NewMsgBox.MBox("The new module was not saved in the project's source folder. Do you want to copy it into the project's source folder?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                If res = DialogResult.Yes Then
                    My.Computer.FileSystem.CopyFile(FInfo.FullName, My.Settings.SOURCE + FInfo.Name)
                End If
            End If

            SaveProject(False)
            UpdateTree()
            Try

                If Trim(My.Settings.SOURCEEDITOR) = "" Then

                    Dim j As New CodeEditor(ofd.FileName)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    ' Shell(My.Settings.SOURCEEDITOR + " " + ofd.FileName, AppWinStyle.NormalFocus)
                End If

            Catch ex As Exception
                NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub AddAnExistingSourceToBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAnExistingSourceToBankToolStripMenuItem.Click
        Dim k As New OpenFileDialog
        k.Title = "Add a new source code"
        k.Filter = "Fortran Source|*.f|Fortran 90|*.f90|Fortran (Old)|*.for|Object File|*.o"
        k.InitialDirectory = My.Settings.SOURCE
        Dim res As DialogResult = k.ShowDialog()
        If res = DialogResult.OK Then
            Dim FInfo As New IO.FileInfo(k.FileName)
            If My.Computer.FileSystem.FileExists(My.Settings.SOURCE + "\" + FInfo.Name) Then
                Dim j As DialogResult = NewMsgBox.MBox("The specified source code is already exist. Do you want to overwrite?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
                If j = DialogResult.Yes Then
                    Try
                        My.Computer.FileSystem.CopyFile(k.FileName, My.Settings.SOURCE + "\" + FInfo.Name, True)
                    Catch ex As Exception
                        ToolStripStatusLabel1.Text = "Error: " + ex.Message
                    End Try
                End If
            Else
                Try
                    My.Computer.FileSystem.CopyFile(k.FileName, My.Settings.SOURCE + "\" + FInfo.Name, True)
                Catch ex As Exception
                    ToolStripStatusLabel1.Text = "Error: " + ex.Message
                End Try
            End If
            InitProgram()
            UpdateTree()
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Button2_Click(Me, Nothing)
        Button17.Image = Button2.Image
    End Sub




    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_VisibleChanged(sender As Object, e As EventArgs) Handles PictureBox2.VisibleChanged
        If Me.Visible Then
            isCompileButtonDisabled = True
        Else
            isCompileButtonDisabled = False
        End If
    End Sub

    Private Sub ExecuteToolStripMenuItem_EnabledChanged(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.EnabledChanged
        If ExecuteToolStripMenuItem.Enabled = True And Not ComboBox1.Text = "" And Not ExecuteToolStripMenuItem.Selected Then
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
        ElseIf ExecuteToolStripMenuItem.Enabled = True And Not ComboBox1.Text = "" And ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button__1_
        ElseIf ExecuteToolStripMenuItem.Enabled = True And ComboBox1.Text = "" And ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button__1_
        ElseIf ExecuteToolStripMenuItem.Enabled = True And ComboBox1.Text = "" And Not ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
        ElseIf ExecuteToolStripMenuItem.Enabled = False And Not ComboBox1.Text = "" And Not ExecuteToolStripMenuItem.Selected Then
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
        ElseIf ExecuteToolStripMenuItem.Enabled = False And Not ComboBox1.Text = "" And ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button__1_
        ElseIf ExecuteToolStripMenuItem.Enabled = False And ComboBox1.Text = "" And ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button__1_
        ElseIf ExecuteToolStripMenuItem.Enabled = False And ComboBox1.Text = "" And Not ExecuteToolStripMenuItem.Selected
            ExecuteToolStripMenuItem.Image = My.Resources.play_rounded_button
        End If
    End Sub

    Private Sub DeleteAllPermanentlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllPermanentlyToolStripMenuItem.Click
        If ListView2.SelectedItems.Count >= 1 Then
            Dim res As DialogResult = NewMsgBox.MBox("Are you sure you want to delete all of the program binaries?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
            If res = DialogResult.Yes Then
                For i = 0 To ListView2.Items.Count - 1
                    Try
                        My.Computer.FileSystem.DeleteFile(ListView2.Items(i).Tag)
                    Catch ex As Exception
                        NewMsgBox.MBox("Error: " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
                    End Try
                Next
            End If
        End If
        SaveProject(False)
        InitProgram()
        UpdateTree()
    End Sub

    Private Sub ExecuteToolStripMenuItem_DragDrop(sender As Object, e As DragEventArgs) Handles ExecuteToolStripMenuItem.DragDrop

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ToolStripMenuItem6.Enabled Then
                ToolStripMenuItem6_Click(Me, Nothing)
            End If
        End If
    End Sub


    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        On Error GoTo 199
        Dim NewProgramName As String = NewProjectName.IBox("New Program Name")
        Dim CurrentProgramName As String = ComboBox1.Text
        If ComboBox1.Items.Contains(NewProgramName) Then
            NewMsgBox.MBox("The specified program name is already exist.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not NewProgramName = "" And System.Text.RegularExpressions.Regex.IsMatch(NewProgramName, "^[a-zA-Z][a-zA-Z_\d]*$") Then
            Dim NewComboboxList As New List(Of String)()
            For Each item In ComboBox1.Items
                If Not item = CurrentProgramName Then
                    NewComboboxList.Add(item)
                Else
                    NewComboboxList.Add(NewProgramName)
                End If
            Next
            ComboBox1.Items.Clear()
            For Each item In NewComboboxList
                ComboBox1.Items.Add(item)
            Next
            ComboBox1.SelectedItem = NewProgramName
            NewComboboxList.Clear()


            Dim CheckList As Boolean = False

            Dim i As Integer = 0
            For i = 0 To My.Settings.PROGRAMMAIN.Count - 1
                If My.Settings.PROGRAMMAIN.Item(i).Contains(CurrentProgramName + "=") Then
                    My.Settings.PROGRAMMAIN.Item(i) = Strings.Replace(My.Settings.PROGRAMMAIN(i), CurrentProgramName + "=", NewProgramName + "=")
                    CheckList = True
                    Exit For
                End If
                i += 1
            Next
            If CheckList = False Then GoTo 199
            CheckList = False

            i = 0
            For i = 0 To My.Settings.PROGRAMLIB.Count - 1
                If My.Settings.PROGRAMLIB.Item(i).Contains(CurrentProgramName + "=") Then
                    My.Settings.PROGRAMLIB.Item(i) = Strings.Replace(My.Settings.PROGRAMLIB(i), CurrentProgramName + "=", NewProgramName + "=")
                    CheckList = True
                    Exit For
                End If
                i += 1
            Next
            If CheckList = False Then GoTo 199
            CheckList = False

            i = 0
            For i = 0 To My.Settings.PROGRAMMOD.Count - 1
                If My.Settings.PROGRAMMOD.Item(i).Contains(CurrentProgramName + "=") Then
                    My.Settings.PROGRAMMOD.Item(i) = Strings.Replace(My.Settings.PROGRAMMOD(i), CurrentProgramName + "=", NewProgramName + "=")
                    CheckList = True
                    Exit For
                End If
                i += 1
            Next
            If CheckList = False Then GoTo 199
            CheckList = False

            i = 0
            For i = 0 To My.Settings.PROGRAMSETTINGS.Count - 1
                If My.Settings.PROGRAMSETTINGS.Item(i).Contains(CurrentProgramName + "=") Then
                    My.Settings.PROGRAMSETTINGS.Item(i) = Strings.Replace(My.Settings.PROGRAMSETTINGS(i), CurrentProgramName + "=", NewProgramName + "=")
                    CheckList = True
                    Exit For
                End If
                i += 1
            Next
            If CheckList = False Then GoTo 199
            CheckList = False

            My.Settings.PROGRAMNAME.Remove(CurrentProgramName)
            My.Settings.PROGRAMNAME.Add(NewProgramName)
            My.Settings.Save()
            UpdateTree()
            ComboBox1.SelectedItem = NewProgramName
            ComboBox1_SelectionChangeCommitted(Me, Nothing)
            ComboBox1_SelectedIndexChanged(Me, Nothing)
            Exit Sub
        Else
            If NewProgramName = "" Then
                NewMsgBox.MBox("Invalid program name input! 'Program Name' field cannot be empty!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z]+$") = False
                NewMsgBox.MBox("Invalid program name input! 'Program Name' field should contains only alphabets [A-Z]!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
            Exit Sub
        End If
199:    LoadDataNoDialog(My.Settings.CurrentProjectPath)
        Button2.Tag = "Edit"
        Button2.BackgroundImage = My.Resources.edit
        ChangedData = False
        NewMsgBox.MBox("An error has occured while renaming the program name.", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim DialogRes As DialogResult = NewMsgBox.MBox("Do you really want to remove the program from this project?", MsgBoxStyle.YesNoCancel, MsgBoxStyle.Exclamation)
        If DialogRes = DialogResult.Yes Then
            For Each ProgramName In My.Settings.PROGRAMNAME
                If ProgramName.Contains(ComboBox1.Text) Then
                    My.Settings.PROGRAMNAME.Remove(ProgramName)
                    Exit For
                End If
            Next

            For Each ProgramLib In My.Settings.PROGRAMLIB
                If ProgramLib.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMLIB.Remove(ProgramLib)
                    Exit For
                End If
            Next

            For Each ProgramMod In My.Settings.PROGRAMMOD
                If ProgramMod.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMOD.Remove(ProgramMod)
                    Exit For
                End If
            Next

            For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
                If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMSETTINGS.Remove(ProgramSettings)
                    Exit For
                End If
            Next

            For Each ProgramMain In My.Settings.PROGRAMMAIN
                If ProgramMain.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMAIN.Remove(ProgramMain)
                    Exit For
                End If
            Next

            My.Settings.Save()

            ChangedData = True
            Button3_Click(Me, Nothing)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim res As DialogResult = NewMsgBox.MBox("Are you sure you want to de-link the source code from the selected program?", MsgBoxStyle.YesNo, MsgBoxStyle.Information)
        If res = DialogResult.Yes Then
            If ListBox1.SelectedItems.Count > 0 Then
                ListBox1.Items.Remove(ListBox1.SelectedItem)
            Else
                NewMsgBox.MBox("Please specify the source to be removed from the list!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Dim ofd As New SaveFileDialog
        ofd.Filter = "FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
        ofd.InitialDirectory = My.Settings.SOURCE
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
            k.WriteLine("!" + AddBlank(0, 5) + "Begin your code here:")
            k.WriteLine(AddBlank(0, 6))
            k.Write(AddBlank(0, 6))
            k.Dispose()
            ListBox1.Items.Add(ofd.FileName)
            Dim Temp As String = ""
            For Each ProgramLib In My.Settings.PROGRAMLIB
                If ProgramLib.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMLIB.Remove(ProgramLib)

                    For Each item As String In ListBox1.Items
                        Temp += item + ";"
                    Next
                    My.Settings.PROGRAMLIB.Add(ComboBox1.Text + "=" + Temp)
                    Exit For
                End If
            Next

            Dim Temp2 As String = ""
            For Each ProgramMod In My.Settings.PROGRAMMOD
                If ProgramMod.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMOD.Remove(ProgramMod)

                    For Each item As String In ListBox2.Items
                        Temp2 += item + ";"
                    Next
                    My.Settings.PROGRAMMOD.Add(ComboBox1.Text + "=" + Temp2)
                    Exit For
                End If
            Next

            For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
                If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMSETTINGS.Remove(ProgramSettings)
                    My.Settings.PROGRAMSETTINGS.Add(ComboBox1.Text + "=" + Strings.Replace(TextBox2.Text, vbNewLine, ";"))

                    Exit For
                End If
            Next

            For Each ProgramMain In My.Settings.PROGRAMMAIN
                If ProgramMain.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMAIN.Remove(ProgramMain)
                    My.Settings.PROGRAMMAIN.Add(ComboBox1.Text + "=" + TextBox1.Text)

                    Exit For
                End If
            Next
            SaveProject(False)
            UpdateTree()
            Try

                If Trim(My.Settings.SOURCEEDITOR) = "" Then

                    Dim j As New CodeEditor(ofd.FileName)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    ' Shell(My.Settings.SOURCEEDITOR + " " + ofd.FileName, AppWinStyle.NormalFocus)
                End If

            Catch ex As Exception
                NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles LinkLabel2.Click
        Dim ofd As New SaveFileDialog
        ofd.Filter = "FORTRAN (FOR)|*.for|FORTRAN 90|*.f90|FORTRAN (MODERN)|*.f"
        ofd.InitialDirectory = My.Settings.SOURCE
        Dim r As DialogResult = ofd.ShowDialog()
        If r = DialogResult.OK Then
            Dim k As New IO.StreamWriter(ofd.FileName)
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine("!" + AddBlank(0, 5) + "THIS FORTRAN MODULE FILE WAS GENERATED USING FORTRAN-IT.")
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine("!" + AddBlank(0, 5) + "Generation time: " + My.Computer.Clock.LocalTime.ToString.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Author         : " + My.User.Name.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Device Name    : " + My.Computer.Name.ToUpper)
            k.WriteLine("!" + AddBlank(0, 5) + "Project Name   : " + My.Settings.CurrentProjectName)
            k.WriteLine("!" + AddBlank(0, 5) + "--------------------------------------------------------")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine("!" + AddBlank(0, 5) + "Begin your code here:")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "module " + Strings.Replace(My.Computer.FileSystem.GetFileInfo(ofd.FileName).Name, My.Computer.FileSystem.GetFileInfo(ofd.FileName).Extension, ""))
            k.WriteLine("!" + AddBlank(0, 5) + "Declare your module variables here.")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "contains")
            k.WriteLine("!" + AddBlank(0, 5) + "Declare your methods here.")
            k.WriteLine(AddBlank(0, 6))
            k.WriteLine(AddBlank(0, 6) + "end module")
            k.Dispose()
            ListBox2.Items.Add(ofd.FileName)
            Dim Temp As String = ""
            For Each ProgramLib In My.Settings.PROGRAMLIB
                If ProgramLib.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMLIB.Remove(ProgramLib)

                    For Each item As String In ListBox1.Items
                        Temp += item + ";"
                    Next
                    My.Settings.PROGRAMLIB.Add(ComboBox1.Text + "=" + Temp)
                    Exit For
                End If
            Next

            Dim Temp2 As String = ""
            For Each ProgramMod In My.Settings.PROGRAMMOD
                If ProgramMod.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMOD.Remove(ProgramMod)

                    For Each item As String In ListBox2.Items
                        Temp2 += item + ";"
                    Next
                    My.Settings.PROGRAMMOD.Add(ComboBox1.Text + "=" + Temp2)
                    Exit For
                End If
            Next

            For Each ProgramSettings In My.Settings.PROGRAMSETTINGS
                If ProgramSettings.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMSETTINGS.Remove(ProgramSettings)
                    My.Settings.PROGRAMSETTINGS.Add(ComboBox1.Text + "=" + Strings.Replace(TextBox2.Text, vbNewLine, ";"))

                    Exit For
                End If
            Next

            For Each ProgramMain In My.Settings.PROGRAMMAIN
                If ProgramMain.Contains(ComboBox1.Text + "=") Then
                    My.Settings.PROGRAMMAIN.Remove(ProgramMain)
                    My.Settings.PROGRAMMAIN.Add(ComboBox1.Text + "=" + TextBox1.Text)

                    Exit For
                End If
            Next
            SaveProject(False)
            UpdateTree()
            Try

                If Trim(My.Settings.SOURCEEDITOR) = "" Then

                    Dim j As New CodeEditor(ofd.FileName)
                    j.Show()
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    ' Shell(My.Settings.SOURCEEDITOR + " " + ofd.FileName, AppWinStyle.NormalFocus)
                End If

            Catch ex As Exception
                NewMsgBox.MBox("Error! " + ex.Message, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
            End Try
        End If

        If Not TextBox2.Text.Contains("-J@SourcePath") Then
            Dim G As String = ""
            For Each line In TextBox2.Lines
                If Not Trim(line) = "" Then
                    G += line + vbNewLine
                End If
            Next
            TextBox2.Text = G
            If TextBox2.Lines.Count = 0 Then
                TextBox2.AppendText("-J@SourcePath" + vbNewLine)
            Else
                TextBox2.AppendText(vbNewLine + "-J@SourcePath" + vbNewLine)
            End If
            TextBox2_Clean()
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            If Not OpenedSourceCodes.Contains(ListView1.SelectedItems(0).Tag) Then

                If My.Settings.SOURCEEDITOR = "" Then
                    Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(0).Tag)
                    If FInfo.Extension.ToLower = ".a" Or FInfo.Extension.ToLower = ".dll" Or FInfo.Extension.ToLower = ".o" Then
                        Exit Sub
                    ElseIf FInfo.Extension.ToLower = ".cmd" Or FInfo.Extension.ToLower = ".bat"
                        Shell("notepad.exe" + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                        Exit Sub
                    End If
                    Dim j As New CodeEditor(ListView1.SelectedItems(0).Tag)
                    j.Show()
                    OpenedSourceCodes.Add(ListView1.SelectedItems(0).Tag)
                    ' Shell("explorer.exe " + ListBox1.SelectedItem, AppWinStyle.NormalFocus)
                Else
                    Dim FInfo As New IO.FileInfo(ListView1.SelectedItems(0).Tag)
                    If FInfo.Extension.ToLower = ".a" Or FInfo.Extension.ToLower = ".dll" Or FInfo.Extension.ToLower = ".o" Then
                        Exit Sub
                    ElseIf FInfo.Extension.ToLower = ".cmd" Or FInfo.Extension.ToLower = ".bat"
                        Shell("notepad.exe" + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                        Exit Sub
                    End If
                    Try
                        Shell(My.Settings.SOURCEEDITOR + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                    Catch ex As Exception
                        Shell("explorer.exe" + " """ + ListView1.SelectedItems(0).Tag + """", AppWinStyle.NormalFocus)
                    End Try
                End If
            Else
                Form1.HaveToFocusNow = ListView1.SelectedItems(0).Tag
                'NewMsgBox.MBox("Source code has been opened!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        TextBox5.Clear()
    End Sub

    Private Sub GotoErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoErrorToolStripMenuItem.Click
        On Error Resume Next
1:      Dim rgex As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:[0-9]+:\s*$", RegexOptions.IgnoreCase)
        Dim rgex2 As New Regex("^.*(\.for|\.f90|\.f|\.f95):[0-9]+:\s*$", RegexOptions.IgnoreCase)
        If rgex.IsMatch(TextBox5.Lines(TextBox5.Selection.Start.iLine)) Then

            If Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":").Count > 3 Then

                Dim location As String = Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(0) + ":" + Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(1)
                If My.Computer.FileSystem.FileExists(location) Then
                    If OpenedSourceCodes.Contains(location) Then
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

                            OpenedSourceCodes.Add(location)
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

            If Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":").Count > 2 Then
                Dim location As String = Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(0) + ":" + Strings.Split(TextBox5.Lines(TextBox5.Selection.Start.iLine), ":")(1)
                If My.Computer.FileSystem.FileExists(location) Then
                    If OpenedSourceCodes.Contains(location) Then
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

                            OpenedSourceCodes.Add(location)
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

    Private Sub ContextMenuStrip8_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip8.Opening
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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If My.Computer.FileSystem.FileExists(My.Settings.EXE) Then
            If My.Computer.FileSystem.GetFiles(My.Settings.EXE).Count > ListView2.Items.Count Then
                UpdateTree()
            End If
        End If
        Try
            If Not ProgressBar1.Visible = True Then
                ProgressBar1.Visible = True
            End If
            With cpu
                .CategoryName = "Processor"
                .CounterName = "% Processor Time"
                .InstanceName = "_Total"
            End With

            ' ...
            Dim ValStr As Single = FormatNumber(cpu.NextValue(), 1)
            Label11.Text = "CPU Utilisation: " + ValStr.ToString() + " %"
            ProgressBar1.Value = CInt(ValStr)
        Catch ex As Exception
            Label11.Text = ""
            ProgressBar1.Visible = False
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        isComboDrop = True
    End Sub

    Private Sub ComboBox1_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox1.DropDownClosed
        isComboDrop = False
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        GC.Collect()
    End Sub

    Private Sub TextBox5_Load(sender As Object, e As EventArgs) Handles TextBox5.Load

    End Sub
End Class