Public Class cls_tblLocker
    Private ReadOnly Property tblLocker_INSERT As String
        Get
            Return <tblLocker_INSERT><![CDATA[
                INSERT INTO [tblLocker]
                (
                    [SL],
                    [LockerNumber],
                    [LockerName],
                    [Price], 
                    [Description] , 
                    [DateCreated] , 
                    [LastAccessed] 
                )
                VALUES
                (
                    @SL,
                    @LockerNumber,
                    @LockerName,
                    @Price, 
                    @Description , 
                    @DateCreated , 
                    @LastAccessed 
                )
                    ]]></tblLocker_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblLocker_UPDATE As String
        Get
            Return <tblLocker_UPDATE><![CDATA[
                UPDATE [tblLocker]
                SET 
                    [LockerName]=@LockerName,
                    [Price]=@Price, 
                    [Description]=@Description  
                WHERE
                    [LockerNumber]=@LockerNumber 
                    ]]></tblLocker_UPDATE>.Value
        End Get
    End Property

    Private ReadOnly Property tblLocker_MAX_ID As String
        Get
            Return <tblLocker_MAX_ID><![CDATA[
                SELECT MAX([SL]) FROM [tblLocker]
                    ]]></tblLocker_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblLocker_Delete As String
        Get
            Return <tblLocker_Delete><![CDATA[
                DELETE FROM [tblLocker] WHERE [LockerNumber]=@LockerNumber
                    ]]></tblLocker_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblLocker_SELECT As String
        Get
            Return <tblLocker_SELECT><![CDATA[
                SELECT
                    [LockerNumber],
                    [LockerName],
                    [Price], 
                    [Description] 
                FROM
                    [tblLocker]
                   ]]></tblLocker_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblLocker_SELECT_Booking As String
        Get
            Return <tblLocker_SELECT><![CDATA[
                SELECT
                    A.[LockerNumber],
                    A.[LockerName],
                    A.[Price] as [Price1], 
                    A.[Description],
                    B.[Sl], 
                    B.[ClientName], 
                    B.[PhoneNumber] , 
                    B.[Address] , 
                    B.[BookingDate] , 
                    B.[StartDate] , 
                    B.[EndDate] , 
                    B.[Status] , 
                    B.[Time] , 
                    B.[TimeType]  , 
                    B.[Price]  as [Price2]
                FROM
                    [tblLocker] [A] 
                LEFT OUTER JOIN
                    (
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
                            [Price] 
                        FROM
                            [tblLockerBooking] WHERE [SL] in (SELECT MAX(sl) from [tblLockerBooking] GROUP BY [LockerNumber])
                    ) [B] ON A.[LockerNumber]=B.[LockerNumber]
                   ]]></tblLocker_SELECT>.Value
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
        Dim comID As New SQLCommand(tblLocker_MAX_ID, conn)
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
                           ByVal LockerName As String, _
                           ByVal Price As String, _
                           ByVal Description As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As String
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblLocker_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim SL As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@SL", SL)
            .AddWithValue("@LockerNumber", LockerNumber)
            .AddWithValue("@LockerName", LockerName)
            .AddWithValue("@Price", Val(Price))
            .AddWithValue("@Description", Description)
            .Add("@DateCreated", SqlDbType.DateTime).Value = Now
            .Add("@LastAccessed", SqlDbType.DateTime).Value = Now
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
        Return LockerNumber
    End Function
    Public Function Update( _
                           ByVal LockerNumber As String, _
                           ByVal LockerName As String, _
                           ByVal Price As String, _
                           ByVal Description As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblLocker_UPDATE, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@LockerName", LockerName)
            .AddWithValue("@Price", Price)
            .AddWithValue("@Description", Description)
            .AddWithValue("@LockerNumber", LockerNumber)
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
        Return Val(LockerNumber)
    End Function
    Public Function Delete(ByVal LockerNumber As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblLocker_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@LockerNumber", LockerNumber)
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
        LOCKER_WITH_LASTBOOKING = 1
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
                comSelect.CommandText = tblLocker_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.LOCKER_WITH_LASTBOOKING
                comSelect.CommandText = tblLocker_SELECT_Booking & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "") & " ORDER BY a.[SL]"
                'Case SelectionType.SELECT_PRODUCT
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
