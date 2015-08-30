Public Class cls_tblLockerBooking
    Private ReadOnly Property tblLockerBooking_INSERT As String
        Get
            Return <tblLockerBooking_INSERT><![CDATA[
                INSERT INTO [tblLockerBooking]
                (
                    [Sl],
                    [LockerNumber],
                    [ClientName], 
                    [PhoneNumber] , 
                    [Address] , 
                    [BookingDate] , 
                    [StartDate] , 
                    [EndDate] , 
                    [Status] , 
                    [Time] , 
                    [TimeType]  , 
                    [Price] ,
                    [WorkerID] 
                )
                VALUES
                (
                    @Sl,
                    @LockerNumber,
                    @ClientName, 
                    @PhoneNumber , 
                    @Address , 
                    @BookingDate , 
                    @StartDate , 
                    @EndDate  , 
                    @Status , 
                    @Time , 
                    @TimeType , 
                    @Price ,
                    @WorkerID 
                )
                    ]]></tblLockerBooking_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblLockerBooking_UPDATE As String
        Get
            Return <tblLockerBooking_UPDATE><![CDATA[
                UPDATE [tblLockerBooking]
                SET  
                    [Status]=@Status, 
                    [EndDate]=@EndDate  
                WHERE
                    [Sl]=@Sl 
                    ]]></tblLockerBooking_UPDATE>.Value
        End Get
    End Property

    Private ReadOnly Property tblLockerBooking_MAX_ID As String
        Get
            Return <tblLockerBooking_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblLockerBooking]
                    ]]></tblLockerBooking_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblLockerBooking_Delete As String
        Get
            Return <tblLockerBooking_Delete><![CDATA[
                DELETE FROM [tblLockerBooking] WHERE [Sl]=@Sl
                    ]]></tblLockerBooking_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblLockerBooking_SELECT As String
        Get
            Return <tblLockerBooking_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [LockerNumber],
                    [ClientName], 
                    [PhoneNumber] , 
                    [Address] , 
                    [BookingDate] , 
                    [StartDate] , 
                    [EndDate] , 
                    [Status] , 
                    [Time] , 
                    [TimeType]  , 
                    [Price] , 
                    [WorkerID] 
                FROM
                    [tblLockerBooking]
                   ]]></tblLockerBooking_SELECT>.Value
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
        Dim comID As New SQLCommand(tblLockerBooking_MAX_ID, conn)
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
                           ByVal LockerNumber As String, _
                           ByVal ClientName As String, _
                           ByVal PhoneNumber As String, _
                           ByVal Address As String, _
                           ByVal BookingDate As Date, _
                           ByVal StartDate As Date, _
                           ByVal EndDate As Date, _
                           ByVal Status As String, _
                           ByVal Time As Integer, _
                           ByVal TimeType As String, _
                           ByVal Price As Double, _
                           ByVal WorkerID As Integer, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblLockerBooking_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@LockerNumber", LockerNumber)
            .AddWithValue("@ClientName", ClientName)
            .AddWithValue("@PhoneNumber", PhoneNumber)
            .AddWithValue("@Address", Address)
            .Add("@BookingDate", SqlDbType.DateTime).Value = BookingDate
            .Add("@StartDate", SqlDbType.DateTime).Value = StartDate
            .Add("@EndDate", SqlDbType.DateTime).Value = EndDate
            '.AddWithValue("@BookingDate", BookingDate)
            '.AddWithValue("@StartDate", StartDate)
            '.AddWithValue("@EndDate", EndDate)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Time", Time)
            .AddWithValue("@TimeType", TimeType)
            .AddWithValue("@Price", Price)
            .AddWithValue("@WorkerID", WorkerID)
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
    Public Function Update( _
                           ByVal Sl As Integer, _
                           ByVal Status As String, _
                           ByVal EndDate As Date, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblLockerBooking_UPDATE, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@Status", Status)
            .Add("@EndDate", SqlDbType.DateTime).Value = EndDate
            .AddWithValue("@Sl", Sl)
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
    Public Function Delete(ByVal Sl As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblLockerBooking_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@Sl", Sl)
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
        DISTINCT_ClientName = 1
        SELECT_PRODUCT = 2
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
                comSelect.CommandText = tblLockerBooking_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_ClientName
            Case SelectionType.SELECT_PRODUCT
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



End Class
