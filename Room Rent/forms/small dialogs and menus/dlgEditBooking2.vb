Imports System.Windows.Forms

Public Class dlgEditBooking2
    Dim vDialogResult As BookingEditResult = Nothing
    Public Enum BookingEditResult
        CHANGE_ROOM
        CHANGE_WORKER
        CANCEL
        GOBACK
    End Enum
    Public Shadows Property DialogResultEx As BookingEditResult
        Get
            Return vDialogResult
        End Get
        Set(ByVal value As BookingEditResult)
            vDialogResult = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CHANGE_WORKER
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CANCEL
        Me.Close()
    End Sub
    Private Sub btnExtend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtend.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CHANGE_ROOM
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResultEx = BookingEditResult.GOBACK
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgExtendDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Question.Handle)
    End Sub

    
End Class
