Public Class cls_tblEscortDriverInfo

    Private ReadOnly Property tblEscortDriverInfo_INSERT As String
        Get
            Return <tblEscortDriverInfo_INSERT><![CDATA[
                INSERT INTO [tblEscortDriverInfo]
                (
                    [ID], 
                    [BookingID] , 
                    [Location] , 
                    [Others] ,
                    [Remarks] 
                )
                VALUES
                (
                    @ID, 
                    @BookingID , 
                    @Location , 
                    @Others ,
                    @Remarks 
                )
            ]]></tblEscortDriverInfo_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblEscortDriverInfo_MAX_ID As String
        Get
            Return <tblEscortDriverInfo_MAX_ID><![CDATA[
                SELECT MAX([ID]) FROM [tblEscortDriverInfo]
                    ]]></tblEscortDriverInfo_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblEscortDriverInfo_SELECT As String
        Get
            Return <tblEscortDriverInfo_SELECT><![CDATA[
                SELECT
                    [ID], 
                    [BookingID]  , 
                    [Location] , 
                    [Others] ,
                    [Remarks] 
                FROM
                    [tblEscortDriverInfo]
                   ]]></tblEscortDriverInfo_SELECT>.Value
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
        Dim comID As New SQLCommand(tblEscortDriverInfo_MAX_ID, conn)
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
                           ByVal BookingID As Integer, _
                           ByVal Location As String, _
                           ByVal Others As String, _
                           ByVal Remarks As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblEscortDriverInfo_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim ID As Integer = MaxID(conn)

        With comInsert.Parameters
            .AddWithValue("@ID", ID)
            .AddWithValue("@BookingID", BookingID)
            .AddWithValue("@Location", Location)
            .AddWithValue("@Others", Others)
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

        Return ID
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
                comSelect.CommandText = tblEscortDriverInfo_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
    Private ReadOnly Property tblEscortDriverInfo_DELETE_q As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                DELETE FROM
                    [tblBookingPayments] 
                WHERE [BookingID]=@BookingID 
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblEscortDriverInfo_DELETE(ByVal BookingID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblEscortDriverInfo_DELETE_q, conn)
        da.Parameters.Add("@BookingID", SqlDbType.Int).Value = BookingID
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

End Class
