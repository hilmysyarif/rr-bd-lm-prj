Public Class MyNumericKeyBoard
    Dim cccc As Control
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'The message ID that tells the textbox to grey out when disabled
        Const WM_ENABLE As Integer = &HA

        'Exit if the message is WM_ENABLE, thus preventing the greyed out look
        If m.Msg = WM_ENABLE Then Exit Sub
        MyBase.WndProc(m)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        Label1.Click, _
        Label2.Click, _
        Label3.Click, _
        Label5.Click, _
        Label6.Click, _
        Label7.Click, _
        Label9.Click, _
        Label10.Click, _
        Label11.Click, _
        Label13.Click 
        'cccc.Focus()
        SendKeys.Send(sender.text)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        'cccc.Focus()
        SendKeys.Send("{BS}")
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        'cccc.Focus()
        SendKeys.Send("{TAB}")
    End Sub


    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'cccc = sender
    End Sub

    Private Sub MyNumericKeyBoard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not DesignMode Then
            'For Each c As Control In FindForm.Controls
            '    AddHandler c.GotFocus, AddressOf Button1_GotFocus
            'Next
        End If
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        SendKeys.Send("{.}")
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click
        Dim frm As Form = Me.FindForm
        ' MsgBox("")
        If TypeOf frm.ActiveControl Is TextBox Then
            If CType(frm.ActiveControl, TextBox).ReadOnly = False And CType(frm.ActiveControl, TextBox).Enabled = True Then
                CType(frm.ActiveControl, TextBox).Text = ""
            End If
        End If
        If TypeOf frm.ActiveControl Is NumericTextBox Then
            If CType(frm.ActiveControl, NumericTextBox).ReadOnly = False And CType(frm.ActiveControl, NumericTextBox).Enabled = True Then
                CType(frm.ActiveControl, NumericTextBox).Text = ""
            End If
        End If

        If TypeOf frm.ActiveControl Is NumericUpDown Then
            If CType(frm.ActiveControl, NumericUpDown).ReadOnly = False And CType(frm.ActiveControl, NumericUpDown).Enabled = True Then
                CType(frm.ActiveControl, NumericUpDown).ResetText() '= ""
            End If
        End If

    End Sub '
End Class
