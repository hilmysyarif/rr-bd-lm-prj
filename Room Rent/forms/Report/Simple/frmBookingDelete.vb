Public Class frmBookingDelete
    Dim TotalBookingDeleted As Integer = 0
    Public dtpFrom As Date
    Public dtpTo As Date
    Dim objBooking As New cls_Temp_tblBookings

    Private Sub frmBookingDelete_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TotalBookingDeleted > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmBookingDelete_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadNotDeleted()
        'LoadDeleted()
    End Sub

    Sub LoadNotDeleted()
        Try
            Dim ppp As New List(Of SqlParameter)
            ppp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = dtpFrom.Date})
            ppp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = dtpTo.Date.AddDays(1).AddSeconds(-1)})
            ' dgNotDeleted.DataSource = objBooking.Selection(cls_tblBookings.SelectionType.REPORT, "Status <> '' and BookingType='BOOKING' AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1) and BookingDate Between @d1 and @d2 Order by BookingDate", ppp)
            dgNotDeleted.DataSource = objBooking.Selection(cls_Temp_tblBookings.SelectionType.REPORT_With_TotalFigures, "c.Cash> 0 and a.Status <> '' and BookingType='BOOKING' AND BookingDate Between @d1 and @d2 Order by BookingDate", ppp)

            'DataGridView1.Columns("BookingID").HeaderText = "BookingID"
            dgNotDeleted.Columns("BookingID").Visible = False

            dgNotDeleted.Columns("ServiceProvider").HeaderText = "Starting SP"
            dgNotDeleted.Columns("ServiceProvider").Visible = True

            dgNotDeleted.Columns("Room").HeaderText = "Room"
            dgNotDeleted.Columns("Room").Visible = True

            'DataGridView1.Columns("RoomCharge").HeaderText = "RoomCharge"
            'DataGridView1.Columns("RoomCharge").Visible = False

            dgNotDeleted.Columns("Service").HeaderText = "Starting Service"
            dgNotDeleted.Columns("Service").Visible = True
            dgNotDeleted.Columns("Service").DefaultCellStyle.Format = "00 Mins"


            dgNotDeleted.Columns("BookingDate").HeaderText = "BookingDate"
            dgNotDeleted.Columns("BookingDate").Visible = True
            dgNotDeleted.Columns("BookingDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

            dgNotDeleted.Columns("Scheduledate").HeaderText = "Scheduledate"
            dgNotDeleted.Columns("Scheduledate").Visible = False

            dgNotDeleted.Columns("BookingType").HeaderText = "BookingType"
            dgNotDeleted.Columns("BookingType").Visible = False

            'DataGridView1.Columns("TotalAmount").HeaderText = "TotalAmount"
            'DataGridView1.Columns("TotalAmount").Visible = False

            dgNotDeleted.Columns("Status").HeaderText = "Status"
            'dgNotDeleted.Columns("Status").Visible = False

            dgNotDeleted.Columns("WorkerID").HeaderText = "WorkerID"
            dgNotDeleted.Columns("WorkerID").Visible = False

            dgNotDeleted.Columns("CustomerName").HeaderText = "Customer Name"
            dgNotDeleted.Columns("CustomerName").Visible = True

            dgNotDeleted.Columns("Phone").HeaderText = "Phone"
            dgNotDeleted.Columns("Phone").Visible = False

            dgNotDeleted.Columns("MobileNo").HeaderText = "MobileNo"
            dgNotDeleted.Columns("MobileNo").Visible = False

            dgNotDeleted.Columns("Worker_status").HeaderText = "Worker_status"
            dgNotDeleted.Columns("Worker_status").Visible = False

            dgNotDeleted.Columns("Client_status").HeaderText = "Client_status"
            dgNotDeleted.Columns("Client_status").Visible = False

            dgNotDeleted.Columns("MemberId").HeaderText = "Member Id"
            dgNotDeleted.Columns("MemberId").Visible = True

            dgNotDeleted.Columns("MemoNo").HeaderText = "MemoNo"
            dgNotDeleted.Columns("MemoNo").Visible = False
            dgNotDeleted.Columns("ExcludeFromReport").Visible = False

            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").Visible = True

            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").Visible = True

            For Each dr As DataGridViewRow In dgNotDeleted.Rows
                If dr.Cells("ExcludeFromReport").Value Is DBNull.Value OrElse dr.Cells("ExcludeFromReport").Value = False Then
                    dr.Cells(0).Value = "Delete"
                Else
                    dr.Cells(0).Value = "Un-Delete"
                    dr.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    'Sub LoadDeleted()
    '    Try
    '        Dim ppp As New List(Of SqlParameter)
    '        ppp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = dtpFrom.Date})
    '        ppp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = dtpTo.Date.AddDays(1).AddSeconds(-1)})
    '        dgDeleted.DataSource = objBooking.Selection(cls_tblBookings.SelectionType.REPORT, "a.Status <> '' and BookingType='BOOKING' AND BookingId in (select BookingId from tblBookings where ExcludeFromReport=1) and BookingDate Between @d1 and @d2 Order by BookingDate", ppp)

    '        'DataGridView1.Columns("BookingID").HeaderText = "BookingID"
    '        dgDeleted.Columns("BookingID").Visible = False

    '        dgDeleted.Columns("ServiceProvider").HeaderText = "Starting SP"
    '        dgDeleted.Columns("ServiceProvider").Visible = True

    '        dgDeleted.Columns("Room").HeaderText = "Room"
    '        dgDeleted.Columns("Room").Visible = True

    '        'DataGridView1.Columns("RoomCharge").HeaderText = "RoomCharge"
    '        'DataGridView1.Columns("RoomCharge").Visible = False

    '        dgDeleted.Columns("Service").HeaderText = "Starting Service"
    '        dgDeleted.Columns("Service").Visible = True
    '        dgDeleted.Columns("Service").DefaultCellStyle.Format = "00 Mins"


    '        dgDeleted.Columns("BookingDate").HeaderText = "BookingDate"
    '        dgDeleted.Columns("BookingDate").Visible = True
    '        dgDeleted.Columns("BookingDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

    '        dgDeleted.Columns("Scheduledate").HeaderText = "Scheduledate"
    '        dgDeleted.Columns("Scheduledate").Visible = False

    '        dgDeleted.Columns("BookingType").HeaderText = "BookingType"
    '        dgDeleted.Columns("BookingType").Visible = False

    '        'DataGridView1.Columns("TotalAmount").HeaderText = "TotalAmount"
    '        'DataGridView1.Columns("TotalAmount").Visible = False

    '        dgDeleted.Columns("Status").HeaderText = "Status"
    '        'dgDeleted.Columns("Status").Visible = False

    '        dgDeleted.Columns("WorkerID").HeaderText = "WorkerID"
    '        dgDeleted.Columns("WorkerID").Visible = False

    '        dgDeleted.Columns("CustomerName").HeaderText = "Customer Name"
    '        dgDeleted.Columns("CustomerName").Visible = True

    '        dgDeleted.Columns("Phone").HeaderText = "Phone"
    '        dgDeleted.Columns("Phone").Visible = False

    '        dgDeleted.Columns("MobileNo").HeaderText = "MobileNo"
    '        dgDeleted.Columns("MobileNo").Visible = False

    '        dgDeleted.Columns("Worker_status").HeaderText = "Worker_status"
    '        dgDeleted.Columns("Worker_status").Visible = False

    '        dgDeleted.Columns("Client_status").HeaderText = "Client_status"
    '        dgDeleted.Columns("Client_status").Visible = False

    '        dgDeleted.Columns("MemberId").HeaderText = "Member Id"
    '        dgDeleted.Columns("MemberId").Visible = True

    '        dgDeleted.Columns("MemoNo").HeaderText = "MemoNo"
    '        dgDeleted.Columns("MemoNo").Visible = False
    '        dgDeleted.Columns("ExcludeFromReport").Visible = False

    '        'DataGridView1.Columns("").HeaderText = ""
    '        'DataGridView1.Columns("").Visible = True

    '        'DataGridView1.Columns("").HeaderText = ""
    '        'DataGridView1.Columns("").Visible = True

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
    '    End Try
    'End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Close()
    End Sub

    Private Sub dgNotDeleted_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgNotDeleted.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Try
                    objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.ExcludeFromReport, IIf(dgNotDeleted.Rows(e.RowIndex).Cells(0).Value = "Delete", 1, 0), "[BookingID]=" & dgNotDeleted.Rows(e.RowIndex).Cells(1).Value)
                    'LoadNotDeleted()
                    dgNotDeleted.Rows(e.RowIndex).Cells("ExcludeFromReport").Value = IIf(dgNotDeleted.Rows(e.RowIndex).Cells(0).Value = "Delete", 1, 0)
                    If dgNotDeleted.Rows(e.RowIndex).Cells("ExcludeFromReport").Value = False Then
                        dgNotDeleted.Rows(e.RowIndex).Cells(0).Value = "Delete"
                        dgNotDeleted.Rows(e.RowIndex).DefaultCellStyle.BackColor = Nothing
                    Else
                        dgNotDeleted.Rows(e.RowIndex).Cells(0).Value = "Un-Delete"
                        dgNotDeleted.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    End If
                    'LoadDeleted()
                    TotalBookingDeleted += 1
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    'Private Sub dgDeleted_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 Then
    '        If e.ColumnIndex = 0 Then
    '            Try
    '                objBooking.UpdateField(cls_tblBookings.tblBookings_FIELDS.ExcludeFromReport, 0, dgDeleted.Rows(e.RowIndex).Cells(1).Value)
    '                LoadNotDeleted()
    '                LoadDeleted()
    '                TotalBookingDeleted += 1
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    'End Sub
End Class