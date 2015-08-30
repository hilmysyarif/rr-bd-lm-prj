Imports System.Windows.Forms

Public Class dlgEditBooking

    Public adjusttime As Integer = 0
    Dim interval As Integer = 1
    Public Room As String = ""

    Dim vDialogResult As BookingEditResult = Nothing

    Public Enum BookingEditResult
        CHANGE_ROOM
        CHANGE_SP
        CHANGE_SERVICE
        CANCEL
        EXTEND
        SUSPEND
        ADD_SP
        CLEAR
        GO_BACK
        REMOVE_SP
        PAUSE_RESUME
        ADD_CLIENT
        ADJUST_TIME
        SWAP_ROOM
        SWAP_SP
        READ
        EDITBOOKING
        CANCEL_ONERROR
    End Enum

    Public Shadows Property DialogResultEx As BookingEditResult
        Get
            Return vDialogResult
        End Get
        Set(ByVal value As BookingEditResult)
            vDialogResult = value
        End Set
    End Property
    Private Sub dlgExtendDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnReadLoad.Visible = isSoundOn
        PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Question.Handle)
        TopMost = IsAllTopMostForm
    End Sub
    Private Sub dlgEditBooking_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If Room = "ESCORT" Then
            interval = 5
        Else
            interval = 1
        End If
        Try
            Dim gr As Graphics = Label1.CreateGraphics
            Dim h1 As Integer = gr.MeasureString(Label1.Text, Label1.Font, Label1.Width).Height
            Dim h2 As Integer = gr.MeasureString(lblBookingInfo.Text, lblBookingInfo.Font, lblBookingInfo.Width).Height
            Dim h As Integer = 0
            If h1 > h2 Then
                h = h1
            Else
                h = h2
            End If
            Height = Height - (Label1.Height - h) + IIf(h < 80, 90 - h, 20)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.ADD_SP
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResultEx = BookingEditResult.GO_BACK
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnExtend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtend.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.EXTEND
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CLEAR
        Me.Close()
    End Sub

    Private Sub btnRemoveWorker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveWorker.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.REMOVE_SP
        Me.Close()
    End Sub

    Private Sub btnSuspend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuspend.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info") = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.SUSPEND
        Me.Close()
    End Sub

    Private Sub btnChangeWorker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeWorker.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CHANGE_SP
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CANCEL
        Me.Close()
    End Sub

    Private Sub btnChangeRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeRoom.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CHANGE_ROOM
        Me.Close()
    End Sub

    Private Sub btnChangeService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeService.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CHANGE_SERVICE
        Me.Close()
    End Sub

    Private Sub btnPauseStart_Click(sender As System.Object, e As System.EventArgs) Handles btnPauseStart.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.PAUSE_RESUME
        Me.Close()
    End Sub

    Private Sub btnAddClient_Click(sender As System.Object, e As System.EventArgs) Handles btnAddClient.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.ADD_CLIENT
        Me.Close()
    End Sub

    Private Sub btnMinusTime_Click(sender As System.Object, e As System.EventArgs) Handles btnMinusTime.Click
        adjusttime -= interval
        If adjusttime > 0 Then
            lblAdjustTime.Text = "Add " & adjusttime.ToString & " Mins"
       ElseIf adjusttime < 0 Then
            lblAdjustTime.Text = "Less " & -adjusttime.ToString & " Mins"
        Else
            lblAdjustTime.Text = (adjusttime).ToString & " Mins"
        End If
        lblTotal.Text = (Val(lblLeftTime.Text) + adjusttime).ToString & " Mins"
    End Sub

    Private Sub btnPlusTime_Click(sender As System.Object, e As System.EventArgs) Handles btnPlusTime.Click
        adjusttime += interval
        If adjusttime > 0 Then
            lblAdjustTime.Text = "Add " & adjusttime.ToString & " Mins"
        ElseIf adjusttime < 0 Then
            lblAdjustTime.Text = "Less " & -adjusttime.ToString & " Mins"
        Else
            lblAdjustTime.Text = (adjusttime).ToString & " Mins"
        End If  
        lblTotal.Text = (Val(lblLeftTime.Text) + adjusttime).ToString & " Mins"
    End Sub

    Private Sub btnAdjustTime_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjustTime.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.ADJUST_TIME
        Me.Close()
    End Sub

    Private Sub btnSwapRoom_Click(sender As System.Object, e As System.EventArgs) Handles btnSwapRoom.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.SWAP_ROOM
        Me.Close()
    End Sub

    Private Sub btnSwapSP_Click(sender As System.Object, e As System.EventArgs) Handles btnSwapSP.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.SWAP_SP
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnReadLoad.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.READ
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnEditBooking.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.EDITBOOKING
        Me.Close()
    End Sub

    Private Sub lblLeftTime_TextChanged(sender As Object, e As System.EventArgs) Handles lblLeftTime.TextChanged
        lblTotal.Text = (Val(lblLeftTime.Text) + adjusttime).ToString & " Mins"

    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        DialogResultEx = BookingEditResult.CANCEL_ONERROR
        Me.Close()
    End Sub
End Class
