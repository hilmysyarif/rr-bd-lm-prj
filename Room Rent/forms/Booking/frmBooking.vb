Public Class frmBooking
    Inherits frmMainMaster
    Private selectedRoomPerMinuteCost As Double = 0
    Private selectedRoom As String = ""
    Private selectedDoor As String = ""
    Private selectedDoorCharge As String = ""
    Private selectedTime As Double = 0
    Private selectedPaymentMode As String = ""


    Private step2 As String = ""
    Private step3 As String = ""
    Private step4 As String = ""
    Private step5 As String = ""

    Private Sub frmBooking_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmBookingHome.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Test Conection
        'Try
        '    Dim clsConn As New clsConnection
        '    clsConn.connect()
        '    MsgBox("Succeed")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        tmrTimeLeftCounter.Start()
    End Sub

    Private Sub frmHome_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        LoadServiceProvider(lstServiceProvider)
        LoadBookings(dgQueuedBooking, BookingType.QUEUE)
        'Dim com As New OleDbCommand(clsQueries.tblBooking_SELECT, obj.connect)
        'Dim da As OleDbDataReader = com.ExecuteReader
        'While da.Read
        '    lstServiceProvider.Items.Add(da.GetValue(1))
        'End While
        'da.Close()
        'com.Dispose()
    End Sub

    Private Sub btnAddServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddServiceProvider.Click

        If txtNewServiceProviderName.Text = "" Then MsgBox("You must enter a Worker name")
        If txtNewServiceProviderName.Text <> "" Then
            lstServiceProvider.Items.Add(txtNewServiceProviderName.Text)
            Dim objServiceProvider As New cls_tblServiceProvider
            objServiceProvider.Insert(txtNewServiceProviderName.Text)
            txtNewServiceProviderName.Text = ""
        End If

    End Sub

    Private Sub btnDeleteServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteServiceProvider.Click

        For I As Integer = 0 To lstServiceProvider.SelectedItems.Count - 1
            lstServiceProvider.Items.Remove(lstServiceProvider.Items(lstServiceProvider.SelectedIndices(I)))
        Next I
        lstServiceProvider.Items.Remove(lstServiceProvider.SelectedItems(0))
        txtNewServiceProviderName.Text = ""

    End Sub

    Private Sub lstServiceProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServiceProvider.SelectedIndexChanged
        If lstServiceProvider.SelectedItems.Count > 0 Then
            grpRoom.Enabled = True
            pnlPaymentMode.Enabled = True
            lnkServiceProvider.Text = lstServiceProvider.SelectedItems(0).Text
            selectedRoomPerMinuteCost = 0
            selectedRoom = ""
            selectedDoor = ""
            selectedTime = 0
            selectedDoorCharge = 0
            selectedPaymentMode = ""
            lnkRoom.Text = ""
            lnkService.Text = ""
        End If
    End Sub

    Private Sub btnROOMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPen.Click, btnEGY.Click, btnASI.Click, btnAFR.Click
        lnkRoom.Text = sender.text
        selectedRoom = sender.text
        selectedRoomPerMinuteCost = Val(sender.tag)
        grpRoom.Enabled = False
        grpService.Enabled = True
        sender.backcolor = Color.Red
        step2 = sender.name
    End Sub

    Private Sub btnSERVICES_MINUTES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn30Min.Click, btn45Min.Click, btn60Min.Click, btn90Min.Click, btn120Min.Click, btnCustomMin.Click
        Dim customeTime As String = ""
        If sender.text = "CUSTOM" Then
            customeTime = InputBox("Enter time in minutes", "Custom", 0)
            If Not IsNumeric(customeTime) Then
                MsgBox("Enter a valid number", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            sender.text = "CUSTOM (" + customeTime + " MINS)"
        Else
            customeTime = sender.tag
        End If
        lnkService.Text = customeTime + " MINS"
        selectedTime = Val(customeTime)
        lblTotalPrice.Text = "$" + (selectedTime * selectedRoomPerMinuteCost).ToString("0.00")
        grpService.Enabled = False
        sender.backcolor = Color.Red
        step3 = sender.name
    End Sub

    Private Sub btnDoorCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrivate.Click, btnLounge.Click
        selectedDoor = sender.text
        selectedDoorCharge = sender.tag
        lblTotalPrice.Text = "$" + ((selectedTime * selectedRoomPerMinuteCost) + Val(sender.tag)).ToString("0.00")
        sender.backcolor = Color.Red
        step4 = sender.name
    End Sub


    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click
        selectedPaymentMode = "CASH"
        pnlPaymentMode.Enabled = False
        sender.backcolor = Color.Red
        step5 = sender.name
    End Sub

    Private Sub btnCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCard.Click
        selectedPaymentMode = "CARD"
        pnlPaymentMode.Enabled = False
        sender.backcolor = Color.Red
        step5 = sender.name
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        grpRoom.Enabled = False
        grpService.Enabled = False
        pnlPaymentMode.Enabled = False

        If selectedPaymentMode = "" Then
            MsgBox("Select a payment Mode", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If lnkServiceProvider.Text <> "" And lnkRoom.Text <> "" And lnkService.Text <> "" Then
            Dim obj As New cls_tblBookings
            Dim BookingId As String = obj.Insert(lnkServiceProvider.Text, _
                                                 selectedRoom, _
                                                 selectedRoomPerMinuteCost, _
                                                 selectedTime, _
                                                 selectedDoor, _
                                                 selectedDoorCharge, _
                                                 Now, _
                                                 Now, _
                                                 "CURRENTBOOK", _
                                                 Val(lblTotalPrice.Text.Replace("$", "")), _
                                                 selectedPaymentMode)

            '   LINC 08-SEP-2013
            '   DETERMINE WHAT THE USER HAS SELECTED FOR THE 1) SERVICE, 2) ROOM AND 3) WORKER, THEN BREAK EACH DOWN AND INSERET INTO QUEUED BOOOKINGS LIST...
            LoadBookings(dgQueuedBooking)



            lnkServiceProvider.Text = ""
            lnkRoom.Text = ""
            lnkService.Text = ""
            lblQueuedQTY.Text = dgQueuedBooking.Rows.Count
            btnPrivate.Enabled = dgQueuedBooking.Rows.Count >= 1

            grpRoom.Controls(step2).BackColor = Nothing
            TryCast(grpRoom.Controls(step2), Button).UseVisualStyleBackColor = True

            grpService.Controls(step3).BackColor = Nothing
            TryCast(grpService.Controls(step3), Button).UseVisualStyleBackColor = True

            grpDoorCharges.Controls(step4).BackColor = Nothing
            TryCast(grpDoorCharges.Controls(step4), Button).UseVisualStyleBackColor = True

            pnlPaymentMode.Controls(step5).BackColor = Nothing
            TryCast(pnlPaymentMode.Controls(step5), Button).UseVisualStyleBackColor = True

            btnCustomMin.Text = "CUSTOM"

        Else
            MsgBox("Select proper values", MsgBoxStyle.Information, "Info")
        End If
    End Sub


    Private Sub btnDeleteBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBooking.Click
        If dgQueuedBooking.RowCount > 0 AndAlso dgQueuedBooking.SelectedCells.Count > 0 Then
            If MsgBox("Are you Sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
            dgQueuedBooking.Rows.Remove(dgQueuedBooking.Rows(dgQueuedBooking.SelectedCells(0).RowIndex))
            lblQueuedQTY.Text = dgQueuedBooking.Rows.Count
            btnPrivate.Enabled = dgQueuedBooking.Rows.Count >= 1
        End If
    End Sub

    Private Sub btnClearBooking_Booking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearBooking.Click
        lnkServiceProvider.Text = ""
        lnkRoom.Text = ""
        lnkService.Text = ""
        grpRoom.Enabled = False
        grpService.Enabled = False
        lblTotalPrice.Text = "$0.00"
    End Sub
    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim FilePath As String = "C:\Users\user\Documents\" & "DC-TEST" & ".pdf"
        'Dim Process As System.Diagnostics.Process = New System.Diagnostics.Process
        'Process.StartInfo.FileName = FilePath
        'Process.Start()
    End Sub

    Private Sub btnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAdmin.Show()
    End Sub

    Private Sub tmrTimeLeftCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeLeftCounter.Tick
        UpdatetimeLeft()
    End Sub
    Sub UpdatetimeLeft()
        If dgQueuedBooking.Rows.Count > 0 Then
            For Each dgRow As DataGridViewRow In dgQueuedBooking.Rows
                If dgRow.Cells(8).Value = "ACTIVE" Then
                    Dim addtime As Date = dgRow.Cells(4).Value
                    Dim duration As Integer = Val(dgRow.Cells(2).Value)
                    dgRow.Cells(3).Value = Math.Floor((duration - (Now - addtime).TotalMinutes)).ToString + " Mins"
                End If
            Next
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim frmMem As New frmPrintMemo
        Dim obj As New cls_tblBookings
        Dim pp As New List(Of OleDbParameter)
        pp.Add(New OleDbParameter("@BookingID", dgQueuedBooking.SelectedRows(0).Cells(7).Value))
        Dim dt As DataTable = obj.Selection("[BookingID]=@BookingID", pp)
        Dim dr As DataRow = dt.Rows(0)
        frmMem.PrintPreview(dr("BookingID"), _
                            dr("ServiceProvider"), _
                            dr("Service").ToString + " Mins", _
                            dr("Room"), _
                            dr("DoorName"), _
                            dr("DoorCharge"), _
                            dr("TotalAmount"), _
                            "$", _
                            dr("PaymentMode"), _
                            "")

    End Sub

End Class
