Public Class frmDoorReport
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Now.Hour > 9 Then
            DateTimePicker1.Value = Today.AddHours(9)
            DateTimePicker2.Value = Today.AddDays(1).AddHours(8).AddMinutes(59).AddSeconds(59)
        Else
            DateTimePicker1.Value = Today.AddDays(-1).AddHours(9)
            DateTimePicker2.Value = Today.AddHours(8).AddMinutes(59).AddSeconds(59)
        End If
    End Sub
    Dim objInstant As New cls_Temp_tblInstant

    Private Sub frmMerchandiseReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub ShowReport()
        Try
            dgReport.DataSource = Nothing
            dgReport.Columns.Clear()
            Dim pp As New List(Of SqlParameter)
            pp.Add(New SqlParameter("@d1", SqlDbType.DateTime) With {.Value = DateTimePicker1.Value})
            pp.Add(New SqlParameter("@d2", SqlDbType.DateTime) With {.Value = DateTimePicker2.Value})
            'dgReport.DataSource = objReports.DailyReportBookings2(, )
            dgReport.DataSource = objInstant.Selection(cls_Temp_tblInstant.SelectionType.report, "[InstantDate] between @d1 and @d2", pp)

            dgReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgReport.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            For Each c As DataGridViewColumn In dgReport.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgReport.Columns.Add(New DataGridViewTextBoxColumn)
            dgReport.Columns(dgReport.ColumnCount - 1).HeaderText = " "
            dgReport.Columns(dgReport.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            ' dgReport.Columns("Status").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Info")
        End Try
    End Sub


    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click
        ShowReport()
    End Sub
End Class