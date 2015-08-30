Public Class frmDailyBooking
    Dim objReports As New cls_Reports
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Now.Hour > 9 Then
            DateTimePicker1.Value = Today.AddHours(9)
            DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
            DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If

    End Sub
    Private Sub btnDailyRPTRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyRPTRefresh.Click
        'refreshDailyReport_Booking(DateTimePicker1.Value.Date)
        refreshDailyReport_Booking()
    End Sub

    'Sub refreshDailyReport_Booking(Optional ByVal rptDate As Date = Nothing)
    '    Try
    '        dgDailyReport.DataSource = Nothing
    '        dgDailyReport.Columns.Clear()
    '        If rptDate = Nothing Then
    '            If Now.Hour < 9 Then
    '                dgDailyReport.DataSource = objReports.DailyReportBookings(Today.AddDays(-1))
    '                DateTimePicker1.Value = Today.AddDays(-1)
    '                DateTimePicker2.Value = Today
    '            Else
    '                dgDailyReport.DataSource = objReports.DailyReportBookings(Today)
    '                DateTimePicker1.Value = Today
    '                DateTimePicker2.Value = Today.AddDays(-1)
    '            End If
    '        Else
    '            'dgDailyReport.DataSource = objReports.DailyReportBookings(rptDate.Date)
    '            dgDailyReport.DataSource = objReports.DailyReportBookings2(DateTimePicker1.Value.Date.AddHours(9), DateTimePicker2.Value.Date.AddHours(9).AddSeconds(-1))
    '        End If
    '        dgDailyReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    '        dgDailyReport.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
    '        For Each c As DataGridViewColumn In dgDailyReport.Columns
    '            c.SortMode = DataGridViewColumnSortMode.Programmatic
    '        Next
    '        dgDailyReport.Columns.Add(New DataGridViewTextBoxColumn)
    '        dgDailyReport.Columns(dgDailyReport.ColumnCount - 1).HeaderText = " "
    '        dgDailyReport.Columns(dgDailyReport.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        dgDailyReport.Columns("Status").Visible = False
    '        For Each dr As DataGridViewRow In dgDailyReport.Rows
    '            If dr.Cells("Status").Value.ToString.StartsWith("CANCEL") Then
    '                dr.DefaultCellStyle.BackColor = Color.Gray
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
    '    End Try
    'End Sub

    Sub refreshDailyReport_Booking()
        Try
            dgDailyReport.DataSource = Nothing
            dgDailyReport.Columns.Clear()
            dgDailyReport.DataSource = objReports.DailyReportBookings2(DateTimePicker1.Value, DateTimePicker2.Value)

            dgDailyReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgDailyReport.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            For Each c As DataGridViewColumn In dgDailyReport.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgDailyReport.Columns.Add(New DataGridViewTextBoxColumn)
            dgDailyReport.Columns(dgDailyReport.ColumnCount - 1).HeaderText = " "
            dgDailyReport.Columns(dgDailyReport.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgDailyReport.Columns("Status").Visible = False
            For Each dr As DataGridViewRow In dgDailyReport.Rows
                If dr.Cells("Status").Value.ToString.StartsWith("CANCEL") Then
                    dr.DefaultCellStyle.BackColor = Color.Gray
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintList
        frm.PrintPreview(dgDailyReport, "Daily Booking Report", "Date : " & DateTimePicker1.Value.ToShortDateString, "", "", True, "", True)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        ' refreshDailyReport_Booking(DateTimePicker1.Value)
    End Sub

    Private Sub frmDailyBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
   

        refreshDailyReport_Booking()
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Close()
    End Sub
End Class