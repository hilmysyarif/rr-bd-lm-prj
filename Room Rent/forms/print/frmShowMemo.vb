Public Class frmShowMemo

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim obj As New clsDocketPrint
        If MyLocalSettings.ReceiptPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                obj.Printing(frm.PrinterSettings.PrinterName, TextBox1.Text, "")
            End If
        Else
            obj.Printing(MyLocalSettings.ReceiptPrinter, TextBox1.Text, "")
        End If
    End Sub

    Private Sub frmShowMemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm

    End Sub
End Class