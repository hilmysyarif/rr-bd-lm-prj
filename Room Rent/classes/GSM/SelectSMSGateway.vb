Imports SMSapplication
Imports System.IO.Ports

Public Class SelectSMSGateway
    Dim objclsSMS As New clsSMS
    Dim Port As New SerialPort
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            objclsSMS.ClosePort(Port)
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            objclsSMS.ClosePort(Port)
        Catch ex As Exception
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub rdbModem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbModem.CheckedChanged

        Label2.Visible = rdbModem.Checked
        Button3.Visible = rdbModem.Checked
        ComboBox1.Visible = rdbModem.Checked
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Try
                objclsSMS.ClosePort(Port)
            Catch ex As Exception
            End Try
            Port = objclsSMS.OpenPort(ComboBox1.Text, Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300))
            Dim no As String = InputBox("Enter Mobile Number", "")
            Dim msg As String = InputBox("Enter Message", "")
            If objclsSMS.sendMsg(Port, no, msg) Then
                '//MessageBox.Show("Message has sent successfully");
                MsgBox("Message has sent successfully")
            Else
                '//MessageBox.Show("Failed to send message");
                MsgBox("Failed to send message")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SelectSMSGateway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboBox1.Items.Clear()
            For Each portName In My.Computer.Ports.SerialPortNames
                ComboBox1.Items.Add(portName)
                ComboBox1.Text = portName
            Next
        Catch ex As Exception

        End Try

    End Sub
End Class