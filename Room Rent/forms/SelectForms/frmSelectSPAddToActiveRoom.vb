Public Class frmSelectSPAddToActiveRoom

    Dim lists As New List(Of Integer)

    Public multiselect As Boolean = False

    Private Sub frmNewBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgAvailableWorker.MultiSelect = multiselect
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If dgAvailableWorker.SelectedRows.Count = 0 Then
            MsgBox("Select atleast one SP", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub lstServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgAvailableWorker.CellClick
        If multiselect Then
            Try
                Dim selectIndex As Integer = dgAvailableWorker.SelectedRows(0).Index
                If lists.Contains(selectIndex) Then
                    lists.Remove(selectIndex)
                Else
                    lists.Add(selectIndex)
                End If
                For Each c As DataGridViewRow In dgAvailableWorker.Rows
                    c.Selected = lists.Contains(c.Index)
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        lists = New List(Of Integer)
        For Each dr As DataGridViewRow In dgAvailableWorker.Rows
            dr.Selected = True
            lists.Add(dr.Index)
        Next
    End Sub

    Private Sub frmSelectSPAddToActiveRoom_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If dgAvailableWorker.RowCount = 1 Then
            dgAvailableWorker.Rows(0).Selected = True
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub
End Class