Public Class frmDoorChargeReport
    Dim objReports As New cls_Reports

    Private Sub frmDoorChargeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        refreshDailyReport_DOOR()
    End Sub
    Sub refreshDailyReport_DOOR(Optional ByVal rptDate As Date = Nothing)
        Try
            dgDailyDoor.DataSource = Nothing
            dgDailyDoor.Columns.Clear()
            If rptDate = Nothing Then
                If Now.Hour < 9 Then
                    dgDailyDoor.DataSource = objReports.DailyReportDoor(Today.AddDays(-1))
                Else
                    dgDailyDoor.DataSource = objReports.DailyReportDoor(Today)
                End If
            Else
                dgDailyDoor.DataSource = objReports.DailyReportDoor(rptDate.Date)
            End If
            dgDailyDoor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgDailyDoor.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            For Each c As DataGridViewColumn In dgDailyDoor.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgDailyDoor.Columns.Add(New DataGridViewTextBoxColumn)
            dgDailyDoor.Columns(dgDailyDoor.ColumnCount - 1).HeaderText = " "
            dgDailyDoor.Columns(dgDailyDoor.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        refreshDailyReport_DOOR(DateTimePicker2.Value)
    End Sub

    Private Sub btnRefreshDoorCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshDoorCharge.Click
        refreshDailyReport_DOOR(DateTimePicker2.Value)
    End Sub

    Private Sub btnPrintDoorDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDoorDaily.Click
        Dim frm As New frmPrintList
        frm.PrintPreview(dgDailyDoor, "Daily Door Charge Report", "Date : " & DateTimePicker2.Value.ToShortDateString, "", "", False, "", True)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim frm As New frmDoorChargeChart
        frm.rep_date = DateTimePicker2.Value.Date
        frm.ShowDialog()
    End Sub



End Class