Public Class frmCancelBookingOption
    Public SelectedOption As String = "CASH BACK"
    Public CASHBACK_AMOUT As Double = 0
    Public VOUCHER_AMOUT As Double = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Button1.BackColor = ActiveButton
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button2.Click
        For Each c As Button In GroupBox1.Controls
            If c.Enabled Then
                c.BackColor = Nothing
                c.UseVisualStyleBackColor = True
            End If
        Next
        SelectedOption = sender.text
        sender.backcolor = ActiveButton

        Label1.Text = "$" & CASHBACK_AMOUT.ToString("0.00")

        Panel1.Visible = sender Is Button2

    End Sub
 
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Panel1.Visible Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Enter voucher reference number", MsgBoxStyle.Information, "info")
                Exit Sub
            End If
        End If
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
 
    Private Sub frmCancelBookingOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class