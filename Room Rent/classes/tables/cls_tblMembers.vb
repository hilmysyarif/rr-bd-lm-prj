Public Class cls_tblMembers

    Private ReadOnly Property tblMembers_INSERT As String
        Get
            Return <tblMembers_INSERT><![CDATA[
                INSERT INTO [tblMembers]
                (
                    [MemberID],
                    [Name],
                    [Phone],
                    [Address],
                    [CreatedDate],
                    [Sl] 
                )
                VALUES
                (
                    @MemberID,
                    @Name,
                    @Phone,
                    @Address,                                                                      
                    @CreatedDate, 
                    @Sl 
                )
                    ]]></tblMembers_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblMembers_UPDATE As String
        Get
            Return <tblMembers_UPDATE><![CDATA[
                UPDATE [tblMembers]
                SET
                    [Name]=@Name,
                    [Phone]=@Phone,
                    [Address]=@Address 
                WHERE
                    [MemberID]=@MemberID
                    ]]></tblMembers_UPDATE>.Value
        End Get
    End Property
    Private ReadOnly Property tblMembers_MAX_ID As String
        Get
            Return <tblMembers_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblMembers]
                    ]]></tblMembers_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblMembers_Delete As String
        Get
            Return <tblMembers_Delete><![CDATA[
                DELETE FROM [tblMembers] WHERE [MemberID]=@MemberID
                    ]]></tblMembers_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblMembers_SELECT As String
        Get
            Return <tblMembers_SELECT><![CDATA[
                SELECT
                    [MemberID],
                    [Name],
                    [Phone],
                    [Address],
                    [CreatedDate],
                    [Sl] 
                FROM
                    [tblMembers]
                   ]]></tblMembers_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblMembers_SELECT_Visits As String
        Get
            Return <tblMembers_SELECT><![CDATA[
                SELECT
                    a.[MemberID],
                    a.[Name],
                    a.[Phone],
                    a.[Address],
                    a.[CreatedDate],
                    a.[Sl] ,
                    b.TotalVisit
                FROM
                    [tblMembers] a
                Left Outer Join
                    (
                        Select 
                                BookingType,
                                MemberID,
                                Count(BookingID) as [TotalVisit] 
                        from  
                            [tblBookings] 
                        Where 
                            BookingType='BOOKING'
                        Group By 
                            BookingType,
                            MemberID
                    ) b 
                on 
                    a.MemberID = b.MemberID  
                   ]]></tblMembers_SELECT>.Value
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
        Dim comID As New SQLCommand(tblMembers_MAX_ID, conn)
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
                           ByVal MemberID As String, _
                           ByVal Name As String, _
                           ByVal Phone As String, _
                           ByVal Address As String, _
                           ByVal CreatedDate As Date, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblMembers_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@MemberID", MemberID)
            .AddWithValue("@Name", Name)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Address", Address)
            '  .AddWithValue("@CreatedDate", CreatedDate)
            .Add("@CreatedDate", SqlDbType.DateTime).Value = Now
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
    Public Function Update( _
                           ByVal MemberID As String, _
                           ByVal Name As String, _
                           ByVal Phone As String, _
                           ByVal Address As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comUpdate As New SQLCommand(tblMembers_UPDATE, conn)
        If transact IsNot Nothing Then
            comUpdate.Transaction = transact
        End If

        With comUpdate.Parameters
            .AddWithValue("@Name", Name)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Address", Address)
            .AddWithValue("@MemberID", MemberID)
        End With
        Dim obj
        Try
            obj = comUpdate.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comUpdate.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comUpdate.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Updated")
        End If
        Return Val(obj)
    End Function
    Public Function Delete(ByVal MemberID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblMembers_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@MemberID", MemberID)
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
        VisitsCount = 1
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
                comSelect.CommandText = tblMembers_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.VisitsCount
                comSelect.CommandText = tblMembers_SELECT_Visits & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
