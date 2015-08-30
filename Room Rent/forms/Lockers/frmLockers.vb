Public Class frmLockers

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub frmLockers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub frmLockers_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
       LoadLocker()
    End Sub
    Sub LoadLocker()
        ' Threading.Thread.Sleep(5000)
        Dim objLocker As New cls_tblLocker
        Dim dt As DataTable = objLocker.Selection(cls_tblLocker.SelectionType.LOCKER_WITH_LASTBOOKING)
        Dim maxColumn As Integer = Math.Floor((TabControl1.Width - 8) / 205)
        Dim maxRow As Integer = Math.Floor((TabControl1.Height - 58) / 135)
        Dim columnCnt As Integer = 1
        Dim rowCnt As Integer = 1
        TabControl1.TabPages.Clear()
        TabControl1.Controls.Clear()

        Dim MaxinOnePage As Integer = maxColumn * maxRow

        Dim cnt_tabitems As Integer = 1
        Dim pageCount As Integer = 1
        Dim tb As TabPage = Nothing
        For Each dr As DataRow In dt.Rows
            If columnCnt <= maxColumn Then
                Dim lt As String = "# : " & dr("LockerNumber").ToString & vbNewLine & "NAME : " & dr("LockerName").ToString & vbNewLine & "PRICE : " & Val(dr("Price1")).ToString("0.00")
                Dim bt As String = "** NO BOOKING RECORD **"
                Dim lstdate As Date = "01/01/2000"
                Dim Status As String = ""
                Try
                    If Not dr("StartDate") Is Nothing And Not dr("StartDate") Is DBNull.Value And Not dr("Status") Is Nothing And Not dr("StartDate") Is DBNull.Value Then
                        bt = "WORKER : " & dr("ClientName").ToString & vbNewLine & "BOOKED AT : " & CDate(dr("StartDate")).ToString("dd MMM yyyy") & vbNewLine & "STATUS : " & dr("Status").ToString
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
                        lstdate = CDate(dr("EndDate"))
                    End If

                Catch ex As Exception
                End Try
                Dim sl As Integer = 0
                Try
                    If Not dr("SL") Is Nothing And Not dr("SL") Is DBNull.Value Then
                        sl = Val(dr("SL"))
                    End If
                Catch ex As Exception
                End Try
                Dim ls As cntlLocker.LockerStatus = cntlLocker.LockerStatus.NOTBOOKED
                If Status = "STARTED" Then
                    ls = cntlLocker.LockerStatus.BOOKED

                Else
                    If lstdate <= Today.AddDays(-43) Then
                        ls = cntlLocker.LockerStatus.NEVERBOOKED
                    Else
                        ls = cntlLocker.LockerStatus.NOTBOOKED
                    End If
                End If
                If Status = "STOPPED" Then
                    bt = "WORKER : " & dr("ClientName").ToString & vbNewLine & "BOOKED AT : " & CDate(dr("StartDate")).ToString("dd MMM yyyy") & vbNewLine & "STATUS : " & dr("Status").ToString & vbNewLine & "STOPPED AT : " & CDate(dr("EndDate")).ToString("dd MMM yyyy")
                End If
                Dim obj As New cntlLocker(dr("LockerNumber").ToString, lt, bt, ls, sl)
                If cnt_tabitems = 1 Then
                    tb = New TabPage
                    tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    tb.Text = (((pageCount - 1) * MaxinOnePage) + 1).ToString & " - " & (pageCount * MaxinOnePage).ToString
                    tb.AutoScroll = True
                    TabControl1.TabPages.Add(tb)
                End If
                tb.Controls.Add(obj)
                obj.Left = (columnCnt * 5) + ((columnCnt - 1) * 200)
                obj.Top = (rowCnt * 5) + ((rowCnt - 1) * 130)
                AddHandler obj.Click, AddressOf cntlLocker_click
                If columnCnt = maxColumn Then
                    columnCnt = 1
                    rowCnt += 1
                Else
                    columnCnt += 1
                End If
                If Status = "STARTED" Then
                    If Today.AddDays(-6 * 7) > CDate(dr("StartDate")) Then
                        Try
                            Dim obj1 As New cls_tblLockerBooking
                            obj1.Update(sl, "STOPPED", Now)
                            cntlLocker_StatusChange(obj)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
            cnt_tabitems += 1
            If cnt_tabitems > MaxinOnePage Then
                cnt_tabitems = 1
                pageCount += 1
                columnCnt = 1
                rowCnt = 1
            End If
        Next
    End Sub
    Sub cntlLocker_click(ByVal Sender As cntlLocker)
        If Sender.Status = cntlLocker.LockerStatus.BOOKED Then
            If MsgBox("Are you sure to Close the Booking?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
            Try
                Dim obj As New cls_tblLockerBooking
                obj.Update(Sender.SL, "STOPPED", Now)
                cntlLocker_StatusChange(Sender)
            Catch ex As Exception
            End Try
        ElseIf Sender.Status = cntlLocker.LockerStatus.NOTBOOKED Or Sender.Status = cntlLocker.LockerStatus.NEVERBOOKED Then
            Dim frm As New frmSelectWorker
            frm.btnNext.Text = "OK"
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim obj As New cls_tblLockerBooking
                    obj.Insert(Sender.LockerNumber, frm.lstServiceProvider.SelectedItems(0).Text, "", "", Now, Now, Now, "STARTED", 0, "", 0, Val(frm.lstServiceProvider.SelectedItems(0).Tag))
                    cntlLocker_StatusChange(Sender)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Sub cntlLocker_StatusChange(ByRef Sender As cntlLocker)
        Dim objLocker As New cls_tblLocker
        Dim dt As DataTable = objLocker.Selection(cls_tblLocker.SelectionType.LOCKER_WITH_LASTBOOKING, " WHERE A.[LockerNumber]='" & Sender.LockerNumber.ToString & "'")
        Dim dr As DataRow = dt.Rows(0)

        Dim bt As String = "** NO BOOKING RECORD **"
        Dim lstdate As Date = "01/01/2000"
        Dim Status As String = ""

        Try
            If Not dr("StartDate") Is Nothing And Not dr("StartDate") Is DBNull.Value And Not dr("Status") Is Nothing And Not dr("StartDate") Is DBNull.Value Then
                bt = "WORKER : " & dr("ClientName").ToString & vbNewLine & "BOOKED AT : " & CDate(dr("StartDate")).ToString("dd MMM yyyy") & vbNewLine & "STATUS : " & dr("Status").ToString
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
                lstdate = CDate(dr("EndDate"))
            End If

        Catch ex As Exception
        End Try
        Dim sl As Integer = 0
        Try
            If Not dr("SL") Is Nothing And Not dr("SL") Is DBNull.Value Then
                sl = Val(dr("SL"))
            End If
        Catch ex As Exception
        End Try

        Dim ls As cntlLocker.LockerStatus = cntlLocker.LockerStatus.NOTBOOKED
        If Status = "STARTED" Then
            ls = cntlLocker.LockerStatus.BOOKED
        Else
            If lstdate <= Today.AddDays(-43) Then
                ls = cntlLocker.LockerStatus.NEVERBOOKED
            Else
                ls = cntlLocker.LockerStatus.NOTBOOKED
            End If
        End If
        If Status = "STOPPED" Then
            bt = "CLIENT # : " & dr("ClientName").ToString & vbNewLine & "PHONE# : " & dr("PhoneNumber").ToString & vbNewLine & "BOOKED AT : " & CDate(dr("StartDate")).ToString("dd MMM yyyy") & vbNewLine & "STATUS : " & dr("Status").ToString & vbNewLine & "STOPPED AT : " & CDate(dr("EndDate")).ToString("dd MMM yyyy")
        End If
        Sender.Status = ls
        Sender.SL = sl
        Sender.lblBookingDetails.Text = bt
        If ls = cntlLocker.LockerStatus.BOOKED Then
            Sender.BackColor = Color.Red
        ElseIf ls = cntlLocker.LockerStatus.NOTBOOKED Then
            Sender.BackColor = Color.Green
        ElseIf ls = cntlLocker.LockerStatus.NEVERBOOKED Then
            Sender.BackColor = Color.LimeGreen
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoadLocker()
    End Sub
End Class