Public Class frmPeroidicFinancialReport

    Dim objBooking As New cls_Temp_tblBookings
    Dim objBPayment As New cls_Temp_tblBookingPayments
    Dim objPayment As New cls_tblPayment
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
      Try
          
            Try
                DataGridView1.Rows.Clear()
               
                DataGridView1.Rows.Add("Gifts Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")

                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")

                DataGridView1.Rows.Add("Membership Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")

                'DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")

                'DataGridView1.Rows.Add("Solarium Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")

                Dim dtMerchat As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='MERCHANDISE_SALE' and Transc_Time Between @d1 and @d2 ", _
                                                                 New List(Of SQLParameter) From {(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})

                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")

                DataGridView1.Rows.Add("Merchandise Subtotal", dtMerchat.Rows.Count, "", "", "", "", "", (TotalField(dtMerchat, "CASH")).ToString("0.00"), (TotalField(dtMerchat, "CARD")).ToString("0.00"), (TotalField(dtMerchat, "Surcharge_Amt")).ToString("0.00"), (TotalField(dtMerchat, "Surcharge_Amt")).ToString("0.00"), "")

                Dim dtCashOut As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='CASH OUT' and Transc_Time Between @d1 and @d2 ", _
                                                                 New List(Of SQLParameter) From {(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")


                DataGridView1.Rows.Add("Addl CASH OUT Subtotal", dtCashOut.Rows.Count, "", "", "", "", "", (TotalField(dtCashOut, "CASH")).ToString("0.00"), (TotalField(dtCashOut, "CARD")).ToString("0.00"), (TotalField(dtCashOut, "Surcharge_Amt")).ToString("0.00"), (TotalField(dtCashOut, "Surcharge_Amt")).ToString("0.00"), "")


                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")

                DataGridView1.Rows.Add("Limo/Taxis Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")


                Dim dtSPAmount As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2 ", _
                                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})


                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
                For Each dr As DataRow In dtSPAmount.Rows
                    'DataGridView1.Rows.Add(" ", "", CDate(dr("CreatedDate")).ToString("ddd"), CDate(dr("CreatedDate")).ToString("dd/MM/yyyy"), CDate(dr("CreatedDate")).ToString("hh:mm tt"), "NORMAL", (Val(dr("HOUSE_Amount")) - Val(dr("GST"))).ToString("0.00"), Val(dr("SP_Amount")).ToString("0.00"), "0.00", "0.00", Val(dr("GST")).ToString("0.00"), dr("PaymentMode"))
                    DataGridView1.Rows.Add(" ", "", CDate(dr("CreatedDate")).ToString("ddd"), CDate(dr("CreatedDate")).ToString("dd/MM/yyyy"), CDate(dr("CreatedDate")).ToString("hh:mm tt"), "NORMAL", "", Val(dr("SP_Amount")).ToString("0.00"), "0.00", "0.00", "0.00", dr("PaymentMode"))
                Next

                DataGridView1.Rows.Add("SP Subtotal", dtSPAmount.Rows.Count, "", "", "", "", "", (TotalField(dtSPAmount, "SP_Amount")).ToString("0.00"), "0.00", "0.00", "0.00", "")
                Dim dtDoorCharge As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type='DOOR CHARGE' and Transc_Time Between @d1 and @d2 ", _
                                                                New List(Of SQLParameter) From {(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
                DataGridView1.Rows.Add("DOOR Subtotal", dtDoorCharge.Rows.Count, "", "", "", "", "", (TotalField(dtDoorCharge, "CASH")).ToString("0.00"), (TotalField(dtDoorCharge, "CARD")).ToString("0.00"), (TotalField(dtDoorCharge, "Surcharge_Amt")).ToString("0.00"), (TotalField(dtDoorCharge, "GST")).ToString("0.00"), "")


                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
                DataGridView1.Rows.Add("Counter Subtotal", 0, "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")

                DataGridView1.Rows.Add(" ", "", "", "", "", "", "", "", " ", " ", " ", "")
                DataGridView1.Rows.Add("Totals", "", "", "", "", "", "", "0.00", "0.00", "0.00", "0.00", "")
            Catch ex As Exception
                Throw ex
            End Try

            Try
                Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2 ", _
                                                                           New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
                Dim dtBPayment As DataTable = objBPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "CreatedDate Between @d1 and @d2 ", _
                                                                  New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})})
                Dim dtPayment As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transac_type in ('DOOR CHARGE','CASH OUT') and Transc_Time Between @d1 and @d2 ", _
                                                                  New List(Of SQLParameter) From {(New SQLParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value}), (New SQLParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})}) 'Transac_type='DOOR CHARGE' and 
                Dim outputString As String = ""

                'outputString += "CASH".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtPayment, "CASH")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                'outputString += "CARD".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CARD") + TotalField(dtPayment, "CARD")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                'outputString += "ADMIN FEE".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                'outputString += "VOUCHER".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "VoucherAmount") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

                'outputString += "Total<Excluding GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount") _
                '                                                                                 + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                'outputString += "GST".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

                'outputString += "Total<Including GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "CASH") + TotalField(dtBPayment, "CARD") + TotalField(dtBPayment, "Surcharge_Amt") + TotalField(dtBPayment, "VoucherAmount") + TotalField(dtBPayment, "GST") _
                '                                                                                 + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

                outputString += "CASH".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += "CARD".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "CARD")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += "ADMIN FEE".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "Surcharge_Amt")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += "VOUCHER".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                'outputString += "Total<Excluding GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += "GST".PadRight(25, " .") & " : " & (currency & (TotalField(dtPayment, "GST")).ToString("0.00")).PadLeft(10, " ") & vbNewLine
                outputString += "Total<Including GST>".PadRight(25, " .") & " : " & (currency & (TotalField(dtBPayment, "SP_Amount") + TotalField(dtPayment, "CASH") + TotalField(dtPayment, "CARD") + TotalField(dtPayment, "Surcharge_Amt") + TotalField(dtPayment, "VoucherAmount")).ToString("0.00")).PadLeft(10, " ") & vbNewLine

                Label2.Text = outputString
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try




    End Sub



    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintList
        Dim header2 As String = ""
        header2 += "START DATE/TIME                                                       END DATE/TIME" & vbNewLine
        header2 += DateTimePicker1.Text & "                                                  " & DateTimePicker2.Text


        frm.PrintPreview(DataGridView1, "PERIODIC FINANCIAL REVENUE TRANSACTION REPORT".ToUpper, header2, Label2.Text, "Abstract Concepts Pty Ltd", True, "", False, True)
    End Sub

    Private Sub frmReport_PERIODIC_ANALYSIS_REPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        If Now.Hour > 9 Then
            DateTimePicker1.Value = Today.AddHours(9)
            DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
            DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class