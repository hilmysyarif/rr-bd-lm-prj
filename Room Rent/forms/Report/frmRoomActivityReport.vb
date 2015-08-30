Public Class frmRoomActivityReport
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim MyQuery_tmp As String = <QUERY><![CDATA[

Select 

a.[WorkerID],
a.[WorkerName],
b.[TimesServed],

(select count(bookingid) from tblActiveWorker where  BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[workingdate] between @D1 and @D2 and workerid = a.[WorkerId] ) as [NoOfBookings],

( select count(wd) from 
(select distinct (format(workingdate,'dd/MM/yyyy')) as [wd] , workerid  from tblActiveWorker where  BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[workingdate] between @D1 and @D2 ) as  xc where xc.workerid = a.[WorkerId]) as [ActiveDays]

 from tblWorkers  a

Left outer Join

( Select 
WorkerId, 
Sum(Service) as [TimesServed] 
from tblExtraService 
where BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[CreatedDate] between @D1 and @D2
Group By WorkerId) b


on a.workerid = b.workerid 

where b.[TimesServed]>0


                ]]></QUERY>.Value
            Dim MyQuery As String = <QUERY><![CDATA[

Select 

a.[Room],
a.[FullName],
b.[TimeUsed],
b.[NoOfBookings]

 from ( select [Room],[FullName] from tblRoom union all (select 'ESCORT','ESCORT')  )  a

Left outer Join


( Select a1.room, sum(isnull(b1.[TimeUsed],0)) as [TimeUsed],count(a1.bookingid) as [NoOfBookings] from tblBookings a1
left outer join
( Select 
BookingId, 
Sum(Service) as [TimeUsed]
from tblExtraService 
Group By BookingId) b1 on a1.bookingid = b1.bookingid

where 
a1.BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and a1.[BookingDate] between @D1 and @D2

group by a1.room
) b


on a.room = b.room 

 


                ]]></QUERY>.Value

            Dim lst As New List(Of SQLParameter)
            lst.Add(New SqlParameter("@D1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
            lst.Add(New SqlParameter("@D2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})

            DataGridView1.DataSource = ExecuteAdapter(MyQuery, lst)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub frmRoomActivityReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        If Now.Hour > 9 Then
            DateTimePicker1.Value = Today.AddHours(9)
            DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
            DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If
    End Sub
End Class