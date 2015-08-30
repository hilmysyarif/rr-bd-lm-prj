'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblLocker
Inherits Database_Table_code_class_tblLocker

    Enum SelectionType
        All = 0
        LOCKER_WITH_LASTBOOKING = 1
    End Enum
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
Where 1=1
                   ]]></tblLocker_SELECT>.Value
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
                comSelection.CommandText = tblLocker_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.LOCKER_WITH_LASTBOOKING
                comSelection.CommandText = tblLocker_SELECT_Booking & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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


    Private ReadOnly Property tblLocker_UPDATE2 As String
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

    Public Function Update2( _
                       ByVal LockerNumber As String, _
                       ByVal LockerName As String, _
                       ByVal Price As String, _
                       ByVal Description As String, _
                       Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblLocker_UPDATE2, conn)
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
End Class