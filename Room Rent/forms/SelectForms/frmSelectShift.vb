Public Class frmSelectShift

    Public SelectedShift As cls_tblLookUp.PriceType = MyShiftType()

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmSelectShift_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case SelectedShift
            Case cls_tblLookUp.PriceType.DAY
                btnDay.BackColor = ActiveButton
            Case cls_tblLookUp.PriceType.EVENING
                btnEvening.BackColor = ActiveButton
            Case cls_tblLookUp.PriceType.NIGHT
                btnNight.BackColor = ActiveButton
        End Select
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDay.Click, btnEvening.Click, btnNight.Click

        For Each c As Button In GroupBox1.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next

        Select Case sender.text
            Case "DAY"
                SelectedShift = cls_tblLookUp.PriceType.DAY

            Case "EVENING"
                SelectedShift = cls_tblLookUp.PriceType.EVENING

            Case "NIGHT"
                SelectedShift = cls_tblLookUp.PriceType.NIGHT

        End Select

        ' SelectedShift = sender.text
        sender.backcolor = ActiveButton

    End Sub

End Class