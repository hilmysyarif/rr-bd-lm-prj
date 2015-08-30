Public Class cls_tblExtraService
    Private ReadOnly Property tblExtraService_INSERT As String
        Get
            Return <tblExtraService_INSERT><![CDATA[
                INSERT INTO [tblExtraService]
                (
                    [Sl],
                    [Service],
                    [BookingID] , 
                    [WorkerID] , 
                    [CreatedDate] , 
                    [MemoNo]  , 
                    [ServiceType] , 
                    [Shift] 
                )
                VALUES
                (
                    @Sl,
                    @Service,
                    @BookingID , 
                    @WorkerID , 
                    @CreatedDate , 
                    @MemoNo, 
                    @ServiceType, 
                    @Shift
                )
                    ]]></tblExtraService_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblExtraService_MAX_ID As String
        Get
            Return <tblExtraService_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblExtraService]
                    ]]></tblExtraService_MAX_ID>.Value
        End Get
    End Property

   

    Private ReadOnly Property tblExtraService_SELECT As String
        Get
            Return <tblExtraService_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Service],
                    [BookingID]  , 
                    [WorkerID] , 
                    [CreatedDate] , 
                    [MemoNo] , 
                    [ServiceType], 
                    [Shift]
                FROM
                    [tblExtraService]
                   ]]></tblExtraService_SELECT>.Value
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
        Dim comID As New SQLCommand(tblExtraService_MAX_ID, conn)
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
                           ByVal Service As Double, _
                           ByVal BookingID As String, _
                           ByVal WorkerID As Double, _
                           ByVal CreatedDate As Date, _
                           ByVal MemoNo As Integer, _
                           ByVal ServiceType As String, _
                           ByVal Shift As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblExtraService_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@Service", Service)
            .AddWithValue("@BookingID", BookingID)
            .AddWithValue("@WorkerID", WorkerID)
            .Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@ServiceType", ServiceType)
            .AddWithValue("@Shift", Shift)
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
        Return Sl
    End Function


    Enum SelectionType
        ALL = 0
    End Enum
    Public Function Selection(Optional ByVal typ As SelectionType = 0, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        Select Case typ
            Case SelectionType.ALL
                comSelect.CommandText = tblExtraService_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
        End Select

        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
        Dim daSelect As New SQLDataAdapter(comSelect)
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

    Private ReadOnly Property tblExtraService_Update_CHANGE_WORKER_select As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                UPDATE
                    [tblExtraService] 
                SET
                    [WorkerId]=@WorkerID1
                 WHERE [BookingID]=@BookingID and [WorkerId]=@WorkerID
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property


    Public Function tblExtraService_Update_CHANGE_WORKER(ByVal BookingID As Integer, ByVal WorkerID As Integer, ByVal NewWorkerID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblExtraService_Update_CHANGE_WORKER_select, conn)
        da.Parameters.Add("@WorkerId1", SqlDbType.Int).Value = NewWorkerID
        da.Parameters.Add("@BookingID", SqlDbType.Int).Value = BookingID
        da.Parameters.Add("@WorkerId", SqlDbType.Int).Value = WorkerID
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

    Private ReadOnly Property tblExtraService_DELETE_q As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                DELETE FROM
                    [tblExtraService] 
                WHERE [BookingID]=@BookingID 
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblExtraService_DELETE(ByVal BookingID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblExtraService_DELETE_q, conn)
        da.Parameters.Add("@BookingID", SqlDbType.Int).Value = BookingID
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

End Class
