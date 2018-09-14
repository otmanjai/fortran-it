﻿
Imports System.Runtime.InteropServices

<ComVisibleAttribute(False)> Public Class NewMenuStripRenderer
    Inherits ToolStripSystemRenderer


    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If Not e.Item.Selected Then
            Dim MenuRectangle As New Rectangle(Point.Empty, e.Item.Size)
            e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), MenuRectangle)
            e.Item.ForeColor = Color.Black
        ElseIf Not e.Item.Enabled = False
            Dim MenuRectangle As New Rectangle(Point.Empty, e.Item.Size)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 45, 45)), MenuRectangle)
            e.Item.ForeColor = Color.White
            e.ToolStrip.BackColor = Color.Transparent
        End If
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        'MyBase.OnRenderToolStripBorder(e)
    End Sub

End Class


<ComVisibleAttribute(False)> Public Class NewToolStripRenderer
    Inherits ToolStripProfessionalRenderer

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If Not e.Item.Selected Then
            Dim MenuRectangle As New Rectangle(Point.Empty, e.Item.Size)
            e.Graphics.FillRectangle(New SolidBrush(Color.White), MenuRectangle)
            e.Item.ForeColor = Color.Black
        Else
            Dim MenuRectangle As New Rectangle(Point.Empty, e.Item.Size)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(48, 113, 173)), MenuRectangle)
            e.Item.ForeColor = Color.White
            e.ToolStrip.BackColor = Color.White
        End If
        Me.RoundedEdges = True
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        'MyBase.OnRenderToolStripBorder(e)

    End Sub

End Class

Public Class myListBox
    Inherits ListBox
    Private Sub myListBox_DrawItem(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.DrawItemEventArgs
    ) Handles Me.DrawItem
        e.DrawBackground()
        'Let's declare a brush, so that we can color the items that are added in the listbox. 
        Dim myBrush As Brush
        If (e.State And DrawItemState.Selected) Then
            e.Graphics.FillRectangle(Brushes.LightCyan, e.Bounds)
        End If
        'Determine the color of the brush to draw each item based on the index of the item to draw. 
        Select Case (e.Index) Mod 3
            Case 0
                myBrush = Brushes.Chocolate
            Case 1
                myBrush = Brushes.MediumSlateBlue
            Case 2
                myBrush = Brushes.Teal
            Case Else
                myBrush = Brushes.Black
        End Select
        ' Draw the current item text based on the current Font and the custom brush settings. 
        e.Graphics.DrawString(Me.Items(e.Index), Me.Font, myBrush,
        New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        'If the ListBox has focus, draw a focus rectangle around the selected item. 
        e.DrawFocusRectangle()
    End Sub
    Public Sub New()
        'This is super important. If you miss it... you won't be able to Draw the item. 
        'If you make it OwnerDrawFixed you won't be able to measure the item. 
        Me.DrawMode = DrawMode.OwnerDrawVariable
    End Sub
    Private Sub myListBox_MeasureItem(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.MeasureItemEventArgs
    ) Handles Me.MeasureItem
        Dim g As Graphics = e.Graphics
        'We will get the size of the string which we are about to draw, 
        'so that we could set the ItemHeight and ItemWidth property 
        Dim size As SizeF = g.MeasureString(Me.Items.Item(e.Index).ToString, Me.Font,
        Me.Width - 5 - SystemInformation.VerticalScrollBarWidth)
        e.ItemHeight = CInt(size.Height) + 5
        e.ItemWidth = CInt(size.Width) + 5
    End Sub
End Class