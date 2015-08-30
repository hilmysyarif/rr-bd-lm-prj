Public Class frmPaymentOthers
    Public selectedPaymentMode As String = ""
    Public VoucherId As Integer = 0
    Public total_inGST As Double = 0
    Public GST_Applicable As Boolean = True
    Public CardName As String = "EFT"
    Dim SelectAdmP As Double = 0.0

    Public isManualEntry As Boolean = False


    Sub New()

        'This call is required by the designer.
        InitializeComponent()
        btnEftPos.Tag = MySettings.OtherSettings.EFT_P
        btnVisa.Tag = MySettings.OtherSettings.VISA_P
        btnMasterCard.Tag = MySettings.OtherSettings.MASTERCARD_P
        btnAmex.Tag = MySettings.OtherSettings.AMEX_P
        btnOthers.Tag = MySettings.OtherSettings.OTHRCARD_P
        txtSurchrgeP.Text = MySettings.OtherSettings.EFT_P '
        'Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmPaymentMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        txtTotalInGST.ReadOnly = Not isManualEntry
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

        If Val(txtCash.Text) + Val(txtCard.Text) <> Val(txtGrandTotal.Text) Then
            MsgBox("SUB Total do not match with PAID AMOUNT", MsgBoxStyle.Information, "PAYMENT AMOUNT")
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub
    Sub total_calc(Optional CalculateGrandTotal As Boolean = True)
        If CalculateGrandTotal Then
            txtGrandTotal.Text = (Val(txtTotalInGST.Text) + Val(txtTip.Text) + Val(txtCashOut.Text)).ToString("0.00")
        End If
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
    Private Sub txtTIP_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTip.KeyUp, txtCashOut.KeyUp
        total_calc()
    End Sub

    Private Sub txtCard_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCard.Leave, txtCash.Leave, txtTip.Leave, txtCashOut.Leave
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
        total_calc()
    End Sub

    Private Sub frmPayment1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'total_inGST = Val(txtTotal.Text)
        'txtTotal.Text = (total_inGST * 0.9).ToString("0.0")
        calc_GST()
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
    Sub calc_GST()
        If GST_Applicable Then
            txtGST.Text = (CalculateGST(Val(txtTotalInGST.Text))).ToString("0.00")
        Else
            txtGST.Text = "0.00"
        End If
        txtTotalExGST.Text = ((Val(txtTotalInGST.Text)) - Val(txtGST.Text)).ToString("0.00")
    End Sub
    Private Sub btnVouchers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVouchers.Click
        Dim frm As New frmVoucherLink
        frm.PayableAmount = Val(txtGrandTotal.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            ''If frm.VoucherAmount > 0 Then
            If frm.PayableAmount > frm.VoucherAmount Then
                txtVoucherAmount.Text = frm.VoucherAmount.ToString("0.00")
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
        Button1.Enabled = False
        txtSurchrgeP.Select()
    End Sub

    Private Sub txtSurchrgeP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSurchrgeP.TextChanged
        If txtSurchrgeP.Enabled Then
        End If
        total_calc()
    End Sub
    Private Sub txtAmountPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountPaid.TextChanged
        Label1.Text = "Total : " & Val(txtAmountPaid.Text).ToString("0.00")
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

    Private Sub txtTotalInGST_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalInGST.KeyUp
        '  txtTotalInGST.Text = Val(txtGrandTotal.Text) - (Val(txtTip.Text) + Val(txtCashOut.Text))
        calc_GST()
        total_calc(True)
    End Sub

    Private Sub txtGrandTotal_Leave(sender As System.Object, e As System.EventArgs) Handles txtTotalInGST.Leave
        txtTotalInGST.Text = Val(txtTotalInGST.Text).ToString("0.00")
    End Sub
 
End Class