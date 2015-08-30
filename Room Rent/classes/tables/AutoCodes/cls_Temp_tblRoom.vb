'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblRoom
Inherits Database_Table_code_class_tblRoom

    Enum SelectionType
        All = 0
    End Enum

    Private ReadOnly Property tblRoom_UPDATE_AUTO_STATUS As String
        Get
            Return <tblRoom_UPDATE><![CDATA[
                UPDATE [tblRoom]
                SET 
                    [Usable]='YES'
                WHERE
                    [AutoActiveIn]>0 and [Usable]='NO' and DATEADD(Minute,[AutoActiveIn],[StatusTime])<=GETDATE()
                    ]]></tblRoom_UPDATE>.Value
        End Get
    End Property

    Private ReadOnly Property tblRoom_UPDATE As String
        Get
            Return <tblRoom_UPDATE><![CDATA[
                UPDATE [tblRoom]
                SET 
                    [Room]=@Room,
                    [FullName]=@FullName, 
                    [AdditonalCharge]=@AdditonalCharge  , 
                    [AddlSP_Fee]=@AddlSP_Fee , 
                    [AddlHouse_Fee]=@AddlHouse_Fee 
                WHERE
                    [Sl]=@Sl 
                    ]]></tblRoom_UPDATE>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoom_UPDATE_2 As String
        Get
            Return <tblRoom_UPDATE><![CDATA[
                UPDATE [tblRoom]
                SET 
                    [Status]=@Status, 
                    [Usable]=@Usable, 
                    [Comment]=@Comment, 
                    [StatusTime]=@StatusTime, 
                    [AutoActiveIn]=@AutoActiveIn 
                WHERE
                    [Room]=@Room 
                    ]]></tblRoom_UPDATE>.Value
        End Get
    End Property

    Public Function Update_Status(
                           ByVal Room As String, _
                           ByVal Status As String, _
                           ByVal Usable As String, _
                           ByVal Comment As String, _
                           ByVal StatusTime As String, _
                           ByVal AutoActiveIn As Integer, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblRoom_UPDATE_2, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@Status", Status)
            .AddWithValue("@Usable", Usable)
            .AddWithValue("@Comment", Comment)
            .Add("@StatusTime", SqlDbType.DateTime).Value = StatusTime
            .AddWithValue("@AutoActiveIn", AutoActiveIn)
            .AddWithValue("@Room", Room)
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
        Return obj
    End Function
    Public Function Update_Status_AUTO() As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim conn As SQLConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblRoom_UPDATE_AUTO_STATUS, conn)
        Dim obj = Nothing
        Try
            obj = comInsert.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comInsert.Dispose()
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comInsert.Dispose()
        Return obj
    End Function
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
                comSelection.CommandText = tblRoom_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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

End Class