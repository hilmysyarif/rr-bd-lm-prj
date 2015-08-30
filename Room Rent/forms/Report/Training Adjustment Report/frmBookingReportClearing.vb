 
Public Class frmBookingReportClearing
    Dim objBooking As New cls_Temp_tblBookings
    Dim objService As New cls_tblExtraService
    Dim objWorkers As New cls_tblActiveWorker
    Dim objBPayment As New cls_tblBookingPayments
    Dim objMerchItems As New cls_tblBillItems
    Dim objMerchs As New cls_Temp_tblBill
    Dim objPayment As New cls_tblPayment

    Dim totBooking As Integer = 0
    Dim cashAmount As Double = 0.0
    Dim totBooking_adjusted As Integer = 0
    Dim cashAmount_adjusted As Double = 0.0
    Function TotalField(ByVal dt As Object, ByVal fieldName As String) As Double
        Dim total As Double = 0
        For Each dr As DataRow In dt
            Try
                If Not dr(fieldName) Is DBNull.Value Then
                    total += Val(dr(fieldName))
                End If
            Catch ex As Exception
            End Try
        Next
        Return total
    End Function

    Dim startTime As Date = Now

    Private Sub frmBookingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        startTime = objBPayment.GetStartDate()
        Try
            If Not MySettings.OtherSettings.StartDate.ToString("dd/MM/yyyy") = "01/01/0001" Then
                startTime = MySettings.OtherSettings.StartDate.ToString
            End If
        Catch ex As Exception
        End Try
        If MySettings.OtherSettings.StartDate.ToString("yyyyMMddHHmmss") = startTime.ToString("yyyyMMddHHmmss") Then
            totBooking_adjusted = MySettings.OtherSettings.Adjust_TotalBooks
            cashAmount_adjusted = MySettings.OtherSettings.Adjust_Cashamount
        Else
            totBooking_adjusted = 0
            cashAmount_adjusted = 0
        End If
        DateTimePicker1.Value = Now

    End Sub
    Dim d2 As Date = Now


    Sub GenrateReport(ByVal frmDate As Date, ByVal toDate As Date)
        Dim outputString As String = ""
        d2 = toDate

        ' lblReportHeader.Text = "Report From : " & frmDate.ToString("dd/MM/yyyy HH:mm")
        dtpFrom.Value = frmDate
        Dim dtBookingService As DataTable = objService.Selection(cls_tblExtraService.SelectionType.ALL, "CreatedDate Between @d1 and @d2 AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", _
                                                        New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})

        'Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", _
        '                                                     New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})

        'Dim dtBooking As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingType='BOOKING' and BookingDate Between @d1 and @d2 ", _
        '                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})

        Dim dtBPayment As DataTable = objBPayment.Selection(cls_tblBookingPayments.SelectionType.ALL, "CreatedDate Between @d1 and @d2 and (BookingId not in (select BookingId from tblBookingStatus where Status='CANCEL') or [Type] in ('CANCEL BOOKING')) AND BookingId not in (select BookingId from tblBookings where ExcludeFromReport=1)", _
                                                          New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})

        Dim dtCashOut As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2 and Transac_type='CASH OUT'", _
                                                         New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})

        Dim dtAllPayment As DataTable = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_Time Between @d1 and @d2", _
                                                               New List(Of SqlParameter) From {(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = frmDate}), (New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = toDate})})


        Dim LeftAdd As String = "      "
        DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Add("", )
        totBooking = dtBookingService.Rows.Count
        cashAmount = TotalField(dtBPayment.Rows, "CASH")
        Dim newTot As Integer = totBooking + totBooking_adjusted
        'Dim newcash As Integer = cashAmount + cashAmount_adjusted

        'Dim CashOut As Double = TotalField(dtBPayment.Rows, "CashOut")
        'Dim tip As Double = TotalField(dtBPayment.Rows, "tip")
        'Dim Upgrade As Double = TotalField(dtBPayment.Rows, "Upgrade")
        'Dim Total As Double = TotalField(dtBPayment.Rows, "Total")
        'Dim CARD As Double = TotalField(dtBPayment.Rows, "CARD")
        'Dim Surcharge_Amt As Double = TotalField(dtBPayment.Rows, "Surcharge_Amt")
        'Dim VoucherAmount As Double = TotalField(dtBPayment.Rows, "VoucherAmount")
        'Dim House_amount As Double = TotalField(dtBPayment.Rows, "House_amount")

        'Dim ddd = From dsss As DataRow In dtBPayment.Rows Where dsss("CASH") = 0 Select dsss
        Dim Sp_Amount As Double = TotalField(dtBPayment.Rows, "Sp_Amount")
        'Dim Sp_Amount2 As Double = TotalField(ddd, "Sp_Amount")

        'DataGridView1.Rows.Add("1. Total bookings", newTot.ToString("0"))
        'DataGridView1.Rows.Add("2. CASH OUT Total", (CashOut).ToString("0.00"))
        'DataGridView1.Rows.Add("3. TIP Total", tip.ToString("0.00"))
        'DataGridView1.Rows.Add("4. UPGRADE Total", Upgrade.ToString("0.00"))
        'DataGridView1.Rows.Add("5. Booking Total", (Total + cashAmount_adjusted).ToString("0.00"))
        'DataGridView1.Rows.Add("   a. Total CASH", newcash.ToString("0.00"))

        ''DataGridView1.Rows.Add("      CASH OUT to SP for CARD PAYMENT", Sp_Amount2.ToString("0.00"))
        'DataGridView1.Rows.Add("      CASH OUT to SP", Sp_Amount.ToString("0.00"))
        'DataGridView1.Rows.Add("      CASH IN HAND (TOTAL CASH - SP CASH OUT)", (newcash - Sp_Amount).ToString("0.00"))
        'DataGridView1.Rows.Add("   b. CARD", (CARD + Surcharge_Amt).ToString("0.00"))
        'DataGridView1.Rows.Add("   c. VOUCHER", VoucherAmount)
        'DataGridView1.Rows.Add("   d. Grand Total", (newcash + CARD + Surcharge_Amt + VoucherAmount - Sp_Amount).ToString("0.00"))
        'DataGridView1.Rows.Add("6. House Grand Total", (House_amount + Surcharge_Amt).ToString("0.00"))

        Dim cash_summary As Double = (TotalField(dtBPayment.Rows, "CASH") - TotalField(dtBPayment.Rows, "Sp_Amount") + TotalField(dtAllPayment.Rows, "CASH") + cashAmount_adjusted) - (TotalField(dtBPayment.Rows, "CashOut") + TotalField(dtCashOut.Rows, "totalamount") + TotalField(dtAllPayment.Rows, "CashOut"))
        Dim card_summary As Double = TotalField(dtBPayment.Rows, "CARD") + TotalField(dtAllPayment.Rows, "CARD")
        Dim sur_summary As Double = TotalField(dtBPayment.Rows, "Surcharge_Amt") + TotalField(dtAllPayment.Rows, "Surcharge_Amt")
        Dim vouc_summary As Double = TotalField(dtBPayment.Rows, "VoucherAmount") + TotalField(dtAllPayment.Rows, "VoucherAmount")



        'DataGridView1.Rows.Add("1. Booking Total", (Total + cashAmount_adjusted).ToString("0.00"))
        DataGridView1.Rows.Add("   A. Total CASH", cash_summary.ToString("0.00"))
        'DataGridView1.Rows.Add("      CASH OUT to SP for CARD PAYMENT", Sp_Amount2.ToString("0.00"))
        'DataGridView1.Rows.Add("      CASH OUT to SP", Sp_Amount.ToString("0.00"))
        'DataGridView1.Rows.Add("      CASH IN HAND (TOTAL CASH - SP CASH OUT)", (newcash - Sp_Amount).ToString("0.00"))
        DataGridView1.Rows.Add("   B. CARD", (card_summary).ToString("0.00"))
        DataGridView1.Rows.Add("   C. ADMIN FEE", (sur_summary).ToString("0.00"))
        DataGridView1.Rows.Add("   D. VOUCHER", vouc_summary.ToString("0.00"))
        DataGridView1.Rows.Add("   E. Grand Total", (cash_summary + card_summary + sur_summary + vouc_summary).ToString("0.00"))
        'DataGridView1.Rows.Add("7. SP Grand Total", (Sp_Amount).ToString("0.00"))
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintList
        frm.PrintPreview(DataGridView1, "ADJUSTMENT REPORT", "Report From : " & dtpFrom.Value.ToString("dd/MM/yyyy HH:mm") & " To " & Now.ToString(" dd/MM/yyyy HH:mm"), "", "Abstract concept pvt ltd", False, "", False)
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Dim frm As New frmAdjustReport
        frm.txtTotalBooking.Text = totBooking
        frm.txtTotalCash.Text = cashAmount.ToString("0.00")
        Try
            frm.ntxtTotalBookin.Value = totBooking + totBooking_adjusted
        Catch ex As Exception
            frm.ntxtTotalBookin.Value = 1
        End Try

        Try
            frm.ntxtCashBookings.Value = cashAmount + cashAmount_adjusted
        Catch ex As Exception
            frm.ntxtCashBookings.Value = 1
        End Try
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            totBooking_adjusted = frm.ntxtTotalBookin.Value - totBooking
            cashAmount_adjusted = frm.ntxtCashBookings.Value - cashAmount
            GenrateReport(startTime, d2)
        End If
    End Sub

    Private Sub btnSaveAdjusted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAdjusted.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

            Dim od As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings


            od.StartDate = startTime
            od.Adjust_Cashamount = cashAmount_adjusted
            od.Adjust_TotalBooks = totBooking_adjusted

            MySettings.OtherSettings = od


            MsgBox("Saved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub btnClearDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDown.Click
        Dim Str As String = "Clearing Down from " & startTime.ToString & " To " & d2.ToString & vbNewLine


        If MsgBox(Str & vbNewLine & "Are you sure? " & vbNewLine & "Note : All Payment information will be erased from database. And also cannot undo clear down.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objBPayment.tblBookingPayments_DELETE_2("[CreatedDate]<=@Date", New List(Of SqlParameter) From {New SqlParameter("@Date", SqlDbType.DateTime) With {.Value = d2}})
          
            Dim od As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings


            od.StartDate = Now
            od.Adjust_Cashamount = 0
            od.Adjust_TotalBooks = 0

            MySettings.OtherSettings = od

            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnShowReport_Click(sender As System.Object, e As System.EventArgs) Handles btnShowReport.Click
        GenrateReport(startTime, DateTimePicker1.Value)
    End Sub

    Private Sub btn_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteBooking.Click
        Dim frm As New frmBookingDelete
        frm.dtpFrom = startTime
        frm.dtpTo = DateTimePicker1.Value
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            GenrateReport(startTime, DateTimePicker1.Value)
        End If
    End Sub

End Class