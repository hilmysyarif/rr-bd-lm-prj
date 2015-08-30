Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmDoorChargeChart
    Public objInstant As New cls_tblInstant
    'Public objBooking As New cls_tblBookings
    Public rep_date As Date = Nothing


    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        Try
            Dim s As New Series
            Dim c As New ChartArea
            Chart1.ChartAreas.Add(c)
            s.ChartType = SeriesChartType.Pie
            s.IsValueShownAsLabel = True


            Dim pp As New List(Of SQLParameter)
            pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = rep_date})
            pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = rep_date.AddDays(1)})
            Dim dtI As DataTable = objInstant.Selection("a.[InstantDate] Between @d1 and @d2", pp)

            'Dim pp1 As New List(Of SQLParameter)
            'pp1.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = rep_date})
            'pp1.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = rep_date.AddDays(1)})
            'Dim dtA As DataTable = objBooking.Selection(cls_tblBookings.SelectionType.ALL, "a.[BookingDate] Between @d1 and @d2", pp1)

            Dim lounge As Double = 0
            Dim Private1 As Double = 0
            For Each dr As DataRow In dtI.Rows
                If dr("DoorName") = "LOUNGE" Then
                    lounge += dr("TotalAmount")
                ElseIf dr("DoorName") = "PRIVATE" Then
                    Private1 += dr("TotalAmount")
                End If
            Next

            'For Each dr As DataRow In dtA.Rows
            '    If dr("DoorName") = "LOUNGE" Then
            '        lounge += dr("DoorCharge")
            '    ElseIf dr("DoorName") = "PRIVATE" Then
            '        Private1 += dr("DoorCharge")
            '    End If
            'Next

            s.Points.Add(New DataPoint(1, Val(lounge)) With {.Label = "Lounge" & vbNewLine & "" & currency & "" & Val(lounge).ToString("0.00"), .LegendText = "Lounge"})
            s.Points.Add(New DataPoint(2, Val(Private1)) With {.Label = "Private" & vbNewLine & "" & currency & "" & Val(Private1).ToString("0.00"), .LegendText = "Private"})

            Chart1.Series.Add(s)
        Catch ex As Exception

        End Try



    End Sub

  
End Class