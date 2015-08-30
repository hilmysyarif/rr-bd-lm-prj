Public Class frmShowFavs

    Public WorkerId As Integer = 0
    Dim objWorkerFav As New cls_Temp_tblWorkerFavourites
    Dim dtFavorites As DataTable

    Private Sub frmShowFavs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub frmShowFavs_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        dtFavorites = objWorkerFav.Selection(cls_Temp_tblWorkerFavourites.SelectionType.All, "WorkerId =" & WorkerId.ToString)
        RefreshFavourites()
    End Sub

    Sub RefreshFavourites()
        dgFavorites.DataSource = dtFavorites
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.ItemId.ToString).Visible = False
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.WorkerId.ToString).Visible = False
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.ClientName.ToString).HeaderText = "Client Name"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.Mobile.ToString).HeaderText = "Mobile"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.Email.ToString).HeaderText = "Email"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.PreferedContactTime.ToString).HeaderText = "Prefered Contact Time"
        dgFavorites.Columns(cls_Temp_tblWorkerFavourites.FieldName.PrefereredContactMethod.ToString).HeaderText = "Prefered Contact Method"
        dgFavorites.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub dgFavorites_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFavorites.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                Dim naam As String = dgFavorites.Rows(e.RowIndex).Cells(cls_Temp_tblWorkerFavourites.FieldName.ClientName.ToString).Value
                Try
                    If naam.Split(" ")(0).Trim.Split.Length > 2 Then
                        naam = naam.Split(" ")(0).Trim
                    End If
                Catch ex As Exception
                End Try
                frmSMSDailog.RichTextBox2.Text = "Dear " & naam.Trim & ","
                If frmSMSDailog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim msg As String = frmSMSDailog.RichTextBox1.Text
                    If msg <> "" Then
                        Dim __List As New List(Of SMS_Client)
                        Dim __ListItem As New SMS_Client
                        __ListItem.MSG__ = frmSMSDailog.RichTextBox2.Text.Trim & vbNewLine & frmSMSDailog.RichTextBox1.Text.Trim
                        __ListItem.No__ = dgFavorites.Rows(e.RowIndex).Cells(cls_Temp_tblWorkerFavourites.FieldName.Mobile.ToString).Value
                        __List.Add(__ListItem)
                        Dim frm As New frmBulkSMS(__List)
                    End If
                End If
            ElseIf e.ColumnIndex = 0 Then
                Dim ObjMail As New clsGmail
                Dim response As String = ""
                Dim frm As New frmEmailAddress
                Dim naam As String = dgFavorites.Rows(e.RowIndex).Cells(cls_Temp_tblWorkerFavourites.FieldName.ClientName.ToString).Value
                frm.txtEmailAddress.Text = dgFavorites.Rows(e.RowIndex).Cells(cls_Temp_tblWorkerFavourites.FieldName.Email.ToString).Value
                frm.txtSubject.Text = "Reminder"
                frm.txtMessage.Text = "Dear " & naam.Trim & "," & vbNewLine
                If frm.ShowDialog = DialogResult.OK Then
                    If MyLocalSettings.EmailUserName Is Nothing OrElse MyLocalSettings.EmailUserName.Trim = "" Then
                        frmSetupEmail.ShowDialog()
                    End If
                    Try
                        Dim objEC As New clsEncryption
                        ObjMail.SendEmail(frm.txtEmailAddress.Text, frm.txtSubject.Text, frm.txtMessage.Text, "", MyLocalSettings.EmailUserName, objEC.Decrypt(MyLocalSettings.EmailPass), response, New List(Of String) From {frm.lblFileName.Text})
                        MsgBox(response, MsgBoxStyle.Information, "Info")
                    Catch ex As Exception
                        MsgBox("Error while sending message", MsgBoxStyle.Information, "info")
                    End Try
                End If
            End If
        End If
    End Sub
End Class