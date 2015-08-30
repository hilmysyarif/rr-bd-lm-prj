Public Class frmPreviousBookings
    ' Public objActiveWorkers As New cls_tblActiveWorker
    Private Sub LoadWorkersInDG(ByVal dg As DataGridView)

        dg.Rows.Clear()

        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlDataAdapter("", conn)

        SELECTSTRING = " AND a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and (a.[Status]<>'' AND a.[Status]<>'STARTED') and a.[room] not in (" & RoomVisibleQuerySelection & ") Order by a.BookingID,DateAdd(Minute,c.serv1,a.starttime) desc"
        ' da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
        da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = DateTimePicker1.Value
        da.SelectCommand.Parameters.Add("@Date3", SqlDbType.DateTime).Value = DateTimePicker2.Value
  
        Dim newQuery As String = <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                   
                    SELECT 
                       a.[SL],
                       a.[WorkerID],
                       b.[WorkerName],
                       a.[WorkerID],
                       a.[workingdate],
                       a.[room],
                       c.serv1 as [service],
                       a.[starttime], 
                       a.[Status],
                       a.[BookingId],
                       c.[st]
                   FROM 
                   (
                       [tblActiveWorker] a 
                   LEFT OUTER JOIN 
                       [tblWorkers] b on a.workerid= b.workerid
                   )
                   LEFT OUTER JOIN 
                        (select sum(Service) as [serv1],workerid as wi,max(servicetype) as st,bookingid as bi  from [tblExtraService] group by workerid,bookingid)  c  on a.workerid= c.wi and a.bookingid = c.bi
                   Where a.BookingId in (Select BookingId from tblBookingStatus)   

    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value + SELECTSTRING
        da.SelectCommand.CommandText = newQuery
    Dim dt As New DataTable
        da.Fill(dt)
    Dim addedRowConter As Integer = 0
    Dim LastBookingID As Integer = 0
        'Dim objBooking As New cls_Temp_tblBookings


        For i = 0 To dt.Rows.Count - 1
    Dim drItem As System.Data.DataRow = dt.Rows(i)
            If LastBookingID <> drItem("BookingID") Then

                LastBookingID = drItem("BookingID")
    Dim l As Integer = 0
                Try
                    l = Val(drItem("Service")) - (Now - CDate(drItem("starttime"))).TotalMinutes
                Catch ex As Exception
                End Try
                dg.Rows.Add(drItem("WorkerID"), _
                                    drItem("WorkerName") + "(" + drItem("Service").ToString + "/" + drItem("Service").ToString & IIf(MySettings.SpecialServiceEnabled, " " & drItem("ST").ToString.Substring(0, 1).ToUpper, "") + ")", _
                                    drItem("Room"), _
                                    drItem("Service").ToString + " Mins", _
                                    drItem("status"), _
                                    drItem("starttime").ToString, _
                                    drItem("sl"), _
                                    drItem("status"), _
                                    "SHOW", drItem("BookingID"))
                dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Black
                dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                addedRowConter = dg.RowCount
                dg.Rows(dg.Rows.Count - 1).Height = 40

            Else

                dg.Rows(addedRowConter - 1).Cells(0).Value = dg.Rows(addedRowConter - 1).Cells(0).Value.ToString & "," & drItem("WorkerID").ToString
                dg.Rows(addedRowConter - 1).Cells(1).Value = dg.Rows(addedRowConter - 1).Cells(1).Value.ToString & vbNewLine & drItem("WorkerName").ToString + "(" + drItem("Service").ToString + "/" + drItem("Service").ToString & IIf(MySettings.SpecialServiceEnabled, " " & drItem("ST").ToString.Substring(0, 1).ToUpper, "") + ")"
                dg.Rows(addedRowConter - 1).Cells(5).Value = dg.Rows(addedRowConter - 1).Cells(5).Value.ToString & vbNewLine & drItem("starttime").ToString
                dg.Rows(addedRowConter - 1).Cells(6).Value = dg.Rows(addedRowConter - 1).Cells(6).Value.ToString & "," & drItem("sl").ToString
                dg.Rows(dg.Rows.Count - 1).Height += 15

            End If

        Next
    'If e.RowIndex >= 0 Then
    '    If e.ColumnIndex = 1 Then
    '        clsDocketPrint.ShowDocketMemo(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
    '    End If
    '    If e.ColumnIndex = 0 Then
    '        clsDocketPrint.PrintDocketMemo(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
    '    End If
    'End If
        Try
            da.Dispose()
            dt.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmPreviousBookings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        If Now.Hour > 9 Then
            DateTimePicker1.Value = Today.AddHours(9)
            DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
            DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If

        LoadWorkersInDG(dgActiveBooking)
    End Sub
    Private Sub dgActiveBooking_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgActiveBooking.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 8 Then
                Dim BookingID As String = dgActiveBooking.Rows(e.RowIndex).Cells(9).Value
                clsDocketPrint.ShowBookingNo(BookingID)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadWorkersInDG(dgActiveBooking)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class