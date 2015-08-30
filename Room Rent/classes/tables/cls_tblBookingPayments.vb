Public Class cls_tblBookingPayments
    Private ReadOnly Property tblBookingPayments_INSERT As String
        Get
            Return <tblBookingPayments_INSERT><![CDATA[
                INSERT INTO [tblBookingPayments]
                (
                    [Sl],
                    [Type],
                    [Total], 
                    [BookingID] ,  
                    [CreatedDate] ,
                    [CASH],
                    [CARD],
                    [Surcharge],
                    [Surcharge_Amt],
                    [Tip],
                    [Status],
                    [PaymentMode],
                    [Sp_Amount],
                    [House_amount],
                    [CashOut],
                    [WorkerID],
                    [VoucherAmount],
                    [VoucherID],
                    [ShiftFee],
                    [MemoNo],
                    [Upgrade],
                    [GST],
                    [UserId],
                    [CarFare],
                    [EscortExtensionFees],
                    [CardName],
                    [Cancel_fees],
                    [Bond_amount]
                )
                VALUES
                (
                    @Sl,
                    @Type,
                    @Total, 
                    @BookingID ,  
                    @CreatedDate ,
                    @CASH,
                    @CARD,
                    @Surcharge,
                    @Surcharge_Amt ,
                    @Tip ,
                    @Status ,
                    @PaymentMode,
                    @Sp_Amount,
                    @House_amount,
                    @CashOut,
                    @WorkerID,
                    @VoucherAmount,
                    @VoucherID,
                    @ShiftFee,
                    @MemoNo,
                    @Upgrade,
                    @GST,
                    @UserId,
                    @CarFare,
                    @EscortExtensionFees,
                    @CardName,
                    @Cancel_fees,
                    @Bond_amount
                )
                    ]]></tblBookingPayments_INSERT>.Value
        End Get
    End Property 

    Private ReadOnly Property tblBookingPayments_MAX_ID As String
        Get
            Return <tblBookingPayments_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblBookingPayments]
                    ]]></tblBookingPayments_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookingPayments_SELECT As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Type],
                    [Total], 
                    [BookingID] ,  
                    [CreatedDate] ,
                    [CASH],
                    [CARD],
                    [Surcharge],
                    [Surcharge_Amt],
                    [Tip],
                    [Status],
                    [PaymentMode],
                    [Sp_Amount],
                    [House_amount],
                    [CashOut],
                    [WorkerID],
                    [VoucherAmount],
                    [VoucherID],
                    [ShiftFee],
                    [MemoNo],
                    [Upgrade],
                    [GST],
                    [UserId],
                    [CarFare],
                    [EscortExtensionFees],
                    [CardName],
                    [Cancel_fees],
                    [Bond_amount]
                FROM
                    [tblBookingPayments]
                   ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookingPayments_SELECT_REPORT As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Type],
                    [Total], 
                    [BookingID] ,  
                    [CreatedDate] ,
                    [CASH],
                    [CARD],
                    [Surcharge],
                    [Surcharge_Amt],
                    [Tip],
                    [Status],
                    [PaymentMode],
                    [Sp_Amount],
                    [House_amount],
                    [CashOut],
                    [WorkerID],
                    [VoucherAmount],
                    [VoucherID],
                    [ShiftFee],
                    [MemoNo],
                    [Upgrade],
                    [GST],
                    b.BookType,
                    [UserId],
                    [CarFare],
                    [EscortExtensionFees],
                    [CardName],
                    [Cancel_fees],
                    [Bond_amount]
                FROM
                    [tblBookingPayments] a
                LEFT OUTER JOIN 
                (
                select a.BookingID as bookingID111,
                case 
                when b.Status='CANCEL' then 'NORMAL/C'
                when c.cnt >1 OR a.TotalClient >1  then 'CUSTOM'
                when d.cnt >1  then 'EXTEND'
                else
                'NORMAL'
                end as [BookType]
                    from tblBookings a
                left outer join 
                tblBookingStatus b on a.BookingID = b.BookingID 
                left outer join
                (select bookingid ,COUNT(sl) as cnt from tblActiveWorker group by BookingId ) c
                 on a.BookingID = c.BookingID 
                left outer join
                (select bookingid ,COUNT(sl) as cnt from tblExtraService group by BookingId ) d
                 on a.BookingID = d.BookingID 
                 where a.BookingType ='BOOKING'
                ) b
                on a.BookingID = B.bookingID111
                   ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookingPayments_SELECT_BOOKING_TOTAL_WORKERWISE As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                select WorkerID ,SUM( Total) as [total],SUM(Sp_Amount) as [Sp_amount],SUM(House_amount) as [House_amount] from tblBookingPayments where bookingid = @BookingID group by WorkerID 
                   ]]></tblBookingPayments_SELECT>.Value
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
        Dim comID As New SQLCommand(tblBookingPayments_MAX_ID, conn)
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
                               ByVal Type As String, _
                               ByVal Total As Double, _
                               ByVal BookingID As Integer, _
                               ByVal CreatedDate As Date, _
                               ByVal CASH As Double, _
                               ByVal CARD As Double, _
                               ByVal Surcharge As Double, _
                               ByVal Surcharge_Amt As Double, _
                               ByVal Tip As Double, _
                               ByVal Status As String, _
                               ByVal PaymentMode As String, _
                               ByVal Sp_Amount As Double, _
                               ByVal House_amount As Double, _
                               ByVal CashOut As Double, _
                               ByVal WorkerID As Integer, _
                               ByVal VoucherAmount As Double, _
                               ByVal VoucherID As Integer, _
                               ByVal ShiftFee As Double, _
                               ByVal MemoNo As Integer, _
                               ByVal Upgrade As Double, _
                               ByVal GST As Double, _
                               ByVal UserId As Integer, _
                               ByVal CarFare As Double, _
                               ByVal EscortExtensionFees As Double, _
                               ByVal CardName As String, _
                               ByVal Cancel_fees As Double, _
                               ByVal Bond_amount As Double, _
                               Optional ByRef conn As SqlConnection = Nothing, _
                               Optional ByRef transact As SqlTransaction = Nothing _
                          ) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblBookingPayments_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@Type", Type)
            .AddWithValue("@Total", Total)
            .AddWithValue("@BookingID", BookingID)
            .Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate
            .AddWithValue("@CASH", CASH)
            .AddWithValue("@CARD", CARD)
            .AddWithValue("@Surcharge", Surcharge)
            .AddWithValue("@Surcharge_Amt", Surcharge_Amt)
            .AddWithValue("@Tip", Tip)
            .AddWithValue("@Status", Status)
            .AddWithValue("@PaymentMode", PaymentMode)
            .AddWithValue("@Sp_Amount", Sp_Amount)
            .AddWithValue("@House_amount", House_amount)
            .AddWithValue("@CashOut", CashOut)
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@VoucherAmount", VoucherAmount)
            .AddWithValue("@VoucherID", VoucherID)
            .AddWithValue("@ShiftFee", ShiftFee)
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@Upgrade", Upgrade)
            .AddWithValue("@GST", GST)
            .AddWithValue("@UserId", UserId)
            .AddWithValue("@CarFare", CarFare)
            .AddWithValue("@EscortExtensionFees", EscortExtensionFees)
            .AddWithValue("@CardName", CardName)
            .AddWithValue("@Cancel_fees", Cancel_fees)
            .AddWithValue("@Bond_amount", Bond_amount)
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
        REPORT = 1
        TOTAL_WORKER_WISE_SELECTSTRING_AS_BOOKINGID = 2
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
                comSelect.CommandText = tblBookingPayments_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.REPORT
                comSelect.CommandText = tblBookingPayments_SELECT_REPORT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.TOTAL_WORKER_WISE_SELECTSTRING_AS_BOOKINGID
                comSelect.CommandText = tblBookingPayments_SELECT_BOOKING_TOTAL_WORKERWISE & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
