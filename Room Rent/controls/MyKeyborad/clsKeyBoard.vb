Module clsKeyBoard
    Sub BindKeyBoard(ByVal TextBox1 As TextBox)
        AddHandler TextBox1.GotFocus, AddressOf TextBox1_GotFocus
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frm As frmMyNumericKeyboard
        If sender.Tag Is Nothing OrElse TryCast(sender.Tag, frmMyNumericKeyboard).IsDisposed Then
            frm = New frmMyNumericKeyboard(sender)
        Else
            frm = sender.Tag
        End If
        frm.Show()
    End Sub
End Module
