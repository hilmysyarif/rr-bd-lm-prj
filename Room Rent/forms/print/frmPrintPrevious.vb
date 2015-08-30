Public Class frmPrintPrevious
    Dim objDocket As New cls_Temp_tblDocketMemo

    Private Sub frmPrintPrevious_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        DataGridView1.DataSource = objDocket.Selection(cls_Temp_tblDocketMemo.SelectionType.LAST10)
        DataGridView1.Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                clsDocketPrint.ShowDocketMemo(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
            End If
            If e.ColumnIndex = 0 Then
                clsDocketPrint.PrintDocketMemo(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
            End If
        End If
    End Sub
End Class