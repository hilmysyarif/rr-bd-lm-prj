Imports System.IO

Public Class cls_tblWorkers
    Enum FieldNames
        WorkerID
        WorkerName
        DC_Date
        Started_Date
        Email
        MobileNo
        PreferredContactMethod
        AdditionalInfo
        dc_file
        d_file_ext
        dc_file_name
        RealName
        DOB
        Nation
    End Enum


    Private ReadOnly Property tblWorkers_INSERT As String
        Get
            Return <tblWorkers_INSERT><![CDATA[
                INSERT INTO [tblWorkers]
                (
                    [WorkerID],
                    [WorkerName],
                    [DC_Date],
                    [Started_Date],
                    [Email],
                    [MobileNo],
                    [PreferredContactMethod],
                    [AdditionalInfo],
                    [dc_file],
                    [dc_file_ext],
                    [dc_file_name],
                    [RealName],
                    [DOB],
                    [Nation]
                )
                VALUES
                (
                    @WorkerID,
                    @WorkerName,
                    @DC_Date,
                    @Started_Date,
                    @Email,
                    @MobileNo,
                    @PreferredContactMethod,
                    @AdditionalInfo,
                    @dc_file,
                    @dc_file_ext,
                    @dc_file_name,
                    @RealName,
                    @DOB,
                    @Nation
                )
                    ]]></tblWorkers_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblWorkers_Update As String
        Get
            Return <tblWorkers_INSERT><![CDATA[
                UPDATE [tblWorkers]
                SET
                    [WorkerName]=@WorkerName,
                    [DC_Date]=@DC_Date,
                    [Started_Date]=@Started_Date,
                    [Email]=@Email,
                    [MobileNo]=@MobileNo,
                    [PreferredContactMethod]=@PreferredContactMethod,
                    [AdditionalInfo]=@AdditionalInfo ,
                    [RealName]=@RealName ,
                    [DOB]=@DOB ,
                    [Nation]=@Nation 
                WHERE
                    [WorkerID]=@WorkerID

                    ]]></tblWorkers_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblWorkers_Update_Availability As String
        Get
            Return <tblWorkers_INSERT><![CDATA[
                UPDATE [tblWorkers]
                SET
                    [NotAvailableTill]=@NotAvailableTill,
                    [AvailabilityComment]=@AvailabilityComment 
                WHERE
                    [WorkerID]=@WorkerID

                    ]]></tblWorkers_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblWorkers_Update_DC As String
        Get
            Return <tblWorkers_INSERT><![CDATA[
                UPDATE [tblWorkers]
                SET
                    [DC_Date]=@DC_Date,
                    [dc_file]=@dc_file,
                    [dc_file_ext]=@dc_file_ext,
                    [dc_file_name]=@dc_file_name  
                WHERE
                    [WorkerID]=@WorkerID

                    ]]></tblWorkers_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkers_MAX_ID As String
        Get
            Return <tblWorkers_MAX_ID><![CDATA[
                SELECT MAX([WorkerID]) FROM [tblWorkers]
                    ]]></tblWorkers_MAX_ID>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkers_Delete As String
        Get
            Return <tblWorkers_Delete><![CDATA[
                DELETE FROM [tblWorkers] WHERE [WorkerID]=@WorkerID
                    ]]></tblWorkers_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblWorkers_SELECT As String
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
                    [Nation], isnull(b.cnt_fav,0 ) as Favs, IsEscort
                FROM
                    [tblWorkers] a
                    left outer join (Select WorkerId as wid, COUNT(itemid) as cnt_fav from [tblWorkerFavourites] group by WorkerId)b on a.workerid = b.wid 

                   ]]></tblWorkers_SELECT>.Value
        End Get
    End Property

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
    Public Function MaxID(Optional ByRef conn As SQLConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim ID As Integer = 1 ' 1 states that, the ID field will start from 1
        Dim comID As New SQLCommand(tblWorkers_MAX_ID, conn)
        Dim obj
        Try
            obj = comID.ExecuteScalar
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comID.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comID.Dispose()
        If IsNumeric(obj) Then
            ID = Val(obj) + 1
        End If
        Return ID
    End Function

    Public Function Insert( _
                           ByVal WorkerName As String, _
                           ByVal DC_Date As Date, _
                           ByVal Started_Date As Date, _
                           ByVal Email As String, _
                           ByVal MobileNo As String, _
                           ByVal PreferredContactMethod As String, _
                           ByVal AdditionalInfo As String, _
                           ByVal dc_file As String, _
                           ByVal RealName As String, _
                           ByVal DOB As Date, _
                           ByVal Nation As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim WorkerID As Integer = MaxID(conn)
        Dim comInsert As New SqlCommand(tblWorkers_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        With comInsert.Parameters
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@WorkerName", WorkerName)
            .Add("@DC_Date", SqlDbType.DateTime).Value = DC_Date
            .Add("@Started_Date", SqlDbType.DateTime).Value = Started_Date
            .AddWithValue("@Email", Email)
            .AddWithValue("@MobileNo", MobileNo)
            .AddWithValue("@PreferredContactMethod", PreferredContactMethod)
            .AddWithValue("@AdditionalInfo", AdditionalInfo)
            .AddWithValue("@RealName", RealName)
            .AddWithValue("@DOB", DOB)
            .AddWithValue("@Nation", Nation)
            If dc_file = "" Then
                '.AddWithValue("@DC_File", DBNull.Value)
                .Add("@DC_File", SqlDbType.Image).Value = DBNull.Value
                .AddWithValue("@DC_File_Ext", "")
                .AddWithValue("@DC_File_Name", "")
            Else
                Dim fileName As String = Now.ToString("yyyyMMddHHmmmssfff")
                .AddWithValue("@DC_File", FileToByteArray(dc_file))
                .AddWithValue("@DC_File_Ext", Path.GetExtension(dc_file))
                .AddWithValue("@DC_File_Name", fileName)
                Try
                    My.Computer.FileSystem.CopyFile(dc_file, My.Computer.FileSystem.CombinePath(DcFolder, fileName + Path.GetExtension(dc_file)))
                Catch ex As Exception
                End Try
            End If
            '.AddWithValue("@", )
        End With
        Dim obj
        Try
            obj = comInsert.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comInsert.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comInsert.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Inserted")
        End If
        Return WorkerID
    End Function

    Public Function Update( _
                           ByVal WorkerID As Integer, _
                           ByVal WorkerName As String, _
                           ByVal DC_Date As Date, _
                           ByVal Started_Date As Date, _
                           ByVal Email As String, _
                           ByVal MobileNo As String, _
                           ByVal PreferredContactMethod As String, _
                           ByVal AdditionalInfo As String, _
                           ByVal dc_file As String, _
                           ByVal RealName As String, _
                           ByVal DOB As Date, _
                           ByVal Nation As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comUpdate As New SqlCommand(tblWorkers_Update, conn)
        If transact IsNot Nothing Then
            comUpdate.Transaction = transact
        End If

        With comUpdate.Parameters
            .AddWithValue("@WorkerName", WorkerName)
            .Add("@DC_Date", SqlDbType.DateTime).Value = DC_Date
            .Add("@Started_Date", SqlDbType.DateTime).Value = Started_Date
            .AddWithValue("@Email", Email)
            .AddWithValue("@MobileNo", MobileNo)
            .AddWithValue("@PreferredContactMethod", PreferredContactMethod)
            .AddWithValue("@AdditionalInfo", AdditionalInfo)
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@RealName", RealName)
            .AddWithValue("@DOB", DOB)
            .AddWithValue("@Nation", Nation)
        End With
        Dim obj

        Try
            obj = comUpdate.ExecuteNonQuery

            If dc_file.Trim <> "" Then
                Dim comUpdateFile As New SqlCommand(tblWorkers_Update_DC, conn)
                If transact IsNot Nothing Then
                    comUpdateFile.Transaction = transact
                End If
                With comUpdateFile.Parameters
                    .Add("@DC_Date", SqlDbType.DateTime).Value = DC_Date
                    Dim fileName As String = Now.ToString("yyyyMMddHHmmmssfff")
                    .AddWithValue("@DC_File", FileToByteArray(dc_file))
                    .AddWithValue("@DC_File_Ext", Path.GetExtension(dc_file))
                    .AddWithValue("@DC_File_Name", fileName)
                    .AddWithValue("@WorkerID", WorkerID)
                    Try
                        My.Computer.FileSystem.CopyFile(dc_file, My.Computer.FileSystem.CombinePath(DcFolder, fileName + Path.GetExtension(dc_file)))
                    Catch ex As Exception
                    End Try
                End With
                comUpdateFile.ExecuteNonQuery()

            End If
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comUpdate.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comUpdate.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Inserted")
        End If
        Return WorkerID
    End Function


    Public Function Update_Availability( _
                             ByVal WorkerID As Integer, _
                             ByVal NotAvailableTill As Date, _
                             ByVal AvailabilityComment As String, _
                             Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comUpdate As New SqlCommand(tblWorkers_Update_Availability, conn)
        If transact IsNot Nothing Then
            comUpdate.Transaction = transact
        End If

        With comUpdate.Parameters
            .Add("@NotAvailableTill", SqlDbType.DateTime).Value = NotAvailableTill
            .AddWithValue("@AvailabilityComment", AvailabilityComment)
            .AddWithValue("@WorkerID", WorkerID)
        End With

        Dim obj

        Try
            obj = comUpdate.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comUpdate.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comUpdate.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Updated")
        End If
        Return WorkerID
    End Function

    Public Function Delete_Worker(ByVal WorkerID As String, Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SqlCommand(tblWorkers_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@WorkerID", WorkerID)
        End With
        Dim obj
        Try
            obj = comDelete.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comDelete.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comDelete.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Deleted")
        End If
        Return Val(obj)
    End Function
    Enum SelectType
        All
        All_with_availability
    End Enum

    Public Function Selection1(Optional ByVal _type As SelectType = SelectType.All, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SqlCommand("", conn)
        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
        Select Case _type
            Case SelectType.All
                comSelect.CommandText = tblWorkers_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectType.All_with_availability
                comSelect.CommandText = tblWorkers_SELECT_with_availabiltity & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("AND"), " ", " AND ") & SelectString, "")
        End Select
        Dim daSelect As New SqlDataAdapter(comSelect)
        Dim dtSelect As New DataTable
        Try
            daSelect.Fill(dtSelect)
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            daSelect.Dispose()
            dtSelect.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        daSelect.Dispose()
        Return dtSelect
    End Function

    Enum SelectionType
        ALL = 0
        DC_14_DAYS = 1
        DC_EXPIRED = 2
        SUSPENDED = 3
        AVAILABLE = 4
        QUEUE = 5
        ACTIVE = 6
        NOT_AVAILABLE = 7
        AVAILABLE_WITHOUT_ACTIVE = 8
        BOOKINGID = 9
        AvailableWithoutLogin = 10
        ACTIVE_Without_bookingID = 11
    End Enum
    Public Sub LoadWorkerInListView(ByVal lst As Object, Optional ByVal Type As SelectionType = 0, Optional ByVal value1 As String = "")
        Dim dt As DataTable = Nothing
        Select Case Type

            Case SelectionType.ALL
                dt = Selection1(SelectType.All, " 1=1 Order By [WorkerName]")
            Case SelectionType.DC_14_DAYS
                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("@DC_Date1", SqlDbType.DateTime) With {.Value = Today})
                lstP.Add(New SqlParameter("@DC_Date2", SqlDbType.DateTime) With {.Value = Today.AddDays(14)})
                dt = Selection1(cls_tblWorkers.SelectType.All, "DATEADD(Month,3,[DC_Date]) BETWEEN @DC_Date1 AND @DC_Date2 ORDER BY [WorkerName]", lstP)
            Case SelectionType.DC_EXPIRED
                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("@DC_Date1", SqlDbType.DateTime) With {.Value = Today.AddDays(-1400)})
                lstP.Add(New SqlParameter("@DC_Date2", SqlDbType.DateTime) With {.Value = Today})
                dt = Selection1(cls_tblWorkers.SelectType.All, "DATEADD(Month,3,[DC_Date]) BETWEEN @DC_Date1 AND @DC_Date2 ORDER BY [WorkerName]", lstP)
            Case SelectionType.SUSPENDED
                dt = Selection1(cls_tblWorkers.SelectType.All, "[Status]='SUSPENDED' ORDER BY [WorkerName]")
            Case SelectionType.AVAILABLE
                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT' and [Status]<>'SUSPENDED') and [NotAvailableTill]<GETDATE() ORDER BY [WorkerName]")
            Case SelectionType.NOT_AVAILABLE
                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("WorkerName", value1.Trim))
                dt = Selection1(cls_tblWorkers.SelectType.All, "[WorkerName] like '%' + @WorkerName + '%' AND WorkerID not in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT' and [Status]<>'SUSPENDED') and [NotAvailableTill]<GETDATE() ORDER BY [WorkerName]", lstP)
            Case SelectionType.QUEUE

                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("@Date1", SqlDbType.DateTime) With {.Value = Today})
                lstP.Add(New SqlParameter("@Date2", SqlDbType.DateTime) With {.Value = Today.AddDays(1).AddSeconds(-1)})
                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblActiveWorker WHERE workingdate Between @Date1 and @Date2 and (([Room]='' and [Status]='') OR [Status]='QUEUE')) ORDER BY [WorkerName]", lstP)

            Case SelectionType.ACTIVE

                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblActiveWorker WHERE GETDATE() BETWEEN DATEADD(Minute,-1,[starttime]) and DATEADD(Minute,([Service] ),[starttime]) and [Status] in ('','STARTED')) ORDER BY [WorkerName]")

            Case SelectionType.AVAILABLE_WITHOUT_ACTIVE

                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblCheckIn WHERE [Status]<>'OUT') and WorkerID not in (Select WorkerID from tblActiveWorker Where Status in ('','STARTED')) ORDER BY [WorkerName]")

            Case SelectionType.BOOKINGID

                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("BookingID", Val(value1)))
                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblActiveWorker WHERE BookingID =@BookingID and ([Status]='' OR [Status]='STARTED') ) ORDER BY [WorkerName]", lstP)

            Case SelectionType.AvailableWithoutLogin

                Dim lstP As New List(Of SqlParameter)
                lstP.Add(New SqlParameter("@NotAvailableTill", SqlDbType.DateTime) With {.Value = value1})
                dt = Selection1(SelectType.All, " NotAvailableTill<@NotAvailableTill Order By [WorkerName]", lstP)

            Case SelectionType.ACTIVE_Without_bookingID

                dt = Selection1(cls_tblWorkers.SelectType.All, "WorkerID in (SELECT WORKERID from tblActiveWorker WHERE GETDATE() BETWEEN DATEADD(Minute,-1,[starttime]) and DATEADD(Minute,([Service] ),[starttime]) and [Status] in ('','STARTED') and bookingID not in (" & value1 & ")) ORDER BY [WorkerName]")


        End Select

        If TypeOf (lst) Is ListView Then
            lst.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                Dim drItem As System.Data.DataRow = dt.Rows(i)
                Dim li As New ListViewItem
                li.Text = drItem("WorkerName").ToString & IIf(drItem("IsEscort").ToString = "YES", "{E}", "")

                li.Tag = drItem("WorkerID").ToString
                lst.Items.Add(li)
            Next
        ElseIf TypeOf (lst) Is DataGridView Then
            lst.rows.Clear()
            For i = 0 To dt.Rows.Count - 1
                Dim drItem As System.Data.DataRow = dt.Rows(i)
                lst.rows.Add(drItem("WorkerID").ToString, drItem("WorkerName").ToString & IIf(drItem("IsEscort").ToString = "YES", "{E}", ""), "")
                'lst.Rows(lst.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                lst.Rows(lst.Rows.Count - 1).Height = 35
            Next
        End If
    End Sub

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


    Function SelectScalar(ByVal fm As FieldNames, ByVal WorkerID As Integer) As Object

        Dim retValue As Object = Nothing
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim comSQL As New SqlCommand("Select [" & fm.ToString & "] from tblWorkers where [WorkerID]=@WorkerID", conn)

        Try
            comSQL.Parameters.Clear()
            comSQL.Parameters.AddWithValue("@WorkerID", WorkerID)
            retValue = comSQL.ExecuteScalar
        Catch ex As Exception
        End Try


        Try
            comSQL.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return retValue

    End Function
End Class
