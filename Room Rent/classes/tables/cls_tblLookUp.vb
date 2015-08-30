Public Class cls_tblLookUp
    Dim objPremiumServices As New cls_Temp_tblPremiumServices
    Dim objRoom As New cls_Temp_tblRoom
    Private ReadOnly Property tblLookUp_INSERT As String
        Get
            Return <tblLookUp_INSERT><![CDATA[
                INSERT INTO [tblLookUp]
                (
                    [Sl],
                    [Worker],
                    [Client], 
                    [Booking] , 
                    [Message] , 
                    [Extras] , 
                    [Service] , 
                    [SP_Amount] , 
                    [House_Amount] , 
                    [TotalAmount] , 
                    [Type] , 
                    [ServiceType] , 
                    [Room]
                )
                VALUES
                (
                    @Sl,
                    @Worker,
                    @Client, 
                    @Booking , 
                    @Message , 
                    @Extras , 
                    @Service , 
                    @SP_Amount , 
                    @House_Amount , 
                    @TotalAmount , 
                    @Type , 
                    @ServiceType , 
                    @Room 
                )
            ]]></tblLookUp_INSERT>.Value
        End Get
    End Property

    'Private ReadOnly Property tblLookUp_UPDATE As String
    '    Get
    '        Return <tblLookUp_UPDATE><![CDATA[
    '            UPDATE [tblLookUp]
    '            SET  
    '                [Client]=@Client, 
    '                [Booking]=@Booking  
    '            WHERE
    '                [Sl]=@Sl 
    '                ]]></tblLookUp_UPDATE>.Value
    '    End Get
    'End Property

    Private ReadOnly Property tblLookUp_MAX_ID As String
        Get
            Return <tblLookUp_MAX_ID><![CDATA[
                SELECT MAX([Sl]) FROM [tblLookUp]
                    ]]></tblLookUp_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblLookUp_Delete As String
        Get
            Return <tblLookUp_Delete><![CDATA[
                DELETE FROM [tblLookUp] WHERE [Sl]=@Sl
                    ]]></tblLookUp_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblLookUp_SELECT As String
        Get
            Return <tblLookUp_SELECT><![CDATA[
                SELECT
                    [Sl]            ,
                    [Worker]        ,
                    [Client]        , 
                    [Booking]       , 
                    [Message]       , 
                    [Extras]        , 
                    [Service]       , 
                    [SP_Amount]     , 
                    [House_Amount]  , 
                    [TotalAmount]   , 
                    [Type]          , 
                    [ServiceType]   , 
                    [Room]  
                FROM
                    [tblLookUp]
                   ]]></tblLookUp_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblLookUp_SELECT_INHRS As String
        Get
            Return <tblLookUp_SELECT><![CDATA[
                SELECT
                    [Sl]            ,
                    [Worker]        ,
                    [Client]        , 
                    [Booking]       , 
                    [Message]       , 
                    [Extras]        , 
                    CASE WHEN [Service]>89 THEN convert(varchar,(convert(float,[Service])/60)) + ' Hrs' ELSE convert(varchar,[Service]) + ' Mins' END as [Service],
                    [SP_Amount]     , 
                    [House_Amount]  , 
                    [TotalAmount]   , 
                    [Type]          , 
                    [ServiceType]   , 
                    [Room]          , 
                    [CreatedDate]   , 
                    [Service] as [Time]   
                FROM
                    [tblLookUp] a
                   ]]></tblLookUp_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblLookUp_UPDATE As String
        Get
            Return <tblLookUp_UPDATE><![CDATA[
                UPDATE
                    [tblLookUp]
                SET                    
                    [Worker]        =@Worker,
                    [Client]        =@Client, 
                    [Booking]       =@Booking  , 
                    [Message]       =@Message , 
                    [Extras]        =@Extras  , 
                    [Service]       =@Service , 
                    [SP_Amount]     =@SP_Amount , 
                    [House_Amount]  =@House_Amount , 
                    [TotalAmount]   =@TotalAmount , 
                    [Type]          =@Type, 
                    [ServiceType]   =@ServiceType, 
                    [Room]          =@Room
                WHERE
                    [Sl]=@Sl
                   ]]></tblLookUp_UPDATE>.Value

        End Get
    End Property
    Private ReadOnly Property tblLookUp_UPDATE_RESET As String
        Get
            Return <tblLookUp_UPDATE><![CDATA[
                UPDATE
                    [tblLookUp]
                SET       
                    [SP_Amount]     =0 , 
                    [House_Amount]  =0 , 
                    [TotalAmount]   =0 
                WHERE
                   1=1 
                   ]]></tblLookUp_UPDATE>.Value

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
        Dim comID As New SQLCommand(tblLookUp_MAX_ID, conn)
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
                           ByVal Worker As Double, _
                           ByVal Client As Double, _
                           ByVal Booking As Double, _
                           ByVal Message As String, _
                           ByVal Extras As String, _
                           ByVal Service As Double, _
                           ByVal SP_Amount As Double, _
                           ByVal House_Amount As Double, _
                           ByVal TotalAmount As Double, _
                           ByVal Type As String, _
                           ByVal ServiceType As String, _
                           ByVal Room As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False

        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comInsert As New SqlCommand(tblLookUp_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        Dim Sl As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@Worker", Worker)
            .AddWithValue("@Client", Client)
            .AddWithValue("@Booking", Booking)
            .AddWithValue("@Message", Message)
            .AddWithValue("@Extras", Extras)
            .AddWithValue("@Service", Service)
            .AddWithValue("@SP_Amount", SP_Amount)
            .AddWithValue("@House_Amount", House_Amount)
            .AddWithValue("@TotalAmount", TotalAmount)
            .AddWithValue("@Type", Type)
            .AddWithValue("@ServiceType", ServiceType)
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
        Return Sl
    End Function

    Public Function Update( _
                           ByVal Sl As Integer, _
                           ByVal Worker As Double, _
                           ByVal Client As Double, _
                           ByVal Booking As Double, _
                           ByVal Message As String, _
                           ByVal Extras As String, _
                           ByVal Service As Double, _
                           ByVal SP_Amount As Double, _
                           ByVal House_Amount As Double, _
                           ByVal TotalAmount As Double, _
                           ByVal Type As String, _
                           ByVal ServiceType As String, _
                           ByVal Room As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comUpdate As New SqlCommand(tblLookUp_UPDATE, conn)

        If transact IsNot Nothing Then
            comUpdate.Transaction = transact
        End If

        With comUpdate.Parameters
            .AddWithValue("@Worker", Worker)
            .AddWithValue("@Client", Client)
            .AddWithValue("@Booking", Booking)
            .AddWithValue("@Message", Message)
            .AddWithValue("@Extras", Extras)
            .AddWithValue("@Service", Service)
            .AddWithValue("@SP_Amount", SP_Amount)
            .AddWithValue("@House_Amount", House_Amount)
            .AddWithValue("@TotalAmount", TotalAmount)
            .AddWithValue("@Type", Type)
            .AddWithValue("@ServiceType", ServiceType)
            .AddWithValue("@Room", Room)
            .AddWithValue("@Sl", Sl)
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
        Return Sl
    End Function

    'Public Function Update( _
    '                       ByVal Sl As Integer, _
    '                       ByVal Client As Double, _
    '                       ByVal Booking As Double, _
    '                       Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
    '    Dim isDisposeConn As Boolean = False
    '    Dim objConn As clsConnection = Nothing
    '    If conn Is Nothing Then
    '        objConn = New clsConnection
    '        conn = objConn.connect
    '        isDisposeConn = True
    '    End If
    '    Dim comInsert As New SQLCommand(tblLookUp_UPDATE, conn)
    '    If transact IsNot Nothing Then
    '        comInsert.Transaction = transact
    '    End If
    '    With comInsert.Parameters
    '        .AddWithValue("@Client", Client)
    '        .AddWithValue("@Booking", Booking)
    '        .AddWithValue("@Sl", Sl)
    '    End With
    '    Dim obj
    '    Try
    '        obj = comInsert.ExecuteNonQuery
    '    Catch ex As Exception
    '        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
    '        comInsert.Dispose()
    '        Throw ex
    '    End Try
    '    If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
    '    comInsert.Dispose()
    '    If Val(obj) <= 0 Then
    '        Throw New Exception("No Record Inserted")
    '    End If
    '    Return Sl
    'End Function

    Public Function Delete(ByVal Sl As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblLookUp_Delete, conn)
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
        ALL_INHRS = 1
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
                comSelect.CommandText = tblLookUp_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.ALL_INHRS
                comSelect.CommandText = tblLookUp_SELECT_INHRS & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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

    Public Function Reset(ByVal SelectString As String, Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comReset As New SQLCommand("", conn)
        comReset.CommandText = tblLookUp_UPDATE_RESET & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("AND"), " ", " AND ") & SelectString, "")
        If Parameters IsNot Nothing Then
            comReset.Parameters.AddRange(Parameters.ToArray)
        End If
        Dim obj As Integer = 0
        Try
            obj = comReset.ExecuteNonQuery()
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comReset.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comReset.Dispose()
        Return obj

    End Function

    Enum PriceType
        NOTHIN
        DAY
        NIGHT
        EVENING
    End Enum

    Structure PriceSpec
        Dim ItemSl As Integer
        Dim Price As Double
        Dim WorkerAmount As Double
        Dim HouseAmount As Double
        Dim WorkerId As Integer
        Dim Shift As PriceType
        Dim Room As String
        Dim IsRoomExtra As String
        Dim IsWeekDayEstra As String
    End Structure

    Function GetPrice(ByVal Worker As Integer, ByVal Client As Integer, ByVal Service As Integer, ByVal ServiceType As String, ByVal Room As String, Optional IsNight As Boolean = True, Optional RoomExtra As Boolean = True, _
                        Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As PriceSpec
        Dim PriceTyp As PriceType = MyShiftType()
        If MySettings.OtherSettings.DayPrice Then
            If IsNight Then
                PriceTyp = PriceType.NIGHT
            End If
        End If
        Return GetPrice2(Worker, Client, Service, PriceTyp, ServiceType, Room)
    End Function

    Public Function GetPrice2(ByVal Worker As Integer, ByVal Client As Integer, ByVal Service As Integer, ByVal PriceTyp As PriceType, ByVal ServiceType As String, ByVal Room As String, Optional ByVal isZeroPriceError As Boolean = True, _
                       Optional IsRoomExtraExclude As Boolean = False, Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As PriceSpec
        Dim retv As New PriceSpec
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim MyRoom As String = ""

        If Room <> "ESCORT" Or MySettings.OtherSettings.SameEscortPrice Then
            MyRoom = "ROOM"
        Else
            MyRoom = Room
        End If

        Dim price As Double = 0
        Dim da As New SqlDataAdapter("SELECT * FROM [tblLookUp] where [Type]=@Type and [Worker]=@Worker and [Client]=@Client and [Service]=@Service and [ServiceType]=@ServiceType and [Room]=@Room", conn)
        Dim dt As New DataTable

        If transact IsNot Nothing Then
            da.SelectCommand.Transaction = transact
        End If
        Try

            da.SelectCommand.Parameters.AddWithValue("@Type", PriceTyp.ToString)
            da.SelectCommand.Parameters.AddWithValue("@Worker", Worker)
            da.SelectCommand.Parameters.AddWithValue("@Client", Client)
            da.SelectCommand.Parameters.AddWithValue("@Service", Service)
            da.SelectCommand.Parameters.AddWithValue("@ServiceType", ServiceType)
            da.SelectCommand.Parameters.AddWithValue("@Room", MyRoom)
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                Throw New Exception("No matching custom lookup found in database." & vbNewLine & vbNewLine & "SP # : " & Worker & vbNewLine & "Client #: " & Client & vbNewLine & "SERVICE : " & Service & " Mins " & ServiceType & " " & Room & vbNewLine & "SHIFT : " & PriceTyp.ToString)
            ElseIf Val(dt.Rows(0).Item("TotalAmount")) <= 0 And isZeroPriceError Then
                Throw New Exception("Price of Service is 0('Zero'). Please set the price." & vbNewLine & vbNewLine & "SP # : " & Worker & vbNewLine & "Client #: " & Client & vbNewLine & "SERVICE : " & Service & " Mins " & ServiceType & " " & Room & vbNewLine & "SHIFT : " & PriceTyp.ToString)
            Else
                retv.Price = Val(dt.Rows(0).Item("TotalAmount"))
                retv.WorkerAmount = Val(dt.Rows(0).Item("SP_Amount"))
                retv.HouseAmount = Val(dt.Rows(0).Item("House_Amount"))
                retv.ItemSl = Val(dt.Rows(0).Item("Sl"))
                retv.Shift = PriceTyp
                retv.Room = MyRoom
                retv.IsRoomExtra = "NO"
                retv.IsWeekDayEstra = "NO"

                Try

                    Dim dtPS As DataTable = objPremiumServices.Selection(cls_Temp_tblPremiumServices.SelectionType.All, "[weekday]=" & (Now.DayOfWeek + 1).ToString)
                    Dim dr As DataRow = dtPS.Rows(0)
                    retv.Price = Val(dt.Rows(0).Item("TotalAmount")) + Val(dr("Servicecharge"))
                    retv.WorkerAmount = Val(dt.Rows(0).Item("SP_Amount")) + Val(dr("SP"))
                    retv.HouseAmount = Val(dt.Rows(0).Item("House_Amount")) + Val(dr("House"))
                    retv.ItemSl = Val(dt.Rows(0).Item("Sl"))
                    retv.IsWeekDayEstra = "YES : SP : " & dr("SP") & " : HOUSE : " & dr("House")

                Catch ex As Exception
                End Try


                If Not IsRoomExtraExclude Then
                    Try
                        Dim dtROOM As DataTable = objRoom.Selection(cls_Temp_tblRoom.SelectionType.All, "[Room]='" & Room & "'")
                        Dim dr As DataRow = dtROOM.Rows(0)
                        retv.Price = retv.Price + Val(dr("AddlSP_Fee")) + Val(dr("AddlHouse_Fee"))
                        retv.WorkerAmount = retv.WorkerAmount + Val(dr("AddlSP_Fee"))
                        retv.HouseAmount = retv.HouseAmount + Val(dr("AddlHouse_Fee"))
                        retv.IsRoomExtra = "YES : SP : " & dr("AddlSP_Fee") & " : HOUSE : " & dr("AddlHouse_Fee")
                    Catch ex As Exception
                    End Try
                End If
            End If

        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            da.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        da.Dispose()
        Return retv
    End Function

End Class
