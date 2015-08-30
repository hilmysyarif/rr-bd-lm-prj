'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblBookings
    Inherits Database_Table_code_class_tblBookings

    Enum SelectionType
        All = 0
        REPORT = 1
        REPORT_With_TotalFigures = 2
        All_View = 3
        ServiceProvider = 10

    End Enum

  

    Function GetDisplayID(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim objBPayment As New cls_Temp_tblBookingPayments
        Dim startTime As Date = objBPayment.GetStartDate
        Try
            If Not MySettings.OtherSettings.StartDate.ToString("dd/MM/yyyy") = "01/01/0001" Then
                startTime = MySettings.OtherSettings.StartDate.ToString
            End If
        Catch ex As Exception
        End Try
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim com As New SqlCommand("Select Max(DisplayBookingId) from tblBookings where BookingDate>=@StartDate", _conn)
        If Not _transac Is Nothing Then
            com.Transaction = _transac
        End If
        com.Parameters.AddWithValue("@StartDate", startTime)
        Dim DisID As Integer = 1
        Try
            DisID = com.ExecuteScalar + 1
        Catch ex As Exception
        End Try

        com.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return DisID

    End Function

    Sub SaveDisplayID(BookingID As Integer, DisplayID As Integer)
        Update_field(FieldName.DisplayBookingId, DisplayID, "BookingID=" & BookingID.ToString)
    End Sub

    Function Selection(Optional ByVal _selection_type As SelectionType = SelectionType.All_View, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

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
                comSelection.CommandText = tblBookings_select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_View
                comSelection.CommandText = tblBooking_SELECT_ALL_VIEW & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.ServiceProvider
                comSelection.CommandText = "SELECT [WorkerName],[WorkerID] FROM [tblWorkers] WHERE WorkerID IN (SELECT DISTINCT([WorkerID]) FROM [tblBookings]" & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "") & ")"
            Case SelectionType.REPORT
                comSelection.CommandText = tblBooking_SELECT_REPORT & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.REPORT_With_TotalFigures
                comSelection.CommandText = tblBooking_SELECT_REPORT_With_TotalFigures & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
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
                Where 1=1
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblBooking_SELECT_ALL_VIEW As String
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
                    a.[ExcludeFromReport],
                    a.[DisplayBookingId]
                FROM
                    [tblBookings] a
                LEFT OUTER JOIN
                    [tblWorkers] b
                ON 
                    a.WorkerID=b.WorkerID
                Where 1=1
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
                Where 1=1
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
                Where 1=1
                   ]]></tblBooking_SELECT>.Value
        End Get
    End Property

End Class