Public Class frmWorkerLogin
    Dim objWorker As New cls_tblWorkers
    Dim objCheckIn As New cls_tblCheckIN
    Dim selectedWorkerID As Integer = 0
    Dim selecteddcdate As Date = Now
    Dim _filename As String = ""
    Private Sub frmWorkerLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        objWorker.LoadWorkerInListView(lstActiveProvider, cls_tblWorkers.SelectionType.NOT_AVAILABLE, txtSPName.Text)
        lblDCDate.Text = ""
        btnLogin.Enabled = False
    End Sub

    Dim totd As Integer = 0
    Dim fl As String = ""

    Private Sub lstActiveProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstActiveProvider.SelectedIndexChanged
        If lstActiveProvider.SelectedItems.Count > 0 Then
            Dim workerid As String = lstActiveProvider.SelectedItems(0).Tag
            selectedWorkerID = workerid
            Dim dt As DataTable = objWorker.Selection1(cls_tblWorkers.SelectType.All, "Where [Workerid]=" & workerid)
            Dim dr As DataRow = dt.Rows(0)
            selecteddcdate = CDate(dr("dc_date"))
            totd = Math.Floor((selecteddcdate.AddMonths(3) - Now).TotalDays)
            If totd <= 0 Then
                lblDCDate.ForeColor = Color.Red
                totd = -totd
                lblDCDate.Text = "Issued Date : " & selecteddcdate.ToShortDateString + vbNewLine + "Expired " + totd.ToString + " days ago"
                btnLogin.Enabled = True
            Else
                lblDCDate.ForeColor = Color.Green
                lblDCDate.Text = "Issued Date : " & selecteddcdate.ToShortDateString + vbNewLine + totd.ToString + " days left to expire"
                btnLogin.Enabled = True
            End If
            fl = ""
            fl = objWorker.LoadLastestDC_File(selectedWorkerID)
            WebBrowser1.Navigate(fl) 
        End If
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Logonin()

        'Close()
    End Sub
    Sub Logonin()
        If fl <> "" And totd < 0 Then
            MsgBox("DC expired", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If lstActiveProvider.SelectedItems.Count > 0 And selectedWorkerID > 0 Then
            objCheckIn.CheckIn(selectedWorkerID, "", Now, selecteddcdate, "")
            lstActiveProvider.Items.Remove(lstActiveProvider.SelectedItems(0))
            frmHome.Loadings()
        Else
            MsgBox("Select a SP", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDC.Click

        'Dim openFiled As New OpenFileDialog
        'openFiled.Filter = "PDF Files|*.pdf"
        'If openFiled.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    _filename = openFiled.FileName
        '    Dim objCustomer As New cls_tblWorkers
        '    objCustomer.CheckIn(selectedWorkerID, "", Now, Now, _filename)
        '    WebBrowser1.Navigate(_filename)
        'End If
        'Dim frm As New frmCheckIn2
        'frm.WorkerID = selectedWorkerID
        'frm.ShowDialog()
        'frmNewHome01.Loadings()
        'Close()
        Close()
    End Sub

    Private Sub btnLogin_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.EnabledChanged
        'btnAddDC.Enabled = Not btnLogin.Enabled
    End Sub

    Private Sub btnNewSp_Click(sender As System.Object, e As System.EventArgs) Handles btnNewSp.Click
        Dim frmp = New frmCreateWorker
        'AddHandler frmp.FormClosed, AddressOf frmPeople
        frmp.ShowDialog()
        objWorker.LoadWorkerInListView(lstActiveProvider, cls_tblWorkers.SelectionType.NOT_AVAILABLE)
    End Sub

    Private Sub txtSPName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSPName.TextChanged
        objWorker.LoadWorkerInListView(lstActiveProvider, cls_tblWorkers.SelectionType.NOT_AVAILABLE, txtSPName.Text)
    End Sub

    Private Sub lstActiveProvider_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lstActiveProvider.DoubleClick
        Logonin()
    End Sub
End Class