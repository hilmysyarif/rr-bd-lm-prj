Public Class frmAdmin

    Dim objService As New cls_tblService
    Dim objRoom As New cls_Temp_tblRoom
    Dim objReports As New cls_Reports
    Dim objPremiumServices As New cls_Temp_tblPremiumServices
    Dim dtServices As DataTable

    Dim CustomeSL As Integer = 0


    Sub LoadServices()

        dtServices = New DataTable
        dtServices.Columns.Add("Text", GetType(String))
        dtServices.Columns.Add("Value", GetType(Integer))

        dtServices.Rows.Add("--Select--", 0)
        dtServices.Rows.Add("5 Mins", 5)
        dtServices.Rows.Add("10 Mins", 10)
        dtServices.Rows.Add("15 Mins", 15)
        dtServices.Rows.Add("20 Mins", 20)
        dtServices.Rows.Add("30 Mins", 30)
        dtServices.Rows.Add("45 Mins", 45)
        dtServices.Rows.Add("60 Mins", 60)
        dtServices.Rows.Add("1.5 Hrs", 90)
        dtServices.Rows.Add("2 Hrs", 120)
        dtServices.Rows.Add("2.5 Hrs", 150)
        dtServices.Rows.Add("3 Hrs", 180)
        dtServices.Rows.Add("3.5 Hrs", 210)
        dtServices.Rows.Add("4 Hrs", 240)
        dtServices.Rows.Add("5 Hrs", 300)

        dtServices.Rows.Add("6 Hrs", 360)
        'dtServices.Rows.Add("7 Hrs", 420)
        'dtServices.Rows.Add("8 Hrs", 480)
        'dtServices.Rows.Add("9 Hrs", 540)
        'dtServices.Rows.Add("10 Hrs", 600)
        ''dtServices.Rows.Add("11 Hrs", 660)
        'dtServices.Rows.Add("12 Hrs", 720)
        'dtServices.Rows.Add("24 Hrs", 1440)
        'dtServices.Rows.Add("36 Hrs", 2160)


        cmbServiceCustom.DataSource = dtServices
        cmbServiceCustom.DisplayMember = "Text"
        cmbServiceCustom.ValueMember = "Value"
        cmbServiceCustom.Text = "--Select--"


    End Sub



    Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnClearBookingTables.Visible = DeveloperPC()
        'TopMost = IsAllTopMostForm
        TabPage4.Dispose()
        dgRoom.AutoGenerateColumns = False
        dgPrice.AutoGenerateColumns = False
        dgRoom.DataSource = objRoom.Selection(cls_Temp_tblRoom.SelectionType.All, " 1=1 Order By Sl")
        For Each dgr As DataGridViewRow In dgRoom.Rows
            Try
                If dgr.Cells(0).Value = 16 Then
                    dgr.Cells(1).ReadOnly = True
                    dgr.Cells(3).ReadOnly = True
                End If
            Catch ex As Exception
            End Try
        Next
        dgPrice.DataSource = objService.Selection(cls_tblService.SelectionType.ALL)

        Try
            For Each p In Printing.PrinterSettings.InstalledPrinters
                cmbMemoPrinter.Items.Add(p.ToString)
            Next
        Catch ex As Exception
        End Try

        Try
            For Each p In Printing.PrinterSettings.InstalledPrinters
                cmbReportPrinter.Items.Add(p.ToString)
            Next
        Catch ex As Exception
        End Try

        btnSpeakON.Enabled = Not isSoundOn
        btnSpeakOFF.Enabled = isSoundOn

        cmbMemoPrinter.Text = MyLocalSettings.ReceiptPrinter
        cmbReportPrinter.Text = MyLocalSettings.ReportPrinter
        txtComPort.Text = MyLocalSettings.ReportPrinter

        txtCompany.Text = MySettings.CompanyName
        txtCompanyAdd.Text = MySettings.CompanyAddress
        txtPhone.Text = MySettings.CompanyPhone

        txtFooter1.Text = MySettings.MemoFooter1
        txtFooter2.Text = MySettings.MemoFooter2
        txtFooter3.Text = MySettings.MemoFooter3

        txtSP_Percentage.Text = MySettings.SP_Percentage.ToString("0.00")
        txtSP_Percentage_night.Text = MySettings.SP_Percentage_Night.ToString("0.00")

        txtDay_start.Text = MySettings.Day_Start
        txtDay_End.Text = MySettings.Day_End

        txtEveingShiftStartTime.Text = MySettings.Eve_Start
        txtEveningShiftEndTime.Text = MySettings.Eve_End

        txtNightStop.Text = txtDay_start.Text
        chk3Shift.Checked = MySettings.Shifts_3_enabled

        If chk3Shift.Checked Then
            txtNightStart.Text = txtEveningShiftEndTime.Text
        Else
            txtNightStart.Text = txtDay_End.Text
        End If

        chkSpecial.Checked = MySettings.SpecialServiceEnabled
        chkContra.Checked = MySettings.Contra
        txtContraPass.Text = MySettings.Contra_Password
        chkDayPrice.Checked = MySettings.OtherSettings.DayPrice
        txtDayPricePass.Text = MySettings.OtherSettings.DayPricePassword
        chkSameEscortPrice.Checked = MySettings.OtherSettings.SameEscortPrice
        chkEscortServices.Checked = MySettings.OtherSettings.EscortService
        cmbRoomType.Text = MySettings.OtherSettings.RoomType
        chkMembership.Checked = MySettings.OtherSettings.Membership

        txtCancellationPassword.Text = MySettings.OtherSettings.CancellationPassword

        dgCustom.Columns(10).DisplayIndex = 8
        dgCustom.Columns(11).DisplayIndex = 9
        LoadLockers()
        LoadCustomBooking()

        LoadServices()
        Try
            cmbServiceType.SelectedIndex = 0
        Catch ex As Exception
        End Try
        cmbCustomType.Text = "DAY"

        If MySettings.Shifts_3_enabled Then
            cmbCustomType.Items.Add("EVENING")
        End If
        If MySettings.SpecialServiceEnabled Then
            cmbServiceType.Items.Add("DELUX")
        End If

        Try
            Dim dt As DataTable = objPremiumServices.Selection()
            For Each dr As DataRow In dt.Rows
                CType(TabPage12.Controls("txtpp" & dr("weekday").ToString), NumericUpDown).Value = dr("Sp")
                CType(TabPage12.Controls("txtpp" & dr("weekday").ToString & dr("weekday").ToString), NumericUpDown).Value = dr("House")
                CType(TabPage12.Controls("txtpp" & dr("weekday").ToString & dr("weekday").ToString & dr("weekday").ToString), NumericUpDown).Value = dr("Servicecharge")
            Next
        Catch ex As Exception
        End Try

        Try
            btnRollBack.Enabled = My.Application.Info.Version > New Version(MyLocalSettings.LastVersion)
        Catch ex As Exception
        End Try

        txtCancelFee1.Maximum = 9999999
        txtCancelFee2.Maximum = 9999999
        txtCancelFee1.Minimum = 0
        txtCancelFee2.Minimum = 0
        txtCancelFee1.Value = MySettings.OtherSettings.CancelFees
        txtCancelFee2.Value = MySettings.OtherSettings.CancelFeesAfter1Hr
        txtMemBershipFees.Value = MySettings.OtherSettings.MembershipFee

        txtEFT.Value = MySettings.OtherSettings.EFT_P
        txtVISA.Value = MySettings.OtherSettings.VISA_P
        txtAMEX.Value = MySettings.OtherSettings.AMEX_P
        txtMASTERCARD.Value = MySettings.OtherSettings.MASTERCARD_P
        txtOthersCard.Value = MySettings.OtherSettings.OTHRCARD_P
        chkEscortShiftPrice.Checked = MySettings.OtherSettings.MultipleEscortPrice
        txtEscortBondFees.Value = MySettings.OtherSettings.BOND_FEES


        NumericUpDown1.Value = MySettings.OtherSettings.DoorLoungeDay
        NumericUpDown2.Value = MySettings.OtherSettings.DoorLoungeNight
        NumericUpDown4.Value = MySettings.OtherSettings.DoorPrivateDay
        NumericUpDown3.Value = MySettings.OtherSettings.DoorPrivateNight
        NumericUpDown5.Value = MySettings.OtherSettings.DoorPrivateIntroDay
        NumericUpDown6.Value = MySettings.OtherSettings.DoorPrivateIntroNight

        If MySettings.OtherSettings.EscortService Then
            chkEscort.Visible = Not MySettings.OtherSettings.SameEscortPrice
            chkEscort.Checked = Not MySettings.OtherSettings.SameEscortPrice
        Else
            chkEscort.Visible = False
            chkEscort.Checked = False
        End If

        '//LAST TAB
        txtPauseResumePassword.Text = MySettings.OtherSettings.PauseResumePassword
        txtAdjustpass.Text = MySettings.OtherSettings.TimeAdjustPassword

    End Sub
    Sub LoadLockers()
        Dim objLocker As New cls_Temp_tblLocker
        dgLocker.AutoGenerateColumns = False
        dgLocker.DataSource = objLocker.Selection(cls_Temp_tblLocker.SelectionType.All)
    End Sub

    Sub LoadCustomBooking()
        Try
            Dim objLookUp As New cls_tblLookUp
            dgCustom.AutoGenerateColumns = False
            dgCustom.DataSource = objLookUp.Selection(cls_tblLookUp.SelectionType.ALL_INHRS, IIf(cmbServiceCustom.SelectedIndex = 0, "", "Service=" & Val(cmbServiceCustom.SelectedValue).ToString & " AND ") & " [Type]='" & cmbCustomType.Text & "' AND [ServiceType]='" & cmbServiceType.Text & "' and [Room]='" & IIf(chkEscort.Checked, "ESCORT", "ROOM") & "' Order By a.[Service],[Type],[ServiceType],[Worker],[Client]")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim d1 As Date = Now
            d1 = CDate(txtDay_start.Text)
            d1 = CDate(txtDay_End.Text)

            d1 = CDate(txtEveingShiftStartTime.Text)
            d1 = CDate(txtEveningShiftEndTime.Text)

            d1 = CDate(txtNightStart.Text)
            d1 = CDate(txtNightStop.Text)
        Catch ex As Exception
            MsgBox("Enter proper shift times", MsgBoxStyle.Information, "Info")
            Exit Sub
        End Try


        MySettings.CompanyName = txtCompany.Text
        MySettings.CompanyAddress = txtCompanyAdd.Text
        MySettings.CompanyPhone = txtPhone.Text
        MySettings.MemoFooter1 = txtFooter1.Text
        MySettings.MemoFooter2 = txtFooter2.Text
        MySettings.MemoFooter3 = txtFooter3.Text
        MySettings.SP_Percentage = Val(txtSP_Percentage.Text)
        MySettings.SP_Percentage_Night = Val(txtSP_Percentage_night.Text)
        MySettings.Day_Start = txtDay_start.Text
        MySettings.Day_End = txtDay_End.Text
        MySettings.Eve_Start = txtEveingShiftStartTime.Text
        MySettings.Eve_End = txtEveningShiftEndTime.Text


        MySettings.Shifts_3_enabled = chk3Shift.Checked
        MySettings.SpecialServiceEnabled = chkSpecial.Checked

        Dim dOT As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings
        dOT.MultipleEscortPrice = chkEscortShiftPrice.Checked
        dOT.EscortService = chkEscortServices.Checked
        dOT.SameEscortPrice = chkSameEscortPrice.Checked
        MySettings.OtherSettings = dOT

        If MsgBox("Saved. Please restart the application for the changes to take effect.", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Application.Restart()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MyLocalSettings.ReceiptPrinter = cmbMemoPrinter.Text
        MyLocalSettings.ReportPrinter = cmbReportPrinter.Text
        MyLocalSettings.CashComPort = txtComPort.Text
        SaveLocalSettings()

        MsgBox("Saved.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Try

            If MySettings.Password = txtOldPassword.Text Then

                If txtNewPassword.Text.Trim = "" Then
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                If txtNewPassword.Text.Trim.Length < 6 Then
                    MsgBox("Minimum 6 Characters", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                If txtNewPassword.Text.Trim.ToLower = "password" Then
                    MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                If txtPasswordHint.Text.Trim.ToLower.Contains(txtNewPassword.Text.Trim.ToLower) Then
                    MsgBox("Hint should not contain the password", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                If txtNewPassword.Text <> txtConfirmPassword.Text Then
                    MsgBox("Please enter correct password", MsgBoxStyle.Information, "Info")
                Else
                    MySettings.Password = txtNewPassword.Text
                    txtNewPassword.Clear()
                    txtOldPassword.Clear()
                    txtConfirmPassword.Clear()
                    MsgBox("Password Changed", MsgBoxStyle.Information, "Info")
                End If
            Else
                MsgBox("Please enter correct password", MsgBoxStyle.Information, "Info")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub btnSavePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePrice.Click

        For Each drg As DataGridViewRow In dgPrice.Rows
            objService.Update(drg.Cells(0).Value, drg.Cells(2).Value, drg.Cells(3).Value)
        Next
        MsgBox("Saved", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Close()

    End Sub

    Private Sub btnSaveLocker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLocker.Click

        Try
            Dim objLocker As New cls_Temp_tblLocker
            If btnSaveLocker.Text = "Save" Then
                objLocker.Insert(txtLockerNumber.Text, txtLockerNAme.Text, txtLockerPrice.Text, txtLockerDes.Text, Now, Now, LoginUserId)
                LoadLockers()
                clearLocaker()
            Else
                objLocker.Update2(txtLockerNumber.Text, txtLockerNAme.Text, txtLockerPrice.Text, txtLockerDes.Text)
                LoadLockers()
                clearLocaker()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Sub clearLocaker()

        txtLockerNumber.Text = ""
        txtLockerNAme.Text = ""
        txtLockerPrice.Text = ""
        txtLockerDes.Text = ""
        btnSaveLocker.Text = "Save"
        txtLockerNumber.ReadOnly = False

    End Sub

    Private Sub dgLocker_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLocker.CellClick
        Try
            txtLockerNumber.ReadOnly = False
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 4 Then
                    txtLockerNumber.Text = TryCast(dgLocker.Rows(e.RowIndex).Cells(0).Value, String)
                    txtLockerNAme.Text = TryCast(dgLocker.Rows(e.RowIndex).Cells(1).Value, String)
                    txtLockerPrice.Text = Val(dgLocker.Rows(e.RowIndex).Cells(2).Value)
                    txtLockerDes.Text = TryCast(dgLocker.Rows(e.RowIndex).Cells(3).Value, String)
                    btnSaveLocker.Text = "Update"
                    txtLockerNumber.ReadOnly = True
                ElseIf e.ColumnIndex = 5 Then
                    Dim objLocker As New cls_Temp_tblLocker
                    objLocker.Delete_By_RowID(dgLocker.Rows(e.RowIndex).Cells(0).Value)
                    LoadLockers()
                    clearLocaker()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub btnNewLocker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLocker.Click
        clearLocaker()
    End Sub

    Private Sub btnSaveCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCustom.Click
        Try
            If btnSaveCustom.Text = "Save" Then

                If Val(txtNoWorker.Text) <= 0 Or Val(txtNoClient.Text) <= 0 Or Val(cmbServiceCustom.SelectedValue) <= 0 Or Val(txtCustomRate.Text) <= 0 Then
                    MsgBox("Enter valid data in fields", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim objLookUp As New cls_tblLookUp
                Try
                    Dim p As cls_tblLookUp.PriceType = cls_tblLookUp.PriceType.DAY
                    Select Case cmbCustomType.SelectedIndex
                        Case 0
                            p = cls_tblLookUp.PriceType.DAY
                        Case 1
                            p = cls_tblLookUp.PriceType.NIGHT
                        Case 2
                            p = cls_tblLookUp.PriceType.EVENING
                    End Select
                    Dim pp As cls_tblLookUp.PriceSpec = objLookUp.GetPrice2(Val(txtNoWorker.Text), Val(txtNoClient.Text), Val(cmbServiceCustom.SelectedValue), p, cmbServiceType.Text, IIf(chkEscort.Checked, "ESCORT", "ROOM"), False)
                    If MsgBox("Duplicate entry. Do you want to update the price ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        CustomeSL = pp.ItemSl
                        GoTo Update
                    End If
                    Exit Sub
                Catch ex As Exception
                End Try
                objLookUp.Insert(Val(txtNoWorker.Text), Val(txtNoClient.Text), 0, txtMessage.Text, "", Val(cmbServiceCustom.SelectedValue), Val(txtCustomSpAmount.Text), Val(txtCustomHouseAmount.Text), Val(txtCustomRate.Text), cmbCustomType.Text, cmbServiceType.Text, IIf(chkEscort.Checked, "ESCORT", "ROOM"))
                LoadCustomBooking()
                clearCustom2()
                txtNoWorker.Focus()
            Else
Update:
                Dim objLookUp As New cls_tblLookUp
                objLookUp.Update(CustomeSL, Val(txtNoWorker.Text), Val(txtNoClient.Text), 0, txtMessage.Text, "", Val(cmbServiceCustom.SelectedValue), Val(txtCustomSpAmount.Text), Val(txtCustomHouseAmount.Text), Val(txtCustomRate.Text), cmbCustomType.Text, cmbServiceType.Text, IIf(chkEscort.Checked, "ESCORT", "ROOM"))
                LoadCustomBooking()
                clearCustom2()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Sub clearCustom()
        txtNoClient.Text = ""
        cmbServiceCustom.Text = "--Select--"
        cmbCustomType.Text = "DAY"
        txtNoWorker.Text = ""
        txtMessage.Text = ""
        txtCustomRate.Text = "0"
        txtCustomHouseAmount.Text = "0"
        txtCustomSpAmount.Text = "0"
        btnSaveCustom.Text = "Save"
        txtNoClient.Enabled = True
        txtNoWorker.Enabled = True
        cmbServiceCustom.Enabled = True
        cmbCustomType.Enabled = True
        cmbServiceType.Enabled = True
    End Sub
    Sub clearCustom2()
        txtNoClient.Text = ""
        txtNoWorker.Text = ""
        txtMessage.Text = ""
        txtCustomRate.Text = "0"
        txtCustomHouseAmount.Text = "0"
        txtCustomSpAmount.Text = "0"
        btnSaveCustom.Text = "Save"
        txtNoClient.Enabled = True
        txtNoWorker.Enabled = True
        cmbServiceCustom.Enabled = True
        cmbCustomType.Enabled = True
        cmbServiceType.Enabled = True
    End Sub
    Private Sub btnNewCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustom.Click
        clearCustom()
    End Sub

    Private Sub dgCustom_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustom.CellClick
        Try


            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 8 Then
                    CustomeSL = dgCustom.Rows(e.RowIndex).Cells(0).Value
                    txtNoClient.Text = dgCustom.Rows(e.RowIndex).Cells(1).Value
                    txtNoClient.Enabled = False
                    txtNoWorker.Text = dgCustom.Rows(e.RowIndex).Cells(2).Value
                    txtNoWorker.Enabled = False
                    'txtNoBooking.Text = dgCustom.Rows(e.RowIndex).Cells(3).Value
                    ' cmbServiceCustom.Text = dgCustom.Rows(e.RowIndex).Cells(3).Value.ToString & " Mins"
                    Dim min As Integer = Val(dgCustom.Rows(e.RowIndex).Cells(3).Value.ToString)
                    If min > 5 Then
                        cmbServiceCustom.SelectedValue = min
                    Else
                        cmbServiceCustom.SelectedValue = min * 60
                    End If
                    ' cmbServiceCustom.SelectedValue = dgCustom.Rows(e.RowIndex).Cells(3).Value.ToString
                    cmbServiceCustom.Enabled = False
                    txtCustomRate.Text = dgCustom.Rows(e.RowIndex).Cells(4).Value
                    txtCustomSpAmount.Text = dgCustom.Rows(e.RowIndex).Cells(5).Value
                    txtCustomHouseAmount.Text = dgCustom.Rows(e.RowIndex).Cells(6).Value
                    cmbCustomType.Text = dgCustom.Rows(e.RowIndex).Cells(7).Value
                    Try
                        cmbServiceType.Text = dgCustom.Rows(e.RowIndex).Cells(10).Value
                    Catch ex As Exception
                    End Try
                    cmbCustomType.Enabled = False
                    cmbServiceType.Enabled = False
                    btnSaveCustom.Text = "Update"
                    txtMessage.Text = dgCustom.Rows(e.RowIndex).Cells(7).Value
                ElseIf e.ColumnIndex = 9 Then
                    If MsgBox("Are you to delete this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    Dim objLocker As New cls_tblLookUp
                    objLocker.Delete(dgCustom.Rows(e.RowIndex).Cells(0).Value)
                    LoadCustomBooking()
                    clearCustom()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub cmbCustomType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomType.SelectedIndexChanged
        LoadCustomBooking()
    End Sub

    Private Sub txtCustomRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomRate.TextChanged
        txtCustomHouseAmount.Text = (Val(txtCustomRate.Text) - Val(txtCustomSpAmount.Text)).ToString("0.00")
    End Sub

    Private Sub txtCustomSpAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomSpAmount.TextChanged
        txtCustomHouseAmount.Text = (Val(txtCustomRate.Text) - Val(txtCustomSpAmount.Text)).ToString("0.00")
    End Sub


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        frmWeekCollectionDoorCharge.Show()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        frmWeekCollectionBooking.Show()
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        frmWeekCollectionBookingWorkerWise.Show()
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        frmWeekCollectionBookingSplit.Show()

    End Sub

    Private Sub cmbServiceCustom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServiceCustom.SelectedIndexChanged, cmbServiceType.SelectedIndexChanged
        LoadCustomBooking()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        frmBookingReportClearing2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If MsgBox("Are you sure?" & vbNewLine &
                      "Please note : Changing the Room names will effect previous bookings tracking", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim errorCnt As Integer = 0
            Dim saveCnt As Integer = 0
            For Each dgr As DataGridViewRow In dgRoom.Rows
                Try
                    If dgr.Cells(0).Value = 16 Then
                        'objRoom.Update(dgr.Cells(0).Value, "ESCORT", "ESCORT", dgr.Cells(2).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)

                        Dim fl As cls_Temp_tblRoom.Fields = objRoom.Selection_One_Row("ESCORT")
                        If fl.Status_ = Nothing Then
                            fl.Status_ = ""
                        End If
                        If fl.Comment_ = Nothing Then
                            fl.Comment_ = ""
                        End If
                        objRoom.Update(dgr.Cells(0).Value, "ESCORT", dgr.Cells(2).Value, fl.Status_, fl.Usable_, fl.Comment_, fl.StatusTime_, fl.AutoActiveIn_, dgr.Cells(4).Value, dgr.Cells(5).Value, "ESCORT")
                        dgr.Cells(1).Value = "ESCORT"
                        dgr.Cells(3).Value = "ESCORT"

                    Else
                        Dim fl As cls_Temp_tblRoom.Fields = objRoom.Selection_One_Row(dgr.Cells(1).Value)
                        If fl.Status_ = Nothing Then
                            fl.Status_ = ""
                        End If
                        If fl.Comment_ = Nothing Then
                            fl.Comment_ = ""
                        End If
                        objRoom.Update(dgr.Cells(0).Value, dgr.Cells(3).Value, dgr.Cells(2).Value, fl.Status_, fl.Usable_, fl.Comment_, fl.StatusTime_, fl.AutoActiveIn_, dgr.Cells(4).Value, dgr.Cells(5).Value, dgr.Cells(1).Value)
                    End If
                    saveCnt += 1
                Catch ex As Exception
                    errorCnt += 1
                End Try
            Next

            'frmHome.LoadRooms()
            'frmMAP.LoadRooms()
            Dim dOT As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings
            dOT.RoomType = cmbRoomType.Text
            MySettings.OtherSettings = dOT
            If errorCnt = 0 Then
                MsgBox("Updated successfully", MsgBoxStyle.Information, "Info")
            Else
                MsgBox("Update not successfull. Please try again", MsgBoxStyle.Information, "Info")
            End If
            If saveCnt > 0 Then
                Application.Restart()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSummaryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummaryReport.Click
        frmSummary.Show()
    End Sub

    Private Sub btnCancelledBookingsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelledBookingsReport.Click
        frmCancelledBooking.Show()
    End Sub

    Private Sub btnSuspendedBookingsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuspendedBookingsReport.Click
        frmSuspendedBooking.Show()
    End Sub

    Private Sub btnCompletedBookingsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompletedBookingsReport.Click
        frmClearedBookings.Show()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If MsgBox("Please note import will delete all current data in database and will add the data's from import file" & vbNewLine & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim oDailog As New OpenFileDialog
        oDailog.AddExtension = True
        oDailog.Filter = "Backup Files|*.bdl"
        If oDailog.ShowDialog = vbOK Then
            Dim obl As New cls_ExportImport
            Try
                frmMAP.tmrRefreshRoomStatus.Stop()
                frmPreBookingHome.tmrTimeLeftCounter.Stop()
                frmHome.tmrFlasher.Stop()
                frmHome.tmrTimeLeftCounter.Stop()
                If obl.ImportDb(oDailog.FileName) Then
                    MsgBox("Done. " & vbNewLine & "Application will restart now.", MsgBoxStyle.Information, "Info")
                    Application.Restart()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim sDailog As New SaveFileDialog
        sDailog.AddExtension = True
        sDailog.Filter = "Backup Files|*.bdl"
        sDailog.FileName = Now.ToString("yyyyMMddHHmm")
        If sDailog.ShowDialog = vbOK Then
            Dim obl As New cls_ExportImport
            Try
                If obl.ExportDb(sDailog.FileName) Then
                    MsgBox("Done", MsgBoxStyle.Information, "Info")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub btnClearDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDB.Click
        If MsgBox("Please note clear database will delete all current data in database." & vbNewLine & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim obl As New cls_ExportImport
        obl.ClearDB()
        MsgBox("Done. Exiting application.", MsgBoxStyle.Information, "Info")
        End
    End Sub


    Private Sub btnResetConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetConnection.Click
        If MsgBox("Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Reset Database Connection") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim dbFileLoca As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "dbLocation.txt")
        My.Computer.FileSystem.WriteAllText(dbFileLoca, "", False)
        Application.Restart()
    End Sub

    Private Sub btnSpeakON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeakON.Click
        Try
            mySpeaker = New Speech.Synthesis.SpeechSynthesizer
            mySpeaker.Volume = 100
            mySpeaker.SelectVoiceByHints(Speech.Synthesis.VoiceGender.Female, Speech.Synthesis.VoiceAge.Teen)
        Catch ex As Exception
        End Try
        isSoundOn = True
        MyLocalSettings.SpeechSpeaker = True
        SaveLocalSettings()

        btnSpeakON.Enabled = False
        btnSpeakOFF.Enabled = True
    End Sub

    Private Sub btnSpeakOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeakOFF.Click
        isSoundOn = False
        MyLocalSettings.SpeechSpeaker = False
        SaveLocalSettings()
        btnSpeakON.Enabled = True
        btnSpeakOFF.Enabled = False
    End Sub

    Private Sub btnWorkerActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkerActivity.Click
        frmSPAcitvityReport.Show()
    End Sub

    Private Sub btnRoomAcitvity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoomAcitvity.Click
        frmRoomActivityReport.Show()
    End Sub

    Private Sub btnDayActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDayActivity.Click
        frmDayActivity.Show()
    End Sub

    Private Sub btnHourlyTrafficReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourlyTrafficReport.Click
        frmHourlyTraffic.Show()
    End Sub

    Private Sub btnDoorChargeOverall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoorChargeOverall.Click
        frmDoorChargeOverall.Show()
    End Sub

    Private Sub btnWeeklyBookingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeeklyBookingReport.Click
        frmWeeklyBookingReport.Show()
    End Sub

    Private Sub btnSplitReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSplitReport.Show()
    End Sub

    Private Sub btnWorkerIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkerIncome.Click
        frmSPIncomeReport.Show()
    End Sub

    Private Sub btnDialyBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDialyBooking.Click
        frmDailyBooking.Show()
    End Sub

    Private Sub btnDoorChargeReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoorChargeReport.Click
        frmDoorChargeReport.Show()
    End Sub

    Private Sub btnAnalysisReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalysisReport.Click
        frmReport_PERIODIC_ANALYSIS_REPORT.Show()
    End Sub

    Private Sub btnPeriodicRevenueReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodicRevenueReport.Click
        'frmPeroidicFinancialReport.Show()
    End Sub

    Private Sub chk3Shift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk3Shift.CheckedChanged
        lblEvening.Visible = chk3Shift.Checked
        Label41.Visible = chk3Shift.Checked
        Label39.Visible = chk3Shift.Checked
        txtEveingShiftStartTime.Visible = chk3Shift.Checked
        txtEveningShiftEndTime.Visible = chk3Shift.Checked
        If chk3Shift.Checked Then
            txtEveingShiftStartTime.Text = txtDay_End.Text
        Else
            txtNightStart.Text = txtDay_End.Text
        End If

    End Sub

    Private Sub btnPrintLookUps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLookUps.Click
        Dim frm As New frmPrintList
        dgCustom.Columns(8).Visible = False
        dgCustom.Columns(9).Visible = False
        frm.PrintPreview(dgCustom, "Lookup Prices", _
                        IIf(cmbServiceCustom.SelectedIndex = 0, "All Services", cmbServiceCustom.Text) & " " & IIf(cmbServiceType.SelectedIndex = 0, "Standard", "Delux") & _
                        " " & cmbCustomType.Text, "", "", False, "", True, True)
        dgCustom.Columns(8).Visible = False
        dgCustom.Columns(9).Visible = False
    End Sub

    Private Sub btnLookUpPriceGenerator_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpPriceGenerator.Click
        Dim fr As New frmLookUpGenerator
        fr.ShowDialog()
        'If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
        'End If
        LoadCustomBooking()

    End Sub

    Private Sub txtResetPrice_Click(sender As System.Object, e As System.EventArgs) Handles txtResetPrice.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            Dim objLookUp As New cls_tblLookUp
            Dim deleteCount As Integer = objLookUp.Reset(IIf(cmbServiceCustom.SelectedIndex = 0, "", "Service=" & Val(cmbServiceCustom.SelectedValue).ToString & " AND ") & " [Type]='" & cmbCustomType.Text & "' AND [ServiceType]='" & cmbServiceType.Text & "'")
            If deleteCount > 0 Then
                MsgBox("Price reset successfull", MsgBoxStyle.Information, "Info")
                LoadCustomBooking()
            Else
                MsgBox("Not done", MsgBoxStyle.Information, "Info")
            End If
        Catch ex As Exception
            MsgBox("Not done" & vbNewLine & ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub chkContra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContra.CheckedChanged

        Label46.Visible = chkContra.Checked
        txtContraPass.Visible = chkContra.Checked

    End Sub

    Private Sub btnPremiumServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPremiumServices.Click
        Dim frm As New frmPremiumServices
        frm.ShowDialog()
    End Sub
    Private Sub btnEscortServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEscortServices.Click
        Dim frm As New frmEscortServices
        frm.ShowDialog()
    End Sub

    Private Sub btnCancellationFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancellationFee.Click
        Dim frm As New frmCancellationFees
        frm.ShowDialog()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmPeroidicFinancialReport2.Owner = Me
        frmPeroidicFinancialReport2.Show()
    End Sub

    Private Sub txtDay_start_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay_start.KeyUp
        txtNightStop.Text = txtDay_start.Text
    End Sub

    Private Sub txtDay_End_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay_End.KeyUp
        If chk3Shift.Checked Then
            txtEveingShiftStartTime.Text = txtDay_End.Text
        Else
            txtNightStart.Text = txtDay_End.Text
        End If
    End Sub

    Private Sub txtEveingShiftStartTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEveingShiftStartTime.KeyUp

    End Sub

    Private Sub txtEveningShiftEndTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEveningShiftEndTime.KeyUp
        txtNightStart.Text = txtEveningShiftEndTime.Text
    End Sub

    Private Sub txtNightStart_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNightStart.KeyUp

    End Sub

    Private Sub txtNightStop_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNightStop.KeyUp
        txtDay_start.Text = txtNightStop.Text
    End Sub

    Private Sub btnResetDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetDatabase.Click
        If MsgBox("Reset database will erase everything from the dattabase. It will be same as a new installation." & vbNewLine & _
                   "Do you want to continue?" & vbNewLine & "We recommend you to Export the database and try this option.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            Dim objCon As New clsConnection
            Dim conn As SqlConnection = Nothing
            conn = objCon.connect(True)
            Dim tt As New cls_ExportImport
            tt.executeSqlScript("Use MASTER", conn)
            tt.executeSqlScript("EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" & dbName & "'", conn)
            tt.executeSqlScript("Use MASTER", conn)
            tt.executeSqlScript("ALTER DATABASE [" & dbName & "] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE", conn)
            tt.executeSqlScript("Use MASTER", conn)
            tt.executeSqlScript("DROP DATABASE [" & dbName & "]", conn)
            tt.executeSqlScript("Use MASTER", conn)
            Application.Restart()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub txt1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpp1.KeyUp, _
        txtpp11.KeyUp, _
        txtpp2.KeyUp, _
        txtpp22.KeyUp, _
        txtpp3.KeyUp, _
        txtpp33.KeyUp, _
        txtpp4.KeyUp, _
        txtpp44.KeyUp, _
        txtpp5.KeyUp, _
        txtpp55.KeyUp, _
        txtpp6.KeyUp, _
        txtpp66.KeyUp, _
        txtpp7.KeyUp, _
        txtpp77.KeyUp
        Try
            txtpp111.Value = txtpp11.Value + txtpp1.Value
            txtpp222.Value = txtpp22.Value + txtpp2.Value
            txtpp333.Value = txtpp33.Value + txtpp3.Value
            txtpp444.Value = txtpp44.Value + txtpp4.Value
            txtpp555.Value = txtpp55.Value + txtpp5.Value
            txtpp666.Value = txtpp66.Value + txtpp6.Value
            txtpp777.Value = txtpp77.Value + txtpp7.Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txt1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpp1.ValueChanged, _
                                                                                                        txtpp11.ValueChanged, _
                                                                                                        txtpp2.ValueChanged, _
                                                                                                        txtpp22.ValueChanged, _
                                                                                                        txtpp3.ValueChanged, _
                                                                                                        txtpp33.ValueChanged, _
                                                                                                        txtpp4.ValueChanged, _
                                                                                                        txtpp44.ValueChanged, _
                                                                                                        txtpp5.ValueChanged, _
                                                                                                        txtpp55.ValueChanged, _
                                                                                                        txtpp6.ValueChanged, _
                                                                                                        txtpp66.ValueChanged, _
                                                                                                        txtpp7.ValueChanged, _
                                                                                                        txtpp77.ValueChanged
        Try
            txtpp111.Value = txtpp11.Value + txtpp1.Value
            txtpp222.Value = txtpp22.Value + txtpp2.Value
            txtpp333.Value = txtpp33.Value + txtpp3.Value
            txtpp444.Value = txtpp44.Value + txtpp4.Value
            txtpp555.Value = txtpp55.Value + txtpp5.Value
            txtpp666.Value = txtpp66.Value + txtpp6.Value
            txtpp777.Value = txtpp77.Value + txtpp7.Value
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnSavePremiumSevices_Click(sender As Object, e As EventArgs) Handles btnSavePremiumSevices.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            For i = 1 To 7
                Try
                    Dim dt As DataTable = objPremiumServices.Selection(cls_Temp_tblPremiumServices.SelectionType.All, "Weekday=" & i.ToString)
                    If dt.Rows.Count = 0 Then
                        Throw New Exception("")
                    End If
                    objPremiumServices.Update(dt.Rows(0).Item("ItemId"), i, CType(TabPage12.Controls("txtpp" & i.ToString & i.ToString & i.ToString), NumericUpDown).Value, CType(TabPage12.Controls("txtpp" & i.ToString), NumericUpDown).Value, CType(TabPage12.Controls("txtpp" & i.ToString & i.ToString), NumericUpDown).Value)
                Catch ex As Exception
                    objPremiumServices.Insert(i, CType(TabPage12.Controls("txtpp" & i.ToString & i.ToString & i.ToString), NumericUpDown).Value, CType(TabPage12.Controls("txtpp" & i.ToString), NumericUpDown).Value, CType(TabPage12.Controls("txtpp" & i.ToString & i.ToString), NumericUpDown).Value)
                End Try
            Next
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click

        Try
            frmUser.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtDayPrice_CheckedChanged(sender As Object, e As EventArgs) Handles chkDayPrice.CheckedChanged

        txtDayPricePass.Visible = chkDayPrice.Checked
        Label61.Visible = chkDayPrice.Checked

    End Sub

    Private Sub btnRollBack_Click(sender As System.Object, e As System.EventArgs) Handles btnRollBack.Click

        If MsgBox("Are you sure?" & vbNewLine & vbCrLf & "Note : Version " & My.Application.Info.Version.ToString & " cannot be used anymore." & vbNewLine & "Application will rollback to version " & MyLocalSettings.LastVersion.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            Dim objCon As New clsConnection
            Dim con As SqlConnection = Nothing
            con = objCon.connect()
            Dim com As New SqlCommand("Update tblDBVErsion SET [Type]='INVALID' where [Version]='" & My.Application.Info.Version.ToString & "'", con)
            com.ExecuteNonQuery()
            MsgBox("Done. Application will terminate now.", MsgBoxStyle.Information, "Info")
            End
        Catch ex As Exception
            MsgBox("Rollback failed." & vbNewLine & "Please contact Application support.", MsgBoxStyle.Critical, "info")
        End Try

    End Sub

    Private Sub chkEscort_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEscort.CheckedChanged

        LoadCustomBooking()
        Try
            cmbServiceType.Enabled = Not chkEscort.Checked
            If Not cmbServiceType.Enabled Then
                cmbServiceType.SelectedIndex = 1
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnSaveFees_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveFees.Click

        Try
            Dim c As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings
            c.CancelFees = txtCancelFee1.Value
            c.CancelFeesAfter1Hr = txtCancelFee2.Value
            c.MembershipFee = txtMemBershipFees.Value
            c.EFT_P = txtEFT.Value
            c.VISA_P = txtVISA.Value
            c.AMEX_P = txtAMEX.Value
            c.MASTERCARD_P = txtMASTERCARD.Value
            c.OTHRCARD_P = txtOthersCard.Value
            c.BOND_FEES = txtEscortBondFees.Value


            c.DoorLoungeDay = NumericUpDown1.Value
            c.DoorLoungeNight = NumericUpDown2.Value

            c.DoorPrivateDay = NumericUpDown4.Value
            c.DoorPrivateNight = NumericUpDown3.Value

            c.DoorPrivateIntroDay = NumericUpDown5.Value
            c.DoorPrivateIntroNight = NumericUpDown6.Value

            MySettings.OtherSettings = c
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "info")
        End Try

    End Sub

    Private Sub chkEscortServices_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEscortServices.CheckedChanged
        chkSameEscortPrice.Enabled = chkEscortServices.Checked
        chkEscortShiftPrice.Enabled = chkEscortServices.Checked
        chkOnlyDeluxe.Enabled = chkEscortServices.Checked
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnClearBookingTables.Click
        Dim obl As New cls_ExportImport
        obl.ClearTabledatas(obl.ClearBookings)
        End
    End Sub
 
    Private Sub btnSavePassword_Click(sender As System.Object, e As System.EventArgs) Handles btnSavePassword.Click
        'If MySettings.OtherSettings.EscortService <> chkEscortServices.Checked Then
        '    MsgBox("Please restart the application for the changes to take effect", MsgBoxStyle.Information, "Info")
        'End If
        MySettings.Contra = chkContra.Checked
        MySettings.Contra_Password = txtContraPass.Text
        Dim dOT As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings
        dOT.PauseResumePassword = txtPauseResumePassword.Text
        dOT.TimeAdjustPassword = txtAdjustpass.Text
        dOT.DayPrice = chkDayPrice.Checked
        dOT.DayPricePassword = txtDayPricePass.Text
        dOT.Membership = chkMembership.Checked
        MySettings.OtherSettings = dOT
        MsgBox("Saved.", MsgBoxStyle.Information, "Info")
    End Sub

  

    Private Sub cmbMemoPrinter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMemoPrinter.SelectedIndexChanged

    End Sub

    Private Sub cmbReportPrinter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbReportPrinter.SelectedIndexChanged

    End Sub

    Private Sub cmbRoomType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbRoomType.SelectedIndexChanged

    End Sub

    Private Sub GroupBox11_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox11.Enter


    End Sub



    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        frmAddMerchandise.ShowDialog()
        frmMerchandiseSale.loadProducts()
    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles btnGenerateCancellationPassword.Click
        btnGenerateCancellationPassword.Text = "Re-Generate"
        Regenerate()
        txtCancellationPassword.Text = MySettings.OtherSettings.CancellationPassword
    End Sub
    Sub Regenerate()
        Dim rn As New Random
        Dim verification_code As String = rn.Next(11111111, 99999999) 
        Dim dOT As cls_tblSettings.OtherSetiings_S = MySettings.OtherSettings
        dOT.CancellationPassword = verification_code
        MySettings.OtherSettings = dOT
    End Sub

    Private Sub Button4_Click_2(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        frmSummaryNew.Owner = Me
        frmSummaryNew.Show()
    End Sub
End Class