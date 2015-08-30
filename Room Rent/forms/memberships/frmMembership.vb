Public Class frmMembership
    Dim objMem As New cls_tblMembers
    Dim objDocket As New cls_Temp_tblDocketMemo
    Dim objPayment As New cls_tblPayment
    Dim objPayment2 As New cls_Temp_tblPayment

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Update" Then
            Try
                If txtName.Text = "" Then
                    MsgBox("Please enter member's name", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                objMem.Update(txtMemberID.Text, _
                                  txtName.Text, _
                                  txtPhone.Text, _
                                  txtAddress.Text )
                MsgBox("Updated", MsgBoxStyle.Information, "Info")
                refreshDG()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        Else

            Try
                If txtMemberID.Text = "" Then
                    If MsgBox("Member ID is empty." & vbNewLine & "Do you want the application to auto-genrate a Member ID?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Info") = MsgBoxResult.Yes Then
                        txtMemberID.Text = "MEM" & objMem.MaxID.ToString("0000")
                        MsgBox("Generated Mmeber Id : " & txtMemberID.Text, MsgBoxStyle.Information, "Info")
                    Else
                        Exit Sub
                    End If
                End If
                If txtName.Text = "" Then
                    MsgBox("Please enter member's name", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Dim frmPay As New frmPaymentOthers
                frmPay.GST_Applicable = True
                frmPay.btnVouchers.Enabled = False
                frmPay.selectedPaymentMode = ""
                frmPay.Label1.Text = "Total : " & MySettings.OtherSettings.MembershipFee.ToString("0.00")
                frmPay.txtTotalInGST.Text = MySettings.OtherSettings.MembershipFee.ToString("0.00")
                If frmPay.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim MemId As Integer = objMem.Insert(txtMemberID.Text, _
                                  txtName.Text, _
                                  txtPhone.Text, _
                                  txtAddress.Text, _
                                  Now)
                    Dim DocketId As Integer = objDocket.Insert("MEMBERSHIP", Now, MemId, "")
                    objPayment.Insert("MEMBERSHIP", frmPay.txtTotalExGST.Text, MemId, Now, frmPay.txtCash.Text, frmPay.txtCard.Text, frmPay.txtSurchrgeP.Text, frmPay.txtSurchargeAmt.Text, "PAID", frmPay.selectedPaymentMode, _
                                     Val(frmPay.txtCash.Text) + Val(frmPay.txtCard.Text) + Val(frmPay.txtSurchargeAmt.Text), "", frmPay.txtVoucherAmount.Text, frmPay.VoucherId, DocketId, frmPay.txtCashOut.Text, frmPay.txtTip.Text, frmPay.txtGST.Text, LoginUserId)
                    MsgBox("Saved", MsgBoxStyle.Information, "Info")
                    refreshDG()
                    clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Sub refreshDG()
        dgProducts.DataSource = objMem.Selection(1)
        dgProducts.Columns("Sl").Visible = False
    End Sub

    Sub clear()
        txtMemberID.Clear()
        txtName.Text = ""
        txtPhone.Text = ""
        txtAddress.Clear()
        txtMemberID.Enabled = True
        btnSave.Text = "Save"
    End Sub

    Private Sub dgProducts_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgProducts.SelectionChanged
        btnDelete.Enabled = dgProducts.RowCount >= 1
        btnEdit.Enabled = dgProducts.RowCount >= 1
        btnVisits.Enabled = dgProducts.RowCount >= 1
    End Sub

    Private Sub frmAddMerchandise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refreshDG()
        TopMost = IsAllTopMostForm
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objMem.Delete(dgProducts.SelectedRows(0).Cells(0).Value)
            Dim MemID As Integer = dgProducts.SelectedRows(0).Cells("Sl").Value
            Try
                objDocket.Delete_By_SELECT("MemoNo=" & objPayment2.Selection_One_Row_Select("Transc_ID=" & MemID.ToString & " and Transac_Type='MEMBERSHIP'").MemoNo_ & " and MemoType='MEMBERSHIP'")
            Catch ex As Exception
            End Try
            Try
                objPayment2.Delete_By_SELECT("Transc_ID=" & MemID.ToString & " and Transac_Type='MEMBERSHIP'")
            Catch ex As Exception
            End Try

            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
            refreshDG()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            txtMemberID.Enabled = False
            txtMemberID.Text = dgProducts.SelectedRows(0).Cells(0).Value
            txtName.Text = dgProducts.SelectedRows(0).Cells(1).Value
            txtPhone.Text = dgProducts.SelectedRows(0).Cells(2).Value
            txtAddress.Text = dgProducts.SelectedRows(0).Cells(3).Value
            btnSave.Text = "Update"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btnVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisits.Click

    End Sub
End Class