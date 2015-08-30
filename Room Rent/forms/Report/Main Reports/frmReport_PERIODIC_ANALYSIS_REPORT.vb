Public Class frmReport_PERIODIC_ANALYSIS_REPORT

    Dim objBooking As New cls_Temp_tblBookings
    ' Dim objBPayment As New cls_Temp_tblBookingPayments
    Dim ll2 As Integer = 205
    Function TotalField(ByVal dt As DataTable, ByVal fieldName As String) As Double
        Dim total As Double = 0
        For Each dr As DataRow In dt.Rows
            Try
                If Not dr(fieldName) Is DBNull.Value Then
                    total += Val(dr(fieldName))
                End If
            Catch ex As Exception
            End Try

        Next
        Return total
    End Function
    Public Sub ReportLoad()
        Dim test As Int16 = 0
        Dim query As String = <QUERY><![CDATA[
select 

        a.[WorkerID] as [SP Code],
        a.[WorkerName] as [SP Name],
        Isnull(c.[cnt],0) as [Total Bookings],
        Isnull(d1.[cnt],0) as [5 Mins], 
        Isnull(d2.[cnt],0) as [10 Mins], 
        Isnull(d3.[cnt],0) as [15 Mins], 
        Isnull(d4.[cnt],0) as [20 Mins], 
        Isnull(d.[cnt],0) as [30 Mins], 
        Isnull(e.[cnt],0) as [45 Mins],
        Isnull(f.[cnt],0) as [60 Mins],
        Isnull(g.[cnt],0) as [1.5 Hrs],
        Isnull(h.[cnt],0) as [2 Hrs],
        Isnull(i.[cnt],0) as [2.5 Hrs],
        Isnull(j.[cnt],0) as [3 Hrs],
        Isnull(k.[cnt],0) as [3.5 Hrs],
        Isnull(l.[cnt],0) as [4 Hrs],
        Isnull(m.[cnt],0) as [5 Hrs],
        Isnull(m1.[cnt],0) as [6 Hrs],
        0 as [Others],
        Isnull(n.[cnt],0) as [Normal Bookings],
        0 as [Special Bookings],
        Isnull(p.[cnt],0) as [ESCORT Bookings],
        Isnull(o.[cnt],0) as [Extended Bookings],
        Isnull(q.[amt],0) as [Proceeds]


from 
(
(
(
( 
(
(
(
(
(
(
(
(
(
(
(
(
(
(
(
(
tblWorkers a

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblActiveWorker
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2)
group by 
    workerid
) b
 on a.workerid = b.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
group by 
    workerid
) c
 on a.workerid = c.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 5
group by 
    workerid
) d1
 on a.workerid = d1.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 10
group by 
    workerid
) d2
 on a.workerid = d2.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 15
group by 
    workerid
) d3
 on a.workerid = d3.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 20
group by 
    workerid
) d4
 on a.workerid = d4.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 30
group by 
    workerid
) d
 on a.workerid = d.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 45
group by 
    workerid
) e
 on a.workerid = e.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 60
group by 
    workerid
) f
 on a.workerid = f.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 90
group by 
    workerid
) g
 on a.workerid = g.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 120
group by 
    workerid
) h
 on a.workerid = h.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 150
group by 
    workerid
) i
 on a.workerid = i.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 180
group by 
    workerid
) j
 on a.workerid = j.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 210
group by 
    workerid
) k
 on a.workerid = k.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 240
group by 
    workerid
) l
 on a.workerid = l.workerid
) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 300
group by 
    workerid
) m
 on a.workerid = m.workerid

) 

left outer join 

(
select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 360
group by 
    workerid
) m1
 on a.workerid = m1.workerid

) 

left outer join 

(
select workerid, count(bookingid) as [cnt] from tblActiveworker

where 
bookingid in (select bookingid from (select bookingid,count(bookingid) as [cnt] from tblExtraservice  group by bookingid ) a1 where a1.cnt =1)
and bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room<>'ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
group by workerid 
) n
 on a.workerid = n.workerid
) 

left outer join 

(
select workerid, count(bookingid) as [cnt] from tblExtraservice

where 

bookingid in (select bookingid from (select bookingid,count(bookingid) as [cnt] from tblExtraservice  group by bookingid ) a1 where a1.cnt >1)
and bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room<>'ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
group by workerid 
) o
 on a.workerid = o.workerid

) 

left outer join 

(
select workerid, count(bookingid) as [cnt] from tblExtraservice

where 
 bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room='ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
group by workerid 
) p
 on a.workerid = p.workerid
)
left outer join 

