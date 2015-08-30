Public Class frmSetWorkerNotAvailable
    Dim objWorker As New cls_tblWorkers

    Sub LoadWorkers()
        FillComBoBox(cmbWorker, "tblWorkers", "WorkerName", "WorkerID", " workerid not in (select workerid from tblActiveWorker where bookingid not in (select bookingid from tblBookingStatus) and status in ('','STARTED','QUEUE'))")
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub frmSetWorkerNotAvailable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Top = IsAllTopMostForm
        LoadWorkers()
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        objWorker.Update_Availability(cmbWorker.SelectedValue, dtpNotAvailableTill.Value.Date.AddDays(1).AddSeconds(-1), txtComment.Text)
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub
End Class