Public Class cls_tblProducts
    Private ReadOnly Property tblProducts_INSERT As String
        Get
            Return <tblProducts_INSERT><![CDATA[
                INSERT INTO [tblProducts]
                (
                    [ProductID],
                    [ProductName],
                    [Category],
                    [Brand],
                    [Price],
                    [Unit],
                    [Tax],
                    [Barcode],
                    [ExpireIn],
                    [ExpireInType],
                    [MinimumStock],
                    [EntryDate]
                )
                VALUES
                (
                    @ProductID,
                    @ProductName,
                    @Category,
                    @Brand,
                    @Price,
                    @Unit,
                    @Tax,
                    @Barcode,
                    @ExpireIn,
                    @ExpireInType,
                    @MinimumStock,
                    @EntryDate
                )
                    ]]></tblProducts_INSERT>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_MAX_ID As String
        Get
            Return <tblProducts_MAX_ID><![CDATA[
                SELECT MAX([ProductID]) FROM [tblProducts]
                    ]]></tblProducts_MAX_ID>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_Delete As String
        Get
            Return <tblProducts_Delete><![CDATA[
                DELETE FROM [tblProducts] WHERE [ProductID]=@ProductID
                    ]]></tblProducts_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_SELECT As String
        Get
            Return <tblProducts_SELECT><![CDATA[
                SELECT
                    [ProductID],
                    [ProductName],
                    [Category],
                    [Brand],
                    [Price],
                    [Unit],
                    [Tax],
                    [Barcode],
                    [ExpireIn],
                    [ExpireInType],
                    [MinimumStock],
                    [EntryDate]
                FROM
                    [tblProducts]
                   ]]></tblProducts_SELECT>.Value
        End Get
    End Property

    Private ReadOnly Property tblProducts_SELECT_ONLY_PRODUCT As String
        Get
            Return <tblProducts_SELECT><![CDATA[
                SELECT
                    [ProductID],
                    [ProductName]
                FROM
                    [tblProducts]
                   ]]></tblProducts_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_DISTINCT_CATEGORY As String
        Get
            Return <tblProducts_SELECT><![CDATA[
                SELECT
                    DISTINCT([Category]) as [Category]
                FROM
                    [tblProducts]
                   ]]></tblProducts_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_DISTINCT_BRAND As String
        Get
            Return <tblProducts_SELECT><![CDATA[
                SELECT
                    DISTINCT([Brand]) as [Brand]
                FROM
                    [tblProducts]
                   ]]></tblProducts_SELECT>.Value
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
        Dim comID As New SQLCommand(tblProducts_MAX_ID, conn)
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
                           ByVal ProductName As String, _
                           ByVal Category As String, _
                           ByVal Brand As String, _
                           ByVal Price As Double, _
                           ByVal Unit As String, _
                           ByVal Tax As Double, _
                           ByVal Barcode As String, _
                           ByVal ExpireIn As Integer, _
                           ByVal ExpireInType As String, _
                           ByVal MinimumStock As Integer, _
                           Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SQLCommand(tblProducts_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim ProductID As Integer = MaxID(conn)
        With comInsert.Parameters
            .AddWithValue("@ProductID", ProductID)
            .AddWithValue("@ProductName", ProductName)
            .AddWithValue("@Category", Category)
            .AddWithValue("@Brand", Brand)
            .AddWithValue("@Price", Price)
            .AddWithValue("@Unit", Unit)
            .AddWithValue("@Tax", Tax)
            .AddWithValue("@Barcode", Barcode)
            .AddWithValue("@ExpireIn", ExpireIn)
            .AddWithValue("@ExpireInType", ExpireInType)
            .AddWithValue("@MinimumStock", MinimumStock)
            .Add("@EntryDate", SqlDbType.DateTime).Value = Now
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
        Return ProductID
    End Function

    Public Function Delete(ByVal ProductID As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblProducts_Delete, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@ProductID", ProductID)
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
        DISTINCT_CATEGORY = 1
        SELECT_PRODUCT = 2
        DISTINCT_BRAND = 3
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
                comSelect.CommandText = tblProducts_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_CATEGORY
                comSelect.CommandText = tblProducts_DISTINCT_CATEGORY & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.SELECT_PRODUCT
                comSelect.CommandText = tblProducts_SELECT_ONLY_PRODUCT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
            Case SelectionType.DISTINCT_BRAND
                comSelect.CommandText = tblProducts_DISTINCT_BRAND & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("WHERE"), " ", " WHERE ") & SelectString, "")
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



    'Public Function LoadCustomer(ByVal lst As ListView, Optional ByVal Type As SelectionType = 0)
    '    lst.Items.Clear()
    '    Dim dt As DataTable = Nothing

    '    Select Case Type
    '        Case SelectionType.ALL
    '            dt = Selection()
    '        Case SelectionType.DC_14_DAYS
    '            Dim lstP As New List(Of SQLParameter)
    '            lstP.Add(New SQLParameter("Brand", Today.AddDays(-14)))
    '            dt = Selection("[Brand]>=@Brand", lstP)
    '        Case SelectionType.DC_EXPIRED
    '            Dim lstP As New List(Of SQLParameter)
    '            lstP.Add(New SQLParameter("Brand", Today.AddDays(-14)))
    '            dt = Selection("[Brand]<@Brand", lstP)
    '        Case SelectionType.SUSPENDED
    '            dt = Selection("[Status]='SUSPENDED'")
    '    End Select
    '    For i = 0 To dt.Rows.Count - 1
    '        Dim drItem As System.Data.DataRow = dt.Rows(i)
    '        Dim li As New ListViewItem
    '        li.Text = drItem("ProductName").ToString
    '        li.Tag = drItem("ProductID").ToString
    '        lst.Items.Add(li)
    '    Next

    'End Function

End Class
