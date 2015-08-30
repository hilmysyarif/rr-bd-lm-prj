Public Class frmMAP
    Dim objRooms As New cls_Temp_tblRoom
    Public AllButtons As List(Of Button)

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadRooms()
        AllButtons = New List(Of Button) From {btnRoom01, btnRoom02, btnRoom03, btnRoom04, btnRoom05, btnRoom06, btnRoom07, btnRoom08, btnRoom09, btnRoom10, btnRoom11, btnRoom12, btnRoom13, btnRoom14, btnRoom15}
    End Sub
    Function getControl(cont As ContainerControl, _name As String) As Control
        For Each c As Control In cont.Controls
            If c.HasChildren Then
                Dim c1 As Control = getControl(c, _name)
                If Not c1 Is Nothing Then
                    Return c1
                End If
            ElseIf c.Name = _name Then
                Return c 
            End If
        Next
        Return Nothing
    End Function
    Function getControl(cont As Control, _name As String) As Control
        For Each c As Control In cont.Controls
            If c.HasChildren Then
                Dim c1 As Control = getControl(c, _name)
                If Not c1 Is Nothing Then
                    Return c1
                End If
            ElseIf c.Name = _name Then
                Return c
            End If
        Next
        Return Nothing
    End Function
    Sub LoadRooms()
        'Dim objRooms As New cls_tblRoom
        For Each dr As DataRow In objRooms.Selection().Rows
            If dr("Room").ToString <> "ESCORT" Then
                Dim c1 As Control = getControl(Me, "btnRoom" & Val(dr("Sl")).ToString("00"))
                c1.Tag = dr("Room").ToString & ":" & dr("FullName").ToString & ":" & c1.Tag.ToString.Split(":")(2).Trim
                c1.Text = dr("FullName").ToString
            End If
        Next
    End Sub

    Public Sub SetButtonVisible()
        'If isSite2ButtonsVisible Then
        '    tlpRoom.ColumnStyles(5).Width = 50
        '    tlpRoom.ColumnStyles(5).Width = 25
        '    tlpRoom.ColumnStyles(6).Width = 20
        '    tlpRoom.ColumnStyles(7).Width = 25
        'Else
        '    tlpRoom.ColumnStyles(5).Width = 0
        '    tlpRoom.ColumnStyles(6).Width = 0
        '    tlpRoom.ColumnStyles(7).Width = 0
        '    tlpRoom.ColumnStyles(8).Width = 0
        'End If
        btnRoom10.Visible = isSite2ButtonsVisible
        btnRoom11.Visible = isSite2ButtonsVisible
        btnRoom12.Visible = isSite2ButtonsVisible
        btnRoom13.Visible = isSite2ButtonsVisible
        btnRoom14.Visible = isSite2ButtonsVisible
        btnRoom15.Visible = isSite2ButtonsVisible
    End Sub
    Private Sub frmMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        tmrRefreshRoomStatus.Start()
    End Sub

    Public Sub ResetDisabledRoomText()
        For Each co As Button In grpRoom_GC.Controls
            If co.Tag.ToString.Split(":")(2) = "NO" Then
                co.Text = co.Tag.ToString.Split(":")(1)
            End If
        Next
    End Sub

    Private Sub frmMap_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetButtonVisible()
        frmHome.CHeckRoomStatus()
        tmrRefreshRoomStatus.Start()
    End Sub
    Private Sub btnRoom01_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRoom01.MouseDown, btnRoom02.MouseDown, btnRoom03.MouseDown, btnRoom04.MouseDown, btnRoom05.MouseDown, btnRoom06.MouseDown, btnRoom07.MouseDown, btnRoom08.MouseDown, btnRoom09.MouseDown, btnRoom10.MouseDown, btnRoom11.MouseDown, btnRoom12.MouseDown, btnRoom13.MouseDown, btnRoom14.MouseDown, btnRoom15.MouseDown
        If e.Clicks = 2 Then
            ShowStatusWindow(sender)
        End If
    End Sub

    Private Sub btnRoom01_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRoom01.MouseUp, btnRoom02.MouseUp, btnRoom03.MouseUp, btnRoom04.MouseUp, btnRoom05.MouseUp, btnRoom06.MouseUp, btnRoom07.MouseUp, btnRoom08.MouseUp, btnRoom09.MouseUp, btnRoom10.MouseUp, btnRoom11.MouseUp, btnRoom12.MouseUp, btnRoom13.MouseUp, btnRoom14.MouseUp, btnRoom15.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right And e.Clicks = 1 Then
            ShowStatusWindow(sender)
        End If
    End Sub

    Sub ShowStatusWindow(ByVal sender As Object)
        If sender.backcolor <> grpRoom_GC.BackColor And sender.backcolor <> NotUseableRooms(0) Then
            MsgBox("Please reset the room first to set the room status", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim frm As New dlgRoomStatus
        Try
            Dim dtNotUsableRooms As DataRow = frmHome.objRoom.Selection(cls_Temp_tblRoom.SelectionType.All, "[ROOM]='" & sender.tag.ToString.Split(":")(0).Trim & "'").Rows(0)
            frm.cmbStatus.Text = dtNotUsableRooms("Status")
            frm.cmbUsable.Text = dtNotUsableRooms("Usable")
            frm.txtComment.Text = dtNotUsableRooms("Comment")
        Catch ex As Exception
        End Try

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                objRooms.Update_Status(sender.tag.ToString.Split(":")(0), frm.cmbStatus.Text, frm.cmbUsable.Text, frm.txtComment.Text, Now, frm.NumericUpDown1.Value)
                RefreshMapRooms()
                If frm.cmbUsable.Text = "YES" Then
                    sender.text = sender.tag.ToString.Split(":")(1)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Sub RefreshMapRooms()
        frmHome.CHeckRoomStatus()
        ' frmHome.ClearAllRoomColors()
        frmHome.RefreshRoomColor()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshRoomStatus.Tick
        RefreshMapRooms()
    End Sub
End Class