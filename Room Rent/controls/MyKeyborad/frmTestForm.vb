Public Class frmTestForm
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        BindKeyBoard(TextBox1)
        BindKeyBoard(TextBox2)
        BindKeyBoard(TextBox4)
        'BindKeyBoard(TextBox5)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
  
    
    Private Sub frmTestForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class