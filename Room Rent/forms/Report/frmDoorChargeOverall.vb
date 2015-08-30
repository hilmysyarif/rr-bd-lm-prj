Public Class frmDoorChargeOverall
    Dim objReports As New cls_Reports
    Sub refreshDOOROverall(Optional ByVal rptDateFrom As Date = Nothing, Optional ByVal rptDateTo As Date = Nothing)
        Try
            dgDoorOverall.DataSource = Nothing
            dgDoorOverall.Columns.Clear()
            Dim d1 As Date = Nothing
            Dim d2 As Date = Nothing

            If rptDateFrom = Nothing Then
                If Now.Hour < 9 Then
                    d1 = Today.AddDays(-1)
                Else
                    d1 = Today
                End If
            Else
                d1 = rptDateFrom
            End If

            If rptDateTo = Nothing Then
                If Now.Hour < 9 Then
                    d2 = Today.AddDays(-1)
                Else
                    d2 = Today
                End If
            Else
                d2 = rptDateTo
            End If

            dgDoorOverall.DataSource = objReports.DoorOverall(d1, d2)


            dgDoorOverall.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgDoorOverall.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            For Each c As DataGridViewColumn In dgDoorOverall.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgDoorOverall.Columns.Add(New DataGridViewTextBoxColumn)
            dgDoorOverall.Columns(dgDoorOverall.ColumnCount - 1).HeaderText = " "
            dgDoorOverall.Columns(dgDoorOverall.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        refreshDOOROverall(dtpOvFrom.Value, dtpOvTo.Value)
    End Sub

    Private Sub frmDoorChargeOverall_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Now.Hour > 9 Then
            dtpOvFrom.Value = Today.AddHours(9)
            dtpOvTo.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            dtpOvFrom.Value = Today.AddDays(-1).AddHours(9)
            dtpOvTo.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If

        TopMost = IsAllTopMostForm
        refreshDOOROverall(dtpOvFrom.Value, dtpOvTo.Value)
    End Sub

End Class