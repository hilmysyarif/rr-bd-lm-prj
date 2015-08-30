Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmWeekCollectionDoorCharge
    Public objInstant As New cls_tblInstant
    'Public objBooking As New cls_tblBookings
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


            Dim d1 As Date = rep_date.Date.AddDays(0 - rep_date.DayOfWeek).AddHours(9)
            Dim d2 As Date = rep_date.Date.AddDays(7 - rep_date.DayOfWeek).AddHours(8).AddMinutes(59).AddSeconds(59)

            Dim pp As New List(Of SQLParameter)
            pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
            pp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
            Dim dtI As DataTable = objInstant.Selection("a.[InstantDate] Between @d1 and @d2", pp)

            'Dim pp1 As New List(Of SQLParameter)
            'pp1.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
            'pp1.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d2})
            'Dim dtA As DataTable = objBooking.Selection(cls_tblBookings.SelectionType.ALL, "a.[BookingDate] Between @d1 and @d2", pp1)

            Dim lounge As Double = 0
            Dim Private1 As Double = 0
            Dim PrivateIntro As Double = 0
            For Each dr As DataRow In dtI.Rows
                If dr("DoorName") = "LOUNGE" Then
                    lounge += dr("TotalAmount")
                ElseIf dr("DoorName") = "PRIVATE" Then
                    Private1 += dr("TotalAmount")
                ElseIf dr("DoorName") = "PRIVATE INTRO" Then
                    PrivateIntro += dr("TotalAmount")
                End If
            Next

            'For Each dr As DataRow In dtA.Rows
            '    If dr("DoorName") = "LOUNGE" Then
            '        lounge += dr("DoorCharge")
            '    ElseIf dr("DoorName") = "PRIVATE" Then
            '        Private1 += dr("DoorCharge")
            '    End If
            'Next

            Select Case ct
                Case SeriesChartType.Line
                    Dim s As New Series
                    s.ChartType = ct
                    s.IsValueShownAsLabel = False
                    s.Name = "Lounge"
                    s.Points.Add(New DataPoint(0, 0)) 'With {.Label = "Lounge" & vbNewLine & "" & currency & "" & Val(lounge).ToString("0.00"), .LegendText = "Lounge"}
                    s.Points.Add(New DataPoint(1, Val(lounge)) With {.Label = "Lounge" & vbNewLine & "" & currency & "" & Val(lounge).ToString("0.00"), .LegendText = "Lounge"})

                    Dim s1 As New Series
                    s1.ChartType = ct
                    s1.IsValueShownAsLabel = False
                    s1.Name = "Private"
                    s1.Points.Add(New DataPoint(0, 0)) 'With {.Label = "Private" & vbNewLine & "" & currency & "" & Val(Private1).ToString("0.00"), .LegendText = "Private"}
                    s1.Points.Add(New DataPoint(1, Val(Private1)) With {.Label = "Private" & vbNewLine & "" & currency & "" & Val(Private1).ToString("0.00"), .LegendText = "Private"})


                    Dim s2 As New Series
                    s2.ChartType = ct
                    s2.IsValueShownAsLabel = False
                    s2.Name = "Private Intro"
                    s2.Points.Add(New DataPoint(0, 0)) 'With {.Label = "Private" & vbNewLine & "" & currency & "" & Val(Private1).ToString("0.00"), .LegendText = "Private"}
                    s2.Points.Add(New DataPoint(1, Val(PrivateIntro)) With {.Label = "Private Intro" & vbNewLine & "" & currency & "" & Val(PrivateIntro).ToString("0.00"), .LegendText = "Private Intro"})


                    Chart1.Series.Clear()
                    Chart1.Series.Add(s)
                    Chart1.Series.Add(s1)
                    Chart1.Series.Add(s2)
                Case SeriesChartType.Column
                    Dim s As New Series
                    s.ChartType = ct
                    s.IsValueShownAsLabel = False
                    s.Name = "Lounge"
                    s.Points.AddXY(TabControl2.SelectedTab.Text, Val(lounge))

                    Dim s1 As New Series
                    s1.ChartType = ct
                    s1.IsValueShownAsLabel = False
                    s1.Name = "Private"
                    s1.Points.AddXY(TabControl2.SelectedTab.Text, Val(Private1))




                    Dim s2 As New Series
                    s2.ChartType = ct
                    s2.IsValueShownAsLabel = False
                    s2.Name = "Private Intro"
                    s2.Points.AddXY(TabControl2.SelectedTab.Text, Val(PrivateIntro))

                    Chart1.Series.Clear()
                    Chart1.Series.Add(s)
                    Chart1.Series.Add(s1)
                    Chart1.Series.Add(s2)
                Case SeriesChartType.Pie
                    Dim s As New Series
                    s.ChartType = ct
                    s.IsValueShownAsLabel = False
                    s.Name = "Door charge"
                    s.Points.Add(New DataPoint(1, Val(lounge)) With {.Label = "Lounge" & vbNewLine & "" & currency & "" & Val(lounge).ToString("0.00"), .LegendText = "Lounge"})
                    s.Points.Add(New DataPoint(2, Val(Private1)) With {.Label = "Private" & vbNewLine & "" & currency & "" & Val(Private1).ToString("0.00"), .LegendText = "Private"})
                    s.Points.Add(New DataPoint(3, Val(PrivateIntro)) With {.Label = "Private Intro" & vbNewLine & "" & currency & "" & Val(PrivateIntro).ToString("0.00"), .LegendText = "Private Intro"})
                    Chart1.Series.Clear()
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