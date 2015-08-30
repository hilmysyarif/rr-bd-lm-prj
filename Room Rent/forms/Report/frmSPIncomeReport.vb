Public Class frmSPIncomeReport
    Dim objReports As New cls_Reports

    Sub refreshDailyWorkerWise(Optional ByVal rptDate As Date = Nothing)

        Try

            dgDailyWorkerWise.DataSource = Nothing
            dgDailyWorkerWise.Columns.Clear()

            If rptDate = Nothing Then
                If Now.Hour < 9 Then
                    dgDailyWorkerWise.DataSource = objReports.DailyWorkerWise(Today.AddDays(-1))
                Else
                    dgDailyWorkerWise.DataSource = objReports.DailyWorkerWise(Today)
                End If
            Else
                dgDailyWorkerWise.DataSource = objReports.DailyWorkerWise(rptDate.Date)
            End If

            dgDailyWorkerWise.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgDailyWorkerWise.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

            For Each c As DataGridViewColumn In dgDailyWorkerWise.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

            dgDailyWorkerWise.Columns.Add(New DataGridViewTextBoxColumn)
            dgDailyWorkerWise.Columns(dgDailyWorkerWise.ColumnCount - 1).HeaderText = " "
            dgDailyWorkerWise.Columns(dgDailyWorkerWise.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")

        End Try

    End Sub

    Private Sub frmWorkerIncomeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TopMost = IsAllTopMostForm
        refreshDailyWorkerWise()

    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged

        refreshDailyWorkerWise(DateTimePicker4.Value)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        refreshDailyWorkerWise(DateTimePicker4.Value)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim frm As New frmPrintList

        frm.PrintPreview(dgDailyWorkerWise, "Daily SP Wise Report", "Date : " & DateTimePicker4.Value.ToShortDateString, "", "", False, "", True)

    End Sub
End Class



