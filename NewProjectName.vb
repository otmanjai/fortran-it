Public Class NewProjectName
    Public Shared ReturnValue As String
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.Panel1.ClientRectangle, Color.FromArgb(48, 123, 173), ButtonBorderStyle.Solid)
    End Sub

    Sub New(ByVal Question1 As String)

        ' This call is required by the designer.
        InitializeComponent()
        Label3.Text = Question1
        TextBox1.Focus()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Shared Function IBox(ByVal Question As String) As String
        Dim k As New NewProjectName(Question)
        k.ShowDialog()
        Return NewProjectName.ReturnValue
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReturnValue = TextBox1.Text
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Close()
    End Sub
End Class