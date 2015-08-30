Public Class frmSPNotAvailableList
    Dim objWorker As New cls_tblWorkers

    Sub LoadWorkers()
        dgList.DataSource = objWorker.Selection1(cls_tblWorkers.SelectType.All_with_availability, "[NotAvailableTill]>GETDATE()")
        dgList.Columns("DC_Date").Visible = False
        dgList.Columns("Started_Date").Visible = False
        dgList.Columns("PreferredContactMethod").Visible = False
        dgList.Columns("Notes").Visible = False
        dgList.Columns("WorkerID").HeaderText = "SP ID"
        dgList.Columns("WorkerName").HeaderText = "Name"
        dgList.Columns("NotAvailableTill").HeaderText = "Unavailable Till"
        dgList.Columns("AvailabilityComment").HeaderText = "Comment"
    End Sub

    Private Sub btnSetAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAvailability.Click
        Dim frm As New frmSetWorkerNotAvailable
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadWorkers()
            frmHome.Loadings()
        End If
    End Sub

    Private Sub frmSPNotAvailableList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Top = IsAllTopMostForm
        LoadWorkers()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgList.SelectedRows.Count = 0 Then
            MsgBox("Please select an SP ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBox("Are you sure (Yes/No)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objWorker.Update_Availability(dgList.SelectedRows(0).Cells("WorkerID").Value, Today.AddSeconds(-1), "Available")
            MsgBox("Deleted Successfully", MsgBoxStyle.Information, "Info")
            LoadWorkers()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

End Class