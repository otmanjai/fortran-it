

Public Class NewMsgBox
    Public Shared ReturnValue As MsgBoxResult = Nothing
    Private Type_ As MsgBoxStyle = MsgBoxStyle.YesNo
    Private Sub NewMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
    End Sub
    Sub New(ByVal Message As String, ByVal Type As MsgBoxStyle, ByVal AlertType As MsgBoxStyle)
        ' This call is required by the designer.
        InitializeComponent()
        Me.MinimumSize = Me.Size
        TextBox1.Text = Message
        ReturnValue = Nothing
        Type_ = Type
        If Type = MsgBoxStyle.YesNo And AlertType = MsgBoxStyle.Critical Then
            Button3.Visible = False
            Button2.Location = Button1.Location
            Button2.Text = "Yes"
            Button1.Location = Button3.Location
            Button1.Text = "No"
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.YesNo And AlertType = MsgBoxStyle.Exclamation Then
            Button3.Visible = False
            Button2.Location = Button1.Location
            Button2.Text = "Yes"
            Button1.Location = Button3.Location
            Button1.Text = "No"
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.YesNo And AlertType = MsgBoxStyle.Information Then
            Button3.Visible = False
            Button2.Location = Button1.Location
            Button2.Text = "Yes"
            Button1.Location = Button3.Location
            Button1.Text = "No"
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        ElseIf Type = MsgBoxStyle.OkOnly And AlertType = MsgBoxStyle.Critical
            Button2.Location = Button3.Location
            Button2.Text = "Okay"
            Button3.Visible = False
            Button1.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.OkOnly And AlertType = MsgBoxStyle.Exclamation
            Button2.Location = Button3.Location
            Button2.Text = "Okay"
            Button3.Visible = False
            Button1.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.OkOnly And AlertType = MsgBoxStyle.Information
            Button2.Location = Button3.Location
            Button2.Text = "Okay"
            Button3.Visible = False
            Button1.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        ElseIf Type = MsgBoxStyle.OkCancel And AlertType = MsgBoxStyle.Critical
            Button2.Location = Button1.Location
            Button2.Text = "Okay"
            Button1.Visible = False
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.OkCancel And AlertType = MsgBoxStyle.Exclamation
            Button2.Location = Button1.Location
            Button2.Text = "Okay"
            Button1.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.OkCancel And AlertType = MsgBoxStyle.Information
            Button2.Location = Button1.Location
            Button2.Text = "Okay"
            Button1.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        ElseIf Type = MsgBoxStyle.YesNoCancel And AlertType = MsgBoxStyle.Critical
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.YesNoCancel And AlertType = MsgBoxStyle.Exclamation

            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
        ElseIf Type = MsgBoxStyle.YesNoCancel And AlertType = MsgBoxStyle.Information
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        End If

        ' Add any initialization after the InitializeComponent() call.

        Try
            My.Computer.Audio.Play(My.Resources.alert, AudioPlayMode.Background)
        Catch ex As Exception

        End Try
        TextBox1.Location = New Point(TextBox1.Location.X, PictureBox1.Location.Y)
        TextBox1.AutoSize = False
        TextBox1.Size = New Size(299, PictureBox1.Height)
        TextBox1.TextAlign = ContentAlignment.MiddleLeft
        Button2.Focus()
        TextBox1.AutoEllipsis = True
        TextBox1.MaximumSize = New Size(299, 93)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Yes" Then
            ReturnValue = MsgBoxResult.Yes
        ElseIf Button2.Text = "Okay"
            ReturnValue = MsgBoxResult.Ok
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "No" Then
            ReturnValue = MsgBoxResult.No
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ReturnValue = MsgBoxResult.Cancel
        Me.Close()
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub

    Public Shared Function MBox(ByVal Message As String, ByVal Style As MsgBoxStyle, ByVal AlertStyle As MsgBoxStyle) As DialogResult
        Dim k As New NewMsgBox(Message, Style, AlertStyle)
        k.ShowDialog()
        Return NewMsgBox.ReturnValue
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        If Type_ = MsgBoxStyle.YesNoCancel Or Type_ = MsgBoxStyle.OkCancel Then
            ReturnValue = MsgBoxResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        If Type_ = MsgBoxStyle.YesNo Or Type_ = MsgBoxStyle.YesNoCancel Then
            ReturnValue = MsgBoxResult.No
        End If
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        If Type_ = MsgBoxStyle.YesNo Or Type_ = MsgBoxStyle.YesNoCancel Then
            ReturnValue = MsgBoxResult.Yes
        ElseIf Type_ = MsgBoxStyle.OkCancel Or Type_ = MsgBoxStyle.OkOnly
            ReturnValue = MsgBoxResult.Ok
        End If
        Me.Close()
    End Sub


    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Me.Height = TextBox1.Height + 50
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ReturnValue = MsgBoxResult.Cancel
        Me.Close()
    End Sub
End Class