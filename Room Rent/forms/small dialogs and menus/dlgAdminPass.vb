Imports System.Windows.Forms

Public Class dlgAdminPass

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAdminPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DeveloperPC() Then
            TextBox1.Text = MySettings.Password
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            'Me.Close()
        End If

        TopMost = IsAllTopMostForm
        If Text = "" Then
            ToolTip1.SetToolTip(TextBox1, MySettings.PassHint)
        End If
    End Sub
End Class
