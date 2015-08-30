Public Class cls_Reports
     
    Private ReadOnly Property Report_DAILY_BOOKING As String
        Get
            Return <REPORT><![CDATA[
                SELECT 

                    aa.StartTime  as [Time],
                    d.[WorkerName] as [Worker],
                    a.[Room],   
                    CASE WHEN c.[Service]>89 THEN convert(varchar,(c.[Service]/60)) + ' Hrs' ELSE convert(varchar,c.[Service]) + ' Mins' END as [Service], 
                    Convert(decimal(18,2) , isnull(b.[TotalA],0))as [Booking Amt],   
                    Convert(decimal(18,2) , isnull(b.[TIPA],0)) as [TIP],   
                    Convert(decimal(18,2) , isnull(b.[UpgradeA],0)) as [Upgrade Fee],
                    Convert(decimal(18,2) , isnull(b.[CarFareA],0)) as [Car Fare],
                    Convert(decimal(18,2) , isnull(b.[EscortExtensionFeesA],0)) as [Escort Ext Fee],
                    Convert(decimal(18,2) , isnull(b.[CASHA],0)) as [CASH],
                    Convert(decimal(18,2) , isnull(b.[CARDA],0)) as [CARD] ,
                    Convert(decimal(18,2) , isnull(b.[SurchargeA],0))  as [Surcharge],
                    Convert(decimal(18,2) , isnull(b.[VoucherAmountA],0)) as [Voucher] ,
                    Convert(decimal(18,2) , (isnull(b.[CASHA],0) + isnull(b.[CARDA],0) + isnull(b.VoucherAmountA ,0) + isnull(b.[SurchargeA],0))) as [Grand Total] ,
                    Convert(decimal(18,2) , (isnull(b.[CASHA],0) + isnull(b.[CARDA],0) + isnull(b.VoucherAmountA ,0) + isnull(b.[SurchargeA],0)) - isnull(b.Sp_AmountA,0)) as [House Amt] ,
                    Convert(decimal(18,2) , isnull(b.Sp_AmountA,0)) as [SP Amt] ,
                    aa.[Status]
                FROM 
                tblActiveWorker AS AA LEFT JOIN tblBookings AS a ON AA.BookingID = a.BookingID
                LEFT outer JOIN 
                (
                select Sum(total) as [TotalA],sum(Card) as [CardA],sum(Cash) as 
                [CashA],sum(Surcharge_Amt) as [SurchargeA],sum(Tip) as [TipA],sum(Upgrade) as [UpgradeA],sum(VoucherAmount) as [VoucherAmountA],sum(CarFare) as [CarFareA],sum(EscortExtensionFees) as [EscortExtensionFeesA],sum(Sp_Amount) as [Sp_AmountA], bookingid,WorkerID from tblBookingPayments group by bookingid,WorkerID 
                )  AS b 
                ON a.bookingid = b.bookingid and aa.WorkerID = b.WorkerID 
                LEFT outer JOIN 
                (
                select sum(Service) as [Service],bookingid,WorkerID from tblExtraService  group by bookingid,WorkerID
                )  AS c 
                ON a.bookingid = c.bookingid and aa.WorkerID = c.WorkerID 
                Left Join
                tblWorkers as d
                ON aa.workerid = d.workerid
                WHERE  aa.addedtime between @d1 and @d2
                    ]]></REPORT>.Value
        End Get
    End Property 'AA.Status<>'STARTED' and  AA.Status<>'' and

    'Private ReadOnly Property Report_DAILY_DOOR As String
    '    Get
    '        Return <REPORT><![CDATA[
    '         (SELECT

    '                FORMAT(c.StartTime,'dd MMM yy HH:mm')  as [Time], 
    '                a.[DoorName] as [Door Name], FORMAT(a.[DoorCharge],'0.00') as [Charge] 
    '                FROM 
    '                (tblBookings AS a LEFT JOIN tblWorkers AS b ON a.WorkerID = b.WorkerID) 
    '                LEFT JOIN tblActiveWorker AS c ON (a.BookingID = c.BookingId) AND (a.WorkerID = c.workerid)
    '                WHERE  a.BookingType ='BOOKING'  and c.StartTime between @d1 and @d2 and a.[DoorCharge]>0)

    '                UNION(
    '                SELECT 
    '                Format(a.InstantDate,'dd mmm yy hh:nn') AS [Time],
    '                a.[DoorName] as [Door Name], FORMAT(a.[DoorCharge],'0.00') as [Charge] 
    '                FROM tblInstant a
    '                WHERE  a.InstantDate between @d1 and @d2 
    '            )

    '            order by [Time]


    '                ]]></REPORT>.Value
    '    End Get
    'End Property
    Private ReadOnly Property Report_DAILY_DOOR As String
        Get
            Return <REPORT><![CDATA[
                SELECT 
                Convert(varchar, a.InstantDate,103) AS [Time],
                a.[DoorName] as [Door Name], a.[TotalAmount] as [Charge] 
                FROM tblInstant a
                WHERE  a.InstantDate between @d1 and @d2                 
                order by a.InstantDate


                    ]]></REPORT>.Value
        End Get
    End Property


    '    Private ReadOnly Property Report_DOOR_OVERAL As String
    '        Get
    '            Return <REPORT><![CDATA[
    'Select a.[Time] as [Date],a.[Door Name], FORMAT(Sum(a.[Charge]),'0.00')  as [Door Charge] from 
    '             (Select * from (SELECT

    '                        FORMAT(c.StartTime,'dd MMM yy')  as [Time], 
    '                        a.[DoorName] as [Door Name], FORMAT(a.[DoorCharge],'0.00') as [Charge] 
    '                        FROM 
    '                        (tblBookings AS a LEFT JOIN tblWorkers AS b ON a.WorkerID = b.WorkerID) 
    '                        LEFT JOIN tblActiveWorker AS c ON (a.BookingID = c.BookingId) AND (a.WorkerID = c.workerid)
    '                        WHERE  a.BookingType ='BOOKING'  and c.StartTime between @d1 and @d2 and a.[DoorCharge]>0)

    '                        UNION(
    '                        SELECT 
    '                        Format(a.InstantDate,'dd MMM yy') AS [Time],
    '                        a.[DoorName] as [Door Name], FORMAT(a.[DoorCharge],'0.00') as [Charge] 
    '                        FROM tblInstant a
    '                        WHERE  a.InstantDate between @d1 and @d2 
    '                    )
    '                    ) a 

    'group by a.[Time],a.[Door Name]
    'order by a.[Time],a.[Door Name]


    '                    ]]></REPORT>.Value
    '        End Get
    '    End Property
    Private ReadOnly Property Report_DOOR_OVERAL As String
        Get
            Return <REPORT><![CDATA[
Select a.[Time] as [Date],a.[Door Name], Sum(a.[Charge])  as [Door Charge] from 
             (
                        SELECT 
                        Convert(varchar,a.InstantDate,103) AS [Time],
                        a.[DoorName] as [Door Name], a.[TotalAmount] as [Charge] 
                        FROM tblInstant a
                        WHERE  a.InstantDate between @d1 and @d2 
                    
                    ) a 
                    
group by a.[Time],a.[Door Name]
order by a.[Time],a.[Door Name]


                    ]]></REPORT>.Value
        End Get
    End Property



    Private ReadOnly Property Report_WORKER_WISE_INCOME As String
        Get
            Return <REPORT><![CDATA[
                    SELECT
                      a.WorkerName as [Worker],
                      convert(decimal(18,2), isnull(b.total ,0))  as [Total]
                    FROM 

                    tblWorkers AS a 
                    LEFT JOIN
                    (
                    SELECT c.WorkerID, sum(b.TotalA /d.workers) as total
                    FROM 
                    (
                    ( 
                    tblActiveWorker AS c
                    LEFT JOIN tblBookings a ON (a.BookingID = c.BookingId) 
                    )
                    LEFT JOIN 
                    (
                    select Sum(total) as [TotalA],sum(Card) as [CardA],sum(Cash) as 
                    [CashA],sum(Surcharge_Amt) as [SurchargeA],sum(Tip) as [TipA], bookingid from tblBookingPayments group by bookingid
                    )  AS b 
                    ON a.bookingid = b.bookingid)

                    LEFT JOIN 
                    (
                    select count(sl) as [Workers], bookingid from tblActiveWorker  group by bookingid
                    )  AS d
                    ON a.bookingid = d.bookingid

                    WHERE  a.BookingType ='BOOKING' and c.addedtime between @d1 and @d2
                    group by c.workerid
                    ) AS b ON a.WorkerID = b.WorkerID
                    ]]></REPORT>.Value
        End Get
    End Property

    Private ReadOnly Property Report_DAILY_BOOKING_INWEEK As String
        Get
            Return <REPORT><![CDATA[
              
  select 

convert(varchar, CreatedDate,103)  as [Time_T],
Sum(total) as [TotalA],
sum(Card) as [CardA],
sum(Cash) as [CashA],
sum(Surcharge_Amt) as [SurchargeA],
sum(Tip) as [TipA],
sum(Card+Cash+Surcharge_Amt+Tip) as [GRAND_T]
from tblBookingPayments
               
 WHERE CreatedDate between @d1 and @d2 group by convert(varchar,CreatedDate,103)


                    ]]></REPORT>.Value
        End Get
    End Property

    Private ReadOnly Property Report_DAILY_BOOKING_INWEEK_WORKERWISE As String
        Get
            Return <REPORT><![CDATA[
SELECT a1.[Time_T],
       a1.WorkerID,
       a1.WorkerName,
       ISNULL( b1.[GRAND_T2],0 ) AS [GRAND_T]
  FROM( 
        SELECT CONVERT( VARCHAR,a.date_val,103 ) AS [Time_T],
               a.date_val,
               b.WorkerID,
               b.WorkerName
          FROM(
        SELECT *
          FROM tblCalender
          WHERE date_val BETWEEN @w1 AND @w2 ) a,
              (
        SELECT *
          FROM tblWorkers
          WHERE WorkerID IN(
        SELECT WorkerID
          FROM tblBookingPayments
          WHERE CreatedDate BETWEEN @d1 AND @d2 )) b ) a1
      LEFT OUTER JOIN( 
                       SELECT CONVERT( VARCHAR,a.CreatedDate,103 ) AS [Time_T],
                              SUM( a.total ) AS [TotalA],
                              SUM( a.Card ) AS [CardA],
                              SUM( a.Cash ) AS [CashA],
                              SUM( a.Surcharge_Amt ) AS [SurchargeA],
                              SUM( a.Tip ) AS [TipA],
                              SUM( a.Card + Cash + Surcharge_Amt + Tip ) AS [GRAND_T],
                              SUM( a.Sp_amount ) AS [GRAND_T2],
                              a.WorkerID,
                              b.WorkerName
                         FROM tblBookingPayments a
                              LEFT OUTER JOIN tblWorkers b ON a.WorkerID = b.WorkerId
                         WHERE a.CreatedDate BETWEEN @d1 AND @d2
                         GROUP BY CONVERT( VARCHAR,a.CreatedDate,103 ),
                                  a.WorkerID,
                                  b.WorkerName ) b1 ON a1.Time_T = b1.Time_T
                                                   AND a1.workerid = b1.workerID
                       ]]></REPORT>.Value
        End Get
    End Property

    Private ReadOnly Property Report_DAILY_BOOKING_INWEEK_SPLITREPORT As String
        Get
            Return <REPORT><![CDATA[
SELECT a1.[Time_T],
       ISNULL( b1.[GRAND_T],0 ) AS [GRAND_T],
       ISNULL( b1.[sp],0 ) AS [sp],
       ISNULL( b1.[house],0 ) AS [house]
  FROM( 
        SELECT CONVERT( VARCHAR,a.date_val,103 ) AS [Time_T],
               a.date_val
          FROM(
        SELECT *
          FROM tblCalender
          WHERE date_val BETWEEN @w1 AND @w2 ) a ) a1
      LEFT OUTER JOIN( 
                       SELECT CONVERT( VARCHAR,a.CreatedDate,103 ) AS [Time_T],
                              SUM( a.total ) AS [TotalA],
                              SUM( a.Card ) AS [CardA],
                              SUM( a.Cash ) AS [CashA],
                              SUM( a.Surcharge_Amt ) AS [SurchargeA],
                              SUM( a.Tip ) AS [TipA],
                              SUM( a.Card + Cash + Surcharge_Amt + Tip ) AS [GRAND_T],
                              SUM( a.Sp_Amount + a.Tip ) AS [sp],
                              SUM( a.House_amount ) AS [house]
                         FROM tblBookingPayments a
                         WHERE a.CreatedDate BETWEEN @d1 AND @d2
                         GROUP BY CONVERT( VARCHAR,a.CreatedDate,103 )) b1 ON a1.Time_T = b1.Time_T
                   ]]></REPORT>.Value
        End Get
    End Property
    Enum ReportType
        DAILY_REPORT_BOOKING = 0
        DAILY_REPORT_DOOR = 1
        DAILY_WORKER_WISE = 2
        DOOR_OVERALL = 3
        BOOKING_TOTAL_INWEEK = 4
        BOOKING_TOTAL_INWEEK_WORKERWISE = 5
        BOOKING_TOTAL_INWEEK_SPLIT = 6
    End Enum
    Public Function Selection(ByVal typ As ReportType, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        Select Case typ
            Case ReportType.DAILY_REPORT_BOOKING
                comSelect.CommandText = Report_DAILY_BOOKING
            Case ReportType.DAILY_REPORT_DOOR
                comSelect.CommandText = Report_DAILY_DOOR
            Case ReportType.DAILY_WORKER_WISE
                comSelect.CommandText = Report_WORKER_WISE_INCOME
            Case ReportType.DOOR_OVERALL
                comSelect.CommandText = Report_DOOR_OVERAL
            Case ReportType.BOOKING_TOTAL_INWEEK
                comSelect.CommandText = Report_DAILY_BOOKING_INWEEK
            Case ReportType.BOOKING_TOTAL_INWEEK_WORKERWISE
                comSelect.CommandText = Report_DAILY_BOOKING_INWEEK_WORKERWISE & " " & SelectString
            Case ReportType.BOOKING_TOTAL_INWEEK_SPLIT
                comSelect.CommandText = Report_DAILY_BOOKING_INWEEK_SPLITREPORT & " " & SelectString
        End Select

        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
        Dim daSelect As New SQLDataAdapter(comSelect)
        Dim dtSelect As New DataTable
        Try
            daSelect.Fill(dtSelect)
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            daSelect.Dispose()
            dtSelect.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        daSelect.Dispose()
        Return dtSelect
    End Function

    Function DailyReportBookings(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DAILY_REPORT_BOOKING, "", pp)
    End Function

    Function DailyReportBookings2(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        'Dim d1 As Date = rptDate.Date.AddHours(9)
        'Dim d2 As Date = rptDate.Date.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SqlParameter)
        pp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DAILY_REPORT_BOOKING, "", pp)
    End Function
    Function WeeklyReportBookings(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.AddDays(0 - rptDate.DayOfWeek).Date.AddHours(9)
        Dim d2 As Date = rptDate.AddDays(7 - rptDate.DayOfWeek).Date.AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DAILY_REPORT_BOOKING, "", pp)
    End Function
    Function DailyReportDoor(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DAILY_REPORT_DOOR, "", pp)
    End Function
    Function DailyWorkerWise(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DAILY_WORKER_WISE, "", pp)
    End Function
    Function DoorOverall(ByVal rptDateFrom As Date, ByVal rptDateTo As Date) As DataTable
        Dim d1 As Date = rptDateFrom.Date.AddHours(9)
        Dim d2 As Date = rptDateTo.Date.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.DOOR_OVERALL, "", pp)
    End Function

    Function BookingTotalInWeek(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddDays(0 - rptDate.DayOfWeek).AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(7 - rptDate.DayOfWeek).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.BOOKING_TOTAL_INWEEK, "", pp)
    End Function

    Function BookingTotalInWeek_WORKERWISE(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddDays(0 - rptDate.DayOfWeek).AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(7 - rptDate.DayOfWeek).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@w1", SqlDbType.DateTime) With {.Value = d1.Date})
        pp.Add(New SQLParameter("@w2", SqlDbType.DateTime) With {.Value = d1.Date.AddDays(6)})
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.BOOKING_TOTAL_INWEEK_WORKERWISE, "order by a1.WorkerID,date_val", pp)
    End Function

    Function BookingTotalInWeek_SPLIT(ByVal rptDate As Date) As DataTable
        Dim d1 As Date = rptDate.Date.AddDays(0 - rptDate.DayOfWeek).AddHours(9)
        Dim d2 As Date = rptDate.Date.AddDays(7 - rptDate.DayOfWeek).AddHours(8).AddMinutes(59).AddSeconds(59)
        Dim pp As New List(Of SQLParameter)
        pp.Add(New SQLParameter("@w1", SqlDbType.DateTime) With {.Value = d1.Date})
        pp.Add(New SQLParameter("@w2", SqlDbType.DateTime) With {.Value = d1.Date.AddDays(6)})
        pp.Add(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = d1})
        pp.Add(New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = d2})
        Return Selection(ReportType.BOOKING_TOTAL_INWEEK_SPLIT, "order by date_val", pp)
    End Function
End Class
