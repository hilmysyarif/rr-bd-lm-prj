Public Class frmLockers2
    Dim lck_started_colr As Color = Color.Red
    Dim lck_avlble_colr As Color = Color.LimeGreen
    Dim lck_5thweek_colr As Color = Color.Orange
    Dim lck_after6thweek_colr As Color = Color.Yellow

    Dim big_font_lck As Font = New Font("Times New Roman", 15.0!, FontStyle.Bold)
    Dim small_font_lck As Font = New Font("Times New Roman", 10.0!, FontStyle.Regular)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub frmLockers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TopMost = IsAllTopMostForm
    End Sub

    Private Sub frmLockers_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        LoadLocker()
    End Sub
    Sub LoadLocker()

        ' Threading.Thread.Sleep(5000)
        Dim objLocker As New cls_Temp_tblLocker
        Dim dt As DataTable = objLocker.Selection(cls_Temp_tblLocker.SelectionType.LOCKER_WITH_LASTBOOKING, " 1=1 Order by A.Sl")
        Dim maxColumn As Integer = 6
        Dim maxRow As Integer = 17

        Dim he As Integer = (dgLockers.Height - 14) / maxRow
        Dim wi As Integer = (dgLockers.Width - 7) / maxColumn
        Dim columnCnt As Integer = 1
        Dim rowCnt As Integer = 1

        dgLockers.Rows.Clear()
        dgLockers.Columns.Clear()
        Dim MaxinOnePage As Integer = maxColumn * maxRow
        Dim cnt_tabitems As Integer = 1
        Dim pageCount As Integer = 1
        For i = 1 To maxColumn
            dgLockers.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "", .Width = wi})
        Next

        For i = 1 To maxRow
            dgLockers.Rows.Add("")
            dgLockers.Rows.Add("")
            dgLockers.Rows(dgLockers.Rows.Count - 2).Height = 18
            dgLockers.Rows(dgLockers.Rows.Count - 1).Height = he - 18
            dgLockers.Rows(dgLockers.Rows.Count - 2).DefaultCellStyle.Font = big_font_lck
            dgLockers.Rows(dgLockers.Rows.Count - 1).DefaultCellStyle.Font = small_font_lck
            dgLockers.Rows(dgLockers.Rows.Count - 1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgLockers.Rows(dgLockers.Rows.Count - 2).DefaultCellStyle.BackColor = dgLockers.BackgroundColor
            dgLockers.Rows(dgLockers.Rows.Count - 1).DefaultCellStyle.BackColor = dgLockers.BackgroundColor
        Next

        Dim itemCounter As Integer = 1
        For Each dr As DataRow In dt.Rows

            'If columnCnt <= maxColumn Then
            Dim lt As String = "# : " & dr("LockerNumber").ToString & "  (" & dr("LockerName").ToString & ") " & currency & "" & Val(dr("Price1")).ToString("0.00")
            Dim bt As String = "** NO BOOKING RECORD **"
            Dim enddate As Date = "01/01/2000"
            Dim startdate As Date = "01/01/2000"
            Dim Status As String = ""

            Try
                If Not dr("StartDate") Is Nothing And Not dr("StartDate") Is DBNull.Value And Not dr("Status") Is Nothing And Not dr("Status") Is DBNull.Value Then
                    bt = dr("ClientName").ToString & " (" & dr("Status").ToString & ")" & " : " & CDate(dr("StartDate")).ToString("dd MMM yyyy")
                End If
            Catch ex As Exception
            End Try
            Try
                If Not dr("Status") Is Nothing And Not dr("Status") Is DBNull.Value Then
                    Status = dr("Status")
                End If
            Catch ex As Exception
            End Try

            Try
                If Not dr("EndDate") Is Nothing And Not dr("EndDate") Is DBNull.Value Then
                    enddate = CDate(dr("EndDate"))
                End If
            Catch ex As Exception
            End Try


            Try
                If Not dr("StartDate") Is Nothing And Not dr("StartDate") Is DBNull.Value Then
                    startdate = CDate(dr("StartDate"))
                End If
            Catch ex As Exception
            End Try
            Dim sl As Integer = 0
            Try
                If Not dr("SL") Is Nothing AndAlso Not dr("SL") Is DBNull.Value Then
                    sl = Val(dr("SL"))
                End If
            Catch ex As Exception
            End Try

            Dim RowNumber As Integer = (((itemCounter - 1) * 2) Mod (maxRow * 2)) + 2
            Dim ColumnNumber As Integer = Math.Floor(((itemCounter - 1) * 2) / (maxRow * 2))

            dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Value = lt
            dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Value = bt

            dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Style.BackColor = lck_avlble_colr
            dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Style.BackColor = lck_avlble_colr

            Try
                If Status = "STARTED" Then

                    dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Style.BackColor = Me.lck_started_colr
                    dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Tag = sl
                    dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Style.BackColor = Me.lck_started_colr
                    dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Tag = sl
                    If startdate <= Today.AddDays(-43) Then
                        dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Style.BackColor = Me.lck_after6thweek_colr
                        dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Style.BackColor = Me.lck_after6thweek_colr
                    ElseIf startdate <= Today.AddDays(-36) Then
                        dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Style.BackColor = Me.lck_5thweek_colr
                        dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Style.BackColor = Me.lck_5thweek_colr
                        'Else
                        '    dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Style.BackColor = Me.lck_avlble_colr
                        '    dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Style.BackColor = Me.lck_avlble_colr
                    End If
                Else
                    dgLockers.Rows(RowNumber - 2).Cells(ColumnNumber).Tag = dr("LockerNumber").ToString
                    dgLockers.Rows(RowNumber - 1).Cells(ColumnNumber).Tag = dr("LockerNumber").ToString
                End If
                If Status = "STARTED" Then
                    If Today.AddDays(-6 * 7) > CDate(dr("StartDate")) Then
                        Try
                            Dim obj1 As New cls_tblLockerBooking
                            obj1.Update(sl, "STOPPED", Now)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Catch ex As Exception
            End Try
            itemCounter += 1
        Next
         
    End Sub
 

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoadLocker()
    End Sub

    Private Sub dgQueuedBooking_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLockers.SelectionChanged
        If sender.SelectedCells.Count >= 1 Then
            dgLockers.SelectedCells(0).Selected = False
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLockers.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex >= 0 Then
                If dgLockers.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Me.lck_started_colr Then
                    If MsgBox("Are you sure to Close the Booking?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    Try
                        Dim obj As New cls_tblLockerBooking
                        obj.Update(dgLockers.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag, "STOPPED", Now)
                        LoadLocker()
                    Catch ex As Exception
                    End Try
                ElseIf {lck_5thweek_colr, lck_after6thweek_colr, lck_avlble_colr}.Contains(dgLockers.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor) Then

                    Dim frm As New frmSelectSP
                    frm.btnNext.Text = "OK"
                    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            Dim obj As New cls_tblLockerBooking

                            If obj.Selection(cls_tblLockerBooking.SelectionType.ALL, "Status='STARTED' and WorkerID=" & Val(frm.lstServiceProvider.SelectedItems(0).Tag).ToString).Rows.Count > 0 Then
                                If MsgBox("SP has already occupied a locker." & vbNewLine & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                                    Exit Sub
                                End If
                            End If

                            Dim total As Integer = (New cls_Temp_tblLocker).Selection(cls_Temp_tblLocker.SelectionType.All, "LockerNumber='" & dgLockers.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString & "'").Rows(0).Item("Price")
                            Dim frmp As New frmPaymentOthers
                            frmp.txtTotalInGST.Text = total.ToString("0.00")
                           frmp.selectedPaymentMode = "CARD"
                            frmp.btnVouchers.Enabled = False



                            If frmp.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim objPayment As New cls_tblPayment

                                Dim objDocket As New cls_Temp_tblDocketMemo
                                Dim MemoNo As Integer = objDocket.Insert("LOCKER BOOKING", Now, "", "")

                                Dim LockerBookingID As Integer = obj.Insert(dgLockers.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag, frm.lstServiceProvider.SelectedItems(0).Text, "", "", Now, Now, Now, "STARTED", 0, "", 0, Val(frm.lstServiceProvider.SelectedItems(0).Tag))
                                objPayment.Insert("LOCKER BOOKING", Val(frmp.txtTotalInGST.Text), LockerBookingID, Now, Val(frmp.txtCash.Text), Val(frmp.txtCard.Text), Val(frmp.txtSurchrgeP.Text), Val(frmp.txtSurchargeAmt.Text), "PAID", frmp.selectedPaymentMode, Val(frmp.txtCard.Text) + Val(frmp.txtSurchargeAmt.Text) + Val(frmp.txtCash.Text), "", 0, 0, MemoNo, Val(frmp.txtCashOut.Text), Val(frmp.txtTip.Text), Val(frmp.txtGST.Text), LoginUserId)
                                clsDocketPrint.PrintDocketMemo(MemoNo)

                                LoadLocker()
                     
                            End If
                        Catch ex As Exception
                            MsgBox("Locker Booking Error" & vbNewLine & ex.Message, MsgBoxStyle.Information, "Info")
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
End Class