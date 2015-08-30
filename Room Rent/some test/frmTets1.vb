Public Class frmTets1

    Private Sub frmTets1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frm As New frmTest2
        frm.TopLevel = False ' = True
        Me.Controls.Add(frm)
        frm.Dock = DockStyle.Fill
    End Sub
End Class