Imports Room_Rent

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

       
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frmPass As New dlgPass
        frmPass.Text = "Enter Project Zip Password"
        If frmPass.ShowDialog = DialogResult.OK Then
            If frmPass.TextBox1.Text = (New clsEncryption).Decrypt(zp) Then
                Dim myset As New cls_tblSettings
                Label1.Text = myset.Password
            Else
                MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim frmPass As New dlgPass
        frmPass.Text = "Enter Project Zip Password"
        If frmPass.ShowDialog = DialogResult.OK Then
            If frmPass.TextBox1.Text = (New clsEncryption).Decrypt(zp) Then
                Dim myset As New cls_tblSettings
                myset.Password = "testpass"
                MsgBox("Done", MsgBoxStyle.Information, "info")
            Else
                MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
    End Sub
End Class
