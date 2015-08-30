Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmWeekCollectionBookingSplit
    Public objReport As New cls_Reports
    Public rep_date As Date = Nothing
    Dim ct As SeriesChartType = SeriesChartType.Column


    Private Sub frmWeekCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim dtI As DataTable = objReport.BookingTotalInWeek_SPLIT(rep_date)
            Chart1.Series.Clear()

            Dim s1 As New Series

            s1.ChartType = ct
            s1.Name = "SP"
            s1.IsValueShownAsLabel = True
            Chart1.Series.Add(s1)

            Dim s2 As New Series

            s2.ChartType = ct
            s2.Name = "House"
            s2.IsValueShownAsLabel = True
            Chart1.Series.Add(s2)

            For Each dr In dtI.Rows
                s1.Points.AddXY(dr("Time_T"), dr("sp"))
                s2.Points.AddXY(dr("Time_T"), dr("house"))
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