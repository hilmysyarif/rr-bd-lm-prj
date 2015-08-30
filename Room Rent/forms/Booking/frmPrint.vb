Public Class frmPrint

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub
End Class