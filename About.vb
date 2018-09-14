Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0.0
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick
        If Me.Opacity = 1 Then
            TimerFadeIn.Enabled = False
        Else
            Me.Opacity += 0.04
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("explorer.exe", "http://fortran-it.xyz")
    End Sub
End Class