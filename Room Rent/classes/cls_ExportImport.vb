Imports System.IO

Public Class cls_ExportImport

    'Dim tablesInDb As String() = {"tblBookings", "tblWorkers", "tblProducts", "tblCheckIn", "tblStock", "tblInstant", _
    '                              "tblActiveWorker", "tblRoom", "tblService", "tblSettings", "tblLocker", "tblLockerBooking", _
    '                              "tblMembers", "tblExtraService", "tblBookingPayments", "tblLookUp", "tblDailyCounter", "tblCalender", _
    '                              "tblEscortDriverInfo", "tblVouchers", "tblPayment", "tblShiftFee", _
    '                              "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}


    'Dim tablesInDb As String() = {"tblBookings", "tblWorkers", "tblProducts", "tblCheckIn", "tblStock", "tblInstant", _
    '                            "tblActiveWorker", "tblRoom", "tblService", "tblSettings", "tblLocker", "tblLockerBooking", _
    '                            "tblMembers", "tblExtraService", "tblBookingPayments", "tblLookUp", "tblDailyCounter", "tblCalender", _
    '                            "tblEscortDriverInfo", "tblVouchers", "tblPayment", "tblShiftFee", _
    '                            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

    Structure Tables_Update
        Dim tablename As String
        Dim updateBy As String
        Dim fields As String()
        Sub New(ByVal _tablename As String, ByVal _updateBy As String, ByVal _fields As String())
            tablename = _tablename
            updateBy = _updateBy
            fields = _fields
        End Sub
    End Structure


    Dim ExcludeTables_ToImport As String() = {"tblCalender", "PRIMARY_KEYS_DT", ""} '"tblLookUp",

    Dim ExcludeTables_ClearDB As String() = {"tblCalender", "tblRoom", "tblService", "tblSettings", "tblLookUp", "tblLocker", "tblDBVersion", "tblSettings2"}

    Dim Tables_to_be_updated As List(Of Tables_Update) = New List(Of Tables_Update) ' From {(New Tables_Update("tblRoom", "room", {"Status", "Usable", "Comment"}))}

    Dim DeletedColumnsInVersion_1_0_0_54 As String() = {"tblBookings.PaymentMode", _
                                                        "tblBookings.CASH", _
                                                        "tblBookings.CARD", _
                                                        "tblBookings.TIP", _
                                                        "tblBookings.Surcharge", _
                                                        "tblBookings.DoorName", _
                                                        "tblBookings.DoorCharge", _
                                                        "tblInstant.Room", _
                                                        "tblInstant.RoomCharge", _
                                                        "tblInstant.Service", _
                                                        "tblInstant.PaymentMode", _
                                                        "tblInstant.WorkerID", _
                                                        "tblInstant.CASH", _
                                                        "tblInstant.CARD", _
                                                        "tblInstant.TIP", _
                                                        "tblInstant.Surcharge", _
                                                        "tblActiveWorker.TotalAmount", _
                                                        "tblActiveWorker.CASH", _
                                                        "tblActiveWorker.CARD", _
                                                        "tblActiveWorker.Surcharge", _
                                                        "tblActiveWorker.PaymentMode", _
                                                        "tblExtraService.CASH", _
                                                        "tblExtraService.CARD", _
                                                        "tblExtraService.Surcharge", _
                                                        "tblExtraService.PaymentMode", _
                                                        "tblExtraService.Charge", _
                                                        "tblActiveWorker.CustomerName", _
                                                        "tblBookings.RoomCharge", _
                                                        "tblBookings.TotalAmount", _
                                                        "", _
                                                        "", _
                                                        ""}

#Region "Developer Codes"

    Public ClearBookings As New List(Of String) From {"tblBookings", "tblBookingPayments", "tblExtraService", "tblActiveWorker", "tblBookingPause", _
                                                      "tblBookingStatus", "", "", "", "", "", "", "", "", "", "", ""}
    Public ClearOthers As New List(Of String) From {"tblPayment", _
                                                    "tblInstant", "", "", "", "", "", "", "", "", "", ""}
    Sub ClearTabledatas(ListOfTables As List(Of String))
        Dim objCon As New clsConnection
        Dim comDelete As New SqlCommand("", objCon.connect)
        For Each tableName As String In ListOfTables
            If tableName <> "" Then
                comDelete.CommandText = "Delete from  [" & tableName & "]"
                comDelete.ExecuteNonQuery()
            End If
        Next
        comDelete.Dispose()
    End Sub
