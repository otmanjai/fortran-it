
Imports System.Drawing.Text

Public Class ProjectParameters
    Dim pfc As PrivateFontCollection = New PrivateFontCollection
    Private Sub ProjectParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        Me.Opacity = 0
        pfc.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksand.ttf")
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.GridColor = Color.Black
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45)
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ColumnHeadersVisible = False
        DataGridView1.RowCount = 7
        DataGridView1.Item(0, 0).Value = "PARAMETER NAME"
        DataGridView1.Item(0, 1).Value = "BinPath"
        DataGridView1.Item(0, 2).Value = "CompilerName"
        DataGridView1.Item(0, 3).Value = "OutputPath"
        DataGridView1.Item(0, 4).Value = "SourcePath"
        DataGridView1.Item(0, 5).Value = "LibraryPath"
        DataGridView1.Item(0, 6).Value = "Default Editor"

        DataGridView1.Item(1, 0).Value = "VALUE"
        With My.Settings
            DataGridView1.Item(1, 1).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 1).Value = .BIN
            DataGridView1.Item(1, 2).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 2).Value = .COMPILER
            DataGridView1.Item(1, 3).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 3).Value = .EXE
            DataGridView1.Item(1, 4).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 4).Value = .SOURCE
            DataGridView1.Item(1, 5).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 5).Value = .LIBRARY
            DataGridView1.Item(1, 6).Style.WrapMode = DataGridViewTriState.True
            DataGridView1.Item(1, 6).Value = .SOURCEEDITOR
        End With

        DataGridView1.Item(0, 0).ReadOnly = True
        DataGridView1.Item(1, 0).ReadOnly = True
        'Set DataGridView Appearance...
        With DataGridView1
            .Columns(0).ReadOnly = True
            .Columns(0).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .Columns(1).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .Item(0, 0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Item(1, 0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Item(0, 0).Style.Font = New Font(pfc.Families(0), 9, FontStyle.Bold)
            .Item(1, 0).Style.Font = New Font(pfc.Families(0), 9, FontStyle.Bold)
            .Columns(0).Width = 30 * (DataGridView1.Width - 5) / 100
            .Columns(1).Width = 70 * (DataGridView1.Width - 5) / 100
            .Rows(1).Height = 60
            .Rows(2).Height = 60
            .Rows(3).Height = 60
            .Rows(4).Height = 60
            .Rows(5).Height = 60
            .Rows(6).Height = 60

            .CellBorderStyle = DataGridViewCellBorderStyle.Single
        End With
        isLoading = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim OFD As New OpenFileDialog
        OFD.Filter = "Executable File|*.exe"
        OFD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Dim r As DialogResult = OFD.ShowDialog
        If r = DialogResult.OK Then
            My.Settings.SOURCEEDITOR = OFD.FileName
            My.Settings.Save()
            NewMsgBox.MBox("Done! Default source code editor program has been set.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        End If
        DataGridView1.Item(1, 6).Value = My.Settings.SOURCEEDITOR
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.SOURCEEDITOR = ""
        My.Settings.Save()
        DataGridView1.Item(1, 6).Value = My.Settings.SOURCEEDITOR
    End Sub


    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
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

    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Close()
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Not e.ColumnIndex = 0 And Not e.RowIndex = 2 And Not e.RowIndex = 0 And Not e.RowIndex = 6 Then
            Dim t As DialogResult = FolderBrowserDialog1.ShowDialog()
            If t = DialogResult.OK Then
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = FolderBrowserDialog1.SelectedPath
            End If
        ElseIf e.ColumnIndex = 1 And e.RowIndex = 6 Then
            Dim OFD As New OpenFileDialog
            OFD.Filter = "Executable File|*.exe"
            OFD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
            Dim r As DialogResult = OFD.ShowDialog
            If r = DialogResult.OK Then
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = OFD.FileName
                NewMsgBox.MBox("Done! Default source code editor program has been set.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            End If
        ElseIf e.ColumnIndex = 1 And e.RowIndex = 2 Then
            Dim OFD As New OpenFileDialog
            OFD.Filter = "Executable File|*.exe"
            OFD.InitialDirectory = My.Settings.BIN
            Dim r As DialogResult = OFD.ShowDialog
            If r = DialogResult.OK Then
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = Strings.Replace(My.Computer.FileSystem.GetFileInfo(OFD.FileName).Name, ".exe", "")
                NewMsgBox.MBox("Done! Compiler name has been set.", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            End If
        End If
    End Sub


    Dim isLoading As Boolean = True
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        'Dim e = DataGridView1.SelectedCells(0)

        Try
            If e.ColumnIndex = 1 And Not isLoading Then
                Select Case e.RowIndex
                    Case 1
                        My.Settings.BIN = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    Case 2
                        My.Settings.COMPILER = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    Case 3
                        My.Settings.EXE = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    Case 4
                        My.Settings.SOURCE = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    Case 5
                        My.Settings.LIBRARY = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    Case 6
                        My.Settings.SOURCEEDITOR = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                End Select
                My.Settings.Save()
                Form1.ChangedData = True
            End If
        Catch ex As Exception
            NewMsgBox.MBox("Error saving parameters!", MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\MinGW") Then
            My.Settings.BIN = My.Application.Info.DirectoryPath + "\MinGW\bin"
            My.Settings.LIBRARY = My.Application.Info.DirectoryPath + "\MinGW\lib"
            My.Settings.COMPILER = "gfortran"
            My.Settings.Save()
            isLoading = True
            pfc.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksand.ttf")
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.GridColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45)
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.ColumnHeadersVisible = False
            DataGridView1.RowCount = 7
            DataGridView1.Item(0, 0).Value = "PARAMETER NAME"
            DataGridView1.Item(0, 1).Value = "BinPath"
            DataGridView1.Item(0, 2).Value = "CompilerName"
            DataGridView1.Item(0, 3).Value = "OutputPath"
            DataGridView1.Item(0, 4).Value = "SourcePath"
            DataGridView1.Item(0, 5).Value = "LibraryPath"
            DataGridView1.Item(0, 6).Value = "Default Editor"

            DataGridView1.Item(1, 0).Value = "VALUE"
            With My.Settings
                DataGridView1.Item(1, 1).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 1).Value = .BIN
                DataGridView1.Item(1, 2).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 2).Value = .COMPILER
                DataGridView1.Item(1, 3).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 3).Value = .EXE
                DataGridView1.Item(1, 4).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 4).Value = .SOURCE
                DataGridView1.Item(1, 5).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 5).Value = .LIBRARY
                DataGridView1.Item(1, 6).Style.WrapMode = DataGridViewTriState.True
                DataGridView1.Item(1, 6).Value = .SOURCEEDITOR
            End With

            DataGridView1.Item(0, 0).ReadOnly = True
            DataGridView1.Item(1, 0).ReadOnly = True
            'Set DataGridView Appearance...
            With DataGridView1
                .Columns(0).ReadOnly = True
                .Columns(0).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                .Columns(1).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                .Item(0, 0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Item(1, 0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Item(0, 0).Style.Font = New Font(pfc.Families(0), 9, FontStyle.Bold)
                .Item(1, 0).Style.Font = New Font(pfc.Families(0), 9, FontStyle.Bold)
                .Columns(0).Width = 30 * (DataGridView1.Width - 5) / 100
                .Columns(1).Width = 70 * (DataGridView1.Width - 5) / 100
                .Rows(1).Height = 60
                .Rows(2).Height = 60
                .Rows(3).Height = 60
                .Rows(4).Height = 60
                .Rows(5).Height = 60
                .Rows(6).Height = 60

                .CellBorderStyle = DataGridViewCellBorderStyle.Single
            End With
            isLoading = False

        End If
        NewMsgBox.MBox("The compiler settings was set to default!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
    End Sub
End Class

