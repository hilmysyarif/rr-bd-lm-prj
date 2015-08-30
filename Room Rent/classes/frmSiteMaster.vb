Public Class frmSiteMaster
    Dim objCounter As New cls_Temp_tblDailyCounter
    Public Sub ParentSetRainbow()
        If isRainBow Then
            btnAdmin.FlatStyle = FlatStyle.Flat
            btnCheckIN.FlatStyle = FlatStyle.Flat
            btnCashOut.FlatStyle = FlatStyle.Flat
            btnLocker.FlatStyle = FlatStyle.Flat
            btnLogin.FlatStyle = FlatStyle.Flat
            btnMechandise.FlatStyle = FlatStyle.Flat
            btnMembership.FlatStyle = FlatStyle.Flat
            btnPreBooking.FlatStyle = FlatStyle.Flat
            btnShiftFee.FlatStyle = FlatStyle.Flat
            btnSuspensions.FlatStyle = FlatStyle.Flat
            btnVouchers.FlatStyle = FlatStyle.Flat
            btnWorkerLookUp.FlatStyle = FlatStyle.Flat
            btnCounter.FlatStyle = FlatStyle.Flat
            grpMiscellanous.ForeColor = Color.WhiteSmoke
        Else
            btnAdmin.FlatStyle = FlatStyle.Standard
            btnCheckIN.FlatStyle = FlatStyle.Standard
            btnCashOut.FlatStyle = FlatStyle.Standard
            btnLocker.FlatStyle = FlatStyle.Standard
            btnLogin.FlatStyle = FlatStyle.Standard
            btnMechandise.FlatStyle = FlatStyle.Standard
            btnMembership.FlatStyle = FlatStyle.Standard
            btnPreBooking.FlatStyle = FlatStyle.Standard
            btnShiftFee.FlatStyle = FlatStyle.Standard
            btnSuspensions.FlatStyle = FlatStyle.Standard
            btnVouchers.FlatStyle = FlatStyle.Standard
            btnWorkerLookUp.FlatStyle = FlatStyle.Standard
            btnCounter.FlatStyle = FlatStyle.Standard
            grpMiscellanous.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnMechandise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMechandise.Click
        frmMerchandiseSale.Show()

        frmMerchandiseSale.Activate()
    End Sub
    Private Sub btnPreBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreBooking.Click
        frmPreBookingHome.Show()
        frmPreBookingHome.Activate()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        frmWorkerLogin.ShowDialog()
    End Sub

    Private Sub btnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmin.Click
        Dim frm As New dlgAdminPass
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If frm.TextBox1.Text = MySettings.Password Then
                frmAdmin.Show()
                frmAdmin.Activate()
            Else
                MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
            End If
        Else
            MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub btnWorkerLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkerLookUp.Click
        frmWorkerLookUp.Show()
        frmWorkerLookUp.Activate()
    End Sub

    Private Sub frmMainMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnCounter.Text = "COUNTER" + vbNewLine + "(" + objCounter.Selection(cls_Temp_tblDailyCounter.SelectionType.TODAY_COUNT).Rows.Count.ToString + ")"
        Catch ex As Exception
        End Try

        'Me.BackColor = mdlColors.formBackColor
        'Me.ForeColor = mdlColors.formForeColor
    End Sub

    Private Sub btnLocker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocker.Click
        frmLockers2.Show()
        frmLockers2.Activate()
    End Sub

    Private Sub btnMembership_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMembership.Click
        frmMembership.Show()
        frmMembership.Activate()
    End Sub

    Private Sub btnCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounter.Click
        objCounter.Insert(Now, "", "", "")
        btnCounter.Text = "COUNTER" + vbNewLine + "(" + objCounter.Selection(cls_Temp_tblDailyCounter.SelectionType.TODAY_COUNT).Rows.Count.ToString + ")"
    End Sub

    Private Sub btnCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashOut.Click
        Dim cashout As Double = 0
        If MsgBox("Are you sure for CASH OUT?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CASH OUT") = MsgBoxResult.Yes Then
            Dim frmc As New dlgAmount
            frmc.Text = "CASH OUT"
            If frmc.ShowDialog = vbOK Then
                cashout = Val(frmc.txtAmount.Text)
                Dim frm As New frmPaymentOthers
                'frm.txtTip.ReadOnly = True
                frm.txtCashOut.Text = cashout.ToString("0.00")
                frm.selectedPaymentMode = "CARD"
                frm.btnCash.Enabled = False
                frm.btnVouchers.Enabled = False
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objPayment As New cls_tblPayment
                    cashout = Val(frm.txtCashOut.Text)
                    Dim objDocket As New cls_Temp_tblDocketMemo
                    Dim MemoNo As Integer = objDocket.Insert("CASH OUT", Now, "", "")
                    objPayment.Insert("CASH OUT", cashout, "0", Now, Val(frm.txtCash.Text), Val(frm.txtCard.Text), Val(frm.txtSurchrgeP.Text), Val(frm.txtSurchargeAmt.Text), "PAID", frm.selectedPaymentMode, cashout + Val(frm.txtSurchargeAmt.Text) + Val(frm.txtCash.Text), "", 0, 0, MemoNo, 0, Val(frm.txtTip.Text), Val(frm.txtGST.Text), LoginUserId)
                    clsDocketPrint.PrintDocketMemo(MemoNo)

                End If
            End If
        End If
    End Sub

    Private Sub btnVouchers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVouchers.Click
        frmVoucherAdd.Show()
        frmVoucherAdd.Activate()
    End Sub

    Private Sub btnAvailableWorker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuspensions.Click
        frmSPNotAvailableList.Show()
        frmSPNotAvailableList.Activate()
    End Sub

    Private Sub btnShiftFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftFee.Click
        Dim ShiftFee As Double = 0
        Dim frmc As New dlgAmount
        frmc.Text = "AMENITIES"
        If frmc.ShowDialog = vbOK Then
            ShiftFee = Val(frmc.txtAmount.Text)
            Dim CashAmt As Double = 0
            Dim CardAmt As Double = 0
            Dim SurchargAmt As Double = 0
            Dim SurchargP As Double = 0
            Dim PaymentMode As String = ""
            Dim sPrice As Double = ShiftFee
            Dim total As Double = sPrice
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0
            Dim GST As Double = 0
            Try
                Dim frmP As New frmPaymentOthers
                frmP.GST_Applicable = False
                frmP.btnVouchers.Enabled = False
                frmP.selectedPaymentMode = PaymentMode
                frmP.Label1.Text = "Total : " & total.ToString("0.00")
                frmP.txtTotalInGST.Text = total.ToString("0.00")
                Dim frmReason As New dlgReason
                frmReason.ReasonType = "SHIFT FEE"
                Dim reason As String = ""
                If frmReason.ShowDialog = Windows.Forms.DialogResult.OK Then
                    reason = frmReason.txtReason.Text
                End If
                If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PaymentMode = frmP.selectedPaymentMode
                    CashAmt = Val(frmP.txtCash.Text)
                    CardAmt = Val(frmP.txtCard.Text)
                    SurchargAmt = Val(frmP.txtSurchargeAmt.Text)
                    SurchargP = Val(frmP.txtSurchrgeP.Text)
                    GST = Val(frmP.txtGST.Text)
                    Dim objShiftFee As New cls_tblShiftFee
                    Dim objDocket As New cls_Temp_tblDocketMemo
                    Dim MemoNo As Integer = objDocket.Insert("SHIFT FEE", Now, "", "")
                    Dim ShiftFeeID As Integer = objShiftFee.Insert("", Now, 0, total, reason, "PAID", "ShiftFee")
                    Dim objPayment As New cls_tblPayment
                    objPayment.Insert("SHIFT FEE", total, ShiftFeeID, Now, CashAmt, CardAmt, MySettings.Surcharge, CardAmt * MySettings.Surcharge / 100, "PAID", PaymentMode, CashAmt + CardAmt + (CardAmt * MySettings.Surcharge / 100), "", 0, 0, MemoNo, Val(frmP.txtCashOut.Text), Val(frmP.txtTip.Text), GST, LoginUserId)
                    clsDocketPrint.PrintDocketMemo(MemoNo)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnCheckIN_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckIN.Click
        frmCancelledBooking.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cashout As Double = 0
        'cashout = 0
        Dim frm As New frmPaymentCustom
        'frm.txtTip.ReadOnly = True
        'frm.txtCashOut.Text = cashout.ToString("0.00")
        frm.selectedPaymentMode = "CARD"
        frm.isManualEntry = True
        'frm.btnCash.Enabled = False
        frm.btnVouchers.Enabled = False
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim objPayment As New cls_tblPayment
            cashout = Val(frm.txtTotalInGST.Text)
            Dim objDocket As New cls_Temp_tblDocketMemo
            Dim MemoNo As Integer = objDocket.Insert("CUSTOM", Now, "", "")
            objPayment.Insert("CUSTOM", cashout, "0", Now, Val(frm.txtCash.Text), Val(frm.txtCard.Text), Val(frm.txtSurchrgeP.Text), Val(frm.txtSurchargeAmt.Text), "PAID", frm.selectedPaymentMode, cashout + Val(frm.txtSurchargeAmt.Text) + Val(frm.txtCash.Text), "", 0, 0, MemoNo, 0, Val(frm.txtTip.Text), Val(frm.txtGST.Text), LoginUserId)
            clsDocketPrint.PrintDocketMemo(MemoNo)
        End If
    End Sub
End Class