Public Class frmShowSpDC
    Dim objWorker As New cls_tblWorkers
    Public selectedWorkerID As Integer = 0
    Dim fl As String = ""
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAddDC_Click(sender As System.Object, e As System.EventArgs) Handles btnAddDC.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmShowSpDC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fl = ""
        fl = objWorker.LoadLastestDC_File(selectedWorkerID)
        If fl = "" Then
            MsgBox(" No DC File ", MsgBoxStyle.Information, "Info")
        End If
        WebBrowser1.Navigate(fl)
    End Sub
End Class