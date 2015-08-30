
Public Class frmServiceTime
    Private _EnableCustomTime As Boolean = False
    Public bookingtype As String = "BOOKING"
    Sub EnableCustomTime(_Shift As String, _Room As String, _SType As String, _Client As String, _SP As String)
        Shift = _Shift
        Room = IIf(_Room = "ESCORT", "ESCORT", "ROOM")
        Client = _Client
        SP = _SP
        serviceType = _SType
        btnCustomMin.Visible = True
        _EnableCustomTime = True
    End Sub

    Public customeTime As String = "120"
    Public serviceType As String = "STANDARD"
    Public customeTimeType As String = "2 HRS"
    Public SelectedTimes As List(Of Integer)

    Public Shift As String = "DAY"
    Public Room As String = "ROOM"
    'Public SType As String = "STANDARD"
    Public Client As String = "1"
    Public SP As String = "1"


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        btn120Min.BackColor = ActiveButton
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Sub SelectTime(_ServiceTime As Integer, _serviceType As String)
        For Each c As Button In grpService.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next

        For Each c As Button In grpService.Controls
            If c.Enabled Then
                If Val(c.Tag) = _ServiceTime Then
                    c.BackColor = ActiveButton
                    customeTime = c.Tag
                End If
            End If
        Next

        If _serviceType = "STANDARD" Then
            btnStandard.BackColor = ActiveButton
        Else
            btnSpecial.BackColor = ActiveButton
        End If
        serviceType = _serviceType
    End Sub
    Private Sub btn30Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn30Min.Click, btn45Min.Click, btn60Min.Click, btn90Min.Click, btn120Min.Click, btnCustomMin.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click, Button9.Click, Button8.Click, Button7.Click, btn20min.Click, Button15.Click, btn5min.Click, Button13.Click, btn10min.Click, btn15min.Click, Button10.Click
        If sender.text.ToString.StartsWith("CUSTOM") Then
            Dim fr As New frmCustomTime
            fr.Shift = Shift
            fr.Room = Room
            fr.SType = serviceType
            fr.Client = Client
            fr.SP = SP
            fr.bookingtype = bookingtype
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                btnCustomMin.Text = "CUSTOM - " & fr.SelectedTime.ToString & " Mins"
                btnCustomMin.Tag = fr.SelectedTime
                SelectedTimes = fr.SelectedTimes
                customeTimeType = "CUSTOM"
                customeTime = sender.tag
                DialogResult = Windows.Forms.DialogResult.OK
            End If
            Exit Sub
        Else
            customeTimeType = sender.text
        End If
        For Each c As Button In grpService.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next

        customeTime = sender.tag
        sender.backcolor = ActiveButton



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

        pnlSpecialService.Visible = MySettings.SpecialServiceEnabled
        If serviceType = "STANDARD" Then
            btnStandard.BackColor = ActiveButton
        Else
            btnSpecial.BackColor = ActiveButton
        End If
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub btnStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandard.Click, btnSpecial.Click

        For Each c As Button In tlpServiceType.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
        sender.backcolor = ActiveButton
        serviceType = sender.text

    End Sub

    Private Sub frmServiceTime_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        SelectTime(customeTime, serviceType)
    End Sub

End Class