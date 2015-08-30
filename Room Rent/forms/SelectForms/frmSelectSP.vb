Public Class frmSelectSP
    Public WorkerID As Integer = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Dim obj As New cls_tblWorkers
        obj.LoadWorkerInListView(lstServiceProvider, cls_tblWorkers.SelectionType.AvailableWithoutLogin, Now)

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmNewBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadServiceProvider(lstServiceProvider)
        TopMost = IsAllTopMostForm
        ' lstServiceProvider.AutoScrollOffset
    End Sub
    'Private Sub btnAddServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddServiceProvider.Click
    '    If txtNewServiceProviderName.Text = "" Then MsgBox("You must enter a SP name")
    '    If txtNewServiceProviderName.Text <> "" Then
    '        lstServiceProvider.Items.Add(txtNewServiceProviderName.Text)
    '        Dim objServiceProvider As New cls_tblServiceProvider
    '        objServiceProvider.Insert(txtNewServiceProviderName.Text)
    '        txtNewServiceProviderName.Text = ""
    '    End If
    'End Sub

    'Private Sub btnDeleteServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteServiceProvider.Click
    '    For I As Integer = 0 To lstServiceProvider.SelectedItems.Count - 1
    '        lstServiceProvider.Items.Remove(lstServiceProvider.Items(lstServiceProvider.SelectedIndices(I)))
    '    Next I
    '    lstServiceProvider.Items.Remove(lstServiceProvider.SelectedItems(0))
    '    txtNewServiceProviderName.Text = ""
    'End Sub
    Private Sub lstServiceProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServiceProvider.SelectedIndexChanged

        Try
            WorkerID = lstServiceProvider.SelectedItems(0).Tag
        Catch ex As Exception
        End Try
        Try
            lblServiceProvider.Text = lstServiceProvider.SelectedItems(0).Text
        Catch ex As Exception
            lblServiceProvider.Text = ""
        End Try
        If lstServiceProvider.SelectedItems.Count > 0 Then
            lblServiceProvider.Text = lstServiceProvider.SelectedItems(0).Text
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If lblServiceProvider.Text = "" Then
            MsgBox("Select a SP", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub
End Class