Public Class frmPaymentMode
    Public selectedPaymentMode As String = ""
    Private Sub frmPaymentMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click, btnCard.Click, btnCardCash.Click
        For Each c As Button In grpPaymentMode.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        selectedPaymentMode = sender.text
        sender.backcolor = ActiveButton 
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If selectedPaymentMode = "" Then
            MsgBox("Select a payment mode", MsgBoxStyle.Information, "PAYMENT MODE")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub
  
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

End Class