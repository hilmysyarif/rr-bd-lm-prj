Public Class frmConnection

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        Try
            testconnection()
            Try
                testconnection2()
                MsgBox("Connection successful", MsgBoxStyle.Information, "Info")
            Catch ex As Exception
                MsgBox("Connection successful. But database not found. This Software will create the database for you.", MsgBoxStyle.Information, "Info")
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Sub testconnection()
        Dim conn As SqlConnection = New SqlConnection("Data Source=" & txtServerName.Text & ";Initial Catalog=master;User ID=" & txtUserName.Text & "; password=" & txtPassword.Text & "")
        conn.Open()
    End Sub

    Sub testconnection2()
        Dim conn As SqlConnection = New SqlConnection("Data Source=" & txtServerName.Text & ";Initial Catalog=" & txtDatabaseName.Text & ";User ID=" & txtUserName.Text & "; password=" & txtPassword.Text & "")
        conn.Open()
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Try
            testconnection()
            Try
                testconnection2()
                MsgBox("Connection successful", MsgBoxStyle.Information, "Info")
            Catch ex As Exception
                If MsgBox("Connection successful. But database not found. This Software will create the database for you." & vbNewLine & "Do you want the software to create the database?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try
            Dim str As String = ""
            Dim obj1 As New clsEncryption
            str += txtServerName.Text & vbNewLine
            str += txtUserName.Text & vbNewLine
            str += obj1.Encrypt(txtPassword.Text) & vbNewLine
            str += txtDatabaseName.Text

            Dim dbFileLoca As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "dbLocation.txt")
            dbServername = txtServerName.Text
            dbUserName = txtUserName.Text
            dbPassword = txtPassword.Text

            My.Computer.FileSystem.WriteAllText(dbFileLoca, str, False)
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub
End Class