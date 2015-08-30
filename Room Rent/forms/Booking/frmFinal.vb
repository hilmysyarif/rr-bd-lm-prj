Public Class frmFinal

    Public selectedDoor As String = "NO CHARGE"
    Public selectedDoorCharge As String = "0"
    Public selectedPaymentMode As String = "CASH"

    Public total As Double = 0


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

    Private Sub btnPrivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrivate.Click, btnLounge.Click, btnNoCharge.Click
        For Each c As Button In grpDoorCharges.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.BackColor = ActiveButton
        selectedDoor = sender.text
        selectedDoorCharge = sender.tag
        lblTotalPrice.Text = "$" + (total + Val(selectedDoorCharge)).ToString("0.00")
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click, btnCard.Click
        For Each c As Button In pnlPaymentMode.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.BackColor = ActiveButton
        selectedPaymentMode = sender.text
    End Sub

    Private Sub frmFinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnNoCharge.BackColor = ActiveButton
        btnCash.BackColor = ActiveButton
    End Sub
End Class