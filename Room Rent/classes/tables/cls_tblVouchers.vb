Public Class cls_tblVouchers

    Private ReadOnly Property tblVouchers_INSERT As String
        Get
            Return <tblVouchers_INSERT><![CDATA[
                INSERT INTO [tblVouchers]
                (
                    [VoucherId], 
                    [RefNo] , 
                    [VoucherDate] , 
                    [Valid] ,
                    [VoucherValue] ,
                    [Comment] ,
                    [Status] ,
                    [Type] 
                )
                VALUES
                (
                    @VoucherId, 
                    @RefNo , 
                    @VoucherDate , 
                    @Valid ,
                    @VoucherValue ,
                    @Comment ,
                    @Status ,
                    @Type 
                )
            ]]></tblVouchers_INSERT>.Value
        End Get
    End Property


    '    Private ReadOnly Property tblVouchers_USED_AMOUNT As String
    '        Get
    '            Return <tblVouchers_INSERT><![CDATA[
    ' Select (
    'Select iif(isnull(Sum (VoucherAmount)) ,0 ,Sum (VoucherAmount)) as [UsedValue]
    'from 
    'tblBookingPayments 
    'where VoucherID=@VoucherID
    ' )

    '+ 

    '(
    'Select iif(isnull(Sum (VoucherAmount)) ,0 ,Sum (VoucherAmount)) as [UsedValue]
    'from 
    'tblPayment
    'where VoucherID=@VoucherID 
    ')

    '            ]]></tblVouchers_INSERT>.Value
    '        End Get
    '    End Property



    Private ReadOnly Property tblVouchers_MAX_ID As String
        Get
            Return <tblVouchers_MAX_ID><![CDATA[
                SELECT MAX([VoucherId]) FROM [tblVouchers]
                    ]]></tblVouchers_MAX_ID>.Value
        End Get
    End Property

    Private ReadOnly Property tblVouchers_SELECT As String
        Get
            Return <tblVouchers_SELECT><![CDATA[
                SELECT
                    [VoucherId], 
                    [RefNo]  , 
                    [VoucherDate] , 
                    [Valid] ,
                    [VoucherValue] ,
                    [Comment] ,
                    [Status] ,
                    [Type] 
                FROM
                    [tblVouchers]
                   ]]></tblVouchers_SELECT>.Value
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
        Dim VoucherId As Integer = 1 '1 states that, the VoucherId field will start from 1
        Dim comID As New SQLCommand(tblVouchers_MAX_ID, conn)
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
            VoucherId = Val(obj) + 1
        End If
        Return VoucherId
    End Function

    Public Function Insert( _
                           ByVal RefNo As String, _
                           ByVal VoucherDate As Date, _
                           ByVal Valid As Integer, _
                           ByVal VoucherValue As Double, _
                           ByVal Comment As String, _
                           ByVal Status As String, _
                           ByVal Type As String, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblVouchers_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim VoucherId As Integer = MaxID(conn)

        With comInsert.Parameters
            .AddWithValue("@VoucherId", VoucherId)
            .AddWithValue("@RefNo", RefNo)
            .Add("@VoucherDate", SqlDbType.DateTime).Value = VoucherDate
            .AddWithValue("@Valid", Valid)
            .AddWithValue("@VoucherValue", VoucherValue)
            .AddWithValue("@Comment", Comment)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Type", Type)
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

        Return VoucherId
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
                comSelect.CommandText = tblVouchers_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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
