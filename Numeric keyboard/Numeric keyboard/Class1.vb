Public Class Class1
    Inherits UserControl


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Class1
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Name = "Class1"
        Me.ResumeLayout(False)
        SendKeys.Send("{ptrscr}")
    End Sub
End Class
