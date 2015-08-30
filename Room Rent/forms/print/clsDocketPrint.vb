Imports System.IO
Imports System.Drawing.Printing


Public Class clsDocketPrint
    Dim objMemo As New cls_Temp_tblDocketMemo

    Function PrintMemo(ByVal MemoNo As Integer, _
                       ByVal Reportprinter2 As String, _
                       ByVal isPreview As Boolean, Optional ShowFooterSpace As Boolean = True, Optional ShowHeader As Boolean = True) As String

        Dim OutPutString As String = ""
        Dim drMemo As DataRow = objMemo.Selection(cls_Temp_tblDocketMemo.SelectionType.All, "MemoNo=" & MemoNo.ToString).Rows(0)
        Dim MemoDate As Date = drMemo("MemoDate")
        Try
            OutPutString = drMemo("PrintText").ToString
        Catch ex As Exception
        End Try

        Dim isPrint As Boolean = True
        If OutPutString = "" Then
            'Try

            'HEADER
            If ShowHeader Then
                OutPutString += "".PadLeft(CInt((32 - MySettings.CompanyName.Length) / 2)) & MySettings.CompanyName & vbNewLine
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.CompanyAddress.Replace(vbNewLine, ", ").Length) / 2)) & MySettings.CompanyAddress.Replace(vbNewLine, ", ") & vbNewLine
                OutPutString += "".PadLeft(Math.Floor((32 - ("PH : " & MySettings.CompanyPhone).Length) / 2)) & ("PH :" & MySettings.CompanyPhone) & vbNewLine
            End If

            'HEADER END

            OutPutString += "   " & "MEMO NO." & ": " & MemoNo.ToString.PadLeft(17) & vbNewLine
            OutPutString += "NUMBER_PART12345678" & vbNewLine
            OutPutString += "   " & "DATE".PadRight(8, ". ") & ": " & MemoDate.ToString("dd/MM/yy (ddd)").PadLeft(17) & vbNewLine
            OutPutString += "   " & "Time".PadRight(8, ". ") & ": " & MemoDate.ToString("hh:mm:ss tt").PadLeft(17) & vbNewLine
            OutPutString += "".PadLeft(32, ".") & vbNewLine


            Select Case drMemo("MemoType").ToString.ToUpper
                Case "LOCKER BOOKING".ToUpper
                    PrintLOCKERBOOKING(MemoNo, OutPutString)
                Case "Booking".ToUpper
                    PrintBooking(MemoNo, OutPutString)
                Case "ADD WORKER".ToUpper
                    PrintADDWORKER(MemoNo, OutPutString)
                Case "ADD CLIENT".ToUpper
                    PrintADDClient(MemoNo, OutPutString)
                Case "EXTEND SERVICE".ToUpper
                    PrintEXTENDSERVICE(MemoNo, OutPutString)
                Case "Door Charge".ToUpper
                    PrintDoorCharge(MemoNo, OutPutString)
                Case "Voucher".ToUpper
                    PrintVoucher(MemoNo, OutPutString)
                Case "Suspension".ToUpper
                    PrintSuspension(MemoNo, OutPutString) 'Not DONE
                Case "Cash Out".ToUpper
                    PrintCashOut(MemoNo, OutPutString)
                Case "Shift Fee".ToUpper
                    PrintShiftFee(MemoNo, OutPutString)
                Case "MERCHANDISE_SALE".ToUpper
                    PrintMerchandiseBill(MemoNo, OutPutString)
                Case "CUSTOM".ToUpper
                    PrintCustom(MemoNo, OutPutString)
                Case Else
                    'Dont Print if not developer PC
                    If Not DeveloperPC() Then
                        isPrint = False
                    Else
                        'Throw New Exception("Printing coding not done yet")
                    End If
            End Select


            If ShowFooterSpace Then
                'FOOTER
                OutPutString += "".PadLeft(32, ".") & vbNewLine
                'Middle
                OutPutString += "".PadLeft(Math.Floor((32 - ("WELCOME TO " & MySettings.CompanyName).Length) / 2)) & ("WELCOME TO " & MySettings.CompanyName) & vbNewLine
                If MySettings.MemoFooter1.Trim <> "" Then
                    OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter1.Length) / 2)) & MySettings.MemoFooter1 & vbNewLine
                End If
                If MySettings.MemoFooter2.Trim <> "" Then
                    OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter2.Length) / 2)) & MySettings.MemoFooter2 & vbNewLine
                End If
                If MySettings.MemoFooter3.Trim <> "" Then
                    OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter3.Length) / 2)) & MySettings.MemoFooter3 & vbNewLine
                End If
                'FOOTER END
                OutPutString += vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine + vbNewLine
            End If
            OutPutString += "".PadLeft(32, ".")
        End If

        If isPrint Then
            If Not isPreview Then
                Printing(Reportprinter2, OutPutString, "Memo No :- " & MemoNo)
            End If
            Return OutPutString
        Else
            Return Nothing
        End If

    End Function


    Sub PrintShiftFee(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim dtPayment As DataTable = (New cls_tblPayment).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString)
        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
          "   " & " *** AMENITIES MEMO *** ")
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim tip As Double = 0
        Dim cashout As Double = 0
        Dim booking As Double = dtPayment.Rows(0).Item("TotalAmount")
        Dim paymode As String = ""
        For Each dr As DataRow In dtPayment.Rows
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            tip += dr("tip")
            cashout += dr("cashout")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
        Next
        OutPutString += "   " & "FEE".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine
        If cashout > 0 Then
            OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If tip > 0 Then
            OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If cashout > 0 Or tip > 0 Then
            OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + (cashout + booking + tip).ToString("0.00")).PadLeft(8) & vbNewLine
        End If

        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        If cash > 0 Then
            OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If CARD > 0 Then
            OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
    End Sub
    Sub PrintCashOut(ByVal MemoNo As Integer, ByRef OutPutString As String)

        Dim dtPayment As DataTable = (New cls_tblPayment).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString)
        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
          "   " & " **** CASH OUT MEMO **** ")
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim tip As Double = 0
        Dim booking As Double = dtPayment.Rows(0).Item("TotalAmount")
        Dim paymode As String = ""
        For Each dr As DataRow In dtPayment.Rows
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            tip += dr("tip")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
        Next
        OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine


        If tip > 0 Then
            OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + (booking + tip).ToString("0.00")).PadLeft(8) & vbNewLine
        End If

        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        If cash > 0 Then
            OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If CARD > 0 Then
            OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        End If

        OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub
    Sub PrintSuspension(ByVal MemoNo As Integer, ByRef OutPutString As String)

    End Sub
    Sub PrintVoucher(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim dtPayment As DataTable = (New cls_tblPayment).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString)
        Dim VoucherID As Integer = dtPayment.Rows(0).Item("Transc_ID")
        Dim dtVoucher As DataTable = (New cls_Temp_tblVouchers).Selection(cls_Temp_tblVouchers.SelectionType.All, "VoucherID=" & VoucherID.ToString)

        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
          "   " & " **** VOUCHER MEMO **** ")
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim cashout As Double = 0
        Dim tip As Double = 0
        Dim booking As Double = dtPayment.Rows(0).Item("TotalAmount")
        Dim paymode As String = ""
        OutPutString += "   " & "REFERENCE NO.".PadRight(16, ". ") & ": " & dtVoucher.Rows(0).Item("RefNo").ToString.PadLeft(8) & vbNewLine

        For Each dr As DataRow In dtPayment.Rows
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            cashout += dr("cashout")
            tip += dr("tip")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
        Next

        OutPutString += "   " & "VOUCHER AMOUNT".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine
        If cashout > 0 Then
            OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If tip > 0 Then
            OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + (cashout + booking + tip).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        If cash > 0 Then
            OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If CARD > 0 Then
            OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + +surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
    End Sub
    Sub PrintDoorCharge(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim drInstant As DataRow = (New cls_tblInstant).Selection("MemoNo=" & MemoNo.ToString).Rows(0)
        Dim dtPayment As DataTable = (New cls_tblPayment).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString)

        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
          "   " & "DOOR CHARGE NO." & ": " & drInstant("InstantID"))

        OutPutString += "   " & "DOOR CHARGE".PadRight(16, ". ") & ": " & (currency + Val(drInstant("DoorCharge")).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "DOOR".PadRight(16, ". ") & ": " & drInstant("DoorName").ToString & vbNewLine
        If drInstant("QTY") > 1 Then
            OutPutString += "   " & "TICKET QTY".PadRight(16, ". ") & ": " & Val(drInstant("QTY")).ToString("0").PadLeft(8) & vbNewLine
        End If

        Dim tip As Double = 0
        Dim shift_fee As Double = 0
        Dim cashout As Double = 0
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim voucher As Double = 0
        Dim booking As Double = drInstant("TotalAmount")
        Dim paymode As String = ""
        For Each dr As DataRow In dtPayment.Rows
            tip += dr("Tip")
            'shift_fee += dr("ShiftFee")
            cashout += dr("CashOut")
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            voucher += dr("VoucherAmount")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
        Next
        OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine
        If tip > 0 Then
            OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If shift_fee > 0 Then
            OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If cashout > 0 Then
            OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If tip + cashout + shift_fee > 0 Then
            OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (booking + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        If cash > 0 Then
            OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If CARD > 0 Then
            OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If voucher > 0 Then
            OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub
    Sub PrintEXTENDSERVICE(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim drBooking As DataRow = (New cls_Temp_tblBookings).Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingID in (select BookingID from tblExtraService where MemoNo=" & MemoNo.ToString & ")").Rows(0)
        Dim BookingId As String = drBooking("BookingID")
        Dim dtWorkers As DataTable = (New cls_tblActiveWorker).tblActiveWorker_Selection(0, "a.WorkerID in (select WorkerID from tblExtraService where MemoNo=" & MemoNo.ToString & ") and a.BookingId=" & BookingId)
        Dim dtService As DataTable = (New cls_tblExtraService).Selection(cls_tblExtraService.SelectionType.ALL, "MemoNo=" & MemoNo.ToString)
        Dim dtPayment As DataTable = (New cls_Temp_tblBookingPayments).Selection(cls_Temp_tblBookingPayments.SelectionType.All, "MemoNo=" & MemoNo.ToString)
        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
             "   " & " ** EXTEND SERVICE MEMO ** " & vbNewLine & _
         "   " & "BOOKING/TICKET NO." & ": " & drBooking("DisplayBookingId"))
        Dim service As Integer = 0
        Dim tip As Double = 0
        Dim shift_fee As Double = 0
        Dim cashout As Double = 0
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim sp_amount As Double = 0
        Dim surcharge As Double = 0
        Dim voucher As Double = 0
        Dim totalAmount As Double = 0
        Dim paymode As String = ""
        Dim vselectedServiceType As String = ""

        For Each dr As DataRow In dtService.Rows
            service = dr("Service")
            Try
                vselectedServiceType = dr("ServiceType")
            Catch ex As Exception

            End Try
        Next
        For Each dr As DataRow In dtPayment.Rows
            totalAmount += dr("Total")
            tip += dr("Tip")
            shift_fee += dr("ShiftFee")
            cashout += dr("CashOut")
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            voucher += dr("VoucherAmount")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
            sp_amount += dr("sp_amount")
        Next

        If MySettings.SpecialServiceEnabled Then
            OutPutString += "   " & "DURATION".PadRight(10, ". ") & ": " & service.ToString & " Mins" & " " & vselectedServiceType & vbNewLine
        Else
            OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & vbNewLine
        End If

        'OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & IIf(MySettings.SpecialServiceEnabled, " " & vselectedServiceType, "") & vbNewLine
        OutPutString += "   " & "ROOM".PadRight(16, ". ") & ": " & drBooking("Room").ToString & vbNewLine

        Try
            Dim str As String = ""
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str = "" Then
                        str += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName("WorkerName") & vbNewLine
                    Else
                        str += "   " & " ".PadRight(16, "  ") & ": " & workerName("WorkerName") & vbNewLine
                    End If
                End If
            Next
            OutPutString += str
        Catch ex As Exception
        End Try



        'OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + totalAmount.ToString("0.00")).PadLeft(8) & vbNewLine
        'If tip > 0 Then
        '    OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If shift_fee > 0 Then
        '    OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If cashout > 0 Then
        '    OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If tip + cashout + shift_fee > 0 Then
        '    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (totalAmount + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        'If cash > 0 Then
        '    OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If CARD > 0 Then
        '    OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
        '    OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "AMOUNT".PadRight(16, ". ") & ": " & (currency + sp_amount.ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub
    Sub PrintADDWORKER(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim drBooking As DataRow = (New cls_Temp_tblBookings).Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingID in (select BookingID from tblExtraService where MemoNo=" & MemoNo.ToString & ")").Rows(0)
        Dim BookingId As String = drBooking("BookingID")
        Dim dtWorkers As DataTable = (New cls_tblActiveWorker).tblActiveWorker_Selection(0, "a.WorkerID in (select WorkerID from tblExtraService where MemoNo=" & MemoNo.ToString & ") and a.BookingId=" & BookingId)
        Dim dtService As DataTable = (New cls_tblExtraService).Selection(cls_tblExtraService.SelectionType.ALL, "MemoNo=" & MemoNo.ToString)
        Dim dtPayment As DataTable = (New cls_Temp_tblBookingPayments).Selection(cls_Temp_tblBookingPayments.SelectionType.All, "MemoNo=" & MemoNo.ToString)
        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
             "   " & " ** ADD SP MEMO ** " & vbNewLine & _
         "   " & "BOOKING/TICKET NO." & ": " & drBooking("DisplayBookingId"))
        Dim service As Integer = 0
        Dim tip As Double = 0
        Dim shift_fee As Double = 0
        Dim cashout As Double = 0
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim sp_amount As Double = 0
        Dim surcharge As Double = 0
        Dim voucher As Double = 0
        Dim totalAmount As Double = 0
        Dim paymode As String = ""
        Dim vselectedServiceType As String = ""

        For Each dr As DataRow In dtService.Rows
            service = dr("Service")
            Try
                vselectedServiceType = dr("ServiceType")
            Catch ex As Exception

            End Try
        Next
        For Each dr As DataRow In dtPayment.Rows
            totalAmount += dr("Total")
            tip += dr("Tip")
            shift_fee += dr("ShiftFee")
            cashout += dr("CashOut")
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            voucher += dr("VoucherAmount")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
            sp_amount += dr("sp_amount")
        Next

        'OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & IIf(MySettings.SpecialServiceEnabled, " " & vselectedServiceType, "") & vbNewLine
        If MySettings.SpecialServiceEnabled Then
            OutPutString += "   " & "DURATION".PadRight(10, ". ") & ": " & service.ToString & " Mins" & " " & vselectedServiceType & vbNewLine
        Else
            OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & vbNewLine
        End If
        OutPutString += "   " & "ROOM".PadRight(16, ". ") & ": " & drBooking("Room").ToString & vbNewLine

        Try
            Dim str As String = ""
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str = "" Then
                        str += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName("WorkerName") & vbNewLine
                    Else
                        str += "   " & " ".PadRight(16, "  ") & ": " & workerName("WorkerName") & vbNewLine
                    End If
                End If
            Next
            OutPutString += str
        Catch ex As Exception
        End Try



        'OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + totalAmount.ToString("0.00")).PadLeft(8) & vbNewLine
        'If tip > 0 Then
        '    OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If shift_fee > 0 Then
        '    OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If cashout > 0 Then
        '    OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If tip + cashout + shift_fee > 0 Then
        '    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (totalAmount + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        'If cash > 0 Then
        '    OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If CARD > 0 Then
        '    OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
        '    OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "AMOUNT".PadRight(16, ". ") & ": " & (currency + sp_amount.ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub

    Sub PrintADDClient(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim drBooking As DataRow = (New cls_Temp_tblBookings).Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingID in (select BookingID from tblBookingPayments where MemoNo=" & MemoNo.ToString & ")").Rows(0)
        Dim BookingId As String = drBooking("BookingID")
        Dim dtWorkers As DataTable = (New cls_tblActiveWorker).tblActiveWorker_Selection(0, "a.WorkerID in (select WorkerID from tblBookingPayments where MemoNo=" & MemoNo.ToString & ") and a.BookingId=" & BookingId)
        Dim dtService As DataTable = (New cls_tblExtraService).Selection(cls_tblExtraService.SelectionType.ALL, "BookingID=" & BookingId.ToString)
        Dim dtPayment As DataTable = (New cls_Temp_tblBookingPayments).Selection(cls_Temp_tblBookingPayments.SelectionType.All, "MemoNo=" & MemoNo.ToString)
        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
             "   " & "   ** ADD CLIENT MEMO ** " & vbNewLine & _
         "   " & "BOOKING/TICKET NO." & ": " & drBooking("DisplayBookingId")) 'DisplayBookingId
        Dim service As Integer = 0
        Dim tip As Double = 0
        Dim shift_fee As Double = 0
        Dim cashout As Double = 0
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim sp_amount As Double = 0
        Dim surcharge As Double = 0
        Dim voucher As Double = 0
        Dim totalAmount As Double = 0
        Dim paymode As String = ""
        Dim vselectedServiceType As String = ""

        For Each dr As DataRow In dtService.Rows
            service = dr("Service")
            Try
                vselectedServiceType = dr("ServiceType")
            Catch ex As Exception

            End Try
        Next

        For Each dr As DataRow In dtPayment.Rows
            totalAmount += dr("Total")
            tip += dr("Tip")
            shift_fee += dr("ShiftFee")
            cashout += dr("CashOut")
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            voucher += dr("VoucherAmount")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
            sp_amount += dr("sp_amount")
        Next

        'OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & IIf(MySettings.SpecialServiceEnabled, " " & vselectedServiceType, "") & vbNewLine
        If MySettings.SpecialServiceEnabled Then
            OutPutString += "   " & "DURATION".PadRight(10, ". ") & ": " & service.ToString & " Mins" & " " & vselectedServiceType & vbNewLine
        Else
            OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & vbNewLine
        End If
        OutPutString += "   " & "ROOM".PadRight(16, ". ") & ": " & drBooking("Room").ToString & vbNewLine

        Try
            Dim str As String = ""
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str = "" Then
                        str += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName("WorkerName") & vbNewLine
                    Else
                        str += "   " & " ".PadRight(16, "  ") & ": " & workerName("WorkerName") & vbNewLine
                    End If
                End If
            Next
            OutPutString += str
        Catch ex As Exception
        End Try



        'OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + totalAmount.ToString("0.00")).PadLeft(8) & vbNewLine
        'If tip > 0 Then
        '    OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If shift_fee > 0 Then
        '    OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If cashout > 0 Then
        '    OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If tip + cashout + shift_fee > 0 Then
        '    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (totalAmount + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        'If cash > 0 Then
        '    OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If CARD > 0 Then
        '    OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
        '    OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "AMOUNT".PadRight(16, ". ") & ": " & (currency + sp_amount.ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub

    Sub PrintBooking(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim drBooking As DataRow = (New cls_Temp_tblBookings).Selection(cls_Temp_tblBookings.SelectionType.All_View, "MemoNo=" & MemoNo.ToString).Rows(0)
        Dim dtWorkers As DataTable = (New cls_tblActiveWorker).tblActiveWorker_Selection(0, "a.MemoNo=" & MemoNo.ToString)
        Dim dtService As DataTable = (New cls_tblExtraService).Selection(cls_tblExtraService.SelectionType.ALL, "MemoNo=" & MemoNo.ToString)
        Dim dtPayment As DataTable = (New cls_Temp_tblBookingPayments).Selection(cls_Temp_tblBookingPayments.SelectionType.All, "MemoNo=" & MemoNo.ToString)

        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
         "   " & "BOOKING/TICKET NO." & ": " & drBooking("DisplayBookingId"))

        Dim service As Integer = 0
        Dim tip As Double = 0
        Dim shift_fee As Double = 0
        Dim cashout As Double = 0
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim voucher As Double = 0
        ' Dim booking As Double = drBooking("TotalAmount")
        Dim paymode As String = ""
        Dim sp_amount As Double = 0
        Dim vselectedServiceType As String = ""

        For Each dr As DataRow In dtService.Rows
            service += dr("Service")
            Try
                vselectedServiceType = dr("ServiceType")
            Catch ex As Exception
            End Try
        Next
        If MySettings.SpecialServiceEnabled Then
            OutPutString += "   " & "DURATION".PadRight(10, ". ") & ": " & service.ToString & " Mins" & " " & vselectedServiceType & vbNewLine
        Else
            OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service.ToString & " Mins" & vbNewLine
        End If
        OutPutString += "   " & "ROOM".PadRight(16, ". ") & ": " & drBooking("Room").ToString & vbNewLine

        Try
            Dim str As String = ""
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str = "" Then
                        str += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName("WorkerName") & vbNewLine
                    Else
                        str += "   " & " ".PadRight(16, "  ") & ": " & workerName("WorkerName") & vbNewLine
                    End If
                End If
            Next
            OutPutString += str
        Catch ex As Exception
        End Try

        For Each dr As DataRow In dtPayment.Rows
            tip += dr("Tip")
            shift_fee += dr("ShiftFee")
            cashout += dr("CashOut")
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            voucher += dr("VoucherAmount")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
            sp_amount += dr("sp_amount")
        Next

        'OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine
        'If tip > 0 Then
        '    OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If shift_fee > 0 Then
        '    OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If cashout > 0 Then
        '    OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If tip + cashout + shift_fee > 0 Then
        '    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (booking + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        'If cash > 0 Then
        '    OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If CARD > 0 Then
        '    OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
        '    OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        'OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "AMOUNT".PadRight(16, ". ") & ": " & (currency + sp_amount.ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub
    Sub PrintLOCKERBOOKING(ByVal MemoNo As Integer, ByRef OutPutString As String)
        Dim dtPayment As DataTable = (New cls_tblPayment).Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString)
        Dim LockerBookingID As Integer = dtPayment.Rows(0).Item("Transc_ID")
        Dim dtlockerbooking As DataTable = (New cls_tblLockerBooking).Selection(cls_tblLockerBooking.SelectionType.ALL, "Sl=" & LockerBookingID.ToString)

        OutPutString = OutPutString.Replace("NUMBER_PART12345678", _
         "   " & "LOCKER TICKET NO." & ": " & LockerBookingID)
        Dim cash As Double = 0
        Dim CARD As Double = 0
        Dim surcharge As Double = 0
        Dim cashout As Double = 0
        Dim tip As Double = 0
        ' Dim voucher As Double = 0
        Dim booking As Double = dtPayment.Rows(0).Item("TotalAmount")
        Dim paymode As String = ""
        OutPutString += "   " & "LOCKER NO.".PadRight(16, ". ") & ": " & dtlockerbooking.Rows(0).Item("LockerNumber").ToString.PadLeft(8) & vbNewLine
        OutPutString += "   " & "SP NAME.".PadRight(16, ". ") & ": " & dtlockerbooking.Rows(0).Item("ClientName").ToString.PadLeft(8) & vbNewLine

        For Each dr As DataRow In dtPayment.Rows
            cash += dr("CASH")
            CARD += dr("CARD")
            surcharge += dr("Surcharge_Amt")
            tip += dr("tip")
            cashout += dr("CashOut")
            If paymode = "" Then
                paymode = dr("PaymentMode")
            End If
        Next
        OutPutString += "   " & "LOCKER AMOUNT".PadRight(16, ". ") & ": " & (currency + booking.ToString("0.00")).PadLeft(8) & vbNewLine
        If cashout > 0 Then
            OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If tip > 0 Then
            OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + (cashout + booking + tip).ToString("0.00")).PadLeft(8) & vbNewLine
        OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
        If cash > 0 Then
            OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        If CARD > 0 Then
            OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + CARD.ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
        End If
        'If voucher > 0 Then
        '    OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
        'End If
        OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + CARD + +surcharge).ToString("0.00")).PadLeft(8) & vbNewLine

    End Sub
    Sub PrintMerchandiseBill(ByVal MemoNo As Integer, ByRef OutputString As String)
        Dim BillNo As Integer = (New cls_tblPayment).Selection(cls_Temp_tblBill.SelectionType.All, "MemoNo=" & MemoNo.ToString).Rows(0).Item("Transc_ID").ToString
        Dim objProduct As New cls_Temp_tblProducts
        Dim objBill As New cls_Temp_tblBill
        Dim objBillItems As New cls_tblBillItems
        Dim objPayment As New cls_tblPayment

        Dim drBill As DataRow = objBill.Selection(cls_Temp_tblBill.SelectionType.All, "BillID=" & BillNo).Rows(0)
        Dim dtBillItems As DataTable = objBillItems.Selection(cls_tblBillItems.SelectionType.ALL, "BillID=" & BillNo)
        Dim drBPaymnet As DataRow = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_ID=" & BillNo.ToString & " And Transac_Type='MERCHANDISE_SALE'").Rows(0)
        Try
            OutputString = OutputString.Replace("NUMBER_PART12345678", _
                         "   " & "BILL NO." & ": " & BillNo.ToString.PadLeft(17))

            OutputString += "   " & "SL ITEM    QTY  PRICE TOTAL" & vbNewLine
            Dim cnt As Integer = 1
            For Each dr As DataRow In dtBillItems.Rows
                Dim item As String = objProduct.Selection(cls_Temp_tblProducts.SelectionType.All, "ProductID=" & dr("ProductID")).Rows(0).Item("ProductName").ToString
                Dim item2 As String = ""
                Try
                    item2 = objProduct.Selection(cls_Temp_tblProducts.SelectionType.All, "ProductID=" & dr("ProductID")).Rows(0).Item("CodeName").ToString
                    If item2 <> "" Then
                        item = item2
                    End If

                Catch ex As Exception
                End Try

                OutputString += "   " & cnt.ToString.PadRight(2)
                Try
                    If item.Length > 8 Then
                        OutputString += item.Substring(0, 8).ToString.PadRight(9)
                    Else
                        OutputString += item.ToString.PadRight(9)
                    End If
                    'OutputString += IIf(item.Length > 8, item.Substring(0, 8), item).ToString.PadRight(9)
                Catch ex As Exception
                    OutputString += "".PadRight(9)
                End Try
                OutputString += dr("QTY").ToString.PadLeft(2)
                OutputString += Val(dr("Price")).ToString("0.0").PadLeft(7)
                OutputString += Val(dr("SubTotal")).ToString("0.0").PadLeft(7) & vbNewLine
                cnt += 1
            Next


            OutputString += "".PadLeft(32, ".") & vbNewLine
            OutputString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("TotalAmount")).ToString("0.00")).PadLeft(9) & vbNewLine
            If Val(drBPaymnet("cashout")) > 0 Then
                OutputString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("cashout")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If
            If Val(drBPaymnet("tip")) > 0 Then
                OutputString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("tip")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If
            If Val(drBPaymnet("cashout")) > 0 Or Val(drBPaymnet("tip")) > 0 Then
                OutputString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (Val(drBPaymnet("TotalAmount")) + Val(drBPaymnet("cashout")) + Val(drBPaymnet("tip"))).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            OutputString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & drBPaymnet("PaymentMode").PadLeft(9) & vbNewLine
            If Val(drBPaymnet("CASH")) > 0 Then
                OutputString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            If Val(drBPaymnet("CARD")) > 0 Then
                OutputString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CARD")).ToString("0.00")).PadLeft(9) & vbNewLine
                OutputString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            If Val(drBPaymnet("VoucherAmount")) > 0 Then
                OutputString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("VoucherAmount")).ToString("0.00")).PadLeft(9) & vbNewLine

            End If
            OutputString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH") + drBPaymnet("CARD") + drBPaymnet("VoucherAmount") + drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(9) & vbNewLine

        Catch ex As Exception
        End Try


    End Sub

    Sub PrintCustom(ByVal MemoNo As Integer, ByRef OutputString As String)
        Dim objPayment As New cls_tblPayment

        Dim drBPaymnet As DataRow = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "MemoNo=" & MemoNo.ToString & " And Transac_Type='CUSTOM'").Rows(0)
        Try
            OutputString = OutputString.Replace("NUMBER_PART12345678", _
                         "          CUSTOM PAYMENT") '& "CUSTOM PAYMENT NO." & ": " & MemoNo.ToString.PadLeft(17))

            OutputString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("TotalAmount")).ToString("0.00")).PadLeft(9) & vbNewLine
            If Val(drBPaymnet("cashout")) > 0 Then
                OutputString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("cashout")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If
            If Val(drBPaymnet("tip")) > 0 Then
                OutputString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("tip")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If
            If Val(drBPaymnet("cashout")) > 0 Or Val(drBPaymnet("tip")) > 0 Then
                OutputString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (Val(drBPaymnet("TotalAmount")) + Val(drBPaymnet("cashout")) + Val(drBPaymnet("tip"))).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            OutputString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & drBPaymnet("PaymentMode").PadLeft(9) & vbNewLine
            If Val(drBPaymnet("CASH")) > 0 Then
                OutputString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            If Val(drBPaymnet("CARD")) > 0 Then
                OutputString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CARD")).ToString("0.00")).PadLeft(9) & vbNewLine
                OutputString += "   " & "ADMIN FEE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(9) & vbNewLine
            End If

            If Val(drBPaymnet("VoucherAmount")) > 0 Then
                OutputString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("VoucherAmount")).ToString("0.00")).PadLeft(9) & vbNewLine

            End If
            OutputString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH") + drBPaymnet("CARD") + drBPaymnet("VoucherAmount") + drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(9) & vbNewLine

        Catch ex As Exception
        End Try


    End Sub


    Shared Sub PrintDocketMemo(ByVal MemoNo As Integer)
        Dim frmMem As New clsDocketPrint
        If MyLocalSettings.ReceiptPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                frmMem.PrintMemo(MemoNo, frm.PrinterSettings.PrinterName, False)
            End If
        Else
            frmMem.PrintMemo(MemoNo, MyLocalSettings.ReceiptPrinter, False)
        End If
    End Sub


    Shared Sub ShowDocketMemo(ByVal MemoNo As Integer)
        Dim frmMem As New clsDocketPrint
        Dim str As String = frmMem.PrintMemo(MemoNo, "", True)
        Dim frm As New frmShowMemo
        frm.TextBox1.Text = str
        frm.ShowDialog()
    End Sub
    Shared Sub ShowBookingNo(ByVal BookingID As Integer)

        Dim strQuery As String = <SQL><![CDATA[

select distinct memono  from 

(select memoNo, bookingid from tblbookings union all 
select memoNo, bookingid from tblactiveworker union all 
select memoNo, bookingid from tblextraservice) 
a where a .bookingid = ]]></SQL>.Value

        Dim dt As New DataTable
        Dim con As SqlConnection = Nothing
        Try
            con = (New clsConnection).connect
        Catch ex As Exception
        End Try
        Dim str As String = ""
        Dim frmMem As New clsDocketPrint
        Try
            Dim da As New SqlDataAdapter(strQuery & " " & BookingID.ToString, con)
            da.Fill(dt)
            Dim c As Integer = 0
            For Each dr As DataRow In dt.Rows
                str += frmMem.PrintMemo(dr("MemoNo"), "", True, c + 1 = dt.Rows.Count, c = 0) & vbNewLine & vbNewLine & vbNewLine
                c += 1
            Next
        Catch ex As Exception
        End Try
        Dim frm As New frmShowMemo
        frm.TextBox1.Text = str
        frm.ShowDialog()
    End Sub
    Private printFont As Font
    Private streamToPrint As StringReader
    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = (ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)) - 2

        ' Iterate over the file, printing each line.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
                yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub
    Public Sub Printing(ByVal PrinterName_ As String, ByVal TextToPrint As String, Optional ByVal DocName As String = "", Optional ByVal PaperName As String = "Envelope", Optional Landscape As Boolean = False, Optional pFont As Font = Nothing)
        Try
            streamToPrint = New StringReader(TextToPrint)
            Try
                If pFont Is Nothing Then
                    Try
                        'printFont = New Font("Fixedsys", 10)
                        printFont = New Font("Fixedsys Neo+", 10)
                    Catch ex As Exception
                        printFont = New Font("Lucida Console", 10)
                    End Try
                Else
                    printFont = pFont
                End If

                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage

                Try
                    Dim printerformat As System.Drawing.Printing.PaperSize
                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                    PrinterObj.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName
                    For Each printerformat In PrinterObj.PaperSizes()
                        Try
                            If PaperName = printerformat.PaperName Then
                                pd.DefaultPageSettings.PaperSize = printerformat
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    pd.DefaultPageSettings.Margins.Top = 3
                    pd.DefaultPageSettings.Margins.Left = 1
                    pd.DefaultPageSettings.Margins.Bottom = 1
                    pd.DefaultPageSettings.Margins.Right = 1
                    pd.DefaultPageSettings.Landscape = Landscape
                    pd.PrinterSettings.PrinterName = PrinterName_
                Catch ex As Exception
                End Try

                pd.DocumentName = DocName
                pd.Print()

            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Printing2(ByVal PrinterName_ As String, ByVal TextToPrint As String, Optional ByVal DocName As String = "", Optional ByVal PaperName As String = "A4")
        Try

            streamToPrint = New StringReader(TextToPrint)
            Try

                printFont = New Font("Courier New", 8)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage

                Try
                    Dim printerformat As System.Drawing.Printing.PaperSize
                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                    PrinterObj.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName

                    For Each printerformat In PrinterObj.PaperSizes()
                        Try
                            If PaperName = printerformat.PaperName Then
                                pd.DefaultPageSettings.PaperSize = printerformat
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    pd.DefaultPageSettings.Margins.Top = 3
                    pd.DefaultPageSettings.Margins.Left = 1
                    pd.DefaultPageSettings.Margins.Bottom = 1
                    pd.DefaultPageSettings.Margins.Right = 1
                    pd.DefaultPageSettings.Landscape = True
                    pd.PrinterSettings.PrinterName = PrinterName_
                Catch ex As Exception
                End Try
                pd.DocumentName = DocName
                pd.Print()

            Finally
                streamToPrint.Close()
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
