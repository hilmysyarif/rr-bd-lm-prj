Public Class frmSelectBookingDate
    Public bookingdate As Date = Today
    Public bookingdate_temp As Date = Today
    Public hou As Integer = 12
    Public min As Integer = 0
    Public ff As String = "AM"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For i = 0 To 15
            pnlPanel.Controls("btn" & (i + 1).ToString).Text = Today.AddDays(i).ToString("ddd dd-MMM")
            pnlPanel.Controls("btn" & (i + 1).ToString).Tag = Today.AddDays(i)
        Next
        btn1.BackColor = ActiveButton
        btnHR12.BackColor = ActiveButton
        btnF1.BackColor = ActiveButton
    End Sub
    Private Sub frmBookingDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bookingdate_temp = Today
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, _
        btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click, btn12.Click, btn13.Click, btn14.Click, btn15.Click, btn16.Click
        For Each c As Button In pnlPanel.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.backcolor = ActiveButton
        bookingdate_temp = sender.tag
    End Sub

    Private Sub btnHR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHR1.Click, btnHR2.Click, btnHR3.Click, btnHR4.Click, btnHR5.Click, btnHR6.Click, btnHR7.Click, btnHR8.Click, btnHR9.Click, btnHR10.Click, btnHR11.Click, btnHR12.Click
        For Each c As Button In pnlHour.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.backcolor = ActiveButton
        hou = sender.text
    End Sub

    Private Sub btnMin0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin0.Click, btnMin5.Click, btnMin10.Click, btnMin15.Click, btnMin20.Click, btnMin25.Click, btnMin30.Click, btnMin35.Click, btnMin40.Click, btnMin45.Click, btnMin50.Click, btnMin55.Click
        For Each c As Button In pnlMin.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.backcolor = ActiveButton
        min = sender.text
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click, btnF2.Click
        For Each c As Button In pnlF.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.backcolor = ActiveButton
        ff = sender.text
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        bookingdate = bookingdate_temp
        bookingdate = bookingdate.AddHours(IIf(hou = 12, 0, hou))
        bookingdate = bookingdate.AddMinutes(min)
        bookingdate = bookingdate.AddHours(IIf(ff = "AM", 0, 12))
        If bookingdate < Now Then
            MsgBox("Please select a valid date time. Selected date time is less than current time", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If bookingdate < Now.AddMinutes(30) Then
            MsgBox("Booking for TIME so close is not possble. Please select a later time", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub
End Class