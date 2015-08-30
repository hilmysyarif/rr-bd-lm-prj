Public Class dlgMembership
    Public MemberID As String = ""
    Dim objMember As New cls_tblMembers

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MemberID = "" Or txtMemberID.Text = "" Then
            MsgBox("Please enter a valid Menmder ID", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MemberID = ""
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub txtMemberID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemberID.TextChanged
        Try
            Dim dt As DataTable
            Dim pp As New List(Of SQLParameter)
            pp.Add(New SQLParameter("@MemberID", txtMemberID.Text))
            dt = objMember.Selection(cls_tblMembers.SelectionType.ALL, "MemberID=@MemberID", pp)
            If dt.Rows.Count = 0 Then
                Label2.Text = "**Not Found**"
                MemberID = ""
            Else
                Label2.Text = dt.Rows(0).Item("Name").ToString
                MemberID = txtMemberID.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dlgMembership_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TopMost = IsAllTopMostForm

    End Sub
End Class