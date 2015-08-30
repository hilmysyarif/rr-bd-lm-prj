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

    Dim ExcludeTables_ClearDB As String() = {"tblCalender", "tblRoom", "tblService", "tblSettings", "tblLookUp", "tblLocker"}

    Dim Tables_to_be_updated As List(Of Tables_Update) = New List(Of Tables_Update) From {(New Tables_Update("tblRoom", "room", {"Status", "Usable", "Comment"}))}

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

        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim MS As New System.IO.MemoryStream()
        BF.Serialize(MS, ds)



        ''Dim sr As New IO.StreamReader(MS)
        ''MS.Position = 0
        'Dim StringContent As String = ds.GetXml
        ''Dim StringContent As String = sr.ReadToEnd
        'Dim objEncryption As New clsEncryption
        'Dim EncryptedStringContent As String = objEncryption.Encrypt(StringContent)
        'My.Computer.FileSystem.WriteAllText(FileName, EncryptedStringContent, False)



        'Dim objEncryption As New clsEncryptionFile
        'My.Computer.FileSystem.WriteAllBytes(FileName, objEncryption.Encrypt(MS).GetBuffer, False)

        My.Computer.FileSystem.WriteAllBytes(FileName, MS.GetBuffer, False)

        'sr.Dispose()


        MS.Flush()
        MS.Dispose()
        ds.Dispose()
        da.Dispose()
        objCon.Dispose()
        Return True
    End Function
    Function ImportDb(ByVal FileName As String) As Boolean
        Dim ds As New DataSet
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()


        'Dim objEncryption As New clsEncryptionFile
        'Dim bData As Byte()
        'Dim br As IO.BinaryReader = New IO.BinaryReader(System.IO.File.OpenRead(FileName))
        'bData = br.ReadBytes(br.BaseStream.Length)
        'Dim ms As IO.MemoryStream = New IO.MemoryStream(bData, 0, bData.Length)
        'ms.Write(bData, 0, bData.Length)
        'ds = DirectCast(BF.Deserialize(New IO.MemoryStream(objEncryption.Decrypt(bData))), DataSet)

        'ms.Flush()
        'ms.Dispose()





        'Dim EncryptedStringContent As String = My.Computer.FileSystem.ReadAllText(FileName)
        'Dim objEncryption As New clsEncryption
        'Dim StringContent As String = objEncryption.Decrypt(EncryptedStringContent)

        'Dim ms As New IO.MemoryStream
        'Dim sw As New IO.StreamWriter(ms)
        'sw.Write(StringContent)
        'sw.Flush()
        ''ms.Position = 0
        ''ds = DirectCast(BF.Deserialize(ms), DataSet)
        'ds.ReadXml(MS)
        ''ms.Flush()
        ''ms.Dispose()


        Dim bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(FileName)
        ds = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), DataSet)


        Dim objCon As New clsConnection

        Dim comInsertDeleteUpdate As New SqlCommand("", objCon.connect)
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
        Dim comInsertDeleteUpdate As New SQLCommand("", objCon.connect)
        For Each dr As DataRow In GetTables(objCon.connect).Rows
            If Not ExcludeTables_ClearDB.Contains(dr("name").ToString) Then
                comInsertDeleteUpdate.CommandText = "Delete from  [" & dr("name").ToString & "]"
                comInsertDeleteUpdate.ExecuteNonQuery()
            End If
        Next
        comInsertDeleteUpdate.Dispose()
    End Sub

    Sub CheckDBVerification()

        Dim objCon As New clsConnection
        Dim con As SqlConnection = objCon.connect
        Dim version As String = ""

        'Try

        '    Dim com As New SqlCommand("Select Version from tblDBVErsion", con)
        '    version = com.ExecuteScalar
        'Catch ex As Exception
        'End Try

        'Dim dbFile As String = db_file
        'If DeveloperPC() Then
        '    Dim dbFileInfo As New IO.FileInfo(dbFile)
        '    Dim dbBlankFileInfo As New IO.FileInfo(New IO.DirectoryInfo(My.Application.Info.DirectoryPath).Parent.Parent.FullName + "\Resources\dbRent_Blank.mdb")
        '    If dbFileInfo.LastWriteTimeUtc < dbBlankFileInfo.LastWriteTimeUtc Then
        '        version = ""
        '    End If
        'End If
        'If version <> My.Application.Info.Version.ToString Then
        '    Dim tmp_filename As String = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Temp, "tnm_update.dbl")
        '    Dim tmp_filename2 As String = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Desktop, "tnm_update" & Now.ToString("yyMMddHHMMSSff") & ".dbl")
        '    Try
        '        If version = "0.0.0.0" Then
        '            UpdateRequired = False
        '        End If
        '        If UpdateRequired Then
        '            ExportDb(tmp_filename)
        '            con.Close()
        '            'Delete all files before renaming the dbFile.
        '            Try
        '                Dim fis As IO.FileInfo() = (New IO.DirectoryInfo((New IO.FileInfo(dbFile)).DirectoryName)).GetFiles("*.mdb")
        '                For Each fi As IO.FileInfo In fis
        '                    Try
        '                        If fi.FullName.ToUpper <> dbFile.ToUpper Then
        '                            fi.Delete()
        '                        End If
        '                    Catch ex As Exception
        '                    End Try
        '                Next
        '            Catch ex As Exception
        '            End Try
        '            Dim dbFile2 As String = "dbRent_" & Now.ToString("yyMMddHHmssff") & ".mdb"
        '            My.Computer.FileSystem.RenameFile(dbFile, dbFile2)
        '            '   My.Computer.FileSystem.WriteAllBytes(dbFile, Room_Rent.My.Resources.Resources.dbRent_blank, False)
        '            con = objCon.connect
        '            If MsgBox("Do you want to Upgrade the Database (Yes) or a New Installation (No) ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Previous Database Found") = MsgBoxResult.Yes Then
        '                ImportDb(tmp_filename)
        '                'Else
        '            End If
        '        End If
        '        Try
        '            Dim com As New SqlCommand("Update tblDBVErsion SET  Version='" & My.Application.Info.Version.ToString & "'", con)
        '            com.ExecuteNonQuery()
        '        Catch ex As Exception
        '        End Try
        '    Catch ex As Exception
        '        Try
        '            My.Computer.FileSystem.CopyFile(tmp_filename, tmp_filename2)
        '            MsgBox("Unable to Update the database." & vbNewLine & "A Backup file stored in " & tmp_filename2, MsgBoxStyle.Information, "Info")
        '        Catch ex1 As Exception
        '            MsgBox("Unable to Update the database.", MsgBoxStyle.Information, "Info")
        '        End Try
        '    End Try
        'End If
        'objCon.Dispose()


    End Sub

End Class
