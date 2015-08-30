Public Class frmMerchandiseSale

    'Dim objProduct As New cls_tblProducts
    Dim objProduct As New cls_Temp_tblProducts
    Dim objBill As New cls_Temp_tblBill
    Dim objBillItems As New cls_tblBillItems
    Dim objPayment As New cls_tblPayment

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Sub loadProducts()
        dgProducts.Rows.Clear()
        Dim dt As DataTable = objProduct.Selection
        For Each dr As DataRow In dt.Rows
            dgProducts.Rows.Add(dr("ProductID"), IIf(dr("CodeName") Is DBNull.Value OrElse dr("CodeName") = "", dr("ProductName"), dr("CodeName")), dr("Price"))
        Next
    End Sub

    Private Sub frmMerchandiseSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub frmMerchandiseSale_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        loadProducts()
        dgCart.Columns(7).DisplayIndex = 0
    End Sub

    Private Sub dgProducts_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProducts.CellClick
        If e.RowIndex >= 0 Then
            For Each dgr As DataGridViewRow In dgCart.Rows
                If dgProducts.Rows(e.RowIndex).Cells(0).Value = dgr.Cells(0).Value Then
                    dgr.Cells(4).Value = Val(dgr.Cells(4).Value) + 1
                    dgr.Cells(2).Value = Val(dgr.Cells(4).Value) * Val(dgr.Cells(3).Value)
                    dgr.Cells(1).Value = dgr.Cells(5).Value & " .....x" & Val(dgr.Cells(4).Value).ToString
                    Total()
                    Exit Sub
                End If
            Next
            dgCart.Rows.Add(dgProducts.Rows(e.RowIndex).Cells(0).Value, dgProducts.Rows(e.RowIndex).Cells(1).Value.ToString & " .....x1", dgProducts.Rows(e.RowIndex).Cells(2).Value, dgProducts.Rows(e.RowIndex).Cells(2).Value, 1, dgProducts.Rows(e.RowIndex).Cells(1).Value.ToString, dgProducts.Rows(e.RowIndex).Cells(2).Value)
            Total()
        End If
    End Sub

    Private Sub dgCart_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCart.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 2 Then
                Dim frm As New dlgAmount2Numeric
                frm.Text = "Product : " & dgCart.Rows(e.RowIndex).Cells(5).Value.ToString & " || Unit Price : " & Val(dgCart.Rows(e.RowIndex).Cells(3).Value).ToString("0.00")
                frm.txtAmount.Minimum = Val(dgCart.Rows(e.RowIndex).Cells(6).Value)
                frm.txtAmount.Value = Val(dgCart.Rows(e.RowIndex).Cells(3).Value)
                frm.Label1.Text = "Unit Price :"
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dgCart.Rows(e.RowIndex).Cells(3).Value = frm.txtAmount.Value
                    dgCart.Rows(e.RowIndex).Cells(2).Value = Val(dgCart.Rows(e.RowIndex).Cells(4).Value) * Val(dgCart.Rows(e.RowIndex).Cells(3).Value)
                    dgCart.Rows(e.RowIndex).Cells(1).Value = dgCart.Rows(e.RowIndex).Cells(5).Value & " .....x" & Val(dgCart.Rows(e.RowIndex).Cells(4).Value).ToString
                End If
            ElseIf e.ColumnIndex = 7 Then
                If Val(dgCart.Rows(e.RowIndex).Cells(4).Value) > 1 Then
                    dgCart.Rows(e.RowIndex).Cells(4).Value = Val(dgCart.Rows(e.RowIndex).Cells(4).Value) - 1
                    dgCart.Rows(e.RowIndex).Cells(2).Value = Val(dgCart.Rows(e.RowIndex).Cells(4).Value) * Val(dgCart.Rows(e.RowIndex).Cells(3).Value)
                    dgCart.Rows(e.RowIndex).Cells(1).Value = dgCart.Rows(e.RowIndex).Cells(5).Value & " .....x" & Val(dgCart.Rows(e.RowIndex).Cells(4).Value).ToString
                Else
                    dgCart.Rows.RemoveAt(e.RowIndex)
                End If
            End If

            Total()
        End If
    End Sub

    Sub Total()
        Dim tot As Double = 0
        For Each dgr As DataGridViewRow In dgCart.Rows
            tot += Val(dgr.Cells(2).Value)
        Next
        txtTotal.Text = tot.ToString("0.00")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If dgCart.Rows.Count = 0 Then
            MsgBox("Please add some items into the cart", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim frm As New frmPaymentOthers
        frm.GST_Applicable = True
        frm.Label1.Text = "Total : " & Val(txtTotal.Text).ToString("0.00")

        'frm.txtCashOut.ReadOnly = True
        'frm.txtTip.ReadOnly = True

        frm.txtTotalInGST.Text = Val(txtTotal.Text).ToString("0.00")

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Save Bill
            Dim objDocket As New cls_Temp_tblDocketMemo
            Dim MemoNo As Integer = objDocket.Insert("MERCHANDISE_SALE", Now, "", "")
            Dim billID As Integer = objBill.Insert("", Val(txtTotal.Text), Now, "PAID", LoginUserId)
            For Each dgr As DataGridViewRow In dgCart.Rows
                objBillItems.Insert(billID, dgr.Cells(0).Value, dgr.Cells(4).Value, dgr.Cells(3).Value, dgr.Cells(4).Value * dgr.Cells(3).Value)
            Next
            objPayment.Insert("MERCHANDISE_SALE", Val(txtTotal.Text), billID, Now, frm.txtCash.Text, frm.txtCard.Text, frm.txtSurchrgeP.Text, frm.txtSurchargeAmt.Text, "PAID", frm.selectedPaymentMode, Val(frm.txtCash.Text) + Val(frm.txtCard.Text) + Val(frm.txtSurchargeAmt.Text) + Val(frm.txtVoucherAmount.Text), "", Val(frm.txtVoucherAmount.Text), frm.VoucherId, MemoNo, Val(frm.txtCashOut.Text), Val(frm.txtTip.Text), Val(frm.txtGST.Text), LoginUserId)
            clsDocketPrint.PrintDocketMemo(MemoNo)
            dgCart.Rows.Clear()
            Total()

        End If
    End Sub

    Private Sub dgCart_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgCart.MouseMove
        For i = 0 To dgCart.RowCount - 1
            Dim r As Rectangle = dgCart.GetCellDisplayRectangle(2, i, False)
            r.Intersect(New Rectangle(e.Location, New Size(1, 1)))
            If r.Width >= 1 Then
                Cursor = Cursors.Hand
                'dgCart.Rows(i).Cells(3).Style.BackColor = Color.Red
                Exit Sub

            Else
                'dgCart.Rows(i).Cells(3).Style.BackColor = Color.White
                Cursor = Cursors.Default
            End If
        Next


    End Sub
End Class