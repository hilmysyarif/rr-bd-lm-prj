Public Class frmLookUpGenerator


    Dim ServiceType As String = ""
    Dim ShiftType As String = ""
    Dim ShiftType_p As cls_tblLookUp.PriceType = cls_tblLookUp.PriceType.DAY

    Private Sub frmLookUpGenerator_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy Then
            MsgBox("Saving in progress", MsgBoxStyle.Information, "Info")
            e.Cancel = True
        End If
    End Sub

    Private Sub frmLookUpGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        rdbEvening.Visible = MySettings.Shifts_3_enabled
        grpServiceType.Visible = MySettings.SpecialServiceEnabled

        If MySettings.OtherSettings.EscortService Then
            grpRoomType.Visible = Not MySettings.OtherSettings.SameEscortPrice
        Else
            grpRoomType.Visible = False
        End If

        Try

            Dim dt As DataTable = ExecuteAdapter("Select Service , count(sl) from tblLookUp where TotalAmount>0 group by service")
            For Each c As RadioButton In grpServices.Controls
                For Each dr As DataRow In dt.Rows
                    If c.Tag = dr("Service") Then
                        c.ForeColor = Color.Green
                    End If
                Next
            Next

        Catch ex As Exception
        End Try

        isLoading = False

    End Sub
    Dim SpR As Double = 110
    Dim HR As Double = 90
    Dim isLoading As Boolean = True
    Private Sub txtTotalAmount30Mins_KeyUp() Handles txtTotalAmount30Mins.ValueChanged
        If Not isLoading Then
            isLoading = True
            txtSPRatio.Maximum = txtTotalAmount30Mins.Value
            txtHouseRatio.Maximum = txtTotalAmount30Mins.Value
            Try
                txtHouseRatio.Value = txtTotalAmount30Mins.Value * (HR / (SpR + HR))
            Catch ex As Exception
                txtHouseRatio.Value = 1
            End Try
            Try
                txtSPRatio.Value = txtTotalAmount30Mins.Value * (SpR / (SpR + HR))
            Catch ex As Exception
                txtSPRatio.Value = 1
            End Try
            HR = txtHouseRatio.Value
            SpR = txtSPRatio.Value
            isLoading = False
        End If

    End Sub

    Private Sub txtSPRatio_KeyUp() Handles txtSPRatio.ValueChanged
        If Not isLoading Then
            isLoading = True

            Try

                txtHouseRatio.Value = txtTotalAmount30Mins.Value - txtSPRatio.Value
                HR = txtHouseRatio.Value
                SpR = txtSPRatio.Value
            Catch ex As Exception

            End Try
            isLoading = False
        End If

    End Sub

    Private Sub txtHouseRatio_KeyUp() Handles txtHouseRatio.ValueChanged
        If Not isLoading Then
            isLoading = True
            txtSPRatio.Value = txtTotalAmount30Mins.Value - txtHouseRatio.Value
            SpR = txtSPRatio.Value
            HR = txtHouseRatio.Value
            isLoading = False
        End If

    End Sub
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If BackgroundWorker1.IsBusy Then
            MsgBox("Saving in progress", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim SelectedService As New List(Of Integer)
        'For Each serv As Integer In Services
        '    If CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Checked Then
        '        SelectedService.Add(serv)
        '    End If
        'Next
        For Each serv As RadioButton In (From r As RadioButton In grpServices.Controls Order By Val(r.Tag) Select r)
            If (serv.Checked Or CheckBox1.Checked) And serv.Visible Then
                SelectedService.Add(serv.Tag)
            End If
        Next
        If SelectedService.Count = 0 Then
            MsgBox("Please a service time", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        dgList.Rows.Clear()
        ServiceType = IIf(rdbStandard.Checked, "STANDARD", "DELUX")
        Select Case True
            Case rdbDay.Checked
                ShiftType = "DAY"
                ShiftType_p = cls_tblLookUp.PriceType.DAY
            Case rdbEvening.Checked
                ShiftType = "EVENING"
                ShiftType_p = cls_tblLookUp.PriceType.EVENING
            Case rdbNight.Checked
                ShiftType = "NIGHT"
                ShiftType_p = cls_tblLookUp.PriceType.NIGHT
        End Select
        'Dim NightAdd As Integer = IIf(rdbDay.Checked, 0, txtExtraAmount.Value)
        'Dim Mins30Price As Double = txtTotalAmount30Mins.Value - NightAdd
        Dim Mins30Price As Double = txtTotalAmount30Mins.Value
        Dim SpRatio As Double = txtSPRatio.Value
        Dim HouseRatio As Double = txtHouseRatio.Value
        Dim Clients As Integer = txtClinetStop.Value
        Dim SPs As Integer = txtSpStop.Value
        Dim Clientstart As Integer = txtClientStart.Value
        Dim SPsstart As Integer = txtSpStart.Value
        Dim sl As Integer = 0

        For Each serv As Integer In SelectedService
            For c = Clientstart To Clients
                For sp = SPsstart To SPs

                    'Dim PriceServiceRatio As Double = 1
                    'If SelectedService.Count <> 1 Then
                    '    Select Case serv
                    '        Case 30
                    '            PriceServiceRatio = 1
                    '        Case 45
                    '            PriceServiceRatio = 1.25
                    '        Case 60
                    '            PriceServiceRatio = 1.5
                    '        Case 90
                    '            PriceServiceRatio = 2
                    '        Case 120
                    '            PriceServiceRatio = 3
                    '        Case 150
                    '            PriceServiceRatio = 3.75
                    '        Case 180
                    '            PriceServiceRatio = 4.5
                    '        Case 210
                    '            PriceServiceRatio = 5.25
                    '        Case 240
                    '            PriceServiceRatio = 6
                    '        Case 300
                    '            PriceServiceRatio = 7.5
                    '    End Select
                    'End If

                    'Dim Total As Double = Math.Round(((PriceServiceRatio * Mins30Price) + NightAdd) * IIf(c > sp, c, sp), 0)
                    'Dim Total As Double = Math.Round((Mins30Price + NightAdd) * IIf(c > sp, c, sp), 0)
                    'Dim Total As Double = Math.Round(Mins30Price * IIf(c > sp, c, sp), 0)

                    'If Total Mod 10 >= 5 Then
                    '    Total = Total - (Total Mod 10) + 10
                    'Else
                    '    Total = Total - (Total Mod 10)
                    'End If
                    Dim noOfBookings As Integer = IIf(c > sp, c, sp)
                    If rdbHighest.Checked Then
                        noOfBookings = IIf(c > sp, c, sp)
                    ElseIf rdbMultiplication.Checked
                        noOfBookings = c * sp
                    End If

                    Dim Total As Double = Math.Round(Mins30Price * (IIf(CheckBox1.Checked, serv / 5, 1)) * noOfBookings, 0)
                    Dim SpAmount As Integer = 0
                    Try
                        SpAmount = (Total * (SpRatio / (HouseRatio + SpRatio))).ToString("0.00")
                    Catch ex As Exception
                    End Try
                    Dim HouseAmount As Double = Total - SpAmount
                    sl += 1
                    dgList.Rows.Add(1, sl, sp, c, IIf(serv >= 90, (serv / 60).ToString & " Hrs", serv.ToString & " Mins"), SpAmount, HouseAmount, Total, IIf(rdbEscort.Checked, "ESCORT", "ROOM"), "", serv)

                Next
            Next
        Next

    End Sub
    Private Sub dgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy Then
            MsgBox("Saving in progress", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dgList.Rows.Count = 0 Then
            MsgBox("Please generate prices and then try to save", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBox("Are you sure (Yes/No)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If

        lookUps = New List(Of LookUp)
        For Each dr As DataGridViewRow In dgList.Rows

            Dim lk As New LookUp
            lk.NoWorker = dr.Cells(2).Value
            lk.NoClient = dr.Cells(3).Value
            '  lk.Serv = IIf(Val(dr.Cells(4).Value) > 5, Val(dr.Cells(4).Value), Val(dr.Cells(4).Value) * 60)
            lk.Serv = Val(dr.Cells(10).Value)
            lk.spAmount = dr.Cells(5).Value
            lk.HouseAmount = dr.Cells(6).Value
            lk.TotalAmount = dr.Cells(7).Value
            lk.Room = dr.Cells(8).Value
            lookUps.Add(lk)

        Next

        BackgroundWorker1.RunWorkerAsync()

    End Sub


    Private Sub rdbDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDay.CheckedChanged, rdbEvening.CheckedChanged, rdbNight.CheckedChanged

        'If rdbDay.Checked Then
        '    txtExtraAmount.Value = 0
        '    Label3.Visible = False
        '    txtExtraAmount.Visible = False
        '    GroupBox4.Text = "DAY PRICE DETAILS"
        'Else
        '    Label3.Visible = True
        '    txtExtraAmount.Visible = True
        '    If rdbEvening.Checked Then
        '        Label3.Text = "EVENING EXTRA AMOUNT"
        '        txtExtraAmount.Value = 30
        '        GroupBox4.Text = "EVENING PRICE DETAILS"
        '    Else
        '        Label3.Text = "NIGHT EXTRA AMOUNT"
        '        txtExtraAmount.Value = 50
        '        GroupBox4.Text = "NIGHT PRICE DETAILS"
        '    End If
        '    txtExtraAmount.Value = 0
        '    Label3.Visible = False
        '    txtExtraAmount.Visible = False
        'End If

        If rdbDay.Checked Then
            GroupBox4.Text = "DAY PRICE DETAILS"
        Else
            If rdbEvening.Checked Then
                GroupBox4.Text = "EVENING PRICE DETAILS"
            Else
                GroupBox4.Text = "NIGHT PRICE DETAILS"
            End If
        End If

        Try
            Dim tm As Integer = 0
            'For Each serv As Integer In Services
            '    If CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Checked Then
            '        tm = CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Tag
            '    End If
            'Next
            For Each serv As RadioButton In grpServices.Controls
                If serv.Checked And serv.Visible Then
                    tm = (serv.Tag)
                End If
            Next
            Dim ty As String = IIf(rdbDay.Checked, "DAY", IIf(rdbNight.Checked, "NIGHT", "EVENING"))
            Dim dt As DataTable = ExecuteAdapter("Select Service,Servicetype , count(sl) from tblLookUp where TotalAmount>0 and service='" & tm.ToString & "' and type='" & ty.ToString & "' group by service,Servicetype ")

            Dim ll As New List(Of String)

            For Each dr As DataRow In dt.Rows
                ll.Add(dr("Servicetype"))
            Next

            rdbStandard.ForeColor = IIf(ll.Contains("STANDARD"), Color.Green, Color.Black)
            rdbDeluc.ForeColor = IIf(ll.Contains("DELUX"), Color.Green, Color.Black)

        Catch ex As Exception
        End Try
    End Sub

    Dim lookUps As List(Of LookUp)
    Structure LookUp
        Dim NoWorker As Integer
        Dim NoClient As Integer
        Dim Serv As Integer
        Dim spAmount As Double
        Dim HouseAmount As Double
        Dim TotalAmount As Double
        Dim Room As String
    End Structure

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim objLookUp As New cls_tblLookUp
        Dim cnt As Integer = 1
        For Each dr As LookUp In lookUps
            Try
                Dim NoWorker As Integer = dr.NoWorker
                Dim NoClient As Integer = dr.NoClient
                Dim Serv As Integer = dr.Serv
                Dim isDuplicate As Boolean = False
                Dim ItemSl As Integer = 0

                Dim spAmount As Double = dr.spAmount
                Dim HouseAmount As Double = dr.HouseAmount
                Dim TotalAmount As Double = dr.TotalAmount
                Dim Room As String = dr.Room

                Try
                    ItemSl = objLookUp.GetPrice2(NoWorker, NoClient, Serv, ShiftType_p, ServiceType, Room, False).ItemSl
                    ' isDuplicate = True
                    While ItemSl <> 0
                        objLookUp.Delete(ItemSl)
                        ItemSl = objLookUp.GetPrice2(NoWorker, NoClient, Serv, ShiftType_p, ServiceType, Room, False).ItemSl
                    End While
                Catch ex As Exception
                End Try
                If Not isDuplicate Then
                    objLookUp.Insert(NoWorker, NoClient, 0, "", "", Serv, spAmount, HouseAmount, TotalAmount, ShiftType, ServiceType, Room)
                Else
                    objLookUp.Update(ItemSl, NoWorker, NoClient, 0, "", "", Serv, spAmount, HouseAmount, TotalAmount, ShiftType, ServiceType, Room)
                End If
                BackgroundWorker1.ReportProgress(cnt)
                cnt += 1
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        GroupBox5.Text = "Saved : " & e.ProgressPercentage.ToString & " Out of " & lookUps.Count.ToString
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MsgBox("Saved", MsgBoxStyle.Information, "Info")
        dgList.Rows.Clear()
        '  Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub chk210_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk90.CheckedChanged, chk60.CheckedChanged, chk45.CheckedChanged, chk300.CheckedChanged, chk30.CheckedChanged, chk240.CheckedChanged, chk210.CheckedChanged, chk180.CheckedChanged, chk150.CheckedChanged, chk120.CheckedChanged, chk20.CheckedChanged, chk600.CheckedChanged, chk10.CheckedChanged, chk5.CheckedChanged, chk720.CheckedChanged, chk480.CheckedChanged, chk540.CheckedChanged, chk360.CheckedChanged, chk420.CheckedChanged, chk15.CheckedChanged
        Dim SelectedService As New List(Of String)
        Dim tm As Integer = 0
        'For Each serv As Integer In Services
        '    If CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Checked Then
        '        SelectedService.Add(CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Text)
        '        tm = CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Tag
        '    End If
        'Next
        For Each serv As RadioButton In grpServices.Controls
            If serv.Checked And serv.Visible Then
                SelectedService.Add(serv.Text)
                tm = (serv.Tag)
            End If
        Next
        If SelectedService.Count = 1 Then
            Label1.Text = SelectedService(0).ToString & " SERVICE PRICE"
        Else
            Label1.Text = "5 MINS SERVICE PRICE"
        End If

        Try
            Dim dt As DataTable = ExecuteAdapter("Select Service,type , count(sl) from tblLookUp where TotalAmount>0 and service='" & tm.ToString & "' group by service,type ")
            Dim ll As New List(Of String)
            For Each dr As DataRow In dt.Rows
                ll.Add(dr("type"))
            Next
            rdbDay.ForeColor = IIf(ll.Contains("DAY"), Color.Green, Color.Black)
            rdbNight.ForeColor = IIf(ll.Contains("NIGHT"), Color.Green, Color.Black)
            rdbEvening.ForeColor = IIf(ll.Contains("EVENING"), Color.Green, Color.Black)
        Catch ex As Exception
        End Try

        Try
            Dim ty As String = IIf(rdbDay.Checked, "DAY", IIf(rdbNight.Checked, "NIGHT", "EVENING"))
            Dim dt As DataTable = ExecuteAdapter("Select Service,Servicetype , count(sl) from tblLookUp where TotalAmount>0 and service='" & tm.ToString & "' and type='" & ty.ToString & "' group by service,Servicetype ")
            Dim ll As New List(Of String)
            For Each dr As DataRow In dt.Rows
                ll.Add(dr("Servicetype"))
            Next
            rdbStandard.ForeColor = IIf(ll.Contains("STANDARD"), Color.Green, Color.Black)
            rdbDeluc.ForeColor = IIf(ll.Contains("DELUX"), Color.Green, Color.Black)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmLookUpGenerator_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        grpRoomType.Visible = Not MySettings.OtherSettings.SameEscortPrice
    End Sub
 
    Private Sub btnLoadPreviousPriceLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPreviousPriceLookup.Click

        If BackgroundWorker1.IsBusy Then
            MsgBox("Saving in progress", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim SelectedService As New List(Of Integer)
        'For Each serv As Integer In Services
        '    If CType(grpServices.Controls("chk" & serv.ToString), RadioButton).Checked Then
        '        SelectedService.Add(serv)
        '    End If
        'Next
        For Each serv As RadioButton In grpServices.Controls
            If serv.Checked And serv.Visible Then
                SelectedService.Add(serv.Tag)
            End If
        Next
        If SelectedService.Count = 0 Then
            MsgBox("Please a service time", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        dgList.Rows.Clear()
        ServiceType = IIf(rdbStandard.Checked, "STANDARD", "DELUX")

        Select Case True
            Case rdbDay.Checked
                ShiftType = "DAY"
                ShiftType_p = cls_tblLookUp.PriceType.DAY
            Case rdbEvening.Checked
                ShiftType = "EVENING"
                ShiftType_p = cls_tblLookUp.PriceType.EVENING
            Case rdbNight.Checked
                ShiftType = "NIGHT"
                ShiftType_p = cls_tblLookUp.PriceType.NIGHT
        End Select

     

        Dim sl As Integer = 0

        Dim objLookUp As New cls_tblLookUp
        Dim serv1 As Integer = SelectedService(0)
        Dim dt As DataTable = objLookUp.Selection(cls_tblLookUp.SelectionType.ALL_INHRS, "Service=" & Val(serv1).ToString & " AND " & " [Type]='" & ShiftType & "' AND [ServiceType]='" & ServiceType & "' and [Room]='" & IIf(rdbEscort.Checked, "ESCORT", "ROOM") & "' Order By a.[Service],[Type],[ServiceType],[Worker],[Client]")

        sl = 0
        For Each dr As DataRow In dt.Rows
            sl += 1
            dgList.Rows.Add(1, sl, dr("Worker"), dr("Client"), dr("Service"), dr("SP_Amount"), dr("House_Amount"), dr("TotalAmount"), dr("Room"))
        Next

    End Sub
    
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        chk5.Checked = CheckBox1.Checked
        grpServices.Enabled = Not CheckBox1.Checked
    End Sub

    Private Sub rdbEscort_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbEscort.CheckedChanged
        'If MySettings.OtherSettings.
        rdbStandard.Enabled = Not rdbEscort.Checked
        rdbDeluc.Checked = rdbEscort.Checked
    End Sub
     
   
End Class