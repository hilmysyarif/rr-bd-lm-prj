Public Class frmAddMerchandise
    Dim objProduct As New cls_Temp_tblProducts
    Dim UpdateID As Integer = 0
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If txtProduct.Text.Trim = "" Then
                MsgBox("Enter a product name", MsgBoxStyle.Information, "info")
                Exit Sub
            End If
            If txtCode.Text.Trim = "" Then
                MsgBox("Enter a product code", MsgBoxStyle.Information, "info")
                Exit Sub
            End If
            If Val(txtPrice.Text) < 0 Then
                MsgBox("Enter valid price", MsgBoxStyle.Information, "info")
                Exit Sub
            End If

            If txtExpireType.SelectedIndex <> 0 Then
                If Val(txtExpire.Text) < 0 Then
                    MsgBox("Enter valid expire time", MsgBoxStyle.Information, "info")
                    Exit Sub
                End If
            End If
            If btnSave.Text = "Save" Then
                objProduct.Insert(txtProduct.Text, _
                                            txtProductCategory.Text, _
                                            txtBrand.Text, _
                                            Val(txtPrice.Text), _
                                            txtUnit.Text,
                                            Val(txtTAX.Text),
                                            txtBarcode.Text,
                                            Val(txtExpire.Text),
                                            txtExpireType.Text,
                                            Val(txtMinimumStock.Text), Now, txtCode.Text)
                MsgBox("Saved", MsgBoxStyle.Information, "Info")
            Else
                objProduct.Update(txtProduct.Text, _
                                            txtProductCategory.Text, _
                                            txtBrand.Text, _
                                            Val(txtPrice.Text), _
                                            txtUnit.Text,
                                            Val(txtTAX.Text),
                                            txtBarcode.Text,
                                            Val(txtExpire.Text),
                                            txtExpireType.Text,
                                            Val(txtMinimumStock.Text), Now, txtCode.Text, UpdateID)
                MsgBox("Updated", MsgBoxStyle.Information, "Info")
            End If


            refreshDG()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Sub refreshDG()
        dgProducts.DataSource = objProduct.Selection(cls_Temp_tblProducts.SelectionType.All)
    End Sub

    Sub clear()
        txtProduct.Clear()
        txtCode.Clear()
        txtPrice.Clear()
        txtUnit.Text = ""
        txtTAX.Clear()
        txtBarcode.Clear()
        txtExpire.Clear()
        txtExpireType.Text = "NA"
        txtMinimumStock.Clear()

        btnSave.Text = "Save"
        Dim dt As DataTable = objProduct.SelectDistinct(Database_Table_code_class_tblProducts.FieldName.Category, " [Category]<>''")
        txtProductCategory.DataSource = dt
        txtProductCategory.DisplayMember = "Category"

        Dim dt2 As DataTable = objProduct.SelectDistinct(Database_Table_code_class_tblProducts.FieldName.Brand, " [Brand]<>''")
        txtBrand.DataSource = dt2
        txtBrand.DisplayMember = "Brand"

        txtProductCategory.Text = ""
        txtBrand.Text = ""

    End Sub

    Private Sub dgProducts_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgProducts.SelectionChanged
        btnDelete.Enabled = dgProducts.RowCount >= 1
    End Sub

    Private Sub frmAddMerchandise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear()
        refreshDG()
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub txtExpireType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpireType.SelectedIndexChanged
        txtExpire.Enabled = txtExpireType.SelectedIndex <> 0
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objProduct.Delete_By_RowID(dgProducts.SelectedRows(0).Cells(0).Value)
            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
            refreshDG()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
    Public ReadOnly Property tblProducts_select
        Get
            Return <tblProducts_select><![CDATA[
SELECT 
      [ProductID],
      [ProductName],
      [Category],
      [Brand],
      [Price],
      [Unit],
      [Tax],
      [Barcode],
      [ExpireIn],
      [ExpireInType],
      [MinimumStock],
      [EntryDate],
      [CodeName]
FROM [tblProducts]
    WHERE 1=1
]]></tblProducts_select>.Value
        End Get
    End Property
    Private Sub dgProducts_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProducts.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                txtProduct.Text = dgProducts.Rows(e.RowIndex).Cells("ProductName").Value
                txtProductCategory.Text = dgProducts.Rows(e.RowIndex).Cells("Category").Value
                txtBrand.Text = dgProducts.Rows(e.RowIndex).Cells("Brand").Value
                txtPrice.Text = dgProducts.Rows(e.RowIndex).Cells("Price").Value
                txtUnit.Text = dgProducts.Rows(e.RowIndex).Cells("Unit").Value
                txtTAX.Text = dgProducts.Rows(e.RowIndex).Cells("Tax").Value
                txtBarcode.Text = dgProducts.Rows(e.RowIndex).Cells("Barcode").Value
                txtExpireType.Text = dgProducts.Rows(e.RowIndex).Cells("ExpireInType").Value
                txtExpire.Text = dgProducts.Rows(e.RowIndex).Cells("ExpireIn").Value
                txtMinimumStock.Text = dgProducts.Rows(e.RowIndex).Cells("MinimumStock").Value
                Try
                    txtCode.Text = ""
                    txtCode.Text = dgProducts.Rows(e.RowIndex).Cells("CodeName").Value
                Catch ex As Exception
                End Try
                UpdateID = dgProducts.Rows(e.RowIndex).Cells("ProductID").Value
                btnSave.Text = "Update"
            End If
        End If
    End Sub

End Class