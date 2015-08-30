Public Class frmHome
    Inherits frmSiteMaster


    Public objWorkers As New cls_tblWorkers
    Public objActiveWorkers As New cls_tblActiveWorker
    Public objCheckIN As New cls_tblCheckIN
    Public objBooking As New cls_Temp_tblBookings
    Public objBookingStatus As New cls_Temp_tblBookingStatus
    Public objBookingPause As New cls_tblBookingPause
    Public objDocketMemo As New cls_Temp_tblDocketMemo
    Public objService As New cls_tblService
    Public objRoom As New cls_Temp_tblRoom
    Public objLookUp As New cls_tblLookUp
    Public objInstant As New cls_tblInstant
    Public objExtend As New cls_tblExtraService
    Public objPayment As New cls_Temp_tblBookingPayments
    Public objPaymentOthers As New cls_tblPayment
    Public objEscortInfor As New cls_Temp_tblEscortDriverInfo

    Dim objPaymentDailogClass As New clsPaymentDailog
    Dim totalWorker As Integer = 0
    Dim DoorQTY As Integer = 0

    Private selectedRoom As String = ""
    Private selectedDoor As String = ""
    Private selectedDoorCharge As String = ""
    Private selectedTime As Double = 0
    Private serviceType As String = "STANDARD"
    Private customeTimeType As String = ""
    Private SelectedTimes As List(Of Integer) = Nothing

    Private selectedPaymentMode As String = ""
    Private AvailableWorkerID As Integer = 0
    Private QueueWorkerID As Integer = 0
    Private ActiveWorkerID As Integer = 0

    Private step2 As String = ""
    Private step3 As String = ""
    Private step4 As String = ""
    Private step5 As String = ""

    Public Sub New()
        InitializeComponent()
        LoadRooms()
        btnStandard.BackColor = ActiveButton
        If MySettings.OtherSettings.EscortService Then

        Else
            tblEscortRoomLayout.ColumnStyles(0).Width = 0
        End If
    End Sub


    Public Sub LoadRooms()
        Dim objRooms As New cls_Temp_tblRoom
        For Each dr As DataRow In objRooms.Selection().Rows
            If dr("Room").ToString <> "ESCORT" Then
                Dim roomtxtb As String = "btnRoom" & (Val(dr("Sl"))).ToString("00")
                tlpRoom.Controls(roomtxtb).Tag = dr("FullName").ToString '& ":" & dr("FullName").ToString & ":YES"
                tlpRoom.Controls(roomtxtb).Text = dr("Room").ToString
            End If
        Next
    End Sub

    Public Sub RefreshActiveBookings()
        objActiveWorkers.LoadWorkersInDG(dgActiveBooking, cls_tblActiveWorker.WorkerTypeDG.Active)
        lblWorkerActiveTot1.Text = "Active : " & dgActiveBooking.RowCount.ToString
    End Sub
   
    Public Sub RefreshActiveBookings_frmPrebookingHome()
        objActiveWorkers.LoadWorkersInDG(frmPreBookingHome.dgActiveBooking, cls_tblActiveWorker.WorkerTypeDG.Active)
    End Sub

    Public Sub RefreshQueuedBookings()
        objActiveWorkers.LoadWorkersInDG(dgQueueWorkers, cls_tblActiveWorker.WorkerTypeDG.Queue)
        If dgQueueWorkers.Rows.Count > 0 Then
            If TableLayoutPanel12.ColumnStyles(2).Width = 0 Then
                TableLayoutPanel12.ColumnStyles(2).Width = 30
                TableLayoutPanel12.ColumnStyles(3).Width = 35
                TableLayoutPanel12.ColumnStyles(4).Width = 35
            End If
        Else
            If Not TableLayoutPanel12.ColumnStyles(2).Width = 0 Then
                TableLayoutPanel12.ColumnStyles(2).Width = 0
                TableLayoutPanel12.ColumnStyles(3).Width = 50
                TableLayoutPanel12.ColumnStyles(4).Width = 50
            End If
        End If
    End Sub

    Public Sub RefreshPreBooking()

        LoadBookings(dgPrebookingNew, BookingType.QUEUE_HOME_PAGE_MULTILINE)
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
        frmPreBookingHome.RefreshPreBooking()
    End Sub

    Sub RefreshAvailableSP()
        LoadWorkers(dgAvailableWorker1, dgAvailableWorker2)
        totalWorker = objWorkers.Selection1().Rows.Count
        lblWorkerTot1.Text = "Total SP :" & totalWorker.ToString & ", Available : " & (dgAvailableWorker1.RowCount + dgAvailableWorker2.RowCount).ToString
    End Sub

    Public Sub RefreshAvailableSP_frmPrebookingHome()
        LoadWorkers(frmPreBookingHome.dgAvailableWorker1, frmPreBookingHome.dgAvailableWorker2)
    End Sub

    Private Sub frmHome_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub frmHome_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load all Data's
        btnStartAvailable.Visible = False
        Me_onlOad()
        'Only Developer Can access these options .UndoToolStripMenuItem
        UndoToolStripMenuItem.Visible = DeveloperPC()
        pnlSpecialService.Visible = MySettings.SpecialServiceEnabled
    End Sub

    Sub Me_onlOad()
        SetRainbow()
        Loadings()
        MakeOrderInDG()
        SetFormTextTitleBar()
        UpdateRoomStatus()
    End Sub

    Sub Me_onRelOad()
        Loadings()
    End Sub

    Private Sub frmNewHome01_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not DeveloperPC() Then
            If Screen.AllScreens.Length >= 2 Then
                Select Case True
                    Case Screen.AllScreens(0).Primary
                        Me.Location = Screen.AllScreens(0).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Normal
                        frmPreBookingHome.Show()
                        frmPreBookingHome.Location = Screen.AllScreens(1).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Maximized
                        If Screen.AllScreens.Length >= 3 Then
                            frmMAP.WindowState = FormWindowState.Normal
                            frmMAP.Show()
                            frmMAP.Location = Screen.AllScreens(2).WorkingArea.Location
                            frmMAP.WindowState = FormWindowState.Maximized
                        End If

                    Case Screen.AllScreens(1).Primary
                        Me.Location = Screen.AllScreens(1).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Normal
                        frmPreBookingHome.Show()
                        frmPreBookingHome.Location = Screen.AllScreens(0).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Maximized
                        If Screen.AllScreens.Length >= 3 Then
                            frmMAP.WindowState = FormWindowState.Normal
                            frmMAP.Show()
                            frmMAP.Location = Screen.AllScreens(2).WorkingArea.Location
                            frmMAP.WindowState = FormWindowState.Maximized
                        End If

                    Case Screen.AllScreens(2).Primary
                        Me.Location = Screen.AllScreens(2).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Normal
                        frmPreBookingHome.Show()
                        frmPreBookingHome.Location = Screen.AllScreens(0).WorkingArea.Location
                        frmPreBookingHome.WindowState = FormWindowState.Maximized
                        If Screen.AllScreens.Length >= 3 Then
                            frmMAP.WindowState = FormWindowState.Normal
                            frmMAP.Show()
                            frmMAP.Location = Screen.AllScreens(1).WorkingArea.Location
                            frmMAP.WindowState = FormWindowState.Maximized
                        End If

                End Select

            End If

        ElseIf DeveloperPC() Then ' DO some codes when running on Developer PC

            frmPeroidicFinancialReport2.Show()
            frmSummaryNew.Show()
            frmAdmin.Show()

        End If
        Refresh_NEW()
        CHeckRoomStatus()
        Select Case MySettings.OtherSettings.RoomType
            Case "6 ROOMS"
                Only6Buttons(False)
                Only9Buttons(False)
            Case "9 ROOMS"
                Only6Buttons(True)
                Only9Buttons(False)
            Case "15 ROOMS"
                Only6Buttons(True)
                Only9Buttons(True)
                HideACCButtonsToolStripMenuItem.Enabled = True
                HideACCButtonsToolStripMenuItem.Visible = True
        End Select
    End Sub

    Sub SetFormTextTitleBar()
        Dim pp As New List(Of SqlParameter)
        pp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = Today})
        pp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = Today.AddDays(1)})
        Dim dtI As DataTable = objInstant.Selection("a.[InstantDate] Between @d1 and @d2", pp)
        Dim lounge As Double = 0
        Dim Private1 As Double = 0
        For Each dr As DataRow In dtI.Rows
            If dr("DoorName") = "LOUNGE" Then
                lounge += dr("TotalAmount")
            ElseIf dr("DoorName") = "PRIVATE" Then
                Private1 += dr("TotalAmount")
            End If
        Next
        Text = "Rent Management " & My.Application.Info.Version.ToString & _
            "||Lounge: " & currency & "" & Val(lounge).ToString("0.00") & _
            "||Private: " & currency & "" & Val(Private1).ToString("0.00") & _
            "||Total: " & currency & "" & Val(Private1 + lounge).ToString("0.00") & _
            "|| " & MyShift() & _
           " ||User: " & LoginUserFullName
    End Sub

    Sub MakeOrderInDG()
        For Each c As DataGridViewColumn In dgQueueWorkers.Columns
            c.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next
        For Each c As DataGridViewColumn In dgActiveBooking.Columns
            c.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next
        dgActiveBooking.Columns(10).DisplayIndex = 5
        frmPreBookingHome.dgActiveBooking.Columns(10).DisplayIndex = 5
        dgAvailableWorker1.Columns(2).DisplayIndex = 0
        dgAvailableWorker2.Columns(2).DisplayIndex = 0
        frmPreBookingHome.dgAvailableWorker1.Columns(2).DisplayIndex = 0
        frmPreBookingHome.dgAvailableWorker2.Columns(2).DisplayIndex = 0
        dgActiveBooking.Columns(14).DisplayIndex = 0
        frmPreBookingHome.dgActiveBooking.Columns(14).DisplayIndex = 0
        dgQueueWorkers.Columns(8).DisplayIndex = 0

    End Sub

    Sub LoadWorkers(ByVal dg1 As DataGridView, ByVal dg2 As DataGridView)

        Try
            Dim dddd As Integer = dg2.FirstDisplayedScrollingRowIndex
            If dg1.FindForm.WindowState = FormWindowState.Minimized Then
                Exit Sub
            End If
            Dim IsMe As Boolean = dg1.FindForm Is Me

            Dim RowH As Integer = 32
            Dim MaxInOne As Integer = Math.Floor(dg1.Height / RowH)
            Dim sw As Integer = AvailableWorkerID
            Dim dt As DataTable = Nothing
            dt = objWorkers.Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT' and [Status]<>'SUSPENDED') and [NotAvailableTill]<GETDATE() ORDER BY [WorkerName]")
            dg1.Rows.Clear()
            dg2.Rows.Clear()

            If dt.Rows.Count > MaxInOne Then
                dg2.Visible = True
            Else
                dg2.Visible = False
            End If
            For i = 0 To IIf(MaxInOne > dt.Rows.Count, dt.Rows.Count, MaxInOne) - 1

                Dim drItem As System.Data.DataRow = dt.Rows(i)

                Dim nn As String = ""
                If Not drItem("Nation") Is DBNull.Value AndAlso drItem("Nation").ToString.Trim <> "" Then
                    Try
                        Dim ll As Integer = IIf(drItem("Nation").ToString.Trim.Length > 3, 3, drItem("Nation").ToString.Trim.Length)
                        nn = " (" & drItem("Nation").ToString.Trim.Substring(0, ll) & ")"
                    Catch ex As Exception
                    End Try
                End If
                Dim selecteddcdate As Date = CDate(drItem("dc_date"))
                Dim totd As Integer = Math.Floor((selecteddcdate.AddMonths(3) - Now).TotalDays)
                Dim FavStr As String = ""
                If drItem("Favs") > 0 Then
                    FavStr = " +"
                End If
                If drItem("IsEscort").ToString = "YES" Then
                    FavStr += "{E}"
                End If
                dg1.Rows.Add(drItem("WorkerID").ToString, IIf(totd <= 0, "* ", IIf(drItem("dcf") = "NO", "* ", "")) & drItem("WorkerName").ToString & nn & FavStr, "")
                dg1.Rows(dg1.Rows.Count - 1).Height = RowH
                dg1.Rows(dg1.Rows.Count - 1).Selected = False
                If IsMe Then
                    dg1.Rows(dg1.Rows.Count - 1).ContextMenuStrip = ContextMenuStrip2
                End If

            Next

            For i = MaxInOne To dt.Rows.Count - 1
                Dim drItem As System.Data.DataRow = dt.Rows(i)
                Dim nn As String = ""
                If Not drItem("Nation") Is DBNull.Value AndAlso drItem("Nation").ToString.Trim <> "" Then
                    Try
                        Dim ll As Integer = IIf(drItem("Nation").ToString.Trim.Length > 3, 3, drItem("Nation").ToString.Trim.Length)
                        nn = " (" & drItem("Nation").ToString.Trim.Substring(0, ll) & ")"
                    Catch ex As Exception
                    End Try
                End If
                Dim selecteddcdate As Date = CDate(drItem("dc_date"))
                Dim totd As Integer = Math.Floor((selecteddcdate.AddMonths(3) - Now).TotalDays)
                Dim FavStr As String = ""
                If drItem("Favs") > 0 Then
                    FavStr = " +"
                End If
                If drItem("IsEscort").ToString = "YES" Then
                    FavStr += "{E}"
                End If
                dg2.Rows.Add(drItem("WorkerID").ToString, IIf(totd <= 0, "* ", IIf(drItem("dcf") = "NO", "* ", "")) & drItem("WorkerName").ToString & nn & FavStr, "")
                dg2.Rows(dg2.Rows.Count - 1).Height = RowH
                dg2.Rows(dg2.Rows.Count - 1).Selected = False
                If IsMe Then
                    dg2.Rows(dg2.Rows.Count - 1).ContextMenuStrip = ContextMenuStrip2
                End If
            Next

            For Each dr In dg1.Rows
                dr.Selected = False
                dr.Cells(2).Style.BackColor = Color.White
                dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                If sw = dr.cells(0).value.ToString Then
                    dr.Cells(2).Style.BackColor = Color.Black
                    dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold + FontStyle.Italic + FontStyle.Underline, GraphicsUnit.Point)
                    lnkServiceProvider.Text = dr.Cells(1).Value
                End If
            Next
            For Each dr In dg2.Rows
                dr.Selected = False
                dr.Cells(2).Style.BackColor = Color.White
                dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                If sw = dr.cells(0).value.ToString Then
                    dr.Cells(2).Style.BackColor = Color.Black
                    dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold + FontStyle.Italic + FontStyle.Underline, GraphicsUnit.Point)
                    lnkServiceProvider.Text = dr.Cells(1).Value
                End If
            Next
            If dddd > 0 Then
                dg2.FirstDisplayedScrollingRowIndex = dddd
            End If
            AvailableWorkerID = sw

        Catch ex As Exception
        End Try
    End Sub
    Sub Loadings()
        RefreshAvailableSP()
        RefreshAvailableSP_frmPrebookingHome()
        MainReloader_OnTimerLeftCounter()
        ResetPaymentType()
    End Sub
    Sub ResetPaymentType()
        selectedPaymentMode = ""
        For Each c As Button In grpPaymentMode.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
    End Sub

    Sub LoadingsBeforeReloader()
        btnLounge.Tag = MySettings.OtherSettings.DoorLoungeDay
        btnPrivate.Tag = MySettings.OtherSettings.DoorPrivateDay
        btnPRIVATEINTRO.Tag = MySettings.OtherSettings.DoorPrivateIntroDay

        If MyShiftType() = cls_tblLookUp.PriceType.NIGHT Then
            btnLounge.Tag = MySettings.OtherSettings.DoorLoungeNight
            btnPrivate.Tag = MySettings.OtherSettings.DoorPrivateNight
            btnPRIVATEINTRO.Tag = MySettings.OtherSettings.DoorPrivateIntroNight
        End If
        If btnPRIVATEINTRO.Tag = 0 Then
            btnPRIVATEINTRO.Tag = 20
        End If
        LoadWorkers(dgAvailableWorker1, dgAvailableWorker2)
        RefreshQueuedBookings()
        RefreshActiveBookings()
        RefreshActiveBookings_frmPrebookingHome()
        CheckRoomValidity()
        RefreshPreBooking()
    End Sub

    Sub CheckRoomValidity(Optional ByVal isEnable As Boolean = True, Optional ByVal frmSv As frmSelectRoom = Nothing, Optional ByVal ExcludeRoom As String = "", Optional isDisableOtherNotActiveRooms As Boolean = False)
        Dim cll As Object = Nothing
        If frmSv Is Nothing Then
            cll = tlpRoom.Controls
        Else
            cll = frmSv.grpRoom.Controls
        End If
        For Each c As Button In cll
            Dim countRoomExistance As Integer = 0
            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                If dgr.Cells(2).Value.trim = c.Text.Trim And c.Text.Trim <> "ESCORT" Then
                    countRoomExistance += 1
                End If
            Next
            If Not frmSv Is Nothing Then
                If c.Text.Trim = ExcludeRoom Then
                    countRoomExistance = 0
                End If
            End If
            If countRoomExistance > 0 Then
                If c.Text <> selectedRoom Then
                    'c.BackColor = ActiveStarted(0)
                    'c.ForeColor = ActiveStarted(1)
                End If
            End If
            If Not isEnable And c.Text.Trim <> "PENDING" Then
                c.Enabled = countRoomExistance = 0
            End If
            If isDisableOtherNotActiveRooms Then
                c.Enabled = countRoomExistance <> 0
                If c.Text.Trim = "ESCORT" Or c.Text.Trim = "PENDING" Then
                    c.Enabled = False
                    c.Visible = False
                End If
            End If
        Next
        If Not frmSv Is Nothing Then
            RefreshRoomColor(frmSv, ExcludeRoom)
        End If
    End Sub

    Sub UpdateRoomStatus()
        If objRoom.Update_Status_AUTO() > 0 Then
            frmMap.ResetDisabledRoomText()
            CHeckRoomStatus()
            ClearAllRoomColors()
            RefreshRoomColor()
        End If
    End Sub

    Sub RefreshAvailableWorkersColor_frmPrebookingHome()
        For Each grA As DataGridViewRow In frmPreBookingHome.dgAvailableWorker1.Rows
            Dim countRoomExistance As Integer = 0
            Dim c As Color = Color.White
            Dim c_f As Color = Color.White

            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                For Each s As String In dgr.Cells(0).Value.ToString.Split(",")
                    If Val(s) = Val(grA.Cells(0).Value) Then
                        countRoomExistance += 1
                        c = dgr.DefaultCellStyle.BackColor
                        c_f = dgr.DefaultCellStyle.ForeColor
                        If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                            c = Color.Red
                            c_f = Color.Black
                        End If
                    End If
                Next
            Next

            If countRoomExistance > 0 Then
                grA.DefaultCellStyle.BackColor = c
                grA.DefaultCellStyle.ForeColor = c_f
            Else
                grA.DefaultCellStyle.BackColor = Color.White
                grA.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next

        For Each grA As DataGridViewRow In frmPreBookingHome.dgAvailableWorker2.Rows
            Dim countRoomExistance As Integer = 0
            Dim c As Color = Color.White
            Dim c_f As Color = Color.White
            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                For Each s As String In dgr.Cells(0).Value.ToString.Split(",")
                    If Val(s) = Val(grA.Cells(0).Value) Then
                        countRoomExistance += 1
                        c = dgr.DefaultCellStyle.BackColor
                        c_f = dgr.DefaultCellStyle.ForeColor
                        If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                            c = Color.Red
                            c_f = Color.Black
                        End If
                    End If
                Next
            Next
            If countRoomExistance > 0 Then
                grA.DefaultCellStyle.BackColor = c
                grA.DefaultCellStyle.ForeColor = c_f
            Else
                grA.DefaultCellStyle.BackColor = Color.White
                grA.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

    End Sub

    Sub RefreshAvailableWorkersColor()


        For Each grA As DataGridViewRow In dgAvailableWorker1.Rows
            Dim countRoomExistance As Integer = 0
            Dim c As Color = Color.White
            Dim c_f As Color = Color.Black

            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                For Each s As String In dgr.Cells(0).Value.ToString.Split(",")
                    If Val(s) = Val(grA.Cells(0).Value) Then
                        countRoomExistance += 1
                        c = dgr.DefaultCellStyle.BackColor
                        c_f = dgr.DefaultCellStyle.ForeColor
                        'If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                        '    c = Color.Red
                        'End If
                    End If
                   
                Next
            Next
            If countRoomExistance > 0 Then
                grA.DefaultCellStyle.BackColor = c
                grA.DefaultCellStyle.ForeColor = c_f
            Else
                grA.DefaultCellStyle.BackColor = Color.White
                grA.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        For Each grA As DataGridViewRow In dgAvailableWorker2.Rows
            Dim countRoomExistance As Integer = 0
            Dim c As Color = Color.White
            Dim c_f As Color = Color.Black
            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                For Each s As String In dgr.Cells(0).Value.ToString.Split(",")
                    If Val(s) = Val(grA.Cells(0).Value) Then
                        countRoomExistance += 1
                        c = dgr.DefaultCellStyle.BackColor
                        c_f = dgr.DefaultCellStyle.ForeColor
                        'If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                        '    c = Color.Red
                        'End If
                    End If
                Next
            Next
          
            If countRoomExistance > 0 Then
                grA.DefaultCellStyle.BackColor = c
                grA.DefaultCellStyle.ForeColor = c_f
            Else
                grA.DefaultCellStyle.BackColor = Color.White
                grA.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Sub RefreshAvailableWorkersColor(ByVal frmSV As frmSelectSPAddToActiveRoom)
        For Each grA As DataGridViewRow In frmSV.dgAvailableWorker.Rows
            Dim countRoomExistance As Integer = 0
            Dim c As Color = Color.White
            Dim c_f As Color = Color.Black
            For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                For Each s As String In dgr.Cells(0).Value.ToString.Split(",")
                    If Val(s) = Val(grA.Cells(0).Value) Then
                        countRoomExistance += 1
                        c = dgr.DefaultCellStyle.BackColor
                        c_f = dgr.DefaultCellStyle.ForeColor
                        If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                            c = Color.Red
                        End If
                    End If
                Next
            Next
            If countRoomExistance > 0 Then
                grA.DefaultCellStyle.BackColor = c
                grA.DefaultCellStyle.ForeColor = c_f
            Else
                grA.DefaultCellStyle.BackColor = Color.White
                grA.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Sub RefreshRoomColor(Optional ByVal ExcludeRoom As String = "")
        For Each c As Button In tlpRoom.Controls
            Dim countRoomExistance As Integer = 0
            Dim cl As Color = Color.White
            Dim cl_f As Color = Color.Black
            If c.Text <> selectedRoom And c.Text <> ExcludeRoom Then
                For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                    If dgr.Cells(2).Value.ToString.Trim = c.Text.Trim Then
                        countRoomExistance += 1
                        cl = dgr.DefaultCellStyle.BackColor
                        cl_f = dgr.DefaultCellStyle.ForeColor
                        If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                            cl = Color.Red
                            cl_f = Color.Black
                        End If
                    End If
                Next
            End If
            If countRoomExistance > 0 Then
                c.BackColor = cl
                c.ForeColor = cl_f
            Else
                c.ForeColor = Color.Black
            End If
        Next
        'RefreshMapFormRoomColor()
    End Sub

    Sub RefreshRoomColor(ByVal frmRM As frmSelectRoom, Optional ByVal ExcludeRoom As String = "")
        For Each c As Button In frmRM.grpRoom.Controls
            If c.Text.Trim <> "ESCORT" Then
                Dim countRoomExistance As Integer = 0
                Dim cl As Color = Color.White
                Dim cl_f As Color = Color.Black
                If c.Text <> selectedRoom And c.Text <> ExcludeRoom Then
                    For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                        If dgr.Cells(2).Value.ToString.Trim = c.Text.Trim Then
                            countRoomExistance += 1
                            cl = dgr.DefaultCellStyle.BackColor
                            cl_f = dgr.DefaultCellStyle.ForeColor
                            If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                                cl = Color.Red
                                cl_f = Color.Black
                            End If
                        End If
                    Next
                End If
                If countRoomExistance > 0 Then
                    c.BackColor = cl
                    c.ForeColor = cl_f
                Else
                    c.ForeColor = Color.Black
                End If
            End If
        Next
    End Sub

    Sub CHeckRoomStatus(Optional ByVal SelectForm As frmSelectRoom = Nothing)
        Try
            Dim dtNotUsableRooms As DataTable = objRoom.Selection(cls_Temp_tblRoom.SelectionType.All, "[Usable]='NO'")
            If SelectForm Is Nothing Then
                For Each c As Button In tlpRoom.Controls
                    Dim isUseable As Boolean = True
                    For Each dr As DataRow In dtNotUsableRooms.Rows
                        If dr("ROOM") = c.Text Then
                            isUseable = False
                            Exit For
                        End If
                    Next
                    If Not isUseable Then
                        c.BackColor = NotUseableRooms(0)
                        c.ForeColor = NotUseableRooms(1)
                    End If
                    If c.Text.Trim <> "PENDING" Then
                        c.Enabled = isUseable
                    End If
                Next

                For Each c As Button In frmMAP.AllButtons
                    If c.Tag <> "" Then
                        Dim isUseable As Boolean = True
                        Dim text_add As String = ""
                        For Each dr As DataRow In dtNotUsableRooms.Rows
                            If dr("ROOM") = c.Tag.ToString.Split(":")(0).Trim Then
                                isUseable = False
                                text_add = dr("Status") + vbNewLine + dr("Comment")
                                Exit For
                            End If
                        Next
                        If Not isUseable Then
                            c.BackColor = NotUseableRooms(0)
                            c.ForeColor = NotUseableRooms(1)
                            c.Text = c.Tag.ToString.Split(":")(1).Trim + vbNewLine + text_add
                        End If
                        c.Tag = c.Tag.ToString.Split(":")(0).Trim + ":" + c.Tag.ToString.Split(":")(1).Trim + ":" + IIf(isUseable, "YES", "NO")
                        'c.Enabled = isUseable
                    End If

                Next
            Else
                For Each c As Button In SelectForm.grpRoom.Controls
                    Dim isUseable As Boolean = True
                    For Each dr As DataRow In dtNotUsableRooms.Rows
                        If dr("ROOM") = c.Text Then
                            isUseable = False
                            Exit For
                        End If
                    Next
                    If Not isUseable Then
                        c.BackColor = NotUseableRooms(0)
                        c.ForeColor = NotUseableRooms(1)
                    End If
                    If c.Text.Trim <> "PENDING" Then
                        c.Enabled = isUseable
                    End If

                Next
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub RefreshMapFormRoomColor()
        Try
            For Each c As Button In frmMAP.AllButtons
                If c.Tag <> "" Then
                    Dim countRoomExistance As Integer = 0
                    Dim cl As Color = Color.White
                    Dim cl_f As Color = Color.Black

                    Dim Workers As String = ""
                    Dim TimeLeft As String = ""
                    For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                        If dgr.Cells(2).Value.ToString.Trim = c.Tag.ToString.Split(":")(0).Trim Then
                            countRoomExistance += 1
                            cl = dgr.DefaultCellStyle.BackColor
                            cl_f = dgr.DefaultCellStyle.ForeColor
                            If Val(dgr.Cells(4).Value.ToString) <= -5 Then
                                cl = Color.Red
                                cl_f = Color.Black
                            End If
                            Workers = dgr.Cells(1).Value.ToString.Trim
                            TimeLeft = dgr.Cells(4).Value.ToString.Trim
                        End If
                    Next
                    If countRoomExistance > 0 Then
                        c.BackColor = cl
                        c.ForeColor = cl_f
                        c.Text = c.Tag.ToString.Split(":")(1).Trim & vbNewLine & Workers & vbNewLine & TimeLeft
                    Else
                        If c.Tag.ToString.Split(":")(2).Trim = "YES" Then
                            c.BackColor = frmMAP.grpRoom_GC.BackColor
                            c.ForeColor = frmMAP.grpRoom_GC.ForeColor
                            c.Text = c.Tag.ToString.Split(":")(1).Trim
                        End If
                    End If
                End If

            Next
        Catch ex As Exception
        End Try
    End Sub
    Function IsRoomValid(ByVal RoomName As String) As Boolean
        Dim ret As Boolean = True
        Dim countRoomExistance As Integer = 0
        For Each dgr As DataGridViewRow In dgActiveBooking.Rows
            If dgr.Cells(2).Value = RoomName Then
                countRoomExistance += 1
            End If
        Next
        ret = countRoomExistance = 0
        Return ret
    End Function

    Function IsWorkerActive(ByVal WorkerID As Integer) As Boolean
        Dim ret As Boolean = True
        Dim countRoomExistance As Integer = 0
        For Each dgr As DataGridViewRow In dgActiveBooking.Rows
            For Each s As String In dgr.Cells(0).Value.ToString().Split(",")
                If s = WorkerID Then
                    countRoomExistance += 1
                End If
            Next
        Next
        ret = countRoomExistance = 0
        Return ret
    End Function

    Function IsWorkerQUEUE(ByVal WorkerID As Integer) As Boolean
        Dim ret As Boolean = True
        Dim countRoomExistance As Integer = 0
        For Each dgr As DataGridViewRow In dgActiveBooking.Rows
            If dgr.Cells(0).Value = WorkerID Then
                countRoomExistance += 1
            End If
        Next
        ret = countRoomExistance = 0
        Return ret
    End Function

    Private Sub btnBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPreBookingHome.Show()
        frmPreBookingHome.Activate()
    End Sub

    Private Sub tmrFlasher_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlasher.Tick

        If dgPrebookingNew.Rows.Count > 0 Then
            Dim c As Integer = 0
            For Each dgRow As DataGridViewRow In dgPrebookingNew.Rows
                Dim newdur As Date = CDate(dgRow.Cells(8).Value)
                If (newdur - Now).TotalMinutes <= 120 And dgRow.Cells(6).Value.ToString.Trim = "" And dgRow.Cells(6).Value.ToString.Trim = "" Then
                    If dgRow.DefaultCellStyle.BackColor = Color.White Then
                        dgRow.DefaultCellStyle.BackColor = Color.Green
                    Else
                        dgRow.DefaultCellStyle.BackColor = Color.White
                    End If
                    c += 1
                End If
            Next

            If c > 0 Then
                dgPrebookingNew.Refresh()
            End If
        End If

        If frmPreBookingHome.dgPrebookingNew.Rows.Count > 0 Then
            Dim c As Integer = 0
            For Each dgRow As DataGridViewRow In frmPreBookingHome.dgPrebookingNew.Rows
                Dim newdur As Date = CDate(dgRow.Cells(8).Value)
                If (newdur - Now).TotalMinutes <= 120 And dgRow.Cells(6).Value.ToString.Trim = "" And dgRow.Cells(6).Value.ToString.Trim = "" Then
                    If dgRow.DefaultCellStyle.BackColor = Color.White Then
                        dgRow.DefaultCellStyle.BackColor = Color.Green
                    Else
                        dgRow.DefaultCellStyle.BackColor = Color.White
                    End If
                    c += 1
                End If
            Next
            If c > 0 Then
                frmPreBookingHome.dgPrebookingNew.Refresh()
            End If
        End If
        RefreshAvailableWorkersColor()
        RefreshRoomColor()
    End Sub
    Private Sub tmrTimeLeftCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeLeftCounter.Tick
        MainReloader_OnTimerLeftCounter()
    End Sub

    Structure BookingWorking
        Dim BookingId As Integer
        Dim Warning As String
        Sub New(ByVal bid As Integer, ByVal wrn As String)
            BookingId = bid
            Warning = wrn
        End Sub
    End Structure
    Dim BookingWarnings As New List(Of BookingWorking)

    ''' <summary>
    ''' Refresh Active booking list, worker list, Time left for each booking and also generate sound if speaker option is turned ON.
    ''' </summary>
    ''' <remarks></remarks>
    Sub MainReloader_OnTimerLeftCounter()
        SetFormTextTitleBar()
        LoadingsBeforeReloader()
        If dgActiveBooking.Rows.Count > 0 Then
            Dim isSpeaking As Boolean = False
            Try
                isSpeaking = mySpeaker.State = Speech.Synthesis.SynthesizerState.Speaking
            Catch ex As Exception
            End Try
            For Each dgRow As DataGridViewRow In dgActiveBooking.Rows
                If dgRow.Cells(7).Value = "STARTED" Then
                    Dim PMinute() As String = dgRow.Cells(11).Value.ToString.Split(",")
                    Dim PStatus As String = dgRow.Cells(12).Value
                    Dim PDate As String = dgRow.Cells(13).Value
                    Try
                        Dim addtime As Date = dgRow.Cells(5).Value.ToString.Split(vbNewLine)(0)

                        Dim CurrentTime As Date = Now
                        Try
                            If PStatus = "PAUSED" Then
                                CurrentTime = PDate
                                If CurrentTime < addtime Then
                                    CurrentTime = addtime
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                        Dim BookingID As String = dgRow.Cells(9).Value
                        Dim roomName As String = dgRow.Cells(2).Value

                        Try
                            For Each c As Button In tlpRoom.Controls
                                If c.Text = dgRow.Cells(2).Value Then
                                    roomName = c.Tag
                                End If
                            Next
                        Catch ex As Exception
                        End Try

                        Dim workerName As String = "" 'dgRow.Cells(1).Value.ToString.Split(vbNewLine)(0).Split("(")(0)
                        For Each s As String In dgRow.Cells(1).Value.ToString.Split(vbNewLine)
                            If s.Trim <> "" Then
                                Try
                                    If workerName <> "" Then
                                        workerName += ","
                                    End If
                                    workerName += " " & s.Split("(")(0).Trim
                                Catch ex As Exception
                                End Try
                            End If
                        Next

                        Try
                            workerName = workerName.Insert(workerName.LastIndexOf(","), " and ")
                            workerName = workerName.Remove(workerName.LastIndexOf(","), 1)
                            'workerName = workerName.Remove(workerName.LastIndexOf("and"), 3)
                        Catch ex As Exception
                        End Try
                        workerName = workerName.Trim
                        Dim duration As Integer = Val(dgRow.Cells(3).Value)
                        Dim newdur As Integer = Math.Ceiling((duration - (CurrentTime - addtime).TotalMinutes)) + PMinute(0) - IIf(CDate(PDate) > addtime Or PStatus = "", 0, (addtime - CDate(PDate)).Minutes)
                        dgRow.Cells(4).Value = newdur.ToString + " Mins"

                        If PStatus = "PAUSED" Then
                            dgRow.DefaultCellStyle.BackColor = PausedBooking(0)
                            dgRow.DefaultCellStyle.ForeColor = IIf(newdur > 0, PausedBooking(1), Active0MinsLeft(0))
                            dgActiveBooking.Refresh()
                            If (Now - CDate(PDate)).TotalSeconds > 300 Then
                                If dgRow.DefaultCellStyle.BackColor <> PausedBookingWarning(0) Then
                                    dgRow.DefaultCellStyle.BackColor = PausedBookingWarning(0)
                                    dgRow.DefaultCellStyle.ForeColor = PausedBookingWarning(1)
                                    dgActiveBooking.Refresh()

                                End If
                            End If
                        Else
                            If newdur > 5 And newdur <= 10 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active10MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active10MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active10MinsLeft(1)
                                    dgActiveBooking.Refresh()
                                End If
                            ElseIf newdur > 0 And newdur <= 5 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active5MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active5MinsLeft(1)
                                    dgActiveBooking.Refresh()
                                End If

                            ElseIf newdur > -5 And newdur <= 0 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active_5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active_5MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active_5MinsLeft(1)
                                    dgActiveBooking.Refresh()
                                End If
                            ElseIf newdur <= -5 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active_5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active0MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active0MinsLeft(1)
                                    dgActiveBooking.Refresh()
                                End If
                            End If
                        End If




                        Dim listoftimes As List(Of Integer) = Nothing
                        listoftimes = New List(Of Integer) From {1, 3, 5, 7, 10}

                        If roomName = "ESCORT" Then
                            listoftimes = New List(Of Integer) From {1, 3, 5, 7, 10, 15, 20}
                        End If

                        If Not isSpeaking Then
                            If listoftimes.Contains(newdur) Then
                                If isSoundOn Then
                                    If Not BookingWarnings.Contains(New BookingWorking(BookingID, newdur.ToString & "MIN" & duration.ToString)) Then
                                        mySpeaker.SpeakAsync("ATTENTION : " & newdur.ToString & " minutes service left for " & workerName & IIf(roomName <> "ESCORT", " in room " & roomName & ".", " in Escort Booking."))
                                        BookingWarnings.Add(New BookingWorking(BookingID, newdur.ToString & "MIN" & duration.ToString))
                                    End If
                                End If
                            ElseIf newdur <= 0 Then
                                If isSoundOn Then
                                    If Not BookingWarnings.Contains(New BookingWorking(BookingID, "0MIN" & duration.ToString)) Then
                                        mySpeaker.SpeakAsync("ATTENTION : " & workerName & "'s " & IIf(roomName <> "ESCORT", "booking in room " & roomName & "", "Escort booking") & " has Expired.")
                                    End If
                                End If
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    Dim TotWorker As Integer = 0
                    Dim NegWorker As Integer = 0
                    Try
                        Dim addtimes() As String = dgRow.Cells(5).Value.ToString.Split(vbNewLine)
                        Dim workers() As String = dgRow.Cells(1).Value.ToString.Split(vbNewLine)
                        dgRow.Cells(1).Value = ""
                        For i = 0 To addtimes.Length - 1
                            Dim addtime As Date = addtimes(i)
                            Dim workern As String = workers(i)
                            Dim workern_new As String = workern.Split("(")(0).Trim
                            If workern.Contains("(E)") Then
                                workern_new += " (E)"
                            End If

                            Dim duration As String = workern.Split("/")(1).Replace(")", "")
                            Dim CurrentTime As Date = Now
                            Try
                                If PStatus = "PAUSED" Then
                                    CurrentTime = PDate
                                    If CurrentTime < addtime Then
                                        CurrentTime = addtime
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                            Dim newdur As Integer = Math.Ceiling((Val(duration) - (CurrentTime - addtime).TotalMinutes)) + PMinute(i) - IIf(CDate(PDate) > addtime, 0, (addtime - CDate(PDate)).Minutes)
                            dgRow.Cells(1).Value += workern_new + " (" + newdur.ToString + "/" + duration.ToString + ")" + vbNewLine
                            If newdur <= 0 Then
                                NegWorker += 1
                            End If
                            TotWorker = addtimes.Length
                        Next
                        dgRow.Cells(1).Value = dgRow.Cells(1).Value.ToString.Trim
                        If TotWorker <> NegWorker And NegWorker > 0 And PStatus <> "PAUSED" Then
                            dgRow.DefaultCellStyle.BackColor = Active_SomeNeedCLear(0)
                            dgRow.DefaultCellStyle.ForeColor = Active_SomeNeedCLear(1)
                            '   ToolTip1.SetToolTip(dgRow, "Test worker")

                        End If

                    Catch ex As Exception
                    End Try

                End If

            Next

            For Each dgRow As DataGridViewRow In frmPreBookingHome.dgActiveBooking.Rows
                If dgRow.Cells(7).Value = "STARTED" Then
                    Dim PMinute() As String = dgRow.Cells(11).Value.ToString.Split(",")
                    Dim PStatus As String = dgRow.Cells(12).Value
                    Dim PDate As String = dgRow.Cells(13).Value
                    Try
                        Dim addtime As Date = dgRow.Cells(5).Value.ToString.Split(vbNewLine)(0)
                        Dim CurrentTime As Date = Now
                        Try
                            If PStatus = "PAUSED" Then
                                CurrentTime = PDate
                                If CurrentTime < addtime Then
                                    CurrentTime = addtime
                                End If
                            End If

                        Catch ex As Exception
                        End Try
                        Dim duration As Integer = Val(dgRow.Cells(3).Value)
                        Dim newdur As Integer = Math.Ceiling((duration - (CurrentTime - addtime).TotalMinutes)) + PMinute(0) - IIf(CDate(PDate) > addtime Or PStatus = "", 0, (addtime - CDate(PDate)).Minutes)
                        dgRow.Cells(4).Value = newdur.ToString + " Mins"

                        If PStatus = "PAUSED" Then
                            dgRow.DefaultCellStyle.BackColor = PausedBooking(0)
                            dgRow.DefaultCellStyle.ForeColor = IIf(newdur > 0, PausedBooking(1), Active0MinsLeft(0))
                            dgActiveBooking.Refresh()
                        Else
                            If newdur > 5 And newdur <= 10 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active10MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active10MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active10MinsLeft(1)
                                    frmPreBookingHome.dgActiveBooking.Refresh()
                                End If
                            ElseIf newdur > 0 And newdur <= 5 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active5MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active5MinsLeft(1)
                                    frmPreBookingHome.dgActiveBooking.Refresh()
                                End If
                            ElseIf newdur > -5 And newdur <= 0 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active_5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active_5MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active_5MinsLeft(1)
                                    frmPreBookingHome.dgActiveBooking.Refresh()
                                End If
                            ElseIf newdur <= -5 Then
                                If dgRow.DefaultCellStyle.BackColor <> Active_5MinsLeft(0) Then
                                    dgRow.DefaultCellStyle.BackColor = Active0MinsLeft(0)
                                    dgRow.DefaultCellStyle.ForeColor = Active0MinsLeft(1)
                                    dgActiveBooking.Refresh()
                                End If
                            End If
                        End If

                    Catch ex As Exception
                    End Try


                    Try

                        Dim addtimes() As String = dgRow.Cells(5).Value.ToString.Split(vbNewLine)
                        Dim workers() As String = dgRow.Cells(1).Value.ToString.Split(vbNewLine)
                        dgRow.Cells(1).Value = ""
                        For i = 0 To addtimes.Length - 1

                            Dim addtime As Date = addtimes(i)
                            Dim workern As String = workers(i)
                            Dim workern_new As String = workern.Split("(")(0).Trim
                            If workern.Contains("(E)") Then
                                workern_new += " (E)"
                            End If
                            Dim duration As Integer = Val(workern.Split("/")(1).Replace(")", ""))
                            Dim CurrentTime As Date = Now
                            Try
                                If PStatus = "PAUSED" Then
                                    CurrentTime = PDate
                                    If CurrentTime < addtime Then
                                        CurrentTime = addtime
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                            Dim newdur As Integer = Math.Ceiling((Val(duration) - (CurrentTime - addtime).TotalMinutes)) + PMinute(i) - IIf(CDate(PDate) > addtime, 0, (addtime - CDate(PDate)).Minutes)
                            dgRow.Cells(1).Value += workern_new + " (" + newdur.ToString + "/" + duration.ToString + ")" + vbNewLine
                        Next
                        dgRow.Cells(1).Value = dgRow.Cells(1).Value.ToString.Trim
                    Catch ex As Exception
                    End Try

                End If

            Next
        End If
        RefreshMapFormRoomColor()
    End Sub


    Public Sub ClearAllRoomColors()
        For Each c As Button In tlpRoom.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
    End Sub

    Private Sub btnROOMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoom01.Click, btnRoom02.Click, btnRoom03.Click, btnRoom04.Click, btnRoom05.Click, btnRoom06.Click, btnRoom07.Click, btnRoom08.Click, btnRoom09.Click, btnRoom10.Click, btnRoom11.Click, btnRoom12.Click, btnEscort.Click, btnRoom13.Click, btnRoom14.Click, btnRoom15.Click, btnHOLD.Click
        If sender.text = "ESCORT" Then 
            For Each c As Button In tlpServiceType.Controls
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            Next
            btnDeluxe.BackColor = ActiveButton
            serviceType = btnDeluxe.Text
            btnStandard.Enabled = False
            btnStandard.BackColor = Color.Gray
        ElseIf selectedRoom = "ESCORT" Then
            btnStandard.Enabled = True
            For Each c As Button In tlpServiceType.Controls
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            Next
            btnStandard.BackColor = ActiveButton
            serviceType = btnStandard.Text
        End If
        If selectedTime > 0 And Not MySettings.OtherSettings.SameEscortPrice Then
            Dim ppp As cls_tblLookUp.PriceSpec
            Try
                ppp = objLookUp.GetPrice(1, 1, selectedTime, serviceType, sender.text)
            Catch ex As Exception
                MsgBox("Please set lookup database for " & sender.text & " " & selectedTime & " mins " & serviceType & " " & MyShiftDayPrice(), MsgBoxStyle.Information, "Info")
                selectedTime = 0
                For Each c As Button In tlpService.Controls
                    c.BackColor = Nothing
                    c.UseVisualStyleBackColor = True
                Next
            End Try
        End If
        ClearAllRoomColors()
        RefreshRoomColor()

        btnEscort.BackColor = Nothing
        btnEscort.UseVisualStyleBackColor = True
        btnHOLD.BackColor = Nothing
        btnHOLD.UseVisualStyleBackColor = True

        lnkRoom.Text = sender.text
        sender.backcolor = ActiveButton
        step2 = sender.name

        If sender.text = "ESCORT" Then
            If selectedTime < 120 And selectedTime <> 60 Then
                selectedTime = 0
                For Each c As Button In tlpService.Controls
                    c.BackColor = Nothing
                    c.UseVisualStyleBackColor = True
                Next
            End If
            btn30Min.Enabled = False
            btn45Min.Enabled = False
            btn20Min.Enabled = False
            btn90Min.Enabled = False
            btn30Min.BackColor = Color.Gray
            btn45Min.BackColor = Color.Gray
            btn20Min.BackColor = Color.Gray
            btn90Min.BackColor = Color.Gray
        ElseIf selectedRoom = "ESCORT" Then
            btn30Min.Enabled = True
            btn45Min.Enabled = True
            btn20Min.Enabled = True
            btn90Min.Enabled = True

            btn30Min.BackColor = Nothing
            btn45Min.BackColor = Nothing
            btn20Min.BackColor = Nothing
            btn90Min.BackColor = Nothing

            btn30Min.UseVisualStyleBackColor = True
            btn45Min.UseVisualStyleBackColor = True
            btn20Min.UseVisualStyleBackColor = True
            btn90Min.UseVisualStyleBackColor = True

        End If

        selectedRoom = sender.text

    End Sub
    Sub ShowOtherWindow()
        Dim frmTimeSelect_obj As New frmServiceTime
        Dim Shift As cls_tblLookUp.PriceType = MyShiftType()
        If selectedRoom = "ESCORT" Then

            If Not MySettings.OtherSettings.MultipleEscortPrice Then
                Shift = cls_tblLookUp.PriceType.NIGHT
            Else
                Dim frmDlgShift As New frmSelectShift
                If frmDlgShift.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
                Shift = frmDlgShift.SelectedShift
            End If
        End If

        frmTimeSelect_obj.EnableCustomTime(Shift.ToString, selectedRoom, serviceType, 1, 1)

        If selectedRoom = "ESCORT" Then

            frmTimeSelect_obj.btn5min.Enabled = False
            frmTimeSelect_obj.btn10min.Enabled = False
            frmTimeSelect_obj.btn15min.Enabled = False
            frmTimeSelect_obj.btn20min.Enabled = False
            frmTimeSelect_obj.btn30Min.Enabled = False
            frmTimeSelect_obj.btn45Min.Enabled = False
            frmTimeSelect_obj.btn90Min.Enabled = False

            frmTimeSelect_obj.btn5min.BackColor = Color.Gray
            frmTimeSelect_obj.btn10min.BackColor = Color.Gray
            frmTimeSelect_obj.btn15min.BackColor = Color.Gray
            frmTimeSelect_obj.btn20min.BackColor = Color.Gray
            frmTimeSelect_obj.btn30Min.BackColor = Color.Gray
            frmTimeSelect_obj.btn45Min.BackColor = Color.Gray
            frmTimeSelect_obj.btn90Min.BackColor = Color.Gray

            frmTimeSelect_obj.btnStandard.Enabled = False
            frmTimeSelect_obj.btnStandard.BackColor = Color.Gray
            frmTimeSelect_obj.serviceType = frmTimeSelect_obj.btnSpecial.Text

        End If

        Select Case frmTimeSelect_obj.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                selectedTime = frmTimeSelect_obj.customeTime
                serviceType = frmTimeSelect_obj.serviceType
                customeTimeType = frmTimeSelect_obj.customeTimeType
                SelectedTimes = frmTimeSelect_obj.SelectedTimes
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub

            Case Else
                Exit Sub
        End Select

        lnkService.Text = selectedTime.ToString + " MINS"
        For Each c As Button In tlpService.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
        Select Case selectedTime
            Case 20
                btn20Min.BackColor = ActiveButton
            Case 30
                btn30Min.BackColor = ActiveButton

            Case 45
                btn45Min.BackColor = ActiveButton

            Case 60
                btn60Min.BackColor = ActiveButton

            Case 90
                btn90Min.BackColor = ActiveButton

            Case 120
                btn120Min.BackColor = ActiveButton

            Case 150
                btn150Mins.BackColor = ActiveButton

            Case 180
                btn180Mins.BackColor = ActiveButton

            Case 210
                btn210Mins.BackColor = ActiveButton

                'Case 240
                '    btn24Mins.BackColor = ActiveButton

                'Case 300
                '    btn210Mins.BackColor = ActiveButton

            Case Else
                btnOtherTime.BackColor = ActiveButton
        End Select
        step3 = "btnOtherTime"
        If AvailableWorkerID > 0 Then
            StartBookingNew(AvailableWorkerID, selectedRoom, selectedTime, selectedPaymentMode, "", 0, "", "", Shift) ', selectedTimeType)
        Else
            MsgBox("Select SP", MsgBoxStyle.Information, "info")
        End If
    End Sub
    Private Sub btnSERVICES_MINUTES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn30Min.Click, btn45Min.Click, btn60Min.Click, btn90Min.Click, btn120Min.Click, btnCustomMin.Click, btn150Mins.Click, btn180Mins.Click, btn210Mins.Click, btnOtherTime.Click, btn20Min.Click
        customeTimeType = ""
        SelectedTimes = Nothing
        If sender.name = "btnCustomMin" Then
            StartBookingCustom()
        ElseIf sender.name = "btnOtherTime" Then
            If AvailableWorkerID = 0 Or selectedRoom = "" Then
                MsgBox("Select a SP and Room first", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            ShowOtherWindow()
        Else
            If Not MySettings.OtherSettings.SameEscortPrice Then
            End If
            If selectedRoom = "" Then
                MsgBox("Please select a Room First", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim ppp As cls_tblLookUp.PriceSpec
            Try
                ppp = objLookUp.GetPrice(1, 1, Val(sender.tag), serviceType, selectedRoom)
            Catch ex As Exception
                MsgBox("Please set lookup database for " & selectedRoom & " " & sender.text & " Service " & serviceType & " " & MyShiftDayPrice(), MsgBoxStyle.Information, "Info")
                Exit Sub
            End Try
            For Each c As Button In tlpService.Controls
                If c.Enabled Then
                    c.BackColor = Nothing
                    c.UseVisualStyleBackColor = True
                End If
            Next
            Dim customeTime As String = ""
            customeTime = sender.tag
            lnkService.Text = customeTime + " MINS"
            selectedTime = Val(customeTime)
            lblTotalPrice.Text = "" & currency & "" + (ppp.Price).ToString("0.00")
            sender.backcolor = ActiveButton
            step3 = sender.name
            If AvailableWorkerID > 0 Then
                StartBookingNew(AvailableWorkerID, selectedRoom, selectedTime, selectedPaymentMode, "", 0, "", "") ', selectedTimeType)
            Else
                MsgBox("Select SP", MsgBoxStyle.Information, "info")
            End If
        End If

    End Sub
    Private Sub btnDoorCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrivate.Click, btnLounge.Click, btnPRIVATEINTRO.Click
        For Each c As Button In grpDoorCharges.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        Dim ppp As New cls_tblLookUp.PriceSpec
        Try
            ppp = objLookUp.GetPrice(1, 1, Val(selectedTime), serviceType, selectedRoom)
        Catch ex As Exception
        End Try
        If selectedDoor <> sender.text Then
            DoorQTY = 0
        End If
        selectedDoor = sender.text
        DoorQTY += 1
        lnkDoor.Text = sender.text & " (" & DoorQTY.ToString & ")"
        selectedDoorCharge = sender.tag
        lblTotalPrice.Text = "" & currency & "" + (Val(sender.tag) * DoorQTY).ToString("0.00")
        sender.backcolor = ActiveButton
        step4 = sender.name
    End Sub

    Private Sub btnLounge_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrivate.DoubleClick, btnLounge.DoubleClick
        Dim frmdlg As New dlgAmount
        frmdlg.Text = "Enter Door Qty"
        frmdlg.Label1.Text = "Enter Door QTY"
        If frmdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnDoorCharge_Click(sender, e)
            DoorQTY = Val(frmdlg.txtAmount.Text)
            lnkDoor.Text = sender.text & " (" & DoorQTY.ToString & ")"
            lblTotalPrice.Text = "" & currency & "" + (Val(sender.tag) * DoorQTY).ToString("0.00")
        End If
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click, _
                                                                                                    btnCard.Click, _
                                                                                                    btnCardCash.Click

        For Each c As Button In grpPaymentMode.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next

        selectedPaymentMode = sender.text
        sender.backcolor = ActiveButton
        step5 = sender.name

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If Val(lblTotalPrice.Text.Replace("" & currency & "", "")) <= 0 Then
            MsgBox("Nothing selected", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If selectedDoor = "" Then
            MsgBox("Nothing selected", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim surchargeAmt As Double = 0
        Dim surchargep As Double = 0
        Dim total As Double = selectedDoorCharge * DoorQTY
        Dim tip As Double = 0
        Dim cashout As Double = 0
        Dim cashAmt As Double = 0
        Dim cardAmt As Double = 0
        Dim blncAmt As Double = 0
        Dim TotalAmtPaid As Double = 0
        Dim GST As Double = 0

        Try
            Dim frm As New frmPaymentOthers
            frm.isManualEntry = True
            frm.selectedPaymentMode = selectedPaymentMode
            frm.Label1.Text = "Total : " & total.ToString("0.00")
            frm.txtTotalInGST.Text = total.ToString("0.00")
            frm.btnVouchers.Enabled = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                selectedPaymentMode = frm.selectedPaymentMode
                cashAmt = Val(frm.txtCash.Text)
                cardAmt = Val(frm.txtCard.Text)
                blncAmt = 0
                surchargeAmt = Val(frm.txtSurchargeAmt.Text)
                surchargep = Val(frm.txtSurchrgeP.Text)
                tip = Val(frm.txtTip.Text)
                cashout = Val(frm.txtCashOut.Text)
                TotalAmtPaid = Val(frm.txtAmountPaid.Text)
                GST = Val(frm.txtGST.Text)
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        Dim MemoNo As Integer = objDocketMemo.Insert("Door Charge", Now, "", "")
        Dim InsantID As Integer = objInstant.Insert(
                                             selectedDoor, _
                                             Val(selectedDoorCharge), _
                                             Now, _
                                             Val(selectedDoorCharge) * DoorQTY, _
                                             DoorQTY, MemoNo)
        objPaymentOthers.Insert("DOOR CHARGE", Val(selectedDoorCharge) * DoorQTY, InsantID, Now, cashAmt, cardAmt, surchargep, surchargeAmt, "PAID", selectedPaymentMode, TotalAmtPaid, "", 0, 0, MemoNo, cashout, tip, GST, LoginUserId)
        clsDocketPrint.PrintDocketMemo(MemoNo)
        Refresh_NEW()

    End Sub

    Private Sub btnRemoveAvailable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveQueue.Click
        Try
            Dim activeAL() As String = dgQueueWorkers.SelectedRows(0).Cells(6).Value.ToString.Split(",")
            Dim BookingId As Integer = objActiveWorkers.tblActiveWorker_Selection(0, "a.SL=" & activeAL(0).ToString).Rows(0).Item("bookingId")
            Dim NameofSPs As String = ""
            ListOfSpInABooking(BookingId, NameofSPs)
            If QueueWorkerID > 0 Then
                If MsgBox("Are you Sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "REMOVE QUEUED SP : " & NameofSPs) = MsgBoxResult.Yes Then

                Else
                    Exit Sub
                End If
                For Each asl As String In dgQueueWorkers.SelectedRows(0).Cells(6).Value.ToString.Split(",")
                    objActiveWorkers.Delete_tblActiveWorker(Val(asl))
                Next
                QueueWorkerID = 0
                Loadings()
                MainReloader_OnTimerLeftCounter()
            Else
                MsgBox("Select SP", MsgBoxStyle.Information, "Info : " & NameofSPs)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgQueuedBooking_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgActiveBooking.SelectionChanged, dgPrebookingNew.SelectionChanged
        If sender.SelectedRows.Count >= 1 Then
            sender.SelectedRows(0).Selected = False
        End If
    End Sub

    Sub Refresh_NEW()

        For Each c As Button In tlpRoom.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next

        btnEscort.BackColor = Nothing
        btnEscort.UseVisualStyleBackColor = True
        btnHOLD.BackColor = Nothing
        btnHOLD.UseVisualStyleBackColor = True
        For Each c As Button In tlpService.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next

        For Each c As Button In grpDoorCharges.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next

        For Each dgr As DataGridViewRow In dgAvailableWorker1.Rows
            dgr.Cells(2).Style.BackColor = Color.White
            dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
        Next

        For Each dgr As DataGridViewRow In dgAvailableWorker2.Rows
            dgr.Cells(2).Style.BackColor = Color.White
            dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
        Next

        ResetPaymentType()

        lnkServiceProvider.Text = ""
        AvailableWorkerID = 0

        selectedRoom = ""
        selectedDoor = ""
        selectedTime = 0
        selectedDoorCharge = 0
        lnkRoom.Text = ""
        lnkService.Text = ""
        lblTotalPrice.Text = "" & currency & "0.00"
        lnkDoor.Text = ""

        Dim cashAmt As Double = 0
        Dim cardAmt As Double = 0
        Dim blncAmt As Double = 0

        Try
            dgAvailableWorker1.SelectedRows(0).Selected = False
        Catch ex As Exception
        End Try
        Try
            dgAvailableWorker2.SelectedRows(0).Selected = False
        Catch ex As Exception
        End Try

        RefreshRoomColor()

        DoorQTY = 0

        btn30Min.Enabled = True
        btn45Min.Enabled = True
        btn60Min.Enabled = True
        btn90Min.Enabled = True

        For Each c As Button In tlpServiceType.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        btnStandard.BackColor = ActiveButton
        serviceType = btnStandard.Text

        customeTimeType = ""
        SelectedTimes = Nothing

    End Sub

    Private Sub btnRefreshNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshNew.Click
        Refresh_NEW()
    End Sub

    Private Sub btnStart2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartQueue.Click
        Try
            Dim activeAL() As String = dgQueueWorkers.SelectedRows(0).Cells(6).Value.ToString.Split(",")
            Dim BookingId As Integer = objActiveWorkers.tblActiveWorker_Selection(0, "a.SL=" & activeAL(0).ToString).Rows(0).Item("bookingId")
            Dim NameofSPs As String = ""
            ListOfSpInABooking(BookingId, NameofSPs)
            If QueueWorkerID > 0 Then
                Dim Sp As String = "" 'ListOfSpInABooking
                If IsWorkerActive(dgQueueWorkers.SelectedRows(0).Cells(0).Value.ToString) Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "START QUEUED SP : " & NameofSPs) = MsgBoxResult.Yes Then

                    Else
                        Exit Sub
                    End If

                    'If dgQueueWorkers.SelectedRows(0).Cells(2).Value.ToString = "" Then
                    '    Dim frmRM As New frmSelectRoom
                    '    CheckRoomValidity(False, frmRM)
                    '    CHeckRoomStatus(frmRM)
                    '    If frmRM.ShowDialog = Windows.Forms.DialogResult.OK Then
                    '        Dim activeAL As Integer = dgQueueWorkers.SelectedRows(0).Cells(6).Value
                    '        objActiveWorkers.tblActiveWorker_Update(activeAL, frmRM.selectedRoom)
                    '        objActiveWorkers.tblActiveWorker_Update2(activeAL, "")
                    '        Loadings()
                    '        MainReloader_OnTimerLeftCounter()
                    '    End If
                    'Else

ChangeRoom:
                    Dim room As String = dgQueueWorkers.SelectedRows(0).Cells(2).Value.ToString

                    If Not IsRoomValid(room) Or room = "PENDING" Then
                        Dim frmsv As New frmSelectRoom
                        frmsv.Text = "SELECT ROOM  : " & NameofSPs
                        CheckRoomValidity(False, frmsv)
                        CHeckRoomStatus(frmsv)

                        If frmsv.ShowDialog = Windows.Forms.DialogResult.OK Then
                            room = frmsv.selectedRoom
                        Else
                            Exit Sub
                        End If
                    End If

                    If Not IsRoomValid(room) Then
                        If MsgBox("Selected room is pre-occupied" & vbNewLine & "Do you want to change the room?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Info : " & NameofSPs) = MsgBoxResult.Yes Then
                            GoTo ChangeRoom
                        Else
                            Exit Sub
                        End If
                    End If

                    For Each asl As String In activeAL
                        objActiveWorkers.tblActiveWorker_Update(asl, room)
                        objActiveWorkers.tblActiveWorker_Update_STatus(asl, "")
                    Next

                    objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Room, room, "[BookingID]=" & BookingId)
                    Loadings()
                    MainReloader_OnTimerLeftCounter()

                    'End If frmsv.Text = "SELECT ROOM  : " & NameofSPs

                Else
                    MsgBox("SP already active", MsgBoxStyle.Information, "info : " & NameofSPs)
                End If
            Else
                MsgBox("Select SP", MsgBoxStyle.Information, "info : " & NameofSPs)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFinishWorker.Click
        Dim frm As New frmSelectSPClearFinished
        For Each dgr As DataGridViewRow In dgActiveBooking.Rows
            Dim lst() As String = dgr.Cells(1).Value.ToString.Split(vbNewLine)
            Dim lst1() As String = dgr.Cells(6).Value.ToString.Split(",")
            For i = 0 To lst.Length - 1

                Dim tm As Integer = 0

                Try
                    If IsNumeric(lst(i).Trim.Split("(")(1).Split("/")(0)) Then
                        tm = lst(i).Trim.Split("(")(1).Split("/")(0)
                    Else
                        tm = lst(i).Trim.Split("(")(2).Split("/")(0)
                    End If
                Catch ex As Exception
                End Try

                If tm <= 0 Then
                    Dim li As New ListViewItem
                    Try
                        li.Text = lst(i).Trim & " (" & dgr.Cells(2).Value.ToString & ")"
                    Catch ex As Exception
                    End Try
                    Try
                        li.Tag = lst1(i)
                    Catch ex As Exception
                    End Try
                    li.BackColor = dgr.DefaultCellStyle.BackColor
                    frm.lstServiceProvider.Items.Add(li)
                End If

            Next
        Next

        If frm.lstServiceProvider.Items.Count <= 0 Then
            MsgBox("No completed SP found", MsgBoxStyle.Critical, "Info")
            Exit Sub
        End If

        If MsgBox("Are you Sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CLEAR FINISHED SP") = MsgBoxResult.Yes Then

        Else
            Exit Sub
        End If

        If frm.lstServiceProvider.Items.Count > 0 Then
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    For Each li As ListViewItem In frm.lstServiceProvider.SelectedItems
                        objActiveWorkers.tblActiveWorker_Update_STatus(Val(li.Tag), "CLEARED AT " + Now.ToString)
                        'TODO : Check the corresponding booking has active worker or not. If not then set the booking status as CLEARED/FINISHED/RESET. As per requirement.  
                        'ResetBooking(
                    Next

                    MainReloader_OnTimerLeftCounter()
                Catch ex As Exception
                End Try
                For Each c As Button In tlpRoom.Controls
                    If c.Enabled Then
                        c.BackColor = Nothing
                        c.UseVisualStyleBackColor = True
                    End If
                Next
            End If
        End If
    End Sub

    Sub ResetBooking(BookingID As String)
        'SERVICE = ""
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Reset Booking") = MsgBoxResult.No Then
            Exit Sub
        End If
        'Dim MemoNo As Integer = objDocketMemo.Insert("CLEAR BOOKING", Now, "") ' If enabled here, also enble in "btnClear_Click"
        objBookingStatus.Insert(BookingID, "CLEAR", Now, 0, "", LoginUserId, 0)
        objActiveWorkers.tblActiveWorker_Update_By_BookingID(BookingID, "CLEARED AT " + Now.ToString)
        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()
        'tblActiveWorker_Update_STatus
    End Sub
    Private Sub dgQueueWorkers_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgQueueWorkers.SelectionChanged
        If dgQueueWorkers.SelectedRows.Count > 0 Then
            QueueWorkerID = dgQueueWorkers.SelectedRows(0).Cells(0).Value
        End If
    End Sub

    Private Sub dgAvailableWorker_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgAvailableWorker1.SelectionChanged, dgAvailableWorker2.SelectionChanged
        If sender.SelectedRows.Count > 0 Then
            lnkServiceProvider.Text = sender.SelectedRows(0).Cells(1).Value
            AvailableWorkerID = sender.SelectedRows(0).Cells(0).Value
            For Each dgr As DataGridViewRow In dgAvailableWorker1.Rows
                dgr.Cells(2).Style.BackColor = Color.White
                dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
            Next
            For Each dgr As DataGridViewRow In dgAvailableWorker2.Rows
                dgr.Cells(2).Style.BackColor = Color.White
                dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
            Next
            sender.SelectedRows(0).Cells(2).Style.BackColor = Color.Black
            sender.SelectedRows(0).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold + FontStyle.Italic + FontStyle.Underline, GraphicsUnit.Point)
            If sender.SelectedRows.Count >= 1 Then
                sender.SelectedRows(0).Selected = False
            End If
        End If
    End Sub

    Private Sub btnClearRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearRoom.Click
        Dim frm As New frmSelectSPClearFinished
        For Each dgr As DataGridViewRow In dgActiveBooking.Rows
            Dim li As New ListViewItem
            Try
                li.Text = dgr.Cells(2).Value + " (" + dgr.Cells(1).Value.ToString.Replace(vbNewLine, ", ") + ")"
            Catch ex As Exception
            End Try
            Try
                li.Tag = dgr.Cells(9).Value
            Catch ex As Exception
            End Try
            li.BackColor = dgr.DefaultCellStyle.BackColor
            frm.lstServiceProvider.Items.Add(li)
        Next
        If frm.lstServiceProvider.Items.Count <= 0 Then
            MsgBox("No Active Room found", MsgBoxStyle.Critical, "Info")
            Exit Sub
        End If
        If MsgBox("Are you Sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CLEAR ROOM") = MsgBoxResult.Yes Then
        Else
            Exit Sub
        End If

        If frm.lstServiceProvider.Items.Count > 0 Then
            frm.Text = "Rooms"
            frm.grpServiceProvider.Text = "Select Room"
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim countActiveRoom As Integer = 0
                For Each li As ListViewItem In frm.lstServiceProvider.SelectedItems
                    For Each dgr As DataGridViewRow In dgActiveBooking.Rows
                        If Val(dgr.Cells(9).Value.ToString.Trim) = Val(li.Tag) And Val(dgr.Cells(4).Value.ToString.Trim) > 0 Then
                            countActiveRoom += 1
                        End If
                    Next
                Next
                If countActiveRoom > 0 Then
                    If MsgBox("Some Room are still Active. Are you Sure?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "CLEAR ROOM") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                Try
                    For Each li As ListViewItem In frm.lstServiceProvider.SelectedItems
                        objActiveWorkers.tblActiveWorker_Update_By_BookingID(Val(li.Tag), "CLEARED AT " + Now.ToString)
                    Next
                    MainReloader_OnTimerLeftCounter()
                Catch ex As Exception
                End Try
                For Each c As Button In tlpRoom.Controls
                    If c.Enabled Then
                        c.BackColor = Nothing
                        c.UseVisualStyleBackColor = True
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartAvailable.Click
        If AvailableWorkerID > 0 Then
            StartBookingNew(AvailableWorkerID, selectedRoom, selectedTime, selectedPaymentMode, "", 0, "", "") ', selectedTimeType)
        Else
            MsgBox("Select SP", MsgBoxStyle.Information, "info")
        End If
    End Sub

    Sub StartBookingCustom()
        Try
            Dim frmWorkerSelect_obj As New frmSelectSPAddToActiveRoom
            Dim frmClientSelect_obj As New frmSelectNoOfClients
            Dim frmTimeSelect_obj As New frmServiceTime
            Dim frmRoomSlecet_obj As New frmSelectRoom
            frmRoomSlecet_obj.btnPending.Enabled = True
            Dim vselectedPaymentMode As String = ""
            Dim vselectedRoom As String = ""
            Dim vselectedTime As String = ""
            Dim vselectedServiceType As String = serviceType
            Dim vselectedNoOfClient As Integer = 0
            Dim vselectedNoOfWorker As Integer = 0
            Dim surchargeAmt As Double = 0
            Dim surchargeP As Double = 0
            Dim tip As Double = 0
            Dim shift_fee As Double = 0
            Dim cashout As Double = 0
            Dim GST As Double = 0
            Dim roomChrge As Double = 0
            Dim vWorkerID As Integer = 0
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0
            Dim status As String = ""
            objWorkers.LoadWorkerInListView(frmWorkerSelect_obj.dgAvailableWorker, cls_tblWorkers.SelectionType.AVAILABLE)
            frmWorkerSelect_obj.multiselect = True
StepSelectWorker:
            Dim ActiveSount As Integer = 0
            RefreshAvailableWorkersColor(frmWorkerSelect_obj)
            Select Case frmWorkerSelect_obj.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    vselectedNoOfWorker = frmWorkerSelect_obj.dgAvailableWorker.SelectedRows.Count
                    vWorkerID = frmWorkerSelect_obj.dgAvailableWorker.SelectedRows(0).Cells(0).Value
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
                Case Else
                    Exit Sub
            End Select

            Dim wns As String = ""
            Dim sp_names As New List(Of String)
            For Each dgrWorkr As DataGridViewRow In frmWorkerSelect_obj.dgAvailableWorker.SelectedRows
                Dim wid As Integer = dgrWorkr.Cells(0).Value
                Dim wn As String = ""
                Try
                    wn = objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, wid)
                Catch ex As Exception
                End Try
                If Not IsWorkerActive(wid) Then
                    ActiveSount += 1
                    Try
                        If wn.Trim <> "" Then
                            If wns <> "" Then
                                wns += ", "
                            End If
                            wns += wn
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    sp_names.Add(wn)
                End If
            Next

            If wns.Trim = "" Or wns.Trim = "," Then
                wns = "SP(s)"
            Else

            End If

            If ActiveSount >= 1 Then
                If MsgBox(wns & " are already Active." & vbNewLine & "Do you want to put the booking in QUEUE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    status = "QUEUE"
                Else
                    GoTo StepSelectWorker
                    Exit Sub
                End If
            End If

StepSelectClient:
            Select Case frmClientSelect_obj.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    vselectedNoOfClient = Val(frmClientSelect_obj.NumericUpDown1.Value)
                Case Windows.Forms.DialogResult.Cancel
                    GoTo StepSelectWorker
                Case Else
                    Exit Sub
            End Select

            Dim countActiveRooms As Integer = dgActiveBooking.Rows.Count

            CheckRoomValidity(True, frmRoomSlecet_obj)
            CHeckRoomStatus(frmRoomSlecet_obj)
stepSelectRoom:
            Select Case frmRoomSlecet_obj.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    vselectedRoom = frmRoomSlecet_obj.selectedRoom
                Case Windows.Forms.DialogResult.Cancel
                    GoTo StepSelectClient
                Case Else
                    Exit Sub
            End Select



            If vselectedRoom = "PENDING" Then
                status = "QUEUE"
            Else
                If Not IsRoomValid(vselectedRoom) And vselectedRoom <> "ESCORT" Then
                    If MsgBox("Room already occupied." & vbNewLine & "Do you want to put it in QUEUE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                        status = "QUEUE"
                    Else
                        GoTo stepSelectRoom
                        Exit Sub
                    End If
                End If
            End If



            Dim frmEsDrInf As New dlgEscortDriveInfo
            If vselectedRoom = "ESCORT" Then
                Select Case frmEsDrInf.ShowDialog
                    Case Windows.Forms.DialogResult.OK

                    Case Windows.Forms.DialogResult.Cancel
                        GoTo stepSelectRoom
                    Case Else
                        Exit Sub
                End Select
            End If


            Dim Shift As cls_tblLookUp.PriceType = MyShiftType()
            If vselectedRoom = "ESCORT" Then

                If Not MySettings.OtherSettings.MultipleEscortPrice Then
                    Shift = cls_tblLookUp.PriceType.NIGHT
                Else
                    Dim frmDlgShift As New frmSelectShift
                    If frmDlgShift.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                    Shift = frmDlgShift.SelectedShift
                End If
            End If

            frmTimeSelect_obj.serviceType = vselectedServiceType
            frmTimeSelect_obj.EnableCustomTime(Shift.ToString, vselectedRoom, serviceType, vselectedNoOfClient, vselectedNoOfWorker)
            If vselectedRoom = "ESCORT" Then

                frmTimeSelect_obj.btn5min.Enabled = False
                frmTimeSelect_obj.btn10min.Enabled = False
                frmTimeSelect_obj.btn15min.Enabled = False
                frmTimeSelect_obj.btn20min.Enabled = False 
                frmTimeSelect_obj.btn30Min.Enabled = False
                frmTimeSelect_obj.btn45Min.Enabled = False
                'frmTimeSelect_obj.btn60Min.Enabled = False
                frmTimeSelect_obj.btn90Min.Enabled = False
                frmTimeSelect_obj.btn5min.BackColor = Color.Gray
                frmTimeSelect_obj.btn10min.BackColor = Color.Gray
                frmTimeSelect_obj.btn15min.BackColor = Color.Gray
                frmTimeSelect_obj.btn20min.BackColor = Color.Gray
                frmTimeSelect_obj.btn30Min.BackColor = Color.Gray 
                frmTimeSelect_obj.btn45Min.BackColor = Color.Gray
                'frmTimeSelect_obj.btn60Min.BackColor = Color.Gray
                frmTimeSelect_obj.btn90Min.BackColor = Color.Gray
                '
                frmTimeSelect_obj.btnStandard.Enabled = False
                frmTimeSelect_obj.btnStandard.BackColor = Color.Gray
                frmTimeSelect_obj.serviceType = frmTimeSelect_obj.btnSpecial.Text
            End If
stepSelectTime:
            Select Case frmTimeSelect_obj.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    vselectedTime = frmTimeSelect_obj.customeTime
                    vselectedServiceType = frmTimeSelect_obj.serviceType
                    customeTimeType = frmTimeSelect_obj.customeTimeType
                    SelectedTimes = frmTimeSelect_obj.SelectedTimes
                Case Windows.Forms.DialogResult.Cancel
                    GoTo stepSelectRoom
                Case Else
                    Exit Sub
            End Select




            Dim ppp_night_default As cls_tblLookUp.PriceSpec = Nothing
            Dim ppp_now As cls_tblLookUp.PriceSpec = Nothing
            Try
                If customeTimeType.StartsWith("CUSTOM") Then
                    ppp_night_default = New cls_tblLookUp.PriceSpec
                    For Each tm As Integer In SelectedTimes
                        Dim ppp_night_default_tmp As cls_tblLookUp.PriceSpec = objLookUp.GetPrice2(vselectedNoOfWorker, vselectedNoOfClient, tm, Shift, vselectedServiceType, vselectedRoom)
                        ppp_night_default.HouseAmount += ppp_night_default_tmp.HouseAmount
                        ppp_night_default.IsRoomExtra = ppp_night_default_tmp.IsRoomExtra
                        ppp_night_default.IsWeekDayEstra = ppp_night_default_tmp.IsWeekDayEstra
                        ppp_night_default.Price += ppp_night_default_tmp.Price
                        ppp_night_default.Room = ppp_night_default_tmp.Room
                        ppp_night_default.WorkerAmount += ppp_night_default_tmp.WorkerAmount
                        ppp_night_default.ItemSl = ppp_night_default_tmp.ItemSl
                        ppp_night_default.Shift = ppp_night_default_tmp.Shift
                        ppp_night_default.WorkerId = ppp_night_default_tmp.WorkerId
                    Next
                Else
                    If MySettings.OtherSettings.DayPrice Then
                        ppp_night_default = objLookUp.GetPrice2(vselectedNoOfWorker, vselectedNoOfClient, Val(vselectedTime), cls_tblLookUp.PriceType.NIGHT, vselectedServiceType, vselectedRoom)
                        ppp_now = objLookUp.GetPrice2(vselectedNoOfWorker, vselectedNoOfClient, Val(vselectedTime), Shift, vselectedServiceType, vselectedRoom)
                    Else
                        ppp_night_default = objLookUp.GetPrice2(vselectedNoOfWorker, vselectedNoOfClient, Val(vselectedTime), Shift, vselectedServiceType, vselectedRoom)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                Exit Sub
            End Try

 
            Dim MemberID As String = ""
            If MySettings.OtherSettings.Membership Then
                Dim frmMember As New dlgMembership
                If frmMember.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MemberID = frmMember.MemberID
                Else
                    Exit Sub
                End If

            End If

            Dim upgarde_amt As Double = 0
            Dim SP_A As Double = 0
            Dim HOUSE_A As Double = 0
            Dim carfare As Double = 0
            Dim escortext As Double = 0
            Dim cashAmt As Double = 0
            Dim cardAmt As Double = 0
            Dim blncAmt As Double = 0
            Dim BondAmt As Double = 0
            Dim CardName As String = ""

            Dim UtilizedVoucher As Double = 0
            Dim GiftAmout As Double = 0
            Dim OriginalShift As String = ""
            Dim CurrentShift As String = ""
            Dim TOTAL_PAID As Double = 0




            Try

                Dim objPayDlg As New clsPaymentDailog
                Dim PayReturn As clsPaymentDailog.BookingPaymentReturn = _
                    objPayDlg.BookingPayment(vselectedRoom, ppp_night_default.Price, vselectedPaymentMode, ppp_night_default.HouseAmount, ppp_night_default.WorkerAmount, True, {0}, False, True, False, True, ppp_now, ppp_night_default, True, sp_names)
                vselectedPaymentMode = PayReturn.PAYMENTMODE
                cashAmt = PayReturn.CASH
                cardAmt = PayReturn.CARD
                blncAmt = 0
                surchargeAmt = PayReturn.SUR_AMT
                surchargeP = PayReturn.SUR_P
                tip = PayReturn.TIP
                cashout = PayReturn.CASHOUT
                VoucherID = PayReturn.VOUCHERID
                VoucherAmount = PayReturn.VOUCHER_AMT
                shift_fee = 0
                upgarde_amt = PayReturn.UPGRADE
                GST = PayReturn.GST
                SP_A = PayReturn.SP_AMOUNT
                HOUSE_A = PayReturn.HOUSE_AMOUNT
                carfare = PayReturn.CAREFARE
                escortext = PayReturn.ESCORT_EXTENSION_FEES
                CardName = PayReturn.CardName
                BondAmt = PayReturn.ESCORT_BOND_FEES
                TOTAL_PAID = PayReturn.TOTAL_AMOUNT_PAID

            Catch ex As Exception
                Exit Sub
            End Try
            Dim total As Double = HOUSE_A + SP_A

            Dim BookingID As Integer = 0
            'Save Booking
            Dim MemoNo As Integer = objDocketMemo.Insert("BOOKING", Now, "", "")
            Dim CustomerName As String = ""
            Dim CustomerPhone As String = ""

            Dim DisplayID As Integer = 0
            Try
                DisplayID = objBooking.GetDisplayID
                objBooking.SaveDisplayID(BookingID, DisplayID)
            Catch ex As Exception
            End Try

            'BookingID = objBooking.Insert  (     
            '                                   vselectedRoom, _
            '                                   Val(vselectedTime), _
            '                                   Now, _
            '                                   Now, _
            '                                   "BOOKING", _
            '                                   vWorkerID, 
            '                                   CustomerName, 
            '                                   CustomerPhone,
            '                                   vselectedNoOfClient, 
            '                                   MemberID, 
            '                                   MemoNo, 
            '                                   0   
            '                               )

            BookingID = objBooking.Insert(vselectedRoom, Val(vselectedTime), Now, Now, "BOOKING", "", vWorkerID, CustomerName, CustomerPhone, "", "", vselectedNoOfClient, MemberID, MemoNo, LoginUserId, False, DisplayID)

            For Each dgr As DataGridViewRow In frmWorkerSelect_obj.dgAvailableWorker.SelectedRows

                objActiveWorkers.Insert_tblActiveWorker(dgr.Cells(0).Value, Today, vselectedRoom, Val(vselectedTime), Now, status, BookingID, MemoNo)
                objExtend.Insert(Val(vselectedTime), BookingID, dgr.Cells(0).Value, Now, MemoNo, vselectedServiceType, Shift.ToString)
                Dim cncl_fees As Double = 0
                objPayment.Insert("BOOKING", total / vselectedNoOfWorker, BookingID, Now, cashAmt / vselectedNoOfWorker, cardAmt / vselectedNoOfWorker, surchargeP, surchargeAmt / vselectedNoOfWorker, tip / vselectedNoOfWorker, "PAID", vselectedPaymentMode, SP_A / vselectedNoOfWorker, HOUSE_A / vselectedNoOfWorker, cashout / vselectedNoOfWorker, dgr.Cells(0).Value, VoucherAmount / vselectedNoOfWorker, VoucherID, shift_fee / vselectedNoOfWorker, MemoNo, upgarde_amt / vselectedNoOfWorker, "", GST / vselectedNoOfWorker, LoginUserId, carfare / vselectedNoOfWorker, escortext / vselectedNoOfWorker, CardName, cncl_fees, BondAmt / vselectedNoOfWorker, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

            Next

            If vselectedRoom = "ESCORT" Then
                objEscortInfor.Insert(BookingID, frmEsDrInf.txtLocation.Text, frmEsDrInf.txtOther.Text, frmEsDrInf.txtRemarks.Text)
            End If

            'Print Booking
            clsDocketPrint.PrintDocketMemo(MemoNo)
            Loadings()
            MainReloader_OnTimerLeftCounter()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Sub RedoBookingNormal(_BookingId As Integer)
        If objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId=" & _BookingId).Rows.Count > 1 Then
            MsgBox("Cannot edit this booking", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'If objPayment.Selection(cls_Temp_tblDocketMemo.SelectionType.All, "BookingId=" & _BookingId).Rows.Count > 1 Then
        '    MsgBox("Cannot edit this booking", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        Dim objTemBooking As New cls_Temp_tblBookings
        Dim Bi As cls_Temp_tblBookings.Fields = objTemBooking.Selection_One_Row(_BookingId)

        Dim _workerId As Integer = Bi.WorkerID_
        Dim clientName As String = Bi.CustomerName_ ' objBooking.SelectionDisctinct(cls_tblBookings.tblBookings_FIELDS.CustomerName, "BookingId=" & _BookingId).Rows(0).Item(0)
        Dim _room As String = Bi.Room_ ' objBooking.SelectionDisctinct(cls_tblBookings.tblBookings_FIELDS.Room, "BookingId=" & _BookingId).Rows(0).Item(0)
        Dim _ServiceTime As Integer = objExtend.Selection(cls_tblExtraService.SelectionType.ALL, "BookingId=" & _BookingId).Rows(0).Item("Service")
        Dim _paymentMode As String = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId=" & _BookingId).Rows(0).Item("PaymentMode")
        Dim _ServiceType As String = objExtend.Selection(cls_tblExtraService.SelectionType.ALL, "BookingId=" & _BookingId).Rows(0).Item("ServiceType")
        Dim DisplayBookingID As String = bi.DisplayBookingId_

        Dim _prevRoom As String = _room
        Dim status As String = ""
        Dim MemberID As String = objBooking.SelectDistinct(Database_Table_code_class_tblBookings.FieldName.MemberId, "BookingId=" & _BookingId).Rows(0).Item(0)
        Dim MemoNo As Integer = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId=" & _BookingId).Rows(0).Item("MemoNo")
        Try

            Dim frmSV As New frmServiceTime
            Dim countActiveRooms As Integer = dgActiveBooking.Rows.Count
            Dim frmRM As New frmSelectRoom
            frmRM.Text += " : " & _room
Step1:
            frmRM.ExcludeRoom = _room
            frmRM.btnPending.Enabled = True
            CheckRoomValidity(True, frmRM, _room)
            CHeckRoomStatus(frmRM)
            frmRM.SelectRoom(_room)

            If frmRM.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            Else
                _room = frmRM.selectedRoom
            End If


            If Not IsRoomValid(_room) And _room <> "ESCORT" And _prevRoom <> _room Then
                If MsgBox("Room(" & _room & ") already occupied." & vbNewLine & "Do you want to put it in QUEUE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    status = "QUEUE"
                Else
                    GoTo Step1
                    Exit Sub
                End If
            End If
            If _room = "PENDING" Then
                status = "QUEUE"
            End If


            frmSV.serviceType = _ServiceType
            If _room = "ESCORT" Then
                frmSV.btn30Min.Enabled = False
                frmSV.btn45Min.Enabled = False
                'frmSV.btn60Min.Enabled = False
                frmSV.btn90Min.Enabled = False
                frmSV.btn30Min.BackColor = Color.Gray
                frmSV.btn45Min.BackColor = Color.Gray
                'frmSV.btn60Min.BackColor = Color.Gray
                frmSV.btn90Min.BackColor = Color.Gray
            End If

            frmSV.SelectTime(_ServiceTime, _ServiceType)
Step2:      Select Case frmSV.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    _ServiceTime = frmSV.customeTime
                    _ServiceType = frmSV.serviceType
                Case Windows.Forms.DialogResult.Retry
                    If frmSV.btnBack.Text = "Cancel" Then
                        Exit Sub
                    Else
                        GoTo Step1
                    End If
                Case Else
                    Exit Sub
            End Select


            If _room = "" Or status = "QUEUE" Then

                Dim frm As New frmSelectEnterClientName
                frm.TextBox1.Text = clientName
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    clientName = frm.TextBox1.Text
                Else
                    Exit Sub
                End If

            End If


            Dim surchargeAmt As Double = 0
            Dim surchargeP As Double = 0
            Dim tip As Double = 0
            Dim shift_fee As Double = 0
            Dim cashAmt As Double = 0
            Dim cardAmt As Double = 0
            Dim blncAmt As Double = 0

            Dim Shift As cls_tblLookUp.PriceType = MyShiftType()
            If _room = "ESCORT" Then
                If Not MySettings.OtherSettings.MultipleEscortPrice Then
                    Shift = cls_tblLookUp.PriceType.NIGHT
                Else
                    Dim frmDlgShift As New frmSelectShift
                    If frmDlgShift.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                    Shift = frmDlgShift.SelectedShift
                End If
            End If

            Dim ppp_night_default As cls_tblLookUp.PriceSpec = objLookUp.GetPrice2(1, 1, Val(_ServiceTime), cls_tblLookUp.PriceType.NIGHT, _ServiceType, _room)
            Dim ppp_now As cls_tblLookUp.PriceSpec = Nothing
            Try
                ppp_now = objLookUp.GetPrice2(1, 1, Val(_ServiceTime), Shift, _ServiceType, _room)
            Catch ex As Exception
            End Try

            Dim cashout As Double = 0
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0

            If _paymentMode = "CARD/CASH" Then

            ElseIf _paymentMode = "CASH" Then
                cashAmt = Val(lblTotalPrice.Text.Replace("" & currency & "", ""))
            ElseIf _paymentMode = "CARD" Then
                surchargeAmt = cashout * MySettings.Surcharge / 100
                cardAmt = Val(lblTotalPrice.Text.Replace("" & currency & "", "")) + cashout
            End If



            Dim upgarde_amt As Double = 0
            Dim GST As Double = 0
            Dim SP_A As Double = 0
            Dim HOUSE_A As Double = 0

            Dim CarFare As Double = 0
            Dim EscortExtensionFees As Double = 0
            Dim CardName As String = ""
            Dim sp_names As New List(Of String)
            Dim BondAmt As Double = 0

            Try
                sp_names.Add(objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, _workerId))
            Catch ex As Exception
            End Try
            Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0






            Dim objTemBookingPayments As New cls_Temp_tblBookingPayments
            Try
                Dim PayInfot As cls_Temp_tblBookingPayments.Fields = objTemBookingPayments.Selection_One_Row_Select("BookingId=" & _BookingId)
                Dim objPayDlg As New clsPaymentDailog
                Dim PayReturn As clsPaymentDailog.BookingPaymentReturn = _
                objPayDlg.BookingPayment(_room, ppp_night_default.Price, _paymentMode, ppp_night_default.HouseAmount, ppp_night_default.WorkerAmount, True, {0}, False, True, False, True, ppp_now, ppp_night_default, True, sp_names, False, PayInfot.Tip_, PayInfot.Upgrade_, PayInfot.CarFare_, PayInfot.EscortExtensionFees_, PayInfot.Bond_amount_, PayInfot.Cash_, PayInfot.CARD_, PayInfot.VoucherID_, PayInfot.VoucherAmount_)
                _paymentMode = PayReturn.PAYMENTMODE
                cashAmt = PayReturn.CASH
                cardAmt = PayReturn.CARD
                blncAmt = 0
                surchargeAmt = PayReturn.SUR_AMT
                surchargeP = PayReturn.SUR_P
                tip = PayReturn.TIP
                cashout = PayReturn.CASHOUT
                VoucherID = PayReturn.VOUCHERID
                VoucherAmount = PayReturn.VOUCHER_AMT
                shift_fee = 0
                upgarde_amt = PayReturn.UPGRADE
                GST = PayReturn.GST
                SP_A = PayReturn.SP_AMOUNT
                HOUSE_A = PayReturn.HOUSE_AMOUNT
                CarFare = PayReturn.CAREFARE
                EscortExtensionFees = PayReturn.ESCORT_EXTENSION_FEES
                CardName = PayReturn.CardName
                BondAmt = PayReturn.ESCORT_BOND_FEES
                TOTAL_PAID = PayReturn.TOTAL_AMOUNT_PAID
            Catch ex As Exception
                Exit Sub
            End Try

            Dim total As Double = HOUSE_A + SP_A
            Dim BookingID As Integer = 0

            Dim objTemActiveWorkers As New cls_Temp_tblActiveWorker
            Dim objTemExtraService As New cls_Temp_tblExtraService

            BookingID = objTemBooking.Update(_room, _ServiceTime, Now, Now, "BOOKING", "", _workerId, clientName, "", "", "", 1, MemberID, MemoNo, LoginUserId, False, DisplayBookingID, _BookingId)
            objTemActiveWorkers.Update(_workerId, Today, _room, _ServiceTime, Now, Now, "", _BookingId, Now, MemoNo, LoginUserId, objTemActiveWorkers.Selection_One_Row_Select("BookingId=" & _BookingId).sl_)
            objTemExtraService.Update(_ServiceTime, _BookingId, _workerId, Now, MemoNo, _ServiceType, LoginUserId, Shift.ToString, objTemActiveWorkers.Selection_One_Row_Select("BookingId=" & _BookingId).sl_)

            Dim Cancel_fees As Double = 0
            Dim DisplayID As Integer = 0

            Try
                DisplayID = objBooking.GetDisplayID
                objBooking.SaveDisplayID(BookingID, DisplayID)
            Catch ex As Exception
            End Try

            objTemBookingPayments.Update("BOOKING", total, _BookingId, Now, cashAmt, cardAmt, surchargeP, surchargeAmt, tip, "PAID", _paymentMode, SP_A, HOUSE_A, cashout, _workerId, VoucherAmount, VoucherID, shift_fee, MemoNo, upgarde_amt, "", GST, LoginUserId, CarFare, EscortExtensionFees, CardName, Cancel_fees, BondAmt, DisplayID, objTemBookingPayments.Selection_One_Row_Select("BookingId=" & _BookingId).Sl_, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

            'Print Booking
            clsDocketPrint.PrintDocketMemo(MemoNo)
            Loadings()
            MainReloader_OnTimerLeftCounter()
            Refresh_NEW()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            Exit Sub
        End Try
    End Sub


    Public Function StartBookingNew(ByVal vWorkerID As Integer, ByVal vselectedRoom As String, _
                    ByVal vselectedTime As String, ByVal vselectedPaymentMode As String, _
                    ByVal vselectedDoor As String, ByVal vselectedDoorCharge As String, _
                    ByVal clientName As String, ByVal status As String, Optional Shift As cls_tblLookUp.PriceType = cls_tblLookUp.PriceType.NOTHIN) As Boolean ', ByVal vselectedTimeType As String

        Try

            Dim vselectedServiceType As String = serviceType
            If vselectedRoom <> "PENDING" Then
                If Not IsWorkerActive(vWorkerID) Then
                    Dim wn As String = ""
                    Try
                        wn = objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, vWorkerID)
                    Catch ex As Exception
                    End Try

                    If wn.Trim = "" Then
                        wn = "SP"
                    End If
                    If MsgBox(wn & " already Active." & vbNewLine & "Do you want to put the booking in QUEUE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                        status = "QUEUE"
                    Else
                        Return False
                        Exit Function
                    End If
                End If
            Else
                status = "QUEUE"
            End If

            Try
                Dim notes As String = objWorkers.Selection1(cls_tblWorkers.SelectType.All, "[WorkerID]=" & AvailableWorkerID.ToString).Rows(0).Item("Notes").ToString
                If notes.Trim <> "" Then
                    MsgBox(notes, MsgBoxStyle.Information, lnkServiceProvider.Text)
                End If
            Catch ex As Exception
            End Try

            Dim countActiveRooms As Integer = dgActiveBooking.Rows.Count

            If vselectedRoom.Trim = "" Then
Step1:          Dim frmRM As New frmSelectRoom
                frmRM.btnPending.Enabled = True
                CheckRoomValidity(True, frmRM)
                CHeckRoomStatus(frmRM)
                If frmRM.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    Return False
                    Exit Function
                Else
                    vselectedRoom = frmRM.selectedRoom
                End If
            End If

            If Not IsRoomValid(vselectedRoom) And vselectedRoom <> "ESCORT" Then
                If MsgBox("Room(" & vselectedRoom & ") already occupied." & vbNewLine & "Do you want to put it in QUEUE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    status = "QUEUE"
                Else
                    'GoTo Step1 
                    Return False
                    Exit Function
                End If
            End If

            If vselectedRoom = "PENDING" Then
                status = "QUEUE"
            End If

            If vselectedRoom = "" Or status = "QUEUE" Then
                If clientName = "" Then
                    Dim frm As New frmSelectEnterClientName
                    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        clientName = frm.TextBox1.Text
                    Else
                        Return False
                        Exit Function
                    End If
                End If
            End If


            Dim frmEsDrInf As New dlgEscortDriveInfo
            If vselectedRoom = "ESCORT" Then
                If frmEsDrInf.ShowDialog = Windows.Forms.DialogResult.OK Then

                Else
                    Return False
                    Exit Function
                End If
            End If

            Dim surchargeAmt As Double = 0
            Dim surchargeP As Double = 0
            Dim tip As Double = 0
            Dim shift_fee As Double = 0
            Dim cashAmt As Double = 0
            Dim cardAmt As Double = 0
            Dim blncAmt As Double = 0
            If Shift = cls_tblLookUp.PriceType.NOTHIN Then
                Shift = MyShiftType()
                If vselectedRoom = "ESCORT" Then
                    If Not MySettings.OtherSettings.MultipleEscortPrice Then
                        Shift = cls_tblLookUp.PriceType.NIGHT
                    Else
                        Dim frmDlgShift As New frmSelectShift
                        If frmDlgShift.ShowDialog <> Windows.Forms.DialogResult.OK Then
                            Return False
                            Exit Function
                        End If
                        Shift = frmDlgShift.SelectedShift
                    End If
                End If
            End If

            Dim ExtraRoomAmount As Double = 0
            Dim ExcludeExtra As Boolean = False
            If vselectedRoom = "PEN" Then
                Dim frm As New dlgAmount
                frm.Text = "PENTHOUSE EXTRA"
                Try
                    frm.txtAmount.Text = objRoom.Selection_One_Row_Select("ROOM='" & vselectedRoom & "'").AddlHouse_Fee_
                Catch ex As Exception
                End Try

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ExtraRoomAmount = frm.txtAmount.Text
                End If
                ExcludeExtra = True
            End If


            Dim ppp_night_default As cls_tblLookUp.PriceSpec = Nothing
            Dim ppp_now As cls_tblLookUp.PriceSpec = Nothing
            If customeTimeType.StartsWith("CUSTOM") Then
                ppp_night_default = New cls_tblLookUp.PriceSpec
                For Each tm As Integer In SelectedTimes
                    Dim ppp_night_default_tmp As cls_tblLookUp.PriceSpec = objLookUp.GetPrice2(1, 1, tm, Shift, vselectedServiceType, vselectedRoom, True, ExcludeExtra)
                    ppp_night_default.HouseAmount += ppp_night_default_tmp.HouseAmount
                    ppp_night_default.IsRoomExtra = ppp_night_default_tmp.IsRoomExtra
                    ppp_night_default.IsWeekDayEstra = ppp_night_default_tmp.IsWeekDayEstra
                    ppp_night_default.Price += ppp_night_default_tmp.Price
                    ppp_night_default.Room = ppp_night_default_tmp.Room
                    ppp_night_default.WorkerAmount += ppp_night_default_tmp.WorkerAmount
                    ppp_night_default.ItemSl = ppp_night_default_tmp.ItemSl
                    ppp_night_default.Shift = ppp_night_default_tmp.Shift
                    ppp_night_default.WorkerId = ppp_night_default_tmp.WorkerId
                Next
            Else
                If MySettings.OtherSettings.DayPrice Then
                    ppp_night_default = objLookUp.GetPrice2(1, 1, Val(vselectedTime), cls_tblLookUp.PriceType.NIGHT, vselectedServiceType, vselectedRoom, True, ExcludeExtra)
                    ppp_now = objLookUp.GetPrice2(1, 1, Val(vselectedTime), Shift, vselectedServiceType, vselectedRoom, True, True)
                Else
                    ppp_night_default = objLookUp.GetPrice2(1, 1, Val(vselectedTime), Shift, vselectedServiceType, vselectedRoom, True, ExcludeExtra)
                End If
            End If

            ppp_night_default.HouseAmount += ExtraRoomAmount
            ppp_night_default.Price += ExtraRoomAmount

            ppp_now.HouseAmount += ExtraRoomAmount
            ppp_now.Price += ExtraRoomAmount

            Dim cashout As Double = 0
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0
            If vselectedPaymentMode = "CARD/CASH" Then

            ElseIf vselectedPaymentMode = "CASH" Then
                cashAmt = Val(lblTotalPrice.Text.Replace("" & currency & "", ""))
            ElseIf vselectedPaymentMode = "CARD" Then
                surchargeAmt = cashout * MySettings.Surcharge / 100
                cardAmt = Val(lblTotalPrice.Text.Replace("" & currency & "", "")) + cashout
            End If

            Dim MemberID As String = ""
            If MySettings.OtherSettings.Membership Then
                Dim frmMember As New dlgMembership
                If frmMember.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MemberID = frmMember.MemberID
                Else
                    Return False
                    Exit Function
                End If
            End If


            Dim upgarde_amt As Double = 0
            Dim GST As Double = 0
            Dim SP_A As Double = 0
            Dim HOUSE_A As Double = 0

            Dim CarFare As Double = 0
            Dim EscortExtensionFees As Double = 0
            Dim CardName As String = ""
            Dim sp_names As New List(Of String)
            Dim BondAmt As Double = 0
            Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0
            Try
                sp_names.Add(objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, vWorkerID))
            Catch ex As Exception
            End Try

            Try

                Dim objPayDlg As New clsPaymentDailog
                Dim PayReturn As clsPaymentDailog.BookingPaymentReturn = _
                    objPayDlg.BookingPayment(vselectedRoom, ppp_night_default.Price, vselectedPaymentMode, ppp_night_default.HouseAmount, ppp_night_default.WorkerAmount, True, {0}, False, True, False, True, ppp_now, ppp_night_default, True, sp_names)
                vselectedPaymentMode = PayReturn.PAYMENTMODE
                cashAmt = PayReturn.CASH
                cardAmt = PayReturn.CARD
                blncAmt = 0
                surchargeAmt = PayReturn.SUR_AMT
                surchargeP = PayReturn.SUR_P
                tip = PayReturn.TIP
                cashout = PayReturn.CASHOUT
                VoucherID = PayReturn.VOUCHERID
                VoucherAmount = PayReturn.VOUCHER_AMT
                shift_fee = 0
                upgarde_amt = PayReturn.UPGRADE
                GST = PayReturn.GST
                SP_A = PayReturn.SP_AMOUNT
                HOUSE_A = PayReturn.HOUSE_AMOUNT
                CarFare = PayReturn.CAREFARE
                EscortExtensionFees = PayReturn.ESCORT_EXTENSION_FEES
                CardName = PayReturn.CardName
                BondAmt = PayReturn.ESCORT_BOND_FEES
                TOTAL_PAID = PayReturn.TOTAL_AMOUNT_PAID
            Catch ex As Exception
                Return False
                Exit Function
            End Try


            Dim total As Double = HOUSE_A + SP_A
            Dim BookingID As Integer = 0

            'Save Booking

            Dim MemoNo As Integer = objDocketMemo.Insert("BOOKING", Now, "", "")
            Dim DisplayID As Integer = 0
            Try
                DisplayID = objBooking.GetDisplayID
                objBooking.SaveDisplayID(BookingID, DisplayID)
            Catch ex As Exception
            End Try

            'BookingID = objBooking.Insert(vselectedRoom, _
            '                        Val(vselectedTime), _
            '                        Now, _
            '                        Now, _
            '                        "BOOKING", _
            '                        vWorkerID, clientName, "", 1, MemberID, MemoNo, 0)
            BookingID = objBooking.Insert(vselectedRoom, _
                                     Val(vselectedTime), _
                                     Now, _
                                     Now, _
                                     "BOOKING", "", _
                                     vWorkerID, clientName, "", "", "", 1, MemberID, MemoNo, LoginUserId, False, DisplayID)

            objActiveWorkers.Insert_tblActiveWorker(vWorkerID, Today, vselectedRoom, Val(vselectedTime), Now, status, BookingID, MemoNo)
            objExtend.Insert(Val(vselectedTime), BookingID, vWorkerID, Now, MemoNo, vselectedServiceType, Shift.ToString)
            If vselectedRoom = "ESCORT" Then
                objEscortInfor.Insert(BookingID, frmEsDrInf.txtLocation.Text, frmEsDrInf.txtOther.Text, frmEsDrInf.txtRemarks.Text)
            End If
            Dim Cancel_fees As Double = 0
            objPayment.Insert("BOOKING", total, BookingID, Now, cashAmt, cardAmt, surchargeP, surchargeAmt, tip, "PAID", vselectedPaymentMode, SP_A, HOUSE_A, cashout, vWorkerID, VoucherAmount, VoucherID, shift_fee, MemoNo, upgarde_amt, "", GST, LoginUserId, CarFare, EscortExtensionFees, CardName, Cancel_fees, BondAmt, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

            'Print Booking
            clsDocketPrint.PrintDocketMemo(MemoNo)
            Loadings()
            MainReloader_OnTimerLeftCounter()
            Refresh_NEW()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            Return Nothing
            Exit Function
        End Try
    End Function


    Private Sub btnRemoveAvailable_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAvailable.Click
        If dgAvailableWorker1.Rows.Count + dgAvailableWorker2.Rows.Count > 0 Then
            Dim frmSelectWorkers_obj As New frmSelectSPAddToActiveRoom
            frmSelectWorkers_obj.btnSelectAll.Visible = True
            objWorkers.LoadWorkerInListView(frmSelectWorkers_obj.dgAvailableWorker, cls_tblWorkers.SelectionType.AVAILABLE_WITHOUT_ACTIVE)
            frmSelectWorkers_obj.multiselect = True
            If frmSelectWorkers_obj.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each dr As DataGridViewRow In frmSelectWorkers_obj.dgAvailableWorker.SelectedRows
                    objCheckIN.CheckOut(dr.Cells(0).Value)
                    AvailableWorkerID = 0
                Next
                Loadings()
            End If
        Else
            MsgBox("No logged in SP found", MsgBoxStyle.Information, "Info")
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPhone.Click
        If dgPrebookingNew.Columns(2).HeaderText.Trim <> "SP" Then
            dgPrebookingNew.Columns(2).HeaderText = "SP"
        Else
            dgPrebookingNew.Columns(2).HeaderText = "SP " + "PHONE"
        End If
        LoadBookings(dgPrebookingNew, BookingType.QUEUE_HOME_PAGE_MULTILINE)

    End Sub



    Private Sub FullScreenToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.CheckedChanged
        If FullScreenToolStripMenuItem.Checked Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub dgPrebooking2_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPrebookingNew.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim frm1 As New dlgPreBookingEditMenu
            frm1.BookingID = dgPrebookingNew.Rows(e.RowIndex).Cells(1).Value
            Select Case frm1.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    RefreshPreBooking()
                Case Windows.Forms.DialogResult.Yes
                    Dim aworkerID As Integer = objBooking.SelectDistinct(Database_Table_code_class_tblBookings.FieldName.WorkerID, "[BookingID]=" & frm1.BookingID.ToString).Rows(0).Item(0)

                    If StartBookingNew(aworkerID, "", dgPrebookingNew.Rows(e.RowIndex).Cells(9).Value.ToString, "CASH", "", "", dgPrebookingNew.Rows(e.RowIndex).Cells(10).Value.ToString, "") Then ', dgPrebookingNew.Rows(e.RowIndex).Cells(9).Value.ToString
                        objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.BookingType, "PREBOOKING-CONFIRMED", "[BookingID]=" & frm1.BookingID.ToString)
                        Loadings()
                    End If
            End Select
        End If
    End Sub

    Private Sub OpenCashDrawerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenCashDrawerToolStripMenuItem.Click
        OpenCashdrawer()
    End Sub

    Private Sub ShowSchematicMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowSchematicMapToolStripMenuItem.Click
        If Screen.AllScreens.Length >= 3 Then
            frmMap.Location = Screen.AllScreens(2).WorkingArea.Location
        End If
        If Screen.AllScreens.Length >= 2 Then
            frmMap.Location = Screen.AllScreens(1).WorkingArea.Location
        End If
        frmMap.Show()
    End Sub

    Private Sub HideACCButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideACCButtonsToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            isSite2ButtonsVisible = Not isSite2ButtonsVisible
        End If
    End Sub


    Private Sub dgActiveBooking_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgActiveBooking.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 8 Then
                Dim BookingID As String = dgActiveBooking.Rows(e.RowIndex).Cells(9).Value
                Select Case dgActiveBooking.Rows(e.RowIndex).Cells(8).Value
                    Case "ACTIVATE"
                        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ACTIVATE") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                        dgActiveBooking.Rows(e.RowIndex).Cells(5).Value = Now
                        dgActiveBooking.Rows(e.RowIndex).Cells(7).Value = "STARTED"
                        'dgActiveBooking.Rows(e.RowIndex).Cells(8).Value = "EDIT"
                        dgActiveBooking.Rows(e.RowIndex).Cells(8).Value = "RESET"
                        objActiveWorkers.Start_tblActiveWorker(BookingID)
                        dgActiveBooking.Rows(e.RowIndex).DefaultCellStyle.BackColor = ActiveStarted(0)
                        dgActiveBooking.Rows(e.RowIndex).DefaultCellStyle.ForeColor = ActiveStarted(1)
                    Case "EDIT"
                        EditBooking(e)
                    Case "RESUME"
                        PauseResumeBooking(BookingID)
                    Case "RESET"
                        ' If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Reset Booking") = MsgBoxResult.Yes Then
                        ResetBooking(BookingID)
                        ' End If
                End Select
            End If

        End If
    End Sub


    Sub ExtendBooking(BookingID As Integer, ROOM As String, NoOfClient As Integer)
        ' Dim NoOfClient As Integer = 1
        Dim frmSelectTime_Obj As New frmServiceTime


        '// When Room is ESCORT, disable some of the SERVICE TIMES as per Settings
        If ROOM = "ESCORT" Then
            For Each b As Button In frmSelectTime_Obj.grpService.Controls
                If MySettings.OtherSettings.EscortServices.Contains(b.Tag) Then
                    b.Enabled = True
                Else
                    b.Enabled = False
                    b.BackColor = Color.Gray
                End If
            Next

        End If

        Dim Shift As cls_tblLookUp.PriceType = MyShiftType()
        If ROOM = "ESCORT" Then
            If Not MySettings.OtherSettings.MultipleEscortPrice Then
                Shift = cls_tblLookUp.PriceType.NIGHT
            Else
                Dim frmDlgShift As New frmSelectShift
                If frmDlgShift.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
                Shift = frmDlgShift.SelectedShift
            End If
        End If


        Dim frmSelectWorker_Obj As New frmSelectSPAddToActiveRoom
        objWorkers.LoadWorkerInListView(frmSelectWorker_Obj.dgAvailableWorker, cls_tblWorkers.SelectionType.BOOKINGID, BookingID)
        frmSelectWorker_Obj.multiselect = True
        If frmSelectWorker_Obj.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim NoOfWorker As Integer = frmSelectWorker_Obj.dgAvailableWorker.SelectedRows.Count

        frmSelectTime_Obj.EnableCustomTime(Shift.ToString, ROOM, "STANDARD", NoOfClient, NoOfWorker)
        frmSelectTime_Obj.bookingtype = "EXTEND"
        If frmSelectTime_Obj.ShowDialog = Windows.Forms.DialogResult.OK Then





            Dim PriceSpec_obj As cls_tblLookUp.PriceSpec = Nothing
            Dim PriceSpec_obj_new As cls_tblLookUp.PriceSpec = Nothing

            Try
                If frmSelectTime_Obj.customeTimeType.StartsWith("CUSTOM") Then
                    PriceSpec_obj = New cls_tblLookUp.PriceSpec
                    For Each tm As Integer In frmSelectTime_Obj.SelectedTimes
                        Dim ppp_night_default_tmp As cls_tblLookUp.PriceSpec = objLookUp.GetPrice2(NoOfWorker, NoOfClient, tm, Shift, frmSelectTime_Obj.serviceType, ROOM)
                        PriceSpec_obj.HouseAmount += ppp_night_default_tmp.HouseAmount
                        PriceSpec_obj.IsRoomExtra = ppp_night_default_tmp.IsRoomExtra
                        PriceSpec_obj.IsWeekDayEstra = ppp_night_default_tmp.IsWeekDayEstra
                        PriceSpec_obj.Price += ppp_night_default_tmp.Price
                        PriceSpec_obj.Room = ppp_night_default_tmp.Room
                        PriceSpec_obj.WorkerAmount += ppp_night_default_tmp.WorkerAmount
                        PriceSpec_obj.ItemSl = ppp_night_default_tmp.ItemSl
                        PriceSpec_obj.Shift = ppp_night_default_tmp.Shift
                        PriceSpec_obj.WorkerId = ppp_night_default_tmp.WorkerId
                    Next
                Else
                    If MySettings.OtherSettings.DayPrice Then
                        PriceSpec_obj = objLookUp.GetPrice2(NoOfWorker, NoOfClient, Val(frmSelectTime_Obj.customeTime), cls_tblLookUp.PriceType.NIGHT, frmSelectTime_Obj.serviceType, ROOM)
                        PriceSpec_obj_new = objLookUp.GetPrice2(NoOfWorker, NoOfClient, Val(frmSelectTime_Obj.customeTime), Shift, frmSelectTime_Obj.serviceType, ROOM)
                    Else
                        PriceSpec_obj = objLookUp.GetPrice2(NoOfWorker, NoOfClient, Val(frmSelectTime_Obj.customeTime), Shift, frmSelectTime_Obj.serviceType, ROOM)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                Exit Sub
            End Try
            Dim cashAmt As Double = 0
            Dim cardAmt As Double = 0
            Dim blncAmt As Double = 0
            Dim SurchargAmt As Double = 0
            Dim SurchargP As Double = 0
            Dim PaymentMode As String = ""
            Dim shift_fee As Double = 0
            Dim cashout As Double = 0
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0
            Dim tip As Double = 0
            Dim upgarde_amt As Double = 0
            Dim GST As Double = 0
            Dim SP_A As Double = 0
            Dim HOUSE_A As Double = 0
            Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0
            'PriceSpec_obj.WorkerAmount = PriceSpec_obj.WorkerAmount * NoOfWorker
            'PriceSpec_obj.HouseAmount = PriceSpec_obj.HouseAmount * NoOfWorker

            'PriceSpec_obj_new.WorkerAmount = PriceSpec_obj_new.WorkerAmount * NoOfWorker
            'PriceSpec_obj_new.HouseAmount = PriceSpec_obj_new.HouseAmount * NoOfWorker

            Dim sp_names As New List(Of String)
            Try
                For Each dgr As DataGridViewRow In frmSelectWorker_Obj.dgAvailableWorker.SelectedRows
                    sp_names.Add(objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, dgr.Cells(0).Value))
                Next
            Catch ex As Exception
            End Try

            Dim CarFare As Double = 0
            Dim EscortExtensionFees As Double = 0
            Dim Total As Double = 0
            Dim BondAmt As Double = 0

            Dim CardName As String = ""
            If ROOM = "ESCORT" Then
                '//Show Escort Payment Window when the ROOM is ESCORT
                Dim frmP As New frmPaymentEscort(sp_names)
                frmP.NightPrice = PriceSpec_obj
                frmP.CurrentPrice = PriceSpec_obj_new
                frmP.txtShiftFee.Enabled = False
                frmP.txtHouse.Text = (PriceSpec_obj.HouseAmount).ToString("0.00")
                frmP.txtWorkerAmount.Text = (PriceSpec_obj.WorkerAmount).ToString("0.00")
                frmP.selectedPaymentMode = PaymentMode
                frmP.isBond = False
                If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then

                    PaymentMode = frmP.selectedPaymentMode
                    cashAmt = Val(frmP.txtCash.Text)
                    cardAmt = Val(frmP.txtCard.Text)
                    blncAmt = 0
                    SurchargAmt = Val(frmP.txtSurchargeAmt.Text)
                    SurchargP = Val(frmP.txtSurchrgeP.Text)
                    cashout = Val(frmP.txtCashOut.Text)
                    VoucherID = frmP.VoucherId
                    VoucherAmount = Val(frmP.txtVoucherAmount.Text)
                    upgarde_amt = Val(frmP.txtUpgrade.Text)
                    tip = Val(frmP.txtTip.Text)
                    GST = Val(frmP.txtGST.Text)
                    SP_A = Val(frmP.txtWorkerAmount.Text)
                    HOUSE_A = Val(frmP.txtHouse.Text)
                    CarFare = Val(frmP.txtCarFare.Text)
                    EscortExtensionFees = Val(frmP.txtEscortExtFees.Text)
                    Total = (Val(frmP.txtWorkerAmount.Text) + Val(frmP.txtHouse.Text))
                    CardName = frmP.CardName
                    TOTAL_PAID = frmP.txtAmountPaid.Text
                    BondAmt = Val(frmP.txtEscortBondFees.Text)

                Else
                    Exit Sub
                End If

            Else
                '// Show Normal Booking Payment Window when the ROOM is not ESCORT
                Dim frmP As New frmPaymentBooking(sp_names)
                frmP.NightPrice = PriceSpec_obj
                frmP.CurrentPrice = PriceSpec_obj_new
                frmP.txtShiftFee.Enabled = False
                frmP.txtHouse.Text = (PriceSpec_obj.HouseAmount).ToString("0.00")
                frmP.txtWorkerAmount.Text = (PriceSpec_obj.WorkerAmount).ToString("0.00")
                frmP.selectedPaymentMode = PaymentMode

                If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then

                    PaymentMode = frmP.selectedPaymentMode
                    cashAmt = Val(frmP.txtCash.Text)
                    cardAmt = Val(frmP.txtCard.Text)
                    blncAmt = 0
                    SurchargAmt = Val(frmP.txtSurchargeAmt.Text)
                    SurchargP = Val(frmP.txtSurchrgeP.Text)
                    cashout = Val(frmP.txtCashOut.Text)
                    VoucherID = frmP.VoucherId
                    VoucherAmount = Val(frmP.txtVoucherAmount.Text)
                    upgarde_amt = Val(frmP.txtUpgrade.Text)
                    tip = Val(frmP.txtTip.Text)
                    GST = Val(frmP.txtGST.Text)
                    SP_A = Val(frmP.txtWorkerAmount.Text)
                    HOUSE_A = Val(frmP.txtHouse.Text)
                    TOTAL_PAID = frmP.txtAmountPaid.Text
                    Total = (Val(frmP.txtWorkerAmount.Text) + Val(frmP.txtHouse.Text))
                    CardName = frmP.CardName
                Else
                    Exit Sub
                End If


            End If

            Dim wnames As String = ""
            Dim wid As Integer = 0
            Dim wname As String = ""
            Dim MemoNo As Integer = objDocketMemo.Insert("EXTEND SERVICE", Now, "", "")
            Dim DisplayID As Integer = 0
            Try
                DisplayID = objBooking.GetDisplayID
                objBooking.SaveDisplayID(BookingID, DisplayID)
            Catch ex As Exception
            End Try

            For Each dgr As DataGridViewRow In frmSelectWorker_Obj.dgAvailableWorker.SelectedRows
                wid = dgr.Cells(0).Value
                wname = dgr.Cells(1).Value
                objExtend.Insert(Val(frmSelectTime_Obj.customeTime), BookingID, wid, Now, MemoNo, frmSelectTime_Obj.serviceType, Shift.ToString)
                Dim Cancel_fees As Double = 0
                objPayment.Insert("EXTEND SERVICE", Total / NoOfWorker, BookingID, Now, cashAmt / NoOfWorker, cardAmt / NoOfWorker, SurchargP, SurchargAmt / NoOfWorker, tip / NoOfWorker, "PAID", PaymentMode, SP_A / NoOfWorker, HOUSE_A / NoOfWorker, cashout / NoOfWorker, wid, VoucherAmount / NoOfWorker, VoucherID, shift_fee / NoOfWorker, MemoNo, upgarde_amt / NoOfWorker, "", GST / NoOfWorker, LoginUserId, CarFare / NoOfWorker, EscortExtensionFees / NoOfWorker, CardName, Cancel_fees, BondAmt, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)
                wnames += wname + ","
            Next

            '//Remove Sound warnings if already registered. Becasue after extension all sound warning must repeat.
            Try
                For i = BookingWarnings.Count - 1 To 0 Step -1
                    If BookingWarnings(i).BookingId = BookingID Then
                        BookingWarnings.RemoveAt(i)
                    End If
                Next
            Catch ex As Exception
            End Try

            '//Print and refresh Active booking List
            clsDocketPrint.PrintDocketMemo(MemoNo)
            MainReloader_OnTimerLeftCounter()
        End If

    End Sub

    Sub AddSP(BookingID As Integer, Room As String, Service As String, isBookingActive As Boolean)
        Dim frmSelectWorkers_obj As New frmSelectSPAddToActiveRoom
        objWorkers.LoadWorkerInListView(frmSelectWorkers_obj.dgAvailableWorker, cls_tblWorkers.SelectionType.AVAILABLE_WITHOUT_ACTIVE)
        If frmSelectWorkers_obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not IsWorkerActive(frmSelectWorkers_obj.dgAvailableWorker.SelectedRows(0).Cells(0).Value) Then
                MsgBox("SP already Active.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim frmServiceTime_Obj As New frmServiceTime
            If frmServiceTime_Obj.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            Dim ppp_night_default As cls_tblLookUp.PriceSpec = objLookUp.GetPrice(1, 1, Val(frmServiceTime_Obj.customeTime), frmServiceTime_Obj.serviceType, Room)
            Dim ppp_now As cls_tblLookUp.PriceSpec = Nothing
            Try
                ppp_now = objLookUp.GetPrice(1, 1, Val(frmServiceTime_Obj.customeTime), frmServiceTime_Obj.serviceType, Room, False)
            Catch ex As Exception
            End Try
            Dim WorkerID As String = frmSelectWorkers_obj.dgAvailableWorker.SelectedRows(0).Cells(0).Value

            Dim cashAmt As Double = 0
            Dim cardAmt As Double = 0
            Dim blncAmt As Double = 0
            Dim shift_fee As Double = 0
            Dim SurchargeAmt As Double = 0
            Dim SurchargeP As Double = 0
            Dim PaymentMode As String = ""
            Dim VoucherID As Integer = 0
            Dim VoucherAmount As Double = 0

            Dim cashout As Double = 0
            Dim upgarde_amt As Double = 0
            Dim GST As Double = 0
            Dim SP_A As Double = 0
            Dim HOUSE_A As Double = 0
            Dim BondAmt As Double = 0

            Dim CarFare As Double = 0
            Dim EscortExtensionFee As Double = 0
            Dim CardName As String = ""
            Dim sp_names As New List(Of String)
            Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0
            Try
                sp_names.Add(objWorkers.SelectScalar(cls_tblWorkers.FieldNames.WorkerName, WorkerID))
            Catch ex As Exception
            End Try



            Try
                Dim objPayDlg As New clsPaymentDailog
                Dim PayReturn As clsPaymentDailog.BookingPaymentReturn = _
                    objPayDlg.BookingPayment(Room, ppp_night_default.Price, "CASH", ppp_night_default.HouseAmount, ppp_night_default.WorkerAmount, False, {0}, False, True, False, True, ppp_now, ppp_night_default, True, sp_names)
                PaymentMode = PayReturn.PAYMENTMODE
                cashAmt = PayReturn.CASH
                cardAmt = PayReturn.CARD
                blncAmt = 0
                SurchargeAmt = PayReturn.SUR_AMT
                SurchargeP = PayReturn.SUR_P
                cashout = PayReturn.CASHOUT
                VoucherID = PayReturn.VOUCHERID
                VoucherAmount = PayReturn.VOUCHER_AMT
                upgarde_amt = PayReturn.UPGRADE
                GST = PayReturn.GST
                SP_A = PayReturn.SP_AMOUNT
                HOUSE_A = PayReturn.HOUSE_AMOUNT
                CarFare = PayReturn.CAREFARE
                EscortExtensionFee = PayReturn.ESCORT_EXTENSION_FEES
                CardName = PayReturn.CardName
                BondAmt = PayReturn.ESCORT_BOND_FEES
                TOTAL_PAID = PayReturn.TOTAL_AMOUNT_PAID
            Catch ex As Exception
            End Try
 
            Dim total As Double = SP_A + HOUSE_A
            Dim Shift As String = MyShift()
            Dim DisplayID As Integer = 0
            Try
                DisplayID = objBooking.GetDisplayID
                objBooking.SaveDisplayID(BookingID, DisplayID)
            Catch ex As Exception
            End Try


            Dim MemoNo As Integer = objDocketMemo.Insert("ADD WORKER", Now, "", "")
            objActiveWorkers.Insert_tblActiveWorker(WorkerID, _
                                            Today, _
                                            Room, _
                                            Val(Service), _
                                            Now, IIf(isBookingActive, "STARTED", ""), _
                                            BookingID, MemoNo)

            objExtend.Insert(Val(frmServiceTime_Obj.customeTime), BookingID, WorkerID, Now, MemoNo, frmServiceTime_Obj.serviceType, Shift)
            Dim Cancel_fees As Double = 0
            objPayment.Insert("ADD WORKER", total, BookingID, Now, cashAmt, cardAmt, SurchargeP, SurchargeAmt, 0, "PAID", PaymentMode, SP_A, HOUSE_A, cashout, WorkerID, VoucherAmount, VoucherID, 0, MemoNo, upgarde_amt, "", GST, LoginUserId, CarFare, EscortExtensionFee, CardName, Cancel_fees, BondAmt, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)
            If isBookingActive Then
                PauseBooking_NoFresh(BookingID)
            End If

            '//
            clsDocketPrint.PrintDocketMemo(MemoNo)
            LoadingsBeforeReloader()
            MainReloader_OnTimerLeftCounter()
        End If
    End Sub


    Sub RemoveSP(BookingID As Integer, Room As String, SPs As String, WorkerIds As String)
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CLEAR ROOM") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim frm As New frmSelectSPClearFinished
        Dim lst() As String = SPs.Split(vbNewLine)
        Dim lst1() As String = WorkerIds.Split(",")
        For i = 0 To lst.Length - 1
            Dim li As New ListViewItem
            Try
                li.Text = lst(i).Trim & " (" & Room & ")"
            Catch ex As Exception
            End Try
            Try
                li.Tag = lst1(i)
            Catch ex As Exception
            End Try
            frm.lstServiceProvider.Items.Add(li)
        Next
        If frm.lstServiceProvider.Items.Count <= 0 Then
            MsgBox("No completed SP found", MsgBoxStyle.Critical, "Info")
            Exit Sub
        End If
        frm.isMultiple = False
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            objActiveWorkers.tblActiveWorker_Update_room_By_BookingID_WorkerID(BookingID, Val(frm.lstServiceProvider.SelectedItems(0).Tag), "CLEARED AT " + Now.ToString)
            MainReloader_OnTimerLeftCounter()
            Refresh_NEW()
        End If
    End Sub


    'Sub RedoBookingCustom()

    'End Sub

    Sub SuspendBooking(BookingID As Integer, DateT As Date, Service As String, Room As String)
        Dim reason As String = ""
        '//Set reason 

        Dim frmReason_obj As New dlgReason
        frmReason_obj.ReasonType = "SUSPEND REASON"
        If frmReason_obj.ShowDialog = Windows.Forms.DialogResult.OK Then
            reason = frmReason_obj.txtReason.Text
        Else
            Exit Sub
        End If

        Dim dtWorkers As DataTable = objActiveWorkers.tblActiveWorker_Selection(0, "a.BookingID=" & BookingID.ToString)
        Dim dtBookinf As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "a.BookingID=" & BookingID.ToString)


        Dim MemoNo As Integer = objDocketMemo.Insert("SUSPEND BOOKING", Now, reason, "")
        Dim SuspendID As Integer = objBookingStatus.NewId("SUSPEND")
        objBookingStatus.Insert(BookingID, "SUSPEND", Now, MemoNo, "", LoginUserId, SuspendID)
        objActiveWorkers.tblActiveWorker_Update_By_BookingID(BookingID, "SUSPENDED AT " + Now.ToString)
        Dim str As String = ""
        Try
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += workerName("WorkerName")
                End If
            Next
        Catch ex As Exception
        End Try




        Dim frm As New frmPrintSuspension
        Dim vselectedServiceType As String = ""
        frm.Print(BookingID, DateT, Service, Room, dtBookinf.Rows(0).Item("TotalClient"), str.Trim, MyLocalSettings.ReceiptPrinter, False, vselectedServiceType, SuspendID)
        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()

    End Sub

    Sub ChangeBookingRoom(Room As String, WorkerIds As String, BookingID As Integer)
        If MsgBox("Are you sure?" & vbNewLine & "NOTE: Changing the room will reset the timer.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim frm As New frmSelectRoom
        frm.ExcludeRoom = ROOM
        CheckRoomValidity(False, frm, ROOM)
        CHeckRoomStatus(frm)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Room, frm.selectedRoom, "[BookingID]=" & BookingID)
            For Each wid As String In WorkerIDs.Split(",")
                objActiveWorkers.tblActiveWorker_Update_BookingID_workerID(Val(wid), BookingID, frm.selectedRoom)
            Next
            MainReloader_OnTimerLeftCounter()
        End If
    End Sub




    Sub SwapBookingRoom(Room As String, WorkerIds As String, BookingID As Integer)
        If MsgBox("Are you sure?" & vbNewLine & "NOTE: Changing the room will reset both the timer.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim frm As New frmSelectRoom

        frm.ExcludeRoom = Room
        CHeckRoomStatus(frm)
        CheckRoomValidity(False, frm, Room, True)

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim NewBookingId As String = objActiveWorkers.GetActiveBookingIDByRoom(frm.selectedRoom)

            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Room, frm.selectedRoom, "[BookingID]=" & BookingID)
            For Each wid As String In WorkerIds.Split(",")
                objActiveWorkers.tblActiveWorker_Update_BookingID_workerID(Val(wid), BookingID, frm.selectedRoom)
            Next


            '// Change the Other Booking to This room
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.Room, Room, "[BookingID]=" & NewBookingId)
            For Each wid As String In objActiveWorkers.GetActiveWorkerIDsByBookingID(NewBookingId)
                objActiveWorkers.tblActiveWorker_Update_BookingID_workerID(Val(wid), NewBookingId, Room)
            Next

            MainReloader_OnTimerLeftCounter()
        End If
    End Sub

    Sub ChangeWorker(BookingID As Integer, Room As String, WorkerIds As String, SPs As String)
        Dim frm As New frmSelectSPClearFinished
        Dim lst() As String = SPs.Split(vbNewLine)
        Dim lst1() As String = WorkerIds.Split(",")
        For i = 0 To lst.Length - 1
            Dim li As New ListViewItem
            Try
                li.Text = lst(i).Trim & " (" & Room & ")"
            Catch ex As Exception
            End Try
            Try
                li.Tag = lst1(i)
            Catch ex As Exception
            End Try
            frm.lstServiceProvider.Items.Add(li)
        Next
        frm.isMultiple = False
        Dim workerID As Integer = 0
        Dim NewworkerID As Integer = 0
        If frm.lstServiceProvider.Items.Count > 1 Then
            If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            workerID = Val(frm.lstServiceProvider.SelectedItems(0).Tag)
        Else
            workerID = Val(frm.lstServiceProvider.Items(0).Tag)
        End If

        Dim frm1 As New frmSelectSPAddToActiveRoom
        objWorkers.LoadWorkerInListView(frm1.dgAvailableWorker, cls_tblWorkers.SelectionType.AVAILABLE_WITHOUT_ACTIVE)
        frm1.multiselect = False
        If frm1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            NewworkerID = frm1.dgAvailableWorker.SelectedRows(0).Cells(0).Value
        Else
            Exit Sub
        End If


        objActiveWorkers.tblActiveWorker_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)
        objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.WorkerID, NewworkerID, "[BookingID]=" & BookingID.ToString & " AND [WorkerId]=" & workerID.ToString)


        objExtend.tblExtraService_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)
        objPayment.tblBookingPayments_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)

        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()
    End Sub
    Sub SwapSP(BookingID As Integer, Room As String, WorkerIds As String, SPs As String)

        Dim frm As New frmSelectSPClearFinished
        Dim lst() As String = SPs.Split(vbNewLine)
        Dim lst1() As String = WorkerIds.Split(",")
        For i = 0 To lst.Length - 1
            Dim li As New ListViewItem
            Try
                li.Text = lst(i).Trim & " (" & Room & ")"
            Catch ex As Exception
            End Try
            Try
                li.Tag = lst1(i)
            Catch ex As Exception
            End Try
            frm.lstServiceProvider.Items.Add(li)
        Next

        frm.isMultiple = False
        Dim workerID As Integer = 0
        Dim NewworkerID As Integer = 0

        If frm.lstServiceProvider.Items.Count > 1 Then
            If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            workerID = Val(frm.lstServiceProvider.SelectedItems(0).Tag)
        Else
            workerID = Val(frm.lstServiceProvider.Items(0).Tag)
        End If



        Dim frm1 As New frmSelectSPAddToActiveRoom
        objWorkers.LoadWorkerInListView(frm1.dgAvailableWorker, cls_tblWorkers.SelectionType.ACTIVE_Without_bookingID, BookingID)
        frm1.multiselect = False
        If frm1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            NewworkerID = frm1.dgAvailableWorker.SelectedRows(0).Cells(0).Value
        Else
            Exit Sub
        End If

        Dim NewBookingID As Integer = objActiveWorkers.GetActiveBookingIDByWorkerID(NewworkerID)

        'Change 1st worker
        objActiveWorkers.tblActiveWorker_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)
        Try
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.WorkerID, NewworkerID, "[BookingID]=" & BookingID.ToString & " AND [WorkerId]=" & workerID.ToString)
        Catch ex As Exception
        End Try
        objExtend.tblExtraService_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)
        objPayment.tblBookingPayments_Update_CHANGE_WORKER(BookingID, workerID, NewworkerID)


        'Change 2nd Worker
        objActiveWorkers.tblActiveWorker_Update_CHANGE_WORKER(NewBookingID, NewworkerID, workerID)
        Try
            objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.WorkerID, workerID, "[BookingID]=" & NewBookingID.ToString & " AND [WorkerId]=" & NewworkerID.ToString)
        Catch ex As Exception
        End Try
        objExtend.tblExtraService_Update_CHANGE_WORKER(NewBookingID, NewworkerID, workerID)
        objPayment.tblBookingPayments_Update_CHANGE_WORKER(NewBookingID, NewworkerID, workerID)



        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()
    End Sub
    Sub CancelBooking(BookingID As Integer, Room As String, DateT As Date, Service As String)

        If Not MySettings.OtherSettings.CancellationPassword = "" Then
            Dim frmPAss As New dlgAdminPass
            If frmPAss.ShowDialog = Windows.Forms.DialogResult.OK Then
                If frmPAss.TextBox1.Text = MySettings.OtherSettings.CancellationPassword Then
                    'frmAdmin.Show()
                    'frmAdmin.Activate()
                Else
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CANCEL BOOKING") = MsgBoxResult.No Then
            Exit Sub
        End If

        '//##Process Cancellation
        '//Load required data and booking details
        Dim dtBookinf As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingID=" & BookingID.ToString) ', dtBookinf.Rows(0).Item("TotalClient")
        Dim dtWorkers As DataTable = objActiveWorkers.tblActiveWorker_Selection(0, "a.BookingID=" & BookingID.ToString)
        Dim WorkerID As Integer = 0
        If dtWorkers.Rows.Count = 1 Then
            WorkerID = dtWorkers.Rows(0).Item("WorkerID")
        End If
        Dim str As String = ""
        Dim sp_names As New List(Of String)
        Try
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += workerName("WorkerName")
                    sp_names.Add(workerName("WorkerName"))
                End If
            Next
        Catch ex As Exception
        End Try

        Dim reason As String = ""
        '//Set reason 

        Dim frmReason_obj As New dlgReason
        frmReason_obj.ReasonType = "CANCEL REASON"
        If frmReason_obj.ShowDialog = Windows.Forms.DialogResult.OK Then
            reason = frmReason_obj.txtReason.Text
        Else
            Exit Sub
        End If

        'Dim PaymentReturn As clsPaymentDailog.BookingPaymentReturn

        Dim cncl_fees As Double = 0
        If Val(Service) > 60 Then
            cncl_fees = MySettings.OtherSettings.CancelFeesAfter1Hr
        Else
            cncl_fees = MySettings.OtherSettings.CancelFees
        End If


        Dim TotalBookingAmount_ex_sur As Double = 0
        Dim sp_amount As Double = 0
        Dim house_amount As Double = 0

        Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0

        Try
            Dim dtBPayment As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId =" & BookingID)
            'Dim cash As Double = frmSummary.TotalField(dtBPayment, "Cash")
            'Dim card As Double = frmSummary.TotalField(dtBPayment, "Card") + frmSummary.TotalField(dtBPayment, "Surcharge_Amt")
            'Dim vch As Double = frmSummary.TotalField(dtBPayment, "VoucherAmount")

            sp_amount = frmSummary.TotalField(dtBPayment, "sp_amount")
            house_amount = frmSummary.TotalField(dtBPayment, "house_amount")
            TotalBookingAmount_ex_sur = house_amount + sp_amount
        Catch ex As Exception
        End Try

        'If MessageBox.Show("Cancellation fees applicable ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
        '    cncl_fees = 0
        'End If


        Dim totalReturn As Double = TotalBookingAmount_ex_sur - cncl_fees

        sp_names.Add(vbNewLine & "Total Amount " & currency & TotalBookingAmount_ex_sur.ToString("0.00"))
        sp_names.Add(vbNewLine & "Total Return Amount " & currency & totalReturn.ToString("0.00"))


        'PaymentReturn = objPaymentDailogClass.BookingPayment(Room, cncl_fees, "", cncl_fees, 0, {0}, True, False, False, False, Nothing, Nothing, False, sp_names, True)



        Dim frmCn As New frmCancelBookingOption
        frmCn.CASHBACK_AMOUT = totalReturn
        frmCn.VOUCHER_AMOUT = totalReturn

        Dim DisplayID As Integer = 0
        Try
            DisplayID = objBooking.GetDisplayID
            objBooking.SaveDisplayID(BookingID, DisplayID)
        Catch ex As Exception
        End Try


        'If frmCn.ShowDialog = Windows.Forms.DialogResult.OK Then
        '// Create Cancel Memo
        Dim MemoNo As Integer = objDocketMemo.Insert("CANCEL BOOKING", Now, "", "")

        '//Set Booking Staus as Cancelled
        Dim CancelID As Integer = objBookingStatus.NewId("CANCEL")
        objBookingStatus.Insert(BookingID, "CANCEL", Now, MemoNo, reason, LoginUserId, CancelID)

        '//Update Active SP as Cancelled.

        objActiveWorkers.tblActiveWorker_Update_By_BookingID(BookingID, "CANCELLED AT " + Now.ToString)
        ' Dim WorkerID As Integer = 0

        'objPayment.tblBookingPayments_CancelBooking(BookingID)" & currency & "" & currency & "


        'objPayment.Insert("CANCEL BOOKING", PaymentReturn.MAIN_TOTAL_WITH_GST, BookingID, Now, -PaymentReturn.CASH, PaymentReturn.CARD, PaymentReturn.SUR_P, PaymentReturn.SUR_AMT, 0, "PAID", PaymentReturn.PAYMENTMODE, PaymentReturn.SP_AMOUNT, PaymentReturn.HOUSE_AMOUNT, PaymentReturn.CASHOUT, WorkerID, PaymentReturn.VOUCHER_AMT, PaymentReturn.VOUCHERID, 0, MemoNo, PaymentReturn.UPGRADE, PaymentReturn.GST, LoginUserId, PaymentReturn.CAREFARE, PaymentReturn.ESCORT_EXTENSION_FEES, PaymentReturn.CardName)
        TOTAL_PAID = -totalReturn
        objPayment.Insert("CANCEL BOOKING", -totalReturn, BookingID, Now, -totalReturn, 0, 0, 0, 0, "PAID", "CASH", -sp_amount, -house_amount, 0, WorkerID, 0, 0, 0, MemoNo, 0, "", CalculateGST(-house_amount + cncl_fees), LoginUserId, 0, 0, "", cncl_fees, 0, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

        '//Prepare for Printing
        MsgBox("Cancelled." & vbNewLine & "Please return total " & currency & totalReturn.ToString("0.00") & " in cash. " & vbNewLine & "(SP : " & currency & sp_amount.ToString("0.00") & " | House : " & currency & (totalReturn - sp_amount).ToString("0.00") & ")", MsgBoxStyle.Information, "Info")

        Dim frm As New frmPrintCancelBooking
        Dim vselectedServiceType As String = ""
        frm.Print(BookingID, DateT, Service, Room, dtBookinf.Rows(0).Item("TotalClient"), str.Trim, MyLocalSettings.ReceiptPrinter, False, vselectedServiceType, cncl_fees)
        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()
        'End If

    End Sub
    Sub CancelBookingUserError(BookingID As Integer, Room As String, DateT As Date, Service As String) 'TODO: It uses Display Booking numbers. And also creates a boucher. 
        If Not MySettings.OtherSettings.CancellationPassword = "" Then
            Dim frmPAss As New dlgAdminPass
            If frmPAss.ShowDialog = Windows.Forms.DialogResult.OK Then
                If frmPAss.TextBox1.Text = MySettings.OtherSettings.CancellationPassword Then
                    'frmAdmin.Show()
                    'frmAdmin.Activate()
                Else
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CANCEL BOOKING") = MsgBoxResult.No Then
            Exit Sub
        End If
        '//##Process Cancellation
        '//Load required data and booking details
        Dim dtBookinf As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingID=" & BookingID.ToString) ', dtBookinf.Rows(0).Item("TotalClient")
        Dim dtWorkers As DataTable = objActiveWorkers.tblActiveWorker_Selection(0, "a.BookingID=" & BookingID.ToString)
        Dim str As String = ""
        Dim sp_names As New List(Of String)
        Try
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += workerName("WorkerName")
                    sp_names.Add(workerName("WorkerName"))
                End If
            Next
        Catch ex As Exception
        End Try

        Dim reason As String = "USER ERROR"
        '//Set reason 

        'Dim frmReason_obj As New dlgReason
        'frmReason_obj.ReasonType = "CANCEL REASON"
        'If frmReason_obj.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    reason = frmReason_obj.txtReason.Text
        'Else
        '    Exit Sub
        'End If

        'Dim PaymentReturn As clsPaymentDailog.BookingPaymentReturn

        Dim cncl_fees As Double = 0
      

        Dim TotalBookingAmount_ex_sur As Double = 0
        Dim sp_amount As Double = 0
        Dim house_amount As Double = 0
        Try
            Dim dtBPayment As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId =" & BookingID)
            Dim cash As Double = frmSummary.TotalField(dtBPayment, "Cash")
            Dim card As Double = frmSummary.TotalField(dtBPayment, "Card") + frmSummary.TotalField(dtBPayment, "Surcharge_Amt")
            Dim vch As Double = frmSummary.TotalField(dtBPayment, "VoucherAmount")
            sp_amount = frmSummary.TotalField(dtBPayment, "sp_amount")
            house_amount = frmSummary.TotalField(dtBPayment, "house_amount")
            'TotalBookingAmount_ex_sur = house_amount + sp_amount
            TotalBookingAmount_ex_sur = cash + card + vch
        Catch ex As Exception
        End Try


        Dim totalReturn As Double = TotalBookingAmount_ex_sur - cncl_fees
        sp_names.Add(vbNewLine & "Total Amount " & currency & TotalBookingAmount_ex_sur.ToString("0.00"))
        sp_names.Add(vbNewLine & "Total Return Amount " & currency & totalReturn.ToString("0.00"))

        'PaymentReturn = objPaymentDailogClass.BookingPayment(Room, cncl_fees, "", cncl_fees, 0, {0}, True, False, False, False, Nothing, Nothing, False, sp_names, True)


        '// Create Cancel Memo
        Dim MemoNo As Integer = objDocketMemo.Insert("CANCEL BOOKING ERROR", Now, "", "")
        Dim CancelID As Integer = objBookingStatus.NewId("CANCEL")


        Dim DisplayID As Integer = 0
        Try
            DisplayID = objBooking.GetDisplayID
            objBooking.SaveDisplayID(BookingID, DisplayID)
        Catch ex As Exception
        End Try


        '//Set Booking Staus as Cancelled
        objBookingStatus.Insert(BookingID, "CANCEL", Now, MemoNo, reason, LoginUserId, CancelID)


        '//Update Active SP as Cancelled.
        objActiveWorkers.tblActiveWorker_Update_By_BookingID(BookingID, "CANCELLED AT " + Now.ToString)
        Dim WorkerID As Integer = 0

        'objPayment.tblBookingPayments_CancelBooking(BookingID)" & currency & "" & currency & "

        'objPayment.Insert("CANCEL BOOKING", PaymentReturn.MAIN_TOTAL_WITH_GST, BookingID, Now, -PaymentReturn.CASH, PaymentReturn.CARD, PaymentReturn.SUR_P, PaymentReturn.SUR_AMT, 0, "PAID", PaymentReturn.PAYMENTMODE, PaymentReturn.SP_AMOUNT, PaymentReturn.HOUSE_AMOUNT, PaymentReturn.CASHOUT, WorkerID, PaymentReturn.VOUCHER_AMT, PaymentReturn.VOUCHERID, 0, MemoNo, PaymentReturn.UPGRADE, PaymentReturn.GST, LoginUserId, PaymentReturn.CAREFARE, PaymentReturn.ESCORT_EXTENSION_FEES, PaymentReturn.CardName)
        Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0
        TOTAL_PAID = -totalReturn
        objPayment.Insert("CANCEL BOOKING", -totalReturn, BookingID, Now, -totalReturn, 0, 0, 0, 0, "PAID", "CASH", -sp_amount, -house_amount, 0, WorkerID, 0, 0, 0, MemoNo, 0, "", CalculateGST(-house_amount + cncl_fees), LoginUserId, 0, 0, "", cncl_fees, 0, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

        '//Prepare for Printing

        'MsgBox("Cancelled." & vbNewLine & "Please return " & currency & totalReturn.ToString("0.00") & " in cash. (SP : " & currency & sp_amount.ToString("0.00") & ")", MsgBoxStyle.Information, "Info")
        MsgBox("Cancelled.", MsgBoxStyle.Information, "Info")

        Dim frm As New frmPrintCancelBooking
        Dim vselectedServiceType As String = ""
        frm.Print(BookingID, DateT, Service, Room, dtBookinf.Rows(0).Item("TotalClient"), str.Trim, MyLocalSettings.ReceiptPrinter, False, vselectedServiceType, cncl_fees)
        MainReloader_OnTimerLeftCounter()
        Refresh_NEW()

    End Sub
    Structure MyPriceSpec
        Dim WorkerId As Integer
        Dim PriceSpec As cls_tblLookUp.PriceSpec
    End Structure
    Function ListOfSpInABooking(ByVal _bookingId As Integer, Optional ByRef StrCommaSepratedReturn As String = "") As List(Of String)
        Dim dtWorkers As DataTable = objActiveWorkers.tblActiveWorker_Selection(0, "a.BookingID=" & _bookingId.ToString)
        Dim str As String = ""
        Dim sp_names As New List(Of String)
        Try
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += workerName("WorkerName")
                    sp_names.Add(workerName("WorkerName"))
                End If
            Next
        Catch ex As Exception
        End Try
        StrCommaSepratedReturn = str
        Return sp_names
    End Function

    Sub AddClient_ChargedNormal(bookingId As Integer, room As String, isBookingActive As Boolean)
        '// Declare required variables
        Dim NoOfClient As Integer = 0

        '// Select No of Client To be added.
        Dim objFrmClientSelect As New frmSelectNoOfClients

        If objFrmClientSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
            NoOfClient = objFrmClientSelect.NumericUpDown1.Value
        Else
            Exit Sub
        End If

        '//Get Total Booking Amount
        Dim dtWorkerTotal As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.TOTAL_WORKER_WISE_SELECTSTRING_AS_BOOKINGID, "", New List(Of SqlParameter) From {New SqlParameter("@bookingid", bookingId)})


        Dim dtService As DataTable = objExtend.Selection(cls_tblExtraService.SelectionType.ALL, "bookingid=@bookingid", New List(Of SqlParameter) From {New SqlParameter("@bookingid", bookingId)})
        Dim dtWorkers As DataTable = objActiveWorkers.tblActiveWorker_Selection(0, "a.BookingID=" & bookingId.ToString)
        Dim str As String = ""
        Dim sp_names As New List(Of String)
        Try
            For Each workerName As DataRow In dtWorkers.Rows
                If workerName("WorkerName").Trim <> "" Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += workerName("WorkerName")
                    sp_names.Add(workerName("WorkerName"))
                End If
            Next
        Catch ex As Exception
        End Try


        Dim CurrentPrices As New List(Of cls_tblLookUp.PriceSpec)
        Dim NightPrices As New List(Of cls_tblLookUp.PriceSpec)

        Dim CurrentPriceTotal As New cls_tblLookUp.PriceSpec
        Dim NightPriceTotal As New cls_tblLookUp.PriceSpec

        For Each dr As DataRow In dtService.Rows

            Dim tmp_PS_Current As cls_tblLookUp.PriceSpec = objLookUp.GetPrice(1, NoOfClient, dr("Service"), dr("ServiceType"), room, False)
            tmp_PS_Current.WorkerId = dr("WorkerID")
            CurrentPriceTotal.HouseAmount += tmp_PS_Current.HouseAmount
            CurrentPriceTotal.WorkerAmount += tmp_PS_Current.WorkerAmount
            CurrentPriceTotal.Price += tmp_PS_Current.WorkerAmount + tmp_PS_Current.HouseAmount
            CurrentPrices.Add(tmp_PS_Current)


            Dim tmp_PS_Night As cls_tblLookUp.PriceSpec = Nothing
            tmp_PS_Night = objLookUp.GetPrice(1, NoOfClient, dr("Service"), dr("ServiceType"), room, True)
            tmp_PS_Night.WorkerId = dr("WorkerID")
            NightPriceTotal.HouseAmount += tmp_PS_Night.HouseAmount
            NightPriceTotal.WorkerAmount += tmp_PS_Night.WorkerAmount
            NightPriceTotal.Price += tmp_PS_Night.WorkerAmount + tmp_PS_Night.HouseAmount
            NightPrices.Add(tmp_PS_Night)

        Next

        Dim TotalBookingAmount As Double = 0
        Dim TotalSPAmount As Double = 0
        Dim TotalHouseAmount As Double = 0

        'For Each dr As DataRow In dtWorkerTotal.Rows
        '    TotalBookingAmount += Val(dr("Total"))
        '    TotalSPAmount += Val(dr("Sp_amount"))
        '    TotalHouseAmount += Val(dr("House_amount"))
        'Next

        'TotalBookingAmount *= NoOfClient
        'TotalSPAmount *= NoOfClient
        'TotalHouseAmount *= NoOfClient

        If MySettings.OtherSettings.DayPrice Then
            TotalBookingAmount = NightPriceTotal.WorkerAmount + NightPriceTotal.HouseAmount
            TotalSPAmount = NightPriceTotal.WorkerAmount
            TotalHouseAmount = NightPriceTotal.HouseAmount
        Else
            TotalBookingAmount = CurrentPriceTotal.WorkerAmount + CurrentPriceTotal.HouseAmount
            TotalSPAmount = CurrentPriceTotal.WorkerAmount
            TotalHouseAmount = CurrentPriceTotal.HouseAmount
        End If

        '//Show Payment Dailog 
        Dim PaymentR As clsPaymentDailog.BookingPaymentReturn = objPaymentDailogClass.BookingPayment(room, TotalBookingAmount, "CASH", TotalHouseAmount, TotalSPAmount, False, {0}, False, True, False, True, CurrentPriceTotal, NightPriceTotal, True, sp_names)

        Dim DisplayID As Integer = 0
        Try
            DisplayID = objBooking.GetDisplayID
            objBooking.SaveDisplayID(bookingId, DisplayID)
        Catch ex As Exception
        End Try


        '//Save Payment and Update the Bookings
        Dim PrevClientCount As Integer = objBooking.Selection(cls_Temp_tblBookings.SelectionType.All_View, "BookingId=" & bookingId.ToString).Rows(0).Item("TotalClient")
        objBooking.Update_field(Database_Table_code_class_tblBookings.FieldName.TotalClient, NoOfClient + PrevClientCount, "[BookingID]=" & bookingId)

        '//Create Memo
        Dim MemoNo As Integer = objDocketMemo.Insert("ADD CLIENT", Now, NoOfClient.ToString & " Clients", "")

        Dim SavedList As List(Of cls_tblLookUp.PriceSpec) = Nothing

        If PaymentR.ISDAY Then
            SavedList = CurrentPrices
        Else
            SavedList = NightPrices
        End If
        Dim UtilizedVoucher As Double = 0, OriginalShift As String = "", CurrentShift As String = "", GiftAmout As Double = 0, TOTAL_PAID As Double = 0


        TOTAL_PAID = PaymentR.TOTAL_AMOUNT_PAID
        Dim Cancel_fees As Double = 0
        For Each priceSpec As cls_tblLookUp.PriceSpec In SavedList

            If PaymentR.ISCONTRA Then

                Dim Total As Double = priceSpec.WorkerAmount
                Dim WorkerAmountPercent As Double = Total / TotalBookingAmount
                objPayment.Insert("ADD CLIENT", Total, bookingId, Now, PaymentR.CASH * WorkerAmountPercent, PaymentR.CARD * WorkerAmountPercent, PaymentR.SUR_P, PaymentR.SUR_AMT * WorkerAmountPercent, PaymentR.TIP * WorkerAmountPercent, _
                                    "PAID", PaymentR.PAYMENTMODE, priceSpec.WorkerAmount, 0, PaymentR.CASHOUT * WorkerAmountPercent, priceSpec.WorkerId, PaymentR.VOUCHER_AMT * WorkerAmountPercent, PaymentR.VOUCHERID, 0, MemoNo, PaymentR.UPGRADE * WorkerAmountPercent, "", PaymentR.GST * WorkerAmountPercent, LoginUserId, PaymentR.CAREFARE * WorkerAmountPercent, PaymentR.ESCORT_EXTENSION_FEES * WorkerAmountPercent, PaymentR.CardName, Cancel_fees, PaymentR.ESCORT_BOND_FEES, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

            Else
                Dim Total As Double = priceSpec.WorkerAmount + priceSpec.HouseAmount
                Dim WorkerAmountPercent As Double = Total / TotalBookingAmount
                objPayment.Insert("ADD CLIENT", Total, bookingId, Now, PaymentR.CASH * WorkerAmountPercent, PaymentR.CARD * WorkerAmountPercent, PaymentR.SUR_P, PaymentR.SUR_AMT * WorkerAmountPercent, PaymentR.TIP * WorkerAmountPercent, _
                                    "PAID", PaymentR.PAYMENTMODE, priceSpec.WorkerAmount, priceSpec.HouseAmount, PaymentR.CASHOUT * WorkerAmountPercent, priceSpec.WorkerId, PaymentR.VOUCHER_AMT * WorkerAmountPercent, PaymentR.VOUCHERID, 0, MemoNo, PaymentR.UPGRADE * WorkerAmountPercent, "", PaymentR.GST * WorkerAmountPercent, LoginUserId, PaymentR.CAREFARE * WorkerAmountPercent, PaymentR.ESCORT_EXTENSION_FEES * WorkerAmountPercent, PaymentR.CardName, Cancel_fees, PaymentR.ESCORT_BOND_FEES, DisplayID, UtilizedVoucher, OriginalShift, CurrentShift, GiftAmout, TOTAL_PAID)

            End If

        Next
        If isBookingActive Then
            PauseBooking_NoFresh(bookingId)
        End If

        clsDocketPrint.PrintDocketMemo(MemoNo)
        LoadingsBeforeReloader()
        MainReloader_OnTimerLeftCounter()

    End Sub

    Function IsBookingPaused(BookingId As Integer)
        Dim ret As Boolean = False
        Try
            ret = objBookingPause.Selection(cls_tblBookingPause.SelectionType.All, "BookingId= " & BookingId.ToString & " AND Status='PAUSED'").Rows.Count > 0
        Catch ex As Exception
        End Try
        Return ret
    End Function

    Sub PauseResumeBooking(BookingId As Integer)
        Dim dt As DataTable = Nothing
        Try
            dt = objBookingPause.Selection(cls_tblBookingPause.SelectionType.All, "bookingId= " & BookingId.ToString & " AND Status='PAUSED'")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    objBookingPause.Update(dr("ItemSl"), dr("BookingID"), dr("WorkerID"), dr("CreatedDate"), dr("PausedTime"), Now, "RESUMED", dr("Reason"))
                Next
            Else
                Throw New Exception("")
            End If
        Catch ex As Exception
            If MySettings.OtherSettings.PauseResumePassword <> "" Then
                Dim frmAdmin As New dlgAdminPass
                frmAdmin.Text = ""
                If frmAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If frmAdmin.TextBox1.Text = MySettings.OtherSettings.PauseResumePassword Then
                        objBookingPause.Insert(BookingId, 0, Now, Now, Now, "PAUSED", "")
                    Else
                        MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                    End If
                End If
            Else
                objBookingPause.Insert(BookingId, 0, Now, Now, Now, "PAUSED", "")
            End If

        End Try
        LoadingsBeforeReloader()
        MainReloader_OnTimerLeftCounter()
    End Sub

    Sub AdjustTimeLeftBooking(bookingId As Integer, TimeAdjust As Integer)
        Dim maxAdj As Integer = 3

        Dim tt As Boolean = True


        Dim dt As DataTable = Nothing
        Dim prevAdjust As Integer = 0
        Try
            dt = objBookingPause.Selection(cls_tblBookingPause.SelectionType.All, "bookingId= " & bookingId.ToString & " AND Status='ADJUST'")
            For Each dr As DataRow In dt.Rows
                prevAdjust += (CDate(dr("ResumeTime")) - CDate(dr("PausedTime"))).TotalMinutes
            Next
        Catch ex As Exception
        End Try
        If prevAdjust > maxAdj And TimeAdjust > 0 Then
            MsgBox("Cannot adjust anymore. You have already adjusted more than " & maxAdj & " mins.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If prevAdjust < -maxAdj And TimeAdjust < 0 Then
            MsgBox("Cannot adjust anymore. You have already adjusted more than " & maxAdj & " mins.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        TimeAdjust += prevAdjust
        If MySettings.OtherSettings.TimeAdjustPassword <> "" Then
            If TimeAdjust > maxAdj Or TimeAdjust < -maxAdj Then
                Dim frm As New dlgAdminPass
                frm.Text = "Enter admin password"
reddd:
                tt = False
                frm.TextBox1.Text = ""
                frm.TextBox1.Focus()
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If frm.TextBox1.Text <> MySettings.OtherSettings.TimeAdjustPassword Then
                        MsgBox("Wrong password", MsgBoxStyle.Information, "Info")
                        GoTo reddd
                    Else
                        tt = True
                    End If
                End If
            End If
        End If

        If tt Then
            Try
                objBookingPause.Insert(bookingId, 0, Now, Now, Now.AddMinutes(TimeAdjust), "ADJUST", "")
            Catch ex As Exception
            End Try
            LoadingsBeforeReloader()
            MainReloader_OnTimerLeftCounter()
        End If
    End Sub

    Sub PauseBooking_NoFresh(bookingId As Integer)
        Dim dt As DataTable = Nothing
        Try
            dt = objBookingPause.Selection(cls_tblBookingPause.SelectionType.All, "bookingId= " & bookingId.ToString & " AND Status='PAUSED'")
            If dt.Rows.Count = 0 Then
                Throw New Exception("")
            End If
        Catch ex As Exception
            objBookingPause.Insert(bookingId, 0, Now, Now, Now, "PAUSED", "")
        End Try
    End Sub



    Sub ReadLoud(RowIndex As Integer) 'Reads out all the booking with Time remaining and room alloted.
        Dim dgRow As DataGridViewRow = dgActiveBooking.Rows(RowIndex)
        Dim isSpeaking As Boolean = False
        Dim BookingID As String = dgRow.Cells(9).Value
        Dim roomName As String = dgRow.Cells(2).Value
        Dim duration As Integer = Val(dgRow.Cells(3).Value)
        Dim newdur As Integer = 0
        Dim workerName As String = ""
        For Each s As String In dgRow.Cells(1).Value.ToString.Split(vbNewLine)
            If s.Trim <> "" Then
                Try
                    If workerName <> "" Then
                        workerName += ","
                    End If
                    workerName += " " & s.Split("(")(0).Trim
                Catch ex As Exception
                End Try
            End If
        Next
        Try
            workerName = workerName.Insert(workerName.LastIndexOf(","), " and ")
            workerName = workerName.Remove(workerName.LastIndexOf(","), 1)
        Catch ex As Exception
        End Try
        workerName = workerName.Trim
        Try
            isSpeaking = mySpeaker.State = Speech.Synthesis.SynthesizerState.Speaking
        Catch ex As Exception
        End Try
        newdur = Val(dgRow.Cells(4).Value)
        If Not isSpeaking Then
            If isSoundOn Then
                If newdur > 0 Then
                    If Not BookingWarnings.Contains(New BookingWorking(BookingID, newdur.ToString & "MIN" & duration.ToString)) Then
                        mySpeaker.SpeakAsync("ATTENTION : " & newdur.ToString & " minutes service left for " & workerName & IIf(roomName <> "ESCORT", " in room " & roomName & ".", " in Escort Booking."))
                    End If
                ElseIf newdur <= 0 Then
                    If Not BookingWarnings.Contains(New BookingWorking(BookingID, "0MIN" & duration.ToString)) Then
                        mySpeaker.SpeakAsync("ATTENTION : " & workerName & "'s " & IIf(roomName <> "ESCORT", "booking in room " & roomName & "", "Escort booking") & " has Expired.")
                    End If
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Booking Edit Menu
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub EditBooking(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dgr As DataGridViewRow = dgActiveBooking.Rows(e.RowIndex)
        Dim BookingID As String = dgr.Cells(9).Value
        Dim DateT As Date = dgr.Cells(5).Value.ToString.Split(vbNewLine)(0)
        Dim room As String = dgr.Cells(2).Value
        Dim Service As String = dgr.Cells(3).Value
        Dim ServiceLeft As Integer = Val(dgr.Cells(4).Value)
        Dim NoOfClient As Integer = Val(dgr.Cells(10).Value)
        Dim frmDlgEdit As New dlgEditBooking
        Dim WorkerIDs As String = dgr.Cells(0).Value
        Dim SPs As String = dgr.Cells(1).Value
        Dim ActiveSLs As String = dgr.Cells(6).Value
        Dim wCount As Integer = WorkerIDs.Split(",").Length
        frmDlgEdit.btnRemoveWorker.Enabled = wCount > 1
        frmDlgEdit.btnChangeWorker.Enabled = Not (wCount > 1)
        frmDlgEdit.lblBookingInfo.Text = SPs
        frmDlgEdit.Room = room
        frmDlgEdit.lblLeftTime.Text = dgr.Cells(4).Value & "Left"
        frmDlgEdit.Room = room

        ' frmDlgEdit.interval = 0
        'Dim isBookingActive As Boolean = {"EDIT", "RESUME"}.Contains(dgr.Cells(8).Value)
        Dim isBookingActive As Boolean = {"RESET", "RESUME"}.Contains(dgr.Cells(8).Value)


        '// Check whether the Booking is Paused or not
        If IsBookingPaused(BookingID) Then
            frmDlgEdit.btnPauseStart.Text = "RESUME BOOKING"
        End If
        frmDlgEdit.btnPauseStart.Enabled = isBookingActive
        frmDlgEdit.lblPayment.Text = "0.00" & vbNewLine & "0.00" & vbNewLine & "0.00"
        Dim TotalBookingAmount_ex_sur As Double = 0

        Try
            If isBookingActive OrElse objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId=" & BookingID).Rows.Count > 1 Then
                frmDlgEdit.btnEditBooking.Enabled = False
            End If
        Catch ex As Exception
        End Try



        Try
            Dim dtBPayment As DataTable = objPayment.Selection(cls_Temp_tblBookingPayments.SelectionType.All, "BookingId =" & BookingID)
            Dim cash As Double = frmSummary.TotalField(dtBPayment, "Cash")
            Dim card As Double = frmSummary.TotalField(dtBPayment, "Card") + frmSummary.TotalField(dtBPayment, "Surcharge_Amt")
            Dim vch As Double = frmSummary.TotalField(dtBPayment, "VoucherAmount")
            frmDlgEdit.lblPayment.Text = cash.ToString("0.00") & vbNewLine & card.ToString("0.00") & vbNewLine & vch.ToString("0.00")
            TotalBookingAmount_ex_sur = cash + card + vch
        Catch ex As Exception
        End Try

        If frmDlgEdit.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Try
            Select Case frmDlgEdit.DialogResultEx

                Case dlgEditBooking.BookingEditResult.EXTEND
                    '// Extend Booking
                    ExtendBooking(BookingID, room, NoOfClient)

                Case dlgEditBooking.BookingEditResult.ADD_SP 'Add SP
                    '// Add SP to Booking
                    AddSP(BookingID, room, Service, isBookingActive)

                Case dlgEditBooking.BookingEditResult.CLEAR 'CLEAR/RESET
                    '// Clear/Reset Booking. I.e When a Booking has finished. This function is used to Remove it from the list.
                    ResetBooking(BookingID)

                Case dlgEditBooking.BookingEditResult.REMOVE_SP '
                    '// Remove additional SP
                    RemoveSP(BookingID, room, SPs, WorkerIDs)

                Case dlgEditBooking.BookingEditResult.SUSPEND 'SUSPEND
                    '// Set Status of Booking as SUSPENDED
                    SuspendBooking(BookingID, DateT, Service, room)

                Case dlgEditBooking.BookingEditResult.CHANGE_ROOM
                    '// Change the Room of the Booking. Need an Empty room to do so.
                    ChangeBookingRoom(room, WorkerIDs, BookingID)

                Case dlgEditBooking.BookingEditResult.CHANGE_SP
                    '// Replace a SP.
                    ChangeWorker(BookingID, room, WorkerIDs, SPs)

                Case dlgEditBooking.BookingEditResult.CANCEL
                    '// Booking cancellation.
                    CancelBooking(BookingID, room, DateT, Service)

                Case dlgEditBooking.BookingEditResult.CANCEL_ONERROR
                    '// Booking cancellation.
                    CancelBookingUserError(BookingID, room, DateT, Service)

                Case dlgEditBooking.BookingEditResult.ADD_CLIENT
                    '// Booking cancellation.
                    'AddClient_ChargedAsPerPrevClient(BookingID, room)
                    AddClient_ChargedNormal(BookingID, room, isBookingActive)

                Case dlgEditBooking.BookingEditResult.PAUSE_RESUME
                    '// Booking cancellation.
                    PauseResumeBooking(BookingID)

                Case dlgEditBooking.BookingEditResult.SWAP_ROOM
                    '// Interchange Room
                    SwapBookingRoom(room, WorkerIDs, BookingID)

                Case dlgEditBooking.BookingEditResult.ADJUST_TIME
                    '// Booking Time Left Adjustment.
                    AdjustTimeLeftBooking(BookingID, frmDlgEdit.adjusttime)

                Case dlgEditBooking.BookingEditResult.SWAP_SP
                    '// Interchange SP
                    SwapSP(BookingID, room, WorkerIDs, SPs)

                Case dlgEditBooking.BookingEditResult.READ
                    '// Read loud the Active booking
                    ReadLoud(e.RowIndex)

                Case dlgEditBooking.BookingEditResult.EDITBOOKING
                    '// Read loud the Active booking
                    RedoBookingNormal(BookingID)

                Case Else
                    MsgBox("Work on progress", MsgBoxStyle.Exclamation, "Info")

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub


    Private Sub dgActiveBooking_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgActiveBooking.CellDoubleClick
        If e.RowIndex >= 0 Then
            EditBooking(e)
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        If MsgBox("WARNING !!! .." & vbNewLine & " CANNOT REDO", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Warning") = MsgBoxResult.No Then
            Exit Sub
        End If
        sender.enabled = False
        objDocketMemo.UndoReceipt(sender.tag)

    End Sub

    Private Sub RePrintMemosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RePrintMemosToolStripMenuItem.Click
        frmPrintPrevious.ShowDialog()
    End Sub

    Private Sub SuspendedBookingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SuspendedBookingsToolStripMenuItem.Click
        frmSuspendedBooking.ShowDialog()
    End Sub


    Private Sub dgAvailableWorker2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAvailableWorker2.VisibleChanged
        Try
            If dgAvailableWorker2.Visible Then
                TableLayoutPanel12.ColumnStyles(0).Width = 388
            Else
                TableLayoutPanel12.ColumnStyles(0).Width = 200
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandard.Click, btnDeluxe.Click
        Dim ppp As cls_tblLookUp.PriceSpec
        Try
            If selectedTime > 0 Then
                ppp = objLookUp.GetPrice(1, 1, selectedTime, sender.text, selectedRoom)
            End If
        Catch ex As Exception
            MsgBox("Please set lookup database for " & sender.text & " Service " & sender.text, MsgBoxStyle.Information, "Info")
            Exit Sub
        End Try
        For Each c As Button In tlpServiceType.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
        sender.backcolor = ActiveButton
        serviceType = sender.text
    End Sub

    Public Sub SetRainbow()
        If isRainBow Then
            btnStartAvailable.FlatStyle = FlatStyle.Flat
            btnRemoveAvailable.FlatStyle = FlatStyle.Flat
            btnPrivate.FlatStyle = FlatStyle.Flat
            btnPRIVATEINTRO.FlatStyle = FlatStyle.Flat
            btnLounge.FlatStyle = FlatStyle.Flat
            btnCash.FlatStyle = FlatStyle.Flat
            btnCard.FlatStyle = FlatStyle.Flat
            btnCardCash.FlatStyle = FlatStyle.Flat
            btnPrint.FlatStyle = FlatStyle.Flat
            btnRefreshNew.FlatStyle = FlatStyle.Flat
            btnRoom01.FlatStyle = FlatStyle.Flat
            btnRoom02.FlatStyle = FlatStyle.Flat
            btnRoom03.FlatStyle = FlatStyle.Flat
            btnRoom04.FlatStyle = FlatStyle.Flat
            btnRoom05.FlatStyle = FlatStyle.Flat
            btnRoom06.FlatStyle = FlatStyle.Flat
            btnRoom07.FlatStyle = FlatStyle.Flat
            btnRoom08.FlatStyle = FlatStyle.Flat
            btnRoom09.FlatStyle = FlatStyle.Flat
            btnRoom10.FlatStyle = FlatStyle.Flat
            btnRoom11.FlatStyle = FlatStyle.Flat
            btnRoom12.FlatStyle = FlatStyle.Flat
            btnRoom13.FlatStyle = FlatStyle.Flat
            btnRoom14.FlatStyle = FlatStyle.Flat
            btnRoom15.FlatStyle = FlatStyle.Flat
            btnEscort.FlatStyle = FlatStyle.Flat
            btnHOLD.FlatStyle = FlatStyle.Flat
            btn30Min.FlatStyle = FlatStyle.Flat
            btn60Min.FlatStyle = FlatStyle.Flat
            btn45Min.FlatStyle = FlatStyle.Flat
            btn90Min.FlatStyle = FlatStyle.Flat
            btn120Min.FlatStyle = FlatStyle.Flat
            btn150Mins.FlatStyle = FlatStyle.Flat
            btn180Mins.FlatStyle = FlatStyle.Flat
            btn210Mins.FlatStyle = FlatStyle.Flat
            btnOtherTime.FlatStyle = FlatStyle.Flat
            btn20Min.FlatStyle = FlatStyle.Flat
            btnCustomMin.FlatStyle = FlatStyle.Flat
            btnStartQueue.FlatStyle = FlatStyle.Flat
            btnRemoveQueue.FlatStyle = FlatStyle.Flat
            btnStartAvailable.FlatStyle = FlatStyle.Flat
            btnClearRoom.FlatStyle = FlatStyle.Flat
            btnClearFinishWorker.FlatStyle = FlatStyle.Flat
            btnShowPhone.FlatStyle = FlatStyle.Flat
            btnStartCustomBooking.FlatStyle = FlatStyle.Flat
        Else
            btnStartAvailable.FlatStyle = FlatStyle.Standard
            btnRemoveAvailable.FlatStyle = FlatStyle.Standard
            btnPrivate.FlatStyle = FlatStyle.Standard
            btnPRIVATEINTRO.FlatStyle = FlatStyle.Standard
            btnLounge.FlatStyle = FlatStyle.Standard
            btnCash.FlatStyle = FlatStyle.Standard
            btnCard.FlatStyle = FlatStyle.Standard
            btnCardCash.FlatStyle = FlatStyle.Standard
            btnPrint.FlatStyle = FlatStyle.Standard
            btnRefreshNew.FlatStyle = FlatStyle.Standard
            btnRoom01.FlatStyle = FlatStyle.Standard
            btnRoom02.FlatStyle = FlatStyle.Standard
            btnRoom03.FlatStyle = FlatStyle.Standard
            btnRoom04.FlatStyle = FlatStyle.Standard
            btnRoom05.FlatStyle = FlatStyle.Standard
            btnRoom06.FlatStyle = FlatStyle.Standard
            btnRoom07.FlatStyle = FlatStyle.Standard
            btnRoom08.FlatStyle = FlatStyle.Standard
            btnRoom09.FlatStyle = FlatStyle.Standard
            btnRoom10.FlatStyle = FlatStyle.Standard
            btnRoom11.FlatStyle = FlatStyle.Standard
            btnRoom12.FlatStyle = FlatStyle.Standard
            btnRoom13.FlatStyle = FlatStyle.Standard
            btnRoom14.FlatStyle = FlatStyle.Standard
            btnRoom15.FlatStyle = FlatStyle.Standard
            btnEscort.FlatStyle = FlatStyle.Standard
            btnEscort.UseVisualStyleBackColor = True
            btnHOLD.FlatStyle = FlatStyle.Standard
            btnHOLD.UseVisualStyleBackColor = True
            btn30Min.FlatStyle = FlatStyle.Standard
            btn60Min.FlatStyle = FlatStyle.Standard
            btn45Min.FlatStyle = FlatStyle.Standard
            btn90Min.FlatStyle = FlatStyle.Standard
            btn120Min.FlatStyle = FlatStyle.Standard
            btn150Mins.FlatStyle = FlatStyle.Standard
            btn180Mins.FlatStyle = FlatStyle.Standard
            btn210Mins.FlatStyle = FlatStyle.Standard
            btnOtherTime.FlatStyle = FlatStyle.Standard
            btn20Min.FlatStyle = FlatStyle.Standard
            btnCustomMin.FlatStyle = FlatStyle.Standard
            btnStartQueue.FlatStyle = FlatStyle.Standard
            btnRemoveQueue.FlatStyle = FlatStyle.Standard
            btnStartAvailable.FlatStyle = FlatStyle.Standard
            btnClearRoom.FlatStyle = FlatStyle.Standard
            btnClearFinishWorker.FlatStyle = FlatStyle.Standard
            btnShowPhone.FlatStyle = FlatStyle.Standard
            btnStartCustomBooking.FlatStyle = FlatStyle.Standard
        End If
        ParentSetRainbow()

    End Sub

    Sub changeTheme()

        dgActiveBooking.BackgroundColor = mdlColors.formBackColor
        dgActiveBooking.ForeColor = mdlColors.formForeColor
        dgAvailableWorker1.BackgroundColor = mdlColors.formBackColor
        dgAvailableWorker1.ForeColor = mdlColors.formForeColor
        dgAvailableWorker2.BackgroundColor = mdlColors.formBackColor
        dgAvailableWorker2.ForeColor = mdlColors.formForeColor
        dgPrebookingNew.BackgroundColor = mdlColors.formBackColor
        dgPrebookingNew.ForeColor = mdlColors.formForeColor
        dgQueueWorkers.BackgroundColor = mdlColors.formBackColor
        dgQueueWorkers.ForeColor = mdlColors.formForeColor

    End Sub
    Public Sub SetButtonVisible()
        Only9Buttons(isSite2ButtonsVisible)
        Loadings()
        frmPreBookingHome.refershBooking()
    End Sub
    Sub Only9Buttons(IsVisible As Boolean)
        If IsVisible Then
            tlpRoom.ColumnStyles(2).Width = 33.34
            btnRoom10.Visible = True
        Else
            tlpRoom.ColumnStyles(2).Width = 0
            btnRoom10.Visible = False
        End If
    End Sub
    Sub Only6Buttons(IsVisible As Boolean)
        If IsVisible Then
            tlpRoom.RowStyles(3).Height = 20
            tlpRoom.RowStyles(4).Height = 20
            tlpRoom.ColumnStyles(2).Width = 33.34
            btnRoom10.Visible = True
            btnRoom09.Visible = True
            btnRoom04.Visible = True
            btnRoom05.Visible = True
        Else
            tlpRoom.RowStyles(3).Height = 0
            tlpRoom.RowStyles(4).Height = 0
            tlpRoom.ColumnStyles(2).Width = 0
            btnRoom10.Visible = False
            btnRoom09.Visible = False
            btnRoom04.Visible = False
            btnRoom05.Visible = False
        End If
    End Sub
    Private Sub SummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem.Click
        frmSummary.Show()
    End Sub

    Private Sub PreviousBookingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviousBookingsToolStripMenuItem.Click
        frmPreviousBookings.Show()
    End Sub

    Private Sub dgAvailableWorker2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgAvailableWorker1.KeyPress, dgAvailableWorker2.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            ' Dim AvailableWorkerID_ind As Integer = -1
            For Each dr As DataGridViewRow In dgAvailableWorker1.Rows
                If dr.Cells(1).Value.ToString.Replace("*", "").Trim.ToUpper.StartsWith(e.KeyChar.ToString.ToUpper) Then
                    lnkServiceProvider.Text = dr.Cells(1).Value
                    AvailableWorkerID = dr.Cells(0).Value
                    For Each dgr As DataGridViewRow In dgAvailableWorker1.Rows
                        dgr.Cells(2).Style.BackColor = Color.White
                        dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                    Next
                    For Each dgr As DataGridViewRow In dgAvailableWorker2.Rows
                        dgr.Cells(2).Style.BackColor = Color.White
                        dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                    Next
                    dr.Cells(2).Style.BackColor = Color.Black
                    dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold + FontStyle.Italic + FontStyle.Underline, GraphicsUnit.Point)
                    Exit Sub
                End If
            Next
            For Each dr As DataGridViewRow In dgAvailableWorker2.Rows
                If dr.Cells(1).Value.ToString.Replace("*", "").Trim.ToUpper.StartsWith(e.KeyChar.ToString.ToUpper) Then
                    lnkServiceProvider.Text = dr.Cells(1).Value
                    AvailableWorkerID = dr.Cells(0).Value
                    For Each dgr As DataGridViewRow In dgAvailableWorker1.Rows
                        dgr.Cells(2).Style.BackColor = Color.White
                        dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                    Next
                    For Each dgr As DataGridViewRow In dgAvailableWorker2.Rows
                        dgr.Cells(2).Style.BackColor = Color.White
                        dgr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14)
                    Next
                    dr.Cells(2).Style.BackColor = Color.Black
                    dr.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold + FontStyle.Italic + FontStyle.Underline, GraphicsUnit.Point)
                    dgAvailableWorker2.FirstDisplayedScrollingRowIndex = dr.Index
                    Exit Sub
                End If
            Next


        End If

    End Sub

    Private Sub dgAvailableWorker2_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAvailableWorker1.CellDoubleClick, dgAvailableWorker2.CellDoubleClick
        'If sender.SelectedRows.Count > 0 Then
        If sender.rows(e.RowIndex).Cells(1).Value.ToString.Contains("+") Then
            Dim frm As New frmShowFavs
            frm.WorkerId = sender.Rows(e.RowIndex).Cells(0).Value
            frm.ShowDialog()
        End If
        ' End If
    End Sub

    Private Sub ShowDCToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowDCToolStripMenuItem.Click

        
        Dim dr1 As DataGridView = CType(ContextMenuStrip2.SourceControl, DataGridView)
        Try

            Dim p As Point = dr1.PointToClient(ContextMenuStrip2.Location)
            Dim tt As DataGridView.HitTestInfo = dr1.HitTest(p.X, p.Y)
            Dim dr As DataGridViewRow = dr1.Rows(tt.RowIndex)
            Dim frm As New frmShowSpDC
            frm.selectedWorkerID = dr.Cells(0).Value
            frm.Text = "DC - " & dr.Cells(1).Value
            frm.ShowDialog()
            ' MsgBox(dr.Cells(1).Value)


        Catch ex As Exception
        End Try
        '  Dim dr As DataGridViewRow = CType(ContextMenuStrip2.Parent, DataGridViewRow)
        '  Dim dr As DataGridViewRow = CType(ContextMenuStrip2.Parent, DataGridViewRow)


    End Sub



 
End Class

