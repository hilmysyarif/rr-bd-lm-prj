Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmWeekCollectionBooking
    Public objReport As New cls_Reports
    Public rep_date As Date = Nothing
    Dim ct As SeriesChartType = SeriesChartType.Column


    Private Sub frmWeekCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frmNewHome01.Show()
        TopMost = IsAllTopMostForm
        rep_date = Today
        refresh_data()
    End Sub
    Sub refresh_data()
        Try
            Dim c As New ChartArea
            Chart1.ChartAreas.Clear() 
            Chart1.ChartAreas.Add(c) 
            Dim dtI As DataTable = objReport.BookingTotalInWeek(rep_date)

            Select Case ct
                Case SeriesChartType.Line
                    Dim s As New Series
                    s.ChartType = ct
                    s.Name = "Weekly Data"
                    s.IsValueShownAsLabel = True
                    Chart1.Series.Clear()
                    s.Points.AddXY(0, 0)
                    For Each dr In dtI.Rows
                        s.Points.AddXY(dr("Time_T"), dr("Grand_T"))
                    Next
                    Chart1.Series.Add(s)
                Case SeriesChartType.Column
                    Dim s As New Series
                    s.ChartType = ct
                    s.Name = "Weekly Data"
                    s.IsValueShownAsLabel = True
                    Chart1.Series.Clear()
                    For Each dr In dtI.Rows
                        s.Points.AddXY(dr("Time_T"), dr("Grand_T"))
                    Next
                    Chart1.Series.Add(s)
                Case SeriesChartType.Pie
                
                    Dim s As New Series
                    s.ChartType = ct
                    s.Name = "Weekly Data"
                    s.IsValueShownAsLabel = True
                    Chart1.Series.Clear()
                    For Each dr In dtI.Rows
                        's.Points.Add(New DataPoint(1, Val(lounge)) With {.Label = "Lounge" & vbNewLine & "" & currency & "" & Val(lounge).ToString("0.00"), .LegendText = "Lounge"})
                        's.Points.AddXY(dr("Time_T") & vbNewLine & "" & currency & "" & dr("Grand_T").ToString("0.00"), dr("Grand_T"))
                        s.Points.AddXY(dr("Time_T"), dr("Grand_T"))
                    Next
                    Chart1.Series.Add(s)
            End Select


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
                ct = SeriesChartType.Pie
            Case 2
                ct = SeriesChartType.Line
        End Select

        refresh_data()
    End Sub
End Class