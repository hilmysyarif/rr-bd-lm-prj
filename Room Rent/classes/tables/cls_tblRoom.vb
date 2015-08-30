Public Class cls_tblRoom
    Private ReadOnly Property tblRoom_INSERT As String
        Get
            Return <tblRoom_INSERT><![CDATA[
                INSERT INTO [tblRoom]
                (
                    [Sl],
                    [Room],
                    [FullName], 
                    [AdditonalCharge] , 
                    [AddlSP_Fee] , 
                    [AddlHouse_Fee] 
                )
                VALUES
                (
                    @Sl,
                    @Room,
                    @FullName, 
                    @AdditonalCharge , 
                    @AddlSP_Fee , 
                    @AddlHouse_Fee 
                )
                    ]]></tblRoom_INSERT>.Value
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

    Private ReadOnly Property tblRoom_MAX_ID As String
        Get
            Return <tblRoom_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblRoom]
                    ]]></tblRoom_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoom_Delete As String
        Get
            Return <tblRoom_Delete><![CDATA[
                DELETE FROM [tblRoom] WHERE [Sl]=@Sl
                    ]]></tblRoom_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoom_SELECT As String
        Get
            Return <tblRoom_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Room],
                    [FullName], 
                    [AdditonalCharge] ,
                    [Status] , 
                    [Usable] , 
                    [Comment] , 
                    [AddlSP_Fee] , 
                    [AddlHouse_Fee] 
                FROM
                    [tblRoom]
                   ]]></tblRoom_SELECT>.Value
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

        Dim ID As Integer = 1 '1 states that, the ID field will start from 1
        Dim comID As New SQLCommand(tblRoom_MAX_ID, conn)

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
                           ByVal Room As String, _
                           ByVal FullName As String, _
                           ByVal AdditonalCharge As Double, _
                           ByVal AddlSP_Fee As Double, _
                           ByVal AddlHouse_Fee As Double, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblRoom_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@Room", Room)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@AdditonalCharge", AdditonalCharge)
            .AddWithValue("@AddlSP_Fee", AddlSP_Fee)
            .AddWithValue("@AddlHouse_Fee", AddlHouse_Fee)
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
        Return Sl
    End Function

    Public Function Update( _
                           ByVal Sl As Integer, _
                           ByVal Room As String, _
                           ByVal FullName As String, _
                           ByVal AdditonalCharge As Double, _
                           ByVal AddlSP_Fee As Double, _
                           ByVal AddlHouse_Fee As Double, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand(tblRoom_UPDATE, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@Room", Room)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@AdditonalCharge", AdditonalCharge)
            .AddWithValue("@AddlSP_Fee", AddlSP_Fee)
            .AddWithValue("@AddlHouse_Fee", AddlHouse_Fee)
            .AddWithValue("@Sl", Sl)
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
        Return Sl
    End Function

    Public Function Update_Status(
                           ByVal Room As String, _
                           ByVal Status As String, _
                           ByVal Usable As String, _
                           ByVal Comment As String, _
                           ByVal StatusTime As String, _
                           ByVal AutoActiveIn As Integer, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
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
    Public Function Delete(ByVal Sl As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblRoom_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@Sl", Sl)
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
                comSelect.CommandText = tblRoom_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")

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
