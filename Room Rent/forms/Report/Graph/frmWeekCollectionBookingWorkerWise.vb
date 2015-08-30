Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmWeekCollectionBookingWorkerWise
    Public objReport As New cls_Reports
    Public rep_date As Date = Nothing
    Dim ct As SeriesChartType = SeriesChartType.Column


    Private Sub frmWeekCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frmNewHome01.Show()
        TopMost = IsAllTopMostForm
        rep_date = Today
        TabControl1.TabPages(1).Hide()
        refresh_data()
    End Sub
    Sub refresh_data()
        Try
            Dim c As New ChartArea
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add(c)
            Dim dtI As DataTable = objReport.BookingTotalInWeek_WORKERWISE(rep_date)
            Chart1.Series.Clear()
            For Each dr In dtI.Rows
                Dim s As Series = Nothing
                Try
                    s = Chart1.Series(dr("WorkerID").ToString)
                Catch ex As Exception
                End Try
                If s Is Nothing Then
                    s = New Series
                    If ct = SeriesChartType.Line Then
                        s.Points.AddXY(0, 0)
                    End If
                    s.ChartType = ct
                    s.Name = dr("WorkerID")
                    Try
                        s.LegendText = dr("WorkerName")
                    Catch ex As Exception
                    End Try
                    s.IsValueShownAsLabel = True
                    Chart1.Series.Add(s)
                End If
                s.Points.AddXY(dr("Time_T"), dr("Grand_T")) 
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        rep_date = Today.AddDays(-7 * TabControl2.SelectedIndex)
        refresh_data()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                ct = SeriesChartType.Column
            Case 1
                ct = SeriesChartType.Line 
        End Select
        refresh_data()
    End Sub
End Class