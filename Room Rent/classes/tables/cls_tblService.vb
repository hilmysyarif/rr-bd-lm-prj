Public Class cls_tblService
    Private ReadOnly Property tblService_INSERT As String
        Get
            Return <tblService_INSERT><![CDATA[
                INSERT INTO [tblService]
                (
                    [Sl],
                    [Service],
                    [DayPrice], 
                    [NightPrice] 
                )
                VALUES
                (
                    @Sl,
                    @Service,
                    @DayPrice, 
                    @NightPrice 
                )
                    ]]></tblService_INSERT>.Value
        End Get
    End Property
    Private ReadOnly Property tblService_UPDATE As String
        Get
            Return <tblService_UPDATE><![CDATA[
                UPDATE [tblService]
                SET  
                    [DayPrice]=@DayPrice, 
                    [NightPrice]=@NightPrice  
                WHERE
                    [Sl]=@Sl 
                    ]]></tblService_UPDATE>.Value
        End Get
    End Property

    Private ReadOnly Property tblService_MAX_ID As String
        Get
            Return <tblService_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblService]
                    ]]></tblService_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblService_Delete As String
        Get
            Return <tblService_Delete><![CDATA[
                DELETE FROM [tblService] WHERE [Sl]=@Sl
                    ]]></tblService_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblService_SELECT As String
        Get
            Return <tblService_SELECT><![CDATA[
                SELECT
                    [Sl],
                    [Service],
                    [DayPrice], 
                    [NightPrice] 
                FROM
                    [tblService]
                   ]]></tblService_SELECT>.Value
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
        Dim comID As New SQLCommand(tblService_MAX_ID, conn)
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
                           ByVal Service As String, _
                           ByVal DayPrice As Double, _
                           ByVal NightPrice As Double, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblService_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@Service", Service)
            .AddWithValue("@DayPrice", DayPrice)
            .AddWithValue("@NightPrice", NightPrice)
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
                           ByVal DayPrice As Double, _
                           ByVal NightPrice As Double, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblService_UPDATE, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@DayPrice", DayPrice)
            .AddWithValue("@NightPrice", NightPrice)
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
    Public Function Delete(ByVal Sl As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblService_Delete, conn)
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
        DISTINCT_DayPrice = 1
        SELECT_PRODUCT = 2
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
                comSelect.CommandText = tblService_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_DayPrice
            Case SelectionType.SELECT_PRODUCT
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
    Enum PriceType
        DAY
        NIGHT
    End Enum
    Public Function SelectScalar( _
                        ByVal SERVICE As String, ByVal Pricetyp As PriceType, _
                        Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As String

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then

            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True

        End If

        Dim comInsert As New SQLCommand("SELECT [" & Pricetyp.ToString & "Price] FROM [tblService] where Service=@Service", conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim obj
        Try
            comInsert.Parameters.AddWithValue("@Service", SERVICE)
            obj = comInsert.ExecuteScalar
            If obj Is Nothing Then
                obj = 0
            End If
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comInsert.Dispose()
            Throw ex
        End Try

        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comInsert.Dispose()
        Return obj.ToString
    End Function


    'Function GetPrice(ByVal ServiceName As String, ByVal CustomeTime As Integer) As Double

    '    Dim price As Double = 0
    '    Dim PriceType As PriceType = PriceType.DAY
    '    If Val(Now.ToString("HH")) >= 8 And Val(Now.ToString("HH")) < 20 Then
    '        PriceType = PriceType.DAY
    '    Else
    '        PriceType = PriceType.NIGHT
    '    End If
    '    If ServiceName.ToUpper.Contains("CUSTOM") Then
    '        price = SelectScalar("CUSTOM", PriceType) * CustomeTime
    '    Else
    '        price = SelectScalar(ServiceName, PriceType)
    '    End If
    '    Return price
    'End Function

End Class
