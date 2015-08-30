Public Class frmHome
    Inherits frmMainMaster

    Private Sub frmHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadings()
    End Sub

    Sub Loadings()
        LoadServiceProvider(lstServiceProvider)
        LoadServiceProvider(lstQueuedProvider, BookingType.QUEUE)
        LoadServiceProvider(lstActiveProvider, BookingType.ACTIVE)
        LoadBookings(dgQueuedBooking, BookingType.QUEUE)
        tmrTimeLeftCounter.Start()
    End Sub

    Private Sub btnBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBooking.Click
        frmBookingHome.Show()
        frmBookingHome.Activate()
    End Sub

    Private Sub tmrTimeLeftCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeLeftCounter.Tick
        If dgQueuedBooking.Rows.Count > 0 Then
            For Each dgRow As DataGridViewRow In dgQueuedBooking.Rows
                If dgRow.Cells(8).Value = "ACTIVE" Then
                    Dim addtime As Date = dgRow.Cells(4).Value
                    Dim duration As Integer = Val(dgRow.Cells(2).Value)
                    dgRow.Cells(3).Value = Math.Floor((duration - (Now - addtime).TotalMinutes)).ToString + " Mins"
                End If
            Next
        End If
    End Sub

    Private Sub frmBooking_closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Loadings()
    End Sub

    Private Sub btnCheckIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIn.Click
        frmCheckIn.Show()
        frmCheckIn.Activate()
    End Sub

    Private Sub btnMerchandise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerchandise.Click
        frmMerchandise.Show()
        frmMerchandise.Activate()
    End Sub
End Class