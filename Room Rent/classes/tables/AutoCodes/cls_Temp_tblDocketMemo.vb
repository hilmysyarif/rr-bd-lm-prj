'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblDocketMemo
    Inherits Database_Table_code_class_tblDocketMemo

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

    Private ReadOnly Property tblDocketMemo_SELECT_REport_CashOut As String
        Get
            Return <tblDocketMemo_SELECT><![CDATA[
                SELECT
                    a.[MemoNo],
                    a.[MemoType],
                    a.[MemoDate] as [Date],b.TotalAmount, b.TOTAIL_PAID 
                FROM
                    [tblDocketMemo] a
                    left outer join tblPayment b on a.MemoNo = b.MemoNo and a.MemoType = b.Transac_Type 
                    where a.MemoType = 'CASH OUT'
                   ]]></tblDocketMemo_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblDocketMemo_SELECT_REport_Amenities As String
        Get
            Return <tblDocketMemo_SELECT><![CDATA[
                SELECT
                    a.[MemoNo],
                    a.[MemoType],
                    a.[MemoDate] as [Date],b.TotalAmount, b.TOTAIL_PAID 
                FROM
                    [tblDocketMemo] a
                    left outer join tblPayment b on a.MemoNo = b.MemoNo and a.MemoType = b.Transac_Type 
                    where a.MemoType = 'SHIFT FEE'
                   ]]></tblDocketMemo_SELECT>.Value
        End Get
    End Property
    Enum SelectionType
        All = 0
        LAST10 = 1
        Cashout = 2
        Amenities = 3
    End Enum

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
                comSelection.CommandText = tblDocketMemo_select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.LAST10
                comSelection.CommandText = tblDocketMemo_SELECT_10 & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "") & " ORDER BY MemoNo Desc"
            Case SelectionType.Cashout
                comSelection.CommandText = tblDocketMemo_SELECT_REport_CashOut & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.Amenities
                comSelection.CommandText = tblDocketMemo_SELECT_REport_Amenities & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
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
    Sub UndoReceipt(ByVal MemoNo As Integer)
        MsgBox("cannot undo. Work in progress", MsgBoxStyle.Information, "Info")
    End Sub

    Private ReadOnly Property tblDocketMemo_UPDATE_PrintText As String
        Get
            Return <tblDocketMemo_Delete><![CDATA[
                UPDATE [tblDocketMemo] SET [PrintText]=@PrintText WHERE [MemoNo]=@MemoNo
                    ]]></tblDocketMemo_Delete>.Value
        End Get
    End Property
    Public Function Update_PrintText(ByVal MemoNo As String, ByVal PrintText As String, Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblDocketMemo_UPDATE_PrintText, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@PrintText", PrintText)
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
            Throw New Exception("No Record Update")
        End If
        Return Val(obj)
    End Function

End Class