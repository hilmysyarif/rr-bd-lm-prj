Imports System.IO
Imports SMSapplication
Imports System.IO.Ports

Public Class frmBulkSMS
    Dim Message As String = ""
    Dim Number As String = ""
    Dim numberS As List(Of SMS_Client)
    Dim w As Integer = 0, t As Integer = 0
    Dim ink As Int16 = 0
    Dim issent As Boolean = False
    Dim i As Integer = 0
    Dim user As String = "9206140739"
    Dim pass As String = "9856637354"
    Dim FailCount = 0
    Dim objclsSMS As New clsSMS
    Dim Port As New SerialPort


    Dim Port_name As String = ""

    Public Sub New(ByVal __List As List(Of SMS_Client))
        Try
            Try
                objclsSMS.ClosePort(Port)
            Catch ex As Exception
            End Try
            Port.Dispose()
        Catch ex As Exception
        End Try
        objclsSMS = Nothing
        objclsSMS = New clsSMS
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        numberS = __List
        Number = __List(0).No__
        Message = __List(0).MSG__

        Try
            Dim fr As New SelectSMSGateway
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                Port_name = fr.ComboBox1.Text
                If fr.rdbWay2sms.Checked Then
                    SendViaWay2sms()
                ElseIf fr.rdbModem.Checked Then
                    Me.ProgressBar1.Maximum = numberS.Count
                    Show()
                    bgwModem.RunWorkerAsync()
                End If
            End If
            fr.Dispose()
        Catch ex As Exception
        End Try
    End Sub
#Region "Way2MSM"

    Sub SendViaWay2sms()

        DisableImages()
        ' Add any initialization after the InitializeComponent() call.
        Me.ProgressBar1.Maximum = numberS.Count
        Label1.Text = "Logging"
        Me.Text = "Logging"
        'WebBrowser1.Stop()
        Dim strLog As String = "http://site5.way2sms.com/content/index.html/Login1.action?username=" & user & "&password=" & pass
        WebBrowser1.Url = New Uri(strLog)
        Show()

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        ' WebBrowser1.DocumentStream.BeginRead()
        If Label1.Text = "Logging" Then
            Dim sr As New StreamReader(WebBrowser1.DocumentStream)
            Dim results As String = sr.ReadToEnd()
            sr.Close()
            If results.Contains("wanama") Then
                Label1.Text = "Logged IN"
                Me.Text = "Logged IN"
                Label1.Text = "Sent"
            Else
                Me.Text = "Logging"
                Label1.Text = "Logging"
                'WebBrowser1.Stop()
                Dim strLog As String = "http://site5.way2sms.com/content/index.html/Login1.action?username=" & user & "&password=" & pass
                WebBrowser1.Url = New Uri(strLog)
                Exit Sub
            End If
            SendSMS(Number, Message)
        Else
            If ink = 1 Then
                Dim sr As New StreamReader(WebBrowser1.DocumentStream)
                Dim results As String = sr.ReadToEnd()
                sr.Close()
                If results.Contains("Message has been submitted successfully") Then
                    Label1.Text = "Sent"
                    Me.Text = "SMS Sent to " & Number
                    If i >= numberS.Count Then
                        Me.Close()
                    End If
                    i += 1
                    FailCount = 0
Read:               Number = numberS(i).No__
                    Message = numberS(i).MSG__
                    ProgressBar1.Value += 1
                    If Not IsNumeric(Number) Or Number.Length <> 10 Then
                        i += 1
                        GoTo Read
                    End If
                    'Threading.Thread.Sleep(30000)
                    'Exit Sub
                    Timer1.Start()
                Else
                    FailCount += 1
                    If FailCount > 5 Then
                        Me.Text = "SMS Sending Failed to " & Number
                        Label1.Text = "Not Sent"
                        If i >= numberS.Count Then
                            Me.Close()
                        End If
                        i += 1
                        FailCount = 0
