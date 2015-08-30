Public Class frmSummaryNew
    Dim objBooking As New cls_Temp_tblBookings
    Dim objBPayment As New cls_Temp_tblBookingPayments
    Dim objService As New cls_tblExtraService
    Dim objWorkers As New cls_tblActiveWorker
    Dim objMerchItems As New cls_tblBillItems
    Dim objMerchs As New cls_Temp_tblBill
    Dim objPayment As New cls_tblPayment
    Public objInstant As New cls_Temp_tblInstant

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
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

    Function GetParams() As List(Of SqlParameter)
        Dim DatePara As New List(Of SqlParameter)
        DatePara.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
        DatePara.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})
        Return DatePara
    End Function

    Sub GenrateReport()
        Dim outputString As String = ""
        'Dim dtBooking As DataTable = objBooking.Selection(cls_tblBookings.SelectionType.ALL, "BookingType='BOOKING'")
        'Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL)


       
        Dim DatePara1 As List(Of SqlParameter) = GetParams()
        Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2  AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", DatePara1)

        Dim DatePara2 As List(Of SqlParameter) = GetParams()
        Dim dtBPayment As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2 and (BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING')) AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", DatePara2)

        Dim DatePara3 As List(Of SqlParameter) = GetParams()
        Dim dtCashOut As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2 and Transac_type='CASH OUT'", DatePara3)

        Dim DatePara4 As List(Of SqlParameter) = GetParams()
        Dim dtAllPayment As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2", DatePara4)

        Dim DatePara5 As List(Of SqlParameter) = GetParams()
        Dim dtMerchant As DataTable = objMerchItems.Selection(cls_tblBillItems.SelectionType.ALL, " [BillID] IN (Select [BillID] from tblBill Where BillDate Between @d1 and @d2 )", DatePara5)

        'Dim DatePara6 As List(Of SqlParameter) = GetParams()
        'Dim dtMPayment As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "Transc_Time Between @d1 and @d2 and Transac_type='MERCHANDISE_SALE'", DatePara6)

        'Dim DatePara7 As List(Of SqlParameter) = GetParams()
        'Dim dtDoorCharge As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2 and Transac_type='DOOR CHARGE'", DatePara7)

        Dim DatePara8 As List(Of SqlParameter) = GetParams()
        Dim dtDoors As DataTable = objInstant.Selection(cls_Temp_tblInstant.SelectionType.All, "InstantDate Between @d1 and @d2 ", DatePara8)



        Dim LeftAdd As String = " "

        ' outputString += LeftAdd + "                       My Periodic Financial Revenue Transaction Report" + vbNewLine
        outputString += LeftAdd + "         My Periodic Financial Revenue Transaction Report" + vbNewLine

        'outputString += LeftAdd + "Total Bookings".PadRight(50,".") & " : " & (dtBooking.Rows.Count.ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Booking Total".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "Total") - TotalField(dtBPayment, "Sp_Amount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "CASH OUT Total".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "CashOut") + TotalField(dtCashOut, "totalamount") + TotalField(dtAllPayment, "CashOut")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "TIP Total".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "tip") + TotalField(dtAllPayment, "tip")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "UPGRADE Total".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "Upgrade")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Car Fare".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "CarFare")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Escort Extension Fee".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "EscortExtensionFees")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Total Custom bookings".PadRight(50,".") & " : " & (dtBooking.Rows.Count.ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "6. House Grand Total".PadRight(50,".") & " : " & (currency & TotalField(dtBPayment, "House_amount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "7. SP Grand Total".PadRight(50,".") & " : " & (currency & TotalField(dtBPayment, "Sp_Amount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "7. Total Merchandise items".PadRight(50,".") & " : " & (TotalField(dtMerchant, "Qty").ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Merchandise Total".PadRight(50,".") & " : " & (currency & TotalField(dtMPayment, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine

        'outputString += vbNewLine
        'outputString += LeftAdd + "Door Charges".PadRight(50,".") & " : " & (currency & TotalField(dtDoorCharge, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '   outputString += LeftAdd + vbNewLine

        Dim cash As Double = TotalField(dtBPayment, "CASH") - TotalField(dtBPayment, "Sp_Amount") + TotalField(dtAllPayment, "CASH")
        Dim card As Double = TotalField(dtBPayment, "CARD") + TotalField(dtAllPayment, "CARD")
        Dim sur As Double = TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtAllPayment, "Surcharge_Amt")
        Dim vouc As Double = TotalField(dtBPayment, "VoucherAmount") + TotalField(dtAllPayment, "VoucherAmount")
        outputString += LeftAdd + " " & vbNewLine
        'outputString += LeftAdd + "8. CASH".PadRight(50,".") & " : " & (currency & (cash).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        Dim cash1 As Double = cash - (TotalField(dtBPayment, "CashOut") + TotalField(dtCashOut, "totalamount") + TotalField(dtAllPayment, "CashOut"))


        Dim Query As String = ""





        ' outputString += LeftAdd + "Day/Date and Time " & " : From " & DateTimePicker1.Value.ToString("ddd dd/MM/yy hh:mm tt") & " - " & DateTimePicker2.Value.ToString("ddd dd/MM/yy hh:mm tt") & vbNewLine
        outputString += LeftAdd + "        From " & DateTimePicker1.Value.ToString("ddd dd/MM/yy hh:mm tt") & " - " & DateTimePicker2.Value.ToString("ddd dd/MM/yy hh:mm tt") & vbNewLine
        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "CASH ".PadRight(50, ".") & " : " & (currency & (cash1).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "CREDIT CARDS ".PadRight(50, ".") & " : " & (currency & (card).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "ADMIN FEES ".PadRight(50, ".") & " : " & (currency & (sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "GST COLLECTED ".PadRight(50, ".") & " : " & (currency & (TotalField(dtBPayment, "GST") + TotalField(dtAllPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "TOTAL ".PadRight(50, ".") & " : " & (currency & (cash1 + card + sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "CATEGORIES " & vbNewLine
        outputString += LeftAdd + vbNewLine

        outputString += LeftAdd + "DOORS" & vbNewLine
        outputString += LeftAdd + vbNewLine


        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  

SELECT a.DoorName,
       SUM( a.qty ) qty,
       SUM( a.TotalAmount ) / SUM( a.qty ) price,
       SUM( ISNULL( b.TOTAIL_PAID,0 )) AS total
  FROM tblInstant a
       LEFT OUTER JOIN tblPayment b ON a.MemoNo = b.MemoNo
  WHERE b.ID IS NOT NULL
    AND a.InstantDate BETWEEN @d1 AND @d2 
  GROUP BY a.DoorName,
           a.TotalAmount / a.qty
  ORDER BY a.TotalAmount / a.qty


]]></Query>.Value
            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Doors " & currency & dr("Price").ToString & " " & dr("DoorName").ToString & " ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No doors" & vbNewLine
            End If
        Catch ex As Exception
            outputString += LeftAdd + ("No of Doors " & currency & "20 Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("No of Doors " & currency & "10 Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try
        outputString += LeftAdd + "Members entering".PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + "Free Entry Card".PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "BOOKINGS" & vbNewLine
        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Bookings".PadRight(50, ".") & " : " & (dtBooking.Rows.Count.ToString("0")).PadLeft(10, " ") & vbNewLine
        Dim Extensions As Integer = 0

        Try

            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[
  
SELECT COUNT(DISTINCT a.bookingid)
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               workerid,
                               COUNT(bookingid) AS cnt
                          FROM tblExtraService
                          GROUP BY bookingid,
                                   workerid ) b ON a.BookingID = b.BookingID
  WHERE a.BookingType = 'BOOKING'
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND b.cnt >= 2
    AND a.BookingID NOT IN( 
                            SELECT BookingID
                              FROM tblBookingStatus
                              WHERE [Status] = 'CANCEL' )


]]></Query>.Value

            Dim cnt As Integer = ExecuteSQL_Scalar(Query, DatePara_)
            outputString += LeftAdd + "Extensions".PadRight(50, ".") & " : " & cnt.ToString.PadLeft(10) & vbNewLine
        Catch ex As Exception
            outputString += LeftAdd + "Extensions".PadRight(50, ".") & " : " & "0".PadLeft(10) & vbNewLine
        End Try

        outputString += LeftAdd + "Upgrades ".PadRight(50, ".") & " : " & "" & vbNewLine

        Try
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[
  
SELECT( 
        SELECT SUM(SURCHARGE_AMT)
          FROM tblPayment
          WHERE Transc_Time BETWEEN @d1 AND @d2 ) + ( 
                                                      SELECT SUM(SURCHARGE_AMT)
                                                        FROM tblBookingPayments
                                                        WHERE CreatedDate BETWEEN @d1 AND @d2 ) AS TotalAdmin


]]></Query>.Value
            Dim amount As Double = ExecuteSQL_Scalar(Query, DatePara_)
            outputString += LeftAdd + "Credit Card Admin Fees".PadRight(50, ".") & " : " & (currency & amount.ToString("0.00")).PadLeft(10) & vbNewLine
        Catch ex As Exception
            outputString += LeftAdd + "Credit Card Admin Fees".PadRight(50, ".") & " : " & (currency & "0.00").PadLeft(10) & vbNewLine
        End Try

        outputString += LeftAdd + vbNewLine

        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  select * from tblBookings  where BookingType ='PREBOOKING' and [BookingDate] between @d1 and @d2 
]]></Query>.Value
            dtDoor = ExecuteAdapter(Query, DatePara_)
            outputString += LeftAdd + "Pre bookings (normally NO door fee)".PadRight(50, ".") & " : " & dtDoor.Rows.Count.ToString.PadLeft(10, " ") & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine
        Catch ex As Exception
            outputString += LeftAdd + "Pre bookings (normally NO door fee)".PadRight(50, ".") & " : " & "0".PadLeft(10, " ") & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine
        End Try

        'outputString += LeftAdd + "Pre bookings (normally NO door fee)" & vbNewLine
        outputString += LeftAdd + vbNewLine

        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  


SELECT COUNT(DISTINCT a.BookingID) AS [Qty],
       ISNULL(SUM(ISNULL(d.cnt,0)),0) AS [Total]
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               COUNT(bookingid) AS cnt
                          FROM tblActiveWorker
                          GROUP BY BookingId ) b ON a.BookingID = b.BookingID
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               SUM(ISNULL(TOTAIL_PAID,0) - ISNULL(Sp_Amount,0) - ISNULL(CashOut,0)) AS cnt
                          FROM tblBookingPayments
                          GROUP BY BookingId ) d ON a.BookingID = d.BookingId
  WHERE a.BookingType = 'BOOKING' 
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND a.BookingID IN( 
                        SELECT bookingid
                          FROM(
                        SELECT BookingID,
                               COUNT(BookingID) AS cnt,
                               WorkerID
                          FROM tblExtraService
                          GROUP BY BookingID,
                                   WorkerID ) n
                          WHERE n.cnt > 1 )


]]></Query>.Value
            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Extensions ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If
        Catch ex As Exception
            outputString += LeftAdd + ("No of Extensions Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try

        outputString += LeftAdd + ("No of Upgrades  Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Admin Fees Total ".PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + ("No of Paid Up Front (no door fee)total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + ("No of Extensions Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + ("No of Upgrades Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Room Upgrades" & vbNewLine
        outputString += LeftAdd + vbNewLine

        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  

SELECT a.Room,
       c.FullName,
       COUNT(a.bookingId) AS qty,
       SUM(ISNULL(b.totail_paid,0) - ISNULL(b.sp_amount,0) - ISNULL(b.cashout,0)) AS Total
  FROM tblbookings a
       LEFT OUTER JOIN tblBookingPayments b ON a.BookingID = b.BookingId
       LEFT OUTER JOIN tblRoom c ON A.Room = c.Room
  WHERE a.BookingType = 'BOOKING'
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND a.BookingID NOT IN( 
                            SELECT BookingID
                              FROM tblBookingStatus
                              WHERE [Status] = 'CANCEL' )
    AND b.Sl IS NOT NULL
  GROUP BY a.Room,
           c.FullName

]]></Query>.Value
            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of " & dr("FullName").ToString & " ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If
        Catch ex As Exception
            outputString += LeftAdd + "No of Penthouse Total ".PadRight(50, ".") & " : " & "" & currency & "0.00" & vbNewLine
        End Try


        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  


SELECT count(distinct a.BookingID) AS [Qty],
       ISNULL(SUM(ISNULL(d.cnt,0)),0) AS [Total]
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               COUNT(bookingid) AS cnt
                          FROM tblActiveWorker
                          GROUP BY BookingId ) b ON a.BookingID = b.BookingID 
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               SUM(ISNULL(TOTAIL_PAID,0) - ISNULL(Sp_Amount,0) - ISNULL(CashOut,0)) AS cnt
                          FROM tblBookingPayments
                          GROUP BY BookingId ) d ON a.BookingID = d.BookingId
  WHERE a.BookingType = 'BOOKING'
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND b.cnt = 2
]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Doubles ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If
        Catch ex As Exception
            outputString += LeftAdd + ("No of Doubles Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try
        outputString += LeftAdd + ("No of Spa Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine

        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  


SELECT count(distinct a.BookingID) AS [Qty],
       ISNULL(SUM(ISNULL(d.cnt,0)),0) AS [Total]
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               COUNT(bookingid) AS cnt
                          FROM tblActiveWorker
                          GROUP BY BookingId ) b ON a.BookingID = b.BookingID 
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               SUM(ISNULL(TOTAIL_PAID,0) - ISNULL(Sp_Amount,0) - ISNULL(CashOut,0)) AS cnt
                          FROM tblBookingPayments
                          GROUP BY BookingId ) d ON a.BookingID = d.BookingId
  WHERE a.BookingType = 'BOOKING'
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND b.cnt = 1

]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Single ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If
        Catch ex As Exception
            outputString += LeftAdd + ("No of Single Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try
        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  


SELECT count(distinct a.BookingID) AS [Qty],
       ISNULL(SUM(ISNULL(d.cnt,0)),0) AS [Total]
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               COUNT(bookingid) AS cnt
                          FROM tblActiveWorker
                          GROUP BY BookingId ) b ON a.BookingID = b.BookingID 
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               SUM(ISNULL(TOTAIL_PAID,0) - ISNULL(Sp_Amount,0) - ISNULL(CashOut,0)) AS cnt
                          FROM tblBookingPayments
                          GROUP BY BookingId ) d ON a.BookingID = d.BookingId
  WHERE a.BookingType = 'BOOKING' and Room='ESCORT'
    AND a.BookingDate BETWEEN @d1 AND @d2


]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Escorts ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next

            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If

        Catch ex As Exception
            outputString += LeftAdd + ("No of Escorts Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try
        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  


SELECT COUNT(DISTINCT a.BookingID) AS [Qty],
       ISNULL(SUM(ISNULL(d.cnt,0)),0) AS [Total]
  FROM tblBookings a
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               COUNT(bookingid) AS cnt
                          FROM tblActiveWorker
                          GROUP BY BookingId ) b ON a.BookingID = b.BookingID
       LEFT OUTER JOIN( 
                        SELECT bookingid,
                               SUM(ISNULL(TOTAIL_PAID,0) - ISNULL(Sp_Amount,0) - ISNULL(CashOut,0)) AS cnt
                          FROM tblBookingPayments
                          GROUP BY BookingId ) d ON a.BookingID = d.BookingId
  WHERE a.BookingType = 'BOOKING'
    AND Room = 'ESCORT'
    AND a.BookingDate BETWEEN @d1 AND @d2
    AND a.BookingID IN( 
                        SELECT bookingid
                          FROM(
                        SELECT BookingID,
                               COUNT(BookingID) AS cnt,
                               WorkerID
                          FROM tblExtraService
                          GROUP BY BookingID,
                                   WorkerID ) n
                          WHERE n.cnt > 1 )


]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)
            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("No of Escorts Extensions ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next

            If dtDoor.Rows.Count = 0 Then
                outputString += LeftAdd + "                  **No Bookings" & vbNewLine
            End If

        Catch ex As Exception
            outputString += LeftAdd + ("No of Escorts Extensions Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try

        outputString += LeftAdd + ("No of Escort Upgrades Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine


        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Travel " & vbNewLine



        Try


            Dim DatePara6_ As List(Of SqlParameter) = GetParams()
            Dim dtMPayment_ As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2", DatePara6_)
            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + ("Travel Fees " & currency & " ").PadRight(50, ".") & " : " & (currency & TotalField(dtMPayment_, "carfare").ToString("0.00")).PadLeft(10, " ") & vbNewLine

        Catch ex As Exception
            outputString += LeftAdd + vbNewLine
           outputString += LeftAdd + "Travel Fees".PadRight(50, ".") & " : " & "" & vbNewLine
        End Try


        'outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "Travel Fees".PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + "Escort Taxi".PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Tips" & vbNewLine
        Try
            Dim DatePara6_ As List(Of SqlParameter) = GetParams()
            'Dim dtMPayment1_ As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2", DatePara6_)
            Dim dtMPayment_ As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "Transc_Time Between @d1 and @d2", DatePara6_)
            outputString += LeftAdd + ("Shift fee " & currency & " ").PadRight(50, ".") & " : " & (currency & TotalField(dtMPayment_, "totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        Catch ex As Exception
            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + ("Shift fee ").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try

        outputString += LeftAdd + vbNewLine

        outputString += LeftAdd + ("No of Staff tip total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + ("No of House tip Toatl " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        outputString += LeftAdd + ("Total of Over Charged Total " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + ("Total Tips " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + vbNewLine
        Try

            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()

            Query = <Query><![CDATA[ select * from tblBookingStatus where [Status]='CANCEL' and [DATE] between @d1 and @d2 ]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)
            outputString += LeftAdd + "Cancellations".PadRight(50, ".") & " : " & dtDoor.Rows.Count.ToString.PadLeft(10, " ") & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine
            outputString += LeftAdd + vbNewLine

            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + "Reason ".PadRight(50, ".") & " : " & dr("Reason").ToString & vbNewLine
            Next



        Catch ex As Exception
            outputString += LeftAdd + "Cancellations".PadRight(50, ".") & " : " & "0".PadLeft(10, " ") & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine

            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + "Reason ".PadRight(50, ".") & " : " & "" & vbNewLine
        End Try
        Try
            Dim dtDoor As DataTable = Nothing
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Query = <Query><![CDATA[  select * from tblBookingStatus where [Status]='SUSPEND' and [DATE] between @d1 and @d2
]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)

            outputString += LeftAdd + "Suspensions".PadRight(50, ".") & " : " & dtDoor.Rows.Count.ToString.PadLeft(10, " ") & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine
            outputString += LeftAdd + vbNewLine

            For Each dr As DataRow In dtDoor.Rows
                'outputString += LeftAdd + ("No of Escorts Extensions ").PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                'outputString += LeftAdd + "                  Total ".PadRight(50, ".") & " : " & (currency & Val(dr("total")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + "Reason ".PadRight(50, ".") & " : " & dr("Reason").ToString & vbNewLine
            Next



        Catch ex As Exception
            outputString += LeftAdd + "Suspensions".PadRight(50, ".") & " : 0" & vbNewLine ' must be authorised by Franco or a staff member authorized by Franco" & vbNewLine

            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + "Reason ".PadRight(50, ".") & " : " & "0".PadLeft(10, " ") & vbNewLine
        End Try

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Merchandise" & vbNewLine
        outputString += LeftAdd + vbNewLine

        Try
            Dim dtDoor As DataTable = Nothing

            Dim DatePara_ As List(Of SqlParameter) = GetParams()

            Query = <Query><![CDATA[  
Select

       COUNT(a.ItemID),
       a.ProductId,
       b.ProductName,
       SUM(
           ( a.Subtotal / c.Amount * d.SURCHARGE_AMT
           ) + a.Subtotal) AS amount,
       SUM(a.Qty) AS qty

  FROM tblBillItems a

       LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductID
       LEFT OUTER JOIN tblBill c ON a.BillID = c.BillID
       LEFT OUTER JOIN tblPayment d ON c.BillID = d.Transc_ID
                       AND d.Transac_Type = 'MERCHANDISE_SALE'

  WHERE

        1 = 1
    AND b.ProductID IS NOT NULL
    AND d.ID IS NOT NULL
    AND c.BillDate BETWEEN @d1 AND @d2

  GROUP BY a.ProductId,
           b.ProductName

]]></Query>.Value

            dtDoor = ExecuteAdapter(Query, DatePara_)

            For Each dr As DataRow In dtDoor.Rows
                outputString += LeftAdd + ("Total No " & dr("ProductName").ToString).PadRight(50, ".") & " : " & dr("qty").ToString.PadLeft(10, " ") & vbNewLine
                outputString += LeftAdd + ("                  Total ").PadRight(50, ".") & " : " & (currency & Val(dr("amount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
            Next
        Catch ex As Exception
            outputString += LeftAdd + ("Total No Liquid Gels  " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Sponge " & currency & " ").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Mouthwash " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Plugs " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Out Fit " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Toys " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Totat No Batteries " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Packet Smokes " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Single Smokes " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Lighters " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Shavers " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Lube " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Shoes " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Handbag " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
            outputString += LeftAdd + ("Total No Custom Accessories " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try



        Try
            Dim objLocker As New cls_Temp_tblLockerBooking
            Dim DatePara_ As List(Of SqlParameter) = GetParams()
            Dim dtLockers As DataTable = objLocker.Selection(cls_Temp_tblLockerBooking.SelectionType.All, "BookingDate BETWEEN @d1 AND @d2", DatePara_)
            Dim countLocker As Integer = dtLockers.Rows.Count
            dtLockers.Dispose()
            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + "Total No LOCKERS ".PadRight(50, ".") & " : " & countLocker.ToString.PadLeft(10, " ") & vbNewLine

            Dim DatePara6_ As List(Of SqlParameter) = GetParams()
            Dim dtMPayment_ As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "Transc_Time Between @d1 and @d2 and Transac_type='LOCKER BOOKING'", DatePara6_)

            outputString += LeftAdd + ("                  Total").PadRight(50, ".") & " : " & (currency & TotalField(dtMPayment_, "totalamount")).ToString("0.00").PadLeft(10, " ") & vbNewLine
        Catch ex As Exception
            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + ("Total No LOCKERS " & currency & "").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try



        'outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "Gift Vouchers".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "From Suspended".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "From Cancelled".PadRight(50, ".") & " : " & "" & vbNewLine

        'outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "Amenities" & vbNewLine
        'outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "Shift Fee room".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Shift Fee DC".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Shift Fee Late".PadRight(50, ".") & " : " & "" & vbNewLine

        Try
           

            Dim DatePara6_ As List(Of SqlParameter) = GetParams()
            Dim dtMPayment_ As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "Transc_Time Between @d1 and @d2 and Transac_type='SHIFT FEE'", DatePara6_)

            outputString += LeftAdd + ("Shift fee").PadRight(50, ".") & " : " & (currency & TotalField(dtMPayment_, "totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine

        Catch ex As Exception
            outputString += LeftAdd + vbNewLine
            outputString += LeftAdd + ("Shift fee ").PadRight(50, ".") & " : " & "" & vbNewLine
        End Try


        'outputString += LeftAdd + "Shift Fee privates".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Shift Fee rosters".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Shift fee cancellation".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Early Shift fee".PadRight(50, ".") & " : " & "" & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + "Memberships".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "Key Ring".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "".PadRight(50, ".") & " : " & "" & vbNewLine
        'outputString += LeftAdd + "".PadRight(50, ".") & " : " & "" & vbNewLine

        'outputString += LeftAdd + "CASH".PadRight(50,".") & " : " & (currency & (cash1).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "CARD".PadRight(50,".") & " : " & (currency & (card).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "ADMIN FEE".PadRight(50,".") & " : " & (currency & (sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "VOUCHER".PadRight(50,".") & " : " & (currency & (vouc).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        ' outputString += LeftAdd + vbNewLine
        ' outputString += LeftAdd + vbNewLine

        ' outputString += LeftAdd + "Door Charges".PadRight(50,".") & " : " & (currency & TotalField(dtDoorCharge, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        ' outputString += LeftAdd + "Doors".PadRight(50,".") & " : " & (TotalField(dtDoors, "Qty").ToString("0")).PadLeft(10, " ") & vbNewLine

        ' outputString += LeftAdd + vbNewLine
        ' outputString += LeftAdd + vbNewLine

        'outputString += LeftAdd + "12. GRAND TOTAL".PadRight(50,".") & " : " & (currency & (cash + card + vouc + sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "TOTAL".PadRight(50,".") & " : " & (currency & (cash1 + card + sur + vouc).ToString("0.00")).PadLeft(10, " ") & "     (Including GST)" & vbNewLine
        ' outputString += LeftAdd + "GST".PadRight(50,".") & " : " & (currency & (TotalField(dtBPayment, "GST") + TotalField(dtAllPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        ' outputString += LeftAdd + vbNewLine

        'outputString += "Reports on cancelations and suspentions AND TOTAL bookings:"
        'outputString += "Total 30 min bookings"
        'outputString += "total 45 mins booking"
        'outputString += "Total 1 hr bookings"

        'outputString += "Strike rate %....................."
        'outputString += "Total Escorts " & currency & " ............"
        'outputString += "Then the lot gets totaled in Cash " & currency & ",,,,,,,,,,,,,   Plus  Total Cards " & currency & " ..................."
        'outputString += ""
        'outputString += ""
        'outputString += ""
        'outputString += "" 
        TextBox1.Text = outputString

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim obj As New clsDocketPrint
        If MyLocalSettings.ReportPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                obj.Printing(frm.PrinterSettings.PrinterName, TextBox1.Text, "House Summary" & Now.ToString("dd-MM-yy HH:mm"), "A4", False, TextBox1.Font)
            End If
        Else
            obj.Printing(MyLocalSettings.ReportPrinter, TextBox1.Text, "House Summary" & Now.ToString("dd-MM-yy HH:mm"), "A4", False, TextBox1.Font)
        End If
    End Sub

    Private Sub frmSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TopMost = IsAllTopMostForm
        ComboBox1.SelectedIndex = 0

        GenrateReport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GenrateReport()
        TextBox1.TextAlign = HorizontalAlignment.Left
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
                Dim startTime As Date = Now
                If Now.Hour > 9 Then
                    startTime = Today.AddHours(9)
                    DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
                Else
                    startTime = Today.AddDays(-1).AddHours(9)
                    DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
                End If

                startTime = objBPayment.GetStartDate()
                Try
                    If Not MySettings.OtherSettings.StartDate.ToString("dd/MM/yyyy") = "01/01/0001" Then
                        startTime = MySettings.OtherSettings.StartDate.ToString
                    End If
                Catch ex As Exception
                End Try
                DateTimePicker1.Value = startTime
                'DateTimePicker1.Enabled = True
                'DateTimePicker2.Enabled = True
            Case 5
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
        GenrateReport()

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        FontDialog1.Font = TextBox1.Font
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
        End If

    End Sub


End Class