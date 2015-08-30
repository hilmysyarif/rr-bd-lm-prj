Public Class cls_tblDailyCounter
    Private ReadOnly Property tblDailyCounter_INSERT As String
        Get
            Return <tblDailyCounter_INSERT><![CDATA[
                INSERT INTO [tblDailyCounter]
                (
                    [SL],
                    [Date],
                    [Value],
                    [Status], 
                    [Remarks]  
                )
                VALUES
                (
                    @SL,
                    @Date,
                    @Value,
                    @Status, 
                    @Remarks  
                )
                    ]]></tblDailyCounter_INSERT>.Value
        End Get
    End Property
 

    Private ReadOnly Property tblDailyCounter_MAX_ID As String
        Get
            Return <tblDailyCounter_MAX_ID><![CDATA[
                SELECT MAX([SL]) FROM [tblDailyCounter]
                    ]]></tblDailyCounter_MAX_ID>.Value
        End Get
    End Property
 
    Private ReadOnly Property tblDailyCounter_SELECT As String
        Get
            Return <tblDailyCounter_SELECT><![CDATA[
                SELECT
                    [SL],
                    [Date],
                    [Value],
                    [Status], 
                    [Remarks] 
                FROM
                    [tblDailyCounter]
                   ]]></tblDailyCounter_SELECT>.Value
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
        Dim comID As New SQLCommand(tblDailyCounter_MAX_ID, conn)
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
                           ByVal Date_ As Date, _
                           ByVal Value As String, _
                           ByVal Status As String, _
                           ByVal Remarks As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As String
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblDailyCounter_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim SL As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@SL", SL)
            .Add("@Date", SqlDbType.DateTime).Value = Date_
            .AddWithValue("@Value", Value)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Remarks", Remarks)
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
        Return SL
    End Function
    Enum SelectionType
        ALL = 0
        TODAY_COUNT = 1
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
                comSelect.CommandText = tblDailyCounter_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.TODAY_COUNT
                comSelect.CommandText = tblDailyCounter_SELECT & " WHERE [Date] between @d1 and @d2 ORDER BY [SL]"
                comSelect.Parameters.Add("@d1", SqlDbType.DateTime).Value = Today
                comSelect.Parameters.Add("@d2", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
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
