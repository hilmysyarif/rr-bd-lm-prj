Public Class cls_tblShiftFee

    Private ReadOnly Property tblShiftFee_INSERT As String
        Get
            Return <tblShiftFee_INSERT><![CDATA[
                INSERT INTO [tblShiftFee]
                (
                    [Serial], 
                    [Room] , 
                    [FeeDate] , 
                    [WorkerID] ,
                    [Amount] ,
                    [Comment] ,
                    [Status] ,
                    [Type] 
                )
                VALUES
                (
                    @Serial, 
                    @Room , 
                    @FeeDate , 
                    @WorkerID ,
                    @Amount ,
                    @Comment ,
                    @Status ,
                    @Type 
                )
            ]]></tblShiftFee_INSERT>.Value
        End Get
    End Property
 
    Private ReadOnly Property tblShiftFee_MAX_ID As String
        Get
            Return <tblShiftFee_MAX_ID><![CDATA[
                SELECT MAX([Serial]) FROM [tblShiftFee]
                    ]]></tblShiftFee_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblShiftFee_SELECT As String
        Get
            Return <tblShiftFee_SELECT><![CDATA[
                SELECT
                    [Serial], 
                    [Room]  , 
                    [FeeDate] , 
                    [WorkerID] ,
                    [Amount] ,
                    [Comment] ,
                    [Status] ,
                    [Type] 
                FROM
                    [tblShiftFee]
                   ]]></tblShiftFee_SELECT>.Value
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
        Dim Serial As Integer = 1 '1 states that, the Serial field will start from 1
        Dim comID As New SQLCommand(tblShiftFee_MAX_ID, conn)
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
            Serial = Val(obj) + 1
        End If
        Return Serial
    End Function

    Public Function Insert( _
                           ByVal Room As String, _
                           ByVal FeeDate As Date, _
                           ByVal WorkerID As Integer, _
                           ByVal Amount As Double, _
                           ByVal Comment As String, _
                           ByVal Status As String, _
                           ByVal Type As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblShiftFee_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Serial As Integer = MaxID(conn)

        With comInsert.Parameters
            .AddWithValue("@Serial", Serial)
            .AddWithValue("@Room", Room)
            .Add("@FeeDate", SqlDbType.DateTime).Value = FeeDate
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@Amount", Amount)
            .AddWithValue("@Comment", Comment)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Type", Type)
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

        Return Serial
    End Function

    Enum SelectionType
        ALL = 0
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
                comSelect.CommandText = tblShiftFee_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
