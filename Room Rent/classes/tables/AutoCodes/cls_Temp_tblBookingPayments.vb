'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblBookingPayments
Inherits Database_Table_code_class_tblBookingPayments

    Enum SelectionType
        All = 0
        REPORT = 1
        TOTAL_WORKER_WISE_SELECTSTRING_AS_BOOKINGID = 2
        REPORT_SP_Amounts = 3
    End Enum

    Function GetStartDate() As Date
        Dim ret As Date = Now
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand("Select Min(CreatedDate) from tblBookingPayments", conn)
        Try
            ret = da.ExecuteScalar
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function



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
                            case when [CASH] < 0 then 'NORMAL/X' else b.BookType end as BookType,
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
                        Where 1=1

                   ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property




    Private ReadOnly Property tblBookingPayments_SELECT_REPORT_SP_AMOUNT As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Type],
                    [BookingID] ,  
                    [CreatedDate] , 
                    [Status],
                    [PaymentMode],
                    [Sp_Amount], 
                    [WorkerID] 
                FROM
                    [tblBookingPayments] a
                LEFT OUTER JOIN 
                (select BookingId as BookingId111 , SUM(sp_amount) as sp_tot from [tblBookingPayments] group by BookingId
                ) b
                on a.BookingID = B.bookingID111
                Where b.sp_tot >0
                   ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblBookingPayments_SELECT_BOOKING_TOTAL_WORKERWISE As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                select WorkerID ,SUM(Total) as [total],SUM(Sp_Amount) as [Sp_amount],SUM(House_amount) as [House_amount] from tblBookingPayments where bookingid = @BookingID    group by WorkerID
                   ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Function Selection(Optional ByVal _selection_type As SelectionType = SelectionType.All, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable
        Dim dt As New DataTable
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comSelection As New SqlCommand("", _conn)
        If Not _transac Is Nothing Then
            comSelection.Transaction = _transac
        End If

        Select Case _selection_type
            Case SelectionType.All
                comSelection.CommandText = tblBookingPayments_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.REPORT
                comSelection.CommandText = tblBookingPayments_SELECT_REPORT & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.TOTAL_WORKER_WISE_SELECTSTRING_AS_BOOKINGID
                comSelection.CommandText = tblBookingPayments_SELECT_BOOKING_TOTAL_WORKERWISE & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.REPORT_SP_Amounts
                comSelection.CommandText = tblBookingPayments_SELECT_REPORT_SP_AMOUNT & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelection.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comSelection.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



    Private ReadOnly Property tblBookingPayments_DELETE_q As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                DELETE FROM
                    [tblBookingPayments] 
                WHERE [BookingID]=@BookingID 
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblBookingPayments_DELETE(ByVal BookingID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblBookingPayments_DELETE_q, conn)
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



    Private ReadOnly Property tblBookingPayments_DELETE_q_2 As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                DELETE FROM
                    [tblBookingPayments] 
                WHERE 1=1
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblBookingPayments_DELETE_2(ByVal SelectString As String, Optional ByVal Parameters As List(Of SqlParameter) = Nothing) As Integer
        Dim ret As Integer = 0
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblBookingPayments_DELETE_q_2 & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("AND"), " ", " AND ") & SelectString, ""), conn)
        If Parameters IsNot Nothing Then
            da.Parameters.AddRange(Parameters.ToArray)
        End If
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

    Private ReadOnly Property tblBookingPayments_Update_CHANGE_WORKER_select As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                UPDATE
                    [tblBookingPayments] 
                SET
                    [WorkerId]=@WorkerID1
                 WHERE [BookingID]=@BookingID and [WorkerId]=@WorkerID
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblBookingPayments_Update_CHANGE_WORKER(ByVal BookingID As Integer, ByVal WorkerID As Integer, ByVal NewWorkerID As Integer) As Integer

        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblBookingPayments_Update_CHANGE_WORKER_select, conn)
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



    Private ReadOnly Property tblBookingPayments_Cancel As String
        Get
            Return <tblBookingPayments_Cancel><![CDATA[
                UPDATE 
                    [tblBookingPayments]
                SET
                    [CASH]=0,
                    [CARD]=0,
                    [VoucherAmount]=0
                FROM
                    [tblBookingPayments]
                WHERE
                    [BookingID]=@BookingID
                   ]]></tblBookingPayments_Cancel>.Value
        End Get
    End Property



    Public Function tblBookingPayments_CancelBooking(ByVal BookingID As Integer) As Integer

        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlCommand(tblBookingPayments_Cancel, conn)

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









    <Serializable()>
    Structure CrytoInfo
        Dim CASH As Double
        Dim CARD As Double
        Dim SurchargeAmt As Double
        Dim VoucherAmount As Double
        Dim TIP As Double
        Dim CashOut As Double
        Dim SP_AMT As Double
        Dim HOUSE_AMT As Double
        Dim GST As Double
        Dim CarFare As Double
        Dim EscortExtensionFees As Double
        Dim Cancel_fees As Double
        Dim Bond_amount As Double
    End Structure


    Private Function CrytoInfo_to_string(ByVal myLayout As CrytoInfo) As String
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim MS As New System.IO.MemoryStream()
        BF.Serialize(MS, myLayout)
        Return Convert.ToBase64String(MS.GetBuffer())
    End Function

    Private Function CrytoInfo_From_string(ByVal basestring As String) As CrytoInfo
        Dim myLayout As CrytoInfo
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim bytes As Byte() = Convert.FromBase64String(basestring)
        myLayout = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), CrytoInfo)
        Return myLayout
    End Function

    Sub Encrypt()

        'Load All fields


        'Create Cryptoinfo


        'Create Encryted Crypto info String


        'Update tables


        'Close connection

    End Sub
    Sub Decrypt()

        'Load All fields


        'Create Cryptoinfo from Encrypted String


        'Create Cryptoinfo


        'Update tables


        'Close connection


    End Sub


End Class