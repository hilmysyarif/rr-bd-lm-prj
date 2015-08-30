Public Class frmCheckIn2
    Inherits frmMaster
    Public WorkerID As Integer = 0
    Private Sub frmCheckIn2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Now.ToString
    End Sub

    Sub SelectRoom(ByVal RoomNo As String)
        If lblFileName.Text = "" Then
            MsgBox("Please select a file", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'If MonthCalendar1.SelectionStart < Today.AddDays(-14) Then
        '    MsgBox("DC Expired. Please enter a new DC", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        Dim objCustomer As New cls_tblWorkers
        objCustomer.CheckIn(WorkerID, RoomNo, Now, MonthCalendar1.SelectionStart, lblFileName.Text)
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click

        Dim openFiled As New OpenFileDialog
        openFiled.Filter = "PDF Files|*.pdf"
        If openFiled.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lblFileName.Text = openFiled.FileName
        End If

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        SelectRoom("")
    End Sub
End Class