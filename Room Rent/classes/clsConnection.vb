Imports System.IO

Public Class clsConnection
    Implements IDisposable
    Private conn As SqlConnection = Nothing

    Function connect(Optional ByVal isMaster As Boolean = False, Optional isForce As Boolean = False) As SqlConnection
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed OrElse conn.State = ConnectionState.Broken OrElse conn.State = ConnectionState.Connecting OrElse isForce Then
            If DeveloperPC() Then

            End If
            If MyConnectionString = "" Then
                'Locate database file
                'db_file = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath & "\db", "dbRent.mdb")
                Try
                    Dim dbFileLoca As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "dbLocation.txt")
                    If IO.File.Exists(dbFileLoca) Then
                        Dim locaText As String = My.Computer.FileSystem.ReadAllText(dbFileLoca).Trim
                        Dim d As New StringReader(locaText)
                        Dim tmp As String = ""

                        tmp = ""
                        tmp = d.ReadLine
                        If tmp.Trim <> "" Then
                            dbServername = tmp
                        End If

                        tmp = ""
                        tmp = d.ReadLine
                        If tmp.Trim <> "" Then
                            dbUserName = tmp
                        End If

                        tmp = ""
                        tmp = d.ReadLine
                        If tmp.Trim <> "" Then
                            Dim obj1 As New clsEncryption
                            dbPassword = obj1.Decrypt(tmp)
                        End If

                        tmp = ""
                        tmp = d.ReadLine
                        If tmp.Trim <> "" Then
                            dbName = tmp
                        End If
                    End If
                Catch ex As Exception
                End Try

                MyConnectionString = "Data Source=" & dbServername & ";Initial Catalog=" & dbName & ";User ID=" & dbUserName & "; password=" & dbPassword & ""
                'Update database
                If My.Application.Info.AssemblyName <> "PasswordApp" And Not isMaster Then
                    Dim obj As New cls_ExportImport
                    If obj.CheckDBVerification() Then
                        'Application.Restart()
                    End If
                End If

            End If

            If isMaster Then
                MyConnectionString = "Data Source=" & dbServername & ";Initial Catalog=master;User ID=" & dbUserName & "; password=" & dbPassword & ""
            Else
                MyConnectionString = "Data Source=" & dbServername & ";Initial Catalog=" & dbName & ";User ID=" & dbUserName & "; password=" & dbPassword & ""
            End If
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If

            conn = New SqlConnection(MyConnectionString)
            conn.Open()

            If My.Application.Info.AssemblyName <> "PasswordApp" And Not isMaster Then
                Try
                    Dim com As New SqlCommand("Select Count(Version) from tblDBVErsion where [Type]='INVALID' and [Version]='" & My.Application.Info.Version.ToString & "'", conn)
                    If com.ExecuteScalar > 0 Then
                        MsgBox("This version no longer valid or abandoned" & vbNewLine & "Please install version " & MyLocalSettings.LastVersion & " Or Install any Latest Version other than this version.", MsgBoxStyle.Information, "Info")
                        End
                    End If
                Catch ex As Exception
                End Try
            End If

        End If
        Return conn
    End Function




#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                If Not conn Is Nothing Then
                    conn.Dispose()
                End If

            End If

        
        End If
        Me.disposedValue = True
    End Sub


    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
