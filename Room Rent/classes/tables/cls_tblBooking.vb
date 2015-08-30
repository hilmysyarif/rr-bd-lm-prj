Public Class cls_tblBookings


    Enum tblBookings_FIELDS
        [BookingID]
        [ServiceProvider]
        [Room]
        [Service]
        [BookingDate]
        [Scheduledate]
        [BookingType]
        [Status]
        [WorkerID]
        [CustomerName]
        [Phone]
        [MobileNo]
        [Worker_status]
        [Client_status]
        [MemberId]
        [MemoNo]
        [TotalClient]
        [ExcludeFromReport]
    End Enum
    Private ReadOnly Property tblBookings_INSERT As String

        Get
            Return <tblBooking_INSERT>
                       <![CDATA[
                        INSERT INTO [tblBookings]
                        (
                            [BookingID],
                            [Room], 
                            [Service],
                            [BookingDate],
                            [Scheduledate],
                            [BookingType], 
                            [WorkerID],
                            [CustomerName],
                            [Phone],
                            [TotalClient],
                            [MemberId],
                            [MemoNo],
                            [ExcludeFromReport]
                        )
                        VALUES
                        (
                            @BookingID,
                            @Room, 
                            @Service,
                            @BookingDate,
                            @Scheduledate,
                            @BookingType, 
                            @WorkerID,
                            @CustomerName,
                            @Phone,
                            @TotalClient,
                            @MemberId,
                            @MemoNo,
                            @ExcludeFromReport
                        )
                    ]]>
                   </tblBooking_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookings_MAX_ID As String
        Get
            Return <tblBooking_MAX_ID><![CDATA[
                SELECT MAX([BookingID]) FROM [tblBookings]
                    ]]></tblBooking_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookings_Delete As String
        Get
            Return <tblBooking_Delete><![CDATA[
                DELETE FROM [tblBookings] WHERE [BookingID]=@BookingID
                    ]]></tblBooking_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblBooking_SELECT As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT
                    a.[BookingID],
                    b.[WorkerName] as [ServiceProvider],
                    a.[Room], 
                    a.[Service],
                    a.[BookingDate],
                    a.[Scheduledate],
                    a.[BookingType], 
                    a.[Status],
                    a.[WorkerID],
                    a.[CustomerName],
                    a.[Phone],
                    b.[MobileNo],
                    a.[Worker_status],
                    a.[Client_status],
                    a.[MemberId],
                    a.[MemoNo],
                    a.[TotalClient],
                    a.[ExcludeFromReport]
                FROM
                    [tblBookings] a
                LEFT OUTER JOIN
                    [tblWorkers] b
                ON 
                    a.WorkerID=b.WorkerID
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBooking_SELECT_REPORT As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT
                    a.[BookingID],
                    b.[WorkerName] as [ServiceProvider],
                    a.[Room], 
                    CASE WHEN a.[Service]>89 THEN convert(varchar,(a.[Service]/60)) + ' Hrs' ELSE convert(varchar,a.[Service]) + ' Mins' END as [Service],
                    a.[BookingDate],
                    a.[Scheduledate],
                    a.[BookingType], 
                    a.[Status],
                    a.[WorkerID],
                    a.[CustomerName],
                    a.[Phone],
                    b.[MobileNo],
                    a.[Worker_status],
                    a.[Client_status],
                    a.[MemberId],
                    a.[MemoNo],
                    a.[TotalClient],
                    a.[ExcludeFromReport]
                FROM
                    [tblBookings] a
                LEFT OUTER JOIN
                    [tblWorkers] b
                ON 
                    a.WorkerID=b.WorkerID
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblBooking_SELECT_REPORT_With_TotalFigures As String
        Get
            Return <tblBooking_SELECT><![CDATA[
  SELECT
                    a.[BookingID],
                    b.[WorkerName] as [ServiceProvider],
                    a.[Room], 
                    CASE WHEN a.[Service]>89 THEN convert(varchar,(a.[Service]/60)) + ' Hrs' ELSE convert(varchar,a.[Service]) + ' Mins' END as [Service],
                    a.[BookingDate],
                    a.[Scheduledate],
                    a.[BookingType], 
                    a.[Status],
                    a.[WorkerID],
                    a.[CustomerName],
                    a.[Phone],
                    b.[MobileNo],
                    a.[Worker_status],
                    a.[Client_status],
                    a.[MemberId],
                    a.[MemoNo],
                    a.[TotalClient],
                    a.[ExcludeFromReport],c.Cash, c.Card, c.Surcharge_Amt, c.VoucherAmount
                FROM
                    [tblBookings] a
                LEFT OUTER JOIN
                    [tblWorkers] b
                ON 
                    a.WorkerID=b.WorkerID
                LEFT OUTER JOIN
                    (select BookingId, SUM(cash) as Cash, SUM(Card) as card, SUM(Surcharge_Amt)Surcharge_Amt, SUM(VoucherAmount  )VoucherAmount from tblBookingPayments group by BookingId ) c
                    on a.BookingID = c.BookingId 
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblBooking_SELECT_REPORT_CANCEL As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT
                    a.[BookingID],
                    b.[WorkerName] as [ServiceProvider],
                    a.[Room], 
                    CASE WHEN a.[Service]>89 THEN convert(varchar,(a.[Service]/60)) + ' Hrs' ELSE convert(varchar,a.[Service]) + ' Mins' END as [Service],
                    a.[BookingDate],
                    a.[Scheduledate],
                    a.[BookingType], 
                    a.[Status],
                    a.[WorkerID],
                    a.[CustomerName],
                    a.[Phone],
                    b.[MobileNo],
                    a.[Worker_status],
                    a.[Client_status],
                    a.[MemberId],
                    a.[MemoNo],
                    a.[TotalClient], 
                    isnull((select top 1 reason from tblBookingStatus tmp where tmp.BookingId = a.BookingId),'') as [Reason],
                    a.[ExcludeFromReport]
                FROM
                    [tblBookings] a
                LEFT OUTER JOIN
                    [tblWorkers] b
                ON 
                    a.WorkerID=b.WorkerID
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBooking_SELECT_DICTINCT_CLIENT As String
        Get
            Return <tblBooking_SELECT_DICTINCT_CLIENT><![CDATA[
                SELECT
                    DISTINCT [CustomerName], [Phone] 
                FROM
                    [tblBookings] WHERE [CustomerName]<>''
                   ]]></tblBooking_SELECT_DICTINCT_CLIENT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBooking_SELECT_CUSTLIST As String
        Get
            Return <tblBooking_SELECT><![CDATA[
                SELECT DISTINCT [CustomerName],
                    a.[Phone] 
                FROM
                    [tblBookings]
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property

    Public Function MaxID(Optional ByRef conn As SqlConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim ID As Integer = 1 ''1 states that, the ID field will start from 1
        Dim comID As New SqlCommand(tblBookings_MAX_ID, conn)
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
                           ByVal Room As String, _
                           ByVal Service As Double, _
                           ByVal BookingDate As Date, _
                           ByVal Scheduledate As Date, _
                           ByVal BookingType As String, _
                           ByVal WorkerID As Integer, _
                           ByVal CustomerName As String, _
                           ByVal Phone As String, _
                           ByVal TotalClient As Integer, _
                           ByVal MemberId As String, _
                           ByVal MemoNo As Integer, _
                           ByVal ExcludeFromReport As Integer, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer


        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comInsert As New SqlCommand(tblBookings_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim BookingID As Integer = MaxID(conn)

        With comInsert.Parameters
            .AddWithValue("@BookingID", BookingID)
            .AddWithValue("@Room", Room)
            .AddWithValue("@Service", Service)
            .Add("@BookingDate", SqlDbType.DateTime).Value = BookingDate
            .Add("@Scheduledate", SqlDbType.DateTime).Value = Scheduledate
            .AddWithValue("@BookingType", BookingType)
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@CustomerName", CustomerName)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@TotalClient", TotalClient)
            .AddWithValue("@MemberId", MemberId)
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@ExcludeFromReport", ExcludeFromReport)
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

    Public Function Delete(ByVal BookingID As String, Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SqlCommand(tblBookings_Delete, conn)
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

    Public Sub UpdateField(ByVal fld As tblBookings_FIELDS, ByVal value As Object, ByVal BookingID As String, Optional ByRef conn As SqlConnection = Nothing)


        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comSelect As New SqlCommand("UPDATE [tblBookings] SET [" & fld.ToString & "]=@Value WHERE [BookingID]=" + BookingID.ToString + "", conn)
        Dim obj As Object = Nothing
        Try

            If TypeOf value Is Date Then
                comSelect.Parameters.Add("@Value", SqlDbType.DateTime).Value = value
            Else
                comSelect.Parameters.AddWithValue("@Value", value)
            End If

            obj = comSelect.ExecuteNonQuery()

            If Val(obj) <= 0 Then
                Throw New Exception("Nothing updated")
            End If

        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            Throw ex

        End Try

        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
    End Sub

    Enum SelectionType
        ALL
        DISTINCT_CLIENT
        REPORT
        REPORT_CANCEL
        REPORT_With_TotalFigures
    End Enum



    Public Function Selection(Optional ByVal Ty As SelectionType = SelectionType.ALL, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SqlCommand("", conn)
        Select Case Ty
            Case SelectionType.ALL
                comSelect.CommandText = tblBooking_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_CLIENT
                comSelect.CommandText = tblBooking_SELECT_DICTINCT_CLIENT
            Case SelectionType.REPORT
                comSelect.CommandText = tblBooking_SELECT_REPORT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.REPORT_CANCEL
                comSelect.CommandText = tblBooking_SELECT_REPORT_CANCEL & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.REPORT_With_TotalFigures
                comSelect.CommandText = tblBooking_SELECT_REPORT_With_TotalFigures & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
        End Select
        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
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

    Public Function SelectionDisctinct(ByVal DistinctField As tblBookings_FIELDS, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SqlCommand("", conn)
        Select Case DistinctField
            Case tblBookings_FIELDS.ServiceProvider
                comSelect.CommandText = "SELECT [WorkerName],[WorkerID] FROM [tblWorkers] WHERE WorkerID IN (SELECT DISTINCT([WorkerID]) FROM [tblBookings]" & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "") & ")"
            Case Else
                comSelect.CommandText = "SELECT DISTINCT([" & DistinctField.ToString & "]) FROM [tblBookings]" & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
        End Select
        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If
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

    'Private ReadOnly Property tblBookings_Update3 As String
    '    Get
    '        Return <tblWorkers_tblActiveWorker_SELECT><![CDATA[
    '            UPDATE
    '                [tblBookings] 
    '            SET
    '                [Service]=[Service] + @Service 
    '             WHERE [BookingID]=@BookingID

    '                ]]></tblWorkers_tblActiveWorker_SELECT>.Value
    '    End Get
    'End Property

    'Public Function EXTENDSERVICE(ByVal [BookingID] As Integer, ByVal Service As Integer) As Integer
    '    Dim ret As Integer = 0
    '    Dim SELECTSTRING As String = ""

    '    Dim objConn As clsConnection = New clsConnection
    '    Dim conn As SQLConnection = objConn.connect
    '    Dim da As New SQLCommand(tblBookings_Update3, conn)
    '    da.Parameters.AddWithValue("@Service", Service)
    '    da.Parameters.Add("@BookingID", SqlDbType.Int).Value = [BookingID]
    '    ret = da.ExecuteNonQuery
    '    Try
    '        da.Dispose()
    '        conn.Close()
    '        conn.Dispose()
    '    Catch ex As Exception
    '    End Try
    '    Return ret
    'End Function
End Class
