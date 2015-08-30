Public Class cls_tblDocketMemo

    Private ReadOnly Property tblDocketMemo_INSERT As String
        Get
            Return <tblDocketMemo_INSERT><![CDATA[
                INSERT INTO [tblDocketMemo]
                (
                    [MemoNo],
                    [MemoType],
                    [MemoDate],
                    [Remarks] 
                )
                VALUES
                (
                    @MemoNo,
                    @MemoType,
                    @MemoDate,
                    @Remarks  
                )
                    ]]></tblDocketMemo_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblDocketMemo_MAX_ID As String
        Get
            Return <tblDocketMemo_MAX_ID><![CDATA[
                SELECT MAX([MemoNo]) FROM [tblDocketMemo]
                    ]]></tblDocketMemo_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblDocketMemo_Delete As String
        Get
            Return <tblDocketMemo_Delete><![CDATA[
                DELETE FROM [tblDocketMemo] WHERE [MemoNo]=@MemoNo
                    ]]></tblDocketMemo_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblDocketMemo_SELECT As String
        Get
            Return <tblDocketMemo_SELECT><![CDATA[
                SELECT
                    [MemoNo],
                    [MemoType],
                    [MemoDate],
                    [Remarks] ,
                    [PrintText] 
                FROM
                    [tblDocketMemo]
                   ]]></tblDocketMemo_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblDocketMemo_SELECT_10 As String
        Get
            Return <tblDocketMemo_SELECT><![CDATA[
                SELECT
                    TOP 10
                    [MemoNo],
                    [MemoType],
                    [MemoDate],
                    [Remarks] ,
                    [PrintText] 
                FROM
                    [tblDocketMemo]
                   ]]></tblDocketMemo_SELECT>.Value
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
        Dim comID As New SQLCommand(tblDocketMemo_MAX_ID, conn)
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
                           ByVal MemoType As String, _
                           ByVal MemoDate As Date, _
                           ByVal Remarks As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comInsert As New SQLCommand(tblDocketMemo_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim MemoNo As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@MemoNo", MemoNo)
            .AddWithValue("@MemoType", MemoType)
            .Add("@MemoDate", SqlDbType.DateTime).Value = MemoDate
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
        frmHome.UndoToolStripMenuItem.Tag = MemoNo
        frmHome.UndoToolStripMenuItem.Text = "Undo Memo #:" & MemoNo.ToString
        frmHome.UndoToolStripMenuItem.Enabled = True
        Return MemoNo

    End Function

    Public Function Delete(ByVal MemoNo As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblDocketMemo_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@MemoNo", MemoNo)
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
        LAST10 = 1
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
                comSelect.CommandText = tblDocketMemo_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.LAST10
                comSelect.CommandText = tblDocketMemo_SELECT_10 & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "") & "ORDER BY MemoNo Desc"
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
