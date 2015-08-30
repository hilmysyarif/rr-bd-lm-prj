Public Class frmRoom
    Public selectedRoom As String = "PEN"

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnPen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoom01.Click, btnRoom03.Click, btnRoom02.Click, btnRoom04.Click, btnRoom05.Click, btnRoom06.Click _
        , btnRoom07.Click, btnRoom08.Click, btnRoom09.Click, btnRoom10.Click, btnRoom11.Click, btnRoom12.Click, btnEscort.Click
        For Each c As Button In grpRoom.Controls
            c.BackColor = Nothing
            c.UseVisualStyleBackColor = True
        Next
        sender.backcolor = ActiveButton
        selectedRoom = sender.text
    End Sub

    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRoom01.BackColor = ActiveButton
    End Sub


End Class