'Imports Microsoft.VisualBasic.Devices
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Input

Public Class UserControl1
    Dim angle = 0
    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        'Dim currentLocation As Point = Mouse.GetPosition(Me)
        'Dim knobCenter As Point = New Point(Me.ActualHeight / 2, Me.ActualWidth / 2)
        'Dim radians As Double = Math.Atan((currentLocation.Y - knobCenter.Y) / (currentLocation.X - knobCenter.X))
        'angle = radians * 180 / Math.PI
        angle += 1
        Dim rt As RotateTransform = New RotateTransform()
        Image1.RenderTransform = rt
        Image1.RenderTransformOrigin = New System.Windows.Point(0.5, 0.5)
        rt.Angle = angle
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        angle -= 1
        Dim rt As RotateTransform = New RotateTransform()
        Image1.RenderTransform = rt
        Image1.RenderTransformOrigin = New System.Windows.Point(0.5, 0.5)
        rt.Angle = angle
    End Sub


End Class