#End Region

    Function ExportDb(ByVal FileName As String) As Boolean
        Dim ds As New DataSet
        Dim objCon As New clsConnection
        Dim da As New SqlDataAdapter("", objCon.connect)
        Dim dtTables As DataTable = GetTables(objCon.connect)
        For Each drTable As DataRow In dtTables.Rows
            If Not ExcludeTables_ToImport.Contains(drTable("name")) Then
                If drTable("name") <> "" Then
                    da.SelectCommand.CommandText = "Select * from [" & drTable("name") & "]"
                    da.Fill(ds, drTable("name"))
                End If
            End If
        Next
        ds.Tables.Add(GetPrimarKeys(objCon.connect))
        Dim objEncryption As New clsEncryption
        Dim sd As New BackupFile
        sd.ExportedBy = My.User.Name
        sd.exportedOn = Now
        sd.dataDS = objEncryption.Encrypt(ds.GetXml)
        sd.schemaDS = objEncryption.Encrypt(ds.GetXmlSchema)
        sd.version = My.Application.Info.Version
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim MS As New System.IO.MemoryStream()
        BF.Serialize(MS, sd)
        My.Computer.FileSystem.WriteAllBytes(FileName, MS.GetBuffer, False)
        MS.Flush()
        MS.Dispose()
        ds.Dispose()
        da.Dispose()
        objCon.Dispose()
        Return True
    End Function

    <Serializable()> _
    Structure BackupFile
        Dim version As Version
        Dim exportedOn As Date
        Dim ExportedBy As String
        Dim schemaDS As String
        Dim dataDS As String
    End Structure

    Function ImportDb(ByVal FileName As String) As Boolean

        Dim ds As New DataSet

        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim objEncryption As New clsEncryption

        ds.DataSetName = "NewDataSet"

        Dim bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(FileName)
        Try
            Dim sd As BackupFile
            sd = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), BackupFile)
            If sd.version > My.Application.Info.Version Then
                MsgBox("Cannot import a file exported from a newer version of this software", MsgBoxStyle.Information, "info")
                Return False
                Exit Function
            End If

            Try
                Dim xmlSR As System.IO.StringReader = New System.IO.StringReader(objEncryption.Decrypt(sd.schemaDS))
                ds.ReadXmlSchema(xmlSR)
            Catch ex As Exception
            End Try
            Try
                Dim xmlSR As System.IO.StringReader = New System.IO.StringReader(objEncryption.Decrypt(sd.dataDS))
                ds.ReadXml(xmlSR, XmlReadMode.IgnoreSchema)
            Catch ex As Exception
            End Try
        Catch ex As Exception
            ds = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), DataSet)
        End Try

        Dim objCon As New clsConnection
        Dim conn As SqlConnection = objCon.connect
        Dim comInsertDeleteUpdate As New SqlCommand("", conn)
        For Each dt As DataTable In ds.Tables
            If Not ExcludeTables_ToImport.Contains(dt.TableName) And Not isTable_to_be_Updated(dt.TableName) Then
                comInsertDeleteUpdate.CommandText = "Delete from  [" & dt.TableName & "]"
                comInsertDeleteUpdate.ExecuteNonQuery()
                For Each dr As DataRow In dt.Rows
                    Try
                        Dim Fields As String = ""
                        Dim Values As String = ""
                        comInsertDeleteUpdate.Parameters.Clear()
                        For Each col As DataColumn In dt.Columns
                            If Not IsColumnDeleted(dt.TableName, col.ColumnName) Then
                                If Fields = "" Then
                                    Fields = "[" & col.ColumnName & "]"
                                Else
                                    Fields += ",[" & col.ColumnName & "]"
                                End If
                                If Values = "" Then
                                    Values = "@" & col.ColumnName & "_1"
                                Else
                                    Values += ",@" & col.ColumnName & "_1"
                                End If
                                If TypeOf dr(col.ColumnName) Is Date Then
                                    comInsertDeleteUpdate.Parameters.Add("@" & col.ColumnName & "_1", SqlDbType.DateTime).Value = dr(col.ColumnName)
                                ElseIf TypeOf dr(col.ColumnName) Is Byte() Or col.DataType = GetType(Byte()) Then
                                    comInsertDeleteUpdate.Parameters.Add("@" & col.ColumnName & "_1", SqlDbType.Image).Value = dr(col.ColumnName)
                                Else
                                    comInsertDeleteUpdate.Parameters.AddWithValue("@" & col.ColumnName & "_1", dr(col.ColumnName))
                                End If
                            End If
                        Next
                        If Fields.Trim <> "" Then
                            comInsertDeleteUpdate.CommandText = "Insert Into [" & dt.TableName & "](" & Fields & ") Values(" & Values & ")"
                            comInsertDeleteUpdate.ExecuteNonQuery()
                        End If
                    Catch ex As Exception
                    End Try
                Next
            ElseIf isTable_to_be_Updated(dt.TableName) Then
                Try
                    Dim tab_to_u As Tables_Update = GetTable_to_be_Updated(dt.TableName)
                    If tab_to_u.tablename = dt.TableName Then
                        For Each dr As DataRow In dt.Rows
                            Dim Fields As String = ""
                            comInsertDeleteUpdate.Parameters.Clear()
                            For Each col As DataColumn In dt.Columns
                                If tab_to_u.fields.Contains(col.ColumnName) Then
                                    If Fields = "" Then
                                        Fields = "[" & col.ColumnName & "]=@" & col.ColumnName & "_1"
                                    Else
                                        Fields += ",[" & col.ColumnName & "]=@" & col.ColumnName & "_1"
                                    End If
                                    If TypeOf dr(col.ColumnName) Is Date Then
                                        comInsertDeleteUpdate.Parameters.Add("@" & col.ColumnName & "_1", SqlDbType.DateTime).Value = dr(col.ColumnName)
                                    Else
                                        comInsertDeleteUpdate.Parameters.AddWithValue("@" & col.ColumnName & "_1", dr(col.ColumnName))
                                    End If
                                End If
                            Next
                            If Fields.Trim <> "" Then
                                comInsertDeleteUpdate.CommandText = "UPDATE [" & dt.TableName & "] SET " & Fields & " WHERE [" & tab_to_u.updateBy & "]=@" & tab_to_u.updateBy & ""
                                comInsertDeleteUpdate.Parameters.AddWithValue("@" & tab_to_u.updateBy, dr(tab_to_u.updateBy))
                                comInsertDeleteUpdate.ExecuteNonQuery()
                            End If
                        Next
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
        ds.Dispose()
        comInsertDeleteUpdate.Dispose()


        CheckAndRegisterThisVersion(conn)
        Return True
    End Function

    Public Function GetPrimarKeys(ByVal conn As SqlConnection) As DataTable
        Dim schemaTable As DataTable = ExecuteAdapter("select col.* from  information_schema.Table_CONSTRAINTS tab, information_schema.CONSTRAINT_TABLE_USAGE col where tab.CONSTRAINT_NAME = col.CONSTRAINT_NAME and col.TABLE_NAME = tab.table_name and tab.CONSTRAINT_TYPE = 'PRIMARY KEY'", Nothing, conn)
        schemaTable.TableName = "PRIMARY_KEYS_DT"
        Return schemaTable
    End Function

    Public Function GetTables(ByVal conn As SqlConnection) As DataTable
        Dim schemaTable As DataTable = ExecuteAdapter("Select * from sys.tables", Nothing, conn)
        Return schemaTable
    End Function

    Function IsColumnDeleted(ByVal TableName As String, ByVal ColumnName As String) As Boolean
        Dim ret As Boolean = False
        For Each column As String In DeletedColumnsInVersion_1_0_0_54
            If column.Trim <> "" AndAlso column.Split(".").Length = 2 Then
                Dim tblName As String = column.Split(".")(0)
                Dim colName As String = column.Split(".")(1)
                If tblName.ToUpper = TableName.ToUpper AndAlso colName.ToUpper = ColumnName.ToUpper Then
                    ret = True
                    Exit For
                End If
            End If
        Next
        Return ret
    End Function

    Function isTable_to_be_Updated(ByVal _tablename As String) As Boolean
        For Each c As Tables_Update In Tables_to_be_updated
            If c.tablename = _tablename Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Function GetTable_to_be_Updated(ByVal _tablename As String) As Tables_Update
        For Each c As Tables_Update In Tables_to_be_updated
            If c.tablename = _tablename Then
                Return c
                Exit Function
            End If
        Next
        Return Nothing
    End Function

    Sub ClearDB()
        Dim objCon As New clsConnection
        Dim comInsertDeleteUpdate As New SqlCommand("", objCon.connect)
        For Each dr As DataRow In GetTables(objCon.connect).Rows
            If Not ExcludeTables_ClearDB.Contains(dr("name").ToString) Then
                comInsertDeleteUpdate.CommandText = "Delete from  [" & dr("name").ToString & "]"
                comInsertDeleteUpdate.ExecuteNonQuery()
            End If
        Next
        comInsertDeleteUpdate.Dispose()
    End Sub

    Dim dbExists As Boolean = True
    Function CheckDBVerification() As Boolean
        Dim ret As Boolean = False
        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect(True, True)

        Try
            Dim com As New SqlCommand("Use [" & dbName & "]", con)
            com.ExecuteNonQuery()
        Catch ex As Exception
            dbExists = False
        End Try

        Dim version As String = ""
        Try
            Dim com As New SqlCommand("Select Version from tblDBVErsion where [Type]='VALID' order by [ID] desc", con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try
        If Not dbExists Then
            version = "1.0.0.0"
        End If
        If version <> My.Application.Info.Version.ToString Then
            Try

                Dim vv As New Version(version)
                If vv > My.Application.Info.Version Then
                    MsgBox("This software is an older version. New version are available. Please install a newer version of this application.", MsgBoxStyle.Information, "Info")
                    End
                End If

            Catch ex As Exception
            End Try

            Dim tmp_filename As String = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Temp, "tmp_update" & Now.ToString("yyMMddHHMMSSff") & ".bdl")
            Dim LastVersion As String = ""
            If MyLocalSettings.ThisVersion = "" Then
                LastVersion = New Version("1.0.0.89").ToString
            Else
                LastVersion = MyLocalSettings.ThisVersion.ToString
            End If

            Dim tmp_filename2 As String = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Desktop, "Automatic Database Export Ver " & LastVersion.ToString & " " & Now.ToString("yyMMddHHMMSSff") & ".bdl")

            Dim BackDir As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "Backup")

            Try
                If Not Directory.Exists(BackDir) Then
                    Directory.CreateDirectory(BackDir)
                End If
            Catch ex As Exception
            End Try


            Dim tmp_filename3 As String = My.Computer.FileSystem.CombinePath(BackDir, "OnUpdate Database Export Ver " & LastVersion.ToString & " " & Now.ToString("yyMMddHHMMSSff") & ".bdl")
            Try
                If version = "0.0.0.0" Then
                    UpdateRequired = False
                End If
                If UpdateRequired Then
                    Try
                        ExportDb(tmp_filename)
                    Catch ex As Exception
                        If dbExists Then
                            Throw ex
                        End If
                    End Try

                    'Delete all files before renaming the dbFile.
                    CreateDatabase(con)
                    Threading.Thread.Sleep(1000)
                    con = objCon.connect
                    If dbExists Then
                        Threading.Thread.Sleep(1000)
                        ImportDb(tmp_filename)
                    End If
                    ret = True
                End If
                MyLocalSettings.LastVersion = LastVersion
                MyLocalSettings.ThisVersion = My.Application.Info.Version.ToString
                SaveLocalSettings()
                If New Version(LastVersion) < New Version("1.0.1.52") Then
                    ExecuteSQL_Query("update tblBookingPayments set TOTAIL_PAID = tblBookingPayments.Total + Surcharge_Amt")
                End If
                CheckAndRegisterThisVersion(con)
            Catch ex As Exception
                Try
                    My.Computer.FileSystem.CopyFile(tmp_filename, tmp_filename2)
                    MsgBox(ex.Message & vbNewLine & "Unable to Update the database." & vbNewLine & "A Backup file stored in " & tmp_filename2, MsgBoxStyle.Information, "Info")
                Catch ex1 As Exception
                    MsgBox(ex.Message & vbNewLine & "Unable to Update the database.", MsgBoxStyle.Information, "Info")
                End Try
            End Try
        End If
        objCon.Dispose()
        Return ret
    End Function
    Public Function CreateDatabase(ByVal conn As SqlConnection) As Boolean
        Try

            'executeSqlScript("Use MASTER", conn)

            If dbExists Then
                'executeSqlScript("EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" & dbName & "'", conn)
                'executeSqlScript("Use MASTER", conn)
                'Try
                '    executeSqlScript("BACKUP DATABASE [" & dbName & "] TO  DISK = N'" & My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "Backup\dbRent.bak") & "' WITH NOFORMAT, INIT,  NAME = N'dbRent-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", conn)
                '    Threading.Thread.Sleep(1500)
                'Catch ex As Exception
                'End Try
                'executeSqlScript("ALTER DATABASE [" & dbName & "] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE", conn)
                'executeSqlScript("Use MASTER", conn)
                'executeSqlScript("DROP DATABASE [" & dbName & "]", conn)
                'executeSqlScript("Use MASTER", conn)
                executeSqlScript("Use [" & dbName & "]", conn)
                Dim da As New SqlDataAdapter("select * from sys.tables", conn)
                Dim dt As New DataTable
                da.Fill(dt)
                For Each dr As DataRow In dt.Rows
                    executeSqlScript("drop table [" & dr("name") & "]", conn)
                Next
            Else
                executeSqlScript("Use [" & dbName & "]", conn)
                Dim ccc As Integer = 0
                While conn.Database <> dbName
                    If ccc Mod 3 = 0 Then
                        executeSqlScript("Create database [" & dbName & "]", conn)
                        Threading.Thread.Sleep(1500)
                    ElseIf ccc Mod 3 = 1 Then
                        executeSqlScript("Create database [" & dbName & "] ON  PRIMARY ( NAME = N'" & dbName & "', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\" & dbName & ".mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) LOG ON ( NAME = N'" & dbName & "_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\" & dbName & "_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)", conn)
                        Threading.Thread.Sleep(1500)
                    ElseIf ccc Mod 3 = 2 Then
                        executeSqlScript("Create database [" & dbName & "] ON  PRIMARY ( NAME = N'" & dbName & "', FILENAME = N'" & My.Application.Info.DirectoryPath & "\" & dbName & ".mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) LOG ON ( NAME = N'" & dbName & "_log', FILENAME = N'" & My.Application.Info.DirectoryPath & "\" & dbName & "_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)", conn)
                        Threading.Thread.Sleep(1500)
                    End If
                    executeSqlScript("Use [" & dbName & "]", conn)
                    ccc += 1
                    If ccc > 20 Then
                        Throw New Exception("Error in creating database. Please use different dbName.")
                    End If
                End While
            End If


            CreateDatabaseSchema(conn)

            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub CreateDatabaseSchema(ByVal conn As SqlConnection)
        executeSqlScript(My.Resources.Schema, conn)
        executeSqlScript("Use [" & dbName & "]", conn)
        executeSqlScript(My.Resources.Data_s, conn)
        executeSqlScript("declare @c int set @c = 0 delete from tblCalender WHILE @c < 20454 BEGIN insert into tblCalender values (DATEADD (DAY,@c,'01/01/2000')) set @c =@c+1 END", conn)
        executeSqlScript("Use [" & dbName & "]", conn)
    End Sub

    Public Sub executeSqlScript(ByVal sqlScript As String, ByVal connection As SqlConnection)
        Dim command As New SqlCommand("", connection) '= connection.CreateCommand()
        Dim sqlScriptReader = New StringReader(sqlScript)
        Dim sqlBatch = New StringWriter()
        While (sqlScriptReader.Peek() <> -1)
            Dim sqlScriptLine = sqlScriptReader.ReadLine()
            If (sqlScriptLine.Trim().ToUpper() = "GO") Then
                command.CommandText = sqlBatch.ToString()
                executeBatch(command)
                sqlBatch = New StringWriter()
            Else
                sqlBatch.WriteLine(sqlScriptLine)
            End If
        End While
        command.CommandText = sqlBatch.ToString()
        executeBatch(command)
    End Sub

    Sub executeBatch(ByVal command As SqlCommand)

        Try
            If (command.CommandText.Trim() <> String.Empty) Then
                command.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub CheckAndRegisterThisVersion(con As SqlConnection)
        Try
            Dim MaxId As Integer = 1
            Try
                MaxId = (New SqlCommand("Select Max(ID) from [tblDBVersion]", con)).ExecuteScalar + 1
            Catch ex As Exception
            End Try
            Dim version1 As String = ""
            Try
                Dim com2 As New SqlCommand("Select Version from tblDBVErsion where [Type]='VALID' order by [ID] desc", con)
                version1 = com2.ExecuteScalar
            Catch ex As Exception
            End Try
            If version1 <> My.Application.Info.Version.ToString Then
                Dim com As New SqlCommand("INSERT INTO [tblDBVersion]([ID],[Version],[UpdatedDate],[UpdaterInfo],[Type]) VALUES (@ID,@Version,@UpdatedDate,@UpdaterInfo,@Type )", con)
                com.Parameters.AddWithValue("@ID", MaxId)
                com.Parameters.AddWithValue("@Version", My.Application.Info.Version.ToString)
                com.Parameters.AddWithValue("@UpdatedDate", Now)
                com.Parameters.AddWithValue("@UpdaterInfo", My.Computer.Name & " - " & My.User.Name)
                com.Parameters.AddWithValue("@Type", "VALID")
                'Dim com As New SqlCommand("Update tblDBVErsio1n SET  Version='" & My.Application.Info.Version.ToString & "'", con)
                com.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub


End Class
