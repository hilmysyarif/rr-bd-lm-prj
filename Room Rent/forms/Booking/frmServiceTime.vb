Public Class frmServiceTime

    Public customeTime As String = "30"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btn30Min.BackColor = ActiveButton
    End Sub
    Private Sub btn30Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn30Min.Click, btn45Min.Click, btn60Min.Click, btn90Min.Click, btn120Min.Click, btnCustomMin.Click
        For Each c As Button In grpService.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        If sender.text.ToString.StartsWith("CUSTOM") Then
            customeTime = InputBox("Enter time in minutes", "Custom", 0)
            If Not IsNumeric(customeTime) Then
                MsgBox("Enter a valid number", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            sender.text = "CUSTOM (" + customeTime + " MINS)"
        Else
            customeTime = sender.tag
        End If
        'lnkService.Text = customeTime + " MINS"
        'selectedTime = Val(customeTime)
        'lblTotalPrice.Text = "$" + (selectedTime * selectedRoomPerMinuteCost).ToString("0.00")
        sender.backcolor = ActiveButton
        'step3 = sender.name
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

    Private Sub frmServiceTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class