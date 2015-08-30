Public Class frmSMSDailog

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmSMSDailog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        RichTextBox1.Clear()
    End Sub

    Private Sub RichTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox1.KeyPress
        Label2.Text = RichTextBox1.Text.Length
    End Sub
End Class