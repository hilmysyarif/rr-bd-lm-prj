Imports System.Windows.Forms

Public Class dlgAmount2Numeric

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Val(txtAmount.Value) <= 0 Then
            MsgBox("Enter a valid amount", MsgBoxStyle.Information, "Info")
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
        TopMost = IsAllTopMostForm

    End Sub

    Private Sub txtAmount_GotFocus(sender As Object, e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.Select()
    End Sub
End Class
