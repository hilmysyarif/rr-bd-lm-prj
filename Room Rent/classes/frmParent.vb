Public Class frmParent
    Dim bgForm As Form

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Try
            If Not DesignMode Then
                'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                bgForm = New Form
                'Add any initialization after the InitializeComponent() call.
                bgForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                bgForm.BackColor = Color.Black
                bgForm.Opacity = 0.1
                Me.Owner = bgForm

                bgForm.TopMost = Me.TopMost
                bgForm.ShowIcon = Me.ShowIcon
                bgForm.Icon = Me.Icon

                'bgForm.ShowInTaskbar = Me.ShowInTaskbar
                bgForm.ShowInTaskbar = False
                Me.StartPosition = FormStartPosition.CenterScreen
            End If
        Catch ex As Exception

        End Try

    End Sub
    'Sub ShowDialog1()
    '    Me.Show()
    '    bgForm.ShowDialog()
    'End Sub

    Dim downLocation As Point = Nothing
    Private Sub frmMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
        bgForm.Close()
    End Sub

    Private Sub frmMaster_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

        Try
            If Not DesignMode Then
                bgForm.Size = Me.Size + New Size(20, 20)
                bgForm.Location = Me.Location - New Point(10, 10)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMaster_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Try
            If Not DesignMode Then
                If e.Location.X > Me.Width - 30 And e.Location.Y < 20 Then
                    Close()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMaster_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Try
            downLocation = e.Location
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMaster_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Try
            If Not DesignMode Then
                Dim gr As Graphics = Me.CreateGraphics
                If e.Location.X > Me.Width - 30 And e.Location.Y < 20 Then
                    gr.DrawString("X", New Font("Times New Roman", 18, FontStyle.Bold), Brushes.Green, New Point(Me.Width - 30, 0))
                Else
                    gr.DrawString("X", New Font("Times New Roman", 18, FontStyle.Bold), Brushes.Red, New Point(Me.Width - 30, 0))
                    If MouseButtons = Windows.Forms.MouseButtons.Left Then
                        Me.Location = MousePosition - downLocation
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMaster_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            e.Graphics.DrawString("X", New Font("Times New Roman", 18, FontStyle.Bold), Brushes.Red, New Point(Me.Width - 30, 0))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If Not DesignMode Then

                bgForm.Show()
                bgForm.Size = Me.Size + New Size(20, 20)
                bgForm.Location = Me.Location - New Point(10, 10)
            End If

        Catch ex As Exception

        End Try

    End Sub
    'Shadows Sub ShowDialog()
    '    Me.ShowDialog()
    'End Sub
    Private Sub frmMaster_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            If Not DesignMode Then
                bgForm.Size = Me.Size + New Size(20, 20)
                bgForm.Location = Me.Location - New Point(10, 10)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMaster_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Not DesignMode Then
                bgForm.Visible = Me.Visible
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Property OpacityBackGround As Double
        Set(ByVal value As Double)
            bgForm.Opacity = value
        End Set
        Get
            Return bgForm.Opacity
        End Get
    End Property
    Public Property ColorBackGround As Color
        Set(ByVal value As Color)
            bgForm.BackColor = value
        End Set
        Get
            Return bgForm.BackColor
        End Get
    End Property

End Class