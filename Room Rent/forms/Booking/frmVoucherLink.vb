Public Class frmVoucherLink
    Dim objVoucher As New cls_Temp_tblVouchers
    Public VoucherId As Integer = 0
    Public VoucherAmount As Double = 0
    Public PayableAmount As Double = 0
 
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Dim pp As New List(Of SQLParameter)
            pp.Add(New SQLParameter("@VoucherId", Val(txtVoucherNo.Text)))
            pp.Add(New SQLParameter("@RefNo", txtRefID.Text))

            Dim dt As DataTable = objVoucher.Selection(cls_Temp_tblVouchers.SelectionType.All, "VoucherId=@VoucherId or RefNo=@RefNo", pp)
            If dt.Rows.Count >= 1 Then
                If dt.Rows(0).Item("Status") = "ACTIVE" Then
                    If CDate(dt.Rows(0).Item("VoucherDate")).AddDays(dt.Rows(0).Item("Valid")) >= Today.AddDays(1).AddSeconds(-1) Or dt.Rows(0).Item("Valid") = 0 Then
                        Dim usedAmt As Double = objVoucher.VoucherAmountUser(dt.Rows(0).Item("VoucherId"))
                        If usedAmt > 1 Then
                            lblMessage.Text = "Already used" ', MsgBoxStyle.Information, "info")
                            Exit Sub
                        End If
                        VoucherId = dt.Rows(0).Item("VoucherId")
                        VoucherAmount = dt.Rows(0).Item("VoucherValue") - usedAmt
                        NumericTextBox1.Text = VoucherAmount.ToString("0.00")
                        lblMessage.Text = "Avalaible Balance : " & currency & " " & VoucherAmount.ToString("0.00")
                    Else
                        lblMessage.Text = "Voucher Expired"
                    End If

                Else
                    lblMessage.Text = "Voucher De-Activated"
                End If
            Else
                lblMessage.Text = "Not Found"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If Val(NumericTextBox1.Text) > VoucherAmount Then
            MsgBox("Amount cannot be more than Balance", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBCK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBCK.Click
        Close()
    End Sub

    Private Sub NumericTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox1.GotFocus
        sender.select()
    End Sub

    Private Sub frmVoucherLink_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm

    End Sub
End Class