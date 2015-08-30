Public Class frmLogin

    Dim objUser As New cls_Temp_tblUserDetails
    Dim objEnc As New clsEncryption

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' frmMaptest.Show()
        ' frmTest3.ShowDialog()
Read:
        Try

            txtUserName.DataSource = objUser.Selection
            txtUserName.DisplayMember = cls_Temp_tblUserDetails.FieldName.UserName.ToString
            If DeveloperPC() Then
                txtUserName.Text = "Admin"
            End If
        Catch ex As Exception
            If MsgBox("No user found" & vbNewLine & "Do you want to create an user?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                Dim frmCU As New frmCreateUser
                If frmCU.ShowDialog = Windows.Forms.DialogResult.OK Then
                    GoTo Read
                End If
            End If
        End Try
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DoLogin()
    End Sub

    Sub DoLogin()
        If txtPassword.Text.Trim = "" Then
            txtPassword.Focus()
            Exit Sub
        End If

        Try
            Dim pl As New List(Of SqlParameter)
            pl.Add(New SqlParameter("@UserName", txtUserName.Text))
            pl.Add(New SqlParameter("@Password", objEnc.Encrypt(txtPassword.Text)))
            Dim userinfo As cls_Temp_tblUserDetails.Fields = objUser.Selection_One_Row_Select(" AND " & cls_Temp_tblUserDetails.FieldName.UserName.ToString & " COLLATE Latin1_General_CS_AS =@UserName AND " & cls_Temp_tblUserDetails.FieldName.Password.ToString & " COLLATE Latin1_General_CS_AS =@Password  ", pl)
            LoginUserName = userinfo.UserName_
            LoginUserId = userinfo.UserId_
            LoginUserBranchID = userinfo.BranchID_
            ' LoginUserPassword = objEnc.Decrypt("IrTYIYAEOUDepOK1wlWUvg==")
            LoginUserPassword = objEnc.Decrypt(userinfo.Password_)
            UserLoggedIn = True
            UserLoginTime = Now
            LoginUserFullName = userinfo.FullName_
            Dim objLoginDetails As New cls_tblUserLoginInfo
            LoginDetailsID = objLoginDetails.Insert(LoginUserId, UserLoginTime, UserLoginTime)
            frmHome.Show()
            Close()
        Catch ex As Exception
            MsgBox("Authentication Failed." & vbNewLine & "Please check your Username and Password", MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub txtUserName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtUserName.SelectedIndexChanged
        If DeveloperPC() Then
            Try
                Dim pl As New List(Of SqlParameter)
                pl.Add(New SqlParameter("@UserName", txtUserName.Text))
                Dim userinfo As cls_Temp_tblUserDetails.Fields = objUser.Selection_One_Row_Select(" AND " & cls_Temp_tblUserDetails.FieldName.UserName.ToString & " COLLATE Latin1_General_CS_AS =@UserName ", pl)
                txtPassword.Text = objEnc.Decrypt(userinfo.Password_)
                txtPassword.PasswordChar = ""
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class