Imports System.IO

Public Class cls_tblCheckIN
    Private ReadOnly Property tblCheckIN_CHECKIN As String
        Get
            Return <tblCheckIN_CHECKIN><![CDATA[
                INSERT INTO [tblCheckIn]
                (
                    [CheckInId],
                    [WorkerID],
                    [CheckInRoomNo],
                    [CheckInDate],
                    [DC_Date],
                    [DC_File],
                    [DC_File_Name],
                    [DC_File_Ext]
                )
                VALUES
                (
                    @CheckInId,
                    @WorkerID,
                    @CheckInRoomNo,
                    @CheckInDate,
                    @DC_Date,
                    @DC_File,
                    @DC_File_Name,
                    @DC_File_Ext
                )
                    ]]></tblCheckIN_CHECKIN>.Value
        End Get
    End Property

    Private ReadOnly Property tblCheckIn_Delete As String
        Get
            Return <tblCheckIn_Delete><![CDATA[
                DELETE FROM [tblCheckIn] WHERE [WorkerID]=@WorkerID
                    ]]></tblCheckIn_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblCheckIN_MAX_ID As String
        Get
            Return <tblCheckIN_MAX_ID><![CDATA[
                SELECT MAX([CheckInId]) FROM [tblCheckIn]
                    ]]></tblCheckIN_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblWorkers_CHECKIN As String
        Get
            Return <tblWorkers_CHECKIN><![CDATA[
                UPDATE [tblWorkers] SET [CheckInRoomNo]=@CheckInRoomNo,[CheckInDate]=@CheckInDate,[CheckInID]=@CheckInID WHERE [WorkerID]=@WorkerID
                    ]]></tblWorkers_CHECKIN>.Value
        End Get
    End Property

    Public Function MaxID_tblCheckIn(Optional ByRef conn As SQLConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim ID As Integer = 1 ' 1 states that, the ID field will start from 1
        Dim comID As New SQLCommand(tblCheckIN_MAX_ID, conn)
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






    Public Function CheckIn( _
                           ByVal WorkerID As Integer, _
                           ByVal CheckInRoomNo As String, _
                           ByVal CheckInDate As Date, _
                           ByVal DC_Date As Date, _
                           ByVal DC_FileName As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim CheckInId As Integer = MaxID_tblCheckIn(conn)
        Dim comCustomerCheckIn As New SQLCommand(tblWorkers_CHECKIN, conn)
        Dim comCheckIn As New SQLCommand(tblCheckIN_CHECKIN, conn)
        If transact IsNot Nothing Then
            comCustomerCheckIn.Transaction = transact
        End If
        With comCheckIn.Parameters
            .Clear()
            .AddWithValue("@CheckInID", CheckInId)
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@CheckInRoomNo", CheckInRoomNo)
            .Add("@CheckInDate", SqlDbType.DateTime).Value = CheckInDate
            .Add("@DC_Date", SqlDbType.DateTime).Value = DC_Date
            .Add("@DC_File", SqlDbType.Image).Value = DBNull.Value
            .AddWithValue("@DC_File_Name", "")
            .AddWithValue("@DC_File_Ext", "")
        End With
        With comCustomerCheckIn.Parameters
            .AddWithValue("@CheckInRoomNo", CheckInRoomNo)
            .Add("@CheckInDate", SqlDbType.DateTime).Value = CheckInDate
            .AddWithValue("@CheckInID", CheckInId)
            .AddWithValue("@WorkerID", WorkerID)
        End With
        Dim obj
        Try
            obj = comCheckIn.ExecuteNonQuery
            comCustomerCheckIn.ExecuteNonQuery()
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comCustomerCheckIn.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comCustomerCheckIn.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Updated")
        End If
        Return WorkerID
    End Function
    Private ReadOnly Property tblCheckIN_CHECKOUT As String
        Get
            Return <tblCheckIN_CHECKOUT><![CDATA[
              UPDATE [tblCheckIn] SET [Status]='OUT' WHERE  [CheckInId] IN ( SELECT MAX([CheckInId]) FROM [tblCheckIn] WHERE [Status]='IN' and [WorkerID]=@WorkerID)
                    ]]></tblCheckIN_CHECKOUT>.Value ' and [CheckInDate] between @D1 and @D2
        End Get
    End Property
    Public Function CheckOut( _
                           ByVal WorkerID As Integer, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim CheckInId As Integer = MaxID_tblCheckIn(conn)

        Dim comCheckOut As New SQLCommand(tblCheckIN_CHECKOUT, conn)
        If transact IsNot Nothing Then
            comCheckOut.Transaction = transact
        End If
        With comCheckOut.Parameters
            .Clear()
            .AddWithValue("@WorkerID", WorkerID)
            '.Add("@D1", SqlDbType.DateTime).Value = Today
            '.Add("@D2", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
        End With

        Dim obj
        Try
            obj = comCheckOut.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comCheckOut.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Updated")
        End If
        Return WorkerID
    End Function
    Public Function Delete_CHECKIN(ByVal WorkerID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblCheckIn_Delete, conn)
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
    

    


    



    
    


    Private ReadOnly Property tblWorkers_tblActiveWorker_SELECT As String
        Get
            Return <tblWorkers_tblActiveWorker_SELECT><![CDATA[
                SELECT 
                    a.[SL],
                    a.[WorkerID],
                    b.[WorkerName],
                    a.[WorkerID],
                    a.[workingdate],
                    a.[room],
                    c.serv1 as [service],
                    a.[starttime],
                    a.[CustomerName],
                    a.[Status],
                    a.[BookingId]
                FROM 
                (
                    [tblActiveWorker] a 
                LEFT OUTER JOIN 
                    [tblWorkers] b on a.workerid= b.workerid
                )
                LEFT OUTER JOIN 
                (select sum(Service) as [serv1],workerid as wi,bookingid as bi  from [tblExtraService] group by workerid,bookingid)  c  on a.workerid= c.wi and a.bookingid = c.bi
                    ]]></tblWorkers_tblActiveWorker_SELECT>.Value
        End Get
    End Property

   
End Class
