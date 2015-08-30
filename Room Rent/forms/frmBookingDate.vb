Public Class frmBookingDate

    Private Sub frmBookingDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 0 To 15
            pnlPanel.Controls("btn" & (i + 1).ToString).Text = Today.AddDays(i).ToString("dd-MMM")
            pnlPanel.Controls("btn" & (i + 1).ToString).Tag = Today.AddDays(i)
        Next
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, _
        btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click, btn12.Click, btn13.Click, btn14.Click, btn15.Click, btn16.Click
        For Each c As Button In pnlPanel.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click, btnF2.Click
        For Each c As Button In pnlF.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btnHR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHR1.Click, btnHR2.Click, btnHR3.Click, btnHR4.Click, btnHR5.Click, btnHR6.Click, btnHR7.Click, btnHR8.Click, btnHR9.Click, btnHR10.Click, btnHR11.Click, btnHR12.Click
        For Each c As Button In pnlHour.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btnMin0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin0.Click, btnMin5.Click, btnMin10.Click, btnMin15.Click, btnMin20.Click, btnMin25.Click, btnMin30.Click, btnMin35.Click, btnMin40.Click, btnMin45.Click, btnMin50.Click, btnMin55.Click
        For Each c As Button In pnlMin.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btnf3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnf3.Click, btnf4.Click
        For Each c As Button In pnlF2.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btn2Min0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2Min0.Click, btn2Min5.Click, btn2Min10.Click, btn2Min15.Click, btn2Min20.Click, btn2Min25.Click, btn2Min30.Click, btn2Min35.Click, btn2Min40.Click, btn2Min45.Click, btn2Min50.Click, btn2Min55.Click
        For Each c As Button In pnlMin2.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub

    Private Sub btn2HR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2HR1.Click, btn2HR2.Click, btn2HR3.Click, btn2HR4.Click, btn2HR5.Click, btn2HR6.Click, btn2HR7.Click, btn2HR8.Click, btn2HR9.Click, btn2HR10.Click, btn2HR11.Click, btn2HR12.Click
        For Each c As Button In pnlHour2.Controls
            c.UseVisualStyleBackColor = True
            c.BackColor = Nothing
        Next
        sender.backcolor = Color.Red
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()

    End Sub
End Class