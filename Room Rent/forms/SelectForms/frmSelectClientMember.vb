Public Class frmSelectClientMember
    Public CustName As String = ""
    Public Phone As String = ""
    Public MemberID As String = ""
    Private Sub frmNewBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim obj As New cls_tblBookings
        'lstServiceProvider.Items.Clear()
        'For Each dr As DataRow In obj.Selection(cls_tblBookings.SelectionType.DISTINCT_CLIENT).Rows
        '    Dim li As New ListViewItem
        '    li.Text = dr("CustomerName").ToString
        '    li.Tag = dr("Phone").ToString
        '    lstServiceProvider.Items.Add(li)
        'Next
        TopMost = IsAllTopMostForm
    End Sub
    'Private Sub btnAddServiceProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddServiceProvider.Click
    '    Dim li As New ListViewItem
    '    li.Text = txtName.Text
    '    li.Tag = txtPhone.Text
    '    lstServiceProvider.Items.Add(li)
    'End Sub

    'Private Sub lstServiceProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServiceProvider.SelectedIndexChanged
    '    Try
    '        Phone = lstServiceProvider.SelectedItems(0).Tag
    '    Catch ex As Exception
    '        Phone = ""
    '    End Try
    '    Try
    '        lblServiceProvider.Text = lstServiceProvider.SelectedItems(0).Text & IIf(Phone <> "", " (" + Phone + ")", "")
    '        CustName = lstServiceProvider.SelectedItems(0).Text
    '    Catch ex As Exception
    '        lblServiceProvider.Text = ""
    '        CustName = ""
    '    End Try
    'End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'If lblServiceProvider.Text = "" Then
        '    MsgBox("Select a Customer", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        If TextBox1.Text <> "" Then
            Find()
        End If
        If txtName.Text = "" Then
            MsgBox("Enter Customer Name", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtPhone.Text = "" Then
            MsgBox("Enter Customer Phone#", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        CustName = txtName.Text
        Phone = txtPhone.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Try
    '        lstServiceProvider.Items.Remove(lstServiceProvider.SelectedItems(0))
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Find()
    End Sub
    Sub Find()
        Try
            Dim objmem As New cls_tblMembers
            Dim pp As New List(Of SqlParameter)
            pp.Add(New SqlParameter("@MemberID", TextBox1.Text.Trim))
            Dim dt As DataTable = objmem.Selection(cls_tblMembers.SelectionType.ALL, "MemberID=@MemberID", pp)
            If dt.Rows.Count > 0 Then
                txtName.Text = dt.Rows(0).Item("Name").ToString
                txtPhone.Text = dt.Rows(0).Item("Phone").ToString
                MemberID = dt.Rows(0).Item("MemberID").ToString
            Else
                MsgBox("Not found !!!", MsgBoxStyle.Information, "Info")
                txtName.Text = ""
                txtPhone.Text = ""
                MemberID = ""

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class