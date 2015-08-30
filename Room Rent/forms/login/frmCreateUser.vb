﻿Public Class frmCreateUser
    Dim objUser As New cls_Temp_tblUserDetails
    Dim objUserRules As New cls_tblUserRules
    Public editID As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtUserName.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
            MsgBox("Username and Password cannot be blank", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtPassword.Text.Trim.Length < 6 Then
            MsgBox("Length of password must be greater than 6 characters", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForAlphaCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one alphabet", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForNumericCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one numeric character", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForSpecialCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one special character", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtFullName.Text.Trim = "" Then
            MsgBox("Fullname cannot be blank", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            Dim UserId As Integer = 0

            Dim objEnc As New clsEncryption
            If editID = 0 Then
                UserId = objUser.Insert(1, txtUserName.Text, objEnc.Encrypt(txtPassword.Text), "OPERATOR", "OK", True, Now, Now, Now, UserId, Now, UserId, "2014-15", txtFullName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text)
            Else
                Dim ud As cls_Temp_tblUserDetails.Fields = objUser.Selection_One_Row(editID)
                objUser.Update(editID, txtUserName.Text, objEnc.Encrypt(txtPassword.Text), ud.UserType_, ud.Status_, ud.Enable_, ud.LastLoginDate_, ud.EnabledDate_, ud.CreatedDate_, ud.CreatedBy_, Now, UserId, ud.Session_, txtFullName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, UserId)
                UserId = editID
            End If

            Try
                objUserRules.Delete_By_SELECT("UserId=" & UserId.ToString)
            Catch ex As Exception
            End Try
            Dim Rules As String = ""
            For Each c As CheckBox In GroupBox1.Controls
                objUserRules.Insert(c.Tag, c.Checked, Now, UserId)
                Rules += c.Tag + vbNewLine
            Next

            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function


    Function CheckForNumericCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsNumber(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function


    Function CheckForSpecialCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Not (Char.IsLetter(StringToCheck.Chars(i)) Or Char.IsNumber(StringToCheck.Chars(i))) Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub frmCreateUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
    End Sub

    Private Sub frmCreateUser_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        If editID > 0 Then
            Dim ud As cls_Temp_tblUserDetails.Fields = objUser.Selection_One_Row(editID)
            txtUserName.Text = ud.UserName_
            Dim objEnc As New clsEncryption
            txtPassword.Text = objEnc.Decrypt(ud.Password_)
            txtFullName.Text = ud.FullName_
            txtAddress.Text = ud.Address_
            txtCity.Text = ud.City_
            txtState.Text = ud.State_
            txtPhone.Text = ud.Phone_
            txtZip.Text = ud.Zip_
            txtUserName.Text = ud.UserName_
            txtEmail.Text = ud.Email_

            Try
                Dim dt As DataTable = objUserRules.Selection(cls_tblUserRules.SelectionType.All, "UserId=" & editID.ToString)

                For Each dr As DataRow In dt.Rows
                    For Each c As CheckBox In GroupBox1.Controls
                        If c.Tag = dr("RuleName") Then
                            c.Checked = dr("Enabled")
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try


        End If

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class