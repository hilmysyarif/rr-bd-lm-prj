Public Class frmPreBookingHome
    Inherits Form

    Public objWorkers As New cls_tblWorkers

    Private Sub frmHom2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TopMost = IsAllTopMostForm
    End Sub
    Private Sub dgAvailableWorker_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgAvailableWorker1.SelectionChanged, dgAvailableWorker2.SelectionChanged
        If sender.SelectedRows.Count > 0 Then
           If sender.SelectedRows.Count >= 1 Then
                sender.SelectedRows(0).Selected = False
            End If
        End If
    End Sub
    Private Sub dgPrebooking2_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPrebookingNew.CellDoubleClick, dgPreBookingQueue.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim frm1 As New dlgPreBookingEditMenu
            frm1.BookingID = sender.Rows(e.RowIndex).Cells(1).Value
            Select Case frm1.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    RefreshPreBooking()
                Case Windows.Forms.DialogResult.Yes
                    Dim aworkerID As Integer = frmHome.objBooking.SelectDistinct(Database_Table_code_class_tblBookings.FieldName.WorkerID, "[BookingID]=" & frm1.BookingID.ToString).Rows(0).Item(0)
                    If frmHome.StartBookingNew(aworkerID, "", sender.Rows(e.RowIndex).Cells(9).Value.ToString, "CASH", "", "", sender.Rows(e.RowIndex).Cells(10).Value.ToString, "") Then ', dgPrebookingNew.Rows(e.RowIndex).Cells(9).Value.ToString
                        frmHome.objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.BookingType, "PREBOOKING-CONFIRMED", "[BookingID]=" & frm1.BookingID)
                        frmHome.Loadings()
                    End If
            End Select
        End If
    End Sub

    Public Sub refershBooking()
        RefreshPreBooking()
        LoadBookings(dgPreBookingQueue, BookingType.QUEUE_PREBOOKING)
        frmHome.RefreshAvailableWorkersColor_frmPrebookingHome()
    End Sub

    Private Sub dgQueuedBooking_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgActiveBooking.SelectionChanged
        If sender.SelectedRows.Count >= 1 Then
            sender.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub btnBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBooking.Click
        Me.Hide()
    End Sub

    Private Sub btnPreBooking1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreBooking1.Click

        Dim frmClient As New frmSelectClientMember
        Dim frmBD As New frmSelectBookingDate
        Dim frmSV As New frmServiceTime
        Dim frmWorker As New frmSelectSP
        Dim ServiceProvider As String = ""
        Dim bookingDate As String = ""
        Dim bookingTime As String = ""
        Dim custName As String = ""
        Dim Phone As String = ""

Step1:  If frmClient.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        custName = frmClient.CustName
        Phone = frmClient.Phone

Step2:  Select Case frmBD.ShowDialog
            Case Windows.Forms.DialogResult.OK
            Case Windows.Forms.DialogResult.Retry
                GoTo Step1
            Case Else
                Exit Sub
        End Select

Step3:  Select Case frmSV.ShowDialog
            Case Windows.Forms.DialogResult.OK
            Case Windows.Forms.DialogResult.Retry
                GoTo Step2
            Case Else
                Exit Sub
        End Select

        frmWorker.btnNext.Text = "Done"
        objWorkers.LoadWorkerInListView(frmWorker.lstServiceProvider, cls_tblWorkers.SelectionType.AvailableWithoutLogin, frmBD.bookingdate)

Step4:  Select Case frmWorker.ShowDialog
            Case Windows.Forms.DialogResult.OK
            Case Windows.Forms.DialogResult.Retry
                GoTo Step3
            Case Else
                Exit Sub
        End Select


        Dim cardAmt As Double = 0
        Dim cashAmt As Double = 0

        'Create Booking
        Dim obj As New cls_Temp_tblBookings
        Dim MemberID As String = ""
        Dim MemoNo As Integer = 0

        Try
            Dim BookingId As String = obj.Insert("", _
                                                 frmSV.customeTime, _
                                                 Now, _
                                                 frmBD.bookingdate, _
                                                 "PREBOOKING", "", _
                                                 frmWorker.WorkerID, _
                                                 custName, Phone, "", "", 1, MemberID, MemoNo, LoginUserId, False, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

        refershBooking()
        frmHome.RefreshPreBooking()
    End Sub

    Private Sub tmrTimeLeftCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeLeftCounter.Tick
        refershBooking()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Sub RefreshPreBooking()
        LoadBookings(dgPrebookingNew, BookingType.QUEUE_HOME_PAGE_MULTILINE_TODAY_12HRS)
        If dgPrebookingNew.Rows.Count > 0 Then
            Dim c As Integer = 0
            For Each dgRow As DataGridViewRow In dgPrebookingNew.Rows
                Dim newdur As Date = CDate(dgRow.Cells(8).Value)
                If dgRow.Cells(6).Value.ToString.Trim = "CONFIRMED" And dgRow.Cells(7).Value.ToString.Trim = "CONFIRMED" Then
                    dgRow.DefaultCellStyle.BackColor = QueuedPreBookingALLConfirmed
                    c += 1
                ElseIf dgRow.Cells(6).Value.ToString.Trim = "CONFIRMED" Then
                    dgRow.DefaultCellStyle.BackColor = QueuedPreBookingClientConfirmed
                    c += 1
                End If
            Next
            If c > 0 Then
                dgPrebookingNew.Refresh()
            End If
        End If
    End Sub

    Private Sub btnShowPhone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPhone.Click
        If dgPrebookingNew.Columns(2).HeaderText.Trim <> "SP" Then
            dgPrebookingNew.Columns(2).HeaderText = "SP"
        Else
            dgPrebookingNew.Columns(2).HeaderText = "SP " + "PHONE"
        End If
        LoadBookings(dgPrebookingNew, BookingType.QUEUE_HOME_PAGE_MULTILINE_TODAY_12HRS)

        If dgPreBookingQueue.Columns(2).HeaderText.Trim <> "SP" Then
            dgPreBookingQueue.Columns(2).HeaderText = "SP"
        Else
            dgPreBookingQueue.Columns(2).HeaderText = "SP " + "PHONE"
        End If
        LoadBookings(dgPreBookingQueue, BookingType.QUEUE_PREBOOKING)
    End Sub

    Private Sub dgAvailableWorker2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAvailableWorker2.VisibleChanged
        Try
            If dgAvailableWorker2.Visible Then
                TableLayoutPanel1.ColumnStyles(0).Width = 388
            Else
                TableLayoutPanel1.ColumnStyles(0).Width = 200
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmPreBookingHome_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmHome.RefreshAvailableSP_frmPrebookingHome()
        frmHome.RefreshAvailableWorkersColor()
        refershBooking()
    End Sub

End Class