Public Class frmCreateWorker
    Inherits Form
    Dim objWorker As New cls_Temp_tblWorkers
    Dim objWorkerFav As New cls_Temp_tblWorkerFavourites
    Dim selectedworkerid As Integer = 0
    Dim prevFile As String = ""
    Dim prevDcDate As Date = Nothing
    'Dim lastf As String = ""
    Dim dtFavorites As DataTable = objWorkerFav.Selection(cls_Temp_tblWorkerFavourites.SelectionType.All, " 2<>2").Clone
    Private Sub frmPeople_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        RefreshDG()
        RefreshFavourites()
    End Sub
    Sub RefreshFavourites()
        dgFavorites.DataSource = dtFavorites
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.ItemId.ToString).Visible = False
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.WorkerId.ToString).Visible = False
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.ClientName.ToString).HeaderText = "Client Name"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.Mobile.ToString).HeaderText = "Mobile"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.Email.ToString).HeaderText = "Email"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.PreferedContactTime.ToString).HeaderText = "Prefered Contact Time"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.PrefereredContactMethod.ToString).HeaderText = "Prefered Contact Method"
    End Sub
    Sub RefreshDG()
        Try
            Dim dt As DataTable = objWorker.Selection(cls_Temp_tblWorkers.SelectionType.VIEW)
            dgCustomers.DataSource = dt
            dgCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            For Each dgr As DataGridViewRow In dgCustomers.Rows
                dgr.Height = 35
            Next
            dgCustomers.Columns("Email").Visible = False


            For Each dr As DataRow In dt.Rows
                If Not txtName.AutoCompleteCustomSource.Contains(dr("WorkerName")) Then
                    txtName.AutoCompleteCustomSource.Add(dr("WorkerName"))
                End If
                Try
                    If Not txtRealname.AutoCompleteCustomSource.Contains(dr("RealName")) Then
                        txtRealname.AutoCompleteCustomSource.Add(dr("RealName"))
                    End If
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MsgBox("Enter Name", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'If txtFileName.Text = "" Then
        '    MsgBox("Select a DC File", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If

        Select Case btnSave.Text
            Case "Submit"

                Dim dtLoggedIN As DataTable = Nothing
                dtLoggedIN = objWorker.Selection(cls_Temp_tblWorkers.SelectionType.VIEW, "[WorkerName]=@WorkerName", New List(Of SqlParameter) From {New SqlParameter("@WorkerName", txtName.Text)})

                If dtLoggedIN.Rows.Count > 0 Then
                    MsgBox("Duplicate SP Name. Please try different name.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Try
                    Dim WorkerId As Integer = objWorker.Insert(txtName.Text, dtpDC.Value.Date, dtpStarted.Value.Date, txtEmail.Text, txtMobile.Text, txtMethod.Text, txtAdditionalInfo.Text, "", "", Now, 0, {0}, "", txtFileName.Text, Now, "", txtRealname.Text, txtDOB.Value.Date, txtNation.Text, IIf(chkEscort.Checked, "YES", "NO"))
                    For Each dr As DataRow In dtFavorites.Rows
                        objWorkerFav.Insert(WorkerId_:=WorkerId, ClientName_:=dr("ClientName"), Mobile_:=dr("Mobile"), Email_:=dr("Email"), PrefereredContactMethod_:=dr("PrefereredContactMethod"), PreferedContactTime_:=dr("PreferedContactTime"))
                    Next
                    MsgBox("Saved successfully.", MsgBoxStyle.Information, "Info")
                    Clear()
                    RefreshDG()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                End Try
            Case "Update"
                Try
                    If prevFile.ToUpper = txtFileName.Text.ToUpper Then
                        If MsgBox("Please update DC File." & vbNewLine & "Do you want to continue without updating DC File (Y/N)?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    Else
                        If prevDcDate = dtpDC.Value Then
                            MsgBox("Please update DC Date.", MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If
                    End If
                    Dim dtLoggedIN As DataTable = Nothing
                    dtLoggedIN = objWorker.Selection(cls_Temp_tblWorkers.SelectionType.VIEW, "[WorkerName]=@WorkerName and workerid <>" & selectedworkerid.ToString, New List(Of SqlParameter) From {New SqlParameter("@WorkerName", txtName.Text)})
                    If dtLoggedIN.Rows.Count > 0 Then
                        MsgBox("Duplicate SP Name. Please try different name.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    Dim sp_info As cls_Temp_tblWorkers.Fields = objWorker.Selection_One_Row(selectedworkerid)
                    Try
                        objWorkerFav.Delete_By_SELECT("WorkerId = " & selectedworkerid.ToString)
                    Catch ex As Exception
                    End Try

                    'objWorker.Update(selectedworkerid, txtName.Text, dtpDC.Value.Date, dtpStarted.Value.Date, txtEmail.Text, txtMobile.Text, txtMethod.Text, txtAdditionalInfo.Text, IIf(prevFile = txtFileName.Text, "", txtFileName.Text), txtRealname.Text, txtDOB.Value.Date, txtNation.Text)
                    objWorker.Update(txtName.Text, dtpDC.Value.Date, dtpStarted.Value.Date, txtEmail.Text, txtMobile.Text, txtMethod.Text, txtAdditionalInfo.Text, IsNull(sp_info.Status_, ""), IsNull(sp_info.CheckInRoomNo_, 0), IsNull(sp_info.CheckInDate_, Now), IsNull(sp_info.CheckInID_, 0), IsNull(sp_info.dc_file_, {CByte(0)}), IsNull(sp_info.dc_file_ext_, ""), IIf(prevFile = txtFileName.Text, "", txtFileName.Text), IsNull(sp_info.NotAvailableTill_, Now), IsNull(sp_info.AvailabilityComment_, ""), txtRealname.Text, txtDOB.Value.Date, txtNation.Text, IIf(chkEscort.Checked, "YES", "NO"), selectedworkerid)
                    For Each dr As DataRow In dtFavorites.Rows
                        objWorkerFav.Insert(WorkerId_:=selectedworkerid, ClientName_:=dr("ClientName"), Mobile_:=dr("Mobile"), Email_:=dr("Email"), PrefereredContactMethod_:=dr("PrefereredContactMethod"), PreferedContactTime_:=dr("PreferedContactTime"))
                    Next
                    MsgBox("Saved successfully.", MsgBoxStyle.Information, "Info")
                    Clear()
                    RefreshDG()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                End Try
            Case ""

            Case ""

        End Select
    End Sub
  

    Sub Clear()
        txtName.Clear()
        dtpDC.Value = Now
        dtpStarted.Value = Now
        txtEmail.Clear()
        txtMobile.Clear()
        txtMethod.Clear()
        txtAdditionalInfo.Clear()
        btnSave.Text = "Submit"
        dgCustomers.Enabled = True
        prevFile = ""
        txtFileName.Text = ""
        txtRealname.Text = ""
        txtNation.Text = ""
        dtFavorites = objWorkerFav.Selection(cls_Temp_tblWorkerFavourites.SelectionType.All, " 2<>2").Clone
        RefreshFavourites()
    End Sub

    Public objActiveWorkers As New cls_tblActiveWorker
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim frm As New dlgAdminPass
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If frm.TextBox1.Text = MySettings.Password Then
                If dgCustomers.SelectedRows.Count > 0 Then
                    Dim cc As Integer = 0
                    For Each dr As DataGridViewRow In dgCustomers.SelectedRows
                        Dim workerid As Integer = dr.Cells(1).Value
                        Dim dtLoggedIN As DataTable = Nothing
                        dtLoggedIN = objWorker.Selection(cls_Temp_tblWorkers.SelectionType.VIEW, "WorkerID in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT' and [Status]<>'SUSPENDED') and workerid=" & workerid.ToString & " ORDER BY [WorkerName]")
                        If dtLoggedIN.Rows.Count > 0 Then
                            Continue For
                        End If
                        If Not frmHome.IsWorkerActive(workerid) Then
                            Continue For
                        End If
                        If Not frmHome.IsWorkerQUEUE(workerid) Then
                            Continue For
                        End If
                        Try
                            objWorker.Delete_By_RowID(workerid)
                            Try
                                objWorkerFav.Delete_By_SELECT("WorkerId = " & workerid.ToString)
                            Catch ex As Exception
                            End Try
                            cc += 1
                        Catch ex As Exception
                            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Info")
                        End Try
                    Next
                    If cc >= 1 Then
                        MsgBox("Deleted", MsgBoxStyle.Information, "Info")
                        RefreshDG()
                    Else
                        MsgBox("Not Deleted. Please check whether SP is logged in or has active booking or not.", MsgBoxStyle.Information, "Info")
                        '   RefreshDG()
                    End If

                Else
                    Dim workerid As Integer = dgCustomers.SelectedRows(0).Cells(1).Value
                    Dim dtLoggedIN As DataTable = Nothing
                    dtLoggedIN = objWorker.Selection(cls_Temp_tblWorkers.SelectionType.VIEW, "WorkerID in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT' and [Status]<>'SUSPENDED') and workerid=" & workerid.ToString & " ORDER BY [WorkerName]")
                    If dtLoggedIN.Rows.Count > 0 Then
                        MsgBox("SP is logged in. Please logout first and then try deleting", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    If Not frmHome.IsWorkerActive(workerid) Then
                        MsgBox("SP has active booking. Please Clear active booking and then try deleting", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    If Not frmHome.IsWorkerQUEUE(workerid) Then
                        MsgBox("SP has queue booking. Please Clear queue booking and then try deleting", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    Try
                        objWorker.Delete_By_RowID(workerid)
                        Try
                            objWorkerFav.Delete_By_SELECT("WorkerId = " & workerid.ToString)
                        Catch ex As Exception
                        End Try
                        MsgBox("Deleted", MsgBoxStyle.Information, "Info")
                        RefreshDG()
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Information, "Info")
                    End Try
                End If


            End If
        Else
            MsgBox("Please enter a valid password", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub dgCustomers_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCustomers.SelectionChanged
        btnDelete.Enabled = dgCustomers.SelectedRows.Count >= 1
    End Sub

    Private Sub dgCustomers_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomers.CellClick
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            dgCustomers.Enabled = False
            btnSave.Text = "Update"
            btnDelete.Enabled = False
            selectedworkerid = dgCustomers.Rows(e.RowIndex).Cells(1).Value
            Dim sp_info As cls_Temp_tblWorkers.Fields = objWorker.Selection_One_Row(selectedworkerid)

            dtFavorites = objWorkerFav.Selection(cls_Temp_tblWorkerFavourites.SelectionType.All, "WorkerId =" & selectedworkerid.ToString)
            RefreshFavourites()
            txtName.Text = dgCustomers.Rows(e.RowIndex).Cells(2).Value
            dtpDC.Value = dgCustomers.Rows(e.RowIndex).Cells(3).Value
            prevDcDate = dtpDC.Value
            dtpStarted.Value = dgCustomers.Rows(e.RowIndex).Cells(4).Value
            txtEmail.Text = dgCustomers.Rows(e.RowIndex).Cells(5).Value
            txtMobile.Text = dgCustomers.Rows(e.RowIndex).Cells(6).Value
            txtMethod.Text = dgCustomers.Rows(e.RowIndex).Cells(7).Value
            txtAdditionalInfo.Text = dgCustomers.Rows(e.RowIndex).Cells(8).Value
            Try
                txtRealname.Text = dgCustomers.Rows(e.RowIndex).Cells(10).Value
            Catch ex As Exception
            End Try

            Try
                txtDOB.Value = dgCustomers.Rows(e.RowIndex).Cells(11).Value

            Catch ex As Exception

            End Try
            Try
                txtNation.Text = dgCustomers.Rows(e.RowIndex).Cells(12).Value

            Catch ex As Exception

            End Try
            Try
                chkEscort.Checked = sp_info.IsEscort_ = "YES"
            Catch ex As Exception
            End Try



            prevFile = objWorker.LoadLastestDC_File(selectedworkerid)
            txtFileName.Text = prevFile
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim openFiled As New OpenFileDialog
        openFiled.Filter = "PDF Files|*.pdf"
        If openFiled.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFileName.Text = openFiled.FileName
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btnAddFavourites_Click(sender As System.Object, e As System.EventArgs) Handles btnAddFavourites.Click
        Dim frm As New frmFavorites
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Dim dr As DataRow = dtFavorites.NewRow

            dtFavorites.Rows.Add(0, 0, frm.txtName.Text, frm.txtMobile.Text, frm.txtEmail.Text, frm.txtPreferedContactTime.Text, frm.txtPreferedContact.Text)
            'dgFavorites.Rows.Add("", frm.txtName.Text, frm.txtMobile.Text, frm.txtEmail.Text, frm.txtPreferedContact.Text, frm.txtPreferedContactTime.Text)
        End If
    End Sub

    Private Sub dgFavorites_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFavorites.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 0 'Delete Column
                    dtFavorites.Rows.RemoveAt(e.RowIndex)
                Case 1 'Edit Column
                    Dim frm As New frmFavorites
                    frm.txtName.Text = dgFavorites.Rows(e.RowIndex).Cells("ClientName").Value
                    frm.txtEmail.Text = dgFavorites.Rows(e.RowIndex).Cells("Email").Value
                    frm.txtMobile.Text = dgFavorites.Rows(e.RowIndex).Cells("Mobile").Value
                    frm.txtPreferedContact.Text = dgFavorites.Rows(e.RowIndex).Cells("PrefereredContactMethod").Value
                    frm.txtPreferedContactTime.Text = dgFavorites.Rows(e.RowIndex).Cells("PreferedContactTime").Value
                    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        dgFavorites.Rows(e.RowIndex).Cells("ClientName").Value = frm.txtName.Text
                        dgFavorites.Rows(e.RowIndex).Cells("Email").Value = frm.txtEmail.Text
                        dgFavorites.Rows(e.RowIndex).Cells("Mobile").Value = frm.txtMobile.Text
                        dgFavorites.Rows(e.RowIndex).Cells("PrefereredContactMethod").Value = frm.txtPreferedContact.Text
                        dgFavorites.Rows(e.RowIndex).Cells("PreferedContactTime").Value = frm.txtPreferedContactTime.Text
                    End If
            End Select
        End If

    End Sub

    Private Sub btnDeActivate_Click(sender As System.Object, e As System.EventArgs) Handles btnDeActivate.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If

        If dgCustomers.SelectedRows.Count > 0 Then
            Dim cc As Integer = 0
            For Each dr As DataGridViewRow In dgCustomers.SelectedRows
                Dim workerid As Integer = dr.Cells(1).Value
                Try
                    objWorker.Update_field(Database_Table_code_class_tblWorkers.FieldName.Status, "De-active", "WorderID=" & workerid.ToString)
                    cc += 1
                Catch ex As Exception
                End Try
            Next
            If cc >= 1 Then
                MsgBox("De-activated", MsgBoxStyle.Information, "Info")
                RefreshDG()
            Else
                MsgBox("Not De-activated. Please check whether SP is logged in or has active booking or not.", MsgBoxStyle.Information, "Info")
            End If

        Else

        End If

 
    End Sub
End Class