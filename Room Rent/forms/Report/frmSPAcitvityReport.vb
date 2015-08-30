Public Class frmSPAcitvityReport
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim MyQuery As String = <QUERY><![CDATA[

Select 

a.[WorkerID],
a.[WorkerName],
b.[TimesServed],
(select count(bookingid) from tblActiveWorker where  BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[workingdate] between @D1 and @D2 and workerid = a.[WorkerId] ) as [NoOfBookings],

( select count(wd) from 
(select distinct (convert(varchar, workingdate,103)) as [wd] , workerid  from tblActiveWorker where  BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[workingdate] between @D1 and @D2 ) as  xc where xc.workerid = a.[WorkerId]) as [ActiveDays]



 from tblWorkers  a

Left outer Join

( Select 
WorkerId, 
Sum(Service) as [TimesServed] ,
count(BookingID ) as [NoOfBookings]
from tblExtraService 
where BookingId in (Select BookingId from tblBookingStatus where [Status]='CLEAR') 
and 
[CreatedDate] between @D1 and @D2
Group By WorkerId) b


on a.workerid = b.workerid 

where b.[TimesServed]>0


                ]]></QUERY>.Value

            Dim lst As New List(Of SQLParameter)
            lst.Add(New SqlParameter("@D1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
            lst.Add(New SqlParameter("@D2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})

            DataGridView1.DataSource = ExecuteAdapter(MyQuery, lst)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub frmWorkerAcitvityReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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