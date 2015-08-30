Public Class cntlLocker
    Shadows Event Click(ByVal Sender As Object)
    Public LockerNumber As String = ""
    Public SL As Integer = 0
    Public Status As LockerStatus = LockerStatus.BOOKED
    Public bookDate As Date = Now
    Private Sub lblLockerDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLockerDetails.Click, lblBookingDetails.Click, MyBase.Click
        RaiseEvent Click(Me)
    End Sub
    Public Enum LockerStatus
        BOOKED
        NOTBOOKED
        NEVERBOOKED
    End Enum
    Public Sub New(ByVal vLockerNumber As String, ByVal LockerText As String, ByVal BookingText As String, ByVal vStatus As LockerStatus, ByVal vSL As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        LockerNumber = vLockerNumber
        lblBookingDetails.Text = BookingText
        lblLockerDetails.Text = LockerText
        Status = vStatus
        SL = vSL
        If Status = LockerStatus.BOOKED Then
            BackColor = Color.Red
        ElseIf Status = LockerStatus.NOTBOOKED Then
            BackColor = Color.LimeGreen
        ElseIf Status = LockerStatus.NEVERBOOKED Then
            BackColor = Color.Orange
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