(
select workerid, sum(SP_AMOUNT) as [amt] from tblBookingPayments

where 
 bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2) AND (BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING'))
group by workerid 
) q
 on a.workerid = q.workerid
where Isnull(c.[cnt],0) >0 or Isnull(q.[amt],0)>0
]]></QUERY>
        Dim ll As New List(Of SqlParameter)
        ll.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
        ll.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})
        Try
            Dim dt As DataTable = Nothing
            dt = ExecuteAdapter(query, ll)
            Dim qq As String = <SS><![CDATA[

select 
    count(bookingId) as [cnt], workerid
from 
    tblExtraService
where
    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2)
group by 
    workerid
]]></SS>
            'dt = ExecuteAdapter(qq, ll)
            'DataGridView1.DataSource = dt

            Dim listofwidths() As Integer = {8, 15, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10}
            Dim str As String = ""
            str += "".PadLeft(ll2, "-")
            str += vbNewLine
            str = HeaderString(1)

            str += "SP Code".PadRight(listofwidths(0)) & "SP Name".PadRight(listofwidths(1)) & "Total  ".PadLeft(listofwidths(2)) & "5 Mins".PadLeft(listofwidths(3)) & "10 Mins".PadLeft(listofwidths(4)) & "15 Mins".PadLeft(listofwidths(5)) & "20 Mins".PadLeft(listofwidths(6)) & "30 Mins".PadLeft(listofwidths(7)) & "45 Mins".PadLeft(listofwidths(8)) _
                & "60 Mins".PadLeft(listofwidths(9)) & "1.5 Hrs".PadLeft(listofwidths(10)) & "2 Hrs".PadLeft(listofwidths(11)) & "2.5 Hrs".PadLeft(listofwidths(12)) & "3 Hrs".PadLeft(listofwidths(13)) & "3.5 Hrs".PadLeft(listofwidths(14)) & "4 Hrs".PadLeft(listofwidths(15)) & "5 Hrs".PadLeft(listofwidths(16)) & "6 Hrs".PadLeft(listofwidths(17)) _
                & "Others".PadLeft(listofwidths(18)) & "Normal".PadLeft(listofwidths(19)) & "Special ".PadLeft(listofwidths(20)) & "ESCORT ".PadLeft(listofwidths(21)) & "Extended".PadLeft(listofwidths(22)) & " Proceeds".PadLeft(listofwidths(3)) & ""
            str += vbNewLine
            str += " ".PadRight(listofwidths(0)) & " ".PadRight(listofwidths(1)) & "Bookings".PadLeft(listofwidths(2)) & " ".PadLeft(listofwidths(3)) & " ".PadLeft(listofwidths(4)) & " ".PadLeft(listofwidths(5)) & " ".PadLeft(listofwidths(6)) & " ".PadLeft(listofwidths(7)) & " ".PadLeft(listofwidths(8)) _
             & " ".PadLeft(listofwidths(9)) & " ".PadLeft(listofwidths(10)) & " ".PadLeft(listofwidths(11)) & " ".PadLeft(listofwidths(12)) & " ".PadLeft(listofwidths(13)) & " ".PadLeft(listofwidths(14)) & " ".PadLeft(listofwidths(15)) & " ".PadLeft(listofwidths(16)) & " ".PadLeft(listofwidths(17)) _
             & " ".PadLeft(listofwidths(18)) & " ".PadLeft(listofwidths(19)) & "Bookings".PadLeft(listofwidths(20)) & "Bookings".PadLeft(listofwidths(21)) & "Bookings".PadLeft(listofwidths(22)) & " ".PadLeft(listofwidths(23))
            str += vbNewLine
            str += "".PadLeft(ll2, "-")
            str += vbNewLine
            For Each dr As DataRow In dt.Rows
                For Each dc As DataColumn In dt.Columns
                    If dc.Ordinal = 1 Then
                        str += dr(dc.ColumnName).ToString.PadRight(listofwidths(dc.Ordinal))
                    Else
                        str += dr(dc.ColumnName).ToString.PadLeft(listofwidths(dc.Ordinal) - 2) & "  "
                    End If
                Next
                str += vbNewLine
            Next
            str += "".PadLeft(ll2, "-")
            str += vbNewLine


            str += vbNewLine

            str += ("TOTAL".PadRight(15, " .") & " : " & (currency & (TotalField(dt, "Proceeds")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine

            'Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2 ", _
            '                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
            'Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 ", _
            '                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

            'str += ("TOTAL".PadRight(15, " .") & " : " & (currency & (TotalField(dt, "Ball Park Earnings")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
            'str += ("CASH".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
            'str += ("CARD".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
            'str += ("VOUCHER".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
            'str += ("Grand Total".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine

            str += "".PadLeft(ll2, "-")

            str += vbNewLine
            TextBox1.Text = str
            'For i = 2 To DataGridView1.Columns.Count - 1
            '    DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Next
            'DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            'DataGridView1.Columns(1).Width = 200
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub
    Function HeaderString(ByVal PageNo As String) As String
        Dim Str As String = ""

        Str = vbNewLine
        Str += vbNewLine
        Str += vbNewLine

        Str += "DATE : " & Now.ToString("dd/MM/yyyy") & ("Page #" & PageNo).PadLeft(120)

        Str += vbNewLine

        Str += "TIME : " & Now.ToString("hh:mm tt")

        Str += vbNewLine

        Str += ("REVENUE TRANSACTION REPORT").PadLeft(100)

        Str += vbNewLine

        Str += ("").PadLeft(ll2, "=")

        Str += vbNewLine

        Str += "Sequence".PadRight(30) & ("START DATE/TIME").PadRight(30) & ("END DATE/TIME").PadRight(20)

        Str += vbNewLine

        Str += "DATE/TIME".PadRight(30) & (DateTimePicker1.Value.ToString("dd/MM/yyyy hh:mm tt")).PadRight(30) & (DateTimePicker2.Value.ToString("dd/MM/yyyy hh:mm tt")).PadRight(20)
        Str += vbNewLine

        Str += ("").PadLeft(ll2, "-")


        'Str += vbNewLine
        'Str += "".PadRight(30) & "DAY".PadRight(10) & "DATE".PadRight(10) & "TIME".PadRight(10) & "BOOKING".PadRight(15) & "HOUSE".PadRight(10) & "CASH".PadRight(10) & "CARDS".PadRight(10) & "G.S.T".PadRight(10) & "".PadRight(4) & "PAYMENT"
        'Str += vbNewLine
        'Str += "".PadRight(30) & "".PadRight(10) & "".PadRight(10) & "".PadRight(10) & "TYPE".PadRight(15) & "AMT.".PadRight(10) & "AMT.".PadRight(10) & "AMT.".PadRight(10) & "".PadRight(10) & "SC".PadRight(4) & "METHOD"


        Str += vbNewLine

        'Str += ("").PadLeft(160, "-")

        Str += vbNewLine



        Return Str
    End Function


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim obj As New clsReportPrint
        If MyLocalSettings.ReportPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                obj.Printing3(frm.PrinterSettings.PrinterName, New List(Of String) From {TextBox1.Text}, "RPT " & Now.ToString("dd-MM-yy HH:mm"), "Legal")
            End If
        Else
            obj.Printing3(MyLocalSettings.ReportPrinter, New List(Of String) From {TextBox1.Text}, "RPT " & Now.ToString("dd-MM-yy HH:mm"), "Legal")
        End If
    End Sub

    Private Sub frmReport_PERIODIC_ANALYSIS_REPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        'If Now.Hour > 9 Then
        '    DateTimePicker1.Value = Today.AddHours(9)
        '    DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        'Else
        '    DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
        '    DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        'End If
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click
        ReportLoad()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        Select Case ComboBox1.SelectedIndex
            Case 0
                If Now.Hour > 9 Then
                    DateTimePicker1.Value = Today.AddHours(9)
                    DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
                Else
                    DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
                    DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
                End If

            Case 1
                If Now.Hour > 9 Then
                    DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
                    DateTimePicker2.Value = Today.AddDays(-1).AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
                Else
                    DateTimePicker1.Value = Today.AddDays(-1).AddDays(-1).AddHours(9)
                    DateTimePicker2.Value = Today.AddDays(-1).AddHours(8).AddMinutes(59).AddSeconds(59)
                End If
            Case 2
                DateTimePicker1.Value = Today.AddDays(-7).AddHours(9)
                DateTimePicker2.Value = Today.AddDays(-1).AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
            Case 3
                DateTimePicker1.Value = Today.AddDays(-28).AddHours(9)
                DateTimePicker2.Value = Today.AddDays(-1).AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
            Case 4
                If Now.Hour > 9 Then
                    DateTimePicker1.Value = Today.AddHours(9)
                    DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
                Else
                    DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
                    DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
                End If
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
        End Select
        btnReport_Click(Nothing, Nothing)
    End Sub
    '    Public Sub ReportLoad()
    '        Dim test As Int16 = 0
    '        Dim query As String = <QUERY><![CDATA[
    'select 

    '        a.[WorkerID] as [SP Code],
    '        a.[WorkerName] as [SP Name],
    '        Isnull(c.[cnt],0) as [Total Bookings],
    '        Isnull(d.[cnt],0) as [30 Mins], 
    '        Isnull(e.[cnt],0) as [45 Mins],
    '        Isnull(f.[cnt],0) as [60 Mins],
    '        Isnull(g.[cnt],0) as [1.5 Hrs],
    '        Isnull(h.[cnt],0) as [2 Hrs],
    '        Isnull(i.[cnt],0) as [2.5 Hrs],
    '        Isnull(j.[cnt],0) as [3 Hrs],
    '        Isnull(k.[cnt],0) as [3.5 Hrs],
    '        Isnull(l.[cnt],0) as [4 Hrs],
    '        Isnull(m.[cnt],0) as [5 Hrs],
    '        0 as [Others],
    '        Isnull(n.[cnt],0) as [Normal Bookings],
    '        0 as [Special Bookings],
    '        Isnull(p.[cnt],0) as [ESCORT Bookings],
    '        Isnull(o.[cnt],0) as [Extended Bookings],
    '        Isnull(q.[amt],0) as [Proceeds]


    'from 
    '(
    '(
    '(
    '( 
    '(
    '(
    '(
    '(
    '(
    '(
    '(
    '(
    '(
    '(
    '(
    'tblWorkers a

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblActiveWorker
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2)
    'group by 
    '    workerid
    ') b
    ' on a.workerid = b.workerid

    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
    'group by 
    '    workerid
    ') c
    ' on a.workerid = c.workerid

    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 30
    'group by 
    '    workerid
    ') d
    ' on a.workerid = d.workerid

    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 45
    'group by 
    '    workerid
    ') e
    ' on a.workerid = e.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 60
    'group by 
    '    workerid
    ') f
    ' on a.workerid = f.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 90
    'group by 
    '    workerid
    ') g
    ' on a.workerid = g.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 120
    'group by 
    '    workerid
    ') h
    ' on a.workerid = h.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 150
    'group by 
    '    workerid
    ') i
    ' on a.workerid = i.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 180
    'group by 
    '    workerid
    ') j
    ' on a.workerid = j.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 210
    'group by 
    '    workerid
    ') k
    ' on a.workerid = k.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 240
    'group by 
    '    workerid
    ') l
    ' on a.workerid = l.workerid
    ') 

    'left outer join 

    '(
    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL')) and service = 300
    'group by 
    '    workerid
    ') m
    ' on a.workerid = m.workerid

    ') 

    'left outer join 

    '(
    'select workerid, count(bookingid) as [cnt] from tblActiveworker

    'where 
    'bookingid in (select bookingid from (select bookingid,count(bookingid) as [cnt] from tblExtraservice  group by bookingid ) a1 where a1.cnt =1)
    'and bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room<>'ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
    'group by workerid 
    ') n
    ' on a.workerid = n.workerid
    ') 

    'left outer join 

    '(
    'select workerid, count(bookingid) as [cnt] from tblExtraservice

    'where 

    'bookingid in (select bookingid from (select bookingid,count(bookingid) as [cnt] from tblExtraservice  group by bookingid ) a1 where a1.cnt >1)
    'and bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room<>'ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
    'group by workerid 
    ') o
    ' on a.workerid = o.workerid

    ') 

    'left outer join 

    '(
    'select workerid, count(bookingid) as [cnt] from tblExtraservice

    'where 
    ' bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and Room='ESCORT' and BookingDate between @d1 and @d2 AND BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL'))
    'group by workerid 
    ') p
    ' on a.workerid = p.workerid
    ')
    'left outer join 

    '(
    'select workerid, sum(SP_AMOUNT) as [amt] from tblBookingPayments

    'where 
    ' bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2) AND (BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING'))
    'group by workerid 
    ') q
    ' on a.workerid = q.workerid
    'where Isnull(c.[cnt],0) >0 or Isnull(q.[amt],0)>0
    ']]></QUERY>
    '        Dim ll As New List(Of SqlParameter)
    '        ll.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
    '        ll.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})
    '        Try
    '            Dim dt As DataTable = Nothing
    '            dt = ExecuteAdapter(query, ll)
    '            Dim qq As String = <SS><![CDATA[

    'select 
    '    count(bookingId) as [cnt], workerid
    'from 
    '    tblExtraService
    'where
    '    bookingid in (select Bookingid from tblBookings where BookingType='BOOKING' and BookingDate between @d1 and @d2)
    'group by 
    '    workerid
    ']]></SS>
    '            'dt = ExecuteAdapter(qq, ll)
    '            'DataGridView1.DataSource = dt

    '            Dim listofwidths() As Integer = {8, 15, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10}
    '            Dim str As String = ""
    '            str += "".PadLeft(ll2, "-")
    '            str += vbNewLine
    '            str = HeaderString(1)

    '            str += "SP Code".PadRight(listofwidths(0)) & "SP Name".PadRight(listofwidths(1)) & "Total  ".PadLeft(listofwidths(2)) & "30 Mins".PadLeft(listofwidths(3)) & "45 Mins".PadLeft(listofwidths(4)) _
    '                & "60 Mins".PadLeft(listofwidths(5)) & "1.5 Hrs".PadLeft(listofwidths(6)) & "2 Hrs".PadLeft(listofwidths(7)) & "2.5 Hrs".PadLeft(listofwidths(8)) & "3 Hrs".PadLeft(listofwidths(9)) & "3.5 Hrs".PadLeft(listofwidths(10)) & "4 Hrs".PadLeft(listofwidths(11)) & "5 Hrs".PadLeft(listofwidths(12)) _
    '                & "Others".PadLeft(listofwidths(13)) & "Normal".PadLeft(listofwidths(14)) & "Special ".PadLeft(listofwidths(15)) & "ESCORT ".PadLeft(listofwidths(16)) & "Extended".PadLeft(listofwidths(17)) & " Proceeds".PadLeft(listofwidths(18)) & ""
    '            str += vbNewLine
    '            str += " ".PadRight(listofwidths(0)) & " ".PadRight(listofwidths(1)) & "Bookings".PadLeft(listofwidths(2)) & " ".PadLeft(listofwidths(3)) & " ".PadLeft(listofwidths(4)) _
    '             & " ".PadLeft(listofwidths(5)) & " ".PadLeft(listofwidths(6)) & " ".PadLeft(listofwidths(7)) & " ".PadLeft(listofwidths(8)) & " ".PadLeft(listofwidths(9)) & " ".PadLeft(listofwidths(10)) & " ".PadLeft(listofwidths(11)) & " ".PadLeft(listofwidths(12)) _
    '             & " ".PadLeft(listofwidths(13)) & " ".PadLeft(listofwidths(14)) & "Bookings".PadLeft(listofwidths(15)) & "Bookings".PadLeft(listofwidths(16)) & "Bookings".PadLeft(listofwidths(17)) '& "Earnings".PadLeft(listofwidths(18)) & ""
    '            str += vbNewLine
    '            str += "".PadLeft(ll2, "-")
    '            str += vbNewLine
    '            For Each dr As DataRow In dt.Rows
    '                For Each dc As DataColumn In dt.Columns
    '                    If dc.Ordinal = 1 Then
    '                        str += dr(dc.ColumnName).ToString.PadRight(listofwidths(dc.Ordinal))
    '                    Else
    '                        str += dr(dc.ColumnName).ToString.PadLeft(listofwidths(dc.Ordinal) - 2) & "  "
    '                    End If
    '                Next
    '                str += vbNewLine
    '            Next
    '            str += "".PadLeft(ll2, "-")
    '            str += vbNewLine


    '            str += vbNewLine

    '            str += ("TOTAL".PadRight(15, " .") & " : " & (currency & (TotalField(dt, "Proceeds")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine

    '            'Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2 ", _
    '            '                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
    '            'Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 ", _
    '            '                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

    '            'str += ("TOTAL".PadRight(15, " .") & " : " & (currency & (TotalField(dt, "Ball Park Earnings")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
    '            'str += ("CASH".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
    '            'str += ("CARD".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
    '            'str += ("VOUCHER".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine
    '            'str += ("Grand Total".PadRight(15, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ")).PadLeft(ll2 - 2) & vbNewLine

    '            str += "".PadLeft(ll2, "-")

    '            str += vbNewLine
    '            TextBox1.Text = str
    '            'For i = 2 To DataGridView1.Columns.Count - 1
    '            '    DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            'Next
    '            'DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    '            'DataGridView1.Columns(1).Width = 200
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
    '        End Try

    '    End Sub
End Class
