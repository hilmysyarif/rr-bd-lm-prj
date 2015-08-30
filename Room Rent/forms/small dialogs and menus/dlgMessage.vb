Public Class dlgMessage
    Dim isAnyButton As Boolean = False
    Public IconI As Integer = MsgBoxStyle.Information
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        isAnyButton = True
        Close()
      
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        isAnyButton = True
        Close()

    End Sub

    Private Sub dlgMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not isAnyButton Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
    End Sub

    Private Sub dlgMessage_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim gr As Graphics = Label1.CreateGraphics
        Dim h As Integer = gr.MeasureString(Label1.Text, Label1.Font, Label1.Width - 5).Height
       Height = 208 + (h - 89) + 30
        If Height < 208 Then
            Height = 208
        End If
    End Sub
End Class