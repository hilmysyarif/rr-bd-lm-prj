'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblWorkers
Inherits Database_Table_code_class_tblWorkers

    Enum SelectionType
        All = 0
        VIEW = 1
        All_with_availability = 2
    End Enum
    Private ReadOnly Property tblWorkers_SELECT_with_availabiltity As String
        Get
            Return <tblWorkers_SELECT><![CDATA[

                SELECT
                    [WorkerID],
                    [WorkerName],
                    [DC_Date],
                    [Started_Date],
                    [Email],
                    [MobileNo],
                    [PreferredContactMethod],
                    [AdditionalInfo] as [Notes],
                    [NotAvailableTill],
                    [AvailabilityComment],
                    [RealName],
                    [DOB],
                    [Nation]
                FROM
                    [tblWorkers]
                WHERE
                    1=1

                   ]]></tblWorkers_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblWorkers_SELECT_VIEW As String
        Get
            Return <tblWorkers_SELECT><![CDATA[

                SELECT
                    [WorkerID],
                    [WorkerName],
                    [DC_Date],
                    [Started_Date],
                    [Email],
                    [MobileNo],
                    [PreferredContactMethod],
                    [AdditionalInfo] as [Notes],
                    case when [dc_file] is null then 'NO' else 'YES' end  as [dcf],
                    [RealName],
                    [DOB],
                    [Nation], isnull(b.cnt_fav,0 ) as Favs,IsEscort
                FROM
                    [tblWorkers] a
                    left outer join (Select WorkerId as wid, COUNT(itemid) as cnt_fav from [tblWorkerFavourites] group by WorkerId)b on a.workerid = b.wid 
                WHERE 1=1
                   ]]></tblWorkers_SELECT>.Value
        End Get
    End Property

    Function Selection(Optional ByVal _selection_type As SelectionType = SelectionType.All, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable
        Dim dt As New DataTable
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comSelection As New SqlCommand("", _conn)
        If Not _transac Is Nothing Then
            comSelection.Transaction = _transac
        End If

        Select Case _selection_type
            Case SelectionType.All
                comSelection.CommandText = tblWorkers_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.VIEW
                comSelection.CommandText = tblWorkers_SELECT_VIEW & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_with_availability
                comSelection.CommandText = tblWorkers_SELECT_with_availabiltity & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelection.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comSelection.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function

    Private ReadOnly Property tblCheckIn_DC_FILENAME As String
        Get
            Return <tblWorkers_tblActiveWorker_SELECT><![CDATA[
                Select [DC_File_Name]+[DC_File_Ext] from [tblWorkers] where [WorkerId]=@WorkerID
                    ]]></tblWorkers_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblCheckIn_DC_FILE_DATA As String
        Get
            Return <tblWorkers_tblActiveWorker_SELECT><![CDATA[
                Select [DC_File] from [tblWorkers] where [DC_File_Name]=@DC_File_Name
                    ]]></tblWorkers_tblActiveWorker_SELECT>.Value
        End Get
    End Property


    Function LoadLastestDC_File(ByVal WorkerId As Integer) As String
        Dim dc_filename As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim comSQL As New SqlCommand(tblCheckIn_DC_FILENAME, conn)

        Try
            comSQL.Parameters.Clear()
            comSQL.Parameters.AddWithValue("@WorkerID", WorkerId)
            dc_filename = comSQL.ExecuteScalar
        Catch ex As Exception
        End Try

        Try
            If dc_filename <> "" Then
                dc_filename = My.Computer.FileSystem.CombinePath(DcFolder, dc_filename)
                If Not My.Computer.FileSystem.FileExists(dc_filename) Then
                    comSQL = New SqlCommand(tblCheckIn_DC_FILE_DATA, conn)
                    comSQL.Parameters.Clear()
                    Dim fi As New FileInfo(dc_filename)
                    comSQL.Parameters.AddWithValue("@DC_File_Name", fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length))
                    ByteArray2File(comSQL.ExecuteScalar, dc_filename)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            comSQL.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return dc_filename

    End Function
End Class