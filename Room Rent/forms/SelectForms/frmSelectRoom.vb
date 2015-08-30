Public Class frmSelectRoom
    Public selectedRoom As String = ""
    Public isENableROom As Boolean = True
    'Public selectedRoomPerMinuteCost As String = "0.00"

    Public ExcludeRoom As String = ""
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        LoadRooms()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadRooms()
        Dim objRooms As New cls_Temp_tblRoom
        For Each dr As DataRow In objRooms.Selection().Rows
            If dr("Sl") <> 16 Then
                grpRoom.Controls("btnRoom" & Val(dr("Sl")).ToString("00")).Tag = dr("Room").ToString '& ":" & dr("FullName").ToString & ":YES"
                grpRoom.Controls("btnRoom" & Val(dr("Sl")).ToString("00")).Text = dr("Room").ToString
            End If
        Next
    End Sub

    Sub SelectRoom(_Room As String)
        For Each c As Button In grpRoom.Controls
            If c.Enabled Then
                If c.Text.Trim.ToUpper = _Room.Trim.ToUpper Then
                    c.BackColor = ActiveButton
                    selectedRoom = c.Text
                End If
            End If
        Next
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If selectedRoom = "" Then
            MsgBox("Select a Room", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnPen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoom01.Click, btnRoom03.Click, btnRoom02.Click, btnRoom04.Click, btnRoom05.Click, btnRoom06.Click, btnRoom07.Click, btnRoom08.Click, btnRoom09.Click, btnRoom10.Click, btnRoom11.Click, btnRoom12.Click, btnEscort.Click, btnRoom15.Click, btnRoom14.Click, btnRoom13.Click, btnPending.Click
        For Each c As Button In grpRoom.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
        frmHome.CheckRoomValidity(isENableROom, Me, ExcludeRoom)
        sender.backcolor = ActiveButton
        selectedRoom = sender.text
        'selectedRoomPerMinuteCost = sender.tag
    End Sub

    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case MySettings.OtherSettings.RoomType
            Case "6 ROOMS"
                Only6Buttons(False)
                Only9Buttons(False)
            Case "9 ROOMS"
                Only6Buttons(True)
                Only9Buttons(False)
            Case "15 ROOMS"
                Only6Buttons(True)
                Only9Buttons(True)
                SetButtonVisible()
        End Select

        TopMost = IsAllTopMostForm
    End Sub

    Sub SetEscortVisible()
        If Not MySettings.OtherSettings.EscortService Then

            btnEscort.Visible = False
            btnPending.Location = New Point(59, 358)
            btnPending.Size = New Size(490, 51)

        End If
    End Sub
    Public Sub SetButtonVisible()
        Only9Buttons(isSite2ButtonsVisible)
        SetEscortVisible()
    End Sub
    Sub Only9Buttons(IsVisible As Boolean)
        btnRoom10.Visible = IsVisible
        btnRoom11.Visible = IsVisible
        btnRoom12.Visible = IsVisible
        btnRoom13.Visible = IsVisible
        btnRoom14.Visible = IsVisible
        btnRoom15.Visible = IsVisible
        If IsVisible Then

            btnRoom01.Width = 158
            btnRoom02.Width = 158
            btnRoom03.Width = 158
            btnRoom04.Width = 158
            btnRoom05.Width = 158
            btnRoom06.Width = 158
            btnRoom07.Width = 158
            btnRoom08.Width = 158
            btnRoom09.Width = 158
            btnRoom06.Left = 225
            btnRoom07.Left = 225
            btnRoom08.Left = 225
            btnRoom09.Left = 225

        Else

            btnRoom01.Width = 242
            btnRoom02.Width = 242
            btnRoom03.Width = 242
            btnRoom04.Width = 242
            btnRoom05.Width = 490
            btnRoom06.Width = 242
            btnRoom07.Width = 242
            btnRoom08.Width = 242
            btnRoom09.Width = 242
            btnRoom06.Left = 225 + 83
            btnRoom07.Left = 225 + 83
            btnRoom08.Left = 225 + 83
            btnRoom09.Left = 225 + 83

        End If


    End Sub
    Sub Only6Buttons(IsVisible As Boolean)
        btnRoom04.Visible = IsVisible
        btnRoom05.Visible = IsVisible
        btnRoom09.Visible = IsVisible
        btnRoom10.Visible = IsVisible
        btnRoom11.Visible = IsVisible
        btnRoom12.Visible = IsVisible
        btnRoom13.Visible = IsVisible
        btnRoom14.Visible = IsVisible
        btnRoom15.Visible = IsVisible

        If IsVisible Then

            btnRoom01.Width = 158
            btnRoom02.Width = 158
            btnRoom03.Width = 158
            btnRoom04.Width = 158
            btnRoom05.Width = 158
            btnRoom06.Width = 158
            btnRoom07.Width = 158
            btnRoom08.Width = 158
            btnRoom09.Width = 158
            btnRoom06.Left = 225
            btnRoom07.Left = 225
            btnRoom08.Left = 225
            btnRoom09.Left = 225

        Else

            btnRoom01.Width = 242
            btnRoom02.Width = 242
            btnRoom03.Width = 242
            btnRoom04.Width = 242
            btnRoom05.Width = 490
            btnRoom06.Width = 242
            btnRoom07.Width = 242
            btnRoom08.Width = 242
            btnRoom09.Width = 242
            btnRoom06.Left = 225 + 83
            btnRoom07.Left = 225 + 83
            btnRoom08.Left = 225 + 83
            btnRoom09.Left = 225 + 83

        End If


    End Sub
End Class