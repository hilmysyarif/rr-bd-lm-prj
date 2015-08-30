Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            Try
                My.Computer.FileSystem.WriteAllText("test.txt", Now.ToString, False)
            Catch ex As Exception
                Try
                    Try
                        Dim p As New Process
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        p.StartInfo.FileName = "DirectorySecurity.exe"
                        p.StartInfo.Arguments = """" + My.Application.Info.DirectoryPath
                        'p.StartInfo.UseShellExecute = False
                        'p.StartInfo.RedirectStandardOutput = True
                        'p.StartInfo.RedirectStandardError = True

                        If (System.Environment.OSVersion.Version.Major >= 6) Then
                            p.StartInfo.Verb = "runas"
                        End If
                        p.Start()
                        p.WaitForExit()

                        'MsgBox(p.ExitCode)
                    Catch ex1 As Exception
                    End Try
                    ' restart()
                Catch ex1 As Exception
                End Try
            End Try

            Try

                If Not My.Computer.FileSystem.DirectoryExists(DcFolder) Then
                    My.Computer.FileSystem.CreateDirectory(DcFolder)
                End If

            Catch ex As Exception
            End Try

            LoadLocalSettings()
            'If DeveloperPC() Then
            '    IsAllTopMostForm = False
            'End If

            'Settings Update
            If My.Settings.Update Then
                My.Settings.Upgrade()
                My.Settings.Update = False
                My.Settings.Save()
            End If


            'Check database exists or not.
            'If Not My.Computer.FileSystem.FileExists(db_file) Then
            '    Try
            '        My.Computer.FileSystem.WriteAllBytes(db_file, Room_Rent.My.Resources.Resources.dbRent_blank, False)
            '        UpdateRequired = False
            '    Catch ex As Exception
            '    End Try
            'End If

            'Database transaction starts here.
            'My.Settings.MyMacAddress = ""
            'Dim ddd As String = (New clsEncryption).Decrypt("6c4KhADWfi8iriNIL4sAHQ==")
            Dim obj As New clsMAC_Address
            If Not obj.isValidNIC And My.Settings.MyMacAddress = "" Then
                Dim frmPass As New dlgPass
                frmPass.Text = "Enter Project Zip Password"
                If MsgBox("Not a Valid MAC Address detected." & vbNewLine & "Do you want to register your MAC Address?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    If frmPass.ShowDialog = DialogResult.OK Then
                        If frmPass.TextBox1.Text = (New clsEncryption).Decrypt(zp) Then
                            Dim frmreson As New dlgReason
                            frmreson.Text = "MAC Address"
                            MsgBox("Enter MAC Addres one in each line", MsgBoxStyle.Information, "Info")
                            For Each s As String In obj.MACs()
                                frmreson.txtReason.Text += s & vbNewLine
                            Next
                            If frmreson.ShowDialog = DialogResult.OK Then
                                My.Settings.MyMacAddress = frmreson.txtReason.Text
                                My.Settings.Save()
                            End If
                        Else
                            MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                        End If
                    End If
                End If
            End If

            Try
                For Each s As String In My.Settings.MyMacAddress.Split(vbNewLine)
                    obj.ValidNICs.Add(s)
                Next
            Catch ex As Exception
            End Try

            If Not obj.isValidNIC Then
                MsgBox("Installation failed" & vbNewLine & "Please re-install the Application properly", MsgBoxStyle.Critical, "Installation Failed!!")
                End
            End If

            Dim dateTrial As Date = "1/1/2015"
            dateTrial = dateTrial.AddMonths(9)
            dateTrial = dateTrial.AddDays(-1)

            If (dateTrial - Now.Date).TotalDays < 15 And (dateTrial - Now.Date).TotalDays > 0 Then
                MsgBox("Trial will expire in " & (dateTrial - Now.Date).TotalDays.ToString & " days " & vbNewLine & "Please contact Abstract Concepts Pty Ltd", MsgBoxStyle.Information, "Info")
            End If

            If Now.Date > dateTrial Then
                MsgBox("Trial expired" & vbNewLine & "Please contact Abstract Concepts Pty Ltd", MsgBoxStyle.Information, "Info")
                End
            End If

            Try
                Dim dbFileLoca As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "dbLocation.txt")
                If Not IO.File.Exists(dbFileLoca) Then
                    My.Computer.FileSystem.WriteAllText(dbFileLoca, "", False)
                End If
                Dim locaText As String = My.Computer.FileSystem.ReadAllText(dbFileLoca).Trim
                If locaText = "" Then
                    Dim frm As New frmConnection
                    If frm.ShowDialog() <> DialogResult.OK Then
                        End
                    End If
                End If
            Catch ex As Exception
            End Try

recheckDB:
            Try
                Dim con1 As SqlConnection = (New clsConnection).connect(True, True)
                Try
                    Dim com As New SqlCommand("Use [" & dbName & "]", con1)
                    com.ExecuteNonQuery()

                Catch ex As Exception

                    If MsgBox("Database not found" & vbNewLine & "Do you want create a new database?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
                        If MsgBox("Do you want to reset the connection? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
                            End
                        Else
                            Dim frmPass1 As New dlgPass
                            frmPass1.Text = "Enter Project Zip Password"
                            If frmPass1.ShowDialog = DialogResult.OK Then
                                If frmPass1.TextBox1.Text = (New clsEncryption).Decrypt(zp) Then
                                    Dim frm2 As New frmConnection
                                    frm2.txtServerName.Text = dbServername
                                    frm2.txtUserName.Text = dbUserName
                                    frm2.txtPassword.Text = dbPassword
                                    frm2.txtDatabaseName.Text = dbName
                                    frm2.ShowDialog()
                                Else
                                    MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                                End If
                            End If
                        End If
                    End If
                End Try
                MyConnectionString = ""
                Dim con2 As SqlConnection = (New clsConnection).connect(False, True)
            Catch ex As Exception
                If MsgBox(ex.Message & vbNewLine & vbNewLine & "", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    End
                Else
                    Dim frmPass As New dlgPass
                    frmPass.Text = "Enter Project Zip Password"
                    If frmPass.ShowDialog = DialogResult.OK Then
                        If frmPass.TextBox1.Text = (New clsEncryption).Decrypt(zp) Then
                            Dim frm As New frmConnection
                            frm.txtServerName.Text = dbServername
                            frm.txtUserName.Text = dbUserName
                            frm.txtPassword.Text = dbPassword
                            frm.txtDatabaseName.Text = dbName
                            frm.ShowDialog()
                        Else
                            MsgBox("Wrong Password", MsgBoxStyle.Information, "Info")
                        End If
                    End If
                    GoTo recheckDB
                End If
            End Try

            Try
                mdlDBGlobals.MySettings = New cls_tblSettings
            Catch ex As Exception
                MsgBox("Error while initializing Global Settings." & vbNewLine & "Please restart the application.", MsgBoxStyle.Information, "Info")
            End Try

            'Try
            '    '//Test of web service
            '    Dim c As New UpdateServer.WebUpdateServerSoapClient
            '    MsgBox(c.TestAdd("Bidyut"))
            'Catch ex As Exception
            'End Try

        End Sub


        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox(e.Exception.ToString)
            My.Computer.FileSystem.WriteAllText("errorlog.txt", Now.ToString + vbNewLine + e.Exception.ToString + vbNewLine + vbNewLine, True)
        End Sub


    End Class


End Namespace

