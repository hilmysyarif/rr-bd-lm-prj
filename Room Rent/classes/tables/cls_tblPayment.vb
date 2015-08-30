Public Class cls_tblPayment
    Private ReadOnly Property tblPayment_INSERT As String
        Get
            Return <tblPayment_INSERT><![CDATA[
                INSERT INTO [tblPayment]
                (
                    [ID],
                    [Transac_Type],
                    [TotalAmount], 
                    [Transc_ID] ,  
                    [Transc_Time] ,
                    [CASH],
                    [CARD],
                    [SURCHARGE_P],
                    [SURCHARGE_AMT], 
                    [Status],
                    [PaymentMode],
                    [TOTAIL_PAID],
                    [Remarks],
                    [VoucherAmount],
                    [VoucherID],
                    [MemoNo],
                    [CashOut],
                    [Tip],
                    [GST],
                    [UserId]
                )
                VALUES
                (
                    @ID,
                    @Transac_Type,
                    @TotalAmount, 
                    @Transc_ID ,  
                    @Transc_Time ,
                    @CASH,
                    @CARD,
                    @SURCHARGE_P,
                    @SURCHARGE_AMT , 
                    @Status ,
                    @PaymentMode,
                    @TOTAIL_PAID,
                    @Remarks,
                    @VoucherAmount,
                    @VoucherID,
                    @MemoNo,
                    @CashOut,
                    @Tip,
                    @GST,
                    @UserId
                )
                    ]]></tblPayment_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblPayment_MAX_ID As String
        Get
            Return <tblPayment_MAX_ID><![CDATA[
                SELECT MAX([ID]) FROM [tblPayment]
                    ]]></tblPayment_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblPayment_SELECT As String
        Get
            Return <tblPayment_SELECT><![CDATA[
                SELECT
                    [ID],
                    [Transac_Type],
                    [TotalAmount], 
                    [Transc_ID] ,  
                    [Transc_Time] ,
                    [CASH],
                    [CARD],
                    [SURCHARGE_P],
                    [SURCHARGE_AMT], 
                    [Status],
                    [PaymentMode],
                    [TOTAIL_PAID],
                    [Remarks] ,
                    [VoucherAmount],
                    [VoucherID],
                    [MemoNo],
                    [CashOut],
                    [Tip],
                    [GST],
                    [UserId]
                FROM
                    [tblPayment]
                   ]]></tblPayment_SELECT>.Value
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
        Dim comID As New SQLCommand(tblPayment_MAX_ID, conn)
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
                               ByVal Transac_Type As String, _
                               ByVal TotalAmount As Double, _
                               ByVal Transc_ID As Integer, _
                               ByVal Transc_Time As Date, _
                               ByVal CASH As Double, _
                               ByVal CARD As Double, _
                               ByVal SURCHARGE_P As Double, _
                               ByVal SURCHARGE_AMT As Double, _
                               ByVal Status As String, _
                               ByVal PaymentMode As String, _
                               ByVal TOTAIL_PAID As Double, _
                               ByVal Remarks As String, _
                               ByVal VoucherAmount As Double, _
                               ByVal VoucherID As Integer, _
                               ByVal MemoNo As Integer, _
                               ByVal CashOut As Double, _
                               ByVal Tip As Double, _
                               ByVal GST As Double, _
                               ByVal UserId As Integer, _
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
        Dim comInsert As New SqlCommand(tblPayment_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim ID As Integer = MaxID(conn)
        With comInsert.Parameters

            .AddWithValue("@ID", ID)
            .AddWithValue("@Transac_Type", Transac_Type)
            .AddWithValue("@TotalAmount", TotalAmount)
            .AddWithValue("@Transc_ID", Transc_ID)
            .Add("@Transc_Time", SqlDbType.DateTime).Value = Transc_Time
            .AddWithValue("@CASH", CASH)
            .AddWithValue("@CARD", CARD)
            .AddWithValue("@SURCHARGE_P", SURCHARGE_P)
            .AddWithValue("@SURCHARGE_AMT", SURCHARGE_AMT)
            .AddWithValue("@Status", Status)
            .AddWithValue("@PaymentMode", PaymentMode)
            .AddWithValue("@TOTAIL_PAID", TOTAIL_PAID)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@VoucherAmount", VoucherAmount)
            .AddWithValue("@VoucherID", VoucherID)
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@CashOut", CashOut)
            .AddWithValue("@Tip", Tip)
            .AddWithValue("@GST", GST)
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
        Return ID
    End Function
    Enum SelectionTransac_Type
        ALL = 0
    End Enum
    Public Function Selection(Optional ByVal typ As SelectionTransac_Type = 0, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        Select Case typ
            Case SelectionTransac_Type.ALL
                comSelect.CommandText = tblPayment_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
