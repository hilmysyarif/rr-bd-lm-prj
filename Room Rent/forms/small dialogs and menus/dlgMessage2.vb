Public Class dlgMessage2
    Dim isAnyButton As Boolean = False
    Public IconI As Integer = MsgBoxStyle.Information
    Public ButtonI As Integer = MsgBoxStyle.OkCancel

    Dim bOk As DialogResult = Windows.Forms.DialogResult.OK
    Dim bCan As DialogResult = Windows.Forms.DialogResult.Cancel
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = bOk
        isAnyButton = True
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = bCan
        isAnyButton = True
        Close()
    End Sub

    Private Sub dlgMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not isAnyButton Then
            Me.DialogResult = bCan
        End If
    End Sub

    Private Sub dlgMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        Select Case IconI
            Case MsgBoxStyle.Information
                PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Information.Handle)
            Case MsgBoxStyle.Question
                PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Question.Handle)
            Case MsgBoxStyle.Critical
                PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Error.Handle)
            Case MsgBoxStyle.Exclamation
                PictureBox1.Image = Bitmap.FromHicon(SystemIcons.Exclamation.Handle)
        End Select
        Select Case ButtonI
            Case MsgBoxStyle.OkCancel
                btnOK.Text = "OK"
                bOk = Windows.Forms.DialogResult.OK
                btnCancel.Text = "CANCEL"
                bCan = Windows.Forms.DialogResult.Cancel
            Case MsgBoxStyle.YesNo
                btnOK.Text = "YES"
                bOk = Windows.Forms.DialogResult.Yes
                btnCancel.Text = "NO"
                bCan = Windows.Forms.DialogResult.No
            Case MsgBoxStyle.RetryCancel
                btnOK.Text = "RETRY"
                bOk = Windows.Forms.DialogResult.Retry
                btnCancel.Text = "CANCEL"
                bCan = Windows.Forms.DialogResult.Cancel
                'Case MsgBoxStyle.
                '    btnOK.Text = "RETRY"
                '    bOk = Windows.Forms.DialogResult.Retry
                '    btnCancel.Text = "CANCEL"
                '    bCan = Windows.Forms.DialogResult.Cancel

        End Select
    End Sub
    Private Sub dlgMessage2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim gr As Graphics = Label1.CreateGraphics
        Dim h As Integer = gr.MeasureString(Label1.Text, Label1.Font, Label1.Width - 5).Height
        Height = 208 + (h - 89) + 30
        If Height < 208 Then
            Height = 208
        End If
    End Sub
End Class