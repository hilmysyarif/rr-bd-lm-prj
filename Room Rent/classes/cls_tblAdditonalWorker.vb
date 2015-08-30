Public Class cls_tblAdditonalWorker
    Private ReadOnly Property tblAdditonalWorker_INSERT As String
        Get
            Return <tblAdditonalWorker_INSERT><![CDATA[
                INSERT INTO [tblAdditonalWorker]
                (
                    [BookingID],
                    [WorkerID],
                    [AddingTime], 
                    [StartedTime], 
                    [StopTime] 
                )
                VALUES
                (
                    @BookingID,
                    @WorkerID,
                    @AddingTime, 
                    @StartedTime, 
                    @StopTime 
                )
                    ]]></tblAdditonalWorker_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblAdditonalWorker_UPDATE As String
        Get
            Return <tblAdditonalWorker_UPDATE><![CDATA[
                UPDATE [tblAdditonalWorker]
                SET 
                    [WorkerID]=@WorkerID,
                    [AddingTime]=@AddingTime, 
                    [StartedTime]=@StartedTime,
                    [StopTime]=@StopTime  
                WHERE
                    [BookingID]=@BookingID 
                    ]]></tblAdditonalWorker_UPDATE>.Value
        End Get
    End Property

    Private ReadOnly Property tblAdditonalWorker_MAX_ID As String
        Get
            Return <tblAdditonalWorker_MAX_ID><![CDATA[
                SELECT MAX([BookingID]) FROM [tblAdditonalWorker]
                    ]]></tblAdditonalWorker_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblAdditonalWorker_Delete As String
        Get
            Return <tblAdditonalWorker_Delete><![CDATA[
                DELETE FROM [tblAdditonalWorker] WHERE [BookingID]=@BookingID
                    ]]></tblAdditonalWorker_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblAdditonalWorker_SELECT As String
        Get
            Return <tblAdditonalWorker_SELECT><![CDATA[
                SELECT
                    [BookingID],
                    [WorkerID],
                    [StartedTime], 
                    [StopTime] 
                FROM
                    [tblAdditonalWorker]
                   ]]></tblAdditonalWorker_SELECT>.Value
        End Get
    End Property

    'Public Function MaxID(Optional ByRef conn As OleDbConnection = Nothing) As Integer
    '    Dim isDisposeConn As Boolean = False
    '    Dim objConn As clsConnection = Nothing
    '    If conn Is Nothing Then
    '        objConn = New clsConnection
    '        conn = objConn.connect
    '        isDisposeConn = True
    '    End If

    '    Dim ID As Integer = 1 ' 1 states that, the ID field will start from 1
    '    Dim comID As New OleDbCommand(tblAdditonalWorker_MAX_ID, conn)
    '    Dim obj
    '    Try
    '        obj = comID.ExecuteScalar
    '    Catch ex As Exception
    '        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
    '        comID.Dispose()
    '        Throw ex
    '    End Try
    '    If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
    '    comID.Dispose()
    '    If IsNumeric(obj) Then
    '        ID = Val(obj) + 1
    '    End If
    '    Return ID
    'End Function

    Public Function Insert( _
                           ByVal BookingID As Integer, _
                           ByVal WorkerID As Integer, _
                           ByVal AddingTime As Date, _
                           ByVal StartedTime As Date, _
                           ByVal StopTime As Date, _
                           Optional ByRef conn As OleDbConnection = Nothing, Optional ByRef transact As OleDbTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New OleDbCommand(tblAdditonalWorker_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        ' Dim BookingID As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@BookingID", BookingID)
            .AddWithValue("@WorkerID", WorkerID)
            .Add("@AddingTime", OleDbType.Date).Value = AddingTime
            .Add("@StartedTime", OleDbType.Date).Value = StartedTime
            .Add("@StopTime", OleDbType.Date).Value = StopTime
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
        Return BookingID
    End Function
    Public Function Update( _
                           ByVal BookingID As Integer, _
                           ByVal WorkerID As Integer, _
                           ByVal AddingTime As Date, _
                           ByVal StartedTime As Date, _
                           ByVal StopTime As Date, _
                           Optional ByRef conn As OleDbConnection = Nothing, Optional ByRef transact As OleDbTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New OleDbCommand(tblAdditonalWorker_UPDATE, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@StartedTime", StartedTime)
            .AddWithValue("@StopTime", StopTime)
            .AddWithValue("@BookingID", BookingID)
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
        Return BookingID
    End Function
    Public Function Delete(ByVal BookingID As String, Optional ByRef conn As OleDbConnection = Nothing, Optional ByRef transact As OleDbTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New OleDbCommand(tblAdditonalWorker_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@BookingID", BookingID)
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

    Enum SelectionType
        ALL = 0
        DISTINCT_StartedTime = 1
        SELECT_PRODUCT = 2
    End Enum
    Public Function Selection(Optional ByVal typ As SelectionType = 0, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of OleDbParameter) = Nothing, Optional ByRef conn As OleDbConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New OleDbCommand("", conn)
        Select Case typ
            Case SelectionType.ALL
                comSelect.CommandText = tblAdditonalWorker_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_StartedTime
            Case SelectionType.SELECT_PRODUCT
        End Select

        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
        Dim daSelect As New OleDbDataAdapter(comSelect)
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



End Class
