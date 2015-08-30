Imports System.Windows.Forms

Public Class dlgPass

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAdminPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If DeveloperPC() Then
        '    TextBox1.Text = "testpass"
        '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '    Me.Close()
        'End If
        TopMost = IsAllTopMostForm
        
    End Sub
End Class
