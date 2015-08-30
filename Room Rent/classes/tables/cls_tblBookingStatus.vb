Public Class cls_tblBookingStatus
    Private ReadOnly Property tblBookingStatus_INSERT As String

        Get
            Return <tblBooking_INSERT>
                       <![CDATA[
                        INSERT INTO [tblBookingStatus]
                        (
                            [Sl],
                            [BookingID],
                            [Status],
                            [Date],
                            [MemoNo] ,
                            [Reason] ,
                            [UserId] 
                        )
                        VALUES
                        (
                            @Sl,
                            @BookingID,
                            @Status,
                            @Date,
                            @MemoNo ,
                            @Reason ,
                            @UserId 
                        )

                    ]]>
                   </tblBooking_INSERT>.Value
        End Get


    End Property

    Private ReadOnly Property tblBookingStatus_MAX_ID As String
        Get
            Return <tblBooking_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblBookingStatus]
                    ]]></tblBooking_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookingStatus_Delete As String
        Get
            Return <tblBooking_Delete><![CDATA[
                DELETE FROM [tblBookingStatus] WHERE [Sl]=@Sl
                    ]]></tblBooking_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblBooking_SELECT As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT
                    [Sl], 
                    [BookingID],
                    [Status],
                    [Date],
                    [MemoNo] ,
                    [Reason],
                    [UserId]
                FROM
                    [tblBookingStatus]  
                   ]]></tblBooking_SELECT>.Value
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

        Dim ID As Integer = 1 ''1 states that, the ID field will start from 1
        Dim comID As New SQLCommand(tblBookingStatus_MAX_ID, conn)
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
                           ByVal BookingID As Integer, _
                           ByVal Status As String, _
                           ByVal _Date As Date, _
                           ByVal MemoNo As Integer, _
                           ByVal Reason As String, _
                           ByVal UserId As Integer, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comInsert As New SqlCommand(tblBookingStatus_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@BookingID", BookingID)
            .AddWithValue("@Status", Status)
            .Add("@Date", SqlDbType.DateTime).Value = _Date
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@Reason", Reason)
            .AddWithValue("@UserId", UserId)
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
        Dim comDelete As New SQLCommand(tblBookingStatus_Delete, conn)
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
        ALL
    End Enum



    Public Function Selection(Optional ByVal Ty As SelectionType = SelectionType.ALL, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        Select Case Ty
            Case SelectionType.ALL
                comSelect.CommandText = tblBooking_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")

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
