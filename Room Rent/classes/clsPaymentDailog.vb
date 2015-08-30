Public Class clsPaymentDailog

    Structure BookingPaymentReturn
        Dim CASH As Double
        Dim CARD As Double
        Dim SUR_AMT As Double
        Dim SUR_P As Double
        Dim VOUCHERID As Double
        Dim VOUCHER_AMT As Double
        'Dim CARD_TYPE As Double
        Dim MAIN_TOTAL_WITHOUT_GST As Double
        Dim MAIN_TOTAL_WITH_GST As Double
        Dim TIP As Double
        Dim CASHOUT As Double
        Dim UPGRADE As Double
      
        Dim SP_AMOUNT As Double
        Dim HOUSE_AMOUNT As Double
        Dim Room As String


        Dim BalanceAmount As Double
        Dim TOTAL_AMOUNT_PAID As Double
        Dim TOTAL_AMOUNT_PAYABLE As Double

        Dim GST As Double
        Dim PAYMENTMODE As String

        Dim IS_GST As Boolean
        Dim ISDAY As Boolean
        Dim ISCONTRA As Boolean


        Dim CAREFARE As Double
        Dim ESCORT_EXTENSION_FEES As Double

        Dim CardName As String


        Dim ESCORT_BOND_FEES As Double
    End Structure

    ''' <summary>
    ''' Used to shows the payment window.
    ''' </summary>
    ''' <param name="Room">Name of the room</param>
    ''' <param name="TotalAmount_With_GST">This the Amount to be charged from the client. Please note the amount must be including GST</param>
    ''' <param name="PaymentMode">Mode of payment (CASH, CARD or CASH/CARD)</param>
    ''' <param name="HouseAmt">House Amount</param>
    ''' <param name="WorkerAmount">SP Amount</param>
    ''' <param name="seperator">This is not a require varible. This is only used so that any future changes reflect error in main codes. Pass this value "{0}"</param>
    ''' <param name="ForceHideExtraButton">If False, must Pass the Values for [CurrentPrice] and [NightPrice] </param>
    ''' <param name="TIP_Enable">Enables TIP Textbox</param>
    ''' <param name="ShiftFeeEnable">Not Valid field</param>
    ''' <param name="IsGST"></param>
    ''' <param name="CurrentPrice"></param>
    ''' <param name="NightPrice"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Function BookingPayment(Room As String, TotalAmount_With_GST As Double, PaymentMode As String, HouseAmt As Double, WorkerAmount As Double, IsBondFees As Boolean, seperator As Byte(), _
                            Optional ForceHideExtraButton As Boolean = False, Optional TIP_Enable As Boolean = True, Optional ShiftFeeEnable As Boolean = True, Optional IsGST As Boolean = True, _
                            Optional CurrentPrice As cls_tblLookUp.PriceSpec = Nothing, Optional NightPrice As cls_tblLookUp.PriceSpec = Nothing, Optional ShowDialog As Boolean = True, Optional Sp_names As List(Of String) = Nothing, Optional ForceCash As Boolean = False, Optional TIP As Double = 0, Optional Upgrade As Double = 0, Optional CarFare As Double = 0, Optional EscExtFee As Double = 0, Optional BondFee As Double = 0, Optional Cash As Double = 0, Optional card As Double = 0, Optional VoucherId As Integer = 0, Optional VoucherAmount As Double = 0) As BookingPaymentReturn
        Dim ReturnP As New BookingPaymentReturn
        If PaymentMode = "" Then
            PaymentMode = "CASH"
        End If

        If Room = "ESCORT" Then
            Dim frmP As New frmPaymentEscort(Sp_names)
            frmP.NightPrice = NightPrice
            frmP.CurrentPrice = CurrentPrice
            frmP.isBond = IsBondFees
            frmP.forceHideBtns = ForceHideExtraButton
            frmP.txtTip.Enabled = TIP_Enable
            ' frmP.txtCashOut.Enabled = False
            frmP.txtShiftFee.Enabled = False
            frmP.selectedPaymentMode = PaymentMode
            frmP.txtTotalInGST.Text = TotalAmount_With_GST.ToString("0.00")
            frmP.txtHouse.Text = HouseAmt.ToString("0.00")
            frmP.txtWorkerAmount.Text = WorkerAmount.ToString("0.00")
            frmP.txtTip.Text = TIP.ToString("0.00")
            frmP.txtUpgrade.Text = Upgrade.ToString("0.00")
            frmP.txtCarFare.Text = CarFare.ToString("0.00")
            frmP.txtEscortExtFees.Text = EscExtFee.ToString("0.00")
            frmP.txtEscortBondFees.Text = BondFee.ToString("0.00")
            frmP.txtCash.Text = Cash.ToString("0.00")
            frmP.txtCard.Text = card.ToString("0.00")

            Dim dr As DialogResult = Nothing
            If ShowDialog Then
                dr = frmP.ShowDialog
            End If

            If ForceCash Then
                frmP.btnCard.Enabled = False
                frmP.btnCardCash.Enabled = False
            End If

            If dr = Windows.Forms.DialogResult.OK Or Not ShowDialog Then
                ReturnP.CASH = Val(frmP.txtCash.Text)
                ReturnP.CARD = Val(frmP.txtCard.Text)
                ReturnP.SUR_P = Val(frmP.txtSurchrgeP.Text)
                ReturnP.SUR_AMT = Val(frmP.txtSurchargeAmt.Text)
                ReturnP.VOUCHERID = frmP.VoucherId
                ReturnP.VOUCHER_AMT = Val(frmP.txtVoucherAmount.Text)
                ReturnP.MAIN_TOTAL_WITHOUT_GST = Val(frmP.txtTotalExGST.Text)
                ReturnP.MAIN_TOTAL_WITH_GST = Val(frmP.txtTotalInGST.Text)
                ReturnP.TIP = Val(frmP.txtTip.Text)
                ReturnP.CASHOUT = Val(frmP.txtCashOut.Text)
                ReturnP.UPGRADE = Val(frmP.txtUpgrade.Text)
                ReturnP.SP_AMOUNT = Val(frmP.txtWorkerAmount.Text)
                ReturnP.HOUSE_AMOUNT = Val(frmP.txtHouse.Text)
                ReturnP.Room = Room
                ReturnP.BalanceAmount = 0
                ReturnP.TOTAL_AMOUNT_PAID = Val(frmP.txtAmountPaid.Text)
                ReturnP.TOTAL_AMOUNT_PAYABLE = Val(frmP.txtGrandTotal.Text)
                ReturnP.GST = Val(frmP.txtGST.Text)
                ReturnP.PAYMENTMODE = frmP.selectedPaymentMode
                ReturnP.ISDAY = frmP.isDayPrice
                ReturnP.ISCONTRA = frmP.isContra
                ReturnP.IS_GST = IsGST
                ReturnP.CAREFARE = Val(frmP.txtCarFare.Text)
                ReturnP.ESCORT_EXTENSION_FEES = Val(frmP.txtEscortExtFees.Text)
                ReturnP.ESCORT_BOND_FEES = Val(frmP.txtEscortBondFees.Text)
                ReturnP.CardName = frmP.CardName
            Else
                Throw New Exception("Payment Denied")
            End If
        Else
            Dim frmP As New frmPaymentBooking(Sp_names)
            frmP.NightPrice = NightPrice
            frmP.CurrentPrice = CurrentPrice
            frmP.forceHideBtns = ForceHideExtraButton
            frmP.txtTip.Enabled = TIP_Enable

            ' frmP.txtCashOut.Enabled = False

            frmP.txtShiftFee.Enabled = False
            frmP.selectedPaymentMode = PaymentMode
            frmP.txtTotalInGST.Text = TotalAmount_With_GST.ToString("0.00")
            frmP.txtHouse.Text = HouseAmt.ToString("0.00")
            frmP.txtWorkerAmount.Text = WorkerAmount.ToString("0.00")

            frmP.txtTip.Text = TIP.ToString("0.00")
            frmP.txtUpgrade.Text = Upgrade.ToString("0.00")

            'frmP.txtCarFare.Text = CarFare.ToString("0.00")
            'frmP.txtEscortExtFees.Text = EscExtFee.ToString("0.00")
            'frmP.txtEscortBondFees.Text = BondFee.ToString("0.00")

            frmP.txtCash.Text = Cash.ToString("0.00")
            frmP.txtCard.Text = card.ToString("0.00")

            If ForceCash Then
                frmP.btnCard.Enabled = False
                frmP.btnCardCash.Enabled = False
            End If

            Dim dr As DialogResult = Nothing
            If ShowDialog Then
                dr = frmP.ShowDialog
            End If

            If dr = Windows.Forms.DialogResult.OK Or Not ShowDialog Then
                ReturnP.CASH = Val(frmP.txtCash.Text)
                ReturnP.CARD = Val(frmP.txtCard.Text)
                ReturnP.SUR_P = Val(frmP.txtSurchrgeP.Text)
                ReturnP.SUR_AMT = Val(frmP.txtSurchargeAmt.Text)
                ReturnP.VOUCHERID = frmP.VoucherId
                ReturnP.VOUCHER_AMT = Val(frmP.txtVoucherAmount.Text)
                ReturnP.MAIN_TOTAL_WITHOUT_GST = Val(frmP.txtTotalExGST.Text)
                ReturnP.MAIN_TOTAL_WITH_GST = Val(frmP.txtTotalInGST.Text)
                ReturnP.TIP = Val(frmP.txtTip.Text)
                ReturnP.CASHOUT = Val(frmP.txtCashOut.Text)
                ReturnP.UPGRADE = Val(frmP.txtUpgrade.Text)
                ReturnP.SP_AMOUNT = Val(frmP.txtWorkerAmount.Text)
                ReturnP.HOUSE_AMOUNT = Val(frmP.txtHouse.Text)
                ReturnP.Room = Room
                ReturnP.BalanceAmount = 0
                ReturnP.TOTAL_AMOUNT_PAID = Val(frmP.txtAmountPaid.Text)
                ReturnP.TOTAL_AMOUNT_PAYABLE = Val(frmP.txtGrandTotal.Text)
                ReturnP.GST = Val(frmP.txtGST.Text)
                ReturnP.PAYMENTMODE = frmP.selectedPaymentMode
                ReturnP.ISDAY = frmP.isDayPrice
                ReturnP.ISCONTRA = frmP.isContra
                ReturnP.IS_GST = IsGST
                ReturnP.CardName = frmP.CardName
            Else
                Throw New Exception("Payment Denied")
            End If
        End If
        Return ReturnP

    End Function




End Class
