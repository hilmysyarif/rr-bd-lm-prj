Public Class dlgPreBookingEditMenu
    Public BookingID As Integer = 0
    Dim objBooking As New cls_Temp_tblBookings
    Private Sub btnGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
        Close()

    End Sub

    Private Sub frmPreBookingEditMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub btnConfirmClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmClient.Click
        objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Client_status, "CONFIRMED", "[BookingID]=" & BookingID)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnConfirmSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmSP.Click
        objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Worker_status, "CONFIRMED", "[BookingID]=" & BookingID)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnReschedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReschedule.Click
        Dim frm As New frmSelectBookingDate
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Scheduledate, frm.bookingdate, "[BookingID]=" & BookingID)
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Client_status, "", "[BookingID]=" & BookingID)
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Worker_status, "CONTACT WORKER", "[BookingID]=" & BookingID)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If

    End Sub

    Private Sub btnChangeSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSP.Click
        Dim frm As New frmSelectSP
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.WorkerID, frm.WorkerID, "[BookingID]=" & BookingID)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btnDeleteCancelBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCancelBooking.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            objBooking.Delete_By_RowID(BookingID)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btnStartBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartBooking.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub
End Class