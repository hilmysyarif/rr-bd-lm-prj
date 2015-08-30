Public Class frmSelectSPClearFinished
    Dim lists As New List(Of Integer)
    Public isMultiple As Boolean = True

    Private Sub frmNewBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If lstServiceProvider.SelectedItems.Count = 0 Then
            MsgBox("Select atleast a one item", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = vbOK
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub lstServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServiceProvider.Click
        If isMultiple Then
            Try
                Dim selectIndex As Integer = lstServiceProvider.SelectedItems(0).Index
                If lists.Contains(selectIndex) Then
                    lists.Remove(selectIndex)
                Else
                    lists.Add(selectIndex)
                End If
                'lstServiceProvider.SelectedItems.Clear()
                'For Each s As Integer In lists
                '    lstServiceProvider.Items(s).Selected = True
                'Next
                For Each c As ListViewItem In lstServiceProvider.Items
                    c.Selected = lists.Contains(c.Index)
                Next
                Application.DoEvents()
            Catch ex As Exception
            End Try
        End If

    End Sub
End Class