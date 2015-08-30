Public Class frmSuspensions
    Public objActiveWorkers As New cls_tblActiveWorker
    Private Sub frmSuspensions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objActiveWorkers.LoadWorkersInDG(dgActiveBooking, cls_tblActiveWorker.WorkerTypeDG.Suspended)
        TopMost = IsAllTopMostForm
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
                        objActiveWorkers.tblActiveWorker_Update_By_BookingID(BookingID, "")
                        objActiveWorkers.LoadWorkersInDG(dgActiveBooking, cls_tblActiveWorker.WorkerTypeDG.Suspended)
                End Select
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub


End Class