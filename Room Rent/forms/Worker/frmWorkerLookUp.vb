Public Class frmWorkerLookUp
    Inherits Form

    Dim objCustomer As New cls_tblWorkers

    Dim frmp As frmCreateWorker

    'Dim frmc As frmCheckIn2

    Dim custId As Integer = 0
    'Dim vCustName As String
    Property custName As String
        Set(ByVal value As String)
            'vCustName = value
            lnlCust.Text = value
        End Set
        Get
            Return lnlCust.Text 'vCustName
        End Get
    End Property


    Private Sub btnAddPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPeople.Click

        'Me.Hide()
        frmp = New frmCreateWorker
        AddHandler frmp.FormClosed, AddressOf frmPeople
        frmp.ShowDialog()

    End Sub

    Private Sub frmCheckIn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LoadCust()
        'frmHome.Show()
    End Sub

    Private Sub frmCheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        LoadCust()
    End Sub

    Sub LoadCust()
        objCustomer.LoadWorkerInListView(lstAvailable, cls_tblWorkers.SelectionType.ALL)
        objCustomer.LoadWorkerInListView(LstDC_14_Days, cls_tblWorkers.SelectionType.DC_14_DAYS)
        objCustomer.LoadWorkerInListView(LstNotUpdated, cls_tblWorkers.SelectionType.DC_EXPIRED)
        objCustomer.LoadWorkerInListView(LstSuspended, cls_tblWorkers.SelectionType.SUSPENDED)
        'objCustomer.LoadWorker(LstSuspended, cls_tblWorkers.SelectionType.SUSPENDED)
    End Sub

    Private Sub frmPeople()
        LoadCust()
    End Sub

    Private Sub lstAvailable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAvailable.SelectedIndexChanged
        Try
            custId = lstAvailable.SelectedItems(0).Tag
        Catch ex As Exception
        End Try
        Try
            custName = lstAvailable.SelectedItems(0).Text
        Catch ex As Exception
            custName = ""
        End Try
    End Sub

    Private Sub LstDC_14_Days_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDC_14_Days.SelectedIndexChanged
        Try
            custId = LstDC_14_Days.SelectedItems(0).Tag
        Catch ex As Exception
        End Try
        Try
            custName = LstDC_14_Days.SelectedItems(0).Text
        Catch ex As Exception
            custName = ""
        End Try
    End Sub

    Private Sub LstNotUpdated_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstNotUpdated.SelectedIndexChanged
        Try
            custId = LstNotUpdated.SelectedItems(0).Tag
        Catch ex As Exception
        End Try
        Try
            custName = LstNotUpdated.SelectedItems(0).Text
        Catch ex As Exception
            custName = ""
        End Try
    End Sub

    Private Sub LstSuspended_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstSuspended.SelectedIndexChanged
        Try
            custId = LstSuspended.SelectedItems(0).Tag
        Catch ex As Exception
        End Try
        Try
            custName = LstSuspended.SelectedItems(0).Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bttn_Checkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bttn_Checkin.Click
        'Me.Hide()

        'If lnlCust.Text = "" Then
        '    MsgBox("Please select a Customer/Person to checkin", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If

        'frmc = New frmCheckIn2
        'AddHandler frmc.FormClosed, AddressOf frmPeople
        'frmc.lblCust.Text = lnlCust.Text
        'frmc.WorkerID = custId
        'frmc.ShowDialog()

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Close()
    End Sub
End Class
