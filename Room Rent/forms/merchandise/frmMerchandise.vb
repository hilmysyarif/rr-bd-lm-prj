Public Class frmMerchandise
    Inherits Form

    Dim objProduct As New cls_tblProducts
    Dim frmm As frmAddMerchandise

    Private Sub frmMerchandise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshCategory()
    End Sub

    Sub RefreshCategory()
        dgCategory.DataSource = objProduct.Selection(cls_tblProducts.SelectionType.DISTINCT_CATEGORY)
        For Each dgr As DataGridViewRow In dgCategory.Rows
            dgr.Height = 50
            dgr.Selected = False
        Next
    End Sub

    Sub RefreshProduct(ByVal Category As String)
        dgProducs.DataSource = objProduct.Selection(cls_tblProducts.SelectionType.SELECT_PRODUCT, "WHERE [Category]='" & Category & "'")
        dgProducs.Columns(0).Visible = False
        For Each dgr As DataGridViewRow In dgProducs.Rows
            dgr.Height = 50
            dgr.Selected = False
        Next
    End Sub

    Private Sub btnItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItems.Click
        frmm = New frmAddMerchandise
        AddHandler frmm.FormClosed, AddressOf frmAD_closed
        frmm.Show()
        frmm.Activate()
    End Sub

    Private Sub frmAD_closed()
        RefreshCategory()
    End Sub

    Private Sub dgCategory_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCategory.CellClick
        If e.RowIndex >= 0 Then
            RefreshProduct(dgCategory.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class