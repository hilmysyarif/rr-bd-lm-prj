Public Class cls_tblBillItems
    Private ReadOnly Property tblBillItems_INSERT As String
        Get
            Return <tblBillItems_INSERT><![CDATA[
                INSERT INTO [tblBillItems]
                (
                    [ItemID],
                    [BillID],
                    [ProductId],
                    [Qty],
                    [Price] ,
                    [Subtotal] 
                )
                VALUES
                (
                    @ItemID,
                    @BillID,
                    @ProductId,
                    @Qty,
                    @Price ,
                    @Subtotal 
                )
                    ]]></tblBillItems_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBillItems_MAX_ID As String
        Get
            Return <tblBillItems_MAX_ID><![CDATA[
                SELECT MAX([ItemID]) FROM [tblBillItems]
                    ]]></tblBillItems_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblBillItems_Delete As String
        Get
            Return <tblBillItems_Delete><![CDATA[
                DELETE FROM [tblBillItems] WHERE [ItemID]=@ItemID
                    ]]></tblBillItems_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblBillItems_SELECT As String
        Get
            Return <tblBillItems_SELECT><![CDATA[
                SELECT
                    [ItemID],
                    [BillID],
                    [ProductId],
                    [Qty],
                    [Price] ,
                    [Subtotal] 
                FROM
                    [tblBillItems]
                   ]]></tblBillItems_SELECT>.Value
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
        Dim comID As New SQLCommand(tblBillItems_MAX_ID, conn)
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
                           ByVal BillID As Integer, _
                           ByVal ProductId As Integer, _
                           ByVal Qty As Integer, _
                           ByVal Price As Double, _
                           ByVal Subtotal As Double, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblBillItems_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim ItemID As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@ItemID", ItemID)
            .AddWithValue("@BillID", BillID)
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@Price", Price)
            .AddWithValue("@Subtotal", Subtotal)
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
        Return ItemID
    End Function

    Public Function Delete(ByVal ItemID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblBillItems_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@ItemID", ItemID)
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
                comSelect.CommandText = tblBillItems_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
