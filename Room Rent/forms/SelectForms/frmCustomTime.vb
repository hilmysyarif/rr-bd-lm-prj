Public Class frmCustomTime
    Public Shift As String = "DAY"
    Public Room As String = "ROOM"
    Public SType As String = "STANDARD"
    Public Client As String = "1"
    Public SP As String = "1"


    Public SelectedTimes As New List(Of Integer)
    Public SelectedTime As Integer

    Dim objLook As New cls_tblLookUp

    Public bookingtype As String = "BOOKING"

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FindTotal()
        If SelectedTime <= 0 Then
            MsgBox("Select atleast one service time", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmCustomTime_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCustomBooking()
    End Sub

    Sub LoadCustomBooking()
        Try
            Dim objLookUp As New cls_tblLookUp
            dgCustom.AutoGenerateColumns = False
            Dim str As String = ""
            If Room = "ESCORT" And bookingtype = "bookingtype" Then
                str = " AND a.[Service] not in (5,10,15,20,30,45,90)"

            End If
            dgCustom.DataSource = objLookUp.Selection(cls_tblLookUp.SelectionType.ALL_INHRS, " [Type]='" & Shift & "' " & str & " AND a.[Service]<=360  AND Client=1 AND WORKER=1 AND [ServiceType]='" & SType & "' and [Room]='" & Room & "' and TotalAmount>0 Order By a.[Service],[Type],[ServiceType],[Worker],[Client]")
        Catch ex As Exception
        End Try
    End Sub

    Sub FindTotal()
        SelectedTime = 0
        SelectedTimes = New List(Of Integer)
        For Each dr As DataGridViewRow In DataGridView1.Rows
            SelectedTime += dr.Cells(1).Value
            SelectedTimes.Add(dr.Cells(1).Value)
        Next
        lblSelectedTime.Text = SelectedTime.ToString & " Mins"
    End Sub
    Private Sub dgCustom_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustom.CellClick
        Try
            DataGridView1.Rows.Add(dgCustom.Rows(e.RowIndex).Cells(0).Value, dgCustom.Rows(e.RowIndex).Cells(1).Value)
            FindTotal()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            DataGridView1.Rows.RemoveAt(e.RowIndex)
            FindTotal()
        Catch ex As Exception

        End Try

    End Sub
End Class