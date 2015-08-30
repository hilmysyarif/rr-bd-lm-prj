Public Class frmSummary
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

    Sub GenrateReport()
        Dim outputString As String = ""
        'Dim dtBooking As DataTable = objBooking.Selection(cls_tblBookings.SelectionType.ALL, "BookingType='BOOKING'")
        'Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL)

        Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2  AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtBPayment As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2 and (BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING')) AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", _
                                                          New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtCashOut As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2 and Transac_type='CASH OUT'", _
                                                         New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtAllPayment As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2", _
                                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})


        Dim dtMerchant As DataTable = objMerchItems.Selection(cls_tblBillItems.SelectionType.ALL, " [BillID] IN (Select [BillID] from tblBill Where BillDate Between @d1 and @d2 )", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtMPayment As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "Transc_Time Between @d1 and @d2 and Transac_type='MERCHANDISE_SALE'", _
                                                         New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtDoorCharge As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2 and Transac_type='DOOR CHARGE'", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtDoors As DataTable = objInstant.Selection(cls_Temp_tblInstant.SelectionType.All, "InstantDate Between @d1 and @d2 ", _
                                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})



        Dim LeftAdd As String = "      "

        outputString += LeftAdd + "                                         SUMMARY REPORT" + vbNewLine

        'outputString += LeftAdd + "Total Bookings".PadRight(50, " .") & " : " & (dtBooking.Rows.Count.ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Booking Total".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "Total") - TotalField(dtBPayment, "Sp_Amount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "CASH OUT Total".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "CashOut") + TotalField(dtCashOut, "totalamount") + TotalField(dtAllPayment, "CashOut")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "TIP Total".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "tip") + TotalField(dtAllPayment, "tip")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "UPGRADE Total".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "Upgrade")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Car Fare".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "CarFare")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Escort Extension Fee".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "EscortExtensionFees")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Total Custom bookings".PadRight(50, " .") & " : " & (dtBooking.Rows.Count.ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "6. House Grand Total".PadRight(50, " .") & " : " & (currency & TotalField(dtBPayment, "House_amount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "7. SP Grand Total".PadRight(50, " .") & " : " & (currency & TotalField(dtBPayment, "Sp_Amount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + vbNewLine
        'outputString += LeftAdd + "7. Total Merchandise items".PadRight(50, " .") & " : " & (TotalField(dtMerchant, "Qty").ToString("0")).PadLeft(10, " ") & vbNewLine
        'outputString += LeftAdd + "Merchandise Total".PadRight(50, " .") & " : " & (currency & TotalField(dtMPayment, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine

        'outputString += vbNewLine
        'outputString += LeftAdd + "Door Charges".PadRight(50, " .") & " : " & (currency & TotalField(dtDoorCharge, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '   outputString += LeftAdd + vbNewLine

        Dim cash As Double = TotalField(dtBPayment, "CASH") - TotalField(dtBPayment, "Sp_Amount") + TotalField(dtAllPayment, "CASH")
        Dim card As Double = TotalField(dtBPayment, "CARD") + TotalField(dtAllPayment, "CARD")
        Dim sur As Double = TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtAllPayment, "Surcharge_Amt")
        Dim vouc As Double = TotalField(dtBPayment, "VoucherAmount") + TotalField(dtAllPayment, "VoucherAmount")
        outputString += LeftAdd + " " & vbNewLine
        'outputString += LeftAdd + "8. CASH".PadRight(50, " .") & " : " & (currency & (cash).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        Dim cash1 As Double = cash - (TotalField(dtBPayment, "CashOut") + TotalField(dtCashOut, "totalamount") + TotalField(dtAllPayment, "CashOut"))

        outputString += LeftAdd + "CASH".PadRight(50, " .") & " : " & (currency & (cash1).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "CARD".PadRight(50, " .") & " : " & (currency & (card).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "ADMIN FEE".PadRight(50, " .") & " : " & (currency & (sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "VOUCHER".PadRight(50, " .") & " : " & (currency & (vouc).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + vbNewLine

        outputString += LeftAdd + "Door Charges".PadRight(50, " .") & " : " & (currency & TotalField(dtDoorCharge, "Totalamount").ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "Doors".PadRight(50, " .") & " : " & (TotalField(dtDoors, "Qty").ToString("0")).PadLeft(10, " ") & vbNewLine

        outputString += LeftAdd + vbNewLine
        outputString += LeftAdd + vbNewLine

        'outputString += LeftAdd + "12. GRAND TOTAL".PadRight(50, " .") & " : " & (currency & (cash + card + vouc + sur).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + "TOTAL".PadRight(50, " .") & " : " & (currency & (cash1 + card + sur + vouc).ToString("0.00")).PadLeft(10, " ") & "     (Including GST)" & vbNewLine
        outputString += LeftAdd + "GST".PadRight(50, " .") & " : " & (currency & (TotalField(dtBPayment, "GST") + TotalField(dtAllPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        outputString += LeftAdd + vbNewLine

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
                obj.Printing(frm.PrinterSettings.PrinterName, TextBox1.Text, "House Summary" & Now.ToString("dd-MM-yy HH:mm"), "Letter")
            End If
        Else
            obj.Printing(MyLocalSettings.ReportPrinter, TextBox1.Text, "House Summary" & Now.ToString("dd-MM-yy HH:mm"), "Letter")
        End If
    End Sub

    Private Sub frmSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
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

        GenrateReport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GenrateReport()
    End Sub
End Class