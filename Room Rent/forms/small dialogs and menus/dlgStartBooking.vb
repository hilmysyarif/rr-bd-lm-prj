Imports System.Windows.Forms

Public Class dlgStartBooking
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgExtendDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Question.Handle)
    End Sub

    Private Sub btnActivates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivates.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnSuspend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuspend.Click, Button1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class
