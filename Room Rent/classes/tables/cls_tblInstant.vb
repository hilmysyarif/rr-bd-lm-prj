Public Class cls_tblInstant
    Private ReadOnly Property tblInstant_INSERT As String
        Get
            Return <tblBooking_INSERT>
                       <![CDATA[
                        INSERT INTO [tblInstant]
                        (
                            [InstantID],
                            [DoorName],
                            [DoorCharge],
                            [InstantDate],
                            [TotalAmount],
                            [QTY],
                            [MemoNo]
                        )
                        VALUES
                        (
                            @InstantID,
                            @DoorName,
                            @DoorCharge,
                            @InstantDate,
                            @TotalAmount,
                            @QTY,
                            @MemoNo
                        )
                    ]]>
                   </tblBooking_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblInstant_MAX_ID As String
        Get
            Return <tblBooking_MAX_ID><![CDATA[
                SELECT MAX([InstantID]) FROM [tblInstant]
                    ]]></tblBooking_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblInstant_Delete As String
        Get
            Return <tblBooking_Delete><![CDATA[
                DELETE FROM [tblInstant] WHERE [InstantID]=@InstantID
                    ]]></tblBooking_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblInstant_SELECT As String
        Get
            Return <tblInstant_SELECT><![CDATA[
                SELECT
                    a.[InstantID], 
                    a.[DoorName],
                    a.[DoorCharge],
                    a.[InstantDate],
                    a.[TotalAmount], 
                    a.[QTY], 
                    a.[MemoNo]
                FROM
                    [tblInstant] a
                   ]]></tblInstant_SELECT>.Value
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
        Dim comID As New SQLCommand(tblInstant_MAX_ID, conn)
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
                           ByVal DoorName As String, _
                           ByVal DoorCharge As Double, _
                           ByVal InstantDate As Date, _
                           ByVal TotalAmount As Double, _
                           ByVal QTY As Integer, _
                           ByVal MemoNo As Integer, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comInsert As New SQLCommand(tblInstant_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim InstantID As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@InstantID", InstantID)
            .AddWithValue("@DoorName", DoorName)
            .AddWithValue("@DoorCharge", DoorCharge)
            .Add("@InstantDate", SqlDbType.DateTime).Value = InstantDate
            .AddWithValue("@TotalAmount", TotalAmount)
            .AddWithValue("@QTY", QTY)
            .AddWithValue("@MemoNo", MemoNo)
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
        Return InstantID
    End Function

    Public Function Delete(ByVal InstantID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblInstant_INSERT, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@InstantID", InstantID)
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
    Public Function Selection( _
                              Optional ByVal SelectString As String = "", _
                              Optional ByVal Parameters As List(Of SQLParameter) = Nothing, _
                              Optional ByRef conn As SQLConnection = Nothing _
                             ) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand(tblInstant_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, ""), conn)
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
    Enum tblInstant_FIELDS
        [InstantID]
        '[ServiceProvider]
        '[Room]
        '[RoomCharge]
        '[Service]
        [DoorName]
        [DoorCharge]
        [InstantDate]
        [TotalAmount]
        '[PaymentMode]
        [Status]
    End Enum
    Public Function SelectionDisctinct( _
                                       ByVal DistinctField As tblInstant_FIELDS, _
                                       Optional ByVal SelectString As String = "", _
                                       Optional ByVal Parameters As SQLParameterCollection = Nothing, _
                                       Optional ByRef conn As SQLConnection = Nothing _
                                      ) As DataTable

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        Select Case DistinctField
            'Case tblInstant_FIELDS.ServiceProvider
            '    comSelect.CommandText = "SELECT [WorkerName],[WorkerID] FROM [tblWorkers] WHERE WorkerID IN (SELECT DISTINCT([WorkerID]) FROM [tblInstant]" & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "") & ")"
            Case Else
                comSelect.CommandText = "SELECT DISTINCT([" & DistinctField.ToString & "]) FROM [tblInstant]" & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
        End Select
        If Parameters IsNot Nothing Then
            comSelect.Parameters.Add(Parameters)
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
