Imports System.Windows.Forms

Public Class dlgCardCash
    Public totalAmount As Double = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Val(txtCard.Text) + Val(txtCash.Text) <> totalAmount Then
            MsgBox("Please enter correct amount.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgCardCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSurchrage.Text = MySettings.Surcharge
    End Sub

    Private Sub txtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged, txtCard.TextChanged, txtSurchrage.TextChanged, txtTIP.TextChanged

  

        txtSC.Text = (Val(txtCard.Text) * (Val(txtSurchrage.Text) / 100)).ToString("0.00")
        txtTotak.Text = (Val(txtCard.Text) + Val(txtCash.Text) + Val(txtSC.Text) + Val(txtTIP.Text)).ToString("0.00")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAdminPass
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If frm.TextBox1.Text = MySettings.Password Then
                txtSurchrage.ReadOnly = False
            Else
                MsgBox("invalid password", MsgBoxStyle.Critical, "Info")
            End If
        End If

    End Sub
End Class
