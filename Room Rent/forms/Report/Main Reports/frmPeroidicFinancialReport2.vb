Public Class frmPeroidicFinancialReport2


    Dim objBooking As New cls_Temp_tblBookings
    Dim objBPayment As New cls_Temp_tblBookingPayments
    Dim objPayment As New cls_tblPayment
    Dim objCounter As New cls_Temp_tblDailyCounter


    Dim listofPages As List(Of String)

    Function HeaderString(ByVal PageNo As String) As String
        Dim Str As String = ""

        Str = vbNewLine
        Str += vbNewLine
        Str += vbNewLine 

        Str += "DATE : " & Now.ToString("dd/MM/yyyy") & ("Page #" & PageNo).PadLeft(120)

        Str += vbNewLine

        Str += "TIME : " & Now.ToString("hh:mm tt")

        Str += vbNewLine

        Str += ("PERIODIC FINANCIAL REVENUE TRANSACTION REPORT").PadLeft(100)

        Str += vbNewLine

        Str += ("").PadLeft(160, "=")

        Str += vbNewLine

        Str += "Sequence".PadRight(30) & ("START DATE/TIME").PadRight(30) & ("END DATE/TIME").PadRight(20)

        Str += vbNewLine

        Str += "DATE/TIME".PadRight(30) & (DateTimePicker1.Value.ToString("dd/MM/yyyy hh:mm tt")).PadRight(30) & (DateTimePicker2.Value.ToString("dd/MM/yyyy hh:mm tt")).PadRight(20)
        Str += vbNewLine

        Str += ("").PadLeft(160, "-")


        Str += vbNewLine
        Str += "".PadRight(30) & "DAY".PadRight(10) & "DATE".PadRight(10) & "TIME".PadRight(10) & "BOOKING".PadRight(15) & "HOUSE".PadRight(10) & "CASH".PadRight(10) & "CARDS".PadRight(10) & "G.S.T".PadRight(10) & "".PadRight(4) & "PAYMENT"
        Str += vbNewLine
        Str += "".PadRight(30) & "".PadRight(10) & "".PadRight(10) & "".PadRight(10) & "TYPE".PadRight(15) & "AMT.".PadRight(10) & "AMT.".PadRight(10) & "AMT.".PadRight(10) & "".PadRight(10) & "SC".PadRight(4) & "METHOD"


        Str += vbNewLine

        Str += ("").PadLeft(160, "-")

        Str += vbNewLine



        Return Str
    End Function


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
    Dim pageCnt As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click




        listofPages = New List(Of String)

        Dim PageStr As String = ""


        Dim TotCash As Double = 0
        Dim TotCard As Double = 0
        Dim TotTravel As Double = 0
        Dim TotCheque As Double = 0
        Dim TotGST As Double = 0
        pageCnt = 0

        Dim i As Integer = 0
        'Dim dtBookings As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.REPORT, "(BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING')) AND CreatedDate Between @d1 and @d2 order by sl", _
        '                                              New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        Dim dtBookings As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.REPORT, "CreatedDate Between @d1 and @d2 order by sl", _
                                                      New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        Dim tt As Double = 0
        Dim tt2 As String = ""
        pageCnt = 1
        PageStr = HeaderString(pageCnt)
        While i < dtBookings.Rows.Count
            Dim dr As DataRow = dtBookings.Rows(i)
            If i Mod 40 = 0 And i > 0 Then
                If PageStr <> "" Then
                    listofPages.Add(PageStr)
                End If
                pageCnt = (i / 40) + 1
                PageStr = HeaderString(pageCnt)
            End If
            tt = Val(dr("CASH")) - (Val(dr("Sp_Amount")) + Val(dr("CASHOUT")))
            If Val(dr("CASH")) > 0 Then
                tt2 = If(tt >= 0, " ", "-")
                tt = If(tt > 0, tt, -tt)
            Else
                tt2 = " "
             End If
            PageStr += vbNewLine
            PageStr += "".PadRight(24) & _
                 dr("SL").ToString.PadRight(6) & _
                 CDate(dr("CreatedDate")).ToString("ddd").PadRight(8) & _
                 CDate(dr("CreatedDate")).ToString("dd/MM/yyyy").PadRight(12) & _
                 CDate(dr("CreatedDate")).ToString("hh:mm tt").PadRight(10) & _
                 dr("BookType").ToString.PadRight(15) & _
                 (Val(dr("HOUSE_Amount")) + Val(dr("TIP")) + Val(dr("Upgrade")) + Val(dr("CarFare")) + Val(dr("EscortExtensionFees")) + Val(dr("Surcharge_amt")) + Val(dr("Cancel_fees")) + Val(dr("Bond_amount"))).ToString("0.00").PadLeft(8) & "  " & _
                 tt.ToString("0.00").PadLeft(8) & tt2 & " " & _
                 (Val(dr("CARD")) + Val(dr("SURCHARGE_AMT"))).ToString("0.00").PadLeft(8) & "  " & _
                 Val(dr("GST")).ToString("0.00").PadLeft(8) & "  " & _
                 "".PadLeft(3) & " " & _
                 dr("PaymentMode")
            i += 1

        End While

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        tt = TotalField(dtBookings, "CASH") - (TotalField(dtBookings, "Sp_Amount") + TotalField(dtBookings, "CASHOUT"))
        tt2 = If(tt >= 0, " ", "-")
        tt = If(tt > 0, tt, -tt)

        PageStr += vbNewLine
        PageStr += "SUB TOTAL".PadRight(25) & _
                    dtBookings.Rows.Count.ToString.PadRight(5) & _
                    "".PadRight(8) & _
                    "".PadRight(12) & _
                    "".PadRight(10) & _
                    "".PadRight(15) & _
                    (Val(TotalField(dtBookings, "HOUSE_Amount")) + Val(TotalField(dtBookings, "TIP")) + Val(TotalField(dtBookings, "Upgrade")) + Val(TotalField(dtBookings, "CarFare")) + Val(TotalField(dtBookings, "EscortExtensionFees")) + Val(TotalField(dtBookings, "Surcharge_amt")) + Val(TotalField(dtBookings, "Cancel_fees"))).ToString("0.00").PadLeft(8) & "  " & _
                    tt.ToString("0.00").PadLeft(8) & tt2 & " " & _
                    Val(TotalField(dtBookings, "CARD") + TotalField(dtBookings, "SURCHARGE_AMT")).ToString("0.00").PadLeft(8) & "  " & _
                    Val(TotalField(dtBookings, "GST")).ToString("0.00").PadLeft(8) & "  " & _
                    "".PadLeft(3) & " " & _
                    ""

        TotCash += TotalField(dtBookings, "CASH") - (TotalField(dtBookings, "Sp_Amount") + TotalField(dtBookings, "CASHOUT"))
        TotCard += TotalField(dtBookings, "CARD") + TotalField(dtBookings, "SURCHARGE_AMT")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtBookings, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")

        listofPages.Add(PageStr)



        '//NEW PAGE
        pageCnt += 1
        PageStr = HeaderString(pageCnt)

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Gifts Subtotal".PadRight(25) & _
            "".PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")



        'Dim dtBookingGifts As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.REPORT, "CreatedDate Between @d1 and @d2 and HOUSE_Amount=0 order by sl", _
        '                                            New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        'For Each dr As DataRow In dtBookingGifts.Rows
        '    CheckPage(PageStr)
        '    PageStr += vbNewLine
        '    PageStr += "".PadRight(24) & _
        '         dr("SL").ToString.PadRight(6) & _
        '         CDate(dr("CreatedDate")).ToString("ddd").PadRight(8) & _
        '         CDate(dr("CreatedDate")).ToString("dd/MM/yyyy").PadRight(12) & _
        '         CDate(dr("CreatedDate")).ToString("hh:mm tt").PadRight(10) & _
        '         dr("BookType").ToString.PadRight(15) & _
        '        "".PadLeft(8) & "  " & _
        '        (Val(dr("CASH")) - Val(dr("Sp_Amount"))).ToString("0.00").PadLeft(8) & "  " & _
        '        (Val(dr("CARD")) + Val(dr("SURCHARGE_AMT"))).ToString("0.00").PadLeft(8) & "  " & _
        '        "0.00".PadLeft(13) & "  " & _
        '        "0.00".PadLeft(8) & "  " & _
        '        Val(dr("GST")).ToString("0.00").PadLeft(8) & "  " & _
        '        "".PadLeft(3) & " " & _
        '        dr("PaymentMode")
        'Next
        'PageStr += vbNewLine
        'PageStr += ("").PadLeft(160, "-")

        'PageStr += vbNewLine
        'PageStr += "Gifts Subtotal".PadRight(25) & _
        '            dtBookingGifts.Rows.Count.ToString.PadRight(5) & _
        '            "".PadRight(8) & _
        '            "".PadRight(12) & _
        '            "".PadRight(10) & _
        '            "".PadRight(15) & _
        '            "".PadLeft(8) & "  " & _
        '            Val(TotalField(dtBookingGifts, "CASH") - TotalField(dtBookingGifts, "Sp_Amount")).ToString("0.00").PadLeft(8) & "  " & _
        '            Val(TotalField(dtBookingGifts, "CARD") + TotalField(dtBookingGifts, "SURCHARGE_AMT")).ToString("0.00").PadLeft(8) & "  " & _
        '            "0.00".PadLeft(13) & "  " & _
        '            "0.00".PadLeft(8) & "  " & _
        '            Val(TotalField(dtBookingGifts, "GST")).ToString("0.00").PadLeft(8) & "  " & _
        '            "".PadLeft(3) & " " & _
        '            ""

        'TotCash += TotalField(dtBookingGifts, "CASH") - TotalField(dtBookingGifts, "Sp_Amount")
        'TotCard += TotalField(dtBookingGifts, "CARD") + TotalField(dtBookingGifts, "SURCHARGE_AMT")
        'TotTravel += 0
        'TotCheque += 0
        'TotGST += TotalField(dtBookingGifts, "GST")
        'PageStr += vbNewLine
        'PageStr += ("").PadLeft(160, "-")




        Dim dtMembership As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='MEMBERSHIP' and Transc_Time Between @d1 and @d2 ", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})


        CheckPage(PageStr)
        PageStr += vbNewLine



        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Membership Subtotal".PadRight(25) & _
            dtMembership.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtMembership, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtMembership, "CARD") + TotalField(dtMembership, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtMembership, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash += TotalField(dtMembership, "CASH")
        TotCard += TotalField(dtMembership, "CARD") + TotalField(dtMembership, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtMembership, "GST")


        'PageStr += "Membership Subtotal".PadRight(25) & _
        '    "".PadRight(5) & _
        '    "".PadRight(8) & _
        '    "".PadRight(12) & _
        '    "".PadRight(10) & _
        '    "".PadRight(15) & _
        '   "".PadLeft(8) & "  " & _
        '    Val(0).ToString("0.00").PadLeft(8) & "  " & _
        '    Val(0).ToString("0.00").PadLeft(8) & "  " & _
        '    Val(0).ToString("0.00").PadLeft(8) & "  " & _
        '    "".PadLeft(3) & " " & _
        '    ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        'Dim dtMerchat As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='MERCHANDISE_SALE' and Transc_Time Between @d1 and @d2 ", _
        '                                          New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        'CheckPage(PageStr)
        'PageStr += vbNewLine

        'PageStr += vbNewLine
        'PageStr += ("").PadLeft(160, "-")
        'PageStr += vbNewLine
        'PageStr += "Merchandise Subtotal".PadRight(25) & _
        '    dtMerchat.Rows.Count.ToString.PadRight(5) & _
        '    "".PadRight(8) & _
        '    "".PadRight(12) & _
        '    "".PadRight(10) & _
        '    "".PadRight(15) & _
        '    "".PadLeft(8) & "  " & _
        '    Val(TotalField(dtMerchat, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
        '    (TotalField(dtMerchat, "CARD") + TotalField(dtMerchat, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
        '    (TotalField(dtMerchat, "GST")).ToString("0.00").PadLeft(8) & "  " & _
        '    "".PadLeft(3) & " " & _
        '    ""
        'TotCash += TotalField(dtMerchat, "CASH")
        'TotCard += TotalField(dtMerchat, "CARD") + TotalField(dtMerchat, "Surcharge_Amt")
        'TotTravel += 0
        'TotCheque += 0
        'TotGST += TotalField(dtMerchat, "GST")

        'PageStr += vbNewLine
        'PageStr += ("").PadLeft(160, "-")



        Dim pp As New List(Of SqlParameter)
        pp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
        pp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})
        Dim objBill As New cls_Temp_tblBillItems

        CheckPage(PageStr)
        PageStr += vbNewLine


        Dim dtMerchatDetails As DataTable = objBill.Selection(cls_Temp_tblBillItems.SelectionType.Report, "a.[BillDate] between @d1 and @d2", pp)

        If dtMerchatDetails.Rows.Count > 0 Then
            PageStr += vbNewLine
            PageStr += ("").PadLeft(160, "-")
            PageStr += vbNewLine
        End If


        i = 0
        While i < dtMerchatDetails.Rows.Count
            Dim dr As DataRow = dtMerchatDetails.Rows(i)
            CheckPage(PageStr)
            PageStr += vbNewLine
            PageStr += "".PadRight(24) & _
                 (i + 1).ToString.PadRight(6) & _
                 CDate(dr("BillDate")).ToString("ddd").PadRight(8) & _
                 CDate(dr("BillDate")).ToString("dd/MM/yyyy").PadRight(12) & _
                 CDate(dr("BillDate")).ToString("hh:mm tt").PadRight(10) & _
                 dr("ProductName").ToString.PadRight(23) & _
                 "".PadLeft(0) & "  " & _
                 Val(dr("SubTotal")).ToString("0.00").PadLeft(8) & tt2 & " " & _
                 "".PadLeft(8) & "  " & _
                 "".PadLeft(8) & "  " & _
                 "".PadLeft(3) & " " & _
                 ""
            i += 1
        End While
        If dtMerchatDetails.Rows.Count > 0 Then
            CheckPage(PageStr)
            PageStr += vbNewLine
            PageStr += ("").PadLeft(160, "-")
            PageStr += vbNewLine
            PageStr += "".PadRight(24) & _
                 "".PadRight(6) & _
                 "".PadRight(8) & _
                 "".PadRight(12) & _
                 "".PadRight(10) & _
                 "TOTAL".PadRight(23) & _
                 "".PadLeft(0) & "  " & _
                 TotalField(dtMerchatDetails, "SubTotal").ToString("0.00").PadLeft(8) & tt2 & " " & _
                 "".PadLeft(8) & "  " & _
                 "".PadLeft(8) & "  " & _
                 "".PadLeft(3) & " " & _
                 ""
        End If




        Dim dtMerchat As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='MERCHANDISE_SALE' and Transc_Time Between @d1 and @d2 ", _
                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        CheckPage(PageStr)


        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Merchandise Subtotal".PadRight(25) & _
            dtMerchatDetails.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtMerchat, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtMerchat, "CARD") + TotalField(dtMerchat, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtMerchat, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash += TotalField(dtMerchat, "CASH")
        TotCard += TotalField(dtMerchat, "CARD") + TotalField(dtMerchat, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtMerchat, "GST")

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")









        Dim dtCashOut As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='CASH OUT' and Transc_Time Between @d1 and @d2 ", _
                                                         New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        CheckPage(PageStr)
        PageStr += vbNewLine

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Addl CASH OUT Subtotal".PadRight(25) & _
            dtCashOut.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtCashOut, "CARD")).ToString("0.00").PadLeft(8) & "- " & _
            (TotalField(dtCashOut, "CARD") + TotalField(dtCashOut, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtCashOut, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash = TotCash - TotalField(dtCashOut, "CARD")
        TotCard += TotalField(dtCashOut, "CARD") + TotalField(dtCashOut, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtCashOut, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        CheckPage(PageStr)
        PageStr += vbNewLine


        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Limo/Taxis Subtotal (*)".PadRight(25) & _
            "".PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
           "".PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        PageStr += vbNewLine


        CheckPage(PageStr)
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "SP Subtotal (*)".PadRight(25) & _
            "".PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        Dim dtDoorCharge As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='DOOR CHARGE' and Transc_Time Between @d1 and @d2 ", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        Dim dtDoorCharge2 As DataTable = (New cls_Temp_tblInstant).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "InstantDate Between @d1 and @d2 ",
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        CheckPage(PageStr)
        PageStr += vbNewLine

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "DOOR Subtotal".PadRight(25) &
            TotalField(dtDoorCharge2, "Qty").ToString.PadRight(5) &
            "".PadRight(8) &
            "".PadRight(12) &
            "".PadRight(10) &
            "".PadRight(15) &
            "".PadLeft(8) & "  " &
            Val(TotalField(dtDoorCharge, "CASH")).ToString("0.00").PadLeft(8) & "  " &
            (TotalField(dtDoorCharge, "CARD") + TotalField(dtDoorCharge, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " &
            (TotalField(dtDoorCharge, "GST")).ToString("0.00").PadLeft(8) & "  " &
            "".PadLeft(3) & " " &
            ""
        TotCash += TotalField(dtDoorCharge, "CASH")
        TotCard += TotalField(dtDoorCharge, "CARD") + TotalField(dtDoorCharge, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtDoorCharge, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")



        CheckPage(PageStr)
        PageStr += vbNewLine


        PageStr += vbNewLine
        Dim CountTotal As Integer = 0
        Try
            CountTotal = objCounter.Selection(cls_Temp_tblDailyCounter.SelectionType.TODAY_COUNT).Rows.Count
        Catch ex As Exception
        End Try
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Counter Subtotal".PadRight(25) & _
            CountTotal.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            Val(0).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")



        Dim dtAmenities As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='SHIFT FEE' and Transc_Time Between @d1 and @d2 ", _
                                                       New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        CheckPage(PageStr)
        PageStr += vbNewLine

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Amenities Subtotal".PadRight(25) & _
            dtAmenities.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtAmenities, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtAmenities, "CARD") + TotalField(dtAmenities, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtAmenities, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash += TotalField(dtAmenities, "CASH")
        TotCard += TotalField(dtAmenities, "CARD") + TotalField(dtAmenities, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtAmenities, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        Dim dtLockers As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='LOCKER BOOKING' and Transc_Time Between @d1 and @d2 ", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        CheckPage(PageStr)
        PageStr += vbNewLine
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Locker Subtotal".PadRight(25) & _
            dtLockers.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtLockers, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtLockers, "CARD") + TotalField(dtLockers, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtLockers, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash += TotalField(dtLockers, "CASH")
        TotCard += TotalField(dtLockers, "CARD") + TotalField(dtLockers, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtLockers, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        Dim dtCustom As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='CUSTOM' and Transc_Time Between @d1 and @d2 ", _
                                                      New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

        CheckPage(PageStr)
        PageStr += vbNewLine

        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "Custom Subtotal".PadRight(25) & _
            dtCustom.Rows.Count.ToString.PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            Val(TotalField(dtCustom, "CASH")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtCustom, "CARD") + TotalField(dtCustom, "Surcharge_Amt")).ToString("0.00").PadLeft(8) & "  " & _
            (TotalField(dtCustom, "GST")).ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        TotCash += TotalField(dtCustom, "CASH")
        TotCard += TotalField(dtCustom, "CARD") + TotalField(dtCustom, "Surcharge_Amt")
        TotTravel += 0
        TotCheque += 0
        TotGST += TotalField(dtCustom, "GST")
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")


        CheckPage(PageStr)
        PageStr += vbNewLine


        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")
        PageStr += vbNewLine
        PageStr += "GRAND TOTAL".PadRight(25) & _
            "".PadRight(5) & _
            "".PadRight(8) & _
            "".PadRight(12) & _
            "".PadRight(10) & _
            "".PadRight(15) & _
            "".PadLeft(8) & "  " & _
            TotCash.ToString("0.00").PadLeft(8) & "  " & _
            TotCard.ToString("0.00").PadLeft(8) & "  " & _
            TotGST.ToString("0.00").PadLeft(8) & "  " & _
            "".PadLeft(3) & " " & _
            ""
        PageStr += vbNewLine
        PageStr += ("").PadLeft(160, "-")

        PageStr += vbNewLine
        PageStr += vbNewLine
        PageStr += vbNewLine
        PageStr += "(*) Values will not be added in Grand Total."
        PageStr += vbNewLine

        listofPages.Add(PageStr)


        'Try

        '    Try
        'Dim dtSPAmount As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 ", _
        '                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})


        'DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
        'For Each dr As DataRow In dtSPAmount.Rows
        '    'DataGridView1.Rows.Add(" ", "", CDate(dr("CreatedDate")).ToString("ddd"), CDate(dr("CreatedDate")).ToString("dd/MM/yyyy"), CDate(dr("CreatedDate")).ToString("hh:mm tt"), "NORMAL", (Val(dr("HOUSE_Amount")) - Val(dr("GST"))).ToString("0.00"), Val(dr("SP_Amount")).ToString("0.00"), "0.00", "0.00", Val(dr("GST")).ToString("0.00"), dr("PaymentMode"))
        '    DataGridView1.Rows.Add(" ", "", CDate(dr("CreatedDate")).ToString("ddd"), CDate(dr("CreatedDate")).ToString("dd/MM/yyyy"), CDate(dr("CreatedDate")).ToString("hh:mm tt"), "NORMAL", "", Val(dr("SP_Amount")).ToString("0.00"), "0.00", "0.00", "0.00", dr("PaymentMode"))
        'Next

        'DataGridView1.Rows.Add("SP Subtotal", dtSPAmount.Rows.Count, "", "", "", "", "", (TotalField(dtSPAmount, "SP_Amount")).ToString("0.00"), "0.00", "0.00", "0.00", "")

        'DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
        'DataGridView1.Rows.Add("Counter Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")

        'DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
        'DataGridView1.Rows.Add("Totals", "", "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")
        '    Catch ex As Exception
        '    Throw ex
        'End Try

        'Try
        '    Dim dtBooking As DataTable = objBooking.Selection(cls_tblBookings.SelectionType.ALL, "BookingType='BOOKING' and BookingDate Between @d1 and @d2 ", _
        '                                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        '    Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 ", _
        '                                                      New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
        '    Dim dtPayment As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type in ('DOOR CHARGE','CASH OUT') and Transc_Time Between @d1 and @d2 ", _
        '                                                      New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})}) 'Transac_type='DOOR CHARGE' and 
        '    Dim outputString As String = ""

        '    'outputString += "CASH".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtPayment, "CASH")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    'outputString += "CARD".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CARD") + TotalField(dtPayment, "CARD")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    'outputString += "SURCHARGE".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    'outputString += "VOUCHER".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "VoucherAmount") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        '    'outputString += "Total<Excluding GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount") _
        '    '                                                                                 + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    'outputString += "GST".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        '    'outputString += "Total<Including GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount") + TotalField(dtBPayment, "GST") _
        '    '                                                                                 + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

        '    outputString += "CASH".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    outputString += "CARD".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "CARD")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    outputString += "SURCHARGE".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    outputString += "VOUCHER".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    'outputString += "Total<Excluding GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    outputString += "GST".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        '    outputString += "Total<Including GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
        'Catch ex As Exception
        '    Throw ex
        'End Try

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        'End Try

        TextBox1.Clear()
        For Each pg As String In listofPages
            TextBox1.Text += pg
        Next

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim obj As New clsReportPrint
        If MyLocalSettings.ReportPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                obj.Printing2(frm.PrinterSettings.PrinterName, listofPages, "RPT " & Now.ToString("dd-MM-yy HH:mm"), "A4")
            End If
        Else
            obj.Printing2(MyLocalSettings.ReportPrinter, listofPages, "RPT " & Now.ToString("dd-MM-yy HH:mm"), "A4")
        End If

    End Sub

    Private Sub frmReport_PERIODIC_ANALYSIS_REPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        ComboBox1.SelectedIndex = 0

    End Sub

    Sub CheckPage(ByRef pagestr_ As String)
        If pagestr_.Split(vbNewLine).Count > 55 Then
            listofPages.Add(pagestr_)
            pageCnt += 1
            pagestr_ = HeaderString(pageCnt)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        'Dim frm As New frmDoorChargeOverall
        'frm.dtpOvFrom.Value = DateTimePicker1.Value
        'frm.dtpOvTo.Value = DateTimePicker2.Value
        'frm.refreshDOOROverall(frm.dtpOvFrom.Value.Date, frm.dtpOvTo.Value.Date)
        'frm.ShowDialog()
        Dim frm As New frmDoorReport
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim frm As New frmDailyBooking
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.refreshDailyReport_Booking()
        frm.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim frm As New frmMembershipReport
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmMerchandiseReport_ProductWse
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim frm As New frmSpReport
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmCashOut
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim frm As New frmAmenitiesReport
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Dim frm As New frmLockerReport
        frm.DateTimePicker1.Value = DateTimePicker1.Value
        frm.DateTimePicker2.Value = DateTimePicker2.Value
        frm.ShowReport()
        frm.ShowDialog()
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
        Button1_Click(Nothing, Nothing)
    End Sub
End Class