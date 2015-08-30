Public Class frmEscortServices

    Private Sub frmEscortServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        Try
            For Each s As String In MySettings.OtherSettings.EscortServices
                Dim chk As CheckBox = grpServices.Controls("chk" & s)
                chk.Checked = chk.Tag = s
                
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim service As New List(Of String)
            For Each chk As CheckBox In grpServices.Controls
                If chk.Checked Then
                    service.Add(chk.Tag)
                End If
            Next
            Dim ot As New cls_tblSettings.OtherSetiings_S
            ot.EscortServices = service
            MySettings.OtherSettings = ot

            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "info")
        End Try

    End Sub
End Class