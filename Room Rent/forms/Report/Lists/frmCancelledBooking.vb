Public Class frmCancelledBooking
    Dim objBooking As New cls_Temp_tblBookings

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            Dim ppp As New List(Of SQLParameter)
            ppp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = dtpFrom.Value.Date})
            ppp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = dtpTo.Value.Date.AddDays(1).AddSeconds(-1)})
            DataGridView1.DataSource = objBooking.Selection(cls_Temp_tblBookings.SelectionType.REPORT, "BookingID in (Select BookingID From tblBookingStatus Where Status='CANCEL') and BookingDate Between @d1 and @d2 Order by BookingDate", ppp)
            

            'DataGridView1.Columns("BookingID").HeaderText = "BookingID"
            DataGridView1.Columns("BookingID").Visible = False

            DataGridView1.Columns("ServiceProvider").HeaderText = "Starting SP"
            DataGridView1.Columns("ServiceProvider").Visible = True

            DataGridView1.Columns("Room").HeaderText = "Room"
            DataGridView1.Columns("Room").Visible = True

            'DataGridView1.Columns("RoomCharge").HeaderText = "RoomCharge"
            'DataGridView1.Columns("RoomCharge").Visible = False

            DataGridView1.Columns("Service").HeaderText = "Starting Service"
            DataGridView1.Columns("Service").Visible = True
            DataGridView1.Columns("Service").DefaultCellStyle.Format = "00 Mins"


            DataGridView1.Columns("BookingDate").HeaderText = "BookingDate"
            DataGridView1.Columns("BookingDate").Visible = True
            DataGridView1.Columns("BookingDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

            DataGridView1.Columns("Scheduledate").HeaderText = "Scheduledate"
            DataGridView1.Columns("Scheduledate").Visible = False

            DataGridView1.Columns("BookingType").HeaderText = "BookingType"
            DataGridView1.Columns("BookingType").Visible = False

            'DataGridView1.Columns("TotalAmount").HeaderText = "TotalAmount"
            'DataGridView1.Columns("TotalAmount").Visible = False

            DataGridView1.Columns("Status").HeaderText = "Status"
            DataGridView1.Columns("Status").Visible = False

            DataGridView1.Columns("WorkerID").HeaderText = "WorkerID"
            DataGridView1.Columns("WorkerID").Visible = False

            DataGridView1.Columns("CustomerName").HeaderText = "Customer Name"
            DataGridView1.Columns("CustomerName").Visible = True

            DataGridView1.Columns("Phone").HeaderText = "Phone"
            DataGridView1.Columns("Phone").Visible = False

            DataGridView1.Columns("MobileNo").HeaderText = "MobileNo"
            DataGridView1.Columns("MobileNo").Visible = False

            DataGridView1.Columns("Worker_status").HeaderText = "Worker_status"
            DataGridView1.Columns("Worker_status").Visible = False

            DataGridView1.Columns("Client_status").HeaderText = "Client_status"
            DataGridView1.Columns("Client_status").Visible = False

            DataGridView1.Columns("MemberId").HeaderText = "Member Id"
            DataGridView1.Columns("MemberId").Visible = True

            DataGridView1.Columns("MemoNo").HeaderText = "MemoNo"
            DataGridView1.Columns("MemoNo").Visible = False

            'DataGridView1.Columns("").HeaderText = ""
            DataGridView1.Columns("ExcludeFromReport").Visible = False

            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").Visible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmCancelledBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm

    End Sub
End Class