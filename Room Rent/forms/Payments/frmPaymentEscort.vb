Public Class frmPaymentEscort

    Public selectedPaymentMode As String = ""
    Public CardName As String = "EFT"
    Public VoucherId As Integer = 0
    Public HouseAmount As Double = 0
    Public isContra As Boolean = Not MySettings.Contra
    Public isBond As Boolean = True
    Public isDayPrice As Boolean = Not MySettings.OtherSettings.DayPrice
    Public forceHideBtns As Boolean = False

    Public NightPrice As cls_tblLookUp.PriceSpec = Nothing
    Public CurrentPrice As cls_tblLookUp.PriceSpec = Nothing
    Dim SelectAdmP As Double = 0.0

    Sub New(SP_names As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        btnEftPos.Tag = MySettings.OtherSettings.EFT_P
        btnVisa.Tag = MySettings.OtherSettings.VISA_P
        btnMasterCard.Tag = MySettings.OtherSettings.MASTERCARD_P
        btnAmex.Tag = MySettings.OtherSettings.AMEX_P
        btnOthers.Tag = MySettings.OtherSettings.OTHRCARD_P
        txtSurchrgeP.Text = MySettings.OtherSettings.EFT_P '
        lblSP.Text = ""
        If Not IsNothing(SP_names) Then
            For Each s As String In SP_names
                If lblSP.Text <> "" Then
                    lblSP.Text += ", "
                End If
                lblSP.Text += s
            Next
        End If
    End Sub

    Private Sub frmPaymentMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        btnContra.Visible = MySettings.Contra
        btnDayPrice.Visible = False
        If forceHideBtns Then
            btnContra.Visible = False
            btnDayPrice.Visible = False
        End If

        If btnDayPrice.Visible Then
            GroupBox1.Text = "SPLIT INFO (NIGHT SHIFT PRICE)"
        Else
            GroupBox1.Text = "SPLIT INFO (" & MyShift() & " PRICE)"
        End If

        If btnContra.Visible Then
            btnContra.Visible = Not IsNothing(CurrentPrice)
        End If
        txtEscortBondFees.Enabled = isBond
        If txtEscortBondFees.Enabled Then
            If txtEscortBondFees.Text = 0 Then
                txtEscortBondFees.Text = MySettings.OtherSettings.BOND_FEES.ToString("0.00")
            End If
        Else
            txtEscortBondFees.Text = 0
        End If
    End Sub

    Private Sub frmPayment1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        HouseAmount = Val(txtHouse.Text)
        calc_on_shown()
    End Sub
    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click, btnCard.Click, btnCardCash.Click

        For Each c As Button In grpPaymentMode.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next

        selectedPaymentMode = sender.text
        sender.backcolor = ActiveButton
        total_calc()
    End Sub
    Sub ValidatePaymentMode()
        If VoucherId > 0 Then
            selectedPaymentMode = "VOUCHER"
            If txtCash.DecimalValue <> 0 Then
                selectedPaymentMode += "/CARD"
            End If
            If txtCard.DecimalValue <> 0 Then
                selectedPaymentMode += "/CARD"
            End If
        End If
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If SelectAdmP > Val(txtSurchrgeP.Text) Then
            MsgBox("Admin fees cannot be lower than stated in Admin Section or also cannot be Zero. Please contact administrator", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If selectedPaymentMode = "" Then
            MsgBox("Select a payment mode", MsgBoxStyle.Information, "PAYMENT MODE")
            Exit Sub
        End If
        If selectedPaymentMode.Contains("CARD") And txtSurchargeAmt.DecimalValue = 0 And txtCard.DecimalValue > 0 Then
            MsgBox("Admin fees cannot be zero.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If Val(txtCash.Text) + Val(txtCard.Text) + Val(txtVoucherAmount.Text) <> Val(txtGrandTotal.Text) Then
            MsgBox("SUB Total do not match with PAID AMOUNT", MsgBoxStyle.Information, "PAYMENT AMOUNT")
            Exit Sub
        End If

        ValidatePaymentMode()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

    Sub total_calc()
        txtGrandTotal.Text = (Val(txtCarFare.Text) + Val(txtEscortExtFees.Text) + Val(txtEscortBondFees.Text) + Val(txtTotalInGST.Text) + Val(txtTip.Text) + Val(txtCashOut.Text) + Val(txtShiftFee.Text) + Val(txtUpgrade.Text)).ToString("0.00")
        txtCashOut.ReadOnly = True
        If selectedPaymentMode = "CARD" Then
            txtCard.Text = (Val(txtGrandTotal.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
            txtCash.Text = "0.00"
            txtCard.Enabled = True
            txtCash.Enabled = False
            txtCashOut.ReadOnly = False
        ElseIf selectedPaymentMode = "CASH" Then
            txtCard.Text = "0.00"
            txtCash.Text = (Val(txtGrandTotal.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
            txtCash.Enabled = True
            txtCard.Enabled = False
            txtCashOut.ReadOnly = True
            txtCashOut.Text = "0.00"
        Else
            txtCard.Enabled = True
            txtCash.Enabled = True
            txtCashOut.ReadOnly = False
        End If
        txtSurchargeAmt.Text = (Val(txtCard.Text) * (Val(txtSurchrgeP.Text) / 100)).ToString("0.00")
        txtAmountPaid.Text = (Val(txtSurchargeAmt.Text) + Val(txtCash.Text) + Val(txtCard.Text) + Val(txtVoucherAmount.Text)).ToString("0.00")
    End Sub

    Private Sub txtCard_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCard.KeyUp, txtCash.KeyUp
        If DirectCast(sender, TextBox).Name = "txtCard" Then
            txtCash.Text = (Val(txtGrandTotal.Text) - Val(txtCard.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtCash" Then
            txtCard.Text = (Val(txtGrandTotal.Text) - Val(txtCash.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
        End If
        txtSurchargeAmt.Text = (Val(txtCard.Text) * (Val(txtSurchrgeP.Text) / 100)).ToString("0.00")
        txtAmountPaid.Text = (Val(txtSurchargeAmt.Text) + Val(txtCash.Text) + Val(txtCard.Text) + Val(txtVoucherAmount.Text)).ToString("0.00")
    End Sub

    Private Sub txtTIP_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTip.KeyUp, txtCashOut.KeyUp, txtUpgrade.KeyUp, txtEscortExtFees.KeyUp, txtCarFare.KeyUp, txtEscortBondFees.KeyUp
        total_calc()
    End Sub

    Private Sub txtCard_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCard.Leave, txtCash.Leave, txtTip.Leave, txtCashOut.Leave, txtEscortExtFees.Leave, txtCarFare.Leave, txtUpgrade.Leave, txtEscortBondFees.Leave
        If DirectCast(sender, TextBox).Name = "txtCard" Then
            txtCard.Text = Val(txtCard.Text).ToString("0.00")
            txtCash.Text = (Val(txtGrandTotal.Text) - Val(txtCard.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtCash" Then
            txtCash.Text = Val(txtCash.Text).ToString("0.00")
            txtCard.Text = (Val(txtGrandTotal.Text) - Val(txtCash.Text) - Val(txtVoucherAmount.Text)).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtTip" Then
            txtTip.Text = Val(txtTip.Text).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtCashOut" Then
            txtCashOut.Text = Val(txtCashOut.Text).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtUpgrade" Then
            txtUpgrade.Text = Val(txtUpgrade.Text).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtCarFare" Then
            txtCarFare.Text = Val(txtCarFare.Text).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtEscortExtFees" Then
            txtEscortExtFees.Text = Val(txtEscortExtFees.Text).ToString("0.00")
        End If
        If DirectCast(sender, TextBox).Name = "txtEscortBondFees" Then
            txtEscortBondFees.Text = Val(txtEscortBondFees.Text).ToString("0.00")
        End If
        total_calc()
    End Sub


    Private Sub txtTip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTip.TextChanged, txtCashOut.TextChanged, txtCard.TextChanged, txtCash.TextChanged, txtShiftFee.TextChanged, txtUpgrade.TextChanged, txtEscortExtFees.TextChanged, txtCarFare.TextChanged, txtEscortBondFees.TextChanged
        total_calc()
    End Sub



    Sub calc_on_shown()
        txtTotalInGST.Text = Val(txtHouse.Text) + Val(txtWorkerAmount.Text)
        txtGST.Text = (CalculateGST(Val(txtHouse.Text))).ToString("0.00")
        txtTotalExGST.Text = ((Val(txtTotalInGST.Text)) - Val(txtGST.Text)).ToString("0.00")
        If selectedPaymentMode = "CARD" Then
            btnCard.BackColor = ActiveButton
        ElseIf selectedPaymentMode = "CASH" Or selectedPaymentMode = "" Then
            btnCash.BackColor = ActiveButton
            selectedPaymentMode = "CASH"
        ElseIf selectedPaymentMode = "CARD/CASH" Then
            btnCardCash.BackColor = ActiveButton
        End If
        total_calc()
    End Sub

    Private Sub btnVouchers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVouchers.Click
        Dim frm As New frmVoucherLink
        frm.PayableAmount = Val(txtGrandTotal.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            ''If frm.VoucherAmount > 0 Then
            If frm.PayableAmount > Val(frm.NumericTextBox1.Text) Then
                txtVoucherAmount.Text = Val(frm.NumericTextBox1.Text).ToString("0.00")
            Else
                txtVoucherAmount.Text = frm.PayableAmount.ToString("0.00")
            End If
            VoucherId = frm.VoucherId
            'End If
            total_calc()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtSurchrgeP.Enabled = True
        'Button1.Enabled = False
        txtSurchrgeP.Select()
    End Sub

    Private Sub txtSurchrgeP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSurchrgeP.TextChanged
        total_calc()
        'If txtSurchrgeP.Enabled Then
        'End If
    End Sub

    Private Sub txtAmountPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountPaid.TextChanged
        lblTot.Text = "Cash Total : " & Val(txtCash.Text).ToString("0.00")
        lblTot.Text += vbNewLine & "Card Total : " & (Val(txtCard.Text) + Val(txtSurchargeAmt.Text)).ToString("0.00")
        ' lblTot.Text = "bdfgjldfkjhlfgkhj" '"Cash Total : " & Val(txtCash.Text).ToString("0.00")
        '  lblTot.Text += vbNewLine & "Card Total : " & (Val(txtCard.Text) + Val(txtSurchargeAmt.Text)).ToString("0.00")
        txtHouse2.Text = (Val(txtHouse.Text) + Val(txtTip.Text) + Val(txtUpgrade.Text) + Val(txtCarFare.Text) + Val(txtEscortExtFees.Text)).ToString("0.00")
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisa.Click, btnOthers.Click, btnMasterCard.Click, btnEftPos.Click, btnAmex.Click
        Try
            For Each pc As Control In pnlCards.Controls
                pc.BackColor = SystemColors.Control
            Next

            sender.backcolor = Color.Red
            txtSurchrgeP.Text = Val(sender.tag).ToString("0.00")
            SelectAdmP = Val(sender.tag)
            Select Case sender.name
                Case "btnEftPos"
                    CardName = "EFT"
                Case "btnVisa"
                    CardName = "VISA"
                Case "btnMasterCard"
                    CardName = "MASTERCARD"
                Case "btnAmex"
                    CardName = "AMEX"
                Case "btnOthers"
                    CardName = "OTHERS"
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtGrandTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrandTotal.TextChanged
        'txtGST.Text = ((Val(txtGrandTotal.Text) - Val(txtWorkerAmount.Text)) * 0.1).ToString("0.00")
    End Sub


    Private Sub btnContra_Click(sender As System.Object, e As System.EventArgs) Handles btnContra.Click
        isContra = Not isContra
        If isContra Then
            isContra = Not isContra
            Dim frm As New dlgAdminPass
            frm.Text = "Enter Contra Password"
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                If frm.TextBox1.Text = MySettings.Contra_Password Then
                    btnContra.BackColor = ActiveButton
                    txtHouse.Text = "0.00"
                    isContra = Not isContra
                Else
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Else
            btnContra.BackColor = Nothing
            btnContra.UseVisualStyleBackColor = True
            txtHouse.Text = HouseAmount.ToString("0.00")
        End If

        calc_on_shown()
        total_calc()
    End Sub


    Private Sub btnDayPrice_Click_1(sender As Object, e As EventArgs) Handles btnDayPrice.Click
        isDayPrice = Not isDayPrice
        If isDayPrice Then
            isDayPrice = Not isDayPrice
            Dim frm As New dlgAdminPass
            frm.Text = "Enter Password"
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                If frm.TextBox1.Text = MySettings.OtherSettings.DayPricePassword Then
                    btnDayPrice.BackColor = ActiveButton
                    If isContra Then
                        txtHouse.Text = "0.00"
                    Else
                        txtHouse.Text = CurrentPrice.HouseAmount.ToString("0.00")
                    End If
                    GroupBox1.Text = "SPLIT INFO (" & CurrentPrice.Shift.ToString & " SHIFT PRICE)"
                    HouseAmount = CurrentPrice.HouseAmount
                    txtWorkerAmount.Text = CurrentPrice.WorkerAmount.ToString("0.00")
                    isDayPrice = Not isDayPrice
                Else
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Else
            btnDayPrice.BackColor = Nothing
            btnDayPrice.UseVisualStyleBackColor = True
            If isContra Then
                txtHouse.Text = "0.00"
            Else
                txtHouse.Text = NightPrice.HouseAmount.ToString("0.00")
            End If
            GroupBox1.Text = "SPLIT INFO (NIGHT SHIFT PRICE)"
            HouseAmount = NightPrice.HouseAmount
            txtWorkerAmount.Text = NightPrice.WorkerAmount.ToString("0.00")
        End If
        calc_on_shown()
        total_calc()
    End Sub

    'Private Sub txtTip_GotFocus(sender As Object, e As Object) Handles txtTip.GotFocus, txtCashOut.GotFocus, txtCarFare.GotFocus, txtEscortExtFees.GotFocus, txtCash.GotFocus, txtCard.GotFocus, txtVoucherAmount.GotFocus, txtSurchrgeP.GotFocus, txtSurchargeAmt.GotFocus, txtUpgrade.GotFocus, _
    '    txtTip.Click, txtCashOut.Click, txtCarFare.Click, txtEscortExtFees.Click, txtCash.Click, txtCard.Click, txtVoucherAmount.Click, txtSurchrgeP.Click, txtSurchargeAmt.Click, txtUpgrade.Click, _
    '    txtTip.MouseUp, txtCashOut.MouseUp, txtCarFare.MouseUp, txtEscortExtFees.MouseUp, txtCash.MouseUp, txtCard.MouseUp, txtVoucherAmount.MouseUp, txtSurchrgeP.MouseUp, txtSurchargeAmt.MouseUp, txtUpgrade.MouseUp
    '    sender.select()
    'End Sub
    'Private Sub txtTip_GotFocus(sender As System.Object, e As Object) Handles txtVoucherAmount.MouseUp, txtVoucherAmount.GotFocus, txtVoucherAmount.Click, txtUpgrade.MouseUp, txtUpgrade.GotFocus, txtUpgrade.Click, txtTip.MouseUp, txtTip.GotFocus, txtTip.Click, txtSurchrgeP.MouseUp, txtSurchrgeP.GotFocus, txtSurchrgeP.Click, txtSurchargeAmt.MouseUp, txtSurchargeAmt.GotFocus, txtSurchargeAmt.Click, txtEscortExtFees.MouseUp, txtEscortExtFees.GotFocus, txtEscortExtFees.Click, txtCashOut.MouseUp, txtCashOut.GotFocus, txtCashOut.Click, txtCash.MouseUp, txtCash.GotFocus, txtCash.Click, txtCarFare.MouseUp, txtCarFare.GotFocus, txtCarFare.Click, txtCard.MouseUp, txtCard.GotFocus, txtCard.Click
    '    sender.select()
    'End Sub
    'Private Sub txtTip_GotFocus(sender As System.Object, e As System.EventArgs)
    'End Sub

End Class