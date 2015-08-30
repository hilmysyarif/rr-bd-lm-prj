Public Class frmWeeklyBookingReport

    Dim objReports As New cls_Reports


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim frm As New frmPrintList
        frm.PrintPreview(dgWeeklyBooking, "Weekly Booking Report", _
                         "Date : " & DateTimePicker5.Value.AddDays(1 - DateTimePicker5.Value.DayOfWeek).ToShortDateString & " To " & DateTimePicker5.Value.AddDays(7 - DateTimePicker5.Value.DayOfWeek).ToShortDateString, _
                         "", "", False, "", True)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        refreshWeeklyReport_Booking(DateTimePicker5.Value)
    End Sub
    Private Sub frmWeeklyBookingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        DateTimePicker5.Value = DateTimePicker5.Value.AddDays(-DateTimePicker5.Value.DayOfWeek + 1)
        refreshWeeklyReport_Booking()
    End Sub
    Sub refreshWeeklyReport_Booking(Optional ByVal rptDate As Date = Nothing)
        Try
            dgWeeklyBooking.DataSource = Nothing
            dgWeeklyBooking.Columns.Clear()
            If rptDate = Nothing Then
                If Now.Hour < 9 Then
                    dgWeeklyBooking.DataSource = objReports.WeeklyReportBookings(Today.AddDays(-1))
                Else
                    dgWeeklyBooking.DataSource = objReports.WeeklyReportBookings(Today)
                End If
            Else
                dgWeeklyBooking.DataSource = objReports.WeeklyReportBookings(rptDate.Date)
            End If
            dgWeeklyBooking.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgWeeklyBooking.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            For Each c As DataGridViewColumn In dgWeeklyBooking.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgWeeklyBooking.Columns.Add(New DataGridViewTextBoxColumn)
            dgWeeklyBooking.Columns(dgWeeklyBooking.ColumnCount - 1).HeaderText = " "
            dgWeeklyBooking.Columns(dgWeeklyBooking.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgWeeklyBooking.Columns("Status").Visible = False
            For Each dr As DataGridViewRow In dgWeeklyBooking.Rows
                If dr.Cells("Status").Value.ToString.StartsWith("CANCEL") Then
                    dr.DefaultCellStyle.BackColor = Color.Gray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub DateTimePicker5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker5.ValueChanged
        DateTimePicker5.Value = DateTimePicker5.Value.AddDays(-DateTimePicker5.Value.DayOfWeek + 1)
    End Sub
End Class