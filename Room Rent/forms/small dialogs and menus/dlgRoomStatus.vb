Public Class dlgRoomStatus
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        cmbStatus.SelectedIndex = 0
        cmbUsable.SelectedIndex = 0
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub dlgRoomStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TopMost = IsAllTopMostForm
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class