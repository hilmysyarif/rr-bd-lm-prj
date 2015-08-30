Public Class cls_tblServiceProvider
    Private ReadOnly Property tblServiceProvider_INSERT As String
        Get
            Return <tblBooking_INSERT><![CDATA[
                INSERT INTO [tblServiceProvider]
                (
                    [ServiceProviderId],
                    [ServiceProviderName],
                    [CreatedDate]
                )
                VALUES
                (
                    @ServiceProviderId,
                    @ServiceProviderName,
                    @CreatedDate
                )
                    ]]></tblBooking_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblServiceProvider_MAX_ID As String
        Get
            Return <tblBooking_MAX_ID><![CDATA[
                SELECT MAX([ServiceProviderId]) FROM [tblServiceProvider]
                    ]]></tblBooking_MAX_ID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBooking_Delete As String
        Get
            Return <tblBooking_Delete><![CDATA[
                DELETE FROM [tblServiceProvider] WHERE [ServiceProviderId]=@ServiceProviderId
                    ]]></tblBooking_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblServiceProvider_SELECT As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT
                    [ServiceProviderId] as [ID],
                    [ServiceProviderName] as [Name],
                    [CreatedDate] 
                FROM
                    [tblServiceProvider]
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property


    Public Function MaxID(Optional ByRef conn As OleDbConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim ID As Integer = 1 ' 1 states that, the ID field will start from 1
        Dim comID As New OleDbCommand(tblServiceProvider_MAX_ID, conn)
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

    Public Function Insert(ByVal ServiceProviderName As String, Optional ByRef conn As OleDbConnection = Nothing, Optional ByRef transact As OleDbTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New OleDbCommand(tblServiceProvider_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim ServiceProviderId As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@ServiceProviderId", ServiceProviderId)
            .AddWithValue("@ServiceProviderName", ServiceProviderName)
            .Add("@CreatedDate", OleDbType.Date).Value = Now
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
        Return ServiceProviderId
    End Function

    Public Function Delete(ByVal ServiceProviderID As String, Optional ByRef conn As OleDbConnection = Nothing, Optional ByRef transact As OleDbTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New OleDbCommand(tblServiceProvider_INSERT, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@ServiceProviderId", ServiceProviderID)
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

    Public Function Selection(Optional ByVal SelectString As String = "", Optional ByVal Parameters As OleDbParameterCollection = Nothing, Optional ByRef conn As OleDbConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New OleDbCommand(tblServiceProvider_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, ""), conn)
        If Parameters IsNot Nothing Then
            comSelect.Parameters.Add(Parameters)
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