Read1:                  Number = numberS(i).No__
                        Message = numberS(i).MSG__
                        ProgressBar1.Value += 1
                        If Not IsNumeric(Number) Or Number.Length <> 10 Then
                            i += 1
                            GoTo Read1
                        End If
                        Timer1.Start()
                    Else
                        Me.Text = "SMS Sending Failed to " & Number
                        Label1.Text = "Not Sent"
                        SendSMS(Number, Message)
                    End If
                    'Exit Sub
                End If
            End If

        End If
        WebBrowser1.DocumentStream.Dispose()
    End Sub
    Sub SendSMS(ByVal mob, ByVal msg)
        'WebBrowser1.Stop()
        'msg += Now.ToString("dd-MM-yyyy hh:mm")
        Dim cnt As Integer = 140 - msg.Trim.Length
        Label1.Text = "Sending"
        ink = 1
        Dim UrltoSMS As String = "http://site5.way2sms.com/quicksms.action?HiddenAction=instantsms&catnamedis=Birthday&Action=sa65sdf656fdfd&chkall=on&MobNo=" & mob & "&textArea=" & msg
        WebBrowser1.Url = New Uri(UrltoSMS)
    End Sub

    Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
        e.Cancel = True
    End Sub
    Private Sub frmBulkSMS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Try
                objclsSMS.ClosePort(Port)
            Catch ex As Exception
            End Try
            Port.Dispose()
        Catch ex As Exception
        End Try
        EnableImages()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SendSMS(Number, Message)
        Timer1.Stop()
    End Sub
#End Region
    Function SendSMS(ByVal no As String, ByVal msg As String) As Boolean
        Try
            Return objclsSMS.sendMsg(Port, no, msg)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Sub Connect()
        Try
            objclsSMS.ClosePort(Port)
        Catch ex As Exception
        End Try
        Port.Dispose()
        Port = New SerialPort
        Port = objclsSMS.OpenPort(Port_name, Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300))
    End Sub
    Dim ErrorCount As Integer = 0
    Dim notSend As Integer = 0
    Dim NotSednNos As String = ""
    Private Sub bgwModem_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwModem.DoWork
        ErrorCount = 0
        notSend = 0
        NotSednNos = ""
        Try
            Try
                Connect()
            Catch ex As Exception
            End Try
            For Each no As SMS_Client In numberS
                Threading.Thread.Sleep(2000)
                If Not SendSMS(no.No__, no.MSG__) Then
                    notSend += 1
                    NotSednNos += no.No__ & ", "
                    'Threading.Thread.Sleep(2000)
                    'If Not SendSMS(no.No__, no.MSG__) Then
                    '    Threading.Thread.Sleep(2000)
                    '    If Not SendSMS(no.No__, no.MSG__) Then
                    '        Threading.Thread.Sleep(2000)
                    '        If Not SendSMS(no.No__, no.MSG__) Then
                    '            Threading.Thread.Sleep(2000)
                    '            If Not SendSMS(no.No__, no.MSG__) Then
                    '                notSend += 1
                    '                NotSednNos += no.No__ & ", "
                    '            End If
                    '        End If
                    '    End If
                    'End If
                End If
                bgwModem.ReportProgress(1)
            Next
        Catch ex As Exception
            ErrorCount += 1
        End Try
    End Sub

    Private Sub bgwModem_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwModem.ProgressChanged
        ProgressBar1.Value += 1
        Try
            Me.Text = "Sending SMS : " & ProgressBar1.Value.ToString & " of " & ProgressBar1.Maximum.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgwModem_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwModem.RunWorkerCompleted
        If ErrorCount > 0 Then
            MsgBox("Not complete", MsgBoxStyle.Information, "Error")
        Else
            If notSend = 0 Then
                MsgBox("Complete", MsgBoxStyle.Information, "Complete")
            Else
                MsgBox("Complete with " & notSend.ToString & " errors." & vbNewLine & "Numbers are" & vbNewLine & NotSednNos, MsgBoxStyle.Information, "Complete")
            End If
        End If
        Try
            Try
                objclsSMS.ClosePort(Port)
            Catch ex As Exception
            End Try
            Port.Dispose()
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub
End Class
Public Module IEFunction
    Public Sub DisableImages()
        Try
            Dim regkey As Microsoft.Win32.RegistryKey = _
            My.Computer.Registry.CurrentUser
            regkey.OpenSubKey("Software\Microsoft\Internet Explorer\Main", _
            True).SetValue("Display Inline Images", "no")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub EnableImages()
        Try
            Dim regkey As Microsoft.Win32.RegistryKey = _
            My.Computer.Registry.CurrentUser
            regkey.OpenSubKey("Software\Microsoft\Internet Explorer\Main", _
            True).SetValue("Display Inline Images", "yes")
        Catch ex As Exception
        End Try
    End Sub

End Module