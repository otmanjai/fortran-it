Imports System.Drawing.Text

Public Class MainForm
    Dim pfc As PrivateFontCollection = New PrivateFontCollection
    Dim pfc2 As PrivateFontCollection = New PrivateFontCollection
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Fortran-It " + My.Application.Info.Version.ToString
        WebBrowser1.Visible = False
        WebBrowser1.Navigate("https://rabiewana.tumblr.com/fortranit")

        Me.Opacity = 0
        pfc.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksandb.ttf")
        pfc2.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksand.ttf")



        Label8.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
        Label2.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)

        '      TextBox1.Font = New Font(pfc2.Families(0), 9, FontStyle.Bold)
        If My.Application.CommandLineArgs.Count > 0 Then
            Form1.ClearSettings()
            If Form1.ResetCmdLine Then
                Exit Sub
            Else
                Dim k As New Form1(My.Application.CommandLineArgs(0))
                k.Show()
                Me.Close()
            End If
        Else
            Form1.ClearSettings()
        End If


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Not My.Settings.DefaultProjectDirectory = "" Then
            OpenFileDialog1.InitialDirectory = My.Settings.DefaultProjectDirectory
        End If
        Dim r As DialogResult = OpenFileDialog1.ShowDialog()
        If r = DialogResult.OK Then
            Form1.ResetCmdLine = False
            Dim k As New Form1(OpenFileDialog1.FileName)
            k.Show()
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim k As New Form2
        k.ShowDialog()
        If Not My.Settings.CurrentProjectPath = "" Then
            Dim d As New Form1(My.Settings.CurrentProjectPath)
            d.Show()
        End If
        Me.Close()
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        On Error Resume Next
        Label8.ForeColor = Color.DodgerBlue
        Label8.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        On Error Resume Next
        Label8.ForeColor = Color.Black
        Label8.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        On Error Resume Next
        Label2.ForeColor = Color.DodgerBlue
        Label2.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        On Error Resume Next
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel2.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs)
        Dim k As New Feedback(True)
        k.ShowDialog()
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs)
        Dim k As New Feedback(False)
        k.ShowDialog()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs)
        Dim k As New About
        k.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("explorer.exe", "http://fortran-it.xyz")
    End Sub

    Private Sub MainForm_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If Not My.Settings.DefaultProjectDirectory = "" Then
            OpenFileDialog1.InitialDirectory = My.Settings.DefaultProjectDirectory
        End If
        Dim r As DialogResult = OpenFileDialog1.ShowDialog()
        If r = DialogResult.OK Then
            Form1.ResetCmdLine = False
            Dim k As New Form1(OpenFileDialog1.FileName)
            k.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Label2_MouseEnter(sender As Object, e As EventArgs) Handles Label2.MouseEnter
        On Error Resume Next
        Label2.ForeColor = Color.DodgerBlue
        Label2.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        On Error Resume Next
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub Label8_MouseEnter(sender As Object, e As EventArgs) Handles Label8.MouseEnter
        On Error Resume Next
        Label8.ForeColor = Color.DodgerBlue
        Label8.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        On Error Resume Next
        Label8.ForeColor = Color.Black
        Label8.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim k As New Form2
        k.ShowDialog()
        If Not My.Settings.CurrentProjectPath = "" Then
            Dim d As New Form1(My.Settings.CurrentProjectPath)
            d.Show()
        End If
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs)
        Process.Start("explorer.exe", e.LinkText)
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class