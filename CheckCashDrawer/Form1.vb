Imports System.IO.Ports

Public Class Form1
    WithEvents Port As SerialPort


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Port = New SerialPort(TextBox1.Text, CInt(Val(TextBox2.Text)), Parity.None, 8, StopBits.One)


        Try
            Port.Open()
            Port.Write(txtMSG.Text)
            Port.Close()
            MsgBox("Done")
        Catch ex As Exception
            MsgBox("Not Done")
        End Try


    End Sub
End Class
