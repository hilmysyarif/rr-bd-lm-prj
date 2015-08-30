Imports System.Windows.Forms

Public Class dlgReason
    Dim ObjSettings2 As New cls_tblSettings2
    Public ReasonType As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        If ReasonType <> "" Then

            Try
                Dim Pp As New List(Of SqlParameter)
                Pp.Add(New SqlParameter("@Value", txtReason.Text.Trim))
                If ObjSettings2.Selection(cls_tblSettings2.SelectionType.All, "[Item]='" & ReasonType & "' and [Value]=@Value", Pp).Rows.Count = 0 Then
                    Throw New Exception("")
                End If
            Catch ex As Exception
                Try
                    ObjSettings2.Insert(ReasonType, txtReason.Text.Trim)
                Catch ex2 As Exception
                End Try
            End Try
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgCardCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        Dim dt As DataTable = New DataTable
        Try
            dt = ObjSettings2.Selection(cls_tblSettings2.SelectionType.All, "[Item]='" & ReasonType & "'")
            Dim dr As DataRow = dt.NewRow
            dr(0) = 0
            dr(1) = ReasonType
            dr(2) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)
            cmbPredefined.DataSource = dt
            cmbPredefined.ValueMember = "Value"
        Catch ex As Exception
        End Try
        cmbPredefined.Enabled = ReasonType <> "" AndAlso dt.Rows.Count > 0
    End Sub

    Private Sub cmbPredefined_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPredefined.SelectedIndexChanged
        Try
            If cmbPredefined.SelectedIndex <> 0 Then
                txtReason.Text = cmbPredefined.Text
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
