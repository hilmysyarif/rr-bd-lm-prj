Public Class frmPremiumServices
    Dim objPremiumServices As New cls_Temp_tblPremiumServices

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            For i = 1 To 7
                Try
                    Dim dt As DataTable = objPremiumServices.Selection(cls_Temp_tblPremiumServices.SelectionType.All, "Weekday=" & i.ToString)
                    If dt.Rows.Count = 0 Then
                        Throw New Exception("")
                    End If
                    objPremiumServices.Update(dt.Rows(0).Item("ItemId"), i, CType(Me.Controls("txtpp" & i.ToString & i.ToString & i.ToString), NumericUpDown).Value, CType(Me.Controls("txtpp" & i.ToString), NumericUpDown).Value, CType(Me.Controls("txtpp" & i.ToString & i.ToString), NumericUpDown).Value)
                Catch ex As Exception
                    objPremiumServices.Insert(i, CType(Me.Controls("txtpp" & i.ToString & i.ToString & i.ToString), NumericUpDown).Value, CType(Me.Controls("txtpp" & i.ToString), NumericUpDown).Value, CType(Me.Controls("txtpp" & i.ToString & i.ToString), NumericUpDown).Value)
                End Try
            Next
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmPremiumServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim dt As DataTable = objPremiumServices.Selection()
            For Each dr As DataRow In dt.Rows
                CType(Me.Controls("txtpp" & dr("weekday").ToString), NumericUpDown).Value = dr("Sp")
                CType(Me.Controls("txtpp" & dr("weekday").ToString & dr("weekday").ToString), NumericUpDown).Value = dr("House")
                CType(Me.Controls("txtpp" & dr("weekday").ToString & dr("weekday").ToString & dr("weekday").ToString), NumericUpDown).Value = dr("Servicecharge")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpp1.ValueChanged, _
        txtpp11.ValueChanged, _
        txtpp2.ValueChanged, _
        txtpp22.ValueChanged, _
        txtpp3.ValueChanged, _
        txtpp33.ValueChanged, _
        txtpp4.ValueChanged, _
        txtpp44.ValueChanged, _
        txtpp5.ValueChanged, _
        txtpp55.ValueChanged, _
        txtpp6.ValueChanged, _
        txtpp66.ValueChanged, _
        txtpp7.ValueChanged, _
        txtpp77.ValueChanged
        Try
            txtpp111.Value = txtpp11.Value + txtpp1.Value
            txtpp222.Value = txtpp22.Value + txtpp2.Value
            txtpp333.Value = txtpp33.Value + txtpp3.Value
            txtpp444.Value = txtpp44.Value + txtpp4.Value
            txt555.Value = txtpp55.Value + txtpp5.Value
            txtpp666.Value = txtpp66.Value + txtpp6.Value
            txtpp777.Value = txtpp77.Value + txtpp7.Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub txt1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpp1.KeyUp, _
        txtpp11.KeyUp, _
        txtpp2.KeyUp, _
        txtpp22.KeyUp, _
        txtpp3.KeyUp, _
        txtpp33.KeyUp, _
        txtpp4.KeyUp, _
        txtpp44.KeyUp, _
        txtpp5.KeyUp, _
        txtpp55.KeyUp, _
        txtpp6.KeyUp, _
        txtpp66.KeyUp, _
        txtpp7.KeyUp, _
        txtpp77.KeyUp
        Try
            txtpp111.Value = txtpp11.Value + txtpp1.Value
            txtpp222.Value = txtpp22.Value + txtpp2.Value
            txtpp333.Value = txtpp33.Value + txtpp3.Value
            txtpp444.Value = txtpp44.Value + txtpp4.Value
            txt555.Value = txtpp55.Value + txtpp5.Value
            txtpp666.Value = txtpp66.Value + txtpp6.Value
            txtpp777.Value = txtpp77.Value + txtpp7.Value
        Catch ex As Exception

        End Try
    End Sub
End Class