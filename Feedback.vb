Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Net
Imports System.Net.Mail
Public Class Feedback
    Dim pfc As PrivateFontCollection = New PrivateFontCollection
    Private bw As BackgroundWorker = New BackgroundWorker
    Private _IsHappy As Boolean = True
    Sub New(Optional ByVal isHappy As Boolean = True)
        _IsHappy = isHappy
        ' This call is required by the designer.
        InitializeComponent()
        pfc.AddFontFile(My.Application.Info.DirectoryPath + "\fonts\quicksandb.ttf")
        Label10.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
        If isHappy Then
            Label1.Text = "Thanks for your feedback. What did you like about Fortran-It SDE?"
            Label10.Text = "HIP, HIP, HOORAY!"
        Else

            Label1.Text = "Help us turn that frown into a smile..."
            Label10.Text = "WE'RE SORRY!"
        End If
        ' Add any initialization after the InitializeComponent() call.
        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Network.IsAvailable = False Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Trim(TextBox1.Text) = "" Then
            bw.RunWorkerAsync()
            TextBox1.Enabled = False
            Timer2.Enabled = True
            Button1.Enabled = False
            Button1.Text = "Sending"
        Else
            NewMsgBox.MBox("Please write something for us!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        End If
    End Sub


    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        Try
            If bw.CancellationPending = True Then
                e.Cancel = True
            Else

                Dim SMessage As MailMessage
                If _IsHappy Then
                    SMessage = New MailMessage("fortranit.sde@gmail.com", "fortranit.sde@gmail.com", "Fortran-It Feedback: " + My.Computer.Name, My.Computer.Name + " likes Fortran-It!" + vbNewLine + vbNewLine + TextBox1.Text)
                Else
                    SMessage = New MailMessage("fortranit.sde@gmail.com", "fortranit.sde@gmail.com", "Fortran-It Feedback: " + My.Computer.Name, My.Computer.Name + " sends a frown :(" + vbNewLine + vbNewLine + TextBox1.Text)
                End If
                Dim SMTP As New SmtpClient("smtp.gmail.com", 587)
                SMTP.EnableSsl = True
                SMTP.Credentials = New NetworkCredential("fortranit.sde@gmail.com", "mrom6485")
                SMTP.Send(SMessage)
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
        '

    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            NewMsgBox.MBox("Oh! You choose to cancel!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
        ElseIf e.Error IsNot Nothing Then
            NewMsgBox.MBox("Oh no! Your feedback could not be sent!", MsgBoxStyle.OkOnly, MsgBoxStyle.Exclamation)
        Else
            NewMsgBox.MBox("Thanks! Your feedback has been sent!", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            Me.Close()
        End If
        Button1.Text = "Send"
        TextBox1.Enabled = True
        Button1.Enabled = True
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not bw.IsBusy Then
            Me.Close()
        Else
            bw.CancelAsync()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub

    Private Sub Feedback_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0.0
    End Sub
End Class