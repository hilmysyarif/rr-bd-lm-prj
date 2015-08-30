Public Class frmWorkerAddQueue2Active
    Dim objWorker As New cls_tblWorkers
    Dim selectedWorkerID As Integer = 0
    Dim selecteddcdate As Date = Now
    Private Sub frmWorkerLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objWorker.LoadWorker(lstActiveProvider, cls_tblWorkers.SelectionType.ALL)
        lblDCDate.Text = ""
        btnLogin.Enabled = False
    End Sub

    Private Sub lstActiveProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstActiveProvider.SelectedIndexChanged
        If lstActiveProvider.SelectedItems.Count > 0 Then
            Dim workerid As String = lstActiveProvider.SelectedItems(0).Tag
            selectedWorkerID = workerid
            Dim dt As DataTable = objWorker.Selection("Where [Workerid]=" & workerid)
            Dim dr As DataRow = dt.Rows(0)
            selecteddcdate = CDate(dr("dc_date"))
            Dim totd As Integer = Math.Floor((selecteddcdate - Now).TotalDays)
            If totd <= 0 Then
                lblDCDate.ForeColor = Color.Red
                totd = -totd
                lblDCDate.Text = selecteddcdate.ToShortDateString + vbNewLine + "Expired " + totd.ToString + " days ago"
                btnLogin.Enabled = False
            Else
                lblDCDate.ForeColor = Color.Green
                lblDCDate.Text = selecteddcdate.ToShortDateString + vbNewLine + totd.ToString + " days left to expire"
                btnLogin.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim objCustomer As New cls_tblWorkers
        objCustomer.Insert_tblQueueWorkers(selectedWorkerID, Today)
        frmNewHome01.Loadings()
        Close()
    End Sub
End Class