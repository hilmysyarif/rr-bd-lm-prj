Public Class frmMyNumericKeyboard
    Dim MyTextBox As TextBox
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    'The message ID that tells the textbox to grey out when disabled
    '    Const WM_ENABLE As Integer = &HA

    '    'Exit if the message is WM_ENABLE, thus preventing the greyed out look
    '    If m.Msg = WM_ENABLE Then Exit Sub
    '    MyBase.WndProc(m)
    'End Sub

    'Protected Overloads Overrides ReadOnly Property ShowWithoutActivation() As Boolean
    '    Get
    '        Return True
    '    End Get
    'End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim baseParams As CreateParams = MyBase.CreateParams
            Const WS_EX_NOACTIVATE As Integer = &H8000000
            Const WS_EX_TOOLWINDOW As Integer = &H80
            baseParams.ExStyle = baseParams.ExStyle Or CInt(WS_EX_NOACTIVATE Or WS_EX_TOOLWINDOW)
            Return baseParams
        End Get
    End Property
    Sub New(ByVal Myt_ As TextBox)
        'This call is required by the designer.
        InitializeComponent()
        MyTextBox = Myt_
        Owner = MyTextBox.FindForm
        MyTextBox.Tag = Me
        Location = Owner.PointToScreen(MyTextBox.Location + New Point((MyTextBox.Width - Width) / 2, MyTextBox.Height + 5))
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub frmMyKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.Selectable, False)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, _
        Button2.Click, _
        Button3.Click, _
        Button4.Click, _
        Button5.Click, _
        Button6.Click, _
        Button7.Click, _
        Button8.Click, _
        Button9.Click, _
        Button10.Click, _
        Button12.Click
        Owner.Focus()
        SendKeys.Send(sender.text)
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Owner.Focus()
        Close()
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Owner.Focus()
        SendKeys.Send("{BS}")
    End Sub
End Class