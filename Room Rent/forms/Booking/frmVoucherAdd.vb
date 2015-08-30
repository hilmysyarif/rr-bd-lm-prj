Public Class frmVoucherAdd
 
    Dim objVoucher As New cls_Temp_tblVouchers
    Dim objPayment As New cls_tblPayment

    Private Sub NumericTextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.GotFocus, txtValue.Click
        txtValue.SelectionStart = 0
        txtValue.SelectionLength = txtValue.Text.Length
    End Sub
 
    Private Sub btnBCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBCK.Click
        Close()
    End Sub

    Sub Clear()
        txtVoucherNo.Text = objVoucher.MaxID_PlusOne
        txtComments.Clear()
        txtDate.Value = Today
        txtRefID.Clear()
        'txtValid.Text = 0
        txtValue.Text = "0.00"
    End Sub




    Private Sub frmVoucherAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Clear()
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub txtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSave.Click
        If txtRefID.Text.Trim = "" Or Val(txtValue.Text) <= 0 Then
            MsgBox("Enter Proper value and Ref Id", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Try
            Dim CashAmt As Double = 0
            Dim CardAmt As Double = 0
            Dim SurchargAmt As Double = 0
            Dim SurchargP As Double = 0
            Dim PaymentMode As String = ""
            Dim TotalPaid As Double = 0
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0
            Dim Cashout As Double = 0
            Dim tip As Double = 0
            Dim GST As Double = 0
            Dim total As Double = Val(txtValue.Text)
            Dim frmP As New frmPaymentOthers
            'frmP.txtTip.Enabled = False
            'frmP.txtCashOut.Enabled = False
            frmP.btnVouchers.Enabled = False

            frmP.selectedPaymentMode = PaymentMode
            frmP.Label1.Text = "Total : " & total.ToString("0.00")
            frmP.GST_Applicable = False
            frmP.txtTotalInGST.Text = total.ToString("0.00")
            If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then
                PaymentMode = frmP.selectedPaymentMode
                CashAmt = Val(frmP.txtCash.Text)
                CardAmt = Val(frmP.txtCard.Text)
                SurchargAmt = Val(frmP.txtSurchargeAmt.Text)
                SurchargP = Val(frmP.txtAmountPaid.Text)
                TotalPaid = Val(frmP.txtAmountPaid.Text)
                VoucherID = frmP.VoucherId
                VoucherAmount = Val(frmP.txtVoucherAmount.Text)
                Cashout = Val(frmP.txtCashOut.Text)
                tip = Val(frmP.txtTip.Text)
                GST = Val(frmP.txtGST.Text)
            Else
                Exit Sub
            End If
            Dim pp As New List(Of SQLParameter)
            pp.Add(New SqlParameter("@RefNo", (txtRefID.Text)))
            Dim dt As DataTable = objVoucher.Selection(cls_Temp_tblVouchers.SelectionType.All, "RefNo=@RefNo", pp)
            If dt.Rows.Count > 0 Then
                MsgBox("Reference number already exists. Please enter a differnt Refernce No", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'Save the Voucher
            Dim objDocket As New cls_Temp_tblDocketMemo
            Dim MemoNo As Integer = objDocket.Insert("Voucher", Now, "", "")
            Dim NewVoucherId As Integer = objVoucher.Insert(txtRefID.Text, txtDate.Value, Val(txtValid.Text), Val(txtValue.Text), txtComments.Text, "ACTIVE", "DIRECT")
            'Save Payment
            objPayment.Insert("VOUCHER_ADD", total, NewVoucherId, Now, CashAmt, CardAmt, SurchargP, SurchargAmt, "PAID", PaymentMode, TotalPaid, txtComments.Text, VoucherAmount, VoucherID, MemoNo, Cashout, tip, GST, LoginUserId)

            'Pirnt Memo
            clsDocketPrint.PrintDocketMemo(MemoNo)
            'Clear and Prepare for new Voucher
            Clear()
            Close()
        Catch ex As Exception
            MsgBox("Error While Processing. Please inform the developer" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Clear()
    End Sub
End Class