Public Class dlgEscortDriveInfo

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
 
    Private Sub dlgEscortDriveInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TopMost = IsAllTopMostForm

    End Sub
End Class