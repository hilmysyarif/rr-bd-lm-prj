Public Class cls_tblBill
    Private ReadOnly Property tblBill_INSERT As String
        Get
            Return <tblBill_INSERT><![CDATA[
                INSERT INTO [tblBill]
                (
                    [BillID],
                    [C_Name],
                    [Amount],
                    [BillDate],
                    [Status] ,
                    [UserId] 
                )
                VALUES
                (
                    @BillID,
                    @C_Name,
                    @Amount,
                    @BillDate,
                    @Status ,
                    @UserId 
                )
                    ]]></tblBill_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBill_MAX_ID As String
        Get
            Return <tblBill_MAX_ID><![CDATA[
                SELECT MAX([BillID]) FROM [tblBill]
                    ]]></tblBill_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblBill_Delete As String
        Get
            Return <tblBill_Delete><![CDATA[
                DELETE FROM [tblBill] WHERE [BillID]=@BillID
                    ]]></tblBill_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblBill_SELECT As String
        Get
            Return <tblBill_SELECT><![CDATA[
                SELECT
                    [BillID],
                    [C_Name],
                    [Amount],
                    [BillDate],
                    [Status] ,
                    [UserId] 
                FROM
                    [tblBill]
                   ]]></tblBill_SELECT>.Value
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
        Dim comID As New SQLCommand(tblBill_MAX_ID, conn)
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
                           ByVal C_Name As String, _
                           ByVal Amount As Double, _
                           ByVal BillDate As Date, _
                           ByVal Status As String, _
                           ByVal UserId As Integer, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblBill_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim BillID As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@BillID", BillID)
            .AddWithValue("@C_Name", C_Name)
            .AddWithValue("@Amount", Amount)
            .Add("@BillDate", SqlDbType.DateTime).Value = BillDate
            .AddWithValue("@Status", Status)
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
        Return BillID
    End Function

    Public Function Delete(ByVal BillID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblBill_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@BillID", BillID)
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
                comSelect.CommandText = tblBill_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
