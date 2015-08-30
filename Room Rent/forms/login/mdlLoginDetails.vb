Module mdlLoginDetails
    Public LoginUserName As String = ""
    Public LoginUserId As Integer = 0
    Public LoginUserPassword As String = ""
    Public UserLoggedIn As Boolean = False
    Public UserLoginTime As Date = Now
    Public LoginUserFullName As String = ""
    Public LoginUserBranchID As Integer = 0
    Public LoginDetailsID As Integer = 0


    Sub Logout()

        Try
            Dim objLoginDetails As New cls_tblUserLoginInfo
            LoginDetailsID = objLoginDetails.Update_field(cls_tblUserLoginInfo.FieldName.LogoutDate, Now, " " & cls_tblUserLoginInfo.FieldName.ItemSL.ToString & " = " & LoginDetailsID)
            LoginUserName = ""
            LoginUserId = 0
            LoginUserBranchID = 0
            LoginUserPassword = ""
            UserLoggedIn = False
            UserLoginTime = Now
            LoginUserFullName = ""
            LoginDetailsID = 0
        Catch ex As Exception
        End Try

    End Sub
End Module
